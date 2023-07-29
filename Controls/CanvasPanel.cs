using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Story_Crafter.Editing;
using Story_Crafter.Editing.Tools;
using Story_Crafter.Knytt;
using Story_Crafter.Rendering;

namespace Story_Crafter.Controls {
    class CanvasPanel: PictureBox {

        public delegate ICanvas GetCanvasCallback();
        public delegate Layer GetLayerCallback();
        public delegate IEditingTool GetToolCallback();
        public delegate Selection GetSelectionCallback();
        public delegate Size GetBrushSizeCallback();
        public delegate int GetTilesetIndexCallback();
        public delegate Tuple<int, int> GetObjectCallback();
        public delegate Tileset GetTilesetCallback();
        public delegate Bitmap GetGradientCallback();

        public GetCanvasCallback GetCanvas { get; set; }
        public GetLayerCallback GetLayer { get; set; }
        public GetToolCallback GetTool { get; set; }
        public GetSelectionCallback GetSelection { get; set; }
        public GetBrushSizeCallback GetBrushSize { get; set; }
        public GetTilesetIndexCallback GetTilesetIndex { get; set; }
        public GetObjectCallback GetObject { get; set; }
        public GetTilesetCallback GetTilesetA { get; set; }
        public GetTilesetCallback GetTilesetB { get; set; }
        public GetGradientCallback GetGradient { get; set; }

        public bool Resizable { get; set; } = false;

        bool resizing = false;
        bool hover = false;
        Point lastPaintLocation = new Point();
        bool painting = false;
        bool waitingToDraw = false;
        DateTime lastDrawn;

        Point hoverPosition = new Point();
        Pen tileCursor = new Pen(Color.Orange);

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

            if(Resizable && e.Button == MouseButtons.Left && this.Cursor == Cursors.SizeNWSE) {
                resizing = true;
                Refresh();
                return;
            }

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

            hoverPosition.X = (int)(e.X / Metrics.TileSizef);
            hoverPosition.Y = (int)(e.Y / Metrics.TileSizef);

            if(resizing) {
                if(hoverPosition.X < 0)
                    hoverPosition.X = 0;
                else if(hoverPosition.X >= Metrics.ScreenWidth)
                    hoverPosition.X = Metrics.ScreenWidth - 1;
                if(hoverPosition.Y < 0)
                    hoverPosition.Y = 0;
                else if(hoverPosition.Y >= Metrics.ScreenHeight)
                    hoverPosition.Y = Metrics.ScreenHeight - 1;
                this.Width = (hoverPosition.X + 1) * Metrics.TileSize + 2;
                this.Height = (hoverPosition.Y + 1) * Metrics.TileSize + 2;
                Refresh();
                return;
            }

            if(Resizable && e.X >= this.Width - 19 && e.Y >= this.Height - 19 + (this.Width - e.X)) {
                this.Cursor = Cursors.SizeNWSE;
            }
            else {
                this.Cursor = Cursors.Default;
            }

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

            if(resizing) {
                resizing = false;
                GetCanvas().Resize(hoverPosition.X + 1, hoverPosition.Y + 1);
                return;
            }

            if(e.Button == MouseButtons.Left) {
                if(waitingToDraw) {
                    Draw();
                }
                painting = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            base.OnPaint(e);

            if(hover && this.Cursor != Cursors.SizeNWSE) {
                Size brushSize = GetBrushSize();
                GetTool().DrawCursor(e.Graphics, hoverPosition, GetSelection(), brushSize.Width, brushSize.Height, GetLayer().Index);
            }
        }

        private void PaintTiles() {
            Layer layer = GetLayer();
            Size brushSize = GetBrushSize();
            if(layer.Index < 4) {
                GetTool().Paint(GetCanvas(), (TileLayer)layer, (TileSelection)GetSelection(), hoverPosition, brushSize.Width, brushSize.Height, GetTilesetIndex());
            }
            else {
                Tuple<int, int> obj = GetObject();
                GetTool().Paint(GetCanvas(), (ObjectLayer)layer, hoverPosition, brushSize.Width, brushSize.Height, obj.Item1, obj.Item2);
            }
        }

        public void Draw() {
            Image updatedScreen = new Bitmap(Metrics.ScreenWidthPx, Metrics.ScreenHeightPx);
            GetCanvas().Draw(Graphics.FromImage(updatedScreen), GetTilesetA(), GetTilesetB(), GetGradient());
            this.Image = updatedScreen;
        }

    }
}
