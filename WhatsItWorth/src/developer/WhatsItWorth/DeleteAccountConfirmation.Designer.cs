using System.Drawing;

namespace WhatsItWorth
{
    partial class DeleteAccountConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteAccountConfirmation));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.unvisibleButton = new System.Windows.Forms.Button();
            this.visibleButton = new System.Windows.Forms.Button();
            this.incorrectLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.subHeadingLabel = new System.Windows.Forms.Label();
            this.headingLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.mainPanel.Controls.Add(this.unvisibleButton);
            this.mainPanel.Controls.Add(this.visibleButton);
            this.mainPanel.Controls.Add(this.incorrectLabel);
            this.mainPanel.Controls.Add(this.passwordTextBox);
            this.mainPanel.Controls.Add(this.passwordLabel);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.subHeadingLabel);
            this.mainPanel.Controls.Add(this.headingLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(484, 496);
            this.mainPanel.TabIndex = 1;
            // 
            // unvisibleButton
            // 
            this.unvisibleButton.FlatAppearance.BorderSize = 0;
            this.unvisibleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unvisibleButton.Image = global::WhatsItWorth.Properties.Resources.UnVisible;
            this.unvisibleButton.Location = new System.Drawing.Point(409, 358);
            this.unvisibleButton.Name = "unvisibleButton";
            this.unvisibleButton.Size = new System.Drawing.Size(45, 28);
            this.unvisibleButton.TabIndex = 38;
            this.unvisibleButton.UseVisualStyleBackColor = true;
            this.unvisibleButton.Visible = false;
            this.unvisibleButton.Click += new System.EventHandler(this.unvisibleButton_Click);
            // 
            // visibleButton
            // 
            this.visibleButton.FlatAppearance.BorderSize = 0;
            this.visibleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visibleButton.Image = global::WhatsItWorth.Properties.Resources.Visible;
            this.visibleButton.Location = new System.Drawing.Point(409, 355);
            this.visibleButton.Name = "visibleButton";
            this.visibleButton.Size = new System.Drawing.Size(45, 28);
            this.visibleButton.TabIndex = 37;
            this.visibleButton.UseVisualStyleBackColor = true;
            this.visibleButton.Click += new System.EventHandler(this.visibleButton_Click);
            // 
            // incorrectLabel
            // 
            this.incorrectLabel.AutoSize = true;
            this.incorrectLabel.BackColor = System.Drawing.Color.Transparent;
            this.incorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.incorrectLabel.Location = new System.Drawing.Point(80, 397);
            this.incorrectLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.incorrectLabel.MinimumSize = new System.Drawing.Size(250, 0);
            this.incorrectLabel.Name = "incorrectLabel";
            this.incorrectLabel.Size = new System.Drawing.Size(317, 24);
            this.incorrectLabel.TabIndex = 36;
            this.incorrectLabel.Text = "Incorrect Password. Please try again!";
            this.incorrectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.incorrectLabel.Visible = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Black;
            this.passwordTextBox.Location = new System.Drawing.Point(203, 351);
            this.passwordTextBox.MaximumSize = new System.Drawing.Size(250, 29);
            this.passwordTextBox.MinimumSize = new System.Drawing.Size(200, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(200, 35);
            this.passwordTextBox.TabIndex = 35;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.passwordTextBox_Validating);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.passwordLabel.Location = new System.Drawing.Point(65, 351);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(132, 29);
            this.passwordLabel.TabIndex = 34;
            this.passwordLabel.Text = "Password: ";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(29)))), ((int)(((byte)(19)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(87, 424);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(300, 60);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // subHeadingLabel
            // 
            this.subHeadingLabel.AutoSize = true;
            this.subHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subHeadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(143)))), ((int)(((byte)(135)))));
            this.subHeadingLabel.Location = new System.Drawing.Point(106, 80);
            this.subHeadingLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.subHeadingLabel.Name = "subHeadingLabel";
            this.subHeadingLabel.Size = new System.Drawing.Size(246, 216);
            this.subHeadingLabel.TabIndex = 8;
            this.subHeadingLabel.Text = resources.GetString("subHeadingLabel.Text");
            this.subHeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.headingLabel.Location = new System.Drawing.Point(60, 9);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(337, 55);
            this.headingLabel.TabIndex = 7;
            this.headingLabel.Text = "Are you sure?";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DeleteAccountConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 496);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteAccountConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What\'s It Worth - Delete Account";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label subHeadingLabel;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label incorrectLabel;
        private System.Windows.Forms.Button unvisibleButton;
        private System.Windows.Forms.Button visibleButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

