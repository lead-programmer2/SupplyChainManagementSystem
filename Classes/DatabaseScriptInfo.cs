using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Application database script information class.
    /// </summary>
    public class DatabaseScriptInfo
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of DatabaseScriptInfo.
        /// </summary>
        /// <param name="refno"></param>
        public DatabaseScriptInfo(string refno)
        {
            _referenceno = refno; ClearInfo();

            DataTable _scripts = Cache.GetCachedTable("scripts");
            if (_scripts != null)
            {
                DataRow[] _rows = _scripts.Select("[ReferenceNo] LIKE '" + refno.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["Author"])) _author = _row["Author"].ToString();
                    if (VisualBasic.IsDate(_row["DateCreated"])) _datecreated = VisualBasic.CDate(_row["DateCreated"]);
                    if (!Materia.IsNullOrNothing(_row["Description"])) _description = _row["Description"].ToString();
                    if (VisualBasic.IsNumeric(_row["RequireAppRestart"])) _requiresapprestartafterexecution = VisualBasic.CBool(_row["RequireAppRestart"]);
                    if (VisualBasic.IsNumeric(_row["RequireBackup"])) _requiresbackupbeforeexecution = VisualBasic.CBool(_row["RequireBackup"]);
                    if (VisualBasic.IsNumeric(_row["RequirePcRestart"])) _requirespcrestartafterexecution = VisualBasic.CBool(_row["RequirePcRestart"]);
                    if (!Materia.IsNullOrNothing(_row["Script"])) _sqlstatement = _row["Script"].ToString();
                    if (!Materia.IsNullOrNothing(_row["SystemVersion"])) _systemversion = _row["SystemVersion"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Title"])) _title = _row["Title"].ToString();
                }
            }
        }

        /// <summary>
        /// Creates a new instance of DatabaseScriptInfo.
        /// </summary>
        /// <param name="table"></param>
        public DatabaseScriptInfo(DataTable table)
        {
            ClearInfo();

            if (table != null)
            {
                if (table.TableName != "scripts") return;

                if (table.Rows.Count > 0)
                {
                    DataRow _row = table.Rows[0];
                    if (!Materia.IsNullOrNothing(_row["Author"])) _author = _row["Author"].ToString();
                    if (VisualBasic.IsDate(_row["DateCreated"])) _datecreated = VisualBasic.CDate(_row["DateCreated"]);
                    if (!Materia.IsNullOrNothing(_row["Description"])) _description = _row["Description"].ToString();
                    if (!Materia.IsNullOrNothing(_row["ReferenceNo"])) _referenceno = _row["ReferenceNo"].ToString();
                    if (VisualBasic.IsNumeric(_row["RequireAppRestart"])) _requiresapprestartafterexecution = VisualBasic.CBool(_row["RequireAppRestart"]);
                    if (VisualBasic.IsNumeric(_row["RequireBackup"])) _requiresbackupbeforeexecution = VisualBasic.CBool(_row["RequireBackup"]);
                    if (VisualBasic.IsNumeric(_row["RequirePcRestart"])) _requirespcrestartafterexecution = VisualBasic.CBool(_row["RequirePcRestart"]);
                    if (!Materia.IsNullOrNothing(_row["Script"])) _sqlstatement = _row["Script"].ToString();
                    if (!Materia.IsNullOrNothing(_row["SystemVersion"])) _systemversion = _row["SystemVersion"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Title"])) _title = _row["Title"].ToString();
                }
            }
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _author = "";

        /// <summary>
        /// Gets the current database script's author name.
        /// </summary>
        public string Author
        {
            get { return _author; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTime _datecreated = DateTime.Now;

        /// <summary>
        /// Gets the current database script's creation date.
        /// </summary>
        public DateTime DateCreated
        {
            get { return _datecreated; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _description = "";

        /// <summary>
        /// Gets the current database script's description.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _filename = "";

        /// <summary>
        /// Gets or sets the filename of the current database script.
        /// </summary>
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _requiresapprestartafterexecution = false;

        /// <summary>
        /// Gets whether the database script opt to require application restart after the sql statement has been executed successfully.
        /// </summary>
        public bool RequiresAppRestartAfterExecution
        {
            get { return _requiresapprestartafterexecution; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _requiresbackupbeforeexecution = false;

        /// <summary>
        /// Gets whether the current database script opt to require a database backup operation first before executing the sql statement.
        /// </summary>
        public bool RequiresBackupBeforeExecution
        {
            get { return _requiresbackupbeforeexecution; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _requirespcrestartafterexecution = false;

        /// <summary>
        /// Gets whether the current database script opt to require a workstation restart after teh sql statement has been executed successfully.
        /// </summary>
        public bool RequiresPcRestartAfterExecution
        {
            get { return _requirespcrestartafterexecution; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _referenceno = "";

        /// <summary>
        /// Gets the current database script's reference number.
        /// </summary>
        public string ReferenceNo
        {
            get { return _referenceno; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _sqlstatement = "";

        /// <summary>
        /// Gets the current database script's sql statement.
        /// </summary>
        public string SqlStatement
        {
            get { return _sqlstatement; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _systemversion = "";

        /// <summary>
        /// Gets the current database script's applying system version.
        /// </summary>
        public string SystemVersion
        {
            get { return _systemversion; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _title = "";

        /// <summary>
        /// Gets the current database script's title.
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        #endregion

        #region Methods

        private void ClearInfo()
        {
            _author = ""; _datecreated = VisualBasic.CDate("1/1/900");
            _description = ""; _requiresapprestartafterexecution = false;
            _requiresbackupbeforeexecution = false; _requirespcrestartafterexecution = false;
            _sqlstatement = ""; _title = "";
        }

        /// <summary>
        /// Executes the current database script.
        /// </summary>
        /// <returns></returns>
        public DatabaseScriptExecutionResult Execute()
        {
            DatabaseScriptExecutionResult _result = new DatabaseScriptExecutionResult(this);

            string _message = "You are about to execute a database script with the following information<br /><br />" +
                              "<b>Reference No.</b>  " + _referenceno + "<br />" +
                              "<b>System Version</b>  " + (_systemversion != Application.ProductVersion ? "<font color=\"red\">" : "") + _systemversion + (_systemversion != Application.ProductVersion ? "<\font>" : "") + "<br />" +
                              "<b>Author</b>  " + _author + "<br />" + 
                              "<b>Date Created</b>  " + VisualBasic.Format(_datecreated, "dd-MMM-yyyy") + "<br />" +
                              "<b>Title</b>" + _title + "<br />" +
                              "<b>Description</b>  " + _description + "<br />" +
                              (_requiresapprestartafterexecution ||
                               _requiresbackupbeforeexecution ||
                               _requirespcrestartafterexecution ? 
                               "<b>Transitions</b><br />" : "") +
                              (_requiresbackupbeforeexecution ? "  Perform database backup before execution<br />" : "") +
                              (_requiresapprestartafterexecution ? "  Restart application after execution<br />" : "") +
                              (_requirespcrestartafterexecution ? "  Restart workstation after execution<br />" : "") +
                              "<br />" +
                              "Press <font color=\"blue\">OK</font> to continue.";

            DialogResult _dialogresult = MsgBoxEx.Shout(_message, "Execute Database Script", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2);
            if (_dialogresult == DialogResult.OK)
            {
                if (_requiresbackupbeforeexecution)
                {
                    string _backupdir = GlobalSettings.AutomaticBackupPath;
                    if (string.IsNullOrEmpty(_backupdir.RLTrim())) _backupdir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    else
                    {
                        if (!Directory.Exists(_backupdir)) _backupdir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    }

                    string _filename = _backupdir + "\\" + SCMS.ServerConnection.Database.ToUpper() + "_BACKUP_" + VisualBasic.Format(DateTime.Now, "dd_MM_yyyy_HH_mm_ss") + ".scmsiv";

                    DatabaseBackupDialog _dialog = new DatabaseBackupDialog(true);
                    _dialog.BackupPath = _filename;

                    DialogResult _backupresult = _dialog.ShowDialog();
                    _dialog.Dispose(); _dialog = null;
                    Materia.RefreshAndManageCurrentProcess();

                    if (_backupresult != DialogResult.OK) return _result;
                }

                InitializerDialog _loader = new InitializerDialog();
                _loader.Message = "Executing database script into " + SCMS.ServerConnection.Server + " / " + SCMS.ServerConnection.Database + "...";
                _loader.Show();  _result.Execute();

                if (_result.Executed)
                {
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.ExecuteScript, "Executed a database script" + (!string.IsNullOrEmpty(_filename.RLTrim()) ? " : " + _filename : "") + ".", _referenceno);
                    _logresult.WaitToFinish();
                
                    IAsyncResult _syncresult = Cache.SyncTableAsync(SCMS.Connection, "scripts");
                    _syncresult.WaitToFinish();

                    DataTable _scripts = Cache.GetCachedTable("scripts");
                    DataRow[] _rows = _scripts.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                    if (_rows.Length <= 0)
                    {
                        DataColumnCollection _cols = _scripts.Columns;
                        object[] _values = new object[_cols.Count];
                        _values[_cols["ReferenceNo"].Ordinal] = _referenceno;
                        _values[_cols["Author"].Ordinal] = _author;
                        _values[_cols["Title"].Ordinal] = _title;
                        _values[_cols["ReferenceNo"].Ordinal] = _referenceno;
                        _values[_cols["SystemVersion"].Ordinal] = _systemversion;
                        _values[_cols["Description"].Ordinal] = _description;
                        _values[_cols["Script"].Ordinal] = _sqlstatement;
                        _values[_cols["DateCreated"].Ordinal] = _datecreated;
                        _values[_cols["Executed"].Ordinal] = 1;
                        _values[_cols["DateExecuted"].Ordinal] = DateTime.Now;
                        _values[_cols["RequireBackup"].Ordinal] = (_requiresbackupbeforeexecution ? 1 : 0);
                        _values[_cols["RequireAppRestart"].Ordinal] = (_requiresapprestartafterexecution ? 1 : 0);
                        _values[_cols["RequirePcRestart"].Ordinal] = (_requiresapprestartafterexecution ? 1 : 0);
                        _scripts.Rows.Add(_values);
                    }
                    else
                    {
                        _rows[0]["Executed"] = 1;
                        _rows[0]["DateExecuted"] = DateTime.Now;
                    }

                    QueryGenerator _generator = new QueryGenerator(_scripts);
                    string _query = _generator.ToString();
                    _generator = null; Materia.RefreshAndManageCurrentProcess();

                    if (!string.IsNullOrEmpty(_query.RLTrim()))
                    {
                        IAsyncResult _queresult = Que.BeginExecution(SCMS.Connection, _query);
                        _queresult.WaitToFinish();
                        QueResult _execresult = Que.EndExecution(_queresult);

                        if (!string.IsNullOrEmpty(_execresult.Error.RLTrim())) _scripts.RejectChanges();
                        else _scripts.AcceptChanges();

                        _execresult.Dispose();
                    }
                }

                _loader.Close(); _loader.Dispose(); _loader = null;
                Materia.RefreshAndManageCurrentProcess();

                if (_result.Executed)
                {

                    if (_requiresapprestartafterexecution)
                    {
                        FormCollection _forms = Application.OpenForms;
                        int _counter = _forms.Count;

                        for (int i = (_counter - 1); i >= 0; i--)
                        {
                            Form _form = _forms[i];
                            if (!(_form is MainWindow) &&
                                !(_form is LoginDialog))
                            {
                                if (_form.TopMost)
                                {
                                    try
                                    {
                                        _form.Close(); _form.Dispose();
                                        _counter = _forms.Count;
                                    }
                                    catch { }
                                    finally { Materia.RefreshAndManageCurrentProcess(); }
                                }
                            }
                        }

                        IAsyncResult _logoutresult = SCMS.CurrentSystemUser.LogOutAsync();
                        _logoutresult.WaitToFinish();

                        Form _mainform = null;
                        System.Collections.IEnumerator _enumerators = _forms.GetEnumerator();

                        while (_enumerators.MoveNext())
                        {
                            Form _form = (Form)_enumerators.Current;
                            if (_form is MainWindow)
                            {
                                _mainform = _form; break;
                            }
                        }

                        if (_mainform != null) _mainform.Close();
                    }
                    else
                    {
                        if (_requirespcrestartafterexecution)
                        {
                            IAsyncResult _logoutresult = SCMS.CurrentSystemUser.LogOutAsync();
                            _logoutresult.WaitToFinish();

                            Process.Start("cmd", "/C shutdown -f -r -t 0");
                        }
                    }
                }
                else MsgBoxEx.Alert("Failed to either complete or fully execute the database script.", "Execute Database Script");
            }

            return _result;
        }

        public override string ToString()
        {
            return _referenceno;
        }

        #endregion

    }

    /// <summary>
    /// Database script execution information.
    /// </summary>
    public class DatabaseScriptExecutionResult
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of DatabaseScriptExecutionResult.
        /// </summary>
        /// <param name="script"></param>
        public DatabaseScriptExecutionResult(DatabaseScriptInfo script)
        { _databasescript = script; }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DatabaseScriptInfo _databasescript = null;

        /// <summary>
        /// Gets the current associated database script.
        /// </summary>
        public DatabaseScriptInfo DatabaseScript
        {
            get { return _databasescript; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _error = "";

        /// <summary>
        /// Gets the error message encountered since the last execution of the current associated database script.
        /// </summary>
        public string Error
        {
            get { return _error; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _executed = false;

        /// <summary>
        /// Gets whether the current database script has been executed succesfully.
        /// </summary>
        public bool Executed
        {
            get { return _executed; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the current associated database script.
        /// </summary>
        public void Execute()
        {
            _executed = false; _error = "";

            if (_databasescript != null)
            {
                MySqlResult _result = MySql.Execute(SCMS.ServerConnection.ToString(), _databasescript.SqlStatement);
                _executed = _result.Succeeded;
                _error = _result.Error;

                if (!string.IsNullOrEmpty(_error.RLTrim())) SCMS.LogError(this.GetType().Name, new Exception(_error));

                _result = null; Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

    }
}
