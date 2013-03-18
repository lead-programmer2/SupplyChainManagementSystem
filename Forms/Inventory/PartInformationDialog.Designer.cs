namespace SupplyChainManagementSystem
{
    partial class PartInformationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartInformationDialog));
            this.brToolbar = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbctrl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.cboType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.cboStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCategory = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAddUom = new System.Windows.Forms.LinkLabel();
            this.cboUom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAddModel = new System.Windows.Forms.LinkLabel();
            this.cboModel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddBrand = new System.Windows.Forms.LinkLabel();
            this.cboBrand = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPartName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblAddPartName = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGeneral = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.btnAddAlternative = new System.Windows.Forms.Button();
            this.grdAlternative = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbAlternative = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtNotes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grdMisc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbMiscellaneous = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtReorderQty = new DevComponents.Editors.IntegerInput();
            this.label16 = new System.Windows.Forms.Label();
            this.txtReorderPoint = new DevComponents.Editors.IntegerInput();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEnding = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label14 = new System.Windows.Forms.Label();
            this.lblViewOutgoing = new System.Windows.Forms.LinkLabel();
            this.txtOutgoing = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label13 = new System.Windows.Forms.Label();
            this.lblViewIncoming = new System.Windows.Forms.LinkLabel();
            this.txtIncoming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAdjustment = new System.Windows.Forms.LinkLabel();
            this.txtQty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.tbInventory = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdLocations = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbLocations = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdLedger = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbLedger = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).BeginInit();
            this.brToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).BeginInit();
            this.tbctrl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlternative)).BeginInit();
            this.superTabControlPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMisc)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderPoint)).BeginInit();
            this.superTabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocations)).BeginInit();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // brToolbar
            // 
            this.brToolbar.AntiAlias = true;
            this.brToolbar.Controls.Add(this.txtSearch);
            this.brToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.brToolbar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brToolbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveShortcut,
            this.labelItem1,
            this.controlContainerItem1});
            this.brToolbar.Location = new System.Drawing.Point(0, 0);
            this.brToolbar.Name = "brToolbar";
            this.brToolbar.RoundCorners = false;
            this.brToolbar.Size = new System.Drawing.Size(697, 27);
            this.brToolbar.Stretch = true;
            this.brToolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brToolbar.TabIndex = 0;
            this.brToolbar.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(545, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 22);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "<i>Search</i>";
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
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
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAndClose.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAndClose.Location = new System.Drawing.Point(381, 407);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 10;
            this.btnSaveAndClose.Text = "Sa&ve and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(588, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(496, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbctrl);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 359);
            this.panel1.TabIndex = 9;
            // 
            // tbctrl
            // 
            this.tbctrl.AutoCloseTabs = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tbctrl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tbctrl.ControlBox.MenuBox.Name = "";
            this.tbctrl.ControlBox.Name = "";
            this.tbctrl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbctrl.ControlBox.MenuBox,
            this.tbctrl.ControlBox.CloseBox});
            this.tbctrl.ControlBox.Visible = false;
            this.tbctrl.Controls.Add(this.superTabControlPanel2);
            this.tbctrl.Controls.Add(this.superTabControlPanel1);
            this.tbctrl.Controls.Add(this.superTabControlPanel3);
            this.tbctrl.Controls.Add(this.superTabControlPanel6);
            this.tbctrl.Controls.Add(this.superTabControlPanel4);
            this.tbctrl.Controls.Add(this.superTabControlPanel5);
            this.tbctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrl.FixedTabSize = new System.Drawing.Size(150, 0);
            this.tbctrl.Location = new System.Drawing.Point(0, 0);
            this.tbctrl.Name = "tbctrl";
            this.tbctrl.ReorderTabsEnabled = false;
            this.tbctrl.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbctrl.SelectedTabIndex = 0;
            this.tbctrl.Size = new System.Drawing.Size(671, 357);
            this.tbctrl.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tbctrl.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbctrl.TabIndex = 0;
            this.tbctrl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbGeneral,
            this.tbInventory,
            this.tbAlternative,
            this.tbLocations,
            this.tbLedger,
            this.tbMiscellaneous});
            this.tbctrl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tbctrl.Text = "superTabControl1";
            this.tbctrl.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tbctrl_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.AutoScroll = true;
            this.superTabControlPanel1.Controls.Add(this.cboType);
            this.superTabControlPanel1.Controls.Add(this.label10);
            this.superTabControlPanel1.Controls.Add(this.cboStatus);
            this.superTabControlPanel1.Controls.Add(this.label9);
            this.superTabControlPanel1.Controls.Add(this.cboCountry);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.txtCategory);
            this.superTabControlPanel1.Controls.Add(this.label7);
            this.superTabControlPanel1.Controls.Add(this.lblAddUom);
            this.superTabControlPanel1.Controls.Add(this.cboUom);
            this.superTabControlPanel1.Controls.Add(this.label6);
            this.superTabControlPanel1.Controls.Add(this.lblAddModel);
            this.superTabControlPanel1.Controls.Add(this.cboModel);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.lblAddBrand);
            this.superTabControlPanel1.Controls.Add(this.cboBrand);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.txtDescription);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.cboPartName);
            this.superTabControlPanel1.Controls.Add(this.lblAddPartName);
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Controls.Add(this.txtPartNo);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(519, 357);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tbGeneral;
            // 
            // cboType
            // 
            this.cboType.DisplayMember = "Text";
            this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType.FormattingEnabled = true;
            this.cboType.ItemHeight = 16;
            this.cboType.Location = new System.Drawing.Point(277, 309);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(210, 22);
            this.cboType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(274, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Type";
            // 
            // cboStatus
            // 
            this.cboStatus.DisplayMember = "Text";
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 16;
            this.cboStatus.Location = new System.Drawing.Point(29, 309);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(210, 22);
            this.cboStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboStatus.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(26, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Status";
            // 
            // cboCountry
            // 
            this.cboCountry.DisplayMember = "Text";
            this.cboCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.ItemHeight = 16;
            this.cboCountry.Location = new System.Drawing.Point(277, 258);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(210, 22);
            this.cboCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCountry.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(274, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Country of Origin";
            // 
            // txtCategory
            // 
            // 
            // 
            // 
            this.txtCategory.Border.Class = "TextBoxBorder";
            this.txtCategory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCategory.Location = new System.Drawing.Point(277, 93);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(210, 22);
            this.txtCategory.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(274, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Category";
            // 
            // lblAddUom
            // 
            this.lblAddUom.AutoSize = true;
            this.lblAddUom.BackColor = System.Drawing.Color.Transparent;
            this.lblAddUom.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddUom.Location = new System.Drawing.Point(101, 242);
            this.lblAddUom.Name = "lblAddUom";
            this.lblAddUom.Size = new System.Drawing.Size(138, 13);
            this.lblAddUom.TabIndex = 40;
            this.lblAddUom.TabStop = true;
            this.lblAddUom.Text = "Add unit of measurement";
            this.lblAddUom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddUom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddUom_LinkClicked);
            // 
            // cboUom
            // 
            this.cboUom.DisplayMember = "Text";
            this.cboUom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUom.FormattingEnabled = true;
            this.cboUom.ItemHeight = 16;
            this.cboUom.Location = new System.Drawing.Point(29, 258);
            this.cboUom.Name = "cboUom";
            this.cboUom.Size = new System.Drawing.Size(210, 22);
            this.cboUom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboUom.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(26, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Unit";
            // 
            // lblAddModel
            // 
            this.lblAddModel.AutoSize = true;
            this.lblAddModel.BackColor = System.Drawing.Color.Transparent;
            this.lblAddModel.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddModel.Location = new System.Drawing.Point(420, 186);
            this.lblAddModel.Name = "lblAddModel";
            this.lblAddModel.Size = new System.Drawing.Size(63, 13);
            this.lblAddModel.TabIndex = 37;
            this.lblAddModel.TabStop = true;
            this.lblAddModel.Text = "Add model";
            this.lblAddModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddModel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddModel_LinkClicked);
            // 
            // cboModel
            // 
            this.cboModel.DisplayMember = "Text";
            this.cboModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.ItemHeight = 16;
            this.cboModel.Location = new System.Drawing.Point(277, 202);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(210, 22);
            this.cboModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(274, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Model";
            // 
            // lblAddBrand
            // 
            this.lblAddBrand.AutoSize = true;
            this.lblAddBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblAddBrand.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddBrand.Location = new System.Drawing.Point(177, 186);
            this.lblAddBrand.Name = "lblAddBrand";
            this.lblAddBrand.Size = new System.Drawing.Size(62, 13);
            this.lblAddBrand.TabIndex = 34;
            this.lblAddBrand.TabStop = true;
            this.lblAddBrand.Text = "Add brand";
            this.lblAddBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddBrand.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddBrand_LinkClicked);
            // 
            // cboBrand
            // 
            this.cboBrand.DisplayMember = "Text";
            this.cboBrand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.ItemHeight = 16;
            this.cboBrand.Location = new System.Drawing.Point(29, 202);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(210, 22);
            this.cboBrand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBrand.TabIndex = 4;
            this.cboBrand.SelectedValueChanged += new System.EventHandler(this.cboBrand_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(26, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Brand";
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.Location = new System.Drawing.Point(29, 147);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(458, 22);
            this.txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(26, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Description";
            // 
            // cboPartName
            // 
            this.cboPartName.DisplayMember = "Text";
            this.cboPartName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPartName.FormattingEnabled = true;
            this.cboPartName.ItemHeight = 16;
            this.cboPartName.Location = new System.Drawing.Point(29, 93);
            this.cboPartName.Name = "cboPartName";
            this.cboPartName.Size = new System.Drawing.Size(210, 22);
            this.cboPartName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPartName.TabIndex = 1;
            this.cboPartName.SelectedValueChanged += new System.EventHandler(this.cboPartName_SelectedValueChanged);
            // 
            // lblAddPartName
            // 
            this.lblAddPartName.AutoSize = true;
            this.lblAddPartName.BackColor = System.Drawing.Color.Transparent;
            this.lblAddPartName.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddPartName.Location = new System.Drawing.Point(156, 77);
            this.lblAddPartName.Name = "lblAddPartName";
            this.lblAddPartName.Size = new System.Drawing.Size(83, 13);
            this.lblAddPartName.TabIndex = 28;
            this.lblAddPartName.TabStop = true;
            this.lblAddPartName.Text = "Add part name";
            this.lblAddPartName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddPartName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddPartName_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(26, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Part Name";
            // 
            // txtPartNo
            // 
            // 
            // 
            // 
            this.txtPartNo.Border.Class = "TextBoxBorder";
            this.txtPartNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPartNo.Location = new System.Drawing.Point(29, 41);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(139, 22);
            this.txtPartNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Part No.";
            // 
            // tbGeneral
            // 
            this.tbGeneral.AttachedControl = this.superTabControlPanel1;
            this.tbGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbGeneral.GlobalItem = false;
            this.tbGeneral.Image = ((System.Drawing.Image)(resources.GetObject("tbGeneral.Image")));
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Text = "General Information";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.btnAddAlternative);
            this.superTabControlPanel3.Controls.Add(this.grdAlternative);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(519, 357);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tbAlternative;
            // 
            // btnAddAlternative
            // 
            this.btnAddAlternative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAlternative.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddAlternative.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAlternative.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAddAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAlternative.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAlternative.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddAlternative.Location = new System.Drawing.Point(11, 323);
            this.btnAddAlternative.Name = "btnAddAlternative";
            this.btnAddAlternative.Size = new System.Drawing.Size(143, 22);
            this.btnAddAlternative.TabIndex = 11;
            this.btnAddAlternative.Text = "&Add Supersession";
            this.btnAddAlternative.UseVisualStyleBackColor = false;
            // 
            // grdAlternative
            // 
            this.grdAlternative.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAlternative.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdAlternative.Location = new System.Drawing.Point(3, 3);
            this.grdAlternative.Name = "grdAlternative";
            this.grdAlternative.Rows.DefaultSize = 21;
            this.grdAlternative.Size = new System.Drawing.Size(513, 307);
            this.grdAlternative.StyleInfo = resources.GetString("grdAlternative.StyleInfo");
            this.grdAlternative.TabIndex = 0;
            // 
            // tbAlternative
            // 
            this.tbAlternative.AttachedControl = this.superTabControlPanel3;
            this.tbAlternative.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbAlternative.GlobalItem = false;
            this.tbAlternative.Image = ((System.Drawing.Image)(resources.GetObject("tbAlternative.Image")));
            this.tbAlternative.Name = "tbAlternative";
            this.tbAlternative.Text = "Parts Supersession";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.txtNotes);
            this.superTabControlPanel6.Controls.Add(this.grdMisc);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(519, 357);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.tbMiscellaneous;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtNotes.Border.Class = "TextBoxBorder";
            this.txtNotes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNotes.Location = new System.Drawing.Point(3, 143);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(513, 211);
            this.txtNotes.TabIndex = 2;
            this.txtNotes.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtNotes.WatermarkText = "<i>Notes</i>";
            // 
            // grdMisc
            // 
            this.grdMisc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMisc.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdMisc.Location = new System.Drawing.Point(3, 3);
            this.grdMisc.Name = "grdMisc";
            this.grdMisc.Rows.DefaultSize = 21;
            this.grdMisc.Size = new System.Drawing.Size(513, 137);
            this.grdMisc.StyleInfo = resources.GetString("grdMisc.StyleInfo");
            this.grdMisc.TabIndex = 1;
            // 
            // tbMiscellaneous
            // 
            this.tbMiscellaneous.AttachedControl = this.superTabControlPanel6;
            this.tbMiscellaneous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbMiscellaneous.GlobalItem = false;
            this.tbMiscellaneous.Image = ((System.Drawing.Image)(resources.GetObject("tbMiscellaneous.Image")));
            this.tbMiscellaneous.Name = "tbMiscellaneous";
            this.tbMiscellaneous.Text = "Miscellaneous";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.txtReorderQty);
            this.superTabControlPanel2.Controls.Add(this.label16);
            this.superTabControlPanel2.Controls.Add(this.txtReorderPoint);
            this.superTabControlPanel2.Controls.Add(this.label15);
            this.superTabControlPanel2.Controls.Add(this.txtEnding);
            this.superTabControlPanel2.Controls.Add(this.label14);
            this.superTabControlPanel2.Controls.Add(this.lblViewOutgoing);
            this.superTabControlPanel2.Controls.Add(this.txtOutgoing);
            this.superTabControlPanel2.Controls.Add(this.label13);
            this.superTabControlPanel2.Controls.Add(this.lblViewIncoming);
            this.superTabControlPanel2.Controls.Add(this.txtIncoming);
            this.superTabControlPanel2.Controls.Add(this.label12);
            this.superTabControlPanel2.Controls.Add(this.lblAdjustment);
            this.superTabControlPanel2.Controls.Add(this.txtQty);
            this.superTabControlPanel2.Controls.Add(this.label11);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(519, 357);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tbInventory;
            // 
            // txtReorderQty
            // 
            // 
            // 
            // 
            this.txtReorderQty.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtReorderQty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReorderQty.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtReorderQty.Location = new System.Drawing.Point(168, 294);
            this.txtReorderQty.Name = "txtReorderQty";
            this.txtReorderQty.ShowUpDown = true;
            this.txtReorderQty.Size = new System.Drawing.Size(104, 22);
            this.txtReorderQty.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(165, 278);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Reorder Quantity";
            // 
            // txtReorderPoint
            // 
            // 
            // 
            // 
            this.txtReorderPoint.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtReorderPoint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReorderPoint.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtReorderPoint.Location = new System.Drawing.Point(34, 294);
            this.txtReorderPoint.Name = "txtReorderPoint";
            this.txtReorderPoint.ShowUpDown = true;
            this.txtReorderPoint.Size = new System.Drawing.Size(104, 22);
            this.txtReorderPoint.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(31, 278);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Reorder Point";
            // 
            // txtEnding
            // 
            // 
            // 
            // 
            this.txtEnding.Border.Class = "TextBoxBorder";
            this.txtEnding.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEnding.Location = new System.Drawing.Point(34, 216);
            this.txtEnding.Name = "txtEnding";
            this.txtEnding.Size = new System.Drawing.Size(104, 22);
            this.txtEnding.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(31, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Ending Balance";
            // 
            // lblViewOutgoing
            // 
            this.lblViewOutgoing.AutoSize = true;
            this.lblViewOutgoing.BackColor = System.Drawing.Color.Transparent;
            this.lblViewOutgoing.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblViewOutgoing.Location = new System.Drawing.Point(156, 164);
            this.lblViewOutgoing.Name = "lblViewOutgoing";
            this.lblViewOutgoing.Size = new System.Drawing.Size(116, 13);
            this.lblViewOutgoing.TabIndex = 35;
            this.lblViewOutgoing.TabStop = true;
            this.lblViewOutgoing.Text = "View Outgoing Items";
            this.lblViewOutgoing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOutgoing
            // 
            // 
            // 
            // 
            this.txtOutgoing.Border.Class = "TextBoxBorder";
            this.txtOutgoing.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOutgoing.Location = new System.Drawing.Point(34, 159);
            this.txtOutgoing.Name = "txtOutgoing";
            this.txtOutgoing.Size = new System.Drawing.Size(104, 22);
            this.txtOutgoing.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(31, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Outgoing";
            // 
            // lblViewIncoming
            // 
            this.lblViewIncoming.AutoSize = true;
            this.lblViewIncoming.BackColor = System.Drawing.Color.Transparent;
            this.lblViewIncoming.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblViewIncoming.Location = new System.Drawing.Point(156, 107);
            this.lblViewIncoming.Name = "lblViewIncoming";
            this.lblViewIncoming.Size = new System.Drawing.Size(113, 13);
            this.lblViewIncoming.TabIndex = 32;
            this.lblViewIncoming.TabStop = true;
            this.lblViewIncoming.Text = "View Incoming Items";
            this.lblViewIncoming.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIncoming
            // 
            // 
            // 
            // 
            this.txtIncoming.Border.Class = "TextBoxBorder";
            this.txtIncoming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIncoming.Location = new System.Drawing.Point(34, 102);
            this.txtIncoming.Name = "txtIncoming";
            this.txtIncoming.Size = new System.Drawing.Size(104, 22);
            this.txtIncoming.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(31, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Incoming";
            // 
            // lblAdjustment
            // 
            this.lblAdjustment.AutoSize = true;
            this.lblAdjustment.BackColor = System.Drawing.Color.Transparent;
            this.lblAdjustment.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAdjustment.Location = new System.Drawing.Point(157, 53);
            this.lblAdjustment.Name = "lblAdjustment";
            this.lblAdjustment.Size = new System.Drawing.Size(88, 13);
            this.lblAdjustment.TabIndex = 29;
            this.lblAdjustment.TabStop = true;
            this.lblAdjustment.Text = "Adjust Quantity";
            this.lblAdjustment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdjustment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdjustment_LinkClicked);
            // 
            // txtQty
            // 
            // 
            // 
            // 
            this.txtQty.Border.Class = "TextBoxBorder";
            this.txtQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQty.Location = new System.Drawing.Point(34, 48);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(104, 22);
            this.txtQty.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(31, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Quantity";
            // 
            // tbInventory
            // 
            this.tbInventory.AttachedControl = this.superTabControlPanel2;
            this.tbInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbInventory.GlobalItem = false;
            this.tbInventory.Image = ((System.Drawing.Image)(resources.GetObject("tbInventory.Image")));
            this.tbInventory.Name = "tbInventory";
            this.tbInventory.Text = "Inventory";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.grdLocations);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(519, 357);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.tbLocations;
            // 
            // grdLocations
            // 
            this.grdLocations.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLocations.Location = new System.Drawing.Point(0, 0);
            this.grdLocations.Name = "grdLocations";
            this.grdLocations.Rows.DefaultSize = 21;
            this.grdLocations.Size = new System.Drawing.Size(519, 357);
            this.grdLocations.StyleInfo = resources.GetString("grdLocations.StyleInfo");
            this.grdLocations.TabIndex = 1;
            // 
            // tbLocations
            // 
            this.tbLocations.AttachedControl = this.superTabControlPanel4;
            this.tbLocations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbLocations.GlobalItem = false;
            this.tbLocations.Image = ((System.Drawing.Image)(resources.GetObject("tbLocations.Image")));
            this.tbLocations.Name = "tbLocations";
            this.tbLocations.Text = "Locations";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.grdLedger);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(519, 357);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.tbLedger;
            // 
            // grdLedger
            // 
            this.grdLedger.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLedger.Location = new System.Drawing.Point(0, 0);
            this.grdLedger.Name = "grdLedger";
            this.grdLedger.Rows.DefaultSize = 21;
            this.grdLedger.Size = new System.Drawing.Size(519, 357);
            this.grdLedger.StyleInfo = resources.GetString("grdLedger.StyleInfo");
            this.grdLedger.TabIndex = 2;
            // 
            // tbLedger
            // 
            this.tbLedger.AttachedControl = this.superTabControlPanel5;
            this.tbLedger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbLedger.GlobalItem = false;
            this.tbLedger.Image = ((System.Drawing.Image)(resources.GetObject("tbLedger.Image")));
            this.tbLedger.Name = "tbLedger";
            this.tbLedger.Text = "Stock Ledger";
            // 
            // PartInformationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(697, 448);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.brToolbar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PartInformationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Part Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartInformationDialog_FormClosing);
            this.Load += new System.EventHandler(this.PartInformationDialog_Load);
            this.Shown += new System.EventHandler(this.PartInformationDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).EndInit();
            this.brToolbar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).EndInit();
            this.tbctrl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlternative)).EndInit();
            this.superTabControlPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMisc)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderPoint)).EndInit();
            this.superTabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLocations)).EndInit();
            this.superTabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLedger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar brToolbar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonItem btnSaveShortcut;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.SuperTabControl tbctrl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tbGeneral;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPartNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel lblAddUom;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lblAddModel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblAddBrand;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBrand;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPartName;
        private System.Windows.Forms.LinkLabel lblAddPartName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCountry;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboStatus;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tbInventory;
        private DevComponents.Editors.IntegerInput txtReorderQty;
        private System.Windows.Forms.Label label16;
        private DevComponents.Editors.IntegerInput txtReorderPoint;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEnding;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel lblViewOutgoing;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOutgoing;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel lblViewIncoming;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIncoming;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel lblAdjustment;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQty;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private System.Windows.Forms.Button btnAddAlternative;
        private C1.Win.C1FlexGrid.C1FlexGrid grdAlternative;
        private DevComponents.DotNetBar.SuperTabItem tbAlternative;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private C1.Win.C1FlexGrid.C1FlexGrid grdLocations;
        private DevComponents.DotNetBar.SuperTabItem tbLocations;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private C1.Win.C1FlexGrid.C1FlexGrid grdLedger;
        private DevComponents.DotNetBar.SuperTabItem tbLedger;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel6;
        private DevComponents.DotNetBar.SuperTabItem tbMiscellaneous;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNotes;
        private C1.Win.C1FlexGrid.C1FlexGrid grdMisc;
    }
}