﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Story_Crafter.Rendering;
using Story_Crafter.Knytt;

namespace Story_Crafter.Controls {

    class D3DCanvas : System.Windows.Forms.Control {

        bool isDesignEnvironment;
        Brush designBrush;
        D3DRenderer renderer;

        public D3DCanvas() {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
            isDesignEnvironment = process.ProcessName == "devenv";
            process.Dispose();

            if (isDesignEnvironment) {
                designBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.SlateBlue, Color.DarkSlateBlue);
            }
            else {
                renderer = new D3DRenderer(this.Handle);
            }
        }

        public void UpdateStory(Story story) {
            renderer.InstallAssets(story);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (isDesignEnvironment) {
                e.Graphics.FillRectangle(designBrush, ClientRectangle);
                base.OnPaint(e);
                return;
            }

            renderer.Render(Program.ActiveScreen);
        }
    }
}