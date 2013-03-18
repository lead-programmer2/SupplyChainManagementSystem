using C1.Win.C1FlexGrid;
using Development.Materia;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
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
    /// <summary>
    /// Customized data-sourced multi-columned capable and fully customizable drop down portion combo box.
    /// </summary>
    [Description("Customized data-sourced multi-columned capable and fully customizable drop down portion combo box."),
     DefaultEvent("SelectedValueChanged")]
    public class DataSourcedComboBox : TextBoxX
    {

        /// <summary>
        /// Creates a new instance of DataSourcedComboBox.
        /// </summary>
        public DataSourcedComboBox()
        {
            InitializeComponent();

            if (this.AutoCompleteCustomSource == null) base.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            base.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            base.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;

            this.ButtonCustom.Visible = true;
            this.ButtonCustom.Image = Properties.Resources.ArrowDown;

            _dropdown = new DataSourcedDropDown(this);
            _dropdown.RowSelected += new EventHandler(DropDown_RowSelected);

            _popup = new Popup(_dropdown);
            _popup.Closed += new ToolStripDropDownClosedEventHandler(Popup_Closed);

        }

        #region Events

        /// <summary>
        /// Occurs when the AutoSizeDropDown property value is changed.
        /// </summary>
        [Description("Occurs when the AutoSizeDropDown property value is changed.")]
        public event EventHandler AutoSizeDropDownChanged;

        protected virtual void OnAutoSizeDropDownChanged(EventArgs e)
        {
            if (AutoSizeDropDownChanged != null) AutoSizeDropDownChanged(this, e);
        }

        /// <summary>
        /// Occurs when the DataSource property value is changed.
        /// </summary>
        [Description("Occurs when the DataSource property value is changed.")]
        public event EventHandler DataSourceChanged;

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (DataSourceChanged != null) DataSourceChanged(this, e);
        }

        /// <summary>
        /// Occurs when the DisplayMember property value is changed.
        /// </summary>
        [Description("Occurs when the DisplayMember property value is changed.")]
        public event EventHandler DisplayMemberChanged;

        protected virtual void OnDisplayMemberChanged(EventArgs e)
        {
            if (DisplayMemberChanged != null) DisplayMemberChanged(this, e);
        }

        /// <summary>
        /// Occurs when the drop down portion of the combo box is closed after being shown on the user's screen.
        /// </summary>
        [Description("Occurs when the drop down portion of the combo box is closed after being shown on the user's screen.")]
        public event EventHandler DropDownClosed;

        protected virtual void OnDropDownClosed(EventArgs e)
        {
            if (DropDownClosed != null) DropDownClosed(this, e);
        }

        /// <summary>
        /// Occurs when the drop down portion of the combo box is shown on the user's screen.
        /// </summary>
        [Description("Occurs when the drop down portion of the combo box is shown on the user's screen.")]
        public event EventHandler DropDownOpened;

        protected virtual void OnDropDownOpened(EventArgs e)
        {
            if (DropDownOpened != null) DropDownOpened(this, e);
        }

        /// <summary>
        /// Occurs when the FixedDropDownSize property value is changed.
        /// </summary>
        private event EventHandler FixedDropDownSizeChanged;

        protected virtual void OnFixedDropDownSizeChanged(EventArgs e)
        {
            if (FixedDropDownSizeChanged != null) FixedDropDownSizeChanged(this, e);
        }

        /// <summary>
        /// Occurs when the SelectedIndex property value is changed.
        /// </summary>
        [Description("Occurs when the SelectedIndex property value is changed.")]
        public event EventHandler SelectedIndexChanged;

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null) SelectedIndexChanged(this, e);
        }

        /// <summary>
        /// Occurs when the SelectedValue property value is changed.
        /// </summary>
        [Description("Occurs when the SelectedValue property value is changed.")]
        public event EventHandler SelectedValueChanged;

        protected virtual void OnSelectedValueChanged(EventArgs e)
        {
            if (SelectedValueChanged != null) SelectedValueChanged(this, e);
        }

        /// <summary>
        /// Occurs when the ValueMember property value is changed.
        /// </summary>
        [Description("Occurs when the ValueMember property value is changed.")]
        public event EventHandler ValueMemberChanged;

        protected virtual void OnValueMemberChanged(EventArgs e)
        {
            if (ValueMemberChanged != null) ValueMemberChanged(this, e);
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _detectinput = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DataSourcedDropDown _dropdown = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Popup _popup = null;

        #endregion

        #region Properties

        [Browsable(false), EditorBrowsable( EditorBrowsableState.Never)]
        public new AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return base.AutoCompleteCustomSource; }
            set { base.AutoCompleteCustomSource = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteMode AutoCompleteMode
        {
            get { return base.AutoCompleteMode; }
            set { base.AutoCompleteMode = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteSource AutoCompleteSource
        {
            get { return base.AutoCompleteSource; }
            set { base.AutoCompleteSource = value; }
        }

        [DebuggerBrowsable (DebuggerBrowsableState.Never)]
        private bool _autosizeropdown = true;

        /// <summary>
        /// Gets or sets whether the drop down portion of the combo box will be displayed according to each of it's column contents or not.
        /// </summary>
        [Description("Gets or sets whether the drop down portion of the combo box will be displayed according to each of it's column contents or not."), 
         DefaultValue(typeof(bool), "True")]
        public bool AutoSizeDropDown
        {
            get { return _autosizeropdown; }
            set
            {
                _autosizeropdown = value;
                OnAutoSizeDropDownChanged(new EventArgs());
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new InputButtonSettings ButtonCustom
        {
            get { return base.ButtonCustom; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new InputButtonSettings ButtonCustom2
        {
            get { return base.ButtonCustom2; }
        }

        /// <summary>
        /// Gets the collection of columns in the drop down portion's grid.
        /// </summary>
        [Description("Gets the collection of columns in the drop down portion's grid.")]
        public ColumnCollection Cols
        {
            get { return _dropdown.Grid.Cols; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DataTable _datasource = null;

        /// <summary>
        /// Gets or sets the data source for this ComboBox.
        /// </summary>
        [Description("Gets or sets the data source for this ComboBox.")]
        public DataTable DataSource
        {
            get { return _datasource; }
            set
            {
                if (_datasource != null)
                {
                    try { _datasource.Dispose(); }
                    catch { }
                    finally { _datasource = null; }

                    Materia.RefreshAndManageCurrentProcess();
                }

                C1FlexGrid _grid = _dropdown.Grid;

                if (_grid != null)
                {
                    if (_grid.DataSource != null)
                    {
                        try { _grid.DataSource = null; }
                        catch { }
                        finally { Materia.RefreshAndManageCurrentProcess(); }
                    }

                    _detectinput = false;
                    _datasource = value; Text = ""; _detectinput = true;
                    _selectedindex = -1; _selectedvalue = null;
                    InitializeAutoCompleteSource();

                    if (_grid.Redraw) _grid.BeginUpdate();
                    _grid.DataSource = _datasource;

                    if (_datasource != null)
                    {
                        _datasource.DefaultView.ListChanged += new ListChangedEventHandler(DataSource_ListChanged);
                        _grid.Rows[_grid.Rows.Fixed - 1].Visible = true;
                        _grid.Cols[_grid.Cols.Fixed - 1].Visible = false;
                        _grid.FormatColumns(); _grid.AutoSizeCols();
                        _grid.ExtendLastCol = true;
                    }
                    else _grid.ClearRowsAndColumns();

                    while (!_grid.Redraw) _grid.EndUpdate();

                    OnDataSourceChanged(new EventArgs());
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _displaymember = "";

        /// <summary>
        /// Gets or sets the property that determines the data source field to display by the ComboBox.
        /// </summary>
        [Description("Gets or sets the property that determines the data source field to display by the ComboBox.")]
        public string DisplayMember
        {
            get { return _displaymember; }
            set
            {
                _displaymember = value;
                OnDisplayMemberChanged(new EventArgs());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _droppeddown = false;

        /// <summary>
        /// Gets whether the dropdown portion of the combo box is currently shown on the user's screen.
        /// </summary>
        [Browsable(false)]
        public bool DroppedDown
        {
            get { return _droppeddown; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Size _fixeddropdownsize = new Size(0, 0);

        /// <summary>
        /// Gets or sets the fixed size for the drop down portion of the combo box.
        /// </summary>
        [Description("Gets or sets the fixed size for the drop down portion of the combo box."),
         DefaultValue(typeof(Size), "0, 0")]
        public Size FixedDropDownSize
        {
            get { return _fixeddropdownsize; }
            set 
            { 
                _fixeddropdownsize = value;
                OnFixedDropDownSizeChanged(new EventArgs());
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string[] Lines
        {
            get { return base.Lines; }
            set { base.Lines = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new int MaxLength
        {
            get { return base.MaxLength; }
            set { base.MaxLength = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new char PasswordChar
        {
            get { return base.PasswordChar; }
            set { base.PasswordChar = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ScrollBars ScrollBars
        {
            get { return base.ScrollBars; }
            set { base.ScrollBars = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _selectedindex = -1;

        /// <summary>
        /// Gets or sets the index specifying the selected item.
        /// </summary>
        [Description("Gets or sets the index specifying the selected item."), Browsable(false)]
        public int SelectedIndex
        {
            get { return _selectedindex; }
            set
            {
                if (value >= 0)
                {
                    if (DataSource == null) throw new NullReferenceException("Index cannot be set. No data source has been specified yet.");
                    else
                    {
                        DataTable _viewtable = DataSource.DefaultView.ToTable();
                        if (_viewtable.Rows.Count > value)
                        {
                            _selectedindex = value; OnSelectedIndexChanged(new EventArgs());

                            DataRow _row = _viewtable.Rows[value];

                            if (!string.IsNullOrEmpty(ValueMember.RLTrim()))
                            {
                                if (_viewtable.Columns.Contains(ValueMember))
                                {
                                    _selectedvalue = _row[ValueMember]; OnSelectedValueChanged(new EventArgs());
                                }
                                else
                                {
                                    _selectedvalue = null; OnSelectedValueChanged(new EventArgs());
                                }
                            }
                            else
                            {
                                _selectedvalue = null; OnSelectedValueChanged(new EventArgs());
                            }

                            _detectinput = false;

                            if (!String.IsNullOrEmpty(DisplayMember.RLTrim()))
                            {
                                if (_viewtable.Columns.Contains(DisplayMember))
                                {
                                    if (!Materia.IsNullOrNothing(_row[DisplayMember])) Text = _row[DisplayMember].ToString();
                                    else Text = "";
                                }
                                else Text = "";
                            }
                            else Text = "";

                            _detectinput = true;
                        }
                        else throw new IndexOutOfRangeException("Index out of range or less than the size of the collection.");
                        _viewtable.Dispose(); _viewtable = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }
                else
                {
                    _detectinput = false;
                    _selectedindex = -1; OnSelectedIndexChanged(new EventArgs());
                    _selectedvalue = null; OnSelectedValueChanged(new EventArgs());
                    Text = ""; _detectinput = true;
                }
            }
        }

        /// <summary>
        /// Gets the currently selected drop down grid row.
        /// </summary>
        [Browsable(false)]
        public Row SelectedRow
        {
            get
            {
                Row _row = null;

                if (SelectedIndex >= 0)
                {
                    if (_dropdown != null)
                    {
                        try { _row = _dropdown.Grid.Rows[SelectedIndex + _dropdown.Grid.Rows.Fixed]; }
                        catch { _row = null; }
                    }
                }

                return _row;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object _selectedvalue = null;

        /// <summary>
        /// Gets or sets the value of the member property specified by the ValueMember property.
        /// </summary>
        [Browsable(false)]
        public object SelectedValue
        {
            get { return _selectedvalue; }
            set
            {
                if (!Materia.IsNullOrNothing(value))
                {
                    if (DataSource != null)
                    {
                        if (!String.IsNullOrEmpty(ValueMember.RLTrim()))
                        {
                            if (DataSource.Columns.Contains(ValueMember))
                            {
                                DataTable _viewtable = DataSource.DefaultView.ToTable();
                                DataRow[] _rows = _viewtable.Select("CONVERT([" + ValueMember + "], System.String) LIKE '" + value.ToString().ToSqlValidString(true) + "'");
                                if (_rows.Length <= 0)
                                {
                                    _detectinput = false; _selectedindex = -1; OnSelectedIndexChanged(new EventArgs());
                                    Text = ""; _detectinput = true;
                                    _selectedvalue = value; OnSelectedValueChanged(new EventArgs());
                                }
                                else
                                {
                                    C1FlexGrid _grid = _dropdown.Grid;
                                    int _index = _grid.FindRow(value, _grid.Rows.Fixed, _grid.Cols.Fixed, false) - 1;
                                    _selectedindex = _index < 0 ? -1 : _index; OnSelectedIndexChanged(new EventArgs());
                                    _detectinput = false;

                                    if (!String.IsNullOrEmpty(DisplayMember.RLTrim()))
                                    {
                                        if (_viewtable.Columns.Contains(DisplayMember))
                                        {
                                            DataRow _row = _rows[0];
                                            if (!Materia.IsNullOrNothing(_row[DisplayMember])) Text = _row[DisplayMember].ToString();
                                            else Text = "";

                                            _selectedvalue = value; OnSelectedValueChanged(new EventArgs());
                                        }
                                        else
                                        {
                                            Text = ""; _selectedvalue = null; OnSelectedValueChanged(new EventArgs());
                                        }
                                    }
                                    else
                                    {
                                        Text = ""; _selectedvalue = null; OnSelectedValueChanged(new EventArgs());
                                    }

                                    _detectinput = true;
                                }
                            }
                            else throw new NullReferenceException("Cannot determine value field.");
                        }
                        else throw new NullReferenceException("Cannot determine value field.");
                    }
                    else throw new NullReferenceException("Source cannot be found and so as the value.");
                }
                else
                {
                    _detectinput = false; _selectedindex = -1; OnSelectedIndexChanged(new EventArgs());
                    Text = ""; _detectinput = true;
                    _selectedvalue = value; OnSelectedValueChanged(new EventArgs());
                }
            }
        }

        /// <summary>
        /// Gets the collection of cell styles defined in the drop down portion's grid.
        /// </summary>
        [Description("Gets the collection of cell styles defined in the drop down portion's grid.")]
        public CellStyleCollection Styles
        {
            get { return _dropdown.Grid.Styles; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseSystemPasswordChar
        {
            get { return base.UseSystemPasswordChar; }
            set { base.UseSystemPasswordChar = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _valuemember = "";

        /// <summary>
        /// Gets or sets the property to use as the actual value for the items in the ComboBox.
        /// </summary>
        [Description("Gets or sets the property to use as the actual value for the items in the ComboBox.")]
        public string ValueMember
        {
            get { return _valuemember; }
            set
            {
                bool _changed = (_selectedindex != -1);
                _selectedindex = -1;
                if (_changed) OnSelectedIndexChanged(new EventArgs());

                _changed = (_selectedvalue != null);
                _selectedvalue = null;
                if (_changed) OnSelectedValueChanged(new EventArgs());

                _valuemember = value; OnValueMemberChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets the value that determines the overall appearance of the drop down portion's grid.
        /// </summary>
        [Description("Gets or sets the value that determines the overall appearance of the drop down portion's grid.")]
        public VisualStyle VisualStyle
        {
            get { return _dropdown.Grid.VisualStyle; }
            set { _dropdown.Grid.VisualStyle = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool WordWrap
        {
            get { return base.WordWrap; }
            set { base.WordWrap = value; }
        }

        #endregion

        #region Methods

        private void InitializeAutoCompleteSource()
        {
            if (base.AutoCompleteCustomSource != null)
            {
                AutoCompleteStringCollection _customsource = base.AutoCompleteCustomSource;
                if (_customsource == null) _customsource = new AutoCompleteStringCollection();

                _customsource.Clear();
                if (DataSource != null)
                {
                    if (!String.IsNullOrEmpty(DisplayMember.RLTrim()))
                    {
                        if (DataSource.Columns.Contains(DisplayMember))
                        {
                            DataView _view = DataSource.DefaultView;
                            DataTable _table = _view.ToTable();
                            _table.DefaultView.Sort = "[" + DisplayMember + "]";
                            DataView _viewsorted = _table.DefaultView;
                            DataTable _tablesorted = _viewsorted.ToTable();

                            foreach (DataRow rw in _tablesorted.Rows)
                            {
                                string _text = "";
                                if (!Materia.IsNullOrNothing(rw[DisplayMember]))  _text = rw[DisplayMember].ToString();
                                if (!_customsource.Contains(_text)) _customsource.Add(_text);
                            }

                            _tablesorted.Dispose();  _table.Dispose();
                            _tablesorted = null; _table = null;
                            Materia.RefreshAndManageCurrentProcess();
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DataSourcedComboBox
            // 
            // 
            // 
            // 
            this.Border.Class = "";
            this.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ButtonCustomClick += new System.EventHandler(this.DataSourcedComboBox_ButtonCustomClick);
            this.SizeChanged += new System.EventHandler(this.DataSourcedComboBox_SizeChanged);
            this.TextChanged += new System.EventHandler(this.DataSourcedComboBox_TextChanged);
            this.Disposed += new System.EventHandler(this.DataSourcedComboBox_Disposed);
            this.ResumeLayout(false);

        }

        private void DataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitializeAutoCompleteSource();

            bool _changed = false;
            _changed = (_selectedindex != -1);
            _selectedindex = -1;
            if (_changed) OnSelectedIndexChanged(new EventArgs());

            _changed = (_selectedvalue != null);
            _selectedvalue = null;
            if (_changed) OnSelectedValueChanged(new EventArgs());

            _detectinput = false;  Text = ""; _detectinput = true;
        }

        private void DropDown_RowSelected(object sender, EventArgs e)
        {
            if (_popup != null) _popup.Close();
        }

        private void Popup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (DroppedDown)
            {
                base.ButtonCustom.Enabled = true;
                _droppeddown = false; OnDropDownClosed(new EventArgs());
            }
        }

        private void DataSourcedComboBox_ButtonCustomClick(object sender, EventArgs e)
        {
            if (!base.ButtonCustom.Enabled) return;
            if (ReadOnly) return;
            if (!DesignMode)
            {
                if (!DroppedDown)
                {
                    base.ButtonCustom.Enabled = false; _droppeddown = true;
                    int _pwidth = Size.Width; int _pheight = Size.Height;

                    if (AutoSizeDropDown)
                    {
                        if (DataSource != null)
                        {
                            C1FlexGrid _grid = _dropdown.Grid; int _colwidth = 0;

                            for (int i = _grid.Cols.Fixed; i <= (_grid.Cols.Count - 1); i++)
                            {
                                if (_grid.Cols[i].Visible) _colwidth += _grid.Cols[i].WidthDisplay;
                            }
                            _colwidth += 21;

                            if (_pwidth < _colwidth) _pwidth = _colwidth;

                            DataTable _viewtable = DataSource.DefaultView.ToTable();
                            int _maxheight = 350;
                            int _estimatedheight = (_viewtable.Rows.Count * 23) + 22;
                            if (_estimatedheight > _maxheight) _pheight = _maxheight;
                            else _pheight = _estimatedheight;
                        }
                        else
                        {
                            if (FixedDropDownSize.Height > 0 ||
                                FixedDropDownSize.Width > 0)
                            {
                                if (_pwidth < FixedDropDownSize.Width) _pwidth = FixedDropDownSize.Width;
                                if (_pheight < FixedDropDownSize.Height) _pheight = FixedDropDownSize.Height;
                            }
                        }
                    }
                    else
                    {
                        if (FixedDropDownSize.Height > 0 ||
                                FixedDropDownSize.Width > 0)
                        {
                            if (_pwidth < FixedDropDownSize.Width) _pwidth = FixedDropDownSize.Width;
                            if (_pheight < FixedDropDownSize.Height) _pheight = FixedDropDownSize.Height;
                        }
                    }

                    _popup.Size = new System.Drawing.Size(_pwidth, _pheight);

                    if (DataSource != null)
                    {
                        C1FlexGrid _grid = _dropdown.Grid;
                        if (SelectedIndex >= 0)
                        {
                            if (((_grid.Rows.Count - _grid.Rows.Fixed) - 1) >= SelectedIndex)
                            {
                                _grid.Row = SelectedIndex + _grid.Rows.Fixed;
                                _grid.RowSel = SelectedIndex + _grid.Rows.Fixed;
                            }
                            else
                            {
                                _grid.Row = _grid.Rows.Fixed - 1;
                                _grid.RowSel = _grid.Rows.Fixed - 1;
                            }
                        }
                        else
                        {
                            _grid.Row = _grid.Rows.Fixed - 1;
                            _grid.RowSel = _grid.Rows.Fixed - 1;
                        }
                    }

                    _popup.Show(this); OnDropDownOpened(new EventArgs());
                }
            }
        }

        private void DataSourcedComboBox_Disposed(object sender, EventArgs e)
        {
            if (_dropdown != null)
            {
                try { _dropdown.Dispose(); }
                catch { }
                finally { _dropdown = null; }
            }

            Materia.RefreshAndManageCurrentProcess();
        }

        private void DataSourcedComboBox_SizeChanged(object sender, EventArgs e)
        {
            if (_popup != null) _popup.Size = new Size(Size.Width, _popup.Size.Height);
        }

        private void DataSourcedComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!_detectinput) return;
            if (DataSource != null)
            {
                if (!string.IsNullOrEmpty(DisplayMember.RLTrim()))
                {
                    if (DataSource.Columns.Contains(DisplayMember))
                    {
                        DataTable _viewtable = DataSource.DefaultView.ToTable();
                        DataRow[] rws = _viewtable.Select("CONVERT([" + DisplayMember + "], System.String) LIKE '" + Text.ToSqlValidString(true) + "'");
                        if (rws.Length > 0)
                        {
                            if (!string.IsNullOrEmpty(ValueMember.RLTrim()))
                            {
                                if (DataSource.Columns.Contains(ValueMember))
                                {
                                    C1FlexGrid _grid = _dropdown.Grid;
                                    int _index = _grid.FindRow(rws[0][ValueMember], _grid.Rows.Fixed, _grid.Cols.Fixed, false) - 1;
                                    _selectedindex = (_index < 0 ? -1 : _index);
                                    OnSelectedIndexChanged(new EventArgs());
                                    _selectedvalue = rws[0][ValueMember];
                                    OnSelectedValueChanged(new EventArgs());
                                }
                                else
                                {
                                    bool _changed = false;
                                    _changed = (_selectedindex != -1);
                                    _selectedindex = -1;
                                    if (_changed) OnSelectedIndexChanged(new EventArgs());

                                    _changed = (_selectedvalue != null);
                                    _selectedvalue = null;
                                    if (_changed) OnSelectedValueChanged(new EventArgs());
                                }
                            }
                            else
                            {
                                bool _changed = false;
                                _changed = (_selectedindex != -1);
                                _selectedindex = -1;
                                if (_changed) OnSelectedIndexChanged(new EventArgs());

                                _changed = (_selectedvalue != null);
                                _selectedvalue = null;
                                if (_changed) OnSelectedValueChanged(new EventArgs());
                            }
                        }
                        else
                        {
                            bool _changed = false;
                            _changed = (_selectedindex != -1);
                            _selectedindex = -1;
                            if (_changed) OnSelectedIndexChanged(new EventArgs());

                            _changed = (_selectedvalue != null);
                            _selectedvalue = null;
                            if (_changed)OnSelectedValueChanged(new EventArgs());
                        }
                        _viewtable.Dispose(); _viewtable = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                    else
                    {
                        bool _changed = false;
                        _changed = (_selectedindex != -1);
                        _selectedindex = -1;
                        if (_changed) OnSelectedIndexChanged(new EventArgs());

                        _changed = (_selectedvalue != null);
                        _selectedvalue = null;
                        if (_changed) OnSelectedValueChanged(new EventArgs());
                    }
                }
                else
                {
                    bool _changed = false;
                    _changed = (_selectedindex != -1);
                    _selectedindex = -1;
                    if (_changed) OnSelectedIndexChanged(new EventArgs());

                    _changed = (_selectedvalue != null);
                    _selectedvalue = null;
                    if (_changed) OnSelectedValueChanged(new EventArgs());
                }
            }
            else
            {
                bool _changed = false;
                _changed = (_selectedindex != -1);
                _selectedindex = -1;
                if (_changed) OnSelectedIndexChanged(new EventArgs());

                _changed = (_selectedvalue != null);
                _selectedvalue = null;
                if (_changed) OnSelectedValueChanged(new EventArgs());
            }
        }

        #endregion

    }
}

