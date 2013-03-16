using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Popup animation enumerations.
    /// </summary>
    public enum PopupAnimation
    {
        /// <summary>
        /// Uses a fade effect.
        /// </summary>
        Blend = 524288,
        /// <summary>
        /// Animates the window from bottom to top. This flag can be used with roll or slide animation.
        /// </summary>
        BottomToTop = 8,
        /// <summary>
        /// Makes the window appear to collapse inward if it is hiding or expand outward if the window is showing.
        /// </summary>
        Center = 10,
        /// <summary>
        /// Animates the window from left to right. This flag can be used with roll or slide animation.
        /// </summary>
        LeftToRight = 1,
        /// <summary>
        /// Uses no animation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Animates the window from right to left. This flag can be used with roll or slide animation.
        /// </summary>
        RightToLeft = 2,
        /// <summary>
        /// Uses a roll animation.
        /// </summary>
        Roll = 1048576,
        /// <summary>
        /// Uses a slide animation.
        /// </summary>
        Slide = 262144,
        /// <summary>
        /// Uses a default animation.
        /// </summary>
        SystemDefault = 2097152,
        /// <summary>
        /// Animates the window from right to left. This flag can be used with roll or slide animation.
        /// </summary>
        TopToBottom = 4
    }

    /// <summary>
    /// Control pop-up managing class.
    /// </summary>
    [ToolboxItem(false)]
    public partial class Popup : ToolStripDropDown
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of Popup.
        /// </summary>
        /// <param name="control"></param>
        public Popup(Control control)
        {
            if (control == null) throw new ArgumentNullException("control");
            _content = control;  FocusOnOpen = true;  AcceptAlt = true;

            _showinganimation = PopupAnimation.SystemDefault;
            _hidinganimation = PopupAnimation.None;
            _animationduration = 100; _ischildpopupopen = false;

            InitializeComponent();
           
            AutoSize = false;  DoubleBuffered = true; ResizeRedraw = true;
            _host = new ToolStripControlHost(_content);
            Padding =  System.Windows.Forms.Padding.Empty;
            Margin = System.Windows.Forms.Padding.Empty;
            _host.Padding = System.Windows.Forms.Padding.Empty;
            _host.Margin = System.Windows.Forms.Padding.Empty;

            MinimumSize = _content.MinimumSize;
            _content.MinimumSize = _content.Size;
            MaximumSize = _content.MaximumSize;
            _content.MaximumSize = _content.Size;
            Size = _content.Size; TabStop = true;
            _content.TabStop = true;
            _content.Location = Point.Empty;
            Items.Add(_host);

            _content.Disposed += Content_Disposed;
            _content.RegionChanged += Content_RegionChanged;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _acceptalt = true;

        /// <summary>
        /// Gets or sets whether to popped-up control accepts Alt key or not.
        /// </summary>
        public bool AcceptAlt
        {
            get { return _acceptalt; }
            set { _acceptalt = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _animationduration = 0;

        /// <summary>
        /// Gets or sets the animetion duration time.
        /// </summary>
        public int AnimationDuration
        {
            get { return _animationduration; }
            set { _animationduration = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Popup _childpopup = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Control _content = null;

        /// <summary>
        /// Gets or sets control to be popped-up.
        /// </summary>
        public Control Content
        {
            get { return _content; }
            set { _content = value; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams _params = base.CreateParams;
                _params.ExStyle = _params.ExStyle | NativeMethods.WS_EX_NOACTIVATE;

                if (NonInteractive) _params.ExStyle = _params.ExStyle | NativeMethods.WS_EX_TRANSPARENT | NativeMethods.WS_EX_LAYERED | NativeMethods.WS_EX_TOOLWINDOW; 

                return _params;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _focusonopen = true;

        /// <summary>
        /// Gets or sets whether to put cursor focus on the contained control upon popup or not.
        /// </summary>
        public bool FocusOnOpen
        {
            get { return _focusonopen; }
            set { _focusonopen = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PopupAnimation _hidinganimation = PopupAnimation.None;

        /// <summary>
        /// Gets or sets ths hiding animation.
        /// </summary>
        public PopupAnimation HidingAnimation
        {
            get { return _hidinganimation; }
            set { _hidinganimation = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ToolStripControlHost _host = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _ischildpopupopen = false;

        [Browsable(false), EditorBrowsable( EditorBrowsableState.Never)]
        public bool IsChildPopupOpen
        {
            get { return _ischildpopupopen; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Size _maximumsize = new Size(0, 0);

        /// <summary>
        /// Gets or sets the maximum allowable size.
        /// </summary>
        public new Size MaximumSize
        {
            get { return _maximumsize; }
            set { _maximumsize = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Size _minimumsize = new Size(0, 0);

        /// <summary>
        /// Gets or sets minimum allowable size.
        /// </summary>
        public new Size MinimumSize
        {
            get { return _minimumsize; }
            set { _minimumsize = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _noninteractive = false;

        /// <summary>
        /// Gets or sets whether the popup accepts user interaction or not.
        /// </summary>
        public bool NonInteractive
        {
            get { return _noninteractive; }
            set
            {
                _noninteractive = value;
                if (IsHandleCreated) RecreateHandle();
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Control _opener = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Popup _ownerpopup = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PopupAnimation _popupanimation = PopupAnimation.None;

        /// <summary>
        /// Gets or sets the popup animation.
        /// </summary>
        public PopupAnimation PopupAnimation
        {
            get { return _popupanimation; }
            set { _popupanimation = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _resizable = false;

        /// <summary>
        /// Gets or sets whether the popup can be resized by the user or not.
        /// </summary>
        public bool Resizable
        {
            get { return _resizable; }
            set { _resizable = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _resizabletop = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _resizableleft = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PopupAnimation _showinganimation = PopupAnimation.SystemDefault;

        /// <summary>
        /// Gets or sets the actual popup animation.
        /// </summary>
        public PopupAnimation ShowingAnimation
        {
            get { return _showinganimation; }
            set { _showinganimation = value; }
        }

        #endregion

        #region Methods

        private void Content_Disposed(object sender, EventArgs e)
        { Content = null; Dispose(true); }

        private void Content_RegionChanged(object sender, EventArgs e)
        {
            if (Region != null)
            {
                Region.Dispose(); Region = null;
            }

            if (Content.Region != null) Region = Content.Region.Clone();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.UnmanagedCode)]
        private bool InternalProcessResizing(ref Message m, bool contentcontrol)
        {
            if (m.Msg == NativeMethods.WM_NCACTIVATE && m.WParam != IntPtr.Zero && _childpopup != null && _childpopup.Visible)
            {
                _childpopup.Hide();
            }

            if (!Resizable && !NonInteractive) return false;

            if (m.Msg == NativeMethods.WM_NCHITTEST) return OnNcHitTest(ref m, contentcontrol);
            else if (m.Msg == NativeMethods.WM_GETMINMAXINFO) return OnGetMinMaxInfo(ref m);

            return false;
        }

        protected override void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            _opener = null;
            if (_ownerpopup != null) _ownerpopup._ischildpopupopen = false;
            base.OnClosed(e);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            NativeMethods.MINMAXINFO minmax = (NativeMethods.MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.MINMAXINFO));
            if (!MaximumSize.IsEmpty)
            {
                minmax.maxtracksize = MaximumSize;
            }
            minmax.mintracksize = MinimumSize;
            Marshal.StructureToPtr(minmax, m.LParam, false);
            return true;
        }

        private bool OnNcHitTest(ref Message m, bool contentControl)
        {
            if (NonInteractive)
            {
                m.Result = new IntPtr(NativeMethods.HTTRANSPARENT);
                return true;
            }

            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            Point clientLocation = PointToClient(new Point(x, y));

            GripBounds gripBouns = new GripBounds(contentControl ? Content.ClientRectangle : ClientRectangle);
            IntPtr transparent = new IntPtr(NativeMethods.HTTRANSPARENT);

            if (_resizabletop)
            {
                if (_resizableleft && gripBouns.TopLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTTOPLEFT);
                    return true;
                }

                if (!_resizableleft && gripBouns.TopRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTTOPRIGHT);
                    return true;
                }

                if (gripBouns.Top.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTTOP);
                    return true;
                }
            }
            else
            {
                if (_resizableleft && gripBouns.BottomLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTBOTTOMLEFT);
                    return true;
                }

                if (!_resizableleft && gripBouns.BottomRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTBOTTOMRIGHT);
                    return true;
                }

                if (gripBouns.Bottom.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTBOTTOM);
                    return true;
                }
            }

            if (_resizableleft && gripBouns.Left.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTLEFT);
                return true;
            }

            if (!_resizableleft && gripBouns.Right.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : new IntPtr(NativeMethods.HTRIGHT);
                return true;
            }

            return false;
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            Size _suggestedsize = GetPreferredSize(Size.Empty);
            if (AutoSize && (_suggestedsize != Size)) Size = _suggestedsize;
            SetDisplayedItems(); base.OnLayout(e); Invalidate();
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if (Content != null)
            {
                if (Content.IsDisposed || Content.Disposing)
                {
                    e.Cancel = true; return;
                }

                Content_RegionChanged(Content, EventArgs.Empty); base.OnOpening(e);
            }
        }

        protected override void OnOpened(EventArgs e)
        {
            if (_ownerpopup != null) _ownerpopup._ischildpopupopen = true;
            if (FocusOnOpen &&
                Content != null) Content.Focus();
            base.OnOpened(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Content != null)
            {
                Content.MinimumSize = Size; Content.MinimumSize = Size;
                Content.Size = Size; Content.Location = Point.Empty;
            }

            base.OnSizeChanged(e);
        }

        protected override void OnVisibleChanged(System.EventArgs e)
        {
            base.OnVisibleChanged(e);
            if ((Visible & ShowingAnimation == PopupAnimation.None) | (Visible & HidingAnimation == PopupAnimation.None))
                return;
            NativeMethods.AnimationFlags flags = Visible ? NativeMethods.AnimationFlags.Roll : NativeMethods.AnimationFlags.Hide;
            PopupAnimation _flags = Visible ? ShowingAnimation : HidingAnimation;

            if ((_flags == PopupAnimation.SystemDefault))
            {
                if (SystemInformation.IsMenuAnimationEnabled)
                {
                    if (SystemInformation.IsMenuFadeEnabled)
                    {
                        _flags = PopupAnimation.Blend;
                    }
                    else
                    {
                        _flags = PopupAnimation.Slide | (Visible ? PopupAnimation.TopToBottom : PopupAnimation.BottomToTop);
                    }
                }
                else
                {
                    _flags = PopupAnimation.None;
                }
            }

            if ((_flags & (PopupAnimation.Blend | PopupAnimation.Center | PopupAnimation.Roll | PopupAnimation.Slide)) == PopupAnimation.None)
                return;

            if (_resizabletop)
            {
                if ((_flags & PopupAnimation.BottomToTop) != PopupAnimation.None)
                {
                    _flags = (_flags & ~PopupAnimation.BottomToTop) | PopupAnimation.TopToBottom;
                }
                else if ((_flags & PopupAnimation.TopToBottom) != PopupAnimation.None)
                {
                }
                else
                {
                    _flags = (_flags & ~PopupAnimation.TopToBottom) | PopupAnimation.BottomToTop;
                }
            }

            if (_resizableleft)
            {
                if ((_flags & PopupAnimation.RightToLeft) != PopupAnimation.None) _flags = (_flags & ~PopupAnimation.RightToLeft) | PopupAnimation.LeftToRight;
                else if ((_flags & PopupAnimation.LeftToRight) != PopupAnimation.None) _flags = (_flags & ~PopupAnimation.LeftToRight) | PopupAnimation.RightToLeft;
                else
                { }
            }

            flags = flags | (NativeMethods.AnimationFlags.Mask & (NativeMethods.AnimationFlags)Convert.ToInt32(_flags));
            NativeMethods.SetTopMost(this);
            NativeMethods.AnimateWindow(this, AnimationDuration, flags);
        }

        protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
        {
            if (AcceptAlt && ((keyData & Keys.Alt) == Keys.Alt))
            {
                if ((keyData & Keys.F4) != Keys.F4) return false;
                else Close();
            }

            bool processed = base.ProcessDialogKey(keyData);
            if (!processed && (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift)))
            {
                bool backward = (keyData & Keys.Shift) == Keys.Shift;
                Content.SelectNextControl(null, !backward, true, true, true);
            }

            return processed;
        }

        private void SetOwnerItem(Control control)
        {
            if (control == null) return;
            if (control is Popup)
            {
                Popup popupControl = control as Popup;
                _ownerpopup = popupControl;
                _ownerpopup._childpopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }
            else if (_opener == null) _opener = control;

            if (control.Parent != null) SetOwnerItem(control.Parent);
        }

        /// <summary>
        /// Shows the pop-up window below the specified control.
        /// </summary>
        /// <param name="control">The control below which the pop-up will be shown.</param>
        public void Show(Control control)
        {
            if (control == null) throw new ArgumentNullException("control");
            Rectangle _rectangle = new Rectangle(control.ClientRectangle.X - 3, control.ClientRectangle.Y, control.ClientRectangle.Width, control.ClientRectangle.Height);
            Show(control, _rectangle);
        }

        /// <summary>
        /// Shows the pop-up window below the specified area.
        /// </summary>
        /// <param name="area">The area of desktop below which the pop-up will be shown.</param>
        public void Show(Rectangle area)
        {
            _resizabletop = false; _resizableleft = false;
            Point location = new Point(area.Left, area.Top + area.Height);
            Rectangle screen__1 = Screen.FromControl(this).WorkingArea;
            if (location.X + Size.Width > (screen__1.Left + screen__1.Width))
            {
                _resizableleft = true;
                location.X = (screen__1.Left + screen__1.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen__1.Top + screen__1.Height))
            {
                _resizabletop = true;
                location.Y -= Size.Height + area.Height;
            }
            Show(location, ToolStripDropDownDirection.BelowRight);
        }

        /// <summary>
        /// Shows the pop-up window below the specified area of the specified control.
        /// </summary>
        /// <param name="control">The control used to compute screen location of specified area</param>
        /// <param name="area">The area of control below which the pop-up will be shown.</param>
        public void Show(Control control, Rectangle area)
        {
            if (control == null) throw new ArgumentNullException("control");
            SetOwnerItem(control);

            _resizabletop = false; _resizableleft = false;
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen__1 = Screen.FromControl(control).WorkingArea;
            if (location.X + Size.Width > (screen__1.Left + screen__1.Width))
            {
                _resizableleft = true;
                location.X = (screen__1.Left + screen__1.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen__1.Top + screen__1.Height))
            {
                _resizabletop = true;
                location.Y -= Size.Height + area.Height;
            }
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        #endregion

    }

    internal class GripBounds
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int GripSize = 6;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int CornerGripSize = GripSize << 1;

        public GripBounds(Rectangle clientRectangle)
        {
            this.m_clientRectangle = clientRectangle;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Rectangle m_clientRectangle;

        public Rectangle ClientRectangle
        {
            get { return m_clientRectangle; }
        }

        public Rectangle Bottom
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - GripSize + 1;
                rect.Height = GripSize;
                return rect;
            }
        }

        public Rectangle BottomRight
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - CornerGripSize + 1;
                rect.Height = CornerGripSize;
                rect.X = rect.Width - CornerGripSize + 1;
                rect.Width = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Top
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Height = GripSize;
                return rect;
            }
        }

        public Rectangle TopRight
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Height = CornerGripSize;
                rect.X = rect.Width - CornerGripSize + 1;
                rect.Width = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Left
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = GripSize;
                return rect;
            }
        }

        public Rectangle BottomLeft
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = CornerGripSize;
                rect.Y = rect.Height - CornerGripSize + 1;
                rect.Height = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Right
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.X = rect.Right - GripSize + 1;
                rect.Width = GripSize;
                return rect;
            }
        }

        public Rectangle TopLeft
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = CornerGripSize;
                rect.Height = CornerGripSize;
                return rect;
            }
        }

    }

    internal static class NativeMethods
    {
        #region Constants

        internal const int WM_NCHITTEST = 0x84;
        internal const int WM_NCACTIVATE = 0x86;
        internal const int WS_EX_TRANSPARENT = 0x20;
        internal const int WS_EX_TOOLWINDOW = 0x80;
        internal const int WS_EX_LAYERED = 0x80000;
        internal const int WS_EX_NOACTIVATE = 0x8000000;
        internal const int HTTRANSPARENT = -1;
        internal const int HTLEFT = 10;
        internal const int HTRIGHT = 11;
        internal const int HTTOP = 12;
        internal const int HTTOPLEFT = 13;
        internal const int HTTOPRIGHT = 14;
        internal const int HTBOTTOM = 15;
        internal const int HTBOTTOMLEFT = 16;
        internal const int HTBOTTOMRIGHT = 17;
        internal const int WM_PRINT = 0x317;
        internal const int WM_USER = 0x400;
        internal const int WM_REFLECT = WM_USER + 0x1c00;
        internal const int WM_COMMAND = 0x111;
        internal const int CBN_DROPDOWN = 7;
        internal const int WM_GETMINMAXINFO = 0x24;

        #endregion

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static HandleRef HWND_TOPMOST = new HandleRef(null, (IntPtr)( -1));

        /// <summary>
        /// Amimation enumerations
        /// </summary>
        [Flags()]
        internal enum AnimationFlags : int
        {
            Roll = 0x0,
            /// <summary>
            /// Uses a roll animation.
            /// </summary>
            /// <remarks></remarks>
            HorizontalPositive = 0x1,
            /// <summary>
            /// Animates the window from left to right. This flag can be used with roll or slide animation.
            /// </summary>
            /// <remarks></remarks>
            HorizontalNegative = 0x2,
            /// <summary>
            /// Animates the window from right to left. This flag can be used with roll or slide animation.
            /// </summary>
            /// <remarks></remarks>
            VerticalPositive = 0x4,
            /// <summary>
            /// Animates the window from top to bottom. This flag can be used with roll or slide animation.
            /// </summary>
            /// <remarks></remarks>
            VerticalNegative = 0x8,
            /// <summary>
            /// Animates the window from bottom to top. This flag can be used with roll or slide animation.
            /// </summary>
            /// <remarks></remarks>
            Center = 0x10,
            /// <summary>
            /// Makes the window appear to collapse inward if Hide is used or expand outward if the Hide is not used.
            /// </summary>
            /// <remarks></remarks>
            Hide = 0x10000,
            /// <summary>
            /// Hides the window. By default, the window is shown.
            /// </summary>
            /// <remarks></remarks>
            Activate = 0x20000,
            /// <summary>
            /// Activates the window.
            /// </summary>
            /// <remarks></remarks>
            Slide = 0x40000,
            /// <summary>
            /// Uses a slide animation. By default, roll animation is used.
            /// </summary>
            /// <remarks></remarks>
            Blend = 0x80000,
            /// <summary>
            /// Uses a fade effect. This flag can be used only with a top-level window.
            /// </summary>
            /// <remarks></remarks>
            Mask = 0xfffff
        }

        [DllImport("user32.dll"), SuppressUnmanagedCodeSecurity()]
        private extern static int AnimateWindow(HandleRef windowhandle, int time, AnimationFlags flags);

        [DllImport("user32.dll"), SuppressUnmanagedCodeSecurity()]
        private extern static bool SetWindowPos(HandleRef hwnd, HandleRef hwndinsertafter, int x, int y, int cx, int cy, AnimationFlags flags);

        [StructLayout(LayoutKind.Sequential)]
        internal struct MINMAXINFO
        {
            public Point reserved;
            public Size maxsize;
            public Point maxposition;
            public Size mintracksize;
            public Size maxtracksize;
        }

        internal static void AnimateWindow(Control control, int time, AnimationFlags flags)
        {
            try
            {
                SecurityPermission _permission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                _permission.Demand(); AnimateWindow(new HandleRef(control, control.Handle), time, flags);
            }
            catch { }
        }

        internal static void SetTopMost(Control control)
        {
            try
            {
                SecurityPermission _permission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                _permission.Demand(); SetWindowPos(new HandleRef(control, control.Handle), HWND_TOPMOST, 0, 0, 0, 0, (AnimationFlags) 0x13);
            }
            catch { }
        }

        internal static int HIWORD(int n)
        {
            return (short)((n >> 16) & 0xffff);
        }

        internal static int HIWORD(long n)
        {
            return (short)((n >> 16) & 0xffff);
        }

        internal static int HIWORD(IntPtr n)
        {
            return HIWORD((long)n);
        }

        internal static int LOWORD(int n)
        {
            return (short)(n & 0xffff);
        }

        internal static int LOWORD(long n)
        {
            return (short)(n & 0xffff);
        }

        internal static int LOWORD(IntPtr n)
        {
            return LOWORD((long)n);
        }
    }

}
