namespace SupplyChainManagementSystem
{
    partial class ConnectionsAndCompaniesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionsAndCompaniesDialog));
            this.tbctrlSettings = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdCompanies = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnSaveCompanies = new DevComponents.DotNetBar.ButtonItem();
            this.tbCompanies = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdServers = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSaveServers = new DevComponents.DotNetBar.ButtonItem();
            this.tbServers = new DevComponents.DotNetBar.SuperTabItem();
            this.bar3 = new DevComponents.DotNetBar.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.tbctrlSettings)).BeginInit();
            this.tbctrlSettings.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).BeginInit();
            this.SuspendLayout();
            // 
            // tbctrlSettings
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tbctrlSettings.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tbctrlSettings.ControlBox.MenuBox.Name = "";
            this.tbctrlSettings.ControlBox.Name = "";
            this.tbctrlSettings.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbctrlSettings.ControlBox.MenuBox,
            this.tbctrlSettings.ControlBox.CloseBox});
            this.tbctrlSettings.ControlBox.Visible = false;
            this.tbctrlSettings.Controls.Add(this.superTabControlPanel1);
            this.tbctrlSettings.Controls.Add(this.superTabControlPanel2);
            this.tbctrlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrlSettings.FixedTabSize = new System.Drawing.Size(150, 0);
            this.tbctrlSettings.Location = new System.Drawing.Point(0, 0);
            this.tbctrlSettings.Name = "tbctrlSettings";
            this.tbctrlSettings.ReorderTabsEnabled = true;
            this.tbctrlSettings.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbctrlSettings.SelectedTabIndex = 0;
            this.tbctrlSettings.Size = new System.Drawing.Size(558, 340);
            this.tbctrlSettings.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbctrlSettings.TabIndex = 0;
            this.tbctrlSettings.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbServers,
            this.tbCompanies});
            this.tbctrlSettings.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.tbctrlSettings.Text = "superTabControl1";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.grdCompanies);
            this.superTabControlPanel2.Controls.Add(this.bar2);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(558, 310);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tbCompanies;
            // 
            // grdCompanies
            // 
            this.grdCompanies.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdCompanies.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCompanies.Location = new System.Drawing.Point(0, 25);
            this.grdCompanies.Name = "grdCompanies";
            this.grdCompanies.Rows.DefaultSize = 21;
            this.grdCompanies.Size = new System.Drawing.Size(558, 285);
            this.grdCompanies.StyleInfo = resources.GetString("grdCompanies.StyleInfo");
            this.grdCompanies.TabIndex = 2;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveCompanies});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(558, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnSaveCompanies
            // 
            this.btnSaveCompanies.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCompanies.Image")));
            this.btnSaveCompanies.Name = "btnSaveCompanies";
            this.btnSaveCompanies.Text = "Save";
            this.btnSaveCompanies.Tooltip = "Save changes...";
            this.btnSaveCompanies.Click += new System.EventHandler(this.btnSaveCompanies_Click);
            // 
            // tbCompanies
            // 
            this.tbCompanies.AttachedControl = this.superTabControlPanel2;
            this.tbCompanies.GlobalItem = false;
            this.tbCompanies.Image = ((System.Drawing.Image)(resources.GetObject("tbCompanies.Image")));
            this.tbCompanies.Name = "tbCompanies";
            this.tbCompanies.Text = "Companies";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.grdServers);
            this.superTabControlPanel1.Controls.Add(this.bar1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(558, 310);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tbServers;
            // 
            // grdServers
            // 
            this.grdServers.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdServers.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdServers.Location = new System.Drawing.Point(0, 25);
            this.grdServers.Name = "grdServers";
            this.grdServers.Rows.DefaultSize = 21;
            this.grdServers.Size = new System.Drawing.Size(558, 285);
            this.grdServers.StyleInfo = resources.GetString("grdServers.StyleInfo");
            this.grdServers.TabIndex = 1;
            this.grdServers.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdServers_CellButtonClick);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveServers});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(558, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnSaveServers
            // 
            this.btnSaveServers.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveServers.Image")));
            this.btnSaveServers.Name = "btnSaveServers";
            this.btnSaveServers.Text = "Save";
            this.btnSaveServers.Tooltip = "Save changes...";
            this.btnSaveServers.Click += new System.EventHandler(this.btnSaveServers_Click);
            // 
            // tbServers
            // 
            this.tbServers.AttachedControl = this.superTabControlPanel1;
            this.tbServers.GlobalItem = false;
            this.tbServers.Image = ((System.Drawing.Image)(resources.GetObject("tbServers.Image")));
            this.tbServers.Name = "tbServers";
            this.tbServers.Text = "Servers";
            // 
            // bar3
            // 
            this.bar3.AntiAlias = true;
            this.bar3.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar3.Location = new System.Drawing.Point(0, 340);
            this.bar3.Name = "bar3";
            this.bar3.RoundCorners = false;
            this.bar3.Size = new System.Drawing.Size(558, 25);
            this.bar3.Stretch = true;
            this.bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar3.TabIndex = 1;
            this.bar3.TabStop = false;
            // 
            // ConnectionsAndCompaniesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(558, 365);
            this.Controls.Add(this.tbctrlSettings);
            this.Controls.Add(this.bar3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectionsAndCompaniesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Settings";
            this.Load += new System.EventHandler(this.ConnectionsAndCompaniesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbctrlSettings)).EndInit();
            this.tbctrlSettings.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl tbctrlSettings;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tbServers;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnSaveServers;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnSaveCompanies;
        private DevComponents.DotNetBar.SuperTabItem tbCompanies;
        private C1.Win.C1FlexGrid.C1FlexGrid grdServers;
        private C1.Win.C1FlexGrid.C1FlexGrid grdCompanies;
        private DevComponents.DotNetBar.Bar bar3;
    }
}