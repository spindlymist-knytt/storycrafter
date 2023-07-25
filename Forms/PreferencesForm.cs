using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Story_Crafter.Knytt;

namespace Story_Crafter.Forms {
    struct EditorDefinition {
        public string Name;
        public string Path;
        public string CmdString;

        public EditorDefinition(string name, string path, string cmdString) {
            this.Name = name;
            this.Path = path;
            this.CmdString = cmdString;
        }
    }

    public partial class PreferencesForm: Form {

        private string path;
        private int profile;

        public PreferencesForm() {
            InitializeComponent();

            this.textBox1.Text = this.path = Program.Path;

            foreach(Profile p in Profile.Profiles) {
                this.comboBox1.Items.Add(p.Name);
                if(p == Program.ActiveProfile) {
                    this.comboBox1.SelectedIndex = this.profile = this.comboBox1.Items.Count - 1;
                }
            }

            // TODO: change to AvEdit
            this.iniEditor1.Highlight();

            // TODO: make editor definitions customizable
            // TODO: grab icons from shell
            this.objectListView1.SmallImageList = new ImageList();
            this.objectListView1.SmallImageList.Images.Add("GIMP", Properties.Resources.gimp);
            this.objectListView1.SmallImageList.Images.Add("Paint", Properties.Resources.paint);
            this.objectListView1.SmallImageList.Images.Add("Paint.NET", Properties.Resources.paint_net);
            this.objectListView1.SmallImageList.Images.Add("Photoshop", Properties.Resources.photoshop);
            this.objectListView1.ColumnsInDisplayOrder[0].ImageGetter += delegate (object row) {
                return ((EditorDefinition)row).Name;
            };
            EditorDefinition gimp = new EditorDefinition("GIMP", @"D:\Program Files (x86)\GIMP\bin\gimp-2.6.exe", "\"%filename%\""),
                           paint = new EditorDefinition("Paint", @"C:\WINDOWS\system32\pbrush.exe", "\"%filename%\""),
                     paintNet = new EditorDefinition("Paint.NET", @"D:\Program Files (x86)\Paint.NET\paintnet.exe", "\"%filename%\""),
                     photoshop = new EditorDefinition("Photoshop", @"D:\Program Files (x86)\Adobe\Photoshop CS5\ps.exe", "\"%filename%\"");
            this.objectListView1.AddObject(gimp);
            this.objectListView1.AddObject(paint);
            this.objectListView1.AddObject(paintNet);
            this.objectListView1.AddObject(photoshop);

            this.button2.Click += delegate (object sender, EventArgs e) {
                FolderBrowserDialog browserDlg = new FolderBrowserDialog();
                browserDlg.Description = "Please select the folder that contains Knytt Stories.exe.";
                if(browserDlg.ShowDialog(Program.Editor) != DialogResult.OK) {
                    return;
                }
                this.textBox1.Text = browserDlg.SelectedPath;
            };
        }

        private void button4_Click(object sender, EventArgs e) {
            // TODO: centralize data.xml operations
            if(this.textBox1.Text != this.path) {
                this.path = this.textBox1.Text;
                // TODO create paths class
                Program.Path = this.textBox1.Text;
                Program.Data.GetElementsByTagName("path")[0].InnerText = Program.Path;
                FileStream fout = File.Open("data.xml", FileMode.Truncate, FileAccess.Write);
                XmlWriter writer = XmlWriter.Create(fout);
                Program.Data.WriteContentTo(writer);
                writer.Close();
                fout.Close();
            }

            if(this.comboBox1.SelectedIndex != this.profile) {
                this.profile = this.comboBox1.SelectedIndex;
                Program.ChangeProfile(Profile.Profiles[this.comboBox1.SelectedIndex]);
                Program.Data.GetElementsByTagName("active")[0].InnerText = Program.ActiveProfile.ID;
                FileStream fout = File.Open("data.xml", FileMode.Truncate, FileAccess.Write);
                XmlWriter writer = XmlWriter.Create(fout);
                Program.Data.WriteContentTo(writer);
                writer.Close();
                fout.Close();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PreferencesForm_Shown(object sender, EventArgs e) {
            this.textBox1.Text = this.path;
            this.comboBox1.SelectedIndex = this.profile;
        }
    }
}
