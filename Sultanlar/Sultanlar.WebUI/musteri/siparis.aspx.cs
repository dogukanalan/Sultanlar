using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.Web.Security;
using Sultanlar.DatabaseObject;
// anlaşmalı noktalarda f3 ve f7 siparişlerini engellemek için ddlFiyatTipleri.SelectedItem.Value arat (sipariş kopyalamayı da engelle)
namespace Sultanlar.WebUI.musteri
{
    public partial class siparis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            
            
            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5) // perakende müşteri değil ise
                {
                    if ((Session["SiparisID"] == null && Session["Siparis"] == null) || Session["SMREF"] == null || Session["Musteri"] == null || Session["Yetkiler"] == null)
                        Response.Redirect("default.aspx", true);
                }
                else
                {
                    //Response.Redirect("yetkiyok.aspx", true);
                }



                if (Session["FiyatTipi"].ToString() == "2")
                {
                    Response.Redirect("siparis2.aspx", true);
                }

                

                if (Convert.ToInt32(Session["SiparisID"]) == 0)
                {
                    int smref = Convert.ToInt32(Session["SMREF"]);
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri  ise
                    {
                        smref = 24479; // perakende müşteriler için kredi kartı satış carisi gözükmesi için
                        rbResimDuzeni.Checked = true;
                        rbListeDuzeni.Checked = false;
                    }

                    string aciklama1 = string.Empty;
                    SiparisListe siplist;
                    if (Session["SiparisSahibiMusteriID"] != null)
                    {
                        siplist = new SiparisListe((int)Session["SiparisSahibiMusteriID"], smref, Convert.ToInt16(Session["FiyatTipi"]), true);
                        Session["SiparisYetkiler"] = new UyeYetkileri((int)Session["SiparisSahibiMusteriID"]);
                        Session["SiparisSahibiMusteriID"] = null;

                        Musteriler musteri = Musteriler.GetMusteriByID((int)Session["SiparisGirenMusteriID"]);
                        aciklama1 = musteri.strAd + " " + musteri.strSoyad;
                    }
                    else
                    {
                        siplist = new SiparisListe(((Musteriler)Session["Musteri"]).pkMusteriID, smref, Convert.ToInt16(Session["FiyatTipi"]), true);
                        Session["SiparisYetkiler"] = Session["Yetkiler"];
                        
                        aciklama1 = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
                    }
                    //((Musteriler)Session["Musteri"]).intSonYarimSiparisID = siplist._SiparisID;
                    //((Musteriler)Session["Musteri"]).DoUpdate();

                    txtSiparisAciklama3.Text = DateTime.Now.ToShortDateString().Replace(".", "/");

                    siplist.AciklamaGuncelle(aciklama1, txtSiparisAciklama2.Text.Trim(), txtSiparisAciklama3.Text.Trim());
                    Session["Siparis"] = siplist;
                }
                //else if (Convert.ToInt32(Session["SiparisID"]) == 1) // aktivite ise
                //{
                //    int smref = Convert.ToInt32(Session["SMREF"]);

                //    string aciklama1 = string.Empty;
                //    SiparisListe siplist;
                //    if (Session["SiparisSahibiMusteriID"] != null)
                //    {
                //        siplist = new SiparisListe((int)Session["SiparisSahibiMusteriID"], smref, Convert.ToInt16(Session["FiyatTipi"]), true);
                //        Session["SiparisYetkiler"] = new UyeYetkileri((int)Session["SiparisSahibiMusteriID"]);
                //        Session["SiparisSahibiMusteriID"] = null;

                //        Musteriler musteri = Musteriler.GetMusteriByID((int)Session["SiparisGirenMusteriID"]);
                //        aciklama1 = musteri.strAd + " " + musteri.strSoyad;
                //    }
                //    else
                //    {
                //        siplist = new SiparisListe(((Musteriler)Session["Musteri"]).pkMusteriID, smref, Convert.ToInt16(Session["FiyatTipi"]), true);
                //        Session["SiparisYetkiler"] = Session["Yetkiler"];

                //        aciklama1 = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
                //    }

                //    siplist.AciklamaGuncelle(aciklama1, txtSiparisAciklama2.Text.Trim(), "AKTIVITE");
                //    Session["Siparis"] = siplist;
                //    txtSiparisAciklama3.Visible = false;
                //}
                else
                {
                    Siparisler sip = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(Session["SiparisID"]));
                    if (sip.pkSiparisID == 0)
                    {
                        Session["SiparisID"] = null;
                        Response.Redirect("default.aspx", true);
                    }

                    if (Session["FiyatTipiDegisti"] == null)
                    {
                        if (Session["RISKBAKIYE"] == null)
                            Session["RISKBAKIYE"] = CariHesaplar.GetRISKBKYByGMREF(Convert.ToInt32(Session["SMREF"]));

                        GetSiparisFromDB();
                    }
                    else
                    {
                        Session["FiyatTipiDegisti"] = null;
                        SepetBilgisiGuncelle();
                    }
                }
                Session["SiparisID"] = null;



                Session["SepetUrunSecimleri"] = new ArrayList();
                //Session["BarkodArama"] = false;
                Session["Tedarikci"] = "NOT NULL";
                Session["OncekiTedarikci"] = "NOT NULL";
                Session["Kategori"] = "NOT NULL";
                Session["OncekiKategori"] = "NOT NULL";
                Session["Aranan"] = "";
                Session["Siralama"] = "TedarikciAdi";
                Session["AzalanArtan"] = "ASC";
                Session["Aktarim"] = "";
                Session["Start"] = 0;
                Session["Count"] = ((Musteriler)Session["Musteri"]).intSiparisUrunSayisi;

                Session["MaxRecordCount"] = GetProductsCount();

                GetUstBilgiler();

                Session["SMREF"] = null;

                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);

                if (((SiparisListe)Session["Siparis"]).Items.Count > 0)
                    ibSepetBuyut.ImageUrl = "img/sepet-dolu.png";

                lblUrunAyrintiTedarikciIlgili.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;
                //hlSatistaOnAdim.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
                {
                    //divSatistaOnAdim.Visible = !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8");
                    //OneriSiparisi();
                }

                Session["FiyatTipi"] = null;
            }
            else
            {
                AciklamalariGuncelle(); // siparisliste ye yeni alan açmaya üşendiğim için
                btnSiparisiTamamlaOnayla.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID != 1 || ((Musteriler)Session["Musteri"]).blSicakSatis;
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(DivAjax, typeof(string), "kucukbilgi", alert, false);
        }

        #region SepetBilgisiGuncelle
        private void SepetBilgisiGuncelle()
        {
            SiparisListe siplist = (SiparisListe)Session["Siparis"];

            lblToplamTutar.Text = siplist.ToplamTutar.ToString("C3");

            siplist._TKSREF = TaksitPlanlari.GetODMREF(siplist.OrtalamaVade);
            siplist.SiparisiVeritabanindaGuncelle();

            if (((SiparisListe)Session["Siparis"]).Items.Count > 0)
                ibSepetBuyut.ImageUrl = "img/sepet-dolu.png";
            else
                ibSepetBuyut.ImageUrl = "img/sepet.png";

            //SiparisListe siplist = (SiparisListe)Session["Siparis"];
            //int sonurunindex = siplist.Items.Count - 1;

            //if (sonurunindex > -1)
            //{
            //    SiparisDetayi sipdet = (SiparisDetayi)siplist[sonurunindex];
            //    lblSepetUrun1.Text = sipdet._UrunAdi;
            //    lblSepetAdet1.Text = sipdet._Miktar.ToString();
            //    lblSepetToplam1.Text = (sipdet._BirimFiyat * sipdet._Miktar).ToString("C3");
            //}

            //int urunsayisi = 0;
            //int cesitsayisi = 0;
            //ArrayList al = new ArrayList();
            //for (int i = 0; i < siplist.Items.Count; i++)
            //{
            //    bool var = false;
            //    for (int j = 0; j < al.Count; j++)
            //    {
            //        if (Convert.ToInt32(al[j]) == ((SiparisDetayi)siplist.Items[i])._UrunID)
            //        {
            //            var = true;
            //            j = al.Count;
            //        }
            //    }
            //    if (!var)
            //    {
            //        al.Add(((SiparisDetayi)siplist.Items[i])._UrunID);
            //        cesitsayisi++;
            //    }
            //    urunsayisi += ((SiparisDetayi)siplist.Items[i])._Miktar;
            //}
            //lblSepetUrunSayisi.Text = urunsayisi.ToString();
            //lblSepetCesitSayisi.Text = cesitsayisi.ToString();
        }
        #endregion

        #region GetUstBilgiler
        private void GetUstBilgiler()
        {
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            divRiskBakiyesi.Visible = (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 1);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5) // perakende müşteri değil ise
            {
                lblCariHesap.Text = CariHesaplar.GetObjectBySMREF(Convert.ToInt32(Session["SMREF"]))[1].ToString() + " : " + CariHesaplar.GetSubeBySMREF(Convert.ToInt32(Session["SMREF"]))[1].ToString();
                if (lblCariHesap.Text.EndsWith(" : "))
                    lblCariHesap.Text = lblCariHesap.Text.Substring(0, lblCariHesap.Text.Length - 3);
            }

            lblSiparisID.Text = ((SiparisListe)Session["Siparis"])._SiparisID.ToString();

            for (int i = 0; i < ((UyeYetkileri)Session["SiparisYetkiler"]).FiyatTipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(((UyeYetkileri)Session["SiparisYetkiler"]).FiyatTipler[i]);
                ddlFiyatTipleri.Items.Add(FiyatTipleri.GetObjectByID(fiyattipiid));
                ddlFiyatTipleri.Items[i].Value = fiyattipiid.ToString();
            }
            ddlFiyatTipleri.SelectedValue = ((SiparisListe)Session["Siparis"])._FiyatTipi.ToString();

            GetTaksitPlani();
        }
        #endregion

        #region GetTaksitPlani
        private void GetTaksitPlani()
        {
            if (((Musteriler)Session["Musteri"]).blTaksitPlani)
            {
                TaksitPlanlari.GetObjects(ddlTaksitPlanlari.Items, Convert.ToInt32(((SiparisListe)Session["Siparis"])._FiyatTipi));
                if (ddlTaksitPlanlari.Items.Count > 0)
                {
                    if (ddlTaksitPlanlari.Items.Count > 1) // TaksitPlanlari.TaksitMi(((SiparisListe)Session["Siparis"])._TKSREF)
                    {
                        ((SiparisListe)Session["Siparis"])._TKSREF = Convert.ToInt32(ddlTaksitPlanlari.Items[1].Value);
                        ((SiparisListe)Session["Siparis"]).SiparisiVeritabanindaGuncelle();
                        ddlTaksitPlanlari.SelectedValue = ((SiparisListe)Session["Siparis"])._TKSREF.ToString();
                    }
                }
            }
            else
            {
                ListItem lst1 = new ListItem();
                lst1.Text = "Seçim Yok";
                lst1.Value = "0";
                ddlTaksitPlanlari.Items.Add(lst1);
            }
        }
        #endregion

        #region FiyatTipiDegistir
        private void FiyatTipiDegistir()
        {
            #region birinci method
            //// <<
            //SiparisListe oncekisiparisliste = ((SiparisListe)Session["Siparis"]);
            //SiparisListe yenisiparisliste = new SiparisListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREF"]), 
            //    Convert.ToInt16(ddlFiyatTipleri.SelectedValue), true);

            //foreach (SiparisDetayi sipdet in oncekisiparisliste.Items)
            //{
            //    int urunid = sipdet._UrunID;
            //    int miktar = sipdet._Miktar;

            //    decimal yenifiyat = Urunler.GetProductPrice(sipdet._UrunID, Convert.ToInt16(ddlFiyatTipleri.SelectedValue));
            //    TaksitPlanlari tp = TaksitPlanlari.GetObject(Convert.ToInt32(ddlTaksitPlanlari.SelectedValue));
            //    yenifiyat = yenifiyat + (yenifiyat * Convert.ToDecimal(tp.YUZDE) / 100);

            //    Guid kamkartref = sipdet._KamKartRef;
            //    bool kampanyahediye = sipdet._KampanyaHediye;

            //    if (kamkartref == Guid.Empty)
            //    {
            //        yenisiparisliste.Add(urunid, miktar, yenifiyat, Guid.Empty, false);
            //    }
            //}

            ////oncekisiparisliste.DeleteSiparisSiparislerDetayFromDB(); // veritabanından sil

            //Session["Siparis"] = yenisiparisliste;
            //// >>
#endregion

            // ikinci method:
            // <<
            SiparisListe siplist = (SiparisListe)Session["Siparis"];
            siplist._FiyatTipi = Convert.ToInt16(ddlFiyatTipleri.SelectedValue);

            ArrayList silinecekler = new ArrayList();
            foreach (SiparisDetayi sipdet in siplist.Items)
            {
                if (sipdet._KamKartRef != Guid.Empty) // eğer kampanya ise direk sil çünkü bir kampanya birden fazla fiyat tipinde OLAMAZ
                {
                    //if (sipdet.KampanyaHediye == false) // ana urunu alsın sadece, yoksa hem ana hem hediyeyi silmeye çalışacak //ESKİ
                        silinecekler.Add(sipdet);
                }
                else
                {
                    decimal yenifiyat = Urunler.GetProductPrice(sipdet._UrunID, siplist._FiyatTipi);
                    double isk1 = Urunler.GetProductDiscountsAndPrice(sipdet._UrunID, siplist._FiyatTipi)[0];
                    double isk2 = Urunler.GetProductDiscountsAndPrice(sipdet._UrunID, siplist._FiyatTipi)[1];
                    double isk3 = Urunler.GetProductDiscountsAndPrice(sipdet._UrunID, siplist._FiyatTipi)[2];
                    double isk4 = Urunler.GetProductDiscountsAndPrice(sipdet._UrunID, siplist._FiyatTipi)[3];
                    TaksitPlanlari tp = TaksitPlanlari.GetObject(Convert.ToInt32(ddlTaksitPlanlari.SelectedValue));
                    yenifiyat = yenifiyat + (yenifiyat * Convert.ToDecimal(tp.YUZDE) / 100);
                    sipdet._BirimFiyat = yenifiyat;
                    sipdet._ISK1 = isk1;
                    sipdet._ISK2 = isk2;
                    sipdet._ISK3 = isk3;
                    sipdet._ISK4 = isk4;
                    sipdet.Update(); // veritabanına da yazması için
                }
            }

            for (int i = 0; i < silinecekler.Count; i++)
            {
                siplist.Remove((SiparisDetayi)silinecekler[i]); // hediyeleriyle birlikte siliyor, veritabanindan da
            }
            GC.SuppressFinalize(silinecekler);

            siplist.ToplamTutarGuncelle(true);
            siplist.SiparisiVeritabanindaGuncelle(); // veritabanına da yazması için
            // >>


            GetTaksitPlani();


            if (ddlTaksitPlanlari.Items.Count == 1) // taksitli fiyat tipinden taksitsize donmusse tksref i ort.vade yapmak icin
            {
                ((SiparisListe)Session["Siparis"])._TKSREF = TaksitPlanlari.GetODMREF(siplist.OrtalamaVade);
                Siparisler sip = Siparisler.GetObjectsBySiparisID(siplist._SiparisID);
                sip.TKSREF = TaksitPlanlari.GetODMREF(siplist.OrtalamaVade);
                sip.DoUpdate();
            }
            else if (ddlTaksitPlanlari.Items.Count > 1) // fiyat tipi taksitli ise 1. taksit planını hemen seçsin
            {
                ddlTaksitPlanlari.SelectedIndex = 1;
                TaksitPlaniDegistir();
            }


            if (Convert.ToInt16(ddlFiyatTipleri.SelectedValue) == 2)
            {
                Session["SiparisID"] = ((SiparisListe)Session["Siparis"])._SiparisID;
                Session["SMREF"] = ((SiparisListe)Session["Siparis"])._SMREF;
                Session["FiyatTipi"] = 2;
                Session["FiyatTipiDegisti"] = true;
                Response.Redirect("siparis2.aspx", true);
            }


            if (rbMalzemeler.Checked)
            {
                SepetBilgisiGuncelle();
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
            else
            {
                ucKampanyalar1.GetObjects();
                ucKampanyalar1.SepetBilgisiGuncelle();
            }
        }
        #endregion

        #region TaksitPlaniDegistir
        private void TaksitPlaniDegistir()
        {
            TaksitPlanlari tp = TaksitPlanlari.GetObject(Convert.ToInt32(ddlTaksitPlanlari.SelectedValue));
            SiparisListe siplist = (SiparisListe)Session["Siparis"];

            siplist._TKSREF = tp.TKSREF;

            for (int i = 0; i < siplist.Items.Count; i++)
            {
                SiparisDetayi sipdet = (SiparisDetayi)siplist[i];
                if (sipdet._KamKartRef == Guid.Empty || sipdet._KampanyaHediye == false)
                {
                    sipdet._BirimFiyat = Urunler.GetProductPrice(sipdet._UrunID, siplist._FiyatTipi) +
                        (sipdet._BirimFiyat * Convert.ToDecimal(tp.YUZDE) / 100);

                    sipdet.Update(); // veritabanına da yazması için
                }
            }

            siplist.SiparisiVeritabanindaGuncelle(); // veritabanına da yazması için

            if (rbMalzemeler.Checked)
                SepetBilgisiGuncelle();
            else
                ucKampanyalar1.SepetBilgisiGuncelle();
        }
        #endregion

        #region GetSiparisFromDB, GetSiparisSepeti, SepetUrunSecimEsitlemesi
        private void GetSiparisFromDB()
        {
            SiparisListe siplist;
            if (Session["SiparisSahibiMusteriID"] != null)
            {
                siplist = new SiparisListe((int)Session["SiparisSahibiMusteriID"], Convert.ToInt32(Session["SMREF"]), Convert.ToInt16(Session["FiyatTipi"]), false);
                Session["SiparisYetkiler"] = new UyeYetkileri((int)Session["SiparisSahibiMusteriID"]);
                Session["SiparisSahibiMusteriID"] = null;
            }
            else
            {
                siplist = new SiparisListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREF"]), Convert.ToInt16(Session["FiyatTipi"]), false);
                Session["SiparisYetkiler"] = Session["Yetkiler"];
            }

            DataTable dt = new DataTable();
            Siparisler sip = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(Session["SiparisID"]));
            SiparislerDetay.GetObjectsBySiparisID(dt, Convert.ToInt32(Session["SiparisID"]));

            siplist._SiparisID = Convert.ToInt32(Session["SiparisID"]);
            siplist._TKSREF = sip.TKSREF;

            // fiyat tipi yetkisi duruyor mu:
            bool yetkili = false;
            for (int i = 0; i < ((UyeYetkileri)Session["SiparisYetkiler"]).FiyatTipler.Count; i++)
            {
                if (Convert.ToInt16(((UyeYetkileri)Session["SiparisYetkiler"]).FiyatTipler[i]) == siplist._FiyatTipi)
                {
                    yetkili = true;
                    break;
                }
            }
            if (!yetkili)
                Response.Redirect("siparisler.aspx", true);

            ArrayList silinecekler = new ArrayList(); // onceden kaydedilen siparisteki bir kampanya kalkmis olabilir veya bir urun pasif olmus olabilir, onlari silmek icin

            lblOncekiToplamTutar.Text = sip.mnToplamTutar.ToString("C3");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long siparisdetayid = Convert.ToInt64(dt.Rows[i]["pkSiparisDetayID"]);
                Guid kamkartref = Guid.Parse(dt.Rows[i]["unKampanyaKart"].ToString());
                Guid kamsatirref = Guid.Parse(dt.Rows[i]["unKampanyaSatir"].ToString());
                int urunid = Convert.ToInt32(dt.Rows[i]["intUrunID"]);
                string urunadi = dt.Rows[i]["strUrunAdi"].ToString();
                int miktar = Convert.ToInt32(dt.Rows[i]["intMiktar"]);
                bool kampanyahediye = Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]);
                decimal oncekifiyat = Convert.ToDecimal(dt.Rows[i]["mnFiyat"]);
                decimal simdikifiyat = 0;
                string miktartur = dt.Rows[i]["strMiktarTur"].ToString();


                if (kampanyahediye)
                    simdikifiyat = Kampanyalar.GetProductPrice(urunid, siplist._FiyatTipi);  // kampanya hediye ürünlerin kampanyasız fiyatlarını veritabanına yazmaya başladıktan sonra koydum
                else if (kamkartref != Guid.Empty)
                    simdikifiyat = Kampanyalar.GetProductPrice(urunid, siplist._FiyatTipi);
                else
                    simdikifiyat = Urunler.GetProductPrice(urunid, siplist._FiyatTipi);

                if (oncekifiyat != simdikifiyat && !kampanyahediye)
                {
                    //divUrunFiyatiDegisti.Visible = true;

                    SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(siparisdetayid);
                    siplerdet.mnFiyat = simdikifiyat;
                    siplerdet.DoUpdate();
                }

                siplist.Add(urunid, urunadi, miktar, simdikifiyat, kamkartref, kampanyahediye, kamsatirref, miktartur, siparisdetayid);

                if (kamkartref != Guid.Empty && !kampanyahediye)
                {
                    if (!Kampanyalar.KampanyaIsAvailable(kamkartref))
                        silinecekler.Add(siplist[siplist.Count - 1]);
                }
                else if (!Urunler.ProductIsAvailable(urunid))
                {
                    silinecekler.Add(siplist[siplist.Count - 1]);
                }
            }
            Session["Siparis"] = siplist;
            GetSiparisSepeti();
            TumunuGuncelle();
            lblSimdikiToplamTutar.Text = siplist.ToplamTutar.ToString("C3");

            for (int i = 0; i < silinecekler.Count; i++)
                siplist.Remove((SiparisDetayi)silinecekler[i]); // veritabanından da siliyor

            siplist.ToplamTutarGuncelle(true);

            ((Musteriler)Session["Musteri"]).intSonYarimSiparisID = siplist._SiparisID;
            ((Musteriler)Session["Musteri"]).DoUpdate();
            SepetBilgisiGuncelle();

            if (TaksitPlanlari.TaksitMi(siplist._TKSREF))
                ddlTaksitPlanlari.SelectedValue = siplist._TKSREF.ToString();

            string[] ayrac = new string[1];
            ayrac[0] = ";;;";
            string[] aciklamalar = sip.strAciklama.Split(ayrac, StringSplitOptions.None);
            txtSiparisAciklama2.Text = aciklamalar[1];
            txtSiparisAciklama3.Text = aciklamalar[2];
        }
        public void GetSiparisSepeti()
        {
            lblSepetToplam.Text = ((SiparisListe)Session["Siparis"]).ToplamTutar.ToString("C3") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(K.Top.: " + ((SiparisListe)Session["Siparis"]).ToplamKoli.ToString("N1") + ")";

            lblOrtalamaVade.Text = "Sip.Ort.Vade: <strong>" + ((SiparisListe)Session["Siparis"]).OrtalamaVade.ToString() + "</strong> Gün";
            lblOrtalamaVade.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID != 1;

            //for (int i = 0; i < ((SiparisListe)Session["Siparis"]).Count; i++)
            //{
            //    double[] veriler = Urunler.GetProductDiscountsAndPrice
            //        (((SiparisDetayi)((SiparisListe)Session["Siparis"])[i])._UrunID, ((SiparisListe)Session["Siparis"])._FiyatTipi);
            //    double kdv = Urunler.GetProductKDV(((SiparisDetayi)((SiparisListe)Session["Siparis"])[i])._UrunID);
            //    ((SiparisDetayi)((SiparisListe)Session["Siparis"])[i])._Brutler =
            //        " &nbsp;&nbsp;<strong>BRÜT</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK1</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK2</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK3</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK4</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>KDV</strong> <br>" + veriler[4].ToString("C3") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + veriler[0].ToString("N1") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + veriler[1].ToString("N1") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + veriler[2].ToString("N1") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + veriler[3].ToString("N1") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + kdv.ToString("N0") + "";
            //}

            Repeater1.DataSource = (SiparisListe)Session["Siparis"];
            Repeater1.DataBind();

            SepetUrunSecimEsitlemesi();
        }
        private void SepetUrunSecimEsitlemesi()
        {
            if (divSepet.Visible)
            {
                for (int i = 0; i < ((ArrayList)Session["SepetUrunSecimleri"]).Count; i++)
                {
                    ArrayList icerik = (ArrayList)((ArrayList)Session["SepetUrunSecimleri"])[i];
                    long ICERIKsiparisdetayid = Convert.ToInt64(icerik[0]);
                    Guid ICERIKkamkartref = Guid.Parse(icerik[1].ToString());

                    foreach (Control ctrl in Repeater1.Controls)
                    {
                        long siparisdetayid = 0;
                        Guid kamkartref = Guid.Parse("90264d63-a72a-4528-a1cb-575ede09200a"); // öylesine guid
                        CheckBox chk = new CheckBox();

                        foreach (Control ctrl2 in ctrl.Controls)
                        {
                            if (ctrl2 is CheckBox)
                            {
                                chk = (CheckBox)ctrl2;
                            }
                            else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("SiparisDetayID"))
                            {
                                siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                            }
                            else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("KamKartRef"))
                            {
                                kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                            }
                        }

                        if (ICERIKsiparisdetayid == siparisdetayid && ICERIKkamkartref == kamkartref)
                            chk.Checked = true;
                    }
                }
            }
        }
        #endregion

        #region SiparisYarimKalanDegil
        private void SiparisYarimKalanDegil()
        {
            AciklamalariGuncelle();
            ((Musteriler)Session["Musteri"]).intSonYarimSiparisID = 0;
            ((Musteriler)Session["Musteri"]).DoUpdate();
            Session["Siparis"] = null;
        }
        #endregion

        #region AciklamalariGuncelle
        private void AciklamalariGuncelle()
        {
            if (Session["Siparis"] != null) // session kendiliğinden sonlanırsa da bu ekrandan bir link tıklanırsa, postback de hataya düşmemesi için
            {
                string aciklama1 = Siparisler.GetObjectsBySiparisID(((SiparisListe)Session["Siparis"])._SiparisID).strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0];
                //if (Session["SiparisGirenMusteriID"] != null)
                //{
                //    Musteriler musteri = Musteriler.GetMusteriByID((int)Session["SiparisGirenMusteriID"]);
                //    aciklama1 = musteri.strAd + " " + musteri.strSoyad;
                //}
                //else
                //{
                //    aciklama1 = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
                //}

                ((SiparisListe)Session["Siparis"]).AciklamaGuncelle(aciklama1, txtSiparisAciklama2.Text.Trim(), txtSiparisAciklama3.Text.Trim());
            }
        }
        #endregion

        #region GetProducts
        private void GetProducts(bool resimli, bool aramabaslangicagore)
        {
            //if (Session["Kategori"] == "NOT NULL" && Session["Tedarikci"] == "NOT NULL" && Session["Aranan"] == "")
            //{
            //    lblUrunSayisi.Text = "0 / 0";
            //    lbOnceki.Enabled = false;
            //    ibOnceki.Enabled = false;
            //    lbSonraki.Enabled = false;
            //    ibSonraki.Enabled = false;
            //    dlResimli.Visible = false;
            //    dlListe.Visible = false;
            //    return;
            //}

            TedarikciHarfler();
            KategoriHarfler();

            Session["MaxRecordCount"] = GetProductsCount();

            if (Convert.ToInt32(Session["MaxRecordCount"]) == 0)
            {
                lblUrunSayisi.Text = "0 / 0";
                lbOnceki.Enabled = false;
                ibOnceki.Enabled = false;
                lbSonraki.Enabled = false;
                ibSonraki.Enabled = false;
                dlResimli.Visible = false;
                dlListe.Visible = false;

                lblEmpty.Visible = true;
                btnSipariseAktar2.Visible = false;
                return;
            }
            else
            {
                lbOnceki.Enabled = true;
                ibOnceki.Enabled = true;
                lbSonraki.Enabled = true;
                ibSonraki.Enabled = true;
                dlResimli.Visible = true;
                dlListe.Visible = true;

                lblEmpty.Visible = false;
                btnSipariseAktar2.Visible = true;
            }

            string aramabasi = string.Empty;
            if (!aramabaslangicagore)
                aramabasi = "%";

            string kategorioperator = "IS";
            string tedarikcioperator = "IS";
            if (Session["Kategori"] != "NOT NULL")
            {
                if (!Session["Kategori"].ToString().StartsWith("'"))
                    Session["Kategori"] = "'" + Session["Kategori"].ToString() + "'";
                kategorioperator = "=";
            }
            if (Session["Tedarikci"] != "NOT NULL")
            {
                if (!Session["Tedarikci"].ToString().StartsWith("'"))
                    Session["Tedarikci"] = "'" + Session["Tedarikci"].ToString() + "'";
                tedarikcioperator = "=";
            }

            if ((int)Session["Start"] < (int)Session["MaxRecordCount"]) // bu gereksiz olabilir onceki ve sonraki sayfayi enabled false yapinca
            {
                DataTable dt = new DataTable();
                Urunler.GetProducts(dt, (int)Session["Start"], (int)Session["Count"], ((SiparisListe)Session["Siparis"]).FiyatTipi.ToString(), 
                    tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, cbYeniUrunler.Checked);

                UrunSayisiniYaz();

                if (resimli)
                {
                    dlListe.Enabled = false;
                    dlListe.Visible = false;
                    dlResimli.Enabled = true;
                    dlResimli.Visible = true;

                    dlResimli.DataSource = dt;
                }
                else
                {
                    dlListe.Enabled = true;
                    dlListe.Visible = true;
                    dlResimli.Enabled = false;
                    dlResimli.Visible = false;

                    dlListe.DataSource = dt;
                }

                if (dt.Rows.Count == 0)
                {
                    lblEmpty.Visible = true;
                    btnSipariseAktar2.Visible = false;
                }
                else
                {
                    lblEmpty.Visible = false;
                    btnSipariseAktar2.Visible = true;
                }

                DataBind();
            }
        }
        private DataTable GetProducts(bool aramabaslangicagore)
        {
            string aramabasi = string.Empty;
            if (!aramabaslangicagore)
                aramabasi = "%";

            string kategorioperator = "IS";
            string tedarikcioperator = "IS";
            if (Session["Kategori"] != "NOT NULL")
            {
                if (!Session["Kategori"].ToString().StartsWith("'"))
                    Session["Kategori"] = "'" + Session["Kategori"].ToString() + "'";
                kategorioperator = "=";
            }
            if (Session["Tedarikci"] != "NOT NULL")
            {
                if (!Session["Tedarikci"].ToString().StartsWith("'"))
                    Session["Tedarikci"] = "'" + Session["Tedarikci"].ToString() + "'";
                tedarikcioperator = "=";
            }

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, 0, (int)Session["MaxRecordCount"], ((SiparisListe)Session["Siparis"]).FiyatTipi.ToString(),
                tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, cbYeniUrunler.Checked);
            return dt;
        }
        #endregion

        #region GetProductsCount
        private int GetProductsCount()
        {
            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5 && !cbYeniUrunler.Checked) // perakende müşteri ise yetkili bütün ürünler gelsin
            //    if (Session["Kategori"] == "NOT NULL" && Session["Tedarikci"] == "NOT NULL" && Session["Aranan"] == "")
            //        return 0;

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";

            string kategorioperator = "IS";
            string tedarikcioperator = "IS";
            if (Session["Kategori"] != "NOT NULL")
            {
                if (!Session["Kategori"].ToString().StartsWith("'"))
                    Session["Kategori"] = "'" + Session["Kategori"].ToString() + "'";
                kategorioperator = "=";
            }
            if (Session["Tedarikci"] != "NOT NULL")
            {
                if (!Session["Tedarikci"].ToString().StartsWith("'"))
                    Session["Tedarikci"] = "'" + Session["Tedarikci"].ToString() + "'";
                tedarikcioperator = "=";
            }

            return Urunler.GetProductsCount(((SiparisListe)Session["Siparis"]).FiyatTipi.ToString(), tedarikcioperator,
                    Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(),
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, cbYeniUrunler.Checked);
        }
        #endregion

        #region UrunSayisiniYaz
        private void UrunSayisiniYaz()
        {
            if ((int)Session["Start"] + (int)Session["Count"] > (int)Session["MaxRecordCount"])
                lblUrunSayisi.Text = Session["MaxRecordCount"].ToString() + " / " + Session["MaxRecordCount"].ToString();
            else
                lblUrunSayisi.Text = ((int)Session["Start"] + (int)Session["Count"]).ToString() + " / " + Session["MaxRecordCount"].ToString();


            char[] ayrac = new char[1];
            ayrac[0] = '/';
            string[] sayilar = lblUrunSayisi.Text.Split(ayrac);
            if (sayilar[0].Trim() == sayilar[1].Trim())
            {
                lbSonraki.Enabled = false;
                ibSonraki.Enabled = false;
            }
            else
            {
                lbSonraki.Enabled = true;
                ibSonraki.Enabled = true;
            }

            if ((int)Session["Start"] == 0)
            {
                lbOnceki.Enabled = false;
                ibOnceki.Enabled = false;
            }
            else
            {
                lbOnceki.Enabled = true;
                ibOnceki.Enabled = true;
            }
        }
        #endregion

        #region UrunSecimTarama
        private bool UrunSecimTarama(bool ekle, bool resimlisteters)
        {
            bool miktargirilmis = false;

            if (ekle)
            {
                if (((SiparisListe)Session["Siparis"]).Items.Count >= 100)
                {
                    divSiparisKalemFazla.Visible = true;
                    return false;
                }
            }

            DataList dl = dlResimli;
            if (rbListeDuzeni.Checked)
                dl = dlListe;

            if (resimlisteters)
            {
                if (rbListeDuzeni.Checked)
                    dl = dlResimli;
                else if (rbResimDuzeni.Checked)
                    dl = dlListe;
            }

            for (int i = 0; i < dl.Controls.Count; i++) // her bir ürün
            {
                int urunid = 0;
                int miktar = 0;
                decimal fiyat = 0;

                for (int j = 0; j < dl.Controls[i].Controls.Count; j++) // üründeki kontroller
                {
                    if (dl.Controls[i].Controls[j] is System.Web.UI.HtmlControls.HtmlInputHidden && ((System.Web.UI.HtmlControls.HtmlInputHidden)dl.Controls[i].Controls[j]).ID.StartsWith("UrunID")) // urunid si ve fiyat
                    {
                        string tekst = ((System.Web.UI.HtmlControls.HtmlInputHidden)dl.Controls[i].Controls[j]).Value;

                        if (urunid == 0) // urun
                            urunid = Convert.ToInt32(tekst);
                        //else // fiyat
                        //    fiyat = decimal.Parse(tekst); // lüzumsuz, fiyatı altta veritabanından alıyoruz
                    }
                    else if (dl.Controls[i].Controls[j] is TextBox) // miktar
                    {
                        if (((TextBox)dl.Controls[i].Controls[j]).Text.Trim() != string.Empty)
                        {
                            miktar = Convert.ToInt32(((TextBox)dl.Controls[i].Controls[j]).Text);
                            miktargirilmis = true;
                        }
                        else
                        {
                            miktar = 0;
                        }

                        if (ekle)
                            ((TextBox)dl.Controls[i].Controls[j]).Text = string.Empty;
                    }
                }

                if (ekle && miktar != 0)
                {
                    TaksitPlanlari tp = TaksitPlanlari.GetObject(Convert.ToInt32(ddlTaksitPlanlari.SelectedValue));
                    fiyat = Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi);             // normal fiyat
                    fiyat = fiyat + (fiyat * Convert.ToDecimal(tp.YUZDE) / 100);                                                 // taksitli fiyat
                    ((SiparisListe)Session["Siparis"]).Add(urunid, miktar, fiyat, Guid.Empty, false, Guid.Empty, false);
                }
            }

            if (miktargirilmis)
                ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

            return miktargirilmis;
        }
        #endregion

        #region UrunSecimTemizle
        private void UrunSecimTemizle(bool resimlisteters)
        {
            DataList dl = dlResimli;
            if (rbListeDuzeni.Checked)
                dl = dlListe;

            if (resimlisteters)
            {
                if (rbListeDuzeni.Checked)
                    dl = dlResimli;
                else if (rbResimDuzeni.Checked)
                    dl = dlListe;
            }

            for (int i = 0; i < dl.Controls.Count; i++) // her bir ürün
            {
                for (int j = 0; j < dl.Controls[i].Controls.Count; j++) // üründeki kontroller
                {
                    if (dl.Controls[i].Controls[j] is TextBox) // miktar
                    {
                        ((TextBox)dl.Controls[i].Controls[j]).Text = string.Empty;
                    }
                }
            }
        }
        #endregion

        #region GetKategoriler, GetTedarikciler
        private void GetKategoriler(string harf)
        {
            //Urunler.GetKategoriler(harf, rblKategoriler.Items);

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetKategoriler2(harf, Session["Tedarikci"].ToString(), aramabasi, Session["Aranan"].ToString(), rblKategoriler.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, true);
        }
        private void GetTedarikciler(string harf)
        {
            //Urunler.GetTedarikciler(harf, rblTedarikciler.Items);

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetTedarikciler2(harf, Session["Kategori"].ToString(), aramabasi, Session["Aranan"].ToString(), rblTedarikciler.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, true);
        }
        #endregion

        #region AramaTemizle, TedarikciTemizle, KategoriTemizle
        private void AramaTemizle()
        {
            tblTedarikciSecimi.Visible = true;
            tblKategoriSecimi.Visible = true;

            Session["Aranan"] = "";
            txtArama.Text = "";
            lblAramaSecim.Text = "-";
        }
        private void TedarikciTemizle()
        {
            Session["Tedarikci"] = "NOT NULL";
            divTedarikci.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            lblTedarikciSecim.Text = "-";
        }
        private void KategoriTemizle()
        {
            Session["Kategori"] = "NOT NULL";
            divKategori.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            lblKategoriSecim.Text = "-";
        }
        #endregion

        #region BarkodAra
        private void BarkodAra(bool ekle)
        {
            lblAramaSecim.Text = txtArama.Text + " (Barkod arama)";

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi.ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);

            if (dt.Rows.Count != 0)
                lblUrunSayisi.Text = "1 / 1";
            else
                lblUrunSayisi.Text = "0 / 0";

            lblEmpty.Visible = dt.Rows.Count == 0;

            if (rbResimDuzeni.Checked)
            {
                dlListe.Enabled = false;
                dlListe.Visible = false;
                dlResimli.Enabled = true;
                dlResimli.Visible = true;

                dlResimli.DataSource = dt;
            }
            else
            {
                dlListe.Enabled = true;
                dlListe.Visible = true;
                dlResimli.Enabled = false;
                dlResimli.Visible = false;

                dlListe.DataSource = dt;
            }

            DataBind();

            if (ekle)
            {
                if (dt.Rows.Count > 0)
                {
                    if (rbListeDuzeni.Checked)
                    {
                        for (int j = 0; j < dlListe.Controls[1].Controls.Count; j++) // üründeki kontroller
                        {
                            if (dlListe.Controls[1].Controls[j] is TextBox) // miktar
                            {
                                ((TextBox)dlListe.Controls[1].Controls[j]).Text = txtAramaMiktar.Text.Trim() != string.Empty ? txtAramaMiktar.Text.Trim() : "1";
                                break;
                            }
                        }
                    }
                    else if (rbResimDuzeni.Checked)
                    {
                        for (int j = 0; j < dlResimli.Controls[0].Controls.Count; j++) // üründeki kontroller
                        {
                            if (dlResimli.Controls[0].Controls[j] is TextBox) // miktar
                            {
                                ((TextBox)dlResimli.Controls[0].Controls[j]).Text = txtAramaMiktar.Text.Trim() != string.Empty ? txtAramaMiktar.Text.Trim() : "1";
                                break;
                            }
                        }
                    }

                    UrunSecimTarama(true, false);
                    SepetBilgisiGuncelle();
                    //if ((bool)Session["BarkodArama"])
                    //{
                    //    UrunSecimTarama(true, false);

                    //    Session["BarkodArama"] = false;
                    //    SepetBilgisiGuncelle();
                    //}
                    //else
                    //{
                    //    Session["BarkodArama"] = true;
                    //}
                }
            }

            txtArama.Text = "";
            txtArama.Focus();
        }
        #endregion

        #region MalzemeKoduAra
        private void MalzemeKoduAra()
        {
            lblAramaSecim.Text = txtArama.Text + " (Malzeme kodu arama)";

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi.ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, true);

            if (dt.Rows.Count != 0)
                lblUrunSayisi.Text = "1 / 1";
            else
                lblUrunSayisi.Text = "0 / 0";

            lblEmpty.Visible = dt.Rows.Count == 0;

            if (rbResimDuzeni.Checked)
            {
                dlListe.Enabled = false;
                dlListe.Visible = false;
                dlResimli.Enabled = true;
                dlResimli.Visible = true;

                dlResimli.DataSource = dt;
            }
            else
            {
                dlListe.Enabled = true;
                dlListe.Visible = true;
                dlResimli.Enabled = false;
                dlResimli.Visible = false;

                dlListe.DataSource = dt;
            }

            DataBind();
        }
        #endregion

        #region UrtKoduAra
        private void UrtKoduAra()
        {
            lblAramaSecim.Text = txtArama.Text + " (Üretici kodu arama)";

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi.ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar, true, true);

            if (dt.Rows.Count != 0)
                lblUrunSayisi.Text = "1 / 1";
            else
                lblUrunSayisi.Text = "0 / 0";

            lblEmpty.Visible = dt.Rows.Count == 0;

            if (rbResimDuzeni.Checked)
            {
                dlListe.Enabled = false;
                dlListe.Visible = false;
                dlResimli.Enabled = true;
                dlResimli.Visible = true;

                dlResimli.DataSource = dt;
            }
            else
            {
                dlListe.Enabled = true;
                dlListe.Visible = true;
                dlResimli.Enabled = false;
                dlResimli.Visible = false;

                dlListe.DataSource = dt;
            }

            DataBind();
        }
        #endregion

        #region SepetiBosalt, SiparisIptal
        private void SepetiBosalt()
        {
            ((SiparisListe)Session["Siparis"]).DeleteSiparislerDetay(true);
        }
        private void SiparisIptal()
        {
            ((SiparisListe)Session["Siparis"]).DeleteSiparisSiparislerDetayFromDB();
            Session["SiparisID"] = null;
            Session["Siparis"] = null;
            GC.Collect();
            SiparisYarimKalanDegil();
            Response.Redirect("default.aspx", true);
        }
        #endregion

        #region TedarikciHarfler
        private void TedarikciHarfler()
        {
            //string tedarikcioperator = "IS";
            string kategorioperator = "IS";
            //if (Session["Tedarikci"] != "NOT NULL")
            //{
            //    if (!Session["Tedarikci"].ToString().StartsWith("'"))
            //        Session["Tedarikci"] = "'" + Session["Tedarikci"].ToString() + "'";
            //    tedarikcioperator = "=";
            //}
            if (Session["Kategori"] != "NOT NULL")
            {
                if (!Session["Kategori"].ToString().StartsWith("'"))
                    Session["Kategori"] = "'" + Session["Kategori"].ToString() + "'";
                kategorioperator = "=";
            }

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";

            DataTable dt = new DataTable();

            Urunler.GetTedarikciHangiHarfler(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi, /*Session["Tedarikci"].ToString(),
                tedarikcioperator, */Session["Kategori"].ToString(), kategorioperator, aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);

            lb2.Font.Bold = false; lbA2.Font.Bold = false; lbB2.Font.Bold = false; lbC2.Font.Bold = false; lbD2.Font.Bold = false; lbE2.Font.Bold = false; lbF2.Font.Bold = false; lbG2.Font.Bold = false; lbH2.Font.Bold = false; lbI2.Font.Bold = false; lbJ2.Font.Bold = false; lbK2.Font.Bold = false; lbL2.Font.Bold = false; lbM2.Font.Bold = false; lbN2.Font.Bold = false; lbO2.Font.Bold = false; lbP2.Font.Bold = false; lbR2.Font.Bold = false; lbS2.Font.Bold = false; lbT2.Font.Bold = false; lbU2.Font.Bold = false; lbV2.Font.Bold = false; lbY2.Font.Bold = false; lbZ2.Font.Bold = false;
            lb2.Font.Size = 7; lbA2.Font.Size = 7; lbB2.Font.Size = 7; lbC2.Font.Size = 7; lbD2.Font.Size = 7; lbE2.Font.Size = 7; lbF2.Font.Size = 7; lbG2.Font.Size = 7; lbH2.Font.Size = 7; lbI2.Font.Size = 7; lbJ2.Font.Size = 7; lbK2.Font.Size = 7; lbL2.Font.Size = 7; lbM2.Font.Size = 7; lbN2.Font.Size = 7; lbO2.Font.Size = 7; lbP2.Font.Size = 7; lbR2.Font.Size = 7; lbS2.Font.Size = 7; lbT2.Font.Size = 7; lbU2.Font.Size = 7; lbV2.Font.Size = 7; lbY2.Font.Size = 7; lbZ2.Font.Size = 7;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "2")
                {
                    lb2.Font.Bold = true;
                    lb2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "A")
                {
                    lbA2.Font.Bold = true;
                    lbA2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "B")
                {
                    lbB2.Font.Bold = true;
                    lbB2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "C")
                {
                    lbC2.Font.Bold = true;
                    lbC2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ç")
                {
                    lbC2.Font.Bold = true;
                    lbC2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "D")
                {
                    lbD2.Font.Bold = true;
                    lbD2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "E")
                {
                    lbE2.Font.Bold = true;
                    lbE2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "F")
                {
                    lbF2.Font.Bold = true;
                    lbF2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "G")
                {
                    lbG2.Font.Bold = true;
                    lbG2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ğ")
                {
                    lbG2.Font.Bold = true;
                    lbG2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "H")
                {
                    lbH2.Font.Bold = true;
                    lbH2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "I")
                {
                    lbI2.Font.Bold = true;
                    lbI2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "İ")
                {
                    lbI2.Font.Bold = true;
                    lbI2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "J")
                {
                    lbJ2.Font.Bold = true;
                    lbJ2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "K")
                {
                    lbK2.Font.Bold = true;
                    lbK2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "L")
                {
                    lbL2.Font.Bold = true;
                    lbL2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "M")
                {
                    lbM2.Font.Bold = true;
                    lbM2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "N")
                {
                    lbN2.Font.Bold = true;
                    lbN2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "O")
                {
                    lbO2.Font.Bold = true;
                    lbO2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ö")
                {
                    lbO2.Font.Bold = true;
                    lbO2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "P")
                {
                    lbP2.Font.Bold = true;
                    lbP2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "R")
                {
                    lbR2.Font.Bold = true;
                    lbR2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "S")
                {
                    lbS2.Font.Bold = true;
                    lbS2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ş")
                {
                    lbS2.Font.Bold = true;
                    lbS2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "T")
                {
                    lbT2.Font.Bold = true;
                    lbT2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "U")
                {
                    lbU2.Font.Bold = true;
                    lbU2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ü")
                {
                    lbU2.Font.Bold = true;
                    lbU2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "V")
                {
                    lbV2.Font.Bold = true;
                    lbV2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Y")
                {
                    lbY2.Font.Bold = true;
                    lbY2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Z")
                {
                    lbZ2.Font.Bold = true;
                    lbZ2.Font.Size = 10;
                }
            }
        }
        #endregion

        #region KategoriHarfler
        private void KategoriHarfler()
        {
            string tedarikcioperator = "IS";
            //string kategorioperator = "IS";
            if (Session["Tedarikci"] != "NOT NULL")
            {
                if (!Session["Tedarikci"].ToString().StartsWith("'"))
                    Session["Tedarikci"] = "'" + Session["Tedarikci"].ToString() + "'";
                tedarikcioperator = "=";
            }
            //if (Session["Kategori"] != "NOT NULL")
            //{
            //    if (!Session["Kategori"].ToString().StartsWith("'"))
            //        Session["Kategori"] = "'" + Session["Kategori"].ToString() + "'";
            //    kategorioperator = "=";
            //}

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";

            DataTable dt = new DataTable();

            Urunler.GetKategoriHangiHarfler(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi, Session["Tedarikci"].ToString(),
                tedarikcioperator, /*Session["Kategori"].ToString(), kategorioperator, */aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);

            lb0.Font.Bold = false; lbA.Font.Bold = false; lbB.Font.Bold = false; lbC.Font.Bold = false; lbD.Font.Bold = false; lbE.Font.Bold = false; lbF.Font.Bold = false; lbG.Font.Bold = false; lbH.Font.Bold = false; lbI.Font.Bold = false; lbJ.Font.Bold = false; lbK.Font.Bold = false; lbL.Font.Bold = false; lbM.Font.Bold = false; lbN.Font.Bold = false; lbO.Font.Bold = false; lbP.Font.Bold = false; lbR.Font.Bold = false; lbS.Font.Bold = false; lbT.Font.Bold = false; lbU.Font.Bold = false; lbV.Font.Bold = false; lbY.Font.Bold = false; lbZ.Font.Bold = false;
            lb0.Font.Size = 7; lbA.Font.Size = 7; lbB.Font.Size = 7; lbC.Font.Size = 7; lbD.Font.Size = 7; lbE.Font.Size = 7; lbF.Font.Size = 7; lbG.Font.Size = 7; lbH.Font.Size = 7; lbI.Font.Size = 7; lbJ.Font.Size = 7; lbK.Font.Size = 7; lbL.Font.Size = 7; lbM.Font.Size = 7; lbN.Font.Size = 7; lbO.Font.Size = 7; lbP.Font.Size = 7; lbR.Font.Size = 7; lbS.Font.Size = 7; lbT.Font.Size = 7; lbU.Font.Size = 7; lbV.Font.Size = 7; lbY.Font.Size = 7; lbZ.Font.Size = 7;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "0")
                {
                    lb0.Font.Bold = true;
                    lb0.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "A")
                {
                    lbA.Font.Bold = true;
                    lbA.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "B")
                {
                    lbB.Font.Bold = true;
                    lbB.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "C")
                {
                    lbC.Font.Bold = true;
                    lbC.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ç")
                {
                    lbC.Font.Bold = true;
                    lbC.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "D")
                {
                    lbD.Font.Bold = true;
                    lbD.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "E")
                {
                    lbE.Font.Bold = true;
                    lbE.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "F")
                {
                    lbF.Font.Bold = true;
                    lbF.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "G")
                {
                    lbG.Font.Bold = true;
                    lbG.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ğ")
                {
                    lbG.Font.Bold = true;
                    lbG.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "H")
                {
                    lbH.Font.Bold = true;
                    lbH.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "I")
                {
                    lbI.Font.Bold = true;
                    lbI.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "İ")
                {
                    lbI.Font.Bold = true;
                    lbI.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "J")
                {
                    lbJ.Font.Bold = true;
                    lbJ.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "K")
                {
                    lbK.Font.Bold = true;
                    lbK.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "L")
                {
                    lbL.Font.Bold = true;
                    lbL.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "M")
                {
                    lbM.Font.Bold = true;
                    lbM.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "N")
                {
                    lbN.Font.Bold = true;
                    lbN.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "O")
                {
                    lbO.Font.Bold = true;
                    lbO.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ö")
                {
                    lbO.Font.Bold = true;
                    lbO.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "P")
                {
                    lbP.Font.Bold = true;
                    lbP.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "R")
                {
                    lbR.Font.Bold = true;
                    lbR.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "S")
                {
                    lbS.Font.Bold = true;
                    lbS.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ş")
                {
                    lbS.Font.Bold = true;
                    lbS.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "T")
                {
                    lbT.Font.Bold = true;
                    lbT.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "U")
                {
                    lbU.Font.Bold = true;
                    lbU.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ü")
                {
                    lbU.Font.Bold = true;
                    lbU.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "V")
                {
                    lbV.Font.Bold = true;
                    lbV.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Y")
                {
                    lbY.Font.Bold = true;
                    lbY.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Z")
                {
                    lbZ.Font.Bold = true;
                    lbZ.Font.Size = 10;
                }
            }
        }
        #endregion

        #region OneriSiparisi
        private void OneriSiparisi()
        {
            int gmref = CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF);

            if (CariHesaplar.AnaSubeMi(gmref))
            {
                divOneriSiparisiSube.Visible = true;
            }
            else
            {
                int sayi = SatisRapor.GetProductCountBySMREF(((SiparisListe)Session["Siparis"])._SMREF, ((SiparisListe)Session["Siparis"])._FiyatTipi,
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);
                lblOneriSiparisiSayisi.Text = sayi.ToString();
                if (sayi < 100)
                    lblOneriSiparisiKacinci.Text = sayi.ToString();
                else
                    lblOneriSiparisiKacinci.Text = "100";

                OneriSiparisiOlustur(false, 0, 100);
                divOneriSiparisiSube.Visible = false;
                divOneri.Visible = true;
            }
        }
        #endregion

        #region OneriSiparisiOlustur
        private void OneriSiparisiOlustur(bool GMREF, int Baslangic, int Miktar)
        {
            #region sepete atmalı yöntem
            //SepetiBosalt();

            //DataTable dt = new DataTable();
            //if (GMREF)
            //{
            //    int gmref = CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF);
            //    SatisRapor.GetITEMREFsByGMREF(dt, gmref);
            //}
            //else
            //{
            //    SatisRapor.GetITEMREFsBySMREF(dt, ((SiparisListe)Session["Siparis"])._SMREF);
            //}

            ////SiparislerDetay.DoInsertToplu(dt, ((SiparisListe)Session["Siparis"])._SiparisID, ((SiparisListe)Session["Siparis"])._FiyatTipi);

            ////Response.Redirect("siparisler.aspx", true);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //    ((SiparisListe)Session["Siparis"]).Add(Convert.ToInt32(dt.Rows[i]["ITEMREF"]), 1, Urunler.GetProductPrice(Convert.ToInt32(dt.Rows[i]["ITEMREF"]), ((SiparisListe)Session["Siparis"])._FiyatTipi), Guid.Empty, false, Guid.Empty, false);

            //if (dt.Rows.Count > 0)
            //    ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

            //GetSiparisSepeti();

            //if (rbMalzemeler.Checked)
            //    SepetBilgisiGuncelle();
            //else
            //    ucKampanyalar1.SepetBilgisiGuncelle();
            #endregion

            Session["OneriSiparisiGMREFdir"] = true;

            DataTable dt = new DataTable();
            if (GMREF)
            {
                int gmref = CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF);
                SatisRapor.GetProductsByGMREF(dt, Baslangic, 1500, gmref, ((SiparisListe)Session["Siparis"])._FiyatTipi,
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);
            }
            else
            {
                Session["OneriSiparisiGMREFdir"] = false;

                SatisRapor.GetProductsBySMREF(dt, Baslangic, 1500, ((SiparisListe)Session["Siparis"])._SMREF, ((SiparisListe)Session["Siparis"])._FiyatTipi,
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);
            }

            Session["OneriSiparisiDt"] = dt;

            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }
        #endregion

        #region TumunuGuncelle
        private void TumunuGuncelle()
        {
            foreach (Control ctrl in Repeater1.Controls)
            {
                long siparisdetayid = 0;
                int yenimiktar = 0;
                decimal fiyat = 0;
                Guid kamkartref = Guid.Parse("90264d63-a72a-4528-a1cb-575ede09200a"); // öylesine guid
                string miktartur = "ST";

                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("SiparisDetayID"))
                    {
                        siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("Miktar"))
                    {
                        yenimiktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("BirimFiyat"))
                    {
                        fiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value); // fuzuli
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("KamKartRef"))
                    {
                        kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                    else if (ctrl2 is DropDownList && ctrl2.ID.StartsWith("ddlMiktarTur"))
                    {
                        miktartur = ((DropDownList)ctrl2).SelectedValue;
                    }
                }

                if (siparisdetayid != 0)
                {
                    int urunid = SiparislerDetay.GetObjectBySiparislerDetayID(siparisdetayid).intUrunID;
                    fiyat = miktartur == "KI" ? Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi) * Convert.ToDecimal(Urunler.GetKoliAdedi(urunid)) : miktartur == "PAK" ? Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi) * Convert.ToDecimal(Urunler.GetProductBirim(urunid)) : Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi);

                    if (kamkartref.ToString() != "90264d63-a72a-4528-a1cb-575ede09200a" && kamkartref != Guid.Empty)
                    {
                        divKampanyaMiktarDegismez.Visible = true;
                        return;
                    }
                    else
                    {
                        ((SiparisListe)Session["Siparis"]).Update(siparisdetayid, yenimiktar, fiyat, miktartur); /*adtadt*/
                    }
                }
            }

            ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);
            GetSiparisSepeti();
        }
        #endregion

        #region Events Süzme
        protected void Tedarikci_Click(object sender, EventArgs e)
        {
            lblTedarikciHarf.Text = ((Control)sender).ID.Substring(2, 1);

            GetTedarikciler(((Control)sender).ID.Substring(2, 1));

            divTedarikci.Visible = true;
            divTedarikciKategoriDis.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '150' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divTedarikci, typeof(string), "scriptSayfayukaricikar", alert, false);
        }
        protected void Kategori_Click(object sender, EventArgs e)
        {
            lblKategoriHarf.Text = ((Control)sender).ID.Substring(2, 1);

            GetKategoriler(((Control)sender).ID.Substring(2, 1));

            divKategori.Visible = true;
            divTedarikciKategoriDis.Visible = true;
        }
        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (rbBarkodaGore.Checked)
            {
                //Session["BarkodArama"] = true;
                BarkodAra(cbBarkodHemenEkle.Checked);
                return;
            }
            else if (rbMalzemeKodunaGore.Checked)
            {
                MalzemeKoduAra();
                return;
            }
            else if (rbUrtKodunaGore.Checked)
            {
                UrtKoduAra();
                return;
            }

            Session["Start"] = 0;
            cbYeniUrunler.Checked = false;

            if (txtArama.Text.Trim() != string.Empty)
            {
                if (UrunSecimTarama(false, false))
                {
                    divTedarikciKategoriDis.Visible = true;
                    divAktarim.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                    Session["Aktarim"] = "Arama";
                }
                else
                {
                    Session["Aranan"] = txtArama.Text;
                    string aramasecim = " (Başlangıca göre)";

                    if (rbIcinde.Checked)
                        aramasecim = " (İçinde)";

                    lblAramaSecim.Text = txtArama.Text + aramasecim;
                    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                }
            }
        }
        protected void rbAramaSecimleri_CheckedChanged(object sender, EventArgs e)
        {
            tblTedarikciSecimi.Visible = !(((RadioButton)sender).ID == "rbBarkodaGore");
            tblKategoriSecimi.Visible = !(((RadioButton)sender).ID == "rbBarkodaGore");

            //txtArama.Text = "";
            //lblAramaSecim.Text = "-";

            if (rbBarkodaGore.Checked)
            {
                TedarikciTemizle();
                KategoriTemizle();
                AramaTemizle();

                cbBarkodHemenEkle.Enabled = true;
                cbBarkodHemenAra.Enabled = true;
                if (cbBarkodHemenAra.Checked)
                {
                    if (txtArama.Attributes["onkeyup"] == null)
                        txtArama.Attributes.Add("onkeyup", "javascript:__doPostBack('txtArama','')");
                }

                lblUrunSayisi.Text = "0 / 0";
                dlListe.DataSource = null;
                dlResimli.DataSource = null;
                DataBind();
                lblEmpty.Visible = true;
            }
            else
            {
                cbBarkodHemenEkle.Enabled = false;
                cbBarkodHemenAra.Enabled = false;
                txtArama.Attributes.Remove("onkeyup");
                //GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbBarkodaGore.Checked &&
                /*(txtArama.Text.Length == 14 || txtArama.Text.Length == 13 || txtArama.Text.Length == 12 || txtArama.Text.Length == 8) && */
                cbBarkodHemenEkle.Checked && cbBarkodHemenAra.Checked)
                BarkodAra(true);
            else if (rbBarkodaGore.Checked &&
                /*(txtArama.Text.Length == 14 || txtArama.Text.Length == 13 || txtArama.Text.Length == 12 || txtArama.Text.Length == 8) && */
                !cbBarkodHemenEkle.Checked && cbBarkodHemenAra.Checked)
                BarkodAra(false);
        }
        protected void txtOneriBarkod_TextChanged(object sender, EventArgs e)
        {
            bool var = false;
            DataTable dt = (DataTable)Session["OneriSiparisiDt"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["BARKOD"].ToString() == txtOneriBarkod.Text)
                {
                    var = true;
                    dt.Rows[i]["Secili"] = true;
                    break;
                }
            }

            if (!var)
                lblOneriBarkod.Text = "<span style='color: #900000'>Aranan: " + txtOneriBarkod.Text + " öneri siparişinde bulunmamaktadır.</span>";
            else
                lblOneriBarkod.Text = "<span style='color: #267F00'>Aranan: " + txtOneriBarkod.Text + "</span>";

            OneriSiparisDegistir();

            txtOneriBarkod.Text = "";
            txtOneriBarkod.Focus();
        }
        protected void rbOneri_CheckedChanged(object sender, EventArgs e)
        {
            OneriSiparisDegistir();
        }
        private void OneriSiparisDegistir()
        {
            DataTable dt = (DataTable)Session["OneriSiparisiDt"];
            DataTable dt1 = new DataTable();
            for (int i = 0; i < dt.Columns.Count; i++)
                dt1.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

            if (rbOneriSecili.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToBoolean(dt.Rows[i]["Secili"]))
                        dt1.Rows.Add(dt.Rows[i].ItemArray);
            }
            else if (rbOneriSecimsiz.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (!Convert.ToBoolean(dt.Rows[i]["Secili"]))
                        dt1.Rows.Add(dt.Rows[i].ItemArray);
            }
            else
            {
                dt1 = dt;
            }

            Repeater2.DataSource = dt1;
            Repeater2.DataBind();

            lblOneriSiparisiSayisi.Text = dt1.Rows.Count.ToString();
        }
        protected void cbBarkodHemenEkle_CheckedChanged(object sender, EventArgs e)
        {
            txtAramaMiktar.Enabled = cbBarkodHemenEkle.Checked;
            txtAramaMiktar.Text = cbBarkodHemenEkle.Checked ? "1" : "";
            //if (rbBarkodaGore.Checked)
            //{
            //    if (cbBarkodHemenEkle.Checked)
            //        txtArama.Attributes.Add("onkeyup", "javascript:__doPostBack('txtArama','')");
            //    else
            //        txtArama.Attributes.Remove("onkeyup");
            //}
        }
        protected void cbBarkodHemenAra_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarkodaGore.Checked)
            {
                if (cbBarkodHemenAra.Checked)
                {
                    if (txtArama.Attributes["onkeyup"] == null)
                        txtArama.Attributes.Add("onkeyup", "javascript:__doPostBack('txtArama','')");
                }
                else
                {
                    txtArama.Attributes.Remove("onkeyup");
                }
            }
        }
        #endregion

        #region Events Temizleme
        protected void btnHepsiniTemizle_Click(object sender, EventArgs e)
        {
            if (lblAramaSecim.Text != "-" || lblTedarikciSecim.Text != "-" || lblKategoriSecim.Text != "-")
            {
                if (UrunSecimTarama(false, false))
                {
                    divTedarikciKategoriDis.Visible = true;
                    divAktarim.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                    Session["Aktarim"] = "TumunuTemizleme";
                }
                else
                {
                    AramaTemizle();
                    TedarikciTemizle();
                    KategoriTemizle();

                    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                }
            }
        }
        protected void btnAramaTemizle_Click(object sender, EventArgs e)
        {
            if (lblAramaSecim.Text != "-")
            {
                if (UrunSecimTarama(false, false))
                {
                    divTedarikciKategoriDis.Visible = true;
                    divAktarim.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                    Session["Aktarim"] = "AramaTemizleme";
                }
                else
                {
                    AramaTemizle();
                    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                }
            }
        }
        protected void btnTedarikciTemizle_Click(object sender, EventArgs e)
        {
            if (lblTedarikciSecim.Text != "-")
            {
                if (UrunSecimTarama(false, false))
                {
                    divTedarikciKategoriDis.Visible = true;
                    divAktarim.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                    Session["Aktarim"] = "TedarikciTemizleme";
                }
                else
                {
                    TedarikciTemizle();
                    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                }
            }
        }
        protected void btnKategoriTemizle_Click(object sender, EventArgs e)
        {
            if (lblKategoriSecim.Text != "-")
            {
                if (UrunSecimTarama(false, false))
                {
                    divTedarikciKategoriDis.Visible = true;
                    divAktarim.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                    Session["Aktarim"] = "KategoriTemizleme";
                }
                else
                {
                    KategoriTemizle();
                    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                }
            }
        }
        #endregion

        #region Events Düzen Sıralama
        protected void Duzen_CheckedChanged(object sender, EventArgs e)
        {
            if (UrunSecimTarama(false, true))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "Duzen";

                rbResimDuzeni.Checked = !rbResimDuzeni.Checked;
                rbListeDuzeni.Checked = !rbListeDuzeni.Checked;
            }
            else
            {
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void SiralamaAzalanArtan_CheckedChanged(object sender, EventArgs e)
        {
            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "Siralama";

                rbSiralamaAzalan.Checked = !rbSiralamaAzalan.Checked;
                rbSiralamaArtan.Checked = !rbSiralamaArtan.Checked;
            }
            else
            {
                if (rbSiralamaAzalan.Checked)
                    Session["AzalanArtan"] = "DESC";
                else if (rbSiralamaArtan.Checked)
                    Session["AzalanArtan"] = "ASC";

                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void Siralama_CheckedChanged(object sender, EventArgs e)
        {
            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "SiralamaTuru";

                string siralama = string.Empty;

                if (rbTariheGoreSiralama.Checked)
                    siralama = "UrunID";
                else if (rbABCSiralama.Checked)
                    siralama = "Ad";
                else if (rbFYTSiralama.Checked)
                    siralama = "Fiyat";

                if (Session["Siralama"] == "UrunID")
                {
                    rbABCSiralama.Checked = false;
                    rbFYTSiralama.Checked = false;
                    rbTariheGoreSiralama.Checked = true;
                }
                else if (Session["Siralama"] == "TedarikciAdi")
                {
                    rbFYTSiralama.Checked = false;
                    rbTariheGoreSiralama.Checked = false;
                    rbABCSiralama.Checked = true;
                }
                else if (Session["Siralama"] == "Fiyat")
                {
                    rbTariheGoreSiralama.Checked = false;
                    rbABCSiralama.Checked = false;
                    rbFYTSiralama.Checked = true;
                }

                Session["Siralama"] = siralama;
            }
            else
            {
                if (rbTariheGoreSiralama.Checked)
                    Session["Siralama"] = "UrunID";
                else if (rbABCSiralama.Checked)
                    Session["Siralama"] = "TedarikciAdi";
                else if (rbFYTSiralama.Checked)
                    Session["Siralama"] = "Fiyat";

                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        #endregion

        #region Events Tedarikçi Kategori Seçim
        protected void lbTedarikciKapat_Click(object sender, EventArgs e)
        {
            divTedarikci.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblTedarikciler.Items.Clear();
        }
        protected void lbKategoriKapat_Click(object sender, EventArgs e)
        {
            divKategori.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblKategoriler.Items.Clear();
        }
        protected void rblTedarikciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Start"] = 0;
            cbYeniUrunler.Checked = false;

            Session["OncekiTedarikci"] = Session["Tedarikci"];

            Session["Tedarikci"] = rblTedarikciler.SelectedItem.Value;
            string secim = rblTedarikciler.SelectedItem.Text;
            int parantezindex = secim.IndexOf("(");
            if (parantezindex > 0)
                secim = secim.Substring(0, parantezindex - 1);
            lblTedarikciSecim.Text = secim;

            divTedarikci.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblTedarikciler.Items.Clear();

            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "Tedarikci";
            }
            else
            {
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void rblKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Start"] = 0;
            cbYeniUrunler.Checked = false;

            Session["OncekiKategori"] = Session["Kategori"];

            Session["Kategori"] = rblKategoriler.SelectedItem.Value;
            string secim = rblKategoriler.SelectedItem.Text;
            int parantezindex = secim.IndexOf("(");
            if (parantezindex > 0)
                secim = secim.Substring(0, parantezindex - 1);
            lblKategoriSecim.Text = secim;

            divKategori.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblKategoriler.Items.Clear();

            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "Kategori";
            }
            else
            {
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void TedarikciIsmindenSecim_Click(object sender, EventArgs e)
        {
            Session["Start"] = 0;
            cbYeniUrunler.Checked = false;

            Session["OncekiTedarikci"] = Session["Tedarikci"];

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("TedarikciAdi"))
                    {
                        lblTedarikciSecim.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                    else if (ctrl.ID.StartsWith("TedarikciID"))
                    {
                        Session["Tedarikci"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "Tedarikci";
            }
            else
            {
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void KategoriIsmindenSecim_Click(object sender, EventArgs e)
        {
            Session["Start"] = 0;
            cbYeniUrunler.Checked = false;

            Session["OncekiKategori"] = Session["Kategori"];

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("KategoriAdi"))
                    {
                        lblKategoriSecim.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                    else if (ctrl.ID.StartsWith("KategoriID"))
                    {
                        Session["Kategori"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "Kategori";
            }
            else
            {
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        #endregion

        #region Events Siparişe Aktarım
        protected void btnSipariseAktar_Click(object sender, EventArgs e)
        {
            UrunSecimTarama(true, false);
            SepetBilgisiGuncelle();
        }
        protected void btnAktarimDevam_Click(object sender, EventArgs e)
        {
            if (Session["Aktarim"] == "Duzen")
            {
                rbResimDuzeni.Checked = !rbResimDuzeni.Checked;
                rbListeDuzeni.Checked = !rbListeDuzeni.Checked;
            }
            else if (Session["Aktarim"] == "Siralama")
            {
                rbSiralamaAzalan.Checked = !rbSiralamaAzalan.Checked;
                rbSiralamaArtan.Checked = !rbSiralamaArtan.Checked;

                if (rbSiralamaAzalan.Checked)
                    Session["AzalanArtan"] = "DESC";
                else if (rbSiralamaArtan.Checked)
                    Session["AzalanArtan"] = "ASC";
            }
            else if (Session["Aktarim"] == "SiralamaTuru")
            {
                if (Session["Siralama"] == "UrunID")
                {
                    rbABCSiralama.Checked = false;
                    rbFYTSiralama.Checked = false;
                    rbTariheGoreSiralama.Checked = true;
                }
                else if (Session["Siralama"] == "TedarikciAdi")
                {
                    rbFYTSiralama.Checked = false;
                    rbTariheGoreSiralama.Checked = false;
                    rbABCSiralama.Checked = true;
                }
                else if (Session["Siralama"] == "Fiyat")
                {
                    rbTariheGoreSiralama.Checked = false;
                    rbABCSiralama.Checked = false;
                    rbFYTSiralama.Checked = true;
                }
            }
            else if (Session["Aktarim"] == "Arama")
            {
                Session["Aranan"] = txtArama.Text.Trim();
                string aramasecim = " (Başlangıca göre)";
                if (rbIcinde.Checked)
                    aramasecim = " (İçinde)";
                lblAramaSecim.Text = txtArama.Text + aramasecim;
            }
            else if (Session["Aktarim"] == "Tedarikci")
            {
                //
            }
            else if (Session["Aktarim"] == "Kategori")
            {
                //
            }
            else if (Session["Aktarim"] == "AramaTemizleme")
            {
                AramaTemizle();
            }
            else if (Session["Aktarim"] == "TedarikciTemizleme")
            {
                TedarikciTemizle();
            }
            else if (Session["Aktarim"] == "KategoriTemizleme")
            {
                KategoriTemizle();
            }
            else if (Session["Aktarim"] == "TumunuTemizleme")
            {
                AramaTemizle();
                TedarikciTemizle();
                KategoriTemizle();
            }
            else if (Session["Aktarim"] == "SayfaDegismeGeri")
            {
                Session["Start"] = (int)Session["Start"] - (int)Session["Count"];
                if ((int)Session["Start"] < 0)
                {
                    Session["Start"] = 0;
                }
            }
            else if (Session["Aktarim"] == "SayfaDegismeIleri")
            {
                Session["Start"] = (int)Session["Start"] + (int)Session["Count"];
                if ((int)Session["Start"] > (int)Session["MaxRecordCount"] - 5)
                {
                    Session["Start"] = (int)Session["MaxRecordCount"] - 5;
                }
            }
            else if (Session["Aktarim"] == "FiyatTipiDegistir")
            {
                FiyatTipiDegistir();
                SepetBilgisiGuncelle();
            }
            else if (Session["Aktarim"] == "TaksitPlaniDegistir")
            {
                TaksitPlaniDegistir();
            }

            if (rbMalzemeler.Checked)
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            else
                ucKampanyalar1.GetObjects();

            divTedarikciKategoriDis.Visible = false;
            divAktarim.Visible = false;
        }
        protected void btnAktarimDur_Click(object sender, EventArgs e)
        {
            if (Session["Aktarim"] == "SiralamaTuru")
            {
                if (rbTariheGoreSiralama.Checked)
                    Session["Siralama"] = "UrunID";
                else if (rbABCSiralama.Checked)
                    Session["Siralama"] = "TedarikciAdi";
                else if (rbFYTSiralama.Checked)
                    Session["Siralama"] = "Fiyat";
            }
            else if (Session["Aktarim"] == "Tedarikci")
            {
                Session["Tedarikci"] = Session["OncekiTedarikci"];
                lblTedarikciSecim.Text = "-";
            }
            else if (Session["Aktarim"] == "Kategori")
            {
                Session["Kategori"] = Session["OncekiKategori"];
                lblKategoriSecim.Text = "-";
            }
            else if (Session["Aktarim"] == "FiyatTipiDegistir")
            {
                for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
                {
                    if (ddlFiyatTipleri.Items[i].Value == ((SiparisListe)Session["Siparis"])._FiyatTipi.ToString())
                    {
                        ddlFiyatTipleri.SelectedIndex = i;
                        i = ddlFiyatTipleri.Items.Count;
                    }
                }
            }
            else if (Session["Aktarim"] == "TaksitPlaniDegistir")
            {
                for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
                {
                    if (ddlTaksitPlanlari.Items[i].Value == ((SiparisListe)Session["Siparis"])._TKSREF.ToString())
                    {
                        ddlTaksitPlanlari.SelectedIndex = i;
                        i = ddlTaksitPlanlari.Items.Count;
                    }
                }
            }

            divTedarikciKategoriDis.Visible = false;
            divAktarim.Visible = false;
        }
        #endregion

        #region Events Sipariş Sepeti, SiparisSepettenUrunSil
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                long siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("SiparisDetayID")).Value);
                //int urunid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("UrunID")).Value);
                Guid kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamKartRef")).Value);
                //bool kampanyahediye = Convert.ToBoolean(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KampanyaHediye")).Value);
                //Guid kamsatirref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamSatirRef")).Value);

                ArrayList al = new ArrayList();
                al.Add(siparisdetayid);
                al.Add(kamkartref);

                Session["SiparisSepettenSil"] = al;

                if (kamkartref !=Guid.Empty)
                    divSiparisSepettenSil.Visible = true;
                else
                    SiparisSepettenUrunSil();
            }
            else if (e.CommandName == "Guncelle")
            {
                long siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("SiparisDetayID")).Value);
                //int urunid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("UrunID")).Value);
                int yenimiktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("Miktar")).Value);
                decimal fiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("BirimFiyat")).Value); // fuzuli
                Guid kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamKartRef")).Value);
                //bool kampanyahediye = Convert.ToBoolean(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KampanyaHediye")).Value);
                //Guid kamsatirref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamSatirRef")).Value);
                string miktartur = ((DropDownList)e.Item.FindControl("ddlMiktarTur")).SelectedValue;

                int urunid = SiparislerDetay.GetObjectBySiparislerDetayID(siparisdetayid).intUrunID;
                fiyat = miktartur == "KI" ? Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi) * Convert.ToDecimal(Urunler.GetKoliAdedi(urunid)) : miktartur == "PAK" ? Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi) * Convert.ToDecimal(Urunler.GetProductBirim(urunid)) : Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi);

                if (kamkartref != Guid.Empty)
                {
                    divKampanyaMiktarDegismez.Visible = true;
                    return;
                }
                else
                {
                    ((SiparisListe)Session["Siparis"]).Update(siparisdetayid, yenimiktar, fiyat, miktartur); /*adtadt*/
                    ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);
                    GetSiparisSepeti();
                }
            }
            else if (e.CommandName == "Arttir")
            {
                int urunid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("UrunID")).Value);
                decimal fiyat = Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi);
                Guid kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamKartRef")).Value);
                bool kampanyahediye = Convert.ToBoolean(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KampanyaHediye")).Value);
                //Guid kamsatirref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamSatirRef")).Value);

                if (kamkartref != Guid.Empty)
                {
                    Kampanya kamp = new Kampanya(kamkartref, 1);
                    kamp.DoInsert((SiparisListe)Session["Siparis"]);
                }
                else
                {
                    ((SiparisListe)Session["Siparis"]).Add(urunid, 1, fiyat, kamkartref, kampanyahediye, Guid.Empty, false);
                }

                ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

                GetSiparisSepeti();
            }
            else if (e.CommandName == "Azalt")
            {
                int urunid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("UrunID")).Value);
                decimal fiyat = Urunler.GetProductPrice(urunid, ((SiparisListe)Session["Siparis"])._FiyatTipi);
                Guid kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamKartRef")).Value);
                bool kampanyahediye = Convert.ToBoolean(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KampanyaHediye")).Value);
                //Guid kamsatirref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("KamSatirRef")).Value);

                if (kamkartref != Guid.Empty)
                {
                    DataTable dt = new DataTable();
                    Kampanyalar.GetAnaUrunler(dt, kamkartref);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int UrunID = Convert.ToInt32(dt.Rows[i]["ITEMREF"]);
                        int Miktar = Convert.ToInt32(dt.Rows[i]["MIKTAR"]);
                        Guid kamsatirref = Guid.Parse(dt.Rows[i]["KAMPANASATREF"].ToString());

                        bool kampanyadahaeksiltilmez = ((SiparisListe)Session["Siparis"]).Add(UrunID, -Miktar, fiyat, kamkartref, false, kamsatirref, false);
                        if (kampanyadahaeksiltilmez)
                            return;
                    }

                    dt = new DataTable();
                    Kampanyalar.GetHediyeUrunler(dt, kamkartref);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int UrunID = Convert.ToInt32(dt.Rows[i]["ITEMREF"]);
                        int Miktar = Convert.ToInt32(dt.Rows[i]["MIKTAR"]);
                        Guid kamsatirref = Guid.Parse(dt.Rows[i]["KAMPHEDSATREF"].ToString());

                        ((SiparisListe)Session["Siparis"]).Add(UrunID, -Miktar, fiyat, kamkartref, true, kamsatirref, false);
                    }
                }
                else
                {
                    bool urundahaeksiltilmez = ((SiparisListe)Session["Siparis"]).Add(urunid, -1, fiyat, kamkartref, kampanyahediye, Guid.Empty, false);
                    if (urundahaeksiltilmez)
                        return;
                }

                ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

                GetSiparisSepeti();
            }
        }
        private void SiparisSepettenUrunSil()
        {
            ArrayList al = (ArrayList)Session["SiparisSepettenSil"];

            long siparisdetayid = (long)al[0];
            Guid kamkartref = (Guid)al[1];

            ((SiparisListe)Session["Siparis"]).Remove(siparisdetayid, kamkartref);
            ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

            GetSiparisSepeti();

            Session["SiparisSepettenSil"] = null;
        }
        protected void btnSiparisSepettenSilDevam_Click(object sender, EventArgs e)
        {
            SiparisSepettenUrunSil();
            divSiparisSepettenSil.Visible = false;
        }
        protected void btnSiparisSepettenSilDur_Click(object sender, EventArgs e)
        {
            Session["SiparisSepettenSil"] = null;
            divSiparisSepettenSil.Visible = false;
        }
        protected void lbSepetBuyut_Click(object sender, EventArgs e)
        {
            divSepet.Visible = true;
            divTedarikciKategoriDis.Visible = true;

            GetSiparisSepeti();
        }
        protected void ibSepetBuyut_Click(object sender, ImageClickEventArgs e)
        {
            divSepet.Visible = true;
            divTedarikciKategoriDis.Visible = true;

            GetSiparisSepeti();
        }
        protected void lbSepetKapat_Click(object sender, EventArgs e)
        {
            divSepet.Visible = false;
            divTedarikciKategoriDis.Visible = false;

            Session["SepetUrunSecimleri"] = new ArrayList();

            if (rbMalzemeler.Checked)
                SepetBilgisiGuncelle();
            else
                ucKampanyalar1.SepetBilgisiGuncelle();
        }
        protected void btnSiparisiTamamla_Click(object sender, EventArgs e)
        {
            //// sipariş ve sipariş detaylar veritabanına yazılmıyorken kullanılıyor:
            //// <<
            //SiparisListe siplist = ((SiparisListe)Session["Siparis"]);

            //Siparisler siparis = null;
            //if (Convert.ToInt32(Session["SiparisID"]) == 0) // yeni sipariş oluşturulmuşsa
            //{
            //    siparis = new Siparisler(siplist._MusteriID, siplist._SMREF, siplist._FiyatTipi, DateTime.Now,
            //        siplist.ToplamTutar, false, TaksitPlanlari.GetObject(Convert.ToInt32(ddlTaksitPlanlari.SelectedValue)).TKSREF, 
            //        DateTime.Now, string.Empty);
            //    siparis.DoInsert();
            //}
            //else // siparişi değiştir denilmişse
            //{
            //    siparis = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(Session["SiparisID"]));
            //    siparis.intMusteriID = siplist._MusteriID;
            //    siparis.SMREF = siplist._SMREF;
            //    siparis.sintFiyatTipiID = siplist._FiyatTipi;
            //    siparis.mnToplamTutar = siplist.ToplamTutar;
            //    siparis.DoUpdate();

            //    SiparislerDetay.DoDelete(siparis.pkSiparisID);
            //}

            //for (int i = 0; i < siplist.Count; i++)
            //{
            //    SiparisDetayi sipdet = (SiparisDetayi)siplist[i];

            //    SiparislerDetay siplerdet = new SiparislerDetay(siparis.pkSiparisID, sipdet._UrunID, sipdet._Miktar, sipdet._BirimFiyat,
            //        sipdet._KamKartRef, sipdet._KampanyaHediye);
            //    siplerdet.DoInsert();
            //}
            //// >>

            Session["SiparisTamamlaBasildi"] = ((SiparisListe)Session["Siparis"])._SMREF;
            Session["SiparisTamamlaBasildiSiparisID"] = ((SiparisListe)Session["Siparis"])._SiparisID;
            SiparisYarimKalanDegil();
            Response.Redirect("siparisler.aspx");
        }
        protected void btnSiparisiTamamlaOnayla_Click(object sender, EventArgs e)
        {
            Session["SiparisTamamlaOnaylaBasildi"] = ((SiparisListe)Session["Siparis"])._SMREF;
            Session["OnaylanacakSiparisID"] = ((SiparisListe)Session["Siparis"])._SiparisID;
            SiparisYarimKalanDegil();
            Response.Redirect("siparisler.aspx");
        }
        protected void btnSepetiBosalt_Click(object sender, EventArgs e)
        {
            divSepetiBosalt.Visible = true;
        }
        protected void btnSepetiBosaltEvet_Click(object sender, EventArgs e)
        {
            SepetiBosalt();
            GetSiparisSepeti();
            divSepetiBosalt.Visible = false;
        }
        protected void btnSepetiBosaltHayir_Click(object sender, EventArgs e)
        {
            divSepetiBosalt.Visible = false;
        }
        protected void btnSiparisiIptalEt_Click(object sender, EventArgs e)
        {
            divSiparisIptal.Visible = true;
        }
        protected void btnSiparisIptalEvet_Click(object sender, EventArgs e)
        {
            SiparisIptal();
        }
        protected void btnSiparisIptalHayir_Click(object sender, EventArgs e)
        {
            divSiparisIptal.Visible = false;
        }
        protected void btnSepetSeciliUrunlerSil_Click(object sender, EventArgs e)
        {
            ArrayList UrunSecimleri = (ArrayList)Session["SepetUrunSecimleri"];

            for (int i = 0; i < UrunSecimleri.Count; i++)
            {
                long siparisdetayid = (long)((ArrayList)UrunSecimleri[i])[0];
                Guid kamkartref = (Guid)((ArrayList)UrunSecimleri[i])[1];

                ((SiparisListe)Session["Siparis"]).Remove(siparisdetayid, kamkartref);
                ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

                GetSiparisSepeti();
            }

            Session["SepetUrunSecimleri"] = new ArrayList();

            cbSepetSecimTumu.Checked = false;
            foreach (Control ctrl in Repeater1.Controls)
                foreach (Control ctrl2 in ctrl.Controls)
                    if (ctrl2 is CheckBox)
                        ((CheckBox)ctrl2).Checked = false;
        }
        protected void cbSepetSecimTumu_OnCheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in Repeater1.Controls)
            {
                long siparisdetayid = 0;
                Guid kamkartref = Guid.Parse("90264d63-a72a-4528-a1cb-575ede09200a"); // öylesine guid
                ArrayList icerik = new ArrayList();

                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is CheckBox)
                    {
                        ((CheckBox)ctrl2).Checked = ((CheckBox)sender).Checked;
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("SiparisDetayID"))
                    {
                        siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("KamKartRef"))
                    {
                        kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                }

                if (siparisdetayid != 0 && kamkartref.ToString() != "90264d63-a72a-4528-a1cb-575ede09200a")
                {
                    icerik.Add(siparisdetayid);
                    icerik.Add(kamkartref);

                    if (((CheckBox)sender).Checked)
                    {
                        ((ArrayList)Session["SepetUrunSecimleri"]).Add(icerik);
                    }
                    else
                    {
                        ArrayList UrunSecimleri = (ArrayList)Session["SepetUrunSecimleri"];
                        int silinecekindex = -1;

                        for (int i = 0; i < UrunSecimleri.Count; i++)
                        {
                            long ID = (long)((ArrayList)UrunSecimleri[i])[0];
                            Guid REF = (Guid)((ArrayList)UrunSecimleri[i])[1];

                            if (ID == siparisdetayid && REF == kamkartref)
                            {
                                silinecekindex = i;
                                break;
                            }
                        }

                        if (silinecekindex != -1)
                            ((ArrayList)Session["SepetUrunSecimleri"]).RemoveAt(silinecekindex);
                    }
                }
            }
        }
        protected void SepetUrunSecim_Click(object sender, EventArgs e)
        {
            long siparisdetayid = 0;
            Guid kamkartref = Guid.Parse("90264d63-a72a-4528-a1cb-575ede09200a"); // öylesine guid
            ArrayList icerik = new ArrayList();

            foreach (Control ctrl in ((CheckBox)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisDetayID"))
                    {
                        siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                    else if (ctrl.ID.StartsWith("KamKartRef"))
                    {
                        kamkartref = Guid.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }

            if (siparisdetayid != 0 && kamkartref.ToString() != "90264d63-a72a-4528-a1cb-575ede09200a")
            {
                icerik.Add(siparisdetayid);
                icerik.Add(kamkartref);

                if (((CheckBox)sender).Checked)
                {
                    ((ArrayList)Session["SepetUrunSecimleri"]).Add(icerik);
                }
                else
                {
                    ArrayList UrunSecimleri = (ArrayList)Session["SepetUrunSecimleri"];
                    int silinecekindex = -1;

                    for (int i = 0; i < UrunSecimleri.Count; i++)
                    {
                        long ID = (long)((ArrayList)UrunSecimleri[i])[0];
                        Guid REF = (Guid)((ArrayList)UrunSecimleri[i])[1];

                        if (ID == siparisdetayid && REF == kamkartref)
                        {
                            silinecekindex = i;
                            break;
                        }
                    }

                    if (silinecekindex != -1)
                        ((ArrayList)Session["SepetUrunSecimleri"]).RemoveAt(silinecekindex);
                }
            }
        }
        protected void btnSepetGuncelle_Click(object sender, EventArgs e)
        {
            TumunuGuncelle();
        }
        #endregion

        #region Events Ürün Seçimi İleri Geri
        protected void lbOnceki_Click(object sender, EventArgs e)
        {
            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "SayfaDegismeGeri";
            }
            else
            {
                Session["MaxRecordCount"] = GetProductsCount();

                Session["Start"] = (int)Session["Start"] - (int)Session["Count"];
                if ((int)Session["Start"] < 0)
                    Session["Start"] = 0;

                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void lbSonraki_Click(object sender, EventArgs e)
        {
            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "SayfaDegismeIleri";
            }
            else
            {
                //Session["MaxRecordCount"] = GetProductsCount();

                Session["Start"] = (int)Session["Start"] + (int)Session["Count"];
                //if ((int)Session["Start"] > (int)Session["MaxRecordCount"] - 5)
                //    Session["Start"] = (int)Session["MaxRecordCount"] - 5;

                if ((int)Session["Start"] < 0)
                    Session["Start"] = 0;

                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        #endregion

        #region Events Fiyat Tipi
        protected void ddlFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiyatTipleri.SelectedValue == ((SiparisListe)Session["Siparis"])._FiyatTipi.ToString())
                return;

            Session["OncekiFiyatTipi"] = ((SiparisListe)Session["Siparis"])._FiyatTipi;
            divFiyatTipiDegisme.Visible = true;
        }
        protected void btnFiyatTipiDegismeDevam_Click(object sender, EventArgs e)
        {
            divFiyatTipiDegisme.Visible = false;

            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "FiyatTipiDegistir";
            }
            else
            {
                //int anlasmaid = Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF), DateTime.Now, "2");
                //if (anlasmaid > 0 && (ddlFiyatTipleri.SelectedItem.Value == "3" || ddlFiyatTipleri.SelectedItem.Value == "4" || ddlFiyatTipleri.SelectedItem.Value == "7" || ddlFiyatTipleri.SelectedItem.Value == "8"))
                //    return;

                if (((SiparisListe)Session["Siparis"])._FiyatTipi > 500)
                    return;

                FiyatTipiDegistir();
                SepetBilgisiGuncelle();
            }
        }
        protected void btnFiyatTipiDegismeDur_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
            {
                if (ddlFiyatTipleri.Items[i].Value == Session["OncekiFiyatTipi"].ToString())
                {
                    Session["OncekiFiyatTipi"] = null;
                    ddlFiyatTipleri.SelectedIndex = i;
                    break;
                }
            }

            divFiyatTipiDegisme.Visible = false;
        }
        #endregion

        #region Event Taksit Planlari
        protected void ddlTaksitPlanlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTaksitPlanlari.SelectedValue == ((SiparisListe)Session["Siparis"])._TKSREF.ToString())
                return;

            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAktarim, typeof(string), "scriptSayfayukaricikar", alert, false);

                Session["Aktarim"] = "TaksitPlaniDegistir";
            }
            else
            {
                TaksitPlaniDegistir();
            }
        }
        #endregion

        #region Events Öneri Siparişi
        protected void btnOneriSiparisi_Click(object sender, EventArgs e)
        {
            OneriSiparisi();

            if (txtOneriBarkod.Attributes["onkeyup"] == null)
                txtOneriBarkod.Attributes.Add("onkeyup", "javascript:__doPostBack('txtOneriBarkod','')");
        }
        protected void ibOneriSiparisiOnceki_Click(object sender, EventArgs e)
        {
            bool miktargirildi = false;
            foreach (Control ctrl in Repeater2.Controls)
                foreach (Control ctrl2 in ctrl.Controls)
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("Miktar"))
                        if (((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value.Trim() != string.Empty)
                            miktargirildi = true;

            if (Convert.ToInt32(lblOneriSiparisiKacinci.Text) == 0)
            {

            }
            else if (Convert.ToInt32(lblOneriSiparisiKacinci.Text) - 200 > 0)
            {
                if (!miktargirildi)
                {
                    OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], Convert.ToInt32(lblOneriSiparisiKacinci.Text) - 200, 100);
                    lblOneriSiparisiKacinci.Text = (Convert.ToInt32(lblOneriSiparisiKacinci.Text) - 100).ToString();
                }
                else
                {
                    Session["OneriSiparisiAktarim"] = "3";

                    divOneriSiparisiUyari.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divOneriSiparisiUyari, typeof(string), "scriptSayfayukaricikar", alert, false);
                }
            }
            else
            {
                if (!miktargirildi)
                {
                    OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], 0, 100);
                    lblOneriSiparisiKacinci.Text = "100";
                }
                else
                {
                    Session["OneriSiparisiAktarim"] = "4";

                    divOneriSiparisiUyari.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divOneriSiparisiUyari, typeof(string), "scriptSayfayukaricikar", alert, false);
                }
            }
        }
        protected void ibOneriSiparisiSonraki_Click(object sender, EventArgs e)
        {
            bool miktargirildi = false;
            foreach (Control ctrl in Repeater2.Controls)
                foreach (Control ctrl2 in ctrl.Controls)
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("Miktar"))
                        if (((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value.Trim() != string.Empty)
                            miktargirildi = true;

            if (Convert.ToInt32(lblOneriSiparisiKacinci.Text) == Convert.ToInt32(lblOneriSiparisiSayisi.Text))
            {

            }
            else if (Convert.ToInt32(lblOneriSiparisiKacinci.Text) + 100 < Convert.ToInt32(lblOneriSiparisiSayisi.Text))
            {
                if (!miktargirildi)
                {
                    OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], Convert.ToInt32(lblOneriSiparisiKacinci.Text), 100);
                    lblOneriSiparisiKacinci.Text = (Convert.ToInt32(lblOneriSiparisiKacinci.Text) + 100).ToString();
                }
                else
                {
                    Session["OneriSiparisiAktarim"] = "1";

                    divOneriSiparisiUyari.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divOneriSiparisiUyari, typeof(string), "scriptSayfayukaricikar", alert, false);
                }
            }
            else
            {
                if (!miktargirildi)
                {
                    OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], Convert.ToInt32(lblOneriSiparisiKacinci.Text), 100);
                    lblOneriSiparisiKacinci.Text = lblOneriSiparisiSayisi.Text;
                }
                else
                {
                    Session["OneriSiparisiAktarim"] = "2";

                    divOneriSiparisiUyari.Visible = true;

                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divOneriSiparisiUyari, typeof(string), "scriptSayfayukaricikar", alert, false);
                }
            }
        }
        protected void btnOneriSiparisiUyariDevam_Click(object sender, EventArgs e)
        {
            if (Session["OneriSiparisiAktarim"].ToString() == "1")
            {
                OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], Convert.ToInt32(lblOneriSiparisiKacinci.Text), 100);
                lblOneriSiparisiKacinci.Text = (Convert.ToInt32(lblOneriSiparisiKacinci.Text) + 100).ToString();
            }
            else if (Session["OneriSiparisiAktarim"].ToString() == "2")
            {
                OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], Convert.ToInt32(lblOneriSiparisiKacinci.Text), 100);
                lblOneriSiparisiKacinci.Text = lblOneriSiparisiSayisi.Text;
            }
            else if (Session["OneriSiparisiAktarim"].ToString() == "3")
            {
                OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], Convert.ToInt32(lblOneriSiparisiKacinci.Text) - 200, 100);
                lblOneriSiparisiKacinci.Text = (Convert.ToInt32(lblOneriSiparisiKacinci.Text) - 100).ToString();
            }
            else if (Session["OneriSiparisiAktarim"].ToString() == "4")
            {
                OneriSiparisiOlustur((bool)Session["OneriSiparisiGMREFdir"], 0, 100);
                lblOneriSiparisiKacinci.Text = "100";
            }

            divOneriSiparisiUyari.Visible = false;
        }
        protected void btnOneriSiparisiUyariDur_Click(object sender, EventArgs e)
        {
            divOneriSiparisiUyari.Visible = false;
        }
        protected void btnOneriSiparisiSubeDevam_Click(object sender, EventArgs e)
        {
            if (rbOneriSiparisiGMREF.Checked)
            {
                int gmref = CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF);
                int sayi = SatisRapor.GetProductCountByGMREF(gmref, ((SiparisListe)Session["Siparis"])._FiyatTipi,
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);
                lblOneriSiparisiSayisi.Text = sayi.ToString();
                if (sayi < 100)
                    lblOneriSiparisiKacinci.Text = sayi.ToString();
                else
                    lblOneriSiparisiKacinci.Text = "100";
            }
            else
            {
                int sayi = SatisRapor.GetProductCountBySMREF(((SiparisListe)Session["Siparis"])._SMREF, ((SiparisListe)Session["Siparis"])._FiyatTipi,
                    ((UyeYetkileri)Session["SiparisYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["SiparisYetkiler"]).GrupKodlar);
                lblOneriSiparisiSayisi.Text = sayi.ToString();
                if (sayi < 100)
                    lblOneriSiparisiKacinci.Text = sayi.ToString();
                else
                    lblOneriSiparisiKacinci.Text = "100";
            }

            OneriSiparisiOlustur(rbOneriSiparisiGMREF.Checked, 0, 100);
            divOneriSiparisiSube.Visible = false;
            divOneri.Visible = true;
        }
        protected void btnOneriSiparisiSubeVazgec_Click(object sender, EventArgs e)
        {
            Session["OneriSiparisiGMREFdir"] = null;
            divOneriSiparisiSube.Visible = false;
        }
        protected void btnOneriSipariseAktar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Repeater2.Controls)
            {
                int itemref = 0;
                int miktar = -1;
                decimal birimfiyat = 0;

                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("ITEMREF"))
                    {
                        itemref = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("Miktar"))
                    {
                        if (((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value.Trim() != string.Empty)
                        {
                            miktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value);

                            ((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value = string.Empty;
                        }
                    }
                    //else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("BirimFiyat"))
                    //{
                    //    birimfiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    //}
                }

                birimfiyat = Urunler.GetProductPrice(itemref, ((SiparisListe)Session["Siparis"])._FiyatTipi);

                if (miktar > 0 && itemref != 0)
                {
                    ((SiparisListe)Session["Siparis"]).Add(itemref, miktar, birimfiyat, Guid.Empty, false, Guid.Empty, false);
                }
            }

            ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);

            //divOneri.Visible = false;
            //Session["OneriSiparisiGMREFdir"] = null;

            //GetSiparisSepeti();

            //divTedarikciKategoriDis.Visible = true;
            //divSepet.Visible = true;
        }
        protected void btnOneriVazgec_Click(object sender, EventArgs e)
        {
            if (rbMalzemeler.Checked)
                SepetBilgisiGuncelle();
            else
                ucKampanyalar1.SepetBilgisiGuncelle();

            Session["OneriSiparisiGMREFdir"] = null;
            divOneri.Visible = false;

            txtOneriBarkod.Attributes.Remove("onkeyup");
        }
        #endregion

        protected void rbMalzemeler_CheckedChanged(object sender, EventArgs e)
        {
            tblURUNLER.Visible = rbMalzemeler.Checked;

            if (rbMalzemeler.Checked)
                divSepetBuyut.Style["top"] = "285px";
            else
                divSepetBuyut.Style["top"] = "160px";
            ucKampanyalar1.Visible = rbKampanyalar.Checked;

            if (rbMalzemeler.Checked)
            {
                btnMalzemelereGeriDon.Visible = false;
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                SepetBilgisiGuncelle();
            }
            else
            {
                btnMalzemelereGeriDon.Visible = true;
                ucKampanyalar1.GetObjects();
                ucKampanyalar1.SepetBilgisiGuncelle();
            }
        }

        protected void lbKampanyaMiktarDegismez_Click(object sender, EventArgs e)
        {
            divKampanyaMiktarDegismez.Visible = false;
        }

        protected void lbUrunFiyatiDegisti_Click(object sender, EventArgs e)
        {
            divUrunFiyatiDegisti.Visible = false;
        }

        protected void KampanyaliUrun_Click(object sender, ImageClickEventArgs e)
        {
            int UrunID = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            rbMalzemeler.Checked = false;
            rbKampanyalar.Checked = true;
            tblURUNLER.Visible = false;
            divSepetBuyut.Style["top"] = "132px";
            ucKampanyalar1.Visible = true;
            ucKampanyalar1.GetObjectsByUrunID(UrunID);
            ucKampanyalar1.SepetBilgisiGuncelle();
            btnMalzemelereGeriDon.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(ucKampanyalar1, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void btnMalzemelereGeriDon_Click(object sender, EventArgs e)
        {
            //Session["TedarikciKamp"] = "NOT NULL";
            //Session["KategoriKamp"] = "NOT NULL";
            //ucKampanyalar1.GetObjects();
            rbKampanyalar.Checked = false;
            rbMalzemeler.Checked = true;
            tblURUNLER.Visible = true;
            divSepetBuyut.Style["top"] = "253px";
            ucKampanyalar1.Visible = false;
            btnMalzemelereGeriDon.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SiparisYarimKalanDegil();
            Response.Redirect("cikis.aspx", true);
        }

        protected void lbSayfayaGit_Click(object sender, EventArgs e)
        {
            SiparisYarimKalanDegil();

            if (((Button)sender).ID == "lbAnaSayfayaGit")
                Response.Redirect("default.aspx", true);
            else if (((Button)sender).ID == "lbHesapAyrintiGit")
                Response.Redirect("hesapayrinti.aspx", true);
            else if (((Button)sender).ID == "lbAktivitelerGit")
                Response.Redirect("aktiviteler.aspx", true);
            else if (((Button)sender).ID == "lbHizmetBedelleriGit")
                Response.Redirect("hizmetbedelleri.aspx", true);
            else if (((Button)sender).ID == "lbAnlasmalarGit")
                Response.Redirect("anlasmalar.aspx", true);
            else if (((Button)sender).ID == "lbSiparislerGit")
                Response.Redirect("siparisler.aspx", true);
            else if (((Button)sender).ID == "lbIadelerGit")
                Response.Redirect("iadeler.aspx", true);
            else if (((Button)sender).ID == "lbOdemelerGit")
                Response.Redirect("odemeler.aspx", true);
            else if (((Button)sender).ID == "lbUyelikIslemleriGit")
                Response.Redirect("uyelik.aspx", true);
            else if (((Button)sender).ID == "lbMesajlarGit")
                Response.Redirect("mesajlar.aspx", true);
        }

        protected void lbUrunAyrinti_Click(object sender, EventArgs e)
        {
            int ResimID = 0;
            int UrunID = 0;
            int FiyatTipi = ((SiparisListe)Session["Siparis"]).FiyatTipi;

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("ResimID"))
                    {
                        ResimID = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                    else if (ctrl.ID.StartsWith("UrunID"))
                    {
                        UrunID = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }
            int TedarikciResimID = TedarikciResim.GetResimID(UrunID);

            txtUrunAyrintiMiktar.Text = string.Empty;
            btnUrunAyrintiSiparisVer.CommandArgument = UrunID.ToString();

            UrunResim.GetObjects(rblResimler.Items, UrunID);
            if (rblResimler.Items.Count > 0)
            {
                lblResimlerBaslik.Visible = true;
                rblResimler.SelectedIndex = 0;
            }
            else
            {
                lblResimlerBaslik.Visible = false;
            }

            ucUrunAyrinti1.ResimAc(ResimID, TedarikciResimID);
            divUrunAyrinti.Visible = true;

            lblUrunAyrintiID.Text = UrunID.ToString();
            lblUrunAyrintiAd.Text = Urunler.GetProductName(UrunID);
            lblUrunAyrintiBarkod.Text = "(" + Urunler.GetProductBarkod(UrunID) + ")";
            double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi);
            lblUrunAyrintiBrut.Text = fiyatiskonto[4].ToString("C3");
            lblUrunAyrintiIsk1.Text = fiyatiskonto[0].ToString("N1");
            lblUrunAyrintiIsk2.Text = fiyatiskonto[1].ToString("N1");
            lblUrunAyrintiIsk3.Text = fiyatiskonto[2].ToString("N1");
            lblUrunAyrintiIsk4.Text = fiyatiskonto[3].ToString("N1");
            lblUrunAyrintiIsk5.Text = fiyatiskonto[5].ToString("N1");
            lblUrunAyrintiIsk6.Text = fiyatiskonto[6].ToString("N1");
            lblUrunAyrintiIsk7.Text = fiyatiskonto[7].ToString("N1");
            lblUrunAyrintiIsk8.Text = fiyatiskonto[8].ToString("N1");
            lblUrunAyrintiIsk9.Text = fiyatiskonto[9].ToString("N1");
            lblUrunAyrintiIsk10.Text = fiyatiskonto[10].ToString("N1");
            lblUrunAyrintiKDV.Text = Urunler.GetProductKDV(UrunID).ToString();
            lblUrunAyrintiVade.Text = Urunler.GetProductVade(UrunID, FiyatTipi).ToString();
            lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)).ToString("C3");
            lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)) *
                (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

            lblUrunAyrintiTedarikciIlgili.Text = Urunler.GetProductTedarikciIlgili(UrunID);
            lblUrunAyrintiTedarikciIlgili.Text = lblUrunAyrintiTedarikciIlgili.Text == string.Empty ? string.Empty : "" + lblUrunAyrintiTedarikciIlgili.Text;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

            txtUrunAyrintiMiktar.Focus();
        }

        protected void ibUrunAyrinti_Click(object sender, ImageClickEventArgs e)
        {
            int ResimID = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            int UrunID = Convert.ToInt32(((ImageButton)sender).CommandName);
            int FiyatTipi = ((SiparisListe)Session["Siparis"]).FiyatTipi;
            int TedarikciResimID = TedarikciResim.GetResimID(UrunID);

            txtUrunAyrintiMiktar.Text = string.Empty;
            btnUrunAyrintiSiparisVer.CommandArgument = UrunID.ToString();

            UrunResim.GetObjects(rblResimler.Items, UrunID);
            if (rblResimler.Items.Count > 0)
            {
                lblResimlerBaslik.Visible = true;
                rblResimler.SelectedIndex = 0;
            }
            else
            {
                lblResimlerBaslik.Visible = false;
            }

            ucUrunAyrinti1.ResimAc(ResimID, TedarikciResimID);
            divUrunAyrinti.Visible = true;

            lblUrunAyrintiID.Text = UrunID.ToString();
            lblUrunAyrintiAd.Text = Urunler.GetProductName(UrunID);
            lblUrunAyrintiBarkod.Text = "(" + Urunler.GetProductBarkod(UrunID) + ")";
            double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi);
            lblUrunAyrintiBrut.Text = fiyatiskonto[4].ToString("C3");
            lblUrunAyrintiIsk1.Text = fiyatiskonto[0].ToString("N1");
            lblUrunAyrintiIsk2.Text = fiyatiskonto[1].ToString("N1");
            lblUrunAyrintiIsk3.Text = fiyatiskonto[2].ToString("N1");
            lblUrunAyrintiIsk4.Text = fiyatiskonto[3].ToString("N1");
            lblUrunAyrintiIsk5.Text = fiyatiskonto[5].ToString("N1");
            lblUrunAyrintiIsk6.Text = fiyatiskonto[6].ToString("N1");
            lblUrunAyrintiIsk7.Text = fiyatiskonto[7].ToString("N1");
            lblUrunAyrintiIsk8.Text = fiyatiskonto[8].ToString("N1");
            lblUrunAyrintiIsk9.Text = fiyatiskonto[9].ToString("N1");
            lblUrunAyrintiIsk10.Text = fiyatiskonto[10].ToString("N1");
            lblUrunAyrintiKDV.Text = Urunler.GetProductKDV(UrunID).ToString();
            lblUrunAyrintiVade.Text = Urunler.GetProductVade(UrunID, FiyatTipi).ToString();
            lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)).ToString("C3");
            lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)) *
                (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

            lblUrunAyrintiTedarikciIlgili.Text = Urunler.GetProductTedarikciIlgili(UrunID);
            lblUrunAyrintiTedarikciIlgili.Text = lblUrunAyrintiTedarikciIlgili.Text == string.Empty ? string.Empty : "" + lblUrunAyrintiTedarikciIlgili.Text;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

            txtUrunAyrintiMiktar.Focus();
        }

        protected void lbUrunAyrintiKapat_Click(object sender, EventArgs e)
        {
            btnUrunAyrintiSiparisVer.CommandArgument = string.Empty;
            divUrunAyrinti.Visible = false;
        }

        protected void btnUrunAyrintiSiparisVer_Click(object sender, EventArgs e)
        {
            if (txtUrunAyrintiMiktar.Text.Trim() != string.Empty)
            {
                ((SiparisListe)Session["Siparis"]).Add(
                    Convert.ToInt32(btnUrunAyrintiSiparisVer.CommandArgument),
                    Convert.ToInt32(txtUrunAyrintiMiktar.Text.Trim()),
                    Urunler.GetProductPrice(Convert.ToInt32(btnUrunAyrintiSiparisVer.CommandArgument), ((SiparisListe)Session["Siparis"]).FiyatTipi),
                    Guid.Empty,
                    false,
                    Guid.Empty,
                    false);

                ((SiparisListe)Session["Siparis"]).ToplamTutarGuncelle(true);
                SepetBilgisiGuncelle();
                btnUrunAyrintiSiparisVer.CommandArgument = string.Empty;
                divUrunAyrinti.Visible = false;
            }
        }

        protected void btnUrunAyrintiOnceki_Click(object sender, EventArgs e)
        {
            int UrunID = 0;
            int ResimID = 0;
            int FiyatTipi = ((SiparisListe)Session["Siparis"]).FiyatTipi;

            DataTable dt = GetProducts(rbBaslangicaGore.Checked);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["UrunID"].ToString() == lblUrunAyrintiID.Text)
                {
                    if (i - 1 > -1)
                    {
                        UrunID = Convert.ToInt32(dt.Rows[i - 1]["UrunID"]);
                        ResimID = Convert.ToInt32(dt.Rows[i - 1]["pkResimID"]);
                    }
                }
            }
            int TedarikciResimID = TedarikciResim.GetResimID(UrunID);

            if (UrunID > 0)
            {
                txtUrunAyrintiMiktar.Text = string.Empty;
                btnUrunAyrintiSiparisVer.CommandArgument = UrunID.ToString();

                UrunResim.GetObjects(rblResimler.Items, UrunID);
                if (rblResimler.Items.Count > 0)
                {
                    lblResimlerBaslik.Visible = true;
                    rblResimler.SelectedIndex = 0;
                }
                else
                {
                    lblResimlerBaslik.Visible = false;
                }

                ucUrunAyrinti1.ResimAc(ResimID, TedarikciResimID);

                lblUrunAyrintiID.Text = UrunID.ToString();
                lblUrunAyrintiAd.Text = Urunler.GetProductName(UrunID);
                lblUrunAyrintiBarkod.Text = "(" + Urunler.GetProductBarkod(UrunID) + ")";
                double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi);
                lblUrunAyrintiBrut.Text = fiyatiskonto[4].ToString("C3");
                lblUrunAyrintiIsk1.Text = fiyatiskonto[0].ToString("N1");
                lblUrunAyrintiIsk2.Text = fiyatiskonto[1].ToString("N1");
                lblUrunAyrintiIsk3.Text = fiyatiskonto[2].ToString("N1");
                lblUrunAyrintiIsk4.Text = fiyatiskonto[3].ToString("N1");
                lblUrunAyrintiIsk5.Text = fiyatiskonto[5].ToString("N1");
                lblUrunAyrintiIsk6.Text = fiyatiskonto[6].ToString("N1");
                lblUrunAyrintiIsk7.Text = fiyatiskonto[7].ToString("N1");
                lblUrunAyrintiIsk8.Text = fiyatiskonto[8].ToString("N1");
                lblUrunAyrintiIsk9.Text = fiyatiskonto[9].ToString("N1");
                lblUrunAyrintiIsk10.Text = fiyatiskonto[10].ToString("N1");
                lblUrunAyrintiKDV.Text = Urunler.GetProductKDV(UrunID).ToString();
                lblUrunAyrintiVade.Text = Urunler.GetProductVade(UrunID, FiyatTipi).ToString();
                lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)).ToString("C3");
                lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)) *
                    (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

                txtUrunAyrintiMiktar.Focus();
            }
        }

        protected void btnUrunAyrintiSonraki_Click(object sender, EventArgs e)
        {
            int UrunID = 0;
            int ResimID = 0;
            int FiyatTipi = ((SiparisListe)Session["Siparis"]).FiyatTipi;

            DataTable dt = GetProducts(rbBaslangicaGore.Checked);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["UrunID"].ToString() == lblUrunAyrintiID.Text)
                {
                    if (i + 1 < dt.Rows.Count)
                    {
                        UrunID = Convert.ToInt32(dt.Rows[i + 1]["UrunID"]);
                        ResimID = Convert.ToInt32(dt.Rows[i + 1]["pkResimID"]);
                    }
                }
            }
            int TedarikciResimID = TedarikciResim.GetResimID(UrunID);

            if (UrunID > 0)
            {
                txtUrunAyrintiMiktar.Text = string.Empty;
                btnUrunAyrintiSiparisVer.CommandArgument = UrunID.ToString();

                UrunResim.GetObjects(rblResimler.Items, UrunID);
                if (rblResimler.Items.Count > 0)
                {
                    lblResimlerBaslik.Visible = true;
                    rblResimler.SelectedIndex = 0;
                }
                else
                {
                    lblResimlerBaslik.Visible = false;
                }

                ucUrunAyrinti1.ResimAc(ResimID, TedarikciResimID);

                lblUrunAyrintiID.Text = UrunID.ToString();
                lblUrunAyrintiAd.Text = Urunler.GetProductName(UrunID);
                lblUrunAyrintiBarkod.Text = "(" + Urunler.GetProductBarkod(UrunID) + ")";
                double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi);
                lblUrunAyrintiBrut.Text = fiyatiskonto[4].ToString("C3");
                lblUrunAyrintiIsk1.Text = fiyatiskonto[0].ToString("N1");
                lblUrunAyrintiIsk2.Text = fiyatiskonto[1].ToString("N1");
                lblUrunAyrintiIsk3.Text = fiyatiskonto[2].ToString("N1");
                lblUrunAyrintiIsk4.Text = fiyatiskonto[3].ToString("N1");
                lblUrunAyrintiIsk5.Text = fiyatiskonto[5].ToString("N1");
                lblUrunAyrintiIsk6.Text = fiyatiskonto[6].ToString("N1");
                lblUrunAyrintiIsk7.Text = fiyatiskonto[7].ToString("N1");
                lblUrunAyrintiIsk8.Text = fiyatiskonto[8].ToString("N1");
                lblUrunAyrintiIsk9.Text = fiyatiskonto[9].ToString("N1");
                lblUrunAyrintiIsk10.Text = fiyatiskonto[10].ToString("N1");
                lblUrunAyrintiKDV.Text = Urunler.GetProductKDV(UrunID).ToString();
                lblUrunAyrintiVade.Text = Urunler.GetProductVade(UrunID, FiyatTipi).ToString();
                lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)).ToString("C3");
                lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi)) *
                    (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

                txtUrunAyrintiMiktar.Focus();
            }
        }

        protected void ibYeniUrunler_Click(object sender, ImageClickEventArgs e)
        {
            cbYeniUrunler.Checked = !cbYeniUrunler.Checked;
            if (cbYeniUrunler.Checked)
                Session["Start"] = 0;
            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }

        protected void cbYeniUrunler_CheckedChanged(object sender, EventArgs e)
        {
            if (cbYeniUrunler.Checked)
                Session["Start"] = 0;
            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }

        protected void rblResimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucUrunAyrinti1.ResimAc(Convert.ToInt32(rblResimler.SelectedValue));
        }

        protected void btnSiparisKalemFazlaKapat_Click(object sender, EventArgs e)
        {
            divSiparisKalemFazla.Visible = false;
        }

        protected void lbSatistaOnAdimKapat_Click(object sender, EventArgs e)
        {
            divSatistaOnAdim.Visible = false;
        }
    }
}