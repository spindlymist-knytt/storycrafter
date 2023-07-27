using Story_Crafter.Knytt;
using Story_Crafter.Panes;
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

namespace Story_Crafter.Forms.EditorForm {
    partial class NewScreenTab : UserControl, IEditorTab {

        Story story;
        ScreenPane screenPane = new ScreenPane();
        TilesetsPane tilesetsPane = new TilesetsPane();
        ObjectsPane objectsPane = new ObjectsPane();
        ToolsPane toolsPane = new ToolsPane();
        AssetsPane assetsPane = new AssetsPane();
        MapPane mapPane = new MapPane();
        List<IEditorPane> panes;

        public NewScreenTab() {
            InitializeComponent();

            this.dockPanel1.Theme = new VS2015LightTheme();

            screenPane.Show(this.dockPanel1);

            tilesetsPane.Show(screenPane.Pane, DockAlignment.Bottom, 0.25);
            objectsPane.Show(tilesetsPane.Pane, null);
            tilesetsPane.Activate();

            toolsPane.Show(screenPane.Pane, DockAlignment.Left, 0.15);
            assetsPane.Show(tilesetsPane.Pane, DockAlignment.Left, 0.15);
            mapPane.Show(tilesetsPane.Pane, DockAlignment.Right, 0.33);
            mapPane.UpdateScreen = delegate (int x, int y) {
                ScreenPane pane = new ScreenPane();
                pane.Show(screenPane.Pane, null);
                (pane as IEditorPane).StoryChanged(story);
                (pane as IEditorPane).ScreenChanged(story.GetScreen(x, y));
            };

            screenPane.Activate();

            panes = new List<IEditorPane>() {
                screenPane,
                tilesetsPane,
                objectsPane,
                toolsPane,
                assetsPane,
                mapPane,
            };
        }

        public void ScreenChanged(Screen screen) {
            foreach (IEditorPane pane in panes) {
                pane.ScreenChanged(screen);
            }
        }

        public void StoryChanged(Story story) {
            this.story = story;
            foreach (IEditorPane pane in panes) {
                pane.StoryChanged(story);
            }
        }

        public void TabOpened() {
        }
    }
}
