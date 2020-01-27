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
    public partial class frmINTERNETresimler : Form
    {
        public frmINTERNETresimler()
        {
            InitializeComponent();
        }

        private void frmINTERNETresimler_Load(object sender, EventArgs e)
        {
            GetTedarikciler();
            GetKategoriler();
            GetUrunler(0, "", "", "", "", true, true, false, true);
            lblToplam.Text = lbUrunler.Items.Count.ToString();
        }

        private void GetTedarikciler()
        {
            Urunler.GetOzelKodlar(cmbTedarikciler.Items);
        }

        private void GetKategoriler()
        {
            Urunler.GetReyonKodlar(cmbKategoriler.Items);  
        }

        private void GetUrunler(int ITEMREF, string MALACIK, string OZELKOD, string REYKOD, string BARKOD, bool Tumu, bool Resimli, 
            bool Yeni, bool Alfabetik)
        {
            Urunler.GetProducts(lbUrunler.Items, ITEMREF, MALACIK, OZELKOD, REYKOD, BARKOD, Tumu, Resimli, Yeni, Alfabetik, true);
            lblAranmis.Text = lbUrunler.Items.Count.ToString();

            if (!cbYeniler.Checked && rbTumu.Checked)
            {
                label6.Visible = true;
                lblToplam.Visible = true;
                lblToplam.Text = lbUrunler.Items.Count.ToString();
            }
        }

        private void GetResim()
        {
            if (lbResimler.SelectedIndex > -1)
            {
                byte[] resimdata = !cbLogo.Checked ? Resimler.GetObjectByResimID(((UrunResim)lbResimler.SelectedItem).intResimID) : Resimler.GetObjectByResimID(((TedarikciResim)lbResimler.SelectedItem).intResimID);
                if (resimdata != null)
                {
                    pictureBox1.Image = Resim.ByteToImage(resimdata);
                    lblCozunurluk.Text = pictureBox1.Image.Width.ToString() + "x" + pictureBox1.Image.Height.ToString();
                    lblBoyut.Text = (resimdata.LongLength / 1024).ToString() + " KB";
                    lblEklenme.Text = !cbLogo.Checked ? ((UrunResim)lbResimler.SelectedItem).dtEklenme.ToString() : ((TedarikciResim)lbResimler.SelectedItem).dtEklenme.ToString();
                    lblEkleyen.Text = !cbLogo.Checked ? ((UrunResim)lbResimler.SelectedItem).strEkleyen : ((TedarikciResim)lbResimler.SelectedItem).strEkleyen;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.hazirlaniyor;
                }
            }
            else
            {
                pictureBox1.Image = Properties.Resources.hazirlaniyor;
            }
        }

        private void ResimEkle(string ResimYolu)
        {
            byte[] resimHamdata = File.ReadAllBytes(ResimYolu);
            Image resimHam = Resim.ByteToImage(resimHamdata);

            if (resimHam.Width < 400 && resimHam.Height < 400)
            {
                MessageBox.Show("Eklenmeye çalışılan resmin çözünürlüğü (" + resimHam.Width.ToString() + "x" + resimHam.Height.ToString() + ") belirlenen en düşük değerin (400x400) altında olduğundan resim eklenemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int width = resimHam.Width;
            int height = resimHam.Height;
            int widthK = 0;
            int heightK = 0;
            int widthO = 0;
            int heightO = 0;
            double AR = Convert.ToDouble(width) / Convert.ToDouble(height);
            if (height > width)
            {
                //height = 400;
                heightK = 25;
                heightO = 100;
                width = Convert.ToInt32(height * AR);
                widthK = Convert.ToInt32(heightK * AR);
                widthO = Convert.ToInt32(heightO * AR);
            }
            else if (width > height)
            {
                //width = 400;
                widthK = 25;
                widthO = 100;
                height = Convert.ToInt32(width / AR);
                heightK = Convert.ToInt32(widthK / AR);
                heightO = Convert.ToInt32(widthO / AR);
            }
            else
            {
                //width = 400;
                widthK = 25;
                widthO = 100;
                //height = 400;
                heightK = 25;
                heightO = 100;
            }

            Image resim = Resim.ResimKucult(resimHam, resimHam.Width, resimHam.Height);
            Image kucukresim = Resim.ResimKucult(resimHam, widthK, heightK);
            Image ortaresim = Resim.ResimKucult(resimHam, widthO, heightO);
            pictureBox1.Image = resim;

            byte[] resimdata = Resim.ImageToByte(resim);
            byte[] kucukresimdata = Resim.ImageToByte(kucukresim);
            byte[] ortaresimdata = Resim.ImageToByte(ortaresim);
            Resimler res = new Resimler(resimdata, kucukresimdata, ortaresimdata);
            res.DoInsert();

            UrunResim ur = new UrunResim(lbResimler.Items.Count + 1, ((Urunler)lbUrunler.SelectedItem).ITEMREF,
                res.pkResimID, DateTime.Now, frmAna.KAdi.ToUpper());
            ur.DoInsert();
            lbResimler.Items.Add(ur);

            lbResimler.SelectedIndex = lbResimler.Items.Count - 1;
        }

        private void lbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbResimler.Items.Clear();
            lblCozunurluk.Text = string.Empty;
            lblBoyut.Text = string.Empty;
            lblEklenme.Text = string.Empty;
            lblEkleyen.Text = string.Empty;
            pictureBox1.Image = Properties.Resources.hazirlaniyor;

            if (lbUrunler.SelectedIndex > -1)
            {
                if (!cbLogo.Checked)
                    UrunResim.GetObjects(lbResimler.Items, ((Urunler)lbUrunler.SelectedItem).ITEMREF, true);
                else
                    TedarikciResim.GetObjects(lbResimler.Items, ((Urunler)lbUrunler.SelectedItem).ITEMREF, true);

                if (lbResimler.Items.Count > 0)
                {
                    lbResimler.SelectedIndex = 0;
                }
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            int itemref = 0;
            try { itemref = Convert.ToInt32(txtUrunKod.Text.Trim()); }
            catch (Exception) { }

            lblCozunurluk.Text = string.Empty;
            lblBoyut.Text = string.Empty;
            lblEklenme.Text = string.Empty;
            lblEkleyen.Text = string.Empty;

            string ozelkod = string.Empty;
            string reykod = string.Empty;

            if (cmbTedarikciler.SelectedIndex > -1)
                ozelkod = ((OzelKodlar)cmbTedarikciler.SelectedItem).OZELKOD;
            if (cmbKategoriler.SelectedIndex > -1)
                reykod = ((ReyonKodlar)cmbKategoriler.SelectedItem).REYKOD;

            GetUrunler(
                itemref, 
                txtUrun.Text, 
                ozelkod,
                reykod,
                txtBarkod.Text.Trim(), 
                rbTumu.Checked, 
                rbResimli.Checked,
                cbYeniler.Checked,
                cbAlfabetik.Checked);

            lbResimler.Items.Clear();
            pictureBox1.Image = Properties.Resources.hazirlaniyor;
        }

        private void lbResimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetResim();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (lbUrunler.SelectedIndex > -1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ResimEkle(ofd.FileName);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbResimler.SelectedIndex > -1)
            {
                if (MessageBox.Show("Resim silinsin mi?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    UrunResim ur = (UrunResim)lbResimler.SelectedItem;
                    Resimler.DoDeleteByResimID(ur.intResimID);
                    ur.DoDelete();
                    lbResimler.Items.RemoveAt(lbResimler.SelectedIndex);
                    lbResimler.SelectedIndex = -1;
                    pictureBox1.Image = Properties.Resources.hazirlaniyor;
                }
            }
        }

        private void cmbTedarikciler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ((ComboBox)sender).SelectedIndex = -1;
            }
        }

        private void txtUrun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAra.PerformClick();
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (lbUrunler.Items.Count == 0)
                return;

            if (lbUrunler.Items.Count > 1000)
                if (MessageBox.Show("Ürün sayısı çok fazla, bu işlem uzun sürebilir. Yinede devam etmek istiyor musunuz?", "Ürün Sayısı Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    return;

            string html = "<html><head><title>Sultanlar UI : Resim Ekleme</title></head><body><table cellpadding='5' cellspacing='0' style='font-family: Verdana; font-size: 10px'>";

            html += "<tr style='color: #D00000; text-decoration: underline;'><td align='center'>Barkod</td>" +
                "<td align='center'>Ürün</td>" +
                "<td align='center'>Grup</td>" +
                "<td align='center'>Tedarikçi</td>" +
                "<td align='center'>Reyon&Kategori</td></tr>";
            for (int i = 0; i < lbUrunler.Items.Count; i++)
            {
                html += "<tr style='height: 36px'><td style='border-top: 1px solid #CCCCCC'>" + ((Urunler)lbUrunler.Items[i]).BARKOD + "</td>" +
                    "<td style='border-top: 1px solid #CCCCCC'>" + ((Urunler)lbUrunler.Items[i]).MALACIK + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC'>" + ((Urunler)lbUrunler.Items[i]).GRUPACIK + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC'>" + ((Urunler)lbUrunler.Items[i]).OZELACIK + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC'>" + ((Urunler)lbUrunler.Items[i]).REYACIK + "</td></tr>";
            }
            html += "</table></body></html>";

            System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\sultanlar-resimekleme.htm", true, Encoding.Unicode);
            sw.Write(html);
            sw.Close();
            sw.Dispose();

            frmYazdir frm = new frmYazdir("C:\\sultanlar-resimekleme.htm");
            frm.ShowDialog();
            File.Delete("C:\\sultanlar-resimekleme.htm");
        }

        private void btnResimsizTedarikciler_Click(object sender, EventArgs e)
        {
            frmINTERNETmusterilersistemde frm = new frmINTERNETmusterilersistemde(true);
            frm.Text = "Resim Eklenmemiş Tedarikçiler";
            frm.ShowDialog();
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            frmINTERNETresimistatistik frm = new frmINTERNETresimistatistik();
            frm.ShowDialog();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            frmINTERNETresimlerrapor frm = new frmINTERNETresimlerrapor();
            frm.ShowDialog();
        }

        private void btnLogoEkle_Click(object sender, EventArgs e)
        {
            if (lbUrunler.SelectedIndex > -1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] resimHamdata = File.ReadAllBytes(ofd.FileName);
                    Image resimHam = Resim.ByteToImage(resimHamdata);

                    if (resimHam.Width < 100 && resimHam.Height < 100)
                    {
                        MessageBox.Show("Eklenmeye çalışılan resmin çözünürlüğü (" + resimHam.Width.ToString() + "x" + resimHam.Height.ToString() + ") belirlenen en düşük değerin (100x100) altında olduğundan resim eklenemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int width = resimHam.Width;
                    int height = resimHam.Height;
                    int widthK = 0;
                    int heightK = 0;
                    int widthO = 0;
                    int heightO = 0;
                    double AR = Convert.ToDouble(width) / Convert.ToDouble(height);
                    if (height > width)
                    {
                        height = 400;
                        heightK = 25;
                        heightO = 100;
                        width = Convert.ToInt32(height * AR);
                        widthK = Convert.ToInt32(heightK * AR);
                        widthO = Convert.ToInt32(heightO * AR);
                    }
                    else if (width > height)
                    {
                        width = 400;
                        widthK = 25;
                        widthO = 100;
                        height = Convert.ToInt32(width / AR);
                        heightK = Convert.ToInt32(widthK / AR);
                        heightO = Convert.ToInt32(widthO / AR);
                    }
                    else
                    {
                        width = 400;
                        widthK = 25;
                        widthO = 100;
                        height = 400;
                        heightK = 25;
                        heightO = 100;
                    }

                    Image resim = Resim.ResimKucult(resimHam, width, height);
                    Image kucukresim = Resim.ResimKucult(resimHam, widthK, heightK);
                    Image ortaresim = Resim.ResimKucult(resimHam, widthO, heightO);
                    pictureBox1.Image = resim;

                    byte[] resimdata = Resim.ImageToByte(resim);
                    byte[] kucukresimdata = Resim.ImageToByte(kucukresim);
                    byte[] ortaresimdata = Resim.ImageToByte(ortaresim);
                    Resimler res = new Resimler(resimdata, kucukresimdata, ortaresimdata);
                    res.DoInsert();

                    TedarikciResim tr = new TedarikciResim(lbResimler.Items.Count + 1, ((Urunler)lbUrunler.SelectedItem).ITEMREF,
                        res.pkResimID, DateTime.Now, frmAna.KAdi.ToUpper());
                    tr.DoInsert();

                    cbLogo.Checked = true;
                    lbResimler.Items.Add(tr);
                    lbResimler.SelectedIndex = lbResimler.Items.Count - 1;
                }
            }
        }

        private void btnLogoSil_Click(object sender, EventArgs e)
        {
            if (!cbLogo.Checked)
            {
                MessageBox.Show("Silinecek logo seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lbResimler.SelectedIndex > -1)
            {
                if (MessageBox.Show("Logo silinsin mi?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    TedarikciResim tr = (TedarikciResim)lbResimler.SelectedItem;
                    Resimler.DoDeleteByResimID(tr.intResimID);
                    tr.DoDelete();
                    lbResimler.Items.RemoveAt(lbResimler.SelectedIndex);
                    lbResimler.SelectedIndex = -1;
                    pictureBox1.Image = Properties.Resources.hazirlaniyor;
                }
            }
            else
            {
                MessageBox.Show("Silinecek logo seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbLogo_CheckedChanged(object sender, EventArgs e)
        {
            lbResimler.Items.Clear();
            lblCozunurluk.Text = string.Empty;
            lblBoyut.Text = string.Empty;
            lblEklenme.Text = string.Empty;
            lblEkleyen.Text = string.Empty;
            pictureBox1.Image = Properties.Resources.hazirlaniyor;

            if (lbUrunler.SelectedIndex > -1)
            {
                if (!cbLogo.Checked)
                    UrunResim.GetObjects(lbResimler.Items, ((Urunler)lbUrunler.SelectedItem).ITEMREF, true);
                else
                    TedarikciResim.GetObjects(lbResimler.Items, ((Urunler)lbUrunler.SelectedItem).ITEMREF, true);

                if (lbResimler.Items.Count > 0)
                {
                    lbResimler.SelectedIndex = 0;
                }
            }
        }

        private void frmINTERNETresimler_DragDrop(object sender, DragEventArgs e)
        {
            if (lbUrunler.SelectedIndex > -1)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if (filePaths[i].ToLower().EndsWith("jpeg") || filePaths[i].ToLower().EndsWith("jpg") || filePaths[i].ToLower().EndsWith("bmp") ||
                            filePaths[i].ToLower().EndsWith("png") || filePaths[i].ToLower().EndsWith("gif") || filePaths[i].ToLower().EndsWith("tif") || filePaths[i].ToLower().EndsWith("tiff"))
                        {
                            ResimEkle(filePaths[i]);
                        }
                    }
                }
            }
        }

        private void frmINTERNETresimler_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btnResimKaydet_Click(object sender, EventArgs e)
        {
            if (lbResimler.SelectedIndex > -1)
            {
                byte[] resimdata = !cbLogo.Checked ? Resimler.GetObjectByResimID(((UrunResim)lbResimler.SelectedItem).intResimID) : Resimler.GetObjectByResimID(((TedarikciResim)lbResimler.SelectedItem).intResimID);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Dosyaları|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Resim.ByteToImage(resimdata).Save(sfd.FileName);
                    ResimlerIndirmeler ri = new ResimlerIndirmeler(((UrunResim)lbResimler.SelectedItem).intResimID,
                        0, DateTime.Now, frmAna.KAdi);
                    ri.DoInsert();
                }
            }
        }
    }
}
