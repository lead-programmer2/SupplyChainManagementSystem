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
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class UserInfoDialog : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of UserInfoDialog.
        /// </summary>
        public UserInfoDialog()
        {
            InitializeComponent(); AttachEditingHandlers();
        }

        /// <summary>
        /// Creates a new instance of UserInfoDialog.
        /// </summary>
        /// <param name="uid"></param>
        public UserInfoDialog(string uid)
        {
            InitializeComponent(); AttachEditingHandlers();

            _username = uid; _isnew = false;
        }

        /// <summary>
        /// Gets whether the current updated account is the currently logged system user account.
        /// </summary>
        public bool IsCurrentUser
        {
            get { return (SCMS.CurrentSystemUser.Username == _username); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isnew = true;

        /// <summary>
        /// Gets whether the dialog is now intended to create a new user account or not.
        /// </summary>
        public bool IsNew
        {
            get { return _isnew; }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _username = "";

        /// <summary>
        /// Gets the current updated system user's name.
        /// </summary>
        public string Username
        {
            get { return _username; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current dialog performs a data update while it is open or not.
        /// </summary>
        public bool WithUpdates
        {
            get { return _withupdates; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _shown = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _updated = false;

        private void AttachEditingHandlers()
        {
            txtPassword.TextChanged += new EventHandler(Field_Edited);
            txtFirstName.TextChanged += new EventHandler(Field_Edited);
            txtMiddleName.TextChanged += new EventHandler(Field_Edited);
            txtLastName.TextChanged += new EventHandler(Field_Edited);

            cboDepartment.SelectedIndexChanged += new EventHandler(Field_Edited);
            cboPosition.SelectedIndexChanged += new EventHandler(Field_Edited);

            chkActive.CheckedChanged += new EventHandler(Field_Edited);
            chkAllowAllCompanies.CheckedChanged += new EventHandler(Field_Edited);
            chkAllowAllCustomers.CheckedChanged += new EventHandler(Field_Edited);
            chkSuperUser.CheckedChanged += new EventHandler(Field_Edited);
        }

        private void InitializeDepartments()
        {
            DataTable _departments = Cache.GetCachedTable("departments");
            if (_departments != null)
            {
                DataTable _datasource = _departments.Replicate();
              
                cboDepartment.Enabled = false;
                if (cboDepartment.DataSource != null)
                {
                    try { ((DataTable)cboDepartment.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboDepartment.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _datasource.DefaultView.Sort = "[Department]";

                cboDepartment.DataSource = _datasource;
                cboDepartment.DisplayMember = "Department";
                cboDepartment.ValueMember = "Department";
                cboDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboDepartment.SelectedIndex = -1; }
                catch { }

                cboDepartment.Enabled = true;
            }
        }

        private void InitializePositions()
        {
            DataTable _positions = Cache.GetCachedTable("positions");
            if (_positions != null)
            {
                DataTable _datasource = _positions.Replicate();
                
                cboPosition.Enabled = false;
                if (cboPosition.DataSource != null)
                {
                    try { ((DataTable)cboPosition.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboPosition.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _datasource.DefaultView.Sort = "[Position]";
                cboPosition.DataSource = _datasource;
                cboPosition.DisplayMember = "Position";
                cboPosition.ValueMember = "Position";
                cboPosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboPosition.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboPosition.SelectedIndex = -1; }
                catch { }

                cboPosition.Enabled = true;
            }
        }

        private void InitializeUserInformation()
        {
            DataTable _users = Cache.GetCachedTable("users");
            if (_users != null)
            {
                DataRow[] _rows = _users.Select("[Username] LIKE '" + _username.ToSqlValidString(true) + "'");

                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    txtUsername.Text = _username;

                    if (!Materia.IsNullOrNothing(_row["Password"])) txtPassword.Text = _row["Password"].ToString().Decrypt(SCMS.EncryptionKey);
                    if (!Materia.IsNullOrNothing(_row["FirstName"])) txtFirstName.Text = _row["FirstName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["MiddleName"])) txtMiddleName.Text = _row["MiddleName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["LastName"])) txtLastName.Text = _row["LastName"].ToString();

                    if (!Materia.IsNullOrNothing(_row["Department"]))
                    {
                        try  { cboDepartment.SelectedValue = _row["Department"].ToString(); }
                        catch {}
                    }

                    if (!Materia.IsNullOrNothing(_row["Position"]))
                    {
                        try  { cboPosition.SelectedValue = _row["Position"].ToString(); }
                        catch {}
                    }

                    if (!Materia.IsNullOrNothing(_row["Active"])) chkActive.Checked = VisualBasic.CBool(_row["Active"]);
                    if (!Materia.IsNullOrNothing(_row["Role"])) chkSuperUser.Checked = (_row["Role"].ToString() == SystemUserInfo.SuperUserRole);
                    if (!Materia.IsNullOrNothing(_row["AllCustomers"])) chkAllowAllCustomers.Checked = VisualBasic.CBool(_row["AllCustomers"]);
                    if (!Materia.IsNullOrNothing(_row["AllCompanies"])) chkAllowAllCompanies.Checked = VisualBasic.CBool(_row["AllCompanies"]);
                }
            }
        }

        private void UserInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current user account. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void UserInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); tbctrl.SelectedTab = tbGeneral;

            txtUsername.SetAsRequired(); txtPassword.SetAsRequired(); 
            txtFirstName.SetAsRequired(); txtLastName.SetAsRequired(); 
            cboDepartment.SetAsRequired();cboPosition.SetAsRequired();

            grdCompanies.InitializeAppearance(); grdCustomers.InitializeAppearance();
            grdPrivileges.InitializeAppearance();

            txtUsername.ReadOnly = (_username == SCMS.CurrentSystemUser.Username);
            txtPassword.PasswordChar = Materia.PasswordCharacter;

            InitializeDepartments(); InitializePositions();
        }

        private void UserInfoDialog_Shown(object sender, EventArgs e)
        {
            if (!_isnew) InitializeUserInformation();
            if (!_shown) _shown = true;
            txtUsername.Focus();
        }

        private void Field_Edited(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!_shown) return;
            if (!_updated) _updated = true; 
            this.MarkAsEdited();
            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.ErrorProvider.SetError((Control)sender, "");
        }

        private void tbctrl_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (!_shown) return;
            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.Highlighter.UpdateHighlights();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!chkShowPassword.Enabled) return;
            if (!chkShowPassword.Checked) txtPassword.PasswordChar = Materia.PasswordCharacter;
            else txtPassword.PasswordChar = '\0';
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!btnSave.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtUsername, !String.IsNullOrEmpty(txtUsername.Text.RLTrim()), "Please specify the user account's logon name.")) return;
            if (!Materia.Valid(_validator, txtPassword, !String.IsNullOrEmpty(txtPassword.Text.RLTrim()), "Please specify the user account's password.")) return;
            if (!Materia.Valid(_validator, txtFirstName, !String.IsNullOrEmpty(txtFirstName.Text.RLTrim()), "Please specify the account holder's given name.")) return;
            if (!Materia.Valid(_validator, txtLastName, !String.IsNullOrEmpty(txtLastName.Text.RLTrim()), "Please specify the account holder's surname.")) return;
            if (!Materia.Valid(_validator, cboDepartment, cboDepartment.SelectedIndex >= 0, "Please specify a valid department.")) return;
            if (!Materia.Valid(_validator, cboPosition, cboPosition.SelectedIndex >= 0, "Please specify a valid position.")) return;

            DataTable _users = Cache.GetCachedTable("users");
            if (_users != null)
            {
                DataRow[] _exists = _users.Select("([Username] LIKE '" + txtUsername.Text.ToSqlValidString(true) + "') AND\n" +
                                                  "NOT ([Username] LIKE '" + _username.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtUsername, _exists.Length <= 0, "Username already exists.")) return;
                string _role = (chkSuperUser.Checked ? SystemUserInfo.SuperUserRole : SystemUserInfo.RegularUserRole).ToString();
                string _privileges = "";

                if (chkSuperUser.Checked)
                {
                    for (int i = 0; i <= 800; i++) _privileges += "1";
                }

                if (_isnew) _users.Rows.Add(new object[] {
                                            txtUsername.Text, txtPassword.Text.Encrypt(SCMS.EncryptionKey),
                                            txtFirstName.Text,txtMiddleName.Text, txtLastName.Text,
                                            cboPosition.SelectedValue.ToString(), cboDepartment.SelectedValue.ToString(),
                                            (chkActive.Checked? 1 : 0), _role, _privileges,
                                            (chkAllowAllCustomers.Checked? 1 : 0), (chkAllowAllCompanies.Checked? 1:0),
                                            DateTime.Now, DateTime.Now, 0, DBNull.Value });
                else
                {
                    DataRow[] _rows = _users.Select("[Username] LIKE '" + _username.ToSqlValidString(true) + "'");
                    if (_rows.Length > 0)
                    {
                        DataRow _row = _rows[0];
                        _row["Username"] = txtUsername.Text;
                        _row["Password"] = txtPassword.Text.Encrypt(SCMS.EncryptionKey);
                        _row["FirstName"] = txtFirstName.Text;
                        _row["MiddleName"] = txtMiddleName.Text;
                        _row["LastName"] = txtLastName.Text;
                        _row["Position"] = cboPosition.SelectedValue.ToString();
                        _row["Department"] = cboDepartment.SelectedValue.ToString();
                        _row["Active"] = (chkActive.Checked ? 1 : 0);
                        _row["Role"] = _role; _row["Privileges"] = _privileges;
                        _row["AllCustomers"] = (chkAllowAllCustomers.Checked ? 1 : 0);
                        _row["AllCompanies"] = (chkAllowAllCompanies.Checked ? 1 : 0);
                    }
                }

                QueryGenerator _generator = new QueryGenerator(_users);
                _generator.ExcludedFields.Add("LastModified");
                string _query = _generator.ToString(); _generator = null;
                Materia.RefreshAndManageCurrentProcess();
               
                if (!String.IsNullOrEmpty(_query.RLTrim()))
                {
                    if (Regex.IsMatch(_query, "WHERE[A-Za-z0-9\\s\\n\\r\\t\\W]+"))
                    {
                        string _tempquery = _query;
                        _query = Regex.Replace(_tempquery, "WHERE[A-Za-z0-9\\s\\n\\r\\t\\W]+", "WHERE (`Username` LIKE '" + _username.ToSqlValidString() + "')");
                    }

                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;
                    IAsyncResult _queresult = Que.BeginExecution(SCMS.Connection, _query);
                    while (!_queresult.IsCompleted &&
                           !_cancelled)
                    { Thread.Sleep(1); Application.DoEvents(); }

                    if (_cancelled)
                    {
                        if (!_queresult.IsCompleted)
                        {
                            try { _queresult = null; }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }
                    }
                    else
                    {
                        QueResult _result = Que.EndExecution(_queresult);

                        if (string.IsNullOrEmpty(_result.Error.RLTrim()))
                        {
                            _users.AcceptChanges(); Cache.Save();
                            if (!_withupdates) _withupdates = true;

                            Cursor = Cursors.WaitCursor;
                            
                            UserAction _action = UserAction.Add;
                            if (!_isnew) _action = UserAction.Edit;

                            string _logdescription = "Added a new system user account : " + txtUsername.Text + ".";
                            if (!_isnew) _logdescription = "Updated user account : " + _username + ".";

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _logdescription);
                            _logresult.WaitToFinish(); Cursor = Cursors.Default;

                            _isnew = false; _username = txtUsername.Text;
                            if (_updated) _updated = false; 
                            Text = Text.Replace(" *", "").Replace("*", "");
                          
                            if (sender == btnSaveAndClose)
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                        }
                        else
                        {
                            if (_result.Error.ToLower().Contains("duplicate")) Materia.Valid(_validator, txtUsername, false, "Username already exists.");
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_result.Error));
                                MsgBoxEx.Alert("Failed to save the user account.", "Save User Account");
                            }
                        }

                        _result.Dispose(); _result = null; Materia.RefreshAndManageCurrentProcess();
                        btnSave.Enabled = true; btnSaveAndClose.Enabled = true;
                    }
                }
                else
                {
                    if (_updated) _updated = false; 
                    Text = Text.Replace(" *", "").Replace("*", "");
                    if (sender == btnSaveAndClose)
                    { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                }
            }
            else
            {
                if (sender == btnSaveAndClose)
                { DialogResult = System.Windows.Forms.DialogResult.None; Close(); }
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!btnSaveAndClose.Enabled) return;
            btnSave_Click(btnSaveAndClose, new EventArgs());
        }

        private void chkSuperUser_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSuperUser.Enabled) return;
            if (!_shown) return;
            if (chkSuperUser.Checked)
            {
                chkAllowAllCompanies.Checked = true;
                chkAllowAllCustomers.Checked = true;
            }
        }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        { btnSave_Click(btnSave, new EventArgs()); }

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void lblAddDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DepartmentInfoDialog _dialog = new DepartmentInfoDialog();
            _dialog.ShowDialog();
            if (_dialog.WithUpdates)
            {
                InitializeDepartments();

                if (cboDepartment.DataSource != null)
                {
                    try { cboDepartment.SelectedValue = _dialog.Department; }
                    catch { }
                }
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void lblAddPosition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PositionInfoDialog _dialog = new PositionInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                InitializePositions();
                if (cboPosition.DataSource != null)
                {
                    try { cboPosition.SelectedValue = _dialog.Position; }
                    catch { }
                }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }


    }
}
