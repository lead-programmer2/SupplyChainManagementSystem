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
    /// Database backup event enumerations.
    /// </summary>
    public enum BackupEvent
    {
        Error = 1,
        Information = 2,
        Success = 3,
        Warning = 4
    }

    /// <summary>
    /// Database backup utility dialog.
    /// </summary>
    public partial class DatabaseBackupDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of DatabaseBackupDialog.
        /// </summary>
        public DatabaseBackupDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of DatabaseBackupDialog.
        /// </summary>
        /// <param name="autoclose"></param>
        public DatabaseBackupDialog(bool autoclose)
        {
            InitializeComponent();
            _isautoclose = autoclose;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the database backup output path.
        /// </summary>
        public string BackupPath
        {
            get { return lblPath.Text; }
            set { lblPath.Text = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isautoclose = false;

        /// <summary>
        /// Gets whether the dialog will close automatically after the database backup routine or not.
        /// </summary>
        public bool IsAutoClose
        {
            get { return _isautoclose; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isfilebrowsingenabled = true;

        /// <summary>
        /// Gets whether path can be changed by the user manually  or not.
        /// </summary>
        public bool IsFileBrowsingEnabled
        {
            get { return _isfilebrowsingenabled; }
            set 
            {
                _isfilebrowsingenabled = value;
                btnBrowse.Enabled = value; 
            }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isrunning = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _succeeded = false;

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
                    case BackupEvent.Error :
                        _image = _eventimages.Images["error"];  break;
                    case BackupEvent.Information :
                        _image = _eventimages.Images["information"];  break;
                    case BackupEvent.Success:
                        _image = _eventimages.Images["good"];  break;
                    case BackupEvent.Warning:
                        _image = _eventimages.Images["exclamation"];  break;
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

        private void RunBackUp()
        {
            if (_isrunning) return;
            if (_succeeded) _succeeded = false;

            if (!Directory.Exists(Path.GetDirectoryName(lblPath.Text)))
            {
                MsgBoxEx.Shout("Please specify a valid database backup output directory.", "Database Backup"); return;
            }

            _isrunning = true; _cancelled = false; InitializeEventGrid();
            btnBrowse.Enabled = false; btnBackup.Enabled = false;
            pctLoad.Show(); pctLoad.BringToFront(); btnCancel.BringToFront();

            AddEvent(BackupEvent.Information, "Database backup operations started.");

            string _tempdir = Application.StartupPath + "\\dbtemp\\"; int _trycounter = 0;

            if (!Directory.Exists(_tempdir))
            {
                try { Directory.CreateDirectory(_tempdir); }
                catch (Exception ex)
                {
                    SCMS.LogError(this.GetType().Name, ex);
                    AddEvent(BackupEvent.Error, "Failed to create temporary output directory.");
                    btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                    pctLoad.Hide(); _isrunning = false; btnCancel.SendToBack(); return;
                }
            }

            MySqlDumpParameterCollection _parameters = new MySqlDumpParameterCollection();
            _parameters.Add(MySqlDumpParameters.CompleteInsert);
            _parameters.Add(MySqlDumpParameters.HexBlob);
            _parameters.Add(MySqlDumpParameters.Routines);
            _parameters.Add("--skip-extended-insert");
            _parameters.Add(MySqlDumpParameters.Triggers);
            _parameters.Add(MySqlDumpParameters.Quick);

            string _filename = Application.StartupPath + "\\dbtemp\\" + Path.GetFileNameWithoutExtension(lblPath.Text) + ".sql";

            Func<string, string, MySqlDumpParameterCollection, MySqlResult> _dumpdelegate = new Func<string, string, MySqlDumpParameterCollection, MySqlResult>(MySql.Dump);
            IAsyncResult _dumpresult = _dumpdelegate.BeginInvoke(SCMS.ServerConnection.ToString(), _filename, _parameters, null, _dumpdelegate);

            AddEvent(BackupEvent.Information, "Running database backup operations.");
                
            while (!_dumpresult.IsCompleted &&
                   !_cancelled)
            {
                Thread.Sleep(1); Application.DoEvents();
            }

            if (_cancelled)
            {
                if (!_dumpresult.IsCompleted)
                {
                    try { _dumpresult = null; }
                    catch { }
                }

                AddEvent(BackupEvent.Warning, "Cancelling database backup...");

                Materia.RefreshAndManageCurrentProcess(); _trycounter = 0;
                while (File.Exists(_filename) &&
                       _trycounter < 30)
                {
                    try { File.Delete(_filename); }
                    catch { }

                    _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                }

                AddEvent(BackupEvent.Information, "Database backup operations has been cancelled.");
                btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                pctLoad.Hide(); btnCancel.SendToBack(); _isrunning = false;

                _trycounter = 0;

                while (_trycounter < 10)
                {
                    Thread.Sleep(100); Application.DoEvents();
                    _trycounter += 1;
                }
            }
            else
            {
                MySqlResult _dumpexecresult = _dumpdelegate.EndInvoke(_dumpresult);
                if (_dumpexecresult.Succeeded)
                {
                    AddEvent(BackupEvent.Information, "Database backup has been created.");
                    AddEvent(BackupEvent.Information, "Archiving backup file...");

                    Func<string, ArchivingToolEnum, FileInfo> _archiverdelegate = new Func<string, ArchivingToolEnum, FileInfo>(Archiver.CompressInsert);
                    IAsyncResult _archiverresult = _archiverdelegate.BeginInvoke(_filename, ArchivingToolEnum.SevenZip, null, _archiverdelegate);

                    while (!_archiverresult.IsCompleted &&
                           !_cancelled)
                    {
                        Thread.Sleep(1); Application.DoEvents();
                    }

                    if (_cancelled)
                    {
                        AddEvent(BackupEvent.Warning, "Cancelling database backup...");

                        Materia.RefreshAndManageCurrentProcess(); _trycounter = 0;
                        while (File.Exists(_filename) &&
                               _trycounter < 30)
                        {
                            try { File.Delete(_filename); }
                            catch { }

                            _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                        }

                        _trycounter = 0;
                        _filename = Application.StartupPath + "\\dbtemp\\" + Path.GetFileNameWithoutExtension(lblPath.Text) + ".7z";

                        while (File.Exists(_filename) &&
                               _trycounter < 30)
                        {
                            try { File.Delete(_filename); }
                            catch { }

                            _trycounter += 1; Thread.Sleep(20); Application.DoEvents();
                        }

                        AddEvent(BackupEvent.Information, "Database backup operations has been cancelled.");
                        btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                        pctLoad.Hide(); btnCancel.SendToBack(); _isrunning = false;

                        _trycounter = 0;

                        while (_trycounter < 10)
                        {
                            Thread.Sleep(100); Application.DoEvents();
                            _trycounter += 1;
                        }
                    }
                    else
                    {
                        FileInfo _archivefile = _archiverdelegate.EndInvoke(_archiverresult);

                        if (_archivefile != null)
                        {
                            AddEvent(BackupEvent.Information, "Database backup file has been archived.");
                            AddEvent(BackupEvent.Information, "Finalizing database backup operations...");

                            bool _copied = false;

                            try 
                            {
                                File.Copy(_archivefile.FullName, lblPath.Text, true);
                                _copied = true;

                                Materia.RefreshAndManageCurrentProcess(); _trycounter = 0;
                                while (File.Exists(_filename) &&
                                       _trycounter < 30)
                                {
                                    try { File.Delete(_filename); }
                                    catch { }

                                    _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                                }

                                _trycounter = 0;
                                _filename = Application.StartupPath + "\\dbtemp\\" + Path.GetFileNameWithoutExtension(lblPath.Text) + ".7z";

                                while (File.Exists(_filename) &&
                                       _trycounter < 30)
                                {
                                    try { File.Delete(_filename); }
                                    catch { }

                                    _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                                }
                            }
                            catch (Exception ex)
                            {
                                SCMS.LogError(this.GetType().Name, ex);
                                AddEvent(BackupEvent.Error, "Failed to transfer archive file into output destinaton.");
                                AddEvent(BackupEvent.Warning, "Cancelling database backup...");

                                Materia.RefreshAndManageCurrentProcess(); _trycounter = 0;
                                while (File.Exists(_filename) &&
                                       _trycounter < 30)
                                {
                                    try { File.Delete(_filename); }
                                    catch { }

                                    _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                                }

                                _trycounter = 0;
                                _filename = Application.StartupPath + "\\dbtemp\\" + Path.GetFileNameWithoutExtension(lblPath.Text) + ".7z";

                                while (File.Exists(_filename) &&
                                       _trycounter < 30)
                                {
                                    try { File.Delete(_filename); }
                                    catch { }

                                    _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                                }

                                AddEvent(BackupEvent.Information, "Database backup operations has been cancelled.");
                                btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                                pctLoad.Hide(); btnCancel.SendToBack(); _isrunning = false;

                                _trycounter = 0;

                                while (_trycounter < 10)
                                {
                                    Thread.Sleep(100); Application.DoEvents();
                                    _trycounter += 1;
                                }
                            }

                            if (_copied)
                            {
                                IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.BackupDatabase, "Performed database backup into : " + lblPath.Text.ToSqlValidString().Replace("\\\\", "\\") + ".");
                                _logresult.WaitToFinish();
                                AddEvent(BackupEvent.Success, "Database backup operations has been completed.");
                                btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                                pctLoad.Hide(); btnCancel.SendToBack(); _isrunning = false;

                                if (!_succeeded) _succeeded = true;
                            }
                        }
                        else
                        {
                            AddEvent(BackupEvent.Error, "Database backup file archiving failed.");
                            AddEvent(BackupEvent.Warning, "Cancelling database backup...");

                            Materia.RefreshAndManageCurrentProcess(); _trycounter = 0;
                            while (File.Exists(_filename) &&
                                   _trycounter < 30)
                            {
                                try { File.Delete(_filename); }
                                catch { }

                                _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                            }

                            _trycounter = 0;
                            _filename = Application.StartupPath + "\\dbtemp\\" + Path.GetFileNameWithoutExtension(lblPath.Text) + ".7z";

                            while (File.Exists(_filename) &&
                                   _trycounter < 30)
                            {
                                try { File.Delete(_filename); }
                                catch { }

                                _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                            }

                            AddEvent(BackupEvent.Information, "Database backup operations has been cancelled.");
                            btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                            pctLoad.Hide(); btnCancel.SendToBack(); _isrunning = false;

                            _trycounter = 0;

                            while (_trycounter < 10)
                            {
                                Thread.Sleep(100); Application.DoEvents();
                                _trycounter += 1;
                            }
                        }
                    }
                }
                else
                {
                    SCMS.LogError(this.GetType().Name, new Exception(_dumpexecresult.Error));
                    AddEvent(BackupEvent.Error, "Database backup operations has been cancelled.");
                    AddEvent(BackupEvent.Warning, "Cancelling database backup...");

                    Materia.RefreshAndManageCurrentProcess(); _trycounter = 0;
                    while (File.Exists(_filename) &&
                           _trycounter < 30)
                    {
                        try { File.Delete(_filename); }
                        catch { }

                        _trycounter += 1; Thread.Sleep(100); Application.DoEvents();
                    }

                    AddEvent(BackupEvent.Information, "Database backup operations has been cancelled.");
                    btnBrowse.Enabled = _isfilebrowsingenabled; btnBackup.Enabled = !_isautoclose;
                    pctLoad.Hide(); btnCancel.SendToBack(); _isrunning = false;

                    _trycounter = 0;

                    while (_trycounter < 10)
                    {
                        Thread.Sleep(100); Application.DoEvents();
                        _trycounter += 1;
                    }
                }
            }

        }

        #endregion

        #region FormEvents

        private void DatabaseBackupDialog_FormClosing(object sender, FormClosingEventArgs e)
        { _cancelled = _isrunning; }

        private void DatabaseBackupDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            pctLoad.Hide(); grdStatus.InitializeAppearance();
            grdStatus.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            InitializeEventGrid();

            if (IsFileBrowsingEnabled)
            {
                string _dir = GlobalSettings.AutomaticBackupPath;
                if (string.IsNullOrEmpty(_dir.RLTrim())) _dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                else
                {
                    if (!Directory.Exists(_dir)) _dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                lblPath.Text = _dir + "\\" + SCMS.ServerConnection.Database.ToUpper() + "_BACKUP_" + VisualBasic.Format(DateTime.Now, "dd_MM_yyyy_HH_mm_ss") + ".scmsiv";
                AddEvent(BackupEvent.Information, "Ready, press 'Backup' to proceed.");
            }
        }

        private void DatabaseBackupDialog_Shown(object sender, EventArgs e)
        {
            if (_isautoclose)
            {
                RunBackUp();

                if (_succeeded) DialogResult = System.Windows.Forms.DialogResult.OK;
                else DialogResult = System.Windows.Forms.DialogResult.Cancel;

                Close();
            }
        }

        #endregion

        #region ControlEvents

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!btnBrowse.Enabled) return;

            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.DefaultExt = "scmsiv";
            _dialog.Filter = "SCMS Database Backup Files (*.scmsiv)|*.scmsiv";
            _dialog.Title = "Select Output Path";
            _dialog.FileName = SCMS.ServerConnection.Database.ToUpper() + "_BACKUP_" + VisualBasic.Format(DateTime.Now, "dd_MM_yyyy_HH_mm_ss") + ".scmsiv";
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(_dialog.FileName.RLTrim())) lblPath.Text = _dialog.FileName;
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancelled = true;
            if (!_isrunning &&
                !_isautoclose)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel; 
                Close();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!btnBackup.Enabled) return;
            if (_isrunning) return;
            RunBackUp();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            _cancelled = true;  Close();
        }

        #endregion

    }
}
