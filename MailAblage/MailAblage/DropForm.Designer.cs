namespace MailAblage
{
    partial class DropForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

 
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.selectedFolder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedFileName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.logoutputGridView = new System.Windows.Forms.DataGridView();
            this.MailDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveAsDropArea = new MailAblage.SaveAsDropArea();
            this.fileDropArea = new MailAblage.DropArea();
            ((System.ComponentModel.ISupportInitialize)(this.logoutputGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Verzeichnis";
            // 
            // selectedFolder
            // 
            this.selectedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedFolder.FormattingEnabled = true;
            this.selectedFolder.Location = new System.Drawing.Point(3, 41);
            this.selectedFolder.Name = "selectedFolder";
            this.selectedFolder.Size = new System.Drawing.Size(400, 21);
            this.selectedFolder.TabIndex = 3;
            this.selectedFolder.SelectedIndexChanged += new System.EventHandler(this.selectedFolder_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Namensformat";
            // 
            // selectedFileName
            // 
            this.selectedFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedFileName.FormattingEnabled = true;
            this.selectedFileName.Location = new System.Drawing.Point(6, 81);
            this.selectedFileName.Name = "selectedFileName";
            this.selectedFileName.Size = new System.Drawing.Size(397, 21);
            this.selectedFileName.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Durchsuchen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectDirectory_ButtonClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // logoutputGridView
            // 
            this.logoutputGridView.AllowUserToAddRows = false;
            this.logoutputGridView.AllowUserToDeleteRows = false;
            this.logoutputGridView.AllowUserToOrderColumns = true;
            this.logoutputGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutputGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.logoutputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logoutputGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MailDateTime,
            this.MailSubject,
            this.Folder,
            this.Filename,
            this.Deleted,
            this.Message});
            this.logoutputGridView.Location = new System.Drawing.Point(3, 264);
            this.logoutputGridView.Name = "logoutputGridView";
            this.logoutputGridView.Size = new System.Drawing.Size(400, 416);
            this.logoutputGridView.TabIndex = 8;
            // 
            // MailDateTime
            // 
            this.MailDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MailDateTime.DataPropertyName = "MailDateTime";
            this.MailDateTime.HeaderText = "Erhalten";
            this.MailDateTime.Name = "MailDateTime";
            this.MailDateTime.Width = 71;
            // 
            // MailSubject
            // 
            this.MailSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MailSubject.DataPropertyName = "MailSubject";
            this.MailSubject.HeaderText = "Mail";
            this.MailSubject.Name = "MailSubject";
            this.MailSubject.Width = 51;
            // 
            // Folder
            // 
            this.Folder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Folder.DataPropertyName = "Folder";
            this.Folder.HeaderText = "Ordner";
            this.Folder.Name = "Folder";
            this.Folder.Width = 64;
            // 
            // Filename
            // 
            this.Filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Filename.DataPropertyName = "Filename";
            this.Filename.HeaderText = "Dateiname";
            this.Filename.Name = "Filename";
            this.Filename.Width = 83;
            // 
            // Deleted
            // 
            this.Deleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Deleted.DataPropertyName = "Deleted";
            this.Deleted.HeaderText = "Gelöscht";
            this.Deleted.Name = "Deleted";
            this.Deleted.Width = 55;
            // 
            // Message
            // 
            this.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "Nachricht";
            this.Message.Name = "Message";
            this.Message.Width = 78;
            // 
            // saveAsDropArea
            // 
            this.saveAsDropArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.saveAsDropArea.Location = new System.Drawing.Point(6, 108);
            this.saveAsDropArea.Name = "saveAsDropArea";
            this.saveAsDropArea.Size = new System.Drawing.Size(132, 134);
            this.saveAsDropArea.TabIndex = 9;
            // 
            // fileDropArea
            // 
            this.fileDropArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDropArea.Location = new System.Drawing.Point(176, 108);
            this.fileDropArea.Name = "fileDropArea";
            this.fileDropArea.Size = new System.Drawing.Size(127, 134);
            this.fileDropArea.TabIndex = 7;
            // 
            // DropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.saveAsDropArea);
            this.Controls.Add(this.logoutputGridView);
            this.Controls.Add(this.fileDropArea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedFolder);
            this.Controls.Add(this.label1);
            this.Name = "DropForm";
            this.Size = new System.Drawing.Size(406, 683);
            ((System.ComponentModel.ISupportInitialize)(this.logoutputGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectedFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectedFileName;
        private System.Windows.Forms.Button button1;
        public DropArea fileDropArea;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView logoutputGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        public SaveAsDropArea saveAsDropArea;
    }
}
