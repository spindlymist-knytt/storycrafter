using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Story_Crafter {
    [Serializable]
    class Tile {
        public int Collection, Index;
        public int Tileset { // For tileset terminology.
            get { return Collection; }
            set { Collection = value; }
        }
        public int Bank { // For object terminology.
            get { return Collection; }
            set { Collection = value; }
        }

        public Tile() {
        }
        public Tile(int collection, int i) {
            this.Collection = collection;
            this.Index = i;
        }
        public Tile Clone() {
            return new Tile(Collection, Index);
        }
        public bool Equals(Tile t) {
            if(t.Collection == Collection && t.Index == Index) return true;
            return false;
        }
        public void Set(int collection, int i) {
            Collection = collection;
            Index = i;
        }
        public void Set(Tile t) {
            Collection = t.Collection;
            Index = t.Index;
        }
    }
    [Serializable]
    class Layer {
        public Size Size;
        public Tile[] Tiles;
        public bool Active;

        public Layer(bool active = true, int width = Program.ScreenWidth, int height = Program.ScreenHeight) {
            this.Active = active;
            this.Size = new Size(width, height);
            Tiles = new Tile[this.Size.Width * this.Size.Height];
        }
        virtual public void Draw(Graphics g) { }
        virtual public void Draw(Graphics g, Tileset tilesetA, Tileset tilesetB) {
            this.Draw(g);
        }
    }
    [Serializable]
    class TileLayer: Layer {
        public TileLayer(byte[] data) : base() {
            for(int i = 0; i < 250; i++) {
                this.Tiles[i] = new Tile();
                if(data[i] < 128) {
                    this.Tiles[i].Tileset = 0;
                    this.Tiles[i].Index = data[i];
                }
                else {
                    this.Tiles[i].Tileset = 1;
                    this.Tiles[i].Index = data[i] - 128;
                }
            }
        }
        public override void Draw(Graphics g, Tileset tilesetA, Tileset tilesetB) {
            int i = 0;
            Rectangle src = new Rectangle(0, 0, 24, 24);
            Rectangle dest = new Rectangle(0, 0, 24, 24);
            for(int y = 0; y < this.Size.Height; y++) {
                for(int x = 0; x < this.Size.Width; x++) {
                    Tile t = this.Tiles[i];
                    if(t.Index > 0) {
                        Bitmap img = t.Tileset == 0 ? tilesetA.Tiles[t.Index] : tilesetB.Tiles[t.Index];
                        if(img != null) g.DrawImage(img, dest, src, GraphicsUnit.Pixel);
                    }

                    dest.Location = new Point(dest.Location.X + 24, dest.Location.Y);
                    i++;
                }

                dest.Location = new Point(0, dest.Location.Y + 24);
            }
        }
    }
    [Serializable]
    class ObjectLayer: Layer {
        private static HatchBrush missingObjectBrush = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.Red, Color.Transparent);

        public ObjectLayer(byte[] data) : base() {
            for(int i = 0; i < 250; i++) {
                this.Tiles[i] = new Tile();
                this.Tiles[i].Index = data[i];
            }
            for(int i = 0; i < 250; i++) {
                this.Tiles[i].Bank = data[i + 250];
            }
        }
        public override void Draw(Graphics g) {
            int i = 0;
            for(int y = 0; y < this.Size.Height; y++) {
                for(int x = 0; x < this.Size.Width; x++) {
                    Tile t = this.Tiles[i];
                    if(t.Index > 0) {
                        Bitmap img = Program.Banks[t.Bank][t.Index];
                        if(img != null) g.DrawImage(img, new Rectangle(x * 24, y * 24, img.Width, img.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                        else {
                            g.FillRectangle(ObjectLayer.missingObjectBrush, new Rectangle(x * 24, y * 24, 24, 24));
                        }
                    }

                    i++;
                }
            }
        }
    }
}
