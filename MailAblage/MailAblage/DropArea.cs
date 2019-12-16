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
    [ComVisible(true), Guid("8B56AE5D-104D-4c0c-BEAA-3E44C5A7E1DC"), ProgId("MailAblage.DropArea")]
    public partial class DropArea : DropUserControl
    {
        internal ComboBox SelectedFolder { get; set; }
        internal ComboBox SelectedFileName { get; set; }


        public DropArea() : base()
        {
            InitializeComponent();
        }

        protected void DropArea_DragOver(object sender, DragEventArgs e)
        {
            this.DragOverHandler(sender, e);
        }

        private void itemDropped(object sender, DragEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.SelectedFolder.Text))
                {
                    throw new ApplicationException("Kein Ordner ausgewählt.");
                }
                if (string.IsNullOrEmpty(this.SelectedFileName.Text))
                {
                    throw new ApplicationException("Kein Namensformat ausgewählt.");
                }

                //wrap standard IDataObject in OutlookDataObject
                OutlookDataObject dataObject = new OutlookDataObject(e.Data);

                //get the names and data streams of the files dropped
                string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");
                MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");
               
                for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                {
                    //use the fileindex to get the name and data stream
                    string filename = filenames[fileIndex];
                    MemoryStream filestream = filestreams[fileIndex];

                    LogEntry newEntry = new LogEntry();
                    newEntry.Folder = this.SelectedFolder.Text;

                    if (filename.EndsWith("msg"))
                    {
                        UpdateEntry(filestream, newEntry);

                    }
                    else
                    {
                        newEntry.Filename = $"{this.SelectedFileName.Text}.{filename.Substring(filename.LastIndexOf("."))}";
                    }
                    //save the file stream using its name to the application path
                    string targetPath = Path.Combine(newEntry.Folder, newEntry.Filename);
                    if (File.Exists(targetPath))
                    {
                        throw new ApplicationException($"Datei mit Namen {targetPath} wurde bereits abgelegt");
                    }
                    FileStream outputStream = File.Create(targetPath);
                    filestream.WriteTo(outputStream);
                    outputStream.Close();
                    FileSaved(newEntry);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateEntry(MemoryStream filestream, LogEntry entry)
        {
            OutlookStorage.Message outlookMsg = new OutlookStorage.Message(filestream);
            entry.MailSubject = outlookMsg.Subject;
            entry.MailDateTime = outlookMsg.ReceivedDate;
            entry.MessageId = outlookMsg.ID;
            int fileCounter = 1;
            entry.Filename = $"{entry.MailDateTime.ToString("yyyy-MM-dd")} ({fileCounter}) {SelectedFileName.Text}.msg";
            while (File.Exists(Path.Combine(entry.Folder, entry.Filename)))
            {
                fileCounter++;
                entry.Filename = $"{entry.MailDateTime.ToString("yyyy-MM-dd")} ({fileCounter}) {SelectedFileName.Text}.msg";
            }
        }


    }
}
