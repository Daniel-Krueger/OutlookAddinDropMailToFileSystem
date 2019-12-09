namespace MailAblage
{
    partial class DropArea
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
            this.droppedFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedFolder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedFileName = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // droppedFiles
            // 
            this.droppedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.droppedFiles.Enabled = false;
            this.droppedFiles.Location = new System.Drawing.Point(6, 108);
            this.droppedFiles.Multiline = true;
            this.droppedFiles.Name = "droppedFiles";
            this.droppedFiles.Size = new System.Drawing.Size(794, 686);
            this.droppedFiles.TabIndex = 1;
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
            this.selectedFolder.FormattingEnabled = true;
            this.selectedFolder.Location = new System.Drawing.Point(98, 28);
            this.selectedFolder.Name = "selectedFolder";
            this.selectedFolder.Size = new System.Drawing.Size(682, 21);
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
            this.selectedFileName.FormattingEnabled = true;
            this.selectedFileName.Location = new System.Drawing.Point(6, 81);
            this.selectedFileName.Name = "selectedFileName";
            this.selectedFileName.Size = new System.Drawing.Size(774, 21);
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
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseDoubleClick);
            // 
            // DropArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.droppedFiles);
            this.Name = "DropArea";
            this.Size = new System.Drawing.Size(800, 800);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.DropArea_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox droppedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectedFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectedFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button1;
    }
}
