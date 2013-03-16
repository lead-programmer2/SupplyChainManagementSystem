using C1.Win.C1FlexGrid;
using Development.Materia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Dropdown portion for DataSourcedComboBox
    /// </summary>
    [ToolboxItem(false)]
    public partial class DataSourcedDropDown : UserControl
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of DataSourcedDropDown.
        /// </summary>
        /// <param name="owner"></param>
        public DataSourcedDropDown(DataSourcedComboBox owner)
        {
            InitializeComponent();

            this.Disposed += new EventHandler(DataSourceDropDown_Disposed);
            _combobox = owner; ;
            _grid.InitializeAppearance();
            _grid.Dock = DockStyle.Fill;
            _grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            _grid.SelectionMode = SelectionModeEnum.Row;
            _grid.AllowDragging = AllowDraggingEnum.None;
            _grid.AllowAddNew = false; _grid.AllowDelete = false;
            _grid.AllowEditing = false; _grid.AllowFiltering = false;
            _grid.Visible = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a valid row of data is selected by the user.
        /// </summary>
        public event EventHandler RowSelected;

        protected virtual void OnRowSelected(EventArgs e)
        {
            if (RowSelected != null) RowSelected(this, e);
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DataSourcedComboBox _combobox = null;

        /// <summary>
        /// Gets the owner combo box for this drop down portion.
        /// </summary>
        public DataSourcedComboBox ComboBox
        {
            get { return _combobox; }
        }

        /// <summary>
        /// Gets the display grid for this drop down.
        /// </summary>
        public C1FlexGrid Grid
        {
            get { return _grid; }
        }

        #endregion

        #region Methods

        private void DataSourceDropDown_Disposed(object sender, EventArgs e)
        {
            if (_grid != null)
            {
                try { _grid.Dispose(); }
                catch { }
                finally { _grid = null; }
            }

            Materia.RefreshAndManageCurrentProcess();
        }

        private void _grid_AfterSort(object sender, SortColEventArgs e)
        {
            if (_grid.DataSource == null) return;
            if (!_grid.Redraw) return;
            if (_grid.RowSel < _grid.Rows.Fixed) return;
            if (_combobox != null) _combobox.SelectedIndex = (_grid.RowSel - _grid.Rows.Fixed); 
        }

        private void _grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (_grid.DataSource == null) return;
            if (!_grid.Redraw) return;
            int _row = _grid.GetMouseOveredRow(e.X, e.Y);
            if (_row < _grid.Rows.Fixed) return;
            if (_combobox != null) _combobox.SelectedIndex = (_row - _grid.Rows.Fixed);
            OnRowSelected(new EventArgs());
        }

        private void _grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (_grid.DataSource == null) return;
            if (!_grid.Redraw) return;
            int _row = _grid.GetMouseOveredRow(e.X, e.Y);
            if (_row >= _grid.Rows.Fixed) _grid.Row = _row;
        }

        #endregion

    }
}
