using C1.Win.C1FlexGrid;
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
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class UserManagementDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of UserManagementDialog.
        /// </summary>
        public UserManagementDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _updatedcurrentuser = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets whether the current user account has been updated when this dialog is opened.
        /// </summary>
        public bool UpdatedCurrentUser
        {
            get { return _updatedcurrentuser; }
        }

        #endregion

        #region Methods

        private void DisplayInfo()
        {
            DataTable _datasource = null;

            try { _datasource = (DataTable)grdUsers.DataSource; }
            catch { }

            if (_datasource == null) btnInformation.Text = " Ready";
            else
            {
                if (_datasource.Rows.Count <= 0) btnInformation.Text = " Ready";
                else
                {
                    DataTable _viewtable = _datasource.DefaultView.ToTable();
                    btnInformation.Text = " Displayed records : " + _viewtable.Rows.Count.ToString() + " out of " + _datasource.Rows.Count.ToString();
                    _viewtable.Dispose(); _viewtable = null;
                    Materia.RefreshAndManageCurrentProcess();
                }
            }
        }

        private void EnabledButtons()
        {
            btnAdd.Enabled = true; btnRefresh.Enabled = true;
            txtSearch.Enabled = true;

            DataTable _datasource = null;

            try { _datasource = (DataTable)grdUsers.DataSource; }
            catch { }

            if (_datasource != null)
            {
                DataTable _viewtable = _datasource.DefaultView.ToTable();

                btnEdit.Enabled = (_viewtable.Rows.Count > 0);
                btnDelete.Enabled = (_viewtable.Rows.Count > 0);

                _viewtable.Dispose(); _viewtable = null;
                Materia.RefreshAndManageCurrentProcess();
            }
            else
            {
                btnEdit.Enabled = false; btnDelete.Enabled = false;

            }
        }

        private void FormatGrid()
        {
            if (grdUsers.DataSource == null) return;
            grdUsers.FormatColumns();
            ColumnCollection _cols = grdUsers.Cols;
            _cols["FullName"].Caption = "Account Holder";
            _cols["Active"].DataType = typeof(bool);
            _cols["DateCreated"].Format = "dd-MMM-yyyy hh:mm:ss tt";
            _cols["DateCreated"].Caption = "Date Created";
            _cols["DateCreated"].Visible = false;
            _cols["LastModified"].Format = "dd-MMM-yyyy hh:mm:ss tt";
            _cols["LastModified"].Caption = "Last Modified";

            grdUsers.AutoNumber(); _cols[_cols.Fixed - 1].Caption = "#";
        }

        private DataTable GetBlankDataSource()
        {
            DataTable _datasource = new DataTable();

            DataColumn _pk = _datasource.Columns.Add("Username", typeof(string));
            _datasource.Columns.Add("FullName", typeof(string));
            _datasource.Columns.Add("Department", typeof(string));
            _datasource.Columns.Add("Position", typeof(string));
            _datasource.Columns.Add("Active", typeof(Int16));
            _datasource.Columns.Add("DateCreated", typeof(DateTime));
            _datasource.Columns.Add("LastModified", typeof(DateTime));
            _datasource.Constraints.Add("PK", _pk, true);

            return _datasource;
        }

        private void InitializeUsersList()
        {
            pctLoad.Show(); pctLoad.BringToFront();
            if (grdUsers.Redraw) grdUsers.BeginUpdate();
            btnAdd.Enabled = false; btnEdit.Enabled = false;
            btnDelete.Enabled = false; btnRefresh.Enabled = false;
            txtSearch.Enabled = false; txtSearch.Text = "";
            btnInformation.Text = " Gathering data...";

            IAsyncResult _cacheresult = Cache.SyncTableAsync(SCMS.Connection, "users");
            while (!_cancelled &&
                   !_cacheresult.IsCompleted)
            { Thread.Sleep(1); Application.DoEvents(); }

            if (_cancelled)
            {
                try { _cacheresult = null; }
                catch { }
                finally { Materia.RefreshAndManageCurrentProcess(); }

                return;
            }
            else
            {
                DataTable _table = Cache.GetCachedTable("users");
                var _query = from _users in _table.AsEnumerable()
                             where _users.Field<Int16>("Voided") == 0
                             select new
                             {
                                 Username = _users.Field<string>("Username"),
                                 FullName = _users.Field<string>("FirstName") + " " + _users.Field<string>("LastName"),
                                 Department = _users.Field<string>("Department"),
                                 Position = _users.Field<string>("Position"),
                                 Active = _users.Field<Int16>("Active"),
                                 DateCreated = _users.Field<DateTime>("DateCreated"),
                                 LastModified = _users.Field<DateTime>("LastModified")
                             };
                    
                DataTable _datasource = GetBlankDataSource();
                foreach (var _row in _query) _datasource.Rows.Add(new object[] {
                                                                  _row.Username, _row.FullName,
                                                                  _row.Department, _row.Position,
                                                                  _row.Active, _row.DateCreated,
                                                                  _row.LastModified });

                _datasource.DefaultView.Sort = "[Username]";
                grdUsers.ClearRowsAndColumns();
                grdUsers.DataSource = _datasource;
                FormatGrid(); ResizeGrid();
                while (!grdUsers.Redraw) grdUsers.EndUpdate();
            }

            EnabledButtons(); pctLoad.Hide(); DisplayInfo();
        }

        private void ResizeGrid()
        {
            if (grdUsers.DataSource == null) return;
            grdUsers.AutoSizeCols(); grdUsers.ExtendLastCol = true;
            ColumnCollection _cols = grdUsers.Cols;
            if (_cols["Username"].Width < 80) _cols["Username"].Width = 80;
            if (_cols["FullName"].Width < 150) _cols["FullName"].Width = 150;
            if (_cols["Department"].Width < 150) _cols["Department"].Width = 150;
            if (_cols["Position"].Width < 150) _cols["Position"].Width = 150;
            _cols[_cols.Fixed - 1].Width = 30;
        }

        #endregion

        #region FormEvents

        private void UserManagementDialog_FormClosing(object sender, FormClosingEventArgs e)
        { _cancelled = true; }

        private void UserManagementDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); grdUsers.InitializeAppearance();
            grdUsers.AttachMouseHoverPointer();
        }

        private void UserManagementDialog_Shown(object sender, EventArgs e)
        { btnRefresh_Click(btnRefresh, new EventArgs()); }

        #endregion

        #region GridEvents

        private void grdUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!grdUsers.Redraw) return;
            if (grdUsers.DataSource == null) return;
            int _row = grdUsers.GetMouseOveredRow(e.X, e.Y);
            if (_row < grdUsers.Rows.Fixed) return;
            grdUsers.Row = _row; btnEdit_Click(btnEdit, new EventArgs());
        }

        #endregion

        #region ControlEvents

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Enabled) InitializeUsersList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!btnAdd.Enabled) return;

            UserInfoDialog _dialog = new UserInfoDialog();
            _dialog.ShowDialog();
            if (_dialog.WithUpdates) InitializeUsersList();
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!btnEdit.Enabled) return;
            if (grdUsers.DataSource == null) return;
            if (!grdUsers.Redraw) return;
            if (grdUsers.RowSel < grdUsers.Rows.Fixed) return;

            string _username = grdUsers[grdUsers.RowSel, "Username"].ToString();

            UserInfoDialog _dialog = new UserInfoDialog(_username);
            _dialog.ShowDialog();
            if (_dialog.WithUpdates)
            { 
                _updatedcurrentuser = _updatedcurrentuser || _dialog.IsCurrentUser;
                InitializeUsersList();
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!btnDelete.Enabled) return;
            if (!grdUsers.Redraw) return;
            if (grdUsers.DataSource == null) return;
            if (grdUsers.RowSel < grdUsers.Rows.Fixed) return;

            string _username = grdUsers[grdUsers.RowSel, "Username"].ToString();
            string _accountholder = grdUsers[grdUsers.RowSel, "FullName"].ToString();

            if (_username == SCMS.CurrentSystemUser.Username)
            { MsgBoxEx.Shout("System does not allow to remove your own user account.", "Delete User Account"); return; }

            if (MsgBoxEx.Ask("Do you really want to remove <font color=\"blue\">" + _accountholder + " (" + _username + ")</font> from the user<br />account list?<br /><br /><b>Note :</b> If account has historical data along with it, user account will<br />not be removed permanently to retain historical logs of the account.", "Delete User Account") != System.Windows.Forms.DialogResult.Yes) return;

            string _query = "DELETE FROM `users` WHERE (`Username` LIKE '" + _username.ToSqlValidString() + "');";

            btnAdd.Enabled = false; btnEdit.Enabled = false; btnDelete.Enabled = false;
            btnRefresh.Enabled = false; txtSearch.Enabled = false;

            Cursor = Cursors.WaitCursor;
            IAsyncResult _delresult = Que.BeginExecution(SCMS.Connection, _query);
            while (!_delresult.IsCompleted &&
                   !_cancelled)
            { Thread.Sleep(1); Application.DoEvents(); }

            if (_cancelled)
            {
                if (!_delresult.IsCompleted)
                {
                    try { _delresult = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }

                return;
            }
            else
            {
                QueResult _result = Que.EndExecution(_delresult);
                if (string.IsNullOrEmpty(_result.Error.RLTrim()))
                {
                    IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Delete, "Removed " + _accountholder + " (" + _username + ") from the user accounts list.");
                    _logresult.WaitToFinish();

                    DataTable _datasource = null;

                    try { _datasource = (DataTable)grdUsers.DataSource; }
                    catch { }

                    if (_datasource != null)
                    {
                        DataRow[] _rows = _datasource.Select("[Username] LIKE '" + _username.ToSqlValidString(true) + "'");
                        if (_rows.Length > 0)
                        {
                            if (grdUsers.Redraw) grdUsers.BeginUpdate();
                            
                            _rows[0].Delete();
                            _datasource.AcceptChanges();
                            FormatGrid(); ResizeGrid();

                            DataTable _users = Cache.GetCachedTable("users");
                            if (_users != null)
                            {
                                DataRow[] _delusers = _users.Select("[Username] LIKE '" + _username.ToSqlValidString(true) + "'");
                                System.Collections.IEnumerator _delenums = _delusers.GetEnumerator();
                                while (_delenums.MoveNext()) ((DataRow)_delenums.Current).Delete();
                                _users.AcceptChanges(); Cache.Save();
                            }

                            while (!grdUsers.Redraw) grdUsers.EndUpdate();
                            DisplayInfo();
                        }
                    }
                }
                else
                {
                    _query = "UPDATE `users` SET\n" +
                             "`Voided` = 1, `DateVoided` = NOW()\n" +
                             "WHERE\n" +
                             "(`Username` LIKE '" + _username.ToSqlValidString(true) + "');";

                    Cursor = Cursors.WaitCursor;
                    _delresult = null; Materia.RefreshAndManageCurrentProcess();
                    _delresult = Que.BeginExecution(SCMS.Connection, _query);
                    while (!_delresult.IsCompleted &&
                           !_cancelled)
                    { Thread.Sleep(1); Application.DoEvents(); }

                    if (_cancelled)
                    {
                        if (!_delresult.IsCompleted)
                        {
                            try { _delresult = null; }
                            catch { }
                            finally { Materia.RefreshAndManageCurrentProcess(); }
                        }

                        return;
                    }
                    else
                    {
                        _result.Dispose(); Materia.RefreshAndManageCurrentProcess();
                        _result = Que.EndExecution(_delresult);
                        if (string.IsNullOrEmpty(_result.Error.RLTrim()))
                        {
                            IAsyncResult _logresult = SCMS.CurrentSystemUser.LogActionAsync(UserAction.Delete, "Removed " + _accountholder + " (" + _username + ") from the user accounts list.");
                            _logresult.WaitToFinish();

                            DataTable _datasource = null;

                            try { _datasource = (DataTable)grdUsers.DataSource; }
                            catch { }

                            if (_datasource != null)
                            {
                                DataRow[] _rows = _datasource.Select("[Username] LIKE '" + _username.ToSqlValidString(true) + "'");
                                if (_rows.Length > 0)
                                {
                                    if (grdUsers.Redraw) grdUsers.BeginUpdate();

                                    _rows[0].Delete();
                                    _datasource.AcceptChanges();
                                    FormatGrid(); ResizeGrid();

                                    DataTable _users = Cache.GetCachedTable("users");
                                    if (_users != null)
                                    {
                                        DataRow[] _delusers = _users.Select("[Username] LIKE '" + _username.ToSqlValidString(true) + "'");
                                        System.Collections.IEnumerator _delenums = _delusers.GetEnumerator();
                                        while (_delenums.MoveNext()) ((DataRow)_delenums.Current).Delete();
                                        _users.AcceptChanges(); Cache.Save();
                                    }

                                    while (!grdUsers.Redraw) grdUsers.EndUpdate();
                                    DisplayInfo();
                                }
                            }
                        }
                        else
                        {
                            SCMS.LogError(this.GetType().Name, new Exception(_result.Error));
                            MsgBoxEx.Alert("Failed to remove the specified user account from the list.", "Delete User Account");
                        }
                    }
                }

                _result.Dispose(); EnabledButtons();
            }

            Cursor = Cursors.Default;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Enabled) return;
            if (!grdUsers.Redraw) return;
            if (grdUsers.DataSource == null) return;

            DataTable _datasource = (DataTable)grdUsers.DataSource;
            if (grdUsers.Redraw) grdUsers.BeginUpdate();
            
            try { _datasource.Filter(txtSearch.Text); }
            catch { }
            FormatGrid(); ResizeGrid();

            while (!grdUsers.Redraw) grdUsers.EndUpdate();
            EnabledButtons(); DisplayInfo();
        }

        #endregion

    }
}
