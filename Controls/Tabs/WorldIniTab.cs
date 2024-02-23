using Microsoft.Web.WebView2.Core;
using Story_Crafter.Controls.Tabs;
using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Controls.Tabs {
    public partial class WorldIniTab : BaseEditorTab {
        public override string Title => "World.ini";

        bool monacoIsLoaded = false;
        event Action MonacoLoaded;

        public WorldIniTab(Editor editor) : base(editor) {
            InitializeComponent();

            MonacoLoaded += delegate {
                string iniText = File.ReadAllText(Path.Combine(Editor.Story.Value.Path, "World.ini"));
                SetMonacoText(iniText);
            };
            InitializeWebViewAsync();
        }

        private async void InitializeWebViewAsync() {
            await this.webView.EnsureCoreWebView2Async(null);

            string rootFolder = Path.Combine(Application.StartupPath, @"Resources\Monaco\");
            this.webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "monaco",
                rootFolder,
                CoreWebView2HostResourceAccessKind.DenyCors);

            this.webView.CoreWebView2.WebMessageReceived += OnWebMessageReceived;
            this.webView.CoreWebView2.Navigate("https://monaco/index.html");
        }

        void OnWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e) {
            try {
                string message = e.TryGetWebMessageAsString();
                if (message == "ready") {
                    monacoIsLoaded = true;
                    MonacoLoaded.Invoke();
                }
                else {
                    Program.Debug.Log("Received invalid message: ", message);
                }
            }
            catch (ArgumentException ex) {
                Program.Debug.Log("Received invalid message: ", ex);
            }
        }

        void SetMonacoText(string text) {
            text.Replace(@"\", @"\\");
            text.Replace(@"`", @"\`");
            string script = String.Format(@"editor.getModel().setValue(`{0}`);", text);
            this.webView.ExecuteScriptAsync(script);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            this.webView.Size = this.ClientSize;
        }
    }
}
