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
            this.button1 = new System.Windows.Forms.Button();
            this.d3dCanvas1 = new Story_Crafter.Controls.D3DCanvas();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Render Random Screen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // d3dCanvas1
            // 
            this.d3dCanvas1.Location = new System.Drawing.Point(0, 0);
            this.d3dCanvas1.Name = "d3dCanvas1";
            this.d3dCanvas1.Screen = null;
            this.d3dCanvas1.Size = new System.Drawing.Size(600, 240);
            this.d3dCanvas1.TabIndex = 0;
            this.d3dCanvas1.Text = "d3dCanvas1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Render Active Screen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TestTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.d3dCanvas1);
            this.Name = "TestTab";
            this.Size = new System.Drawing.Size(1534, 871);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.D3DCanvas d3dCanvas1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
