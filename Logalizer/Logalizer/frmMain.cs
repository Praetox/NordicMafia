using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logalizer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Splitting
        public static string Split(string msg, string delim, int part)
        {
            try
            {
                string ret;
                string repd = "" + (char)2449 + (char)3983 + (char)5422 + (char)7882 + (char)9003;
                msg = msg.Replace("" + (char)9376, repd);
                ret = msg.Replace(delim, "" + (char)9376).Split((char)9376)[part];
                ret = ret.Replace(repd, "" + (char)9376);
                return ret;
            }
            catch { return ""; }
        }
        public static string[] aSplit(string msg, string delim)
        {
            try
            {
                string[] ret;
                string repd = "" + (char)2449 + (char)3983 + (char)5422 + (char)7882 + (char)9003;
                msg = msg.Replace("" + (char)9376, repd);
                ret = msg.Replace(delim, "" + (char)9376).Split((char)9376);
                for (int a = 0; a < ret.Length; a++)
                {
                    ret[a] = ret[a].Replace(repd, "" + (char)9376);
                }
                return ret;
            }
            catch { return new string[1]; }
        }
        public static string sSplit(string msg, string delim, int part)
        {
            try
            {
                int loc = -1;
                for (int a = 0; a < part; a++)
                {
                    loc = msg.IndexOf(delim, loc + 1);
                }
                return msg.Substring(loc + delim.Length);
            }
            catch { return ""; }
        }
        #endregion

        public static string strLog = "";
        public static string[] saClk, saVer, saID, saIP;

        private void cmdPasteLog_Click(object sender, EventArgs e)
        {
            strLog = Clipboard.GetText();
            strLog = strLog.Replace("\r", "");
            while (strLog.EndsWith("\n"))
                strLog = strLog.Substring(0, strLog.Length - 1);
        }

        private void cmdAnalyze_Click(object sender, EventArgs e)
        {
            cmdAnalyze.Enabled = false; Application.DoEvents();
            long StartTick = ((System.DateTime.Now.Ticks) / 10000);
            saClk = null; saVer = null; saID = null; saIP = null;
            cbClk.Items.Clear(); cbVer.Items.Clear();
            cbID.Items.Clear(); cbIP.Items.Clear();
            dgv.RowCount = 0;

            string stClk = "\n", stVer = "\n", stID = "\n", stIP = "\n",
                   sdClk = "\n", sdVer = "\n", sdID = "\n", sdIP = "\n";
            int iPClk = Convert.ToInt16(txtPClk.Text);
            int iPVer = Convert.ToInt16(txtPVer.Text);
            int iPID = Convert.ToInt16(txtPID.Text);
            int iPIP = Convert.ToInt16(txtPIP.Text);

            string[] LogElements = aSplit(strLog, "\n");
            foreach (string LogElement in LogElements)
            {
                string sClk = Split(LogElement, " | ", iPClk);
                string sVer = Split(LogElement, " | ", iPVer);
                string sID = Split(LogElement, " | ", iPID);
                string sIP = Split(LogElement, " | ", iPIP);
                if (sClk == "") sClk = "null";
                if (sVer == "") sVer = "null";
                if (sID == "") sID = "null";
                if (sIP == "") sIP = "null";

                if (!sdClk.Contains("\n" + Split(sClk, " ", 0) + "\n"))
                    sdClk += Split(sClk, " ", 0) + "\n";
                if (!sdVer.Contains("\n" + sVer + "\n")) sdVer += sVer + "\n";
                if (!sdID.Contains("\n" + sID + "\n")) sdID += sID + "\n";
                if (!sdIP.Contains("\n" + sIP + "\n")) sdIP += sIP + "\n";

                stClk += sClk + "\n";
                stVer += sVer + "\n";
                stID += sID + "\n";
                stIP += sIP + "\n";
            }

            stClk = stClk.Substring(0, stClk.Length - 1).Substring(1);
            stVer = stVer.Substring(0, stVer.Length - 1).Substring(1);
            stID = stID.Substring(0, stID.Length - 1).Substring(1);
            stIP = stIP.Substring(0, stIP.Length - 1).Substring(1);

            sdClk = sdClk.Substring(0, sdClk.Length - 1).Substring(1);
            sdVer = sdVer.Substring(0, sdVer.Length - 1).Substring(1);
            sdID = sdID.Substring(0, sdID.Length - 1).Substring(1);
            sdIP = sdIP.Substring(0, sdIP.Length - 1).Substring(1);

            saClk = aSplit(stClk, "\n");
            saVer = aSplit(stVer, "\n");
            saID = aSplit(stID, "\n");
            saIP = aSplit(stIP, "\n");

            string[] sadClk = aSplit(sdClk, "\n");
            string[] sadVer = aSplit(sdVer, "\n");
            string[] sadID = aSplit(sdID, "\n");
            string[] sadIP = aSplit(sdIP, "\n");

            foreach (string sClk in sadClk) cbClk.Items.Add(sClk);
            foreach (string sVer in sadVer) cbVer.Items.Add(sVer);
            foreach (string sID in sadID) cbID.Items.Add(sID);
            foreach (string sIP in sadIP) cbIP.Items.Add(sIP);

            gbClk.Text = "Date ------------- " + sadClk.Length;
            gbVer.Text = "Version --------- " + sadVer.Length;
            gbID.Text = "Identification - " + sadID.Length;
            gbIP.Text = "IP address ---- " + sadIP.Length;

            cmdAnalyze.Enabled = true;
            MessageBox.Show("Completed in " +
                (((System.DateTime.Now.Ticks) / 10000) - StartTick) + "ms");
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdClk = "";
            sdClk = cbClk.Text;
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (Split(saClk[a], " ", 0) == sdClk)
                {
                    stClk += saClk[a] + "\n";
                    stVer += saVer[a] + "\n";
                    stID += saID[a] + "\n";
                    stIP += saIP[a] + "\n";
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }

        private void cbVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdVer = "";
            sdVer = cbVer.Text;
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (saVer[a] == sdVer)
                {
                    stClk += saClk[a] + "\n";
                    stVer += saVer[a] + "\n";
                    stID += saID[a] + "\n";
                    stIP += saIP[a] + "\n";
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }

        private void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdID = "", sdIP = "\n";
            bool chkUID = chkUniqueID.Checked;
            sdID = cbID.Text;
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (saID[a] == sdID)
                {
                    bool Resume = true;
                    if (chkUID) if (sdIP.Contains("\n" + saIP[a] + "\n")) Resume = false;
                    if (Resume)
                    {
                        if (chkUID) sdIP += saIP[a] + "\n";
                        stClk += saClk[a] + "\n";
                        stVer += saVer[a] + "\n";
                        stID += saID[a] + "\n";
                        stIP += saIP[a] + "\n";
                    }
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }

        private void cbIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdIP = "", sdID = "\n";
            bool chkUIP = chkUniqueIP.Checked;
            sdIP = cbIP.Text;
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (saIP[a] == sdIP)
                {
                    bool Resume = true;
                    if (chkUIP) if (sdID.Contains("\n" + saID[a] + "\n")) Resume = false;
                    if (Resume)
                    {
                        if (chkUIP) sdID += saID[a] + "\n";
                        stClk += saClk[a] + "\n";
                        stVer += saVer[a] + "\n";
                        stID += saID[a] + "\n";
                        stIP += saIP[a] + "\n";
                    }
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }

        private void AssignGridview(string stClk, string stVer, string stID, string stIP)
        {
            string[] sgvClk = aSplit(stClk.Substring(0, stClk.Length - 1), "\n");
            string[] sgvVer = aSplit(stVer.Substring(0, stVer.Length - 1), "\n");
            string[] sgvID = aSplit(stID.Substring(0, stID.Length - 1), "\n");
            string[] sgvIP = aSplit(stIP.Substring(0, stIP.Length - 1), "\n");
            dgv.RowCount = sgvClk.Length;
            for (int a = 0; a < sgvClk.Length; a++)
            {
                dgv[0, sgvClk.Length-a-1].Value = sgvClk[a];
                dgv[1, sgvClk.Length-a-1].Value = sgvVer[a];
                dgv[2, sgvClk.Length-a-1].Value = sgvID[a];
                dgv[3, sgvClk.Length-a-1].Value = sgvIP[a];
            }
            gbReport.Text = "Report - " + sgvClk.Length + " entries";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgv.RowCount = 100;
            dgv[0, 0].Value = "08-01-18 19:45:57";
            dgv[1, 0].Value = "1.0.13.27";
            dgv[2, 0].Value = "3b83ce2a";
            dgv[3, 0].Value = "214.251.195.121";
        }

        private void cmdUniqueID_Click(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdUniCnt = "\n";
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (!sdUniCnt.Contains("\n" + saID[a] + "\n"))
                {
                    sdUniCnt += saID[a] + "\n";
                    stClk += saClk[a] + "\n";
                    stVer += saVer[a] + "\n";
                    stID += saID[a] + "\n";
                    stIP += saIP[a] + "\n";
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }

        private void cmdUniqueIP_Click(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdUniCnt = "\n";
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (!sdUniCnt.Contains("\n" + saIP[a] + "\n"))
                {
                    sdUniCnt += saIP[a] + "\n";
                    stClk += saClk[a] + "\n";
                    stVer += saVer[a] + "\n";
                    stID += saID[a] + "\n";
                    stIP += saIP[a] + "\n";
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }

        private void cmdUniqueIDIP_Click(object sender, EventArgs e)
        {
            string stClk = "", stVer = "", stID = "", stIP = "",
                   sdUniCnt = "\n";
            for (int a = saClk.Length - 1; a >= 0; a--)
            {
                if (!sdUniCnt.Contains("\n" + saID[a] + "|" + saIP[a] + "\n"))
                {
                    sdUniCnt += saID[a] + "|" + saIP[a] + "\n";
                    stClk += saClk[a] + "\n";
                    stVer += saVer[a] + "\n";
                    stID += saID[a] + "\n";
                    stIP += saIP[a] + "\n";
                }
            }
            AssignGridview(stClk, stVer, stID, stIP);
        }
    }
}
