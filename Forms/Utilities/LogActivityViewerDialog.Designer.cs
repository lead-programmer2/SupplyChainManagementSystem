namespace SupplyChainManagementSystem
{
    partial class LogActivityViewerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogActivityViewerDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnInfo = new DevComponents.DotNetBar.ButtonItem();
            this._barmanager = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this._sidebar = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer1 = new DevComponents.DotNetBar.PanelDockContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.exppnlUsers = new DevComponents.DotNetBar.ExpandablePanel();
            this.grdUsers = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.exppnlActions = new DevComponents.DotNetBar.ExpandablePanel();
            this.grdActions = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.exppnlDateRanges = new DevComponents.DotNetBar.ExpandablePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDateTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this._containeritem = new DevComponents.DotNetBar.DockContainerItem();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnExportExcel = new DevComponents.DotNetBar.ButtonItem();
            this.btnExportXml = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.grdLogs = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            this._images = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.dockSite2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._sidebar)).BeginInit();
            this._sidebar.SuspendLayout();
            this.panelDockContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.exppnlUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            this.exppnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActions)).BeginInit();
            this.exppnlDateRanges.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.bar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnInfo});
            this.bar1.Location = new System.Drawing.Point(0, 467);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(933, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            // 
            // btnInfo
            // 
            this.btnInfo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnInfo.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Text = " Ready";
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
            this.dockSite4.Location = new System.Drawing.Point(0, 492);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(933, 0);
            this.dockSite4.TabIndex = 5;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 467);
            this.dockSite1.TabIndex = 2;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Controls.Add(this._sidebar);
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this._sidebar, 248, 467)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.dockSite2.Location = new System.Drawing.Point(682, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(251, 467);
            this.dockSite2.TabIndex = 3;
            this.dockSite2.TabStop = false;
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
            this._containeritem});
            this._sidebar.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this._sidebar.Location = new System.Drawing.Point(3, 0);
            this._sidebar.Name = "_sidebar";
            this._sidebar.Size = new System.Drawing.Size(248, 467);
            this._sidebar.Stretch = true;
            this._sidebar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._sidebar.TabIndex = 0;
            this._sidebar.TabStop = false;
            this._sidebar.Text = "Filter Options";
            this._sidebar.AutoHideChanged += new System.EventHandler(this._sidebar_AutoHideChanged);
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDockContainer1.Controls.Add(this.panel2);
            this.panelDockContainer1.Controls.Add(this.exppnlUsers);
            this.panelDockContainer1.Controls.Add(this.exppnlActions);
            this.panelDockContainer1.Controls.Add(this.exppnlDateRanges);
            this.panelDockContainer1.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(242, 441);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 50);
            this.panel2.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClear.Location = new System.Drawing.Point(129, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 22);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.Location = new System.Drawing.Point(15, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 22);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // exppnlUsers
            // 
            this.exppnlUsers.CanvasColor = System.Drawing.SystemColors.Control;
            this.exppnlUsers.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exppnlUsers.Controls.Add(this.grdUsers);
            this.exppnlUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.exppnlUsers.ExpandOnTitleClick = true;
            this.exppnlUsers.Location = new System.Drawing.Point(0, 52);
            this.exppnlUsers.Name = "exppnlUsers";
            this.exppnlUsers.Size = new System.Drawing.Size(242, 330);
            this.exppnlUsers.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exppnlUsers.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnlUsers.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnlUsers.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnlUsers.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exppnlUsers.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exppnlUsers.Style.GradientAngle = 90;
            this.exppnlUsers.TabIndex = 2;
            this.exppnlUsers.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnlUsers.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnlUsers.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnlUsers.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exppnlUsers.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exppnlUsers.TitleStyle.GradientAngle = 90;
            this.exppnlUsers.TitleText = "   System Users";
            // 
            // grdUsers
            // 
            this.grdUsers.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUsers.Location = new System.Drawing.Point(0, 26);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Rows.DefaultSize = 21;
            this.grdUsers.Size = new System.Drawing.Size(242, 304);
            this.grdUsers.StyleInfo = resources.GetString("grdUsers.StyleInfo");
            this.grdUsers.TabIndex = 4;
            this.grdUsers.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUsers_CellChecked);
            // 
            // exppnlActions
            // 
            this.exppnlActions.CanvasColor = System.Drawing.SystemColors.Control;
            this.exppnlActions.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exppnlActions.Controls.Add(this.grdActions);
            this.exppnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.exppnlActions.Expanded = false;
            this.exppnlActions.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 242, 332);
            this.exppnlActions.ExpandOnTitleClick = true;
            this.exppnlActions.Location = new System.Drawing.Point(0, 26);
            this.exppnlActions.Name = "exppnlActions";
            this.exppnlActions.Size = new System.Drawing.Size(242, 26);
            this.exppnlActions.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exppnlActions.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnlActions.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnlActions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnlActions.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exppnlActions.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exppnlActions.Style.GradientAngle = 90;
            this.exppnlActions.TabIndex = 1;
            this.exppnlActions.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnlActions.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnlActions.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnlActions.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exppnlActions.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exppnlActions.TitleStyle.GradientAngle = 90;
            this.exppnlActions.TitleText = "   User Actions";
            // 
            // grdActions
            // 
            this.grdActions.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActions.Location = new System.Drawing.Point(0, 26);
            this.grdActions.Name = "grdActions";
            this.grdActions.Rows.DefaultSize = 21;
            this.grdActions.Size = new System.Drawing.Size(242, 0);
            this.grdActions.StyleInfo = resources.GetString("grdActions.StyleInfo");
            this.grdActions.TabIndex = 3;
            this.grdActions.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdActions_CellChecked);
            // 
            // exppnlDateRanges
            // 
            this.exppnlDateRanges.CanvasColor = System.Drawing.SystemColors.Control;
            this.exppnlDateRanges.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exppnlDateRanges.Controls.Add(this.panel1);
            this.exppnlDateRanges.Dock = System.Windows.Forms.DockStyle.Top;
            this.exppnlDateRanges.Expanded = false;
            this.exppnlDateRanges.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 242, 330);
            this.exppnlDateRanges.ExpandOnTitleClick = true;
            this.exppnlDateRanges.Location = new System.Drawing.Point(0, 0);
            this.exppnlDateRanges.Name = "exppnlDateRanges";
            this.exppnlDateRanges.Size = new System.Drawing.Size(242, 26);
            this.exppnlDateRanges.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exppnlDateRanges.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnlDateRanges.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnlDateRanges.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnlDateRanges.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exppnlDateRanges.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exppnlDateRanges.Style.GradientAngle = 90;
            this.exppnlDateRanges.TabIndex = 0;
            this.exppnlDateRanges.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnlDateRanges.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnlDateRanges.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnlDateRanges.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exppnlDateRanges.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exppnlDateRanges.TitleStyle.GradientAngle = 90;
            this.exppnlDateRanges.TitleText = "   Date and Time";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 0);
            this.panel1.TabIndex = 1;
            // 
            // dtpDateTo
            // 
            // 
            // 
            // 
            this.dtpDateTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpDateTo.ButtonDropDown.Visible = true;
            this.dtpDateTo.IsPopupCalendarOpen = false;
            this.dtpDateTo.Location = new System.Drawing.Point(27, 83);
            // 
            // 
            // 
            this.dtpDateTo.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtpDateTo.MonthCalendar.BackgroundStyle.Class = "";
            this.dtpDateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateTo.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtpDateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateTo.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.dtpDateTo.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpDateTo.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpDateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpDateTo.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtpDateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateTo.MonthCalendar.TodayButtonVisible = true;
            this.dtpDateTo.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(191, 22);
            this.dtpDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpDateTo.TabIndex = 2;
            this.dtpDateTo.LockUpdateChanged += new System.EventHandler(this.dtpDateTo_LockUpdateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(24, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "To";
            // 
            // dtpDateFrom
            // 
            // 
            // 
            // 
            this.dtpDateFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpDateFrom.ButtonDropDown.Visible = true;
            this.dtpDateFrom.IsPopupCalendarOpen = false;
            this.dtpDateFrom.Location = new System.Drawing.Point(27, 36);
            // 
            // 
            // 
            this.dtpDateFrom.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtpDateFrom.MonthCalendar.BackgroundStyle.Class = "";
            this.dtpDateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateFrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtpDateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateFrom.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.dtpDateFrom.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpDateFrom.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpDateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpDateFrom.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtpDateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDateFrom.MonthCalendar.TodayButtonVisible = true;
            this.dtpDateFrom.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(191, 22);
            this.dtpDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpDateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "From";
            // 
            // _containeritem
            // 
            this._containeritem.Control = this.panelDockContainer1;
            this._containeritem.Name = "_containeritem";
            this._containeritem.Text = "Filter Options";
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 492);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(933, 0);
            this.dockSite8.TabIndex = 9;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 492);
            this.dockSite5.TabIndex = 6;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(933, 0);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 492);
            this.dockSite6.TabIndex = 7;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(933, 0);
            this.dockSite7.TabIndex = 8;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(933, 0);
            this.dockSite3.TabIndex = 4;
            this.dockSite3.TabStop = false;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Controls.Add(this.txtSearch);
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnExportExcel,
            this.btnExportXml,
            this.labelItem1,
            this.controlContainerItem1});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(682, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 10;
            this.bar2.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(522, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "<i>Search</i>";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Tooltip = "Export the current displayed list into a Microsoft Excel file.";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportXml
            // 
            this.btnExportXml.Image = ((System.Drawing.Image)(resources.GetObject("btnExportXml.Image")));
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Tooltip = "Export the current displayed list into an Extensive Markup Language (Xml) file.";
            this.btnExportXml.Click += new System.EventHandler(this.btnExportXml_Click);
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
            // grdLogs
            // 
            this.grdLogs.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogs.Location = new System.Drawing.Point(0, 27);
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.Rows.DefaultSize = 21;
            this.grdLogs.Size = new System.Drawing.Size(682, 440);
            this.grdLogs.StyleInfo = resources.GetString("grdLogs.StyleInfo");
            this.grdLogs.TabIndex = 11;
            // 
            // pctLoad
            // 
            this.pctLoad.BackColor = System.Drawing.Color.Transparent;
            this.pctLoad.ForeColor = System.Drawing.Color.Black;
            this.pctLoad.Image = ((System.Drawing.Image)(resources.GetObject("pctLoad.Image")));
            this.pctLoad.Location = new System.Drawing.Point(331, 234);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(102, 18);
            this.pctLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLoad.TabIndex = 21;
            this.pctLoad.TabStop = false;
            // 
            // _images
            // 
            this._images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_images.ImageStream")));
            this._images.TransparentColor = System.Drawing.Color.Transparent;
            this._images.Images.SetKeyName(0, "Add");
            this._images.Images.SetKeyName(1, "Edit");
            this._images.Images.SetKeyName(2, "Delete");
            this._images.Images.SetKeyName(3, "Preview Report");
            this._images.Images.SetKeyName(4, "Print Report");
            this._images.Images.SetKeyName(5, "Exports Excel");
            this._images.Images.SetKeyName(6, "Exports Pdf");
            this._images.Images.SetKeyName(7, "Exports Xml");
            this._images.Images.SetKeyName(8, "Exports EDI");
            this._images.Images.SetKeyName(9, "Imports Excel");
            this._images.Images.SetKeyName(10, "Imports EDI");
            this._images.Images.SetKeyName(11, "Imports Xml");
            this._images.Images.SetKeyName(12, "Backup Database");
            this._images.Images.SetKeyName(13, "Restore Database");
            this._images.Images.SetKeyName(14, "Maintain Database");
            this._images.Images.SetKeyName(15, "Log In");
            this._images.Images.SetKeyName(16, "Log Out");
            this._images.Images.SetKeyName(17, "Finalize Transaction");
            this._images.Images.SetKeyName(18, "System Generated");
            this._images.Images.SetKeyName(19, "Execute Script");
            // 
            // LogActivityViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 492);
            this.Controls.Add(this.pctLoad);
            this.Controls.Add(this.grdLogs);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.bar1);
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
            this.Name = "LogActivityViewerDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Activity Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogActivityViewerDialog_FormClosing);
            this.Load += new System.EventHandler(this.LogActivityViewerDialog_Load);
            this.Shown += new System.EventHandler(this.LogActivityViewerDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.dockSite2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._sidebar)).EndInit();
            this._sidebar.ResumeLayout(false);
            this.panelDockContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.exppnlUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            this.exppnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdActions)).EndInit();
            this.exppnlDateRanges.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.bar2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.DotNetBarManager _barmanager;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.Bar _sidebar;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer1;
        private DevComponents.DotNetBar.ExpandablePanel exppnlDateRanges;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.DockContainerItem _containeritem;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ExpandablePanel exppnlUsers;
        private C1.Win.C1FlexGrid.C1FlexGrid grdUsers;
        private DevComponents.DotNetBar.ExpandablePanel exppnlActions;
        private C1.Win.C1FlexGrid.C1FlexGrid grdActions;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpDateTo;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonItem btnExportExcel;
        private DevComponents.DotNetBar.ButtonItem btnExportXml;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private C1.Win.C1FlexGrid.C1FlexGrid grdLogs;
        private System.Windows.Forms.PictureBox pctLoad;
        private System.Windows.Forms.ImageList _images;
        private DevComponents.DotNetBar.ButtonItem btnInfo;
    }
}