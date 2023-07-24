using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class MapTab {
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapTab));
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.map_showThumbs = new System.Windows.Forms.CheckBox();
            this.map_mainView = new Story_Crafter.MapViewPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.translucentPanel1 = new Story_Crafter.TranslucentPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.map_mainView)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.translucentPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(696, 29);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(82, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "Cancel";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(608, 29);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Confirm";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(608, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Import Screens";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // map_showThumbs
            // 
            this.map_showThumbs.AutoSize = true;
            this.map_showThumbs.BackColor = System.Drawing.Color.Transparent;
            this.map_showThumbs.Location = new System.Drawing.Point(606, 464);
            this.map_showThumbs.Name = "map_showThumbs";
            this.map_showThumbs.Size = new System.Drawing.Size(110, 17);
            this.map_showThumbs.TabIndex = 9;
            this.map_showThumbs.Text = "Show Thumbnails";
            this.map_showThumbs.UseVisualStyleBackColor = false;
            // 
            // map_mainView
            // 
            this.map_mainView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.map_mainView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("map_mainView.BackgroundImage")));
            this.map_mainView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map_mainView.Image = ((System.Drawing.Image)(resources.GetObject("map_mainView.Image")));
            this.map_mainView.Location = new System.Drawing.Point(0, 0);
            this.map_mainView.Name = "map_mainView";
            this.map_mainView.ShowThumbs = false;
            this.map_mainView.Size = new System.Drawing.Size(602, 482);
            this.map_mainView.TabIndex = 10;
            this.map_mainView.TabStop = false;
            this.map_mainView.TheStory = null;
            this.map_mainView.UpdateScreen = null;
            this.map_mainView.UpdateStatus = null;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.map_mainView);
            this.panel1.Controls.Add(this.map_showThumbs);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Location = new System.Drawing.Point(193, 166);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 485);
            this.panel1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
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
            // MapTab
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.translucentPanel1);
            this.Name = "MapTab";
            this.Size = new System.Drawing.Size(1167, 817);
            ((System.ComponentModel.ISupportInitialize)(this.map_mainView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.translucentPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button button9;
        private Button button8;
        private Button button7;
        private CheckBox map_showThumbs;
        private MapViewPanel map_mainView;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TranslucentPanel translucentPanel1;
        private Panel panel2;
        private Label progressBarLabel;
        private ProgressBar progressBar1;
    }
}
