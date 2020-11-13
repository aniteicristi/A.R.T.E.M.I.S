namespace A.R.T.E.M.I.S
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.speechHypothesisTextBox = new System.Windows.Forms.TextBox();
            this.mutedCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "ARTEMIS";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "A.R.T.E.M.I.S";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            // 
            // speechHypothesisTextBox
            // 
            this.speechHypothesisTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.speechHypothesisTextBox.Location = new System.Drawing.Point(12, 229);
            this.speechHypothesisTextBox.Name = "speechHypothesisTextBox";
            this.speechHypothesisTextBox.ReadOnly = true;
            this.speechHypothesisTextBox.Size = new System.Drawing.Size(212, 20);
            this.speechHypothesisTextBox.TabIndex = 1;
            // 
            // mutedCheckBox
            // 
            this.mutedCheckBox.AutoSize = true;
            this.mutedCheckBox.Location = new System.Drawing.Point(229, 233);
            this.mutedCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mutedCheckBox.Name = "mutedCheckBox";
            this.mutedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.mutedCheckBox.TabIndex = 2;
            this.mutedCheckBox.UseVisualStyleBackColor = true;
            this.mutedCheckBox.CheckedChanged += new System.EventHandler(this.MutedCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(254, 261);
            this.Controls.Add(this.mutedCheckBox);
            this.Controls.Add(this.speechHypothesisTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ARTEMIS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox speechHypothesisTextBox;
        private System.Windows.Forms.CheckBox mutedCheckBox;
    }
}

