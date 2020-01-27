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
    public partial class frmTekUrunSiparisDurumlari : Form
    {
        public frmTekUrunSiparisDurumlari()
        {
            InitializeComponent();
        }

        private void frmTekUrunSiparisDurumlari_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            SiparisDurumlari.GetObjects(lbSiparisDurumlari.Items, true);
        }

        private void Temizle()
        {
            txtEkle.Text = string.Empty;
            txtGuncelle.Text = string.Empty;
            txtSil.Text = string.Empty;
            lbSiparisDurumlari.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkle.Text.Trim() != string.Empty)
            {
                SiparisDurumlari sd = new SiparisDurumlari(txtEkle.Text.Trim());
                sd.DoInsert();
                GetObjects();
                Temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbSiparisDurumlari.SelectedIndex > -1)
            {
                int index = lbSiparisDurumlari.SelectedIndex;
                SiparisDurumlari sd = ((SiparisDurumlari)lbSiparisDurumlari.SelectedItem);
                sd.strSiparisDurumu = txtGuncelle.Text.Trim();
                sd.DoUpdate();

                GetObjects();
                lbSiparisDurumlari.SelectedIndex = index;
            }
        }

        private void lbSiparisDurumlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSiparisDurumlari.SelectedIndex > -1)
            {
                txtGuncelle.Text = lbSiparisDurumlari.SelectedItem.ToString();
                txtSil.Text = lbSiparisDurumlari.SelectedItem.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbSiparisDurumlari.SelectedIndex > -1)
            {
                if (MessageBox.Show("Seçili sipariş durumunu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    SiparisDurumlari sd = ((SiparisDurumlari)lbSiparisDurumlari.SelectedItem);
                    sd.DoDelete();

                    GetObjects();
                    lbSiparisDurumlari.SelectedIndex = -1;
                }
            }
        }
    }
}
