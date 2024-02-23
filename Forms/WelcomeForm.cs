using System;
using System.Windows.Forms;

namespace Story_Crafter.Forms {
    public partial class WelcomeForm : Form {
        public string KsDirectory { get; private set; }

        public WelcomeForm() {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);

            FolderBrowserDialog browserDlg = new FolderBrowserDialog();
            browserDlg.Description = "Please select the folder that contains Knytt Stories.exe.";

            if (browserDlg.ShowDialog(this) == DialogResult.OK) {
                KsDirectory = browserDlg.SelectedPath;
            }

            this.Close();
        }
    }
}
