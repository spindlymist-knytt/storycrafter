using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Story_Crafter.Rendering {
    class AssetManager {
        IDictionary<int, Bitmap[]> tilesetCache = new Dictionary<int, Bitmap[]>();
        IDictionary<int, Bitmap> gradientCache = new Dictionary<int, Bitmap>();

        string dataPath;
        string worldPath;

        public AssetManager(string dataPath, string worldPath) {
            this.dataPath = dataPath;
            this.worldPath = worldPath;
        }

        public string GetTilesetPath(int index) {
            string suffix = string.Format(@"\Tilesets\Tileset{0}.png", index);
            string guess = this.worldPath + suffix;

            if (File.Exists(guess)) {
                return guess;
            }
            else {
                return this.dataPath + suffix;
            }
        }

        public string GetGradientPath(int index) {
            string suffix = string.Format(@"\Gradients\Gradient{0}.png", index);
            string guess = this.worldPath + suffix;

            if (File.Exists(guess)) {
                return guess;
            }
            else {
                return this.dataPath + suffix;
            }
        }

        public Bitmap[] LoadTileset(int index) {
            Bitmap[] tiles;
            tilesetCache.TryGetValue(index, out tiles);

            if (tiles == null) {
                tiles = new Bitmap[Program.TilesetWidth * Program.TilesetHeight];
                Bitmap tileset = Program.LoadBitmap(GetTilesetPath(index));
                Rectangle source = new Rectangle(0, 0, 24, 24);
                Rectangle dest = new Rectangle(0, 0, 24, 24);

                int i = 0;
                for (int y = 0; y < Program.TilesetHeight; y++) {
                    for (int x = 0; x < Program.TilesetWidth; x++) {
                        Bitmap tile = new Bitmap(24, 24);
                        Graphics.FromImage(tile).DrawImage(tileset, dest, source, GraphicsUnit.Pixel);
                        tile.MakeTransparent(Color.Magenta);
                        tiles[i++] = tile;
                        source.X += 24;
                    }
                    source.X = 0;
                    source.Y += 24;
                }

                tilesetCache.Add(index, tiles);
            }

            return tiles;
        }

        public Bitmap LoadGradient(int index) {
            Bitmap gradient;
            gradientCache.TryGetValue(index, out gradient);

            if (gradient == null) {
                gradient = Program.LoadBitmap(GetGradientPath(index));
                gradientCache.Add(index, gradient);
            }

            return gradient;
        }
    }
}
