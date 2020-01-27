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
using System.Net.Mail;
using System.Net;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmusteriler : Form
    {
        public frmINTERNETmusteriler()
        {
            InitializeComponent();
        }

        public static int GMREF;
        public static string MUSKOD;
        public static string MUSTERI;
        ArrayList ilkMusteriler;
        public static int SLSREF;
        public static string SATKOD1;
        public static string SATTEM;

        public static int SMREF; // altcari bağlantısı için

        private void frmINTERNETmusteriler_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            GMREF = 0;
            SMREF = 0;
            ilkMusteriler = new ArrayList();
            GetFiyatTipleri();
            GetOzelKodlar();
            GetGrupKodlar();
            GetBayiler();
            GetUyeTipleri();
            GetUyeGruplari();
            GetMusteriler();
            
            AcilisKontrol();
        }

        private void AcilisKontrol()
        {
            // design den visible false yapınca bidaha true da yapınca gözükmediler o yüzden buraya yazdım
            btnCariHesabaBagla.Visible = false;
            btnAltCariyeBagla.Visible = false;
            btnSatisTemsilcisineBagla.Visible = false;
            btnTalepEposta.Visible = false;
            btnOnayEposta.Visible = false;

            int Tip = -1;
            if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR")
                Tip = 0;
            else if (frmAna.KAdi.ToUpper() == "ST09" || frmAna.KAdi.ToUpper() == "YN02")
                Tip = 1;
            else if (frmAna.KAdi.ToUpper() == "FN08" || frmAna.KAdi.ToUpper() == "FN09" || frmAna.KAdi.ToUpper() == "FN03" || frmAna.KAdi.ToUpper() == "MI05")
                Tip = 2;
            else if (frmAna.KAdi.ToUpper() == "ST01")
                Tip = 3;
            else if (frmAna.KAdi.ToUpper() == "ST12")
                Tip = 4;

            KontrollerKontrolu(Tip);
        }

        /// <summary>
        /// Açılışta hangi kontroller aktif olacak
        /// </summary>
        /// <param name="Tip">Bilgi İşlem: 0 - Satış: 1 - Finans: 2 - V.Gazanfer: 3 - Mustafa Torun: 4</param>
        private void KontrollerKontrolu(int Tip)
        {
            #region Tip 0
            if (Tip == 0)
            {
                cbSatisOnayli.Enabled = true;
                cbBilgiIslemOnayli.Enabled = true;
                cbPasif.Enabled = true;
                rbMusteri.Enabled = true;
                rbSatTem.Enabled = true;
                rbTumu.Enabled = true;

                cbOnayBekleyenler.Enabled = true;
                rbSatistaBekleyenler.Enabled = true;
                rbFinanstaBekleyenler.Enabled = true;
                rbBilgiIslemdeBekleyenler.Enabled = true;

                cmbUyeGruplari.Enabled = true;
                cmbUyeTipleri.Enabled = true;
                cbTaksitPlani.Enabled = true;
                cbSatisOnaylanmis.Enabled = true;
                cbBilgiIslemOnaylanmis.Enabled = true;
                cbPasifYapilmis.Enabled = true;
                btnKaydet.Enabled = true;

                lbFiyatTipleri.Enabled = true;
                lbFiyatTipleriYetkili.Enabled = true;
                btnFiyatTipiYetkiEkle.Enabled = true;
                btnFiyatTipiYetkiKaldir.Enabled = true;

                lbOzelKodlar.Enabled = true;
                lbOzelKodlarYetkili.Enabled = true;
                btnOzelKodYetkiEkle.Enabled = true;
                btnOzelKodYetkiKaldir.Enabled = true;

                lbGrupKodlar.Enabled = true;
                lbGrupKodlarYetkili.Enabled = true;
                btnGrupKodYetkiEkle.Enabled = true;
                btnGrupKodYetkiKaldir.Enabled = true;

                lbBayiIc.Enabled = true;
                lbBayiDis.Enabled = true;
                btnBayiAc.Enabled = true;
                btnBayiKapat.Enabled = true;

                btnCariHesabaBagla.Enabled = true;
                btnAltCariyeBagla.Enabled = true;
                btnSatisTemsilcisineBagla.Enabled = true;
                btnTalepEposta.Enabled = true;
                btnOnayEposta.Enabled = true;

                btnYeniUye.Enabled = true;
            }
            #endregion
            #region Tip 1
            else if (Tip == 1)
            {
                cbOnayBekleyenler.Enabled = true;
                cbOnayBekleyenler.Checked = true;
                rbFinanstaBekleyenler.Checked = false;
                rbSatistaBekleyenler.Checked = true;
                rbBilgiIslemdeBekleyenler.Checked = false;

                cmbUyeGruplari.Enabled = true;
                cbTaksitPlani.Enabled = true;
                btnKaydet.Enabled = true;

                lbFiyatTipleri.Enabled = true;
                lbFiyatTipleriYetkili.Enabled = true;
                btnFiyatTipiYetkiEkle.Enabled = true;
                btnFiyatTipiYetkiKaldir.Enabled = true;

                lbOzelKodlar.Enabled = true;
                lbOzelKodlarYetkili.Enabled = true;
                btnOzelKodYetkiEkle.Enabled = true;
                btnOzelKodYetkiKaldir.Enabled = true;

                lbGrupKodlar.Enabled = true;
                lbGrupKodlarYetkili.Enabled = true;
                btnGrupKodYetkiEkle.Enabled = true;
                btnGrupKodYetkiKaldir.Enabled = true;

                lbBayiIc.Enabled = true;
                lbBayiDis.Enabled = true;
                btnBayiAc.Enabled = true;
                btnBayiKapat.Enabled = true;

                btnCariHesabaBagla.Enabled = true;
                btnAltCariyeBagla.Enabled = true;
                btnSatisTemsilcisineBagla.Enabled = true;
                btnTalepEposta.Enabled = true;
                btnOnayEposta.Enabled = true;
            }
            #endregion
            #region Tip 2
            else if (Tip == 2)
            {
                cbOnayBekleyenler.Enabled = true;
                cbOnayBekleyenler.Checked = true;
                rbFinanstaBekleyenler.Checked = true;
                rbSatistaBekleyenler.Checked = false;
                rbBilgiIslemdeBekleyenler.Checked = false;
            }
            #endregion
            #region Tip 3
            else if (Tip == 3)
            {
                cbOnayBekleyenler.Enabled = true;
                cbOnayBekleyenler.Checked = true;
                rbFinanstaBekleyenler.Checked = false;
                rbSatistaBekleyenler.Checked = false;
                rbBilgiIslemdeBekleyenler.Checked = true;

                rbMusteri.Enabled = true;
                rbSatTem.Enabled = true;
                rbTumu.Enabled = true;

                lbFiyatTipleri.Enabled = true;
                lbFiyatTipleriYetkili.Enabled = true;
                btnFiyatTipiYetkiEkle.Enabled = true;
                btnFiyatTipiYetkiKaldir.Enabled = true;

                btnCariHesabaBagla.Enabled = true;
                btnAltCariyeBagla.Enabled = true;
            }
            #endregion
            #region Tip 4
            else if (Tip == 4)
            {
                rbMusteri.Enabled = true;
                rbSatTem.Enabled = true;
                rbTumu.Enabled = true;

                cbOnayBekleyenler.Enabled = true;
                cbOnayBekleyenler.Checked = true;
                rbFinanstaBekleyenler.Enabled = true;
                rbFinanstaBekleyenler.Checked = false;
                rbSatistaBekleyenler.Enabled = true;
                rbSatistaBekleyenler.Checked = true;
                rbBilgiIslemdeBekleyenler.Enabled = true;
                rbBilgiIslemdeBekleyenler.Checked = false;

                cmbUyeGruplari.Enabled = true;
                cbTaksitPlani.Enabled = true;
                cbPasifYapilmis.Enabled = true;
                btnKaydet.Enabled = true;

                lbFiyatTipleri.Enabled = true;
                lbFiyatTipleriYetkili.Enabled = true;
                btnFiyatTipiYetkiEkle.Enabled = true;
                btnFiyatTipiYetkiKaldir.Enabled = true;

                lbOzelKodlar.Enabled = true;
                lbOzelKodlarYetkili.Enabled = true;
                btnOzelKodYetkiEkle.Enabled = true;
                btnOzelKodYetkiKaldir.Enabled = true;

                lbGrupKodlar.Enabled = true;
                lbGrupKodlarYetkili.Enabled = true;
                btnGrupKodYetkiEkle.Enabled = true;
                btnGrupKodYetkiKaldir.Enabled = true;

                lbBayiIc.Enabled = true;
                lbBayiDis.Enabled = true;
                btnBayiAc.Enabled = true;
                btnBayiKapat.Enabled = true;

                btnCariHesabaBagla.Enabled = true;
                btnAltCariyeBagla.Enabled = true;
                btnSatisTemsilcisineBagla.Enabled = true;
                btnTalepEposta.Enabled = true;
                btnOnayEposta.Enabled = true;
            }
            #endregion
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObject(lbFiyatTipleri.Items, true);
        }

        private void GetOzelKodlar()
        {
            Urunler.GetOzelKodlar(lbOzelKodlar.Items);
        }

        private void GetGrupKodlar()
        {
            Urunler.GetGrupKodlar(lbGrupKodlar.Items);
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(lbBayiDis.Items, 0);
        }

        private void GetUyeTipleri()
        {
            UyeGruplari.GetObject(cmbUyeGruplari.Items, true);
        }

        private void GetUyeGruplari()
        {
            UyeTipleri.GetObject(cmbUyeTipleri.Items, true);
        }

        private void GetMusteriler()
        {
            Musteriler.GetObjects(ilkMusteriler, true);
            lblToplamUyeSayisi.Text = ilkMusteriler.Count.ToString();
            MusterilerSuz();
            lblAktifKullaniciSayisi.Text = Musteriler.KacKisiSistemde().ToString();
        }

        private void MusterilerSuz()
        {
            lbMusteriler.Items.Clear();
            int UyeTipiID = rbMusteri.Checked ? 1 : 4;

            for (int i = 0; i < ilkMusteriler.Count; i++)
            {
                if (((Musteriler)ilkMusteriler[i]).strAd.ToUpper().StartsWith(txtAramaAd.Text.Trim().ToUpper()) &&
                    ((Musteriler)ilkMusteriler[i]).strSoyad.ToUpper().StartsWith(txtAramaSoyad.Text.Trim().ToUpper()) &&
                    ((Musteriler)ilkMusteriler[i]).blSatisOnayi == cbSatisOnayli.Checked &&
                    ((Musteriler)ilkMusteriler[i]).blBilgiIslemOnayi == cbBilgiIslemOnayli.Checked &&
                    ((Musteriler)ilkMusteriler[i]).blPasif == cbPasif.Checked)
                {
                    if (!rbTumu.Checked && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID == Convert.ToByte(UyeTipiID))
                    {
                        lbMusteriler.Items.Add(ilkMusteriler[i]);
                    }
                    else if (rbTumu.Checked)
                    {
                        lbMusteriler.Items.Add(ilkMusteriler[i]);
                    }
                }
            }

            lblUyeSayisi.Text = lbMusteriler.Items.Count.ToString();
            lbMusteriler.SelectedIndex = -1;
            Temizle();
        }

        private void MusteriAyrintilariYaz()
        {
            Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
            txtKAdi.Text = musteri.binKullaniciAdi;
            txtSifre.Text = musteri.binSifre;
            txtEposta.Text = musteri.strEposta;
            txtTelefon.Text = musteri.strTelefon;
            txtVergiDairesi.Text = musteri.strVergiDairesi;
            txtVergiNo.Text = musteri.strVergiNo;
            txtUnvan.Text = musteri.strUnvan;
            txtIl.Text = Iller.GetObjectByID(((Musteriler)lbMusteriler.SelectedItem).tintIlID);

            if (cmbUyeGruplari.SelectedIndex == 0)
                cbTaksitPlani.Checked = musteri.blTaksitPlani;
            else if (cmbUyeGruplari.SelectedIndex > -1)
                cbTaksitPlani.Checked = ((UyeGruplari)cmbUyeGruplari.SelectedItem).blTaksitPlani;

            cbSicakSatis.Checked = musteri.blSicakSatis;

            cbSatisOnaylanmis.Checked = musteri.blSatisOnayi;
            cbBilgiIslemOnaylanmis.Checked = musteri.blBilgiIslemOnayi;
            cbPasifYapilmis.Checked = musteri.blPasif;

            lblBasvuruTarihi.Text = musteri.dtBasvuruTarihi.ToShortDateString() + " " + musteri.dtBasvuruTarihi.ToShortTimeString().Replace(":00", "");
            lblSatisOnayTarihi.Text = (musteri.blSatisOnayi && musteri.dtSatisOnayTarihi != DateTime.MinValue) ? musteri.dtSatisOnayTarihi.ToShortDateString() + " " + musteri.dtSatisOnayTarihi.ToShortTimeString().Replace(":00", "") : "-";
            lblBilgiIslemOnayTarihi.Text = (musteri.blBilgiIslemOnayi && musteri.dtBilgiIslemOnayTarihi != DateTime.MinValue) ? musteri.dtBilgiIslemOnayTarihi.ToShortDateString() + " " + musteri.dtBilgiIslemOnayTarihi.ToShortTimeString().Replace(":00", "") : "-";

            rbCHvar.Checked = musteri.blCHvar;
            rbCHyok.Checked = !musteri.blCHvar;
            btnTalepEposta.Visible = !musteri.blTalepEposta;
            btnOnayEposta.Visible = (musteri.blTalepEposta) ? !musteri.blOnayEposta : false;

            txtSatisTemsilcisi.Text = string.Empty;
            txtCariHesap.Text = string.Empty;

            btnCariHesabaBagla.Visible = false;
            btnAltCariyeBagla.Visible = false;
            btnSatisTemsilcisineBagla.Visible = false;
            if (musteri.intGMREF > 0)
            {
                if (musteri.tintUyeTipiID == 1) // müşteri ise
                {
                    ArrayList al = CariHesaplar.GetObjectByGMREF(musteri.intGMREF);
                    if (al.Count > 0)
                    {
                        btnCariHesabaBagla.Visible = false;
                        btnAltCariyeBagla.Visible = false;
                        txtCariHesap.Text = musteri.intGMREF.ToString() + " - " + al[1].ToString();
                        txtSatisTemsilcisi.Text = string.Empty;
                    }
                    else
                    {
                        btnCariHesabaBagla.Visible = false;
                        btnAltCariyeBagla.Visible = false;
                        txtCariHesap.Text = "-c/h bulunamıyor-";
                        txtSatisTemsilcisi.Text = string.Empty;
                    }
                }
                else if (musteri.tintUyeTipiID == 7) // altmüşteri ise
                {
                    ArrayList al = CariHesaplarTP.GetObjectBySMREF(musteri.intGMREF);
                    if (al.Count > 0)
                    {
                        btnCariHesabaBagla.Visible = false;
                        btnAltCariyeBagla.Visible = false;
                        txtCariHesap.Text = musteri.intGMREF.ToString() + " - " + al[1].ToString();
                        txtSatisTemsilcisi.Text = string.Empty;
                    }
                    else
                    {
                        btnCariHesabaBagla.Visible = false;
                        btnAltCariyeBagla.Visible = false;
                        txtCariHesap.Text = "-c/h bulunamıyor-";
                        txtSatisTemsilcisi.Text = string.Empty;
                    }
                }
            }
            if (musteri.intSLSREF > 0)
            {
                ArrayList al = SatisTemsilcileri.GetObjectBySLSREF(musteri.intSLSREF);
                btnSatisTemsilcisineBagla.Visible = false;
                txtSatisTemsilcisi.Text = musteri.intSLSREF.ToString() + " - " + al[0].ToString() + " - " + al[1].ToString();
                txtCariHesap.Text = string.Empty;
            }

            btnCariHesabaBagla.Visible = (/*musteri.intGMREF == 0 && */musteri.tintUyeTipiID == 1);
            btnAltCariyeBagla.Visible = (/*musteri.intGMREF == 0 && */musteri.tintUyeTipiID == 1);
            btnSatisTemsilcisineBagla.Visible = (musteri.intSLSREF == 0 && musteri.tintUyeTipiID == 4);

            lblDurum.Text = MusteriOnayDurumlari.GetObjectByID(musteri.tintMusteriDurumID);
            ArrayList List = new ArrayList();
            MusteriOnayDurumYetkileri.GetObjectByDurumID(List, musteri.tintMusteriDurumID, true);
            bool yetkili = false;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ToString().ToUpper() == frmAna.KAdi.ToUpper())
                {
                    yetkili = true;
                    break;
                }
            }

            cmbDurumIslem.Enabled = yetkili;

            GetSonrakiDurumlar(musteri.tintMusteriDurumID);
        }

        private void UyeGrupEsitle()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                for (int i = 0; i < cmbUyeGruplari.Items.Count; i++)
                {
                    if (((Musteriler)lbMusteriler.SelectedItem).intUyeGrupID == ((UyeGruplari)cmbUyeGruplari.Items[i]).pkUyeGrupID)
                    {
                        cmbUyeGruplari.SelectedIndex = i;
                        i = cmbUyeGruplari.Items.Count;
                    }
                }
            }
        }

        private void UyeTipEsitle()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                for (int i = 0; i < cmbUyeTipleri.Items.Count; i++)
                {
                    if (((Musteriler)lbMusteriler.SelectedItem).tintUyeTipiID == ((UyeTipleri)cmbUyeTipleri.Items[i]).pkUyeTipiID)
                    {
                        cmbUyeTipleri.SelectedIndex = i;
                        i = cmbUyeTipleri.Items.Count;
                    }
                }
            }
        }

        private void UyeFiyatTipEsitle()
        {
            GetFiyatTipleri();
            lbFiyatTipleriYetkili.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeFiyatTipleri.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbFiyatTipleri.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((FiyatTipleri)lbFiyatTipleri.Items[i]).NOSU == ((UyeFiyatTipleri)al[j]).sintFiyatTipiID)
                        {
                            lbFiyatTipleri.Items.RemoveAt(i);
                            arttirma = true;
                            lbFiyatTipleriYetkili.Items.Add((UyeFiyatTipleri)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void UyeOzelKodEsitle()
        {
            GetOzelKodlar();
            lbOzelKodlarYetkili.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeOzelKodlar.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbOzelKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((OzelKodlar)lbOzelKodlar.Items[i]).OZELKOD == ((UyeOzelKodlar)al[j]).strOzelKod)
                        {
                            lbOzelKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbOzelKodlarYetkili.Items.Add((UyeOzelKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void UyeGrupKodEsitle()
        {
            GetGrupKodlar();
            lbGrupKodlarYetkili.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrupKodlar.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbGrupKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((GrupKodlar)lbGrupKodlar.Items[i]).GRUPKOD == ((UyeGrupKodlar)al[j]).strGrupKod)
                        {
                            lbGrupKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbGrupKodlarYetkili.Items.Add((UyeGrupKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void BayiEsitle()
        {
            GetBayiler();
            lbBayiIc.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeBayiler.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbBayiDis.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((CariHesaplarTP)lbBayiDis.Items[i]).SMREF == ((UyeBayiler)al[j]).SMREF)
                        {
                            lbBayiDis.Items.RemoveAt(i);
                            arttirma = true;
                            lbBayiIc.Items.Add((UyeBayiler)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void Temizle()
        {
            //Deaktifet();

            cmbUyeTipleri.SelectedIndex = -1;
            cmbUyeGruplari.SelectedIndex = -1;
            GetFiyatTipleri();
            lbFiyatTipleriYetkili.Items.Clear();
            GetOzelKodlar();
            lbOzelKodlarYetkili.Items.Clear();
            GetGrupKodlar();
            lbGrupKodlarYetkili.Items.Clear();
            GetBayiler();
            lbBayiIc.Items.Clear();

            lblBasvuruTarihi.Text = "-";
            lblSatisOnayTarihi.Text = "-";
            lblBilgiIslemOnayTarihi.Text = "-";
            txtKAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            txtEposta.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtVergiDairesi.Text = string.Empty;
            txtVergiNo.Text = string.Empty;
            txtCariHesap.Text = string.Empty;
            txtSatisTemsilcisi.Text = string.Empty;
            lblDurum.Text = string.Empty;
            txtUnvan.Text = string.Empty;
            txtIl.Text = string.Empty;

            cmbDurumIslem.Items.Clear();

            btnCariHesabaBagla.Visible = false;
            btnAltCariyeBagla.Visible = false;

            //Aktifet();
        }

        private void Deaktifet()
        {
            cbTaksitPlani.Checked = false;
            cbTaksitPlani.Enabled = false;
            cbSatisOnaylanmis.Checked = false;
            cbSatisOnaylanmis.Enabled = false;
            cbBilgiIslemOnaylanmis.Checked = false;
            cbBilgiIslemOnaylanmis.Enabled = false;
            rbCHvar.Checked = false;
            rbCHvar.Enabled = false;
            rbCHyok.Checked = false;
            rbCHyok.Enabled = false;
            cbPasifYapilmis.Checked = false;
            cbPasifYapilmis.Enabled = false;
            
            gbFiyatTipiYetkileri.Enabled = false;
            gbOzelKodYetkileri.Enabled = false;
            gbGrupKodYetkileri.Enabled = false;
            gbBayiler.Enabled = false;
            cmbUyeTipleri.Enabled = false;
            cmbUyeGruplari.Enabled = false;

            btnCariHesabaBagla.Visible = false;
            btnAltCariyeBagla.Visible = false;
            btnSatisTemsilcisineBagla.Visible = false;

            btnIslemGecmisi.Enabled = false;
            btnKaydet.Enabled = false;
            cmbDurumIslem.Enabled = false;
            btnTalepEposta.Visible = false;
            btnOnayEposta.Visible = false;
        }

        private void Aktifet()
        {
            cbTaksitPlani.Enabled = true;
            cbSatisOnaylanmis.Enabled = true;
            cbBilgiIslemOnaylanmis.Enabled = true;
            rbCHvar.Enabled = true;
            rbCHyok.Enabled = true;
            cbPasifYapilmis.Checked = true;
            cbPasifYapilmis.Enabled = true;

            gbFiyatTipiYetkileri.Enabled = true;
            gbOzelKodYetkileri.Enabled = true;
            gbGrupKodYetkileri.Enabled = true;
            gbBayiler.Enabled = true;
            cmbUyeTipleri.Enabled = true;
            cmbUyeGruplari.Enabled = true;

            btnIslemGecmisi.Enabled = true;
            btnKaydet.Enabled = true;
            cmbDurumIslem.Enabled = true;
            btnTalepEposta.Visible = true;
            btnOnayEposta.Visible = true;
        }

        private void FiyatTipiYetkiEkle()
        {
            if (lbFiyatTipleri.SelectedIndex > -1)
            {
                UyeFiyatTipleri uft = new UyeFiyatTipleri(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((FiyatTipleri)lbFiyatTipleri.SelectedItem).NOSU);
                uft.DoInsert();
            }
        }

        private void FiyatTipiYetkiKaldir()
        {
            if (lbFiyatTipleriYetkili.SelectedIndex > -1)
            {
                UyeFiyatTipleri uft = (UyeFiyatTipleri)lbFiyatTipleriYetkili.SelectedItem;
                uft.DoDelete();
            }
        }

        private void BayiEkle()
        {
            if (lbBayiDis.SelectedIndex > -1)
            {
                UyeBayiler uok = new UyeBayiler(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((CariHesaplarTP)lbBayiDis.SelectedItem).SMREF);
                uok.DoInsert();
            }
        }

        private void BayiKaldir()
        {
            if (lbBayiIc.SelectedIndex > -1)
            {
                UyeBayiler uok = (UyeBayiler)lbBayiIc.SelectedItem;
                uok.DoDelete();
            }
        }

        private void OzelKodYetkiEkle()
        {
            if (lbOzelKodlar.SelectedIndex > -1)
            {
                UyeOzelKodlar uok = new UyeOzelKodlar(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((OzelKodlar)lbOzelKodlar.SelectedItem).OZELKOD);
                uok.DoInsert();
            }
        }

        private void OzelKodYetkiKaldir()
        {
            if (lbOzelKodlarYetkili.SelectedIndex > -1)
            {
                UyeOzelKodlar uok = (UyeOzelKodlar)lbOzelKodlarYetkili.SelectedItem;
                uok.DoDelete();
            }
        }

        private void GrupKodYetkiEkle()
        {
            if (lbGrupKodlar.SelectedIndex > -1)
            {
                // once o grupkoda ait butun ozelkod yetkilerini sil:
                ArrayList ozelkodlar = OzelKodlar.GetObjectsByGrupKod(((GrupKodlar)lbGrupKodlar.SelectedItem).GRUPKOD);
                for (int i = 0; i < ozelkodlar.Count; i++)
                {
                    UyeOzelKodlar uok = UyeOzelKodlar.GetObject(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((OzelKodlar)ozelkodlar[i]).OZELKOD);
                    if (uok.pkID != 0)
                        uok.DoDelete();
                }

                UyeGrupKodlar ugk = new UyeGrupKodlar(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((GrupKodlar)lbGrupKodlar.SelectedItem).GRUPKOD);
                ugk.DoInsert();
                for (int i = 0; i < ozelkodlar.Count; i++)
                {
                    UyeOzelKodlar uok = new UyeOzelKodlar(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((OzelKodlar)ozelkodlar[i]).OZELKOD);
                    uok.DoInsert();
                }
            }
        }

        private void GrupKodYetkiKaldir()
        {
            if (lbGrupKodlarYetkili.SelectedIndex > -1)
            {
                UyeGrupKodlar ugk = (UyeGrupKodlar)lbGrupKodlarYetkili.SelectedItem;
                ugk.DoDelete();

                ArrayList ozelkodlar = OzelKodlar.GetObjectsByGrupKod(ugk.strGrupKod);
                for (int i = 0; i < ozelkodlar.Count; i++)
                {
                    UyeOzelKodlar uok = UyeOzelKodlar.GetObject(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, ((OzelKodlar)ozelkodlar[i]).OZELKOD);
                    if (uok.pkID != 0)
                        uok.DoDelete();
                }
            }
        }

        private void UyeGrubuDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1 && cmbUyeGruplari.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).intUyeGrupID != ((UyeGruplari)cmbUyeGruplari.SelectedItem).pkUyeGrupID)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.intUyeGrupID = ((UyeGruplari)cmbUyeGruplari.SelectedItem).pkUyeGrupID;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).intUyeGrupID = ((UyeGruplari)cmbUyeGruplari.SelectedItem).pkUyeGrupID;
                }
            }
        }

        private void UyeTipiDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1 && cmbUyeTipleri.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).tintUyeTipiID != ((UyeTipleri)cmbUyeTipleri.SelectedItem).pkUyeTipiID)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.tintUyeTipiID = ((UyeTipleri)cmbUyeTipleri.SelectedItem).pkUyeTipiID;
                    if (((UyeTipleri)cmbUyeTipleri.SelectedItem).pkUyeTipiID == 2) musteri.intSLSREF = 0;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).tintUyeTipiID = ((UyeTipleri)cmbUyeTipleri.SelectedItem).pkUyeTipiID;
                }
            }
        }

        private void TaksitPlaniDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).blTaksitPlani != cbTaksitPlani.Checked)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.blTaksitPlani = cbTaksitPlani.Checked;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).blTaksitPlani = cbTaksitPlani.Checked;

                    UyeGrubunuZorunluDegistir();
                }
            }
        }

        private void SicakSatisDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).blSicakSatis != cbSicakSatis.Checked)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.blSicakSatis = cbSicakSatis.Checked;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).blSicakSatis = cbSicakSatis.Checked;
                }
            }
        }

        private void SatisOnayDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).blSatisOnayi != cbSatisOnaylanmis.Checked)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.blSatisOnayi = cbSatisOnaylanmis.Checked;
                    musteri.dtSatisOnayTarihi = DateTime.Now;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).blSatisOnayi = cbSatisOnaylanmis.Checked;

                    //cbSatisOnayli.Checked = cbSatisOnaylanmis.Checked;
                    //MusterilerSuz();
                    //lbMusteriler.SelectedItem = musteri;
                }
            }
        }

        private void BilgiIslemOnayDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).blBilgiIslemOnayi != cbBilgiIslemOnaylanmis.Checked)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.blBilgiIslemOnayi = cbBilgiIslemOnaylanmis.Checked;
                    musteri.dtBilgiIslemOnayTarihi = DateTime.Now;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).blBilgiIslemOnayi = cbBilgiIslemOnaylanmis.Checked;

                    //cbBilgiIslemOnayli.Checked = cbBilgiIslemOnaylanmis.Checked;
                    //MusterilerSuz();
                    //lbMusteriler.SelectedItem = musteri;
                }
            }
        }

        private void PasifDegistir()
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                if (((Musteriler)lbMusteriler.SelectedItem).blPasif != cbPasifYapilmis.Checked)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    musteri.blPasif = cbPasifYapilmis.Checked;
                    musteri.DoUpdate();
                    ((Musteriler)lbMusteriler.SelectedItem).blPasif = cbPasifYapilmis.Checked;

                    //cbPasif.Checked = cbPasifYapilmis.Checked;
                    //MusterilerSuz();
                    //lbMusteriler.SelectedItem = musteri;
                }
            }
        }

        private void UyeGrubunuZorunluDegistir()
        {
            cmbUyeGruplari.SelectedIndex = 0;
        }

        private void txtAramaAd_TextChanged(object sender, EventArgs e)
        {
            //MusterilerSuz();
        }

        private void cbSatisOnayli_CheckedChanged(object sender, EventArgs e)
        {
            //MusterilerSuz();
        }

        private void lbMusteriler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void lbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temizle();
            if (lbMusteriler.SelectedIndex < 0)
            {
                return;
            }

            lbMusteriler.Enabled = false;
            frmyukleniyor = new frmYukleniyor();
            frmyukleniyor.StartPosition = FormStartPosition.CenterScreen;
            frmyukleniyor.Show();
            //frmyukleniyor.Left = this.Left + 196;
            //frmyukleniyor.Top = this.Top + 76;
            //frmyukleniyor.Size = new System.Drawing.Size(this.Width - 24, this.Height - 30);
            System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ThreadStart(Get));
            thr.Start();
        }
        frmYukleniyor frmyukleniyor;
        private void Get()
        {
            UyeGrupEsitle();
            UyeTipEsitle();

            if (cmbUyeGruplari.SelectedIndex == 0)
            {
                gbFiyatTipiYetkileri.Enabled = true;
                gbOzelKodYetkileri.Enabled = true;
                gbGrupKodYetkileri.Enabled = true;
                gbBayiler.Enabled = true;

                UyeFiyatTipEsitle();
                UyeOzelKodEsitle();
                UyeGrupKodEsitle();
                BayiEsitle();
            }
            else
            {
                gbFiyatTipiYetkileri.Enabled = false;
                gbOzelKodYetkileri.Enabled = false;
                gbGrupKodYetkileri.Enabled = false;
                gbBayiler.Enabled = false;

                FiyatTipEsitle();
                OzelKodEsitle();
                GrupKodEsitle();
            }

            MusteriAyrintilariYaz();
            frmyukleniyor.Dispose();
            lbMusteriler.Enabled = true;
        }

        private void GetSonrakiDurumlar(byte MusteriDurumID)
        {
            MusteriOnayDurumlariSonrakiler.GetObjectByID(cmbDurumIslem.Items, MusteriDurumID);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            lbMusteriler.SelectedIndex = -1;
        }

        private void btnFiyatTipiYetkiEkle_Click(object sender, EventArgs e)
        {
            FiyatTipiYetkiEkle();
            UyeFiyatTipEsitle();
            //UyeGrubunuZorunluDegistir();
        }

        private void btnFiyatTipiYetkiKaldir_Click(object sender, EventArgs e)
        {
            FiyatTipiYetkiKaldir();
            UyeFiyatTipEsitle();
            //UyeGrubunuZorunluDegistir();
        }

        private void btnOzelKodYetkiEkle_Click(object sender, EventArgs e)
        {
            OzelKodYetkiEkle();
            UyeOzelKodEsitle();
            //UyeGrubunuZorunluDegistir();
        }

        private void btnOzelKodYetkiKaldir_Click(object sender, EventArgs e)
        {
            OzelKodYetkiKaldir();
            UyeOzelKodEsitle();
            //UyeGrubunuZorunluDegistir();
        }

        private void btnGrupKodYetkiEkle_Click(object sender, EventArgs e)
        {
            GrupKodYetkiEkle();
            UyeGrupKodEsitle();
            UyeOzelKodEsitle();
            //UyeGrubunuZorunluDegistir();
        }

        private void btnGrupKodYetkiKaldir_Click(object sender, EventArgs e)
        {
            GrupKodYetkiKaldir();
            UyeGrupKodEsitle();
            UyeOzelKodEsitle();
            //UyeGrubunuZorunluDegistir();
        }

        private void lbFiyatTipleri_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnFiyatTipiYetkiEkle.PerformClick();
        }

        private void lbFiyatTipleriYetkili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnFiyatTipiYetkiKaldir.PerformClick();
        }

        private void lbBayiDis_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnBayiAc.PerformClick();
        }

        private void lbBayiIc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnBayiKapat.PerformClick();
        }

        private void lbOzelKodlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOzelKodYetkiEkle.PerformClick();
        }

        private void lbOzelKodlarYetkili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOzelKodYetkiKaldir.PerformClick();
        }

        private void lbGrupKodlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnGrupKodYetkiEkle.PerformClick();
        }

        private void lbGrupKodlarYetkili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnGrupKodYetkiKaldir.PerformClick();
        }

        private void cbTaksitPlani_CheckedChanged(object sender, EventArgs e)
        {
            //TaksitPlaniDegistir();
        }

        private void cmbUyeGruplari_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UyeGrubuDegistir();

            //if (cmbUyeGruplari.SelectedIndex > 0)
            //{
            //    gbFiyatTipiYetkileri.Enabled = false;
            //    gbGrupKodYetkileri.Enabled = false;
            //    gbOzelKodYetkileri.Enabled = false;
            //    cbTaksitPlani.Enabled = false;

            //    cbTaksitPlani.Checked = ((UyeGruplari)cmbUyeGruplari.SelectedItem).blTaksitPlani;
            //    FiyatTipEsitle();
            //    OzelKodEsitle();
            //    GrupKodEsitle();
            //}
            //else if (cmbUyeGruplari.SelectedIndex == 0)
            //{
            //    gbFiyatTipiYetkileri.Enabled = true;
            //    gbGrupKodYetkileri.Enabled = true;
            //    gbOzelKodYetkileri.Enabled = true;
            //    cbTaksitPlani.Enabled = true;

            //    if (lbMusteriler.SelectedIndex > -1)
            //        cbTaksitPlani.Checked = ((Musteriler)lbMusteriler.SelectedItem).blTaksitPlani;
            //    UyeFiyatTipEsitle();
            //    UyeOzelKodEsitle();
            //    UyeGrupKodEsitle();
            //}
        }

        private void cmbUyeTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UyeTipiDegistir();
        }

        private void cbSatisOnaylanmis_CheckedChanged(object sender, EventArgs e)
        {
            //SatisOnayDegistir();
        }

        private void cbBilgiIslemOnaylanmis_CheckedChanged(object sender, EventArgs e)
        {
            //BilgiIslemOnayDegistir();
        }

        private void btnCariHesabaBagla_Click(object sender, EventArgs e)
        {
            frmINTERNETsatistemsilcileri frm = new frmINTERNETsatistemsilcileri(txtVergiNo.Text);
            frm.ShowDialog();
            if (GMREF > 0)
            {
                txtCariHesap.Text = MUSKOD + " - " + MUSTERI;
                Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                musteri.intGMREF = GMREF;

                musteri.strUnvan = MUSTERI;

                musteri.DoUpdate();
                ((Musteriler)lbMusteriler.SelectedItem).intGMREF = GMREF;
                btnCariHesabaBagla.Visible = false;
                btnAltCariyeBagla.Visible = false;
                GMREF = 0;
            }
        }

        private void btnAltCariyeBagla_Click(object sender, EventArgs e)
        {
            frmINTERNETsatistemsilcileri frm = new frmINTERNETsatistemsilcileri(txtUnvan.Text, true);
            frm.ShowDialog();
            if (SMREF > 0)
            {
                txtCariHesap.Text = MUSTERI;
                Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                musteri.intGMREF = SMREF;
                musteri.tintUyeTipiID = 7;

                musteri.strUnvan = MUSTERI;

                musteri.DoUpdate();
                ((Musteriler)lbMusteriler.SelectedItem).intGMREF = SMREF;
                btnAltCariyeBagla.Visible = false;
                SMREF = 0;
            }
        }

        private void btnSatisTemsilcisineBagla_Click(object sender, EventArgs e)
        {
            frmINTERNETsatistemsilcileri1 frm = new frmINTERNETsatistemsilcileri1();
            frm.ShowDialog();
            if (SLSREF > 0)
            {
                txtSatisTemsilcisi.Text = SATKOD1 + " - " + SATTEM;
                Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                musteri.intSLSREF = SLSREF;

                musteri.strTelefon = SatisTemsilcileri.GetTELEFONBySLSREF(musteri.intSLSREF);
                musteri.strVergiDairesi = string.Empty;

                musteri.DoUpdate();
                ((Musteriler)lbMusteriler.SelectedItem).intSLSREF = SLSREF;
                btnSatisTemsilcisineBagla.Visible = false;
                SLSREF = 0;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                UyeGrubuDegistir();
                UyeTipiDegistir();
                TaksitPlaniDegistir();
                SicakSatisDegistir();
                SatisOnayDegistir();
                BilgiIslemOnayDegistir();
                PasifDegistir();

                if (((Musteriler)lbMusteriler.SelectedItem).blSatisOnayi != cbSatisOnayli.Checked ||
                    ((Musteriler)lbMusteriler.SelectedItem).blBilgiIslemOnayi != cbBilgiIslemOnayli.Checked ||
                    ((Musteriler)lbMusteriler.SelectedItem).blPasif != cbPasif.Checked)
                {
                    Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                    cbSatisOnayli.Checked = musteri.blSatisOnayi;
                    cbBilgiIslemOnayli.Checked = musteri.blBilgiIslemOnayi;
                    cbPasif.Checked = musteri.blPasif;
                    btnMusterilerSuz.PerformClick();
                    lbMusteriler.SelectedItem = musteri;
                }
            }
            else
            {
                MessageBox.Show("Bir üye seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbDurumIslem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDurumIslem.SelectedIndex == -1)
                return;

            if (MessageBox.Show("Emin misiniz?", "Üye Durumu", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                byte YeniDurumID = ((MusteriOnayDurumlari)cmbDurumIslem.SelectedItem).pkDurumID;
                musteri.tintMusteriDurumID = YeniDurumID;
                musteri.DoUpdate();
                ((Musteriler)lbMusteriler.SelectedItem).tintMusteriDurumID = YeniDurumID;

                MusteriOnayDurumHareketleri modh = new MusteriOnayDurumHareketleri
                    (musteri.pkMusteriID, YeniDurumID, DateTime.Now, frmAna.KAdi.ToUpper());
                modh.DoInsert();

                if (YeniDurumID == 2) // satış ve finans onayları tamamlanmışsa
                {
                    cbSatisOnaylanmis.Checked = true;
                    SatisOnayDegistir();
                }
                else if (YeniDurumID == 8) // satış ve finans onayları tamamlanmışsa
                {
                    cbBilgiIslemOnaylanmis.Checked = true;
                    BilgiIslemOnayDegistir();
                }

                lblDurum.Text = MusteriOnayDurumlari.GetObjectByID(YeniDurumID);
                GetSonrakiDurumlar(YeniDurumID);
            }
            else
            {
                cmbDurumIslem.SelectedIndex = -1;
            }
        }

        private void btnMusterilerSuz_Click(object sender, EventArgs e)
        {
            MusterilerSuz();
        }

        private void btnYeniUye_Click(object sender, EventArgs e)
        {
            frmINTERNETyenimusteri frm = new frmINTERNETyenimusteri();
            frm.ShowDialog();
            GetMusteriler();
        }

        private void rbCHvar_CheckedChanged(object sender, EventArgs e)
        {
            if (lbMusteriler.SelectedIndex > -1)
                rbCHvar.Checked = ((Musteriler)lbMusteriler.SelectedItem).blCHvar;
        }

        private void rbCHyok_CheckedChanged(object sender, EventArgs e)
        {
            if (lbMusteriler.SelectedIndex > -1)
                rbCHyok.Checked = !((Musteriler)lbMusteriler.SelectedItem).blCHvar;
        }

        private void btnIslemGecmisi_Click(object sender, EventArgs e)
        {
            if (lbMusteriler.SelectedIndex > -1)
            {
                frmINTERNETmusterionaydurumharaketleri frm = new frmINTERNETmusterionaydurumharaketleri(((Musteriler)lbMusteriler.SelectedItem).pkMusteriID);
                frm.ShowDialog();
            }
        }

        private void cbOnayBekleyenler_CheckedChanged(object sender, EventArgs e)
        {
            gbSuzme.Enabled = !cbOnayBekleyenler.Checked;
            cbSatisOnayli.Checked = true;
            cbBilgiIslemOnayli.Checked = true;
            rbMusteri.Checked = true;
            rbSatTem.Checked = false;
            rbTumu.Checked = false;
            cbPasif.Checked = false;
            txtAramaAd.Text = string.Empty;
            txtAramaSoyad.Text = string.Empty;

            rbFinanstaBekleyenler.Visible = cbOnayBekleyenler.Checked;
            rbSatistaBekleyenler.Visible = cbOnayBekleyenler.Checked;
            rbBilgiIslemdeBekleyenler.Visible = cbOnayBekleyenler.Checked;

            if (cbOnayBekleyenler.Checked)
                MusterilerSuz2();
            else
                MusterilerSuz();
        }

        private void MusterilerSuz2()
        {
            lbMusteriler.Items.Clear();

            if (rbFinanstaBekleyenler.Checked)
            {
                for (int i = 0; i < ilkMusteriler.Count; i++)
                {
                    if (((Musteriler)ilkMusteriler[i]).blPasif == false && ((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 3)
                    {
                        lbMusteriler.Items.Add(ilkMusteriler[i]);
                    }
                }
            }
            else if (rbSatistaBekleyenler.Checked)
            {
                for (int i = 0; i < ilkMusteriler.Count; i++)
                {
                    if (((Musteriler)ilkMusteriler[i]).blPasif == false &&
                        (((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 1 ||
                        ((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 4 ||
                        ((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 5 ||
                        ((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 7))
                    {
                        lbMusteriler.Items.Add(ilkMusteriler[i]);
                    }
                }
            }
            else if (rbBilgiIslemdeBekleyenler.Checked)
            {
                for (int i = 0; i < ilkMusteriler.Count; i++)
                {
                    if (((Musteriler)ilkMusteriler[i]).blPasif == false && (((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 2 || ((Musteriler)ilkMusteriler[i]).tintMusteriDurumID == 6))
                    {
                        lbMusteriler.Items.Add(ilkMusteriler[i]);
                    }
                }
            }

            lblUyeSayisi.Text = lbMusteriler.Items.Count.ToString();
            lbMusteriler.SelectedIndex = -1;
            Temizle();
        }

        private void rbFinanstaBekleyenler_CheckedChanged(object sender, EventArgs e)
        {
            MusterilerSuz2();
        }

        private void btnTalepEposta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Talebiniz alındı epostası gönderilsin mi?", "Eposta Gönder", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                EpostaGonder(txtEposta.Text, "Üyelik Talebi", "Üyelik talebiniz alınmıştır. En kısa sürede size dönülecektir.");
                Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                musteri.blTalepEposta = true;
                musteri.DoUpdate();
                lbMusteriler.SelectedItem = musteri;
                MessageBox.Show("Gönderildi.                         ", "Üyelik Talep Alındı Gönderimi");
                btnTalepEposta.Visible = false;
                btnOnayEposta.Visible = true;
            }
        }

        private void btnOnayEposta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Üyeliğiniz onaylandı epostası gönderilsin mi?", "Eposta Gönder", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                EpostaGonder(txtEposta.Text, "Üyelik Talebi", "Üyeliğiniz onaylanmıştır. Eposta adresiniz ve şifreniz ile sisteme giriş yapabilirsiniz. https://www.sultanlar.com.tr/musteri");
                Musteriler musteri = (Musteriler)lbMusteriler.SelectedItem;
                musteri.blOnayEposta = true;
                musteri.DoUpdate();
                lbMusteriler.SelectedItem = musteri;
                MessageBox.Show("Gönderildi.                        ", "Üyelik Onay Gönderimi");
                btnOnayEposta.Visible = false;
            }
        }

        private void EpostaGonder(string Eposta, string Konu, string Icerik)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.NameSpace onS = (Microsoft.Office.Interop.Outlook.NameSpace)oApp.GetNamespace("mapi");
                //onS.Logon(null, null, true, true);
                //Microsoft.Office.Interop.Outlook.MailItem oMsg =
                //    (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //oMsg.To = Eposta;
                //oMsg.Subject = Konu;
                //oMsg.Body = Icerik;


                //oMsg.Send();

                //onS.Logoff();

                //oMsg = null;
                //onS = null;
                //oApp = null;
                //GC.Collect();


                MailMessage mail = new MailMessage("bilgi@sultanlar.com.tr", Eposta);
                mail.IsBodyHtml = true;
                mail.To.Add("bilgi@sultanlar.com.tr");
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("bilgi@sultan", "987456");
                client.Host = "mail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.Body = Icerik;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "Üye Kaydı Eposta Gönderimi");
            }
            Cursor.Current = Cursors.AppStarting;
        }

        private void lblAktifKullaniciSayisi_Click(object sender, EventArgs e)
        {
            if (lblAktifKullaniciSayisi.Text != "0")
            {
                frmINTERNETmusterilersistemde frm = new frmINTERNETmusterilersistemde();
                frm.ShowDialog();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            ilkMusteriler = new ArrayList();
            GetMusteriler();
            cbOnayBekleyenler.Checked = false;
        }

        private void cbAlfabetik_CheckedChanged(object sender, EventArgs e)
        {
            lbMusteriler.Sorted = cbAlfabetik.Checked;
            btnYenile.PerformClick();
        }

        #region UyeGrubuYetkileri
        private void FiyatTipEsitle()
        {
            GetFiyatTipleri();
            lbFiyatTipleriYetkili.Items.Clear();

            if (cmbUyeGruplari.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrubuFiyatTipleri.GetObject(al, ((UyeGruplari)cmbUyeGruplari.SelectedItem).pkUyeGrupID, true);

                for (int i = 0; i < lbFiyatTipleri.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((FiyatTipleri)lbFiyatTipleri.Items[i]).NOSU == ((UyeGrubuFiyatTipleri)al[j]).sintFiyatTipiID)
                        {
                            lbFiyatTipleri.Items.RemoveAt(i);
                            arttirma = true;
                            lbFiyatTipleriYetkili.Items.Add((UyeGrubuFiyatTipleri)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void OzelKodEsitle()
        {
            GetOzelKodlar();
            lbOzelKodlarYetkili.Items.Clear();

            if (cmbUyeGruplari.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrubuOzelKodlar.GetObject(al, ((UyeGruplari)cmbUyeGruplari.SelectedItem).pkUyeGrupID, true);

                for (int i = 0; i < lbOzelKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((OzelKodlar)lbOzelKodlar.Items[i]).OZELKOD == ((UyeGrubuOzelKodlar)al[j]).strOzelKod)
                        {
                            lbOzelKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbOzelKodlarYetkili.Items.Add((UyeGrubuOzelKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void GrupKodEsitle()
        {
            GetGrupKodlar();
            lbGrupKodlarYetkili.Items.Clear();

            if (cmbUyeGruplari.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrubuGrupKodlar.GetObject(al, ((UyeGruplari)cmbUyeGruplari.SelectedItem).pkUyeGrupID, true);

                for (int i = 0; i < lbGrupKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((GrupKodlar)lbGrupKodlar.Items[i]).GRUPKOD == ((UyeGrubuGrupKodlar)al[j]).strGrupKod)
                        {
                            lbGrupKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbGrupKodlarYetkili.Items.Add((UyeGrubuGrupKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }
        #endregion

        private void rbOzelKodYetkileri_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOzelKodYetkileri.Checked)
            {
                gbOzelKodYetkileri.BringToFront();
                gbGrupKodYetkileri.SendToBack();
                gbBayiler.SendToBack();
            }
            else if (rbGrupKodYetkileri.Checked)
            {
                gbGrupKodYetkileri.BringToFront();
                gbOzelKodYetkileri.SendToBack();
                gbBayiler.SendToBack();
            }
            else if (rbBayiYetki.Checked)
            {
                gbBayiler.BringToFront();
                gbOzelKodYetkileri.SendToBack();
                gbGrupKodYetkileri.SendToBack();
            }
        }

        private void btnMusteriBilgiEposta_Click(object sender, EventArgs e)
        {
            string chvar = rbCHvar.Checked ? "Var" : "Yok";

            //EpostaAc("", "Yeni Müşteri Kaydı Bilgileri",
            //    "Aşağıda iletişim bilgileri bulunan ve webden üye başvurusu yapan müşteri adayı ile iletişime geçilerek o bölgeye bakan satış temsilcisi arkadaşımızın yönlendirilmesi ve tarafıma olumlu yada olumsuz bilgi verilmesi önemle rica olunur.<br><br>" +
            //    "<table><tr>" +
            //    "<td><b>Başvuru Tarihi:</b> </td><td>" + lblBasvuruTarihi.Text +
            //    "</td></tr><tr><td><b>Cari Hesabı:</b> </td><td>" + chvar +
            //    "</td></tr><tr><td><b>Müşteri Unvanı:</b> </td><td>" + txtUnvan.Text +
            //    "</td></tr><tr><td><b>Eposta:</b> </td><td>" + txtEposta.Text +
            //    "</td></tr><tr><td><b>Telefon:</b> </td><td>" + txtTelefon.Text +
            //    "</td></tr><tr><td><b>Vergi Dairesi:</b> </td><td>" + txtVergiDairesi.Text +
            //    "</td></tr><tr><td><b>Vergi No veya TC No:</b> &nbsp;&nbsp;&nbsp;</td><td>" + txtVergiNo.Text +
            //    "</td></tr><tr><td><b>İl:</b> </td><td>" + txtIl.Text +
            //    "</td></tr></table>"
            //    );

            EpostaGonder("fkaya@sultanlar.com.tr", "Yeni Müşteri Kaydı Bilgileri", "" +
                "Aşağıda iletişim bilgileri bulunan ve webden üye başvurusu yapan müşteri adayı ile iletişime geçilerek o bölgeye bakan satış temsilcisi arkadaşımızın yönlendirilmesi ve tarafıma olumlu yada olumsuz bilgi verilmesi önemle rica olunur.<br><br>" +
                "<table><tr>" +
                "<td><b>Başvuru Tarihi:</b> </td><td>" + lblBasvuruTarihi.Text +
                "</td></tr><tr><td><b>Cari Hesabı:</b> </td><td>" + chvar +
                "</td></tr><tr><td><b>Müşteri Unvanı:</b> </td><td>" + txtUnvan.Text +
                "</td></tr><tr><td><b>Eposta:</b> </td><td>" + txtEposta.Text +
                "</td></tr><tr><td><b>Telefon:</b> </td><td>" + txtTelefon.Text +
                "</td></tr><tr><td><b>Vergi Dairesi:</b> </td><td>" + txtVergiDairesi.Text +
                "</td></tr><tr><td><b>Vergi No veya TC No:</b> &nbsp;&nbsp;&nbsp;</td><td>" + txtVergiNo.Text +
                "</td></tr><tr><td><b>İl:</b> </td><td>" + txtIl.Text +
                "</td></tr></table>");
        }

        private void EpostaAc(string Eposta, string Konu, string Icerik)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.NameSpace onS = (Microsoft.Office.Interop.Outlook.NameSpace)oApp.GetNamespace("mapi");
                onS.Logon(null, null, true, true);
                Microsoft.Office.Interop.Outlook.MailItem oMsg =
                    (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                oMsg.To = Eposta;
                oMsg.Subject = Konu;
                oMsg.HTMLBody = Icerik;
                
                oMsg.Display(true);

                onS.Logoff();

                oMsg = null;
                onS = null;
                oApp = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "Üye Şifre Sıfırlama Eposta Gönderimi");
            }
            Cursor.Current = Cursors.AppStarting;
        }

        private void txtAramaAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnMusterilerSuz.PerformClick();
        }

        private void btnBayiAc_Click(object sender, EventArgs e)
        {
            BayiEkle();
            BayiEsitle();
        }

        private void btnBayiKapat_Click(object sender, EventArgs e)
        {
            BayiKaldir();
            BayiEsitle();
        }
    }
}
