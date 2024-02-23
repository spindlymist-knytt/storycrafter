using Story_Crafter.Controls;
using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Editing.Tools {
    public interface IEditingTool {
        string Name { get; }
        //ICanvas Target { get; set; }
        ITileCanvasEvents EventsHandler { get; }

        void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset);
        void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx);
    }
}
