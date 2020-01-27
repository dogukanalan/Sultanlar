using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmINTERNETtedarikciresim : Form
    {
        public frmINTERNETtedarikciresim()
        {
            InitializeComponent();
        }

        private void frmINTERNETtedarikciresim_Load(object sender, EventArgs e)
        {
            //GetTedarikciler();
        }

        private void GetTedarikciler()
        {
            //Urunler.GetOzelKodlar(lbTedarikciler.Items);
        }

        private void GetResim()
        {
            //if (lbResimler.SelectedIndex > -1)
            //{
            //    byte[] resimdata = Resimler.GetObjectByResimID(((TedarikciResim)lbResimler.SelectedItem).intResimID);
            //    if (resimdata != null)
            //    {
            //        pictureBox1.Image = Resim.ByteToImage(resimdata);
            //        lblBoyut.Text = (resimdata.LongLength / 1024).ToString() + " KB";
            //        lblEklenme.Text = ((TedarikciResim)lbResimler.SelectedItem).dtEklenme.ToString();
            //        lblEkleyen.Text = ((TedarikciResim)lbResimler.SelectedItem).strEkleyen;
            //    }
            //    else
            //    {
            //        pictureBox1.Image = Properties.Resources.resimyok;
            //    }
            //}
            //else
            //{
            //    pictureBox1.Image = Properties.Resources.resimyok;
            //}
        }

        private void lbTedarikciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbResimler.Items.Clear();
            //lblBoyut.Text = string.Empty;
            //lblEklenme.Text = string.Empty;
            //lblEkleyen.Text = string.Empty;
            //pictureBox1.Image = Properties.Resources.resimyok;

            //if (lbTedarikciler.SelectedIndex > -1)
            //{
            //    TedarikciResim.GetObjects(lbResimler.Items, ((OzelKodlar)lbTedarikciler.SelectedItem).OZELKOD, true);

            //    if (lbResimler.Items.Count > 0)
            //    {
            //        lbResimler.SelectedIndex = 0;
            //    }
            //}
        }

        private void lbResimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetResim();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //if (lbTedarikciler.SelectedIndex > -1)
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        byte[] resimHamdata = File.ReadAllBytes(ofd.FileName);
            //        Image resimHam = Resim.ByteToImage(resimHamdata);

            //        if (resimHam.Width < 100 && resimHam.Height < 100)
            //        {
            //            MessageBox.Show("Eklenmeye çalışılan resmin çözünürlüğü (" + resimHam.Width.ToString() + "x" + resimHam.Height.ToString() + ") belirlenen en düşük değerin (100x100) altında olduğundan resim eklenemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        int width = resimHam.Width;
            //        int height = resimHam.Height;
            //        int widthK = 0;
            //        int heightK = 0;
            //        int widthO = 0;
            //        int heightO = 0;
            //        double AR = Convert.ToDouble(width) / Convert.ToDouble(height);
            //        if (height > width)
            //        {
            //            height = 400;
            //            heightK = 25;
            //            heightO = 100;
            //            width = Convert.ToInt32(height * AR);
            //            widthK = Convert.ToInt32(heightK * AR);
            //            widthO = Convert.ToInt32(heightO * AR);
            //        }
            //        else if (width > height)
            //        {
            //            width = 400;
            //            widthK = 25;
            //            widthO = 100;
            //            height = Convert.ToInt32(width / AR);
            //            heightK = Convert.ToInt32(widthK / AR);
            //            heightO = Convert.ToInt32(widthO / AR);
            //        }
            //        else
            //        {
            //            width = 400;
            //            widthK = 25;
            //            widthO = 100;
            //            height = 400;
            //            heightK = 25;
            //            heightO = 100;
            //        }

            //        Image resim = Resim.ResimKucult(resimHam, width, height);
            //        Image kucukresim = Resim.ResimKucult(resimHam, widthK, heightK);
            //        Image ortaresim = Resim.ResimKucult(resimHam, widthO, heightO);
            //        pictureBox1.Image = resim;

            //        byte[] resimdata = Resim.ImageToByte(resim);
            //        byte[] kucukresimdata = Resim.ImageToByte(kucukresim);
            //        byte[] ortaresimdata = Resim.ImageToByte(ortaresim);
            //        Resimler res = new Resimler(resimdata, kucukresimdata, ortaresimdata);
            //        res.DoInsert();

            //        TedarikciResim tr = new TedarikciResim(lbResimler.Items.Count + 1, ((OzelKodlar)lbTedarikciler.SelectedItem).OZELKOD,
            //            res.pkResimID, DateTime.Now, frmAna.KAdi.ToUpper());
            //        tr.DoInsert();
            //        lbResimler.Items.Add(tr);

            //        lbResimler.SelectedIndex = lbResimler.Items.Count - 1;
            //    }
            //}
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //if (lbResimler.SelectedIndex > -1)
            //{
            //    if (MessageBox.Show("Resim silinsin mi?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        TedarikciResim tr = (TedarikciResim)lbResimler.SelectedItem;
            //        Resimler.DoDeleteByResimID(tr.intResimID);
            //        tr.DoDelete();
            //        lbResimler.Items.RemoveAt(lbResimler.SelectedIndex);
            //        lbResimler.SelectedIndex = -1;
            //        pictureBox1.Image = Properties.Resources.resimyok;
            //    }
            //}
        }
    }
}
