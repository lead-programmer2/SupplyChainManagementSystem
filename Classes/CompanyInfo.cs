using Development.Materia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{

    /// <summary>
    /// Accessible company information class.
    /// </summary>
    public class CompanyInfo
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of CompanyInfo.
        /// </summary>
        /// <param name="code"></param>
        public CompanyInfo(string code)
        {
            _company = code; _name = "";

            Action<IDbConnection, string> _delegate = new Action<IDbConnection, string>(Cache.SyncTable);
            IAsyncResult _result = _delegate.BeginInvoke(SCMS.Connection, "companies", null, _delegate);
            while (!_result.IsCompleted)
            { Thread.Sleep(1); Application.DoEvents(); }
            _delegate.EndInvoke(_result);

            DataTable _table = Cache.GetCachedTable("companies");

            if (_table != null)
            {
                DataRow[] _rows = _table.Select("[Company] LIKE '" + _company.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    if (!Materia.IsNullOrNothing(_rows[0]["Name"])) _name = _rows[0]["Name"].ToString();
                }
            }
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _company = "";

        /// <summary>
        /// Gets the assigned company abbreviation / code.
        /// </summary>
        public string Company
        {
            get { return _company; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _name = "";

        /// <summary>
        /// Gets the name of the company.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return _company;
        }

        #endregion

    }

    /// <summary>
    /// Collection of accesssible comapny information.
    /// </summary>
    public class CompanyInfoCollection : CollectionBase
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of CompanyInfoCollection.
        /// </summary>
        /// <param name="user"></param>
        public CompanyInfoCollection(SystemUserInfo user)
        { _systemuser = user; }


        #endregion

        #region Properties

        /// <summary>
        /// Gets the company information at specified index of the collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CompanyInfo this[int index]
        {
            get { return (CompanyInfo)List[index]; }
        }

        /// <summary>
        /// Gets a company information with the specified company code from the collection.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public CompanyInfo this[string company]
        {
            get { return GetCompany(company); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SystemUserInfo _systemuser = null;

        /// <summary>
        /// Gets the collection's owner.
        /// </summary>
        public SystemUserInfo SystemUser
        {
            get { return _systemuser; }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Hashtable _companytable = new Hashtable();

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new company information into the collection.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int Add(CompanyInfo company)
        {
            int _index = List.Add(company);
            _companytable.Add(company.Name, company);
            return _index; 
        }

        /// <summary>
        /// Adds a new company information into the collection.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public CompanyInfo Add(string company)
        {
            CompanyInfo _info = GetCompany(company);

            if (_info == null)
            {
                int _index = Add(new CompanyInfo(company));
                _info = (CompanyInfo)List[_index];
            }

            return _info;
        }

        /// <summary>
        /// Validates whether the specified company information already exists within the collection or not.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool Contains(CompanyInfo company)
        { return List.Contains(company); }

        /// <summary>
        /// Validates whether a certain company information with the specified name already exists within the collection or not.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool Contains(string company)
        { return _companytable.ContainsKey(company); }

        private CompanyInfo GetCompany(string company)
        {
            CompanyInfo _info = null;

            if (_companytable.ContainsKey(company)) _info = (CompanyInfo)_companytable[company];

            return _info;
        }

        protected override void OnClear()
        {
            _companytable.Clear();  base.OnClear();
        }

        /// <summary>
        /// Removes the specified company information from the collection.
        /// </summary>
        /// <param name="company"></param>
        public void Remove(CompanyInfo company)
        {
            if (Contains(company))
            {
                if (_companytable.ContainsKey(company.Company)) _companytable.Remove(company.Company);
                List.Remove(company);
            }
        }

        /// <summary>
        /// Removes a company information with the specified company code from the collection.
        /// </summary>
        /// <param name="company"></param>
        public void Remove(string company)
        {
            CompanyInfo _company = GetCompany(company);
            if (_company != null) Remove(_company);
        }

        #endregion

    }

}
