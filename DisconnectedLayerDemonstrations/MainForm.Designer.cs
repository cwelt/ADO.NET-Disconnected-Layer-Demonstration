namespace DisconnectedLayerDemonstration
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
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.connectionStatePanel = new System.Windows.Forms.Panel();
            this.btnOpenCloseConnection = new System.Windows.Forms.Button();
            this.lblConnectionStateTitle = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.deleteTextBox = new System.Windows.Forms.TextBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.updateTextBox = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.insertTextBox = new System.Windows.Forms.TextBox();
            this.lblInsert = new System.Windows.Forms.Label();
            this.selectTextBox = new System.Windows.Forms.TextBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.unitOfWorkCheckBox = new System.Windows.Forms.CheckBox();
            this.dataAdapterListBox = new System.Windows.Forms.ListBox();
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.btnWriteXmlSchema = new System.Windows.Forms.Button();
            this.btnReadXml = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.connectionStatePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(731, 229);
            this.mainDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowHeadersWidth = 51;
            this.mainDataGridView.RowTemplate.Height = 24;
            this.mainDataGridView.Size = new System.Drawing.Size(994, 526);
            this.mainDataGridView.TabIndex = 0;
            this.mainDataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_RowValidated);
            this.mainDataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.mainDataGridView_Paint);
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoadData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLoadData.Location = new System.Drawing.Point(245, 478);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(156, 41);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Fill";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRemove.Location = new System.Drawing.Point(952, 186);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(133, 39);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // connectionStatePanel
            // 
            this.connectionStatePanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.connectionStatePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionStatePanel.Controls.Add(this.btnOpenCloseConnection);
            this.connectionStatePanel.Controls.Add(this.lblConnectionStateTitle);
            this.connectionStatePanel.Controls.Add(this.lblConnection);
            this.connectionStatePanel.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatePanel.Location = new System.Drawing.Point(1235, 12);
            this.connectionStatePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionStatePanel.Name = "connectionStatePanel";
            this.connectionStatePanel.Size = new System.Drawing.Size(282, 148);
            this.connectionStatePanel.TabIndex = 7;
            // 
            // btnOpenCloseConnection
            // 
            this.btnOpenCloseConnection.BackColor = System.Drawing.Color.LightCyan;
            this.btnOpenCloseConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenCloseConnection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenCloseConnection.Font = new System.Drawing.Font("Aharoni", 12F);
            this.btnOpenCloseConnection.Location = new System.Drawing.Point(8, 110);
            this.btnOpenCloseConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenCloseConnection.Name = "btnOpenCloseConnection";
            this.btnOpenCloseConnection.Size = new System.Drawing.Size(257, 34);
            this.btnOpenCloseConnection.TabIndex = 6;
            this.btnOpenCloseConnection.Text = "Open\\Close Connection";
            this.btnOpenCloseConnection.UseVisualStyleBackColor = false;
            this.btnOpenCloseConnection.Click += new System.EventHandler(this.btnOpenCloseConnection_Click);
            // 
            // lblConnectionStateTitle
            // 
            this.lblConnectionStateTitle.AutoSize = true;
            this.lblConnectionStateTitle.Location = new System.Drawing.Point(3, 16);
            this.lblConnectionStateTitle.Name = "lblConnectionStateTitle";
            this.lblConnectionStateTitle.Size = new System.Drawing.Size(262, 20);
            this.lblConnectionStateTitle.TabIndex = 5;
            this.lblConnectionStateTitle.Text = "Database Connection State";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.BackColor = System.Drawing.Color.Transparent;
            this.lblConnection.Font = new System.Drawing.Font("Aharoni", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(53, 49);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(176, 43);
            this.lblConnection.TabIndex = 4;
            this.lblConnection.Text = "<State>";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MintCream;
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.deleteTextBox);
            this.groupBox1.Controls.Add(this.lblDelete);
            this.groupBox1.Controls.Add(this.updateTextBox);
            this.groupBox1.Controls.Add(this.btnLoadData);
            this.groupBox1.Controls.Add(this.lblUpdate);
            this.groupBox1.Controls.Add(this.insertTextBox);
            this.groupBox1.Controls.Add(this.lblInsert);
            this.groupBox1.Controls.Add(this.selectTextBox);
            this.groupBox1.Controls.Add(this.lblSelect);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 229);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(708, 526);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Adapter";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnUpdate.Location = new System.Drawing.Point(442, 478);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 41);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // deleteTextBox
            // 
            this.deleteTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.deleteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deleteTextBox.Location = new System.Drawing.Point(213, 286);
            this.deleteTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteTextBox.Multiline = true;
            this.deleteTextBox.Name = "deleteTextBox";
            this.deleteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.deleteTextBox.Size = new System.Drawing.Size(485, 84);
            this.deleteTextBox.TabIndex = 7;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDelete.Location = new System.Drawing.Point(5, 286);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(182, 29);
            this.lblDelete.TabIndex = 6;
            this.lblDelete.Text = "Delete Command";
            // 
            // updateTextBox
            // 
            this.updateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.updateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.updateTextBox.Location = new System.Drawing.Point(213, 199);
            this.updateTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateTextBox.Multiline = true;
            this.updateTextBox.Name = "updateTextBox";
            this.updateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.updateTextBox.Size = new System.Drawing.Size(485, 80);
            this.updateTextBox.TabIndex = 5;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUpdate.Location = new System.Drawing.Point(5, 199);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(188, 29);
            this.lblUpdate.TabIndex = 4;
            this.lblUpdate.Text = "Update Command";
            // 
            // insertTextBox
            // 
            this.insertTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.insertTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.insertTextBox.Location = new System.Drawing.Point(213, 111);
            this.insertTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertTextBox.Multiline = true;
            this.insertTextBox.Name = "insertTextBox";
            this.insertTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.insertTextBox.Size = new System.Drawing.Size(485, 83);
            this.insertTextBox.TabIndex = 3;
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInsert.Location = new System.Drawing.Point(5, 111);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(174, 29);
            this.lblInsert.TabIndex = 2;
            this.lblInsert.Text = "Insert Command";
            // 
            // selectTextBox
            // 
            this.selectTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.selectTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectTextBox.Location = new System.Drawing.Point(213, 26);
            this.selectTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectTextBox.Multiline = true;
            this.selectTextBox.Name = "selectTextBox";
            this.selectTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.selectTextBox.Size = new System.Drawing.Size(485, 80);
            this.selectTextBox.TabIndex = 1;
            this.selectTextBox.Text = "Select * From students;";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelect.Location = new System.Drawing.Point(5, 26);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(177, 29);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select Command";
            // 
            // unitOfWorkCheckBox
            // 
            this.unitOfWorkCheckBox.AutoSize = true;
            this.unitOfWorkCheckBox.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitOfWorkCheckBox.Location = new System.Drawing.Point(731, 199);
            this.unitOfWorkCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.unitOfWorkCheckBox.Name = "unitOfWorkCheckBox";
            this.unitOfWorkCheckBox.Size = new System.Drawing.Size(203, 24);
            this.unitOfWorkCheckBox.TabIndex = 9;
            this.unitOfWorkCheckBox.Text = "Display Row State";
            this.unitOfWorkCheckBox.UseVisualStyleBackColor = true;
            this.unitOfWorkCheckBox.CheckedChanged += new System.EventHandler(this.unitOfWorkCheckBox_CheckedChanged);
            // 
            // listBox1
            // 
            this.dataAdapterListBox.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataAdapterListBox.FormattingEnabled = true;
            this.dataAdapterListBox.ItemHeight = 23;
            this.dataAdapterListBox.Location = new System.Drawing.Point(3, 29);
            this.dataAdapterListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataAdapterListBox.Name = "listBox1";
            this.dataAdapterListBox.Size = new System.Drawing.Size(379, 188);
            this.dataAdapterListBox.TabIndex = 10;
            this.dataAdapterListBox.SelectedIndexChanged += new System.EventHandler(this.dataAdapterListBox_SelectedIndexChanged);
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.BackColor = System.Drawing.Color.LightGreen;
            this.btnWriteXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWriteXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnWriteXml.Location = new System.Drawing.Point(813, 78);
            this.btnWriteXml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(133, 39);
            this.btnWriteXml.TabIndex = 11;
            this.btnWriteXml.Text = "WriteXml";
            this.btnWriteXml.UseVisualStyleBackColor = false;
            this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
            // 
            // btnWriteXmlSchema
            // 
            this.btnWriteXmlSchema.BackColor = System.Drawing.Color.LightGreen;
            this.btnWriteXmlSchema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWriteXmlSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnWriteXmlSchema.Location = new System.Drawing.Point(952, 78);
            this.btnWriteXmlSchema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWriteXmlSchema.Name = "btnWriteXmlSchema";
            this.btnWriteXmlSchema.Size = new System.Drawing.Size(163, 39);
            this.btnWriteXmlSchema.TabIndex = 12;
            this.btnWriteXmlSchema.Text = "WriteXmlSchema";
            this.btnWriteXmlSchema.UseVisualStyleBackColor = false;
            this.btnWriteXmlSchema.Click += new System.EventHandler(this.btnWriteXmlSchema_Click);
            // 
            // btnReadXml
            // 
            this.btnReadXml.BackColor = System.Drawing.Color.LightGreen;
            this.btnReadXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnReadXml.Location = new System.Drawing.Point(867, 29);
            this.btnReadXml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.Size = new System.Drawing.Size(179, 42);
            this.btnReadXml.TabIndex = 13;
            this.btnReadXml.Text = "ReadXml";
            this.btnReadXml.UseVisualStyleBackColor = false;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClear.Location = new System.Drawing.Point(1230, 184);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 41);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDelete.Location = new System.Drawing.Point(1091, 186);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 39);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Data Adapters";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1729, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReadXml);
            this.Controls.Add(this.btnWriteXmlSchema);
            this.Controls.Add(this.btnWriteXml);
            this.Controls.Add(this.dataAdapterListBox);
            this.Controls.Add(this.unitOfWorkCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.connectionStatePanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Disconnected Layer Demonstration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.connectionStatePanel.ResumeLayout(false);
            this.connectionStatePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel connectionStatePanel;
        private System.Windows.Forms.Label lblConnectionStateTitle;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnOpenCloseConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox selectTextBox;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.TextBox deleteTextBox;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.TextBox updateTextBox;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox insertTextBox;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.CheckBox unitOfWorkCheckBox;
        private System.Windows.Forms.ListBox dataAdapterListBox;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnWriteXml;
        private System.Windows.Forms.Button btnWriteXmlSchema;
        private System.Windows.Forms.Button btnReadXml;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
    }
}

