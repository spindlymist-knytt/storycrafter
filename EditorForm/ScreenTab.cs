using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        public Image Screen {
            get { return this.screen_mainView.Image; }
            set { this.screen_mainView.Image = value; }
        }
        // TODO: show custom objects
        // TODO: tile to custom object
        // TODO: follow warps/shifts
        // TODO: go to x1000y1000, start screen, last save, coordinates
        // TODO: undo/redo
        // TODO: set start position
        // TODO: test level
        // TODO: functional view menu
        // TODO: ground tool
        // TODO: ambiance/music preview
        // TODO: show neighboring screens
        // TODO: new screens
        // TODO: recently used objects
        class ScreenTab {

            EditorForm form;
            System.Timers.Timer TimerA, TimerB, TimerGrad;

            bool changingScreen = false;
            bool screenEdited = false;

            int brushSizeX {
                get { return (int)form.screen_brushX.Value; }
            }
            int brushSizeY {
                get { return (int)form.screen_brushY.Value; }
            }

            Tileset TilesetA, TilesetB;
            Bitmap Gradient;
            TileSelection selection;
            int activeTileset; // 0 = A, 1 = B

            List<EditingTool> tools;
            EditingTool currentTool;
            int currentToolIdx = 0;

            Pattern editingPattern = null;
            bool newPattern = false;

            Tuple<RadioButton,Label>[] layerSelectors;

            public int CurrentToolIndex {
                get { return currentToolIdx; }
                set {
                    currentToolIdx = value;
                    currentTool = tools[currentToolIdx];
                }
            }

            public ScreenTab(EditorForm parent) {
                form = parent;

                // These timers are used to create a delay between changing the tileset/gradient and redrawing the screen.
                // Otherwise, the program would freeze up when a user scrolled through the tilesets/gradients.

                this.TimerA = new System.Timers.Timer() { AutoReset = false, Interval = 75 };
                this.TimerA.Elapsed += ChangeTilesetA;
                this.TimerB = new System.Timers.Timer() { AutoReset = false, Interval = 75 };
                this.TimerB.Elapsed += ChangeTilesetB;
                this.TimerGrad = new System.Timers.Timer() { AutoReset = false, Interval = 75 };
                this.TimerGrad.Elapsed += ChangeGradient;

                form.screen_tilesetA.ValueChanged += tilesetA_ValueChanged;
                form.screen_tilesetB.ValueChanged += tilesetB_ValueChanged;
                form.screen_gradient.ValueChanged += gradient_ValueChanged;

                form.screen_tilesetViewA.MouseUp += delegate (Object sender, MouseEventArgs e) {
                    this.activeTileset = 0;
                    this.selection = form.screen_tilesetViewA.Selection;
                    form.screen_tilesetViewB.Active = false;
                };
                form.screen_tilesetViewB.MouseUp += delegate (Object sender, MouseEventArgs e) {
                    this.activeTileset = 1;
                    this.selection = form.screen_tilesetViewB.Selection;
                    form.screen_tilesetViewA.Active = false;
                };
                form.screen_objectList.LargeImageList = new ImageList();
                form.screen_objectList.LargeImageList.ImageSize = new Size(24, 24);
                Program.SendMessage(form.screen_objectList.Handle, 0x1000 + 53, IntPtr.Zero, (IntPtr)(((ushort)(30)) | (uint)((50) << 16))); // Sets margins and spacing.

                form.screen_bankList.SelectedIndexChanged += bankList_SelectedIndexChanged;
                foreach(ObjectBank b in Program.Banks) {
                    form.screen_bankList.Items.Add(b.Index + ". " + b.Name);
                }

                form.screen_mainView.GetCanvas += delegate () {
                    return editingPattern == null ? (ICanvas)Program.ActiveScreen : (ICanvas)editingPattern;
                };
                form.screen_mainView.GetLayer += delegate () {
                    return editingPattern == null ? Program.ActiveScreen.Layers[GetActiveLayer()] : editingPattern.Layers[GetActiveLayer()];
                };
                form.screen_mainView.GetTool += delegate () {
                    return currentTool;
                };
                form.screen_mainView.GetSelection += delegate () {
                    return selection;
                };
                form.screen_mainView.GetBrushSize += delegate () {
                    return new Size(this.brushSizeX, this.brushSizeY);
                };
                form.screen_mainView.GetTilesetIndex += delegate () {
                    return activeTileset;
                };
                form.screen_mainView.GetObject += delegate () {
                    return new Tuple<int, int>(Program.Banks.ByAbsoluteIndex(form.screen_bankList.SelectedIndex).Index,
                        form.screen_objectList.SelectedIndices.Count > 0 ? form.screen_objectList.SelectedIndices[0] : 0); // TODO make more robust?
                };
                form.screen_mainView.GetTilesetA += delegate () {
                    return TilesetA;
                };
                form.screen_mainView.GetTilesetB += delegate () {
                    return TilesetB;
                };
                form.screen_mainView.GetGradient += delegate () {
                    return Gradient;
                };
                // TODO move to function
                form.screen_mainView.MouseUp += delegate (Object sender, MouseEventArgs e) {
                    if(e.Button == MouseButtons.Right) {
                        int layer = GetActiveLayer();
                        int x = (int)(e.X / 24f);
                        int y = (int)(e.Y / 24f);
                        Tile t = editingPattern == null ? Program.ActiveScreen.Layers[layer].Tiles[y * Program.ScreenWidth + x] :
                                                                editingPattern.Layers[layer].Tiles[y * Program.ScreenWidth + x];
                        if(layer < 4) {
                            activeTileset = t.Tileset;
                            if(activeTileset == 0) {
                                form.screen_tilesetViewA.Active = true;
                                form.screen_tilesetViewB.Active = false;
                                selection = form.screen_tilesetViewA.Selection;
                            }
                            else {
                                form.screen_tilesetViewA.Active = false;
                                form.screen_tilesetViewB.Active = true;
                                selection = form.screen_tilesetViewB.Selection;
                            }
                            selection.Clear();
                            Point p = Program.TilesetIndexToPoint(t.Index);
                            selection.Add(new Rectangle(p.X, p.Y, 1, 1));
                            form.screen_tilesetViewA.Refresh();
                            form.screen_tilesetViewB.Refresh();
                        }
                        else {
                            ObjectBank bank = Program.Banks[t.Bank];
                            int idx = bank.AbsoluteIndex;
                            int obj = bank.AbsoluteIndexOf(t.Index);
                            if(idx < form.screen_bankList.Items.Count && obj >= 0 && obj < bank.Count) {
                                form.screen_bankList.SelectedIndex = idx;
                                form.screen_objectList.SelectedIndices.Clear();
                                form.screen_objectList.SelectedIndices.Add(obj);
                                form.screen_objectList.EnsureVisible(form.screen_objectList.SelectedIndices[0]);
                            }
                        }
                    }
                };

                TabPage pg = form.tabControl1.TabPages["tabPageScreen"];
                layerSelectors = new Tuple<RadioButton, Label>[8];
                for(int i = 0; i < 8; i++) {
                    layerSelectors[i] = new Tuple<RadioButton, Label>(
                        (RadioButton)pg.Controls["screen_layer" + i],
                        (Label)pg.Controls["screen_layer" + i + "Label"]
                    );
                    layerSelectors[i].Item1.Tag = i;
                    layerSelectors[i].Item1.MouseUp += layerSelector_MouseUp;
                }

                // TODO fix hotkeys
                form.screen_mainView.Click += delegate {
                    form.tabControl1.Focus();
                };
                form.tabControl1.KeyUp += delegate (object sender, KeyEventArgs e) {
                    switch(e.KeyCode) {
                        case Keys.W:
                            if(editingPattern == null && e.Shift) {
                                this.ChangeScreen(Program.ActiveScreen.X, Program.ActiveScreen.Y - 1);
                            }
                            else {
                                selection.Translate(0, -1);
                                form.screen_tilesetViewA.Refresh();
                                form.screen_tilesetViewB.Refresh();
                            }
                            break;
                        case Keys.A:
                            if(editingPattern == null && e.Shift) {
                                this.ChangeScreen(Program.ActiveScreen.X - 1, Program.ActiveScreen.Y);
                            }
                            else {
                                selection.Translate(-1, 0);
                                form.screen_tilesetViewA.Refresh();
                                form.screen_tilesetViewB.Refresh();
                            }
                            break;
                        case Keys.S:
                            if(editingPattern == null && e.Shift) {
                                this.ChangeScreen(Program.ActiveScreen.X, Program.ActiveScreen.Y + 1);
                            }
                            else {
                                selection.Translate(0, 1);
                                form.screen_tilesetViewA.Refresh();
                                form.screen_tilesetViewB.Refresh();
                            }
                            break;
                        case Keys.D:
                            if(editingPattern == null && e.Shift) {
                                this.ChangeScreen(Program.ActiveScreen.X + 1, Program.ActiveScreen.Y);
                            }
                            else {
                                selection.Translate(1, 0);
                                form.screen_tilesetViewA.Refresh();
                                form.screen_tilesetViewB.Refresh();
                            }
                            break;
                        case Keys.D0:
                            form.screen_layer0.Checked = true;
                            break;
                        case Keys.D1:
                            form.screen_layer1.Checked = true;
                            break;
                        case Keys.D2:
                            form.screen_layer2.Checked = true;
                            break;
                        case Keys.D3:
                            form.screen_layer3.Checked = true;
                            break;
                        case Keys.D4:
                            form.screen_layer4.Checked = true;
                            break;
                        case Keys.D5:
                            form.screen_layer5.Checked = true;
                            break;
                        case Keys.D6:
                            form.screen_layer6.Checked = true;
                            break;
                        case Keys.D7:
                            form.screen_layer7.Checked = true;
                            break;
                    }
                };

                form.screen_comboPatterns.Items.Add("");
                form.screen_comboPatterns.SelectedIndex = 0;
                // TODO move to function
                form.screen_buttonEditPattern.Click += delegate {
                    if(editingPattern == null) {
                        form.screen_tilesetA.Enabled = false;
                        form.screen_tilesetB.Enabled = false;
                        form.screen_gradient.Enabled = false;
                        form.screen_music.Enabled = false;
                        form.screen_ambiA.Enabled = false;
                        form.screen_ambiB.Enabled = false;
                        form.screen_comboPatterns.DropDownStyle = ComboBoxStyle.Simple;
                        form.screen_buttonEditPattern.Text = "Save";
                        form.screen_mainView.Resizable = true;
                        if(form.screen_comboPatterns.SelectedIndex <= 0) {
                            editingPattern = new Pattern(GetActiveLayer());
                            newPattern = true;
                            for(int i = 0; i < 8; i++) {
                                layerSelectors[i].Item2.Enabled = layerSelectors[i].Item1.Checked;
                            }
                        }
                        else {
                            editingPattern = Program.OpenStory.Patterns[form.screen_comboPatterns.SelectedIndex - 1];
                            form.screen_mainView.Size = new Size(editingPattern.Width * 24 + 2, editingPattern.Height * 24 + 2);
                            for(int i = 0; i < 8; i++) {
                                layerSelectors[i].Item2.Enabled = editingPattern.Layers[i].Active;
                            }
                        }
                        form.screen_checkBoxOverwrite.Visible = true;
                        form.screen_checkBoxOverwrite.Checked = editingPattern.Overwrite;
                        form.screen_mainView.Draw();
                    }
                    else {
                        if(form.screen_comboPatterns.Text == "" &&
                           MessageBox.Show("Please enter a name for your pattern, or press Cancel to discard.", "Enter Pattern Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                            return;
                        }
                        if(form.screen_comboPatterns.Text != "") {
                            editingPattern.Name = form.screen_comboPatterns.Text;
                            if(newPattern) {
                                Program.OpenStory.Patterns.Add(editingPattern);
                                form.screen_comboPatterns.Items.Add(editingPattern.Name);
                                form.screen_comboPatterns.SelectedIndex = form.screen_comboPatterns.Items.Count - 1;
                            }
                            else {
                                form.screen_comboPatterns.Items[Program.OpenStory.Patterns.IndexOf(editingPattern) + 1] = editingPattern.Name;
                                form.screen_buttonEditPattern.Text = "Edit";
                            }
                            ((PatternTool)tools[4]).Source = editingPattern;
                        }
                        else {
                            form.screen_comboPatterns.SelectedIndex = 0;
                        }
                        newPattern = false;
                        form.screen_tilesetA.Enabled = true;
                        form.screen_tilesetB.Enabled = true;
                        form.screen_gradient.Enabled = true;
                        form.screen_music.Enabled = true;
                        form.screen_ambiA.Enabled = true;
                        form.screen_ambiB.Enabled = true;
                        form.screen_comboPatterns.DropDownStyle = ComboBoxStyle.DropDown;
                        form.screen_mainView.Resizable = false;
                        form.screen_mainView.Size = new Size(Program.PxScreenWidth + 2, Program.PxScreenHeight + 2);
                        for(int i = 0; i < 8; i++) {
                            layerSelectors[i].Item2.Enabled = Program.ActiveScreen.Layers[i].Active;
                        }
                        form.screen_checkBoxOverwrite.Visible = false;
                        editingPattern = null;
                        form.screen_mainView.Draw();
                    }
                };
                form.screen_comboPatterns.SelectedIndexChanged += delegate {
                    if(form.screen_comboPatterns.SelectedIndex == 0) {
                        form.screen_buttonEditPattern.Text = "New";
                        ((PatternTool)tools[4]).Source = null;
                    }
                    else if(editingPattern == null) {
                        form.screen_buttonEditPattern.Text = "Edit";
                        ((PatternTool)tools[4]).Source = Program.OpenStory.Patterns[form.screen_comboPatterns.SelectedIndex - 1];
                    }
                };
                form.screen_checkBoxOverwrite.CheckedChanged += delegate {
                    editingPattern.Overwrite = form.screen_checkBoxOverwrite.Checked;
                };

                this.selection = form.screen_tilesetViewA.Selection;
                form.screen_tilesetViewA.Active = true;

                tools = new List<EditingTool>(5);
                tools.Add(new PaintTool());
                tools.Add(new FillTool());
                tools.Add(new ReplaceTool());
                tools.Add(new RandomizeTool());
                tools.Add(new PatternTool());
                currentTool = tools[0];
            }
            public void StoryChanged() {
                form.screen_bankList.SelectedIndex = 0;
                form.screen_comboPatterns.Items.Clear();
                form.screen_comboPatterns.Items.Add("");
                form.screen_comboPatterns.SelectedIndex = 0;
                // TODO exit pattern mode
                foreach(Pattern p in Program.OpenStory.Patterns) {
                    form.screen_comboPatterns.Items.Add(p.Name);
                }

                this.ScreenChanged();
            }
            public void ChangeScreen(int x, int y) {
                /*if(Program.OpenStory.GetScreen(x, y) == null) {
                  Story_Crafter.Screen s = new Story_Crafter.Screen(x, y);
                  s.TilesetA = Program.ActiveScreen.TilesetA;
                  s.TilesetB = Program.ActiveScreen.TilesetB;
                  s.Gradient = Program.ActiveScreen.Gradient;
                  s.AmbianceA = Program.ActiveScreen.AmbianceA;
                  s.AmbianceB = Program.ActiveScreen.AmbianceB;
                  s.Music = Program.ActiveScreen.Music;
                  Program.OpenStory.AddScreen(s);
                }*/
                Program.OpenStory.ChangeScreen(x, y);
                this.ScreenChanged();
            }
            public void ScreenChanged() {
                this.changingScreen = true;
                form.screen_tilesetA.Value = Program.ActiveScreen.TilesetA;
                form.screen_tilesetB.Value = Program.ActiveScreen.TilesetB;
                form.screen_gradient.Value = Program.ActiveScreen.Gradient;
                form.screen_ambiA.Value = Program.ActiveScreen.AmbianceA;
                form.screen_ambiB.Value = Program.ActiveScreen.AmbianceB;
                form.screen_music.Value = Program.ActiveScreen.Music;

                TilesetA = Program.OpenStory.CreateTileset(Program.ActiveScreen.TilesetA);
                TilesetB = Program.OpenStory.CreateTileset(Program.ActiveScreen.TilesetB);
                Gradient = Program.LoadBitmap(Program.OpenStory.Gradient(Program.ActiveScreen.Gradient));
                form.screen_tilesetViewA.Image = (Image)TilesetA.Full.Clone();
                form.screen_tilesetViewB.Image = (Image)TilesetB.Full.Clone();

                form.screen_mainView.Draw();
                this.screenEdited = false;
                this.changingScreen = false;
            }
            public void TabOpened() {
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                return false;
            }
            public void ProfileChanged() {
                form.screen_bankList.Items.Clear();
                foreach(ObjectBank b in Program.Banks) {
                    form.screen_bankList.Items.Add(b.Index + ". " + b.Name);
                }
                form.screen_bankList.SelectedIndex = 0;

                form.screen_mainView.Draw();
            }

            private int GetActiveLayer() {
                for(int i = 0; i < 8; i++)
                    if(layerSelectors[i].Item1.Checked) return i;
                return -1;
            }

            private void tilesetA_ValueChanged(object sender, EventArgs e) {
                if(Program.ChangingStory || this.changingScreen) return;
                TimerA.Stop();
                TimerA.Start();
            }
            private void ChangeTilesetA(object sender, System.Timers.ElapsedEventArgs e) {
                Program.ActiveScreen.TilesetA = (int)form.screen_tilesetA.Value;
                TilesetA = Program.OpenStory.CreateTileset((int)form.screen_tilesetA.Value);
                form.screen_tilesetViewA.Image = (Image)TilesetA.Full.Clone();
                form.screen_mainView.Draw();
            }

            private void tilesetB_ValueChanged(object sender, EventArgs e) {
                if(Program.ChangingStory || this.changingScreen) return;
                TimerB.Stop();
                TimerB.Start();
            }
            private void ChangeTilesetB(object sender, System.Timers.ElapsedEventArgs e) {
                Program.ActiveScreen.TilesetB = (int)form.screen_tilesetB.Value;
                TilesetB = Program.OpenStory.CreateTileset((int)form.screen_tilesetB.Value);
                form.screen_tilesetViewB.Image = (Image)TilesetB.Full.Clone();
                form.screen_mainView.Draw();
            }

            private void gradient_ValueChanged(object sender, EventArgs e) {
                if(Program.ChangingStory || this.changingScreen) return;
                TimerGrad.Stop();
                TimerGrad.Start();
            }
            private void ChangeGradient(object sender, System.Timers.ElapsedEventArgs e) {
                Program.ActiveScreen.Gradient = (int)form.screen_gradient.Value;
                Gradient = Program.LoadBitmap(Program.OpenStory.Gradient((int)form.screen_gradient.Value));
                form.screen_mainView.Draw();
            }

            private void bankList_SelectedIndexChanged(object sender, EventArgs e) {
                ObjectBank bank = Program.Banks.ByAbsoluteIndex(form.screen_bankList.SelectedIndex);
                form.screen_objectList.Items.Clear();
                form.screen_objectList.LargeImageList.Images.Clear();
                form.screen_objectList.Items.Add("0");
                for(int i = 1; i < bank.Count; i++) {
                    Tuple<int, Bitmap> t = bank.ByAbsoluteIndex(i);
                    if(t.Item2 != null) {
                        form.screen_objectList.LargeImageList.Images.Add(t.Item2);
                        form.screen_objectList.Items.Add(t.Item1.ToString(), i - 1);
                    }
                    else form.screen_objectList.Items.Add(t.Item1.ToString());
                }
                form.screen_objectList.SelectedIndices.Clear();
                form.screen_objectList.SelectedIndices.Add(0);
            }

            private void layerSelector_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    int i = (int)((RadioButton)sender).Tag;
                    layerSelectors[i].Item2.Enabled = !layerSelectors[i].Item2.Enabled;
                    if(editingPattern == null) {
                        Program.ActiveScreen.Layers[i].Active = layerSelectors[i].Item2.Enabled;
                    }
                    else {
                        editingPattern.Layers[i].Active = layerSelectors[i].Item2.Enabled;
                    }
                    form.screen_mainView.Draw();
                }
            }
            
        }
    }
}
