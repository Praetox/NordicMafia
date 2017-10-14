using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pNMC
{
    public partial class frmPmAntispam : Form
    {
        public frmPmAntispam()
        {
            InitializeComponent();
        }

        private void frmPmAntispam_Load(object sender, EventArgs e)
        {
            tNicks.Text = frmMain.PM_Spam_sNicks;
            tTopics.Text = frmMain.PM_Spam_sTopics;
        }

        private void frmPmAntispam_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.PM_Spam_sNicks = tNicks.Text;
            frmMain.PM_Spam_sTopics = tTopics.Text;
        }
    }
}
