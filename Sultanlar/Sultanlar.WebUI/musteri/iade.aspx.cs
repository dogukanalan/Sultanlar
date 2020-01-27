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
    public partial class iade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("default.aspx", true);



            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5) // perakende müşteri değil ise
                {
                    if ((Session["IadeID"] == null && Session["Iade"] == null) || Session["SMREF"] == null || Session["Musteri"] == null || Session["Yetkiler"] == null)
                        Response.Redirect("default.aspx", true);
                }
                else
                {
                    Response.Redirect("yetkiyok.aspx", true);
                }



                if (Convert.ToInt32(Session["IadeID"]) == 0)
                {
                    int smref = Convert.ToInt32(Session["SMREF"]);
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri  ise
                    {
                        smref = 24479; // perakende müşteriler için kredi kartı satış carisi gözükmesi için
                        rbResimDuzeni.Checked = true;
                        rbListeDuzeni.Checked = false;
                    }

                    string aciklama1 = string.Empty;
                    IadeListe ilist;
                    if (Session["IadeSahibiMusteriID"] != null)
                    {
                        ilist = new IadeListe((int)Session["IadeSahibiMusteriID"], smref, true);
                        Session["IadeYetkiler"] = new UyeYetkileri((int)Session["IadeSahibiMusteriID"]);
                        Session["IadeSahibiMusteriID"] = null;

                        Musteriler musteri = Musteriler.GetMusteriByID((int)Session["IadeGirenMusteriID"]);
                        aciklama1 = musteri.strAd + " " + musteri.strSoyad;
                    }
                    else
                    {
                        ilist = new IadeListe(((Musteriler)Session["Musteri"]).pkMusteriID, smref, true);
                        Session["IadeYetkiler"] = Session["Yetkiler"];

                        aciklama1 = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
                    }

                    ilist.AciklamaGuncelle(aciklama1, txtSiparisAciklama2.Text.Trim(), txtSiparisAciklama3.Text.Trim());
                    Session["Iade"] = ilist;

                    IadeHareketleri.DoInsert(ilist._IadeID, 8, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // iade girildi
                }
                else
                {
                    GetSiparisFromDB();
                }
                Session["IadeID"] = null;



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
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
                
                //hlSatistaOnAdim.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;

                if (((IadeListe)Session["Iade"]).Items.Count > 0)
                    ibSepetBuyut.ImageUrl = "img/sepet-dolu.png";
            }
            else
            {
                AciklamalariGuncelle();
                // IadeListe ye yeni alan açmaya üşendiğim için
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(DivAjax, typeof(string), "kucukbilgi", alert, false);
        }

        #region SepetBilgisiGuncelle
        private void SepetBilgisiGuncelle()
        {
            if (((IadeListe)Session["Iade"]).Items.Count > 0)
                ibSepetBuyut.ImageUrl = "img/sepet-dolu.png";
            else
                ibSepetBuyut.ImageUrl = "img/sepet.png";
        }
        #endregion

        #region GetUstBilgiler
        private void GetUstBilgiler()
        {
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5) // perakende müşteri değil ise
            {
                lblCariHesap.Text = CariHesaplar.GetObjectBySMREF(Convert.ToInt32(Session["SMREF"]))[1].ToString() + " : " + CariHesaplar.GetSubeBySMREF(Convert.ToInt32(Session["SMREF"]))[1].ToString();
                if (lblCariHesap.Text.EndsWith(" : "))
                    lblCariHesap.Text = lblCariHesap.Text.Substring(0, lblCariHesap.Text.Length - 3);
            }

            lblSiparisID.Text = ((IadeListe)Session["Iade"])._IadeID.ToString();
        }
        #endregion

        #region GetSiparisFromDB, GetSiparisSepeti
        private void GetSiparisFromDB()
        {
            IadeListe ilist;
            if (Session["IadeSahibiMusteriID"] != null)
            {
                ilist = new IadeListe((int)Session["IadeSahibiMusteriID"], Convert.ToInt32(Session["SMREF"]), false);
                Session["IadeYetkiler"] = new UyeYetkileri((int)Session["IadeSahibiMusteriID"]);
                Session["IadeSahibiMusteriID"] = null;
            }
            else
            {
                ilist = new IadeListe(((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Session["SMREF"]), false);
                Session["IadeYetkiler"] = Session["Yetkiler"];
            }

            DataTable dt = new DataTable();
            Iadeler iade = Iadeler.GetObjectsByIadeID(Convert.ToInt32(Session["IadeID"]));
            IadelerDetay.GetObjectsByIadeID(dt, Convert.ToInt32(Session["IadeID"]));

            ilist._IadeID = Convert.ToInt32(Session["IadeID"]);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long iadedetayid = Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]);
                int urunid = Convert.ToInt32(dt.Rows[i]["intUrunID"]);
                string urunadi = dt.Rows[i]["strUrunAdi"].ToString();
                int miktar = Convert.ToInt32(dt.Rows[i]["intMiktar"]);

                ilist.Add(urunid, urunadi, miktar, 0, iadedetayid);
            }

            Session["Iade"] = ilist;

            string[] ayrac = new string[1];
            ayrac[0] = ";;;";
            string[] aciklamalar = iade.strAciklama.Split(ayrac, StringSplitOptions.None);
            txtSiparisAciklama2.Text = aciklamalar[1];
            txtSiparisAciklama3.Text = aciklamalar[2];
        }
        public void GetSiparisSepeti()
        {
            Repeater1.DataSource = (IadeListe)Session["Iade"];
            Repeater1.DataBind();
        }
        #endregion

        #region AciklamalariGuncelle
        private void AciklamalariGuncelle()
        {
            if (Session["Iade"] != null) // session kendiliğinden sonlanırsa da bu ekrandan bir link tıklanırsa, postback de hataya düşmemesi için
            {
                string aciklama1 = Iadeler.GetObjectsByIadeID(((IadeListe)Session["Iade"])._IadeID).strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0];
                //if (Session["IadeGirenMusteriID"] != null)
                //{
                //    Musteriler musteri = Musteriler.GetMusteriByID((int)Session["IadeGirenMusteriID"]);
                //    aciklama1 = musteri.strAd + " " + musteri.strSoyad;
                //}
                //else
                //{
                //    aciklama1 = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
                //}

                ((IadeListe)Session["Iade"]).AciklamaGuncelle(aciklama1, txtSiparisAciklama2.Text.Trim(), txtSiparisAciklama3.Text.Trim());
            }
        }
        #endregion

        #region GetProducts ------------------------
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
                DataTable dt = new DataTable();
                Urunler.GetProducts(dt, (int)Session["Start"], (int)Session["Count"],
                    tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                    ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar);

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
        #endregion

        #region GetProductsCount ------------------------
        private int GetProductsCount()
        {
            //if (Session["Kategori"] == "NOT NULL" && Session["Tedarikci"] == "NOT NULL" && Session["Aranan"] == "")
            //    return 0;

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

            return Urunler.GetProductsCount(tedarikcioperator,
                    Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(),
                    ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar);
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
                if (((IadeListe)Session["Iade"]).Items.Count >= 100)
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

                for (int j = 0; j < dl.Controls[i].Controls.Count; j++) // üründeki kontroller
                {
                    if (dl.Controls[i].Controls[j] is System.Web.UI.HtmlControls.HtmlGenericControl) // urunid si
                    {
                        string tekst = ((System.Web.UI.HtmlControls.HtmlGenericControl)dl.Controls[i].Controls[j]).InnerText;

                        if (urunid == 0) // urun
                            urunid = Convert.ToInt32(tekst);
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
                    ((IadeListe)Session["Iade"]).Add(urunid, miktar);
                }
            }

            return miktargirilmis;
        }
        #endregion

        #region GetKategoriler, GetTedarikciler
        private void GetKategoriler(string harf)
        {
            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetKategoriler2iade(harf, Session["Tedarikci"].ToString(), aramabasi, Session["Aranan"].ToString(), rblKategoriler.Items, ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar, false);
        }
        private void GetTedarikciler(string harf)
        {
            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetTedarikciler2iade(harf, Session["Kategori"].ToString(), aramabasi, Session["Aranan"].ToString(), rblTedarikciler.Items, ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar, false);
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
            Urunler.GetProducts(dt, txtArama.Text.Trim(),
                ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar, true);

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
            Urunler.GetProducts(dt, txtArama.Text.Trim(),
                ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar);

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
            Urunler.GetProducts(dt, txtArama.Text.Trim(),
                ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar, true, true);

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

        #region TedarikciHarfler
        private void TedarikciHarfler()
        {
            string kategorioperator = "IS";
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

            Urunler.GetTedarikciHangiHarfler(dt, /*Session["Tedarikci"].ToString(),
                tedarikcioperator, */Session["Kategori"].ToString(), kategorioperator, aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar);

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
            if (Session["Tedarikci"] != "NOT NULL")
            {
                if (!Session["Tedarikci"].ToString().StartsWith("'"))
                    Session["Tedarikci"] = "'" + Session["Tedarikci"].ToString() + "'";
                tedarikcioperator = "=";
            }

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";

            DataTable dt = new DataTable();

            Urunler.GetKategoriHangiHarfler(dt, Session["Tedarikci"].ToString(),
                tedarikcioperator, /*Session["Kategori"].ToString(), kategorioperator, */aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["IadeYetkiler"]).OzelKodlar, ((UyeYetkileri)Session["IadeYetkiler"]).GrupKodlar);

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

        #region SepetiBosalt, SiparisIptal
        private void SepetiBosalt()
        {
            ((IadeListe)Session["Iade"]).DeleteIadelerDetay(true);
        }
        private void SiparisIptal()
        {
            ((IadeListe)Session["Iade"]).DeleteIadeIadelerDetayFromDB();

            IadeHareketleri.DoInsert(((IadeListe)Session["Iade"])._IadeID, 16, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // iade silindi

            Session["IadeID"] = null;
            Session["Iade"] = null;
            GC.Collect();
            Response.Redirect("default.aspx", true);
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
            //cbYeniUrunler.Checked = false;

            if (txtArama.Text.Trim() != string.Empty)
            {
                if (UrunSecimTarama(false, false))
                {
                    divTedarikciKategoriDis.Visible = true;
                    divAktarim.Visible = true;

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
            }
            else
            {
                cbBarkodHemenEkle.Enabled = false;
                cbBarkodHemenAra.Enabled = false;
                txtArama.Attributes.Remove("onkeyup");
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

                Session["Aktarim"] = "SiralamaTuru";

                string siralama = string.Empty;

                if (rbTariheGoreSiralama.Checked)
                    siralama = "UrunID";
                else if (rbABCSiralama.Checked)
                    siralama = "Ad";

                if (Session["Siralama"] == "UrunID")
                {
                    rbABCSiralama.Checked = false;
                    rbTariheGoreSiralama.Checked = true;
                }
                else if (Session["Siralama"] == "TedarikciAdi")
                {
                    rbTariheGoreSiralama.Checked = false;
                    rbABCSiralama.Checked = true;
                }

                Session["Siralama"] = siralama;
            }
            else
            {
                if (rbTariheGoreSiralama.Checked)
                    Session["Siralama"] = "UrunID";
                else if (rbABCSiralama.Checked)
                    Session["Siralama"] = "TedarikciAdi";

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
            //cbYeniUrunler.Checked = false;

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
            //cbYeniUrunler.Checked = false;

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
            //cbYeniUrunler.Checked = false;

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
            //cbYeniUrunler.Checked = false;

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
                    rbTariheGoreSiralama.Checked = true;
                }
                else if (Session["Siralama"] == "TedarikciAdi")
                {
                    rbTariheGoreSiralama.Checked = false;
                    rbABCSiralama.Checked = true;
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

            }
            else if (Session["Aktarim"] == "TaksitPlaniDegistir")
            {

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

            }
            else if (Session["Aktarim"] == "TaksitPlaniDegistir")
            {

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
                long iadedetayid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("IadeDetayID")).Value);

                Session["SiparisSepettenSil"] = iadedetayid;
                SiparisSepettenUrunSil();
            }
            else if (e.CommandName == "Guncelle")
            {
                long iadedetayid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("IadeDetayID")).Value);
                int yenimiktar = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("Miktar")).Value);

                ((IadeListe)Session["Iade"]).Update(iadedetayid, yenimiktar);
                GetSiparisSepeti();
            }
            else if (e.CommandName == "Arttir")
            {
                int urunid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("UrunID")).Value);

                ((IadeListe)Session["Iade"]).Add(urunid, 1);
                GetSiparisSepeti();
            }
            else if (e.CommandName == "Azalt")
            {
                int urunid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("UrunID")).Value);

                bool urundahaeksiltilmez = ((IadeListe)Session["Iade"]).Add(urunid, -1);
                if (urundahaeksiltilmez)
                    return;

                GetSiparisSepeti();
            }
        }
        private void SiparisSepettenUrunSil()
        {
            long iadedetayid = (long)Session["SiparisSepettenSil"];

            ((IadeListe)Session["Iade"]).Remove(iadedetayid);

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

            if (rbMalzemeler.Checked)
                SepetBilgisiGuncelle();
        }
        protected void btnSiparisiTamamla_Click(object sender, EventArgs e)
        {
            Session["IadeTamamlaBasildi"] = ((IadeListe)Session["Iade"])._SMREF;
            Session["Iade"] = null;
            Response.Redirect("iadeler.aspx");
        }
        protected void btnSiparisiTamamlaOnayla_Click(object sender, EventArgs e)
        {
            Session["IadeTamamlaOnaylaBasildi"] = ((IadeListe)Session["Iade"])._SMREF;
            Session["OnaylanacakIadeID"] = ((IadeListe)Session["Iade"])._IadeID;
            Session["Iade"] = null;
            Response.Redirect("iadeler.aspx");
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
        #endregion

        #region Events Ürün Seçimi İleri Geri
        protected void lbOnceki_Click(object sender, EventArgs e)
        {
            if (UrunSecimTarama(false, false))
            {
                divTedarikciKategoriDis.Visible = true;
                divAktarim.Visible = true;

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

        protected void rbMalzemeler_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void lbSayfayaGit_Click(object sender, EventArgs e)
        {
            Session["Iade"] = null;

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

            lblUrunAyrintiAd.Text = Urunler.GetProductName(UrunID, true);
            lblUrunAyrintiBarkod.Text = "(" + Urunler.GetProductBarkod(UrunID, true) + ")";

            //txtUrunAyrintiMiktar.Visible = Urunler.ProductIsAvailable(UrunID);
            //btnUrunAyrintiSiparisVer.Enabled = Urunler.ProductIsAvailable(UrunID);
            //imgUrunAyrintiPasif.Visible = !Urunler.ProductIsAvailable(UrunID);

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divUrunAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);

            txtUrunAyrintiMiktar.Focus();
        }

        protected void ibUrunAyrinti_Click(object sender, ImageClickEventArgs e)
        {
            int ResimID = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            int UrunID = Convert.ToInt32(((ImageButton)sender).CommandName);
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

            lblUrunAyrintiAd.Text = Urunler.GetProductName(UrunID, true);
            lblUrunAyrintiBarkod.Text = "(" + Urunler.GetProductBarkod(UrunID, true) + ")";

            //txtUrunAyrintiMiktar.Visible = Urunler.ProductIsAvailable(UrunID);
            //btnUrunAyrintiSiparisVer.Enabled = Urunler.ProductIsAvailable(UrunID);
            //imgUrunAyrintiPasif.Visible = !Urunler.ProductIsAvailable(UrunID);

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
                ((IadeListe)Session["Iade"]).Add(
                    Convert.ToInt32(btnUrunAyrintiSiparisVer.CommandArgument),
                    Convert.ToInt32(txtUrunAyrintiMiktar.Text.Trim()));

                SepetBilgisiGuncelle();
                btnUrunAyrintiSiparisVer.CommandArgument = string.Empty;
                divUrunAyrinti.Visible = false;
            }
        }

        //protected void ibYeniUrunler_Click(object sender, ImageClickEventArgs e)
        //{
        //    cbYeniUrunler.Checked = !cbYeniUrunler.Checked;
        //    if (cbYeniUrunler.Checked)
        //        Session["Start"] = 0;
        //    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        //}

        //protected void cbYeniUrunler_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbYeniUrunler.Checked)
        //        Session["Start"] = 0;
        //    GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        //}

        protected void rblResimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucUrunAyrinti1.ResimAc(Convert.ToInt32(rblResimler.SelectedValue));
        }

        protected void btnSiparisKalemFazlaKapat_Click(object sender, EventArgs e)
        {
            divSiparisKalemFazla.Visible = false;
        }
    }
}