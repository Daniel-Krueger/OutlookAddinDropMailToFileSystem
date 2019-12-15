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


        private void toggleDropPane_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.DropPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void toggleLogPane_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.LogPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void automaticDelete_Click(object sender, RibbonControlEventArgs e)
        {
            Properties.Settings.Default.AutomaticDelete = this.AutomaticDelecte.Checked;
        }
    }
}
