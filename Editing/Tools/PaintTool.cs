using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Knytt;

namespace Story_Crafter.Editing.Tools {
    class PaintTool: EditingTool {

        public override string Name { get { return "Paint"; } }

        Pen objectCursor = new Pen(Color.Gold);

        public override void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            for(int brushX = 0; brushX < brushSizeX; brushX++) {
                for(int brushY = 0; brushY < brushSizeY; brushY++) {
                    selection.Paint(layer, tileset, paintLocation.X + brushX * selection.Width, paintLocation.Y + brushY * selection.Height);
                }
            }
        }

        public override void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
            for(int brushX = 0; brushX < brushSizeX; brushX++) {
                for(int brushY = 0; brushY < brushSizeY; brushY++) {
                    int x = paintLocation.X + brushX;
                    int y = paintLocation.Y + brushY;
                    if(x < 0 || x >= Program.ScreenWidth || y < 0 || y >= Program.ScreenHeight) continue;
                    int i = Program.ScreenPointToIndex(x, y);
                    layer.Tiles[i].Bank = bank;
                    layer.Tiles[i].Index = idx;
                }
            }
        }

        public override void DrawCursor(Graphics g, Point position, Selection selection, int brushSizeX, int brushSizeY, int layer) {
            if(layer < 4) {
                for(int x = position.X; x < position.X + brushSizeX * selection.Width; x += selection.Width) {
                    for(int y = position.Y; y < position.Y + brushSizeY * selection.Height; y += selection.Height) {
                        g.DrawImage(selection.Borders,
                            new Rectangle(x * 24, y * 24, selection.Borders.Width, selection.Borders.Height),
                            new Rectangle(0, 0, selection.Borders.Width, selection.Borders.Height),
                            GraphicsUnit.Pixel);
                    }
                }
            }
            else g.DrawRectangle(objectCursor, position.X * 24, position.Y * 24, 24 * brushSizeX - 1, 24 * brushSizeY - 1);
        }

    }
}
