using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pengebot
{
    public partial class frmMain : Form
    {
        bool intMain, bStop; long curvl;

        public frmMain()
        {
            InitializeComponent();
        }

        public static byte[] StrToByte(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
        public static string ByteToStr(byte[] dBytes)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(dBytes);
            return str;
        }
        public static string Split(string msg, string delim, int part)
        {
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        public static string[] aSplit(string msg, string delim)
        {
            int spt = 0; string[] ret = new string[Countword(msg, delim)+1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        public static int Countword(string msg, string delim)
        {
            int ret = 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
            }
            return ret;
        }
        public static string Decimize(string vl)
        {
            string ret = ""; int spt = 0;
            while (vl.Length!=0)
            {
                if (spt==3){
                    ret = "," + ret; spt = 0;
                }
                ret = vl.Substring(vl.Length-1, 1) + ret;
                vl = vl.Substring(0, vl.Length-1);
                spt++;
            }
            return ret;
        }
        public static string Space(int vl)
        {
            string ret = " ";
            for (int a = 1; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }
        public static void IE_Images(bool show)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            key = key.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main", true);
            if (show) key.SetValue("Display Inline Images", "yes");
            if (!show) key.SetValue("Display Inline Images", "no");
            key.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IE_Images(false);
            this.wb.Navigate("about:blank");
            IE_Images(true);
            wb.ScriptErrorsSuppressed = true;
        }
        public void Nav(string url, string vl)
        {
            wb.Navigate(url); Application.DoEvents();
            if (vl == "") { w8(); } else { w8u(vl); }
            if (Login()) { Nav(url, vl); }
        }
        public void w8()
        {
            Application.DoEvents();
            while (wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
        }
        public void w8u(string vl)
        {
            Application.DoEvents();
            while (wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if (wb.DocumentText.Contains(vl)) break;
            }
        }
        public string wSRC()
        {
            return wb.Document.Body.Parent.InnerHtml;
        }
        public bool WPC(string vl)
        {
            return wSRC().Contains(vl);
        }
        public bool Login()
        {
            bool ret = false;
            if (WPC("Du er ikke logget inn!") || WPC("Du ble logget inn fra et annet sted.") || 
                WPC("Du er ikke logged ind!"))
            {
                fStatus("Logger inn...");
                wb.Document.GetElementById("brukernavn").SetAttribute("value", txtUser.Text);
                wb.Document.GetElementById("passoord").SetAttribute("value", txtPass.Text);
                wb.Document.GetElementById("submit").InvokeMember("click"); w8();
                ret = true;
            }
            return ret;
        }
        private void cmdStart_Click(object sender, EventArgs e)
        {
            fStatus("Starter...");
            txtBelop.Text = txtBelop.Text.Replace(" ", "");
            if (txtExpo.Text == "") txtExpo.Text = "0";
            while (txtBelop.Text.EndsWith("0"))
            {
                txtBelop.Text = txtBelop.Text.Substring(0, txtBelop.Text.Length - 1);
                txtExpo.Text = Convert.ToString(Convert.ToInt32(txtExpo.Text) + 1);
            }
            Nav(Program.Gamedomain + "nordic/index.php?side=blackjack", "");
            lbCStart.Text = Split(Split(wSRC(), "Penger: <SPAN class=menuyellowtext>", 1), " kr", 0);
            tMain.Start();
        }
        private void cmdStopp_Click(object sender, EventArgs e)
        {
            fStatus("Stopper uten å tape penger...");
            bStop = true;
        }
        private void cmdPanikk_Click(object sender, EventArgs e)
        {
            fStatus("Panikkstopp! Penger kan ha gått tapt.");
            tMain.Stop();
        }
        private void cmdConfig_Click(object sender, EventArgs e)
        {
            Nav(Program.Gamedomain + "nordic/index.php?side=blackjack", "");
            Program.strCNow = Split(Split(wSRC(), "Penger: <SPAN class=menuyellowtext>", 1), " kr", 0);
            Form fConf = new frmConfig();
            fConf.Show();
        }
        public void fStatus(string vl)
        {
            string TimeNow = System.DateTime.Now.ToLongTimeString();
            Status.Text = TimeNow + " - " + vl;
        }
        private void tMain_Tick(object sender, EventArgs e)
        {
            try
            {
                if (intMain) return; intMain = true;
                Nav(Program.Gamedomain + "nordic/index.php?side=blackjack", "");
                if (curvl == 0) lbCTotal.Text = Split(Split(wSRC(), "Penger: <SPAN class=menuyellowtext>", 1), " kr", 0);
                if (Split(wSRC(), "<B>Dine Kort:</B>", 1).Contains("cardback"))
                {
                    if (curvl == 0) curvl = Convert.ToInt32(txtBelop.Text);
                    if (lbMBet.Text == "~") lbMBet.Text = "0 x0";
                    string tmp = Split(lbMBet.Text, " x", 0);
                    if (curvl > Convert.ToInt32(tmp)) lbMBet.Text = curvl + " x10^" + txtExpo.Text;
                    lbCNow.Text = curvl + " x10^" + txtExpo.Text;
                    wb.Document.GetElementById("bjbelop").SetAttribute("value", curvl + Space(Convert.ToInt32(txtExpo.Text)).Replace(" ", "0"));
                    wb.Document.GetElementById("subbj").InvokeMember("click"); w8();
                }
                if (Split(wSRC(), "<B>Dine Kort:</B>", 1).Contains("cardback"))
                {
                    MessageBox.Show("Oisann, der blei du blakk! Muhahaha.");
                    tMain.Enabled = false;
                }

     tagResume: long cs = GetCards();
                if (cs < Program.StopVal)
                {
                    fStatus(cs + ". Nytt kort...");
                    wb.Document.GetElementById("nysubmit").InvokeMember("click"); w8();
                }else{
                    fStatus(cs + ". Står...");
                    wb.Document.GetElementById("stasubmit").InvokeMember("click"); w8();
                }
                cs = GetCards();

                if (WPC(", du tapte ") || WPC("Du fikk over 21 og tapte ") ||
                    WPC(", du tabte ") || WPC("Du fik over 21 og tabte "))
                {
                    double fcurvl = curvl; fcurvl = fcurvl * 2.1; curvl = Convert.ToInt32(fcurvl);
                    lbLoss.Text = Convert.ToString(Convert.ToInt32(lbLoss.Text) + 1);
                    fStatus("Tapte med " + cs);
                    goto tagQuit;
                }
                if (WPC(" og vant ") || WPC("Dealeren brøt, du vant ") ||
                    WPC(" og vandt ") || WPC("Dealeren brød, du vandt "))
                {
                    curvl = 0; lbWin.Text = Convert.ToString(Convert.ToInt32(lbWin.Text) + 1);
                    fStatus("Vant med " + cs);
                    if (bStop) { tMain.Stop(); bStop = false; }
                    goto tagQuit;
                }
                if (WPC("Det ble push, dere fikk samme sum") ||
                    WPC("Det blev push, dere fik samme sum."))
                {
                    lbPush.Text = Convert.ToString(Convert.ToInt32(lbPush.Text) + 1);
                    fStatus("Push med " + cs);
                    goto tagQuit;
                }
                goto tagResume;
            }
            catch
            {
                if (Program.CAErr) MessageBox.Show("Crash!");
            }
   tagQuit: if ((Convert.ToInt32(lbWin.Text) >= Program.MaxWin) && (Program.MaxWin>0)) tMain.Stop();
            if ((Convert.ToInt32(lbLoss.Text) >= Program.MaxLoss) && (Program.MaxLoss>0)) tMain.Stop();
            if ((Convert.ToInt32(lbPush.Text) >= Program.MaxPush) && (Program.MaxPush>0)) tMain.Stop();
            intMain = false;
        }
        public long GetCards()
        {
            if (Login()) Nav(Program.Gamedomain + "nordic/index.php?side=blackjack", "");
            long tc = 0, cs = 0;
            string scards = Split(Split(wSRC(), "<B>Dine Kort:</B>", 1), "<DIV>", 0);
            string[] cards = aSplit(scards, "images/kortstokk/");
            for (int a=1; a<Countword(scards,"images/kortstokk/")+1; a++){
                cards[a] = Split(Split(cards[a], "/", 1), ".gif", 0);
                tc = Convert.ToInt32(cards[a]);
                if ((tc == 1) || (tc == 14))
                {
                    if (cs + 11 > 21) { tc = 1; } else { tc = 11; }
                    cs = cs + tc;
                }
                else if ((tc >= 2) && (tc <= 10))
                {
                    cs = cs + tc;
                }
                else if ((tc >= 11) && (tc <= 13))
                {
                    tc = 10;
                    cs = cs + tc;
                }
            }
            return cs;
        }
    }
}