﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Story_Crafter {
    public class DragDropListView: ListView {
        #region Scroll
        // Windows messages
        private const int WM_PAINT = 0x000F;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONUP = 0x0202;

        // ScrollBar types
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;

        // ScrollBar interfaces
        private const int SIF_TRACKPOS = 0x10;
        private const int SIF_RANGE = 0x01;
        private const int SIF_POS = 0x04;
        private const int SIF_PAGE = 0x02;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

        // ListView messages
        private const uint LVM_SCROLL = 0x1014;
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETGROUPINFO = (LVM_FIRST + 147);

        public enum ScrollBarCommands: int {
            SB_LINEUP = 0,
            SB_LINELEFT = 0,
            SB_LINEDOWN = 1,
            SB_LINERIGHT = 1,
            SB_PAGEUP = 2,
            SB_PAGELEFT = 2,
            SB_PAGEDOWN = 3,
            SB_PAGERIGHT = 3,
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_TOP = 6,
            SB_LEFT = 6,
            SB_BOTTOM = 7,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);

            switch(m.Msg) {
                case WM_HSCROLL:
                    ScrollEventArgs sargs = new ScrollEventArgs(ScrollEventType.EndScroll, GetScrollPos(this.Handle, SB_HORZ));
                    Scroll(this, sargs);
                    break;

                case WM_MOUSEWHEEL:
                    ScrollEventArgs sarg = new ScrollEventArgs(ScrollEventType.EndScroll, GetScrollPos(this.Handle, SB_HORZ));
                    Scroll(this, sarg);
                    break;

                case WM_KEYDOWN:
                    switch(m.WParam.ToInt32()) {
                        case (int)Keys.Down:
                            Scroll(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, GetScrollPos(this.Handle, SB_HORZ)));
                            break;
                        case (int)Keys.Up:
                            Scroll(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, GetScrollPos(this.Handle, SB_HORZ)));
                            break;
                        case (int)Keys.PageDown:
                            Scroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, GetScrollPos(this.Handle, SB_HORZ)));
                            break;
                        case (int)Keys.PageUp:
                            Scroll(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, GetScrollPos(this.Handle, SB_HORZ)));
                            break;
                        case (int)Keys.Home:
                            Scroll(this, new ScrollEventArgs(ScrollEventType.First, GetScrollPos(this.Handle, SB_HORZ)));
                            break;
                        case (int)Keys.End:
                            Scroll(this, new ScrollEventArgs(ScrollEventType.Last, GetScrollPos(this.Handle, SB_HORZ)));
                            break;
                    }
                    break;
            }

        }

        public int ScrollPosition {
            get {
                return GetScrollPos(this.Handle, SB_HORZ);
            }
            set {
                int prevPos;
                int scrollVal = 0;

                prevPos = GetScrollPos(this.Handle, SB_HORZ);
                scrollVal = -(prevPos - value);

                SendMessage(this.Handle, LVM_SCROLL, (IntPtr)scrollVal, (IntPtr)0);
            }
        }

        public event ScrollEventHandler Scroll;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, long wParam, long lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [StructLayout(LayoutKind.Sequential)]
        struct SCROLLINFO {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        #endregion]

        int dropIndex;
        int scrollSpeed = 0;
        public int Tolerance = 0;
        Timer t = new Timer();

        public DragDropListView() {
            t.Interval = 25;
            t.Tick += delegate {
                this.ScrollPosition += scrollSpeed;
            };

            this.ItemDrag += delegate (object sender, ItemDragEventArgs e) {
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            };
            this.DragEnter += delegate (object sender, DragEventArgs e) {
                e.Effect = DragDropEffects.Move;
                t.Start();
            };
            this.DragOver += delegate (object sender, DragEventArgs e) {
                int x = this.PointToClient(new Point(e.X, e.Y)).X;
                if(x > this.Width - Tolerance) scrollSpeed = (Tolerance - (this.Width - x)) / 10;
                else if(x < Tolerance) scrollSpeed = -(Tolerance - x) / 10;
                else scrollSpeed = 0;
            };
            this.DragDrop += delegate (object sender, DragEventArgs e) {
                t.Stop();
                Point cp = this.PointToClient(new Point(e.X, e.Y));
                ListViewItem dragToItem = this.GetItemAt(cp.X, cp.Y);
                if(dragToItem != null) {
                    dropIndex = dragToItem.Index;
                    ListViewItem i = this.SelectedItems[0];
                    if(dropIndex != i.Index) {
                        ListViewItem newItem = (ListViewItem)i.Clone();
                        this.Items.Insert(dropIndex, newItem); ;
                        i.Remove();

                        // ListViewItemCollection.Insert is bugged, but this is a workaround:
                        this.Alignment = ListViewAlignment.Default;
                        this.Alignment = ListViewAlignment.Left;
                        this.Refresh();

                        newItem.Selected = true;
                    }
                }
            };
        }
    }
}
