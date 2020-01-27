using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.Class;

namespace Sultanlar.UI
{
    public partial class frmTedarikciResim : Form
    {
        public frmTedarikciResim(Image Img)
        {
            InitializeComponent();
            img = Img;
        }

        public Image img;
        int buyukluk;
        int soldanuzaklik;
        int yukardanuzaklik;

        private void frmTedarikciResim_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, 270, 120, 60);
            buyukluk = 270;
            soldanuzaklik = 120;
            yukardanuzaklik = 60;
        }

        private void btnTamamla_Click(object sender, EventArgs e)
        {
            img = pictureBox1.Image;
            this.Close();
        }

        private void btnKucult_Click(object sender, EventArgs e)
        {
            buyukluk = buyukluk - 10;
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, buyukluk, soldanuzaklik, yukardanuzaklik);
        }

        private void btnBuyut_Click(object sender, EventArgs e)
        {
            buyukluk = buyukluk + 10;
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, buyukluk, soldanuzaklik, yukardanuzaklik);
        }

        private void btnYukariya_Click(object sender, EventArgs e)
        {
            yukardanuzaklik = yukardanuzaklik - 10;
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, buyukluk, soldanuzaklik, yukardanuzaklik);
        }

        private void btnAsagiya_Click(object sender, EventArgs e)
        {
            yukardanuzaklik = yukardanuzaklik + 10;
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, buyukluk, soldanuzaklik, yukardanuzaklik);
        }

        private void btnSola_Click(object sender, EventArgs e)
        {
            soldanuzaklik = soldanuzaklik - 10;
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, buyukluk, soldanuzaklik, yukardanuzaklik);
        }

        private void btnSaga_Click(object sender, EventArgs e)
        {
            soldanuzaklik = soldanuzaklik + 10;
            pictureBox1.Image = Resim.TedarikciResimOlustur(img, buyukluk, soldanuzaklik, yukardanuzaklik);
        }
    }
}
