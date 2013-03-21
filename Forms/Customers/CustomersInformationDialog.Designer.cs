namespace SupplyChainManagementSystem
{
    partial class CustomersInformationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersInformationDialog));
            this.brToolbar = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbctrl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.chkActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtPoc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMobile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFax = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddCustomerGroup = new System.Windows.Forms.LinkLabel();
            this.cboCustomerGroup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGeneral = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtNotes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grdMisc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbMisc = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdCustomerLedger = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbCustomerLedger = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdPayments = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbPayments = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdReceivables = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbReceivables = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.cboPaymentTerms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label18 = new System.Windows.Forms.Label();
            this.cboLocation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label17 = new System.Windows.Forms.Label();
            this.cboBankAccount = new SupplyChainManagementSystem.DataSourcedComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMarginPercent = new DevComponents.Editors.DoubleInput();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCreditLimit = new DevComponents.Editors.DoubleInput();
            this.label13 = new System.Windows.Forms.Label();
            this.cboPrepaymentAccount = new SupplyChainManagementSystem.DataSourcedComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboDebtorAccount = new SupplyChainManagementSystem.DataSourcedComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAccounts = new DevComponents.DotNetBar.SuperTabItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).BeginInit();
            this.brToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).BeginInit();
            this.tbctrl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMisc)).BeginInit();
            this.superTabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerLedger)).BeginInit();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).BeginInit();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceivables)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditLimit)).BeginInit();
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
            this.brToolbar.Size = new System.Drawing.Size(706, 27);
            this.brToolbar.Stretch = true;
            this.brToolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brToolbar.TabIndex = 1;
            this.brToolbar.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(554, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 22);
            this.txtSearch.TabIndex = 27;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbctrl);
            this.panel1.Location = new System.Drawing.Point(17, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 469);
            this.panel1.TabIndex = 2;
            // 
            // tbctrl
            // 
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
            this.tbctrl.Controls.Add(this.superTabControlPanel1);
            this.tbctrl.Controls.Add(this.superTabControlPanel6);
            this.tbctrl.Controls.Add(this.superTabControlPanel4);
            this.tbctrl.Controls.Add(this.superTabControlPanel5);
            this.tbctrl.Controls.Add(this.superTabControlPanel3);
            this.tbctrl.Controls.Add(this.superTabControlPanel2);
            this.tbctrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrl.FixedTabSize = new System.Drawing.Size(150, 0);
            this.tbctrl.Location = new System.Drawing.Point(0, 0);
            this.tbctrl.Name = "tbctrl";
            this.tbctrl.ReorderTabsEnabled = false;
            this.tbctrl.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbctrl.SelectedTabIndex = 0;
            this.tbctrl.Size = new System.Drawing.Size(669, 467);
            this.tbctrl.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tbctrl.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbctrl.TabIndex = 3;
            this.tbctrl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbGeneral,
            this.tbAccounts,
            this.tbReceivables,
            this.tbPayments,
            this.tbCustomerLedger,
            this.tbMisc});
            this.tbctrl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tbctrl.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tbctrl_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.AutoScroll = true;
            this.superTabControlPanel1.Controls.Add(this.chkActive);
            this.superTabControlPanel1.Controls.Add(this.txtPoc);
            this.superTabControlPanel1.Controls.Add(this.label10);
            this.superTabControlPanel1.Controls.Add(this.txtEmail);
            this.superTabControlPanel1.Controls.Add(this.label9);
            this.superTabControlPanel1.Controls.Add(this.txtMobile);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.txtFax);
            this.superTabControlPanel1.Controls.Add(this.label7);
            this.superTabControlPanel1.Controls.Add(this.txtPhone);
            this.superTabControlPanel1.Controls.Add(this.label6);
            this.superTabControlPanel1.Controls.Add(this.cboCountry);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.txtAddress);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.txtCustomerName);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.lblAddCustomerGroup);
            this.superTabControlPanel1.Controls.Add(this.cboCustomerGroup);
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Controls.Add(this.txtCustomerNo);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(517, 467);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tbGeneral;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            // 
            // 
            // 
            this.chkActive.BackgroundStyle.Class = "";
            this.chkActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkActive.Location = new System.Drawing.Point(404, 356);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(52, 17);
            this.chkActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "Active";
            // 
            // txtPoc
            // 
            // 
            // 
            // 
            this.txtPoc.Border.Class = "TextBoxBorder";
            this.txtPoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPoc.Location = new System.Drawing.Point(38, 351);
            this.txtPoc.Name = "txtPoc";
            this.txtPoc.Size = new System.Drawing.Size(199, 22);
            this.txtPoc.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(35, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Contact Person";
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.Location = new System.Drawing.Point(257, 300);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(199, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(254, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Email";
            // 
            // txtMobile
            // 
            // 
            // 
            // 
            this.txtMobile.Border.Class = "TextBoxBorder";
            this.txtMobile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMobile.Location = new System.Drawing.Point(38, 300);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(199, 22);
            this.txtMobile.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(35, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Mobile No.";
            // 
            // txtFax
            // 
            // 
            // 
            // 
            this.txtFax.Border.Class = "TextBoxBorder";
            this.txtFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFax.Location = new System.Drawing.Point(257, 251);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(199, 22);
            this.txtFax.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(254, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Fax";
            // 
            // txtPhone
            // 
            // 
            // 
            // 
            this.txtPhone.Border.Class = "TextBoxBorder";
            this.txtPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPhone.Location = new System.Drawing.Point(38, 251);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(199, 22);
            this.txtPhone.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(35, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Phone";
            // 
            // cboCountry
            // 
            this.cboCountry.DisplayMember = "Text";
            this.cboCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.ItemHeight = 16;
            this.cboCountry.Location = new System.Drawing.Point(38, 201);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(199, 22);
            this.cboCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCountry.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(35, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Country";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(38, 137);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(418, 39);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(35, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Address";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.Border.Class = "TextBoxBorder";
            this.txtCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerName.Location = new System.Drawing.Point(38, 91);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(418, 22);
            this.txtCustomerName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(35, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Customer Name";
            // 
            // lblAddCustomerGroup
            // 
            this.lblAddCustomerGroup.AutoSize = true;
            this.lblAddCustomerGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblAddCustomerGroup.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddCustomerGroup.Location = new System.Drawing.Point(343, 28);
            this.lblAddCustomerGroup.Name = "lblAddCustomerGroup";
            this.lblAddCustomerGroup.Size = new System.Drawing.Size(113, 13);
            this.lblAddCustomerGroup.TabIndex = 2;
            this.lblAddCustomerGroup.TabStop = true;
            this.lblAddCustomerGroup.Text = "Add customer group";
            this.lblAddCustomerGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCustomerGroup
            // 
            this.cboCustomerGroup.DisplayMember = "Text";
            this.cboCustomerGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCustomerGroup.FormattingEnabled = true;
            this.cboCustomerGroup.ItemHeight = 16;
            this.cboCustomerGroup.Location = new System.Drawing.Point(208, 44);
            this.cboCustomerGroup.Name = "cboCustomerGroup";
            this.cboCustomerGroup.Size = new System.Drawing.Size(248, 22);
            this.cboCustomerGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCustomerGroup.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(205, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Customer Group";
            // 
            // txtCustomerNo
            // 
            // 
            // 
            // 
            this.txtCustomerNo.Border.Class = "TextBoxBorder";
            this.txtCustomerNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerNo.Location = new System.Drawing.Point(38, 44);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Size = new System.Drawing.Size(131, 22);
            this.txtCustomerNo.TabIndex = 0;
            this.txtCustomerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Customer No.";
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
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.txtNotes);
            this.superTabControlPanel6.Controls.Add(this.grdMisc);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(517, 467);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.tbMisc;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtNotes.Border.Class = "TextBoxBorder";
            this.txtNotes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNotes.Location = new System.Drawing.Point(3, 161);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(511, 303);
            this.txtNotes.TabIndex = 23;
            this.txtNotes.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtNotes.WatermarkText = "<i>Notes</i>";
            // 
            // grdMisc
            // 
            this.grdMisc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMisc.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdMisc.Location = new System.Drawing.Point(3, 3);
            this.grdMisc.Name = "grdMisc";
            this.grdMisc.Rows.DefaultSize = 21;
            this.grdMisc.Size = new System.Drawing.Size(511, 154);
            this.grdMisc.StyleInfo = resources.GetString("grdMisc.StyleInfo");
            this.grdMisc.TabIndex = 22;
            // 
            // tbMisc
            // 
            this.tbMisc.AttachedControl = this.superTabControlPanel6;
            this.tbMisc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbMisc.GlobalItem = false;
            this.tbMisc.Image = ((System.Drawing.Image)(resources.GetObject("tbMisc.Image")));
            this.tbMisc.Name = "tbMisc";
            this.tbMisc.Text = "Miscellaneous";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.grdCustomerLedger);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(517, 467);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.tbCustomerLedger;
            // 
            // grdCustomerLedger
            // 
            this.grdCustomerLedger.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdCustomerLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomerLedger.Location = new System.Drawing.Point(0, 0);
            this.grdCustomerLedger.Name = "grdCustomerLedger";
            this.grdCustomerLedger.Rows.DefaultSize = 21;
            this.grdCustomerLedger.Size = new System.Drawing.Size(517, 467);
            this.grdCustomerLedger.StyleInfo = resources.GetString("grdCustomerLedger.StyleInfo");
            this.grdCustomerLedger.TabIndex = 21;
            // 
            // tbCustomerLedger
            // 
            this.tbCustomerLedger.AttachedControl = this.superTabControlPanel4;
            this.tbCustomerLedger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbCustomerLedger.GlobalItem = false;
            this.tbCustomerLedger.Image = ((System.Drawing.Image)(resources.GetObject("tbCustomerLedger.Image")));
            this.tbCustomerLedger.Name = "tbCustomerLedger";
            this.tbCustomerLedger.Text = "Customer Ledger";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.grdPayments);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(517, 467);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.tbPayments;
            // 
            // grdPayments
            // 
            this.grdPayments.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPayments.Location = new System.Drawing.Point(0, 0);
            this.grdPayments.Name = "grdPayments";
            this.grdPayments.Rows.DefaultSize = 21;
            this.grdPayments.Size = new System.Drawing.Size(517, 467);
            this.grdPayments.StyleInfo = resources.GetString("grdPayments.StyleInfo");
            this.grdPayments.TabIndex = 20;
            // 
            // tbPayments
            // 
            this.tbPayments.AttachedControl = this.superTabControlPanel5;
            this.tbPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPayments.GlobalItem = false;
            this.tbPayments.Image = ((System.Drawing.Image)(resources.GetObject("tbPayments.Image")));
            this.tbPayments.Name = "tbPayments";
            this.tbPayments.Text = "Payments";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.grdReceivables);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(517, 467);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tbReceivables;
            // 
            // grdReceivables
            // 
            this.grdReceivables.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdReceivables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReceivables.Location = new System.Drawing.Point(0, 0);
            this.grdReceivables.Name = "grdReceivables";
            this.grdReceivables.Rows.DefaultSize = 21;
            this.grdReceivables.Size = new System.Drawing.Size(517, 467);
            this.grdReceivables.StyleInfo = resources.GetString("grdReceivables.StyleInfo");
            this.grdReceivables.TabIndex = 19;
            // 
            // tbReceivables
            // 
            this.tbReceivables.AttachedControl = this.superTabControlPanel3;
            this.tbReceivables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbReceivables.GlobalItem = false;
            this.tbReceivables.Image = ((System.Drawing.Image)(resources.GetObject("tbReceivables.Image")));
            this.tbReceivables.Name = "tbReceivables";
            this.tbReceivables.Text = "Receivables";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.cboPaymentTerms);
            this.superTabControlPanel2.Controls.Add(this.label18);
            this.superTabControlPanel2.Controls.Add(this.cboLocation);
            this.superTabControlPanel2.Controls.Add(this.label17);
            this.superTabControlPanel2.Controls.Add(this.cboBankAccount);
            this.superTabControlPanel2.Controls.Add(this.label16);
            this.superTabControlPanel2.Controls.Add(this.label15);
            this.superTabControlPanel2.Controls.Add(this.txtMarginPercent);
            this.superTabControlPanel2.Controls.Add(this.label14);
            this.superTabControlPanel2.Controls.Add(this.txtCreditLimit);
            this.superTabControlPanel2.Controls.Add(this.label13);
            this.superTabControlPanel2.Controls.Add(this.cboPrepaymentAccount);
            this.superTabControlPanel2.Controls.Add(this.label12);
            this.superTabControlPanel2.Controls.Add(this.cboDebtorAccount);
            this.superTabControlPanel2.Controls.Add(this.label11);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(517, 467);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tbAccounts;
            // 
            // cboPaymentTerms
            // 
            this.cboPaymentTerms.DisplayMember = "Text";
            this.cboPaymentTerms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaymentTerms.FormattingEnabled = true;
            this.cboPaymentTerms.ItemHeight = 16;
            this.cboPaymentTerms.Location = new System.Drawing.Point(33, 168);
            this.cboPaymentTerms.Name = "cboPaymentTerms";
            this.cboPaymentTerms.Size = new System.Drawing.Size(128, 22);
            this.cboPaymentTerms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPaymentTerms.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(30, 152);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Payment Terms";
            // 
            // cboLocation
            // 
            this.cboLocation.DisplayMember = "Text";
            this.cboLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.ItemHeight = 16;
            this.cboLocation.Location = new System.Drawing.Point(33, 272);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(286, 22);
            this.cboLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLocation.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(30, 256);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Default Receiving Location";
            // 
            // cboBankAccount
            // 
            this.cboBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.cboBankAccount.Border.Class = "TextBoxBorder";
            this.cboBankAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboBankAccount.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboBankAccount.ButtonCustom.Image")));
            this.cboBankAccount.ButtonCustom.Visible = true;
            this.cboBankAccount.DataSource = null;
            this.cboBankAccount.DisplayMember = "";
            this.cboBankAccount.Location = new System.Drawing.Point(33, 220);
            this.cboBankAccount.Name = "cboBankAccount";
            this.cboBankAccount.SelectedIndex = -1;
            this.cboBankAccount.SelectedValue = null;
            this.cboBankAccount.Size = new System.Drawing.Size(286, 22);
            this.cboBankAccount.TabIndex = 17;
            this.cboBankAccount.ValueMember = "";
            this.cboBankAccount.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(30, 204);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Default Bank Account for Payments";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(30, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(295, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "________________________________________________";
            // 
            // txtMarginPercent
            // 
            // 
            // 
            // 
            this.txtMarginPercent.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMarginPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMarginPercent.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMarginPercent.Increment = 1D;
            this.txtMarginPercent.Location = new System.Drawing.Point(191, 98);
            this.txtMarginPercent.Name = "txtMarginPercent";
            this.txtMarginPercent.ShowUpDown = true;
            this.txtMarginPercent.Size = new System.Drawing.Size(128, 22);
            this.txtMarginPercent.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(188, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Margin Percentage";
            // 
            // txtCreditLimit
            // 
            // 
            // 
            // 
            this.txtCreditLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCreditLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCreditLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCreditLimit.Increment = 1D;
            this.txtCreditLimit.Location = new System.Drawing.Point(33, 98);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.ShowUpDown = true;
            this.txtCreditLimit.Size = new System.Drawing.Size(128, 22);
            this.txtCreditLimit.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(30, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Credit Limit";
            // 
            // cboPrepaymentAccount
            // 
            this.cboPrepaymentAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPrepaymentAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.cboPrepaymentAccount.Border.Class = "TextBoxBorder";
            this.cboPrepaymentAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboPrepaymentAccount.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboPrepaymentAccount.ButtonCustom.Image")));
            this.cboPrepaymentAccount.ButtonCustom.Visible = true;
            this.cboPrepaymentAccount.DataSource = null;
            this.cboPrepaymentAccount.DisplayMember = "";
            this.cboPrepaymentAccount.Location = new System.Drawing.Point(191, 46);
            this.cboPrepaymentAccount.Name = "cboPrepaymentAccount";
            this.cboPrepaymentAccount.SelectedIndex = -1;
            this.cboPrepaymentAccount.SelectedValue = null;
            this.cboPrepaymentAccount.Size = new System.Drawing.Size(128, 22);
            this.cboPrepaymentAccount.TabIndex = 13;
            this.cboPrepaymentAccount.ValueMember = "";
            this.cboPrepaymentAccount.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(188, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Prepayment Account";
            // 
            // cboDebtorAccount
            // 
            this.cboDebtorAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDebtorAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.cboDebtorAccount.Border.Class = "TextBoxBorder";
            this.cboDebtorAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboDebtorAccount.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboDebtorAccount.ButtonCustom.Image")));
            this.cboDebtorAccount.ButtonCustom.Visible = true;
            this.cboDebtorAccount.DataSource = null;
            this.cboDebtorAccount.DisplayMember = "";
            this.cboDebtorAccount.Location = new System.Drawing.Point(33, 46);
            this.cboDebtorAccount.Name = "cboDebtorAccount";
            this.cboDebtorAccount.SelectedIndex = -1;
            this.cboDebtorAccount.SelectedValue = null;
            this.cboDebtorAccount.Size = new System.Drawing.Size(128, 22);
            this.cboDebtorAccount.TabIndex = 12;
            this.cboDebtorAccount.ValueMember = "";
            this.cboDebtorAccount.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(30, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Debtor\'s Account";
            // 
            // tbAccounts
            // 
            this.tbAccounts.AttachedControl = this.superTabControlPanel2;
            this.tbAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbAccounts.GlobalItem = false;
            this.tbAccounts.Image = ((System.Drawing.Image)(resources.GetObject("tbAccounts.Image")));
            this.tbAccounts.Name = "tbAccounts";
            this.tbAccounts.Text = "Account Information";
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
            this.btnSaveAndClose.Location = new System.Drawing.Point(399, 517);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 24;
            this.btnSaveAndClose.Text = "Sa&ve and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
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
            this.btnCancel.Location = new System.Drawing.Point(606, 517);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 26;
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
            this.btnSave.Location = new System.Drawing.Point(514, 517);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // CustomersInformationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 551);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.brToolbar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomersInformationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Information";
            this.Load += new System.EventHandler(this.CustomersInformationDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).EndInit();
            this.brToolbar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).EndInit();
            this.tbctrl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMisc)).EndInit();
            this.superTabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerLedger)).EndInit();
            this.superTabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).EndInit();
            this.superTabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReceivables)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar brToolbar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonItem btnSaveShortcut;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.SuperTabControl tbctrl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tbGeneral;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCustomerGroup;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerNo;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkActive;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPoc;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMobile;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFax;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPhone;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblAddCustomerGroup;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tbAccounts;
        private DevComponents.Editors.DoubleInput txtMarginPercent;
        private System.Windows.Forms.Label label14;
        private DevComponents.Editors.DoubleInput txtCreditLimit;
        private System.Windows.Forms.Label label13;
        private DataSourcedComboBox cboPrepaymentAccount;
        private System.Windows.Forms.Label label12;
        private DataSourcedComboBox cboDebtorAccount;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLocation;
        private System.Windows.Forms.Label label17;
        private DataSourcedComboBox cboBankAccount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tbReceivables;
        private C1.Win.C1FlexGrid.C1FlexGrid grdReceivables;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private C1.Win.C1FlexGrid.C1FlexGrid grdCustomerLedger;
        private DevComponents.DotNetBar.SuperTabItem tbCustomerLedger;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private C1.Win.C1FlexGrid.C1FlexGrid grdPayments;
        private DevComponents.DotNetBar.SuperTabItem tbPayments;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel6;
        private DevComponents.DotNetBar.SuperTabItem tbMisc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNotes;
        private C1.Win.C1FlexGrid.C1FlexGrid grdMisc;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPaymentTerms;
        private System.Windows.Forms.Label label18;
    }
}