using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Knytt;
using Story_Crafter.Rendering;

namespace Story_Crafter.Editing {
    public interface ICanvas {

        // TODO make class that is member of Fragment and Screen rather than interface
        void Draw(Graphics g, Tileset a, Tileset b, Bitmap gradient); // TODO get layer mask from caller
        void Resize(int width, int height);
        Layer GetLayer(int idx);

    }
}
