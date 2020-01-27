using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;
using System.IO;
using Design;

namespace Sultanlar.UI
{
    public partial class frmHaberler : Form
    {
        public frmHaberler()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        //Editor edAciklama;
        //Editor edEkle;
        //
        //
        //
        //
        //
        private void frmHaberler_Load(object sender, EventArgs e)
        {
            //edEkle = new Editor();
            //edEkle.Size = new Size(352, 119);
            //edEkle.Location = new Point(67, 121);
            //edEkle.Enabled = true;
            //groupBox1.Controls.Add(edEkle);
            //edEkle.BringToFront();

            //edAciklama = new Editor();
            //edAciklama.Size = new Size(352, 119);
            //edAciklama.Location = new Point(67, 121);
            //edAciklama.Enabled = false;
            //groupBox2.Controls.Add(edAciklama);
            //edAciklama.BringToFront();

            GetHaberler();
        }
        //
        //
        //
        //
        //
        private void GetHaberler()
        {
            Haberler.GetObject(cmbHaberler.Items);
        }
        //
        //
        //
        //
        //
        private void cmbHaberler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Haberler hbr = (Haberler)cmbHaberler.SelectedItem;
            txtHaberIcerik.Text = HtmlToText(hbr.strIcerik);
            //edAciklama.BodyHtml = HtmlToText(hbr.strIcerik);
            pbHaber.Image = Resim.ByteToImage((byte[])hbr.binResim);
            //edAciklama.Document.Body.Style = "font-size: 10px; font-family: Tahoma";
        }
        //
        //
        //
        //
        //
        private string HtmlToText(string ham)
        {
            ham = ham.Replace("<br />", "\r\n");
            return ham;
        }
        //
        //
        //
        //
        //
        private string TextToHtml(string ham)
        {
            ham = ham.Replace("\r\n", "<br />");
            return ham;
        }
        //
        //
        //
        //
        //
        private void btnHaberSil_Click(object sender, EventArgs e)
        {
            if (btnHaberSil.Text == "Haberi Sil")
            {
                if (cmbHaberler.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Geçerli kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Haberler hbr = (Haberler)cmbHaberler.SelectedItem;
                        hbr.DoDelete();
                        cmbHaberler.Items.Remove(hbr);

                        txtHaberIcerik.Text = string.Empty;
                        //edAciklama.BodyText = string.Empty;
                        pbHaber.Image = null;

                        lblHaberDurum.Text = "Haber silindi.";
                    }
                }
            }
            else if (btnHaberSil.Text == "İptal Et")
            {
                btnResimDegistir.Visible = false;
                cmbHaberler.Visible = true;
                btnHaberSil.Enabled = true;
                txtHaberBaslik.Visible = false;
                txtHaberIcerik.ReadOnly = true;
                //edAciklama.Enabled = false;
                btnHaberGuncelle.Text = "Haberi Güncelle";
                btnHaberSil.Text = "Haberi Sil";

                Haberler hbr = (Haberler)cmbHaberler.SelectedItem;
                txtHaberIcerik.Text = HtmlToText(hbr.strIcerik);
                //edAciklama.BodyHtml = HtmlToText(hbr.strIcerik);
                pbHaber.Image = Resim.ByteToImage((byte[])hbr.binResim);

                lblHaberDurum.Text = "Güncelleme iptal edildi.";
            }
        }
        //
        //
        //
        //
        //
        private void btnHaberEkle_Click(object sender, EventArgs e)
        {
            if (pbHaberEkle.Image != null)
            {
                if (MessageBox.Show("Bir kayıt eklenmek üzere. Emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    byte[] resim = Resim.ImageToByte(Resim.ResimKucult(pbHaberEkle.Image, 140), pbHaberEkle.Image.RawFormat.Guid);

                    Haberler hbr = new Haberler(txtHaberEkleBaslik.Text, txtHaberEkleIcerik.Text, DateTime.Now, resim);
                    //Haberler hbr = new Haberler(txtHaberEkleBaslik.Text, edEkle.BodyHtml, DateTime.Now, resim);
                    hbr.DoInsert();
                    cmbHaberler.Items.Add(hbr);

                    btnHaberEkleTemizle.PerformClick();
                    lblDurum.Text = "Yeni haber eklendi.";
                    cmbHaberler.SelectedItem = hbr;
                }
            }
            else
            {
                MessageBox.Show("Resim seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //
        //
        //
        //
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnResimEkle.Visible = false;
                pbHaberEkle.Visible = true;
                lblDurum.Text = "Resim Alındı.";

                pbHaberEkle.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            }
        }
        //
        //
        //
        //
        //
        private void btnHaberEkleTemizle_Click(object sender, EventArgs e)
        {
            txtHaberEkleBaslik.Text = string.Empty;
            txtHaberEkleIcerik.Text = string.Empty;
            //edEkle.BodyText = string.Empty;
            btnResimEkle.Visible = true;
            pbHaberEkle.Image = null;
            pbHaberEkle.Visible = false;
            lblDurum.Text = "Form temizlendi.";
        }
        //
        //
        //
        //
        //
        private void btnHaberGuncelle_Click(object sender, EventArgs e)
        {
            if (btnHaberGuncelle.Text == "Haberi Güncelle")
            {
                lblHaberDurum.Text = "Haber güncelleniyor.";

                btnResimDegistir.Visible = true;
                cmbHaberler.Visible = false;
                txtHaberBaslik.Visible = true;
                txtHaberIcerik.ReadOnly = false;
                //edAciklama.Enabled = true;
                btnHaberGuncelle.Text = "Güncellemeyi Bitir";
                btnHaberSil.Text = "İptal Et";

                txtHaberBaslik.Text = cmbHaberler.SelectedItem.ToString();
            }
            else if (btnHaberGuncelle.Text == "Güncellemeyi Bitir")
            {
                int index = cmbHaberler.SelectedIndex;
                Haberler hbr = (Haberler)cmbHaberler.SelectedItem;
                hbr.strIcerik = txtHaberIcerik.Text;
                //hbr.strIcerik = edAciklama.BodyHtml;
                hbr.strIcerik = txtHaberIcerik.Text;
                hbr.strBaslik = txtHaberBaslik.Text;
                hbr.binResim = Resim.ImageToByte(Resim.ResimKucult(pbHaber.Image, 140), pbHaber.Image.RawFormat.Guid);
                
                hbr.DoUpdate();
                GetHaberler();
                cmbHaberler.SelectedIndex = index;

                btnResimDegistir.Visible = false;
                cmbHaberler.Visible = true;
                txtHaberBaslik.Visible = false;
                txtHaberIcerik.ReadOnly = true;
                //edAciklama.Enabled = false;
                btnHaberGuncelle.Text = "Haberi Güncelle";
                btnHaberSil.Text = "Haberi Sil";

                lblHaberDurum.Text = "Haber güncellendi.";
            }
        }
        //
        //
        //
        //
        //
        private void btnResimDegistir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbHaber.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
                lblHaberDurum.Text = "Haber resmi değiştirildi.";
            }
        }
    }
}
