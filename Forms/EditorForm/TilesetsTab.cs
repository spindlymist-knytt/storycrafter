﻿using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Forms.EditorForm {
    partial class TilesetsTab : UserControl, IEditorTab {
        ListViewItemComparer lvItemComparer = new ListViewItemComparer();
        Story story;

        public TilesetsTab() {
            this.InitializeComponent();

            this.tileset_list.SelectedIndexChanged += delegate {
                if(this.tileset_list.SelectedItems.Count > 0) {
                    Bitmap b = Program.LoadBitmap(this.story.Path + @"\Tilesets\" + this.tileset_list.SelectedItems[0].Text);
                    b.MakeTransparent(Color.Magenta);
                    this.tileset_view.Image = b;
                    this.tileset_view.Tag = this.story.Path + @"\Tilesets\" + this.tileset_list.SelectedItems[0].Text;
                    this.tileset_label.Text = this.tileset_list.SelectedItems[0].Text;
                }
            };
        }

        public void StoryChanged(Story story) {
            this.story = story;

            this.tileset_list.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(this.story.Path + @"\Tilesets");
            if(!dirInfo.Exists) {
                this.tileset_label.Text = "";
                this.tileset_view.Image = null;
                return;
            }
            FileInfo[] files = dirInfo.GetFiles("Tileset*.png");
            if(files.Length > 0) {
                this.tileset_list.LargeImageList = new ImageList();
                this.tileset_list.LargeImageList.ImageSize = new Size(192, 101);
                this.tileset_list.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
                foreach(FileInfo f in files) {
                    Bitmap b = (Bitmap)Image.FromFile(f.FullName);
                    b.MakeTransparent(Color.Magenta);
                    this.tileset_list.LargeImageList.Images.Add(b);
                    this.tileset_list.Items.Add(f.Name).ImageIndex = this.tileset_list.LargeImageList.Images.Count - 1;
                }
                this.tileset_list.ListViewItemSorter = lvItemComparer;
                this.tileset_list.Sort();
                this.tileset_list.Items[0].Selected = true;
            }
            else {
                this.tileset_label.Text = "";
                this.tileset_view.Image = null;
            }
        }

        public void TabOpened() {
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            return false;
        }

        public void ScreenChanged(Screen screen) {
        }
    }
}
