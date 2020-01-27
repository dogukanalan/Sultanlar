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
    public partial class hesapayrinti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (((Musteriler)Session["Musteri"]).blSicakSatis) // merch ise
                Response.Redirect("yetkiyok.aspx", true);

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    Response.Redirect("yetkiyok.aspx", true);

                Calendar1.SelectedDate = Convert.ToDateTime("01.01.2000");
                Calendar2.SelectedDate = DateTime.Now.AddYears(1);

                Session["downloadyazdirekstretarih1"] = Calendar1.SelectedDate;
                Session["downloadyazdirekstretarih2"] = Calendar2.SelectedDate;
                Session["downloadyazdirekstrevgb"] = false;

                Session["EkstrelerSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intRaporSatirSayisi;

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 9) // müşteri ise veya bayi yöneticisi ise
                {
                    int satirsayisi = GetEkstrelerCountByGMREF(((Musteriler)Session["Musteri"]).intGMREF);
                    int baslangic = satirsayisi - (int)Session["EkstrelerSayfaBasiGosterim"];
                    if (baslangic < 0)
                        baslangic = 0;
                    else
                        lblEkstreKacinci.Text = Session["EkstrelerSayfaBasiGosterim"].ToString();

                    //ddlTemsilciler.Items.Add(new ListItem(SatisTemsilcileri.GetObjectBySLSREF(CariHesaplar.GetSLSREFBySMREF(((Musteriler)Session["Musteri"]).intGMREF))[1].ToString()));
                    divCariHesaplar.Visible = false;
                    GetEkstrelerByGMREF(((Musteriler)Session["Musteri"]).intGMREF, 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
                    GetToplamlar(((Musteriler)Session["Musteri"]).intGMREF);

                    // son sayfaya git:
                    if (satirsayisi > (int)Session["EkstrelerSayfaBasiGosterim"])
                    {
                        GetEkstrelerByGMREF(((Musteriler)Session["Musteri"]).intGMREF, satirsayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                        lblEkstreKacinci.Text = satirsayisi.ToString();
                        ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                    }

                    cbTumu.Visible = false;
                    ddlIsyerleri.Visible = false;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                {
                    hlBorcAlacak.Visible = (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) && !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8");
                    imgBorcAlacak.Visible = (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) && !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8");
                    hlSatisHedef.Visible = true;
                    imgSatisHedef.Visible = true;
                    //hlSatistaOnAdim.Visible = true;
                    hlStok.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6;
                    imgStok.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6;
                    GetSatisSefYoneticiHesaplar();

                    lblEkstreYok.Visible = true;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    hlBorcAlacak.Visible = true;
                    imgBorcAlacak.Visible = true;
                    hlSatisHedef.Visible = true;
                    imgSatisHedef.Visible = true;
                    //hlSatistaOnAdim.Visible = true;
                    hlStok.Visible = true;
                    imgStok.Visible = true;

                    SatisTemsilcileri.GetObjectsFromCariHesaplar(ddlTemsilciler.Items);
                    ArrayList slsrefs = new ArrayList();
                    slsrefs.Add(ddlTemsilciler.SelectedValue);
                    divCariHesapArama.Visible = true;
                    ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                    CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);

                    lblEkstreYok.Visible = true;

                    //SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                    //divCariHesapArama.Visible = true;
                    //ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                }

                string isyeri = ddlIsyerleri.SelectedValue;
                Session["downloadyazdirekstreisyeri"] = isyeri;
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGosterSade\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(upHesapAyrintilari, typeof(string), "kucukbilgi", alert, false);
        }

        private void GetSatisSefYoneticiHesaplar()
        {
            divCariHesaplar.Visible = true;

            ArrayList altlar = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
            {
                altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            {
                altlar = SatisTemsilcileri.GetSLSREFsFromCariHesaplar();
                divCariHesapArama.Visible = true;
            }
            //Session["SefSLSREFs"] = altlar;

            if (altlar.Count == 0)  // şef değil ise
            {
                /*SAP*/
                ArrayList st = SatisTemsilcileri.GetObjectBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                if (st.Count > 0)
                    ddlTemsilciler.Items.Add(new ListItem(st[1].ToString(), ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                else
                    ddlTemsilciler.Items.Add(new ListItem("-", ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));

                CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, false, true, true);

                ArrayList anacarigmrefler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                for (int i = 0; i < anacarigmrefler.Count; i++)
                {
                    DataTable dtAna = new DataTable();
                    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacarigmrefler[i]), true);

                    ListItem lst = new ListItem();
                    lst.Text = ".G - " + dtAna.Rows[0][1].ToString() + " - " + dtAna.Rows[0][2].ToString();
                    lst.Value = dtAna.Rows[0][2].ToString().Substring(0, 3) + dtAna.Rows[0][0].ToString();
                    ddlCariHesaplar.Items.Add(lst);
                }
            }
            else // şef ise
            {
                //// grup şirketi ve tek şubelileri ayırarak getirmek için vardı:
                //// <<
                //for (int i = 0; i < altlar.Count; i++)
                //{
                //    CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, Convert.ToInt32(altlar[i]), true, false, true);
                //    CariHesaplar.GetAnaCarilerGMREFBySLSREF(anacarigmrefler, Convert.ToInt32(altlar[i]));
                //}

                //for (int i = 0; i < anacarigmrefler.Count; i++)
                //{
                //    DataTable dtAna = new DataTable();
                //    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacarigmrefler[i]), true, true);

                //    ListItem lst = new ListItem();
                //    lst.Text = ".G - " + dtAna.Rows[0][2].ToString();
                //    lst.Value = dtAna.Rows[0][0].ToString();
                //    ddlCariHesaplar.Items.Add(lst);
                //}
                //// >>

                SatisTemsilcileri.GetObjectsBySLSREFs(ddlTemsilciler.Items, altlar, true);

                // yeni sistem, grup şirketi ve tek şubeliler biryerde:
                // <<
                if (Session["SefMusteriListesi"] == null)
                {
                    ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));

                    ////eski
                    //// <<
                    //ArrayList anacarigmrefler = new ArrayList();
                    //ArrayList anacarigmrefslsrefler = new ArrayList();

                    //for (int i = 0; i < altlar.Count; i++)
                    //{
                    //    int kactanegeldi = CariHesaplar.GetGMREFsBySLSREF(anacarigmrefler, Convert.ToInt32(altlar[i]));
                    //    for (int j = 0; j < kactanegeldi; j++)
                    //    {
                    //        anacarigmrefslsrefler.Add(altlar[i]);
                    //    }
                    //}

                    //for (int i = 0; i < anacarigmrefler.Count; i++)
                    //{
                    //    DataTable dtAna = new DataTable();
                    //    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacarigmrefler[i]), Convert.ToInt32(anacarigmrefslsrefler[i]), true, true);
                    //    ddlCariHesaplar.Items.Add(new ListItem(dtAna.Rows[0][2].ToString(), dtAna.Rows[0][0].ToString()));
                    //}
                    //// >>

                    CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, altlar);

                    Session["SefMusteriListesi"] = ddlCariHesaplar.Items;
                }
                else
                {
                    for (int i = 0; i < ((ListItemCollection)Session["SefMusteriListesi"]).Count; i++) // seçiniz varsada tekrar eklemiyor
                        ddlCariHesaplar.Items.Add(((ListItemCollection)Session["SefMusteriListesi"])[i]);
                }
                // >>
            }
        }

        private void GetToplamlar(int GMREF)
        {
            short isyeri = 0;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
                isyeri = -1;
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                isyeri = Convert.ToInt16(ddlIsyerleri.SelectedValue);
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                isyeri = Convert.ToInt16(ddlIsyerleri.SelectedValue);

            ArrayList toplamlar = Ekstreler.GetToplamFiyatlar(GMREF, isyeri, Calendar1.SelectedDate, Calendar2.SelectedDate, cbVGB.Checked);
            lblToplamBorc.Text = ((decimal)toplamlar[0]).ToString("C2");
            lblToplamAlacak.Text = ((decimal)toplamlar[1]).ToString("C2");
            lblToplamBakiye.Text = ((decimal)toplamlar[2]).ToString("C2");
            //lblToplamVGB.Text = ((decimal)toplamlar[3]).ToString("C2");
            lblToplamOrtVade.Text = (decimal)toplamlar[2] < 0 ? DateTime.Now.AddDays(Convert.ToInt32(Math.Floor((double)toplamlar[4]))).ToShortDateString() : "<i>Bakiye sıfırdan büyük</i>";
        }

        private int GetEkstrelerCountByGMREF(int GMREF)
        {
            int donendeger = Ekstreler.GetObjectsCountByGMREF(GMREF, -1, Calendar1.SelectedDate, Calendar2.SelectedDate, cbVGB.Checked, ddlIsyerleri.SelectedValue);



            ddlSayfa.Items.Clear();
            int sayfasayisi = 0;
            int kalan = donendeger % (int)Session["EkstrelerSayfaBasiGosterim"];
            double sayfasayi = Convert.ToDouble(donendeger) / (int)Session["EkstrelerSayfaBasiGosterim"];
            if (kalan == 0)
            {
                sayfasayisi = Convert.ToInt32(sayfasayi);
            }
            else
            {
                if (kalan * 2 >= (int)Session["EkstrelerSayfaBasiGosterim"])
                    sayfasayisi = Convert.ToInt32(sayfasayi);
                else
                    sayfasayisi = Convert.ToInt32(sayfasayi) + 1;
            }
            for (int i = 1; i <= sayfasayisi; i++)
                ddlSayfa.Items.Add(new ListItem(i.ToString(), (i * (int)Session["EkstrelerSayfaBasiGosterim"]).ToString()));



            tblToplam.Visible = Convert.ToBoolean(donendeger > 0);

            if (donendeger > 0)
                lblEkstreKacinci.Text = Session["EkstrelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["EkstrelerSayfaBasiGosterim"])
                lblEkstreKacinci.Text = donendeger.ToString();

            lblEkstreSayisi.Text = donendeger.ToString();
            return donendeger;
        }

        private void GetEkstrelerByGMREF(int GMREF, int Baslangic, int Adet)
        {
            Session["EkstreGetirilecekGMREF"] = GMREF;

            DataTable dt = new DataTable();
            Ekstreler.GetObjectsByGMREF(dt, GMREF, Baslangic, Adet, -1, Calendar1.SelectedDate, Calendar2.SelectedDate, cbVGB.Checked, ddlIsyerleri.SelectedValue);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCariHesaplar.Items.Clear();
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));

            ArrayList slsrefs = new ArrayList();

            if (ddlTemsilciler.SelectedValue == "1")
            {
                for (int i = 2; i < ddlTemsilciler.Items.Count; i++)
                    slsrefs.Add(Convert.ToInt32(ddlTemsilciler.Items[i].Value));

                CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);
            }
            else
            {
                slsrefs.Add(ddlTemsilciler.SelectedValue);
                CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);
            }

            Calendar1.SelectedDate = Convert.ToDateTime("01.01.2012");
            Calendar2.SelectedDate = DateTime.Now.AddYears(1);

            tblToplam.Visible = false;
            DataList1.DataSource = null;
            DataList1.DataBind();
            ddlSayfa.Items.Clear();
            lblEkstreKacinci.Text = "0"; lblEkstreSayisi.Text = "0";

            lblEkstreYok.Visible = true;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEkstreKacinci.Text = "0"; lblEkstreSayisi.Text = "0";

            Calendar1.SelectedDate = Convert.ToDateTime("01.01.2012");
            Calendar2.SelectedDate = DateTime.Now.AddYears(1);

            if (ddlCariHesaplar.SelectedValue != "0")
            {
                GetEkstrelerCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                GetEkstrelerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
                GetToplamlar(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                // son sayfaya git:
                if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
                {
                    int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
                    GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                    lblEkstreKacinci.Text = ekstresayisi.ToString();

                    ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                }

                Session["downloadyazdirekstretarih1"] = Calendar1.SelectedDate;
                Session["downloadyazdirekstretarih2"] = Calendar2.SelectedDate;
            }
            else
            {
                tblToplam.Visible = false;
                DataList1.DataSource = null;
                DataList1.DataBind();
                ddlSayfa.Items.Clear();

                lblEkstreYok.Visible = true;
            }
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblEkstreKacinci.Text) - (int)Session["EkstrelerSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["EkstrelerSayfaBasiGosterim"] < baslangic)
                {
                    GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], baslangic - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                    lblEkstreKacinci.Text = baslangic.ToString();
                }
                else
                {
                    GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
                    lblEkstreKacinci.Text = Session["EkstrelerSayfaBasiGosterim"].ToString();
                }

                ddlSayfa.SelectedIndex = ddlSayfa.SelectedIndex - 1;
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblEkstreKacinci.Text) + (int)Session["EkstrelerSayfaBasiGosterim"];
            if (Convert.ToInt32(lblEkstreKacinci.Text) < Convert.ToInt32(lblEkstreSayisi.Text))
            {
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], baslangic - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);

                if (baslangic > Convert.ToInt32(lblEkstreSayisi.Text))
                    lblEkstreKacinci.Text = lblEkstreSayisi.Text;
                else
                    lblEkstreKacinci.Text = baslangic.ToString();

                ddlSayfa.SelectedIndex = ddlSayfa.SelectedIndex + 1;
            }
        }

        protected void ibIlk_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
            {
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
                lblEkstreKacinci.Text = Session["EkstrelerSayfaBasiGosterim"].ToString();

                ddlSayfa.SelectedIndex = 0;
            }
        }

        protected void ibSon_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
            {
                int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                lblEkstreKacinci.Text = ekstresayisi.ToString();

                ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
            }
        }

        protected void ibYazdir_Click(object sender, ImageClickEventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                Session["EkstreYazdirGMREF"] = ((Musteriler)Session["Musteri"]).intGMREF;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 || 
                      ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yönetici ise
            {
                if (ddlCariHesaplar.SelectedIndex > 0)
                {
                    Session["EkstreYazdirGMREF"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                }
            }
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                Session["downloadekstregmref"] = ((Musteriler)Session["Musteri"]).intGMREF;
                divEkstreKaydet.Visible = true;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 ||
                      ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yönetici ise
            {
                if (ddlCariHesaplar.SelectedIndex > 0)
                {
                    Session["downloadekstregmref"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                    divEkstreKaydet.Visible = true;
                }
            }
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
            Session["downloadyazdirekstretarih1"] = Calendar1.SelectedDate;
            Session["downloadyazdirekstretarih2"] = Calendar2.SelectedDate;

            if (ddlCariHesaplar.SelectedIndex > -1)
            {
                if (ddlCariHesaplar.SelectedValue != "0")
                {
                    GetEkstrelerCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    GetEkstrelerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
                    GetToplamlar(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                    // son sayfaya git:
                    if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
                    {
                        int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
                        GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                        lblEkstreKacinci.Text = ekstresayisi.ToString();

                        ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
                    }
                }
            }

            divTarih.Visible = false;
        }

        protected void lbEkstreKaydetKapat_Click(object sender, EventArgs e)
        {
            divEkstreKaydet.Visible = false;
            Session["downloadekstregmref"] = null;
        }

        protected void ddlSayfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSayfa.SelectedIndex == ddlSayfa.Items.Count - 1)
                lblEkstreKacinci.Text = lblEkstreSayisi.Text;
            else
                lblEkstreKacinci.Text = ddlSayfa.SelectedValue;

            GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], Convert.ToInt32(ddlSayfa.SelectedValue) - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
        }

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty)
                return;

            tblToplam.Visible = false;
            DataList1.DataSource = null;
            DataList1.DataBind();

            ddlSayfa.Items.Clear();
            lblEkstreKacinci.Text = "0"; lblEkstreSayisi.Text = "0";

            if (rbCariHesapAraMusteri.Checked)
            {
                ddlTemsilciler.Items.Clear();
                ddlTemsilciler.Items.Add(new ListItem("Seçiniz", "0"));
                CariHesaplar.GetGMREFSATTEMMUSTERIByMusteri(ddlCariHesaplar.Items, txtCariHesapAra.Text.Trim(), true);
                ddlCariHesaplar.Items.RemoveAt(1); // tümünü kaldırmak için
            }
            else if (rbCariHesapAraSattem.Checked)
            {
                ddlCariHesaplar.Items.Clear();
                ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                SatisTemsilcileri.GetObjectsBySatisTemsilcisi(ddlTemsilciler.Items, txtCariHesapAra.Text.Trim(), false);
            }

            //if (ddlCariHesaplar.Items.Count > 0) // ilk hesapların ekstresini getir
            //{
            //    ddlCariHesaplar.SelectedIndex = 0;
            //    GetEkstrelerCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
            //    GetEkstrelerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
            //    GetToplamlar(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

            //    // son sayfaya git:
            //    if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
            //    {
            //        int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
            //        GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
            //        lblEkstreKacinci.Text = ekstresayisi.ToString();
            //    }
            //}
        }

        protected void btnCariHesapTemizle_Click(object sender, EventArgs e)
        {
            divCariHesapArama.Visible = true;
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));

            //txtCariHesapAra.Text = string.Empty;
            //ddlCariHesaplar.Items.Clear();
            //ddlCariHesaplar.SelectedIndex = -1;
            //GetSatisSefYoneticiHesaplar();
            //ddlCariHesaplar.SelectedIndex = 0;

            //tblToplam.Visible = false;
            //DataList1.DataSource = null;
            //DataList1.DataBind();
        }

        protected void lbSatisRapor_Click(object sender, EventArgs e)
        {
            lblToplamBrut.Text = 0.ToString("C3");
            lblToplamIskonto.Text = 0.ToString("C3");
            lblToplamNet.Text = 0.ToString("C3");
            lblToplamNETKDV.Text = 0.ToString("C3");

            lblFaturaNo.Text = ((LinkButton)sender).CommandArgument + " Nolu Fatura İçeriği";

            DataTable dt = new DataTable();
            int satirsayisi = SatisRapor.GetObjectCountByFisNo(((LinkButton)sender).CommandArgument, "", "");
            lblRaporSayisi.Text = satirsayisi.ToString();
            SatisRapor.GetObjectsByFisNo(dt, ((LinkButton)sender).CommandArgument, "", "");
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarByFisNo(((LinkButton)sender).CommandArgument, "", "");

            bool yetkisiz = false;
            if (((UyeYetkileri)Session["Yetkiler"]).OzelKodlar.Count > 0)
            {
                yetkisiz = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar.Count; j++)
                    {
                        if (dt.Rows[i]["GRP KOD"].ToString() == ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar[j].ToString())
                        {
                            yetkisiz = false;
                            break;
                        }
                    }

                    if (!yetkisiz)
                        break;
                }
            }

            if (yetkisiz)
            {
                divSatisRaporHata.Visible = true;

                string alert1 = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divSatisRaporHata, typeof(string), "scriptSayfayukaricikar", alert1, false);

                return;
            }

            divSatisRapor.Visible = true;
            DataList2.DataSource = dt;
            DataList2.DataBind();
            if (satirsayisi > 0)
            {
                tblToplamlar.Visible = true;
                lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C3");
                lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C3");
                lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C3");
                lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C3");
            }

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSatisRapor, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSatisRaporKapat_Click(object sender, EventArgs e)
        {
            divSatisRapor.Visible = false;
        }

        protected void lbSatisRaporHataKapat_Click(object sender, EventArgs e)
        {
            divSatisRaporHata.Visible = false;
        }

        protected void cbVGB_CheckedChanged(object sender, EventArgs e)
        {
            if (Session["EkstreGetirilecekGMREF"] == null)
                return;

            Session["downloadyazdirekstrevgb"] = cbVGB.Checked;
            GetEkstrelerCountByGMREF((int)Session["EkstreGetirilecekGMREF"]);
            GetToplamlar((int)Session["EkstreGetirilecekGMREF"]);

            // son sayfaya git:
            if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
            {
                int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                lblEkstreKacinci.Text = ekstresayisi.ToString();

                ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
            }
            else
            {
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
            }
        }

        protected void cbTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (Session["EkstreGetirilecekGMREF"] == null)
                return;

            string isyeri = ddlIsyerleri.SelectedValue;

            Session["downloadyazdirekstreisyeri"] = isyeri;
            GetEkstrelerCountByGMREF((int)Session["EkstreGetirilecekGMREF"]);
            GetToplamlar((int)Session["EkstreGetirilecekGMREF"]);

            // son sayfaya git:
            if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
            {
                int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                lblEkstreKacinci.Text = ekstresayisi.ToString();

                ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
            }
            else
            {
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
            }
        }

        protected void DataList1_DataBound(object sender, EventArgs e)
        {
            lblEkstreYok.Visible = DataList1.Items.Count == 0;
        }

        protected void ddlIsyerleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["EkstreGetirilecekGMREF"] == null)
                return;

            string isyeri = ddlIsyerleri.SelectedValue;

            Session["downloadyazdirekstreisyeri"] = isyeri;
            GetEkstrelerCountByGMREF((int)Session["EkstreGetirilecekGMREF"]);
            GetToplamlar((int)Session["EkstreGetirilecekGMREF"]);

            // son sayfaya git:
            if (Convert.ToInt32(lblEkstreSayisi.Text) > (int)Session["EkstrelerSayfaBasiGosterim"])
            {
                int ekstresayisi = Convert.ToInt32(lblEkstreSayisi.Text);
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], ekstresayisi - (int)Session["EkstrelerSayfaBasiGosterim"], (int)Session["EkstrelerSayfaBasiGosterim"]);
                lblEkstreKacinci.Text = ekstresayisi.ToString();

                ddlSayfa.SelectedIndex = ddlSayfa.Items.Count - 1;
            }
            else
            {
                GetEkstrelerByGMREF((int)Session["EkstreGetirilecekGMREF"], 0, (int)Session["EkstrelerSayfaBasiGosterim"]);
            }
        }
    }
}