using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    interface ICanvas {

        // TODO make class that is member of Fragment and Screen rather than interface
        void Draw(Graphics g, Tileset a, Tileset b, Bitmap gradient); // TODO get layer mask from caller
        void Resize(int width, int height);
        Layer GetLayer(int idx);

    }
}
