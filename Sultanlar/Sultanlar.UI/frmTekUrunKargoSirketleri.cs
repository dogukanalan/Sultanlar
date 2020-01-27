using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TekUrun.DatabaseObjects;

namespace Sultanlar.UI
{
    public partial class frmTekUrunKargoSirketleri : Form
    {
        public frmTekUrunKargoSirketleri()
        {
            InitializeComponent();
        }

        private void frmTekUrunKargoSirketleri_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            KargoSirketleri.GetObjects(lbKargoSirketleri.Items, true);
        }

        private void Temizle()
        {
            txtEkleSirket.Text = string.Empty;
            txtEkleFiyat.Text = string.Empty;
            txtGuncelleSirket.Text = string.Empty;
            txtGuncelleFiyat.Text = string.Empty;
            txtSilSirket.Text = string.Empty;
            lbKargoSirketleri.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkleSirket.Text.Trim() != string.Empty && txtEkleFiyat.Text.Trim() != string.Empty && txtEkleFiyatDesi.Text.Trim() != string.Empty)
            {
                KargoSirketleri ks = new KargoSirketleri
                    (txtEkleSirket.Text.Trim(), Convert.ToDecimal(txtEkleFiyat.Text.Trim()), Convert.ToDecimal(txtEkleFiyatDesi.Text.Trim()));
                ks.DoInsert();
                GetObjects();
                Temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbKargoSirketleri.SelectedIndex > -1)
            {
                int index = lbKargoSirketleri.SelectedIndex;
                KargoSirketleri ks = ((KargoSirketleri)lbKargoSirketleri.SelectedItem);
                ks.strKargoSirketi = txtGuncelleSirket.Text.Trim();
                ks.mnKargoFiyati = Convert.ToDecimal(txtGuncelleFiyat.Text.Trim());
                ks.mnKargoFiyatiDesi = Convert.ToDecimal(txtGuncelleFiyatDesi.Text.Trim());
                ks.DoUpdate();

                GetObjects();
                lbKargoSirketleri.SelectedIndex = index;
            }
        }

        private void lbKargoSirketleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKargoSirketleri.SelectedIndex > -1)
            {
                txtGuncelleSirket.Text = lbKargoSirketleri.SelectedItem.ToString();
                txtGuncelleFiyat.Text = ((KargoSirketleri)lbKargoSirketleri.SelectedItem).mnKargoFiyati.ToString();
                txtGuncelleFiyatDesi.Text = ((KargoSirketleri)lbKargoSirketleri.SelectedItem).mnKargoFiyatiDesi.ToString();

                txtSilSirket.Text = lbKargoSirketleri.SelectedItem.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbKargoSirketleri.SelectedIndex > -1)
            {
                if (MessageBox.Show("Seçili kargo şirketini silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    KargoSirketleri ks = ((KargoSirketleri)lbKargoSirketleri.SelectedItem);
                    ks.DoDelete();

                    GetObjects();
                    lbKargoSirketleri.SelectedIndex = -1;
                }
            }
        }
    }
}
