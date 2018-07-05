using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        class CutscenesTab {
            class SceneEntry {
                public int Index;

                public SceneEntry(int i) {
                    this.Index = i;
                }
            }

            EditorForm form;

            public CutscenesTab(EditorForm parent) {
                form = parent;
            }
            public void StoryChanged() {
            }
            public void TabOpened() {
                /*form.objectListView1.ColumnsInDisplayOrder[0].ImageGetter = delegate(object o) {
                  return ((SceneEntry)o).Index - 1;
                };

                ImageList smallList = form.objectListView1.SmallImageList = new ImageList();
                smallList.ColorDepth = ColorDepth.Depth24Bit;
                smallList.ImageSize = new Size(30, 12);

                ImageList largeList = form.objectListView1.LargeImageList = new ImageList();
                largeList.ColorDepth = ColorDepth.Depth24Bit;
                largeList.ImageSize = new Size(240, 96);

                string cutscene = "Intro";
                DirectoryInfo dirInfo = new DirectoryInfo(Program.OpenStory.Path + @"\" + cutscene);
                foreach(FileInfo f in dirInfo.GetFiles("Scene*.png")) {
                  int start = f.Name.IndexOfAny(new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'});
                  int i = int.Parse(f.Name.Substring(start, f.Name.IndexOf('.') - start));

                  Bitmap scene = new Bitmap(f.FullName);

                  Bitmap small = new Bitmap(30, 12);
                  Graphics.FromImage(small).DrawImage(scene, 0, 0, 240, 96);
                  smallList.Images.Add(small);

                  Bitmap large = new Bitmap(240, 96);
                  Graphics.FromImage(large).DrawImage(scene, 0, 0, 240, 96);
                  largeList.Images.Add(large);

                  form.objectListView1.AddObject(new SceneEntry(i));

                  if(File.Exists(Program.OpenStory.Path + @"\" + cutscene + @"\Sound" + i + ".ogg")) {
                    form.objectListView2.Items.Add("Sound" + i + ".ogg");
                  }
                  else {
                    form.objectListView2.Items.Add("No sound");
                  }
                }
                form.pictureBox2.Image = new Bitmap(Program.OpenStory.Path + @"\" + cutscene + @"\Scene1.png");*/
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                return false;
            }
        }
    }
}
