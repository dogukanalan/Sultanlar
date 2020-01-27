using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmINTERNETresimler2 : Form
    {
        public frmINTERNETresimler2()
        {
            InitializeComponent();
        }

        private void frmINTERNETresimler2_Load(object sender, EventArgs e)
        {
            Resimler2.GetObjects(lbResimler.Items, "");
        }

        private void ResimEkle(string dosya)
        {
            byte[] resimHamdata = File.ReadAllBytes(dosya);
            Image resimHam = Resim.ByteToImage(resimHamdata);
            Resimler2 r2 = new Resimler2(txtEkle.Text.Trim(), resimHamdata);
            r2.DoInsert();

            MessageBox.Show("Yeni görsel eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtEkle.Text = string.Empty;
            Resimler2.GetObjects(lbResimler.Items, "");

            pictureBox1.Image = Properties.Resources.hazirlaniyor;
            lblBoyut.Text = string.Empty;
            lblCozunurluk.Text = string.Empty;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Resimler2.GetObjects(lbResimler.Items, txtUrun.Text.Trim());
            pictureBox1.Image = Properties.Resources.hazirlaniyor;
            lblBoyut.Text = string.Empty;
            lblCozunurluk.Text = string.Empty;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bir başlık girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                ResimEkle(ofd.FileName);
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (lbResimler.SelectedIndex > -1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] resimHamdata = File.ReadAllBytes(ofd.FileName);

                    Resimler2 r2 = Resimler2.GetObject(((Resimler2)lbResimler.SelectedItem).pkID);
                    r2.binResim = resimHamdata;
                    r2.DoUpdate();

                    pictureBox1.Image = Resim.ByteToImage(resimHamdata);
                    lblBoyut.Text = (resimHamdata.LongLength / 1024).ToString() + " KB";
                    lblCozunurluk.Text = pictureBox1.Image.Width.ToString() + "x" + pictureBox1.Image.Height.ToString();
                }
            }
        }

        private void lbResimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbResimler.SelectedIndex > -1)
            {
                byte[] imgb = Resimler2.GetObject(((Resimler2)lbResimler.SelectedItem).pkID).binResim;
                Image img = Resim.ByteToImage(imgb);
                pictureBox1.Image = img;
                lblBoyut.Text = (imgb.LongLength / 1024).ToString() + " KB";
                lblCozunurluk.Text = img.Width.ToString() + "x" + img.Height.ToString();
            }
            else
            {
                pictureBox1.Image = Properties.Resources.hazirlaniyor;
                lblBoyut.Text = string.Empty;
                lblCozunurluk.Text = string.Empty;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbResimler.SelectedIndex > -1 && MessageBox.Show("Silme işlemine devam etmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Resimler2 r2 = (Resimler2)lbResimler.SelectedItem;
                r2.DoDelete();

                MessageBox.Show("Görsel kaldırıldı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtEkle.Text = string.Empty;
                Resimler2.GetObjects(lbResimler.Items, "");

                pictureBox1.Image = Properties.Resources.hazirlaniyor;
                lblBoyut.Text = string.Empty;
                lblCozunurluk.Text = string.Empty;
            }
        }
    }
}
