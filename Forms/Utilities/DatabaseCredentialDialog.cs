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
    /// <summary>
    /// Database server credential entry dialog.
    /// </summary>
    public partial class DatabaseCredentialDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of DatabaseCredentialDialog.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        public DatabaseCredentialDialog(string server, string database)
        {
            InitializeComponent();

            _server = server; _database = database;
        }

        /// <summary>
        /// Creates a new instance of DatabaseCredentialDialog.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public DatabaseCredentialDialog(string server, string database, string uid, string pwd)
        {
            InitializeComponent();

            _server = server; _database = database;
            _userid = uid; _password = pwd;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _database = "";

        /// <summary>
        /// Gets the current evaluated server database.
        /// </summary>
        public string Database
        {
            get { return _database; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _password = "";

        /// <summary>
        /// Gets the current evaluated server database credential password.
        /// </summary>
        public string Password
        {
            get { return _password; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _server = "";

        /// <summary>
        /// Gets the current evaluated server IP address or hostname.
        /// </summary>
        public string Server
        {
            get { return _server; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _userid = "";

        /// <summary>
        /// Gets the current evaluated server database credential log on id.
        /// </summary>
        public string UserId
        {
            get { return _userid; }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _cancelled = false;

        #endregion

        #region FormEvents

        private void DatabaseCredentialDialog_FormClosing(object sender, FormClosingEventArgs e)
        { _cancelled = (!e.Cancel); }

        private void DatabaseCredentialDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this);

            txtServer.Text = Server; txtServer.ReadOnly = true;
            txtDatabase.Text = Database; txtDatabase.ReadOnly = true;

            txtUserId.Text = UserId; txtUserId.SetAsRequired();
            
            txtPassword1.PasswordChar = Materia.PasswordCharacter;
            txtPassword2.PasswordChar = Materia.PasswordCharacter;

            txtPassword1.SetAsRequired(); txtPassword1.Text = Password;
            txtPassword2.SetAsRequired(); txtPassword2.Text = Password;
        }

        private void DatabaseCredentialDialog_Shown(object sender, EventArgs e)
        {
            if (txtUserId.Enabled) txtUserId.Focus();
        }

        #endregion

        #region ControlEvents

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (!btnTestConnection.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtUserId, !String.IsNullOrEmpty(txtUserId.Text.RLTrim()), "Please specify database server's log on account id.")) return;

            if (!Materia.Valid(_validator, txtPassword1, !String.IsNullOrEmpty(txtPassword1.Text.RLTrim()), "Please specify database server's log on account password.")) return;

            if (!Materia.Valid(_validator, txtPassword2, string.Compare(txtPassword1.Text, txtPassword2.Text) == 0 &&
                                                         txtPassword1.Text == txtPassword2.Text, "Passwords doesn't match each other.")) return;

            btnTestConnection.Enabled = false; btnOk.Enabled = false;
            txtUserId.ReadOnly = true; txtPassword1.ReadOnly = true; txtPassword2.ReadOnly = true;

            string _connectionstring = "SERVER=" + txtServer.Text + ";DATABASE=" + txtDatabase.Text + ";UID=" + txtUserId.Text + ";PWD=" + txtPassword1.Text + ";";
            IDbConnection _connection = Development.Materia.Database.Database.CreateConnection(_connectionstring);

            Func<IDbConnection, bool> _delegate = new Func<IDbConnection, bool>(Materia.CanConnect);
            IAsyncResult _result = _delegate.BeginInvoke(_connection, null, _delegate);

            while (!_result.IsCompleted &&
                  !_cancelled)
            {
                Thread.Sleep(1); Application.DoEvents();
            }

            Materia.RefreshAndManageCurrentProcess();

            if (_cancelled)
            {
                if (!_result.IsCompleted)
                {
                    try { _result = null; }
                    catch { }
                    finally { Materia.RefreshAndManageCurrentProcess(); }
                }
            }
            else
            {
                bool _connected = _delegate.EndInvoke(_result);

                if (_connected) MsgBoxEx.Inform("Connection has been successfully established.", "Test Database Connection");
                else MsgBoxEx.Alert("Failed to establish a connection using the specified configurations.", "Connection Failed");
            }

            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    try { _connection.Close(); }
                    catch { }
                }

                try { _connection.Dispose(); }
                catch { }
                finally
                { _connection = null; Materia.RefreshAndManageCurrentProcess(); }
            }

            btnTestConnection.Enabled = true; btnOk.Enabled = true;
            txtUserId.ReadOnly = false; txtPassword1.ReadOnly = false; txtPassword2.ReadOnly = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled) Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!btnOk.Enabled) return;

            Validator _validator = SCMS.Validators[this];

            if (!Materia.Valid(_validator, txtUserId, !String.IsNullOrEmpty(txtUserId.Text.RLTrim()), "Please specify database server's log on account id.")) return;

            if (!Materia.Valid(_validator, txtPassword1, !String.IsNullOrEmpty(txtPassword1.Text.RLTrim()), "Please specify database server's log on account password.")) return;

            if (!Materia.Valid(_validator, txtPassword2, string.Compare(txtPassword1.Text, txtPassword2.Text) == 0 &&
                                                         txtPassword1.Text == txtPassword2.Text, "Passwords doesn't match each other.")) return;

            _userid = txtUserId.Text; _password = txtPassword1.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK; Close();
        }

        #endregion

    }
}
