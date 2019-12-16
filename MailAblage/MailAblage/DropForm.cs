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
using System.Text.RegularExpressions;

namespace MailAblage
{

    public partial class DropForm : UserControl
    {
        private const string fileNamePatternGroup = "filename";
        private static Regex FileNamePattern = new Regex(@"\d{4}-\d{1,2}-\d{1,2}\s*\(\d*\)\s*(?<" + fileNamePatternGroup + @">.*)\.[^.]*$");
        private string oldFolder = null;
        public string DefaultPath = "";
        private const int MaxFolderNames = 5;

        public BindingSource LogEntries { get; private set; }

        public DropForm()
        {
            InitializeComponent();
            InitControls(null);
        }

        public void InitControls(string defaultPath)
        {
            this.fileDropArea.SelectedFileName = this.selectedFileName;
            this.fileDropArea.SelectedFolder = this.selectedFolder;
            this.saveAsDropArea.SelectedFileName = this.selectedFileName;
            this.saveAsDropArea.SelectedFolder = this.selectedFolder;

            this.DefaultPath = defaultPath;
            if (Properties.Settings.Default.LastFolders != null && Properties.Settings.Default.LastFolders.Count > 0)
            {
                string[] newValues = new string[Properties.Settings.Default.LastFolders.Count];
                Properties.Settings.Default.LastFolders.CopyTo(newValues, 0);
                this.selectedFolder.Items.AddRange(newValues);
                this.selectedFolder.SelectedItem = this.selectedFolder.Items[0];
            }

            LogEntries = new BindingSource();
            this.logoutputGridView.DataSource = LogEntries;
            logoutputGridView.AutoGenerateColumns = false;
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

        private void selectDirectory_ButtonClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.selectedFolder.Text))
            {
                this.openFileDialog.InitialDirectory = this.selectedFolder.Text;
            }
            else if (string.IsNullOrEmpty(this.openFileDialog.InitialDirectory))
            {
                this.openFileDialog.InitialDirectory = DefaultPath;
            }
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedPath = this.openFileDialog.FileName.Substring(0, this.openFileDialog.FileName.LastIndexOf("\\"));
                UpdateSelectedFolders(selectedPath);
            }

        }

        private void UpdateSelectedFolders(string selectedPath)
        {
            string[] currentValues = new string[this.selectedFolder.Items.Count];
            this.selectedFolder.Items.CopyTo(currentValues, 0);
            this.selectedFolder.Items.Clear();
            var index = this.selectedFolder.Items.Add(selectedPath);
            this.selectedFolder.SelectedItem = index;
            this.selectedFolder.SelectedItem = this.selectedFolder.Items[index];
            this.selectedFolder.Items.AddRange(currentValues.Where(x => !x.Equals(selectedPath)).Take(MaxFolderNames).ToArray());
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

        private void selectedFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newFolder = this.selectedFolder.Text;
            if (newFolder.Equals(oldFolder, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            var filenames = System.IO.Directory.GetFiles(newFolder);
            var filePatterns = new HashSet<string>();
            foreach (var filename in filenames)
            {
                var matches = FileNamePattern.Match(filename);
                if (matches.Success)
                {
                    filePatterns.Add(matches.Groups[fileNamePatternGroup].Value);
                }
            }
            this.selectedFileName.Items.Clear();
            this.selectedFileName.Text = null;
            this.selectedFileName.Items.AddRange(filePatterns.ToArray());
            oldFolder = newFolder;
        }
    }
}
