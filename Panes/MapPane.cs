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
    partial class MapPane : DockContent {
        EditingContext context;
        PaneManager paneManager;

        public MapPane(PaneManager paneManager, EditingContext context) {
            this.context = context;

            InitializeComponent();

            this.context.StoryChanged += OnStoryChanged;
            this.map_mainView.UpdateScreen += delegate (int x, int y) {
                paneManager.AddScreenPane(this.context.Story.GetScreen(x, y));
            };
        }

        void OnStoryChanged(StoryChangedArgs e) {
            this.map_mainView.Story = e.story;
        }
    }
}
