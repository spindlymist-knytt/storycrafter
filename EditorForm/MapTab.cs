using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    public partial class EditorForm {
        // TODO: popout
        // TODO: multi-screen editing, copying, etc.
        // TODO: visualize screen params, powerup locations, ...
        // TODO: import from another level
        class MapTab {
            EditorForm form;

            int overwrite;

            public MapTab(EditorForm parent) {
                form = parent;

                form.map_mainView.TheStory = Program.OpenStory;
                form.map_mainView.UpdateScreen += delegate (int x, int y) {
                    form.ChangeScreen(x, y);
                };
                form.map_mainView.UpdateStatus += delegate (int x, int y) {
                    form.toolStripStatusLabel1.Text = "x" + x + ", y" + y;
                };
                form.map_showThumbs.CheckedChanged += map_showThumbs_CheckChanged;

                form.button7.Click += delegate {
                    Program.ImportScreens.Show();
                };
                form.button8.Click += delegate (object sender, EventArgs e) {
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
                    form.map_mainView.ConfirmPaste();
                    form.ChangeScreen(activeX, activeY);
                    form.map_mainView.DrawMap(); // TODO remove redundant redraw
                    ((Control)sender).Enabled = false;
                    form.button9.Enabled = false;
                };
                form.button9.Click += delegate (object sender, EventArgs e) {
                    form.map_mainView.CancelPaste();
                    ((Control)sender).Enabled = false;
                    form.button8.Enabled = false;
                };
            }
            public void StoryChanged() {
                form.map_mainView.TheStory = Program.OpenStory;
                form.map_mainView.ResetSelection(Program.ActiveScreen.X, Program.ActiveScreen.Y);
            }
            public void TabOpened() {
                form.map_mainView.DrawMap();
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                if(keyData == (Keys.Control | Keys.V)) {
                    List<Screen> screens = (List<Screen>)Clipboard.GetData("StoryCrafterScreens");
                    if(screens == null) return false;
                    this.overwrite = form.map_mainView.PasteScreens(screens);
                    form.button8.Enabled = true;
                    form.button9.Enabled = true;
                    return true;
                }
                return false;
            }
            public void map_showThumbs_CheckChanged(object sender, EventArgs e) {
                if(!Program.OpenStory.ThumbnailsCached) {
                    if(MessageBox.Show("Enabling thumbnails may require a large amount of memory and take a while to draw. Do you wish to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
                        form.map_showThumbs.CheckedChanged -= map_showThumbs_CheckChanged;
                        form.map_showThumbs.Checked = false;
                        form.map_showThumbs.CheckedChanged += map_showThumbs_CheckChanged;
                        return;
                    }
                    BackgroundWorker bgWorker = new BackgroundWorker();
                    bgWorker.WorkerReportsProgress = true;
                    bgWorker.DoWork += delegate (object bgwsender, DoWorkEventArgs bgwe) {
                        Program.OpenStory.CacheThumbnails((BackgroundWorker)bgwsender);
                    };
                    bgWorker.ProgressChanged += delegate (object from, ProgressChangedEventArgs ev) {
                        form.progressBar1.Value = ev.ProgressPercentage;
                    };
                    bgWorker.RunWorkerCompleted += delegate {
                        form.translucentPanel1.Visible = false;
                        form.map_mainView.ShowThumbs = form.map_showThumbs.Checked;
                    };
                    form.progressBarLabel.Text = "Caching thumbnails...";
                    form.progressBar1.Maximum = Program.OpenStory.Screens.Count;
                    form.translucentPanel1.BringToFront();
                    form.translucentPanel1.Visible = true;
                    bgWorker.RunWorkerAsync();
                    return;
                }
                form.map_mainView.ShowThumbs = form.map_showThumbs.Checked;
            }
        }
    }
}
