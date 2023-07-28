using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Forms.EditorForm {
    partial class MapTab {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapTab));
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.map_showThumbs = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.translucentPanel1 = new Story_Crafter.TranslucentPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.map_mainView = new Story_Crafter.MapViewPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.translucentPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.map_mainView)).BeginInit();
            this.SuspendLayout();
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(3, 61);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(110, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "Cancel";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(3, 32);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(110, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Confirm";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(3, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Import Screens";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // map_showThumbs
            // 
            this.map_showThumbs.AutoSize = true;
            this.map_showThumbs.BackColor = System.Drawing.Color.Transparent;
            this.map_showThumbs.Location = new System.Drawing.Point(3, 90);
            this.map_showThumbs.Name = "map_showThumbs";
            this.map_showThumbs.Size = new System.Drawing.Size(110, 17);
            this.map_showThumbs.TabIndex = 9;
            this.map_showThumbs.Text = "Show Thumbnails";
            this.map_showThumbs.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tableLayoutPanel1.Controls.Add(this.map_mainView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1167, 817);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // translucentPanel1
            // 
            this.translucentPanel1.BackColor = System.Drawing.Color.White;
            this.translucentPanel1.Controls.Add(this.panel2);
            this.translucentPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translucentPanel1.Location = new System.Drawing.Point(0, 0);
            this.translucentPanel1.Name = "translucentPanel1";
            this.translucentPanel1.Size = new System.Drawing.Size(1167, 817);
            this.translucentPanel1.TabIndex = 16;
            this.translucentPanel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.progressBarLabel);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(176, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 105);
            this.panel2.TabIndex = 0;
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.AutoSize = true;
            this.progressBarLabel.Location = new System.Drawing.Point(22, 64);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(35, 13);
            this.progressBarLabel.TabIndex = 1;
            this.progressBarLabel.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 34);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Controls.Add(this.map_showThumbs);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(968, 353);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(116, 110);
            this.flowLayoutPanel1.TabIndex = 15;
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
            this.map_mainView.Size = new System.Drawing.Size(886, 817);
            this.map_mainView.TabIndex = 16;
            this.map_mainView.TabStop = false;
            this.map_mainView.Story = null;
            this.map_mainView.UpdateScreen = null;
            this.map_mainView.UpdateStatus = null;
            // 
            // MapTab
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.translucentPanel1);
            this.Name = "MapTab";
            this.Size = new System.Drawing.Size(1167, 817);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.translucentPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.map_mainView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button9;
        private Button button8;
        private Button button7;
        private CheckBox map_showThumbs;
        private TableLayoutPanel tableLayoutPanel1;
        private TranslucentPanel translucentPanel1;
        private Panel panel2;
        private Label progressBarLabel;
        private ProgressBar progressBar1;
        private MapViewPanel map_mainView;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
