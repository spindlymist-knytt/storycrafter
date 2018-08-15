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
        // TODO: brushes
        // TODO: follow warps/shifts
        // TODO: go to x1000y1000, start screen, last save, coordinates
        // TODO: undo/redo
        // TODO: set start position
        // TODO: test level
        // TODO: functional view menu
        // TODO: ground tool
        // TODO: make tools more flexible
        // TODO: ambiance/music preview
        // TODO: show neighboring screens
        // TODO: new screens
        // TODO: recently used objects
        class ScreenTab {

            EditorForm form;
            System.Timers.Timer TimerA, TimerB, TimerGrad, TimerDraw;

            bool changingScreen = false;
            bool screenEdited = false;

            bool hover = false;
            Point hoverPosition = new Point();
            Pen tileCursor = new Pen(Color.Orange);
            Pen newSelectionCursor = new Pen(Color.AntiqueWhite);
            Pen objectCursor = new Pen(Color.Gold);
            Pen specialCursor = new Pen(Color.Orchid);

            int brushSizeX {
                get { return (int)form.screen_brushX.Value; }
            }
            int brushSizeY {
                get { return (int)form.screen_brushY.Value; }
            }

            TileSelection selection;
            int activeTileset; // 0 = A, 1 = B

            Point lastPaintLocation = new Point();
            bool painting = false;
            bool waitingToDraw = false;
            DateTime lastDrawn;

            List<EditingTool> tools;
            EditingTool currentTool;
            int currentToolIdx = 0;

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

                this.TimerDraw = new System.Timers.Timer();

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

                form.screen_mainView.MouseEnter += delegate { hover = true; };
                form.screen_mainView.MouseDown += mainView_MouseDown;
                form.screen_mainView.MouseMove += mainView_MouseMove;
                form.screen_mainView.MouseUp += mainView_MouseUp;
                form.screen_mainView.MouseLeave += delegate { hover = false; form.screen_mainView.Refresh(); };
                form.screen_mainView.Paint += mainView_Paint;

                form.screen_layer0.MouseUp += layer0_MouseUp;
                form.screen_layer1.MouseUp += layer1_MouseUp;
                form.screen_layer2.MouseUp += layer2_MouseUp;
                form.screen_layer3.MouseUp += layer3_MouseUp;
                form.screen_layer4.MouseUp += layer4_MouseUp;
                form.screen_layer5.MouseUp += layer5_MouseUp;
                form.screen_layer6.MouseUp += layer6_MouseUp;
                form.screen_layer7.MouseUp += layer7_MouseUp;

                form.button1.Click += delegate {
                    this.ChangeScreen(Program.OpenStory.ActiveScreen.X - 1, Program.OpenStory.ActiveScreen.Y);
                    this.ScreenChanged();
                };
                form.button2.Click += delegate {
                    this.ChangeScreen(Program.OpenStory.ActiveScreen.X + 1, Program.OpenStory.ActiveScreen.Y);
                    this.ScreenChanged();
                };
                form.button3.Click += delegate {
                    this.ChangeScreen(Program.OpenStory.ActiveScreen.X, Program.OpenStory.ActiveScreen.Y - 1);
                    this.ScreenChanged();
                };
                form.button4.Click += delegate {
                    this.ChangeScreen(Program.OpenStory.ActiveScreen.X, Program.OpenStory.ActiveScreen.Y + 1);
                    this.ScreenChanged();
                };

                // TODO fix hotkeys
                form.screen_mainView.Click += delegate {
                    form.tabControl1.Focus();
                };
                form.tabControl1.KeyUp += delegate (object sender, KeyEventArgs e) {
                    int x, y;
                    switch(e.KeyCode) {
                        // TODO move selection translation to TilesetViewPanel
                        case Keys.W:
                            x = selection.MinX;
                            y = selection.MinY;
                            if(y > 0) {
                                selection.Clear();
                                selection.Add(new Rectangle(x, y - 1, 1, 1));
                            }
                            form.screen_tilesetViewA.Refresh();
                            form.screen_tilesetViewB.Refresh();
                            break;
                        case Keys.A:
                            x = selection.MinX;
                            y = selection.MinY;
                            if(x > 0) {
                                selection.Clear();
                                selection.Add(new Rectangle(x - 1, y, 1, 1));
                            }
                            form.screen_tilesetViewA.Refresh();
                            form.screen_tilesetViewB.Refresh();
                            break;
                        case Keys.S:
                            x = selection.MinX;
                            y = selection.MinY;
                            if(y < Program.TilesetHeight - 1) {
                                selection.Clear();
                                selection.Add(new Rectangle(x, y + 1, 1, 1));
                            }
                            form.screen_tilesetViewA.Refresh();
                            form.screen_tilesetViewB.Refresh();
                            break;
                        case Keys.D:
                            x = selection.MinX;
                            y = selection.MinY;
                            if(x < Program.TilesetWidth - 1) {
                                selection.Clear();
                                selection.Add(new Rectangle(x + 1, y, 1, 1));
                            }
                            form.screen_tilesetViewA.Refresh();
                            form.screen_tilesetViewB.Refresh();
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

                this.selection = form.screen_tilesetViewA.Selection;
                form.screen_tilesetViewA.Active = true;

                tools = new List<EditingTool>(4);
                tools.Add(new PaintTool());
                tools.Add(new FillTool());
                tools.Add(new ReplaceTool());
                tools.Add(new RandomizeTool());
                currentTool = tools[0];
            }
            public void StoryChanged() {
                form.screen_bankList.SelectedIndex = 0;

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
                form.screen_tilesetA.Value = Program.OpenStory.ActiveScreen.TilesetA;
                form.screen_tilesetB.Value = Program.OpenStory.ActiveScreen.TilesetB;
                form.screen_gradient.Value = Program.OpenStory.ActiveScreen.Gradient;
                form.screen_ambiA.Value = Program.OpenStory.ActiveScreen.AmbianceA;
                form.screen_ambiB.Value = Program.OpenStory.ActiveScreen.AmbianceB;
                form.screen_music.Value = Program.OpenStory.ActiveScreen.Music;

                form.screen_tilesetViewA.Image = (Image)Program.OpenStory.TilesetACache.Full.Clone();
                form.screen_tilesetViewB.Image = (Image)Program.OpenStory.TilesetBCache.Full.Clone();

                Draw();
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

                this.Draw();
            }

            private void Draw() {
                Image updatedScreen = new Bitmap(Program.PxScreenWidth, Program.PxScreenHeight);
                Program.OpenStory.ActiveScreen.Draw(Graphics.FromImage(updatedScreen));
                form.screen_mainView.Image = updatedScreen;
            }
            private int GetActiveLayer() {
                if(form.screen_layer0.Checked) return 0;
                if(form.screen_layer1.Checked) return 1;
                if(form.screen_layer2.Checked) return 2;
                if(form.screen_layer3.Checked) return 3;
                if(form.screen_layer4.Checked) return 4;
                if(form.screen_layer5.Checked) return 5;
                if(form.screen_layer6.Checked) return 6;
                if(form.screen_layer7.Checked) return 7;
                return -1;
            }

            private void tilesetA_ValueChanged(object sender, EventArgs e) {
                if(Program.ChangingStory || this.changingScreen) return;
                TimerA.Stop();
                TimerA.Start();
            }
            private void ChangeTilesetA(object sender, System.Timers.ElapsedEventArgs e) {
                Program.ActiveScreen.TilesetA = (int)form.screen_tilesetA.Value;
                Program.OpenStory.TilesetACache = Program.OpenStory.CreateTileset((int)form.screen_tilesetA.Value);
                form.screen_tilesetViewA.Image = (Image)Program.OpenStory.TilesetACache.Full.Clone();
                this.Draw();
            }

            private void tilesetB_ValueChanged(object sender, EventArgs e) {
                if(Program.ChangingStory || this.changingScreen) return;
                TimerB.Stop();
                TimerB.Start();
            }
            private void ChangeTilesetB(object sender, System.Timers.ElapsedEventArgs e) {
                Program.ActiveScreen.TilesetB = (int)form.screen_tilesetB.Value;
                Program.OpenStory.TilesetBCache = Program.OpenStory.CreateTileset((int)form.screen_tilesetB.Value);
                form.screen_tilesetViewB.Image = (Image)Program.OpenStory.TilesetBCache.Full.Clone();
                this.Draw();
            }

            private void gradient_ValueChanged(object sender, EventArgs e) {
                if(Program.ChangingStory || this.changingScreen) return;
                TimerGrad.Stop();
                TimerGrad.Start();
            }
            private void ChangeGradient(object sender, System.Timers.ElapsedEventArgs e) {
                Program.ActiveScreen.Gradient = (int)form.screen_gradient.Value;
                Program.OpenStory.GradientCache = Program.LoadBitmap(Program.OpenStory.Gradient((int)form.screen_gradient.Value));
                this.Draw();
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

            private void mainView_MouseDown(object sender, MouseEventArgs e) {
                int x = (int)(e.X / 24f);
                int y = (int)(e.Y / 24f);
                if(e.Button == MouseButtons.Left) {
                    lastPaintLocation.X = x;
                    lastPaintLocation.Y = y;
                    painting = true;
                    PaintTiles();
                    Draw();
                    lastDrawn = DateTime.Now;
                    waitingToDraw = false;
                }
            }
            private void mainView_MouseMove(object sender, MouseEventArgs e) {
                hoverPosition.X = (int)(e.X / 24f);
                hoverPosition.Y = (int)(e.Y / 24f);
                if(painting && !hoverPosition.Equals(lastPaintLocation)) {
                    lastPaintLocation.X = hoverPosition.X;
                    lastPaintLocation.Y = hoverPosition.Y;
                    PaintTiles();
                    if((DateTime.Now - lastDrawn).TotalMilliseconds > 45) {
                        Draw();
                        lastDrawn = DateTime.Now;
                        waitingToDraw = false;
                    }
                    else {
                        waitingToDraw = true;
                    }
                }
                else {
                    form.screen_mainView.Refresh();
                }
            }
            private void mainView_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Left) {
                    if(waitingToDraw) {
                        Draw();
                    }
                    painting = false;
                }
                else if(e.Button == MouseButtons.Right) {
                    int layer = GetActiveLayer();
                    int x = (int)(e.X / 24f);
                    int y = (int)(e.Y / 24f);
                    Tile t = Program.OpenStory.ActiveScreen.Layers[layer].Tiles[y * Program.ScreenWidth + x];
                    if(layer < 4) {
                        // TODO fix this nonsense
                        selection.Clear();
                        Point p = Program.TilesetIndexToPoint(t.Index);
                        selection.Add(new Rectangle(p.X, p.Y, 1, 1));
                        activeTileset = t.Tileset;
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
            }
            private void mainView_Paint(object sender, PaintEventArgs e) {
                if(hover) {
                    // TODO: maybe generalize this so tools draw their own cursor?
                    if(currentToolIdx == 0) { // Edit tool
                        if(GetActiveLayer() < 4) {
                            for(int x = hoverPosition.X; x < hoverPosition.X + brushSizeX * selection.Width; x += selection.Width) {
                                for(int y = hoverPosition.Y; y < hoverPosition.Y + brushSizeY * selection.Height; y += selection.Height) {
                                    e.Graphics.DrawImage(selection.Borders,
                                               new Rectangle(x * 24, y * 24, selection.Borders.Width, selection.Borders.Height),
                                               new Rectangle(0, 0, selection.Borders.Width, selection.Borders.Height),
                                               GraphicsUnit.Pixel);
                                }
                            }
                        }
                        else e.Graphics.DrawRectangle(objectCursor, hoverPosition.X * 24, hoverPosition.Y * 24, 24 * brushSizeX - 1, 24 * brushSizeY - 1);
                    }
                    else if(currentToolIdx == 3) { // Randomize tool
                        e.Graphics.DrawRectangle(specialCursor, hoverPosition.X * 24, hoverPosition.Y * 24, 24 * brushSizeX - 1, 24 * brushSizeY - 1);
                    }
                    else {
                        e.Graphics.DrawRectangle(specialCursor, hoverPosition.X * 24, hoverPosition.Y * 24, 23, 23);
                    }
                }
            }
            private void PaintTiles() {
                int layer = GetActiveLayer();
                if(layer < 4) {
                    currentTool.Paint((TileLayer) Program.Layers[layer], selection, hoverPosition, brushSizeX, brushSizeY, activeTileset);
                }
                else {
                    currentTool.Paint((ObjectLayer) Program.Layers[layer], hoverPosition, brushSizeX, brushSizeY, Program.Banks.ByAbsoluteIndex(form.screen_bankList.SelectedIndex).Index, form.screen_objectList.SelectedIndices[0]);
                }
            }

            private void layer0_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[0].Active = !Program.OpenStory.ActiveScreen.Layers[0].Active;
                    form.screen_layer0Label.Enabled = Program.OpenStory.ActiveScreen.Layers[0].Active;
                    Draw();
                }
            }
            private void layer1_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[1].Active = !Program.OpenStory.ActiveScreen.Layers[1].Active;
                    form.screen_layer1Label.Enabled = Program.OpenStory.ActiveScreen.Layers[1].Active;
                    Draw();
                }
            }
            private void layer2_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[2].Active = !Program.OpenStory.ActiveScreen.Layers[2].Active;
                    form.screen_layer2Label.Enabled = Program.OpenStory.ActiveScreen.Layers[2].Active;
                    Draw();
                }
            }
            private void layer3_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[3].Active = !Program.OpenStory.ActiveScreen.Layers[3].Active;
                    form.screen_layer3Label.Enabled = Program.OpenStory.ActiveScreen.Layers[3].Active;
                    Draw();
                }
            }
            private void layer4_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[4].Active = !Program.OpenStory.ActiveScreen.Layers[4].Active;
                    form.screen_layer4Label.Enabled = Program.OpenStory.ActiveScreen.Layers[4].Active;
                    Draw();
                }
            }
            private void layer5_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[5].Active = !Program.OpenStory.ActiveScreen.Layers[5].Active;
                    form.screen_layer5Label.Enabled = Program.OpenStory.ActiveScreen.Layers[5].Active;
                    Draw();
                }
            }
            private void layer6_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[6].Active = !Program.OpenStory.ActiveScreen.Layers[6].Active;
                    form.screen_layer6Label.Enabled = Program.OpenStory.ActiveScreen.Layers[6].Active;
                    Draw();
                }
            }
            private void layer7_MouseUp(object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    Program.OpenStory.ActiveScreen.Layers[7].Active = !Program.OpenStory.ActiveScreen.Layers[7].Active;
                    form.screen_layer7Label.Enabled = Program.OpenStory.ActiveScreen.Layers[7].Active;
                    Draw();
                }
            }
        }
    }
}
