using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Forms.EditorForm {
    public partial class TestTab : UserControl, IEditorTab {
        public TestTab() {
            InitializeComponent();
        }

        public void ScreenChanged() {
        }

        public void StoryChanged() {
            this.dxCanvas1.UpdateStory(Program.OpenStory);
        }

        public void TabOpened() {
        }
    }
}
