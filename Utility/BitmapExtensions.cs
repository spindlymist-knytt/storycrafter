using System;
using System.Drawing;

namespace Story_Crafter.Utility {
    public static class BitmapExtensions {
        public static Bitmap FromFileToMemory(string path) {
            using Bitmap temp = new(path);
            return new Bitmap(temp);
        }
    }
}
