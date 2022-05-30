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

namespace Sultanlar.UI
{
    public partial class frmINTERNETiadegirme : Form
    {
        public frmINTERNETiadegirme()
        {
            InitializeComponent();
            iade = null;
            duzenleme = false;
            //GetCariHesaplar("");
        }

        public frmINTERNETiadegirme(int IadeID)
        {
            InitializeComponent();
            iade = Iadeler.GetObjectsByIadeID(IadeID);
            txtAciklama1.Text = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[1];
            txtAciklama2.Text = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[2];

            duzenleme = true;

            txtMusteri.Enabled = false;
            btnMusteriAra.Enabled = false;
            btnBaslat.Text = "İptal Et";
            btnVazgec.Enabled = false;
            cmbMusteriler.Enabled = false;
            cmbSubeler.Enabled = false;
            cmbTemsilciler.Enabled = false;
            cmbBolum.Enabled = false;
            groupBox1.Enabled = true;
            pnlNedenler.Visible = false;
        }

        bool duzenleme;
        Iadeler iade;
        string bolum;

        private void frmINTERNETiadegirme_Load(object sender, EventArgs e)
        {
            if (!duzenleme)
            {
                txtAciklama2.Text = frmAna.KAdi.ToUpper() + "-IADE MERKEZDEN GIRILDI";
                cbUrunlerBurada.Checked = true;
                cmbBolum.SelectedIndex = 0;
            }
        }

        private void GetCariHesaplar(string Musteri)
        {
            cmbSubeler.Items.Clear();
            cmbTemsilciler.Items.Clear();
            CariHesaplar.GetMUSTERIs(cmbMusteriler.Items, Musteri, true);
        }

        private void GetUrunler(string Urun)
        {
            DataTable dt = new DataTable();
            int sayi = Urunler.GetProductsCount("IS", "NOT NULL", "IS", "NOT NULL", "%", Urun, new ArrayList(), new ArrayList());
            Urunler.GetProducts(dt, 0, sayi, "IS", "NOT NULL", "IS", "NOT NULL", "%", Urun, "[OZEL ACIK]", "ASC", new ArrayList(), new ArrayList());
            dt.Columns.Remove(dt.Columns["PASIF"]);
            dataGridView1.DataSource = dt;
        }

        private void GetUrunler(string Barkod, bool barkod)
        {
            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, Barkod, new ArrayList(), new ArrayList(), true, true);
            dt.Columns.Remove(dt.Columns["PASIF"]);
            dataGridView1.DataSource = dt;

            if (dt.Rows.Count == 0)
                lblBarkodBulunamadi.Visible = true;
        }

        private void cmbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubeler.Items.Clear();
            btnBaslat.Enabled = false;
            if (CariHesaplar.AnaSubeMi(((CariHesaplar)cmbMusteriler.SelectedItem).GMREF))
            {
                CariHesaplar.GetSUBEs(cmbSubeler.Items, ((CariHesaplar)cmbMusteriler.SelectedItem).GMREF);
            }
            else
            {
                CariHesaplar.GetSUBEs(cmbSubeler.Items, ((CariHesaplar)cmbMusteriler.SelectedItem).GMREF);
                CariHesaplar.GetSatTemsInnerTblMusterilerByGMREF(cmbTemsilciler.Items, ((CariHesaplar)cmbMusteriler.SelectedItem).GMREF);

                if (cmbTemsilciler.Items.Count > 0)
                    cmbTemsilciler.SelectedIndex = 0;
            }

