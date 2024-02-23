using Story_Crafter.Controls;
using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Forms.Editor {
    public partial class TestTab : UserControl, IEditorTab {
        public TestTab() {
            InitializeComponent();
        }

        public void ScreenChanged(Screen screen) {
        }

        public void StoryChanged(Story story) {
        }

        public void TabOpened() {
        }

        private void button1_Click(object sender, EventArgs e) {
            //Screen screen = this.story.Screens[rng.Next(this.story.Screens.Count)];
            //this.drawTest1.UploadScreenData(screen);
        }

        private void button2_Click(object sender, EventArgs e) {
            //this.drawTest1.UploadScreenData(this.story.ActiveScreen);
        }
    }
}
