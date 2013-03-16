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
    public partial class PartNameInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of PartNameInfoDialog.
        /// </summary>
        public PartNameInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of PartNameInfoDialog.
        /// </summary>
        /// <param name="name"></param>
        public PartNameInfoDialog(string name)
        {
            InitializeComponent();

            _partname = name; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _partname = "";

        /// <summary>
        /// Gets the current updated part name.
        /// </summary>
        public string PartName
        {
            get { return _partname; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current department conducts any updates while it is open.
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
            txtPartName.TextChanged += new EventHandler(Field_Edited);
            cboPartCategory.SelectedValueChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _partnames = Cache.GetCachedTable("partnames");
            if (_partnames != null)
            {
                DataRow[] _rows = _partnames.Select("[PartName] LIKE '" + _partname.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["PartName"])) txtPartName.Text = _row["PartName"].ToString();
                    if (!Materia.IsNullOrNothing(_row["PartCategory"])) cboPartCategory.SelectedValue = _row["PartCategory"];
                }
            }
        }

        #endregion

        #region FormEvents

        private void PartNameInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current part name. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void PartNameInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();
            cboPartCategory.LoadPartCategories();

            txtPartName.SetAsRequired(); cboPartCategory.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void PartNameInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtPartName, !string.IsNullOrEmpty(txtPartName.Text.RLTrim()), "Please specify part name.")) return;
            if (!Materia.Valid(_validator, cboPartCategory, cboPartCategory.SelectedIndex >= 0, "Please specify a valid parts category.")) return;
            
            DataTable _partnames = Cache.GetCachedTable("partnames");

            if (_partnames != null)
            {
                DataRow[] _rows = _partnames.Select("([PartName] LIKE '" + txtPartName.Text.ToSqlValidString(true) + "') AND\n" +
                                                    "NOT ([PartName] LIKE '" + _partname.ToSqlValidString(true) + "')");

                if (!Materia.Valid(_validator, txtPartName, _rows.Length <= 0, "Part name already exists.")) return;

                string _query = "";
                DataColumnCollection _cols = _partnames.Columns;

                if (_isnew)
                {
                    _query = "INSERT INTO `partnames`\n" +
                             "(`PartName`, `PartCategory`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + txtPartName.Text.ToSqlValidString() + "', '" + cboPartCategory.SelectedValue.ToString().ToSqlValidString()  + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["PartName"].Ordinal] = txtPartName.Text;
                    _values[_cols["PartCategory"].Ordinal] = cboPartCategory.SelectedValue;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _partnames.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `partnames` SET\n" +
                             "`PartName` = '" + txtPartName.Text.ToSqlValidString() + "', `PartCategory` = '" + cboPartCategory.SelectedValue.ToString().ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`PartName` LIKE '" + _partname.ToSqlValidString() + "');";
                    
                    DataRow[] _existing = _partnames.Select("[PartName] LIKE '" + _partname.ToSqlValidString(true) + "'");
                    if (_existing.Length > 0)
                    {
                        _existing[0]["PartName"] = txtPartName.Text;
                        _existing[0]["PartCategory"] = cboPartCategory.SelectedValue;
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

                            string _log = "Added a new part name : " + txtPartName.Text + ".";
                            if (!_isnew) _log = "Updated part name : " + _partname + (_partname != txtPartName.Text ? " to " + txtPartName.Text : "").ToString() + ".";

                            _partnames.AcceptChanges(); _partname = txtPartName.Text;
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
                                bool _invalid = Materia.Valid(_validator, txtPartName, false, "Part name already exists.");
                            }
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current part name.", "Save Part Name");
                            }

                            _partnames.RejectChanges();
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

        private void lblAddCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PartCategoryInfoDialog _dialog = new PartCategoryInfoDialog();
            _dialog.ShowDialog();

            if (_dialog.WithUpdates)
            {
                cboPartCategory.LoadPartCategories();

                if (cboPartCategory.DataSource != null)
                {
                    try { cboPartCategory.SelectedValue = _dialog.PartCategory; }
                    catch { }
                }
            }

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        #endregion

    }
}
