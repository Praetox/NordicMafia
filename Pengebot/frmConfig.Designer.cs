namespace Pengebot
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCAErr = new System.Windows.Forms.CheckBox();
            this.cmdAbort = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtStopVal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxPush = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxLoss = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxWin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbR4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCNow = new System.Windows.Forms.TextBox();
            this.cmdCalc = new System.Windows.Forms.Button();
            this.lbR3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbR2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbR1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCAErr);
            this.groupBox1.Controls.Add(this.cmdAbort);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.txtStopVal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaxPush);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaxLoss);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaxWin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 197);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Konfigurasjon";
            // 
            // chkCAErr
            // 
            this.chkCAErr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCAErr.Location = new System.Drawing.Point(6, 128);
            this.chkCAErr.Name = "chkCAErr";
            this.chkCAErr.Size = new System.Drawing.Size(268, 17);
            this.chkCAErr.TabIndex = 18;
            this.chkCAErr.Text = "Vis en feilmelding ved problemer";
            this.chkCAErr.UseVisualStyleBackColor = true;
            // 
            // cmdAbort
            // 
            this.cmdAbort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmdAbort.Location = new System.Drawing.Point(6, 163);
            this.cmdAbort.Name = "cmdAbort";
            this.cmdAbort.Size = new System.Drawing.Size(131, 28);
            this.cmdAbort.TabIndex = 16;
            this.cmdAbort.Text = "A v b r y t";
            this.cmdAbort.UseVisualStyleBackColor = true;
            this.cmdAbort.Click += new System.EventHandler(this.cmdAbort_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmdSave.Location = new System.Drawing.Point(143, 163);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(131, 28);
            this.cmdSave.TabIndex = 15;
            this.cmdSave.Text = "L a g r e   o p p s e t t";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtStopVal
            // 
            this.txtStopVal.BackColor = System.Drawing.Color.Green;
            this.txtStopVal.ForeColor = System.Drawing.Color.White;
            this.txtStopVal.Location = new System.Drawing.Point(214, 13);
            this.txtStopVal.Name = "txtStopVal";
            this.txtStopVal.Size = new System.Drawing.Size(60, 20);
            this.txtStopVal.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Stopp ÅEta nye kort nÂr x er oppnÂdd";
            // 
            // txtMaxPush
            // 
            this.txtMaxPush.BackColor = System.Drawing.Color.Green;
            this.txtMaxPush.ForeColor = System.Drawing.Color.White;
            this.txtMaxPush.Location = new System.Drawing.Point(214, 102);
            this.txtMaxPush.Name = "txtMaxPush";
            this.txtMaxPush.Size = new System.Drawing.Size(60, 20);
            this.txtMaxPush.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Stopp bot etter x antall push";
            // 
            // txtMaxLoss
            // 
            this.txtMaxLoss.BackColor = System.Drawing.Color.Green;
            this.txtMaxLoss.ForeColor = System.Drawing.Color.White;
            this.txtMaxLoss.Location = new System.Drawing.Point(214, 76);
            this.txtMaxLoss.Name = "txtMaxLoss";
            this.txtMaxLoss.Size = new System.Drawing.Size(60, 20);
            this.txtMaxLoss.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Stopp bot etter x antall tapt";
            // 
            // txtMaxWin
            // 
            this.txtMaxWin.BackColor = System.Drawing.Color.Green;
            this.txtMaxWin.ForeColor = System.Drawing.Color.White;
            this.txtMaxWin.Location = new System.Drawing.Point(214, 50);
            this.txtMaxWin.Name = "txtMaxWin";
            this.txtMaxWin.Size = new System.Drawing.Size(60, 20);
            this.txtMaxWin.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Stopp bot etter x antall vunnet";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbR4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCNow);
            this.groupBox2.Controls.Add(this.cmdCalc);
            this.groupBox2.Controls.Add(this.lbR3);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lbR2);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lbR1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 159);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Beregninger";
            // 
            // lbR4
            // 
            this.lbR4.Location = new System.Drawing.Point(165, 96);
            this.lbR4.Name = "lbR4";
            this.lbR4.Size = new System.Drawing.Size(109, 13);
            this.lbR4.TabIndex = 26;
            this.lbR4.Text = "100,000,000,000,000";
            this.lbR4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "- Meget lav risiko";
            // 
            // txtCNow
            // 
            this.txtCNow.BackColor = System.Drawing.Color.Green;
            this.txtCNow.ForeColor = System.Drawing.Color.White;
            this.txtCNow.Location = new System.Drawing.Point(165, 16);
            this.txtCNow.Name = "txtCNow";
            this.txtCNow.Size = new System.Drawing.Size(109, 20);
            this.txtCNow.TabIndex = 24;
            this.txtCNow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdCalc
            // 
            this.cmdCalc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmdCalc.Location = new System.Drawing.Point(168, 125);
            this.cmdCalc.Name = "cmdCalc";
            this.cmdCalc.Size = new System.Drawing.Size(106, 28);
            this.cmdCalc.TabIndex = 23;
            this.cmdCalc.Text = "B e r e g n !";
            this.cmdCalc.UseVisualStyleBackColor = true;
            this.cmdCalc.Click += new System.EventHandler(this.cmdCalc_Click);
            // 
            // lbR3
            // 
            this.lbR3.Location = new System.Drawing.Point(165, 83);
            this.lbR3.Name = "lbR3";
            this.lbR3.Size = new System.Drawing.Size(109, 13);
            this.lbR3.TabIndex = 22;
            this.lbR3.Text = "100,000,000,000,000";
            this.lbR3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "- Lav risiko";
            // 
            // lbR2
            // 
            this.lbR2.Location = new System.Drawing.Point(165, 70);
            this.lbR2.Name = "lbR2";
            this.lbR2.Size = new System.Drawing.Size(109, 13);
            this.lbR2.TabIndex = 20;
            this.lbR2.Text = "100,000,000,000,000";
            this.lbR2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "- Middels risiko";
            // 
            // lbR1
            // 
            this.lbR1.Location = new System.Drawing.Point(165, 57);
            this.lbR1.Name = "lbR1";
            this.lbR1.Size = new System.Drawing.Size(109, 13);
            this.lbR1.TabIndex = 18;
            this.lbR1.Text = "100,000,000,000,000";
            this.lbR1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "- Stor risiko";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(165, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 16;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Forslag til innsats:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Penger naa";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(304, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfig";
            this.Text = "Pengebot | Avansert";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCAErr;
        private System.Windows.Forms.Button cmdAbort;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox txtStopVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaxPush;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxLoss;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxWin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdCalc;
        private System.Windows.Forms.Label lbR3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbR2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbR1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCNow;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Label lbR4;
        private System.Windows.Forms.Label label7;


    }
}