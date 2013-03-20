using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Development.Materia;
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

    /// <summary>
    /// Search dialog data source field enlisting method.
    /// </summary>
    public enum SearchFieldEnlisting
    {
        Auto = 1,
        CustomSource = 0
    }

    public partial class SearchDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of SearchDialog.
        /// </summary>
        public SearchDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs after the current search data source has been filtered thru the search box and column field.
        /// </summary>
        public event EventHandler AfterDataSourceFilter;

        protected virtual void OnAfterDataSourceFilter(EventArgs e)
        { if (AfterDataSourceFilter != null) AfterDataSourceFilter(this, e); }

        /// <summary>
        /// Occurs after the assigned data source has been loaded into the grid.
        /// </summary>
        public event EventHandler AfterDataSourceLoaded;

        protected virtual void OnAfterDataSourceLoaded(EventArgs e)
        { if (AfterDataSourceLoaded != null) AfterDataSourceLoaded(this, e); }

        /// <summary>
        /// Occurs after the field listing has been loaded.
        /// </summary>
        public event EventHandler AfterFieldListLoaded;

        protected virtual void OnAfterFieldListLoaded(EventArgs e)
        { if (AfterFieldListLoaded != null) AfterFieldListLoaded(this, e); }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the serach dialog's grid columns.
        /// </summary>
        public ColumnCollection Cols
        {
            get { return grdSearch.Cols; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DataTable _datasource = null;

        public DataTable DataSource
        {
            get { return _datasource; }
            set 
            {
                _datasource = value; InitializeDataSource(_datasource); 
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<string> _fieldcustomsource = null;

        /// <summary>
        /// Gets or sets the source of the column names to be displayed when FieldEnlisting is set to CustomSource.
        /// </summary>
        public List<string> FieldCustomSource
        {
            get { return _fieldcustomsource; }
            set 
            { 
                _fieldcustomsource = value;
                InitializeColumns();
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SearchFieldEnlisting _fieldenlisting = SearchFieldEnlisting.Auto;

        /// <summary>
        /// Gets or sets how the columns field will be enlisted.
        /// </summary>
        public SearchFieldEnlisting FieldEnlisting
        {
            get { return _fieldenlisting; }
            set 
            {
                _fieldenlisting = value; InitializeColumns(); 
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _multiselect = false;

        /// <summary>
        /// Gets or sets whether selection is in multi-selection mode or single-selection mode.
        /// </summary>
        public bool MultiSelect
        {
            get { return _multiselect; }
            set 
            { 
                _multiselect = value;
                InitializeDataSource(_datasource);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _multiselectmember = "";

        /// <summary>
        /// Gets or sets the multi-select datasource field member to where checkboxes will be put into.
        /// </summary>
        public string MultiSelectMember
        {
            get { return _multiselectmember; }
            set 
            { 
                _multiselectmember = value;
                if (_multiselectmember != _currentmultiselectmember)
                {
                    InitializeDataSource(_datasource);
                    _currentmultiselectmember = value;
                }
            }
        }

        /// <summary>
        /// Gets the collection of rows displayed in the dialog.
        /// </summary>
        public RowColCollection Rows
        {
            get { return grdSearch.Rows; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DataRow[] _selectedrows = null;

        /// <summary>
        /// Gets the rows selected by the user upon closing the dialog.
        /// </summary>
        public DataRow[] SelectedRows
        {
            get { return _selectedrows; }
        }

        /// <summary>
        /// Gets the styling appearance of the dialog's grid.
        /// </summary>
        public CellStyleCollection Styles
        {
            get { return grdSearch.Styles; }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _currentmultiselectmember = "";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isshown = false;

        #endregion

        #region Methods

        private void DisplayInfo()
        {
            if (grdSearch.DataSource == null) btnInfo.Text = " Ready";
            else
            {
                DataTable _table = null;

                try { _table = (DataTable)grdSearch.DataSource; }
                catch { }

                if (_table != null)
                {
                    DataTable _viewtable = _table.DefaultView.ToTable();
                    btnInfo.Text = " Displayed records : " + _viewtable.Rows.Count + " out of " + _table.Rows.Count + ".";
                    _viewtable.Dispose(); _viewtable = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
                else btnInfo.Text = " Ready";
            }
        }

        private void InitializeCheckBoxes()
        {
            if (_multiselect &&
                grdSearch.DataSource != null)
            {
                string _fieldname = _multiselectmember;
                if (string.IsNullOrEmpty(_fieldname.RLTrim()))
                {
                    for (int i = grdSearch.Cols.Fixed; i <= (grdSearch.Cols.Count - 1); i++)
                    {
                        if (grdSearch.Cols[i].Visible)
                        {
                            _fieldname = grdSearch.Cols[i].Name; break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(_fieldname.RLTrim()))
                {
                    grdSearch.AllowEditing = true;
                    for (int i = grdSearch.Cols.Fixed; i <= (grdSearch.Cols.Count - 1); i++) grdSearch.Cols[i].AllowEditing = (grdSearch.Cols[i].Name == _fieldname);

                    bool _selectall = true;

                    for (int i = grdSearch.Rows.Fixed; i <= (grdSearch.Rows.Count - 1); i++)
                    {
                        bool _selected = VisualBasic.CBool(grdSearch[i, "Select"]);
                        
                        if (_selected) grdSearch.SetCellCheck(i, grdSearch.Cols[_fieldname].Index, CheckEnum.Checked);
                        else grdSearch.SetCellCheck(i, grdSearch.Cols[_fieldname].Index, CheckEnum.Unchecked);

                        _selectall = _selectall && _selected;
                    }

                    if (_selectall) grdSearch.SetCellCheck(0, grdSearch.Cols[_fieldname].Index, CheckEnum.Checked);
                    else grdSearch.SetCellCheck(0, grdSearch.Cols[_fieldname].Index, CheckEnum.Unchecked);
                }
            }
        }

        private void InitializeColumns()
        {
            if (grdSearch.DataSource == null) return;

            cboSearch.Enabled = false;
            DataTable _table = new DataTable();
            _table.TableName = "columns";
            DataColumnCollection _cols = _table.Columns;

            DataColumn _pk = _cols.Add("Id", typeof(long));
            _cols.Add("Column", typeof(string));
            _cols.Add("Caption", typeof(string));

            _table.Constraints.Add("PK", _pk, true);
            _pk.AutoIncrement = true; _pk.AutoIncrementSeed = 1;
            _pk.AutoIncrementStep = 1;

            object[] _all = new object[_cols.Count];
            _all[_cols["Id"].Ordinal] = 0;
            _all[_cols["Column"].Ordinal] = "";
            _all[_cols["Caption"].Ordinal] = "[ All ]";

            _table.Rows.Add(_all);

            if (_fieldenlisting == SearchFieldEnlisting.Auto)
            {
                for (int i = grdSearch.Cols.Fixed; i <= (grdSearch.Cols.Count - 1); i++)
                {
                    if (grdSearch.Cols[i].Visible)
                    {
                        object[] _newrow = new object[_cols.Count];
                        _newrow[_cols["Column"].Ordinal] = grdSearch.Cols[i].Name;
                        _newrow[_cols["Caption"].Ordinal] = grdSearch.Cols[i].Caption;
                        _table.Rows.Add(_newrow);
                    }
                }
            }
            else
            {
                if (_fieldcustomsource != null)
                {
                    for (int i = 0; i <= (_fieldcustomsource.Count - 1); i++)
                    {
                        object[] _newrow = new object[_cols.Count];
                        _newrow[_cols["Column"].Ordinal] = _fieldcustomsource[i];
                        _newrow[_cols["Caption"].Ordinal] = _fieldcustomsource[i];
                        _table.Rows.Add(_newrow);
                    }
                }
                else
                {
                    for (int i = grdSearch.Cols.Fixed; i <= (grdSearch.Cols.Count - 1); i++)
                    {
                        if (grdSearch.Cols[i].Visible)
                        {
                            object[] _newrow = new object[_cols.Count];
                            _newrow[_cols["Column"].Ordinal] = grdSearch.Cols[i].Name;
                            _newrow[_cols["Caption"].Ordinal] = grdSearch.Cols[i].Caption;
                            _table.Rows.Add(_newrow);
                        }
                    }
                }
            }

            if (cboSearch.DataSource != null)
            {
                try { ((DataTable)cboSearch.DataSource).Dispose(); }
                catch { }
                finally { cboSearch.DataSource = null; }

                Materia.RefreshAndManageCurrentProcess();
            }

            cboSearch.DataSource = _table;
            cboSearch.DisplayMember = "Caption"; cboSearch.ValueMember = "Column";
            cboSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSearch.AutoCompleteSource = AutoCompleteSource.ListItems;

            try { cboSearch.SelectedIndex = 0; }
            catch { }

            cboSearch.Enabled = true;

            OnAfterFieldListLoaded(new EventArgs());
        }

        private void InitializeDataSource(DataTable table)
        {
            if (table != null)
            {
                DataTable _table = table.Clone();
                if (!_table.Columns.Contains("Select")) _table.Columns.Add("Select", typeof(int));

                int _selectvalue = 0;
                if (_multiselect) _selectvalue = 1;

                for (int i = 0; i <= (table.Rows.Count - 1); i++)
                {
                    object[] _values = new object[_table.Columns.Count];
                    for (int c = 0; c <= (table.Columns.Count - 1); c++) _values[c] = table.Rows[i][c];
                    _values[_table.Columns["Select"].Ordinal] = _selectvalue;
                    _table.Rows.Add(_values);
                }

                _table.AcceptChanges();

                if (grdSearch.Redraw) grdSearch.BeginUpdate();

                if (grdSearch.DataSource != null)
                {
                    try { ((DataTable)grdSearch.DataSource).Dispose(); }
                    catch { }
                    finally { grdSearch.DataSource = null; }
                    Materia.RefreshAndManageCurrentProcess();
                }

                grdSearch.DataSource = _table;
                _table.DefaultView.RowFilter = table.DefaultView.RowFilter;

                if (_multiselect) InitializeCheckBoxes();
                else grdSearch.AllowEditing = false;

                grdSearch.AutoSizeCols(); grdSearch.ExtendLastCol = true;
                OnAfterDataSourceLoaded(new EventArgs());
                InitializeColumns();

                while (!grdSearch.Redraw) grdSearch.EndUpdate();
                DisplayInfo();
            }
        }

        /// <summary>
        /// Sets the dialog to activate search selection for the given value.
        /// </summary>
        /// <param name="value"></param>
        public void Search(string value)
        {
            if (!txtSearch.Enabled) return;
            if (!grdSearch.Redraw) return;
            if (grdSearch.DataSource == null) return;

            if (txtSearch.Text != value) txtSearch.Text = value;

            DataTable _table = null;

            try { _table = (DataTable)grdSearch.DataSource; }
            catch { }

            if (_table != null)
            {
                if (grdSearch.Redraw) grdSearch.BeginUpdate();

                string _fieldname = "";

                if (cboSearch.SelectedIndex >= 0) _fieldname = cboSearch.SelectedValue.ToString();

                if (string.IsNullOrEmpty(_fieldname.RLTrim())) _table.Filter(txtSearch.Text);
                else _table.DefaultView.RowFilter = "(CONVERT([" + _fieldname + "], System.String) LIKE '%" + txtSearch.Text.ToSqlValidString(true).Replace(" ", "%') AND (CONVERT([" + _fieldname + "], System.String) LIKE '%") + "%')";

                if (_multiselect) InitializeCheckBoxes();
                else grdSearch.AllowEditing = false;

                grdSearch.AutoSizeCols(); grdSearch.ExtendLastCol = true;
                OnAfterDataSourceFilter(new EventArgs());

                while (!grdSearch.Redraw) grdSearch.EndUpdate();
                DisplayInfo();
            }
        }

        #endregion

        #region FormEvents

        private void SearchDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); grdSearch.InitializeAppearance();
            grdSearch.AttachMouseHoverPointer(); InitializeDataSource(_datasource);
        }

        private void SearchDialog_Shown(object sender, EventArgs e)
        { if (!_isshown) _isshown = true; }

        #endregion

        #region GridEvents

        private void grdSearch_CellChecked(object sender, RowColEventArgs e)
        {
            if (!grdSearch.Redraw) return;
            if (grdSearch.DataSource == null) return;
            if (grdSearch.RowSel < grdSearch.Rows.Fixed) return;

            bool _ischecked = (grdSearch.GetCellCheck(grdSearch.RowSel, e.Col) == CheckEnum.Checked);

            if (_ischecked) grdSearch[grdSearch.RowSel, "Select"] = 1;
            else grdSearch[grdSearch.RowSel, "Select"] = 0;
        }

        private void grdSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!grdSearch.Redraw) return;
            if (grdSearch.DataSource == null) return;
            if (_multiselect) return;

            int _row = grdSearch.GetMouseOveredRow(e.X, e.Y);
            if (_row < grdSearch.Rows.Fixed) return;
            grdSearch.Row = _row; grdSearch.RowSel = _row;
            btnOK_Click(btnOK, new EventArgs());
        }

        #endregion

        #region ControlEvents

        private void txtSearch_TextChanged(object sender, EventArgs e)
        { if (txtSearch.Enabled) Search(txtSearch.Text); }

        private void cboSearch_SelectedValueChanged(object sender, EventArgs e)
        { if (cboSearch.Enabled) Search(txtSearch.Text); }

  
        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!grdSearch.Redraw) return;
            if (grdSearch.DataSource == null) return;

            DataTable _table = null;

            try { _table = (DataTable)grdSearch.DataSource; }
            catch { }

            if (_table != null)
            {
                if (_multiselect) _selectedrows = _table.Select("[Select] = 1");
                else
                {
                    if (grdSearch.RowSel < grdSearch.Rows.Fixed) return;

                    string _pk = "";

                    for (int i = 0; i <= (_table.Columns.Count - 1); i++)
                    {
                        if (_table.Columns[i].Unique)
                        {
                            _pk = _table.Columns[i].ColumnName; break;
                        }
                    }

                    if (!string.IsNullOrEmpty(_pk.RLTrim()))
                    {
                        object _value = grdSearch[grdSearch.RowSel, _pk];
                        _selectedrows = _table.Select("CONVERT([" + _pk + "], System.String) LIKE '" + _value.ToString().ToSqlValidString(true) + "'");
                    }
                    else
                    {
                        string _filter = "";

                        for (int i = grdSearch.Cols.Fixed; i <= (grdSearch.Cols.Count - 1); i++)
                        {
                            Type _datatype = grdSearch.Cols[i].DataType;

                            if (_datatype != null)
                            {
                                if (_datatype.Name == typeof(string).Name ||
                                    _datatype.Name == typeof(String).Name) _filter += (!string.IsNullOrEmpty(_filter.RLTrim()) ? " AND\n" : "") + "[" + grdSearch.Cols[i].Name + "] = '" + grdSearch[grdSearch.RowSel, i].ToString().ToSqlValidString(true) + "'";
                                else if (_datatype.Name == typeof(byte).Name ||
                                         _datatype.Name == typeof(Byte).Name ||
                                         _datatype.Name == typeof(decimal).Name ||
                                         _datatype.Name == typeof(Decimal).Name ||
                                         _datatype.Name == typeof(double).Name ||
                                         _datatype.Name == typeof(Double).Name ||
                                         _datatype.Name == typeof(float).Name ||
                                         _datatype.Name == typeof(int).Name ||
                                         _datatype.Name == typeof(Int16).Name ||
                                         _datatype.Name == typeof(Int32).Name ||
                                         _datatype.Name == typeof(Int64).Name ||
                                         _datatype.Name == typeof(long).Name ||
                                         _datatype.Name == typeof(sbyte).Name ||
                                         _datatype.Name == typeof(SByte).Name ||
                                         _datatype.Name == typeof(short).Name ||
                                         _datatype.Name == typeof(Single).Name) _filter += (!string.IsNullOrEmpty(_filter.RLTrim()) ? " AND\n" : "") + "[" + grdSearch.Cols[i].Name + "] = " + grdSearch[grdSearch.RowSel, i].ToString();
                                else if (_datatype.Name == typeof(DateTime).Name) _filter += (!string.IsNullOrEmpty(_filter.RLTrim()) ? " AND\n" : "") + "[" + grdSearch.Cols[i].Name + "] = #" + VisualBasic.CDate(grdSearch[grdSearch.RowSel, i]).ToShortDateString() + "#";
                                else { }
                            }
                        }

                        _selectedrows = _table.Select(_filter);
                    }
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK; Close();
        }

        #endregion

    }
}
