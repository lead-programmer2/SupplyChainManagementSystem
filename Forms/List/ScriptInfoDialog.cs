using DevComponents.DotNetBar;
using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class ScriptInfoDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of ScriptInfoDialog.
        /// </summary>
        public ScriptInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of ScriptInfoDialog.
        /// </summary>
        /// <param name="refno"></param>
        public ScriptInfoDialog(string refno)
        {
            InitializeComponent();

            _referenceno = refno; _isnew = false;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _referenceno = "";

        /// <summary>
        /// Gets the current updated script's reference number.
        /// </summary>
        public string ReferenceNo
        {
            get { return _referenceno; }
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
            txtTitle.TextChanged += new EventHandler(Field_Edited);
            txtScript.TextChanged += new EventHandler(Field_Edited);
            txtDescription.TextChanged += new EventHandler(Field_Edited);
            chkBackup.CheckedChanged += new EventHandler(Field_Edited);
            chkRestartApp.CheckedChanged += new EventHandler(Field_Edited);
            chkRestartPc.CheckedChanged += new EventHandler(Field_Edited);
        }

        private void InitializeInfo()
        {
            DataTable _scripts = Cache.GetCachedTable("scripts");
            if (_scripts != null)
            {
                DataRow[] _rows = _scripts.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];

                    if (!Materia.IsNullOrNothing(_row["ReferenceNo"])) txtReferenceNo.Text = _row["ReferenceNo"].ToString();
                    if (!Materia.IsNullOrNothing(_row["SystemVersion"])) txtSystemVersion.Text = _row["SystemVersion"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Author"])) txtAuthor.Text = _row["Author"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Title"])) txtTitle.Text = _row["Title"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Script"])) txtScript.Text = _row["Script"].ToString();
                    if (VisualBasic.IsNumeric(_row["RequireBackup"])) chkBackup.Checked = VisualBasic.CBool(_row["RequireBackup"]);
                    if (VisualBasic.IsNumeric(_row["RequireAppRestart"])) chkRestartApp.Checked = VisualBasic.CBool(_row["RequireAppRestart"]);
                    if (VisualBasic.IsNumeric(_row["RequirePcRestart"])) chkRestartPc.Checked = VisualBasic.CBool(_row["RequirePcRestart"]);
                    if (!Materia.IsNullOrNothing(_row["Description"])) txtDescription.Text = _row["Description"].ToString();
                    if (VisualBasic.IsNumeric(_row["Executed"]))
                    {
                        if (VisualBasic.CBool(_row["Executed"]))
                        {
                            if (VisualBasic.IsDate(_row["DateExecuted"]))
                            { 
                                lblExecuted.Text = "Last Executed : " + VisualBasic.Format(VisualBasic.CDate(_row["DateExecuted"]), "dd-MMM-yyyy");
                                lblExecuted.Show(); lblExecuted.BringToFront();
                            }
                            else lblExecuted.Hide();
                        }
                        else lblExecuted.Hide();
                    }

                    if (VisualBasic.IsNumeric(_row["AutoScript"]))
                    {
                        if (VisualBasic.CBool(_row["AutoScript"]))
                        { lblAutoScript.Show(); lblAutoScript.BringToFront(); }
                        else lblAutoScript.Hide();
                    }
                    else lblAutoScript.Hide();
                }
            }
        }

        #endregion

        #region FormEvents

        private void ScriptInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updated)
            {
                System.Windows.Forms.DialogResult _result = MsgBoxEx.Shout("You have made some updates in the current database script. Do you<br/>want to save the changes applied before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);

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

        private void ScriptInfoDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            if (_isnew)
            {
                string _tempseries = SCMS.GetTableSeriesNumber("scripts");
                txtReferenceNo.Text = "SQL-" + SCMS.CurrentCompany.Company + "-" + _tempseries;
            }
            else txtReferenceNo.Text = _referenceno;

            btnExport.Enabled = (!_isnew); btnExport.Visible = (!_isnew);
            btnExecute.Enabled = (!_isnew); btnExecute.Visible = (!_isnew);
            txtAuthor.Text = SCMS.CurrentSystemUser.FullName; txtSystemVersion.Text = Application.ProductVersion;
            
            txtReferenceNo.ReadOnly = true; txtAuthor.ReadOnly = true;
            lblAutoScript.Hide(); lblExecuted.Hide();

            txtTitle.SetAsRequired(); txtScript.SetAsRequired();
            txtSystemVersion.SetAsRequired(); txtDescription.SetAsRequired();

            if (!_isnew) InitializeInfo();
        }

        private void ScriptInfoDialog_Shown(object sender, EventArgs e)
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

            if (!Materia.Valid(_validator, txtSystemVersion, !string.IsNullOrEmpty(txtSystemVersion.Text.RLTrim()), "Please specify the applicable system version for the current script.")) return;
            if (!Materia.Valid(_validator, txtTitle, !string.IsNullOrEmpty(txtTitle.Text.RLTrim()), "Please specify database script's title.")) return;
            if (!Materia.Valid(_validator, txtScript, !string.IsNullOrEmpty(txtScript.Text.RLTrim()), "Please specify database script's sql statement.")) return;
            if (!Materia.Valid(_validator, txtDescription, !string.IsNullOrEmpty(txtDescription.Text.RLTrim()), "Please specify database script's description.")) return;

            string _pattern = "[0-9]+\\.[0-9]+\\.[0-9]+\\.[0-9]+";
            if (!Materia.Valid(_validator, txtSystemVersion, Regex.IsMatch(txtSystemVersion.Text, _pattern), "Please specify a valid system version.")) return;

            MatchCollection _matches = Regex.Matches(txtSystemVersion.Text, _pattern);
            if (_matches.Count > 0)
            {
                string _match = _matches[0].Value;
                if (!Materia.Valid(_validator, txtSystemVersion, _match == txtSystemVersion.Text, "Please specify a valid system version.")) return;
            }
            DataTable _scripts = Cache.GetCachedTable("scripts");

            if (_scripts != null)
            {
                string _query = ""; string _refno = "";
                DataColumnCollection _cols = _scripts.Columns;
 
                if (_isnew)
                {
                    Func<string, bool, string> _delegate = new Func<string, bool, string>(SCMS.GetTableSeriesNumber);
                    IAsyncResult _result = _delegate.BeginInvoke("scripts", true, null, _delegate);

                    while (!_result.IsCompleted &&
                           !_cancelled)
                    { Thread.Sleep(1); Application.DoEvents(); }

                    if (_cancelled)
                    {
                        if (!_result.IsCompleted)
                        {
                            try { _result = null; }
                            catch {}
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }

                        return;
                    }

                    string _seriesno = _delegate.EndInvoke(_result);
                    _refno = "SQL-" + SCMS.CurrentCompany.Company + "-" + _seriesno;

                    _query = "INSERT INTO `scripts`\n" +
                             "(`ReferenceNo`, `Title`, `Author`, `Script`, `SystemVersion`, `RequireBackup`, `RequireAppRestart`, `RequirePcRestart`, `Description`, `DateCreated`)\n" +
                             "VALUES\n" +
                             "('" + _refno.ToSqlValidString() + "', '" + txtTitle.Text.ToSqlValidString() + "', '" + txtAuthor.Text.ToSqlValidString() + "', '" + txtScript.Text.ToSqlValidString() + "', '" + txtSystemVersion.Text.ToSqlValidString() + "', " + (chkBackup.Checked ? "1" : "0") + ", " + (chkRestartApp.Checked ? "1" : "0") + ", " + (chkRestartPc.Checked ? "1" : "0") + ", '" + txtDescription.Text.ToSqlValidString() + "', NOW());";

                    object[] _values = new object[_cols.Count];
                    _values[_cols["ReferenceNo"].Ordinal] = _refno;
                    _values[_cols["Title"].Ordinal] = txtTitle.Text;
                    _values[_cols["Author"].Ordinal] = txtAuthor.Text;
                    _values[_cols["Script"].Ordinal] = txtScript.Text;
                    _values[_cols["SystemVersion"].Ordinal] = txtSystemVersion.Text;
                    _values[_cols["RequireBackup"].Ordinal] = (chkBackup.Checked? 1 : 0);
                    _values[_cols["RequireAppRestart"].Ordinal] = (chkRestartApp.Checked ? 1 : 0);
                    _values[_cols["RequirePcRestart"].Ordinal] = (chkRestartPc.Checked ? 1 : 0);
                    _values[_cols["Description"].Ordinal] = txtDescription.Text;
                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _values[_cols["LastModified"].Ordinal] = DateTime.Now;
                    _scripts.Rows.Add(_values);
                }
                else
                {
                    _query = "UPDATE `scripts` SET\n" +
                             "`Title` = '" + txtTitle.Text.ToSqlValidString() + "', `Author` = '" + txtAuthor.Text.ToSqlValidString() + "', `Author` = '" + txtAuthor.Text.ToSqlValidString() + "', `Script` = '" + txtScript.Text.ToSqlValidString() + "', `SystemVersion` = '" + txtSystemVersion.Text.ToSqlValidString() + "', `RequireBackup` = " + (chkBackup.Checked ? "1" : "0") + ", `RequireAppRestart` = " + (chkRestartApp.Checked ? "1" : "0") + ", `RequirePcRestart` = " + (chkRestartPc.Checked ? "1" : "0") + ", `Description` = '" + txtDescription.Text.ToSqlValidString() + "'\n" +
                             "WHERE\n" +
                             "(`ReferenceNo` LIKE '" + _referenceno.ToSqlValidString() + "');";
                    
                    DataRow[] _existing = _scripts.Select("[ReferenceNo] LIKE '" + _referenceno.ToSqlValidString(true) + "'");

                    if (_existing.Length > 0)
                    {
                        _existing[0]["Title"] = txtTitle.Text;
                        _existing[0]["Author"] = txtAuthor.Text;
                        _existing[0]["Script"] = txtScript.Text;
                        _existing[0]["SystemVersion"] = txtSystemVersion.Text;
                        _existing[0]["RequireBackup"] = (chkBackup.Checked? 1 : 0);
                        _existing[0]["RequireAppRestart"] = (chkRestartApp.Checked ? 1 : 0);
                        _existing[0]["RequirePcRestart"] = (chkRestartPc.Checked? 1 : 0);
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

                            string _log = "Added a database script : " + _refno + ".";
                            if (!_isnew) _log = "Updated database script : " + _referenceno + ".";

                            _scripts.AcceptChanges();
                            if (_isnew)
                            {
                                _referenceno = _refno;
                                _isnew = false;
                                
                                btnExport.Enabled = true;
                                btnExport.Show(); btnExport.BringToFront();

                                btnExecute.Enabled = true;
                                btnExecute.Show(); btnExecute.BringToFront();
                            } 
                            if (_updated) _updated = false;
                            if (!_withupdates) _withupdates = true;
                            Text = Text.Replace(" *", "").Replace("*", "");
                            Cursor = Cursors.WaitCursor;

                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(_action, _log, _referenceno);
                            _logresult.WaitToFinish();

                            Cursor = Cursors.Default;

                            if (sender == btnSaveAndClose)
                            { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
                        }
                        else
                        {
                            if (_queresult.Error.Contains("duplicate")) btnSave_Click(sender, new EventArgs());
                            else
                            {
                                SCMS.LogError(this.GetType().Name, new Exception(_queresult.Error));
                                MsgBoxEx.Alert("Failed to save the current database script.", "Save Database Script");
                            }

                            _scripts.RejectChanges();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!btnExport.Enabled) return;

            if (_updated)
            {
                if (MsgBoxEx.Shout("Changes in the current database script will be saved<br />first? Continue with the exportation?", "Export Database Script", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes) return;
                btnSave_Click(btnSave, new EventArgs());
                if (_updated) return;
            }

            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.DefaultExt = SCMS.ScriptFileExtension;
            _dialog.Filter = "SCMS database script file (*." + SCMS.ScriptFileExtension + ")|*." + SCMS.ScriptFileExtension;
            _dialog.Title = "Export Database Script";
            _dialog.FileName = _referenceno + "." + SCMS.ScriptFileExtension;
            if (_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess(); return;
            }

            DataTable _scripts = Cache.GetCachedTable("scripts");
            if (_scripts != null)
            {
                var _query = from _scr in _scripts.AsEnumerable()
                             where _scr.Field<string>("ReferenceNo") == _referenceno
                             select _scr;

                DataTable _script = _query.CopyToDataTable();
                _script.TableName = "scripts";
                FileInfo _exportedfile = _script.ExportData(_dialog.FileName, true);
                if (_exportedfile != null)
                {
                    Cursor = Cursors.WaitCursor;
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.ExportEdi, "Exported database script into : " + _dialog.FileName + ".", _referenceno);
                    _logresult.WaitToFinish(); Cursor = Cursors.Default;
                    Process.Start("explorer.exe", "/select, \"" + _exportedfile.FullName + "\"");
                }
                else MsgBoxEx.Alert("Failed to export the current database script into the specified path.", "Export Database Script");
                _script.Dispose(); _script = null; _exportedfile = null;
                Materia.RefreshAndManageCurrentProcess();
            }
            else MsgBoxEx.Alert("Failed to export the current database script into the specified path.", "Export Database Script");

            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!btnExport.Enabled) return;

            if (_updated)
            {
                if (MsgBoxEx.Shout("Changes in the current database script will be saved<br />first? Continue with the exportation?", "Export Database Script", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes) return;
                btnSave_Click(btnSave, new EventArgs());
                if (_updated) return;
            }

            DatabaseScriptInfo _script = new DatabaseScriptInfo(_referenceno);
            _script.Execute();

            try { InitializeInfo(); }
            catch { }
        }

        #endregion
        
    }
}
