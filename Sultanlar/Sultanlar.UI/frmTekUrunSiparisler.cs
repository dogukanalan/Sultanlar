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
    public partial class frmTekUrunSiparisler : Form
    {
        public frmTekUrunSiparisler()
        {
            InitializeComponent();
        }

        private void frmTekUrunSiparisler_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            GetObjects();
        }

        private void GetObjects()
        {
            GetOdemeTipleri();
            GetKargoSirketleri();
            GetSiparisDurumlari();
            GetIller();
            GetUrunler();
            GetSiparisler();
        }

        private void GetOdemeTipleri()
        {
            OdemeTipleri.GetObjects(cmbOdemeTipleri.Items, true);
        }

        private void GetKargoSirketleri()
        {
            KargoSirketleri.GetObjects(cmbKargoSirketleri.Items, true);
        }

        private void GetSiparisDurumlari()
        {
            SiparisDurumlari.GetObjects(cmbSiparisDurumu.Items, true);
        }

        private void GetIller()
        {
            Iller.GetObject(cmbIller.Items, true);
        }

        private void GetIlceler()
        {
            if (cmbIller.SelectedIndex > -1)
            {
                string ilkkod = ((Iller)cmbIller.SelectedItem).strIlKod;
                Ilceler.GetObject(cmbIlceler.Items, ilkkod, true);
            }
            else
            {
                cmbIlceler.Items.Clear();
            }
        }

        private void GetUrunler()
        {
            Urunler.GetObjects(cmbUrunler.Items, true);
        }

        private void GetSiparisler()
        {
            DataTable dt = new DataTable();

            int UrunID = 0;
            if (cmbUrunler.SelectedIndex > -1)
                UrunID =((Urunler)cmbUrunler.SelectedItem).pkUrunID;

            byte OdemeTipiID = 0;
            if (cmbOdemeTipleri.SelectedIndex > -1)
                OdemeTipiID = ((OdemeTipleri)cmbOdemeTipleri.SelectedItem).pkOdemeTipiID;

            byte KargoSirketiID = 0;
            if(cmbKargoSirketleri.SelectedIndex > -1)
                KargoSirketiID = ((KargoSirketleri)cmbKargoSirketleri.SelectedItem).pkKargoSirketiID;

            byte SiparisDurumuID = 0;
            if (cmbSiparisDurumu.SelectedIndex > -1)
                SiparisDurumuID = ((SiparisDurumlari)cmbSiparisDurumu.SelectedItem).pkSiparisDurumuID;

            byte IlID = 0;
            if (cmbIller.SelectedIndex > -1)
                IlID = ((Iller)cmbIller.SelectedItem).pkIlID;

            short IlceID = 0;
            if (cmbIlceler.SelectedIndex > -1)
                IlceID = ((Ilceler)cmbIlceler.SelectedItem).pkIlceID;

            if (!rbTahsilatHepsi.Checked)
            {
                bool Tahsilat = rbTahsilatYapildi.Checked;
                Siparisler.GetObjectsFilters(dt, UrunID, OdemeTipiID, KargoSirketiID, SiparisDurumuID, IlID, IlceID, Tahsilat);
            }
            else
            {
                Siparisler.GetObjectsFilters(dt, UrunID, OdemeTipiID, KargoSirketiID, SiparisDurumuID, IlID, IlceID, null);
            }

            dataGridView1.DataSource = dt;

            GetGenelToplam();
        }

        private void GetGenelToplam()
        {
            decimal ToplamFiyat = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ToplamFiyat += Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmnToplamFiyat"].Value);
            }

            lblGenelToplam.Text = "Genel Toplam: " + ToplamFiyat.ToString("C2");
        }

        private void GetHareketler()
        {
            long SiparisID = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkSiparisID"].Value);
            DataTable dt = new DataTable();
            Hareketler.GetObjectsBySiparisID(dt, SiparisID);
            dataGridView2.DataSource = dt;
        }

        private void GetSiparisDetayi()
        {
            txtKargoLinki.Text = dataGridView1.SelectedRows[0].Cells["clstrKargoLinki"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.SelectedRows[0].Cells["clstrKullaniciAdSoyad"].Value.ToString();
            txtTelefon.Text = dataGridView1.SelectedRows[0].Cells["clstrKullaniciTelefon"].Value.ToString();
            txtTCKimlik.Text = dataGridView1.SelectedRows[0].Cells["clstrKullaniciTC"].Value.ToString();
            txtKargoSirketi.Text = dataGridView1.SelectedRows[0].Cells["clstrKargoSirketi"].Value.ToString();
            txtTeslimatAdresi.Text = dataGridView1.SelectedRows[0].Cells["clstrKullaniciTeslimatAdres"].Value.ToString();
            txtFaturaAdresi.Text = dataGridView1.SelectedRows[0].Cells["clstrKullaniciFaturaAdres"].Value.ToString();
            txtIl.Text = dataGridView1.SelectedRows[0].Cells["clstrIl"].Value.ToString();
            txtIlce.Text = dataGridView1.SelectedRows[0].Cells["clstrIlce"].Value.ToString();
            txtEposta.Text = dataGridView1.SelectedRows[0].Cells["clstrKullaniciEposta"].Value.ToString();
            txtOdemeTipi.Text = dataGridView1.SelectedRows[0].Cells["clstrOdemeTipi"].Value.ToString();
            txtNot.Text = dataGridView1.SelectedRows[0].Cells["clstrAciklama"].Value.ToString();
        }

        private void Temizle()
        {
            //dataGridView1.ClearSelection();

            DataTable dt = new DataTable();
            Hareketler.GetObjectsBySiparisID(dt, 0);
            dataGridView2.DataSource = dt;

            txtAdSoyad.Text = string.Empty;
            txtEposta.Text = string.Empty;
            txtFaturaAdresi.Text = string.Empty;
            txtIl.Text = string.Empty;
            txtIlce.Text = string.Empty;
            txtKargoLinki.Text = string.Empty;
            txtKargoSirketi.Text = string.Empty;
            txtNot.Text = string.Empty;
            txtOdemeTipi.Text = string.Empty;
            txtTCKimlik.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtTeslimatAdresi.Text = string.Empty;
        }

        private void ExceleAktar(object filename)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 16;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 18;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 20;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 5;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 15;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 8;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 11;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 26;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["M", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["N", Type.Missing]).ColumnWidth = 30;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["O", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["P", Type.Missing]).ColumnWidth = 20;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["Q", Type.Missing]).ColumnWidth = 36;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["R", Type.Missing]).ColumnWidth = 14;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["S", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["T", Type.Missing]).ColumnWidth = 50;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["U", Type.Missing]).ColumnWidth = 50;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["V", Type.Missing]).ColumnWidth = 16;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["W", Type.Missing]).ColumnWidth = 16;

            ws.Cells[1, 1] = "Sipariş No";
            ws.Cells[1, 2] = "Ürün Adı";
            ws.Cells[1, 3] = "Sipariş Tarihi";
            ws.Cells[1, 4] = "Tahsilat Durumu";
            ws.Cells[1, 5] = "Adet";
            ws.Cells[1, 6] = "Birim Fiyat";
            ws.Cells[1, 7] = "İndirim Oranı (%)";
            ws.Cells[1, 8] = "İndirim";
            ws.Cells[1, 9] = "Kargo Fiyatı";
            ws.Cells[1, 10] = "Toplam Fiyat";
            ws.Cells[1, 11] = "Ödeme Tipi";
            ws.Cells[1, 12] = "Kargo Şirketi";
            ws.Cells[1, 13] = "Kargo Takibi";
            ws.Cells[1, 14] = "Not";
            ws.Cells[1, 15] = "TC Kimlik";
            ws.Cells[1, 16] = "Ad Soyad";
            ws.Cells[1, 17] = "Eposta";
            ws.Cells[1, 18] = "Şifre";
            ws.Cells[1, 19] = "Telefon";
            ws.Cells[1, 20] = "Teslimat Adresi";
            ws.Cells[1, 21] = "Fatura Adresi";
            ws.Cells[1, 22] = "İl";
            ws.Cells[1, 23] = "İlçe";

            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;

            this.Enabled = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                progressBar1.Value = i;

                ws.Cells[i + 3, 1] = dataGridView1.Rows[i].Cells["clpkSiparisID"].Value;
                ws.Cells[i + 3, 2] = dataGridView1.Rows[i].Cells["clstrUrunAdi"].Value;
                ws.Cells[i + 3, 3] = dataGridView1.Rows[i].Cells["cldtSiparisTarihi"].Value;
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["clblTahsilatDurumu"].Value) == true)
                    ws.Cells[i + 3, 4] = "Ödeme Yapıldı";
                else
                    ws.Cells[i + 3, 4] = "Ödeme Bekleniyor";
                ws.Cells[i + 3, 5] = dataGridView1.Rows[i].Cells["clsintAdet"].Value;
                ws.Cells[i + 3, 6] = dataGridView1.Rows[i].Cells["clmnBirimFiyat"].FormattedValue;
                ws.Cells[i + 3, 7] = dataGridView1.Rows[i].Cells["clflIndirimMiktari"].Value;
                ws.Cells[i + 3, 8] = dataGridView1.Rows[i].Cells["clmnIndirim"].FormattedValue;
                ws.Cells[i + 3, 9] = dataGridView1.Rows[i].Cells["clmnKargoFiyati"].FormattedValue;
                ws.Cells[i + 3, 10] = dataGridView1.Rows[i].Cells["clmnToplamFiyat"].FormattedValue;
                ws.Cells[i + 3, 11] = dataGridView1.Rows[i].Cells["clstrOdemeTipi"].Value;
                ws.Cells[i + 3, 12] = dataGridView1.Rows[i].Cells["clstrKargoSirketi"].Value;
                ws.Cells[i + 3, 13] = dataGridView1.Rows[i].Cells["clstrKargoLinki"].Value;
                ws.Cells[i + 3, 14] = dataGridView1.Rows[i].Cells["clstrAciklama"].Value;
                ws.Cells[i + 3, 15] = dataGridView1.Rows[i].Cells["clstrKullaniciTC"].Value;
                ws.Cells[i + 3, 16] = dataGridView1.Rows[i].Cells["clstrKullaniciAdSoyad"].Value;
                ws.Cells[i + 3, 17] = dataGridView1.Rows[i].Cells["clstrKullaniciEposta"].Value;
                ws.Cells[i + 3, 18] = dataGridView1.Rows[i].Cells["clstrKullaniciSifre"].Value;
                ws.Cells[i + 3, 19] = dataGridView1.Rows[i].Cells["clstrKullaniciTelefon"].Value;
                ws.Cells[i + 3, 20] = dataGridView1.Rows[i].Cells["clstrKullaniciTeslimatAdres"].Value;
                ws.Cells[i + 3, 21] = dataGridView1.Rows[i].Cells["clstrKullaniciFaturaAdres"].Value;
                ws.Cells[i + 3, 22] = dataGridView1.Rows[i].Cells["clstrIl"].Value;
                ws.Cells[i + 3, 23] = dataGridView1.Rows[i].Cells["clstrIlce"].Value;
            }
            this.Enabled = true;

            progressBar1.Visible = false;

            ws.SaveAs(filename.ToString());
            wb.Close();
            ap.Quit();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetSiparisler();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Temizle();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                GetHareketler();
                GetSiparisDetayi();
            }
        }

        private void btnHareketSil_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                if (dataGridView2.Rows.Count - 1 == dataGridView2.SelectedRows[0].Index)
                {
                    if (MessageBox.Show("Hareketi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        long HareketID = Convert.ToInt64(dataGridView2.SelectedRows[0].Cells["clpkHareketID"].Value);
                        Hareketler.DoDelete(HareketID);

                        if (cmbSiparisDurumu.SelectedIndex > -1)
                        {
                            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                            dataGridView1.ClearSelection();
                            Temizle();
                        }
                        else
                        {
                            GetHareketler();
                        }

                        dataGridView1.SelectedRows[0].Cells["cltintSiparisDurumuID"].Value = dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["cltintSiparisDurumuID2"].Value;
                    }
                }
                else
                {
                    if (dataGridView2.Rows.Count - 1 != dataGridView2.SelectedRows[0].Index)
                        MessageBox.Show("Siparişin sadece son hareketi silinebilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Bir \"Hareket\" seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bir \"Hareket\" seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHareketEkle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                long SiparisID = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkSiparisID"].Value);
                byte SiparisDurumuID = Convert.ToByte(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["cltintSiparisDurumuID2"].Value);
                frmTekUrunHareketEkle frm = new frmTekUrunHareketEkle(SiparisID, SiparisDurumuID);
                frm.ShowDialog();

                if (cmbSiparisDurumu.SelectedIndex > -1)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    dataGridView1.ClearSelection();
                    Temizle();
                }
                else
                {
                    GetHareketler();
                }

                dataGridView1.SelectedRows[0].Cells["cltintSiparisDurumuID"].Value = dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["cltintSiparisDurumuID2"].Value;
            }
            else
            {
                MessageBox.Show("Bir \"Sipariş\" seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKargoLinkiGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                long SiparisID = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkSiparisID"].Value);
                Siparisler sp = Siparisler.GetObject(SiparisID);
                sp.strKargoLinki = txtKargoLinki.Text.Trim();
                sp.DoUpdate();
                dataGridView1.SelectedRows[0].Cells["clstrKargoLinki"].Value = txtKargoLinki.Text.Trim();
            }
            else
            {
                MessageBox.Show("Bir \"Sipariş\" seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Dosyası|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ExceleAktar));
                    thr.Start(sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Aktarılacak veri yok.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.ClearSelection();
                Temizle();
            }
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView2.ClearSelection();
            }
        }

        private void cmbUrunler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                ((ComboBox)sender).SelectedIndex = -1;
        }

        private void cmbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name == "cmbIller")
            {
                GetIlceler();
            }

            GetSiparisler();
        }

        private void rbTahsilat_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                GetSiparisler();
            }
        }
    }
}
