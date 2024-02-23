using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Story_Crafter.Knytt;

namespace Story_Crafter.Rendering {
    class TilemapMesh {
        static readonly IDictionary<Tuple<int, int>, VertexPosition[]> cache =
            new Dictionary<Tuple<int, int>, VertexPosition[]>();

        VertexPosition[] vertexPositions;

        public TilemapMesh(int width, int height) {
            var key = Tuple.Create(width, height);
            if(cache.TryGetValue(key, out vertexPositions)) {
                return;
            }

            float tileSize = Metrics.TileSizef;
            float leftEdge = -tileSize * width / 2.0f;
            float topEdge = tileSize * height / 2.0f;

            vertexPositions = new VertexPosition[width * height * 6];
            for (int i = 0, screenY = 0; screenY < height; screenY++) {
                for (int screenX = 0; screenX < width; screenX++) {
                    float top = topEdge - (screenY * tileSize);
                    float bottom = top - tileSize;
                    float left = leftEdge + (screenX * tileSize);
                    float right = left + tileSize;

                    vertexPositions[i++] = new VertexPosition(new Vector3(left, top, 0.5f));
                    vertexPositions[i++] = new VertexPosition(new Vector3(right, bottom, 0.5f));
                    vertexPositions[i++] = new VertexPosition(new Vector3(left, bottom, 0.5f));
                    vertexPositions[i++] = new VertexPosition(new Vector3(left, top, 0.5f));
                    vertexPositions[i++] = new VertexPosition(new Vector3(right, top, 0.5f));
                    vertexPositions[i++] = new VertexPosition(new Vector3(right, bottom, 0.5f));
                }
            }

            cache[key] = vertexPositions;
        }

        public void Draw(GraphicsDevice graphics) {
            graphics.DrawUserPrimitives(PrimitiveType.TriangleList, vertexPositions, 0, vertexPositions.Length / 3);
        }
    }
}
