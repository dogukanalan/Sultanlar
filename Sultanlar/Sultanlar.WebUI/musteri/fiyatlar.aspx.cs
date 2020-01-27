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
    public partial class fiyatlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);



            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 5) // perakende müşteri değil ise
                {
                    if (Session["Musteri"] == null || Session["Yetkiler"] == null || Session["FiyatlarFiyatTipi"] == null)
                        Response.Redirect("default.aspx", true);
                }
                else
                {
                    Response.Redirect("yetkiyok.aspx", true);
                }

                

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

                lblUrunAyrintiTedarikciIlgili.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;
                //hlSatistaOnAdim.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(DivAjax, typeof(string), "kucukbilgi", alert, false);
        }

        #region GetUstBilgiler
        private void GetUstBilgiler()
        {
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]);
                ddlFiyatTipleri.Items.Add(FiyatTipleri.GetObjectByID(fiyattipiid));
                ddlFiyatTipleri.Items[i].Value = fiyattipiid.ToString();
            }
            ddlFiyatTipleri.SelectedValue = Session["FiyatlarFiyatTipi"].ToString();
        }
        #endregion

        #region GetTaksitPlani
        private void GetTaksitPlani()
        {
            if (((Musteriler)Session["Musteri"]).blTaksitPlani)
            {
                TaksitPlanlari.GetObjects(ddlTaksitPlanlari.Items, Convert.ToInt16(Session["FiyatlarFiyatTipi"]));
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
            //GetTaksitPlani();
            
            
            //if (ddlTaksitPlanlari.Items.Count > 1) // fiyat tipi taksitli ise 1. taksit planını hemen seçsin
            //{
            //    ddlTaksitPlanlari.SelectedIndex = 1;
            //    TaksitPlaniDegistir();
            //}


            Session["FiyatlarFiyatTipi"] = ddlFiyatTipleri.SelectedValue;


            if (rbMalzemeler.Checked)
            {
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
            else
            {
                ucKampanyalar1.GetObjects();
            }
        }
        #endregion

        #region TaksitPlaniDegistir
        private void TaksitPlaniDegistir()
        {
            TaksitPlanlari tp = TaksitPlanlari.GetObject(Convert.ToInt32(ddlTaksitPlanlari.SelectedValue));
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
                Urunler.GetProducts(dt, (int)Session["Start"], (int)Session["Count"], Session["FiyatlarFiyatTipi"].ToString(),
                    tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                    ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, cbYeniUrunler.Checked);

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
                }
                else
                {
                    lblEmpty.Visible = false;
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
            Urunler.GetProducts(dt, 0, (int)Session["MaxRecordCount"], Session["FiyatlarFiyatTipi"].ToString(),
                tedarikcioperator, Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                Session["Aranan"].ToString(), Session["Siralama"].ToString(), Session["AzalanArtan"].ToString(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, cbYeniUrunler.Checked);
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

            return Urunler.GetProductsCount(Session["FiyatlarFiyatTipi"].ToString(), tedarikcioperator,
                    Session["Tedarikci"].ToString(), kategorioperator, Session["Kategori"].ToString(), aramabasi,
                    Session["Aranan"].ToString(),
                    ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, cbYeniUrunler.Checked);
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

        #region GetKategoriler, GetTedarikciler
        private void GetKategoriler(string harf)
        {
            //Urunler.GetKategoriler(harf, rblKategoriler.Items);

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetKategoriler2(harf, Session["Tedarikci"].ToString(), aramabasi, Session["Aranan"].ToString(), rblKategoriler.Items, Convert.ToInt32(Session["FiyatlarFiyatTipi"]), ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, true);
        }
        private void GetTedarikciler(string harf)
        {
            //Urunler.GetTedarikciler(harf, rblTedarikciler.Items);

            string aramabasi = string.Empty;
            if (!rbBaslangicaGore.Checked)
                aramabasi = "%";
            Urunler.GetTedarikciler2(harf, Session["Kategori"].ToString(), aramabasi, Session["Aranan"].ToString(), rblTedarikciler.Items, Convert.ToInt32(Session["FiyatlarFiyatTipi"]), ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, true);
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
            Urunler.GetProducts(dt, Session["FiyatlarFiyatTipi"].ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);

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

            txtArama.Text = "";
            txtArama.Focus();
        }
        #endregion

        #region MalzemeKoduAra
        private void MalzemeKoduAra()
        {
            lblAramaSecim.Text = txtArama.Text + " (Malzeme kodu arama)";

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, Session["FiyatlarFiyatTipi"].ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, true);

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
            Urunler.GetProducts(dt, Session["FiyatlarFiyatTipi"].ToString(), txtArama.Text.Trim(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, true, true);

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

            Urunler.GetTedarikciHangiHarfler(dt, Convert.ToInt16(Session["FiyatlarFiyatTipi"]), /*Session["Tedarikci"].ToString(),
                tedarikcioperator, */Session["Kategori"].ToString(), kategorioperator, aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);

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

            Urunler.GetKategoriHangiHarfler(dt, Convert.ToInt16(Session["FiyatlarFiyatTipi"]), Session["Tedarikci"].ToString(),
                tedarikcioperator, /*Session["Kategori"].ToString(), kategorioperator, */aramabasi, Session["Aranan"].ToString(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);

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
            cbYeniUrunler.Checked = false;

            if (txtArama.Text.Trim() != string.Empty)
            {
                Session["Aranan"] = txtArama.Text;
                string aramasecim = " (Başlangıca göre)";

                if (rbIcinde.Checked)
                    aramasecim = " (İçinde)";

                lblAramaSecim.Text = txtArama.Text + aramasecim;
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
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
                AramaTemizle();
                TedarikciTemizle();
                KategoriTemizle();

                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void btnAramaTemizle_Click(object sender, EventArgs e)
        {
            if (lblAramaSecim.Text != "-")
            {
                AramaTemizle();
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void btnTedarikciTemizle_Click(object sender, EventArgs e)
        {
            if (lblTedarikciSecim.Text != "-")
            {
                TedarikciTemizle();
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        protected void btnKategoriTemizle_Click(object sender, EventArgs e)
        {
            if (lblKategoriSecim.Text != "-")
            {
                KategoriTemizle();
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
        }
        #endregion

        #region Events Düzen Sıralama
        protected void Duzen_CheckedChanged(object sender, EventArgs e)
        {
            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }
        protected void SiralamaAzalanArtan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSiralamaAzalan.Checked)
                Session["AzalanArtan"] = "DESC";
            else if (rbSiralamaArtan.Checked)
                Session["AzalanArtan"] = "ASC";

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }
        protected void Siralama_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTariheGoreSiralama.Checked)
                Session["Siralama"] = "UrunID";
            else if (rbABCSiralama.Checked)
                Session["Siralama"] = "TedarikciAdi";
            else if (rbFYTSiralama.Checked)
                Session["Siralama"] = "Fiyat";

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
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

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
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

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
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

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
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

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }
        #endregion

        #region Events Siparişe Aktarım
        //protected void btnAktarimDevam_Click(object sender, EventArgs e)
        //{
        //    if (Session["Aktarim"] == "Duzen")
        //    {
        //        rbResimDuzeni.Checked = !rbResimDuzeni.Checked;
        //        rbListeDuzeni.Checked = !rbListeDuzeni.Checked;
        //    }
        //    else if (Session["Aktarim"] == "Siralama")
        //    {
        //        rbSiralamaAzalan.Checked = !rbSiralamaAzalan.Checked;
        //        rbSiralamaArtan.Checked = !rbSiralamaArtan.Checked;

        //        if (rbSiralamaAzalan.Checked)
        //            Session["AzalanArtan"] = "DESC";
        //        else if (rbSiralamaArtan.Checked)
        //            Session["AzalanArtan"] = "ASC";
        //    }
        //    else if (Session["Aktarim"] == "SiralamaTuru")
        //    {
        //        if (Session["Siralama"] == "UrunID")
        //        {
        //            rbABCSiralama.Checked = false;
        //            rbFYTSiralama.Checked = false;
        //            rbTariheGoreSiralama.Checked = true;
        //        }
        //        else if (Session["Siralama"] == "TedarikciAdi")
        //        {
        //            rbFYTSiralama.Checked = false;
        //            rbTariheGoreSiralama.Checked = false;
        //            rbABCSiralama.Checked = true;
        //        }
        //        else if (Session["Siralama"] == "Fiyat")
        //        {
        //            rbTariheGoreSiralama.Checked = false;
        //            rbABCSiralama.Checked = false;
        //            rbFYTSiralama.Checked = true;
        //        }
        //    }
        //    else if (Session["Aktarim"] == "Arama")
        //    {
        //        Session["Aranan"] = txtArama.Text.Trim();
        //        string aramasecim = " (Başlangıca göre)";
        //        if (rbIcinde.Checked)
        //            aramasecim = " (İçinde)";
        //        lblAramaSecim.Text = txtArama.Text + aramasecim;
        //    }
        //    else if (Session["Aktarim"] == "Tedarikci")
        //    {
        //        //
        //    }
        //    else if (Session["Aktarim"] == "Kategori")
        //    {
        //        //
        //    }
        //    else if (Session["Aktarim"] == "AramaTemizleme")
        //    {
        //        AramaTemizle();
        //    }
        //    else if (Session["Aktarim"] == "TedarikciTemizleme")
        //    {
        //        TedarikciTemizle();
        //    }
        //    else if (Session["Aktarim"] == "KategoriTemizleme")
        //    {
        //        KategoriTemizle();
        //    }
        //    else if (Session["Aktarim"] == "TumunuTemizleme")
        //    {
        //        AramaTemizle();
        //        TedarikciTemizle();
        //        KategoriTemizle();
        //    }
        //    else if (Session["Aktarim"] == "SayfaDegismeGeri")
        //    {
        //        Session["Start"] = (int)Session["Start"] - (int)Session["Count"];
        //        if ((int)Session["Start"] < 0)
        //        {
        //            Session["Start"] = 0;
        //        }
        //    }
        //    else if (Session["Aktarim"] == "SayfaDegismeIleri")
        //    {
        //        Session["Start"] = (int)Session["Start"] + (int)Session["Count"];
        //        if ((int)Session["Start"] > (int)Session["MaxRecordCount"] - 5)
        //        {
        //            Session["Start"] = (int)Session["MaxRecordCount"] - 5;
        //        }
        //    }
        //    else if (Session["Aktarim"] == "FiyatTipiDegistir")
        //    {
        //        FiyatTipiDegistir();
        //    }
        //    else if (Session["Aktarim"] == "TaksitPlaniDegistir")
        //    {
        //        TaksitPlaniDegistir();
        //    }

        //    if (rbMalzemeler.Checked)
        //        GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        //    else
        //        ucKampanyalar1.GetObjects();

        //    divTedarikciKategoriDis.Visible = false;
        //}
        //protected void btnAktarimDur_Click(object sender, EventArgs e)
        //{
        //    if (Session["Aktarim"] == "SiralamaTuru")
        //    {
        //        if (rbTariheGoreSiralama.Checked)
        //            Session["Siralama"] = "UrunID";
        //        else if (rbABCSiralama.Checked)
        //            Session["Siralama"] = "TedarikciAdi";
        //        else if (rbFYTSiralama.Checked)
        //            Session["Siralama"] = "Fiyat";
        //    }
        //    else if (Session["Aktarim"] == "Tedarikci")
        //    {
        //        Session["Tedarikci"] = Session["OncekiTedarikci"];
        //        lblTedarikciSecim.Text = "-";
        //    }
        //    else if (Session["Aktarim"] == "Kategori")
        //    {
        //        Session["Kategori"] = Session["OncekiKategori"];
        //        lblKategoriSecim.Text = "-";
        //    }
        //    else if (Session["Aktarim"] == "FiyatTipiDegistir")
        //    {
        //        for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
        //        {
        //            if (ddlFiyatTipleri.Items[i].Value == ((SiparisListe)Session["Siparis"])._FiyatTipi.ToString())
        //            {
        //                ddlFiyatTipleri.SelectedIndex = i;
        //                i = ddlFiyatTipleri.Items.Count;
        //            }
        //        }
        //    }
        //    else if (Session["Aktarim"] == "TaksitPlaniDegistir")
        //    {
        //        for (int i = 0; i < ddlFiyatTipleri.Items.Count; i++)
        //        {
        //            if (ddlTaksitPlanlari.Items[i].Value == ((SiparisListe)Session["Siparis"])._TKSREF.ToString())
        //            {
        //                ddlTaksitPlanlari.SelectedIndex = i;
        //                i = ddlTaksitPlanlari.Items.Count;
        //            }
        //        }
        //    }

        //    divTedarikciKategoriDis.Visible = false;
        //}
        #endregion

        #region Events Ürün Seçimi İleri Geri
        protected void lbOnceki_Click(object sender, EventArgs e)
        {
            Session["MaxRecordCount"] = GetProductsCount();

            Session["Start"] = (int)Session["Start"] - (int)Session["Count"];
            if ((int)Session["Start"] < 0)
                Session["Start"] = 0;

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }
        protected void lbSonraki_Click(object sender, EventArgs e)
        {
            //Session["MaxRecordCount"] = GetProductsCount();

            Session["Start"] = (int)Session["Start"] + (int)Session["Count"];
            //if ((int)Session["Start"] > (int)Session["MaxRecordCount"] - 5)
            //    Session["Start"] = (int)Session["MaxRecordCount"] - 5;

            if ((int)Session["Start"] < 0)
                Session["Start"] = 0;

            GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
        }
        #endregion

        #region Event Fiyat Tipi
        protected void ddlFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["FiyatlarFiyatTipi"] = ddlFiyatTipleri.SelectedValue;

            if (rbMalzemeler.Checked)
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            else
                ucKampanyalar1.GetObjects();
        }
        #endregion

        #region Event Taksit Planlari
        protected void ddlTaksitPlanlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaksitPlaniDegistir();
        }
        #endregion

        protected void rbMalzemeler_CheckedChanged(object sender, EventArgs e)
        {
            tblURUNLER.Visible = rbMalzemeler.Checked;
            ucKampanyalar1.Visible = rbKampanyalar.Checked;

            if (rbMalzemeler.Checked)
            {
                btnMalzemelereGeriDon.Visible = false;
                GetProducts(rbResimDuzeni.Checked, rbBaslangicaGore.Checked);
            }
            else
            {
                btnMalzemelereGeriDon.Visible = true;
                ucKampanyalar1.GetObjects();
            }
        }

        protected void KampanyaliUrun_Click(object sender, ImageClickEventArgs e)
        {
            int UrunID = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            rbMalzemeler.Checked = false;
            rbKampanyalar.Checked = true;
            tblURUNLER.Visible = false;
            ucKampanyalar1.Visible = true;
            ucKampanyalar1.GetObjectsByUrunID(UrunID);
            btnMalzemelereGeriDon.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(ucKampanyalar1, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void btnMalzemelereGeriDon_Click(object sender, EventArgs e)
        {
            rbKampanyalar.Checked = false;
            rbMalzemeler.Checked = true;
            tblURUNLER.Visible = true;
            ucKampanyalar1.Visible = false;
            btnMalzemelereGeriDon.Visible = false;
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
            int FiyatTipi = Convert.ToInt16(Session["FiyatlarFiyatTipi"]);

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
        }

        protected void ibUrunAyrinti_Click(object sender, ImageClickEventArgs e)
        {
            int ResimID = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            int UrunID = Convert.ToInt32(((ImageButton)sender).CommandName);
            int FiyatTipi = Convert.ToInt16(Session["FiyatlarFiyatTipi"]);
            int TedarikciResimID = TedarikciResim.GetResimID(UrunID);

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
        }

        protected void lbUrunAyrintiKapat_Click(object sender, EventArgs e)
        {
            divUrunAyrinti.Visible = false;
        }

        protected void btnUrunAyrintiOnceki_Click(object sender, EventArgs e)
        {
            int UrunID = 0;
            int ResimID = 0;
            int FiyatTipi = Convert.ToInt16(Session["FiyatlarFiyatTipi"]);

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
            }
        }

        protected void btnUrunAyrintiSonraki_Click(object sender, EventArgs e)
        {
            int UrunID = 0;
            int ResimID = 0;
            int FiyatTipi = Convert.ToInt16(Session["FiyatlarFiyatTipi"]);

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
    }
}