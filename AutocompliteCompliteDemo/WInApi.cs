using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Collections;

namespace AutocompleteTexboxDemo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FLASHWINFO
    {
        public uint cbSize;
        public IntPtr hwnd;
        public uint dwFlags;
        public uint uCount;
        public uint dwTimeout;
    }


    static class WinApi
    {
        #region Message Loop Elements

        #region Messages

        public const uint WM_NULL = 0x000;
        public const uint WM_CREATE = 0x001;
        public const uint WM_DESTROY = 0x002;
        public const uint WM_MOVE = 0x003;
        public const uint WM_SIZE = 0x005;
        public const uint WM_ACTIVATE = 0x006;
        public const uint WM_SETFOCUS = 0x007;
        public const uint WM_KILLFOCUS = 0x008;
        public const uint WM_ENABLE = 0x00A;
        public const uint WM_SETREDRAW = 0x00B;
        public const uint WM_SETTEXT = 0x00C;
        public const uint WM_GETTEXT = 0x00D;
        public const uint WM_GETTEXTLENGTH = 0x00E;
        public const uint WM_PAINT = 0x00F;
        public const uint WM_CLOSE = 0x010;
        public const uint WM_QUERYENDSESSION = 0x011;
        public const uint WM_QUIT = 0x012;
        public const uint WM_QUERYOPEN = 0x013;
        public const uint WM_ERASEBKGND = 0x014;
        public const uint WM_SYSCOLORCHANGE = 0x015;
        public const uint WM_ENDSESSION = 0x016;
        public const uint WM_SHOWWINDOW = 0x018;
        public const uint WM_WININICHANGE = 0x01A;
        public const uint WM_DEVMODECHANGE = 0x01B;
        public const uint WM_ACTIVATEAPP = 0x01C;
        public const uint WM_FONTCHANGE = 0x01D;
        public const uint WM_TIMECHANGE = 0x01E;
        public const uint WM_CANCELMODE = 0x01F;
        public const uint WM_SETCURSOR = 0x020;
        public const uint WM_MOUSEACTIVATE = 0x021;
        public const uint WM_CHILDACTIVATE = 0x022;
        public const uint WM_QUEUESYNC = 0x023;
        public const uint WM_GETMINMAXINFO = 0x024;
        public const uint WM_PAuintICON = 0x026;
        public const uint WM_ICONERASEBKGND = 0x027;
        public const uint WM_NEXTDLGCTL = 0x028;
        public const uint WM_SPOOLERSTATUS = 0x02A;
        public const uint WM_DRAWITEM = 0x02B;
        public const uint WM_MEASUREITEM = 0x02C;
        public const uint WM_DELETEITEM = 0x02D;
        public const uint WM_VKEYTOITEM = 0x02E;
        public const uint WM_CHARTOITEM = 0x02F;
        public const uint WM_SETFONT = 0x030;
        public const uint WM_GETFONT = 0x031;
        public const uint WM_SETHOTKEY = 0x032;
        public const uint WM_GETHOTKEY = 0x033;
        public const uint WM_QUERYDRAGICON = 0x037;
        public const uint WM_COMPAREITEM = 0x039;
        public const uint WM_COMPACTING = 0x041;
        public const uint WM_COMMNOTIFY = 0x044; /* no longer suported */
        public const uint WM_WINDOWPOSCHANGING = 0x046;
        public const uint WM_WINDOWPOSCHANGED = 0x047;
        public const uint WM_POWER = 0x048;
        public const uint WM_COPYDATA = 0x04A;
        public const uint WM_CANCELJOURNAL = 0x04B;
        public const uint WM_NOTIFY = 0x04E;
        public const uint WM_INPUTLANGCHANGEREQUEST = 0x050;
        public const uint WM_INPUTLANGCHANGE = 0x051;
        public const uint WM_TCARD = 0x052;
        public const uint WM_HELP = 0x053;
        public const uint WM_USERCHANGED = 0x054;
        public const uint WM_NOTIFYFORMAT = 0x055;
        public const uint WM_CONTEXTMENU = 0x07B;
        public const uint WM_STYLECHANGING = 0x07C;
        public const uint WM_STYLECHANGED = 0x07D;
        public const uint WM_DISPLAYCHANGE = 0x07E;
        public const uint WM_GETICON = 0x07F;
        public const uint WM_SETICON = 0x080;
        public const uint WM_NCCREATE = 0x081;
        public const uint WM_NCDESTROY = 0x082;
        public const uint WM_NCCALCSIZE = 0x083;
        public const uint WM_NCHITTEST = 0x084;
        public const uint WM_NCPAINT = 0x085;
        public const uint WM_NCACTIVATE = 0x086;
        public const uint WM_GETDLGCODE = 0x087;
        public const uint WM_SYNCPAuint = 0x088;
        public const uint WM_NCMOUSEMOVE = 0x0A0;
        public const uint WM_NCLBUTTONDOWN = 0x0A1;
        public const uint WM_NCLBUTTONUP = 0x0A2;
        public const uint WM_NCLBUTTONDBLCLK = 0x0A3;
        public const uint WM_NCRBUTTONDOWN = 0x0A4;
        public const uint WM_NCRBUTTONUP = 0x0A5;
        public const uint WM_NCRBUTTONDBLCLK = 0x0A6;
        public const uint WM_NCMBUTTONDOWN = 0x0A7;
        public const uint WM_NCMBUTTONUP = 0x0A8;
        public const uint WM_NCMBUTTONDBLCLK = 0x0A9;
        public const uint WM_NCXBUTTONDOWN = 0x0AB;
        public const uint WM_NCXBUTTONUP = 0x0AC;
        public const uint WM_NCXBUTTONDBLCLK = 0x0AD;
        public const uint WM_INPUT = 0x0FF;
        public const uint WM_KEYFIRST = 0x100;
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x101;
        public const uint WM_CHAR = 0x102;
        public const uint WM_DEADCHAR = 0x103;
        public const uint WM_SYSKEYDOWN = 0x104;
        public const uint WM_SYSKEYUP = 0x105;
        public const uint WM_SYSCHAR = 0x106;
        public const uint WM_SYSDEADCHAR = 0x107;
        public const uint WM_UNICHAR = 0x109;
        public const uint WM_KEYLAST = 0x109;
        public const uint WM_IME_STARTCOMPOSITION = 0x10D;
        public const uint WM_IME_ENDCOMPOSITION = 0x10E;
        public const uint WM_IME_COMPOSITION = 0x10F;
        public const uint WM_IME_KEYLAST = 0x10F;
        public const uint WM_INITDIALOG = 0x110;
        public const uint WM_COMMAND = 0x111;
        public const uint WM_SYSCOMMAND = 0x112;
        public const uint WM_TIMER = 0x113;
        public const uint WM_HSCROLL = 0x114;
        public const uint WM_VSCROLL = 0x115;
        public const uint WM_INITMENU = 0x116;
        public const uint WM_INITMENUPOPUP = 0x117;
        public const uint WM_SYSTIMER = 0x118;
        public const uint WM_MENUSELECT = 0x11F;
        public const uint WM_MENUCHAR = 0x120;
        public const uint WM_ENTERIDLE = 0x121;
        public const uint WM_MENURBUTTONUP = 0x122;
        public const uint WM_MENUDRAG = 0x123;
        public const uint WM_MENUGETOBJECT = 0x124;
        public const uint WM_UNINITMENUPOPUP = 0x125;
        public const uint WM_MENUCOMMAND = 0x126;
        public const uint WM_CHANGEUISTATE = 0x127;
        public const uint WM_UPDATEUISTATE = 0x128;
        public const uint WM_QUERYUISTATE = 0x129;
        public const uint WM_CTLCOLORMSGBOX = 0x132;
        public const uint WM_CTLCOLOREDIT = 0x133;
        public const uint WM_CTLCOLORLISTBOX = 0x134;
        public const uint WM_CTLCOLORBTN = 0x135;
        public const uint WM_CTLCOLORDLG = 0x136;
        public const uint WM_CTLCOLORSCROLLBAR = 0x137;
        public const uint WM_CTLCOLORSTATIC = 0x138;
        public const uint MN_GETHMENU = 0x1E1;
        public const uint WM_MOUSEFIRST = 0x200;
        public const uint WM_MOUSEMOVE = 0x200;
        public const uint WM_LBUTTONDOWN = 0x201;
        public const uint WM_LBUTTONUP = 0x202;
        public const uint WM_LBUTTONDBLCLK = 0x203;
        public const uint WM_RBUTTONDOWN = 0x204;
        public const uint WM_RBUTTONUP = 0x205;
        public const uint WM_RBUTTONDBLCLK = 0x206;
        public const uint WM_MBUTTONDOWN = 0x207;
        public const uint WM_MBUTTONUP = 0x208;
        public const uint WM_MBUTTONDBLCLK = 0x209;
        public const uint WM_MOUSEWHEEL = 0x20A;
        public const uint WM_XBUTTONDOWN = 0x20B;
        public const uint WM_XBUTTONUP = 0x20C;
        public const uint WM_XBUTTONDBLCLK = 0x20D;
        public const uint WM_MOUSELAST = 0x20A;
        public const uint WM_PARENTNOTIFY = 0x210;
        public const uint WM_ENTERMENULOOP = 0x211;
        public const uint WM_EXITMENULOOP = 0x212;
        public const uint WM_NEXTMENU = 0x213;
        public const uint WM_SIZING = 0x214;
        public const uint WM_CAPTURECHANGED = 0x215;
        public const uint WM_MOVING = 0x216;
        public const uint WM_POWERBROADCAST = 0x218;
        public const uint WM_DEVICECHANGE = 0x219;
        public const uint WM_MDICREATE = 0x220;
        public const uint WM_MDIDESTROY = 0x221;
        public const uint WM_MDIACTIVATE = 0x222;
        public const uint WM_MDIRESTORE = 0x223;
        public const uint WM_MDINEXT = 0x224;
        public const uint WM_MDIMAXIMIZE = 0x225;
        public const uint WM_MDITILE = 0x226;
        public const uint WM_MDICASCADE = 0x227;
        public const uint WM_MDIICONARRANGE = 0x228;
        public const uint WM_MDIGETACTIVE = 0x229;
        public const uint WM_MDISETMENU = 0x230;
        public const uint WM_ENTERSIZEMOVE = 0x231;
        public const uint WM_EXITSIZEMOVE = 0x232;
        public const uint WM_DROPFILES = 0x233;
        public const uint WM_MDIREFRESHMENU = 0x234;
        public const uint WM_IME_SETCONTEXT = 0x281;
        public const uint WM_IME_NOTIFY = 0x282;
        public const uint WM_IME_CONTROL = 0x283;
        public const uint WM_IME_COMPOSITIONFULL = 0x284;
        public const uint WM_IME_SELECT = 0x285;
        public const uint WM_IME_CHAR = 0x286;
        public const uint WM_IME_REQUEST = 0x288;
        public const uint WM_IME_KEYDOWN = 0x290;
        public const uint WM_IME_KEYUP = 0x291;
        public const uint WM_MOUSEHOVER = 0x2A1;
        public const uint WM_MOUSELEAVE = 0x2A3;
        public const uint WM_NCMOUSEHOVER = 0x2A0;
        public const uint WM_NCMOUSELEAVE = 0x2A2;
        public const uint WM_WTSSESSION_CHANGE = 0x2B1;
        public const uint WM_TABLET_FIRST = 0x2c0;
        public const uint WM_TABLET_LAST = 0x2df;
        public const uint WM_CUT = 0x300;
        public const uint WM_COPY = 0x301;
        public const uint WM_PASTE = 0x302;
        public const uint WM_CLEAR = 0x303;
        public const uint WM_UNDO = 0x304;
        public const uint WM_RENDERFORMAT = 0x305;
        public const uint WM_RENDERALLFORMATS = 0x306;
        public const uint WM_DESTROYCLIPBOARD = 0x307;
        public const uint WM_DRAWCLIPBOARD = 0x308;
        public const uint WM_PAuintCLIPBOARD = 0x309;
        public const uint WM_VSCROLLCLIPBOARD = 0x30A;
        public const uint WM_SIZECLIPBOARD = 0x30B;
        public const uint WM_ASKCBFORMATNAME = 0x30C;
        public const uint WM_CHANGECBCHAIN = 0x30D;
        public const uint WM_HSCROLLCLIPBOARD = 0x30E;
        public const uint WM_QUERYNEWPALETTE = 0x30F;
        public const uint WM_PALETTEISCHANGING = 0x310;
        public const uint WM_PALETTECHANGED = 0x311;
        public const uint WM_HOTKEY = 0x312;
        public const uint WM_PRINT = 0x317;
        public const uint WM_PRINTCLIENT = 0x0318;
        public const uint WM_APPCOMMAND = 0x319;
        public const uint WM_THEMECHANGED = 0x31A;
        public const uint WM_HANDHELDFIRST = 0x358;
        public const uint WM_HANDHELDLAST = 0x35F;
        public const uint WM_AFXFIRST = 0x360;
        public const uint WM_AFXLAST = 0x37F;
        public const uint WM_PENWINFIRST = 0x380;
        public const uint WM_PENWINLAST = 0x38F;

        #endregion

        #region Hit test

        internal enum HitTest
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = 4,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = 8,
            HTZOOM = 9,
            HTSIZEFIRST = 10,
            HTSIZELAST = 17,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21
        }

        #endregion

        #region WM_CHAR Key Codes

        public static readonly IntPtr VK_BACK = (IntPtr)0x08;
        public static readonly IntPtr VK_TAB = (IntPtr)0x09;
        public static readonly IntPtr VK_CLEAR = (IntPtr)0x0C;
        public static readonly IntPtr VK_RETURN = (IntPtr)0x0D;
        public static readonly IntPtr VK_DELETE = (IntPtr)(0x2E);
        public static readonly IntPtr VK_UP = (IntPtr)(0x26);
        public static readonly IntPtr VK_DOWN = (IntPtr)(0x28);
        public static readonly IntPtr VK_PRIOR = (IntPtr)0x21; // PAGE UP key
        public static readonly IntPtr VK_NEXT = (IntPtr)0x22; // PAGE DOWN key

        #endregion

        #region WM_COMMAND IDs

        public const uint IDOK = 1;
        public const uint IDCANCEL = 2;
        public const uint IDABORT = 3;
        public const uint IDRETRY = 4;
        public const uint IDIGNORE = 5;
        public const uint IDYES = 6;
        public const uint IDNO = 7;
        public const uint IDCLOSE = 8;
        public const uint IDHELP = 9;
        public const uint IDTRYAGAIN = 10;
        public const uint IDCONTINUE = 11;

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        public const int PM_REMOVE = 1;
        public const int PM_NOREMOVE = 0;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll")]
        public static extern bool IsDialogMessage(IntPtr hDlg, [In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        #endregion

        internal enum ClassStyle : int
        {
            CS_DROPSHADOW = 0x00020000
        };

        internal enum WindowStyles : uint
        {
            WS_OVERLAPPED = 0x00000000,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x08000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_MAXIMIZE = 0x01000000,
            WS_CAPTION = 0x00C00000,
            WS_BORDER = 0x00800000,
            WS_DLGFRAME = 0x00400000,
            WS_VSCROLL = 0x00200000,
            WS_HSCROLL = 0x00100000,
            WS_SYSMENU = 0x00080000,
            WS_THICKFRAME = 0x00040000,
            WS_GROUP = 0x00020000,
            WS_TABSTOP = 0x00010000,
            WS_MINIMIZEBOX = 0x00020000,
            WS_MAXIMIZEBOX = 0x00010000,
            WS_TILED = 0x00000000,
            WS_ICONIC = 0x20000000,
            WS_SIZEBOX = 0x00040000,
            WS_POPUPWINDOW = 0x80880000,
            WS_OVERLAPPEDWINDOW = 0x00CF0000,
            WS_TILEDWINDOW = 0x00CF0000,
            WS_CHILDWINDOW = 0x40000000
        }

        internal enum WindowExStyles
        {
            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_NOACTIVATE = 0x08000000,
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_TRANSPARENT = 0x00000020,
            WS_EX_MDICHILD = 0x00000040,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_WINDOWEDGE = 0x00000100,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_CONTEXTHELP = 0x00000400,
            WS_EX_RIGHT = 0x00001000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,
            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_APPWINDOW = 0x00040000,
            WS_EX_OVERLAPPEDWINDOW = 0x00000300,
            WS_EX_PALETTEWINDOW = 0x00000188,
            WS_EX_LAYERED = 0x00080000,
            WS_EX_COMPOSITED = 0x02000000
        }

        public const int MA_ACTIVATE = 0x0001;
        public const int MA_ACTIVATEANDEAT = 0x0002;
        public const int MA_NOACTIVATE = 0x0003;
        public const int MA_NOACTIVATEANDEAT = 0x0004;

        public const int SB_HORZ = 0x0;
        public const int SB_VERT = 0x1;
        public const int SB_LINEUP = 0; // Scrolls one line up
        public const int SB_LINELEFT = 0;// Scrolls one cell left
        public const int SB_LINEDOWN = 1; // Scrolls one line down
        public const int SB_LINERIGHT = 1;// Scrolls one cell right
        public const int SB_PAGEUP = 2; // Scrolls one page up
        public const int SB_PAGELEFT = 2;// Scrolls one page left
        public const int SB_PAGEDOWN = 3; // Scrolls one page down
        public const int SB_PAGERIGTH = 3; // Scrolls one page right
        public const int SB_THUMBPOSITION = 4; // Scrolls one page right
        public const int SB_PAGETOP = 6; // Scrolls to the upper left
        public const int SB_LEFT = 6; // Scrolls to the left
        public const int SB_PAGEBOTTOM = 7; // Scrolls to the upper right
        public const int SB_RIGHT = 7; // Scrolls to the right
        public const int SB_ENDSCROLL = 8; // Ends scroll

        [DllImport("user32")]
        public static extern int SetCursor(IntPtr cursor);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern void RedrawWindow(IntPtr hwnd, IntPtr iRect, IntPtr hRgn, uint flags);

        public const int RDW_INVALIDATE = 0x0001;
        public const int RDW_INTERNALPAINT = 0x0002;
        public const int RDW_ERASE = 0x0004;

        public const int RDW_VALIDATE = 0x0008;
        public const int RDW_NOINTERNALPAINT = 0x0010;
        public const int RDW_NOERASE = 0x0020;

        public const int RDW_NOCHILDREN = 0x0040;
        public const int RDW_ALLCHILDREN = 0x0080;

        public const int RDW_UPDATENOW = 0x0100;
        public const int RDW_ERASENOW = 0x0200;

        public const int RDW_FRAME = 0x0400;
        public const int RDW_NOFRAME = 0x0800;

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT Point);

        #region GetSystemMetrics

        /// <summary>
        /// Retrieves the specified system metric or system configuration setting
        /// </summary>
        /// <param name="which">The system metric or configuration setting to be retrieved</param>
        /// <returns>If the function succeeds, the return value is the requested system metric or configuration setting. 
        /// If the function fails, the return value is 0</returns>
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        /// <summary>
        /// The width of the screen of the primary display monitor, in pixels
        /// </summary>
        public const int SM_CXSCREEN = 0;
        /// <summary>
        /// The height of the screen of the primary display monitor, in pixels
        /// </summary>
        public const int SM_CYSCREEN = 1;
        /// <summary>
        /// The width of a vertical scroll bar, in pixels
        /// </summary>
        public const int SM_CXVSCROLL = 2;
        /// <summary>
        /// The height of a horizontal scroll bar, in pixels
        /// </summary>
        public const int SM_CYHSCROLL = 3;

        /// <summary>
        /// Nonzero if the current operating system is the Windows XP Tablet PC edition, zero if not.
        /// </summary>
        public const int SM_TABLETPC = 86;

        /// <summary>
        /// Nonzero if the current operating system is the Windows XP, Media Center Edition, zero if not.
        /// </summary>
        public const int SM_MEDIACENTER = 87;


        #endregion

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        /// Child, pop-up, and top-level windows are ordered according to their appearance on the screen. 
        /// The topmost window receives the highest rank and is the first window in the Z order
        /// </summary>
        /// <param name="hwnd">Handle to the window</param>
        /// <param name="hwndInsertAfter">Handle to the window to precede the positioned window in the Z order. 
        /// This parameter must be a window handle or one of the HWND_* values</param>
        /// <param name="X">Specifies the new position of the left side of the window, in client coordinates</param>
        /// <param name="Y">Specifies the new position of the top of the window, in client coordinates</param>
        /// <param name="width">Specifies the new width of the window, in pixels</param>
        /// <param name="height">Specifies the new height of the window, in pixels</param>
        /// <param name="flags">Specifies the window sizing and positioning flags. This parameter can be a combination of the SWP_* values</param>
        [DllImport("user32.dll")]
        public static extern void SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            IntPtr hwnd;
            IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            #region Construction

            public RECT(int left_, int top_, int right_, int bottom_)
            {
                Left = left_;
                Top = top_;
                Right = right_;
                Bottom = bottom_;
            }

            public RECT(Rectangle r)
            {
                this.Left = r.Left;
                this.Top = r.Top;
                this.Bottom = r.Bottom;
                this.Right = r.Right;
            }

            #endregion

            #region Internal Data and Basic Properties

            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Height { get { return Bottom - Top; } }
            public int Width { get { return Right - Left; } }
            public Size Size { get { return new Size(Width, Height); } }

            #endregion

            #region Public Methods, Properties and Transformations

            public Point Location { get { return new Point(Left, Top); } }

            // Handy method for converting to a System.Drawing.Rectangle
            public Rectangle ToRectangle()
            { return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

            public static RECT FromRectangle(Rectangle rectangle)
            {
                return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }

            public override int GetHashCode()
            {
                return Left ^ ((Top << 13) | (Top >> 0x13))
                  ^ ((Width << 0x1a) | (Width >> 6))
                  ^ ((Height << 7) | (Height >> 0x19));
            }

            #endregion

            #region Operator overloads

            public static implicit operator Rectangle(RECT rect)
            {
                return rect.ToRectangle();
            }

            public static implicit operator RECT(Rectangle rect)
            {
                return FromRectangle(rect);
            }

            #endregion
        }

        /// <summary>
        /// Scrolls the contents of the specified window's client area
        /// </summary>
        /// <param name="hWnd">Handle to the window where the client area is to be scrolled</param>
        /// <param name="xAmount">Specifies the amount, in device units, of horizontal scrolling. 
        /// If the window being scrolled has the CS_OWNDC or CS_CLASSDC style, 
        /// then this parameter uses logical units rather than device units. 
        /// This parameter must be a negative value to scroll the content of the window to the left</param>
        /// <param name="yAmount">Specifies the amount, in device units, of vertical scrolling. 
        /// If the window being scrolled has the CS_OWNDC or CS_CLASSDC style, then this parameter 
        /// uses logical units rather than device units. 
        /// This parameter must be a negative value to scroll the content of the window up</param>
        /// <param name="rect">Pointer to the RECT structure specifying the portion of the client area to be scrolled. 
        /// If this parameter is NULL, the entire client area is scrolled</param>
        /// <param name="clipRect">RECT structure containing the coordinates of the clipping rectangle. 
        /// Only device bits within the clipping rectangle are affected. 
        /// Bits scrolled from the outside of the rectangle to the inside are painted; bits scrolled from the inside 
        /// of the rectangle to the outside are not painted</param>
        /// <returns>If the function succeeds, the return value is nonzero 
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ScrollWindow(IntPtr hWnd, int xAmount, int yAmount,
            IntPtr rect, [In] ref RECT clipRect);

        /// <summary>
        /// Scroll children within *lprcScroll.
        /// </summary>
        public const uint SW_SCROLLCHILDREN = 0x0001;
        /// <summary>
        /// Invalidate after scrolling.
        /// </summary>
        public const uint SW_INVALIDATE = 0x0002;
        /// <summary>
        /// If SW_INVALIDATE, don't send WM_ERASEBACKGROUND.
        /// </summary>
        public const uint SW_ERASE = 0x0004;
        /// <summary>
        /// Use smooth scrolling.
        /// </summary>
        public const uint SW_SMOOTHSCROLL = 0x0010;

        [DllImport("user32.dll")]
        public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, IntPtr prcScroll,
        ref RECT prcClip, IntPtr hrgnUpdate, IntPtr prcUpdate, uint flags);

        private static IntPtr HWND_TOP = IntPtr.Zero;

        private const int SWP_SHOWWINDOW = 64; // 0x0040

        /// <summary>
        /// X-size of screen in pixels
        /// </summary>
        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        /// <summary>
        /// Y-size of screen in pixels
        /// </summary>
        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        [DllImport("user32.dll")]
        public static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(int hwnd, int command);

        internal const int SW_HIDE = 0;
        internal const int SW_SHOWNORMAL = 1;
        internal const int SW_NORMAL = 1;
        internal const int SW_SHOWMINIMIZED = 2;
        internal const int SW_SHOWMAXIMIZED = 3;
        internal const int SW_MAXIMIZE = 3;
        internal const int SW_SHOWNOACTIVATE = 4;
        internal const int SW_SHOW = 5;
        internal const int SW_MINIMIZE = 6;
        internal const int SW_SHOWMINNOACTIVE = 7;
        internal const int SW_SHOWNA = 8;
        internal const int SW_RESTORE = 9;
        internal const int SW_SHOWDEFAULT = 10;
        internal const int SW_FORCEMINIMIZE = 11;
        internal const int SW_MAX = 11;

        /// <summary>
        /// Brings window to front and changes its size to occupy the entire screen
        /// </summary>
        /// <param name="hwnd">Handle of the window</param>
        public static void SetWinFullScreen(IntPtr hwnd)
        {
            int _hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(_hwnd, SW_SHOW);

            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }

        [DllImport("user32.dll")]
        public static extern bool ClipCursor(ref RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool GetClipCursor(ref RECT lpRect);

        #region Caret

        [DllImport("user32.dll")]
        public static extern int ShowCaret(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int HideCaret(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [DllImport("user32.dll")]
        public static extern bool SetCaretPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern bool DestroyCaret();

        #endregion

        #region ScrollBar

        [DllImport("user32.dll")]
        public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi, bool fRedraw);
        [DllImport("user32.dll")]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
        [DllImport("user32.dll")]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetScrollBarInfo")]
        public static extern int GetScrollBarInfo(IntPtr hWnd, uint idObject, ref SCROLLBARINFO psbi);

        public const uint OBJID_VSCROLL = 0xFFFFFFFB;

        [StructLayout(LayoutKind.Sequential)]
        public struct SCROLLBARINFO
        {
            public int cbSize;
            public Rectangle rcScrollBar;
            public int dxyLineButton;
            public int xyThumbTop;
            public int xyThumbBottom;
            public int reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public int[] rgstate;
        }

        public enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        public enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }

        public const int EM_GETLINECOUNT = 0x00BA;
        public const int EM_LINESCROLL = 0x00B6;

        #endregion

        #region Paint

        internal const uint DT_TOP = 0x00000000;
        internal const uint DT_LEFT = 0x00000000;
        internal const uint DT_CENTER = 0x00000001;
        internal const uint DT_RIGHT = 0x00000002;
        internal const uint DT_VCENTER = 0x00000004;
        internal const uint DT_BOTTOM = 0x00000008;
        internal const uint DT_WORDBREAK = 0x00000010;
        internal const uint DT_SINGLELINE = 0x00000020;
        internal const uint DT_EXPANDTABS = 0x00000040;
        internal const uint DT_TABSTOP = 0x00000080;
        internal const uint DT_NOCLIP = 0x00000100;
        internal const uint DT_EXTERNALLEADING = 0x00000200;
        internal const uint DT_CALCRECT = 0x00000400;
        internal const uint DT_NOPREFIX = 0x00000800;
        internal const uint DT_INTERNAL = 0x00001000;

        internal const uint DT_EDITCONTROL = 0x00002000;
        internal const uint DT_PATH_ELLIPSIS = 0x00004000;
        internal const uint DT_END_ELLIPSIS = 0x00008000;
        internal const uint DT_MODIFYSTRING = 0x00010000;
        internal const uint DT_RTLREADING = 0x00020000;
        internal const uint DT_WORD_ELLIPSIS = 0x00040000;
        internal const uint DT_NOFULLWIDTHCHARBREAK = 0x00080000;
        internal const uint DT_HIDEPREFIX = 0x00100000;
        internal const uint DT_PREFIXONLY = 0x00200000;

        internal const int EM_SETMARGINS = 0x00D3;
        internal const int EC_LEFTMARGIN = 0x0001;
        internal const int EC_RIGHTMARGIN = 0x0002;

        [StructLayout(LayoutKind.Sequential)]
        public class DRAWTEXTPARAMS
        {
            private int cbSize;
            public int iTabLength;
            public int iLeftMargin;
            public int iRightMargin;
            public int uiLengthDrawn;

            public DRAWTEXTPARAMS()
            {
                this.cbSize = Marshal.SizeOf(typeof(DRAWTEXTPARAMS));
            }

            public DRAWTEXTPARAMS(DRAWTEXTPARAMS original)
            {
                this.cbSize = Marshal.SizeOf(typeof(DRAWTEXTPARAMS));
                this.iLeftMargin = original.iLeftMargin;
                this.iRightMargin = original.iRightMargin;
                this.iTabLength = original.iTabLength;
            }

            public DRAWTEXTPARAMS(int leftMargin, int rightMargin)
            {
                this.cbSize = Marshal.SizeOf(typeof(DRAWTEXTPARAMS));
                this.iLeftMargin = leftMargin;
                this.iRightMargin = rightMargin;
            }
        }

        [DllImport("user32.dll")]
        public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref WinApi.RECT lpRect, uint uFormat);
        [DllImport("user32.dll")]
        public static extern int DrawTextEx(IntPtr hDC, string lpString, int nCount, ref WinApi.RECT lpRect, uint uFormat, DRAWTEXTPARAMS lpDTParams);
        [DllImport("gdi32.dll")]
        public static extern int SetTextColor(IntPtr hdc, int crColor);
        [DllImport("gdi32.dll")]
        public static extern int SetBkColor(IntPtr hdc, int crColor);
        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int iBkMode);
        [DllImport("gdi32.dll")]
        public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        #endregion

        #region Cursor

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        /// <summary>
        /// Provides access to function required to delete handle. This method is used internally
        /// and is not required to be called separately.
        /// </summary>
        /// <param name="hIcon">Pointer to icon handle.</param>
        /// <returns>N/A</returns>
        [DllImport("user32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool DestroyCursor(IntPtr hIcon);

        #endregion

        #region Helpers
        public static string GetMessageName(uint value)
        {
            Type WinApiType = typeof(WinApi);

            FieldInfo[] FieldInfo = WinApiType.GetFields(BindingFlags.Public | BindingFlags.Static);
            int length = FieldInfo.Length;

            for (int i = 0; i < length; i++)
            {
                object FieldObj = FieldInfo[i].GetValue(WinApiType);
                if ((FieldObj is uint) && ((uint)FieldObj) == value)
                    return FieldInfo[i].Name;
            }

            return value.ToString("x");
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DragDetect(IntPtr hWnd, Point pt);

        public enum ProcessDpiAwareness : int
        {
            PROCESS_DPI_UNAWARE = 0,
            PROCESS_SYSTEM_DPI_AWARE = 1,
            PROCESS_PER_MONITOR_DPI_AWARE = 2
        };

        [DllImport("shcore.dll")]
        public static extern int SetProcessDpiAwareness(int value);

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        #endregion

        #region Menu handling
        public enum SysCommands : int
        {
            SC_SIZE = 0xF000,
            SC_MOVE = 0xF010,
            SC_MINIMIZE = 0xF020,
            SC_MAXIMIZE = 0xF030,
            SC_NEXTWINDOW = 0xF040,
            SC_PREVWINDOW = 0xF050,
            SC_CLOSE = 0xF060,
            SC_VSCROLL = 0xF070,
            SC_HSCROLL = 0xF080,
            SC_MOUSEMENU = 0xF090,
            SC_KEYMENU = 0xF100,
            SC_ARRANGE = 0xF110,
            SC_RESTORE = 0xF120,
            SC_TASKLIST = 0xF130,
            SC_SCREENSAVE = 0xF140,
            SC_HOTKEY = 0xF150,
            //#if(WINVER >= 0x0400) //Win95
            SC_DEFAULT = 0xF160,
            SC_MONITORPOWER = 0xF170,
            SC_CONTEXTHELP = 0xF180,
            SC_SEPARATOR = 0xF00F,
            //#endif /* WINVER >= 0x0400 */

            //#if(WINVER >= 0x0600) //Vista
            SCF_ISSECURE = 0x00000001,
            //#endif /* WINVER >= 0x0600 */

            /*
              * Obsolete names
              */
            SC_ICON = SC_MINIMIZE,
            SC_ZOOM = SC_MAXIMIZE,
        }
        internal const UInt32 MF_INSERT = 0x00000000;
        internal const UInt32 MF_CHANGE = 0x00000080;
        internal const UInt32 MF_APPEND = 0x00000100;
        internal const UInt32 MF_DELETE = 0x00000200;
        internal const UInt32 MF_REMOVE = 0x00001000;

        internal const UInt32 MF_BYCOMMAND = 0x00000000;
        internal const UInt32 MF_BYPOSITION = 0x00000400;

        internal const UInt32 MF_SEPARATOR = 0x00000800;

        internal const UInt32 MF_ENABLED = 0x00000000;
        internal const UInt32 MF_GRAYED = 0x00000001;
        internal const UInt32 MF_DISABLED = 0x00000002;

        internal const UInt32 MF_UNCHECKED = 0x00000000;
        internal const UInt32 MF_CHECKED = 0x00000008;
        internal const UInt32 MF_USECHECKBITMAPS = 0x00000200;

        internal const UInt32 MF_STRING = 0x00000000;
        internal const UInt32 MF_BITMAP = 0x00000004;
        internal const UInt32 MF_OWNERDRAW = 0x00000100;

        internal const UInt32 MF_POPUP = 0x00000010;
        internal const UInt32 MF_MENUBARBREAK = 0x00000020;
        internal const UInt32 MF_MENUBREAK = 0x00000040;

        internal const UInt32 MF_UNHILITE = 0x00000000;
        internal const UInt32 MF_HILITE = 0x00000080;

        internal const UInt32 MF_DEFAULT = 0x00001000;
        internal const UInt32 MF_SYSMENU = 0x00002000;
        internal const UInt32 MF_HELP = 0x00004000;
        internal const UInt32 MF_RIGHTJUSTIFY = 0x00004000;

        internal const UInt32 MF_MOUSESELECT = 0x00008000;
        internal const UInt32 MF_END = 0x00000080;  /* Obsolete -- only used by old RES files */

        internal const UInt32 MFT_STRING = MF_STRING;
        internal const UInt32 MFT_BITMAP = MF_BITMAP;
        internal const UInt32 MFT_MENUBARBREAK = MF_MENUBARBREAK;
        internal const UInt32 MFT_MENUBREAK = MF_MENUBREAK;
        internal const UInt32 MFT_OWNERDRAW = MF_OWNERDRAW;
        internal const UInt32 MFT_RADIOCHECK = 0x00000200;
        internal const UInt32 MFT_SEPARATOR = MF_SEPARATOR;
        internal const UInt32 MFT_RIGHTORDER = 0x00002000;
        internal const UInt32 MFT_RIGHTJUSTIFY = MF_RIGHTJUSTIFY;

        internal const UInt32 MFS_GRAYED = 0x00000003;
        internal const UInt32 MFS_DISABLED = MFS_GRAYED;
        internal const UInt32 MFS_CHECKED = MF_CHECKED;
        internal const UInt32 MFS_HILITE = MF_HILITE;
        internal const UInt32 MFS_ENABLED = MF_ENABLED;
        internal const UInt32 MFS_UNCHECKED = MF_UNCHECKED;
        internal const UInt32 MFS_UNHILITE = MF_UNHILITE;
        internal const UInt32 MFS_DEFAULT = MF_DEFAULT;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        public extern static IntPtr GetDesktopWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        public extern static int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        public extern static int GetWindowLong(IntPtr hWnd, int nIndex);

        public enum GWLParameter
        {
            GWL_EXSTYLE = -20, //Sets a new extended window style
            GWL_HINSTANCE = -6, //Sets a new application instance handle.
            GWL_HWNDPARENT = -8, //Set window handle as parent
            GWL_ID = -12, //Sets a new identifier of the window.
            GWL_STYLE = -16, // Set new window style
            GWL_USERDATA = -21, //Sets the user data associated with the window. 
            //This data is intended for use by the application 
            //that created the window. Its value is initially zero.
            GWL_WNDPROC = -4 //Sets a new address for the window procedure.
        }

        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        #endregion

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EndTask(IntPtr hWnd, bool fShutDown, bool fForce);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, int fAttach); //bool fAttach

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        public enum DeviceCap : int
        {
            VERTRES = 10,
            LOGPIXELSX = 88,
            LOGPIXELSY = 90,
            DESKTOPVERTRES = 117,
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern Int32 GetDeviceCaps(IntPtr hdc, Int32 capindex);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool SetViewportOrgEx(IntPtr hdc, int x, int y, out POINT prevPoint);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys key);

        public static bool IsKeyDown(Keys key)
        {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool AllowSetForegroundWindow(int dwProcessId);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        public enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public const uint SRCCOPY = 0x00CC0020;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, int lParam);

        public const int PRF_CLIENT = 0x04;
        public const int PRF_CHILDREN = 0x10;
        public const int PRF_OWNED = 0x20;
        public const int PRF_ERASEBKGN = 0x08;
        public const int PRF_NON_CLIENT = 0x02;

        // ClickOnce
        [DllImport("user32.Dll")]
        public static extern int EnumWindows(EnumWindowsCallbackDelegate callback, IntPtr lParam);

        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);

        [DllImport("User32.Dll")]
        public static extern void GetClassName(int h, StringBuilder s, int nMaxCount);

        [DllImport("User32.Dll")]
        private static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsCallbackDelegate lpEnumFunc, IntPtr lParam);

        [DllImport("User32.Dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public delegate bool EnumWindowsCallbackDelegate(IntPtr hwnd, IntPtr lParam);

        private const int BM_CLICK = 0x00F5;

        public static IntPtr SearchForTopLevelWindow(string WindowTitle)
        {
            ArrayList windowHandles = new ArrayList();
            /* Create a GCHandle for the ArrayList */
            GCHandle gch = GCHandle.Alloc(windowHandles);
            try
            {
                EnumWindows(new EnumWindowsCallbackDelegate(EnumProc), (IntPtr)gch);
                /* the windowHandles array list contains all of the
                    window handles that were passed to EnumProc.  */
            }
            finally
            {
                /* Free the handle */
                gch.Free();
            }

            /* Iterate through the list and get the handle thats the best match */
            foreach (IntPtr handle in windowHandles)
            {
                StringBuilder sb = new StringBuilder(1024);
                GetWindowText((int)handle, sb, sb.Capacity);
                if (sb.Length > 0)
                {
                    if (sb.ToString().StartsWith(WindowTitle))
                    {
                        return handle;
                    }
                }
            }

            return IntPtr.Zero;
        }

        public static IntPtr SearchForChildWindow(IntPtr ParentHandle, string Caption)
        {
            ArrayList windowHandles = new ArrayList();
            /* Create a GCHandle for the ArrayList */
            GCHandle gch = GCHandle.Alloc(windowHandles);
            try
            {
                EnumChildWindows(ParentHandle, new EnumWindowsCallbackDelegate(EnumProc), (IntPtr)gch);
                /* the windowHandles array list contains all of the
                    window handles that were passed to EnumProc.  */
            }
            finally
            {
                /* Free the handle */
                gch.Free();
            }

            /* Iterate through the list and get the handle thats the best match */
            foreach (IntPtr handle in windowHandles)
            {
                StringBuilder sb = new StringBuilder(1024);
                GetWindowText((int)handle, sb, sb.Capacity);
                if (sb.Length > 0)
                {
                    if (sb.ToString().StartsWith(Caption))
                    {
                        return handle;
                    }
                }
            }

            return IntPtr.Zero;

        }

        static bool EnumProc(IntPtr hWnd, IntPtr lParam)
        {
            /* get a reference to the ArrayList */
            GCHandle gch = (GCHandle)lParam;
            ArrayList list = (ArrayList)(gch.Target);
            /* and add this window handle */
            list.Add(hWnd);
            return true;
        }

        public static void DoButtonClick(IntPtr ButtonHandle)
        {
            SendMessage(ButtonHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }

        public static bool FlashWindowAPI(IntPtr handleToWindow, uint flags, uint count, uint timeout)
        {
            FLASHWINFO flashwinfo1 = new FLASHWINFO();
            flashwinfo1.cbSize = (uint)Marshal.SizeOf(flashwinfo1);
            flashwinfo1.hwnd = handleToWindow;
            flashwinfo1.dwFlags = flags;
            flashwinfo1.uCount = count;
            flashwinfo1.dwTimeout = timeout;
            return (WinApi.FlashWindowEx(ref flashwinfo1) == 0);
        }

        public static bool FlashWindowAPI(IntPtr handleToWindow)
        {
            return FlashWindowAPI(handleToWindow, 15, uint.MaxValue, 0);
        }

        public const int GCL_HICONSM = -34;
        public const int GCL_HICON = -14;

        public const int ICON_SMALL = 0;
        public const int ICON_BIG = 1;
        public const int ICON_SMALL2 = 2;

        [DllImport("user32.dll")]
        private static extern short FlashWindowEx(ref FLASHWINFO pwfi);

        public static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size > 4)
                return GetClassLongPtr64(hWnd, nIndex);
            else
                return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
        }

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        public static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        public static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);

        // Fields
        public const uint FLASHW_ALL = 3;
        public const uint FLASHW_CAPTION = 1;
        public const uint FLASHW_STOP = 0;
        public const uint FLASHW_TIMER = 4;
        public const uint FLASHW_TIMERNOFG = 12;
        public const uint FLASHW_TRAY = 2;

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExtractIconEx(string fullFilePath, int iconIndex, out IntPtr largeIconVersion, out IntPtr smallIconVersion, uint iconsQuantity);

        /// <summary>
        /// Extracts icon from resources, such as icon dll or exe file.
        /// </summary>
        /// <param name="fullFilePath">Path to existing resource</param>
        /// <param name="iconIndex">icon index</param>
        /// <param name="useLargeIcon">default value == true</param>
        /// <returns>Icon if extraction succeeded, null otherwise</returns>
        public static Icon ExtractIconFromResource(string fullFilePath, int iconIndex, bool useLargeIcon = true)
        {
            IntPtr largeIcon;
            IntPtr smallIcon;

            ExtractIconEx(fullFilePath, iconIndex, out largeIcon, out smallIcon, 1);

            try
            {
                return Icon.FromHandle(useLargeIcon ? largeIcon : smallIcon).Clone() as Icon;
            }
            catch
            {
                return null;
            }
            finally
            {
                // Cleanup
                DestroyIcon(largeIcon);
                DestroyIcon(smallIcon);
            }
        }
    }

    #region enum SystemMetric
    /// <summary>
    /// Flags used with the Windows API GetSystemMetrics(SystemMetric smIndex)
    /// </summary>
    internal enum SystemMetric : int
    {
        /// <summary>
        ///  Width of the screen of the primary display monitor, in pixels. 
        /// This is the same values obtained by calling GetDeviceCaps as 
        /// follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
        /// </summary>
        SM_CXSCREEN = 0,

        /// <summary>
        /// Height of the screen of the primary display monitor, in pixels. 
        /// This is the same values obtained by calling GetDeviceCaps as 
        /// follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
        /// </summary>
        SM_CYSCREEN = 1,

        /// <summary>
        /// Width of a horizontal scroll bar, in pixels.
        /// </summary>
        SM_CYVSCROLL = 2,

        /// <summary>
        /// Height of a horizontal scroll bar, in pixels.
        /// </summary>
        SM_CXVSCROLL = 3,

        /// <summary>
        /// Height of a caption area, in pixels.
        /// </summary>
        SM_CYCAPTION = 4,

        /// <summary>
        /// Width of a window border, in pixels. This is equivalent to the
        /// SM_CXEDGE value for windows with the 3-D look. 
        /// </summary>
        SM_CXBORDER = 5,

        /// <summary>
        /// Height of a window border, in pixels. This is equivalent to the 
        /// SM_CYEDGE value for windows with the 3-D look. 
        /// </summary>
        SM_CYBORDER = 6,

        /// <summary>
        /// Thickness of the frame around the perimeter of a window that has
        /// a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the
        /// height of the horizontal border and SM_CYFIXEDFRAME is the width
        /// of the vertical border. 
        /// </summary>
        SM_CXDLGFRAME = 7,

        /// <summary>
        /// Thickness of the frame around the perimeter of a window that has
        /// a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the
        /// height of the horizontal border and SM_CYFIXEDFRAME is the width
        /// of the vertical border. 
        /// </summary>
        SM_CYDLGFRAME = 8,

        /// <summary>
        /// Height of the thumb box in a vertical scroll bar, in pixels
        /// </summary>
        SM_CYVTHUMB = 9,

        /// <summary>
        /// Width of the thumb box in a horizontal scroll bar, in pixels.
        /// </summary>
        SM_CXHTHUMB = 10,

        /// <summary>
        /// Default width of an icon, in pixels. The LoadIcon function can 
        /// load only icons with the dimensions specified by SM_CXICON and
        /// SM_CYICON
        /// </summary>
        SM_CXICON = 11,

        /// <summary>
        /// Default height of an icon, in pixels. The LoadIcon function can 
        /// load only icons with the dimensions SM_CXICON and SM_CYICON.
        /// </summary>
        SM_CYICON = 12,

        /// <summary>
        /// Width of a cursor, in pixels. The system cannot create 
        /// cursors of other sizes.
        /// </summary>
        SM_CXCURSOR = 13,

        /// <summary>
        /// Height of a cursor, in pixels. The system cannot create cursors
        ///  of other sizes.
        /// </summary>
        SM_CYCURSOR = 14,

        /// <summary>
        /// Height of a single-line menu bar, in pixels.
        /// </summary>
        SM_CYMENU = 15,

        /// <summary>
        /// Width of the client area for a full-screen window on the primary
        /// display monitor, in pixels. To get the coordinates of the portion 
        /// of the screen not obscured by the system taskbar or by application 
        /// desktop toolbars, call the SystemParametersInfo function with the
        /// SPI_GETWORKAREA value.
        /// </summary>
        SM_CXFULLSCREEN = 16,

        /// <summary>
        /// Height of the client area for a full-screen window on the primary
        /// display monitor, in pixels. To get the coordinates of the portion
        /// of the screen not obscured by the system taskbar or by application
        /// desktop toolbars, call the SystemParametersInfo function with the
        /// SPI_GETWORKAREA value.
        /// </summary>
        SM_CYFULLSCREEN = 17,

        /// <summary>
        /// For double byte character set versions of the system, this is the
        /// height of the Kanji window at the bottom of the screen, in pixels.
        /// </summary>
        SM_CYKANJIWINDOW = 18,

        /// <summary>
        /// Nonzero if a mouse with a wheel is installed; zero otherwise
        /// </summary>
        SM_MOUSEWHEELPRESENT = 75,

        /// <summary>
        /// Height of the arrow bitmap on a vertical scroll bar, in pixels.
        /// </summary>
        SM_CYHSCROLL = 20,

        /// <summary>
        /// Width of the arrow bitmap on a horizontal scroll bar, in pixels.
        /// </summary>
        SM_CXHSCROLL = 21,

        /// <summary>
        /// Nonzero if the debug version of User.exe is installed; zero
        /// otherwise.
        /// </summary>
        SM_DEBUG = 22,

        /// <summary>
        /// Nonzero if the left and right mouse buttons are reversed; zero
        /// otherwise.
        /// </summary>
        SM_SWAPBUTTON = 23,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        SM_RESERVED1 = 24,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        SM_RESERVED2 = 25,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        SM_RESERVED3 = 26,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        SM_RESERVED4 = 27,

        /// <summary>
        /// Minimum width of a window, in pixels.
        /// </summary>
        SM_CXMIN = 28,

        /// <summary>
        /// Minimum height of a window, in pixels.
        /// </summary>
        SM_CYMIN = 29,

        /// <summary>
        /// Width of a button in a window's caption or title bar, in pixels.
        /// </summary>
        SM_CXSIZE = 30,

        /// <summary>
        /// Height of a button in a window's caption or title bar, in pixels.
        /// </summary>
        SM_CYSIZE = 31,

        /// <summary>
        /// Thickness of the sizing border around the perimeter of a window 
        /// that can be resized, in pixels. SM_CXSIZEFRAME is the width of the
        /// horizontal border, and SM_CYSIZEFRAME is the height of the
        /// vertical border. 
        /// </summary>
        SM_CXFRAME = 32,

        /// <summary>
        /// Thickness of the sizing border around the perimeter of a window 
        /// that can be resized, in pixels. SM_CXSIZEFRAME is the width of the
        /// horizontal border, and SM_CYSIZEFRAME is the height of the 
        /// vertical border. 
        /// </summary>
        SM_CYFRAME = 33,

        /// <summary>
        /// Minimum tracking width of a window, in pixels. The user cannot drag
        /// the window frame to a size smaller than these dimensions. A window
        /// can override this value by processing the WM_GETMINMAXINFO message.
        /// </summary>
        SM_CXMINTRACK = 34,

        /// <summary>
        /// Minimum tracking height of a window, in pixels. The user cannot 
        /// drag the window frame to a size smaller than these dimensions. A 
        /// window can override this value by processing the WM_GETMINMAXINFO
        /// message
        /// </summary>
        SM_CYMINTRACK = 35,

        /// <summary>
        /// Width of the rectangle around the location of a first click in a 
        /// double-click sequence, in pixels. The second click must occur 
        /// within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK 
        /// for the system to consider the two clicks a double-click
        /// </summary>
        SM_CXDOUBLECLK = 36,

        /// <summary>
        /// Height of the rectangle around the location of a first click in a
        /// double-click sequence, in pixels. The second click must occur 
        /// within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK
        /// for the system to consider the two clicks a double-click. (The two
        /// clicks must also occur within a specified time.) 
        /// </summary>
        SM_CYDOUBLECLK = 37,

        /// <summary>
        /// Width of a grid cell for items in large icon view, in pixels. Each
        /// item fits into a rectangle of size SM_CXICONSPACING by 
        /// SM_CYICONSPACING when arranged. This value is always greater 
        /// than or equal to SM_CXICON
        /// </summary>
        SM_CXICONSPACING = 38,

        /// <summary>
        /// Height of a grid cell for items in large icon view, in pixels. 
        /// Each item fits into a rectangle of size SM_CXICONSPACING by 
        /// SM_CYICONSPACING when arranged. This value is always greater than
        /// or equal to SM_CYICON.
        /// </summary>
        SM_CYICONSPACING = 39,

        /// <summary>
        /// Nonzero if drop-down menus are right-aligned with the corresponding
        /// menu-bar item; zero if the menus are left-aligned.
        /// </summary>
        SM_MENUDROPALIGNMENT = 40,

        /// <summary>
        /// Nonzero if the Microsoft Windows for Pen computing extensions are
        /// installed; zero otherwise.
        /// </summary>
        SM_PENWINDOWS = 41,

        /// <summary>
        /// Nonzero if User32.dll supports DBCS; zero otherwise. 
        /// (WinMe/95/98): Unicode
        /// </summary>
        SM_DBCSENABLED = 42,

        /// <summary>
        /// Number of buttons on mouse, or zero if no mouse is installed.
        /// </summary>
        SM_CMOUSEBUTTONS = 43,

        /// <summary>
        /// Identical Values Changed After Windows NT 4.0  
        /// </summary>
        SM_CXFIXEDFRAME = SM_CXDLGFRAME,

        /// <summary>
        /// Identical Values Changed After Windows NT 4.0
        /// </summary>
        SM_CYFIXEDFRAME = SM_CYDLGFRAME,

        /// <summary>
        /// Identical Values Changed After Windows NT 4.0
        /// </summary>
        SM_CXSIZEFRAME = SM_CXFRAME,

        /// <summary>
        /// Identical Values Changed After Windows NT 4.0
        /// </summary>
        SM_CYSIZEFRAME = SM_CYFRAME,

        /// <summary>
        /// Nonzero if security is present; zero otherwise.
        /// </summary>
        SM_SECURE = 44,

        /// <summary>
        /// Width of a 3-D border, in pixels. This is the 3-D counterpart 
        /// of SM_CXBORDER.
        /// </summary>
        SM_CXEDGE = 45,

        /// <summary>
        /// Height of a 3-D border, in pixels. This is the 3-D counterpart 
        /// of SM_CYBORDER.
        /// </summary>
        SM_CYEDGE = 46,

        /// <summary>
        /// Width of a grid cell for a minimized window, in pixels. Each 
        /// minimized window fits into a rectangle this size when arranged. 
        /// This value is always greater than or equal to SM_CXMINIMIZED.
        /// </summary>
        SM_CXMINSPACING = 47,

        /// <summary>
        /// Height of a grid cell for a minimized window, in pixels. Each 
        /// minimized window fits into a rectangle this size when arranged. 
        /// This value is always greater than or equal to SM_CYMINIMIZED.
        /// </summary>
        SM_CYMINSPACING = 48,

        /// <summary>
        /// Recommended width of a small icon, in pixels. Small icons typically
        /// appear in window captions and in small icon view
        /// </summary>
        SM_CXSMICON = 49,

        /// <summary>
        /// Recommended height of a small icon, in pixels. Small icons 
        /// typically appear in window captions and in small icon view.
        /// </summary>
        SM_CYSMICON = 50,

        /// <summary>
        /// Height of a small caption, in pixels
        /// </summary>
        SM_CYSMCAPTION = 51,
        /// <summary>
        /// Width of small caption buttons, in pixels.
        /// </summary>
        SM_CXSMSIZE = 52,

        /// <summary>
        /// Height of small caption buttons, in pixels.
        /// </summary>
        SM_CYSMSIZE = 53,

        /// <summary>
        /// Width of menu bar buttons, such as the child window close button
        /// used in the multiple document interface, in pixels.
        /// </summary>
        SM_CXMENUSIZE = 54,

        /// <summary>
        /// Height of menu bar buttons, such as the child window close button
        /// used in the multiple document interface, in pixels.
        /// </summary>
        SM_CYMENUSIZE = 55,

        /// <summary>
        /// Flags specifying how the system arranged minimized windows
        /// </summary>
        SM_ARRANGE = 56,

        /// <summary>
        /// Width of a minimized window, in pixels.
        /// </summary>
        SM_CXMINIMIZED = 57,

        /// <summary>
        /// Height of a minimized window, in pixels.
        /// </summary>
        SM_CYMINIMIZED = 58,

        /// <summary>
        /// Default maximum width of a window that has a caption and sizing 
        /// borders, in pixels. This metric refers to the entire desktop. The
        /// user cannot drag the window frame to a size larger than these 
        /// dimensions. A window can override this value by processing the 
        /// WM_GETMINMAXINFO message.
        /// </summary>
        SM_CXMAXTRACK = 59,

        /// <summary>
        /// Default maximum height of a window that has a caption and sizing 
        /// borders, in pixels. This metric refers to the entire desktop. The
        /// user cannot drag the window frame to a size larger than these 
        /// dimensions. A window can override this value by processing the 
        /// WM_GETMINMAXINFO message.
        /// </summary>
        SM_CYMAXTRACK = 60,

        /// <summary>
        /// Default width, in pixels, of a maximized top-level window on the
        /// primary display monitor.
        /// </summary>
        SM_CXMAXIMIZED = 61,

        /// <summary>
        /// Default height, in pixels, of a maximized top-level window on the 
        /// primary display monitor.
        /// </summary>
        SM_CYMAXIMIZED = 62,

        /// <summary>
        /// Least significant bit is set if a network is present; otherwise, 
        /// it is cleared. The other bits are reserved for future use
        /// </summary>
        SM_NETWORK = 63,

        /// <summary>
        /// Value that specifies how the system was started: 0-normal, 
        /// 1-failsafe, 2-failsafe /w net
        /// </summary>
        SM_CLEANBOOT = 67,

        /// <summary>
        /// Width of a rectangle centered on a drag point to allow for limited
        /// movement of the mouse pointer before a drag operation begins, 
        /// in pixels. 
        /// </summary>
        SM_CXDRAG = 68,

        /// <summary>
        /// Height of a rectangle centered on a drag point to allow for limited
        /// movement of the mouse pointer before a drag operation begins. This 
        /// value is in pixels. It allows the user to click and release the 
        /// mouse button easily without unintentionally starting a drag 
        /// operation.
        /// </summary>
        SM_CYDRAG = 69,

        /// <summary>
        /// Nonzero if the user requires an application to present information
        /// visually in situations where it would otherwise present the 
        /// information only in audible form; zero otherwise. 
        /// </summary>
        SM_SHOWSOUNDS = 70,

        /// <summary>
        /// Width of the default menu check-mark bitmap, in pixels.
        /// </summary>
        SM_CXMENUCHECK = 71,

        /// <summary>
        /// Height of the default menu check-mark bitmap, in pixels.
        /// </summary>
        SM_CYMENUCHECK = 72,

        /// <summary>
        /// Nonzero if the computer has a low-end (slow) processor; 
        /// zero otherwise.
        /// </summary>
        SM_SLOWMACHINE = 73,

        /// <summary>
        /// Nonzero if the system is enabled for Hebrew and Arabic languages,
        /// zero if not.
        /// </summary>
        SM_MIDEASTENABLED = 74,

        /// <summary>
        /// Nonzero if a mouse is installed; zero otherwise. This value is 
        /// rarely zero, because of support for virtual mice and because some 
        /// systems detect the presence of the port instead of the presence of
        /// a mouse.
        /// </summary>
        SM_MOUSEPRESENT = 19,

        /// <summary>
        /// Windows 2000 (v5.0+) Coordinate of the top of the virtual screen.
        /// </summary>
        SM_XVIRTUALSCREEN = 76,

        /// <summary>
        /// Windows 2000 (v5.0+) Coordinate of the left of the virtual screen.
        /// </summary>
        SM_YVIRTUALSCREEN = 77,

        /// <summary>
        /// Windows 2000 (v5.0+) Width of the virtual screen.
        /// </summary>
        SM_CXVIRTUALSCREEN = 78,

        /// <summary>
        /// Windows 2000 (v5.0+) Height of the virtual screen.
        /// </summary>
        SM_CYVIRTUALSCREEN = 79,

        /// <summary>
        /// Number of display monitors on the desktop.
        /// </summary>
        SM_CMONITORS = 80,

        /// <summary>
        /// Windows XP (v5.1+) Nonzero if all the display monitors have the 
        /// same color format, zero otherwise. Note that two displays can have
        /// the same bit depth, but different color formats. For example, the 
        /// red, green, and blue pixels can be encoded with different numbers
        /// of bits, or those bits can be located in different places in a 
        /// pixel's color value. 
        /// </summary>
        SM_SAMEDISPLAYFORMAT = 81,

        /// <summary>
        /// Windows XP (v5.1+) Nonzero if Input Method Manager/Input Method 
        /// Editor features are enabled; zero otherwise.
        /// </summary>
        SM_IMMENABLED = 82,

        /// <summary>
        /// Windows XP (v5.1+) Width of the left and right edges of the focus 
        /// rectangle drawn by DrawFocusRect. This value is in pixels. 
        /// </summary>
        SM_CXFOCUSBORDER = 83,

        /// <summary>
        /// Windows XP (v5.1+) Height of the top and bottom edges of the focus 
        /// rectangle drawn by DrawFocusRect. This value is in pixels. 
        /// </summary>
        SM_CYFOCUSBORDER = 84,

        /// <summary>
        /// Nonzero if the current operating system is the Windows XP Tablet PC 
        /// edition, zero if not.
        /// </summary>
        SM_TABLETPC = 86,

        /// <summary>
        /// Nonzero if the current operating system is the Windows XP, Media 
        /// Center Edition, zero if not.
        /// </summary>
        SM_MEDIACENTER = 87,

        /// <summary>
        /// Metrics Other
        /// </summary>
        SM_CMETRICS_OTHER = 76,

        /// <summary>
        /// Metrics Windows 2000
        /// </summary>
        SM_CMETRICS_2000 = 83,

        /// <summary>
        /// Metrics Windows NT
        /// </summary>
        SM_CMETRICS_NT = 88,

        /// <summary>
        /// Windows XP (v5.1+) This system metric is used in a Terminal 
        /// Services environment. If the calling process is associated with a 
        /// Terminal Services client session, the return value is nonzero. If 
        /// the calling process is associated with the Terminal Server console 
        /// session, the return value is zero. The console session is not 
        /// necessarily the physical console - see WTSGetActiveConsoleSessionId 
        /// for more information. 
        /// </summary>
        SM_REMOTESESSION = 0x1000,

        /// <summary>
        /// Windows XP (v5.1+) Nonzero if the current session is shutting down; 
        /// zero otherwise.
        /// </summary>
        SM_SHUTTINGDOWN = 0x2000,

        /// <summary>
        /// Windows XP (v5.1+) This system metric is used in a Terminal 
        /// Services environment. Its value is nonzero if the current session 
        /// is remotely controlled; zero otherwise.
        /// </summary>
        SM_REMOTECONTROL = 0x2001,
    }
    #endregion


}