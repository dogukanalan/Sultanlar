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
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmINTERNETiadelerdetay : Form
    {
        /// <summary>
        /// nereden: 0 tümü, 1 fiyatlandırılmamış, 2 fiyatlandırılmış, 3 sevk bekleyen, 4 iade girilen, 5 iade kabul, 6 sat.op, 7 s.t., 8 c/h, 9 son, 10 red, 11 değişim, 12 önemsiz, 13 çöptekiler2
        /// </summary>
        public frmINTERNETiadelerdetay(int iadeid, int smref, int nereden)
        {
            InitializeComponent();

            IadeID = iadeid;
            SMREF = smref;
            Nereden = nereden;

            if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR" || frmAna.KAdi.ToUpper() == "YN02" 
                || frmAna.KAdi.ToUpper() == "LK12" || frmAna.KAdi.ToUpper() == "LK13" || frmAna.KAdi.ToUpper() == "LK14"
                || frmAna.KAdi.ToUpper() == "ST08") //frmAna.KAdi.ToUpper() == "ST16" || frmAna.KAdi.ToUpper() == "MI01" || frmAna.KAdi.ToUpper() == "ST03" || frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR" || frmAna.KAdi.ToUpper() == "ST12" || frmAna.KAdi.ToUpper() == "FN03" || frmAna.KAdi.ToUpper() == "YN04" || frmAna.KAdi.ToUpper() == "YN02" || frmAna.KAdi.ToUpper() == "ST07" || frmAna.KAdi.ToUpper() == "ST13"
            {
                txtTutar.Enabled = true;
                btnFiyatGuncelle.Enabled = true;
                cmbListeFiyati.Enabled = true;
                btnListeFiyati.Enabled = true;
                btnIadeFiyatlandir.Enabled = true;
                btnHizmetHesapla.Enabled = true;
                btnKaydet.Enabled = true;
                btnTamamla.Enabled = nereden != 13;
            }

            if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR" || frmAna.KAdi.ToUpper() == "ST08")
            {
                btnAciklamaGuncelle.Enabled = true;
            }

            if ((nereden == 9 || nereden == 0) && frmAna.KAdi.ToUpper() != "BI04" && frmAna.KAdi.ToUpper() != "ADMİNİSTRATOR" &&
                frmAna.KAdi.ToUpper() != "ST16" && frmAna.KAdi.ToUpper() != "MI01" && frmAna.KAdi.ToUpper() != "ST08" && 
                frmAna.KAdi.ToUpper() != "ST03")
            {
                //btnYazdir.Enabled = false;
            }
        }
        /// <summary>
        /// nereden: 0 tümü, 1 fiyatlandırılmamış, 2 fiyatlandırılmış, 3 sevk bekleyen, 4 iade girilen, 5 iade kabul, 6 sat.op, 7 s.t., 8 c/h, 9 son, 10 red, 11 değişim, 12 önemsiz, 13 çöptekiler2
        /// </summary>
        public frmINTERNETiadelerdetay(int iadeid, int smref, bool degisiklikyok, int nereden)
        {
            InitializeComponent();

            IadeID = iadeid;
            SMREF = smref;
            Nereden = nereden;

            txtTutar.Enabled = false;
            btnFiyatGuncelle.Enabled = false;
            btnIadeFiyatlandir.Enabled = false;
            btnHizmetHesapla.Enabled = false;
            btnKaydet.Enabled = false;
            btnTamamla.Enabled = false;

            if ((nereden == 9 || nereden == 0) && frmAna.KAdi.ToUpper() != "BI04" && frmAna.KAdi.ToUpper() != "ADMİNİSTRATOR" &&
                frmAna.KAdi.ToUpper() != "ST16" && frmAna.KAdi.ToUpper() != "MI01" && frmAna.KAdi.ToUpper() != "ST08" && 
                frmAna.KAdi.ToUpper() != "ST03")
            {
                //btnYazdir.Enabled = false;
            }
        }

        int IadeID;
        int SMREF;
        DataTable dt;
        int Nereden;

        private void frmINTERNETiadelerdetay_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp"))
                Directory.Delete(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp", true);
            Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp");

            dateTimePicker1.Value = Convert.ToDateTime("01.01.2008");
            dateTimePicker2.Value = DateTime.Now;
            GetIadelerDetay();
            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);
            txtAciklama2.Text = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[1];
            txtAciklama3.Text = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[2];

            FiyatTipleri.GetObject(cmbListeFiyati.Items, true);
            cmbListeFiyati.SelectedIndex = 21;
        }

        private void GetIadelerDetay()
        {
            dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID_Fiy(dt, IadeID);
            dataGridView1.DataSource = dt;
        }

        private void BarkodOlustur(string Barkod, string Yer, string Numara)
        {
            BarcodeLib.Barcode bc = new BarcodeLib.Barcode();
            bc.LabelFont = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
            bc.IncludeLabel = true;
            bc.Width = 100;
            bc.Height = 45;
            bc.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            bc.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            bc.BackColor = Color.White;
            bc.ForeColor = Color.Black;

            try
            {
                bc.Encode(BarcodeLib.TYPE.CODE128, Barkod);
                bc.SaveImage(Yer + "\\" + Numara + "barkod.png", BarcodeLib.SaveTypes.PNG);
            }
            catch (Exception ex)
            {
                if (ex.Message == "EEAN13-3: Country assigning manufacturer code not found.")
                {
                    bc.Encode(BarcodeLib.TYPE.CODE128, Barkod);
                    bc.SaveImage(Yer + "\\" + Numara + "barkod.png", BarcodeLib.SaveTypes.PNG);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmINTERNETiadelerdetay_SizeChanged(object sender, EventArgs e)
        {
            btnYazdir.Location = new Point(btnYazdir.Location.X, btnYazdir.Location.Y);

            txtTutar.Location = new Point(txtTutar.Location.X, lblAlt.Location.Y + 8);
            cmbListeFiyati.Location = new Point(cmbListeFiyati.Location.X, lblAlt.Location.Y + 6);
            btnListeFiyati.Location = new Point(btnListeFiyati.Location.X, lblAlt.Location.Y + 6);
            btnFiyatGuncelle.Location = new Point(btnFiyatGuncelle.Location.X, lblAlt.Location.Y + 6);

            btnIadeFiyatlandir.Location = new Point(btnIadeFiyatlandir.Location.X, lblAlt.Location.Y + 6);
            btnHizmetHesapla.Location = new Point(btnHizmetHesapla.Location.X, lblAlt.Location.Y + 6);

            btnKaydet.Location = new Point(btnKaydet.Location.X, lblAlt.Location.Y + 6);
            btnTamamla.Location = new Point(btnTamamla.Location.X, lblAlt.Location.Y + 6);
        }

        private void btnISK_Click(object sender, EventArgs e)
        {
            string kolon = string.Empty;
            if (((Button)sender).Name == "btnISK")
                kolon = "AD ID";
            else if (((Button)sender).Name == "btnISKBDL")
                kolon = "AD IBD";
            else if (((Button)sender).Name == "btnISKBDLPROM")
                kolon = "AD IBPD";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt1 = new DataTable();
                IadeFiyat.GetObjectsBySMREFITEMREF(dt1, SMREF, Convert.ToInt32(dt.Rows[i]["intUrunID"]), dateTimePicker1.Value, dateTimePicker2.Value);
                decimal toplam = 0;
                for (int j = 0; j < dt1.Rows.Count; j++)
                    toplam += Convert.ToDecimal(dt1.Rows[j][kolon]);
                decimal ortalama = 0;
                if (dt1.Rows.Count > 0)
                    ortalama = toplam / dt1.Rows.Count;



                IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt32(dt.Rows[i]["pkIadeDetayID"]));
                id.mnFiyat = ortalama;
                id.DoUpdate();

                dt.Rows[i]["mnFiyat"] = ortalama;
                dt.Rows[i]["mnToplam"] = ortalama * Convert.ToInt32(dt.Rows[i]["intMiktar"]);
                //dataGridView1.Rows[i].Cells["clmnFiyat"].Value = ortalama;
                //dataGridView1.Rows[i].Cells["clmnToplam"].Value = ortalama * Convert.ToInt32(dt.Rows[i]["intMiktar"]);
            }

            dataGridView1.DataSource = dt;

            txtTutar.Text = dt.Rows[dataGridView1.SelectedRows[0].Index]["mnFiyat"].ToString();
        }

        private void dataGridView1_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            txtTutar.Text = dt.Rows[e.RowIndex]["mnFiyat"].ToString();
        }

        private void btnFiyatGuncelle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İade Birim Fiyat Tutarını güncellediğinizde, bu satıra ait daha önceden hesaplanmış hizmet sıfırlanacaktır. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                return;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                IadeDetayFiyatSifirla();



                IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID
                    (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));
                id.mnFiyat = Convert.ToDecimal(txtTutar.Text.Trim());
                id.DoUpdate();



                //IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));
                //if (idf.bintIadeDetayID != 0)
                //{
                //    idf.mnIadeToplam = Convert.ToDecimal(txtTutar.Text.Trim()) * id.intMiktar;
                //    idf.mnHizmetToplam = 0;
                //    idf.dtFiyatlandirmaTarihi = DateTime.Now;
                //    idf.strFiyatlandiran = frmAna.KAdi.ToUpper();
                //    idf.dtHizmetTarihi = DateTime.MinValue;
                //    idf.strHizmetleyen = string.Empty;
                //}
                //else
                //{
                //    idf = new IadelerDetayFiy(id.pkIadeDetayID, Convert.ToDecimal(txtTutar.Text.Trim()) * id.intMiktar,
                //        0, DateTime.Now, frmAna.KAdi.ToUpper(), DateTime.MinValue, string.Empty);
                //    idf.DoInsert();
                //}

                IadelerDetayFiy idf = new IadelerDetayFiy(id.pkIadeDetayID, Convert.ToDecimal(txtTutar.Text.Trim()) * id.intMiktar,
                    0, DateTime.Now, frmAna.KAdi.ToUpper(), DateTime.MinValue, string.Empty);
                idf.DoInsert();



                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnFiyat"] = Convert.ToDecimal(txtTutar.Text.Trim());
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnIadeToplam"] = Convert.ToDecimal(txtTutar.Text.Trim()) * id.intMiktar;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnHizmet"] = 0;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnHizmetToplam"] = 0;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnToplam"] = Convert.ToDecimal(txtTutar.Text.Trim()) * id.intMiktar;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["dtFiyatlandirmaTarihi"] = DateTime.Now;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["strFiyatlandiran"] = frmAna.KAdi.ToUpper();
                dt.Rows[dataGridView1.SelectedRows[0].Index]["dtHizmetTarihi"] = DateTime.MinValue;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["strHizmetleyen"] = string.Empty;
                dataGridView1.DataSource = dt;
            }
        }

        private void btnListeFiyati_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && cmbListeFiyati.SelectedIndex > -1)
            {
                IadeDetayFiyatSifirla();



                IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID
                    (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));
                decimal tutar = Urunler.GetProductPriceFULL(id.intUrunID, ((FiyatTipleri)cmbListeFiyati.SelectedItem).NOSU);
                id.mnFiyat = tutar;
                id.DoUpdate();

                IadelerDetayFiy idf = new IadelerDetayFiy(id.pkIadeDetayID, tutar * id.intMiktar,
                    0, DateTime.Now, frmAna.KAdi.ToUpper(), DateTime.MinValue, string.Empty);
                idf.DoInsert();



                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnFiyat"] = tutar;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnIadeToplam"] = tutar * id.intMiktar;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnHizmet"] = 0;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnHizmetToplam"] = 0;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["mnToplam"] = tutar * id.intMiktar;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["dtFiyatlandirmaTarihi"] = DateTime.Now;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["strFiyatlandiran"] = frmAna.KAdi.ToUpper();
                dt.Rows[dataGridView1.SelectedRows[0].Index]["dtHizmetTarihi"] = DateTime.MinValue;
                dt.Rows[dataGridView1.SelectedRows[0].Index]["strHizmetleyen"] = string.Empty;
                dataGridView1.DataSource = dt;

                txtTutar.Text = tutar.ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Kaydetme işlemine devam etmek istiyor musunuz?", "Kaydetme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    IadeFiyatAdet.DoUpdate(Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value), true);
            //    this.Close();
            //}
            this.Close();
        }

        private void btnTamamla_Click(object sender, EventArgs e)
        {
            decimal toplam = 0;
            bool girilmemisurunvar = false;
            ArrayList girilmemisurunlerid = new ArrayList();
            //ArrayList girilmemisurunler = new ArrayList();
            bool bedelsizurunvar = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["mnToplam"] != DBNull.Value)
                {
                    decimal fiyat = Convert.ToDecimal(dt.Rows[i]["mnToplam"]);

                    toplam += fiyat;

                    if (fiyat == 0)
                    {
                        bedelsizurunvar = true;
                    }
                }
                else
                {
                    girilmemisurunlerid.Add(Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]));
                    //girilmemisurunler.Add(dt.Rows[i]["strUrunAdi"].ToString() + " (" + dt.Rows[i]["intMiktar"].ToString() + " Adet)");
                    girilmemisurunvar = true;
                }
            }

            string bedelsiz = bedelsizurunvar ? " - Bazı satırlar bedelsiz girildi.\r\n" : "";
            string girilmemisurun = girilmemisurunvar ? " - Bazı satırlar hesaplanmadığı için iptal edilecek ve \"Bu ürünlerin iadesi kabul edilmedi\" şeklinde müşteriye (veya satış temsilcisine) bilgi verilecek.\r\n" : "";

            if (MessageBox.Show("İadenin toplam tutarı: " + toplam.ToString("C2") + "\r\n\r\n" + bedelsiz + girilmemisurun + "\r\nDevam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);

                #region mesajlar
                /*
                if (iade.strAciklama.StartsWith("Sistem") || iade.strAciklama.IndexOf("(sistemden değişiklik yapıldı)") > -1 || iade.strAciklama.IndexOf("(SDY)") > -1)
                {
                    if (iade.strAciklama.IndexOf("(sistemden değişiklik yapıldı)") > -1 || iade.strAciklama.IndexOf("(SDY)") > -1)
                    {
                        GonderilenMesajlar gm = new GonderilenMesajlar(
                            iade.intMusteriID,
                            59,
                            "Değiştirilip Fiyatlandırılan İade: " + iade.pkIadeID.ToString(),
                            iade.pkIadeID.ToString() + " nolu iade talebiniz tekrar fiyatlandırılmıştır. <a href='iadeler.aspx'>İadeler</a> sayfasından, \"Onay Talepten Gelen İadeler\" seçeneğini tıklayarak fiyatlandırılmış iade talebini onaylayarak devreye sokabilirsiniz.\r\n\r\n" + iadekabuledilmeyenler + "\r\n\r\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\r\n", "<br />"),
                            DateTime.Now,
                            DateTime.MinValue,
                            false,
                            false,
                            false);
                        gm.DoInsert();
                    }
                    else
                    {
                        GonderilenMesajlar gm = new GonderilenMesajlar(
                            iade.intMusteriID,
                            59,
                            "Fiyatlandırılan İade: " + iade.pkIadeID.ToString(),
                            "Merkezden iade talep formu ile girilen iade talebi, " + iade.pkIadeID.ToString() + " no ile sisteme girilmiş ve fiyatlandırılmıştır. <a href='iadeler.aspx'>İadeler</a> sayfasından, \"Onay Talepten Gelen İadeler\" seçeneğini tıklayarak fiyatlandırılmış iade talebini onaylayarak devreye sokabilirsiniz.\r\n\r\n" + iadekabuledilmeyenler + "\r\n\r\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\r\n", "<br />"),
                            DateTime.Now,
                            DateTime.MinValue,
                            false,
                            false,
                            false);
                        gm.DoInsert();
                    }
                }
                else
                {
                    GonderilenMesajlar gm = new GonderilenMesajlar(
                        iade.intMusteriID,
                        59,
                        "Fiyatlandırılan İade: " + iade.pkIadeID.ToString(),
                        iade.pkIadeID.ToString() + " nolu iade talebiniz fiyatlandırılmıştır. <a href='iadeler.aspx'>İadeler</a> sayfasından, \"Onay Talepten Gelen İadeler\" seçeneğini tıklayarak fiyatlandırılmış iade talebini onaylayarak devreye sokabilirsiniz.\r\n\r\n" + iadekabuledilmeyenler + "\r\n\r\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\r\n", "<br />"),
                        DateTime.Now,
                        DateTime.MinValue,
                        false,
                        false,
                        false);
                    gm.DoInsert();
                }
                */
                #endregion

                DataTable dt = new DataTable();
                IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);

                SAPchangeorderC.ZWEB_CHANGE_SALES_ORDERService serv = new SAPchangeorderC.ZWEB_CHANGE_SALES_ORDERService();
                serv.Credentials = new System.Net.NetworkCredential("MISTIF", "Ankara1923*+B");
                SAPchangeorderC.BAPIRET2[] donen1 = null;
                SAPchangeorderC.ZWEBS022[] items = new SAPchangeorderC.ZWEBS022[dt.Rows.Count];

                string error = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    items[i] = new SAPchangeorderC.ZWEBS022();

                    double kdv = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                    if (kdv == 0) error += dt.Rows[i]["intUrunID"].ToString() + " SAP kodlu ürünün KDV'si bulunamadı. ";
                    decimal kdvlifiyat = Convert.ToDecimal(dt.Rows[i]["mnFiyat"]);

                    items[i].POSNR = ((i + 1) * 100).ToString();
                    items[i].FIYATSpecified = true;
                    items[i].FIYAT = Convert.ToDecimal((kdvlifiyat / ((100 + Convert.ToDecimal(kdv)) / 100)).ToString("N2"));
                }

                if (error == string.Empty) // kdv si olmayan ürün varsa fiyatları göndermesin
                {
                    try { donen1 = serv.ZWEB_CHANGE_SALES_ORDER(items, IadelerQ.GetQuantumNo(iade.pkIadeID)); }
                    catch (Exception ex) { error = ex.Message; }
                }

                if (error == string.Empty)
                {
                    iade.mnToplamTutar = toplam == 0 ? Convert.ToDecimal(0.001) : toplam;
                    iade.blAktarilmis = true;
                    iade.DoUpdate();

                    IadeHareketleri.DoInsert(iade.pkIadeID, 2, frmAna.KAdi.ToUpper(), ""); // fiyatlandırılmışa geldi

                    string iadekabuledilmeyenler = string.Empty;
                    //if (girilmemisurunlerid.Count > 0)
                    //    iadekabuledilmeyenler = "Bu iadedeki şu ürünlerin iadesi kabul edilmedi ve listeden çıkarıldı: \r\n\r\n";
                    for (int i = 0; i < girilmemisurunlerid.Count; i++)
                    {
                        IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(girilmemisurunlerid[i]));
                        id.mnFiyat = 0;
                        id.DoUpdate();
                        //iadekabuledilmeyenler += id.strUrunAdi + " (" + id.intMiktar + " Adet)\r\n";
                    }

                    MessageBox.Show("İade fiyatlandırması tamamlandı ve fiyatlar SAP'a gönderildi.", "Onaylandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < donen1.Length; i++)
                        error += donen1[i].MESSAGE + ", ";
                    MessageBox.Show("İade fiyatları SAP'da güncellenemedi. Hata ayrıntısı:\r\n\r\n" + error, "Onaylandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }

        private void frmINTERNETiadelerdetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //decimal toplam = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    toplam += Convert.ToDecimal(dt.Rows[i]["mnToplam"]);

            //Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);
            //iade.mnToplamTutar = toplam;
            //iade.DoUpdate();
        }

        private void btnIadeFiyatlandir_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.SelectedRows[0].Index;

            if (rowindex < 0)
                return;

            if (dataGridView1.SelectedRows[0].Cells["clmnToplam"].Value == DBNull.Value)
            {
                FiyatHesapla(rowindex);
            }
            else
            {
                if (MessageBox.Show("Bu satır zaten fiyatlandırılmış. İptal edip tekrar fiyatlandırmak istiyor musunuz?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    IadeDetayFiyatSifirla();

                    FiyatHesapla(rowindex);
                }

                //MessageBox.Show("Bu satır zaten fiyatlandırılmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IadeDetayFiyatSifirla()
        {
            IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));
            idf.DoDelete();

            IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));

            DataTable dt1 = new DataTable();
            IadeFiyatAdet.GetObjectsByIadeDetayID(dt1, id.pkIadeDetayID);
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["ITEMREF"].ToString() == id.intUrunID.ToString())
                {
                    IadeFiyatAdet ifa = IadeFiyatAdet.GetObject(dt1.Rows[j]["STRREF"].ToString());
                    if (ifa.STRREF != string.Empty) // bu satıra hizmet girilmiş ise
                    {
                        ifa.ADIADE = ifa.ADIADE - id.intMiktar <= 0 ? 0 : ifa.ADIADE - id.intMiktar;
                        ifa.DoUpdate();

                        if (ifa.ADIADE == 0)
                            ifa.DoDelete();
                    }
                }
            }

            int GMREF = CariHesaplar.GetGMREFBySMREF(SMREF);
            string OZELKOD = Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clintUrunID"].Value), true);
            IadeHizmetTutar iht = IadeHizmetTutar.GetObject(GMREF, OZELKOD);
            iht.TUTTOP = iht.TUTTOP - idf.mnHizmetToplam;
            iht.DoUpdate();
            if (iht.TUTTOP == 0 && iht.STRREF != string.Empty)
                iht.DoDelete();

            Iadeler iade = Iadeler.GetObjectsByIadeID(id.intIadeID);
            iade.mnToplamTutar = iade.mnToplamTutar - (id.mnFiyat * id.intMiktar);
            if (iade.mnToplamTutar < 0)
                iade.mnToplamTutar = 0;
            iade.DoUpdate();

            id.mnFiyat = 0;
            id.DoUpdate();
        }

        private void FiyatHesapla(int rowindex)
        {
            int GMREF = cbAnaSube.Checked ? CariHesaplar.GetGMREFBySMREF(SMREF) : 0;
            frmINTERNETiadelerdetayfiyat frm = new frmINTERNETiadelerdetayfiyat(
                Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clpkIadeDetayID"].Value),
                GMREF, SMREF, Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value),
                Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintMiktar"].Value),
                dateTimePicker1.Value, dateTimePicker2.Value);
            frm.ShowDialog();

            GetIadelerDetay();
            dataGridView1.Rows[rowindex].Selected = true;
            txtTutar.Text = dt.Rows[rowindex]["mnFiyat"].ToString();
        }

        private void btnHizmetHesapla_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.SelectedRows[0].Index;

            if (rowindex < 0)
                return;

            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clmnFiyat"].Value) != 0
                && Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clmnHizmetToplam"].Value) == 0)
            {
                HizmetHesap(rowindex);
            }
            else if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clmnFiyat"].Value) == 0)
            {
                MessageBox.Show("Bu satır fiyatlandırılmamış. Satırı fiyatlandırmadan hizmet hesaplayamazsınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clmnHizmetToplam"].Value) != 0)
            {
                if (MessageBox.Show("Bu satırın hizmeti zaten hesaplanmış. İptal edip tekrar hesaplamak istiyor musunuz?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    HizmetSifirla();

                    HizmetHesap(rowindex);
                }

                //MessageBox.Show("Bu satırın hizmeti zaten hesaplanmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HizmetSifirla()
        {
            IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));
            idf.mnHizmetToplam = 0;
            idf.dtHizmetTarihi = DateTime.MinValue;
            idf.strHizmetleyen = string.Empty;
            idf.DoUpdate();



            int GMREF = CariHesaplar.GetGMREFBySMREF(SMREF);
            string OZELKOD = Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clintUrunID"].Value), true);
            //DataTable dt = new DataTable();
            //IadeHizmet.GetSTRREFsByGMREFOZELKOD(dt, GMREF, OZELKOD);
            //DataTable dt1 = new DataTable();
            //IadeHizmetTutar.GetObjects(dt1);
            //string STRREF = string.Empty;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt1.Rows.Count; j++)
            //    {
            //        if (dt.Rows[i]["STRREF"].ToString() == dt1.Rows[j]["STRREF"].ToString())
            //        {
            //            STRREF = dt.Rows[i]["STRREF"].ToString();
            //            IadeHizmetTutar iht = IadeHizmetTutar.GetObject(STRREF);
            //            iht.TUTTOP = iht.TUTTOP - Convert.ToDecimal(dt.Rows[i]["mnHizmetToplam"]);
            //            iht.DoUpdate();

            //            if (iht.TUTTOP == 0)
            //                IadeHizmetTutar.DoDelete(STRREF);
            //        }
            //    }
            //}
            //if (STRREF == string.Empty) // buraya düşmez
            //    IadeHizmetTutar.DoDelete(STRREF);
            IadeHizmetTutar iht = IadeHizmetTutar.GetObject(GMREF, OZELKOD);
            iht.TUTTOP = iht.TUTTOP - Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["clmnHizmetToplam"].Value);
            iht.DoUpdate();
            if (iht.TUTTOP == 0)
                iht.DoDelete();



            IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["clpkIadeDetayID"].Value));

            Iadeler iade = Iadeler.GetObjectsByIadeID(id.intIadeID);
            if (iade.mnToplamTutar != 0)
                iade.mnToplamTutar = iade.mnToplamTutar - id.mnFiyat;

            id.mnFiyat = idf.mnIadeToplam;
            id.DoUpdate();

            if (iade.mnToplamTutar != 0)
            {
                iade.mnToplamTutar = iade.mnToplamTutar + id.mnFiyat;
                if (iade.mnToplamTutar < 0)
                    iade.mnToplamTutar = 0;
                iade.DoUpdate();
            }
        }

        private void HizmetHesap(int rowindex)
        {
            int GMREF = cbAnaSube.Checked ? CariHesaplar.GetGMREFBySMREF(SMREF) : 0;



            double urunsatis = 0;
            double oncekiiadetoplam = 0;
            //int urunsatisadet = 0;
            double genelsatis = 0;
            double hizmetgenel = 0;

            if (GMREF > 0)
            {
                urunsatis = IadeFiyat.GetNETTOPByGMREFITEMREF(GMREF,
                    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), dateTimePicker1.Value, dateTimePicker2.Value);
                oncekiiadetoplam = IadeFiyat.GetOncekiIadeoplamByGMREFITEMREF(GMREF,
                    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), dateTimePicker1.Value, dateTimePicker2.Value);
                //urunsatisadet = IadeFiyat.GetSatisAdetByGMREFITEMREF(GMREF,
                //    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), dateTimePicker1.Value, dateTimePicker2.Value);
                genelsatis = IadeFiyat.GetNETTOPByGMREFOZELKOD(GMREF,
                    Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), true),
                    dateTimePicker1.Value, dateTimePicker2.Value);

                hizmetgenel = IadeHizmet.GetNETTOPByGMREFOZELKOD(GMREF,
                Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), true),
                    dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else
            {
                urunsatis = IadeFiyat.GetNETTOPBySMREFITEMREF(SMREF,
                    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), dateTimePicker1.Value, dateTimePicker2.Value);
                oncekiiadetoplam = IadeFiyat.GetOncekiIadeoplamBySMREFITEMREF(GMREF,
                    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), dateTimePicker1.Value, dateTimePicker2.Value);
                //urunsatisadet = IadeFiyat.GetSatisAdetBySMREFITEMREF(SMREF,
                //    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), dateTimePicker1.Value, dateTimePicker2.Value);
                genelsatis = IadeFiyat.GetNETTOPBySMREFOZELKOD(SMREF,
                    Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), true),
                    dateTimePicker1.Value, dateTimePicker2.Value);

                hizmetgenel = IadeHizmet.GetNETTOPBySMREFOZELKOD(SMREF,
                Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), true),
                    dateTimePicker1.Value, dateTimePicker2.Value);
            }

            if (urunsatis == 0)
            {
                frmINTERNETiadelerdetayhizmet frm = new frmINTERNETiadelerdetayhizmet(
                    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clpkIadeDetayID"].Value),
                    GMREF, SMREF, Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), true),
                    0,
                    dateTimePicker1.Value, dateTimePicker2.Value, urunsatis, genelsatis, 0, hizmetgenel, 0, 0, 0);
                frm.ShowDialog();
            }
            else
            {
                int miktar = IadeFiyatAdet.GetMiktarByIadeDetayID(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clpkIadeDetayID"].Value));
                double iadetoplam = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells["clmnFiyat"].Value) * miktar;

                urunsatis = urunsatis - oncekiiadetoplam + iadetoplam; // önceki iade toplamın içinde bu iadenin toplamı da geliyor o yüzden tekrar ekledik

                double yuzde = (100 * urunsatis) / genelsatis;

                double hizmetyuzdeli = (hizmetgenel / 100) * yuzde;

                //// adetli hesaplama
                //double hizmetbirim = urunsatisadet > 0 ? hizmetyuzdeli / urunsatisadet : 0;
                //double hizmettop = hizmetbirim * Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintMiktar"].Value);

                // fiyatli hesaplama
                double hizmetbirim = hizmetyuzdeli / (urunsatis / iadetoplam);
                double hizmettop = hizmetbirim;



                frmINTERNETiadelerdetayhizmet frm = new frmINTERNETiadelerdetayhizmet(
                    Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clpkIadeDetayID"].Value),
                    GMREF, SMREF, Urunler.GetProductOzelKod(Convert.ToInt32(dataGridView1.Rows[rowindex].Cells["clintUrunID"].Value), true),
                    Convert.ToDecimal(hizmettop),
                    dateTimePicker1.Value, dateTimePicker2.Value, urunsatis, genelsatis, yuzde, hizmetgenel, hizmetyuzdeli, hizmetbirim, hizmettop);
                frm.ShowDialog();
            }

            GetIadelerDetay();
            dataGridView1.Rows[rowindex].Selected = true;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            if (dataGridView1.Rows.Count > 1000)
                if (MessageBox.Show("Satır sayısı çok fazla, bu işlem uzun sürebilir. Yinede devam etmek istiyor musunuz?", "Satır Sayısı Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    return;

            if (Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp"))
                Directory.Delete(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp", true);
            Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp");

            //dataGridView1.Sort(dataGridView1.Columns["clpkIadeDetayID"], ListSortDirection.Ascending);

            string nereden = string.Empty;
            if (Nereden == 0)
                nereden = "Tümü";
            else if (Nereden == 1)
                nereden = "Fiyatlandırılmamış";
            else if (Nereden == 2)
                nereden = "Fiyatlandırılmış";
            else if (Nereden == 3)
                nereden = "Sevk Bekleyen";
            else if (Nereden == 4)
                nereden = "İade Girilen";
            else if (Nereden == 5)
                nereden = "İade Kabul";
            else if (Nereden == 6)
                nereden = "Sat.Op.";
            else if (Nereden == 7)
                nereden = "S.T.";
            else if (Nereden == 8)
                nereden = "C/H";
            else if (Nereden == 9)
                nereden = "Son";
            else if (Nereden == 10)
                nereden = "Reddedilenler";
            else if (Nereden == 11)
                nereden = "Değişimler";
            else if (Nereden == 12)
                nereden = "(Önemsizler)";
            else if (Nereden == 13)
                nereden = "Yeni";

            string musteri = CariHesaplar.GetMUSTERIbySMREF(SMREF);
            musteri += CariHesaplar.AnaSubeMi(CariHesaplar.GetGMREFBySMREF(SMREF)) ? "<br /><span style='color: #FFFFFF'>Müşteri: </span>" + CariHesaplar.GetSUBEbySMREF(SMREF) : "";
            musteri += "<br /><span style='color: #D00000'>Müşteri Kodu: </span>" + CariHesaplar.GetGMREFBySMREF(SMREF).ToString() + 
                "<br /><span style='color: #D00000'>Şube Kodu: </span>" + SMREF.ToString() + 
                "<br /><span style='color: #D00000'>Adres: </span>" + CariHesaplar.GetADRESbySMREF(SMREF) + 
                "<br /><span style='color: #D00000'>İlgili: </span>" + CariHesaplar.GetILGILIbySMREF(SMREF) + 
                "<br /><span style='color: #D00000'>Vergi No: </span>" + CariHesaplar.GetVRGNObySMREF(SMREF);

            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);

            string html = "<html><head><title>Sultanlar UI : Iade Detay Satırları</title></head><body>";

            html += "<table cellspacing='0' cellpadding='0' style='font-family: Verdana; font-size: 11px'><tr><td style='padding-top: 10px; padding-bottom: 15px; padding-left: 3px; width: 540px'><b><span style='color: #D00000'>Müşteri:</span> " + 
                musteri + "</b></td><td style='padding-top: 10px; padding-bottom: 15px; width: 160px;' align='left'><b><span style='color: #D00000'>SAP No:</span> " +
                IadelerQ.GetQuantumNo(IadeID) + "<br><span style='color: #D00000'>İade No:</span> " + IadeID.ToString() + "</b></td></tr></table>";

            string iadesahibi = SatisTemsilcileri.GetSATTEMBySMREF(iade.SMREF) == "" ? "<i>-Bağlı kimse yok-</i>" : SatisTemsilcileri.GetSATTEMBySMREF(iade.SMREF);

            html += "<table cellpadding='3' cellspacing='0' style='font-family: Verdana; font-size: 11px'><tr>" +
                "<td align='left' style='width: 320px; padding-top: 0px;'><b><span style='color: #D00000'>İade Sahibi:</span> " + iadesahibi + "</b></td>" +
                "<td align='center' style='width: 100px; padding-top: 0px;'></td>" +
                "<td align='center' style='width: 40px; padding-top: 0px;'></td>" +
                "<td align='center' style='width: 100px; padding-top: 0px;'></td>" +
                "<td align='center' style='width: 40px; padding-top: 0px;'></td>" +
                "<td align='center' valign='bottom' style='width: 100px; color: #D00000; padding-top: 0px;'><b>Tarih</b></td></tr>";

            html += "<tr>" +
                "<td align='left' style='width: 320px'><b><span style='color: #D00000'>İadeyi Giren:</span> " + iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0].ToUpper() + "</b></td>" +
                "<td align='center' style='width: 100px'></td>" +
                "<td align='center' style='width: 40px'></td>" +
                "<td align='center' style='width: 100px'></td>" +
                "<td align='center' style='width: 40px'></td>" +
                "<td align='center' valign='top' style='width: 100px'><b>" + iade.dtOnaylamaTarihi.ToShortDateString() + "</b></td></tr>";

            string iadeyiveren = CariHesapEk.GetIadeIlgiliBySMREF(iade.SMREF) == string.Empty ? "<i>-İlgili kayıtlı değil-</i>" : CariHesapEk.GetIadeIlgiliBySMREF(iade.SMREF);

            html += "<tr>" +
                "<td align='left' style='width: 320px; padding-bottom: 10px'><b><span style='color: #D00000'>İadeyi Veren:</span> " + iadeyiveren + "</b></td>" +
                "<td align='center' style='width: 100px; padding-bottom: 10px'></td>" +
                "<td align='center' style='width: 40px; padding-bottom: 10px'></td>" +
                "<td align='center' style='width: 100px; padding-bottom: 10px'></td>" +
                "<td align='center' style='width: 40px; padding-bottom: 10px'></td>" +
                "<td align='center' valign='top' style='width: 100px; padding-bottom: 10px'></td></tr>";

            if (Nereden == 3)
            {
                html += "<tr>" +
                    "<td colspan='6' align='center' style='width: 700px; padding-bottom: 10px'><b><span style='color: #000000; font-size: 20px'>İADE ÜRÜN ALIM FORMU</span></b></td></tr>";
            }

            html += "<tr style='color: #D00000; text-decoration: underline;'>" +
                "<td align='center' style='width: 320px'>Ürün</td>" +
                "<td align='center' style='width: 100px'>Barkod</td>" +
                "<td align='center' style='width: 40px'>Adet</td>" +
                "<td align='center' style='width: 100px'>Net B.F.</td>" +
                "<td align='center' style='width: 40px'>Kdv</td>" +
                "<td align='center' style='width: 100px'>Net Top.</td></tr>";

            double toplamnet = 0;
            double toplamnetkdv = 0;
            double birkdv = 0;
            double sekizkdv = 0;
            double onsekizkdv = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double kdv = Urunler.GetProductKDV(Convert.ToInt32(dataGridView1.Rows[i].Cells["clintUrunID"].Value), true);
                double net = 0;
                double tutar = 0;
                int miktar = Convert.ToInt32(dataGridView1.Rows[i].Cells["clintMiktar"].Value);
                if (dataGridView1.Rows[i].Cells["clmnTutar"].Value != DBNull.Value)
                {
                    net = Convert.ToDouble(((Convert.ToDouble(dataGridView1.Rows[i].Cells["clmnTutar"].Value) * 100) / (100 + kdv)).ToString("N2"));
                    tutar = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmnTutar"].Value);
                    toplamnetkdv += tutar * miktar;
                }

                if (kdv == 1)
                    birkdv += (net * miktar) / 100;
                if (kdv == 8)
                    sekizkdv += ((net * miktar)  / 100) * kdv;
                if (kdv == 18)
                    onsekizkdv += ((net * miktar) / 100) * kdv;

                toplamnet += net * miktar;

                html += "<tr style='height: 36px'>" +
                    "<td align='left' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrUrunAdi"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clBARKOD"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clintMiktar"].Value.ToString() + "</td>" +
                    "<td align='right' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + net.ToString("C2") + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + kdv.ToString() + "</td>" +
                    "<td align='right' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC; border-right: 1px solid #CCCCCC'>" + (net * Convert.ToInt32(dataGridView1.Rows[i].Cells["clintMiktar"].Value)).ToString("C2") + "</td></tr>";
            }

            html += "<tr><td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC; padding-top: 10px'><img src='../spacer.gif' /></td>" +
                "<td align='right' style='border-top: 1px solid #CCCCCC; padding-top: 10px'><b><span style='color: #D00000'>Toplam:</span></b></td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC; padding-top: 10px'><img src='../spacer.gif' /></td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC; padding-top: 10px'><img src='../spacer.gif' /></td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC; padding-top: 10px'><img src='../spacer.gif' /></td>" +
                "<td align='right' style='border-top: 1px solid #CCCCCC; padding-top: 10px'>" + toplamnet.ToString("C2") + "</td></tr>";
            html += "<tr><td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'><b><span style='color: #D00000'>%1 KDV T.:</span></b></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'>" + birkdv.ToString("C2") + "</td></tr>";
            html += "<tr><td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'><b><span style='color: #D00000'>%8 KDV T.:</span></b></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'>" + sekizkdv.ToString("C2") + "</td></tr>";
            html += "<tr><td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'><b><span style='color: #D00000'>%18 KDV T.:</span></b></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'>" + onsekizkdv.ToString("C2") + "</td></tr>";
            html += "<tr><td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'><b><span style='color: #D00000'>Net+KDV T.:</span></b></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='center' style='color: #FFFFFF; padding-top: 10px'></td>" +
                "<td align='right' style='padding-top: 10px'>" + toplamnetkdv.ToString("C2") + "</td></tr>";
            html += "<tr style='height: 36px'>" +
                "<td align='left' style='width: 320px;'><b><span style='color: #D00000'>Açıklama:</span> " + iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[1] + "</b></td>" +
                "<td align='center' style='width: 100px;'></td>" +
                "<td align='center' style='width: 40px;'></td>" +
                "<td align='center' style='width: 100px;'></td>" +
                "<td align='center' style='width: 40px;'></td>" +
                "<td align='center' style='width: 100px;'></td></tr>";
            html += "<tr style='font-size: 9px; font-style: italic'>" +
                "<td align='left' style='width: 320px;'></td>" +
                "<td align='center' style='width: 100px;'><img src='" + IadeID.ToString() + "barkod.png' /></td>" +
                "<td align='center' style='width: 40px;'></td>" +
                "<td align='center' style='width: 100px;'></td>" +
                "<td align='center' style='width: 40px;'></td>" +
                "<td align='center' style='width: 100px;'></td></tr>";
            html += "<tr style='font-size: 9px; font-style: italic'>" +
                "<td align='left' style='width: 320px; color: Gray'><b>" + DateTime.Now.ToString() + " " + frmAna.KAdi.ToUpper() + " " + "<br>-" + nereden + "-</b></td>" +
                "<td align='center' style='width: 100px;'></td>" +
                "<td align='center' style='width: 40px;'></td>" +
                "<td align='center' style='width: 100px;'></td>" +
                "<td align='center' style='width: 40px;'></td>" +
                "<td align='center' style='width: 100px;'></td></tr>";
            html += "</table></body></html>";

            System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp\\sultanlar-iadesatirlar.htm", true, Encoding.Unicode);
            sw.Write(html);
            sw.Close();
            sw.Dispose();

            BarkodOlustur(IadeID.ToString(), Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp", IadeID.ToString());

            frmYazdir frm = new frmYazdir(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp\\sultanlar-iadesatirlar.htm");
            frm.MaximumSize = new System.Drawing.Size(720, 500);
            frm.Size = new System.Drawing.Size(720, 500);
            frm.MinimumSize = new System.Drawing.Size(720, 500);
            frm.webBrowser1.Width = 700;
            frm.ShowDialog();
            File.Delete(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp\\sultanlar-iadesatirlar.htm");
            File.Delete(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp\\" + IadeID.ToString() + "barkod.png");

            //if (frmAna.KAdi.ToUpper() == "LK07" || frmAna.KAdi.ToUpper() == "LK06" || frmAna.KAdi.ToUpper() == "LK17" || 
            //    frmAna.KAdi.ToUpper() == "LK12" || frmAna.KAdi.ToUpper() == "LK02" || frmAna.KAdi.ToUpper() == "FT09")
            //{
            //    if (MessageBox.Show("Bu iade yazdırıldı olarak işaretlensin mi? (İşaretlendiğinde sevk bilgisi şoför ve muavin ismi olmadan otomatik girilecektir)", "Yazdırılma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        Iadeler.DoInsertEk(IadeID);
            //        //Iadeler.DoInsertSevkBilgisi(IadeID, "", "", DateTime.Now);
            //    }
            //}

            IadeHareketleri.DoInsert(iade.pkIadeID, 10, frmAna.KAdi.ToUpper(), ""); // yazdırıldı
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnIadeFiyatlandir.PerformClick();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 55;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 12;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 8;

                ((Microsoft.Office.Interop.Excel.Range)ws.Rows[1, Type.Missing]).Font.Bold = true;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                ws.Cells[1, 1] = "İade D.No";
                ws.Cells[1, 2] = "Kullanımda";
                ws.Cells[1, 3] = "Ürün No";
                ws.Cells[1, 4] = "Ürün";
                ws.Cells[1, 5] = "Barkod";
                ws.Cells[1, 6] = "Adet";
                ws.Cells[1, 7] = "İade B.Fiyat";
                ws.Cells[1, 8] = "KDV";

                this.Enabled = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ws.Cells[i + 2, 1] = dataGridView1.Rows[i].Cells["clpkIadeDetayID"].Value.ToString();
                    ws.Cells[i + 2, 2] = dataGridView1.Rows[i].Cells["clblKullanimda"].Value.ToString();
                    ws.Cells[i + 2, 3] = dataGridView1.Rows[i].Cells["clintUrunID"].Value.ToString();
                    ws.Cells[i + 2, 4] = dataGridView1.Rows[i].Cells["clstrUrunAdi"].Value.ToString();
                    ws.Cells[i + 2, 5] = dataGridView1.Rows[i].Cells["clBARKOD"].Value.ToString();
                    ws.Cells[i + 2, 6] = dataGridView1.Rows[i].Cells["clintMiktar"].Value.ToString();
                    ws.Cells[i + 2, 7] = Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmnFiyat"].Value).ToString("C2");
                    ws.Cells[i + 2, 8] = Urunler.GetProductKDV(Convert.ToInt32(dataGridView1.Rows[i].Cells["clintUrunID"].Value.ToString())).ToString();
                }
                this.Enabled = true;

                ws.SaveAs(sfd.FileName);
                wb.Close();
                ap.Quit();
            }
        }

        private void btnAciklamaGuncelle_Click(object sender, EventArgs e)
        {
            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);
            string[] aciklamalar = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            iade.strAciklama = string.Empty;
            for (int i = 0; i < aciklamalar.Length; i++)
            {
                if (i == 1)
                    aciklamalar[i] = txtAciklama2.Text;
                iade.strAciklama += aciklamalar[i] + ";;;";
            }
            iade.strAciklama = iade.strAciklama.Substring(0, iade.strAciklama.Length - 3);
            iade.DoUpdate();
            MessageBox.Show("İade açıklaması güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
