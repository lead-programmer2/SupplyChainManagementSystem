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
    public partial class SignatoryInfoDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of SignatoryInfoDialog. 
        /// </summary>
        public SignatoryInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of SignatoryInfoDialog. 
        /// </summary>
        public SignatoryInfoDialog(long detailid)
        {
            InitializeComponent();

            _id = detailid; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long _id = 0;

        /// <summary>
        /// Gets the current updated signatory id number.
        /// </summary>
        public long Id
        {
            get { return _id; }
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current signatory conducts any updates while it is open.
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
            cboUsername.SelectedValueChanged += new EventHandler(Field_Edited);
            cboRole.SelectedValueChanged += new EventHandler(Field_Edited);
            txtBankLimit.ValueChanged += new EventHandler(Field_Edited);
            txtCashLimit.ValueChanged += new EventHandler(Field_Edited);
        }

        private void InitializeRoles()
        {
            string _path = Application.StartupPath + "\\Xml\\signatoryroles.xml";
            DataTable _roles = SCMS.XmlToTable(_path);

            if (_roles != null)
            {
                cboRole.Enabled = false;

                if (cboRole.DataSource != null)
                {
                    try { ((DataTable)cboRole.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboRole.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                cboRole.DataSource = _roles;
                cboRole.DisplayMember = "Role"; cboRole.ValueMember = "Id";
                cboRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboRole.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboRole.SelectedIndex = -1; }
                catch { }

                cboRole.Enabled = true;
            }
        }

        private void InitializeInfo()
        {
            DataTable _signatories = Cache.GetCachedTable("signatories");
            DataTable _users = Cache.GetCachedTable("users");

            if (_signatories != null &&
                _users != null)
            {
                var _query = from _signs in _signatories.AsEnumerable()
                             join _usr in _users.AsEnumerable() on _signs.Field<string>("Username") equals _usr.Field<string>("Username")
                             where _signs.Field<long>("DetailId") == _id
                             select new
                             {
                                 Username = _signs.Field<string>("Username"),
                                 RoleId = _signs.Field<int>("RoleId"),
                                 FullName = _usr.Field<string>("FirstName") + " " + _usr.Field<string>("LastName"),
                                 Department = _usr.Field<string>("Department"),
                                 Position = _usr.Field<string>("Position"),
                                 CashLimit = _signs.Field<decimal>("CashLimit"),
                                 BankLimit = _signs.Field<decimal>("BankLimit")
                             };

                foreach (var _row in _query)
                {
                    cboUsername.SelectedValue = _row.Username;
                    cboRole.SelectedValue = _row.RoleId;
                    txtFullName.Text = _row.FullName;
                    txtDepartment.Text = _row.Department;
                    txtPosition.Text = _row.Position;
                    txtBankLimit.Value = VisualBasic.CDbl(_row.BankLimit);
                    txtBankLimit.LockUpdateChecked = (_row.BankLimit > 0);
                    txtCashLimit.Value = VisualBasic.CDbl(_row.CashLimit);
                    txtCashLimit.LockUpdateChecked = (_row.CashLimit > 0);
                }
            }
        }

        #endregion

        #region FormEvents

        private void SignatoryInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current signatory. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void SignatoryInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboUsername.LoadUsers(); InitializeRoles();

            txtDepartment.ReadOnly = true; txtPosition.ReadOnly = true;
            txtFullName.ReadOnly = true;

            txtBankLimit.MinValue = 1; txtBankLimit.AllowEmptyState = false;
            txtBankLimit.ShowUpDown = false; txtBankLimit.ShowCheckBox = true;
            txtBankLimit.MaxValue = 999999; txtBankLimit.LockUpdateChecked = false;

            txtCashLimit.MinValue = 1; txtCashLimit.AllowEmptyState = false;
            txtCashLimit.ShowUpDown = false; txtCashLimit.ShowCheckBox = true;
            txtCashLimit.MaxValue = 999999; txtCashLimit.LockUpdateChecked = false;

            cboUsername.SetAsRequired(); cboRole.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void SignatoryInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, cboUsername, cboUsername.SelectedIndex >= 0, "Please specify signatory from the existing accounts.")) return;
            if (!Materia.Valid(_validator, cboRole, cboRole.SelectedIndex >= 0, "Please specify signatory role.")) return;

            DataTable _signatories = Cache.GetCachedTable("signatories");

            if (_signatories != null)
            {
                DataRow[] _rows = _signatories.Select("([Username] LIKE '" + cboUsername.SelectedValue.ToString().ToSqlValidString(true) + "' AND\n" +
                                                      " [RoleId] = " + cboRole.SelectedValue.ToString() + " AND\n" +
                                                      " [Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "') AND\n" +
                                                      "([DetailId] <> " + _id.ToString() + ")");

                if (!Materia.Valid(_validator, cboUsername, _rows.Length <= 0, "Signatory under the specified role already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _signatories.Columns;
                DataRow _newrow = null;

                if (_isnew)
                {
                    _query = "INSERT INTO `signatories`\n" +
                             "(`Username`, `RoleId`, `CashLimit`, `BankLimit`, `Company`)\n" +
                             "VALUES\n" +
                             "('" + cboUsername.SelectedValue.ToString().ToSqlValidString() + "', " + cboRole.SelectedValue.ToString() + ", " + (txtCashLimit.LockUpdateChecked? txtCashLimit.Value.ToSqlValidString() : "0") + ", " + (txtBankLimit.LockUpdateChecked? txtBankLimit.Value.ToSqlValidString() : "0") + ", '" + SCMS.CurrentCompany.Company.ToSqlValidString() + "');\n" +
                             "SELECT LAST_INSERT_ID() AS `Id`;";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["Username"].Ordinal] = cboUsername.SelectedValue;
                    _values[_cols["RoleId"].Ordinal] = cboRole.SelectedValue;
                    _values[_cols["CashLimit"].Ordinal] = (txtCashLimit.LockUpdateChecked ? txtCashLimit.Value : 0);
                    _values[_cols["BankLimit"].Ordinal] = (txtCashLimit.LockUpdateChecked ? txtCashLimit.Value : 0);
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _newrow =  _signatories.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `signatories` SET\n" +
                             "`Username` = '" + cboUsername.SelectedValue.ToString() + "', `RoleId` = " + cboRole.SelectedValue.ToString() + ", `CashLimit` = " + (txtCashLimit.LockUpdateChecked? txtCashLimit.Value.ToSqlValidString() : "0") + ", `BankLimit` = " + (txtBankLimit.LockUpdateChecked ? txtBankLimit.Value.ToSqlValidString() : "0") + "\n" +
                             "WHERE\n" +
                             "(`DetailId` = " + _id.ToString() + ");";

                    DataRow[] _existing = _signatories.Select("[DetailId] = " +  _id.ToString());
                    if (_existing.Length > 0)
                    {
                        _existing[0]["Username"] = cboUsername.SelectedValue;
                        _existing[0]["RoleId"] = cboRole.SelectedValue;
                        _existing[0]["CashLimit"] = (txtCashLimit.LockUpdateChecked ? txtCashLimit.Value : 0);
                        _existing[0]["BankLimit"] = (txtBankLimit.LockUpdateChecked ? txtBankLimit.Value : 0);
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

                            string _log = "Added a new signatory : " + txtFullName.Text + " as " + cboRole.Text.ToLower() + ".";
                            if (!_isnew) _log = "Updated signatory : " + txtFullName.Text + " as " + cboRole.Text.ToLower() + ".";

                            if (_queresult.ResultSet != null)
                            {
                                if (_queresult.ResultSet.Tables.Count > 0)
                                {
                                    DataTable _table = _queresult.ResultSet.Tables[0];
                                    if (_table.Rows.Count > 0)
                                    {
                                        DataRow _row = _table.Rows[0];
                                        if (VisualBasic.IsNumeric(_row["Id"]))
                                        {
                                            if (_newrow != null)
                                            {
                                                _id = VisualBasic.CLng(_row["Id"]);
                                                _newrow["DetailId"] = _row["Id"];
                                            }
                                        }
                                    }
                                }
                            }

                            _signatories.AcceptChanges(); 
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
                                bool _invalid = Materia.Valid(_validator, cboUsername, false, "Signatory with the specified role already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current signatory.", "Save Signatory");
                            }

                            _signatories.RejectChanges();
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

        private void cboUsername_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_isshown) return;
            if (!cboUsername.Enabled) return;
            if (cboUsername.DataSource == null) return;
            
            string _department = ""; string _position = "";
            string _fullname = "";

            if (cboUsername.SelectedValue != null)
            {
                _department = cboUsername.SelectedRow["Department"].ToString();
                _position = cboUsername.SelectedRow["Position"].ToString();
                _fullname = cboUsername.SelectedRow["AccountHolder"].ToString();
            }

            txtFullName.Text = _fullname; txtDepartment.Text = _department;
            txtPosition.Text = _position;
        }

        #endregion

    }
}
