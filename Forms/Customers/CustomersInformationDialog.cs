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
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class CustomersInformationDialog : Office2007Form
    {
        /// <summary>
        /// Creates a new instance of CustomersInformationDialog.
        /// </summary>
        public CustomersInformationDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of CustomersInformationDialog.
        /// </summary>
        /// <param name="code"></param>
        public CustomersInformationDialog(string code)
        {
            InitializeComponent();

            _customercode = code; _isnew = false;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _customercode = "";

        /// <summary>
        /// Gets the customer code of the current update customer.
        /// </summary>
        public string CustomerCode
        {
            get { return _customercode; }
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isinbackground = false;

        /// <summary>
        /// Gets whether the current form is active but resides in the backgound only or not.
        /// </summary>
        public bool IsInBackground
        {
            get { return _isinbackground; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _withupdates = false;

        /// <summary>
        /// Gets whether the current banking company conducts any updates while it is open.
        /// </summary>
        public bool WithUpdates
        {
            get { return _withupdates; }
        }

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

        private void AttachEditorHandler()
        {
            txtAddress.TextChanged += new EventHandler(Field_Edited);
            txtCreditLimit.ValueChanged += new EventHandler(Field_Edited);
            txtCustomerName.TextChanged += new EventHandler(Field_Edited);
            txtEmail.TextChanged += new EventHandler(Field_Edited);
            txtFax.TextChanged += new EventHandler(Field_Edited);
            txtMarginPercent.ValueChanged += new EventHandler(Field_Edited);
            txtMobile.TextChanged += new EventHandler(Field_Edited);
            txtNotes.TextChanged += new EventHandler(Field_Edited);
            txtPhone.TextChanged += new EventHandler(Field_Edited);
            txtPoc.TextChanged += new EventHandler(Field_Edited);
            cboBankAccount.SelectedValueChanged += new EventHandler(Field_Edited);
            cboCountry.SelectedValueChanged += new EventHandler(Field_Edited);
            cboCustomerGroup.SelectedValueChanged += new EventHandler(Field_Edited);
            cboDebtorAccount.SelectedValueChanged += new EventHandler(Field_Edited);
            cboLocation.SelectedValueChanged += new EventHandler(Field_Edited);
            cboPaymentTerms.SelectedValueChanged += new EventHandler(Field_Edited);
            cboPrepaymentAccount.SelectedValueChanged += new EventHandler(Field_Edited);
            chkActive.CheckedChanged += new EventHandler(Field_Edited);
        }

        /// <summary>
        /// Clears the information fields for the current customer rendering it in a new instance mode.
        /// </summary>
        public void ClearInformation()
        {
            if (!_isnew) _isnew = true;
            if (_updated) _updated = false;
            if (_isshown) _isshown = false;
            if (_isinbackground) _isinbackground = false;

            Text = Text.Replace(" *", "").Replace("*", "");

            txtAddress.Text = ""; txtCreditLimit.Value = 0; txtCustomerName.Text = "";
            txtCustomerNo.Text = ""; txtEmail.Text = ""; txtFax.Text = "";
            txtMarginPercent.Value = 0; txtMobile.Text = ""; txtNotes.Text = "";
            txtPhone.Text = ""; txtPoc.Text = "";

            string _seriesno = SCMS.GetTableSeriesNumber("customers");
            txtCustomerNo.Text = _seriesno;

            try { cboBankAccount.SelectedIndex = -1; }
            catch { }

            try { cboCountry.SelectedIndex = -1; }
            catch { }

            try { cboCustomerGroup.SelectedIndex = -1; }
            catch { }

            try { cboDebtorAccount.SelectedIndex = -1; }
            catch { }

            try { cboLocation.SelectedIndex = -1; }
            catch { }

            try { cboPaymentTerms.SelectedIndex = -1; }
            catch { }

            try { cboPrepaymentAccount.SelectedIndex = -1; }
            catch { }

            tbctrl.SelectedTab = tbGeneral;
            tbCustomerLedger.Visible = false; tbPayments.Visible = false;
            tbReceivables.Visible = false;
        }

        /// <summary>
        /// Loads the customer information into this dialog using the specified customer code.
        /// </summary>
        /// <param name="code"></param>
        public void LoadCustomerInformation(string code)
        {

        }

        /// <summary>
        /// Forces the dialog to stay silently in the background.
        /// </summary>
        public void StayInBackground()
        { _withupdates = false; _updated = false; _isinbackground = true; }

        private void CustomersInformationDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            SCMS.Validators.Add(this); AttachEditorHandler();

            txtCustomerNo.ReadOnly = true;
            
            grdCustomerLedger.InitializeAppearance(); grdMisc.InitializeAppearance();
            grdPayments.InitializeAppearance(); grdReceivables.InitializeAppearance();

            txtCreditLimit.ShowUpDown = false; txtCreditLimit.MinValue = 0;
            txtCreditLimit.AllowEmptyState = false; txtCreditLimit.DisplayFormat = "N2";

            txtMarginPercent.ShowUpDown = false; txtMarginPercent.MinValue = 0;
            txtMarginPercent.AllowEmptyState = false; txtMarginPercent.DisplayFormat = "N2";

            cboDebtorAccount.LoadAccounts(); cboPrepaymentAccount.LoadAccounts();
            cboLocation.LoadLocations(); cboCountry.LoadCountries();
            cboCustomerGroup.LoadCustomerGroups(); cboBankAccount.LoadBankAccounts();
            cboPaymentTerms.LoadPaymentTerms();

            txtAddress.SetAsRequired(); txtCustomerName.SetAsRequired();
            cboCountry.SetAsRequired(); cboBankAccount.SetAsRequired();
            cboCustomerGroup.SetAsRequired(); cboDebtorAccount.SetAsRequired();
            cboLocation.SetAsRequired(); cboPaymentTerms.SetAsRequired(); 
            cboPrepaymentAccount.SetAsRequired();

            if (_isnew) ClearInformation();
            else LoadCustomerInformation(_customercode);
        }

        private void Field_Edited(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (!_isshown) return;

            Validator _validator = SCMS.Validators[this];
            if (_validator != null) _validator.ErrorProvider.SetError((Control)sender, "");

            if (!_updated) _updated = true;
            this.MarkAsEdited();
        }

        private void tbctrl_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        { if (SCMS.Validators.Contains(this)) SCMS.Validators[this].Highlighter.UpdateHighlights(); }

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }


    }
}
