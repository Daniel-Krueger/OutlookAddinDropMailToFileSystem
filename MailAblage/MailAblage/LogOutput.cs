using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailAblage
{
    public partial class LogOutput : UserControl
    {
         public BindingSource LogEntries { get; private set; }
        public LogOutput()
        {
            InitializeComponent();
            LogEntries = new BindingSource();
            this.logoutputGridView.DataSource = LogEntries;
            logoutputGridView.AutoGenerateColumns = false;
        }
    }
}
