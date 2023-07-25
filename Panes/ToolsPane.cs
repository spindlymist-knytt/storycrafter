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

namespace Story_Crafter.Panes {
    public partial class ToolsPane : DockContent, IEditorPane {
        public ToolsPane() {
            InitializeComponent();
        }

        void IEditorPane.ChangeScreen(Screen screen) {
        }
    }
}
