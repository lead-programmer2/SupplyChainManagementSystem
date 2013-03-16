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
    /// Application database restore point information.
    /// </summary>
    public class RestorePointInfo
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of RestorePointInfo.
        /// </summary>
        /// <param name="restorepointid"></param>
        public RestorePointInfo(long restorepointid)
        {
            _id = restorepointid;

            string _path = Application.StartupPath + "\\Xml\\restorepoints.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataRow[] _rows = _table.Select("[DetailId] = " + _id.ToString());
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (VisualBasic.IsDate(_row["DateAndTime"])) _asof = VisualBasic.CDate(_row["DateAndTime"]);
                    if (!Materia.IsNullOrNothing(_row["Filename"])) _filename = _row["Filename"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Server"])) _server = _row["Server"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Database"])) _database = _row["Database"].ToString();
                }
                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTime _asof = DateTime.Now;

        /// <summary>
        /// Gets the restore points time stamp.
        /// </summary>
        public DateTime AsOf
        {
            get { return _asof; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _database = "";

        /// <summary>
        /// Gets the source database for the current restore point.
        /// </summary>
        public string Database
        {
            get { return _database; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _filename = "";

        /// <summary>
        /// Gets the restore points database filename.
        /// </summary>
        public string Filename
        {
            get { return _filename; }
        }

       [DebuggerBrowsable(DebuggerBrowsableState.Never)]
       private long _id = 0;

       public long Id
       {
           get { return _id; }
       }

       [DebuggerBrowsable(DebuggerBrowsableState.Never)]
       private string _server = "";

        /// <summary>
        /// Gets the source database server for the current restore point.
        /// </summary>
       public string Server
       {
           get { return _server; }
       }

        #endregion

        #region Methods

       public override string ToString()
       {
           return _filename;
       }

       #endregion

    }
}
