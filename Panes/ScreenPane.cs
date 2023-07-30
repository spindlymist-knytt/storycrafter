using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Story_Crafter.Editing;
using Story_Crafter.Editing.Tools;
using Story_Crafter.Rendering;
using Screen = Story_Crafter.Knytt.Screen;
using Story_Crafter.Knytt;

namespace Story_Crafter.Panes {
    partial class ScreenPane : DockContent {
        EditingContext context;
        Tileset tilesetA;
        Tileset tilesetB;
        Bitmap gradient;
        Screen screen;
        int scale = 1;

        public ScreenPane(EditingContext context, Screen screen) {
            this.context = context;
            this.screen = screen;

            InitializeComponent();

            this.context.ActiveScreenChanged += OnActiveScreenChanged;
            this.canvasPanel1.GetCanvas += delegate () {
                return this.screen;
            };
            this.canvasPanel1.GetLayer += delegate () {
                return this.screen?.GetLayer(3);
            };
            this.canvasPanel1.GetTool += delegate () {
                return this.context.Tool;
            };
            this.canvasPanel1.GetSelection += delegate () {
                return this.context.TilesetSelection?.Item2;
            };
            this.canvasPanel1.GetBrushSize += delegate () {
                return new Size(1, 1);
            };
            this.canvasPanel1.GetTilesetIndex += delegate () {
                return this.context.TilesetSelection?.Item1 ?? 0;
            };
            this.canvasPanel1.GetObject += delegate () {
                return new Tuple<int, int>(0, 0);
            };
            this.canvasPanel1.GetTilesetA += delegate () {
                return tilesetA;
            };
            this.canvasPanel1.GetTilesetB += delegate () {
                return tilesetB;
            };
            this.canvasPanel1.GetGradient += delegate () {
                return gradient;
            };

            if (screen != null) {
                this.Text = "x" + screen.X + "y" + screen.Y;
                tilesetA = this.context.Story.CreateTileset(screen.TilesetA);
                tilesetB = this.context.Story.CreateTileset(screen.TilesetB);
                gradient = Program.LoadBitmap(this.context.Story.Gradient(screen.Gradient));
                this.canvasPanel1.Draw();
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);

            if (this.screen != null) {
                this.context.ActiveScreen = this.screen;
            }
        }

        void OnActiveScreenChanged(ActiveScreenChangedArgs e) {
            if (this.screen == null) {
                this.screen = e.screen;
                this.Text = "x" + screen.X + "y" + screen.Y;
                tilesetA = this.context.Story.CreateTileset(screen.TilesetA);
                tilesetB = this.context.Story.CreateTileset(screen.TilesetB);
                gradient = Program.LoadBitmap(this.context.Story.Gradient(screen.Gradient));
                this.canvasPanel1.Draw();
            }
        }

        private void menuItem_setZoom100_Click(object sender, EventArgs e) {
            scale = 1;
            this.canvasPanel1.Size = new Size(600 * scale, 240 * scale);
        }

        private void menuItem_setZoom200_Click(object sender, EventArgs e) {
            scale = 2;
            this.canvasPanel1.Size = new Size(600 * scale, 240 * scale);
        }

        private void menuItem_setZoom300_Click(object sender, EventArgs e) {
            scale = 3;
            this.canvasPanel1.Size = new Size(600 * scale, 240 * scale);
        }
    }
}
