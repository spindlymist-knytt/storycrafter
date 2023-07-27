using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Rendering {
    class GDIRenderer {
        AssetManager assetManager;

        public GDIRenderer(AssetManager assetManager) {
            this.assetManager = assetManager;
        }

        public void Render(Screen screen, Graphics g) {
            Bitmap[] tilesetA = assetManager.LoadTileset(screen.TilesetA);
            Bitmap[] tilesetB = assetManager.LoadTileset(screen.TilesetB);
            Bitmap gradient = assetManager.LoadGradient(screen.Gradient);

            // Render background
            for (int x = 0; x < Metrics.ScreenWidthPx; x += gradient.Width) {
                g.DrawImage(gradient, x, 0, gradient.Width, gradient.Height);
            }

            // Render tiles
            int i = 0;
            for (int y = 0; y < Metrics.ScreenHeightPx; y += Metrics.TileSize) {
                for (int x = 0; x < Metrics.ScreenWidthPx; x += Metrics.TileSize) {
                    for (int offset = 0; offset < 1000; offset += 250) {
                        byte tileIndex = screen.RawData[offset + i];
                        if (tileIndex > 0) {
                            Bitmap tile = tileIndex < 128 ? tilesetA[tileIndex] : tilesetB[tileIndex];
                            g.DrawImageUnscaled(tile, x, y);
                        }
                    }
                    i++;
                }
            }

            // Render objects
        }
    }
}
