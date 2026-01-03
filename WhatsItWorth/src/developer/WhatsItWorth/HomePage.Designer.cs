using System.Drawing;

namespace WhatsItWorth
{
    partial class HomePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.incorrectLabel = new System.Windows.Forms.Label();
            this.numItemsTextBox = new System.Windows.Forms.TextBox();
            this.totalValueTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.tableList = new System.Windows.Forms.DataGridView();
            this.selectionDataGridColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPriceDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.compareItemsButton = new System.Windows.Forms.Button();
            this.resourcesButton = new System.Windows.Forms.Button();
            this.yourProfileButton = new System.Windows.Forms.Button();
            this.selectItemButton = new System.Windows.Forms.Button();
            this.numItemsLabel = new System.Windows.Forms.Label();
            this.totalValueLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.signOutButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.addItemButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableList)).BeginInit();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
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
            this.mainPanel.Controls.Add(this.incorrectLabel);
            this.mainPanel.Controls.Add(this.numItemsTextBox);
            this.mainPanel.Controls.Add(this.totalValueTextBox);
            this.mainPanel.Controls.Add(this.nameTextBox);
            this.mainPanel.Controls.Add(this.tableList);
            this.mainPanel.Controls.Add(this.generateReportButton);
            this.mainPanel.Controls.Add(this.compareItemsButton);
            this.mainPanel.Controls.Add(this.resourcesButton);
            this.mainPanel.Controls.Add(this.yourProfileButton);
            this.mainPanel.Controls.Add(this.selectItemButton);
            this.mainPanel.Controls.Add(this.numItemsLabel);
            this.mainPanel.Controls.Add(this.totalValueLabel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Controls.Add(this.addItemButton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(993, 757);
            this.mainPanel.TabIndex = 1;
            // 
            // incorrectLabel
            // 
            this.incorrectLabel.AutoSize = true;
            this.incorrectLabel.BackColor = System.Drawing.Color.Transparent;
            this.incorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.incorrectLabel.Location = new System.Drawing.Point(265, 136);
            this.incorrectLabel.MaximumSize = new System.Drawing.Size(450, 0);
            this.incorrectLabel.MinimumSize = new System.Drawing.Size(400, 0);
            this.incorrectLabel.Name = "incorrectLabel";
            this.incorrectLabel.Size = new System.Drawing.Size(435, 25);
            this.incorrectLabel.TabIndex = 25;
            this.incorrectLabel.Text = "Please select an item from list and try again!";
            this.incorrectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.incorrectLabel.Visible = false;
            // 
            // numItemsTextBox
            // 
            this.numItemsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.numItemsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numItemsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numItemsTextBox.ForeColor = System.Drawing.Color.Black;
            this.numItemsTextBox.Location = new System.Drawing.Point(852, 136);
            this.numItemsTextBox.MinimumSize = new System.Drawing.Size(120, 27);
            this.numItemsTextBox.Name = "numItemsTextBox";
            this.numItemsTextBox.ReadOnly = true;
            this.numItemsTextBox.Size = new System.Drawing.Size(120, 31);
            this.numItemsTextBox.TabIndex = 24;
            this.numItemsTextBox.Text = "0";
            this.numItemsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalValueTextBox
            // 
            this.totalValueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.totalValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueTextBox.ForeColor = System.Drawing.Color.ForestGreen;
            this.totalValueTextBox.Location = new System.Drawing.Point(12, 136);
            this.totalValueTextBox.MinimumSize = new System.Drawing.Size(120, 27);
            this.totalValueTextBox.Name = "totalValueTextBox";
            this.totalValueTextBox.ReadOnly = true;
            this.totalValueTextBox.Size = new System.Drawing.Size(120, 29);
            this.totalValueTextBox.TabIndex = 23;
            this.totalValueTextBox.Text = "$0.00";
            this.totalValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.nameTextBox.Location = new System.Drawing.Point(173, 84);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(656, 55);
            this.nameTextBox.TabIndex = 22;
            this.nameTextBox.Text = "Name";
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableList
            // 
            this.tableList.AllowUserToAddRows = false;
            this.tableList.AllowUserToDeleteRows = false;
            this.tableList.AllowUserToResizeColumns = false;
            this.tableList.AllowUserToResizeRows = false;
            this.tableList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectionDataGridColumn,
            this.descriptionDataGridColumn,
            this.currentPriceDataGridColumn,
            this.changeDataGridColumn,
            this.itemIDDataGridColumn});
            this.tableList.GridColor = System.Drawing.Color.Black;
            this.tableList.Location = new System.Drawing.Point(25, 181);
            this.tableList.MultiSelect = false;
            this.tableList.Name = "tableList";
            this.tableList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.tableList.RowHeadersWidth = 62;
            this.tableList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableList.ShowEditingIcon = false;
            this.tableList.Size = new System.Drawing.Size(930, 362);
            this.tableList.TabIndex = 21;
            this.tableList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableList_ValueChanged);
            this.tableList.Sorted += new System.EventHandler(this.tableList_Sorted);
            // 
            // selectionDataGridColumn
            // 
            this.selectionDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.NullValue = false;
            this.selectionDataGridColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.selectionDataGridColumn.FalseValue = "false";
            this.selectionDataGridColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectionDataGridColumn.HeaderText = "Select";
            this.selectionDataGridColumn.IndeterminateValue = "false";
            this.selectionDataGridColumn.MinimumWidth = 8;
            this.selectionDataGridColumn.Name = "selectionDataGridColumn";
            this.selectionDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selectionDataGridColumn.TrueValue = "true";
            this.selectionDataGridColumn.Width = 75;
            // 
            // descriptionDataGridColumn
            // 
            this.descriptionDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.descriptionDataGridColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.descriptionDataGridColumn.FillWeight = 35.7868F;
            this.descriptionDataGridColumn.HeaderText = "Description";
            this.descriptionDataGridColumn.MinimumWidth = 8;
            this.descriptionDataGridColumn.Name = "descriptionDataGridColumn";
            this.descriptionDataGridColumn.ReadOnly = true;
            this.descriptionDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // currentPriceDataGridColumn
            // 
            this.currentPriceDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.currentPriceDataGridColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.currentPriceDataGridColumn.FillWeight = 35.7868F;
            this.currentPriceDataGridColumn.HeaderText = "Current Price";
            this.currentPriceDataGridColumn.MinimumWidth = 8;
            this.currentPriceDataGridColumn.Name = "currentPriceDataGridColumn";
            this.currentPriceDataGridColumn.ReadOnly = true;
            this.currentPriceDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.currentPriceDataGridColumn.Width = 175;
            // 
            // changeDataGridColumn
            // 
            this.changeDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Format = "$0.00;-$#.##";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.changeDataGridColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.changeDataGridColumn.FillWeight = 35.7868F;
            this.changeDataGridColumn.HeaderText = "Change";
            this.changeDataGridColumn.MinimumWidth = 8;
            this.changeDataGridColumn.Name = "changeDataGridColumn";
            this.changeDataGridColumn.ReadOnly = true;
            this.changeDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.changeDataGridColumn.Width = 150;
            // 
            // itemIDDataGridColumn
            // 
            this.itemIDDataGridColumn.HeaderText = "ItemID";
            this.itemIDDataGridColumn.MinimumWidth = 8;
            this.itemIDDataGridColumn.Name = "itemIDDataGridColumn";
            this.itemIDDataGridColumn.ReadOnly = true;
            this.itemIDDataGridColumn.Visible = false;
            this.itemIDDataGridColumn.Width = 150;
            // 
            // generateReportButton
            // 
            this.generateReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.generateReportButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.generateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generateReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateReportButton.ForeColor = System.Drawing.Color.White;
            this.generateReportButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.generateReportButton.Location = new System.Drawing.Point(805, 549);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(151, 150);
            this.generateReportButton.TabIndex = 20;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.generateReportButton.UseVisualStyleBackColor = false;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // compareItemsButton
            // 
            this.compareItemsButton.BackColor = System.Drawing.Color.White;
            this.compareItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.compareItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareItemsButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.compareItemsButton.Image = global::WhatsItWorth.Properties.Resources.CompareIcon;
            this.compareItemsButton.Location = new System.Drawing.Point(649, 549);
            this.compareItemsButton.Name = "compareItemsButton";
            this.compareItemsButton.Size = new System.Drawing.Size(150, 150);
            this.compareItemsButton.TabIndex = 18;
            this.compareItemsButton.Text = "Compare two items and view an investment comparison.";
            this.compareItemsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.compareItemsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.compareItemsButton.UseVisualStyleBackColor = false;
            this.compareItemsButton.Click += new System.EventHandler(this.compareItemsButton_Click);
            // 
            // resourcesButton
            // 
            this.resourcesButton.BackColor = System.Drawing.Color.White;
            this.resourcesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resourcesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resourcesButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.resourcesButton.Image = global::WhatsItWorth.Properties.Resources.ResourcesIcon;
            this.resourcesButton.Location = new System.Drawing.Point(493, 549);
            this.resourcesButton.Name = "resourcesButton";
            this.resourcesButton.Size = new System.Drawing.Size(150, 150);
            this.resourcesButton.TabIndex = 17;
            this.resourcesButton.Text = "View useful resources and documentation";
            this.resourcesButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.resourcesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.resourcesButton.UseVisualStyleBackColor = false;
            this.resourcesButton.Click += new System.EventHandler(this.resourcesButton_Click);
            // 
            // yourProfileButton
            // 
            this.yourProfileButton.BackColor = System.Drawing.Color.White;
            this.yourProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yourProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourProfileButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.yourProfileButton.Image = global::WhatsItWorth.Properties.Resources.ProfileIcon;
            this.yourProfileButton.Location = new System.Drawing.Point(337, 549);
            this.yourProfileButton.Name = "yourProfileButton";
            this.yourProfileButton.Size = new System.Drawing.Size(150, 150);
            this.yourProfileButton.TabIndex = 16;
            this.yourProfileButton.Text = "View or Edit your account information";
            this.yourProfileButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.yourProfileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.yourProfileButton.UseVisualStyleBackColor = false;
            this.yourProfileButton.Click += new System.EventHandler(this.yourProfileButton_Click);
            // 
            // selectItemButton
            // 
            this.selectItemButton.BackColor = System.Drawing.Color.White;
            this.selectItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectItemButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.selectItemButton.Image = global::WhatsItWorth.Properties.Resources.SelectIcon;
            this.selectItemButton.Location = new System.Drawing.Point(181, 549);
            this.selectItemButton.Name = "selectItemButton";
            this.selectItemButton.Size = new System.Drawing.Size(150, 150);
            this.selectItemButton.TabIndex = 15;
            this.selectItemButton.Text = "Select an item from list and press this button to View or Edit item information";
            this.selectItemButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.selectItemButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.selectItemButton.UseVisualStyleBackColor = false;
            this.selectItemButton.Click += new System.EventHandler(this.selectItemButton_Click);
            // 
            // numItemsLabel
            // 
            this.numItemsLabel.AutoSize = true;
            this.numItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numItemsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.numItemsLabel.Location = new System.Drawing.Point(867, 108);
            this.numItemsLabel.Name = "numItemsLabel";
            this.numItemsLabel.Size = new System.Drawing.Size(105, 25);
            this.numItemsLabel.TabIndex = 11;
            this.numItemsLabel.Text = "# of Items";
            // 
            // totalValueLabel
            // 
            this.totalValueLabel.AutoSize = true;
            this.totalValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.totalValueLabel.Location = new System.Drawing.Point(12, 108);
            this.totalValueLabel.Name = "totalValueLabel";
            this.totalValueLabel.Size = new System.Drawing.Size(121, 25);
            this.totalValueLabel.TabIndex = 9;
            this.totalValueLabel.Text = "Total Value";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.topPanel.Controls.Add(this.signOutButton);
            this.topPanel.Controls.Add(this.logoPictureBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(993, 81);
            this.topPanel.TabIndex = 8;
            // 
            // signOutButton
            // 
            this.signOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.signOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(174)))));
            this.signOutButton.Location = new System.Drawing.Point(864, 12);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(108, 50);
            this.signOutButton.TabIndex = 11;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.Image = global::WhatsItWorth.Properties.Resources.WIWLogo;
            this.logoPictureBox.Location = new System.Drawing.Point(12, -22);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(195, 120);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 10;
            this.logoPictureBox.TabStop = false;
            // 
            // addItemButton
            // 
            this.addItemButton.BackColor = System.Drawing.Color.White;
            this.addItemButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addItemButton.Image = global::WhatsItWorth.Properties.Resources.ItemIcon;
            this.addItemButton.Location = new System.Drawing.Point(25, 549);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(150, 150);
            this.addItemButton.TabIndex = 14;
            this.addItemButton.Text = "Create and Add item to your account";
            this.addItemButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addItemButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(993, 757);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What\'s It Worth - Home Page";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableList)).EndInit();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label totalValueLabel;
        private System.Windows.Forms.Label numItemsLabel;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button compareItemsButton;
        private System.Windows.Forms.Button resourcesButton;
        private System.Windows.Forms.Button yourProfileButton;
        private System.Windows.Forms.Button selectItemButton;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Button signOutButton;
        private System.Windows.Forms.DataGridView tableList;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox totalValueTextBox;
        private System.Windows.Forms.TextBox numItemsTextBox;
        private System.Windows.Forms.Label incorrectLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectionDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridColumn;
    }
}

