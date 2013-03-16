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
    public partial class PositionInfoDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of PositionInfoDialog.
        /// </summary>
        public PositionInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of PositionInfoDialog.
        /// </summary>
        public PositionInfoDialog(string postn)
        {
            InitializeComponent();

            _position = postn; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _position = "";

        /// <summary>
        /// Gets the current updated position.
        /// </summary>
        public string Position
        {
            get { return _position; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current position conducts any updates while it is open.
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
            txtPosition.TextChanged += new EventHandler(Field_Edited);
        }

        #endregion

        #region FormEvents

        private void PositionInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current position. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void PositionInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            txtPosition.SetAsRequired(); txtPosition.Text = _position;
        }

        private void PositionInfoDialog_Shown(object sender, EventArgs e)
        {  if (!_isshown) _isshown = true; }

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

            if (!Materia.Valid(_validator, txtPosition, !string.IsNullOrEmpty(txtPosition.Text.RLTrim()), "Please specify position name.")) return;
            DataTable _positions = Cache.GetCachedTable("positions");

            if (_position != null)
            {
                DataRow[] _rows = _positions.Select("([Position] LIKE '" + txtPosition.Text.ToSqlValidString(true) + "') AND\n" +
                                                      "NOT ([Position] LIKE '" + _position.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtPosition, _rows.Length <= 0, "Position already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _positions.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `positions`\n" +
                             "(`Position`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtPosition.Text.ToSqlValidString() + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["Position"].Ordinal] = txtPosition.Text;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _positions.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `positions` SET\n" +
                             "`Position` = '" + txtPosition.Text.ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`Position` LIKE '" + _position.ToSqlValidString() + "');";
                    DataRow[] _existing = _positions.Select("[Position] LIKE '" + _position.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0) _existing[0]["Position"] = txtPosition.Text;
                }

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;

                    if (txtPosition.Text == _position)
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

                            string _log = "Added a new position : " + txtPosition.Text + ".";
                            if (!_isnew) _log = "Updated position : " + _position + (_position != txtPosition.Text ? " to " + txtPosition.Text : "").ToString() + ".";

                            _positions.AcceptChanges(); _position = txtPosition.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtPosition, false, "Position already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current position.", "Save Position");
                            }

                            _positions.RejectChanges();
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
        {  btnSave_Click(btnSave, new EventArgs()); }

        #endregion

    }
}
