using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        // TODO: finish migration to AvEdit
        // TODO: add border to edit control
        class WorldIniTab {
            class CollectionHelper {
                Regex Section;
                Regex Key;
                ToolStripItemCollection Items;

                public CollectionHelper(ContextMenuStrip owner, string sectionPattern, string keyPattern) {
                    Items = new ToolStripItemCollection(owner, new ToolStripItem[] { });
                    Section = new Regex(sectionPattern);
                    Key = new Regex(keyPattern);
                }
                public CollectionHelper(ContextMenuStrip owner, Regex sectionPattern, string keyPattern) {
                    Items = new ToolStripItemCollection(owner, new ToolStripItem[] { });
                    Section = sectionPattern;
                    Key = new Regex(keyPattern);
                }
                public bool Match(string section, string key) {
                    return Section.IsMatch(section) && Key.IsMatch(key);
                }
                public void Add(ToolStripItem i, EventHandler click) {
                    if(click != null) i.Click += click;
                    Items.Add(i);
                }
                public void Add(string i, EventHandler click) {
                    this.Add(new ToolStripMenuItem(i), click);
                }
                public void AddList(params object[] list) {
                    AddListTo("", list);
                }
                public void AddListTo(string to, params object[] list) {
                    ToolStripMenuItem subMenu = new ToolStripMenuItem((string)list[0]);
                    if(list[1] != null) subMenu.Click += (EventHandler)list[1];
                    for(int i = 2; i < list.Length - 1; i += 2) {
                        ToolStripMenuItem item = new ToolStripMenuItem((string)list[i]);
                        if(list[i + 1] != null) item.Click += (EventHandler)list[i + 1];
                        subMenu.DropDown.Items.Add(item);
                    }
                    if(to == "") {
                        Items.Add(subMenu);
                    }
                    else {
                        foreach(ToolStripItem i in Items) {
                            if(i.Text == to) ((ToolStripMenuItem)i).DropDown.Items.Add(subMenu);
                        }
                    }
                }
                public ToolStripItemCollection GetItems() {
                    return Items;
                }
            }

            EditorForm form;

            Regex ScreenPattern = new Regex(@"\[x[1-9][0-9]*y[1-9][0-9]*\]");
            Regex CustomObjectPattern = new Regex(@"\[custom object [1-9][0-9]*\]");
            List<CollectionHelper> Collections = new List<CollectionHelper>();

            void CreateMenuCollections() {
                // Screen

                CollectionHelper screen = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, "^$");
                screen.Add("Ending", keyInsertText);
                screen.AddList("Sign", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddList("Flag", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddList("Warp X", null, "Up", (EventHandler)warp, "Right", (EventHandler)warp, "Down", (EventHandler)warp, "Left", (EventHandler)warp);
                screen.AddList("Warp Y", null, "Up", (EventHandler)warp, "Right", (EventHandler)warp, "Down", (EventHandler)warp, "Left", (EventHandler)warp);
                screen.AddList("Flag Warp X", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddList("Flag Warp Y", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.Add("Shift", keyInsertText);
                screen.AddListTo("Shift", "Type", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Touch", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Quantize", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Save", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Visible", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Stop Music", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Effect", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Deny Hologram", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Absolute Target", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "X Map", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Y Map", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "X Pos", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Y Pos", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Cutscene", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Flag On", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Flag Off", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);
                screen.AddListTo("Shift", "Sound", null, "A", (EventHandler)insertPath, "B", (EventHandler)insertPath, "C", (EventHandler)insertPath);

                CollectionHelper flags = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"flag\([abc]\)");
                for(int i = 0; i < 10; i++) {
                    flags.Add("Flag " + i, null);
                }
                flags.AddList("Powers", null, "Run", null, "Climb", null, "Double Jump", null, "High Jump", null, "Eye", null, "Detector", null, "Umbrella", null, "Hologram", null, "Red Key", null, "Yellow Key", null, "Blue Key", null, "Purple Key", null);

                CollectionHelper shiftType = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shifttype\([abc]\)");
                shiftType.Add("Spot", insertIndex);
                shiftType.Add("Floor", insertIndex);
                shiftType.Add("Circle", insertIndex);
                shiftType.Add("Square", insertIndex);

                CollectionHelper shiftTouch = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shifttouch\([abc]\)");
                shiftTouch.Add("True", insertText);
                shiftTouch.Add("False", insertText);

                CollectionHelper shiftQuantize = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftquantize\([abc]\)");
                shiftQuantize.Add("True", insertText);
                shiftQuantize.Add("False", insertText);

                CollectionHelper shiftSave = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftsave\([abc]\)");
                shiftSave.Add("True", insertText);
                shiftSave.Add("False", insertText);

                CollectionHelper shiftVisible = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftvisible\([abc]\)");
                shiftVisible.Add("True", insertText);
                shiftVisible.Add("False", insertText);

                CollectionHelper shiftStopMusic = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftstopmusic\([abc]\)");
                shiftStopMusic.Add("True", insertText);
                shiftStopMusic.Add("False", insertText);

                CollectionHelper shiftEffect = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shifteffect\([abc]\)");
                shiftEffect.Add("True", insertText);
                shiftEffect.Add("False", insertText);

                CollectionHelper shiftDenyHologram = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftdenyhologram\([abc]\)");
                shiftDenyHologram.Add("True", insertText);
                shiftDenyHologram.Add("False", insertText);

                CollectionHelper shiftAbsoluteTarget = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftabsolutetarget\([abc]\)");
                shiftAbsoluteTarget.Add("True", insertText);
                shiftAbsoluteTarget.Add("False", insertText);

                CollectionHelper shiftFlagOn = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftflagon\([abc]\)");
                for(int i = 0; i < 10; i++) {
                    shiftFlagOn.Add("Flag " + i, null);
                }
                shiftFlagOn.AddList("Powers", null, "Run", null, "Climb", null, "Double Jump", null, "High Jump", null, "Eye", null, "Detector", null, "Umbrella", null, "Hologram", null, "Red Key", null, "Yellow Key", null, "Blue Key", null, "Purple Key", null);

                CollectionHelper shiftFlagOff = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftflagoff\([abc]\)");
                for(int i = 0; i < 10; i++) {
                    shiftFlagOff.Add("Flag " + i, null);
                }
                shiftFlagOff.AddList("Powers", null, "Run", null, "Climb", null, "Double Jump", null, "High Jump", null, "Eye", null, "Detector", null, "Umbrella", null, "Hologram", null, "Red Key", null, "Yellow Key", null, "Blue Key", null, "Purple Key", null);

                CollectionHelper shiftSound = new CollectionHelper(form.contextMenuStrip4, ScreenPattern, @"shiftsound\([abc]\)");
                shiftSound.Add("None", insertText);
                shiftSound.Add("Electronic", insertText);
                shiftSound.Add("Door", insertText);
                shiftSound.Add("Switch", insertText);

                Collections.Add(flags);
                Collections.Add(shiftType);
                Collections.Add(shiftTouch);
                Collections.Add(shiftQuantize);
                Collections.Add(shiftSave);
                Collections.Add(shiftVisible);
                Collections.Add(shiftStopMusic);
                Collections.Add(shiftEffect);
                Collections.Add(shiftDenyHologram);
                Collections.Add(shiftAbsoluteTarget);
                Collections.Add(shiftFlagOn);
                Collections.Add(shiftFlagOff);
                Collections.Add(shiftSound);
                Collections.Add(screen);

                // Custom Object
            }
            ToolStripItemCollection GetMenuCollection(string line, string section) {
                string key = "";
                int i = line.IndexOf('=');
                if(i != -1) key = line.Substring(0, i);
                foreach(var collection in Collections) {
                    if(collection.Match(section, key)) return collection.GetItems();
                }
                return null;
            }

            private void insertText(object sender, EventArgs e) {
                //string value = form.scintilla1.Lines.Current.Text;
                //value = value.Substring(0, value.IndexOf('=') + 1);
                //form.scintilla1.Lines.Current.Text = value + ((ToolStripMenuItem)sender).Text;
                //form.scintilla1.GoTo.Position(form.scintilla1.Lines.Current.EndPosition);
            }
            private void keyInsertText(object sender, EventArgs e) {
                //form.scintilla1.Lines.Current.Text = ((ToolStripMenuItem)sender).Text + '=';
                //form.scintilla1.GoTo.Position(form.scintilla1.Lines.Current.EndPosition);
            }
            private void insertIndex(object sender, EventArgs e) {
                //ToolStripMenuItem i = (ToolStripMenuItem)sender;
                //string value = form.scintilla1.Lines.Current.Text;
                //value = value.Substring(0, value.IndexOf('=') + 1);
                //form.scintilla1.Lines.Current.Text = value + i.GetCurrentParent().Items.IndexOf(i).ToString();
                //form.scintilla1.GoTo.Position(form.scintilla1.Lines.Current.EndPosition);
            }
            private void insertPath(object sender, EventArgs e) {
                //ToolStripItem i = (ToolStripItem)sender;
                //string key = '(' + i.Text + ")=";
                //ToolStripItem parent1 = i.OwnerItem;
                //if(parent1 != null) {
                //  key = parent1.Text + key;
                //  ToolStripItem parent2 = parent1.OwnerItem;
                //  if(parent2 != null) key = parent2.Text + key;
                //}
                //form.scintilla1.Lines.Current.Text = key.Replace(" ", "");
                //form.scintilla1.GoTo.Position(form.scintilla1.Lines.Current.EndPosition);
            }
            private void warp(object sender, EventArgs e) {
                //ToolStripItem i = (ToolStripItem)sender;
                //form.scintilla1.Lines.Current.Text = (i.OwnerItem.Text + '(' + i.Text[0] + ")=").Replace(" ", "");
                //form.scintilla1.GoTo.Position(form.scintilla1.Lines.Current.EndPosition);
            }

            public WorldIniTab(EditorForm parent) {
                form = parent;

                CreateMenuCollections();

                form.worldIni_goToWorld.Click += delegate { scrollToLine("[world]"); };
                form.worldIni_goToCutsceneMusic.Click += delegate { scrollToLine("[cutscene music]"); };
                form.worldIni_goToCurrentScreen.Click += delegate { scrollToLine("[x" + Program.ActiveScreen.X + "y" + Program.ActiveScreen.Y + "]"); };
                form.worldIni_screenX.ValueChanged += goToScreen;
                form.worldIni_screenY.ValueChanged += goToScreen;
                form.worldIni_customObject.ValueChanged += delegate { scrollToLine("[custom object " + form.worldIni_customObject.Value + "]"); };

                form.contextMenuStrip4.Opening += contextMenuStrip4_Opening;

                //form.scintilla1.ConfigurationManager.Language = "props";
                //form.scintilla1.ConfigurationManager.Configure();
                //form.scintilla1.Lexing.LexerName = "props";

                //Font theFont = new Font("Courier New", 8);

                //form.scintilla1.Styles[0].ForeColor = Color.Black;
                //form.scintilla1.Styles[0].Font = theFont;

                //form.scintilla1.Styles[1].ForeColor = Color.Gray;
                //form.scintilla1.Styles[1].Font = theFont;

                //form.scintilla1.Styles[2].ForeColor = Color.Green;
                //form.scintilla1.Styles[2].Font = theFont;

                //form.scintilla1.Styles[3].ForeColor = Color.Gray;
                //form.scintilla1.Styles[3].Font = theFont;

                //form.scintilla1.Styles[5].ForeColor = Color.Blue;
                //form.scintilla1.Styles[5].Font = theFont;

                //form.scintilla1.Folding.IsEnabled = true;
            }
            public void StoryChanged() {
                form.worldIni_avEdit.Text = File.ReadAllText(Program.OpenStory.WorldIni.Path);
            }
            public void TabOpened() {
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                return false;
            }

            private void contextMenuStrip4_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
                //while(form.contextMenuStrip4.Items.Count > 9) {
                //  form.contextMenuStrip4.Items.RemoveAt(0);
                //}
                //Point pos = form.scintilla1.PointToClient(Cursor.Position);
                //ScintillaNET.Line line = form.scintilla1.Lines.FromPosition(form.scintilla1.PositionFromPoint(pos.X, pos.Y));
                //string section = "";
                //for(int i = line.Number; i >= 0; i--) {
                //  string s = form.scintilla1.Lines[i].Text.Trim();
                //  if(s != "" && s[0] == '[') {
                //	section = s.ToLower();
                //	break;
                //  }
                //}
                //ToolStripItemCollection items = GetMenuCollection(line.Text.ToLower(), section);
                //if(items != null) {
                //  for(int i = items.Count - 1; i >= 0; i--) {
                //	form.contextMenuStrip4.Items.Insert(0, items[i]);
                //  }
                //  form.contextMenuStrip4.Items.Insert(items.Count, new ToolStripSeparator());
                //}
            }

            private void goToScreen(object sender, EventArgs e) {
                scrollToLine("[x" + form.worldIni_screenX.Value + "y" + form.worldIni_screenY.Value + "]");
            }
            private void scrollToLine(string line) {
                //foreach(ScintillaNET.Line ln in form.scintilla1.Lines) {
                //  if(ln.Text.Trim().ToLower() == line) {
                //	form.scintilla1.Focus();
                //	form.scintilla1.GoTo.Line(ln.Number);
                //	form.scintilla1.Lines.FirstVisibleIndex = ln.Number;
                //	return;
                //  }
                //}
            }
        }
    }
}
