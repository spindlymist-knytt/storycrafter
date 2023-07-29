using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Story_Crafter.Knytt;

namespace Story_Crafter.Editing.Tools {
    class PatternTool : IEditingTool {
        
        public string Name { get { return "Pattern"; } }

        public Pattern Source { get; set; } = null;

        static Pen cursor = new Pen(Color.Orchid);

        public void DrawCursor(Graphics g, Point position, Selection selection, int brushSizeX, int brushSizeY, int layer) {
            if(Source == null) return;
            for(int x = position.X; x < position.X + brushSizeX * Source.Width; x += Source.Width) {
                for(int y = position.Y; y < position.Y + brushSizeY * Source.Height; y += Source.Height) {
                    g.DrawRectangle(cursor, x * 24, y * 24, Source.Width * 24 - 1, Source.Height * 24 - 1);
                }
            }
        }

        public void Paint(ICanvas canvas, TileLayer layer, TileSelection selection, Point paintLocation, int brushSizeX, int brushSizeY, int tileset) {
            if(Source == null) return;
            Source.Paint(canvas, layer, paintLocation, brushSizeX, brushSizeY);
        }

        public void Paint(ICanvas canvas, ObjectLayer layer, Point paintLocation, int brushSizeX, int brushSizeY, int bank, int idx) {
            if(Source == null) return;
            Source.Paint(canvas, layer, paintLocation, brushSizeX, brushSizeY);
        }

    }
}
