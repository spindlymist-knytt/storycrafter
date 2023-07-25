using Story_Crafter;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter.Forms.EditorForm {
    // TODO: compress
    // TODO: upload to knyttlevels.com
    // TODO: populate dropdowns
    // TODO: use ks+ info.png
    partial class OverviewTab : UserControl, IEditorTab {
        Image overlay;

        public OverviewTab() {
            InitializeComponent();

            this.overlay = this.overview_info.Image;
            this.overview_overlayCheck.CheckedChanged += this.overlayCheck_CheckedChanged;
            this.overview_publish.MouseClick += this.publish_MouseClick;

            this.overview_author.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.Author = ((TextBox)sender).Text; };
            this.overview_title.TextChanged += delegate (object sender, EventArgs e) {
                Program.OpenStory.Title = ((TextBox)sender).Text;
                //this.Text = Program.OpenStory.Title + " - Story Crafter";
            };
            this.overview_description.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.Description = ((TextBox)sender).Text; };

            this.overview_size.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.Size = ((ComboBox)sender).Text; };

            this.overview_catA.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.CategoryA = ((ComboBox)sender).Text; };
            this.overview_catB.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.CategoryB = ((ComboBox)sender).Text; };

            this.overview_diffA.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.DifficultyA = ((ComboBox)sender).Text; };
            this.overview_diffB.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.DifficultyB = ((ComboBox)sender).Text; };
            this.overview_diffC.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.DifficultyC = ((ComboBox)sender).Text; };
        }
        public void StoryChanged() {
            this.overview_info.BackgroundImage = Program.LoadBitmap(Program.OpenStory.Path + @"\Info.png");
            this.overview_info.Tag = Program.OpenStory.Path + @"\Info.png";

            this.overview_icon.Image = Program.LoadBitmap(Program.OpenStory.Path + @"\Icon.png");
            this.overview_icon.Tag = Program.OpenStory.Path + @"\Icon.png";
            this.overview_title.Text = Program.OpenStory.Title;
            this.overview_author.Text = Program.OpenStory.Author;
            this.overview_description.Text = Program.OpenStory.Description;

            this.overview_size.Text = Program.OpenStory.Size;
            this.overview_screenCount.Text = "Screens: " + Program.OpenStory.Screens.Count;
            this.overview_catA.Text = Program.OpenStory.CategoryA;
            this.overview_catB.Text = Program.OpenStory.CategoryB;
            this.overview_diffA.Text = Program.OpenStory.DifficultyA;
            this.overview_diffB.Text = Program.OpenStory.DifficultyB;
            this.overview_diffC.Text = Program.OpenStory.DifficultyC;

            this.overview_skinPreview.BackColor = Program.OpenStory.Skin;
            this.overview_clothesPreview.BackColor = Program.OpenStory.Clothes;
            this.overview_skinPreview.Click += this.skinPreview_Click;
            this.overview_skinLabel.Click += this.skinPreview_Click;
            this.overview_clothesPreview.Click += this.clothesPreview_Click;
            this.overview_clothesLabel.Click += this.clothesPreview_Click;
            if(!this.CmpColors(Program.Skin, Program.OpenStory.Skin)) this.ReplaceColor((Bitmap)this.overview_juni.Image, Program.Skin, Program.OpenStory.Skin, 10, 15);
            if(!this.CmpColors(Program.Clothes, Program.OpenStory.Clothes)) this.ReplaceColor((Bitmap)this.overview_juni.Image, Program.Clothes, Program.OpenStory.Clothes, 15, 21);
        }

        public void TabOpened() {
        }

        public void ScreenChanged() {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            return false;
        }

        public void overlayCheck_CheckedChanged(object sender, EventArgs e) {
            if(this.overview_overlayCheck.Checked) {
                this.overview_info.Image = overlay;
            }
            else {
                this.overview_info.Image = null;
            }
        }

        public void skinPreview_Click(object sender, EventArgs e) {
            this.overview_colorDialog.Color = Program.OpenStory.Skin;
            this.overview_colorDialog.ShowDialog();
            if(this.CmpColors(this.overview_colorDialog.Color, Program.OpenStory.Skin)) return;
            this.ReplaceColor((Bitmap)this.overview_juni.Image, Program.OpenStory.Skin, this.overview_colorDialog.Color, 10, 15);
            Program.OpenStory.Skin = this.overview_skinPreview.BackColor = this.overview_colorDialog.Color;
            this.overview_juni.Refresh();
        }

        public void clothesPreview_Click(object sender, EventArgs e) {
            this.overview_colorDialog.Color = Program.OpenStory.Clothes;
            this.overview_colorDialog.ShowDialog();
            if(this.CmpColors(this.overview_colorDialog.Color, Program.OpenStory.Clothes)) return;
            this.ReplaceColor((Bitmap)this.overview_juni.Image, Program.OpenStory.Clothes, this.overview_colorDialog.Color, 15, 21);
            Program.OpenStory.Clothes = this.overview_clothesPreview.BackColor = this.overview_colorDialog.Color;
            this.overview_juni.Refresh();
        }

        private bool CmpColors(Color left, Color right) {
            return left.ToArgb() == right.ToArgb();
        }

        private void ReplaceColor(Bitmap b, Color replace, Color with, int minY, int maxY) {
            for(int x = 14; x <= 18; x++) {
                for(int y = minY; y <= maxY; y++) {
                    if(this.CmpColors(b.GetPixel(x, y), replace)) {
                        b.SetPixel(x, y, with);
                    }
                }
            }
        }

        public void publish_MouseClick(object sender, MouseEventArgs e) {
            this.contextMenu1.Show(this.overview_publish, e.Location);
        }
    }
}
