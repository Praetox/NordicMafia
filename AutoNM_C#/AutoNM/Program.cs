using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoNM
{
    static class Program
    {
        public static long oTrsp = 0;
        public static long oKrim = 0, oPress = 1, oBil = 0, oFCt = 1, oFCa = 1, oKjop = -1, oBryt = -1, oEst = 1, vEst = 60, oAbt = 1;
        public static string vBryt = "", vFCa = "";
        public static long st_cKrim = 0, st_cPress = 0, st_cBil = 0, st_cBryt = 0, st_cFCt = 0, st_cFCa = 0;
        public static long st_fKrim = 0, st_fPress = 0, st_fBil = 0, st_fBryt = 0;
        public static long pRB_StartPerc = 0, pRB_LastPerc = 0, pRB_LastTick, pRB_TotlTime = 0;
        public static string st_pFCl = "n/a", st_pFCs = "n/a", st_pRank = "n/a", st_pCash = "n/a";
        public static string st_vBryt = "";
        public static string st_bLaunch = System.DateTime.Now.ToLongDateString() + " .::. " +
                                          System.DateTime.Now.ToLongTimeString();
        public static string Gamedomain = "http://www.nordicmafia.net/";
        //public static string Gamedomain = "http://www.nordicmafia.dk/";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}