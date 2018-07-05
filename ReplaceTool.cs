using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {
    class ReplaceTool: EditingTool {

        public override string Name { get { return "Replace"; } }

        public override void Paint(TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            Tile target = layer.Tiles[Program.ScreenPointToIndex(paintLocation)].Clone();
            Tile replacement = new Tile(tileset, Program.TilesetPointToIndex(selection.MinX, selection.MinY));
            Replace(layer, target, replacement);
        }

        public override void Paint(ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
            Tile target = layer.Tiles[Program.ScreenPointToIndex(paintLocation)].Clone();
            Tile replacement = new Tile(bank, idx);
            Replace(layer, target, replacement);
        }

        private void Replace(Layer layer, Tile target, Tile replacement) {
            if(target.Equals(replacement)) return;
            for(int i = 0; i < Program.ScreenWidth * Program.ScreenHeight; i++) {
                Tile t = layer.Tiles[i];
                if(t.Equals(target)) {
                    t.Set(replacement);
                }
            }
        }

    }
}
