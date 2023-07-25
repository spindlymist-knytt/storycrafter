using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Crafter.Forms.EditorForm {
    partial class ScreenTab {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.screen_layer7Label = new System.Windows.Forms.Label();
            this.screen_layer6Label = new System.Windows.Forms.Label();
            this.screen_tilesetA = new System.Windows.Forms.NumericUpDown();
            this.screen_layer5Label = new System.Windows.Forms.Label();
            this.screen_tilesetB = new System.Windows.Forms.NumericUpDown();
            this.screen_layer4Label = new System.Windows.Forms.Label();
            this.screen_gradient = new System.Windows.Forms.NumericUpDown();
            this.screen_layer3Label = new System.Windows.Forms.Label();
            this.screen_brushX = new System.Windows.Forms.NumericUpDown();
            this.screen_layer2Label = new System.Windows.Forms.Label();
            this.screen_brushY = new System.Windows.Forms.NumericUpDown();
            this.screen_layer1Label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.screen_layer0Label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.screen_layer7 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.screen_layer6 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.screen_layer5 = new System.Windows.Forms.RadioButton();
            this.screen_music = new System.Windows.Forms.NumericUpDown();
            this.screen_layer4 = new System.Windows.Forms.RadioButton();
            this.screen_ambiB = new System.Windows.Forms.NumericUpDown();
            this.screen_layer3 = new System.Windows.Forms.RadioButton();
            this.screen_ambiA = new System.Windows.Forms.NumericUpDown();
            this.screen_layer2 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.screen_layer1 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.screen_layer0 = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.screen_tilesetViewB = new Story_Crafter.TilesetViewPanel();
            this.screen_comboPatterns = new System.Windows.Forms.ComboBox();
            this.screen_tilesetViewA = new Story_Crafter.TilesetViewPanel();
            this.screen_buttonEditPattern = new System.Windows.Forms.Button();
            this.screen_objectList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.screen_bankList = new System.Windows.Forms.ComboBox();
            this.screen_checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.screen_mainView = new Story_Crafter.Controls.CanvasPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_gradient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_brushX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_brushY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_music)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_ambiB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_ambiA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_mainView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 680);
            this.tableLayoutPanel1.TabIndex = 88;
            // 
            // screen_layer7Label
            // 
            this.screen_layer7Label.AutoSize = true;
            this.screen_layer7Label.Location = new System.Drawing.Point(140, 267);
            this.screen_layer7Label.Name = "screen_layer7Label";
            this.screen_layer7Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer7Label.TabIndex = 64;
            this.screen_layer7Label.Text = "7";
            // 
            // screen_layer6Label
            // 
            this.screen_layer6Label.AutoSize = true;
            this.screen_layer6Label.Location = new System.Drawing.Point(120, 267);
            this.screen_layer6Label.Name = "screen_layer6Label";
            this.screen_layer6Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer6Label.TabIndex = 63;
            this.screen_layer6Label.Text = "6";
            // 
            // screen_tilesetA
            // 
            this.screen_tilesetA.Location = new System.Drawing.Point(168, 264);
            this.screen_tilesetA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.screen_tilesetA.Name = "screen_tilesetA";
            this.screen_tilesetA.Size = new System.Drawing.Size(40, 20);
            this.screen_tilesetA.TabIndex = 65;
            // 
            // screen_layer5Label
            // 
            this.screen_layer5Label.AutoSize = true;
            this.screen_layer5Label.Location = new System.Drawing.Point(100, 267);
            this.screen_layer5Label.Name = "screen_layer5Label";
            this.screen_layer5Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer5Label.TabIndex = 62;
            this.screen_layer5Label.Text = "5";
            // 
            // screen_tilesetB
            // 
            this.screen_tilesetB.Location = new System.Drawing.Point(220, 264);
            this.screen_tilesetB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.screen_tilesetB.Name = "screen_tilesetB";
            this.screen_tilesetB.Size = new System.Drawing.Size(40, 20);
            this.screen_tilesetB.TabIndex = 66;
            // 
            // screen_layer4Label
            // 
            this.screen_layer4Label.AutoSize = true;
            this.screen_layer4Label.Location = new System.Drawing.Point(80, 267);
            this.screen_layer4Label.Name = "screen_layer4Label";
            this.screen_layer4Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer4Label.TabIndex = 61;
            this.screen_layer4Label.Text = "4";
            // 
            // screen_gradient
            // 
            this.screen_gradient.Location = new System.Drawing.Point(272, 264);
            this.screen_gradient.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.screen_gradient.Name = "screen_gradient";
            this.screen_gradient.Size = new System.Drawing.Size(40, 20);
            this.screen_gradient.TabIndex = 67;
            // 
            // screen_layer3Label
            // 
            this.screen_layer3Label.AutoSize = true;
            this.screen_layer3Label.Location = new System.Drawing.Point(60, 267);
            this.screen_layer3Label.Name = "screen_layer3Label";
            this.screen_layer3Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer3Label.TabIndex = 60;
            this.screen_layer3Label.Text = "3";
            // 
            // screen_brushX
            // 
            this.screen_brushX.Location = new System.Drawing.Point(324, 264);
            this.screen_brushX.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.screen_brushX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screen_brushX.Name = "screen_brushX";
            this.screen_brushX.Size = new System.Drawing.Size(40, 20);
            this.screen_brushX.TabIndex = 68;
            this.screen_brushX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // screen_layer2Label
            // 
            this.screen_layer2Label.AutoSize = true;
            this.screen_layer2Label.Location = new System.Drawing.Point(40, 267);
            this.screen_layer2Label.Name = "screen_layer2Label";
            this.screen_layer2Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer2Label.TabIndex = 59;
            this.screen_layer2Label.Text = "2";
            // 
            // screen_brushY
            // 
            this.screen_brushY.Location = new System.Drawing.Point(370, 264);
            this.screen_brushY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.screen_brushY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screen_brushY.Name = "screen_brushY";
            this.screen_brushY.Size = new System.Drawing.Size(40, 20);
            this.screen_brushY.TabIndex = 69;
            this.screen_brushY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // screen_layer1Label
            // 
            this.screen_layer1Label.AutoSize = true;
            this.screen_layer1Label.Location = new System.Drawing.Point(20, 267);
            this.screen_layer1Label.Name = "screen_layer1Label";
            this.screen_layer1Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer1Label.TabIndex = 58;
            this.screen_layer1Label.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(163, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "Tileset A";
            // 
            // screen_layer0Label
            // 
            this.screen_layer0Label.AutoSize = true;
            this.screen_layer0Label.Location = new System.Drawing.Point(0, 267);
            this.screen_layer0Label.Name = "screen_layer0Label";
            this.screen_layer0Label.Size = new System.Drawing.Size(13, 13);
            this.screen_layer0Label.TabIndex = 57;
            this.screen_layer0Label.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 245);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Tileset B";
            // 
            // screen_layer7
            // 
            this.screen_layer7.AutoSize = true;
            this.screen_layer7.Location = new System.Drawing.Point(140, 251);
            this.screen_layer7.Name = "screen_layer7";
            this.screen_layer7.Size = new System.Drawing.Size(14, 13);
            this.screen_layer7.TabIndex = 56;
            this.screen_layer7.Tag = "";
            this.screen_layer7.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Gradient";
            // 
            // screen_layer6
            // 
            this.screen_layer6.AutoSize = true;
            this.screen_layer6.Location = new System.Drawing.Point(120, 251);
            this.screen_layer6.Name = "screen_layer6";
            this.screen_layer6.Size = new System.Drawing.Size(14, 13);
            this.screen_layer6.TabIndex = 55;
            this.screen_layer6.Tag = "";
            this.screen_layer6.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 73;
            this.label12.Text = "Brush size";
            // 
            // screen_layer5
            // 
            this.screen_layer5.AutoSize = true;
            this.screen_layer5.Location = new System.Drawing.Point(100, 251);
            this.screen_layer5.Name = "screen_layer5";
            this.screen_layer5.Size = new System.Drawing.Size(14, 13);
            this.screen_layer5.TabIndex = 54;
            this.screen_layer5.Tag = "";
            this.screen_layer5.UseVisualStyleBackColor = true;
            // 
            // screen_music
            // 
            this.screen_music.Location = new System.Drawing.Point(748, 264);
            this.screen_music.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.screen_music.Name = "screen_music";
            this.screen_music.Size = new System.Drawing.Size(40, 20);
            this.screen_music.TabIndex = 74;
            // 
            // screen_layer4
            // 
            this.screen_layer4.AutoSize = true;
            this.screen_layer4.Location = new System.Drawing.Point(80, 251);
            this.screen_layer4.Name = "screen_layer4";
            this.screen_layer4.Size = new System.Drawing.Size(14, 13);
            this.screen_layer4.TabIndex = 53;
            this.screen_layer4.Tag = "";
            this.screen_layer4.UseVisualStyleBackColor = true;
            // 
            // screen_ambiB
            // 
            this.screen_ambiB.Location = new System.Drawing.Point(680, 264);
            this.screen_ambiB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.screen_ambiB.Name = "screen_ambiB";
            this.screen_ambiB.Size = new System.Drawing.Size(56, 20);
            this.screen_ambiB.TabIndex = 75;
            // 
            // screen_layer3
            // 
            this.screen_layer3.AutoSize = true;
            this.screen_layer3.Checked = true;
            this.screen_layer3.Location = new System.Drawing.Point(60, 251);
            this.screen_layer3.Name = "screen_layer3";
            this.screen_layer3.Size = new System.Drawing.Size(14, 13);
            this.screen_layer3.TabIndex = 52;
            this.screen_layer3.TabStop = true;
            this.screen_layer3.Tag = "";
            this.screen_layer3.UseVisualStyleBackColor = true;
            // 
            // screen_ambiA
            // 
            this.screen_ambiA.Location = new System.Drawing.Point(612, 264);
            this.screen_ambiA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.screen_ambiA.Name = "screen_ambiA";
            this.screen_ambiA.Size = new System.Drawing.Size(56, 20);
            this.screen_ambiA.TabIndex = 76;
            // 
            // screen_layer2
            // 
            this.screen_layer2.AutoSize = true;
            this.screen_layer2.Location = new System.Drawing.Point(40, 251);
            this.screen_layer2.Name = "screen_layer2";
            this.screen_layer2.Size = new System.Drawing.Size(14, 13);
            this.screen_layer2.TabIndex = 51;
            this.screen_layer2.Tag = "";
            this.screen_layer2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(608, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 77;
            this.label13.Text = "Ambiance A";
            // 
            // screen_layer1
            // 
            this.screen_layer1.AutoSize = true;
            this.screen_layer1.Location = new System.Drawing.Point(20, 251);
            this.screen_layer1.Name = "screen_layer1";
            this.screen_layer1.Size = new System.Drawing.Size(14, 13);
            this.screen_layer1.TabIndex = 50;
            this.screen_layer1.Tag = "";
            this.screen_layer1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(677, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 78;
            this.label14.Text = "Ambiance B";
            // 
            // screen_layer0
            // 
            this.screen_layer0.AutoSize = true;
            this.screen_layer0.Location = new System.Drawing.Point(0, 251);
            this.screen_layer0.Name = "screen_layer0";
            this.screen_layer0.Size = new System.Drawing.Size(14, 13);
            this.screen_layer0.TabIndex = 49;
            this.screen_layer0.Tag = "";
            this.screen_layer0.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(745, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 79;
            this.label15.Text = "Music";
            // 
            // screen_tilesetViewB
            // 
            this.screen_tilesetViewB.Active = false;
            this.screen_tilesetViewB.BackgroundImage = global::Story_Crafter.Properties.Resources.checkers;
            this.screen_tilesetViewB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen_tilesetViewB.Location = new System.Drawing.Point(402, 290);
            this.screen_tilesetViewB.Name = "screen_tilesetViewB";
            this.screen_tilesetViewB.Size = new System.Drawing.Size(386, 204);
            this.screen_tilesetViewB.TabIndex = 81;
            this.screen_tilesetViewB.TabStop = false;
            // 
            // screen_comboPatterns
            // 
            this.screen_comboPatterns.FormattingEnabled = true;
            this.screen_comboPatterns.Location = new System.Drawing.Point(416, 264);
            this.screen_comboPatterns.Name = "screen_comboPatterns";
            this.screen_comboPatterns.Size = new System.Drawing.Size(144, 21);
            this.screen_comboPatterns.TabIndex = 83;
            // 
            // screen_tilesetViewA
            // 
            this.screen_tilesetViewA.Active = false;
            this.screen_tilesetViewA.BackgroundImage = global::Story_Crafter.Properties.Resources.checkers;
            this.screen_tilesetViewA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen_tilesetViewA.Location = new System.Drawing.Point(0, 290);
            this.screen_tilesetViewA.Name = "screen_tilesetViewA";
            this.screen_tilesetViewA.Size = new System.Drawing.Size(386, 204);
            this.screen_tilesetViewA.TabIndex = 80;
            this.screen_tilesetViewA.TabStop = false;
            // 
            // screen_buttonEditPattern
            // 
            this.screen_buttonEditPattern.Location = new System.Drawing.Point(566, 263);
            this.screen_buttonEditPattern.Name = "screen_buttonEditPattern";
            this.screen_buttonEditPattern.Size = new System.Drawing.Size(40, 23);
            this.screen_buttonEditPattern.TabIndex = 84;
            this.screen_buttonEditPattern.Text = "New";
            this.screen_buttonEditPattern.UseVisualStyleBackColor = true;
            // 
            // screen_objectList
            // 
            this.screen_objectList.HideSelection = false;
            this.screen_objectList.Location = new System.Drawing.Point(610, 28);
            this.screen_objectList.MultiSelect = false;
            this.screen_objectList.Name = "screen_objectList";
            this.screen_objectList.Size = new System.Drawing.Size(178, 214);
            this.screen_objectList.TabIndex = 48;
            this.screen_objectList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Patterns";
            // 
            // screen_bankList
            // 
            this.screen_bankList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screen_bankList.FormattingEnabled = true;
            this.screen_bankList.Location = new System.Drawing.Point(610, 0);
            this.screen_bankList.Name = "screen_bankList";
            this.screen_bankList.Size = new System.Drawing.Size(178, 21);
            this.screen_bankList.TabIndex = 47;
            // 
            // screen_checkBoxOverwrite
            // 
            this.screen_checkBoxOverwrite.AutoSize = true;
            this.screen_checkBoxOverwrite.Location = new System.Drawing.Point(480, 244);
            this.screen_checkBoxOverwrite.Name = "screen_checkBoxOverwrite";
            this.screen_checkBoxOverwrite.Size = new System.Drawing.Size(122, 17);
            this.screen_checkBoxOverwrite.TabIndex = 86;
            this.screen_checkBoxOverwrite.Text = "Empty tiles overwrite";
            this.screen_checkBoxOverwrite.UseVisualStyleBackColor = true;
            this.screen_checkBoxOverwrite.Visible = false;
            // 
            // screen_mainView
            // 
            this.screen_mainView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen_mainView.GetBrushSize = null;
            this.screen_mainView.GetCanvas = null;
            this.screen_mainView.GetGradient = null;
            this.screen_mainView.GetLayer = null;
            this.screen_mainView.GetObject = null;
            this.screen_mainView.GetSelection = null;
            this.screen_mainView.GetTilesetA = null;
            this.screen_mainView.GetTilesetB = null;
            this.screen_mainView.GetTilesetIndex = null;
            this.screen_mainView.GetTool = null;
            this.screen_mainView.Location = new System.Drawing.Point(0, 0);
            this.screen_mainView.Name = "screen_mainView";
            this.screen_mainView.Resizable = false;
            this.screen_mainView.Size = new System.Drawing.Size(602, 242);
            this.screen_mainView.TabIndex = 82;
            this.screen_mainView.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.screen_mainView);
            this.panel1.Controls.Add(this.screen_checkBoxOverwrite);
            this.panel1.Controls.Add(this.screen_bankList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.screen_objectList);
            this.panel1.Controls.Add(this.screen_buttonEditPattern);
            this.panel1.Controls.Add(this.screen_tilesetViewA);
            this.panel1.Controls.Add(this.screen_comboPatterns);
            this.panel1.Controls.Add(this.screen_tilesetViewB);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.screen_layer0);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.screen_layer1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.screen_layer2);
            this.panel1.Controls.Add(this.screen_ambiA);
            this.panel1.Controls.Add(this.screen_layer3);
            this.panel1.Controls.Add(this.screen_ambiB);
            this.panel1.Controls.Add(this.screen_layer4);
            this.panel1.Controls.Add(this.screen_music);
            this.panel1.Controls.Add(this.screen_layer5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.screen_layer6);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.screen_layer7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.screen_layer0Label);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.screen_layer1Label);
            this.panel1.Controls.Add(this.screen_brushY);
            this.panel1.Controls.Add(this.screen_layer2Label);
            this.panel1.Controls.Add(this.screen_brushX);
            this.panel1.Controls.Add(this.screen_layer3Label);
            this.panel1.Controls.Add(this.screen_gradient);
            this.panel1.Controls.Add(this.screen_layer4Label);
            this.panel1.Controls.Add(this.screen_tilesetB);
            this.panel1.Controls.Add(this.screen_layer5Label);
            this.panel1.Controls.Add(this.screen_tilesetA);
            this.panel1.Controls.Add(this.screen_layer6Label);
            this.panel1.Controls.Add(this.screen_layer7Label);
            this.panel1.Location = new System.Drawing.Point(104, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 497);
            this.panel1.TabIndex = 87;
            // 
            // ScreenTab
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScreenTab";
            this.Size = new System.Drawing.Size(1000, 680);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_gradient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_brushX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_brushY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_music)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_ambiB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_ambiA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_tilesetViewA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screen_mainView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Controls.CanvasPanel screen_mainView;
        private System.Windows.Forms.CheckBox screen_checkBoxOverwrite;
        private System.Windows.Forms.ComboBox screen_bankList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView screen_objectList;
        private System.Windows.Forms.Button screen_buttonEditPattern;
        private TilesetViewPanel screen_tilesetViewA;
        private System.Windows.Forms.ComboBox screen_comboPatterns;
        private TilesetViewPanel screen_tilesetViewB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton screen_layer0;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton screen_layer1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton screen_layer2;
        private System.Windows.Forms.NumericUpDown screen_ambiA;
        private System.Windows.Forms.RadioButton screen_layer3;
        private System.Windows.Forms.NumericUpDown screen_ambiB;
        private System.Windows.Forms.RadioButton screen_layer4;
        private System.Windows.Forms.NumericUpDown screen_music;
        private System.Windows.Forms.RadioButton screen_layer5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton screen_layer6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton screen_layer7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label screen_layer0Label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label screen_layer1Label;
        private System.Windows.Forms.NumericUpDown screen_brushY;
        private System.Windows.Forms.Label screen_layer2Label;
        private System.Windows.Forms.NumericUpDown screen_brushX;
        private System.Windows.Forms.Label screen_layer3Label;
        private System.Windows.Forms.NumericUpDown screen_gradient;
        private System.Windows.Forms.Label screen_layer4Label;
        private System.Windows.Forms.NumericUpDown screen_tilesetB;
        private System.Windows.Forms.Label screen_layer5Label;
        private System.Windows.Forms.NumericUpDown screen_tilesetA;
        private System.Windows.Forms.Label screen_layer6Label;
        private System.Windows.Forms.Label screen_layer7Label;
    }
}
