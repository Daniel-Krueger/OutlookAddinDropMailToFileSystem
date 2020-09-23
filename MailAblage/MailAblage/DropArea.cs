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
using Microsoft.Office.Core;

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
                try
                {
                    Dictionary<LogEntry, MemoryStream> messageStreamMapping = new Dictionary<LogEntry, MemoryStream>();

                    for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                    {
                        //use the fileindex to get the name and data stream
                        string filename = filenames[fileIndex];
                        MemoryStream filestream = filestreams[fileIndex];

                        LogEntry newEntry = new LogEntry();
                        newEntry.Folder = this.SelectedFolder.Text.Replace(DropForm.favoritePrefix, "");

                        if (filename.EndsWith("msg"))
                        {
                            OutlookStorage.Message outlookMsg = new OutlookStorage.Message(filestream);
                            newEntry.MailSubject = outlookMsg.Subject;
                            newEntry.MailDateTime = outlookMsg.ReceivedDate;
                            newEntry.MessageId = outlookMsg.ID;
                            messageStreamMapping.Add(newEntry, filestream);
                        }
                        else
                        {
                            newEntry.Filename = $"{this.SelectedFileName.Text}.{filename.Substring(filename.LastIndexOf("."))}";
                            SaveFileStreamToFile(filestream, newEntry);
                        }
                    }

                    foreach (var kvp in messageStreamMapping.OrderBy(x => x.Key.MailDateTime))
                    {
                        PrepareFilename(kvp.Value, kvp.Key);
                        SaveFileStreamToFile(kvp.Value, kvp.Key);
                    }
                }
                finally
                {
                    foreach (var fileStream in filestreams)
                    {
                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFileStreamToFile(MemoryStream filestream, LogEntry newEntry)
        {
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

        private void PrepareFilename(MemoryStream filestream, LogEntry entry)
        {
            int fileCounter = 1;
            string mailDate = entry.MailDateTime.ToString("yyyy-MM-dd");
            entry.Filename = $"{mailDate} ({fileCounter}) {SelectedFileName.Text}.msg";
            while (File.Exists(Path.Combine(entry.Folder, entry.Filename)))
            {
                OutlookStorage.Message existingFile = new OutlookStorage.Message(Path.Combine(entry.Folder, entry.Filename));
                bool isExistingFileOlder = existingFile.ReceivedDate < entry.MailDateTime;
                existingFile.Dispose();
                if (isExistingFileOlder)
                {
                    fileCounter++;
                    entry.Filename = $"{mailDate} ({fileCounter}) {SelectedFileName.Text}.msg";
                }
                else
                {
                    RenameExistingFollowingFiles(entry, mailDate, fileCounter, SelectedFileName.Text);
                }
            }
        }


        /// <summary>
        /// Increases the counter of each following file by 1
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="mailDate"></param>
        /// <param name="targetCounterValue"></param>
        /// <param name="filenamePart"></param>
        private void RenameExistingFollowingFiles(LogEntry entry, string mailDate, int targetCounterValue, string filenamePart)
        {
            string filename = $"{mailDate} ({targetCounterValue}) {SelectedFileName.Text}.msg";
            List<int> fileCountersToIncrease = new List<int>();
            // Get all file counters starting with the current one
            while (File.Exists(Path.Combine(entry.Folder, filename)))
            {
                fileCountersToIncrease.Add(targetCounterValue);
                targetCounterValue++;
                filename = $"{mailDate} ({targetCounterValue}) {filenamePart}.msg";
            }
            for (int i = fileCountersToIncrease.Count - 1; i >= 0; i--)
            {
                string oldFilename = Path.Combine(entry.Folder, $"{mailDate} ({fileCountersToIncrease[i]}) {SelectedFileName.Text}.msg");
                string newFilename = Path.Combine(entry.Folder, $"{mailDate} ({fileCountersToIncrease[i] + 1}) {SelectedFileName.Text}.msg");
                System.IO.File.Move(oldFilename, newFilename);
            }
        }
    }
}
