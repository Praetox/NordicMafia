using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void c_Click(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                int iNum = 10000;
                while (true)
                {
                    WebReq[] wr = new WebReq[10000];
                    for (int a = 0; a < wr.Length; a++)
                    {
                        iNum++;
                        wr[a] = new WebReq();
                        wr[a].Request("http://www.nordicmafia.net/nordic/nmget_nycbild.php",
                        "AB-" + iNum + ".png", false);
                    }
                    while (true)
                    {
                        int iLeft = 0;
                        for (int a = 0; a < wr.Length; a++)
                        {
                            if (!wr[a].isReady) iLeft++;
                        }
                        if (iLeft == 0) break;
                        this.Text = iNum + " - " + iLeft;
                        Application.DoEvents();
                    }
                }
            }

            if (r2.Checked)
            {
                string retSums = "", retNames = "";
                string[] abs = Directory.GetFiles(Application.StartupPath + "\\", "ab*");
                for (int a = 0; a < abs.Length; a++)
                {
                    if (a.ToString().EndsWith("0"))
                    {
                        this.Text = "Summing " + a + " of " + abs.Length + "...";
                        Application.DoEvents();
                    }
                    StringBuilder sb = new StringBuilder();
                    FileStream fs = new FileStream(abs[a], FileMode.Open);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] hash = md5.ComputeHash(fs);
                    fs.Close(); fs.Dispose();
                    foreach (byte hex in hash)
                        sb.Append(hex.ToString("x2"));
                    string md5sum = sb.ToString();

                    retSums += md5sum + " " + abs[a].Split('\\')[abs[a].Split('\\').Length-1] + "\n";
                }
                string[] saret = retSums.Split('\n');
                retSums = "";
                for (int a = 0; a < saret.Length; a++)
                {
                    if (a.ToString().EndsWith("0"))
                    {
                        this.Text = "Checking " + a + " of " + saret.Length + "...";
                        Application.DoEvents();
                    }
                    if (!retSums.Contains(saret[a].Split(' ')[0]))
                    {
                        retSums += saret[a].Split(' ')[0] + "\r\n";
                        retNames += saret[a].Split(' ')[1] + "\r\n";
                        /*
                         * string eq = "";
                         * for (int b = a + 1; b < saret.Length; b++)
                         * {
                         *     if (saret[a].Split(' ')[0] == saret[b].Split(' ')[0])
                         *     {
                         *         eq +=
                         *             saret[a].Split(' ')[1] + " and " + saret[b].Split(' ')[1] + "|" +
                         *             saret[a].Split(' ')[0] + " and " + saret[b].Split(' ')[0] + "\n";
                         *     }
                         * }
                         * if (eq != "") ret += eq;
                         */
                    }
                }
                saret = retSums.Replace("\r", "").Split('\n');

                t.Text = "There are " + saret.Length + " unique files." + "\r\n\r\n" + retNames;
                MessageBox.Show("All done!" + "\r\n\r\n" +
                    "PROTIP: You better copypasta the results to notepad for easier reading.");
            }
        }
    }
}
