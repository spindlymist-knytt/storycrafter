using System;
using System.Collections.Generic;

namespace Story_Crafter.Assets {
    public struct Image: IEquatable<Image> {
        public static readonly Image None = new();

        public int Width = 0;
        public int Height = 0;
        public byte[] Data = Array.Empty<byte>();

        public Image() { }

        public Image(int width, int height, byte[] data) {
            this.Width = width;
            this.Height = height;
            this.Data = data;
        }

        public bool Equals(Image other) {
            return this.Width.Equals(other.Width)
                && this.Height.Equals(other.Height)
                && this.Data.Equals(other.Data);
        }

        public override bool Equals(object obj) {
            return obj is Image other && this.Equals(other);
        }

        public static bool operator==(Image left, Image right) {
            return left.Equals(right);
        }

        public static bool operator!=(Image left, Image right) {
            return !left.Equals(right);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Width, Height, Data);
        }
    }
}
