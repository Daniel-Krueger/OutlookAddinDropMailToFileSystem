namespace MailAblage
{
    partial class DropArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropArea));
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.InitialImage = ((System.Drawing.Image)(resources.GetObject("image.InitialImage")));
            this.image.Location = new System.Drawing.Point(3, 3);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(128, 128);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            this.image.DragDrop += new System.Windows.Forms.DragEventHandler(this.itemDropped);
            this.image.DragOver += new System.Windows.Forms.DragEventHandler(this.DropArea_DragOver);
            // 
            // DropArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.image);
            this.Name = "DropArea";
            this.Size = new System.Drawing.Size(132, 134);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.itemDropped);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.DropArea_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
    }
}
