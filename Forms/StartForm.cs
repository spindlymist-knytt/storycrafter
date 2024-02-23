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
            this.storyList.Items.Clear();
            DirectoryInfo worldsDir = new DirectoryInfo(Program.Path + @"\Worlds");

            foreach (DirectoryInfo dir in worldsDir.EnumerateDirectories()) {
                string worldIniPath = Path.Combine(dir.FullName, "World.ini");
                string mapBinPath = Path.Combine(dir.FullName, "Map.bin");

                if (
                    !File.Exists(worldIniPath)
                    || !File.Exists(mapBinPath)
                ) {
                    continue;
                }

                var props = Story.Properties.Parser.Parse(worldIniPath);
                this.storyList.Items
                    .Add(props.Author)
                    .SubItems.AddRange(new string[2] {
                        props.Name,
                        dir.FullName,
                    });
            }
        }

        private void loadStory_Click(object sender, EventArgs e) {
            if(this.storyList.SelectedItems.Count < 1) return;
            try {
                string path = Path.Combine(Program.WorldsPath, this.storyList.SelectedItems[0].SubItems[2].Text);
                SelectedStory = Story.Parser.FromDirectory(path);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString(), "Failed to load story", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createStory_Click(object sender, EventArgs e) {
            // TODO verify legal directory name
            //if(storyAuthor.Text == "" || storyTitle.Text == "") return;
            //if(Directory.Exists(Program.WorldsPath + "\\" + storyAuthor.Text + " - " + storyTitle.Text)) {
            //    MessageBox.Show("That story already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //SelectedStory = new Story(storyAuthor.Text, storyTitle.Text);
            //this.DialogResult = DialogResult.OK;
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
