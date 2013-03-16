namespace SupplyChainManagementSystem
{
    partial class UserInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbctrl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lblAddPosition = new System.Windows.Forms.LinkLabel();
            this.lblAddDepartment = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSuperUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkShowPassword = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboPosition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboDepartment = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMiddleName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbGeneral = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdCustomers = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chkAllowAllCustomers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tbCustomers = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdCompanies = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chkAllowAllCompanies = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tbCompanies = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdPrivileges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tbPrivileges = new DevComponents.DotNetBar.SuperTabItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).BeginInit();
            this.tbctrl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanies)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrivileges)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Location = new System.Drawing.Point(0, 487);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(536, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
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
            this.btnCancel.Location = new System.Drawing.Point(440, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 17;
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
            this.btnSave.Location = new System.Drawing.Point(348, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbctrl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 430);
            this.panel1.TabIndex = 23;
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
            this.tbctrl.Controls.Add(this.superTabControlPanel4);
            this.tbctrl.Controls.Add(this.superTabControlPanel3);
            this.tbctrl.Controls.Add(this.superTabControlPanel2);
            this.tbctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrl.FixedTabSize = new System.Drawing.Size(110, 0);
            this.tbctrl.Location = new System.Drawing.Point(0, 0);
            this.tbctrl.Name = "tbctrl";
            this.tbctrl.ReorderTabsEnabled = true;
            this.tbctrl.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbctrl.SelectedTabIndex = 0;
            this.tbctrl.Size = new System.Drawing.Size(510, 428);
            this.tbctrl.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tbctrl.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbctrl.TabIndex = 0;
            this.tbctrl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbGeneral,
            this.tbPrivileges,
            this.tbCompanies,
            this.tbCustomers});
            this.tbctrl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tbctrl.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tbctrl_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.lblAddPosition);
            this.superTabControlPanel1.Controls.Add(this.lblAddDepartment);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Controls.Add(this.chkSuperUser);
            this.superTabControlPanel1.Controls.Add(this.chkActive);
            this.superTabControlPanel1.Controls.Add(this.chkShowPassword);
            this.superTabControlPanel1.Controls.Add(this.cboPosition);
            this.superTabControlPanel1.Controls.Add(this.cboDepartment);
            this.superTabControlPanel1.Controls.Add(this.txtLastName);
            this.superTabControlPanel1.Controls.Add(this.txtMiddleName);
            this.superTabControlPanel1.Controls.Add(this.txtFirstName);
            this.superTabControlPanel1.Controls.Add(this.txtPassword);
            this.superTabControlPanel1.Controls.Add(this.txtUsername);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(398, 428);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tbGeneral;
            // 
            // lblAddPosition
            // 
            this.lblAddPosition.AutoSize = true;
            this.lblAddPosition.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddPosition.Location = new System.Drawing.Point(176, 269);
            this.lblAddPosition.Name = "lblAddPosition";
            this.lblAddPosition.Size = new System.Drawing.Size(74, 13);
            this.lblAddPosition.TabIndex = 28;
            this.lblAddPosition.TabStop = true;
            this.lblAddPosition.Text = "Add position";
            this.lblAddPosition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddPosition_LinkClicked);
            // 
            // lblAddDepartment
            // 
            this.lblAddDepartment.AutoSize = true;
            this.lblAddDepartment.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblAddDepartment.Location = new System.Drawing.Point(159, 210);
            this.lblAddDepartment.Name = "lblAddDepartment";
            this.lblAddDepartment.Size = new System.Drawing.Size(91, 13);
            this.lblAddDepartment.TabIndex = 27;
            this.lblAddDepartment.TabStop = true;
            this.lblAddDepartment.Text = "Add department";
            this.lblAddDepartment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddDepartment_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(25, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(25, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(24, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Account Holder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(181, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Username";
            // 
            // chkSuperUser
            // 
            this.chkSuperUser.AutoSize = true;
            // 
            // 
            // 
            this.chkSuperUser.BackgroundStyle.Class = "";
            this.chkSuperUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSuperUser.Location = new System.Drawing.Point(223, 397);
            this.chkSuperUser.Name = "chkSuperUser";
            this.chkSuperUser.Size = new System.Drawing.Size(75, 17);
            this.chkSuperUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSuperUser.TabIndex = 8;
            this.chkSuperUser.Text = "Super User";
            this.chkSuperUser.CheckedChanged += new System.EventHandler(this.chkSuperUser_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            // 
            // 
            // 
            this.chkActive.BackgroundStyle.Class = "";
            this.chkActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkActive.Location = new System.Drawing.Point(319, 397);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(52, 17);
            this.chkActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkActive.TabIndex = 9;
            this.chkActive.Text = "Active";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            // 
            // 
            // 
            this.chkShowPassword.BackgroundStyle.Class = "";
            this.chkShowPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkShowPassword.Location = new System.Drawing.Point(184, 97);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(98, 17);
            this.chkShowPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkShowPassword.TabIndex = 2;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // cboPosition
            // 
            this.cboPosition.DisplayMember = "Text";
            this.cboPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.ItemHeight = 16;
            this.cboPosition.Location = new System.Drawing.Point(27, 291);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(223, 22);
            this.cboPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPosition.TabIndex = 7;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DisplayMember = "Text";
            this.cboDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.ItemHeight = 16;
            this.cboDepartment.Location = new System.Drawing.Point(27, 233);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(223, 22);
            this.cboDepartment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboDepartment.TabIndex = 6;
            // 
            // txtLastName
            // 
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLastName.Location = new System.Drawing.Point(267, 167);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(104, 22);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtLastName.WatermarkText = "Last Name";
            // 
            // txtMiddleName
            // 
            // 
            // 
            // 
            this.txtMiddleName.Border.Class = "TextBoxBorder";
            this.txtMiddleName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMiddleName.Location = new System.Drawing.Point(146, 167);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(104, 22);
            this.txtMiddleName.TabIndex = 4;
            this.txtMiddleName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtMiddleName.WatermarkText = "Middle Name";
            // 
            // txtFirstName
            // 
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstName.Location = new System.Drawing.Point(26, 167);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(104, 22);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtFirstName.WatermarkText = "First Name";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Location = new System.Drawing.Point(184, 69);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(187, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.Border.Class = "TextBoxBorder";
            this.txtUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsername.Location = new System.Drawing.Point(26, 69);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(133, 22);
            this.txtUsername.TabIndex = 0;
            // 
            // tbGeneral
            // 
            this.tbGeneral.AttachedControl = this.superTabControlPanel1;
            this.tbGeneral.GlobalItem = false;
            this.tbGeneral.Image = ((System.Drawing.Image)(resources.GetObject("tbGeneral.Image")));
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Text = "General";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.grdCustomers);
            this.superTabControlPanel4.Controls.Add(this.chkAllowAllCustomers);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(398, 428);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.tbCustomers;
            // 
            // grdCustomers
            // 
            this.grdCustomers.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdCustomers.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdCustomers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdCustomers.Location = new System.Drawing.Point(0, 50);
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.Rows.DefaultSize = 21;
            this.grdCustomers.Size = new System.Drawing.Size(398, 378);
            this.grdCustomers.StyleInfo = resources.GetString("grdCustomers.StyleInfo");
            this.grdCustomers.TabIndex = 14;
            // 
            // chkAllowAllCustomers
            // 
            this.chkAllowAllCustomers.AutoSize = true;
            // 
            // 
            // 
            this.chkAllowAllCustomers.BackgroundStyle.Class = "";
            this.chkAllowAllCustomers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllowAllCustomers.Location = new System.Drawing.Point(13, 19);
            this.chkAllowAllCustomers.Name = "chkAllowAllCustomers";
            this.chkAllowAllCustomers.Size = new System.Drawing.Size(223, 17);
            this.chkAllowAllCustomers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllowAllCustomers.TabIndex = 13;
            this.chkAllowAllCustomers.Text = "Allowed to access all available customers.";
            // 
            // tbCustomers
            // 
            this.tbCustomers.AttachedControl = this.superTabControlPanel4;
            this.tbCustomers.GlobalItem = false;
            this.tbCustomers.Image = ((System.Drawing.Image)(resources.GetObject("tbCustomers.Image")));
            this.tbCustomers.Name = "tbCustomers";
            this.tbCustomers.Text = "Customers";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.grdCompanies);
            this.superTabControlPanel3.Controls.Add(this.chkAllowAllCompanies);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(398, 428);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tbCompanies;
            // 
            // grdCompanies
            // 
            this.grdCompanies.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdCompanies.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdCompanies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdCompanies.Location = new System.Drawing.Point(0, 50);
            this.grdCompanies.Name = "grdCompanies";
            this.grdCompanies.Rows.DefaultSize = 21;
            this.grdCompanies.Size = new System.Drawing.Size(398, 378);
            this.grdCompanies.StyleInfo = resources.GetString("grdCompanies.StyleInfo");
            this.grdCompanies.TabIndex = 12;
            // 
            // chkAllowAllCompanies
            // 
            this.chkAllowAllCompanies.AutoSize = true;
            // 
            // 
            // 
            this.chkAllowAllCompanies.BackgroundStyle.Class = "";
            this.chkAllowAllCompanies.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllowAllCompanies.Location = new System.Drawing.Point(13, 19);
            this.chkAllowAllCompanies.Name = "chkAllowAllCompanies";
            this.chkAllowAllCompanies.Size = new System.Drawing.Size(188, 17);
            this.chkAllowAllCompanies.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllowAllCompanies.TabIndex = 11;
            this.chkAllowAllCompanies.Text = "Allowed in all available companies";
            // 
            // tbCompanies
            // 
            this.tbCompanies.AttachedControl = this.superTabControlPanel3;
            this.tbCompanies.GlobalItem = false;
            this.tbCompanies.Image = ((System.Drawing.Image)(resources.GetObject("tbCompanies.Image")));
            this.tbCompanies.Name = "tbCompanies";
            this.tbCompanies.Text = "Companies";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.grdPrivileges);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(398, 428);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tbPrivileges;
            // 
            // grdPrivileges
            // 
            this.grdPrivileges.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdPrivileges.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdPrivileges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrivileges.Location = new System.Drawing.Point(0, 0);
            this.grdPrivileges.Name = "grdPrivileges";
            this.grdPrivileges.Rows.DefaultSize = 21;
            this.grdPrivileges.Size = new System.Drawing.Size(398, 428);
            this.grdPrivileges.StyleInfo = resources.GetString("grdPrivileges.StyleInfo");
            this.grdPrivileges.TabIndex = 4;
            // 
            // tbPrivileges
            // 
            this.tbPrivileges.AttachedControl = this.superTabControlPanel2;
            this.tbPrivileges.GlobalItem = false;
            this.tbPrivileges.Image = ((System.Drawing.Image)(resources.GetObject("tbPrivileges.Image")));
            this.tbPrivileges.Name = "tbPrivileges";
            this.tbPrivileges.Text = "Privileges";
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
            this.btnSaveAndClose.Location = new System.Drawing.Point(233, 454);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 15;
            this.btnSaveAndClose.Text = "Sa&ve and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveShortcut.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveShortcut.Location = new System.Drawing.Point(153, 388);
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveShortcut.Size = new System.Drawing.Size(55, 28);
            this.btnSaveShortcut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveShortcut.TabIndex = 24;
            this.btnSaveShortcut.Click += new System.EventHandler(this.btnSaveShortcut_Click);
            // 
            // UserInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 512);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.btnSaveShortcut);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserInfoDialog_FormClosing);
            this.Load += new System.EventHandler(this.UserInfoDialog_Load);
            this.Shown += new System.EventHandler(this.UserInfoDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbctrl)).EndInit();
            this.tbctrl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            this.superTabControlPanel3.ResumeLayout(false);
            this.superTabControlPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanies)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrivileges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.SuperTabControl tbctrl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tbGeneral;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tbPrivileges;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tbCompanies;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem tbCustomers;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllowAllCompanies;
        private C1.Win.C1FlexGrid.C1FlexGrid grdCompanies;
        private C1.Win.C1FlexGrid.C1FlexGrid grdPrivileges;
        private C1.Win.C1FlexGrid.C1FlexGrid grdCustomers;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllowAllCustomers;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUsername;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMiddleName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSuperUser;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkActive;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkShowPassword;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPosition;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDepartment;
        private System.Windows.Forms.Button btnSaveAndClose;
        private DevComponents.DotNetBar.ButtonX btnSaveShortcut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblAddPosition;
        private System.Windows.Forms.LinkLabel lblAddDepartment;
    }
}