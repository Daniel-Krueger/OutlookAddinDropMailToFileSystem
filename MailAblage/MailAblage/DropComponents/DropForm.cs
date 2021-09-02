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
        private string oldFolder = null;
        public string DefaultPath = "";
        private const int MaxFolderNames = 5;
        internal const string favoritePrefix = "*** ";
        private static List<string> favoriteFolders = new List<string>();

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
            this.saveAsDropArea.OnDropCompleted += DropCompleted;
            this.DefaultPath = defaultPath;
            if (Properties.Settings.Default.LastFolders != null && Properties.Settings.Default.LastFolders.Count > 0)
            {
                string[] newValues = new string[Properties.Settings.Default.LastFolders.Count];
                Properties.Settings.Default.LastFolders.CopyTo(newValues, 0);
                this.selectedFolder.Items.AddRange(newValues);
                this.selectedFolder.SelectedItem = this.selectedFolder.Items[0];
            }
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
                this.openFileDialog.InitialDirectory = this.selectedFolder.Text.Replace(favoritePrefix, "");
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
                selectedFileName.Text = Helper.GetFileNamePattern(this.openFileDialog.FileName.Substring(this.openFileDialog.FileName.LastIndexOf("\\")));
            }
        }

        private void DropCompleted(object sender, DropUserControl.DropCompletedEventArgs eventArgs)
        {
            UpdateSelectedFolders(eventArgs.Folder);

            string pattern = Helper.GetFileNamePattern(eventArgs.Filename);
            for (var i = 0; i < selectedFileName.Items.Count; i++)
            {
                if (selectedFileName.Items[i].Equals(pattern))
                {
                    selectedFileName.SelectedIndex = i;
                    break;
                }
            }

        }

        private void UpdateSelectedFolders(string selectedPath)
        {
            UpdateFilePatterns(selectedPath);
            if (selectedPath.Equals(this.selectedFolder.Text.Replace(favoritePrefix, ""), StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            string[] currentValues = new string[this.selectedFolder.Items.Count];
            this.selectedFolder.Items.CopyTo(currentValues, 0);
            this.selectedFolder.Items.Clear();
            var index = this.selectedFolder.Items.Add(selectedPath);
            this.selectedFolder.SelectedItem = index;
            this.selectedFolder.SelectedItem = this.selectedFolder.Items[index];
            this.selectedFolder.Items.AddRange(currentValues.Where(x => !x.Equals(selectedPath) && !x.StartsWith(favoritePrefix)).Take(MaxFolderNames).ToArray());
            this.selectedFolder.Items.AddRange(favoriteFolders.ToArray());
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
            string newFolder = this.selectedFolder.Text.Replace(favoritePrefix, "");
            if (newFolder.Equals(oldFolder, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            UpdateFilePatterns(newFolder);
            oldFolder = newFolder;
        }

        private void UpdateFilePatterns(string folder)
        {
            this.selectedFileName.Items.Clear();
            this.selectedFileName.Text = null;

            if (!System.IO.Directory.Exists(folder))
            {
                return;
            }
            var filenames = System.IO.Directory.GetFiles(folder);
            var filePatterns = new HashSet<string>();
            foreach (var filename in filenames)
            {
                filePatterns.Add(Helper.GetFileNamePattern(filename.Substring(folder.Length + 1)));
            }
            this.selectedFileName.Items.AddRange(filePatterns.OrderBy(x => x).ToArray());
        }

        public void AddFavoriteFolders(string[] favorites)
        {
            favoriteFolders.Clear();
            foreach (var value in favorites)
            {
                var label = favoritePrefix + value;
                favoriteFolders.Add(label);
            }

            var currentSelectedItem = this.selectedFolder.SelectedItem as string;
            string[] currentValues = new string[this.selectedFolder.Items.Count];
            this.selectedFolder.Items.CopyTo(currentValues, 0);
            this.selectedFolder.Items.Clear();
            foreach (var value in currentValues)
            {
                if (value.StartsWith(favoritePrefix))
                {
                    continue;
                }
                var index = this.selectedFolder.Items.Add(value);
                if (currentSelectedItem.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.selectedFolder.SelectedItem = this.selectedFolder.Items[index];
                }
            }
            this.selectedFolder.Items.AddRange(favoriteFolders.ToArray());
        }
    }
}
