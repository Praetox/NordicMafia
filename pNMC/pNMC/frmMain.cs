using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pNMC
{
    public partial class frmMain : Form
    {
        public static string PM_Spam_sNicks = "", PM_Spam_sTopics = "",
            sUser = "", sPass = "", sGamedomain = "http://www.nordicmafia.net/";
        public static int ttGlobal = -1, ooGlobal = 4, t2aDelay = 1, Timeout = 10000,
            itKrim = -1, itPress = -1, itGTA = -1, itFC = -1;

        #region Load
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            wb.Navigate("about:blank"); Application.DoEvents();
            itKrim = T2A(0); itPress = T2A(0); itGTA = T2A(0); itFC = T2A(0);

            Form SplashForm = new frmSplash(); SplashForm.Show();
            
            sUser = FileRead("user.txt");
            string sUData = sUser.ToLower();
            if (sUData != "")
            {
                sUData = sUData.Replace("æ", "(ae)").Replace("ø", "(oo)").Replace("å", "(aa)");
                sUData = "" + new Crc32().S(sUData);
            }
            else
            {
                sUData = "xxxxxxxx";
            }

            string vRaw = new System.Net.WebClient().DownloadString(
                "http://tox.awardspace.us/div/pNMC_version.php?" +
                "id=" + sUData + "&" +
                "cv=" + Application.ProductVersion);
            vRaw = vRaw.Replace("\r", "");
            if (!vRaw.Contains("<VERSION>" + Application.ProductVersion + "</VERSION>"))
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "En ny versjon av pNMC er tilgjengelig. Oppdatere?",
                    "Oppdatere pNMC", MessageBoxButtons.YesNo))
                {
                    string Link = new System.Net.WebClient().DownloadString(
                        "http://www.praetox.com/inf/pNMC_link.html").Split('%')[1];
                    Link += "?id=" + sUData + "&cv=" + Application.ProductVersion;
                    System.Diagnostics.Process.Start(Link); AppExit();
                }
            }

            while (SplashForm.Enabled) { Application.DoEvents(); System.Threading.Thread.Sleep(10); }
            this.Show(); Application.DoEvents(); SplashForm.Dispose();

            string tmpPW = "";
            wb.Navigate("http://www.nordicmafia.net/"); w8();
            if (sUser != null) wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser);
            MessageBox.Show("Vennligst logg inn.");
            while (!wb.IsBusy)
            {
                System.Threading.Thread.Sleep(10); Application.DoEvents();
                sUser = wb.Document.GetElementById("brukernavn").GetAttribute("value");
                tmpPW = wb.Document.GetElementById("passoord").GetAttribute("value");
                this.Text = "pNMC (" + sUser + ")  |  v" + Application.ProductVersion + "  |  www.Praetox.com";
            }
            sPass = tmpPW; FileWrite("user.txt", sUser);
        }
        #endregion

        private void frmMain_Resize(object sender, EventArgs e)
        {
            wb.Size = new Size(this.Width - 133, this.Height - 105);
        }

        #region Conversions
        /// <summary>
        /// Returns character from ascii
        /// </summary>
        static string Chr(int id)
        {
            return Convert.ToChar(id).ToString();
        }
        /// <summary>
        /// Returns ascii from character
        /// </summary>
        static int Asc(char id)
        {
            return Convert.ToInt16(id);
        }
        /// <summary>
        /// Converts integer to byte
        /// </summary>
        public static byte[] Int2Byte(int Value)
        {
            byte[] rawbuf = BitConverter.GetBytes(Value);
            int a = 0; for (a = rawbuf.Length; a > 0; a--) if (rawbuf[a - 1] != 0) break;
            byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = rawbuf[a];
            return buf;
        }
        /// <summary>
        /// Converts byte to string
        /// </summary>
        public static String Byte2Str(byte[] Value)
        {
            int len = 0; for (len = Value.Length; len > 0; len--) if (Value[len - 1] != 0) break;
            string ret = ""; for (int a = 0; a < len; a++) ret += (char)Value[a];
            //byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = Value[a];
            return ret; //System.Text.Encoding.ASCII.GetString(buf);
        }
        /// <summary>
        /// Converts string to byte
        /// </summary>
        public static byte[] Str2Byte(string Value)
        {
            byte[] ret = new byte[Value.Length];
            for (int a = 0; a < Value.Length; a++) ret[a] = (byte)Value[a];
            return ret;
        }
        #endregion
        #region "Standard" functions
        ///<summary>
        /// Splits msg by delim, returns bit part
        ///</summary>
        public static string Split(string msg, string delim, int part)
        {
            if (msg == "" || msg == null || delim == "" || delim == null) return "";
            if (msg.IndexOf(delim) == -1) return msg;
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        ///<summary>
        /// Splits msg by delim, returns string array
        ///</summary>
        public static string[] aSplit(string msg, string delim)
        {
            if (msg == "" || msg == null || delim == "" || delim == null) return new string[0];
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        /// <summary>
        /// Alternative aSplit, should be faster
        /// </summary>
        public static string[] aSplit2(string msg, string delim)
        {
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    ret[spt] = msg.Substring(0, FoundPos); spt++;
                    msg = msg.Substring(FoundPos + delimLen);
                }
            }
            ret[spt] = msg; return ret;
        }
        ///<summary>
        /// Counts occurrences of delim within msg
        ///</summary>
        public static int Countword(string msg, string delim)
        {
            int ret = 0; if (msg == "" || msg == null || delim == "" || delim == null) return 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
            }
            return ret;
        }
        /// <summary>
        /// Alternative Countword, should be faster
        /// </summary>
        public static int Countword2(string msg, string delim)
        {
            int ret = 0; int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    msg = msg.Substring(FoundPos + delimLen); ret++;
                }
            }
            return ret;
        }
        /// <summary>
        /// Returns true if str only contains chars specified in vl
        /// </summary>
        public static bool OnlyContains(string str, string vl)
        {
            for (int a = 0; a < str.Length; a++)
                if (!vl.Contains("" + str[a])) return false;
            return true;
        }
        ///<summary>
        /// Converts a number (vl) into a digit-grouped string
        ///</summary>
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
        ///<summary>
        /// Creates a string containing vl number of spaces
        ///</summary>
        public static string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }
        ///<summary>
        /// Removes all spaces at start and end of vl
        ///</summary>
        public static string unSpace(string vl)
        {
            string ret = vl;
            try
            {
                while (ret.Substring(0, 1) == " ")
                {
                    ret = ret.Substring(1);
                }
                while (ret.Substring(ret.Length - 1) == " ")
                {
                    ret = ret.Substring(0, ret.Length - 1);
                }
                return ret;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Removes all newlines at start and end of vl
        /// </summary>
        public static string unNewline(string vl)
        {
            try
            {
                while ((vl.Substring(0, 1) == "\r") || (vl.Substring(0, 1) == "\n"))
                {
                    vl = vl.Substring(1);
                }
                while ((vl.Substring(vl.Length - 1) == "\r") || (vl.Substring(vl.Length - 1) == "\n"))
                {
                    vl = vl.Substring(0, vl.Length - 1);
                }
                return vl;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Returns system clock in seconds
        ///</summary>
        public static int sTick()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        ///<summary>
        /// Returns what sTick will be after vl seconds
        ///</summary>
        public static int T2A(int vl)
        {
            int ret = sTick() + vl + t2aDelay;
            if (ret > 86400) ret -= 86400;
            return ret;
        }
        ///<summary>
        /// Returns the waiting time until sTick is vl
        ///</summary>
        public static int T2B(int vl)
        {
            int ret = vl - sTick();
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
            return ret;
        }
        ///<summary>
        /// Returns how many seconds sTick has passed vl
        ///</summary>
        public static int T2C(int vl)
        {
            int ret = sTick() - vl;
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
            return ret;
        }
        ///<summary>
        /// Sleeps for vl seconds
        ///</summary>
        public static void iSlp(int vl)
        {
            long lol = Tick();
            while (Tick() < lol + vl)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
        }
        ///<summary>
        /// Returns system clock in miliseconds
        ///</summary>
        public static long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        ///<summary>
        /// Returns hh:mm:ss of vl (seconds)
        ///</summary>
        public static string s2ms(int vl)
        {
            int iHour = 0; int iMins = 0; int iSecs = vl;
            while (iSecs >= 60)
            {
                iSecs -= 60; iMins++;
            }
            while (iMins >= 60)
            {
                iMins -= 60; iHour++;
            }
            string sHour = Convert.ToString(iHour); sHour = Space(2 - sHour.Length).Replace(" ", "0") + sHour;
            string sMins = Convert.ToString(iMins); sMins = Space(2 - sMins.Length).Replace(" ", "0") + sMins;
            string sSecs = Convert.ToString(iSecs); sSecs = Space(2 - sSecs.Length).Replace(" ", "0") + sSecs;
            return sHour + ":" + sMins + ":" + sSecs;
        }
        /// <summary>
        /// This function returns false and makes regkey if not exist.
        /// </summary>
        static bool Reg_DoesExist(string regPath)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                key = key.OpenSubKey(regPath, true);
                long lol = key.SubKeyCount;
                return true;
            }
            catch
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                key.CreateSubKey(regPath);
                return false;
            }
        }
        ///<summary>
        /// Returns current date and time
        ///</summary>
        public static string TDNow()
        {
            return System.DateTime.Now.ToShortDateString() + " .::. " +
                   System.DateTime.Now.ToLongTimeString();
        }
        ///<summary>
        /// Returns MD5 of vl
        ///</summary>
        public static string MD5(string vl)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(vl);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
        #endregion
        #region Webbrowser related
        ///<summary>
        /// Displays / hides images in internet explorer
        ///</summary>
        public static void IE_Images(bool show)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            key = key.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main", true);
            if (show) key.SetValue("Display Inline Images", "yes");
            if (!show) key.SetValue("Display Inline Images", "no");
            key.Close();
        }
        ///<summary>
        /// Navigates to website url, optionally waits until vl appears in source
        ///</summary>
        public void Nav(string url, string vl)
        {
            wb.Stop(); Application.DoEvents();
            wb.Navigate(url); Application.DoEvents();
            if (vl == "") { w8(); } else { w8u(vl); }
            if (Login()) { Nav(url, vl); }
        }
        public void Nav(string url)
        {
            Nav(url, "");
        }
        ///<summary>
        /// Waits until web browser stops loading
        ///</summary>
        public void w8()
        {
            long t = Tick();
            Application.DoEvents();
            while (wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if (t + Timeout <= Tick()) break;
            }
        }
        ///<summary>
        /// Waits until web browser starts loading
        ///</summary>
        public void w8i(long iTimeout)
        {
            Application.DoEvents(); long t = sTick();
            while (!wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if ((iTimeout != 0) && (sTick() > t + iTimeout)) break;
            }
        }
        public void w8i()
        {
            w8i(0);
        }
        ///<summary>
        /// Waits until website contains vl
        ///</summary>
        public void w8u(string vl)
        {
            long t = Tick();
            Application.DoEvents();
            while (wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if (wb.DocumentText.Contains(vl)) break;
                if (t + Timeout <= Tick()) break;
            }
        }
        ///<summary>
        /// Returns source code of website
        ///</summary>
        public string wSRC()
        {
            try
            {
                return wb.Document.Body.Parent.InnerHtml;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Returns whether website contains vl or not
        ///</summary>
        public bool WPC(string vl)
        {
            return wSRC().Contains(vl);
        }
        #endregion
        #region File and array manipulation
        /// <summary>
        /// Reads sFile, works with norwegian letters ae oo aa
        /// </summary>
        public static string FileRead(string sFile)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(sFile, Encoding.GetEncoding("iso-8859-1"));
                string ret = sr.ReadToEnd();
                while ((ret.Substring(ret.Length - 1) == "\r") || (ret.Substring(ret.Length - 1) == "\n"))
                    ret = ret.Substring(0, ret.Length - 1);
                sr.Close(); sr.Dispose(); return ret;
            }
            catch { return ""; }
        }
        /// <summary>
        /// Writes sVal to sFile, works with norwegian letters ae oo aa
        /// </summary>
        /// <param name="sFile">Target file</param>
        /// <param name="sVal">The string to write</param>
        /// <param name="bAppend">Append instead of overwrite</param>
        public static void FileWrite(string sFile, string sVal, bool bAppend)
        {
            System.IO.FileMode AccessType = System.IO.FileMode.Create;
            if (bAppend) AccessType = System.IO.FileMode.Append;
            System.IO.FileStream fs = new System.IO.FileStream(sFile, AccessType);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"));
            sw.Write(sVal); sw.Close(); sw.Dispose();
        }
        public static void FileWrite(string sFile, string sVal)
        {
            FileWrite(sFile, sVal, false);
        }
        /// <summary>
        /// Sorts vl[] alphabetically, ignores letters other than 0-9 a-z
        /// </summary>
        public static string[] SortStringArrayAlphabetically(string[] vl)
        {
            for (int a = vl.GetUpperBound(0); a >= 0; a--)
            {
                for (int b = 0; b < a; b++) //changed "b <= a" to "b < a"
                {
                    if (string.Compare(vl[b], vl[b + 1], true) > 0)
                    {
                        //Swap values
                        string tmp = vl[b].ToString();
                        vl[b] = vl[b + 1];
                        vl[b + 1] = tmp;
                    }
                }
            }
            return vl;
        }
        #endregion

        private void AppExit()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public void GCD_Wait()
        {
            while (T2B(ttGlobal) != 0) { System.Threading.Thread.Sleep(1); Application.DoEvents(); }
        }
        public bool Login()
        {
            bool ret = false;
            if (WPC("Du er ikke logget inn!") || WPC("Du ble logget inn fra et annet sted.") ||
                WPC("Du er ikke logged ind!"))
            {
                wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser);
                wb.Document.GetElementById("passoord").SetAttribute("value", sPass);
                wb.Document.GetElementById("Submit").InvokeMember("click"); w8();
                ttGlobal = T2A(ooGlobal); GCD_Wait();
                ret = true;
            }
            return ret;
        }

        #region PM inbox cleaner
        private void PM_Spam_Config_Click(object sender, EventArgs e)
        {
            new frmPmAntispam().Show();
            this.Text = sUser + " | " + sPass;
        }

        private void PM_Spam_Remove_Click(object sender, EventArgs e)
        {
            if (PM_Spam_sNicks == "" && PM_Spam_sTopics == "")
            {
                MessageBox.Show("Vennligst konfigurer Antispam-funksjonen først."); return;
            }

            PM_Spam_sNicks = PM_Spam_sNicks.Replace("\r", "");
            if (!PM_Spam_sNicks.StartsWith("\n")) PM_Spam_sNicks = "\n" + PM_Spam_sNicks;
            if (!PM_Spam_sNicks.EndsWith("\n")) PM_Spam_sNicks = PM_Spam_sNicks + "\n";

            PM_Spam_sTopics = PM_Spam_sTopics.Replace("\r", "");
            if (!PM_Spam_sTopics.StartsWith("\n")) PM_Spam_sTopics = "\n" + PM_Spam_sTopics;
            if (!PM_Spam_sTopics.EndsWith("\n")) PM_Spam_sTopics = PM_Spam_sTopics + "\n";

            while (true)
            {
                bool DelMsgs = false;
                if (!wSRC().Contains("#00cc00>Meldingene har blitt slettet!</FONT>"))
                {
                    Nav(sGamedomain + "nordic/index.php?side=pm_inn");
                }
                string src = wSRC();
                src = Split(Split(src, "title=\"Merk Alle\"", 1), "> = Lest pm<BR>", 0);
                string[] aSrc = aSplit(src, "width=28");
                for (int a = 1; a <= aSrc.GetUpperBound(0); a++)
                {
                    string sID = Split(Split(aSrc[a], "?side=pm_les&amp;id=", 1), "\">", 0);
                    string sNick = Split(Split(Split(aSrc[a], "?side=bruker&amp;b", 1), "\">", 1), "</A>", 0);
                    string sTopic = Split(Split(aSrc[a], sID + "\">", 2), "</A>", 0);
                    string sDate = Split(Split(aSrc[a], " || ", 1), "</FONT>", 0);
                    if (PM_Spam_sNicks.Contains("\n" + sNick + "\n") ||
                        PM_Spam_sTopics.Contains("\n" + sTopic + "\n"))
                    {
                        DelMsgs = true;
                        wb.Document.All.GetElementsByName("deleted_items[]")[a-1].SetAttribute("checked", "CHECKED");
                    }
                }
                if (DelMsgs)
                {
                    wb.Document.GetElementById("sub_delmerk").InvokeMember("click"); w8();
                    Clipboard.Clear(); Clipboard.SetText(wSRC());
                }
                else break;
            }
            MessageBox.Show("Fullført.");
        }
        #endregion
        #region NM links
        private void NmfNav(string subsite)
        {
            if (sUser == "" || sPass == "") { new frmWtf().Show(); return; }
            wb.Stop(); Application.DoEvents();
            Nav(sGamedomain + "nordic/index.php?side=" + subsite);
        }

        private void lnkKrim_Click(object sender, EventArgs e)
        {
            NmfNav("krim");
        }

        private void lnkPress_Click(object sender, EventArgs e)
        {
            NmfNav("utpressing");
        }

        private void lnkGTA_Click(object sender, EventArgs e)
        {
            NmfNav("gta");
        }

        private void lnkFC_Click(object sender, EventArgs e)
        {
            NmfNav("fightclub");
        }

        private void lnkBank_Click(object sender, EventArgs e)
        {
            NmfNav("bank");
        }

        private void lnkBors_Click(object sender, EventArgs e)
        {
            NmfNav("borsen");
        }

        private void lnkDrep_Click(object sender, EventArgs e)
        {
            NmfNav("drep");
        }

        private void lnkFengsel_Click(object sender, EventArgs e)
        {
            NmfNav("fengsel");
        }

        private void lnkFilm_Click(object sender, EventArgs e)
        {
            NmfNav("filmprod");
        }

        private void lnkFly_Click(object sender, EventArgs e)
        {
            NmfNav("flyplass");
        }

        private void lnkHasj_Click(object sender, EventArgs e)
        {
            NmfNav("plantasje");
        }

        private void lnkHitlist_Click(object sender, EventArgs e)
        {
            NmfNav("hitlist");
        }

        private void lnkLivvakt_Click(object sender, EventArgs e)
        {
            NmfNav("livvakt");
        }

        private void lnkOC_Click(object sender, EventArgs e)
        {
            NmfNav("oc");
        }

        private void lnkOverfor_Click(object sender, EventArgs e)
        {
            NmfNav("poverfor");
        }

        private void lnkKjopKuler_Click(object sender, EventArgs e)
        {
            NmfNav("kuler");
        }

        private void lnkKjopGTA_Click(object sender, EventArgs e)
        {
            NmfNav("bruktbilo");
        }

        private void lnkSelgGTA_Click(object sender, EventArgs e)
        {
            NmfNav("bruktbilo&akt=selg");
        }

        private void lnkUnderground_Click(object sender, EventArgs e)
        {
            NmfNav("underground");
        }

        private void lnkRankbar_Click(object sender, EventArgs e)
        {
            NmfNav("rankbar");
        }

        private void lnkGjeng_Click(object sender, EventArgs e)
        {
            NmfNav("gjengcp");
        }

        private void lnkFinn_Click(object sender, EventArgs e)
        {
            NmfNav("finn");
        }

        private void lnkPmLes_Click(object sender, EventArgs e)
        {
            NmfNav("pm_inn");
        }

        private void lnkPmNy_Click(object sender, EventArgs e)
        {
            NmfNav("pm_ny");
        }

        private void lnkForumGen_Click(object sender, EventArgs e)
        {
            NmfNav("genforum");
        }

        private void lnkForumGenNy_Click(object sender, EventArgs e)
        {
            NmfNav("genforum&valg=ny");
        }

        private void lnkForumSok_Click(object sender, EventArgs e)
        {
            NmfNav("sokforum");
        }

        private void lnkForumSokNy_Click(object sender, EventArgs e)
        {
            NmfNav("sokforum&valg=ny");
        }

        private void lnkForumOt_Click(object sender, EventArgs e)
        {
            NmfNav("otforum");
        }

        private void lnkForumOtNy_Click(object sender, EventArgs e)
        {
            NmfNav("otforum&valg=ny");
        }

        private void lnkForumGjeng_Click(object sender, EventArgs e)
        {
            NmfNav("gjengforum");
        }

        private void lnkForumGjengNy_Click(object sender, EventArgs e)
        {
            NmfNav("gjengforum&valg=ny");
        }
        #endregion
        #region Timers
        private void pBanner_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.praetox.com/");
        }

        private void ltKrim_Click(object sender, EventArgs e)
        {
            itKrim = T2A(180 - 1);
        }

        private void ltPress_Click(object sender, EventArgs e)
        {
            itPress = T2A(960 - 1);
        }

        private void ltGTA_Click(object sender, EventArgs e)
        {
            itGTA = T2A(360 - 1);
        }

        private void ltFC_Click(object sender, EventArgs e)
        {
            itFC = T2A(120 - 1);
        }

        private void tTimere_Tick(object sender, EventArgs e)
        {
            ltKrim.Text = s2ms(T2B(itKrim)).Substring(3);
            if (T2B(itKrim) > 0) ltKrim.ForeColor = Color.CadetBlue; else ltKrim.ForeColor = Color.LightBlue;
            ltPress.Text = s2ms(T2B(itPress)).Substring(3);
            if (T2B(itPress) > 0) ltPress.ForeColor = Color.CadetBlue; else ltPress.ForeColor = Color.LightBlue;
            ltGTA.Text = s2ms(T2B(itGTA)).Substring(3);
            if (T2B(itGTA) > 0) ltGTA.ForeColor = Color.CadetBlue; else ltGTA.ForeColor = Color.LightBlue;
            ltFC.Text = s2ms(T2B(itFC)).Substring(3);
            if (T2B(itFC) > 0) ltFC.ForeColor = Color.CadetBlue; else ltFC.ForeColor = Color.LightBlue;
        }
        #endregion
    }
}
