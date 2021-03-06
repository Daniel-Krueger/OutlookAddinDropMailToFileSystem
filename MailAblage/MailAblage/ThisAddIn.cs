﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;

namespace MailAblage
{
    public partial class ThisAddIn
    {

        private Microsoft.Office.Interop.Outlook.Application app;
        private DropForm dropArea;
        private LogOutput logOutput;
        private Microsoft.Office.Tools.CustomTaskPane dropPane;
        private Microsoft.Office.Tools.CustomTaskPane logPane;
        public Microsoft.Office.Tools.CustomTaskPane DropPane
        {
            get
            {
                return dropPane;
            }
        }

        public Microsoft.Office.Tools.CustomTaskPane LogPane
        {
            get
            {
                return logPane;
            }
        }
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

            ((Outlook.ApplicationEvents_11_Event)Application).Quit += new Outlook.ApplicationEvents_11_QuitEventHandler(ThisAddIn_Quit);
            Globals.Ribbons.AblageRibbon.AutomaticDelecte.Checked = Properties.Settings.Default.AutomaticDelete;
            RegisterToExceptionEvents();

            #region init drop pane
            dropArea = new DropForm();
            dropArea.fileDropArea.OnFileSaved += DroppedFileSaved;
            dropArea.saveAsDropArea.OnFileSaved += DroppedFileSaved;
            dropPane = this.CustomTaskPanes.Add(dropArea, "Ablage");
            SetPaneProperties(dropPane, Properties.Settings.Default.DropPanePosition, Properties.Settings.Default.DropPaneSize, Properties.Settings.Default.DropPaneVisible);
            Globals.Ribbons.AblageRibbon.ToggleDropAreaPane.Checked = dropPane.Visible;
            dropPane.VisibleChanged += new EventHandler(dropPaneVisibilityChanged);
            #endregion

            #region init log pane
            logOutput = new LogOutput();
            logPane = this.CustomTaskPanes.Add(logOutput, "Log");
            SetPaneProperties(logPane, Properties.Settings.Default.LogPanePosition, Properties.Settings.Default.LogPaneSize, Properties.Settings.Default.LogPaneVisible);
            Globals.Ribbons.AblageRibbon.ToggleLogPane.Checked = logPane.Visible;
            logPane.VisibleChanged += new EventHandler(logPaneVisibilityChanged);
            Globals.Ribbons.AblageRibbon.OnFavoriteChanged += favoritesChanged;
            #endregion 

            #region init favorites
            if (Properties.Settings.Default.Favorites != null)
            {
                string[] favorites = new string[Properties.Settings.Default.Favorites.Count];
                Properties.Settings.Default.Favorites.CopyTo(favorites, 0);
                Globals.Ribbons.AblageRibbon.InitFavoriteDropDownItems(favorites);
                dropArea.AddFavoriteFolders(favorites);
            }
            #endregion
        }

        private void SetPaneProperties(CustomTaskPane pane, int positionValue, int size, bool visible)
        {
            var position = (Microsoft.Office.Core.MsoCTPDockPosition)positionValue;
            pane.DockPosition = position;
            if (position == Office.MsoCTPDockPosition.msoCTPDockPositionBottom ||
                position == Office.MsoCTPDockPosition.msoCTPDockPositionTop)
            {
                pane.Height = size;
            }
            if (position == Office.MsoCTPDockPosition.msoCTPDockPositionLeft ||
                position == Office.MsoCTPDockPosition.msoCTPDockPositionRight)
            {
                pane.Width = size;
            }
            pane.Visible = visible;
        }

