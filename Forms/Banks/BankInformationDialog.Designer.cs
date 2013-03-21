namespace SupplyChainManagementSystem
{
    partial class BankInformationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankInformationDialog));
            this.brToolbar = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbctrl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.cboCurrency = new SupplyChainManagementSystem.DataSourcedComboBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBranch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIban = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSwift = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddCurrency = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddBank = new System.Windows.Forms.LinkLabel();
            this.cboBankingCompany = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAccountCode = new SupplyChainManagementSystem.DataSourcedComboBox();
            this.tbGeneral = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEndingBalance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOutstandingBalance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurrentBalance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.grdOutstanding = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbOutstanding = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdBankLedger = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbBankLedger = new DevComponents.DotNetBar.SuperTabItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).BeginInit();
            this.brToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).BeginInit();
            this.tbctrl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutstanding)).BeginInit();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBankLedger)).BeginInit();
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
            this.brToolbar.Size = new System.Drawing.Size(768, 27);
            this.brToolbar.Stretch = true;
            this.brToolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brToolbar.TabIndex = 2;
            this.brToolbar.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(616, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 22);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "<i>Search</i>";
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveShortcut.Click += new System.EventHandler(this.btnSaveShortcut_Click);
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
            this.panel1.Location = new System.Drawing.Point(15, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 420);
            this.panel1.TabIndex = 3;
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
            this.tbctrl.Controls.Add(this.superTabControlPanel2);
            this.tbctrl.Controls.Add(this.superTabControlPanel3);
            this.tbctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrl.FixedTabSize = new System.Drawing.Size(150, 0);
            this.tbctrl.Location = new System.Drawing.Point(0, 0);
            this.tbctrl.Name = "tbctrl";
            this.tbctrl.ReorderTabsEnabled = false;
            this.tbctrl.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbctrl.SelectedTabIndex = 0;
            this.tbctrl.Size = new System.Drawing.Size(735, 418);
            this.tbctrl.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tbctrl.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbctrl.TabIndex = 0;
            this.tbctrl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbGeneral,
            this.tbOutstanding,
            this.tbBankLedger});
            this.tbctrl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tbctrl.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tbctrl_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.AutoScroll = true;
            this.superTabControlPanel1.Controls.Add(this.cboCurrency);
            this.superTabControlPanel1.Controls.Add(this.txtNotes);
            this.superTabControlPanel1.Controls.Add(this.label9);
            this.superTabControlPanel1.Controls.Add(this.txtBranch);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.txtIban);
            this.superTabControlPanel1.Controls.Add(this.label7);
            this.superTabControlPanel1.Controls.Add(this.txtSwift);
            this.superTabControlPanel1.Controls.Add(this.label6);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.lblAddCurrency);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.txtAccountName);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.lblAddBank);
            this.superTabControlPanel1.Controls.Add(this.cboBankingCompany);
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Controls.Add(this.txtAccountNo);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Controls.Add(this.cboAccountCode);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(583, 418);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tbGeneral;
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.cboCurrency.Border.Class = "TextBoxBorder";
            this.cboCurrency.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboCurrency.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboCurrency.ButtonCustom.Image")));
            this.cboCurrency.ButtonCustom.Visible = true;
            this.cboCurrency.DataSource = null;
            this.cboCurrency.DisplayMember = "";
            this.cboCurrency.Location = new System.Drawing.Point(39, 156);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.SelectedIndex = -1;
            this.cboCurrency.SelectedValue = null;
            this.cboCurrency.Size = new System.Drawing.Size(174, 22);
            this.cboCurrency.TabIndex = 5;
            this.cboCurrency.ValueMember = "";
            this.cboCurrency.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
            // 
            // txtNotes
            // 
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Location = new System.Drawing.Point(39, 263);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(390, 62);
            this.txtNotes.TabIndex = 10;
            this.txtNotes.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(36, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Notes";
            // 
            // txtBranch
            // 
            // 
            // 
            // 
            this.txtBranch.Border.Class = "TextBoxBorder";
            this.txtBranch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBranch.Location = new System.Drawing.Point(250, 100);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(179, 22);
            this.txtBranch.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(247, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Branch";
            // 
            // txtIban
            // 
            // 
            // 
            // 
            this.txtIban.Border.Class = "TextBoxBorder";
            this.txtIban.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIban.Location = new System.Drawing.Point(250, 209);
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(179, 22);
            this.txtIban.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(247, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "IBAN";
            // 
            // txtSwift
            // 
            // 
            // 
            // 
            this.txtSwift.Border.Class = "TextBoxBorder";
            this.txtSwift.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSwift.Location = new System.Drawing.Point(39, 209);
            this.txtSwift.Name = "txtSwift";
            this.txtSwift.Size = new System.Drawing.Size(174, 22);
            this.txtSwift.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(36, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Swift Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(247, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Account Code";
            // 
            // lblAddCurrency
            // 
            this.lblAddCurrency.AutoSize = true;
            this.lblAddCurrency.BackColor = System.Drawing.Color.Transparent;
            this.lblAddCurrency.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddCurrency.Location = new System.Drawing.Point(139, 140);
            this.lblAddCurrency.Name = "lblAddCurrency";
            this.lblAddCurrency.Size = new System.Drawing.Size(74, 13);
            this.lblAddCurrency.TabIndex = 6;
            this.lblAddCurrency.TabStop = true;
            this.lblAddCurrency.Text = "Add currency";
            this.lblAddCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddCurrency.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddCurrency_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(36, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Currency";
            // 
            // txtAccountName
            // 
            // 
            // 
            // 
            this.txtAccountName.Border.Class = "TextBoxBorder";
            this.txtAccountName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAccountName.Location = new System.Drawing.Point(250, 48);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(179, 22);
            this.txtAccountName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(247, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Account Name";
            // 
            // lblAddBank
            // 
            this.lblAddBank.AutoSize = true;
            this.lblAddBank.BackColor = System.Drawing.Color.Transparent;
            this.lblAddBank.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddBank.Location = new System.Drawing.Point(90, 84);
            this.lblAddBank.Name = "lblAddBank";
            this.lblAddBank.Size = new System.Drawing.Size(123, 13);
            this.lblAddBank.TabIndex = 3;
            this.lblAddBank.TabStop = true;
            this.lblAddBank.Text = "Add banking company";
            this.lblAddBank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddBank_LinkClicked);
            // 
            // cboBankingCompany
            // 
            this.cboBankingCompany.DisplayMember = "Text";
            this.cboBankingCompany.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBankingCompany.FormattingEnabled = true;
            this.cboBankingCompany.ItemHeight = 16;
            this.cboBankingCompany.Location = new System.Drawing.Point(39, 100);
            this.cboBankingCompany.Name = "cboBankingCompany";
            this.cboBankingCompany.Size = new System.Drawing.Size(174, 22);
            this.cboBankingCompany.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBankingCompany.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(36, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Bank";
            // 
            // txtAccountNo
            // 
            // 
            // 
            // 
            this.txtAccountNo.Border.Class = "TextBoxBorder";
            this.txtAccountNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAccountNo.Location = new System.Drawing.Point(39, 48);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(174, 22);
            this.txtAccountNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Account No.";
            // 
            // cboAccountCode
            // 
            this.cboAccountCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAccountCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.cboAccountCode.Border.Class = "TextBoxBorder";
            this.cboAccountCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboAccountCode.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboAccountCode.ButtonCustom.Image")));
            this.cboAccountCode.ButtonCustom.Visible = true;
            this.cboAccountCode.DataSource = null;
            this.cboAccountCode.DisplayMember = "";
            this.cboAccountCode.Location = new System.Drawing.Point(250, 156);
            this.cboAccountCode.Name = "cboAccountCode";
            this.cboAccountCode.SelectedIndex = -1;
            this.cboAccountCode.SelectedValue = null;
            this.cboAccountCode.Size = new System.Drawing.Size(179, 22);
            this.cboAccountCode.TabIndex = 7;
            this.cboAccountCode.ValueMember = "";
            this.cboAccountCode.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
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
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.panel2);
            this.superTabControlPanel2.Controls.Add(this.grdOutstanding);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(583, 418);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tbOutstanding;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtEndingBalance);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtOutstandingBalance);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtCurrentBalance);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 64);
            this.panel2.TabIndex = 1;
            // 
            // txtEndingBalance
            // 
            this.txtEndingBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtEndingBalance.Border.Class = "TextBoxBorder";
            this.txtEndingBalance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndingBalance.Location = new System.Drawing.Point(415, 26);
            this.txtEndingBalance.Name = "txtEndingBalance";
            this.txtEndingBalance.Size = new System.Drawing.Size(151, 22);
            this.txtEndingBalance.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(412, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Ending Balance (USD)";
            // 
            // txtOutstandingBalance
            // 
            this.txtOutstandingBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtOutstandingBalance.Border.Class = "TextBoxBorder";
            this.txtOutstandingBalance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOutstandingBalance.Location = new System.Drawing.Point(247, 26);
            this.txtOutstandingBalance.Name = "txtOutstandingBalance";
            this.txtOutstandingBalance.Size = new System.Drawing.Size(151, 22);
            this.txtOutstandingBalance.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(244, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Outstanding Balance (USD)";
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCurrentBalance.Border.Class = "TextBoxBorder";
            this.txtCurrentBalance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCurrentBalance.Location = new System.Drawing.Point(78, 26);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.Size = new System.Drawing.Size(151, 22);
            this.txtCurrentBalance.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(75, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Current Balance (USD)";
            // 
            // grdOutstanding
            // 
            this.grdOutstanding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOutstanding.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdOutstanding.Location = new System.Drawing.Point(3, 3);
            this.grdOutstanding.Name = "grdOutstanding";
            this.grdOutstanding.Rows.DefaultSize = 21;
            this.grdOutstanding.Size = new System.Drawing.Size(577, 345);
            this.grdOutstanding.StyleInfo = resources.GetString("grdOutstanding.StyleInfo");
            this.grdOutstanding.TabIndex = 11;
            // 
            // tbOutstanding
            // 
            this.tbOutstanding.AttachedControl = this.superTabControlPanel2;
            this.tbOutstanding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbOutstanding.GlobalItem = false;
            this.tbOutstanding.Image = ((System.Drawing.Image)(resources.GetObject("tbOutstanding.Image")));
            this.tbOutstanding.Name = "tbOutstanding";
            this.tbOutstanding.Text = "Account Balances";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.grdBankLedger);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(152, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(583, 418);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tbBankLedger;
            // 
            // grdBankLedger
            // 
            this.grdBankLedger.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdBankLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBankLedger.Location = new System.Drawing.Point(0, 0);
            this.grdBankLedger.Name = "grdBankLedger";
            this.grdBankLedger.Rows.DefaultSize = 21;
            this.grdBankLedger.Size = new System.Drawing.Size(583, 418);
            this.grdBankLedger.StyleInfo = resources.GetString("grdBankLedger.StyleInfo");
            this.grdBankLedger.TabIndex = 15;
            // 
            // tbBankLedger
            // 
            this.tbBankLedger.AttachedControl = this.superTabControlPanel3;
            this.tbBankLedger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbBankLedger.GlobalItem = false;
            this.tbBankLedger.Image = ((System.Drawing.Image)(resources.GetObject("tbBankLedger.Image")));
            this.tbBankLedger.Name = "tbBankLedger";
            this.tbBankLedger.Text = "Bank Ledger";
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
            this.btnSaveAndClose.Location = new System.Drawing.Point(460, 478);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 16;
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
            this.btnCancel.Location = new System.Drawing.Point(667, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 18;
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
            this.btnSave.Location = new System.Drawing.Point(575, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BankInformationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(768, 537);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.brToolbar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BankInformationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bank Account Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BankInformationDialog_FormClosing);
            this.Load += new System.EventHandler(this.BankInformationDialog_Load);
            this.Shown += new System.EventHandler(this.BankInformationDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).EndInit();
            this.brToolbar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).EndInit();
            this.tbctrl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutstanding)).EndInit();
            this.superTabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBankLedger)).EndInit();
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
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBankingCompany;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAccountNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBranch;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIban;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSwift;
        private System.Windows.Forms.Label label6;
        private DataSourcedComboBox cboAccountCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblAddCurrency;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAccountName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblAddBank;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tbOutstanding;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tbBankLedger;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEndingBalance;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOutstandingBalance;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCurrentBalance;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1FlexGrid.C1FlexGrid grdOutstanding;
        private C1.Win.C1FlexGrid.C1FlexGrid grdBankLedger;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private DataSourcedComboBox cboCurrency;
    }
}