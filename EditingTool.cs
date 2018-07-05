using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    abstract class EditingTool {

        abstract public string Name { get; }

        abstract public void Paint(TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset);
        abstract public void Paint(ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx);

    }
}
