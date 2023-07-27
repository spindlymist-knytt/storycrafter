using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Forms.EditorForm {
    partial class TestTab : UserControl, IEditorTab {

        Story story;
        Random rng = new Random();

        public TestTab() {
            InitializeComponent();
        }

        public void ScreenChanged(Screen screen) {
        }

        public void StoryChanged(Story story) {
            this.story = story;
            this.d3dCanvas1.UpdateStory(story);
        }

        public void TabOpened() {
        }

        private void button1_Click(object sender, EventArgs e) {
            this.d3dCanvas1.Screen = this.story.Screens[rng.Next(this.story.Screens.Count)];
        }

        private void button2_Click(object sender, EventArgs e) {
            this.d3dCanvas1.Screen = this.story.ActiveScreen;
        }
    }
}
