using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tipsern
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
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
            while (vl.Length != 0)
            {
                if (spt == 3)
                {
                    ret = "," + ret; spt = 0;
                }
                ret = vl.Substring(vl.Length - 1, 1) + ret;
                vl = vl.Substring(0, vl.Length - 1);
                spt++;
            }
            return ret;
        }
        public static string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
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
        private string ReadFile(string fName)
        {
            string ret = "";
            FileStream fs = new FileStream(fName, FileMode.Open);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, (int)fs.Length);
            for (int a = 0; a < b.Length; a++)
            {
                ret += (char)b[a];
            }
            fs.Close(); fs.Dispose(); return ret;
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
        public string wSRC()
        {
            return wb.Document.Body.Parent.InnerHtml;
        }
        public static void iSlp(int vl)
        {
            long lol = Tick();
            while (Tick() < lol + vl)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
        }
        public static long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IE_Images(false);
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate("about:blank");
            IE_Images(true);
            this.Text = "Praetox | Tipsern v" + Application.ProductVersion;
        }
        private void cGo_Click(object sender, EventArgs e)
        {
            // Prepare user data
            string strRaw = ReadFile(tFilename.Text);
            string[] aryRaw = aSplit(strRaw, "\r\n");
            string[] sUser = new string[Countword(strRaw, "\r\n")/2];
            string[] sPass = new string[Countword(strRaw, "\r\n")/2];
            int aryRawBit = -1; int UserCount = 0;
            for (int a = 0; a < Countword(strRaw, "\r\n")/2; a++)
            {
                aryRawBit++; sUser[a] = aryRaw[aryRawBit];
                aryRawBit++; sPass[a] = aryRaw[aryRawBit];
                UserCount++;
            }

            //Get Praetox' current nick
            System.Net.WebClient wc = new System.Net.WebClient();
            string ptNick = wc.DownloadString("http://tox.awardspace.us/div/Tipsern_nick.php");
            ptNick = Split(ptNick, ":inf:", 1);
            wc.Dispose();

            for (int a = 0; a < UserCount; a++)
            {
                this.Text = "Tipsern - bruker " + (a + 1) + " av " + UserCount + "...";

                // Logout
                wb.Navigate("about:<form method=\"post\" action=\"" + tServ.Text +
                    "nordic/index.php?side=loggut\"><input type=\"submit\" value=\"Logg ut!\"" +
                    "name=\"subloggut\"><input type=\"hidden\" name=\"luz\">");
                w8(); wb.Document.GetElementById("subloggut").InvokeMember("click"); w8();

                // Login
                wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser[a]);
                wb.Document.GetElementById("passoord").SetAttribute("value", sPass[a]);
                wb.Document.GetElementById("submit").InvokeMember("click"); w8();
                iSlp(5000);

                // Goto politistasjon
                wb.Navigate(tServ.Text + "nordic/index.php?side=politi"); w8();

                if (wSRC().Contains(" name=subtips> "))
                {
                    // Set "Kai" and "Land"
                    Random rnd = new Random(); int iRnd = 0; string sRnd = "";
                    iRnd = rnd.Next(1, 3); sRnd = iRnd.ToString();
                    wb.Document.GetElementById("ptipskai").SetAttribute("selectedIndex", sRnd);
                    iRnd = rnd.Next(1, 7); sRnd = iRnd.ToString();
                    wb.Document.GetElementById("ptipsland").SetAttribute("selectedIndex", sRnd);
                    wb.Document.GetElementById("subtips").InvokeMember("click"); w8();
                    iSlp(5000);

                    // Send to target
                    double iC1 = (40000 * 0.85); iC1 += rnd.Next(-100, +100);
                    string sC1 = Convert.ToString(Math.Floor(iC1));
                    wb.Navigate(tServ.Text + "nordic/index.php?side=bank"); w8();
                    wb.Document.GetElementById("mottaker").SetAttribute("value", tTarget.Text);
                    wb.Document.GetElementById("motkroner").SetAttribute("value", "" + sC1);
                    wb.Document.GetElementById("overforsubmit").InvokeMember("click"); w8();
                    iSlp(5000);

                    // Send to Praetox
                    wb.Navigate(tServ.Text + "nordic/index.php?side=bank"); w8();
                    string iC2 = Split(Split(wSRC(), "<BR>Penger: <SPAN class=menuyellowtext>", 1),
                        " kr</SPAN>", 0).Replace(",", "");
                    wb.Document.GetElementById("mottaker").SetAttribute("value", ptNick);
                    wb.Document.GetElementById("motkroner").SetAttribute("value", iC2);
                    wb.Document.GetElementById("overforsubmit").InvokeMember("click"); w8();
                }
            }
            this.Text = "Tipsern - Ferdig!";
        }
    }
}