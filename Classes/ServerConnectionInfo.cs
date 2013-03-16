using Development.Materia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{

    /// <summary>
    /// Database server connection information.
    /// </summary>
    public class ServerConnectionInfo
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ServerConnectionInfo.
        /// </summary>
        /// <param name="connectionname"></param>
        public ServerConnectionInfo(string connectionname)
        {
            string _path = Application.StartupPath + "\\Xml\\databaseconnections.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataRow[] _rows = _table.Select("[Name] = '" + connectionname.ToSqlValidString(true) + "'");

                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0]; _name = connectionname;

                    if (!Materia.IsNullOrNothing(_row["Server"])) _server = _row["Server"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Database"])) _database = _row["Database"].ToString();
                    if (!Materia.IsNullOrNothing(_row["UID"])) _userid = _row["UID"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Password"])) _password = _row["Password"].ToString();
                }

                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _database = "";

        /// <summary>
        /// Gets the current server connection's database catalog.
        /// </summary>
        public string Database
        {
            get { return _database; }
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _name = "";

        /// <summary>
        /// Gets the current server connection's name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _password = "";

        /// <summary>
        /// Gets the current server connection's log on account password.
        /// </summary>
        public string Password
        {
            get { return _password; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _server = "";

        /// <summary>
        /// Gets the current server connection's IP address / hostname.
        /// </summary>
        public string Server
        {
            get { return _server; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _userid = "";

        /// <summary>
        /// Gets the current server connection's log on account id.
        /// </summary>
        public string UserId
        {
            get { return _userid; }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string _pattern = "SERVER={0};DATABASE={1};UID={2};PWD={3};";
            string _currentserver = Server; string _currentdatabase = Database;
            string _currentuid = UserId;  string _currentpwd = Password;

            if (String.IsNullOrEmpty(_currentserver.RLTrim())) _currentserver = "?";
            if (String.IsNullOrEmpty(_currentdatabase.RLTrim())) _currentdatabase = "?";
            if (String.IsNullOrEmpty(_currentuid.RLTrim())) _currentuid = "?";
            if (String.IsNullOrEmpty(_currentpwd.RLTrim())) _currentpwd = "?";

            return String.Format(_pattern, _currentserver, _currentdatabase, _currentuid, _currentpwd);
        }

        #endregion

    }
}
