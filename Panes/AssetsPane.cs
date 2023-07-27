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
    partial class AssetsPane : DockContent, IEditorPane {
        public AssetsPane() {
            InitializeComponent();
        }

        public void ScreenChanged(Screen screen) {
            this.screen_tilesetA.Value = screen.TilesetA;
            this.screen_tilesetB.Value = screen.TilesetB;
            this.screen_gradient.Value = screen.Gradient;
            this.screen_ambiA.Value = screen.AmbianceA;
            this.screen_ambiB.Value = screen.AmbianceB;
            this.screen_music.Value = screen.Music;
        }

        public void StoryChanged(Story story) {
        }
    }
}
