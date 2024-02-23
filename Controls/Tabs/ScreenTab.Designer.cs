namespace Story_Crafter.Controls.Tabs {
    partial class ScreenTab {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            SuspendLayout();
            // 
            // dockPanel
            // 
            dockPanel.BackColor = System.Drawing.Color.Transparent;
            dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel.Location = new System.Drawing.Point(0, 0);
            dockPanel.Margin = new System.Windows.Forms.Padding(0);
            dockPanel.Name = "dockPanel";
            dockPanel.Size = new System.Drawing.Size(947, 657);
            dockPanel.TabIndex = 0;
            // 
            // ScreenTab
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(dockPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ScreenTab";
            Size = new System.Drawing.Size(947, 657);
            ResumeLayout(false);
        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}
