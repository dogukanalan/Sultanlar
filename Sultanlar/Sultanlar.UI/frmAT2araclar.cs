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
    public partial class frmAT2araclar : Form
    {
        public frmAT2araclar()
        {
            InitializeComponent();
        }

        private void frmAT2araclar_Load(object sender, EventArgs e)
        {
            AT2_LojistikFirmalar.GetObjects(cmbAramaLojistikFirmasi.Items, false, true);
            AT2_AracTipler.GetObjects(cmbAramaAracTipi.Items, false, true);

            GetObjects();
        }

        private void GetObjects()
        {
            AT2_LojistikFirmalar.GetObjects(cmbEkleLojistikFirmasi.Items, false, true);
            AT2_LojistikFirmalar.GetObjects(cmbGuncelleLojistikFirmasi.Items, false, true);
            AT2_AracTipler.GetObjects(cmbEkleAracTipi.Items, false, true);
            AT2_AracTipler.GetObjects(cmbGuncelleAracTipi.Items, false, true);
            AT2_SoforlerMuavinler.GetObjects(cmbEkleSofor.Items, false, false, "", "", true);
            AT2_SoforlerMuavinler.GetObjects(cmbGuncelleSofor.Items, false, false, "", "", true);
            AT2_SoforlerMuavinler.GetObjects(cmbEkleMuavin.Items, false, true, "", "", true);
            AT2_SoforlerMuavinler.GetObjects(cmbGuncelleMuavin.Items, false, true, "", "", true);

            int aractip = cmbAramaAracTipi.SelectedIndex > -1 ? ((AT2_AracTipler)cmbAramaAracTipi.SelectedItem).pkID : 0;
            int firma = cmbAramaLojistikFirmasi.SelectedIndex > -1 ? ((AT2_LojistikFirmalar)cmbAramaLojistikFirmasi.SelectedItem).pkID : 0;
            AT2_Araclar.GetObjects(lbAraclar.Items, cbPasifler.Checked, firma, aractip, txtAramaPlaka.Text, true);
        }

        private void Temizle()
        {
            cmbEkleAracTipi.SelectedIndex = -1;
            cmbEkleLojistikFirmasi.SelectedIndex = -1;
            txtEkleSorumlu.Text = string.Empty;
            txtEklePlaka.Text = string.Empty;
            txtEkleYil.Text = string.Empty;
            txtEkleTonaj.Text = string.Empty;
            txtEkleHacim.Text = string.Empty;
            cmbGuncelleAracTipi.SelectedIndex = -1;
            cmbGuncelleLojistikFirmasi.SelectedIndex = -1;
            txtGuncelleSorumlu.Text = string.Empty;
            txtGuncellePlaka.Text = string.Empty;
            txtGuncelleYil.Text = string.Empty;
            txtGuncelleTonaj.Text = string.Empty;
            txtGuncelleHacim.Text = string.Empty;
            txtSil.Text = string.Empty;
            lbAraclar.SelectedIndex = -1;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private string PlakaDogrult(string Plaka)
        {
            string donendeger = string.Empty;

            if (!char.IsDigit(Plaka, 0))
                return Plaka;

            char[] haneler = Plaka.ToCharArray();

            //donendeger += haneler[0];
            //donendeger += haneler[1];

            //bool numarabitmis = false;
            //for (int i = 2; i < haneler.Length; i++)
            //{
            //    if (i == 2)
            //    {
            //        if (haneler[2] != ' ')
            //            donendeger += " " + haneler[2];
            //        else
            //            donendeger += haneler[i];
            //    }
            //    else
            //    {
            //        if (char.IsNumber(haneler[i]) && !numarabitmis)
            //        {
            //            donendeger += " " + haneler[i];
            //            numarabitmis = true;
            //        }
            //        else
            //        {
            //            donendeger += haneler[i];
            //        }
            //    }
            //}

            //return donendeger.Replace("  ", " ");

            int harfegeldi = 0;
            for (int i = 0; i < haneler.Length; i++)
            {
                if (char.IsNumber(haneler[i]))
                {
                    donendeger += haneler[i];
                }
                else if (haneler[i] == ' ')
                {
                    harfegeldi = i + 1;
                    break;
                }
                else
                {
                    harfegeldi = i;
                    break;
                }
            }
            donendeger += " ";
            int sayiyageldi = 0;
            for (int i = harfegeldi; i < haneler.Length; i++)
            {
                if (!char.IsNumber(haneler[i]) && haneler[i] != ' ')
                {
                    donendeger += haneler[i];
                }
                else
                {
                    sayiyageldi = i;
                    break;
                }
            }
            donendeger += " ";
            for (int i = sayiyageldi; i < haneler.Length; i++)
            {
                if (char.IsNumber(haneler[i]))
                {
                    donendeger += haneler[i];
                }
            }

            return donendeger;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbEkleAracTipi.SelectedIndex > -1 && cmbEkleLojistikFirmasi.SelectedIndex > -1 && txtEklePlaka.Text.Trim() != string.Empty && txtEkleTonaj.Text.Trim() != string.Empty && txtEkleHacim.Text.Trim() != string.Empty)
            {
                try { Convert.ToDecimal(txtEkleTonaj.Text.Trim()); Convert.ToDecimal(txtEkleHacim.Text.Trim()); }
                catch (Exception) { MessageBox.Show("Girilen değerlerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                if (AT2_Araclar.IsExist(PlakaDogrult(txtEklePlaka.Text.Trim().ToUpper())))
                {
                    MessageBox.Show("Bu plaka ile bir araç daha önce kaydedilmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AT2_Araclar ar = new AT2_Araclar(
                        ((AT2_LojistikFirmalar)cmbEkleLojistikFirmasi.SelectedItem).pkID,
                        ((AT2_AracTipler)cmbEkleAracTipi.SelectedItem).pkID,
                        cmbEkleSofor.SelectedIndex > -1 ? ((AT2_SoforlerMuavinler)cmbEkleSofor.SelectedItem).pkID : 0,
                        cmbEkleMuavin.SelectedIndex > -1 ? ((AT2_SoforlerMuavinler)cmbEkleMuavin.SelectedItem).pkID : 0,
                        false, txtEkleSorumlu.Text.Trim().ToUpper(), PlakaDogrult(txtEklePlaka.Text.Trim().ToUpper()), txtEkleYil.Text.Trim().ToUpper(), txtEkleTonaj.Text.Trim().ToUpper(), txtEkleHacim.Text.Trim().ToUpper());
                    ar.DoInsert();

                    MessageBox.Show("Ekleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetObjects();
                    Temizle();
                }
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbAraclar.SelectedIndex > -1 && cmbGuncelleAracTipi.SelectedIndex > -1 && cmbGuncelleLojistikFirmasi.SelectedIndex > -1 &&
                txtGuncellePlaka.Text.Trim() != string.Empty && txtGuncelleTonaj.Text.Trim() != string.Empty && txtGuncelleHacim.Text.Trim() != string.Empty)
            {
                try { Convert.ToDecimal(txtGuncelleTonaj.Text.Trim()); Convert.ToDecimal(txtGuncelleHacim.Text.Trim()); }
                catch (Exception) { MessageBox.Show("Girilen değerlerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                int index = lbAraclar.SelectedIndex;
                AT2_Araclar ar = ((AT2_Araclar)lbAraclar.SelectedItem);
                ar.intLojistikFirmaID = ((AT2_LojistikFirmalar)cmbGuncelleLojistikFirmasi.SelectedItem).pkID;
                ar.intAracTipiID = ((AT2_AracTipler)cmbGuncelleAracTipi.SelectedItem).pkID;
                ar.intSoforMuavinID = cmbGuncelleSofor.SelectedIndex > -1 ? ((AT2_SoforlerMuavinler)cmbGuncelleSofor.SelectedItem).pkID : 0;
                ar.intMuavinID = cmbGuncelleMuavin.SelectedIndex > -1 ? ((AT2_SoforlerMuavinler)cmbGuncelleMuavin.SelectedItem).pkID : 0;
                ar.strSorumlu = txtGuncelleSorumlu.Text.Trim().ToUpper();
                ar.strPlaka = PlakaDogrult(txtGuncellePlaka.Text.Trim().ToUpper());
                ar.strModelYil = txtGuncelleYil.Text.Trim().ToUpper();
                ar.strTonaj = txtGuncelleTonaj.Text.Trim().ToUpper();
                ar.strHacim = txtGuncelleHacim.Text.Trim().ToUpper();
                ar.DoUpdate();

                MessageBox.Show("Güncelleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                lbAraclar.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAraclar.SelectedIndex > -1)
            {
                //groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;

                AT2_Araclar arac = (AT2_Araclar)lbAraclar.SelectedItem;

                for (int i = 0; i < cmbGuncelleLojistikFirmasi.Items.Count; i++)
                {
                    if (((AT2_LojistikFirmalar)cmbGuncelleLojistikFirmasi.Items[i]).pkID == arac.intLojistikFirmaID)
                    {
                        cmbGuncelleLojistikFirmasi.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbGuncelleAracTipi.Items.Count; i++)
                {
                    if (((AT2_AracTipler)cmbGuncelleAracTipi.Items[i]).pkID == arac.intAracTipiID)
                    {
                        cmbGuncelleAracTipi.SelectedIndex = i;
                        break;
                    }
                }

                bool soforgirdi = false;
                for (int i = 0; i < cmbGuncelleSofor.Items.Count; i++)
                {
                    if (((AT2_SoforlerMuavinler)cmbGuncelleSofor.Items[i]).pkID == arac.intSoforMuavinID)
                    {
                        cmbGuncelleSofor.SelectedIndex = i;
                        soforgirdi = true;
                        break;
                    }
                }
                if (!soforgirdi) cmbGuncelleSofor.SelectedIndex = -1;

                bool muavingirdi = false;
                for (int i = 0; i < cmbGuncelleMuavin.Items.Count; i++)
                {
                    if (((AT2_SoforlerMuavinler)cmbGuncelleMuavin.Items[i]).pkID == arac.intMuavinID)
                    {
                        cmbGuncelleMuavin.SelectedIndex = i;
                        muavingirdi = true;
                        break;
                    }
                }
                if (!muavingirdi) cmbGuncelleMuavin.SelectedIndex = -1;

                txtGuncelleSorumlu.Text = arac.strSorumlu;
                txtGuncellePlaka.Text = arac.strPlaka;
                txtGuncelleYil.Text = arac.strModelYil;
                txtGuncelleTonaj.Text = arac.strTonaj;
                txtGuncelleHacim.Text = arac.strHacim;
                txtSil.Text = lbAraclar.SelectedItem.ToString();
                btnSil.Text = arac.blPasif ? "Geri Al" : "Sil";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbAraclar.SelectedIndex > -1)
            {
                if (MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AT2_Araclar ar = ((AT2_Araclar)lbAraclar.SelectedItem);

                    if (ar.blPasif && AT2_LojistikFirmalar.GetObject(ar.intLojistikFirmaID).blPasif) // araç geri alınıyorsa ve firma pasif ise
                    {
                        MessageBox.Show("Lojistik firması silinmiş olduğundan araç geri alınamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ar.blPasif = !ar.blPasif;
                    ar.DoUpdate();

                    if (ar.blPasif)
                    {
                        ArrayList bedeller = new ArrayList();
                        AT2_AracBedeller.GetObjectsByAracID(bedeller, false, ar.pkID, true, true);
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

        private void btnAracBedelleri_Click(object sender, EventArgs e)
        {
            if (lbAraclar.SelectedIndex > -1)
            {
                frmAT2aracbedelleri frm = new frmAT2aracbedelleri(((AT2_Araclar)lbAraclar.SelectedItem).pkID);
                frm.ShowDialog();
            }
        }

        private void lbAraclar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbAraclar.SelectedIndex > -1)
            {
                btnAracBedelleri.PerformClick();
            }
        }

        private void frmAT2araclar_SizeChanged(object sender, EventArgs e)
        {
            btnYenile.Location = new Point(this.Width - 40, btnYenile.Location.Y);
            groupBox1.Location = new Point(this.Width - 467, groupBox1.Location.Y);
            groupBox2.Location = new Point(this.Width - 243, groupBox2.Location.Y);
            groupBox3.Location = new Point(this.Width - 467, groupBox3.Location.Y);
            lbAraclar.Width = this.Width - 473;
        }

        private void cmbAramaAracTipi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                ((ComboBox)sender).SelectedIndex = -1;
        }

        private void cmbEkleLojistikFirmasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEkleLojistikFirmasi.SelectedIndex > -1)
                txtEkleSorumlu.Text = ((AT2_LojistikFirmalar)cmbEkleLojistikFirmasi.SelectedItem).strSorumlu;
        }

        private void cmbGuncelleLojistikFirmasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGuncelleLojistikFirmasi.SelectedIndex > -1)
                txtGuncelleSorumlu.Text = ((AT2_LojistikFirmalar)cmbGuncelleLojistikFirmasi.SelectedItem).strSorumlu;
        }

        private void cmbGuncelleSofor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                ((ComboBox)sender).SelectedIndex = -1;
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            lblYardim.Visible = true;
        }

        private void label22_MouseLeave(object sender, EventArgs e)
        {
            lblYardim.Visible = false;
        }

        private void label28_MouseHover(object sender, EventArgs e)
        {
            label30.Visible = true;
        }

        private void label28_MouseLeave(object sender, EventArgs e)
        {
            label30.Visible = false;
        }

        private void txtAramaPlaka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnYenile.PerformClick();
            }
        }
    }
}
