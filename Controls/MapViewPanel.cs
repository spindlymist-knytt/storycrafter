using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using Story_Crafter.Editing;
using Story_Crafter.Knytt;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter {

    public class MapViewPanel : PictureBox {

        public bool ShowThumbs {
            get { return this.showThumbs; }
            set {
                this.showThumbs = value;
                DrawMap();
            }
        }
        public Story Story {
            get { return this.story; }
            set {
                this.story = value;
                if (this.story != null) {
                    CenterScreen(this.story.DefaultSave.MapX, this.story.DefaultSave.MapY);
                }
                DrawMap();
            }
        }
        public UpdateScreenEvent UpdateScreen {
            get { return this.updateScreen; }
            set { this.updateScreen = value; }
        }
        public UpdateStatusEvent UpdateStatus {
            get { return this.updateStatus; }
            set { this.updateStatus = value; }
        }

        public delegate void UpdateScreenEvent(int x, int y);
        public delegate void UpdateStatusEvent(int x, int y);

        int startX = 1000, startY = 1000, mapWidth, mapHeight, screenWidth, screenHeight;
        int origStartX, origStartY, mouseDownX, mouseDownY;
        Pen p = new Pen(Color.FromArgb(25, 0, 0, 0));
        Pen p2 = new Pen(Color.FromArgb(25, 255, 255, 255));
        Pen activeScreenOutline = new Pen(Color.Orchid, 2);
        Brush screenFill = new SolidBrush(Color.FromArgb(58, 102, 135));
        Brush activeScreenFill = new SolidBrush(Color.FromArgb(171, 199, 243));
        bool panning = false;

        Selection selection;
        Rectangle lastSelection;
        Point selectionStart = new Point();
        bool selectionInProgress = false;

        Brush pasteFill = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(58, 102, 135), Color.Transparent);
        Brush conflictFill = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(253, 53, 58), Color.Transparent);
        List<Screen> paste;

        Pen selectionCursor = new Pen(Color.Orange);
        Pen newSelectionCursor = new Pen(Color.Gold);

        Story story;
        bool showThumbs = false;
        UpdateScreenEvent updateScreen;
        UpdateStatusEvent updateStatus;

        int _zoomLevel;
        int ZoomLevel {
            get { return _zoomLevel; }
            set {
                _zoomLevel = Math.Max(1, Math.Min(7, value));
                switch (_zoomLevel) {
                    case 1:
                        screenWidth = 3;
                        screenHeight = 1;
                        break;
                    case 2:
                        screenWidth = 6;
                        screenHeight = 3;
                        break;
                    case 3:
                        screenWidth = 13;
                        screenHeight = 5;
                        break;
                    case 4:
                        screenWidth = 25;
                        screenHeight = 10;
                        break;
                    case 5:
                        screenWidth = 50;
                        screenHeight = 20;
                        break;
                    case 6:
                        screenWidth = 100;
                        screenHeight = 40;
                        break;
                    case 7:
                        screenWidth = 200;
                        screenHeight = 80;
                        break;
                    default:
                        screenWidth = 25;
                        screenHeight = 10;
                        break;
                }
            }
        }

        public MapViewPanel() {
            ZoomLevel = 4;
            selection = new Selection(screenWidth, screenHeight, selectionCursor);
            this.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.ResetSelection(startX, startY);
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseUp(e);

            mouseDownX = e.X;
            mouseDownY = e.Y;
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle) {
                origStartX = startX;
                origStartY = startY;
                panning = true;
            }
            else if (e.Button == MouseButtons.Left) {
                selectionInProgress = true;
                selectionStart = new Point(e.X / screenWidth + startX, e.Y / screenHeight + startY);
                lastSelection = new Rectangle(selectionStart.X, selectionStart.Y, 1, 1);
                this.Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);

            panning = false;
            if (selectionInProgress) {
                if (ModifierKeys == Keys.Control) {
                    selection.Remove(lastSelection);
                }
                else {
                    if (ModifierKeys != Keys.Shift) selection.Clear();
                    selection.Add(lastSelection);
                }
                selectionInProgress = false;
                this.Refresh();
            }
        }

        protected override void OnDoubleClick(EventArgs e) {
            base.OnDoubleClick(e);

            if (updateScreen == null) return;
            updateScreen(mouseDownX / screenWidth + startX, mouseDownY / screenHeight + startY);
            DrawMap();
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            if (panning) {
                int deltaX = e.X - mouseDownX;
                int deltaY = e.Y - mouseDownY;
                startX = origStartX - deltaX / screenWidth;
                startY = origStartY - deltaY / screenHeight;
                DrawMap();
            }
            else if (selectionInProgress) {
                int x = (int)(e.X / screenWidth) + startX;
                int y = (int)(e.Y / screenHeight) + startY;
                lastSelection.X = Math.Min(x, selectionStart.X);
                lastSelection.Y = Math.Min(y, selectionStart.Y);
                lastSelection.Width = Math.Abs(x - selectionStart.X) + 1;
                lastSelection.Height = Math.Abs(y - selectionStart.Y) + 1;
                this.Refresh();
            }
            int hoverX = startX + e.X / screenWidth;
            int hoverY = startY + e.Y / screenHeight;
            updateStatus?.Invoke(hoverX, hoverY);
        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);

            int d = e.Delta / 120;
            ZoomLevel += d;

            // Find the center screen.
            int centerX = startX + mapWidth / 2;
            int centerY = startY + mapHeight / 2;

            mapWidth = this.Width / screenWidth + 1;
            mapHeight = this.Height / screenHeight + 1;

            this.CenterScreen(centerX, centerY);
            selection.ChangeCellSize(screenWidth, screenHeight);
            DrawGridLines();
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);

            if (story == null) return;

            pe.Graphics.DrawImage(
                selection.Borders,
                new Rectangle(
                    (selection.MinX - startX) * screenWidth,
                    (selection.MinY - startY) * screenHeight,
                    selection.Borders.Width,
                    selection.Borders.Height
                ),
                new Rectangle(0, 0, selection.Borders.Width, selection.Borders.Height),
                GraphicsUnit.Pixel);

            //pe.Graphics.DrawRectangle(
            //    activeScreenOutline,
            //    new Rectangle((story.ActiveScreen.X - startX) * screenWidth,
            //    (story.ActiveScreen.Y - startY) * screenHeight,
            //    screenWidth - 1,
            //    screenHeight - 1));

            if (selectionInProgress) {
                pe.Graphics.DrawRectangle(
                    newSelectionCursor,
                    (lastSelection.X - startX) * screenWidth,
                    (lastSelection.Y - startY) * screenHeight,
                    lastSelection.Width * screenWidth - 1,
                    lastSelection.Height * screenHeight - 1);
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            this.mapWidth = this.Width / screenWidth + 1;
            this.mapHeight = this.Height / screenHeight + 1;
            DrawGridLines();
            DrawMap();
        }

        private void DrawGridLines() {
            this.Image = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(this.Image);
            for(int x = 1; x < mapWidth; x++) {
                g.DrawLine(p2, x * screenWidth - 1, 0, x * screenWidth - 1, this.Height);
                g.DrawLine(p, x * screenWidth, 0, x * screenWidth, this.Height);
            }
            for(int y = 1; y < mapHeight; y++) {
                g.DrawLine(p2, 0, y * screenHeight - 1, this.Width, y * screenHeight - 1);
                g.DrawLine(p, 0, y * screenHeight, this.Width, y * screenHeight);
            }
            this.Refresh();
        }

        public void DrawMap() {
            this.BackgroundImage = new Bitmap(this.Size.Width, this.Size.Height);
            if(story != null) {
                Graphics g = Graphics.FromImage(this.BackgroundImage);
                Rectangle src = new Rectangle(0, 0, 200, 80);
                foreach(Screen s in story.Screens.Values) {
                    int offX = s.X - startX;
                    int offY = s.Y - startY;
                    if(offX >= 0 && offX < mapWidth && offY >= 0 && offY < mapHeight) {
                        Rectangle area = new Rectangle(offX * screenWidth, offY * screenHeight, screenWidth, screenHeight);
                        if(this.showThumbs && s.Thumbnail != null) {
                            g.DrawImage(s.Thumbnail, area, src, GraphicsUnit.Pixel);
                        }
                        else {
                            //g.FillRectangle(s == story.ActiveScreen ? activeScreenFill : screenFill, area);
                            g.FillRectangle(screenFill, area);
                        }
                    }
                }
                if(paste != null) {
                    foreach(Screen s in paste) {
                        int offX = s.X - startX;
                        int offY = s.Y - startY;
                        if(offX >= 0 && offX < mapWidth && offY >= 0 && offY < mapHeight) {
                            Rectangle area = new Rectangle(offX * screenWidth, offY * screenHeight, screenWidth, screenHeight);
                            g.FillRectangle(s.Conflict ? conflictFill : pasteFill, area);
                        }
                    }
                }
            }
            this.Refresh();
        }

        public void CenterScreen(int x, int y) {
            startX = x - mapWidth / 2;
            startY = y - mapHeight / 2;
            DrawMap();
        }

        public void ResetSelection(int x, int y) {
            lastSelection = new Rectangle(x, y, 1, 1);
            selection.Clear();
            selection.Add(lastSelection);
            this.Refresh();
        }

        public Selection GetSelection() {
            return selection;
        }

        public int PasteScreens(List<Screen> screens) {
            int overwrite = 0;
            foreach(Screen s in screens) {
                s.X += selection.MinX;
                s.Y += selection.MinY;
                if(Story.GetScreen(s.X, s.Y) != null) {
                    s.Conflict = true;
                    overwrite++;
                }
            }
            paste = screens;
            DrawMap();
            return overwrite;
        }

        public void ConfirmPaste() {
            Story.AddScreens(paste);
            paste = null;
            DrawMap();
        }

        public void CancelPaste() {
            paste = null;
            DrawMap();
        }

    }

}
