using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Panes {
    partial class AssetsPane : DockContent {
        public AssetsPane(EditingContext context) {
            InitializeComponent();

            context.ActiveScreenChanged += this.OnActiveScreenChanged;
        }

        public void OnActiveScreenChanged(ActiveScreenChangedArgs e) {
            this.screen_tilesetA.Value = e.screen.TilesetA;
            this.screen_tilesetB.Value = e.screen.TilesetB;
            this.screen_gradient.Value = e.screen.Gradient;
            this.screen_ambiA.Value = e.screen.AmbianceA;
            this.screen_ambiB.Value = e.screen.AmbianceB;
            this.screen_music.Value = e.screen.Music;
        }
    }
}
