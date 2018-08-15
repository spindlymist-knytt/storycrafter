using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    class TileSelection: Selection {

        public TileSelection(int cellWidth, int cellHeight, int containerMaxX, int containerMaxY, Pen cursor) : base(cellWidth, cellHeight, containerMaxX, containerMaxY, cursor) { }

        public void Paint(Layer l, int tileset, int paintX, int paintY) {
            paintX -= MinX;
            paintY -= MinY;
            foreach(SelectionNode n in nodes) {
                int x = paintX + n.X;
                int y = paintY + n.Y;
                if(x < 0 || x > Program.ScreenWidth - 1 || y < 0 || y > Program.ScreenHeight - 1) continue;
                l.Tiles[Program.ScreenPointToIndex(x, y)].Set(tileset, n.TileIndex);
            }
        }

    }
}
