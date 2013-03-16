using Development.Materia;
using Development.Materia.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Application settings.
    /// </summary>
    public static class GlobalSettings
    {

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string _address = "";

        /// <summary>
        /// Gets the current selected company's address.
        /// </summary>
        public static string Address
        {
            get { return _address; }
        }

        /// <summary>
        /// Gets or sets whether the automatic backup feature of the application is activated or not.
        /// </summary>
        public static bool AutomaticBackupEnabled
        {
            get { return VisualBasic.CBool(VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "AutoBackup", 0)); }
            set { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "AutoBackup", value ? 1 : 0); }
        }

        /// <summary>
        /// Gets or sets whether the automatic backup feature (second instance) of the application is activated or not.
        /// </summary>
        public static bool AutomaticBackupEnabled2
        {
            get { return VisualBasic.CBool(VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "AutoBackup2", 0)); }
            set { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "AutoBackup2", value ? 1 : 0); }
        }

        /// <summary>
        /// Gets or sets the local or network output path for the automatic backup.
        /// </summary>
        public static string AutomaticBackupPath
        {
            get { return VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "AutoBackupPath", "").ToString(); }
            set { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "AutoBackupPath", value); }
        }

        /// <summary>
        /// Gets or sets the automatic backup's first occurence.
        /// </summary>
        public static DateTime AutomaticBackupTime1
        {
            get
            {
                string _timepart = VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "AutoBackupTime1", "12:00:00 AM").ToString();
                DateTime _backuptime = VisualBasic.CDate(DateTime.Now.ToShortDateString() + " " + _timepart);
                
                return _backuptime;
            }
            set
            { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName,"AutoBackupTime1", VisualBasic.Format(value, "hh:mm:ss tt")); }
        }

        /// <summary>
        /// Gets or sets the automatic backup's second occurence.
        /// </summary>
        public static DateTime AutomaticBackupTime2
        {
            get
            {
                string _timepart = VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "AutoBackupTime2", "12:00:00 AM").ToString();
                DateTime _backuptime = VisualBasic.CDate(DateTime.Now.ToShortDateString() + " " + _timepart);

                return _backuptime;
            }
            set
            { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "AutoBackupTime2", VisualBasic.Format(value, "hh:mm:ss tt")); }
        }

        /// <summary>
        /// Gets or sets the idle time (in min.) of the application to when the system lock dialog will show in the user's screen. Setting this to zero (or less) will turn off the automatic system lock. 
        /// </summary>
        public static int AutomaticLockTime
        {
            get { return VisualBasic.CInt(VisualBasic.GetSetting(Application.ProductName, Application.ProductName, "IdleTime", 0)); }
            set { VisualBasic.SaveSetting(Application.ProductName, Application.ProductName, "IdleTime", value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static long _cashadvanceaccountcode = 0;

        /// <summary>
        /// Gets the current selected company's cash advance account.
        /// </summary>
        public static long CashAdvanceAccountCode
        {
            get { return _cashadvanceaccountcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static CompanyInfo _company = null;

        /// <summary>
        /// Gets the current selected company.
        /// </summary>
        public static CompanyInfo Company
        { 
            get { return _company; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Image _companylogo = Properties.Resources.CSPTColored;

        /// <summary>
        /// Gets the current selected company's logo.
        /// </summary>
        public static Image CompanyLogo
        {
            get { return _companylogo; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string _country = "";

        /// <summary>
        /// Gets teh current selected company's residing company.
        /// </summary>
        public static string Country
        {
            get { return _country; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string _email = "";

        /// <summary>
        /// Gets the current selected company's email address.
        /// </summary>
        public static string Email
        {
            get { return _email; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string _fax = "";

        /// <summary>
        /// Gets the current selected company's fax number.
        /// </summary>
        public static string Fax
        {
            get { return _fax; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string _mobile = "";

        /// <summary>
        /// Gets the current selected company's mobile number.
        /// </summary>
        public static string Mobile
        {
            get { return _mobile; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string _phone = "";

        /// <summary>
        /// Gets the current selected company's phone number.
        /// </summary>
        public static string Phone
        {
            get { return _phone; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static long _rawmaterialaccountcode = 0;

        /// <summary>
        /// Gets the current selected company's raw materials account.
        /// </summary>
        public static long RawMaterialAccountCode
        {
            get { return _rawmaterialaccountcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Image _reportlogo = Properties.Resources.CSPTBlackAndWhite;

        /// <summary>
        /// Gets the current selected company's report template logo.
        /// </summary>
        public static Image ReportLogo
        {
            get { return _reportlogo; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static long _rollforwardaccountcode = 0;

        /// <summary>
        /// Gets the current selected company's roll forward account.
        /// </summary>
        public static long RollForwardAccountCode
        {
            get { return _rollforwardaccountcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static long _stockadjustmentaccountcode = 0;

        /// <summary>
        /// Gets the current selected company's stock adjustment account.
        /// </summary>
        public static long StockAdjustmentAccountCode
        {
            get { return _stockadjustmentaccountcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static long _stockconsumptionaccountcode = 0;

        /// <summary>
        /// Gets the current selected company's stock consumption account.
        /// </summary>
        public static long StockConsumptionAccountCode
        {
            get { return _stockconsumptionaccountcode; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static long _unallocatedpaymentaccountcode = 0;

        /// <summary>
        /// Gets the current selected company's unallocated payments account.
        /// </summary>
        public static long UnallocatedPaymentAccountCode
        {
            get { return _unallocatedpaymentaccountcode; }
        }

        #endregion

        #region Methods

        private static void ClearInformation()
        {
            _cashadvanceaccountcode = 0; _company = null;
            _companylogo = Properties.Resources.CSPTColored;
            _country = ""; _email = ""; _fax = "";
            _mobile = ""; _phone = ""; _rawmaterialaccountcode = 0;
            _reportlogo = Properties.Resources.CSPTBlackAndWhite;
            _rollforwardaccountcode = 0; _stockadjustmentaccountcode = 0;
            _stockconsumptionaccountcode = 0; _unallocatedpaymentaccountcode = 0;
            Materia.RefreshAndManageCurrentProcess();
        }

        /// <summary>
        /// Retrieves the specified company's application settings and cofigurations.
        /// </summary>
        /// <param name="companycode"></param>
        public static void Refresh(string companycode)
        {
            ClearInformation(); _company = new CompanyInfo(companycode);
            Cache.SyncTable(SCMS.Connection, "settings");
            DataTable _settings = Cache.GetCachedTable("settings");

            if (_settings != null)
            {
                DataRow[] _rows = _settings.Select("[Company] LIKE '" + companycode.ToSqlValidString(true) + "'");

                if (_rows.Length <= 0)
                {
                    object[] _values = new object[_settings.Columns.Count];
                    DataColumnCollection _cols = _settings.Columns;

                    _values[_cols["Company"].Ordinal] = companycode;
                    _values[_cols["Address"].Ordinal] = "";
                    _values[_cols["Country"].Ordinal] = "";
                    _values[_cols["Phone"].Ordinal] = "";
                    _values[_cols["Mobile"].Ordinal] = "";
                    _values[_cols["Fax"].Ordinal] = "";
                    _values[_cols["Email"].Ordinal] = "";
                    _values[_cols["CompanyLogo"].Ordinal] = Properties.Resources.CSPTColored.ToByteArray();
                    _values[_cols["ReportLogo"].Ordinal] = Properties.Resources.CSPTBlackAndWhite.ToByteArray();
                    
                    Cache.SyncTable(SCMS.Connection, "accounts");
                    DataTable _accounts = Cache.GetCachedTable("accounts");
                    if (_accounts != null)
                    {
                        long _accountcode = 0; string _accountname = "Raw materials & consumables - spare parts";
                        DataRow[] _selrows = _accounts.Select("[AccountName] LIKE '" + _accountname.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            _accountcode = (long)_selrows[0]["AccountCode"];
                            _values[_cols["RawMaterialAccountCode"].Ordinal] = _accountcode;
                        }

                        _accountname = "Cash advances";
                        _selrows = _accounts.Select("[AccountName] LIKE '" + _accountname.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            _accountcode = (long)_selrows[0]["AccountCode"];
                            _values[_cols["CashAdvanceAccountCode"].Ordinal] = _accountcode;
                        }

                        _accountname = "Parts consumption";
                        _selrows = _accounts.Select("[AccountName] LIKE '" + _accountname.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            _accountcode = (long)_selrows[0]["AccountCode"];
                            _values[_cols["StockConsumptionAccountCode"].Ordinal] = _accountcode;
                        }

                        _accountname = "Stock adjustments";
                        _selrows = _accounts.Select("[AccountName] LIKE '" + _accountname.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            _accountcode = (long)_selrows[0]["AccountCode"];
                            _values[_cols["StockAdjustmentAccountCode"].Ordinal] = _accountcode;
                        }

                        _accountname = "Unallocated payments / cheques";
                        _selrows = _accounts.Select("[AccountName] LIKE '" + _accountname.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            _accountcode = (long)_selrows[0]["AccountCode"];
                            _values[_cols["UnallocatedPaymentAccountCode"].Ordinal] = _accountcode;
                        }

                        _accountname = "Result carried forward previous years";
                        _selrows = _accounts.Select("[AccountName] LIKE '" + _accountname.ToSqlValidString(true) + "'");
                        if (_selrows.Length > 0)
                        {
                            _accountcode = (long)_selrows[0]["AccountCode"];
                            _values[_cols["RollForwardAccountCode"].Ordinal] = _accountcode;
                        }
                    }

                    _values[_cols["DateCreated"].Ordinal] = DateTime.Now;
                    _settings.Rows.Add(_values);

                    QueryGenerator _generator = new QueryGenerator(_settings);
                    _generator.ExcludedFields.Add("LastModified");
                    string _query = _generator.ToString();

                    if (!String.IsNullOrEmpty(_query.RLTrim()))
                    {
                        QueResult _result = Que.Execute(SCMS.Connection, _query);
                        if (String.IsNullOrEmpty(_result.Error.RLTrim())) _settings.AcceptChanges();
                        _result.Dispose(); _result = null; Materia.RefreshAndManageCurrentProcess();
                    }
                }

                _rows = _settings.Select("[Company] LIKE '" + companycode.ToSqlValidString(true) + "'");
                if (_rows.Length > 0)
                {
                    DataRow _row = _rows[0];
                    if (!Materia.IsNullOrNothing(_row["Address"])) _address = _row["Address"].ToString();
                    if (VisualBasic.IsNumeric(_row["CashAdvanceAccountCode"])) _cashadvanceaccountcode = (long)_row["CashAdvanceAccountCode"];
                    if (!Materia.IsNullOrNothing(_row["CompanyLogo"]))
                    {
                        try { _companylogo = ((byte[])_row["CompanyLogo"]).ToImage(); }
                        catch { }
                    }
                    if (!Materia.IsNullOrNothing(_row["Country"])) _country = _row["Country"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Email"])) _email = _row["Email"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Fax"])) _fax = _row["Fax"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Mobile"])) _mobile = _row["Mobile"].ToString();
                    if (!Materia.IsNullOrNothing(_row["Phone"])) _phone = _row["Phone"].ToString();
                    if (VisualBasic.IsNumeric(_row["RawMaterialAccountCode"])) _rawmaterialaccountcode = (long)_row["RawMaterialAccountCode"];
                    if (!Materia.IsNullOrNothing(_row["ReportLogo"]))
                    {
                        try { _reportlogo = ((byte[])_row["ReportLogo"]).ToImage(); }
                        catch { }
                    }
                    if (VisualBasic.IsNumeric(_row["RollForwardAccountCode"])) _rollforwardaccountcode = (long)_row["RollForwardAccountCode"];
                    if (VisualBasic.IsNumeric(_row["StockAdjustmentAccountCode"])) _stockadjustmentaccountcode = (long)_row["StockAdjustmentAccountCode"];
                    if (VisualBasic.IsNumeric(_row["StockConsumptionAccountCode"])) _stockconsumptionaccountcode = (long)_row["StockConsumptionAccountCode"];
                    if (VisualBasic.IsNumeric(_row["UnallocatedPaymentAccountCode"])) _unallocatedpaymentaccountcode = (long)_row["UnallocatedPaymentAccountCode"];
                }
            }
        }

        /// <summary>
        /// Asynchornously retrieves the specified company's application settings and cofigurations.
        /// </summary>
        /// <returns></returns>
        public static IAsyncResult RefreshAsync(string companycode)
        {
            Action<string> _delegate = new Action<string>(Refresh);
            return _delegate.BeginInvoke(companycode, null, _delegate);
        }

        #endregion

    }
}
