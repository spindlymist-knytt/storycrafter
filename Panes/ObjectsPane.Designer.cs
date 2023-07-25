namespace Story_Crafter.Panes {
    partial class ObjectsPane {
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
            this.screen_bankList = new System.Windows.Forms.ComboBox();
            this.screen_objectList = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // screen_bankList
            // 
            this.screen_bankList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screen_bankList.FormattingEnabled = true;
            this.screen_bankList.Location = new System.Drawing.Point(3, 3);
            this.screen_bankList.Name = "screen_bankList";
            this.screen_bankList.Size = new System.Drawing.Size(178, 21);
            this.screen_bankList.TabIndex = 49;
            // 
            // screen_objectList
            // 
            this.screen_objectList.HideSelection = false;
            this.screen_objectList.Location = new System.Drawing.Point(3, 30);
            this.screen_objectList.MultiSelect = false;
            this.screen_objectList.Name = "screen_objectList";
            this.screen_objectList.Size = new System.Drawing.Size(178, 214);
            this.screen_objectList.TabIndex = 50;
            this.screen_objectList.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.screen_bankList);
            this.flowLayoutPanel1.Controls.Add(this.screen_objectList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(880, 406);
            this.flowLayoutPanel1.TabIndex = 51;
            // 
            // ObjectsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 406);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ObjectsPane";
            this.Text = "Objects";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox screen_bankList;
        private System.Windows.Forms.ListView screen_objectList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
