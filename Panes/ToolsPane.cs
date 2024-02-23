using Story_Crafter.Editing.Tools;
using Story_Crafter.Knytt;
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
    partial class ToolsPane : DockContent {
        EditingContext context;

        public ToolsPane(EditingContext context) {
            this.context = context;

            InitializeComponent();

            this.context.Tool = new PaintTool(context);
        }
    }
}
