using System.Drawing;

namespace WhatsItWorth
{
    partial class AddDiamond
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDiamond));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.goBackButton = new System.Windows.Forms.Button();
            this.headingLabel = new System.Windows.Forms.Label();
            this.addDiamondButton = new System.Windows.Forms.Button();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.incorrectLabel = new System.Windows.Forms.Label();
            this.weightSpinner = new System.Windows.Forms.NumericUpDown();
            this.cutComboBox = new System.Windows.Forms.ComboBox();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.clarityComboBox = new System.Windows.Forms.ComboBox();
            this.cutLabel = new System.Windows.Forms.Label();
            this.clarityLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.subHeadingLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            this.inputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightSpinner)).BeginInit();
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
            this.mainPanel.Controls.Add(this.goBackButton);
            this.mainPanel.Controls.Add(this.headingLabel);
            this.mainPanel.Controls.Add(this.addDiamondButton);
            this.mainPanel.Controls.Add(this.inputPanel);
            this.mainPanel.Controls.Add(this.subHeadingLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(484, 461);
            this.mainPanel.TabIndex = 1;
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.goBackButton.Location = new System.Drawing.Point(35, 390);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(200, 50);
            this.goBackButton.TabIndex = 38;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // headingLabel
            // 
            this.headingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.headingLabel.Location = new System.Drawing.Point(114, 9);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(224, 37);
            this.headingLabel.TabIndex = 37;
            this.headingLabel.Text = "Add Diamond";
            this.headingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addDiamondButton
            // 
            this.addDiamondButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addDiamondButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.addDiamondButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addDiamondButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDiamondButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.addDiamondButton.Location = new System.Drawing.Point(250, 390);
            this.addDiamondButton.Name = "addDiamondButton";
            this.addDiamondButton.Size = new System.Drawing.Size(200, 50);
            this.addDiamondButton.TabIndex = 36;
            this.addDiamondButton.Text = "Add Diamond";
            this.addDiamondButton.UseVisualStyleBackColor = false;
            this.addDiamondButton.Click += new System.EventHandler(this.addDiamondButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputPanel.Controls.Add(this.incorrectLabel);
            this.inputPanel.Controls.Add(this.weightSpinner);
            this.inputPanel.Controls.Add(this.cutComboBox);
            this.inputPanel.Controls.Add(this.colorComboBox);
            this.inputPanel.Controls.Add(this.clarityComboBox);
            this.inputPanel.Controls.Add(this.cutLabel);
            this.inputPanel.Controls.Add(this.clarityLabel);
            this.inputPanel.Controls.Add(this.colorLabel);
            this.inputPanel.Controls.Add(this.weightLabel);
            this.inputPanel.Location = new System.Drawing.Point(77, 141);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(300, 226);
            this.inputPanel.TabIndex = 34;
            this.inputPanel.Tag = "";
            // 
            // incorrectLabel
            // 
            this.incorrectLabel.AutoSize = true;
            this.incorrectLabel.BackColor = System.Drawing.Color.Transparent;
            this.incorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectLabel.Location = new System.Drawing.Point(46, 184);
            this.incorrectLabel.Name = "incorrectLabel";
            this.incorrectLabel.Size = new System.Drawing.Size(203, 25);
            this.incorrectLabel.TabIndex = 43;
            this.incorrectLabel.Text = "Diamond Not Found";
            this.incorrectLabel.Visible = false;
            // 
            // weightSpinner
            // 
            this.weightSpinner.DecimalPlaces = 2;
            this.weightSpinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightSpinner.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.weightSpinner.Location = new System.Drawing.Point(170, 140);
            this.weightSpinner.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.weightSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.weightSpinner.Name = "weightSpinner";
            this.weightSpinner.Size = new System.Drawing.Size(100, 29);
            this.weightSpinner.TabIndex = 42;
            this.weightSpinner.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // cutComboBox
            // 
            this.cutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cutComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutComboBox.FormattingEnabled = true;
            this.cutComboBox.Items.AddRange(new object[] {
            "Round",
            "Princess",
            "Marquise",
            "Pear",
            "Oval"});
            this.cutComboBox.Location = new System.Drawing.Point(91, 8);
            this.cutComboBox.MaximumSize = new System.Drawing.Size(100, 0);
            this.cutComboBox.MaxLength = 1;
            this.cutComboBox.Name = "cutComboBox";
            this.cutComboBox.Size = new System.Drawing.Size(100, 32);
            this.cutComboBox.TabIndex = 38;
            this.cutComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.cutComboBox_Validating);
            // 
            // colorComboBox
            // 
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N"});
            this.colorComboBox.Location = new System.Drawing.Point(91, 53);
            this.colorComboBox.MaximumSize = new System.Drawing.Size(100, 0);
            this.colorComboBox.MaxLength = 1;
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(100, 32);
            this.colorComboBox.TabIndex = 39;
            this.colorComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.colorComboBox_Validating);
            // 
            // clarityComboBox
            // 
            this.clarityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clarityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clarityComboBox.FormattingEnabled = true;
            this.clarityComboBox.Items.AddRange(new object[] {
            "VVS1",
            "VVS2",
            "VS1",
            "VS2",
            "SI1",
            "SI2",
            "I1",
            "I2"});
            this.clarityComboBox.Location = new System.Drawing.Point(91, 98);
            this.clarityComboBox.MaximumSize = new System.Drawing.Size(100, 0);
            this.clarityComboBox.MaxLength = 4;
            this.clarityComboBox.Name = "clarityComboBox";
            this.clarityComboBox.Size = new System.Drawing.Size(100, 32);
            this.clarityComboBox.TabIndex = 40;
            this.clarityComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.clarityComboBox_Validating);
            // 
            // cutLabel
            // 
            this.cutLabel.AutoSize = true;
            this.cutLabel.BackColor = System.Drawing.Color.Transparent;
            this.cutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutLabel.ForeColor = System.Drawing.Color.White;
            this.cutLabel.Location = new System.Drawing.Point(10, 10);
            this.cutLabel.Name = "cutLabel";
            this.cutLabel.Size = new System.Drawing.Size(57, 25);
            this.cutLabel.TabIndex = 1;
            this.cutLabel.Text = "Cut: ";
            // 
            // clarityLabel
            // 
            this.clarityLabel.AutoSize = true;
            this.clarityLabel.BackColor = System.Drawing.Color.Transparent;
            this.clarityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clarityLabel.ForeColor = System.Drawing.Color.White;
            this.clarityLabel.Location = new System.Drawing.Point(10, 100);
            this.clarityLabel.Name = "clarityLabel";
            this.clarityLabel.Size = new System.Drawing.Size(85, 25);
            this.clarityLabel.TabIndex = 4;
            this.clarityLabel.Text = "Clarity: ";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.BackColor = System.Drawing.Color.Transparent;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorLabel.ForeColor = System.Drawing.Color.White;
            this.colorLabel.Location = new System.Drawing.Point(10, 55);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(75, 25);
            this.colorLabel.TabIndex = 3;
            this.colorLabel.Text = "Color: ";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.BackColor = System.Drawing.Color.Transparent;
            this.weightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLabel.ForeColor = System.Drawing.Color.White;
            this.weightLabel.Location = new System.Drawing.Point(10, 140);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(169, 25);
            this.weightLabel.TabIndex = 2;
            this.weightLabel.Text = "Weight (Carat):  ";
            // 
            // subHeadingLabel
            // 
            this.subHeadingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.subHeadingLabel.AutoSize = true;
            this.subHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subHeadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(143)))), ((int)(((byte)(135)))));
            this.subHeadingLabel.Location = new System.Drawing.Point(108, 46);
            this.subHeadingLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.subHeadingLabel.Name = "subHeadingLabel";
            this.subHeadingLabel.Size = new System.Drawing.Size(230, 75);
            this.subHeadingLabel.TabIndex = 8;
            this.subHeadingLabel.Text = "Please input your diamond information to add it to your item.";
            this.subHeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddDiamond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDiamond";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What\'s It Worth - Add Diamond";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label clarityLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label cutLabel;
        private System.Windows.Forms.Label subHeadingLabel;
        private System.Windows.Forms.Button addDiamondButton;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.ComboBox clarityComboBox;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.ComboBox cutComboBox;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown weightSpinner;
        private System.Windows.Forms.Label incorrectLabel;
    }
}

