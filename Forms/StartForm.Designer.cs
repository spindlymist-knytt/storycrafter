namespace Story_Crafter.Forms {
  partial class StartForm {
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
      this.label1 = new System.Windows.Forms.Label();
      this.storyList = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.loadStory = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.storyAuthor = new System.Windows.Forms.TextBox();
      this.storyTitle = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.createStory = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(116, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "Load a story:";
      // 
      // storyList
      // 
      this.storyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.storyList.FullRowSelect = true;
      this.storyList.GridLines = true;
      this.storyList.Location = new System.Drawing.Point(12, 36);
      this.storyList.MultiSelect = false;
      this.storyList.Name = "storyList";
      this.storyList.Size = new System.Drawing.Size(390, 297);
      this.storyList.TabIndex = 1;
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
      this.loadStory.Location = new System.Drawing.Point(12, 339);
      this.loadStory.Name = "loadStory";
      this.loadStory.Size = new System.Drawing.Size(390, 29);
      this.loadStory.TabIndex = 2;
      this.loadStory.Text = "Load";
      this.loadStory.UseVisualStyleBackColor = true;
      this.loadStory.Click += new System.EventHandler(this.loadStory_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(408, 36);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Author:";
      // 
      // storyAuthor
      // 
      this.storyAuthor.Location = new System.Drawing.Point(408, 52);
      this.storyAuthor.Name = "storyAuthor";
      this.storyAuthor.Size = new System.Drawing.Size(178, 20);
      this.storyAuthor.TabIndex = 4;
      // 
      // storyTitle
      // 
      this.storyTitle.Location = new System.Drawing.Point(408, 91);
      this.storyTitle.Name = "storyTitle";
      this.storyTitle.Size = new System.Drawing.Size(178, 20);
      this.storyTitle.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(408, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Title:";
      // 
      // createStory
      // 
      this.createStory.Location = new System.Drawing.Point(408, 117);
      this.createStory.Name = "createStory";
      this.createStory.Size = new System.Drawing.Size(178, 29);
      this.createStory.TabIndex = 7;
      this.createStory.Text = "Create";
      this.createStory.UseVisualStyleBackColor = true;
      this.createStory.Click += new System.EventHandler(this.createStory_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(404, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(129, 24);
      this.label4.TabIndex = 8;
      this.label4.Text = "Create a story:";
      // 
      // StartForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImage = global::Story_Crafter.Resources.background;
      this.ClientSize = new System.Drawing.Size(594, 376);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.createStory);
      this.Controls.Add(this.storyTitle);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.storyAuthor);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.loadStory);
      this.Controls.Add(this.storyList);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "StartForm";
      this.Text = "Story Crafter";
      this.Shown += new System.EventHandler(this.StartForm_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView storyList;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Button loadStory;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox storyAuthor;
    private System.Windows.Forms.TextBox storyTitle;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button createStory;
	private System.Windows.Forms.Label label4;
  }
}