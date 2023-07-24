using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    // TODO: add analyze tab: wallswim, unsmooth collision surfaces, ...
    // TODO: cutscenes tab
    // TODO: music tab
    // TODO: ambiance tab
    // TODO: custom objects tab
    public partial class EditorForm: Form {
        private ICSharpCode.AvalonEdit.TextEditor worldIni_avEdit;

        WorldIniTab worldIni;

        List<IEditorTab> tabs;

        public EditorForm() {
            InitializeComponent();

            tabs = new List<IEditorTab>() {
                this.overviewTab1,
                this.screenTab1,
                this.mapTab1,
                this.tilesetsTab1,
                this.gradientsTab1,
            };

            this.worldIni_avEdit = new ICSharpCode.AvalonEdit.TextEditor();
            this.worldIni_avEdit.FontFamily = new System.Windows.Media.FontFamily("Courier New");
            this.worldIni_avEdit.BorderThickness = new System.Windows.Thickness(1);
            this.elementHost1.Child = worldIni_avEdit;
        }
        public void StoryChanged() {
            Program.ChangingStory = true;
            this.Text = Program.OpenStory.Title + " - Story Crafter";

            foreach (IEditorTab tab in tabs) {
                tab.StoryChanged();
            }

            this.worldIni.StoryChanged();

            GC.Collect();
            Program.ChangingStory = false;
        }

        private void EditorForm_Load(object sender, EventArgs e) {
            Program.Debug.Show();
            if(Program.Start.ShowDialog(this) != DialogResult.OK) {
                this.Close();
                return;
            }

            this.worldIni = new WorldIniTab(this);

            StoryChanged();
        }

        private void menuItem2_Click(object sender, EventArgs e) {
            if(Program.Preferences.ShowDialog() == DialogResult.OK) {
                //this.screen.ProfileChanged();
            }
        }

        private void editWithGIMPToolStripMenuItem_Click(object sender, EventArgs e) {
            //System.Diagnostics.Process.Start(@"D:\Program Files (x86)\GIMP\bin\gimp-2.6.exe", '"' + (string)((ContextMenuStrip)((ToolStripDropDownItem)sender).Owner).SourceControl.Tag + '"');
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

            switch(tabControl1.SelectedIndex) {
                case 5: this.worldIni.TabOpened(); break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch(tabControl1.SelectedIndex) {
                case 5: this.worldIni.ProcessCmdKey(ref msg, keyData); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void menuItem8_Click(object sender, EventArgs e) {
            Program.OpenStory.Save(this.worldIni_avEdit.Text);
        }

        private void menuItem5_Click(object sender, EventArgs e) {
            if(Program.Start.ShowDialog() == DialogResult.OK) {
                StoryChanged();
            }
        }

        public string GetWorldINIText() {
            return this.worldIni_avEdit.Text;
        }

        public void ChangeScreen(int x, int y) {
            Program.OpenStory.ChangeScreen(x, y);
            foreach (IEditorTab tab in tabs) {
                tab.ScreenChanged();
            }
        }
    }
}