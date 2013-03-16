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
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class PartInformationDialog : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of PartInformationDialog. 
        /// </summary>
        public PartInformationDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of PartInformationDialog. 
        /// </summary>
        public PartInformationDialog(string code)
        {
            InitializeComponent();

            _partcode = code; _isnew = false;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Form _invokingform = null;

        /// <summary>
        /// Gets or sets the invoking form for this dialog.
        /// </summary>
        public Form InvokingForm
        {
            get { return _invokingform; }
            set { _invokingform = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _partcode = "";

        /// <summary>
        /// Gets the current updated part's code.
        /// </summary>
        public string PartCode
        {
            get { return _partcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _supersession = "";

        /// <summary>
        /// Gets or sets the part supersession code for the current updated part.
        /// </summary>
        public string Supersession
        {
            get { return _supersession; }
            set { _supersession = value; }
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

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isnew = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isshown = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _updated = false;

        #endregion

        private void AttachEditorHandler()
        {
            txtDescription.TextChanged += new EventHandler(Field_Edited);
            txtNotes.TextChanged += new EventHandler(Field_Edited);
            txtPartNo.TextChanged += new EventHandler(Field_Edited);
            txtReorderPoint.ValueChanged += new EventHandler(Field_Edited);
            txtReorderQty.ValueChanged += new EventHandler(Field_Edited);
            cboCountry.SelectedValueChanged += new EventHandler(Field_Edited);
            cboBrand.SelectedValueChanged += new EventHandler(Field_Edited);
            cboModel.SelectedValueChanged += new EventHandler(Field_Edited);
            cboPartName.SelectedValueChanged += new EventHandler(Field_Edited);
            cboStatus.SelectedValueChanged += new EventHandler(Field_Edited);
            cboType.SelectedValueChanged += new EventHandler(Field_Edited);
            cboUom.SelectedValueChanged += new EventHandler(Field_Edited);
            grdMisc.AfterEdit += new RowColEventHandler(Field_Edited);
        }

        /// <summary>
        /// Clears the dialog's information rendering it to be in a new instance state.
        /// </summary>
        public void ClearInformation()
        {
            _partcode = ""; _isnew = true;
            _isshown = false; _updated = false;

            txtCategory.Text = ""; txtDescription.Text = "";
            txtEnding.Text = "0"; txtIncoming.Text = "0";
            txtNotes.Text = ""; txtOutgoing.Text = "0";
            txtPartNo.Text = ""; txtQty.Text = "0";
            txtReorderPoint.Value = 0; txtReorderQty.Value = 0;
            
            try { cboBrand.SelectedIndex = -1; }
            catch { }

            DataTable _models = null;

            if (cboModel.DataSource != null)
            {
                try { _models = (DataTable)cboModel.DataSource; }
                catch { }
            }

            if (_models != null) _models.DefaultView.RowFilter = "[Brand] LIKE ''";

            try { cboCountry.SelectedIndex = -1; }
            catch { }

            try { cboPartName.SelectedIndex = -1; }
            catch { }

            try { cboStatus.SelectedValue = 1; }
            catch { }

            try { cboType.SelectedValue = 2; }
            catch { }

            try { cboUom.SelectedIndex = -1; }
            catch { }

            InitializeUDFs();

            tbctrl.SelectedTab = tbGeneral;
            tbAlternative.Visible = false;
            tbLocations.Visible = false;
            tbLedger.Visible = false;

            lblAdjustment.Hide(); lblAdjustment.Enabled = false;
            lblViewIncoming.Hide(); lblViewIncoming.Enabled = false;
            lblViewOutgoing.Hide(); lblViewOutgoing.Enabled = false;

            _isshown = true;
        }

        private void InitializeLocations()
        {
            if (grdLocations.Redraw) grdLocations.BeginUpdate();

            DataTable _stockledger = Cache.GetCachedTable("stockledger");
            DataTable _locations = Cache.GetCachedTable("locations");

            if (_stockledger != null &&
                _locations != null)
            {
                var _query = from _ledger in _stockledger.AsEnumerable()
                             join _loc in _locations.AsEnumerable() on _ledger.Field<string>("LocationCode") equals _loc.Field<string>("LocationCode") into _l
                             where _ledger.Field<string>("PartCode") == _partcode
                             from _loc in _l.DefaultIfEmpty(_locations.NewRow())
                             group _ledger by new
                             {
                                 Location = _loc.Field<string>("Location")
                             } into _group
                             select new
                             {
                                 Location = _group.Key.Location,
                                 Quantity = _group.Sum(_ledger => (_ledger.Field<int>("In") - _ledger.Field<int>("Out")))
                             };

                DataTable _datasource = new DataTable();
                _datasource.TableName = "stockledger";
                DataColumn _pk = _datasource.Columns.Add("Location", typeof(string));
                _datasource.Columns.Add("Quantity", typeof(int));
                _datasource.Columns.Add("Remarks", typeof(string));
                _datasource.Constraints.Add("PK", _pk, true);

                try
                {
                    foreach (var _row in _query) _datasource.Rows.Add(new object[] {
                                                                      _row.Location, _row.Quantity, "" });

                    _datasource.AcceptChanges();
                }
                catch { }

                grdLocations.ClearRowsAndColumns();
                grdLocations.DataSource = _datasource;
                ColumnCollection _cols = grdLocations.Cols;

                _cols["Remarks"].Caption = "";
                grdLocations.AutoSizeCols(); grdLocations.ExtendLastCol = true;

                for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
                {
                    if (_cols[i].Width < 80) _cols[i].Width = 80;
                }

                _cols[_cols.Fixed - 1].Visible = false;

                while (!grdLocations.Redraw) grdLocations.EndUpdate();
            }
        }

        private void InitializeModels()
        {
            object _selectedvalue = cboModel.SelectedValue;
            string _selectedbrand = "";

            if (!Materia.IsNullOrNothing(cboBrand.SelectedValue)) _selectedbrand = cboBrand.SelectedValue.ToString();
            cboModel.Enabled = false;
            if (cboModel.DataSource != null)
            {
                try { ((DataTable)cboModel.DataSource).Dispose(); }
                catch { }
                finally
                {
                    cboModel.DataSource = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }

            DataTable _models = Cache.GetCachedTable("models");
            if (_models != null)
            {
                DataTable _datasource = _models.Replicate();
                 _datasource.DefaultView.RowFilter = "[Brand] LIKE '" + _selectedbrand.ToSqlValidString(true) + "'";

                cboModel.DataSource = _datasource;
                cboModel.ValueMember = "ModelCode"; cboModel.DisplayMember = "Model";

                if (!string.IsNullOrEmpty(_selectedbrand.RLTrim()) &&
                    !Materia.IsNullOrNothing(_selectedvalue))
                {
                    DataRow[] _rows = _datasource.Select("[Brand] LIKE '" + _selectedbrand.ToSqlValidString(true) + "' AND [ModelCode] LIKE '" + _selectedvalue.ToString().ToSqlValidString(true) + "'");
                    if (_rows.Length > 0)
                    {
                        try { cboModel.SelectedValue = _selectedvalue; }
                        catch { }
                    }
                    else
                    {
                        try { cboModel.SelectedIndex = -1; }
                        catch { }
                    }
                }
                else
                {
                    if (Materia.IsNullOrNothing(_selectedvalue))
                    {
                        try { cboModel.SelectedIndex = -1; }
                        catch { }
                    }
                    else
                    {
                        try { cboModel.SelectedValue = _selectedvalue; }
                        catch { }
                    }
                }

                cboModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboModel.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

            cboModel.Enabled = true;
        }

        private void InitializePartStatus()
        {
            string _path = Application.StartupPath + "\\Xml\\partsstatus.xml";
            DataTable _status = SCMS.XmlToTable(_path);

            if (_status != null)
            {
                cboStatus.Enabled = false;

                if (cboStatus.DataSource != null)
                {
                    try { ((DataTable)cboStatus.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboStatus.DataSource = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _status.DefaultView.Sort = "[Status]";
                cboStatus.DataSource = _status;
                cboStatus.DisplayMember = "Status"; cboStatus.ValueMember = "Id";
                cboStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboStatus.SelectedValue = 1; }
                catch { }

                cboStatus.Enabled = true;
            }
        }

        private void InitializeSearches()
        {
            DataTable _table = Cache.GetCachedTable("parts");
            var _query = from _tbl in _table.AsEnumerable()
                         where _tbl.Field<string>("Company") == SCMS.CurrentCompany.Company
                         select new 
                         { 
                             PartNo = _tbl.Field<string>("PartNo"),  
                             PartName = _tbl.Field<string>("PartName"),
                             Description = _tbl.Field<string>("Description")
                         };

            if (txtSearch.AutoCompleteCustomSource == null) txtSearch.AutoCompleteCustomSource = new AutoCompleteStringCollection();

            try
            {
                foreach (var _row in _query)
                {
                    if (!Materia.IsNullOrNothing(_row.PartNo))
                    {
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row.PartNo)) txtSearch.AutoCompleteCustomSource.Add(_row.PartNo);
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row.PartName)) txtSearch.AutoCompleteCustomSource.Add(_row.PartName);
                        if (!txtSearch.AutoCompleteCustomSource.Contains(_row.Description)) txtSearch.AutoCompleteCustomSource.Add(_row.Description);
                    }
                }
            }
            catch { }

            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void InitializeStockLedger()
        {
            if (grdLedger.Redraw) grdLedger.BeginUpdate();

            DataTable _stockledger = Cache.GetCachedTable("stockledger");
            DataTable _suppliers = Cache.GetCachedTable("suppliers");
            DataTable _customers = Cache.GetCachedTable("customers");
            DataTable _locations = Cache.GetCachedTable("locations");
            DataTable _users = Cache.GetCachedTable("users");

            if (_stockledger != null &&
                _suppliers != null &&
                _customers != null &&
                _locations != null &&
                _users != null)
            {
                string _path = Application.StartupPath + "\\Xml\\stocktransactiontypes.xml";
                DataTable _transactiontypes = SCMS.XmlToTable(_path);

                if (_transactiontypes != null)
                {
                    var _query = from _ledger in _stockledger.AsEnumerable()
                                 join _usr in _users.AsEnumerable() on _ledger.Field<string>("Username") equals _usr.Field<string>("Username")
                                 join _trx in _transactiontypes.AsEnumerable() on _ledger.Field<int>("TransactionType") equals _trx.Field<int>("Id")
                                 join _loc in _locations.AsEnumerable() on _ledger.Field<string>("LocationCode") equals _loc.Field<string>("LocationCode") into _l
                                 join _sup in _suppliers.AsEnumerable() on _ledger.Field<string>("SupplierCode") equals _sup.Field<string>("SupplierCode") into _s
                                 join _cus in _customers.AsEnumerable() on _ledger.Field<string>("CustomerCode") equals _cus.Field<string>("CustomerCode") into _c
                                 where _ledger.Field<string>("PartCode") == _partcode
                                 from _loc in _l.DefaultIfEmpty(_locations.NewRow())
                                 from _sup in _s.DefaultIfEmpty(_suppliers.NewRow())
                                 from _cus in _c.DefaultIfEmpty(_customers.NewRow())
                                 orderby _ledger.Field<DateTime>("Dated"),
                                         _ledger.Field<int>("TransactionType"),
                                         _ledger.Field<string>("ReferenceNo")
                                 select new
                                 {
                                     DetailId = _ledger.Field<long>("DetailId"),
                                     Date = _ledger.Field<DateTime>("Dated"),
                                     ReferenceNo = _ledger.Field<string>("ReferenceNo"),
                                     TransactionType = _trx.Field<string>("TransactionType"),
                                     Supplier = _sup.Field<string>("SupplierName"),
                                     Customer = _cus.Field<string>("CustomerName"),
                                     Location = _loc.Field<string>("Location"),
                                     In = _ledger.Field<int>("In"),
                                     Out = _ledger.Field<int>("Out"),
                                     Incoming = _ledger.Field<int>("Incoming"),
                                     Outgoing = _ledger.Field<int>("Outgoing"),
                                     UnitCost = _ledger.Field<decimal>("UnitCostUSD"),
                                     TotalCost = _ledger.Field<decimal>("TotalCostUSD"),
                                     UpdatedBy = _usr.Field<string>("FirstName") + " " + _usr.Field<string>("LastName")
                                 };

                    DataTable _datasource = new DataTable();
                    _datasource.TableName = "stockledger";
                    DataColumn _pk = _datasource.Columns.Add("Id", typeof(long));
                    _datasource.Columns.Add("Date", typeof(DateTime));
                    _datasource.Columns.Add("ReferenceNo", typeof(string));
                    _datasource.Columns.Add("TransactionType", typeof(string));
                    _datasource.Columns.Add("ReferenceName", typeof(string));
                    _datasource.Columns.Add("Location", typeof(string));
                    _datasource.Columns.Add("In", typeof(int));
                    _datasource.Columns.Add("Incoming", typeof(int));
                    _datasource.Columns.Add("Outgoing", typeof(int));
                    _datasource.Columns.Add("Out", typeof(int));
                    _datasource.Columns.Add("Ending", typeof(int));
                    _datasource.Columns.Add("UnitCost", typeof(decimal));
                    _datasource.Columns.Add("TotalCost", typeof(decimal));
                    _datasource.Columns.Add("EndingCost", typeof(decimal));
                    _datasource.Columns.Add("UpdatedBy", typeof(string));

                    _datasource.Constraints.Add("PK", _pk, true);

                    try 
                    {
                        int _ending = 0; decimal _balance = 0;

                        foreach (var _row in _query)
                        {
                            _ending += (_row.In - _row.Out + _row.Incoming - _row.Outgoing);
                            _balance += ((_row.In - _row.Out + _row.Incoming - _row.Outgoing) * _row.UnitCost);

                            _datasource.Rows.Add(new object[] {
                                                 _row.DetailId, _row.Date, _row.ReferenceNo,
                                                 _row.TransactionType, (Materia.IsNullOrNothing(_row.Supplier)? "" : _row.Supplier) + (Materia.IsNullOrNothing(_row.Customer) ? "" : _row.Customer),
                                                 _row.Location, _row.In, _row.Incoming, 
                                                 _row.Outgoing, _row.Out, _ending,
                                                 _row.UnitCost, _row.TotalCost, _balance,
                                                 _row.UpdatedBy });
                        }

                        _datasource.AcceptChanges();
                    }
                    catch { }

                    grdLedger.ClearRowsAndColumns();
                    grdLedger.DataSource = _datasource;
                    grdLedger.FormatColumns();

                    ColumnCollection _cols = grdLedger.Cols;
                    _cols["Id"].Visible = false;
                    _cols["ReferenceNo"].Caption = "Reference No.";
                    _cols["TransactionType"].Caption = "Transaction Type";
                    _cols["ReferenceName"].Caption = "Customer / Supplier";
                    _cols["UnitCost"].Caption = "Unit Cost (USD)";
                    _cols["TotalCost"].Caption = "Total Cost (USD)";
                    _cols["EndingCost"].Caption = "Balance (USD)";
                    _cols["UpdatedBy"].Caption = "Filed By";

                    grdLedger.AutoSizeCols(); grdLedger.ExtendLastCol = true;
                    _cols[_cols.Fixed - 1].Visible = false;

                    for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
                    {
                        if (_cols[i].Width < 80) _cols[i].Width = 80;
                    }

                    while (!grdLedger.Redraw) grdLedger.EndUpdate();
                }
            }
        }

        private void InitializeStockTypes()
        {
            string _path = Application.StartupPath + "\\Xml\\stocktypes.xml";
            DataTable _stocktypes = SCMS.XmlToTable(_path);

            if (_stocktypes != null)
            {
                cboType.Enabled = false;

                if (cboType.DataSource != null)
                {
                    try { ((DataTable)cboType.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboType.DataSource = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _stocktypes.DefaultView.Sort = "[StockType]";
                cboType.DataSource = _stocktypes;
                cboType.DisplayMember = "StockType"; cboType.ValueMember = "Id";
                cboType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboType.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboType.SelectedValue = 2; }
                catch { }

                cboType.Enabled = true;
            }
        }

        private void InitializeUDFs()
        {
            if (!grdMisc.Redraw) grdMisc.BeginUpdate();

            DataTable _datasource = null;

            if (grdMisc.DataSource != null)
            {
                try { _datasource = (DataTable)grdMisc.DataSource; }
                catch { }
            }

            if (_datasource == null)
            {
                _datasource = new DataTable();
                _datasource.TableName = "udf";

                DataColumn _pk = _datasource.Columns.Add("Id", typeof(int));
                _datasource.Columns.Add("Field", typeof(string));
                _datasource.Columns.Add("Value", typeof(string));

                _datasource.Constraints.Add("PK", _pk, true);
                DataColumnCollection _cols = _datasource.Columns;

                for (int i = 1; i <= 6; i++)
                {
                    object[] _values = new object[_cols.Count];
                    _values[_cols["Id"].Ordinal] = i;
                    _values[_cols["Field"].Ordinal] = "User-defined Field " + i.ToString();
                    _values[_cols["Value"].Ordinal] = "";
                    _datasource.Rows.Add(_values);
                }

                _datasource.AcceptChanges();
                grdMisc.DataSource = _datasource;
            }

            if (_datasource != null)
            {
                if (!_isnew)
                {
                    DataTable _parts = Cache.GetCachedTable("parts");
                    if (_parts != null)
                    {
                        DataRow[] _rows = _parts.Select("[PartCode] LIKE '" + _partcode.ToSqlValidString(true) + "'");
                        if (_rows.Length > 0)
                        {
                            DataRow _row = _rows[0];

                            for (int i = 0; i <= (_datasource.Rows.Count - 1); i++)
                            {
                                DataRow _currow = _datasource.Rows[i];
                                int _id = VisualBasic.CInt(_currow["Id"]);
                                if (!Materia.IsNullOrNothing(_row["UDF" + _id.ToString()]))
                                {
                                    if (!string.IsNullOrEmpty(_row["UDF" + _id.ToString()].ToString().RLTrim())) _currow["Field"] = _row["UDF" + _id.ToString()];
                                    else _currow["Field"] = "User-defined Field " + _id.ToString();
                                }
                                else _currow["Field"] = "User-defined Field " + _id.ToString();

                                _currow["Value"] = _row["UDFValue" + _id.ToString()];
                            }

                            _datasource.AcceptChanges();
                        }
                    }
                }

                grdMisc.AllowEditing = true;
                
                ColumnCollection _gridcols = grdMisc.Cols;
                RowCollection _grodrows = grdMisc.Rows;

                _gridcols["Id"].Visible = false;
                grdMisc.AutoSizeCols(); grdMisc.AutoSizeRows();
                grdMisc.ExtendLastCol = true;

                _gridcols[_gridcols.Fixed - 1].Visible = false;
                _grodrows[_grodrows.Fixed - 1].Visible = false;

                if (_gridcols["Field"].Width < 175) _gridcols["Field"].Width = 175;

                while (!grdMisc.Redraw) grdMisc.EndUpdate();
            }
        }

        /// <summary>
        /// Reloads this dialog using the specified part code.
        /// </summary>
        /// <param name="code"></param>
        public void LoadPartInformation(string code)
        {
            DataTable _parts = Cache.GetCachedTable("parts");
            DataTable _partnames = Cache.GetCachedTable("partnames");
            DataTable _ledger = Cache.GetCachedTable("stockledger");
            
            if (_parts != null &&
                _partnames != null &&
                _ledger != null)
            {
                DataRow[] _rows = _parts.Select("[PartCode] LIKE '" + code.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    _partcode = code; _isnew = false;
                    _updated = false; _isshown = false;

                    Text = Text.Replace(" *", "").Replace("*", "");

                    DataRow _row = _rows[0];

                    var _query = from _part in _parts.AsEnumerable()
                                 join _name in _partnames.AsEnumerable() on _part.Field<string>("PartName") equals _name.Field<string>("PartName")
                                 join _stockledger in _ledger.AsEnumerable() on _part.Field<string>("PartCode") equals _stockledger.Field<string>("PartCode") into _sl
                                 where _part.Field<string>("PartCode") == code
                                 from _stockledger in _sl.DefaultIfEmpty(_ledger.NewRow())
                                 group _stockledger by new
                                 {
                                     PartCode = _part.Field<string>("PartCode"),
                                     PartNo = _part.Field<string>("PartNo"),
                                     PartName = _part.Field<string>("PartName"),
                                     Description = _part.Field<string>("Description"),
                                     Brand = _part.Field<string>("Brand"),
                                     ModelCode = _part.Field<string>("ModelCode"),
                                     Unit = _part.Field<string>("Unit"),
                                     ReorderPoint = _part.Field<int>("ReorderPoint"),
                                     ReorderQty = _part.Field<int>("ReorderQty"),
                                     StockType = _part.Field<int>("StockType"),
                                     Country = _part.Field<string>("OriginatingCountry"),
                                     Active = _part.Field<Int16>("Active"),
                                     Notes = _part.Field<string>("Notes"),
                                     Category = _name.Field<string>("PartCategory")
                                 } into _group
                                 select new
                                 {
                                     PartCode = _group.Key.PartCode,
                                     PartNo = _group.Key.PartNo,
                                     PartName = _group.Key.PartName,
                                     Description = _group.Key.Description,
                                     Brand = _group.Key.Brand,
                                     ModelCode = _group.Key.ModelCode,
                                     Unit = _group.Key.Unit,
                                     ReorderPoint = _group.Key.ReorderPoint,
                                     ReorderQty = _group.Key.ReorderQty,
                                     StockType = _group.Key.StockType,
                                     Country = _group.Key.Country,
                                     Active = _group.Key.Active,
                                     Notes = _group.Key.Notes,
                                     Category = _group.Key.Category,
                                     Quantity = _group.Sum(_stockledger => (_stockledger.Field<int>("In") - _stockledger.Field<int>("Out"))),
                                     Incoming = _group.Sum(_stockledger => (_stockledger.Field<int>("Incoming"))),
                                     Outgoing = _group.Sum(_stockledger => (_stockledger.Field<int>("Outgoing"))),
                                     Ending = _group.Sum(_stockledger => (_stockledger.Field<int>("In") - _stockledger.Field<int>("Out") + _stockledger.Field<int>("Incoming") - _stockledger.Field<int>("Outgoing")))
                                 };

                    try
                    {
                        foreach (var _result in _query)
                        {
                            if (!Materia.IsNullOrNothing(_result.Category)) txtCategory.Text = _result.Category;
                            else txtCategory.Text = "";

                            if (!Materia.IsNullOrNothing(_result.Description)) txtDescription.Text = _result.Description;
                            else txtDescription.Text = "";

                            if (VisualBasic.IsNumeric(_result.Ending)) txtEnding.Text = _result.Ending.ToString();
                            else txtEnding.Text = "0";

                            if (VisualBasic.IsNumeric(_result.Incoming)) txtIncoming.Text = _result.Incoming.ToString();
                            else txtIncoming.Text = "0";

                            if (!Materia.IsNullOrNothing(_result.Notes)) txtNotes.Text = _result.Notes;
                            else txtNotes.Text = "";

                            if (VisualBasic.IsNumeric(_result.Outgoing)) txtOutgoing.Text = _result.Outgoing.ToString();
                            else txtOutgoing.Text = "0";

                            if (!Materia.IsNullOrNothing(_result.PartNo)) txtPartNo.Text = _result.PartNo;
                            else txtPartNo.Text = "";

                            if (VisualBasic.IsNumeric(_result.Quantity)) txtQty.Text = _result.Quantity.ToString();
                            else txtQty.Text = "0";

                            if (VisualBasic.IsNumeric(_result.ReorderPoint)) txtReorderPoint.Value = _result.ReorderPoint;
                            else txtReorderPoint.Value = 0;

                            if (VisualBasic.IsNumeric(_result.ReorderQty)) txtReorderQty.Value = _result.ReorderQty;
                            else txtReorderQty.Value = 0;

                            if (!Materia.IsNullOrNothing(_result.Country)) cboCountry.SelectedValue = _result.Country;
                            else cboCountry.SelectedIndex = - 1;

                            if (!Materia.IsNullOrNothing(_result.Brand)) cboBrand.SelectedValue = _result.Brand;
                            else cboBrand.SelectedIndex = -1;

                            DataTable _modeldatasource = null;

                            try { _modeldatasource = (DataTable)cboModel.DataSource; }
                            catch { }

                            if (_modeldatasource != null)
                            {
                                if (!Materia.IsNullOrNothing(_result.Brand))
                                {
                                    _modeldatasource.DefaultView.RowFilter = "[Brand] LIKE '" + _result.Brand.ToSqlValidString(true) + "'";
                                    if (!Materia.IsNullOrNothing(_result.ModelCode)) cboModel.SelectedValue = _result.ModelCode;
                                    else cboModel.SelectedIndex = -1;

                                }
                                else _modeldatasource.DefaultView.RowFilter = "";
                            }

                            if (!Materia.IsNullOrNothing(_result.PartName)) cboPartName.SelectedValue = _result.PartName;
                            else cboPartName.SelectedIndex = -1;

                            if (VisualBasic.IsNumeric(_result.Active)) cboStatus.SelectedValue = _result.Active;
                            else cboStatus.SelectedIndex = 1;

                            if (VisualBasic.IsNumeric(_result.StockType)) cboType.SelectedValue = _result.StockType;
                            else cboType.SelectedValue = 2;

                            if (!Materia.IsNullOrNothing(_result.Unit)) cboUom.SelectedValue = _result.Unit;
                            else cboUom.SelectedIndex = -1;
                        }
                    }
                    catch
                    { }

                    InitializeUDFs(); InitializeLocations(); InitializeStockLedger();

                    tbctrl.SelectedTab = tbGeneral;
                    tbAlternative.Visible = true;
                    tbLocations.Visible = true;
                    tbLedger.Visible = true;

                    lblAdjustment.Show(); lblAdjustment.Enabled = true;
                    lblViewIncoming.Show(); lblViewIncoming.Enabled = true;
                    lblViewOutgoing.Show(); lblViewOutgoing.Enabled = true;

                    if (!_isshown) _isshown = true;
                }
            }
        }

        private void PartInformationDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current part information. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

                switch (_result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        btnSave_Click(btnSaveAndClose, new EventArgs());
                        e.Cancel = _updated; break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true; break;
                    default: break;
                }
            }

            _cancelled = (!e.Cancel);
        }

        private void PartInformationDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            tbctrl.SelectedTab = tbGeneral;

            grdAlternative.InitializeAppearance(); grdLedger.InitializeAppearance();
            grdLocations.InitializeAppearance(); grdMisc.InitializeAppearance();

            grdMisc.AttachMouseHoverPointer();

            cboCountry.LoadCountries(); cboBrand.LoadBrands();
            cboPartName.LoadPartNames(); cboUom.LoadMeasurements();
            InitializeSearches(); InitializeModels(); 
            InitializePartStatus(); InitializeStockTypes();

            txtCategory.ReadOnly = true;

            txtEnding.ReadOnly = true; txtEnding.Text = "0";
            txtEnding.TextAlign = HorizontalAlignment.Right;

            txtIncoming.ReadOnly = true; txtIncoming.Text = "0"; 
            txtIncoming.TextAlign = HorizontalAlignment.Right;

            txtOutgoing.ReadOnly = true; txtOutgoing.Text = "0";
            txtOutgoing.TextAlign = HorizontalAlignment.Right;

            txtQty.ReadOnly = true; txtQty.Text = "0";
            txtQty.TextAlign = HorizontalAlignment.Right;

            txtReorderPoint.MinValue = 0; txtReorderPoint.AllowEmptyState = false;
            txtReorderPoint.ShowUpDown = false; txtReorderPoint.Value = 0;

            txtReorderQty.MinValue = 0; txtReorderQty.AllowEmptyState = false;
            txtReorderQty.ShowUpDown = false; txtReorderQty.Value = 0;

            txtDescription.SetAsRequired(); txtPartNo.SetAsRequired();
            cboCountry.SetAsRequired(); cboBrand.SetAsRequired();
            cboPartName.SetAsRequired(); cboStatus.SetAsRequired();
            cboType.SetAsRequired(); cboUom.SetAsRequired();

            if (!_isnew) LoadPartInformation(_partcode);
            else ClearInformation();
        }

        private void PartInformationDialog_Shown(object sender, EventArgs e)
        { if (!_isshown) _isshown = true; }

        private void Field_Edited(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!_isshown) return;

            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.ErrorProvider.SetError((Control)sender, "");

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

        private void tbctrl_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (!_isshown) return;
            if (SCMS.Validators.Contains(this)) SCMS.Validators[this].Highlighter.UpdateHighlights();
        }

        private void cboBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!cboBrand.Enabled) return;
            if (!_isshown) return;
            if (cboBrand.DataSource == null) return;
            if (cboModel.DataSource == null) return;

            string _selectedbrand = "";
            if (!Materia.IsNullOrNothing(cboBrand.SelectedValue)) _selectedbrand = cboBrand.SelectedValue.ToString();

            DataTable _models = null;

            try { _models = (DataTable)cboModel.DataSource; }
            catch { }

            if (_models != null)
            {
                object _selectedmodel = cboModel.SelectedValue;

                cboModel.Enabled = false;
                _models.DefaultView.RowFilter = "[Brand] LIKE '" + _selectedbrand.ToSqlValidString(true) + "'";

                if (Materia.IsNullOrNothing(_selectedmodel))
                {
                    try { cboModel.SelectedIndex = -1; }
                    catch { }
                }
                else
                {
                    DataRow[] _rows = _models.Select("[Brand] LIKE '" + _selectedbrand.ToSqlValidString(true) + "' AND [ModelCode] LIKE '" + _selectedmodel.ToString().ToSqlValidString(true) + "'");

                    if (_rows.Length > 0)
                    {
                        try { cboModel.SelectedValue = _selectedmodel; }
                        catch { }
                    }
                    else
                    {
                        try { cboModel.SelectedIndex = -1; }
                        catch { }
                    }
                }

                cboModel.Enabled = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_cancelled) _cancelled = true;
            DialogResult = System.Windows.Forms.DialogResult.Cancel; Close();
        }

        private void lblAddPartName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lblAddPartName.Enabled) return;

            PartNameInfoDialog _dialog = new PartNameInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                cboPartName.LoadPartNames();

                string _partname = _dialog.PartName;

                try { cboPartName.SelectedValue = _partname; }
                catch { }

                DataTable _partnames = Cache.GetCachedTable("partnames");
                if (_partnames != null)
                {
                    DataRow[] _rows = _partnames.Select("[PartName] LIKE '" + _partname.ToSqlValidString(true) + "'");
                    if (_rows.Length > 0) txtCategory.Text = _rows[0]["PartCategory"].ToString();
                    else txtCategory.Text = "";
                }
                else txtCategory.Text = "";
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void lblAddBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lblAddBrand.Enabled) return;

            BrandInfoDialog _dialog = new BrandInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                cboBrand.LoadBrands();
                try { cboBrand.SelectedValue = _dialog.Brand; }
                catch { }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void lblAddModel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lblAddModel.Enabled) return;

            string _brand = "";
            if (cboBrand.SelectedIndex >= 0) _brand = cboBrand.SelectedValue.ToString();

            ModelInfoDialog _dialog = new ModelInfoDialog();
            _dialog.Brand = _brand; _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                InitializeModels();
                try { cboModel.SelectedValue = _dialog.ModelCode; }
                catch { }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();

        }

        private void lblAddUom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lblAddUom.Enabled) return;

            MeasurementInfoDialog _dialog = new MeasurementInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                cboUom.LoadMeasurements();
                try { cboUom.SelectedValue = _dialog.Measurement; }
                catch { }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;

            try { grdMisc.Row = (grdMisc.Rows.Fixed - 1); }
            catch { }

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtPartNo, !string.IsNullOrEmpty(txtPartNo.Text.RLTrim()), "Please specify a part number."))
            { tbctrl.SelectedTab = tbGeneral; return; }

            if (!Materia.Valid(_validator,cboPartName, cboPartName.SelectedIndex >= 0, "Please specify a valid part name."))
            { tbctrl.SelectedTab = tbGeneral; return; }

            if (!Materia.Valid(_validator, txtDescription, !string.IsNullOrEmpty(txtDescription.Text.RLTrim()), "Please specify part's description."))
            { tbctrl.SelectedTab = tbGeneral; return; }

            if (!Materia.Valid(_validator, cboBrand, cboBrand.SelectedIndex >= 0, "Please specify a valid brand."))
            { tbctrl.SelectedTab = tbGeneral; return; }

            if (!string.IsNullOrEmpty(cboModel.Text.RLTrim()))
            {
                if (!Materia.Valid(_validator, cboModel,cboModel.SelectedIndex >= 0, "Please specify a valid model."))
                { tbctrl.SelectedTab = tbGeneral; return; }
            }
            if (!Materia.Valid(_validator, cboUom, cboUom.SelectedIndex >= 0, "Please specify a valid unit of measurement."))
            { tbctrl.SelectedTab = tbGeneral; return; }

            if (!Materia.Valid(_validator, cboCountry, cboCountry.SelectedIndex >= 0, "Please specify a valid country."))
            { tbctrl.SelectedTab = tbGeneral; return; }

            if (grdMisc.DataSource != null)
            {
                for (int i = grdMisc.Rows.Fixed; i <= (grdMisc.Rows.Count - 1); i++)
                {
                    if (!Materia.IsNullOrNothing(grdMisc[i, "Value"]))
                    {
                        if (!string.IsNullOrEmpty(grdMisc[i, "Value"].ToString().RLTrim()))
                        {
                            if (Materia.IsNullOrNothing(grdMisc[i, "Field"]))
                            {
                                MsgBoxEx.Shout("Please specify a valid user-defined field name for row : " + i.ToString() + ".", "User-defined Fields");
                                return;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(grdMisc[i, "Field"].ToString().RLTrim()))
                                {
                                    MsgBoxEx.Shout("Please specify a valid user-defined field name for row : " + i.ToString() + ".", "User-defined Fields");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            DataTable _parts = Cache.GetCachedTable("parts");

            if (_parts != null)
            {
                string _query = ""; string _refno = "";
                DataColumnCollection _cols = _parts.Columns;

                if (_isnew)
                {
                    Func<string, bool, string> _delegate = new Func<string, bool, string>(SCMS.GetTableSeriesNumber);
                    IAsyncResult _result = _delegate.BeginInvoke("parts", true, null, _delegate);

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
                    _refno = "PART-" + SCMS.CurrentCompany.Company + "-" + _seriesno;

                    object[] _values = new object[_cols.Count];
                    _values[_cols["PartCode"].Ordinal] = _refno;
                    _values[_cols["PartNo"].Ordinal] = txtPartNo.Text;
                    _values[_cols["PartName"].Ordinal] = cboPartName.SelectedValue.ToString();
                    _values[_cols["Description"].Ordinal] = txtDescription.Text;
                    _values[_cols["SuperPartCode"].Ordinal] = Supersession;
                    _values[_cols["Brand"].Ordinal] = cboBrand.SelectedValue.ToString();
                    
                    if (cboModel.SelectedIndex >= 0) _values[_cols["ModelCode"].Ordinal] = cboModel.SelectedValue.ToString();
                    else _values[_cols["ModelCode"].Ordinal] = "";

                    _values[_cols["Unit"].Ordinal] = cboUom.SelectedValue.ToString();
                    _values[_cols["ReorderPoint"].Ordinal] = txtReorderPoint.Value;
                    _values[_cols["ReorderQty"].Ordinal] = txtReorderQty.Value;
                    _values[_cols["StockType"].Ordinal] = cboType.SelectedValue;
                    _values[_cols["OriginatingCountry"].Ordinal] = cboCountry.SelectedValue.ToString();
                    _values[_cols["Active"].Ordinal] = cboStatus.SelectedValue;

                    if (grdMisc.DataSource != null)
                    {
                        DataTable _misc = null;

                        try { _misc = (DataTable)grdMisc.DataSource; }
                        catch { }

                        if (_misc != null)
                        {
                            for (int i = 1; i <= 6; i++)
                            {
                                DataRow[] _rows = _misc.Select("[Id] = " + i.ToString());
                                if (_rows.Length >= 0)
                                {
                                    DataRow _row = _rows[0];
                                    _values[_cols["UDF" + i.ToString()].Ordinal] = _row["Field"];
                                    _values[_cols["UDFValue" + i.ToString()].Ordinal] = _row["Value"];
                                }
                            }
                        }
                    }

                    _values[_cols["Notes"].Ordinal] = txtNotes.Text;
                    _values[_cols["Company"].Ordinal] = SCMS.CurrentCompany.Company;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _parts.Rows.Add(_values);
                }
                else
                {
                    DataRow[] _existing = _parts.Select("[PartCode] LIKE '" + _partcode.ToSqlValidString(true) + "'");

                    if (_existing.Length > 0)
                    {
                        _existing[0]["PartNo"] = txtPartNo.Text;
                        _existing[0]["PartName"] = cboPartName.SelectedValue.ToString();
                        _existing[0]["Description"] = txtDescription.Text;
                        _existing[0]["SuperPartCode"] = Supersession;
                        _existing[0]["Brand"] = cboBrand.SelectedValue.ToString();

                        if (cboModel.SelectedIndex >= 0) _existing[0]["ModelCode"] = cboModel.SelectedValue.ToString();
                        else _existing[0]["ModelCode"] = "";

                        _existing[0]["Unit"] = cboUom.SelectedValue.ToString();
                        _existing[0]["ReorderPoint"] = txtReorderPoint.Value;
                        _existing[0]["ReorderQty"] = txtReorderQty.Value;
                        _existing[0]["StockType"] = cboType.SelectedValue;
                        _existing[0]["OriginatingCountry"] = cboCountry.SelectedValue.ToString();
                        _existing[0]["Active"] = cboStatus.SelectedValue;

                        if (grdMisc.DataSource != null)
                        {
                            DataTable _misc = null;

                            try { _misc = (DataTable)grdMisc.DataSource; }
                            catch { }

                            if (_misc != null)
                            {
                                for (int i = 1; i <= 6; i++)
                                {
                                    DataRow[] _rows = _misc.Select("[Id] = " + i.ToString());
                                    if (_rows.Length >= 0)
                                    {
                                        DataRow _row = _rows[0];
                                        _existing[0]["UDF" + i.ToString()] = _row["Field"];
                                        _existing[0]["UDFValue" + i.ToString()] = _row["Value"];
                                    }
                                }
                            }
                        }

                        _existing[0]["Notes"] = txtNotes.Text;
                    }
                }

                QueryGenerator _generator = new QueryGenerator(_parts);
                _generator.ExcludedFields.Add("LastModified");
                _query = _generator.ToString();
                _generator = null; Materia.RefreshAndManageCurrentProcess();

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;

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

                            string _log = "Added a new part : " + txtPartNo.Text + " - " + cboPartName.SelectedValue.ToString() + " (" + txtDescription.Text + ").";
                            if (!_isnew) _log = "Updated part : " + txtPartNo.Text + " - " + cboPartName.SelectedValue.ToString() + " (" + txtDescription.Text + ").";

                            _parts.AcceptChanges();
                            if (_isnew)
                            {
                                if (!txtSearch.AutoCompleteCustomSource.Contains(txtPartNo.Text)) txtSearch.AutoCompleteCustomSource.Add(txtPartNo.Text);
                                if (!txtSearch.AutoCompleteCustomSource.Contains(cboPartName.SelectedValue.ToString())) txtSearch.AutoCompleteCustomSource.Add(cboPartName.SelectedValue.ToString());
                                if (!txtSearch.AutoCompleteCustomSource.Contains(txtDescription.Text)) txtSearch.AutoCompleteCustomSource.Add(txtDescription.Text);

                                _partcode = _refno;
                                _isnew = false;

                                tbAlternative.Visible = true;
                                tbLocations.Visible = true;
                                tbLedger.Visible = true;

                                lblAdjustment.Show(); lblAdjustment.Enabled = true;
                                lblViewIncoming.Show(); lblViewIncoming.Enabled = true;
                                lblViewOutgoing.Show(); lblViewOutgoing.Enabled = true;
                            }
                            if (_updated) _updated = false;
                            if (!_withupdates) _withupdates = true;
                            Text = Text.Replace(" *", "").Replace("*", "");
                            Cursor = Cursors.WaitCursor;

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _log, _partcode);
                            _logresult.WaitToFinish();

                            Cursor = Cursors.Default;

                            if (sender == btnSaveAndClose)
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                        }
                        else
                        {
                            if (_queresult.Error.Contains("duplicate")) btnSave_Click(sender, new EventArgs());
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current part information.", "Save Part");
                            }

                            _parts.RejectChanges();
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

        private void cboPartName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_isshown) return;
            if (cboPartName.DataSource == null) return;
            if (!cboPartName.Enabled) return;
            if (cboPartName.SelectedIndex < 0)
            { txtCategory.Text = ""; return; }
            else
            {
                string _partname = cboPartName.SelectedValue.ToString();
                DataTable _partnames = Cache.GetCachedTable("partnames");
                if (_partnames != null)
                {
                    DataRow[] _rows = _partnames.Select("[PartName] LIKE '" + _partname.ToSqlValidString(true) + "'");
                    if (_rows.Length > 0) txtCategory.Text = _rows[0]["PartCategory"].ToString();
                    else txtCategory.Text = "";
                }
                else txtCategory.Text = "";
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (btnSaveAndClose.Enabled) btnSave_Click(btnSaveAndClose, new EventArgs());
        }

    }
}
