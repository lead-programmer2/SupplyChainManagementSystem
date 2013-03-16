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
    public partial class PickListDialog : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of PickListDialog.
        /// </summary>
        /// <param name="list"></param>
        public PickListDialog(PickList list)
        {
            InitializeComponent();

            _currentlist = list;
            btnNew.Click += new EventHandler(btnNewAndEdit_Click);
            btnEdit.Click += new EventHandler(btnNewAndEdit_Click);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        PickList _currentlist = PickList.None;

        /// <summary>
        /// Gets the current displayed maintenance list.
        /// </summary>
        public PickList CurrentList
        {
            get { return _currentlist; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        private void DisplayInfo()
        {
            if (grdPickList.DataSource == null) btnInformation.Text = " Ready";
            else
            {
                DataTable _datasource = (DataTable)grdPickList.DataSource;
                if (_datasource.Rows.Count <= 0) btnInformation.Text = " Ready";
                else
                {
                    DataTable _viewtable = _datasource.DefaultView.ToTable();
                    btnInformation.Text = " Displayed records : " + _viewtable.Rows.Count + " out of " + _datasource.Rows.Count + ".";
                    _viewtable.Dispose(); _viewtable = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }
        }

        private void EnableButtons()
        {
            btnRefresh.Enabled = true; btnNew.Enabled = true;
            txtSearch.Enabled = true; cboPickList.Enabled = true;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdPickList.DataSource; }
            catch { }

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
            if (grdPickList.DataSource == null) return;

            ColumnCollection _cols = grdPickList.Cols;

            switch (_currentlist)
            {
                case PickList.AdditionalCharges:
                    _cols["AdditionalCharge"].Caption = "Additional Charge"; break;
                case  PickList.Bank:
                    _cols["Bank"].Caption = "Banking Company"; break;
                case PickList.BankMiscellaneous:
                    _cols["BankMiscellaneous"].Caption = "Bank Miscellaneous"; break;
                case PickList.CurrencyDenominations:
                    grdPickList.FormatColumns(); 
                    _cols["DetailId"].Visible = false; break;
                case PickList.CustomerGroups:
                    _cols["CustomerGroup"].Caption = "Customer Group"; break;
                case PickList.Locations:
                    _cols["LocationCode"].Visible = false; break;
                case PickList.Models:
                    _cols["ModelCode"].Visible = false; break;
                case PickList.PartCategories:
                    _cols["PartCategory"].Caption = "Parts Category"; break;
                case PickList.PartNames:
                    _cols["PartName"].Caption = "Part Name";
                    _cols["PartCategory"].Caption = "Parts Category"; break;
                case PickList.PaymentTerms :
                    _cols["PaymentTerm"].Caption = "Payment Term"; break;
                case PickList.Signatories:
                    _cols["DetailId"].Visible = false; break;
                default: break;
            }

            grdPickList.AutoNumber(); _cols[_cols.Fixed - 1].Caption = "#";
        }

        private DataTable GetAdditionalCharges()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "additionalcharges");
            Cache.SyncTable(SCMS.Connection, "accounts");
            DataTable _additionalcharges = Cache.GetCachedTable("additionalcharges");

            if (_additionalcharges != null)
            {
                string _path = Application.StartupPath + "\\Xml\\chargegroups.xml";
                DataTable _groups = SCMS.XmlToTable(_path);

                if (_groups != null)
                {
                    var _query = from _ac in _additionalcharges.AsEnumerable()
                                 join _grp in _groups.AsEnumerable() 
                                 on _ac.Field<int>("ChargeGroup") equals _grp.Field<int>("Id")
                                 select new 
                                 {
                                     AdditionalCharge = _ac.Field<string>("AdditionalCharge"),
                                     Group = _grp.Field<string>("Group")
                                 };

                    _datasource = new DataTable();
                    _datasource.TableName = "additionalcharges";

                    DataColumn _pkcol = _datasource.Columns.Add("AdditionalCharge", typeof(string));
                    _datasource.Columns.Add("Group", typeof(string));
                    _datasource.Constraints.Add("PK", _pkcol, true);

                    foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.AdditionalCharge, _row.Group });

                    _datasource.DefaultView.Sort = "[Group], [AdditionalCharge]";
                }
            }

            return _datasource;
        }

        private DataTable GetBankMiscellaneous()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "bankmiscellaneous");
            Cache.SyncTable(SCMS.Connection, "accounts");
            DataTable _bankmisc = Cache.GetCachedTable("bankmiscellaneous");

            if (_bankmisc != null)
            {
                var _query = from _bnkmisc in _bankmisc.AsEnumerable()
                             select new 
                             { 
                                 BankMiscellaneous = _bnkmisc.Field<string>("BankMiscellaneous"), 
                                 Type = ( _bnkmisc.Field<int>("Type") == 0? "Additional" : "Deduction").ToString()
                             };

                _datasource = new DataTable();
                _datasource.TableName = "bankmiscellaneous";
                DataColumn _pkcol = _datasource.Columns.Add("BankMiscellaneous", typeof(string));
                _datasource.Columns.Add("Type", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.BankMiscellaneous, _row.Type });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[BankMiscellaneous]";
            }

            return _datasource;
        }

        private DataTable GetBankingCompanies()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "banks");
            DataTable _banks = Cache.GetCachedTable("banks");

            if (_banks != null)
            {
                var _query = from _bnk in _banks.AsEnumerable()
                             select new { Bank = _bnk.Field<string>("Bank") };

                _datasource = new DataTable();
                _datasource.TableName = "banks";
                DataColumn _pkcol = _datasource.Columns.Add("Bank", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Bank });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Bank]";
            }

            return _datasource;
        }

        private DataTable GetBrands()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "brands");
            DataTable _brands = Cache.GetCachedTable("brands");

            if (_brands != null)
            {
                var _query = from _br in _brands.AsEnumerable()
                             select new { Brand = _br.Field<string>("Brand") };

                _datasource = new DataTable();
                _datasource.TableName = "brands";
                DataColumn _pkcol = _datasource.Columns.Add("Brand", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Brand });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Brand]";
            }

            return _datasource;
        }

        private DataTable GetCurrencies()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "currencies");
            Cache.SyncTable(SCMS.Connection, "accounts");
            DataTable _currencies = Cache.GetCachedTable("currencies");

            if (_currencies != null)
            {
                var _query = from _cur in _currencies.AsEnumerable()
                             select new
                             {
                                 Currency = _cur.Field<string>("Currency"),
                                 Description = _cur.Field<string>("Description")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "currencies";
                DataColumn _pkcol = _datasource.Columns.Add("Currency", typeof(string));
                _datasource.Columns.Add("Description", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Currency, _row.Description });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Currency]";
            }

            return _datasource;
        }

        private DataTable GetCurrencyDenominations()
        {
            DataTable _datasource = null; SCMS.CreateInitialCurrencyDenominations();

            Cache.SyncTable(SCMS.Connection, "currencydenominations");
            Cache.SyncTable(SCMS.Connection, "currencies");
            DataTable _denominations = Cache.GetCachedTable("currencydenominations");
            
            if (_denominations != null)
            {
                var _query = from _denom in _denominations.AsEnumerable()
                             select new
                             {
                                 DetailId = _denom.Field<Int32>("DetailId"),
                                 Denomination = _denom.Field<decimal>("Denomination"),
                                 Currency = _denom.Field<string>("Currency")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "currencydenominations";
                
                DataColumn _pk = _datasource.Columns.Add("DetailId", typeof(long));
                _datasource.Columns.Add("Denomination", typeof(decimal));
                _datasource.Columns.Add("Currency", typeof(string));
                _datasource.Constraints.Add("PK", _pk, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.DetailId, _row.Denomination, _row.Currency });

                _datasource.AcceptChanges(); _datasource.DefaultView.Sort = "[Currency], [Denomination]";
            }

            return _datasource;
        }

        private DataTable GetCustomerGroups()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "customergroups");
            DataTable _customergroups = Cache.GetCachedTable("customergroups");

            if (_customergroups != null)
            {
                var _query = from _cgrp in _customergroups.AsEnumerable()
                             select new { CustomerGroup = _cgrp.Field<string>("CustomerGroup") };

                _datasource = new DataTable();
                _datasource.TableName = "customergroups";
                DataColumn _pkcol = _datasource.Columns.Add("CustomerGroup", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.CustomerGroup });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[CustomerGroup]";
            }

            return _datasource;
        }

        private DataTable GetDepartments()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "departments");
            DataTable _departments = Cache.GetCachedTable("departments");

            if (_departments != null)
            {
                var _query = from _depts in _departments.AsEnumerable()
                             select new { Department = _depts.Field<string>("Department") };

                _datasource = new DataTable();
                _datasource.TableName = "departments";
                DataColumn _pkcol = _datasource.Columns.Add("Department", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Department });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Department]";
            }

            return _datasource;
        }

        private DataTable GetLocations()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "locations", "LocationCode");
            DataTable _locations = Cache.GetCachedTable("locations");

            if (_locations != null)
            {
                var _query = from _locs in _locations.AsEnumerable()
                             where _locs.Field<string>("Company") == SCMS.CurrentCompany.Company
                             select new 
                             { 
                                 LocationCode = _locs.Field<string>("LocationCode"),
                                 Location = _locs.Field<string>("Location") 
                             };

                _datasource = new DataTable();
                _datasource.TableName = "locations";
                DataColumn _pkcol = _datasource.Columns.Add("LocationCode", typeof(string));
                _datasource.Columns.Add("Location", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.LocationCode, _row.Location });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Location]";
            }

            return _datasource;
        }

        private DataTable GetMeasurements()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "measurements");
            DataTable _measurements = Cache.GetCachedTable("measurements");

            if (_measurements != null)
            {
                var _query = from _uom in _measurements.AsEnumerable()
                             select new 
                             { 
                                 Unit = _uom.Field<string>("Unit"),
                                 Description = _uom.Field<string>("Description")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "measurements";
                DataColumn _pkcol = _datasource.Columns.Add("Unit", typeof(string));
                _datasource.Columns.Add("Description", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);
                
                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Unit, _row.Description });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Unit]";
            }

            return _datasource;
        }

        private DataTable GetModels()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "models", "ModelCode");
            Cache.SyncTable(SCMS.Connection, "brands");

            DataTable _models = Cache.GetCachedTable("models");

            if (_models != null)
            {
                var _query = from _mdl in _models.AsEnumerable()
                             select new
                             {
                                 ModelCode = _mdl.Field<string>("ModelCode"),
                                 Brand = _mdl.Field<string>("Brand"),
                                 Model = _mdl.Field<string>("Model")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "models";
                DataColumn _pkcol = _datasource.Columns.Add("ModelCode", typeof(string));
                _datasource.Columns.Add("Model", typeof(string));
                _datasource.Columns.Add("Brand", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.ModelCode, _row.Model,
                                                                                 _row.Brand });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Brand], [Model]";
            }

            return _datasource;
        }

        private string GetPickListName(PickList list)
        {
            string _name = "";

            string _path = Application.StartupPath + "\\Xml\\picklist.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataRow[] _rows = _table.Select("[Id] = " + ((int)list).ToString());
                if (_rows.Length > 0) _name = _rows[0]["Name"].ToString();

                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();
            }

            return _name;
        }

        private DataTable GetPartCategories()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "partcategories");
            DataTable _partcategories = Cache.GetCachedTable("partcategories");

            if (_partcategories != null)
            {
                var _query = from _categ in _partcategories.AsEnumerable()
                             select new  { PartCategory = _categ.Field<string>("PartCategory") };

                _datasource = new DataTable();
                _datasource.TableName = "partcategories";
                DataColumn _pkcol = _datasource.Columns.Add("PartCategory", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.PartCategory });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[PartCategory]";
            }

            return _datasource;
        }

        private DataTable GetPartNames()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "partnames");
            Cache.SyncTable(SCMS.Connection, "partcategories");
            DataTable _partnames = Cache.GetCachedTable("partnames");

            if (_partnames != null)
            {
                var _query = from _parts in _partnames.AsEnumerable()
                             select new 
                             { 
                                 PartName = _parts.Field<string>("PartName"),
                                 PartCategory = _parts.Field<string>("PartCategory")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "partnames";
                DataColumn _pkcol = _datasource.Columns.Add("PartName", typeof(string));
                _datasource.Columns.Add("PartCategory", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.PartName, _row.PartCategory });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[PartName]";
            }

            return _datasource;
        }

        private DataTable GetPaymentTerms()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "paymentterms");
            DataTable _paymentterms = Cache.GetCachedTable("paymentterms");

            if (_paymentterms != null)
            {
                var _query = from _pmterm in _paymentterms.AsEnumerable()
                             select new
                             {
                                 PaymentTerm = _pmterm.Field<string>("PaymentTerm"),
                                 Description = _pmterm.Field<string>("Description")
                             };

                _datasource = new DataTable();
                _datasource.TableName = "paymentterms";
                DataColumn _pkcol = _datasource.Columns.Add("PaymentTerm", typeof(string));
                _datasource.Columns.Add("Description", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.PaymentTerm, _row.Description });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[PaymentTerm]";
            }

            return _datasource;
        }

        private DataTable GetPositions()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "positions");
            DataTable _positions = Cache.GetCachedTable("positions");

            if (_positions != null)
            {
                var _query = from _postn in _positions.AsEnumerable()
                             select new { Position = _postn.Field<string>("Position") };

                _datasource = new DataTable();
                _datasource.TableName = "positions";
                DataColumn _pkcol = _datasource.Columns.Add("Position", typeof(string));
                _datasource.Constraints.Add("PK", _pkcol, true);

                foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.Position });

                _datasource.AcceptChanges();
                _datasource.DefaultView.Sort = "[Position]";
            }

            return _datasource;
        }

        private DataTable GetSignatories()
        {
            DataTable _datasource = null;

            Cache.SyncTable(SCMS.Connection, "users");
            Cache.SyncTable(SCMS.Connection, "signatories");

            DataTable _users = Cache.GetCachedTable("users");
            DataTable _signatories = Cache.GetCachedTable("signatories");
            
            if (_signatories != null &&
                _users != null)
            {
                string _path = Application.StartupPath + "\\Xml\\signatoryroles.xml";
                DataTable _roles = SCMS.XmlToTable(_path);

                if (_roles != null)
                {
                    var _query = from _signas in _signatories.AsEnumerable()
                                 join _usr in _users.AsEnumerable() on _signas.Field<string>("Username") equals _usr.Field<string>("Username")
                                 join _role in _roles.AsEnumerable() on _signas.Field<int>("RoleId") equals _role.Field<int>("Id")
                                 where _signas.Field<string>("Company") == SCMS.CurrentCompany.Company
                                 select new
                                 {
                                     DetailId = _signas.Field<long>("DetailId"),
                                     Signatory = _usr.Field<string>("FirstName") + " " + _usr.Field<string>("LastName"),
                                     Role = _role.Field<string>("Role")
                                 };

                    _datasource = new DataTable();
                    _datasource.TableName = "signatories";

                    DataColumn _pkcol = _datasource.Columns.Add("DetailId", typeof(long));
                    _datasource.Columns.Add("Signatory", typeof(string));
                    _datasource.Columns.Add("Role", typeof(string));

                    _datasource.Constraints.Add("PK", _pkcol, true);

                    foreach (var _row in _query) _datasource.Rows.Add(new object[] { _row.DetailId, _row.Signatory, _row.Role });

                    _datasource.AcceptChanges(); _datasource.DefaultView.Sort = "[Signatory], [Role]";

                    _roles.Dispose(); _roles = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }

            return _datasource;
        }

        private void InitializeDisplay()
        {
            cboPickList.Enabled = false; btnInformation.Text = " Gathering data...";
            btnDelete.Enabled = false; btnEdit.Enabled = false; btnNew.Enabled = false;
            btnRefresh.Enabled = false; txtSearch.Enabled = false; txtSearch.Text = "";
            pctLoad.Show(); pctLoad.BringToFront();
            if (grdPickList.Redraw) grdPickList.BeginUpdate();

            Func<DataTable> _delegate = null;

            switch (_currentlist)
            {
                case PickList.AdditionalCharges:
                    _delegate = new Func<DataTable>(GetAdditionalCharges); break;
                case PickList.Bank:
                    _delegate = new Func<DataTable>(GetBankingCompanies); break;
                case PickList.BankMiscellaneous:
                    _delegate = new Func<DataTable>(GetBankMiscellaneous); break;
                case PickList.Currencies:
                    _delegate = new Func<DataTable>(GetCurrencies); break;
                case PickList.CurrencyDenominations:
                    _delegate = new Func<DataTable>(GetCurrencyDenominations); break;
                case PickList.CustomerGroups:
                    _delegate = new Func<DataTable>(GetCustomerGroups); break;
                case PickList.Departments: 
                    _delegate = new Func<DataTable>(GetDepartments); break;
                case PickList.Locations:
                    _delegate = new Func<DataTable>(GetLocations); break;
                case PickList.Brands:
                    _delegate = new Func<DataTable>(GetBrands); break;
                case PickList.Measurements:
                    _delegate = new Func<DataTable>(GetMeasurements); break;
                case PickList.Models:
                    _delegate = new Func<DataTable>(GetModels); break;
                case PickList.PartNames:
                    _delegate = new Func<DataTable>(GetPartNames); break;
                case PickList.PartCategories:
                    _delegate = new Func<DataTable>(GetPartCategories); break;
                case PickList.PaymentTerms:
                    _delegate = new Func<DataTable>(GetPaymentTerms); break;
                case PickList.Positions:
                    _delegate = new Func<DataTable>(GetPositions); break;
                case PickList.Signatories:
                    _delegate = new Func<DataTable>(GetSignatories); break;
                default: break;
            }

            if (_delegate != null)
            {
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

                    if (_datasource != null)
                    {
                        if (grdPickList.DataSource != null)
                        {
                            try { ((DataTable)grdPickList.DataSource).Dispose(); }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }

                        grdPickList.DataSource = _datasource;
                        FormatGrid(); ResizeGrid();
                    }
                    else grdPickList.ClearRowsAndColumns();
                }
            }

            while (!grdPickList.Redraw) grdPickList.EndUpdate();

            EnableButtons(); pctLoad.Hide(); DisplayInfo();
        }

        private void InitializeListSelections()
        {
            string _path = Application.StartupPath + "\\Xml\\picklist.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                _table.DefaultView.Sort = "[Name]";

                cboPickList.Enabled = false;
                if (cboPickList.DataSource != null)
                {
                    try { ((DataTable)cboPickList.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboPickList.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                cboPickList.DataSource = _table;
                cboPickList.DisplayMember = "Name";
                cboPickList.ValueMember = "Id";
                cboPickList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboPickList.AutoCompleteSource = AutoCompleteSource.ListItems;

                try { cboPickList.SelectedValue = _currentlist; }
                catch { }

                cboPickList.Enabled = true;
            }
        }

        private void ResizeGrid()
        {
            if (grdPickList.DataSource == null) return;
            ColumnCollection _cols = grdPickList.Cols;

            grdPickList.AutoSizeCols(); grdPickList.ExtendLastCol = true;
            _cols[_cols.Fixed - 1].Width = 30;

            switch (_currentlist)
            {
                case PickList.AdditionalCharges:
                    if (_cols["AdditionalCharge"].Width < 90) _cols["AdditionalCharge"].Width = 90; 
                    break;
                case PickList.BankMiscellaneous:
                    if (_cols["BankMiscellaneous"].Width < 150) _cols["BankMiscellaneous"].Width = 150;
                    break;
                case PickList.Currencies:
                    if (_cols["Currency"].Width < 80) _cols["Currency"].Width = 80; 
                    break;
                case PickList.Measurements:
                    if (_cols["Unit"].Width < 80) _cols["Unit"].Width = 80; 
                    break;
                case PickList.PartNames:
                    if (_cols["PartName"].Width < 90) _cols["PartName"].Width = 90;
                    break;
                case PickList.PaymentTerms:
                    if (_cols["PaymentTerm"].Width < 150) _cols["PaymentTerm"].Width = 150; 
                    break;
                case PickList.Signatories:
                    if (_cols["Signatory"].Width < 150) _cols["Signatory"].Width = 150; 
                    break;
                default: break;
            }
        }

        private void PickListDialog_FormClosing(object sender, FormClosingEventArgs e)
        { _cancelled = true; }

        private void PickListDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); InitializeListSelections();
            grdPickList.InitializeAppearance(); grdPickList.AttachMouseHoverPointer();
            Text = "Picklist Maintenance - " + GetPickListName(_currentlist);
        }

        private void PickListDialog_Shown(object sender, EventArgs e)
        { btnRefresh_Click(btnRefresh, new EventArgs()); }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Enabled) InitializeDisplay();
        }

        private void cboPickList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboPickList.Enabled) return;
            if (cboPickList.DataSource == null) return;
            if (cboPickList.SelectedIndex < 0) return;

            if (!_cancelled) _cancelled = true;

            _cancelled = false;
            _currentlist = (PickList)cboPickList.SelectedValue;
            btnRefresh_Click(btnRefresh, new EventArgs());
            Text = "Picklist Maintenance - " + GetPickListName(_currentlist);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Enabled) return;
            if (!grdPickList.Redraw) return;
            if (grdPickList.DataSource == null) return;

            DataTable _datasource = null;
            try { _datasource = (DataTable)grdPickList.DataSource; }
            catch { }

            if (_datasource != null)
            {
                if (grdPickList.Redraw) grdPickList.BeginUpdate();
                _datasource.Filter(txtSearch.Text);
                FormatGrid(); ResizeGrid();
                while (!grdPickList.Redraw) grdPickList.EndUpdate();
                EnableButtons(); DisplayInfo();
            }
        }

        private void btnNewAndEdit_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender.GetType() != typeof(ButtonItem)) return;
            ButtonItem _button = (ButtonItem)sender;
            if (!_button.Enabled) return;

            bool _isnew = (_button == btnNew);
            if (!_isnew)
            {
                if (!grdPickList.Redraw) return;
                if (grdPickList.DataSource == null) return;
                if (grdPickList.RowSel < grdPickList.Rows.Fixed) return;
            }

            Form _dialog = null;
        
            switch (_currentlist)
            {
                case PickList.AdditionalCharges:
                    if (_isnew) _dialog = new AdditionalChargeInfoDialog();
                    else
                    {
                        string _additionalcharge = grdPickList[grdPickList.RowSel, "AdditionalCharge"].ToString();
                        _dialog = new AdditionalChargeInfoDialog(_additionalcharge);
                    }

                    break;
                case PickList.Bank:
                    if (_isnew) _dialog = new BankInfoDialog();
                    else
                    {
                        string _bank = grdPickList[grdPickList.RowSel, "Bank"].ToString();
                        _dialog = new BankInfoDialog(_bank);
                    }

                    break;
                case PickList.BankMiscellaneous:
                    if (_isnew) _dialog = new BankMiscInfoDialog();
                    else
                    {
                        string _bankmisc = grdPickList[grdPickList.RowSel, "BankMiscellaneous"].ToString();
                        _dialog = new BankMiscInfoDialog(_bankmisc);
                    }

                    break;
                case PickList.Brands:
                    if (_isnew) _dialog = new BrandInfoDialog();
                    else
                    {
                        string _brand = grdPickList[grdPickList.RowSel, "Brand"].ToString();
                        _dialog = new BrandInfoDialog(_brand);
                    }

                    break;
                case PickList.Currencies:
                    if (_isnew) _dialog = new CurrencyInfoDialog();
                    else
                    {
                        string _currency = grdPickList[grdPickList.RowSel, "Currency"].ToString();
                        _dialog = new CurrencyInfoDialog(_currency);
                    }

                    break;
                case PickList.CurrencyDenominations:
                     if (_isnew) _dialog = new CurrencyDenominationInfoDialog();
                    else
                    {
                        long _id = VisualBasic.CLng(grdPickList[grdPickList.RowSel, "DetailId"]);
                        _dialog = new CurrencyDenominationInfoDialog(_id);
                    }

                    break;
                case PickList.CustomerGroups:
                    if (_isnew) _dialog = new CustomerGroupInfoDialog();
                    else
                    {
                        string _customergroup = grdPickList[grdPickList.RowSel, "CustomerGroup"].ToString();
                        _dialog = new CustomerGroupInfoDialog(_customergroup);
                    }

                    break;
                case PickList.Departments:
                    if (_isnew) _dialog = new DepartmentInfoDialog();
                    else
                    {
                        string _department = grdPickList[grdPickList.RowSel, "Department"].ToString();
                        _dialog = new DepartmentInfoDialog(_department);
                    }

                    break;
                case PickList.Locations:
                    if (_isnew) _dialog = new LocationInfoDialog();
                    else
                    {
                        string _locationcode = grdPickList[grdPickList.RowSel, "LocationCode"].ToString();
                        _dialog = new LocationInfoDialog(_locationcode);
                    }

                    break;
                case PickList.Measurements:
                    if (_isnew) _dialog = new MeasurementInfoDialog();
                    else
                    {
                        string _unit = grdPickList[grdPickList.RowSel, "Unit"].ToString();
                        _dialog = new MeasurementInfoDialog(_unit);
                    }

                    break;
                case PickList.Models:
                    if (_isnew) _dialog = new ModelInfoDialog();
                    else
                    {
                        string _modelcode = grdPickList[grdPickList.RowSel, "ModelCode"].ToString();
                        _dialog = new ModelInfoDialog(_modelcode);
                    }

                    break;
                case PickList.PartCategories:
                     if (_isnew) _dialog = new PartCategoryInfoDialog();
                    else
                    {
                        string _category = grdPickList[grdPickList.RowSel, "PartCategory"].ToString();
                        _dialog = new PartCategoryInfoDialog(_category);
                    }

                    break;
                case PickList.PartNames:
                    if (_isnew) _dialog = new PartNameInfoDialog();
                    else
                    {
                        string _partname = grdPickList[grdPickList.RowSel, "PartName"].ToString();
                        _dialog = new PartNameInfoDialog(_partname);
                    }

                    break;
                case PickList.PaymentTerms:
                     if (_isnew) _dialog = new PaymentTermInfoDialog();
                    else
                    {
                        string _paymentterm = grdPickList[grdPickList.RowSel, "PaymentTerm"].ToString();
                        _dialog = new PaymentTermInfoDialog(_paymentterm);
                    }

                    break;
                case PickList.Positions:
                      if (_isnew) _dialog = new PositionInfoDialog();
                    else
                    {
                        string _position = grdPickList[grdPickList.RowSel, "Position"].ToString();
                        _dialog = new PositionInfoDialog(_position);
                    }

                    break;
                case PickList.Signatories:
                     if (_isnew) _dialog = new SignatoryInfoDialog();
                    else
                    {
                        long _id = VisualBasic.CLng(grdPickList[grdPickList.RowSel, "DetailId"]);
                        _dialog = new SignatoryInfoDialog(_id);
                    }

                    break;
                default: break;
            }

            if (_dialog != null)
            {
                _dialog.ShowDialog();

                bool _withupdates = false;

                switch (_currentlist)
                {
                    case PickList.AdditionalCharges:
                        _withupdates = ((AdditionalChargeInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Bank:
                        _withupdates = ((BankInfoDialog)_dialog).WithUpdates; break;
                    case PickList.BankMiscellaneous:
                        _withupdates = ((BankMiscInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Brands:
                        _withupdates = ((BrandInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Currencies:
                        _withupdates = ((CurrencyInfoDialog)_dialog).WithUpdates; break;
                    case PickList.CurrencyDenominations:
                        _withupdates = ((CurrencyDenominationInfoDialog)_dialog).WithUpdates; break;
                    case PickList.CustomerGroups:
                        _withupdates = ((CustomerGroupInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Departments:
                        _withupdates = ((DepartmentInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Locations:
                        _withupdates = ((LocationInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Measurements:
                        _withupdates = ((MeasurementInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Models:
                        _withupdates = ((ModelInfoDialog)_dialog).WithUpdates; break;
                    case PickList.PartCategories:
                        _withupdates = ((PartCategoryInfoDialog)_dialog).WithUpdates; break;
                    case PickList.PartNames:
                        _withupdates = ((PartNameInfoDialog)_dialog).WithUpdates; break;
                    case PickList.PaymentTerms:
                        _withupdates = ((PaymentTermInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Positions:
                        _withupdates = ((PositionInfoDialog)_dialog).WithUpdates; break;
                    case PickList.Signatories:
                        _withupdates = ((SignatoryInfoDialog)_dialog).WithUpdates; break;
                    default: break;
                }

                if (_withupdates) InitializeDisplay();

                _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void grdPickList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!grdPickList.Redraw) return;
            if (grdPickList.DataSource == null) return;
            int _row = grdPickList.GetMouseOveredRow(e.X, e.Y);
            if (_row < grdPickList.Rows.Fixed) return;
            grdPickList.Row = _row; btnNewAndEdit_Click(btnEdit, new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!btnDelete.Enabled) return;
            if (!grdPickList.Redraw) return;
            if (grdPickList.DataSource == null) return;
            if (grdPickList.RowSel < grdPickList.Rows.Fixed) return;

            string _message = ""; string _valuename = "";
            object _value = null;

            switch (_currentlist)
            {
                case PickList.AdditionalCharges:
                    _value = grdPickList[grdPickList.RowSel, "AdditionalCharge"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "AdditionalCharge"].ToString();
                    break;
                case PickList.Bank:
                    _value = grdPickList[grdPickList.RowSel, "Bank"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Bank"].ToString();
                    break;
                case PickList.BankMiscellaneous:
                    _value = grdPickList[grdPickList.RowSel, "BankMiscellaneous"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "BankMiscellaneous"].ToString();
                    break;
                case PickList.Brands:
                    _value = grdPickList[grdPickList.RowSel, "Brand"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Brand"].ToString();
                    break;
                case PickList.Currencies:
                    _value = grdPickList[grdPickList.RowSel, "Currency"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Currency"].ToString() + " (" + grdPickList[grdPickList.RowSel, "Description"].ToString() + ")";
                    break;
                case PickList.CurrencyDenominations:
                     _value = grdPickList[grdPickList.RowSel, "DetailId"];
                    _valuename = VisualBasic.Format(VisualBasic.CDbl(grdPickList[grdPickList.RowSel, "Denomination"]), "N2") + grdPickList[grdPickList.RowSel, "Currency"].ToString();
                    break;
                case PickList.CustomerGroups:
                    _value = grdPickList[grdPickList.RowSel, "CustomerGroup"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "CustomerGroup"].ToString();
                    break;
                case PickList.Departments:
                    _value = grdPickList[grdPickList.RowSel, "Department"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Department"].ToString();
                    break;
                case PickList.Locations:
                    _value = grdPickList[grdPickList.RowSel, "LocationCode"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Location"].ToString();
                    break;
                case PickList.Measurements:
                    _value = grdPickList[grdPickList.RowSel, "Unit"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Unit"].ToString();
                    break;
                case PickList.Models:
                    _value = grdPickList[grdPickList.RowSel, "ModelCode"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Brand"].ToString() + " - " + grdPickList[grdPickList.RowSel, "Model"].ToString();
                    break;
                case PickList.PartCategories:
                     _value = grdPickList[grdPickList.RowSel, "PartCategory"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "PartCategory"].ToString();
                    break;
                case PickList.PartNames:
                    _value = grdPickList[grdPickList.RowSel, "PartName"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "PartName"].ToString();
                    break;
                case PickList.PaymentTerms:
                     _value = grdPickList[grdPickList.RowSel, "PaymentTerm"].ToString();
                     _valuename = grdPickList[grdPickList.RowSel, "PaymentTerm"].ToString();
                    break;
                case PickList.Positions:
                    _value = grdPickList[grdPickList.RowSel, "Position"].ToString();
                    _valuename = grdPickList[grdPickList.RowSel, "Position"].ToString();
                    break;
                case PickList.Signatories:
                    _value = grdPickList[grdPickList.RowSel, "DetailId"];
                    _valuename = grdPickList[grdPickList.RowSel, "Signatory"].ToString() + " (" + grdPickList[grdPickList.RowSel, "Role"].ToString() + ")";
                    break;
                default: break;
            }

            if (!string.IsNullOrEmpty(_valuename.RLTrim()))
            {
                switch (_currentlist)
                {
                    case PickList.Currencies:
                        if (!Materia.IsNullOrNothing(_value))
                        {
                            if (_value.ToString().ToUpper() == "USD")
                            {
                                MsgBoxEx.Shout("Cannot delete <font color=\"blue\">USD</font> from the currency list because it is the base currency.", "Default Currency"); return;
                            }
                        }
                        
                        break;
                    default: break;
                }

                _message = "Delete <font color=\"blue\">" + _valuename + "</font> from " + GetPickListName(_currentlist).ToLower() + " list?";
  
                if (MsgBoxEx.Ask(_message, "Delete " + GetPickListName(_currentlist)) != System.Windows.Forms.DialogResult.Yes) return;

                DataTable _datasource = (DataTable)grdPickList.DataSource;

                string _pk = ""; DataColumnCollection _cols = _datasource.Columns;
                
                for (int i = 0; i <= (_cols.Count - 1); i++)
                {
                    if (_cols[i].Unique)
                    {
                        _pk = _cols[i].ColumnName; break;
                    }
                }

                string _query = "DELETE FROM `" + _datasource.TableName + "` WHERE (`" + _pk + "` = '" + _value.ToString().ToSqlValidString() + "');";
                
                btnNew.Enabled = false; btnEdit.Enabled = false; btnDelete.Enabled = false;
                btnRefresh.Enabled = false; txtSearch.Enabled = false;

                IAsyncResult _delresult = Que.BeginExecution(SCMS.Connection, _query);
                
                while (!_cancelled &&
                       !_delresult.IsCompleted)
                { Thread.Sleep(1); Application.DoEvents(); }

                if (_cancelled)
                {
                    if (!_delresult.IsCompleted)
                    {
                        try { _delresult = null; }
                        catch { }
                        finally { Materia.RefreshAndManageCurrentProcess(); }
                    }

                    return;
                }
                else
                {
                    QueResult _result = Que.EndExecution(_delresult);

                    if (string.IsNullOrEmpty(_result.Error.RLTrim()))
                    {
                        Cursor = Cursors.WaitCursor;

                        IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Delete, "Delete " + _valuename + " from " + GetPickListName(_currentlist).ToLower() + " list.");
                        _logresult.WaitToFinish();

                        if (grdPickList.Redraw) grdPickList.BeginUpdate();

                        bool _isstring = (_datasource.Columns[_pk].DataType.Name == typeof(string).Name ||
                                          _datasource.Columns[_pk].DataType.Name == typeof(String).Name);

                        DataRow[] _rows = _datasource.Select("[" + _pk + "] = " + (_isstring? "'" + _value.ToString().ToSqlValidString(true) + "'" : _value.ToString()));
                        System.Collections.IEnumerator _enumerators = _rows.GetEnumerator();
                        while (_enumerators.MoveNext()) ((DataRow)_enumerators.Current).Delete();
                        _datasource.AcceptChanges();

                        DataTable _cachedtable = Cache.GetCachedTable(_datasource.TableName);
                        if (_cachedtable != null)
                        {
                            DataRow[] _delrows = _cachedtable.Select("[" + _pk + "] = " + (_isstring ? "'" + _value.ToString().ToSqlValidString(true) + "'" : _value.ToString()));

                            System.Collections.IEnumerator _delenumerators = _delrows.GetEnumerator();
                            while (_delenumerators.MoveNext()) ((DataRow)_delenumerators.Current).Delete();

                            _cachedtable.AcceptChanges(); Cache.Save();
                        }

                        FormatGrid(); ResizeGrid();
                        while (!grdPickList.Redraw) grdPickList.EndUpdate();
                        
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        if (_result.Error.ToLower().Contains("constraint")) MsgBoxEx.Shout("Cannot delete <font color=\"blue\">" + _valuename + "</font> from the " + GetPickListName(_currentlist).ToLower() + " list because it is used<br />into another transaction and / or record.", "Delete " + GetPickListName(_currentlist));
                        else
                        {
                            SCMS.LogError(this.GetType().Name, new Exception(_result.Error));
                            MsgBoxEx.Alert("Failed to delete <font color=\"blue\">" + _valuename + "</font> from the " + GetPickListName(_currentlist).ToLower() + " list.", "Delete " + GetPickListName(_currentlist));
                        }
                    }

                    _result.Dispose();
                }

                EnableButtons(); DisplayInfo();
            }
        }

    }
}


