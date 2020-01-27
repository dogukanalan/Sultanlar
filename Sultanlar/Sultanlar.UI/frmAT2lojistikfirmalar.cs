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
    public partial class frmAT2lojistikfirmalar : Form
    {
        public frmAT2lojistikfirmalar()
        {
            InitializeComponent();
        }

        private void frmAT2lojistikfirmalar_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            AT2_LojistikFirmalar.GetObjects(lbFirmalar.Items, cbPasifler.Checked, true);
        }

        private void Temizle()
        {
            txtSil.Text = string.Empty;
            lbFirmalar.SelectedIndex = -1;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            txtEkleAd.ForeColor = Color.Gray;
            txtEkleAd.Text = "Firma";
            txtGuncelleAd.ForeColor = Color.Gray;
            txtGuncelleAd.Text = "Firma";
            txtEkleSorumlu.ForeColor = Color.Gray;
            txtEkleSorumlu.Text = "Sorumlu";
            txtGuncelleSorumlu.ForeColor = Color.Gray;
            txtGuncelleSorumlu.Text = "Sorumlu";
            txtEkleTelefon.ForeColor = Color.Gray;
            txtEkleTelefon.Text = "Telefon";
            txtGuncelleTelefon.ForeColor = Color.Gray;
            txtGuncelleTelefon.Text = "Telefon";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkleAd.Text.Trim() != string.Empty && txtEkleAd.Text.Trim().ToUpper() != "FİRMA")
            {
                AT2_LojistikFirmalar lf = new AT2_LojistikFirmalar(false, 
                    txtEkleAd.Text.Trim().ToUpper(),
                    txtEkleSorumlu.Text.Trim().ToUpper() == "SORUMLU" ? string.Empty : txtEkleSorumlu.Text.Trim().ToUpper(),
                    txtEkleTelefon.Text.Trim().ToUpper() == "TELEFON" ? string.Empty : txtEkleTelefon.Text.Trim().ToUpper());
                lf.DoInsert();

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
            if (lbFirmalar.SelectedIndex > -1 && txtGuncelleAd.Text.Trim() != string.Empty && txtGuncelleAd.Text.Trim().ToUpper() != "FİRMA")
            {
                int index = lbFirmalar.SelectedIndex;
                AT2_LojistikFirmalar lf = ((AT2_LojistikFirmalar)lbFirmalar.SelectedItem);
                lf.strLojistikFirma = txtGuncelleAd.Text.Trim().ToUpper();
                lf.strSorumlu = txtGuncelleSorumlu.Text.Trim().ToUpper() == "SORUMLU" ? string.Empty : txtGuncelleSorumlu.Text.Trim().ToUpper();
                lf.strTelefon = txtGuncelleTelefon.Text.Trim().ToUpper() == "TELEFON" ? string.Empty : txtGuncelleTelefon.Text.Trim().ToUpper();
                lf.DoUpdate();

                MessageBox.Show("Güncelleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                lbFirmalar.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbFirmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFirmalar.SelectedIndex > -1)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;

                AT2_LojistikFirmalar lf = ((AT2_LojistikFirmalar)lbFirmalar.SelectedItem);
                txtGuncelleAd.Text = lf.strLojistikFirma;
                txtGuncelleSorumlu.Text = lf.strSorumlu;
                txtGuncelleTelefon.Text = lf.strTelefon;
                txtSil.Text = lbFirmalar.SelectedItem.ToString();
                btnSil.Text = lf.blPasif ? "Geri Al" : "Sil";

                txtGuncelleAd.ForeColor = Color.Black;
                txtGuncelleSorumlu.ForeColor = Color.Black;
                txtGuncelleTelefon.ForeColor = Color.Black;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbFirmalar.SelectedIndex > -1)
            {
                if (MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AT2_LojistikFirmalar lf = ((AT2_LojistikFirmalar)lbFirmalar.SelectedItem);
                    lf.blPasif = !lf.blPasif;
                    lf.DoUpdate();

                    if (lf.blPasif)
                    {
                        ArrayList araclar = new ArrayList();
                        AT2_Araclar.GetObjects(araclar, false, lf.pkID, 0, string.Empty, true);
                        for (int i = 0; i < araclar.Count; i++)
                        {
                            AT2_Araclar ar = (AT2_Araclar)araclar[i];
                            ar.blPasif = true;
                            ar.DoUpdate();

                            ArrayList bedeller = new ArrayList();
                            AT2_AracBedeller.GetObjectsByAracID(bedeller, false, ar.pkID, true, true);
                            for (int j = 0; j < bedeller.Count; j++)
                            {
                                AT2_AracBedeller bedel = (AT2_AracBedeller)bedeller[j];
                                bedel.blPasif = true;
                                bedel.DoUpdate();
                            }
                        }

                        ArrayList soforler = new ArrayList();
                        AT2_SoforlerMuavinler.GetObjectsByFirmaID(soforler, false, false, lf.pkID, true);
                        for (int i = 0; i < soforler.Count; i++)
                        {
                            AT2_SoforlerMuavinler sofor = (AT2_SoforlerMuavinler)soforler[i];
                            sofor.blPasif = true;
                            sofor.DoUpdate();
                        }

                        ArrayList muavinler = new ArrayList();
                        AT2_SoforlerMuavinler.GetObjectsByFirmaID(muavinler, false, true, lf.pkID, true);
                        for (int i = 0; i < soforler.Count; i++)
                        {
                            AT2_SoforlerMuavinler muavin = (AT2_SoforlerMuavinler)muavinler[i];
                            muavin.blPasif = true;
                            muavin.DoUpdate();
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

        private void txtEkleAd_Enter(object sender, EventArgs e)
        {
            if ((((TextBox)sender).Name == "txtEkleAd" || ((TextBox)sender).Name == "txtGuncelleAd") && ((TextBox)sender).Text == "Firma")
            {
                ((TextBox)sender).ForeColor = Color.Black;
                ((TextBox)sender).Text = string.Empty;
            }
            else if ((((TextBox)sender).Name == "txtEkleSorumlu" || ((TextBox)sender).Name == "txtGuncelleSorumlu") && ((TextBox)sender).Text == "Sorumlu")
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
            if ((((TextBox)sender).Name == "txtEkleAd" || ((TextBox)sender).Name == "txtGuncelleAd") && ((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Firma";
            }
            else if ((((TextBox)sender).Name == "txtEkleSorumlu" || ((TextBox)sender).Name == "txtGuncelleSorumlu") && ((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Sorumlu";
            }
            else if ((((TextBox)sender).Name == "txtEkleTelefon" || ((TextBox)sender).Name == "txtGuncelleTelefon") && (((TextBox)sender).Text == "0" || ((TextBox)sender).Text == string.Empty))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Telefon";
            }
        }

        private void frmAT2lojistikfirmalar_SizeChanged(object sender, EventArgs e)
        {
            btnYenile.Location = new Point(this.Width - 40, btnYenile.Location.Y);
            cbPasifler.Location = new Point(this.Width - 115, cbPasifler.Location.Y);
            groupBox1.Location = new Point(this.Width - 240, groupBox1.Location.Y);
            groupBox2.Location = new Point(this.Width - 240, groupBox2.Location.Y);
            groupBox3.Location = new Point(this.Width - 240, groupBox3.Location.Y);
            lbFirmalar.Width = this.Width - 246;
        }
    }
}
