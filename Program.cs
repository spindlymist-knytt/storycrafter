using System;
using System.Collections.Generic;
using System.Drawing;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Story_Crafter {
    static class Program {
        public static EditorForm Editor;
        public static StartForm Start;
        public static DebugLog Debug;
        public static PreferencesForm Preferences;
        public static ImportScreensForm ImportScreens;

        public static Profile ActiveProfile;
        public static Story OpenStory = null;
        public static Screen ActiveScreen {
            get { return Program.OpenStory.ActiveScreen; }
        }
        public static Layer[] Layers {
            get { return Program.OpenStory.ActiveScreen.Layers; }
        }
        public static bool ChangingStory = false;
        public static string Path;
        public static string ObjectsPath;
        public static string WorldsPath;

        public static XmlDocument Data = new XmlDocument();
        public static ObjectBankList Banks = new ObjectBankList();
        public static byte[] Signature = new byte[5] { 0x00, 0xBE, 0x0B, 0x00, 0x00 }; // These five bytes appear after screen coordinates in every Map.bin file.
        public static Color Clothes = Color.FromArgb(235, 235, 235);                   // Default clothes color
        public static Color Skin = Color.FromArgb(216, 192, 166);                      // Default skin color
        public const int ScreenWidth = 25;
        public const int ScreenHeight = 10;
        public const int PxScreenWidth = Program.ScreenWidth * 24;
        public const int PxScreenHeight = Program.ScreenHeight * 24;
        public const int TilesetWidth = 16;
        public const int TilesetHeight = 8;

        public static Random Rand = new Random();

        public static Bitmap LoadBitmap(string path) {
            //return new Bitmap(new Bitmap(path)); Not sure why I wrote this, but leaving it in case it's useful.
            Bitmap b;
            try {
                b = new Bitmap(path);
            }
            catch(FileNotFoundException) {
                return null;
            }
            return b;
        }

        public static int ParseInt(string s, int onFail) {
            int i;
            if(!int.TryParse(s, out i)) i = onFail;
            return i;
        }
        public static int ScreenPointToIndex(Point p) {
            return ScreenPointToIndex(p.X, p.Y);
        }
        public static int ScreenPointToIndex(int x, int y) {
            return PointToIndex(x, y, Program.ScreenWidth);
        }
        public static Point ScreenIndexToPoint(int i) {
            return IndexToPoint(i, Program.ScreenWidth);
        }
        public static int TilesetPointToIndex(Point p) {
            return TilesetPointToIndex(p.X, p.Y);
        }
        public static int TilesetPointToIndex(int x, int y) {
            return PointToIndex(x, y, Program.TilesetWidth);
        }
        public static Point TilesetIndexToPoint(int i) {
            return IndexToPoint(i, Program.TilesetWidth);
        }

        private static int PointToIndex(Point p, int width) {
            return PointToIndex(p.X, p.Y, width);
        }
        private static int PointToIndex(int x, int y, int width) {
            return y * width + x;
        }
        private static Point IndexToPoint(int i, int width) {
            int y = i / width;
            return new Point(i - y * width, y);
        }

        public static void ChangeProfile(Profile p) {
            Program.Banks = p.Load();
            Program.ActiveProfile = p;
            GC.Collect();
        }
        /* private static List<Tuple<int, Bitmap>> LoadBank(string path, string indices) {
           List<int> bounds = new List<int>();
           string[] unparsed = indices.Split(new char[] { ' ', '-' });
           foreach(string s in unparsed) {
             bounds.Add(int.Parse(s));
           }
           List<Tuple<int, Bitmap>> objects = new List<Tuple<int, Bitmap>>();
           for(int r = 0; r < bounds.Count; r += 2) {
             for(int i = bounds[r]; i <= bounds[r + 1]; i++) {
               Bitmap b = Program.LoadBitmap(path + @"\Object" + i + ".png");
               b.MakeTransparent(Color.Magenta);
               objects.Add(Tuple.Create<int, Bitmap>(i, b));
             }
           }
           return objects;
         }
         private static void LoadProfile(string id) {
           foreach(XmlElement el in Program.Data.GetElementsByTagName("profile")) {
             if(el.Attributes["id"].Value != id) continue;
             LoadProfile(el);
             break;
           }
         }
         private static void LoadProfile(XmlElement el) {
           foreach(XmlElement bank in el["banks"].GetElementsByTagName("bank")) {
             int index = int.Parse(bank.Attributes["index"].Value);
             if(banksLoaded.Contains(index)) continue;
             banksLoaded.Add(index);
             List<Tuple<int, Bitmap>> objects;
             if(bank.HasChildNodes) {
               objects = new List<Tuple<int, Bitmap>>();
               foreach(XmlElement src in bank.GetElementsByTagName("src")) {
                 objects.AddRange(LoadBank(src.Attributes["path"].Value.Replace("%ks%", Program.Path), src.Attributes["objects"].Value));
               }
             }
             else {
               objects = LoadBank(Program.Path + @"\Data\Objects\Bank" + index, bank.Attributes["objects"].Value);
             }
             Program.Banks.Add(new ObjectBank(index, bank.Attributes["name"].Value, objects));
           }
           if(el.Attributes["base"] != null) {
             foreach(string b in ((string)el.Attributes["base"].Value).Split(' ')) {
               LoadProfile(b);
             }
           }
         }*/

        private static bool LoadGlobalData() {
            Program.Data.Load("data.xml");

            FolderBrowserDialog browserDlg = new FolderBrowserDialog();
            browserDlg.Description = "Please select the folder that contains Knytt Stories.exe.";
            Program.Path = Program.Data.GetElementsByTagName("path")[0].InnerText;
            if(Program.Path == "") {
                if(browserDlg.ShowDialog(Program.Editor) == DialogResult.OK) {
                    Program.Path = browserDlg.SelectedPath;
                }
                else {
                    return false;
                }
                Program.Data.GetElementsByTagName("path")[0].InnerText = Program.Path;
                FileStream fout = File.Open("data.xml", FileMode.Truncate, FileAccess.Write);
                XmlWriter writer = XmlWriter.Create(fout);
                Program.Data.WriteContentTo(writer);
                writer.Close();
                fout.Close();
            }
            Program.ObjectsPath = Program.Path + @"\Data\Objects";
            Program.WorldsPath = Program.Path + @"\Worlds";

            string active = Program.Data.GetElementsByTagName("active")[0].InnerText;
            foreach(XmlElement el in Program.Data.GetElementsByTagName("profile")) {
                Profile p = new Profile(el);
                if(p.ID.Equals(active)) {
                    Program.Banks = p.Load();
                    Program.ActiveProfile = p;
                }
            }
            if(Program.Banks == null) return false;

            return true;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(!Program.LoadGlobalData()) return;
            Program.Editor = new EditorForm();
            Program.Start = new StartForm();
            Program.Debug = new DebugLog();
            Program.Preferences = new PreferencesForm();
            Program.ImportScreens = new ImportScreensForm();
            Application.Run(Editor);
        }
    }
}
