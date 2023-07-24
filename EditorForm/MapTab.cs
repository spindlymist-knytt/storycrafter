﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
        // TODO: popout
        // TODO: multi-screen editing, copying, etc.
        // TODO: visualize screen params, powerup locations, ...
        // TODO: import from another level
    partial class MapTab : UserControl, IEditorTab {
        int overwrite;
        EditorForm form;

        public MapTab() {
            InitializeComponent();

            this.form = this.FindForm() as EditorForm;

            this.map_mainView.TheStory = Program.OpenStory;
            this.map_mainView.UpdateScreen += delegate (int x, int y) {
                form.ChangeScreen(x, y);
            };
            this.map_mainView.UpdateStatus += delegate (int x, int y) {
                //form.toolStripStatusLabel1.Text = "x" + x + ", y" + y;
            };
            this.map_showThumbs.CheckedChanged += map_showThumbs_CheckChanged;

            this.button7.Click += delegate {
                Program.ImportScreens.Show();
            };
            this.button8.Click += delegate (object sender, EventArgs e) {
                if(overwrite > 0) {
                    if(MessageBox.Show("This action will overwrite " + overwrite + " screens. Do you wish to continue? This action cannot be undone.",
                                            "Paste Screens",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Warning) == DialogResult.Cancel) {
                        return;
                    }
                }
                int activeX = Program.ActiveScreen.X;
                int activeY = Program.ActiveScreen.Y;
                this.map_mainView.ConfirmPaste();
                form.ChangeScreen(activeX, activeY);
                this.map_mainView.DrawMap(); // TODO remove redundant redraw
                ((Control)sender).Enabled = false;
                this.button9.Enabled = false;
            };
            this.button9.Click += delegate (object sender, EventArgs e) {
                this.map_mainView.CancelPaste();
                ((Control)sender).Enabled = false;
                this.button8.Enabled = false;
            };
        }
        public void StoryChanged() {
            this.map_mainView.TheStory = Program.OpenStory;
            this.map_mainView.ResetSelection(Program.ActiveScreen.X, Program.ActiveScreen.Y);
        }

        public void TabOpened() {
            this.map_mainView.DrawMap();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if(keyData == (Keys.Control | Keys.V)) {
                List<Screen> screens = (List<Screen>)Clipboard.GetData("StoryCrafterScreens");
                if(screens == null) return false;
                this.overwrite = this.map_mainView.PasteScreens(screens);
                this.button8.Enabled = true;
                this.button9.Enabled = true;
                return true;
            }
            return false;
        }

        public void map_showThumbs_CheckChanged(object sender, EventArgs e) {
            if(!Program.OpenStory.ThumbnailsCached) {
                if(MessageBox.Show("Enabling thumbnails may require a large amount of memory and take a while to draw. Do you wish to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
                    this.map_showThumbs.CheckedChanged -= map_showThumbs_CheckChanged;
                    this.map_showThumbs.Checked = false;
                    this.map_showThumbs.CheckedChanged += map_showThumbs_CheckChanged;
                    return;
                }
                BackgroundWorker bgWorker = new BackgroundWorker();
                bgWorker.WorkerReportsProgress = true;
                bgWorker.DoWork += delegate (object bgwsender, DoWorkEventArgs bgwe) {
                    Program.OpenStory.CacheThumbnails((BackgroundWorker)bgwsender);
                };
                bgWorker.ProgressChanged += delegate (object from, ProgressChangedEventArgs ev) {
                    this.progressBar1.Value = ev.ProgressPercentage;
                };
                bgWorker.RunWorkerCompleted += delegate {
                    this.translucentPanel1.Visible = false;
                    this.map_mainView.ShowThumbs = this.map_showThumbs.Checked;
                };
                this.progressBarLabel.Text = "Caching thumbnails...";
                this.progressBar1.Maximum = Program.OpenStory.Screens.Count;
                this.translucentPanel1.BringToFront();
                this.translucentPanel1.Visible = true;
                bgWorker.RunWorkerAsync();
                return;
            }
            this.map_mainView.ShowThumbs = this.map_showThumbs.Checked;
        }

        public void ScreenChanged() {
        }
    }
}
