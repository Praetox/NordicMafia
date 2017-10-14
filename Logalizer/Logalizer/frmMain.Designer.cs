namespace Logalizer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPIP = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPClk = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPVer = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gbClk = new System.Windows.Forms.GroupBox();
            this.cmdUniqueIDIP = new System.Windows.Forms.Button();
            this.cbClk = new System.Windows.Forms.ComboBox();
            this.gbIP = new System.Windows.Forms.GroupBox();
            this.chkUniqueIP = new System.Windows.Forms.CheckBox();
            this.cmdUniqueIP = new System.Windows.Forms.Button();
            this.cbIP = new System.Windows.Forms.ComboBox();
            this.gbVer = new System.Windows.Forms.GroupBox();
            this.cbVer = new System.Windows.Forms.ComboBox();
            this.gbID = new System.Windows.Forms.GroupBox();
            this.chkUniqueID = new System.Windows.Forms.CheckBox();
            this.cmdUniqueID = new System.Windows.Forms.Button();
            this.cbID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAnalyze = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbReport = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grClk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdPasteLog = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbClk.SuspendLayout();
            this.gbIP.SuspendLayout();
            this.gbVer.SuspendLayout();
            this.gbID.SuspendLayout();
            this.gbReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log format";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPIP);
            this.groupBox2.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Location = new System.Drawing.Point(210, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(62, 45);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IP";
            // 
            // txtPIP
            // 
            this.txtPIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.txtPIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPIP.ForeColor = System.Drawing.Color.White;
            this.txtPIP.Location = new System.Drawing.Point(6, 19);
            this.txtPIP.Name = "txtPIP";
            this.txtPIP.Size = new System.Drawing.Size(50, 20);
            this.txtPIP.TabIndex = 1;
            this.txtPIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtPClk);
            this.groupBox5.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(62, 45);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Clk";
            // 
            // txtPClk
            // 
            this.txtPClk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.txtPClk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPClk.ForeColor = System.Drawing.Color.White;
            this.txtPClk.Location = new System.Drawing.Point(6, 19);
            this.txtPClk.Name = "txtPClk";
            this.txtPClk.Size = new System.Drawing.Size(50, 20);
            this.txtPClk.TabIndex = 1;
            this.txtPClk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPVer);
            this.groupBox4.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox4.Location = new System.Drawing.Point(74, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(62, 45);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ver";
            // 
            // txtPVer
            // 
            this.txtPVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.txtPVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPVer.ForeColor = System.Drawing.Color.White;
            this.txtPVer.Location = new System.Drawing.Point(6, 19);
            this.txtPVer.Name = "txtPVer";
            this.txtPVer.Size = new System.Drawing.Size(50, 20);
            this.txtPVer.TabIndex = 1;
            this.txtPVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPID);
            this.groupBox3.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Location = new System.Drawing.Point(142, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(62, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ID";
            // 
            // txtPID
            // 
            this.txtPID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.txtPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPID.ForeColor = System.Drawing.Color.White;
            this.txtPID.Location = new System.Drawing.Point(6, 19);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(50, 20);
            this.txtPID.TabIndex = 1;
            this.txtPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gbClk);
            this.groupBox7.Controls.Add(this.gbIP);
            this.groupBox7.Controls.Add(this.gbVer);
            this.groupBox7.Controls.Add(this.gbID);
            this.groupBox7.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox7.Location = new System.Drawing.Point(12, 300);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(278, 219);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Get statistics for";
            // 
            // gbClk
            // 
            this.gbClk.Controls.Add(this.cmdUniqueIDIP);
            this.gbClk.Controls.Add(this.cbClk);
            this.gbClk.ForeColor = System.Drawing.Color.LightBlue;
            this.gbClk.Location = new System.Drawing.Point(6, 19);
            this.gbClk.Name = "gbClk";
            this.gbClk.Size = new System.Drawing.Size(266, 44);
            this.gbClk.TabIndex = 4;
            this.gbClk.TabStop = false;
            this.gbClk.Text = "Date";
            // 
            // cmdUniqueIDIP
            // 
            this.cmdUniqueIDIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cmdUniqueIDIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUniqueIDIP.Location = new System.Drawing.Point(198, 19);
            this.cmdUniqueIDIP.Name = "cmdUniqueIDIP";
            this.cmdUniqueIDIP.Size = new System.Drawing.Size(62, 19);
            this.cmdUniqueIDIP.TabIndex = 12;
            this.cmdUniqueIDIP.Text = "UNIQUE";
            this.cmdUniqueIDIP.UseVisualStyleBackColor = false;
            this.cmdUniqueIDIP.Click += new System.EventHandler(this.cmdUniqueIDIP_Click);
            // 
            // cbClk
            // 
            this.cbClk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cbClk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbClk.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClk.ForeColor = System.Drawing.Color.White;
            this.cbClk.FormattingEnabled = true;
            this.cbClk.Location = new System.Drawing.Point(6, 19);
            this.cbClk.Name = "cbClk";
            this.cbClk.Size = new System.Drawing.Size(186, 19);
            this.cbClk.TabIndex = 0;
            this.cbClk.SelectedIndexChanged += new System.EventHandler(this.cbDate_SelectedIndexChanged);
            // 
            // gbIP
            // 
            this.gbIP.Controls.Add(this.chkUniqueIP);
            this.gbIP.Controls.Add(this.cmdUniqueIP);
            this.gbIP.Controls.Add(this.cbIP);
            this.gbIP.ForeColor = System.Drawing.Color.LightBlue;
            this.gbIP.Location = new System.Drawing.Point(6, 169);
            this.gbIP.Name = "gbIP";
            this.gbIP.Size = new System.Drawing.Size(266, 44);
            this.gbIP.TabIndex = 1;
            this.gbIP.TabStop = false;
            this.gbIP.Text = "IP address";
            // 
            // chkUniqueIP
            // 
            this.chkUniqueIP.Location = new System.Drawing.Point(6, 23);
            this.chkUniqueIP.Name = "chkUniqueIP";
            this.chkUniqueIP.Size = new System.Drawing.Size(13, 12);
            this.chkUniqueIP.TabIndex = 1;
            this.chkUniqueIP.UseVisualStyleBackColor = true;
            // 
            // cmdUniqueIP
            // 
            this.cmdUniqueIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cmdUniqueIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUniqueIP.Location = new System.Drawing.Point(198, 19);
            this.cmdUniqueIP.Name = "cmdUniqueIP";
            this.cmdUniqueIP.Size = new System.Drawing.Size(62, 19);
            this.cmdUniqueIP.TabIndex = 15;
            this.cmdUniqueIP.Text = "UNIQUE";
            this.cmdUniqueIP.UseVisualStyleBackColor = false;
            this.cmdUniqueIP.Click += new System.EventHandler(this.cmdUniqueIP_Click);
            // 
            // cbIP
            // 
            this.cbIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cbIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbIP.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIP.ForeColor = System.Drawing.Color.White;
            this.cbIP.FormattingEnabled = true;
            this.cbIP.Location = new System.Drawing.Point(25, 19);
            this.cbIP.Name = "cbIP";
            this.cbIP.Size = new System.Drawing.Size(167, 19);
            this.cbIP.TabIndex = 2;
            this.cbIP.SelectedIndexChanged += new System.EventHandler(this.cbIP_SelectedIndexChanged);
            // 
            // gbVer
            // 
            this.gbVer.Controls.Add(this.cbVer);
            this.gbVer.ForeColor = System.Drawing.Color.LightBlue;
            this.gbVer.Location = new System.Drawing.Point(6, 69);
            this.gbVer.Name = "gbVer";
            this.gbVer.Size = new System.Drawing.Size(266, 44);
            this.gbVer.TabIndex = 3;
            this.gbVer.TabStop = false;
            this.gbVer.Text = "Version";
            // 
            // cbVer
            // 
            this.cbVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cbVer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbVer.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVer.ForeColor = System.Drawing.Color.White;
            this.cbVer.FormattingEnabled = true;
            this.cbVer.Location = new System.Drawing.Point(6, 19);
            this.cbVer.Name = "cbVer";
            this.cbVer.Size = new System.Drawing.Size(254, 19);
            this.cbVer.TabIndex = 0;
            this.cbVer.SelectedIndexChanged += new System.EventHandler(this.cbVer_SelectedIndexChanged);
            // 
            // gbID
            // 
            this.gbID.Controls.Add(this.chkUniqueID);
            this.gbID.Controls.Add(this.cmdUniqueID);
            this.gbID.Controls.Add(this.cbID);
            this.gbID.ForeColor = System.Drawing.Color.LightBlue;
            this.gbID.Location = new System.Drawing.Point(6, 119);
            this.gbID.Name = "gbID";
            this.gbID.Size = new System.Drawing.Size(266, 44);
            this.gbID.TabIndex = 2;
            this.gbID.TabStop = false;
            this.gbID.Text = "Identification";
            // 
            // chkUniqueID
            // 
            this.chkUniqueID.Location = new System.Drawing.Point(6, 23);
            this.chkUniqueID.Name = "chkUniqueID";
            this.chkUniqueID.Size = new System.Drawing.Size(13, 12);
            this.chkUniqueID.TabIndex = 15;
            this.chkUniqueID.UseVisualStyleBackColor = true;
            // 
            // cmdUniqueID
            // 
            this.cmdUniqueID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cmdUniqueID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUniqueID.Location = new System.Drawing.Point(198, 19);
            this.cmdUniqueID.Name = "cmdUniqueID";
            this.cmdUniqueID.Size = new System.Drawing.Size(62, 19);
            this.cmdUniqueID.TabIndex = 14;
            this.cmdUniqueID.Text = "UNIQUE";
            this.cmdUniqueID.UseVisualStyleBackColor = false;
            this.cmdUniqueID.Click += new System.EventHandler(this.cmdUniqueID_Click);
            // 
            // cbID
            // 
            this.cbID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cbID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbID.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbID.ForeColor = System.Drawing.Color.White;
            this.cbID.FormattingEnabled = true;
            this.cbID.Location = new System.Drawing.Point(25, 19);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(167, 19);
            this.cbID.TabIndex = 1;
            this.cbID.SelectedIndexChanged += new System.EventHandler(this.cbID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 4;
            // 
            // cmdAnalyze
            // 
            this.cmdAnalyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cmdAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAnalyze.Location = new System.Drawing.Point(12, 202);
            this.cmdAnalyze.Name = "cmdAnalyze";
            this.cmdAnalyze.Size = new System.Drawing.Size(278, 76);
            this.cmdAnalyze.TabIndex = 3;
            this.cmdAnalyze.Text = "S t a r t     a n a l y z i n g";
            this.cmdAnalyze.UseVisualStyleBackColor = false;
            this.cmdAnalyze.Click += new System.EventHandler(this.cmdAnalyze_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(296, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 8);
            this.label4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightBlue;
            this.label5.Location = new System.Drawing.Point(310, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 513);
            this.label5.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(317, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 8);
            this.label6.TabIndex = 9;
            // 
            // gbReport
            // 
            this.gbReport.Controls.Add(this.dgv);
            this.gbReport.ForeColor = System.Drawing.Color.LightBlue;
            this.gbReport.Location = new System.Drawing.Point(331, 12);
            this.gbReport.Name = "gbReport";
            this.gbReport.Size = new System.Drawing.Size(467, 507);
            this.gbReport.TabIndex = 2;
            this.gbReport.TabStop = false;
            this.gbReport.Text = "Report";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LightBlue;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grClk,
            this.grVer,
            this.grID,
            this.grIP});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.GridColor = System.Drawing.Color.LightBlue;
            this.dgv.Location = new System.Drawing.Point(6, 19);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 16;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.Size = new System.Drawing.Size(455, 482);
            this.dgv.TabIndex = 0;
            // 
            // grClk
            // 
            this.grClk.Frozen = true;
            this.grClk.HeaderText = "Date";
            this.grClk.Name = "grClk";
            this.grClk.ReadOnly = true;
            this.grClk.Width = 130;
            // 
            // grVer
            // 
            this.grVer.Frozen = true;
            this.grVer.HeaderText = "Version";
            this.grVer.Name = "grVer";
            this.grVer.ReadOnly = true;
            this.grVer.Width = 75;
            // 
            // grID
            // 
            this.grID.Frozen = true;
            this.grID.HeaderText = "Ident";
            this.grID.Name = "grID";
            this.grID.ReadOnly = true;
            this.grID.Width = 117;
            // 
            // grIP
            // 
            this.grIP.Frozen = true;
            this.grIP.HeaderText = "IP addr.";
            this.grIP.Name = "grIP";
            this.grIP.ReadOnly = true;
            this.grIP.Width = 117;
            // 
            // cmdPasteLog
            // 
            this.cmdPasteLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.cmdPasteLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPasteLog.Location = new System.Drawing.Point(12, 104);
            this.cmdPasteLog.Name = "cmdPasteLog";
            this.cmdPasteLog.Size = new System.Drawing.Size(278, 76);
            this.cmdPasteLog.TabIndex = 2;
            this.cmdPasteLog.Text = "R e a d     l o g";
            this.cmdPasteLog.UseVisualStyleBackColor = false;
            this.cmdPasteLog.Click += new System.EventHandler(this.cmdPasteLog_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 11;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(810, 531);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmdPasteLog);
            this.Controls.Add(this.gbReport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdAnalyze);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.Name = "frmMain";
            this.Text = "Logalizer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.gbClk.ResumeLayout(false);
            this.gbIP.ResumeLayout(false);
            this.gbVer.ResumeLayout(false);
            this.gbID.ResumeLayout(false);
            this.gbReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtPClk;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPVer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPIP;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox gbIP;
        private System.Windows.Forms.GroupBox gbVer;
        private System.Windows.Forms.ComboBox cbVer;
        private System.Windows.Forms.GroupBox gbID;
        private System.Windows.Forms.ComboBox cbIP;
        private System.Windows.Forms.ComboBox cbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAnalyze;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbReport;
        private System.Windows.Forms.GroupBox gbClk;
        private System.Windows.Forms.ComboBox cbClk;
        private System.Windows.Forms.Button cmdPasteLog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button cmdUniqueIDIP;
        private System.Windows.Forms.Button cmdUniqueIP;
        private System.Windows.Forms.Button cmdUniqueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn grClk;
        private System.Windows.Forms.DataGridViewTextBoxColumn grVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn grID;
        private System.Windows.Forms.DataGridViewTextBoxColumn grIP;
        private System.Windows.Forms.CheckBox chkUniqueIP;
        private System.Windows.Forms.CheckBox chkUniqueID;
    }
}

