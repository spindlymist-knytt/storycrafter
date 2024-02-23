using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

using Story_Crafter.Rendering;
using Story_Crafter.Knytt;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls {
    public class DrawTest : MonoGame.Forms.NET.Controls.MonoGameControl {
        struct CachedTexture {
            public RenderTarget2D Target;
            public bool IsDirty;
        }

        public Screen Screen {
            get { return screen; }
            set {
                screen = value;
                if (isInitialized) {
                    UpdateScreenData(screen);
                }
            }
        }
        Screen screen;

        RenderingContext renderContext;
        bool isInitialized = false;

        Camera camera = new Camera();
        TilemapMesh tileMesh;
        TilemapShader shader;
        Texture2D gradient;

        CachedTexture tileLayers;
        CachedTexture objectLayers;
        CachedTexture screenTexture;

        bool isMouseDown = false;
        System.Drawing.Point initialMousePos;
        Vector2 initialCameraPos;

        public DrawTest(RenderingContext renderContext) {
            this.renderContext = renderContext;
        }

        protected override void Initialize() {
            Components.Clear();

            tileLayers = new CachedTexture {
                Target = new RenderTarget2D(Editor.GraphicsDevice, 600, 240),
                IsDirty = false,
            };
            objectLayers = new CachedTexture {
                Target = new RenderTarget2D(Editor.GraphicsDevice, 600, 240),
                IsDirty = false,
            };
            screenTexture = new CachedTexture {
                Target = new RenderTarget2D(Editor.GraphicsDevice, 600, 240),
                IsDirty = false,
            };

            tileMesh = new TilemapMesh(Metrics.ScreenWidth, Metrics.ScreenHeight);
            shader = renderContext.CreateTilemapShader(Metrics.ScreenWidth, Metrics.ScreenHeight);

            if (screen != null) {
                UpdateScreenData(screen);
            }

            isInitialized = true;
        }

        public void UpdateScreenData(Screen screen) {
            if (screen == null) return;

            shader.UpdateAssets(screen.TilesetA, screen.TilesetB);
            shader.UpdateTileData(screen.RawData);
            gradient = renderContext.LoadGradient((uint) screen.Gradient);

            tileLayers.IsDirty = true;
            objectLayers.IsDirty = true;
            screenTexture.IsDirty = tileLayers.IsDirty || objectLayers.IsDirty;
        }

        protected override void Update(GameTime gameTime) {
        }

        protected override void Draw() {
            UpdateCachedTextures();

            Editor.spriteBatch.Begin(
                samplerState: new SamplerState {
                    Filter = TextureFilter.Point,
                },
                transformMatrix: camera.Matrix);
            Editor.spriteBatch.Draw(screenTexture.Target, Vector2.Zero, Color.White);
            Editor.spriteBatch.End();
        }

        void UpdateCachedTextures() {
            if (!screenTexture.IsDirty) return;

            if (tileLayers.IsDirty) {
                DrawTileLayers(tileLayers.Target);
                tileLayers.IsDirty = false;
            }

            if (objectLayers.IsDirty) {
                DrawObjectLayers(objectLayers.Target);
                objectLayers.IsDirty = false;
            }

            DrawScreenTexture(screenTexture.Target);
            Editor.GraphicsDevice.SetRenderTarget(Editor.SwapChainRenderTarget);
        }

        protected void DrawTileLayers(RenderTarget2D target) {
            Editor.GraphicsDevice.SetRenderTarget(target);
            Editor.GraphicsDevice.Clear(Color.Transparent);
            shader.Begin();
            tileMesh.Draw(Editor.GraphicsDevice);
            shader.End();
        }

        static BlendState blendState = new BlendState {
            ColorSourceBlend = Blend.SourceAlpha,
            ColorDestinationBlend = Blend.InverseSourceAlpha,
            AlphaSourceBlend = Blend.One,
            AlphaDestinationBlend = Blend.InverseSourceAlpha,
        };

        void DrawObjectLayers(RenderTarget2D target) {
            Editor.GraphicsDevice.SetRenderTarget(target);
            Editor.GraphicsDevice.Clear(Color.Transparent);
            Editor.spriteBatch.Begin(blendState: blendState);

            Vector2 position = Vector2.Zero;
            for (int layer = 4; layer < 8; layer++) {
                var tiles = screen.Layers[layer].Tiles;
                for (int y = 0, i = 0; y < 10; y++) {
                    position.Y = y * 24f;
                    for (int x = 0; x < 25; x++) {
                        var tile = tiles[i++];
                        if (tile.Index > 0) {
                            position.X = x * 24f;
                            Texture2D texture = renderContext.GetObjectTexture(tile.Bank, tile.Index);
                            Editor.spriteBatch.Draw(texture, position, Color.White);
                        }
                    }
                }
            }
            Editor.spriteBatch.End();
        }

        void DrawScreenTexture(RenderTarget2D target) {
            Editor.GraphicsDevice.SetRenderTarget(target);
            Editor.GraphicsDevice.Clear(Color.Transparent);
            Editor.spriteBatch.Begin(blendState: blendState);
            Editor.spriteBatch.Draw(gradient, target.Bounds, target.Bounds, Color.White);
            Editor.spriteBatch.Draw(tileLayers.Target, Vector2.Zero, Color.White);
            Editor.spriteBatch.Draw(objectLayers.Target, Vector2.Zero, Color.White);
            Editor.spriteBatch.End();
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            isMouseDown = true;
            initialMousePos = e.Location;
            initialCameraPos = camera.Position;
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            isMouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            if (isMouseDown) {
                float deltaX = (e.Location.X - initialMousePos.X) / camera.Zoom;
                float deltaY = (e.Location.Y - initialMousePos.Y) / camera.Zoom;
                camera.SetPosition(
                    initialCameraPos.X + deltaX,
                    initialCameraPos.Y + deltaY);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);

            float delta = e.Delta / 120;
            camera.Zoom = Math.Clamp(camera.Zoom + delta, 1f, 4f);
        }
    }
}
