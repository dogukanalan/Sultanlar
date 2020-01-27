using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmAT2soforlermuavinler : Form
    {
        public frmAT2soforlermuavinler()
        {
            InitializeComponent();
        }

        private void frmAT2soforlermuavinler_Load(object sender, EventArgs e)
        {
            GetObjects();
            Temizle();
        }

        private void GetObjects()
        {
            AT2_SoforlerMuavinler.GetObjects(lbSoforlerMuavinler.Items, cbPasifler.Checked, rbMuavin.Checked, txtAramaAd.Text == "İsim" ? "" : txtAramaAd.Text, txtAramaSoyad.Text == "Soyisim" ? "" : txtAramaSoyad.Text, true);
            AT2_LojistikFirmalar.GetObjects(cmbEkleFirmalar.Items, false, true);
            AT2_LojistikFirmalar.GetObjects(cmbGuncelleFirmalar.Items, false, true);
        }

        private void Temizle()
        {
            txtSil.Text = string.Empty;
            lbSoforlerMuavinler.SelectedIndex = -1;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            txtEkleAd.ForeColor = Color.Gray;
            txtEkleAd.Text = "İsim";
            txtGuncelleAd.ForeColor = Color.Gray;
            txtGuncelleAd.Text = "İsim";
            txtEkleSoyad.ForeColor = Color.Gray;
            txtEkleSoyad.Text = "Soyisim";
            txtGuncelleSoyad.ForeColor = Color.Gray;
            txtGuncelleSoyad.Text = "Soyisim";
            txtEkleTelefon.ForeColor = Color.Gray;
            txtEkleTelefon.Text = "Telefon";
            txtGuncelleTelefon.ForeColor = Color.Gray;
            txtGuncelleTelefon.Text = "Telefon";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkleAd.Text.Trim() != string.Empty && txtEkleAd.Text.Trim().ToUpper() != "İSİM" &&
                txtEkleSoyad.Text.Trim() != string.Empty && txtEkleSoyad.Text.Trim().ToUpper() != "SOYİSİM")
            {
                AT2_SoforlerMuavinler sm = new AT2_SoforlerMuavinler(
                    cmbEkleFirmalar.SelectedIndex > -1 ? ((AT2_LojistikFirmalar)cmbEkleFirmalar.SelectedItem).pkID : 0,
                    false, rbEkleMuavin.Checked,
                    txtEkleAd.Text.Trim().ToUpper() == "İSİM" ? string.Empty : txtEkleAd.Text.Trim().ToUpper(),
                    txtEkleSoyad.Text.Trim().ToUpper() == "SOYİSİM" ? string.Empty : txtEkleSoyad.Text.Trim().ToUpper(),
                    txtEkleTelefon.Text.Trim().ToUpper() == "TELEFON" ? string.Empty : txtEkleTelefon.Text.Trim().ToUpper());
                sm.DoInsert();

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
            if (lbSoforlerMuavinler.SelectedIndex > -1 && 
                txtGuncelleAd.Text.Trim() != string.Empty && txtGuncelleAd.Text.Trim().ToUpper() != "İSİM" &&
                txtGuncelleSoyad.Text.Trim() != string.Empty && txtGuncelleSoyad.Text.Trim().ToUpper() != "SOYİSİM")
            {
                int index = lbSoforlerMuavinler.SelectedIndex;

                AT2_SoforlerMuavinler sm = ((AT2_SoforlerMuavinler)lbSoforlerMuavinler.SelectedItem);
                sm.intLojistikFirmaID = cmbGuncelleFirmalar.SelectedIndex > -1 ? ((AT2_LojistikFirmalar)cmbGuncelleFirmalar.SelectedItem).pkID : 0;
                sm.strAd = txtGuncelleAd.Text.Trim().ToUpper() == "İSİM" ? string.Empty : txtGuncelleAd.Text.Trim().ToUpper();
                sm.strSoyad = txtGuncelleSoyad.Text.Trim().ToUpper() == "SOYİSİM" ? string.Empty : txtGuncelleSoyad.Text.Trim().ToUpper();
                sm.strTelefon = txtGuncelleTelefon.Text.Trim().ToUpper() == "TELEFON" ? string.Empty : txtGuncelleTelefon.Text.Trim().ToUpper();
                sm.DoUpdate();

                MessageBox.Show("Güncelleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                lbSoforlerMuavinler.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbSoforlerMuavinler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSoforlerMuavinler.SelectedIndex > -1)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;

                AT2_SoforlerMuavinler soformuavin = (AT2_SoforlerMuavinler)lbSoforlerMuavinler.SelectedItem;

                rbGuncelleMuavin.Checked = soformuavin.blMuavin;
                rbGuncelleSofor.Checked = !soformuavin.blMuavin;
                txtGuncelleAd.Text = soformuavin.strAd;
                txtGuncelleSoyad.Text = soformuavin.strSoyad;
                txtGuncelleTelefon.Text = soformuavin.strTelefon;

                bool firmagirdi = false;
                for (int i = 0; i < cmbGuncelleFirmalar.Items.Count; i++)
                {
                    if (((AT2_LojistikFirmalar)cmbGuncelleFirmalar.Items[i]).pkID == soformuavin.intLojistikFirmaID)
                    {
                        cmbGuncelleFirmalar.SelectedIndex = i;
                        firmagirdi = true;
                        break;
                    }
                }
                if (!firmagirdi) cmbGuncelleFirmalar.SelectedIndex = -1;

                txtSil.Text = lbSoforlerMuavinler.SelectedItem.ToString();
                btnSil.Text = soformuavin.blPasif ? "Geri Al" : "Sil";

                txtGuncelleAd.ForeColor = Color.Black;
                txtGuncelleSoyad.ForeColor = Color.Black;
                txtGuncelleTelefon.ForeColor = Color.Black;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbSoforlerMuavinler.SelectedIndex > -1)
            {
                if (MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AT2_SoforlerMuavinler sm = ((AT2_SoforlerMuavinler)lbSoforlerMuavinler.SelectedItem);

                    if (sm.blPasif && AT2_LojistikFirmalar.GetObject(sm.intLojistikFirmaID).blPasif) // soformuavin geri alınıyorsa ve firma pasif ise
                    {
                        MessageBox.Show("Lojistik firması silinmiş olduğundan kişi geri alınamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    sm.blPasif = !sm.blPasif;
                    sm.DoUpdate();

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

        private void txtEkleAd_Enter(object sender, EventArgs e)
        {
            if ((((TextBox)sender).Name == "txtEkleAd" || ((TextBox)sender).Name == "txtGuncelleAd" || ((TextBox)sender).Name == "txtAramaAd") && ((TextBox)sender).Text == "İsim")
            {
                ((TextBox)sender).ForeColor = Color.Black;
                ((TextBox)sender).Text = string.Empty;
            }
            else if ((((TextBox)sender).Name == "txtEkleSoyad" || ((TextBox)sender).Name == "txtGuncelleSoyad" || ((TextBox)sender).Name == "txtAramaSoyad") && ((TextBox)sender).Text == "Soyisim")
            {
                ((TextBox)sender).ForeColor = Color.Black;
                ((TextBox)sender).Text = string.Empty;
            }
            else if ((((TextBox)sender).Name == "txtEkleTelefon" || ((TextBox)sender).Name == "txtGuncelleTelefon") && ((TextBox)sender).Text == "Telefon")
            {
                ((TextBox)sender).ForeColor = Color.Black;
                ((TextBox)sender).Text = "0";
            }
        }

        private void txtEkleAd_Leave(object sender, EventArgs e)
        {
            if ((((TextBox)sender).Name == "txtEkleAd" || ((TextBox)sender).Name == "txtGuncelleAd" || ((TextBox)sender).Name == "txtAramaAd") && ((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "İsim";
            }
            else if ((((TextBox)sender).Name == "txtEkleSoyad" || ((TextBox)sender).Name == "txtGuncelleSoyad" || ((TextBox)sender).Name == "txtAramaSoyad") && ((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Soyisim";
            }
            else if ((((TextBox)sender).Name == "txtEkleTelefon" || ((TextBox)sender).Name == "txtGuncelleTelefon") && (((TextBox)sender).Text == "0" || ((TextBox)sender).Text == string.Empty))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Telefon";
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
            Temizle();
        }

        private void rbSofor_CheckedChanged(object sender, EventArgs e)
        {
            //if (((RadioButton)sender).Checked)
            //    btnYenile.PerformClick();
        }

        private void frmAT2soforlermuavinler_SizeChanged(object sender, EventArgs e)
        {
            btnYenile.Location = new Point(this.Width - 40, btnYenile.Location.Y);
            groupBox1.Location = new Point(this.Width - 240, groupBox1.Location.Y);
            groupBox2.Location = new Point(this.Width - 240, groupBox2.Location.Y);
            groupBox3.Location = new Point(this.Width - 240, groupBox3.Location.Y);
            lbSoforlerMuavinler.Width = this.Width - 246;
        }

        private void cmbEkleFirmalar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                ((ComboBox)sender).SelectedIndex = -1;
        }

        private void txtAramaAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnYenile.PerformClick();
            }
        }
    }
}
