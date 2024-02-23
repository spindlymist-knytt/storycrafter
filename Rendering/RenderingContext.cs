using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Story_Crafter.Assets;
using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Story_Crafter.Rendering {
    public class RenderingContext {
        public GraphicsDevice GraphicsDevice {
            get { return graphics; }
        }

        public ContentManager Content {
            get { return content; }
        }

        public IAssetSource Assets {
            get { return assets; }
            set {
                assets = value;
                UploadTilesets();
                UploadObjects();
            }
        }
        IAssetSource assets;

        GraphicsDevice graphics;
        ContentManager content;
        Texture2D tilesetsArray;
        Texture2D[] gradients = new Texture2D[256];
        Texture2D[] objectTextures = new Texture2D[256 * 256];

        public RenderingContext(GraphicsDevice graphics, ContentManager content) {
            this.graphics = graphics;
            this.content = content;
            this.content.RootDirectory = "Resources";

            // Override capabilities
            {
                var prop = graphics.GetType()
                    .GetProperty("GraphicsCapabilities", BindingFlags.NonPublic | BindingFlags.Instance);
                var capabilities = prop.GetValue(graphics);

                prop = capabilities.GetType()
                    .GetProperty("SupportsVertexTextures", BindingFlags.NonPublic | BindingFlags.Instance);
                prop.SetValue(capabilities, true);

                prop = capabilities.GetType()
                    .GetProperty("SupportsTextureArrays", BindingFlags.NonPublic | BindingFlags.Instance);
                prop.SetValue(capabilities, true);
            }

            tilesetsArray = new Texture2D(
                graphics,
                Metrics.TilesetWidthPx,
                Metrics.TilesetHeightPx,
                false,
                SurfaceFormat.Color,
                256);
        }

        public void Initialize() { }

        public Texture2D LoadGradient(uint index) {
            Texture2D texture = gradients[index];

            if (texture != null) {
                return texture;
            }

            Image image = assets.GradientRGBA(index);
            texture = new Texture2D(graphics, image.Width, image.Height, false, SurfaceFormat.Color);
            texture.SetData(image.Data);

            gradients[index] = texture;

            return texture;
        }

        public TilemapShader CreateTilemapShader(int width, int height) {
            return new TilemapShader(this, width, height, tilesetsArray);
        }

        void UploadTilesets() {
            Rectangle rect = new Rectangle(0, 0, Metrics.TilesetWidthPx, Metrics.TilesetHeightPx);
            for (int i = 0; i < 256; i++) {
                Image image = assets.TilesetRGBA((uint) i);
                tilesetsArray.SetData(0, i, rect, image.Data, 0, image.Data.Length);
            }
        }

        void UploadObjects() {
            foreach (var bank in Program.Banks) {
                int baseIndex = 256 * bank.Index;

                foreach (var obj in bank) {
                    if (obj.Item1 == 0) continue;

                    Image image = assets.ObjectRGBA((uint) bank.Index, (uint) obj.Item1);
                    Texture2D texture = new Texture2D(graphics, image.Width, image.Height, false, SurfaceFormat.Color);
                    texture.SetData(image.Data);
                    objectTextures[baseIndex + obj.Item1] = texture;
                }
            }
        }

        public Texture2D GetObjectTexture(int bank, int obj) {
            return objectTextures[bank * 256 + obj];
        }
    }
}