        private void ThisAddIn_Quit()
        {
            #region drop pane
            Properties.Settings.Default.DropPanePosition = (int)Globals.ThisAddIn.DropPane.DockPosition;
            if (Globals.ThisAddIn.DropPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom ||
                Globals.ThisAddIn.DropPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionTop)
            {
                Properties.Settings.Default.DropPaneSize = Globals.ThisAddIn.DropPane.Height;
            }
            if (Globals.ThisAddIn.DropPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft ||
                Globals.ThisAddIn.DropPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight)
            {
                Properties.Settings.Default.DropPaneSize = Globals.ThisAddIn.DropPane.Width;
            }
            Properties.Settings.Default.DropPaneVisible = Globals.ThisAddIn.DropPane.Visible;

            #endregion
            #region log pane
            Properties.Settings.Default.LogPanePosition = (int)Globals.ThisAddIn.LogPane.DockPosition;
            if (Globals.ThisAddIn.LogPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom ||
                Globals.ThisAddIn.LogPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionTop)
            {
                Properties.Settings.Default.LogPaneSize = Globals.ThisAddIn.DropPane.Height;
            }
            if (Globals.ThisAddIn.LogPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft ||
                Globals.ThisAddIn.LogPane.DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight)
            {
                Properties.Settings.Default.LogPaneSize = Globals.ThisAddIn.DropPane.Width;
            }
            Properties.Settings.Default.LogPaneVisible = Globals.ThisAddIn.LogPane.Visible;
            #endregion
            Properties.Settings.Default.Save();
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void dropPaneVisibilityChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.AblageRibbon.ToggleDropAreaPane.Checked = dropPane.Visible;
            //Properties.Settings.Default.DropPaneVisible = Globals.Ribbons.AblageRibbon.ToggleDropAreaPane.Checked;
            //Properties.Settings.Default.Save();
        }

        private void logPaneVisibilityChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.AblageRibbon.ToggleLogPane.Checked = LogPane.Visible;
            //Properties.Settings.Default.LogPaneVisible = Globals.Ribbons.AblageRibbon.ToggleLogPane.Checked;
            //Properties.Settings.Default.Save();
        }

        private void DroppedFileSaved(object sender, DropUserControl.FileSavedEventArgs eventArgs)
        {
            var newEntry = eventArgs.Entry;
            try
            {
                if (!Globals.Ribbons.AblageRibbon.AutomaticDelecte.Checked)
                {
                    return;
                }
                app = new Microsoft.Office.Interop.Outlook.Application();

                var test = app.ActiveExplorer().CurrentFolder.Items;
                var selection = app.ActiveExplorer().Selection;
                MailItem itemToDelete = null;
                foreach (MailItem item in selection)
                {
                    Microsoft.Office.Interop.Outlook.PropertyAccessor oPropAccessor = item.PropertyAccessor;
                    if (item != null)
                    {
                        string messageId = (string)oPropAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x1035001E");
                        if (messageId.Equals(newEntry.MessageId))
                        {
                            itemToDelete = item;
                            break;
                        }
                    }
                }
                if (itemToDelete != null)
                {
                    bool deleted = false;
                    try
                    {
                        itemToDelete.Delete();
                        deleted = true;
                    }
                    catch (System.Exception ex)
                    {
                        newEntry.Message = $"Mail {itemToDelete.Subject} konnte nicht gelöscht werden. Fehler: {ex.Message}";
                    }
                    finally
                    {
                        newEntry.deleted = deleted;
                    }
                }
                else
                {
                    newEntry.Message = $"Die gedroppte Mail {newEntry.MailSubject} wurde nicht gefunden.";
                }
            }
            catch (System.Exception ex)
            {
                newEntry.Message = $"Unerwarteter Fehler: {ex.Message}";
            }
            finally
            {
                if (!string.IsNullOrEmpty(newEntry.Message))
                {
                    System.Windows.Forms.MessageBox.Show(newEntry.Message, "Fehler", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                logOutput.LogEntries.Add(newEntry);
            }
            //string filter = string.Format("@SQL=\"http://schemas.microsoft.com/mapi/proptag/0x1035001F\" = '{0}'", eventArgs.Info);
            //object result = test.Find(filter);
            //MailItem mail = (MailItem)result;

            ////var serach = app.AdvancedSearch(app.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).FolderPath, filter, true, "ABC");

        }

        private void favoritesChanged(object sender, FavoriteChangedArgs e)
        {
            Properties.Settings.Default.Favorites = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.Favorites.AddRange(e.Favorites);
            Properties.Settings.Default.Save();
            this.dropArea.AddFavoriteFolders(e.Favorites);
        }

        private static void RegisterToExceptionEvents()
        {
            System.Windows.Forms.Application.ThreadException += ApplicationThreadException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
        }

        private static bool _handlingUnhandledException;
        static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException((System.Exception)e.ExceptionObject);//there is small possibility that this wont be exception but only when interacting with code that can throw object that does not inherit from Exception
        }

        static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception);
        }

        private static void HandleUnhandledException(System.Exception exception)
        {
            if (_handlingUnhandledException)
                return;
            try
            {
                _handlingUnhandledException = true;

                //ErrorHandler.HandleFatalError(exception, "Unhandled exception occurred, plug-in will close.");
            }
            finally
            {
                _handlingUnhandledException = false;
            }
        }


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
