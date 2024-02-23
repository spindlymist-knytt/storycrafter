using Story_Crafter.Knytt.Primitives;
using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Story_Crafter.Controls.Panes
{
    partial class MapPane : BasePane {
        public EventHandler<Int2> ScreenSelected;

        EditingContext context;

        public MapPane(EditingContext context) {
            this.context = context;

            InitializeComponent();

            this.map_mainView.Story = context.Story;
            this.map_mainView.UpdateScreen += delegate (int x, int y) {
                ScreenSelected.Invoke(this, new Int2(x, y));
            };
        }
    }
}
