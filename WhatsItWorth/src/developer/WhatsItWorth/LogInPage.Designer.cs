namespace WhatsItWorth
{
    partial class LogInPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInPage));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gradient = new WhatsItWorth.Gradient();
            this.subHeadingLabel = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.unvisibleButton = new System.Windows.Forms.Button();
            this.visibleButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.incorrectLabel = new System.Windows.Forms.Label();
            this.WIWLogo = new System.Windows.Forms.PictureBox();
            this.diamondPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gradient.SuspendLayout();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WIWLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diamondPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // gradient
            // 
            this.gradient.Angle = 0F;
            this.gradient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(186)))));
            this.gradient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gradient.Controls.Add(this.subHeadingLabel);
            this.gradient.Controls.Add(this.loginPanel);
            this.gradient.Controls.Add(this.WIWLogo);
            this.gradient.Controls.Add(this.diamondPictureBox);
            this.gradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradient.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(69)))), ((int)(((byte)(18)))));
            this.gradient.Location = new System.Drawing.Point(0, 0);
            this.gradient.Name = "gradient";
            this.gradient.RightColor = System.Drawing.Color.Transparent;
            this.gradient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gradient.Size = new System.Drawing.Size(984, 687);
            this.gradient.TabIndex = 3;
            // 
            // subHeadingLabel
            // 
            this.subHeadingLabel.AutoSize = true;
            this.subHeadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.subHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subHeadingLabel.ForeColor = System.Drawing.Color.White;
            this.subHeadingLabel.Location = new System.Drawing.Point(167, 224);
            this.subHeadingLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.subHeadingLabel.Name = "subHeadingLabel";
            this.subHeadingLabel.Size = new System.Drawing.Size(244, 120);
            this.subHeadingLabel.TabIndex = 9;
            this.subHeadingLabel.Text = "Instantly calculate and track the market value of your pieces of fine jewelry! Si" +
    "mply login or click \"Create Account\" to get started now.";
            this.subHeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.loginPanel.Controls.Add(this.unvisibleButton);
            this.loginPanel.Controls.Add(this.visibleButton);
            this.loginPanel.Controls.Add(this.passwordTextBox);
            this.loginPanel.Controls.Add(this.instructionLabel);
            this.loginPanel.Controls.Add(this.emailLabel);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.emailTextBox);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.createAccountButton);
            this.loginPanel.Controls.Add(this.incorrectLabel);
            this.loginPanel.Location = new System.Drawing.Point(86, 398);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(464, 275);
            this.loginPanel.TabIndex = 1;
            // 
            // unvisibleButton
            // 
            this.unvisibleButton.FlatAppearance.BorderSize = 0;
            this.unvisibleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unvisibleButton.Image = global::WhatsItWorth.Properties.Resources.UnVisible;
            this.unvisibleButton.Location = new System.Drawing.Point(393, 122);
            this.unvisibleButton.Name = "unvisibleButton";
            this.unvisibleButton.Size = new System.Drawing.Size(45, 28);
            this.unvisibleButton.TabIndex = 14;
            this.unvisibleButton.UseVisualStyleBackColor = true;
            this.unvisibleButton.Visible = false;
            this.unvisibleButton.Click += new System.EventHandler(this.unvisibleButton_Click);
            // 
            // visibleButton
            // 
            this.visibleButton.FlatAppearance.BorderSize = 0;
            this.visibleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visibleButton.Image = global::WhatsItWorth.Properties.Resources.Visible;
            this.visibleButton.Location = new System.Drawing.Point(393, 122);
            this.visibleButton.Name = "visibleButton";
            this.visibleButton.Size = new System.Drawing.Size(45, 28);
            this.visibleButton.TabIndex = 13;
            this.visibleButton.UseVisualStyleBackColor = true;
            this.visibleButton.Click += new System.EventHandler(this.visibleButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Black;
            this.passwordTextBox.Location = new System.Drawing.Point(178, 121);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(200, 26);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.passwordTextBox_Validating);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.instructionLabel.Location = new System.Drawing.Point(102, 18);
            this.instructionLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(246, 48);
            this.instructionLabel.TabIndex = 10;
            this.instructionLabel.Text = "Please enter your Email and password and click \"Log In\".";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(101, 85);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(71, 25);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Email:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(60, 120);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(112, 25);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.ForeColor = System.Drawing.Color.Black;
            this.emailTextBox.Location = new System.Drawing.Point(178, 84);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 26);
            this.emailTextBox.TabIndex = 2;
            this.emailTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.emailTextBox_Validating);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.loginButton.Location = new System.Drawing.Point(85, 170);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(125, 60);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // createAccountButton
            // 
            this.createAccountButton.BackColor = System.Drawing.Color.White;
            this.createAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createAccountButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.createAccountButton.Location = new System.Drawing.Point(239, 170);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(125, 60);
            this.createAccountButton.TabIndex = 5;
            this.createAccountButton.Text = "Create Account";
            this.createAccountButton.UseVisualStyleBackColor = false;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // incorrectLabel
            // 
            this.incorrectLabel.AutoSize = true;
            this.incorrectLabel.BackColor = System.Drawing.Color.Transparent;
            this.incorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.incorrectLabel.Location = new System.Drawing.Point(102, 242);
            this.incorrectLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.incorrectLabel.MinimumSize = new System.Drawing.Size(250, 0);
            this.incorrectLabel.Name = "incorrectLabel";
            this.incorrectLabel.Size = new System.Drawing.Size(282, 24);
            this.incorrectLabel.TabIndex = 11;
            this.incorrectLabel.Text = "Incorrect Email. Please try again!";
            this.incorrectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.incorrectLabel.Visible = false;
            // 
            // WIWLogo
            // 
            this.WIWLogo.BackColor = System.Drawing.Color.Transparent;
            this.WIWLogo.Image = global::WhatsItWorth.Properties.Resources.WIWLogo;
            this.WIWLogo.InitialImage = null;
            this.WIWLogo.Location = new System.Drawing.Point(217, 12);
            this.WIWLogo.Name = "WIWLogo";
            this.WIWLogo.Size = new System.Drawing.Size(534, 173);
            this.WIWLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WIWLogo.TabIndex = 3;
            this.WIWLogo.TabStop = false;
            // 
            // diamondPictureBox
            // 
            this.diamondPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.diamondPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.diamondPictureBox.Image = global::WhatsItWorth.Properties.Resources.LoginPhoto;
            this.diamondPictureBox.Location = new System.Drawing.Point(456, 278);
            this.diamondPictureBox.Name = "diamondPictureBox";
            this.diamondPictureBox.Size = new System.Drawing.Size(500, 350);
            this.diamondPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.diamondPictureBox.TabIndex = 2;
            this.diamondPictureBox.TabStop = false;
            // 
            // LogInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 687);
            this.Controls.Add(this.gradient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What\'s It Worth - Login";
            this.Load += new System.EventHandler(this.LogInPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gradient.ResumeLayout(false);
            this.gradient.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WIWLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diamondPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.PictureBox WIWLogo;
        private Gradient gradient;
        private System.Windows.Forms.PictureBox diamondPictureBox;
        private System.Windows.Forms.Label subHeadingLabel;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Label incorrectLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button visibleButton;
        private System.Windows.Forms.Button unvisibleButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

