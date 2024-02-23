using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Controls.Tabs {
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
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            map_showThumbs = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            map_mainView = new MapViewPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            translucentPanel1 = new TranslucentPanel();
            panel2 = new Panel();
            progressBarLabel = new Label();
            progressBar1 = new ProgressBar();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) map_mainView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            translucentPanel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button9
            // 
            button9.Anchor =  AnchorStyles.Left | AnchorStyles.Right;
            button9.Enabled = false;
            button9.Location = new System.Drawing.Point(3, 61);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(120, 23);
            button9.TabIndex = 13;
            button9.Text = "Cancel";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Anchor =  AnchorStyles.Left | AnchorStyles.Right;
            button8.Enabled = false;
            button8.Location = new System.Drawing.Point(3, 32);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(120, 23);
            button8.TabIndex = 12;
            button8.Text = "Confirm";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button7.Location = new System.Drawing.Point(3, 3);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(120, 23);
            button7.TabIndex = 11;
            button7.Text = "Import Screens";
            button7.UseVisualStyleBackColor = true;
            // 
            // map_showThumbs
            // 
            map_showThumbs.AutoSize = true;
            map_showThumbs.BackColor = System.Drawing.Color.Transparent;
            map_showThumbs.Location = new System.Drawing.Point(3, 90);
            map_showThumbs.Name = "map_showThumbs";
            map_showThumbs.Size = new System.Drawing.Size(120, 19);
            map_showThumbs.TabIndex = 9;
            map_showThumbs.Text = "Show Thumbnails";
            map_showThumbs.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 281F));
            tableLayoutPanel1.Controls.Add(map_mainView, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1167, 817);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // map_mainView
            // 
            map_mainView.BackColor = System.Drawing.Color.FromArgb(  0,   0,   0,   0);
            map_mainView.BackgroundImage = (System.Drawing.Image) resources.GetObject("map_mainView.BackgroundImage");
            map_mainView.Dock = DockStyle.Fill;
            map_mainView.Image = (System.Drawing.Image) resources.GetObject("map_mainView.Image");
            map_mainView.Location = new System.Drawing.Point(0, 0);
            map_mainView.Margin = new Padding(0);
            map_mainView.Name = "map_mainView";
            map_mainView.ShowThumbs = false;
            map_mainView.Size = new System.Drawing.Size(886, 817);
            map_mainView.Story = null;
            map_mainView.TabIndex = 16;
            map_mainView.TabStop = false;
            map_mainView.UpdateScreen = null;
            map_mainView.UpdateStatus = null;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(button7);
            flowLayoutPanel1.Controls.Add(button8);
            flowLayoutPanel1.Controls.Add(button9);
            flowLayoutPanel1.Controls.Add(map_showThumbs);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(963, 352);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(126, 112);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // translucentPanel1
            // 
            translucentPanel1.BackColor = System.Drawing.Color.White;
            translucentPanel1.Controls.Add(panel2);
            translucentPanel1.Dock = DockStyle.Fill;
            translucentPanel1.Location = new System.Drawing.Point(0, 0);
            translucentPanel1.Name = "translucentPanel1";
            translucentPanel1.Size = new System.Drawing.Size(1167, 817);
            translucentPanel1.TabIndex = 16;
            translucentPanel1.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(progressBarLabel);
            panel2.Controls.Add(progressBar1);
            panel2.Location = new System.Drawing.Point(176, 204);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(433, 105);
            panel2.TabIndex = 0;
            // 
            // progressBarLabel
            // 
            progressBarLabel.AutoSize = true;
            progressBarLabel.Location = new System.Drawing.Point(22, 64);
            progressBarLabel.Name = "progressBarLabel";
            progressBarLabel.Size = new System.Drawing.Size(38, 15);
            progressBarLabel.TabIndex = 1;
            progressBarLabel.Text = "label1";
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(22, 34);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(386, 23);
            progressBar1.TabIndex = 0;
            // 
            // MapTab
            // 
            Controls.Add(tableLayoutPanel1);
            Controls.Add(translucentPanel1);
            Name = "MapTab";
            Size = new System.Drawing.Size(1167, 817);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) map_mainView).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            translucentPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
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
