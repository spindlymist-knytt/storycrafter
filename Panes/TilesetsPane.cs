using Story_Crafter.Editing;
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
    partial class TilesetsPane : DockContent {
        EditingContext context;

        public TilesetsPane(EditingContext context) {
            this.context = context;

            InitializeComponent();

            context.ActiveScreenChanged += OnActiveScreenChanged;
            this.screen_tilesetViewA.SelectionChanged += delegate (TileSelection selection) {
                this.context.TilesetSelection = Tuple.Create(0, selection as Selection);
            };
            this.screen_tilesetViewB.SelectionChanged += delegate (TileSelection selection) {
                this.context.TilesetSelection = Tuple.Create(1, selection as Selection);
            };

            this.context.TilesetSelection = Tuple.Create(0, this.screen_tilesetViewA.Selection as Selection);
        }

        public void OnActiveScreenChanged(ActiveScreenChangedArgs e) {
            this.screen_tilesetViewA.Image = context.Story.CreateTileset(e.screen.TilesetA).Full;
            this.screen_tilesetViewB.Image = context.Story.CreateTileset(e.screen.TilesetB).Full;
        }
    }
}
