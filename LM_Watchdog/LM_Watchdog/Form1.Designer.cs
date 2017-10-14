namespace LM_Watchdog
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cUsrRem = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddKrim4 = new System.Windows.Forms.RadioButton();
            this.AddKrim3 = new System.Windows.Forms.RadioButton();
            this.AddKrim2 = new System.Windows.Forms.RadioButton();
            this.AddKrim1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddBil4 = new System.Windows.Forms.RadioButton();
            this.AddBil3 = new System.Windows.Forms.RadioButton();
            this.AddBil2 = new System.Windows.Forms.RadioButton();
            this.AddBil1 = new System.Windows.Forms.RadioButton();
            this.AddAdd = new System.Windows.Forms.Button();
            this.AddPress = new System.Windows.Forms.CheckBox();
            this.AddFC = new System.Windows.Forms.CheckBox();
            this.AddWarn = new System.Windows.Forms.CheckBox();
            this.AddAutoLoc = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvbList = new System.Windows.Forms.DataGridView();
            this.tMain = new System.Windows.Forms.Timer(this.components);
            this.zID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zLastRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvbList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cUsrRem);
            this.groupBox1.Controls.Add(this.lstUsers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 271);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lagrede brukere";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "Start alle";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start valgt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cUsrRem
            // 
            this.cUsrRem.Location = new System.Drawing.Point(6, 172);
            this.cUsrRem.Name = "cUsrRem";
            this.cUsrRem.Size = new System.Drawing.Size(126, 27);
            this.cUsrRem.TabIndex = 2;
            this.cUsrRem.Text = "Fjern bruker";
            this.cUsrRem.UseVisualStyleBackColor = true;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(6, 19);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(126, 147);
            this.lstUsers.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.AddAdd);
            this.groupBox2.Controls.Add(this.AddPress);
            this.groupBox2.Controls.Add(this.AddFC);
            this.groupBox2.Controls.Add(this.AddWarn);
            this.groupBox2.Controls.Add(this.AddAutoLoc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(156, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 271);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Legg til bruker";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AddKrim4);
            this.panel2.Controls.Add(this.AddKrim3);
            this.panel2.Controls.Add(this.AddKrim2);
            this.panel2.Controls.Add(this.AddKrim1);
            this.panel2.Location = new System.Drawing.Point(76, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 13);
            this.panel2.TabIndex = 29;
            // 
            // AddKrim4
            // 
            this.AddKrim4.AutoSize = true;
            this.AddKrim4.Location = new System.Drawing.Point(60, 0);
            this.AddKrim4.Name = "AddKrim4";
            this.AddKrim4.Size = new System.Drawing.Size(14, 13);
            this.AddKrim4.TabIndex = 26;
            this.AddKrim4.UseVisualStyleBackColor = true;
            // 
            // AddKrim3
            // 
            this.AddKrim3.AutoSize = true;
            this.AddKrim3.Location = new System.Drawing.Point(40, 0);
            this.AddKrim3.Name = "AddKrim3";
            this.AddKrim3.Size = new System.Drawing.Size(14, 13);
            this.AddKrim3.TabIndex = 25;
            this.AddKrim3.UseVisualStyleBackColor = true;
            // 
            // AddKrim2
            // 
            this.AddKrim2.AutoSize = true;
            this.AddKrim2.Location = new System.Drawing.Point(20, 0);
            this.AddKrim2.Name = "AddKrim2";
            this.AddKrim2.Size = new System.Drawing.Size(14, 13);
            this.AddKrim2.TabIndex = 24;
            this.AddKrim2.UseVisualStyleBackColor = true;
            // 
            // AddKrim1
            // 
            this.AddKrim1.AutoSize = true;
            this.AddKrim1.Checked = true;
            this.AddKrim1.Location = new System.Drawing.Point(0, 0);
            this.AddKrim1.Name = "AddKrim1";
            this.AddKrim1.Size = new System.Drawing.Size(14, 13);
            this.AddKrim1.TabIndex = 23;
            this.AddKrim1.TabStop = true;
            this.AddKrim1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddBil4);
            this.panel1.Controls.Add(this.AddBil3);
            this.panel1.Controls.Add(this.AddBil2);
            this.panel1.Controls.Add(this.AddBil1);
            this.panel1.Location = new System.Drawing.Point(76, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(74, 13);
            this.panel1.TabIndex = 28;
            // 
            // AddBil4
            // 
            this.AddBil4.AutoSize = true;
            this.AddBil4.Location = new System.Drawing.Point(60, 0);
            this.AddBil4.Name = "AddBil4";
            this.AddBil4.Size = new System.Drawing.Size(14, 13);
            this.AddBil4.TabIndex = 26;
            this.AddBil4.UseVisualStyleBackColor = true;
            // 
            // AddBil3
            // 
            this.AddBil3.AutoSize = true;
            this.AddBil3.Location = new System.Drawing.Point(40, 0);
            this.AddBil3.Name = "AddBil3";
            this.AddBil3.Size = new System.Drawing.Size(14, 13);
            this.AddBil3.TabIndex = 25;
            this.AddBil3.UseVisualStyleBackColor = true;
            // 
            // AddBil2
            // 
            this.AddBil2.AutoSize = true;
            this.AddBil2.Location = new System.Drawing.Point(20, 0);
            this.AddBil2.Name = "AddBil2";
            this.AddBil2.Size = new System.Drawing.Size(14, 13);
            this.AddBil2.TabIndex = 24;
            this.AddBil2.UseVisualStyleBackColor = true;
            // 
            // AddBil1
            // 
            this.AddBil1.AutoSize = true;
            this.AddBil1.Checked = true;
            this.AddBil1.Location = new System.Drawing.Point(0, 0);
            this.AddBil1.Name = "AddBil1";
            this.AddBil1.Size = new System.Drawing.Size(14, 13);
            this.AddBil1.TabIndex = 23;
            this.AddBil1.TabStop = true;
            this.AddBil1.UseVisualStyleBackColor = true;
            // 
            // AddAdd
            // 
            this.AddAdd.Location = new System.Drawing.Point(6, 238);
            this.AddAdd.Name = "AddAdd";
            this.AddAdd.Size = new System.Drawing.Size(170, 27);
            this.AddAdd.TabIndex = 27;
            this.AddAdd.Text = "Legg til bruker";
            this.AddAdd.UseVisualStyleBackColor = true;
            // 
            // AddPress
            // 
            this.AddPress.AutoSize = true;
            this.AddPress.Checked = true;
            this.AddPress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddPress.Location = new System.Drawing.Point(76, 100);
            this.AddPress.Name = "AddPress";
            this.AddPress.Size = new System.Drawing.Size(15, 14);
            this.AddPress.TabIndex = 26;
            this.AddPress.UseVisualStyleBackColor = true;
            // 
            // AddFC
            // 
            this.AddFC.AutoSize = true;
            this.AddFC.Checked = true;
            this.AddFC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddFC.Location = new System.Drawing.Point(76, 150);
            this.AddFC.Name = "AddFC";
            this.AddFC.Size = new System.Drawing.Size(15, 14);
            this.AddFC.TabIndex = 25;
            this.AddFC.UseVisualStyleBackColor = true;
            // 
            // AddWarn
            // 
            this.AddWarn.AutoSize = true;
            this.AddWarn.Location = new System.Drawing.Point(76, 175);
            this.AddWarn.Name = "AddWarn";
            this.AddWarn.Size = new System.Drawing.Size(15, 14);
            this.AddWarn.TabIndex = 24;
            this.AddWarn.UseVisualStyleBackColor = true;
            // 
            // AddAutoLoc
            // 
            this.AddAutoLoc.AutoSize = true;
            this.AddAutoLoc.Checked = true;
            this.AddAutoLoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddAutoLoc.Location = new System.Drawing.Point(76, 200);
            this.AddAutoLoc.Name = "AddAutoLoc";
            this.AddAutoLoc.Size = new System.Drawing.Size(15, 14);
            this.AddAutoLoc.TabIndex = 23;
            this.AddAutoLoc.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Autoplasser";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Advarsler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fightclub";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Biltyveri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Utpressing";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kriminalitet";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Passord";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brukernavn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvbList);
            this.groupBox3.Location = new System.Drawing.Point(344, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 271);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aktive bots";
            // 
            // gvbList
            // 
            this.gvbList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvbList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zID,
            this.zUser,
            this.zStatus,
            this.zLastRS});
            this.gvbList.Location = new System.Drawing.Point(6, 19);
            this.gvbList.Name = "gvbList";
            this.gvbList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvbList.Size = new System.Drawing.Size(381, 246);
            this.gvbList.TabIndex = 0;
            // 
            // tMain
            // 
            this.tMain.Enabled = true;
            this.tMain.Interval = 5000;
            this.tMain.Tick += new System.EventHandler(this.tMain_Tick);
            // 
            // zID
            // 
            this.zID.Frozen = true;
            this.zID.HeaderText = "ID";
            this.zID.MinimumWidth = 60;
            this.zID.Name = "zID";
            this.zID.ReadOnly = true;
            this.zID.Width = 60;
            // 
            // zUser
            // 
            this.zUser.Frozen = true;
            this.zUser.HeaderText = "User";
            this.zUser.MinimumWidth = 100;
            this.zUser.Name = "zUser";
            this.zUser.ReadOnly = true;
            // 
            // zStatus
            // 
            this.zStatus.Frozen = true;
            this.zStatus.HeaderText = "Status";
            this.zStatus.MinimumWidth = 60;
            this.zStatus.Name = "zStatus";
            this.zStatus.ReadOnly = true;
            this.zStatus.Width = 60;
            // 
            // zLastRS
            // 
            this.zLastRS.Frozen = true;
            this.zLastRS.HeaderText = "Siste krasj";
            this.zLastRS.MinimumWidth = 100;
            this.zLastRS.Name = "zLastRS";
            this.zLastRS.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 295);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "LM Watchdog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvbList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button cUsrRem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox AddPress;
        private System.Windows.Forms.CheckBox AddFC;
        private System.Windows.Forms.CheckBox AddWarn;
        private System.Windows.Forms.CheckBox AddAutoLoc;
        private System.Windows.Forms.Button AddAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton AddBil4;
        private System.Windows.Forms.RadioButton AddBil3;
        private System.Windows.Forms.RadioButton AddBil2;
        private System.Windows.Forms.RadioButton AddBil1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton AddKrim4;
        private System.Windows.Forms.RadioButton AddKrim3;
        private System.Windows.Forms.RadioButton AddKrim2;
        private System.Windows.Forms.RadioButton AddKrim1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gvbList;
        private System.Windows.Forms.Timer tMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn zID;
        private System.Windows.Forms.DataGridViewTextBoxColumn zUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn zStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn zLastRS;
    }
}

