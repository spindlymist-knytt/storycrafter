using System;
using WeifenLuo.WinFormsUI.Docking;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls.Panes {
    partial class AssetsPane : BasePane {
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
