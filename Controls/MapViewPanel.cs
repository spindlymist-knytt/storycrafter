using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Story_Crafter {

    class MapViewPanel: PictureBox {

        public bool ShowThumbs {
            get { return this.showThumbs; }
            set { this.showThumbs = value; DrawMap(); }
        }
        public Story TheStory {
            get { return this.story; }
            set {
                this.story = value;
                if(this.story != null) CenterScreen(this.story.DefaultSave.MapX, this.story.DefaultSave.MapY);
                else DrawMap();
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

        int startX = 1000, startY = 1000, mapWidth, mapHeight, screenWidth = 25, screenHeight = 10;
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

        public MapViewPanel() {
            selection = new Selection(screenWidth, screenHeight, -1, -1, selectionCursor);
            this.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.ResetSelection(startX, startY);

            this.MouseDown += delegate (object o, MouseEventArgs mouse) {
                mouseDownX = mouse.X;
                mouseDownY = mouse.Y;
                if(mouse.Button == MouseButtons.Right || mouse.Button == MouseButtons.Middle) {
                    origStartX = startX;
                    origStartY = startY;
                    panning = true;
                }
                else if(mouse.Button == MouseButtons.Left) {
                    selectionInProgress = true;
                    selectionStart = new Point(mouse.X / screenWidth + startX, mouse.Y / screenHeight + startY);
                    lastSelection = new Rectangle(selectionStart.X, selectionStart.Y, 1, 1);
                    this.Refresh();
                }
            };
            this.MouseUp += delegate {
                panning = false;
                if(selectionInProgress) {
                    if(ModifierKeys == Keys.Control) {
                        selection.Remove(lastSelection);
                    }
                    else {
                        if(ModifierKeys != Keys.Shift) selection.Clear();
                        selection.Add(lastSelection);
                    }
                    selectionInProgress = false;
                    this.Refresh();
                }
            };
            this.DoubleClick += delegate (object o, EventArgs e) {
                if(updateScreen == null) return;
                updateScreen(mouseDownX / screenWidth + startX, mouseDownY / screenHeight + startY);
                DrawMap();
            };
            this.MouseMove += delegate (object o, MouseEventArgs mouse) {
                //this.Focus();
                if(panning) {
                    int deltaX = mouse.X - mouseDownX;
                    int deltaY = mouse.Y - mouseDownY;
                    startX = origStartX - deltaX / screenWidth;
                    startY = origStartY - deltaY / screenHeight;
                    DrawMap();
                }
                else if(selectionInProgress) {
                    int x = (int)(mouse.X / screenWidth) + startX;
                    int y = (int)(mouse.Y / screenHeight) + startY;
                    lastSelection.X = Math.Min(x, selectionStart.X);
                    lastSelection.Y = Math.Min(y, selectionStart.Y);
                    lastSelection.Width = Math.Abs(x - selectionStart.X) + 1;
                    lastSelection.Height = Math.Abs(y - selectionStart.Y) + 1;
                    this.Refresh();
                }
                int hoverX = startX + mouse.X / screenWidth;
                int hoverY = startY + mouse.Y / screenHeight;
                updateStatus?.Invoke(hoverX, hoverY);
            };
            this.MouseWheel += delegate (object o, MouseEventArgs mouse) {
                int d = mouse.Delta / 120;
                while(d != 0) {
                    if(d < 0) {
                        if(screenHeight == 10) break; // Reached minimum zoom level.
                        screenHeight /= 2;
                        screenWidth /= 2;
                        d++;
                    }
                    else {
                        if(screenHeight == 80) break; // Reached maximum zoom level.
                        screenHeight *= 2;
                        screenWidth *= 2;
                        d--;
                    }
                }

                // Find the center screen.
                int centerX = startX + mapWidth / 2;
                int centerY = startY + mapHeight / 2;

                mapWidth = this.Width / screenWidth;
                mapHeight = this.Height / screenHeight;

                this.CenterScreen(centerX, centerY);
                selection.ChangeCellSize(screenWidth, screenHeight);
                DrawGridLines();
            };
            this.Paint += delegate (object sender, PaintEventArgs e) {
                if(story == null) return;
                e.Graphics.DrawImage(selection.Borders,
                  new Rectangle(
                    (selection.MinX - startX) * screenWidth,
                    (selection.MinY - startY) * screenHeight,
                    selection.Borders.Width,
                    selection.Borders.Height
                  ),
                  new Rectangle(0, 0, selection.Borders.Width, selection.Borders.Height),
                  GraphicsUnit.Pixel);
                e.Graphics.DrawRectangle(activeScreenOutline, new Rectangle((story.ActiveScreen.X - startX) * screenWidth, (story.ActiveScreen.Y - startY) * screenHeight, screenWidth - 1, screenHeight - 1));
                if(selectionInProgress) e.Graphics.DrawRectangle(newSelectionCursor, (lastSelection.X - startX) * screenWidth, (lastSelection.Y - startY) * screenHeight, lastSelection.Width * screenWidth - 1, lastSelection.Height * screenHeight - 1);
            };
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            this.mapWidth = this.Width / screenWidth;
            this.mapHeight = this.Height / screenHeight;
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
            this.BackgroundImage = new Bitmap(600, 480);
            if(story != null) {
                Graphics g = Graphics.FromImage(this.BackgroundImage);
                Rectangle src = new Rectangle(0, 0, 200, 80);
                foreach(Screen s in story.Screens) {
                    int offX = s.X - startX;
                    int offY = s.Y - startY;
                    if(offX >= 0 && offX < mapWidth && offY >= 0 && offY < mapHeight) {
                        Rectangle area = new Rectangle(offX * screenWidth, offY * screenHeight, screenWidth, screenHeight);
                        if(this.showThumbs && s.Thumbnail != null) {
                            g.DrawImage(s.Thumbnail, area, src, GraphicsUnit.Pixel);
                        }
                        else {
                            g.FillRectangle(s == story.ActiveScreen ? activeScreenFill : screenFill, area);
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
                if(TheStory.GetScreen(s.X, s.Y) != null) {
                    s.Conflict = true;
                    overwrite++;
                }
            }
            paste = screens;
            DrawMap();
            return overwrite;
        }

        public void ConfirmPaste() {
            TheStory.AddScreens(paste);
            paste = null;
            DrawMap();
        }

        public void CancelPaste() {
            paste = null;
            DrawMap();
        }

    }

}

/*
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Story_Crafter {

  class MapViewPanel: PictureBox {

    public bool ShowThumbs {
      get { return this.showThumbs; }
      set { this.showThumbs = value; DrawMap(); }
    }
    public Story TheStory {
      get { return this.story; }
      set { this.story = value; DrawMap(); }
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

    int startX = 998, startY = 998, mapWidth = 5, mapHeight = 8, screenWidth = 200, screenHeight = 80;
    int origStartX, origStartY, mouseDownX, mouseDownY;
    Pen p = new Pen(Color.FromArgb(25, 0, 0, 0));
    Pen p2 = new Pen(Color.FromArgb(25, 255, 255, 255));
    Pen activeScreenOutline = new Pen(Color.Orchid);
    Brush screenFill = new SolidBrush(Color.FromArgb(58, 102, 135));
    Brush activeScreenFill = new SolidBrush(Color.FromArgb(171, 199, 243));
    bool panning = false;

    bool selectionInProgress = false;
    Point selectionStart;
    Rectangle selection;

    Story story;
    bool showThumbs = false;
    UpdateScreenEvent updateScreen;
    UpdateStatusEvent updateStatus;

    public MapViewPanel() {
      this.BackColor = Color.FromArgb(0, 0, 0, 0);
      this.MouseDown += delegate (object o, MouseEventArgs mouse) {
        mouseDownX = mouse.X;
        mouseDownY = mouse.Y;
        if(mouse.Button == MouseButtons.Right || mouse.Button == MouseButtons.Middle) {
          origStartX = startX;
          origStartY = startY;
          panning = true;
        }
        else if(mouse.Button == MouseButtons.Left) {
          selectionStart = new Point(mouse.X / screenWidth + startX, mouse.Y / screenHeight + startY);
          selection = new Rectangle(selectionStart.X, selectionStart.Y, 1, 1);
          selectionInProgress = true;
          this.Refresh();
        }
      };
      this.MouseUp += delegate { panning = false; selectionInProgress = false; };
      this.DoubleClick += delegate (object o, EventArgs e) {
        if(updateScreen == null) return;
        updateScreen(mouseDownX / screenWidth + startX, mouseDownY / screenHeight + startY);
        DrawMap();
      };
      this.MouseMove += delegate (object o, MouseEventArgs mouse) {
        this.Focus();
        if(panning) {
          int deltaX = mouse.X - mouseDownX;
          int deltaY = mouse.Y - mouseDownY;
          startX = origStartX - deltaX / screenWidth;
          startY = origStartY - deltaY / screenHeight;
          DrawMap();
        }
        else if(selectionInProgress) {
          int x = (int)(mouse.X / screenWidth) + startX;
          int y = (int)(mouse.Y / screenHeight) + startY;
          selection.X = Math.Min(x, selectionStart.X);
          selection.Y = Math.Min(y, selectionStart.Y);
          selection.Width = Math.Abs(x - selectionStart.X) + 1;
          selection.Height = Math.Abs(y - selectionStart.Y) + 1;
          this.Refresh();
        }
        int hoverX = startX + mouse.X / screenWidth;
        int hoverY = startY + mouse.Y / screenHeight;
        updateStatus?.Invoke(hoverX, hoverY);
      };
      this.MouseWheel += delegate (object o, MouseEventArgs mouse) {
        int d = mouse.Delta / 120;
        while(d != 0) {
          if(d < 0) {
            if(screenHeight == 10) break; // Reached minimum zoom level.
            screenHeight /= 2;
            screenWidth /= 2;
            d++;
          }
          else {
            if(screenHeight == 80) break; // Reached maximum zoom level.
            screenHeight *= 2;
            screenWidth *= 2;
            d--;
          }
        }

        // Find the center screen.
        startX += mapWidth / 2;
        startY += mapHeight / 2;

        mapWidth = this.Width / screenWidth;
        mapHeight = this.Height / screenHeight;

        // Center the screen we found above.
        startX -= mapWidth / 2;
        startY -= mapHeight / 2;

        DrawGridLines();
        DrawMap();
      };
      this.Paint += delegate (object sender, PaintEventArgs e) {
        if(story == null) return;
        e.Graphics.DrawRectangle(new Pen(Color.Orange), new Rectangle((selection.X - startX) * screenWidth, (selection.Y - startY) * screenHeight, selection.Width * screenWidth - 1, selection.Height * screenHeight - 1));
        e.Graphics.DrawRectangle(activeScreenOutline, new Rectangle((story.ActiveScreen.X - startX) * screenWidth, (story.ActiveScreen.Y - startY) * screenHeight, screenWidth - 1, screenHeight - 1));
      };

      DrawGridLines();
      DrawMap();
    }

    private void DrawGridLines() {
      this.Image = new Bitmap(600, 480);
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

    private void DrawMap() {
      if(story == null) return;
      this.BackgroundImage = new Bitmap(600, 480);
      Graphics g = Graphics.FromImage(this.BackgroundImage);
      Rectangle src = new Rectangle(0, 0, 200, 80);
      foreach(Screen s in story.Screens) {
        int offX = s.X - startX;
        int offY = s.Y - startY;
        if(offX >= 0 && offX < mapWidth && offY >= 0 && offY < mapHeight) {
          Rectangle area = new Rectangle(offX * screenWidth, offY * screenHeight, screenWidth, screenHeight);
          if(this.showThumbs) {
            g.DrawImage(s.Thumbnail, area, src, GraphicsUnit.Pixel);
          }
          else {
            g.FillRectangle(s == story.ActiveScreen ? activeScreenFill : screenFill, area);
          }
        }
      }
      this.Refresh();
    }

  }

}
*/
