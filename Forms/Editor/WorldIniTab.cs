using Microsoft.Web.WebView2.Core;
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

namespace Story_Crafter.Forms.Editor {
    // TODO: finish migration to AvEdit
    // TODO: add border to edit control
    public partial class WorldIniTab : UserControl, IEditorTab {
        delegate void MonacoLoadedEventHandler();

        Story story;
        bool monacoIsLoaded = false;
        event MonacoLoadedEventHandler monacoLoaded;

        public WorldIniTab() {
            InitializeComponent();
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
                    monacoLoaded?.Invoke();
                }
                else {
                    Program.Debug.Log("Received invalid message: ", message);
                }
            }
            catch (ArgumentException ex) {
                Program.Debug.Log("Received invalid message: ", ex);
            }
        }

        public void StoryChanged(Story story) {
            this.story = story;
            if (monacoIsLoaded) {
                string iniText = File.ReadAllText(Path.Combine(this.story.Path, "World.ini"));
                SetMonacoText(iniText);
            }
            else {
                monacoLoaded = delegate {
                    string iniText = File.ReadAllText(Path.Combine(this.story.Path, "World.ini"));
                    SetMonacoText(iniText);
                };
            }
        }

        public void TabOpened() {
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
