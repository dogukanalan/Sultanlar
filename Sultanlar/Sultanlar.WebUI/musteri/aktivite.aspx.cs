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

namespace Sultanlar.WebUI.musteri
{
    public partial class aktivite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);



            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 6 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 2 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 4) // bayi yöneticisi değil ise ve yönetici değil ise ve satıcı değil ise
                    Response.Redirect("yetkiyok.aspx", true);

                if (Session["AktiviteID"] == null)
                    Response.Redirect("default.aspx", true);

                divDonem.Visible = true;

                if (Convert.ToInt32(Session["AktiviteID"]) == 0) // yeni aktivite ise
                {
                    AktiviteListe list = new AktiviteListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREFakt"]),
                        Convert.ToInt16(Session["FiyatTipi"]), 1, true);

                    if(Session["flAktiviteKarZararYuzde"] != null)
                    {
                        list._AktiviteKarZararYuzde = Convert.ToDouble(Session["flAktiviteKarZararYuzde"]);
                        Session["flAktiviteKarZararYuzde"] = null;
                    }

                    Session["Aktivite"] = list;

                    inputDonemYil.Value = DateTime.Now.Year.ToString();
                    inputDonemAy.Value = DateTime.Now.Month.ToString();
                    AciklamalariGuncelle();
                }
                else if (Convert.ToInt32(Session["AktiviteID"]) == 1) // yeni sul aktivite ise
                {
                    int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Session["SMREFakt"]));
                    short FiyatTipi = GMREF != 0 ? FiyatTipleri.GetFiyatTipByGMREF(CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Session["SMREFakt"]))) : (short)0;

                    if (FiyatTipi > 0)
                    {
                        AktiviteListe list = new AktiviteListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREFakt"]),
                            FiyatTipi, 2, true);
                        Session["Aktivite"] = list;
                    }
                    else
                    {
                        AktiviteListe list = new AktiviteListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREFakt"]),
                            Convert.ToInt16(Session["FiyatTipi"]), 2, true);
                        Session["Aktivite"] = list;
                    }

                    inputDonemYil.Value = DateTime.Now.Year.ToString();
                    inputDonemAy.Value = DateTime.Now.Month.ToString();
                    AciklamalariGuncelle();
                }
                else                                                               // kaydedilmiş aktivite değiştiriliyor ise
                {
                    divDonem.Visible = false;

                    GetSiparisFromDB();
                }


                if (((AktiviteListe)Session["Aktivite"])._AnlasmaID > 0)
                {
                    inputAnlasmaBaslangic.Value = Anlasmalar.GetObject(((AktiviteListe)Session["Aktivite"])._AnlasmaID).dtBaslangic.ToShortDateString();
                    inputAnlasmaBitis.Value = Anlasmalar.GetObject(((AktiviteListe)Session["Aktivite"])._AnlasmaID).dtBitis.ToShortDateString();
                    inputTAHSabitBedel.Value = ((AktiviteListe)Session["Aktivite"])._TahSabitBedel.ToString("C2");
                    inputYEGSabitBedel.Value = ((AktiviteListe)Session["Aktivite"])._YegSabitBedel.ToString("C2");
                    inputTAHHedefCiro.Value = ((AktiviteListe)Session["Aktivite"])._TahHedefCiro.ToString("C2");
                    inputYEGHedefCiro.Value = ((AktiviteListe)Session["Aktivite"])._YegHedefCiro.ToString("C2");
                }
                //else
                //{
                //    inputAnlasmaBaslangic.Value = "-";
                //    inputAnlasmaBitis.Value = "-";
                //    inputTAHSabitBedel.Value = 0.ToString("C2");
                //    inputYEGSabitBedel.Value = 0.ToString("C2");
                //    inputTAHHedefCiro.Value = 0.ToString("C2");
                //    inputYEGHedefCiro.Value = 0.ToString("C2");
                //}


                Session["AktiviteYetkiler"] = Session["Yetkiler"];


                Session["SepetUrunSecimleri"] = new ArrayList();
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

                GetUstBilgiler();

                if (Convert.ToInt32(Session["AktiviteID"]) > 1)
                {
                    Session["MaxRecordCount"] = GetProductsCount();
                    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                }

                Session["AktiviteID"] = null;
                Session["SMREFakt"] = null;

                if (((AktiviteListe)Session["Aktivite"]).Items.Count > 0)
                    ibSepetBuyut.ImageUrl = "img/sepet-dolu.png";

                Session["FiyatTipi"] = null;

                ddlDonemAy.SelectedIndex = DateTime.Now.Month - 1;
            }
            else
            {
                AciklamalariGuncelle();
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(DivAjax, typeof(string), "kucukbilgi", alert, false);
        }

        #region SepetBilgisiGuncelle
        private void SepetBilgisiGuncelle()
        {
            lblToplamTutar.Text = ((AktiviteListe)Session["Aktivite"]).ToplamTutar.ToString("C3");
            if (((AktiviteListe)Session["Aktivite"]).Items.Count > 0)
                ibSepetBuyut.ImageUrl = "img/sepet-dolu.png";
            else
                ibSepetBuyut.ImageUrl = "img/sepet.png";
        }
        #endregion

        #region GetUstBilgiler
        private void GetUstBilgiler()
        {
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (((AktiviteListe)Session["Aktivite"])._AktiviteTipiID == 1)
            {
                lblBayi.Text = CariHesaplarTP.GetObject(CariHesaplarTP.GetObject(Convert.ToInt32(Session["SMREFakt"]), false).GMREF, true).MUSTERI;
                lblCariHesap.Text = CariHesaplarTP.GetObjectBySMREF(Convert.ToInt32(Session["SMREFakt"]))[1].ToString();
            }
            else if (((AktiviteListe)Session["Aktivite"])._AktiviteTipiID == 2)
            {
                //if (((AktiviteListe)Session["Aktivite"])._FiyatTipi == 25 && (CariHesaplarTP.GetObject(Convert.ToInt32(Session["SMREFakt"]), true).GMREF == 1005405 || CariHesaplarTP.GetObject(Convert.ToInt32(Session["SMREFakt"]), true).GMREF == 1000951)) // öztrakya veya meltem ise
                //{
                //    lblBayi.Text = CariHesaplarTP.GetObject(CariHesaplarTP.GetObject(Convert.ToInt32(Session["SMREFakt"]), false).GMREF, true).MUSTERI;
                //    lblCariHesap.Text = CariHesaplarTP.GetObjectBySMREF(Convert.ToInt32(Session["SMREFakt"]))[1].ToString();
                //}
                //else
                //{
                    lblBayi.Text = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(Session["SMREFakt"]));
                    lblCariHesap.Text = string.Empty;
                //}
            }

            lblAktiviteID.Text = ((AktiviteListe)Session["Aktivite"])._AktiviteID.ToString();

            //for (int i = 0; i < ((UyeYetkileri)Session["AktiviteYetkiler"]).FiyatTipler.Count; i++)
            //{
            //    short fiyattipiid = Convert.ToInt16(((UyeYetkileri)Session["AktiviteYetkiler"]).FiyatTipler[i]);
            //    ddlFiyatTipleri.Items.Add(FiyatTipleri.GetObjectByID(fiyattipiid));
            //    ddlFiyatTipleri.Items[i].Value = fiyattipiid.ToString();
            //}
            //ddlFiyatTipleri.SelectedValue = ((AktiviteListe)Session["Aktivite"])._FiyatTipi.ToString();
        }
        #endregion

        #region GetSiparisFromDB, GetSiparisSepeti, SepetUrunSecimEsitlemesi
        private void GetSiparisFromDB()
        {
            int AktiviteTipi = Convert.ToInt32(Session["AktiviteTipi"]);
            Session["AktiviteTipi"] = null;
            AktiviteListe aktlist = new AktiviteListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREFakt"]),
                Convert.ToInt16(Session["FiyatTipi"]), AktiviteTipi, false);
            Session["AktiviteYetkiler"] = Session["Yetkiler"];

            DataTable dt = new DataTable();
            Aktiviteler akt = Aktiviteler.GetObject(Convert.ToInt32(Session["AktiviteID"]));
            AktivitelerDetay.GetObjectsByAktiviteID(dt, Convert.ToInt32(Session["AktiviteID"]));

            aktlist._AktiviteID = Convert.ToInt32(Session["AktiviteID"]);

            int yil = akt.strAciklama4 != string.Empty ? Convert.ToInt32(akt.strAciklama4.Split(new char[] { '/' }, StringSplitOptions.None)[0]) : DateTime.Now.Year;
            int ay = akt.strAciklama4 != string.Empty ? Convert.ToInt32(akt.strAciklama4.Split(new char[] { '/' }, StringSplitOptions.None)[1]) : DateTime.Now.Month;

            aktlist._DonemYil = yil;
            aktlist._DonemAy = ay;
            inputDonemYil.Value = yil.ToString();
            inputDonemAy.Value = ay.ToString();



            if (akt.intAnlasmaID != 0)
            {
                Anlasmalar anlasma = Anlasmalar.GetObject(akt.intAnlasmaID);
                inputAnlasmaBaslangic.Value = anlasma.dtBaslangic.ToShortDateString();
                inputAnlasmaBitis.Value = anlasma.dtBitis.ToShortDateString();
                inputTAHSabitBedel.Value = akt.mnTahSabitBedel.ToString("C2");
                inputYEGSabitBedel.Value = akt.mnYegSabitBedel.ToString("C2");
                inputTAHHedefCiro.Value = akt.mnTahHedefCiro.ToString("C2");
                inputYEGHedefCiro.Value = akt.mnYegHedefCiro.ToString("C2");
            }



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long aktivitedetayid = Convert.ToInt64(dt.Rows[i]["pkID"]);
                aktlist.Add(aktivitedetayid);
            }

            aktlist.ToplamTutarGuncelle();



            Session["Aktivite"] = aktlist;
            SepetBilgisiGuncelle();

            txtSiparisAciklama1.Text = akt.strAciklama1;
            txtSiparisAciklama2.Text = akt.strAciklama2;
            txtSiparisAciklama3.Text = akt.strAciklama3;
            //txtSiparisAciklama4.Text = akt.strAciklama4;

            datepicker1.Value = akt.dtAktiviteBaslangic.ToShortDateString();
            datepicker2.Value = akt.dtAktiviteBitis.ToShortDateString();
        }
        public void GetSiparisSepeti()
        {
            lblSepetToplam.Text = ((AktiviteListe)Session["Aktivite"]).ToplamTutar.ToString("C3");

            Repeater1.DataSource = (AktiviteListe)Session["Aktivite"];
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

                    foreach (Control ctrl in Repeater1.Controls)
                    {
                        long siparisdetayid = 0;
                        CheckBox chk = new CheckBox();

                        foreach (Control ctrl2 in ctrl.Controls)
                        {
                            if (ctrl2 is CheckBox)
                            {
                                chk = (CheckBox)ctrl2;
                            }
                            else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("AktiviteDetayID"))
                            {
                                siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                            }
                        }

                        if (ICERIKsiparisdetayid == siparisdetayid)
                            chk.Checked = true;
                    }
                }
            }
        }
        #endregion

        #region AciklamalariGuncelle
        private void AciklamalariGuncelle()
        {
            if (Session["Aktivite"] != null) // session kendiliğinden sonlanırsa da bu ekrandan bir link tıklanırsa, postback de hataya düşmemesi için
            {
                if (datepicker1.Value != string.Empty)
                    ((AktiviteListe)Session["Aktivite"])._AktiviteBaslangic = Convert.ToDateTime(datepicker1.Value);
                if (datepicker2.Value != string.Empty)
                    ((AktiviteListe)Session["Aktivite"])._AktiviteBitis = Convert.ToDateTime(datepicker2.Value);

                ((AktiviteListe)Session["Aktivite"])._Aciklama1 = txtSiparisAciklama1.Text.Trim();
                ((AktiviteListe)Session["Aktivite"])._Aciklama2 = txtSiparisAciklama2.Text.Trim();
                ((AktiviteListe)Session["Aktivite"])._Aciklama3 = txtSiparisAciklama3.Text.Trim();
                ((AktiviteListe)Session["Aktivite"])._Aciklama4 = inputDonemYil.Value + "/" + inputDonemAy.Value;
                ((AktiviteListe)Session["Aktivite"]).AciklamaGuncelle(datepicker1.Value != string.Empty && datepicker2.Value != string.Empty);
            }
        }
        #endregion

        #region GetProducts
        private void GetProducts(bool resimli, bool aramabaslangicagore)
        {
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
                string fiyattipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi.ToString(); // bayi öztrakya veya meltem ise ::: CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"])._SMREF, true).GMREF == 1005405 || CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"])._SMREF, true).GMREF == 1000951 ? "7" : 

                DataTable dt = new DataTable();
                Urunler.GetProducts(dt, (int)Session["Start"], (int)Session["Count"], fiyattipi,
                    tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                    new ArrayList(), ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, false, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));

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

            string fiyattipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi.ToString(); // bayi öztrakya veya meltem ise ::: CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"])._SMREF, true).GMREF == 1005405 || CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"])._SMREF, true).GMREF == 1000951 ? "7" : 

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, 0, (int)Session["MaxRecordCount"], fiyattipi,
                tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, false, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
            return dt;
        }
        #endregion

        #region GetProductsCount
        private int GetProductsCount()
        {
            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5 && !false) // perakende müşteri ise yetkili bütün ürünler gelsin
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

            string fiyattipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi.ToString(); // bayi öztrakya veya meltem ise ::: CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"])._SMREF, true).GMREF == 1005405 || CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"])._SMREF, true).GMREF == 1000951 ? "7" : 

            return Urunler.GetProductsCount(fiyattipi, tedarikcioperator,
                    Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(),
                    ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, false, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
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
                if (((AktiviteListe)Session["Aktivite"]).Items.Count >= 100)
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
                    if (dl.Controls[i].Controls[j] is System.Web.UI.HtmlControls.HtmlGenericControl) // urunid si ve fiyat
                    {
                        string tekst = ((System.Web.UI.HtmlControls.HtmlGenericControl)dl.Controls[i].Controls[j]).InnerText;

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
                    double[] fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, 7, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                    if (((AktiviteListe)Session["Aktivite"]).FiyatTipi == 25) // altcaridir (web-musteri-tp) yada bayi genel anlaşmasız aktivitedir
                    {
                        //if (CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"]).SMREF, true).GMREF == 1005405 || CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"]).SMREF, true).GMREF == 1000951) // bayi öztrakya veya meltem ise sultanlar gibi
                        //{
                        //    fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, 7, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                        //}
                        //else
                        //{
                            fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, 25, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                        //}
                    }
                    else
                    {
                        fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, ((AktiviteListe)Session["Aktivite"]).FiyatTipi /*7 yi aktivite ftipi yaptım*/ , Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                    }
                    fiyat = Convert.ToDecimal(fiyatisks[4] * ((100 + Urunler.GetProductKDV(urunid)) / 100));             // normal fiyat
                    ((AktiviteListe)Session["Aktivite"]).Add(urunid, miktar, fiyat, false);
                }
            }

            if (miktargirilmis)
                ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

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
            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetKategoriler2(harf, Session["Tedarikci"].ToString(), aramabasi, Session["Aranan"].ToString(), rblKategoriler.Items, ((AktiviteListe)Session["Aktivite"])._FiyatTipi, ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, true);
        }
        private void GetTedarikciler(string harf)
        {
            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetTedarikciler2(harf, Session["Kategori"].ToString(), aramabasi, Session["Aranan"].ToString(), rblTedarikciler.Items, ((AktiviteListe)Session["Aktivite"])._FiyatTipi, ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, true);
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
            Urunler.GetProducts(dt, ((AktiviteListe)Session["Aktivite"]).FiyatTipi.ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar);

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
                                ((TextBox)dlListe.Controls[1].Controls[j]).Text = "1";
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
                                ((TextBox)dlResimli.Controls[0].Controls[j]).Text = "1";
                                break;
                            }
                        }
                    }

                    UrunSecimTarama(true, false);
                    SepetBilgisiGuncelle();
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
            Urunler.GetProducts(dt, ((AktiviteListe)Session["Aktivite"]).FiyatTipi.ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, true);

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
            Urunler.GetProducts(dt, ((AktiviteListe)Session["Aktivite"]).FiyatTipi.ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar, true, true, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));

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
            ((AktiviteListe)Session["Aktivite"]).DeleteSiparislerDetay(true);
        }
        private void SiparisIptal()
        {
            ((AktiviteListe)Session["Aktivite"]).DeleteSiparisSiparislerDetayFromDB();
            Session["AktiviteID"] = null;
            Session["Aktivite"] = null;
            GC.Collect();
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

            Urunler.GetTedarikciHangiHarfler(dt, ((AktiviteListe)Session["Aktivite"]).FiyatTipi, /*Session["Tedarikci"].ToString(),
                tedarikcioperator, */Session["Kategori"].ToString(), kategorioperator, aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar);

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

            Urunler.GetKategoriHangiHarfler(dt, ((AktiviteListe)Session["Aktivite"]).FiyatTipi, Session["Tedarikci"].ToString(),
                tedarikcioperator, /*Session["Kategori"].ToString(), kategorioperator, */aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar);

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
        protected void cbBarkodHemenEkle_CheckedChanged(object sender, EventArgs e)
        {
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

            if (rbMalzemeler.Checked)
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);

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
                //for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
                //{
                //    if (ddlFiyatTipleri.Items[i].Value == ((AktiviteListe)Session["Aktivite"])._FiyatTipi.ToString())
                //    {
                //        ddlFiyatTipleri.SelectedIndex = i;
                //        i = ddlFiyatTipleri.Items.Count;
                //    }
                //}
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
                long siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("AktiviteDetayID")).Value);

                ArrayList al = new ArrayList();
                al.Add(siparisdetayid);

                Session["SiparisSepettenSil"] = al;

                SiparisSepettenUrunSil();
            }
            else if (e.CommandName == "Guncelle")
            {
                long siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("AktiviteDetayID")).Value);
                int yenimiktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("SatisHedefi")).Value);
                decimal fiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("AksiyonFiyati")).Value);
                double isk = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("EkIsk")).Value);
                double iskfiyat = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("EkIskFiyat")).Value);
                double birimfiyat = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("BirimFiyatKDVli")).Value);

                if (isk == 0)
                {
                    AktivitelerDetay aktdet = AktivitelerDetay.GetObject(siparisdetayid);
                    double dusulenfiyat = birimfiyat - ((birimfiyat / 100) * Convert.ToDouble(aktdet.strAciklama1));
                    double dusulenfiyat1 = dusulenfiyat - ((dusulenfiyat / 100) * Convert.ToDouble(aktdet.strAciklama2));
                    double dusulenfiyat2 = dusulenfiyat1 - ((dusulenfiyat1 / 100) * Convert.ToDouble(aktdet.strAciklama3));
                    isk = (1 - (iskfiyat / dusulenfiyat2)) * 100;
                }

                if (yenimiktar > 0)
                    ((AktiviteListe)Session["Aktivite"]).Update(siparisdetayid, yenimiktar, fiyat, isk);
                ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

                GetSiparisSepeti();
            }
            else if (e.CommandName == "Arttir")
            {
                long siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("AktiviteDetayID")).Value);
                int miktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("SatisHedefi")).Value);
                decimal fiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("AksiyonFiyati")).Value);
                double isk = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("EkIsk")).Value);

                ((AktiviteListe)Session["Aktivite"]).Update(siparisdetayid, miktar + 1, fiyat, isk);
                ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

                GetSiparisSepeti();
            }
            else if (e.CommandName == "Azalt")
            {
                long siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("AktiviteDetayID")).Value);
                int miktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("SatisHedefi")).Value);
                decimal fiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("AksiyonFiyati")).Value);
                double isk = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("EkIsk")).Value);
                
                if (miktar > 1)
                    ((AktiviteListe)Session["Aktivite"]).Update(siparisdetayid, miktar - 1, fiyat, isk);
                ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

                GetSiparisSepeti();
            }
        }
        private void SiparisSepettenUrunSil()
        {
            ArrayList al = (ArrayList)Session["SiparisSepettenSil"];

            long siparisdetayid = (long)al[0];

            ((AktiviteListe)Session["Aktivite"]).Remove(siparisdetayid);
            ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

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
        }
        protected void btnSiparisiTamamla_Click(object sender, EventArgs e)
        {
            Session["AktiviteTamamlaBasildi"] = ((AktiviteListe)Session["Aktivite"])._SMREF;
            Response.Redirect("aktiviteler.aspx");
        }
        protected void btnSiparisiTamamlaOnayla_Click(object sender, EventArgs e)
        {
            Session["AktiviteTamamlaOnaylaBasildi"] = ((AktiviteListe)Session["Aktivite"])._AktiviteID;
            Session["OnaylanacakAktiviteID"] = ((AktiviteListe)Session["Aktivite"])._AktiviteID;
            Response.Redirect("aktiviteler.aspx");
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

                ((AktiviteListe)Session["Aktivite"]).Remove(siparisdetayid);
                ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

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
                ArrayList icerik = new ArrayList();

                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is CheckBox)
                    {
                        ((CheckBox)ctrl2).Checked = ((CheckBox)sender).Checked;
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("AktiviteDetayID"))
                    {
                        siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                }

                if (siparisdetayid != 0)
                {
                    icerik.Add(siparisdetayid);

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

                            if (ID == siparisdetayid)
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
            ArrayList icerik = new ArrayList();

            foreach (Control ctrl in ((CheckBox)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("AktiviteDetayID"))
                    {
                        siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }

            if (siparisdetayid != 0)
            {
                icerik.Add(siparisdetayid);

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

                        if (ID == siparisdetayid)
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
            foreach (Control ctrl in Repeater1.Controls)
            {
                long siparisdetayid = 0;
                int yenimiktar = 0;
                decimal fiyat = 0;
                double isk = 0;
                double iskfiyat = 0;
                double birimfiyat = 0;

                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("AktiviteDetayID"))
                    {
                        siparisdetayid = Convert.ToInt64(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("SatisHedefi"))
                    {
                        yenimiktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("AksiyonFiyati"))
                    {
                        fiyat = Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("EkIskFiyat"))
                    {
                        iskfiyat = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputText && ctrl2.ID.StartsWith("EkIsk"))
                    {
                        isk = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputText)ctrl2).Value);
                    }
                    else if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("BirimFiyatKDVli"))
                    {
                        birimfiyat = Convert.ToDouble(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                    }
                }

                if (isk == 0 && siparisdetayid > 0)
                {
                    AktivitelerDetay aktdet = AktivitelerDetay.GetObject(siparisdetayid);
                    double dusulenfiyat = birimfiyat - ((birimfiyat / 100) * Convert.ToDouble(aktdet.strAciklama1));
                    double dusulenfiyat1 = dusulenfiyat - ((dusulenfiyat / 100) * Convert.ToDouble(aktdet.strAciklama2));
                    double dusulenfiyat2 = dusulenfiyat1 - ((dusulenfiyat1 / 100) * Convert.ToDouble(aktdet.strAciklama3));
                    isk = (1 - (iskfiyat / dusulenfiyat2)) * 100;
                }

                ((AktiviteListe)Session["Aktivite"]).Update(siparisdetayid, yenimiktar, fiyat, isk);
            }

            ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();
            GetSiparisSepeti();
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
            //if (ddlFiyatTipleri.SelectedValue == ((AktiviteListe)Session["Aktivite"])._FiyatTipi.ToString())
            //    return;

            Session["OncekiFiyatTipi"] = ((AktiviteListe)Session["Aktivite"])._FiyatTipi;
        }
        protected void btnFiyatTipiDegismeDevam_Click(object sender, EventArgs e)
        {
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
                SepetBilgisiGuncelle();
            }
        }
        protected void btnFiyatTipiDegismeDur_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
            //{
            //    if (ddlFiyatTipleri.Items[i].Value == Session["OncekiFiyatTipi"].ToString())
            //    {
            //        Session["OncekiFiyatTipi"] = null;
            //        ddlFiyatTipleri.SelectedIndex = i;
            //        break;
            //    }
            //}
        }
        #endregion

        protected void lbUrunFiyatiDegisti_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void lbSayfayaGit_Click(object sender, EventArgs e)
        {
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
            int FiyatTipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi;

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
            double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
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
            lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)).ToString("C3");
            lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)) *
                (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

            txtUrunAyrintiMiktar.Focus();
        }

        protected void ibUrunAyrinti_Click(object sender, ImageClickEventArgs e)
        {
            int ResimID = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            int UrunID = Convert.ToInt32(((ImageButton)sender).CommandName);
            int FiyatTipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi;
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
            double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
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
            lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)).ToString("C3");
            lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)) *
                (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

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
                int urunid = Convert.ToInt32(btnUrunAyrintiSiparisVer.CommandArgument);
                double[] fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, 7, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                if (((AktiviteListe)Session["Aktivite"]).FiyatTipi == 25) // altcaridir (web-musteri-tp) yada bayi genel anlaşmasız aktivitedir
                {
                    //if (CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"]).SMREF, true).GMREF == 1005405 || CariHesaplarTP.GetObject(((AktiviteListe)Session["Aktivite"]).SMREF, true).GMREF == 1000951) // bayi öztrakya veya meltem ise sultanlar gibi
                    //{
                    //    fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, 7, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                    //}
                    //else
                    //{
                    fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, 25, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                    //}
                }
                else
                {
                    fiyatisks = Urunler.GetProductDiscountsAndPrice(urunid, ((AktiviteListe)Session["Aktivite"]).FiyatTipi /*7 yi aktivite ftipi yaptım*/ , Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
                }
                decimal fiyat = Convert.ToDecimal(fiyatisks[4] * ((100 + Urunler.GetProductKDV(Convert.ToInt32(btnUrunAyrintiSiparisVer.CommandArgument))) / 100));
                ((AktiviteListe)Session["Aktivite"]).Add(
                    urunid,
                    Convert.ToInt32(txtUrunAyrintiMiktar.Text.Trim()),
                    fiyat, 
                    false);

                ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();
                SepetBilgisiGuncelle();
                btnUrunAyrintiSiparisVer.CommandArgument = string.Empty;
                divUrunAyrinti.Visible = false;
            }
        }

        protected void btnUrunAyrintiOnceki_Click(object sender, EventArgs e)
        {
            int UrunID = 0;
            int ResimID = 0;
            int FiyatTipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi;

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
                double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
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
                lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)).ToString("C3");
                lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)) *
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
            int FiyatTipi = ((AktiviteListe)Session["Aktivite"]).FiyatTipi;

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
                double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, FiyatTipi, Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value));
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
                lblUrunAyrintiFiyat.Text = Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)).ToString("C3");
                lblUrunAyrintiOnerilenFiyat.Text = (Urunler.GetProductPrice(UrunID, Convert.ToInt16(FiyatTipi), Convert.ToInt32(inputDonemYil.Value), Convert.ToInt32(inputDonemAy.Value)) *
                    (Convert.ToDecimal(((Musteriler)Session["Musteri"]).tintOnerilenFiyatYuzde + 100) / 100)).ToString("C3");

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

                txtUrunAyrintiMiktar.Focus();
            }
        }

        protected void rblResimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucUrunAyrinti1.ResimAc(Convert.ToInt32(rblResimler.SelectedValue));
        }

        protected void btnSiparisKalemFazlaKapat_Click(object sender, EventArgs e)
        {
            divSiparisKalemFazla.Visible = false;
        }

        protected void btnOneri_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SatisRapor.GetProductsByGMREF(dt, 0, 100, ((AktiviteListe)Session["Aktivite"])._SMREF, ((AktiviteListe)Session["Aktivite"])._FiyatTipi, ((UyeYetkileri)Session["AktiviteYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["AktiviteYetkiler"]).GrupKodlar);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int urunid = Convert.ToInt32(dt.Rows[i]["ITEMREF"]);
                decimal fiyat = FiyatlarTP.GetFiyat(urunid, ((AktiviteListe)Session["Aktivite"])._FiyatTipi, ((AktiviteListe)Session["Aktivite"])._DonemYil, ((AktiviteListe)Session["Aktivite"])._DonemAy);
                fiyat = fiyat * Convert.ToDecimal(((100 + Urunler.GetProductKDV(urunid)) / 100));
                ((AktiviteListe)Session["Aktivite"]).Add(urunid, 1, fiyat, false);
            }
            ((AktiviteListe)Session["Aktivite"]).ToplamTutarGuncelle();

            divSepet.Visible = true;
            divTedarikciKategoriDis.Visible = true;

            GetSiparisSepeti();
        }

        protected void btnDonemTamam_Click(object sender, EventArgs e)
        {
            divDonem.Visible = false;
            inputDonemYil.Value = ddlDonemYil.SelectedValue;
            inputDonemAy.Value = ddlDonemAy.SelectedValue;

            ((AktiviteListe)Session["Aktivite"])._DonemYil = Convert.ToInt32(inputDonemYil.Value);
            ((AktiviteListe)Session["Aktivite"])._DonemAy = Convert.ToInt32(inputDonemAy.Value);

            foreach (AktiviteDetayi aktdet in ((AktiviteListe)Session["Aktivite"]).Items)
            {
                aktdet._DonemYil = ((AktiviteListe)Session["Aktivite"])._DonemYil;
                aktdet._DonemAy = ((AktiviteListe)Session["Aktivite"])._DonemAy;
            }



            if (((AktiviteListe)Session["Aktivite"])._FiyatTipi != 25) // sul aktivite ise anlaşma seçeneği vereceğiz
            {
                DataTable dt = new DataTable();

                Anlasmalar.GetObjects("2", dt, 
                    CariHesaplar.GetSMREFsByGMREF(CariHesaplar.GetGMREFBySMREF(((AktiviteListe)Session["Aktivite"])._SMREF)), 
                    true,
                    Convert.ToDateTime("01." + ((AktiviteListe)Session["Aktivite"])._DonemAy.ToString() + "." + ((AktiviteListe)Session["Aktivite"])._DonemYil.ToString()),
                    Convert.ToDateTime("01." + ((AktiviteListe)Session["Aktivite"])._DonemAy.ToString() + "." + ((AktiviteListe)Session["Aktivite"])._DonemYil.ToString()),
                    0, 50);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rblAnlasmalar.Items.Add(new ListItem("Anlaşma No: " + dt.Rows[i]["pkID"].ToString() + "<br>Açıklama: " + dt.Rows[i]["strAciklama1"].ToString(), dt.Rows[i]["pkID"].ToString()));
                    }
                }
                else
                {
                    rblAnlasmalar.Items.Add(new ListItem("Anlaşma bulunamadı.", "0"));
                }

                rblAnlasmalar.SelectedIndex = 0;
                divAnlasmaSecim.Visible = true;
            }
            else
            {
                int sonanlasmaid = Anlasmalar.GetSonAnlasmaID(((AktiviteListe)Session["Aktivite"])._SMREF, Convert.ToDateTime("01." + ((AktiviteListe)Session["Aktivite"])._DonemAy.ToString() + "." + ((AktiviteListe)Session["Aktivite"])._DonemYil.ToString()), "1");
                if (sonanlasmaid != 0)
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                    ((AktiviteListe)Session["Aktivite"])._AnlasmaID = anlasma.pkID;
                    ((AktiviteListe)Session["Aktivite"])._TahSabitBedel = anlasma.TAHTumBedellerToplami + anlasma.mnTAHAnlasmaDisiBedeller;
                    ((AktiviteListe)Session["Aktivite"])._YegSabitBedel = anlasma.YEGTumBedellerToplami + anlasma.mnYEGAnlasmaDisiBedeller;
                    ((AktiviteListe)Session["Aktivite"])._TahHedefCiro = anlasma.mnTAHToplamCiro;
                    ((AktiviteListe)Session["Aktivite"])._YegHedefCiro = anlasma.mnYEGToplamCiro;

                    inputAnlasmaBaslangic.Value = anlasma.dtBaslangic.ToShortDateString();
                    inputAnlasmaBitis.Value = anlasma.dtBitis.ToShortDateString();
                    inputTAHSabitBedel.Value = ((AktiviteListe)Session["Aktivite"])._TahSabitBedel.ToString("C2");
                    inputYEGSabitBedel.Value = ((AktiviteListe)Session["Aktivite"])._YegSabitBedel.ToString("C2");
                    inputTAHHedefCiro.Value = ((AktiviteListe)Session["Aktivite"])._TahHedefCiro.ToString("C2");
                    inputYEGHedefCiro.Value = ((AktiviteListe)Session["Aktivite"])._YegHedefCiro.ToString("C2");
                }
                Aktiviteler aktivite = Aktiviteler.GetObject(((AktiviteListe)Session["Aktivite"])._AktiviteID);
                aktivite.intAnlasmaID = ((AktiviteListe)Session["Aktivite"])._AnlasmaID;
                aktivite.mnTahSabitBedel = ((AktiviteListe)Session["Aktivite"])._TahSabitBedel;
                aktivite.mnYegSabitBedel = ((AktiviteListe)Session["Aktivite"])._YegSabitBedel;
                aktivite.mnTahHedefCiro = ((AktiviteListe)Session["Aktivite"])._TahHedefCiro;
                aktivite.mnYegHedefCiro = ((AktiviteListe)Session["Aktivite"])._YegHedefCiro;
                aktivite.DoUpdate();



                Session["MaxRecordCount"] = GetProductsCount();
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }

        protected void btnAnlasmaTamam_Click(object sender, EventArgs e)
        {
            int anlasmaid = rblAnlasmalar.SelectedIndex > -1 ? Convert.ToInt32(rblAnlasmalar.SelectedValue) : 0;
            if (anlasmaid != 0)
            {
                Anlasmalar anlasma = Anlasmalar.GetObject(anlasmaid);
                ((AktiviteListe)Session["Aktivite"])._AnlasmaID = anlasma.pkID;
                ((AktiviteListe)Session["Aktivite"])._TahSabitBedel = anlasma.TAHTumBedellerToplami + anlasma.mnTAHAnlasmaDisiBedeller;
                ((AktiviteListe)Session["Aktivite"])._YegSabitBedel = anlasma.YEGTumBedellerToplami + anlasma.mnYEGAnlasmaDisiBedeller;
                ((AktiviteListe)Session["Aktivite"])._TahHedefCiro = anlasma.mnTAHToplamCiro;
                ((AktiviteListe)Session["Aktivite"])._YegHedefCiro = anlasma.mnYEGToplamCiro;

                inputAnlasmaBaslangic.Value = anlasma.dtBaslangic.ToShortDateString();
                inputAnlasmaBitis.Value = anlasma.dtBitis.ToShortDateString();
                inputTAHSabitBedel.Value = ((AktiviteListe)Session["Aktivite"])._TahSabitBedel.ToString("C2");
                inputYEGSabitBedel.Value = ((AktiviteListe)Session["Aktivite"])._YegSabitBedel.ToString("C2");
                inputTAHHedefCiro.Value = ((AktiviteListe)Session["Aktivite"])._TahHedefCiro.ToString("C2");
                inputYEGHedefCiro.Value = ((AktiviteListe)Session["Aktivite"])._YegHedefCiro.ToString("C2");
            }
            Aktiviteler aktivite = Aktiviteler.GetObject(((AktiviteListe)Session["Aktivite"])._AktiviteID);
            aktivite.intAnlasmaID = ((AktiviteListe)Session["Aktivite"])._AnlasmaID;
            aktivite.mnTahSabitBedel = ((AktiviteListe)Session["Aktivite"])._TahSabitBedel;
            aktivite.mnYegSabitBedel = ((AktiviteListe)Session["Aktivite"])._YegSabitBedel;
            aktivite.mnTahHedefCiro = ((AktiviteListe)Session["Aktivite"])._TahHedefCiro;
            aktivite.mnYegHedefCiro = ((AktiviteListe)Session["Aktivite"])._YegHedefCiro;
            aktivite.DoUpdate();



            Session["MaxRecordCount"] = GetProductsCount();
            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);

            divAnlasmaSecim.Visible = false;
        }
    }
}