using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Runtime.InteropServices;

namespace AutoNM
{
    public partial class frmMain : Form
    {
        string FormTitle = "AutoNM C# v" + Application.ProductVersion + " | http://praetox.50webs.com";
        string sUser, sPass, AbSession; bool FirstLaunch = false, intMain, HKWinState;
        int tKrim, tPress, tBil, tFCt, tFCa, tBryt, tFengsel, tEst, t2aDelay = 1;
        string aPath = Application.StartupPath + "\\";
        double TransVal = 0.9;

        public frmMain()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Returns str as a byte array
        ///</summary>
        public static byte[] StrToByte(string str)
        {
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //return encoding.GetBytes(str);
            int x;  byte[] vl = new byte[str.Length + 2];
            for (x = 0; x < str.Length; x++)
            {
                vl[x] = (byte)str[x];
            }
            vl[x] = 13; vl[x + 1] = 10;
            return vl;
        }
        ///<summary>
        /// Returns dBytes as a string (bugged!)
        ///</summary>
        public static string ByteToStr(byte[] dBytes)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(dBytes);
            return str;
        }
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
        /// Returns what tck will be after vl seconds
        ///</summary>
        public int T2A(int vl)
        {
            int ret = tck() + vl + t2aDelay;
            if (ret > 86400) ret -= 86400;
            return ret;
        }
        ///<summary>
        /// Returns the waiting time until tck is vl
        ///</summary>
        public int T2B(int vl)
        {
            int ret = vl - tck();
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
            return ret;
        }
        ///<summary>
        /// Returns how many seconds tck has passed vl
        ///</summary>
        public int T2C(int vl)
        {
            int ret = tck() - vl;
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
            return ret;
        }
        ///<summary>
        /// Sleeps for vl seconds
        ///</summary>
        public void iSlp(int vl)
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
        ///<summary>
        /// The load procedure of the form
        ///</summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
            //System.IO.StreamReader sAsm = new StreamReader(Asm.GetManifestResourceStream("AutoNM.Cars.txt"));
            //string AbCars = sAsm.ReadToEnd(); MessageBox.Show(AbCars); Application.Exit();
            if (FirstLaunch) return;
            //wb.Navigate("about:blank"); LoadSettings(); Application.DoEvents(); GatherStats(true); MessageBox.Show("Kek ^^"); Application.Exit();
            Balloon("Ser etter oppdateringer...");
            try
            {
                string sUData = ReadFile("user.ini");
                if (sUData.IndexOf("\r\n") == -1) sUData = "no_config";
                sUData = sUData.ToLower();
                sUData = sUData.Replace("æ", "(ae)").Replace("ø", "(oo)").Replace("å", "(aa)");
                sUData = Split(sUData, "\r\n", 0);
                sUData = MD5(sUData);

                string vNewest = wc.DownloadString("http://nordic.awardspace.com/ANmCs_version.php?id=" + sUData + "&cv=" + Application.ProductVersion);
                if (vNewest.IndexOf("<VERSION>" + Application.ProductVersion + "</VERSION>")==-1)
                {
                    MessageBox.Show("Du bruker en utdatert versjon av AutoNM C#.\n\nLaster ned nyeste versjon...", "Utdatert");
                    string Link = Split(wc.DownloadString("http://praetox.50webs.com/ANmCs_link.html"), "%", 1);
                    System.Diagnostics.Process.Start(Link);
                    this.Close(); Application.Exit(); return;
                }
            }
            catch
            {
                MessageBox.Show("AutoNM C# kunne ikke sjekke etter oppdateringer.");
            }
            Balloon("Starter opp...");
            wb.ScriptErrorsSuppressed = true;
            this.Icon = mIcon.Icon; Status.Text = Status.Text + Application.ProductVersion;
            tKrim = T2A(-5); tPress = T2A(-5); tBil = T2A(-5); tFCt = T2A(-5); tFCa = T2A(-5); tBryt = T2A(-5); tFengsel = T2A(-5); tEst = T2A(-5);
            //wb.Navigate("about:<form method=\"post\" action=\"" + Program.Gamedomain + "nordic/index.php?side=loggut\"><input type=\"submit\" value=\"Logg ut!\" name=\"subloggut\"><input type=\"hidden\" name=\"luz\">");
            //w8(); wb.Document.GetElementById("subloggut").InvokeMember("click"); w8();
            wb.Navigate("http://nordicmafia.me");


