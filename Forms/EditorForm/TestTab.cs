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

        Random rng = new Random();

        public TestTab() {
            InitializeComponent();
        }

        public void ScreenChanged() {
        }

        public void StoryChanged() {
            this.d3dCanvas1.UpdateStory(Program.OpenStory);
        }

        public void TabOpened() {
        }

        private void button1_Click(object sender, EventArgs e) {
            this.d3dCanvas1.Screen = Program.OpenStory.Screens[rng.Next(Program.OpenStory.Screens.Count)];
        }

        private void button2_Click(object sender, EventArgs e) {
            this.d3dCanvas1.Screen = Program.ActiveScreen;
        }
    }
}
