using Story_Crafter.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Editing.Tools {
    abstract class BaseEventsHandler : ITileCanvasEvents {
        public virtual bool OnKeyDown(TileCanvas sender, KeyEventArgs e) { return false; }
        public virtual bool OnKeyPress(TileCanvas sender, KeyPressEventArgs e) { return false; }
        public virtual bool OnKeyUp(TileCanvas sender, KeyEventArgs e) { return false; }
        public virtual bool OnMouseDown(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseUp(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseClick(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseDoubleClick(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseWheel(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseEnter(TileCanvas sender, EventArgs e) { return false; }
        public virtual bool OnMouseMove(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseMoveUnique(TileCanvas sender, MouseEventArgs e) { return false; }
        public virtual bool OnMouseLeave(TileCanvas sender, EventArgs e) { return true; }
        public virtual void OnPaint(TileCanvas sender, PaintEventArgs e) { }
    }
}
