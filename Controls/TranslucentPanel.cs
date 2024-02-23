using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    // A simple control that allows for a semitransparent background.
    public class TranslucentPanel: Panel {
        private SolidBrush fill;
        public override Color BackColor {
            get {
                return base.BackColor;
            }
            set {
                base.BackColor = value;
                this.fill.Color = value;
            }
        }

        public TranslucentPanel() : base() {
            this.fill = new SolidBrush(this.BackColor);
        }
        protected override void OnPaintBackground(PaintEventArgs e) {
            e.Graphics.FillRectangle(fill, 0, 0, this.Width, this.Height);
        }
    }
}
