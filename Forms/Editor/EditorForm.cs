using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Story_Crafter.Knytt;

namespace Story_Crafter.Forms.Editor {
    // TODO: add analyze tab: wallswim, unsmooth collision surfaces, ...
    // TODO: cutscenes tab
    // TODO: custom objects tab
    public partial class EditorForm : Form {
        readonly List<IEditorTab> tabs;
        Story story;

        public EditorForm() {
            InitializeComponent();

            tabs = new List<IEditorTab>() {
                this.overviewTab1,
                this.mapTab1,
                this.worldIniTab1,
                this.newScreenTab1,
                this.testTab1,
            };
        }

        public void StoryChanged(Story story) {
            this.story = story;

            Program.ChangingStory = true;
            this.Text = story.Title + " - Story Crafter";

            foreach (IEditorTab tab in tabs) {
                tab.StoryChanged(story);
            }

            GC.Collect();
            Program.ChangingStory = false;
        }

        private bool ShowOpenStoryDialog() {
            using StartForm startDialog = new();

            if (startDialog.ShowDialog(this) != DialogResult.OK) {
                return false;
            }

            StoryChanged(startDialog.SelectedStory);

            return true;
        }

        private void EditorForm_Load(object sender, EventArgs e) {
            Program.Debug.Show();
            if (!ShowOpenStoryDialog()) {
                this.Close();
            }
        }

        private void menuItem2_Click(object sender, EventArgs e) {
            if (Program.Preferences.ShowDialog() == DialogResult.OK) {
                //this.screen.ProfileChanged();
            }
        }

        private void menuTools_Click(object sender, EventArgs e) {
            //MenuItem m = (MenuItem)sender;
            //menuTools.MenuItems[screen.CurrentToolIndex].Checked = false;
            //m.Checked = true;
            //screen.CurrentToolIndex = m.Index;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedIndex < tabs.Count) {
                tabs[tabControl1.SelectedIndex].TabOpened();
            }
        }

        private void menuItem8_Click(object sender, EventArgs e) {
            story.Save();
        }

        private void menuItem5_Click(object sender, EventArgs e) {
            ShowOpenStoryDialog();
        }
    }
}
