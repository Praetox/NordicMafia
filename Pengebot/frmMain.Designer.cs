namespace Pengebot
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
            this.cmdStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExpo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBelop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbPush = new System.Windows.Forms.Label();
            this.lbLoss = new System.Windows.Forms.Label();
            this.lbWin = new System.Windows.Forms.Label();
            this.lbMBet = new System.Windows.Forms.Label();
            this.lbCNow = new System.Windows.Forms.Label();
            this.lbCStart = new System.Windows.Forms.Label();
            this.lbCTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdStopp = new System.Windows.Forms.Button();
            this.cmdPanikk = new System.Windows.Forms.Button();
            this.tMain = new System.Windows.Forms.Timer(this.components);
            this.wb = new System.Windows.Forms.WebBrowser();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Status = new System.Windows.Forms.Label();
            this.cmdConfig = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(12, 334);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(161, 30);
            this.cmdStart.TabIndex = 5;
            this.cmdStart.Text = "S t a r t";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExpo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBelop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontrollpanel";
            // 
            // txtExpo
            // 
            this.txtExpo.BackColor = System.Drawing.Color.Green;
            this.txtExpo.ForeColor = System.Drawing.Color.White;
            this.txtExpo.Location = new System.Drawing.Point(53, 97);
            this.txtExpo.Name = "txtExpo";
            this.txtExpo.Size = new System.Drawing.Size(102, 20);
            this.txtExpo.TabIndex = 4;
            this.txtExpo.Text = "999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "x10^n";
            // 
            // txtBelop
            // 
            this.txtBelop.BackColor = System.Drawing.Color.Green;
            this.txtBelop.ForeColor = System.Drawing.Color.White;
            this.txtBelop.Location = new System.Drawing.Point(53, 71);
            this.txtBelop.Name = "txtBelop";
            this.txtBelop.Size = new System.Drawing.Size(102, 20);
            this.txtBelop.TabIndex = 3;
            this.txtBelop.Text = "1 000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Beløp";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Green;
            this.txtPass.ForeColor = System.Drawing.Color.White;
            this.txtPass.Location = new System.Drawing.Point(53, 45);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(102, 20);
            this.txtPass.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pass";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Green;
            this.txtUser.ForeColor = System.Drawing.Color.White;
            this.txtUser.Location = new System.Drawing.Point(53, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(102, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "Johnny Knoxville";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbPush);
            this.groupBox2.Controls.Add(this.lbLoss);
            this.groupBox2.Controls.Add(this.lbWin);
            this.groupBox2.Controls.Add(this.lbMBet);
            this.groupBox2.Controls.Add(this.lbCNow);
            this.groupBox2.Controls.Add(this.lbCStart);
            this.groupBox2.Controls.Add(this.lbCTotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(179, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistikk";
            // 
            // lbPush
            // 
            this.lbPush.Location = new System.Drawing.Point(57, 107);
            this.lbPush.Name = "lbPush";
            this.lbPush.Size = new System.Drawing.Size(98, 13);
            this.lbPush.TabIndex = 19;
            this.lbPush.Text = "0";
            this.lbPush.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLoss
            // 
            this.lbLoss.Location = new System.Drawing.Point(57, 94);
            this.lbLoss.Name = "lbLoss";
            this.lbLoss.Size = new System.Drawing.Size(98, 13);
            this.lbLoss.TabIndex = 18;
            this.lbLoss.Text = "0";
            this.lbLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbWin
            // 
            this.lbWin.Location = new System.Drawing.Point(57, 81);
            this.lbWin.Name = "lbWin";
            this.lbWin.Size = new System.Drawing.Size(98, 13);
            this.lbWin.TabIndex = 17;
            this.lbWin.Text = "0";
            this.lbWin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMBet
            // 
            this.lbMBet.Location = new System.Drawing.Point(57, 55);
            this.lbMBet.Name = "lbMBet";
            this.lbMBet.Size = new System.Drawing.Size(98, 13);
            this.lbMBet.TabIndex = 16;
            this.lbMBet.Text = "~";
            this.lbMBet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCNow
            // 
            this.lbCNow.Location = new System.Drawing.Point(57, 42);
            this.lbCNow.Name = "lbCNow";
            this.lbCNow.Size = new System.Drawing.Size(98, 13);
            this.lbCNow.TabIndex = 15;
            this.lbCNow.Text = "~";
            this.lbCNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCStart
            // 
            this.lbCStart.Location = new System.Drawing.Point(57, 29);
            this.lbCStart.Name = "lbCStart";
            this.lbCStart.Size = new System.Drawing.Size(98, 13);
            this.lbCStart.TabIndex = 14;
            this.lbCStart.Text = "~";
            this.lbCStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCTotal
            // 
            this.lbCTotal.Location = new System.Drawing.Point(57, 16);
            this.lbCTotal.Name = "lbCTotal";
            this.lbCTotal.Size = new System.Drawing.Size(98, 13);
            this.lbCTotal.TabIndex = 13;
            this.lbCTotal.Text = "~";
            this.lbCTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Push";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Tapt";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Vunnet";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Maks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Spiller";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "v/ start";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Penger";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdStopp
            // 
            this.cmdStopp.Location = new System.Drawing.Point(179, 334);
            this.cmdStopp.Name = "cmdStopp";
            this.cmdStopp.Size = new System.Drawing.Size(161, 30);
            this.cmdStopp.TabIndex = 6;
            this.cmdStopp.Text = "S t o p p";
            this.cmdStopp.UseVisualStyleBackColor = true;
            this.cmdStopp.Click += new System.EventHandler(this.cmdStopp_Click);
            // 
            // cmdPanikk
            // 
            this.cmdPanikk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdPanikk.Location = new System.Drawing.Point(179, 370);
            this.cmdPanikk.Name = "cmdPanikk";
            this.cmdPanikk.Size = new System.Drawing.Size(161, 30);
            this.cmdPanikk.TabIndex = 7;
            this.cmdPanikk.Text = "N ø d s t o p p";
            this.cmdPanikk.UseVisualStyleBackColor = false;
            this.cmdPanikk.Click += new System.EventHandler(this.cmdPanikk_Click);
            // 
            // tMain
            // 
            this.tMain.Tick += new System.EventHandler(this.tMain_Tick);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(383, 12);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(889, 691);
            this.wb.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Status);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 37);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Applikasjons-hendelser";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(6, 16);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(185, 13);
            this.Status.TabIndex = 0;
            this.Status.Text = "88:88:88 - Ingen aksjoner utført enda.";
            // 
            // cmdConfig
            // 
            this.cmdConfig.Location = new System.Drawing.Point(12, 370);
            this.cmdConfig.Name = "cmdConfig";
            this.cmdConfig.Size = new System.Drawing.Size(161, 30);
            this.cmdConfig.TabIndex = 12;
            this.cmdConfig.Text = "A v a n s e r t";
            this.cmdConfig.UseVisualStyleBackColor = true;
            this.cmdConfig.Click += new System.EventHandler(this.cmdConfig_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pengebot.Properties.Resources.Pengebot;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 140);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = ".dk versjon for Johnny Knoxville";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(352, 412);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmdConfig);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.cmdPanikk);
            this.Controls.Add(this.cmdStopp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Pengebot | Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBelop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdStopp;
        private System.Windows.Forms.Button cmdPanikk;
        private System.Windows.Forms.Label lbPush;
        private System.Windows.Forms.Label lbLoss;
        private System.Windows.Forms.Label lbWin;
        private System.Windows.Forms.Label lbMBet;
        private System.Windows.Forms.Label lbCNow;
        private System.Windows.Forms.Label lbCStart;
        private System.Windows.Forms.Label lbCTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer tMain;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button cmdConfig;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
    }
}

