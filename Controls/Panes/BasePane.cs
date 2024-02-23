using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using Story_Crafter.Utility;

namespace Story_Crafter.Controls.Panes
{
    public class BasePane : DockContent {
        private readonly DisposableBag disposables = new();

        protected override void OnControlRemoved(ControlEventArgs e) {
            base.OnControlRemoved(e);
            disposables.Dispose();
        }

        protected void Autodispose(IDisposable subscription) {
            disposables.Add(subscription);
        }
    }
}
