using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nmStats
{
    public partial class frmMain : Form
    {
        private static bool FirstLaunch = false;
        private static string isOnline = "\r\n";
        private static string fullList = "\r\n";
        private static int Timeout = 10000;
        public frmMain()
        {
            InitializeComponent();
        }

        #region Standard Praetox functions
        ///<summary>
        /// Splits msg by delim, returns bit part
        ///</summary>
        public static string Split(string msg, string delim, int part)
        {
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
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        ///<summary>
        /// Counts occurrences of delim within msg
        ///</summary>
        public static int Countword(string msg, string delim)
        {
            int ret = 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
            }
            return ret;
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
        public int tck()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        ///<summary>
        /// Returns system clock in miliseconds
        ///</summary>
        public long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        ///<summary>
        /// Returns hh:mm:ss of vl (seconds)
        ///</summary>
        public string s2ms(int vl)
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
        /// <summary>
        /// This function returns false and makes regkey if not exist.
        /// </summary>
        private bool Reg_DoesExist(string regPath)
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
        public string TDNow()
        {
            return System.DateTime.Now.ToLongDateString() + " .::. " +
                   System.DateTime.Now.ToLongTimeString();
        }
        ///<summary>
        /// Returns MD5 of vl
        ///</summary>
        public string MD5(string vl)
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
        /// <summary>
        /// The form's load code
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (FirstLaunch) return;
            IE_Images(false); Application.DoEvents();
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate("about:Blank"); Application.DoEvents();
            IE_Images(true);
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
            Application.DoEvents(); long t = tck();
            while (!wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if ((iTimeout != 0) && (tck() > t + iTimeout)) break;
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
        ///<summary>
        /// Checks if you are logged in, logs in and returns true if necessary
        ///</summary>
        public bool Login()
        {
            bool ret = false;
            if (WPC("Du er ikke logget inn!") || WPC("Du ble logget inn fra et annet sted.") ||
                WPC("Du er ikke logged ind!"))
            {
                lg("Logging in...");
                wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser.Text);
                wb.Document.GetElementById("passoord").SetAttribute("value", sPass.Text);
                wb.Document.GetElementById("submit").InvokeMember("click"); w8();
                lg("Logged in.");
                ret = true;
            }
            return ret;
        }
        ///<summary>
        /// Displays status message vl
        ///</summary>
        public void lg(string vl)
        {
            //string TimeNow = System.DateTime.Now.ToLongTimeString();
            Status.Text = vl; Application.DoEvents();
        }
        #endregion
        #region new Standard Praetox functions
        public string FileRead(string sFile)
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
        public void FileWrite(string sFile, string sVal)
        {
            System.IO.FileStream fs = new System.IO.FileStream(sFile, System.IO.FileMode.Create);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"));
            sw.Write(sVal); sw.Close(); sw.Dispose();
        }
        public string[] SortStringArrayAlphabetically(string[] vl)
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
        public string DatecharsToDatenums(string vl)
        {
            vl = vl.Replace(". January ", "/01/");
            vl = vl.Replace(". February ", "/02/");
            vl = vl.Replace(". March ", "/03/");
            vl = vl.Replace(". April ", "/04/");
            vl = vl.Replace(". May ", "/05/");
            vl = vl.Replace(". June ", "/06/");
            vl = vl.Replace(". July ", "/07/");
            vl = vl.Replace(". August ", "/08/");
            vl = vl.Replace(". September ", "/09/");
            vl = vl.Replace(". October ", "/10/");
            vl = vl.Replace(". November ", "/11/");
            vl = vl.Replace(". December ", "/12/");
            return vl;
        }
        #endregion

        /// <summary>
        /// Converts a rank-char into short-rank
        /// </summary>
        public string RankCharToShortRank(string tRank)
        {
            if (tRank == "A") tRank = "Capo Don";
            if (tRank == "B") tRank = "Don";
            if (tRank == "C") tRank = "L.Gudfar";
            if (tRank == "D") tRank = "Gudfar";
            if (tRank == "E") tRank = "Boss";
            if (tRank == "F") tRank = "Kaptein";
            if (tRank == "G") tRank = "Assassin";
            if (tRank == "H") tRank = "Hitman";
            if (tRank == "I") tRank = "Gangster";
            if (tRank == "J") tRank = "Bråkmaker";
            if (tRank == "K") tRank = "Wannabe";
            if (tRank == "L") tRank = "Sivilist";
            return tRank;
        }

        /// <summary>
        /// Returns a list of all online players
        /// </summary>
        public string GetOnline(string Exclude)
        {
            long CurUser = 0; string ret = ""; Exclude = "\r\n" + unNewline(Exclude) + "\r\n";
            while (true)
            {
                Nav("http://www.nordicmafia.net/nordic/index.php?side=online&start=" + CurUser);
                long vl2 = Convert.ToInt32(Split(Split(wSRC(), "Viser <B>", 1), " spillere", 0));
                string CharsTmp = Split(Split(wSRC(), " spillere</B></P></DIV><BR>", 1), "<TABLE ", 0);
                string[] Chars = aSplit(CharsTmp, "\">"); long CharsUBound = Chars.GetUpperBound(0); //Countword(CharsTmp, "\">");
                for (int a = 1; a <= CharsUBound; a++)
                {
                    lg("Caching " + a + " / " + CharsUBound + "...");
                    Chars[a] = Split(Chars[a], "</A>", 0);
                    if (Exclude.IndexOf("\r\n" + Chars[a] + "\r\n")==-1)
                        ret += Chars[a] + "\r\n";
                }
                CurUser += 600; if (CharsUBound < 600) break;
            }
            if (ret.Length>=2)
                if (ret.Substring(ret.Length - 2) == "\r\n") ret = ret.Substring(0, ret.Length - 2);
            return ret;
        }
        /// <summary>
        /// Reads the ranks of submitted players
        /// </summary>
        /// <param name="sUsers">Players to check</param>
        private string GetRanks(string sUsers, string KnownStats, bool FullRefresh)
        {
            string ret = "\r\n";
            if (sUsers == "") return ""; if (sUsers.Substring(sUsers.Length - 2) != "\r\n") sUsers += "\r\n";
            string[] Users = aSplit(sUsers, "\r\n"); int UsersUBound = Users.GetUpperBound(0); //Countword(sUsers, "\r\n");
            if ((KnownStats != "") && (KnownStats != "\r\n")) KnownStats = "\r\n" + unNewline(KnownStats) + "\r\n";
            if ((KnownStats == "") || (FullRefresh)) KnownStats = "\r\n";
            int Time0 = tck();
            string isDead = "";
            for (int a = 0; a < UsersUBound; a++)
            {
                if (KnownStats.IndexOf("\r\n|" + Users[a] + "|") == -1)
                {
                    lg("Reading user " + a + " / " + UsersUBound + "  -  " +
                        (int)(((double)100 / (double)UsersUBound) * (double)a) + "%  -  done in " +
                        s2ms(((int)((double)((double)(tck() - Time0) / (double)a) * (double)(UsersUBound - a)))));
                    if (Users[a].IndexOf(" | ") != -1) Users[a] = Users[a].Substring(Users[a].IndexOf(" | ") + 3);
                    Nav("http://www.nordicmafia.net/nordic/index.php?side=bruker&brukernavn=" +
                        Users[a].Replace(" ", "+"), "><B>· Fri Tekst</B></FONT><"); string WCRet = wSRC();
                    //MessageBox.Show(Users[a] + "\r\n\r\n" + wSRC());
                    //FileWrite("dump.txt", WCRet); Application.Exit();
                    if (WCRet.IndexOf("size=1><B>Pengestatus:</B></FONT></TD>") != -1)
                    {
                        string chGjeng = Split(Split(Split(wSRC(),
                            "size=1><B>Gjeng:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                        if (chGjeng != "Ingen") chGjeng = Split(Split(chGjeng, "\">", 1), "</A>", 0);
                        string chStatus = Split(Split(Split(wSRC(), 
                            "size=1><B>Status:</B></FONT><", 1), " size=1>", 1), " (", 0);
                        string chRank = Split(Split(Split(wSRC(),
                            "size=1><B>Rank:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                        string chPenger = Split(Split(Split(wSRC(), 
                            "size=1><B>Pengestatus:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                        string chDrap = Split(Split(Split(wSRC(), 
                            "size=1><B>Antall drap:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                        string chCDG = Split(Split(Split(wSRC(),
                            "size=1><B>Club de gangster:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                        string chMelds = Split(Split(Split(wSRC(),
                            "size=1><B>Meld. sendt:</B></FONT><", 1), " size=1>", 1), "<BR><BR></FON", 0);
                        string chNavn = Split(Split(Split(wSRC(), 
                            "size=1><B>Navn:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                        string chJoin = DatecharsToDatenums(Split(Split(Split(wSRC(), 
                            "size=1><B>Ble medlem:</B></FONT><", 1), " size=1>", 1), "<BR><BR></FON", 0));
                        string chSiste = DatecharsToDatenums(Split(Split(Split(wSRC(), 
                            "size=1><B>Siste besøk:</B></FONT><", 1), " size=1>", 1), "</FON", 0));

                        if (WPC("<EMBED src="))
                        {
                            string sEmbed = Split(Split(wSRC(), "<EMBED src=", 1), " width=2 ", 0);
                            if (sEmbed != "http://") tEmbeds.Text += sEmbed + "\r\n";
                        }

                        if (chRank == "Sivilist")           chRank = "L";
                        if (chRank == "Wannabe")            chRank = "K";
                        if (chRank == "Bråkmaker")          chRank = "J";
                        if (chRank == "Gangster")           chRank = "I";
                        if (chRank == "Hitman")             chRank = "H";
                        if (chRank == "Assassin")           chRank = "G";
                        if (chRank == "Kaptein")            chRank = "F";
                        if (chRank == "Boss")               chRank = "E";
                        if (chRank == "Gudfar")             chRank = "D";
                        if (chRank == "Legendarisk Gudfar") chRank = "C";
                        if (chRank == "Don")                chRank = "B";
                        if (chRank == "Capo Don")           chRank = "A";

                        if (chStatus == "Levende")
                        {
                            ret += "|" + Users[a] + "|" +
                                chGjeng + "|" +
                                //chStatus + "|" +
                                chRank + "|" +
                                //chPenger + "|" +
                                chDrap + "|" +
                                chCDG + "|" +
                                chMelds + "|" +
                                //chNavn + "|" +
                                chJoin + "|" +
                                chSiste + "|" +
                                System.DateTime.Now.ToShortDateString() + " " +
                                System.DateTime.Now.ToShortTimeString() +
                                "\r\n";
                        }
                        else
                        {
                            isDead += Users[a] + "\r\n";
                        }
                    }
                    else
                    {
                        a--;
                    }
                }
            }
            if (isDead != "") MessageBox.Show("The following are dead:\r\n\r\n" + isDead);
            if (ret == "\r\n") return "\r\n";
            return unNewline(ret); //ret.Substring(2, ret.Length - 4);
        }

        private void cmdStep1_Click(object sender, EventArgs e)
        {
            isOnline = FileRead("userdb_names.txt");
            if (isOnline != "") isOnline += "\r\n";
            txtStep1.Text = isOnline;
            isOnline += GetOnline(isOnline);
            isOnline = unNewline(isOnline);
            
            // Sort alphabetically
            string[] aisOnline = SortStringArrayAlphabetically(aSplit(isOnline, "\r\n"));
            isOnline = ""; foreach (string kek in aisOnline)
                isOnline += kek + "\r\n";
            isOnline = unNewline(isOnline);

            txtStep1.Text = isOnline;
            FileWrite("userdb_names.txt", isOnline);
            lg("Step 1 completed, proceed to step 2 or append more users.");
        }

        private void cmdStep2a_Click(object sender, EventArgs e)
        {
            //try { new System.Net.WebClient().DownloadString("http://nordic.awardspace.com/GetOnline_Step2.php"); }
            //catch { }
            isOnline = FileRead("userdb_names.txt");
            txtStep1.Text = isOnline;
            fullList = FileRead("userdb_infos.txt");
            if (fullList != "") fullList += "\r\n";
            txtStep2.Text = fullList;
            fullList += GetRanks(isOnline, fullList, false);
            txtStep2.Text = fullList;
            FileWrite("userdb_infos.txt", unNewline(fullList));
            lg("Step 3 completed, proceed to step 3 or append more users.");
        }

        private void cmdStep2b_Click(object sender, EventArgs e)
        {
            //try { new System.Net.WebClient().DownloadString("http://nordic.awardspace.com/GetOnline_Step2.php"); }
            //catch { }
            isOnline = FileRead("userdb_names.txt");
            txtStep1.Text = isOnline;
            txtStep2.Text = "";
            fullList += GetRanks(isOnline, "", false);
            txtStep2.Text = fullList;
            FileWrite("userdb_infos.txt", unNewline(fullList));
            lg("Step 3 completed, proceed to step 3 or append more users.");
        }

        private void cmdStep3_Click(object sender, EventArgs e)
        {
            lg("Reading users...");
            string UserInf = FileRead("userdb_infos.txt");
            lg("Splitting users...");
            string[] Onl = aSplit(UserInf, "\r\n");
            lg("Reading ubound...");
            int OnlUBound = Onl.GetUpperBound(0); //Countword(txtStep2.Text, "\r\n");
            lg("Sorting alphabetically...");
            Onl = SortStringArrayAlphabetically(Onl);
            lg("Sorting ranks...");
            string RankA = "", RankB = "", RankC = "", RankD = "", RankE = "", RankF = "",
                   RankG = "", RankH = "", RankI = "", RankJ = "", RankK = "", RankL = "";
            int iGang = 0; string GangHTML = "";
            for (int a = 0; a <= OnlUBound; a++)
            {
                //lg("Sorting " + a + " / " + OnlUBound);
                string[] inf = aSplit(Onl[a], "|");
                string tNick = inf[1]; string tGang = inf[2]; string tRank = inf[3];
                string tKill = inf[4]; string tCdeG = inf[5]; string tPriv = inf[6];
                string tJoin = inf[7]; string tLast = inf[8]; string tRead = inf[9];
                string val = "<td>" +
                    tNick + "</td><td>" +
                    tGang + "</td><td>" +
                    tKill + "</td><td>" +
                    tPriv + "</td><td>" +
                    //tJoin + "</td><td>" +
                    tLast + "</td><td>" +
                    tRead + "</td></tr>\r\n";
                if (tRank == "A") RankA += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "B") RankB += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "C") RankC += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "D") RankD += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "E") RankE += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "F") RankF += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "G") RankG += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "H") RankH += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "I") RankI += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "J") RankJ += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "K") RankK += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tRank == "L") RankL += "<tr><td>" + RankCharToShortRank(tRank) + "</td>" + val;
                if (tGang != "Ingen") iGang++;
            }
            string UserHTML = RankA + RankB + RankC + RankD + RankE + RankF + 
                              RankG + RankH + RankH + RankJ + RankK + RankL;
            if (iGang != 0)
            {
                lg("Listing gang members...");
                string[] GangData = new string[iGang];
                int iTGChar = -1;
                for (int a = 0; a <= OnlUBound; a++)
                {
                    if (Split(Onl[a], "|", 2) != "Ingen")
                    {
                        iTGChar++;
                        string[] inf = aSplit(Onl[a], "|");
                        string tNick = inf[1]; string tGang = inf[2]; string tRank = inf[3];
                        string tKill = inf[4]; string tCdeG = inf[5]; string tPriv = inf[6];
                        string tJoin = inf[7]; string tLast = inf[8]; string tRead = inf[9];
                        tRank = RankCharToShortRank(tRank);
                        string val = "<td>" +
                            tGang + "</td><td>" +
                            tNick + "</td><td>" +
                            tRank + "</td><td>" +
                            tKill + "</td><td>" +
                            tPriv + "</td><td>" +
                            //tJoin + "</td><td>" +
                            tLast + "</td><td>" +
                            tRead + "</td></tr>";
                        GangData[iTGChar] = val + "\r\n";
                    }
                }
                lg("Sorting gang members alphabetically...");
                GangData = SortStringArrayAlphabetically(GangData);
                lg("Forming HTML gang list...");
                for (int a = 0; a <= GangData.GetUpperBound(0); a++)
                {
                    GangHTML += GangData[a];
                }
            }
            FileWrite("nm-db.html", FileRead("design.html").Replace("<generated_content_here>",
                "	<center><h2>Nordicmafia.net brukerstatistikk</h2>\r\n" +
                "	<a href=\"#Alle\">Alle brukere</a> | <a href=\"#Gjeng\">Gjengmedlemmer</a><br>\r\n" +
                "	<font size=2 color=#446677>Last updated " +
                System.DateTime.Now.ToLongDateString() + " - " +
                System.DateTime.Now.ToLongTimeString() + "</center></font><br>\r\n" +

                "	<a name=\"Alle\"></a>\r\n" +
                "	<h2><center>Alle brukere:</center></h2>\r\n" +
                "	<table align=center border=1>\r\n" +
                "	<tr bgcolor=#88CCFF><td>Rank</td><td>Brukernavn</td><td>Gjeng</td><td>Drap</td><td>PMs</td><td>Sist pålogget</td><td>Sist oppdatert</td></tr>" +
                UserHTML +
                "	</table><br>\r\n" +

                "	<a name=\"Gjeng\"></a>\r\n" +
                "	<h2><center>Gjengmedlemmer:</center></h2>\r\n" +
                "	<table align=center border=1>\r\n" +
                "	<tr bgcolor=#88CCFF><td>Gjengnavn</td><td>Brukernavn</td><td>Rank</td><td>Drap</td><td>PMs</td><td>Sist pålogget</td><td>Sist oppdatert</td></tr>" +
                GangHTML +
                "	</table></font></body>"));
            lg("Alle operasjoner fullført!");
        }
    }
}