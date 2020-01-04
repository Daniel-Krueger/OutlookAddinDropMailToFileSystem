using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

using System.Windows.Forms;

namespace MailAblage
{

    [ComVisible(true), Guid("8B56AE5D-104D-4c0c-BEAA-3E44C5A7E1DC"), ProgId("MailAblage.AblageRibbon")]
    public partial class AblageRibbon
    {
        public delegate void FavoritesChangedHandler(object sender, FavoriteChangedArgs e);
        public event FavoritesChangedHandler OnFavoriteChanged;

        private void toggleDropPane_Click(object sender, RibbonControlEventArgs e)
        {
           
            Globals.ThisAddIn.DropPane.Visible = ((RibbonToggleButton)sender).Checked;

        }

       

        private void toggleLogPane_Click(object sender, RibbonControlEventArgs e)
        {

            Globals.ThisAddIn.LogPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

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
        private void automaticDelete_Click(object sender, RibbonControlEventArgs e)
        {
            Properties.Settings.Default.AutomaticDelete = this.AutomaticDelecte.Checked;
        }

        private void addFavoriteButton_Click(object sender, RibbonControlEventArgs e)
        {
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.CheckPathExists = false;
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedPath = this.openFileDialog.FileName.Substring(0, this.openFileDialog.FileName.LastIndexOf("\\"));
                UpdateSelectedFolders(selectedPath);
            }

            RaiseFavoriteChangedEvent();
        }

        private void RaiseFavoriteChangedEvent()
        {
            // Make sure someone is listening to event
            if (OnFavoriteChanged == null)
                return;
            var args = new FavoriteChangedArgs(this.favoriteFolders.Items.Select(i => i as RibbonDropDownItem).Select(i => i.Label).ToArray());
            OnFavoriteChanged(this, args);
        }
        private void UpdateSelectedFolders(string selectedPath)
        {
            var item = (RibbonDropDownItem)Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
            item.Label = selectedPath;
            this.favoriteFolders.Items.Add(item);
            Type type = item.GetType();
            var folders = this.favoriteFolders.Items.Select(i => i as RibbonDropDownItem).OrderBy(i => i.Label).Select(i => i.Label).ToArray();
            this.favoriteFolders.Items.Clear();

            foreach (var path in folders)
            {
                item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                item.Label = path;
                this.favoriteFolders.Items.Add(item);
                if (item.Label.Equals(selectedPath))
                {
                    this.favoriteFolders.SelectedItem = item;
                }
            }
        }

        private void removeFavoriteButton_Click(object sender, RibbonControlEventArgs e)
        {
            this.favoriteFolders.Items.Remove(this.favoriteFolders.SelectedItem);
            RaiseFavoriteChangedEvent();
        }

        public void InitFavoriteDropDownItems(string[] favorites)
        {
            foreach (string path in favorites)
            {
                var item = (RibbonDropDownItem)Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                item.Label = path.Replace(DropForm.favoritePrefix, "");
                this.favoriteFolders.Items.Add(item);
            }
        }
    }

    public class FavoriteChangedArgs : EventArgs
    {
        public string[] Favorites { get; private set; }

        public FavoriteChangedArgs(string[] favorites)
        {
            Favorites = favorites;
        }
    }
}
