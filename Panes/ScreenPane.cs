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

namespace Story_Crafter.Panes {
    public partial class ScreenPane : DockContent, IEditorPane {
        Tileset tilesetA;
        Tileset tilesetB;
        Bitmap gradient;
        TileSelection selection;
        Screen screen;
        int scale = 1;

        public ScreenPane() {
            InitializeComponent();

            selection = new TileSelection(24, 24, 0, 0, Program.TilesetWidth, Program.TilesetHeight, new Pen(Color.Orange));
            selection.Add(new Rectangle(0, 0, 1, 1));

            this.canvasPanel1.GetCanvas += delegate () {
                return this.screen;
            };
            this.canvasPanel1.GetLayer += delegate () {
                return this.screen.GetLayer(3);
            };
            this.canvasPanel1.GetTool += delegate () {
                return new PaintTool();
            };
            this.canvasPanel1.GetSelection += delegate () {
                return selection;
            };
            this.canvasPanel1.GetBrushSize += delegate () {
                return new Size(1, 1);
            };
            this.canvasPanel1.GetTilesetIndex += delegate () {
                return 0;
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
        }

        void IEditorPane.ChangeScreen(Screen screen) {
            if (this.screen == null) {
                this.screen = screen;
                this.Text = "x" + screen.X + "y" + screen.Y;
                tilesetA = Program.OpenStory.CreateTileset(screen.TilesetA);
                tilesetB = Program.OpenStory.CreateTileset(screen.TilesetB);
                gradient = Program.LoadBitmap(Program.OpenStory.Gradient(screen.Gradient));
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
