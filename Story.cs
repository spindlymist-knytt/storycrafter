using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.IO;
using System.IO.Compression;

/* Format of Map.bin data:
         
    1 byte  x
   ?? bytes	X coordinate (ASCII)
    1 byte	y
   ?? bytes	Y coordinate (ASCII)
    5 bytes	00 BE 0B 00 00
  250 bytes	Layer 0 tile indices (128-255 is tileset B)
  250 bytes	Layer 1 tile indices
  250 bytes	Layer 2 tile indices
  250 bytes	Layer 3 tile indices
  250 bytes	Layer 4 object indices
  250 bytes	Layer 4 banks
  250 bytes	Layer 5 object indices
  250 bytes	Layer 5 banks
  250 bytes	Layer 6 object indices
  250 bytes	Layer 6 banks
  250 bytes	Layer 7 object indices
  250 bytes	Layer 7 banks
    1 byte	Tileset A
    1 byte	Tileset B
    1 byte	Music
    1 byte	Ambiance A
    1 byte	Ambiance B
    1 byte	Gradient
*/

namespace Story_Crafter {
    class FileCorruptException: System.Exception {
        public FileCorruptException(string message) : base(message) {
        }
    }
    struct SaveInfo {
        public int MapX, MapY;
        public int ScreenX, ScreenY;
        public bool[] Powers;
    }

    class Story {
        #region Fields
        public string Path;
        public string Author, Title, Description;
        public string Size;
        public string CategoryA, CategoryB;
        public string DifficultyA, DifficultyB, DifficultyC;
        public Color Clothes, Skin;
        public SaveInfo DefaultSave;
        public List<Screen> Screens;
        public IniFile WorldIni;

        public Tileset TilesetACache, TilesetBCache;
        public Bitmap GradientCache;
        public Screen ActiveScreen;

        public Boolean ThumbnailsCached = false;
        #endregion

        public Story(string author, string title) {
            this.Path = Directory.CreateDirectory(Program.WorldsPath + "\\" + author + " - " + title).FullName;
            using(File.Create(this.Path + @"\World.ini")) { }
            this.WorldIni = new IniFile(this.Path + @"\World.ini");

            Story_Crafter.Properties.Resources.default_icon.Save(this.Path + @"\Icon.png");
            Story_Crafter.Properties.Resources.default_info.Save(this.Path + @"\Info.png");

            this.Author = author;
            this.Title = title;
            this.Description = "";
            this.Size = "";
            this.CategoryA = "";
            this.CategoryB = "";
            this.DifficultyA = "";
            this.DifficultyB = "";
            this.DifficultyC = "";

            this.Clothes = Program.Clothes;
            this.Skin = Program.Skin;

            this.DefaultSave = new SaveInfo();
            this.DefaultSave.MapX = 1000;
            this.DefaultSave.MapY = 1000;
            this.DefaultSave.ScreenX = 0;
            this.DefaultSave.ScreenY = 0;
            this.DefaultSave.Powers = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };

            Screen start = new Screen(1000, 1000);
            this.Screens = new List<Screen>(1);
            this.Screens.Add(start);
            this.ActiveScreen = start;

            this.TilesetACache = this.CreateTileset(this.ActiveScreen.TilesetA);
            this.TilesetBCache = this.CreateTileset(this.ActiveScreen.TilesetB);
            this.GradientCache = Program.LoadBitmap(this.Gradient(this.ActiveScreen.Gradient));

            this.Save();
        }

