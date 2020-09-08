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
using System.Threading;
using DgvFilterPopup;
using System.IO;
using Microsoft.Win32;

namespace Sultanlar.UI
{
    public partial class frmINTERNETiadeler : Form
    {
        public frmINTERNETiadeler()
        {
            InitializeComponent();
        }

        DataTable dt;
        DgvFilterManager dgvfm;
        public static int SubeDegistirmeSMREF;
        public static string SatisOperasyon;
        public static bool iadegirmetamamlandi;

        private void frmINTERNETiadeler_Load(object sender, EventArgs e)
        {
            SubeDegistirmeSMREF = 0;
            SatisOperasyon = string.Empty;
            iadegirmetamamlandi = false;

            try
            {
                if (Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp"))
                    Directory.Delete(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp", true);
                Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Windows bir hata verdi: " + ex.Message);
            }

            CheckForIllegalCrossThreadCalls = false;

            DoYetkiler();
            Suz();
        }

        private void DoYetkiler()
        {
            if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR")
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = true;
                btnGeriAl.Enabled = true;
                btnFiyatlandirmaIptal.Enabled = true;
                btnDegisim.Enabled = true;
                btnQuantumaYaz.Enabled = true;
                btnSubeDegistir.Enabled = true;
                btnUyeDegistir.Enabled = true;
                btnSayim.Enabled = true;
                btnSatisOperasyon.Enabled = true;
                btnOnemsizeAt.Enabled = true;
                btnKabul.Enabled = true;
                btnKabuldenGeri.Enabled = true;

                btnEposta.Visible = true;
            }
            else if (frmAna.KAdi.ToUpper() == "ST12" || frmAna.KAdi.ToUpper() == "MI05" ||
                frmAna.KAdi.ToUpper() == "FN09" || frmAna.KAdi.ToUpper() == "ST70") // mtorun, gökhan çelik, özlem avcı, sonay köse
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = false;
                btnIadeDuzenle.Enabled = false;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = false;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = false;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = false;
                btnKabuldenGeri.Enabled = false;
            }
            else if (frmAna.KAdi.ToUpper() == "FN03") // tuba usta
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = false;
                btnIadeDuzenle.Enabled = false;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = true;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = false;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = false;
                btnKabuldenGeri.Enabled = false;
            }
            else if (frmAna.KAdi.ToUpper() == "ST16" || frmAna.KAdi.ToUpper() == "MI01") //nilufer kopuz, hediye çetli
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = false;
                rbST.Enabled = false;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = true;
                btnGeriAl.Enabled = true;
                btnFiyatlandirmaIptal.Enabled = true;
                btnDegisim.Enabled = true;
                btnQuantumaYaz.Enabled = true;
                btnSubeDegistir.Enabled = true;
                btnUyeDegistir.Enabled = true;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = true;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = false;
                btnKabuldenGeri.Enabled = false;
            }
            else if (frmAna.KAdi.ToUpper() == "LK21") // ünal yıldırım
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = true;
                btnGeriAl.Enabled = true;
                btnFiyatlandirmaIptal.Enabled = true;
                btnDegisim.Enabled = true;
                btnQuantumaYaz.Enabled = true;
                btnSubeDegistir.Enabled = true;
                btnUyeDegistir.Enabled = true;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = true;
                btnOnemsizeAt.Enabled = true;
                btnKabul.Enabled = true;
                btnKabuldenGeri.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "ST03") // murat kasaroğlu
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = true;
                btnFiyatlandirmaIptal.Enabled = true;
                btnDegisim.Enabled = true;
                btnQuantumaYaz.Enabled = true;
                btnSubeDegistir.Enabled = true;
                btnUyeDegistir.Enabled = true;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = true;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = true;
                btnKabuldenGeri.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "LK07" || frmAna.KAdi.ToUpper() == "LK06" || frmAna.KAdi.ToUpper() == "LK16") // arzu bayram, ertuğrul, olgun kaya
            {
                rbFiyatlandirilmis.Enabled = false;
                rbFiyatlandirilmamis.Enabled = false;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = false;
                rbFaturalananlar.Enabled = false;
                rbReddedilenler.Enabled = false;
                rbDegisimler.Enabled = false;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = false;
                rbST.Enabled = false;
                rbCH.Enabled = false;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = false;
                btnIadeDuzenle.Enabled = false;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = false;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = false;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = true;
                btnKabuldenGeri.Enabled = true;

                rbFiyatlandirilmamis.Checked = false;
                rbFiyatlandirilmisOnaylanmis.Checked = true;
                pnlSevk.Visible = true;
                Suz();
                //GetCariler();
            }
            else if (frmAna.KAdi.ToUpper() == "LK12" || frmAna.KAdi.ToUpper() == "LK02" ||
                frmAna.KAdi.ToUpper() == "LK04" || frmAna.KAdi.ToUpper() == "LK09" || frmAna.KAdi.ToUpper() == "LK17" || 
                /*frmAna.KAdi.ToUpper() == "LK21" ||*/
                frmAna.KAdi.ToUpper() == "ST06" || frmAna.KAdi.ToUpper() == "ST09") // şeyda arslan, alttaki iki tane: tuba polat, zehra akgül
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = false;
                rbDegisimler.Enabled = false;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = false;
                rbST.Enabled = false;
                rbCH.Enabled = false;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = false;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = true;
                btnSatisOperasyon.Enabled = true;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = true;
                btnKabuldenGeri.Enabled = true;

                rbFiyatlandirilmamis.Checked = true;
                rbFiyatlandirilmisOnaylanmis.Checked = true;
                pnlSevk.Visible = true;
                Suz();
                //GetCariler();
            }
            else if (frmAna.KAdi.ToUpper() == "YN08" || frmAna.KAdi.ToUpper() == "YN09") // ahmet fettah, kemal baltaşı
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = false;
                rbST.Enabled = false;
                rbCH.Enabled = false;
                rbSon.Enabled = false;

                btnIadeGir.Enabled = false;
                btnIadeDuzenle.Enabled = false;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = false;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = false;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = false;
                btnKabuldenGeri.Enabled = false;

                rbFiyatlandirilmamis.Checked = false;
                rbFiyatlandirilmisOnaylanmis.Checked = true;
                pnlSevk.Visible = true;
                Suz();
                //GetCariler();
            }
            else if (frmAna.KAdi.ToUpper() == "YN04" || frmAna.KAdi.ToUpper() == "YN02" || frmAna.KAdi.ToUpper() == "ST07" || frmAna.KAdi.ToUpper() == "ST13") // fahrettin kaya, safiye bağdatlı, neslihan demirbaş, gülzade yar
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = true;
                btnFiyatlandirmaIptal.Enabled = true;
                btnDegisim.Enabled = true;
                btnQuantumaYaz.Enabled = true;
                btnSubeDegistir.Enabled = true;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = true;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = true;
                btnKabuldenGeri.Enabled = true;

                rbFiyatlandirilmamis.Checked = false;
                rbFiyatlandirilmisOnaylanmis.Checked = true;
                pnlSevk.Visible = true;
                Suz();
                //GetCariler();
            }
            else if (frmAna.KAdi.ToUpper() == "SUL05") // selçuk tonyalı
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = true;
                btnIadeDuzenle.Enabled = false;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = false;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = false;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = false;
                btnKabuldenGeri.Enabled = false;

                rbFiyatlandirilmamis.Checked = false;
                rbFiyatlandirilmisOnaylanmis.Checked = true;
                pnlSevk.Visible = true;
                Suz();
                //GetCariler();
            }
            else if (frmAna.KAdi.ToUpper() == "ST04") // yücel kavanoz
            {
                rbFiyatlandirilmis.Enabled = true;
                rbFiyatlandirilmamis.Enabled = true;
                rbFiyatlandirilmisOnaylanmis.Enabled = true;
                rbCoptekiler.Enabled = true;
                rbSevkIadeKabulArasi.Enabled = true;
                rbFaturalananlar.Enabled = true;
                rbReddedilenler.Enabled = true;
                rbDegisimler.Enabled = true;
                rbTumu.Enabled = true;
                rbSatOp.Enabled = true;
                rbST.Enabled = true;
                rbCH.Enabled = true;
                rbSon.Enabled = true;

                btnIadeGir.Enabled = false;
                btnIadeDuzenle.Enabled = true;
                btnIadeRed.Enabled = false;
                btnGeriAl.Enabled = false;
                btnFiyatlandirmaIptal.Enabled = false;
                btnDegisim.Enabled = false;
                btnQuantumaYaz.Enabled = false;
                btnSubeDegistir.Enabled = false;
                btnUyeDegistir.Enabled = false;
                btnSayim.Enabled = false;
                btnSatisOperasyon.Enabled = false;
                btnOnemsizeAt.Enabled = false;
                btnKabul.Enabled = false;
                btnKabuldenGeri.Enabled = false;

                rbFiyatlandirilmamis.Checked = false;
                rbFiyatlandirilmisOnaylanmis.Checked = true;
                pnlSevk.Visible = true;
                Suz();
                //GetCariler();
            }

            iadeyiDüzenleToolStripMenuItem.Enabled = btnIadeDuzenle.Enabled;
            iadeyiReddetToolStripMenuItem.Enabled = btnIadeRed.Enabled;
            iadeyiGeriAlToolStripMenuItem.Enabled = btnGeriAl.Enabled;
            tekrarFiyatlandırToolStripMenuItem.Enabled = btnFiyatlandirmaIptal.Enabled;
            değişimToolStripMenuItem.Enabled = btnDegisim.Enabled;
            sevkBilgisiToolStripMenuItem.Enabled = btnSevkBilgisi.Enabled;
            fiyatlandırmayıOnaylaToolStripMenuItem.Enabled = btnQuantumaYaz.Enabled;
            müşteriDeğiştirToolStripMenuItem.Enabled = btnSubeDegistir.Enabled;
            üyeDeğiştirToolStripMenuItem.Enabled = btnUyeDegistir.Enabled;
            sayımToolStripMenuItem.Enabled = btnSayim.Enabled;
            satışOperasyonToolStripMenuItem.Enabled = btnSatisOperasyon.Enabled;
            önemsizeAtToolStripMenuItem.Enabled = btnOnemsizeAt.Enabled;
            iadeKabuleGönderToolStripMenuItem.Enabled = btnKabul.Enabled;
            iadeKabuldenGeriAlToolStripMenuItem.Enabled = btnKabuldenGeri.Enabled;
        }

        private void GetIadeler()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].HeaderText = "";

            int Durum = 0;
            if (rbFiyatlandirilmamis.Checked)
                Durum = 1;
            else if (rbFiyatlandirilmis.Checked)
                Durum = 2;
            else if (rbFiyatlandirilmisOnaylanmis.Checked && rbSevkTumu.Checked)
                Durum = 3;
            else if (rbFiyatlandirilmisOnaylanmis.Checked && rbSevkBilgili.Checked)
                Durum = 4;
            else if (rbFiyatlandirilmisOnaylanmis.Checked && rbSevkBilgisiz.Checked)
                Durum = 5;
            else if (rbSevkGelisBilgili.Checked)
                Durum = 13;
            else if (rbSevkIadeKabulArasi.Checked)
                Durum = 9;
            else if (rbFaturalananlar.Checked && !cbIadeKabulTumu.Checked)
                Durum = 6;
            else if (rbFaturalananlar.Checked && cbIadeKabulTumu.Checked)
                Durum = 11;
            else if (rbSatOp.Checked && !cbIadeKabulTumu.Checked)
                Durum = 6;
            else if (rbSatOp.Checked && cbIadeKabulTumu.Checked)
                Durum = 11;
            else if (rbST.Checked && !cbIadeKabulTumu.Checked)
                Durum = 6;
            else if (rbST.Checked && cbIadeKabulTumu.Checked)
                Durum = 11;
            else if (rbCH.Checked && !cbIadeKabulTumu.Checked)
                Durum = 6;
            else if (rbCH.Checked && cbIadeKabulTumu.Checked)
                Durum = 11;
            else if (rbSon.Checked && !cbIadeKabulTumu.Checked)
                Durum = 6;
            else if (rbSon.Checked && cbIadeKabulTumu.Checked)
                Durum = 11;
            else if (rbReddedilenler.Checked)
                Durum = 7;
            else if (rbDegisimler.Checked)
                Durum = 8;
            else if (rbCoptekiler.Checked)
                Durum = 10;
            else if (rbCoptekiler2.Checked)
                Durum = 12;

            DateTime baslangic = rb2012.Checked ? Convert.ToDateTime("01.01.2012") : rb2013.Checked ? Convert.ToDateTime("01.01.2013") : rb2014.Checked ? Convert.ToDateTime("01.01.2014") : rb2015.Checked ? Convert.ToDateTime("01.01.2015") : rb2016.Checked ? Convert.ToDateTime("01.01.2016") : rb2017.Checked ? Convert.ToDateTime("01.01.2017") : rb2018.Checked ? Convert.ToDateTime("01.01.2018") : Convert.ToDateTime("01.01.2019");

            dt = new DataTable();
            Iadeler.GetObjectsVW(dt, Durum, baslangic, 
                true, cbSatisOperasyonSonIslemYapan.Checked, cbSatisOperasyonSonTarih.Checked,
                cbstrSofor.Checked, cbstrMuavin.Checked, cbdtTarihGidis.Checked, cbFiyatlandirilmisSatirSayisi.Checked, cbSevkBilgisiSayisi.Checked, 
                cbstrSoyad.Checked, cbstrAd.Checked, cbSatirSayisi.Checked, cbVGBLI.Checked, cbIstihbarat.Checked);
        }

        //private void GetCariler()
        //{
        //    cmbCariler.Items.Clear();
        //    cmbCariSubeler.Items.Clear();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        bool eklenebilir = true;
        //        for (int j = 0; j < cmbCariler.Items.Count; j++)
        //        {
        //            if (dt.Rows[i]["MUSTERI"].ToString() == cmbCariler.Items[j].ToString())
        //            {
        //                eklenebilir = false;
        //                break;
        //            }
        //        }
        //        if (eklenebilir)
        //            cmbCariler.Items.Add(dt.Rows[i]["MUSTERI"].ToString());
        //    }
        //}

        //private void GetCariSubeler()
        //{
        //    cmbCariSubeler.Items.Clear();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        bool eklenebilir = true;
        //        if (dt.Rows[i]["SUBE"].ToString().Trim() == string.Empty)
        //        {
        //            eklenebilir = false;
        //        }
        //        else
        //        {
        //            for (int j = 0; j < cmbCariSubeler.Items.Count; j++)
        //            {
        //                if (dt.Rows[i]["SUBE"].ToString() == cmbCariSubeler.Items[j].ToString())
        //                {
        //                    eklenebilir = false;
        //                    break;
        //                }
        //            }
        //        }

        //        if (eklenebilir)
        //            cmbCariSubeler.Items.Add(dt.Rows[i]["SUBE"].ToString());
        //    }
        //}

        private void Suz()
        {
            GetIadeler();

            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.DataSource = dt;
            dgvfm = new DgvFilterManager(dataGridView1);
            
            Kolonlar();

            if (cbRenklendir.Checked)
            {
                Renklendir2();
            }
            else
            {
                lblSatirSayisi2.Visible = false;
                lblSatirSayisi3.Visible = false;
                lblSatirSayisiArkaplan.Visible = false;
            }
        }

        private void Kolonlar()
        {
            dataGridView1.Columns["clSatisOperasyonSonIslemYapan"].Visible = cbSatisOperasyonSonIslemYapan.Checked;
            dataGridView1.Columns["clSatisOperasyonSonTarih"].Visible = cbSatisOperasyonSonTarih.Checked;
            dataGridView1.Columns["clstrSofor"].Visible = cbstrSofor.Checked;
            dataGridView1.Columns["clstrMuavin"].Visible = cbstrMuavin.Checked;
            dataGridView1.Columns["cldtTarihGidis"].Visible = cbdtTarihGidis.Checked;
            dataGridView1.Columns["clSatirSayisi"].Visible = cbFiyatlandirilmisSatirSayisi.Checked;
            dataGridView1.Columns["clSevkBilgisiSayisi"].Visible = cbSevkBilgisiSayisi.Checked;
            dataGridView1.Columns["clstrSoyad"].Visible = cbstrSoyad.Checked;
            dataGridView1.Columns["clstrAd"].Visible = cbstrAd.Checked;
            dataGridView1.Columns["clSatirSayisi"].Visible = cbSatirSayisi.Checked;
            dataGridView1.Columns["clVGBLI"].Visible = cbVGBLI.Checked;
            dataGridView1.Columns["clIstihbarat4"].Visible = cbIstihbarat.Checked;
            dataGridView1.Columns["clIstihbarat5"].Visible = cbIstihbarat.Checked;
            dataGridView1.Columns["clIstihbarat6"].Visible = cbIstihbarat.Checked;

            dataGridView1.Columns["clSecim"].Visible = cbSecim.Checked;
            dataGridView1.Columns["clBasilmaSayisi"].Visible = cbBasilmaSayisi.Checked;
            dataGridView1.Columns["clIADEMERKEZDENGIRILDI"].Visible = cbIADEMERKEZDENGIRILDI.Checked;

            dgvfm["clSatisOperasyonSonAciklama"].Enabled = false;

            if (rbFaturalananlar.Checked)
            {
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpression = "..xxx..";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).TextBoxValue.Text = "İade  Kabul";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).Active = true;
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpressionBuild();
            }
            else if (rbSatOp.Checked)
            {
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpression = "..xxx..";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).TextBoxValue.Text = "Sat.Op. - ";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).Active = true;
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpressionBuild();
            }
            else if (rbST.Checked)
            {
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpression = "..xxx..";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).TextBoxValue.Text = "S.T. - ";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).Active = true;
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpressionBuild();
            }
            else if (rbCH.Checked)
            {
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpression = "..xxx..";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).TextBoxValue.Text = "C/H - ";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).Active = true;
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpressionBuild();
            }
            else if (rbSon.Checked)
            {
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpression = "..xxx..";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).TextBoxValue.Text = "Son - ";
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).Active = true;
                ((DgvTextBoxColumnFilter)dgvfm["clSatisOperasyonSonAciklama"]).FilterExpressionBuild();
            }

            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();

            KolonlarIsimler();
        }

        private void KolonlarIsimler()
        {
            dataGridView1.Columns["clSecim"].HeaderText = "Seçim";
            dataGridView1.Columns["clSTATU"].HeaderText = "Statü";
            dataGridView1.Columns["clpkIadeID"].HeaderText = "Iade No";
            dataGridView1.Columns["clintMusteriID"].HeaderText = "Musteri No";
            dataGridView1.Columns["clstrAd"].HeaderText = "Üye Ad Soyad";
            dataGridView1.Columns["clstrSoyad"].HeaderText = "Satış Temsilcisi";
            dataGridView1.Columns["clSMREF"].HeaderText = "SMREF";
            dataGridView1.Columns["clYTKKOD"].HeaderText = "Müş.Tipi";
            dataGridView1.Columns["clMUSKOD"].HeaderText = "Müşteri Kod";
            dataGridView1.Columns["clMUSTERI"].HeaderText = "Cari Hesap";
            dataGridView1.Columns["clSUBKOD"].HeaderText = "Şube Kod";
            dataGridView1.Columns["clSUBE"].HeaderText = "Cari Şube";
            dataGridView1.Columns["cldtOlusmaTarihi"].HeaderText = "Oluşturma Tarihi";
            dataGridView1.Columns["cldtOnaylamaTarihi"].HeaderText = "Onaylama Tarihi";
            dataGridView1.Columns["clblAktarilmis"].HeaderText = "Aktarılmış";
            dataGridView1.Columns["clmnToplamTutar"].HeaderText = "Toplam Tutar";
            dataGridView1.Columns["clSatirSayisi"].HeaderText = "Satır";
            dataGridView1.Columns["clVGBLI"].HeaderText = "VGB";
            dataGridView1.Columns["clstrAciklama2"].HeaderText = "Açıklama";
            dataGridView1.Columns["clIADEMERKEZDENGIRILDI"].HeaderText = "M";
            dataGridView1.Columns["clstrAciklama3"].HeaderText = "Açıklama 3";
            dataGridView1.Columns["clQUANTUMNO"].HeaderText = "SAP Sip.No";
            dataGridView1.Columns["clFATNO"].HeaderText = "Fat.No";
            dataGridView1.Columns["clFATTAR"].HeaderText = "Fat.Tarih";
            dataGridView1.Columns["clblSayimYapildi"].HeaderText = "Sayım";
            dataGridView1.Columns["cldtSayimTarihi"].HeaderText = "Sayım Tarihi";
            dataGridView1.Columns["clSatisOperasyonSonAciklama"].HeaderText = "Op.İşlem Açıklama";
            dataGridView1.Columns["clSatisOperasyonSonIslemYapan"].HeaderText = "Op.İşlem Kullanıcı";
            dataGridView1.Columns["clSatisOperasyonSonTarih"].HeaderText = "Op.İşlem Tarihi";
            dataGridView1.Columns["clBasilmaSayisi"].HeaderText = "Yazdırılma Sayısı";
            dataGridView1.Columns["clFiyatlandirilmisSatirSayisi"].HeaderText = "Fiyatlandırılmış Satır Sayısı";
            dataGridView1.Columns["clSevkBilgisiSayisi"].HeaderText = "Sevk Bilgisi Satır Sayısı";
            dataGridView1.Columns["clIstihbarat4"].HeaderText = "İstihbarat-4 (İ.ŞEY)";
            dataGridView1.Columns["clIstihbarat5"].HeaderText = "İstihbarat-5 (İ.LOJ)";
            dataGridView1.Columns["clIstihbarat6"].HeaderText = "İstihbarat-6 (İ.MK)";
            dataGridView1.Columns["clstrSofor"].HeaderText = "Şoför";
            dataGridView1.Columns["clstrMuavin"].HeaderText = "Muavin";
            dataGridView1.Columns["cldtTarihGidis"].HeaderText = "Veriliş Tarihi";
        }

        //private void Suz2()
        //{
        //    GetIadeler();

        //    ArrayList silinecekler = new ArrayList();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (rbTumu.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString())
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //        else if (rbFiyatlandirilmamis.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString()) ||
        //                Convert.ToDecimal(dt.Rows[i]["mnToplamTutar"]) != 0
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //        else if (rbFiyatlandirilmis.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString()) ||
        //                Convert.ToDecimal(dt.Rows[i]["mnToplamTutar"]) == 0 || !Convert.ToBoolean(dt.Rows[i]["blAktarilmis"])
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //        else if (rbFiyatlandirilmisOnaylanmis.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString()) ||
        //                Convert.ToDecimal(dt.Rows[i]["mnToplamTutar"]) <= 0 || Convert.ToBoolean(dt.Rows[i]["blAktarilmis"]) ||
        //                dt.Rows[i]["FATTAR"] != DBNull.Value
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //        else if (rbReddedilenler.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString()) ||
        //                Convert.ToDecimal(dt.Rows[i]["mnToplamTutar"]) != -1
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //        else if (rbDegisimler.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString()) ||
        //                Convert.ToDecimal(dt.Rows[i]["mnToplamTutar"]) != -2
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //        else if (rbFaturalananlar.Checked)
        //        {
        //            if (
        //                (cmbCariler.SelectedIndex > -1 && dt.Rows[i]["MUSTERI"].ToString() != cmbCariler.SelectedItem.ToString()) ||
        //                (cmbCariSubeler.SelectedIndex > -1 && dt.Rows[i]["SUBE"].ToString() != cmbCariSubeler.SelectedItem.ToString()) ||
        //                dt.Rows[i]["FATTAR"] == DBNull.Value || Convert.ToDecimal(dt.Rows[i]["mnToplamTutar"]) == 0
        //               )
        //                silinecekler.Add(dt.Rows[i]);
        //        }
        //    }
        //    for (int i = 0; i < silinecekler.Count; i++)
        //        dt.Rows.Remove((DataRow)silinecekler[i]);

        //    lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();

        //    dataGridView1.DataSource = dt;
        //    dgvfm = new DgvFilterManager(dataGridView1);

        //    Renklendir();
        //}

        private void Renklendir()
        {
            if (rbFiyatlandirilmamis.Checked)
            {
                #region ilk yontem, sarı ve kırmızı bazen karışıyor incelemedim
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    DataTable dt1 = new DataTable();
                //    IadelerDetay.GetObjectsByIadeID(dt1, Convert.ToInt32(row.Cells["clpkIadeID"].Value));

                //    bool hepsidolu = true;
                //    bool enazbiridolu = false;
                //    for (int i = 0; i < dt1.Rows.Count; i++)
                //    {
                //        if (Convert.ToInt32(dt1.Rows[i]["mnFiyat"]) == 0)
                //            hepsidolu = false;
                //        else
                //            enazbiridolu = true;
                //    }

                //    if (hepsidolu)
                //        row.DefaultCellStyle.BackColor = Color.Red;
                //    else if (enazbiridolu)
                //        row.DefaultCellStyle.BackColor = Color.Yellow;
                //}
                #endregion

                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    DataTable dt1 = new DataTable();
                    IadelerDetay.GetObjectsByIadeID_Fiy(dt1, Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value));

                    bool hepsidolu = true;
                    bool enazbiridolu = false;
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt1.Rows[i]["mnToplam"] == DBNull.Value)
                            hepsidolu = false;
                        else
                            enazbiridolu = true;
                    }

                    if (hepsidolu)
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                    else if (enazbiridolu)
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            else if (rbFiyatlandirilmisOnaylanmis.Checked)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    DataTable dt1 = new DataTable();
                    Iadeler.GetSevkBilgileri(dt1, Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value));
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = dt1.Rows.Count > 0 ? Color.DarkBlue : Color.White;
                    dataGridView1.Rows[j].DefaultCellStyle.ForeColor = dt1.Rows.Count > 0 ? Color.White : Color.Black;
                }
            }
        }

        private void Renklendir2()
        {
            lblSatirSayisi2.Visible = rbFiyatlandirilmamis.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler.Checked;
            lblSatirSayisi3.Visible = rbFiyatlandirilmamis.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler.Checked;
            lblSatirSayisiArkaplan.Visible = rbFiyatlandirilmamis.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler.Checked;
            if (rbFiyatlandirilmamis.Checked)
            {
                lblSatirSayisi2.ForeColor = Color.FromArgb(255, 225, 117);
                lblSatirSayisi3.ForeColor = Color.FromArgb(155, 226, 255);
            }
            else if (rbFiyatlandirilmisOnaylanmis.Checked)
            {
                lblSatirSayisi2.ForeColor = Color.White;
                lblSatirSayisi3.ForeColor = Color.LightBlue;
            }

            lblSatirSayisi2.Text = "0";
            lblSatirSayisi3.Text = "0";

            if (rbFiyatlandirilmamis.Checked)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if ((int)dataGridView1.Rows[j].Cells["clFiyatlandirilmisSatirSayisi"].Value == 0)
                    {
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    }
                    else if ((int)dataGridView1.Rows[j].Cells["clFiyatlandirilmisSatirSayisi"].Value == (int)dataGridView1.Rows[j].Cells["clSatirSayisi"].Value)
                    {
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 225, 117);
                        lblSatirSayisi2.Text = (Convert.ToInt32(lblSatirSayisi2.Text) + 1).ToString();
                    }
                    else if ((int)dataGridView1.Rows[j].Cells["clFiyatlandirilmisSatirSayisi"].Value < (int)dataGridView1.Rows[j].Cells["clSatirSayisi"].Value)
                    {
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(155, 226, 255);
                        lblSatirSayisi3.Text = (Convert.ToInt32(lblSatirSayisi3.Text) + 1).ToString();
                    }
                }
            }
            else if (rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler.Checked)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if ((int)dataGridView1.Rows[j].Cells["clSevkBilgisiSayisi"].Value > 0)
                    {
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.DarkBlue;
                        dataGridView1.Rows[j].DefaultCellStyle.ForeColor = Color.White;

                        lblSatirSayisi3.Text = (Convert.ToInt32(lblSatirSayisi3.Text) + 1).ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[j].DefaultCellStyle.ForeColor = Color.Black;

                        lblSatirSayisi2.Text = (Convert.ToInt32(lblSatirSayisi2.Text) + 1).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// nereden: 0 tümü, 1 fiyatlandırılmamış, 2 fiyatlandırılmış, 3 sevk bekleyen, 4 iade girilen, 5 iade kabul, 6 sat.op, 7 s.t., 8 c/h, 9 son, 10 red, 11 değişim, 12 önemsiz
        /// </summary>
        private int HangiHavuzda()
        {
            if (rbTumu.Checked)
                return 0;
            else if (rbFiyatlandirilmamis.Checked)
                return 1;
            else if (rbFiyatlandirilmis.Checked)
                return 2;
            else if (rbFiyatlandirilmisOnaylanmis.Checked)
                return 3;
            else if (rbSevkIadeKabulArasi.Checked)
                return 4;
            else if (rbFaturalananlar.Checked)
                return 5;
            else if (rbSatOp.Checked)
                return 6;
            else if (rbST.Checked)
                return 7;
            else if (rbCH.Checked)
                return 8;
            else if (rbSon.Checked)
                return 9;
            else if (rbReddedilenler.Checked)
                return 10;
            else if (rbDegisimler.Checked)
                return 11;
            else if (rbCoptekiler.Checked)
                return 12;

            return 0;
        }

        //private void SagTusMenu()
        //{
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Sultanlar", true);

        //    if (key.GetValue("IadeSagTusMenu").ToString() == "evet")
        //        dataGridView1.ContextMenuStrip = contextMenuStrip1;
        //    else if (key.GetValue("IadeSagTusMenu").ToString() == "hayir")
        //        dataGridView1.ContextMenuStrip = null;
        //}

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

        private void IadeFiyatSifirla(int IadeID)
        {
            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long IadeDetayID = Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]);

                IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(IadeDetayID);
                idf.DoDelete();

                IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(IadeDetayID);

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

                int GMREF = CariHesaplar.GetGMREFBySMREF(Iadeler.GetObjectsByIadeID(id.intIadeID).SMREF);
                string OZELKOD = Urunler.GetProductOzelKod(id.intUrunID, true);
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
        }

        public static string QuantumaYaz(int IadeID, short IsyeriNo, short AmbarNo, out string hata)
        {
            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);
            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID);

            int SLSREF = CariHesaplar.GetSLSREFBySMREF(iade.SMREF);
            Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(iade.intMusteriID);
            if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
                SLSREF = siparisiolusturanmusteri1.intSLSREF;

            string[] aciklamalar = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            string Aciklama2 = aciklamalar[1];
            string Aciklama3 = aciklamalar[2];

            string[] depoveneden = Iadeler.GetSapDepo(iade.pkIadeID);

            SAPsendorderC.ZwebSendSalesOrderService clOrder = new SAPsendorderC.ZwebSendSalesOrderService();
            clOrder.Credentials = new System.Net.NetworkCredential("MISTIF", "123456q");
            SAPsendorderC.Zwebs010 header = new SAPsendorderC.Zwebs010();

            header.Ctype = "IADE";
            header.Ketdat = DateTime.Now.Year.ToString() + (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString());
            header.Kunwe = "000" + iade.SMREF.ToString();
            header.Pltyp = "02";
            header.Vbeln = "";
            header.Xblnr = iade.pkIadeID.ToString(); //WebGenel.DoUpdateSayac().ToString()
            header.Stext = Aciklama2 + " " + Aciklama3;
            header.Zterm = "";
            header.Augru = Iadeler.GetSapDepo(iade.pkIadeID)[0];

            if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "VE")
            {
                header.Pernr = SLSREF.ToString();
                header.PernrVw = "1530";
            }
            else if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "VW")
            {
                header.Pernr = "1529";
                header.PernrVw = SLSREF.ToString();
            }
            else if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "ZM") // gerek olmayabilir diye kaldırdım çünkü satkod1 order by ile getirince önce ve geliyor
            {
                //header.Pernr = SLSREF.ToString();
                //header.PernrVw = "1530";
                hata = "Sat.Tem. olarak yetkili çalışan seçilemez. Sat.Tem. alanını değiştirerek tekrar deneyiniz.";
                return string.Empty;
            }
            else
            {
                hata = "Satış temsilcisi gözükmüyor.";
                return string.Empty;
            }

            SAPsendorderC.Zwebs011[] line = new SAPsendorderC.Zwebs011[dt.Rows.Count];
            for (int i = 0; i < line.Length; i++)
            {
                double fiyat = Convert.ToDouble(dt.Rows[i]["mnFiyat"]);
                double kdv = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]));

                line[i] = new SAPsendorderC.Zwebs011();
                line[i].Xblnr = iade.pkIadeID.ToString();
                line[i].Itmid = (i + 1).ToString();
                line[i].Matnr = "00000000000" + dt.Rows[i]["intUrunID"].ToString();
                line[i].Meins = Urunler.GetProductBirimRef(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                line[i].MengeSpecified = true;
                line[i].Menge = Convert.ToDecimal(dt.Rows[i]["intMiktar"]);
                line[i].Satir = "00";

                line[i].FiyatSpecified = true;
                line[i].Fiyat = 0; //Convert.ToDecimal((fiyat * 100) / (100 + kdv))
                line[i].Isk1Specified = true;
                line[i].Isk1 = 0;
                line[i].Isk2Specified = true;
                line[i].Isk2 = 0;
                line[i].Isk3Specified = true;
                line[i].Isk3 = 0;
                line[i].Isk4Specified = true;
                line[i].Isk4 = 0;
                line[i].Isk5Specified = true;
                line[i].Isk5 = 0;
                line[i].Isk6Specified = true;
                line[i].Isk6 = 0;
                line[i].Isk7Specified = true;
                line[i].Isk7 = 0;
                line[i].Isk8Specified = true;
                line[i].Isk8 = 0;
                line[i].Isk9Specified = true;
                line[i].Isk9 = 0;
                line[i].Isk10Specified = true;
                line[i].Isk10 = 0;

                line[i].Lgort = Iadeler.GetSapDepo(iade.pkIadeID)[1];
                line[i].Werks = Iadeler.GetSapDepo(iade.pkIadeID)[2];
                line[i].Charg = Iadeler.GetSapDepo(iade.pkIadeID)[3];
            }

            string error = string.Empty;
            string donen = string.Empty;

            SAPsendorderC.Bapiret2[] donen1 = null;
            try { donen1 = clOrder.ZwebSendSalesOrder(header, line, out donen); }
            catch (Exception ex) { error = ex.Message; }

            if (donen1 != null)
            {
                for (int i = 0; i < donen1.Length; i++)
                    error += donen1[i].Message + ", ";
            }

            hata = error;

            if (donen != string.Empty)
            {
                IadelerQ.WriteQuantumNo(iade.pkIadeID, donen, "0");

                #region mesajlar
                //iade.strAciklama += ";;;" + siparisno;
                //iade.DoUpdate();

                // lojistik:
                //AlinanMesajlar am = new AlinanMesajlar(
                //    iade.intMusteriID,
                //    1,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am.DoInsert();

                // iade kabul:
                //AlinanMesajlar am1 = new AlinanMesajlar(
                //    iade.intMusteriID,
                //    58,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am1.DoInsert();

                // iade fiyatlandırma:
                //AlinanMesajlar am2 = new AlinanMesajlar(
                //    iade.intMusteriID,
                //    59,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am2.DoInsert();

                // satış:
                //AlinanMesajlar am3 = new AlinanMesajlar(
                //    iade.intMusteriID,
                //    10,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am3.DoInsert();
                #endregion
            }
            else
            {
                Hatalar.DoInsert("İade SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + error, "frmINTERNETiadeler Quantumayaz()");
            }

            QuantumWebServisLog.DoInsert(donen != string.Empty, iade.pkIadeID, donen, 0, frmAna.KAdi, "IADE");

            return donen;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnFiyatlandir.PerformClick();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Suz();
            rbSevkTumu.Checked = true;
        }

        private void btnFiyatlandir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            int nereden = HangiHavuzda();

            if (rbTumu.Checked)
            {
                frmINTERNETiadelerdetay frm = new frmINTERNETiadelerdetay(
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value),
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clSMREF"].Value),
                    true,
                    nereden);
                frm.ShowDialog();
            }
            else if (rbFiyatlandirilmamis.Checked || rbFaturalananlar.Checked) //Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["clmnToplamTutar"].Value) == 0
            {
                frmINTERNETiadelerdetay frm = new frmINTERNETiadelerdetay(
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value),
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clSMREF"].Value),
                    nereden);
                frm.ShowDialog();
            }
            else if (Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["clmnToplamTutar"].Value) != 0/* && Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["clblAktarilmis"].Value)*/)
            {
                frmINTERNETiadelerdetay frm = new frmINTERNETiadelerdetay(
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value),
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clSMREF"].Value),
                    true,
                    nereden);
                frm.ShowDialog();
            }

            btnYenile.PerformClick();
        }

        private void btnFiyatlandirmaIptal_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            if (MessageBox.Show("Fiyatlandırmanın tekrar yapılabilmesi için önceki fiyatlandırma silinecek. Devam etmek istediğinize emin misiniz?", "İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.No)
                return;

            Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
            iade.mnToplamTutar = 0;
            iade.blAktarilmis = true;
            iade.DoUpdate();

            IadeHareketleri.DoInsert(iade.pkIadeID, 1, frmAna.KAdi.ToUpper(), ""); // fiyatlandırılmamışa geldi

            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]));
                id.mnFiyat = 0;
                id.DoUpdate();

                IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(id.pkIadeDetayID);
                idf.DoDelete();



                //IadeFiyatAdet.DoDelete(id.pkIadeDetayID);
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
                                ifa.DoDelete(); //IadeFiyatAdet.DoDeleteIadeDetayIDs(ifa.bintIadeDetayID);
                        }
                    }
                }



                int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clSMREF"].Value));
                string OZELKOD = Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["intUrunID"]), true);
                IadeHizmetTutar iht = IadeHizmetTutar.GetObject(GMREF, OZELKOD);
                iht.TUTTOP = iht.TUTTOP - idf.mnHizmetToplam;
                iht.DoUpdate();
                if (iht.TUTTOP == 0 && iht.STRREF != string.Empty)
                    iht.DoDelete();
            }

            frmINTERNETiadelerdetay frm = new frmINTERNETiadelerdetay(
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value),
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clSMREF"].Value),
                HangiHavuzda());
            frm.ShowDialog();
        }

        private void btnIadeRed_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            //if (dataGridView1.SelectedRows[0].Cells["clQUANTUMNO"].Value != DBNull.Value && dataGridView1.SelectedRows[0].Cells["clFATNO"].Value != DBNull.Value)
            //{
            //    MessageBox.Show("İade geri alınmadan başa alınamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else if (dataGridView1.SelectedRows[0].Cells["clFATNO"].Value != DBNull.Value)
            //{
            //    MessageBox.Show("İade geri alınmadan başa alınamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else if (dataGridView1.SelectedRows[0].Cells["clQUANTUMNO"].Value != DBNull.Value)
            //{
            //    MessageBox.Show("İade geri alınmadan başa alınamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (MessageBox.Show("Devam etmek istiyor musunuz?", "İade İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
                iade.mnToplamTutar = -1;
                iade.blAktarilmis = false;
                iade.DoUpdate();

                IadeHareketleri.DoInsert(iade.pkIadeID, 5, frmAna.KAdi.ToUpper(), ""); // reddedilenlere geldi

                DataTable dt = new DataTable();
                IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]));
                    id.mnFiyat = -1;
                    id.DoUpdate();

                    IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(id.pkIadeDetayID);
                    idf.DoDelete();



                    //IadeFiyatAdet.DoDelete(id.pkIadeDetayID);
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
                                    ifa.DoDelete(); //IadeFiyatAdet.DoDeleteIadeDetayIDs(ifa.bintIadeDetayID);
                            }
                        }
                    }



                    int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clSMREF"].Value));
                    string OZELKOD = Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["intUrunID"]), true);
                    IadeHizmetTutar iht = IadeHizmetTutar.GetObject(GMREF, OZELKOD);
                    iht.TUTTOP = iht.TUTTOP - idf.mnHizmetToplam;
                    iht.DoUpdate();
                    if (iht.TUTTOP == 0 && iht.STRREF != string.Empty)
                        iht.DoDelete();
                }

                //GonderilenMesajlar gm = new GonderilenMesajlar(
                //    iade.intMusteriID,
                //    59,
                //    "Kabul Edilmeyen İade: " + iade.pkIadeID.ToString(),
                //    iade.pkIadeID.ToString() + " nolu iade fiyatlandırma talebiniz kabul edilmemiştir.\r\n\r\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\r\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //gm.DoInsert();

                //MessageBox.Show("İade reddildi ve müşteriye (veya satış temsilcisine) bilgi gönderildi.", "İptal Edildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Suz();
            }
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            //if (dataGridView1.SelectedRows[0].Cells["clQUANTUMNO"].Value != DBNull.Value && dataGridView1.SelectedRows[0].Cells["clFATNO"].Value != DBNull.Value)
            //{
            //    MessageBox.Show("İade geri alınmadan başa alınamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else if (dataGridView1.SelectedRows[0].Cells["clFATNO"].Value != DBNull.Value)
            //{
            //    MessageBox.Show("İade geri alınmadan başa alınamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else if (dataGridView1.SelectedRows[0].Cells["clQUANTUMNO"].Value != DBNull.Value)
            //{
            //    MessageBox.Show("İade geri alınmadan başa alınamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}


            if (MessageBox.Show("İade, satırların eski fiyatlandırılması silinerek geri alınacak ve \"Fiyatlandırılmamış\" sekmesinde gözükecek. Devam etmek istiyor musunuz?", "Geri Alma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                //IadelerQ.Delete(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value)); //silmesin sap numarasını

                Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
                iade.blAktarilmis = true;
                iade.mnToplamTutar = 0;
                iade.DoUpdate();

                IadeFiyatSifirla(iade.pkIadeID);

                IadeHareketleri.DoInsert(iade.pkIadeID, 1, frmAna.KAdi.ToUpper(), ""); // fiyatlandırılmamışa geldi

                //GonderilenMesajlar gm = new GonderilenMesajlar(
                //    iade.intMusteriID,
                //    59,
                //    "Değişiklik Yapılacak İade: " + iade.pkIadeID.ToString(),
                //    iade.pkIadeID.ToString() + " nolu iade fiyatlandırma talebiniz, tekrar fiyatlandırılmak üzere geri alınmıştır. İade fiyatlandırıldıktan sonra yine mesaj ile bilgi alacaksınız ve fiyatlanan iadeyi \"Fiyatlandırılmış İadeyi Onayla\" tuşuyla tekrar onaylamanız gerekmektedir.\r\n\r\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\r\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //gm.DoInsert();

                //MessageBox.Show("İade geri alındı ve müşteriye (veya satış temsilcisine) bilgi gönderildi.", "Geri Alındı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                rbFiyatlandirilmis.Checked = true;
                Suz();
            }
        }

        private void btnDegisim_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            if (MessageBox.Show("Seçilen iadeler 'Son Fiyatlama'ya gönderilecek. Devam etmek istiyor musunuz?", "Son Fiyatlama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["clSecim"].Value != null)
                    {
                        if ((bool)dataGridView1.Rows[j].Cells["clSecim"].Value == true)
                        {
                            Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value));
                            iade.mnToplamTutar = -2;
                            iade.blAktarilmis = false;
                            iade.DoUpdate();

                            if (IadelerQ.GetQuantumNo(iade.pkIadeID).StartsWith("0035"))
                            {
                                bool varmi = IadelerIslem.IsExist(iade.pkIadeID);
                                if (varmi)
                                {
                                    //IadelerIslem ii = IadelerIslem.GetObject(iade.pkIadeID);
                                    //ii.dtIrsaliye = DateTime.MinValue;
                                    //ii.strVerilen = string.Empty;
                                    //ii.dtVerilis = DateTime.MinValue;
                                    //ii.dtMuhasebeVerilis = DateTime.MinValue;
                                    //ii.strFatNo = string.Empty;
                                    //ii.blIadeDegil = false;
                                    //ii.DoUpdate();
                                }
                                else
                                {
                                    IadelerIslem ii = new IadelerIslem(iade.pkIadeID, DateTime.MinValue, string.Empty, DateTime.MinValue, DateTime.MinValue, string.Empty, false);
                                    ii.DoInsert();
                                }
                            }

                            IadeHareketleri.DoInsert(iade.pkIadeID, 6, frmAna.KAdi.ToUpper(), ""); // değişimlere geldi
                        }
                    }
                }

                Suz();
            }

            //if (MessageBox.Show("Devam etmek istiyor musunuz?", "Değişim", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
            //    iade.mnToplamTutar = -2;
            //    iade.blAktarilmis = false;
            //    iade.DoUpdate();

            //    IadeHareketleri.DoInsert(iade.pkIadeID, 6, frmAna.KAdi.ToUpper(), ""); // değişimlere geldi
            //}
        }

        private void btnSevkBilgisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            frmINTERNETiadelersevk frm = new frmINTERNETiadelersevk(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
            frm.ShowDialog();
        }

        private void btnSubeDegistir_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //    return;

            //frmINTERNETcarihesaplarsubeler frm = new frmINTERNETcarihesaplarsubeler();
            //frm.ShowDialog();
            //if (SubeDegistirmeSMREF != 0)
            //{
            //    Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
            //    iade.SMREF = SubeDegistirmeSMREF;
            //    iade.DoUpdate();
            //    SubeDegistirmeSMREF = 0;

            //    IadeHareketleri.DoInsert(iade.pkIadeID, 11, frmAna.KAdi.ToUpper(), ""); // müşteri değiştirildi

            //    dataGridView1.SelectedRows[0].Cells["clSMREF"].Value = iade.SMREF;
            //    dataGridView1.SelectedRows[0].Cells["clMUSKOD"].Value = CariHesaplar.GetMUSKODbySMREF(iade.SMREF);
            //    dataGridView1.SelectedRows[0].Cells["clMUSTERI"].Value = CariHesaplar.GetMUSTERIbySMREF(iade.SMREF);
            //    dataGridView1.SelectedRows[0].Cells["clSUBKOD"].Value = CariHesaplar.GetSUBKODbySMREF(iade.SMREF);
            //    dataGridView1.SelectedRows[0].Cells["clSUBE"].Value = CariHesaplar.GetSUBEbySMREF(iade.SMREF);
            //}
        }

        private void btnUyeDegistir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            frmINTERNETmusterilersistemde frm = new frmINTERNETmusterilersistemde(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
            frm.Text = "İade Üye Değişimi";
            frm.ShowDialog();

            try
            {
                Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));

                dataGridView1.SelectedRows[0].Cells["clintMusteriID"].Value = iade.intMusteriID;
                dataGridView1.SelectedRows[0].Cells["clstrAd"].Value = Musteriler.GetMusteriByID(iade.intMusteriID).strAd;
                dataGridView1.SelectedRows[0].Cells["clstrSoyad"].Value = Musteriler.GetMusteriByID(iade.intMusteriID).strSoyad;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIadeGir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int indexxx = dataGridView1.SelectedRows[0].Index;
                frmINTERNETiadegirme frm = new frmINTERNETiadegirme();
                frm.ShowDialog();
                while (iadegirmetamamlandi)
                {
                    frm = new frmINTERNETiadegirme();
                    frm.ShowDialog();
                }

                Suz();
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[indexxx].Selected = true;
            }
            else
            {
                frmINTERNETiadegirme frm = new frmINTERNETiadegirme();
                frm.ShowDialog();
                while (iadegirmetamamlandi)
                {
                    frm = new frmINTERNETiadegirme();
                    frm.ShowDialog();
                }
            }
        }

        private void btnIadeDuzenle_Click(object sender, EventArgs e)
        {
            frmINTERNETiadefaturatakip frm = new frmINTERNETiadefaturatakip();
            frm.ShowDialog();
        }

        private void btnQuantumaYaz_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            if (MessageBox.Show("Fiyatlandırılmış iadeyi onayladığınızda müşteriye (veya satış temsilcisine) \"Bu iade sistem tarafından onaylanmıştır\" şeklinde bir mesaj gönderilecek. Devam etmek istiyor musunuz?", "Fiyatlandırılmış İadeyi Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));

                DataTable dt = new DataTable();
                IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);

                bool siparisbolundu = false;
                bool bolunenlerdenbiriaktarilamadi = false;



                #region IsyeriOzelKod bölünmesi
                //DataTable dtIsyeriOzelKodGruplar = new DataTable();
                //IsyeriOzelKod.GetObjects2Gruplar(dtIsyeriOzelKodGruplar);

                //for (int i = 0; i < dtIsyeriOzelKodGruplar.Rows.Count; i++)
                //{
                //    DataTable dtSiparistekiUrunler = new DataTable();
                //    IadelerDetay.GetObjectsByIadeID(dtSiparistekiUrunler, iade.pkIadeID);

                //    DataTable dtIsyeriOzelKod = new DataTable();
                //    IsyeriOzelKod.GetObjects2ByGrup(dtIsyeriOzelKod, Convert.ToInt32(dtIsyeriOzelKodGruplar.Rows[i][0]));

                //    short isyerino = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintIsyeriKod"]);
                //    short ambarno = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintAmbarKod"]);

                //    Iadeler yenisiparis =
                //        new Iadeler(iade.intMusteriID, iade.SMREF, DateTime.Now, 0, false, DateTime.Now, iade.strAciklama);
                //    ArrayList yenisiparisurunleri = new ArrayList();

                //    for (int j = 0; j < dtSiparistekiUrunler.Rows.Count; j++)
                //    {
                //        for (int k = 0; k < dtIsyeriOzelKod.Rows.Count; k++)
                //        {
                //            string isyeriozelkod = dtIsyeriOzelKod.Rows[k]["strOzelKod"].ToString();
                //            string urunozelkod = Urunler.GetProductOzelKod(Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]));

                //            if (urunozelkod == isyeriozelkod)
                //            {
                //                siparisbolundu = true;
                //                yenisiparisurunleri.Add(
                //                    new SiparislerDetay(
                //                        0,
                //                        Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]),
                //                        dtSiparistekiUrunler.Rows[j]["strUrunAdi"].ToString(),
                //                        Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intMiktar"]),
                //                        Convert.ToDecimal(dtSiparistekiUrunler.Rows[j]["mnFiyat"]),
                //                        Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaKart"].ToString()),
                //                        Convert.ToBoolean(dtSiparistekiUrunler.Rows[j]["blKampanyaHediye"]),
                //                        Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaSatir"].ToString()),
                //                        dtSiparistekiUrunler.Rows[j]["strMiktarTur"].ToString()));

                //                SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(
                //                    Convert.ToInt64(dtSiparistekiUrunler.Rows[j]["pkSiparisDetayID"]));

                //                siplerdet.DoDelete();
                //                //siparis.ToplamTutarGuncelle();

                //                break;
                //            }
                //        }
                //    }

                //    if (yenisiparisurunleri.Count > 0)
                //    {
                //        yenisiparis.DoInsert();

                //        decimal toplamtutar = 0;
                //        for (int j = 0; j < yenisiparisurunleri.Count; j++)
                //        {
                //            IadelerDetay siplerdet = (IadelerDetay)yenisiparisurunleri[j];
                //            siplerdet.intIadeID = yenisiparis.pkIadeID;
                //            siplerdet.DoInsert();

                //            toplamtutar += siplerdet.mnFiyat * siplerdet.intMiktar;
                //        }
                //        yenisiparis.mnToplamTutar = toplamtutar;
                //        yenisiparis.DoUpdate();

                //        if (QuantumaYaz(yenisiparis.pkIadeID, isyerino, ambarno))
                //        {
                //            yenisiparis.blAktarilmis = false;
                //            yenisiparis.DoUpdate();

                //            if (iade.strAciklama.EndsWith("-IADE MERKEZDEN GIRILDI"))
                //                IadeHareketleri.DoInsert(iade.pkIadeID, 4, frmAna.KAdi.ToUpper(), ""); // iade girilene geldi
                //            else
                //                IadeHareketleri.DoInsert(iade.pkIadeID, 3, frmAna.KAdi.ToUpper(), ""); // sevk bekleyene geldi

                //            DataTable dt1 = new DataTable();
                //            IadelerDetay.GetObjectsByIadeID(dt1, iade.pkIadeID);
                //            for (int i = 0; i < dt1.Rows.Count; i++)
                //                IadeFiyatAdet.DoUpdate(Convert.ToInt64(dt1.Rows[i]["pkIadeDetayID"]), true);
                //        }
                //        else
                //        {
                //            bolunenlerdenbiriaktarilamadi = true;
                //        }
                //    }
                //}
                #endregion



                if (!siparisbolundu)
                {
                    if (true) //QuantumaYaz(iade.pkIadeID, 0, 1)
                    {
                        iade.blAktarilmis = false;
                        iade.DoUpdate();

                        if (iade.strAciklama.EndsWith("-IADE MERKEZDEN GIRILDI"))
                            IadeHareketleri.DoInsert(iade.pkIadeID, 4, frmAna.KAdi.ToUpper(), ""); // iade girilene geldi
                        else
                            IadeHareketleri.DoInsert(iade.pkIadeID, 3, frmAna.KAdi.ToUpper(), ""); // sevk bekleyene geldi

                        DataTable dt1 = new DataTable();
                        IadelerDetay.GetObjectsByIadeID(dt1, iade.pkIadeID);
                        for (int i = 0; i < dt1.Rows.Count; i++)
                            IadeFiyatAdet.DoUpdate(Convert.ToInt64(dt1.Rows[i]["pkIadeDetayID"]), true);
                    }
                    else
                    {
                        IadelerQ.Delete(iade.pkIadeID);
                        MessageBox.Show("İade yoğunluktan dolayı SAP'a gönderilemedi, lütfen daha sonra tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }



                Suz();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ExceleAktar));
                thr.Start(sfd.FileName);
            }
        }

        private void rbTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                btnGeriAl.Visible = rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler2.Checked || rbFaturalananlar.Checked || rbReddedilenler.Checked || rbDegisimler.Checked || rbSevkIadeKabulArasi.Checked;
                iadeyiGeriAlToolStripMenuItem.Enabled = btnGeriAl.Visible;

                btnIadeRed.Visible = rbFiyatlandirilmamis.Checked || rbFaturalananlar.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler2.Checked || rbSevkIadeKabulArasi.Checked || rbSevkGelisBilgili.Checked || rbCoptekiler2.Checked;
                iadeyiReddetToolStripMenuItem.Enabled = btnIadeRed.Visible;

                btnFiyatlandirmaIptal.Visible = rbFiyatlandirilmis.Checked;
                tekrarFiyatlandırToolStripMenuItem.Enabled = btnFiyatlandirmaIptal.Visible;

                btnSevkBilgisi.Visible = rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler2.Checked || rbFaturalananlar.Checked || rbSevkGelisBilgili.Checked;
                sevkBilgisiToolStripMenuItem.Enabled = btnSevkBilgisi.Visible;

                btnIadeDuzenle.Visible = true;
                iadeyiDüzenleToolStripMenuItem.Enabled = btnIadeDuzenle.Visible;

                btnDegisim.Visible = rbFiyatlandirilmamis.Checked || rbFiyatlandirilmis.Checked;
                değişimToolStripMenuItem.Enabled = btnDegisim.Visible;

                btnQuantumaYaz.Visible = rbFiyatlandirilmis.Checked;
                fiyatlandırmayıOnaylaToolStripMenuItem.Enabled = btnQuantumaYaz.Visible;

                btnSubeDegistir.Visible = rbFiyatlandirilmamis.Checked;
                müşteriDeğiştirToolStripMenuItem.Enabled = btnSubeDegistir.Visible;

                btnUyeDegistir.Visible = true;
                üyeDeğiştirToolStripMenuItem.Enabled = btnUyeDegistir.Visible;

                btnSayim.Visible = rbFaturalananlar.Checked;
                sayımToolStripMenuItem.Enabled = btnSayim.Visible;

                btnSatisOperasyon.Visible = rbFaturalananlar.Checked || rbSatOp.Checked || rbST.Checked || rbCH.Checked || rbSon.Checked;
                satışOperasyonToolStripMenuItem.Enabled = btnSatisOperasyon.Visible;

                btnOnemsizeAt.Visible = rbFiyatlandirilmisOnaylanmis.Checked || rbSevkGelisBilgili.Checked || rbSevkIadeKabulArasi.Checked;
                önemsizeAtToolStripMenuItem.Enabled = btnOnemsizeAt.Visible;

                btnKabul.Visible = rbFiyatlandirilmamis.Checked || rbSevkGelisBilgili.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbSevkIadeKabulArasi.Checked;
                iadeKabuleGönderToolStripMenuItem.Enabled = btnKabul.Visible;

                btnKabuldenGeri.Visible = rbFaturalananlar.Checked;
                iadeKabuldenGeriAlToolStripMenuItem.Enabled = btnKabuldenGeri.Visible;

                btnTopluYazdir.Visible = rbFiyatlandirilmamis.Checked || rbFiyatlandirilmis.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbSevkIadeKabulArasi.Checked || rbFaturalananlar.Checked || rbSatOp.Checked || rbST.Checked || rbCH.Checked || rbReddedilenler.Checked || rbDegisimler.Checked || rbCoptekiler2.Checked;



                pnlSevk.Visible = rbFiyatlandirilmisOnaylanmis.Checked;
                rbSevkTumu.Checked = true;

                //cbIadeKabulTumu.Visible = rbFaturalananlar.Checked || rbSatOp.Checked || rbST.Checked || rbCH.Checked || rbSon.Checked;

                Suz();
                //GetCariler();



                dataGridView1.Columns["clblSayimYapildi"].Visible = rbFaturalananlar.Checked;
                dataGridView1.Columns["cldtSayimTarihi"].Visible = rbFaturalananlar.Checked;
                dataGridView1.Columns["clSatisOperasyonSonAciklama"].Visible = rbFaturalananlar.Checked || rbSatOp.Checked || rbST.Checked || rbCH.Checked || rbSon.Checked;
                dataGridView1.Columns["clSatisOperasyonSonIslemYapan"].Visible = rbFaturalananlar.Checked || rbSatOp.Checked || rbST.Checked || rbCH.Checked || rbSon.Checked;
                dataGridView1.Columns["clSatisOperasyonSonTarih"].Visible = rbFaturalananlar.Checked || rbSatOp.Checked || rbST.Checked || rbCH.Checked || rbSon.Checked;
                dataGridView1.Columns["clmnToplamTutar"].Visible = rbFiyatlandirilmis.Checked || rbFaturalananlar.Checked || rbFiyatlandirilmisOnaylanmis.Checked || rbCoptekiler.Checked || rbTumu.Checked;
                dataGridView1.Columns["clSTATU"].Visible = rbTumu.Checked;
            }
        }

        private void cbIadeKabulTumu_CheckedChanged(object sender, EventArgs e)
        {
            Suz();
        }

        private void frmINTERNETiadeler_SizeChanged(object sender, EventArgs e)
        {
            lblSatirSayisi1.Location = new Point(lblSatirSayisi1.Location.X, lblAlt.Location.Y + 12);
            lblSatirSayisi.Location = new Point(lblSatirSayisi.Location.X, lblAlt.Location.Y + 12);
            lblSatirSayisi2.Location = new Point(lblSatirSayisi2.Location.X, lblAlt.Location.Y + 40);
            lblSatirSayisi3.Location = new Point(lblSatirSayisi3.Location.X, lblAlt.Location.Y + 40);
            lblSatirSayisiArkaplan.Location = new Point(lblSatirSayisiArkaplan.Location.X, lblAlt.Location.Y + 36);
            btnExcel.Location = new Point(btnExcel.Location.X, lblAlt.Location.Y + 7);
            progressBar1.Location = new Point(progressBar1.Location.X, lblAlt.Location.Y + 7);
            btnSevkBilgisi.Location = new Point(btnSevkBilgisi.Location.X, lblAlt.Location.Y + 7);
            btnIadeRed.Location = new Point(btnIadeRed.Location.X, lblAlt.Location.Y + 7);
            btnOnemsizeAt.Location = new Point(btnOnemsizeAt.Location.X, lblAlt.Location.Y + 7);
            btnGeriAl.Location = new Point(btnGeriAl.Location.X, lblAlt.Location.Y + 7);
            btnFiyatlandir.Location = new Point(btnFiyatlandir.Location.X, lblAlt.Location.Y + 36);
            btnTopluYazdir.Location = new Point(btnTopluYazdir.Location.X, lblAlt.Location.Y + 36);
            btnAkibet.Location = new Point(btnAkibet.Location.X, lblAlt.Location.Y + 36);
            btnIadeGir.Location = new Point(btnIadeGir.Location.X, lblAlt.Location.Y + 36);
            btnIadeDuzenle.Location = new Point(btnIadeDuzenle.Location.X, lblAlt.Location.Y + 36);
            btnSubeDegistir.Location = new Point(btnSubeDegistir.Location.X, lblAlt.Location.Y + 36);
            btnUyeDegistir.Location = new Point(btnUyeDegistir.Location.X, lblAlt.Location.Y + 36);
            btnFiyatlandirmaIptal.Location = new Point(btnFiyatlandirmaIptal.Location.X, lblAlt.Location.Y + 7);
            btnDegisim.Location = new Point(btnDegisim.Location.X, lblAlt.Location.Y + 7);
            btnQuantumaYaz.Location = new Point(btnQuantumaYaz.Location.X, lblAlt.Location.Y + 7);
            btnSayim.Location = new Point(btnSayim.Location.X, lblAlt.Location.Y + 36);
            btnSatisOperasyon.Location = new Point(btnSatisOperasyon.Location.X, lblAlt.Location.Y + 7);
            btnKabul.Location = new Point(btnKabul.Location.X, lblAlt.Location.Y + 36);
            btnKabuldenGeri.Location = new Point(btnKabuldenGeri.Location.X, lblAlt.Location.Y + 36);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
        }

        private void ExceleAktar(object filename)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 8;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 55;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 55;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 18;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 9;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 25;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 25;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 15;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 9;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["M", Type.Missing]).ColumnWidth = 18;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["N", Type.Missing]).ColumnWidth = 15;

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["O", Type.Missing]).ColumnWidth = 20;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["P", Type.Missing]).ColumnWidth = 20;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["Q", Type.Missing]).ColumnWidth = 18;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["R", Type.Missing]).ColumnWidth = 18;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["S", Type.Missing]).ColumnWidth = 25;

            ((Microsoft.Office.Interop.Excel.Range)ws.Rows[1, Type.Missing]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["N", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ws.Cells[1, 1] = "İade No";
            ws.Cells[1, 2] = "Üye Ad";
            ws.Cells[1, 3] = "Üye Soyad";
            ws.Cells[1, 4] = "Cari Hesap";
            ws.Cells[1, 5] = "Cari Şube";
            ws.Cells[1, 6] = "Onaylama Tarihi";
            ws.Cells[1, 7] = "Toplam Tutar";
            ws.Cells[1, 8] = "Satır Sayısı";
            ws.Cells[1, 9] = "Açıklama 2";
            ws.Cells[1, 10] = "Açıklama 3";
            ws.Cells[1, 11] = "SAP Sip.No";
            ws.Cells[1, 12] = "Fat.No";
            ws.Cells[1, 13] = "Fat.Tarih";
            ws.Cells[1, 14] = "Yazdırılma Sayısı";

            ws.Cells[1, 15] = "Şoför";
            ws.Cells[1, 16] = "Muavin";
            ws.Cells[1, 17] = "Verilme Tarihi";
            ws.Cells[1, 18] = "Geliş Tarihi";
            ws.Cells[1, 19] = "Sevk Açıklaması";

            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;

            this.Enabled = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                progressBar1.Value = i;

                ws.Cells[i + 2, 1] = dataGridView1.Rows[i].Cells["clpkIadeID"].Value.ToString();
                ws.Cells[i + 2, 2] = dataGridView1.Rows[i].Cells["clstrAd"].Value.ToString();
                ws.Cells[i + 2, 3] = dataGridView1.Rows[i].Cells["clstrSoyad"].Value.ToString();
                ws.Cells[i + 2, 4] = dataGridView1.Rows[i].Cells["clMUSTERI"].Value.ToString();
                ws.Cells[i + 2, 5] = dataGridView1.Rows[i].Cells["clSUBE"].Value.ToString();
                ws.Cells[i + 2, 6] = dataGridView1.Rows[i].Cells["cldtOnaylamaTarihi"].Value.ToString();
                ws.Cells[i + 2, 7] = Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmnToplamTutar"].Value).ToString("C2");
                ws.Cells[i + 2, 8] = dataGridView1.Rows[i].Cells["clSatirSayisi"].Value.ToString();
                ws.Cells[i + 2, 9] = dataGridView1.Rows[i].Cells["clstrAciklama2"].Value.ToString();
                ws.Cells[i + 2, 10] = dataGridView1.Rows[i].Cells["clstrAciklama3"].Value.ToString();
                ws.Cells[i + 2, 11] = dataGridView1.Rows[i].Cells["clQUANTUMNO"].Value.ToString();
                ws.Cells[i + 2, 12] = dataGridView1.Rows[i].Cells["clFATNO"].Value.ToString();
                ws.Cells[i + 2, 13] = dataGridView1.Rows[i].Cells["clFATTAR"].Value.ToString();
                ws.Cells[i + 2, 14] = dataGridView1.Rows[i].Cells["clBasilmaSayisi"].Value.ToString();

                DataTable dt1 = new DataTable();
                Iadeler.GetSevkBilgileri(dt1, Convert.ToInt32(dataGridView1.Rows[i].Cells["clpkIadeID"].Value));
                if (dt1.Rows.Count > 0)
                {
                    ws.Cells[i + 2, 15] = dt1.Rows[dt1.Rows.Count - 1]["strSofor"].ToString();
                    ws.Cells[i + 2, 16] = dt1.Rows[dt1.Rows.Count - 1]["strMuavin"].ToString();
                    ws.Cells[i + 2, 17] = dt1.Rows[dt1.Rows.Count - 1]["dtTarihGidis"].ToString();
                    ws.Cells[i + 2, 18] = dt1.Rows[dt1.Rows.Count - 1]["dtTarihGelis"].ToString();
                    ws.Cells[i + 2, 19] = dt1.Rows[dt1.Rows.Count - 1]["strAciklama"].ToString();
                }
            }
            this.Enabled = true;

            progressBar1.Visible = false;

            ws.SaveAs(filename.ToString());
            wb.Close();
            ap.Quit();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (cbRenklendir.Checked)
                Renklendir2();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (rbFiyatlandirilmisOnaylanmis.Checked)
            //{
            //    if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            //    {
            //        btnSevkBilgisi.PerformClick();
            //    }
            //}
        }

        private void rbSevkTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Suz();
                //GetCariler();
                Renklendir2();
            }
        }

        private void rbSevkBilgili_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Suz();

                //ArrayList silinecekler = new ArrayList();
                //for (int j = 0; j < dataGridView1.Rows.Count; j++)
                //{
                //    DataTable dt1 = new DataTable();
                //    Iadeler.GetSevkBilgileri(dt1, Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value));
                //    if (dt1.Rows.Count == 0 || dt1.Rows[dt1.Rows.Count - 1]["dtTarihGelis"] != DBNull.Value)
                //    //if ((int)dataGridView1.Rows[j].Cells["clSevkBilgisiSayisi"].Value == 0)
                //        silinecekler.Add(dataGridView1.Rows[j]);
                //}

                //for (int i = 0; i < silinecekler.Count; i++)
                //    dataGridView1.Rows.Remove((DataGridViewRow)silinecekler[i]);

                //lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
                //Renklendir2();
            }
        }

        private void rbSevkBilgisiz_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Suz();

                //ArrayList silinecekler = new ArrayList();
                //for (int j = 0; j < dataGridView1.Rows.Count; j++)
                //{
                //    DataTable dt1 = new DataTable();
                //    Iadeler.GetSevkBilgileri(dt1, Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value));
                //    if (dt1.Rows.Count > 0)
                //    //if ((int)dataGridView1.Rows[j].Cells["clSevkBilgisiSayisi"].Value > 0)
                //        silinecekler.Add(dataGridView1.Rows[j]);
                //}

                //for (int i = 0; i < silinecekler.Count; i++)
                //    dataGridView1.Rows.Remove((DataGridViewRow)silinecekler[i]);

                //lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
                //Renklendir2();
            }
        }

        private void rb2013_CheckedChanged(object sender, EventArgs e)
        {
            Suz();
            rbSevkTumu.Checked = true;
        }

        private void btnTopluYazdir_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp"))
                Directory.Delete(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp", true);

            if (dataGridView1.Rows.Count > 0)
                Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp");
            else
                return;

            if (frmAna.KAdi.ToUpper() == "LK07" || frmAna.KAdi.ToUpper() == "LK06" ||
                frmAna.KAdi.ToUpper() == "LK12" || frmAna.KAdi.ToUpper() == "LK02" || frmAna.KAdi.ToUpper() == "FT09")
            {
                if (MessageBox.Show("Bu iadeler yazdırıldı olarak işaretlensin mi?", "Yazdırılma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    topluyazdirisaretlesevkbilgisigir = true;
                }
                else
                {
                    topluyazdirisaretlesevkbilgisigir = false;
                }
            }

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (dataGridView1.Rows[j].Cells["clSecim"].Value != null)
                {
                    if ((bool)dataGridView1.Rows[j].Cells["clSecim"].Value == true)
                    {
                        Yazdir(j);
                        IadeHareketleri.DoInsert(Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value), 13, frmAna.KAdi.ToUpper(), ""); // yazdırıldı (toplu)
                    }
                }
            }
        }
        bool topluyazdirisaretlesevkbilgisigir = false;
        private void Yazdir(int DataGridViewIndex)
        {
            int IadeID = Convert.ToInt32(dataGridView1.Rows[DataGridViewIndex].Cells["clpkIadeID"].Value);
            int SMREF = Convert.ToInt32(dataGridView1.Rows[DataGridViewIndex].Cells["clSMREF"].Value);

            if (topluyazdirisaretlesevkbilgisigir)
            {
                Iadeler.DoInsertEk(IadeID);
                //Iadeler.DoInsertSevkBilgisi(IadeID, "", "", DateTime.Now);
            }

            int Nereden = HangiHavuzda();
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

            string musteri = CariHesaplar.GetMUSTERIbySMREF(SMREF);
            musteri += CariHesaplar.AnaSubeMi(CariHesaplar.GetGMREFBySMREF(SMREF)) ? "<br /><span style='color: #FFFFFF'>Müşteri: </span>" + CariHesaplar.GetSUBEbySMREF(SMREF) : "";
            musteri += "<br /><span style='color: #D00000'>Müşteri Kodu: </span>" + CariHesaplar.GetMUSKODbySMREF(SMREF) +
                "<br /><span style='color: #D00000'>Şube Kodu: </span>" + CariHesaplar.GetSUBKODbySMREF(SMREF) +
                "<br /><span style='color: #D00000'>Adres: </span>" + CariHesaplar.GetADRESbySMREF(SMREF) +
                "<br /><span style='color: #D00000'>İlgili: </span>" + CariHesaplar.GetILGILIbySMREF(SMREF) +
                "<br /><span style='color: #D00000'>Vergi No: </span>" + CariHesaplar.GetVRGNObySMREF(SMREF);

            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);

            string html = "<html><head><title>Sultanlar UI : Iade Detay Satırları</title></head><body>";

            html += "<table cellspacing='0' cellpadding='0' style='font-family: Verdana; font-size: 11px'><tr><td style='padding-top: 10px; padding-bottom: 15px; padding-left: 3px; width: 540px'><b><span style='color: #D00000'>Müşteri:</span> " +
                musteri + "</b></td><td style='padding-top: 10px; padding-bottom: 15px; width: 160px;' align='left'><b><span style='color: #D00000'>Quantum No:</span> " +
                IadelerQ.GetQuantumNo(IadeID) + "<br><span style='color: #D00000'>İade No:</span> " + IadeID.ToString() + "</b></td></tr></table>";

            html += "<table cellpadding='3' cellspacing='0' style='font-family: Verdana; font-size: 11px'><tr>" +
                "<td align='left' style='width: 320px; padding-top: 0px;'><b><span style='color: #D00000'>İade Sahibi:</span> " + SatisTemsilcileri.GetSATTEMBySMREF(iade.SMREF) + "</b></td>" +
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
            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double kdv = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]), true);
                double net = 0;
                double tutar = 0;
                int miktar = Convert.ToInt32(dt.Rows[i]["intMiktar"]);
                if (dt.Rows[i]["mnFiyat"] != DBNull.Value)
                {
                    net = (Convert.ToDouble(dt.Rows[i]["mnFiyat"]) * 100) / (100 + kdv);
                    tutar = Convert.ToDouble(dt.Rows[i]["mnFiyat"]);
                    toplamnetkdv += tutar * miktar;
                }

                if (kdv == 1)
                    birkdv += (net * miktar) / 100;
                if (kdv == 8)
                    sekizkdv += ((net * miktar) / 100) * kdv;
                if (kdv == 18)
                    onsekizkdv += ((net * miktar) / 100) * kdv;

                toplamnet += net * miktar;

                html += "<tr style='height: 36px'>" +
                    "<td align='left' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dt.Rows[i]["strUrunAdi"].ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + Urunler.GetProductBarkod(Convert.ToInt32(dt.Rows[i]["intUrunID"]), true) + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dt.Rows[i]["intMiktar"].ToString() + "</td>" +
                    "<td align='right' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + net.ToString("C2") + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + kdv.ToString() + "</td>" +
                    "<td align='right' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC; border-right: 1px solid #CCCCCC'>" + (net * Convert.ToInt32(dt.Rows[i]["intMiktar"])).ToString("C2") + "</td></tr>";
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

            System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp\\sultanlar-iadesatirlar" + DataGridViewIndex.ToString() + ".htm", true, Encoding.Unicode);
            sw.Write(html);
            sw.Close();
            sw.Dispose();

            BarkodOlustur(IadeID.ToString(), Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp", IadeID.ToString());

            //System.Drawing.Printing.PrintDocument p = new System.Drawing.Printing.PrintDocument();
            //p.DocumentName = "C:\\sultanlar-iadesatirlar" + DataGridViewIndex.ToString() + ".htm";
            //p.Print();

            WebBrowser webBrowserForPrinting = new WebBrowser();
            webBrowserForPrinting.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowserForPrinting_DocumentCompleted);
            webBrowserForPrinting.Url = new Uri(Application.StartupPath + "\\temp\\Sultanlar\\iadeyazdirmatemp\\sultanlar-iadesatirlar" + DataGridViewIndex.ToString() + ".htm");
        }
        
        void webBrowserForPrinting_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Print();
        }

        private void btnAkibet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            frmINTERNETiadeGecmisi frm = new frmINTERNETiadeGecmisi(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value));
            frm.ShowDialog();
        }

        #region contextmenustrip
        private void içerikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFiyatlandir.PerformClick();
        }
        private void iadeGeçmişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAkibet.PerformClick();
        }
        private void sevkBilgisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSevkBilgisi.PerformClick();
        }
        private void fiyatlandırmayıOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnQuantumaYaz.PerformClick();
        }
        private void tekrarFiyatlandırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFiyatlandirmaIptal.PerformClick();
        }
        private void iadeyiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnIadeDuzenle.PerformClick();
        }
        private void iadeyiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGeriAl.PerformClick();
        }
        private void iadeyiReddetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnIadeRed.PerformClick();
        }
        private void değişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDegisim.PerformClick();
        }
        private void müşteriDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSubeDegistir.PerformClick();
        }
        private void üyeDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUyeDegistir.PerformClick();
        }
        private void sayımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSayim.PerformClick();
        }
        private void satışOperasyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSatisOperasyon.PerformClick();
        }
        private void iadeKabuleGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnKabul.PerformClick();
        }
        private void iadeKabuldenGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnKabuldenGeri.PerformClick();
        }
        #endregion

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                if (dataGridView1.Columns[e.ColumnIndex].Name != "clSatisOperasyonSonAciklama")
                    dgvfm.ShowPopup(e.ColumnIndex);
        }

        private void btnSayim_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            int iadeid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value);
            string mesaj = dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value == DBNull.Value || !Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value) ? "İade, sayım yapıldı olarak işaretlenecektir. Devam etmek istediğinize emin misiniz?" : "İade, sayımı yapılmadı olarak işaretlenecektir. Devam etmek istediğinize emin misiniz";

            if (MessageBox.Show(mesaj, "Sayım İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value == DBNull.Value || !Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value))
                {
                    Iadeler.DoInsertEkSayimYapildi(iadeid);
                    IadeHareketleri.DoInsert(iadeid, 18, frmAna.KAdi.ToUpper(), ""); // sayım işlemi yapıldı
                }
                else
                {
                    Iadeler.DoInsertEkSayimYapilmadi(iadeid);
                    IadeHareketleri.DoInsert(iadeid, 19, frmAna.KAdi.ToUpper(), ""); // sayım işlemi geri alındı
                }

                dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value = dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value == DBNull.Value || !Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value) ? true : false;
                dataGridView1.SelectedRows[0].Cells["cldtSayimTarihi"].Value = dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value == DBNull.Value || !Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["clblSayimYapildi"].Value) ? "" : DateTime.Now.ToString();
            }
        }

        private void btnSatisOperasyon_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            int Nereden = 0;

            if (frmAna.KAdi.ToUpper() == "LK21" || frmAna.KAdi.ToUpper() == "ST03" || frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "YN04" || frmAna.KAdi.ToUpper() == "YN02" || frmAna.KAdi.ToUpper() == "ST07" || frmAna.KAdi.ToUpper() == "ST13")
            {
                frmINTERNETiadelersatisoperasyon frm = new frmINTERNETiadelersatisoperasyon(10); // ünal yıldırım, murat kasaroğlu, fahrettin kaya, neslihan demirbaş, gülzade yar
                frm.ShowDialog();
            }
            else
            {
                if (rbFaturalananlar.Checked)
                {
                    Nereden = 0;
                    SatisOperasyon = "Sat.Op. - İade Kabul'den geldi.";
                }
                else if (rbSatOp.Checked)
                {
                    Nereden = 1;
                    SatisOperasyon = "S.T. - Sat.Op.'dan geldi.";
                }
                else if (rbST.Checked)
                {
                    Nereden = 2;
                    SatisOperasyon = "C/H - S.T.'den geldi.";
                }
                else if (rbCH.Checked)
                {
                    Nereden = 3;
                    SatisOperasyon = "Son - C/H'dan düşüldü.";
                }
            }

            if (SatisOperasyon != string.Empty)
            {
                if (MessageBox.Show("\"" + SatisOperasyon + "\"\r\n\r\nişlemi uygulanacak. Devam etmek istediğinize emin misiniz?", "Operasyon İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int iadeid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value);

                    IadeHareketleri.DoInsert(iadeid, 21, frmAna.KAdi.ToUpper(), SatisOperasyon); // satış operasyon işlemi uygulandı

                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    if (dataGridView1.Rows.Count > 0)
                        dataGridView1.Rows[0].Selected = true;
                    //dataGridView1.SelectedRows[0].Cells["clSatisOperasyonSonAciklama"].Value = SatisOperasyon;
                    //dataGridView1.SelectedRows[0].Cells["clSatisOperasyonSonIslemYapan"].Value = frmAna.KAdi.ToUpper();
                    //dataGridView1.SelectedRows[0].Cells["clSatisOperasyonSonTarih"].Value = DateTime.Now;

                    if (lblSatirSayisi.Text != "0")
                        lblSatirSayisi.Text = (Convert.ToInt32(lblSatirSayisi.Text) - 1).ToString();

                    SatisOperasyon = string.Empty;
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            KolonlarIsimler();
        }

        private void btnQuantumdanGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void cbSatisOperasyonSonAciklama_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["clSatisOperasyonSonIslemYapan"].Visible = cbSatisOperasyonSonIslemYapan.Checked;
            dataGridView1.Columns["clSatisOperasyonSonTarih"].Visible = cbSatisOperasyonSonTarih.Checked;
            dataGridView1.Columns["clstrSofor"].Visible = cbstrSofor.Checked;
            dataGridView1.Columns["clstrMuavin"].Visible = cbstrMuavin.Checked;
            dataGridView1.Columns["cldtTarihGidis"].Visible = cbdtTarihGidis.Checked;
            dataGridView1.Columns["clSevkBilgisiSayisi"].Visible = cbSevkBilgisiSayisi.Checked;
            dataGridView1.Columns["clstrSoyad"].Visible = cbstrSoyad.Checked;
            dataGridView1.Columns["clstrAd"].Visible = cbstrAd.Checked;
            dataGridView1.Columns["clSatirSayisi"].Visible = cbSatirSayisi.Checked;
            dataGridView1.Columns["clVGBLI"].Visible = cbVGBLI.Checked;
            dataGridView1.Columns["clIstihbarat4"].Visible = cbIstihbarat.Checked;
            dataGridView1.Columns["clIstihbarat5"].Visible = cbIstihbarat.Checked;
            dataGridView1.Columns["clIstihbarat6"].Visible = cbIstihbarat.Checked;

            dataGridView1.Columns["clSecim"].Visible = cbSecim.Checked;
            dataGridView1.Columns["clBasilmaSayisi"].Visible = cbBasilmaSayisi.Checked;
            dataGridView1.Columns["clIADEMERKEZDENGIRILDI"].Visible = cbIADEMERKEZDENGIRILDI.Checked;

            cbRenklendir.Enabled = cbFiyatlandirilmisSatirSayisi.Checked && cbSatirSayisi.Checked && cbSevkBilgisiSayisi.Checked;
            cbRenklendir.Checked = cbFiyatlandirilmisSatirSayisi.Checked && cbSatirSayisi.Checked && cbSevkBilgisiSayisi.Checked ? cbRenklendir.Checked : false;
        }

        private void btnSecenekler_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
        }

        private void btnEposta_Click(object sender, EventArgs e)
        {
            string stiadesahipleri = Sultanlar.DatabaseObject.Internet.Iadeler.STIadeleriSahiplerineMesaj();

            Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "",
                new string[] { 
                        "mtorun@sultanlar.com.tr", "eozel@sultanlar.com.tr", "gcelik@sultanlar.com.tr", "afettah@sultanlar.com.tr", 
                        "kbaltasi@sultanlar.com.tr", "mkasaroglu@sultanlar.com.tr", "iade@sultanlar.com.tr", "uyildirim@sultanlar.com.tr", 
                        "mistif@sultanlar.com.tr"
                    },
                new string[] {
                        "my@sultanlar.com.tr", "farukyildiz@sultanlar.com.tr", "rbagdatli@sultanlar.com.tr", "fmehmetoglu@sultanlar.com.tr", 
                        "hozpoyraz@sultanlar.com.tr"
                    },
                "Sultanlar Pazarlama A.Ş.", "2014 yılı itibariyle iade uygulaması günlük bölüm satır sayıları",
                Sultanlar.DatabaseObject.Internet.Iadeler.GetIadelerTabsRowCount().Replace("\r\n", "<br>")
                .Replace("Fiyatlandırılmamış:", "<b>Emre Özel / Hediye Çetli / Fiyatlandırılmamış:</b>")
                .Replace("Fiyatlandırılmış:", "<b>Fikret Yıldırıcı / Ünal Yıldırım / Fiyatlandırılmış:</b>")
                //.Replace("Sevk Bekleyen Tümü:", "<b>Ahmet Fettah / Arzu Bayram / Sevk Bekleyen Tümü:</b>")
                .Replace("Sevk Bekleyen Araca Verilecek:", "<b>Ahmet Fettah / Ertuğrul Duysak - Olgun Kaya / Sevk Bekleyen Araca Verilecek:</b>")
                .Replace("Sevk Bekleyen Araçta:", "<b>Ahmet Fettah / Ertuğrul Duysak - Olgun Kaya / Sevk Bekleyen Araçta:</b>")
                .Replace("Sevkten Gelen:", "<b>Ahmet Fettah / Erkan Karakurt - Şeyda Aslan / Sevkten Gelen:</b>")
                .Replace("İade Girilen:", "<b>Ahmet Fettah / Erkan Karakurt - Şeyda Aslan / İade Girilen:</b>")
                .Replace("İade Kabul:", "<b>Ahmet Fettah / Erkan Karakurt - Şeyda Aslan / İade Kabul:</b>")
                .Replace("Sat.Op.:", "<b>Fikret Yıldırıcı / Ünal Yıldırım / Sat.Op.:</b>")
                .Replace("S.T.:", "<b>Fikret Yıldırıcı / Ünal Yıldırım / S.T.:</b>")
                .Replace("C/H:", "<b>Emre Özel / Hediye Çetli / C/H:</b>")
                .Replace("Son:", "<b>İşlemi Biten:</b>")
                .Replace("Reddedilen:", "<b>Reddedilen:</b>")
                .Replace("Değişim:", "<b>Değişim:</b>")
                .Replace("Önemsiz:", "<b>Önemsiz:</b>")
                + "<br>" + "<i> Gönderim tarihi: " + DateTime.Now.ToString() + "</i>"
                + "<br><br><br><br><i><b>S.T. Bölümündeki Satıcıların Dosyalarındaki İade Sayısı:</b></i><br><br>"
                + (stiadesahipleri == string.Empty ? "- Görüntülenecek bilgi yoktur. -" : stiadesahipleri));

            MessageBox.Show("Gönderildi.");
        }

        private void btnOnemsizeAt_Click(object sender, EventArgs e)
        {
            frmInputBox frm = new frmInputBox("Lütfen Açıklama Yazınız");
            frm.ShowDialog();

            int iadeid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value);

            Iadeler iade = Iadeler.GetObjectsByIadeID(iadeid);
            iade.strAciklama = iade.strAciklama.Replace("-IADE MERKEZDEN GIRILDI", "");
            iade.DoUpdate();

            Iadeler.DoInsertCopeAt(iadeid);
            IadeHareketleri.DoInsert(iadeid, 23, frmAna.KAdi.ToUpper(), frmAna.InputBox);
            frmAna.InputBox = string.Empty;

            MessageBox.Show("İade 'Önemsiz' bölümüne atıldı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;
        }

        private void btnKabul_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen iadeler 'İade Kabul' bölümüne gönderilecek. Devam etmek istediğinize emin misiniz?", "İade Kabul", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                bool secimyok = true;

                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["clSecim"].Value != null)
                    {
                        if ((bool)dataGridView1.Rows[j].Cells["clSecim"].Value == true)
                        {
                            secimyok = false;

                            int iadeid = Convert.ToInt32(dataGridView1.Rows[j].Cells["clpkIadeID"].Value);
                            if (rbFiyatlandirilmamis.Checked)
                            {
                                Iadeler iade = Iadeler.GetObjectsByIadeID(iadeid);
                                iade.mnToplamTutar = Convert.ToDecimal(0.001);
                                iade.blAktarilmis = false;
                                iade.DoUpdate();
                            }
                            IadelerQ.WriteQuantumNo(iadeid, "0", "0");
                            IadeHareketleri.DoInsert(iadeid, 24, frmAna.KAdi.ToUpper(), frmAna.InputBox);
                            //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            //if (dataGridView1.Rows.Count > 0)
                            //    dataGridView1.Rows[0].Selected = true;
                        }
                    }
                }

                if (secimyok)
                {
                    int iadeid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value);
                    if (rbFiyatlandirilmamis.Checked)
                    {
                        Iadeler iade = Iadeler.GetObjectsByIadeID(iadeid);
                        iade.mnToplamTutar = Convert.ToDecimal(0.001);
                        iade.blAktarilmis = false;
                        iade.DoUpdate();
                    }
                    IadelerQ.WriteQuantumNo(iadeid, "0", "0");
                    IadeHareketleri.DoInsert(iadeid, 24, frmAna.KAdi.ToUpper(), frmAna.InputBox);
                    MessageBox.Show("İade 'İade Kabul' bölümüne atıldı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    if (dataGridView1.Rows.Count > 0)
                        dataGridView1.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("İadeler 'İade Kabul' bölümüne atıldı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Suz();
                }
            }
        }

        private void btnKabuldenGeri_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İade 'İade Kabul' bölümünden geri gönderilecek. Devam etmek istediğinize emin misiniz?", "İade Kabul Geri", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                int iadeid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkIadeID"].Value);
                IadelerQ.Delete(iadeid);
                IadeHareketleri.DoInsert(iadeid, 25, frmAna.KAdi.ToUpper(), frmAna.InputBox);
                MessageBox.Show("İade 'İade Kabul' bölümünden geri alındı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = true;
            }
        }

        private void cbTumunuSec_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                dataGridView1.Rows[j].Cells["clSecim"].Value = cbTumunuSec.Checked;
        }
    }
}
