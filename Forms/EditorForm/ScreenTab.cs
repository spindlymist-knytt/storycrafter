using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Story_Crafter.Editing;
using Story_Crafter.Editing.Tools;
using Story_Crafter.Knytt;
using Story_Crafter.Rendering;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Forms.EditorForm {
        
    partial class ScreenTab : UserControl, IEditorTab {

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

        System.Timers.Timer TimerA, TimerB, TimerGrad;

        bool changingScreen = false;

        int brushSizeX {
            get { return (int)this.screen_brushX.Value; }
        }
        int brushSizeY {
            get { return (int)this.screen_brushY.Value; }
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

        EditorForm form;
        Story story;
        Screen screen;

        public ScreenTab() {
            InitializeComponent();

            form = this.FindForm() as EditorForm;

            // These timers are used to create a delay between changing the tileset/gradient and redrawing the screen.
            // Otherwise, the program would freeze up when a user scrolled through the tilesets/gradients.

            this.TimerA = new System.Timers.Timer() { AutoReset = false, Interval = 75 };
            this.TimerA.Elapsed += ChangeTilesetA;
            this.TimerB = new System.Timers.Timer() { AutoReset = false, Interval = 75 };
            this.TimerB.Elapsed += ChangeTilesetB;
            this.TimerGrad = new System.Timers.Timer() { AutoReset = false, Interval = 75 };
            this.TimerGrad.Elapsed += ChangeGradient;

            this.screen_tilesetA.ValueChanged += tilesetA_ValueChanged;
            this.screen_tilesetB.ValueChanged += tilesetB_ValueChanged;
            this.screen_gradient.ValueChanged += gradient_ValueChanged;

            this.screen_tilesetViewA.MouseUp += delegate (Object sender, MouseEventArgs e) {
                this.activeTileset = 0;
                this.selection = this.screen_tilesetViewA.Selection;
                this.screen_tilesetViewB.Active = false;
            };
            this.screen_tilesetViewB.MouseUp += delegate (Object sender, MouseEventArgs e) {
                this.activeTileset = 1;
                this.selection = this.screen_tilesetViewB.Selection;
                this.screen_tilesetViewA.Active = false;
            };
            this.screen_objectList.LargeImageList = new ImageList();
            this.screen_objectList.LargeImageList.ImageSize = new Size(24, 24);
            Program.SendMessage(this.screen_objectList.Handle, 0x1000 + 53, IntPtr.Zero, (IntPtr)(((ushort)(30)) | (uint)((50) << 16))); // Sets margins and spacing.

            this.screen_bankList.SelectedIndexChanged += bankList_SelectedIndexChanged;
            foreach(ObjectBank b in Program.Banks) {
                this.screen_bankList.Items.Add(b.Index + ". " + b.Name);
            }

            this.screen_mainView.GetCanvas += delegate () {
                return editingPattern == null ? (ICanvas)this.screen : (ICanvas)editingPattern;
            };
            this.screen_mainView.GetLayer += delegate () {
                return editingPattern == null ? this.screen.Layers[GetActiveLayer()] : editingPattern.Layers[GetActiveLayer()];
            };
            this.screen_mainView.GetTool += delegate () {
                return currentTool;
            };
            this.screen_mainView.GetSelection += delegate () {
                return selection;
            };
            this.screen_mainView.GetBrushSize += delegate () {
                return new Size(this.brushSizeX, this.brushSizeY);
            };
            this.screen_mainView.GetTilesetIndex += delegate () {
                return activeTileset;
            };
            this.screen_mainView.GetObject += delegate () {
                return new Tuple<int, int>(Program.Banks.ByAbsoluteIndex(this.screen_bankList.SelectedIndex).Index,
                    this.screen_objectList.SelectedIndices.Count > 0 ? this.screen_objectList.SelectedIndices[0] : 0); // TODO make more robust?
            };
            this.screen_mainView.GetTilesetA += delegate () {
                return TilesetA;
            };
            this.screen_mainView.GetTilesetB += delegate () {
                return TilesetB;
            };
            this.screen_mainView.GetGradient += delegate () {
                return Gradient;
            };
            // TODO move to function
            this.screen_mainView.MouseUp += delegate (Object sender, MouseEventArgs e) {
                if(e.Button == MouseButtons.Right) {
                    int layer = GetActiveLayer();
                    int x = (int)(e.X / Metrics.TileSizef);
                    int y = (int)(e.Y / Metrics.TileSizef);
                    Tile t = editingPattern == null
                        ? this.screen.Layers[layer].Tiles[y * Metrics.ScreenWidth + x]
                        : editingPattern.Layers[layer].Tiles[y * Metrics.ScreenWidth + x];
                    if(layer < 4) {
                        activeTileset = t.Tileset;
                        if(activeTileset == 0) {
                            this.screen_tilesetViewA.Active = true;
                            this.screen_tilesetViewB.Active = false;
                            selection = this.screen_tilesetViewA.Selection;
                        }
                        else {
                            this.screen_tilesetViewA.Active = false;
                            this.screen_tilesetViewB.Active = true;
                            selection = this.screen_tilesetViewB.Selection;
                        }
                        selection.Clear();
                        Point p = Metrics.TilesetIndexToPoint(t.Index);
                        selection.Add(new Rectangle(p.X, p.Y, 1, 1));
                        this.screen_tilesetViewA.Refresh();
                        this.screen_tilesetViewB.Refresh();
                    }
                    else {
                        ObjectBank bank = Program.Banks[t.Bank];
                        int idx = bank.AbsoluteIndex;
                        int obj = bank.AbsoluteIndexOf(t.Index);
                        if(idx < this.screen_bankList.Items.Count && obj >= 0 && obj < bank.Count) {
                            this.screen_bankList.SelectedIndex = idx;
                            this.screen_objectList.SelectedIndices.Clear();
                            this.screen_objectList.SelectedIndices.Add(obj);
                            this.screen_objectList.EnsureVisible(this.screen_objectList.SelectedIndices[0]);
                        }
                    }
                }
            };

            layerSelectors = new Tuple<RadioButton, Label>[] {
                Tuple.Create(this.screen_layer0, this.screen_layer0Label),
                Tuple.Create(this.screen_layer1, this.screen_layer1Label),
                Tuple.Create(this.screen_layer2, this.screen_layer2Label),
                Tuple.Create(this.screen_layer3, this.screen_layer3Label),
                Tuple.Create(this.screen_layer4, this.screen_layer4Label),
                Tuple.Create(this.screen_layer5, this.screen_layer5Label),
                Tuple.Create(this.screen_layer6, this.screen_layer6Label),
                Tuple.Create(this.screen_layer7, this.screen_layer7Label),
            };
            for(int i = 0; i < layerSelectors.Length; i++) {
                layerSelectors[i].Item1.Tag = i;
                layerSelectors[i].Item1.MouseUp += layerSelector_MouseUp;
            }

            // TODO fix hotkeys
            this.screen_mainView.Click += delegate {
                //this.tabControl1.Focus();
            };
            this.KeyUp += delegate (object sender, KeyEventArgs e) {
                switch (e.KeyCode) {
                    case Keys.W:
                        selection.Translate(0, -1);
                        this.screen_tilesetViewA.Refresh();
                        this.screen_tilesetViewB.Refresh();
                        break;
                    case Keys.A:
                        selection.Translate(-1, 0);
                        this.screen_tilesetViewA.Refresh();
                        this.screen_tilesetViewB.Refresh();
                        break;
                    case Keys.S:
                        selection.Translate(0, 1);
                        this.screen_tilesetViewA.Refresh();
                        this.screen_tilesetViewB.Refresh();
                        break;
                    case Keys.D:
                        selection.Translate(1, 0);
                        this.screen_tilesetViewA.Refresh();
                        this.screen_tilesetViewB.Refresh();
                        break;
                    case Keys.D0:
                        this.screen_layer0.Checked = true;
                        break;
                    case Keys.D1:
                        this.screen_layer1.Checked = true;
                        break;
                    case Keys.D2:
                        this.screen_layer2.Checked = true;
                        break;
                    case Keys.D3:
                        this.screen_layer3.Checked = true;
                        break;
                    case Keys.D4:
                        this.screen_layer4.Checked = true;
                        break;
                    case Keys.D5:
                        this.screen_layer5.Checked = true;
                        break;
                    case Keys.D6:
                        this.screen_layer6.Checked = true;
                        break;
                    case Keys.D7:
                        this.screen_layer7.Checked = true;
                        break;
                }
            };

            this.screen_comboPatterns.Items.Add("");
            this.screen_comboPatterns.SelectedIndex = 0;
            // TODO move to function
            this.screen_buttonEditPattern.Click += delegate {
                if(editingPattern == null) {
                    this.screen_tilesetA.Enabled = false;
                    this.screen_tilesetB.Enabled = false;
                    this.screen_gradient.Enabled = false;
                    this.screen_music.Enabled = false;
                    this.screen_ambiA.Enabled = false;
                    this.screen_ambiB.Enabled = false;
                    this.screen_comboPatterns.DropDownStyle = ComboBoxStyle.Simple;
                    this.screen_buttonEditPattern.Text = "Save";
                    this.screen_mainView.Resizable = true;
                    if(this.screen_comboPatterns.SelectedIndex <= 0) {
                        editingPattern = new Pattern(GetActiveLayer());
                        newPattern = true;
                        for(int i = 0; i < 8; i++) {
                            layerSelectors[i].Item2.Enabled = layerSelectors[i].Item1.Checked;
                        }
                    }
                    else {
                        editingPattern = this.story.Patterns[this.screen_comboPatterns.SelectedIndex - 1];
                        this.screen_mainView.Size = new Size(editingPattern.Width * 24 + 2, editingPattern.Height * 24 + 2);
                        for(int i = 0; i < 8; i++) {
                            layerSelectors[i].Item2.Enabled = editingPattern.Layers[i].Active;
                        }
                    }
                    this.screen_checkBoxOverwrite.Visible = true;
                    this.screen_checkBoxOverwrite.Checked = editingPattern.Overwrite;
                    this.screen_mainView.Draw();
                }
                else {
                    if(this.screen_comboPatterns.Text == "" &&
                        MessageBox.Show("Please enter a name for your pattern, or press Cancel to discard.", "Enter Pattern Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                        return;
                    }
                    if(this.screen_comboPatterns.Text != "") {
                        editingPattern.Name = this.screen_comboPatterns.Text;
                        if(newPattern) {
                            this.story.Patterns.Add(editingPattern);
                            this.screen_comboPatterns.Items.Add(editingPattern.Name);
                            this.screen_comboPatterns.SelectedIndex = this.screen_comboPatterns.Items.Count - 1;
                        }
                        else {
                            this.screen_comboPatterns.Items[this.story.Patterns.IndexOf(editingPattern) + 1] = editingPattern.Name;
                            this.screen_buttonEditPattern.Text = "Edit";
                        }
                        ((PatternTool)tools[4]).Source = editingPattern;
                    }
                    else {
                        this.screen_comboPatterns.SelectedIndex = 0;
                    }
                    newPattern = false;
                    this.screen_tilesetA.Enabled = true;
                    this.screen_tilesetB.Enabled = true;
                    this.screen_gradient.Enabled = true;
                    this.screen_music.Enabled = true;
                    this.screen_ambiA.Enabled = true;
                    this.screen_ambiB.Enabled = true;
                    this.screen_comboPatterns.DropDownStyle = ComboBoxStyle.DropDown;
                    this.screen_mainView.Resizable = false;
                    this.screen_mainView.Size = new Size(Metrics.ScreenWidthPx + 2, Metrics.ScreenHeightPx + 2);
                    for(int i = 0; i < 8; i++) {
                        layerSelectors[i].Item2.Enabled = this.screen.Layers[i].Active;
                    }
                    this.screen_checkBoxOverwrite.Visible = false;
                    editingPattern = null;
                    this.screen_mainView.Draw();
                }
            };
            this.screen_comboPatterns.SelectedIndexChanged += delegate {
                if(this.screen_comboPatterns.SelectedIndex == 0) {
                    this.screen_buttonEditPattern.Text = "New";
                    ((PatternTool)tools[4]).Source = null;
                }
                else if(editingPattern == null) {
                    this.screen_buttonEditPattern.Text = "Edit";
                    ((PatternTool)tools[4]).Source = this.story.Patterns[this.screen_comboPatterns.SelectedIndex - 1];
                }
            };
            this.screen_checkBoxOverwrite.CheckedChanged += delegate {
                editingPattern.Overwrite = this.screen_checkBoxOverwrite.Checked;
            };

            this.selection = this.screen_tilesetViewA.Selection;
            this.screen_tilesetViewA.Active = true;

            tools = new List<EditingTool>(5);
            tools.Add(new PaintTool());
            tools.Add(new FillTool());
            tools.Add(new ReplaceTool());
            tools.Add(new RandomizeTool());
            tools.Add(new PatternTool());
            currentTool = tools[0];
        }
        public void StoryChanged(Story story) {
            this.story = story;

            this.screen_bankList.SelectedIndex = 0;
            this.screen_comboPatterns.Items.Clear();
            this.screen_comboPatterns.Items.Add("");
            this.screen_comboPatterns.SelectedIndex = 0;
            // TODO exit pattern mode
            foreach(Pattern p in this.story.Patterns) {
                this.screen_comboPatterns.Items.Add(p.Name);
            }
        }
        public void ScreenChanged(Screen screen) {
            this.screen = screen;

            this.changingScreen = true;
            this.screen_tilesetA.Value = this.screen.TilesetA;
            this.screen_tilesetB.Value = this.screen.TilesetB;
            this.screen_gradient.Value = this.screen.Gradient;
            this.screen_ambiA.Value = this.screen.AmbianceA;
            this.screen_ambiB.Value = this.screen.AmbianceB;
            this.screen_music.Value = this.screen.Music;

            TilesetA = this.story.CreateTileset(this.screen.TilesetA);
            TilesetB = this.story.CreateTileset(this.screen.TilesetB);
            Gradient = Program.LoadBitmap(this.story.Gradient(this.screen.Gradient));
            this.screen_tilesetViewA.Image = (Image)TilesetA.Full.Clone();
            this.screen_tilesetViewB.Image = (Image)TilesetB.Full.Clone();

            this.screen_mainView.Draw();
            this.changingScreen = false;
        }
        public void TabOpened() {
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            return false;
        }
        public void ProfileChanged() {
            this.screen_bankList.Items.Clear();
            foreach(ObjectBank b in Program.Banks) {
                this.screen_bankList.Items.Add(b.Index + ". " + b.Name);
            }
            this.screen_bankList.SelectedIndex = 0;

            this.screen_mainView.Draw();
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
            this.screen.TilesetA = (int)this.screen_tilesetA.Value;
            TilesetA = this.story.CreateTileset((int)this.screen_tilesetA.Value);
            this.screen_tilesetViewA.Image = (Image)TilesetA.Full.Clone();
            this.screen_mainView.Draw();
        }

        private void tilesetB_ValueChanged(object sender, EventArgs e) {
            if(Program.ChangingStory || this.changingScreen) return;
            TimerB.Stop();
            TimerB.Start();
        }
        private void ChangeTilesetB(object sender, System.Timers.ElapsedEventArgs e) {
            this.screen.TilesetB = (int)this.screen_tilesetB.Value;
            TilesetB = this.story.CreateTileset((int)this.screen_tilesetB.Value);
            this.screen_tilesetViewB.Image = (Image)TilesetB.Full.Clone();
            this.screen_mainView.Draw();
        }

        private void gradient_ValueChanged(object sender, EventArgs e) {
            if(Program.ChangingStory || this.changingScreen) return;
            TimerGrad.Stop();
            TimerGrad.Start();
        }

        private void ChangeGradient(object sender, System.Timers.ElapsedEventArgs e) {
            this.screen.Gradient = (int)this.screen_gradient.Value;
            Gradient = Program.LoadBitmap(this.story.Gradient((int)this.screen_gradient.Value));
            this.screen_mainView.Draw();
        }

        private void bankList_SelectedIndexChanged(object sender, EventArgs e) {
            ObjectBank bank = Program.Banks.ByAbsoluteIndex(this.screen_bankList.SelectedIndex);
            this.screen_objectList.Items.Clear();
            this.screen_objectList.LargeImageList.Images.Clear();
            this.screen_objectList.Items.Add("0");
            for(int i = 1; i < bank.Count; i++) {
                Tuple<int, Bitmap> t = bank.ByAbsoluteIndex(i);
                if(t.Item2 != null) {
                    this.screen_objectList.LargeImageList.Images.Add(t.Item2);
                    this.screen_objectList.Items.Add(t.Item1.ToString(), i - 1);
                }
                else this.screen_objectList.Items.Add(t.Item1.ToString());
            }
            this.screen_objectList.SelectedIndices.Clear();
            this.screen_objectList.SelectedIndices.Add(0);
        }

        private void layerSelector_MouseUp(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right) {
                int i = (int)((RadioButton)sender).Tag;
                layerSelectors[i].Item2.Enabled = !layerSelectors[i].Item2.Enabled;
                if(editingPattern == null) {
                    this.screen.Layers[i].Active = layerSelectors[i].Item2.Enabled;
                }
                else {
                    editingPattern.Layers[i].Active = layerSelectors[i].Item2.Enabled;
                }
                this.screen_mainView.Draw();
            }
        }
            
    }

}
