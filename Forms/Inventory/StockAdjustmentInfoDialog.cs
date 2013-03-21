using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using Development.Materia;
using Development.Materia.Controls;
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
    public partial class StockAdjustmentInfoDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of StockAdjustmentInfoDialog.
        /// </summary>
        public StockAdjustmentInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of StockAdjustmentInfoDialog.
        /// </summary>
        /// <param name="info"></param>
        public StockAdjustmentInfoDialog(PartInfo info)
        {
            InitializeComponent();

            _partinfo = info;
        }

        /// <summary>
        /// Creates a new instance of StockAdjustmentInfoDialog.
        /// </summary>
        /// <param name="refno"></param>
        public StockAdjustmentInfoDialog(string refno)
        {
            InitializeComponent();

            _referenceno = refno; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isfinalized = false;

        /// <summary>
        /// Gets whether the current stock adjustment has been finalized and has taken effect into the inventory.
        /// </summary>
        public bool IsFinalized
        {
            get { return _isfinalized; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _referenceno = "";

        /// <summary>
        /// Gets the current updated stock adjustment's reference number.
        /// </summary>
        public string ReferenceNo
        {
            get { return _referenceno; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current banking company conducts any updates while it is open.
        /// </summary>
        public bool WithUpdates
        {
            get { return _withupdates; }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DoubleInput _amounteditor = new DoubleInput();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTimeInput _dateeditor = new DateTimeInput();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isnew = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isshown = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ComboBoxEx _locationseditor = new ComboBoxEx();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PartInfo _partinfo = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DataSourcedComboBox _partseditor = new DataSourcedComboBox();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntegerInput _qtyeditor = new IntegerInput();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SizableTextBox _remarkseditor = new SizableTextBox();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _updated = false;

        #endregion

        #region Methods

        private void AttachEditorHandler()
        {
            txtSummary.TextChanged += new EventHandler(Field_Edited);
            dtpDated.ValueChanged += new EventHandler(Field_Edited);
            grdDetails.AfterAddRow += new RowColEventHandler(Field_Edited);
            grdDetails.AfterDeleteRow += new RowColEventHandler(Field_Edited);
            btnDelete.Click += new EventHandler(Field_Edited);
        }

        private void ComputeTotal()
        {
            decimal _totalcost = 0;

            DataTable _datasource = null;

            if (grdDetails.DataSource != null)
            {
                try { _datasource = (DataTable)grdDetails.DataSource; }
                catch { }
            }

            if (_datasource != null)
            {
                object _total = _datasource.Compute("SUM([TotalCost])", "");
                if (VisualBasic.IsNumeric(_total)) _totalcost = VisualBasic.CDec(_total);
            }

            txtTotalCost.Text = VisualBasic.Format(_totalcost, "N2");
        }

        private void FormatGrid()
        {
            if (grdDetails.DataSource == null) return;
            ColumnCollection _cols = grdDetails.Cols;

            grdDetails.AutoNumber(); grdDetails.FormatColumns();
            grdDetails.AllowAddNew = true; grdDetails.AllowDelete = true;
            grdDetails.AllowEditing = true;

            string[] _invisiblecols = new string[] 
                                      { "DetailId", "PartCode", "ReferenceNo",
                                        "LocationCode", "Multiplier"};

            for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++) _cols[i].Visible = !_invisiblecols.Contains(_cols[i].Name);

            string[] _editablecols = new string[]
                                     { "PartNo", "Adjustment", "Quantity", 
                                       "Location", "StockDate", "UnitCostUSD", "Remarks" };

            for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
            {
                bool _allowedit = _editablecols.Contains(_cols[i].Name);
                _cols[i].AllowEditing = _allowedit;

                if (_allowedit)
                {
                    _cols[i].StyleNew.BackColor = Color.White;
                    _cols[i].StyleNew.ForeColor = Color.Black;
                }
                else
                {
                    _cols[i].StyleNew.BackColor = Color.Gray;
                    _cols[i].StyleNew.ForeColor = Color.WhiteSmoke;
                }
            }


            _cols["PartNo"].Caption = "Part No.";
            _cols["PartName"].Caption = "Part Name";
            _cols["StockDate"].Caption = "Purchase Date";
            _cols["UnitCostUSD"].Caption = "Unit Cost (USD)";
            _cols["CurrentQty"].Caption = "Current Qty";
            _cols["EndingQty"].Caption = "Ending Qty";
            _cols["TotalCost"].Caption = "Total Cost (USD)";
            _cols[_cols.Fixed - 1].Caption = "#";

            _cols["PartNo"].Editor = _partseditor;
            _cols["Location"].Editor = _locationseditor;
            _cols["Adjustment"].ComboList = "Additional|Deduction";
            _cols["Quantity"].Editor = _qtyeditor;
            _cols["UnitCostUSD"].Editor = _amounteditor;
            _cols["StockDate"].Editor = _dateeditor;
            _cols["Remarks"].Editor = _remarkseditor;
            
            grdDetails.NewRowWatermark = "Add a new stock adjustment entry here...";
        }

        private int GetPartQty(string partcode, string locationcode, DateTime stockdate, decimal unitcost)
        {
            int _currentqty = 0;

            DataTable _stockledger = Cache.GetCachedTable("stockledger");
            if (_stockledger != null)
            {
                var _query = from _ledger in _stockledger.AsEnumerable()
                             where _ledger.Field<string>("PartCode") == partcode &&
                                   _ledger.Field<string>("LocationCode") == locationcode &&
                                   _ledger.Field<DateTime>("PurchaseDate").Date == stockdate.Date &&
                                   _ledger.Field<decimal>("UnitCostUSD") == unitcost
                             group _ledger by _ledger.Field<string>("PartCode") into _group
                             select new 
                             {
                                 Total = _group.Sum(_ledger => (_ledger.Field<int>("In") - _ledger.Field<int>("Out")))
                             };

                try 
                { 
                    foreach (var _row in _query)
                    {
                        if (VisualBasic.IsNumeric(_row.Total)) _currentqty = _row.Total;
                    }
                }
                catch { _currentqty = 0; }
            }

            return _currentqty;
        }

        private void InitializeInfo()
        {
            if (grdDetails.Redraw) grdDetails.BeginUpdate();

            DataTable _stockadjheader = Cache.GetCachedTable("stockadjustments");
            DataTable _stockadjdetail = Cache.GetCachedTable("stockadjustmentdetails");
            DataTable _parts = Cache.GetCachedTable("parts");
            DataTable _locations = Cache.GetCachedTable("locations");

            if (_stockadjheader != null &&
                _stockadjdetail != null &&
                _parts != null &&
                _locations != null)
            {
                var _query = from _header in _stockadjheader.AsEnumerable()
                             join _detail in _stockadjdetail.AsEnumerable() on _header.Field<string>("ReferenceNo") equals _detail.Field<string>("ReferenceNo")
                             join _part in _parts.AsEnumerable() on _detail.Field<string>("PartCode") equals _part.Field<string>("PartCode")
                             join _loc in _locations.AsEnumerable() on _detail.Field<string>("LocationCode") equals _loc.Field<string>("LocationCode")
                             where _header.Field<string>("ReferenceNo") == _referenceno
                             select new
                             {
                                 ReferenceNo = _header.Field<string>("ReferenceNo"),
                                 Dated = _header.Field<DateTime>("Dated"),
                                 Summary = _header.Field<string>("Summary"),
                                 DateApproved = _header.Field<DateTime>("DateApproved"),
                                 DateCancelled = _header.Field<DateTime>("DateCancelled"),
                                 DateClosed = _header.Field<DateTime>("DateClosed"),
                                 Approved = _header.Field<Int16>("Approved"),
                                 Cancelled = _header.Field<Int16>("Cancelled"),
                                 Closed = _header.Field<Int16>("Closed"),
                                 DetailId = _detail.Field<long>("DetailId"),
                                 PartCode = _detail.Field<string>("PartCode"),
                                 PartNo = _part.Field<string>("PartNo"),
                                 PartName = _part.Field<string>("PartName"),
                                 PartDescription = _part.Field<string>("Description"),
                                 Unit = _part.Field<string>("Unit"),
                                 LocationCode = _detail.Field<string>("LocationCode"),
                                 Location = _loc.Field<string>("Location"),
                                 StockDate = _detail.Field<DateTime>("StockDate"),
                                 Multiplier = _detail.Field<int>("Multiplier"),
                                 Qty = _detail.Field<int>("Quantity"),
                                 UnitCost = _detail.Field<decimal>("UnitCostUSD"),
                                 Remarks = _detail.Field<string>("Remarks")
                             };

                DataTable _datasource = new DataTable();
                _datasource.TableName = "stockadjustmentdetails";
                DataColumnCollection _cols = _datasource.Columns;

                DataColumn _pk = _cols.Add("DetailId", typeof(long));
                _cols.Add("ReferenceNo", typeof(string));
                _cols.Add("PartCode", typeof(string));
                _cols.Add("PartNo", typeof(string));
                _cols.Add("PartName", typeof(string));
                _cols.Add("Description", typeof(string));
                _cols.Add("Unit", typeof(string));
                _cols.Add("LocationCode", typeof(string));
                _cols.Add("Location", typeof(string));
                _cols.Add("StockDate", typeof(DateTime));
                _cols.Add("UnitCostUSD", typeof(decimal));
                _cols.Add("CurrentQty", typeof(int));
                _cols.Add("Multiplier", typeof(int));
                _cols.Add("Adjustment", typeof(string));
                _cols.Add("Quantity", typeof(int));
                _cols.Add("EndingQty", typeof(int));
                _cols.Add("TotalCost", typeof(decimal));
                _cols.Add("Remarks", typeof(string));

                _datasource.Constraints.Add("PK", _pk, true);
                _pk.AutoIncrement = true; _pk.AutoIncrementSeed = 1;
                _pk.AutoIncrementStep = 1;

                _datasource.SerializeColumns();
                _cols["Multiplier"].DefaultValue = 1;
                _cols["Adjustment"].DefaultValue = "Additional";

                bool _headerloaded = false; bool _closed = false;
                bool _approved = false; bool _voided = false;

                try
                {
                    if (_partinfo != null)
                    {
                        object[] _newrow = new object[_cols.Count];
                        _newrow[_cols["PartCode"].Ordinal] = _partinfo.PartCode;
                        _newrow[_cols["PartNo"].Ordinal] = _partinfo.PartNo;
                        _newrow[_cols["PartName"].Ordinal] = _partinfo.PartName;
                        _newrow[_cols["Description"].Ordinal] = _partinfo.Description;
                        _newrow[_cols["Unit"].Ordinal] = _partinfo.Unit;

                        _datasource.Rows.Add(_newrow);
                    }

                    foreach (var _row in _query)
                    {
                        if (!_headerloaded)
                        {
                            if (VisualBasic.IsDate(_row.DateApproved))
                            {
                                if (VisualBasic.CDate(_row.DateApproved) != VisualBasic.CDate("1/1/1900")) txtDateApproved.Text = VisualBasic.Format(_row.DateApproved, "dd-MMM-yyyy");
                            }

                            if (VisualBasic.IsDate(_row.DateCancelled))
                            {
                                if (VisualBasic.CDate(_row.DateCancelled) != VisualBasic.CDate("1/1/1900")) txtDateCancelled.Text = VisualBasic.Format(_row.DateCancelled, "dd-MMM-yyyy");
                            }

                            if (VisualBasic.IsDate(_row.DateClosed))
                            {
                                if (VisualBasic.CDate(_row.DateClosed) != VisualBasic.CDate("1/1/1900")) txtDateClosed.Text = VisualBasic.Format(_row.DateClosed, "dd-MMM-yyyy");
                            }

                            if (VisualBasic.IsNumeric(_row.Closed)) _closed = VisualBasic.CBool(_row.Closed);
                            if (VisualBasic.IsNumeric(_row.Approved)) _approved = VisualBasic.CBool(_row.Approved);
                            if (VisualBasic.IsNumeric(_row.Cancelled)) _voided = VisualBasic.CBool(_row.Cancelled);

                            if (VisualBasic.IsDate(_row.Dated)) dtpDated.Value = _row.Dated;
                            if (!Materia.IsNullOrNothing(_row.Summary)) txtSummary.Text = _row.Summary;
                            _headerloaded = true;
                        }

                        int _currentqty = GetPartQty(_row.PartCode, _row.LocationCode, _row.StockDate, _row.UnitCost);
                        int _tempty = _currentqty - (_row.Multiplier * _row.Qty);
                        if (_tempty >= 0) _currentqty -= (_row.Multiplier * _row.Qty);
                        
                        DataRow[] _rows = _datasource.Select("[PartCode] LIKE '" + _row.PartCode.ToSqlValidString(true) + "' AND\n" +
                                                             "[LocationCode] LIKE '" + _row.LocationCode.ToSqlValidString(true) + "' AND\n" +
                                                             "[StockDate] = #" + _row.StockDate.ToShortDateString()  + "# AND\n" +
                                                             "[DetailId] < " + _row.DetailId.ToString());

                        if (_rows.Length > 0)
                        {
                            for (int i = 0; i <= (_rows.Length -1); i++) 
                            {
                                DataRow _currentrow = _rows[i];
                                _currentqty += (VisualBasic.CInt(_currentrow["Mutiplier"]) * VisualBasic.CInt(_currentrow["Quantity"]));
                            }
                        }

                        _datasource.Rows.Add(new object[] {
                                             _row.DetailId, _row.ReferenceNo, _row.PartCode,
                                             _row.PartNo, _row.PartName, _row.PartDescription,
                                             _row.Unit, _row.LocationCode, _row.Location,
                                             _row.StockDate, _row.UnitCost, _currentqty,
                                             _row.Multiplier, (_row.Multiplier >= 1 ? "Additional" : "Deduction"), _row.Qty,
                                             _currentqty + (_row.Multiplier * _row.Qty), _row.UnitCost * (_row.Multiplier * _row.Qty), _row.Remarks });

                        _datasource.AcceptChanges();
                    }
                }
                catch { }

                if (_datasource.Rows.Count > 0)
                {
                    object _max = _datasource.Compute("MAX([DetailId])", "");
                    if (VisualBasic.IsNumeric(_max)) _pk.AutoIncrementSeed = VisualBasic.CLng(_max) + 1;
                }

                grdDetails.ClearRowsAndColumns();
                grdDetails.DataSource = _datasource;
                FormatGrid(); ResizeGrid();

                if (!_closed)
                {
                    grdDetails.AllowAddNew = !_approved && !_voided;
                    grdDetails.AllowDelete = !_approved && !_voided;
                    grdDetails.AllowEditing = !_approved && !_voided;
                    btnDelete.Enabled = !_approved && !_voided;
                }
                else
                {
                    _isfinalized = true;
                    dtpDated.Enabled = false; txtSummary.ReadOnly = true;
                    grdDetails.AllowAddNew = false; grdDetails.AllowDelete = false;
                    grdDetails.AllowEditing = false; btnDelete.Enabled = false;
                }

                while (!grdDetails.Redraw) grdDetails.EndUpdate();
                ShowButtons(); ComputeTotal();
            }
        }

        private void InitializeParts()
        {
            DataTable _parts = Cache.GetCachedTable("parts");
            if (_parts != null)
            {
                _partseditor.Enabled = false;

                if (_partseditor.DataSource != null)
                {
                    try { ((DataTable)_partseditor.DataSource).Dispose(); }
                    catch { }
                    finally 
                    { 
                        _partseditor.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _partseditor.DisplayMember = "PartNo"; _partseditor.ValueMember = "PartCode";
                DataTable _datasource = _parts.Replicate();
                _partseditor.DataSource = _datasource;

                ColumnCollection _cols = _partseditor.Cols;
                _cols["PartNo"].Caption = "Part No.";
                _cols["PartName"].Caption = "Part Name";

                _partseditor.Enabled = true;
            }

            if (_partseditor.DataSource != null)
            {
                ColumnCollection _cols = _partseditor.Cols;
                string[] _visiblecols = new string[] { "PartNo", "PartName", "Description" };

                for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++) _cols[i].Visible = _visiblecols.Contains(_cols[i].Name);
            }
        }

        private void ResizeGrid()
        {
            if (grdDetails.DataSource == null) return;
            ColumnCollection _cols = grdDetails.Cols;

            grdDetails.AutoSizeCols(); grdDetails.ExtendLastCol = true;
            _cols[_cols.Fixed - 1].Width = 30;

            for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
            {
                if (_cols[i].Visible)
                {
                    if (_cols[i].Width < 60) _cols[i].Width = 60;
                }
            }

            if (_cols["Description"].Width < 175) _cols["Description"].Width = 175;
            if (_cols["Remarks"].Width < 175) _cols["Remarks"].Width = 175;
        }

        private void ShowButtons()
        {
            btnApprove.Hide(); btnApprove.Enabled = false;
            btnFinalize.Hide(); btnFinalize.Enabled = false;
            btnPreview.Hide(); btnPreview.Enabled = false;
            btnVoid.Hide(); btnVoid.Enabled = false;

            DataTable _stockadj = Cache.GetCachedTable("stockadjustments");

            if (_stockadj != null)
            {
                DataRow[] _rows = _stockadj.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");

                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    bool _closed = false; bool _approved = false;
                    bool _voided = false;

                    if (VisualBasic.IsNumeric(_row["Approved"])) _approved = VisualBasic.CBool(_row["Approved"]);
                    if (VisualBasic.IsNumeric(_row["Closed"])) _closed = VisualBasic.CBool(_row["Closed"]);
                    if (VisualBasic.IsNumeric(_row["Cancelled"])) _voided = VisualBasic.CBool(_row["Cancelled"]);

                    if (!_closed && !_isnew)
                    {
                        if (_voided || _approved)
                        {
                            if (_approved)
                            { btnFinalize.Enabled = true; btnFinalize.Show(); }
                        }
                        else
                        {
                            btnApprove.Enabled = true; btnApprove.Show();
                            btnVoid.Enabled = true; btnVoid.Show();
                        }
                    }

                    if (_closed)
                    {
                        btnSave.Enabled = false; btnSave.Hide();
                        btnSaveAndClose.Enabled = false; btnSaveAndClose.Hide();
                    }

                    if (!_isnew)
                    { btnPreview.Show(); btnPreview.Enabled = true; }
                }
            }
        }

        #endregion

        #region FormEvents

        private void StockAdjustmentInfoDialog_Disposed(object sender, EventArgs e)
        {
            if (_locationseditor != null)
            {
                try { _locationseditor.Dispose(); }
                catch { }
                finally { _locationseditor = null; }
            }

            if (_partseditor != null)
            {
                try { _partseditor.Dispose(); }
                catch { }
                finally { _partseditor = null; }
            }

            if (_dateeditor != null)
            {
                try { _dateeditor.Dispose(); }
                catch { }
                finally { _dateeditor = null; }
            }

            if (_qtyeditor != null)
            {
                try { _qtyeditor.Dispose(); }
                catch { }
                finally { _qtyeditor = null; }
            }

            if (_amounteditor != null)
            {
                try { _amounteditor.Dispose(); }
                catch { }
                finally { _amounteditor = null; }
            }

            if (_remarkseditor != null)
            {
                try { _remarkseditor.Dispose(); }
                catch { }
                finally { _remarkseditor = null; }
            }

            Materia.RefreshAndManageCurrentProcess();
        }

        private void StockAdjustmentInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            dtpDated.ButtonDropDown.Visible = true; dtpDated.CustomFormat = "dd-MMM-yyyy";
            dtpDated.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpDated.MaxDate = DateTime.Now.Date; dtpDated.AllowEmptyState = false;
            dtpDated.Value = DateTime.Now.Date;

            _dateeditor.ButtonDropDown.Visible = true; _dateeditor.CustomFormat = "dd-MMM-yyyy";
            _dateeditor.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            _dateeditor.MaxDate = DateTime.Now.Date; _dateeditor.AllowEmptyState = false;
            _dateeditor.Value = DateTime.Now.Date;

            _qtyeditor.MinValue = 0; _qtyeditor.MaxValue = 25000;
            _qtyeditor.AllowEmptyState = false; _qtyeditor.ShowUpDown = false;

            _amounteditor.MinValue = 0; _amounteditor.MaxValue = 3000000;
            _amounteditor.AllowEmptyState = false; _amounteditor.ShowUpDown = false;

            grdDetails.InitializeAppearance(); _locationseditor.LoadLocations();
            InitializeParts();

            if (_isnew)
            {
                string _refno = SCMS.GetTableSeriesNumber("stockadjustments");
                txtReferenceNo.Text = "ADJ-" + SCMS.CurrentCompany.Company + "-" + _refno;
            }
            else txtReferenceNo.Text = _referenceno;

            txtReferenceNo.ReadOnly = true;
            txtDateApproved.ReadOnly = true; txtDateCancelled.ReadOnly = true;
            txtDateClosed.ReadOnly = true;
            txtTotalCost.Text = "0.00"; txtTotalCost.ReadOnly = true;
            txtTotalCost.TextAlign = HorizontalAlignment.Right;

            txtSummary.SetAsRequired();

            InitializeInfo();
        }

        private void StockAdjustmentInfoDialog_Shown(object sender, EventArgs e)
        { 
            if (!_isshown) _isshown = true;
            if (dtpDated.Enabled) dtpDated.Focus();
            else
            {
                if (txtSummary.Enabled) txtSummary.Focus();
            }
        }

        #endregion

        #region GridEvents

        private void grdDetails_AfterEdit(object sender, RowColEventArgs e)
        {
            if (!_isshown) return;
            if (grdDetails.DataSource == null) return;
            RowCollection _rows = grdDetails.Rows;
            if (e.Row < (_rows.Fixed)) return;

            ColumnCollection _cols = grdDetails.Cols;

            if (_cols[e.Col].Name == "PartNo")
            {
                if (!Materia.IsNullOrNothing(grdDetails[e.Row, e.Col]))
                {
                    string _partno = grdDetails[e.Row, e.Col].ToString();
                    DataTable _parts = Cache.GetCachedTable("parts");
                    if (_parts != null)
                    {
                        DataRow[] _selrows = _parts.Select("[PartNo] LIKE '" + _partno.ToSqlValidString(true) + "' AND\n" +
                                                           "[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            DataRow _row = _selrows[0];
                            grdDetails[e.Row, "PartCode"] = _row["PartCode"];
                            grdDetails[e.Row, "PartName"] = _row["PartName"];
                            grdDetails[e.Row, "Description"] = _row["Description"];
                            grdDetails[e.Row, "Unit"] = _row["Unit"];
                        }
                        else
                        {
                            grdDetails[e.Row, "PartCode"] = "";
                            grdDetails[e.Row, "PartName"] = "";
                            grdDetails[e.Row, "Description"] = "";
                            grdDetails[e.Row, "Unit"] = "";
                        }
                    }
                    else
                    {
                        grdDetails[e.Row, "PartCode"] = "";
                        grdDetails[e.Row, "PartName"] = "";
                        grdDetails[e.Row, "Description"] = "";
                        grdDetails[e.Row, "Unit"] = "";
                    }
                }
                else
                {
                    grdDetails[e.Row, "PartCode"] = "";
                    grdDetails[e.Row, "PartName"] = "";
                    grdDetails[e.Row, "Description"] = "";
                    grdDetails[e.Row, "Unit"] = "";
                }
            }
            else if (_cols[e.Col].Name == "Location")
            {
                if (!Materia.IsNullOrNothing(grdDetails[e.Row, e.Col]))
                {
                    DataTable _locations = Cache.GetCachedTable("locations");
                    if (_locations != null)
                    {
                        string _location = grdDetails[e.Row, e.Col].ToString();
                        DataRow[] _selrows = _locations.Select("[Location] LIKE '" + _location.ToSqlValidString(true) + "' AND\n" +
                                                               "[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0) grdDetails[e.Row, "LocationCode"] = _selrows[0]["LocationCode"];
                        else grdDetails[e.Row, "LocationCode"] = "";
                    }
                    else grdDetails[e.Row, "LocationCode"] = "";
                }
                else grdDetails[e.Row, "LocationCode"] = "";
            }
            else if (_cols[e.Col].Name == "Adjustment")
            {
                string _adj = ""; int _multiplier = 0;

                if (!Materia.IsNullOrNothing(grdDetails[e.Row, e.Col])) _adj = grdDetails[e.Row, e.Col].ToString();
                if (_adj.ToLower() == "additional") _multiplier = 1;
                else if (_adj.ToLower() == "deduction") _multiplier = -1;
                else { }

                grdDetails[e.Row, "Multiplier"] = _multiplier;
            }
            else { }

            if (_cols[e.Col].Name == "PartNo" ||
                _cols[e.Col].Name == "Location" ||
                _cols[e.Col].Name == "StockDate" ||
                _cols[e.Col].Name == "UnitCostUSD" ||
                _cols[e.Col].Name == "Quantity" ||
                _cols[e.Col].Name == "Adjustment")
            {
                DataTable _ledger = Cache.GetCachedTable("stockledger");

                decimal _unitcost = 0;
                string _partcode = ""; string _locationcode = "";
                DateTime _stockdate = DateTime.Now.Date;

                if (!Materia.IsNullOrNothing(grdDetails[e.Row, "PartCode"])) _partcode = grdDetails[e.Row, "PartCode"].ToString();
                if (!Materia.IsNullOrNothing(grdDetails[e.Row, "LocationCode"])) _locationcode = grdDetails[e.Row, "LocationCode"].ToString();
                if (VisualBasic.IsDate(grdDetails[e.Row, "StockDate"])) _stockdate = VisualBasic.CDate(grdDetails[e.Row, "StockDate"]);
                if (VisualBasic.IsNumeric(grdDetails[e.Row, "UnitCostUSD"])) _unitcost = VisualBasic.CDec(grdDetails[e.Row, "UnitCostUSD"]);

                if (_cols[e.Col].Name != "UnitCostUSD")
                {
                    if (_unitcost <= 0)
                    {
                        object _maxcost = _ledger.Compute("MAX([UnitCostUSD])", "[PartCode] LIKE '" + _partcode.ToSqlValidString(true) + "' AND\n" +
                                                                                "[LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "' AND\n" +
                                                                                "[PurchaseDate] = #" + _stockdate.ToShortDateString() + "#");

                        if (VisualBasic.IsNumeric(_maxcost))
                        {
                            _unitcost = VisualBasic.CDec(_maxcost);
                            grdDetails[e.Row, "UnitCostUSD"] = VisualBasic.CDec(_maxcost);
                        }
                    }
                }

                int _currentqty = GetPartQty(_partcode, _locationcode, _stockdate, _unitcost);
                DataTable _datasource = null;

                try { _datasource = (DataTable)grdDetails.DataSource; }
                catch { }

                if (_datasource != null)
                {
                    long _id = 0;
                    if (VisualBasic.IsNumeric(grdDetails[e.Row, "DetailId"])) _id = VisualBasic.CLng(grdDetails[e.Row, "DetailId"]);

                    DataRow[] _selrows = _datasource.Select("[PartCode] LIKE '" + _partcode.ToSqlValidString(true) + "' AND\n" +
                                                            "[LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "' AND\n" +
                                                            "[StockDate] = #" + _stockdate.ToShortDateString() + "# AND\n" +
                                                            "[DetailId] < " + _id.ToString());

                    if (_selrows.Length > 0)
                    {
                        for (int i = 0; i <= (_selrows.Length - 1); i++)
                        {
                            DataRow _currentrow = _selrows[i];
                            _currentqty += (VisualBasic.CInt(_currentrow["Multiplier"]) * VisualBasic.CInt(_currentrow["Quantity"]));
                        }
                    }
                }

                grdDetails[e.Row, "CurrentQty"] = _currentqty;
                int _multiplier = 0; int _qty = 0;

                if (VisualBasic.IsNumeric(grdDetails[e.Row, "Multiplier"])) _multiplier = VisualBasic.CInt(grdDetails[e.Row, "Multiplier"]);
                if (VisualBasic.IsNumeric(grdDetails[e.Row, "Quantity"])) _qty = VisualBasic.CInt(grdDetails[e.Row, "Quantity"]);
                grdDetails[e.Row, "EndingQty"] = _currentqty + (_multiplier * _qty);
                grdDetails[e.Row, "TotalCost"] = _unitcost * (_multiplier * _qty);
                ComputeTotal();
            }
        }

        #endregion

        #region ControlEvents

        private void Field_Edited(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!_isshown) return;
            if (sender is ButtonItem)
            {
                if (!((ButtonItem)sender).Enabled) return;
            }

            if (!_updated) _updated = true;
            this.MarkAsEdited();
        }

        private void Field_Edited(object sender, RowColEventArgs e)
        {
            if (sender == null) return;
            if (!_isshown) return;

            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.ErrorProvider.SetError((Control)sender, "");

            if (!_updated) _updated = true;
            this.MarkAsEdited();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_cancelled) _cancelled = true;
            DialogResult = System.Windows.Forms.DialogResult.Cancel; Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!btnDelete.Enabled) return;
            if (!_isshown) return;
            if (!grdDetails.Redraw) return;
            if (grdDetails.DataSource == null) return;
            if (grdDetails.RowSel < grdDetails.Rows.Fixed) return;

            long _id = 0;

            if (VisualBasic.IsNumeric(grdDetails[grdDetails.RowSel, "DetailId"])) _id = VisualBasic.CLng(grdDetails[grdDetails.RowSel, "DetailId"]);

            if (_id > 0)
            {
                DataTable _datasource = null;

                try { _datasource = (DataTable)grdDetails.DataSource; }
                catch { }

                if (_datasource != null)
                {
                    DataRow[] _rows = _datasource.Select("[DetailId] = " + _id.ToString());
                    if (_rows.Length > 0)
                    {
                        if (grdDetails.Redraw) grdDetails.BeginUpdate();

                        foreach (DataRow _row in _rows) _row.Delete();

                        for (int i = 0; i <= _datasource.Rows.Count - 1; i++)
                        {
                            DataRow _row = _datasource.Rows[i];
                            if (_row.RowState != DataRowState.Deleted &&
                                _row.RowState != DataRowState.Detached)
                            {
                                string _partcode = ""; string _locationcode = "";
                                DateTime _stockdate = DateTime.Now.Date; decimal _unitcost = 0;

                                if (!Materia.IsNullOrNothing(_row["PartCode"])) _partcode = _row["PartCode"].ToString();
                                if (!Materia.IsNullOrNothing(_row["LocationCode"])) _locationcode = _row["LocationCode"].ToString();
                                if (VisualBasic.IsDate(_row["StockDate"])) _stockdate = VisualBasic.CDate(_row["StockDate"]);
                                if (VisualBasic.IsNumeric(_row["UnitCostUSD"])) _unitcost = VisualBasic.CDec(_row["UnitCostUSD"]);

                                int _currentqty = GetPartQty(_partcode, _locationcode, _stockdate, _unitcost);

                                DataRow[] _selrows = _datasource.Select("[PartCode] LIKE '" + _partcode.ToSqlValidString(true) + "' AND\n" +
                                                            "[LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "' AND\n" +
                                                            "[StockDate] = #" + _stockdate.ToShortDateString() + "# AND\n" +
                                                            "[DetailId] < " + _id.ToString());

                                if (_selrows.Length > 0)
                                {
                                    for (int c = 0; c <= (_selrows.Length - 1); c++)
                                    {
                                        DataRow _currentrow = _selrows[c];
                                        _currentqty += (VisualBasic.CInt(_currentrow["Multiplier"]) * VisualBasic.CInt(_currentrow["Quantity"]));
                                    }
                                }

                                _row["CurrentQty"] = _currentqty;
                                int _multiplier = 0; int _qty = 0;

                                if (VisualBasic.IsNumeric(_row["Multiplier"])) _multiplier = VisualBasic.CInt(_row["Multiplier"]);
                                if (VisualBasic.IsNumeric(_row["Quantity"])) _qty = VisualBasic.CInt(_row["Quantity"]);

                                _row["EndingQty"] = _currentqty + (_multiplier * _qty);
                                _row["TotalCost"] = _unitcost * (_multiplier * _qty);
                            }       
                        }

                        FormatGrid(); ResizeGrid();

                        while (!grdDetails.Redraw) grdDetails.EndUpdate();
                    }
                }
            }
            else
            {
                grdDetails.RemoveItem(grdDetails.RowSel);
                _updated = true; this.MarkAsEdited();
            }

            ComputeTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;
            if (!grdDetails.Redraw) return;
            if (grdDetails.DataSource == null) return;

            try { grdDetails.Row = grdDetails.Rows.Fixed - 1; }
            catch { }
            ComputeTotal();

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtSummary, !string.IsNullOrEmpty(txtSummary.Text.RLTrim()), "Please specify stock adjustment description / summary.")) return;
            DataTable _datasource = null;

            try { _datasource = (DataTable)grdDetails.DataSource; }
            catch { }

            DataTable _parts = Cache.GetCachedTable("parts");
            DataTable _locations = Cache.GetCachedTable("locations");

            if (_datasource != null &&
                _parts != null &&
                _locations != null)
            {
           
                if (_datasource.Rows.Count <= 0)
                {
                    MsgBoxEx.Shout("Please specify at leasts a stock adjustment entry.", "Stock Adjustment Notification");
                    return;
                }

                for (int i = grdDetails.Rows.Fixed; i <= (grdDetails.Rows.Count - 1); i++)
                {
                    Row _row = grdDetails.Rows[i];

                    if (!Materia.IsNullOrNothing(_row["PartCode"]) &&
                        !Materia.IsNullOrNothing(_row["LocationCode"]) &&
                        !Materia.IsNullOrNothing(_row["Adjustment"]) &&
                        VisualBasic.IsDate(_row["StockDate"]) &&
                        VisualBasic.IsNumeric(_row["UnitCostUSD"]) &&
                        VisualBasic.IsNumeric(_row["Quantity"]) &&
                        VisualBasic.IsNumeric(_row["Multiplier"]) &&
                        VisualBasic.IsNumeric(_row["EndingQty"]))
                    {
                        string _partcode = _row["PartCode"].ToString();
                        if (_parts.Select("[PartCode] LIKE '" + _partcode.ToSqlValidString(true) + "' AND\n" +
                                          "[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'").Length <= 0)
                        {
                            MsgBoxEx.Shout("Please specify a valid part number at row : " + i.ToString() + ".", "Stock Adjustment Notification");
                            grdDetails.StartEditing(i, grdDetails.Cols["PartNo"].Index); return;
                        }

                        string _locationcode = _row["LocationCode"].ToString();
                        if (_locations.Select("[LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "' AND\n" +
                                              "[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'").Length <= 0)
                        {
                            MsgBoxEx.Shout("Please specify a valid location at row : " + i.ToString() + ".", "Stock Adjustment Notification");
                            grdDetails.StartEditing(i, grdDetails.Cols["Location"].Index); return;
                        }

                        int _multiplier = VisualBasic.CInt(_row["Multiplier"]);

                        if (_multiplier == 0)
                        {
                            MsgBoxEx.Shout("Please specify a correct stock adjustment type at row : " + i.ToString() + ".", "Stock Adjustment Notification");
                            grdDetails.StartEditing(i, grdDetails.Cols["Adjustment"].Index); return;
                        }

                        int _qty = VisualBasic.CInt(_row["Quantity"]);

                        if (_qty <= 0)
                        {
                            MsgBoxEx.Shout("Please specify a correct stock adjustment quantity at row : " + i.ToString() + ".", "Stock Adjustment Notification");
                            grdDetails.StartEditing(i, grdDetails.Cols["Quantity"].Index); return;
                        }

                        int _endingqty = VisualBasic.CInt(_row["EndingQty"]);

                        if (_endingqty < 0)
                        {
                            MsgBoxEx.Shout("Please specify a correct quantity at row : " + i.ToString() + ".", "Stock Adjustment Notification");
                            grdDetails.StartEditing(i, grdDetails.Cols["Quantity"].Index); return;
                        }
                    }
                }
            }

            DataTable _stockadjustments = Cache.GetCachedTable("stockadjustments");
            DataTable _stockadjdetails = Cache.GetCachedTable("stockadjustmentdetails");
            DataTable _stockledger = Cache.GetCachedTable("stockledger");
                            
            if (_stockadjustments != null &&
                _stockadjdetails != null)
            {
                string _refno = "";
                DataColumnCollection _cols = _stockadjustments.Columns;

                if (_isnew)
                {
                    Cursor = Cursors.WaitCursor;
                    Func<string, bool, string> _delegate = new Func<string, bool, string>(SCMS.GetTableSeriesNumber);
                    IAsyncResult _result = _delegate.BeginInvoke("stockadjustments", true, null, _delegate);

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

                    string _seriesno = _delegate.EndInvoke(_result);
                    _refno = "ADJ-" + SCMS.CurrentCompany.Company + "-" + _seriesno;
                    Cursor = Cursors.Default;

                    object[] _values = new object[_cols.Count];

                    _values[_cols["ReferenceNo"].Ordinal] = _refno;
                    _values[_cols["Dated"].Ordinal] = dtpDated.Value;
                    _values[_cols["Summary"].Ordinal] = txtSummary.Text;
                    _values[_cols["Username"].Ordinal] = SCMS.CurrentSystemUser.Username;
                    _values[_cols["Company"].Ordinal] = SCMS.CurrentCompany.Company;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _stockadjustments.Rows.Add(_values);
                }
                else
                {
                    if (sender != null)
                    {
                        if (sender is Button)
                        {
                            if (sender == btnApprove)
                            {
                                if (MsgBoxEx.Ask("You are about to <font color=\"blue\">approve</font> the current stock adjustment. If you proceed<br />" +
                                                 "adjusted parts can't be modified anymore. Continue anyway?", "Approve Stock Adjustment") != System.Windows.Forms.DialogResult.Yes) return;
                            }
                            else if (sender == btnVoid)
                            {
                                if (MsgBoxEx.Ask("You are about to <font color=\"red\">void / cancel</font> the current stock adjustment. If you proceed<br />" +
                                                 "adjusted parts will be invalidated. Continue anyway?", "Void Stock Adjustment") != System.Windows.Forms.DialogResult.Yes) return;
                            }
                            else if (sender == btnFinalize)
                            {
                                if (MsgBoxEx.Ask("You are about to <font color=\"green\">finalize</font> the current stock adjustment. If you proceed<br />" +
                                                 "adjusted parts will reflect in the inventory. Continue anyway?", "Close Stock Adjustment") != System.Windows.Forms.DialogResult.Yes) return;
                            }
                            else { }
                        }
                    }

                    DataRow[] _existing = _stockadjustments.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _refno = _referenceno;
                        _existing[0]["Dated"] = dtpDated.Value;
                        _existing[0]["Summary"] = txtSummary.Text;

                        if (sender != null)
                        {
                            if (sender is Button)
                            {
                                if (sender == btnApprove)
                                {
                                    LongTextInputDialog _dialog = new LongTextInputDialog();
                                    _dialog.Text = "Approval Remarks";
                                    _dialog.EntryWatermark = "<i>Enter approval remarks / comments here...</i>";
                                    if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    {
                                        _dialog.Dispose(); _dialog = null;
                                        Materia.RefreshAndManageCurrentProcess();
                                        _stockadjustments.RejectChanges();
                                        return;
                                    }
                                    
                                    _existing[0]["ApprovalRemarks"] = _dialog.TextValue;
                                    _dialog.Dispose(); _dialog = null;
                                    Materia.RefreshAndManageCurrentProcess();

                                    _existing[0]["Approved"] = 1;
                                    _existing[0]["DateApproved"] = DateTime.Now;
                                    _existing[0]["ApprovedBy"] = SCMS.CurrentSystemUser.Username;
                                }
                                else if (sender == btnVoid)
                                {
                                    LongTextInputDialog _dialog = new LongTextInputDialog();
                                    _dialog.Text = "Cancellation Remarks";
                                    _dialog.EntryWatermark = "<i>Enter cancellation remarks / comments here...</i>";
                                    if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    {
                                        _dialog.Dispose(); _dialog = null;
                                        Materia.RefreshAndManageCurrentProcess();
                                        _stockadjustments.RejectChanges();
                                        return;
                                    }

                                    _existing[0]["CancellationRemarks"] = _dialog.TextValue;
                                    _dialog.Dispose(); _dialog = null; Materia.RefreshAndManageCurrentProcess();

                                    _existing[0]["Cancelled"] = 1;
                                    _existing[0]["DateCancelled"] = DateTime.Now;
                                    _existing[0]["CancelledBy"] = SCMS.CurrentSystemUser.Username;
                                    _existing[0]["Closed"] = 1;
                                    _existing[0]["DateClosed"] = DateTime.Now;
                                    _existing[0]["ClosedBy"] = SCMS.CurrentSystemUser.Username;
                                }
                                else if (sender == btnFinalize)
                                {
                                    LongTextInputDialog _dialog = new LongTextInputDialog();
                                    _dialog.Text = "Closing Remarks";
                                    _dialog.EntryWatermark = "<i>Enter closing remarks / comments here...</i>";
                                    if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    {
                                        _dialog.Dispose(); _dialog = null;
                                        Materia.RefreshAndManageCurrentProcess();
                                        _stockadjustments.RejectChanges();
                                        return;
                                    }

                                    _existing[0]["ClosingRemarks"] = _dialog.TextValue;
                                    _dialog.Dispose(); _dialog = null; Materia.RefreshAndManageCurrentProcess();

                                    _existing[0]["Closed"] = 1;
                                    _existing[0]["DateClosed"] = DateTime.Now;
                                    _existing[0]["ClosedBy"] = SCMS.CurrentSystemUser.Username;
                                }
                                else { }
                            }
                        }
                    }
                }

                string _query = "";
                QueryGenerator _generator = new QueryGenerator(_stockadjustments);
                _generator.ExcludedFields.Add("LastModified");
                _query = _generator.ToString();

                DataTable _changes = _datasource.GetChanges();

                if (_changes != null)
                {
                    if (_changes.Rows.Count > 0)
                    {
                        for (int i = 0; i <= (_changes.Rows.Count - 1); i++)
                        {
                            DataRow _row = _changes.Rows[i];
                            long _id = 0;

                            switch (_row.RowState)
                            {
                                case DataRowState.Deleted:
                                case DataRowState.Detached:
                                    try { _id = VisualBasic.CLng(_row["DetailId", DataRowVersion.Original]); }
                                    catch { }
                                    DataRow[] _deletedrows = _stockadjdetails.Select("[DetailId] = " + _id.ToString());
                                    if (_deletedrows.Length > 0) _deletedrows[0].Delete();
                                    break;
                                case DataRowState.Modified:
                                    try { _id = VisualBasic.CLng(_row["DetailId", DataRowVersion.Original]); }
                                    catch { }
                                    DataRow[] _updatedrows = _stockadjdetails.Select("[DetailId] = " + _id.ToString());
                                    if (_updatedrows.Length > 0)
                                    {
                                        DataRow _updatedrow = _updatedrows[0];
                                        for (int c = 0; c <= (_stockadjdetails.Columns.Count - 1); c++)
                                        {
                                            if (_datasource.Columns.Contains(_stockadjdetails.Columns[c].ColumnName)) _updatedrow[_stockadjdetails.Columns[c].ColumnName] = _row[_stockadjdetails.Columns[c].ColumnName];
                                        }
                                    }
                                    break;
                                case DataRowState.Added:
                                    object[] _newdetail = new object[_stockadjdetails.Columns.Count];
                                    DataColumnCollection _detailcols = _stockadjdetails.Columns;
                                    for (int c = 0; c <= (_stockadjdetails.Columns.Count - 1); c++)
                                    {
                                        if (_datasource.Columns.Contains(_stockadjdetails.Columns[c].ColumnName) &&
                                            !_stockadjdetails.Columns[c].Unique) _newdetail[_stockadjdetails.Columns[c].Ordinal] = _row[_stockadjdetails.Columns[c].ColumnName];
                                    }
                                    _newdetail[_detailcols["ReferenceNo"].Ordinal] = _refno;
                                    _stockadjdetails.Rows.Add(_newdetail);
                                    break;
                                default: break;
                            }
                        }
                    }
                }

                _generator = null; Materia.RefreshAndManageCurrentProcess();
                _generator = new QueryGenerator(_stockadjdetails);
                _generator.ExcludedFields.Add("LastModified");
                _query += "\n" + _generator.ToString();

                if (sender != null)
                {
                    if (sender is Button)
                    {
                        if (sender == btnFinalize)
                        {
                            if (_stockledger != null)
                            {
                                DataColumnCollection _ledgercols = _stockledger.Columns;

                                for (int i = 0; i <= (_datasource.Rows.Count - 1); i++)
                                {
                                    DataRow _currentrow = _datasource.Rows[i];
                                    object[] _items = new object[_ledgercols.Count];

                                    _items[_ledgercols["PartCode"].Ordinal] = _currentrow["PartCode"];
                                    _items[_ledgercols["PurchaseDate"].Ordinal] = _currentrow["StockDate"];
                                    _items[_ledgercols["Dated"].Ordinal] = dtpDated.Value;
                                    _items[_ledgercols["ReferenceNo"].Ordinal] = _referenceno;

                                    int _multiplier = VisualBasic.CInt(_currentrow["Multiplier"]);
                                    if (_multiplier > 0) _items[_ledgercols["TransactionType"].Ordinal] = StockTransactionType.StockAdjustmentAdd;
                                    else _items[_ledgercols["TransactionType"].Ordinal] = StockTransactionType.StockAdjustmentDeduct;

                                    _items[_ledgercols["LocationCode"].Ordinal] = _currentrow["LocationCode"];

                                    if (_multiplier > 0) _items[_ledgercols["In"].Ordinal] = _currentrow["Quantity"];
                                    else _items[_ledgercols["Out"].Ordinal] = _currentrow["Quantity"];

                                    decimal _unitcost = VisualBasic.CDec(_currentrow["UnitCostUSD"]);

                                    _items[_ledgercols["UnitCost"].Ordinal] = _unitcost;
                                    _items[_ledgercols["UnitCostUSD"].Ordinal] = _unitcost;
                                    _items[_ledgercols["Currency"].Ordinal] = "USD";
                                    _items[_ledgercols["Rate"].Ordinal] = 100;

                                    _items[_ledgercols["TotalCost"].Ordinal] = _unitcost * (_multiplier * VisualBasic.CInt(_currentrow["Quantity"]));
                                    _items[_ledgercols["TotalCostUSD"].Ordinal] = _unitcost * (_multiplier * VisualBasic.CInt(_currentrow["Quantity"]));
                                    _items[_ledgercols["Username"].Ordinal] = SCMS.CurrentSystemUser.Username;

                                    _stockledger.Rows.Add(_items);
                                }

                                _generator = null; Materia.RefreshAndManageCurrentProcess();
                                _generator = new QueryGenerator(_stockledger);
                                _generator.ExcludedFields.Add("LastModified");
                                _query += "\n" + _generator.ToString();
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;
                    if (btnFinalize.Visible) btnFinalize.Enabled = false;
                    if (btnApprove.Visible) btnApprove.Enabled = false;
                    if (btnVoid.Visible) btnVoid.Enabled = false;
                    if (btnPreview.Visible) btnPreview.Enabled = false;

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
                            UserAction _action = UserAction.Add;
                            if (!_isnew) _action = UserAction.Edit;

                            string _log = "Added a new stock adjustment : " + _refno + ".";
                            if (!_isnew)
                            {
                                if (sender != null)
                                {
                                    if (sender is Button)
                                    {
                                        if (sender == btnApprove) _log = "Approved stock adjustment : " + _referenceno + ".";
                                        else if (sender == btnVoid) _log = "Cancelled stock adjustment : " + _referenceno + ".";
                                        else if (sender == btnFinalize)
                                        {
                                            _log = "Closed stock adjustment : " + _referenceno + ".";
                                            _action = UserAction.FinalizeTransaction;
                                        }
                                        else { }
                                    }
                                    else _log = "Updated stock adjustment : " + _referenceno + ".";
                                }
                                else _log = "Updated stock adjustment : " + _referenceno + ".";
                            }

                            Cursor = Cursors.WaitCursor;
                            _stockadjustments.AcceptChanges();

                            if (!_isnew)
                            {
                                _stockadjdetails.AcceptChanges();
                                _datasource.AcceptChanges();
                            }
                            
                            if (_stockledger != null)
                            {
                                if (sender != null)
                                {
                                    if (sender is Button)
                                    {
                                        if (sender == btnFinalize)
                                        {
                                            _stockledger.RejectChanges();
                                            IAsyncResult _syncresult = Cache.SyncTableAsync(SCMS.Connection, "stockledger");
                                            _syncresult.WaitToFinish();
                                        }
                                    }
                                }
                            }

                            if (_isnew) 
                            { 
                                _referenceno = _refno; _isnew = false;
                                txtReferenceNo.Text = _referenceno;
                                _stockadjdetails.RejectChanges();
                                if (_partinfo != null)
                                {
                                    _partinfo = null; Materia.RefreshAndManageCurrentProcess();
                                }
                                IAsyncResult _detailresult = Cache.SyncTableAsync(SCMS.Connection, "stockadjustmentdetails");
                                _detailresult.WaitToFinish(); InitializeInfo();
                            }
                            
                            if (_updated) _updated = false;
                            if (!_withupdates) _withupdates = true;
                            Text = Text.Replace(" *", "").Replace("*", "");

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _log, _referenceno);
                            _logresult.WaitToFinish();

                            Cursor = Cursors.Default;

                            if (sender != null)
                            {
                                if (sender is Button)
                                {
                                    if (sender == btnSaveAndClose)
                                    { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                                    else if (sender == btnApprove)
                                    {
                                        txtDateApproved.Text = VisualBasic.Format(DateTime.Now, "dd-MMM-yyyy");
                                        grdDetails.AllowAddNew = false; grdDetails.AllowEditing = false;
                                        grdDetails.AllowDelete = false; btnDelete.Enabled = false;
                                    }
                                    else if (sender == btnVoid)
                                    {
                                        txtDateCancelled.Text = VisualBasic.Format(DateTime.Now, "dd-MMM-yyyy");
                                        grdDetails.AllowAddNew = false; grdDetails.AllowEditing = false;
                                        grdDetails.AllowDelete = false; btnDelete.Enabled = false;
                                    }
                                    else if (sender == btnFinalize)
                                    {
                                        txtDateClosed.Text = VisualBasic.Format(DateTime.Now, "dd-MMM-yyyy");
                                        dtpDated.Enabled = false; txtSummary.ReadOnly = true;
                                        grdDetails.AllowAddNew = false; grdDetails.AllowEditing = false;
                                        grdDetails.AllowDelete = false; btnDelete.Enabled = false;
                                        _isfinalized = true;
                                    }
                                    else { }

                                    ShowButtons();
                                }
                            }
                       }
                       else
                       {
                           if (_queresult.Error.Contains("duplicate")) btnSave_Click(sender, new EventArgs());
                           else
                           {
                               SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                               MsgBoxEx.Alert("Failed to save the current stock adjustment.", "Save Stock Adjustment");
                           }

                           _stockadjustments.RejectChanges(); _stockadjdetails.RejectChanges();
                           if (_stockledger != null) _stockledger.RejectChanges();

                           if (btnFinalize.Visible) btnFinalize.Enabled = true;
                           if (btnApprove.Visible) btnApprove.Enabled = true;
                           if (btnVoid.Visible) btnVoid.Enabled = true;
                           if (btnPreview.Visible) btnPreview.Enabled = true;
                       }

                        _queresult.Dispose();
                     }

                     btnSave.Enabled = true; btnSaveAndClose.Enabled = true;
                }
            }
            else
            {
                if (sender == btnSaveAndClose)
                { DialogResult = System.Windows.Forms.DialogResult.None; Close(); }
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        { if (btnSaveAndClose.Enabled) btnSave_Click(btnSaveAndClose, e); }

        private void btnApprove_Click(object sender, EventArgs e)
        { if (btnApprove.Enabled) btnSave_Click(btnApprove, e); }

        private void btnVoid_Click(object sender, EventArgs e)
        { if (btnVoid.Enabled) btnSave_Click(btnVoid, e); }

        private void btnFinalize_Click(object sender, EventArgs e)
        { if (btnFinalize.Enabled) btnSave_Click(btnFinalize, e); }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        {  btnSave_Click(btnSave, e); }

        private void exppnl_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (!_isshown) return;
            if (SCMS.Validators.Contains(this)) SCMS.Validators[this].Highlighter.UpdateHighlights();
        }

        #endregion

    }
}
