﻿using System;
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
using System.Text.RegularExpressions;

namespace MailAblage
{
    [ComVisible(true), Guid("8B56AE5D-104D-4c0c-BEAA-4E44C5A7E1DC"), ProgId("MailAblage.SaveAsDropArea")]
    public partial class SaveAsDropArea : DropUserControl
    {

        internal ComboBox SelectedFolder { get; set; }
        internal ComboBox SelectedFileName { get; set; }


        public SaveAsDropArea() : base()
        {
            InitializeComponent();
        }

        protected void DropArea_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            //ensure FileGroupDescriptor is present before allowing drop
            //if (e.Data.GetDataPresent("FileGroupDescriptor"))
            //{
            //    OutlookDataObject dataObject = new OutlookDataObject(e.Data);
            //    string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");
            //    if (filenames.Length == 1)
            //    {
            //        e.Effect = DragDropEffects.Copy;
            //    }
            //}
        }

        private void itemDropped(object sender, DragEventArgs e)
        {
            MemoryStream[] filestreams = null;
            try
            {

                string targetFolder = null;
                string targetFileName = null;

                //wrap standard IDataObject in OutlookDataObject
                OutlookDataObject dataObject = new OutlookDataObject(e.Data);

                //get the names and data streams of the files dropped
                string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");
                filestreams = (MemoryStream[])dataObject.GetData("FileContents");

                for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                {
                    //use the fileindex to get the name and data stream
                    string filename = filenames[fileIndex];
                    using (MemoryStream filestream = filestreams[fileIndex])
                    {

                        LogEntry newEntry = new LogEntry();

                        Helper.GetNewEntryFromMessage(filestream, out newEntry);
                        if (fileIndex == 0)
                        {
                            if (!string.IsNullOrEmpty(this.SelectedFolder.Text))
                            {
                                this.openFileDialog.InitialDirectory = this.SelectedFolder.Text.Replace(DropForm.favoritePrefix, "");
                            }
                            this.openFileDialog.DefaultExt = filename.Substring(filename.LastIndexOf('.'));
                            if (newEntry.SpecialCase)
                            {
                                this.openFileDialog.FileName = newEntry.Filename;
                            }
                            else
                            {
                                this.openFileDialog.FileName = filename;
                            }
                            DialogResult result = this.openFileDialog.ShowDialog();
                            if (result != DialogResult.OK)
                            {
                                return;
                            }
                            targetFolder = this.openFileDialog.FileName.Substring(0, this.openFileDialog.FileName.LastIndexOf("\\"));
                            targetFileName = this.openFileDialog.FileName.Substring(targetFolder.Length + 1);

                        }

                        newEntry.Folder = targetFolder;
                        
                        string fileNamePattern = Helper.GetFileNamePattern(targetFileName);
                        if (filename.EndsWith("msg") && !newEntry.SpecialCase)
                        {

                            int fileCounter = 1;
                            newEntry.Filename = $"{newEntry.MailDateTime.ToString("yyyy-MM-dd")} ({fileCounter}) {fileNamePattern}.msg";
                            while (File.Exists(Path.Combine(newEntry.Folder, newEntry.Filename)))
                            {
                                fileCounter++;
                                newEntry.Filename = $"{newEntry.MailDateTime.ToString("yyyy-MM-dd")} ({fileCounter}) {fileNamePattern}.msg";
                            }
                        }
                        else
                        {
                            newEntry.Filename = targetFileName;
                        }



                        //save the file stream using its name to the application path
                        string targetPath = Path.Combine(newEntry.Folder, newEntry.Filename);
                        using (FileStream outputStream = File.Create(targetPath))
                        {
                            filestream.WriteTo(outputStream);
                            outputStream.Close();
                        }
                        FileSaved(newEntry);
                    }
                }
                DropCompleted(targetFolder, targetFileName);



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (filestreams != null)
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
        }



    }
}
