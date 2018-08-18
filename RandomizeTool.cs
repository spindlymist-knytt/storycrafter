using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    class RandomizeTool: EditingTool {

        public override string Name { get { return "Randomize"; } }

        Pen cursor = new Pen(Color.Orchid);

        public override void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            for(int brushX = 0; brushX < brushSizeX; brushX++) {
                for(int brushY = 0; brushY < brushSizeY; brushY++) {
                    int x = paintLocation.X + brushX;
                    int y = paintLocation.Y + brushY;
                    if(x < 0 || x >= Program.ScreenWidth || y < 0 || y >= Program.ScreenHeight) continue;
                    int i = y * Program.ScreenWidth + x;
                    layer.Tiles[i].Set(tileset, selection.RandomNode());
                }
            }
        }

        public override void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
            // Duplicates PaintTool.Paint(ObjectLayer...) behavior
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
            g.DrawRectangle(cursor, position.X * 24, position.Y * 24, 24 * brushSizeX - 1, 24 * brushSizeY - 1);
        }

    }
}
