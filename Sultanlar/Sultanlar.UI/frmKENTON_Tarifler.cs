using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Design;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.Class;
using System.IO;
using mshtml;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmKENTON_Tarifler : Form
    {
        public frmKENTON_Tarifler()
        {
            InitializeComponent();
        }

        Editor edMalzeme;
        Editor edHazirlanis;
        Editor edKulMalzeme;
        Editor edKulHazirlanis;
        Editor edEkleMalzeme;
        Editor edEkleHazirlanis;

        private void frmKENTON_Tarifler_Load(object sender, EventArgs e)
        {
            edMalzeme = new Editor();
            edMalzeme.Size = textBox2.Size;
            edMalzeme.Location = textBox2.Location;
            splitContainer1.Panel2.Controls.Add(edMalzeme);
            edMalzeme.BringToFront();
            edHazirlanis = new Editor();
            edHazirlanis.Size = textBox3.Size;
            edHazirlanis.Location = textBox3.Location;
            splitContainer1.Panel2.Controls.Add(edHazirlanis);
            edHazirlanis.BringToFront();
            
            edKulMalzeme = new Editor();
            edKulMalzeme.Size = textBox6.Size;
            edKulMalzeme.Location = textBox6.Location;
            splitContainer2.Panel2.Controls.Add(edKulMalzeme);
            edKulMalzeme.BringToFront();
            edKulHazirlanis = new Editor();
            edKulHazirlanis.Size = textBox7.Size;
            edKulHazirlanis.Location = textBox7.Location;
            splitContainer2.Panel2.Controls.Add(edKulHazirlanis);
            edKulHazirlanis.BringToFront();

            edEkleMalzeme = new Editor();
            edEkleMalzeme.Size = textBox10.Size;
            edEkleMalzeme.Location = textBox10.Location;
            tabPage2.Controls.Add(edEkleMalzeme);
            edEkleMalzeme.BringToFront();
            edEkleHazirlanis = new Editor();
            edEkleHazirlanis.Size = textBox11.Size;
            edEkleHazirlanis.Location = textBox11.Location;
            tabPage2.Controls.Add(edEkleHazirlanis);
            edEkleHazirlanis.BringToFront();

            sbYorumlar.Parent = this;
            sbYorumlar.Location = new Point(550, 4);
            sbYorumlar.BringToFront();

            GetTarifler();
            GetUrunler();
            GetTarifVideo();
        }

        private void GetTarifVideo()
        {
            Videolar.GetObjects(lbTarifVideo2.Items, 0, 1000, "", "");
        }

        private void GetUrunler()
        {
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT [Web-Malzeme-Full].[ITEMREF] AS UrunID, IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, [MAL ACIK] AS Ad,[BARKOD] AS Barkod,strKategori AS Kategori FROM [Web-Malzeme-Full] LEFT OUTER JOIN tblKENTON_UrunKategori ON [Web-Malzeme-Full].[ITEMREF] = tblKENTON_UrunKategori.intUrunID LEFT OUTER JOIN tblKENTON_KategorilerUrun ON tblKENTON_UrunKategori.intKategoriID = tblKENTON_KategorilerUrun.pkID WHERE [MAL ACIK] LIKE '%KENTON%' AND IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) != 0 ORDER BY [MAL ACIK] ASC");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Urun ur = new Urun();
                ur.ID = Convert.ToInt32(dt.Rows[i]["UrunID"]);
                ur.Ad = dt.Rows[i]["Ad"].ToString();
                lbUrunler.Items.Add(ur);
            }

            KategorilerUrun.GetObjects(clbKategoriler.Items);
        }

        public class Urun
        {
            public int ID { get; set; }
            public string Ad { get; set; }
            public override string ToString() { return this.Ad; }
        }

        private void GetTarifler()
        {
            Tarifler.GetObjects(listBoxControl1.Items, false);
            Tarifler.GetObjects(listBox1.Items, true);
            Tarifler.GetObjects(lbTarifVideo.Items, false);

            KategorilerTarif.GetObjects(checkedListBox1.Items);
            KategorilerTarif.GetObjects(checkedListBox2.Items);
            KategorilerTarif.GetObjects(checkedListBox3.Items);
        }

        private void GetTarifDetay()
        {
            if (listBoxControl1.SelectedIndex > -1)
            {
                edMalzeme.Document.Body.Style = "font-size: 12px; font-family: Tahoma";
                edHazirlanis.Document.Body.Style = "font-size: 12px; font-family: Tahoma";

                Tarifler tarif = (Tarifler)listBoxControl1.SelectedItem;
                textBox1.Text = tarif.strBaslik;
                edMalzeme.BodyHtml = tarif.strMalzemeler;
                edHazirlanis.BodyHtml = tarif.strHazirlanis;
                pictureBox1.Image = Resim.ByteToImage(Tarifler.GetResim(tarif.pkID));
                pictureBox2.Image = Tarifler.GetResimUrunler(tarif.pkID) != null ? Resim.ByteToImage(Tarifler.GetResimUrunler(tarif.pkID)) : null;
                textBox4.Text = tarif.strUrunlerLink;

                TarifUrun.GetObjects(listBox2.Items, tarif.pkID);

                List<TarifKategori> kategoriler = TarifKategori.GetObjectsByTarifID(tarif.pkID);

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                    for (int j = 0; j < kategoriler.Count; j++)
                    {
                        if (((KategorilerTarif)checkedListBox1.Items[i]).pkID == kategoriler[j].intKategoriID)
                            checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void GetTarifDetay2()
        {
            if (listBox1.SelectedIndex > -1)
            {
                edKulMalzeme.Document.Body.Style = "font-size: 12px; font-family: Tahoma";
                edKulHazirlanis.Document.Body.Style = "font-size: 12px; font-family: Tahoma";

                Tarifler tarif = (Tarifler)listBox1.SelectedItem;
                textBox5.Text = tarif.strBaslik;
                edKulMalzeme.BodyHtml = tarif.strMalzemeler;
                edKulHazirlanis.BodyHtml = tarif.strHazirlanis;
                pictureBox3.Image = Resim.ByteToImage(Tarifler.GetResim(tarif.pkID));
                pictureBox4.Image = Tarifler.GetResimUrunler(tarif.pkID) != null ? Resim.ByteToImage(Tarifler.GetResimUrunler(tarif.pkID)) : null;
                textBox8.Text = tarif.strUrunlerLink;
                checkBox1.Checked = tarif.blOnay;
                lblEkleyen.Text = "Ekleyen: " + tarif.Uye.strAd + " " + tarif.Uye.strSoyad;
                lblTarih.Text = tarif.dtTarih.ToString();

                List<TarifKategori> kategoriler = TarifKategori.GetObjectsByTarifID(tarif.pkID);

                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, false);
                    for (int j = 0; j < kategoriler.Count; j++)
                    {
                        if (((KategorilerTarif)checkedListBox3.Items[i]).pkID == kategoriler[j].intKategoriID)
                            checkedListBox3.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Enabled = listBoxControl1.SelectedIndex > -1;
            GetTarifDetay();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Enabled = listBox1.SelectedIndex > -1;
            GetTarifDetay2();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            else if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                pictureBox1.Image = null;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox2.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            else if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                pictureBox2.Image = null;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox3.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            else if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                pictureBox3.Image = null;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox4.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            else if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                pictureBox4.Image = null;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox5.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            else if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                pictureBox5.Image = null;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox6.Image = Resim.ByteToImage(File.ReadAllBytes(ofd.FileName));
            else if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                pictureBox6.Image = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || edMalzeme.BodyHtml == string.Empty ||edHazirlanis.BodyHtml == string.Empty || pictureBox1.Image == null)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Tarifler tarif = (Tarifler)listBoxControl1.SelectedItem;
            tarif.strBaslik = textBox1.Text.Trim();
            tarif.strMalzemeler = edMalzeme.BodyHtml.Replace("<p>", "").Replace("</p>", "<br>");
            tarif.strHazirlanis = edHazirlanis.BodyHtml.Replace("<p>", "").Replace("</p>", "<br>");
            tarif.binResim = Resim.ImageToByte(pictureBox1.Image);
            tarif.binResimUrunler = pictureBox2.Image == null ? null : Resim.ImageToByte(pictureBox2.Image);
            tarif.strUrunlerLink = textBox4.Text.Trim();
            tarif.DoUpdate();
            
            List<TarifKategori> kategoriler = TarifKategori.GetObjectsByTarifID(tarif.pkID);
            for (int i = 0; i < kategoriler.Count; i++)
                kategoriler[i].DoDelete();

            List<TarifUrun> urunler = new List<TarifUrun>();
            TarifUrun.GetObjects(urunler, tarif.pkID);
            for (int i = 0; i < urunler.Count; i++)
                urunler[i].DoDelete();

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                TarifUrun ta = (TarifUrun)listBox2.Items[i];
                ta.intTarifID = tarif.pkID;
                ta.DoInsert();
            }

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (!TarifKategori.VarMi(tarif.pkID, ((KategorilerTarif)checkedListBox1.Items[i]).pkID))
                    {
                        TarifKategori tk = new TarifKategori(tarif.pkID, ((KategorilerTarif)checkedListBox1.Items[i]).pkID);
                        tk.DoInsert();
                    }
                }
                else
                {
                    if (TarifKategori.VarMi(tarif.pkID, ((KategorilerTarif)checkedListBox1.Items[i]).pkID))
                    {
                        TarifKategori tk = TarifKategori.GetObject(tarif.pkID, ((KategorilerTarif)checkedListBox1.Items[i]).pkID);
                        tk.DoDelete();
                    }
                }
            }

            MessageBox.Show("Tarif güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listBoxControl1.SelectedItem = tarif;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == string.Empty || edKulMalzeme.BodyHtml == string.Empty || edKulHazirlanis.BodyHtml == string.Empty || pictureBox3.Image == null)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Tarifler tarif = (Tarifler)listBox1.SelectedItem;
            tarif.strBaslik = textBox5.Text.Trim();
            tarif.strMalzemeler = edKulMalzeme.BodyHtml.Replace("<p>", "").Replace("</p>", "<br>");
            tarif.strHazirlanis = edKulHazirlanis.BodyHtml.Replace("<p>", "").Replace("</p>", "<br>");
            tarif.binResim = Resim.ImageToByte(pictureBox3.Image);
            tarif.binResimUrunler = textBox8.Text.Trim() == string.Empty ? null : Resim.ImageToByte(pictureBox4.Image);
            tarif.strUrunlerLink = textBox8.Text.Trim();
            tarif.blOnay = checkBox1.Checked;
            tarif.DoUpdate();

            if (tarif.blOnay)
            {
                Eposta.EpostaGonder("mail.kenton.com.tr", "app@kenton.com.tr", "[8TAZgK[=fCB", "Tarif Sepeti", tarif.Uye.strEposta, 25, false, "Tarifiniz onaylandı",
                        "Sayın üyemiz, '" + tarif.strBaslik + "' başlıklı tarifiniz onaylanmıştır. Teşekkür ederiz.");
            }

            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                if (checkedListBox3.GetItemChecked(i))
                {
                    if (!TarifKategori.VarMi(tarif.pkID, ((KategorilerTarif)checkedListBox3.Items[i]).pkID))
                    {
                        TarifKategori tk = new TarifKategori(tarif.pkID, ((KategorilerTarif)checkedListBox3.Items[i]).pkID);
                        tk.DoInsert();
                    }
                }
                else
                {
                    if (TarifKategori.VarMi(tarif.pkID, ((KategorilerTarif)checkedListBox3.Items[i]).pkID))
                    {
                        TarifKategori tk = TarifKategori.GetObject(tarif.pkID, ((KategorilerTarif)checkedListBox3.Items[i]).pkID);
                        tk.DoDelete();
                    }
                }
            }

            MessageBox.Show("Tarif güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listBox1.SelectedItem = tarif;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Trim() == string.Empty || edEkleMalzeme.BodyHtml == string.Empty || edEkleHazirlanis.BodyHtml == string.Empty || pictureBox5.Image == null)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Tarifler tarif = new Tarifler();
            tarif.strBaslik = textBox9.Text.Trim();
            tarif.strMalzemeler = edEkleMalzeme.BodyHtml.Replace("<p>", "").Replace("</p>", "<br>");
            tarif.strHazirlanis = edEkleHazirlanis.BodyHtml.Replace("<p>", "").Replace("</p>", "<br>");
            tarif.binResim = Resim.ImageToByte(pictureBox5.Image);
            tarif.binResimUrunler = textBox12.Text.Trim() == string.Empty ? null : Resim.ImageToByte(pictureBox6.Image);
            tarif.strUrunlerLink = textBox12.Text.Trim();
            tarif.blOnay = true;
            tarif.DoInsert();

            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                TarifUrun ta = (TarifUrun)listBox3.Items[i];
                ta.intTarifID = tarif.pkID;
                ta.DoInsert();
            }

            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                TarifKategori tk = new TarifKategori(tarif.pkID, ((KategorilerTarif)checkedListBox2.CheckedItems[i]).pkID);
                tk.DoInsert();
            }

            MessageBox.Show("Tarif eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GetTarifler();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            frmKENTON_TariflerUrun frm = new frmKENTON_TariflerUrun();
            frm.ShowDialog();
            if (frm.urunid != 0)
            {
                TarifUrun tu = new TarifUrun(0, frm.urunid);
                listBox3.Items.Add(tu);
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > -1)
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        bool ilkbas = false;
        private void lbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilkbas = true;
            List<UrunKategori> liste = UrunKategori.GetObjectsByUrunID(((Urun)lbUrunler.SelectedItem).ID);
            for (int j = 0; j < clbKategoriler.Items.Count; j++)
            {
                clbKategoriler.SetItemChecked(j, false);
                for (int i = 0; i < liste.Count; i++)
                    if (liste[i].intKategoriID == ((KategorilerUrun)clbKategoriler.Items[j]).pkID)
                        clbKategoriler.SetItemChecked(j, true);
            }
            ilkbas = false;
        }

        private void clbKategoriler_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ilkbas)
            {
                if (UrunKategori.VarMi(((Urun)lbUrunler.SelectedItem).ID, ((KategorilerUrun)clbKategoriler.SelectedItem).pkID))
                {
                    UrunKategori urkat = UrunKategori.GetObject(((Urun)lbUrunler.SelectedItem).ID, ((KategorilerUrun)clbKategoriler.SelectedItem).pkID);
                    urkat.DoDelete();
                }
                else
                {
                    UrunKategori urkat = new UrunKategori(((Urun)lbUrunler.SelectedItem).ID, ((KategorilerUrun)clbKategoriler.SelectedItem).pkID);
                    urkat.DoInsert();
                }
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            frmKENTON_TariflerUrun frm = new frmKENTON_TariflerUrun();
            frm.ShowDialog();
            if (frm.urunid != 0)
            {
                TarifUrun tu = new TarifUrun(0, frm.urunid);
                listBox2.Items.Add(tu);
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void lbTarifVideo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ilkbasvideo && lbTarifVideo2.SelectedIndex > -1)
            {
                TarifVideo tv1 = TarifVideo.GetObjectByTarif(((Tarifler)lbTarifVideo.SelectedItem).pkID);
                tv1.intVideoID = ((Videolar)lbTarifVideo2.SelectedItem).pkID;
                if (tv1.intTarifID == 0)
                {
                    tv1.intTarifID = ((Tarifler)lbTarifVideo.SelectedItem).pkID;
                    tv1.DoInsert();
                }
                else
                {
                    tv1.DoUpdate();
                }
            }
        }

        bool ilkbasvideo = false;
        private void lbTarifVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilkbasvideo = true;
            lbTarifVideo2.SelectedIndex = -1;
            TarifVideo tv1 = TarifVideo.GetObjectByTarif(((Tarifler)lbTarifVideo.SelectedItem).pkID);
            for (int i = 0; i < lbTarifVideo2.Items.Count; i++)
            {
                if (((Videolar)lbTarifVideo2.Items[i]).pkID == tv1.intVideoID)
                {
                    lbTarifVideo2.SelectedIndex = i;
                    break;
                }
            }
            ilkbasvideo = false;
        }

        private void lbTarifVideo2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lbTarifVideo2.SelectedIndex > -1)
                {
                    ilkbasvideo = true;
                    TarifVideo tv1 = TarifVideo.GetObjectByTarif(((Tarifler)lbTarifVideo.SelectedItem).pkID);
                    tv1.DoDelete();
                    lbTarifVideo2.ClearSelected();
                    ilkbasvideo = false;
                }
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (MessageBox.Show("Tarifi sildiğiniz zaman tarif ile ilgili tüm bilgiler silinecektir. Devam etmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Tarifler tarif = (Tarifler)listBox1.SelectedItem;
                    tarif.DoDelete();
                    Tarifler.GetObjects(listBox1.Items, true);
                }
            }
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                byte[] resimdata = ((Tarifler)listBox1.SelectedItem).GetResim();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Dosyaları|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Resim.ByteToImage(resimdata).Save(sfd.FileName);
                }
            }
        }

        private void sbYorumlar_Click(object sender, EventArgs e)
        {
            frmKENTON_Yorumlar frm = new frmKENTON_Yorumlar();
            frm.Show();
        }
    }
}
