using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmINTERNETfiyatlisteleri : Form
    {
        public frmINTERNETfiyatlisteleri()
        {
            InitializeComponent();
        }

        private void frmINTERNETfiyatlisteleri_Load(object sender, EventArgs e)
        {
            GetFiyatTipleri();
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObject(cmbFiyatTipleri.Items, true);
        }

        private void btnDosya_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Dosyaları|*.xls;*.xlsx|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDosya.Text = ofd.FileName;
            }
        }

        private void cmbFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDosya.Enabled = Convert.ToBoolean(cmbFiyatTipleri.SelectedIndex > -1);
            txtDosya.Enabled = Convert.ToBoolean(cmbFiyatTipleri.SelectedIndex > -1);

            if (cmbFiyatTipleri.SelectedIndex > -1)
            {
                btnGuncelle.Enabled = FiyatListeleri.FiyatListesiVarMi(((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU);
                btnEkle.Enabled = !btnGuncelle.Enabled;
            }
            else
            {
                btnGuncelle.Enabled = false;
                btnEkle.Enabled = false;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtDosya.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bir dosya seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FiyatListeleri fl = new FiyatListeleri(((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU, File.ReadAllBytes(txtDosya.Text));
            fl.DoInsert();
            MessageBox.Show("Fiyat listesi başarıyla eklendi.", "Fiyat Listesi Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtDosya.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bir dosya seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FiyatListeleri fl = new FiyatListeleri(((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU, File.ReadAllBytes(txtDosya.Text));
            fl.DoUpdate();
            MessageBox.Show("Fiyat listesi başarıyla güncellendi.", "Fiyat Listesi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
