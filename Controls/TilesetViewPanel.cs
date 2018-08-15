using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Story_Crafter {

    class TilesetViewPanel: PictureBox {

        public TileSelection Selection {
            get { return selection; }
        }
        TileSelection selection;
        Rectangle lastSelection;
        Point selectionStart = new Point();
        bool selectionInProgress = false;
        bool firstSelection = false;

        static Pen tileCursor = new Pen(Color.Orange);
        static Pen newSelectionCursor = new Pen(Color.AntiqueWhite);

        public bool Active {
            set {
                active = value;
                Refresh();
            }
            get { return active; }
        }
        bool active = false;

        public TilesetViewPanel() {
            selection = new TileSelection(24, 24, 0, 0, Program.TilesetWidth, Program.TilesetHeight, tileCursor);
            selection.Add(new Rectangle(0, 0, 1, 1));
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);

            if(e.Button == MouseButtons.Left) {
                if(!active) firstSelection = true;
                active = true;
                selectionInProgress = true;
                selectionStart.X = (int)(e.X / 24f);
                selectionStart.Y = (int)(e.Y / 24f);
                lastSelection.X = selectionStart.X;
                lastSelection.Y = selectionStart.Y;
                lastSelection.Width = 1;
                lastSelection.Height = 1;
                Refresh();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            if(selectionInProgress && active) {
                int x = (int)(e.X / 24f);
                int y = (int)(e.Y / 24f);
                lastSelection.X = Math.Min(x, selectionStart.X);
                lastSelection.Y = Math.Min(y, selectionStart.Y);
                lastSelection.Width = Math.Abs(x - selectionStart.X) + 1;
                lastSelection.Height = Math.Abs(y - selectionStart.Y) + 1;
                Refresh();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);

            if(active && e.Button == MouseButtons.Left) {
                firstSelection = false;
                if(ModifierKeys == Keys.Control) {
                    selection.Remove(lastSelection);
                }
                else {
                    if(ModifierKeys != Keys.Shift) selection.Clear();
                    selection.Add(lastSelection);
                }
                selectionInProgress = false;
                Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            if(active) {
                if(!firstSelection)
                    e.Graphics.DrawImage(selection.Borders,
                           new Rectangle(selection.MinX * 24, selection.MinY * 24, selection.Borders.Width, selection.Borders.Height),
                           new Rectangle(0, 0, selection.Borders.Width, selection.Borders.Height),
                           GraphicsUnit.Pixel);
                if(selectionInProgress)
                    e.Graphics.DrawRectangle(newSelectionCursor, lastSelection.X * 24, lastSelection.Y * 24, lastSelection.Width * 24 - 1, lastSelection.Height * 24 - 1);
            }
        }

    }

}
