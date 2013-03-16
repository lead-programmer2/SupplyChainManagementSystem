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
    public partial class MeasurementInfoDialog : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of MeasurementInfoDialog.
        /// </summary>
        public MeasurementInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of MeasurementInfoDialog.
        /// </summary>
        /// <param name="unit"></param>
        public MeasurementInfoDialog(string unit)
        {
            InitializeComponent();

            _measurement = unit; _isnew = false;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _measurement = "";

        /// <summary>
        /// Gets the current updated unit of measurement.
        /// </summary>
        public string Measurement
        {
            get { return _measurement; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current measurement conducts any updates while it is open.
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

        #region Methods

        private void AttachEditorHandler()
        {
            txtUnit.TextChanged += new EventHandler(Field_Edited);
            txtDescription.TextChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _units = Cache.GetCachedTable("measurements");
            if (_units != null)
            {
                DataRow[] _rows = _units.Select("[Unit] LIKE '" + _measurement.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["Unit"])) txtUnit.Text = _row["Unit"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Description"])) txtDescription.Text = _row["Description"].ToString();
                }
            }
        }

        #endregion

        private void MeasurementInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            txtUnit.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void MeasurementInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current location. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void MeasurementInfoDialog_Shown(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtUnit, !string.IsNullOrEmpty(txtUnit.Text.RLTrim()), "Please specify unit of measurement.")) return;
            DataTable _units = Cache.GetCachedTable("measurements");

            if (_units != null)
            {
                DataRow[] _rows = _units.Select("([Unit] LIKE '" + txtUnit.Text.ToSqlValidString(true) + "') AND\n" +
                                                 "NOT ([Unit] LIKE '" + _measurement.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtUnit, _rows.Length <= 0, "Unit of measurement already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _units.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `measurements`\n" +
                             "(`Unit`, `Description`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtUnit.Text.ToSqlValidString() + "', '" + txtDescription.Text.ToSqlValidString() + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["Unit"].Ordinal] = txtUnit.Text;
                    _values[_cols["Description"].Ordinal] = txtDescription.Text;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _units.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `measurements` SET\n" +
                             "`Unit` = '" + txtUnit.Text.ToSqlValidString() + "', `Description` = '" + txtDescription.Text.ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`Unit` LIKE '" + _measurement.ToSqlValidString() + "');";

                    DataRow[] _existing = _units.Select("[Unit] LIKE '" + _measurement.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["Unit"] = txtUnit.Text;
                        _existing[0]["Description"] = txtDescription.Text;
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

                            string _log = "Added a new unit of measurement : " + txtUnit.Text + ".";
                            if (!_isnew) _log = "Updated unit of measurement : " + _measurement + (_measurement != txtUnit.Text ? " to " + txtUnit.Text : "").ToString() + ".";

                            _units.AcceptChanges(); _measurement = txtUnit.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtUnit, false, "Unit of measurement already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current unit of measurement.", "Save Measurement");
                            }

                            _units.RejectChanges();
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

    }

}
