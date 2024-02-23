using System;
using System.Collections.Generic;
using System.IO;
using ImageMagick;
using Story_Crafter.Knytt;

namespace Story_Crafter.Assets {
    public abstract class BaseAssetSource : IAssetSource {
        protected static readonly MagickColor MAGENTA = MagickColor.FromRgba(255, 0, 255, 255);
        //protected static readonly MagickColor TRANSPARENT = MagickColor.FromRgba(0, 0, 0, 0);

        protected Image LoadImage(string path, int cropWidth = 0, int cropHeight = 0) {
            if (path == null) return Image.None;

            try {
                using var image = new MagickImage(path);
                if (!image.HasAlpha) {
                    image.TransparentChroma(MAGENTA, MAGENTA);
                }

                if (cropWidth > 0) {
                    image.Crop(cropWidth, cropHeight);
                }

                image.Format = MagickFormat.Rgba;

                return new Image(image.Width, image.Height, image.ToByteArray());
            }
            catch (MagickException) {
                return Image.None;
            }
        }

        public abstract string TilesetPath(uint index);
        public abstract string GradientPath(uint index);
        public abstract string ObjectPath(uint bank, uint index);

        public FileStream GradientStream(uint index) {
            string path = GradientPath(index);
            if (path == null) return null;

            try {
                return new FileStream(GradientPath(index), FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException) {
                return null;
            }
        }

        public FileStream ObjectStream(uint bank, uint index) {
            string path = ObjectPath(bank, index);
            if (path == null) return null;

            try {
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException) {
                return null;
            }
        }

        public FileStream TilesetStream(uint index) {
            string path = TilesetPath(index);
            if (path == null) return null;

            try {
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException) {
                return null;
            }
        }

        public Image GradientRGBA(uint index) {
            return LoadImage(GradientPath(index));
        }

        public Image TilesetRGBA(uint index, bool withInfo = false) {
            int width = Metrics.TilesetWidthPx;
            int height = withInfo ? Metrics.TilesetHeightPxWithInfo : Metrics.TilesetHeightPx;
            return LoadImage(TilesetPath(index), width, height);
        }

        public Image ObjectRGBA(uint bank, uint index) {
            return LoadImage(ObjectPath(bank, index));
        }
    }
}
