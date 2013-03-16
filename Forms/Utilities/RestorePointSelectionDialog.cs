using Development.Materia;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RestorePointSelectionDialog : Office2007Form
    {
        
        #region Constructors

        /// <summary>
        /// Creates a new instance of RestorePointSelectionDialog.
        /// </summary>
        public RestorePointSelectionDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _loaded = false;

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RestorePointInfo _selectedrestorepoint = null;

        /// <summary>
        /// Gets the current selected restore point.
        /// </summary>
        public RestorePointInfo SelectedRestorePoint
        {
            get { return _selectedrestorepoint; }
        }

        #endregion

        #region Methods

        private void InitializeRestorePoints()
        {
            if (grdRestorePoints.Redraw) grdRestorePoints.BeginUpdate();

            if (grdRestorePoints.DataSource != null)
            {
                try { grdRestorePoints.DataSource = null; }
                catch { }
                finally { Materia.RefreshAndManageCurrentProcess(); }
            }

            string _path = Application.StartupPath + "\\Xml\\restorepoints.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataTable _datasource = new DataTable();
                DataColumn _pkcol = _datasource.Columns.Add("Id", typeof(int));
                _pkcol.AutoIncrement = true; _pkcol.AutoIncrementSeed = 1;
                _pkcol.AutoIncrementStep = 1;
                _datasource.Columns.Add("Select", typeof(bool));
                _datasource.Columns.Add("As Of", typeof(DateTime));
                _datasource.Columns.Add("Info", typeof(RestorePointInfo));


                DataRow[] _rows = _table.Select("[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "' AND\n" +
                                                "[Server] LIKE '" + SCMS.ServerConnection.Server.ToSqlValidString(true) + "' AND\n" +
                                                "[Database] LIKE '" + SCMS.ServerConnection.Database.ToSqlValidString(true) + "'");

                for (int i = 0; i <= (_rows.Length - 1); i++)
                {
                    DataRow _row = _rows[i];
                    RestorePointInfo _restorepoint = new RestorePointInfo(VisualBasic.CLng(_row["DetailId"]));

                    if (!String.IsNullOrEmpty(_restorepoint.Filename.RLTrim()))
                    {
                        if (File.Exists(_restorepoint.Filename))
                        {
                            DataColumnCollection _cols = _datasource.Columns;
                            object[] _values = new object[_cols.Count];
                            _values[_cols["Select"].Ordinal] = VisualBasic.CBool(i == 0);
                            _values[_cols["As Of"].Ordinal] = _row["DateAndTime"];
                            _values[_cols["Info"].Ordinal] = _restorepoint;
                            _datasource.Rows.Add(_values);
                        }
                    }
                }

                grdRestorePoints.DataSource = _datasource;
                grdRestorePoints.Rows[grdRestorePoints.Rows.Fixed - 1].Visible = false;
                grdRestorePoints.Cols["Id"].Visible = false;
                grdRestorePoints.Cols["Select"].Caption = "";
                grdRestorePoints.Cols["As Of"].Format = "dd-MMM-yyyy hh:mm:ss tt";
                grdRestorePoints.Cols["Info"].Visible = false;
                grdRestorePoints.AutoNumber();
                grdRestorePoints.AutoSizeCols();
                grdRestorePoints.ExtendLastCol = true;
            }
            else grdRestorePoints.InitializeAppearance();

            while (!grdRestorePoints.Redraw) grdRestorePoints.EndUpdate();
        }

        #endregion

        #region FormEvents

        private void RestorePointSelectionDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            grdRestorePoints.InitializeAppearance(); 
            grdRestorePoints.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Normal].Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            InitializeRestorePoints(); _loaded = true;
        }

        #endregion

        #region GridEvents

        private void grdRestorePoints_SelChange(object sender, EventArgs e)
        {
            if (!_loaded) return;
            if (grdRestorePoints.DataSource == null) return;
            if (grdRestorePoints.RowSel < grdRestorePoints.Rows.Fixed) return;
            for (int i = grdRestorePoints.Rows.Fixed; i <= (grdRestorePoints.Rows.Count - 1); i++) grdRestorePoints.Rows[i]["Select"] = false;
            grdRestorePoints.Rows[grdRestorePoints.RowSel]["Select"] = true;
        }

        #endregion

        #region ControlEvents

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close();  }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (grdRestorePoints.DataSource == null) return;
            if (grdRestorePoints.RowSel < grdRestorePoints.Rows.Fixed) return;
            if (!Materia.IsNullOrNothing(grdRestorePoints.Rows[grdRestorePoints.RowSel]["Info"]))
            {
                _selectedrestorepoint = (RestorePointInfo)grdRestorePoints.Rows[grdRestorePoints.RowSel]["Info"];
                DialogResult = System.Windows.Forms.DialogResult.OK; Close();
            }
        }

        #endregion

    }
}
