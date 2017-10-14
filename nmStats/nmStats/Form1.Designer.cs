namespace nmStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sPass = new System.Windows.Forms.TextBox();
            this.sUser = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdStep3a = new System.Windows.Forms.Button();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdStep1 = new System.Windows.Forms.Button();
            this.txtStep1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdStep2b = new System.Windows.Forms.Button();
            this.txtStep2 = new System.Windows.Forms.TextBox();
            this.cmdStep2a = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tEmbeds = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sPass);
            this.groupBox1.Controls.Add(this.sUser);
            this.groupBox1.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nordicmafia account access information";
            // 
            // sPass
            // 
            this.sPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sPass.ForeColor = System.Drawing.Color.White;
            this.sPass.Location = new System.Drawing.Point(291, 19);
            this.sPass.Name = "sPass";
            this.sPass.PasswordChar = '*';
            this.sPass.Size = new System.Drawing.Size(278, 20);
            this.sPass.TabIndex = 2;
            this.sPass.Text = "1qaz2wsx";
            // 
            // sUser
            // 
            this.sUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sUser.ForeColor = System.Drawing.Color.White;
            this.sUser.Location = new System.Drawing.Point(6, 19);
            this.sUser.Name = "sUser";
            this.sUser.Size = new System.Drawing.Size(278, 20);
            this.sUser.TabIndex = 1;
            this.sUser.Text = "Diclonius";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tEmbeds);
            this.groupBox2.Controls.Add(this.cmdStep3a);
            this.groupBox2.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Location = new System.Drawing.Point(609, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 385);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 3 - Export";
            // 
            // cmdStep3a
            // 
            this.cmdStep3a.ForeColor = System.Drawing.Color.Black;
            this.cmdStep3a.Location = new System.Drawing.Point(6, 19);
            this.cmdStep3a.Name = "cmdStep3a";
            this.cmdStep3a.Size = new System.Drawing.Size(188, 21);
            this.cmdStep3a.TabIndex = 3;
            this.cmdStep3a.Text = "Generate HTML documents";
            this.cmdStep3a.UseVisualStyleBackColor = true;
            this.cmdStep3a.Click += new System.EventHandler(this.cmdStep3_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(-500, -500);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(66, 50);
            this.wb.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdStep1);
            this.groupBox3.Controls.Add(this.txtStep1);
            this.groupBox3.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Location = new System.Drawing.Point(12, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 154);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 1 - Download online list";
            // 
            // cmdStep1
            // 
            this.cmdStep1.ForeColor = System.Drawing.Color.Black;
            this.cmdStep1.Location = new System.Drawing.Point(6, 126);
            this.cmdStep1.Name = "cmdStep1";
            this.cmdStep1.Size = new System.Drawing.Size(563, 21);
            this.cmdStep1.TabIndex = 6;
            this.cmdStep1.Text = "Download complete online list (append if exist)";
            this.cmdStep1.UseVisualStyleBackColor = true;
            this.cmdStep1.Click += new System.EventHandler(this.cmdStep1_Click);
            // 
            // txtStep1
            // 
            this.txtStep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStep1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStep1.ForeColor = System.Drawing.Color.White;
            this.txtStep1.Location = new System.Drawing.Point(6, 15);
            this.txtStep1.Multiline = true;
            this.txtStep1.Name = "txtStep1";
            this.txtStep1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStep1.Size = new System.Drawing.Size(563, 105);
            this.txtStep1.TabIndex = 5;
            this.txtStep1.Text = resources.GetString("txtStep1.Text");
            this.txtStep1.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdStep2b);
            this.groupBox4.Controls.Add(this.txtStep2);
            this.groupBox4.Controls.Add(this.cmdStep2a);
            this.groupBox4.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox4.Location = new System.Drawing.Point(12, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(575, 154);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 2 - Read user information";
            // 
            // cmdStep2b
            // 
            this.cmdStep2b.ForeColor = System.Drawing.Color.Black;
            this.cmdStep2b.Location = new System.Drawing.Point(291, 126);
            this.cmdStep2b.Name = "cmdStep2b";
            this.cmdStep2b.Size = new System.Drawing.Size(278, 21);
            this.cmdStep2b.TabIndex = 7;
            this.cmdStep2b.Text = "Update each and every object";
            this.cmdStep2b.UseVisualStyleBackColor = true;
            this.cmdStep2b.Click += new System.EventHandler(this.cmdStep2b_Click);
            // 
            // txtStep2
            // 
            this.txtStep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStep2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStep2.ForeColor = System.Drawing.Color.White;
            this.txtStep2.Location = new System.Drawing.Point(6, 15);
            this.txtStep2.Multiline = true;
            this.txtStep2.Name = "txtStep2";
            this.txtStep2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStep2.Size = new System.Drawing.Size(563, 105);
            this.txtStep2.TabIndex = 5;
            this.txtStep2.Text = resources.GetString("txtStep2.Text");
            this.txtStep2.WordWrap = false;
            // 
            // cmdStep2a
            // 
            this.cmdStep2a.ForeColor = System.Drawing.Color.Black;
            this.cmdStep2a.Location = new System.Drawing.Point(6, 126);
            this.cmdStep2a.Name = "cmdStep2a";
            this.cmdStep2a.Size = new System.Drawing.Size(278, 21);
            this.cmdStep2a.TabIndex = 6;
            this.cmdStep2a.Text = "Update alien objects";
            this.cmdStep2a.UseVisualStyleBackColor = true;
            this.cmdStep2a.Click += new System.EventHandler(this.cmdStep2a_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(9, 404);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(805, 13);
            this.Status.TabIndex = 6;
            this.Status.Text = resources.GetString("Status.Text");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(146, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 10);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(146, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 10);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(593, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 10);
            this.label4.TabIndex = 9;
            // 
            // tEmbeds
            // 
            this.tEmbeds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tEmbeds.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEmbeds.ForeColor = System.Drawing.Color.White;
            this.tEmbeds.Location = new System.Drawing.Point(6, 46);
            this.tEmbeds.Multiline = true;
            this.tEmbeds.Name = "tEmbeds";
            this.tEmbeds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tEmbeds.Size = new System.Drawing.Size(188, 332);
            this.tEmbeds.TabIndex = 6;
            this.tEmbeds.WordWrap = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(821, 424);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "nmStats | www.praetox.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox sPass;
        private System.Windows.Forms.TextBox sUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Button cmdStep3a;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdStep1;
        private System.Windows.Forms.TextBox txtStep1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdStep2a;
        private System.Windows.Forms.TextBox txtStep2;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdStep2b;
        private System.Windows.Forms.TextBox tEmbeds;
    }
}

