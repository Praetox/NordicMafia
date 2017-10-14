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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; this.Show(); Application.DoEvents();
            for (double a = 0; a <= 0.9; a += 0.02)
            {
                this.Opacity = a; Application.DoEvents(); System.Threading.Thread.Sleep(10);
            }
            System.Threading.Thread.Sleep(1500);
            for (double a = 0.9; a > 0; a -= 0.02)
            {
                this.Opacity = a; Application.DoEvents(); System.Threading.Thread.Sleep(10);
            }
            this.Enabled = false;
        }
    }
}
