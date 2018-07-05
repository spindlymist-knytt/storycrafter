using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        class TilesetsTab {
            EditorForm form;
            ListViewItemComparer lvItemComparer = new ListViewItemComparer();

            public TilesetsTab(EditorForm parent) {
                form = parent;

                form.tileset_list.SelectedIndexChanged += delegate {
                    if(form.tileset_list.SelectedItems.Count > 0) {
                        Bitmap b = Program.LoadBitmap(Program.OpenStory.Path + @"\Tilesets\" + form.tileset_list.SelectedItems[0].Text);
                        b.MakeTransparent(Color.Magenta);
                        form.tileset_view.Image = b;
                        form.tileset_view.Tag = Program.OpenStory.Path + @"\Tilesets\" + form.tileset_list.SelectedItems[0].Text;
                        form.tileset_label.Text = form.tileset_list.SelectedItems[0].Text;
                    }
                };
            }
            public void StoryChanged() {
                form.tileset_list.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(Program.OpenStory.Path + @"\Tilesets");
                if(!dirInfo.Exists) {
                    form.tileset_label.Text = "";
                    form.tileset_view.Image = null;
                    return;
                }
                FileInfo[] files = dirInfo.GetFiles("Tileset*.png");
                if(files.Length > 0) {
                    form.tileset_list.LargeImageList = new ImageList();
                    form.tileset_list.LargeImageList.ImageSize = new Size(192, 101);
                    form.tileset_list.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
                    foreach(FileInfo f in files) {
                        Bitmap b = (Bitmap)Image.FromFile(f.FullName);
                        b.MakeTransparent(Color.Magenta);
                        form.tileset_list.LargeImageList.Images.Add(b);
                        form.tileset_list.Items.Add(f.Name).ImageIndex = form.tileset_list.LargeImageList.Images.Count - 1;
                    }
                    form.tileset_list.ListViewItemSorter = lvItemComparer;
                    form.tileset_list.Sort();
                    form.tileset_list.Items[0].Selected = true;
                }
                else {
                    form.tileset_label.Text = "";
                    form.tileset_view.Image = null;
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
