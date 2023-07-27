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
    partial class TilesetsPane : DockContent, IEditorPane {
        Story story;

        public TilesetsPane() {
            InitializeComponent();
        }

        public void ScreenChanged(Screen screen) {
            this.screen_tilesetViewA.Image = story.CreateTileset(screen.TilesetA).Full;
            this.screen_tilesetViewB.Image = story.CreateTileset(screen.TilesetB).Full;
        }

        public void StoryChanged(Story story) {
            this.story = story;
        }
    }
}
