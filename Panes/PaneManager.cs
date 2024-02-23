using Story_Crafter.Knytt;
using Story_Crafter.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace Story_Crafter.Panes {
    class PaneManager {
        public EditingContext EditingContext {
            get { return editContext; }
            set { editContext = value; }
        }
        EditingContext editContext;

        public RenderingContext RenderingContext {
            get { return renderContext; }
            set { renderContext = value; }
        }
        RenderingContext renderContext;

        DockPanel dockPanel;
        IList<ScreenPane> screenPanes = new List<ScreenPane>();
        ScreenPane lastScreenPane;

        public PaneManager(DockPanel dockPanel) {
            this.dockPanel = dockPanel;
            this.dockPanel.Theme = new VS2015LightTheme();
        }

        public void CreateDefaultPanes() {
            ScreenPane screenPane = CreateScreenPane(null);
            TilesetsPane tilesetsPane = new TilesetsPane(editContext);
            ObjectsPane objectsPane = new ObjectsPane(editContext);
            ToolsPane toolsPane = new ToolsPane(editContext);
            AssetsPane assetsPane = new AssetsPane(editContext);
            MapPane mapPane = new MapPane(this, editContext);

            screenPane.Show(this.dockPanel);

            tilesetsPane.Show(screenPane.Pane, DockAlignment.Bottom, 0.25);
            objectsPane.Show(tilesetsPane.Pane, null);
            tilesetsPane.Activate();

            toolsPane.Show(screenPane.Pane, DockAlignment.Left, 0.15);
            assetsPane.Show(tilesetsPane.Pane, DockAlignment.Left, 0.15);
            mapPane.Show(tilesetsPane.Pane, DockAlignment.Right, 0.33);

            screenPane.Activate();
        }

        public ScreenPane CreateScreenPane(Screen screen) {
            ScreenPane pane = new ScreenPane(screen, editContext, renderContext);

            pane.FormClosed += OnScreenPaneClosed;
            pane.Enter += OnScreenPaneFocused;

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
