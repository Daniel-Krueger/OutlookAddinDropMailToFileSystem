using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace MailAblage
{
    [ComVisible(true), Guid("8B56AE5D-104D-4c0c-BEAA-3E44C5A7E1DF"), ProgId("MailAblage.DropArea")]

    public partial class DropArea : UserControl
    {
        DropTarget dropTarget = null;

        public DropArea()
        {
            InitializeComponent();
            dropTarget = new DropTarget(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (dropTarget != null)
                {
                    dropTarget.Dispose();
                    dropTarget = null;
                }
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DropArea_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            System.Console.WriteLine("test");

            //wrap standard IDataObject in OutlookDataObject
            OutlookDataObject dataObject = new OutlookDataObject(e.Data);

            //get the names and data streams of the files dropped
            string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");
            MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");
            this.droppedFiles.Text = null;
            for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
            {
                //use the fileindex to get the name and data stream
                string filename = filenames[fileIndex];
                 MemoryStream filestream = filestreams[fileIndex];

                OutlookStorage.Message outlookMsg = new OutlookStorage.Message(filestream);
                DisplayMessage(outlookMsg);
            //save the file stream using its name to the application path
            //FileStream outputStream = File.Create(filename);
            //filestream.WriteTo(outputStream);
            //outputStream.Close();
        }
    }

        private void DisplayMessage(OutlookStorage.Message outlookMsg)
        {
            this.droppedFiles.Text += $"Subject {outlookMsg.Subject} Date {outlookMsg.ReceivedDate}\r\n";

            Console.WriteLine("Subject: {0}", outlookMsg.Subject);
            Console.WriteLine("Body: {0}", outlookMsg.BodyText);

            Console.WriteLine("{0} Recipients", outlookMsg.Recipients.Count);
            foreach (OutlookStorage.Recipient recip in outlookMsg.Recipients)
            {
                Console.WriteLine(" {0}:{1}", recip.Type, recip.Email);
            }

            Console.WriteLine("{0} Attachments", outlookMsg.Attachments.Count);
            foreach (OutlookStorage.Attachment attach in outlookMsg.Attachments)
            {
                Console.WriteLine(" {0}, {1}b", attach.Filename, attach.Data.Length);
            }

            Console.WriteLine("{0} Messages", outlookMsg.Messages.Count);
            foreach (OutlookStorage.Message subMessage in outlookMsg.Messages)
            {
                DisplayMessage(subMessage);
            }
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var index = this.selectedFolder.Items.Add(this.folderBrowserDialog.SelectedPath);
                this.selectedFolder.SelectedItem = index;
            }
        }
    }
}
