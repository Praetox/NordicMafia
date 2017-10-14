using System;
using System.Text;
using System.Collections.Generic;
//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data;
using System.Runtime.InteropServices;

namespace AutoNM
{
    public class MP3
    {
        private string Pcommand; private bool isOpen;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(
            string strCommand,          // The command to execute
            StringBuilder strReturn,    // The returned string (if any)
            int iReturnLength,          // The bitcount of the returned string
            IntPtr hwndCallback);       // Callback value of spec. handle
        public MP3()
        {
        }

        public void Close()
        {
            Pcommand = "close ANmCs";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        public void Open(string sFileName)
        {
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias ANmCs";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        public void Play(bool loop)
        {
            if (isOpen)
            {
                Pcommand = "play ANmCs";
                if (loop) Pcommand += " REPEAT";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }
    }

    public class FormPos
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
           int hWnd,               // Window handle
           int hWndInsertAfter,    // Placement-order handle
           int X,                  // Horizontal position
           int Y,                  // Vertical position
           int cx,                 // Width
           int cy,                 // Height
           uint uFlags);           // Window positioning flags
        public const int HWND_BOTTOM = 0x1;
        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;
        public const uint SWP_HIDEWINDOW = 0x80;
    }

    public class DlFile
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Int32 URLDownloadToFile(
            [MarshalAs(UnmanagedType.IUnknown)] object pCaller,
            [MarshalAs(UnmanagedType.LPWStr)] string szURL,
            [MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            Int32 dwReserved,
            IntPtr lpfnCB);
    }

    public class GKHook
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(
            System.Windows.Forms.Keys vKey);    // The keycode to poll for
    }   
}
