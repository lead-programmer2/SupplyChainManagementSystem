using DevComponents.DotNetBar;
using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class BankInformationDialog : Office2007Form
    {

        /// <summary>
        /// Creates a new instance of BankInformationDialog.
        /// </summary>
        public BankInformationDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of BankInformationDialog.
        /// </summary>
        /// <param name="code"></param>
        public BankInformationDialog(string code)
        {
            InitializeComponent();

            _bankaccountcode = code; _isnew = false;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _bankaccountcode = "";

        /// <summary>
        /// Gets the current updated bank account's code.
        /// </summary>
        public string BankAccountCode
        {
            get { return _bankaccountcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isinbackground = false;

        /// <summary>
        /// Gets whether the current form is active but resides in the backgound only or not.
        /// </summary>
        public bool IsInBackground
        {
            get { return _isinbackground; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current banking company conducts any updates while it is open.
        /// </summary>
        public bool WithUpdates
        {
            get { return _withupdates; }
        }

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isnew = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isshown = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _updated = false;

        #endregion

        private void AttachEditorHandler()
        {
            txtAccountName.TextChanged += new EventHandler(Field_Edited);
            txtAccountNo.TextChanged += new EventHandler(Field_Edited);
            txtBranch.TextChanged += new EventHandler(Field_Edited);
            txtIban.TextChanged += new EventHandler(Field_Edited);
            txtNotes.TextChanged += new EventHandler(Field_Edited);
            txtSwift.TextChanged += new EventHandler(Field_Edited);
            cboAccountCode.SelectedValueChanged += new EventHandler(Field_Edited);
            cboBankingCompany.SelectedValueChanged += new EventHandler(Field_Edited);
            cboCurrency.SelectedValueChanged += new EventHandler(Field_Edited);
        }

        /// <summary>
        /// Clears the information fields for the current bank account rendering it in a new instance mode.
        /// </summary>
        public void ClearInformation()
        {
            _isnew = true; _withupdates = false; _bankaccountcode = "";
            _updated = false; _isshown = false; _isinbackground = false;

            Text = Text.Replace(" *", "").Replace("*", "");

            txtAccountName.Text = ""; txtAccountNo.Text = "";
            txtBranch.Text = ""; txtCurrentBalance.Text = "0.00";
            txtEndingBalance.Text = "0.00"; txtIban.Text = "";
            txtNotes.Text = ""; txtOutstandingBalance.Text = "0.00";
            txtSwift.Text = "";

            try { cboAccountCode.SelectedIndex = -1; }
            catch { }

            try { cboBankingCompany.SelectedIndex = -1; }
            catch { }

            try { cboCurrency.SelectedIndex = -1; }
            catch { }

            tbctrl.SelectedTab = tbGeneral;
            tbBankLedger.Visible = false; tbOutstanding.Visible = false;
        }

        /// <summary>
        /// Loads a bank account information in this dialog thru the given bank account code.
        /// </summary>
        /// <param name="code"></param>
        public void LoadBankAccountInformation(string code)
        {
            DataTable _bankaccounts = Cache.GetCachedTable("bankaccounts");
            _bankaccountcode = code; _isnew = false; _withupdates = false;
            _updated = false; _isshown = false; _isinbackground = false;

            Text = Text.Replace(" *", "").Replace("*", "");

            if (_bankaccounts != null)
            {
                DataRow[] _rows = _bankaccounts.Select("[BankAccountCode] LIKE '" + _bankaccountcode.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["AccountNo"])) txtAccountNo.Text = _row["AccountNo"].ToString();
                    if (!Materia.IsNullOrNothing(_row["AccountName"])) txtAccountName.Text = _row["AccountName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Currency"])) cboCurrency.SelectedValue = _row["Currency"].ToString();
                    if (VisualBasic.IsNumeric(_row["AccountCode"])) cboAccountCode.SelectedValue = _row["AccountCode"];
                    if (!Materia.IsNullOrNothing(_row["Swift"])) txtSwift.Text = _row["Swift"].ToString();
                    if (!Materia.IsNullOrNothing(_row["IBAN"])) txtIban.Text = _row["IBAN"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Bank"])) cboBankingCompany.SelectedValue = _row["Bank"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Branch"])) txtBranch.Text = _row["Branch"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Notes"])) txtNotes.Text = _row["Notes"].ToString();
                }
            }

            if (!_isshown) _isshown = true;
        }

        private void InitializeSearches()
        {
            DataTable _bankaccounts = Cache.GetCachedTable("bankaccounts");
            if (_bankaccounts != null)
            {
                if (txtSearch.AutoCompleteCustomSource == null) txtSearch.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                txtSearch.AutoCompleteCustomSource.Clear();

                for (int i = 0; i <= (_bankaccounts.Rows.Count - 1); i++)
                {
                    DataRow _row = _bankaccounts.Rows[i];

                    if (!Materia.IsNullOrNothing(_row["AccountNo"]))
                    {
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row["AccountNo"].ToString())) txtSearch.AutoCompleteCustomSource.Add(_row["AccountNo"].ToString());
                    }

                    if (!Materia.IsNullOrNothing(_row["AccountName"]))
                    {
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row["AccountName"].ToString())) txtSearch.AutoCompleteCustomSource.Add(_row["AccountName"].ToString());
                    }

                    if (VisualBasic.IsNumeric(_row["AccountCode"]))
                    {
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row["AccountCode"].ToString())) txtSearch.AutoCompleteCustomSource.Add(_row["AccountCode"].ToString());
                    }

                    if (!Materia.IsNullOrNothing(_row["Bank"]))
                    {
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row["Bank"].ToString())) txtSearch.AutoCompleteCustomSource.Add(_row["Bank"].ToString());
                    }
                }

                txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        /// <summary>
        /// Forces the dialog to stay silently in the background.
        /// </summary>
        public void StayInBackground()
        { _withupdates = false; _updated = false; _isinbackground = true; }

        private void BankInformationDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SCMS.CurrentSystemUser == null) return;
            if (!SCMS.CurrentSystemUser.IsSignedIn) return;
            if (!TopMost) return;
            if (MdiParent != null)
            {
                if (MdiParent is MainWindow)
                {
                    if (((MainWindow)MdiParent).IsClosing) return;
                }
            }

            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current bank account. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

                switch (_result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        btnSave_Click(btnSaveAndClose, new EventArgs());
                        e.Cancel = _updated; break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true; break;
                    default: break;
                }
            }

            _cancelled = (!e.Cancel);
        }

        private void BankInformationDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            txtCurrentBalance.Text = "0.00"; txtCurrentBalance.TextAlign = HorizontalAlignment.Right;
            txtCurrentBalance.ReadOnly = true;

            txtOutstandingBalance.Text = "0.00"; txtOutstandingBalance.TextAlign = HorizontalAlignment.Right;
            txtOutstandingBalance.ReadOnly = true;

            txtEndingBalance.Text = "0.00"; txtEndingBalance.TextAlign = HorizontalAlignment.Right;
            txtEndingBalance.ReadOnly = true;

            grdBankLedger.InitializeAppearance(); grdOutstanding.InitializeAppearance();
            tbctrl.SelectedTab = tbGeneral; InitializeSearches();

            tbBankLedger.Visible = (!_isnew); tbOutstanding.Visible = (!_isnew);
            cboAccountCode.LoadAccounts(); cboCurrency.LoadCurrencies();
            cboBankingCompany.LoadBanks();

            txtAccountName.SetAsRequired(); txtAccountNo.SetAsRequired();
            cboAccountCode.SetAsRequired(); cboBankingCompany.SetAsRequired();
            cboCurrency.SetAsRequired();

            if (!_isnew) LoadBankAccountInformation(_bankaccountcode);
        }

        private void BankInformationDialog_Shown(object sender, EventArgs e)
        {
            if (!_isshown) _isshown = true;
            if (txtAccountNo.Enabled) txtAccountNo.Focus();
        }

        private void Field_Edited(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!_isshown) return;

            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.ErrorProvider.SetError((Control)sender, "");

            if (!_updated) _updated = true;
            this.MarkAsEdited();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtAccountNo, !string.IsNullOrEmpty(txtAccountNo.Text.RLTrim()), "Please specify bank account number.")) return;
            if (!Materia.Valid(_validator, txtAccountName, !string.IsNullOrEmpty(txtAccountName.Text.RLTrim()), "Please specify bank account name.")) return;
            if (!Materia.Valid(_validator, cboBankingCompany, cboBankingCompany.SelectedIndex >= 0, "Please specify a valid banking company.")) return;
            if (!Materia.Valid(_validator, cboCurrency, cboCurrency.SelectedIndex >= 0, "Please specify bank currency.")) return;
            if (!Materia.Valid(_validator, cboAccountCode, cboAccountCode.SelectedIndex >= 0, "Please specify bank's associated G/L account.")) return;

            DataTable _bankaccounts = Cache.GetCachedTable("bankaccounts");

            if (_bankaccounts != null)
            {
                DataRow[] _rows = _bankaccounts.Select("([AccountNo] LIKE '" + txtAccountNo.Text.ToSqlValidString(true) + "' AND\n" +
                                                       " [Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "') AND\n" +
                                                       "NOT ([BankAccountCode] LIKE '" + _bankaccountcode.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtAccountNo, _rows.Length <= 0, "Account already exists.")) return;

                string _query = ""; string _refno = ""; string _seriesno = "";
                DataColumnCollection _cols = _bankaccounts.Columns;
                
                if (_isnew)
                {
                    Func<string, bool, string> _delegate = new Func<string, bool, string>(SCMS.GetTableSeriesNumber);
                    IAsyncResult _result = _delegate.BeginInvoke("bankaccounts", true, null, _delegate);

                    while (!_result.IsCompleted &&
                           !_cancelled)
                    { Thread.Sleep(1); Application.DoEvents(); }

                    if (_cancelled)
                    {
                        if (!_result.IsCompleted)
                        {
                            try { _result = null; }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }

                        return;
                    }

                    _seriesno = _delegate.EndInvoke(_result);
                    _refno = "BANK-" + SCMS.CurrentCompany.Company + "-" + _seriesno;

                    object[] _values = new object[_cols.Count];
                    _values[_cols["BankAccountCode"].Ordinal] = _refno;
                    _values[_cols["AccountNo"].Ordinal] = txtAccountNo.Text;
                    _values[_cols["AccountName"].Ordinal] = txtAccountName.Text;
                    _values[_cols["Currency"].Ordinal] = cboCurrency.SelectedValue.ToString();
                    _values[_cols["AccountCode"].Ordinal] = cboAccountCode.SelectedValue;
                    _values[_cols["Swift"].Ordinal] = txtSwift.Text;
                    _values[_cols["IBAN"].Ordinal] = txtIban.Text;
                    _values[_cols["Bank"].Ordinal] = cboBankingCompany.SelectedValue;
                    _values[_cols["Branch"].Ordinal] = txtBranch.Text;
                    _values[_cols["Notes"].Ordinal] = txtNotes.Text;
                    _values[_cols["Company"].Ordinal] = SCMS.CurrentCompany.Company;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _bankaccounts.Rows.Add(_values);
                }
                else
                {
                    DataRow[] _existing = _bankaccounts.Select("[BankAccountCode] LIKE '" + _bankaccountcode.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["AccountNo"] = txtAccountNo.Text;
                        _existing[0]["AccountName"] = txtAccountName.Text;
                        _existing[0]["Currency"] = cboCurrency.SelectedValue;
                        _existing[0]["AccountCode"] = cboAccountCode.SelectedValue;
                        _existing[0]["Swift"] = txtSwift.Text;
                        _existing[0]["IBAN"] = txtIban.Text;
                        _existing[0]["Bank"] = cboBankingCompany.SelectedValue;
                        _existing[0]["Branch"] = txtBranch.Text;
                        _existing[0]["Notes"] = txtNotes.Text;
                    }
                }

                QueryGenerator _generator = new QueryGenerator(_bankaccounts);
                _query = _generator.ToString();
                _generator = null; Materia.RefreshAndManageCurrentProcess();

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;

                    IAsyncResult _result = Que.BeginExecution(SCMS.Connection, _query);

                    while (!_result.IsCompleted &&
                           !_cancelled)
                    { Thread.Sleep(1); Application.DoEvents(); }

                    if (_cancelled)
                    {
                        if (!_result.IsCompleted)
                        {
                            try { _result = null; }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }

                        return;
                    }
                    else
                    {
                        QueResult _queresult = Que.EndExecution(_result);

                        if (string.IsNullOrEmpty(_queresult.Error.RLTrim()))
                        {
                            UserAction _action = UserAction.Add;
                            if (!_isnew) _action = UserAction.Edit;

                            string _log = "Added a new bank account : " + txtAccountNo.Text + " - " + txtAccountName.Text + ".";
                            if (!_isnew) _log = "Updated bank account : " + txtAccountNo.Text + " - " + txtAccountName.Text + ".";

                            _bankaccounts.AcceptChanges();
                            if (_isnew) _bankaccountcode = _refno;
                            if (_isnew) _isnew = false;
                            if (_updated) _updated = false;
                            if (!_withupdates) _withupdates = true;
                            Text = Text.Replace(" *", "").Replace("*", "");
                            Cursor = Cursors.WaitCursor;

                            if (!txtSearch.AutoCompleteCustomSource.Contains(txtAccountNo.Text)) txtSearch.AutoCompleteCustomSource.Add(txtAccountNo.Text);
                            if (!txtSearch.AutoCompleteCustomSource.Contains(txtAccountName.Text)) txtSearch.AutoCompleteCustomSource.Add(txtAccountName.Text);
                            if (!txtSearch.AutoCompleteCustomSource.Contains(cboBankingCompany.SelectedValue.ToString())) txtSearch.AutoCompleteCustomSource.Add(cboBankingCompany.SelectedValue.ToString());
                            if (!txtSearch.AutoCompleteCustomSource.Contains(cboAccountCode.SelectedValue.ToString())) txtSearch.AutoCompleteCustomSource.Add(cboAccountCode.SelectedValue.ToString());

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _log);
                            _logresult.WaitToFinish();

                            Cursor = Cursors.Default;

                            if (sender == btnSaveAndClose)
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                            else
                            {
                                if (!tbOutstanding.Visible) tbOutstanding.Visible = true; 
                                if (!tbBankLedger.Visible) tbBankLedger.Visible = true; 
                            }
                        }
                        else
                        {
                            if (_queresult.Error.Contains("duplicate")) btnSave_Click(sender, new EventArgs());
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current bank account.", "Save Bank Account");
                            }

                            _bankaccounts.RejectChanges();
                        }

                        _queresult.Dispose();
                    }

                    btnSave.Enabled = true; btnSaveAndClose.Enabled = true;
                }
            }
            else
            {
                if (sender == btnSaveAndClose)
                { DialogResult = System.Windows.Forms.DialogResult.None; Close(); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        { if (btnSaveAndClose.Enabled) btnSave_Click(btnSaveAndClose, new EventArgs()); }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        { btnSave_Click(btnSave, new EventArgs()); }

        private void tbctrl_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        { if (SCMS.Validators.Contains(this)) SCMS.Validators[this].Highlighter.UpdateHighlights(); }

        private void lblAddBank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lblAddBank.Enabled) return;

            BankInfoDialog _dialog = new BankInfoDialog();
            if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess(); return;
            }

            if (_dialog.WithUpdates)
            {
                cboBankingCompany.LoadBanks();
                try { cboBankingCompany.SelectedValue = _dialog.Bank; }
                catch { }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void lblAddCurrency_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lblAddCurrency.Enabled) return;

            CurrencyInfoDialog _dialog = new CurrencyInfoDialog();
            if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess(); return;
            }

            if (_dialog.WithUpdates)
            {
                cboCurrency.LoadCurrencies();

                try { cboCurrency.SelectedValue = _dialog.Currency; }
                catch { }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

    }
}