        public Story(string path) {
            this.Path = path;

            // Extract World.ini info.
            this.WorldIni = new IniFile(this.Path + @"\World.ini");
            this.Author = WorldIni.Read("World", "Author");
            this.Title = WorldIni.Read("World", "Name");
            this.Description = WorldIni.Read("World", "Description");
            this.Size = WorldIni.Read("World", "Size");
            this.CategoryA = WorldIni.Read("World", "Category A");
            this.CategoryB = WorldIni.Read("World", "Category B");
            this.DifficultyA = WorldIni.Read("World", "Difficulty A");
            this.DifficultyB = WorldIni.Read("World", "Difficulty B");
            this.DifficultyC = WorldIni.Read("World", "Difficulty C");

            try {
                int clothes = int.Parse(this.WorldIni.Read("World", "Clothes"));
                this.Clothes = Color.FromArgb(clothes & 0xFF, (clothes & 0xFF00) / 256, clothes / 65536); // Bit operations... best just move along.
            }
            catch(Exception) {
                this.Clothes = Program.Clothes;
            }
            try {
                int skin = int.Parse(this.WorldIni.Read("World", "Skin"));
                this.Skin = Color.FromArgb(skin & 0xFF, (skin & 0xFF00) / 256, skin / 65536);
            }
            catch(Exception) {
                this.Skin = Program.Skin;
            }

            // Extract DefaultSavegame.ini info.
            IniFile saveIni = new IniFile(this.Path + @"\DefaultSavegame.ini");
            this.DefaultSave = new SaveInfo();
            this.DefaultSave.MapX = Program.ParseInt(saveIni.Read("Positions", "X Map"), 1000);
            this.DefaultSave.MapY = Program.ParseInt(saveIni.Read("Positions", "Y Map"), 1000);
            this.DefaultSave.ScreenX = Program.ParseInt(saveIni.Read("Positions", "X Pos"), 0);
            this.DefaultSave.ScreenY = Program.ParseInt(saveIni.Read("Positions", "Y Pos"), 0);
            this.DefaultSave.Powers = new bool[12];
            for(int i = 0; i < 12; i++)
                this.DefaultSave.Powers[i] = saveIni.Read("Powers", "Power" + i) == "1";

            // Extract data from Map.bin.
            FileStream fileIn = File.OpenRead(this.Path + @"\Map.bin");
            Story_Crafter.MemoryStream data = new Story_Crafter.MemoryStream();
            GZipStream zipStream = new GZipStream(fileIn, CompressionMode.Decompress);
            zipStream.CopyTo(data);
            zipStream.Close();
            fileIn.Close();
            data.Seek(0, SeekOrigin.Begin);

            // Load all the screens. 1000 screens currently take about 25 mb of memory not including thumbnails.
            this.Screens = new List<Screen>();
            try {
                Screen s = this.LoadScreen(data);
                while(s != null) {
                    this.Screens.Add(s);
                    s = this.LoadScreen(data);
                }
            }
            catch(Exception) {
                throw;
            }
            finally {
                GC.Collect();
                data.Close();
            }

            if(Screens.Count == 0) { // If there are no screens, create a blank one to start on.
                Screen start = new Screen(1000, 1000);
                this.Screens.Add(start);
                this.ActiveScreen = start;
            }
            else {
                this.ActiveScreen = GetScreen(this.DefaultSave.MapX, this.DefaultSave.MapY); // Try the screen given as Juni's starting position.
                if(this.ActiveScreen == null) {
                    this.ActiveScreen = this.GetScreen(1000, 1000);                            // If that screen doesn't exist, try x1000y1000.
                    if(this.ActiveScreen == null) this.ActiveScreen = this.Screens[0];         // If that doesn't exist either, use whatever the first screen in Map.bin is.
                }
            }
            this.TilesetACache = this.CreateTileset(this.ActiveScreen.TilesetA);
            this.TilesetBCache = this.CreateTileset(this.ActiveScreen.TilesetB);
            this.GradientCache = Program.LoadBitmap(this.Gradient(this.ActiveScreen.Gradient));
        }
        public string Tileset(int index) {
            string guess = this.Path + @"\Tilesets\Tileset" + index + ".png";
            if(File.Exists(guess)) return guess;
            return Program.Path + @"\Data\Tilesets\Tileset" + index + ".png";
        }
        public Tileset CreateTileset(int index) {
            return new Tileset(this.Tileset(index));
        }
        public string Gradient(int index) {
            string guess = this.Path + @"\Gradients\Gradient" + index + ".png";
            if(File.Exists(guess)) return guess;
            return Program.Path + @"\Data\Gradients\Gradient" + index + ".png";
        }
        public string Music(int index) {
            return "";
        }
        public string Ambiance(int index) {
            return "";
        }
        public void CacheThumbnails(System.ComponentModel.BackgroundWorker bgWorker) {
            Rectangle src = new Rectangle(0, 0, 600, 240),
                    dest = new Rectangle(0, 0, 200, 80);
            var tilesetCache = new Dictionary<int, Tileset>();
            var gradientCache = new Dictionary<int, Bitmap>();
            int done = 0;
            foreach(Screen s in this.Screens) {
                Tileset a, b;
                Bitmap gradient;
                if(!tilesetCache.TryGetValue(s.TilesetA, out a)) {
                    a = new Tileset(this.Tileset(s.TilesetA));
                    tilesetCache.Add(s.TilesetA, a);
                }
                if(!tilesetCache.TryGetValue(s.TilesetB, out b)) {
                    b = new Tileset(this.Tileset(s.TilesetB));
                    tilesetCache.Add(s.TilesetB, b);
                }
                if(!gradientCache.TryGetValue(s.Gradient, out gradient)) {
                    gradient = new Bitmap(this.Gradient(s.Gradient));
                    gradientCache.Add(s.Gradient, gradient);
                }
                Bitmap thumbnail = new Bitmap(600, 240);
                s.Draw(Graphics.FromImage(thumbnail), a, b, gradient);
                s.Thumbnail = new Bitmap(200, 80);
                Graphics g = Graphics.FromImage(s.Thumbnail);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(thumbnail, dest, src, GraphicsUnit.Pixel);
                done++;
                bgWorker.ReportProgress(done);
            }
            this.ThumbnailsCached = true;
        }
        private Screen LoadScreen(Story_Crafter.MemoryStream data) {
            if(data.Position == data.Length) return null;
            Screen s = new Screen();
            try {
                // Read x coordinate.
                // I allow any number of characters at the beginning of the file due to a strange bug in the stock editor that results in several megabytes of garbage before the screen data begins in a some levels.
                char c;
                do c = (char)data.ReadByte(); while(c != 'x');
                if(c != 'x') throw new FileCorruptException("Could not find an x coordinate.");
                string read = "";
                c = (char)data.ReadByte();
                while(c != 'y') {
                    if(!char.IsDigit(c)) throw new FileCorruptException("Non-numeric characters present in x coordinate.");
                    read += c;
                    c = (char)data.ReadByte();
                }
                s.X = int.Parse(read);

                // Read y coordinate. Almost exactly as above, but not really worth an entire function.
                read = "";
                c = (char)data.ReadByte();
                while(c != '\0') {
                    if(!char.IsDigit(c)) throw new FileCorruptException("Non-numeric characters present in y coordinate.");
                    read += c;
                    c = (char)data.ReadByte();
                }
                s.Y = int.Parse(read);

                // Ensure there is enough data left in the stream (4 + 12 * 250 + 6 = 3010) before I go crazy allocating memory.
                // I didn't do this before because the length of the coordinates is variable.
                if(data.Length - data.Position < 3010) throw new FileCorruptException("Not enough data is present.");

                // Check the constant for integrity. It starts at 1 because the first byte is checked finding the y coordinate.
                for(int i = 1; i < 5; i++) {
                    if(data.ReadByte() != Program.Signature[i]) throw new FileCorruptException("Signature is missing.");
                }

                // Now begin reading actual tile data.
                for(int i = 0; i < 4; i++) { // Tile layers.
                    s.Layers[i] = new TileLayer(data.Read(250));
                }
                for(int i = 4; i < 8; i++) { // Object layers.
                    s.Layers[i] = new ObjectLayer(data.Read(500));
                }

                // Read which assets the screen uses.
                s.TilesetA = data.ReadByte();
                s.TilesetB = data.ReadByte();
                s.AmbianceA = data.ReadByte();
                s.AmbianceB = data.ReadByte();
                s.Music = data.ReadByte();
                s.Gradient = data.ReadByte();
            }
            catch(IOException) {
                throw new FileCorruptException("I/O exception.");
            }
            return s;
        }
        public Screen GetScreen(int x, int y) {
            foreach(Screen s in this.Screens) {
                if(s.X == x && s.Y == y) return s;
            }
            return null;
        }
        public void AddScreen(Screen screen) {
            Screen check = this.GetScreen(screen.X, screen.Y);
            if(check != null) this.Screens.Remove(check);
            this.Screens.Add(screen);
        }
        public void AddScreens(List<Screen> screens) {
            foreach(Screen s in screens) {
                Screen check = this.GetScreen(s.X, s.Y);
                if(check != null) this.Screens.Remove(check);
                this.Screens.Add(s);
            }
            GC.Collect();
        }
        public void ChangeScreen(int x, int y) {
            this.ActiveScreen = this.GetScreen(x, y);
            if(this.ActiveScreen == null) {
                this.ActiveScreen = new Screen(x, y);
            }
            this.TilesetACache = this.CreateTileset(this.ActiveScreen.TilesetA);
            this.TilesetBCache = this.CreateTileset(this.ActiveScreen.TilesetB);
            this.GradientCache = Program.LoadBitmap(this.Gradient(this.ActiveScreen.Gradient));
        }
        public void Save(string worldIniText = "") {
            // Write screen data to memory.

            Story_Crafter.MemoryStream data = new Story_Crafter.MemoryStream();
            BinaryWriter writer = new BinaryWriter(data);

            foreach(Screen s in Screens) {
                writer.Write(("x" + s.X + "y" + s.Y).ToCharArray());
                writer.Write(Program.Signature);
                for(int i = 0; i < 4; i++) {
                    foreach(Tile t in s.Layers[i].Tiles) {
                        writer.Write((byte)((t.Tileset == 1 ? 128 : 0) + t.Index));
                    }
                }
                for(int i = 4; i <= 7; i++) {
                    byte[] banks = new byte[250];
                    int j = 0;
                    foreach(Tile t in s.Layers[i].Tiles) {
                        writer.Write((byte)t.Index);
                        banks[j] = (byte)t.Bank;
                        j++;
                    }
                    writer.Write(banks);
                }
                writer.Write((byte)s.TilesetA);
                writer.Write((byte)s.TilesetB);
                writer.Write((byte)s.AmbianceA);
                writer.Write((byte)s.AmbianceB);
                writer.Write((byte)s.Music);
                writer.Write((byte)s.Gradient);
            }

            // Compress and save screen data.

            FileStream mapBin = new FileStream(this.Path + @"\Map.bin", FileMode.Create, FileAccess.Write);
            GZipStream zipStream = new GZipStream(mapBin, CompressionMode.Compress);
            zipStream.Write(data.GetBuffer(), 0, (int)data.Length);
            zipStream.Close();
            mapBin.Close();
            data.Close();
            writer.Close();

            // Update World.ini.

            File.WriteAllText(WorldIni.Path, worldIniText);

            WorldIni.Write("World", "Author", this.Author);
            WorldIni.Write("World", "Name", this.Title);
            WorldIni.Write("World", "Description", this.Description);
            WorldIni.Write("World", "Size", this.Size);
            WorldIni.Write("World", "Category A", this.CategoryA);
            WorldIni.Write("World", "Category B", this.CategoryB);
            WorldIni.Write("World", "Difficulty A", this.DifficultyA);
            WorldIni.Write("World", "Difficulty B", this.DifficultyB);
            WorldIni.Write("World", "Difficulty C", this.DifficultyC);
            WorldIni.Write("World", "Clothes", (this.Clothes.R + this.Clothes.G * 256 + this.Clothes.B * 65536).ToString());
            WorldIni.Write("World", "Skin", (this.Skin.R + this.Skin.G * 256 + this.Skin.B * 65536).ToString());

            // Update DefaultSavegame.ini.

            IniFile saveINI = new IniFile(this.Path + @"\DefaultSavegame.ini");
            saveINI.Write("Positions", "X Map", this.DefaultSave.MapX.ToString());
            saveINI.Write("Positions", "Y Map", this.DefaultSave.MapY.ToString());
            saveINI.Write("Positions", "X Pos", this.DefaultSave.ScreenX.ToString());
            saveINI.Write("Positions", "Y Pos", this.DefaultSave.ScreenY.ToString());
            for(int i = 0; i < 12; i++)
                saveINI.Write("Powers", "Power" + i, this.DefaultSave.Powers[i].ToString());

            // Update path.
            string newPath = Program.WorldsPath + "\\" + this.Author + " - " + this.Title;
            if(newPath != this.Path) {
                Directory.Move(this.Path, newPath);
                this.Path = newPath;
            }
        }
    }
}