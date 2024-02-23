using System;
using System.Collections.Generic;
using System.Drawing;

namespace Story_Crafter.Knytt {
    public partial class Story {
        public string Path {
            get { return path; }
            set { path = value; }
        }

        public Properties Props => props;

        public string Title {
            get { return props.Name; }
            set { props.Name = value; }
        }

        public string Author {
            get { return props.Author; }
            set { props.Author = value; }
        }

        public SaveData DefaultSave => defaultSave;

        public IReadOnlyDictionary<Point, Screen> Screens => screens as IReadOnlyDictionary<Point, Screen>;

        string path;
        Properties props;
        SaveData defaultSave;
        IDictionary<Point, Screen> screens = new Dictionary<Point, Screen>();

        Story() { }

        //public Story(string author, string title) {
        //    this.Path = Directory.CreateDirectory(Program.WorldsPath + "\\" + author + " - " + title).FullName;
        //    using (File.Create(this.Path + @"\World.ini")) { }
        //    this.WorldIni = new IniFile(this.Path + @"\World.ini");

        //    Resources.default_icon.Save(this.Path + @"\Icon.png");
        //    Resources.default_info.Save(this.Path + @"\Info.png");

        //    this.Author = author;
        //    this.Title = title;
        //    this.Description = "";
        //    this.Size = "";
        //    this.CategoryA = "";
        //    this.CategoryB = "";
        //    this.DifficultyA = "";
        //    this.DifficultyB = "";
        //    this.DifficultyC = "";

        //    this.Clothes = Metrics.DefaultClothes;
        //    this.Skin = Metrics.DefaultSkin;

        //    this.DefaultSave = new SaveData();
        //    this.DefaultSave.MapX = 1000;
        //    this.DefaultSave.MapY = 1000;
        //    this.DefaultSave.ScreenX = 0;
        //    this.DefaultSave.ScreenY = 0;
        //    this.DefaultSave.Powers = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };

        //    Screen start = new Screen(1000, 1000);
        //    this.Screens = new() {
        //        start
        //    };
        //    this.ActiveScreen = start;

        //    this.Patterns = new List<Pattern>();

        //    this.Save();
        //}

        public Screen GetScreen(int x, int y) {
            return screens[new Point(x, y)];
        }

        public void AddScreen(Screen screen) {
            screens[new Point(screen.X, screen.Y)] = screen;
        }

        public void AddScreens(IEnumerable<Screen> screens) {
            foreach (Screen screen in screens) {
                AddScreen(screen);
            }
        }

        public void Save() {
            //// Write screen data to memory.

            //Story_Crafter.MemoryStream data = new Story_Crafter.MemoryStream();
            //BinaryWriter writer = new BinaryWriter(data);

            //foreach(Screen s in Screens) {
            //    writer.Write(("x" + s.X + "y" + s.Y).ToCharArray());
            //    writer.Write(Program.Signature);
            //    for(int i = 0; i < 4; i++) {
            //        foreach(Tile t in s.Layers[i].Tiles) {
            //            writer.Write((byte)((t.Tileset == 1 ? 128 : 0) + t.Index));
            //        }
            //    }
            //    for(int i = 4; i <= 7; i++) {
            //        byte[] banks = new byte[250];
            //        int j = 0;
            //        foreach(Tile t in s.Layers[i].Tiles) {
            //            writer.Write((byte)t.Index);
            //            banks[j] = (byte)t.Bank;
            //            j++;
            //        }
            //        writer.Write(banks);
            //    }
            //    writer.Write((byte)s.TilesetA);
            //    writer.Write((byte)s.TilesetB);
            //    writer.Write((byte)s.AmbianceA);
            //    writer.Write((byte)s.AmbianceB);
            //    writer.Write((byte)s.Music);
            //    writer.Write((byte)s.Gradient);
            //}

            //// Compress and save screen data.

            //FileStream mapBin = new FileStream(this.Path + @"\Map.bin", FileMode.Create, FileAccess.Write);
            //GZipStream zipStream = new GZipStream(mapBin, CompressionMode.Compress);
            //zipStream.Write(data.GetBuffer(), 0, (int)data.Length);
            //zipStream.Close();
            //mapBin.Close();
            //data.Close();
            //writer.Close();

            //// Update World.ini.

            //File.WriteAllText(WorldIni.Path, worldIniText);

            //WorldIni.Write("World", "Author", this.Author);
            //WorldIni.Write("World", "Name", this.Title);
            //WorldIni.Write("World", "Description", this.Description);
            //WorldIni.Write("World", "Size", this.Size);
            //WorldIni.Write("World", "Category A", this.CategoryA);
            //WorldIni.Write("World", "Category B", this.CategoryB);
            //WorldIni.Write("World", "Difficulty A", this.DifficultyA);
            //WorldIni.Write("World", "Difficulty B", this.DifficultyB);
            //WorldIni.Write("World", "Difficulty C", this.DifficultyC);
            //WorldIni.Write("World", "Clothes", (this.Clothes.R + this.Clothes.G * 256 + this.Clothes.B * 65536).ToString());
            //WorldIni.Write("World", "Skin", (this.Skin.R + this.Skin.G * 256 + this.Skin.B * 65536).ToString());

            //// Update DefaultSavegame.ini.

            //IniFile saveINI = new IniFile(this.Path + @"\DefaultSavegame.ini");
            //saveINI.Write("Positions", "X Map", this.DefaultSave.MapX.ToString());
            //saveINI.Write("Positions", "Y Map", this.DefaultSave.MapY.ToString());
            //saveINI.Write("Positions", "X Pos", this.DefaultSave.ScreenX.ToString());
            //saveINI.Write("Positions", "Y Pos", this.DefaultSave.ScreenY.ToString());
            //for(int i = 0; i < 12; i++)
            //    saveINI.Write("Powers", "Power" + i, this.DefaultSave.Powers[i].ToString());

            //// Update path.
            //string newPath = Program.WorldsPath + "\\" + this.Author + " - " + this.Title;
            //if(newPath != this.Path) {
            //    Directory.Move(this.Path, newPath);
            //    this.Path = newPath;
            //}

            //// Save patterns

            //try {
            //    using(FileStream patternsFile = new FileStream(this.Path + @"\.story_crafter_patterns", FileMode.Create, FileAccess.Write)) {
            //        BinaryFormatter formatter = new BinaryFormatter();
            //        formatter.Serialize(patternsFile, Patterns);
            //    }
            //}
            //catch {
            //    // TODO error message
            //}

        }
    }
}
