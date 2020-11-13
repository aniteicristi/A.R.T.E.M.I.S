namespace A.R.T.E.M.I.S
{
    partial class GitConfigurationPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitConfigurationPanel));
            this.gitPath = new System.Windows.Forms.TextBox();
            this.gitPathLabel = new System.Windows.Forms.Label();
            this.gitName = new System.Windows.Forms.TextBox();
            this.gitNameLable = new System.Windows.Forms.Label();
            this.gitLocalLable = new System.Windows.Forms.Label();
            this.localPathButton = new System.Windows.Forms.Button();
            this.cloneButton = new System.Windows.Forms.Button();
            this.savedRepoList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gitPath
            // 
            this.gitPath.Location = new System.Drawing.Point(12, 33);
            this.gitPath.Name = "gitPath";
            this.gitPath.Size = new System.Drawing.Size(386, 20);
            this.gitPath.TabIndex = 0;
            // 
            // gitPathLabel
            // 
            this.gitPathLabel.AutoSize = true;
            this.gitPathLabel.Location = new System.Drawing.Point(13, 14);
            this.gitPathLabel.Name = "gitPathLabel";
            this.gitPathLabel.Size = new System.Drawing.Size(80, 13);
            this.gitPathLabel.TabIndex = 1;
            this.gitPathLabel.Text = "Repository Link";
            // 
            // gitName
            // 
            this.gitName.Location = new System.Drawing.Point(12, 80);
            this.gitName.Name = "gitName";
            this.gitName.Size = new System.Drawing.Size(251, 20);
            this.gitName.TabIndex = 2;
            // 
            // gitNameLable
            // 
            this.gitNameLable.AutoSize = true;
            this.gitNameLable.Location = new System.Drawing.Point(13, 64);
            this.gitNameLable.Name = "gitNameLable";
            this.gitNameLable.Size = new System.Drawing.Size(88, 13);
            this.gitNameLable.TabIndex = 3;
            this.gitNameLable.Text = "Repository Name";
            // 
            // gitLocalLable
            // 
            this.gitLocalLable.AutoSize = true;
            this.gitLocalLable.Location = new System.Drawing.Point(16, 124);
            this.gitLocalLable.Name = "gitLocalLable";
            this.gitLocalLable.Size = new System.Drawing.Size(114, 13);
            this.gitLocalLable.TabIndex = 4;
            this.gitLocalLable.Text = "Repository Local Path:";
            // 
            // localPathButton
            // 
            this.localPathButton.Location = new System.Drawing.Point(55, 150);
            this.localPathButton.Name = "localPathButton";
            this.localPathButton.Size = new System.Drawing.Size(75, 19);
            this.localPathButton.TabIndex = 5;
            this.localPathButton.Text = "ChoosePath";
            this.localPathButton.UseVisualStyleBackColor = true;
            this.localPathButton.Click += new System.EventHandler(this.LocalPathButton_Click);
            // 
            // cloneButton
            // 
            this.cloneButton.Location = new System.Drawing.Point(456, 33);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(78, 67);
            this.cloneButton.TabIndex = 6;
            this.cloneButton.Text = "CLONE!";
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.CloneButton_Click);
            // 
            // savedRepoList
            // 
            this.savedRepoList.Location = new System.Drawing.Point(197, 150);
            this.savedRepoList.Multiline = true;
            this.savedRepoList.Name = "savedRepoList";
            this.savedRepoList.ReadOnly = true;
            this.savedRepoList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.savedRepoList.Size = new System.Drawing.Size(337, 92);
            this.savedRepoList.TabIndex = 7;
            // 
            // GitConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 253);
            this.Controls.Add(this.savedRepoList);
            this.Controls.Add(this.cloneButton);
            this.Controls.Add(this.localPathButton);
            this.Controls.Add(this.gitLocalLable);
            this.Controls.Add(this.gitNameLable);
            this.Controls.Add(this.gitName);
            this.Controls.Add(this.gitPathLabel);
            this.Controls.Add(this.gitPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GitConfigurationPanel";
            this.Text = "GitConfigurationPanel";
            this.Load += new System.EventHandler(this.GitConfigurationPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gitPath;
        private System.Windows.Forms.Label gitPathLabel;
        private System.Windows.Forms.TextBox gitName;
        private System.Windows.Forms.Label gitNameLable;
        private System.Windows.Forms.Label gitLocalLable;
        private System.Windows.Forms.Button localPathButton;
        private System.Windows.Forms.Button cloneButton;
        private System.Windows.Forms.TextBox savedRepoList;
    }
}