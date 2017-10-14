namespace NM_Broadcast
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
            this.txTopic = new System.Windows.Forms.TextBox();
            this.txMsg = new System.Windows.Forms.TextBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.tUser = new System.Windows.Forms.TextBox();
            this.tPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txTopic
            // 
            this.txTopic.Location = new System.Drawing.Point(302, 12);
            this.txTopic.Name = "txTopic";
            this.txTopic.Size = new System.Drawing.Size(341, 20);
            this.txTopic.TabIndex = 0;
            this.txTopic.Text = "Det er på tide å ta kontroll.";
            // 
            // txMsg
            // 
            this.txMsg.Location = new System.Drawing.Point(12, 38);
            this.txMsg.Multiline = true;
            this.txMsg.Name = "txMsg";
            this.txMsg.Size = new System.Drawing.Size(666, 297);
            this.txMsg.TabIndex = 1;
            this.txMsg.Text = "Vil du delta i revolusjonen? Vis verden at Norge er best!\r\n\r\nhttp://praetox.mymin" +
                "icity.com/ind";
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(649, 10);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(29, 23);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = ">";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(12, 12);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(139, 20);
            this.tUser.TabIndex = 4;
            // 
            // tPass
            // 
            this.tPass.Location = new System.Drawing.Point(157, 12);
            this.tPass.Name = "tPass";
            this.tPass.Size = new System.Drawing.Size(139, 20);
            this.tPass.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 347);
            this.Controls.Add(this.tPass);
            this.Controls.Add(this.tUser);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.txMsg);
            this.Controls.Add(this.txTopic);
            this.Name = "Form1";
            this.Text = "NM Broadcaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txTopic;
        private System.Windows.Forms.TextBox txMsg;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.TextBox tPass;
    }
}

