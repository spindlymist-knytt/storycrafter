namespace Story_Crafter.Panes {
    partial class TilesetsPane {
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.screen_tilesetViewA = new Story_Crafter.TilesetViewPanel();
            this.screen_tilesetViewB = new Story_Crafter.TilesetViewPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewB)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.screen_tilesetViewA);
            this.flowLayoutPanel1.Controls.Add(this.screen_tilesetViewB);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(893, 492);
            this.flowLayoutPanel1.TabIndex = 84;
            // 
            // screen_tilesetViewA
            // 
            this.screen_tilesetViewA.Active = false;
            this.screen_tilesetViewA.BackgroundImage = global::Story_Crafter.Properties.Resources.checkers;
            this.screen_tilesetViewA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen_tilesetViewA.Location = new System.Drawing.Point(3, 3);
            this.screen_tilesetViewA.Name = "screen_tilesetViewA";
            this.screen_tilesetViewA.Size = new System.Drawing.Size(386, 204);
            this.screen_tilesetViewA.TabIndex = 82;
            this.screen_tilesetViewA.TabStop = false;
            // 
            // screen_tilesetViewB
            // 
            this.screen_tilesetViewB.Active = false;
            this.screen_tilesetViewB.BackgroundImage = global::Story_Crafter.Properties.Resources.checkers;
            this.screen_tilesetViewB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen_tilesetViewB.Location = new System.Drawing.Point(395, 3);
            this.screen_tilesetViewB.Name = "screen_tilesetViewB";
            this.screen_tilesetViewB.Size = new System.Drawing.Size(386, 204);
            this.screen_tilesetViewB.TabIndex = 83;
            this.screen_tilesetViewB.TabStop = false;
            // 
            // TilesetsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 492);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TilesetsPane";
            this.Text = "Tilesets";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TilesetViewPanel screen_tilesetViewA;
        private TilesetViewPanel screen_tilesetViewB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
