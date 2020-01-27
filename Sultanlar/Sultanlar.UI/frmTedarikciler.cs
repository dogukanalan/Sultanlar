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
using mshtml;

namespace Sultanlar.UI
{
    public partial class frmTedarikciler : Form
    {
        public frmTedarikciler()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        Editor edAciklama;
        Editor edEkle;
        Image anaResim;
        //
        //
        //
        //
        //
        private void frmTedarikciler_Load(object sender, EventArgs e)
        {
            edAciklama = new Editor();
            edAciklama.Size = new Size(560, 153);
            edAciklama.Location = new Point(66, 72);
            edAciklama.Enabled = false;
            gbAyrinti.Controls.Add(edAciklama);
            edEkle = new Editor();
            edEkle.Size = new Size(560, 172);
            edEkle.Location = new Point(66, 54);
            gbEkleme.Controls.Add(edEkle);
            GetTedarikciler();
            lbTedarikciler.SelectedIndex = -1;
        }
        //
        //
        //
        //
        //
        private void GetTedarikciler()
        {
            Tedarikciler.GetObject(lbTedarikciler.Items);
        }
        //
        //
        //
        //
        //
        private void lbTedarikciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTedarikciler.SelectedIndex > -1)
            {
                Tedarikciler td = (Tedarikciler)lbTedarikciler.SelectedItem;
                lblID.Text = td.pkTedarikciID.ToString();
                txtTedarikci.Text = td.strTedarikci;
                edAciklama.Document.Body.Style = "font-size: 10px; font-family: Tahoma";
                edAciklama.BodyHtml = td.strTedarikciAciklama;
                pbResim.Image = Resim.ByteToImage(td.binTedarikciResim);
            }
        }
        //
        //
        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            if (lbTedarikciler.SelectedIndex > -1)
            {
                if (btnDuzelt.Text == "Düzelt")
                {
                    lbTedarikciler.Enabled = false;
                    btnResimDegistir.Visible = true;
                    txtTedarikci.ReadOnly = false;
                    edAciklama.Enabled = true;
                    btnDuzelt.Text = "Güncelle";
                    btnSil.Text = "İptal Et";
                    gbEkleme.Enabled = false;
                }
                else if (btnDuzelt.Text == "Güncelle")
                {
                    int index = lbTedarikciler.SelectedIndex;
                    Tedarikciler td = (Tedarikciler)lbTedarikciler.SelectedItem;
                    td.strTedarikci = txtTedarikci.Text;

                    if (edAciklama.BodyText != string.Empty && edAciklama.BodyText != null)
                    {
                        td.strTedarikciAciklama = edAciklama.BodyHtml.Replace("\r\n", string.Empty);
                    }
                    else
                    {
                        td.strTedarikciAciklama = string.Empty;
                    }
                    
                    td.binTedarikciResim = Resim.ImageToByte(pbResim.Image, pbResim.Image.RawFormat.Guid);

                    td.DoUpdate();
                    GetTedarikciler();
                    lbTedarikciler.SelectedIndex = index;

                    lbTedarikciler.Enabled = true;
                    btnResimDegistir.Visible = false;
                    txtTedarikci.ReadOnly = true;
                    edAciklama.Enabled = false;
                    btnDuzelt.Text = "Düzelt";
                    btnSil.Text = "Sil";
                }
            }
            else
            {
                MessageBox.Show("Bir tedarikçi seçiniz", "Tedarikçi Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //
        private void btnSil_Click(object sender, EventArgs e)
        {
            Tedarikciler td = (Tedarikciler)lbTedarikciler.SelectedItem;

            if (btnSil.Text == "Sil")
            {
                if (lbTedarikciler.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Geçerli kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        td.DoDelete();
                        GetTedarikciler();

                        lblID.Text = string.Empty;
                        txtTedarikci.Text = string.Empty;
                        edAciklama.BodyHtml = string.Empty;
                        pbResim.Image = null;
                    }
                }
            }
            else if (btnSil.Text == "İptal Et")
            {
                edAciklama.Document.Body.Style = "font-size: 10px; font-family: Tahoma";
                lbTedarikciler.SelectedItem = td;
                txtTedarikci.Text = td.strTedarikci;
                edAciklama.BodyHtml = td.strTedarikciAciklama;
                pbResim.Image = Resim.ByteToImage(td.binTedarikciResim);

                lbTedarikciler.Enabled = true;
                btnResimDegistir.Visible = false;
                txtTedarikci.ReadOnly = true;
                edAciklama.Enabled = false;
                btnDuzelt.Text = "Düzelt";
                btnSil.Text = "Sil";
                gbEkleme.Enabled = true;
            }
        }
        //
        //
        private void btnResimDegistir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbResim.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            }
        }
        //
        //
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (pbEkleResim.Image != null)
            {
                if (MessageBox.Show("Bir kayıt eklenmek üzere. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Image Tedarikci = Resim.TedarikciResimOlustur(pbEkleResim.Image);
                    Image kayitedilecekresim = Resim.ResimKucult(pbEkleResim.Image, 140);
                    byte[] resim = Resim.ImageToByte(kayitedilecekresim, "PNG");

                    Tedarikciler td;

                    if (edEkle.BodyText != null && edEkle.BodyText != string.Empty)
                    {
                        td = new Tedarikciler(txtEkleTedarikci.Text, edEkle.BodyHtml.Replace("\r\n", string.Empty), resim);
                    }
                    else
                    {
                        td = new Tedarikciler(txtEkleTedarikci.Text, string.Empty, resim);
                    }

                    td.DoInsert();
                    lbTedarikciler.Items.Add(td);

                    btnTemizle.PerformClick();
                    lbTedarikciler.SelectedItem = td;
                }
            }
            else
            {
                MessageBox.Show("Resim seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //
        private void btnEkleResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                anaResim = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
                pbEkleResim.Image = Resim.TedarikciResimOlustur(anaResim, 270, 120, 60);
            }
        }
        //
        //
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtEkleTedarikci.Text = string.Empty;
            edEkle.BodyHtml = string.Empty;
            pbEkleResim.Image = null;
        }

        private void pbEkleResim_Click(object sender, EventArgs e)
        {
            if (pbEkleResim.Image != null)
            {
                frmTedarikciResim frm = new frmTedarikciResim(anaResim);
                frm.ShowDialog();
                pbEkleResim.Image = frm.img;
            }
        }
    }
}
