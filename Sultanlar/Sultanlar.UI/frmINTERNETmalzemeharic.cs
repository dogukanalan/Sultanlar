using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmalzemeharic : Form
    {
        public frmINTERNETmalzemeharic()
        {
            InitializeComponent();
        }

        private void frmINTERNETmalzemeharic_Load(object sender, EventArgs e)
        {
            GetMalzemeler();
            GetAna();
        }

        private void GetMalzemeler()
        {
            Urunler.GetProducts(comboBox1.Items, 0, "", "", "", "", true, true, false, true, true);
            for (int i = 0; i < comboBox1.Items.Count; i++)
                comboBox2.Items.Add(comboBox1.Items[i]);
        }

        private void GetAna()
        {
            MalzemeHaric.GetObjects(listBox1.Items);
            for (int i = 0; i < listBox1.Items.Count; i++)
                listBox3.Items.Add(listBox1.Items[i]);
        }

        private void GetAlt(int ID)
        {
            MalzemeHaric.GetObjectsByAna(listBox2.Items, ID);
            listBox2.SelectedIndex = 0;
        }

        private void GetAltDetay()
        {
            if (listBox2.SelectedIndex > -1)
            {
                MalzemeHaric mh = (MalzemeHaric)listBox2.SelectedItem;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (mh.ITEMREF == ((Urunler)comboBox1.Items[i]).ITEMREF)
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
                textBox1.Text = mh.ADET.ToString();
                textBox2.Text = mh.BASLIK;
                textBox3.Text = mh.ACIKLAMA.Replace("<br>", "\r\n");
            }
            else
            {
                comboBox1.SelectedIndex = -1;
                textBox1.Text = "1";
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
            }
        }

        private void AnaEkle()
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (MessageBox.Show("Ana ürün olarak eklenecek, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MalzemeHaric mh = new MalzemeHaric(
                        MalzemeHaric.GetLastID() + 1,
                        1,
                        ((Urunler)comboBox1.SelectedItem).ITEMREF,
                        0,
                        Convert.ToInt32(textBox1.Text.Trim()),
                        textBox2.Text.Trim(),
                        textBox3.Text.Trim().Replace("\r\n", "<br>"),
                        Resim.ImageToByte(pictureBox1.Image),
                        0);
                    mh.DoInsert();

                    listBox1.Items.Add(mh);

                    MessageBox.Show("Eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            }
        }

        private void Ekle()
        {
            if (comboBox1.SelectedIndex > -1)
            {
                MalzemeHaric ustmalzeme = (MalzemeHaric)listBox1.SelectedItem;

                if (MessageBox.Show("Alt ürün olarak " + (MalzemeHaric.GetSonSira(ustmalzeme.ID) + 1) + ". sıraya eklenecek, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MalzemeHaric mh = new MalzemeHaric(
                    ustmalzeme.ID,
                    MalzemeHaric.GetSonSira(ustmalzeme.ID) + 1,
                    ((Urunler)comboBox1.SelectedItem).ITEMREF,
                    0,
                    Convert.ToInt32(textBox1.Text.Trim()),
                    textBox2.Text.Trim(),
                    textBox3.Text.Trim().Replace("\r\n", "<br>"),
                    Resim.ImageToByte(pictureBox1.Image),
                    0);
                    mh.DoInsert();

                    listBox2.Items.Add(mh);

                    MessageBox.Show("Eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Guncelle(int ID, int SIRA)
        {
            if (MessageBox.Show("Ürün güncellenecek, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MalzemeHaric mh = MalzemeHaric.GetObject(ID, SIRA);
                mh.ITEMREF = ((Urunler)comboBox1.SelectedItem).ITEMREF;
                mh.ADET = Convert.ToInt32(textBox1.Text.Trim());
                mh.BASLIK = textBox2.Text.Trim();
                mh.ACIKLAMA = textBox3.Text.Trim();
                mh.DoUpdate();

                MessageBox.Show("Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AnaSil(int ID)
        {
            MalzemeHaric mh = MalzemeHaric.GetObject(ID, 1);
            mh.AP = 1;
            mh.DoUpdate();
        }

        private void Sil(int ID, int SIRA)
        {
            MalzemeHaric mh = MalzemeHaric.GetObject(ID, SIRA);
            mh.DoDelete();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                MalzemeHaric mh = (MalzemeHaric)listBox1.SelectedItem;

                object resim = MalzemeHaric.GetResim(mh.ID);
                if (resim != null)
                    pictureBox1.Image = Resim.ByteToImage(MalzemeHaric.GetResim(mh.ID));
                else
                    pictureBox1.Image = null;
                label5.Visible = mh.AP == 1;

                GetAlt(mh.ID);
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = listBox2.SelectedIndex == -1;
            button2.Enabled = listBox2.SelectedIndex > -1;
            button3.Enabled = listBox2.SelectedIndex > -1;
            button4.Enabled = listBox2.SelectedIndex > -1;

            GetAltDetay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.ClearSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürün silinecek, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MalzemeHaric mh = (MalzemeHaric)listBox2.SelectedItem;

                if (mh.SIRA > 1)
                {
                    Sil(mh.ID, mh.SIRA);
                    listBox2.Items.Remove(listBox2.SelectedItem);
                }
                else
                    MessageBox.Show("Birinci sıradaki ürün silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MalzemeHaric mh = (MalzemeHaric)listBox2.SelectedItem;

            if (mh.SIRA > 1)
            {
                Guncelle(mh.ID, mh.SIRA);
            }
            else
                MessageBox.Show("Birinci sıradaki ürün güncellenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
                Ekle();
            else
                AnaEkle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    Urunler urun = (Urunler)comboBox1.SelectedItem;

                    textBox1.Text = "1";
                    textBox2.Text = urun.MALACIK;
                    try { textBox3.Text = MalzemeKategoriMarka.GetBaglanti(urun.ITEMREF).Rows[0]["ACIKLAMA"].ToString().Replace("<br>", "\r\n"); }
                    catch (Exception) { textBox3.Text = string.Empty; }

                    int resimid = UrunResim.GetResimIDByUrunID(urun.ITEMREF);
                    if (resimid > 0)
                        pictureBox1.Image = Resim.ByteToImage(Resimler.GetObjectByResimID(resimid));
                    else
                        pictureBox1.Image = null;
                }
                else
                    pictureBox1.Image = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            listBox2.SelectedIndex = 0;
            listBox2.SelectedIndex = -1;
            listBox2.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (MessageBox.Show("Ana ürün pasife alınacak, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AnaSil(((MalzemeHaric)listBox1.SelectedItem).ID);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    frmINTERNETresim frm = new frmINTERNETresim(ofd.FileName);
                    frm.ShowDialog();

                    if (frm.kaydet)
                    {
                        MalzemeHaric mh = (MalzemeHaric)listBox1.SelectedItem;
                        mh.RESIM = Resim.ImageToByte(frm.imaj);
                        mh.DoUpdate();

                        pictureBox1.Image = frm.imaj;

                        MessageBox.Show("Resim güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                string[] arama = textBox4.Text.ToUpper().Split(new char[] { ' ' });
                bool var = false;
                for (int j = 0; j < arama.Length; j++)
                {
                    if (((Urunler)comboBox2.Items[i]).MALACIK.ToUpper().IndexOf(arama[j]) > -1)
                    {
                        var = true;
                    }
                    else
                    {
                        var = false;
                        break;
                    }
                }

                if (var)
                {
                    comboBox1.Items.Add(comboBox2.Items[i]);
                }

                //if (((Urunler)comboBox2.Items[i]).MALACIK.ToUpper().IndexOf(textBox4.Text.ToUpper()) > -1)
                //{
                //    comboBox1.Items.Add(comboBox2.Items[i]);
                //}
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(sfd.FileName);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                string[] arama = textBox5.Text.ToUpper().Split(new char[] { ' ' });
                bool var = false;
                for (int j = 0; j < arama.Length; j++)
                {
                    if (((MalzemeHaric)listBox3.Items[i]).BASLIK.ToUpper().IndexOf(arama[j]) > -1 ||
                        ((MalzemeHaric)listBox3.Items[i]).ID.ToString() == arama[j] ||
                        ((MalzemeHaric)listBox3.Items[i]).ITEMREF.ToString() == arama[j])
                    {
                        var = true;
                    }
                    else
                    {
                        var = false;
                        break;
                    }
                }

                if (var)
                {
                    listBox1.Items.Add(listBox3.Items[i]);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmINTERNETentegra frm = new frmINTERNETentegra();
            frm.ShowDialog();
        }
    }
}
