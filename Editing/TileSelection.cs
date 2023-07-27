using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Knytt;

namespace Story_Crafter.Editing {
    class TileSelection: Selection {

        public TileSelection(int cellWidth, int cellHeight, int containerMinX, int containerMinY, int containerMaxX, int containerMaxY, Pen cursor)
            : base(cellWidth, cellHeight, containerMinX, containerMinY, containerMaxX, containerMaxY, cursor) { }

        public void Paint(Layer l, int tileset, int paintX, int paintY) {
            paintX -= MinX;
            paintY -= MinY;
            foreach(SelectionNode n in nodes) {
                int x = paintX + n.X;
                int y = paintY + n.Y;
                if(x < 0 || x > Metrics.ScreenWidth - 1 || y < 0 || y > Metrics.ScreenHeight - 1) continue;
                l.Tiles[Metrics.ScreenPointToIndex(x, y)].Set(tileset, n.TileIndex);
            }
        }

    }
}
