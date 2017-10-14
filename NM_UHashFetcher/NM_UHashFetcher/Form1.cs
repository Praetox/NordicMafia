using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NM_UHashFetcher
{
    public partial class Form1 : Form
    {
        public bool bDebug = true;

        public Form1()
        {
            InitializeComponent();
        }

        #region Standard functions
        public string Split(string msg, string delim, int part)
        {
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        public string[] aSplit(string msg, string delim)
        {
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos!=-1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    ret[spt] = msg.Substring(0, FoundPos); spt++;
                    msg = msg.Substring(FoundPos + delimLen);
                    Debug("aSplit", spt);
                }
            }
            ret[spt] = msg;
            return ret;
        }
        public int Countword(string msg, string delim)
        {
            int ret = 0; int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    msg = msg.Substring(FoundPos + delimLen); ret++;
                    Debug("Countword", ret);
                }
            }
            return ret;
        }
        public string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }
        public string unSpace(string vl)
        {
            string ret = vl;
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
        public int tck()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        public long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        public static void IE_Images(bool show)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            key = key.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main", true);
            if (show) key.SetValue("Display Inline Images", "yes");
            if (!show) key.SetValue("Display Inline Images", "no");
            key.Close();
        }
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
        private void Form1_Load(object sender, EventArgs e)
        {
            IE_Images(false); Application.DoEvents();
            this.Show(); wb.Navigate("about:blank"); Application.DoEvents();
            IE_Images(true);
        }
        public void Nav(string url, string vl)
        {
            wb.Stop(); Application.DoEvents();
            wb.Navigate("about:blank"); Application.DoEvents();
            wb.Navigate(url); Application.DoEvents();
            if (vl == "") { w8(); } else { w8u(vl); }
            if (Login()) { Nav(url, vl); }
        }
        public void Nav(string url)
        {
            Nav(url, "");
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
            wb.Stop(); Application.DoEvents();
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
                wb.Document.GetElementById("brukernavn").SetAttribute("value", tUser.Text);
                wb.Document.GetElementById("passoord").SetAttribute("value", tPass.Text);
                wb.Document.GetElementById("submit").InvokeMember("click"); w8();
                ret = true;
            }
            return ret;
        }
        public byte[] StrToByte(string str)
        {
            int x; byte[] vl = new byte[str.Length + 2];
            for (x = 0; x < str.Length; x++)
            {
                vl[x] = (byte)str[x];
            }
            vl[x] = 13; vl[x + 1] = 10;
            return vl;
        }
        /// <summary>
        /// Reads sFile, works with norwegian letters ae oo aa
        /// </summary>
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
        /// <summary>
        /// Writes sVal to sFile, works with norwegian letters ae oo aa
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="sVal"></param>
        public void FileWrite(string sFile, string sVal)
        {
            System.IO.FileStream fs = new System.IO.FileStream(sFile, System.IO.FileMode.Create);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"));
            sw.Write(sVal); sw.Close(); sw.Dispose();
        }
        /// <summary>
        /// Sorts vl[] alphabetically, ignores letters other than 0-9 a-z
        /// </summary>
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
        #endregion
        
        public void Debug(string vl, int val, string valend)
        {
            if (bDebug)
            {
                if (Convert.ToString(val).EndsWith(valend) || val == 0)
                {
                    lDebug.Text = vl + " " + val; Application.DoEvents();
                }
            }
        }
        public void Debug(string vl, int val)
        {
            Debug(vl, val, "00");
        }

        public string GetOnline()
        {
            long CurUser = 0; string ret = "";
            while (true)
            {
                Nav("http://www.nordicmafia.net/nordic/index.php?side=online&start=" + CurUser);
                //long vl1 = Convert.ToInt32(Split(Split(wSRC(), "Det er <FONT size=3><B>", 1), " spillere", 0));
                long vl2 = Convert.ToInt32(Split(Split(wSRC(), "Viser <B>", 1), " spillere", 0));
                string CharsTmp = Split(Split(wSRC(), " spillere</B></P></DIV><BR>", 1), "<TABLE ", 0);
                string[] Chars = aSplit(CharsTmp, "\">"); long CharsUBound = Countword(CharsTmp, "\">");
                for (int a = 1; a <= CharsUBound; a++)
                {
                    Debug("Reading", a);
                    Chars[a] = Split(Chars[a], "</A>", 0);
                    ret += Chars[a] + "\r\n";
                }
                CurUser += 600; if (CharsUBound < 600) break;
            }
            if (ret.Substring(ret.Length - 2) == "\r\n") ret = ret.Substring(0, ret.Length - 2);
            return ret;
        }
        private string GetHashes(string vl)
        {
            string ret = ""; vl = vl.Replace("\r", "");
            string[] Chars = vl.Split('\n'); long CharsUBound = Chars.GetUpperBound(0); // aSplit(vl, "\r\n"); Countword(vl, "\r\n");
            for (int a = 0; a <= CharsUBound; a++)
            {
                Debug("Hashing", a);
                Chars[a] = Chars[a].ToLower();
                Chars[a] = Chars[a].Replace("æ", "(ae)").Replace("ø", "(oo)").Replace("å", "(aa)");
                if (ret.Contains(new Crc32().S(Chars[a])))
                    MessageBox.Show("Hash " + new Crc32().S(Chars[a]) + " for ''" + Chars[a] + "'' exists!");
                ret += new Crc32().S(Chars[a]) + " | " + Chars[a] + "\r\n";
            }
            if (ret.Substring(ret.Length - 2) == "\r\n") ret = ret.Substring(0, ret.Length - 2);
            return ret;
        }
        private string DecryptHashes(string sHashes, string sBotSums)
        {
            string ret = "\r\n"; sBotSums = sBotSums.Replace("\r", "");
            if (sHashes == "" || sBotSums == "") return "";
            string[] BotSums = sBotSums.Split('\n'); //aSplit(sBotSums, "\r\n");
            long BotSumsUBound = BotSums.GetUpperBound(0); //Countword(sBotSums, "\r\n");
            for (int a = 0; a < BotSumsUBound; a++)
            {
                Debug("Checking", a);
                BotSums[a] = Split(BotSums[a], " | ", 1);
                if (sHashes.IndexOf(BotSums[a])!=-1)
                {
                    string ThisUser = Split(sHashes.Substring(sHashes.IndexOf(BotSums[a])), "\r\n", 0);
                    if (ret.IndexOf("\r\n" + ThisUser + "\r\n")==-1)
                    {
                        ret += ThisUser + "\r\n";
                    }
                }
            }
            ret = ret.Substring(2);
            if (ret.Substring(ret.Length - 2) == "\r\n") ret = ret.Substring(0, ret.Length - 2);
            return ret;
        }
        private string GetRanks(string sUsers)
        {
            string ret = "\r\n";
            if (sUsers == "") return ""; sUsers = sUsers.Replace("\r", "");
            string[] Users = sUsers.Split('\n'); int UsersUBound = Users.GetUpperBound(0); //aSplit(sUsers, "\r\n"); Countword(sUsers, "\r\n");
            for (int a = 0; a < UsersUBound; a++)
            {
                Debug("Fetching", a, "");
                if (Users[a].IndexOf(" | ") != -1) Users[a] = Users[a].Substring(Users[a].IndexOf(" | ") + 3);
                Nav("http://www.nordicmafia.net/nordic/index.php?side=bruker&brukernavn=" + Users[a].Replace(" ", "+"),
                    "size=1><B>Pengestatus:</B></FONT></TD>");
                if (WPC("size=1><B>Pengestatus:</B></FONT></TD>"))
                {
                    string Rank = Split(Split(Split(wSRC(), "size=1><B>Rank:</B></FONT><", 1), " size=1>", 1), "</FON", 0);
                    ret += Space(19 - Rank.Length) + Rank + " - " + Users[a] + "\r\n";
                }
                else
                {
                    a--;
                }
            }
            return ret;
        }

        private void cmdGo1a_Click(object sender, EventArgs e)
        {
            if (tSumFile.Text.EndsWith(".txt"))
            {
                FileWrite(tSumFile.Text, GetHashes(GetOnline()));
                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show(GetHashes(tSumFile.Text));
            }
        }
        private void cmdGo1b_Click(object sender, EventArgs e)
        {
            FileWrite(tSumFile.Text, GetHashes(FileRead(tLocalNames.Text)));
            MessageBox.Show("Done!");
        }

        private void cmdGo2_Click(object sender, EventArgs e)
        {
            string sBotSums = FileRead(tHashlog.Text); MessageBox.Show(sBotSums);
            string sHashes = FileRead(tSumFile.Text);
            FileWrite(tBotNames.Text, DecryptHashes(sHashes, sBotSums));
            MessageBox.Show("Done!");
        }

        private void cmdGo3_Click(object sender, EventArgs e)
        {
            string sUsernames = FileRead(tBotNames.Text);
            FileWrite(tURanks.Text, GetRanks(sUsernames));
            MessageBox.Show("Done!");
        }

        private void cmdGo3s_Click(object sender, EventArgs e)
        {
            string ret = "";
            string[] Users = FileRead(tURanks.Text).Replace("\r", "").Split('\n');
            Users = SortStringArrayAlphabetically(Users);
            foreach (string User in Users)
                ret += User + "\r\n";
            FileWrite(tURanks.Text, ret);
            MessageBox.Show("Done!");
        }
    }
}