namespace Story_Crafter.Controls.Panes {
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            screen_tilesetViewA = new TilesetViewPanel();
            screen_tilesetViewB = new TilesetViewPanel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            screen_gradient = new System.Windows.Forms.NumericUpDown();
            screen_tilesetA = new System.Windows.Forms.NumericUpDown();
            screen_tilesetB = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetViewA).BeginInit();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetViewB).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) screen_gradient).BeginInit();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetA).BeginInit();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetB).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(screen_tilesetViewA);
            flowLayoutPanel1.Controls.Add(screen_tilesetViewB);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1229, 518);
            flowLayoutPanel1.TabIndex = 84;
            // 
            // screen_tilesetViewA
            // 
            screen_tilesetViewA.Active = false;
            screen_tilesetViewA.BackgroundImage = Resources.checkers;
            screen_tilesetViewA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            screen_tilesetViewA.Location = new System.Drawing.Point(4, 3);
            screen_tilesetViewA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_tilesetViewA.Name = "screen_tilesetViewA";
            screen_tilesetViewA.Size = new System.Drawing.Size(384, 202);
            screen_tilesetViewA.TabIndex = 82;
            screen_tilesetViewA.TabStop = false;
            // 
            // screen_tilesetViewB
            // 
            screen_tilesetViewB.Active = false;
            screen_tilesetViewB.BackgroundImage = Resources.checkers;
            screen_tilesetViewB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            screen_tilesetViewB.Location = new System.Drawing.Point(396, 3);
            screen_tilesetViewB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_tilesetViewB.Name = "screen_tilesetViewB";
            screen_tilesetViewB.Size = new System.Drawing.Size(384, 202);
            screen_tilesetViewB.TabIndex = 83;
            screen_tilesetViewB.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1229, 568);
            tableLayoutPanel1.TabIndex = 85;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(screen_gradient, 2, 1);
            tableLayoutPanel2.Controls.Add(screen_tilesetA, 1, 1);
            tableLayoutPanel2.Controls.Add(screen_tilesetB, 0, 1);
            tableLayoutPanel2.Controls.Add(label10, 2, 0);
            tableLayoutPanel2.Controls.Add(label9, 1, 0);
            tableLayoutPanel2.Controls.Add(label11, 0, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(180, 44);
            tableLayoutPanel2.TabIndex = 95;
            // 
            // screen_gradient
            // 
            screen_gradient.Location = new System.Drawing.Point(124, 18);
            screen_gradient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_gradient.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            screen_gradient.Name = "screen_gradient";
            screen_gradient.Size = new System.Drawing.Size(47, 23);
            screen_gradient.TabIndex = 88;
            // 
            // screen_tilesetA
            // 
            screen_tilesetA.Location = new System.Drawing.Point(64, 18);
            screen_tilesetA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_tilesetA.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            screen_tilesetA.Name = "screen_tilesetA";
            screen_tilesetA.Size = new System.Drawing.Size(47, 23);
            screen_tilesetA.TabIndex = 86;
            // 
            // screen_tilesetB
            // 
            screen_tilesetB.Location = new System.Drawing.Point(4, 18);
            screen_tilesetB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_tilesetB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            screen_tilesetB.Name = "screen_tilesetB";
            screen_tilesetB.Size = new System.Drawing.Size(47, 23);
            screen_tilesetB.TabIndex = 87;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(124, 0);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(50, 15);
            label10.TabIndex = 90;
            label10.Text = "Tileset B";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(64, 0);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(51, 15);
            label9.TabIndex = 89;
            label9.Text = "Tileset A";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(4, 0);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(52, 15);
            label11.TabIndex = 91;
            label11.Text = "Gradient";
            // 
            // TilesetsPane
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1229, 568);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "TilesetsPane";
            Text = "Tilesets";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) screen_tilesetViewA).EndInit();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetViewB).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) screen_gradient).EndInit();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetA).EndInit();
            ((System.ComponentModel.ISupportInitialize) screen_tilesetB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TilesetViewPanel screen_tilesetViewA;
        private TilesetViewPanel screen_tilesetViewB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown screen_gradient;
        private System.Windows.Forms.NumericUpDown screen_tilesetA;
        private System.Windows.Forms.NumericUpDown screen_tilesetB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}
