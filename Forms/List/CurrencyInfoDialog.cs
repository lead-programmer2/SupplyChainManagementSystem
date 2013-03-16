using C1.Win.C1FlexGrid;
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
    public partial class CurrencyInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of CurrencyInfoDialog. 
        /// </summary>
        public CurrencyInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of CurrencyInfoDialog. 
        /// </summary>
        /// <param name="unit"></param>
        public CurrencyInfoDialog(string unit)
        {
            InitializeComponent();

            _currency = unit; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _currency = "";

        /// <summary>
        /// Gets the current updated currency.
        /// </summary>
        public string Currency
        {
            get { return _currency; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current currency conducts any updates while it is open.
        /// </summary>
        public bool WithUpdates
        {
            get { return _withupdates; }
        }

        #endregion

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

        #region Methods

        private void AttachEditorHandler()
        {
            txtDescription.TextChanged += new EventHandler(Field_Edited);
            cboExchangeRateDiff.SelectedValueChanged += new EventHandler(Field_Edited);
            cboAccount.SelectedValueChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _currencies = Cache.GetCachedTable("currencies");
            if (_currencies != null)
            {
                DataRow[] _rows = _currencies.Select("[Currency] LIKE '" + _currency.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["Currency"])) txtCurrency.Text = _row["Currency"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Description"])) txtDescription.Text = _row["Description"].ToString();
                    if (VisualBasic.IsNumeric(_row["AccountCode"])) cboAccount.SelectedValue = _row["AccountCode"];
                    if (VisualBasic.IsNumeric(_row["ExchangeRateAccountCode"])) cboExchangeRateDiff.SelectedValue = _row["ExchangeRateAccountCode"];
                }
            }
        }

        #endregion

        #region FormEvents

        private void CurrencyInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current currency. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void CurrencyInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboAccount.LoadAccounts(); cboExchangeRateDiff.LoadAccounts();

            txtCurrency.ReadOnly = (_currency.ToUpper() == "USD");

            string _path = Application.StartupPath + "\\Xml\\defaultaccounts.xml";
            DataTable _defaultaccounts = SCMS.XmlToTable(_path);

            if (_defaultaccounts != null)
            {
                if (cboAccount.DataSource != null)
                {
                    long _cashathand = 54005;
                    DataRow[] _rows = _defaultaccounts.Select("[AccountName] LIKE 'Cash at hand'");
                    if (_rows.Length > 0) _cashathand = VisualBasic.CLng(_rows[0]["AccountCode"]);
                    try { cboAccount.SelectedValue = _cashathand; }
                    catch { }
                }

                if (cboExchangeRateDiff.DataSource != null)
                {
                    long _exratediff = 34625;
                    DataRow[] _rows = _defaultaccounts.Select("[AccountName] LIKE 'Exchange rate differences'");
                    if (_rows.Length > 0) _exratediff = VisualBasic.CLng(_rows[0]["AccountCode"]);
                    try { cboExchangeRateDiff.SelectedValue = _exratediff; }
                    catch { }
                }

                _defaultaccounts.Dispose(); _defaultaccounts = null;
                Materia.RefreshAndManageCurrentProcess();
            }
            
            txtCurrency.SetAsRequired();
            cboAccount.SetAsRequired(); cboExchangeRateDiff.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void CurrencyInfoDialog_Shown(object sender, EventArgs e)
        { if (!_isshown) _isshown = true; }

        #endregion

        #region ControlEvents

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

            if (!Materia.Valid(_validator, txtCurrency, !string.IsNullOrEmpty(txtCurrency.Text.RLTrim()), "Please specify currency.")) return;
            if (!Materia.Valid(_validator, cboAccount, cboAccount.SelectedIndex >= 0, "Please specify a valid account.")) return;
            if (!Materia.Valid(_validator, cboExchangeRateDiff, cboExchangeRateDiff.SelectedIndex >= 0, "Please specify a valid exchange rate diff. account.")) return;

            DataTable _currencies = Cache.GetCachedTable("currencies");

            if (_currencies != null)
            {
                DataRow[] _rows = _currencies.Select("([Currency] LIKE '" + txtCurrency.Text.ToSqlValidString(true) + "') AND\n" +
                                                     "NOT ([Currency] LIKE '" + _currency.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtCurrency, _rows.Length <= 0, "Currency already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _currencies.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `currencies`\n" +
                             "(`Currency`, `Description`, `AccountCode`, `ExchangeRateAccountCode`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtCurrency.Text.ToSqlValidString() + "', '" + txtDescription.Text.ToSqlValidString() + "', " + cboAccount.SelectedValue.ToString() + ", " + cboExchangeRateDiff.SelectedValue.ToString() + ", NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["Currency"].Ordinal] = txtCurrency.Text;
                    _values[_cols["Description"].Ordinal] = txtDescription.Text;
                    _values[_cols["AccountCode"].Ordinal] = cboAccount.SelectedValue;
                    _values[_cols["ExchangeRateAccountCode"].Ordinal] = cboExchangeRateDiff.SelectedValue;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _currencies.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `currencies` SET\n" +
                             "`Currency` = '" + txtCurrency.Text.ToSqlValidString() + "', `Description` = '" +  txtDescription.Text.ToSqlValidString() + "', `AccountCode` = " + cboAccount.SelectedValue.ToString() + ", `ExchangeRateAccountCode` = " + cboExchangeRateDiff.SelectedValue.ToString() + "\n" +
                             "WHERE\n" +
                             "(`Currency` LIKE '" + _currency.ToSqlValidString() + "');";

                    DataRow[] _existing = _currencies.Select("[Currency] LIKE '" + _currency.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["Currency"] = txtCurrency.Text;
                        _existing[0]["Description"] = txtDescription.Text;
                        _existing[0]["AccountCode"] = cboAccount.SelectedValue;
                        _existing[0]["ExchangeRateAccountCode"] = cboExchangeRateDiff.SelectedValue;
                    }
                }

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

                            string _log = "Added a new currency : " + txtCurrency.Text + ".";
                            if (!_isnew) _log = "Updated currency : " + _currency + (_currency != txtCurrency.Text ? " to " + txtCurrency.Text : "").ToString() + ".";

                            _currencies.AcceptChanges(); _currency = txtCurrency.Text;
                            if (_isnew) _isnew = false;
                            if (_updated) _updated = false;
                            if (!_withupdates) _withupdates = true;
                            Text = Text.Replace(" *", "").Replace("*", "");
                            Cursor = Cursors.WaitCursor;

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _log);
                            _logresult.WaitToFinish();

                            Cursor = Cursors.Default;

                            if (sender == btnSaveAndClose)
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                        }
                        else
                        {
                            if (_queresult.Error.Contains("duplicate"))
                            {
                                bool _invalid = Materia.Valid(_validator, txtCurrency, false, "Currency already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current currency.", "Save Currency");
                            }

                            _currencies.RejectChanges();
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
        {
            if (btnSaveAndClose.Enabled) btnSave_Click(btnSaveAndClose, new EventArgs());
        }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        { btnSave_Click(btnSave, new EventArgs()); }

        #endregion

    }
}
