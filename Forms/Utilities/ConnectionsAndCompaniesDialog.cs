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
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{

    /// <summary>
    /// Default database connections and accessible companies maintenance dialog.
    /// </summary>
    public partial class ConnectionsAndCompaniesDialog : Office2007Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of ConnectionsAndCompaniesDialog.
        /// </summary>
        public ConnectionsAndCompaniesDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of ConnectionsAndCompaniesDialog.
        /// </summary>
        /// <param name="setting"></param>
        public ConnectionsAndCompaniesDialog(ConnectionSetting setting)
        {
            InitializeComponent();

            _setting = setting;
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ConnectionSetting _setting = ConnectionSetting.Servers;

        #endregion

        #region Methods

        private void FormatGrid(C1FlexGrid grid)
        {
            if (grid != null)
            {
                if (grid.DataSource != null)
                {
                    if (grid.Name == grdServers.Name)
                    {
                        grid.AllowEditing = true;  grid.AllowDelete = true;
                        grid.AllowAddNew = true; grid.AllowFiltering = true;

                        for (int i = grid.Cols.Fixed; i <= (grid.Cols.Count -1); i++) grid.Cols[i].AllowEditing = true;

                        grid.Cols["Extra"].Caption = "";
                        grid.Cols["Extra"].AllowEditing = false;
                        grid.Cols["Editor"].Caption = "Credentials";
                        grid.Cols["Editor"].ComboList = "...";
                        grid.Cols["UID"].Visible = false;
                        grid.Cols["Password"].Visible = false;
                        grid.NewRowWatermark = "Add new server connection here...";
                        grid.ShowButtons = ShowButtonsEnum.Always;
                    }
                    else if (grid.Name == grdCompanies.Name)
                    {
                        grid.AllowEditing = true; grid.AllowDelete = true;
                        grid.AllowAddNew = true; grid.AllowFiltering = true;
                        grid.NewRowWatermark = "Add new company here...";
                    }
                    else
                    { }
                }
            }
        }

        private void InitializeCompanies()
        {
            string _path = Application.StartupPath + "\\Xml\\defaultcompanies.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                if (grdCompanies.Redraw) grdCompanies.BeginUpdate();

                if (grdCompanies.DataSource != null)
                {
                    try { grdCompanies.DataSource = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }

                grdCompanies.DataSource = _table;
                FormatGrid(grdCompanies);
                grdCompanies.AutoNumber();
                grdCompanies.AutoSizeCols(); ResizeGrid(grdCompanies);
                grdCompanies.ExtendLastCol = true;

                while (!grdCompanies.Redraw) grdCompanies.EndUpdate();
            }
        }

        private void InitializeConnections()
        {
            string _path = Application.StartupPath + "\\Xml\\databaseconnections.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataTable _datasource = _table.Clone();
                DataColumn _editorcol = _datasource.Columns.Add("Editor", typeof(string));
                _datasource.Columns.Add("Extra", typeof(string));
                _editorcol.DefaultValue = "Assign server credentials...";

                foreach (DataRow _row in _table.Rows)
                {
                    string[] _values = new string[_datasource.Columns.Count];
                    foreach (DataColumn _col in _table.Columns) _values[_col.Ordinal] = _row[_col.ColumnName].ToString();
                    _values[_datasource.Columns["Editor"].Ordinal] = "Assign server credentials...";
                    _values[_datasource.Columns["Extra"].Ordinal] = "";

                    _datasource.Rows.Add(_values);
                }

                _datasource.AcceptChanges();
                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();

                if (grdServers.Redraw) grdServers.BeginUpdate();

                if (grdServers.DataSource != null)
                {
                    try { ((DataTable)grdServers.DataSource).Dispose(); }
                    catch { }
                    finally
                    {
                        grdServers.DataSource = null; 
                        Materia.RefreshAndManageCurrentProcess();
                    }
                }

                grdServers.DataSource = _datasource;
                FormatGrid(grdServers);

                grdServers.AutoNumber();
                grdServers.AutoSizeCols(); ResizeGrid(grdServers);
                grdServers.ExtendLastCol = true;

                while (!grdServers.Redraw) grdServers.EndUpdate();
            }
        }

        private void ResizeGrid(C1FlexGrid grid)
        {
            if (grid != null)
            {
                if (grid.DataSource != null)
                {
                    if (grid.Name == grdServers.Name)
                    {
                        if (grid.Cols["Name"].Width < 90) grid.Cols["Name"].Width = 90;
                        if (grid.Cols["Server"].Width < 90) grid.Cols["Server"].Width = 90;
                        if (grid.Cols["Database"].Width < 90) grid.Cols["Database"].Width = 90;
                        if (grid.Cols["Editor"].Width < 160) grid.Cols["Editor"].Width = 160;
                    }
                    else if (grid.Name == grdCompanies.Name)
                    {
                        if (grid.Cols["Company"].Width < 90) grid.Cols["Company"].Width = 90;
                    }
                    else
                    { }
                }
            }
        }

        #endregion

        #region FormEvents

        private void ConnectionsAndCompaniesDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose(); 
            grdServers.InitializeAppearance(); grdCompanies.InitializeAppearance();
            InitializeConnections(); InitializeCompanies();

            switch (_setting)
            {
                case ConnectionSetting.Companies :
                    tbctrlSettings.SelectedTab = tbCompanies; break;
                case ConnectionSetting.Servers:
                default:
                    tbctrlSettings.SelectedTab = tbServers; break;
            }
        }

        #endregion

        #region GridEvents

        private void grdServers_CellButtonClick(object sender, RowColEventArgs e)
        {
            if (grdServers.DataSource == null) return;
            if (grdServers.RowSel < grdServers.Rows.Fixed) return;

            string _server = ""; string _database = "";
            string _uid = ""; string _pwd = "";

            if (!Materia.IsNullOrNothing(grdServers.Rows[grdServers.RowSel]["Server"])) _server = grdServers.Rows[grdServers.RowSel]["Server"].ToString();
            if (!Materia.IsNullOrNothing(grdServers.Rows[grdServers.RowSel]["Database"])) _database = grdServers.Rows[grdServers.RowSel]["Database"].ToString();
            if (!Materia.IsNullOrNothing(grdServers.Rows[grdServers.RowSel]["UID"])) _uid = grdServers.Rows[grdServers.RowSel]["UID"].ToString();
            if (!Materia.IsNullOrNothing(grdServers.Rows[grdServers.RowSel]["Password"])) _pwd = grdServers.Rows[grdServers.RowSel]["Password"].ToString();

            DatabaseCredentialDialog _dialog = new DatabaseCredentialDialog(_server, _database, _uid, _pwd);
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                grdServers.Rows[grdServers.RowSel]["UID"] = _dialog.UserId;
                grdServers.Rows[grdServers.RowSel]["Password"] = _dialog.Password;
            }

            try { _dialog.Dispose(); }
            catch { }
            finally { Materia.RefreshAndManageCurrentProcess(); }
        }

        #endregion

        #region ControlEvents

        private void btnSaveServers_Click(object sender, EventArgs e)
        {
            if (!btnSaveServers.Enabled) return;
            if (grdServers.DataSource == null) return;
            try { grdServers.Row = grdServers.Rows.Fixed - 1; }
            catch { }

            for (int i = grdServers.Rows.Fixed; i <= (grdServers.Rows.Count - 1); i++)
            {
                if (!Materia.IsNullOrNothing(grdServers.Rows[i]["Name"]))
                {
                    if (String.IsNullOrEmpty(grdServers.Rows[i]["Name"].ToString().RLTrim()))
                    {
                        MsgBoxEx.Shout("Please specify database server connection name at entry : " + i.ToString() + ".", "Required Field Notification");
                        grdServers.StartEditing(i, grdServers.Cols["Name"].Index); return; 
                    }

                    if (String.IsNullOrEmpty(grdServers.Rows[i]["Server"].ToString().RLTrim()))
                    {
                        MsgBoxEx.Shout("Please specify database server IP address or hostname at entry : " + i.ToString() + ".", "Required Field Notification");
                        grdServers.StartEditing(i, grdServers.Cols["Server"].Index); return;
                    }

                    if (String.IsNullOrEmpty(grdServers.Rows[i]["Database"].ToString().RLTrim()))
                    {
                        MsgBoxEx.Shout("Please specify database catalog name at entry : " + i.ToString() + ".", "Required Field Notification");
                        grdServers.StartEditing(i, grdServers.Cols["Database"].Index); return;
                    }
                }
            }

            DataTable _datasource = (DataTable)grdServers.DataSource;

            if (_datasource.Rows.Count <= 0)
            { MsgBoxEx.Shout("Please specify at least a database connection to be registered.", "Save Database Server Connections"); return; }

            DataTable _changes = _datasource.GetChanges();

            if (_changes != null)
            {
                string _path = Application.StartupPath + "\\Xml\\databaseconnections.xml";
                DataTable _current = SCMS.XmlToTable(_path);

                if (_current != null)
                {
                    foreach (DataRow _row in _changes.Rows)
                    {
                        switch (_row.RowState)
                        {
                            case DataRowState.Added:
                                string[] _values = new string[_current.Columns.Count];
                                foreach (DataColumn _col in _current.Columns)
                                { _values[_col.Ordinal] = _row[_col.ColumnName].ToString(); }
                                _current.Rows.Add(_values); break;
                            case DataRowState.Modified:
                                string _name = "";
                                
                                try { _name = _row["Name", DataRowVersion.Original].ToString(); }
                                catch { _name = _row["Name"].ToString(); }
                                
                                DataRow[] _existingrows = _current.Select("[Name] = '" + _name.ToSqlValidString(true) + "'");
                                if (_existingrows.Length > 0)
                                {
                                    DataRow _currentrow = _existingrows[0];
                                    foreach (DataColumn _col in _current.Columns)
                                    { _currentrow[_col.ColumnName] = _row[_col.ColumnName]; }
                                }

                                break;
                            case DataRowState.Deleted:
                            case DataRowState.Detached:
                                string _deletedname = "";
                                
                                try { _deletedname = _row["Name", DataRowVersion.Original].ToString(); }
                                catch { _deletedname = ""; }

                                 DataRow[] _rows = _current.Select("[Name] = '" + _deletedname.ToSqlValidString(true) + "'");
                                 if (_rows.Length > 0) _rows[0].Delete();

                                break;
                            default: break;
                        }
                    }

                    try 
                    { 
                        _current.WriteXml(_path, XmlWriteMode.WriteSchema);
                        _datasource.AcceptChanges();
                    }
                    catch (Exception ex)  
                    {
                        SCMS.LogError(this.Name, ex);
                        MsgBoxEx.Alert("Failed to save the changes made in the list. Please try again and / or report<br />this to your System Administrator.", "Save Database Server Connections");
                    }

                    try { _current.Dispose(); }
                    catch { }

                    _current = null; Materia.RefreshAndManageCurrentProcess();
                }
            }
        }

        private void btnSaveCompanies_Click(object sender, EventArgs e)
        {
            if (!btnSaveCompanies.Enabled) return;
            if (grdCompanies.DataSource == null) return;

            try { grdCompanies.Row = grdCompanies.Rows.Fixed - 1; }
            catch { }

            for (int i = 0; i <= (grdCompanies.Rows.Count - 1); i++)
            {
                if (!Materia.IsNullOrNothing(grdCompanies.Rows[i]["Company"]))
                {
                    if (String.IsNullOrEmpty(grdCompanies.Rows[i]["Company"].ToString().RLTrim()))
                    {
                        MsgBoxEx.Shout("Please specify company at entry : " + i.ToString() + ".", "Required Field Notification");
                        grdCompanies.StartEditing(i, grdCompanies.Cols["Company"].Index); return;
                    }

                    if (String.IsNullOrEmpty(grdCompanies.Rows[i]["Name"].ToString().RLTrim()))
                    {
                        MsgBoxEx.Shout("Please specify company name at entry : " + i.ToString() + ".", "Required Field Notification");
                        grdCompanies.StartEditing(i, grdCompanies.Cols["Name"].Index); return;
                    }
                }
            }

            DataTable _datasource = (DataTable)grdCompanies.DataSource;

            if (_datasource.Rows.Count <= 0)
            {
                MsgBoxEx.Shout("Please specify at leasts a company to be registered and accessed.", "Save Company List"); return;
            }

            DataTable _changes = _datasource.GetChanges();

            if (_changes != null)
            {
                try
                {
                    string _path = Application.StartupPath + "\\Xml\\defaultcompanies.xml";
                    _datasource.WriteXml(_path, XmlWriteMode.WriteSchema);
                    _datasource.AcceptChanges();
                }
                catch (Exception ex)
                {
                    SCMS.LogError(this.Name, ex);
                    MsgBoxEx.Alert("Failed to save the changes made in the list. Please try again and / or report<br />this to your System Administrator.", "Save Company List");
                }
            }
        }

        #endregion

    }
}
