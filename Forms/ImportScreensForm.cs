using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Story_Crafter.Editing;
using Story_Crafter.Knytt;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Forms {
    public partial class ImportScreensForm: Form {

        ListViewItemComparer lvItemComparer = new ListViewItemComparer();
        Story story;

        public ImportScreensForm() {
            InitializeComponent();

            this.storyList.ListViewItemSorter = lvItemComparer;
            this.ClientSize = new Size(602, 482);
        }

        private void ImportScreensForm_Shown(object sender, EventArgs e) {
            // TODO make reusable
            DirectoryInfo worldsDir = new DirectoryInfo(Program.Path + @"\Worlds");
            IniFile ini = new IniFile();
            this.storyList.Items.Clear();
            foreach(DirectoryInfo dir in worldsDir.EnumerateDirectories()) {
                if(!File.Exists(dir.FullName + @"\Map.bin") || !File.Exists(dir.FullName + @"\World.ini")) continue;
                ini.Path = dir.FullName + @"\World.ini";
                this.storyList.Items.Add(ini.Read("World", "Author")).SubItems.AddRange(new string[2] { ini.Read("World", "Name"), dir.FullName });
            }
        }
        private void loadStory_Click(object sender, EventArgs e) {
            if(this.storyList.SelectedItems.Count < 1) return;
            try {
                this.story = new Story((string)this.storyList.SelectedItems[0].SubItems[2].Text);
                this.Text = "Import Screens: " + this.story.Title;
                this.mapViewPanel1.BringToFront();
                this.mapViewPanel1.TheStory = story;
                mapViewPanel1.ResetSelection(story.DefaultSave.MapX, story.DefaultSave.MapY);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString(), "Failed to load story", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void storyList_ColumnClick(object sender, ColumnClickEventArgs e) {
            if(this.lvItemComparer.Column == e.Column) {
                this.lvItemComparer.Order = this.lvItemComparer.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else this.lvItemComparer.Column = e.Column;
            this.storyList.Sort();
        }

        private void ImportScreensForm_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.C && e.Modifiers == Keys.Control) {
                List<Screen> screens = new List<Screen>();
                foreach(Selection.SelectionNode n in this.mapViewPanel1.GetSelection().nodes) {
                    Screen s = this.mapViewPanel1.TheStory.GetScreen(n.X, n.Y);
                    if(s == null) continue;
                    if(s != null) screens.Add(s);
                }
                Clipboard.SetData("StoryCrafterTemp", screens);
                screens = (List<Screen>)Clipboard.GetData("StoryCrafterTemp"); // Duplicates Screen instances so we don't change the coordinates of the originals
                GC.Collect();
                foreach(Screen s in screens) {
                    s.X -= this.mapViewPanel1.GetSelection().MinX;
                    s.Y -= this.mapViewPanel1.GetSelection().MinY;
                }
                Clipboard.SetData("StoryCrafterScreens", screens);
            }
        }

        private void ImportScreensForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
                this.Text = "Import Screens";
                this.mapViewPanel1.SendToBack();
                this.mapViewPanel1.TheStory = null;
                GC.Collect();
            }
        }
    }
}
