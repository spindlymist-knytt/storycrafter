using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Story_Crafter.Editing;
using Story_Crafter.Editing.Tools;
using Story_Crafter.Knytt;
using Story_Crafter.Rendering;

namespace Story_Crafter.Controls {
    public class TileCanvas : PictureBox {
        public ICanvas Canvas {
            get { return this.canvas; }
            set { this.canvas = value; Refresh(); }
        }
        ICanvas canvas;

        public bool Resizable { get; set; } = false;
        public float ScalingFactor { get; set; } = 1.0f;
        public ITileCanvasEvents EventsHandler { get; set; }

        public struct MouseState {
            public bool isHovering;
            public bool isDragging;
            public MouseButtons dragButton;
            public Point dragStartLocation;
            public Point currentLocation;
        }
        public MouseState Mouse {
            get { return mouseState; }
        }
        MouseState mouseState = new MouseState();
        Point lastMouseLocation = new Point();

        public TileCanvas() { }

        void MouseLocationToTile(Point mouseLocation, ref Point tileLocation) {
            float scaledTileSize = Metrics.TileSize * this.ScalingFactor;
            tileLocation.X = (int)(mouseLocation.X / scaledTileSize);
            tileLocation.Y = (int)(mouseLocation.Y / scaledTileSize);
        }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);

            this.mouseState.isHovering = true;

            if (this.EventsHandler?.OnMouseEnter(this, e) ?? false) {
                Refresh();
            }
        }

        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);

            this.mouseState.isHovering = false;

            if (this.EventsHandler?.OnMouseLeave(this, e) ?? false) {
                Refresh();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);

            this.mouseState.isDragging = true;
            this.mouseState.dragButton = e.Button;
            MouseLocationToTile(e.Location, ref this.mouseState.currentLocation);
            this.mouseState.dragStartLocation = this.mouseState.currentLocation;
            
            if (this.EventsHandler?.OnMouseDown(this, e) ?? false) {
                Refresh();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            this.lastMouseLocation = this.mouseState.currentLocation;
            MouseLocationToTile(e.Location, ref this.mouseState.currentLocation);

            bool shouldRefresh = this.EventsHandler?.OnMouseMove(this, e) ?? false;
            if (this.mouseState.currentLocation != this.lastMouseLocation) {
                shouldRefresh = shouldRefresh || (this.EventsHandler?.OnMouseMoveUnique(this, e) ?? false);
            }

            if (shouldRefresh) {
                Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);

            this.mouseState.isDragging = false;
            MouseLocationToTile(e.Location, ref this.mouseState.currentLocation);

            if (EventsHandler?.OnMouseUp(this, e) ?? false) {
                Refresh();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);

            if ((bool)this.EventsHandler?.OnKeyDown(this, e)) {
                Refresh();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {
            base.OnKeyPress(e);

            if(this.EventsHandler?.OnKeyPress(this, e) ?? false) {
                Refresh();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e) {
            base.OnKeyUp(e);

            if(this.EventsHandler?.OnKeyUp(this, e) ?? false) {
                Refresh();
            }
        }

        public void OnMouseClick(CanvasPanel sender, MouseEventArgs e) {
            base.OnMouseClick(e);

            if (this.EventsHandler?.OnMouseClick(this, e) ?? false) {
                Refresh();
            }
        }

        public void OnMouseDoubleClick(CanvasPanel sender, MouseEventArgs e) {
            base.OnMouseDoubleClick(e);

            if(this.EventsHandler?.OnMouseDoubleClick(this, e) ?? false) {
                Refresh();
            }
        }

        public void OnMouseWheel(CanvasPanel sender, MouseEventArgs e) {
            base.OnMouseWheel(e);

            if(this.EventsHandler?.OnMouseWheel(this, e) ?? false) {
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            base.OnPaint(e);

            this.EventsHandler?.OnPaint(this, e);
        }

    }
}
