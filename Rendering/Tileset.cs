using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

namespace Story_Crafter.Rendering {
    public class Tileset {
        public Bitmap[] Tiles;
        public Bitmap Full;

        public Tileset(string file) {
            this.Tiles = new Bitmap[Metrics.TilesetWidth * Metrics.TilesetHeight];
            this.Full = Program.LoadBitmap(file);
            this.Full.MakeTransparent(Color.Magenta);
            for(int y = 0; y < Metrics.TilesetHeight; y++) {
                for(int x = 0; x < Metrics.TilesetWidth; x++) {
                    Bitmap tile = new Bitmap(Metrics.TileSize, Metrics.TileSize);
                    Graphics.FromImage(tile).DrawImage(
                        this.Full,
                        new Rectangle(0, 0, Metrics.TileSize, Metrics.TileSize),
                        new Rectangle(x * Metrics.TileSize, y * Metrics.TileSize, Metrics.TileSize, Metrics.TileSize),
                        GraphicsUnit.Pixel);
                    tile.MakeTransparent(Color.Magenta);
                    this.Tiles[y * Metrics.TilesetWidth + x] = tile;
                }
            }
        }
    }
}
