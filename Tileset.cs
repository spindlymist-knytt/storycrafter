using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

namespace Story_Crafter {
    class Tileset {
        public Bitmap[] Tiles;
        public Bitmap Full;

        public Tileset(string file) {
            this.Tiles = new Bitmap[Program.TilesetWidth * Program.TilesetHeight];
            this.Full = Program.LoadBitmap(file);
            this.Full.MakeTransparent(Color.Magenta);
            for(int y = 0; y < Program.TilesetHeight; y++) {
                for(int x = 0; x < Program.TilesetWidth; x++) {
                    Bitmap tile = new Bitmap(24, 24);
                    Graphics.FromImage(tile).DrawImage(this.Full, new Rectangle(0, 0, 24, 24), new Rectangle(x * 24, y * 24, 24, 24), GraphicsUnit.Pixel);
                    tile.MakeTransparent(Color.Magenta);
                    this.Tiles[y * Program.TilesetWidth + x] = tile;
                }
            }
        }
    }
}
