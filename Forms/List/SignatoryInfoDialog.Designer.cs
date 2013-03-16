namespace SupplyChainManagementSystem
{
    partial class SignatoryInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignatoryInfoDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDepartment = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPosition = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCashLimit = new DevComponents.Editors.DoubleInput();
            this.txtBankLimit = new DevComponents.Editors.DoubleInput();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUsername = new SupplyChainManagementSystem.DataSourcedComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveShortcut});
            this.bar1.Location = new System.Drawing.Point(0, 351);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(368, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveShortcut.Click += new System.EventHandler(this.btnSaveShortcut_Click);
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
            this.btnSaveAndClose.Location = new System.Drawing.Point(52, 313);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 7;
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
            this.btnCancel.Location = new System.Drawing.Point(259, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(167, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "System User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(23, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Full Name";
            // 
            // txtFullName
            // 
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.Location = new System.Drawing.Point(26, 118);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(313, 22);
            this.txtFullName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(23, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Department";
            // 
            // txtDepartment
            // 
            // 
            // 
            // 
            this.txtDepartment.Border.Class = "TextBoxBorder";
            this.txtDepartment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDepartment.Location = new System.Drawing.Point(26, 185);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(146, 22);
            this.txtDepartment.TabIndex = 3;
            // 
            // txtPosition
            // 
            // 
            // 
            // 
            this.txtPosition.Border.Class = "TextBoxBorder";
            this.txtPosition.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPosition.Location = new System.Drawing.Point(193, 185);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(146, 22);
            this.txtPosition.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(193, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(174, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Role";
            // 
            // cboRole
            // 
            this.cboRole.DisplayMember = "Text";
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.ItemHeight = 16;
            this.cboRole.Location = new System.Drawing.Point(176, 53);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(163, 22);
            this.cboRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRole.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(22, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Cash Limit (USD)";
            // 
            // txtCashLimit
            // 
            // 
            // 
            // 
            this.txtCashLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCashLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCashLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCashLimit.Increment = 1D;
            this.txtCashLimit.Location = new System.Drawing.Point(26, 253);
            this.txtCashLimit.Name = "txtCashLimit";
            this.txtCashLimit.ShowUpDown = true;
            this.txtCashLimit.Size = new System.Drawing.Size(146, 22);
            this.txtCashLimit.TabIndex = 5;
            // 
            // txtBankLimit
            // 
            // 
            // 
            // 
            this.txtBankLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBankLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBankLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBankLimit.Increment = 1D;
            this.txtBankLimit.Location = new System.Drawing.Point(193, 253);
            this.txtBankLimit.Name = "txtBankLimit";
            this.txtBankLimit.ShowUpDown = true;
            this.txtBankLimit.Size = new System.Drawing.Size(146, 22);
            this.txtBankLimit.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(190, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Bank Limit (USD)";
            // 
            // cboUsername
            // 
            this.cboUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.cboUsername.Border.Class = "TextBoxBorder";
            this.cboUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboUsername.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("cboUsername.ButtonCustom.Image")));
            this.cboUsername.ButtonCustom.Visible = true;
            this.cboUsername.DataSource = null;
            this.cboUsername.DisplayMember = "";
            this.cboUsername.Location = new System.Drawing.Point(26, 53);
            this.cboUsername.Name = "cboUsername";
            this.cboUsername.SelectedIndex = -1;
            this.cboUsername.SelectedValue = null;
            this.cboUsername.Size = new System.Drawing.Size(112, 22);
            this.cboUsername.TabIndex = 0;
            this.cboUsername.ValueMember = "";
            this.cboUsername.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
            this.cboUsername.SelectedValueChanged += new System.EventHandler(this.cboUsername_SelectedValueChanged);
            // 
            // SignatoryInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(368, 376);
            this.Controls.Add(this.txtBankLimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCashLimit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignatoryInfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signatory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignatoryInfoDialog_FormClosing);
            this.Load += new System.EventHandler(this.SignatoryInfoDialog_Load);
            this.Shown += new System.EventHandler(this.SignatoryInfoDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnSaveShortcut;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private DataSourcedComboBox cboUsername;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFullName;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDepartment;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRole;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.DoubleInput txtCashLimit;
        private DevComponents.Editors.DoubleInput txtBankLimit;
        private System.Windows.Forms.Label label7;
    }
}