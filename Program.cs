using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Story_Crafter.Forms;

namespace Story_Crafter {
    static class Program {
        public static LogsForm Debug;
        public static Random Rng = new();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Debug = new LogsForm();
            Debug.Show();

            Editor editor = new();
            Application.Run(editor.Form);
        }
    }
}
