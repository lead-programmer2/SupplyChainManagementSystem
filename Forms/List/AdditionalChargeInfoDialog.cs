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
    public partial class AdditionalChargeInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of AdditionalChargeInfoDialog. 
        /// </summary>
        public AdditionalChargeInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of AdditionalChargeInfoDialog. 
        /// </summary>
        public AdditionalChargeInfoDialog(string description)
        {
            InitializeComponent();

            _additionalcharge = description; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _additionalcharge = "";

        /// <summary>
        /// Gets the current updated additional charge.
        /// </summary>
        public string AdditionalCharge
        {
            get { return _additionalcharge; }
            set { _additionalcharge = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current additional charge conducts any updates while it is open.
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
            cboGroup.SelectedValueChanged += new EventHandler(Field_Edited);
            cboAccount.SelectedValueChanged += new EventHandler(Field_Edited);
        }

       private void InitializeGroups()
       {
            string _path = Application.StartupPath + "\\Xml\\chargegroups.xml";
            DataTable _groups = SCMS.XmlToTable(_path);

            if (_groups != null)
            {
                cboGroup.Enabled = false;
                if (cboGroup.DataSource != null)
                {
                    try { ((DataTable)cboGroup.DataSource).Dispose(); }
                    catch { }
                    finally 
                    {
                        cboGroup.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess(); 
                    }
                }

                cboGroup.DataSource = _groups;
                cboGroup.DisplayMember = "Group"; cboGroup.ValueMember = "Id";
                cboGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboGroup.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboGroup.SelectedIndex = -1; }
                catch { }

                cboGroup.Enabled = true;
            }
        }

        private void InitializeInfo()
        {
            DataTable _additionalcharges = Cache.GetCachedTable("additionalcharges");
            if (_additionalcharges != null)
            {
                DataRow[] _rows = _additionalcharges.Select("[AdditionalCharge] LIKE '" + _additionalcharge.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["AdditionalCharge"])) txtDescription.Text = _row["AdditionalCharge"].ToString();
                    if (VisualBasic.IsNumeric(_row["ChargeGroup"])) cboGroup.SelectedValue = _row["ChargeGroup"];
                    if (VisualBasic.IsNumeric(_row["AccountCode"])) cboAccount.SelectedValue = _row["AccountCode"];
                }
            }
        }

        #endregion

        #region FormEvents

        private void AdditionalChargeInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current additional charge. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void AdditionalChargeInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboAccount.LoadAccounts(); InitializeGroups();
          
            txtDescription.SetAsRequired();
            cboGroup.SetAsRequired(); cboAccount.SetAsRequired();
            
            if (!_isnew) InitializeInfo();
        }

        private void AdditionalChargeInfoDialog_Shown(object sender, EventArgs e)
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

        private void cboGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_isshown) return;
            if (!cboGroup.Enabled) return;
            if (cboGroup.DataSource == null) return;
            if (cboGroup.SelectedIndex < 0) return;
            if (cboAccount.SelectedIndex >= 0) return;
            if (cboAccount.DataSource == null) return;
            if (!VisualBasic.IsNumeric(cboGroup.SelectedValue)) return;

            DataTable _datasource = null;

            try { _datasource = (DataTable)cboGroup.DataSource; }
            catch { }

            if (_datasource != null)
            {
                DataRow[] _rows = _datasource.Select("[Id] = " + cboGroup.SelectedValue.ToString());
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    try { cboAccount.SelectedValue = _row["DefaultAccount"]; }
                    catch { }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtDescription, !string.IsNullOrEmpty(txtDescription.Text.RLTrim()), "Please specify additional charge's description.")) return;
            if (!Materia.Valid(_validator, cboGroup, cboGroup.SelectedIndex >= 0, "Please specify a proper charge group.")) return;
            if (!Materia.Valid(_validator, cboAccount, cboAccount.SelectedIndex >= 0, "Please specify a proper account.")) return;

            DataTable _additionalcharges = Cache.GetCachedTable("additionalcharges");

            if (_additionalcharges != null)
            {
                DataRow[] _rows = _additionalcharges.Select("([AdditionalCharge] LIKE '" + txtDescription.Text.ToSqlValidString(true) + "') AND\n" +
                                                            "NOT ([AdditionalCharge] LIKE '" + _additionalcharge.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtDescription, _rows.Length <= 0, "Additional charge already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _additionalcharges.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `additionalcharges`\n" +
                             "(`AdditionalCharge`, `ChargeGroup`, `AccountCode`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtDescription.Text.ToSqlValidString() + "', " + cboGroup.SelectedValue.ToString() + ", " + cboAccount.SelectedValue.ToString() + ", NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["AdditionalCharge"].Ordinal] = txtDescription.Text;
                    _values[_cols["ChargeGroup"].Ordinal] = cboGroup.SelectedValue;
                    _values[_cols["AccountCode"].Ordinal] = cboAccount.SelectedValue;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _additionalcharges.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `additionalcharges` SET\n" +
                             "`AdditionalCharge` = '" + txtDescription.Text.ToSqlValidString() + "', `ChargeGroup` = " + cboGroup.SelectedValue.ToString() + ", `AccountCode` = " + cboAccount.SelectedValue.ToString() + "\n" +
                             "WHERE\n" +
                             "(`AdditionalCharge` LIKE '" + _additionalcharge.ToSqlValidString() + "');";
                    DataRow[] _existing = _additionalcharges.Select("[AdditionalCharge] LIKE '" + _additionalcharge.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["AdditionalCharge"] = txtDescription.Text;
                        _existing[0]["ChargeGroup"] = cboGroup.SelectedValue;
                        _existing[0]["AccountCode"] = cboAccount.SelectedValue;
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

                            string _log = "Added a new additional charge : " + txtDescription.Text + ".";
                            if (!_isnew) _log = "Updated additional charge : " + _additionalcharge + (_additionalcharge != txtDescription.Text ? " to " + txtDescription.Text : "").ToString() + ".";

                            _additionalcharges.AcceptChanges(); _additionalcharge = txtDescription.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtDescription, false, "Additional charge already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current additional charge.", "Save Additional Charge");
                            }

                            _additionalcharges.RejectChanges();
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
