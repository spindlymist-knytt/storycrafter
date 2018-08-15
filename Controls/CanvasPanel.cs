using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Story_Crafter.Controls {
    class CanvasPanel: PictureBox {

        public delegate Layer GetLayerCallback();
        public delegate EditingTool GetToolCallback();
        public delegate Selection GetSelectionCallback();
        public delegate Size GetBrushSizeCallback();
        public delegate int GetTilesetCallback();
        public delegate Tuple<int, int> GetObjectCallback();

        bool hover = false;
        Point lastPaintLocation = new Point();
        bool painting = false;
        bool waitingToDraw = false;
        DateTime lastDrawn;

        Point hoverPosition = new Point();
        Pen tileCursor = new Pen(Color.Orange);

        public GetLayerCallback GetLayer { get; set; }
        public GetToolCallback GetTool { get; set; }
        public GetSelectionCallback GetSelection { get; set; }
        public GetBrushSizeCallback GetBrushSize { get; set; }
        public GetTilesetCallback GetTileset { get; set; }
        public GetObjectCallback GetObject { get; set; }

        public CanvasPanel() { }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            hover = true;
        }

        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            hover = false;
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
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

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
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
                Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            if(e.Button == MouseButtons.Left) {
                if(waitingToDraw) {
                    Draw();
                }
                painting = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if(hover) {
                Size brushSize = GetBrushSize();
                GetTool().DrawCursor(e.Graphics, hoverPosition, GetSelection(), brushSize.Width, brushSize.Height, GetLayer().Index);
            }
        }

        private void PaintTiles() {
            Layer layer = GetLayer();
            Size brushSize = GetBrushSize();
            if(layer.Index < 4) {
                GetTool().Paint((TileLayer)layer, (TileSelection)GetSelection(), hoverPosition, brushSize.Width, brushSize.Height, GetTileset());
            }
            else {
                Tuple<int, int> obj = GetObject();
                GetTool().Paint((ObjectLayer)layer, hoverPosition, brushSize.Width, brushSize.Height, obj.Item1, obj.Item2);
            }
        }

        private void Draw() {
            Image updatedScreen = new Bitmap(Program.PxScreenWidth, Program.PxScreenHeight);
            Program.OpenStory.ActiveScreen.Draw(Graphics.FromImage(updatedScreen)); // TODO generalize
            this.Image = updatedScreen;
        }

    }
}
