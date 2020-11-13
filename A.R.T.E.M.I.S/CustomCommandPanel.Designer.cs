namespace A.R.T.E.M.I.S
{
    partial class CustomCommandPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomCommandPanel));
            this.commandsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newCommandButton = new System.Windows.Forms.Button();
            this.saveCommandButton = new System.Windows.Forms.Button();
            this.commandName = new System.Windows.Forms.TextBox();
            this.commandCodeLines = new System.Windows.Forms.TextBox();
            this.commandDescription = new System.Windows.Forms.TextBox();
            this.commandDescriptionLabel = new System.Windows.Forms.Label();
            this.commandCodeLabel = new System.Windows.Forms.Label();
            this.commandNameLabel = new System.Windows.Forms.Label();
            this.insertBox = new System.Windows.Forms.GroupBox();
            this.insertWaitButton = new System.Windows.Forms.Button();
            this.insertDialogueButton = new System.Windows.Forms.Button();
            this.insertPathButton = new System.Windows.Forms.Button();
            this.insertLinkButton = new System.Windows.Forms.Button();
            this.deleteCommandButton = new System.Windows.Forms.Button();
            this.insertBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandsPanel
            // 
            this.commandsPanel.AutoScroll = true;
            this.commandsPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.commandsPanel.Location = new System.Drawing.Point(12, 12);
            this.commandsPanel.Name = "commandsPanel";
            this.commandsPanel.Size = new System.Drawing.Size(175, 450);
            this.commandsPanel.TabIndex = 0;
            // 
            // newCommandButton
            // 
            this.newCommandButton.BackColor = System.Drawing.Color.PaleGreen;
            this.newCommandButton.Location = new System.Drawing.Point(274, 15);
            this.newCommandButton.Name = "newCommandButton";
            this.newCommandButton.Size = new System.Drawing.Size(75, 23);
            this.newCommandButton.TabIndex = 1;
            this.newCommandButton.Text = "NEW";
            this.newCommandButton.UseVisualStyleBackColor = false;
            this.newCommandButton.Click += new System.EventHandler(this.NewCommandButton_Click);
            // 
            // saveCommandButton
            // 
            this.saveCommandButton.BackColor = System.Drawing.Color.Bisque;
            this.saveCommandButton.Location = new System.Drawing.Point(194, 15);
            this.saveCommandButton.Name = "saveCommandButton";
            this.saveCommandButton.Size = new System.Drawing.Size(75, 23);
            this.saveCommandButton.TabIndex = 2;
            this.saveCommandButton.Text = "SAVE";
            this.saveCommandButton.UseVisualStyleBackColor = false;
            this.saveCommandButton.Click += new System.EventHandler(this.SaveCommandButton_Click);
            // 
            // commandName
            // 
            this.commandName.Location = new System.Drawing.Point(193, 77);
            this.commandName.Name = "commandName";
            this.commandName.Size = new System.Drawing.Size(377, 20);
            this.commandName.TabIndex = 3;
            this.commandName.TextChanged += new System.EventHandler(this.CommandName_TextChanged);
            // 
            // commandCodeLines
            // 
            this.commandCodeLines.Location = new System.Drawing.Point(194, 172);
            this.commandCodeLines.Multiline = true;
            this.commandCodeLines.Name = "commandCodeLines";
            this.commandCodeLines.Size = new System.Drawing.Size(377, 290);
            this.commandCodeLines.TabIndex = 4;
            // 
            // commandDescription
            // 
            this.commandDescription.Location = new System.Drawing.Point(194, 116);
            this.commandDescription.Multiline = true;
            this.commandDescription.Name = "commandDescription";
            this.commandDescription.Size = new System.Drawing.Size(336, 37);
            this.commandDescription.TabIndex = 5;
            // 
            // commandDescriptionLabel
            // 
            this.commandDescriptionLabel.AutoSize = true;
            this.commandDescriptionLabel.Location = new System.Drawing.Point(193, 100);
            this.commandDescriptionLabel.Name = "commandDescriptionLabel";
            this.commandDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.commandDescriptionLabel.TabIndex = 6;
            this.commandDescriptionLabel.Text = "Description";
            // 
            // commandCodeLabel
            // 
            this.commandCodeLabel.AutoSize = true;
            this.commandCodeLabel.Location = new System.Drawing.Point(193, 156);
            this.commandCodeLabel.Name = "commandCodeLabel";
            this.commandCodeLabel.Size = new System.Drawing.Size(56, 13);
            this.commandCodeLabel.TabIndex = 7;
            this.commandCodeLabel.Text = "Code lines";
            // 
            // commandNameLabel
            // 
            this.commandNameLabel.AutoSize = true;
            this.commandNameLabel.Location = new System.Drawing.Point(193, 61);
            this.commandNameLabel.Name = "commandNameLabel";
            this.commandNameLabel.Size = new System.Drawing.Size(35, 13);
            this.commandNameLabel.TabIndex = 8;
            this.commandNameLabel.Text = "Name";
            // 
            // insertBox
            // 
            this.insertBox.Controls.Add(this.insertWaitButton);
            this.insertBox.Controls.Add(this.insertDialogueButton);
            this.insertBox.Controls.Add(this.insertPathButton);
            this.insertBox.Controls.Add(this.insertLinkButton);
            this.insertBox.Location = new System.Drawing.Point(355, 15);
            this.insertBox.Name = "insertBox";
            this.insertBox.Size = new System.Drawing.Size(215, 50);
            this.insertBox.TabIndex = 9;
            this.insertBox.TabStop = false;
            this.insertBox.Text = "INSERT";
            // 
            // insertWaitButton
            // 
            this.insertWaitButton.Location = new System.Drawing.Point(166, 20);
            this.insertWaitButton.Name = "insertWaitButton";
            this.insertWaitButton.Size = new System.Drawing.Size(43, 24);
            this.insertWaitButton.TabIndex = 3;
            this.insertWaitButton.Text = "WAIT";
            this.insertWaitButton.UseVisualStyleBackColor = true;
            this.insertWaitButton.Click += new System.EventHandler(this.InsertWaitButton_Click);
            // 
            // insertDialogueButton
            // 
            this.insertDialogueButton.Location = new System.Drawing.Point(123, 20);
            this.insertDialogueButton.Name = "insertDialogueButton";
            this.insertDialogueButton.Size = new System.Drawing.Size(37, 24);
            this.insertDialogueButton.TabIndex = 2;
            this.insertDialogueButton.Text = "SAY";
            this.insertDialogueButton.UseVisualStyleBackColor = true;
            this.insertDialogueButton.Click += new System.EventHandler(this.InsertDialogueButton_Click);
            // 
            // insertPathButton
            // 
            this.insertPathButton.Location = new System.Drawing.Point(65, 20);
            this.insertPathButton.Name = "insertPathButton";
            this.insertPathButton.Size = new System.Drawing.Size(52, 24);
            this.insertPathButton.TabIndex = 1;
            this.insertPathButton.Text = "PATH";
            this.insertPathButton.UseVisualStyleBackColor = true;
            this.insertPathButton.Click += new System.EventHandler(this.InsertPathButton_Click);
            // 
            // insertLinkButton
            // 
            this.insertLinkButton.Location = new System.Drawing.Point(7, 19);
            this.insertLinkButton.Name = "insertLinkButton";
            this.insertLinkButton.Size = new System.Drawing.Size(52, 24);
            this.insertLinkButton.TabIndex = 0;
            this.insertLinkButton.Text = "LINK";
            this.insertLinkButton.UseVisualStyleBackColor = true;
            this.insertLinkButton.Click += new System.EventHandler(this.InsertLinkButton_Click);
            // 
            // deleteCommandButton
            // 
            this.deleteCommandButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteCommandButton.Location = new System.Drawing.Point(274, 44);
            this.deleteCommandButton.Name = "deleteCommandButton";
            this.deleteCommandButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCommandButton.TabIndex = 10;
            this.deleteCommandButton.Text = "DELETE";
            this.deleteCommandButton.UseVisualStyleBackColor = false;
            this.deleteCommandButton.Click += new System.EventHandler(this.DeleteCommandButton_Click);
            // 
            // CustomCommandPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(584, 491);
            this.Controls.Add(this.deleteCommandButton);
            this.Controls.Add(this.insertBox);
            this.Controls.Add(this.commandNameLabel);
            this.Controls.Add(this.commandCodeLabel);
            this.Controls.Add(this.commandDescriptionLabel);
            this.Controls.Add(this.commandDescription);
            this.Controls.Add(this.commandCodeLines);
            this.Controls.Add(this.commandName);
            this.Controls.Add(this.saveCommandButton);
            this.Controls.Add(this.newCommandButton);
            this.Controls.Add(this.commandsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomCommandPanel";
            this.Text = "CustomCommandPanel";
            this.Load += new System.EventHandler(this.CustomCommandPanel_Load);
            this.insertBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel commandsPanel;
        private System.Windows.Forms.Button newCommandButton;
        private System.Windows.Forms.Button saveCommandButton;
        private System.Windows.Forms.TextBox commandName;
        private System.Windows.Forms.TextBox commandCodeLines;
        private System.Windows.Forms.TextBox commandDescription;
        private System.Windows.Forms.Label commandDescriptionLabel;
        private System.Windows.Forms.Label commandCodeLabel;
        private System.Windows.Forms.Label commandNameLabel;
        private System.Windows.Forms.GroupBox insertBox;
        private System.Windows.Forms.Button insertDialogueButton;
        private System.Windows.Forms.Button insertPathButton;
        private System.Windows.Forms.Button insertLinkButton;
        private System.Windows.Forms.Button deleteCommandButton;
        private System.Windows.Forms.Button insertWaitButton;
    }
}