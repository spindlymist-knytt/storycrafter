using System;

using Story_Crafter.Knytt.Primitives;

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

        public static Color DefaultClothes = Color.FromRgb(235, 235, 235);
        public static Color DefaultSkin = Color.FromRgb(216, 192, 166);

        public static int ScreenPointToIndex(Int2 p) {
            return ScreenPointToIndex(p.X, p.Y);
        }

        public static int ScreenPointToIndex(int x, int y) {
            return PointToIndex(x, y, ScreenWidth);
        }

        public static Int2 ScreenIndexToPoint(int i) {
            return IndexToPoint(i, ScreenWidth);
        }

        public static int TilesetPointToIndex(Int2 p) {
            return TilesetPointToIndex(p.X, p.Y);
        }

        public static int TilesetPointToIndex(int x, int y) {
            return PointToIndex(x, y, TilesetWidth);
        }

        public static Int2 TilesetIndexToPoint(int i) {
            return IndexToPoint(i, TilesetWidth);
        }

        public static int PointToIndex(Int2 p, int width) {
            return PointToIndex(p.X, p.Y, width);
        }

        public static int PointToIndex(int x, int y, int width) {
            return y * width + x;
        }

        public static Int2 IndexToPoint(int i, int width) {
            int y = i / width;
            return new Int2(i - y * width, y);
        }
    }
}
