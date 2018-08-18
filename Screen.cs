using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

namespace Story_Crafter {
    [Serializable]
    class Screen: ICanvas {
        public int X, Y;
        public int TilesetA, TilesetB, Gradient, Music, AmbianceA, AmbianceB;
        public Layer[] Layers;
        [NonSerialized] public Bitmap Thumbnail;
        [NonSerialized] public bool Conflict = false;

        public Screen() {
            this.Layers = new Layer[8];
        }

        public Screen(int x, int y) {
            this.Layers = new Layer[8];
            Byte[] blankData = new Byte[500];
            for(int i = 0; i < 500; i++) blankData[i] = 0;

            this.X = x;
            this.Y = y;
            this.TilesetA = 0;
            this.TilesetB = 0;
            this.Gradient = 0;
            this.AmbianceA = 0;
            this.AmbianceB = 0;
            this.Music = 0;
            for(int i = 0; i < 4; i++) {
                this.Layers[i] = new TileLayer(i, blankData);
            }
            for(int i = 4; i < 8; i++) {
                this.Layers[i] = new ObjectLayer(i, blankData);
            }
        }

        public void Draw(Graphics g, Tileset a, Tileset b, Bitmap gradient) {
            this.DrawGradient(g, gradient);
            foreach(Layer l in this.Layers) {
                if(l.Active) l.Draw(g, a, b);
            }
        }

        private void DrawGradient(Graphics g, Bitmap gradient) {
            for(int x = 0; x < Program.PxScreenWidth; x += gradient.Width) {
                g.DrawImage(gradient, x, 0, gradient.Width, gradient.Height);
            }
        }

        public void Resize(int width, int height) {
        }

        public Layer GetLayer(int idx) {
            return Layers[idx];
        }

    }
}
