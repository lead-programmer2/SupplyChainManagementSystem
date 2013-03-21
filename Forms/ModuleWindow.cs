using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class ModuleWindow : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of ModuleWindow. 
        /// </summary>
        public ModuleWindow(Module module)
        {
            InitializeComponent();

            _selectedmodule = module;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Module _selectedmodule = Module.None;

        /// <summary>
        /// Gets the application's module that this window represents.
        /// </summary>
        public Module SelectedModule
        {
            get { return _selectedmodule; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SubModule _selectedsubmodule = SubModule.None;

        /// <summary>
        /// Gets the current selected and displayed application sub module.
        /// </summary>
        public SubModule SelectedSubModule
        {
            get { return _selectedsubmodule; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _nodesloading = false;

        private void DisableButtons()
        {
            foreach (BaseItem item in _toolbar.Items) item.Enabled = false;
            txtSearch.Enabled = false; txtSearch.Text = "";
        }

        private void EnableButtons()
        {
            bool _refresh = true; bool _search = true; bool _add = true;
            bool _edit = false; bool _delete = false; bool _preview = false;
            bool _print = false; bool _exportexcel = false; bool _export = false;
            bool _import = true;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdRecords.DataSource; }
            catch { }

            if (_datasource != null)
            {
                DataTable _viewtable = _datasource.DefaultView.ToTable();

                _edit = (_viewtable.Rows.Count > 0);
                _delete = (_viewtable.Rows.Count > 0);
                _preview = (_viewtable.Rows.Count > 0);
                _print = (_viewtable.Rows.Count > 0);
                _exportexcel = (_viewtable.Rows.Count > 0);
                _export = (_viewtable.Rows.Count > 0);

                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }

            btnRefresh.Enabled = _refresh; txtSearch.Enabled = _search;
            btnNew.Enabled = _add; btnEdit.Enabled = _edit;
            btnDelete.Enabled = _delete; btnExportExcel.Enabled = _exportexcel;
            btnExport.Enabled = _export; btnImport.Enabled = _import;
            btnPrintPreview.Enabled = _preview; btnPrint.Enabled = _print;
        }

        private void FormatGrid()
        {
            if (grdRecords.DataSource == null) return;
            ColumnCollection _cols = grdRecords.Cols;
            grdRecords.FormatColumns();

            switch (_selectedsubmodule)
            {
                case SubModule.BankAccounts:
                    _cols["BankAccountCode"].Visible = false;
                    _cols["BankAccountNo"].Caption = "Bank Account No.";
                    _cols["BankAccountName"].Caption = "Bank Account Name";
                    _cols["AccountCode"].Caption = "Account Code";
                    _cols["AccountName"].Caption = "Account Name";
                    _cols["Current"].Caption = "Current Balance";
                    _cols["Outstanding"].Caption = "Outstanding Balance";
                    _cols["Ending"].Caption = "Ending Balance";
                    break;
                case SubModule.Customers:
                    _cols["CustomerCode"].Visible = false;
                    _cols["CustomerNo"].Caption = "Customer No.";
                    _cols["CustomerName"].Caption = "Customer";
                    _cols["CustomerGroup"].Caption = "Group";
                    _cols["Active"].DataType = typeof(bool);
                    _cols["Balance"].Caption = "Balance (USD)";
                    _cols["ContactPerson"].Caption = "Contact Person";
                    break;
                case SubModule.PartsInventory:
                    _cols["PartCode"].Visible = false;
                    _cols["PartNo"].Caption = "Part No.";
                    _cols["PartName"].Caption = "Part Name";
                    _cols["UnitCost"].Caption = "Unit Cost (USD)";
                    _cols["ReorderPoint"].Caption = "Reorder Point";
                    _cols["ReorderQty"].Caption = "Reorder Qty";
                    _cols["LastPurchased"].Caption = "Last Purchased";
                    break;
                default: break;
            }
        }

        private DataTable GetBankAccounts()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "bankaccounts");
            Cache.SyncTable(SCMS.Connection, "banks");
            Cache.SyncTable(SCMS.Connection, "bankledger");
            Cache.SyncTable(SCMS.Connection, "accounts");
            Cache.SyncTable(SCMS.Connection, "currencies");

            DataTable _bankaccounts = Cache.GetCachedTable("bankaccounts");
            DataTable _bankledger = Cache.GetCachedTable("bankledger");
            DataTable _accounts = Cache.GetCachedTable("accounts");

            if (_bankaccounts != null &&
                _bankledger != null &&
                _accounts != null)
            {
                var _query = from _bankaccount in _bankaccounts.AsEnumerable()
                             join _account in _accounts.AsEnumerable() on _bankaccount.Field<long>("AccountCode") equals _account.Field<long>("AccountCode")
                             join _ledger in _bankledger.AsEnumerable() on _bankaccount.Field<string>("BankAccountCode") equals _ledger.Field<string>("BankAccountCode") into _bl
                             where _bankaccount.Field<string>("Company") == SCMS.CurrentCompany.Company
                             from _ledger in _bl.DefaultIfEmpty(_bankledger.NewRow())
                             group _ledger by new
                             {
                                 BankAccountCode = _bankaccount.Field<string>("BankAccountCode"),
                                 BankAccountNo = _bankaccount.Field<string>("AccountNo"),
                                 BankAccountName = _bankaccount.Field<string>("AccountName"),
                                 Currency = _bankaccount.Field<string>("Currency"),
                                 AccountCode = _bankaccount.Field<long>("AccountCode"),
                                 AccountName = _account.Field<string>("AccountName"),
                                 Bank = _bankaccount.Field<string>("Bank"),
                                 Notes = _bankaccount.Field<string>("Notes")
                             } into _group
                             select new
                             {
                                 BankAccountCode = _group.Key.BankAccountCode,
                                 BankAccountNo = _group.Key.BankAccountNo,
                                 BankAccountName = _group.Key.BankAccountName,
                                 Bank = _group.Key.Bank,
                                 Currency = _group.Key.Currency,
                                 AccountCode = _group.Key.AccountCode,
                                 AccountName = _group.Key.AccountName,
                                 CurrentBalance = _group.Sum(_ledger => (_ledger.Field<decimal>("In") - _ledger.Field<decimal>("Out"))),
                                 OutstandingBalance = _group.Sum(_ledger => (_ledger.Field<decimal>("Incoming") - _ledger.Field<decimal>("Outgoing"))),
                                 EndingBalance = _group.Sum(_ledger => (_ledger.Field<decimal>("In") - _ledger.Field<decimal>("Out") + _ledger.Field<decimal>("Incoming") - _ledger.Field<decimal>("Outgoing"))),
                                 Notes = _group.Key.Notes
                             };

                _datasource = new DataTable();
                _datasource.TableName = "bankaccounts";

                DataColumnCollection _cols = _datasource.Columns;
                DataColumn _pk = _cols.Add("BankAccountCode", typeof(string));
                _cols.Add("BankAccountNo", typeof(string));
                _cols.Add("BankAccountName", typeof(string));
                _cols.Add("Bank", typeof(string));
                _cols.Add("Currency", typeof(string));
                _cols.Add("AccountCode", typeof(long));
                _cols.Add("AccountName", typeof(string));
                _cols.Add("Current", typeof(decimal));
                _cols.Add("Outstanding", typeof(decimal));
                _cols.Add("Ending", typeof(decimal));
                _cols.Add("Notes", typeof(string));

                _datasource.Constraints.Add("PK", _pk, true);


                try
                {
                    foreach (var _row in _query) _datasource.Rows.Add(new object[] {
                                                                      _row.BankAccountCode, _row.BankAccountNo, _row.BankAccountName,
                                                                      _row.Bank, _row.Currency, _row.AccountCode,
                                                                      _row.AccountName, _row.CurrentBalance, _row.OutstandingBalance,
                                                                      _row.EndingBalance, _row.Notes });

                    _datasource.AcceptChanges();
                }
                catch { }
            }

            return _datasource;
        }

        private DataTable GetCustomers()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "customers");
            Cache.SyncTable(SCMS.Connection, "customergroups");
            Cache.SyncTable(SCMS.Connection, "locations");
            Cache.SyncTable(SCMS.Connection, "bankaccounts");
            Cache.SyncTable(SCMS.Connection, "accounts");
            Cache.SyncTable(SCMS.Connection, "receivableledger");

            DataTable _customers = Cache.GetCachedTable("customers");
            DataTable _arledger = Cache.GetCachedTable("receivableledger");

            if (_customers != null &&
                _arledger != null)
            {
                var _query = from _cus in _customers.AsEnumerable()
                             join _ledger in _arledger.AsEnumerable() on _cus.Field<string>("CustomerCode") equals _ledger.Field<string>("CustomerCode") into _cl
                             where _cus.Field<string>("Company") == SCMS.CurrentCompany.Company
                             from _ledger in _cl.DefaultIfEmpty(_arledger.NewRow())
                             group _ledger by new
                             {
                                 CustomerCode = _cus.Field<string>("CustomerCode"),
                                 CustomerNo = _cus.Field<string>("CustomerNo"),
                                 CustomerName = _cus.Field<string>("CustomerName"),
                                 CustomerGroup = _cus.Field<string>("CustomerGroup"),
                                 Active = _cus.Field<Int16>("Active"),
                                 Address = _cus.Field<string>("Address") + ", " + _cus.Field<string>("Country"),
                                 Phone = _cus.Field<string>("Phone"),
                                 Mobile = _cus.Field<string>("Mobile"),
                                 Fax = _cus.Field<string>("Fax"),
                                 Email = _cus.Field<string>("Email"),
                                 ContactPerson = _cus.Field<string>("POC"),
                                 Notes = _cus.Field<string>("Notes")
                             } into _group
                             orderby _group.Key.CustomerNo
                             select new
                             {
                                 CustomerCode = _group.Key.CustomerCode,
                                 CustomerNo = _group.Key.CustomerNo,
                                 CustomerName = _group.Key.CustomerName,
                                 CustomerGroup = _group.Key.CustomerGroup,
                                 Active = _group.Key.Active,
                                 Address = _group.Key.Address,
                                 Phone = _group.Key.Phone,
                                 Mobile = _group.Key.Mobile,
                                 Fax = _group.Key.Fax,
                                 Email = _group.Key.Email,
                                 ContactPerson = _group.Key.ContactPerson,
                                 OutstandingBalance = _group.Sum(_ledger => (_ledger.Field<decimal>("Receivable") - _ledger.Field<decimal>("Credited") - _ledger.Field<decimal>("Paid") - _ledger.Field<decimal>("Prepayment"))),
                                 Notes = _group.Key.Notes
                             };

                _datasource = new DataTable();
                _datasource.TableName = "customers";

                DataColumnCollection _cols = _datasource.Columns;
                DataColumn _pk = _cols.Add("CustomerCode", typeof(string));
                _cols.Add("CustomerNo", typeof(string));
                _cols.Add("CustomerName", typeof(string));
                _cols.Add("CustomerGroup", typeof(string));
                _cols.Add("Active", typeof(Int16));
                _cols.Add("Address", typeof(string));
                _cols.Add("Phone", typeof(string));
                _cols.Add("Mobile", typeof(string));
                _cols.Add("Fax", typeof(string));
                _cols.Add("Email", typeof(string));
                _cols.Add("ContactPerson", typeof(string));
                _cols.Add("Balance", typeof(decimal));
                _cols.Add("Notes", typeof(string));

                _datasource.Constraints.Add("PK", _pk, true);

                try
                {
                    foreach (var _row in _query) _datasource.Rows.Add(new object[] {
                                                                      _row.CustomerCode, _row.CustomerNo, _row.CustomerName,
                                                                      _row.CustomerGroup, _row.Active, _row.Address,
                                                                      _row.Phone, _row.Mobile, _row.Fax,
                                                                      _row.Email, _row.ContactPerson, _row.OutstandingBalance,
                                                                      _row.Notes });

                    _datasource.AcceptChanges();
                }
                catch { }
            }

            return _datasource;
        }

        private string GetModuleName()
        {
            string _modulename = "";
            string _path = Application.StartupPath + "\\Xml\\modules.xml";
            DataTable _modules = SCMS.XmlToTable(_path);

            if (_modules != null)
            {
                DataRow[] _rows = _modules.Select("[Id] = " + VisualBasic.CInt(_selectedmodule).ToString());
                if (_rows.Length > 0) _modulename = _rows[0]["Text"].ToString();
                _modules.Dispose(); _modules = null;
                Materia.RefreshAndManageCurrentProcess();
            }

            return _modulename;
        }
       
        private DataTable GetPartInventory()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "parts");
            Cache.SyncTable(SCMS.Connection, "partnames");
            Cache.SyncTable(SCMS.Connection, "partcategories");
            Cache.SyncTable(SCMS.Connection, "brands");
            Cache.SyncTable(SCMS.Connection, "models");
            Cache.SyncTable(SCMS.Connection, "measurements");
            Cache.SyncTable(SCMS.Connection, "stockledger");
            Cache.SyncTable(SCMS.Connection, "customers");
            Cache.SyncTable(SCMS.Connection, "suppliers");
            Cache.SyncTable(SCMS.Connection, "locations");
            Cache.SyncTable(SCMS.Connection, "users");

            DataTable _parts = Cache.GetCachedTable("parts");
            DataTable _partnames = Cache.GetCachedTable("partnames");
            DataTable _partcategories = Cache.GetCachedTable("partcategories");
            DataTable _brands = Cache.GetCachedTable("brands");
            DataTable _models = Cache.GetCachedTable("models");
            DataTable _measurements = Cache.GetCachedTable("measurements");
            DataTable _ledger = Cache.GetCachedTable("stockledger");

            if (_parts != null &&
                _partnames != null &&
                _partcategories != null &&
                _brands != null &&
                _models != null &&
                _measurements != null &&
                _ledger != null)
            {
                string _path = Application.StartupPath + "\\Xml\\stocktypes.xml";
                DataTable _stocktypes = SCMS.XmlToTable(_path);

                if (_stocktypes != null)
                {
                    var _query = from _part in _parts.AsEnumerable()
                                 join _uom in _measurements.AsEnumerable() on _part.Field<string>("Unit") equals _uom.Field<string>("Unit")
                                 join _name in _partnames.AsEnumerable() on _part.Field<string>("PartName") equals _name.Field<string>("PartName")
                                 join _brand in _brands.AsEnumerable() on _part.Field<string>("Brand") equals _brand.Field<string>("Brand")
                                 join _type in _stocktypes.AsEnumerable() on _part.Field<int>("StockType") equals _type.Field<int>("Id")
                                 join _model in _models.AsEnumerable() on _part.Field<string>("ModelCode") equals _model.Field<string>("ModelCode") into _pm 
                                 join _stockledger in _ledger.AsEnumerable() on _part.Field<string>("PartCode") equals _stockledger.Field<string>("PartCode") into _sl
                                 where _part.Field<string>("Company") == SCMS.CurrentCompany.Company
                                 from _model in _pm.DefaultIfEmpty(_models.NewRow())
                                 from _stockledger in _sl.DefaultIfEmpty(_ledger.NewRow())
                                 group _stockledger by new
                                 {
                                     PartCode = _part.Field<string>("PartCode"),
                                     PartNo = _part.Field<string>("PartNo"),
                                     PartName = _part.Field<string>("PartName"),
                                     Description = _part.Field<string>("Description"),
                                     Brand = _part.Field<string>("Brand"),
                                     Model = _model.Field<string>("Model"),
                                     Category = _name.Field<string>("PartCategory"),
                                     Unit = _part.Field<string>("Unit"),
                                     ReorderPoint = _part.Field<int>("ReorderPoint"),
                                     ReorderQty = _part.Field<int>("ReorderQty"),
                                     Type = _type.Field<string>("StockType"),
                                     Status = (_part.Field<Int16>("Active") == 1 ? "Active" : "Inactive")
                                 } into _group
                                 select new
                                 {
                                     PartCode = _group.Key.PartCode,
                                     PartNo = _group.Key.PartNo,
                                     PartName = _group.Key.PartName,
                                     Description = _group.Key.Description,
                                     Brand = _group.Key.Brand,
                                     Model = _group.Key.Model,
                                     Category = _group.Key.Category,
                                     Unit = _group.Key.Unit,
                                     Quantity = _group.Sum(_stockledger => (_stockledger.Field<int>("In") - _stockledger.Field<int>("Out"))),
                                     Incoming = _group.Sum(_stockledger => _stockledger.Field<int>("Incoming")),
                                     Outgoing = _group.Sum(_stockledger => _stockledger.Field<int>("Outgoing")),
                                     Balance = _group.Sum(_stockledger => (_stockledger.Field<int>("In") - _stockledger.Field<int>("Out") + _stockledger.Field<int>("Incoming") - _stockledger.Field<int>("Outgoing"))),
                                     ReorderPoint = _group.Key.ReorderPoint,
                                     ReorderQty = _group.Key.ReorderQty,
                                     Type = _group.Key.Type,
                                     Status = _group.Key.Status,
                                     LastPurchased = _group.Max(_stockledger => _stockledger.Field<DateTime>("PurchaseDate")),
                                     UnitCost = _group.Sum(_stockledger => ((_stockledger.Field<int>("In") > 0 || _stockledger.Field<int>("Incoming") > 0 ? 1 : -1) * _stockledger.Field<decimal>("TotalCostUSD")))
                                 };  

                    _datasource = new DataTable();
                    _datasource.TableName = "parts";
                    DataColumn _dpk = _datasource.Columns.Add("PartCode", typeof(string));
                    _datasource.Columns.Add("PartNo", typeof(string));
                    _datasource.Columns.Add("PartName", typeof(string));
                    _datasource.Columns.Add("Description", typeof(string));
                    _datasource.Columns.Add("Brand", typeof(string));
                    _datasource.Columns.Add("Model", typeof(string));
                    _datasource.Columns.Add("Category", typeof(string));
                    _datasource.Columns.Add("Unit", typeof(string));
                    _datasource.Columns.Add("Quantity", typeof(int));
                    _datasource.Columns.Add("Incoming", typeof(int));
                    _datasource.Columns.Add("Outgoing", typeof(int));
                    _datasource.Columns.Add("Balance", typeof(int));
                    _datasource.Columns.Add("UnitCost", typeof(decimal));
                    _datasource.Columns.Add("ReorderPoint", typeof(int));
                    _datasource.Columns.Add("ReorderQty", typeof(int));
                    _datasource.Columns.Add("Type", typeof(string));
                    _datasource.Columns.Add("Status", typeof(string));
                    DataColumn _lastpurchasecol = _datasource.Columns.Add("LastPurchased", typeof(DateTime));
                    _lastpurchasecol.AllowDBNull = true;

                    _datasource.Constraints.Add("PK", _dpk, true);

                    try
                    {
                        foreach (var _row in _query)
                        {
                            decimal _unitcost = 0;
                            if (_row.Balance > 0 &&
                                _row.UnitCost > 0) _unitcost = _row.UnitCost / _row.Balance;

                            object _lastpurchased = _row.LastPurchased;
                            if (VisualBasic.IsDate(_lastpurchased))
                            {
                                if (VisualBasic.CDate(_lastpurchased) == VisualBasic.CDate("1/1/1900")) _lastpurchased = DBNull.Value;
                            }

                            _datasource.Rows.Add(new object[] {
                                                 _row.PartCode, _row.PartNo, _row.PartName,
                                                 _row.Description, _row.Brand, _row.Model,
                                                 _row.Category, _row.Unit, _row.Quantity,
                                                 _row.Incoming, _row.Outgoing, _row.Balance,
                                                 _unitcost, _row.ReorderPoint, _row.ReorderQty, 
                                                 _row.Type, _row.Status, _lastpurchased });
                        }

                    }
                    catch { }
               
                    _datasource.AcceptChanges();
                }
            }

            _datasource.DefaultView.Sort = "[PartNo]";
            return _datasource;
        }

        private void InitializeDataSource()
        {            
            if (grdRecords.Redraw) grdRecords.BeginUpdate();
            DisableButtons(); trvwModules.Enabled = false;

            Func<DataTable> _delegate = null;

            switch (_selectedsubmodule)
            {
                case SubModule.BankAccounts:
                    _delegate = new Func<DataTable>(GetBankAccounts); break;
                case SubModule.Customers:
                    _delegate = new Func<DataTable>(GetCustomers); break;
                case SubModule.PartsInventory:
                    _delegate = new Func<DataTable>(GetPartInventory); break;
                default: break;
            }

            if (_delegate != null)
            {

                InitializerDialog _dialog = null;

                DataTable _datasource = null;
                if (grdRecords.DataSource != null)
                {
                    try { _datasource = (DataTable)grdRecords.DataSource; }
                    catch { }
                }

                grdRecords.Cursor = Cursors.WaitCursor;

                if (_datasource == null)
                {
                    _dialog = new InitializerDialog();
                    _dialog.Message = "Loading... Please wait...";
                    _dialog.Show();
                }
               
                IAsyncResult _result = _delegate.BeginInvoke(null, _delegate);

                while (!_result.IsCompleted &&
                       !_cancelled)
                { Thread.Sleep(1); Application.DoEvents(); }

                if (_cancelled)
                {
                    if (_dialog != null)
                    { _dialog.Close(); _dialog.Dispose(); _dialog = null; }

                    if (!_result.IsCompleted)
                    {
                        try { _result = null; }
                        catch { }
                    }

                    Materia.RefreshAndManageCurrentProcess(); return;
                }
                else
                {
                    DataTable _updates = _delegate.EndInvoke(_result);
                
                    if (_datasource != null)
                    {
                        try { _datasource.Merge(_updates, false); }
                        catch { }
                    }
                    else grdRecords.DataSource = _updates;
                    
                    FormatGrid(); ResizeGrid();
                    EnableButtons();

                    if (_dialog != null)
                    { _dialog.Close(); _dialog.Dispose(); _dialog = null; }
                    Materia.RefreshAndManageCurrentProcess();
                    trvwModules.Enabled = true;

                    if (grdRecords.DataSource != null)
                    {
                        while (!grdRecords.Redraw) grdRecords.EndUpdate();
                    }

                    grdRecords.Cursor = Cursors.Default;
                }
            }
        }

        private void InitializeModuleNodes()
        {
            if (!_nodesloading) _nodesloading = true;

            trvwModules.BeginUpdate(); trvwModules.Nodes.Clear();
            trvwModules.ImageList = _images16; trvwModules.DragDropEnabled = false;

            DevComponents.AdvTree.Node _scmsnode = new DevComponents.AdvTree.Node();
            _scmsnode.Name = "SCMS"; _scmsnode.Text = "Supply Chain Management System";
            _scmsnode.Selectable = true; _scmsnode.Enabled = true;
            _scmsnode.ImageKey = "SCMS"; _scmsnode.Editable = false;

            trvwModules.Nodes.Add(_scmsnode);

            string _path = Application.StartupPath + "\\Xml\\nodes.xml";
            DataTable _nodes = SCMS.XmlToTable(_path);

            if (_nodes != null)
            {
                var _query = from _n in _nodes.AsEnumerable()
                             where _n.Field<int>("Module") == VisualBasic.CInt(_selectedmodule)
                             select _n;

                DataTable _modulenodes = null;

                try { _modulenodes =  _query.CopyToDataTable(); }
                catch { }

                if (_modulenodes != null)
                {
                    _modulenodes.TableName = "nodes";
                    _modulenodes.DefaultView.Sort = "[Ordering]";
                    DataTable _viewtable = _modulenodes.DefaultView.ToTable();

                    if (_viewtable.Rows.Count > 0)
                    {
                        for (int i = 0; i <= (_viewtable.Rows.Count - 1); i++)
                        {
                            DataRow _row = _viewtable.Rows[i];
                            DevComponents.AdvTree.Node[] _parentnodes = trvwModules.Nodes.Find(_row["ParentKey"].ToString(), true);
                            if (_parentnodes.Length > 0)
                            {
                                DevComponents.AdvTree.Node _parentnode = _parentnodes[0];
                                DevComponents.AdvTree.Node _childnode = new DevComponents.AdvTree.Node();
                                _childnode.Name = _row["NodeKey"].ToString(); _childnode.Text = _row["Text"].ToString();
                                _childnode.ImageKey = _row["NodeKey"].ToString();
                                _childnode.Editable = false; _childnode.Enabled = true;
                                _childnode.Selectable = true; _childnode.Tag = _row["SubModuleEnum"];

                                _parentnode.Nodes.Add(_childnode);
                            }
                        }
                    }

                    _viewtable.Dispose(); _viewtable = null;
                    _modulenodes.Dispose(); _modulenodes = null;
                    _nodes.Dispose(); _nodes = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }

            trvwModules.ExpandAll(); trvwModules.EndUpdate();
            if (_nodesloading) _nodesloading = false;

            if (_scmsnode.Nodes.Count > 0)
            {
                DevComponents.AdvTree.Node _selectednode = _scmsnode.Nodes[0];
                trvwModules.SelectedNode = _selectednode;
            }
        }

        private void ResizeGrid()
        {
            if (grdRecords.DataSource == null) return;
            ColumnCollection _cols = grdRecords.Cols;

            grdRecords.AutoSizeCols(); grdRecords.ExtendLastCol = true;

            switch (_selectedsubmodule)
            {
                case SubModule.BankAccounts:
                case SubModule.Customers:
                case SubModule.PartsInventory:
                    for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
                    {
                        if (_cols[i].Width < 80) _cols[i].Width = 80;
                    }
                    
                    _cols[_cols.Fixed - 1].Visible = false;
                    break;
                default: break;
            }
        }

        private void ModuleWindow_FormClosing(object sender, FormClosingEventArgs e)
        { if (!_cancelled) _cancelled = true; }

        private void ModuleWindow_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this);
            grdRecords.InitializeAppearance(); grdRecords.Hide();
            grdRecords.AttachMouseHoverPointer();
            grdRecords.Styles[CellStyleEnum.EmptyArea].BackColor = Color.Transparent;
            lstvwRecords.Show(); DisableButtons();

            string _modulename = GetModuleName();
            Text = _modulename.Replace("\n", " ");
        }

        private void ModuleWindow_Shown(object sender, EventArgs e)
        {
            InitializeModuleNodes();
        }

        private void _dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Module _module = ((MainWindow)MdiParent).SelectedModule;
            if (((MainWindow)MdiParent).IsClosing) return;
            if (sender != null)
            {
                if (Materia.PropertyExists(sender, "IsInBackground"))
                {
                    bool _isinbackground = Materia.GetPropertyValue<bool>(sender, "IsInBackground");
                    if (_isinbackground) return;
                }
            }

            ((MainWindow)MdiParent).SelectModule(_module);

            if (sender != null)
            {
                if (sender is BankInformationDialog)
                {
                    if (((BankInformationDialog)sender).WithUpdates) btnRefresh_Click(btnRefresh, new EventArgs());
                }
                else if (sender is PartInformationDialog)
                {
                    if (((PartInformationDialog)sender).WithUpdates) btnRefresh_Click(btnRefresh, new EventArgs());
                }
                else { }
            }
        }

        private void trvwModules_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            if (_nodesloading) return;
            if (e.Node == null) return;
            _selectedsubmodule = SubModule.None;

            if (e.Node.Nodes.Count > 0)
            {
                DisableButtons(); grdRecords.Hide(); 
                if (lstvwRecords.Redraw) lstvwRecords.BeginUpdate();
                lstvwRecords.ImageList = _images32; lstvwRecords.Show();
                lstvwRecords.ListItems.Clear();

                for (int i = 0; i <= (e.Node.Nodes.Count - 1); i++)
                {
                    ListViewGridItem _item = new ListViewGridItem(e.Node.Nodes[i].Name, e.Node.Nodes[i].Text.Replace(" ", "\n"), e.Node.Nodes[i].Name);
                    _item.Tag = e.Node.Nodes[i].Tag;
                    lstvwRecords.ListItems.Add(_item);    
                }

                while (!lstvwRecords.Redraw) lstvwRecords.EndUpdate();
            }
            else
            {
                if (VisualBasic.IsNumeric(e.Node.Tag))
                {
                    if (VisualBasic.CInt(e.Node.Tag) > 0)
                    {
                        try { _selectedsubmodule = (SubModule)e.Node.Tag; }
                        catch { _selectedsubmodule = SubModule.None; }

                        grdRecords.Show(); lstvwRecords.Hide();
                        InitializeDataSource();
                    }
                }
            }
        }

        private void lstvwRecords_ListViewItemDoubleClick(object sender, ListViewGridSelectionEventArgs e)
        {
            if (e.ListItem != null)
            {
                DevComponents.AdvTree.Node[] _nodes = trvwModules.Nodes.Find(e.ListItem.Name, true);
                if (_nodes.Length > 0)
                {
                    DevComponents.AdvTree.Node _selectednode = _nodes[0];
                    trvwModules.SelectedNode = _selectednode;
                }
            }
        }

        private void lstvwRecords_ListViewItemEnterKeyPressed(object sender, ListViewGridSelectionEventArgs e)
        {
            if (e.ListItem != null)
            {
                DevComponents.AdvTree.Node[] _nodes = trvwModules.Nodes.Find(e.ListItem.Name, true);
                if (_nodes.Length > 0)
                {
                    DevComponents.AdvTree.Node _selectednode = _nodes[0];
                    trvwModules.SelectedNode = _selectednode;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        { if (btnRefresh.Enabled) InitializeDataSource();  }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!btnNew.Enabled) return;

            Form _dialog = null;

            foreach (Form _form in MdiParent.MdiChildren)
            {
                if (Materia.MethodExists(_form, "StayInBackground") )
                {
                    try { Materia.InvokeMethod(_form, "StayInBackground"); }
                    catch { }
                }
            }

            switch (_selectedsubmodule)
            {
                case SubModule.BankAccounts:
                    foreach (Form _form in MdiParent.MdiChildren)
                    {
                        if (_form is BankInformationDialog)
                        { _dialog = _form; break; }
                    }

                    if (_dialog == null) _dialog = new BankInformationDialog();
                    else ((BankInformationDialog)_dialog).ClearInformation();

                    break;
                case SubModule.Customers:
                    foreach (Form _form in MdiParent.MdiChildren)
                    {
                        if (_form is CustomersInformationDialog)
                        { _dialog = _form; break; }
                    }

                    if (_dialog == null) _dialog = new CustomersInformationDialog();
                    else ((CustomersInformationDialog)_dialog).ClearInformation();

                    break;
                case SubModule.PartsInventory:
                    foreach (Form _form in MdiParent.MdiChildren)
                    {
                        if (_form is PartInformationDialog)
                        {
                            if (((PartInformationDialog)_form).Superseded == null)
                            { _dialog = _form; break; }
                        }
                    }

                    if (_dialog == null) _dialog = new PartInformationDialog();
                    else ((PartInformationDialog)_dialog).ClearInformation();

                   ((PartInformationDialog)_dialog).InvokingForm = this;
                   break;
                default: break;
            }

            if (_dialog != null)
            {
                _dialog.FormClosed -= new FormClosedEventHandler(_dialog_FormClosed);
                _dialog.FormClosed += new FormClosedEventHandler(_dialog_FormClosed);
                _dialog.MdiParent = MdiParent; _dialog.WindowState = FormWindowState.Maximized;
                _dialog.MinimizeBox = false; _dialog.MaximizeBox = false;
                _dialog.ControlBox = false; _dialog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                _dialog.Dock = DockStyle.Fill; _dialog.TopMost = true;
                _dialog.Show(); _dialog.Activate();
                _dialog.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                _dialog.WindowState = FormWindowState.Normal;
                _dialog.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!btnEdit.Enabled) return;
            if (!grdRecords.Redraw) return;
            if (grdRecords.DataSource == null) return;
            if (grdRecords.RowSel < grdRecords.Rows.Fixed) return;

            Form _dialog = null; object _reference = null;

            foreach (Form _form in MdiParent.MdiChildren)
            {
                if (Materia.MethodExists(_form, "StayInBackground"))
                {
                    try { Materia.InvokeMethod(_form, "StayInBackground"); }
                    catch { }
                }
            }

            switch (_selectedsubmodule)
            {
                case SubModule.BankAccounts:
                    _reference = grdRecords[grdRecords.RowSel, "BankAccountCode"].ToString();

                    foreach (Form _form in MdiParent.MdiChildren)
                    {
                        if (_form is BankInformationDialog)
                        {
                            _dialog = _form; break;
                        }
                    }

                    if (_dialog == null) _dialog = new BankInformationDialog(_reference.ToString());
                    else ((BankInformationDialog)_dialog).LoadBankAccountInformation(_reference.ToString());

                    break;
                case SubModule.Customers:
                    _reference = grdRecords[grdRecords.RowSel, "CustomerCode"].ToString();

                    foreach (Form _form in MdiParent.MdiChildren)
                    {
                        if (_form is CustomersInformationDialog)
                        {
                            _dialog = _form; break;
                        }
                    }

                    if (_dialog == null) _dialog = new CustomersInformationDialog(_reference.ToString());
                    else ((CustomersInformationDialog)_dialog).LoadCustomerInformation(_reference.ToString());

                    break;
                case SubModule.PartsInventory:
                    _reference = grdRecords[grdRecords.RowSel, "PartCode"].ToString();

                    foreach (Form _form in MdiParent.MdiChildren)
                    {
                        if (_form is PartInformationDialog)
                        {
                            _dialog = _form; break;
                        }
                    }

                    if (_dialog == null)  _dialog = new PartInformationDialog(_reference.ToString());
                    ((PartInformationDialog)_dialog).InvokingForm = this;
                    break;
                default: break;
            }

            if (_dialog != null)
            {
                _dialog.FormClosed -= new FormClosedEventHandler(_dialog_FormClosed);
                _dialog.FormClosed += new FormClosedEventHandler(_dialog_FormClosed);
                _dialog.MdiParent = MdiParent; _dialog.WindowState = FormWindowState.Maximized;
                _dialog.MinimizeBox = false; _dialog.MaximizeBox = false;
                _dialog.ControlBox = false; _dialog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                _dialog.Dock = DockStyle.Fill; _dialog.TopMost = true;
                _dialog.Show(); _dialog.Activate();
                _dialog.Size = this.Size;
                _dialog.WindowState = FormWindowState.Normal;
                _dialog.WindowState = FormWindowState.Maximized;

                if (!Materia.IsNullOrNothing(_reference))
                {
                    if (_dialog is PartInformationDialog) ((PartInformationDialog)_dialog).LoadPartInformation(_reference.ToString());
                    else { }
                }
            }
        }

        private void grdRecords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!grdRecords.Redraw) return;
            if (grdRecords.DataSource == null) return;
            int _row = grdRecords.GetMouseOveredRow(e.X, e.Y);
            if (_row < grdRecords.Rows.Fixed) return;
            grdRecords.Row = _row; grdRecords.RowSel = _row;
            btnEdit_Click(btnEdit, new EventArgs());
        }

    }
}
