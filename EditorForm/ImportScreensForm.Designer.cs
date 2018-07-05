namespace Story_Crafter {
    partial class ImportScreensForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportScreensForm));
            this.mapViewPanel1 = new Story_Crafter.MapViewPanel();
            this.storyList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadStory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapViewPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapViewPanel1
            // 
            this.mapViewPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapViewPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapViewPanel1.Image = ((System.Drawing.Image)(resources.GetObject("mapViewPanel1.Image")));
            this.mapViewPanel1.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel1.Name = "mapViewPanel1";
            this.mapViewPanel1.ShowThumbs = false;
            this.mapViewPanel1.Size = new System.Drawing.Size(602, 482);
            this.mapViewPanel1.TabIndex = 0;
            this.mapViewPanel1.TabStop = false;
            this.mapViewPanel1.TheStory = null;
            this.mapViewPanel1.UpdateScreen = null;
            this.mapViewPanel1.UpdateStatus = null;
            // 
            // storyList
            // 
            this.storyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.storyList.FullRowSelect = true;
            this.storyList.GridLines = true;
            this.storyList.Location = new System.Drawing.Point(106, 75);
            this.storyList.MultiSelect = false;
            this.storyList.Name = "storyList";
            this.storyList.Size = new System.Drawing.Size(390, 297);
            this.storyList.TabIndex = 2;
            this.storyList.UseCompatibleStateImageBehavior = false;
            this.storyList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Author";
            this.columnHeader1.Width = 184;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 184;
            // 
            // loadStory
            // 
            this.loadStory.Location = new System.Drawing.Point(106, 378);
            this.loadStory.Name = "loadStory";
            this.loadStory.Size = new System.Drawing.Size(390, 29);
            this.loadStory.TabIndex = 3;
            this.loadStory.Text = "Load";
            this.loadStory.UseVisualStyleBackColor = true;
            this.loadStory.Click += new System.EventHandler(this.loadStory_Click);
            // 
            // ImportScreensForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 443);
            this.Controls.Add(this.loadStory);
            this.Controls.Add(this.storyList);
            this.Controls.Add(this.mapViewPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ImportScreensForm";
            this.Text = "Import Screens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportScreensForm_FormClosing);
            this.Shown += new System.EventHandler(this.ImportScreensForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImportScreensForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.mapViewPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MapViewPanel mapViewPanel1;
        private System.Windows.Forms.ListView storyList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button loadStory;
    }
}