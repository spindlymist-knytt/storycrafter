using System.Windows.Forms;

namespace Story_Crafter.Controls.Tabs {
    public interface IEditorTab {
        public string Title { get; }
        public Control Control { get; }

        void EnterTab();
        void LeaveTab();
    }
}
