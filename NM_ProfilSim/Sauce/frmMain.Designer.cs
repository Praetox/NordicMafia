namespace ProfilSim
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
            this.tx = new System.Windows.Forms.TextBox();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.cCol = new System.Windows.Forms.Button();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.cU = new System.Windows.Forms.Button();
            this.cB = new System.Windows.Forms.Button();
            this.cI = new System.Windows.Forms.Button();
            this.cGra = new System.Windows.Forms.Button();
            this.chkLinjal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tx
            // 
            this.tx.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx.Location = new System.Drawing.Point(0, 363);
            this.tx.Multiline = true;
            this.tx.Name = "tx";
            this.tx.Size = new System.Drawing.Size(901, 76);
            this.tx.TabIndex = 0;
            this.tx.Text = resources.GetString("tx.Text");
            this.tx.TextChanged += new System.EventHandler(this.tx_TextChanged);
            this.tx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_KeyDown);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(901, 363);
            this.wb.TabIndex = 1;
            // 
            // cCol
            // 
            this.cCol.Location = new System.Drawing.Point(0, 340);
            this.cCol.Name = "cCol";
            this.cCol.Size = new System.Drawing.Size(42, 23);
            this.cCol.TabIndex = 2;
            this.cCol.Text = "Farge";
            this.Tip.SetToolTip(this.cCol, "Velg skriftfarge (Ctrl+F)");
            this.cCol.UseVisualStyleBackColor = true;
            this.cCol.Click += new System.EventHandler(this.cCol_Click);
            // 
            // Tip
            // 
            this.Tip.AutomaticDelay = 0;
            this.Tip.AutoPopDelay = 5000;
            this.Tip.InitialDelay = 0;
            this.Tip.ReshowDelay = 100;
            // 
            // cU
            // 
            this.cU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cU.Location = new System.Drawing.Point(106, 340);
            this.cU.Name = "cU";
            this.cU.Size = new System.Drawing.Size(23, 23);
            this.cU.TabIndex = 3;
            this.cU.Text = "U";
            this.Tip.SetToolTip(this.cU, "Understreket skrift (Ctrl+D)");
            this.cU.UseVisualStyleBackColor = true;
            this.cU.Click += new System.EventHandler(this.cU_Click);
            // 
            // cB
            // 
            this.cB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB.Location = new System.Drawing.Point(48, 340);
            this.cB.Name = "cB";
            this.cB.Size = new System.Drawing.Size(23, 23);
            this.cB.TabIndex = 4;
            this.cB.Text = "B";
            this.Tip.SetToolTip(this.cB, "Fet skrift (Ctrl+A)");
            this.cB.UseVisualStyleBackColor = true;
            this.cB.Click += new System.EventHandler(this.cB_Click);
            // 
            // cI
            // 
            this.cI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cI.Location = new System.Drawing.Point(77, 340);
            this.cI.Name = "cI";
            this.cI.Size = new System.Drawing.Size(23, 23);
            this.cI.TabIndex = 5;
            this.cI.Text = "I";
            this.Tip.SetToolTip(this.cI, "Kursiv skrift (Ctrl+S)");
            this.cI.UseVisualStyleBackColor = true;
            this.cI.Click += new System.EventHandler(this.cI_Click);
            // 
            // cGra
            // 
            this.cGra.Location = new System.Drawing.Point(135, 340);
            this.cGra.Name = "cGra";
            this.cGra.Size = new System.Drawing.Size(56, 23);
            this.cGra.TabIndex = 6;
            this.cGra.Text = "Gradient";
            this.Tip.SetToolTip(this.cGra, "Skrift som endrer farge gradvis");
            this.cGra.UseVisualStyleBackColor = true;
            this.cGra.Visible = false;
            // 
            // chkLinjal
            // 
            this.chkLinjal.AutoSize = true;
            this.chkLinjal.BackColor = System.Drawing.Color.Black;
            this.chkLinjal.ForeColor = System.Drawing.Color.Goldenrod;
            this.chkLinjal.Location = new System.Drawing.Point(0, 317);
            this.chkLinjal.Name = "chkLinjal";
            this.chkLinjal.Size = new System.Drawing.Size(50, 17);
            this.chkLinjal.TabIndex = 7;
            this.chkLinjal.Text = "Linjal";
            this.chkLinjal.UseVisualStyleBackColor = false;
            this.chkLinjal.CheckedChanged += new System.EventHandler(this.chkLinjal_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 439);
            this.Controls.Add(this.chkLinjal);
            this.Controls.Add(this.cGra);
            this.Controls.Add(this.cI);
            this.Controls.Add(this.cB);
            this.Controls.Add(this.cU);
            this.Controls.Add(this.cCol);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.tx);
            this.Name = "frmMain";
            this.Text = "Praetox | NM ProfilSim";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Button cCol;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.Button cU;
        private System.Windows.Forms.Button cB;
        private System.Windows.Forms.Button cI;
        private System.Windows.Forms.Button cGra;
        private System.Windows.Forms.CheckBox chkLinjal;
    }
}

