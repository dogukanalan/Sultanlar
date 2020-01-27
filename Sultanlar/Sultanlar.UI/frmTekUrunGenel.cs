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
    public partial class frmTekUrunGenel : Form
    {
        public frmTekUrunGenel()
        {
            InitializeComponent();
        }

        private void frmTekUrunGenel_Load(object sender, EventArgs e)
        {
            GetUrunler();
        }

        private void GetUrunler()
        {
            Urunler.GetObjects(cmbUrunler.Items, true);
        }

        private void cmbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedIndex > -1)
            {
                btnGuncelle.Enabled = true;

                Urunler urun = (Urunler)cmbUrunler.SelectedItem;

                txtUrunFiyati.Text = urun.mnUrunFiyati.ToString();
                txtUrunFiyati2.Text = urun.mnUrunFiyati2.ToString();
                txtUrunFiyati3.Text = urun.mnUrunFiyati3.ToString();
                txtUrunFiyati4.Text = urun.mnUrunFiyati4.ToString();
                txtUrunFiyati5.Text = urun.mnUrunFiyati5.ToString();
                rbGram.Checked = urun.blGram;
                rbDesi.Checked = !urun.blGram;
                txtDesi.Text = urun.flDesi.ToString();
                txtGram.Text = urun.flGram.ToString();
                txtZiyaretciSayisi.Text = urun.intZiyaretciSayisi.ToString();
            }
            else
            {
                btnGuncelle.Enabled = false;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Urunler urun = (Urunler)cmbUrunler.SelectedItem;

            urun.mnUrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text.Trim());
            urun.mnUrunFiyati2 = Convert.ToDecimal(txtUrunFiyati2.Text.Trim());
            urun.mnUrunFiyati3 = Convert.ToDecimal(txtUrunFiyati3.Text.Trim());
            urun.mnUrunFiyati4 = Convert.ToDecimal(txtUrunFiyati4.Text.Trim());
            urun.mnUrunFiyati5 = Convert.ToDecimal(txtUrunFiyati5.Text.Trim());
            urun.blGram = rbGram.Checked;
            urun.flDesi = Convert.ToDouble(txtDesi.Text.Trim());
            urun.flGram = Convert.ToDouble(txtGram.Text.Trim());

            urun.DoUpdate();
        }
    }
}
