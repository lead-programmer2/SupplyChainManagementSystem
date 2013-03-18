using C1.Win.C1FlexGrid;
using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{

    /// <summary>
    /// Additional charges groups.
    /// </summary>
    public enum AdditionalChargeGroup
    {
        CustomsDuty = 3,
        DocumentAndHandling = 1,
        FreightCost = 2,
        InsuranceCost = 4
    }

    /// <summary>
    /// Bank miscellaneous types.
    /// </summary>
    public enum BankMiscType
    {
        Addition = 0,
        Deduction = 1
    }

    /// <summary>
    /// Connection setting enumerations.
    /// </summary>
    public enum ConnectionSetting
    {
        /// <summary>
        /// Database servers
        /// </summary>
        Servers = 0,
        /// <summary>
        /// Company list
        /// </summary>
        Companies = 1
    }

    /// <summary>
    /// Application modules
    /// </summary>
    public enum Module
    {
        Bank = 1,
        CashPosition = 2,
        Customers = 3,
        GeneralLedger = 4,
        JournalEntries = 5,
        Inventory = 6,
        None = 0,
        Orders = 7,
        Purchases = 8,
        Quotations = 9,
        Sales = 10,
        Shipments = 11,
        Suppliers = 12
    }

    /// <summary>
    ///Application's module groupings.
    /// </summary>
    public enum ModuleGroup
    {
        Finance = 1,
        None = 0,
        Operations = 2
    }

    /// <summary>
    /// Application's maintaned list.
    /// </summary>
    public enum PickList
    {
        AdditionalCharges = 15,
        Bank = 16,
        BankMiscellaneous = 17,
        Brands = 6,
        Currencies = 1,
        CurrencyDenominations = 2,
        CustomerGroups = 3,
        Departments = 4,
        Locations = 5,
        Measurements = 7,
        Models = 8,
        None = 0,
        PartCategories = 9,
        PartNames = 10,
        PaymentTerms = 11,
        Positions = 12,
        Signatories = 13,
        SystemUsers = 14
    }

    /// <summary>
    /// Stock transaction type enumerations.
    /// </summary>
    public enum StockTransactionType
    {
        Beginning = 0,
        CreditNote = 8,
        DebitNote = 7,
        Purchase = 1,
        PurchaseOrder = 5,
        Sales = 2,
        ShippingInvoice = 6,
        StockAdjustmentAdd = 3,
        StockAdjustmentDeduct = 4
    }

    /// <summary>
    /// Application's sub modules.
    /// </summary>
    public enum SubModule
    {
        None = 0,
        PartsInventory = 1
    }

    public static class SCMS
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static IDbConnection _connection = null;

        /// <summary>
        /// Gets or sets the database connection object used by the entire application.
        /// </summary>
        public static IDbConnection Connection
        {
            get { return _connection; }
            set 
            {
                if (_connection != null)
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        try { _connection.Close(); }
                        catch { }
                    }

                    try { _connection.Dispose(); }
                    catch { }
                    finally
                    {
                        _connection = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _connection = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static CompanyInfo _currentcompany = null;

        /// <summary>
        /// Gets the current pointed and transacted company.
        /// </summary>
        public static CompanyInfo CurrentCompany
        {
            get { return _currentcompany; }
            set { _currentcompany = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static SystemUserInfo _currentsystemuser = null;

        /// <summary>
        /// Gets or sets the currently active system user that is logged into the application.
        /// </summary>
        public static SystemUserInfo CurrentSystemUser
        {
            get { return _currentsystemuser; }
            set { _currentsystemuser = value; }
        }

        /// <summary>
        /// Gets the application's encryption and decryption key value.
        /// </summary>
        public static string EncryptionKey
        {
            get { return "X-X!V''Q"; }
        }

        /// <summary>
        /// Gets or sets the last selected company used by the current workstation.
        /// </summary>
        public static string LastSelectedCompany
        {
            get
            {
                object _value = VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "LastSelectedCompany", "CSPT-FZE");
                return _value.ToString();
            }
            set
            { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "LastSelectedCompany", value); }
        }

        /// <summary>
        /// Gets or sets the last selected database server connection name used by the current workstation.
        /// </summary>
        public static string LastSelectedConnection
        {
            get 
            {
                object _value = VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "LastSelectedConnection", "CSPT-Live");
                return _value.ToString(); 
            }
            set { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "LastSelectedConnection", value); }
        }

        /// <summary>
        /// Gets the database script file extension used and produced by the application.
        /// </summary>
        public static string ScriptFileExtension
        {
            get { return "sql4x"; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ServerConnectionInfo _serverconnection = null;

        /// <summary>
        /// Gets or sets the currently active and connected server connection information.
        /// </summary>
        public static ServerConnectionInfo ServerConnection
        {
            get { return _serverconnection; }
            set { _serverconnection = value; }
        }

        /// <summary>
        /// Attaches a handler that makes the grid interactive thru mouse hover.
        /// </summary>
        /// <param name="grid"></param>
        public static void AttachMouseHoverPointer(this C1FlexGrid grid)
        { grid.MouseMove += new MouseEventHandler(grid_MouseMove); }

        private static void ApplyNumberings(C1FlexGrid grid)
        {
            if (grid != null)
            {
                int _counter = 1;

                for (int i = grid.Rows.Fixed; i <= (grid.Rows.Count - 1); i++)
                {
                    if (grid.Rows[i].Visible)
                    {
                        grid.Rows[i][0] = _counter;
                        _counter += 1;
                    }
                }
            }
        }

        /// <summary>
        /// Applies row numberings to the specified grid.
        /// </summary>
        /// <param name="grid"></param>
        public static void AutoNumber(this C1FlexGrid grid)
        {
            if (grid != null)
            {
                ApplyNumberings(grid);
                grid.AfterAddRow += new RowColEventHandler(grid_AfterRowUpdated);
                grid.AfterDeleteRow += new RowColEventHandler(grid_AfterRowUpdated);
                grid.AfterFilter += new EventHandler(grid_AfterRowUpdated);
            }
        }

        /// <summary>
        /// Performs application resource clean-up.
        /// </summary>
        public static void CleanUp()
        {
            int _trycounter = 0;

            while (_trycounter < 30 &&
                   Directory.Exists(Application.StartupPath + "\\dbtemp"))
            {
                try { Directory.Delete(Application.StartupPath + "\\dbtemp", true); }
                catch { }
                Thread.Sleep(100); Application.DoEvents();
            }

            Materia.RefreshAndManageCurrentProcess();
        }

        public static void ClearRowsAndColumns(this C1FlexGrid grid)
        {
            if (grid != null)
            {
                if (grid.Redraw) grid.BeginUpdate();

                if (grid.DataSource != null)
                {
                    try { grid.DataSource = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }

                grid.Clear(ClearFlags.All);
                grid.Rows.Fixed = 1; grid.Rows.Count = 1;
                grid.Cols.Fixed = 1; grid.Cols.Count = 1;
                grid.ExtendLastCol = false; grid.Cols[0].Width = 0;

                while (!grid.Redraw) grid.EndUpdate();
            }
        }

        /// <summary>
        /// Creates initial currency denominations using the applications embedded default values.
        /// </summary>
        public static void CreateInitialCurrencyDenominations()
        {
            string _path = Application.StartupPath + "\\Xml\\defaultdenominations.xml";
            DataTable _defaultdenominations = XmlToTable(_path);

            if (_defaultdenominations != null)
            {
                Cache.SyncTable(SCMS.Connection, "currencies");
                Cache.SyncTable(SCMS.Connection, "currencydenominations");

                DataTable _currencies = Cache.GetCachedTable("currencies");
                DataTable _denominations = Cache.GetCachedTable("currencydenominations");

                if (_currencies != null &&
                    _denominations != null)
                {
                    _denominations.Columns["DetailId"].AutoIncrementSeed = 1;
                    for (int i = 0; i <= (_defaultdenominations.Rows.Count - 1); i++)
                    {
                        DataRow _row = _defaultdenominations.Rows[i];
                        DataRow[] _rows = _denominations.Select("[Denomination] = " + VisualBasic.CDec(_row["Denomination"]).ToString());

                        if (_rows.Length <= 0)
                        {
                            for (int c = 0; c <= (_currencies.Rows.Count - 1); c++)
                            {
                                DataRow _cur = _currencies.Rows[c];

                                _denominations.Rows.Add(new object[]{
                                                        null, _cur["Currency"].ToString(), _row["Denomination"],
                                                        1, DateTime.Now, DateTime.Now, 0, null});
                            }
                        }
                    }

                    QueryGenerator _generator = new QueryGenerator(_denominations);
                    _generator.ExcludedFields.Add("LastModified");

                    string _query = _generator.ToString();
                    if (!string.IsNullOrEmpty(_query.RLTrim()))
                    {
                        QueResult _result = Que.Execute(SCMS.Connection, _query);
                        if (string.IsNullOrEmpty(_result.Error.RLTrim()))
                        { _denominations.AcceptChanges(); Cache.Save(); }
                        else _denominations.RejectChanges();
                    }
                }

                _defaultdenominations.Dispose(); _defaultdenominations = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        /// <summary>
        /// Exports the specified table into a certain file.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileInfo ExportData(this DataTable table, string path)
        { return table.ExportData(path, false); }

        /// <summary>
        /// Exports the specified table into a certain file.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="path"></param>
        /// <param name="encrypted"></param>
        /// <returns></returns>
        public static FileInfo ExportData(this DataTable table, string path, bool encrypted)
        {
            FileInfo _exportedfile = null;

            if (table != null)
            {
                bool _written = false;

                try 
                { 
                    table.WriteXml(path, XmlWriteMode.WriteSchema);
                    if (!_written) _written = true;
                }
                catch (Exception ex) { LogError("ExportData", ex); }

                if (_written)
                {
                    if (File.Exists(path)) _exportedfile = new FileInfo(path);
                    
                    if (encrypted)
                    {
                        bool _encrypted = _exportedfile.Encrypt(EncryptionKey);
                        if (!_encrypted) _exportedfile = null;
                    }
                }
            }

            Materia.RefreshAndManageCurrentProcess();

            return _exportedfile;
        }

        /// <summary>
        /// Formats data in each of the grid's column based on the column's data type.
        /// </summary>
        /// <param name="grid"></param>
        public static void FormatColumns(this C1FlexGrid grid)
        {
            if (grid != null)
            {
                for (int i = grid.Cols.Fixed; i <= (grid.Cols.Count - 1); i++)
                {
                    Column _col = grid.Cols[i];
                    if (_col.DataType != null)
                    {
                        if (_col.DataType.Name == typeof(DateTime).Name ||
                            _col.DataType.Name.Contains("Date")) _col.Format = "dd-MMM-yyyy";
                        else if (_col.DataType.Name == typeof(decimal).Name ||
                                 _col.DataType.Name == typeof(Decimal).Name ||
                                 _col.DataType.Name == typeof(double).Name ||
                                 _col.DataType.Name == typeof(Double).Name ||
                                 _col.DataType.Name == typeof(float).Name ||
                                 _col.DataType.Name == typeof(Single).Name) _col.Format = "N2";
                        else { }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the Row the corresponds by the current mouse cursor position.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetMouseOveredRow(this C1FlexGrid grid, int x, int y)
        { return grid.GetMouseOveredRow(new Point(x, y));  }

        /// <summary>
        /// Returns the Row the corresponds by the current mouse cursor position.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="mouseposition"></param>
        /// <returns></returns>
        public static int GetMouseOveredRow(this C1FlexGrid grid, Point mouseposition)
        {
            int _index = -1;

            if (grid != null)
            {
                HitTestInfo _hittest = grid.HitTest(mouseposition);
                _index = _hittest.Row;
            }

            return _index;
        }

        /// <summary>
        /// Request a series number to the corresponding table name.
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static string GetTableSeriesNumber(string tablename)
        { return GetTableSeriesNumber(tablename, false); }

        /// <summary>
        /// Request a series number to the corresponding table name.
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="official"></param>
        /// <returns></returns>
        public static string GetTableSeriesNumber(string tablename, bool official)
        { return GetTableSeriesNumber(tablename, 5, official); }

        /// <summary>
        /// Request a series number to the corresponding table name.
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string GetTableSeriesNumber(string tablename, int digits)
        { return GetTableSeriesNumber(tablename, digits, false); }

        /// <summary>
        /// Request a series number to the corresponding table name.
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="digits"></param>
        /// <param name="official"></param>
        /// <returns></returns>
        public static string GetTableSeriesNumber(string tablename, int digits, bool official)
        {
            string _seriesnumber = "";

            long _counter = 0;

            Cache.SyncTable(SCMS.Connection, "keysettings");
            DataTable _keys = Cache.GetCachedTable("keysettings");

            if (_keys != null)
            {
                DataRow[] _rows = _keys.Select("[TableName] LIKE '" + tablename.ToSqlValidString(true) + "'");
                if (_rows.Length > 0) _counter = (long)_rows[0]["Counter"];     
            }

            _counter += 1; string _zeros = "";

            while (_seriesnumber.RLTrim().Length < digits)
            {
                _zeros += "0";
                _seriesnumber = _zeros + _counter.ToString();
            }

            if (official &&
                _keys != null)
            {
                DataRow[] _rows = _keys.Select("[TableName] LIKE '" + tablename.ToSqlValidString(true) + "'");
                
                if (_rows.Length > 0) _rows[0]["Counter"] = _counter;
                else
                {
                    DataColumnCollection _cols = _keys.Columns;
                    object[] _values = new object[_cols.Count];
                    _values[_cols["TableName"].Ordinal] = tablename;
                    _values[_cols["Counter"].Ordinal] = _counter;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _keys.Rows.Add(_values);
                 }

                QueryGenerator _generator = new QueryGenerator(_keys);
                _generator.ExcludedFields.Add("LastModified");
                string _query = _generator.ToString();
                _generator = null; Materia.RefreshAndManageCurrentProcess();

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    QueResult _result = Que.Execute(SCMS.Connection, _query);
                    if (string.IsNullOrEmpty(_query.RLTrim())) _keys.AcceptChanges();
                }
            }

            return _seriesnumber;
        }

        private static void grid_AfterRowUpdated(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender.GetType().Name == typeof(C1FlexGrid).Name) ApplyNumberings((C1FlexGrid)sender);
            }
        }

        private static void grid_AfterRowUpdated(object sender, RowColEventArgs e)
        {
            if (sender != null)
            {
                if (sender.GetType().Name == typeof(C1FlexGrid).Name) ApplyNumberings((C1FlexGrid)sender);
            }
        }

        private static void grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            if (sender.GetType() != typeof(C1FlexGrid)) return;
            C1FlexGrid _grid = (C1FlexGrid)sender;

            if (!_grid.Redraw) return;
            if (_grid.DataSource == null) return;
            int _row = _grid.GetMouseOveredRow(e.X, e.Y);
            if (_row < _grid.Rows.Fixed) _grid.Cursor = Cursors.Default;
            else
            {
                if (_grid.Rows[_row].IsNode) _grid.Cursor = Cursors.Default;
                else _grid.Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// Loads accounts from the chart of accounts into the specified data sourced combo box control.
        /// </summary>
        /// <param name="combobox"></param>
        public static void LoadAccounts(this DataSourcedComboBox combobox)
        {
            if (combobox == null) return;
            DataTable _accounts = Cache.GetCachedTable("accounts");

            if (_accounts != null)
            {
                IEnumerable<DataRow> _query = from ac in _accounts.AsEnumerable()
                                              where ac.Field<Int16>("Header") == 0 && ac.Field<Int16>("Sum") == 0
                                              select ac;

                DataTable _table = _query.CopyToDataTable();
                _table.DefaultView.Sort = "[AccountCode]";

                combobox.Enabled = false;
                combobox.DataSource = null; Materia.RefreshAndManageCurrentProcess();
                combobox.DisplayMember = "AccountCode"; combobox.ValueMember = "AccountCode";
                combobox.DataSource = _table;
                ColumnCollection _cols = combobox.Cols;
                string[] _visiblecols = new string[] { "AccountCode", "AccountName" };
                for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++)
                {
                    if (_visiblecols.Contains(_cols[i].Name))
                    {
                        if (_cols[i].Name == "AccountCode") _cols[i].Caption = "Account Code";
                        else if (_cols[i].Name == "AccountName") _cols[i].Caption = "Account Name";
                        else { }

                        _cols[i].Visible = true;
                    }
                    else _cols[i].Visible = false;
                }
                combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                combobox.SelectedIndex = -1; combobox.Enabled = true;
            }
        }

        /// <summary>
        /// Loads list of brands into the specified control as a data source.
        /// </summary>
        /// <param name="control"></param>
        public static void LoadBrands(this Control control)
        {
            if (control == null) return;
            if (!(Materia.PropertyExists(control, "DataSource") &&
                  Materia.PropertyExists(control, "DisplayMember") &&
                  Materia.PropertyExists(control, "ValueMember"))) return;

            DataTable _brands = Cache.GetCachedTable("brands");
            if (_brands != null)
            {
                control.Enabled = false;
                object _datasource = Materia.GetPropertyValue<object>(control, "DataSource");
                if (_datasource != null)
                {
                    try { ((DataTable)_datasource).Dispose(); }
                    catch { }
                    finally
                    {
                        Materia.SetPropertyValue(control, "DataSource", null);
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                DataTable _newdatasource = _brands.Replicate();
                _newdatasource.DefaultView.Sort = "[Brand]";

                Materia.SetPropertyValue(control, "DataSource", _newdatasource);
                Materia.SetPropertyValue(control, "DisplayMember", "Brand");
                Materia.SetPropertyValue(control, "ValueMember", "Brand");

                if (Materia.PropertyExists(control, "AutoCompleteMode") &&
                    Materia.PropertyExists(control, "AutoCompleteSource"))
                {
                    Materia.SetPropertyValue(control, "AutoCompleteMode", AutoCompleteMode.SuggestAppend);
                    Materia.SetPropertyValue(control, "AutoCompleteSource", AutoCompleteSource.ListItems);
                }

                if (Materia.PropertyExists(control, "SelectedIndex"))
                {
                    try { Materia.SetPropertyValue(control, "SelectedIndex", -1); }
                    catch { }
                }

                control.Enabled = true;
            }
        }

        /// <summary>
        /// Loads the currency list into the specified combo box as it's data source.
        /// </summary>
        /// <param name="combobox"></param>
        public static void LoadCurrencies(this DataSourcedComboBox combobox)
        {
            if (combobox == null) return;
            DataTable _currencies = Cache.GetCachedTable("currencies");

            if (_currencies != null)
            {
                DataTable _datasource = _currencies.Replicate();
                combobox.Enabled = false;

                if (combobox.DataSource != null)
                {
                    try { ((DataTable)combobox.DataSource).Dispose(); }
                    catch { }
                    finally 
                    {
                        combobox.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _datasource.DefaultView.Sort = "[Currency]";
                combobox.DisplayMember = "Currency"; combobox.ValueMember = "Currency";
                combobox.DataSource = _datasource;

                ColumnCollection _cols = combobox.Cols;
                string[] _visiblecols = new string[] { "Currency", "Description" };

                for (int i = 0; i<= (_cols.Count -1); i++) _cols[i].Visible = _visiblecols.Contains(_cols[i].Name);

                try { combobox.SelectedValue = null; }
                catch { }

                combobox.Enabled = true;
            }
        }

        /// <summary>
        /// Loads the list of locations into the specified control as a data source.
        /// </summary>
        /// <param name="control"></param>
        public static void LoadLocations(this Control control)
        {
            if (control == null) return;
            if (!(Materia.PropertyExists(control, "DataSource") &&
                  Materia.PropertyExists(control, "DisplayMember") &&
                  Materia.PropertyExists(control, "ValueMember"))) return;

            DataTable _locations = Cache.GetCachedTable("locations");
            if (_locations != null)
            {
                control.Enabled = false;
                object _datasource = Materia.GetPropertyValue<object>(control, "DataSource");
                if (_datasource != null)
                {
                    try { ((DataTable)_datasource).Dispose(); }
                    catch { }
                    finally
                    {
                        Materia.SetPropertyValue(control, "DataSource", null);
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                DataTable _newdatasource = _locations.Replicate();
                _newdatasource.DefaultView.RowFilter = "[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'";
                _newdatasource.DefaultView.Sort = "[Location]";

                Materia.SetPropertyValue(control, "DataSource", _newdatasource);
                Materia.SetPropertyValue(control, "DisplayMember", "Location");
                Materia.SetPropertyValue(control, "ValueMember", "LocationCode");

                if (Materia.PropertyExists(control, "AutoCompleteMode") &&
                    Materia.PropertyExists(control, "AutoCompleteSource"))
                {
                    Materia.SetPropertyValue(control, "AutoCompleteMode", AutoCompleteMode.SuggestAppend);
                    Materia.SetPropertyValue(control, "AutoCompleteSource", AutoCompleteSource.ListItems);
                }

                if (Materia.PropertyExists(control, "SelectedIndex"))
                {
                    try { Materia.SetPropertyValue(control, "SelectedIndex", -1); }
                    catch { }
                }

                control.Enabled = true;
            }
        }

        public static void LoadMeasurements(this Control control)
        {
            if (control == null) return;
            if (!(Materia.PropertyExists(control, "DataSource") &&
                  Materia.PropertyExists(control, "DisplayMember") &&
                  Materia.PropertyExists(control, "ValueMember"))) return;

            DataTable _measures = Cache.GetCachedTable("measurements");
            if (_measures != null)
            {
                control.Enabled = false;
                object _datasource = Materia.GetPropertyValue<object>(control, "DataSource");
                if (_datasource != null)
                {
                    try { ((DataTable)_datasource).Dispose(); }
                    catch { }
                    finally
                    {
                        Materia.SetPropertyValue(control, "DataSource", null);
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                DataTable _newdatasource = _measures.Replicate();
                _newdatasource.DefaultView.Sort = "[Unit]";

                Materia.SetPropertyValue(control, "DataSource", _newdatasource);
                Materia.SetPropertyValue(control, "DisplayMember", "Unit");
                Materia.SetPropertyValue(control, "ValueMember", "Unit");

                if (Materia.PropertyExists(control, "AutoCompleteMode") &&
                    Materia.PropertyExists(control, "AutoCompleteSource"))
                {
                    Materia.SetPropertyValue(control, "AutoCompleteMode", AutoCompleteMode.SuggestAppend);
                    Materia.SetPropertyValue(control, "AutoCompleteSource", AutoCompleteSource.ListItems);
                }

                if (Materia.PropertyExists(control, "SelectedIndex"))
                {
                    try { Materia.SetPropertyValue(control, "SelectedIndex", -1); }
                    catch { }
                }

                control.Enabled = true;
            }
        }

        /// <summary>
        /// Loads all parts category into the specified control as a data source.
        /// </summary>
        /// <param name="control"></param>
        public static void LoadPartCategories(this Control control)
        {
            if (control == null) return;
            DataTable _partcategories = Cache.GetCachedTable("partcategories");

            if (_partcategories != null)
            {
                control.Enabled = false;
                object _datasource = Materia.GetPropertyValue<object>(control, "DataSource");
                if (_datasource != null)
                {
                    try { ((DataTable)_datasource).Dispose(); }
                    catch { }
                    finally
                    {
                        Materia.SetPropertyValue(control, "DataSource", null);
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                DataTable _newdatasource = _partcategories.Replicate();
                _newdatasource.DefaultView.Sort = "[PartCategory]";

                Materia.SetPropertyValue(control, "DataSource", _newdatasource);
                Materia.SetPropertyValue(control, "DisplayMember", "PartCategory");
                Materia.SetPropertyValue(control, "ValueMember", "PartCategory");

                if (Materia.PropertyExists(control, "AutoCompleteMode") &&
                    Materia.PropertyExists(control, "AutoCompleteSource"))
                {
                    Materia.SetPropertyValue(control, "AutoCompleteMode", AutoCompleteMode.SuggestAppend);
                    Materia.SetPropertyValue(control, "AutoCompleteSource", AutoCompleteSource.ListItems);
                }

                if (Materia.PropertyExists(control, "SelectedIndex"))
                {
                    try { Materia.SetPropertyValue(control, "SelectedIndex", -1); }
                    catch { }
                }

                control.Enabled = true;
            }
        }

        /// <summary>
        /// Loads all available parts names into the specified control as a data source.
        /// </summary>
        /// <param name="control"></param>
        public static void LoadPartNames(this Control control)
        {
            if (control == null) return;
            DataTable _partnames = Cache.GetCachedTable("partnames");

            if (_partnames != null)
            {
                control.Enabled = false;
                object _datasource = Materia.GetPropertyValue<object>(control, "DataSource");
                if (_datasource != null)
                {
                    try { ((DataTable)_datasource).Dispose(); }
                    catch { }
                    finally
                    {
                        Materia.SetPropertyValue(control, "DataSource", null);
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                DataTable _newdatasource = _partnames.Replicate();
                _newdatasource.DefaultView.Sort = "[PartName]";

                Materia.SetPropertyValue(control, "DataSource", _newdatasource);
                Materia.SetPropertyValue(control, "DisplayMember", "PartName");
                Materia.SetPropertyValue(control, "ValueMember", "PartName");

                if (Materia.PropertyExists(control, "AutoCompleteMode") &&
                    Materia.PropertyExists(control, "AutoCompleteSource"))
                {
                    Materia.SetPropertyValue(control, "AutoCompleteMode", AutoCompleteMode.SuggestAppend);
                    Materia.SetPropertyValue(control, "AutoCompleteSource", AutoCompleteSource.ListItems);
                }

                if (Materia.PropertyExists(control, "SelectedIndex"))
                {
                    try { Materia.SetPropertyValue(control, "SelectedIndex", -1); }
                    catch { }
                }

                control.Enabled = true;
            }
        }

        /// <summary>
        /// Loads the list of parts into the specified control as a data source.
        /// </summary>
        /// <param name="control"></param>
        public static void LoadParts(this Control control)
        {
            if (control == null) return;
            DataTable _parts = Cache.GetCachedTable("parts");

            if (_parts != null)
            {
                control.Enabled = false;
                object _datasource = Materia.GetPropertyValue<object>(control, "DataSource");
                if (_datasource != null)
                {
                    try { ((DataTable)_datasource).Dispose(); }
                    catch { }
                    finally
                    {
                        Materia.SetPropertyValue(control, "DataSource", null);
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                DataTable _newdatasource = _parts.Replicate();
                _newdatasource.DefaultView.Sort = "[PartNo]";
                _newdatasource.DefaultView.RowFilter = "[Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "'";

                Materia.SetPropertyValue(control, "DataSource", _newdatasource);
                Materia.SetPropertyValue(control, "DisplayMember", "PartNo");
                Materia.SetPropertyValue(control, "ValueMember", "PartCode");

                if (Materia.PropertyExists(control, "AutoCompleteMode") &&
                    Materia.PropertyExists(control, "AutoCompleteSource"))
                {
                    Materia.SetPropertyValue(control, "AutoCompleteMode", AutoCompleteMode.SuggestAppend);
                    Materia.SetPropertyValue(control, "AutoCompleteSource", AutoCompleteSource.ListItems);
                }

                if (Materia.PropertyExists(control, "SelectedIndex"))
                {
                    try { Materia.SetPropertyValue(control, "SelectedIndex", -1); }
                    catch { }
                }

                control.Enabled = true;
            }
        }

        /// <summary>
        /// Loads the list of system user into the specified control as a data source.
        /// </summary>
        /// <param name="combobox"></param>
        public static void LoadUsers(this DataSourcedComboBox combobox)
        {
            if (combobox == null) return;

            DataTable _users = Cache.GetCachedTable("users");
            if (_users != null)
            {
                var _query = from _usr in _users.AsEnumerable()
                             where _usr.Field<Int16>("Voided") == 0
                             select new
                             {
                                 Username = _usr.Field<string>("Username"),
                                 AccountHolder = _usr.Field<string>("FirstName") + " " + _usr.Field<string>("LastName"),
                                 Department = _usr.Field<string>("Department"),
                                 Position = _usr.Field<string>("Position")
                             };


                DataTable _datasource = new DataTable();
                _datasource.TableName = "users";
                DataColumn _pk = _datasource.Columns.Add("Username", typeof(string));
                _datasource.Columns.Add("AccountHolder", typeof(string));
                _datasource.Columns.Add("Department", typeof(string));
                _datasource.Columns.Add("Position", typeof(string));

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { 
                                                                  _row.Username, _row.AccountHolder,
                                                                  _row.Department, _row.Position });

                _datasource.DefaultView.Sort = "[Username]";

                combobox.Enabled = false;

                if (combobox.DataSource != null)
                {
                    try { ((DataTable)combobox.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        combobox.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                combobox.DisplayMember = "Username"; combobox.ValueMember = "Username";
                combobox.DataSource = _datasource;

                ColumnCollection _cols = combobox.Cols;
                _cols["AccountHolder"].Caption = "Account Holder";

                try { combobox.SelectedValue = null; }
                catch { }

                combobox.Enabled = true;
            }
        }
     
        /// <summary>
        /// Logs the specified encountered exception into the applications error logs.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="ex"></param>
        public static void LogError(string window, Exception ex)
        {
            if (ex != null)
            {
                string _path = Application.StartupPath + "\\Xml\\errorlogs.xml";
                DataTable _table = XmlToTable(_path);

                if (_table != null)
                {
                    object[] _values = new object[_table.Columns.Count];
                    _values[_table.Columns["ComputerName"].Ordinal] = System.Environment.MachineName;
                    _values[_table.Columns["DateAndTime"].Ordinal] = DateTime.Now;
                    _values[_table.Columns["Window"].Ordinal] = window;
                    _values[_table.Columns["ErrorMessage"].Ordinal] = ex.Message;
                    _values[_table.Columns["StackTrace"].Ordinal] = ex.StackTrace;

                    try { _table.Rows.Add(_values); }
                    catch { }
                  
                    try { _table.WriteXml(_path, XmlWriteMode.WriteSchema); }
                    catch { }

                    try { _table.Dispose(); }
                    catch { }

                    _table = null; Materia.RefreshAndManageCurrentProcess();
                }
            }
        }

        /// <summary>
        /// Imports the specified file into a DataTable object.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable ImportData(string path)
        { return ImportData(path, false); }

        /// <summary>
        /// Imports the specified file into a DataTable object.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="decrypt"></param>
        /// <returns></returns>
        public static DataTable ImportData(string path, bool decrypt)
        {
            DataTable _table = null; string _filename = "";

            if (File.Exists(path))
            {
                if (decrypt)
                {
                    string _tempdir = Application.StartupPath + "\\Temp";

                    if (!Directory.Exists(_tempdir))
                    {
                        try { Directory.CreateDirectory(_tempdir); }
                        catch { }
                    }

                    if (Directory.Exists(_tempdir))
                    {
                        int _trycounter = 0;

                        string _path = _tempdir + "\\" + Path.GetFileNameWithoutExtension(path) + ".xml";
                        while (File.Exists(_path) &&
                              _trycounter < 30)
                        {
                            try { File.Delete(_path); }
                            catch { }
                            _trycounter += 1;
                            Thread.Sleep(100); Application.DoEvents();
                        }

                        FileInfo _file = new FileInfo(path);
                        string _decrypted = _file.Decrypt(EncryptionKey);

                        FileInfo _xmfile = Materia.WriteToFile(_path, _decrypted, false);
                        if (_xmfile != null) _filename = _xmfile.FullName;
                    }
                }
            }
            else _filename = path;

            if (!string.IsNullOrEmpty(_filename.RLTrim()))
            {
                _table = new DataTable();

                try { _table.ReadXml(_filename); }
                catch
                { _table.Dispose(); _table = null; }

                Materia.RefreshAndManageCurrentProcess();
            }

            return _table;
        }

        public static void InitializeAppearance(this C1FlexGrid grid)
        {
            if (grid != null)
            {
                if (grid.Redraw) grid.BeginUpdate();

                if (grid.DataSource != null)
                {
                    try { grid.DataSource = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }

                grid.Clear(ClearFlags.All);
                grid.Rows.Fixed = 1; grid.Rows.Count = 1;
                grid.Cols.Fixed = 1; grid.Cols.Count = 1;

                grid.AllowAddNew = false; grid.AllowDelete = false;
                grid.AllowEditing = false; grid.AllowFiltering = false;

                for (int i = 0; i <= 10; i++)
                {
                    CellStyle _style = null;

                    if (grid.Styles.Contains("SubTotal" + i.ToString())) _style = grid.Styles["SubTotal" + i.ToString()];
                    else _style = grid.Styles.Add("SubTotal" + i.ToString());

                    if (_style != null)
                    {
                        _style.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                        _style.BackColor = Color.White;
                    }
                }

                grid.Styles.Normal.Border.Color = Color.Gainsboro;
                grid.Styles.EmptyArea.BackColor = Color.White;
                grid.Styles.EmptyArea.Border.Style = BorderStyleEnum.None;
                grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
                grid.KeyActionEnter = KeyActionEnum.MoveAcrossOut;
                grid.KeyActionTab = KeyActionEnum.MoveAcrossOut;
                grid.SelectionMode = SelectionModeEnum.Row;

                grid.ExtendLastCol = false; grid.Cols[0].Width = 0;

                while (!grid.Redraw) grid.EndUpdate();
            }
        }

        /// <summary>
        /// Serialized each of the specified DataTable object's column default values.
        /// </summary>
        /// <param name="table"></param>
        public static void SerializeColumns(this DataTable table)
        {
            if (table == null) return;
            DataColumnCollection _cols = table.Columns;

            for (int i = 0; i <= (_cols.Count - 1); i++)
            {
                if (!_cols[i].Unique)
                {
                    if (_cols[i].DataType == typeof(string) ||
                        _cols[i].DataType == typeof(String)) _cols[i].DefaultValue = "";
                    else if (_cols[i].DataType == typeof(DateTime)) _cols[i].DefaultValue = DateTime.Now;
                    else if (_cols[i].DataType == typeof(decimal) ||
                             _cols[i].DataType == typeof(double) ||
                             _cols[i].DataType == typeof(Single) ||
                             _cols[i].DataType == typeof(float) ||
                             _cols[i].DataType == typeof(int) ||
                             _cols[i].DataType == typeof(long) ||
                             _cols[i].DataType == typeof(short) ||
                             _cols[i].DataType == typeof(byte) ||
                             _cols[i].DataType == typeof(Int16) ||
                             _cols[i].DataType == typeof(Int32) ||
                             _cols[i].DataType == typeof(Int64) ||
                             _cols[i].DataType == typeof(Byte)) _cols[i].DefaultValue = 0;
                    else { }
                }
            }
        }

        /// <summary>
        /// Retrieves an Xml-based DataSet object from the specified file.
        /// </summary>
        /// <param name="path">Xml file path</param>
        /// <returns></returns>
        public static DataSet XmlToDataSet(string path)
        {
            DataSet _dataset = null;

            if (File.Exists(path))
            {
                _dataset = new DataSet();

                try { _dataset.ReadXml(path); }
                catch
                {
                    _dataset.Dispose(); _dataset = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }

            return _dataset;
        }

        /// <summary>
        /// Retrieves an Xml-based DataTable object from the specified file.
        /// </summary>
        /// <param name="path">Xml file path</param>
        /// <returns></returns>
        public static DataTable XmlToTable(string path)
        {
            DataTable _table = null;

            if (File.Exists(path))
            {
                _table = new DataTable();

                try { _table.ReadXml(path); }
                catch
                {
                    _table.Dispose(); _table = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }

            return _table;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ValidatorCollection _validators = new ValidatorCollection();

        /// <summary>
        /// Gets the collection of Validator controls the application is currently using.
        /// </summary>
        public static ValidatorCollection Validators
        {
            get { return _validators; }
        }

    }
}
