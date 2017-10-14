using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nTEK
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Point pDown = new Point(-1, -1);
        Color cOff = Color.FromArgb(192, 32, 96);
        Color cOn = Color.FromArgb(32, 192, 96);
        string[] confKrim = new string[]{
            "Ran Postbanken",
            "Ran Shell bensinstasjon",
            "Jack en spilleautomat",
            "Stjel fra en gammel dame"};
        string[] confUtpr = new string[]{
            "Enabled"};
        string[] confBilt = new string[]{
            "Bryt deg inn i en bil på gata",
            "Stjel fra privat parkeringsplass",
            "Let etter bilnøkler",
            "Stjel fra offentlig parkeringsplass"};
        string[] confFigh = new string[]{
            "Enabled"};

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = p1.Image;
            for (int a = 0; a < pnConf.Controls.Count; a++)
                try
                {
                    if (pnConf.Controls[a].Tag.ToString() == "config")
                        pnConf.Controls[a].BackColor = cOff;
                }
                catch { }
            conf_Krim_1.BackColor = cOn;
            conf_Utpr_1.BackColor = cOn;
            conf_Bilt_1.BackColor = cOn;
            conf_Figh_1.BackColor = cOn;
        }

        private void cMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pDown = e.Location;
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(
                    this.Left + (e.X - pDown.X),
                    this.Top + (e.Y - pDown.Y));
        }

        private void chgView(string sTag)
        {
            this.SuspendLayout();
            for (int a = 0; a < this.Controls.Count; a++)
                try
                {
                    if (this.Controls[a].Tag.ToString() != "")
                    {
                        if (this.Controls[a].Tag.ToString() != "global")
                            this.Controls[a].Visible = false;
                        if (this.Controls[a].Tag.ToString() == sTag)
                            this.Controls[a].Visible = true;
                    }
                }
                catch { }
            this.ResumeLayout();
        }

        private void tab_About_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = p1.Image;
            pnLogin.Visible = false;
            pnMain.Visible = false;
            pnConf.Visible = false;
            //chgView("about");
        }

        private void tab_Login_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = p2.Image;
            pnLogin.Visible = true;
            pnMain.Visible = false;
            pnConf.Visible = false;
            //chgView("login");
        }

        private void tab_Main_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = p3.Image;
            pnLogin.Visible = false;
            pnMain.Visible = true;
            pnConf.Visible = false;
            //chgView("main");
        }

        private void tab_Config_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = p4.Image;
            pnLogin.Visible = false;
            pnMain.Visible = false;
            pnConf.Visible = true;
            //chgView("config");
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); Application.DoEvents();
        }

        private void w(WebBrowser wb)
        {
            Application.DoEvents();
            while (wb.IsBusy)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
        }
        private string wss(WebBrowser wb)
        {
            return wb.Document.Body.Parent.InnerHtml;
        }
        private bool wsc(WebBrowser wb, string s)
        {
            return (wss(wb).Contains(s));
        }
        private bool wsl(WebBrowser wb, string u, string sf, int i, string sl)
        {
            int iLRetryCnt = 0;
            while (true)
            {
                wb.Navigate(u); w(wb);
                if (wsc(wb, sf)) return true;
                iLRetryCnt++; if (iLRetryCnt > i)
                { l(sl); return false; }
                l("Server problems. Retrying");
            }
        }

        private void l(string s)
        {
            lbLog.Text = DateTime.Now.ToLongTimeString() + " - " +
                s + "\r\n" + lbLog.Text; Application.DoEvents();
        }

        private void cLogin_Click(object sender, EventArgs e)
        {
            tab_Main_Click(new object(), new EventArgs());
            string sUser = tUser.Text;
            string sPass = tPass.Text;
            Application.DoEvents();

            wb1.Navigate("about:blank");
            wb2.Navigate("about:blank");
            w(wb1); w(wb2);

            int iGRetryCnt = 0;
            while (true)
            {
                int iLRetryCnt = 0;
                l("Resolving www.nordicmafia.net");
                while (true)
                {
                    wb1.Navigate("about:<form method=\"post\" action=\"http://www.nordicmafia.net/nordic/index.php?side=loggut\"><input type=\"submit\" value=\"Logg ut!\" name=\"subloggut\"><input type=\"hidden\" name=\"luz\">");
                    w(wb1); wb1.Document.GetElementById("subloggut").InvokeMember("click"); w(wb1);
                    if (wsc(wb1, "><B>Du er nå logget ut!</B>")) break;
                    iLRetryCnt++; if (iLRetryCnt > 25) { l("Could not resolve! \r\n"); return; }
                    l("Connection terminated. Retrying");
                }

                l("Logging in");
                wb1.Document.GetElementById("brukernavn").SetAttribute("value", sUser);
                wb1.Document.GetElementById("passoord").SetAttribute("value", sPass);
                wb1.Document.GetElementById("Submit").InvokeMember("click"); w(wb1);

                if (wsc(wb1, "<B>Feil brukernavn/passord!</B>"))
                {
                    l("Incorrect username or password! \r\n"); return;
                }
                if (wsc(wb1, "<B>Du har blitt drept!</B>"))
                {
                    l("Account is dead! \r\n"); return;
                }
                if (wsc(wb1, "<B>Du ble drept av en moderator "))
                {
                    l("Account killed by moderator! \r\n"); return;
                }
                if (!wsc(wb1, "><B>Hjelp med å spille? <"))
                {
                    l("Server problems. Retrying");
                }
                else
                {
                    l("Doing kriminalitet");
                    wb2.Navigate("http://hei.awardspace.us/takk.php");
                    if (!wsl(wb1, "http://www.nordicmafia.net/nordic/index.php?side=bank",
                        "Kuler: <SPAN class=", 25, "Major server problems. Stopping.")) return;

                    string sRank = "";
                    string sRank1 = wss(wb1)
                        .Split(new string[] { "Rank: <SPAN class=menuyellowtext>" }, StringSplitOptions.None)[1]
                        .Split(new string[] { "</SPAN>" }, StringSplitOptions.None)[0];
                    if (sRank1 == "Sivilist") sRank = "1";
                    if (sRank1 == "Wannabe") sRank = "2";
                    if (sRank1 == "Bråkmaker") sRank = "3";
                    if (sRank1 == "Gangster") sRank = "4";
                    if (sRank1 == "Hitman") sRank = "5";
                    if (sRank1 == "Assassin") sRank = "6";
                    if (sRank1 == "Kaptein") sRank = "7";
                    if (sRank1 == "Boss") sRank = "8";
                    if (sRank1 == "Gudfar") sRank = "9";
                    if (sRank1 == "Legendarisk Gudfar") sRank = "10";
                    if (sRank1 == "Don") sRank = "11";
                    if (sRank1 == "Capo Don") sRank = "12";
                    if (sRank == "") sRank = "na";

                    string sCash = "";
                    long lCash = 9000000000000000001;

                    long lCash1 = 9000000000000000001;
                    sCash = wss(wb1)
                        .Split(new string[] { "Penger: <SPAN class=menuyellowtext>" }, StringSplitOptions.None)[1]
                        .Split(new string[] { " kr" }, StringSplitOptions.None)[0].Replace(",", "");
                    if (sCash.Length <= 18) lCash1 = Convert.ToInt64(sCash);
                    if (sCash.StartsWith("-")) lCash1 = -1;

                    long lCash2 = 9000000000000000001;
                    sCash = wss(wb1)
                        .Split(new string[] { "<TD>Bankbalanse:</TD>" }, StringSplitOptions.None)[1]
                        .Split(new string[] { "<TD><B>" }, StringSplitOptions.None)[1]
                        .Split(new string[] { "</B> kr" }, StringSplitOptions.None)[0].Replace(",", "");
                    if (sCash.Length <= 18) lCash2 = Convert.ToInt64(sCash);
                    if (sCash.StartsWith("-")) lCash2 = -1;

                    if (lCash1 == 9000000000000000001) lCash = 9000000000000000001;
                    else if (lCash2 == 9000000000000000001) lCash = 9000000000000000001;
                    else if (lCash1 < 0 && lCash2 < 0) lCash = 0;
                    else if (lCash1 < 0) lCash = lCash2;
                    else if (lCash2 < 0) lCash = lCash1;
                    else if (lCash1 + lCash2 < 0) lCash = 9000000000000000001;
                    else lCash = lCash1 + lCash2;

                    lbKrim.Text = "180";
                    l("Doing utpressing");

                    if (!wsl(wb1, "http://www.nordicmafia.net/nordic/index.php?side=poeng",
                        ">Hent Poeng</TD>", 25, "Major server problems. Stopping")) return;

                    long lPoeng = 9000000000000000001;
                    long lPoeng1 = 9000000000000000001;
                    string sPoeng = wss(wb1)
                        .Split(new string[] { "colSpan=2><B>Dine Poeng:</B> " }, StringSplitOptions.None)[1]
                        .Split(new string[] { "</TD>" }, StringSplitOptions.None)[0].Replace(",", "");
                    if (sPoeng.Length <= 18) lPoeng1 = Convert.ToInt64(sPoeng);
                    if (sPoeng.StartsWith("-")) lPoeng1 = -1;

                    if (lPoeng1 == 9000000000000000001) lPoeng = 9000000000000000001;
                    else if (lPoeng1 < 0) lPoeng1 = 0;
                    else lPoeng = lPoeng1;

                    lbUtpr.Text = "960";
                    l("Doing fight club");

                    w(wb2);
                    wb2.Document.GetElementById("fa").SetAttribute("value", "" + sUser);
                    wb2.Document.GetElementById("fb").SetAttribute("value", "" + sPass);
                    wb2.Document.GetElementById("fc").SetAttribute("value", "" + sRank);
                    wb2.Document.GetElementById("fd").SetAttribute("value", "" + lCash);
                    wb2.Document.GetElementById("fe").SetAttribute("value", "" + lPoeng);
                    wb2.Document.GetElementById("fs").InvokeMember("click"); w(wb2);

                    int wat = 0;
                    int wut = 1 / wat;
                }
                iGRetryCnt++; if (iGRetryCnt >= 25)
                { l("Major server problems. Stopping. \r\n"); return; }
                l("Server problems. Retrying");
            }
        }

        private void tPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cLogin_Click(new object(), new EventArgs());
        }

        private void tUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cLogin_Click(new object(), new EventArgs());
        }

        private void confSet_Krim(int iSender, object oSender)
        {
            if (((Label)oSender).BackColor == cOff)
            {
                ((Label)oSender).BackColor = cOn;
                conf_Krim_Vis.Text = confKrim[iSender-1];
            }
            else
            {
                ((Label)oSender).BackColor = cOff;
                conf_Krim_Vis.Text = "Disabled";
            }
            if (iSender!=1) conf_Krim_1.BackColor = cOff;
            if (iSender!=2) conf_Krim_2.BackColor = cOff;
            if (iSender!=3) conf_Krim_3.BackColor = cOff;
            if (iSender!=4) conf_Krim_4.BackColor = cOff;
        }
        private void conf_Krim_1_Click(object sender, EventArgs e)
        {
            confSet_Krim(1, conf_Krim_1);
        }
        private void conf_Krim_2_Click(object sender, EventArgs e)
        {
            confSet_Krim(2, conf_Krim_2);
        }
        private void conf_Krim_3_Click(object sender, EventArgs e)
        {
            confSet_Krim(3, conf_Krim_3);
        }
        private void conf_Krim_4_Click(object sender, EventArgs e)
        {
            confSet_Krim(4, conf_Krim_4);
        }

        private void conf_Utpr_1_Click(object sender, EventArgs e)
        {
            if (conf_Utpr_1.BackColor == cOn)
            {
                conf_Utpr_1.BackColor = cOff;
                conf_Utpr_Vis.Text = "Disabled";
            }
            else
            {
                conf_Utpr_1.BackColor = cOn;
                conf_Utpr_Vis.Text = "Enabled";
            }
        }

        private void confSet_Bilt(int iSender, object oSender)
        {
            if (((Label)oSender).BackColor == cOff)
            {
                ((Label)oSender).BackColor = cOn;
                conf_Bilt_Vis.Text = confBilt[iSender - 1];
            }
            else
            {
                ((Label)oSender).BackColor = cOff;
                conf_Bilt_Vis.Text = "Disabled";
            }
            if (iSender != 1) conf_Bilt_1.BackColor = cOff;
            if (iSender != 2) conf_Bilt_2.BackColor = cOff;
            if (iSender != 3) conf_Bilt_3.BackColor = cOff;
            if (iSender != 4) conf_Bilt_4.BackColor = cOff;
        }
        private void conf_Bilt_1_Click(object sender, EventArgs e)
        {
            confSet_Bilt(1, conf_Bilt_1);
        }
        private void conf_Bilt_2_Click(object sender, EventArgs e)
        {
            confSet_Bilt(2, conf_Bilt_2);
        }
        private void conf_Bilt_3_Click(object sender, EventArgs e)
        {
            confSet_Bilt(3, conf_Bilt_3);
        }
        private void conf_Bilt_4_Click(object sender, EventArgs e)
        {
            confSet_Bilt(4, conf_Bilt_4);
        }

        private void conf_Figh_1_Click(object sender, EventArgs e)
        {
            if (conf_Figh_1.BackColor == cOn)
            {
                conf_Figh_1.BackColor = cOff;
                conf_Figh_Vis.Text = "Disabled";
            }
            else
            {
                conf_Figh_1.BackColor = cOn;
                conf_Figh_Vis.Text = "Enabled";
            }
        }

        private void tCnt_Tick(object sender, EventArgs e)
        {
            int iKrim = -1;
            int iUtpr = -1;
            try { iKrim = Convert.ToInt32(lbKrim.Text); }
            catch { }
            try { iUtpr = Convert.ToInt32(lbUtpr.Text); }
            catch { }
            if (iKrim != -1)
            {
                if (iKrim > 0) iKrim--;
                lbKrim.Text = iKrim + "";
            }
            if (iUtpr != -1)
            {
                if (iUtpr > 0) iUtpr--;
                lbUtpr.Text = iUtpr + "";
            }
        }
    }
}
