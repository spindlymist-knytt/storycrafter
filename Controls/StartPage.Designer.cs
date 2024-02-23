namespace Story_Crafter.Controls {
    partial class StartPage {
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            loadStory = new System.Windows.Forms.Button();
            storyList = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(loadStory, 0, 1);
            tableLayoutPanel1.Controls.Add(storyList, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(768, 533);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // loadStory
            // 
            loadStory.Dock = System.Windows.Forms.DockStyle.Top;
            loadStory.Location = new System.Drawing.Point(4, 505);
            loadStory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadStory.Name = "loadStory";
            loadStory.Size = new System.Drawing.Size(760, 25);
            loadStory.TabIndex = 6;
            loadStory.Text = "Load";
            loadStory.UseVisualStyleBackColor = true;
            loadStory.Click += loadStory_Click;
            // 
            // storyList
            // 
            storyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            storyList.Dock = System.Windows.Forms.DockStyle.Fill;
            storyList.FullRowSelect = true;
            storyList.GridLines = true;
            storyList.Location = new System.Drawing.Point(4, 3);
            storyList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            storyList.MultiSelect = false;
            storyList.Name = "storyList";
            storyList.Size = new System.Drawing.Size(760, 496);
            storyList.TabIndex = 5;
            storyList.UseCompatibleStateImageBehavior = false;
            storyList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Author";
            columnHeader1.Width = 184;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Title";
            columnHeader2.Width = 184;
            // 
            // StartPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "StartPage";
            Size = new System.Drawing.Size(768, 533);
            Load += StartPage_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button loadStory;
        private System.Windows.Forms.ListView storyList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
