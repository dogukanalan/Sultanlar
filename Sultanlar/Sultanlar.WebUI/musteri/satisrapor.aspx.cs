using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.musteri
{
    /// <summary>
    /// ListItemCollection larda value nun başına text in ilk 3 hanesi GELİYOR ddltemsilciler hariç
    /// </summary>
    public partial class satisrapor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("default.aspx", true);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    Response.Redirect("yetkiyok.aspx", true);

                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = DateTime.Now;

                Session["SatisRaporSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intRaporSatirSayisi;

                GetTedarikciler();
                GetFiyatTipleri();
                GetCariHesaplar();

                Session["downloadyazdirsatisraporurunler"] = new ListItemCollection();
                Session["downloadyazdirsatisraporurunlerselectedindex"] = 0;
                Session["downloadyazdirsatisraporozelkod"] = "";
                Session["downloadyazdirsatisraporfiyattip"] = "";
                Session["downloadyazdirsatisraporbedelsiz"] = false;
                Session["downloadyazdirsatisraporiadeler"] = false;
                Session["downloadyazdirsatisraportarih1"] = Calendar1.SelectedDate;
                Session["downloadyazdirsatisraportarih2"] = Calendar2.SelectedDate;
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGosterSade\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(upHesapAyrintilari, typeof(string), "kucukbilgi", alert, false);
        }

        private void GetTedarikciler()
        {
            Urunler.GetOzelKodlar(ddlUrunAramaTedarikciler.Items, true);
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObject(ddlUrunAramaFiyatTipleri.Items, false, true);
        }

        private void GetCariHesaplar()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 ||
                ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)     // satış temsilcisi ise veya yönetici ise
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                {
                    hlBorcAlacak.Visible = (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) && !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8");
                    imgBorcAlacak.Visible = (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) && !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8");
                    hlSatisHedef.Visible = true;
                    imgSatisHedef.Visible = true;
                    //hlSatistaOnAdim.Visible = true;
                    hlStok.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6;
                    imgStok.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6;
                    GetSatisSefYoneticiHesaplar();

                    lblRaporYok.Visible = true;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    hlBorcAlacak.Visible = true;
                    imgBorcAlacak.Visible = true;
                    hlSatisHedef.Visible = true;
                    imgSatisHedef.Visible = true;
                    divCariHesapArama.Visible = true;
                    //hlSatistaOnAdim.Visible = true;
                    hlStok.Visible = true;
                    imgStok.Visible = true;

                    lblRaporYok.Visible = true;

                    SatisTemsilcileri.GetObjectsFromCariHesaplar(ddlTemsilciler.Items);
                    ArrayList slsrefs = new ArrayList();
                    slsrefs.Add(ddlTemsilciler.SelectedValue);
                    divCariHesapArama.Visible = true;
                    ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                    ddlCariHesaplar.Items.Add(new ListItem(ddlTemsilciler.SelectedItem.Text + " - ::: BÜTÜN SATIŞ RAPORU :::", "1"));
                    CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);

                    //SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                    //ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                    //ddlCariHesaplar.SelectedIndex = 0;
                }
            }
            else                                                                        // müşteri ise
            {
                ddlTemsilciler.Enabled = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 1;
                //int slsref = 0;
                if (CariHesaplar.AnaSubeMi(((Musteriler)Session["Musteri"]).intGMREF))
                    CariHesaplar.GetSatTemsByGMREF(ddlTemsilciler.Items, ((Musteriler)Session["Musteri"]).intGMREF);
                else
                    CariHesaplar.GetSatTemsBySMREF(ddlTemsilciler.Items, ((Musteriler)Session["Musteri"]).intGMREF);
                //ArrayList sattem = SatisTemsilcileri.GetObjectBySLSREF(slsref);
                //ddlTemsilciler.Items.Add(new ListItem(sattem[1].ToString(), slsref.ToString()));

                int gmref = ((Musteriler)Session["Musteri"]).intGMREF;
                Session["SatisRaporGetirilecekSMREF"] = gmref;

                if (CariHesaplar.AnaSubeMi(gmref))
                {
                    ddlCariHesaplarSubeler.Visible = true;
                    ListItem list = new ListItem();
                    string text = CariHesaplar.GetObjectByGMREF(gmref)[1].ToString();
                    list.Text = text;
                    list.Value = text.Substring(0, 3) + gmref.ToString();
                    ddlCariHesaplar.Items.Add(list);
                    CariHesaplar.GetSubeler(ddlCariHesaplarSubeler.Items, Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                }
                else
                {
                    divSuzme.Visible = true;
                    ddlCariHesaplarSubeler.Visible = false;
                    ListItem lst = new ListItem();
                    lst.Text = CariHesaplar.GetObjectByGMREF(gmref)[1].ToString();
                    lst.Value = gmref.ToString();
                    ddlCariHesaplar.Items.Add(lst);

                    GetSatisRaporCountBySMREF(gmref, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                    GetSatisRaporlarBySMREF(gmref, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    GetToplamlarBySMREF(gmref, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");

                    // son sayfaya git:
                    if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                    {
                        int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                        GetSatisRaporlarBySMREF(gmref, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                        lblRaporKacinci.Text = raporsayisi.ToString();

                        ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                    }
                }
            }
        }

        private void GetSatisSefYoneticiHesaplar()
        {
            ArrayList altlar = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
                altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                altlar = SatisTemsilcileri.GetSLSREFsFromCariHesaplar();
            //Session["SefSLSREFs"] = altlar;



            if (altlar.Count == 0)  // şef değil ise
            {
                /*SAP*/
                ArrayList st = SatisTemsilcileri.GetObjectBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                if (st.Count > 0)
                    ddlTemsilciler.Items.Add(new ListItem(st[1].ToString(), ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                else
                    ddlTemsilciler.Items.Add(new ListItem("-", ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));



                ArrayList SMREFs = new ArrayList();



                CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, true);



                // önce tek carileri doldur, tek carilerde gmref = smref dir
                for (int i = 2; i < ddlCariHesaplar.Items.Count; i++)
                    SMREFs.Add(ddlCariHesaplar.Items[i].Value.Substring(3));



                ArrayList anacarigmrefler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                for (int i = 0; i < anacarigmrefler.Count; i++)
                {
                    DataTable dtAna = new DataTable();
                    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacarigmrefler[i]), true);

                    ListItem lst = new ListItem();
                    lst.Text = "G - " + dtAna.Rows[0][2].ToString() + " : ";
                    lst.Value = dtAna.Rows[0][2].ToString().Substring(0, 3) + dtAna.Rows[0][0].ToString();
                    ddlCariHesaplar.Items.Add(lst);



                    // sonra her bir grup şirketi eklenirken, ona ait şubelerin smref lerini doldur
                    DataTable dt = new DataTable();
                    CariHesaplar.GetSubeler(dt, Convert.ToInt32(anacarigmrefler[i]));
                    for (int j = 0; j < dt.Rows.Count; j++)
                        SMREFs.Add(dt.Rows[j]["SMREF"].ToString());
                }

                for (int i = 1; i < ddlCariHesaplar.Items.Count; i++)
                    ddlCariHesaplar.Items[i].Text = ddlTemsilciler.Items[0].Text + " - " + ddlCariHesaplar.Items[i].Text;



                Session["SatTemSMREFs"] = SMREFs; // şef değil ise fazla smref olmayacağından yeni yöntemi kullanmaya gerek yok

                ddlCariHesaplar.SelectedValue = "0";
                ddlCariHesaplarSubeler.Visible = false;
            }
            else // şef ise
            {
                cbNSTTumSatislar.Visible = SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8");

                SatisTemsilcileri.GetObjectsBySLSREFs(ddlTemsilciler.Items, altlar, true);

                if (Session["SefMusteriListesi"] == null)
                {
                    ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));

                    CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, altlar);

                    ListItemCollection lic = new ListItemCollection();
                    lic.Add(new ListItem("Seçiniz", "0"));
                    CariHesaplar.GetObjectsBySLSREFs(lic, altlar);
                    Session["SefMusteriListesi"] = lic;
                }
                else
                {
                    ddlCariHesaplar.Items.Add(((ListItemCollection)Session["SefMusteriListesi"])[0]); // seçiniz

                    for (int i = 1; i < ((ListItemCollection)Session["SefMusteriListesi"]).Count; i++)
                        ddlCariHesaplar.Items.Add(((ListItemCollection)Session["SefMusteriListesi"])[i]);
                }
            }
        }

        private void GetSatisRaporBos()
        {
            DataList1.DataSource = null;
            DataList1.DataBind();

            lblToplamBrut.Text = 0.ToString("C3");
            lblToplamIskonto.Text = 0.ToString("C3");
            lblToplamNet.Text = 0.ToString("C3");
            lblToplamNETKDV.Text = 0.ToString("C3");
        }

        #region SMREF
        private int GetSatisRaporCountBySMREF(int SMREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            int SLSREF = Convert.ToInt32(ddlTemsilciler.SelectedValue);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            int donendeger = SatisRapor.GetObjectCountBySMREF(SMREF, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);

            lblUrunArama.Text = ddlUrunler.SelectedItem.Text + " (" + ddlUrunAramaTedarikciler.SelectedItem.Text + ")";
            tblToplam.Visible = Convert.ToBoolean(donendeger > 0);
            GetToplamlarBySMREF(SMREF, lic, lic_si, OzelKod, FiyatTip);

            SayfaGecis(donendeger);

            if (donendeger > 0)
                lblRaporKacinci.Text = Session["SatisRaporSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SatisRaporSayfaBasiGosterim"])
                lblRaporKacinci.Text = donendeger.ToString();

            lblRaporSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSatisRaporlarBySMREF(int SMREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip, int Baslangic, int Adet)
        {
            int SLSREF = Convert.ToInt32(ddlTemsilciler.SelectedValue);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            Session["SatisRaporGetirilecekSMREF"] = SMREF;

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySMREF(dt, SMREF, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked, Baslangic, Adet,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        private void GetToplamlarBySMREF(int SMREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            int SLSREF = Convert.ToInt32(ddlTemsilciler.SelectedValue);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySMREF(SMREF, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }
        #endregion

        #region GMREF
        private int GetSatisRaporCountByGMREF(int GMREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            int SLSREF = Convert.ToInt32(ddlTemsilciler.SelectedValue);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            int donendeger = SatisRapor.GetObjectCountByGMREF(GMREF, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);

            lblUrunArama.Text = ddlUrunler.SelectedItem.Text + " (" + ddlUrunAramaTedarikciler.SelectedItem.Text + ")";
            tblToplam.Visible = Convert.ToBoolean(donendeger > 0);
            GetToplamlarByGMREF(GMREF, lic, lic_si, OzelKod, FiyatTip);

            SayfaGecis(donendeger);

            if (donendeger > 0)
                lblRaporKacinci.Text = Session["SatisRaporSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SatisRaporSayfaBasiGosterim"])
                lblRaporKacinci.Text = donendeger.ToString();

            lblRaporSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSatisRaporlarByGMREF(int GMREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip, int Baslangic, int Adet)
        {
            int SLSREF = Convert.ToInt32(ddlTemsilciler.SelectedValue);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            Session["SatisRaporGetirilecekGMREF"] = GMREF;

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsByGMREF(dt, GMREF, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked, Baslangic, Adet,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        private void GetToplamlarByGMREF(int GMREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            int SLSREF = Convert.ToInt32(ddlTemsilciler.SelectedValue);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarByGMREF(GMREF, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }
        #endregion

        #region SLSREF
        private int GetSatisRaporCountBySLSREF(int SLSREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            int donendeger = SatisRapor.GetObjectCountBySLSREF(SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);

            lblUrunArama.Text = ddlUrunler.SelectedItem.Text + " (" + ddlUrunAramaTedarikciler.SelectedItem.Text + ")";
            tblToplam.Visible = Convert.ToBoolean(donendeger > 0);
            GetToplamlarBySLSREF(SLSREF, lic, lic_si, OzelKod, FiyatTip);

            SayfaGecis(donendeger);

            if (donendeger > 0)
                lblRaporKacinci.Text = Session["SatisRaporSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SatisRaporSayfaBasiGosterim"])
                lblRaporKacinci.Text = donendeger.ToString();

            lblRaporSayisi.Text = donendeger.ToString();

            return donendeger;
        }
        private void GetSatisRaporlarBySLSREF(int SLSREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip, int Baslangic, int Adet)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            Session["SatisRaporGetirilecekSLSREF"] = SLSREF;

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySLSREF(dt, SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked, Baslangic, Adet,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        private void GetToplamlarBySLSREF(int SLSREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySLSREF(SLSREF, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }
        #endregion

        #region BySLSREFs
        private int GetSatisRaporCountBySLSREFs(int SLSREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            int donendeger = SatisRapor.GetObjectCountBySLSREFs(slsrefs, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);

            lblUrunArama.Text = ddlUrunler.SelectedItem.Text + " (" + ddlUrunAramaTedarikciler.SelectedItem.Text + ")";
            tblToplam.Visible = Convert.ToBoolean(donendeger > 0);
            GetToplamlarBySLSREFs(SLSREF, lic, lic_si, OzelKod, FiyatTip);

            SayfaGecis(donendeger);

            if (donendeger > 0)
                lblRaporKacinci.Text = Session["SatisRaporSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SatisRaporSayfaBasiGosterim"])
                lblRaporKacinci.Text = donendeger.ToString();

            lblRaporSayisi.Text = donendeger.ToString();

            return donendeger;
        }
        private void GetSatisRaporlarBySLSREFs(int SLSREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip, int Baslangic, int Adet)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySLSREFs(dt, slsrefs, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked, Baslangic, Adet,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        private void GetToplamlarBySLSREFs(int SLSREF, ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySLSREFs(slsrefs, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate, TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }
        #endregion

        #region All
        private int GetSatisRaporCount(ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            int donendeger = SatisRapor.GetObjectCount(lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate);

            lblUrunArama.Text = ddlUrunler.SelectedItem.Text + " (" + ddlUrunAramaTedarikciler.SelectedItem.Text + ")";
            tblToplam.Visible = Convert.ToBoolean(donendeger > 0);
            GetToplamlar(lic, lic_si, OzelKod, FiyatTip);

            SayfaGecis(donendeger);

            if (donendeger > 0)
                lblRaporKacinci.Text = Session["SatisRaporSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SatisRaporSayfaBasiGosterim"])
                lblRaporKacinci.Text = donendeger.ToString();

            lblRaporSayisi.Text = donendeger.ToString();

            return donendeger;
        }
        private void GetSatisRaporlar(ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip, int Baslangic, int Adet)
        {
            DataTable dt = new DataTable();
            SatisRapor.GetObjects(dt, lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked, Baslangic, Adet,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        private void GetToplamlar(ListItemCollection lic, int lic_si, string OzelKod, string FiyatTip)
        {
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlar(lic, lic_si, OzelKod, FiyatTip, cbBedelsizler.Checked, cbIadeler.Checked,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                Calendar1.SelectedDate, Calendar2.SelectedDate);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }
        #endregion

        private void SayfaGecis(int donendeger)
        {
            ddlSayfa.Items.Clear();
            int sayfasayisi = 0;
            int kalan = donendeger % (int)Session["SatisRaporSayfaBasiGosterim"];
            double sayfasayi = Convert.ToDouble(donendeger) / (int)Session["SatisRaporSayfaBasiGosterim"];
            if (kalan == 0)
            {
                sayfasayisi = Convert.ToInt32(sayfasayi);
            }
            else
            {
                if (kalan * 2 >= (int)Session["SatisRaporSayfaBasiGosterim"])
                    sayfasayisi = Convert.ToInt32(sayfasayi);
                else
                    sayfasayisi = Convert.ToInt32(sayfasayi) + 1;
            }
            for (int i = 1; i <= sayfasayisi; i++)
                ddlSayfa.Items.Add(new ListItem(i.ToString(), (i * (int)Session["SatisRaporSayfaBasiGosterim"]).ToString()));
            //ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise diğer raporlar gelmemesi için
            {
                if (CariHesaplar.AnaSubeMi(((Musteriler)Session["Musteri"]).intGMREF))
                {
                    ddlCariHesaplarSubeler.SelectedIndex = 0;

                    divSuzme.Visible = false;
                    tblToplam.Visible = false;

                    Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                    Calendar2.SelectedDate = DateTime.Now;

                    Session["SatisRaporGetirilecekSMREF"] = null;
                    lblRaporKacinci.Text = "0"; lblRaporSayisi.Text = "0";
                    GetSatisRaporBos();
                    ddlSayfa.Items.Clear();
                }
                else
                {
                    divSuzme.Visible = true;
                    ddlCariHesaplarSubeler.Visible = false;

                    GetSatisRaporCountBySMREF(((Musteriler)Session["Musteri"]).intGMREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                    GetSatisRaporlarBySMREF(((Musteriler)Session["Musteri"]).intGMREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    GetToplamlarBySMREF(((Musteriler)Session["Musteri"]).intGMREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                }

                return;
            }

            ddlCariHesaplar.Items.Clear();
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));

            if (ddlTemsilciler.SelectedValue == "1")
            {
                ddlCariHesaplar.Items.Clear();
                ddlCariHesaplar.Items.Add(new ListItem(ddlTemsilciler.SelectedItem.Text + " - ::: BÜTÜN SATIŞ RAPORU :::", "1"));

                ddlCariHesaplarSubeler.Items.Clear();
                ddlCariHesaplarSubeler.Visible = false;
                divSuzme.Visible = true;

                ddlUrunAramaTedarikciler.SelectedIndex = 0;
                ddlUrunler.Items.Clear(); ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
                ddlUrunler.SelectedIndex = 0;
                ddlUrunAramaFiyatTipleri.SelectedIndex = 0;
                txtUrunArama.Text = string.Empty;
                lblUrunArama.Text = "Tümü (Tümü)";

                GetSatisRaporCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");


                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }

                return;
            }
            else if (ddlTemsilciler.SelectedValue != "0")
            {
                ddlCariHesaplar.Items.Add(new ListItem(ddlTemsilciler.SelectedItem.Text + " - ::: BÜTÜN SATIŞ RAPORU :::", "1"));
            }

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;

            ArrayList slsrefs = new ArrayList(); slsrefs.Add(ddlTemsilciler.SelectedValue);
            CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);

            Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
            Calendar2.SelectedDate = DateTime.Now;

            tblToplam.Visible = false;
            DataList1.DataSource = null;
            DataList1.DataBind();
            ddlSayfa.Items.Clear();
            lblRaporKacinci.Text = "0"; lblRaporSayisi.Text = "0";

            ddlUrunAramaTedarikciler.SelectedIndex = 0;
            ddlUrunler.Items.Clear(); ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
            ddlUrunler.SelectedIndex = 0;
            ddlUrunAramaFiyatTipleri.SelectedIndex = 0;
            txtUrunArama.Text = string.Empty;
            lblUrunArama.Text = "Tümü (Tümü)";
            divSuzme.Visible = false;

            if (ddlTemsilciler.SelectedValue == "0")
            {
                divSuzme.Visible = false;
                Session["SatisRaporGetirilecekSLSREF"] = null;
                Session["SatisRaporGetirilecekGMREF"] = null;
                Session["SatisRaporGetirilecekSMREF"] = null;
                ddlSayfa.Items.Clear();
            }

            lblRaporYok.Visible = true;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSatisRaporBos();
            ddlCariHesaplarSubeler.Items.Clear();
            lblRaporKacinci.Text = "0"; lblRaporSayisi.Text = "0";
            ddlUrunAramaTedarikciler.SelectedIndex = 0;
            ddlUrunler.Items.Clear(); ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
            ddlUrunler.SelectedIndex = 0;
            ddlUrunAramaFiyatTipleri.SelectedIndex = 0;
            txtUrunArama.Text = string.Empty;
            lblUrunArama.Text = "Tümü (Tümü)";

            if (ddlCariHesaplar.SelectedValue == "1")
            {
                ddlCariHesaplarSubeler.Items.Clear();
                ddlCariHesaplarSubeler.Visible = false;

                GetSatisRaporCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                GetSatisRaporlarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "",
                    0, (int)Session["SatisRaporSayfaBasiGosterim"]);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySLSREF((int)Session["SatisRaporGetirilecekSLSREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }

                divSuzme.Visible = true;
            }
            else if (ddlCariHesaplar.SelectedValue != "0")
            {
                //ddlTemsilciler.SelectedItem.Text = ddlCariHesaplar.SelectedItem.Text.Substring(0, ddlCariHesaplar.SelectedItem.Text.IndexOf(" - "));
                for (int i = 0; i < ddlTemsilciler.Items.Count; i++)
                {
                    if (ddlTemsilciler.Items[i].Text == ddlCariHesaplar.SelectedItem.Text.Substring(0, ddlCariHesaplar.SelectedItem.Text.IndexOf(" - ")))
                    {
                        ddlTemsilciler.SelectedIndex = i;
                        break;
                    }
                }

                bool AnaSube = CariHesaplar.AnaSubeMi(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                if (AnaSube)
                {
                    ddlCariHesaplarSubeler.Visible = true;

                    if ((((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) && Session["SefMusteriListesi"] == null) // şef değil ise
                    {
                        CariHesaplar.GetSubelerBySLSREF(ddlCariHesaplarSubeler.Items,
                            Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ((Musteriler)Session["Musteri"]).intSLSREF);
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
                    {
                        CariHesaplar.GetSubeler(ddlCariHesaplarSubeler.Items, Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    }
                    else // yönetici veya şef ise
                    {
                        CariHesaplar.GetSubelerBySLSREF(ddlCariHesaplarSubeler.Items,
                            Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    }

                    ddlSayfa.Items.Clear();

                    tblToplam.Visible = false;

                    divSuzme.Visible = false;
                }
                else
                {
                    ddlCariHesaplarSubeler.Visible = false;

                    GetSatisRaporCountBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                    GetSatisRaporlarBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "",
                        0, (int)Session["SatisRaporSayfaBasiGosterim"]);



                    // son sayfaya git:
                    if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                    {
                        int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                        GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                        lblRaporKacinci.Text = raporsayisi.ToString();

                        ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                    }

                    divSuzme.Visible = true;
                }
            }
            else
            {
                divSuzme.Visible = false;

                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = DateTime.Now;

                tblToplam.Visible = false;

                ddlCariHesaplarSubeler.Visible = false;
                Session["SatisRaporGetirilecekSMREF"] = null;
                ddlSayfa.Items.Clear();

                lblRaporYok.Visible = true;
            }
        }

        protected void ddlCariHesaplarSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlUrunAramaTedarikciler.SelectedIndex = 0;
            ddlUrunler.Items.Clear(); ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
            ddlUrunler.SelectedIndex = 0;
            ddlUrunAramaFiyatTipleri.SelectedIndex = 0;
            txtUrunArama.Text = string.Empty;
            lblUrunArama.Text = "Tümü (Tümü)";

            if (ddlCariHesaplarSubeler.SelectedValue == "1")
            {
                GetSatisRaporCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                GetSatisRaporlarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", 0, (int)Session["SatisRaporSayfaBasiGosterim"]);


                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarByGMREF((int)Session["SatisRaporGetirilecekGMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }

                divSuzme.Visible = true;
            }
            else if (ddlCariHesaplarSubeler.SelectedValue != "0")
            {
                GetSatisRaporCountBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");
                GetSatisRaporlarBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "",
                    0, (int)Session["SatisRaporSayfaBasiGosterim"]);



                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }

                divSuzme.Visible = true;
            }
            else
            {
                divSuzme.Visible = false;

                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = DateTime.Now;

                tblToplam.Visible = false;

                Session["SatisRaporGetirilecekSMREF"] = null;
                lblRaporKacinci.Text = "0"; lblRaporSayisi.Text = "0";
                GetSatisRaporBos();
                ddlSayfa.Items.Clear();
            }
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblRaporKacinci.Text) - (int)Session["SatisRaporSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                string ozelkod = string.Empty;
                if (ddlUrunAramaTedarikciler.SelectedIndex > 0)
                    ozelkod = ddlUrunAramaTedarikciler.SelectedValue;
                string fiyattip = string.Empty;
                if (ddlUrunAramaFiyatTipleri.SelectedIndex > 0)
                    fiyattip = ddlUrunAramaFiyatTipleri.SelectedValue;

                if ((int)Session["SatisRaporSayfaBasiGosterim"] < baslangic)
                {
                    if (cbNSTTumSatislar.Checked) // nst ler için bütün satış raporu
                        GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                        GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else if (ddlCariHesaplar.SelectedValue == "1") // slsref seçilmişse
                        GetSatisRaporlarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                        GetSatisRaporlarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else
                        GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);

                    lblRaporKacinci.Text = baslangic.ToString();
                }
                else
                {
                    if (cbNSTTumSatislar.Checked) // nst ler için bütün satış raporu
                        GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                        GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else if (ddlCariHesaplar.SelectedValue == "1") // slsref seçilmişse
                        GetSatisRaporlarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                        GetSatisRaporlarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    else
                        GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);

                    lblRaporKacinci.Text = Session["SatisRaporSayfaBasiGosterim"].ToString();
                }

                ddlSayfa.SelectedIndex = ddlSayfa.SelectedIndex - 1;
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblRaporKacinci.Text) + (int)Session["SatisRaporSayfaBasiGosterim"];
            if (Convert.ToInt32(lblRaporKacinci.Text) < Convert.ToInt32(lblRaporSayisi.Text))
            {
                string ozelkod = string.Empty;
                if (ddlUrunAramaTedarikciler.SelectedIndex > 0)
                    ozelkod = ddlUrunAramaTedarikciler.SelectedValue;
                string fiyattip = string.Empty;
                if (ddlUrunAramaFiyatTipleri.SelectedIndex > 0)
                    fiyattip = ddlUrunAramaFiyatTipleri.SelectedValue;

                if (cbNSTTumSatislar.Checked) // nst ler için bütün satış raporu
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                else if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                else if (ddlCariHesaplar.SelectedValue == "1") // slsref seçilmişse
                    GetSatisRaporlarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                    GetSatisRaporlarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                else
                    GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, baslangic - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);

                if (baslangic > Convert.ToInt32(lblRaporSayisi.Text))
                    lblRaporKacinci.Text = lblRaporSayisi.Text;
                else
                    lblRaporKacinci.Text = baslangic.ToString();

                ddlSayfa.SelectedIndex = ddlSayfa.SelectedIndex + 1;
            }
        }

        protected void ibYazdir_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlTemsilciler.SelectedValue == "0" && !cbNSTTumSatislar.Checked)
                return;

            Session["SatisRaporYazdirSLSREF"] = Convert.ToInt32(ddlTemsilciler.SelectedValue);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                Session["SatisRaporYazdirGMREF"] = ((Musteriler)Session["Musteri"]).intGMREF;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 ||
                      ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yönetici ise
            {
                if (cbNSTTumSatislar.Checked)
                {
                    Session["SatisRaporYazdirTumOzelKod"] = true;
                }
                else if (ddlTemsilciler.SelectedValue == "1")
                {
                    Session["SatisRaporYazdirSLSREFs"] = true;
                    Session["SatisRaporYazdirSLSREF"] = ((Musteriler)Session["Musteri"]).intSLSREF;
                }
                else if (ddlCariHesaplar.SelectedValue == "1")
                {
                    Session["SatisRaporYazdirSLSREFs"] = null;
                }
                else if (ddlCariHesaplarSubeler.SelectedIndex > 1)
                {
                    Session["SatisRaporYazdirSMREF"] = Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3));
                }
                else if (ddlCariHesaplar.SelectedIndex > 0 && ddlCariHesaplarSubeler.Visible && ddlCariHesaplarSubeler.SelectedIndex == 1)
                {
                    Session["SatisRaporYazdirGMREF"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                }
                else if (ddlCariHesaplar.SelectedIndex > 0 && !ddlCariHesaplarSubeler.Visible)
                {
                    Session["SatisRaporYazdirGMREF"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                }
            }
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            if ((ddlTemsilciler.SelectedValue == "0" || ddlCariHesaplar.SelectedValue == "0" || ddlCariHesaplarSubeler.SelectedValue == "0") 
                && !cbNSTTumSatislar.Checked)
                return;

            Session["downloadsatisraporslsref"] = Convert.ToInt32(ddlTemsilciler.SelectedValue);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                Session["downloadsatisraporgmref"] = ((Musteriler)Session["Musteri"]).intGMREF;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 ||
                      ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yönetici ise
            {
                if (cbNSTTumSatislar.Checked)
                {
                    Session["downloadsatisraportumozelkod"] = true;
                }
                else if (ddlTemsilciler.SelectedValue == "1")
                {
                    Session["downloadsatisraporslsrefs"] = true;
                    Session["downloadsatisraporslsref"] = ((Musteriler)Session["Musteri"]).intSLSREF;
                }
                else if (ddlCariHesaplar.SelectedValue == "1")
                {
                    Session["downloadsatisraporslsrefs"] = null;
                }
                else if (ddlCariHesaplarSubeler.SelectedIndex > 1)
                {
                    Session["downloadsatisraporsmref"] = Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3));
                }
                else if (ddlCariHesaplar.SelectedIndex > 0 && ddlCariHesaplarSubeler.Visible && ddlCariHesaplarSubeler.SelectedIndex == 1)
                {
                    Session["downloadsatisraporgmref"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                }
                else if (ddlCariHesaplar.SelectedIndex > 0 && !ddlCariHesaplarSubeler.Visible)
                {
                    Session["downloadsatisraporgmref"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                }
            }

            divKaydet.Visible = true;
        }

        protected void lbKaydetKapat_Click(object sender, EventArgs e)
        {
            divKaydet.Visible = false;
        }

        protected void lbTarih_Click(object sender, EventArgs e)
        {
            divTarih.Visible = true;
        }

        protected void ibTarih_Click(object sender, ImageClickEventArgs e)
        {
            divTarih.Visible = true;
        }

        protected void lbTarihKapat_Click(object sender, EventArgs e)
        {
            Session["downloadyazdirsatisraportarih1"] = Calendar1.SelectedDate;
            Session["downloadyazdirsatisraportarih2"] = Calendar2.SelectedDate;

            string ozelkod = string.Empty;
            if (ddlUrunAramaTedarikciler.SelectedIndex > 0)
                ozelkod = ddlUrunAramaTedarikciler.SelectedValue;
            string fiyattip = string.Empty;
            if (ddlUrunAramaFiyatTipleri.SelectedIndex > 0)
                fiyattip = ddlUrunAramaFiyatTipleri.SelectedValue;

            if (cbNSTTumSatislar.Checked) // nst ler için bütün satış raporu
            {
                GetSatisRaporCount(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
            {
                GetSatisRaporCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplar.SelectedValue == "1") // slsref seçilmişse
            {
                GetSatisRaporCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
            {
                if (ddlCariHesaplar.SelectedIndex > -1)
                {
                    GetSatisRaporCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                    // son sayfaya git:
                    if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                    {
                        int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                        GetSatisRaporlarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                        lblRaporKacinci.Text = raporsayisi.ToString();

                        ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                    }
                    else
                    {
                        GetSatisRaporlarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    }
                }
            }
            else
            {
                if (Session["SatisRaporGetirilecekSMREF"] != null)
                {
                    GetSatisRaporCountBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                    // son sayfaya git:
                    if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                    {
                        int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                        GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                        lblRaporKacinci.Text = raporsayisi.ToString();

                        ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                    }
                    else
                    {
                        GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                    }
                }
            }

            divTarih.Visible = false;
        }

        protected void ddlSayfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ozelkod = string.Empty;
            if (ddlUrunAramaTedarikciler.SelectedIndex > 0)
                ozelkod = ddlUrunAramaTedarikciler.SelectedValue;
            string fiyattip = string.Empty;
            if (ddlUrunAramaFiyatTipleri.SelectedIndex > 0)
                fiyattip = ddlUrunAramaFiyatTipleri.SelectedValue;

            if (ddlSayfa.SelectedIndex == ddlSayfa.Items.Count - 1)
                lblRaporKacinci.Text = lblRaporSayisi.Text;
            else
                lblRaporKacinci.Text = ddlSayfa.SelectedValue;

            if (cbNSTTumSatislar.Checked) // nst ler için bütün satış raporu
                GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, Convert.ToInt32(ddlSayfa.SelectedValue) - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
            else if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, Convert.ToInt32(ddlSayfa.SelectedValue) - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
            else if (ddlCariHesaplar.SelectedValue == "1") // slsref seçilmişse
                GetSatisRaporlarBySLSREF((int)Session["SatisRaporGetirilecekSLSREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, Convert.ToInt32(ddlSayfa.SelectedValue) - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
            else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                GetSatisRaporlarByGMREF((int)Session["SatisRaporGetirilecekGMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, Convert.ToInt32(ddlSayfa.SelectedValue) - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
            else
                GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, Convert.ToInt32(ddlSayfa.SelectedValue) - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
        }

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty || txtCariHesapAra.Text.Length < 3)
                return;

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;

            GetSatisRaporBos();

            divSuzme.Visible = false;

            ddlUrunAramaTedarikciler.SelectedIndex = 0;
            ddlUrunler.Items.Clear(); ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
            ddlUrunler.SelectedIndex = 0;
            ddlUrunAramaFiyatTipleri.SelectedIndex = 0;
            txtUrunArama.Text = string.Empty;
            lblUrunArama.Text = "Tümü (Tümü)";

            Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
            Calendar2.SelectedDate = DateTime.Now;

            tblToplam.Visible = false;

            lblRaporKacinci.Text = "0"; lblRaporSayisi.Text = "0";

            if (rbCariHesapAraMusteri.Checked)
            {
                ddlTemsilciler.Items.Clear();
                ddlTemsilciler.Items.Add(new ListItem("Seçiniz", "0"));
                CariHesaplar.GetGMREFSATTEMMUSTERIByMusteri(ddlCariHesaplar.Items, txtCariHesapAra.Text.Trim(), false);
            }
            else if (rbCariHesapAraSattem.Checked)
            {
                ddlCariHesaplar.Items.Clear();
                ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                SatisTemsilcileri.GetObjectsBySatisTemsilcisi(ddlTemsilciler.Items, txtCariHesapAra.Text.Trim(), false);
            }
        }

        protected void btnCariHesapTemizle_Click(object sender, EventArgs e)
        {
            //txtCariHesapAra.Text = string.Empty;
            //ddlCariHesaplarSubeler.Items.Clear();
            //ddlCariHesaplarSubeler.Visible = false;
            //ddlCariHesaplar.Items.Clear();
            //ddlCariHesaplar.SelectedIndex = -1;
            //GetSatisSefYoneticiHesaplar();
            //ddlCariHesaplar.SelectedIndex = 0;

            //DataList1.DataSource = null;
            //DataList1.DataBind();
        }

        protected void btnUrunAdiAra_Click(object sender, EventArgs e)
        {
            if (txtUrunArama.Text.Trim().Length > 2)
            {
                Urunler.GetProducts(ddlUrunler.Items, txtUrunArama.Text,
                    ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
                txtUrunArama.Text = string.Empty;
            }
            else if (txtUrunArama.Text.Trim() == string.Empty)
            {
                ddlUrunler.Items.Clear();
                ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
            }
        }

        protected void btnUrunArama_Click(object sender, EventArgs e)
        {
            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 1)
            //    if ((ddlCariHesaplar.SelectedIndex == 0 && ddlCariHesaplar.SelectedValue != "1")
            //        && !cbNSTTumSatislar.Checked)
            //        return;

            string ozelkod = string.Empty;
            if (ddlUrunAramaTedarikciler.SelectedIndex > 0)
                ozelkod = ddlUrunAramaTedarikciler.SelectedValue;
            string fiyattip = string.Empty;
            if (ddlUrunAramaFiyatTipleri.SelectedIndex > 0)
                fiyattip = ddlUrunAramaFiyatTipleri.SelectedValue;

            int baslangic = Convert.ToInt32(lblRaporKacinci.Text) + (int)Session["SatisRaporSayfaBasiGosterim"];
            if (cbNSTTumSatislar.Checked) // nst ler için bütün satış raporu
            {
                GetSatisRaporCount(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
            {
                GetSatisRaporCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplar.SelectedValue == "1") // slsref seçilmişse
            {
                GetSatisRaporCountBySLSREF((int)Session["SatisRaporGetirilecekSLSREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySLSREF((int)Session["SatisRaporGetirilecekSLSREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarBySLSREF((int)Session["SatisRaporGetirilecekSLSREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
            {
                GetSatisRaporCountByGMREF((int)Session["SatisRaporGetirilecekGMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarByGMREF((int)Session["SatisRaporGetirilecekGMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarByGMREF((int)Session["SatisRaporGetirilecekGMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }
            else
            {
                GetSatisRaporCountBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip);

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlarBySMREF((int)Session["SatisRaporGetirilecekSMREF"], ddlUrunler.Items, ddlUrunler.SelectedIndex, ozelkod, fiyattip, 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }
            }

            //if (baslangic > Convert.ToInt32(lblRaporSayisi.Text))
            //    lblRaporKacinci.Text = lblRaporSayisi.Text;
            //else
            //    lblRaporKacinci.Text = baslangic.ToString();

            Session["downloadyazdirsatisraporurunler"] = ddlUrunler.Items;
            Session["downloadyazdirsatisraporurunlerselectedindex"] = ddlUrunler.SelectedIndex;
            Session["downloadyazdirsatisraporozelkod"] = ozelkod;
            Session["downloadyazdirsatisraporfiyattip"] = fiyattip;
            Session["downloadyazdirsatisraporbedelsiz"] = cbBedelsizler.Checked;
            Session["downloadyazdirsatisraporiadeler"] = cbIadeler.Checked;
            Session["downloadyazdirsatisraportarih1"] = Calendar1.SelectedDate;
            Session["downloadyazdirsatisraportarih2"] = Calendar2.SelectedDate;
        }

        protected void cbNSTTumSatislar_CheckedChanged(object sender, EventArgs e)
        {
            divSuzme.Visible = !cbNSTTumSatislar.Checked;
            ddlTemsilciler.SelectedIndex = 0;
            ddlTemsilciler.Enabled = !cbNSTTumSatislar.Checked;
            ddlCariHesaplar.Items.Clear();
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
            ddlCariHesaplar.SelectedIndex = 0;
            ddlCariHesaplar.Enabled = !cbNSTTumSatislar.Checked;

            ddlUrunAramaTedarikciler.SelectedIndex = 0;
            ddlUrunler.Items.Clear(); ddlUrunler.Items.Add(new ListItem("Tümü", "0"));
            ddlUrunler.SelectedIndex = 0;
            ddlUrunAramaFiyatTipleri.SelectedIndex = 0;
            txtUrunArama.Text = string.Empty;
            lblUrunArama.Text = "Tümü (Tümü)";

            if (cbNSTTumSatislar.Checked)
            {
                GetSatisRaporCount(ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "");

                // son sayfaya git:
                if (Convert.ToInt32(lblRaporSayisi.Text) > (int)Session["SatisRaporSayfaBasiGosterim"])
                {
                    int raporsayisi = Convert.ToInt32(lblRaporSayisi.Text);
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", raporsayisi - (int)Session["SatisRaporSayfaBasiGosterim"], (int)Session["SatisRaporSayfaBasiGosterim"]);
                    lblRaporKacinci.Text = raporsayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }
                else
                {
                    GetSatisRaporlar(ddlUrunler.Items, ddlUrunler.SelectedIndex, "", "", 0, (int)Session["SatisRaporSayfaBasiGosterim"]);
                }

                divSuzme.Visible = true;
            }
            else
            {
                GetSatisRaporBos();
                tblToplam.Visible = false;
                ddlSayfa.Items.Clear();
                lblRaporKacinci.Text = "0"; lblRaporSayisi.Text = "0";
                divSuzme.Visible = false;
            }
        }

        protected void DataList1_DataBound(object sender, EventArgs e)
        {
            lblRaporYok.Visible = DataList1.Items.Count == 0;
        }
    }
}