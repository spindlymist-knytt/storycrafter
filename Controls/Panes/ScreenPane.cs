using System;
using System.Windows.Forms;

using Story_Crafter.Rendering;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls.Panes {
    partial class ScreenPane : BasePane {
        public Screen Screen { get; private set; }

        EditingContext editContext;
        RenderingContext renderContext;
        DrawTest drawTest1;

        public ScreenPane(Screen screen, EditingContext editContext, RenderingContext renderContext) {
            this.Screen = screen;
            this.editContext = editContext;
            this.renderContext = renderContext;

            InitializeComponent();

            this.editContext.ActiveScreenChanged += OnActiveScreenChanged;
            this.editContext.ToolChanged += OnToolChanged;
            //this.tileCanvas1.EventsHandler = this.context.Tool?.EventsHandler;

            this.drawTest1 = new DrawTest(renderContext);
            this.drawTest1.Dock = DockStyle.Fill;
            this.Controls.Add(this.drawTest1);

            if (screen != null) {
                this.Text = "x" + screen.X + "y" + screen.Y;
                this.drawTest1.Screen = screen;
            }
        }

        void OnActiveScreenChanged(ActiveScreenChangedArgs e) {
            if (e.screen == null) return;
            if (this.Screen != null) return;

            this.Screen = e.screen;
            this.Text = "x" + Screen.X + "y" + Screen.Y;
            this.drawTest1.Screen = this.Screen;
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
            this.drawTest1.Screen = this.Screen;
        }
    }
}
