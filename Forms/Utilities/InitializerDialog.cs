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
    public partial class InitializerDialog : Form
    {
        /// <summary>
        /// Creates a new instance of InitializerDialog.
        /// </summary>
        public InitializerDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the notification text that the dialog displays.
        /// </summary>
        public string Message
        {
            get { return lblNotification.Text; }
            set { lblNotification.Text = value; }
        }

        private void InitializerDialog_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
        }
    }
}
