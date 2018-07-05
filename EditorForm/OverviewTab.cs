using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        // TODO: compress
        // TODO: upload to knyttlevels.com
        // TODO: populate dropdowns
        class OverviewTab {
            EditorForm form;
            Image overlay;

            public OverviewTab(EditorForm parent) {
                form = parent;

                this.overlay = form.overview_info.Image;
                form.overview_overlayCheck.CheckedChanged += this.overlayCheck_CheckedChanged;
                form.overview_publish.MouseClick += this.publish_MouseClick;

                form.overview_author.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.Author = ((TextBox)sender).Text; };
                form.overview_title.TextChanged += delegate (object sender, EventArgs e) {
                    Program.OpenStory.Title = ((TextBox)sender).Text;
                    form.Text = Program.OpenStory.Title + " - Story Crafter";
                };
                form.overview_description.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.Description = ((TextBox)sender).Text; };

                form.overview_size.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.Size = ((ComboBox)sender).Text; };

                form.overview_catA.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.CategoryA = ((ComboBox)sender).Text; };
                form.overview_catB.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.CategoryB = ((ComboBox)sender).Text; };

                form.overview_diffA.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.DifficultyA = ((ComboBox)sender).Text; };
                form.overview_diffB.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.DifficultyB = ((ComboBox)sender).Text; };
                form.overview_diffC.TextChanged += delegate (object sender, EventArgs e) { Program.OpenStory.DifficultyC = ((ComboBox)sender).Text; };
            }
            public void StoryChanged() {
                form.overview_info.BackgroundImage = Program.LoadBitmap(Program.OpenStory.Path + @"\Info.png");
                form.overview_info.Tag = Program.OpenStory.Path + @"\Info.png";

                form.overview_icon.Image = Program.LoadBitmap(Program.OpenStory.Path + @"\Icon.png");
                form.overview_icon.Tag = Program.OpenStory.Path + @"\Icon.png";
                form.overview_title.Text = Program.OpenStory.Title;
                form.overview_author.Text = Program.OpenStory.Author;
                form.overview_description.Text = Program.OpenStory.Description;

                form.overview_size.Text = Program.OpenStory.Size;
                form.overview_screenCount.Text = "Screens: " + Program.OpenStory.Screens.Count;
                form.overview_catA.Text = Program.OpenStory.CategoryA;
                form.overview_catB.Text = Program.OpenStory.CategoryB;
                form.overview_diffA.Text = Program.OpenStory.DifficultyA;
                form.overview_diffB.Text = Program.OpenStory.DifficultyB;
                form.overview_diffC.Text = Program.OpenStory.DifficultyC;

                form.overview_skinPreview.BackColor = Program.OpenStory.Skin;
                form.overview_clothesPreview.BackColor = Program.OpenStory.Clothes;
                form.overview_skinPreview.Click += this.skinPreview_Click;
                form.overview_skinLabel.Click += this.skinPreview_Click;
                form.overview_clothesPreview.Click += this.clothesPreview_Click;
                form.overview_clothesLabel.Click += this.clothesPreview_Click;
                if(!this.CmpColors(Program.Skin, Program.OpenStory.Skin)) this.ReplaceColor((Bitmap)form.overview_juni.Image, Program.Skin, Program.OpenStory.Skin, 10, 15);
                if(!this.CmpColors(Program.Clothes, Program.OpenStory.Clothes)) this.ReplaceColor((Bitmap)form.overview_juni.Image, Program.Clothes, Program.OpenStory.Clothes, 15, 21);
            }
            public void TabOpened() {
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                return false;
            }

            public void overlayCheck_CheckedChanged(object sender, EventArgs e) {
                if(form.overview_overlayCheck.Checked) {
                    form.overview_info.Image = overlay;
                }
                else {
                    form.overview_info.Image = null;
                }
            }
            public void skinPreview_Click(object sender, EventArgs e) {
                form.overview_colorDialog.Color = Program.OpenStory.Skin;
                form.overview_colorDialog.ShowDialog();
                if(this.CmpColors(form.overview_colorDialog.Color, Program.OpenStory.Skin)) return;
                this.ReplaceColor((Bitmap)form.overview_juni.Image, Program.OpenStory.Skin, form.overview_colorDialog.Color, 10, 15);
                Program.OpenStory.Skin = form.overview_skinPreview.BackColor = form.overview_colorDialog.Color;
                form.overview_juni.Refresh();
            }
            public void clothesPreview_Click(object sender, EventArgs e) {
                form.overview_colorDialog.Color = Program.OpenStory.Clothes;
                form.overview_colorDialog.ShowDialog();
                if(this.CmpColors(form.overview_colorDialog.Color, Program.OpenStory.Clothes)) return;
                this.ReplaceColor((Bitmap)form.overview_juni.Image, Program.OpenStory.Clothes, form.overview_colorDialog.Color, 15, 21);
                Program.OpenStory.Clothes = form.overview_clothesPreview.BackColor = form.overview_colorDialog.Color;
                form.overview_juni.Refresh();
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
                form.contextMenu1.Show(form.overview_publish, e.Location);
            }
        }
    }
}
