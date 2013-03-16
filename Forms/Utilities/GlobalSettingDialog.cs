using C1.Win.C1FlexGrid;
using Development.Materia;
using Development.Materia.Database;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class GlobalSettingDialog : Office2007Form
    {

        /// <summary>
        /// Creates a new instance of GlobalSettingDialog.
        /// </summary>
        public GlobalSettingDialog()
        {
            InitializeComponent();

            pctCompanyLogo.Click += new EventHandler(pct_Click);
            pctReportLogo.Click += new EventHandler(pct_Click);

            txtAddress.TextChanged += new EventHandler(Editor_Edited);
            txtEmail.TextChanged += new EventHandler(Editor_Edited);
            txtFax.TextChanged += new EventHandler(Editor_Edited);
            txtMobile.TextChanged += new EventHandler(Editor_Edited);
            txtPhone.TextChanged += new EventHandler(Editor_Edited);

            cboCountry.SelectedIndexChanged += new EventHandler(Editor_Edited);
            cboCashAdvance.SelectedIndexChanged += new EventHandler(Editor_Edited);
            cboRawMaterials.SelectedIndexChanged += new EventHandler(Editor_Edited);
            cboRollForward.SelectedIndexChanged += new EventHandler(Editor_Edited);
            cboStockAdjustment.SelectedIndexChanged += new EventHandler(Editor_Edited);
            cboStockConsumption.SelectedIndexChanged += new EventHandler(Editor_Edited);
            cboUnallocatedPayments.SelectedIndexChanged += new EventHandler(Editor_Edited);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _shown = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _updated = false;

        private void InitializeValues()
        {
            DataTable _settings = Cache.GetCachedTable("settings");
            DataTable _companies = Cache.GetCachedTable("companies");
          
            if (_settings != null &&
                _companies != null)
            {
                var _query = from gs in _settings.AsEnumerable()
                             join comp in _companies.AsEnumerable()
                             on gs.Field<string>("Company") equals comp.Field<string>("Company")
                             where comp.Field<string>("Company") == SCMS.CurrentCompany.Company
                             select new 
                             {
                                 Company = gs.Field<string>("Company"),
                                 CompanyName = comp.Field<string>("Name"),
                                 Address = gs.Field<string>("Address"),
                                 Country = gs.Field<string>("Country"),
                                 Phone = gs.Field<string>("Phone"),
                                 Fax = gs.Field<string>("Fax"),
                                 Mobile = gs.Field<string>("Mobile"),
                                 Email = gs.Field<string>("Email"),
                                 CompanyLogo = gs.Field<byte[]>("CompanyLogo"),
                                 ReportLogo = gs.Field<byte[]>("ReportLogo"),
                                 CashAdvance = gs.Field<long>("CashAdvanceAccountCode"),
                                 RawMaterial = gs.Field<long>("RawMaterialAccountCode"),
                                 StockConsumption = gs.Field<long>("StockConsumptionAccountCode"),
                                 StockAdjustment = gs.Field<long>("StockAdjustmentAccountCode"),
                                 UnallocatedPayments = gs.Field<long>("UnallocatedPaymentAccountCode"),
                                 RollFoward = gs.Field<long>("RollForwardAccountCode")
                             };

                foreach (var _row in _query)
                {
                    txtCompanyCode.Text = _row.Company; txtCompanyName.Text = _row.CompanyName;
                    txtAddress.Text = _row.Address; cboCountry.Text = _row.Country;
                    txtPhone.Text = _row.Phone; txtFax.Text = _row.Fax;
                    txtMobile.Text = _row.Mobile; txtEmail.Text = _row.Email;
                    if (!Materia.IsNullOrNothing(_row.CompanyLogo)) pctCompanyLogo.Image = _row.CompanyLogo.ToImage();
                    if (!Materia.IsNullOrNothing(_row.ReportLogo)) pctReportLogo.Image = _row.ReportLogo.ToImage();
                    cboCashAdvance.SelectedValue = _row.CashAdvance;
                    cboRawMaterials.SelectedValue = _row.RawMaterial;
                    cboStockConsumption.SelectedValue = _row.StockConsumption;
                    cboStockAdjustment.SelectedValue = _row.StockAdjustment;
                    cboUnallocatedPayments.SelectedValue = _row.UnallocatedPayments;
                    cboRollForward.SelectedValue = _row.RollFoward;
                    chkAutoBackup.Checked = GlobalSettings.AutomaticBackupEnabled;
                    dtpBackUpTime2.LockUpdateChecked = GlobalSettings.AutomaticBackupEnabled2;

                    if (GlobalSettings.AutomaticBackupEnabled)
                    {
                        lblPath.Text = GlobalSettings.AutomaticBackupPath;
                        dtpBackUpTime1.Enabled = true; dtpBackUpTime1.Value = GlobalSettings.AutomaticBackupTime1;
                        dtpBackUpTime2.Enabled = true; 
                        if (GlobalSettings.AutomaticBackupEnabled2) dtpBackUpTime2.Value = GlobalSettings.AutomaticBackupTime2;
                        else dtpBackUpTime2.Value = GlobalSettings.AutomaticBackupTime1.AddHours(5);
                        btnBrowsePath.Enabled = true;
                    }
                    txtIdleTime.LockUpdateChecked = (GlobalSettings.AutomaticLockTime > 0);
                    if (GlobalSettings.AutomaticLockTime > 0) txtIdleTime.Value = GlobalSettings.AutomaticLockTime;
                }
            }
        }

        private void GlobalSettingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the application settings. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

                switch (_result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        btnSave_Click(btnSave, new EventArgs());
                        e.Cancel = _updated; break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true; break;
                    default: break;
                }
            }
        }

        private void GlobalSettingDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); tbctrl.SelectedTab = tbCompany;
            txtCompanyCode.ReadOnly = true; txtCompanyName.ReadOnly = true;

            cboCashAdvance.LoadAccounts(); cboRawMaterials.LoadAccounts();
            cboRollForward.LoadAccounts(); cboStockAdjustment.LoadAccounts();
            cboStockConsumption.LoadAccounts(); cboUnallocatedPayments.LoadAccounts();
            
            dtpBackUpTime1.CustomFormat = "hh:mm tt";
            dtpBackUpTime1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpBackUpTime1.ButtonDropDown.Visible = false;
            dtpBackUpTime1.ShowUpDown = true;
            dtpBackUpTime1.AllowEmptyState = false;

            dtpBackUpTime2.CustomFormat = "hh:mm tt";
            dtpBackUpTime2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpBackUpTime2.ButtonDropDown.Visible = false;
            dtpBackUpTime2.ShowUpDown = true;
            dtpBackUpTime2.ShowCheckBox = true;
            dtpBackUpTime2.AllowEmptyState = false;

            btnBrowsePath.Enabled = false; dtpBackUpTime1.Enabled = false; dtpBackUpTime2.Enabled = false;

            txtIdleTime.ShowUpDown = false; txtIdleTime.ShowCheckBox = true;
            txtIdleTime.MinValue = 1; txtIdleTime.MaxValue = 240;
            txtIdleTime.Value = 1; txtIdleTime.AllowEmptyState = false;

            txtAddress.SetAsRequired(); cboCountry.SetAsRequired();
            cboCashAdvance.SetAsRequired(); cboRawMaterials.SetAsRequired();
            cboRollForward.SetAsRequired(); cboStockAdjustment.SetAsRequired();
            cboStockConsumption.SetAsRequired(); cboUnallocatedPayments.SetAsRequired();

            cboCountry.LoadCountries(); InitializeValues(); 
        }

        private void GlobalSettingDialog_Shown(object sender, EventArgs e)
        { _shown = true; }

        private void btnCancel_Click(object sender, EventArgs e)
        {   
            if (!_cancelled) _cancelled = true; 
            DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); 
        }

        private void tbctrl_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        { if (SCMS.Validators.Contains(this)) SCMS.Validators[this].Highlighter.UpdateHighlights();  }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            if (!btnBrowsePath.Enabled) return;

            FolderBrowserDialog _dialog = new FolderBrowserDialog();
            _dialog.Description = "Automatic backup output destination";
            _dialog.RootFolder = Environment.SpecialFolder.Desktop;
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Directory.Exists(_dialog.SelectedPath)) lblPath.Text = _dialog.SelectedPath;
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void chkAutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkAutoBackup.Enabled) return;
            dtpBackUpTime1.Enabled = chkAutoBackup.Checked;
            dtpBackUpTime2.Enabled = chkAutoBackup.Checked;
            btnBrowsePath.Enabled = chkAutoBackup.Checked;
            if (!chkAutoBackup.Checked) dtpBackUpTime2.LockUpdateChecked = false;
        }

        private void pct_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender.GetType() != typeof(PictureBox)) return;
            PictureBox _picturebox = (PictureBox)sender;

            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.CheckFileExists = true; _dialog.CheckPathExists = true;
            _dialog.DefaultExt = "jpg";
            _dialog.Filter = "All supported image files (*.bmp; *.jpeg; *.jpg; *.png)|*.bmp; *.jpeg; *.jpg; *.png|" +
                             "Bitmap images (*.bmp)|*.bmp|" +
                             "Joint Photograpic Experts Group images (*.jpeg; *.jpg)|*.jpeg; *.jpg|" +
                             "Portable Network Graphics images (*.png)|*.png";
            _dialog.Title = "Select Logo";
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(_dialog.FileName.RLTrim()))
                {
                    if (File.Exists(_dialog.FileName))
                    {
                        try 
                        { 
                            _picturebox.Image = Image.FromFile(_dialog.FileName);
                            _updated = true; this.MarkAsEdited();
                        }
                        catch { }
                    }
                }
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void Editor_Edited(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!_updated) _updated = true; 
            this.MarkAsEdited();
            Validator _validator = SCMS.Validators[this];
            if (_validator != null &&
                sender != null) _validator.ErrorProvider.SetError((Control)sender, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtAddress, !string.IsNullOrEmpty(txtAddress.Text.RLTrim()), "Please specify company address."))
            { tbctrl.SelectedTab = tbCompany; return; }

            if (!Materia.Valid(_validator, cboCountry, cboCountry.SelectedIndex >=0, "Please specify a valid country."))
            { tbctrl.SelectedTab = tbCompany; return; }

            if (!Materia.Valid(_validator, cboCashAdvance, cboCashAdvance.SelectedIndex >= 0, "Please specify a valid account."))
            { tbctrl.SelectedTab = tbAccounts; return; }

            if (!Materia.Valid(_validator, cboUnallocatedPayments, cboUnallocatedPayments.SelectedIndex >= 0, "Please specify a valid account."))
            { tbctrl.SelectedTab = tbAccounts; return; }

            if (!Materia.Valid(_validator, cboRawMaterials, cboRawMaterials.SelectedIndex >= 0, "Please specify a valid account."))
            { tbctrl.SelectedTab = tbAccounts; return; }

            if (!Materia.Valid(_validator, cboStockConsumption, cboStockConsumption.SelectedIndex >= 0, "Please specify a valid account."))
            { tbctrl.SelectedTab = tbAccounts; return; }

            if (!Materia.Valid(_validator, cboStockAdjustment, cboStockAdjustment.SelectedIndex >= 0, "Please specify a valid account."))
            { tbctrl.SelectedTab = tbAccounts; return; }

            if (!Materia.Valid(_validator, cboRollForward, cboRollForward.SelectedIndex >= 0, "Please specify a valid account."))
            { tbctrl.SelectedTab = tbAccounts; return; }

            if (chkAutoBackup.Checked)
            {
                if (!Materia.Valid(_validator, lblPath, !string.IsNullOrEmpty(lblPath.Text.RLTrim()), "Please specify backup output destination."))
                { tbctrl.SelectedTab = tbWorkstation; return; }

                if (!Materia.Valid(_validator, lblPath, Directory.Exists(lblPath.Text), "Please specify backup output destination."))
                { tbctrl.SelectedTab = tbWorkstation; return; }

                if (dtpBackUpTime2.LockUpdateChecked)
                {
                    DateTime _date1 = VisualBasic.CDate(DateTime.Now.ToShortDateString() + " " + VisualBasic.Format(dtpBackUpTime1.Value, "hh:mm tt"));
                    DateTime _date2 = VisualBasic.CDate(DateTime.Now.ToShortDateString() + " " + VisualBasic.Format(dtpBackUpTime2.Value, "hh:mm tt"));

                    if (!Materia.Valid(_validator, dtpBackUpTime2, _date2 >= _date1, "Please specify a time equal or higher than the first instance."))
                    { tbctrl.SelectedTab = tbWorkstation; return; }
                }
            }

            DataTable _settings = Cache.GetCachedTable("settings");
            if (_settings != null)
            {
                DataRow[] _rows = _settings.Select("[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    _row["Address"] = txtAddress.Text; _row["Country"] = cboCountry.SelectedValue.ToString();
                    _row["Phone"] = txtPhone.Text; _row["Mobile"] = txtMobile.Text;
                    _row["Fax"] = txtFax.Text; _row["Email"] = txtEmail.Text;

                    try { _row["CompanyLogo"] = pctCompanyLogo.Image.ToByteArray(); }
                    catch { }

                    try { _row["ReportLogo"] = pctReportLogo.Image.ToByteArray(); }
                    catch { }

                    _row["CashAdvanceAccountCode"] = cboCashAdvance.SelectedValue;
                    _row["RawMaterialAccountCode"] = cboRawMaterials.SelectedValue;
                    _row["StockConsumptionAccountCode"] = cboStockConsumption.SelectedValue;
                    _row["StockAdjustmentAccountCode"] = cboStockAdjustment.SelectedValue;
                    _row["UnallocatedPaymentAccountCode"] = cboUnallocatedPayments.SelectedValue;
                    _row["RollForwardAccountCode"] = cboRollForward.SelectedValue;

                    QueryGenerator _generator = new QueryGenerator(_settings);
                    string _query = _generator.ToString();
                    _generator = null; Materia.RefreshAndManageCurrentProcess();

                    if (string.IsNullOrEmpty(_query.RLTrim()))
                    {
                        GlobalSettings.AutomaticBackupEnabled = chkAutoBackup.Checked;

                        if (chkAutoBackup.Checked) GlobalSettings.AutomaticBackupEnabled2 = dtpBackUpTime2.LockUpdateChecked;
                        else GlobalSettings.AutomaticBackupEnabled2 = false;

                        GlobalSettings.AutomaticBackupPath = lblPath.Text;
                        GlobalSettings.AutomaticBackupTime1 = dtpBackUpTime1.Value;
                        if (chkAutoBackup.Checked &&
                            dtpBackUpTime2.LockUpdateChecked) GlobalSettings.AutomaticBackupTime2 = dtpBackUpTime2.Value;

                        if (txtIdleTime.LockUpdateChecked) GlobalSettings.AutomaticLockTime = txtIdleTime.Value;
                        else GlobalSettings.AutomaticLockTime = 0;

                        IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Edit, "Updated the application settings.");

                        while (!_logresult.IsCompleted &&
                               !_cancelled)
                        { Thread.Sleep(1); Application.DoEvents(); }

                        if (_cancelled)
                        {
                            if (!_logresult.IsCompleted)
                            {
                                try { _logresult = null; }
                                catch { }
                                finally { Materia.RefreshAndManageCurrentProcess(); }
                            }
                        }

                        DialogResult = System.Windows.Forms.DialogResult.OK; Close();
                        return;
                    }
                    
                    btnSave.Enabled = false;
                    IAsyncResult _result = Que.BeginExecution(SCMS.Connection, _query);

                    while (!_result.IsCompleted &&
                           !_cancelled)
                    { Thread.Sleep(1); Application.DoEvents(); }

                    if (_cancelled)
                    {
                        _settings.RejectChanges();
                        if (!_result.IsCompleted)
                        {
                            try { _result = null; }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }
                    }
                    else
                    {
                        QueResult _queresult = Que.EndExecution(_result);
                        if (string.IsNullOrEmpty(_queresult.Error.RLTrim()))
                        {
                            _settings.AcceptChanges(); Cache.Save(); _updated = false;
                            GlobalSettings.AutomaticBackupEnabled = chkAutoBackup.Checked;

                            if (chkAutoBackup.Checked) GlobalSettings.AutomaticBackupEnabled2 = dtpBackUpTime2.LockUpdateChecked;
                            else GlobalSettings.AutomaticBackupEnabled2 = false;

                            GlobalSettings.AutomaticBackupPath = lblPath.Text;
                            GlobalSettings.AutomaticBackupTime1 = dtpBackUpTime1.Value;
                            if (chkAutoBackup.Checked &&
                                dtpBackUpTime2.LockUpdateChecked) GlobalSettings.AutomaticBackupTime2 = dtpBackUpTime2.Value;

                            if (txtIdleTime.LockUpdateChecked) GlobalSettings.AutomaticLockTime = txtIdleTime.Value;
                            else GlobalSettings.AutomaticLockTime = 0;

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Edit, "Updated the application settings.");

                            while (!_logresult.IsCompleted &&
                                   !_cancelled)
                            { Thread.Sleep(1); Application.DoEvents(); }

                            if (_cancelled)
                            {
                                if (!_logresult.IsCompleted)
                                {
                                    try { _logresult = null; }
                                    catch { }
                                    finally { Materia.RefreshAndManageCurrentProcess(); }
                                }
                            }
                            else
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                        }
                        else
                        {
                            _settings.RejectChanges(); SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                            MsgBoxEx.Alert("Failed to save application settings.", "Save Settings"); btnSave.Enabled = true;
                        }
                    }
                }
            }
        }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        { btnSave_Click(btnSave, new EventArgs()); }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            if (!btnClearCache.Enabled) return;
            Cache.Clear(); MsgBoxEx.Inform("Cached application data has been cleared.", "Clear Cache");
        }

    }
}
