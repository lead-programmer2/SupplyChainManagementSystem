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
    public partial class LogActivityViewerDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of LogActivityViewerDialog.
        /// </summary>
        public LogActivityViewerDialog()
        {
            InitializeComponent();

            exppnlActions.ExpandedChanged += new ExpandChangeEventHandler(exppnl_ExpandedChanged);
            exppnlDateRanges.ExpandedChanged += new ExpandChangeEventHandler(exppnl_ExpandedChanged);
            exppnlUsers.ExpandedChanged += new ExpandChangeEventHandler(exppnl_ExpandedChanged);
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _detectexpandactions = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _detectexpanddates = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _detectexpandusers = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _shown = false;

        #endregion

        #region Methods

        private void DisplayInfo()
        {
            DataTable _datasource = null;

            try { _datasource = (DataTable)grdLogs.DataSource; }
            catch { }

            if (_datasource == null) btnInfo.Text = " Ready";
            else
            {
                DataTable _viewtable = _datasource.DefaultView.ToTable();
                btnInfo.Text = " Displayed records : " + _viewtable.Rows.Count + " out of " + _datasource.Rows.Count + ".";
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }

        }

        private void EnableButtons()
        {
            btnClear.Enabled = true; btnSearch.Enabled = true;
            txtSearch.Enabled = true;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdLogs.DataSource; }
            catch { }

            if (_datasource != null)
            {
                DataTable _viewtable = _datasource.DefaultView.ToTable();
                btnExportExcel.Enabled = (_viewtable.Rows.Count > 0);
                btnExportXml.Enabled = (_viewtable.Rows.Count > 0);
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void FormatGrid(C1FlexGrid grid)
        {
            if (grid == null) return;

            ColumnCollection _cols = grid.Cols;

            if (grid.Name == grdUsers.Name)
            {
                 grid.AllowEditing = true;

                 for (int i = 0; i <= (_cols.Count - 1); i++) _cols[i].AllowEditing = false;
                 _cols["AccountHolder"].AllowEditing = true;

                 for (int i = 0; i <= (grid.Rows.Count - 1); i++)
                 {
                    CheckEnum _checked = CheckEnum.Unchecked;
                    if (i == (_cols.Fixed - 1)) _checked = CheckEnum.Checked;
                    else
                    {
                        if (VisualBasic.CBool(grid[i, "Select"])) _checked = CheckEnum.Checked;
                    }

                    grid.SetCellCheck(i, _cols["AccountHolder"].Index, _checked);
                 }

                _cols["AccountHolder"].Caption = "Account Holder";
                _cols["Username"].Visible = false; 
                _cols["Select"].Visible = false;
                grid.ExtendLastCol = true; 
                _cols[_cols.Fixed - 1].Visible = false;
             }
            else if (grid == grdActions)
            {
                grid.AllowEditing = true;

                for (int i = 0; i <= (_cols.Count - 1); i++) _cols[i].AllowEditing = false;
                _cols["Action"].AllowEditing = true;

                for (int i = 0; i <= (grid.Rows.Count - 1); i++)
                {
                    CheckEnum _checked = CheckEnum.Unchecked;
                    if (i == (_cols.Fixed - 1)) _checked = CheckEnum.Checked;
                    else
                    {
                        if (VisualBasic.CBool(grid[i, "Select"])) _checked = CheckEnum.Checked;
                    }

                    grid.SetCellCheck(i, _cols["Action"].Index, _checked);
                }

                _cols["Id"].Visible = false;
                _cols["Select"].Visible = false;
                grid.ExtendLastCol = true;
                _cols[_cols.Fixed - 1].Visible = false;
            }
            else if (grid == grdLogs)
            {
                _cols["DateAndTime"].Format = "dd-MMM-yyyy hh:mm:ss tt";
                _cols["DateAndTime"].Caption = "Date and Time";
                _cols["AccountHolder"].Caption = "Account Holder";
                _cols["ReferenceNo"].Caption = "Reference No";
                _cols["ComputerName"].Caption = "Computer Name";
                _cols["IPAddress"].Caption = "IP Address";
                _cols["Image"].Caption = "";

                _cols["DetailId"].Visible = false;
                grid.AutoSizeCols(); grid.ExtendLastCol = true;
                _cols[_cols.Fixed - 1].Visible = false;
                _cols["Image"].Width = 30;
            }
            else
            { }
        }

        private DataTable GetLogsTable()
        {
            DataTable _datasource = null;
            DataTable _userlogs = Cache.GetCachedTable("userlogs");

            if (_userlogs != null)
            {
                if (grdActions.DataSource != null &&
                    grdUsers.DataSource != null)
                {
                    DataTable _users = (DataTable)grdUsers.DataSource;
                    DataTable _actions = (DataTable)grdActions.DataSource;

                    var _query = from _logs in _userlogs.AsEnumerable()
                                 join _usr in _users.AsEnumerable() on _logs.Field<string>("Username") equals _usr.Field<string>("Username")
                                 join _act in _actions.AsEnumerable() on _logs.Field<int>("Action") equals _act.Field<int>("Id")
                                 where 
                                 _usr.Field<bool>("Select") == true && 
                                 _act.Field<bool>("Select") == true &&
                                 (dtpDateTo.LockUpdateChecked ? _logs.Field<DateTime>("DateAndTime") <= dtpDateTo.Value : true) &&
                                 (dtpDateFrom.LockUpdateChecked ? _logs.Field<DateTime>("DateAndTime") >= dtpDateFrom.Value : true)
                                 select new
                                 {
                                     DetailId = _logs.Field<long>("DetailId"),
                                     DateAndTime = _logs.Field<DateTime>("DateAndTime"),
                                     AccountHolder = _usr.Field<string>("AccountHolder"),
                                     Image = (_images.Images.ContainsKey(_act.Field<string>("Action"))? _images.Images[_act.Field<string>("Action")] : null),
                                     Action = _act.Field<string>("Action"),
                                     Description = _logs.Field<string>("Description"),
                                     ReferenceNo = _logs.Field<string>("ReferenceNo"),
                                     Computer = _logs.Field<string>("ComputerName"),
                                     IPAddress = _logs.Field<string>("IPAddress")
                                 };

                    _datasource = new DataTable();
                    _datasource.TableName = "userlogs";

                    DataColumn _pk = _datasource.Columns.Add("DetailId", typeof(long));
                    _datasource.Columns.Add("Image", typeof(Image));
                    _datasource.Columns.Add("DateAndTime", typeof(DateTime));
                    _datasource.Columns.Add("AccountHolder", typeof(string));
                    _datasource.Columns.Add("Action", typeof(string));
                    _datasource.Columns.Add("Description", typeof(string));
                    _datasource.Columns.Add("ReferenceNo", typeof(string));
                    _datasource.Columns.Add("ComputerName", typeof(string));
                    _datasource.Columns.Add("IPAddress", typeof(string));
                    _datasource.Constraints.Add("PK", _pk, true);

                    foreach (var _row in _query) _datasource.Rows.Add(new object[] {
                                                                       _row.DetailId, _row .Image, _row.DateAndTime, 
                                                                       _row.AccountHolder, _row.Action, _row.Description, 
                                                                       _row.ReferenceNo, _row.Computer, _row.IPAddress});

                    _datasource.AcceptChanges(); _datasource.DefaultView.Sort = "[DateAndTime] DESC, [AccountHolder], [ReferenceNo]";
                }
            }

            return _datasource;
        }

        private void InitializeActions()
        {
            string _path = Application.StartupPath + "\\Xml\\systemactions.xml";
            DataTable _actions = SCMS.XmlToTable(_path);

            if (_actions != null)
            {
                if (grdActions.Redraw) grdActions.BeginUpdate();
                grdActions.ClearRowsAndColumns();

                var _query = from _act in _actions.AsEnumerable()
                             select new
                             {
                                 Id = _act.Field<int>("Id"),
                                 Action = _act.Field<string>("Name")
                             };

                DataTable _datasource = new DataTable();
                _datasource.TableName = "actions";

                DataColumn _pk = _datasource.Columns.Add("Id", typeof(int));
                _datasource.Columns.Add("Action", typeof(string));
                _datasource.Columns.Add("Select", typeof(bool));
                _datasource.Constraints.Add("PK", _pk, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Id, _row.Action, true });
                _datasource.AcceptChanges(); _datasource.DefaultView.Sort = "[Action]";

                grdActions.DataSource = _datasource;
                FormatGrid(grdActions);

                while (!grdActions.Redraw) grdActions.EndUpdate();
            }
        }

        private void InitializeLogs()
        {
            btnClear.Enabled = false; btnSearch.Enabled = false;
            txtSearch.Enabled = false; txtSearch.Text = "";
            btnExportExcel.Enabled = false; btnExportXml.Enabled = false;
            pctLoad.Show(); pctLoad.BringToFront();

            if (grdLogs.Redraw) grdLogs.BeginUpdate();
            grdLogs.ClearRowsAndColumns();

            Func<DataTable> _delegate = new Func<DataTable>(GetLogsTable);
            IAsyncResult _result = _delegate.BeginInvoke(null, _delegate);

            while (!_result.IsCompleted &&
                   _cancelled)
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
                if (_datasource != null)  grdLogs.DataSource = _datasource;
                FormatGrid(grdLogs);
                while (!grdLogs.Redraw) grdLogs.EndUpdate();
            }

            EnableButtons(); DisplayInfo(); pctLoad.Hide();
        }

        private void InitializeUsers()
        {

            if (grdUsers.Redraw) grdUsers.BeginUpdate();
            grdUsers.ClearRowsAndColumns();

            DataTable _users = Cache.GetCachedTable("users");
            if (_users != null)
            {
                var _query = from _usr in _users.AsEnumerable()
                             select new
                             {
                                 Username = _usr.Field<string>("Username"),
                                 AccountHolder = _usr.Field<string>("FirstName") + " " + _usr.Field<string>("LastName")
                             };

                DataTable _datasource = new DataTable();
                _datasource.TableName = "users";
                DataColumn _pk = _datasource.Columns.Add("Username", typeof(string));
                _datasource.Columns.Add("AccountHolder", typeof(string));
                _datasource.Columns.Add("Select", typeof(bool));
                _datasource.Constraints.Add("PK", _pk, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Username, _row.AccountHolder, true });

                _datasource.AcceptChanges(); _datasource.DefaultView.Sort = "[AccountHolder]";
                grdUsers.DataSource = _datasource;
                FormatGrid(grdUsers);

                while (!grdUsers.Redraw) grdUsers.EndUpdate();
            }
        }

        #endregion

        #region FormEvents

        private void LogActivityViewerDialog_FormClosing(object sender, FormClosingEventArgs e)
        { if (!_cancelled) _cancelled = true; }

        private void LogActivityViewerDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this);

            exppnlActions.Expanded = false; exppnlUsers.Expanded = false;
            exppnlDateRanges.Expanded = true;

            grdUsers.InitializeAppearance(); grdActions.InitializeAppearance();
            grdLogs.InitializeAppearance(); pctLoad.Hide();

            grdActions.Styles.Normal.Border.Style = BorderStyleEnum.None;
            grdLogs.Styles.Normal.Border.Style = BorderStyleEnum.None;
            grdUsers.Styles.Normal.Border.Style = BorderStyleEnum.None;
            
            grdUsers.AttachMouseHoverPointer(); grdActions.AttachMouseHoverPointer();

            dtpDateFrom.CustomFormat = "dd-MMM-yyyy hh:mm tt"; dtpDateFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpDateFrom.ShowCheckBox = true; dtpDateFrom.ButtonDropDown.Visible = false;
            dtpDateFrom.ShowUpDown = true; dtpDateFrom.AllowEmptyState = false;
            dtpDateFrom.Value = VisualBasic.CDate(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            dtpDateFrom.MaxDate = DateTime.Now.AddDays(1); dtpDateFrom.LockUpdateChecked = false;

            dtpDateTo.CustomFormat = "dd-MMM-yyyy hh:mm tt"; dtpDateTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpDateTo.ShowCheckBox = true; dtpDateTo.ButtonDropDown.Visible = false;
            dtpDateTo.ShowUpDown = true; dtpDateTo.AllowEmptyState = false;
            dtpDateTo.Value = DateTime.Now;
            dtpDateTo.MaxDate = DateTime.Now.AddDays(1); dtpDateTo.LockUpdateChecked = false;

            InitializeActions(); InitializeUsers();
        }

        private void LogActivityViewerDialog_Shown(object sender, EventArgs e)
        { 
            if (!_shown) _shown = true;
            InitializeLogs();
        }

        #endregion

        #region GridEvents

        private void grdUsers_CellChecked(object sender, RowColEventArgs e)
        {
            if (!_shown) return;
            if (!grdUsers.Redraw) return;
            if (grdUsers.DataSource == null) return;

            ColumnCollection _cols = grdUsers.Cols;

            if (_cols[e.Col].Name == "AccountHolder")
            {
                if (e.Row == (grdUsers.Rows.Fixed - 1))
                {
                    if (grdUsers.Redraw) grdUsers.BeginUpdate();
                    CheckEnum _checked = grdUsers.GetCellCheck(e.Row, e.Col);

                    for (int i = grdUsers.Rows.Fixed; i <= (grdUsers.Rows.Count - 1); i++)
                    {
                        grdUsers.SetCellCheck(i, e.Col, _checked);
                        grdUsers[i, _cols["Select"].Index] = (_checked == CheckEnum.Checked);
                    }

                    while (!grdUsers.Redraw) grdUsers.EndUpdate();
                }
                else
                {
                    grdUsers[e.Row, "Select"] = (grdUsers.GetCellCheck(e.Row, e.Col) == CheckEnum.Checked);

                    CheckEnum _checked = CheckEnum.Checked;
                    bool _allchecked = true;

                    for (int i = grdUsers.Rows.Fixed; i <= (grdUsers.Rows.Count - 1); i++)
                    {
                        _allchecked = _allchecked && VisualBasic.CBool(grdUsers[i, "Select"]);
                        if (!_allchecked) break;
                    }

                    if (!_allchecked) _checked = CheckEnum.Unchecked;

                    grdUsers.SetCellCheck(grdUsers.Rows.Fixed - 1, e.Col, _checked);
                }
            }
        }

        private void grdActions_CellChecked(object sender, RowColEventArgs e)
        {
            if (!_shown) return;
            if (!grdActions.Redraw) return;
            if (grdActions.DataSource == null) return;

            ColumnCollection _cols = grdActions.Cols;

            if (_cols[e.Col].Name == "Action")
            {
                if (e.Row == (grdActions.Rows.Fixed - 1))
                {
                    if (grdActions.Redraw) grdActions.BeginUpdate();
                    CheckEnum _checked = grdActions.GetCellCheck(e.Row, e.Col);

                    for (int i = grdActions.Rows.Fixed; i <= (grdActions.Rows.Count - 1); i++)
                    {
                        grdActions.SetCellCheck(i, e.Col, _checked);
                        grdActions[i, _cols["Select"].Index] = (_checked == CheckEnum.Checked);
                    }

                    while (!grdActions.Redraw) grdActions.EndUpdate();
                }
                else
                {
                    grdActions[e.Row, "Select"] = (grdActions.GetCellCheck(e.Row, e.Col) == CheckEnum.Checked);

                    CheckEnum _checked = CheckEnum.Checked;
                    bool _allchecked = true;

                    for (int i = grdActions.Rows.Fixed; i <= (grdActions.Rows.Count - 1); i++)
                    {
                        _allchecked = _allchecked && VisualBasic.CBool(grdActions[i, "Select"]);
                        if (!_allchecked) break;
                    }

                    if (!_allchecked) _checked = CheckEnum.Unchecked;

                    grdActions.SetCellCheck(grdActions.Rows.Fixed - 1, e.Col, _checked);
                }
            }
        }

        #endregion

        #region ControlEvents

        private void exppnl_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (!_shown) return;
            if (sender == null) return;
            if (sender.GetType() != typeof(ExpandablePanel)) return;
            ExpandablePanel expppnl = (ExpandablePanel)sender;

            if (expppnl == exppnlActions)
            {
                if (!_detectexpandactions) return;
                if (expppnl.Expanded)
                {
                    _detectexpanddates = false;
                    _detectexpandusers = false;
                    exppnlDateRanges.Expanded = false;
                    exppnlUsers.Expanded = false;
                    _detectexpanddates = true;
                    _detectexpandusers = true;
                }
                else
                {
                    _detectexpandusers = true;
                    exppnlUsers.Expanded = true;
                }
            }
            else if (expppnl == exppnlDateRanges)
            {
                if (!_detectexpanddates) return;
                if (expppnl.Expanded)
                {
                    _detectexpandactions = false;
                    _detectexpandusers = false;
                    exppnlActions.Expanded = false;
                    exppnlUsers.Expanded = false;
                    _detectexpandactions = true;
                    _detectexpandusers = true;
                }
                else
                {
                    _detectexpandactions = true;
                    exppnlActions.Expanded = true;
                }
            }
            else if (expppnl == exppnlUsers)
            {
                if (!_detectexpandusers) return;
                if (expppnl.Expanded)
                {
                    _detectexpandactions = false;
                    _detectexpanddates = false;
                    exppnlActions.Expanded = false;
                    exppnlDateRanges.Expanded = false;
                    _detectexpandactions = true;
                    _detectexpanddates = true;
                }
                else
                {
                    _detectexpandactions = true;
                    exppnlActions.Expanded = true;
                }
            }
            else { }
        }

        private void dtpDateTo_LockUpdateChanged(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!dtpDateTo.Enabled) return;
            if (!dtpDateTo.LockUpdateChecked) dtpDateFrom.LockUpdateChecked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Enabled) InitializeLogs();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!txtSearch.Enabled) return;
            if (!grdLogs.Redraw) return;
            if (grdLogs.DataSource == null) return;

            if (grdLogs.Redraw) grdLogs.BeginUpdate();

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdLogs.DataSource; }
            catch { }

            if (_datasource != null)
            {
                try { _datasource.Filter(txtSearch.Text); }
                catch { }
            }

            FormatGrid(grdLogs);

            while (!grdLogs.Redraw) grdLogs.EndUpdate();

            EnableButtons(); DisplayInfo(); 
        }

        private void _sidebar_AutoHideChanged(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!SCMS.Validators.Contains(this)) return;
            SCMS.Validators[this].Highlighter.UpdateHighlights();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!btnClear.Enabled) return;

            DataTable _users = null;

            try { _users = (DataTable)grdUsers.DataSource; }
            catch { }

            if (_users != null)
            {
                if (grdUsers.Redraw) grdUsers.BeginUpdate();

                for (int i = 0; i <= (_users.Rows.Count - 1); i++) _users.Rows[i]["Select"] = true;

                FormatGrid(grdUsers);

                while (!grdUsers.Redraw) grdUsers.EndUpdate();
            }

            DataTable _actions = null;

            try { _actions = (DataTable)grdActions.DataSource; }
            catch { }

            if (_actions != null)
            {
                if (grdActions.Redraw) grdActions.BeginUpdate();

                for (int i = 0; i <= (_actions.Rows.Count - 1); i++) _actions.Rows[i]["Select"] = true;

                FormatGrid(grdActions);

                while (!grdActions.Redraw) grdActions.EndUpdate();
            }

            dtpDateTo.LockUpdateChecked = false; dtpDateFrom.LockUpdateChecked = false;

            InitializeLogs();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!btnExportExcel.Enabled) return;
            if (!grdLogs.Redraw) return;
            if (grdLogs.DataSource == null) return;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdLogs.DataSource; }
            catch { }

            if (_datasource != null)
            {
                SaveFileDialog _dialog = new SaveFileDialog();
                _dialog.DefaultExt = "xls";
                _dialog.FileName = "userlogs.xls";
                _dialog.Filter = "Micrososft Excel Worksheet (*.xls)|*.xls";
                _dialog.Title = "Export User Logs";
                if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    _dialog.Dispose(); _dialog = null;
                    Materia.RefreshAndManageCurrentProcess(); return;
                }

                DataTable _viewtable = _datasource.DefaultView.ToTable();
                Cursor = Cursors.WaitCursor;

                try
                {
                    _viewtable.SaveExcel(_dialog.FileName);
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.ExportExcel, "Exported user logs into : " + _dialog.FileName + ".");
                    _logresult.WaitToFinish(); Cursor = Cursors.Default;

                    if (File.Exists(_dialog.FileName)) Process.Start(_dialog.FileName);
                }
                catch (Exception ex)
                {
                    SCMS.LogError(this.GetType().Name, ex);
                    MsgBoxEx.Alert("Failed to export the current list into the output file.", "Export User Logs");
                }

                Cursor = Cursors.Default;
                _dialog.Dispose(); _dialog = null;
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void btnExportXml_Click(object sender, EventArgs e)
        {
            if (!_shown) return;
            if (!btnExportXml.Enabled) return;
            if (!grdLogs.Redraw) return;
            if (grdLogs.DataSource == null) return;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdLogs.DataSource; }
            catch { }

            if (_datasource != null)
            {
                SaveFileDialog _dialog = new SaveFileDialog();
                _dialog.DefaultExt = "xml";
                _dialog.FileName = "userlogs.xml";
                _dialog.Filter = "Extensive Markup Language Files (*.xml)|*.xml";
                _dialog.Title = "Export User Logs";
                if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    _dialog.Dispose(); _dialog = null;
                    Materia.RefreshAndManageCurrentProcess(); return;
                }

                DataTable _viewtable = _datasource.DefaultView.ToTable();
                Cursor = Cursors.WaitCursor;
                btnClear.Enabled = false; btnSearch.Enabled = false;
                btnExportExcel.Enabled = false; btnExportXml.Enabled = false;

                Func<DataTable, DataTable> _delegate = new Func<DataTable, DataTable>(Materia.ToExportableTable);
                IAsyncResult _result = _delegate.BeginInvoke(_viewtable, null, _delegate);
                _result.WaitToFinish();
                DataTable _exportabletable = _delegate.EndInvoke(_result);

                try
                {
                    _exportabletable.WriteXml(_dialog.FileName, XmlWriteMode.WriteSchema);
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.ExportXml, "Exported user logs into : " + _dialog.FileName + ".");
                    _logresult.WaitToFinish(); Cursor = Cursors.Default;

                    if (File.Exists(_dialog.FileName)) Process.Start("explorer.exe", "/select, \"" + _dialog.FileName + "\"");
                }
                catch (Exception ex)
                {
                    SCMS.LogError(this.GetType().Name, ex);
                    MsgBoxEx.Alert("Failed to export the current list into the output file.", "Export User Logs");
                }

                EnableButtons(); Cursor = Cursors.Default;
                _dialog.Dispose(); _dialog = null;
                _exportabletable.Dispose(); _exportabletable = null;
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

    }
}
 