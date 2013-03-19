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
    public partial class PartSupersessionSelectionDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of PartSupersessionSelectionDialog.
        /// </summary>
        public PartSupersessionSelectionDialog(PartInfo superseded)
        {
            InitializeComponent();

            _supersededpart = superseded;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PartInfo _selectedpart = null;

        /// <summary>
        /// Gets the selected part's information.
        /// </summary>
        public PartInfo SelectedPartInfo
        {
            get { return _selectedpart; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PartInfo _supersededpart = null;

        /// <summary>
        /// Gets the superseded part's information.
        /// </summary>
        public PartInfo SupersededPart
        {
            get { return _supersededpart; }
        }

        #endregion

        #region Methods

        private void InitializeParts()
        {
            DataTable _parts = Cache.GetCachedTable("parts");
            DataTable _models = Cache.GetCachedTable("models");

            if (_parts != null &&
                _models != null)
            {
                string _partname = ""; string _partcode = "";

                if (_supersededpart != null)
                {
                    _partname = _supersededpart.PartName; _partcode = _supersededpart.PartCode;
                }

                DataTable _supers = _parts.Replicate();

                var _query = from _part in _parts.AsEnumerable()
                             join _model in _models.AsEnumerable() on _part.Field<string>("ModelCode") equals _model.Field<string>("ModelCode") into _m
                             join _super in _supers.AsEnumerable() on _part.Field<string>("PartCode") equals _super.Field<string>("SuperPartCode") into _s
                             where _part.Field<string>("PartName") == _partname &&
                                   _part.Field<string>("SuperPartCode") == "" &&
                                   _part.Field<string>("PartCode") != _partcode
                             from _model in _m.DefaultIfEmpty(_models.NewRow())
                             from _super in _s.DefaultIfEmpty(_supers.NewRow())
                             group _super by new
                             {
                                 PartCode = _part.Field<string>("PartCode"),
                                 PartNo = _part.Field<string>("PartNo"),
                                 PartName = _part.Field<string>("PartName"),
                                 Description = _part.Field<string>("Description"),
                                 Brand = _part.Field<string>("Brand"),
                                 Model = _model.Field<string>("Model")
                             } into _group
                             select new
                             {
                                 PartCode = _group.Key.PartCode,
                                 PartNo = _group.Key.PartNo,
                                 PartName = _group.Key.PartName,
                                 Description = _group.Key.Description,
                                 Brand = _group.Key.Brand,
                                 Model = _group.Key.Model,
                                 Count = _group.Sum(_super => (string.IsNullOrEmpty(_super.Field<string>("PartCode")) ? 0 : 1))
                             };

                DataTable _datasource = new DataTable();
                DataColumnCollection _sourcecols = _datasource.Columns;

                DataColumn _pk = _sourcecols.Add("PartCode", typeof(string));
                _sourcecols.Add("PartNo", typeof(string));
                _sourcecols.Add("PartName", typeof(string));
                _sourcecols.Add("Description", typeof(string));
                _sourcecols.Add("Brand", typeof(string));
                _sourcecols.Add("Model", typeof(string));

                try
                {
                    foreach (var _row in _query)
                    {
                        if (_row.Count <= 0) _datasource.Rows.Add(new object[] {
                                                                  _row.PartCode, _row.PartNo, _row.PartName,
                                                                  _row.Description, _row.Brand, _row.Model });
                    }

                    _datasource.AcceptChanges();
                }
                catch { }

                cboPartNo.Enabled = false;
                if (cboPartNo.DataSource != null)
                {
                    try { ((DataTable)cboPartNo.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        cboPartNo.DataSource = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                cboPartNo.DisplayMember = "PartNo"; cboPartNo.ValueMember = "PartCode";
                cboPartNo.DataSource = _datasource;
             
                ColumnCollection _cols = cboPartNo.Cols;
                _cols["PartCode"].Visible = false;
                _cols["PartNo"].Caption = "Part No.";
                _cols["PartName"].Caption = "Part Name";

                try { cboPartNo.SelectedIndex = -1; }
                catch { }

                DataTable _viewtable = _datasource.DefaultView.ToTable();
                cboPartNo.Enabled = (_viewtable.Rows.Count > 0);
                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

        #region FormEvents

        private void PartSupersessionSelectionDialog_Load(object sender, EventArgs e)
        {
            this.ManageOnDispose(); SCMS.Validators.Add(this);
            InitializeParts(); btnAdd.Enabled = false;

            if (_supersededpart != null) lblHeader.Text = "Add part supersession for : " + _supersededpart.PartNo + " - " + _supersededpart.PartName + ".";
        }

        #endregion

        #region ControlEvents

        private void cboPartNo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!cboPartNo.Enabled) return;
            if (cboPartNo.DataSource == null) return;
            btnAdd.Enabled = (cboPartNo.SelectedIndex >= 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!btnAdd.Enabled) return;
            if (cboPartNo.DataSource == null) return;
            if (cboPartNo.SelectedIndex < 0) return;

            _selectedpart = new PartInfo(cboPartNo.SelectedValue.ToString());
            DialogResult = System.Windows.Forms.DialogResult.OK; Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _selectedpart = null;
            DialogResult = System.Windows.Forms.DialogResult.OK; Close();
        }

        #endregion

    }
}
