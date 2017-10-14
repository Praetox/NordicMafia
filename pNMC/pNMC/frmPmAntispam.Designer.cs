namespace pNMC
{
    partial class frmPmAntispam
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tNicks = new System.Windows.Forms.TextBox();
            this.tTopics = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tNicks);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fjern alle meldinger fra følgende brukere";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tTopics);
            this.groupBox2.Location = new System.Drawing.Point(243, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 255);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fjern meldinger med følgende emnetitler";
            // 
            // tNicks
            // 
            this.tNicks.Location = new System.Drawing.Point(6, 19);
            this.tNicks.Multiline = true;
            this.tNicks.Name = "tNicks";
            this.tNicks.Size = new System.Drawing.Size(213, 230);
            this.tNicks.TabIndex = 0;
            // 
            // tTopics
            // 
            this.tTopics.Location = new System.Drawing.Point(6, 19);
            this.tTopics.Multiline = true;
            this.tTopics.Name = "tTopics";
            this.tTopics.Size = new System.Drawing.Size(213, 230);
            this.tTopics.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Skriv et brukernavn/emne per linje. Lagre ved å lukke dette vinduet.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPmAntispam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPmAntispam";
            this.Text = "Konfigurasjon";
            this.Load += new System.EventHandler(this.frmPmAntispam_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPmAntispam_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tNicks;
        private System.Windows.Forms.TextBox tTopics;
        private System.Windows.Forms.Label label1;
    }
}