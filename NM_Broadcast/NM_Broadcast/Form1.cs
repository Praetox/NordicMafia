using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NM_Broadcast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string sUser, sPass;
        public static int t2aDelay = 1, Timeout = 10000;
        public static WebBrowser wb = new WebBrowser();
        public static string[] aNmMods = { "Branco", "Eliisa", "Luscious Insanity", "Twinky",
                                           "EvigEngel", "Khaza", "Lucas Scott", "Magdalena" };

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
        public static void Nav(string url, string vl)
        {
            wb.Stop(); Application.DoEvents();
            wb.Navigate(url); Application.DoEvents();
            if (vl == "") { w8(); } else { w8u(vl); }
            if (Login()) { Nav(url, vl); }
        }
        public static void Nav(string url)
        {
            Nav(url, "");
        }
        ///<summary>
        /// Waits until web browser stops loading
        ///</summary>
        public static void w8()
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
        public static void w8i(long iTimeout)
        {
            Application.DoEvents(); long t = sTick();
            while (!wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if ((iTimeout != 0) && (sTick() > t + iTimeout)) break;
            }
        }
        public static void w8i()
        {
            w8i(0);
        }
        ///<summary>
        /// Waits until website contains vl
        ///</summary>
        public static void w8u(string vl)
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
        public static string wSRC()
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
        public static bool WPC(string vl)
        {
            return wSRC().Contains(vl);
        }
        #endregion
        #region Nordicmafia specific webbrowser functions
        ///<summary>
        /// Checks if you are logged in, logs in and returns true if necessary
        ///</summary>
        public static bool Login()
        {
            bool ret = false;
            if (WPC("Du er ikke logget inn!") || WPC("Du ble logget inn fra et annet sted.") ||
                WPC("Du er ikke logged ind!"))
            {
                wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser);
                wb.Document.GetElementById("passoord").SetAttribute("value", sPass);
                wb.Document.GetElementById("submit").InvokeMember("click"); w8();
                System.Threading.Thread.Sleep(3500);
                ret = true;
            }
            return ret;
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

        public void lg(string vl)
        {
            this.Text = vl; Application.DoEvents();
        }

        /// <summary>
        /// Returns a list of all online players
        /// </summary>
        public string GetOnline()
        {
            long CurUser = 0; string ret = "";
            while (true)
            {
                Nav("http://www.nordicmafia.net/nordic/index.php?side=online&start=" + CurUser);
                long vl2 = Convert.ToInt32(Split(Split(wSRC(), "Viser <B>", 1), " spillere", 0));
                string CharsTmp = Split(Split(wSRC(), " spillere</B></P></DIV><BR>", 1), "<TABLE ", 0);
                string[] Chars = aSplit(CharsTmp, "\">"); long CharsUBound = Chars.GetUpperBound(0); //Countword(CharsTmp, "\">");
                for (int a = 1; a <= CharsUBound; a++)
                {
                    lg("Caching " + a + " / " + CharsUBound + "...");
                    ret += Split(Chars[a], "</A>", 0) + "\r\n";
                }
                CurUser += 600; if (CharsUBound < 600) break;
            }
            if (ret.Length >= 2)
                if (ret.Substring(ret.Length - 2) == "\r\n") ret = ret.Substring(0, ret.Length - 2);
            //return "Diclonius";
            return ret;
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int iCurr = 0, iDoneCnt = 0, iWait = T2A(0);
            sUser = tUser.Text; sPass = tPass.Text;
            string nmCharlist = GetOnline().Replace("\r", "");
            string sDoneLst = ",";
            foreach (string modNick in aNmMods)
            {
                nmCharlist = nmCharlist.Replace(modNick + "\n", "");
            }
            string[] nmChars = nmCharlist.Split('\n');
            string sTopic = HtmlStr(txTopic.Text), sMsg = HtmlStr(txMsg.Text);
            while (iDoneCnt < nmChars.GetUpperBound(0)-1)
            {
                while (sDoneLst.Contains("," + iCurr + ","))
                {
                    iCurr = rnd.Next(0, nmChars.GetUpperBound(0));
                }
                sDoneLst += iCurr + ","; iDoneCnt++;
                while (T2B(iWait) != 0)
                {
                    lg(iDoneCnt + "/" + nmChars.GetUpperBound(0) + " in " + T2B(iWait) + "sec (" + nmChars[iCurr] + ")...");
                    System.Threading.Thread.Sleep(250);
                }
                while (true)
                {
                    wb.DocumentText =
                        "<form name='form1' method='post' action='http://www.nordicmafia.net/nordic/index.php?side=pm_ny2'>" +
                        "<input type='text' name='til'><input type='text' name='tittel'>" +
                        "<textarea name='melding' wrap='VIRTUAL' cols='50' rows='7'></textarea>" +
                        "<input type='submit' name='Submit5222' value='Send'></form>"; w8();
                    wb.Document.GetElementById("til").SetAttribute("value", nmChars[iCurr]);
                    wb.Document.GetElementById("tittel").SetAttribute("value", sTopic);
                    wb.Document.GetElementById("melding").SetAttribute("value", sMsg);
                    wb.Document.GetElementById("Submit5222").InvokeMember("click"); w8();
                    if (Login())
                    {
                        System.Threading.Thread.Sleep(3500);
                    }
                    else
                    {
                        break;
                    }
                }
                iWait = T2A(20);
            }
            lg("All done!");
        }

        public static string HtmlStr(string vl)
        {
            return vl.Replace("æ", "&aelig;").Replace("ø", "&oslash;").Replace("å", "&aring;").
                      Replace("Æ", "&Aelig;").Replace("Ø", "&Oslash;").Replace("Å", "&Aring;");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IE_Images(false); Application.DoEvents();
            this.Show(); Application.DoEvents();
            wb.Navigate("about:blank"); Application.DoEvents();
            IE_Images(true); Application.DoEvents();
            wb.Navigate("about:<form method=\"post\" action=\"http://www.nordicmafia.net/nordic/index.php?side=loggut\"><input type=\"submit\" value=\"Logg ut!\" name=\"subloggut\"><input type=\"hidden\" name=\"luz\">");
            w8(); wb.Document.GetElementById("subloggut").InvokeMember("click"); w8();
        }
    }
}