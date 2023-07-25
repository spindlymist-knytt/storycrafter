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
    public partial class MapPane : DockContent, IEditorPane {
        public delegate void UpdateScreenEvent(int x, int y);

        public UpdateScreenEvent UpdateScreen {
            set {
                this.map_mainView.UpdateScreen = delegate (int x, int y) {
                    value(x, y);
                };
            }
        }

        public MapPane() {
            InitializeComponent();
        }

        void IEditorPane.ChangeScreen(Screen screen) {
            this.map_mainView.TheStory = Program.OpenStory;
        }
    }
}
