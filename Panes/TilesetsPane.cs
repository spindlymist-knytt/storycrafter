﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Story_Crafter.Panes {
    public partial class TilesetsPane : DockContent, IEditorPane {
        public TilesetsPane() {
            InitializeComponent();
        }

        void IEditorPane.ChangeScreen(Screen screen) {
            this.screen_tilesetViewA.Image = Program.OpenStory.CreateTileset(screen.TilesetA).Full;
            this.screen_tilesetViewB.Image = Program.OpenStory.CreateTileset(screen.TilesetB).Full;
        }
    }
}