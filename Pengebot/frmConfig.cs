using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pengebot
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtStopVal.Text = Convert.ToString(Program.StopVal);
            txtMaxWin.Text = Convert.ToString(Program.MaxWin);
            txtMaxLoss.Text = Convert.ToString(Program.MaxLoss);
            txtMaxPush.Text = Convert.ToString(Program.MaxPush);
            chkCAErr.Checked = Program.CAErr;
            txtCNow.Text = Program.strCNow;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            Program.StopVal = Convert.ToInt32(txtStopVal.Text);
            Program.MaxWin = Convert.ToInt32(txtMaxWin.Text);
            Program.MaxLoss = Convert.ToInt32(txtMaxLoss.Text);
            Program.MaxPush = Convert.ToInt32(txtMaxPush.Text);
            Program.CAErr = chkCAErr.Checked;
            this.Hide();
        }
        private void cmdAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void cmdCalc_Click(object sender, EventArgs e)
        {
            //UInt64 Maks: ~18 446 700 000 000 000 000
            UInt64 CNow, MBet, R1, R2, R3, R4; double fCurVl = 0;
            CNow = Convert.ToUInt64(txtCNow.Text.Replace(",", ""));
            MBet=1;
            while (MBet<CNow)
            {
                fCurVl = MBet; fCurVl = fCurVl * 2.1;
                if (fCurVl < CNow){
                    MBet = Convert.ToUInt64(fCurVl);
                }else{
                    break;
                }
            }
            R1 = MBet; R2 = MBet; R3 = MBet; R4 = MBet;
            for (int a = 0; a <= 10; a++)
            {
                fCurVl = R1; fCurVl = fCurVl / 2.1; R1 = Convert.ToUInt64(fCurVl);
            }
            for (int a = 0; a <= 15; a++)
            {
                fCurVl = R2; fCurVl = fCurVl / 2.1; R2 = Convert.ToUInt64(fCurVl);
            }
            for (int a = 0; a <= 20; a++)
            {
                fCurVl = R3; fCurVl = fCurVl / 2.1; R3 = Convert.ToUInt64(fCurVl);
            }
            for (int a = 0; a <= 30; a++)
            {
                fCurVl = R4; fCurVl = fCurVl / 2.1; R4 = Convert.ToUInt64(fCurVl);
            }
            fCurVl = R1; R1 = Convert.ToUInt64((fCurVl / 1000) * 980);
            fCurVl = R2; R2 = Convert.ToUInt64((fCurVl / 1000) * 980);
            fCurVl = R3; R3 = Convert.ToUInt64((fCurVl / 1000) * 980);
            fCurVl = R4; R4 = Convert.ToUInt64((fCurVl / 1000) * 980);
            lbR1.Text = frmMain.Decimize(Convert.ToString(R1));
            lbR2.Text = frmMain.Decimize(Convert.ToString(R2));
            lbR3.Text = frmMain.Decimize(Convert.ToString(R3));
            lbR4.Text = frmMain.Decimize(Convert.ToString(R4));
            tt.SetToolTip(lbR1, "Stor sjans for å miste alt.   " + Convert.ToString(R1));
            tt.SetToolTip(lbR2, "Passelig balanse mellom intekter og risk.   " + Convert.ToString(R2));
            tt.SetToolTip(lbR3, "Lav risiko, men også lave inntekter.   " + Convert.ToString(R3));
            tt.SetToolTip(lbR4, "Tilnærmet ingen inntekter.   " + Convert.ToString(R4));
        }
    }
}