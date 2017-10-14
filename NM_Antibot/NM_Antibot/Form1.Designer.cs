namespace NM_Antibot
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
            this.pBox = new System.Windows.Forms.PictureBox();
            this.cmdIdent = new System.Windows.Forms.Button();
            this.tCols = new System.Windows.Forms.TextBox();
            this.cmdVerify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(12, 12);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(90, 65);
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            this.pBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBox_MouseDown);
            this.pBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBox_MouseMove);
            this.pBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBox_MouseUp);
            // 
            // cmdIdent
            // 
            this.cmdIdent.Location = new System.Drawing.Point(108, 12);
            this.cmdIdent.Name = "cmdIdent";
            this.cmdIdent.Size = new System.Drawing.Size(75, 29);
            this.cmdIdent.TabIndex = 1;
            this.cmdIdent.Text = "Identify";
            this.cmdIdent.UseVisualStyleBackColor = true;
            this.cmdIdent.Click += new System.EventHandler(this.cmdIdent_Click);
            // 
            // tCols
            // 
            this.tCols.Location = new System.Drawing.Point(12, 83);
            this.tCols.Multiline = true;
            this.tCols.Name = "tCols";
            this.tCols.Size = new System.Drawing.Size(307, 171);
            this.tCols.TabIndex = 2;
            this.tCols.Text = "5921631p470p500p10";
            // 
            // cmdVerify
            // 
            this.cmdVerify.Location = new System.Drawing.Point(108, 48);
            this.cmdVerify.Name = "cmdVerify";
            this.cmdVerify.Size = new System.Drawing.Size(75, 29);
            this.cmdVerify.TabIndex = 3;
            this.cmdVerify.Text = "Verify";
            this.cmdVerify.UseVisualStyleBackColor = true;
            this.cmdVerify.Click += new System.EventHandler(this.cmdVerify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 266);
            this.Controls.Add(this.cmdVerify);
            this.Controls.Add(this.tCols);
            this.Controls.Add(this.cmdIdent);
            this.Controls.Add(this.pBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button cmdIdent;
        private System.Windows.Forms.TextBox tCols;
        private System.Windows.Forms.Button cmdVerify;
    }
}

