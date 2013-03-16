using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// System user actions.
    /// </summary>
    public enum UserAction
    {
        /// <summary>
        /// Adds new record / transaction.
        /// </summary>
        Add = 0,
        /// <summary>
        /// Perform database backup to local or network drive.
        /// </summary>
        BackupDatabase = 12,
        /// <summary>
        /// Deletes record / transaction.
        /// </summary>
        Delete = 2,
        /// <summary>
        /// Updates record / transaction.
        /// </summary>
        Edit = 1,
        /// <summary>
        /// Executes a database script file.
        /// </summary>
        ExecuteScript = 19,
        /// <summary>
        /// Exports system-defined file from the application.
        /// </summary>
        ExportEdi = 8,
        /// <summary>
        /// Exports Microsoft Excel file from the application.
        /// </summary>
        ExportExcel = 5,
        /// <summary>
        /// Exports Portable Document (pdf) file from the application.
        /// </summary>
        ExportPdf = 6,
        /// <summary>
        /// Exports Extensive Markup Language (xml) file from the application.
        /// </summary>
        ExportXml = 7,
        /// <summary>
        /// Finalizes / closes any transaction.
        /// </summary>
        FinalizeTransaction = 17,
        /// <summary>
        /// Imports system-defined file into the application.
        /// </summary>
        ImportEdi = 10,
        /// <summary>
        /// Imports Microsoft Excel file into the application.
        /// </summary>
        ImportExcel = 9,
        /// <summary>
        /// Imports Extensive Markup Language (xml) file into the application.
        /// </summary>
        ImportXml = 11,
        /// <summary>
        /// Signs into the application.
        /// </summary>
        Login = 15,
        /// <summary>
        /// Signs off from the application.
        /// </summary>
        Logout = 16,
        /// <summary>
        /// Runs database maintenance.
        /// </summary>
        MaintainDatabase = 14,
        /// <summary>
        /// Previews available printable report.
        /// </summary>
        Preview = 3,
        /// <summary>
        /// Prints any avilable printable report.
        /// </summary>
        Print = 4,
        /// <summary>
        /// Perform database restoration from a local or network drive.
        /// </summary>
        RestoreDatabase = 13,
        /// <summary>
        /// Created by the system.
        /// </summary>
        SystemGenerated = 18
    }

    /// <summary>
    /// Application user information.
    /// </summary>
    public class SystemUserInfo
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of SystemUserInfo.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public SystemUserInfo(string uid, string pwd)
        { 
            _username = uid; _password = pwd;
            _accessiblecompanies = new CompanyInfoCollection(this);
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CompanyInfoCollection _accessiblecompanies = null;

        /// <summary>
        /// Gets the list of allowed companies for the specified system user if current system user is not allowed to access all existing companies.
        /// </summary>
        public CompanyInfoCollection AccessibleCompanies
        {
            get { return _accessiblecompanies; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _department = "";

        /// <summary>
        /// Gets the current system user's associated department.
        /// </summary>
        public string Department
        {
            get { return _department; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _firstname = "";

        /// <summary>
        /// Gets the current system user's given name.
        /// </summary>
        public string FirstName
        {
            get { return _firstname; }
        }

        /// <summary>
        /// Gets the current system user's full name.
        /// </summary>
        public string FullName
        {
            get { return _firstname.RLTrim() + (!String.IsNullOrEmpty(_firstname.RLTrim()) && !String.IsNullOrEmpty(_lastname.RLTrim()) ? " " : "").ToString() + _lastname; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isactive = false;

        /// <summary>
        /// Gets whether the current system user's account is active or inactive.
        /// </summary>
        public bool IsActive
        {
            get { return _isactive; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isallowedallcompanies = false;

        /// <summary>
        /// Gets whether the current system user's account has rigths to access all companies or not.
        /// </summary>
        public bool IsAllowedAllCompanies
        {
            get { return _isallowedallcompanies; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isallowedallcustomers = false;

        /// <summary>
        /// Gets whether the current system user's account has privilege to access all customers or not.
        /// </summary>
        public bool IsAllowedAllCustomers
        {
            get { return _isallowedallcustomers; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _issignedin = false;

        /// <summary>
        /// Gets whether the current system user's account is signed into the system or not.
        /// </summary>
        public bool IsSignedIn
        {
            get { return _issignedin; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _issuperuser = false;

        /// <summary>
        /// Gets whether the current system user's account is a super user or regular user.
        /// </summary>
        public bool IsSuperUser
        {
            get { return _issuperuser; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isvaliduser = false;

        /// <summary>
        /// Gets whether the current system user is an existing application user or not.
        /// </summary>
        public bool IsValidUser
        {
            get { return _isvaliduser; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _lastname = "";

        /// <summary>
        /// Gets the current system user's surname.
        /// </summary>
        public string LastName
        {
            get { return _lastname; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _middlename = "";

        /// <summary>
        /// Gets the current system user's middle name.
        /// </summary>
        public string MiddleName
        {
            get { return _middlename; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _password = "";

        /// <summary>
        /// Gets the current system user's log on account password.
        /// </summary>
        public string Password
        {
            get { return _password; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _position = "";

        /// <summary>
        /// Gets the current system user's assigned company position.
        /// </summary>
        public string Position
        {
            get { return _position; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _username = "";

        /// <summary>
        /// Gets the current system user's log on account name.
        /// </summary>
        public string Username
        {
            get { return _username; }
        }

        #endregion

        #region GlobalProperties

        /// <summary>
        /// Gets the key value for a regular user role.
        /// </summary>
        public static string RegularUserRole
        {
            get { return "12e6uLaR_u53r".Encrypt(SCMS.EncryptionKey); }
        }

        /// <summary>
        /// Gets the key value for a super user role.
        /// </summary>
        public static string SuperUserRole
        {
            get { return "5uP312_Us312".Encrypt(SCMS.EncryptionKey); }
        }

        #endregion

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Hashtable _delegatestable = new Hashtable();

        /// <summary>
        /// Asynchronously gathers a user information based on the supplied credentials.
        /// </summary>
        /// <returns></returns>
        public IAsyncResult BeginGetInformation()
        {
            IAsyncResult _result = null;

            Func<bool> _delegate = new Func<bool>(GetInformation);
            _result = _delegate.BeginInvoke(null, _delegate);

            _delegatestable.Add(_result, _delegate);

            return _result;
        }

        private void ClearInformation()
        {
            _accessiblecompanies.Clear();
            _firstname = ""; _department = ""; _isactive = false;
            _isallowedallcompanies = false; _isallowedallcustomers = false;
            _issuperuser = false; _isvaliduser = false; _lastname = "";
            _middlename = ""; _position = "";
        }

        private void CreateInitialAccountCodes(IDbConnection connection)
        {
            string _path = Application.StartupPath + "\\Xml\\defaultaccounts.xml";
            DataTable _defaultaccounts = SCMS.XmlToTable(_path);

            if (_defaultaccounts != null)
            {
                Cache.SyncTable(connection, "accounts");
                DataTable _accounts = Cache.GetCachedTable("accounts");

                if (_accounts != null)
                {
                    string _query = "";

                    for (int i = 0; i <= (_defaultaccounts.Rows.Count - 1); i++)
                    {
                        DataRow _row = _defaultaccounts.Rows[i];
                        DataRow[] _rows = _accounts.Select("[AccountCode] = " + _row["AccountCode"].ToString());
                        if (_rows.Length <= 0)
                        {
                            _query += "INSERT INTO `accounts`\n" +
                                      "(`AccountCode`, `AccountName`, `AccountCategory`, `Active`, `DateCreated`)\n" +
                                      "VALUES\n" +
                                      "(" + _row["AccountCode"].ToString() + ", '" + _row["AccountName"].ToString().ToSqlValidString() + "', '" + _row["AccountCategory"].ToString().ToSqlValidString() + "', 1, NOW());\n";
                            
                            object[] _values = new object[_accounts.Columns.Count];
                            DataColumnCollection _cols = _accounts.Columns;
                            _values[_cols["AccountCode"].Ordinal] = _row["AccountCode"];
                            _values[_cols["AccountName"].Ordinal] = _row["AccountName"];
                            _values[_cols["AccountCategory"].Ordinal] = _row["AccountCategory"];
                            _values[_cols["Active"].Ordinal] = 1;
                            _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                            _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                            _accounts.Rows.Add(_values);
                        }
                    }

                    if (!String.IsNullOrEmpty(_query.RLTrim()))
                    {
                        QueResult _result = Que.Execute(connection, _query);
                        if (String.IsNullOrEmpty(_query.RLTrim()))
                        { _accounts.AcceptChanges(); Cache.Save(); }
                        else _accounts.RejectChanges();
                        _result.Dispose(); _result = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _defaultaccounts.Dispose(); _defaultaccounts = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void CreateInitialCurrencies(IDbConnection connection)
        {
            string _path = Application.StartupPath + "\\Xml\\defaultcurrencies.xml";
            DataTable _defaultcurrencies = SCMS.XmlToTable(_path);

            if (_defaultcurrencies != null)
            {
                Cache.SyncTable(connection, "currencies");
                DataTable _currencies = Cache.GetCachedTable("currencies");

                if (_currencies != null)
                {
                    string _query = "";
                    long _cashathandac = 54005; long _exrateac = 34625;
                    DataTable _accounts = Cache.GetCachedTable("accounts");

                    if (_accounts != null)
                    {
                        DataRow[] _rows = _accounts.Select("[AccountName] LIKE 'Cash at hand'");
                        if (_rows.Length > 0) _cashathandac = (long)_rows[0]["AccountCode"];

                        _rows = _accounts.Select("[AccountName] LIKE 'Exchange rate differences'");
                        if (_rows.Length > 0) _exrateac = (long)_rows[0]["AccountCode"];
                    }

                    for (int i = 0; i <= (_defaultcurrencies.Rows.Count - 1); i++)
                    {
                        DataRow _row = _defaultcurrencies.Rows[i];
                        DataRow[] _rows = _currencies.Select("[Currency] LIKE '" + _row["Currency"].ToString().ToSqlValidString(true) + "'");
                        if (_rows.Length <= 0)
                        {
                            _query += "INSERT INTO `currencies`\n" +
                                      "(`Currency`, `Description`, `AccountCode`, `ExchangeRateAccountCode`, `DateCreated`)\n" +
                                      "VALUES\n" +
                                      "('" + _row["Currency"].ToString().ToSqlValidString() + "', '" + _row["Description"].ToString().ToSqlValidString() + "', " + _cashathandac.ToString() + ", " + _exrateac.ToString() + ", NOW());";
                            
                            DataColumnCollection _cols = _currencies.Columns;
                            object[] _values = new object[_cols.Count];
                            _values[_cols["Currency"].Ordinal] = _row["Currency"];
                            _values[_cols["Description"].Ordinal] = _row["Description"];
                            _values[_cols["AccountCode"].Ordinal] = _cashathandac;
                            _values[_cols["ExchangeRateAccountCode"].Ordinal] = _exrateac;
                            _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                            _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                            _currencies.Rows.Add(_values);
                        }
                    }

                    if (!String.IsNullOrEmpty(_query.RLTrim()))
                    {
                        QueResult _result = Que.Execute(connection, _query);
                        if (String.IsNullOrEmpty(_result.Error.RLTrim()))
                        { _currencies.AcceptChanges(); Cache.Save(); }
                        else _currencies.RejectChanges();
                        _result.Dispose(); _result = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _defaultcurrencies.Dispose(); _defaultcurrencies = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        /// <summary>
        /// Gets the result of an initialized BeginGetInformation method call.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool EndGetInformation(IAsyncResult result)
        {
            bool _withinfo = false;

            if (_delegatestable.ContainsKey(result))
            {
                _withinfo = ((Func<bool>)_delegatestable[result]).EndInvoke(result);
                _delegatestable.Remove(result); Materia.RefreshAndManageCurrentProcess();
            }

            return _withinfo;
        }

        /// <summary>
        /// Gathers a user information based on the supplied credentials.
        /// </summary>
        /// <returns></returns>
        public bool GetInformation()
        {
            bool _withinfo = false; ClearInformation();

            Cache.SyncTable(SCMS.Connection, "users");
            DataTable _table = Cache.GetCachedTable("users");

            if (_table != null)
            {
                _table.CaseSensitive = true;
                DataRow[] _rows = _table.Select("[Username] = '" + _username.ToSqlValidString(true) + "' AND [Password] = '" + _password.Encrypt(SCMS.EncryptionKey).ToSqlValidString(true) + "'");

                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["Department"])) _department = _row["Department"].ToString();
                    if (!Materia.IsNullOrNothing(_row["FirstName"])) _firstname = _row["FirstName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["LastName"])) _lastname = _row["LastName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["MiddleName"])) _middlename = _row["MiddleName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Position"])) _position = _row["Position"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Active"])) _isactive = VisualBasic.CBool(_row["Active"]);
                    if (!Materia.IsNullOrNothing(_row["Role"])) _issuperuser = VisualBasic.CBool(_row["Role"].ToString() == SuperUserRole);
                    if (!Materia.IsNullOrNothing(_row["AllCustomers"])) _isallowedallcustomers = VisualBasic.CBool(_row["AllCustomers"]);
                    if (!Materia.IsNullOrNothing(_row["AllCompanies"])) _isallowedallcompanies = VisualBasic.CBool(_row["AllCompanies"]);

                    if (!_isallowedallcompanies)
                    {
                        DataTable _companies = null;
                        _companies = _companies.LoadData(SCMS.Connection, "SELECT `Company` FROM `usercompanies` WHERE (`Username` LIKE '" + _username.ToSqlValidString() + "')");

                        if (_companies != null)
                        {
                            foreach (DataRow _company in _companies.Rows) _accessiblecompanies.Add(new CompanyInfo(_company["Company"].ToString()));

                            _companies.Dispose(); _companies = null;
                            Materia.RefreshAndManageCurrentProcess();
                        }
                    }
                 
                    _isvaliduser = true; _withinfo = true;
                }
            }

            return _withinfo;
        }

        /// <summary>
        /// Logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        public void LogAction(UserAction action, string description)
        { LogAction(action, description, ""); }

        /// <summary>
        /// Logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="refno"></param>
        public void LogAction(UserAction action, string description, string refno)
        { LogAction(action, description, refno, 0); }

        /// <summary>
        /// Logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="refno"></param>
        /// <param name="amount"></param>
        public void LogAction(UserAction action, string description, string refno, decimal amount)
        { LogAction(action, description, refno, amount, "USD", amount); }

        /// <summary>
        /// Logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="refno"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="amountusd"></param>
        public void LogAction(UserAction action, string description, string refno, decimal amount, string currency, decimal amountusd)
        {
            if (IsSignedIn)
            {
                string _path = Application.StartupPath + "\\Xml\\locallogs.xml";
                DataTable _localtable = SCMS.XmlToTable(_path);

                if (_localtable != null)
                {
                    object[] _values = new object[_localtable.Columns.Count];
                    DataColumnCollection _cols = _localtable.Columns;

                    _values[_cols["Username"].Ordinal] = Username;
                    _values[_cols["DateAndTime"].Ordinal] = DateTime.Now;
                    _values[_cols["Action"].Ordinal] = (int) action;
                    _values[_cols["ReferenceNo"].Ordinal] = refno;
                    _values[_cols["Description"].Ordinal] = description;
                    _values[_cols["Amount"].Ordinal] = amount;
                    _values[_cols["Currency"].Ordinal] = currency;
                    _values[_cols["AmountUSD"].Ordinal] = amountusd;

                    _localtable.Rows.Add(_values);

                    try
                    {
                        _localtable.AcceptChanges();
                        _localtable.WriteXml(_path, XmlWriteMode.WriteSchema);
                    }
                    catch (Exception ex)
                    { SCMS.LogError("UserLogs", ex); }

                    _localtable.Dispose(); _localtable = null;
                    Materia.RefreshAndManageCurrentProcess();
                }

                string _query = "INSERT INTO `userlogs`\n" +
                                "(`Username`, `Action`, `ReferenceNo`, `Description`, `Amount`, `Currency`, `AmountUSD`, `ComputerName`, `IPAddress`)\n" +
                                "VALUES\n" +
                                "('" + Username.ToSqlValidString() + "', " + ((int)action).ToString() + ", '" + refno.ToSqlValidString() + "', '" + description.ToSqlValidString() + "', " + amount.ToSqlValidString() + ", '" + currency.ToSqlValidString() + "', " + amountusd.ToSqlValidString() + ", '" + Environment.MachineName.ToSqlValidString() + "', '" + Materia.GetCurrentIPAddress().ToSqlValidString() + "');";

                QueResult _result = Que.Execute(SCMS.Connection, _query);
                if (String.IsNullOrEmpty(_result.Error.RLTrim())) Cache.SyncTable(SCMS.Connection, "userlogs");
                else SCMS.LogError("UserLog", new Exception(_result.Error));
                _result.Dispose(); Materia.RefreshAndManageCurrentProcess();
            }
        }

        /// <summary>
        /// Asynchronously logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public IAsyncResult LogActionAsync(UserAction action, string description)
        { return LogActionAsync(action, description, ""); }

        /// <summary>
        /// Asynchronously logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="refno"></param>
        /// <returns></returns>
        public IAsyncResult LogActionAsync(UserAction action, string description, string refno)
        { return LogActionAsync(action, description, refno, 0); }

        /// <summary>
        /// Asynchronously logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="refno"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public IAsyncResult LogActionAsync(UserAction action, string description, string refno, decimal amount)
        { return LogActionAsync(action, description, refno, amount, "USD", amount); }

        /// <summary>
        /// Asynchronously logs the current system user's action into the database and locally.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="refno"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="amountusd"></param>
        /// <returns></returns>
        public IAsyncResult LogActionAsync(UserAction action, string description, string refno, decimal amount, string currency, decimal amountusd)
        {
            Action<UserAction, string, string, decimal, string, decimal> _delegate = new Action<UserAction, string, string, decimal, string, decimal>(LogAction);
            return _delegate.BeginInvoke(action, description, refno, amount, currency, amountusd, null, _delegate);
        }

        /// <summary>
        /// Attempts to log the current system user into the application.
        /// </summary>
        public void LogIn()
        {
            _issignedin = false;
            
            bool _withrecord = GetInformation();
            if (_withrecord)
            {
                if (!_isallowedallcompanies) _issignedin = _accessiblecompanies.Contains(SCMS.CurrentCompany.Company) && _isactive;
                else  _issignedin = _isactive;
            }

            if (_issignedin)
            {
                CreateInitialAccountCodes(SCMS.Connection); CreateInitialCurrencies(SCMS.Connection);
                LogAction(UserAction.Login, "Logs into the application.");
            }
        }

        /// <summary>
        /// Attempts to asynchronously log the current system user into the application.
        /// </summary>
        /// <returns></returns>
        public IAsyncResult LogInAsync()
        {
            Action _delegate = new Action(LogIn);
            return _delegate.BeginInvoke(null, _delegate);
        }

        /// <summary>
        /// Logs out currently signed in system user.
        /// </summary>
        public void LogOut()
        {
            if (IsSignedIn)
            {
                IAsyncResult _logresult = LogActionAsync(UserAction.Logout, "Logs off from the application.");
                _logresult.WaitToFinish(); ClearInformation(); _issignedin = false;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        /// <summary>
        /// Logs out currently signed in system user asynchronously.
        /// </summary>
        /// <returns></returns>
        public IAsyncResult LogOutAsync()
        {
            Action _delegate = new Action(LogOut);
            return _delegate.BeginInvoke(null, _delegate);
        }

        public override string ToString()
        {
            string _fullname = FullName;
            return _fullname.RLTrim() + (!String.IsNullOrEmpty(_fullname.RLTrim()) ? " {" : "") + _username + (!String.IsNullOrEmpty(_fullname.RLTrim()) ? "}" : "");
        }

    }
}
