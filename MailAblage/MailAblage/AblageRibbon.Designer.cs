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
            this.TabAblage = this.Factory.CreateRibbonTab();
            this.Settings = this.Factory.CreateRibbonGroup();
            this.ToggleDropAreaPane = this.Factory.CreateRibbonToggleButton();
            this.AutomaticDelecte = this.Factory.CreateRibbonCheckBox();
            this.ToggleLogPane = this.Factory.CreateRibbonToggleButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.directorySearcher = new System.DirectoryServices.DirectorySearcher();
            this.button1 = this.Factory.CreateRibbonButton();
            this.TabAblage.SuspendLayout();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabAblage
            // 
            this.TabAblage.Groups.Add(this.Settings);
            this.TabAblage.Label = "Ablage";
            this.TabAblage.Name = "TabAblage";
            // 
            // Settings
            // 
            this.Settings.Items.Add(this.ToggleDropAreaPane);
            this.Settings.Items.Add(this.AutomaticDelecte);
            this.Settings.Items.Add(this.ToggleLogPane);
            this.Settings.Items.Add(this.button2);
            this.Settings.Label = "Einstellungen";
            this.Settings.Name = "Settings";
            // 
            // ToggleDropAreaPane
            // 
            this.ToggleDropAreaPane.Label = "Ablage anzeigen";
            this.ToggleDropAreaPane.Name = "ToggleDropAreaPane";
            this.ToggleDropAreaPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleDropPane_Click);
            // 
            // AutomaticDelecte
            // 
            this.AutomaticDelecte.Label = "Automatisch löschen";
            this.AutomaticDelecte.Name = "AutomaticDelecte";
            this.AutomaticDelecte.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.automaticDelete_Click);
        
            // 
            // button2
            // 
            this.button2.Label = "";
            this.button2.Name = "button2";
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
            // AblageRibbon
            // 
            this.Name = "AblageRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.TabAblage);
            this.TabAblage.ResumeLayout(false);
            this.TabAblage.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Settings;
        private System.DirectoryServices.DirectorySearcher directorySearcher;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabAblage;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ToggleDropAreaPane;
        public Microsoft.Office.Tools.Ribbon.RibbonCheckBox AutomaticDelecte;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ToggleLogPane;
    }

    partial class ThisRibbonCollection
    {
        internal AblageRibbon AblageRibbon
        {
            get { return this.GetRibbon<AblageRibbon>(); }
        }
    }
}
