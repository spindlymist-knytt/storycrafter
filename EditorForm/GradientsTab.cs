using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        class GradientsTab {
            EditorForm form;
            ListViewItemComparer lvItemComparer = new ListViewItemComparer();

            public GradientsTab(EditorForm parent) {
                form = parent;

                form.gradient_list.ListViewItemSorter = lvItemComparer;
                form.gradient_list.SelectedIndexChanged += delegate {
                    if(form.gradient_list.SelectedItems.Count > 0) {
                        form.gradient_view.BackgroundImage = Program.LoadBitmap(Program.OpenStory.Path + @"\Gradients\" + form.gradient_list.SelectedItems[0].Text);
                        form.gradient_view.Tag = Program.OpenStory.Path + @"\Gradients\" + form.gradient_list.SelectedItems[0].Text;
                        form.gradient_label.Text = form.gradient_list.SelectedItems[0].Text;
                    }
                };

                form.gradient_tileCheck.CheckedChanged += delegate {
                    form.gradient_view.BackgroundImageLayout = form.gradient_view.BackgroundImageLayout == ImageLayout.Tile ? ImageLayout.None : ImageLayout.Tile;
                };
            }
            public void StoryChanged() {
                form.gradient_list.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(Program.OpenStory.Path + @"\Gradients");
                if(!dirInfo.Exists) {
                    form.gradient_label.Text = "";
                    form.gradient_view.Image = null;
                    return;
                }
                FileInfo[] files = dirInfo.GetFiles("Gradient*.png");
                if(files.Length > 0) {
                    form.gradient_list.LargeImageList = new ImageList();
                    form.gradient_list.LargeImageList.ImageSize = new Size(75, 30);
                    form.gradient_list.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
                    foreach(FileInfo f in files) {
                        Bitmap gradient = Program.LoadBitmap(f.FullName);
                        gradient.MakeTransparent(Color.Magenta);
                        Bitmap thumbnail = new Bitmap(Program.PxScreenWidth, Program.PxScreenHeight);
                        Graphics g = Graphics.FromImage(thumbnail);
                        for(int x = 0; x < thumbnail.Width; x += gradient.Width) {
                            g.DrawImage(gradient, x, 0);
                        }
                        form.gradient_list.LargeImageList.Images.Add(thumbnail);
                        form.gradient_list.Items.Add(f.Name).ImageIndex = form.gradient_list.LargeImageList.Images.Count - 1;
                    }
                    form.gradient_list.Sort();
                    form.gradient_list.Items[0].Selected = true;
                }
                else {
                    form.gradient_label.Text = "";
                    form.gradient_view.Image = null;
                }
            }
            public void TabOpened() {
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                return false;
            }
        }
    }
}
