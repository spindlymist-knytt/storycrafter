using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Story_Crafter {

    class Selection {
        public class SelectionNode {
            public SelectionNode North, East, South, West;
            public int X {
                get { return x; }
                set {
                    x = value;
                    TileIndex = Program.TilesetPointToIndex(x, y);
                }
            }
            public int Y {
                get { return y; }
                set {
                    y = value;
                    TileIndex = Program.TilesetPointToIndex(x, y);
                }
            }
            public int TileIndex;

            int x, y;

            public SelectionNode(int _x, int _y) {
                North = East = South = West = null;
                x = _x;
                y = _y;
                TileIndex = Program.TilesetPointToIndex(x, y);
            }
        }

        public List<SelectionNode> nodes = new List<SelectionNode>();
        public int MinX = 0, MinY = 0, MaxX = 0, MaxY = 0;
        public int Width {
            get { return MaxX - MinX + 1; }
        }
        public int Height {
            get { return MaxY - MinY + 1; }
        }
        public Image Borders;
        public Pen Cursor = new Pen(Color.Black);

        int CellWidth, CellHeight, ContainerMinX, ContainerMinY, ContainerMaxX, ContainerMaxY;
        bool InfiniteContainer;

        public Selection(int cellWidth, int cellHeight, int containerMinX, int containerMinY, int containerMaxX, int containerMaxY, Pen cursor) {
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            ContainerMinX = containerMinX;
            ContainerMinY = containerMinY;
            ContainerMaxX = containerMaxX;
            ContainerMaxY = containerMaxY;
            Cursor = cursor;
            InfiniteContainer = false;
        }

        public Selection(int cellWidth, int cellHeight, Pen cursor) {
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            Cursor = cursor;
            InfiniteContainer = true;
        }

        public void Clear() {
            nodes.Clear();
            MinX = MinY = 0;
            MaxX = MaxY = 0;
        }
        public void Add(Rectangle r) {
            bool first = false;
            if(nodes.Count == 0) first = true;
            for(int x = r.X; x < r.Right; x++) {
                for(int y = r.Y; y < r.Bottom; y++) {
                    if(!InfiniteContainer && (x < ContainerMinX || x >= ContainerMaxX || y < ContainerMinY || y >= ContainerMaxY)) continue;
                    if(FindNode(x, y) == null) nodes.Add(new SelectionNode(x, y));
                }
            }
            if(nodes.Count() == 0) return;
            if(first) {
                MinX = r.X;
                MinY = r.Y;
                MaxX = r.Right - 1;
                MaxY = r.Bottom - 1;
            }
            else {
                if(r.X < MinX) MinX = r.X;
                if(r.Y < MinY) MinY = r.Y;
                if(r.Right - 1 > MaxX) MaxX = r.Right - 1;
                if(r.Bottom - 1 > MaxY) MaxY = r.Bottom - 1;
            }
            FindNeighbors();
            DrawBorders();
        }
        public void Remove(Rectangle r) {
            bool first = true;
            List<SelectionNode> toRemove = new List<SelectionNode>();
            foreach(SelectionNode n in nodes) {
                if(n.X >= r.X && n.X < r.Right && n.Y >= r.Y && n.Y < r.Bottom) toRemove.Add(n);
                else if(first) {
                    MinX = n.X;
                    MinY = n.Y;
                    MaxX = n.X;
                    MaxY = n.Y;
                    first = false;
                }
                else {
                    if(n.X < MinX) MinX = n.X;
                    if(n.X > MaxX) MaxX = n.X;
                    if(n.Y < MinY) MinY = n.Y;
                    if(n.Y > MaxY) MaxY = n.Y;
                }
            }
            nodes.RemoveAll(n => toRemove.Contains(n));
            if(nodes.Count == 0) {
                MinX = MaxX = 0;
                MinY = MaxY = 0;
                nodes.Add(new SelectionNode(0, 0));
            }
            FindNeighbors();
            DrawBorders();
        }
        public int RandomNode() {
            return nodes[Program.Rand.Next(0, nodes.Count)].TileIndex;
        }
        protected void FindNeighbors() {
            // TODO optimize
            foreach(SelectionNode n in nodes) {
                n.North = n.East = n.South = n.West = null;
            }
            foreach(SelectionNode n in nodes) {
                SelectionNode neighbor;
                if(n.Y > 0 && (neighbor = FindNode(n.X, n.Y - 1)) != null) {
                    n.North = neighbor;
                    neighbor.South = neighbor;
                }
                if((ContainerMaxY == -1 || n.Y < ContainerMaxY - 1) && (neighbor = FindNode(n.X, n.Y + 1)) != null) {
                    n.South = neighbor;
                    neighbor.North = n;
                }
                if(n.X > 0 && (neighbor = FindNode(n.X - 1, n.Y)) != null) {
                    n.West = neighbor;
                    neighbor.East = n;
                }
                if((ContainerMaxX == -1 || n.X < ContainerMaxX - 1) && (neighbor = FindNode(n.X + 1, n.Y)) != null) {
                    n.East = neighbor;
                    neighbor.West = n;
                }
            }
        }
        protected void DrawBorders() {
            Borders = new Bitmap((MaxX - MinX + 1) * CellWidth, (MaxY - MinY + 1) * CellHeight);
            Graphics g = Graphics.FromImage(Borders);
            foreach(SelectionNode n in nodes) {
                int x = (n.X - MinX) * CellWidth;
                int y = (n.Y - MinY) * CellHeight;
                if(n.North == null) {
                    g.DrawLine(Cursor, x, y, x + (CellWidth - 1), y);
                }
                if(n.East == null) {
                    g.DrawLine(Cursor, x + (CellWidth - 1), y, x + (CellWidth - 1), y + (CellHeight - 1));
                }
                if(n.South == null) {
                    g.DrawLine(Cursor, x + (CellWidth - 1), y + (CellHeight - 1), x, y + (CellHeight - 1));
                }
                if(n.West == null) {
                    g.DrawLine(Cursor, x, y + (CellHeight - 1), x, y);
                }
            }
        }
        protected SelectionNode FindNode(int x, int y) {
            // TODO: optimize
            foreach(SelectionNode n in nodes) {
                if(n.X == x && n.Y == y) return n;
            }
            return null;
        }
        public void ChangeCellSize(int cellWidth, int cellHeight) {
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            DrawBorders();
        }
        public void Translate(int dx, int dy) {
            if(MinX + dx < ContainerMinX || MinY + dy < ContainerMinY || MaxX + dx >= ContainerMaxX || MaxY + dy >= ContainerMaxY)
                return;
            foreach(SelectionNode n in nodes) {
                n.X += dx;
                n.Y += dy;
            }
            MinX += dx;
            MinY += dy;
            MaxX += dx;
            MaxY += dy;
            DrawBorders();
        }
    }

}
