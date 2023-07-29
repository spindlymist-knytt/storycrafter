using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Crafter.Editing.Tools {
    interface IEditingTool {
        string Name { get; }

        void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset);
        void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx);
        void DrawCursor(Graphics g, Point position, Selection selection, int brushSizeX, int brushSizeY, int layer);
    }
}
