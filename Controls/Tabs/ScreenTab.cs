using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Story_Crafter.Controls.Panes;
using Story_Crafter.Knytt.Primitives;
using WeifenLuo.WinFormsUI.Docking;

using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls.Tabs {
    public partial class ScreenTab : BaseEditorTab {
        public override string Title => "Screen";

        EditingContext editContext;
        IList<ScreenPane> screenPanes = new List<ScreenPane>();
        ScreenPane lastScreenPane;

        public ScreenTab(Editor editor) : base(editor) {
            InitializeComponent();

            var theme = new VS2015LightTheme();
            theme.ColorPalette.MainWindowActive.Background = System.Drawing.SystemColors.Window;
            this.dockPanel.Theme = theme;

            this.editContext = new EditingContext(Editor.Story, Editor.Assets);
            this.editContext.ActiveScreen =
                Editor.Story.Value[Editor.Story.Value.DefaultSave.Screen]
                ?? Editor.Story.Value[1000, 1000]
                ?? Editor.Story.Value.Screens.Values.First();

            CreateDefaultPanes();
        }

        public void CreateDefaultPanes() {
            ScreenPane screenPane = CreateScreenPane(editContext.ActiveScreen);
            TilesetsPane tilesetsPane = new(editContext);
            ObjectsPane objectsPane = new(editContext);
            ToolsPane toolsPane = new(editContext);
            AudioPane audioPane = new(editContext);
            TestingPane testingPane = new(editContext);
            MapPane mapPane = new(editContext);
            mapPane.ScreenSelected += delegate (object _, Int2 position) {
                if (Editor.Story.Value.Screens.TryGetValue(position, out Screen screen)) {
                    CreateScreenPane(screen);
                }
            };

            screenPane.Show(dockPanel);

            tilesetsPane.Show(screenPane.Pane, DockAlignment.Bottom, 0.25);
            objectsPane.Show(tilesetsPane.Pane, null);
            tilesetsPane.Activate();

            toolsPane.Show(screenPane.Pane, DockAlignment.Left, 0.15);

            audioPane.Show(tilesetsPane.Pane, DockAlignment.Left, 0.15);
            testingPane.Show(audioPane.Pane, null);
            audioPane.Activate();

            mapPane.Show(tilesetsPane.Pane, DockAlignment.Right, 0.33);

            screenPane.Activate();
        }

        ScreenPane CreateScreenPane(Screen screen) {
            ScreenPane pane = new ScreenPane(screen, editContext, Editor.RenderContext);

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
            else if (dockPanel.ActivePane != null) {
                pane.Show(dockPanel.ActivePane, null);
            }
            else if (dockPanel.Panes.Count > 0) {
                pane.Show(dockPanel.Panes[0], null);
            }
            else {
                pane.Show(dockPanel);
            }

            screenPanes.Add(pane);
            lastScreenPane = pane;

            return pane;
        }

        void OnScreenPaneFocused(object sender, EventArgs e) {
            lastScreenPane = sender as ScreenPane;
            editContext.ActiveScreen = (sender as ScreenPane).Screen;
        }

        void OnScreenPaneClosed(object sender, EventArgs e) {
            ScreenPane pane = sender as ScreenPane;
            screenPanes.Remove(pane);

            if (pane == lastScreenPane) {
                lastScreenPane = screenPanes.FirstOrDefault();
            }
        }
    }
}
