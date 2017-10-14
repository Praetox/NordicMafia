namespace AutoNM
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tMain = new System.Windows.Forms.Timer(this.components);
            this.wb = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdChUsr = new System.Windows.Forms.Button();
            this.lbKrim = new System.Windows.Forms.Label();
            this.lbPress = new System.Windows.Forms.Label();
            this.lbFCt = new System.Windows.Forms.Label();
            this.lbBil = new System.Windows.Forms.Label();
            this.fbActive = new System.Windows.Forms.GroupBox();
            this.cTrg = new System.Windows.Forms.CheckBox();
            this.cmd = new System.Windows.Forms.Button();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbFCa = new System.Windows.Forms.Label();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.lbFengsel = new System.Windows.Forms.Label();
            this.lbEst = new System.Windows.Forms.Label();
            this.lbRBar = new System.Windows.Forms.Label();
            this.lbKuler = new System.Windows.Forms.Label();
            this.lbCash = new System.Windows.Forms.Label();
            this.lbRank = new System.Windows.Forms.Label();
            this.lbFcLv = new System.Windows.Forms.Label();
            this.cmdDLAB = new System.Windows.Forms.Button();
            this.cmdConfig = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmdEmuAB = new System.Windows.Forms.Button();
            this.wc = new System.Net.WebClient();
            this.abnIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tCount = new System.Windows.Forms.Timer(this.components);
            this.botStatus = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.userStatus = new System.Windows.Forms.GroupBox();
            this.mIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmdMer = new System.Windows.Forms.Button();
            this.abpBox = new System.Windows.Forms.PictureBox();
            this.tHotkeys = new System.Windows.Forms.Timer(this.components);
            this.tGuiRedraw = new System.Windows.Forms.Timer(this.components);
            this.cmdOm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.fbActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.botStatus.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.userStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abpBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tMain
            // 
            this.tMain.Interval = 1000;
            this.tMain.Tick += new System.EventHandler(this.tMain_Tick);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(12, 94);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(890, 407);
            this.wb.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdChUsr);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 35);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NM-bruker";
            this.tTip.SetToolTip(this.groupBox1, "Velg en konto som boten skal benytte");
            // 
            // cmdChUsr
            // 
            this.cmdChUsr.ForeColor = System.Drawing.Color.Black;
            this.cmdChUsr.Location = new System.Drawing.Point(1, 13);
            this.cmdChUsr.Name = "cmdChUsr";
            this.cmdChUsr.Size = new System.Drawing.Size(82, 21);
            this.cmdChUsr.TabIndex = 14;
            this.cmdChUsr.Text = "Velg bruker";
            this.tTip.SetToolTip(this.cmdChUsr, "Velg en konto som boten skal benytte");
            this.cmdChUsr.UseVisualStyleBackColor = true;
            this.cmdChUsr.Click += new System.EventHandler(this.cmdChUsr_Click);
            // 
            // lbKrim
            // 
            this.lbKrim.AutoSize = true;
            this.lbKrim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.lbKrim.Location = new System.Drawing.Point(45, 16);
            this.lbKrim.Name = "lbKrim";
            this.lbKrim.Size = new System.Drawing.Size(24, 13);
            this.lbKrim.TabIndex = 15;
            this.lbKrim.Text = "n/a";
            this.tTip.SetToolTip(this.lbKrim, "Kriminalitet");
            // 
            // lbPress
            // 
            this.lbPress.AutoSize = true;
            this.lbPress.Location = new System.Drawing.Point(45, 29);
            this.lbPress.Name = "lbPress";
            this.lbPress.Size = new System.Drawing.Size(24, 13);
            this.lbPress.TabIndex = 16;
            this.lbPress.Text = "n/a";
            this.tTip.SetToolTip(this.lbPress, "Utpressing");
            // 
            // lbFCt
            // 
            this.lbFCt.AutoSize = true;
            this.lbFCt.Location = new System.Drawing.Point(45, 55);
            this.lbFCt.Name = "lbFCt";
            this.lbFCt.Size = new System.Drawing.Size(24, 13);
            this.lbFCt.TabIndex = 16;
            this.lbFCt.Text = "n/a";
            this.tTip.SetToolTip(this.lbFCt, "FC Trener");
            // 
            // lbBil
            // 
            this.lbBil.AutoSize = true;
            this.lbBil.Location = new System.Drawing.Point(45, 42);
            this.lbBil.Name = "lbBil";
            this.lbBil.Size = new System.Drawing.Size(24, 13);
            this.lbBil.TabIndex = 16;
            this.lbBil.Text = "n/a";
            this.tTip.SetToolTip(this.lbBil, "Biltyveri");
            // 
            // fbActive
            // 
            this.fbActive.Controls.Add(this.cTrg);
            this.fbActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.fbActive.Location = new System.Drawing.Point(11, 53);
            this.fbActive.Name = "fbActive";
            this.fbActive.Size = new System.Drawing.Size(84, 35);
            this.fbActive.TabIndex = 9;
            this.fbActive.TabStop = false;
            this.fbActive.Text = "Bot aktivert?";
            this.tTip.SetToolTip(this.fbActive, "Botens status");
            // 
            // cTrg
            // 
            this.cTrg.AutoSize = true;
            this.cTrg.Enabled = false;
            this.cTrg.Location = new System.Drawing.Point(35, 18);
            this.cTrg.Name = "cTrg";
            this.cTrg.Size = new System.Drawing.Size(15, 14);
            this.cTrg.TabIndex = 12;
            this.tTip.SetToolTip(this.cTrg, "Bot aktivert / deaktivert");
            this.cTrg.UseVisualStyleBackColor = true;
            this.cTrg.CheckedChanged += new System.EventHandler(this.cTrg_CheckedChanged);
            // 
            // cmd
            // 
            this.cmd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmd.Location = new System.Drawing.Point(6, 46);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(84, 24);
            this.cmd.TabIndex = 11;
            this.cmd.Text = "Dump";
            this.cmd.UseVisualStyleBackColor = true;
            this.cmd.Click += new System.EventHandler(this.cmd_Click);
            // 
            // nIcon
            // 
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "AutoNM C#";
            this.nIcon.Visible = true;
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // lbFCa
            // 
            this.lbFCa.AutoSize = true;
            this.lbFCa.Location = new System.Drawing.Point(139, 16);
            this.lbFCa.Name = "lbFCa";
            this.lbFCa.Size = new System.Drawing.Size(24, 13);
            this.lbFCa.TabIndex = 17;
            this.lbFCa.Text = "n/a";
            this.tTip.SetToolTip(this.lbFCa, "FC Angriper");
            // 
            // tTip
            // 
            this.tTip.AutomaticDelay = 0;
            // 
            // lbFengsel
            // 
            this.lbFengsel.AutoSize = true;
            this.lbFengsel.Location = new System.Drawing.Point(139, 29);
            this.lbFengsel.Name = "lbFengsel";
            this.lbFengsel.Size = new System.Drawing.Size(24, 13);
            this.lbFengsel.TabIndex = 23;
            this.lbFengsel.Text = "n/a";
            this.tTip.SetToolTip(this.lbFengsel, "Fengsel");
            // 
            // lbEst
            // 
            this.lbEst.AutoSize = true;
            this.lbEst.Location = new System.Drawing.Point(139, 29);
            this.lbEst.Name = "lbEst";
            this.lbEst.Size = new System.Drawing.Size(24, 13);
            this.lbEst.TabIndex = 23;
            this.lbEst.Text = "n/a";
            this.tTip.SetToolTip(this.lbEst, "Tid til neste rank (HH:MM:SS)");
            // 
            // lbRBar
            // 
            this.lbRBar.AutoSize = true;
            this.lbRBar.Location = new System.Drawing.Point(139, 16);
            this.lbRBar.Name = "lbRBar";
            this.lbRBar.Size = new System.Drawing.Size(24, 13);
            this.lbRBar.TabIndex = 17;
            this.lbRBar.Text = "n/a";
            this.tTip.SetToolTip(this.lbRBar, "Rankbar");
            // 
            // lbKuler
            // 
            this.lbKuler.AutoSize = true;
            this.lbKuler.Location = new System.Drawing.Point(45, 55);
            this.lbKuler.Name = "lbKuler";
            this.lbKuler.Size = new System.Drawing.Size(24, 13);
            this.lbKuler.TabIndex = 16;
            this.lbKuler.Text = "n/a";
            this.tTip.SetToolTip(this.lbKuler, "Kuler");
            // 
            // lbCash
            // 
            this.lbCash.AutoSize = true;
            this.lbCash.Location = new System.Drawing.Point(45, 29);
            this.lbCash.Name = "lbCash";
            this.lbCash.Size = new System.Drawing.Size(24, 13);
            this.lbCash.TabIndex = 16;
            this.lbCash.Text = "n/a";
            this.tTip.SetToolTip(this.lbCash, "Penger");
            // 
            // lbRank
            // 
            this.lbRank.AutoSize = true;
            this.lbRank.Location = new System.Drawing.Point(45, 16);
            this.lbRank.Name = "lbRank";
            this.lbRank.Size = new System.Drawing.Size(24, 13);
            this.lbRank.TabIndex = 16;
            this.lbRank.Text = "n/a";
            this.tTip.SetToolTip(this.lbRank, "Rank");
            // 
            // lbFcLv
            // 
            this.lbFcLv.AutoSize = true;
            this.lbFcLv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.lbFcLv.Location = new System.Drawing.Point(45, 42);
            this.lbFcLv.Name = "lbFcLv";
            this.lbFcLv.Size = new System.Drawing.Size(24, 13);
            this.lbFcLv.TabIndex = 15;
            this.lbFcLv.Text = "n/a";
            this.tTip.SetToolTip(this.lbFcLv, "FC Level");
            // 
            // cmdDLAB
            // 
            this.cmdDLAB.Location = new System.Drawing.Point(771, 56);
            this.cmdDLAB.Name = "cmdDLAB";
            this.cmdDLAB.Size = new System.Drawing.Size(84, 32);
            this.cmdDLAB.TabIndex = 17;
            this.cmdDLAB.Text = "Antibot varsel";
            this.tTip.SetToolTip(this.cmdDLAB, "Last ned antibot-varslings-musikk");
            this.cmdDLAB.UseVisualStyleBackColor = true;
            this.cmdDLAB.Click += new System.EventHandler(this.cmdDLAB_Click);
            // 
            // cmdConfig
            // 
            this.cmdConfig.Location = new System.Drawing.Point(771, 18);
            this.cmdConfig.Name = "cmdConfig";
            this.cmdConfig.Size = new System.Drawing.Size(84, 32);
            this.cmdConfig.TabIndex = 21;
            this.cmdConfig.Text = "Oppsett";
            this.tTip.SetToolTip(this.cmdConfig, "Endre oppsettet til boten");
            this.cmdConfig.UseVisualStyleBackColor = true;
            this.cmdConfig.Click += new System.EventHandler(this.cmdConfig_Click);
            // 
            // Status
            // 
            this.Status.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Status.Location = new System.Drawing.Point(102, 2);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(263, 13);
            this.Status.TabIndex = 0;
            this.Status.Text = "Velkommen til AutoNM C# v";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tTip.SetToolTip(this.Status, "sist utførte handling");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Krim";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Press";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "GTA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "FC-T";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(100, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Fngsl";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(100, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "FC-A";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(100, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Est";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(100, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "RBar";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Kuler";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Cash";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Rank";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "FC lv";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdEmuAB
            // 
            this.cmdEmuAB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdEmuAB.Location = new System.Drawing.Point(6, 16);
            this.cmdEmuAB.Name = "cmdEmuAB";
            this.cmdEmuAB.Size = new System.Drawing.Size(84, 24);
            this.cmdEmuAB.TabIndex = 16;
            this.cmdEmuAB.Text = "Simuler AB";
            this.cmdEmuAB.UseVisualStyleBackColor = true;
            this.cmdEmuAB.Click += new System.EventHandler(this.cmdEmuAB_Click);
            // 
            // wc
            // 
            this.wc.BaseAddress = "";
            this.wc.CachePolicy = null;
            this.wc.Credentials = null;
            this.wc.Encoding = ((System.Text.Encoding)(resources.GetObject("wc.Encoding")));
            this.wc.Headers = ((System.Net.WebHeaderCollection)(resources.GetObject("wc.Headers")));
            this.wc.QueryString = ((System.Collections.Specialized.NameValueCollection)(resources.GetObject("wc.QueryString")));
            this.wc.UseDefaultCredentials = false;
            this.wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.wc_DownloadFileCompleted);
            this.wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(this.wc_DownloadProgressChanged);
            // 
            // abnIcon
            // 
            this.abnIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("abnIcon.Icon")));
            this.abnIcon.Text = "AutoNM C#";
            this.abnIcon.DoubleClick += new System.EventHandler(this.abnIcon_DoubleClick);
            this.abnIcon.BalloonTipClicked += new System.EventHandler(this.abnIcon_BalloonTipClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoNM.Properties.Resources.AnmCs;
            this.pictureBox1.Location = new System.Drawing.Point(101, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 70);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // tCount
            // 
            this.tCount.Enabled = true;
            this.tCount.Interval = 1000;
            this.tCount.Tick += new System.EventHandler(this.tCount_Tick);
            // 
            // botStatus
            // 
            this.botStatus.Controls.Add(this.lbFengsel);
            this.botStatus.Controls.Add(this.lbFCa);
            this.botStatus.Controls.Add(this.label6);
            this.botStatus.Controls.Add(this.label8);
            this.botStatus.Controls.Add(this.lbFCt);
            this.botStatus.Controls.Add(this.lbBil);
            this.botStatus.Controls.Add(this.lbPress);
            this.botStatus.Controls.Add(this.lbKrim);
            this.botStatus.Controls.Add(this.label4);
            this.botStatus.Controls.Add(this.label3);
            this.botStatus.Controls.Add(this.label2);
            this.botStatus.Controls.Add(this.label1);
            this.botStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.botStatus.Location = new System.Drawing.Point(371, 12);
            this.botStatus.Name = "botStatus";
            this.botStatus.Size = new System.Drawing.Size(194, 76);
            this.botStatus.TabIndex = 22;
            this.botStatus.TabStop = false;
            this.botStatus.Text = "Status (bot)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdEmuAB);
            this.groupBox3.Controls.Add(this.cmd);
            this.groupBox3.ForeColor = System.Drawing.Color.Gray;
            this.groupBox3.Location = new System.Drawing.Point(915, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(96, 76);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Debug stuff";
            // 
            // userStatus
            // 
            this.userStatus.Controls.Add(this.lbEst);
            this.userStatus.Controls.Add(this.lbRBar);
            this.userStatus.Controls.Add(this.label13);
            this.userStatus.Controls.Add(this.label14);
            this.userStatus.Controls.Add(this.lbKuler);
            this.userStatus.Controls.Add(this.lbCash);
            this.userStatus.Controls.Add(this.lbRank);
            this.userStatus.Controls.Add(this.lbFcLv);
            this.userStatus.Controls.Add(this.label15);
            this.userStatus.Controls.Add(this.label16);
            this.userStatus.Controls.Add(this.label17);
            this.userStatus.Controls.Add(this.label18);
            this.userStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.userStatus.Location = new System.Drawing.Point(571, 12);
            this.userStatus.Name = "userStatus";
            this.userStatus.Size = new System.Drawing.Size(194, 76);
            this.userStatus.TabIndex = 24;
            this.userStatus.TabStop = false;
            this.userStatus.Text = "Status (bruker)";
            // 
            // mIcon
            // 
            this.mIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mIcon.Icon")));
            this.mIcon.Text = "notifyIcon1";
            // 
            // cmdMer
            // 
            this.cmdMer.Enabled = false;
            this.cmdMer.Location = new System.Drawing.Point(861, 18);
            this.cmdMer.Name = "cmdMer";
            this.cmdMer.Size = new System.Drawing.Size(41, 32);
            this.cmdMer.TabIndex = 0;
            this.cmdMer.Text = "Mer";
            this.cmdMer.UseVisualStyleBackColor = true;
            this.cmdMer.Click += new System.EventHandler(this.cmdMer_Click);
            // 
            // abpBox
            // 
            this.abpBox.Location = new System.Drawing.Point(918, 94);
            this.abpBox.Name = "abpBox";
            this.abpBox.Size = new System.Drawing.Size(90, 65);
            this.abpBox.TabIndex = 0;
            this.abpBox.TabStop = false;
            // 
            // tHotkeys
            // 
            this.tHotkeys.Enabled = true;
            this.tHotkeys.Interval = 3;
            this.tHotkeys.Tick += new System.EventHandler(this.tHotkeys_Tick);
            // 
            // tGuiRedraw
            // 
            this.tGuiRedraw.Enabled = true;
            this.tGuiRedraw.Interval = 1000;
            this.tGuiRedraw.Tick += new System.EventHandler(this.tGuiRedraw_Tick);
            // 
            // cmdOm
            // 
            this.cmdOm.Location = new System.Drawing.Point(861, 56);
            this.cmdOm.Name = "cmdOm";
            this.cmdOm.Size = new System.Drawing.Size(41, 32);
            this.cmdOm.TabIndex = 25;
            this.cmdOm.Text = "Om...";
            this.cmdOm.UseVisualStyleBackColor = true;
            this.cmdOm.Click += new System.EventHandler(this.cmdOm_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(914, 505);
            this.Controls.Add(this.cmdOm);
            this.Controls.Add(this.abpBox);
            this.Controls.Add(this.cmdMer);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.userStatus);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.botStatus);
            this.Controls.Add(this.cmdConfig);
            this.Controls.Add(this.cmdDLAB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fbActive);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wb);
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.Text = "AutoNM C#";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.fbActive.ResumeLayout(false);
            this.fbActive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.botStatus.ResumeLayout(false);
            this.botStatus.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.userStatus.ResumeLayout(false);
            this.userStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abpBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tMain;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox fbActive;
        private System.Windows.Forms.CheckBox cTrg;
        private System.Windows.Forms.Button cmd;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.Button cmdChUsr;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.Label lbKrim;
        private System.Windows.Forms.Label lbPress;
        private System.Windows.Forms.Label lbFCt;
        private System.Windows.Forms.Label lbBil;
        private System.Windows.Forms.Label lbFCa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdEmuAB;
        private System.Windows.Forms.Button cmdDLAB;
        private System.Net.WebClient wc;
        private System.Windows.Forms.Button cmdConfig;
        private System.Windows.Forms.NotifyIcon abnIcon;
        private System.Windows.Forms.Timer tCount;
        private System.Windows.Forms.GroupBox botStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbFengsel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox userStatus;
        private System.Windows.Forms.Label lbEst;
        private System.Windows.Forms.Label lbRBar;
        private System.Windows.Forms.Label lbKuler;
        private System.Windows.Forms.Label lbCash;
        private System.Windows.Forms.Label lbRank;
        private System.Windows.Forms.Label lbFcLv;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NotifyIcon mIcon;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button cmdMer;
        private System.Windows.Forms.PictureBox abpBox;
        private System.Windows.Forms.Timer tHotkeys;
        private System.Windows.Forms.Timer tGuiRedraw;
        private System.Windows.Forms.Button cmdOm;
    }
}

