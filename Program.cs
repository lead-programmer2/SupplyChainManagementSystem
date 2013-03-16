using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public static class Program
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Form _startupform = null;

        /// <summary>
        /// Gets the application's start-up form.
        /// </summary>
        public static Form StartUpForm
        {
            get { return _startupform; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBoxEx.ButtonsDividerVisible = false;
            StyleManager.Style = eStyle.Office2010Silver;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _startupform = new LoginDialog();
            Application.Run(_startupform);
        }
    }
}
