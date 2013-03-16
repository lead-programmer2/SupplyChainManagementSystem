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
    public partial class ModelInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of ModelInfoDialog.
        /// </summary>
        public ModelInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of ModelInfoDialog.
        /// </summary>
        /// <param name="code"></param>
        public ModelInfoDialog(string code)
        {
            InitializeComponent();

            _modelcode = code; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _brand = "";

        /// <summary>
        /// Sets the initially selected brand when dialog shows up in the user screen.
        /// </summary>
        public string Brand
        {
            set { _brand = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _modelcode = "";

        /// <summary>
        /// Gets the current updated vehicle model's code.
        /// </summary>
        public string ModelCode
        {
            get { return _modelcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current vehicle model conducts any updates while it is open.
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
            txtModel.TextChanged += new EventHandler(Field_Edited);
            cboBrand.SelectedValueChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _models = Cache.GetCachedTable("models");
            if (_models != null)
            {
                DataRow[] _rows = _models.Select("[ModelCode] LIKE '" + _modelcode.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["Model"])) txtModel.Text = _row["Model"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Brand"])) cboBrand.SelectedValue = _row["Brand"].ToString();
                 }
            }
        }

        #endregion

        #region FormEvents

        private void ModelInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current model. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void ModelInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboBrand.LoadBrands();

            if (!string.IsNullOrEmpty(_brand.RLTrim()) &&
                cboBrand.DataSource != null)
            {
                try { cboBrand.SelectedValue = _brand; }
                catch { }
            }

            txtModel.SetAsRequired(); cboBrand.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void ModelInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtModel, !string.IsNullOrEmpty(txtModel.Text.RLTrim()), "Please specify vehicle model name.")) return;
            if (!Materia.Valid(_validator, cboBrand, cboBrand.SelectedIndex >= 0, "Please specify a valid vehicle make.")) return;

            DataTable _models = Cache.GetCachedTable("models");

            if (_models != null)
            {
                DataRow[] _rows = _models.Select("([Model] LIKE '" + txtModel.Text.ToSqlValidString(true) + "' AND\n" +
                                                 " [Brand] LIKE '" + cboBrand.SelectedValue.ToString().ToSqlValidString(true) + "') AND\n" +
                                                 "NOT ([ModelCode] LIKE '" + _modelcode.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtModel, _rows.Length <= 0, "Model already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _models.Columns;
                string _refno = "";

                if (_isnew)
                {
                    Func<string, bool, string> _delegate = new Func<string, bool, string>(SCMS.GetTableSeriesNumber);
                    IAsyncResult _result = _delegate.BeginInvoke("models", true, null, _delegate);

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

                    _refno = _delegate.EndInvoke(_result);

                    _query = "INSERT INTO `models`\n" +
                             "(`ModelCode`, `Model`, `Brand`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('MODEL-" + _refno + "', '" + txtModel.Text.ToSqlValidString() + "', '" + cboBrand.SelectedValue.ToString().ToSqlValidString() + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["ModelCode"].Ordinal] = "MODEL-" + _refno;
                    _values[_cols["Model"].Ordinal] = txtModel.Text;
                    _values[_cols["Brand"].Ordinal] = cboBrand.SelectedValue;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _models.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `models` SET\n" +
                             "`Model` = '" + txtModel.Text.ToSqlValidString() + "', `Brand` = '" + cboBrand.SelectedValue.ToString().ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`ModelCode` LIKE '" + _modelcode.ToSqlValidString() + "');";

                    DataRow[] _existing = _models.Select("[ModelCode] LIKE '" + _modelcode.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["Model"] = txtModel.Text;
                        _existing[0]["Brand"] = cboBrand.SelectedValue;
                    }
                }

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

                            string _log = "Added a new model : " + txtModel.Text + ".";
                            if (!_isnew) _log = "Updated model : " + cboBrand.SelectedValue.ToString() + " - " + txtModel.Text + ".";

                            _models.AcceptChanges();
                            if (_isnew) _modelcode = "MODEL-" + _refno;
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
                                bool _invalid = Materia.Valid(_validator, txtModel, false, "Model already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current model.", "Save Model");
                            }

                            _models.RejectChanges();
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

        private void lblAddBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrandInfoDialog _dialog = new BrandInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                cboBrand.LoadBrands();

                if (cboBrand.DataSource != null)
                {
                    try { cboBrand.SelectedValue = _dialog.Brand; }
                    catch { }
                }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        #endregion

    }
}
