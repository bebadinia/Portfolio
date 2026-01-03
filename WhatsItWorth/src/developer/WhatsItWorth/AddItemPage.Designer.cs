using System.Drawing;

namespace WhatsItWorth
{
    partial class AddItemPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemPage));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.weightSpinner = new System.Windows.Forms.NumericUpDown();
            this.viewList = new System.Windows.Forms.DataGridView();
            this.diamondCutDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondColorDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondClarityDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondCaratWeightDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondDeleteDataGridColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.diamondLabel = new System.Windows.Forms.Label();
            this.goBackButton = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.photoButton = new System.Windows.Forms.Button();
            this.addDiamondButton = new System.Windows.Forms.Button();
            this.weightLabel = new System.Windows.Forms.Label();
            this.purityComboBox = new System.Windows.Forms.ComboBox();
            this.purityLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.subHeadingLabel = new System.Windows.Forms.Label();
            this.headingLabel = new System.Windows.Forms.Label();
            this.addItemButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            this.mainPanel.Controls.Add(this.weightSpinner);
            this.mainPanel.Controls.Add(this.viewList);
            this.mainPanel.Controls.Add(this.diamondLabel);
            this.mainPanel.Controls.Add(this.goBackButton);
            this.mainPanel.Controls.Add(this.descriptionTextBox);
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.pictureBox);
            this.mainPanel.Controls.Add(this.photoButton);
            this.mainPanel.Controls.Add(this.addDiamondButton);
            this.mainPanel.Controls.Add(this.weightLabel);
            this.mainPanel.Controls.Add(this.purityComboBox);
            this.mainPanel.Controls.Add(this.purityLabel);
            this.mainPanel.Controls.Add(this.typeComboBox);
            this.mainPanel.Controls.Add(this.typeLabel);
            this.mainPanel.Controls.Add(this.subHeadingLabel);
            this.mainPanel.Controls.Add(this.headingLabel);
            this.mainPanel.Controls.Add(this.addItemButton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(984, 884);
            this.mainPanel.TabIndex = 1;
            // 
            // weightSpinner
            // 
            this.weightSpinner.DecimalPlaces = 1;
            this.weightSpinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightSpinner.Location = new System.Drawing.Point(30, 352);
            this.weightSpinner.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.weightSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightSpinner.Name = "weightSpinner";
            this.weightSpinner.Size = new System.Drawing.Size(237, 31);
            this.weightSpinner.TabIndex = 38;
            this.weightSpinner.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // viewList
            // 
            this.viewList.AllowUserToAddRows = false;
            this.viewList.AllowUserToDeleteRows = false;
            this.viewList.AllowUserToResizeColumns = false;
            this.viewList.AllowUserToResizeRows = false;
            this.viewList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.viewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diamondCutDataGridColumn,
            this.diamondColorDataGridColumn,
            this.diamondClarityDataGridColumn,
            this.diamondCaratWeightDataGridColumn,
            this.diamondDeleteDataGridColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.viewList.DefaultCellStyle = dataGridViewCellStyle7;
            this.viewList.GridColor = System.Drawing.Color.Black;
            this.viewList.Location = new System.Drawing.Point(30, 505);
            this.viewList.MultiSelect = false;
            this.viewList.Name = "viewList";
            this.viewList.ReadOnly = true;
            this.viewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.viewList.ShowEditingIcon = false;
            this.viewList.Size = new System.Drawing.Size(592, 200);
            this.viewList.TabIndex = 37;
            this.viewList.Visible = false;
            this.viewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewList_CellContentClick);
            // 
            // diamondCutDataGridColumn
            // 
            this.diamondCutDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.diamondCutDataGridColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.diamondCutDataGridColumn.HeaderText = "Cut";
            this.diamondCutDataGridColumn.Name = "diamondCutDataGridColumn";
            this.diamondCutDataGridColumn.ReadOnly = true;
            this.diamondCutDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondColorDataGridColumn
            // 
            this.diamondColorDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.diamondColorDataGridColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.diamondColorDataGridColumn.HeaderText = "Color";
            this.diamondColorDataGridColumn.Name = "diamondColorDataGridColumn";
            this.diamondColorDataGridColumn.ReadOnly = true;
            this.diamondColorDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondClarityDataGridColumn
            // 
            this.diamondClarityDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.diamondClarityDataGridColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.diamondClarityDataGridColumn.HeaderText = "Clarity";
            this.diamondClarityDataGridColumn.Name = "diamondClarityDataGridColumn";
            this.diamondClarityDataGridColumn.ReadOnly = true;
            this.diamondClarityDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondCaratWeightDataGridColumn
            // 
            this.diamondCaratWeightDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.diamondCaratWeightDataGridColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.diamondCaratWeightDataGridColumn.HeaderText = "Carat Weight";
            this.diamondCaratWeightDataGridColumn.Name = "diamondCaratWeightDataGridColumn";
            this.diamondCaratWeightDataGridColumn.ReadOnly = true;
            this.diamondCaratWeightDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondDeleteDataGridColumn
            // 
            this.diamondDeleteDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.NullValue = "\'X\'";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Red;
            this.diamondDeleteDataGridColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.diamondDeleteDataGridColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.diamondDeleteDataGridColumn.HeaderText = "";
            this.diamondDeleteDataGridColumn.Name = "diamondDeleteDataGridColumn";
            this.diamondDeleteDataGridColumn.ReadOnly = true;
            this.diamondDeleteDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.diamondDeleteDataGridColumn.Text = "X";
            this.diamondDeleteDataGridColumn.UseColumnTextForButtonValue = true;
            this.diamondDeleteDataGridColumn.Width = 5;
            // 
            // diamondLabel
            // 
            this.diamondLabel.AutoSize = true;
            this.diamondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diamondLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.diamondLabel.Location = new System.Drawing.Point(25, 459);
            this.diamondLabel.Name = "diamondLabel";
            this.diamondLabel.Size = new System.Drawing.Size(130, 29);
            this.diamondLabel.TabIndex = 36;
            this.diamondLabel.Text = "Diamonds";
            this.diamondLabel.Visible = false;
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.goBackButton.Location = new System.Drawing.Point(177, 798);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(300, 60);
            this.goBackButton.TabIndex = 34;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(672, 505);
            this.descriptionTextBox.MaxLength = 50;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(300, 200);
            this.descriptionTextBox.TabIndex = 32;
            this.descriptionTextBox.Text = "Enter Item Description";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.descriptionLabel.Location = new System.Drawing.Point(667, 473);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(135, 29);
            this.descriptionLabel.TabIndex = 18;
            this.descriptionLabel.Text = "Description";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(683, 130);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(289, 228);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 16;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // photoButton
            // 
            this.photoButton.BackColor = System.Drawing.Color.White;
            this.photoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.photoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(71)))), ((int)(((byte)(20)))));
            this.photoButton.Location = new System.Drawing.Point(716, 379);
            this.photoButton.Name = "photoButton";
            this.photoButton.Size = new System.Drawing.Size(237, 40);
            this.photoButton.TabIndex = 17;
            this.photoButton.Text = "Add Photo";
            this.photoButton.UseVisualStyleBackColor = false;
            this.photoButton.Click += new System.EventHandler(this.photoButton_Click);
            // 
            // addDiamondButton
            // 
            this.addDiamondButton.BackColor = System.Drawing.Color.White;
            this.addDiamondButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addDiamondButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDiamondButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(71)))), ((int)(((byte)(20)))));
            this.addDiamondButton.Location = new System.Drawing.Point(49, 405);
            this.addDiamondButton.Name = "addDiamondButton";
            this.addDiamondButton.Size = new System.Drawing.Size(237, 40);
            this.addDiamondButton.TabIndex = 15;
            this.addDiamondButton.Text = "Add Diamond";
            this.addDiamondButton.UseVisualStyleBackColor = false;
            this.addDiamondButton.Click += new System.EventHandler(this.addDiamondButton_Click);
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.weightLabel.Location = new System.Drawing.Point(25, 320);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(242, 29);
            this.weightLabel.TabIndex = 14;
            this.weightLabel.Text = "Total Weight (Grams)";
            // 
            // purityComboBox
            // 
            this.purityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.purityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purityComboBox.FormattingEnabled = true;
            this.purityComboBox.Items.AddRange(new object[] {
            "9K",
            "10K",
            "14K",
            "18K",
            "21K",
            "22K",
            "24K"});
            this.purityComboBox.Location = new System.Drawing.Point(30, 262);
            this.purityComboBox.Name = "purityComboBox";
            this.purityComboBox.Size = new System.Drawing.Size(299, 33);
            this.purityComboBox.TabIndex = 13;
            this.purityComboBox.Visible = false;
            this.purityComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.purityComboBox_Validating);
            // 
            // purityLabel
            // 
            this.purityLabel.AutoSize = true;
            this.purityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.purityLabel.Location = new System.Drawing.Point(25, 221);
            this.purityLabel.Name = "purityLabel";
            this.purityLabel.Size = new System.Drawing.Size(138, 29);
            this.purityLabel.TabIndex = 12;
            this.purityLabel.Text = "Metal Purity";
            this.purityLabel.Visible = false;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Gold",
            "Silver",
            "Platinum"});
            this.typeComboBox.Location = new System.Drawing.Point(30, 170);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(299, 33);
            this.typeComboBox.TabIndex = 11;
            this.typeComboBox.SelectedValueChanged += new System.EventHandler(this.typeComboBox_SelectedValueChanged);
            this.typeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.typeComboBox_Validating);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.typeLabel.Location = new System.Drawing.Point(25, 130);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(133, 29);
            this.typeLabel.TabIndex = 9;
            this.typeLabel.Text = "Metal Type";
            // 
            // subHeadingLabel
            // 
            this.subHeadingLabel.AutoSize = true;
            this.subHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subHeadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(143)))), ((int)(((byte)(135)))));
            this.subHeadingLabel.Location = new System.Drawing.Point(386, 67);
            this.subHeadingLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.subHeadingLabel.Name = "subHeadingLabel";
            this.subHeadingLabel.Size = new System.Drawing.Size(242, 48);
            this.subHeadingLabel.TabIndex = 8;
            this.subHeadingLabel.Text = "Input information about your item to calculate price!";
            this.subHeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.headingLabel.Location = new System.Drawing.Point(435, 30);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(153, 37);
            this.headingLabel.TabIndex = 7;
            this.headingLabel.Text = "Add Item";
            // 
            // addItemButton
            // 
            this.addItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.addItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.addItemButton.Location = new System.Drawing.Point(502, 798);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(300, 60);
            this.addItemButton.TabIndex = 4;
            this.addItemButton.Text = "Add Item";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddItemPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 884);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddItemPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What\'s It Worth - Add Item";
            this.Load += new System.EventHandler(this.AddItemPage_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Label subHeadingLabel;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox purityComboBox;
        private System.Windows.Forms.Label purityLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Button addDiamondButton;
        private System.Windows.Forms.Button photoButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Label diamondLabel;
        private System.Windows.Forms.DataGridView viewList;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown weightSpinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondCutDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondColorDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondClarityDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondCaratWeightDataGridColumn;
        private System.Windows.Forms.DataGridViewButtonColumn diamondDeleteDataGridColumn;
    }
}

