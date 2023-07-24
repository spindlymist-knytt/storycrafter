using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class GradientsTab : UserControl, IEditorTab {
        ListViewItemComparer lvItemComparer = new ListViewItemComparer();

        public GradientsTab() {
            this.InitializeComponent();

            this.gradient_list.ListViewItemSorter = lvItemComparer;
            this.gradient_list.SelectedIndexChanged += delegate {
                if(this.gradient_list.SelectedItems.Count > 0) {
                    this.gradient_view.BackgroundImage = Program.LoadBitmap(Program.OpenStory.Path + @"\Gradients\" + this.gradient_list.SelectedItems[0].Text);
                    this.gradient_view.Tag = Program.OpenStory.Path + @"\Gradients\" + this.gradient_list.SelectedItems[0].Text;
                    this.gradient_label.Text = this.gradient_list.SelectedItems[0].Text;
                }
            };

            this.gradient_tileCheck.CheckedChanged += delegate {
                this.gradient_view.BackgroundImageLayout = this.gradient_view.BackgroundImageLayout == ImageLayout.Tile ? ImageLayout.None : ImageLayout.Tile;
            };
        }

        public void StoryChanged() {
            this.gradient_list.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(Program.OpenStory.Path + @"\Gradients");
            if(!dirInfo.Exists) {
                this.gradient_label.Text = "";
                this.gradient_view.Image = null;
                return;
            }
            FileInfo[] files = dirInfo.GetFiles("Gradient*.png");
            if(files.Length > 0) {
                this.gradient_list.LargeImageList = new ImageList();
                this.gradient_list.LargeImageList.ImageSize = new Size(75, 30);
                this.gradient_list.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
                foreach(FileInfo f in files) {
                    Bitmap gradient = Program.LoadBitmap(f.FullName);
                    gradient.MakeTransparent(Color.Magenta);
                    Bitmap thumbnail = new Bitmap(Program.PxScreenWidth, Program.PxScreenHeight);
                    Graphics g = Graphics.FromImage(thumbnail);
                    for(int x = 0; x < thumbnail.Width; x += gradient.Width) {
                        g.DrawImage(gradient, x, 0);
                    }
                    this.gradient_list.LargeImageList.Images.Add(thumbnail);
                    this.gradient_list.Items.Add(f.Name).ImageIndex = this.gradient_list.LargeImageList.Images.Count - 1;
                }
                this.gradient_list.Sort();
                this.gradient_list.Items[0].Selected = true;
            }
            else {
                this.gradient_label.Text = "";
                this.gradient_view.Image = null;
            }
        }

        public void TabOpened() {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            return false;
        }

        public void ScreenChanged() {
        }
    }
}
