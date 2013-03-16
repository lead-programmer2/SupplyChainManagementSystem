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
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class BrandInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of BrandInfoDialog.
        /// </summary>
        public BrandInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of BrandInfoDialog.
        /// </summary>
        public BrandInfoDialog(string brandname)
        {
            InitializeComponent();

            _brand = brandname; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _brand = "";

        /// <summary>
        /// Gets the current updated brand.
        /// </summary>
        public string Brand
        {
            get { return _brand; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current vehicle make conducts any updates while it is open.
        /// </summary>
        public bool WithUpdates
        {
            get { return _withupdates; }
        }

        #endregion

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

        #region Methods

        private void AttachEditorHandler()
        {
            txtBrand.TextChanged += new EventHandler(Field_Edited);
        }

        #endregion

        #region FormEvents

        private void VehicleMakeInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current brand. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void VehicleMakeInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            txtBrand.SetAsRequired(); txtBrand.Text = _brand;
        }

        private void VehicleMakeInfoDialog_Shown(object sender, EventArgs e)
        { if (!_isshown) _isshown = true; }

        #endregion

        #region ControlEvents

        private void Field_Edited(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!_isshown) return;

            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.ErrorProvider.SetError((Control)sender, "");

            if (!_updated) _updated = true;
            this.MarkAsEdited();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtBrand, !string.IsNullOrEmpty(txtBrand.Text.RLTrim()), "Please specify vehicle make name.")) return;
            DataTable _brands = Cache.GetCachedTable("brands");

            if (_brands != null)
            {
                DataRow[] _rows = _brands.Select("([Brand] LIKE '" + txtBrand.Text.ToSqlValidString(true) + "') AND\n" +
                                                 "NOT ([Brand] LIKE '" + _brand.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtBrand, _rows.Length <= 0, "Brand already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _brands.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `brands`\n" +
                             "(`Brand`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtBrand.Text.ToSqlValidString() + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["Brand"].Ordinal] = txtBrand.Text;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _brands.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `brands` SET\n" +
                             "`Brand` = '" + txtBrand.Text.ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`Brand` LIKE '" + _brand.ToSqlValidString() + "');";
                    DataRow[] _existing = _brands.Select("[Brand] LIKE '" + _brand.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0) _existing[0]["Brand"] = txtBrand.Text;
                }

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;

                    if (txtBrand.Text == _brand)
                    {
                        if (_isnew) _isnew = false;
                        if (_updated) _updated = false;
                        if (_withupdates) _withupdates = false;

                        Text = Text.Replace(" *", "").Replace("*", "");

                        if (sender == btnSaveAndClose)
                        { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }

                        return;
                    }

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

                            string _log = "Added a new brand : " + txtBrand.Text + ".";
                            if (!_isnew) _log = "Updated brand : " + _brand + (_brand != txtBrand.Text ? " to " + txtBrand.Text : "").ToString() + ".";

                            _brands.AcceptChanges(); _brand = txtBrand.Text;
                            if (_isnew) _isnew = false;
                            if (_updated) _updated = false;
                            if (!_withupdates) _withupdates = true;
                            Text = Text.Replace(" *", "").Replace("*", "");
                            Cursor = Cursors.WaitCursor;

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _log);
                            _logresult.WaitToFinish();

                            Cursor = Cursors.Default;

                            if (sender == btnSaveAndClose)
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                        }
                        else
                        {
                            if (_queresult.Error.Contains("duplicate"))
                            {
                                bool _invalid = Materia.Valid(_validator, txtBrand, false, "Brand already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current brand.", "Save Brand");
                            }

                            _brands.RejectChanges();
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

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (btnSaveAndClose.Enabled) btnSave_Click(btnSaveAndClose, new EventArgs());
        }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        { btnSave_Click(btnSave, new EventArgs()); }

        #endregion

    }
}
