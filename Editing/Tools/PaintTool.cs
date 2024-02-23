using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Controls;
using System.Windows.Forms;
using Story_Crafter.Knytt;
using Story_Crafter.Panes;

namespace Story_Crafter.Editing.Tools {
    struct PaintToolOptions {
        public int Layer;
        public Point BrushSize;
    }

    class PaintTool : BaseEventsHandler, IEditingTool {
        public string Name { get { return "Paint"; } }
        public PaintToolOptions Options { get; set; } = new PaintToolOptions {
            Layer = 3,
            BrushSize = new Point(1, 1),
        };
        public ITileCanvasEvents EventsHandler { get { return this; } }

        Pen objectCursor = new Pen(Color.Gold);
        EditingContext context;

        public PaintTool(EditingContext context) {
            this.context = context;
        }

        public void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            for(int brushX = 0; brushX < brushSizeX; brushX++) {
                for(int brushY = 0; brushY < brushSizeY; brushY++) {
                    selection.Paint(layer, tileset, paintLocation.X + brushX * selection.Width, paintLocation.Y + brushY * selection.Height);
                }
            }
        }

        public void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
            for(int brushX = 0; brushX < brushSizeX; brushX++) {
                for(int brushY = 0; brushY < brushSizeY; brushY++) {
                    int x = paintLocation.X + brushX;
                    int y = paintLocation.Y + brushY;
                    if(x < 0 || x >= Metrics.ScreenWidth || y < 0 || y >= Metrics.ScreenHeight) continue;
                    int i = Metrics.ScreenPointToIndex(x, y);
                    layer.Tiles[i].Bank = bank;
                    layer.Tiles[i].Index = idx;
                }
            }
        }

        public override bool OnMouseDown(TileCanvas sender, MouseEventArgs e) {
            //Paint(sender.Mouse.currentLocation);
            return true;
        }

        public override bool OnMouseMoveUnique(TileCanvas sender, MouseEventArgs e) {
            if (sender.Mouse.isDragging) {
                //Paint(sender.Mouse.currentLocation);
            }
            return true;
        }

        public override void OnPaint(TileCanvas sender, PaintEventArgs e) {
            if (!sender.Mouse.isHovering) {
                return;
            }

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Selection selection = this.context.TilesetSelection.Item2;

            if (this.Options.Layer < 4) {
                for (int x = sender.Mouse.currentLocation.X; x < sender.Mouse.currentLocation.X + this.Options.BrushSize.X * selection.Width; x += selection.Width) {
                    for (int y = sender.Mouse.currentLocation.Y; y < sender.Mouse.currentLocation.Y + this.Options.BrushSize.Y * selection.Height; y += selection.Height) {
                        e.Graphics.DrawImage(
                            selection.Borders,
                            new Rectangle((int)(x * 24 * sender.ScalingFactor), (int)(y * 24 * sender.ScalingFactor), (int)(selection.Borders.Width * sender.ScalingFactor), (int)(selection.Borders.Height * sender.ScalingFactor)),
                            new Rectangle(0, 0, (int)(selection.Borders.Width * sender.ScalingFactor), (int)(selection.Borders.Height * sender.ScalingFactor)),
                            GraphicsUnit.Pixel);
                    }
                }
            }
            else {
                e.Graphics.DrawRectangle(objectCursor, sender.Mouse.currentLocation.X * 24, sender.Mouse.currentLocation.Y * 24, 24 * this.Options.BrushSize.X - 1, 24 * this.Options.BrushSize.Y - 1);
            }
        }
    }
}
