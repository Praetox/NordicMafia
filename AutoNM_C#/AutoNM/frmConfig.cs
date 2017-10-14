using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoNM
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }
        private void WriteFile(string file, string val)
        {
            TextWriter tw = new StreamWriter(file);
            tw.WriteLine(val);
            tw.Close();
        }

        private void cmdLagre_Click(object sender, EventArgs e)
        {
            string sCfg = "";
            if (rKri0.Checked) sCfg += "-1 | ";                                                     // 0
            if (rKri1.Checked) sCfg += "0 | "; if (rKri2.Checked) sCfg += "1 | ";                   // 0
            if (rKri3.Checked) sCfg += "2 | "; if (rKri4.Checked) sCfg += "3 | ";                   // 0
            if (rPre1.Checked) sCfg += "1 | "; else sCfg += "-1 | ";                                // 1
            if (rBil0.Checked) sCfg += "-1 | ";                                                     // 2
            if (rBil1.Checked) sCfg += "0 | "; if (rBil2.Checked) sCfg += "1 | ";                   // 2
            if (rBil3.Checked) sCfg += "2 | "; if (rBil4.Checked) sCfg += "3 | ";                   // 2
            if (rFCt1.Checked) sCfg += "1 | "; else sCfg += "-1 | ";                                // 3
            if (rFCa0.Checked) sCfg += "-1 | "; if (rFCa1.Checked) sCfg += "1 | ";                  // 4
            if (rFCa2.Checked) sCfg += "2 | "; sCfg += vFCa.Text + " | ";                           // 4-5
            if (rBry0.Checked) sCfg += "-1 | "; if (rBry1.Checked) sCfg += "1 | ";                  // 6
            if (rBry2.Checked) sCfg += "2 | "; sCfg += vBry.Text + " | ";                           // 6-7
            if (rKjo1.Checked) sCfg += "1 | "; else sCfg += "-1 | ";                                // 8
            if (rEst1.Checked) sCfg += "1 | "; else sCfg += "-1 | "; sCfg += vEst.Text + " | ";     // 9-10
            if (rAbo1.Checked) sCfg += "1 | "; if (rAbo2.Checked) sCfg += "2 | ";                   //11
            if (rAbo3.Checked) sCfg += "3 | ";                                                      //11
            if (rSrv1.Checked) sCfg += "http://www.nordicmafia.net/ | ";                            //12
            if (rSrv2.Checked) sCfg += "http://www.nordicmafia.dk/ | ";                             //12
            if (cTrsp.Checked) sCfg += "1 | "; else sCfg += "-1 | ";                                //13
            WriteFile("cfg.ini", sCfg);
            // Krim | Press | Bil | FCT | FCA | FCAOpt | Bryt | BrytOpt | Kjøput | Est | optEst | ABot | Srvr
            //   0      1      2     3     4      5       6       7          8      9      10      11     12
            // Trsp
            //  13
        }

        private void cmdBruk_Click(object sender, EventArgs e)
        {
            if (rKri0.Checked) Program.oKrim = -1;
            if (rKri1.Checked) Program.oKrim = 0; if (rKri2.Checked) Program.oKrim = 1;
            if (rKri3.Checked) Program.oKrim = 2; if (rKri4.Checked) Program.oKrim = 3;
            if (rPre1.Checked) Program.oPress = 1; else Program.oPress = -1;
            if (rBil0.Checked) Program.oBil = -1;
            if (rBil1.Checked) Program.oBil = 0; if (rBil2.Checked) Program.oBil = 1;
            if (rBil3.Checked) Program.oBil = 2; if (rBil4.Checked) Program.oBil = 3;
            if (rFCt1.Checked) Program.oFCt = 1; else Program.oFCt = -1;
            if (rFCa0.Checked) Program.oFCa = -1; if (rFCa1.Checked) Program.oFCa = 1; if (rFCa2.Checked) Program.oFCa = 2;
            if (rBry0.Checked) Program.oBryt = -1; if (rBry1.Checked) Program.oBryt = 1; if (rBry2.Checked) Program.oBryt = 2;
            if (rKjo1.Checked) Program.oKjop = 1; else Program.oKjop = -1;
            if (rEst1.Checked) Program.oEst = 1; else Program.oEst = -1; Program.vEst = Convert.ToInt32(vEst.Text);
            if (rAbo1.Checked) Program.oAbt = 1; if (rAbo2.Checked) Program.oAbt = 2; if (rAbo3.Checked) Program.oAbt = 3;
            if (rSrv1.Checked) Program.Gamedomain = "http://www.nordicmafia.net/";
            if (rSrv2.Checked) Program.Gamedomain = "http://www.nordicmafia.dk/";
            if (cTrsp.Checked) Program.oTrsp = 1; else Program.oTrsp = 0;
            Program.vFCa = vFCa.Text; Program.vBryt = vBry.Text;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            switch (Program.oKrim)
            {
                case -1: rKri0.Checked = true; break;
                case 0: rKri1.Checked = true; break;
                case 1: rKri2.Checked = true; break;
                case 2: rKri3.Checked = true; break;
                case 3: rKri4.Checked = true; break;
            }
            switch (Program.oPress)
            {
                case -1: rPre0.Checked = true; break;
                case 1: rPre1.Checked = true; break;
            }
            switch (Program.oBil)
            {
                case -1: rBil0.Checked = true; break;
                case 0: rBil1.Checked = true; break;
                case 1: rBil2.Checked = true; break;
                case 2: rBil3.Checked = true; break;
                case 3: rBil4.Checked = true; break;
            }
            switch (Program.oFCt)
            {
                case -1: rFCt0.Checked = true; break;
                case 1: rFCt1.Checked = true; break;
            }
            vBry.Text = Program.vBryt;
            switch(Program.oBryt)
            {
                case -1: rBry0.Checked = true; break;
                case 1: rBry1.Checked = true; break;
                case 2: rBry2.Checked = true; break;
            }
            switch (Program.oKjop)
            {
                case -1: rKjo0.Checked = true; break;
                case 1: rKjo1.Checked = true; break;
            }
            vFCa.Text = Program.vFCa;
            switch (Program.oFCa)
            {
                case -1: rFCa0.Checked = true; break;
                case 1: rFCa1.Checked = true; break;
                case 2: rFCa2.Checked = true; break;
            }
            vEst.Text = Convert.ToString(Program.vEst);
            switch (Program.oEst)
            {
                case -1: rEst0.Checked = true; break;
                case 1: rEst1.Checked = true; break;
            }
            switch (Program.oAbt)
            {
                case 1: rAbo1.Checked = true; break;
                case 2: rAbo2.Checked = true; break;
                case 3: rAbo3.Checked = true; break;
            }
            if (Program.Gamedomain == "http://www.nordicmafia.net/") rSrv1.Checked = true;
            if (Program.Gamedomain == "http://www.nordicmafia.dk/") rSrv2.Checked = true;
            switch (Program.oTrsp)
            {
                case -1: cTrsp.Checked = false; break;
                case 1: cTrsp.Checked = true; break;
            }
        }
    }
}