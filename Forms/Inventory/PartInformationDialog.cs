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
            _partcode = ""; _isnew = false;
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

                            DataTable _models = null;

                            try { _models = (DataTable)cboModel.DataSource; }
                            catch { }

                            if (_models != null)
                            {
                                if (!Materia.IsNullOrNothing(_result.Brand))
                                {
                                    _models.DefaultView.RowFilter = "[Brand] LIKE '" + _result.Brand.ToSqlValidString(true) + "'";
                                    if (!Materia.IsNullOrNothing(_result.ModelCode)) cboModel.SelectedValue = _result.ModelCode;
                                    else cboModel.SelectedIndex = -1;

                                }
                                else _models.DefaultView.RowFilter = "";
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

                    InitializeUDFs();

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
            InitializeModels(); InitializePartStatus(); InitializeStockTypes();

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
                try { cboPartName.SelectedValue = _dialog.PartName; }
                catch { }
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


    }
}
