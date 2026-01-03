using System.Drawing;

namespace WhatsItWorth
{
    partial class ViewItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewItem));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.photoButton = new System.Windows.Forms.Button();
            this.viewList = new System.Windows.Forms.DataGridView();
            this.diamondCutDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondClarityDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondColorDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondCaratDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diamondPriceDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.purityTextBox = new System.Windows.Forms.TextBox();
            this.metalTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.valuePanel = new System.Windows.Forms.Panel();
            this.changeTextBox = new System.Windows.Forms.Label();
            this.currentTextBox = new System.Windows.Forms.Label();
            this.originalTextBox = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.Label();
            this.currentPriceLabel = new System.Windows.Forms.Label();
            this.originalPriceLabel = new System.Windows.Forms.Label();
            this.changeLabel = new System.Windows.Forms.Label();
            this.dateAddedLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.itemImageBox = new System.Windows.Forms.PictureBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.purityLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.subHeadingLabel = new System.Windows.Forms.Label();
            this.headingLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            this.valuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemImageBox)).BeginInit();
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
            this.mainPanel.Controls.Add(this.saveButton);
            this.mainPanel.Controls.Add(this.editButton);
            this.mainPanel.Controls.Add(this.goBackButton);
            this.mainPanel.Controls.Add(this.photoButton);
            this.mainPanel.Controls.Add(this.viewList);
            this.mainPanel.Controls.Add(this.descriptionTextBox);
            this.mainPanel.Controls.Add(this.totalTextBox);
            this.mainPanel.Controls.Add(this.purityTextBox);
            this.mainPanel.Controls.Add(this.metalTextBox);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.valuePanel);
            this.mainPanel.Controls.Add(this.button2);
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.itemImageBox);
            this.mainPanel.Controls.Add(this.weightLabel);
            this.mainPanel.Controls.Add(this.purityLabel);
            this.mainPanel.Controls.Add(this.typeLabel);
            this.mainPanel.Controls.Add(this.subHeadingLabel);
            this.mainPanel.Controls.Add(this.headingLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(984, 743);
            this.mainPanel.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(71)))), ((int)(((byte)(20)))));
            this.saveButton.Location = new System.Drawing.Point(429, 283);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 32);
            this.saveButton.TabIndex = 35;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.White;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(71)))), ((int)(((byte)(20)))));
            this.editButton.Location = new System.Drawing.Point(429, 245);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(61, 32);
            this.editButton.TabIndex = 34;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.goBackButton.Location = new System.Drawing.Point(176, 655);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(606, 60);
            this.goBackButton.TabIndex = 24;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // photoButton
            // 
            this.photoButton.BackColor = System.Drawing.Color.White;
            this.photoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.photoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(71)))), ((int)(((byte)(20)))));
            this.photoButton.Location = new System.Drawing.Point(762, 420);
            this.photoButton.Name = "photoButton";
            this.photoButton.Size = new System.Drawing.Size(147, 32);
            this.photoButton.TabIndex = 33;
            this.photoButton.Text = "Change Photo";
            this.photoButton.UseVisualStyleBackColor = false;
            this.photoButton.Click += new System.EventHandler(this.photoButton_Click);
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
            this.diamondClarityDataGridColumn,
            this.diamondColorDataGridColumn,
            this.diamondCaratDataGridColumn,
            this.diamondPriceDataGridColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.viewList.DefaultCellStyle = dataGridViewCellStyle7;
            this.viewList.Enabled = false;
            this.viewList.GridColor = System.Drawing.Color.Black;
            this.viewList.Location = new System.Drawing.Point(12, 364);
            this.viewList.MultiSelect = false;
            this.viewList.Name = "viewList";
            this.viewList.ReadOnly = true;
            this.viewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.viewList.ShowEditingIcon = false;
            this.viewList.Size = new System.Drawing.Size(662, 197);
            this.viewList.TabIndex = 32;
            this.viewList.Visible = false;
            // 
            // diamondCutDataGridColumn
            // 
            this.diamondCutDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.diamondCutDataGridColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.diamondCutDataGridColumn.HeaderText = "Cut";
            this.diamondCutDataGridColumn.Name = "diamondCutDataGridColumn";
            this.diamondCutDataGridColumn.ReadOnly = true;
            this.diamondCutDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondClarityDataGridColumn
            // 
            this.diamondClarityDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.diamondClarityDataGridColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.diamondClarityDataGridColumn.HeaderText = "Clarity";
            this.diamondClarityDataGridColumn.Name = "diamondClarityDataGridColumn";
            this.diamondClarityDataGridColumn.ReadOnly = true;
            this.diamondClarityDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondColorDataGridColumn
            // 
            this.diamondColorDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.diamondColorDataGridColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.diamondColorDataGridColumn.HeaderText = "Color";
            this.diamondColorDataGridColumn.Name = "diamondColorDataGridColumn";
            this.diamondColorDataGridColumn.ReadOnly = true;
            this.diamondColorDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondCaratDataGridColumn
            // 
            this.diamondCaratDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.diamondCaratDataGridColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.diamondCaratDataGridColumn.HeaderText = "Carat Weight";
            this.diamondCaratDataGridColumn.Name = "diamondCaratDataGridColumn";
            this.diamondCaratDataGridColumn.ReadOnly = true;
            this.diamondCaratDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diamondPriceDataGridColumn
            // 
            this.diamondPriceDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.diamondPriceDataGridColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.diamondPriceDataGridColumn.HeaderText = "Price";
            this.diamondPriceDataGridColumn.Name = "diamondPriceDataGridColumn";
            this.diamondPriceDataGridColumn.ReadOnly = true;
            this.diamondPriceDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Enabled = false;
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(176, 235);
            this.descriptionTextBox.MaximumSize = new System.Drawing.Size(247, 4);
            this.descriptionTextBox.MaxLength = 1000;
            this.descriptionTextBox.MinimumSize = new System.Drawing.Size(4, 100);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(247, 100);
            this.descriptionTextBox.TabIndex = 31;
            // 
            // totalTextBox
            // 
            this.totalTextBox.Enabled = false;
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextBox.Location = new System.Drawing.Point(279, 200);
            this.totalTextBox.MaximumSize = new System.Drawing.Size(4, 29);
            this.totalTextBox.MinimumSize = new System.Drawing.Size(144, 4);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(144, 29);
            this.totalTextBox.TabIndex = 30;
            // 
            // purityTextBox
            // 
            this.purityTextBox.Enabled = false;
            this.purityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purityTextBox.Location = new System.Drawing.Point(176, 165);
            this.purityTextBox.MaximumSize = new System.Drawing.Size(4, 29);
            this.purityTextBox.MinimumSize = new System.Drawing.Size(144, 4);
            this.purityTextBox.Name = "purityTextBox";
            this.purityTextBox.ReadOnly = true;
            this.purityTextBox.Size = new System.Drawing.Size(144, 29);
            this.purityTextBox.TabIndex = 29;
            this.purityTextBox.Visible = false;
            // 
            // metalTextBox
            // 
            this.metalTextBox.Enabled = false;
            this.metalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metalTextBox.Location = new System.Drawing.Point(176, 130);
            this.metalTextBox.MaximumSize = new System.Drawing.Size(4, 29);
            this.metalTextBox.MinimumSize = new System.Drawing.Size(144, 4);
            this.metalTextBox.Name = "metalTextBox";
            this.metalTextBox.ReadOnly = true;
            this.metalTextBox.Size = new System.Drawing.Size(144, 29);
            this.metalTextBox.TabIndex = 28;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(732, 18);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(217, 60);
            this.deleteButton.TabIndex = 27;
            this.deleteButton.Text = "Delete Item";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // valuePanel
            // 
            this.valuePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.valuePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.valuePanel.Controls.Add(this.changeTextBox);
            this.valuePanel.Controls.Add(this.currentTextBox);
            this.valuePanel.Controls.Add(this.originalTextBox);
            this.valuePanel.Controls.Add(this.dateTextBox);
            this.valuePanel.Controls.Add(this.currentPriceLabel);
            this.valuePanel.Controls.Add(this.originalPriceLabel);
            this.valuePanel.Controls.Add(this.changeLabel);
            this.valuePanel.Controls.Add(this.dateAddedLabel);
            this.valuePanel.Controls.Add(this.valueLabel);
            this.valuePanel.Location = new System.Drawing.Point(702, 458);
            this.valuePanel.Name = "valuePanel";
            this.valuePanel.Size = new System.Drawing.Size(270, 191);
            this.valuePanel.TabIndex = 26;
            this.valuePanel.Tag = "";
            // 
            // changeTextBox
            // 
            this.changeTextBox.AutoSize = true;
            this.changeTextBox.BackColor = System.Drawing.Color.Transparent;
            this.changeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeTextBox.ForeColor = System.Drawing.Color.White;
            this.changeTextBox.Location = new System.Drawing.Point(135, 145);
            this.changeTextBox.MinimumSize = new System.Drawing.Size(110, 0);
            this.changeTextBox.Name = "changeTextBox";
            this.changeTextBox.Size = new System.Drawing.Size(110, 24);
            this.changeTextBox.TabIndex = 8;
            // 
            // currentTextBox
            // 
            this.currentTextBox.AutoSize = true;
            this.currentTextBox.BackColor = System.Drawing.Color.Transparent;
            this.currentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTextBox.ForeColor = System.Drawing.Color.White;
            this.currentTextBox.Location = new System.Drawing.Point(135, 110);
            this.currentTextBox.MinimumSize = new System.Drawing.Size(110, 0);
            this.currentTextBox.Name = "currentTextBox";
            this.currentTextBox.Size = new System.Drawing.Size(110, 24);
            this.currentTextBox.TabIndex = 7;
            // 
            // originalTextBox
            // 
            this.originalTextBox.AutoSize = true;
            this.originalTextBox.BackColor = System.Drawing.Color.Transparent;
            this.originalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalTextBox.ForeColor = System.Drawing.Color.White;
            this.originalTextBox.Location = new System.Drawing.Point(135, 75);
            this.originalTextBox.MinimumSize = new System.Drawing.Size(110, 0);
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.Size = new System.Drawing.Size(110, 24);
            this.originalTextBox.TabIndex = 6;
            // 
            // dateTextBox
            // 
            this.dateTextBox.AutoSize = true;
            this.dateTextBox.BackColor = System.Drawing.Color.Transparent;
            this.dateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTextBox.ForeColor = System.Drawing.Color.White;
            this.dateTextBox.Location = new System.Drawing.Point(135, 40);
            this.dateTextBox.MinimumSize = new System.Drawing.Size(110, 0);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(110, 24);
            this.dateTextBox.TabIndex = 5;
            // 
            // currentPriceLabel
            // 
            this.currentPriceLabel.AutoSize = true;
            this.currentPriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPriceLabel.ForeColor = System.Drawing.Color.White;
            this.currentPriceLabel.Location = new System.Drawing.Point(5, 110);
            this.currentPriceLabel.Name = "currentPriceLabel";
            this.currentPriceLabel.Size = new System.Drawing.Size(130, 24);
            this.currentPriceLabel.TabIndex = 4;
            this.currentPriceLabel.Text = "Current Price: ";
            // 
            // originalPriceLabel
            // 
            this.originalPriceLabel.AutoSize = true;
            this.originalPriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.originalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalPriceLabel.ForeColor = System.Drawing.Color.White;
            this.originalPriceLabel.Location = new System.Drawing.Point(5, 75);
            this.originalPriceLabel.Name = "originalPriceLabel";
            this.originalPriceLabel.Size = new System.Drawing.Size(133, 24);
            this.originalPriceLabel.TabIndex = 3;
            this.originalPriceLabel.Text = "Original Price: ";
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.BackColor = System.Drawing.Color.Transparent;
            this.changeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLabel.ForeColor = System.Drawing.Color.White;
            this.changeLabel.Location = new System.Drawing.Point(5, 145);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(107, 24);
            this.changeLabel.TabIndex = 2;
            this.changeLabel.Text = "% Change: ";
            // 
            // dateAddedLabel
            // 
            this.dateAddedLabel.AutoSize = true;
            this.dateAddedLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateAddedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateAddedLabel.ForeColor = System.Drawing.Color.White;
            this.dateAddedLabel.Location = new System.Drawing.Point(5, 40);
            this.dateAddedLabel.Name = "dateAddedLabel";
            this.dateAddedLabel.Size = new System.Drawing.Size(120, 24);
            this.dateAddedLabel.TabIndex = 1;
            this.dateAddedLabel.Text = "Date Added: ";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.BackColor = System.Drawing.Color.Transparent;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueLabel.ForeColor = System.Drawing.Color.White;
            this.valueLabel.Location = new System.Drawing.Point(3, -2);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(72, 25);
            this.valueLabel.TabIndex = 0;
            this.valueLabel.Text = "Value";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(482, 655);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 60);
            this.button2.TabIndex = 25;
            this.button2.Text = "Generate Item Report";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.descriptionLabel.Location = new System.Drawing.Point(25, 235);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(141, 29);
            this.descriptionLabel.TabIndex = 21;
            this.descriptionLabel.Text = "Description:";
            // 
            // itemImageBox
            // 
            this.itemImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemImageBox.Location = new System.Drawing.Point(713, 110);
            this.itemImageBox.Name = "itemImageBox";
            this.itemImageBox.Size = new System.Drawing.Size(238, 303);
            this.itemImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.itemImageBox.TabIndex = 16;
            this.itemImageBox.TabStop = false;
            this.itemImageBox.Visible = false;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.weightLabel.Location = new System.Drawing.Point(25, 200);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(254, 29);
            this.weightLabel.TabIndex = 14;
            this.weightLabel.Text = "Total Weight (Grams): ";
            // 
            // purityLabel
            // 
            this.purityLabel.AutoSize = true;
            this.purityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.purityLabel.Location = new System.Drawing.Point(25, 165);
            this.purityLabel.Name = "purityLabel";
            this.purityLabel.Size = new System.Drawing.Size(150, 29);
            this.purityLabel.TabIndex = 12;
            this.purityLabel.Text = "Metal Purity: ";
            this.purityLabel.Visible = false;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.typeLabel.Location = new System.Drawing.Point(25, 130);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(145, 29);
            this.typeLabel.TabIndex = 9;
            this.typeLabel.Text = "Metal Type: ";
            // 
            // subHeadingLabel
            // 
            this.subHeadingLabel.AutoSize = true;
            this.subHeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subHeadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(143)))), ((int)(((byte)(135)))));
            this.subHeadingLabel.Location = new System.Drawing.Point(409, 67);
            this.subHeadingLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.subHeadingLabel.Name = "subHeadingLabel";
            this.subHeadingLabel.Size = new System.Drawing.Size(208, 48);
            this.subHeadingLabel.TabIndex = 8;
            this.subHeadingLabel.Text = "View or Edit information about your item!";
            this.subHeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.headingLabel.Location = new System.Drawing.Point(435, 30);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(165, 37);
            this.headingLabel.TabIndex = 7;
            this.headingLabel.Text = "View Item";
            // 
            // ViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 743);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What\'s It Worth - View Item";
            this.Load += new System.EventHandler(this.ViewItemPage_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            this.valuePanel.ResumeLayout(false);
            this.valuePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label subHeadingLabel;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label purityLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.PictureBox itemImageBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Panel valuePanel;
        private System.Windows.Forms.Label originalTextBox;
        private System.Windows.Forms.Label dateTextBox;
        private System.Windows.Forms.Label currentPriceLabel;
        private System.Windows.Forms.Label originalPriceLabel;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Label dateAddedLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label changeTextBox;
        private System.Windows.Forms.Label currentTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox metalTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox purityTextBox;
        private System.Windows.Forms.DataGridView viewList;
        private System.Windows.Forms.Button photoButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondCutDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondClarityDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondColorDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondCaratDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diamondPriceDataGridColumn;
    }
}

