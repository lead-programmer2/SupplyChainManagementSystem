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
    public partial class CurrencyDenominationInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of CurrencyDenominationInfoDialog.
        /// </summary>
        public CurrencyDenominationInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of CurrencyDenominationInfoDialog.
        /// </summary>
        /// <param name="detailid"></param>
        public CurrencyDenominationInfoDialog(long detailid)
        {
            InitializeComponent();

            _id = detailid; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long _id = 0;

        /// <summary>
        /// Gets the current updated currency denomination id number.
        /// </summary>
        public long Id
        {
            get { return _id; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current currency denomination conducts any updates while it is open.
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
            txtValue.ValueChanged += new EventHandler(Field_Edited);
            cboCurrency.SelectedValueChanged += new EventHandler(Field_Edited);
            chkActive.CheckedChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _denominations = Cache.GetCachedTable("currencydenominations");
            if (_denominations != null)
            {
                DataRow[] _rows = _denominations.Select("[DetailId] = " + _id.ToString());
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (VisualBasic.IsNumeric(_row["Denomination"])) txtValue.Value = VisualBasic.CDbl(_row["Denomination"]);
                    if (!Materia.IsNullOrNothing(_row["Currency"])) cboCurrency.SelectedValue = _row["Currency"];
                    if (VisualBasic.IsNumeric(_row["Active"])) chkActive.Checked = VisualBasic.CBool(_row["Active"]);
                }
            }
        }

        #endregion

        #region FormEvents

        private void CurrencyDenominationInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current currency denomination. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void CurrencyDenominationInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboCurrency.LoadCurrencies();

            txtValue.MinValue = 0; txtValue.AllowEmptyState = false;
            txtValue.ShowUpDown = false; txtValue.MaxValue = 50000;
            txtValue.DisplayFormat = "N2";

            txtValue.SetAsRequired(); cboCurrency.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void CurrencyDenominationInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtValue, txtValue.Value > 0, "Please specify currency denomination value.")) return;
            if (!Materia.Valid(_validator, cboCurrency, cboCurrency.SelectedIndex >= 0, "Please specify a valid currency.")) return;

            DataTable _denominations = Cache.GetCachedTable("currencydenominations");
            DataRow _newrow = null;

            if (_denominations != null)
            {
                DataRow[] _rows = _denominations.Select("([Denomination] = " + txtValue.Value.ToSqlValidString() + " AND\n" +
                                                        " [Currency] LIKE '" + cboCurrency.SelectedValue.ToString().ToSqlValidString(true) + "') AND\n" +
                                                        "([DetailId] <> " + _id.ToString() + ")");

                if (!Materia.Valid(_validator, txtValue, _rows.Length <= 0, "Currency denomination already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _denominations.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `currencydenominations`\n" +
                             "(`Currency`, `Denomination`, `Active`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + cboCurrency.SelectedValue.ToString().ToSqlValidString(true) + "', " + txtValue.Value.ToSqlValidString() + ", " + (chkActive.Checked? "1" : "0").ToString() + ", NOW());\n" +
                             "SELECT LAST_INSERT_ID() AS `Id`;";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["Currency"].Ordinal] = cboCurrency.SelectedValue;
                    _values[_cols["Denomination"].Ordinal] = txtValue.Value;
                    _values[_cols["Active"].Ordinal] = (chkActive.Checked ? 1 : 0);
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _newrow =  _denominations.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `currencydenominations` SET\n" +
                             "`Currency` = '" + cboCurrency.SelectedValue.ToString().ToSqlValidString() + "', `Denomination` = " + txtValue.Value.ToSqlValidString() + ", `Active` = " + (chkActive.Checked? "1" : "0").ToString() + "\n" +
                             "WHERE\n" +
                             "(`DetailId` = " + _id.ToString() + ");";

                    DataRow[] _existing = _denominations.Select("[DetailId] = " + _id.ToString());
                    if (_existing.Length > 0)
                    {
                        _existing[0]["Currency"] = cboCurrency.SelectedValue;
                        _existing[0]["Denomination"] = txtValue.Value;
                        _existing[0]["Active"] = (chkActive.Checked? 1 : 0);
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

                            string _log = "Added a new currency denomination : " + txtValue.Value.ToSqlValidString() + " " + cboCurrency.SelectedValue.ToString() + ".";
                            if (!_isnew) _log = "Updated currency denomination : " + txtValue.Value.ToSqlValidString() + " " + cboCurrency.SelectedValue.ToString() + ".";
                    
                            if (_isnew)
                            {
                                if (_queresult.ResultSet.Tables.Count > 0)
                                {
                                    DataTable _table = _queresult.ResultSet.Tables[0];
                                    if (_table.Rows.Count > 0)
                                    {
                                        DataRow _row = _table.Rows[0];
                                        if (VisualBasic.IsNumeric(_row["Id"]))
                                        {
                                            _id = VisualBasic.CLng(_row["Id"]);
                                            if (_newrow != null) _newrow["DetailId"] = _id;
                                        }
                                    }
                                }
                            }

                            _denominations.AcceptChanges();

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
                                bool _invalid = Materia.Valid(_validator, txtValue, false, "Currency denomination already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current currency denomination.", "Save Currency Denomination");
                            }

                            _denominations.RejectChanges();
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
