using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailAblage
{
    public class DropUserControl : UserControl
    {
        DropTarget dropTarget = null;

        public delegate void FileSavedHandler(object sender, FileSavedEventArgs e);
        public event FileSavedHandler OnFileSaved;

        public DropUserControl()
        {
            dropTarget = new DropTarget(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (dropTarget != null)
            {
                dropTarget.Dispose();
                dropTarget = null;
            }
            base.Dispose(disposing);
        }

        protected void DragOverHandler(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        protected void FileSaved(LogEntry entry)
        {
            // Make sure someone is listening to event
            if (OnFileSaved == null) return;

            var args = new FileSavedEventArgs(entry);
            OnFileSaved(this, args);
        }

        public class FileSavedEventArgs : EventArgs
        {
            public LogEntry Entry { get; private set; }

            public FileSavedEventArgs(LogEntry entry)
            {
                Entry = entry;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DropUserControl
            // 
            this.Name = "DropUserControl";
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.DragOverHandler);
            this.ResumeLayout(false);

        }
    }
}
