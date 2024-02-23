using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Story_Crafter.Knytt;
using Story_Crafter.Panes;
using Story_Crafter.Rendering;
using Story_Crafter.Controls;
using Screen = Story_Crafter.Knytt.Screen;
using System.Linq;

namespace Story_Crafter.Forms.Editor {
    public partial class ScreenTab : UserControl, IEditorTab {
        EditingContext editContext = new EditingContext();
        RenderingContext renderContext;
        PaneManager paneManager;

        public ScreenTab() {
            InitializeComponent();

            this.renderingContextProvider1.RenderingContextReady += OnRenderingContextReady;

            this.paneManager = new PaneManager(this.dockPanel1);
            this.paneManager.EditingContext = this.editContext;
        }

        void OnRenderingContextReady(object sender, RenderingContext renderContext) {
            this.renderContext = renderContext;
            this.paneManager.RenderingContext = this.renderContext;
            this.paneManager.CreateDefaultPanes();

            this.StoryChanged(editContext.Story);
        }

        public void StoryChanged(Story story) {
            this.editContext.Story = story;
            if (this.renderContext != null) {
                this.renderContext.Assets = this.editContext.Assets;
            }

            this.editContext.ActiveScreen =
                story.GetScreen(story.DefaultSave.MapX, story.DefaultSave.MapY)
                ?? story.GetScreen(1000, 1000)
                ?? story.Screens.First().Value;

        }

        public void TabOpened() {
        }
    }
}
