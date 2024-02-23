using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Controls {
    public interface ITileCanvasEvents {
        bool OnKeyDown(TileCanvas sender, KeyEventArgs e);
        bool OnKeyPress(TileCanvas sender, KeyPressEventArgs e);
        bool OnKeyUp(TileCanvas sender, KeyEventArgs e);
        bool OnMouseDown(TileCanvas sender, MouseEventArgs e);
        bool OnMouseUp(TileCanvas sender, MouseEventArgs e);
        bool OnMouseClick(TileCanvas sender, MouseEventArgs e);
        bool OnMouseDoubleClick(TileCanvas sender, MouseEventArgs e);
        bool OnMouseWheel(TileCanvas sender, MouseEventArgs e);
        bool OnMouseEnter(TileCanvas sender, EventArgs e);
        bool OnMouseMove(TileCanvas sender, MouseEventArgs e);
        bool OnMouseMoveUnique(TileCanvas sender, MouseEventArgs e);
        bool OnMouseLeave(TileCanvas sender, EventArgs e);
        void OnPaint(TileCanvas sender, PaintEventArgs e);
    }
}
