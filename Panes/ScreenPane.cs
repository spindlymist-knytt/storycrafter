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
using Story_Crafter.Editing;
using Story_Crafter.Editing.Tools;
using Story_Crafter.Rendering;
using Screen = Story_Crafter.Knytt.Screen;
using Story_Crafter.Knytt;
using Story_Crafter.Controls;

namespace Story_Crafter.Panes
{
    partial class ScreenPane : DockContent {
        EditingContext editContext;
        RenderingContext renderContext;
        Screen screen;
        DrawTest drawTest1;

        public ScreenPane(Screen screen, EditingContext editContext, RenderingContext renderContext) {
            this.screen = screen;
            this.editContext = editContext;
            this.renderContext = renderContext;

            InitializeComponent();

            this.editContext.ActiveScreenChanged += OnActiveScreenChanged;
            this.editContext.ToolChanged += OnToolChanged;
            this.editContext.StoryChanged += OnStoryChanged;
            //this.tileCanvas1.EventsHandler = this.context.Tool?.EventsHandler;

            this.drawTest1 = new DrawTest(renderContext);
            this.drawTest1.Dock = DockStyle.Fill;
            this.Controls.Add(this.drawTest1);

            if (screen != null) {
                this.Text = "x" + screen.X + "y" + screen.Y;
                this.drawTest1.Screen = screen;
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
            if (this.screen == null) return;

            this.editContext.ActiveScreen = this.screen;
        }

        void OnStoryChanged(StoryChangedArgs e) {
        }

        void OnActiveScreenChanged(ActiveScreenChangedArgs e) {
            if (e.screen == null) return;
            if (this.screen != null) return;

            this.screen = e.screen;
            this.Text = "x" + screen.X + "y" + screen.Y;
            this.drawTest1.Screen = screen;
        }

        void OnToolChanged(ToolChangedArgs e) {
            //this.tileCanvas1.EventsHandler = e.tool.EventsHandler;
        }

        protected override void OnFormClosed(FormClosedEventArgs e) {
            base.OnFormClosed(e);
            this.drawTest1.Dispose();
        }

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);
            this.drawTest1.Screen = this.screen;
        }
    }
}
