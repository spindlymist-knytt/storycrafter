using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter.Controls.Tabs {
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewTab));
            overview_colorDialog = new ColorDialog();
            contextMenu_info = new ContextMenuStrip(components);
            menuItem_toggleOverlay = new ToolStripMenuItem();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            overview_info = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            overview_cardBorder = new Panel();
            overview_cardBackground = new Panel();
            overview_description = new TextBox();
            label17 = new Label();
            label16 = new Label();
            overview_author = new TextBox();
            overview_title = new TextBox();
            overview_icon = new PictureBox();
            overview_publish = new Button();
            flowLayoutPanel4 = new FlowLayoutPanel();
            overview_juni = new PictureBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            overview_skinPreview = new Panel();
            overview_skinLabel = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            overview_clothesPreview = new Panel();
            overview_clothesLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label18 = new Label();
            overview_screenCount = new Label();
            overview_size = new ComboBox();
            label19 = new Label();
            overview_catA = new ComboBox();
            overview_catB = new ComboBox();
            label20 = new Label();
            overview_diffA = new ComboBox();
            overview_diffB = new ComboBox();
            overview_diffC = new ComboBox();
            contextMenu_info.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) overview_info).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            overview_cardBorder.SuspendLayout();
            overview_cardBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) overview_icon).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) overview_juni).BeginInit();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenu_info
            // 
            contextMenu_info.Items.AddRange(new ToolStripItem[] { menuItem_toggleOverlay });
            contextMenu_info.Name = "contextMenuStrip1";
            contextMenu_info.Size = new Size(115, 26);
            // 
            // menuItem_toggleOverlay
            // 
            menuItem_toggleOverlay.Checked = true;
            menuItem_toggleOverlay.CheckOnClick = true;
            menuItem_toggleOverlay.CheckState = CheckState.Checked;
            menuItem_toggleOverlay.Name = "menuItem_toggleOverlay";
            menuItem_toggleOverlay.Size = new Size(114, 22);
            menuItem_toggleOverlay.Text = "Overlay";
            menuItem_toggleOverlay.Click += menuItem_toggleOverlay_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.Window;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 374F));
            tableLayoutPanel2.Size = new Size(1200, 875);
            tableLayoutPanel2.TabIndex = 46;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(overview_info, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel4, 1, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 1);
            tableLayoutPanel1.Location = new Point(299, 200);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(602, 474);
            tableLayoutPanel1.TabIndex = 44;
            // 
            // overview_info
            // 
            overview_info.BackgroundImageLayout = ImageLayout.Center;
            overview_info.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(overview_info, 3);
            overview_info.ContextMenuStrip = contextMenu_info;
            overview_info.Image = (Image) resources.GetObject("overview_info.Image");
            overview_info.Location = new Point(0, 0);
            overview_info.Margin = new Padding(0);
            overview_info.Name = "overview_info";
            overview_info.Size = new Size(602, 242);
            overview_info.TabIndex = 45;
            overview_info.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Left;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(overview_cardBorder);
            flowLayoutPanel2.Controls.Add(overview_publish);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(0, 289);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(285, 137);
            flowLayoutPanel2.TabIndex = 40;
            // 
            // overview_cardBorder
            // 
            overview_cardBorder.BackColor = Color.FromArgb(  151,   151,   151);
            overview_cardBorder.Controls.Add(overview_cardBackground);
            overview_cardBorder.Location = new Point(3, 3);
            overview_cardBorder.Name = "overview_cardBorder";
            overview_cardBorder.Size = new Size(278, 34);
            overview_cardBorder.TabIndex = 21;
            // 
            // overview_cardBackground
            // 
            overview_cardBackground.BackColor = Color.FromArgb(  235,   235,   235);
            overview_cardBackground.Controls.Add(overview_description);
            overview_cardBackground.Controls.Add(label17);
            overview_cardBackground.Controls.Add(label16);
            overview_cardBackground.Controls.Add(overview_author);
            overview_cardBackground.Controls.Add(overview_title);
            overview_cardBackground.Controls.Add(overview_icon);
            overview_cardBackground.Location = new Point(1, 1);
            overview_cardBackground.Name = "overview_cardBackground";
            overview_cardBackground.Size = new Size(276, 32);
            overview_cardBackground.TabIndex = 1;
            // 
            // overview_description
            // 
            overview_description.BackColor = Color.FromArgb(  235,   235,   235);
            overview_description.BorderStyle = BorderStyle.None;
            overview_description.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            overview_description.ForeColor = Color.FromArgb(  75,   75,   75);
            overview_description.Location = new Point(35, 16);
            overview_description.Name = "overview_description";
            overview_description.Size = new Size(238, 11);
            overview_description.TabIndex = 7;
            overview_description.Text = "Description";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(159, 2);
            label17.Name = "label17";
            label17.Size = new Size(10, 13);
            label17.TabIndex = 6;
            label17.Text = "(";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(267, 2);
            label16.Name = "label16";
            label16.Size = new Size(10, 13);
            label16.TabIndex = 5;
            label16.Text = ")";
            // 
            // overview_author
            // 
            overview_author.BackColor = Color.FromArgb(  235,   235,   235);
            overview_author.BorderStyle = BorderStyle.None;
            overview_author.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            overview_author.ForeColor = Color.Black;
            overview_author.Location = new Point(169, 3);
            overview_author.Name = "overview_author";
            overview_author.Size = new Size(97, 11);
            overview_author.TabIndex = 4;
            overview_author.Text = "Author";
            // 
            // overview_title
            // 
            overview_title.BackColor = Color.FromArgb(  235,   235,   235);
            overview_title.BorderStyle = BorderStyle.None;
            overview_title.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            overview_title.ForeColor = Color.Black;
            overview_title.Location = new Point(35, 3);
            overview_title.Name = "overview_title";
            overview_title.Size = new Size(125, 11);
            overview_title.TabIndex = 3;
            overview_title.Text = "Title";
            // 
            // overview_icon
            // 
            overview_icon.Location = new Point(1, 1);
            overview_icon.Name = "overview_icon";
            overview_icon.Size = new Size(30, 30);
            overview_icon.TabIndex = 0;
            overview_icon.TabStop = false;
            // 
            // overview_publish
            // 
            overview_publish.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point);
            overview_publish.Location = new Point(3, 43);
            overview_publish.Name = "overview_publish";
            overview_publish.Size = new Size(279, 91);
            overview_publish.TabIndex = 28;
            overview_publish.Text = "Publish";
            overview_publish.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Anchor = AnchorStyles.None;
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(overview_juni);
            flowLayoutPanel4.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel4.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(340, 313);
            flowLayoutPanel4.Margin = new Padding(0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(80, 90);
            flowLayoutPanel4.TabIndex = 42;
            // 
            // overview_juni
            // 
            overview_juni.Anchor = AnchorStyles.None;
            overview_juni.Image = (Image) resources.GetObject("overview_juni.Image");
            overview_juni.Location = new Point(25, 3);
            overview_juni.Name = "overview_juni";
            overview_juni.Size = new Size(30, 30);
            overview_juni.TabIndex = 32;
            overview_juni.TabStop = false;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel5.Controls.Add(overview_skinPreview);
            flowLayoutPanel5.Controls.Add(overview_skinLabel);
            flowLayoutPanel5.Location = new Point(3, 39);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(50, 21);
            flowLayoutPanel5.TabIndex = 43;
            // 
            // overview_skinPreview
            // 
            overview_skinPreview.BackColor = Color.FromArgb(  216,   192,   166);
            overview_skinPreview.BorderStyle = BorderStyle.FixedSingle;
            overview_skinPreview.Cursor = Cursors.Hand;
            overview_skinPreview.Location = new Point(3, 3);
            overview_skinPreview.Name = "overview_skinPreview";
            overview_skinPreview.Size = new Size(15, 15);
            overview_skinPreview.TabIndex = 33;
            // 
            // overview_skinLabel
            // 
            overview_skinLabel.AutoSize = true;
            overview_skinLabel.Dock = DockStyle.Fill;
            overview_skinLabel.Location = new Point(21, 0);
            overview_skinLabel.Margin = new Padding(0);
            overview_skinLabel.Name = "overview_skinLabel";
            overview_skinLabel.Size = new Size(29, 21);
            overview_skinLabel.TabIndex = 35;
            overview_skinLabel.Text = "Skin";
            overview_skinLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel6.Controls.Add(overview_clothesPreview);
            flowLayoutPanel6.Controls.Add(overview_clothesLabel);
            flowLayoutPanel6.Location = new Point(3, 66);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(74, 21);
            flowLayoutPanel6.TabIndex = 44;
            // 
            // overview_clothesPreview
            // 
            overview_clothesPreview.BackColor = Color.FromArgb(  235,   235,   235);
            overview_clothesPreview.BorderStyle = BorderStyle.FixedSingle;
            overview_clothesPreview.Cursor = Cursors.Hand;
            overview_clothesPreview.Location = new Point(3, 3);
            overview_clothesPreview.Name = "overview_clothesPreview";
            overview_clothesPreview.Size = new Size(15, 15);
            overview_clothesPreview.TabIndex = 34;
            // 
            // overview_clothesLabel
            // 
            overview_clothesLabel.AutoSize = true;
            overview_clothesLabel.Dock = DockStyle.Fill;
            overview_clothesLabel.Location = new Point(21, 0);
            overview_clothesLabel.Margin = new Padding(0);
            overview_clothesLabel.Name = "overview_clothesLabel";
            overview_clothesLabel.Size = new Size(53, 21);
            overview_clothesLabel.TabIndex = 36;
            overview_clothesLabel.Text = "Clothing";
            overview_clothesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label18);
            flowLayoutPanel1.Controls.Add(overview_screenCount);
            flowLayoutPanel1.Controls.Add(overview_size);
            flowLayoutPanel1.Controls.Add(label19);
            flowLayoutPanel1.Controls.Add(overview_catA);
            flowLayoutPanel1.Controls.Add(overview_catB);
            flowLayoutPanel1.Controls.Add(label20);
            flowLayoutPanel1.Controls.Add(overview_diffA);
            flowLayoutPanel1.Controls.Add(overview_diffB);
            flowLayoutPanel1.Controls.Add(overview_diffC);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(475, 242);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(127, 232);
            flowLayoutPanel1.TabIndex = 39;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(3, 0);
            label18.Name = "label18";
            label18.Size = new Size(27, 15);
            label18.TabIndex = 29;
            label18.Text = "Size";
            // 
            // overview_screenCount
            // 
            overview_screenCount.AutoSize = true;
            overview_screenCount.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            overview_screenCount.ForeColor = Color.Gray;
            overview_screenCount.Location = new Point(3, 15);
            overview_screenCount.Name = "overview_screenCount";
            overview_screenCount.Size = new Size(48, 13);
            overview_screenCount.TabIndex = 38;
            overview_screenCount.Text = "Screens:";
            // 
            // overview_size
            // 
            overview_size.FormattingEnabled = true;
            overview_size.Location = new Point(3, 31);
            overview_size.Name = "overview_size";
            overview_size.Size = new Size(121, 23);
            overview_size.TabIndex = 27;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(3, 57);
            label19.Name = "label19";
            label19.Size = new Size(63, 15);
            label19.TabIndex = 30;
            label19.Text = "Categories";
            // 
            // overview_catA
            // 
            overview_catA.FormattingEnabled = true;
            overview_catA.Location = new Point(3, 75);
            overview_catA.Name = "overview_catA";
            overview_catA.Size = new Size(121, 23);
            overview_catA.TabIndex = 22;
            // 
            // overview_catB
            // 
            overview_catB.FormattingEnabled = true;
            overview_catB.Location = new Point(3, 104);
            overview_catB.Name = "overview_catB";
            overview_catB.Size = new Size(121, 23);
            overview_catB.TabIndex = 23;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(3, 130);
            label20.Name = "label20";
            label20.Size = new Size(63, 15);
            label20.TabIndex = 31;
            label20.Text = "Difficulties";
            // 
            // overview_diffA
            // 
            overview_diffA.FormattingEnabled = true;
            overview_diffA.Location = new Point(3, 148);
            overview_diffA.Name = "overview_diffA";
            overview_diffA.Size = new Size(121, 23);
            overview_diffA.TabIndex = 24;
            // 
            // overview_diffB
            // 
            overview_diffB.FormattingEnabled = true;
            overview_diffB.Location = new Point(3, 177);
            overview_diffB.Name = "overview_diffB";
            overview_diffB.Size = new Size(121, 23);
            overview_diffB.TabIndex = 25;
            // 
            // overview_diffC
            // 
            overview_diffC.FormattingEnabled = true;
            overview_diffC.Location = new Point(3, 206);
            overview_diffC.Name = "overview_diffC";
            overview_diffC.Size = new Size(121, 23);
            overview_diffC.TabIndex = 26;
            // 
            // OverviewTab
            // 
            Controls.Add(tableLayoutPanel2);
            Margin = new Padding(0);
            Name = "OverviewTab";
            Size = new Size(1200, 875);
            contextMenu_info.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) overview_info).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            overview_cardBorder.ResumeLayout(false);
            overview_cardBackground.ResumeLayout(false);
            overview_cardBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) overview_icon).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) overview_juni).EndInit();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ColorDialog overview_colorDialog;
        private ContextMenuStrip contextMenu_info;
        private ToolStripMenuItem menuItem_toggleOverlay;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel overview_cardBorder;
        private Panel overview_cardBackground;
        private TextBox overview_description;
        private Label label17;
        private Label label16;
        private TextBox overview_author;
        private TextBox overview_title;
        private PictureBox overview_icon;
        private Button overview_publish;
        private FlowLayoutPanel flowLayoutPanel4;
        private PictureBox overview_juni;
        private FlowLayoutPanel flowLayoutPanel5;
        private Panel overview_skinPreview;
        private Label overview_skinLabel;
        private FlowLayoutPanel flowLayoutPanel6;
        private Panel overview_clothesPreview;
        private Label overview_clothesLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label18;
        private Label overview_screenCount;
        private ComboBox overview_size;
        private Label label19;
        private ComboBox overview_catA;
        private ComboBox overview_catB;
        private Label label20;
        private ComboBox overview_diffA;
        private ComboBox overview_diffB;
        private ComboBox overview_diffC;
        private PictureBox overview_info;
    }
}
