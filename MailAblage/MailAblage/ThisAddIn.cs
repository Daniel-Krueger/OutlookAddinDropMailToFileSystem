using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;

namespace MailAblage
{
    public partial class ThisAddIn
    {

        private Microsoft.Office.Interop.Outlook.Application app;
        private DropForm dropArea;
        private Microsoft.Office.Tools.CustomTaskPane dropPane;
        public Microsoft.Office.Tools.CustomTaskPane DropPane
        {
            get
            {
                return dropPane;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Globals.Ribbons.AblageRibbon.AutomaticDelecte.Checked = Properties.Settings.Default.AutomaticDelete;
            RegisterToExceptionEvents();
            dropArea = new DropForm();
            dropArea.fileDropArea.OnFileSaved += DroppedFileSaved;
            dropPane = this.CustomTaskPanes.Add(dropArea, "Ablage");
            dropPane.Visible = Globals.Ribbons.AblageRibbon.ToggleDropAreaPane.Checked;
            dropPane.VisibleChanged += new EventHandler(dropPaneVisibilityChanged);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void dropPaneVisibilityChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.AblageRibbon.ToggleDropAreaPane.Checked = dropPane.Visible;
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
                        if (messageId.Equals(newEntry.MessageId)) ;
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
                dropArea.LogEntries.Add(newEntry);
            }
            //string filter = string.Format("@SQL=\"http://schemas.microsoft.com/mapi/proptag/0x1035001F\" = '{0}'", eventArgs.Info);
            //object result = test.Find(filter);
            //MailItem mail = (MailItem)result;

            ////var serach = app.AdvancedSearch(app.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).FolderPath, filter, true, "ABC");

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
