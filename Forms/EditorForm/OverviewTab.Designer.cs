using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter.Forms.EditorForm {
    partial class OverviewTab {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewTab));
            this.overview_screenCount = new System.Windows.Forms.Label();
            this.overview_overlayCheck = new System.Windows.Forms.CheckBox();
            this.overview_clothesPreview = new System.Windows.Forms.Panel();
            this.overview_skinPreview = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.overview_publish = new System.Windows.Forms.Button();
            this.overview_size = new System.Windows.Forms.ComboBox();
            this.overview_diffC = new System.Windows.Forms.ComboBox();
            this.overview_diffB = new System.Windows.Forms.ComboBox();
            this.overview_diffA = new System.Windows.Forms.ComboBox();
            this.overview_catB = new System.Windows.Forms.ComboBox();
            this.overview_catA = new System.Windows.Forms.ComboBox();
            this.overview_cardBorder = new System.Windows.Forms.Panel();
            this.overview_cardBackground = new System.Windows.Forms.Panel();
            this.overview_description = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.overview_author = new System.Windows.Forms.TextBox();
            this.overview_title = new System.Windows.Forms.TextBox();
            this.overview_icon = new System.Windows.Forms.PictureBox();
            this.overview_clothesLabel = new System.Windows.Forms.Label();
            this.overview_skinLabel = new System.Windows.Forms.Label();
            this.overview_juni = new System.Windows.Forms.PictureBox();
            this.overview_info = new System.Windows.Forms.PictureBox();
            this.overview_colorDialog = new System.Windows.Forms.ColorDialog();
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressAndUploadToKnyttlevelscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.overview_cardBorder.SuspendLayout();
            this.overview_cardBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overview_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overview_juni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overview_info)).BeginInit();
            this.contextMenu1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // overview_screenCount
            // 
            this.overview_screenCount.AutoSize = true;
            this.overview_screenCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overview_screenCount.ForeColor = System.Drawing.Color.Gray;
            this.overview_screenCount.Location = new System.Drawing.Point(3, 13);
            this.overview_screenCount.Name = "overview_screenCount";
            this.overview_screenCount.Size = new System.Drawing.Size(48, 13);
            this.overview_screenCount.TabIndex = 38;
            this.overview_screenCount.Text = "Screens:";
            // 
            // overview_overlayCheck
            // 
            this.overview_overlayCheck.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.overview_overlayCheck.AutoSize = true;
            this.overview_overlayCheck.Checked = true;
            this.overview_overlayCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overview_overlayCheck.Location = new System.Drawing.Point(540, 0);
            this.overview_overlayCheck.Margin = new System.Windows.Forms.Padding(0);
            this.overview_overlayCheck.Name = "overview_overlayCheck";
            this.overview_overlayCheck.Size = new System.Drawing.Size(62, 17);
            this.overview_overlayCheck.TabIndex = 37;
            this.overview_overlayCheck.Text = "Overlay";
            this.overview_overlayCheck.UseVisualStyleBackColor = true;
            // 
            // overview_clothesPreview
            // 
            this.overview_clothesPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.overview_clothesPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overview_clothesPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.overview_clothesPreview.Location = new System.Drawing.Point(3, 3);
            this.overview_clothesPreview.Name = "overview_clothesPreview";
            this.overview_clothesPreview.Size = new System.Drawing.Size(15, 15);
            this.overview_clothesPreview.TabIndex = 34;
            // 
            // overview_skinPreview
            // 
            this.overview_skinPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(192)))), ((int)(((byte)(166)))));
            this.overview_skinPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overview_skinPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.overview_skinPreview.Location = new System.Drawing.Point(3, 3);
            this.overview_skinPreview.Name = "overview_skinPreview";
            this.overview_skinPreview.Size = new System.Drawing.Size(15, 15);
            this.overview_skinPreview.TabIndex = 33;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Difficulties";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 53);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Categories";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Size";
            // 
            // overview_publish
            // 
            this.overview_publish.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overview_publish.Location = new System.Drawing.Point(3, 43);
            this.overview_publish.Name = "overview_publish";
            this.overview_publish.Size = new System.Drawing.Size(279, 91);
            this.overview_publish.TabIndex = 28;
            this.overview_publish.Text = "Publish";
            this.overview_publish.UseVisualStyleBackColor = true;
            // 
            // overview_size
            // 
            this.overview_size.FormattingEnabled = true;
            this.overview_size.Location = new System.Drawing.Point(3, 29);
            this.overview_size.Name = "overview_size";
            this.overview_size.Size = new System.Drawing.Size(121, 21);
            this.overview_size.TabIndex = 27;
            // 
            // overview_diffC
            // 
            this.overview_diffC.FormattingEnabled = true;
            this.overview_diffC.Location = new System.Drawing.Point(3, 190);
            this.overview_diffC.Name = "overview_diffC";
            this.overview_diffC.Size = new System.Drawing.Size(121, 21);
            this.overview_diffC.TabIndex = 26;
            // 
            // overview_diffB
            // 
            this.overview_diffB.FormattingEnabled = true;
            this.overview_diffB.Location = new System.Drawing.Point(3, 163);
            this.overview_diffB.Name = "overview_diffB";
            this.overview_diffB.Size = new System.Drawing.Size(121, 21);
            this.overview_diffB.TabIndex = 25;
            // 
            // overview_diffA
            // 
            this.overview_diffA.FormattingEnabled = true;
            this.overview_diffA.Location = new System.Drawing.Point(3, 136);
            this.overview_diffA.Name = "overview_diffA";
            this.overview_diffA.Size = new System.Drawing.Size(121, 21);
            this.overview_diffA.TabIndex = 24;
            // 
            // overview_catB
            // 
            this.overview_catB.FormattingEnabled = true;
            this.overview_catB.Location = new System.Drawing.Point(3, 96);
            this.overview_catB.Name = "overview_catB";
            this.overview_catB.Size = new System.Drawing.Size(121, 21);
            this.overview_catB.TabIndex = 23;
            // 
            // overview_catA
            // 
            this.overview_catA.FormattingEnabled = true;
            this.overview_catA.Location = new System.Drawing.Point(3, 69);
            this.overview_catA.Name = "overview_catA";
            this.overview_catA.Size = new System.Drawing.Size(121, 21);
            this.overview_catA.TabIndex = 22;
            // 
            // overview_cardBorder
            // 
            this.overview_cardBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.overview_cardBorder.Controls.Add(this.overview_cardBackground);
            this.overview_cardBorder.Location = new System.Drawing.Point(3, 3);
            this.overview_cardBorder.Name = "overview_cardBorder";
            this.overview_cardBorder.Size = new System.Drawing.Size(278, 34);
            this.overview_cardBorder.TabIndex = 21;
            // 
            // overview_cardBackground
            // 
            this.overview_cardBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.overview_cardBackground.Controls.Add(this.overview_description);
            this.overview_cardBackground.Controls.Add(this.label17);
            this.overview_cardBackground.Controls.Add(this.label16);
            this.overview_cardBackground.Controls.Add(this.overview_author);
            this.overview_cardBackground.Controls.Add(this.overview_title);
            this.overview_cardBackground.Controls.Add(this.overview_icon);
            this.overview_cardBackground.Location = new System.Drawing.Point(1, 1);
            this.overview_cardBackground.Name = "overview_cardBackground";
            this.overview_cardBackground.Size = new System.Drawing.Size(276, 32);
            this.overview_cardBackground.TabIndex = 1;
            // 
            // overview_description
            // 
            this.overview_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.overview_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overview_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overview_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.overview_description.Location = new System.Drawing.Point(35, 16);
            this.overview_description.Name = "overview_description";
            this.overview_description.Size = new System.Drawing.Size(238, 11);
            this.overview_description.TabIndex = 7;
            this.overview_description.Text = "Description";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(159, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "(";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(267, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = ")";
            // 
            // overview_author
            // 
            this.overview_author.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.overview_author.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overview_author.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overview_author.ForeColor = System.Drawing.Color.Black;
            this.overview_author.Location = new System.Drawing.Point(169, 3);
            this.overview_author.Name = "overview_author";
            this.overview_author.Size = new System.Drawing.Size(97, 11);
            this.overview_author.TabIndex = 4;
            this.overview_author.Text = "Author";
            // 
            // overview_title
            // 
            this.overview_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.overview_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overview_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overview_title.ForeColor = System.Drawing.Color.Black;
            this.overview_title.Location = new System.Drawing.Point(35, 3);
            this.overview_title.Name = "overview_title";
            this.overview_title.Size = new System.Drawing.Size(125, 11);
            this.overview_title.TabIndex = 3;
            this.overview_title.Text = "Title";
            // 
            // overview_icon
            // 
            this.overview_icon.Location = new System.Drawing.Point(1, 1);
            this.overview_icon.Name = "overview_icon";
            this.overview_icon.Size = new System.Drawing.Size(30, 30);
            this.overview_icon.TabIndex = 0;
            this.overview_icon.TabStop = false;
            // 
            // overview_clothesLabel
            // 
            this.overview_clothesLabel.AutoSize = true;
            this.overview_clothesLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.overview_clothesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overview_clothesLabel.Location = new System.Drawing.Point(21, 0);
            this.overview_clothesLabel.Margin = new System.Windows.Forms.Padding(0);
            this.overview_clothesLabel.Name = "overview_clothesLabel";
            this.overview_clothesLabel.Size = new System.Drawing.Size(45, 21);
            this.overview_clothesLabel.TabIndex = 36;
            this.overview_clothesLabel.Text = "Clothing";
            this.overview_clothesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // overview_skinLabel
            // 
            this.overview_skinLabel.AutoSize = true;
            this.overview_skinLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.overview_skinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overview_skinLabel.Location = new System.Drawing.Point(21, 0);
            this.overview_skinLabel.Margin = new System.Windows.Forms.Padding(0);
            this.overview_skinLabel.Name = "overview_skinLabel";
            this.overview_skinLabel.Size = new System.Drawing.Size(28, 21);
            this.overview_skinLabel.TabIndex = 35;
            this.overview_skinLabel.Text = "Skin";
            this.overview_skinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // overview_juni
            // 
            this.overview_juni.Image = ((System.Drawing.Image)(resources.GetObject("overview_juni.Image")));
            this.overview_juni.Location = new System.Drawing.Point(3, 3);
            this.overview_juni.Name = "overview_juni";
            this.overview_juni.Size = new System.Drawing.Size(30, 30);
            this.overview_juni.TabIndex = 32;
            this.overview_juni.TabStop = false;
            // 
            // overview_info
            // 
            this.overview_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.overview_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overview_info.Image = ((System.Drawing.Image)(resources.GetObject("overview_info.Image")));
            this.overview_info.Location = new System.Drawing.Point(0, 17);
            this.overview_info.Margin = new System.Windows.Forms.Padding(0);
            this.overview_info.Name = "overview_info";
            this.overview_info.Size = new System.Drawing.Size(602, 242);
            this.overview_info.TabIndex = 20;
            this.overview_info.TabStop = false;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressToolStripMenuItem,
            this.compressAndUploadToKnyttlevelscomToolStripMenuItem});
            this.contextMenu1.Name = "contextMenuStrip1";
            this.contextMenu1.Size = new System.Drawing.Size(291, 48);
            // 
            // compressToolStripMenuItem
            // 
            this.compressToolStripMenuItem.Name = "compressToolStripMenuItem";
            this.compressToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.compressToolStripMenuItem.Text = "Compress";
            // 
            // compressAndUploadToKnyttlevelscomToolStripMenuItem
            // 
            this.compressAndUploadToKnyttlevelscomToolStripMenuItem.Name = "compressAndUploadToKnyttlevelscomToolStripMenuItem";
            this.compressAndUploadToKnyttlevelscomToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.compressAndUploadToKnyttlevelscomToolStripMenuItem.Text = "Compress and upload to knyttlevels.com";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label18);
            this.flowLayoutPanel1.Controls.Add(this.overview_screenCount);
            this.flowLayoutPanel1.Controls.Add(this.overview_size);
            this.flowLayoutPanel1.Controls.Add(this.label19);
            this.flowLayoutPanel1.Controls.Add(this.overview_catA);
            this.flowLayoutPanel1.Controls.Add(this.overview_catB);
            this.flowLayoutPanel1.Controls.Add(this.label20);
            this.flowLayoutPanel1.Controls.Add(this.overview_diffA);
            this.flowLayoutPanel1.Controls.Add(this.overview_diffB);
            this.flowLayoutPanel1.Controls.Add(this.overview_diffC);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(475, 14);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(127, 214);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.overview_cardBorder);
            this.flowLayoutPanel2.Controls.Add(this.overview_publish);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 53);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(285, 137);
            this.flowLayoutPanel2.TabIndex = 40;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.overview_juni);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(344, 76);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(72, 90);
            this.flowLayoutPanel4.TabIndex = 42;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.overview_skinPreview);
            this.flowLayoutPanel5.Controls.Add(this.overview_skinLabel);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(49, 21);
            this.flowLayoutPanel5.TabIndex = 43;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel6.Controls.Add(this.overview_clothesPreview);
            this.flowLayoutPanel6.Controls.Add(this.overview_clothesLabel);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 66);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(66, 21);
            this.flowLayoutPanel6.TabIndex = 44;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.overview_overlayCheck);
            this.flowLayoutPanel3.Controls.Add(this.overview_info);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(602, 259);
            this.flowLayoutPanel3.TabIndex = 43;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 259);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 243);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(299, 186);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 502);
            this.panel1.TabIndex = 45;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1200, 875);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // OverviewTab
            // 
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OverviewTab";
            this.Size = new System.Drawing.Size(1200, 875);
            this.overview_cardBorder.ResumeLayout(false);
            this.overview_cardBackground.ResumeLayout(false);
            this.overview_cardBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overview_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overview_juni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overview_info)).EndInit();
            this.contextMenu1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label overview_screenCount;
        private CheckBox overview_overlayCheck;
        private Panel overview_clothesPreview;
        private Panel overview_skinPreview;
        private PictureBox overview_juni;
        private Label label20;
        private Label label19;
        private Label label18;
        private Button overview_publish;
        private ComboBox overview_size;
        private ComboBox overview_diffC;
        private ComboBox overview_diffB;
        private ComboBox overview_diffA;
        private ComboBox overview_catB;
        private ComboBox overview_catA;
        private PictureBox overview_info;
        private Panel overview_cardBorder;
        private Panel overview_cardBackground;
        private TextBox overview_description;
        private Label label17;
        private Label label16;
        private TextBox overview_author;
        private TextBox overview_title;
        private PictureBox overview_icon;
        private Label overview_clothesLabel;
        private ColorDialog overview_colorDialog;
        private ContextMenuStrip contextMenu1;
        private ToolStripMenuItem compressToolStripMenuItem;
        private ToolStripMenuItem compressAndUploadToKnyttlevelscomToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label overview_skinLabel;
    }
}
