using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Collections;
using System.Runtime.InteropServices;

namespace ProfilSim
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        
        private string NM_Raw = "";
        private string Linjal = "[color=#111111]________________[/color][color=#705020]|[/color][color=#111111]q________[/color][color=#E0B040]|[/color][color=#111111]q________[/color][color=#705020]|[/color][color=#111111]q________[/color][color=#FFFFFF]|[/color][color=#111111]q________[/color][color=#705020]|[/color][color=#111111]q________[/color][color=#E0B040]|[/color][color=#111111]q________[/color][color=#705020]|[/color]";
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            wb.Size = new Size(this.Width - 8, this.Height - 110);
            tx.Location = new Point(0, wb.Height);
            tx.Size = new Size(this.Width - 8, 76);
            cCol.Location = new Point(cCol.Left, wb.Height - 23);
            cB.Location = new Point(cCol.Left + cCol.Width + 6, cCol.Top);
            cI.Location = new Point(cB.Left + cB.Width + 6, cCol.Top);
            cU.Location = new Point(cI.Left + cI.Width + 6, cCol.Top);
            cGra.Location = new Point(cU.Left + cU.Width + 6, cCol.Top);
            chkLinjal.Location = new Point(chkLinjal.Left, wb.Height - 46);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "NM ProfilSim v" + Application.ProductVersion + " | http://praetox.atspace.com";
            System.Net.WebClient wc = new System.Net.WebClient();
            NM_Raw = wc.DownloadString("http://tib.110mb.com/ProfilSim_NMRaw.txt");
            Linjal = Linjal.Replace("|", "·");
            MakeProfile(tx.Text);
        }
        private void chkLinjal_CheckedChanged(object sender, EventArgs e)
        {
            tx_TextChanged(new object(), new EventArgs());
        }
        private void tx_TextChanged(object sender, EventArgs e)
        {
            MakeProfile(tx.Text);
        }

        private void MakeProfile(string vl)
        {
            string Path = Application.StartupPath;
            if (Path.Substring(Path.Length - 1, 1) != "/") Path = Path + "/";
            if (chkLinjal.Checked) vl = Linjal + "\r\n" + vl;

            try
            {
                if (!chkLinjal.Checked) vl = vl.Replace("\r\n", "<br />");
                if (chkLinjal.Checked) vl = vl.Replace("\r\n", "<br />" + Linjal + "<br />");
                int loops = 0;
                while (vl.IndexOf("[color=") != -1)
                {
                    loops++; if (loops > 10000) throw new Exception("Error");
                    string ColCode = Split(Split(vl, "[color=", 1), "]", 0);
                    string ColHtml = "[color=" + ColCode + "]";
                    string tmp = vl.Substring(0, vl.IndexOf(ColHtml));
                    tmp = tmp + "<span style=\"color:" + ColCode + ";\">";
                    vl = tmp + vl.Substring(vl.IndexOf(ColHtml) + ColHtml.Length);
                }
                vl = vl.Replace("[/color]", "</span>");
                vl = vl.Replace("[img]", "<img src=\"");
                vl = vl.Replace("[/img]", "\" style=\"border:0px; max-width: 470px;\">");
                vl = vl.Replace("[i]", "<em>");
                vl = vl.Replace("[/i]", "</em>");
                vl = vl.Replace("[b]", "<strong>");
                vl = vl.Replace("[/b]", "</strong>");
                vl = vl.Replace("[u]", "<span style=\"border-bottom: 1px dotted\">");
                vl = vl.Replace("[/u]", "</span>");
                vl = vl.Replace("[strike]", "<strike>");
                vl = vl.Replace("[/strike]", "</strike>");
                vl = vl.Replace("[size=", "<h");
                vl = vl.Replace("[/size]", "</h>");
            }
            catch
            {
                //catch(Exception ex) - ex.Message
                vl = "<br>\r\n"
                   + "<span style=\"color:#111111;\">''______________________________</span><span style=\"color:#705020;\">.:: </span><span style=\"color:#E0B040;\">Advarsel - feil i profilkode!</span><span style=\"color:#705020;\"> ::.</span>"
                   + "<br>\r\n<br>\r\n" + vl;
            }
            WriteFile("tmp.html", NM_Raw.Replace("<profile_goes_here>", vl));
            wb.Navigate(Path + "tmp.html");
        }
        public static string Split(string msg, string delim, int part)
        {
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        public static byte[] StrToByte(string str)
        {
            int x; byte[] vl = new byte[str.Length + 2];
            for (x = 0; x < str.Length; x++)
            {
                vl[x] = (byte)str[x];
            }
            vl[x] = 13; vl[x + 1] = 10;
            return vl;
        }
        private void WriteFile(string file, string val)
        {
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            fs.SetLength(0);
            byte[] b; b = StrToByte(val);
            fs.Write(b, 0, b.Length);
            fs.Close(); fs.Dispose();
        }

        private void tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (GetAsyncKeyState(Keys.ControlKey) != 0)
            {
                if (e.KeyCode == Keys.F) cCol_Click(new object(), new EventArgs());
                if (e.KeyCode == Keys.A) cB_Click(new object(), new EventArgs());
                if (e.KeyCode == Keys.S) cI_Click(new object(), new EventArgs());
                if (e.KeyCode == Keys.D) cU_Click(new object(), new EventArgs());
            }
        }

        private void cCol_Click(object sender, EventArgs e)
        {
            if (tx.SelectedText != "")
            {
                string col = inBox.InputBox.Show("Om du vil bruke en fargekode, skriv den inn og trykk enter.\r\nEksempel: F0C040\r\n\r\nOm du vil velge fra fargekart, trykk enter uten å skrive noe.", "Fargekode?").Text;
                if (col == "")
                {
                    ColorDialog lol = new ColorDialog(); lol.ShowDialog();
                    string C1 = lol.Color.R.ToString("X");
                    string C2 = lol.Color.G.ToString("X");
                    string C3 = lol.Color.B.ToString("X");
                    if (C1.Length != 2) C1 = "0" + C1;
                    if (C2.Length != 2) C2 = "0" + C2;
                    if (C3.Length != 2) C3 = "0" + C3;
                    tx.SelectedText = "[color=#" + C1 + C2 + C3 + "]" +
                                      tx.SelectedText +
                                      "[/color]";
                }
                else
                {
                    tx.SelectedText = "[color=#" + col + "]" + tx.SelectedText + "[/color]";
                }
            }
            else
            {
                MessageBox.Show("Vennligst marker teksten du vil endre først.");
            }
        }

        private void cB_Click(object sender, EventArgs e)
        {
            if (tx.SelectedText != "")
            {
                tx.SelectedText = "[b]" + tx.SelectedText + "[/b]";
            }
            else
            {
                MessageBox.Show("Vennligst marker teksten du vil endre først.");
            }
        }

        private void cI_Click(object sender, EventArgs e)
        {
            if (tx.SelectedText != "")
            {
                tx.SelectedText = "[i]" + tx.SelectedText + "[/i]";
            }
            else
            {
                MessageBox.Show("Vennligst marker teksten du vil endre først.");
            }
        }

        private void cU_Click(object sender, EventArgs e)
        {
            if (tx.SelectedText != "")
            {
                tx.SelectedText = "[u]" + tx.SelectedText + "[/u]";
            }
            else
            {
                MessageBox.Show("Vennligst marker teksten du vil endre først.");
            }
        }
    }
}