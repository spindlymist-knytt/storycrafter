namespace Story_Crafter.Forms.EditorForm {
    partial class TestTab {
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
            this.dxCanvas1 = new Story_Crafter.Controls.D3DCanvas();
            this.SuspendLayout();
            // 
            // dxCanvas1
            // 
            this.dxCanvas1.Location = new System.Drawing.Point(0, 0);
            this.dxCanvas1.Name = "dxCanvas1";
            this.dxCanvas1.Size = new System.Drawing.Size(600, 240);
            this.dxCanvas1.TabIndex = 0;
            this.dxCanvas1.Text = "d3dCanvas1";
            // 
            // TestTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dxCanvas1);
            this.Name = "TestTab";
            this.Size = new System.Drawing.Size(1534, 871);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.D3DCanvas dxCanvas1;
    }
}
