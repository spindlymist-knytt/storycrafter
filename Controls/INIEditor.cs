using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    // This is just a fancy textbox that highlights itself.
    // Some black magic going on here; beware ye who meddle here.
    class INIEditor: RichTextBox {
        bool paint = true;
        public enum StopAt { EndOfLine, EndOfFile, Length };

        // Highlighting colors.
        Color colorText = Color.Black;
        Color colorComment = Color.Gray;
        Color colorSection = Color.Green;
        Color colorKey = Color.Blue;
        Color colorOp = Color.Gray;

        int lastIndexHighlighted;

        public INIEditor() {
            this.KeyUp += this.doHighlight;
            this.VScroll += delegate {
                int start = this.GetCharIndexFromPosition(new Point(0, 0));
                int stop = this.GetCharIndexFromPosition(new Point(this.Width, this.Height));
                this.Highlight(start, StopAt.Length, stop - start);
            };
        }
        protected override void WndProc(ref Message m) {
            if(m.Msg != 0x00F || paint) // 0x00F: WM_PAINT
                base.WndProc(ref m);
            else
                m.Result = IntPtr.Zero;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) { // So we can format pasted text.
            if(keyData == (Keys.Control | Keys.V)) {
                int start = this.SelectionStart;
                this.Paste();
                this.paint = false;
                this.SelectionLength = this.SelectionStart - start;
                this.SelectionStart = start;
                this.SelectionFont = this.Font;
                this.SelectionStart = start + this.SelectionLength;
                this.SelectionLength = 0;
                this.Highlight(start, StopAt.Length, this.SelectionStart - start);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void doHighlight(object sender, KeyEventArgs e) {
            if(e.KeyData == (Keys.Shift | Keys.Left)) return; // If we process this, shift+left arrow will not work correctly because the selection direction will not be preserved.
            this.Highlight(this.SelectionStart, StopAt.EndOfLine);
        }
        public void Highlight(int start = 0, StopAt stop = StopAt.EndOfFile, int length = 0) {
            this.paint = false; // Disable painting so you don't see all the selections flickering about.
            int saveStart = this.SelectionStart; // To restore the selection when we are done.
            int saveLength = this.SelectionLength;
            int position = 0;
            foreach(string s in this.Lines) { // Probably not the most efficient way, but it works.
                if(position + s.Length >= start) {
                    this.highlightLine(position, s);
                    if(stop == StopAt.EndOfLine) break;
                }
                position += s.Length + 1; // One more for newline.
                if(stop == StopAt.Length && position - start >= length) break;
            }
            this.SelectionStart = saveStart;
            this.SelectionLength = saveLength;
            this.paint = true;
        }
        public void HighlightVisible() {
            int start = this.GetCharIndexFromPosition(new Point(0, 0));
            int end = this.GetCharIndexFromPosition(new Point(this.Width, this.Height));
            this.Highlight(start, StopAt.Length, end - start);
            lastIndexHighlighted = end;
        }
        void highlightLine(int start, string line) {
            bool textFound = false;
            for(int i = 0; i < line.Length; i++) {
                if(!textFound && line[i] == ';') {
                    this.SelectionStart = start;
                    this.SelectionLength = line.Length;
                    this.SelectionColor = this.colorComment;
                    return;
                }
                if(!textFound && line[i] == '[') {
                    this.SelectionStart = start;
                    this.SelectionLength = line.Length;
                    this.SelectionColor = this.colorSection;
                    return;
                }
                if(line[i] == '=') {
                    this.SelectionStart = start;
                    this.SelectionLength = i;
                    this.SelectionColor = this.colorKey;

                    this.SelectionStart = start + i;
                    this.SelectionLength = 1;
                    this.SelectionColor = this.colorOp;

                    this.SelectionStart = start + i + 1;
                    this.SelectionLength = line.Length - i - 1;
                    this.SelectionColor = this.colorText;
                    return;
                }
                if(!char.IsWhiteSpace(line[i])) textFound = true;
            }
            this.SelectionStart = start;
            this.SelectionLength = line.Length;
            this.SelectionColor = this.colorText;
        }
    }
}
