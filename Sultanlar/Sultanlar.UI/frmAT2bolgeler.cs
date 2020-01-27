using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmAT2bolgeler : Form
    {
        public frmAT2bolgeler()
        {
            InitializeComponent();
        }

        private void frmAT2bolgeler_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            AT2_Bolgeler.GetObjects(lbBolgeler.Items, cbPasifler.Checked, true);
        }

        private void Temizle()
        {
            txtEkle.Text = string.Empty;
            txtGuncelle.Text = string.Empty;
            txtSil.Text = string.Empty;
            lbBolgeler.SelectedIndex = -1;
            txtGuncelle.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkle.Text.Trim() != string.Empty)
            {
                AT2_Bolgeler bg = new AT2_Bolgeler(false, txtEkle.Text.Trim().ToUpper());
                bg.DoInsert();

                MessageBox.Show("Ekleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                Temizle();
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbBolgeler.SelectedIndex > -1)
            {
                int index = lbBolgeler.SelectedIndex;
                AT2_Bolgeler bg = ((AT2_Bolgeler)lbBolgeler.SelectedItem);
                bg.strBolge = txtGuncelle.Text.Trim().ToUpper();
                bg.DoUpdate();

                MessageBox.Show("Güncelleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                lbBolgeler.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbBolgeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBolgeler.SelectedIndex > -1)
            {
                txtGuncelle.Enabled = true;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;

                txtGuncelle.Text = lbBolgeler.SelectedItem.ToString();
                txtSil.Text = lbBolgeler.SelectedItem.ToString();
                btnSil.Text = ((AT2_Bolgeler)lbBolgeler.SelectedItem).blPasif ? "Geri Al" : "Sil";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbBolgeler.SelectedIndex > -1)
            {
                if (MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AT2_Bolgeler bg = ((AT2_Bolgeler)lbBolgeler.SelectedItem);
                    bg.blPasif = !bg.blPasif;
                    bg.DoUpdate();

                    if (bg.blPasif)
                    {
                        ArrayList bedeller = new ArrayList();
                        AT2_AracBedeller.GetObjectsByBolgeID(bedeller, false, bg.pkID, true, true);
                        for (int i = 0; i < bedeller.Count; i++)
                        {
                            AT2_AracBedeller bedel = (AT2_AracBedeller)bedeller[i];
                            bedel.blPasif = true;
                            bedel.DoUpdate();
                        }
                    }

                    MessageBox.Show("İşlem başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetObjects();
                    Temizle();
                }
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
            Temizle();
        }

        private void frmAT2bolgeler_SizeChanged(object sender, EventArgs e)
        {
            btnYenile.Location = new Point(this.Width - 40, btnYenile.Location.Y);
            cbPasifler.Location = new Point(this.Width - 115, cbPasifler.Location.Y);
            label1.Location = new Point(this.Width - 236, label1.Location.Y);
            label2.Location = new Point(this.Width - 236, label2.Location.Y);
            label3.Location = new Point(this.Width - 236, label3.Location.Y);
            txtEkle.Location = new Point(this.Width - 236, txtEkle.Location.Y);
            txtGuncelle.Location = new Point(this.Width - 236, txtGuncelle.Location.Y);
            txtSil.Location = new Point(this.Width - 236, txtSil.Location.Y);
            btnEkle.Location = new Point(this.Width - 102, btnEkle.Location.Y);
            btnGuncelle.Location = new Point(this.Width - 102, btnGuncelle.Location.Y);
            btnSil.Location = new Point(this.Width - 102, btnSil.Location.Y);
            lbBolgeler.Width = this.Width - 246;
        }
    }
}