            for (int i = 0; i < cmbSubeler.Items.Count; i++)
            {
                if (((CariHesaplar)cmbSubeler.Items[i]).SMREF == ((CariHesaplar)cmbMusteriler.SelectedItem).GMREF)
                {
                    cmbSubeler.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAdres.Text = CariHesaplar.GetADRESbySMREF(((CariHesaplar)cmbSubeler.SelectedItem).SMREF);

            if (CariHesaplar.AnaSubeMi(((CariHesaplar)cmbMusteriler.SelectedItem).GMREF))
            {
                CariHesaplar.GetSatTemsInnerTblMusterilerBySMREF(cmbTemsilciler.Items, ((CariHesaplar)cmbSubeler.SelectedItem).SMREF);
                cmbTemsilciler.SelectedIndex = 0;
            }

            btnBaslat.Enabled = true;
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (btnBaslat.Text == "Ürün Girişi")
            {
                if (MessageBox.Show("İade işlemini başlatmak istediğinizden emin misiniz?", "İade Girme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnBaslat.Text = "İptal Et";
                    cmbMusteriler.Enabled = false;
                    cmbSubeler.Enabled = false;
                    cmbTemsilciler.Enabled = false;
                    cmbBolum.Enabled = false;

                    bolum = cmbBolum.SelectedItem.ToString();

                    int musteriid = 1720; //sultanlar satış
                    if (cmbTemsilciler.SelectedIndex > -1)
                        musteriid = Musteriler.GetMusteriIDbySLSREF(SatisTemsilcileri.GetSLSREFBySATTEM(cmbTemsilciler.SelectedItem.ToString()));
                    //else
                    //    musteriid = Musteriler.GetMusteriIDbySLSREF(CariHesaplar.GetSLSREFBySMREF(((CariHesaplar)cmbSubeler.SelectedItem).SMREF));

                    iade = new Iadeler(musteriid, ((CariHesaplar)cmbSubeler.SelectedItem).SMREF, DateTime.Now, 0, false, DateTime.Now, "Sistem;;;;;;");
                    iade.DoInsert();

                    IadeHareketleri.DoInsert(iade.pkIadeID, 8, "iadekabul", ""); // iade girildi

                    lblIadeNo.Text = iade.pkIadeID.ToString();

                    //GetUrunler("");

                    groupBox1.Enabled = true;
                    btnVazgec.Enabled = false;

                    cmbUY.SelectedIndex = 3;
                    cmbDepo.SelectedIndex = 7;
                }
            }
            else
            {
                if (MessageBox.Show("İptal etmek istediğinize emin misiniz?", "İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnBaslat.Text = "Ürün Girişi";
                    cmbMusteriler.Enabled = true;
                    cmbSubeler.Enabled = true;
                    cmbTemsilciler.Enabled = true;
                    cmbBolum.Enabled = true;

                    IadeHareketleri.DoInsert(iade.pkIadeID, 16, frmAna.KAdi.ToUpper(), ""); // iade silindi

                    Iadeler.DoDeleteWithIadelerDetays(iade.pkIadeID);
                    iade = null;

                    groupBox1.Enabled = false;
                    btnVazgec.Enabled = true;
                    GetUrunler("zihuanatejo");
                    lblIadeNo.Text = "";
                    lblSatirSayisi.Text = "0";
                }
            }
        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            if (cbAramadanAktar.Checked)
            {
                btnAktar.PerformClick();
            }
            else
            {
                bool miktargirilmis = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["clMiktar"].Value != null && dataGridView1.Rows[i].Cells["clMiktar"].Value.ToString() != string.Empty)
                    {
                        miktargirilmis = true;
                        break;
                    }
                }

                if (miktargirilmis)
                {
                    if (MessageBox.Show("Miktar girilen satırları listeye aktarmadınız, aktarmak istiyor musunuz?", "Miktar Girildi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnAktar.PerformClick();
                    }
                }
            }

            GetUrunler(txtUrun.Text);
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);

            bool yanlisgirisvar = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["clMiktar"].Value != null && dataGridView1.Rows[i].Cells["clMiktar"].Value.ToString() != string.Empty)
                {
                    try { Convert.ToInt32(dataGridView1.Rows[i].Cells["clMiktar"].Value); }
                    catch (Exception) { yanlisgirisvar = true; break; }

                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["clMiktar"].Value) > 0)
                    {
                        if (bolum != "S1" && Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[i].Cells["clUrunID"].Value)) != bolum)
                        {
                            MessageBox.Show("İade girişi için seçilen bölüm ile eklenmek istenen ürünün bölümü aynı değil.", "Bölüm hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (bolum == "S1" && !Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[i].Cells["clUrunID"].Value)).StartsWith("S"))
                        {
                            MessageBox.Show("İade girişi için seçilen bölüm ile eklenmek istenen ürünün bölümü aynı değil.", "Bölüm hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        long iadedetayid = 0;
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells["clUrunID"].Value) == Convert.ToInt32(dt.Rows[j]["intUrunID"]))
                            {
                                iadedetayid = Convert.ToInt64(dt.Rows[j]["pkIadeDetayID"]);
                                break;
                            }
                        }

                        if (iadedetayid > 0)
                        {
                            IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(iadedetayid);
                            id.intMiktar += Convert.ToInt32(dataGridView1.Rows[i].Cells["clMiktar"].Value);
                            id.DoUpdate();
                            dataGridView1.Rows[i].Cells["clMiktar"].Value = DBNull.Value;
                        }
                        else
                        {
                            IadelerDetay id = new IadelerDetay(iade.pkIadeID, Convert.ToInt32(dataGridView1.Rows[i].Cells["clUrunID"].Value),
                                dataGridView1.Rows[i].Cells["clAd"].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells["clMiktar"].Value), 0);
                            id.DoInsert();
                            dataGridView1.Rows[i].Cells["clMiktar"].Value = DBNull.Value;
                        }
                    }
                }
            }

            if (yanlisgirisvar)
                MessageBox.Show("Hatalı miktar girildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtMusteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMusteriAra.PerformClick();
            }
        }

        private void txtUrun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUrunAra.PerformClick();
            }
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBarkod.PerformClick();
            }
        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            GetCariHesaplar(txtMusteri.Text);
            txtMusteri.Text = string.Empty;
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İadeyi onaylamak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                //string neden = string.Empty;

                if (duzenleme)
                {
                    //iade.strAciklama = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0] + " (SDY)" + ";;;" /*+ "Değişikilik Yapılan İade ! - "*/ + txtAciklama1.Text.Trim() + ";;;" + txtAciklama2.Text.Trim();
                    //iade.blAktarilmis = true;

                    //iade.DoUpdate();

                    IadeHareketleri.DoInsert(iade.pkIadeID, 7, frmAna.KAdi.ToUpper(), ""); // iade düzenlendi

                    frmINTERNETiadeler.iadegirmetamamlandi = true;
                    this.Close();
                }
                else
                {
                    //if (rbHasarli.Checked)
                    //    neden = "HASARLI-";
                    //else if (rbHazirlama.Checked)
                    //    neden = "HAZIRLAMA HATASI-";
                    //else if (rbOnaylanmamis.Checked)
                    //    neden = "ONAYLANMAMIŞ SİPARİŞ-";
                    //else if (rbOdeme.Checked)
                    //    neden = "ÖDEME PROBLEMİ-";
                    //else if (rbSevkiyat.Checked)
                    //    neden = "SEVKİYAT GECİKMESİ-";
                    //else if (rbSonKullanim.Checked)
                    //    neden = "SON KULLANIM TARİHİ-";
                    //else if (rbTeslimat.Checked)
                    //    neden = "TESLİMAT HATASI-";
                    //else if (rbDegisim.Checked)
                    //    neden = "ÜRÜN DEĞİŞİM-";
                    //else if (rbBarkodOkumuyor.Checked)
                    //    neden = "BARKOD OKUMUYOR-";
                    //else if (rbRaftan.Checked)
                    //    neden = "RAFTAN SATIŞI YOK-";
                    //else if (rbFaturadan.Checked)
                    //    neden = "GİDEN FATURADAN İADE-";
                    //else if (rbHatali.Checked)
                    //    neden = "HATALI SİPARİŞ-";

                    iade.strAciklama = "Sistem;;;" + /*neden +*/ txtAciklama1.Text.Trim() + ";;;" + txtAciklama2.Text.Trim();
                    iade.DoUpdate();

                    Iadeler.SetSapDepo(rbSaglamIade.Checked ? "Z17" : "Z16", ((Depo)cmbDepo.SelectedItem).Kod, cmbUY.SelectedItem.ToString(), txtPartiNo.Text.Trim().ToUpper(), iade.pkIadeID);

                    string hata = string.Empty;
                    string sapiadeno = frmINTERNETiadeler.QuantumaYaz(iade.pkIadeID, 0, 0, out hata);

                    if (sapiadeno != string.Empty)
                    {
                        iade.dtOnaylamaTarihi = DateTime.Now;
                        iade.blAktarilmis = true;

                        iade.DoUpdate();

                        IadeHareketleri.DoInsert(iade.pkIadeID, 1, frmAna.KAdi.ToUpper(), ""); // fiyatlandırılmamışa geldi

                        MessageBox.Show("İade SAP'a gönderildi.\r\n\r\nSAP İade No: " + sapiadeno, "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmINTERNETiadeler.iadegirmetamamlandi = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("İade SAP'a gönderilemediği için kaydedilemedi.\r\n\r\nHata ayrıntısı:\r\n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }



                    #region bolunme
                    //DataTable dtSiparistekiUrunler = new DataTable();
                    //IadelerDetay.GetObjectsByIadeID(dtSiparistekiUrunler, iade.pkIadeID);

                    //DataTable dtIsyeriOzelKod = new DataTable();
                    //IsyeriOzelKod.GetObjects(dtIsyeriOzelKod);

                    //for (int i = 0; i < dtIsyeriOzelKod.Rows.Count; i++) // sadece jwax için bölünüyor dolayısıyla 1 kere giriyor buraya
                    //{
                    //    Iadeler yenisiparis =
                    //        new Iadeler(iade.intMusteriID, iade.SMREF, iade.dtOlusmaTarihi, 0, true,
                    //            DateTime.Now, iade.strAciklama);
                    //    ArrayList yenisiparisurunleri = new ArrayList();

                    //    for (int j = 0; j < dtSiparistekiUrunler.Rows.Count; j++)
                    //    {
                    //        string isyeriozelkod = dtIsyeriOzelKod.Rows[i]["strOzelKod"].ToString();
                    //        string urunozelkod = Urunler.GetProductOzelKod(Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]), true);
                    //        if (urunozelkod.StartsWith(isyeriozelkod))
                    //        {
                    //            yenisiparisurunleri.Add(
                    //                new IadelerDetay(
                    //                    0,
                    //                    Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]),
                    //                    dtSiparistekiUrunler.Rows[j]["strUrunAdi"].ToString(),
                    //                    Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intMiktar"]),
                    //                    Convert.ToDecimal(dtSiparistekiUrunler.Rows[j]["mnFiyat"])));

                    //            IadelerDetay siplerdet = IadelerDetay.GetObjectByIadelerDetayID(
                    //                Convert.ToInt64(dtSiparistekiUrunler.Rows[j]["pkIadeDetayID"]));
                    //            siplerdet.DoDelete();
                    //        }
                    //    }

                    //    if (yenisiparisurunleri.Count > 0)
                    //    {
                    //        yenisiparis.DoInsert();

                    //        for (int j = 0; j < yenisiparisurunleri.Count; j++)
                    //        {
                    //            IadelerDetay siplerdet = (IadelerDetay)yenisiparisurunleri[j];
                    //            siplerdet.intIadeID = yenisiparis.pkIadeID;
                    //            siplerdet.DoInsert();
                    //        }

                    //        MessageBox.Show("Yeni iade numarası: " + yenisiparis.pkIadeID.ToString(), "İade No Değişti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }

                    //    DataTable dtEski = new DataTable();
                    //    IadelerDetay.GetObjectsByIadeID(dtEski, iade.pkIadeID);
                    //    if (dtEski.Rows.Count == 0) // bölünüp eskisinde ürün kalmadıysa
                    //    {
                    //        iade.DoDelete();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Yeni iade numarası: " + iade.pkIadeID.ToString(), "İade No Değişti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    #endregion
                }




                //btnBaslat.Text = "Ürün Girişi";
                //cmbMusteriler.Enabled = true;
                //cmbSubeler.Enabled = true;

                //groupBox1.Enabled = false;
                //GetUrunler("zihuanatejo");
                //lblSatirSayisi.Text = "0";

                //if (duzenleme)
                //    this.Close();
                //else
                //    btnVazgec.Enabled = true;
            }
        }

        //frmINTERNETiadegirmeliste frm;
        //static internal bool listeacik = false;

        private void btnSepet_Click(object sender, EventArgs e)
        {
            //if (!listeacik)
            //{
            //    frm = new frmINTERNETiadegirmeliste(iade.pkIadeID);
            //    frm.Show();
            //    listeacik = true;
            //}
            //else
            //{
            //    frm.Focus();
            //}

            frmINTERNETiadegirmeliste frm = new frmINTERNETiadegirmeliste(iade.pkIadeID, bolum);
            frm.ShowDialog();
        }

        private void btnBarkod_Click(object sender, EventArgs e)
        {
            lblBarkodBulunamadi.Visible = false;

            GetUrunler(txtBarkod.Text.Trim(), true);



            //if (dataGridView1.Rows.Count > 0)
            //{
            //    DataTable dt = new DataTable();
            //    IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);

            //    long iadedetayid = 0;
            //    for (int j = 0; j < dt.Rows.Count; j++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[0].Cells["clUrunID"].Value) == Convert.ToInt32(dt.Rows[j]["intUrunID"]))
            //        {
            //            iadedetayid = Convert.ToInt64(dt.Rows[j]["pkIadeDetayID"]);
            //            break;
            //        }
            //    }

            //    if (iadedetayid > 0)
            //    {
            //        IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(iadedetayid);
            //        id.intMiktar += 1;
            //        id.DoUpdate();
            //        dataGridView1.Rows[0].Cells["clMiktar"].Value = DBNull.Value;
            //    }
            //    else
            //    {
            //        IadelerDetay id = new IadelerDetay(iade.pkIadeID, Convert.ToInt32(dataGridView1.Rows[0].Cells["clUrunID"].Value),
            //            dataGridView1.Rows[0].Cells["clAd"].Value.ToString(), 1, 0);
            //        id.DoInsert();
            //        dataGridView1.Rows[0].Cells["clMiktar"].Value = DBNull.Value;
            //    }

            //    //frm.GetObjects();
            //}



            txtBarkod.Text = string.Empty;

            if (dataGridView1.Rows.Count > 0)
            {
                //dataGridView1.Rows[0].Cells["clAd"].Selected = false;
                //dataGridView1.Rows[0].Cells["clMiktar"].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["clMiktar"];
                dataGridView1.Focus();
            }
            else
            {
                txtBarkod.Focus();
            }
        }

        private void frmINTERNETiadegirme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (iade != null)
                if (!iade.blAktarilmis && !duzenleme)
                    Iadeler.DoDeleteWithIadelerDetays(iade.pkIadeID);
        }

        protected override bool ProcessTabKey(bool forward)
        {
            if (txtBarkod.Focused)
            {
                btnBarkod.PerformClick();
            }
            return false;
        }

        private void cbAramadanAktar_MouseHover(object sender, EventArgs e)
        {
            lblAramadanAktar.Visible = true;
        }

        private void cbAramadanAktar_MouseLeave(object sender, EventArgs e)
        {
            lblAramadanAktar.Visible = false;
        }

        private void cbUrunlerBurada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUrunlerBurada.Checked)
            {
                txtAciklama2.Text = frmAna.KAdi.ToUpper() + "-IADE MERKEZDEN GIRILDI";
            }
            else
            {
                txtAciklama2.Text = "";
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            frmINTERNETiadeler.iadegirmetamamlandi = false;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAktar.PerformClick();
                txtBarkod.Focus();
            }
        }

        private void cmbUY_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDepolar(cmbDepo.Items, cmbUY.SelectedItem.ToString());
            cmbDepo.SelectedIndex = 0;
        }

        private void GetDepolar(IList List, string UY)
        {
            List.Clear();

            if (UY == "TB10")
            {
                List.Add(new Depo("SP53", "SP53 Depo Yeri"));
                List.Add(new Depo("TB10", "Tibet Hammadde"));
                List.Add(new Depo("TB11", "Tibet Ambalaj"));
                List.Add(new Depo("TB13", "Teslim Tesellüm"));
                List.Add(new Depo("TB14", "Tibet Üretim"));
                List.Add(new Depo("TB15", "İhracat Deposu"));
                List.Add(new Depo("TB16", "Tibet Silolar"));
                List.Add(new Depo("TB17", "Tibet Kırtasiye"));
                List.Add(new Depo("TB18", "Tibet Sevkiyat"));
                List.Add(new Depo("TB19", "Tibet Sevk. Adet"));
                List.Add(new Depo("TB1A", "İade Depo"));
                List.Add(new Depo("TB1B", "İmha Depo"));
                List.Add(new Depo("TB1C", "Karantina Depo"));
                List.Add(new Depo("TB1D", "Promosyon Depo"));
                List.Add(new Depo("TB1E", "Re-Work Depo"));
                List.Add(new Depo("TB20", "Tib.Transfer Dep"));
                List.Add(new Depo("TB21", "Teknik Depo Y."));
                List.Add(new Depo("TB22", "Ü.İade Tesellüm"));
                List.Add(new Depo("TBEF", "Envanter Farkı"));
                List.Add(new Depo("TBS1", "Sultanlar Kat 1"));
                List.Add(new Depo("TBS2", "Sultanlar Kat 2"));
                List.Add(new Depo("TBS3", "Sultanlar Kat 3"));
                List.Add(new Depo("TS1A", "Sultanlar İade D"));
                List.Add(new Depo("TS1B", "Sultanlar İmha D"));
                List.Add(new Depo("TS5A", "Sult.Kurt İade D"));
                List.Add(new Depo("TS5B", "Sult.Kurt İmha D"));
                List.Add(new Depo("TBET", "E-Ticaret"));
            }
            else if (UY == "TB13")
            {
                List.Add(new Depo("SP53", "SP53 Depo Yeri"));
                List.Add(new Depo("TB10", "YEG Hammadde"));
                List.Add(new Depo("TB11", "YEG Ambalaj"));
                List.Add(new Depo("TB12", "Tibet YEG deposu"));
                List.Add(new Depo("TB13", "Teslim Tesellüm"));
                List.Add(new Depo("TB14", "YEG Üretim Depo"));
                List.Add(new Depo("TB15", "İhracat Deposu"));
                List.Add(new Depo("TB18", "YEG Sevkiyat"));
                List.Add(new Depo("TB19", "YEG Sevk. Adet"));
                List.Add(new Depo("TB1A", "İade Depo"));
                List.Add(new Depo("TB1B", "İmha Depo"));
                List.Add(new Depo("TB1C", "Karantina Depo"));
                List.Add(new Depo("TB1D", "Promosyon Depo"));
                List.Add(new Depo("TB1E", "Re-Work Depo"));
                List.Add(new Depo("TB20", "Ü.İade Tesellüm"));
                List.Add(new Depo("TBEF", "Envanter Farkı"));
                List.Add(new Depo("TBET", "E-Ticaret"));
            }
            else if (UY == "TB20" || UY == "TB60")
            {
                List.Add(new Depo("TS5B", "Sult.Kurt İmha D"));
                List.Add(new Depo("TS5A", "Sult.Kurt İade D"));
                List.Add(new Depo("TS2B", "Sultanlar İmha D"));
                List.Add(new Depo("TS2A", "Sultanlar İade D"));
                List.Add(new Depo("TBS3", "Sultanlar Kat 3"));
                List.Add(new Depo("TBS2", "Sultanlar Kat 2"));
                List.Add(new Depo("TBS1", "Sultanlar Kat 1"));
                List.Add(new Depo("TBEF", "Envanter Farkı"));
                List.Add(new Depo("TB30", "Ü.İade Tesellüm"));
                List.Add(new Depo("TB2E", "Re-Work Depo"));
                List.Add(new Depo("TB2D", "Promosyon Depo"));
                List.Add(new Depo("TB2C", "Karantina Depo"));
                List.Add(new Depo("TB2B", "İmha Depo"));
                List.Add(new Depo("TB2A", "İade Depo"));
                List.Add(new Depo("TB29", "Teknik Depo Y."));
                List.Add(new Depo("TB28", "Dış Depolar"));
                List.Add(new Depo("TB27", "Hyt.Transfer Dep"));
                List.Add(new Depo("TB26", "Teslim Tesellüm"));
                List.Add(new Depo("TB25", "İhracat Deposu"));
                List.Add(new Depo("TB24", "Hayat Üretim"));
                List.Add(new Depo("TB23", "Hayat Sevk. ADET"));
                List.Add(new Depo("TB22", "Hayat Sevkiyat"));
                List.Add(new Depo("TB21", "Hayat Ambalaj"));
                List.Add(new Depo("TB20", "Hayat Hammadde"));
                List.Add(new Depo("SP53", "SP53 Depo Yeri"));
                List.Add(new Depo("TBET", "E-Ticaret"));
            }
            else if (UY == "TB80")
            {
                List.Add(new Depo("SP53", "SP53 Depo Yeri"));
                List.Add(new Depo("TB18", "Tibet Sevkiyat"));
                List.Add(new Depo("TB22", "Hayat Sevkiyat"));
                List.Add(new Depo("TB81", "Sultanlar Kat 1"));
                List.Add(new Depo("TB82", "Sultanlar Kat 2"));
                List.Add(new Depo("TB83", "Sultanlar Kat 3"));
                List.Add(new Depo("TB85", "Transfer depo"));
                List.Add(new Depo("TB8A", "İade depo"));
                List.Add(new Depo("TB8B", "İmha Depo"));
                List.Add(new Depo("TB8E", "Sultanlar Rework"));
                List.Add(new Depo("TBET", "E-Ticaret"));
            }
        }
    }

    public class Depo
    {
        public string Kod { get; set; }
        public string Ad { get; set; }

        public Depo(string Kod, string Ad)
        {
            this.Kod = Kod;
            this.Ad = Ad;
        }

        public override string ToString()
        {
            return this.Kod + "-" + this.Ad;
        }
    }
}
