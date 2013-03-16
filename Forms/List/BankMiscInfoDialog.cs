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
    public partial class BankMiscInfoDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of BankMiscInfoDialog.
        /// </summary>
        public BankMiscInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of BankMiscInfoDialog.
        /// </summary>
        public BankMiscInfoDialog(string miscellaneous)
        {
            InitializeComponent();

            _bankmiscellaneous = miscellaneous; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _bankmiscellaneous = "";

        /// <summary>
        /// Gets the current update bank miscellaneous.
        /// </summary>
        public string BankMiscellaneous
        {
            get { return _bankmiscellaneous; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current bank miscellaneous conducts any updates while it is open.
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
            cboType.SelectedIndexChanged += new EventHandler(Field_Edited);
            cboAccount.SelectedValueChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _bankmisc = Cache.GetCachedTable("bankmiscellaneous");
            if (_bankmisc != null)
            {
                DataRow[] _rows = _bankmisc.Select("[BankMiscellaneous] LIKE '" + _bankmiscellaneous.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["BankMiscellaneous"])) txtDescription.Text = _row["BankMiscellaneous"].ToString();
                    if (VisualBasic.IsNumeric(_row["AccountCode"])) cboAccount.SelectedValue = _row["AccountCode"];
                    if (VisualBasic.IsNumeric(_row["Type"])) cboType.SelectedIndex = VisualBasic.CInt(_row["Type"]);
                }
            }

        }

        private void InitializeTypes()
        {
            cboType.Enabled = false;
            cboType.Items.Clear();
            cboType.Items.Add("Additional");
            cboType.Items.Add("Deduction");
            cboType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboType.SelectedIndex = 0;
            cboType.Enabled = true;
        }

        #endregion

        #region FormEvents

        private void BankMiscInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current bank miscellaneous. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void BankMiscInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboAccount.LoadAccounts(); InitializeTypes();

            txtDescription.SetAsRequired();
            cboAccount.SetAsRequired(); cboType.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void BankMiscInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtDescription, !string.IsNullOrEmpty(txtDescription.Text.RLTrim()), "Please specify bank miscellaneous.")) return;
            if (!Materia.Valid(_validator, cboAccount, cboAccount.SelectedIndex >= 0, "Please specify a valid account.")) return;
            if (!Materia.Valid(_validator, cboType,cboType.SelectedIndex >=0 , "Please specify a valid type.")) return;

            DataTable _bankmisc = Cache.GetCachedTable("bankmiscellaneous");

            if (_bankmisc != null)
            {
                DataRow[] _rows = _bankmisc.Select("([BankMiscellaneous] LIKE '" + txtDescription.Text.ToSqlValidString(true) + "') AND\n" +
                                                   "NOT ([BankMiscellaneous] LIKE '" + _bankmiscellaneous.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtDescription, _rows.Length <= 0, "Bank miscellaneous already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _bankmisc.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `bankmiscellaneous`\n" +
                             "(`BankMiscellaneous`, `AccountCode`, `Type`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtDescription.Text.ToSqlValidString() + "', " + cboAccount.SelectedValue.ToString() + ", " + cboType.SelectedIndex.ToString() + ", NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["BankMiscellaneous"].Ordinal] = txtDescription.Text;
                    _values[_cols["AccountCode"].Ordinal] = cboAccount.SelectedValue;
                    _values[_cols["Type"].Ordinal] = cboType.SelectedIndex;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _bankmisc.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `bankmiscellaneous` SET\n" +
                             "`BankMiscellaneous` = '" + txtDescription.Text.ToSqlValidString() + "', `AccountCode` = " + cboAccount.SelectedValue.ToString() + ", `Type` = " + cboType.SelectedIndex.ToString() + "\n" +
                             "WHERE\n" +
                             "(`BankMiscellaneous` LIKE '" + _bankmiscellaneous.ToSqlValidString() + "');";
                    DataRow[] _existing = _bankmisc.Select("[BankMiscellaneous] LIKE '" + _bankmiscellaneous.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["BankMiscellaneous"] = txtDescription.Text;
                        _existing[0]["AccountCode"] = cboAccount.SelectedValue;
                        _existing[0]["Type"] = cboType.SelectedIndex;
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

                            string _log = "Added a new bank miscellaneous : " + txtDescription.Text + ".";
                            if (!_isnew) _log = "Updated bank miscellaneous : " + _bankmiscellaneous + (_bankmiscellaneous != txtDescription.Text ? " to " + txtDescription.Text : "").ToString() + ".";

                            _bankmisc.AcceptChanges(); _bankmiscellaneous = txtDescription.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtDescription, false, "Bank miscellaneous already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current bank miscellaneous.", "Save Bank Miscellaneous");
                            }

                            _bankmisc.RejectChanges();
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
