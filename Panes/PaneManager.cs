using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace Story_Crafter.Panes {
    class PaneManager {
        DockPanel dockPanel;
        EditingContext context;
        IList<ScreenPane> screenPanes = new List<ScreenPane>();
        ScreenPane lastScreenPane;

        public PaneManager(DockPanel dockPanel, EditingContext context) {
            this.context = context;
            this.dockPanel = dockPanel;
            this.dockPanel.Theme = new VS2015LightTheme();

            ScreenPane screenPane = AddScreenPane(null);
            TilesetsPane tilesetsPane = new TilesetsPane(context);
            ObjectsPane objectsPane = new ObjectsPane(context);
            ToolsPane toolsPane = new ToolsPane(context);
            AssetsPane assetsPane = new AssetsPane(context);
            MapPane mapPane = new MapPane(this, context);

            screenPane.Show(this.dockPanel);

            tilesetsPane.Show(screenPane.Pane, DockAlignment.Bottom, 0.25);
            objectsPane.Show(tilesetsPane.Pane, null);
            tilesetsPane.Activate();

            toolsPane.Show(screenPane.Pane, DockAlignment.Left, 0.15);
            assetsPane.Show(tilesetsPane.Pane, DockAlignment.Left, 0.15);
            mapPane.Show(tilesetsPane.Pane, DockAlignment.Right, 0.33);

            screenPane.Activate();
        }

        public ScreenPane AddScreenPane(Screen screen) {
            ScreenPane pane = new ScreenPane(context, screen);

            pane.FormClosed += OnScreenPaneClosed;
            pane.GotFocus += OnScreenPaneFocused;

            // Priority:
            // 1. Dock to same pane as the last active screen
            // 2. If there are no screens, dock to the active pane
            // 3. If there is no active pane, dock to the first pane
            // 4. If there are no panes, dock to the panel
            if (lastScreenPane != null) {
                pane.Show(lastScreenPane.Pane, null);
            }
            else if (this.dockPanel.ActivePane != null) {
                pane.Show(this.dockPanel.ActivePane, null);
            }
            else if (this.dockPanel.Panes.Count > 0) {
                pane.Show(this.dockPanel.Panes[0], null);
            }
            else {
                pane.Show(this.dockPanel);
            }

            this.screenPanes.Add(pane);
            this.lastScreenPane = pane;

            return pane;
        }

        void OnScreenPaneFocused(object sender, EventArgs e) {
            this.lastScreenPane = sender as ScreenPane;
        }

        void OnScreenPaneClosed(object sender, EventArgs e) {
            ScreenPane pane = sender as ScreenPane;
            this.screenPanes.Remove(pane);

            if (pane == this.lastScreenPane) {
                this.lastScreenPane = this.screenPanes.FirstOrDefault();
            }
        }
    }
}
