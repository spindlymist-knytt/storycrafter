using Story_Crafter.Knytt;
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
                tiles = new Bitmap[Metrics.TilesetWidth * Metrics.TilesetHeight];
                Bitmap tileset = new Bitmap(GetTilesetPath(index));
                Rectangle source = new Rectangle(0, 0, Metrics.TileSize, Metrics.TileSize);
                Rectangle dest = new Rectangle(0, 0, Metrics.TileSize, Metrics.TileSize);

                int i = 0;
                for (int y = 0; y < Metrics.TilesetHeight; y++) {
                    for (int x = 0; x < Metrics.TilesetWidth; x++) {
                        Bitmap tile = new Bitmap(Metrics.TileSize, Metrics.TileSize);
                        Graphics.FromImage(tile).DrawImage(tileset, dest, source, GraphicsUnit.Pixel);
                        tile.MakeTransparent(Color.Magenta);
                        tiles[i++] = tile;
                        source.X += Metrics.TileSize;
                    }
                    source.X = 0;
                    source.Y += Metrics.TileSize;
                }

                tilesetCache.Add(index, tiles);
            }

            return tiles;
        }

        public Bitmap LoadGradient(int index) {
            Bitmap gradient;
            gradientCache.TryGetValue(index, out gradient);

            if (gradient == null) {
                gradient = new Bitmap(GetGradientPath(index));
                gradientCache.Add(index, gradient);
            }

            return gradient;
        }
    }
}
