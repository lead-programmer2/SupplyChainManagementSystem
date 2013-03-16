using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Personalized message box methods derived from DevComponents.DotNetBar.MessageBoxEx class.
    /// </summary>
    public class MsgBoxEx : MessageBoxEx
    {

        #region Alert

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Alert(string text)
        { return Alert(text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Alert(IWin32Window owner, string text)
        { return Alert(owner, text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Alert(string text, string caption)
        { return Alert(text, caption, MessageBoxButtons.OK); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Alert(IWin32Window owner, string text, string caption)
        { return Alert(owner, text, caption, MessageBoxButtons.OK); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Alert(string text, string caption, MessageBoxButtons buttons)
        { return Alert(text, caption, buttons, MessageBoxDefaultButton.Button1); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Alert(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        { return Alert(owner, text, caption, buttons, MessageBoxDefaultButton.Button1); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Alert(string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
        { return Show("<font face=\"tahoma\">" + text + "</font>", caption, buttons, MessageBoxIcon.Error, defaultbutton); }

        /// <summary>
        /// Shows a message box in error mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Alert(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
        { return Show(owner, "<font face=\"tahoma\">" + text + "</font>", caption, buttons, MessageBoxIcon.Error, defaultbutton); }

        #endregion

        #region Ask

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Ask(string text)
        { return Ask(text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Ask(IWin32Window owner, string text)
        { return Ask(owner, text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Ask(string text, string caption)
        { return Ask(text, caption, MessageBoxIcon.Question); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Ask(IWin32Window owner, string text, string caption)
        { return Ask(owner, text, caption, MessageBoxIcon.Question); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static DialogResult Ask(string text, string caption, MessageBoxIcon icon)
        { return Ask(text, caption, icon, MessageBoxDefaultButton.Button2); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static DialogResult Ask(IWin32Window owner, string text, string caption, MessageBoxIcon icon)
        { return Ask(owner, text, caption, icon, MessageBoxDefaultButton.Button2); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Ask(string text, string caption, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        { return Show("<font face=\"tahoma\">" + text + "</font>", caption, MessageBoxButtons.YesNo, icon, defaultbutton); }

        /// <summary>
        /// Shows a message box in question mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Ask(IWin32Window owner, string text, string caption, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        { return Show(owner, "<font face=\"tahoma\">" + text + "</font>", caption, MessageBoxButtons.YesNo, icon, defaultbutton); }

        #endregion

        #region Inform

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Inform(string text)
        { return Inform(text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Inform(IWin32Window owner, string text)
        { return Inform(owner, text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Inform(string text, string caption)
        { return Inform(text, caption, MessageBoxButtons.OK); }

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Inform(IWin32Window owner, string text, string caption)
        { return Inform(owner, text, caption, MessageBoxButtons.OK); }

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Inform(string text, string caption, MessageBoxButtons buttons)
        { return Inform(text, caption, buttons, MessageBoxDefaultButton.Button1); }

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Inform(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        { return Inform(owner, text, caption, buttons, MessageBoxDefaultButton.Button1); }

        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Inform(string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
        { return Show("<font face=\"tahoma\">" + text + "</font>", caption, buttons, MessageBoxIcon.Information, defaultbutton); }
        
        /// <summary>
        /// Shows a message box in information mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Inform(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
        { return Show(owner, "<font face=\"tahoma\">" + text + "</font>", caption, buttons, MessageBoxIcon.Information, defaultbutton); }

        #endregion

        #region Shout

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Shout(string text)
        { return Shout(text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Shout(IWin32Window owner, string text)
        { return Shout(owner, text, Application.ProductName); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Shout(string text, string caption)
        { return Shout(text, caption, MessageBoxButtons.OK); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Shout(IWin32Window owner, string text, string caption)
        { return Shout(owner, text, caption, MessageBoxButtons.OK); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Shout(string text, string caption, MessageBoxButtons buttons)
        { return Shout(text, caption, buttons, MessageBoxDefaultButton.Button1); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Shout(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        { return Shout(owner, text, caption, buttons, MessageBoxDefaultButton.Button1); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Shout(string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
        { return Show("<font face=\"tahoma\">" + text + "</font>", caption, buttons, MessageBoxIcon.Exclamation, defaultbutton); }

        /// <summary>
        /// Shows a message box in exclamation mode on the user's screen.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Shout(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
        { return Show(owner, "<font face=\"tahoma\">" + text + "</font>", caption, buttons, MessageBoxIcon.Exclamation, defaultbutton); }

        #endregion

    }
}