            MenuItem[] mnuList = new MenuItem[4];
            mnuList[0] = new MenuItem("Start bot", mnuStartBot);
            mnuList[1] = new MenuItem("Stopp bot", mnuStoppBot);
            mnuList[2] = new MenuItem("Besøk nettside", mnuWebsite);
            mnuList[3] = new MenuItem("Avslutt", mnuExit);
            nIcon.ContextMenu = new ContextMenu(mnuList);
            LoadSettings(); Balloon("AutoNM C# (" + sUser + ") klar.");
            FormTitle = "ANMC# " + sUser; this.Text = FormTitle;
            tGuiRedraw_Tick(new object(), new EventArgs());
            this.ShowInTaskbar = true; ShowForm(); cTrg.Focus();
            FirstLaunch = true;

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            Reg_DoesExist("Software\\Praetox Technologies\\AutoNM C#");
            key = key.OpenSubKey("Software\\Praetox Technologies\\AutoNM C#", true);
            string LastBootDate = ""; long LastBootTime = 0;
            try
            {
                LastBootDate = key.GetValue("Last ad date").ToString();
                LastBootTime = Convert.ToInt32(key.GetValue("Last ad time"));
            }
            catch { }
            if ((LastBootDate != System.DateTime.Now.ToLongDateString()) || 
                ((LastBootDate == System.DateTime.Now.ToLongDateString()) &&
                (LastBootTime + 10800 <= tck())))
            {
                wb.Navigate("http://adserv.110mb.com/"); w8();
                this.Text = ">>> KLIKK PÅ REKLAMEN FOR Å FORTSETTE <<<"; w8i();
                while (WPC("Welcome to ANM.")) Application.DoEvents();
                Random random = new Random(); int lw8 = T2A(random.Next(-2, +3) + 10);
                while (true)
                {
                    this.Text = ">>> VENT (" + T2B(lw8) + ")... <<<";
                    iSlp(50); if (T2B(lw8)==0) break;
                    if (WPC("Du er nå logget ut!") || WPC("Welcome to ANM.")) Application.Exit();
                }
                key.SetValue("Last ad date", System.DateTime.Now.ToLongDateString());
                key.SetValue("Last ad time", tck());
                this.Text = FormTitle;
            }
            key.Close(); cTrg.Enabled = true; cmdMer.Enabled = true;
        }
        ///<summary>
        /// The function called when "Start bot" is pressed
        ///</summary>
        private void mnuStartBot(object sender, EventArgs e)
        {
            cTrg.Checked = true; cTrg_CheckedChanged(new object(), new EventArgs());
        }
        ///<summary>
        /// The function called when "Stopp bot" is pressed
        ///</summary>
        private void mnuStoppBot(object sender, EventArgs e)
        {
            cTrg.Checked = false; cTrg_CheckedChanged(new object(), new EventArgs());
        }
        ///<summary>
        /// The function called when "Besøk nettside" is pressed
        ///</summary>
        private void mnuWebsite(object sender, EventArgs e)
        {
            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = "http://praetox.50webs.com";
            //proc.EnableRaisingEvents = false; proc.Start();
            System.Diagnostics.Process.Start("http://praetox.50webs.com");
        }
        ///<summary>
        /// The function called when "Avslutt" is pressed
        ///</summary>
        private void mnuExit(object sender, EventArgs e)
        {
            this.Close(); Application.Exit(); Application.DoEvents(); return;
        }
        ///<summary>
        /// Resizing of form
        ///</summary>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            wb.Height = this.Height - 132;
            if (this.WindowState == FormWindowState.Minimized) funcOpaque(false);
            if (this.WindowState == FormWindowState.Maximized) HKWinState = true;
            if (this.WindowState == FormWindowState.Normal) HKWinState = false;
        }
        ///<summary>
        /// Change username and password
        ///</summary>
        private void cmdChUsr_Click(object sender, EventArgs e)
        {
            sUser = ""; sPass = ""; 
            sUser = inBox.InputBox.Show("Skriv inn NordicMafia brukernavn.\n\nAvslutt med OK eller ENTER.", "Brukerdata").Text;
            
            //::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::
            // *** // if (sUser != "Onkel Don") sUser = "Privat bot";
            //::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::
            
            sPass = inBox.InputBox.Show("Skriv inn passordet for følgende NordicMafia bruker:\n\n\"" + sUser + "\"", "Brukerdata").Text;
            cmdChUsr.Text = sUser; WriteFile("user.ini", sUser + "\r\n" + sPass);
            FormTitle = "ANMC# " + sUser; this.Text = FormTitle;
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
            
            //::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::
            // *** // if (WPC("<SPAN class=menuyellowtext><A href=\"index.php?side=bruker"))
            // *** // {
                // *** // //<SPAN class=menuyellowtext><A href="index.php?side=bruker&amp;brukernavn=qwe">qwe</A></SPAN>
                // *** // string siteNick = Split(wSRC(), "<SPAN class=menuyellowtext><A href=\"index.php?side=bruker", 1);
                // *** // siteNick = Split(Split(siteNick, "\">", 1), "</A>", 0);
                // *** // if (siteNick != "Onkel Don")
                // *** // {
                    // *** // this.Close(); wb.Dispose(); Application.Exit(); Application.DoEvents();
                // *** // }
            // *** // }
            //::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::
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
            Application.DoEvents();
            while (wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
            GatherStats(false);
        }
        ///<summary>
        /// Waits until web browser starts loading
        ///</summary>
        public void w8i(long Timeout)
        {
            Application.DoEvents(); long t = tck();
            while (!wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if ((Timeout!=0) && (tck() > t + Timeout)) break;
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
            Application.DoEvents();
            while (wb.IsBusy)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
                if (wb.DocumentText.Contains(vl)) break;
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
                lg("Logger inn...");
                wb.Document.GetElementById("brukernavn").SetAttribute("value", sUser);
                wb.Document.GetElementById("passoord").SetAttribute("value", sPass);
                wb.Document.GetElementById("submit").InvokeMember("click"); w8();
                lg("Logget inn.");
                ret = true;
            }
            return ret;
        }
        ///<summary>
        /// Displays status message vl
        ///</summary>
        public void lg(string vl)
        {
            string TimeNow = System.DateTime.Now.ToLongTimeString();
            Status.Text = TimeNow + ": " + vl; Application.DoEvents();
        }
        ///<summary>
        /// Starts and stops the bot
        ///</summary>
        private void cTrg_CheckedChanged(object sender, EventArgs e)
        {
            if (cTrg.Checked)
            {
                tMain.Start(); fbActive.Text = "Startet"; LoadSettings();
                Balloon("AutoNM C# er nå aktivert.\n\nDet anbefales at du minimerer boten under bruk.\nFor å åpne boten igjen, dobbeltklikk dette ikonet.");
            }
            if (!cTrg.Checked) fbActive.Text = "Stopper...";
        }

        ///<summary>
        /// Displays time left until action is performed
        ///</summary>
        private void tCount_Tick(object sender, EventArgs e)
        {
            lbKrim.Text = s2ms(T2B(tKrim));
            lbPress.Text = s2ms(T2B(tPress));
            lbBil.Text = s2ms(T2B(tBil));
            lbFCt.Text = s2ms(T2B(tFCt));
            lbFCa.Text = s2ms(T2B(tFCa));
            lbFengsel.Text = s2ms(T2B(tFengsel));
        }
        ///<summary>
        /// Performs actions if time reaches zero
        ///</summary>
        private void tMain_Tick(object sender, EventArgs e)
        {
            if (intMain == true) return; intMain = true;

            //::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::
            // *** // if (WPC("<SPAN class=menuyellowtext><A href=\"index.php?side=bruker"))
            // *** // {
                // *** // //<SPAN class=menuyellowtext><A href="index.php?side=bruker&amp;brukernavn=qwe">qwe</A></SPAN>
                // *** // string siteNick = Split(wSRC(), "<SPAN class=menuyellowtext><A href=\"index.php?side=bruker", 1);
                // *** // siteNick = Split(Split(siteNick, "\">", 1), "</A>", 0);
                // *** // if (siteNick != "Onkel Don")
                // *** // {
                    // *** // this.Close(); wb.Dispose(); Application.Exit(); Application.DoEvents();
                // *** // }
            // *** // }
            //::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::SIKRING::

            if (T2B(tEst) == 0 && Program.oEst != -1) GatherStats(true);
            if (T2B(tFengsel) == 0)
            {
                tFengsel = T2A(-2);
                if (T2B(tFengsel) == 0 && T2B(tKrim) == 0 && Program.oKrim!=-1) funcKrim();
                if (T2B(tFengsel) == 0 && T2B(tPress) == 0 && Program.oPress != -1) funcPress();
                if (T2B(tFengsel) == 0 && T2B(tFCt) == 0 && Program.oFCt != -1) funcFCt();
                if (T2B(tFengsel) == 0 && T2B(tFCa) == 0 && Program.oFCa != -1) funcFCa();
                if (T2B(tFengsel) == 0 && T2B(tBil) == 0 && Program.oBil != -1) funcGTA();
                if (T2B(tFengsel) == 0 && T2B(tBryt) == 0 && Program.oBryt != -1) funcBryt();
            }
            else
            {
                lg("Fengsel | " + T2B(tFengsel) + " sek");
                string tmp = Convert.ToString(T2B(tFengsel));
                if (tmp.Substring(tmp.Length-1)=="0"){
                    PollFengsel(true, false);
                }
            }
            if (!cTrg.Checked)
            {
                fbActive.Text = "Stoppet";
                tMain.Enabled = false;
            }
            intMain = false;
        }
        ///<summary>
        /// Performs kiminalitet
        ///</summary>
        private void funcKrim()
        {
            int iOpt = Convert.ToInt32(Program.oKrim); if (iOpt < 0) iOpt = 0;
            Nav(Program.Gamedomain + "nordic/index.php?side=krim");
            if (Antibot() || PollFengsel()) return;
            if (WPC("name=bekreftkrimsubmit") || WPC("handling, du må vente"))
            {
                if (WPC("handling, du må vente"))
                {
                    tKrim = T2A(GetTell()); return;
                }
                wb.Document.All.GetElementsByName("valg")[iOpt].SetAttribute("checked", "true");
                wb.Document.GetElementById("bekreftkrimsubmit").InvokeMember("click"); w8();
                if (WPC("colSpan=4>Vellykket! ") || WPC("colSpan=4>Mislykket! "))
                {
                    Program.st_cKrim++; if (WPC("colSpan=4>Vellykket! ")) Program.st_fKrim++; PrintReport();
                    tKrim = T2A(180); lg("Kriminalitet"); return;
                }
                else
                {
                    tKrim = T2A(1-t2aDelay);
                }
            }
            else
            {
                tKrim = T2A(1-t2aDelay);
            }
        }
        ///<summary>
        /// Performs utpressing
        ///</summary>
        private void funcPress()
        {
            Nav(Program.Gamedomain + "nordic/index.php?side=utpressing");
            if (Antibot() || PollFengsel()) return;
            if (WPC("name=subpress"))
            {
                wb.Document.GetElementById("subpress").InvokeMember("click"); w8();
                Program.st_cPress++; if (WPC("colSpan=4>Vellykket! ")) Program.st_fPress++; PrintReport();
                tPress = T2A(960); lg("Utpressing"); return;
            }
            else
            {
                tPress = T2A(1-t2aDelay);
            }
        }
        ///<summary>
        /// Performs biltyveri
        ///</summary>
        private void funcGTA()
        {
            int iOpt = Convert.ToInt32(Program.oBil); if (iOpt < 0) iOpt = 0;
            Nav(Program.Gamedomain + "nordic/index.php?side=gta");
            if (Antibot() || PollFengsel()) return;
            if (WPC("name=stjelsubmit"))
            {
                wb.Document.All.GetElementsByName("gtanr")[iOpt].SetAttribute("checked", "true");
                wb.Document.GetElementById("stjelsubmit").InvokeMember("click"); w8();

                iOpt = -1; Antibot();
                if (WPC("colSpan=4>Du fikk ingenting")) iOpt = 1;
                if (WPC("biltyveri, du må vente <SPAN id=tell>")) iOpt = 2;
                if (WPC("content=0;url=index.php?side=fengsel>")) iOpt = 3;
                if (WPC("colSpan=4>Du stjal en <B>")) iOpt = 4;
                if (WPC("colSpan=4>Du stjæler en <B>")) iOpt = 4;
                if (iOpt != 2) Program.st_cBil++;
                switch (iOpt)
                {
                    case 1:
                        tBil = T2A(360); lg("Biltyveri"); return;
                    case 2:
                        tBil = T2A(GetTell()); return;
                    case 3:
                        PollFengsel(true, true); return;
                    case 4:
                        Program.st_fBil++; PrintReport();
                        tBil = T2A(360); lg("Fikk bil"); funcGTAs(); return;
                }
                //MessageBox.Show("Event: " + iOpt);
                //if (iOpt == -1) cmd_Click(new object(), new EventArgs());
                //this.Text = "Event: " + iOpt;
                PollFengsel(true, true); return;
            }
            else
            {
                tBil = T2A(1-t2aDelay);
            }
        }
        ///<summary>
        /// Sends the topmost car in garage to other country
        ///</summary>
        private void funcGTAs()
        {
            Nav(Program.Gamedomain + "nordic/index.php?side=gta");
            if (Antibot())
            {
                funcGTAs();
                return;
            }
            if (WPC("name=subtrans"))
            {
                string sCarID = Split(Split(wSRC(), "onmousedown=carvin(", 1), ")", 0);
                wb.Document.GetElementById("trainid").SetAttribute("value", sCarID);
                wb.Document.GetElementById("subtrans").InvokeMember("click"); w8();
                lg("Bil sendt");
            }
        }
        ///<summary>
        /// Performs FC training
        ///</summary>
        private void funcFCt()
        {
            Nav(Program.Gamedomain + "nordic/index.php?side=fightclub");
            if (Antibot() || PollFengsel()) return;
            if (WPC("name=subtrennaa"))
            {
                wb.Document.All.GetElementsByName("aktivitetvalg")[2].SetAttribute("checked", "true");
                wb.Document.GetElementById("subtrennaa").InvokeMember("click"); w8();
                if (WPC("colSpan=4>Du tok 25 Pushups. "))
                {
                    Program.st_cFCt++; PrintReport();
                    tFCt = T2A(120); lg("Fightclub"); return;
                }
            }
            else
            {
                tFCt = T2A(1-t2aDelay);
            }
        }
        ///<summary>
        /// Performs FC attacking
        ///</summary>
        private void funcFCa()
        {
            Nav(Program.Gamedomain + "nordic/index.php?side=fightclub");
            if (Antibot() || PollFengsel()) return;
            if (WPC("name=subutford"))
            {
                string TargetID = ""; float TargetDiff = 0;
                if (Program.oFCa==1 || Program.vFCa=="")
                {
                    string tfID, stWin, stLos, stCsh; float tWin, tLos, tmpDiff; UInt64 tCsh;
                    string WinLoss = "<BR>(Vinn:Tap)</TD>";                                                //.dk mod
                    if (!WPC(WinLoss)) WinLoss = "<BR>(Vind:Tab)</TD>";                                    //.dk mod
                    string TMP = Split(Split(wSRC(), WinLoss, 1), "subutford", 0);
                    string[] fIDs = aSplit(TMP, "value=");
                    string[] sSta = aSplit(TMP, "<BR>(");
                    for (int a = 1; a <= Countword(TMP, "motstandervelg"); a++)
                    {
                        tfID = Split(fIDs[a], " ", 0);
                        stWin = Split(sSta[a], ":", 0);
                        stLos = Split(Split(sSta[a], ":", 1), ")</TD>", 0);
                        stCsh = Split(Split(fIDs[a], "<TD>", 3), " kr<", 0);
                        tWin = Convert.ToInt32(stWin);
                        tLos = Convert.ToInt32(stLos);
                        tCsh = Convert.ToUInt64(stCsh);
                        tmpDiff = tLos / tWin;
                        if (tmpDiff > TargetDiff && tLos >= 20 && tCsh <= 500000000)
                        {
                            TargetDiff = tmpDiff; TargetID = tfID;
                        }
                    }
                }
                else if (Program.oFCa == 2 && Program.vFCa!="")
                {
                    string WinLoss = "<BR>(Vinn:Tap)</TD>";                                                //.dk mod
                    if (!WPC(WinLoss)) WinLoss = "<BR>(Vind:Tab)</TD>";                                    //.dk mod
                    string TMP = Split(Split(wSRC(), WinLoss, 1), "subutford", 0);
                    string[] fIDs = aSplit(TMP, "value=");
                    string[] sNIK = aSplit(TMP, "value=");
                    for (int a = 1; a <= Countword(TMP, "motstandervelg"); a++)
                    {
                        sNIK[a] = Split(Split(sNIK[a], "<TD>", 1), "<BR>", 0);
                        if (Program.vFCa.IndexOf("¤" + sNIK[a] + "¤") != -1)
                        {
                            TargetID = Split(fIDs[a], " ", 0); TargetDiff = 100;
                        }
                    }
                }
                if (TargetDiff >= 10)
                {
                    int iOpt = 0;
                    wb.Navigate("about:<FORM action=" + Program.Gamedomain + "nordic/index.php?side=fightclub method=post><INPUT type=radio value=" + TargetID + " name=motstandervelg><INPUT type=submit value=Utfordre! name=subutford></form>");
                    Application.DoEvents();
                    wb.Document.GetElementById("motstandervelg").InvokeMember("click");
                    wb.Document.GetElementById("subutford").InvokeMember("click"); w8();
                    if (WPC("colSpan=4>Du var sterkere enn motstanderen din. Du vant <B>") ||
                        WPC("colSpan=4>Du er stærkere end modstanderen din. Du vandt <B>")) iOpt = 1;
                    if (WPC("colSpan=4>Motstanderen var sterkere enn deg. Du tapte <B>") ||
                        WPC("colSpan=4>Modstanderen er stærkere end dig. Du tabte <B>")) iOpt = 2;
                    if (iOpt == 1 || iOpt == 2)
                    {
                        if (iOpt == 1)
                        {
                            Program.st_cFCa++; PrintReport();
                        }
                        tFCa = T2A(30); lg("FC Angrep"); return;
                    }
                    else
                    {
                        //MessageBox.Show("Unknown event!");
                    }
                }
                tFCa = T2A(1-t2aDelay); return;
            }
        }
        ///<summary>
        /// Performs jail breakout
        ///</summary>
        private void funcBryt()
        {
            bool rsm = true;
            if (Program.oBryt == 1 || Program.vBryt == "")
            {
                Nav(Program.Gamedomain + "nordic/index.php?side=fengsel");
                if (Antibot()) return;
                if (!WPC(">Bryt Ut!<")) rsm = false;
            }
            if (rsm)
            {
                Program.st_cBryt++;
                string BrytUtLink = "index.php?side=fengsel&bryt=" + Program.vBryt;
                if (WPC("index.php?side=fengsel&jbryt=")) BrytUtLink = "index.php?side=fengsel&jbryt=" +
                    Split(Split(wSRC(), "index.php?side=fengsel&jbryt=", 1), "\"", 0);
                if (Program.oBryt == 1 || Program.vBryt == "")
                {
                    BrytUtLink = Split(Split(wSRC(), ">Bryt Ut<", 1), "align=left", 0);
                    BrytUtLink = Split(Split(BrytUtLink, "<TD><A href=\"", 2), "\">Bryt Ut!<", 0);
                    BrytUtLink = BrytUtLink.Replace("&amp;", "&");
                }
                Nav(Program.Gamedomain + "nordic/" + BrytUtLink); Antibot();
                if (WPC("2><B>Du ble tatt mens du skulle bryte en ut,<BR"))
                {
                    Nav(Program.Gamedomain + "nordic/index.php?side=fengsel"); Antibot();
                    if (WPC("colSpan=2>Du sitter i fengsel!</TD></")) tFengsel = T2A(GetTell());
                    PrintReport();
                }
                if (WPC("colSpan=4>Du brøt ut <B>"))
                {
                    Program.st_vBryt += Split(BrytUtLink, "fengsel&bryt=", 1) + "\r\n";
                    Program.st_fBryt++; PrintReport();
                }
            }
        }
        ///<summary>
        /// Checks if you are in jail, sets jail timer / perfoms action if true
        ///</summary>
        private bool PollFengsel(bool FullCheck, bool MeasureTime)
        {
            if (FullCheck)
            {
                Nav(Program.Gamedomain + "nordic/index.php?side=krim");
                if (!WPC("name=bekreftkrimsubmit") && !WPC("handling, du må vente") && !WPC("center>Kriminalitet løser ingenting...<")) return PollFengsel();
            }
            {
                if (!WPC("center>Kriminalitet løser ingenting...<"))
                {
                    tFengsel = T2A(-2); return false;
                }
                else
                {
                    if (!MeasureTime) return true;
                    if (Program.oKjop==1)
                    {
                        wb.Navigate("<form action=\"" + Program.Gamedomain + "nordic/index.php?side=fengsel\" method=\"POST\"><input type=\"submit\" name=\"subbestikk\" value=\"Kjøp deg ut!\"></form>");
                        Application.DoEvents(); wb.Document.GetElementById("subbestikk").InvokeMember("click"); w8();
                        return false;
                    }
                    else
                    {
                        Nav(Program.Gamedomain + "nordic/index.php?side=fengsel");
                        if (WPC("colSpan=2>Du sitter i fengsel!</TD></") ||
                            WPC("colSpan=2>Du sidder i fængsel!</TD></")) tFengsel = T2A(GetTell());
                        return true;
                    }
                }
            }
        }
        private bool PollFengsel()
        {
            return PollFengsel(false, true);
        }
        ///<summary>
        /// Gets the remaining waiting time of current function
        ///</summary>
        private int GetTell()
        {
            if (!WPC("<SPAN id=tell>")) return -1;
            string str = Split(Split(wSRC(), "<SPAN id=tell>", 1), "</SPAN>", 0);
            return Convert.ToInt32(str);
        }
        ///<summary>
        /// Checks for antibot, performs action if needed
        ///</summary>
        private bool Antibot()
        {
            if (WPC(" velg tre bilder som inneholder ") || WPC(" vælg tre billeder som indeholder "))
            {
                MP3 mFile = new MP3(); if (File.Exists("ab.mp3")) mFile.Open("ab.mp3"); mFile.Play(true);
                FormWindowState OldWinState = this.WindowState;
                lg("Antibot"); this.Icon = abnIcon.Icon;
                if (Program.oAbt == 1)
                {
                    abnIcon.Visible = true;
                    abnIcon.ShowBalloonTip(60000, ".:: ANTIBOT ::.", "Klikk på boblen for å fortsette.", ToolTipIcon.Warning);
                }
                else if (Program.oAbt == 2)
                {
                    ShowForm(false);
                }
                else if (Program.oAbt == 3)
                {
                    AbSession = Split(Split(wSRC(), "genbilde.php?id=0&amp;", 1), "\">", 0);
                    //BreakAntibot();
                    MessageBox.Show("Fatal error:\r\n\r\nCould not perform selected ABMode!");
                }
                w8i(15); mFile.Close();
                if (OldWinState == FormWindowState.Minimized) funcOpaque(false);
                this.WindowState = OldWinState;
                //if (OldWinState == FormWindowState.Minimized) this.Hide();
                abnIcon.Visible = false; this.Icon = mIcon.Icon; w8();
                return true;
            }
            return false;
        }

        ///<summary>
        /// Dumps the current website to disk
        ///</summary>
        private void cmd_Click(object sender, EventArgs e)
        {
            //System.IO.TextWriter fOut = new System.IO.StreamWriter("c:/dump.txt");
            //fOut.WriteLine(wSRC());
            //fOut.Close();
            //funcFCa(); return;
            //Nav(Program.Gamedomain + "nordic/index.php?side=fightclub");
            WriteFile2("c:/dump.txt", wSRC());
        }
        ///<summary>
        /// Writes to text file with æ-ø-å in correct format
        ///</summary>
        private void WriteFile2(string file, string val)
        {
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            fs.SetLength(0);
            byte[] b; b = StrToByte(val);
            fs.Write(b, 0, b.Length);
            fs.Close(); fs.Dispose();
        }
        ///<summary>
        /// Writes to text file with non-correct æ-ø-å
        ///</summary>
        private void WriteFile(string file, string val)
        {
            TextWriter tw = new StreamWriter(file);
            tw.WriteLine(val);
            tw.Close();
        }
        ///<summary>
        /// Reads text files - only reads if æ-ø-å is non-correct
        ///</summary>
        private string ReadFile(string file)
        {
            try
            {
                TextReader tr = new StreamReader(file);
                string ret = tr.ReadToEnd();
                tr.Close(); return ret;
            }
            catch
            {
                return "";
            }
        }

        ///<summary>
        /// Display a tray balloon
        ///</summary>
        private void Balloon(string vl)
        {
            nIcon.ShowBalloonTip(5, "AutoNM C# v" + Application.ProductVersion, vl, ToolTipIcon.Info);
        }
        ///<summary>
        /// Show bot if tray icon is double-clicked
        ///</summary>
        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        ///<summary>
        /// Shows bot if tray balloon is clicked
        ///</summary>
        private void abnIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show(); this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
        }
        ///<summary>
        /// Shows bot in fullscreen mode if alert tray icon is double clicked
        ///</summary>
        private void abnIcon_DoubleClick(object sender, EventArgs e)
        {
            abnIcon_BalloonTipClicked(new object(), new EventArgs());
        }

        ///<summary>
        /// Emulate an antibot for testing purposes
        ///</summary>
        private void cmdEmuAB_Click(object sender, EventArgs e)
        {
            for (int a = 0; a <= 300; a++)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
            wb.Document.Write("<a href=\" velg tre bilder som inneholder \"></a>" +
                              "<a href=\"http://praetox.50webs.com/lindex.html\">Avslutt debug modus.</a>");
            Application.DoEvents(); Antibot();
        }
        ///<summary>
        /// Downloads an antibot alert song
        ///</summary>
        private void cmdDLAB_Click(object sender, EventArgs e)
        {
            if (intMain) MessageBox.Show("Stopp boten først!"); tMain.Enabled = false; cTrg.Checked = false; cTrg_CheckedChanged(new object(), new EventArgs());
            string link = wc.DownloadString("http://tib.110mb.com/abmusic.html");
            string[] abSongsAry = aSplit(link, "###"); string abSongs = "";
            for (int a = 0; a <= Countword(link, "###"); a++)
            {
                string sTitle = Split(abSongsAry[a], "%%%", 2); string sLink = Split(abSongsAry[a], "%%%", 1);
                abSongs += (a+1) + ": " + sTitle + "\r\n"; abSongsAry[a] = sLink;
            }
            int AbToDl = Convert.ToInt32(inBox.InputBox.Show("Velg sang ved å skrive inn tall. 0 avbryter.\n\n" + abSongs, "Velg sang", "0").Text);
            if (AbToDl == 0) return; if (File.Exists("ab.mp3")) File.Delete("ab.mp3"); Application.DoEvents();
            Uri uLink = new Uri(abSongsAry[AbToDl-1]); wc.DownloadFileAsync(uLink, "ab.mp3");
        }
        ///<summary>
        /// Shows the user the current download progress
        ///</summary>
        private void wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            this.Text = "ANM | Laster ned | " + e.ProgressPercentage + "% | !!VENT!!";
        }
        ///<summary>
        /// Notifys the user that download has completed
        ///</summary>
        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Text = FormTitle;
            lg("Nedlastning fullført."); MessageBox.Show("Nedlastning fullført!");
        }

        ///<summary>
        /// Loads the configuration screen
        ///</summary>
        private void cmdConfig_Click(object sender, EventArgs e)
        {
            //DialogResult rsp = MessageBox.Show("Kjøp ut av fengsel?", "Oppsett", MessageBoxButtons.YesNo);
            //if (rsp == DialogResult.Yes) bFengsel = true; else bFengsel = false;
            //Program.Gamedomain = inBox.InputBox.Show("Server som skal benyttes?", "Spilldomene", Program.Gamedomain).Text;
            //MessageBox.Show("Kjøper ut av fengsel (t/f): " + bFengsel + "\r\n" + 
            //                "Benytter server: " + Program.Gamedomain);
            Form fConf = new frmConfig(); fConf.Show();
        }

        ///<summary>
        /// Loads stored settings
        ///</summary>
        private void LoadSettings()
        {
            string sUData = ReadFile("user.ini");
            string sCfg = ReadFile("cfg.ini");
            if (sUData == "" && sCfg == "")
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false; proc.StartInfo.FileName = "http://tib.110mb.com/ANmCs_Guide.html";
                proc.Start(); return;
            }
            try
            {
                if (sUData != "")
                {
                    sUser = Split(sUData, "\r\n", 0); sPass = Split(sUData, "\r\n", 1); cmdChUsr.Text = sUser;
                }
                if (sCfg != "")
                {
                    string[] aCfg = aSplit(sCfg, " | ");
                    Program.oKrim = Convert.ToInt32(aCfg[0]);
                    Program.oPress = Convert.ToInt32(aCfg[1]);
                    Program.oBil = Convert.ToInt32(aCfg[2]);
                    Program.oFCt = Convert.ToInt32(aCfg[3]);
                    Program.oFCa = Convert.ToInt32(aCfg[4]);
                    Program.vFCa = aCfg[5];
                    Program.oBryt = Convert.ToInt32(aCfg[6]);
                    Program.vBryt = aCfg[7];
                    Program.oKjop = Convert.ToInt32(aCfg[8]);
                    Program.oEst = Convert.ToInt32(aCfg[9]);
                    Program.vEst = Convert.ToInt32(aCfg[10]);
                    Program.oAbt = Convert.ToInt32(aCfg[11]);
                    Program.Gamedomain = aCfg[12];
                    Program.oTrsp = Convert.ToInt32(aCfg[13]);
                    if (aCfg[12].Length < 10) throw new Exception("lol");
                }
                // Krim | Press | Bil | FCT | FCA | FCAOpt | Bryt | BrytOpt | Kjøput | Est | optEst | ABot | Srvr
                //   0      1      2     3     4      5       6       7          8      9      10      11     12
                // Trsp
                //  13
            }
            catch
            {
                MessageBox.Show("Konfigurasjonsfilene er korrupte / utdaterte!\r\n\r\nStart boten på nytt, og utfør samtlige konfigurasjoner igjen.");
                File.Delete("user.ini"); File.Delete("cfg.ini"); Application.Exit();
            }
        }

        ///<summary>
        /// Reads information from Nordicmafia
        ///</summary>
        private void GatherStats(bool Fullread)
        {
            if (Fullread) Nav(Program.Gamedomain + "nordic/index.php?side=rankbar");
            //Program.st_pRank = "n/a"; Program.st_pCash = "n/a"; Program.st_pFCs = "n/a"; Program.st_pFCl = "n/a";
            if (WPC("<BR>Penger: <SPAN class=menuyellowtext>"))
            {
                Program.st_pRank = Split(Split(wSRC(), "Rank: <SPAN class=menuyellowtext>", 1), "</SPAN>", 0);
                Program.st_pCash = Split(Split(wSRC(), "Penger: <SPAN class=menuyellowtext>", 1), " kr</SPAN>", 0);
                if (WPC("Prosent til Neste Level:</TD"))
                {
                    Program.st_pFCs = Split(Split(Split(wSRC(), "5%\">Vunnet/Tapt Forhold:<", 1), "<TD>", 1), "</", 0);
                    Program.st_pFCl = Split(Split(Split(wSRC(), "5%\">Fighterlevel:<", 1), "<TD>", 1), "</", 0);
                }
            }
            lbRank.Text = Program.st_pRank; lbCash.Text = Program.st_pCash; lbFcLv.Text = Program.st_pFCl; 
            if (!Fullread) return;
            if (WPC("%</STRONG></FONT>"))
            {
                lbRBar.Text = Split(Split(wSRC(), "<FONT size=3><STRONG>", 1), "%</STRONG></FONT>", 0);
                long RbPerc = Convert.ToInt32(lbRBar.Text.Replace(",", ""));
                if (Program.pRB_LastPerc == 0 || Program.pRB_LastPerc > RbPerc || Program.pRB_StartPerc > RbPerc)
                {
                    Program.pRB_TotlTime = 0;
                    Program.pRB_LastTick = T2A(-1);
                    Program.pRB_StartPerc = RbPerc;
                    Program.pRB_LastPerc = RbPerc;
                    lbEst.Text = "[?]";
                }
                else
                {
                    Program.pRB_TotlTime += T2C(Convert.ToInt32(Program.pRB_LastTick));
                    Program.pRB_LastTick = T2A(0 - t2aDelay);
                    float RSpeed = RbPerc - Program.pRB_StartPerc;
                    RSpeed = RSpeed / Program.pRB_TotlTime;
                    if (RSpeed != 0)
                    {
                        long RLeft = 10000 - RbPerc;
                        long RTLeft = Convert.ToInt32(RLeft / RSpeed);
                        lbEst.Text = s2ms(Convert.ToInt32(RTLeft));
                    }
                    else
                    {
                        lbEst.Text = "[?]";
                    }
                }
                tEst = T2A(Convert.ToInt32(Program.vEst));
            }
            else
            {
                tEst = T2A(300);
            }
        }
        ///<summary>
        /// Prints performance report to .html file
        ///</summary>
        private void PrintReport()
        {
            float PercVl = 0;
            string vl = "<center>" + "\r\n";

            // Header
            vl = vl + "<font size=5>AutoNM logg for " + sUser + "</size><br>" + "\r\n";
            vl = vl + "<font size=3>Bot åpnet .::. " + Program.st_bLaunch + "</size><br>" + "\r\n";
            vl = vl + "<font size=3>Oppdatert .::. " + TDNow() + "</size><br><br>" + "\r\n";
            vl = vl + "" + "\r\n";

            // Brukerinformasjon
            vl += "<table align=center border=1>" + "\r\n";
            vl += GenLogLine(Program.st_pRank, "%rankbar") + "\r\n";
            vl += GenLogLine(Program.st_pCash, "%est") + "\r\n";
            vl += "</table><br>" + "\r\n";
            vl += "<table align=center border=1>" + "\r\n";
            
            // Kriminalitet
            PercVl = 0; if (Program.st_cKrim > 0) PercVl = (100 / Program.st_cKrim) * Program.st_fKrim;
            vl += GenLogLine("<b>" + Program.st_cKrim + "</b> Kriminalitet", PercVl + "% suksessrate") + "\r\n";
            
            // Utpressing
            PercVl = 0; if (Program.st_cPress > 0) PercVl = (100 / Program.st_cPress) * Program.st_fPress;
            vl += GenLogLine("<b>" + Program.st_cPress + "</b> Utpressing", PercVl + "% suksessrate") + "\r\n";
            
            // Biltyveri
            PercVl = 0; if (Program.st_cBil > 0) PercVl = (100 / Program.st_cBil) * Program.st_fBil;
            vl += GenLogLine("<b>" + Program.st_cBil + "</b> Biltyveri", PercVl + "% suksessrate") + "\r\n";
            
            // FC-trening
            vl += GenLogLine("<b>" + Program.st_cFCt + "</b> FC-trening", "Level: " + Program.st_pFCl) + "\r\n";

            // FC-angrep
            vl += GenLogLine("<b>" + Program.st_cFCa + "</b> FC-angrep", "Stats: " + Program.st_pFCs) + "\r\n";
            
            // Utbrytninger
            vl += "</table><br>" + "\r\n";
            vl += "<table align=center border=1>" + "\r\n";
            PercVl = 0; if (Program.st_cBryt > 0) PercVl = (100 / Program.st_cBryt) * Program.st_fBryt;
            vl += GenLogLine("<b>" + Program.st_cBryt + "</b> Utbrytninger", PercVl + "% suksessrate") + "\r\n";
            if (Program.st_vBryt != "")
            {
                string[] breakouts = aSplit(Program.st_vBryt, "\r\n");
                for (int a = 0; a < Countword(Program.st_vBryt, "\r\n"); a++)
                {
                    vl += GenLogLine(breakouts[a], "#" + (a + 1));
                }
            }

            //Lagre til loggfil
            WriteFile2("log_" + sUser + ".html", vl);
        }
        ///<summary>
        /// Generates line used in PrintReport
        ///</summary>
        private string GenLogLine(string val1, string val2)
        {
            if (val1=="") val1 = "&nbsp;"; if (val2=="") val2 = "&nbsp;";
            return "<tr>\r\n" +
                   "  <td width=140><i>" + val1 + "</i></td>\r\n" +
                   "  <td width=140><i>" + val2 + "</i></td>\r\n" +
                   "</tr>";
            //return "<tr>" + "\r\n" +
            //       "  <td width=200><P ALIGN=\"right\"><i>" + val1 + "</i> ..</p></td>" + "\r\n" +
            //       "  <td width=200>.. <i>" + val2 + "</i></td>" + "\r\n" +
            //       "</tr>" + "\r\n";
        }

        ///<summary>
        /// Shoves form to topmost z-orientation
        ///</summary>
        private void ShowForm(bool Retain)
        {
            double Opness = this.Opacity;
            this.Opacity = 0;
            this.Show();
            if (Retain)
            {
                if (HKWinState) this.WindowState = FormWindowState.Maximized;
                if (!HKWinState) this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            FormPos.SetWindowPos((int)this.Handle, -1, 0, 0, 0, 0,
                                 FormPos.SWP_NOMOVE + FormPos.SWP_NOSIZE +
                                 FormPos.SWP_SHOWWINDOW);
            FormPos.SetWindowPos((int)this.Handle, -2, 0, 0, 0, 0,
                                 FormPos.SWP_NOMOVE + FormPos.SWP_NOSIZE +
                                 FormPos.SWP_SHOWWINDOW);
            this.Opacity = Opness;
        }
        private void ShowForm()
        {
            ShowForm(true);
        }

        ///<summary>
        /// Display the rest of the features
        ///</summary>
        private void cmdMer_Click(object sender, EventArgs e)
        {
            if (intMain) MessageBox.Show("Stopp boten først!"); tMain.Enabled = false; cTrg.Checked = false; cTrg_CheckedChanged(new object(), new EventArgs());
            int ret = Convert.ToInt16(inBox.InputBox.Show("" +
                "0: Avbryt \r\n" +
                "1: Selg biler",
                "Velg oppgave", "0").Text);
            switch (ret)
            {
                case 0: break;
                case 1:
                    string SkipThese = inBox.InputBox.Show("" + 
                        "a: Lamborghini Gallardo \r\n" + 
                        "b: Mercedes-Benz SL 500 \r\n" +
                        "c: Alfa Romeo GT SeleSpeed \r\n" +
                        "d: BMW 5-serie 520i \r\n" + 
                        "e: Seat Toledo \r\n" +
                        "f: Audi A3 \r\n" + 
                        "g: Volkswagen Polo", "Hvilke biler skal ikke selges?", "ab").Text;
                    bool DumpOthers = (MessageBox.Show("" +
                        "Dump biler som er i andre land?", "Dump...?",
                        MessageBoxButtons.YesNo) == DialogResult.Yes);
                    funcSelgBiler(SkipThese, DumpOthers); break;
            }
        }
        ///<summary>
        /// Sells cars by passed values
        ///</summary>
        private void funcSelgBiler(string SkipThese, bool DumpOthers)
        {
            string SkipTheseTmp = SkipThese; SkipThese="\r\n";
            if (SkipTheseTmp.IndexOf("a")!=-1) SkipThese += "Lamborghini Gallardo" + "\r\n";
            if (SkipTheseTmp.IndexOf("b") != -1) SkipThese += "Mercedes-Benz SL 500" + "\r\n";
            if (SkipTheseTmp.IndexOf("c") != -1) SkipThese += "Alfa Romeo GT SeleSpeed" + "\r\n";
            if (SkipTheseTmp.IndexOf("d") != -1) SkipThese += "BMW 5-serie 520i" + "\r\n";
            if (SkipTheseTmp.IndexOf("e") != -1) SkipThese += "Seat Toledo" + "\r\n";
            if (SkipTheseTmp.IndexOf("f") != -1) SkipThese += "Audi A3" + "\r\n";
            if (SkipTheseTmp.IndexOf("g") != -1) SkipThese += "Volkswagen Polo" + "\r\n";
            
            bool EventHappened = true;
            while (EventHappened)
            {
                EventHappened = false;
                Nav(Program.Gamedomain + "nordic/index.php?side=gta");
                string MyLoc = unSpace(Split(Split(wSRC(), "Bosted: <SPAN class=menuyellowtext>", 1), "</", 0));
                string[] cars = aSplit(wSRC(), "onmousedown=carvin(");
                for (int a = 1; a <= Countword(wSRC(), "onmousedown=carvin("); a++)
                {
                    string ThisID = Split(cars[a], ")", 0);
                    string ThisName = unSpace(Split(Split(cars[a], "<TD>", 1), "</TD>", 0));
                    string ThisLFrm = unSpace(Split(Split(cars[a], "<TD>", 3), "</TD>", 0));
                    string ThisLNow = unSpace(Split(Split(cars[a], "<TD>", 4), "</TD>", 0));
                    //MessageBox.Show("Linf -" + ThisID + "-\n" + ThisName + "\n" + ThisLFrm + "\n" + ThisLNow);
                    if ((DumpOthers) && (MyLoc != ThisLNow) && (ThisLNow.IndexOf(" timer og ") == -1) && (SkipThese.IndexOf(ThisName) == -1))
                    {
                        lg("Dumper " + ThisID + " (" + ThisName + ")...");
                        //MessageBox.Show("Dumping -" + ThisID + "-\n" + ThisName + "\n" + ThisLFrm + "\n" + ThisLNow);
                        Nav(Program.Gamedomain + "nordic/index.php?side=gta&valg=slett&zz=" + ThisID);
                        EventHappened = true;
                    }
                    if ((MyLoc == ThisLNow) && (SkipThese.IndexOf(ThisName) == -1))
                    {
                        lg("Selger " + ThisID + " (" + ThisName + ")...");
                        //MessageBox.Show("Selling -" + ThisID + "-\n" + ThisName + "\n" + ThisLFrm + "\n" + ThisLNow);
                        Nav(Program.Gamedomain + "nordic/index.php?side=gta&valg=selg&zz=" + ThisID);
                        EventHappened = true;
                    }
                }
            }
            MessageBox.Show("Bilsalg stoppet! \r\n\r\n" +
                            "Mulige grunner: \r\n" +
                            "1. Garasjen din ble helt tømt. \r\n" +
                            "2. Første side er full med biler som ikke kan selges/dumpes.");
        }
        ///<summary>
        /// Automatically performs current antibot
        ///</summary>
        private void BreakAntibot()
        {
            System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.StreamReader sAsm = new StreamReader (Asm.GetManifestResourceStream("AutoNM.Cars.txt"));
            string AbData = sAsm.ReadToEnd(); sAsm.Dispose();
            string AbCars = Split(AbData, "\r\n-~~-", 0);
            string AbPos = Split(AbData, "-~~-", 1);
            string AbNeg = Split(AbData, "-~~-", 2);
            MessageBox.Show(">"+AbCars+"<\r\n\r\n>"+AbPos+"<\r\n\r\n>"+AbNeg+"<");
            
            // [color]-[MinV]-[MaxV]-[Threshold] \r\n //

            while (true)
            {
                for (int abPic = 0; abPic <= 8; abPic++)                                    //Loop through all 9 AB-Pictures
                {
                    if (File.Exists("tmp.jpg")) File.Delete("tmp.jpg");                     //Delete any old ab pictures
                    DlFile.URLDownloadToFile(new object(),                                  //Download new ab picture
                        "http://www.nordicmafia.net/nordic/hget_genbilde.php?id=" +
                        abPic + "&" + AbSession, "tmp.jpg", 0, new System.IntPtr());
                    abpBox.Load("tmp.jpg"); Application.DoEvents();                         //Show ab-picture - just for fun

                    string retval = "-";                                                    //Prepare return value
                    long cRaw = Countword(AbCars, "\r\n");                                  //Count ubound of raw-array
                    string[] aryTmp, Raw = aSplit(AbCars, "\r\n");                          //Define and assign raw-array
                    long[] aryColor = new long[cRaw + 1], aryMtch = new long[cRaw + 1],     //Define holders of long values
                           aryMinV = new long[cRaw + 1], aryMaxV = new long[cRaw + 1],
                           aryThr = new long[cRaw + 1];
                    Color thisCol, findCol;                                                 //Define holders of temp. colors

                    for (int a = 0; a <= cRaw; a++)                                         //Loop to parse raw-array
                    {
                        aryTmp = aSplit(Raw[a], "-");                                       //Split raw-array %a
                        aryColor[a] = Convert.ToInt32(aryTmp[0]);                           //Assign target color of %a
                        aryMinV[a] = Convert.ToInt32(aryTmp[1]);                            //Assign minimum value of %a
                        aryMaxV[a] = Convert.ToInt32(aryTmp[2]);                            //Assign maximum value of %a
                        aryThr[a] = Convert.ToInt32(aryTmp[3]);                             //Assign color threshold of %a
                    }

                    Image.FastBitmap img = new Image.FastBitmap(new Bitmap("tmp.jpg"));     //Load picture as FastBitmap
                    for (int X = 0; X < 90; X++)                                            //Start X loop
                    {
                        for (int Y = 0; Y < 65; Y++)                                        //Start Y loop
                        {
                            thisCol = img.GetPixel(X, Y);                                   //Read color of current pixel
                            for (int a = 0; a <= cRaw; a++)                                 //Scan for supplied targets
                            {
                                findCol = Long2Col(aryColor[a]);                            //Convert target color from long
                                if (CompareColors(thisCol, findCol, aryThr[a]))             //If colors match, add +1 found
                                {
                                    aryMtch[a]++;                                           //Add +1 to found pixels
                                }
                            }
                        }
                    }
                    img.Release(); Application.DoEvents();                                  //Throw img into the wastebin
                    img.Bitmap.Dispose(); Application.DoEvents();                           //Stubborn, are we? This should do.
                    for (int a = 0; a <= cRaw; a++)                                         //Loop to sum up results
                    {
                        //MessageBox.Show("Total found on col #" + a + ": " + aryMtch[a]);  //  *debug* Display matchcount
                        if (aryMtch[a] >= aryMinV[a] && aryMtch[a] <= aryMaxV[a])           //If correct number of matches
                        {
                            retval += Convert.ToString(a) + "-";                            //Add target-ID to result list
                        }
                    }
                    if (retval != "-") MessageBox.Show("Found colors: " + retval);          //  *debug* Display retval
                }
            }
        }
        ///<summary>
        /// Returns color as long
        ///</summary>
        public static long Col2Long(Color Col)
        {
            return (Col.R * 256 * 256) + (Col.G * 256) + (Col.B * 1);
        }
        ///<summary>
        /// Returns long as color
        ///</summary>
        public static Color Long2Col(long Col)
        {
            int retR = Convert.ToInt16((Col / 256 / 256));
            int retG = Convert.ToInt16((Col / 256) - (retR * 256));
            int retB = Convert.ToInt16((Col) - (retR * 256 * 256) - (retG * 256));
            return Color.FromArgb(retR, retG, retB);
        }
        ///<summary>
        /// Compares two colors (Compare / CompareTo), returns true if within Threshold
        ///</summary>
        private bool CompareColors(Color Compare, Color CompareTo, long Threshold)
        {
            if (Compare == Color.Black || CompareTo == Color.Black) return false;   //Return false if pitch black
            long RDiff = Compare.R - CompareTo.R; if (RDiff < 0) RDiff = -RDiff;    //Compare reds, make positive
            long GDiff = Compare.G - CompareTo.G; if (GDiff < 0) GDiff = -GDiff;    //Compare greens, make positive
            long BDiff = Compare.B - CompareTo.B; if (BDiff < 0) BDiff = -BDiff;    //Compare blues, make positive
            if (RDiff <= Threshold && GDiff <= Threshold && BDiff <= Threshold)     //If all are below threshold
            {
                return true;                                                        //Return with a match (true)
            }
            else                                                                    //else...
            {
                return false;                                                       //Return with a mismatch (false)
            }
        }

        ///<summary>
        /// Application hotkeys timer
        ///</summary>
        private void tHotkeys_Tick(object sender, EventArgs e)
        {
            if (GKHook.GetAsyncKeyState(Keys.LControlKey) != 0)
            {
                if (GKHook.GetAsyncKeyState(Keys.LShiftKey) != 0)
                {
                    if (GKHook.GetAsyncKeyState(Keys.P) == -32767)
                    {
                        //if (HKWinState)
                        if (this.WindowState == FormWindowState.Minimized)
                        {
                            funcOpaque(true);
                        }
                        else
                        {
                            funcOpaque(false);
                        }
                    }
                    if (GKHook.GetAsyncKeyState(Keys.O) == -32767)
                    {
                        ShowForm();
                    }
                }
            }
        }

        ///<summary>
        /// Verifies that correct opacity mode is used
        ///</summary>
        private void tGuiRedraw_Tick(object sender, EventArgs e)
        {
            if ((this.Opacity == 1 && Program.oTrsp == 1) || (this.Opacity != 1 && Program.oTrsp != 1))
            {
                if (Program.oTrsp == 1) this.Opacity = TransVal; else this.Opacity = 1;
            }
        }

        ///<summary>
        /// Fades from invisible to nearly opaque (and back)
        ///</summary>
        private void funcOpaque(bool Opaque)
        {
            if (!tGuiRedraw.Enabled) return;
            tGuiRedraw.Stop();
            if (Opaque)
            {
                this.Opacity = 0; ShowForm(); //this.Opacity = 0; Application.DoEvents();
                for (double a = 0; a <= TransVal; a += 0.03)
                {
                    this.Opacity = a;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }
            }
            else
            {
                for (double a = TransVal; a > 0; a -= 0.03)
                {
                    this.Opacity = a;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }
                this.Hide(); Application.DoEvents();
                this.WindowState = FormWindowState.Minimized;
                this.Opacity = 1;
            }
            tGuiRedraw.Start();
        }

        ///<summary>
        /// Shows the "About..." box
        ///</summary>
        private void cmdOm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AutoNM C# versjon " + Application.ProductVersion + "\r\n" + 
                            "\r\n" + 
                            "Praetox Technologies 2007" + "\r\n" + 
                            "\r\n" +
                            "http://praetox.50webs.com");
        }
    }
}

/*
 * Examples derived by:
 * The result of guessing alot
 * http://www.webtropy.com/articles/InternetExplorer.asp?Internet%20explorer
 * 
 * // submit form
 * wb.GetElementById("~formid~").InvokeMember("Submit");
 * 
 * // get source of frame
 * wb.Document.Window.Frames[0].Document.Body.Innerhtml;
 * 
 * // set text box
 * wb.Document.GetElementById("~txtField~").SetAttribute("value", "~string~");
 * 
 * // set dropdown value
 * wb.Document.GetElementById("~ddMenu~").SetAttribute("selectedIndex", "~int~");
 * 
 * // set checkbox
 * wb.Document.GetElementById("~cBox~").SetAttribute("checked", "~bool~");
 * 
 * // set radio button
 * wb.Document.All.GetElementsByName("~rButton~")[0].SetAttribute("checked", "~bool~");
 * 
 * // click button
 * wb.Document.GetElementById("~button~").InvokeMember("click");
 * 
 * // execute JavaScript
 * string strRetVal = (string)wb.Document.InvokeScript("~jsFunction~")
 * 
*/