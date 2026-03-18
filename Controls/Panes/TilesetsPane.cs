using System;
using System.Drawing;
using System.IO;
using Story_Crafter.Editing;
using Story_Crafter.Utility;

namespace Story_Crafter.Controls.Panes {
    partial class TilesetsPane : BasePane {
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
            this.screen_tilesetA.Value = e.screen.TilesetA;
            this.screen_tilesetB.Value = e.screen.TilesetB;
            this.screen_gradient.Value = e.screen.Gradient;

            using Bitmap tilesetA = new(context.Assets.TilesetPath(e.screen.TilesetA));
            using Bitmap tilesetB = new(context.Assets.TilesetPath(e.screen.TilesetB));

            this.screen_tilesetViewA.Image = new Bitmap(tilesetA);
            this.screen_tilesetViewB.Image = new Bitmap(tilesetB);
        }
    }
}
