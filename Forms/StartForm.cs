using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;
using Story_Crafter.Knytt;

namespace Story_Crafter.Forms {
    partial class StartForm: Form {
        ListViewItemComparer lvItemComparer = new ListViewItemComparer();

        public Story SelectedStory { get; private set; }

        public StartForm() {
            InitializeComponent();
            storyList.ListViewItemSorter = lvItemComparer;
        }
        private void StartForm_Shown(object sender, EventArgs e) {
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
                SelectedStory = new Story((string)this.storyList.SelectedItems[0].SubItems[2].Text);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString(), "Failed to load story", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createStory_Click(object sender, EventArgs e) {
            // TODO verify legal directory name
            if(storyAuthor.Text == "" || storyTitle.Text == "") return;
            if(Directory.Exists(Program.WorldsPath + "\\" + storyAuthor.Text + " - " + storyTitle.Text)) {
                MessageBox.Show("That story already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SelectedStory = new Story(storyAuthor.Text, storyTitle.Text);
            this.DialogResult = DialogResult.OK;
        }

        /*private void DoLoadStory(object sender, DoWorkEventArgs e)
        {
          ((BackgroundWorker)sender).ReportProgress(0, "Loading screen data...");
          Program.OpenStory = new Story((string)e.Argument);

          ((BackgroundWorker)sender).ReportProgress(Program.OpenStory.Screens.Count, "set max");
          Program.OpenStory.CacheThumbnails((BackgroundWorker)sender);
          GC.Collect();
        }*/
        private void storyList_ColumnClick(object sender, ColumnClickEventArgs e) {
            if(this.lvItemComparer.Column == e.Column) {
                this.lvItemComparer.Order = this.lvItemComparer.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else this.lvItemComparer.Column = e.Column;
            storyList.Sort();
        }

    }
}
