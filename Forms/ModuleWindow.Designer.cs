namespace SupplyChainManagementSystem
{
    partial class ModuleWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleWindow));
            this._barmanager = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this._sidebar = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer1 = new DevComponents.DotNetBar.PanelDockContainer();
            this.trvwModules = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this._dockcontainer = new DevComponents.DotNetBar.DockContainerItem();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this._toolbar = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnNew = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintPreview = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnExportExcel = new DevComponents.DotNetBar.ButtonItem();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            this.btnExport = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.grdRecords = new C1.Win.C1FlexGrid.C1FlexGrid();
            this._images16 = new System.Windows.Forms.ImageList(this.components);
            this._images32 = new System.Windows.Forms.ImageList(this.components);
            this.lstvwRecords = new SupplyChainManagementSystem.ListViewGrid();
            this.dockSite1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._sidebar)).BeginInit();
            this._sidebar.SuspendLayout();
            this.panelDockContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvwModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._toolbar)).BeginInit();
            this._toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstvwRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // _barmanager
            // 
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this._barmanager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this._barmanager.BottomDockSite = this.dockSite4;
            this._barmanager.EnableFullSizeDock = false;
            this._barmanager.LeftDockSite = this.dockSite1;
            this._barmanager.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this._barmanager.ParentForm = this;
            this._barmanager.RightDockSite = this.dockSite2;
            this._barmanager.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._barmanager.ToolbarBottomDockSite = this.dockSite8;
            this._barmanager.ToolbarLeftDockSite = this.dockSite5;
            this._barmanager.ToolbarRightDockSite = this.dockSite6;
            this._barmanager.ToolbarTopDockSite = this.dockSite7;
            this._barmanager.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 481);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(906, 0);
            this.dockSite4.TabIndex = 3;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Controls.Add(this._sidebar);
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this._sidebar, 243, 481)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(246, 481);
            this.dockSite1.TabIndex = 0;
            this.dockSite1.TabStop = false;
            // 
            // _sidebar
            // 
            this._sidebar.AccessibleDescription = "DotNetBar Bar (_sidebar)";
            this._sidebar.AccessibleName = "DotNetBar Bar";
            this._sidebar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this._sidebar.AutoSyncBarCaption = true;
            this._sidebar.CanCustomize = false;
            this._sidebar.CanDockBottom = false;
            this._sidebar.CanDockLeft = false;
            this._sidebar.CanDockRight = false;
            this._sidebar.CanDockTab = false;
            this._sidebar.CanDockTop = false;
            this._sidebar.CanUndock = false;
            this._sidebar.CloseSingleTab = true;
            this._sidebar.Controls.Add(this.panelDockContainer1);
            this._sidebar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sidebar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this._sidebar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this._dockcontainer});
            this._sidebar.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this._sidebar.Location = new System.Drawing.Point(0, 0);
            this._sidebar.Name = "_sidebar";
            this._sidebar.Size = new System.Drawing.Size(243, 481);
            this._sidebar.Stretch = true;
            this._sidebar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._sidebar.TabIndex = 0;
            this._sidebar.TabStop = false;
            this._sidebar.Text = "Modules";
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDockContainer1.Controls.Add(this.trvwModules);
            this.panelDockContainer1.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(237, 455);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            // 
            // trvwModules
            // 
            this.trvwModules.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.trvwModules.AllowDrop = true;
            this.trvwModules.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.trvwModules.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.trvwModules.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.trvwModules.BackgroundStyle.Class = "TreeBorderKey";
            this.trvwModules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.trvwModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvwModules.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.trvwModules.Location = new System.Drawing.Point(0, 0);
            this.trvwModules.Name = "trvwModules";
            this.trvwModules.NodesConnector = this.nodeConnector1;
            this.trvwModules.NodeStyle = this.elementStyle1;
            this.trvwModules.PathSeparator = ";";
            this.trvwModules.Size = new System.Drawing.Size(237, 455);
            this.trvwModules.Styles.Add(this.elementStyle1);
            this.trvwModules.TabIndex = 0;
            this.trvwModules.Text = "advTree1";
            this.trvwModules.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.trvwModules_AfterNodeSelect);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // _dockcontainer
            // 
            this._dockcontainer.Control = this.panelDockContainer1;
            this._dockcontainer.Name = "_dockcontainer";
            this._dockcontainer.Text = "Modules";
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(906, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 481);
            this.dockSite2.TabIndex = 1;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 481);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(906, 0);
            this.dockSite8.TabIndex = 7;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 481);
            this.dockSite5.TabIndex = 4;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(906, 0);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 481);
            this.dockSite6.TabIndex = 5;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(906, 0);
            this.dockSite7.TabIndex = 6;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(906, 0);
            this.dockSite3.TabIndex = 2;
            this.dockSite3.TabStop = false;
            // 
            // _toolbar
            // 
            this._toolbar.AntiAlias = true;
            this._toolbar.Controls.Add(this.txtSearch);
            this._toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this._toolbar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._toolbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnPrintPreview,
            this.btnPrint,
            this.btnExportExcel,
            this.btnImport,
            this.btnExport,
            this.labelItem1,
            this.controlContainerItem1});
            this._toolbar.Location = new System.Drawing.Point(246, 0);
            this._toolbar.Name = "_toolbar";
            this._toolbar.RoundCorners = false;
            this._toolbar.Size = new System.Drawing.Size(660, 27);
            this._toolbar.Stretch = true;
            this._toolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._toolbar.TabIndex = 8;
            this._toolbar.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(505, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(152, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "<i>Search</i>";
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Name = "btnNew";
            this.btnNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN);
            this.btnNew.Tooltip = "Create a new transaction.";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnEdit.Tooltip = "Update the selected transaction\'s information.";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Tooltip = "Deletes the selected transaction.";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Tooltip = "Reloads the current list.";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BeginGroup = true;
            this.btnPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.Image")));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlR);
            this.btnPrintPreview.Tooltip = "View printable template that supports the selected transaction or list.";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.btnPrint.Tooltip = "Prints a document that supports the selected transaction or list.";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BeginGroup = true;
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnExportExcel.Tooltip = "Exports the current list into a Microsoft Excel worksheet.";
            // 
            // btnImport
            // 
            this.btnImport.BeginGroup = true;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Name = "btnImport";
            this.btnImport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnImport.Tooltip = "Imports a file that contains information relative to the current displayed list.";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Name = "btnExport";
            this.btnExport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.btnExport.Tooltip = "Exports the selected transaction\'s information into a file.";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Stretch = true;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.txtSearch;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // grdRecords
            // 
            this.grdRecords.BackColor = System.Drawing.Color.Transparent;
            this.grdRecords.BackgroundImage = global::SupplyChainManagementSystem.Properties.Resources.SCMSFaded;
            this.grdRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grdRecords.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecords.Location = new System.Drawing.Point(246, 27);
            this.grdRecords.Name = "grdRecords";
            this.grdRecords.Rows.DefaultSize = 21;
            this.grdRecords.Size = new System.Drawing.Size(660, 454);
            this.grdRecords.StyleInfo = resources.GetString("grdRecords.StyleInfo");
            this.grdRecords.TabIndex = 9;
            this.grdRecords.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdRecords_MouseDoubleClick);
            // 
            // _images16
            // 
            this._images16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_images16.ImageStream")));
            this._images16.TransparentColor = System.Drawing.Color.Transparent;
            this._images16.Images.SetKeyName(0, "SCMS");
            this._images16.Images.SetKeyName(1, "100");
            this._images16.Images.SetKeyName(2, "1000");
            this._images16.Images.SetKeyName(3, "1100");
            this._images16.Images.SetKeyName(4, "1200");
            this._images16.Images.SetKeyName(5, "200");
            this._images16.Images.SetKeyName(6, "2000");
            this._images16.Images.SetKeyName(7, "2100");
            this._images16.Images.SetKeyName(8, "2200");
            this._images16.Images.SetKeyName(9, "2300");
            this._images16.Images.SetKeyName(10, "300");
            this._images16.Images.SetKeyName(11, "3000");
            this._images16.Images.SetKeyName(12, "3100");
            this._images16.Images.SetKeyName(13, "3200");
            this._images16.Images.SetKeyName(14, "400");
            this._images16.Images.SetKeyName(15, "4000");
            this._images16.Images.SetKeyName(16, "500");
            this._images16.Images.SetKeyName(17, "5000");
            this._images16.Images.SetKeyName(18, "5100");
            this._images16.Images.SetKeyName(19, "5200");
            this._images16.Images.SetKeyName(20, "5300");
            this._images16.Images.SetKeyName(21, "5400");
            this._images16.Images.SetKeyName(22, "600");
            this._images16.Images.SetKeyName(23, "6000");
            this._images16.Images.SetKeyName(24, "6100");
            this._images16.Images.SetKeyName(25, "6200");
            this._images16.Images.SetKeyName(26, "6300");
            this._images16.Images.SetKeyName(27, "6400");
            this._images16.Images.SetKeyName(28, "700");
            this._images16.Images.SetKeyName(29, "7000");
            this._images16.Images.SetKeyName(30, "7100");
            this._images16.Images.SetKeyName(31, "7200");
            this._images16.Images.SetKeyName(32, "7300");
            this._images16.Images.SetKeyName(33, "7400");
            this._images16.Images.SetKeyName(34, "7401");
            this._images16.Images.SetKeyName(35, "7402");
            this._images16.Images.SetKeyName(36, "7500");
            this._images16.Images.SetKeyName(37, "7600");
            this._images16.Images.SetKeyName(38, "800");
            this._images16.Images.SetKeyName(39, "8000");
            this._images16.Images.SetKeyName(40, "900");
            this._images16.Images.SetKeyName(41, "9000");
            this._images16.Images.SetKeyName(42, "9100");
            this._images16.Images.SetKeyName(43, "9200");
            this._images16.Images.SetKeyName(44, "9300");
            this._images16.Images.SetKeyName(45, "9400");
            this._images16.Images.SetKeyName(46, "9500");
            this._images16.Images.SetKeyName(47, "9600");
            this._images16.Images.SetKeyName(48, "10000");
            this._images16.Images.SetKeyName(49, "10100");
            this._images16.Images.SetKeyName(50, "10200");
            this._images16.Images.SetKeyName(51, "10300");
            this._images16.Images.SetKeyName(52, "10400");
            this._images16.Images.SetKeyName(53, "10500");
            this._images16.Images.SetKeyName(54, "10600");
            this._images16.Images.SetKeyName(55, "10700");
            this._images16.Images.SetKeyName(56, "10800");
            this._images16.Images.SetKeyName(57, "11000");
            this._images16.Images.SetKeyName(58, "11100");
            this._images16.Images.SetKeyName(59, "11200");
            this._images16.Images.SetKeyName(60, "11300");
            this._images16.Images.SetKeyName(61, "11400");
            this._images16.Images.SetKeyName(62, "11500");
            this._images16.Images.SetKeyName(63, "11600");
            this._images16.Images.SetKeyName(64, "11700");
            this._images16.Images.SetKeyName(65, "12000");
            this._images16.Images.SetKeyName(66, "12100");
            this._images16.Images.SetKeyName(67, "12200");
            this._images16.Images.SetKeyName(68, "12300");
            this._images16.Images.SetKeyName(69, "12400");
            this._images16.Images.SetKeyName(70, "12500");
            this._images16.Images.SetKeyName(71, "12600");
            this._images16.Images.SetKeyName(72, "12700");
            this._images16.Images.SetKeyName(73, "12800");
            this._images16.Images.SetKeyName(74, "12900");
            // 
            // _images32
            // 
            this._images32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_images32.ImageStream")));
            this._images32.TransparentColor = System.Drawing.Color.Transparent;
            this._images32.Images.SetKeyName(0, "SCMS");
            this._images32.Images.SetKeyName(1, "100");
            this._images32.Images.SetKeyName(2, "1000");
            this._images32.Images.SetKeyName(3, "1100");
            this._images32.Images.SetKeyName(4, "1200");
            this._images32.Images.SetKeyName(5, "200");
            this._images32.Images.SetKeyName(6, "2000");
            this._images32.Images.SetKeyName(7, "2100");
            this._images32.Images.SetKeyName(8, "2200");
            this._images32.Images.SetKeyName(9, "2300");
            this._images32.Images.SetKeyName(10, "300");
            this._images32.Images.SetKeyName(11, "3000");
            this._images32.Images.SetKeyName(12, "3100");
            this._images32.Images.SetKeyName(13, "3200");
            this._images32.Images.SetKeyName(14, "400");
            this._images32.Images.SetKeyName(15, "4000");
            this._images32.Images.SetKeyName(16, "500");
            this._images32.Images.SetKeyName(17, "5000");
            this._images32.Images.SetKeyName(18, "5100");
            this._images32.Images.SetKeyName(19, "5200");
            this._images32.Images.SetKeyName(20, "5300");
            this._images32.Images.SetKeyName(21, "5400");
            this._images32.Images.SetKeyName(22, "600");
            this._images32.Images.SetKeyName(23, "6000");
            this._images32.Images.SetKeyName(24, "6100");
            this._images32.Images.SetKeyName(25, "6200");
            this._images32.Images.SetKeyName(26, "6300");
            this._images32.Images.SetKeyName(27, "6400");
            this._images32.Images.SetKeyName(28, "700");
            this._images32.Images.SetKeyName(29, "7000");
            this._images32.Images.SetKeyName(30, "7100");
            this._images32.Images.SetKeyName(31, "7200");
            this._images32.Images.SetKeyName(32, "7300");
            this._images32.Images.SetKeyName(33, "7400");
            this._images32.Images.SetKeyName(34, "7401");
            this._images32.Images.SetKeyName(35, "7402");
            this._images32.Images.SetKeyName(36, "7500");
            this._images32.Images.SetKeyName(37, "7600");
            this._images32.Images.SetKeyName(38, "800");
            this._images32.Images.SetKeyName(39, "8000");
            this._images32.Images.SetKeyName(40, "900");
            this._images32.Images.SetKeyName(41, "9000");
            this._images32.Images.SetKeyName(42, "9100");
            this._images32.Images.SetKeyName(43, "9200");
            this._images32.Images.SetKeyName(44, "9300");
            this._images32.Images.SetKeyName(45, "9400");
            this._images32.Images.SetKeyName(46, "9500");
            this._images32.Images.SetKeyName(47, "9600");
            this._images32.Images.SetKeyName(48, "10000");
            this._images32.Images.SetKeyName(49, "10100");
            this._images32.Images.SetKeyName(50, "10200");
            this._images32.Images.SetKeyName(51, "10300");
            this._images32.Images.SetKeyName(52, "10400");
            this._images32.Images.SetKeyName(53, "10500");
            this._images32.Images.SetKeyName(54, "10600");
            this._images32.Images.SetKeyName(55, "10700");
            this._images32.Images.SetKeyName(56, "10800");
            this._images32.Images.SetKeyName(57, "11000");
            this._images32.Images.SetKeyName(58, "11100");
            this._images32.Images.SetKeyName(59, "11200");
            this._images32.Images.SetKeyName(60, "11300");
            this._images32.Images.SetKeyName(61, "11400");
            this._images32.Images.SetKeyName(62, "11500");
            this._images32.Images.SetKeyName(63, "11600");
            this._images32.Images.SetKeyName(64, "11700");
            this._images32.Images.SetKeyName(65, "12000");
            this._images32.Images.SetKeyName(66, "12100");
            this._images32.Images.SetKeyName(67, "12200");
            this._images32.Images.SetKeyName(68, "12300");
            this._images32.Images.SetKeyName(69, "12400");
            this._images32.Images.SetKeyName(70, "12500");
            this._images32.Images.SetKeyName(71, "12600");
            this._images32.Images.SetKeyName(72, "12700");
            this._images32.Images.SetKeyName(73, "12800");
            this._images32.Images.SetKeyName(74, "12900");
            // 
            // lstvwRecords
            // 
            this.lstvwRecords.AllowEditing = false;
            this.lstvwRecords.BackgroundImage = global::SupplyChainManagementSystem.Properties.Resources.SCMSFaded;
            this.lstvwRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lstvwRecords.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.lstvwRecords.ColumnInfo = "1,1,0,0,0,105,Columns:0{Width:0;}\t";
            this.lstvwRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvwRecords.ImageList = null;
            this.lstvwRecords.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this.lstvwRecords.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this.lstvwRecords.Location = new System.Drawing.Point(246, 27);
            this.lstvwRecords.Name = "lstvwRecords";
            this.lstvwRecords.Rows.Count = 1;
            this.lstvwRecords.Rows.DefaultSize = 21;
            this.lstvwRecords.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.lstvwRecords.Size = new System.Drawing.Size(660, 454);
            this.lstvwRecords.StyleInfo = resources.GetString("lstvwRecords.StyleInfo");
            this.lstvwRecords.TabIndex = 10;
            this.lstvwRecords.ListViewItemDoubleClick += new SupplyChainManagementSystem.ListViewGridSelectionEventHandler(this.lstvwRecords_ListViewItemDoubleClick);
            this.lstvwRecords.ListViewItemEnterKeyPressed += new SupplyChainManagementSystem.ListViewGridSelectionEventHandler(this.lstvwRecords_ListViewItemEnterKeyPressed);
            // 
            // ModuleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 481);
            this.Controls.Add(this.lstvwRecords);
            this.Controls.Add(this.grdRecords);
            this.Controls.Add(this._toolbar);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suppliy Chain Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuleWindow_FormClosing);
            this.Load += new System.EventHandler(this.ModuleWindow_Load);
            this.Shown += new System.EventHandler(this.ModuleWindow_Shown);
            this.dockSite1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._sidebar)).EndInit();
            this._sidebar.ResumeLayout(false);
            this.panelDockContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trvwModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._toolbar)).EndInit();
            this._toolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstvwRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.DotNetBarManager _barmanager;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.Bar _sidebar;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer1;
        private DevComponents.AdvTree.AdvTree trvwModules;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.DockContainerItem _dockcontainer;
        private DevComponents.DotNetBar.Bar _toolbar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonItem btnNew;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnPrintPreview;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem btnExportExcel;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private DevComponents.DotNetBar.ButtonItem btnExport;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private C1.Win.C1FlexGrid.C1FlexGrid grdRecords;
        private System.Windows.Forms.ImageList _images16;
        private System.Windows.Forms.ImageList _images32;
        private ListViewGrid lstvwRecords;
    }
}