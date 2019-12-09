namespace MailAblage
{
    partial class AblageRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AblageRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.Verzeichnis = this.Factory.CreateRibbonEditBox();
            this.directorySearcher = new System.DirectoryServices.DirectorySearcher();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Ablage";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.label1);
            this.group1.Items.Add(this.Verzeichnis);
            this.group1.Items.Add(this.button2);
            this.group1.Label = "Einstellungen";
            this.group1.Name = "group1";
            // 
            // label1
            // 
            this.label1.Label = "label1";
            this.label1.Name = "label1";
            // 
            // Verzeichnis
            // 
            this.Verzeichnis.Label = "editBox1";
            this.Verzeichnis.Name = "Verzeichnis";
            this.Verzeichnis.Text = null;
            // 
            // directorySearcher
            // 
            this.directorySearcher.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // button1
            // 
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            // 
            // button2
            // 
            this.button2.Label = "button2";
            this.button2.Name = "button2";
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // AblageRibbon
            // 
            this.Name = "AblageRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AblageRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox Verzeichnis;
        private System.DirectoryServices.DirectorySearcher directorySearcher;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
    }

    partial class ThisRibbonCollection
    {
        internal AblageRibbon AblageRibbon
        {
            get { return this.GetRibbon<AblageRibbon>(); }
        }
    }
}
