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
using Sultanlar.UI.Properties;

namespace Sultanlar.UI
{
    public partial class frmINTERNETkutuphane2 : Form
    {
        public frmINTERNETkutuphane2()
        {
            InitializeComponent();
        }

        private void frmINTERNETkutuphane2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Kutuphane2.GetObjects(listBox1.Items, true, "");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                textBox1.Text = ((Kutuphane2)listBox1.SelectedItem).strAd;
                textBox2.Text = ((Kutuphane2)listBox1.SelectedItem).strDosyaTur;
                if (((Kutuphane2)listBox1.SelectedItem).strDosyaTur == "pdf")
                {
                    pictureBox1.Image = Resources.onizlemeyok;
                }
                else
                {
                    pictureBox1.Image = Resim.ByteToImage(Kutuphane2.GetResim(((Kutuphane2)listBox1.SelectedItem).pkID));
                }
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                pictureBox1.Image = null;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                ((Kutuphane2)listBox1.SelectedItem).DoDelete();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                MessageBox.Show("Dosya silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                Kutuphane2 kutup = (Kutuphane2)listBox1.SelectedItem;
                kutup.strAd = textBox1.Text.Trim();
                kutup.binDosya = Resim.ImageToByte(pictureBox1.Image);
                kutup.DoUpdate();

                MessageBox.Show("Dosya güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listBox1.SelectedItem = kutup;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Dosyalar|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.pdf|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|PDF Dosyaları|*.pdf|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] resim = File.ReadAllBytes(ofd.FileName);
                string dosya = ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\") + 1, ofd.FileName.LastIndexOf(".") - (ofd.FileName.LastIndexOf("\\") + 1));
                string uzanti = ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1);
                Kutuphane2 kutup = new Kutuphane2(dosya, uzanti, DateTime.Now, resim);
                kutup.DoInsert();
                listBox1.Items.Add(kutup);

                MessageBox.Show("Dosya eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            byte[] dosya = Kutuphane2.GetResim(((Kutuphane2)listBox1.SelectedItem).pkID);
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Desteklenen Dosyalar|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.pdf|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|PDF Dosyaları|*.pdf|Bütün Dosyalar|*.*";
            sfd.Filter = "Desteklenen Dosyalar|*." + ((Kutuphane2)listBox1.SelectedItem).strDosyaTur + ";";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, dosya);
            }
        }
    }
}
