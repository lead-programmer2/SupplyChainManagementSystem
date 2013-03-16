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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class ScriptListDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ScriptListDialog.
        /// </summary>
        public ScriptListDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        #endregion

        #region Methods

        private void DisplayInfo()
        {
            DataTable _datasource = null;

            if (grdScripts.DataSource != null)
            {
                try { _datasource = (DataTable)grdScripts.DataSource; }
                catch { }
            }

            if (_datasource != null)
            {
                if (_datasource.Rows.Count > 0)
                {
                    DataTable _viewtable = _datasource.DefaultView.ToTable();
                    btnInformation.Text = " Displayed records : " + _viewtable.Rows.Count.ToString() + " out of " + _datasource.Rows.Count.ToString() + ".";
                    _viewtable.Dispose(); _viewtable = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
                else btnInformation.Text = " Ready";
            }
            else btnInformation.Text = " Ready";
        }

        private void EnableButtons()
        {
            DataTable _datasource = null;

            if (grdScripts.DataSource != null)
            {
                try { _datasource = (DataTable)grdScripts.DataSource; }
                catch { }
            }

            if (_datasource != null)
            {
                DataTable _viewtable = _datasource.DefaultView.ToTable();
                btnDelete.Enabled = (_viewtable.Rows.Count > 0);
                btnEdit.Enabled = (_viewtable.Rows.Count > 0);
                btnExport.Enabled = (_viewtable.Rows.Count > 0);
                btnExecuteScript.Enabled = (_viewtable.Rows.Count > 0);
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }

            btnAdd.Enabled = true; btnImport.Enabled = true;
            btnRefresh.Enabled = true; txtSearch.Enabled = true;
        }

        private void FormatGrid()
        {
            if (grdScripts.DataSource == null) return;
            ColumnCollection _cols = grdScripts.Cols;

            _cols["ReferenceNo"].Caption = "Reference No";
            _cols["SystemVersion"].Caption = "System Version";
            _cols["AutoScript"].Caption = "Auto-script";
            _cols["DateCreated"].Caption = "Date Created";
            _cols["LastModified"].Caption = "Last Modified";

            _cols["DateCreated"].Format = "dd-MMM-yyyy hh:mm:ss tt";
            _cols["LastModified"].Format = "dd-MMM-yyyy hh:mm:ss tt";
            _cols[_cols.Fixed - 1].Caption = "#";

            grdScripts.AutoNumber();
        }

        private DataTable GetDataSource()
        {
            DataTable _datasource = null;
            
            Cache.SyncTable(SCMS.Connection, "scripts");
            DataTable _scripts = Cache.GetCachedTable("scripts");

            if (_scripts != null)
            {
                var _query = from _scr in _scripts.AsEnumerable()
                             select new
                             {
                                 ReferenceNo = _scr.Field<string>("ReferenceNo"),
                                 SystemVersion = _scr.Field<string>("SystemVersion"),
                                 Title = _scr.Field<string>("Title"),
                                 Author = _scr.Field<string>("Author"),
                                 Executed = _scr.Field<Int16>("Executed"),
                                 AutoScript = _scr.Field<Int16>("AutoScript"),
                                 DateCreated = _scr.Field<DateTime>("DateCreated"),
                                 LastModified = _scr.Field<DateTime>("LastModified")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "scripts";
                DataColumn _pk = _datasource.Columns.Add("ReferenceNo", typeof(string));
                _datasource.Columns.Add("SystemVersion", typeof(string));
                _datasource.Columns.Add("Title", typeof(string));
                _datasource.Columns.Add("Author", typeof(string));
                _datasource.Columns.Add("Executed", typeof(bool));
                _datasource.Columns.Add("AutoScript", typeof(bool));
                _datasource.Columns.Add("DateCreated", typeof(DateTime));
                _datasource.Columns.Add("LastModified", typeof(DateTime));

                foreach (var _row in _query) _datasource.Rows.Add(new object[] {
                                                                  _row.ReferenceNo, _row.SystemVersion, _row.Title,
                                                                  _row.Author, VisualBasic.CBool(_row.Executed), VisualBasic.CBool(_row.AutoScript),
                                                                  _row.DateCreated, _row.LastModified });

                _datasource.AcceptChanges();
            }

            return _datasource;
        }

        private void InitializeScripts()
        {
            if (grdScripts.Redraw) grdScripts.BeginUpdate();
            btnAdd.Enabled = false; btnDelete.Enabled = false; btnEdit.Enabled = false;
            btnExport.Enabled = false; btnImport.Enabled = false; btnRefresh.Enabled = false;
            txtSearch.Enabled = false; txtSearch.Text = ""; btnExecuteScript.Enabled = false;
            grdScripts.ClearRowsAndColumns();

            pctLoad.Show(); pctLoad.BringToFront();

            Func<DataTable> _delegate = new Func<DataTable>(GetDataSource);
            IAsyncResult _result = _delegate.BeginInvoke(null, _delegate);

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
                DataTable _datasource = _delegate.EndInvoke(_result);

                grdScripts.DataSource = _datasource;
                FormatGrid(); ResizeGrid();

                while (!grdScripts.Redraw) grdScripts.EndUpdate();
            }

            EnableButtons(); DisplayInfo(); pctLoad.Hide();
        }

        private void ResizeGrid()
        {
            if (grdScripts.DataSource == null) return;
            ColumnCollection _cols = grdScripts.Cols;

            grdScripts.AutoSizeCols(); grdScripts.ExtendLastCol = true;
            _cols[_cols.Fixed - 1].Width = 30;
        }

        #endregion

        #region FormEvents

        private void ScriptListDialog_FormClosing(object sender, FormClosingEventArgs e)
        { _cancelled = true; }

        private void ScriptListDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            grdScripts.InitializeAppearance(); grdScripts.AttachMouseHoverPointer(); 
            pctLoad.Hide();
        }

        private void ScriptListDialog_Shown(object sender, EventArgs e)
        { InitializeScripts(); }

        #endregion

        #region GridEvents

        private void grdScripts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!grdScripts.Redraw) return;
            if (grdScripts.DataSource == null) return;
            int _row = grdScripts.GetMouseOveredRow(e.X, e.Y);
            if (_row < grdScripts.Rows.Fixed) return;
            grdScripts.Row = _row; grdScripts.RowSel = _row;
            btnEdit_Click(btnEdit, new EventArgs());
        }

        #endregion

        #region ControlEvents

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Enabled) InitializeScripts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!btnAdd.Enabled) return;
            ScriptInfoDialog _dialog = new ScriptInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates) InitializeScripts();
            _dialog.Dispose(); _dialog = null;

            Materia.RefreshAndManageCurrentProcess();
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!btnEdit.Enabled) return;
            if (!grdScripts.Redraw) return;
            if (grdScripts.DataSource == null) return;
            if (grdScripts.RowSel < (grdScripts.Rows.Fixed)) return;

            string _referenceno = grdScripts[grdScripts.RowSel, "ReferenceNo"].ToString();
            ScriptInfoDialog _dialog = new ScriptInfoDialog(_referenceno);
            _dialog.ShowDialog();

            if (_dialog.WithUpdates) InitializeScripts();
            _dialog.Dispose(); _dialog = null;

            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!btnDelete.Enabled) return;
            if (!grdScripts.Redraw) return;
            if (grdScripts.DataSource == null) return;
            if (grdScripts.RowSel < (grdScripts.Rows.Fixed)) return;

            string _referenceno = grdScripts[grdScripts.RowSel, "ReferenceNo"].ToString();

            if (MsgBoxEx.Ask("Delete script: <font color=\"blue\">" + _referenceno + "</font> from the scipts list permanently?", "Delete Script") != System.Windows.Forms.DialogResult.Yes) return;

            string _query = "DELETE FROM `scripts` WHERE (`ReferenceNo` LIKE '" + _referenceno.ToSqlValidString() + "');";
            Cursor = Cursors.WaitCursor;

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
                    Cursor = Cursors.WaitCursor;
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Delete, "Deleted script : " + _referenceno + " from the database script list.", _referenceno);
                    _logresult.WaitToFinish(); Cursor = Cursors.Default;

                    DataTable _datasource = null;

                    try { _datasource = (DataTable)grdScripts.DataSource; }
                    catch { }

                    if (_datasource != null)
                    {
                        if (grdScripts.Redraw) grdScripts.BeginUpdate();

                        DataRow[] _rows = _datasource.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                        if (_rows.Length > 0)
                        {
                            System.Collections.IEnumerator _enumerators = _rows.GetEnumerator();
                            while (_enumerators.MoveNext()) ((DataRow)_enumerators.Current).Delete();
                            _datasource.AcceptChanges();
                        }

                        DataTable _scripts = Cache.GetCachedTable("scripts");
                        if (_scripts != null)
                        {
                            DataRow[] _syncrows = _scripts.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                            System.Collections.IEnumerator _enumerators = _syncrows.GetEnumerator();
                            while (_enumerators.MoveNext()) ((DataRow)_enumerators.Current).Delete();
                            Cache.Save();
                        }

                        FormatGrid(); ResizeGrid();

                        while (!grdScripts.Redraw) grdScripts.EndUpdate();
                        EnableButtons(); DisplayInfo();
                    }
                }
                else
                {
                    SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                    MsgBoxEx.Alert("Failed to permanently delete the specified database script.", "Deletion Failed");
                }

                _queresult.Dispose(); Materia.RefreshAndManageCurrentProcess();
            }
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!btnImport.Enabled) return;

            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.CheckFileExists = true;
            _dialog.CheckPathExists = true;
            _dialog.DefaultExt = SCMS.ScriptFileExtension;
            _dialog.Filter = "SCMS Database Script Files (*." + SCMS.ScriptFileExtension + ")|*." + SCMS.ScriptFileExtension;
            _dialog.Title = "Import Database Script File";

            if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess(); return;
            }

            string _filename = _dialog.FileName;
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
            btnAdd.Enabled = false; btnEdit.Enabled = false; btnDelete.Enabled = false;
            btnExecuteScript.Enabled = false; btnExport.Enabled = false; btnImport.Enabled = false;

            Func<string, bool, DataTable> _delegate = new Func<string, bool, DataTable>(SCMS.ImportData);
            IAsyncResult _result = _delegate.BeginInvoke(_filename, true, null, _delegate);

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
                DataTable _table = _delegate.EndInvoke(_result);
                if (_table != null)
                {
                    if (_table.TableName != "scripts") MsgBoxEx.Shout("The specified file does not contain any relevant database script information.", "Import Database Script");
                    else
                    {
                        if (_table.Rows.Count > 0)
                        {
                            DataRow _row = _table.Rows[0];
                            DataTable _scripts = Cache.GetCachedTable("scripts");
                            if (_scripts != null)
                            {
                                DataRow[] _rows = _scripts.Select("[ReferenceNo] LIKE '" + _row["ReferenceNo"].ToString().ToSqlValidString(true) + "'");
                                if (_rows.Length <= 0)
                                {
                                    DataColumnCollection _cols = _scripts.Columns;
                                    object[] _values = new object[_cols.Count];

                                    for (int i = 0; i <= (_cols.Count - 1); i++)
                                    {
                                        if (_table.Columns.Contains(_cols[i].ColumnName)) _values[i] = _row[_cols[i].ColumnName];
                                    }

                                    _scripts.Rows.Add(_values);
                                    QueryGenerator _generator = new QueryGenerator(_scripts);
                                    string _query = _generator.ToString();
                                    _generator = null; Materia.RefreshAndManageCurrentProcess();

                                    if (!string.IsNullOrEmpty(_query.RLTrim()))
                                    {
                                       IAsyncResult _execresult = Que.BeginExecution(SCMS.Connection, _query);

                                        while (!_execresult.IsCompleted &&
                                               !_cancelled)
                                        { Thread.Sleep(1); Application.DoEvents(); }

                                        if (_cancelled)
                                        {
                                            if (!_execresult.IsCompleted)
                                            {
                                                try { _execresult = null; }
                                                catch { }
                                                finally { Materia.RefreshAndManageCurrentProcess(); }

                                                return;
                                            }
                                        }
                                        else
                                        {
                                            QueResult _queresult = Que.EndExecution(_execresult);

                                            if (string.IsNullOrEmpty(_queresult.Error.RLTrim()))
                                            {
                                                Cursor = Cursors.WaitCursor;
                                                IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.ImportEdi, "Imported database script from : " + _filename + ".", _row["ReferenceNo"].ToString());
                                                _logresult.WaitToFinish(); Cursor = Cursors.Default;

                                                _scripts.AcceptChanges(); InitializeScripts();
                                            }
                                            else
                                            {
                                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                                MsgBoxEx.Alert("Failed to import the specified database script file.", "Import Database Script");
                                            }

                                            _queresult.Dispose();
                                        }
                                    }
                                }
                                else MsgBoxEx.Shout("Database script : <font color=\"blue\">" + _row["ReferenceNo"].ToString() + "</font> already exists.", "Import Database Script");
                            }
                            else MsgBoxEx.Shout("Cannot import database script information.", "Import Database Script");
                        }
                        else MsgBoxEx.Shout("The specified file does not contain any relevant database script information.", "Import Database Script"); 
                    }
                    _table.Dispose(); _table = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
                else MsgBoxEx.Alert("Failed to import the specified database script file.", "Import Database Script");
            }

            EnableButtons(); DisplayInfo();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!btnExport.Enabled) return;
            if (!grdScripts.Redraw) return; 
            if (grdScripts.DataSource == null) return;
            if (grdScripts.RowSel < (grdScripts.Rows.Fixed)) return;

            string _referenceno = grdScripts[grdScripts.RowSel, "ReferenceNo"].ToString();

            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.DefaultExt = SCMS.ScriptFileExtension;
            _dialog.Filter = "SCMS database script file (*." + SCMS.ScriptFileExtension + ")|*." + SCMS.ScriptFileExtension;
            _dialog.Title = "Export Database Script";
            _dialog.FileName = _referenceno + "." + SCMS.ScriptFileExtension;
            if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess(); return;
            }

            DataTable _scripts = Cache.GetCachedTable("scripts");
            if (_scripts != null)
            {
                var _query = from _scr in _scripts.AsEnumerable()
                             where _scr.Field<string>("ReferenceNo") == _referenceno
                             select _scr;

                DataTable _script = _query.CopyToDataTable();
                _script.TableName = "scripts";
                FileInfo _exportedfile = _script.ExportData(_dialog.FileName, true);
                if (_exportedfile != null)
                {
                    Cursor = Cursors.WaitCursor;
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.ExportEdi, "Exported database script into : " + _dialog.FileName + ".", _referenceno);
                    _logresult.WaitToFinish(); Cursor = Cursors.Default;
                    Process.Start("explorer.exe", "/select, \"" + _exportedfile.FullName + "\"");
                }
                else MsgBoxEx.Alert("Failed to export the current database script into the specified path.", "Export Database Script");
                _script.Dispose(); _script = null; _exportedfile = null;
                Materia.RefreshAndManageCurrentProcess();
            }
            else MsgBoxEx.Alert("Failed to export the current database script into the specified path.", "Export Database Script");

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnExecuteScript_Click(object sender, EventArgs e)
        {
            if (!btnExecuteScript.Enabled) return;
            if (!grdScripts.Redraw) return;
            if (grdScripts.DataSource == null) return;
            if (grdScripts.RowSel < (grdScripts.Rows.Fixed)) return;

            string _referenceno = grdScripts[grdScripts.RowSel, "ReferenceNo"].ToString();

            DatabaseScriptInfo _script = new DatabaseScriptInfo(_referenceno);
            DatabaseScriptExecutionResult _result = _script.Execute();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Enabled) return;
            if (!grdScripts.Redraw) return;
            if (grdScripts.DataSource == null) return;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdScripts.DataSource; }
            catch { }

            if (_datasource != null)
            {
                if (grdScripts.Redraw) grdScripts.BeginUpdate();
                _datasource.Filter(txtSearch.Text);
                FormatGrid(); ResizeGrid();
                while (!grdScripts.Redraw) grdScripts.EndUpdate();

                EnableButtons(); DisplayInfo();
            }
        }

        #endregion

    }
}
