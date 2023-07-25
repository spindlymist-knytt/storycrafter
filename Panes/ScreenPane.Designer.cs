namespace Story_Crafter.Panes {
    partial class ScreenPane {
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_setZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_setZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_setZoom300 = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasPanel1 = new Story_Crafter.Controls.CanvasPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.canvasPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1697, 769);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_setZoom100,
            this.menuItem_setZoom200,
            this.menuItem_setZoom300});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // menuItem_setZoom100
            // 
            this.menuItem_setZoom100.Name = "menuItem_setZoom100";
            this.menuItem_setZoom100.Size = new System.Drawing.Size(102, 22);
            this.menuItem_setZoom100.Text = "100%";
            this.menuItem_setZoom100.Click += new System.EventHandler(this.menuItem_setZoom100_Click);
            // 
            // menuItem_setZoom200
            // 
            this.menuItem_setZoom200.Name = "menuItem_setZoom200";
            this.menuItem_setZoom200.Size = new System.Drawing.Size(102, 22);
            this.menuItem_setZoom200.Text = "200%";
            this.menuItem_setZoom200.Click += new System.EventHandler(this.menuItem_setZoom200_Click);
            // 
            // menuItem_setZoom300
            // 
            this.menuItem_setZoom300.Name = "menuItem_setZoom300";
            this.menuItem_setZoom300.Size = new System.Drawing.Size(102, 22);
            this.menuItem_setZoom300.Text = "300%";
            this.menuItem_setZoom300.Click += new System.EventHandler(this.menuItem_setZoom300_Click);
            // 
            // canvasPanel1
            // 
            this.canvasPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.canvasPanel1.GetBrushSize = null;
            this.canvasPanel1.GetCanvas = null;
            this.canvasPanel1.GetGradient = null;
            this.canvasPanel1.GetLayer = null;
            this.canvasPanel1.GetObject = null;
            this.canvasPanel1.GetSelection = null;
            this.canvasPanel1.GetTilesetA = null;
            this.canvasPanel1.GetTilesetB = null;
            this.canvasPanel1.GetTilesetIndex = null;
            this.canvasPanel1.GetTool = null;
            this.canvasPanel1.Location = new System.Drawing.Point(548, 264);
            this.canvasPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.canvasPanel1.Name = "canvasPanel1";
            this.canvasPanel1.Resizable = false;
            this.canvasPanel1.Size = new System.Drawing.Size(600, 240);
            this.canvasPanel1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.canvasPanel1.TabIndex = 0;
            this.canvasPanel1.TabStop = false;
            // 
            // ScreenPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1697, 769);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScreenPane";
            this.Text = "Screen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvasPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CanvasPanel canvasPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_setZoom100;
        private System.Windows.Forms.ToolStripMenuItem menuItem_setZoom200;
        private System.Windows.Forms.ToolStripMenuItem menuItem_setZoom300;
    }
}
