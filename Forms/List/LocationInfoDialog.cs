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
    public partial class LocationInfoDialog : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of LocationInfoDialog.
        /// </summary>
        public LocationInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of LocationInfoDialog.
        /// </summary>
        public LocationInfoDialog(string code)
        {
            InitializeComponent();

            _locationcode = code; _isnew = false;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _location = "";
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _locationcode = "";

        /// <summary>
        /// Gets the current updated location.
        /// </summary>
        public string LocationCode
        {
            get { return _locationcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current location conducts any updates while it is open.
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
            txtLocation.TextChanged += new EventHandler(Field_Edited);
        }

        #endregion

        private void LocationInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
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

        private void LocationInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            txtLocation.SetAsRequired();

            DataTable _locations = Cache.GetCachedTable("locations");
            if (_locations != null)
            {
                DataRow[] _rows = _locations.Select("[LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "'");
                if (_rows.Length > 0) _location = _rows[0]["Location"].ToString();
            }
            txtLocation.Text = _location;
        }

        private void LocationInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtLocation, !string.IsNullOrEmpty(txtLocation.Text.RLTrim()), "Please specify location name.")) return;
            DataTable _locations = Cache.GetCachedTable("locations");

            if (_locations != null)
            {
                DataRow[] _rows = _locations.Select("([Location] LIKE '" + txtLocation.Text.ToSqlValidString(true) + "' AND\n" +
                                                    " [Company] LIKE '" + SCMS.CurrentCompany.Company.ToSqlValidString(true) + "') AND\n" +
                                                    "NOT ([LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtLocation, _rows.Length <= 0, "Location already exists.")) return;

                string _query = ""; string _refno = _locationcode;
                DataColumnCollection _cols = _locations.Columns;

                if (_isnew)
                {
                    Func<string, bool, string> _delegate = new Func<string, bool, string>(SCMS.GetTableSeriesNumber);
                    IAsyncResult _result = _delegate.BeginInvoke("locations", true, null, _delegate);

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

                    string _seriesnumber = _delegate.EndInvoke(_result);
                    _refno = SCMS.CurrentCompany.Company + "-" + _seriesnumber;

                    _query = "INSERT INTO `locations`\n" +
                             "(`LocationCode`, `Location`, `Company`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + _refno.ToSqlValidString() + "', '" + txtLocation.Text.ToSqlValidString() + "', '" + SCMS.CurrentCompany.Company.ToSqlValidString() + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["LocationCode"].Ordinal] = _refno;
                    _values[_cols["Location"].Ordinal] = txtLocation.Text;
                    _values[_cols["Company"].Ordinal] = SCMS.CurrentCompany.Company;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _locations.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `locations` SET\n" +
                             "`Location` = '" + txtLocation.Text.ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`LocationCode` LIKE '" + _locationcode.ToSqlValidString() + "');";

                    DataRow[] _existing = _locations.Select("[LocationCode] LIKE '" + _locationcode.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0) _existing[0]["Location"] = txtLocation.Text;
                }

                if (!string.IsNullOrEmpty(_query.RLTrim()))
                {
                    btnSave.Enabled = false; btnSaveAndClose.Enabled = false;

                    if (txtLocation.Text == _location)
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

                            string _log = "Added a new location : " + txtLocation.Text + ".";
                            if (!_isnew) _log = "Updated location : " + _location + (_location != txtLocation.Text ? " to " + txtLocation.Text : "").ToString() + ".";

                            _locations.AcceptChanges(); _locationcode = _refno;  
                            _location = txtLocation.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtLocation, false, "Location already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current location.", "Save Location");
                            }

                            _locations.RejectChanges();
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
        {  btnSave_Click(btnSave, new EventArgs());  }

    }
}
