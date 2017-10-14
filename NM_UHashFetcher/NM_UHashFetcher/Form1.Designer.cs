namespace NM_UHashFetcher
{
    partial class Form1
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
            this.wb = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tPass = new System.Windows.Forms.TextBox();
            this.tUser = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tSumFile = new System.Windows.Forms.TextBox();
            this.cmdGo1a = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tHashlog = new System.Windows.Forms.TextBox();
            this.cmdGo2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tBotNames = new System.Windows.Forms.TextBox();
            this.lDebug = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tURanks = new System.Windows.Forms.TextBox();
            this.cmdGo3 = new System.Windows.Forms.Button();
            this.cmdGo1b = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tLocalNames = new System.Windows.Forms.TextBox();
            this.cmdGo3s = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(236, 1);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(607, 428);
            this.wb.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tPass);
            this.groupBox1.Controls.Add(this.tUser);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nordicmafia access information";
            // 
            // tPass
            // 
            this.tPass.Location = new System.Drawing.Point(112, 19);
            this.tPass.Name = "tPass";
            this.tPass.PasswordChar = '*';
            this.tPass.Size = new System.Drawing.Size(100, 20);
            this.tPass.TabIndex = 3;
            this.tPass.Text = "14qrafzv";
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(6, 19);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(100, 20);
            this.tUser.TabIndex = 2;
            this.tUser.Text = "Crystallized";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tSumFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Username hashes";
            // 
            // tSumFile
            // 
            this.tSumFile.Location = new System.Drawing.Point(6, 19);
            this.tSumFile.Name = "tSumFile";
            this.tSumFile.Size = new System.Drawing.Size(206, 20);
            this.tSumFile.TabIndex = 3;
            this.tSumFile.Text = "uSums.txt";
            // 
            // cmdGo1a
            // 
            this.cmdGo1a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGo1a.Location = new System.Drawing.Point(124, 114);
            this.cmdGo1a.Name = "cmdGo1a";
            this.cmdGo1a.Size = new System.Drawing.Size(100, 23);
            this.cmdGo1a.TabIndex = 3;
            this.cmdGo1a.Text = "Fetch UHashes";
            this.cmdGo1a.UseVisualStyleBackColor = true;
            this.cmdGo1a.Click += new System.EventHandler(this.cmdGo1a_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tHashlog);
            this.groupBox3.Location = new System.Drawing.Point(12, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 45);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User hash connection log";
            // 
            // tHashlog
            // 
            this.tHashlog.Location = new System.Drawing.Point(6, 19);
            this.tHashlog.Name = "tHashlog";
            this.tHashlog.Size = new System.Drawing.Size(206, 20);
            this.tHashlog.TabIndex = 3;
            this.tHashlog.Text = "ANmCs_loads.txt";
            // 
            // cmdGo2
            // 
            this.cmdGo2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGo2.Location = new System.Drawing.Point(124, 325);
            this.cmdGo2.Name = "cmdGo2";
            this.cmdGo2.Size = new System.Drawing.Size(100, 23);
            this.cmdGo2.TabIndex = 5;
            this.cmdGo2.Text = "Make botuser list";
            this.cmdGo2.UseVisualStyleBackColor = true;
            this.cmdGo2.Click += new System.EventHandler(this.cmdGo2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tBotNames);
            this.groupBox4.Location = new System.Drawing.Point(12, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 45);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decrypted usernames";
            // 
            // tBotNames
            // 
            this.tBotNames.Location = new System.Drawing.Point(6, 19);
            this.tBotNames.Name = "tBotNames";
            this.tBotNames.Size = new System.Drawing.Size(206, 20);
            this.tBotNames.TabIndex = 3;
            this.tBotNames.Text = "ANmCs_users.txt";
            // 
            // lDebug
            // 
            this.lDebug.AutoSize = true;
            this.lDebug.Location = new System.Drawing.Point(15, 410);
            this.lDebug.Name = "lDebug";
            this.lDebug.Size = new System.Drawing.Size(39, 13);
            this.lDebug.TabIndex = 7;
            this.lDebug.Text = "Debug";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tURanks);
            this.groupBox5.Location = new System.Drawing.Point(12, 354);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(218, 45);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Usernames with ranks";
            // 
            // tURanks
            // 
            this.tURanks.Location = new System.Drawing.Point(6, 19);
            this.tURanks.Name = "tURanks";
            this.tURanks.Size = new System.Drawing.Size(206, 20);
            this.tURanks.TabIndex = 3;
            this.tURanks.Text = "AMnCs_ranks.txt";
            // 
            // cmdGo3
            // 
            this.cmdGo3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGo3.Location = new System.Drawing.Point(124, 405);
            this.cmdGo3.Name = "cmdGo3";
            this.cmdGo3.Size = new System.Drawing.Size(100, 23);
            this.cmdGo3.TabIndex = 9;
            this.cmdGo3.Text = "Get user ranks";
            this.cmdGo3.UseVisualStyleBackColor = true;
            this.cmdGo3.Click += new System.EventHandler(this.cmdGo3_Click);
            // 
            // cmdGo1b
            // 
            this.cmdGo1b.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGo1b.Location = new System.Drawing.Point(124, 194);
            this.cmdGo1b.Name = "cmdGo1b";
            this.cmdGo1b.Size = new System.Drawing.Size(100, 23);
            this.cmdGo1b.TabIndex = 11;
            this.cmdGo1b.Text = "Make UHashes";
            this.cmdGo1b.UseVisualStyleBackColor = true;
            this.cmdGo1b.Click += new System.EventHandler(this.cmdGo1b_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tLocalNames);
            this.groupBox6.Location = new System.Drawing.Point(12, 143);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 45);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hash from local file";
            // 
            // tLocalNames
            // 
            this.tLocalNames.Location = new System.Drawing.Point(6, 19);
            this.tLocalNames.Name = "tLocalNames";
            this.tLocalNames.Size = new System.Drawing.Size(206, 20);
            this.tLocalNames.TabIndex = 3;
            this.tLocalNames.Text = "userdb_names.txt";
            // 
            // cmdGo3s
            // 
            this.cmdGo3s.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGo3s.Location = new System.Drawing.Point(106, 405);
            this.cmdGo3s.Name = "cmdGo3s";
            this.cmdGo3s.Size = new System.Drawing.Size(12, 23);
            this.cmdGo3s.TabIndex = 12;
            this.cmdGo3s.Text = "s";
            this.cmdGo3s.UseVisualStyleBackColor = true;
            this.cmdGo3s.Click += new System.EventHandler(this.cmdGo3s_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 440);
            this.Controls.Add(this.cmdGo3s);
            this.Controls.Add(this.cmdGo1b);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cmdGo3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lDebug);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdGo2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdGo1a);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tPass;
        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tSumFile;
        private System.Windows.Forms.Button cmdGo1a;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tHashlog;
        private System.Windows.Forms.Button cmdGo2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tBotNames;
        public System.Windows.Forms.Label lDebug;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tURanks;
        private System.Windows.Forms.Button cmdGo3;
        private System.Windows.Forms.Button cmdGo1b;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tLocalNames;
        private System.Windows.Forms.Button cmdGo3s;
    }
}

