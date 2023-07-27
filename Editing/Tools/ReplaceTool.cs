using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Knytt;

namespace Story_Crafter.Editing.Tools {
    class ReplaceTool: EditingTool {

        public override string Name { get { return "Replace"; } }

        Pen cursor = new Pen(Color.Orchid);

        public override void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            Tile target = layer.Tiles[Metrics.ScreenPointToIndex(paintLocation)].Clone();
            Tile replacement = new Tile(tileset, Metrics.TilesetPointToIndex(selection.MinX, selection.MinY));
            Replace(layer, target, replacement);
        }

        public override void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
            Tile target = layer.Tiles[Metrics.ScreenPointToIndex(paintLocation)].Clone();
            Tile replacement = new Tile(bank, idx);
            Replace(layer, target, replacement);
        }

        public override void DrawCursor(Graphics g, Point position, Selection selection, int brushSizeX, int brushSizeY, int layer) {
            g.DrawRectangle(cursor, position.X * Metrics.TileSize, position.Y * Metrics.TileSize, Metrics.TileSize - 1, Metrics.TileSize - 1);
        }

        private void Replace(Layer layer, Tile target, Tile replacement) {
            if(target.Equals(replacement)) return;
            for(int i = 0; i < Metrics.ScreenWidth * Metrics.ScreenHeight; i++) {
                Tile t = layer.Tiles[i];
                if(t.Equals(target)) {
                    t.Set(replacement);
                }
            }
        }

    }
}
