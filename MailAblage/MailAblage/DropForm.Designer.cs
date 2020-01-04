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
            this.selectedFolder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedFileName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveAsDropArea = new MailAblage.SaveAsDropArea();
            this.fileDropArea = new MailAblage.DropArea();
            this.SuspendLayout();
            // 
            // selectedFolder
            // 
            this.selectedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedFolder.FormattingEnabled = true;
            this.selectedFolder.Location = new System.Drawing.Point(210, 3);
            this.selectedFolder.Name = "selectedFolder";
            this.selectedFolder.Size = new System.Drawing.Size(480, 21);
            this.selectedFolder.TabIndex = 3;
            this.selectedFolder.SelectedIndexChanged += new System.EventHandler(this.selectedFolder_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 30);
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
            this.selectedFileName.Location = new System.Drawing.Point(210, 30);
            this.selectedFileName.Name = "selectedFileName";
            this.selectedFileName.Size = new System.Drawing.Size(480, 21);
            this.selectedFileName.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Verzeichnis";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectDirectory_ButtonClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveAsDropArea
            // 
            this.saveAsDropArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.saveAsDropArea.Location = new System.Drawing.Point(0, 0);
            this.saveAsDropArea.Name = "saveAsDropArea";
            this.saveAsDropArea.Size = new System.Drawing.Size(55, 55);
            this.saveAsDropArea.TabIndex = 9;
            // 
            // fileDropArea
            // 
            this.fileDropArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileDropArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDropArea.Location = new System.Drawing.Point(61, 0);
            this.fileDropArea.Name = "fileDropArea";
            this.fileDropArea.Size = new System.Drawing.Size(55, 55);
            this.fileDropArea.TabIndex = 7;
            // 
            // DropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.saveAsDropArea);
            this.Controls.Add(this.fileDropArea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedFolder);
            this.Name = "DropForm";
            this.Size = new System.Drawing.Size(700, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox selectedFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectedFileName;
        private System.Windows.Forms.Button button1;
        public DropArea fileDropArea;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public SaveAsDropArea saveAsDropArea;
    }
}
