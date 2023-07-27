using System;
using System.Drawing;

namespace Story_Crafter.Knytt {
    static class Metrics {
        public const int TileSize = 24;
        public const float TileSizef = 24.0f;

        public const int ScreenWidth = 25;
        public const int ScreenHeight = 10;
        public const int ScreenWidthPx = ScreenWidth * TileSize;
        public const int ScreenHeightPx = ScreenHeight * TileSize;

        public const int TilesetWidth = 16;
        public const int TilesetHeight = 8;
        public const int TilesetWidthPx = TilesetWidth * TileSize;
        public const int TilesetHeightPx = TilesetHeight * TileSize;
        public const int TilesetHeightPxWithInfo = TilesetHeightPx + 10;

        public static Color DefaultClothes = Color.FromArgb(235, 235, 235);
        public static Color DefaultSkin = Color.FromArgb(216, 192, 166);

        public static int ScreenPointToIndex(Point p) {
            return ScreenPointToIndex(p.X, p.Y);
        }
        public static int ScreenPointToIndex(int x, int y) {
            return PointToIndex(x, y, ScreenWidth);
        }
        public static Point ScreenIndexToPoint(int i) {
            return IndexToPoint(i, ScreenWidth);
        }
        public static int TilesetPointToIndex(Point p) {
            return TilesetPointToIndex(p.X, p.Y);
        }
        public static int TilesetPointToIndex(int x, int y) {
            return PointToIndex(x, y, TilesetWidth);
        }
        public static Point TilesetIndexToPoint(int i) {
            return IndexToPoint(i, TilesetWidth);
        }

        public static int PointToIndex(Point p, int width) {
            return PointToIndex(p.X, p.Y, width);
        }
        public static int PointToIndex(int x, int y, int width) {
            return y * width + x;
        }
        public static Point IndexToPoint(int i, int width) {
            int y = i / width;
            return new Point(i - y * width, y);
        }
    }
}
