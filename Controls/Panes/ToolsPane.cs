using System;

namespace Story_Crafter.Controls.Panes {
    partial class ToolsPane : BasePane {
        EditingContext context;

        public ToolsPane(EditingContext context) {
            this.context = context;
            InitializeComponent();
        }
    }
}
