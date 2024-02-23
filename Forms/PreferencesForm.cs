using System;
using System.Windows.Forms;

namespace Story_Crafter.Forms {
    public partial class PreferencesForm : Form {
        public PreferencesForm() {
            InitializeComponent();

            this.button2.Click += delegate (object sender, EventArgs e) {
                FolderBrowserDialog browserDlg = new FolderBrowserDialog();
                browserDlg.Description = "Please select the folder that contains Knytt Stories.exe.";
                if (browserDlg.ShowDialog(this) == DialogResult.OK) {
                    this.textBox1.Text = browserDlg.SelectedPath;
                }
            };
        }

        private void button4_Click(object sender, EventArgs e) {
            // TODO Save path
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PreferencesForm_Shown(object sender, EventArgs e) {
        }
    }
}
