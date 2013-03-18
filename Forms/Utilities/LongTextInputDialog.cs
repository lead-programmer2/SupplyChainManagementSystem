using DevComponents.DotNetBar;
using Development.Materia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class LongTextInputDialog : Office2007Form
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of LongTextInputDialog.
        /// </summary>
        public LongTextInputDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the entry box's watermark text.
        /// </summary>
        public string EntryWatermark
        {
            get { return txtRemarks.WatermarkText; }
            set { txtRemarks.WatermarkText = value; }
        }

        /// <summary>
        /// Gets or sets the text value in the dialog's entry box.
        /// </summary>
        public string TextValue
        {
            get { return txtRemarks.Text; }
            set { txtRemarks.Text = value; }
        }

        #endregion

        #region FormEvents

        private void LongTextInputDialog_Load(object sender, EventArgs e)
        { this.ManageOnDispose(); SCMS.Validators.Add(this); }

        #endregion

        #region ControlEvents
        
        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); }

        private void btnOK_Click(object sender, EventArgs e)
        { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); }
    
        #endregion

    }
}
