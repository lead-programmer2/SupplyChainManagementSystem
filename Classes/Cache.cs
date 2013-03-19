using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{

    /// <summary>
    /// Application's data cache.
    /// </summary>
    public static class Cache
    {

        /// <summary>
        /// Gets the cache storage path.
        /// </summary>
        public static string CachePath
        {
            get { return Application.StartupPath + "\\Cache\\cache.scms"; }
        }

        /// <summary>
        /// Gets the current synchronization date and time for the current workstation's cache.
        /// </summary>
        public static DateTime LastRestoration
        {
            get
            {
                DateTime _lastrestoration = VisualBasic.CDate("1/1/1900");

                string _path = Application.StartupPath + "\\Xml\\cachesettings.xml";
                DataTable _cachesettings = SCMS.XmlToTable(_path);

                if (_cachesettings != null)
                {
                    if (_cachesettings.Rows.Count > 0)
                    {
                        CompanyInfo _company = SCMS.CurrentCompany;
                        ServerConnectionInfo _server = SCMS.ServerConnection;
                        if (_company != null &&
                            _server != null)
                        {
                            DataRow[] _rows = _cachesettings.Select("[Company] LIKE '" + _company.Company.ToSqlValidString(true) + "' AND\n" +
                                                              "[Server] LIKE '" + _server.Server.ToSqlValidString(true) + "' AND\n" +
                                                              "[Database] LIKE '" + _server.Database.ToSqlValidString(true) + "'");

                            if (_rows.Length > 0) _lastrestoration = VisualBasic.CDate(_rows[0]["LastRestored"]);
                        }
                     }
                    _cachesettings.Dispose(); _cachesettings = null;
                    Materia.RefreshAndManageCurrentProcess();
                }

                return _lastrestoration;
            }
        }

        /// <summary>
        /// Gets whether contents are available in the application's cache or not.
        /// </summary>
        public static bool WithContents
        {
            get { return File.Exists(CachePath); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static DataSet _cacheddataset = null;

        /// <summary>
        /// Clears the cache contents.
        /// </summary>
        public static void Clear()
        {
            int _trycounter = 0;

            while (File.Exists(CachePath) &&
                   _trycounter <= 30)
            {
                try { File.Delete(CachePath); }
                catch { }
                _trycounter += 1;
                Thread.Sleep(100); Application.DoEvents();
            }

            if (_cacheddataset != null)
            {
                _cacheddataset.Tables.Clear(); Materia.RefreshAndManageCurrentProcess();
            }
        }

        /// <summary>
        /// Gets a table with the specified table name from the application's cache.
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataTable GetCachedTable(string tablename)
        {
            DataTable _table = null;

            if (_cacheddataset != null)
            {
                if (_cacheddataset.Tables.Contains(tablename)) _table = _cacheddataset.Tables[tablename];
                else
                {
                    SyncTable(SCMS.Connection, tablename);
                    if (_cacheddataset.Tables.Contains(tablename)) _table = _cacheddataset.Tables[tablename];
                }
            }

            return _table;
        }

        /// <summary>
        /// Synchronizes registered cache data into the current connected server.
        /// </summary>
        /// <param name="connection"></param>
        public static void Refresh(IDbConnection connection)
        {
            if (_cacheddataset == null) _cacheddataset = SCMS.XmlToDataSet(CachePath);

            if (_cacheddataset == null)
            {
                if (connection != null) _cacheddataset = MySql.GetDataSet(connection);
            }
            else
            {
                List<string> _tables = MySql.GetTables(connection);

                if (_tables != null)
                {
                    foreach (string _tablename in _tables) SyncTable(connection, _tablename);
                }
            }

            Save();
        }

        /// <summary>
        /// Asynchronously synchronizes registered cache data into the current connected server.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static IAsyncResult RefreshAsync(IDbConnection connection)
        {
            Action<IDbConnection> _delegate = new Action<IDbConnection>(Refresh);
            return _delegate.BeginInvoke(connection, null, _delegate);
        }

        /// <summary>
        /// Synchronizes the specified database table using the supplied database connection.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tablename"></param>
        public static void SyncTable(IDbConnection connection, string tablename)
        {
            string _pk = "";

            if (tablename == "models") _pk = "ModelCode";
            else if (tablename == "locations") _pk = "LocationCode";
            else { }

            SyncTable(connection, tablename, _pk); 
        }

        /// <summary>
        /// Synchronizes the specified database table using the supplied database connection.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tablename"></param>
        /// <param name="primarykey"></param>
        public static void SyncTable(IDbConnection connection, string tablename, string primarykey)
        {
            if (_cacheddataset == null) _cacheddataset = SCMS.XmlToDataSet(CachePath);
            if (_cacheddataset == null)
            {
                if (connection != null)
                {
                    _cacheddataset = new DataSet();
                    _cacheddataset.DataSetName = connection.ConnectionString.ConnectionStringValue(ConnectionStringSection.Database);
                }                
            }

            if (_cacheddataset != null)
            {
                DataTable _table = null;

                if (_cacheddataset.Tables.Contains(tablename))
                {
                    _table = _cacheddataset.Tables[tablename];

                    DataTable _updated = null;

                    if (_table.Columns.Contains("LastModified") ||
                        _table.Columns.Contains("DateAndTime"))
                    {
                        DateTime _lastupdate = VisualBasic.CDate("1/1/1900");
                        string _datetimefield = "DateAndTime";
                        if (_table.Columns.Contains("LastModified")) _datetimefield = "LastModified";

                        object _maxdate = _table.Compute("MAX([" + _datetimefield + "])", "");
                        if (VisualBasic.IsDate(_maxdate)) _lastupdate = VisualBasic.CDate(_maxdate);

                        _updated = _updated.LoadData(SCMS.Connection, "SELECT `OldValue`, `NewValue` FROM `updateditems` AS `u` WHERE (`TableName` LIKE '" + tablename.ToSqlValidString() + "') AND (`LastModified` >= '" + _lastupdate.ToSqlValidString(true) + "')");
                    }
                    else _updated = _updated.LoadData(SCMS.Connection, "SELECT `OldValue`, `NewValue` FROM `updateditems` AS `u` WHERE (`TableName` LIKE '" + tablename.ToSqlValidString() + "')");
   
                    if (_updated != null)
                    {
                        string _pk = primarykey;

                        if (string.IsNullOrEmpty(_pk.RLTrim()))
                        {
                            for (int i = 0; i <= (_table.Columns.Count - 1); i++)
                            {
                                if (_table.Columns[i].Unique)
                                { _pk = _table.Columns[i].ColumnName; break; }
                            }
                        }
                       
                        if (!string.IsNullOrEmpty(_pk.RLTrim()))
                        {
                            for (int i = 0; i <= (_updated.Rows.Count - 1); i++)
                            {
                                DataRow _row = _updated.Rows[i];
                                DataRow[] _rows = _table.Select("CONVERT([" + _pk + "], System.String) = '" + _row["OldValue"].ToString().ToSqlValidString(true) + "'");
                                if (_rows.Length > 0)
                                {
                                    DataRow[] _exists = _table.Select("CONVERT([" + _pk + "], System.String) = '" + _row["NewValue"].ToString().ToSqlValidString(true) + "'");
                                    if (_exists.Length <= 0) _rows[0][_pk] = _row["NewValue"];
                                }
                            }

                            _table.AcceptChanges();
                        }

                        _updated.Dispose(); _updated = null;
                        Materia.RefreshAndManageCurrentProcess();
                    }

                    if (_table.Columns.Contains("LastModified") ||
                        _table.Columns.Contains("DateAndTime"))
                    {
                        DateTime _lastupdate = VisualBasic.CDate("1/1/1900");
                        string _datetimefield = "DateAndTime";
                        if (_table.Columns.Contains("LastModified")) _datetimefield = "LastModified";

                        object _maxdate = _table.Compute("MAX([" + _datetimefield + "])", "");
                        if (VisualBasic.IsDate(_maxdate)) _lastupdate = VisualBasic.CDate(_maxdate);

                        DataTable _updates = null;
                        _updates = _updates.LoadData(connection, "SELECT * FROM `" + tablename + "` WHERE (`" + _datetimefield + "` >= '" + _lastupdate.ToSqlValidString(true) + "')");

                        if (_updates != null)
                        {
                            if (_updates.Rows.Count > 0)
                            {
                                try { _table.Merge(_updates, false, MissingSchemaAction.Add); }
                                catch (Exception ex) { SCMS.LogError("Cache", ex); }

                                if (_table.Columns.Contains("Voided"))
                                {
                                    DataRow[] _rows = _table.Select("[Voided] = 1");

                                    if (_rows.Length > 0)
                                    {
                                        System.Collections.IEnumerator _enumerators = _rows.GetEnumerator();
                                        while (_enumerators.MoveNext()) ((DataRow)_enumerators.Current).Delete();
                                    }
                                }

                                _table.AcceptChanges();
                            }
                            
                            try { _updates.Dispose(); }
                            catch { }
                            finally { _updates = null; Materia.RefreshAndManageCurrentProcess(); }
                        }

                        DataTable _deleted = null;

                        if (_table.Columns.Contains("LastModified") ||
                            _table.Columns.Contains("DateAndTime")) _deleted = _deleted.LoadData(connection, "SELECT * FROM `deleteditems` WHERE (`TableName` LIKE '" + tablename.ToSqlValidString() + "') AND (`LastModified` >= '" + _lastupdate.ToSqlValidString(true) + "');");
                        else _deleted = _deleted.LoadData(connection, "SELECT * FROM `deleteditems` WHERE (`TableName` LIKE '" + tablename.ToSqlValidString() + "');");

                        if (_deleted != null)
                        {
                            if (_deleted.Rows.Count > 0)
                            {
                                for (int i = 0; i <= (_deleted.Rows.Count - 1); i++)
                                {
                                    DataRow _delrow = _deleted.Rows[i];
                                    string _pk = primarykey;

                                    if (string.IsNullOrEmpty(_pk.RLTrim()))
                                    {
                                        foreach (DataColumn _col in _table.Columns)
                                        {
                                            if (_col.Unique)
                                            {
                                                _pk = _col.ColumnName; break;
                                            }
                                        }
                                    }
                                    
                                    if (!String.IsNullOrEmpty(_pk.RLTrim()))
                                    {
                                        DataRow[] _delrows = _table.Select("CONVERT([" + _pk + "], System.String) LIKE '" + _delrow["Value"].ToString().ToSqlValidString(true) + "'");
                                        if (_delrows.Length > 0)
                                        {
                                            System.Collections.IEnumerator _selrows = _delrows.GetEnumerator();
                                            while (_selrows.MoveNext()) ((DataRow)_selrows.Current).Delete();
                                          
                                            _table.AcceptChanges(); Materia.RefreshAndManageCurrentProcess();
                                        }
                                    }
                                }
                            }
                            
                            _deleted.Dispose(); _deleted = null;
                            Materia.RefreshAndManageCurrentProcess();
                        }
                    }
                }
                else
                {
                    if (connection != null)
                    {
                        _table = _table.LoadData(connection, "SELECT * FROM `" + tablename + "`");
                        if (_table != null)
                        {
                            if (!string.IsNullOrEmpty(primarykey.RLTrim()))
                            {
                                if (_table.Constraints.Count > 0 &&
                                    _table.Columns.Contains(primarykey)) _table.Constraints.Clear();

                                if (_table.Constraints.Count <= 0 &&
                                    _table.Columns.Contains(primarykey)) _table.Constraints.Add("PK", _table.Columns[primarykey], true);
                         
                            }

                            if (_table.Columns.Contains("Voided"))
                            {
                                DataRow[] _rows = _table.Select("[Voided] = 1");

                                if (_rows.Length > 0)
                                {
                                    System.Collections.IEnumerator _enumerators = _rows.GetEnumerator();
                                    while (_enumerators.MoveNext()) ((DataRow)_enumerators.Current).Delete();
                                }
                            }

                            DataTable _deleted = null;
                            _deleted = _deleted.LoadData(connection, "SELECT * FROM `deleteditems` WHERE (`TableName` LIKE '" + tablename.ToSqlValidString() + "');");

                            if (_deleted != null)
                            {
                                if (_deleted.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= (_deleted.Rows.Count - 1); i++)
                                    {
                                        DataRow _delrow = _deleted.Rows[i];
                                        string _pk = primarykey;

                                        if (string.IsNullOrEmpty(_pk.RLTrim()))
                                        {
                                            foreach (DataColumn _col in _table.Columns)
                                            {
                                                if (_col.Unique)
                                                {
                                                    _pk = _col.ColumnName; break;
                                                }
                                            }
                                        }
                                        
                                        if (!String.IsNullOrEmpty(_pk.RLTrim()))
                                        {
                                            DataRow[] _delrows = _table.Select("CONVERT([" + _pk + "], System.String) LIKE '" + _delrow["Value"].ToString().ToSqlValidString(true) + "'");
                                            if (_delrows.Length > 0)
                                            {
                                                System.Collections.IEnumerator _selrows = _delrows.GetEnumerator();
                                                while (_selrows.MoveNext()) ((DataRow)_selrows.Current).Delete();
                                          
                                                _table.AcceptChanges(); Materia.RefreshAndManageCurrentProcess();
                                            }
                                        }
                                    }
                                }

                                _deleted.Dispose(); _deleted = null;
                                Materia.RefreshAndManageCurrentProcess();
                            }

                            _table.AcceptChanges(); _cacheddataset.Tables.Add(_table);
                        } 
                    }
                }

                Save();
            }
        }

        /// <summary>
        /// Synchronizes the specified database table using the supplied database connection asynchronously.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static IAsyncResult SyncTableAsync(IDbConnection connection, string tablename)
        { return SyncTableAsync(connection, tablename, ""); }

        /// <summary>
        /// Synchronizes the specified database table using the supplied database connection asynchronously.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tablename"></param>
        /// <param name="primarykey"></param>
        /// <returns></returns>
        public static IAsyncResult SyncTableAsync(IDbConnection connection, string tablename, string primarykey)
        {
            Action<IDbConnection, string, string> _delegate = new Action<IDbConnection, string, string>(SyncTable);
            return _delegate.BeginInvoke(connection, tablename, primarykey, null, _delegate);
        }

        /// <summary>
        /// Saves the current synchronized data into the application's cache.
        /// </summary>
        public static void Save()
        {
            if (_cacheddataset != null)
            {
                
                try 
                {
                    _cacheddataset.AcceptChanges();
                    _cacheddataset.WriteXml(CachePath, XmlWriteMode.WriteSchema); 
                }
                catch (Exception ex) { SCMS.LogError("Cache", ex); }
            }
        }

        /// <summary>
        /// Updates the current workstation's cache time stamp.
        /// </summary>
        /// <param name="timestamp"></param>
        public static void UpdateCacheTimeStamp(DateTime timestamp)
        {
            string _path = Application.StartupPath + "\\Xml\\cachesettings.xml";
            DataTable _cachesettings = SCMS.XmlToTable(_path);

            if (_cachesettings != null)
            {
                CompanyInfo _company = SCMS.CurrentCompany;
                ServerConnectionInfo _server = SCMS.ServerConnection;

                if (_company == null) _company = new CompanyInfo(SCMS.LastSelectedCompany);
                if (_server == null) _server = new ServerConnectionInfo(SCMS.LastSelectedConnection);

                if (_cachesettings.Rows.Count > 0)
                {
                    DataRow[] _rows = _cachesettings.Select("[Company] LIKE '" + _company.Company.ToSqlValidString(true) + "' AND\n" +
                                                            "[Server] LIKE '" + _server.Server.ToSqlValidString(true) + "' AND\n" +
                                                            "[Database] LIKE '" + _server.Database.ToSqlValidString(true) + "'");

                    if (_rows.Length > 0) _rows[0]["LastRestored"] = timestamp;
                    else
                    {
                        object[] _values = new object[_cachesettings.Columns.Count];
                        DataColumnCollection _cols = _cachesettings.Columns;

                        _values[_cols["Company"].Ordinal] = _company.Company;
                        _values[_cols["Server"].Ordinal] = _server.Server;
                        _values[_cols["Database"].Ordinal] = _server.Database;
                        _values[_cols["LastRestored"].Ordinal] = timestamp;

                        _cachesettings.Rows.Add(_values);
                    }
                }
                else
                {
                    object[] _values = new object[_cachesettings.Columns.Count];
                    DataColumnCollection _cols = _cachesettings.Columns;

                    _values[_cols["Company"].Ordinal] = _company.Company;
                    _values[_cols["Server"].Ordinal] = _server.Server;
                    _values[_cols["Database"].Ordinal] = _server.Database;
                    _values[_cols["LastRestored"].Ordinal] = timestamp;

                    _cachesettings.Rows.Add(_values);
                 }

                _cachesettings.AcceptChanges();

                try { _cachesettings.WriteXml(_path, XmlWriteMode.WriteSchema); }
                catch { }

                _cachesettings.Dispose(); _cachesettings = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

    }
}
