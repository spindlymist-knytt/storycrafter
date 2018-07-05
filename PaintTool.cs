using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    class PaintTool: EditingTool {

        public override string Name { get { return "Paint"; } }

        public override void Paint(TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            for(int brushX = 0; brushX < brushSizeX; brushX++) {
                for(int brushY = 0; brushY < brushSizeY; brushY++) {
                    selection.Paint(layer, tileset, paintLocation.X + brushX * selection.Width, paintLocation.Y + brushY * selection.Height);
                }
            }
        }
        public override void Paint(ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
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

    }
}
