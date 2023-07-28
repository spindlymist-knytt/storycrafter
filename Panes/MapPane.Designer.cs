namespace Story_Crafter.Panes {
    partial class MapPane {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPane));
            this.map_mainView = new Story_Crafter.MapViewPanel();
            ((System.ComponentModel.ISupportInitialize)(this.map_mainView)).BeginInit();
            this.SuspendLayout();
            // 
            // map_mainView
            // 
            this.map_mainView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.map_mainView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("map_mainView.BackgroundImage")));
            this.map_mainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map_mainView.Image = ((System.Drawing.Image)(resources.GetObject("map_mainView.Image")));
            this.map_mainView.Location = new System.Drawing.Point(0, 0);
            this.map_mainView.Margin = new System.Windows.Forms.Padding(0);
            this.map_mainView.Name = "map_mainView";
            this.map_mainView.ShowThumbs = false;
            this.map_mainView.Size = new System.Drawing.Size(891, 570);
            this.map_mainView.TabIndex = 17;
            this.map_mainView.TabStop = false;
            this.map_mainView.Story = null;
            this.map_mainView.UpdateScreen = null;
            this.map_mainView.UpdateStatus = null;
            // 
            // MapPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 570);
            this.Controls.Add(this.map_mainView);
            this.Name = "MapPane";
            this.Text = "Map";
            ((System.ComponentModel.ISupportInitialize)(this.map_mainView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MapViewPanel map_mainView;
    }
}
