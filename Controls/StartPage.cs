using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Controls {
    public partial class StartPage : UserControl {
        public event EventHandler<string> StorySelected;

        readonly string worldsPath;

        public StartPage(string worldsPath) {
            this.worldsPath = worldsPath;

            InitializeComponent();
        }

        private void loadStory_Click(object sender, EventArgs e) {
            if (this.storyList.SelectedItems.Count < 1) return;

            string path = Path.Combine(worldsPath, this.storyList.SelectedItems[0].SubItems[2].Text);
            this.StorySelected.Invoke(this, path);
        }

        private void StartPage_Load(object sender, EventArgs e) {
            DirectoryInfo worldsDir = new DirectoryInfo(worldsPath);

            foreach (DirectoryInfo dir in worldsDir.EnumerateDirectories()) {
                string worldIniPath = Path.Combine(dir.FullName, "World.ini");
                string mapBinPath = Path.Combine(dir.FullName, "Map.bin");

                if (
                    !File.Exists(worldIniPath)
                    || !File.Exists(mapBinPath)
                ) {
                    continue;
                }

                var props = Story.Properties.Parser.Parse(worldIniPath);
                this.storyList.Items
                    .Add(props.Author)
                    .SubItems.AddRange(new string[2] {
                        props.Name,
                        dir.FullName,
                    });
            }
        }
    }
}
