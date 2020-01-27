using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmDepoDenetlemeResim : Form
    {
        public frmDepoDenetlemeResim(Image[] resim)
        {
            InitializeComponent();
            Resim = resim;
        }

        Image[] Resim;
        int imageindex;

        private void frmDepoDenetlemeResim_Load(object sender, EventArgs e)
        {
            if (Resim.Length != 0)
            {
                pictureBox1.Image = Resim[0];
                imageindex = 0;
                this.Text = "Resimler (1 / " + Resim.Length.ToString() + ")";
            }
            else
            {
                imageindex = -1;
                this.Text = "Resimler (0 / 0)";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (imageindex + 1 < Resim.Length)
            {
                imageindex++;
                pictureBox1.Image = Resim[imageindex];
                this.Text = "Resimler (" + (imageindex + 1).ToString() + " / " + Resim.Length.ToString() + ")";
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (imageindex > 0)
            {
                imageindex--;
                pictureBox1.Image = Resim[imageindex];
                this.Text = "Resimler (" + (imageindex + 1).ToString() + " / " + Resim.Length.ToString() + ")";
            }
        }

        private void frmDepoDenetlemeResim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                simpleButton1.PerformClick();
            }
            else if (e.KeyCode == Keys.A)
            {
                simpleButton2.PerformClick();
            }
        }
    }
}
