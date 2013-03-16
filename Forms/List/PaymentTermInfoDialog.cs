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
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class PaymentTermInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of PaymentTermInfoDialog.
        /// </summary>
        public PaymentTermInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of PaymentTermInfoDialog.
        /// </summary>
        public PaymentTermInfoDialog(string term)
        {
            InitializeComponent();

            _paymentterm = term; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _paymentterm = "";

        /// <summary>
        /// Gets the current updated payment term.
        /// </summary>
        public string PaymentTerm
        {
            get { return _paymentterm; }
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
            txtPaymentTerm.TextChanged += new EventHandler(Field_Edited);
            txtDescription.TextChanged += new EventHandler(Field_Edited);
            cboTerms.SelectedValueChanged += new EventHandler(Field_Edited);
            txtDays.ValueChanged += new EventHandler(Field_Edited);
            txtMonths.ValueChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _paymentterms = Cache.GetCachedTable("paymentterms");
            if (_paymentterms != null)
            {
                DataRow[] _rows = _paymentterms.Select("[PaymentTerm] LIKE '" + _paymentterm.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["PaymentTerm"])) txtPaymentTerm.Text = _row["PaymentTerm"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Description"])) txtDescription.Text = _row["Description"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Term"])) cboTerms.SelectedValue = _row["Term"].ToString();
                    if (VisualBasic.IsNumeric(_row["Days"])) txtDays.Value = VisualBasic.CInt(_row["Days"]);
                    if (VisualBasic.IsNumeric(_row["Months"])) txtMonths.Value = VisualBasic.CInt(_row["Months"]);
                }
            }
        }

        private void InitializeTerms()
        {
            string _path = Application.StartupPath + "\\Xml\\terms.xml";
            DataTable _terms = SCMS.XmlToTable(_path);

            if (_terms != null)
            {
                cboTerms.Enabled = false;

                if (cboTerms.DataSource != null)
                {
                    try { ((DataTable)cboTerms.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboTerms.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                cboTerms.DataSource = _terms;
                cboTerms.DisplayMember = "Term"; cboTerms.ValueMember = "Term";
                cboTerms.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboTerms.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboTerms.SelectedIndex = -1; }
                catch { }

                cboTerms.Enabled = true;
            }
        }

        #endregion

        #region FormEvents

        private void PaymentTermInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current payment term. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void PaymentTermInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            InitializeTerms();

            txtPaymentTerm.SetAsRequired(); cboTerms.SetAsRequired();

            txtDays.ShowUpDown = false; txtDays.AllowEmptyState = false;
            txtDays.MinValue = 0; txtDays.MaxValue = 30;

            txtMonths.ShowUpDown = false; txtMonths.AllowEmptyState = false;
            txtMonths.MinValue = 0; txtMonths.MaxValue = 48;

            if (!_isnew) InitializeInfo();
        }

        private void PaymentTermInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtPaymentTerm, !string.IsNullOrEmpty(txtPaymentTerm.Text.RLTrim()), "Please specify payment term.")) return;
            if (!Materia.Valid(_validator, cboTerms, cboTerms.SelectedIndex >= 0, "Please specify term.")) return;

            DataTable _paymentterms = Cache.GetCachedTable("paymentterms");

            if (_paymentterms != null)
            {
                DataRow[] _rows = _paymentterms.Select("([PaymentTerm] LIKE '" + txtPaymentTerm.Text.ToSqlValidString(true) + "') AND\n" +
                                                       "NOT ([PaymentTerm] LIKE '" + _paymentterm.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtPaymentTerm, _rows.Length <= 0, "Payment term already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _paymentterms.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `paymentterms`\n" +
                             "(`PaymentTerm`, `Description`, `Term`, `Days`, `Months`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtPaymentTerm.Text.ToSqlValidString() + "', '" + txtDescription.Text.ToSqlValidString(true) + "', '" + cboTerms.SelectedValue.ToString().ToSqlValidString(true) + "', " + txtDays.Value.ToString() + ", " + txtMonths.Value.ToString() + ", NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["PaymentTerm"].Ordinal] = txtPaymentTerm.Text;
                    _values[_cols["Description"].Ordinal] = txtDescription.Text;
                    _values[_cols["Term"].Ordinal] = cboTerms.SelectedValue;
                    _values[_cols["Days"].Ordinal] = txtDays.Value;
                    _values[_cols["Months"].Ordinal] = txtMonths.Value;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _paymentterms.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `paymentterms` SET\n" +
                             "`PaymentTerm` = '" + txtPaymentTerm.Text.ToSqlValidString() + "', `Description` = '" + txtDescription.Text.ToSqlValidString() + "', `Term` = '" + cboTerms.SelectedValue.ToString().ToSqlValidString() + "', `Days` = " + txtDays.Value.ToString() + ", `Months` = " + txtMonths.Value.ToString() + "\n" +
                             "WHERE\n" +
                             "(`PaymentTerm` LIKE '" + _paymentterm.ToSqlValidString() + "');";

                    DataRow[] _existing = _paymentterms.Select("[PaymentTerm] LIKE '" + _paymentterm.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["PaymentTerm"] = txtPaymentTerm.Text;
                        _existing[0]["Description"] = txtDescription.Text;
                        _existing[0]["Term"] = cboTerms.SelectedValue;
                        _existing[0]["Days"] = txtDays.Value;
                        _existing[0]["Months"] = txtMonths.Value;
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

                            string _log = "Added a new payment term : " + txtPaymentTerm.Text + ".";
                            if (!_isnew) _log = "Updated payment term : " + _paymentterm + (_paymentterm != txtPaymentTerm.Text ? " to " + txtPaymentTerm.Text : "").ToString() + ".";

                            _paymentterms.AcceptChanges(); _paymentterm = txtPaymentTerm.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtPaymentTerm, false, "Payment term already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current payment term.", "Save Payment Term");
                            }

                            _paymentterms.RejectChanges();
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
