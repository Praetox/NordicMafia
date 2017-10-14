using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pengebot
{
    static class Program
    {
        //public static string Gamedomain = "http://www.nordicmafia.net/";
        public static string Gamedomain = "http://www.nordicmafia.dk/";
        public static int StopVal, MaxWin, MaxLoss, MaxPush;
        public static bool CAErr;
        public static string strCNow;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StopVal = 17; MaxWin = 0; MaxLoss = 0; MaxPush = 0;
            Application.Run(new frmMain());
        }
    }
}