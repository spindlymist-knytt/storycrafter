using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Story_Crafter.Knytt;

namespace Story_Crafter.Rendering {
    public class TilemapShader {
        public Effect Effect {
            get { return effect; }
        }
        Effect effect;

        public Texture2D TilesetsArray {
            get { return tilesetsArray; }
            set {
                tilesetsArray = value;
                effect.Parameters["tilesets"].SetValue(tilesetsArray);
            }
        }
        Texture2D tilesetsArray;

        public Texture2D TileDataTexture {
            get { return tileData; }
        }
        Texture2D tileData;

        public Point Size {
            get { return size; }
            set { Resize(value); }
        }
        Point size;

        RenderingContext context;

        public TilemapShader(RenderingContext context, int width, int height, Texture2D tilesetsArray) {
            this.context = context;
            effect = context.Content.Load<Effect>("Effects/tilemap").Clone();
            TilesetsArray = tilesetsArray;
            Size = new Point(width, height);
        }

        public void Begin() {
            effect.CurrentTechnique.Passes[0].Apply();
        }

        public void End() { }

        public void Resize(Point size) {
            this.size = size;

            tileData?.Dispose();
            tileData = new Texture2D(
                effect.GraphicsDevice,
                size.X * size.Y,
                1,
                false,
                SurfaceFormat.Single);
            effect.Parameters["tileData"].SetValue(tileData);

            Matrix view = Matrix.CreateLookAt(Vector3.Backward, Vector3.Forward, Vector3.Up);
            Matrix proj = Matrix.CreateOrthographic(
                size.X * Metrics.TileSizef,
                size.Y * Metrics.TileSizef,
                0.1f,
                100f);
            effect.Parameters["viewProj"].SetValue(view * proj);
        }

        public void UpdateAssets(int tilesetA, int tilesetB) {
            effect.Parameters["assets"].SetValue(new Vector4(
                tilesetA,
                tilesetB,
                0f,
                0f));
        }

        public void UpdateTileData(byte[] data) {
            tileData.SetData(data, 0, 1000);
        }
    }
}
