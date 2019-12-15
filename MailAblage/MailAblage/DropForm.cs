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

    public partial class DropForm : UserControl
    {

        public string DefaultPath = "";
        private const int MaxFolderNames = 5;
        private static string LastFolderFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), @"MailAblage_LastFolders.json");

        public DropForm()
        {
            InitializeComponent();
            InitControls(null);
        }

        protected override void Dispose(bool disposing)
        {
            Properties.Settings.Default.LastFolders = new System.Collections.Specialized.StringCollection();
            string[] newValues = new string[this.selectedFolder.Items.Count];
            this.selectedFolder.Items.CopyTo(newValues, 0);
            Properties.Settings.Default.LastFolders.AddRange(newValues);

            Properties.Settings.Default.Save();

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        public void InitControls(string defaultPath)
        {
            this.fileDropArea.SelectedFileName = this.selectedFileName;
            this.fileDropArea.SelectedFolder = this.selectedFolder;
            this.folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            this.DefaultPath = defaultPath;
            if (Properties.Settings.Default.LastFolders != null && Properties.Settings.Default.LastFolders.Count > 0)
            {
                string[] newValues = new string[Properties.Settings.Default.LastFolders.Count];
                Properties.Settings.Default.LastFolders.CopyTo(newValues, 0);
                this.selectedFolder.Items.AddRange(newValues);
                this.selectedFolder.SelectedItem = this.selectedFolder.Items[0];
            }
            //if (File.Exists(LastFolderFilePath))
            //{
            //    var content = File.ReadAllText(LastFolderFilePath);
            //    var folders = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //    if (folders.Length > 0)
            //    {
            //        this.selectedFolder.Items.AddRange(folders);
            //        this.selectedFolder.SelectedItem = folders[0];
            //    }
            //}

        }

        private void DisplayMessage(OutlookStorage.Message outlookMsg)
        {
            //this.droppedFiles.Text += $"Subject {outlookMsg.Subject} Date {outlookMsg.ReceivedDate}\r\n";

            //Console.WriteLine("Subject: {0}", outlookMsg.Subject);
            //Console.WriteLine("Body: {0}", outlookMsg.BodyText);

            //Console.WriteLine("{0} Recipients", outlookMsg.Recipients.Count);
            //foreach (OutlookStorage.Recipient recip in outlookMsg.Recipients)
            //{
            //    Console.WriteLine(" {0}:{1}", recip.Type, recip.Email);
            //}

            //Console.WriteLine("{0} Attachments", outlookMsg.Attachments.Count);
            //foreach (OutlookStorage.Attachment attach in outlookMsg.Attachments)
            //{
            //    Console.WriteLine(" {0}, {1}b", attach.Filename, attach.Data.Length);
            //}

            //Console.WriteLine("{0} Messages", outlookMsg.Messages.Count);
            //foreach (OutlookStorage.Message subMessage in outlookMsg.Messages)
            //{
            //    DisplayMessage(subMessage);
            //}
        }

        private void selectDirectory_ButtonClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.selectedFolder.SelectedItem as string))
            {
                this.openFileDialog.InitialDirectory = this.selectedFolder.SelectedItem as string;
            }
            else if (string.IsNullOrEmpty(this.folderBrowserDialog.SelectedPath))
            {
                this.openFileDialog.InitialDirectory = DefaultPath;
            }
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] currentValues = new string[this.selectedFolder.Items.Count];
                this.selectedFolder.Items.CopyTo(currentValues, 0);
                this.selectedFolder.Items.Clear();
                var index = this.selectedFolder.Items.Add(this.openFileDialog.FileName.Substring(0, this.openFileDialog.FileName.LastIndexOf("\\")));
                this.selectedFolder.SelectedItem = index;
                this.selectedFolder.SelectedItem = this.selectedFolder.Items[index];
                this.selectedFolder.Items.AddRange(currentValues.Where(x => !x.Equals(folderBrowserDialog.SelectedPath)).Take(MaxFolderNames).ToArray());
            }

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
