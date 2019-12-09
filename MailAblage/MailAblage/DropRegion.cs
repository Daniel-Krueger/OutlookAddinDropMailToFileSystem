using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MailAblage
{
    partial class DropRegion
    {
        #region Form Region Factory 

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("MailAblage.DropRegion")]
        public partial class DropRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void DropRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void DropRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void DropRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
        }

        private void button1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            var app = new Microsoft.Office.Interop.Outlook.Application();        // get current selected items
            Microsoft.Office.Interop.Outlook.Selection sel = app.ActiveExplorer().Selection;
            string p = @"c:\SaveHere";
            foreach (object mitem in sel)
            {

                Microsoft.Office.Interop.Outlook.MailItem mi = (Microsoft.Office.Interop.Outlook.MailItem)mitem;
                //Outlook.OlSaveAsType. -olMSG, olHTML, olDoc, etc.
                mi.SaveAs(p + mi.Subject.ToString() + ".msg", Outlook.OlSaveAsType.olMSG);   //Message stored in path file as .msg form
                //textBox1.Text = p + mi.Subject.ToString() + ".msg";
                //for (int i = 1; i <= mi.Attachments.Count; i++)
                //{
                //    mi.Attachments.SaveAsFile(p + mi.Attachments.Filename);
                //}
            }
        }
    }
}
