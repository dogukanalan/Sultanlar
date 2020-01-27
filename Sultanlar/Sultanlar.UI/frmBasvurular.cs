using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;
using System.IO;
using Microsoft.Win32;

namespace Sultanlar.UI
{
    public partial class frmBasvurular : Form
    {
        public frmBasvurular(string kadi)
        {
            InitializeComponent();
            KAdi = kadi;
        }
        //
        //
        //
        // Degiskenler:
        //
        string KAdi = string.Empty;
        ListBox lbCocuklar;
        ListBox lbBasvurularArkaplan;
        Image bosResim;
        //
        //
        //
        //
        //
        private void frmBasvurular_Load(object sender, EventArgs e)
        {
            if (KAdi.ToUpper() == "BI04" || KAdi.ToUpper().StartsWith("ADM"))
            {
                btnEpostaGonder.Visible = true;
            }

            btnTemizle.PerformClick();
            lbBasvurularArkaplan = new ListBox();
            Basvurular.GetObject(lbBasvurularArkaplan.Items, true);
            bosResim = pictureBox1.Image;
            pictureBox1.Image = null;
            GetBasvurular();

            foreach (Control item in panel1.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control ctrl in item.Controls)
                    {
                        ctrl.Font = ctrl.Font;
                    }
                }
                item.Font = new Font("Microsoft Sans Serif", 9);
            }
            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control ctrl in item.Controls)
                    {
                        ctrl.Font = ctrl.Font;
                    }
                }
                item.Font = new Font("Microsoft Sans Serif", 9);
            }
        }
        //
        //
        //
        // Methodlar:
        //
        private void GetBasvurular()
        {
            lbBasvurular.Items.Clear();

            for (int i = 0; i < lbBasvurularArkaplan.Items.Count; i++)
            {
                lbBasvurular.Items.Add(lbBasvurularArkaplan.Items[i]);
            }

            BasvuruSayisi();
        }

        private void BasvuruSayisi()
        {
            lblBasvuruSayisi.Text = "Kayıt Sayısı: " + lbBasvurular.Items.Count.ToString();
        }
        //
        //
        private void GetBasvurularByIl()
        {
            GetBasvurular();
        }
        //
        //
        private void GetBasvurularByIlce()
        {
            GetBasvurular();
        }
        //
        //
        private void BasvuruAyrintiTemizle()
        {
            pictureBox1.Visible = false;
            lblBasvuruTarihi.Text = string.Empty;
            btnEpostaGonder.Enabled = false;
            lblArananGorevler.Visible = false;

            foreach (Control grctrl in panel1.Controls)
            {
                foreach (Control ctrl in grctrl.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).Text = string.Empty;
                    }
                    else if (ctrl is MaskedTextBox)
                    {
                        ((MaskedTextBox)ctrl).Text = string.Empty;
                    }
                    else if (ctrl is RadioButton)
                    {
                        ((RadioButton)ctrl).Checked = false;
                    }
                    else if (ctrl is DateTimePicker)
                    {
                        ctrl.Enabled = false;
                        ((DateTimePicker)ctrl).Value = DateTime.Now;
                    }
                }
            }
            nudCocuklar.Value = 0;
            nudCocuklar.Enabled = false;
            lblCocukSayisi.Text = string.Empty;

            // egitimi sifirla:
            int satirsayisi = dgvEgitimler.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvEgitimler.Rows.RemoveAt(0);
            }
            dgvEgitimler.ColumnHeadersVisible = false;

            // kurslari sifirla:
            satirsayisi = dgvKurslar.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvKurslar.Rows.RemoveAt(0);
            }
            dgvKurslar.ColumnHeadersVisible = false;

            // yabancidilleri sifirla:
            satirsayisi = dgvYabanciDiller.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvYabanciDiller.Rows.RemoveAt(0);
            }
            dgvYabanciDiller.ColumnHeadersVisible = false;

            // tecrubeleri sifirla:
            satirsayisi = dgvTecrubeler.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvTecrubeler.Rows.RemoveAt(0);
            }
            dgvTecrubeler.ColumnHeadersVisible = false;

            // gelirleri sifirla:
            satirsayisi = dgvGelirler.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvGelirler.Rows.RemoveAt(0);
            }
            dgvGelirler.ColumnHeadersVisible = false;

            // kredikartlarini sifirla:
            satirsayisi = dgvKrediKartlari.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvKrediKartlari.Rows.RemoveAt(0);
            }
            dgvKrediKartlari.ColumnHeadersVisible = false;

            // referanslari sifirla:
            satirsayisi = dgvReferanslar.Rows.Count;
            for (int i = 0; i < satirsayisi; i++)
            {
                dgvReferanslar.Rows.RemoveAt(0);
            }
            dgvReferanslar.ColumnHeadersVisible = false;
        }
        //
        //
        private void KontrolleriAktifEt()
        {
            pictureBox1.Visible = true;

            foreach (Control grctrl in panel1.Controls)
            {
                if (grctrl is GroupBox)
                {
                    foreach (Control ctrl in grctrl.Controls)
                    {
                        if (ctrl is DateTimePicker)
                        {
                            ctrl.Enabled = true;
                        }
                    }
                }
            }
            nudCocuklar.Enabled = true;
            nudCocuklar.Value = 0;
        }
        //
        //
        private void GetIller()
        {
            cmbIl.Items.Clear();
            Iller.GetObject(cmbIl.Items, true);
        }
        //
        //
        private void GetIlceler()
        {
            cmbIlce.Items.Clear();
            Ilceler.GetObject(cmbIlce.Items, ((Iller)cmbIl.SelectedItem).pkIlID.ToString(), true);
        }
        //
        //
        private void HtmlSayfaOlustur(bool yazdirma)
        {
            string bos = string.Empty;


            if (yazdirma == true)
            {
                bos = "<img src='" + Application.StartupPath + "\\spacer.gif' />";
            }
            else
            {
                bos = "-";
            }


            //StringBuilder sb = new StringBuilder();
            string basvuru = string.Empty;




            // cocuklar:
            string cocuk1ad = bos, cocuk1dogumtarihi = bos, cocuk1okul = bos,
                cocuk2ad = bos, cocuk2dogumtarihi = bos, cocuk2okul = bos,
                cocuk3ad = bos, cocuk3dogumtarihi = bos, cocuk3okul = bos,
                cocuk4ad = bos, cocuk4dogumtarihi = bos, cocuk4okul = bos,
                cocuk5ad = bos, cocuk5dogumtarihi = bos, cocuk5okul = bos;

            for (int i = 0; i < lbCocuklar.Items.Count; i++)
            {
                if (i == 0)
                {
                    cocuk1ad = lbCocuklar.Items[i].ToString() + " -Erkek- ";
                    if (((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi != string.Empty)
                        cocuk1dogumtarihi = Convert.ToDateTime(((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi).ToShortDateString();
                    if (((Cocuklar)lbCocuklar.Items[i]).strCocukOkul != string.Empty)
                        cocuk1okul = ((Cocuklar)lbCocuklar.Items[i]).strCocukOkul;
                    if (((Cocuklar)lbCocuklar.Items[i]).blCocukErkek == false)
                        cocuk1ad = lbCocuklar.Items[i].ToString() + " -Kız- ";
                }
                else if (i == 1)
                {
                    cocuk2ad = lbCocuklar.Items[i].ToString() + " -Erkek- ";
                    if (((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi != string.Empty)
                        cocuk2dogumtarihi = Convert.ToDateTime(((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi).ToShortDateString();
                    if (((Cocuklar)lbCocuklar.Items[i]).strCocukOkul != string.Empty)
                        cocuk2okul = ((Cocuklar)lbCocuklar.Items[i]).strCocukOkul;
                    if (((Cocuklar)lbCocuklar.Items[i]).blCocukErkek == false)
                        cocuk2ad = lbCocuklar.Items[i].ToString() + " -Kız- ";
                }
                else if (i == 2)
                {
                    cocuk3ad = lbCocuklar.Items[i].ToString() + " -Erkek- ";
                    if (((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi != string.Empty)
                        cocuk3dogumtarihi = Convert.ToDateTime(((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi).ToShortDateString();
                    if (((Cocuklar)lbCocuklar.Items[i]).strCocukOkul != string.Empty)
                        cocuk3okul = ((Cocuklar)lbCocuklar.Items[i]).strCocukOkul;
                    if (((Cocuklar)lbCocuklar.Items[i]).blCocukErkek == false)
                        cocuk3ad = lbCocuklar.Items[i].ToString() + " -Kız- ";
                }
                else if (i == 3)
                {
                    cocuk4ad = lbCocuklar.Items[i].ToString() + " -Erkek- ";
                    if (((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi != string.Empty)
                        cocuk4dogumtarihi = Convert.ToDateTime(((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi).ToShortDateString();
                    if (((Cocuklar)lbCocuklar.Items[i]).strCocukOkul != string.Empty)
                        cocuk4okul = ((Cocuklar)lbCocuklar.Items[i]).strCocukOkul;
                    if (((Cocuklar)lbCocuklar.Items[i]).blCocukErkek == false)
                        cocuk4ad = lbCocuklar.Items[i].ToString() + " -Kız- ";
                }
                else if (i == 4)
                {
                    cocuk5ad = lbCocuklar.Items[i].ToString() + " -Erkek- ";
                    if (((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi != string.Empty)
                        cocuk5dogumtarihi = Convert.ToDateTime(((Cocuklar)lbCocuklar.Items[i]).dtCocukDogumTarihi).ToShortDateString();
                    if (((Cocuklar)lbCocuklar.Items[i]).strCocukOkul != string.Empty)
                        cocuk5okul = ((Cocuklar)lbCocuklar.Items[i]).strCocukOkul;
                    if (((Cocuklar)lbCocuklar.Items[i]).blCocukErkek == false)
                        cocuk4ad = lbCocuklar.Items[i].ToString() + " -Kız- ";
                }
            }



            // tarih ve textbox kontrolleri:
            string boy = bos;
            string kilo = bos;
            string kardessayisi = bos;
            string surucubelgetarihi = bos;
            string esdogumtarihi = bos;
            string terhistarihi = bos;
            string teciltarihi = bos;
            string mahkemetarihi = bos;
            string tahliyetarihi = bos;
            string tedaviyemuhtacyakin = bos;
            string bakmaklayukumluyakin = bos;
            string baslayabilecegitarih = bos;
            string surenhastalik = bos;
            string onemliameliyat = bos;
            string sakatlik = bos;
            string otomobilmarkamodeldurum = bos;
            string dernekklupkurulus = bos;
            string ozelmerakhobi = bos;
            string bildigibilgisayarprogramlari = bos;
            string meslekibasari = bos;
            string sirkettanidik = bos;
            string ucret = bos;
            string isozelbeklenti = bos;

            if (txtBoy.Text != string.Empty)
            {
                boy = txtBoy.Text;
            }
            if (txtKilo.Text != string.Empty)
            {
                kilo = txtKilo.Text;
            }
            if (txtKardesSayisi.Text != string.Empty)
            {
                kardessayisi = txtKardesSayisi.Text;
            }
            if (dtpSurucuBelgeTarihi.Enabled == true)
            {
                surucubelgetarihi = dtpSurucuBelgeTarihi.Value.ToShortDateString();
            }
            if (dtpEsDogumTarihi.Enabled == true)
            {
                esdogumtarihi = dtpEsDogumTarihi.Value.ToShortDateString();
            }
            if (dtpTerhisTarihi.Enabled == true)
            {
                terhistarihi = dtpTerhisTarihi.Value.ToShortDateString();
            }
            if (dtpTecilTarihi.Enabled == true)
            {
                teciltarihi = dtpTecilTarihi.Value.ToShortDateString();
            }
            if (dtpMahkemeDurusmaTarihi.Enabled == true)
            {
                mahkemetarihi = dtpMahkemeDurusmaTarihi.Value.ToShortDateString();
            }
            if (dtpMahkumiyetTahliyeTarihi.Enabled == true)
            {
                tahliyetarihi = dtpMahkumiyetTahliyeTarihi.Value.ToShortDateString();
            }
            if (txtTedaviyeMuhtacYakin.Text != string.Empty)
            {
                tedaviyemuhtacyakin = txtTedaviyeMuhtacYakin.Text;
            }
            if (txtBakmaklaYukumluYakin.Text != string.Empty)
            {
                bakmaklayukumluyakin = txtBakmaklaYukumluYakin.Text;
            }
            if (dtpIsBaslangicTarihi.Enabled == true)
            {
                baslayabilecegitarih = dtpIsBaslangicTarihi.Value.ToShortDateString();
            }
            if (txtSurenHastalik.Text != string.Empty)
            {
                surenhastalik = txtSurenHastalik.Text;
            }
            if (txtOnemliAmeliyat.Text != string.Empty)
            {
                onemliameliyat = txtOnemliAmeliyat.Text;
            }
            if (txtSakatlik.Text != string.Empty)
            {
                sakatlik = txtSakatlik.Text;
            }
            if (txtOtomobilMarkaModelDurum.Text != string.Empty)
            {
                otomobilmarkamodeldurum = txtOtomobilMarkaModelDurum.Text;
            }
            if (txtUyeDernekKlupKurulus.Text != string.Empty)
            {
                dernekklupkurulus = txtUyeDernekKlupKurulus.Text;
            }
            if (txtOzelMerakHobi.Text != string.Empty)
            {
                ozelmerakhobi = txtOzelMerakHobi.Text;
            }
            if (txtBildigiBilgisayarProgramlari.Text != string.Empty)
            {
                bildigibilgisayarprogramlari = txtBildigiBilgisayarProgramlari.Text;
            }
            if (txtMeslekBasari.Text != string.Empty)
            {
                meslekibasari = txtMeslekBasari.Text;
            }
            if (txtSirketTanidik.Text != string.Empty)
            {
                sirkettanidik = txtSirketTanidik.Text;
            }
            if (txtTalepUcret.Text != string.Empty)
            {
                ucret = txtTalepUcret.Text;
            }
            if (txtIsOzelBeklenti.Text != string.Empty)
            {
                isozelbeklenti = txtIsOzelBeklenti.Text;
            }




            // egitim durumu:
            string ilkokuladi = bos, ilkokulbolum = bos, ilkokulbitirmeyili = bos, ortaokulkuladi = bos, ortaokulbolum = bos, ortaokulbitirmeyili = bos,
            liseadi = bos, lisebolum = bos, lisebitirmeyili = bos, universiteadi = bos, universitebolum = bos, universitebitirmeyili = bos, lisansustuadi = bos,
            lisansustubolum = bos, lisansustubitirmeyili = bos;
            for (int i = 0; i < dgvEgitimler.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dgvEgitimler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        ilkokuladi = dgvEgitimler.Rows[i].Cells[1].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        ilkokulbolum = dgvEgitimler.Rows[i].Cells[2].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        ilkokulbitirmeyili = dgvEgitimler.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 1)
                {
                    if (dgvEgitimler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        ortaokulkuladi = dgvEgitimler.Rows[i].Cells[1].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        ortaokulbolum = dgvEgitimler.Rows[i].Cells[2].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        ortaokulbitirmeyili = dgvEgitimler.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 2)
                {
                    if (dgvEgitimler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        liseadi = dgvEgitimler.Rows[i].Cells[1].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        lisebolum = dgvEgitimler.Rows[i].Cells[2].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        lisebitirmeyili = dgvEgitimler.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 3)
                {
                    if (dgvEgitimler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        universiteadi = dgvEgitimler.Rows[i].Cells[1].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        universitebolum = dgvEgitimler.Rows[i].Cells[2].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        universitebitirmeyili = dgvEgitimler.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 4)
                {
                    if (dgvEgitimler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        lisansustuadi = dgvEgitimler.Rows[i].Cells[1].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        lisansustubolum = dgvEgitimler.Rows[i].Cells[2].Value.ToString();
                    if (dgvEgitimler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        lisansustubitirmeyili = dgvEgitimler.Rows[i].Cells[3].Value.ToString();
                }
            }



            // kurslar:
            string kurs1konu = bos, kurs1verenkurulus = bos, kurs1suresi = bos, kurs1yili = bos, kurs2konu = bos, kurs2verenkurulus = bos, kurs2suresi = bos, kurs2yili = bos,
            kurs3konu = bos, kurs3verenkurulus = bos, kurs3suresi = bos, kurs3yili = bos, kurs4konu = bos, kurs4verenkurulus = bos, kurs4suresi = bos, kurs4yili = bos,
            kurs5konu = bos, kurs5verenkurulus = bos, kurs5suresi = bos, kurs5yili = bos;
            for (int i = 0; i < dgvKurslar.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dgvKurslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kurs1konu = dgvKurslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kurs1verenkurulus = dgvKurslar.Rows[i].Cells[1].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        kurs1suresi = dgvKurslar.Rows[i].Cells[2].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        kurs1yili = dgvKurslar.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 1)
                {
                    if (dgvKurslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kurs2konu = dgvKurslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kurs2verenkurulus = dgvKurslar.Rows[i].Cells[1].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        kurs2suresi = dgvKurslar.Rows[i].Cells[2].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        kurs2yili = dgvKurslar.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 2)
                {
                    if (dgvKurslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kurs3konu = dgvKurslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kurs3verenkurulus = dgvKurslar.Rows[i].Cells[1].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        kurs3suresi = dgvKurslar.Rows[i].Cells[2].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        kurs3yili = dgvKurslar.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 3)
                {
                    if (dgvKurslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kurs4konu = dgvKurslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kurs4verenkurulus = dgvKurslar.Rows[i].Cells[1].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        kurs4suresi = dgvKurslar.Rows[i].Cells[2].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        kurs4yili = dgvKurslar.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 4)
                {
                    if (dgvKurslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kurs5konu = dgvKurslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kurs5verenkurulus = dgvKurslar.Rows[i].Cells[1].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        kurs5suresi = dgvKurslar.Rows[i].Cells[2].Value.ToString();
                    if (dgvKurslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        kurs5yili = dgvKurslar.Rows[i].Cells[3].Value.ToString();
                }
            }



            // yabanci diller:
            string dil1 = bos, dil1okuma = bos, dil1yazma = bos, dil1konusma = bos, dil2 = bos, dil2okuma = bos, dil2yazma = bos, dil2konusma = bos,
            dil3 = bos, dil3okuma = bos, dil3yazma = bos, dil3konusma = bos;
            for (int i = 0; i < dgvYabanciDiller.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dgvYabanciDiller.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        dil1 = dgvYabanciDiller.Rows[i].Cells[0].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        dil1okuma = dgvYabanciDiller.Rows[i].Cells[1].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        dil1yazma = dgvYabanciDiller.Rows[i].Cells[2].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        dil1konusma = dgvYabanciDiller.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 1)
                {
                    if (dgvYabanciDiller.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        dil2 = dgvYabanciDiller.Rows[i].Cells[0].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        dil2okuma = dgvYabanciDiller.Rows[i].Cells[1].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        dil2yazma = dgvYabanciDiller.Rows[i].Cells[2].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        dil2konusma = dgvYabanciDiller.Rows[i].Cells[3].Value.ToString();
                }
                else if (i == 2)
                {
                    if (dgvYabanciDiller.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        dil3 = dgvYabanciDiller.Rows[i].Cells[0].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        dil3okuma = dgvYabanciDiller.Rows[i].Cells[1].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        dil3yazma = dgvYabanciDiller.Rows[i].Cells[2].Value.ToString();
                    if (dgvYabanciDiller.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        dil3konusma = dgvYabanciDiller.Rows[i].Cells[3].Value.ToString();
                }
            }



            // tecrubeler:
            string simdikiis = bos, simdikiisgorev = bos, simdikiisgiris = bos, simdikiiscikis = bos, simdikiisucret = bos, simdikiisayrilma = bos,
            is1 = bos, is1gorev = bos, is1giris = bos, is1cikis = bos, is1ucret = bos, is1ayrilma = bos,
            is2 = bos, is2gorev = bos, is2giris = bos, is2cikis = bos, is2ucret = bos, is2ayrilma = bos,
            is3 = bos, is3gorev = bos, is3giris = bos, is3cikis = bos, is3ucret = bos, is3ayrilma = bos,
            is4 = bos, is4gorev = bos, is4giris = bos, is4cikis = bos, is4ucret = bos, is4ayrilma = bos;

            if (dgvTecrubeler.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dgvTecrubeler.Rows[0].Cells[6].Value) == true) // şimdiki işi var ise
                {
                    for (int i = 0; i < dgvTecrubeler.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                simdikiis = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                simdikiisgorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                simdikiisgiris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                simdikiiscikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                simdikiisucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                simdikiisayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 1)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is1 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is1gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is1giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is1cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is1ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is1ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 2)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is2 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is2gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is2giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is2cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is2ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is2ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 3)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is3 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is3gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is3giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is3cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is3ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is3ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 4)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is4 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is4gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is4giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is4cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is4ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is4ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dgvTecrubeler.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is1 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is1gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is1giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is1cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is1ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is1ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 1)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is2 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is2gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is2giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is2cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is2ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is2ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 2)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is3 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is3gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is3giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is3cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is3ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is3ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                        else if (i == 3)
                        {
                            if (dgvTecrubeler.Rows[i].Cells[0].Value.ToString() != string.Empty)
                                is4 = dgvTecrubeler.Rows[i].Cells[0].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                                is4gorev = dgvTecrubeler.Rows[i].Cells[1].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                                is4giris = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[2].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[3].Value.ToString() != string.Empty)
                                is4cikis = Convert.ToDateTime(dgvTecrubeler.Rows[i].Cells[3].Value.ToString()).ToShortDateString();
                            if (dgvTecrubeler.Rows[i].Cells[4].Value.ToString() != string.Empty)
                                is4ucret = dgvTecrubeler.Rows[i].Cells[4].Value.ToString();
                            if (dgvTecrubeler.Rows[i].Cells[5].Value.ToString() != string.Empty)
                                is4ayrilma = dgvTecrubeler.Rows[i].Cells[5].Value.ToString();
                        }
                    }
                }
            }
            
            

            // diger gelirler:
            string kiratutar = bos, kiraciklama = bos, ortakliktutar = bos, ortaklikaciklama = bos, digertutar = bos, digeraciklama = bos, estutar = bos, esaciklama = bos;
            for (int i = 0; i < dgvGelirler.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dgvGelirler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kiratutar = dgvGelirler.Rows[i].Cells[1].Value.ToString();
                    if (dgvGelirler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        kiraciklama = dgvGelirler.Rows[i].Cells[2].Value.ToString();
                }
                else if (i == 1)
                {
                    if (dgvGelirler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        ortakliktutar = dgvGelirler.Rows[i].Cells[1].Value.ToString();
                    if (dgvGelirler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        ortaklikaciklama = dgvGelirler.Rows[i].Cells[2].Value.ToString();
                }
                else if (i == 2)
                {
                    if (dgvGelirler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        digertutar = dgvGelirler.Rows[i].Cells[1].Value.ToString();
                    if (dgvGelirler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        digeraciklama = dgvGelirler.Rows[i].Cells[2].Value.ToString();
                }
                else if (i == 3)
                {
                    if (dgvGelirler.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        estutar = dgvGelirler.Rows[i].Cells[1].Value.ToString();
                    if (dgvGelirler.Rows[i].Cells[2].Value.ToString() != string.Empty)
                        esaciklama = dgvGelirler.Rows[i].Cells[2].Value.ToString();
                }
            }




            // kredi kartlari:
            string kredikarti1 = bos, kredikarti1limit = bos, kredikarti2 = bos, kredikarti2limit = bos;
            for (int i = 0; i < dgvKrediKartlari.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dgvKrediKartlari.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kredikarti1 = dgvKrediKartlari.Rows[i].Cells[0].Value.ToString();
                    if (dgvKrediKartlari.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kredikarti1limit = dgvKrediKartlari.Rows[i].Cells[1].Value.ToString();
                }
                else if (i == 1)
                {
                    if (dgvKrediKartlari.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        kredikarti2 = dgvKrediKartlari.Rows[i].Cells[0].Value.ToString();
                    if (dgvKrediKartlari.Rows[i].Cells[1].Value.ToString() != string.Empty)
                        kredikarti2limit = dgvKrediKartlari.Rows[i].Cells[1].Value.ToString();
                }
            }




            // referanslar:
            string referans1ad = bos, referans1sirketgorev = bos, referans1telefon = bos, referans2ad = bos, referans2sirketgorev = bos, referans2telefon = bos,
            referans3ad = bos, referans3sirketgorev = bos, referans3telefon = bos;
            for (int i = 0; i < dgvReferanslar.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dgvReferanslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        referans1ad = dgvReferanslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvReferanslar.Rows[i].Cells[1].Value.ToString() != string.Empty || dgvReferanslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                    {
                        referans1sirketgorev = dgvReferanslar.Rows[i].Cells[2].Value.ToString();
                        if (dgvReferanslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                            referans1sirketgorev = dgvReferanslar.Rows[i].Cells[1].Value.ToString() + ", " + referans1sirketgorev;
                    }
                    if (dgvReferanslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        referans1telefon = dgvReferanslar.Rows[i].Cells[3].Value.ToString();
                }
                if (i == 1)
                {
                    if (dgvReferanslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        referans2ad = dgvReferanslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvReferanslar.Rows[i].Cells[1].Value.ToString() != string.Empty || dgvReferanslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                    {
                        referans2sirketgorev = dgvReferanslar.Rows[i].Cells[2].Value.ToString();
                        if (dgvReferanslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                            referans2sirketgorev = dgvReferanslar.Rows[i].Cells[1].Value.ToString() + ", " + referans2sirketgorev;
                    }
                    if (dgvReferanslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        referans2telefon = dgvReferanslar.Rows[i].Cells[3].Value.ToString();
                }
                if (i == 2)
                {
                    if (dgvReferanslar.Rows[i].Cells[0].Value.ToString() != string.Empty)
                        referans3ad = dgvReferanslar.Rows[i].Cells[0].Value.ToString();
                    if (dgvReferanslar.Rows[i].Cells[1].Value.ToString() != string.Empty || dgvReferanslar.Rows[i].Cells[2].Value.ToString() != string.Empty)
                    {
                        referans3sirketgorev = dgvReferanslar.Rows[i].Cells[2].Value.ToString();
                        if (dgvReferanslar.Rows[i].Cells[1].Value.ToString() != string.Empty)
                            referans3sirketgorev = dgvReferanslar.Rows[i].Cells[1].Value.ToString() + ", " + referans3sirketgorev;
                    }
                    if (dgvReferanslar.Rows[i].Cells[3].Value.ToString() != string.Empty)
                        referans3telefon = dgvReferanslar.Rows[i].Cells[3].Value.ToString();
                }
            }



            byte[] resim = Resim.ImageToByte(pictureBox1.Image, "PNG");




            // basvuruyu bitir:
            basvuru = Sultanlar.Class.BasvuruHtml.HtmlSayfaGetir
                (
                yazdirma,

                Application.StartupPath + "\\",

                lbBasvurular.SelectedItem.ToString(), dtpDogumTarihi.Value.ToShortDateString() + " " + txtDogumYeri.Text,
                "Bay", txtTCKimlik.Text, txtNufusIl.Text + ", " + txtNufusIlce.Text, txtMedeniDurum.Text, txtAnneBaba.Text, txtSecilenGorevler.Text,
                "Var", txtSurucuBelgeSinifi.Text + " - " + surucubelgetarihi, boy, kilo, kardessayisi, txtAdres.Text, mtbEvTelefonu.Text, mtbCepTelefonu.Text, txtAdresIlce.Text,
                txtAdresIl.Text, txtEposta.Text,

                txtEsAd.Text + " " + txtEsSoyad.Text, txtEsMeslek.Text, esdogumtarihi, cocuk1ad, cocuk1dogumtarihi, cocuk1okul, cocuk2ad, cocuk2dogumtarihi, cocuk2okul,
                cocuk3ad, cocuk3dogumtarihi, cocuk3okul, cocuk4ad, cocuk4dogumtarihi, cocuk4okul, cocuk5ad, cocuk5dogumtarihi, cocuk5okul,

                txtAskerlikDurumu.Text, txtAskerlikTipi.Text, terhistarihi, teciltarihi, txtAskerlikSinifi.Text, txtMuafiyetNedeni.Text,

                txtOgrenimDurumu.Text, ilkokuladi, ilkokulbolum, ilkokulbitirmeyili, ortaokulkuladi, ortaokulbolum, ortaokulbitirmeyili, liseadi, lisebolum, lisebitirmeyili,
                universiteadi, universitebolum, universitebitirmeyili, lisansustuadi, lisansustubolum, lisansustubitirmeyili,

                kurs1konu, kurs1verenkurulus, kurs1suresi, kurs1yili, kurs2konu, kurs2verenkurulus, kurs2suresi, kurs2yili,
                kurs3konu, kurs3verenkurulus, kurs3suresi, kurs3yili, kurs4konu, kurs4verenkurulus, kurs4suresi, kurs4yili,
                kurs5konu, kurs5verenkurulus, kurs5suresi, kurs5yili,

                dil1, dil1okuma, dil1yazma, dil1konusma, dil2, dil2okuma, dil2yazma, dil2konusma, dil3, dil3okuma, dil3yazma, dil3konusma,

                simdikiis, simdikiisgorev, simdikiisgiris, simdikiiscikis, simdikiisucret, simdikiisayrilma,
                is1, is1gorev, is1giris, is1cikis, is1ucret, is1ayrilma, is2, is2gorev, is2giris, is2cikis, is2ucret, is2ayrilma,
                is3, is3gorev, is3giris, is3cikis, is3ucret, is3ayrilma, is4, is4gorev, is4giris, is4cikis, is4ucret, is4ayrilma,

                "Hayır", mahkemetarihi, "Hayır", tahliyetarihi, bakmaklayukumluyakin, tedaviyemuhtacyakin, txtKrediKartiTakibat.Text,
                kiratutar, kiraciklama, ortakliktutar, ortaklikaciklama, digertutar, digeraciklama, estutar, esaciklama,
                kredikarti1, kredikarti1limit, kredikarti2, kredikarti2limit,

                surenhastalik, onemliameliyat, sakatlik,

                "Hayır", "Hayır", txtBaskaEvAdresDurum.Text, "Hayır", otomobilmarkamodeldurum, dernekklupkurulus, ozelmerakhobi,
                bildigibilgisayarprogramlari, meslekibasari,

                sirkettanidik, "Hayır", ucret, baslayabilecegitarih, "Evet", isozelbeklenti, "Hayır", "Hayır", txtSehirDisiCalismaKisitlama.Text,

                referans1ad, referans1sirketgorev, referans1telefon, referans2ad, referans2sirketgorev, referans2telefon,
                referans3ad, referans3sirketgorev, referans3telefon,

                txtCalismaHayatiBeklenti.Text, lblBasvuruTarihi.Text,

                resim
                );



            // son kontroller:
            if (rbCinsiyetBayan.Checked)
            {
                basvuru = basvuru.Replace("Cinsiyet<br /><b>Bay", "Cinsiyet<br /><b>Bayan");
            }
            if (rbEhliyetYok.Checked)
            {
                basvuru = basvuru.Replace("Sürücü Belgeniz Var Mı?<br /><b>Var", "Sürücü Belgeniz Var Mı?<br /><b>Yok");
            }
            if (rbMahkemeEvet.Checked)
            {
                basvuru = basvuru.Replace("Herhangi bir nedenle devam eden mahkemeniz var mı? Varsa neden?<br /><b>Hayır",
                    "Herhangi bir nedenle devam eden mahkemeniz var mı? Varsa neden?<br /><b>Evet, " + txtMahkemeNedeni.Text);
            }
            if (rbMahkumiyetEvet.Checked)
            {
                basvuru = basvuru.Replace("Herhangi bir nedenle devam eden mahkumiyetiniz var mı? Varsa nedeni, süresi.<br /><b>Hayır",
                    "Herhangi bir nedenle devam eden mahkumiyetiniz var mı? Varsa nedeni, süresi.<br /><b>Evet, " + txtMahkumiyetNedeni.Text);
            }
            if (rbEvSizinEvet.Checked)
            {
                basvuru = basvuru.Replace("Oturduğunuz ev size mi ait?<br /><b>Hayır", "Oturduğunuz ev size mi ait?<br /><b>Evet");
            }
            if (rbBaskaEvEvet.Checked)
            {
                basvuru = basvuru.Replace("Oturduğunuz ev dışında gayri menkulünüz var mı? Varsa adresi, durumu.<br /><b>Hayır",
                    "Oturduğunuz ev dışında gayri menkulünüz var mı? Varsa adresi, durumu.<br /><b>Evet, ");
            }
            if (rbOtomobilEvet.Checked)
            {
                basvuru = basvuru.Replace("Otomobiliniz var mı?<br /><b>Hayır", "Otomobiliniz var mı?<br /><b>Evet");
            }
            if (rbDahaOnceBasvuruEvet.Checked)
            {
                basvuru = basvuru.Replace("Daha önce şirketimize başvurunuz oldu mu?<br /><b>Hayır", "Daha önce şirketimize başvurunuz oldu mu?<br /><b>Evet");
            }
            if (rbSigaraHayir.Checked)
            {
                basvuru = basvuru.Replace("Sigara içiyor musunuz?<br /><b>Evet",
                    "Sigara içiyor musunuz?<br /><b>Hayır, bundan sonra da içmeyi düşünmüyorum.");
            }
            if (rbVardiyaEvet.Checked)
            {
                basvuru = basvuru.Replace("Gerektiğinde vardiyalı olarak çalışabilir misiniz?<br /><b>Hayır",
                    "Gerektiğinde vardiyalı olarak çalışabilir misiniz?<br /><b>Evet");
            }
            if (rbSehirDisiEvet.Checked)
            {
                basvuru = basvuru.Replace("Görev verildiği takdirde şehir dışında görev yapabilir misiniz, kısıtlamalarınız nelerdir?<br /><b>Hayır",
                    "Görev verildiği takdirde şehir dışında görev yapabilir misiniz, kısıtlamalarınız nelerdir?<br /><b>Evet, ");
            }




            System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\IK-" + lbBasvurular.SelectedItem.ToString() + ".htm", true, Encoding.Unicode);
            sw.Write(basvuru);
            sw.Close();
            sw.Dispose();
        }
        //
        //
        //
        // Olaylar:
        //
        #region Basvuru Secildiginde
        private void lbBasvurular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBasvurular.SelectedIndex > -1)
            {
                BasvuruAyrintiTemizle();
                KontrolleriAktifEt();

                Basvurular bas = ((Basvurular)lbBasvurular.SelectedItem);
                lblBasvuruTarihi.Text = bas.dtBasvuruTarihi.ToShortDateString();
                dtpDogumTarihi.Value = DateTime.Parse(bas.dtDogumTarihi);
                txtDogumYeri.Text = Iller.GetObjectByID(bas.tintDogumYeriID);
                rbCinsiyetBay.Checked = bas.blCinsiyet;
                rbCinsiyetBayan.Checked = !(bas.blCinsiyet);
                txtTCKimlik.Text = bas.strTCKimlik;
                txtNufusIl.Text = Iller.GetObjectByID(bas.tintNufusIlID);
                txtNufusIlce.Text = Ilceler.GetObjectByID(bas.sintNufusIlceID);
                txtMedeniDurum.Text = MedeniDurumlar.GetObjectByID(bas.tintMedeniDurumID);
                txtAnneBaba.Text = bas.strAnneBaba;
                rbEhliyetVar.Checked = bas.blSurucuBelge;
                rbEhliyetYok.Checked = !(bas.blSurucuBelge);
                if (bas.blSurucuBelge)
                {
                    if (bas.tintSurucuBelgeSinifiID > 0)
                    {
                        txtSurucuBelgeSinifi.Text = SurucuBelgeSiniflari.GetObjectByID(bas.tintSurucuBelgeSinifiID);
                    }
                }
                if (bas.dtSurucuBelgeTarihi != string.Empty)
                {
                    dtpSurucuBelgeTarihi.Enabled = true;
                    dtpSurucuBelgeTarihi.Value = DateTime.Parse(bas.dtSurucuBelgeTarihi);
                }
                else
                {
                    dtpSurucuBelgeTarihi.Enabled = false;
                }
                txtBoy.Text = bas.strBoy;
                txtKilo.Text = bas.strKilo;
                txtKardesSayisi.Text = bas.strKardesSayisi;
                txtAdres.Text = bas.strAdres;
                mtbEvTelefonu.Text = bas.strEvTelefonu;
                mtbCepTelefonu.Text = bas.strCepTelefonu;
                txtAdresIl.Text = Iller.GetObjectByID(bas.tintAdresIlID);
                txtAdresIlce.Text = Ilceler.GetObjectByID(bas.sintAdresIlceID);
                txtEposta.Text = bas.strEposta;
                txtWebSayfasi.Text = bas.strWebSayfasi;
                txtEsAd.Text = bas.strEsAd;
                txtEsSoyad.Text = bas.strEsSoyad;
                txtEsMeslek.Text = bas.strEsMeslek;
                dtpEsDogumTarihi.Value = StringParcalama.TariheCevir(bas.dtEsDogumTarihi, dtpEsDogumTarihi);

                // basvurdugu gorevler:
                DataTable dt = new DataTable();
                dt.Columns.Add("pkGorevID", typeof(string));
                dt.Columns.Add("strGorev", typeof(string));
                SecilenGorevler.GetObjectByBasvuruID(dt, bas.pkBasvuruID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtSecilenGorevler.Text += dt.Rows[i][1].ToString() + ", ";
                    if (i == dt.Rows.Count - 1)
                    {
                        txtSecilenGorevler.Text = txtSecilenGorevler.Text.Substring(0, txtSecilenGorevler.Text.Length - 2);
                    }
                }

                // cocuklar:
                lbCocuklar = new ListBox();
                Cocuklar.GetObject(lbCocuklar.Items, bas.pkBasvuruID);
                nudCocuklar.Maximum = lbCocuklar.Items.Count;
                lblCocukSayisi.Text = "(" + lbCocuklar.Items.Count.ToString() + " çocuk sahibi)";
                dtpCocukDogumTarihi.Enabled = false;

                // askerlik:
                if (bas.tintAskerlikDurumuID > 0)
                {
                    txtAskerlikDurumu.Text = AskerlikDurumlari.GetObjectByID(bas.tintAskerlikDurumuID);
                }
                if (bas.tintAskerlikTipID > 0)
                {
                    txtAskerlikTipi.Text = AskerlikTipleri.GetObjectByID(bas.tintAskerlikTipID);
                }
                txtAskerlikSinifi.Text = bas.strAskerlikSinifi;
                dtpTerhisTarihi.Value = StringParcalama.TariheCevir(bas.dtTerhisTarihi, dtpTerhisTarihi);
                dtpTecilTarihi.Value = StringParcalama.TariheCevir(bas.dtTecilTarihi, dtpTecilTarihi);
                txtMuafiyetNedeni.Text = bas.strMuafNedeni;

                // egitim ozgecmisi:
                txtOgrenimDurumu.Text = OgrenimDurumlari.GetObjectByID(bas.tintOgrenimDurumuID);
                dt = new DataTable(); // datatable lari herseferinde yeniden olusturuyoruz cunku performans artiyor bellekte daha fazla yer tutsa da
                Egitimler.GetObject(dt, bas.pkBasvuruID);
                dgvEgitimler.DataSource = dt;
                if (dgvEgitimler.Rows.Count > 0) { dgvEgitimler.ColumnHeadersVisible = true; }

                // katildigi programlar:
                dt = new DataTable();
                Kurslar.GetObject(dt, bas.pkBasvuruID);
                dgvKurslar.DataSource = dt;
                if (dgvKurslar.Rows.Count > 0) { dgvKurslar.ColumnHeadersVisible = true; }

                // yabanci diller:
                dt = new DataTable();
                YabanciDiller.GetObject(dt, bas.pkBasvuruID);
                dgvYabanciDiller.DataSource = dt;
                if (dgvYabanciDiller.Rows.Count > 0) { dgvYabanciDiller.ColumnHeadersVisible = true; }

                // tecrubeler:
                dt = new DataTable();
                Tecrubeler.GetObject(dt, bas.pkBasvuruID);
                dgvTecrubeler.DataSource = dt;
                if (dgvTecrubeler.Rows.Count > 0) { dgvTecrubeler.ColumnHeadersVisible = true; }

                // diger bilgiler:
                rbMahkemeEvet.Checked = bas.blMahkeme;
                rbMahkemeHayir.Checked = !bas.blMahkeme;
                txtMahkemeNedeni.Text = bas.strMahkemeNedeni;
                dtpMahkemeDurusmaTarihi.Value = StringParcalama.TariheCevir(bas.dtMahkemeDurusmaTarihi, dtpMahkemeDurusmaTarihi);
                rbMahkumiyetEvet.Checked = bas.blMahkumiyet;
                rbMahkumiyetHayir.Checked = !bas.blMahkumiyet;
                txtMahkumiyetNedeni.Text = bas.strMahkumiyetNedeni;
                dtpMahkumiyetTahliyeTarihi.Value = StringParcalama.TariheCevir(bas.dtMahkumiyetTahliye, dtpMahkumiyetTahliyeTarihi);
                txtBakmaklaYukumluYakin.Text = bas.strBakmaklaYukumluYakin;
                txtTedaviyeMuhtacYakin.Text = bas.strTedaviyeMuhtacYakin;
                txtKrediKartiTakibat.Text = bas.strKrediKartiTakibat;
                txtSurenHastalik.Text = bas.strSurenHastalik;
                txtOnemliAmeliyat.Text = bas.strOnemliAmeliyat;
                txtSakatlik.Text = bas.strSakatlik;
                rbEvSizinEvet.Checked = bas.blEvSizin;
                rbEvSizinHayir.Checked = !bas.blEvSizin;
                rbOtomobilEvet.Checked = bas.blOtomobil;
                rbOtomobilHayir.Checked = !bas.blOtomobil;
                txtOtomobilMarkaModelDurum.Text = bas.strOtomobilMarkaModelDurum;
                rbBaskaEvEvet.Checked = bas.blBaskaEv;
                rbBaskaEvHayir.Checked = !bas.blBaskaEv;
                txtBaskaEvAdresDurum.Text = bas.strBaskaEvAdresDurum;
                txtUyeDernekKlupKurulus.Text = bas.strUyeDernekKlupKurulus;
                txtOzelMerakHobi.Text = bas.strOzelMerakHobi;
                txtMeslekBasari.Text = bas.strMeslekBasari;
                txtSirketTanidik.Text = bas.strSirketTanidik;
                rbDahaOnceBasvuruEvet.Checked = bas.blDahaOnceBasvuru;
                rbDahaOnceBasvuruHayir.Checked = !bas.blDahaOnceBasvuru;
                txtTalepUcret.Text = bas.strTalepUcret;
                dtpIsBaslangicTarihi.Value = StringParcalama.TariheCevir(bas.dtIsBaslangicTarihi, dtpIsBaslangicTarihi);
                rbSigaraEvet.Checked = bas.blSigara;
                rbSigaraHayir.Checked = !bas.blSigara;
                txtIsOzelBeklenti.Text = bas.strIsOzelBeklenti;
                rbVardiyaEvet.Checked = bas.blVardiyaliCalisma;
                rbVardiyaHayir.Checked = !bas.blVardiyaliCalisma;
                rbSehirDisiEvet.Checked = bas.blSehirDisiCalisma;
                rbSehirDisiHayir.Checked = !bas.blSehirDisiCalisma;
                txtSehirDisiCalismaKisitlama.Text = bas.strSehirDisiCalismaKisitlama;
                txtCalismaHayatiBeklenti.Text = bas.strCalismaHayatiBeklenti;

                // gelirler:
                dt = new DataTable();
                Gelirler.GetObject(dt, bas.pkBasvuruID);
                dgvGelirler.DataSource = dt;
                if (dgvGelirler.Rows.Count > 0) { dgvGelirler.ColumnHeadersVisible = true; }

                // kredi kartlari:
                dt = new DataTable();
                KrediKartlari.GetObject(dt, bas.pkBasvuruID);
                dgvKrediKartlari.DataSource = dt;
                if (dgvKrediKartlari.Rows.Count > 0) { dgvKrediKartlari.ColumnHeadersVisible = true; }

                // bildigi bilgisayar programlari:
                dt = new DataTable();
                dt.Columns.Add("strBildigiBilgisayarProgrami", typeof(string));
                BildigiBilgisayarProgramlari.GetObject(dt, bas.pkBasvuruID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtBildigiBilgisayarProgramlari.Text += dt.Rows[i][0].ToString() + ", ";
                    if (i == dt.Rows.Count - 1)
                    {
                        txtBildigiBilgisayarProgramlari.Text = txtBildigiBilgisayarProgramlari.Text.Substring(0, txtBildigiBilgisayarProgramlari.Text.Length - 2);
                    }
                }
                if (bas.strBildigiBilgisayarProgramiDiger != string.Empty)
                {
                    txtBildigiBilgisayarProgramlari.Text += ", " + bas.strBildigiBilgisayarProgramiDiger;
                }

                // referanslar:
                dt = new DataTable();
                Referanslar.GetObject(dt, bas.pkBasvuruID);
                dgvReferanslar.DataSource = dt;
                if (dgvReferanslar.Rows.Count > 0) { dgvReferanslar.ColumnHeadersVisible = true; }

                // resim:
                if (bas.binResim != DBNull.Value)
                {
                    pictureBox1.Image = Resim.ByteToImage((byte[])bas.binResim);
                }
                else
                {
                    pictureBox1.Image = bosResim;
                }


                // eposta ile gonderme:
                if (bas.blEpostaIleYollandi == false)
                {
                    btnEpostaGonder.Enabled = true;
                }
                else
                {
                    btnEpostaGonder.Enabled = false;
                }


                // aranan görevlerden başvuruldu:
                if (bas.intArananGorevID > 0)
                {
                    lblArananGorevler.Visible = true;
                    lblArananGorevler.Text = "Eleman taleplerinden " + bas.intArananGorevID.ToString() + " \r\nnumaralı talebe başvuru yapıldı.";
                }
                else
                {
                    lblArananGorevler.Visible = false;
                }
            }
        }
        //
        //
        private void nudCocuklar_ValueChanged(object sender, EventArgs e)
        {
            if (nudCocuklar.Value > 0)
            {
                lbCocuklar.SelectedIndex = Convert.ToInt32(nudCocuklar.Value) - 1;
                Cocuklar coc = (Cocuklar)lbCocuklar.SelectedItem;
                txtCocukAdi.Text = coc.strCocukAd;
                rbCocukErkek.Checked = coc.blCocukErkek;
                rbCocukKiz.Checked = !(coc.blCocukErkek);
                dtpCocukDogumTarihi.Enabled = true;
                dtpCocukDogumTarihi.Value = StringParcalama.TariheCevir(coc.dtCocukDogumTarihi, dtpCocukDogumTarihi);
                txtCocukOkul.Text = coc.strCocukOkul;
            }
            else
            {
                txtCocukAdi.Text = string.Empty;
                dtpCocukDogumTarihi.Value = DateTime.Now;
                dtpCocukDogumTarihi.Enabled = false;
                txtCocukOkul.Text = string.Empty;
            }
        }
        #endregion
        //
        //
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            BasvuruAyrintiTemizle();
            lbBasvurular.SelectedIndex = -1;
        }
        //
        //
        private void btnBasvurulariYenile_Click(object sender, EventArgs e)
        {
            if (cbSilinenler.Checked)
            {
                cbIlIlce.Checked = false;
                cbKayitTarihi.Checked = false;
                cbDepartmanGorev.Checked = false;
                cbEgitimDurumu.Checked = false;
                cbAskerlikDurumu.Checked = false;
                Basvurular.GetObject(lbBasvurularArkaplan.Items, false);
                GetBasvurular();
                btnTemizle.PerformClick();
            }
            else
            {
                cbIlIlce.Checked = false;
                cbKayitTarihi.Checked = false;
                cbDepartmanGorev.Checked = false;
                cbEgitimDurumu.Checked = false;
                cbAskerlikDurumu.Checked = false;
                Basvurular.GetObject(lbBasvurularArkaplan.Items, true);
                GetBasvurular();
                btnTemizle.PerformClick();
            }
        }
        //
        //
        #region checkboxlar
        private void cbKisiselBilgiler_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKisiselBilgiler.Checked)
            {
                gbKisiselBilgiler.Height = 309;
            }
            else
            {
                gbKisiselBilgiler.Height = 16;
            }

            gbAileBilgileri.Location = new Point(3, gbKisiselBilgiler.Height + 9);
            gbAskerlikBilgileri.Location = new Point(3, gbAileBilgileri.Height + gbKisiselBilgiler.Height + 15);
            gbEgitimOzgecmisi.Location = new Point(3, gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 21);
            gbKurslar.Location = new Point(3, gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 27);
            gbYabanciDiller.Location = new Point(3, gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 33);
            gbTecrubeler.Location = new Point(3, gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 39);
            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbAileBilgileri_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAileBilgileri.Checked)
            {
                gbAileBilgileri.Height = 134;
            }
            else
            {
                gbAileBilgileri.Height = 16;
            }

            gbAskerlikBilgileri.Location = new Point(3, gbAileBilgileri.Height + gbKisiselBilgiler.Height + 15);
            gbEgitimOzgecmisi.Location = new Point(3, gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 21);
            gbKurslar.Location = new Point(3, gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 27);
            gbYabanciDiller.Location = new Point(3, gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 33);
            gbTecrubeler.Location = new Point(3, gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 39);
            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbAskerlikBilgileri_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAskerlikBilgileri.Checked)
            {
                gbAskerlikBilgileri.Height = 88;
            }
            else
            {
                gbAskerlikBilgileri.Height = 16;
            }

            gbEgitimOzgecmisi.Location = new Point(3, gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 21);
            gbKurslar.Location = new Point(3, gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 27);
            gbYabanciDiller.Location = new Point(3, gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 33);
            gbTecrubeler.Location = new Point(3, gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 39);
            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbEgitimOzgecmisi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEgitimOzgecmisi.Checked)
            {
                gbEgitimOzgecmisi.Height = 186;
            }
            else
            {
                gbEgitimOzgecmisi.Height = 16;
            }

            gbKurslar.Location = new Point(3, gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 27);
            gbYabanciDiller.Location = new Point(3, gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 33);
            gbTecrubeler.Location = new Point(3, gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 39);
            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbKurslar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKurslar.Checked)
            {
                gbKurslar.Height = 164;
            }
            else
            {
                gbKurslar.Height = 16;
            }

            gbYabanciDiller.Location = new Point(3, gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 33);
            gbTecrubeler.Location = new Point(3, gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 39);
            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbYabanciDiller_CheckedChanged(object sender, EventArgs e)
        {
            if (cbYabanciDiller.Checked)
            {
                gbYabanciDiller.Height = 150;
            }
            else
            {
                gbYabanciDiller.Height = 16;
            }

            gbTecrubeler.Location = new Point(3, gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 39);
            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbTecrubeler_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTecrubeler.Checked)
            {
                gbTecrubeler.Height = 150;
            }
            else
            {
                gbTecrubeler.Height = 16;
            }

            gbDigerBilgiler.Location = new Point(3, gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 45);
            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbDigerBilgiler_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDigerBilgiler.Checked)
            {
                gbDigerBilgiler.Height = 792;
            }
            else
            {
                gbDigerBilgiler.Height = 16;
            }

            gbReferanslar.Location = new Point(3, gbDigerBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbKisiselBilgiler.Height + 51);

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        //
        //
        private void cbReferanslar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReferanslar.Checked)
            {
                gbReferanslar.Height = 144;
            }
            else
            {
                gbReferanslar.Height = 16;
            }

            panel1.Height = 56 + gbKisiselBilgiler.Height + gbTecrubeler.Height + gbYabanciDiller.Height + gbKurslar.Height + gbEgitimOzgecmisi.Height + gbAskerlikBilgileri.Height + gbAileBilgileri.Height + gbDigerBilgiler.Height + gbReferanslar.Height;
        }
        #endregion
        //
        //
        #region Il Ilce
        private void cbIlIlce_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIlIlce.Checked)
            {
                cmbIl.Enabled = true;
                cmbIlce.Enabled = true;
                GetIller();
            }
            else
            {
                cmbIl.Enabled = false;
                cmbIlce.Enabled = false;
                cmbIlce.Items.Clear();
                cmbIl.Items.Clear();
            }

            Suz();
        }
        //
        //
        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIlceler();
            Suz();
        }
        //
        //
        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suz();
        }
        #endregion
        //
        //
        #region Kayit Tarihi
        private void cbKayitTarihi_CheckedChanged(object sender, EventArgs e)
        {
            rbKayitTarihiDenSonra.Checked = true;

            if (cbKayitTarihi.Checked)
            {
                rbKayitTarihiArasinda.Enabled = true;
                rbKayitTarihiDenOnce.Enabled = true;
                rbKayitTarihiDenSonra.Enabled = true;
                dtpKayitTarihi1.Enabled = true;
                dtpKayitTarihi2.Enabled = false;
            }
            else
            {
                rbKayitTarihiArasinda.Enabled = false;
                rbKayitTarihiDenOnce.Enabled = false;
                rbKayitTarihiDenSonra.Enabled = false;
                dtpKayitTarihi1.Enabled = false;
                dtpKayitTarihi2.Enabled = false;
            }

            Suz();
        }
        //
        //
        private void rbKayitTarihiDenSonra_CheckedChanged(object sender, EventArgs e)
        {
            dtpKayitTarihi1.Enabled = true;
            dtpKayitTarihi2.Enabled = false;

            Suz();
        }
        //
        //
        private void rbKayitTarihiDenOnce_CheckedChanged(object sender, EventArgs e)
        {
            dtpKayitTarihi1.Enabled = false;
            dtpKayitTarihi2.Enabled = true;

            Suz();
        }
        //
        //
        private void rbKayitTarihiArasinda_CheckedChanged(object sender, EventArgs e)
        {
            dtpKayitTarihi1.Enabled = true;
            dtpKayitTarihi2.Enabled = true;

            Suz();
        }
        #endregion
        //
        //
        #region Departman Gorev
        private void cbDepartmanGorev_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDepartmanGorev.Checked)
            {
                cmbDepartmanlar.Enabled = true;
                cmbGorevler.Enabled = true;
                Departmanlar.GetObject(cmbDepartmanlar.Items, true);
                Gorevler.GetObject(cmbGorevler.Items, true);
            }
            else
            {
                cmbDepartmanlar.Enabled = false;
                cmbGorevler.Enabled = false;
                cmbDepartmanlar.Items.Clear();
                cmbGorevler.Items.Clear();
            }

            Suz();
        }
        //
        //
        private void cmbDepartmanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gorevler.GetObjectByDepartmanID(cmbGorevler.Items, ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID.ToString());
            Suz();
        }
        //
        //
        private void cmbGorevler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suz();
        }
        #endregion
        //
        //
        #region Egitim Durumlari
        private void cbEgitimDurumu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEgitimDurumu.Checked)
            {
                cmbEgitimDurumlari.Enabled = true;
                OgrenimDurumlari.GetObject(cmbEgitimDurumlari.Items, true);
            }
            else
            {
                cmbEgitimDurumlari.Enabled = false;
                cmbEgitimDurumlari.Items.Clear();
            }

            Suz();
        }
        //
        //
        private void cmbEgitimDurumlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suz();
        }
        #endregion
        //
        //
        #region Askerlik Durumlari
        private void cbAskerlikDurumu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAskerlikDurumu.Checked)
            {
                cmbAskerlikDurumlari.Enabled = true;
                AskerlikDurumlari.GetObject(cmbAskerlikDurumlari.Items, true);
            }
            else
            {
                cmbAskerlikDurumlari.Enabled = false;
                cmbAskerlikDurumlari.Items.Clear();
            }

            Suz();
        }
        //
        //
        private void cmbAskerlikDurumlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suz();
        }
        #endregion
        //
        //
        #region Suzme Islemi
        private void Suz()
        {
            btnTemizle.PerformClick();
            GetBasvurular();


            // kayıt tarihi:
            if (cbKayitTarihi.Checked && rbKayitTarihiDenSonra.Checked)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (DateTime.Parse(dtpKayitTarihi1.Value.ToShortDateString()) > DateTime.Parse(((Basvurular)lbBasvurular.Items[i]).dtBasvuruTarihi.ToShortDateString()))
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }
            else if (cbKayitTarihi.Checked && rbKayitTarihiDenOnce.Checked)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (DateTime.Parse(dtpKayitTarihi2.Value.ToShortDateString()) < DateTime.Parse(((Basvurular)lbBasvurular.Items[i]).dtBasvuruTarihi.ToShortDateString()))
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }
            else if (cbKayitTarihi.Checked && rbKayitTarihiArasinda.Checked)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (DateTime.Parse(dtpKayitTarihi1.Value.ToShortDateString()) > DateTime.Parse(((Basvurular)lbBasvurular.Items[i]).dtBasvuruTarihi.ToShortDateString())
                        || DateTime.Parse(dtpKayitTarihi2.Value.ToShortDateString()) < DateTime.Parse(((Basvurular)lbBasvurular.Items[i]).dtBasvuruTarihi.ToShortDateString()))
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }



            // il:
            if (cbIlIlce.Checked && cmbIl.SelectedIndex > -1)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (((Iller)cmbIl.SelectedItem).pkIlID != ((Basvurular)lbBasvurular.Items[i]).tintAdresIlID)
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }


            // ilce:
            if (cbIlIlce.Checked && cmbIlce.SelectedIndex > -1)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (((Ilceler)cmbIlce.SelectedItem).pkIlceID != ((Basvurular)lbBasvurular.Items[i]).sintAdresIlceID)
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }



            // departman:                                                                                                     !!!!!!!!!! çok karışık iyice bak !!!!!!!!!
            if (cbDepartmanGorev.Checked && cmbDepartmanlar.SelectedIndex > -1)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                // önce o departmana ait gorevleri getir:
                DataTable dt = new DataTable();
                dt.Columns.Add("pkGorevID", typeof(string));
                dt.Columns.Add("tintDepartmanID", typeof(string));
                dt.Columns.Add("strGorev", typeof(string));
                Gorevler.GetObjectByDepartmanID(dt, ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID.ToString());

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    // adamın seçtiği görevler:
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("pkGorevID", typeof(string));
                    dt2.Columns.Add("strGorev", typeof(string));
                    SecilenGorevler.GetObjectByBasvuruID(dt2, ((Basvurular)lbBasvurular.Items[i]).pkBasvuruID);

                    if (dt2.Rows.Count == 0) // hiçbiryere başvuru yapmamışsa adamı listboxtan kaldır
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        // o departmanın görevlerinin herbirini dolaş:
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            // adamın seçtiği görevlerden en az biri bile o departmanda varsa kaldırılmayacak:
                            for (int K = 0; K < dt2.Rows.Count; K++)
                            {
                                if (dt.Rows[k][0].ToString() != dt2.Rows[K][0].ToString())
                                {
                                    kaldirilacakIndexler[i] = 1;
                                }
                                else
                                {
                                    kaldirilacakIndexler[i] = 0;
                                    k = dt.Rows.Count;
                                    K = dt2.Rows.Count;
                                }
                            }
                        }

                        if (dt.Rows.Count == 0) // o departmana ait bir gorev yoksa veritabaninda
                        {
                            kaldirilacakIndexler[i] = 1;
                        }
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }

            

            // gorevler:
            if (cbDepartmanGorev.Checked && cmbGorevler.SelectedIndex > -1)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    // önce adamın seçtiği görevleri getir:
                    DataTable dt = new DataTable();
                    dt.Columns.Add("pkGorevID", typeof(string));
                    dt.Columns.Add("strGorev", typeof(string));
                    SecilenGorevler.GetObjectByBasvuruID(dt, ((Basvurular)lbBasvurular.Items[i]).pkBasvuruID);

                    if (dt.Rows.Count == 0) // hiçbiryere başvuru yapmamışsa adamı listboxtan kaldır
                    {
                        kaldirilacakIndexler[i] = 1;
                    }

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        // adamın seçtiği görevlerden en az biri bile cmbgorevlerde secilen gorev ise kaldirilmayacak, hicbiri cmbgorevlerdeki gorev degilse kaldirilacak:
                        if (dt.Rows[k][0].ToString() != ((Gorevler)cmbGorevler.SelectedItem).pkGorevID.ToString())
                        {
                            kaldirilacakIndexler[i] = 1;
                        }
                        else
                        {
                            kaldirilacakIndexler[i] = 0;
                            k = dt.Rows.Count;
                        }
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }



            // egitim durumu:
            if (cbEgitimDurumu.Checked && cmbEgitimDurumlari.SelectedIndex > -1)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (((OgrenimDurumlari)cmbEgitimDurumlari.SelectedItem).pkOgrenimDurumuID != ((Basvurular)lbBasvurular.Items[i]).tintOgrenimDurumuID)
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }



            // askerlik durumu:
            if (cbAskerlikDurumu.Checked && cmbAskerlikDurumlari.SelectedIndex > -1)
            {
                int[] kaldirilacakIndexler = new int[lbBasvurular.Items.Count];

                for (int i = 0; i < lbBasvurular.Items.Count; i++)
                {
                    if (((AskerlikDurumlari)cmbAskerlikDurumlari.SelectedItem).pkAskerlikDurumuID != ((Basvurular)lbBasvurular.Items[i]).tintAskerlikDurumuID)
                    {
                        kaldirilacakIndexler[i] = 1;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        lbBasvurular.Items.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }

            BasvuruSayisi();
        }
        #endregion
        //
        //
        private void dtpKayitTarihi1_ValueChanged(object sender, EventArgs e)
        {
            Suz();
        }
        //
        //
        private void dtpKayitTarihi2_ValueChanged(object sender, EventArgs e)
        {
            Suz();
        }
        //
        //
        private void btnBasvuruSil_Click(object sender, EventArgs e)
        {
            if (lbBasvurular.SelectedIndex > -1)
            {
                if (btnBasvuruSil.Text == "Sil")
                {
                    Basvurular bas = (Basvurular)lbBasvurular.SelectedItem;
                    bas.DoDelete();
                    btnBasvurulariYenile.PerformClick();
                }
                else if (btnBasvuruSil.Text == "Geri Getir")
                {
                    Basvurular bas = (Basvurular)lbBasvurular.SelectedItem;
                    bas.DoRestore();
                    btnBasvurulariYenile.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Bir başvuru seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (lbBasvurular.SelectedIndex < 0)
            {
                return;
            }

            HtmlSayfaOlustur(true);

            frmYazdir frm = new frmYazdir("C:\\IK-" + lbBasvurular.SelectedItem.ToString() + ".htm");
            frm.ShowDialog();

            File.Delete("C:\\IK-" + lbBasvurular.SelectedItem.ToString() + ".htm");
            File.Delete("C:\\yazdir.png");
            RegistryKey yaziciustalt = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
            //yaziciustalt.SetValue("footer", "&u&b&d");
            //yaziciustalt.SetValue("header", "&w&bPage &p of &P");
        }
        //
        //
        private void cbSilinenler_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSilinenler.Checked)
            {
                btnBasvuruSil.Text = "Geri Getir";
                Basvurular.GetObject(lbBasvurularArkaplan.Items, false);
                GetBasvurular();
                btnTemizle.PerformClick();
            }
            else
            {
                btnBasvuruSil.Text = "Sil";
                Basvurular.GetObject(lbBasvurularArkaplan.Items, true);
                GetBasvurular();
                btnTemizle.PerformClick();
            }
        }
        //
        //
        private void btnEpostaGonder_Click(object sender, EventArgs e)
        {
            HtmlSayfaOlustur(false);


            DataTable secilengorevler = new DataTable();
            SecilenGorevler.GetObjectByBasvuruID(secilengorevler, ((Basvurular)lbBasvurular.SelectedItem).pkBasvuruID);
            string[] departmanepostalar = new string[secilengorevler.Rows.Count];

            for (int i = 0; i < secilengorevler.Rows.Count; i++)
            {
                departmanepostalar[i] = Gorevler.GetDepartmanEposta(secilengorevler.Rows[i][0].ToString());
            }


            string[] departmanepostalar2 = new string[departmanepostalar.Length];
            int departmaneposta2indexler = 0;
            int departmaneposta3indexsayisi = 0;
            for (int i = 0; i < departmanepostalar.Length; i++)
            {
                bool ekle = true;

                for (int j = 0; j < departmanepostalar2.Length; j++)
                {
                    if (departmanepostalar[i] == departmanepostalar2[j])
                    {
                        ekle = false;
                    }
                }

                if (ekle == true)
                {
                    departmanepostalar2[departmaneposta2indexler] = departmanepostalar[i];
                    departmaneposta2indexler++;
                    departmaneposta3indexsayisi++;
                }
            }

            string[] departmanepostalar3 = new string[departmaneposta3indexsayisi + 2];
            departmanepostalar3[0] = "sultanlar@sultanlar.com.tr";
            departmanepostalar3[1] = "eleman@sultanlar.com.tr";

            for (int i = 2; i < departmaneposta3indexsayisi + 2; i++)
            {
                departmanepostalar3[i] = departmanepostalar2[i - 2];
            }



            Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", departmanepostalar3, "Sultanlar Pazarlama A.Ş.", "İş Başvurusu Web - " + lbBasvurular.SelectedItem.ToString(), "Yeni bir iş başvurusu yapılmıştır. Açıklama ektedir.", "C:\\IK-" + lbBasvurular.SelectedItem.ToString() + ".htm");

            Basvurular.DoEpostaOK(((Basvurular)lbBasvurular.SelectedItem).pkBasvuruID);

            btnEpostaGonder.Enabled = false;

            File.Delete("C:\\IK-" + lbBasvurular.SelectedItem.ToString() + ".htm");
            File.Delete("C:\\yazdir.png");

            btnBasvurulariYenile.PerformClick();
        }
        //
        //
        private void lblArananGorevler_Click(object sender, EventArgs e)
        {
            frmArananGorevler frm = new frmArananGorevler();
            frm.ShowDialog();
        }
    }
}
