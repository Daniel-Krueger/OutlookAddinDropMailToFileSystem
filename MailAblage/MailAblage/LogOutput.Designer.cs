namespace MailAblage
{
    partial class LogOutput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logoutputGridView = new System.Windows.Forms.DataGridView();
            this.MailDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.logoutputGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutputGridView
            // 
            this.logoutputGridView.AllowUserToAddRows = false;
            this.logoutputGridView.AllowUserToDeleteRows = false;
            this.logoutputGridView.AllowUserToOrderColumns = true;
            this.logoutputGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.logoutputGridView.Location = new System.Drawing.Point(0, 0);
            this.logoutputGridView.Name = "logoutputGridView";
            this.logoutputGridView.Size = new System.Drawing.Size(818, 337);
            this.logoutputGridView.TabIndex = 0;
            // 
            // MailDateTime
            // 
            this.MailDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MailDateTime.DataPropertyName = "MailDateTime";
            this.MailDateTime.HeaderText = "Zeitpunkt";
            this.MailDateTime.Name = "MailDateTime";
            this.MailDateTime.Width = 77;
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
            // LogOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logoutputGridView);
            this.Name = "LogOutput";
            this.Size = new System.Drawing.Size(818, 337);
            ((System.ComponentModel.ISupportInitialize)(this.logoutputGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logoutputGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}
