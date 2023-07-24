using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class GradientsTab : UserControl {

        private void InitializeComponent() {
            this.gradient_tileCheck = new System.Windows.Forms.CheckBox();
            this.gradient_label = new System.Windows.Forms.Label();
            this.gradient_list = new System.Windows.Forms.ListView();
            this.gradient_delete = new System.Windows.Forms.Button();
            this.gradient_rename = new System.Windows.Forms.Button();
            this.gradient_view = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gradient_view)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradient_tileCheck
            // 
            this.gradient_tileCheck.AutoSize = true;
            this.gradient_tileCheck.Checked = true;
            this.gradient_tileCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gradient_tileCheck.Location = new System.Drawing.Point(3, 282);
            this.gradient_tileCheck.Name = "gradient_tileCheck";
            this.gradient_tileCheck.Size = new System.Drawing.Size(61, 17);
            this.gradient_tileCheck.TabIndex = 19;
            this.gradient_tileCheck.Text = "Repeat";
            this.gradient_tileCheck.UseVisualStyleBackColor = true;
            // 
            // gradient_label
            // 
            this.gradient_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradient_label.Location = new System.Drawing.Point(3, 0);
            this.gradient_label.Name = "gradient_label";
            this.gradient_label.Size = new System.Drawing.Size(600, 33);
            this.gradient_label.TabIndex = 18;
            this.gradient_label.Text = "Tileset X";
            this.gradient_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gradient_list
            // 
            this.gradient_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradient_list.HideSelection = false;
            this.gradient_list.Location = new System.Drawing.Point(0, 0);
            this.gradient_list.Margin = new System.Windows.Forms.Padding(0);
            this.gradient_list.MultiSelect = false;
            this.gradient_list.Name = "gradient_list";
            this.gradient_list.Size = new System.Drawing.Size(256, 660);
            this.gradient_list.TabIndex = 13;
            this.gradient_list.UseCompatibleStateImageBehavior = false;
            // 
            // gradient_delete
            // 
            this.gradient_delete.Location = new System.Drawing.Point(523, 282);
            this.gradient_delete.Name = "gradient_delete";
            this.gradient_delete.Size = new System.Drawing.Size(80, 23);
            this.gradient_delete.TabIndex = 17;
            this.gradient_delete.Text = "Delete";
            this.gradient_delete.UseVisualStyleBackColor = true;
            // 
            // gradient_rename
            // 
            this.gradient_rename.Location = new System.Drawing.Point(437, 282);
            this.gradient_rename.Name = "gradient_rename";
            this.gradient_rename.Size = new System.Drawing.Size(80, 23);
            this.gradient_rename.TabIndex = 16;
            this.gradient_rename.Text = "Rename";
            this.gradient_rename.UseVisualStyleBackColor = true;
            // 
            // gradient_view
            // 
            this.gradient_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradient_view.Location = new System.Drawing.Point(3, 36);
            this.gradient_view.Name = "gradient_view";
            this.gradient_view.Size = new System.Drawing.Size(600, 240);
            this.gradient_view.TabIndex = 14;
            this.gradient_view.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.gradient_label);
            this.panel1.Controls.Add(this.gradient_tileCheck);
            this.panel1.Controls.Add(this.gradient_view);
            this.panel1.Controls.Add(this.gradient_rename);
            this.panel1.Controls.Add(this.gradient_delete);
            this.panel1.Location = new System.Drawing.Point(278, 176);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 308);
            this.panel1.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gradient_list, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(907, 660);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // GradientsTab
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GradientsTab";
            this.Size = new System.Drawing.Size(907, 660);
            ((System.ComponentModel.ISupportInitialize)(this.gradient_view)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private CheckBox gradient_tileCheck;
        private Label gradient_label;
        private ListView gradient_list;
        private Button gradient_delete;
        private Button gradient_rename;
        private PictureBox gradient_view;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
