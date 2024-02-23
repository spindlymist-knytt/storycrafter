using System;
using System.Collections.Generic;

namespace Story_Crafter.Assets {
    public struct Image {
        public int Width = 0;
        public int Height = 0;
        public byte[] Data = null;

        public Image() { }

        public Image(int width, int height, byte[] data) {
            this.Width = width;
            this.Height = height;
            this.Data = data;
        }

        public static Image None = new Image();
    }
}
