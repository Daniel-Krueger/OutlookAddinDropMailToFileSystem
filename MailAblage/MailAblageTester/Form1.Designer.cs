namespace MailAblageTester
{
    partial class Form1
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
            this.dropArea.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dropArea = new MailAblage.DropArea();
            this.SuspendLayout();
            // 
            // dropArea
            // 
            this.dropArea.AutoSize = true;
            this.dropArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dropArea.Location = new System.Drawing.Point(12, 12);
            this.dropArea.Name = "dropArea";
            this.dropArea.Size = new System.Drawing.Size(800, 500);
            this.dropArea.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 517);
            this.Controls.Add(this.dropArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MailAblage.DropArea dropArea;
    }
}

