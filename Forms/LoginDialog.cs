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
    public partial class LoginDialog : Office2007Form
    {

        /// <summary>
        /// Creates a new instance of LoginDialog.
        /// </summary>
        public LoginDialog()
        {
            InitializeComponent();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        private void CreateInitialCompanies(IDbConnection connection)
        {
            string _path = Application.StartupPath + "\\Xml\\defaultcompanies.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                Cache.SyncTable(connection, "companies");

                DataTable _cachedtable = Cache.GetCachedTable("companies");
                if (_cachedtable != null)
                {
                    string _query = "";

                    for (int i = 0; i <= (_table.Rows.Count - 1); i++)
                    {
                        DataRow _row = _table.Rows[i];
                        DataRow[] _rows = _cachedtable.Select("[Company] LIKE '" + _row["Company"].ToString().ToSqlValidString(true) + "'");
                        if (_rows.Length <= 0)
                        {
                            _query += "INSERT INTO `companies`\n" +
                                      "(`Company`, `Name`, `DateCreated`)\n" +
                                      "VALUES\n" +
                                      "('" + _row["Company"].ToString().ToSqlValidString() + "', '" + _row["Name"].ToString().ToSqlValidString() + "', NOW());\n";

                            DataColumnCollection _cols = _cachedtable.Columns;
                            object[] _values = new object[_cols.Count];
                            _values[_cols["Company"].Ordinal] = _row["Company"];
                            _values[_cols["Name"].Ordinal] = _row["Name"];
                            _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                            _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                            _cachedtable.Rows.Add(_values);
                        }
                    }

                    if (!String.IsNullOrEmpty(_query.RLTrim()))
                    {
                        QueResult _result = Que.Execute(connection, _query);
                        if (String.IsNullOrEmpty(_result.Error.RLTrim()))
                        { _cachedtable.AcceptChanges(); Cache.Save(); }
                        _result.Dispose(); _result = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void CreateInitialUser(IDbConnection connection)
        {
            string _path = Application.StartupPath + "\\Xml\\defaultusers.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataRow[] _rows = _table.Select("[ComputerName] = '" + Environment.MachineName.ToSqlValidString(true) + "' AND " +
                                                "[UserAccount] = '" + Environment.UserName.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    Cache.SyncTable(connection, "users");             
                    bool _exists = false;
                    DataTable _cachedtable = Cache.GetCachedTable("users");
                    if (_cachedtable != null)
                    {
                        DataRow[] _exrows = _cachedtable.Select("[Username] LIKE '" + _rows[0]["Username"].ToString().ToSqlValidString(true) + "'");
                        if (_exrows.Length > 0) _exists = true;
                    }

                    if (!_exists)
                    {
                        Cache.SyncTable(connection, "departments");
                        Cache.SyncTable(connection, "positions");

                        string _query = "";  _exists = false;

                        DataTable _depttable = Cache.GetCachedTable("departments");
                        if (_depttable != null)
                        {
                            DataRow[] _exrows = _depttable.Select("[Department] LIKE '" + _rows[0]["Department"].ToString().ToSqlValidString(true) + "'");
                            if (_exrows.Length > 0) _exists = true;
                        }

                        if (!_exists)
                        {
                            _query += "INSERT INTO `departments`\n" +
                                      "(`Department`, `DateCreated`)\n" +
                                      "VALUES\n" +
                                      "('" + _rows[0]["Department"].ToString().ToSqlValidString() + "', NOW());\n";

                            object[] _values = new object[_depttable.Columns.Count];
                            DataColumnCollection _cols = _depttable.Columns;
                            _values[_cols["Department"].Ordinal] = _rows[0]["Department"];
                            _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                            _values[_cols["LastModified"].Ordinal] = DateTime.Now;

                            _depttable.Rows.Add(_values);
                        }

                        _exists = false;

                        DataTable _postntable = Cache.GetCachedTable("positions");
                        if (_postntable != null)
                        {
                            DataRow[] _exrows = _postntable.Select("[Position] LIKE '" + _rows[0]["Position"].ToString().ToSqlValidString(true) + "'");
                            if (_exrows.Length > 0) _exists = true;
                        }

                        if (!_exists)
                        {
                            _query += "INSERT INTO `positions`\n" +
                                      "(`Position`, `DateCreated`)\n" +
                                      "VALUES\n" +
                                      "('" + _rows[0]["Position"].ToString().ToSqlValidString() + "', NOW());\n";

                            object[] _values = new object[_postntable.Columns.Count];
                            DataColumnCollection _cols = _postntable.Columns;
                            _values[_cols["Position"].Ordinal] = _rows[0]["Position"];
                            _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                            _values[_cols["LastModified"].Ordinal] = DateTime.Now;

                            _postntable.Rows.Add(_values);
                        }

                        StringBuilder _privileges = new StringBuilder();

                        for (int i = 1; i <= 700; i++) _privileges.Append("1");

                        _query += "INSERT INTO `users`\n" +
                                  "(`Username`, `Password`, `FirstName`, `MiddleName`, `LastName`, `Department`, `Position`, `Active`, `Role`, `Privileges`, `AllCustomers`, `AllCompanies`, `DateCreated`)\n" +
                                  "VALUES\n" +
                                  "('" + _rows[0]["Username"].ToString().ToSqlValidString() + "', '" + _rows[0]["Password"].ToString().Encrypt(SCMS.EncryptionKey).ToSqlValidString() + "', " +
                                  "'" + _rows[0]["FirstName"].ToString().ToSqlValidString() + "', '" + _rows[0]["MiddleName"].ToString().ToSqlValidString() + "', '" + _rows[0]["LastName"].ToString().ToSqlValidString() + "', " +
                                  "'" + _rows[0]["Department"].ToString().ToSqlValidString() + "', '" + _rows[0]["Position"].ToString().ToSqlValidString() + "', 1, '" + SystemUserInfo.SuperUserRole.ToSqlValidString() + "', " +
                                  "'" + _privileges.ToString() + "', 1, 1, NOW());";

                        QueResult _result = Que.Execute(connection, _query);
                        if (String.IsNullOrEmpty(_result.Error.RLTrim()))
                        {
                            if (_depttable != null) _depttable.AcceptChanges();
                            if (_postntable != null) _postntable.AcceptChanges();
                            if (_cachedtable != null)
                            {
                                object[] _values = new object[_cachedtable.Columns.Count];
                                DataColumnCollection _cols = _cachedtable.Columns;
                                _values[_cols["Username"].Ordinal] = _rows[0]["Username"];
                                _values[_cols["Password"].Ordinal] = _rows[0]["Password"].ToString().Encrypt(SCMS.EncryptionKey);
                                _values[_cols["FirstName"].Ordinal] = _rows[0]["FirstName"];
                                _values[_cols["MiddleName"].Ordinal] = _rows[0]["MiddleName"];
                                _values[_cols["LastName"].Ordinal] = _rows[0]["LastName"];
                                _values[_cols["Position"].Ordinal] = _rows[0]["Position"];
                                _values[_cols["Department"].Ordinal] = _rows[0]["Department"];
                                _values[_cols["Role"].Ordinal] = SystemUserInfo.SuperUserRole;
                                _values[_cols["Privileges"].Ordinal] = _privileges.ToString();
                                _values[_cols["AllCustomers"].Ordinal] = 1;
                                _values[_cols["AllCompanies"].Ordinal] = 1;
                                _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                                _values[_cols["DateVoided"].Ordinal] = DBNull.Value;

                                _cachedtable.Rows.Add(_values); _cachedtable.AcceptChanges();
                            }
                            Cache.Save();
                        }
                        else
                        {
                            if (_depttable != null) _depttable.RejectChanges();
                            if (_postntable != null) _postntable.RejectChanges();
                            if (_cachedtable != null) _cachedtable.RejectChanges();
                        }

                        _result.Dispose(); Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void InitializeCompanies()
        {
            string _path = Application.StartupPath + "\\Xml\\defaultcompanies.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                cboCompanies.Enabled = false;

                try { cboCompanies.DataSource = null; }
                catch { }
                finally { Materia.RefreshAndManageCurrentProcess(); }

                _table.Rows.Add(new string[] { "Company List...", "" });

                cboCompanies.DataSource = _table;
                cboCompanies.DisplayMember = "Company"; cboCompanies.ValueMember = "Company";
                cboCompanies.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboCompanies.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboCompanies.SelectedValue = SCMS.LastSelectedCompany; }
                catch { cboCompanies.SelectedIndex = -1; }

                cboCompanies.Enabled = true;
            }
        }

        private void InitializeServers()
        {
            string _path = Application.StartupPath + "\\Xml\\databaseconnections.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                cboServers.Enabled = false;
                
                try { cboServers.DataSource = null; }
                catch { }
                finally { Materia.RefreshAndManageCurrentProcess(); }

                _table.Rows.Add(new string[] { "Server List...", "", "", "", "" });

                cboServers.DataSource = _table;
                cboServers.DisplayMember = "Name"; cboServers.ValueMember = "Name";
                cboServers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboServers.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboServers.SelectedValue = SCMS.LastSelectedConnection; }
                catch { cboServers.SelectedIndex = -1; }

                cboServers.Enabled = true;
            }
        }

        private void LoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SCMS.CurrentSystemUser == null) _cancelled = true;
            SCMS.Connection = null;
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            SCMS.Validators.Add(this); pctLoad.Hide(); pnlNotification.Hide();
            txtPassword.PasswordChar = Materia.PasswordCharacter;

            InitializeServers(); InitializeCompanies();
        }

        private void cboServers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!cboServers.Enabled) return;
            if (cboServers.DataSource == null) return;
            if (cboServers.SelectedIndex < 0) return;
            if (cboServers.SelectedValue == null) return;

            if (cboServers.SelectedValue.ToString() == "Server List...")
            {
                ConnectionsAndCompaniesDialog _dialog = new ConnectionsAndCompaniesDialog();
                _dialog.ShowDialog(); InitializeServers();
                try { _dialog.Dispose(); }
                catch { }
                Materia.RefreshAndManageCurrentProcess();

                try { cboServers.SelectedValue = SCMS.LastSelectedConnection; }
                catch { cboServers.SelectedIndex = -1; }
            }
            else SCMS.LastSelectedConnection = cboServers.SelectedValue.ToString();
         }

        private void cboCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!cboCompanies.Enabled) return;
            if (cboCompanies.DataSource == null) return;
            if (cboCompanies.SelectedIndex < 0) return;
            if (cboCompanies.SelectedValue == null) return;

            if (cboCompanies.SelectedValue.ToString() == "Company List...")
            {
                ConnectionsAndCompaniesDialog _dialog = new ConnectionsAndCompaniesDialog(ConnectionSetting.Companies);
                _dialog.ShowDialog(); InitializeCompanies();
                try { _dialog.Dispose(); }
                catch { }
                Materia.RefreshAndManageCurrentProcess();

                try { cboCompanies.SelectedValue = SCMS.LastSelectedCompany; }
                catch { cboCompanies.SelectedIndex = -1; }
            }
            else SCMS.LastSelectedCompany = cboCompanies.SelectedValue.ToString();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!btnSignIn.Enabled) return;

            Validator _validator = SCMS.Validators[this]; pnlNotification.Hide();

            if (!Materia.Valid(_validator, cboServers, cboServers.SelectedIndex >= 0, "Select a database server.")) return;
            if (!Materia.Valid(_validator, cboCompanies, cboCompanies.SelectedIndex >= 0, "Select access company.")) return;

            SCMS.ServerConnection = null; SCMS.Connection = null;
            Materia.RefreshAndManageCurrentProcess();

            if (String.IsNullOrEmpty(txtUsername.Text.RLTrim()) ||
                String.IsNullOrEmpty(txtPassword.Text.RLTrim()))
            {
                pnlNotification.Text = "Invalid account credentials.";
                pnlNotification.Show(); pnlNotification.BringToFront();
                return;
            }

            ServerConnectionInfo _info = new ServerConnectionInfo(cboServers.SelectedValue.ToString());

            pctLoad.Show(); pctLoad.BringToFront();
            btnSignIn.Enabled = false; cboServers.Enabled = false; cboCompanies.Enabled = false;

            IDbConnection _connection = Database.CreateConnection(_info.ToString());

            Func<IDbConnection, bool> _connectdelegate = new Func<IDbConnection, bool>(Materia.CanConnect);
            IAsyncResult _connectresult = _connectdelegate.BeginInvoke(_connection, null, _connectdelegate);

            while (!_connectresult.IsCompleted &&
                   !_cancelled)
            {
                Thread.Sleep(1); Application.DoEvents();
            }

            bool _connected = false;

            if (_cancelled)
            {
                if (!_connectresult.IsCompleted)
                {
                    try { _connectresult = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }
            }
            else
            {
                _connected = _connectdelegate.EndInvoke(_connectresult);
                if (!_connected) MsgBoxEx.Alert("Failed to connect to the specified database server.", "Database Connection");
            }

            if (!_connected)
            {
                if (_connection != null)
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        try { _connection.Close(); }
                        catch { }
                    }

                    try { _connection.Dispose(); }
                    catch { }

                    _connection = null; Materia.RefreshAndManageCurrentProcess();
                }

                 cboServers.Enabled = true; cboCompanies.Enabled = true;
                 btnSignIn.Enabled = true; pctLoad.Hide(); return;
            }

            SCMS.Connection = _connection; SCMS.ServerConnection = new ServerConnectionInfo(cboServers.SelectedValue.ToString());
            SCMS.CurrentCompany = new CompanyInfo(cboCompanies.SelectedValue.ToString());

            Func<IDbConnection, string, DateTime> _getvaluedelegate = new Func<IDbConnection, string, DateTime>(Que.GetValue<DateTime>);
            IAsyncResult _getvalueresult = _getvaluedelegate.BeginInvoke(_connection, "SELECT MAX(`LastRestored`) AS `Date` FROM `settings`", null, _getvaluedelegate);
            _getvalueresult.WaitToFinish();
            DateTime _dbtimestamp = _getvaluedelegate.EndInvoke(_getvalueresult);
            DateTime _timestamp = Cache.LastRestoration;

            if (_dbtimestamp > _timestamp)
            { Cache.Clear(); Cache.UpdateCacheTimeStamp(_dbtimestamp);  }

            Action<IDbConnection> _inituserdelegate = new Action<IDbConnection>(CreateInitialUser);
            IAsyncResult _inituserresult = _inituserdelegate.BeginInvoke(SCMS.Connection, null, _inituserdelegate);

            while (!_inituserresult.IsCompleted &&
                   !_cancelled)
            { Thread.Sleep(1); Application.DoEvents(); }

            if (_cancelled)
            {
                if (!_inituserresult.IsCompleted)
                {
                    try { _inituserresult = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }

                return;
            }
            else
            {
                Action<IDbConnection> _initcompaniesdelegate = new Action<IDbConnection>(CreateInitialCompanies);
                IAsyncResult _initcompaniesresult = _initcompaniesdelegate.BeginInvoke(SCMS.Connection, null, _initcompaniesdelegate);

                while (!_cancelled &&
                       !_initcompaniesresult.IsCompleted)
                { Thread.Sleep(1); Application.DoEvents(); }

                if (_cancelled)
                {
                    if (_initcompaniesresult.IsCompleted)
                    {
                        try { _initcompaniesresult = null; }
                        catch { }
                        finally { Materia.RefreshAndManageCurrentProcess(); }
                    }

                    return;
                }
                else
                {
                    SCMS.CurrentSystemUser = null; Materia.RefreshAndManageCurrentProcess();
                    SystemUserInfo _userinfo = new SystemUserInfo(txtUsername.Text, txtPassword.Text);

                    IAsyncResult _loginasync = _userinfo.LogInAsync();

                    while (!_loginasync.IsCompleted &&
                           !_cancelled)
                    {
                        Thread.Sleep(1); Application.DoEvents();
                    }

                    if (_cancelled)
                    {
                        if (!_loginasync.IsCompleted)
                        {
                            try { _loginasync = null; }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }
                    }
                    else
                    {
                        if (_userinfo.IsSignedIn)
                        {
                            SCMS.CurrentSystemUser = _userinfo;
                            InitializerDialog _loader = new InitializerDialog();
                            _loader.Message = "Gathering application settings for " + SCMS.CurrentCompany.Company + ".";
                            txtPassword.Text = ""; Hide(); _loader.Show();

                            IAsyncResult _gsresult = GlobalSettings.RefreshAsync(SCMS.CurrentCompany.Company);
                            _gsresult.WaitToFinish(); SCMS.CleanUp();

                            _loader.Close(); _loader.Dispose(); _loader = null;
                            Materia.RefreshAndManageCurrentProcess();
                            MainWindow _main = new MainWindow(); _main.Show();
                        }
                        else
                        {
                            if (_userinfo.IsValidUser &&
                                !_userinfo.IsActive)
                            {
                                pnlNotification.Text = "Account needs activation.";
                                pnlNotification.Show(); pnlNotification.BringToFront();
                            }
                            else
                            {
                                if (_userinfo.IsValidUser &&
                                    !_userinfo.AccessibleCompanies.Contains(SCMS.CurrentCompany.Company))
                                {
                                    pnlNotification.Text = "Account not allowed in selected company.";
                                    pnlNotification.Show(); pnlNotification.BringToFront();
                                }
                                else
                                {
                                    pnlNotification.Text = "Invalid account credentials.";
                                    pnlNotification.Show(); pnlNotification.BringToFront();
                                }
                            }

                            _userinfo = null; Materia.RefreshAndManageCurrentProcess();
                        }

                        cboCompanies.Enabled = true; cboServers.Enabled = true;
                        btnSignIn.Enabled = true; pctLoad.Hide();
                    }
                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == VisualBasic.Chr(13)) btnSignIn_Click(btnSignIn, new EventArgs());
        }

        private void LoginDialog_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                string _path = Application.StartupPath + "\\Xml\\defaultusers.xml";
                DataTable _table = SCMS.XmlToTable(_path);

                if (_table != null)
                {
                    DataRow[] _rows = _table.Select("[ComputerName] LIKE '" + Environment.MachineName.ToSqlValidString(true) + "' AND [UserAccount] LIKE '" + Environment.UserName.ToSqlValidString(true) + "'");
                    if (_rows.Length > 0)
                    {
                        txtUsername.Text = _rows[0]["Username"].ToString();
                        txtPassword.Text = _rows[0]["Password"].ToString();
                    }

                    _table.Dispose(); _table = null; 
                    Materia.RefreshAndManageCurrentProcess();
                }
            }
        }

    }
}
