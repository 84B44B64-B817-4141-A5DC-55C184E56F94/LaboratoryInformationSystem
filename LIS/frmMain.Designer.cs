namespace LIS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPatientDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPreviousPatientDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valueThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_usertype = new System.Windows.Forms.Label();
            this.menMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menMain
            // 
            this.menMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.patientsDataToolStripMenuItem,
            this.testToolStripMenuItem,
            this.tsmMaintenance,
            this.aboutToolStripMenuItem});
            this.menMain.Location = new System.Drawing.Point(0, 0);
            this.menMain.Name = "menMain";
            this.menMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menMain.Size = new System.Drawing.Size(1284, 25);
            this.menMain.TabIndex = 1;
            this.menMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // patientsDataToolStripMenuItem
            // 
            this.patientsDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPatientDataToolStripMenuItem,
            this.viewPreviousPatientDataToolStripMenuItem});
            this.patientsDataToolStripMenuItem.Name = "patientsDataToolStripMenuItem";
            this.patientsDataToolStripMenuItem.Size = new System.Drawing.Size(91, 19);
            this.patientsDataToolStripMenuItem.Text = "&Patients\' Data";
            // 
            // addNewPatientDataToolStripMenuItem
            // 
            this.addNewPatientDataToolStripMenuItem.Name = "addNewPatientDataToolStripMenuItem";
            this.addNewPatientDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addNewPatientDataToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.addNewPatientDataToolStripMenuItem.Text = "&Add New Patient Data";
            this.addNewPatientDataToolStripMenuItem.Click += new System.EventHandler(this.addNewPatientDataToolStripMenuItem_Click);
            // 
            // viewPreviousPatientDataToolStripMenuItem
            // 
            this.viewPreviousPatientDataToolStripMenuItem.Name = "viewPreviousPatientDataToolStripMenuItem";
            this.viewPreviousPatientDataToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.viewPreviousPatientDataToolStripMenuItem.Text = "&View Previous Patient Data";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.testToolStripMenuItem.Text = "&Tests";
            // 
            // tsmMaintenance
            // 
            this.tsmMaintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseManagerToolStripMenuItem,
            this.userAccountsToolStripMenuItem,
            this.valueThresholdToolStripMenuItem,
            this.priceListToolStripMenuItem,
            this.auditTrailToolStripMenuItem});
            this.tsmMaintenance.Name = "tsmMaintenance";
            this.tsmMaintenance.Size = new System.Drawing.Size(88, 19);
            this.tsmMaintenance.Text = "&Maintenance";
            // 
            // databaseManagerToolStripMenuItem
            // 
            this.databaseManagerToolStripMenuItem.Name = "databaseManagerToolStripMenuItem";
            this.databaseManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.databaseManagerToolStripMenuItem.Text = "&Database Manager";
            // 
            // userAccountsToolStripMenuItem
            // 
            this.userAccountsToolStripMenuItem.Name = "userAccountsToolStripMenuItem";
            this.userAccountsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.userAccountsToolStripMenuItem.Text = "&User Accounts";
            // 
            // valueThresholdToolStripMenuItem
            // 
            this.valueThresholdToolStripMenuItem.Name = "valueThresholdToolStripMenuItem";
            this.valueThresholdToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.valueThresholdToolStripMenuItem.Text = "&Value Thresholds";
            // 
            // priceListToolStripMenuItem
            // 
            this.priceListToolStripMenuItem.Name = "priceListToolStripMenuItem";
            this.priceListToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.priceListToolStripMenuItem.Text = "&Price List";
            this.priceListToolStripMenuItem.Click += new System.EventHandler(this.priceListToolStripMenuItem_Click);
            // 
            // auditTrailToolStripMenuItem
            // 
            this.auditTrailToolStripMenuItem.Name = "auditTrailToolStripMenuItem";
            this.auditTrailToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.auditTrailToolStripMenuItem.Text = "&Audit Trail";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "&About";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(778, 8);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(38, 17);
            this.lbl_username.TabIndex = 2;
            this.lbl_username.Text = "temp";
            this.lbl_username.Visible = false;
            // 
            // lbl_usertype
            // 
            this.lbl_usertype.AutoSize = true;
            this.lbl_usertype.Location = new System.Drawing.Point(832, 8);
            this.lbl_usertype.Name = "lbl_usertype";
            this.lbl_usertype.Size = new System.Drawing.Size(38, 17);
            this.lbl_usertype.TabIndex = 3;
            this.lbl_usertype.Text = "temp";
            this.lbl_usertype.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1284, 633);
            this.Controls.Add(this.lbl_usertype);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.menMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menMain.ResumeLayout(false);
            this.menMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPatientDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPreviousPatientDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmMaintenance;
        private System.Windows.Forms.ToolStripMenuItem databaseManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valueThresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditTrailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.ToolStripMenuItem priceListToolStripMenuItem;
        public System.Windows.Forms.Label lbl_usertype;
    }
}