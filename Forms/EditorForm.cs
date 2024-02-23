using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Story_Crafter;
using Story_Crafter.Controls;
using Story_Crafter.Controls.Panes;
using Story_Crafter.Controls.Tabs;
using Story_Crafter.Knytt;
using Story_Crafter.Rendering;
using Story_Crafter.Utility;

namespace Story_Crafter.Forms {
    // TODO: add analyze tab: wallswim, unsmooth collision surfaces, ...
    // TODO: cutscenes tab
    // TODO: custom objects tab
    public partial class EditorForm : Form {
        public event EventHandler<RenderingContext> RenderingContextReady;
        public event EventHandler<string> StorySelected;

        Editor editor;
        DisposableBag disposables = new();
        StartPage startPage;

        TabControl tabControl;
        IEditorTab[] tabs;
        int previousTabIndex;

        public EditorForm(Editor editor) {
            this.editor = editor;

            disposables.Add(editor.Story.Subscribe(story => {
                this.Text = story.Title + " - Story Crafter";
            }));

            InitializeComponent();
        }

        void SwitchToStartPage() {
            if (startPage != null) return;

            DestroyTabControl();

            this.startPage = new StartPage(editor.Paths.Worlds);
            this.startPage.Dock = DockStyle.Fill;
            this.startPage.Margin = Padding.Empty;
            this.startPage.Size = this.panel1.Size;
            this.startPage.StorySelected += OnStorySelected;
            this.panel1.Controls.Add(startPage);
        }

        void DestroyStartPage() {
            if (startPage == null) return;

            this.startPage.StorySelected -= OnStorySelected;
            this.panel1.Controls.Remove(this.startPage);
            this.startPage.Dispose();
            this.startPage = null;
        }

        void SwitchToTabControl() {
            if (tabControl != null) return;

            DestroyStartPage();

            this.tabControl = new TabControl();
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Margin = Padding.Empty;
            this.tabControl.Size = this.panel1.Size;

            tabs = new IEditorTab[] {
                new OverviewTab(editor),
                new ScreenTab(editor),
                new MapTab(editor),
                new WorldIniTab(editor),
                new TestTab(editor),
            };

            foreach (var tab in tabs) {
                tab.Control.Dock = DockStyle.Fill;

                TabPage page = new TabPage();
                page.Text = tab.Title;
                page.Controls.Add(tab.Control);

                tabControl.TabPages.Add(page);
            }

            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            this.panel1.Controls.Add(tabControl);

            previousTabIndex = 0;
            tabs[0].EnterTab();
        }

        void DestroyTabControl() {
            if (tabControl == null) return;

            this.panel1.Controls.Remove(this.tabControl);
            this.tabControl.Dispose();
            this.tabControl = null;
        }

        private void OnStorySelected(object sender, string path) {
            this.StorySelected.Invoke(this, path);
            this.SwitchToTabControl();
        }

        void OnRenderingContextReady(object sender, RenderingContext renderContext) {
            this.RenderingContextReady.Invoke(this, renderContext);
            this.SwitchToStartPage();
        }

        protected override void OnFormClosed(FormClosedEventArgs e) {
            base.OnFormClosed(e);
            disposables.Dispose();
        }

        //protected override void OnShown(EventArgs e) {
        //    base.OnShown(e);

        //    if (editor.Paths.KS == "") {
        //        WelcomeForm welcome = new();
        //        if (welcome.ShowDialog(this) != DialogResult.OK) {
        //            this.Close();
        //        }
        //        editor.SetKsDirectory(welcome.KsDirectory);
        //    }

        //    if (!ShowOpenStoryDialog()) {
        //        this.Close();
        //    }
        //}

        private void menuItem2_Click(object sender, EventArgs e) {
            PreferencesForm preferences = new();
            preferences.ShowDialog(this);
        }

        private void menuTools_Click(object sender, EventArgs e) {
            //MenuItem m = (MenuItem)sender;
            //menuTools.MenuItems[screen.CurrentToolIndex].Checked = false;
            //m.Checked = true;
            //screen.CurrentToolIndex = m.Index;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            tabs[previousTabIndex].LeaveTab();
            tabs[tabControl.SelectedIndex].EnterTab();
            previousTabIndex = tabControl.SelectedIndex;
        }

        private void menuItem8_Click(object sender, EventArgs e) {
        }

        private void menuItem5_Click(object sender, EventArgs e) {
            this.SwitchToStartPage();
        }
    }
}
