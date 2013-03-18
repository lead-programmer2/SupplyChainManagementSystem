namespace SupplyChainManagementSystem
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.brStatus = new DevComponents.DotNetBar.Bar();
            this.btnStatus = new DevComponents.DotNetBar.ButtonItem();
            this.btnCursor = new DevComponents.DotNetBar.ButtonItem();
            this.btnCompany = new DevComponents.DotNetBar.ButtonItem();
            this.btnUser = new DevComponents.DotNetBar.ButtonItem();
            this.btnConnection = new DevComponents.DotNetBar.ButtonItem();
            this.btnCaps = new DevComponents.DotNetBar.ButtonItem();
            this.btnNum = new DevComponents.DotNetBar.ButtonItem();
            this.btnScrl = new DevComponents.DotNetBar.ButtonItem();
            this.btnDate = new DevComponents.DotNetBar.ButtonItem();
            this.btnTime = new DevComponents.DotNetBar.ButtonItem();
            this.brMenu = new DevComponents.DotNetBar.Bar();
            this.mnuFile = new DevComponents.DotNetBar.ButtonItem();
            this.mnuBackUp = new DevComponents.DotNetBar.ButtonItem();
            this.mnuRestoreDatabase = new DevComponents.DotNetBar.ButtonItem();
            this.mnuGlobalSettings = new DevComponents.DotNetBar.ButtonItem();
            this.mnuLogout = new DevComponents.DotNetBar.ButtonItem();
            this.mnuLock = new DevComponents.DotNetBar.ButtonItem();
            this.mnuExit = new DevComponents.DotNetBar.ButtonItem();
            this.mnuEdit = new DevComponents.DotNetBar.ButtonItem();
            this.mnuUserManagement = new DevComponents.DotNetBar.ButtonItem();
            this.mnuDepartments = new DevComponents.DotNetBar.ButtonItem();
            this.mnuPositions = new DevComponents.DotNetBar.ButtonItem();
            this.mnuFinancePicklist = new DevComponents.DotNetBar.ButtonItem();
            this.mnuAdditionalCharges = new DevComponents.DotNetBar.ButtonItem();
            this.mnuBankMisc = new DevComponents.DotNetBar.ButtonItem();
            this.mnuBankingCompanies = new DevComponents.DotNetBar.ButtonItem();
            this.mnuCurrencies = new DevComponents.DotNetBar.ButtonItem();
            this.mnuCurrencyDenominations = new DevComponents.DotNetBar.ButtonItem();
            this.mnuCustomerGroups = new DevComponents.DotNetBar.ButtonItem();
            this.mnuPaymentTerms = new DevComponents.DotNetBar.ButtonItem();
            this.mnuSignatories = new DevComponents.DotNetBar.ButtonItem();
            this.mnuOperationsPicklist = new DevComponents.DotNetBar.ButtonItem();
            this.mnuBrands = new DevComponents.DotNetBar.ButtonItem();
            this.mnuLocations = new DevComponents.DotNetBar.ButtonItem();
            this.mnuMeasurements = new DevComponents.DotNetBar.ButtonItem();
            this.mnuModels = new DevComponents.DotNetBar.ButtonItem();
            this.mnuPartNames = new DevComponents.DotNetBar.ButtonItem();
            this.mnuPartsCategory = new DevComponents.DotNetBar.ButtonItem();
            this.mnuTools = new DevComponents.DotNetBar.ButtonItem();
            this.mnuDatabaseTools = new DevComponents.DotNetBar.ButtonItem();
            this.mnuBackup2 = new DevComponents.DotNetBar.ButtonItem();
            this.mnuRestoreDatabase2 = new DevComponents.DotNetBar.ButtonItem();
            this.mnuMaintainDatabase = new DevComponents.DotNetBar.ButtonItem();
            this.mnuScripts = new DevComponents.DotNetBar.ButtonItem();
            this.mnuScriptList = new DevComponents.DotNetBar.ButtonItem();
            this.mnuExecuteScripts = new DevComponents.DotNetBar.ButtonItem();
            this.mnuLogActivityViewer = new DevComponents.DotNetBar.ButtonItem();
            this.mnuReports = new DevComponents.DotNetBar.ButtonItem();
            this.mnuHelp = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblCompanyAddress = new DevComponents.DotNetBar.LabelX();
            this.lblCompanyName = new DevComponents.DotNetBar.LabelX();
            this.pctCompanyLogo = new System.Windows.Forms.PictureBox();
            this.brModules = new DevComponents.DotNetBar.Bar();
            this.btnModule = new DevComponents.DotNetBar.ButtonItem();
            this._moduleimages = new System.Windows.Forms.ImageList(this.components);
            this.rbnctrl = new DevComponents.DotNetBar.RibbonControl();
            this.mnuStockAdjustments = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.brStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brMenu)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCompanyLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brModules)).BeginInit();
            this.SuspendLayout();
            // 
            // brStatus
            // 
            this.brStatus.AntiAlias = true;
            this.brStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.brStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnStatus,
            this.btnCursor,
            this.btnCompany,
            this.btnUser,
            this.btnConnection,
            this.btnCaps,
            this.btnNum,
            this.btnScrl,
            this.btnDate,
            this.btnTime});
            this.brStatus.Location = new System.Drawing.Point(5, 715);
            this.brStatus.Name = "brStatus";
            this.brStatus.RoundCorners = false;
            this.brStatus.Size = new System.Drawing.Size(1129, 25);
            this.brStatus.Stretch = true;
            this.brStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brStatus.TabIndex = 1;
            this.brStatus.TabStop = false;
            // 
            // btnStatus
            // 
            this.btnStatus.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnStatus.FixedSize = new System.Drawing.Size(220, 21);
            this.btnStatus.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnStatus.Image")));
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Text = " Ready";
            // 
            // btnCursor
            // 
            this.btnCursor.BeginGroup = true;
            this.btnCursor.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCursor.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Stretch = true;
            // 
            // btnCompany
            // 
            this.btnCompany.BeginGroup = true;
            this.btnCompany.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCompany.FixedSize = new System.Drawing.Size(150, 21);
            this.btnCompany.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnCompany.Image = ((System.Drawing.Image)(resources.GetObject("btnCompany.Image")));
            this.btnCompany.Name = "btnCompany";
            // 
            // btnUser
            // 
            this.btnUser.BeginGroup = true;
            this.btnUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUser.FixedSize = new System.Drawing.Size(200, 21);
            this.btnUser.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.Name = "btnUser";
            // 
            // btnConnection
            // 
            this.btnConnection.BeginGroup = true;
            this.btnConnection.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnConnection.FixedSize = new System.Drawing.Size(250, 21);
            this.btnConnection.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnConnection.Image")));
            this.btnConnection.Name = "btnConnection";
            // 
            // btnCaps
            // 
            this.btnCaps.BeginGroup = true;
            this.btnCaps.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnCaps.Name = "btnCaps";
            this.btnCaps.Text = "CAPS";
            // 
            // btnNum
            // 
            this.btnNum.BeginGroup = true;
            this.btnNum.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnNum.Name = "btnNum";
            this.btnNum.Text = "NUM";
            // 
            // btnScrl
            // 
            this.btnScrl.BeginGroup = true;
            this.btnScrl.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnScrl.Name = "btnScrl";
            this.btnScrl.Text = "SCRL";
            // 
            // btnDate
            // 
            this.btnDate.BeginGroup = true;
            this.btnDate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDate.FixedSize = new System.Drawing.Size(100, 21);
            this.btnDate.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnDate.Image = ((System.Drawing.Image)(resources.GetObject("btnDate.Image")));
            this.btnDate.Name = "btnDate";
            // 
            // btnTime
            // 
            this.btnTime.BeginGroup = true;
            this.btnTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnTime.FixedSize = new System.Drawing.Size(100, 21);
            this.btnTime.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnTime.Image = ((System.Drawing.Image)(resources.GetObject("btnTime.Image")));
            this.btnTime.Name = "btnTime";
            // 
            // brMenu
            // 
            this.brMenu.AccessibleDescription = "DotNetBar Bar (brMenu)";
            this.brMenu.AccessibleName = "DotNetBar Bar";
            this.brMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.brMenu.AntiAlias = true;
            this.brMenu.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.brMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.brMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuTools,
            this.mnuReports,
            this.mnuHelp});
            this.brMenu.Location = new System.Drawing.Point(5, 31);
            this.brMenu.MenuBar = true;
            this.brMenu.Name = "brMenu";
            this.brMenu.RoundCorners = false;
            this.brMenu.Size = new System.Drawing.Size(1129, 24);
            this.brMenu.Stretch = true;
            this.brMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brMenu.TabIndex = 2;
            this.brMenu.TabStop = false;
            // 
            // mnuFile
            // 
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuBackUp,
            this.mnuRestoreDatabase,
            this.mnuGlobalSettings,
            this.mnuLogout,
            this.mnuLock,
            this.mnuExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuBackUp
            // 
            this.mnuBackUp.Image = ((System.Drawing.Image)(resources.GetObject("mnuBackUp.Image")));
            this.mnuBackUp.Name = "mnuBackUp";
            this.mnuBackUp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlB);
            this.mnuBackUp.Text = "&Backup Database";
            this.mnuBackUp.Click += new System.EventHandler(this.mnuBackUp_Click);
            // 
            // mnuRestoreDatabase
            // 
            this.mnuRestoreDatabase.Image = ((System.Drawing.Image)(resources.GetObject("mnuRestoreDatabase.Image")));
            this.mnuRestoreDatabase.Name = "mnuRestoreDatabase";
            this.mnuRestoreDatabase.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlR);
            this.mnuRestoreDatabase.Text = "&Restore Database";
            this.mnuRestoreDatabase.Click += new System.EventHandler(this.mnuRestoreDatabase_Click);
            // 
            // mnuGlobalSettings
            // 
            this.mnuGlobalSettings.BeginGroup = true;
            this.mnuGlobalSettings.Image = ((System.Drawing.Image)(resources.GetObject("mnuGlobalSettings.Image")));
            this.mnuGlobalSettings.Name = "mnuGlobalSettings";
            this.mnuGlobalSettings.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlG);
            this.mnuGlobalSettings.Text = "&Global Settings";
            this.mnuGlobalSettings.Click += new System.EventHandler(this.mnuGlobalSettings_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.BeginGroup = true;
            this.mnuLogout.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogout.Image")));
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlL);
            this.mnuLogout.Text = "&Log Out";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuLock
            // 
            this.mnuLock.Image = ((System.Drawing.Image)(resources.GetObject("mnuLock.Image")));
            this.mnuLock.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.mnuLock.Name = "mnuLock";
            this.mnuLock.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlK);
            this.mnuLock.Text = "Loc&k";
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuUserManagement,
            this.mnuDepartments,
            this.mnuPositions,
            this.mnuFinancePicklist,
            this.mnuOperationsPicklist});
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuUserManagement
            // 
            this.mnuUserManagement.Image = ((System.Drawing.Image)(resources.GetObject("mnuUserManagement.Image")));
            this.mnuUserManagement.Name = "mnuUserManagement";
            this.mnuUserManagement.Text = "&User Management";
            this.mnuUserManagement.Click += new System.EventHandler(this.mnuUserManagement_Click);
            // 
            // mnuDepartments
            // 
            this.mnuDepartments.BeginGroup = true;
            this.mnuDepartments.Image = ((System.Drawing.Image)(resources.GetObject("mnuDepartments.Image")));
            this.mnuDepartments.Name = "mnuDepartments";
            this.mnuDepartments.Text = "&Departments";
            // 
            // mnuPositions
            // 
            this.mnuPositions.Image = ((System.Drawing.Image)(resources.GetObject("mnuPositions.Image")));
            this.mnuPositions.Name = "mnuPositions";
            this.mnuPositions.Text = "&Positions";
            // 
            // mnuFinancePicklist
            // 
            this.mnuFinancePicklist.BeginGroup = true;
            this.mnuFinancePicklist.Image = ((System.Drawing.Image)(resources.GetObject("mnuFinancePicklist.Image")));
            this.mnuFinancePicklist.Name = "mnuFinancePicklist";
            this.mnuFinancePicklist.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuAdditionalCharges,
            this.mnuBankMisc,
            this.mnuBankingCompanies,
            this.mnuCurrencies,
            this.mnuCurrencyDenominations,
            this.mnuCustomerGroups,
            this.mnuPaymentTerms,
            this.mnuSignatories});
            this.mnuFinancePicklist.Text = "&Finance";
            // 
            // mnuAdditionalCharges
            // 
            this.mnuAdditionalCharges.BeginGroup = true;
            this.mnuAdditionalCharges.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdditionalCharges.Image")));
            this.mnuAdditionalCharges.Name = "mnuAdditionalCharges";
            this.mnuAdditionalCharges.Text = "&Additional Charges";
            // 
            // mnuBankMisc
            // 
            this.mnuBankMisc.Image = ((System.Drawing.Image)(resources.GetObject("mnuBankMisc.Image")));
            this.mnuBankMisc.Name = "mnuBankMisc";
            this.mnuBankMisc.Text = "Bank &Miscellaneous";
            // 
            // mnuBankingCompanies
            // 
            this.mnuBankingCompanies.Image = ((System.Drawing.Image)(resources.GetObject("mnuBankingCompanies.Image")));
            this.mnuBankingCompanies.Name = "mnuBankingCompanies";
            this.mnuBankingCompanies.Text = "&Banking Companies";
            // 
            // mnuCurrencies
            // 
            this.mnuCurrencies.Image = ((System.Drawing.Image)(resources.GetObject("mnuCurrencies.Image")));
            this.mnuCurrencies.Name = "mnuCurrencies";
            this.mnuCurrencies.Text = "&Currencies";
            // 
            // mnuCurrencyDenominations
            // 
            this.mnuCurrencyDenominations.Image = ((System.Drawing.Image)(resources.GetObject("mnuCurrencyDenominations.Image")));
            this.mnuCurrencyDenominations.Name = "mnuCurrencyDenominations";
            this.mnuCurrencyDenominations.Text = "Currency &Denominations";
            // 
            // mnuCustomerGroups
            // 
            this.mnuCustomerGroups.Image = ((System.Drawing.Image)(resources.GetObject("mnuCustomerGroups.Image")));
            this.mnuCustomerGroups.Name = "mnuCustomerGroups";
            this.mnuCustomerGroups.Text = "C&ustomer Groups";
            // 
            // mnuPaymentTerms
            // 
            this.mnuPaymentTerms.Image = ((System.Drawing.Image)(resources.GetObject("mnuPaymentTerms.Image")));
            this.mnuPaymentTerms.Name = "mnuPaymentTerms";
            this.mnuPaymentTerms.Text = "&Payment Terms";
            // 
            // mnuSignatories
            // 
            this.mnuSignatories.Image = ((System.Drawing.Image)(resources.GetObject("mnuSignatories.Image")));
            this.mnuSignatories.Name = "mnuSignatories";
            this.mnuSignatories.Text = "&Signatories";
            // 
            // mnuOperationsPicklist
            // 
            this.mnuOperationsPicklist.Image = ((System.Drawing.Image)(resources.GetObject("mnuOperationsPicklist.Image")));
            this.mnuOperationsPicklist.Name = "mnuOperationsPicklist";
            this.mnuOperationsPicklist.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuBrands,
            this.mnuLocations,
            this.mnuMeasurements,
            this.mnuModels,
            this.mnuPartNames,
            this.mnuPartsCategory});
            this.mnuOperationsPicklist.Text = "&Operations";
            // 
            // mnuBrands
            // 
            this.mnuBrands.Image = ((System.Drawing.Image)(resources.GetObject("mnuBrands.Image")));
            this.mnuBrands.Name = "mnuBrands";
            this.mnuBrands.Text = "&Brands";
            // 
            // mnuLocations
            // 
            this.mnuLocations.Image = ((System.Drawing.Image)(resources.GetObject("mnuLocations.Image")));
            this.mnuLocations.Name = "mnuLocations";
            this.mnuLocations.Text = "&Locations";
            // 
            // mnuMeasurements
            // 
            this.mnuMeasurements.Image = ((System.Drawing.Image)(resources.GetObject("mnuMeasurements.Image")));
            this.mnuMeasurements.Name = "mnuMeasurements";
            this.mnuMeasurements.Text = "M&easurements";
            // 
            // mnuModels
            // 
            this.mnuModels.Image = ((System.Drawing.Image)(resources.GetObject("mnuModels.Image")));
            this.mnuModels.Name = "mnuModels";
            this.mnuModels.Text = "M&odels";
            // 
            // mnuPartNames
            // 
            this.mnuPartNames.Image = ((System.Drawing.Image)(resources.GetObject("mnuPartNames.Image")));
            this.mnuPartNames.Name = "mnuPartNames";
            this.mnuPartNames.Text = "&Part Names";
            // 
            // mnuPartsCategory
            // 
            this.mnuPartsCategory.Image = ((System.Drawing.Image)(resources.GetObject("mnuPartsCategory.Image")));
            this.mnuPartsCategory.Name = "mnuPartsCategory";
            this.mnuPartsCategory.Text = "Parts &Category";
            // 
            // mnuTools
            // 
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuDatabaseTools,
            this.mnuScripts,
            this.mnuStockAdjustments,
            this.mnuLogActivityViewer});
            this.mnuTools.Text = "&Tools";
            // 
            // mnuDatabaseTools
            // 
            this.mnuDatabaseTools.Image = ((System.Drawing.Image)(resources.GetObject("mnuDatabaseTools.Image")));
            this.mnuDatabaseTools.Name = "mnuDatabaseTools";
            this.mnuDatabaseTools.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuBackup2,
            this.mnuRestoreDatabase2,
            this.mnuMaintainDatabase});
            this.mnuDatabaseTools.Text = "&Database";
            // 
            // mnuBackup2
            // 
            this.mnuBackup2.Image = ((System.Drawing.Image)(resources.GetObject("mnuBackup2.Image")));
            this.mnuBackup2.Name = "mnuBackup2";
            this.mnuBackup2.Text = "&Backup Database";
            this.mnuBackup2.Click += new System.EventHandler(this.mnuBackup2_Click);
            // 
            // mnuRestoreDatabase2
            // 
            this.mnuRestoreDatabase2.Image = ((System.Drawing.Image)(resources.GetObject("mnuRestoreDatabase2.Image")));
            this.mnuRestoreDatabase2.Name = "mnuRestoreDatabase2";
            this.mnuRestoreDatabase2.Text = "&Restore Database";
            this.mnuRestoreDatabase2.Click += new System.EventHandler(this.mnuRestoreDatabase2_Click);
            // 
            // mnuMaintainDatabase
            // 
            this.mnuMaintainDatabase.Image = ((System.Drawing.Image)(resources.GetObject("mnuMaintainDatabase.Image")));
            this.mnuMaintainDatabase.Name = "mnuMaintainDatabase";
            this.mnuMaintainDatabase.Text = "Database &Maintenance";
            this.mnuMaintainDatabase.Click += new System.EventHandler(this.mnuMaintainDatabase_Click);
            // 
            // mnuScripts
            // 
            this.mnuScripts.BeginGroup = true;
            this.mnuScripts.Image = ((System.Drawing.Image)(resources.GetObject("mnuScripts.Image")));
            this.mnuScripts.Name = "mnuScripts";
            this.mnuScripts.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mnuScriptList,
            this.mnuExecuteScripts});
            this.mnuScripts.Text = "&Scripts";
            // 
            // mnuScriptList
            // 
            this.mnuScriptList.Image = ((System.Drawing.Image)(resources.GetObject("mnuScriptList.Image")));
            this.mnuScriptList.Name = "mnuScriptList";
            this.mnuScriptList.Text = "Script &Management";
            this.mnuScriptList.Click += new System.EventHandler(this.mnuScriptList_Click);
            // 
            // mnuExecuteScripts
            // 
            this.mnuExecuteScripts.Image = ((System.Drawing.Image)(resources.GetObject("mnuExecuteScripts.Image")));
            this.mnuExecuteScripts.Name = "mnuExecuteScripts";
            this.mnuExecuteScripts.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.mnuExecuteScripts.Text = "E&xecute Script File";
            this.mnuExecuteScripts.Click += new System.EventHandler(this.mnuExecuteScripts_Click);
            // 
            // mnuLogActivityViewer
            // 
            this.mnuLogActivityViewer.BeginGroup = true;
            this.mnuLogActivityViewer.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogActivityViewer.Image")));
            this.mnuLogActivityViewer.Name = "mnuLogActivityViewer";
            this.mnuLogActivityViewer.Text = "&Log Activity Viewer";
            this.mnuLogActivityViewer.Click += new System.EventHandler(this.mnuLogActivityViewer_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Text = "&Reports";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Text = "&Help";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lblCompanyAddress);
            this.panelEx1.Controls.Add(this.lblCompanyName);
            this.panelEx1.Controls.Add(this.pctCompanyLogo);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(5, 55);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1129, 62);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // lblCompanyAddress
            // 
            this.lblCompanyAddress.AutoSize = true;
            // 
            // 
            // 
            this.lblCompanyAddress.BackgroundStyle.Class = "";
            this.lblCompanyAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCompanyAddress.Location = new System.Drawing.Point(132, 33);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(41, 17);
            this.lblCompanyAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblCompanyAddress.TabIndex = 3;
            this.lblCompanyAddress.Text = "Address";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            // 
            // 
            // 
            this.lblCompanyName.BackgroundStyle.Class = "";
            this.lblCompanyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(131, 7);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(70, 24);
            this.lblCompanyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "Company";
            // 
            // pctCompanyLogo
            // 
            this.pctCompanyLogo.Location = new System.Drawing.Point(7, 3);
            this.pctCompanyLogo.Name = "pctCompanyLogo";
            this.pctCompanyLogo.Size = new System.Drawing.Size(108, 55);
            this.pctCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCompanyLogo.TabIndex = 0;
            this.pctCompanyLogo.TabStop = false;
            // 
            // brModules
            // 
            this.brModules.AntiAlias = true;
            this.brModules.Dock = System.Windows.Forms.DockStyle.Top;
            this.brModules.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnModule});
            this.brModules.Location = new System.Drawing.Point(5, 117);
            this.brModules.Name = "brModules";
            this.brModules.RoundCorners = false;
            this.brModules.Size = new System.Drawing.Size(1129, 68);
            this.brModules.Stretch = true;
            this.brModules.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brModules.TabIndex = 6;
            this.brModules.TabStop = false;
            // 
            // btnModule
            // 
            this.btnModule.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnModule.FixedSize = new System.Drawing.Size(120, 65);
            this.btnModule.Image = ((System.Drawing.Image)(resources.GetObject("btnModule.Image")));
            this.btnModule.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnModule.Name = "btnModule";
            this.btnModule.Text = "Module Name";
            // 
            // _moduleimages
            // 
            this._moduleimages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_moduleimages.ImageStream")));
            this._moduleimages.TransparentColor = System.Drawing.Color.Transparent;
            this._moduleimages.Images.SetKeyName(0, "Quotations");
            this._moduleimages.Images.SetKeyName(1, "Orders");
            this._moduleimages.Images.SetKeyName(2, "Shipments");
            this._moduleimages.Images.SetKeyName(3, "Inventory");
            this._moduleimages.Images.SetKeyName(4, "Purchases");
            this._moduleimages.Images.SetKeyName(5, "Sales");
            this._moduleimages.Images.SetKeyName(6, "Finance");
            this._moduleimages.Images.SetKeyName(7, "GeneralLedger");
            this._moduleimages.Images.SetKeyName(8, "Customers");
            this._moduleimages.Images.SetKeyName(9, "Suppliers");
            this._moduleimages.Images.SetKeyName(10, "JournalEntries");
            this._moduleimages.Images.SetKeyName(11, "CashPosition");
            this._moduleimages.Images.SetKeyName(12, "Bank");
            this._moduleimages.Images.SetKeyName(13, "Operations");
            // 
            // rbnctrl
            // 
            // 
            // 
            // 
            this.rbnctrl.BackgroundStyle.Class = "";
            this.rbnctrl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbnctrl.CanCustomize = false;
            this.rbnctrl.CaptionVisible = true;
            this.rbnctrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbnctrl.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.rbnctrl.Location = new System.Drawing.Point(5, 1);
            this.rbnctrl.MdiSystemItemVisible = false;
            this.rbnctrl.Name = "rbnctrl";
            this.rbnctrl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.rbnctrl.Size = new System.Drawing.Size(1129, 30);
            this.rbnctrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbnctrl.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.rbnctrl.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.rbnctrl.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.rbnctrl.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.rbnctrl.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.rbnctrl.SystemText.QatDialogAddButton = "&Add >>";
            this.rbnctrl.SystemText.QatDialogCancelButton = "Cancel";
            this.rbnctrl.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.rbnctrl.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.rbnctrl.SystemText.QatDialogOkButton = "OK";
            this.rbnctrl.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.rbnctrl.SystemText.QatDialogRemoveButton = "&Remove";
            this.rbnctrl.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.rbnctrl.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.rbnctrl.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.rbnctrl.TabGroupHeight = 14;
            this.rbnctrl.TabIndex = 8;
            this.rbnctrl.Text = "ribbonControl1";
            // 
            // mnuStockAdjustments
            // 
            this.mnuStockAdjustments.BeginGroup = true;
            this.mnuStockAdjustments.Image = ((System.Drawing.Image)(resources.GetObject("mnuStockAdjustments.Image")));
            this.mnuStockAdjustments.Name = "mnuStockAdjustments";
            this.mnuStockAdjustments.Text = "Stock &Adjustments";
            this.mnuStockAdjustments.Click += new System.EventHandler(this.mnuStockAdjustments_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 742);
            this.Controls.Add(this.brStatus);
            this.Controls.Add(this.brModules);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.brMenu);
            this.Controls.Add(this.rbnctrl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Chain Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.brStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brMenu)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCompanyLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar brStatus;
        private DevComponents.DotNetBar.Bar brMenu;
        private DevComponents.DotNetBar.ButtonItem mnuFile;
        private DevComponents.DotNetBar.ButtonItem mnuEdit;
        private DevComponents.DotNetBar.ButtonItem mnuTools;
        private DevComponents.DotNetBar.ButtonItem mnuReports;
        private DevComponents.DotNetBar.ButtonItem mnuHelp;
        private DevComponents.DotNetBar.ButtonItem btnStatus;
        private DevComponents.DotNetBar.ButtonItem btnCursor;
        private DevComponents.DotNetBar.ButtonItem btnCompany;
        private DevComponents.DotNetBar.ButtonItem btnUser;
        private DevComponents.DotNetBar.ButtonItem btnConnection;
        private DevComponents.DotNetBar.ButtonItem btnDate;
        private DevComponents.DotNetBar.ButtonItem btnTime;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX lblCompanyAddress;
        private DevComponents.DotNetBar.LabelX lblCompanyName;
        private System.Windows.Forms.PictureBox pctCompanyLogo;
        private DevComponents.DotNetBar.Bar brModules;
        private DevComponents.DotNetBar.ButtonItem btnModule;
        private System.Windows.Forms.ImageList _moduleimages;
        private DevComponents.DotNetBar.ButtonItem mnuBackUp;
        private DevComponents.DotNetBar.ButtonItem mnuRestoreDatabase;
        private DevComponents.DotNetBar.ButtonItem mnuGlobalSettings;
        private DevComponents.DotNetBar.ButtonItem mnuLogout;
        private DevComponents.DotNetBar.ButtonItem mnuExit;
        private DevComponents.DotNetBar.ButtonItem mnuUserManagement;
        private DevComponents.DotNetBar.ButtonItem mnuDepartments;
        private DevComponents.DotNetBar.ButtonItem mnuPositions;
        private DevComponents.DotNetBar.ButtonItem mnuFinancePicklist;
        private DevComponents.DotNetBar.ButtonItem mnuAdditionalCharges;
        private DevComponents.DotNetBar.ButtonItem mnuOperationsPicklist;
        private DevComponents.DotNetBar.ButtonItem mnuBankingCompanies;
        private DevComponents.DotNetBar.ButtonItem mnuBankMisc;
        private DevComponents.DotNetBar.ButtonItem mnuCurrencies;
        private DevComponents.DotNetBar.ButtonItem mnuCurrencyDenominations;
        private DevComponents.DotNetBar.ButtonItem mnuCustomerGroups;
        private DevComponents.DotNetBar.ButtonItem mnuPaymentTerms;
        private DevComponents.DotNetBar.ButtonItem mnuSignatories;
        private DevComponents.DotNetBar.ButtonItem mnuBrands;
        private DevComponents.DotNetBar.ButtonItem mnuMeasurements;
        private DevComponents.DotNetBar.ButtonItem mnuModels;
        private DevComponents.DotNetBar.ButtonItem mnuPartNames;
        private DevComponents.DotNetBar.ButtonItem mnuPartsCategory;
        private DevComponents.DotNetBar.ButtonItem mnuLock;
        private DevComponents.DotNetBar.ButtonItem mnuLocations;
        private DevComponents.DotNetBar.ButtonItem btnCaps;
        private DevComponents.DotNetBar.ButtonItem btnNum;
        private DevComponents.DotNetBar.ButtonItem btnScrl;
        private DevComponents.DotNetBar.ButtonItem mnuDatabaseTools;
        private DevComponents.DotNetBar.ButtonItem mnuBackup2;
        private DevComponents.DotNetBar.ButtonItem mnuRestoreDatabase2;
        private DevComponents.DotNetBar.ButtonItem mnuMaintainDatabase;
        private DevComponents.DotNetBar.ButtonItem mnuLogActivityViewer;
        private DevComponents.DotNetBar.ButtonItem mnuScripts;
        private DevComponents.DotNetBar.ButtonItem mnuScriptList;
        private DevComponents.DotNetBar.ButtonItem mnuExecuteScripts;
        private DevComponents.DotNetBar.RibbonControl rbnctrl;
        private DevComponents.DotNetBar.ButtonItem mnuStockAdjustments;

    }
}