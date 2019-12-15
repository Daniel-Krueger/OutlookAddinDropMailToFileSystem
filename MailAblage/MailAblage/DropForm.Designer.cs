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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.fileDropArea = new MailAblage.DropArea();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
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
            this.selectedFolder.Location = new System.Drawing.Point(98, 28);
            this.selectedFolder.Name = "selectedFolder";
            this.selectedFolder.Size = new System.Drawing.Size(348, 21);
            this.selectedFolder.TabIndex = 3;
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
            this.selectedFileName.Size = new System.Drawing.Size(440, 21);
            this.selectedFileName.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Durchsuchen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectDirectory_ButtonClick);
            // 
            // fileDropArea
            // 
            this.fileDropArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDropArea.Location = new System.Drawing.Point(6, 108);
            this.fileDropArea.Name = "fileDropArea";
            this.fileDropArea.Size = new System.Drawing.Size(150, 150);
            this.fileDropArea.TabIndex = 7;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // DropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.fileDropArea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedFolder);
            this.Controls.Add(this.label1);
            this.Name = "DropForm";
            this.Size = new System.Drawing.Size(449, 261);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectedFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectedFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button1;
        public DropArea fileDropArea;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
