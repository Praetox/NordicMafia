namespace pNMC
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
            this.wb = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PM_Spam_Config = new System.Windows.Forms.Button();
            this.PM_Spam_Remove = new System.Windows.Forms.Button();
            this.TTip = new System.Windows.Forms.ToolTip(this.components);
            this.lnkKrim = new System.Windows.Forms.Label();
            this.lnkPress = new System.Windows.Forms.Label();
            this.lnkGTA = new System.Windows.Forms.Label();
            this.lnkFC = new System.Windows.Forms.Label();
            this.lnkDrep = new System.Windows.Forms.Label();
            this.lnkBors = new System.Windows.Forms.Label();
            this.lnkBank = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lnkOC = new System.Windows.Forms.Label();
            this.lnkLivvakt = new System.Windows.Forms.Label();
            this.lnkHitlist = new System.Windows.Forms.Label();
            this.lnkHasj = new System.Windows.Forms.Label();
            this.lnkFly = new System.Windows.Forms.Label();
            this.lnkFilm = new System.Windows.Forms.Label();
            this.lnkFengsel = new System.Windows.Forms.Label();
            this.lnkFinn = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lnkGjeng = new System.Windows.Forms.Label();
            this.lnkRankbar = new System.Windows.Forms.Label();
            this.lnkUnderground = new System.Windows.Forms.Label();
            this.lnkSelgGTA = new System.Windows.Forms.Label();
            this.lnkKjopGTA = new System.Windows.Forms.Label();
            this.lnkKjopKuler = new System.Windows.Forms.Label();
            this.lnkPmNy = new System.Windows.Forms.Label();
            this.lnkForumOt = new System.Windows.Forms.Label();
            this.lnkForumSok = new System.Windows.Forms.Label();
            this.lnkForumGen = new System.Windows.Forms.Label();
            this.lnkPmLes = new System.Windows.Forms.Label();
            this.lnkOverfor = new System.Windows.Forms.Label();
            this.lnkForumGenNy = new System.Windows.Forms.Label();
            this.lnkForumSokNy = new System.Windows.Forms.Label();
            this.lnkForumOtNy = new System.Windows.Forms.Label();
            this.lnkForumGjengNy = new System.Windows.Forms.Label();
            this.lnkForumGjeng = new System.Windows.Forms.Label();
            this.pBanner = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ltKrim = new System.Windows.Forms.Label();
            this.ltPress = new System.Windows.Forms.Label();
            this.ltFC = new System.Windows.Forms.Label();
            this.ltGTA = new System.Windows.Forms.Label();
            this.tTimere = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBanner)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(113, 66);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(887, 455);
            this.wb.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PM_Spam_Config);
            this.groupBox1.Controls.Add(this.PM_Spam_Remove);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(113, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[PM] Antispam";
            // 
            // PM_Spam_Config
            // 
            this.PM_Spam_Config.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PM_Spam_Config.Location = new System.Drawing.Point(72, 19);
            this.PM_Spam_Config.Name = "PM_Spam_Config";
            this.PM_Spam_Config.Size = new System.Drawing.Size(24, 23);
            this.PM_Spam_Config.TabIndex = 2;
            this.PM_Spam_Config.Text = "...";
            this.TTip.SetToolTip(this.PM_Spam_Config, "Konfigurer spamfjerner");
            this.PM_Spam_Config.UseVisualStyleBackColor = true;
            this.PM_Spam_Config.Click += new System.EventHandler(this.PM_Spam_Config_Click);
            // 
            // PM_Spam_Remove
            // 
            this.PM_Spam_Remove.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PM_Spam_Remove.Location = new System.Drawing.Point(6, 19);
            this.PM_Spam_Remove.Name = "PM_Spam_Remove";
            this.PM_Spam_Remove.Size = new System.Drawing.Size(60, 23);
            this.PM_Spam_Remove.TabIndex = 2;
            this.PM_Spam_Remove.Text = "Utfør!";
            this.TTip.SetToolTip(this.PM_Spam_Remove, "Utfør spamfjerning");
            this.PM_Spam_Remove.UseVisualStyleBackColor = true;
            this.PM_Spam_Remove.Click += new System.EventHandler(this.PM_Spam_Remove_Click);
            // 
            // lnkKrim
            // 
            this.lnkKrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkKrim.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkKrim.Location = new System.Drawing.Point(12, 66);
            this.lnkKrim.Name = "lnkKrim";
            this.lnkKrim.Size = new System.Drawing.Size(95, 15);
            this.lnkKrim.TabIndex = 2;
            this.lnkKrim.Text = "Kriminalitet";
            this.lnkKrim.Click += new System.EventHandler(this.lnkKrim_Click);
            // 
            // lnkPress
            // 
            this.lnkPress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPress.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPress.Location = new System.Drawing.Point(12, 81);
            this.lnkPress.Name = "lnkPress";
            this.lnkPress.Size = new System.Drawing.Size(95, 15);
            this.lnkPress.TabIndex = 3;
            this.lnkPress.Text = "Utpressing";
            this.lnkPress.Click += new System.EventHandler(this.lnkPress_Click);
            // 
            // lnkGTA
            // 
            this.lnkGTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkGTA.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkGTA.Location = new System.Drawing.Point(12, 96);
            this.lnkGTA.Name = "lnkGTA";
            this.lnkGTA.Size = new System.Drawing.Size(95, 15);
            this.lnkGTA.TabIndex = 4;
            this.lnkGTA.Text = "Biltyveri";
            this.lnkGTA.Click += new System.EventHandler(this.lnkGTA_Click);
            // 
            // lnkFC
            // 
            this.lnkFC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkFC.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFC.Location = new System.Drawing.Point(12, 111);
            this.lnkFC.Name = "lnkFC";
            this.lnkFC.Size = new System.Drawing.Size(95, 15);
            this.lnkFC.TabIndex = 5;
            this.lnkFC.Text = "Fightclub";
            this.lnkFC.Click += new System.EventHandler(this.lnkFC_Click);
            // 
            // lnkDrep
            // 
            this.lnkDrep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkDrep.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDrep.Location = new System.Drawing.Point(12, 171);
            this.lnkDrep.Name = "lnkDrep";
            this.lnkDrep.Size = new System.Drawing.Size(95, 15);
            this.lnkDrep.TabIndex = 9;
            this.lnkDrep.Text = "Drep";
            this.lnkDrep.Click += new System.EventHandler(this.lnkDrep_Click);
            // 
            // lnkBors
            // 
            this.lnkBors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBors.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBors.Location = new System.Drawing.Point(12, 156);
            this.lnkBors.Name = "lnkBors";
            this.lnkBors.Size = new System.Drawing.Size(95, 15);
            this.lnkBors.TabIndex = 8;
            this.lnkBors.Text = "Børsen";
            this.lnkBors.Click += new System.EventHandler(this.lnkBors_Click);
            // 
            // lnkBank
            // 
            this.lnkBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBank.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBank.Location = new System.Drawing.Point(12, 141);
            this.lnkBank.Name = "lnkBank";
            this.lnkBank.Size = new System.Drawing.Size(95, 15);
            this.lnkBank.TabIndex = 7;
            this.lnkBank.Text = "Banken";
            this.lnkBank.Click += new System.EventHandler(this.lnkBank_Click);
            // 
            // label8
            // 
            this.label8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 15);
            this.label9.TabIndex = 17;
            // 
            // lnkOC
            // 
            this.lnkOC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkOC.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOC.Location = new System.Drawing.Point(12, 276);
            this.lnkOC.Name = "lnkOC";
            this.lnkOC.Size = new System.Drawing.Size(95, 15);
            this.lnkOC.TabIndex = 16;
            this.lnkOC.Text = "Organisert krim";
            this.lnkOC.Click += new System.EventHandler(this.lnkOC_Click);
            // 
            // lnkLivvakt
            // 
            this.lnkLivvakt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkLivvakt.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLivvakt.Location = new System.Drawing.Point(12, 261);
            this.lnkLivvakt.Name = "lnkLivvakt";
            this.lnkLivvakt.Size = new System.Drawing.Size(95, 15);
            this.lnkLivvakt.TabIndex = 15;
            this.lnkLivvakt.Text = "Livvaktutleie";
            this.lnkLivvakt.Click += new System.EventHandler(this.lnkLivvakt_Click);
            // 
            // lnkHitlist
            // 
            this.lnkHitlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkHitlist.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkHitlist.Location = new System.Drawing.Point(12, 246);
            this.lnkHitlist.Name = "lnkHitlist";
            this.lnkHitlist.Size = new System.Drawing.Size(95, 15);
            this.lnkHitlist.TabIndex = 14;
            this.lnkHitlist.Text = "Hitlist";
            this.lnkHitlist.Click += new System.EventHandler(this.lnkHitlist_Click);
            // 
            // lnkHasj
            // 
            this.lnkHasj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkHasj.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkHasj.Location = new System.Drawing.Point(12, 231);
            this.lnkHasj.Name = "lnkHasj";
            this.lnkHasj.Size = new System.Drawing.Size(95, 15);
            this.lnkHasj.TabIndex = 13;
            this.lnkHasj.Text = "Hasjplantasje";
            this.lnkHasj.Click += new System.EventHandler(this.lnkHasj_Click);
            // 
            // lnkFly
            // 
            this.lnkFly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkFly.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFly.Location = new System.Drawing.Point(12, 216);
            this.lnkFly.Name = "lnkFly";
            this.lnkFly.Size = new System.Drawing.Size(95, 15);
            this.lnkFly.TabIndex = 12;
            this.lnkFly.Text = "Flyplass";
            this.lnkFly.Click += new System.EventHandler(this.lnkFly_Click);
            // 
            // lnkFilm
            // 
            this.lnkFilm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkFilm.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFilm.Location = new System.Drawing.Point(12, 201);
            this.lnkFilm.Name = "lnkFilm";
            this.lnkFilm.Size = new System.Drawing.Size(95, 15);
            this.lnkFilm.TabIndex = 11;
            this.lnkFilm.Text = "Filmproduksjon";
            this.lnkFilm.Click += new System.EventHandler(this.lnkFilm_Click);
            // 
            // lnkFengsel
            // 
            this.lnkFengsel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkFengsel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFengsel.Location = new System.Drawing.Point(12, 186);
            this.lnkFengsel.Name = "lnkFengsel";
            this.lnkFengsel.Size = new System.Drawing.Size(95, 15);
            this.lnkFengsel.TabIndex = 10;
            this.lnkFengsel.Text = "Fengsel";
            this.lnkFengsel.Click += new System.EventHandler(this.lnkFengsel_Click);
            // 
            // lnkFinn
            // 
            this.lnkFinn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkFinn.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFinn.Location = new System.Drawing.Point(12, 426);
            this.lnkFinn.Name = "lnkFinn";
            this.lnkFinn.Size = new System.Drawing.Size(95, 15);
            this.lnkFinn.TabIndex = 25;
            this.lnkFinn.Text = "Finn spiller";
            this.lnkFinn.Click += new System.EventHandler(this.lnkFinn_Click);
            // 
            // label18
            // 
            this.label18.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label18.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 411);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 15);
            this.label18.TabIndex = 24;
            // 
            // lnkGjeng
            // 
            this.lnkGjeng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkGjeng.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkGjeng.Location = new System.Drawing.Point(12, 396);
            this.lnkGjeng.Name = "lnkGjeng";
            this.lnkGjeng.Size = new System.Drawing.Size(95, 15);
            this.lnkGjeng.TabIndex = 23;
            this.lnkGjeng.Text = "Gjengsenter";
            this.lnkGjeng.Click += new System.EventHandler(this.lnkGjeng_Click);
            // 
            // lnkRankbar
            // 
            this.lnkRankbar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkRankbar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRankbar.Location = new System.Drawing.Point(12, 381);
            this.lnkRankbar.Name = "lnkRankbar";
            this.lnkRankbar.Size = new System.Drawing.Size(95, 15);
            this.lnkRankbar.TabIndex = 22;
            this.lnkRankbar.Text = "Rankbar";
            this.lnkRankbar.Click += new System.EventHandler(this.lnkRankbar_Click);
            // 
            // lnkUnderground
            // 
            this.lnkUnderground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkUnderground.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUnderground.Location = new System.Drawing.Point(12, 366);
            this.lnkUnderground.Name = "lnkUnderground";
            this.lnkUnderground.Size = new System.Drawing.Size(95, 15);
            this.lnkUnderground.TabIndex = 21;
            this.lnkUnderground.Text = "The underground";
            this.lnkUnderground.Click += new System.EventHandler(this.lnkUnderground_Click);
            // 
            // lnkSelgGTA
            // 
            this.lnkSelgGTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkSelgGTA.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSelgGTA.Location = new System.Drawing.Point(12, 351);
            this.lnkSelgGTA.Name = "lnkSelgGTA";
            this.lnkSelgGTA.Size = new System.Drawing.Size(95, 15);
            this.lnkSelgGTA.TabIndex = 20;
            this.lnkSelgGTA.Text = "Selg bruktbil";
            this.lnkSelgGTA.Click += new System.EventHandler(this.lnkSelgGTA_Click);
            // 
            // lnkKjopGTA
            // 
            this.lnkKjopGTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkKjopGTA.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkKjopGTA.Location = new System.Drawing.Point(12, 336);
            this.lnkKjopGTA.Name = "lnkKjopGTA";
            this.lnkKjopGTA.Size = new System.Drawing.Size(95, 15);
            this.lnkKjopGTA.TabIndex = 19;
            this.lnkKjopGTA.Text = "Kjøp bruktbil";
            this.lnkKjopGTA.Click += new System.EventHandler(this.lnkKjopGTA_Click);
            // 
            // lnkKjopKuler
            // 
            this.lnkKjopKuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkKjopKuler.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkKjopKuler.Location = new System.Drawing.Point(12, 321);
            this.lnkKjopKuler.Name = "lnkKjopKuler";
            this.lnkKjopKuler.Size = new System.Drawing.Size(95, 15);
            this.lnkKjopKuler.TabIndex = 18;
            this.lnkKjopKuler.Text = "Kjøp kuler";
            this.lnkKjopKuler.Click += new System.EventHandler(this.lnkKjopKuler_Click);
            // 
            // lnkPmNy
            // 
            this.lnkPmNy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPmNy.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPmNy.Location = new System.Drawing.Point(85, 441);
            this.lnkPmNy.Name = "lnkPmNy";
            this.lnkPmNy.Size = new System.Drawing.Size(22, 15);
            this.lnkPmNy.TabIndex = 30;
            this.lnkPmNy.Text = "NY";
            this.lnkPmNy.Click += new System.EventHandler(this.lnkPmNy_Click);
            // 
            // lnkForumOt
            // 
            this.lnkForumOt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumOt.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumOt.Location = new System.Drawing.Point(12, 486);
            this.lnkForumOt.Name = "lnkForumOt";
            this.lnkForumOt.Size = new System.Drawing.Size(67, 15);
            this.lnkForumOt.TabIndex = 29;
            this.lnkForumOt.Text = "Offtopic";
            this.lnkForumOt.Click += new System.EventHandler(this.lnkForumOt_Click);
            // 
            // lnkForumSok
            // 
            this.lnkForumSok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumSok.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumSok.Location = new System.Drawing.Point(12, 471);
            this.lnkForumSok.Name = "lnkForumSok";
            this.lnkForumSok.Size = new System.Drawing.Size(67, 15);
            this.lnkForumSok.TabIndex = 28;
            this.lnkForumSok.Text = "Søknad";
            this.lnkForumSok.Click += new System.EventHandler(this.lnkForumSok_Click);
            // 
            // lnkForumGen
            // 
            this.lnkForumGen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumGen.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumGen.Location = new System.Drawing.Point(12, 456);
            this.lnkForumGen.Name = "lnkForumGen";
            this.lnkForumGen.Size = new System.Drawing.Size(67, 15);
            this.lnkForumGen.TabIndex = 27;
            this.lnkForumGen.Text = "Generelt";
            this.lnkForumGen.Click += new System.EventHandler(this.lnkForumGen_Click);
            // 
            // lnkPmLes
            // 
            this.lnkPmLes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPmLes.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPmLes.Location = new System.Drawing.Point(12, 441);
            this.lnkPmLes.Name = "lnkPmLes";
            this.lnkPmLes.Size = new System.Drawing.Size(67, 15);
            this.lnkPmLes.TabIndex = 26;
            this.lnkPmLes.Text = "Les PM";
            this.lnkPmLes.Click += new System.EventHandler(this.lnkPmLes_Click);
            // 
            // lnkOverfor
            // 
            this.lnkOverfor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkOverfor.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOverfor.Location = new System.Drawing.Point(12, 291);
            this.lnkOverfor.Name = "lnkOverfor";
            this.lnkOverfor.Size = new System.Drawing.Size(95, 15);
            this.lnkOverfor.TabIndex = 31;
            this.lnkOverfor.Text = "Overfør poeng";
            this.lnkOverfor.Click += new System.EventHandler(this.lnkOverfor_Click);
            // 
            // lnkForumGenNy
            // 
            this.lnkForumGenNy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumGenNy.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumGenNy.Location = new System.Drawing.Point(85, 456);
            this.lnkForumGenNy.Name = "lnkForumGenNy";
            this.lnkForumGenNy.Size = new System.Drawing.Size(22, 15);
            this.lnkForumGenNy.TabIndex = 32;
            this.lnkForumGenNy.Text = "NY";
            this.lnkForumGenNy.Click += new System.EventHandler(this.lnkForumGenNy_Click);
            // 
            // lnkForumSokNy
            // 
            this.lnkForumSokNy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumSokNy.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumSokNy.Location = new System.Drawing.Point(85, 471);
            this.lnkForumSokNy.Name = "lnkForumSokNy";
            this.lnkForumSokNy.Size = new System.Drawing.Size(22, 15);
            this.lnkForumSokNy.TabIndex = 33;
            this.lnkForumSokNy.Text = "NY";
            this.lnkForumSokNy.Click += new System.EventHandler(this.lnkForumSokNy_Click);
            // 
            // lnkForumOtNy
            // 
            this.lnkForumOtNy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumOtNy.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumOtNy.Location = new System.Drawing.Point(85, 486);
            this.lnkForumOtNy.Name = "lnkForumOtNy";
            this.lnkForumOtNy.Size = new System.Drawing.Size(22, 15);
            this.lnkForumOtNy.TabIndex = 34;
            this.lnkForumOtNy.Text = "NY";
            this.lnkForumOtNy.Click += new System.EventHandler(this.lnkForumOtNy_Click);
            // 
            // lnkForumGjengNy
            // 
            this.lnkForumGjengNy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumGjengNy.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumGjengNy.Location = new System.Drawing.Point(85, 501);
            this.lnkForumGjengNy.Name = "lnkForumGjengNy";
            this.lnkForumGjengNy.Size = new System.Drawing.Size(22, 15);
            this.lnkForumGjengNy.TabIndex = 36;
            this.lnkForumGjengNy.Text = "NY";
            this.lnkForumGjengNy.Click += new System.EventHandler(this.lnkForumGjengNy_Click);
            // 
            // lnkForumGjeng
            // 
            this.lnkForumGjeng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForumGjeng.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForumGjeng.Location = new System.Drawing.Point(12, 501);
            this.lnkForumGjeng.Name = "lnkForumGjeng";
            this.lnkForumGjeng.Size = new System.Drawing.Size(67, 15);
            this.lnkForumGjeng.TabIndex = 35;
            this.lnkForumGjeng.Text = "Gjeng";
            this.lnkForumGjeng.Click += new System.EventHandler(this.lnkForumGjeng_Click);
            // 
            // pBanner
            // 
            this.pBanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBanner.Image = ((System.Drawing.Image)(resources.GetObject("pBanner.Image")));
            this.pBanner.Location = new System.Drawing.Point(12, 12);
            this.pBanner.Name = "pBanner";
            this.pBanner.Size = new System.Drawing.Size(95, 48);
            this.pBanner.TabIndex = 37;
            this.pBanner.TabStop = false;
            this.pBanner.Click += new System.EventHandler(this.pBanner_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ltFC);
            this.groupBox2.Controls.Add(this.ltGTA);
            this.groupBox2.Controls.Add(this.ltPress);
            this.groupBox2.Controls.Add(this.ltKrim);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(221, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(102, 48);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timere";
            // 
            // ltKrim
            // 
            this.ltKrim.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltKrim.Location = new System.Drawing.Point(6, 15);
            this.ltKrim.Name = "ltKrim";
            this.ltKrim.Size = new System.Drawing.Size(42, 15);
            this.ltKrim.TabIndex = 3;
            this.ltKrim.Text = "00:00";
            this.ltKrim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TTip.SetToolTip(this.ltKrim, "Kriminalitet");
            this.ltKrim.Click += new System.EventHandler(this.ltKrim_Click);
            // 
            // ltPress
            // 
            this.ltPress.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltPress.Location = new System.Drawing.Point(54, 15);
            this.ltPress.Name = "ltPress";
            this.ltPress.Size = new System.Drawing.Size(42, 15);
            this.ltPress.TabIndex = 5;
            this.ltPress.Text = "00:00";
            this.ltPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TTip.SetToolTip(this.ltPress, "Utpressing");
            this.ltPress.Click += new System.EventHandler(this.ltPress_Click);
            // 
            // ltFC
            // 
            this.ltFC.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltFC.Location = new System.Drawing.Point(54, 30);
            this.ltFC.Name = "ltFC";
            this.ltFC.Size = new System.Drawing.Size(42, 15);
            this.ltFC.TabIndex = 7;
            this.ltFC.Text = "00:00";
            this.ltFC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TTip.SetToolTip(this.ltFC, "Fightclub");
            this.ltFC.Click += new System.EventHandler(this.ltFC_Click);
            // 
            // ltGTA
            // 
            this.ltGTA.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltGTA.Location = new System.Drawing.Point(6, 30);
            this.ltGTA.Name = "ltGTA";
            this.ltGTA.Size = new System.Drawing.Size(42, 15);
            this.ltGTA.TabIndex = 6;
            this.ltGTA.Text = "00:00";
            this.ltGTA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TTip.SetToolTip(this.ltGTA, "Biltyveri");
            this.ltGTA.Click += new System.EventHandler(this.ltGTA_Click);
            // 
            // tTimere
            // 
            this.tTimere.Enabled = true;
            this.tTimere.Interval = 250;
            this.tTimere.Tick += new System.EventHandler(this.tTimere_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(6)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1012, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pBanner);
            this.Controls.Add(this.lnkForumGjengNy);
            this.Controls.Add(this.lnkForumGjeng);
            this.Controls.Add(this.lnkForumOtNy);
            this.Controls.Add(this.lnkForumSokNy);
            this.Controls.Add(this.lnkForumGenNy);
            this.Controls.Add(this.lnkOverfor);
            this.Controls.Add(this.lnkPmNy);
            this.Controls.Add(this.lnkForumOt);
            this.Controls.Add(this.lnkForumSok);
            this.Controls.Add(this.lnkForumGen);
            this.Controls.Add(this.lnkPmLes);
            this.Controls.Add(this.lnkFinn);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lnkGjeng);
            this.Controls.Add(this.lnkRankbar);
            this.Controls.Add(this.lnkUnderground);
            this.Controls.Add(this.lnkSelgGTA);
            this.Controls.Add(this.lnkKjopGTA);
            this.Controls.Add(this.lnkKjopKuler);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lnkOC);
            this.Controls.Add(this.lnkLivvakt);
            this.Controls.Add(this.lnkHitlist);
            this.Controls.Add(this.lnkHasj);
            this.Controls.Add(this.lnkFly);
            this.Controls.Add(this.lnkFilm);
            this.Controls.Add(this.lnkFengsel);
            this.Controls.Add(this.lnkDrep);
            this.Controls.Add(this.lnkBors);
            this.Controls.Add(this.lnkBank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lnkFC);
            this.Controls.Add(this.lnkGTA);
            this.Controls.Add(this.lnkPress);
            this.Controls.Add(this.lnkKrim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wb);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pNMClient";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBanner)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PM_Spam_Config;
        private System.Windows.Forms.ToolTip TTip;
        private System.Windows.Forms.Button PM_Spam_Remove;
        private System.Windows.Forms.Label lnkKrim;
        private System.Windows.Forms.Label lnkPress;
        private System.Windows.Forms.Label lnkGTA;
        private System.Windows.Forms.Label lnkFC;
        private System.Windows.Forms.Label lnkDrep;
        private System.Windows.Forms.Label lnkBors;
        private System.Windows.Forms.Label lnkBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lnkOC;
        private System.Windows.Forms.Label lnkLivvakt;
        private System.Windows.Forms.Label lnkHitlist;
        private System.Windows.Forms.Label lnkHasj;
        private System.Windows.Forms.Label lnkFly;
        private System.Windows.Forms.Label lnkFilm;
        private System.Windows.Forms.Label lnkFengsel;
        private System.Windows.Forms.Label lnkFinn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lnkGjeng;
        private System.Windows.Forms.Label lnkRankbar;
        private System.Windows.Forms.Label lnkUnderground;
        private System.Windows.Forms.Label lnkSelgGTA;
        private System.Windows.Forms.Label lnkKjopGTA;
        private System.Windows.Forms.Label lnkKjopKuler;
        private System.Windows.Forms.Label lnkPmNy;
        private System.Windows.Forms.Label lnkForumOt;
        private System.Windows.Forms.Label lnkForumSok;
        private System.Windows.Forms.Label lnkForumGen;
        private System.Windows.Forms.Label lnkPmLes;
        private System.Windows.Forms.Label lnkOverfor;
        private System.Windows.Forms.Label lnkForumGenNy;
        private System.Windows.Forms.Label lnkForumSokNy;
        private System.Windows.Forms.Label lnkForumOtNy;
        private System.Windows.Forms.Label lnkForumGjengNy;
        private System.Windows.Forms.Label lnkForumGjeng;
        private System.Windows.Forms.PictureBox pBanner;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ltFC;
        private System.Windows.Forms.Label ltGTA;
        private System.Windows.Forms.Label ltPress;
        private System.Windows.Forms.Label ltKrim;
        private System.Windows.Forms.Timer tTimere;
    }
}

