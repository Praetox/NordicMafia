using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LM
{
    public partial class frmAntibot : Form
    {
        public frmAntibot()
        {
            InitializeComponent();
        }

        PBoxArray aPBox; public static PictureBox aPBoxClicked; public static int aPBoxClickedNum;
        LabelArray aLabel; public static Label aLabelClicked; public static int aLabelClickedNum;
        private Random rnd = new Random();

        private void frmAntibot_Load(object sender, EventArgs e)
        {
            aPBox = new PBoxArray(this); aLabel = new LabelArray(this);
            for (int y = 1; y <= 3; y++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    int xs = 90, ys = 65; int aThis = ControlIntFromXY(x, y);
                    aPBox.NewPBox(); aLabel.NewLabel();
                    abPanel.Controls.Add(aLabel[aThis]);
                    abPanel.Controls.Add(aPBox[aThis]);
                    aPBox[aThis].BringToFront();
                    aPBox[aThis].Size = new Size(xs, ys);
                    aPBox[aThis].Location = new Point(((x * (xs + 6 + 16)) - (xs + 6 + 16)) + 8,
                                                      ((y * (ys + 6 + 16)) - (ys + 6 + 16)) + 8);
                    string stFName = "";
                    while (true)
                    {
                        stFName = "tmp/abtmp_" + RandomChars(8) + ".jpg";
                        if (!System.IO.File.Exists(stFName)) break;
                    }
                    System.IO.File.Copy("tmp/" + Program.sAbPrefix + aThis + ".jpg", stFName);
                    //string stFName = "tmp/" + Program.sAbPrefix + aThis + ".jpg";
                    try
                    {
                        aPBox[aThis].BackgroundImage = (new Bitmap(stFName)) as Image;
                    }
                    catch { aPBox[aThis].BackColor = Color.FromArgb(255, 0, 0); }
                    aPBox[aThis].BackgroundImageLayout = ImageLayout.Stretch;
                    aLabel[aThis].Size = new Size(aPBox[aThis].Size.Width + 16,
                                                  aPBox[aThis].Size.Height + 16);
                    aLabel[aThis].Location = new Point(aPBox[aThis].Location.X - 8,
                                                       aPBox[aThis].Location.Y - 8);
                    aLabel[aThis].BackColor = Color.FromArgb(20, 75, 120);
                    aLabel[aThis].Text = "";
                }
            }
            /*cGo.Top = aLabel[8].Location.Y + aLabel[8].Height + 6;
            cGo.Width = aLabel[8].Location.X - aLabel[0].Location.X + aLabel[8].Width;
            lbHdr.Width = cGo.Width;
            this.Size = new Size(cGo.Top + cGo.Height + 33, cGo.Left + cGo.Width + 26);*/

            FormPos.SetWindowPos(this.Handle, -1, 0, 0, 0, 0,
                                 FormPos.SWP_NOMOVE + FormPos.SWP_NOSIZE +
                                 FormPos.SWP_SHOWWINDOW);
            FormPos.SetWindowPos(this.Handle, -2, 0, 0, 0, 0,
                                 FormPos.SWP_NOMOVE + FormPos.SWP_NOSIZE +
                                 FormPos.SWP_SHOWWINDOW);
            this.Show(); cGo.Focus(); Application.DoEvents();
            FormPos.SetForegroundWindow(this.Handle);
        }
        private int ControlIntFromXY(int x, int y)
        {
            return ((y * 3) - 3) + x - 1;
        }
        private Point XYFromControlInt(int ind)
        {
            return new Point((ind / 3), ind - (ind / 3));
        }

        private void cGo_Click(object sender, EventArgs e)
        {
            if (Program.sAntibot.Length != 3) return;
            for (int a = 0; a <= 8; a++)
                aPBox[a].BackgroundImage = null;
            Program.bAbCompleted = true; Program.bAbEnded = true;
            this.Close(); this.Dispose();
        }

        private void tMain_Tick(object sender, EventArgs e)
        {
            if (aPBoxClicked == null) return; aPBoxClicked = null;
            if (aLabel[aPBoxClickedNum].BackColor == Color.FromArgb(20, 75, 120))
                aLabel[aPBoxClickedNum].BackColor = Color.FromArgb(100, 200, 250);
            else
                aLabel[aPBoxClickedNum].BackColor = Color.FromArgb(20, 75, 120);
            Program.sAntibot = "";
            for (int a = 0; a <= 8; a++)
                if (aLabel[a].BackColor == Color.FromArgb(100, 200, 250)) Program.sAntibot += a;
        }

        private void cGo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q) { aPBoxClickedNum = 0; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.W) { aPBoxClickedNum = 1; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.E) { aPBoxClickedNum = 2; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.A) { aPBoxClickedNum = 3; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.S) { aPBoxClickedNum = 4; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.D) { aPBoxClickedNum = 5; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.Z) { aPBoxClickedNum = 6; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.X) { aPBoxClickedNum = 7; aPBoxClicked = new PictureBox(); }
            if (e.KeyCode == Keys.C) { aPBoxClickedNum = 8; aPBoxClicked = new PictureBox(); }
        }

        private string RandomChars(int Count)
        {
            string ret = "";
            for (int a = 0; a < Count; a++)
            {
                int ThisRnd = rnd.Next(1, 63);
                if (ThisRnd >= 1 && ThisRnd <= 26)
                    ThisRnd += 64;
                else if (ThisRnd >= 27 && ThisRnd <= 52)
                    ThisRnd += 97 - 27;
                else if (ThisRnd >= 53 && ThisRnd <= 62)
                    ThisRnd += 48 - 53;
                ret += (char)ThisRnd;
            }
            return ret;
        }

        private void frmAntibot_FormClosed(object sender, FormClosedEventArgs e)
        {
            aLabel = null; aPBox = null;
            Program.bAbEnded = true;
        }
    }
}