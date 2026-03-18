namespace Story_Crafter.Controls.Panes {
    partial class AudioPane {
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
            label15 = new System.Windows.Forms.Label();
            screen_music = new System.Windows.Forms.NumericUpDown();
            label13 = new System.Windows.Forms.Label();
            screen_ambiA = new System.Windows.Forms.NumericUpDown();
            label14 = new System.Windows.Forms.Label();
            screen_ambiB = new System.Windows.Forms.NumericUpDown();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) screen_music).BeginInit();
            ((System.ComponentModel.ISupportInitialize) screen_ambiA).BeginInit();
            ((System.ComponentModel.ISupportInitialize) screen_ambiB).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label15);
            flowLayoutPanel1.Controls.Add(screen_music);
            flowLayoutPanel1.Controls.Add(label13);
            flowLayoutPanel1.Controls.Add(screen_ambiA);
            flowLayoutPanel1.Controls.Add(label14);
            flowLayoutPanel1.Controls.Add(screen_ambiB);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1205, 549);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(4, 0);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(39, 15);
            label15.TabIndex = 91;
            label15.Text = "Music";
            // 
            // screen_music
            // 
            screen_music.Location = new System.Drawing.Point(4, 18);
            screen_music.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_music.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            screen_music.Name = "screen_music";
            screen_music.Size = new System.Drawing.Size(47, 23);
            screen_music.TabIndex = 86;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(4, 44);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(72, 15);
            label13.TabIndex = 89;
            label13.Text = "Ambiance A";
            // 
            // screen_ambiA
            // 
            screen_ambiA.Location = new System.Drawing.Point(4, 62);
            screen_ambiA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_ambiA.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            screen_ambiA.Name = "screen_ambiA";
            screen_ambiA.Size = new System.Drawing.Size(65, 23);
            screen_ambiA.TabIndex = 88;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(4, 88);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(71, 15);
            label14.TabIndex = 90;
            label14.Text = "Ambiance B";
            // 
            // screen_ambiB
            // 
            screen_ambiB.Location = new System.Drawing.Point(4, 106);
            screen_ambiB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            screen_ambiB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            screen_ambiB.Name = "screen_ambiB";
            screen_ambiB.Size = new System.Drawing.Size(65, 23);
            screen_ambiB.TabIndex = 87;
            // 
            // AudioPane
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1205, 549);
            Controls.Add(flowLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AudioPane";
            Text = "Audio";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) screen_music).EndInit();
            ((System.ComponentModel.ISupportInitialize) screen_ambiA).EndInit();
            ((System.ComponentModel.ISupportInitialize) screen_ambiB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown screen_music;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown screen_ambiA;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown screen_ambiB;
    }
}
