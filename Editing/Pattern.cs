using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Knytt;
using Story_Crafter.Rendering;

namespace Story_Crafter.Editing {
    [Serializable]
    class Pattern: ICanvas {
        
        private enum PatternType { SingleTileLayer, SingleObjectLayer, Multilayer, Empty };

        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Overwrite { get; set; }

        public Layer[] Layers;

        public Pattern(int layer, int width = Program.ScreenWidth, int height = Program.ScreenHeight, bool overwrite = false) {
            Width = width;
            Height = height;
            Overwrite = overwrite;
            Layers = new Layer[8];
            for(int i = 0; i < 4; i++) {
                Layers[i] = new TileLayer(i, (i == layer));
            }
            for(int i = 4; i < 8; i++) {
                Layers[i] = new ObjectLayer(i, (i == layer));
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
            Width = width;
            Height = height;
        }

        public Layer GetLayer(int idx) {
            return Layers[idx];
        }

        private PatternType DeterminePatternType() {
            int tileLayers = 0, objLayers = 0;
            for(int i = 0; i < 4; i++) {
                if(Layers[i].Active) tileLayers++;
            }
            for(int i = 4; i < 8; i++) {
                if(Layers[i].Active) objLayers++;
            }

            if(tileLayers == 1 && objLayers == 0) return PatternType.SingleTileLayer;
            else if(tileLayers == 0 && objLayers == 1) return PatternType.SingleObjectLayer;
            else if(tileLayers + objLayers > 0) return PatternType.Multilayer;

            return PatternType.Empty;
        }

        private Layer GetActiveLayer() {
            foreach(Layer l in Layers) {
                if(l.Active) return l;
            }
            return null;
        }

        public void Paint(ICanvas canvas, TileLayer layer, Point paintLocation, int brushSizeX, int brushSizeY) {
            PatternType type = DeterminePatternType();
            if(type == PatternType.Empty || type == PatternType.SingleObjectLayer) return;
            if(type == PatternType.Multilayer) {
                Paint(canvas, paintLocation, brushSizeX, brushSizeY);
                return;
            }
            for(int x = paintLocation.X; x < paintLocation.X + brushSizeX * Width; x += Width) {
                for(int y = paintLocation.Y; y < paintLocation.Y + brushSizeY * Height; y += Height) {
                    GetActiveLayer().CopyTo(layer, new Rectangle(0, 0, Width, Height), new Point(x, y), Overwrite);
                }
            }
            
        }

        public void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY) {
            PatternType type = DeterminePatternType();
            if(type == PatternType.Empty || type == PatternType.SingleTileLayer) return;
            if(type == PatternType.Multilayer) {
                Paint(canvas, paintLocation, brushSizeX, brushSizeY);
                return;
            }
            for(int x = paintLocation.X; x < paintLocation.X + brushSizeX * Width; x += Width) {
                for(int y = paintLocation.Y; y < paintLocation.Y + brushSizeY * Height; y += Height) {
                    GetActiveLayer().CopyTo(layer, new Rectangle(0, 0, Width, Height), new Point(x, y), Overwrite);
                }
            }
        }

        private void Paint(ICanvas canvas, Point paintLocation, int brushSizeX, int brushSizeY) {
            for(int x = paintLocation.X; x < paintLocation.X + brushSizeX * Width; x += Width) {
                for(int y = paintLocation.Y; y < paintLocation.Y + brushSizeY * Height; y += Height) {
                    for(int i = 0; i < 8; i++) {
                        if(Layers[i].Active) Layers[i].CopyTo(canvas.GetLayer(i), new Rectangle(0, 0, Width, Height), new Point(x, y), Overwrite);
                    }
                }
            }
        }

    }
}
