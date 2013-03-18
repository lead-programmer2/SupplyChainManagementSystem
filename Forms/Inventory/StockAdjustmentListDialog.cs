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
    public partial class StockAdjustmentListDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of StockAdjustmentListDialog. 
        /// </summary>
        public StockAdjustmentListDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isshown = false;

        #endregion

        #region Methods

        private void DisplayInfo()
        {
            DataTable _datasource = null;

            if (grdStockAdjustments.DataSource != null)
            {
                try { _datasource = (DataTable)grdStockAdjustments.DataSource; }
                catch { }
            }

            if (_datasource != null)
            {
                if (_datasource.Rows.Count <= 0) btnInfo.Text = " Ready";
                else
                {
                    DataTable _viewtable = _datasource.DefaultView.ToTable();

                    btnInfo.Text = " Displayed records : " + _viewtable.Rows.Count.ToString() + " out of " + _datasource.Rows.Count.ToString() + ".";
                    _viewtable.Dispose(); _viewtable = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }
            else btnInfo.Text = " Ready";
        }

        private void EnableButtons()
        {
            DataTable _datasource = null;

            if (grdStockAdjustments.DataSource != null)
            {
                try { _datasource = (DataTable)grdStockAdjustments.DataSource; }
                catch { }
            }

            btnNew.Enabled = true; btnRefresh.Enabled = true; txtSearch.Enabled = true;
            if (_datasource != null)
            {
                DataTable _viewtable = _datasource.DefaultView.ToTable();

                btnEdit.Enabled = (_viewtable.Rows.Count > 0);
                btnDelete.Enabled = (_viewtable.Rows.Count > 0);
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void FormatGrid()
        {
            if (grdStockAdjustments.DataSource == null) return;
            ColumnCollection _cols = grdStockAdjustments.Cols;

            grdStockAdjustments.FormatColumns();
            grdStockAdjustments.AutoNumber();

            _cols["ReferenceNo"].Caption = "Reference No.";
            _cols["Dated"].Caption = "Date";
            _cols["Approval"].Caption = "Approval Status";
            _cols["DateCreated"].Caption = "Date Created";
            _cols["DateCreated"].Format = "dd-MMM-yyyy hh:mm:ss tt";
            _cols["RefDate"].Caption = "Date Approved / Cancelled";
            _cols["RefName"].Caption = "Approved / Cancelled By";
            _cols["DateClosed"].Caption = "Date Closed";
            _cols["ClosedBy"].Caption = "Closed By";
            _cols[_cols.Fixed - 1].Caption = "#";
        }

        private DataTable GetDataSource()
        {
            DataTable _datasource = null;

            DataTable _adjustments = Cache.GetCachedTable("stockadjustments");
            DataTable _users = Cache.GetCachedTable("users");

            if (_adjustments != null &&
                _users != null)
            {
                DataTable _approver = _users.Replicate();
                DataTable _canceller = _users.Replicate();
                DataTable _closing = _users.Replicate();

                var _query = from _adj in _adjustments.AsEnumerable()
                             join _creator in _users.AsEnumerable() on _adj.Field<string>("Username") equals _creator.Field<string>("Username")
                             join _app in _approver.AsEnumerable() on _adj.Field<string>("ApprovedBy") equals _app.Field<string>("Username") into _a
                             join _cancel in _canceller.AsEnumerable() on _adj.Field<string>("CancelledBy") equals _cancel.Field<string>("Username") into _c
                             join _close in _closing.AsEnumerable() on _adj.Field<string>("ClosedBy") equals _close.Field<string>("Username") into _cl
                             where _adj.Field<string>("Company") == SCMS.CurrentCompany.Company
                             from _app in _a.DefaultIfEmpty(_approver.NewRow())
                             from _cancel in _c.DefaultIfEmpty(_canceller.NewRow())
                             from _close in _cl.DefaultIfEmpty(_closing.NewRow())
                             select new
                             {
                                 ReferenceNo = _adj.Field<string>("ReferenceNo"),
                                 Date = _adj.Field<DateTime>("Dated"),
                                 Summary = _adj.Field<string>("Summary"),
                                 Approval = (_adj.Field<Int16>("Approved") == 1 || _adj.Field<Int16>("Cancelled") == 1  ? (_adj.Field<Int16>("Approved") == 1 ? "Approved" : "") + (_adj.Field<Int16>("Cancelled") == 1 ? "Cancelled" : "") : "For Approval"),
                                 Status = (_adj.Field<Int16>("Closed") == 1? "Closed" : "Open"),
                                 DateCreated = _adj.Field<DateTime>("DateCreated"),
                                 CreatedBy = _creator.Field<string>("FirstName") + " " + _creator.Field<string>("LastName"),
                                 RefDate = (_adj.Field<Int16>("Approved") == 1 || _adj.Field<Int16>("Cancelled") == 1 ? (_adj.Field<Int16>("Approved") == 1 ? _adj.Field<DateTime>("DateApproved") : _adj.Field<DateTime>("DateCancelled")) : VisualBasic.CDate("1/1/1900")),
                                 RefName = (_adj.Field<Int16>("Approved") == 1 || _adj.Field<Int16>("Cancelled") == 1 ? (_adj.Field<Int16>("Approved") == 1 ? _app.Field<string>("FirstName") + " " + _app.Field<string>("LastName") : _cancel.Field<string>("FirstName") + " " + _cancel.Field<string>("LastName")) : ""),
                                 DateClosed = _adj.Field<DateTime>("DateClosed"),
                                 ClosedBy = _close.Field<string>("FirstName") + " " + _close.Field<string>("LastName")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "stockadjustments";
                DataColumnCollection _cols = _datasource.Columns;

                DataColumn _pk = _cols.Add("ReferenceNo", typeof(string));
                _cols.Add("Dated", typeof(DateTime));
                _cols.Add("Summary", typeof(string));
                _cols.Add("Approval", typeof(string));
                _cols.Add("Status", typeof(string));
                _cols.Add("DateCreated", typeof(DateTime));
                DataColumn _refdatecol = _cols.Add("RefDate", typeof(DateTime));
                _cols.Add("RefName", typeof(string));
                DataColumn _dateclosedcol = _cols.Add("DateClosed", typeof(DateTime));
                _cols.Add("ClosedBy", typeof(string));

                _datasource.Constraints.Add("PK", _pk, true);
                _refdatecol.AllowDBNull = true; _dateclosedcol.AllowDBNull = true;

                try
                {
                    foreach (var _row in _query)
                    {
                        object _refdate = DBNull.Value;
                        if (_row.RefDate != VisualBasic.CDate("1/1/1900")) _refdate = _row.RefDate;

                        object _dateclosed = DBNull.Value;
                        if (_row.DateClosed != VisualBasic.CDate("1/1/1900")) _dateclosed = _row.DateClosed;

                        _datasource.Rows.Add(new object[] {
                                                                      _row.ReferenceNo, _row.Date, _row.Summary,
                                                                      _row.Approval, _row.Status, _row.DateCreated,
                                                                      _refdate, _row.RefName, _dateclosed,
                                                                      _row.ClosedBy });
                    }
                }
                catch { }

                _datasource.AcceptChanges();
            }

            return _datasource;
        }

        private void InitializeDataSource()
        {
            if (grdStockAdjustments.Redraw) grdStockAdjustments.BeginUpdate();
            pctLoad.Show(); pctLoad.BringToFront();
            btnNew.Enabled = false; btnEdit.Enabled = false;
            btnDelete.Enabled = false; btnRefresh.Enabled = false;
            txtSearch.Enabled = false; txtSearch.Text = "";
            btnInfo.Text = " Gathering information...";

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

                return ;
            }
            else
            {
                DataTable _datasource = _delegate.EndInvoke(_result);

                if (_datasource != null)
                {
                    grdStockAdjustments.ClearRowsAndColumns();
                    grdStockAdjustments.DataSource = _datasource;
                    FormatGrid(); ResizeGrid();
                    while (!grdStockAdjustments.Redraw) grdStockAdjustments.EndUpdate();
                }

                pctLoad.Hide(); EnableButtons(); DisplayInfo();
            }
        }

        private void ResizeGrid()
        {
            if (grdStockAdjustments.DataSource == null) return;
            ColumnCollection _cols = grdStockAdjustments.Cols;

            grdStockAdjustments.AutoSizeCols(); grdStockAdjustments.ExtendLastCol = true;
            _cols[_cols.Fixed - 1].Width = 30;

            for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
            {
                if (_cols[i].Width < 80) _cols[i].Width = 80;
            }
        }

        #endregion

        #region FormEvents

        private void StockAdjustmentListDialog_FormClosing(object sender, FormClosingEventArgs e)
        { if (!_cancelled) _cancelled = true; }

        private void StockAdjustmentListDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            pctLoad.Hide(); SCMS.Validators.Add(this);
            grdStockAdjustments.InitializeAppearance();
            grdStockAdjustments.AttachMouseHoverPointer();
        }

        private void StockAdjustmentListDialog_Shown(object sender, EventArgs e)
        { 
            if (!_isshown) _isshown = true;
            btnRefresh_Click(btnRefresh, new EventArgs());
        }

        #endregion

        #region GridEvents

        private void grdStockAdjustments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!grdStockAdjustments.Redraw) return;
            if (grdStockAdjustments.DataSource == null) return;
            int _row = grdStockAdjustments.GetMouseOveredRow(e.X, e.Y);
            if (_row < grdStockAdjustments.Rows.Fixed) return;
            else
            {
                grdStockAdjustments.Row = _row;
                grdStockAdjustments.RowSel = _row;
                btnEdit_Click(btnEdit, new EventArgs());
            }
        }

        #endregion

        #region ControlEvents

        private void btnRefresh_Click(object sender, EventArgs e)
        { if (btnRefresh.Enabled) InitializeDataSource(); }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_isshown) return;
            if (!txtSearch.Enabled) return;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdStockAdjustments.DataSource; }
            catch { }

            if (_datasource != null)
            {
                if (grdStockAdjustments.Redraw) grdStockAdjustments.BeginUpdate();
                _datasource.Filter(txtSearch.Text);
                FormatGrid(); ResizeGrid();
                while (!grdStockAdjustments.Redraw) grdStockAdjustments.EndUpdate();
                EnableButtons(); DisplayInfo();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!btnNew.Enabled) return;

            StockAdjustmentInfoDialog _dialog = new StockAdjustmentInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates) InitializeDataSource();
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!btnEdit.Enabled) return;
            if (!grdStockAdjustments.Redraw) return;
            if (grdStockAdjustments.DataSource == null) return;
            if (grdStockAdjustments.RowSel < grdStockAdjustments.Rows.Fixed) return;

            string _referenceno = "";
            if (!Materia.IsNullOrNothing(grdStockAdjustments[grdStockAdjustments.RowSel, "ReferenceNo"])) _referenceno = grdStockAdjustments[grdStockAdjustments.RowSel, "ReferenceNo"].ToString();

            StockAdjustmentInfoDialog _dialog = new StockAdjustmentInfoDialog(_referenceno);
            _dialog.ShowDialog();

            if (_dialog.WithUpdates) InitializeDataSource();
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!btnDelete.Enabled) return;
            if (!grdStockAdjustments.Redraw) return;
            if (grdStockAdjustments.DataSource == null) return;
            if (grdStockAdjustments.RowSel < grdStockAdjustments.Rows.Fixed) return;
            if (Materia.IsNullOrNothing(grdStockAdjustments[grdStockAdjustments.RowSel, "ReferenceNo"])) return;

            string _referenceno = grdStockAdjustments[grdStockAdjustments.RowSel, "ReferenceNo"].ToString();
            DataTable _stockadjustments = Cache.GetCachedTable("stockadjustments");
            if (_stockadjustments != null)
            {
                DataRow[] _rows = _stockadjustments.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (VisualBasic.IsNumeric(_row["Closed"]))
                    {
                        if (VisualBasic.CBool(_row["Closed"]))
                        {
                            MsgBoxEx.Shout("Cannot delete stock adjustment : <font color=\"blue\">" + _referenceno + "</font> because it is already marked as final.", "Delete Stock Adjustment");
                            return;
                        }
                    }

                    if (MsgBoxEx.Ask("Delete stock adjustment <font color=\"blue\">" + _referenceno + "</font> permanently from the list?", "Delete Stock Adjustments") != System.Windows.Forms.DialogResult.Yes) return;

                    string _query = "DELETE FROM `stockadjustments` WHERE (`ReferenceNo` LIKE '" + _referenceno.ToSqlValidString(true) + "')";
                    IAsyncResult _execresult = Que.BeginExecution(SCMS.Connection, _query);

                    btnNew.Enabled = false; btnEdit.Enabled = false; btnDelete.Enabled = false;
                    btnRefresh.Enabled = false; txtSearch.Enabled = false;

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
                        }

                        return;
                    }
                    else
                    {
                        QueResult _result = Que.EndExecution(_execresult);
                        if (string.IsNullOrEmpty(_result.Error.RLTrim()))
                        {
                            _row.Delete(); _stockadjustments.AcceptChanges();

                            if (grdStockAdjustments.Redraw) grdStockAdjustments.BeginUpdate();

                            DataTable _datasource = null;

                            try { _datasource = (DataTable)grdStockAdjustments.DataSource; }
                            catch { }

                            if (_datasource != null)
                            {
                                DataRow[] _currows = _datasource.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                                if (_currows.Length > 0) _currows[0].Delete();
                                _datasource.AcceptChanges();
                            }

                            FormatGrid(); ResizeGrid();

                            Cursor = Cursors.WaitCursor;
                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Delete, "Deletes stock adjustment : " + _referenceno + ".", _referenceno);
                            _logresult.WaitToFinish(); Cursor = Cursors.Default;

                            while (!grdStockAdjustments.Redraw) grdStockAdjustments.EndUpdate();
                        }
                        else
                        {
                            SCMS.LogError(this.GetType().Name, new Exception(_result.Error));
                            MsgBoxEx.Alert("Failed to delete the specified stock adjustment.", "Delete Stock Adjustment");
                        }

                        _result.Dispose(); EnableButtons(); DisplayInfo();
                    }
                }
            }
        }

        #endregion

    }
}
