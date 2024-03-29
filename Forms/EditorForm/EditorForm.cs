﻿using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter.Forms.EditorForm {
    // TODO: add analyze tab: wallswim, unsmooth collision surfaces, ...
    // TODO: cutscenes tab
    // TODO: music tab
    // TODO: ambiance tab
    // TODO: custom objects tab
    partial class EditorForm: Form {
        List<IEditorTab> tabs;
        Story story;

        public EditorForm() {
            InitializeComponent();

            tabs = new List<IEditorTab>() {
                this.overviewTab1,
                this.screenTab1,
                this.mapTab1,
                this.tilesetsTab1,
                this.gradientsTab1,
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
                tab.ScreenChanged(story.ActiveScreen);
            }

            GC.Collect();
            Program.ChangingStory = false;
        }

        private void EditorForm_Load(object sender, EventArgs e) {
            Program.Debug.Show();
            if(Program.Start.ShowDialog(this) != DialogResult.OK) {
                this.Close();
                return;
            }
            StoryChanged(Program.Start.SelectedStory);
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
        }

        private void menuItem8_Click(object sender, EventArgs e) {
            story.Save();
        }

        private void menuItem5_Click(object sender, EventArgs e) {
            if(Program.Start.ShowDialog() == DialogResult.OK) {
                StoryChanged(Program.Start.SelectedStory);
            }
        }

        public void ChangeScreen(int x, int y) {
            story.ChangeScreen(x, y);
            foreach (IEditorTab tab in tabs) {
                tab.ScreenChanged(story.ActiveScreen);
            }
        }
    }
}