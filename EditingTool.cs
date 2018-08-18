using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    abstract class EditingTool {

        abstract public string Name { get; }

        abstract public void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset);
        abstract public void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx);
        abstract public void DrawCursor(Graphics g, Point position, Selection selection, int brushSizeX, int brushSizeY, int layer);

    }
}
