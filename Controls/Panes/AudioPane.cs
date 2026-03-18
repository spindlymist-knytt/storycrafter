using System;
using WeifenLuo.WinFormsUI.Docking;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls.Panes {
    partial class AudioPane : BasePane {
        public AudioPane(EditingContext context) {
            InitializeComponent();

            context.ActiveScreenChanged += this.OnActiveScreenChanged;
        }

        public void OnActiveScreenChanged(ActiveScreenChangedArgs e) {
            this.screen_ambiA.Value = e.screen.AmbianceA;
            this.screen_ambiB.Value = e.screen.AmbianceB;
            this.screen_music.Value = e.screen.Music;
        }
    }
}
