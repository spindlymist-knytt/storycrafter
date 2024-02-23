namespace Story_Crafter.Forms.Editor {
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
            dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            renderingContextProvider1 = new Controls.RenderingContextProvider();
            SuspendLayout();
            // 
            // dockPanel1
            // 
            dockPanel1.BackColor = System.Drawing.Color.Transparent;
            dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel1.Location = new System.Drawing.Point(0, 0);
            dockPanel1.Margin = new System.Windows.Forms.Padding(0);
            dockPanel1.Name = "dockPanel1";
            dockPanel1.Size = new System.Drawing.Size(947, 657);
            dockPanel1.TabIndex = 0;
            // 
            // renderingContextProvider1
            // 
            renderingContextProvider1.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            renderingContextProvider1.Location = new System.Drawing.Point(0, 0);
            renderingContextProvider1.Margin = new System.Windows.Forms.Padding(0);
            renderingContextProvider1.MouseHoverUpdatesOnly = false;
            renderingContextProvider1.Name = "renderingContextProvider1";
            renderingContextProvider1.Size = new System.Drawing.Size(0, 0);
            renderingContextProvider1.TabIndex = 1;
            renderingContextProvider1.Text = "renderingContextProvider1";
            // 
            // NewScreenTab
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(renderingContextProvider1);
            Controls.Add(dockPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "NewScreenTab";
            Size = new System.Drawing.Size(947, 657);
            ResumeLayout(false);
        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private Controls.RenderingContextProvider renderingContextProvider1;
    }
}
