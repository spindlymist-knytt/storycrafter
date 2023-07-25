using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Story_Crafter.Forms.EditorForm {
    partial class TilesetsTab {
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
            this.tileset_label = new System.Windows.Forms.Label();
            this.tileset_delete = new System.Windows.Forms.Button();
            this.tileset_rename = new System.Windows.Forms.Button();
            this.tileset_view = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tileset_list = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.tileset_view)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileset_label
            // 
            this.tileset_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tileset_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileset_label.Location = new System.Drawing.Point(0, 0);
            this.tileset_label.Margin = new System.Windows.Forms.Padding(0);
            this.tileset_label.Name = "tileset_label";
            this.tileset_label.Size = new System.Drawing.Size(392, 33);
            this.tileset_label.TabIndex = 11;
            this.tileset_label.Text = "Tileset X";
            this.tileset_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tileset_delete
            // 
            this.tileset_delete.Location = new System.Drawing.Point(89, 3);
            this.tileset_delete.Name = "tileset_delete";
            this.tileset_delete.Size = new System.Drawing.Size(80, 23);
            this.tileset_delete.TabIndex = 10;
            this.tileset_delete.Text = "Delete";
            this.tileset_delete.UseVisualStyleBackColor = true;
            // 
            // tileset_rename
            // 
            this.tileset_rename.Location = new System.Drawing.Point(3, 3);
            this.tileset_rename.Name = "tileset_rename";
            this.tileset_rename.Size = new System.Drawing.Size(80, 23);
            this.tileset_rename.TabIndex = 9;
            this.tileset_rename.Text = "Rename";
            this.tileset_rename.UseVisualStyleBackColor = true;
            // 
            // tileset_view
            // 
            this.tileset_view.BackgroundImage = global::Story_Crafter.Properties.Resources.checkers;
            this.tileset_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileset_view.Location = new System.Drawing.Point(3, 36);
            this.tileset_view.Name = "tileset_view";
            this.tileset_view.Size = new System.Drawing.Size(386, 204);
            this.tileset_view.TabIndex = 7;
            this.tileset_view.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.tileset_label);
            this.flowLayoutPanel2.Controls.Add(this.tileset_view);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(459, 203);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(392, 272);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.tileset_rename);
            this.flowLayoutPanel3.Controls.Add(this.tileset_delete);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(220, 243);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(172, 29);
            this.flowLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tileset_list, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1054, 678);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // tileset_list
            // 
            this.tileset_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileset_list.HideSelection = false;
            this.tileset_list.Location = new System.Drawing.Point(0, 0);
            this.tileset_list.Margin = new System.Windows.Forms.Padding(0);
            this.tileset_list.MultiSelect = false;
            this.tileset_list.Name = "tileset_list";
            this.tileset_list.Size = new System.Drawing.Size(256, 658);
            this.tileset_list.TabIndex = 16;
            this.tileset_list.UseCompatibleStateImageBehavior = false;
            // 
            // TilesetsTab
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TilesetsTab";
            this.Size = new System.Drawing.Size(1054, 678);
            ((System.ComponentModel.ISupportInitialize)(this.tileset_view)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label tileset_label;
        private Button tileset_delete;
        private Button tileset_rename;
        private PictureBox tileset_view;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView tileset_list;
    }
}
