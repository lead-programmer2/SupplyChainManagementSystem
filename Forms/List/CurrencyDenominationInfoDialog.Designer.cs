namespace SupplyChainManagementSystem
{
    partial class CurrencyDenominationInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyDenominationInfoDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new DevComponents.Editors.DoubleInput();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCurrency = new SupplyChainManagementSystem.DataSourcedComboBox();
            this.chkActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveShortcut});
            this.bar1.Location = new System.Drawing.Point(0, 181);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(340, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
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
            this.btnSaveAndClose.Location = new System.Drawing.Point(23, 142);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(230, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 5;
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
            this.btnSave.Location = new System.Drawing.Point(138, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Value";
            // 
            // txtValue
            // 
            // 
            // 
            // 
            this.txtValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtValue.Increment = 1D;
            this.txtValue.Location = new System.Drawing.Point(23, 58);
            this.txtValue.Name = "txtValue";
            this.txtValue.ShowUpDown = true;
            this.txtValue.Size = new System.Drawing.Size(128, 22);
            this.txtValue.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(183, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Currency";
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
            this.cboCurrency.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("dataSourcedComboBox1.ButtonCustom.Image")));
            this.cboCurrency.ButtonCustom.Visible = true;
            this.cboCurrency.DataSource = null;
            this.cboCurrency.DisplayMember = "";
            this.cboCurrency.Location = new System.Drawing.Point(186, 58);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.SelectedIndex = -1;
            this.cboCurrency.SelectedValue = null;
            this.cboCurrency.Size = new System.Drawing.Size(128, 22);
            this.cboCurrency.TabIndex = 1;
            this.cboCurrency.ValueMember = "";
            this.cboCurrency.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            // 
            // 
            // 
            this.chkActive.BackgroundStyle.Class = "";
            this.chkActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkActive.Location = new System.Drawing.Point(26, 98);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(52, 17);
            this.chkActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active";
            // 
            // CurrencyDenominationInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(340, 206);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValue);
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
            this.Name = "CurrencyDenominationInfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Currency Denomination";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrencyDenominationInfoDialog_FormClosing);
            this.Load += new System.EventHandler(this.CurrencyDenominationInfoDialog_Load);
            this.Shown += new System.EventHandler(this.CurrencyDenominationInfoDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
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
        private DevComponents.Editors.DoubleInput txtValue;
        private System.Windows.Forms.Label label2;
        private DataSourcedComboBox cboCurrency;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkActive;
    }
}