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
        private void AblageRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
           
        }

        private void AblageRibbon_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
