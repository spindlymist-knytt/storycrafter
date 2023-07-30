using Story_Crafter.Editing.Tools;
using Story_Crafter.Knytt;
using Story_Crafter.Panes;
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

namespace Story_Crafter.Forms.EditorForm {
    partial class NewScreenTab : UserControl, IEditorTab {
        EditingContext context = new EditingContext();
        PaneManager paneManager;

        public NewScreenTab() {
            InitializeComponent();

            paneManager = new PaneManager(this.dockPanel1, this.context);
        }

        public void ScreenChanged(Screen screen) {
        }

        public void StoryChanged(Story story) {
            this.context.Story = story;
            this.context.ActiveScreen = story.ActiveScreen;
        }

        public void TabOpened() {
        }
    }
}
