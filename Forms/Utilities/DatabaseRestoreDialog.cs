using DevComponents.DotNetBar;
using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Application's database restoration utility dialog.
    /// </summary>
    public partial class DatabaseRestoreDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of DatabaseRestoreDialog
        /// </summary>
        public DatabaseRestoreDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _backupfilename = "";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isrunning = false;

        #endregion

        #region Methods

        private void AddEvent(BackupEvent notification, string description)
        {
            DataTable _table = null;

            try { _table = (DataTable)grdStatus.DataSource; }
            catch { _table = null; }

            if (_table != null)
            {
                object[] _values = new object[_table.Columns.Count];
                DataColumnCollection _cols = _table.Columns;

                Image _image = null;

                switch (notification)
                {
                    case BackupEvent.Error:
                        _image = _eventimages.Images["error"]; break;
                    case BackupEvent.Information:
                        _image = _eventimages.Images["information"]; break;
                    case BackupEvent.Success:
                        _image = _eventimages.Images["good"]; break;
                    case BackupEvent.Warning:
                        _image = _eventimages.Images["exclamation"]; break;
                    default: break;
                }

                _values[_cols["Image"].Ordinal] = _image;
                _values[_cols["Event"].Ordinal] = description;
                _table.Rows.Add(_values);
            }
        }

        private void InitializeEventGrid()
        {
            if (grdStatus.Redraw) grdStatus.BeginUpdate();

            if (grdStatus.DataSource != null)
            {
                try { grdStatus.DataSource = null; }
                catch { }
                finally { Materia.RefreshAndManageCurrentProcess(); }
            }

            DataTable _datasource = new DataTable();

            DataColumn _pk = _datasource.Columns.Add("Id", typeof(int));
            _pk.AutoIncrement = true; _pk.AutoIncrementSeed = 1;
            _pk.AutoIncrementStep = 1;

            _datasource.Columns.Add("Image", typeof(Image));
            _datasource.Columns.Add("Event", typeof(string));

            _datasource.Constraints.Add("PK", _pk, true);

            grdStatus.DataSource = _datasource;
            if (grdStatus.Rows.Fixed > 0) grdStatus.Rows[grdStatus.Rows.Fixed - 1].Visible = false;
            grdStatus.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Normal].Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grdStatus.Cols["Id"].Visible = false;
            grdStatus.Cols["Image"].Caption = "";
            grdStatus.Cols["Image"].Width = 30;
            grdStatus.ExtendLastCol = true;

            while (!grdStatus.Redraw) grdStatus.EndUpdate();
        }

        private RestorePointInfo MakeRestorePoint()
        {
            RestorePointInfo _restorepoint = null;

            AddEvent(BackupEvent.Information, "Creating database restore point...");

            string _rpdir = Application.StartupPath + "\\Restore Points";

            if (!Directory.Exists(_rpdir))
            {
                try { Directory.CreateDirectory(_rpdir); }
                catch (Exception ex)
                {
                    SCMS.LogError(this.GetType().Name, ex);
                    AddEvent(BackupEvent.Error, "Can't create database restore point directory.");
                }
            }

            if (Directory.Exists(_rpdir))
            {
                Func<IDbConnection, DateTime> _serverdatedelegate = new Func<IDbConnection, DateTime>(MySql.GetServerDateAndTime);
                IAsyncResult _serverdateresult = _serverdatedelegate.BeginInvoke(SCMS.Connection, null, _serverdatedelegate);
                _serverdateresult.WaitToFinish();
                DateTime _serverdatetime = _serverdatedelegate.EndInvoke(_serverdateresult);
                string _rpfilename = _rpdir + "\\" + SCMS.ServerConnection.Database.ToUpper() + "_" + SCMS.CurrentCompany.Company + "_RESTORE_POINT_" + VisualBasic.Format(_serverdatetime, "dd_MM_yyyy_HH_mm_ss") + ".sql";
                int _trycounter = 0;

                MySqlDumpParameterCollection _parameters = new MySqlDumpParameterCollection();
                _parameters.Add(MySqlDumpParameters.CompleteInsert);
                _parameters.Add(MySqlDumpParameters.HexBlob);
                _parameters.Add(MySqlDumpParameters.Routines);
                _parameters.Add("--skip-extended-insert");
                _parameters.Add(MySqlDumpParameters.Triggers);
                _parameters.Add(MySqlDumpParameters.Quick);

                Func<string, string, MySqlDumpParameterCollection, MySqlResult> _dumpdelegate = new Func<string, string, MySqlDumpParameterCollection, MySqlResult>(MySql.Dump);
                IAsyncResult _dumpresult = _dumpdelegate.BeginInvoke(SCMS.ServerConnection.ToString(), _rpfilename, _parameters, null, _dumpdelegate);

                AddEvent(BackupEvent.Information, "Restore point creation started.");

                while (!_dumpresult.IsCompleted &&
                       !_cancelled)
                {
                    Thread.Sleep(1); Application.DoEvents(); 
                }

                if (_cancelled)
                {
                    AddEvent(BackupEvent.Warning, "Cancelling restore point creation...");
                    
                    _trycounter = 0;

                    while (File.Exists(_rpfilename) &&
                           _trycounter <= 30)
                    {
                        try { File.Delete(_rpfilename); }
                        catch { }

                        _trycounter += 1; 
                        Thread.Sleep(100); Application.DoEvents();
                    }

                    Materia.RefreshAndManageCurrentProcess();
                    AddEvent(BackupEvent.Information, "Restore point creation cancelled.");
                }
                else
                {
                    MySqlResult _result = _dumpdelegate.EndInvoke(_dumpresult);
                    if (_result.Succeeded)
                    {
                        string _path = Application.StartupPath + "\\Xml\\restorepoints.xml";
                        DataTable _table = SCMS.XmlToTable(_path);

                        if (_table != null)
                        {
                            bool _created = false; DataRow _newrow = null;

                            object[] _values = new object[_table.Columns.Count];
                            DataColumnCollection _cols = _table.Columns;
                            _values[_cols["DateAndTime"].Ordinal] = _serverdatetime;
                            _values[_cols["Filename"].Ordinal] = _rpfilename;
                            _values[_cols["Company"].Ordinal] = SCMS.CurrentCompany.Company;
                            _values[_cols["Server"].Ordinal] = SCMS.ServerConnection.Server;
                            _values[_cols["Database"].Ordinal] = SCMS.ServerConnection.Database;

                            try
                            {
                                _newrow = _table.Rows.Add(_values);
                                _table.AcceptChanges();
                                _table.WriteXml(_path, XmlWriteMode.WriteSchema);
                                _created = true;
                            }
                            catch (Exception ex)
                            {
                                SCMS.LogError(this.GetType().Name, ex);
                                AddEvent(BackupEvent.Error, "Failed to create and / or complete database restore point.");

                                _trycounter = 0;

                                while (File.Exists(_rpfilename) &&
                                       _trycounter <= 30)
                                {
                                    try { File.Delete(_rpfilename); }
                                    catch { }

                                    _trycounter += 1;
                                    Thread.Sleep(100); Application.DoEvents();
                                }
                            }

                            if (_created) _restorepoint = new RestorePointInfo(VisualBasic.CLng(_newrow["DetailId"]));

                            _table.Dispose(); _table = null;
                            Materia.RefreshAndManageCurrentProcess();
                        }
                        else
                        {
                            AddEvent(BackupEvent.Error, "Failed to create and / or complete database restore point.");

                            _trycounter = 0;

                            while (File.Exists(_rpfilename) &&
                                   _trycounter <= 30)
                            {
                                try { File.Delete(_rpfilename); }
                                catch { }

                                _trycounter += 1;
                                Thread.Sleep(100); Application.DoEvents();
                            }

                            Materia.RefreshAndManageCurrentProcess();
                        }
                    }
                    else
                    {
                        SCMS.LogError(this.GetType().Name, new Exception(_result.Error));
                        AddEvent(BackupEvent.Error, "Failed to create and / or complete database restore point.");

                        _trycounter = 0;

                        while (File.Exists(_rpfilename) &&
                               _trycounter <= 30)
                        {
                            try { File.Delete(_rpfilename); }
                            catch { }

                            _trycounter += 1;
                            Thread.Sleep(100); Application.DoEvents();
                        }

                        Materia.RefreshAndManageCurrentProcess();
                    }
                }
            }

            return _restorepoint;
        }

        private void RunRestoration()
        {
            if (!File.Exists(_backupfilename))
            {
                MsgBoxEx.Shout("Could not locate the specified database backup file / restore point.", "Database Restoration"); return;
            }

            btnBrowseDrive.Enabled = false; btnBrowseRestorePoint.Enabled = false;
            btnRestore.Enabled = false; btnCancel.BringToFront(); InitializeEventGrid();
            chkCreateRestorePoint.Enabled = false; pctLoad.Show(); pctLoad.BringToFront(); 
            _isrunning = true; _cancelled = false;

            AddEvent(BackupEvent.Information, "Starting database restoration routines...");
            RestorePointInfo _restorepoint = null;

            if (chkCreateRestorePoint.Checked)
            {
                _restorepoint = MakeRestorePoint();
                if (_restorepoint == null)
                {
                    btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                    btnRestore.Enabled = true; btnCancel.SendToBack();
                    chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                    _isrunning = false; Materia.RefreshAndManageCurrentProcess(); return;
                }
            }

            string _filename = _backupfilename; int _trycounter = 0;

            if (Path.GetExtension(_filename).ToLower().Replace(".", "").RLTrim() == "scmsiv")
            {
                AddEvent(BackupEvent.Information, "Extracting database backup...");
                _filename = "";

                string _dbtempdir = Application.StartupPath + "\\dbtemp";
                if (!Directory.Exists(_dbtempdir))
                {
                    try { Directory.CreateDirectory(_dbtempdir); }
                    catch (Exception ex)
                    {
                        SCMS.LogError(this.GetType().Name, ex);
                        AddEvent(BackupEvent.Error, "Could not create temporary backup file extraction directory.");

                        btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                        btnRestore.Enabled = true; btnCancel.SendToBack();
                        chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                        _isrunning = false; Materia.RefreshAndManageCurrentProcess(); return;
                    }
                }

                string _archivedir = _dbtempdir + "\\" + Path.GetFileNameWithoutExtension(_backupfilename);

                Func<string, string, bool> _extractordelegate = new Func<string, string, bool>(Archiver.Decompress);
                IAsyncResult _extractorresult = _extractordelegate.BeginInvoke(_backupfilename, _archivedir, null, _extractordelegate);

                while (!_extractorresult.IsCompleted &&
                       !_cancelled)
                {
                    Thread.Sleep(1); Application.DoEvents();
                }
   
                if (_cancelled)
                {
                    AddEvent(BackupEvent.Warning, "Cancelling database restoration...");

                    _trycounter = 0;

                    while (Directory.Exists(_archivedir) &&
                        _trycounter <= 30)
                    {
                        try { Directory.Delete(_archivedir, true); }
                        catch { }

                        _trycounter += 1;
                        Thread.Sleep(100); Application.DoEvents();
                    }

                    btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                    btnRestore.Enabled = true; btnCancel.SendToBack();
                    chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                    _isrunning = false; Materia.RefreshAndManageCurrentProcess();

                    AddEvent(BackupEvent.Information, "Cancelled database restoration.");

                    _trycounter = 0;

                    while (_trycounter < 10)
                    {
                        Thread.Sleep(100); Application.DoEvents();
                        _trycounter += 1;
                    }
                }
                else
                {
                    bool _extracted = _extractordelegate.EndInvoke(_extractorresult);

                    if (_extracted)
                    {
                        if (Directory.Exists(_archivedir))
                        {
                            string[] _files = Directory.GetFiles(_archivedir);
                            foreach (string _file in _files)
                            {
                                if (Path.GetExtension(_file).ToLower().Replace(".", "").RLTrim() == "sql")
                                {
                                    _filename = _file; break;
                                }
                            }

                            if (String.IsNullOrEmpty(_filename.RLTrim()))
                            {
                                AddEvent(BackupEvent.Error, "Could not find any supported database backup file.");

                                _trycounter = 0;

                                while (Directory.Exists(_archivedir) &&
                                    _trycounter <= 30)
                                {
                                    try { Directory.Delete(_archivedir, true); }
                                    catch { }

                                    _trycounter += 1;
                                    Thread.Sleep(100); Application.DoEvents();
                                }

                                btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                                btnRestore.Enabled = true; btnCancel.SendToBack();
                                chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                                _isrunning = false; Materia.RefreshAndManageCurrentProcess(); return;
                            }
                        }
                        else
                        {
                            AddEvent(BackupEvent.Error, "Could not extract data from database backup.");

                            _trycounter = 0;

                            while (Directory.Exists(_archivedir) &&
                                _trycounter <= 30)
                            {
                                try { Directory.Delete(_archivedir, true); }
                                catch { }

                                _trycounter += 1;
                                Thread.Sleep(100); Application.DoEvents();
                            }

                            btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                            btnRestore.Enabled = true; btnCancel.SendToBack();
                            chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                            _isrunning = false; Materia.RefreshAndManageCurrentProcess(); return;
                        }
                    }
                    else
                    {
                        AddEvent(BackupEvent.Error, "Could not extract data from database backup.");

                        _trycounter = 0;

                        while (Directory.Exists(_archivedir) &&
                            _trycounter <= 30)
                        {
                            try { Directory.Delete(_archivedir, true); }
                            catch { }

                            _trycounter += 1;
                            Thread.Sleep(100); Application.DoEvents();
                        }

                        btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                        btnRestore.Enabled = true; btnCancel.SendToBack();
                        chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                        _isrunning = false; Materia.RefreshAndManageCurrentProcess(); return;
                    }
                }
            }

            if (!String.IsNullOrEmpty(_filename.RLTrim()))
            {
                FileInfo _backupfile = new FileInfo(_filename);
                Func<string, FileInfo, MySqlResult> _restoredelegate = new Func<string, FileInfo, MySqlResult>(MySql.Execute);
                IAsyncResult _restoreresult = _restoredelegate.BeginInvoke(SCMS.ServerConnection.ToString(), _backupfile, null, _restoredelegate);

                while (!_restoreresult.IsCompleted &&
                       !_cancelled)
                {
                    Thread.Sleep(1); Application.DoEvents();
                }

                if (_cancelled)
                {
                    AddEvent(BackupEvent.Warning, "Cancelling database restoration...");

                    if (_restorepoint != null)
                    {
                        if (File.Exists(_restorepoint.Filename))
                        {
                            AddEvent(BackupEvent.Information, "Performing roll back from recorded restore point.");
                            FileInfo _restorepointfile = new FileInfo(_restorepoint.Filename);

                            _trycounter = 0;
                            while (_trycounter < 30)
                            {
                                _trycounter += 1;
                                Thread.Sleep(100); Application.DoEvents(); 
                            }

                            Func<string, FileInfo, MySqlResult> _restorepointdelegate = new Func<string, FileInfo, MySqlResult>(MySql.Execute);
                            IAsyncResult _restorepointresult = _restorepointdelegate.BeginInvoke(SCMS.ServerConnection.ToString(), _restorepointfile, null, _restorepointdelegate);
                            _restorepointresult.WaitToFinish();

                            MySqlResult _rpresult = _restorepointdelegate.EndInvoke(_restorepointresult);

                            if (_rpresult.Succeeded) AddEvent(BackupEvent.Success, "Roll back from recorded restore point has been completed.");
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_rpresult.Error));
                                AddEvent(BackupEvent.Error, "Failed to roll back from restore point.");
                            }
                        }
                    }

                    SCMS.CleanUp();
                    btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                    btnRestore.Enabled = true; btnCancel.SendToBack();
                    chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                    _isrunning = false; Materia.RefreshAndManageCurrentProcess();

                    AddEvent(BackupEvent.Information, "Cancelled database restoration.");

                    _trycounter = 0;

                    while (_trycounter < 30)
                    {
                        Thread.Sleep(100); Application.DoEvents();
                        _trycounter += 1;
                    }
                }
                else
                {
                    MySqlResult _execresult = _restoredelegate.EndInvoke(_restoreresult);

                    if (_execresult.Succeeded)
                    {
                        AddEvent(BackupEvent.Information, "Finalizing database restoration...");
                        IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.RestoreDatabase, "Restored database from file : " + lblPath.Text.ToSqlValidString().Replace("\\\\", "\\") + ".");
                        IAsyncResult _queexresult = Que.BeginExecution(SCMS.ServerConnection.ToString(), "UPDATE `settings` SET `LastRestored` = NOW();");

                        while (!_logresult.IsCompleted &&
                               !_queexresult.IsCompleted)
                        {
                            Thread.Sleep(1); Application.DoEvents();
                        }

                        QueResult _queresult = Que.EndExecution(_queexresult);
                        _queresult.Dispose(QueResultDisposition.WithAssociatedQue);

                        SCMS.CleanUp(); _isrunning = false;

                        AddEvent(BackupEvent.Success, "Database backup restoration has been completed.");

                        _trycounter = 0;

                        while (_trycounter <= 10)
                        {
                            Thread.Sleep(100); Application.DoEvents();
                            _trycounter += 1;
                        }

                        MsgBoxEx.Inform("Application will restart for the restored values to fully take effect.", "Database Backup Restoration");
                        DialogResult = System.Windows.Forms.DialogResult.OK; Close();
                    }
                    else
                    {
                        SCMS.LogError(this.GetType().Name, new Exception(_execresult.Error));
                        AddEvent(BackupEvent.Error, "Failed to complete database restoration from the specified database backup / restore point.");

                        if (_restorepoint != null)
                        {
                            if (File.Exists(_restorepoint.Filename))
                            {
                                AddEvent(BackupEvent.Information, "Performing roll back from recorded restore point.");
                                FileInfo _restorepointfile = new FileInfo(_restorepoint.Filename);

                                _trycounter = 0;
                                while (_trycounter < 15)
                                {
                                    _trycounter += 1;
                                    Thread.Sleep(100); Application.DoEvents();
                                }

                                Func<string, FileInfo, MySqlResult> _restorepointdelegate = new Func<string, FileInfo, MySqlResult>(MySql.Execute);
                                IAsyncResult _restorepointresult = _restorepointdelegate.BeginInvoke(SCMS.ServerConnection.ToString(), _restorepointfile, null, _restorepointdelegate);
                                _restorepointresult.WaitToFinish();

                                MySqlResult _rpresult = _restorepointdelegate.EndInvoke(_restorepointresult);

                                if (_rpresult.Succeeded) AddEvent(BackupEvent.Success, "Roll back from recorded restore point has been completed.");
                                else
                                {
                                    SCMS.LogError(this.GetType().Name, new Exception(_rpresult.Error));
                                    AddEvent(BackupEvent.Error, "Failed to roll back from restore point.");
                                }
                            }
                        }

                        SCMS.CleanUp();
                        btnBrowseDrive.Enabled = true; btnBrowseRestorePoint.Enabled = true;
                        btnRestore.Enabled = true; btnCancel.SendToBack();
                        chkCreateRestorePoint.Enabled = true; pctLoad.Hide();
                        _isrunning = false; Materia.RefreshAndManageCurrentProcess();
                    }
                }
            }
        }

        #endregion

        #region FormEvents

        private void DatabaseRestoreDialog_FormClosing(object sender, FormClosingEventArgs e)
        {  _cancelled = _isrunning; }

        private void DatabaseRestoreDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            pctLoad.Hide(); grdStatus.InitializeAppearance();
            chkCreateRestorePoint.Checked = true; btnRestore.Enabled = false;
            grdStatus.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            InitializeEventGrid(); AddEvent(BackupEvent.Information, "Ready, select database restoration data to proceed.");
        }

        #endregion

        #region ControlEvents

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!btnRestore.Enabled) return;
            if (String.IsNullOrEmpty(lblPath.Text.RLTrim())) return;
            RunRestoration();
        }

        private void btnBrowseDrive_Click(object sender, EventArgs e)
        {
            if (!btnBrowseDrive.Enabled) return;

            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.DefaultExt = "scmsiv";
            _dialog.Filter = "SCMS Database Backup Files (*.scmsiv)|*.scmsiv";
            _dialog.Title = "Select Database Backup File";
            _dialog.CheckFileExists = true; _dialog.CheckPathExists = true;
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(_dialog.FileName.RLTrim()))
                {
                    if (File.Exists(_dialog.FileName))
                    {
                        _backupfilename = _dialog.FileName;
                        lblPath.Text = _dialog.FileName;
                    }
                }
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();

            if (String.IsNullOrEmpty(_backupfilename.RLTrim())) btnRestore.Enabled = false;
            else btnRestore.Enabled = File.Exists(_backupfilename);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {  _cancelled = _isrunning;  }

        private void btnClose_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void btnBrowseRestorePoint_Click(object sender, EventArgs e)
        {
            if (!btnBrowseRestorePoint.Enabled) return;
            RestorePointSelectionDialog _dialog = new RestorePointSelectionDialog();
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_dialog.SelectedRestorePoint != null)
                {
                    lblPath.Text = "Restore Point : " + _dialog.SelectedRestorePoint.Server + "\\" + _dialog.SelectedRestorePoint.Database + " as of " + VisualBasic.Format(_dialog.SelectedRestorePoint.AsOf, "dd-MMM-yyyy hh:mm:ss tt");
                    _backupfilename = _dialog.SelectedRestorePoint.Filename;
                    btnRestore.Enabled = File.Exists(_backupfilename);
                }
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        #endregion

        

    }
}
