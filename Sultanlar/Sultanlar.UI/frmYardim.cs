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
    public partial class frmYardim : Form
    {
        public frmYardim(Bitmap Resim)
        {
            InitializeComponent();
            pictureBox1.Image = Resim;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Width = pictureBox1.Width + 10;
            this.Height = pictureBox1.Height + 30;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
