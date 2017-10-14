using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;

/* Full source for Ledetekst-Mafia
 * Enjoy your useless and shitty code.
 * Also, www.praetox.com for moar
 *
 * Released to the public domain
 * ~~ 2009/04/05 15:30 GMT+01 ~~
 */

namespace LM
{
    class Program
    {
        #region Public variables
        public static double ssdRank = 0;
        public static bool bSilent = false, bAbCompleted = false, bAbEnded = false, bAutoLoc = false, bPM = false;
        public static int ttKrim = 0, ttPress = 0, ttGta = 0, ttFCt = 0, ttJail = 0, ttGlobal = 0,
                          ooKrim = 1, ooPress = 1, ooGta = 1, ooFCt = 1, ooJail = 0, ooBryt = 0,
                          st_cKrim = 0, st_cPress = 0, st_cGta = 0, st_cBryt = 0, st_cFCt = 0,
                          st_fKrim = 0, st_fPress = 0, st_fGta = 0, st_fBryt = 0, ooGlobal = 5,
                          Timeout = 10000, sckTimeout = 15000, iRedraw = 100, t2aDelay = 1, Reports = 0;
        public static string sUser = "", sPass = "", vBryt = "", st_vBryt = "",
                             sPath = Application.StartupPath + "\\",
                             sAntibot = "", sAbSession = "", sAbPrefix = "",
                             sStatus = "Starter", sONick = "Praetox Technologies",
                             ssRank = "Start bot", ssCash = "Start more bots", ssBy = "????", ssLiv = "PROFIT!",
                             sGamedomain = "http://www.nordicmafia.net/",
                             sBotdomain = "http://tox.awardspace.us/LM/",
                             sToxdomain = "http://praetox.com/",
                             myProcName = "", myIP = "", trgIP = "", trgCRC = "",
                             ssBoot = System.DateTime.Now.ToShortDateString() + " - " +
                                      System.DateTime.Now.ToShortTimeString();
        public static string[] aRankName = { "Sivilist", "Wannabe", "Bråkmaker", "Gangster", "Hitman", "Assassin",
                                             "Kaptein", "Boss", "Gudfar", "Legendarisk Gudfar", "Don", "Capo Don" };
        public static WebHeaderCollection SESSID = new WebHeaderCollection();
        public static string[] DeskMsg = new string[8];
        public static WebBrowser wb = new WebBrowser();
        public static IntPtr myHwnd = (IntPtr)0;
        public static int iStockCount = 0;
        #endregion
        
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
        /// <summary>
        /// Splits msg by delim, returns bit part
        /// </summary>
        public static string sSplit(string msg, string delim, int part, bool doCut)
        {
            if (doCut) return Split(msg, delim, part);
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
        ///<summary>
        /// Splits msg by delim, returns bit part (chops after next instance)
        ///</summary>
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
        ///<summary>
        /// Splits msg by delim, returns string array
        ///</summary>
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
                while ((vl.StartsWith("\r") || vl.StartsWith("\n")))
                {
                    vl = vl.Substring(1);
                }
                while ((vl.EndsWith("\r") || vl.EndsWith("\n")))
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
            GetStats(wSRC(), false);
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
        #region Socketbrowser related
        /// <summary>
        /// Sends an HTTP request to specified URL.
        /// </summary>
        /// <param name="sURL">[Obligatory] Target URL</param>
        /// <param name="cHeaders">[Optional] Additional headers</param>
        /// <param name="sPostdata">[Optional] String to POST</param>
        /// <returns>HTTP response (headers and returned string)</returns>
        public static HttpData ExecReq(String sURL, WebHeaderCollection cHeaders, bool bSessid, string sPostdata)
        {
            WebHeaderCollection rHeaders = cHeaders;
            if (rHeaders == null) rHeaders = new WebHeaderCollection();
            if (bSessid)
                for (int a = 0; a < SESSID.Count; a++)
                    rHeaders.Add(SESSID.GetKey(a) + ": " + SESSID.Get(a));

            WebReq sck = new WebReq(); sck.SetTimeout(sckTimeout);
            sck.Request(sURL, rHeaders, sPostdata, "", true);
            while (!sck.isReady)
            {
                Application.DoEvents(); System.Threading.Thread.Sleep(1);
            }
            HttpData ret = new HttpData();
            ret.Headers = sck.Headers;
            ret.Html = sck.Response;
            //Clipboard.Clear(); Clipboard.SetText(sck.SentPacket);
            GetStats(sck.Response, false);
            sck = null; return ret;
        }
        /// <summary>
        /// Posts data to specified URL (automatic relog optional)
        /// </summary>
        public static string sNav(string URL, string Postdata, WebHeaderCollection cHeaders, bool bSessid, bool Relog)
        {
            if (Postdata != "") ttGlobal = T2A(ooGlobal);
            string ret = ExecReq(URL, cHeaders, bSessid, Postdata).Html;
            if (Relog) { if (Login(ret)) return sNav(URL, Postdata, cHeaders, bSessid, Relog); } return ret;
        }
        /// <summary>
        /// Gets data from specified URL (automatic relog optional)
        /// </summary>
        public static string sNav(string URL, bool Relog)
        {
            return sNav(URL, "", new WebHeaderCollection(), true, Relog);
        }
        /// <summary>
        /// Posts data to specified URL (automatic relog + resend data)
        /// </summary>
        public static string sNav(string url, string Postdata)
        {
            WebHeaderCollection whc = new WebHeaderCollection();
            whc.Add("Referer: " + url);
            return sNav(url, Postdata, whc, true, true);
        }
        /// <summary>
        /// Gets data from specified URL (automatic relog + reget data)
        /// </summary>
        public static string sNav(string url)
        {
            return sNav(url, "", new WebHeaderCollection(), true, true);
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
        #region Nordicmafia specific webbrowser functions
        ///<summary>
        /// Checks if you are logged in, logs in and returns true if necessary
        ///</summary>
        public static bool Login()
        {
            try
            {
                bool ret = false;
                if (WPC("Du er ikke logget inn!") || WPC("Du ble logget inn fra et annet sted.") ||
                    WPC("Du er ikke logged ind!"))
                {
                    doLogin();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                CritErrlog(ex); return false;
            }
        }
        public static bool Login(string pSrc)
        {
            try
            {
                bool ret = false;
                if (pSrc.Contains("Du er ikke logget inn!") || pSrc.Contains("Du ble logget inn fra et annet sted.") ||
                    pSrc.Contains("Du er ikke logged ind!"))
                {
                    doLogin();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                CritErrlog(ex); return false;
            }
        }
        public static void doLogin()
        {
            try
            {
                lg("Logger inn...");
                wb.Stop(); Application.DoEvents();
                wb.Navigate(sGamedomain); w8();
                wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser);
                wb.Document.GetElementById("passoord").SetAttribute("value", sPass);
                wb.Document.GetElementById("Submit").InvokeMember("click"); w8();
                string Reason = "Ukjent grunn (overbelastet server?)";
                string Subreason = "";
                if (WPC("<B>Feil brukernavn/passord!</B>"))
                {
                    Reason = "~Feil bruker/pass~";
                }
                if (WPC("<B>Du har blitt drept!</B>"))
                {
                    Reason = "~Drept av spiller~";
                }
                if (WPC("<B>Du ble drept av en moderator "))
                {
                    Reason = "Drept av moderator";
                    Subreason =
                        "\r\n[" + Split(Split(wSRC(), "en moderator ", 1),
                        ", dette", 0).Replace(" || ", "] [") + "] [" +
                        Split(Split(wSRC(), "grunnen til modkill:<BR>", 1),
                        "</B></B>", 0).Trim() + "]";
                }
                if (!WPC("><B>Hjelp med å spille? <") && !WPC("><B>Hjælp med at spille? <"))
                {
                    Errlog("Login - " + Reason + " - " + sUser + Subreason);
                    FileWrite("errors_login.txt",
                        System.DateTime.Now.ToShortDateString() + " - " +
                        System.DateTime.Now.ToLongTimeString() + " - " +
                        Reason + " - " + sUser + Subreason + "\r\n", true);
                    //FileWrite("error_login.html", wSRC());
                    pKillMe();
                }
                ttGlobal = T2A(ooGlobal); GCD_Wait();
                SESSID = null; SESSID = new WebHeaderCollection();
                SESSID.Add("Cookie: " + wb.Document.Cookie.ToString());
                //FileWrite("var/" + MD5(sONick) + ".cok",
                //          sONick + "\r\n" + wb.Document.Cookie.ToString());
                lg("Logget inn.");
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        public static void GetStats(string pSrc, bool Fullcheck)
        {
            try
            {
                if (pSrc.Contains("<b>Utboks/sendte meld.</b></a>"))
                {
                    sONick = Split(Split(Split(pSrc,
                        "<span class=\"menuyellowtext\"><a href=\"index.php?side=bruker&", 1), "\">", 1), "</a>", 0);
                    ssRank = Split(Split(pSrc, "Rank: <span class=\"menuyellowtext\">", 1), "</span>", 0);
                    ssCash = Split(Split(pSrc, "Penger: <span class=\"menuyellowtext\">", 1), " kr", 0);
                    ssBy = Split(Split(pSrc, "Bosted: <span class=\"menuyellowtext\">", 1), "</span>", 0);
                    ssLiv = Split(Split(pSrc, "\t\t\tLiv: ", 1), "<br>", 0);
                    if (pSrc.Contains("<img border=\"0\" src=\"iconer/flashpm.gif\" alt=\"\">")) bPM = true; else bPM = false;
                    if (pSrc.Contains("<font color=red><b>Du må vente 3 sekunder mellom")) Errlog("3sec - " + sStatus);
                }
                if (pSrc.Contains("<b>Udboks/sendte meld.</b></a>"))
                {
                    sONick = Split(Split(Split(pSrc,
                        "<span class=\"menuyellowtext\"><a href=\"index.php?side=bruker&", 1), "\">", 1), "</a>", 0);
                    ssRank = Split(Split(pSrc, "Rank: <span class=\"menuyellowtext\">", 1), "</span>", 0);
                    ssCash = Split(Split(pSrc, "Penge: <span class=\"menuyellowtext\">", 1), " kr", 0);
                    ssBy = Split(Split(pSrc, "Land: <span class=\"menuyellowtext\">", 1), "</span>", 0);
                    ssLiv = Split(Split(pSrc, "\t\t\tLiv: ", 1), "<br>", 0);
                    if (pSrc.Contains("<img border=\"0\" src=\"iconer/flashpm.gif\" alt=\"\">")) bPM = true; else bPM = false;
                    if (pSrc.Contains("<font color=red><b>Du må vente 3 sekunder mellom")) Errlog("3sec - " + sStatus);
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        public static void GCD_Wait()
        {
            while (T2B(ttGlobal) != 0) System.Threading.Thread.Sleep(1);
        }
        #endregion
        #region Console functions
        /// <summary>
        /// Creates a console-friendly string
        /// </summary>
        /// <param name="vl">The message to display</param>
        /// <param name="len">The space that should be filled</param>
        /// <param name="Align">How to align text (1=left 2=right 3=center)</param>
        static string GenLine(string vl, int len, int Align)
        {
            if (len == -1) len = vl.Length;
            if (vl.Length > len) vl = vl.Substring(0, len - 3) + "...";
            int ES = len - vl.Length;
            if (Align == 1) return vl + Space(ES);
            if (Align == 2) return Space(ES) + vl;
            if (Align == 3)
            {
                int ES1 = ES / 2; int ES2 = ES / 2;
                if ((ES / 2) * 2 != ES) ES2 += 1;
                return Space(ES1) + vl + Space(ES2);
            }
            return vl;
        }
        static string GenLine(int vl, int len, int Align)
        {
            return GenLine(vl.ToString(), len, Align);
        }

        /// <summary>
        /// Prints a line to console, converting symbol indicators to proper ansi in the process
        /// </summary>
        /// <param name="vl">The message to print to console</param>
        /// <param name="endl">Returns carriage if true</param>
        static void csPrint(string vl, bool endl)
        {
            Console.Write(vl.
                Replace("{", Convert.ToString((char)9616)).
                Replace("}", Convert.ToString((char)9619)).
                Replace("£", Convert.ToString((char)9600)).
                Replace("€", Convert.ToString((char)9604)));
            if (endl) if (Console.CursorLeft!=0 || vl == "")
                Console.Write(Space(80 - Console.CursorLeft));
        }
        static void csPrint(string vl)
        {
            csPrint(vl, true);
        }

        /// <summary>
        /// Sets cursor location to X, Y and writes vl to screen. Does not \n.
        /// </summary>
        static void csPrintAt(int x, int y, string vl)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(vl);
        }

        /// <summary>
        /// Removes all cached keys from input stream
        /// </summary>
        static void csWipeInstr()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Asks a yes/no question, returns true if user answers "Y"
        /// </summary>
        /// <param name="vl">The question to ask</param>
        /// <returns>User's answer as a bool</returns>
        static bool csBool(string vl)
        {
            csWipeInstr();
            csPrint(vl + " (Y/N)? ", false);
            ConsoleKeyInfo cRet = Console.ReadKey();
            if (cRet.Key == ConsoleKey.Y) return true;
            return false;
        }

        /// <summary>
        /// Returns a single keypress
        /// </summary>
        static char csKey()
        {
            csWipeInstr();
            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Asks a question, returns single char entered
        /// </summary>
        /// <param name="vl">The question to ask</param>
        /// <returns>User's answer as a char</returns>
        static char csChar(string vl)
        {
            csWipeInstr();
            csPrint(vl + "> ", false);
            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Asks a full-answer question, returns user response
        /// </summary>
        /// <param name="vl">The question to ask</param>
        /// <returns>User's answer as a string</returns>
        static string csString(string vl)
        {
            csWipeInstr();
            csPrint(vl + "> ", false);
            string ret = Console.ReadLine();
            return ret;
        }

        /// <summary>
        /// Redraws the console window
        /// </summary>
        static void csDraw()
        {
            string sStatMsg = "";
            if (bPM) sStatMsg += "PM ";
            csDraw(new string[] {
                "      Status:  " + GenLine(sStatus, 54, 1),
                null,
                "Kriminalitet:  " + GenLine(T2B(ttKrim), 3, 2)  + " sek" + Space(13) + "Rank:  " + GenLine(ssRank, 27, 1),
                "  Utpressing:  " + GenLine(T2B(ttPress), 3, 2) + " sek" + Space(13) + "Cash:  " + GenLine(ssCash, 27, 1),
                "   Biltyveri:  " + GenLine(T2B(ttGta), 3, 2)   + " sek" + Space(13) + "  By:  " + GenLine(ssBy, 27, 1),
                "   Fightclub:  " + GenLine(T2B(ttFCt), 3, 2)   + " sek" + Space(13) + " Liv:  " + GenLine(ssLiv, 27, 1),
                "     Fengsel:  " + GenLine(T2B(ttJail), 3, 2)  + " sek" + Space(13) + "Stat:  " + GenLine(sStatMsg, 27, 1),
                null,
                GenLine(DeskMsg[0], 69, 3),
                GenLine(DeskMsg[1], 69, 3),
                GenLine(DeskMsg[2], 69, 3),
                GenLine(DeskMsg[3], 69, 3),
                GenLine(DeskMsg[4], 69, 3),
                GenLine(DeskMsg[5], 69, 3),
                GenLine(DeskMsg[6], 69, 3),
                GenLine(DeskMsg[7], 69, 3) } );
            string DispInf = sONick; if (bPM) DispInf = "PM | " + DispInf;
            Console.Title = "LM | " + DispInf + " | " + sTick();
        }
        static void csDraw(string[] DisplayStrings)
        {
            double pcRAMd = 0;
            pcRAMd = Process.GetCurrentProcess().WorkingSet64 / 1024;
            string pcRAM = Decimize(Convert.ToString(Math.Round(pcRAMd, 0)));
            Console.SetCursorPosition(0, 0);
            string[] vl = new string[16];
            for (int a = 0; a < 16; a++)
            {
                if (a <= DisplayStrings.GetUpperBound(0))
                    if (DisplayStrings[a] != null)
                        vl[a] = DisplayStrings[a];
                if (vl[a] == null) vl[a] = "";
                if (vl[a].StartsWith("$1")) vl[a] = GenLine(vl[a].Substring(2), 69, 1);
                if (vl[a].StartsWith("$2")) vl[a] = GenLine(vl[a].Substring(2), 69, 2);
                if (vl[a].StartsWith("$3")) vl[a] = GenLine(vl[a].Substring(2), 69, 3);
            }
            //rint("    '    *    '    *    '    *    '    !    '    *    '    *    '    *    '    ");
            csPrint(GenLine("     Startet " + ssBoot, 40, 1) + 
                    GenLine(System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString() + "      ", 40, 2));
            csPrint("  {£££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££££{   ");
            csPrint("  {  Ledetekst-mafia " + GenLine(sONick, 37, 3) + " www.praetox.com  {}  ");
            csPrint("  {-------------------------------------------------------------------------{}  ");
            csPrint("  {  " + GenLine("RAM: " + pcRAM, 69, 2) + "  {}  ");
            csPrint("  {  " + GenLine(vl[00], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[01], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[02], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[03], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[04], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[05], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[06], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[07], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[08], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[09], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[10], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[11], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[12], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[13], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[14], 69, 1) + "  {}  ");
            csPrint("  {  " + GenLine(vl[15], 69, 1) + "  {}  ");
            csPrint("  {                                                                         {}  ");
            csPrint("  {€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€{}  ");
            csPrint("   }}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}  ");
            csPrint("                                                                               ", false);
        }

        /// <summary>
        /// Changes the application status and redraws the window
        /// </summary>
        /// <param name="vl">The new application status</param>
        static void lg(string vl)
        {
            if (sStatus == vl) return;
            iRedraw = 0; sStatus = vl; csDraw();
        }
        #endregion

        #region Nordicmafia Control
        public static void NordicmafiaControl()
        {
            csDraw(new string[] {
                    "   LM >> Hovedmeny",
                    "",
                    "0. Kalkulatorer        1. Rydd opp            2. PM til Praetox      ",
                    "3. Selvmord            4. Vis NM                                     ",
                    "a. Banken              b. - Børsen            c. - Drep              ",
                    "d. - Eiendom           e. Filmproduksjon      f. Flyplass            ",
                    "g. Garasje             h. - Hasjplantasje     i. Kommunikasjon       ",
                    "j. Livvaktutleie       k. - Poenghandel       l. - Rankbar           ",
                    "m. - Russisk Rulett    n. - Sykehus           o. - Underground       " });
            Console.SetCursorPosition(8, 20);
            char MenuL1 = csChar("Handling");


            if (MenuL1 == '0')
            {
                csDraw(new string[] {
                        "   LM >> Kalkulatorer", "",
                        "a. Banken" });
                Console.SetCursorPosition(8, 20);
                char MenuL2 = csChar("Handling");


                if (MenuL2 == 'a')
                {
                    csDraw(new string[] {
                        "   LM >> Kalkulatorer >> Banken", "",
                        "a. Hvor mye må jeg sende?",
                        "b. Hvor mye får mottaker?",
                        "c. Hva tjener jeg i renter?" });
                    Console.SetCursorPosition(8, 20);
                    char MenuL3 = csChar("Handling");
                    if (MenuL3 == 'a')
                    {
                        while (true)
                        {
                            guiCalculateBankSend();
                            Console.SetCursorPosition(8, 20);
                            if (!csBool("Igjen")) break;
                        }
                    }
                    if (MenuL3 == 'b')
                    {
                        while (true)
                        {
                            guiCalculateBankReceive();
                            Console.SetCursorPosition(8, 20);
                            if (!csBool("Igjen")) break;
                        }
                    }
                    if (MenuL3 == 'c')
                    {
                        while (true)
                        {
                            guiCalculateBankInterest();
                            Console.SetCursorPosition(8, 20);
                            if (!csBool("Igjen")) break;
                        }
                    }
                }
            }

            if (MenuL1 == '1')
            {
                guiCleanup();
            }

            if (MenuL1 == '2')
            {
                guiPraetoxPM();
            }

            if (MenuL1 == '3')
            {
                guiSuicide();
            }

            if (MenuL1 == '4')
            {
                csDraw(new string[] {"   LM >> Vis NM", "", "$3Viser NM.", "",
                                     "$3Pga. C# faggot-tree så kan ikke boten kjøre mens NM er synlig.",
                                     "$3Lukk nettleseren for å fortsette bottingen."});
                Form fBrowse = new frmBrowser();
                fBrowse.Text = "LMWB | " + sONick;
                fBrowse.Show();
                while (fBrowse.Visible)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }
            }

            if (MenuL1 == 'a')
            {
                csDraw(new string[] {
                        "   LM >> Banken", "",
                        "a. Overførings-logg",
                        "b. Sett inn penger",
                        "c. Ta ut penger",
                        "d. Send penger", });
                Console.SetCursorPosition(8, 20);
                guiBank(csChar("Handling"));
            }

            if (MenuL1 == 'e')
            {
                guiMovie();
            }
            if (MenuL1 == 'f')
            {
                guiAirport();
            }
            if (MenuL1 == 'g')
            {
                csDraw(new string[] {
                    "   LM >> Garasje",
                    "",
                    "a. Tell biler",
                    "b. NPC - selg",
                    "c. Marked - kjøp",
                    "d. Marked - selg" });
                Console.SetCursorPosition(8, 20);
                char MenuL2 = csChar("Handling");
                if (MenuL2 == 'a') guiCarCounter();
                if (MenuL2 == 'b') guiCarSeller();
            }
            if (MenuL1 == 'i')
            {
                csDraw(new string[] {
                        "   LM >> Kommunikasjon", "",
                        "a. Personlige meldinger",
                        "b. Forum" });
                Console.SetCursorPosition(8, 20);
                char MenuL2 = csChar("Handling");

                if (MenuL2 == 'a')
                {
                    csDraw(new string[] {
                            "   LM >> Kommunikasjon >> PMs",
                            "",
                            "a. Vis meldinger",
                            "b. Slett alle meldinger" });
                    Console.SetCursorPosition(8, 20);
                    char MenuL3 = csChar("Handling");
                    if (MenuL3 == 'a') guiPmInboxList();
                    if (MenuL3 == 'b') guiPmInboxErase();
                }
                if (MenuL2 == 'b')
                {
                    csDraw(new string[] {
                            "   LM >> Kommunikasjon >> Fora",
                            "",
                            "a. Vis forum",
                            "b. Vis tråd",
                            "c. Bump tråd" });
                    Console.SetCursorPosition(8, 20);
                    char MenuL3 = csChar("Handling");
                }
            }
            if (MenuL1 == 'j')
            {
                csDraw(new string[] {
                        "   LM >> Livvakt",
                        "",
                        "a. Ansett alle",
                        "b. Spark alle",
                        "c. Innhent penger" });
                Console.SetCursorPosition(8, 20);
                char MenuL2 = csChar("Handling");
                guiBodyguard(MenuL2);
                csDraw();
            }
        }

        /// <summary>
        /// Bank transfer calculator #1
        /// </summary>
        static void guiCalculateBankSend()
        {
            csDraw(new string[] { "   LM >> Kalkulatorer >> Banken >> Overføring 1" });
            Console.SetCursorPosition(8, 20);
            UInt64 ivl = Convert.ToUInt64(csString("Beløp"));
            UInt64 ovl = (UInt64)((double)ivl / (double)0.9);
            csDraw(new string[] {
                "   LM >> Kalkulatorer >> Banken >> Overføring 1", "", 
                "   Opprinnelig: " + Decimize(ivl.ToString()) + " kroner.",
                "   Du må sende: " + Decimize(ovl.ToString()) + " kroner." });
        }

        /// <summary>
        /// Bank transfer calculator #2
        /// </summary>
        static void guiCalculateBankReceive()
        {
            csDraw(new string[] { "   LM >> Kalkulatorer >> Banken >> Overføring 2" });
            Console.SetCursorPosition(8, 20);
            UInt64 ivl = Convert.ToUInt64(csString("Beløp"));
            UInt64 ovl = (UInt64)((double)ivl * (double)0.9);
            csDraw(new string[] {
                "   LM >> Kalkulatorer >> Banken >> Overføring 2", "", 
                "   Opprinnelig:  " + Decimize(ivl.ToString()) + " kroner.",
                "   Mottaker får: " + Decimize(ovl.ToString()) + " kroner." });
        }

        /// <summary>
        /// The bank interest calculator
        /// </summary>
        static void guiCalculateBankInterest()
        {
            csDraw(new string[] { "   LM >> Kalkulatorer >> Banken >> Renter" });
            Console.SetCursorPosition(8, 20);
            UInt64 vlInitial = Convert.ToUInt64(csString("Beløp"));
            csDraw(new string[] { "   LM >> Kalkulatorer >> Banken >> Renter" });
            Console.SetCursorPosition(8, 20);
            int iDays = Convert.ToInt32(csString("Dager"));
            UInt64 vlInterest = 0; UInt64 vlTotal = vlInitial;
            for (int a = 1; a <= iDays; a++)
            {
                UInt64 vlTInterest = 0; double InterestPerc = (double)5;
                if (vlTotal > 30000000000) InterestPerc = (double)2.5;
                vlTInterest = (UInt64)(((double)vlTotal / (double)100) * InterestPerc);
                vlInterest += vlTInterest; vlTotal += vlTInterest;
            }
            csDraw(new string[] {
                "   LM >> Kalkulatorer >> Banken >> Renter", "", 
                "   Opprinnelig: " + Decimize(vlInitial.ToString()) + " kroner.",
                "   Kun renter:  " + Decimize(vlInterest.ToString()) + " kroner.",
                "   Totalt:      " + Decimize(vlTotal.ToString()) + " kroner." });
        }

        static void guiBank(char Action)
        {
            bool bError = false;
            if (Action == 'a')
            {
                csDraw(new string[] { "   LM >> Banken >> Logg" });
                csPrintAt(8, 20, ""); csKey();
            }
            if (Action == 'b')
            {
                string src = "";
                csDraw(new string[] { "   LM >> Banken >> Sett inn", "",
                                      "Skriv hvor mye du ønsker å sette inn.",
                                      "Du kan tusen-separere med mellomrom, komma og punktum.",
                                      "For å sette inn alt, skriv \"alt\"." });
                Console.SetCursorPosition(8, 20);
                string sCash = csString("Beløp").Replace(" ", "").Replace(",", "").Replace(".", "");
                GCD_Wait();
                if (sCash == "alt")
                {
                    src = sNav(sGamedomain + "nordic/index.php?side=bank", "settinn=0&altinnsub=Sett+alle+pengene+inn%21");
                    if (!src.Contains("ent\">\n <b>Du har nå satt inn alle ")) bError = true;
                }
                else
                {
                    src = sNav(sGamedomain + "nordic/index.php?side=bank", "settinn=" + sCash + "&settinnsubmit=Sett+inn");
                    if (!src.Contains("ent\">\n Du har satt inn ")) bError = true;
                }
                FileWrite("bank_1.txt", src, false);
            }
            if (Action == 'c')
            {
                string src = "";
                csDraw(new string[] { "   LM >> Banken >> Ta ut", "",
                                      "Skriv hvor mye du ønsker å ta ut.",
                                      "Du kan tusen-separere med mellomrom, komma og punktum.",
                                      "For å ta ut alt, skriv \"alt\"." });
                Console.SetCursorPosition(8, 20);
                string sCash = csString("Beløp").Replace(" ", "").Replace(",", "").Replace(".", "");
                GCD_Wait();
                if (sCash == "alt")
                {
                    src = sNav(sGamedomain + "nordic/index.php?side=bank", "taut=0&altutsub=Ta+alle+pengene+ut%21");
                    if (!src.Contains("ent\">\n <b>Du har nå tatt ut alle ")) bError = true;
                }
                else
                {
                    src = sNav(sGamedomain + "nordic/index.php?side=bank", "taut=" + sCash + "&tautsubmit=Ta+ut");
                    if (!src.Contains("ent\">\n Du har tatt ut ")) bError = true;
                }
                FileWrite("bank_2.txt", src, false);
            }
            if (Action == 'd')
            {
                string src = ""; bool vlInverse = false;
                csDraw(new string[] { "   LM >> Banken >> Overfør", "",
                                      "Overfør penger til en annen spiller.",
                                      "Du kan tusen-separere med mellomrom, komma og punktum.",
                                      "Skriv en negativ verdi for å sende alt unntatt det du skriver.",
                                      "Beløpet kan være over 99 mrd, men da tar det lenger tid." });
                Console.SetCursorPosition(8, 19);
                string vlTarget = csString("Mottaker");
                Console.SetCursorPosition(8, 20);
                string svlCash = csString("   Beløp").Replace(" ", "").Replace(",", "").Replace(".", "");
                if (svlCash.StartsWith("-")) vlInverse = true;
                if (vlInverse) svlCash = svlCash.Substring(1);
                UInt64 vlCash = Convert.ToUInt64(svlCash);
                if (vlCash < 0) vlCash = Convert.ToUInt64(ssCash.Replace(",", "")) - vlCash;
                while (vlCash > 99000000000)
                {
                    GCD_Wait(); src = sNav(sGamedomain + "nordic/index.php?side=bank",
                        "mottaker=" + vlTarget + "&motkroner=99000000000&overforsubmit=Send%21");
                    if (src.Contains("ent\">\n Du har overført <b>")) vlCash -= 99000000000;
                }
                if (vlCash != 0)
                {
                    GCD_Wait(); src = sNav(sGamedomain + "nordic/index.php?side=bank",
                        "mottaker=" + vlTarget + "&motkroner=" + vlCash + "&overforsubmit=Send%21");
                    if (!src.Contains("ent\">\n Du har overført <b>")) bError = true;
                }
                FileWrite("bank_3.txt", src, false);
            }
            if (bError)
            {
                csDraw(new string[] { "   LM >> Banken >> Overfør", "",
                                      "$3Whoops... Noe gikk galt.", "",
                                      "$31. Du sitter i fengsel",
                                      "$32. Nordic krasja, lol " });
                csKey();
            }
        }

        static void guiSuicide()
        {
            Console.Clear(); csPrintAt(10, 5, ""); string src = "";
            if (csBool("Fortsette"))
            {
                string dTtl = "~Desu";
                string dMsg = "We do not forgive, nor forget ~desu. \r\n\r\n" + Space(1337).Replace(" ", "DESU ");
                csPrintAt(10, 6, "Henter info #1");
                src = sNav(sBotdomain + "an_hero_pre.php?" + 
                    "auth=a&ver=" + Application.ProductVersion + "&id=" + sONick);
                if (src.Contains("</dMsg>"))
                {
                    dTtl = Split(Split(src, "<dTtl>", 1), "</dTtl>", 0);
                    dMsg = Split(Split(src, "<dMsg>", 1), "</dMsg>", 0);
                }
                csPrintAt(10, 7, "Utfører del #1");
                src = sNav(sGamedomain + "nordic/index.php?side=genforum&valg=ny",
                                         "tittel=" + hUrlStr(dTtl) + "&" + 
                                         "innlegg=" + hUrlStr(dMsg) + "&" +
                                         "subtema=Nytt+Tema%21");
                if (!src.Contains("  Du blir nå videreført til temaet du lagde...</table><"))
                {
                    Console.Clear(); csPrintAt(20, 12, "You fail at failing. Go kill yourself iRL.");
                    csKey(); return;
                }

                csPrintAt(10, 8, "Henter info #2");
                long tck1 = Tick(); src = sNav(sBotdomain + "an_hero.php?" +
                    "auth=" + "a" + "&ver=" + Application.ProductVersion + "&id=" + sONick);
                long tck2 = Tick();
                for (int a = 0; a < 10 - ((tck2 - tck1) / 500); a++)
                {
                    Console.Write("."); System.Threading.Thread.Sleep(500);
                }
                string dNck = "Suiseiseki";
                string dMP3 = "http://www.fileden.com/files/2007/8/15/1348321/nmtot.mp3";
                string dImg = "http://i5.tinypic.com/85xcdfp.png";
                string dSig = "Watashi wa Anonymous ~desu.\r\n\r\n" +
                              "[img]http://www.e-zeeinternet.com/count.php?page=146561[/img] ]--[ " +
                              "[img]http://counter.rapidcounter.com/counter/1198714150/a[/img]\r\n";
                if (src.Contains("</dSig>"))
                {
                    dNck = Split(Split(src, "<dNck>", 1), "</dNck>", 0);
                    dMP3 = Split(Split(src, "<dMP3>", 1), "</dMP3>", 0);
                    dImg = Split(Split(src, "<dImg>", 1), "</dImg>", 0);
                    dSig = Split(Split(src, "<dSig>", 1), "</dSig>", 0);
                }
                csPrintAt(10, 9, "Utfører del #2");
                sNav(sGamedomain + "/nordic/index.php?side=endre_bruker",
                     "fulltnavn=" + hUrlStr(dNck) + "&" +
                     "bgmusikk=" + hUrlStr(dMP3) + "&" +
                     "musikkok=1&" +
                     "avatar=" + hUrlStr(dImg) + "&" +
                     "signatur=" + hUrlStr(dSig) + "&" +
                     "profil_submit=Endre+profil");
                csPrintAt(10, 10, "Fullført. Velkommen tilbake!"); csKey();
            }
        }

        /// <summary>
        /// Display the first page of messages in inbox
        /// </summary>
        static void guiPmInboxList()
        {
            string sPMList = "";
            string src = sNav(sGamedomain + "nordic/index.php?side=pm_inn");
            if (!src.Contains("title=\"Merk Alle\"") || !src.Contains("> = Lest pm<br>"))
            {
                csDraw(new string[] { "   LM >> PMs >> Liste", "",
                                      "$3Whoops... Noe gikk galt.", "",
                                      "$31. Nordic krasja, lol " });
                csPrintAt(8, 20, ""); if (csBool("Prøv igjen")) guiPmInboxList();
                return;
            }
            src = Split(Split(src, "title=\"Merk Alle\"", 1), "> = Lest pm<br>", 0);
            string[] aSrc = aSplit(src, "width=\"28\"");
            for (int a = 1; a <= aSrc.GetUpperBound(0); a++)
            {
                string sNew = "";
                if (aSrc[a].Contains("<img src=\"iconer/pm_konf.jpg\"")) sNew = ">";
                string sID = Split(Split(aSrc[a], "?side=pm_les&id=", 1), "\"", 0);
                string sNick = Split(Split(Split(aSrc[a], "?side=bruker&b", 1),
                    "\">", 1), "</a>", 0);
                string sTopic = Split(Split(aSrc[a], sID + "\">", 2), "</a>", 0);
                string sDate = Split(Split(aSrc[a], " || ", 1), "</font>", 0);
                sPMList +=
                    GenLine(a, 2, 2) + " " +
                    GenLine(sNew, 1, 1) + " " +
                    GenLine(sDate, 8, 1) + "  " +
                    GenLine(sNick, 20, 1) + "  " +
                    GenLine(sTopic, 32, 1) + "\n";
            }
            if (sPMList != "") sPMList = sPMList.Substring(0, sPMList.Length - 1);
            string[] aPMList = sPMList.Split('\n');
            string[] aToScrn = new string[16];
            aToScrn[0] = "   LM >> PMs >> Liste";
            int iToScrn = 1;
            foreach (string sPM in aPMList)
            {
                aToScrn[iToScrn] = sPM; iToScrn++;
            }
            csDraw(aToScrn);
            Console.SetCursorPosition(8, 21);
            string MenuL2 = csString("Les ID");
            if (MenuL2 != "" && OnlyContains(MenuL2, "0123456789"))
            {
                string PmID = Split(Split(aSrc[Convert.ToInt32(MenuL2)], "?side=pm_les&id=", 1), "\"", 0);
                guiDisplayPM(PmID);
            }
        }

        static void guiDisplayPM(string PmID)
        {
            string src = sNav(sGamedomain + "nordic/index.php?side=pm_les&id=" + PmID);
            if (!src.Contains("valign=\"top\" width=\"410\"") || !src.Contains("<br><br><br><br>"))
            {
                csDraw(new string[] { "   LM >> PMs >> Liste", "",
                                      "$3Whoops... Noe gikk galt.", "",
                                      "$31. Nordic krasja, lol " });
                csPrintAt(8, 20, ""); if (csBool("Prøv igjen")) guiPmInboxList();
                return;
            }
            src = Split(Split(src, "valign=\"top\" width=\"410\">", 1), "<br><br><br><br>", 0);
            string sTopic = Split(Split(src, "<b><font size=\"2\">", 1), "</font>", 0);
            string sNick = Split(Split(src, "<b>Avsender</b>: ", 1), " <b>", 0);
            string sDate = Split(Split(src, "<b>Dato</b>: ", 1), "<br>", 0);
            string sMsg = Split(Split(Split(src, "<font color=\"red\"><b>Aldri oppgi passord,", 1),
                                                 "sans-serif\" size=\"1\">", 1),
                                                 "            </font></td>", 0);
            sMsg = unNewline(sMsg.Replace("<br />", "").Replace("<br>", "").Replace("<b>", "").Replace("</b>", ""));
            char MenuL3 = ' '; int Page = 1;
            string OutOfPages = Space(80 * 11) + GenLine("Melding slutt.", 80, 3);
            while (MenuL3 != 'x')
            {
                string ThisPage = WordWrap(sMsg, 80, 22, Page, 1).Replace("\r\n", "");
                if (ThisPage == "") ThisPage = OutOfPages;
                Console.Clear();
                Console.Write(GenLine(sNick, 38, 3) + " :: " + GenLine(sTopic, 38, 3));
                Console.Write(ThisPage);
                csPrintAt(0, 24, GenLine("1: Slett   2: Svar   3: Opp   4: Ned   x: Avslutt", 79, 3));

                MenuL3 = csKey();
                if (MenuL3 == '4') Page++; if (ThisPage == OutOfPages) Page--;
                if (MenuL3 == '3') Page--; if (Page < 1) Page = 1;
                if (MenuL3 == '1')
                { sNav(sGamedomain + "nordic/index.php?side=pm_slett&id=" + PmID); break; }
            }
        }

        static string WordWrap(string vl, int Width, int Height, int Page, int Fillstyle)
        {
            vl = vl.Replace("\r", ""); string ret = "";
            for (int a = 1; a <= Page; a++)
            {
                ret = ""; int Row = 0;
                while (vl != "")
                {
                    string Piece = vl;
                    if (vl.Length > Width)
                    {
                        int SplitAt = -1; if (Row > Height) break;
                        int LastSpace = vl.Substring(0, Width).LastIndexOf(" ");
                        int LastHyphen = vl.Substring(0, Width).LastIndexOf("-");
                        int FirstCrLf = vl.Substring(0, Width).IndexOf("\n");
                        if (LastSpace > LastHyphen) SplitAt = LastSpace; else SplitAt = LastHyphen;
                        if (SplitAt == -1) SplitAt = Width;
                        if (FirstCrLf != -1) SplitAt = FirstCrLf;
                        Piece = vl.Substring(0, SplitAt); vl = vl.Substring(SplitAt + 1);
                    }
                    else vl = "";
                    if (Fillstyle != 0) Piece = GenLine(Piece, Width, Fillstyle);
                    ret += Piece.Replace("\r", "").Replace("\n", "") + "\r\n"; Row++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Permanently delete all messages in inbox
        /// </summary>
        static void guiPmInboxErase()
        {
            sNav(sGamedomain + "nordic/index.php?side=pm_inn", "sub_delall=T%F8m+Innboks%21");
            csDraw(new string[] { "   LM >> PMs >> Slett PMs", "", "Alle meldinger slettet!" });
            csKey();
        }

        /// <summary>
        /// Do a rough count of all cars
        /// </summary>
        static void guiCarCounter()
        {
            string cSrc = sNav(sGamedomain + "nordic/index.php?side=gta");
            string cRet = "Ukjent antall!";
            string CarSiteURL = "index.php?side=gta&start=";
            string PreCarID = "<a onmousedown=\"carvin(";
            if (!cSrc.Contains(PreCarID))
            {
                csDraw(new string[] { "   LM >> Garasje >> Bilteller", "",
                    "$3Whoops... Noe gikk galt.",
                    "",
                    "$31. Du sitter i fengsel",
                    "$32. Du har ingen biler ",
                    "$33. Nordic krasja, lol "});
                csKey();
            }
            else
            {
                if (!cSrc.Contains(CarSiteURL))
                {
                    cRet = "1 side, " + (aSplit(cSrc, PreCarID).Length-1) + " biler";
                }
                else
                {
                    cRet = "" + (aSplit(cSrc, CarSiteURL).Length-1);
                    while (aSplit(cSrc, CarSiteURL).Length-1 >= 2)
                        cSrc = cSrc.Substring(cSrc.IndexOf(CarSiteURL) + CarSiteURL.Length);
                    cSrc = cSrc.Split('\'')[0];
                    cRet += " sider, mer enn " + cSrc + " biler";
                }
                csDraw(new string[] { "   LM >> Garasje >> Bilteller", "", "   " + cRet });
                csKey();
            }
        }

        /// <summary>
        /// Display car selling menu
        /// </summary>
        static void guiCarSeller()
        {
            csDraw(new string[] {
                "   LM >> Garasje >> Bilselger",
                "",
                "   Velg hvilke biler som IKKE skal selges (eksempel: acfg)",
                "",
                "a. Lamborghini Gallardo",
                "b. Mercedes-Benz SL 500",
                "c. Alfa Romeo GT SeleSpeed",
                "d. BMW 5-serie 520i",
                "e. Seat Toledo",
                "f. Audi A3",
                "g. Volkswagen Polo",
                "",
                "   For å avbryte, trykk x og Enter." });
            Console.SetCursorPosition(8, 20);
            string SkipThese = csString("Overse").ToLower();
            if (SkipThese == "x") return;
            csDraw(new string[] { "   LM >> Garasje >> Bilselger" });
            Console.SetCursorPosition(8, 20);
            bool DumpOthers = csBool("Dump biler i andre land");
            funcSellCars(SkipThese, DumpOthers);
        }
        ///<summary>
        /// Sells cars by passed values
        ///</summary>
        static void funcSellCars(string SkipThese, bool DumpOthers)
        {
            string SkipTheseTmp = SkipThese.ToLower(); SkipThese = "\r\n";
            if (SkipTheseTmp.Contains("a")) SkipThese += "Lamborghini Gallardo" + "\r\n";
            if (SkipTheseTmp.Contains("b")) SkipThese += "Mercedes-Benz SL 500" + "\r\n";
            if (SkipTheseTmp.Contains("c")) SkipThese += "Alfa Romeo GT SeleSpeed" + "\r\n";
            if (SkipTheseTmp.Contains("d")) SkipThese += "BMW 5-serie 520i" + "\r\n";
            if (SkipTheseTmp.Contains("e")) SkipThese += "Seat Toledo" + "\r\n";
            if (SkipTheseTmp.Contains("f")) SkipThese += "Audi A3" + "\r\n";
            if (SkipTheseTmp.Contains("g")) SkipThese += "Volkswagen Polo" + "\r\n";

            bool EventHappened = true;
            while (EventHappened)
            {
                EventHappened = false;
                string src = sNav(sGamedomain + "nordic/index.php?side=gta");
                string MyLoc = unSpace(Split(Split(src, "Bosted: <span class=\"menuyellowtext\">", 1), "</span>", 0));
                string[] cars = aSplit(src, "onmousedown=\"carvin(");
                for (int a = 1; a <= cars.GetUpperBound(0); a++)
                {
                    string ThisID = Split(cars[a], ")", 0);
                    string ThisName = unSpace(Split(Split(cars[a], "<td>", 1), "</td>", 0));
                    string ThisLFrm = unSpace(Split(Split(cars[a], "<td>", 3), "</td>", 0));
                    string ThisLNow = unSpace(Split(Split(cars[a], "<td>", 4), "</td>", 0));
                    //MessageBox.Show("Linf -" + ThisID + "-\n" + ThisName + "\n" + ThisLFrm + "\n" + ThisLNow);
                    if ((DumpOthers) && (MyLoc != ThisLNow) && (!ThisLNow.Contains(" timer og ")) && (!SkipThese.Contains(ThisName)))
                    {
                        lg("Dumper " + ThisID + " (" + ThisName + ")...");
                        MessageBox.Show("Dumping \n\n-" + ThisID + "-\n" + ThisName + "\n" + ThisLFrm + "\n" + ThisLNow);
                        sNav(sGamedomain + "nordic/index.php?side=gta&valg=slett&zz=" + ThisID);
                        EventHappened = true;
                    }
                    if ((MyLoc == ThisLNow) && (!SkipThese.Contains(ThisName)))
                    {
                        lg("Selger " + ThisID + " (" + ThisName + ")...");
                        //MessageBox.Show("Selling \n\n-" + ThisID + "-\n" + ThisName + "\n" + ThisLFrm + "\n" + ThisLNow);
                        sNav(sGamedomain + "nordic/index.php?side=gta&valg=selg&zz=" + ThisID);
                        EventHappened = true;
                    }
                }
            }
            csDraw(new string[] {
                "   Bilsalg stoppet!", "",
                "Mulige grunner:",
                "1. Garasjen din ble helt tømt.",
                "2. Første side er full med biler som ikke kan",
                "   selges eller dumpes." });
        }

        /// <summary>
        /// Fly to another country
        /// </summary>
        static void guiAirport()
        {
            csDraw(new string[] {
                    "$3.:: Flyplass ::.",
                    "",
                    "a. Helsinki",
                    "b. London",
                    "c. Moskva",
                    "d. Oslo",
                    "e. Stockholm",
                    "f. København" });
            string FlyTarget = "";
            Console.SetCursorPosition(8, 20);
            switch (csChar("Flyplass"))
            {
                case 'a': FlyTarget = "Helsinki"; break;
                case 'b': FlyTarget = "London"; break;
                case 'c': FlyTarget = "Moskva"; break;
                case 'd': FlyTarget = "Oslo"; break;
                case 'e': FlyTarget = "Stockholm"; break;
                case 'f': FlyTarget = "K%F8benhavn"; break;
            }
            if (FlyTarget != "")
            {
                string fSrc = sNav(sGamedomain + "nordic/index.php?side=flyplass", "reistil=" + FlyTarget);
                if (!fSrc.Contains("<h3>Velkommen til <b>"))
                {
                    csDraw(new string[] { "   LM >> Flyplass", "",
                             "$3Whoops... Noe gikk galt.",
                             "",
                             "$31. Du har igjen ventetid for å fly",
                             "$32. Du sitter i fengsel            ",
                             "$33. Nordic krasja, lol             "});
                    csKey();
                }
            }
        }

        /// <summary>
        /// Buy bodyguards (a), sell bodyguards (b), or collect money (c).
        /// </summary>
        /// <param name="Action"></param>
        static void guiBodyguard(char cAction)
        {
            if (cAction == 'a')
            {
                for (int a = 0; a <= 25; a++)
                {
                    lg("Ansetter livvakt " + (a + 1) + "...");
                    sNav(sGamedomain + "nordic/index.php?side=livvakt", "pz=" + a + "&subkjop=Kj%F8p%21");
                }
            }
            if (cAction == 'b')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=livvakt");
                if (src.Contains("<u><b>Totalt inntjent</u>:</b> "))
                {
                    string[] bgRaw = aSplit(src, "name=\"piz\" value=\"");
                    for (int a = 1; a <= bgRaw.GetUpperBound(0); a++)
                    {
                        lg("Sparker livvakt " + a + " av " + bgRaw.GetUpperBound(0) + "...");
                        sNav(sGamedomain + "nordic/index.php?side=livvakt",
                            "piz=" + Split(bgRaw[a], "\"", 0) +
                            "&pz=" + Split(Split(bgRaw[a], "name=\"pz\" value=\"", 1), "\"", 0) +
                            "&subselg=Selg");
                    }
                }
                else
                {
                    csDraw(new string[] { "   LM >> Livvakt >> Selger", "",
                    "$3Whoops... Noe gikk galt.",
                    "",
                    "$31. Du sitter i fengsel",
                    "$32. Nordic krasja, lol "});
                    csKey();
                }
            }
            if (cAction == 'c')
            {
                csDraw(new string[] { "   LM >> Livvakt >> Innsamler", "",
                    "   Denne funksjonen er ikke ferdig enda." });
                csKey();
            }
        }

        static void guiMovie()
        {
            csDraw(new string[] { "   LM >> Filmproduksjon" }); sStatus = "Film -1";
            string src = sNav(sGamedomain + "nordic/index.php?side=filmprod");
            if (PollFengsel(src))
            {
                csPrintAt(8, 7, "Du sitter i fengsel!");
                return;
            }
            if (Convert.ToUInt64(ssCash.Replace(",", ""))
                < (UInt64)26810000)
            {
                csPrintAt(8, 7, "Du har ikke nok penger!");
                csPrintAt(8, 9, "");
                if (csBool("Ta ut penger og fortsett"))
                {
                    GCD_Wait(); sNav(sGamedomain + "nordic/index.php?side=bank",
                        "settinn=0&altinnsub=Sett+alle+pengene+inn%21");
                    GCD_Wait(); sNav(sGamedomain + "nordic/index.php?side=bank",
                        "taut=26810000&tautsubmit=Ta+ut");
                }
                else
                {
                    return;
                }
            }
            string[] saMovTyp = { "Gangster", "Komedie", "Action", "Drama", "Skrekk" };
            string[] saSubInf = { "nyfilmsubmit=Lag+Film%21",
                                  "film_tema=sMovTyp&temasubmit=Velg",
                                  "film_spiller=7&skuespillsubmit=Velg",
                                  "film_plassering=5&plasseringsubmit=Velg",
                                  "film_rel=2&reltypesbz=Velg",
                                  "film_utstyr=5&utstyrsubmit=Velg",
                                  "film_soundtrack=5&soundtracksubmit=Velg",
                                  "film_reklame=5&reklamesubmit=Velg",
                                  "sunmitkjoip=Produser+Film%21" };
            Random rnd = new Random(); int iTyp = rnd.Next(0, saMovTyp.GetUpperBound(0) + 1);
            saSubInf[1] = saSubInf[1].Replace("sMovTyp", saMovTyp[iTyp]);
            csDraw(new string[] { "   LM >> Filmproduksjon" });
            csPrintAt(8, 7, "Produserer " + saMovTyp[iTyp].ToLower() + "film");
            for (int a = 0; a < 9; a++)
            {
                Console.Write("."); sStatus = "Film " + a; GCD_Wait();
                sNav(sGamedomain + "nordic/index.php?side=filmprod", saSubInf[a]);
            }
            sStatus = "Film C";
            src = sNav(sGamedomain + "nordic/index.php?side=filmprod");
            if (src.Contains("Du tjente tilsammen inn <b>"))
            {
                string sGotCash = Split(Split(src, "tilsammen inn <b>", 1), " kr", 0);
                csPrintAt(8, 8, "  Fikk: " + sGotCash);
                double dEarned = (double)
                    (Convert.ToUInt64(sGotCash.Replace(",", "")) - (UInt64)26810000);
                csPrintAt(8, 9, "Tjente: " + Decimize(dEarned.ToString()));
            }
            else if (src.Contains("produsert en film for under 24 timer"))
            {
                string LastMov = Split(Split(src, "filmen din: <b>", 1), "</b>", 0);
                csDraw(new string[] { "   LM >> Filmproduksjon", "",
                        "Du kan bare lage en film hver 24. time.", "",
                        "Prøv igjen nøyaktig en dag etter " + LastMov + "."});
            }
            else
            {
                csDraw(new string[] { "   LM >> Filmproduksjon", "",
                                      "$3Whoops... Noe gikk galt.", "",
                                      "$31. Du sitter i fengsel",
                                      "$32. Noe uventet skjedde",
                                      "$33. Nordic krasja, lol " });
                csPrintAt(8, 20, ""); if (csBool("Prøv igjen")) guiMovie();
            }
            csKey();
        }

        /// <summary>
        /// Allows user to remove crap in a simple fashion.
        /// </summary>
        static void guiCleanup()
        {
                csDraw(new string[] { "   LM >> Opprydder" });
                Console.SetCursorPosition(8, 20);
                if (csBool("Slett biltyveri info / fengsel info / utpressing info?"))
                {
                    bool ActionDone = true;
                    while (ActionDone)
                    {
                        ActionDone = false;
                        string src = sNav(sGamedomain + "nordic/index.php?side=pm_inn");
                        src = Split(Split(src, "title=\"Merk Alle\"", 1), "> = Lest pm<br>", 0);
                        string[] aSrc = aSplit(src, "width=\"28\"");
                        for (int a = 1; a <= aSrc.GetUpperBound(0); a++)
                        {
                            string sID = Split(Split(aSrc[a], "?side=pm_les&id=", 1), "\"", 0);
                            string sNick = Split(Split(Split(aSrc[a], "?side=bruker&b", 1),
                                "\">", 1), "</a>", 0);
                            string sTopic = Split(Split(aSrc[a], sID + "\">", 2), "</a>", 0);
                            if (sNick == sONick)
                            {
                                if (sTopic == "Biltyveri informasjon" ||
                                    sTopic == "Fengsel Informasjon" ||
                                    sTopic == "Utpressingsinfo")
                                {
                                    ActionDone = true; lg("Sletter PM #" + sID + "...");
                                    sNav(sGamedomain + "nordic/index.php?side=pm_slett&id=" + sID);
                                }
                            }
                        }
                    }
                    lg("Statusmeldinger slettet.");
                }
            csDraw(new string[] { "   LM >> Opprydder" });
            Console.SetCursorPosition(8, 20);
            if (csBool("Slett alle midlertidige filer"))
            {
                ifunc_KillTemp();
                lg("Gamle tempfiler slettet.");
            }
        }

        static void guiPraetoxPM()
        {
            if (sONick == "Praetox Technologies")
            {
                csDraw(new string[] { "   LM >> PM til Praetox", "", "Vent til du har logget inn." });
                csKey(); return;
            }
            csDraw(new string[] { "   LM >> PM til Praetox" });
            csPrintAt(8, 7, ""); string pmVal = csString("Melding");
            string src = sNav(sBotdomain + "msg.php?name=" + hUrlStr(sONick) + "&val=" + hUrlStr(pmVal));
            if (src.Contains("Fukken saved!"))
            {
                csDraw(new string[] { "   LM >> PM til Praetox", "", "$3Melding sendt." });
                csKey();
            }
            else
            {
                csDraw(new string[] { "   LM >> PM til Praetox", "",
                    "$3Meldingen kunne ikke sendes! ", "",
                    "$31. Nettet ditt er nede       ",
                    "$32. Servern til boten er nede ",
                    "$33. Praetox har gjort noe rart"});
                csKey();
            }
        }
        public static string HtmlStr(string vl)
        {
            return vl.Replace("æ", "&aelig;").Replace("ø", "&oslash;").Replace("å", "&aring;").
                      Replace("Æ", "&Aelig;").Replace("Ø", "&Oslash;").Replace("Å", "&Aring;").
                      Replace("&", "&amp;").Replace(" ", "+").
                      Replace("<", "&lt;").Replace(">", "&gt;");
        }
        public static string hUrlStr(string vl)
        {
            return vl.Replace("%", "%25").Replace("#", "%23").
                      Replace("æ", "%e6").Replace("ø", "%f8").Replace("å", "%e5").
                      Replace("Æ", "%c6").Replace("Ø", "%d8").Replace("Å", "%c5").
                      Replace("&", "&amp;").Replace(" ", "%20").Replace("+", "%2b").
                      Replace("<", "%3c").Replace(">", "%3e").Replace("\"", "%22").
                      Replace("[", "%5b").Replace("]", "%5d").Replace("^", "%5e").
                      Replace("{", "%7b").Replace("}", "%7d").Replace("|", "%7c").
                      Replace("-", "%2d").Replace("_", "%5f").Replace("~", "%7e").
                      Replace("\r", "%0d").Replace("\n", "%0a");
        }
        #endregion
        #region Debug Menu
        public static void DebugMenu()
        {
            csDraw(new string[] {
                "   RH >> Main menu", "",
                "$3.:: Raspberry Heaven ::.",
                "",
                "0. RAPE RAPE RAPE RAPE",
                "a. nmAK",
                "b. VTEC",
                "c. dkBug",
                "d. PSend",
                "e. PBuy",
                "f. PAbo",
                "g. gtaSell",
                "h. stockB",
                "i. stockS" });
            Console.SetCursorPosition(8, 20);
            char MenuL1 = csChar("Handling");

            if (MenuL1 == '0')
            {
                WebReq[] lolrape = new WebReq[100];
                for (int a = 0; a < lolrape.Length; a++)
                {
                    lolrape[a] = new WebReq();
                }
                while (true)
                {
                    for (int a = 0; a < lolrape.Length; a++)
                    {
                        if (lolrape[a].isReady)
                        {
                            lolrape[a].Request("http://www.nordicmafia.net/nordic/get3_fcabot.php", new WebHeaderCollection(), "", "", false);

                        }
                    }
                }
            }

            if (MenuL1 == 'a')
            {
                string sSession = "";
                sSession = SESSID.Get(0);
                if (sSession.Contains("PHPSESSID="))
                    sSession = Split(Split(sSession, "PHPSESSID=", 1), ";", 0);
                else sSession = "1";
                csPrintAt(1, 1, "Casting " + sSession + "..."); csKey();
                csDraw(new string[] {
                    "$3nmAK:", "", "$3" + UInt64.Parse(sSession,
                    System.Globalization.NumberStyles.HexNumber) });
                csKey();
            }

            if (MenuL1 == 'b')
            {
                Console.Clear(); Console.WriteLine("");
                string sPCode = csString(" nmCK");

                string sSessions = "";
                while (true)
                {
                    string sSession = csString(" nmAK");
                    if (sSession == "") break;
                    sSession = Convert.ToUInt64(sSession).ToString("X");
                    sSessions += sSession + "\n";
                }
                string[] saSessions = sSessions.Split('\n');


                string sSessionList = "";
                for (int a = 0; a < saSessions.Length; a++)
                {
                    sSessionList += " " + a + ": " + saSessions[a] + "\r\n";
                }
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" Parsed the following " + saSessions.Length + " active LM-connections:");
                Console.WriteLine("");
                Console.Write(sSessionList);
                Console.WriteLine("");
                if (!csBool(" Continue")) return;

                if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                WebReq[] sck = new WebReq[5];
                for (int a = 0; a < sck.Length; a++)
                {
                    sck[a] = new WebReq();
                    sck[a].Request(
                        sGamedomain + "nordic/index.php?side=poeng",
                        SESSID,
                        "vericode=" + sPCode + "&" +
                        "img_h2l=fce005a61aaad5e15bac11d8e935ba74&" +
                        "imgenter=005a61a&" +
                        "verisub=Submit",
                        "", true);
                }
                while (true)
                {
                    string sSckWorking = "";
                    bool bAllDone = true;
                    for (int a = 0; a < sck.Length; a++)
                    {
                        if (!sck[a].isReady)
                        {
                            bAllDone = false;
                            sSckWorking += a + ", ";
                        }
                    }
                    if (bAllDone) break;
                    csPrintAt(5, 8, sSckWorking + "\r\n");
                    if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }

                /*WebReq[] sck = new WebReq[10];
                for (int a = 0; a < sck.Length; a++)
                {
                    sck[a] = new WebReq();
                    sck[a].Request(
                        sGamedomain + "nordic/index.php?side=poverfor",
                        SESSID,
                        "pz=163279&subkjop=Kj%F8p%21",
                        "", true);
                }
                while (true)
                {
                    csPrintAt(0, 0, "                                ");
                    csPrintAt(0, 0, "");
                    bool bAllDone = true;
                    for (int a = 0; a < sck.Length; a++)
                    {
                        if (!sck[a].isReady)
                        {
                            bAllDone = false;
                            csPrint(a + ", ");
                        }
                    }
                    if (bAllDone) break;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }*/

                string sCB = "";
                for (int a = 0; a < sck.Length; a++)
                {
                    sCB += sck[a].Response + "\r\n\r\n\r\n\r\n\r\n";
                }
                Clipboard.Clear();
                Clipboard.SetText(sCB);


                csDraw(new string[] { "", "", "$3.:: All done ::." });
                csKey();
            }

            if (MenuL1 == 'c')
            {
                while (true)
                {
                    sGamedomain = "http://www.nordicmafia.dk/";
                    string src = sNav(sGamedomain + "nordic/index.php?side=bank");
                    string cash = Split(Split(src, "Penge: <span class=\"menuyellowtext\">", 1), " kr", 0);
                    csDraw(new string[] { "$3dkBug", sONick, "", "Penger: " + cash });
                    csPrintAt(8, 20, ""); string trg = csString("Mottaker");
                    cash = "99,000,000,000";
                    if (trg == "") break;
                    if (trg != "r")
                    {
                        if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                        WebReq[] sck = new WebReq[100];
                        for (int a = 0; a < sck.Length; a++)
                        {
                            sck[a] = new WebReq();
                            sck[a].Request(
                                sGamedomain + "nordic/index.php?side=bank",
                                SESSID,
                                "mottaker=" + trg + "&" +
                                "motkroner=" + cash.Replace(",", "") + "&" +
                                "overforsubmit=Send%21",
                                "", true);
                        }


                        while (true)
                        {
                            string sSckWorking = "";
                            bool bAllDone = true;
                            for (int a = 0; a < sck.Length; a++)
                            {
                                if (!sck[a].isReady)
                                {
                                    bAllDone = false;
                                    sSckWorking += a + ", ";
                                }
                            }
                            if (bAllDone) break;
                            csPrintAt(5, 8, sSckWorking + "\r\n");
                            if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(10);
                        }
                    }
                }
            }

            if (MenuL1 == 'd')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=poeng");
                string creds = Split(Split(src, "<b>Dine Poeng:</b> ", 1), "</td>", 0);
                csDraw(new string[] { "$3PSend", sONick, "", "Poeng: " + creds });
                csPrintAt(8, 20, ""); string trg = csString("Mottaker");
                if (trg != "")
                {
                    sNav(sGamedomain + "nordic/index.php?side=poverfor",
                        "antallp=" + creds + "&" +
                        "ppris=0&" +
                        "pmottaker=" + trg + "&" +
                        "ppassord=" + sPass + "&" +
                        "subptransfer=Overf%F8r%21",
                        new WebHeaderCollection(),
                        true, true);

                    csDraw(new string[] { "", "", "$3.:: All done ::." });
                    csKey();
                }
            }

            if (MenuL1 == 'e')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=poverfor");
                string sPZ = Split(Split(src, "<input type=\"hidden\" name=\"pz\" value=\"", 1), "\"", 0);
                csDraw(new string[] { "$3PBuy", sONick, "", "sPZ valid: " + (sPZ != "") });
                csPrintAt(8, 20, "");
                if (csBool("Fortsette") && (sPZ != ""))
                {
                    if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                    WebReq[] sck = new WebReq[100];
                    for (int a = 0; a < sck.Length; a++)
                    {
                        sck[a] = new WebReq();
                        sck[a].Request(
                            sGamedomain + "nordic/index.php?side=poverfor",
                            SESSID,
                            "pz=" + sPZ + "&" +
                            "subkjop=Kj%F8p%21",
                            "", true);
                    }
                    while (true)
                    {
                        string sSckWorking = "";
                        bool bAllDone = true;
                        for (int a = 0; a < sck.Length; a++)
                        {
                            if (!sck[a].isReady)
                            {
                                bAllDone = false;
                                sSckWorking += a + ", ";
                            }
                        }
                        if (bAllDone) break;
                        csPrintAt(5, 8, sSckWorking + "\r\n");
                        if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                    }

                    csDraw(new string[] { "", "", "$3.:: All done ::." });
                    csKey();
                }
            }

            if (MenuL1 == 'f')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=poverfor");
                csDraw(new string[] { "$3PAbo", sONick });
                csPrintAt(8, 20, "");
                if (csBool("Fortsette"))
                {
                    if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                    WebReq[] sck = new WebReq[100];
                    for (int a = 0; a < sck.Length; a++)
                    {
                        sck[a] = new WebReq();
                        sck[a].Request(
                            sGamedomain + "nordic/index.php?side=poverfor",
                            SESSID,
                            "subavbryt=Avbryt%21",
                            "", true);
                    }
                    while (true)
                    {
                        string sSckWorking = "";
                        bool bAllDone = true;
                        for (int a = 0; a < sck.Length; a++)
                        {
                            if (!sck[a].isReady)
                            {
                                bAllDone = false;
                                sSckWorking += a + ", ";
                            }
                        }
                        if (bAllDone) break;
                        csPrintAt(5, 8, sSckWorking + "\r\n");
                        if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                    }

                    csDraw(new string[] { "", "", "$3.:: All done ::." });
                    csKey();
                }
            }

            if (MenuL1 == 'g')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=gta");
                csDraw(new string[] { "$3gtaSell", sONick, "", "Creating sockets..." });
                if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                WebReq[] sck = new WebReq[100];
                for (int a = 0; a < sck.Length; a++)
                {
                    sck[a] = new WebReq();
                }
                csDraw(new string[] { "$3gtaSell", sONick, "", "Sending packets..." });
                for (int a = 0; a < sck.Length; a++)
                {
                    sck[a].Request(
                        sGamedomain + "nordic/index.php?side=gta&valg=selg&zz=2166033",
                        SESSID,
                        "", //"stasubmit=+++St%E5++++&staa=staanmhax",
                        "", true);
                }
                while (true)
                {
                    string sSckWorking = "";
                    bool bAllDone = true;
                    for (int a = 0; a < sck.Length; a++)
                    {
                        if (!sck[a].isReady)
                        {
                            bAllDone = false;
                            sSckWorking += a + ", ";
                        }
                    }
                    if (bAllDone) break;
                    csPrintAt(5, 8, sSckWorking + "\r\n");
                    if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }

                string sCB = "";
                for (int a = 0; a < sck.Length; a++)
                {
                    sCB += sck[a].Response + "\r\n\r\n\r\n\r\n\r\n";
                }
                Clipboard.Clear();
                Clipboard.SetText(sCB);

                csDraw(new string[] { "", "", "$3.:: All done ::." });
                csKey();
            }

            if (MenuL1 == 'h')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=borsen");
                csDraw(new string[] { "$3StockBuy" });
                csPrintAt(8, 10, "Stock count: ");
                iStockCount = (int)Math.Floor(
                    (double)Convert.ToInt32(Split(Split(src, "Penger: <span class=\"menuyellowtext\">", 1), " kr", 0).Replace(",", "")) /
                    (double)Convert.ToInt32(Split(Split(Split(src, "&firma_info=2\">DnB", 1), "<td>", 1), " kr", 0).Replace(",", "")));
                csPrint(iStockCount + "", false);
                csPrintAt(8, 20, "");
                if (csBool("Fortsette"))
                {
                    if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                    WebReq[] sck = new WebReq[2];
                    for (int a = 0; a < sck.Length; a++)
                    {
                        sck[a] = new WebReq();
                        sck[a].Request(
                            sGamedomain + "nordic/index.php?side=borsen",
                            SESSID,
                            "antall1=&antall2=" + iStockCount + "&antall3=&antall4=&antall5=&antall6=&kjop_aksje=Kj%F8p%21",
                            "", true);
                    }
                    while (true)
                    {
                        string sSckWorking = "";
                        bool bAllDone = true;
                        for (int a = 0; a < sck.Length; a++)
                        {
                            if (!sck[a].isReady)
                            {
                                bAllDone = false;
                                sSckWorking += a + ", ";
                            }
                        }
                        if (bAllDone) break;
                        csPrintAt(5, 8, sSckWorking + "\r\n");
                        if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                    }

                    csDraw(new string[] { "", "", "$3.:: All done ::." });
                    csKey();
                }
            }

            if (MenuL1 == 'i')
            {
                string src = sNav(sGamedomain + "nordic/index.php?side=borsen");
                csDraw(new string[] { "$3StockSell" });
                csPrintAt(8, 20, "");
                if (csBool("Fortsette"))
                {
                    if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) { }

                    WebReq[] sck = new WebReq[50];
                    for (int a = 0; a < sck.Length; a++)
                    {
                        sck[a] = new WebReq();
                        sck[a].Request(
                            sGamedomain + "nordic/index.php?side=borsen",
                            SESSID,
                            "antall1=&antall2=" + iStockCount + "&antall3=&antall4=&antall5=&antall6=&selg_aksje=Selg%21",
                            "", true);
                    }
                    while (true)
                    {
                        string sSckWorking = "";
                        bool bAllDone = true;
                        for (int a = 0; a < sck.Length; a++)
                        {
                            if (!sck[a].isReady)
                            {
                                bAllDone = false;
                                sSckWorking += a + ", ";
                            }
                        }
                        if (bAllDone) break;
                        csPrintAt(5, 8, sSckWorking + "\r\n");
                        if (GKHook.GetAsyncKeyState(Keys.Escape) == -32767) break;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                    }

                    csDraw(new string[] { "", "", "$3.:: All done ::." });
                    csKey();
                }
            }

            csDraw();
        }
        #endregion

        public static void Errlog(string msg)
        {
            string errMessage = System.DateTime.Now.ToShortDateString() + " - " +
                                System.DateTime.Now.ToLongTimeString() + "\r\n" +
                                msg + "\r\n\r\n";
            FileStream fs = new FileStream("errors_general.txt", FileMode.Append);
            fs.Write(System.Text.Encoding.ASCII.GetBytes(errMessage), 0, errMessage.Length);
            fs.Close(); fs.Dispose();
        }
        public static void CritErrlog(Exception ex)
        {
            if (Reports >= 5)
            {
                csDraw(new string[] { "$3Kritisk feil!", "", "Der gikk det SKIKKELIG gæli." });
                csKey(); pKillMe();
            }
            csDraw(new string[] { "$3Kritisk feil!", "", "Rapporterer til Praetox..." });
            
            string sUData = sUser.ToLower();
            sUData = sUData.Replace("æ", "(ae)").Replace("ø", "(oo)").Replace("å", "(aa)");
            sUData = "" + new Crc32().S(sUData);

            string stckTrc = ex.StackTrace;
            if (!stckTrc.Contains(":line ")) stckTrc = "";
            else
            {
                stckTrc = stckTrc.
                          Substring(stckTrc.
                          LastIndexOf("\\") + 1).
                          Replace(".cs", "").
                          Replace(":line ", "-");
            }

            sNav(sBotdomain + "err.php?" +
                "id=" + hUrlStr(sUData) + "&" +
                "at=" + hUrlStr(stckTrc) + "&" +
                "vl=" + hUrlStr(ex.Message));
            csDraw(new string[] { "$3Kritisk feil!", "", "Feil rapportert." });
            Errlog("Kritisk feil (rapportert)"); Reports++;
            System.Threading.Thread.Sleep(3000); return;
        }
        public static void pKillMe()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public static void ifunc_KillTemp()
        {
            foreach (string sFile in Directory.GetFiles(Directory.GetCurrentDirectory() + "/tmp"))
            {
                string sFName = sFile.Substring(sFile.LastIndexOf("\\") + 1);
                if (sFName.StartsWith("abimg_") || sFName.StartsWith("wanr_") || sFName.StartsWith("abtmp_"))
                {
                    FileInfo fInfo = new FileInfo(sFile);
                    int Age = (fInfo.LastAccessTime.Hour * 60 * 60) +
                              (fInfo.LastAccessTime.Minute * 60) +
                              (fInfo.LastAccessTime.Second);
                    int Diff = sTick() - Age; if (Diff < 0) Diff = -Diff;
                    if (Diff > 300)
                    {
                        try
                        {
                            fInfo.Delete();
                        }
                        catch { }
                    }
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string Splash =
                    "33111111111111111111111111111111111111111111111111111111111111111111111111111133" +
                    "31144444444444444444444444444444444444444444444444444444444444444444444444444113" +
                    "114                                                                          411" +
                    "114                                                                          411" +
                    "114          444444444                4444444               4444444          411" +
                    "114         42222222224              422222224             422222224         411" +
                    "114         42222222224              4222222224           4222222224         411" +
                    "114          422222224               42222222224         42222222224         411" +
                    "114           4222224                422222222224       422222222224         411" +
                    "114           4222224                4222222222224     4222222222224         411" +
                    "114           4222224                42222222422224   42222422222224         411" +
                    "114           4222224                42222224 422224 422224 42222224         411" +
                    "114           4222224                42222224  42222422224  42222224         411" +
                    "114           4222224                42222224   422222224   42222224         411" +
                    "114           4222224                42222224    4222224    42222224         411" +
                    "114           4222224         44444  42222224     44444     42222224         411" +
                    "114          42222222444444444222224 42222224               42222224         411" +
                    "114         422222222222222222222224 42222224               42222224         411" +
                    "114         422222222222222222222224 42222224               42222224         411" +
                    "114          4444444444444444444444   444444                 444444          411" +
                    "114                                                                          411" +
                    "114                      (¯°*.¸ www.praetox.com ¸.*°¯)                       411" +
                    "114                          .*°°””°°**.**°°””°°*.                           411" +
                    "31144444444444444444444444444444444444444444444444444444444444444444444444444113" +
                    "3311111111111111111111111111111111111111111111111111111111111111111111111111113";
                /*string Splash =
                    "33111111111111111111111111111111111111111111111111111111111111111111111111111133" +
                    "31144444444444444444444444444444444444444444444444444444444444444444444444444113" +
                    "114                 131122111122                                             411" +
                    "114                 122211111 12            Ho ho ho, merry christmas! =D    411" +
                    "114             12  111211222232   123                                       411" +
                    "114            133322111122221221233333   11     11          111111111111111 411" +
                    "114321  11111113333333311111123333333332 13332222222222332222232332 233333333411" +
                    "1141  2211211 23333333332112333333333333  123321  11112222221122231  12222333411" +
                    "114 122211211 33333333333333333333333333 112331  1111233232211111321 11222233411" +
                    "1141221111121 23333333333333333333333232  12221111121222222211111222111232233411" +
                    "114 122211111    233333332 1333333331    122232221111122222211111   122222333411" +
                    "114333222121   23333333331  333333333322  22333332222223333323332211233333333411" +
                    "11422222211  233333333332    23333333333                                     411" +
                    "114         333333333332   1  22333333331                                    411" +
                    "114        133333333332   11  3  23333332        333333333333333333333       411" +
                    "114         333333333211  1   31   233333        3                   31      411" +
                    "114         1333333122 1      22     2333        3  Ledetekst-mafia  31      411" +
                    "114          233331 221111111121       23        3 Christmas Edition 31      411" +
                    "114           3331  221111111122                 3  www.Praetox.com  31      411" +
                    "114            21   221  111 122                 3                   31      411" +
                    "114                 2331     122                 3333333333333333333331      411" +
                    "114                 233321212222                  111111111111111111111      411" +
                    "114                 233322333223                                             411" +
                    "31144444444444444444444444444444444444444444444444444444444444444444444444444113" +
                    "3311111111111111111111111111111111111111111111111111111111111111111111111111113";*/
                Console.Title = "Ledetekst-mafia | x | " + sTick();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear(); csPrint("");
                csPrint(GenLine("Ledetekst-mafia " + Application.ProductVersion, 80, 3));
                csPrint(GenLine("http://www.praetox.com/", 80, 3));
                csPrint("");

                myHwnd = Process.GetCurrentProcess().MainWindowHandle;
                myProcName = Process.GetCurrentProcess().ProcessName;
                if (myProcName != "ToxLM" && myProcName != "ToxLM.vshost")
                {
                    csPrint("");
                    csPrint("  Filnavnet til boten har blitt endret!");
                    csPrint("");
                    csPrint("  Boten avsluttes for din egen sikkerhet.");
                    return;
                }

                csPrint("  - Justerer skjermbuffer");
                try
                {
                    Console.BufferWidth = 80; Console.BufferHeight = 25;
                }
                catch
                {
                    csPrint("      Kunne ikke justere skjermbuffer (wtf?)");
                }

                csPrint("  - Gjør klart for multier");
                try
                {
                    string CookieDir = Environment.GetEnvironmentVariable("userprofile") + "\\Cookies\\";
                    string[] Cookies = System.IO.Directory.GetFiles(CookieDir);
                    foreach (string Cookie in Cookies)
                        if (Cookie.Contains("nordicmafia")) System.IO.File.Delete(Cookie);
                }
                catch
                {
                    csPrint("      Kan ikke sikre bruk av flere bots samtidig.");
                    csPrint("      Mulige grunner: Du har Windowns Vista.");
                    csPrint("      Dette skaper nesten aldri problemer, men sier fra likevel.");
                }

                csPrint("  - Oppretter nettleser");
                IE_Images(false); wb.Navigate("about:blank");
                wb.ScriptErrorsSuppressed = true;
                Application.DoEvents(); IE_Images(true);
                if (!Directory.Exists("tmp")) Directory.CreateDirectory("tmp");
                //if (!Directory.Exists("var")) Directory.CreateDirectory("var");

                csPrint("  - Kontrollerer at bot er utpakket");
                if (FileRead("readme.prm").Replace("\r", "").Split('\n')[0]
                    != "#PRM file for Ledetekst-mafia")
                {
                    csPrint("      Det ser ut som LM ikke har blitt utpakket før bruk.");
                    csPrint("      Dette vil skape store problemer før eller senere under bruk.");
                    csPrint("      Det anbefales på det sterkeste at du avslutter og pakker ut boten.");
                    if (!bSilent) csKey();
                }

                csPrint("  - Leser argumenter");
                string arg = "";
                foreach (string ThisArg in args)
                    arg += ThisArg + " ";
                if (arg.Contains("/user ") && arg.Contains("/pass "))
                {
                    arg = arg.Substring(0, arg.Length - 1);
                    sUser = Split(Split(arg, "/user ", 1), " /", 0);
                    sPass = Split(Split(arg, "/pass ", 1), " /", 0);
                    if (arg.Contains("/krim ")) ooKrim = Convert.ToInt16(Split(Split(arg, "/krim ", 1), " /", 0));
                    else csPrint("      Argument mangler: /krim  (kriminalitet)");
                    if (arg.Contains("/press ")) ooPress = Convert.ToInt16(Split(Split(arg, "/press ", 1), " /", 0));
                    else csPrint("      Argument mangler: /press (utpressing)");
                    if (arg.Contains("/fc ")) ooFCt = Convert.ToInt16(Split(Split(arg, "/fc ", 1), " /", 0));
                    else csPrint("      Argument mangler: /fc    (fightclub trening)");
                    if (arg.Contains("/gta ")) ooGta = Convert.ToInt16(Split(Split(arg, "/gta ", 1), " /", 0));
                    else csPrint("      Argument mangler: /gta   (biltyveri)");
                    if (arg.Contains("/jail ")) ooJail = Convert.ToInt16(Split(Split(arg, "/jail ", 1), " /", 0));
                    else csPrint("      Argument mangler: /jail  (kjøpe ut av fengsel)");
                    if (arg.Contains("/bryt ")) ooBryt = Convert.ToInt16(Split(Split(arg, "/bryt ", 1), " /", 0));
                    else csPrint("      Argument mangler: /bryt  (utbrytning)");
                    if (arg.Contains("/vbryt ")) vBryt = Split(Split(arg, "/vbryt ", 1), " /", 0);
                    else csPrint("      Argument mangler: /vbryt (utbrytning mål)");
                    if (arg.Contains("/silent")) bSilent = true;
                    if (arg.Contains("/autoloc")) bAutoLoc = true;
                }
                else
                {
                    csPrint(""); csPrint("  ! Kritisk feil:");
                    csPrint("      Argumenter for brukernavn og passord mangler.");
                    if (csBool("      Ønsker du å fikse problemet"))
                    {
                        Console.Clear();
                        csPrint("");
                        csPrint(GenLine("--= Praetox Launcher Generator =--", 80, 3));
                        csPrint("");
                        csPrint("  Dersom du har brukt Launcher Generator før, vil den nye konfigurasjonen");
                        csPrint("  appenderes til den eksisterende launcher filen.");
                        csPrint("");
                        sUser = csString("   (str) Brukernavn   ");
                        sPass = csString("   (str) Passord      ");
                        try
                        {
                            ooKrim = Convert.ToInt16(csChar("   (int) Kriminalitet ").ToString()); csPrint("");
                            ooGta = Convert.ToInt16(csChar("   (int) Biltyveri    ").ToString()); csPrint("");
                            ooPress = Convert.ToInt16(csBool("  (bool) Utpressing  ")); csPrint("");
                            ooFCt = Convert.ToInt16(csBool("  (bool) FC trening  ")); csPrint("");
                            ooJail = Convert.ToInt16(csBool("  (bool) Kjøp ut     ")); csPrint("");
                            ooBryt = Convert.ToInt16(csBool("  (bool) Utbryter    ")); csPrint("");
                            if (ooBryt == 1)
                            {
                                bool Topmost = csBool("  (bool) Bryt ut øverste person"); csPrint("");
                                if (!Topmost)
                                    vBryt = csString("   (str) Utbryter mål ");
                            }
                            bSilent = !csBool("  (bool) Advarsler   "); csPrint("");
                            bAutoLoc = csBool("  (bool) Autoplasser "); csPrint("");
                        }
                        catch
                        {
                            csPrint("");
                            csPrint("  Verdier av typen int skal kun bestå av tall.");
                            csKey(); return;
                        }
                        string StartArgs =
                            "/user " + sUser + " " +
                            "/pass " + sPass + " " +
                            "/krim " + ooKrim + " " +
                            "/press " + ooPress + " " +
                            "/gta " + ooGta + " " +
                            "/fc " + ooFCt + " " +
                            "/jail " + ooJail + " " +
                            "/bryt " + ooBryt + " " +
                            "/vbryt " + vBryt + " ";
                        if (bSilent) StartArgs += "/silent ";
                        if (bAutoLoc) StartArgs += "/autoloc ";
                        if (File.Exists("Launcher.bat"))
                        {
                            if (FileRead("Launcher.bat").ToLower().Contains("/user " + sUser.ToLower() + " "))
                            {
                                csDraw(new string[] {
                                    "$3Hva er det du gjør?!", "",
                                    "$3Les bruksanvisningen!", "", "", "", "",
                                    "$3Trykk en knapp for å fortsette."});
                                csKey(); Process.Start("http://www.praetox.com/guide_lm.html");
                                pKillMe(); return;
                            }
                        }
                        FileWrite("Launcher.bat", "START ToxLM.exe " + StartArgs + "\r\n", true);
                        csPrint("");
                        csPrint("  Benytt Launcher for å starte LM fra nå av.");
                        if (csBool("  Start LM med valgte innstillinger"))
                        {
                            System.Diagnostics.Process LMProc = new System.Diagnostics.Process();
                            LMProc.StartInfo.FileName = "ToxLM.exe";
                            LMProc.StartInfo.Arguments = StartArgs;
                            LMProc.Start();
                        }
                    }
                    return;
                }

                if (bAutoLoc)
                {
                    csPrint("  - Finner plassering");
                    Process[] procs = Process.GetProcessesByName(myProcName);
                    FormPos.RECT[] FrmPos = new FormPos.RECT[procs.GetUpperBound(0) + 1];
                    FormPos.GetWindowRect(myHwnd, ref FrmPos[0]);
                    System.Drawing.Point FrmSize = new System.Drawing.Point(FrmPos[0].X2 - FrmPos[0].X1,
                                                                            FrmPos[0].Y2 - FrmPos[0].Y1);
                    int FrmPosXM = 0, FrmPosYM = 0;
                    for (int a = 0; a <= procs.GetUpperBound(0); a++)
                    {
                        FormPos.GetWindowRect(procs[a].MainWindowHandle, ref FrmPos[a]);
                        if (procs[a].MainWindowHandle != myHwnd)
                            if (FrmPos[a].Y1 > FrmPosYM &&
                                ((double)FrmPos[a].Y1 / (double)FrmSize.Y == FrmPos[a].Y1 / FrmSize.Y))
                                FrmPosYM = FrmPos[a].Y1;
                        //csPrint("Y" + a + ": " + ((double)FrmPos[a].Y2 / (double)FrmSize.Y));
                    }
                    for (int a = 0; a <= procs.GetUpperBound(0); a++)
                    {
                        if (procs[a].MainWindowHandle != myHwnd)
                            if (FrmPos[a].Y1 == FrmPosYM)
                                if (FrmPos[a].X2 > FrmPosXM &&
                                    ((double)FrmPos[a].X1 / (double)FrmSize.X == FrmPos[a].X1 / FrmSize.X))
                                    FrmPosXM = FrmPos[a].X2;
                        //csPrint("X" + a + ": " + ((double)FrmPos[a].X2 / (double)FrmSize.X));
                    }
                    if (FrmPosXM + FrmSize.X > Screen.PrimaryScreen.Bounds.Width)
                    {
                        FrmPosYM += FrmSize.Y; FrmPosXM = 0;
                    }
                    FormPos.SetWindowPos(Process.GetCurrentProcess().MainWindowHandle, 0, FrmPosXM, FrmPosYM, 0, 0, FormPos.SWP_NOSIZE);
                    //csBool("Done");
                }

                string sUData = sUser.ToLower();
                sUData = sUData.Replace("æ", "(ae)").Replace("ø", "(oo)").Replace("å", "(aa)");
                sUData = "" + new Crc32().S(sUData);

                csPrint("  - Ser etter oppdateringer");
                try
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    string vRaw = wc.DownloadString(
                        sBotdomain + "version.php?id=" + sUData + "&cv=" + Application.ProductVersion);
                    vRaw = vRaw.Replace("\r", "");
                    if (!vRaw.Contains("<VERSION>" + Application.ProductVersion + "</VERSION>"))
                    {
                        bool GetUpd = csBool("      Ny versjon tilgjengelig. Last ned"); csPrint("");
                        if (GetUpd)
                        {
                            try
                            {
                                string Link = wc.DownloadString(sToxdomain + "inf/LM_link.html").Split('%')[1];
                                Link += "?id=" + sUData + "&cv=" + Application.ProductVersion;
                                System.Diagnostics.Process.Start(Link); return;
                            }
                            catch
                            {
                                csPrint("      Whoops... Hoved-domene er utilgjengelig.");
                            }
                        }
                    }
                    if (vRaw.Contains("<NEWS>"))
                    {
                        string[] saNews = Split(Split(vRaw, "<NEWS>\n", 1), "\n</NEWS>", 0).Split('\n');
                        int ths = 0; for (ths = 0; ths <= saNews.GetUpperBound(0); ths++)
                        {
                            if (ths > 7) break; DeskMsg[ths] = saNews[ths];
                        }
                        while (ths <= 7)
                        {
                            DeskMsg[ths] = ""; ths++;
                        }
                    }
                }
                catch
                {
                    for (int ths = 0; ths <= 7; ths++)
                        DeskMsg[ths] = "";
                    DeskMsg[4] = "Kunne ikke hente nyheter.";
                    csPrint("      Kunne ikke sjekke etter oppdateringer");
                    if (!bSilent) csKey();
                }

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Clear(); Console.Write(Splash.
                    Replace("1", Convert.ToString((char)9617)).
                    Replace("2", Convert.ToString((char)9618)).
                    Replace("3", Convert.ToString((char)9619)).
                    Replace("4", Convert.ToString((char)9616)));
                Splash = ""; long SplashT1 = Tick();

                wb.Navigate("about:<form method=\"post\" action=\"" + sGamedomain + "nordic/index.php?side=loggut\"><input type=\"submit\" value=\"Logg ut!\" name=\"subloggut\"><input type=\"hidden\" name=\"luz\">");
                w8(); wb.Document.GetElementById("subloggut").InvokeMember("click"); w8();
                ttGlobal = T2A(ooGlobal);

                /*Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                Reg_DoesExist("Software\\Praetox Technologies\\Ledetekst-mafia");
                key = key.OpenSubKey("Software\\Praetox Technologies\\Ledetekst-mafia", true);
                string LastMMCityDate = ""; long LastMMCityTime = 0;
                try
                {
                    LastMMCityDate = key.GetValue("Last MMCity date").ToString();
                    LastMMCityTime = Convert.ToInt32(key.GetValue("Last MMCity time"));
                }
                catch { }
                if ((LastMMCityDate != System.DateTime.Now.ToLongDateString()) ||
                    ((LastMMCityDate == System.DateTime.Now.ToLongDateString()) &&
                    (LastMMCityTime + 10800 <= sTick())))
                {
                    key.SetValue("Last MMCity date", System.DateTime.Now.ToLongDateString());
                    key.SetValue("Last MMCity time", sTick());
                    wb.Navigate(sNav(sBotdomain + "mmcity.txt")); w8();
                }
                key.Close();*/

                Timer tKillIfClones = new Timer();
                tKillIfClones.Tick += new EventHandler(tKillIfClones_Tick);
                tKillIfClones.Interval = 10000;
                tKillIfClones.Start();

                Timer tKillTempFiles = new Timer();
                tKillTempFiles.Tick += new EventHandler(tKillTempFiles_Tick);
                tKillTempFiles.Interval = 300000;
                tKillTempFiles.Start();

                ttKrim = T2A(0); ttPress = T2A(0); ttGta = T2A(0);
                ttFCt = T2A(0); ttJail = T2A(0); iRedraw = 100;
                if (Tick() - SplashT1 < 2000)
                    System.Threading.Thread.Sleep(2000 - (int)(Tick() - SplashT1));
                Console.Title = "LM | " + sUser + " | " + sTick(); csWipeInstr();
                while (true)
                {
                    if (GKHook.GetAsyncKeyState(Keys.LShiftKey) != 0 && GKHook.GetAsyncKeyState(Keys.Scroll) == -32767)
                        FormPos.SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
                    if (FormPos.GetForegroundWindow() == myHwnd)
                    {
                        if (GKHook.GetAsyncKeyState(Keys.M) != 0)
                        {
                            NordicmafiaControl(); csDraw();
                        }
                        if (GKHook.GetAsyncKeyState(Keys.F12) != 0)
                        {
                            DebugMenu(); csDraw();
                        }
                    }
                    if (iRedraw >= 10) { csDraw(); iRedraw = 0; } iRedraw++;
                    System.Threading.Thread.Sleep(200); Application.DoEvents();
                    if (T2B(ttJail) == 0)
                    {
                        ttJail = T2A((-2) - t2aDelay);
                        if (T2B(ttJail) == 0 && T2B(ttKrim) == 0 && ooKrim != 0) funcKrim();
                        else if (T2B(ttJail) == 0 && T2B(ttPress) == 0 && ooPress != 0) funcPress();
                        else if (T2B(ttJail) == 0 && T2B(ttFCt) == 0 && ooFCt != 0) funcFCt();
                        else if (T2B(ttJail) == 0 && T2B(ttGta) == 0 && ooGta != 0) funcGTA();
                        else if (T2B(ttJail) == 0 && ooBryt != 0) funcBryt();
                    }
                    else
                    {
                        lg("Sitter i fengsel");
                        string tmp = Convert.ToString(T2B(ttJail));
                        if (tmp.Substring(tmp.Length - 1) == "0")
                        {
                            long JailT1 = Tick();
                            PollFengsel("", true, false);
                            if (Tick() - JailT1 < 850) System.Threading.Thread.Sleep(850);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex); Main(args); return;
            }
        }

        static void tKillTempFiles_Tick(object sender, EventArgs e)
        {
            ifunc_KillTemp();
        }
        static void tKillIfClones_Tick(object sender, EventArgs e)
        {
            if (sONick == "Praetox Technologies") return;
            Process[] LMProcs = Process.GetProcessesByName(
                Process.GetCurrentProcess().ProcessName);
            for (int a = 0; a < LMProcs.Length; a++)
            {
                if (LMProcs[a].MainWindowHandle != myHwnd)
                {
                    string[] MWParams = aSplit(LMProcs[a].MainWindowTitle, " | ");
                    if (MWParams[0] == "LM" && sONick==MWParams[MWParams.Length-2])
                    {
                        Errlog("LM startet flere ganger med samme bruker. Rydd opp i Launcher.bat!");
                        Application.DoEvents(); pKillMe();
                    }
                }
            }
        }

        static void funcKrim()
        {
            try
            {
                lg("Utfører kriminalitet");
                int iOpt = Convert.ToInt32(ooKrim); if (iOpt < 1) iOpt = 1;
                string target = "bank";
                switch (iOpt)
                {
                    case 1: target = "bank"; break;
                    case 2: target = "bensin"; break;
                    case 3: target = "automat"; break;
                    case 4: target = "lomme"; break;
                }
                GCD_Wait();
                string src = sNav(sGamedomain + "nordic/index.php?side=krim",
                    "valg=" + target + "&bekreftkrimsubmit=Utf%F8r%21");
                if (Antibot(src, "krim")) { funcKrim(); return; }
                if (PollFengsel(src)) return;
                if (src.Contains("handling, du må vente")) { ttKrim = T2A(GetTell(src)); return; }
                if (src.Contains("nt\">\n Vellykket! ") || src.Contains("nt\">\n Mislykket! "))
                {
                    st_cKrim++; if (src.Contains("nt\">\n Vellykket! ")) st_fKrim++;
                    PrintReport(); ttKrim = T2A(180); lg("Utførte kriminalitet"); return;
                }
                else
                {
                    ttKrim = T2A(1 - t2aDelay);
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        static void funcPress()
        {
            try
            {
                lg("Utfører utpressing");
                GCD_Wait();
                string src = sNav(sGamedomain + "nordic/index.php?side=utpressing", "subpress=Utf%F8r%21");
                if (PollFengsel(src)) return;
                if (src.Contains("nt\">\n <b>Mislykket! ") || src.Contains("nt\">\n <b>Vellykket! "))
                {
                    Program.st_cPress++; if (WPC("nt\">\n <b>Vellykket! ")) Program.st_fPress++;
                    PrintReport(); ttPress = T2A(960); lg("Utførte utpressing"); return;
                }
                else
                {
                    ttPress = T2A(10 - t2aDelay);
                    lg("Utsetter utpressig");
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        static void funcGTA()
        {
            try
            {
                lg("Utfører biltyveri");
                int iOpt = Convert.ToInt32(ooGta); if (iOpt < 1) iOpt = 1; iOpt = 5 - iOpt;
                GCD_Wait();
                string src = sNav(sGamedomain + "nordic/index.php?side=gta",
                    "gtanr=" + iOpt + "&stjelsubmit=Stjel");
                if (Antibot(src, "gta")) { funcGTA(); return; }
                if (PollFengsel(src)) return;
                iOpt = -1; Antibot(src, "gta");
                if (src.Contains("nt\">\n Du fikk ingenting")) iOpt = 1;
                if (src.Contains("biltyveri, du må vente <span id=tell>")) iOpt = 2;
                if (src.Contains("content=\"0;url=index.php?side=fengsel\">")) iOpt = 3;
                if (src.Contains("nt\">\n Du stjal en <b>")) iOpt = 4;
                if (src.Contains("nt\">\n Du stjæler en <b>")) iOpt = 4;
                if (iOpt != 2 && iOpt != 3) Program.st_cGta++;
                switch (iOpt)
                {
                    case 1:
                        ttGta = T2A(360); lg("Utførte biltyveri"); return;
                    case 2:
                        ttGta = T2A(GetTell(src)); return;
                    case 3:
                        PollFengsel("", true, true); return;
                    case 4:
                        Program.st_fGta++; PrintReport();
                        ttGta = T2A(360); lg("Fikk bil"); funcGTAs(1); return;
                }
                //MessageBox.Show("Event: " + iOpt);
                //if (iOpt == -1) cmd_Click(new object(), new EventArgs());
                //this.Text = "Event: " + iOpt;
                PollFengsel("", true, true); return;
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        static void funcGTAs(int IterationCount)
        {
            if (IterationCount > 5)
            {
                Errlog("Kunne ikke sende bil (5 forsøk failet)");
                return;
            }
            try
            {
                lg("Sender bil (forsøk " + IterationCount + ")");
                string src = sNav(sGamedomain + "nordic/index.php?side=gta");
                if (Antibot(src, "gta")) { funcGTAs(IterationCount + 1); return; }
                if (src.Contains("name=\"subtrans\""))
                {
                    string sCarID = Split(Split(src, "<a onmousedown=\"carvin(", 1), ")", 0);
                    string sTTown = Split(Split(src, "<OPTION value=\"", 1), "\">", 0);
                    if (src.Contains("<OPTION value=\"Helsinki\">")) sTTown = "Helsinki";
                    GCD_Wait();
                    src = sNav(sGamedomain + "nordic/index.php?side=gta",
                        "trainid=" + sCarID + "&" +
                        "trainto=" + sTTown + "&" +
                        "subtrans=Transporter%21");
                    if (!src.Contains("\n Bilen flyttes nå til ") &&
                        Convert.ToUInt64(ssCash.Replace(",", "")) > (UInt64)10000)
                    {
                        funcGTAs(IterationCount + 1); return;
                    }
                    lg("Bil sendt");
                }
                else
                {
                    funcGTAs(IterationCount + 1); return;
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        static void funcFCt()
        {
            try
            {
                lg("Utfører fightclub");
                GCD_Wait();
                string src = sNav(sGamedomain + "nordic/index.php?side=fightclub",
                    "aktivitetvalg=1&subtrennaa=Utf%F8r%21");
                if (Antibot(src, "fightclub")) { funcFCt(); return; }
                if (PollFengsel(src)) return;
                if (src.Contains("nt\">\n Du tok 25 Pushups. "))
                {
                    Program.st_cFCt++; PrintReport();
                    ttFCt = T2A(120); lg("Utførte fightclub"); return;
                }
                else
                {
                    ttFCt = T2A(5 - t2aDelay);
                    lg("Utsetter fightclub");
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        static void funcBryt()
        {
            try
            {
                bool rsm = true; string src = "";
                if (ooBryt == 1 || Program.vBryt == "")
                {
                    src = sNav(sGamedomain + "nordic/index.php?side=fengsel");
                    if (Antibot(src, "fengsel")) return;
                    if (!WPC("\">Bryt Ut!</a>")) rsm = false;
                }
                if (rsm)
                {
                    Program.st_cBryt++; lg("Utfører utbrytning");
                    string BrytUtLink = "index.php?side=fengsel&bryt=" + Program.vBryt;
                    if (src.Contains("index.php?side=fengsel&jbryt=\""))
                    {
                        BrytUtLink = "index.php?side=fengsel&jbryt=\"" +
                        Split(Split(src, "index.php?side=fengsel&jbryt=\"", 1), "\">", 0);
                    }
                    else
                    {
                        if (ooBryt == 1 || Program.vBryt == "")
                        {
                            BrytUtLink = Split(Split(src, ">Bryt Ut<", 1), "td  align='left'", 0);
                            BrytUtLink = Split(Split(BrytUtLink, "<td><a href=\"", 2), "\">", 0);
                            BrytUtLink = BrytUtLink.Replace("&amp;", "&");
                        }
                    }
                    GCD_Wait();
                    src = sNav(sGamedomain + "nordic/" + BrytUtLink); Antibot(src, "fengsel");
                    if (src.Contains("2><b>Du ble tatt mens du skulle bryte en ut,<br>"))
                    {
                        src = sNav(sGamedomain + "nordic/index.php?side=fengsel"); Antibot(src, "fengsel");
                        if (src.Contains("center\">Du sitter i fengsel!</td>")) ttJail = T2A(GetTell(src));
                        PrintReport(); lg("Utførte utbrytning - failet");
                    }
                    if (src.Contains("nt\">\n Du brøt ut <b>"))
                    {
                        st_vBryt += Split(BrytUtLink, "fengsel&bryt=", 1) + "\r\n";
                        st_fBryt++; PrintReport(); lg("Utførte utbrytning - suksess");
                    }
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex);
            }
        }
        static bool PollFengsel(string pSrc, bool FullCheck, bool MeasureTime)
        {
            try
            {
                string src = pSrc;
                if (FullCheck)
                {
                    src = sNav(sGamedomain + "nordic/index.php?side=krim");
                    if (!src.Contains("name=\"bekreftkrimsubmit\"") &&
                        !src.Contains("en kriminell handling, du må vente") &&
                        !src.Contains("center\">Kriminalitet løser ingenting...<br>"))
                        return PollFengsel(pSrc);
                }
                {
                    if (!src.Contains("center\">Kriminalitet løser ingenting...<br>"))
                    {
                        ttJail = T2A(-2); return false;
                    }
                    else
                    {
                        if (!MeasureTime) return true;
                        if (ooJail == 1)
                        {
                            GCD_Wait();
                            sNav(sGamedomain + "nordic/index.php?side=fengsel", "subbestikk=Kj%F8p+deg+ut%21");
                            return false;
                        }
                        else
                        {
                            string cSrc = sNav(sGamedomain + "nordic/index.php?side=fengsel");
                            if (cSrc.Contains("center\">Du sitter i fengsel!</td>") ||
                                cSrc.Contains("center\">Du sidder i fængsel!</td>"))
                                ttJail = T2A(GetTell(cSrc));
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CritErrlog(ex); return false;
            }
        }
        static bool PollFengsel(string pSrc)
        {
            return PollFengsel(pSrc, false, true);
        }
        static int GetTell(string pSrc)
        {
            try
            {
                if (!pSrc.Contains("<span id=tell>")) return -1;
                string str = Split(Split(pSrc, "<span id=tell>", 1), "</span>", 0);
                return Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                CritErrlog(ex); return 0;
            }
        }
        static void PrintReport()
        {
            return;
        }
        static bool Antibot(string pSrc, string NmFunc)
        {
            try
            {
                if (pSrc.Contains(" velg tre bilder som inneholder ") ||
                    pSrc.Contains(" vælg tre billeder som indeholder "))
                {
                    lg("Laster antibot");
                    string src = pSrc; sAntibot = ""; sAbSession = ""; sAbPrefix = "";
                    sAbSession = Split(Split(pSrc, "genbilde.php?id=0&", 1), "\"", 0);
                    sAbPrefix = "abimg_" + MD5(sUser).Substring(0, 8) + "_" + sAbSession + "_";
                    bAbCompleted = false; bAbEnded = false;

                    while (!bAbCompleted)
                    {
                        bool bGetAntibotImages = true;
                        while (bGetAntibotImages)
                        {
                            lg("Laster ned antibot...");
                            ifunc_DownloadAntibot();
                            lg("Bilder verifiseres...");
                            if (ifunc_NullCheckAntibotImages())
                            {
                                lg("Kunne ikke hente antibot-bilder");
                                Errlog("Kunne ikke hente antibot-bilder!");
                                return true;
                            }
                            bGetAntibotImages = !ifunc_VerifyAntibotImages();
                        }

                        lg("Venter på inntasting");
                        IntPtr FocusedWnd = FormPos.GetForegroundWindow();
                        System.Windows.Forms.Form fAB = new frmAntibot();
                        fAB.Show(); Application.DoEvents();
                        bAbCompleted = false; bAbEnded = false;
                        MP3 mFile = new MP3(); if (File.Exists("ab.mp3")) { mFile.Open("ab.mp3"); mFile.Play(true); }
                        while (!bAbEnded)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(100);
                        }
                        fAB.Dispose(); Application.DoEvents();
                        FormPos.SetForegroundWindow(FocusedWnd);
                        mFile.Close();
                    }

                    lg("Sender antibot");
                    int[] AbPicIDs = new int[3];
                    for (int a = 0; a <= 2; a++)
                        AbPicIDs[a] = Convert.ToInt16(sAntibot.Substring(a, 1));
                    src = sNav(sGamedomain + "nordic/index.php?side=" + NmFunc,
                        "bilde%5B" + AbPicIDs[0] + "%5D=" + AbPicIDs[0] + "&" +
                        "bilde%5B" + AbPicIDs[1] + "%5D=" + AbPicIDs[1] + "&" +
                        "bilde%5B" + AbPicIDs[2] + "%5D=" + AbPicIDs[2] + "&" +
                        "antibot_valider=Fullf%F8r");
                    if (Login(src))
                    {
                        lg("Alle elsker kicks");
                        src = sNav(sGamedomain + "nordic/index.php?side=" + NmFunc);
                        Antibot(src, NmFunc); return true;
                    }
                    if (WPC("Mislykket! Prøv igjen."))
                    {
                        lg("Feil antibot-kode");
                        src = sNav(sGamedomain + "nordic/index.php?side=" + NmFunc,
                            "nye_bilder=Nye+bilder");
                        Antibot(src, NmFunc); return true;
                    }
                    lg("Antibot fullført");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                CritErrlog(ex); return false;
            }
        }

        public static void ifunc_DownloadAntibot()
        {
            WebReq[] abDL = new WebReq[9];
            for (int a = 0; a <= 8; a++)
            {
                abDL[a] = new WebReq(); abDL[a].SetTimeout(sckTimeout);
                abDL[a].Request(sGamedomain +
                    "nordic/hget_genbilde.php?id=" + a + "&" + sAbSession,
                    SESSID, "", "tmp/" + sAbPrefix + a + ".jpg", false);
            }
            while (true)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                bool AbDLsDone = true;
                for (int a = 0; a <= 8; a++)
                {
                    if (!abDL[a].isReady) AbDLsDone = false;
                }
                if (AbDLsDone) break;
            }
        }
        public static bool ifunc_VerifyAntibotImages()
        {
            bool ret = true;
            for (int a = 0; a <= 8; a++)
            {
                bool bRedoImage = true;
                PictureBox pbTester = new PictureBox();
                try
                {
                    pbTester.BackgroundImage = new System.Drawing.Bitmap(
                        "tmp/" + sAbPrefix + a + ".jpg") as System.Drawing.Image;
                    bRedoImage = false;
                }
                catch { }
                if (bRedoImage) ret = false;
                pbTester.Dispose();
            }
            return ret;
        }
        public static bool ifunc_NullCheckAntibotImages()
        {
            bool ret = true;
            for (int a = 0; a <= 8; a++)
            {
                System.IO.FileStream fs = new System.IO.FileStream
                    ("tmp/" + sAbPrefix + a + ".jpg", FileMode.Open);
                if (fs.Length > 128) ret = false;
                fs.Close(); fs.Dispose();
            }
            return ret;
        }
    }
}