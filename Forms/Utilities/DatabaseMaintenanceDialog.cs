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

    /// <summary>
    /// Database maintenance operations.
    /// </summary>
    public enum DatabaseMaintenance
    {
        Analyze = 1,
        Check = 2,
        Optimize = 3,
        Repair = 4
    }

    public partial class DatabaseMaintenanceDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of DatabaseMaintenanceDialog. 
        /// </summary>
        public DatabaseMaintenanceDialog()
        {
            InitializeComponent();

            btnAnalyze.Click += new EventHandler(MaintenanceButton_Click);
            btnCheck.Click += new EventHandler(MaintenanceButton_Click);
            btnOptimize.Click += new EventHandler(MaintenanceButton_Click);
            btnRepair.Click += new EventHandler(MaintenanceButton_Click);
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        #endregion

        #region Methods

        private DataTable GetMaintenanceResult(DatabaseMaintenance maintenance)
        {
            DataTable _result = null;

            List<string> _tables = MySql.GetTables(SCMS.Connection);

            if (_tables != null)
            {
                if (_tables.Count > 0)
                {
                    string _query = ""; string _tablenames = "";

                    for (int i = 0; i <= (_tables.Count - 1); i++)
                    {
                        string _tablename = _tables[i];
                        if (string.IsNullOrEmpty(_tablenames.RLTrim())) _tablenames = "`" + _tablename + "`";
                        else _tablenames += ", `" + _tablename + "`";
                    }

                    switch (maintenance)
                    {
                        case DatabaseMaintenance.Analyze :
                            _query = "ANALYZE TABLE " + _tablenames + ";"; break;
                        case DatabaseMaintenance.Check:
                            _query = "CHECK TABLE " + _tablenames + ";"; break;
                        case DatabaseMaintenance.Optimize:
                            _query = "OPTIMIZE TABLE " + _tablenames + ";"; break;
                        case DatabaseMaintenance.Repair:
                            _query = "REPAIR TABLE " + _tablenames + ";"; break;
                        default: break;
                    }

                    if (!string.IsNullOrEmpty(_query.RLTrim())) _result = _result.LoadData(SCMS.Connection, _query);
                }

                _tables = null; Materia.RefreshAndManageCurrentProcess();
            }

            return _result;
        }

        private void InitializeMaintenance(DatabaseMaintenance maintenance)
        {
            if (grdResult.Redraw) grdResult.BeginUpdate();
            grdResult.ClearRowsAndColumns();
            btnAnalyze.Enabled = false; btnCheck.Enabled = false;
            btnOptimize.Enabled = false; btnRepair.Enabled = false;
            pctLoad.Show(); pctLoad.BringToFront();

            Func<DatabaseMaintenance, DataTable> _delelgate = new Func<DatabaseMaintenance, DataTable>(GetMaintenanceResult);
            IAsyncResult _result = _delelgate.BeginInvoke(maintenance, null, _delelgate);

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
                DataTable _table = _delelgate.EndInvoke(_result);
                if (_table != null)
                {
                    DataTable _datasource = new DataTable();
                    _datasource.TableName = "maintenance";

                    DataColumn _pk = _datasource.Columns.Add("Id", typeof(long));
                    _datasource.Columns.Add("Image", typeof(Image));
                    _datasource.Columns.Add("Table", typeof(string));
                    _datasource.Columns.Add("Remarks", typeof(string));

                    _pk.AutoIncrement = true; _pk.AutoIncrementSeed = 1;
                    _pk.AutoIncrementStep = 1;

                    _datasource.Constraints.Add("PK", _pk, true);

                    var _query = from _tbl in _table.AsEnumerable()
                                 select new
                                 {
                                     Table = _tbl.Field<string>("Table"),
                                     Image = (_tbl.Field<string>("Msg_Text").ToUpper() == "OK" ? _images.Images["check"] : _images.Images["warning"]),
                                     Remarks = _tbl.Field<string>("Msg_Text")
                                 };

                    foreach (var _row in _query) _datasource.Rows.Add(new object[] { null,
                                                                                     _row.Image, _row.Table, _row.Remarks });

                    _datasource.AcceptChanges();

                    grdResult.DataSource = _datasource;
                    ColumnCollection _cols = grdResult.Cols;
                    _cols["Id"].Visible = false; _cols["Image"].Caption = "";

                    string _tablecaption = "";
                    
                    switch (maintenance)
                    {
                        case DatabaseMaintenance.Analyze:
                            _tablecaption = "Analyzed Table"; break;
                        case DatabaseMaintenance.Check:
                            _tablecaption = "Checked Table"; break;
                        case DatabaseMaintenance.Optimize:
                            _tablecaption = "Optimized Table"; break;
                        case DatabaseMaintenance.Repair:
                            _tablecaption = "Repaired Table"; break;
                        default: break;
                    }

                    _cols["Table"].Caption = _tablecaption;
                    grdResult.AutoSizeCols(); grdResult.ExtendLastCol = true;
                    _cols[_cols.Fixed - 1].Visible = false;
                    _cols["Image"].Width = 30;

                    Cursor = Cursors.WaitCursor;
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.MaintainDatabase, _tablecaption);
                    _logresult.WaitToFinish(); Cursor = Cursors.Default;

                    while (!grdResult.Redraw) grdResult.EndUpdate();
                }
            }

            btnAnalyze.Enabled = true; btnCheck.Enabled = true;
            btnOptimize.Enabled = true; btnRepair.Enabled = true;
            pctLoad.Hide();
        }

        #endregion

        #region FormEvents

        private void DatabaseMaintenanceDialog_FormClosing(object sender, FormClosingEventArgs e)
        { _cancelled = true; }
   
        private void DatabaseMaintenanceDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            pctLoad.Hide(); grdResult.InitializeAppearance(); 
            grdResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            lblDatabase.Text = "Database : " + SCMS.ServerConnection.Server + "\\" + SCMS.ServerConnection.Database;
        }

        #endregion

        #region ControlEvents

        private void MaintenanceButton_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender.GetType() != typeof(Button)) return;
            Button _button = (Button)sender;
            if (!_button.Enabled) return;

            DatabaseMaintenance _maintenance = DatabaseMaintenance.Analyze;

            if (_button == btnCheck) _maintenance = DatabaseMaintenance.Check;
            else if (_button == btnOptimize) _maintenance = DatabaseMaintenance.Optimize;
            else if (_button == btnRepair) _maintenance = DatabaseMaintenance.Repair;
            else { }

            InitializeMaintenance(_maintenance);
         }

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        #endregion

    }
}
