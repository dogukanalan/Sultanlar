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
    public partial class frmFotografBilgi : Form
    {
        public frmFotografBilgi(Bitmap BMP)
        {
            InitializeComponent();
            btmp = BMP;
        }

        Bitmap btmp;

        private void frmFotografBilgi_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = btmp;

            this.Size = new Size(btmp.Size.Width + 4, btmp.Size.Height + 20);
        }
    }
}
