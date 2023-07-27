using Story_Crafter;
using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Forms.EditorForm {
    // TODO: compress
    // TODO: upload to knyttlevels.com
    // TODO: populate dropdowns
    // TODO: use ks+ info.png
    partial class OverviewTab : UserControl, IEditorTab {
        Image overlay;
        Story story;

        public OverviewTab() {
            InitializeComponent();

            this.overlay = this.overview_info.Image;

            this.overview_author.TextChanged += delegate (object sender, EventArgs e) { story.Author = ((TextBox)sender).Text; };
            this.overview_title.TextChanged += delegate (object sender, EventArgs e) {
                story.Title = ((TextBox)sender).Text;
                //this.Text = story.Title + " - Story Crafter";
            };
            this.overview_description.TextChanged += delegate (object sender, EventArgs e) { story.Description = ((TextBox)sender).Text; };

            this.overview_size.TextChanged += delegate (object sender, EventArgs e) { story.Size = ((ComboBox)sender).Text; };

            this.overview_catA.TextChanged += delegate (object sender, EventArgs e) { story.CategoryA = ((ComboBox)sender).Text; };
            this.overview_catB.TextChanged += delegate (object sender, EventArgs e) { story.CategoryB = ((ComboBox)sender).Text; };

            this.overview_diffA.TextChanged += delegate (object sender, EventArgs e) { story.DifficultyA = ((ComboBox)sender).Text; };
            this.overview_diffB.TextChanged += delegate (object sender, EventArgs e) { story.DifficultyB = ((ComboBox)sender).Text; };
            this.overview_diffC.TextChanged += delegate (object sender, EventArgs e) { story.DifficultyC = ((ComboBox)sender).Text; };
        }
        public void StoryChanged(Story story) {
            this.story = story;

            this.overview_info.BackgroundImage = Program.LoadBitmap(story.Path + @"\Info.png");
            this.overview_info.Tag = story.Path + @"\Info.png";

            this.overview_icon.Image = Program.LoadBitmap(story.Path + @"\Icon.png");
            this.overview_icon.Tag = story.Path + @"\Icon.png";
            this.overview_title.Text = story.Title;
            this.overview_author.Text = story.Author;
            this.overview_description.Text = story.Description;

            this.overview_size.Text = story.Size;
            this.overview_screenCount.Text = "Screens: " + story.Screens.Count;
            this.overview_catA.Text = story.CategoryA;
            this.overview_catB.Text = story.CategoryB;
            this.overview_diffA.Text = story.DifficultyA;
            this.overview_diffB.Text = story.DifficultyB;
            this.overview_diffC.Text = story.DifficultyC;

            this.overview_skinPreview.BackColor = story.Skin;
            this.overview_clothesPreview.BackColor = story.Clothes;
            this.overview_skinPreview.Click += this.skinPreview_Click;
            this.overview_skinLabel.Click += this.skinPreview_Click;
            this.overview_clothesPreview.Click += this.clothesPreview_Click;
            this.overview_clothesLabel.Click += this.clothesPreview_Click;
            if(!this.CmpColors(Metrics.DefaultSkin, story.Skin)) this.ReplaceColor((Bitmap)this.overview_juni.Image, Metrics.DefaultSkin, story.Skin, 10, 15);
            if(!this.CmpColors(Metrics.DefaultClothes, story.Clothes)) this.ReplaceColor((Bitmap)this.overview_juni.Image, Metrics.DefaultClothes, story.Clothes, 15, 21);
        }

        public void TabOpened() {
        }

        public void ScreenChanged(Screen screen) {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            return false;
        }

        public void skinPreview_Click(object sender, EventArgs e) {
            this.overview_colorDialog.Color = this.story.Skin;
            this.overview_colorDialog.ShowDialog();
            if(this.CmpColors(this.overview_colorDialog.Color, this.story.Skin)) return;
            this.ReplaceColor((Bitmap)this.overview_juni.Image, this.story.Skin, this.overview_colorDialog.Color, 10, 15);
            this.story.Skin = this.overview_skinPreview.BackColor = this.overview_colorDialog.Color;
            this.overview_juni.Refresh();
        }

        public void clothesPreview_Click(object sender, EventArgs e) {
            this.overview_colorDialog.Color = this.story.Clothes;
            this.overview_colorDialog.ShowDialog();
            if(this.CmpColors(this.overview_colorDialog.Color, this.story.Clothes)) return;
            this.ReplaceColor((Bitmap)this.overview_juni.Image, this.story.Clothes, this.overview_colorDialog.Color, 15, 21);
            this.story.Clothes = this.overview_clothesPreview.BackColor = this.overview_colorDialog.Color;
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

        private void menuItem_toggleOverlay_Click(object sender, EventArgs e) {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (menuItem.Checked) {
                this.overview_info.Image = overlay;
            }
            else {
                this.overview_info.Image = null;
            }
        }
    }
}
