using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Story_Crafter.Forms;
using Story_Crafter.Knytt;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls.Tabs {
    // TODO: popout
    // TODO: multi-screen editing, copying, etc.
    // TODO: visualize screen params, powerup locations, ...
    // TODO: import from another level
    public partial class MapTab : BaseEditorTab {
        public override string Title => "Map";

        int overwrite;
        Screen screen;
        ImportScreensForm importForm;

        public MapTab(Editor editor) : base(editor) {
            InitializeComponent();

            this.map_mainView.Story = Editor.Story.Value;

            this.map_showThumbs.CheckedChanged += map_showThumbs_CheckChanged;
            this.button7.Click += delegate {
                if (this.importForm != null) return;

                this.importForm = new ImportScreensForm(editor.Paths.Worlds);
                this.importForm.FormClosed += delegate {
                    this.importForm = null;
                };

                this.importForm.Show();
            };
            this.button8.Click += delegate (object sender, EventArgs e) {
                if (overwrite > 0) {
                    if (MessageBox.Show("This action will overwrite " + overwrite + " screens. Do you wish to continue? This action cannot be undone.",
                                            "Paste Screens",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Warning) == DialogResult.Cancel) {
                        return;
                    }
                }
                int activeX = screen.X;
                int activeY = screen.Y;
                this.map_mainView.ConfirmPaste();
                this.map_mainView.DrawMap(); // TODO remove redundant redraw
                ((Control) sender).Enabled = false;
                this.button9.Enabled = false;
            };
            this.button9.Click += delegate (object sender, EventArgs e) {
                this.map_mainView.CancelPaste();
                ((Control) sender).Enabled = false;
                this.button8.Enabled = false;
            };
        }

        protected override void OnTabEntered(bool isFirstTime) {
            this.map_mainView.DrawMap();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.V)) {
                List<Screen> screens = (List<Screen>) Clipboard.GetData("StoryCrafterScreens");
                if (screens == null) return false;
                this.overwrite = this.map_mainView.PasteScreens(screens);
                this.button8.Enabled = true;
                this.button9.Enabled = true;
                return true;
            }
            return false;
        }

        public void map_showThumbs_CheckChanged(object sender, EventArgs e) {
            //if(!story.ThumbnailsCached) {
            //    if(MessageBox.Show("Enabling thumbnails may require a large amount of memory and take a while to draw. Do you wish to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
            //        this.map_showThumbs.CheckedChanged -= map_showThumbs_CheckChanged;
            //        this.map_showThumbs.Checked = false;
            //        this.map_showThumbs.CheckedChanged += map_showThumbs_CheckChanged;
            //        return;
            //    }
            //    BackgroundWorker bgWorker = new BackgroundWorker();
            //    bgWorker.WorkerReportsProgress = true;
            //    bgWorker.DoWork += delegate (object bgwsender, DoWorkEventArgs bgwe) {
            //        story.CacheThumbnails((BackgroundWorker)bgwsender);
            //    };
            //    bgWorker.ProgressChanged += delegate (object from, ProgressChangedEventArgs ev) {
            //        this.progressBar1.Value = ev.ProgressPercentage;
            //    };
            //    bgWorker.RunWorkerCompleted += delegate {
            //        this.translucentPanel1.Visible = false;
            //        this.map_mainView.ShowThumbs = this.map_showThumbs.Checked;
            //    };
            //    this.progressBarLabel.Text = "Caching thumbnails...";
            //    this.progressBar1.Maximum = story.Screens.Count;
            //    this.translucentPanel1.BringToFront();
            //    this.translucentPanel1.Visible = true;
            //    bgWorker.RunWorkerAsync();
            //    return;
            //}
            //this.map_mainView.ShowThumbs = this.map_showThumbs.Checked;
        }

        public void ScreenChanged(Screen screen) {
            this.screen = screen;
            this.map_mainView.ResetSelection(screen.X, screen.Y);
        }
    }
}
