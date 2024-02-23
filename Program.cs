using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using Story_Crafter.Config;
using Story_Crafter.Knytt;
using Story_Crafter.Forms;
using Story_Crafter.Forms.Editor;

namespace Story_Crafter {
    static class Program {
        public static EditorForm Editor;
        public static StartForm Start;
        public static LogsForm Debug;
        public static PreferencesForm Preferences;
        public static ImportScreensForm ImportScreens;

        public static Profile ActiveProfile;
        public static bool ChangingStory = false;
        public static string Path;
        public static string ObjectsPath;
        public static string WorldsPath;

        public static XmlDocument Data = new XmlDocument();
        public static ObjectBankList Banks = new ObjectBankList();

        public static Random Rand = new Random();

        public static Bitmap LoadBitmap(string path) {
            try {
                using (var temp = new Bitmap(path)) {
                    return new Bitmap(temp);
                }
            }
            catch(FileNotFoundException) {
                return null;
            }
        }

        public static void ChangeProfile(Profile p) {
            Program.Banks = p.Load();
            Program.ActiveProfile = p;
            GC.Collect();
        }

        private static bool LoadGlobalData() {
            Program.Data.Load("Resources/Data/data.xml");

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
                FileStream fout = File.Open("Resources/Data/data.xml", FileMode.Truncate, FileAccess.Write);
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

            StoryCrafterConfiguration config = new("Resources/Data");
            config.Load();

            if(!Program.LoadGlobalData()) return;

            Program.Debug = new LogsForm();
            Program.Start = new StartForm();
            Program.Editor = new EditorForm();
            Program.Preferences = new PreferencesForm();
            Program.ImportScreens = new ImportScreensForm();

            Application.Run(Editor);
        }
    }
}
