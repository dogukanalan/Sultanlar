using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    /// <summary>
    /// ListItemCollection larda value nun başına text in ilk 3 hanesi GELİYOR ddltemsilciler hariç
    /// </summary>
    public partial class siparisler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (((Musteriler)Session["Musteri"]).blSicakSatis) // merch ise
                Response.Redirect("yetkiyok.aspx", true);

            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                //cbSicakSatis.Visible = ((Musteriler)Session["Musteri"]).blSicakSatis;

                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
                lblTarihSecim1.Text = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString()).ToShortDateString();
                lblTarihSecim2.Text = DateTime.Now.AddDays(1).ToShortDateString();

                int sonyarimsiparis = ((Musteriler)Session["Musteri"]).intSonYarimSiparisID;
                if (sonyarimsiparis > 0)
                {
                    Siparisler siparis = Siparisler.GetObjectsBySiparisID(((Musteriler)Session["Musteri"]).intSonYarimSiparisID);
                    if (siparis == null)
                    {
                        ((Musteriler)Session["Musteri"]).intSonYarimSiparisID = 0;
                        ((Musteriler)Session["Musteri"]).DoUpdate();
                        Response.Redirect("hata.htm", true);
                    }

                    Session["SiparisID"] = siparis.pkSiparisID;
                    Session["SMREF"] = siparis.SMREF;
                    Session["FiyatTipi"] = siparis.sintFiyatTipiID;
                    Response.Redirect("siparis.aspx", true);
                }

                Session["SiparislerSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intSiparisSatirSayisi;

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1 && ((Musteriler)Session["Musteri"]).blSicakSatis) 
                {
                    Calendar1.SelectedDate = Convert.ToDateTime("01.01.2012");
                    divHesapSecim.Visible = false;
                    //divSiparisVer.Visible = true;
                    GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["SiparislerSayfaBasiGosterim"]);


                    divTopluIslemlerTus.Visible = false;


                    if (Session["SiparisTamamlaOnaylaBasildi"] != null)
                    {
                        Siparisler siparis = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(Session["OnaylanacakSiparisID"]));

                        divSevkYerleri.Visible = true;
                        tblSevk.Visible = false;
                        tblAdresler.Visible = true;

                        //GetAdresler();

                        if (!Odemeler.GetSiparisOdemeYapildiMi(siparis.pkSiparisID)) // ödeme yapılmış sipariş ise ödeme ekranı açılmayacak
                        {
                            Session["OdemeSiparisNo"] = siparis.pkSiparisID;
                            Session["OdemeTutari"] = siparis.mnToplamTutar;
                            Session["OdemeGMREF"] = siparis.SMREF;
                            divOdeme.Visible = true;
                        }
                    }
                    
                    string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>"; ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "kucukbilgi", alert, false);
                    return;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
                {
                    lblVadeBaslik.Visible = false;
                }

                GetCariHesaplar();

                if (Session["SiparisTamamlaBasildi"] != null)
                {
                    Session["SiparisGetirilecekSMREF"] = Session["SiparisTamamlaBasildi"];
                    //SelectCariHesap();
                    Session["SiparisTamamlaBasildi"] = null;

                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
                    {
                        Session["OnaylanacakSiparisID"] = Session["SiparisTamamlaBasildiSiparisID"];
                        divAyniMusteriyeSiparis.Visible = true;
                    }
                }
                else if (Session["SiparisTamamlaOnaylaBasildi"] != null)
                {
                    //SelectCariHesap();

                    divSevkYerleri.Visible = true;

                    Siparisler sip = Siparisler.GetObjectsBySiparisID((int)Session["OnaylanacakSiparisID"]);
                    int SLSREFkontrol = CariHesaplar.GetSLSREFBySMREF(sip.SMREF);
                    Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(sip.intMusteriID);
                    if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
                        SLSREFkontrol = siparisiolusturanmusteri1.intSLSREF;

                    bool bakiye = WebMusteriEk.GetBakiye(sip.SMREF, SLSREFkontrol);
                    //spanBakiyeSiparis.Visible = bakiye;
                    //cbBakiyeSiparis.Visible = bakiye;
                    cbBakiyeSiparis.Checked = bakiye;

                    if (((Musteriler)Session["Musteri"]).tintIlID != 34) // istanbul dışı müşteri ise
                    {
                        Session["SiparisTamamlaOnaylaBasildi"] = null;
                        tblSevk.Visible = false;
                        tblDepolar.Visible = true;
                        GetDepolar(((Musteriler)Session["Musteri"]).tintIlID);
                        return;
                    }

                    GetSevkYerleri((int)Session["SiparisTamamlaOnaylaBasildi"]);

                    Session["SiparisTamamlaOnaylaBasildi"] = null;
                }
                
                //SayfaToplami();
            }

            string alert1 = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "kucukbilgi", alert1, false);

            inputTopluIslemGosterGizle.Value = "kapali";
        }

        private void GetCariHesaplar()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
            {
                GetSatisSefYoneticiHesaplar();
                //hlSatistaOnAdim.Visible = true;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi
            {
                /*SAP*/
                ArrayList st = SatisTemsilcileri.GetObjectBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                if (st.Count > 0)
                    ddlTemsilciler.Items.Add(new ListItem(st[1].ToString(), ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                else
                    ddlTemsilciler.Items.Add(new ListItem("-", ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));

                CariHesaplarTP.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true);

                ddlCariHesaplar.SelectedIndex = 1;
                GetSiparisCountBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                GetSiparislerBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                //hlSatistaOnAdim.Visible = true;

                SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, true);
                ddlTemsilciler.SelectedIndex = 1;

                divCariHesapArama.Visible = true;
                ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));
                ddlCariHesaplar.SelectedIndex = 1;

                GetSiparisCount();
                GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                ddlTemsilciler.Enabled = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 1;
                btnExceldenSiparis.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 1;
                int gmref = ((Musteriler)Session["Musteri"]).intGMREF;
                Session["SiparisGetirilecekSMREF"] = gmref;

                if (CariHesaplar.AnaSubeMi(((Musteriler)Session["Musteri"]).intGMREF))
                    CariHesaplar.GetSatTemsByGMREF(ddlTemsilciler.Items, ((Musteriler)Session["Musteri"]).intGMREF);
                else
                    CariHesaplar.GetSatTemsBySMREF(ddlTemsilciler.Items, ((Musteriler)Session["Musteri"]).intGMREF);

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
                    ddlCariHesaplarSubeler.Visible = false;
                    ListItem lst = new ListItem();
                    lst.Text = CariHesaplar.GetObjectByGMREF(gmref)[1].ToString();
                    lst.Value = gmref.ToString();
                    ddlCariHesaplar.Items.Add(lst);

                    GetSiparisCountBySMREF(gmref);
                    GetSiparislerBySMREF(gmref, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
        }

        private void GetSatisSefYoneticiHesaplar()
        {
            ArrayList altlar = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
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

                ddlCariHesaplar.SelectedValue = "1";
                ddlCariHesaplarSubeler.Visible = false;
                GetSiparisCountBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                GetSiparislerBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else // şef ise
            {
                SatisTemsilcileri.GetObjectsBySLSREFs(ddlTemsilciler.Items, altlar, true);

                // hesapayrinti.aspx in aynısı
                if (Session["SefMusteriListesi"] == null)
                {
                    ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                    ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                    CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, altlar);

                    ListItemCollection lic = new ListItemCollection();
                    lic.Add(new ListItem("Seçiniz", "0"));
                    CariHesaplar.GetObjectsBySLSREFs(lic, altlar);
                    Session["SefMusteriListesi"] = lic;
                }
                else
                {
                    ddlCariHesaplar.Items.Add(((ListItemCollection)Session["SefMusteriListesi"])[0]); // seçiniz
                    ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                    for (int i = 1; i < ((ListItemCollection)Session["SefMusteriListesi"]).Count; i++)
                        ddlCariHesaplar.Items.Add(((ListItemCollection)Session["SefMusteriListesi"])[i]);
                }

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise tümü seçili gelsin, smrefs siz tümü geliyor hızlı
                {
                    ddlCariHesaplar.SelectedValue = "1";
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
        }

        //private void SelectCariHesap()
        //{
        //    int gmref = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Session["SiparisGetirilecekSMREF"]));

        //    if (gmref > 0)
        //    {
        //        for (int i = 0; i < ddlCariHesaplar.Items.Count; i++)
        //        {
        //            if (ddlCariHesaplar.Items[i].Value == gmref.ToString())
        //            {
        //                ddlCariHesaplar.SelectedIndex = i;
        //                for (int j = 0; j < ddlCariHesaplarSubeler.Items.Count; j++)
        //                {
        //                    if (ddlCariHesaplarSubeler.Items[j].Value == Session["SiparisGetirilecekSMREF"].ToString())
        //                    {
        //                        ddlCariHesaplarSubeler.SelectedIndex = j;
        //                        break;
        //                    }
        //                }
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < ddlCariHesaplar.Items.Count; i++)
        //        {
        //            if (ddlCariHesaplar.Items[i].Value == Session["SiparisGetirilecekSMREF"].ToString())
        //            {
        //                ddlCariHesaplar.SelectedIndex = i;
        //                break;
        //            }
        //        }
        //    }

        //    GetSiparisCountBySMREF(Convert.ToInt32(Session["SiparisGetirilecekSMREF"]));
        //    DataTable dt = new DataTable();
        //    Siparisler.GetObjectsBySMREF(dt, Convert.ToInt32(Session["SiparisGetirilecekSMREF"]), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //    dlSiparisler.DataSource = dt;
        //    dlSiparisler.DataBind();
        //}

        private void GetSiparislerBos()
        {
            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();
        }

        #region BySMREF
        private int GetSiparisCountBySMREF(int SMREF)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            int donendeger = 0;
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)).StartsWith("8"))
            {
                int MusteriID = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                donendeger = Siparisler.GetSiparisCountBySMREFMusteriID(SMREF, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFMusteriID(SMREF, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }
            else
            {
                donendeger = Siparisler.GetSiparisCountBySMREF(SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREF(SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySMREF(int SMREF, int Baslangic, int Adet)
        {
            Session["SiparisGetirilecekSMREF"] = SMREF;

            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)).StartsWith("8"))
            {
                int MusteriID = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                Siparisler.GetObjectsBySMREFMusteriID(dt, SMREF, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }
            else
            {
                Siparisler.GetObjectsBySMREF(dt, SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }

            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();
        }
        #endregion

        #region ByGMREF
        // parametre ile gelen GMREF fuzuli çünkü smref leri ddlcarihesapsubeler den alıyoruz
        private int GetSiparisCountByGMREF(int GMREF)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            //DataTable dt = new DataTable();
            //CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            //int donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs);
            int donendeger = 0;
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)).StartsWith("8"))
            {
                int MusteriID = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                donendeger = Siparisler.GetSiparisCountBySMREFsMusteriID(SMREFs, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFsMusteriID(SMREFs, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }
            else
            {
                donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerByGMREF(int GMREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            //DataTable dt = new DataTable();
            //CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            DataTable dtSiparisler = new DataTable();
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)).StartsWith("8"))
            {
                int MusteriID = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                Siparisler.GetObjectsBySMREFsMusteriID(dtSiparisler, SMREFs, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }
            else
            {
                Siparisler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region BySLSREF
        private int GetSiparisCountBySLSREF(int SLSREF)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi veya yönetici ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);

            int donendeger = 0;
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)).StartsWith("8"))
            {
                int MusteriID = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                donendeger = Siparisler.GetSiparisCountBySMREFsMusteriID(SMREFs, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFsMusteriID(SMREFs, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }
            else
            {
                donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySLSREF(int SLSREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi veya yönetici ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);

            DataTable dtSiparisler = new DataTable();
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)).StartsWith("8"))
            {
                int MusteriID = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                Siparisler.GetObjectsBySMREFsMusteriID(dtSiparisler, SMREFs, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }
            else
            {
                Siparisler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region BySLSREFs
        private int GetSiparisCountBySLSREFs(int SLSREF)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            ArrayList SMREFs = new ArrayList();
            CariHesaplar.GetSMREFsBySLSREFs(SMREFs, slsrefs);

            int donendeger = 0;
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8")) // buraya gelmişse tümü seçilmiştir o yüzden üyenin slsrefine bakacağız
            {
                ArrayList musteriids = Musteriler.GetMusteriIDsBySLSREFs(slsrefs);
                donendeger = Siparisler.GetSiparisCountBySMREFsMusteriIDs(SMREFs, musteriids, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFsMusteriIDs(SMREFs, musteriids, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }
            else
            {
                donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySLSREFs(int SLSREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            ArrayList SMREFs = new ArrayList();
            CariHesaplar.GetSMREFsBySLSREFs(SMREFs, slsrefs);

            DataTable dtSiparisler = new DataTable();
            if (SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"))
            {
                ArrayList musteriids = Musteriler.GetMusteriIDsBySLSREFs(slsrefs);
                Siparisler.GetObjectsBySMREFsMusteriIDs(dtSiparisler, SMREFs, musteriids, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }
            else
            {
                Siparisler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region ByMusteriID
        private int GetSiparisCountByMusteriID(int MusteriID)
        {
            //int donendeger = Siparisler.GetSiparisCountByMusteriID(MusteriID);

            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            int donendeger = Siparisler.GetSiparisCountByMusteriID(MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

            if (donendeger > 0)
                lblDipToplam.Text = Siparisler.GetSiparislerToplamByMusteriID(MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
            else
                lblDipToplam.Text = 0.ToString("C3");

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerByMusteriID(int MusteriID, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            //Siparisler.GetObjectsByMusteriID(dt, MusteriID, Baslangic, Adet);
            Siparisler.GetObjectsByMusteriID(dt, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();
        }
        #endregion
        
        #region All
        private int GetSiparisCount()
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            int donendeger = 0;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise hepsi gelsin, smref lere göre getirmeye gerek yok
            {
                donendeger = Siparisler.GetSiparisCount(Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli, rbCariHesapUye.Checked ? txtCariHesapAra.Text : "");
                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplam(Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }
            else
            {
                if (Session["SatTemSMREFs"] == null)
                {
                    ArrayList SMREFs = new ArrayList();

                    //for (int j = 2; j < ddlCariHesaplar.Items.Count; j++) // seçiniz ve tümü hariç
                    //{
                    //    int GMREF = Convert.ToInt32(ddlCariHesaplar.Items[j].Value);

                    //    DataTable dt = new DataTable();
                    //    CariHesaplar.GetSubeler(dt, GMREF);
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //        SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
                    //}
                    // yeni yöntem:
                    SMREFs = CariHesaplar.GetSMREFsByGMREFs(ddlCariHesaplar.Items);

                    Session["SatTemSMREFs"] = SMREFs;
                }

                donendeger = Siparisler.GetSiparisCountBySMREFs((ArrayList)Session["SatTemSMREFs"], Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

                if (donendeger > 0)
                    lblDipToplam.Text = Siparisler.GetSiparislerToplamBySMREFs((ArrayList)Session["SatTemSMREFs"], Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli).ToString("C3");
                else
                    lblDipToplam.Text = 0.ToString("C3");
            }

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparisler(int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            DataTable dtSiparisler = new DataTable();

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise hepsi gelsin, smref lere göre getirmeye gerek yok
            {
                Siparisler.GetObjects(dtSiparisler, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli, rbCariHesapUye.Checked ? txtCariHesapAra.Text : "");
            }
            else
            {
                if (Session["SatTemSMREFs"] == null)
                {
                    ArrayList SMREFs = new ArrayList();

                    //for (int j = 2; j < ddlCariHesaplar.Items.Count; j++) // seçiniz ve tümü hariç
                    //{
                    //    int GMREF = Convert.ToInt32(ddlCariHesaplar.Items[j].Value);

                    //    DataTable dt = new DataTable();
                    //    CariHesaplar.GetSubeler(dt, GMREF);
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //        SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
                    //}
                    // yeni yöntem:
                    SMREFs = CariHesaplar.GetSMREFsByGMREFs(ddlCariHesaplar.Items);

                    Session["SatTemSMREFs"] = SMREFs;
                }

                Siparisler.GetObjectsBySMREFs(dtSiparisler, (ArrayList)Session["SatTemSMREFs"], Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }
            
            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion
        
        private void GetFiyatTipleri()
        {
            ddlFiyatTipleri.Items.Clear();
            ddlFiyatTipleri.Items.Add("Seçiniz");
            ddlFiyatTipleri.Items[0].Value = "0";

            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]);
                string fiyattipi = FiyatTipleri.GetObjectByID(fiyattipiid);

                ddlFiyatTipleri.Items.Add(fiyattipi);
                ddlFiyatTipleri.Items[i + 1].Value = fiyattipiid.ToString();
            }
            
            if (ddlFiyatTipleri.Items.Count == 2)
            {
                Session["SiparisID"] = 0;
                Session["SMREF"] = 0;
                Session["FiyatTipi"] = Convert.ToInt32(ddlFiyatTipleri.Items[1].Value);
                Response.Redirect("siparis.aspx", true);
            }
        }

        private int GetSiparisOrtVade(Siparisler Siparis)
        {
            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, Siparis.pkSiparisID);
            decimal vadetoplam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), Siparis.sintFiyatTipiID);
                vadetoplam += Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * vade;
            }
            decimal siparistoplam = Siparis.mnToplamTutar != 0 ? Siparis.mnToplamTutar : 1;
            return Convert.ToInt32(Math.Round(vadetoplam / siparistoplam));
        }
        
        private int GetSiparisOrtVade(SiparisListe Siparisliste)
        {
            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, Siparisliste._SiparisID);
            decimal vadetoplam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), Siparisliste._FiyatTipi);
                vadetoplam += Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * vade;
            }

            if (Siparisliste.ToplamTutar == 0)
                return 0;
            return Convert.ToInt32(Math.Round(vadetoplam / Siparisliste.ToplamTutar));
        }

        private void GetSevkYerleri(int SMREF)
        {
            SevkYerleri.GetObjectsBySMREF(rblSevkYerleri.Items, SMREF);
            rblSevkYerleri.SelectedIndex = 0;

            int GMREF = CariHesaplar.GetGMREFBySMREF(SMREF);
            DataTable dt = new DataTable();
            CariHesaplar.GetObjectByGMREF(dt, GMREF);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["BAKIYE"] != DBNull.Value)
                    lblSevkYeriBakiye.Text = Convert.ToDecimal(dt.Rows[0]["BAKIYE"]).ToString("C3");
                if (dt.Rows[0]["RISK BKY"] != DBNull.Value)
                    lblSevkYeriRiskBakiyesi.Text = Convert.ToDecimal(dt.Rows[0]["RISK BKY"]).ToString("C3");
                if (dt.Rows[0]["VGB GUN"] != DBNull.Value)
                    lblSevkYeriVGBGun.Text = dt.Rows[0]["VGB GUN"].ToString();
                if (dt.Rows[0]["VGB TOP"] != DBNull.Value)
                    lblSevkYeriVGBToplam.Text = Convert.ToDecimal(dt.Rows[0]["VGB TOP"]).ToString("C3");
            }
        }

        private bool SiparisOnayla(int siparisid, int sevkref)
        {
            string donen = string.Empty;
            bool aktarildimi = Siparis.SiparisOnayla(siparisid, sevkref, Session["DepoID"] != null ? Convert.ToInt32(Session["DepoID"]) : 0, cbBakiyeSiparis.Checked, (Musteriler)Session["Musteri"], out donen);
            if (!aktarildimi)
            {
                lblSiparisOnaylanamadiHata.Text = donen;
                //string alert = "<script type='text/javascript'>alert('" + donen + "');</script>";
                //ScriptManager.RegisterStartupScript(DivAjaxProg, typeof(string), "scriptSayfayukaricikar", alert, false);
            }
            return aktarildimi;



            Siparisler siparis = Siparisler.GetObjectsBySiparisID(siparisid);

            //if (siparis.sintFiyatTipiID == 2)
            //{
            //    divSiparisOnaylamama.Visible = true;
            //    return true;
            //}

            //decimal riskbakiye = CariHesaplar.GetRISKBKYByGMREF(CariHesaplar.GetGMREFBySMREF(siparis.SMREF));

            //if (siparis.mnToplamTutar > riskbakiye) // riske takıldı mı
            //    return false;

            if (siparis.sintFiyatTipiID == 3 && CariHesaplar.GetMtAciklama(siparis.SMREF).IndexOf("TOPTAN") == -1)
            {
                lblSiparisOnaylanamadiHata.Text = "Toptancı olmayan bir müşteriye toptan fiyatından sipariş girilemez. Eğer müşteri toptancı ise sistemden müşteri tipi değiştirilmelidir.";
                return false;
            }



            if (Session["DepoID"] != null)
            {
                siparis.blAktarilmis = true;
                siparis.dtOnaylamaTarihi = DateTime.Now;
                siparis.strAciklama = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + 
                    "Siparişin gönderileceği depo: " + Depolar.GetObject(Convert.ToInt32(Session["DepoID"])) + ";;;";
                siparis.DoUpdate();

                Session["DepoID"] = null;
                Session["SiparisTamamlaOnaylaBasildi"] = null;
                Session["OnaylanacakSiparisID"] = null;
                divSevkYerleri.Visible = false;
                Response.Redirect("siparisler.aspx", true);
            }

            bool bakiyesiparis = siparis.sintFiyatTipiID == 12 || siparis.sintFiyatTipiID == 13 ? false : cbBakiyeSiparis.Checked;



            bool siparisbolundu = false;
            bool bolunenlerdenbiriaktarilamadi = false;

           
            #region IsyeriOzelKod bölünmesi
            //
            if (siparis.SMREF != 24479 && CariHesaplar.GetGRPBySMREF(siparis.SMREF) != "06" && siparis.sintFiyatTipiID != 9 &&
                siparis.sintFiyatTipiID != 14 /*&& CariHesaplar.GetYTKKODBySMREF(siparis.SMREF) != "Z1"*/)
            {
                DataTable dtIsyeriOzelKodGruplar = new DataTable();
                IsyeriOzelKod.GetObjects2Gruplar(dtIsyeriOzelKodGruplar);

                for (int i = 0; i < dtIsyeriOzelKodGruplar.Rows.Count; i++)
                {
                    DataTable dtSiparistekiUrunler = new DataTable();
                    SiparislerDetay.GetObjectsBySiparisID(dtSiparistekiUrunler, siparisid);

                    DataTable dtIsyeriOzelKod = new DataTable();
                    IsyeriOzelKod.GetObjects2ByGrup(dtIsyeriOzelKod, Convert.ToInt32(dtIsyeriOzelKodGruplar.Rows[i][0]));

                    short isyerino = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintIsyeriKod"]);
                    short ambarno = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintAmbarKod"]);

                    Siparisler yenisiparis =
                        new Siparisler(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, DateTime.Now, 0, false,
                            siparis.TKSREF, DateTime.Now, siparis.strAciklama);
                    ArrayList yenisiparisurunleri = new ArrayList();
                    ArrayList eskisiparisurunleri = new ArrayList();

                    for (int j = 0; j < dtSiparistekiUrunler.Rows.Count; j++)
                    {
                        for (int k = 0; k < dtIsyeriOzelKod.Rows.Count; k++)
                        {
                            string isyeriozelkod = dtIsyeriOzelKod.Rows[k]["strOzelKod"].ToString();
                            string urunozelkod = Urunler.GetProductOzelKod(Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]));

                            if (urunozelkod == isyeriozelkod)
                            {
                                siparisbolundu = true;
                                yenisiparisurunleri.Add(
                                    new SiparislerDetay(
                                        0,
                                        Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]),
                                        dtSiparistekiUrunler.Rows[j]["strUrunAdi"].ToString(),
                                        Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intMiktar"]),
                                        Convert.ToDecimal(dtSiparistekiUrunler.Rows[j]["mnFiyat"]),
                                        Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaKart"].ToString()),
                                        Convert.ToBoolean(dtSiparistekiUrunler.Rows[j]["blKampanyaHediye"]),
                                        Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaSatir"].ToString()),
                                        dtSiparistekiUrunler.Rows[j]["strMiktarTur"].ToString()));

                                SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(
                                    Convert.ToInt64(dtSiparistekiUrunler.Rows[j]["pkSiparisDetayID"]));

                                eskisiparisurunleri.Add(siplerdet);

                                siplerdet.DoDelete();
                                siparis.ToplamTutarGuncelle();

                                break;
                            }
                        }
                    }
                    
                    if (yenisiparisurunleri.Count > 0)
                    {
                        yenisiparis.DoInsert();

                        decimal toplamtutar = 0;
                        for (int j = 0; j < yenisiparisurunleri.Count; j++)
                        {
                            SiparislerDetay siplerdet = (SiparislerDetay)yenisiparisurunleri[j];
                            siplerdet.intSiparisID = yenisiparis.pkSiparisID;
                            siplerdet.DoInsert();

                            SiparislerDetay.DoChangeIDISKs(((SiparislerDetay)eskisiparisurunleri[j]).pkSiparisDetayID, siplerdet.pkSiparisDetayID);

                            if (!siplerdet.blKampanyaHediye)
                                toplamtutar += siplerdet.mnFiyat * siplerdet.intMiktar;
                        }
                        yenisiparis.mnToplamTutar = toplamtutar;
                        yenisiparis.DoUpdate();

                        //if (!TaksitPlanlari.TaksitMi(siparis.TKSREF))
                        //    yenisiparis.TKSREF = TaksitPlanlari.GetODMREF(GetSiparisOrtVade(yenisiparis));

                        if (QuantumaYaz(yenisiparis.pkSiparisID, isyerino, ambarno, bakiyesiparis, sevkref))
                        {
                            yenisiparis.blAktarilmis = true;
                            yenisiparis.DoUpdate();
                        }
                        else
                        {
                            bolunenlerdenbiriaktarilamadi = true;
                        }
                    }
                }
            }
            //
            #endregion


            bool siparisaktarilamadi = false;


            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, siparis.pkSiparisID);
            if (dt.Rows.Count == 0) // eski siparişte ürün kalmışsa alsat dır
            {
                siparis.DoDelete();
            }
            else
            {
                if (siparisbolundu)
                {
                    decimal toplamtutar = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                        if (!Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]))
                            toplamtutar += Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * Convert.ToInt32(dt.Rows[i]["intMiktar"]);

                    siparis.mnToplamTutar = toplamtutar;
                    siparis.DoUpdate();
                }


                #region vade bölünmesi


                ArrayList vadeler = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), siparis.sintFiyatTipiID);
                    bool var = false;
                    for (int j = 0; j < vadeler.Count; j++)
                        if (Convert.ToInt32(vadeler[j]) == vade)
                            var = true;

                    if (!var)
                        vadeler.Add(vade);
                }

                if (vadeler.Count == 1) // vadeler hep aynıysa bölme
                {
                    if (QuantumaYaz(siparisid, 0, 0, bakiyesiparis, sevkref))
                    {
                        siparis.blAktarilmis = true;

                        siparis.dtOnaylamaTarihi = DateTime.Now;
                        siparis.DoUpdate();
                    }
                    else
                    {
                        siparisaktarilamadi = true;
                    }
                }
                else // bölünme
                {
                    for (int i = 0; i < vadeler.Count; i++)
                    {
                        // yeni sipariş oluştur
                        Siparisler yenisiparis = new Siparisler(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, DateTime.Now, 0, false,
                            siparis.TKSREF, DateTime.Now, siparis.strAciklama);
                        yenisiparis.DoInsert();

                        // yeni sipariş kalemlerini vadeden yararlanarak bul
                        ArrayList yenisipariskalemleri = new ArrayList();
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[j]["intUrunID"]), siparis.sintFiyatTipiID);
                            if (Convert.ToInt32(vadeler[i]) == vade)
                            {
                                SiparislerDetay sipdet = SiparislerDetay.GetObjectBySiparislerDetayID(Convert.ToInt64(dt.Rows[j]["pkSiparisDetayID"]));
                                yenisipariskalemleri.Add(new SiparislerDetay(yenisiparis.pkSiparisID, sipdet.intUrunID, sipdet.strUrunAdi, sipdet.intMiktar, sipdet.mnFiyat, sipdet.unKampanyaKart, sipdet.blKampanyaHediye, sipdet.unKampanyaSatir, sipdet.strMiktarTur));
                            }
                        }

                        // bulunan yeni sipariş kalemlerini yeni siparişe ekle
                        decimal toplamtutar = 0;
                        for (int j = 0; j < yenisipariskalemleri.Count; j++)
                        {
                            SiparislerDetay sipdet = ((SiparislerDetay)yenisipariskalemleri[j]);
                            toplamtutar += sipdet.mnFiyat * sipdet.intMiktar;
                            sipdet.DoInsert();
                        }
                        yenisiparis.mnToplamTutar = toplamtutar;

                        if (!TaksitPlanlari.TaksitMi(siparis.TKSREF))
                            yenisiparis.TKSREF = TaksitPlanlari.GetODMREF(Convert.ToInt32(vadeler[i]));

                        yenisiparis.DoUpdate();

                        // yeni siparişi onayla
                        if (QuantumaYaz(yenisiparis.pkSiparisID, 0, 0, bakiyesiparis, sevkref))
                        {
                            yenisiparis.blAktarilmis = true;

                            yenisiparis.dtOnaylamaTarihi = DateTime.Now;
                            yenisiparis.DoUpdate();
                        }
                        else
                        {
                            siparisaktarilamadi = true;
                        }
                    }

                    siparis.DoDelete(); // eski siparişte ürün kalmadığından sil
                }


                #endregion


            }



            if (siparisaktarilamadi || bolunenlerdenbiriaktarilamadi)
            {
                divSiparisOnaylanamadi.Visible = true;
            }

            return true;
        }

        private bool QuantumaYaz(int SiparisID, short IsyeriNo, short AmbarNo, bool BakiyeSiparis, int Sevkref)
        {
            Siparisler sip = Siparisler.GetObjectsBySiparisID(SiparisID);
            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, SiparisID);

            int SLSREF = CariHesaplar.GetSLSREFBySMREF(sip.SMREF);
            Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(sip.intMusteriID);
            if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
                SLSREF = siparisiolusturanmusteri1.intSLSREF;

            string bakiyeaciklama = cbBakiyeSiparis.Checked ? "*BKY*" : "";

            string[] aciklamalar = sip.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            string Aciklama2 = bakiyeaciklama + aciklamalar[1];
            string Aciklama3 = aciklamalar[2];
            DateTime tesltrh = DateTime.Now;
            try { tesltrh = Convert.ToDateTime(Aciklama3); } catch (Exception) { }
            if (tesltrh < DateTime.Now) tesltrh = DateTime.Now;

            SAPsendorderC.ZwebSendSalesOrderService clOrder = new SAPsendorderC.ZwebSendSalesOrderService();
            clOrder.Credentials = new System.Net.NetworkCredential("MISTIF", "123456q");
            SAPsendorderC.Zwebs010 header = new SAPsendorderC.Zwebs010();
            
            header.Ctype = "SATIS"; //IADE
            header.Ketdat = tesltrh.Year.ToString() + (tesltrh.Month.ToString().Length == 1 ? "0" + tesltrh.Month.ToString() : tesltrh.Month.ToString()) + (tesltrh.Day.ToString().Length == 1 ? "0" + tesltrh.Day.ToString() : tesltrh.Day.ToString());
            header.Kunwe = "000" + sip.SMREF.ToString();
            header.Pltyp = sip.sintFiyatTipiID.ToString().Length == 1 ? "0" + sip.sintFiyatTipiID.ToString() : sip.sintFiyatTipiID.ToString().Length == 3 ? "XX" : sip.sintFiyatTipiID.ToString();
            header.Vbeln = "";
            header.Xblnr = sip.pkSiparisID.ToString(); //WebGenel.DoUpdateSayac().ToString()
            header.Stext = Aciklama2;
            header.Zterm = sip.sintFiyatTipiID == 2 ? Convert.ToInt32(TaksitPlanlari.GetOdemePlani(sip.TKSREF).Substring(0, 3).Trim()).ToString() : "";

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
            else
            {
                //lblSiparisOnaylanamadiHata.Text = "Teknik Ayrıntı: <br><br>" + error;
                return false;
            }
            
            SAPsendorderC.Zwebs011[] line = new SAPsendorderC.Zwebs011[dt.Rows.Count];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = new SAPsendorderC.Zwebs011();
                line[i].Xblnr = sip.pkSiparisID.ToString();
                line[i].Itmid = (i + 1).ToString();
                line[i].Matnr = "00000000000" + dt.Rows[i]["intUrunID"].ToString();
                line[i].Meins = dt.Rows[i]["strMiktarTur"].ToString(); //Urunler.GetProductBirimRef(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                line[i].MengeSpecified = true;
                line[i].Menge = Convert.ToDecimal(dt.Rows[i]["intMiktar"]);
                line[i].Satir = Urunler.GetProductKampanyaAnaMi(Convert.ToInt32(dt.Rows[i]["intUrunID"])) ? "01" : "00";

                if (sip.sintFiyatTipiID == 2)
                {
                    double[] isks = SiparislerDetay.GetObjectISKs(Convert.ToInt64(dt.Rows[i]["pkSiparisDetayID"]));

                    line[i].FiyatSpecified = true;
                    line[i].Fiyat = Convert.ToDecimal(isks[10]);
                    line[i].Isk1Specified = true;
                    line[i].Isk1 = Convert.ToDecimal(isks[0]);
                    line[i].Isk2Specified = true;
                    line[i].Isk2 = Convert.ToDecimal(isks[1]);
                    line[i].Isk3Specified = true;
                    line[i].Isk3 = Convert.ToDecimal(isks[2]);
                    line[i].Isk4Specified = true;
                    line[i].Isk4 = Convert.ToDecimal(isks[3]);
                    line[i].Isk5Specified = true;
                    line[i].Isk5 = Convert.ToDecimal(isks[4]);
                    line[i].Isk6Specified = true;
                    line[i].Isk6 = Convert.ToDecimal(isks[5]);
                    line[i].Isk7Specified = true;
                    line[i].Isk7 = Convert.ToDecimal(isks[6]);
                    line[i].Isk8Specified = true;
                    line[i].Isk8 = Convert.ToDecimal(isks[7]);
                    line[i].Isk9Specified = true;
                    line[i].Isk9 = Convert.ToDecimal(isks[8]);
                    line[i].Isk10Specified = true;
                    line[i].Isk10 = Convert.ToDecimal(isks[9]);
                }
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

            if (donen != string.Empty)
            {
                Siparisler.DoInsertQ(sip.pkSiparisID, donen);
                error = string.Empty;
            }
            else
            {
                Hatalar.DoInsert("Sipariş (" + sip.pkSiparisID.ToString() + ") SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + error, "siparisler.aspx Quantumayaz()");
                lblSiparisOnaylanamadiHata.Text = "Ayrıntı: <br><br>" + error.Replace("SALES_HEADER_IN işlendi, ", "").Replace("SALES_ITEM_IN işlendi, ", "").Replace("Satış belgesi  değiştirilmedi, ", "").Replace("SALES_ITEM_IN", "").Replace("Teknik eksiklikler", "Ürün kullanım dışındadır. Lütfen ürünü siparişten silerek onaylayınız, ");
            }

            QuantumWebServisLog.DoInsert(error == string.Empty, sip.pkSiparisID, donen, ((Musteriler)Session["Musteri"]).pkMusteriID, "", "SATIS");

            return error == string.Empty;
        }

        private void SiparisListesiniYenile()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);

                if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0,
                        (int)Session["SiparislerSayfaBasiGosterim"]);
                else
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID,
                        Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"],
                        (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                    {
                        GetSiparisCount();

                        if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                            GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        else
                            GetSiparisler(Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                    {
                        GetSiparisCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF);

                        if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                            GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        else
                            GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
                else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                        GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    else
                        GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0,
                            (int)Session["SiparislerSayfaBasiGosterim"]);
                    else
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)),
                            Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"],
                            (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else                                                                // şube seçilmişse
                {
                    GetSiparisCountBySMREF((int)Session["SiparisGetirilecekSMREF"]);

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                        GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], 0,
                            (int)Session["SiparislerSayfaBasiGosterim"]);
                    else
                        GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"],
                            Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"],
                            (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
        }

        private void GetSiparisFromDB(int SiparisID)
        {
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(SiparisID);

            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, SiparisID);

            SiparisListe siplist = new SiparisListe(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, false);
            siplist._SiparisID = SiparisID;
            siplist._TKSREF = siparis.TKSREF;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long siparisdetayid = Convert.ToInt64(dt.Rows[i]["pkSiparisDetayID"]);
                Guid kamkartref = Guid.Parse(dt.Rows[i]["unKampanyaKart"].ToString());
                Guid kamsatirref = Guid.Parse(dt.Rows[i]["unKampanyaSatir"].ToString());
                int urunid = Convert.ToInt32(dt.Rows[i]["intUrunID"]);
                string urunadi = dt.Rows[i]["strUrunAdi"].ToString();
                int miktar = Convert.ToInt32(dt.Rows[i]["intMiktar"]); //  * (dt.Rows[i]["strMiktarTur"].ToString() == "ST" ? 1 : dt.Rows[i]["strMiktarTur"].ToString() == "KI" ? Convert.ToInt32(Urunler.GetKoliAdedi(urunid)) : dt.Rows[i]["strMiktarTur"].ToString() == "PAK" ? Convert.ToInt32(Urunler.GetProductBirim(urunid)) : 1) // buna gerek kalmadı niye anlamadım
                bool kampanyahediye = Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]);
                decimal oncekifiyat = Convert.ToDecimal(dt.Rows[i]["mnFiyat"]);
                decimal simdikifiyat = 0;
                
                simdikifiyat = oncekifiyat;

                siplist.Add(urunid, urunadi, miktar, simdikifiyat, kamkartref, kampanyahediye, kamsatirref, dt.Rows[i]["strMiktarTur"].ToString(), siparisdetayid);
            }

            SiparisIncele(siplist);
            string[] aciklamalar = siparis.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            lblSiparisAciklama.Text = "<strong>Açıklama:</strong> -";

            if (aciklamalar.Length > 2)
            {
                if (aciklamalar[1] != string.Empty)
                    lblSiparisAciklama.Text = lblSiparisAciklama.Text.Substring(0, lblSiparisAciklama.Text.Length - 1) + "<i>" + aciklamalar[1] + "</i>";
                if (aciklamalar[2] != string.Empty)
                    lblSiparisAciklama.Text += " - <i>" + aciklamalar[2] + "</i>";
            }
            else
            {
                if (aciklamalar[1] != string.Empty)
                    lblSiparisAciklama.Text = lblSiparisAciklama.Text.Substring(0, lblSiparisAciklama.Text.Length - 1) + "<i>" + aciklamalar[1] + "</i>";
            }
        }

        private void SiparisIncele(SiparisListe siplist)
        {
            divSiparis.Visible = true;
            lblSiparisSonDurum.Visible = false;
            lbOnaylamayaDevam.Visible = false;
            lblSiparisDetaylari.Visible = true;

            Repeater1.DataSource = siplist;
            Repeater1.DataBind();
            lblSiparisToplam.Text = siplist.ToplamTutar.ToString("C3");
            //lblOrtalamaVade.Text = GetSiparisOrtVade(siplist).ToString();
            lblSiparisDetaylari.Text = "Sip.No: " + siplist._SiparisID.ToString() + " <span style='color: #B50012'>(SAP: " + Siparisler.GetQ(siplist._SiparisID) + ")</span>";

            if (TaksitPlanlari.TaksitMi(siplist._TKSREF))
                lblOrtalamaVade.Text = TaksitPlanlari.GetOdemePlani(siplist._TKSREF);
            else
                lblOrtalamaVade.Text = (((Musteriler)Session["Musteri"]).tintUyeTipiID != 1) ? "Ortalama Vade: <strong>" + TaksitPlanlari.GetOdemePlani(siplist._TKSREF).Replace("GÜN VADE", "Gün") + "</strong>" : "";
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise diğer siparişler gelmemesi için
            {
                if (CariHesaplar.AnaSubeMi(((Musteriler)Session["Musteri"]).intGMREF))
                {
                    ddlCariHesaplarSubeler.SelectedIndex = 0;

                    Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year);
                    Calendar2.SelectedDate = DateTime.Now;

                    Session["SiparisGetirilecekSMREF"] = null;
                    lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
                    GetSiparislerBos();
                }
                else
                {
                    ddlCariHesaplarSubeler.Visible = false;

                    GetSiparisCountBySMREF(((Musteriler)Session["Musteri"]).intGMREF);
                    GetSiparislerBySMREF(((Musteriler)Session["Musteri"]).intGMREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }

                return;
            }

            if (ddlTemsilciler.SelectedValue == "1")
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);

                    ddlCariHesaplar.Items.Clear();
                    ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                    ddlCariHesaplarSubeler.Items.Clear();
                    ddlCariHesaplarSubeler.Visible = false;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                {
                    GetSiparisCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF);
                    GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);

                    ddlCariHesaplar.Items.Clear();
                    ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                    ddlCariHesaplarSubeler.Items.Clear();
                    ddlCariHesaplarSubeler.Visible = false;
                }

                return;
            }

            ddlCariHesaplar.Items.Clear();
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
            if (ddlTemsilciler.SelectedValue != "0")
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;

            ArrayList slsrefs = new ArrayList(); slsrefs.Add(ddlTemsilciler.SelectedValue);
            CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);

            Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year);
            Calendar2.SelectedDate = DateTime.Now;

            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();
            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
            lblDipToplam.Text = "0,000 TL";

            lblSiparisYok.Visible = true;

            if (ddlTemsilciler.SelectedValue == "0")
                Session["SiparisGetirilecekSMREF"] = null;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSiparislerBos();
            ddlCariHesaplarSubeler.Items.Clear();
            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
            lblDipToplam.Text = "0,000 TL";
            lblSiparisYok.Visible = true;

            if (ddlCariHesaplar.SelectedValue == "1") // tümü denmişse
            {
                ddlCariHesaplarSubeler.Visible = false;

                if (ddlTemsilciler.SelectedValue == "1")
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (ddlTemsilciler.SelectedValue != "0")
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplar.SelectedValue != "0" && ddlCariHesaplar.SelectedValue != "1")
            {
                bool AnaSube = CariHesaplar.AnaSubeMi(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                if (AnaSube)
                {
                    ddlCariHesaplarSubeler.Visible = true;

                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && Session["SefMusteriListesi"] == null) // şef değil ise
                    {
                        CariHesaplar.GetSubelerBySLSREF(ddlCariHesaplarSubeler.Items, 
                            Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), ((Musteriler)Session["Musteri"]).intSLSREF);
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
                    {
                        CariHesaplar.GetSubeler(ddlCariHesaplarSubeler.Items, Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                    {
                        int SLSREF = SatisTemsilcileri.GetSLSREFBySATTEM(ddlCariHesaplar.SelectedItem.Text.Substring(0, ddlCariHesaplar.SelectedItem.Text.IndexOf(" - ")));

                        CariHesaplar.GetSubelerBySLSREF(ddlCariHesaplarSubeler.Items,
                            Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), SLSREF);
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                    {
                        CariHesaplar.GetSubelerBySLSREF(ddlCariHesaplarSubeler.Items,
                            Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    }
                }
                else
                {
                    ddlCariHesaplarSubeler.Visible = false;

                    //Session["SiparisGetirilecekSMREF"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue);
                    //DataTable dt = new DataTable();
                    //Siparisler.GetObjectsBySMREF(dt, Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0, 
                    //    (int)Session["SiparislerSayfaBasiGosterim"]);
                    //dlSiparisler.DataSource = dt;
                    //dlSiparisler.DataBind();

                    GetSiparisCountBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    GetSiparislerBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)),
                        0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
            else
            {
                ddlCariHesaplarSubeler.Visible = false;
                Session["SiparisGetirilecekSMREF"] = null;
            }

            //rbSiparislerHepsi.Checked = false;
            //rbSiparislerOnaylilar.Checked = false;
            //rbSiparislerOnaysizlar.Checked = true;
        }

        protected void ddlCariHesaplarSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCariHesaplarSubeler.SelectedValue == "1")
            {
                GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            } 
            else if (ddlCariHesaplarSubeler.SelectedValue != "0")
            {
                GetSiparisCountBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)));
                GetSiparislerBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), 
                    0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                Session["SiparisGetirilecekSMREF"] = null;
                lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
                lblDipToplam.Text = "0,000 TL";
                lblSiparisYok.Visible = true;
                GetSiparislerBos();
            }

            //rbSiparislerHepsi.Checked = false;
            //rbSiparislerOnaylilar.Checked = false;
            //rbSiparislerOnaysizlar.Checked = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["SiparislerSayfaBasiGosterim"] < baslangic)
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    {
                        GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                        {
                            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                                GetSiparisler(baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                                GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                        {
                            GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                        {
                            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else
                        {
                            GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                    }

                    lblSiparisKacinci.Text = baslangic.ToString();
                }
                else
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    {
                        GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                        {
                            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                                GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                                GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                        {
                            GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                        {
                            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else
                        {
                            GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                    }

                    lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
                }
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) + (int)Session["SiparislerSayfaBasiGosterim"];
            if (Convert.ToInt32(lblSiparisKacinci.Text) < Convert.ToInt32(lblSiparisSayisi.Text))
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                {
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else
                {
                    if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                    {
                        if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                            GetSiparisler(baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                            GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                    {
                        GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                    {
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }

                if (baslangic > Convert.ToInt32(lblSiparisSayisi.Text))
                    lblSiparisKacinci.Text = lblSiparisSayisi.Text;
                else
                    lblSiparisKacinci.Text = baslangic.ToString();
            }
        }

        protected void ibIncele_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            GetSiparisFromDB(siparisid);

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparis, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisKapat_Click(object sender, EventArgs e)
        {
            divSiparis.Visible = false;
        }

        protected void ibDegistir_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        Session["SiparisID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                    else if (ctrl.ID.StartsWith("SMREF"))
                    {
                        Session["SMREF"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            if (Session["SiparisID"] != null && Session["SMREF"] != null)
            {
                Siparisler siparis = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(Session["SiparisID"]));

                bool yetkili = false;
                for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
                {
                    if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == siparis.sintFiyatTipiID)
                    {
                        yetkili = true;
                        break;
                    }
                }

                if (yetkili)
                {
                    int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Session["SMREF"]));
                    Session["SiparisSahibiMusteriID"] = siparis.intMusteriID;
                    Session["RISKBAKIYE"] = CariHesaplar.GetRISKBKYByGMREF(GMREF); // sadece sipariş sayfasında geçişte kullanılacak
                    Session["FiyatTipi"] = siparis.sintFiyatTipiID; // sadece siparis sayfasinda geciste kullanilacak
                    Response.Redirect("siparis.aspx", true);
                }
                else
                {
                    divFiyatTipiYetkisiYok.Visible = true;
                }
            }
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        Session["SilinecekSiparisID"] = siparisid;
                        break;
                    }
                }
            }



            // siparisteki fiyat tipine hala yetkili mi:
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(siparisid);
            bool yetkili = false;
            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == siparis.sintFiyatTipiID)
                {
                    yetkili = true;
                    break;
                }
            }
            if (!yetkili)
            {
                divFiyatTipiYetkisiYok.Visible = true;
                return;
            }



            divSiparisSil.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisSil, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisSilEvet_Click(object sender, EventArgs e)
        {
            Siparisler.DoDeleteWithSiparislerDetays((int)Session["SilinecekSiparisID"]);
            Session["SilinecekSiparisID"] = null;
            divSiparisSil.Visible = false;
            SiparisListesiniYenile();
        }

        protected void lbSiparisSilHayir_Click(object sender, EventArgs e)
        {
            Session["SilinecekSiparisID"] = null;
            divSiparisSil.Visible = false;
        }

        protected void ibOnayla_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        Session["OnaylanacakSiparisID"] = siparisid;
                        break;
                    }
                }
            }



            Siparisler siparis = Siparisler.GetObjectsBySiparisID(siparisid);

            if (siparis.blAktarilmis)
            {
                divSiparisAktarilmisHata.Visible = true;
                return;
            }



            // siparisteki fiyat tipine hala yetkili mi:
            bool yetkili = false;
            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == siparis.sintFiyatTipiID)
                {
                    yetkili = true;
                    break;
                }
            }
            if (!yetkili)
            {
                divFiyatTipiYetkisiYok.Visible = true;
                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divFiyatTipiYetkisiYok, typeof(string), "scriptSayfayukaricikar", alert, false);
                return;
            }



            DataTable dtDetaylar = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dtDetaylar, siparis.pkSiparisID);
            if (dtDetaylar.Rows.Count == 0)
            {
                divToplamTutarSifir.Visible = true;
                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divToplamTutarSifir, typeof(string), "scriptSayfayukaricikar", alert, false);
                return;
            }



            #region sipariş tekrar hesaplanması yeni fiyatlarla, kaldırdım çünkü koli adet karıştırıyordu
            //if (siparis.sintFiyatTipiID != 2) // guncel fiyatlari al, fiyat tipi 2 ise yeni fiyat gelmeyecek
            //{
            //    DataTable dt1 = new DataTable();
            //    SiparislerDetay.GetObjectsBySiparisID(dt1, siparis.pkSiparisID);

            //    decimal toplamtutar = 0;

            //    for (int i = 0; i < dt1.Rows.Count; i++)
            //    {
            //        if (!Convert.ToBoolean(dt1.Rows[i]["blKampanyaHediye"]))
            //        {
            //            decimal yenifiyat = Urunler.GetProductPrice(Convert.ToInt32(dt1.Rows[i]["intUrunID"]), siparis.sintFiyatTipiID);

            //            int miktar = Convert.ToInt32(dt1.Rows[i]["intMiktar"]); // adet ise
            //            if (dt1.Rows[i]["strMiktarTur"].ToString() == "KI") // koli ise
            //                miktar = Convert.ToInt32(dt1.Rows[i]["intMiktar"]) * Convert.ToInt32(Urunler.GetKoliAdedi(Convert.ToInt32(dt1.Rows[i]["intUrunID"])));
            //            else if (dt1.Rows[i]["strMiktarTur"].ToString() == "PAK") // paket ise
            //                miktar = Convert.ToInt32(dt1.Rows[i]["intMiktar"]) * Convert.ToInt32(Urunler.GetProductBirim(Convert.ToInt32(dt1.Rows[i]["intUrunID"])));

            //            toplamtutar += yenifiyat * miktar;
            //            SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(Convert.ToInt64(dt1.Rows[i]["pkSiparisDetayID"]));
            //            siplerdet.mnFiyat = yenifiyat;
            //            siplerdet.DoUpdate();
            //        }
            //    }

            //    siparis.mnToplamTutar = toplamtutar;
            //    siparis.DoUpdate();
            //}
            #endregion



            divSevkYerleri.Visible = true;

            int SLSREFkontrol = CariHesaplar.GetSLSREFBySMREF(siparis.SMREF);
            Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(siparis.intMusteriID);
            if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
                SLSREFkontrol = siparisiolusturanmusteri1.intSLSREF;

            bool bakiye = WebMusteriEk.GetBakiye(siparis.SMREF, SLSREFkontrol);
            spanBakiyeSiparis.Visible = bakiye;
            cbBakiyeSiparis.Visible = bakiye;
            cbBakiyeSiparis.Checked = bakiye;

            GetSiparisFromDB(siparis.pkSiparisID);
            lblSiparisDetaylari.Visible = false;
            lblSiparisSonDurum.Visible = true;
            lbOnaylamayaDevam.Visible = true;


            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1 && ((Musteriler)Session["Musteri"]).blSicakSatis)
            {
                tblSevk.Visible = false;
                tblAdresler.Visible = true;
                //GetAdresler();


                if (!Odemeler.GetSiparisOdemeYapildiMi(siparisid)) // ödeme yapılmış sipariş ise ödeme ekranı açılmayacak
                {
                    Session["OdemeSiparisNo"] = siparisid;
                    Session["OdemeTutari"] = siparis.mnToplamTutar;
                    Session["OdemeGMREF"] = siparis.SMREF;
                    divOdeme.Visible = true;
                }


                return;
            }


            if (((Musteriler)Session["Musteri"]).tintIlID != 34) // istanbul dışı müşteri ise
            {
                tblSevk.Visible = false;
                tblDepolar.Visible = true;
                GetDepolar(((Musteriler)Session["Musteri"]).tintIlID);
                return;
            }


            GetSevkYerleri(siparis.SMREF);

            string alert2 = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSevkYerleri, typeof(string), "scriptSayfayukaricikar", alert2, false);
        }

        private void GetDepolar(byte IlID)
        {
            Depolar.GetObjectsByIlID(rblDepolar.Items, IlID);
            rblDepolar.SelectedIndex = 0;
        }

        private void GetAdresler()
        {
            MusteriAdresler.GetObjects(ddlAdresler.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);
            Iller.GetObject(ddlIller.Items);
            ddlIller.Items.RemoveAt(0);
            for (int i = 0; i < ddlIller.Items.Count; i++)
            {
                if (ddlIller.Items[i].Value == "34")
                {
                    ddlIller.Items[i].Selected = true;
                    break;
                }
            }

            Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
            ddlIlceler.Items.RemoveAt(0);
            ddlIlceler.SelectedIndex = 0;
        }

        protected void ddlAdresler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAdresler.SelectedIndex > 0)
            {
                txtBaslik.Enabled = false;
                txtAdres.Enabled = false;
                ddlIller.Enabled = false;
                ddlIlceler.Enabled = false;

                MusteriAdresler ma = MusteriAdresler.GetObject(Convert.ToInt32(ddlAdresler.SelectedValue));
                txtBaslik.Text = ma.strBaslik;
                txtAdres.Text = ma.strAdres;

                Iller.GetObject(ddlIller.Items);
                ddlIller.Items.RemoveAt(0);
                for (int i = 0; i < ddlIller.Items.Count; i++)
                {
                    if (Convert.ToByte(ddlIller.Items[i].Value) == ma.tintIlID)
                    {
                        ddlIller.Items[i].Selected = true;
                        break;
                    }
                }

                Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
                ddlIlceler.Items.RemoveAt(0);
                for (int i = 0; i < ddlIlceler.Items.Count; i++)
                {
                    if (Convert.ToInt16(ddlIlceler.Items[i].Value) == ma.sintIlceID)
                    {
                        ddlIlceler.Items[i].Selected = true;
                        break;
                    }
                }
            }
            else if (ddlAdresler.SelectedIndex == 0)
            {
                txtBaslik.Enabled = true;
                txtAdres.Enabled = true;
                ddlIller.Enabled = true;
                ddlIlceler.Enabled = true;

                txtBaslik.Text = string.Empty;
                txtAdres.Text = string.Empty;

                for (int i = 0; i < ddlIller.Items.Count; i++)
                {
                    if (ddlIller.Items[i].Value == "34")
                    {
                        ddlIller.Items[i].Selected = true;
                        break;
                    }
                }

                Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
                ddlIlceler.Items.RemoveAt(0);
                ddlIlceler.SelectedIndex = 0;
            }
        }

        protected void ddlIller_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
            ddlIlceler.Items.RemoveAt(0);
            ddlIlceler.SelectedIndex = 0;
        }

        protected void lbOnaylaBitir_Click(object sender, EventArgs e)
        {
            Siparisler sip = Siparisler.GetObjectsBySiparisID((int)Session["OnaylanacakSiparisID"]);



            if (sip.SMREF == 24479) // perakende müşteri siparişi ise
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri onaylıyorsa, diğer ihtimal yöneticinin onaylaması
                {
                    if (ddlAdresler.SelectedIndex == 0)
                    {
                        MusteriAdresler ma = new MusteriAdresler(
                            ((Musteriler)Session["Musteri"]).pkMusteriID, txtBaslik.Text.Trim(), txtAdres.Text.Trim(),
                            Convert.ToByte(ddlIller.SelectedValue), Convert.ToInt16(ddlIlceler.SelectedValue));

                        if (txtBaslik.Text.Trim() != string.Empty)
                        {
                            ma.DoInsert();
                            sip.strAciklama =  ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + 
                                ma.strAdres + ";;;" + ddlIlceler.SelectedItem.Text + "/" + ddlIller.SelectedItem.Text;
                            sip.DoUpdate();
                        }
                    }
                    else if (ddlAdresler.SelectedIndex > 0)
                    {
                        Musteriler siparisigirenmusteri = Musteriler.GetMusteriByID(sip.intMusteriID);
                        sip.strAciklama = siparisigirenmusteri.strAd + " " + siparisigirenmusteri.strSoyad +  ";;;" + 
                            txtAdres.Text.Trim() + ";;;" + ddlIlceler.SelectedItem.Text + "/" + ddlIller.SelectedItem.Text;
                        sip.DoUpdate();
                    }
                }

                SiparisOnayla((int)Session["OnaylanacakSiparisID"], 0);

                Session["SiparisTamamlaOnaylaBasildi"] = null;
                Session["OnaylanacakSiparisID"] = null;
                divSevkYerleri.Visible = false;
                Response.Redirect("siparisler.aspx", true);
                //divOdeme.Visible = true;
            }



            if (((Musteriler)Session["Musteri"]).tintIlID != 34 && rblDepolar.SelectedIndex > 0) // istanbul dışı müşteri ise ve sultanlar merkez seçilmemişse
            {
                Session["DepoID"] = rblDepolar.SelectedItem.Value;
                SiparisOnayla((int)Session["OnaylanacakSiparisID"], Convert.ToInt32(rblSevkYerleri.SelectedValue));
            }



            if (SiparisOnayla((int)Session["OnaylanacakSiparisID"], Convert.ToInt32(rblSevkYerleri.SelectedValue))) // false ise hata var
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
                {
                    divAyniMusteriyeSiparis.Visible = true;
                }
                else
                {
                    Session["OnaylanacakSiparisID"] = null;
                    Response.Redirect("siparisler.aspx", true);
                }
            }
            else
            {
                Session["OnaylanacakSiparisID"] = null;
                divSevkYerleri.Visible = false;
                //divRiskBakiyeHata.Visible = true;
                divSiparisOnaylanamadi.Visible = true;
            }
        }

        protected void lbAyniMusteriyeSiparisEvet_Click(object sender, EventArgs e)
        {
            Siparisler sip = Siparisler.GetObjectsBySiparisID((int)Session["OnaylanacakSiparisID"]);
            Session["OnaylanacakSiparisID"] = null;
            Session["SiparisTamamlaBasildiSiparisID"] = null;

            Session["SMREF"] = sip.SMREF;
            Session["RISKBAKIYE"] = CariHesaplar.GetRISKBKYByGMREF(CariHesaplar.GetGMREFBySMREF(sip.SMREF)); // sadece sipariş sayfasında geçişte kullanılacak
            Session["FiyatTipi"] = sip.sintFiyatTipiID; // sadece siparis sayfasinda geciste kullanilacak
            Session["SiparisID"] = 0;

            Response.Redirect("siparis.aspx", true);
        }

        protected void lbAyniMusteriyeSiparisHayir_Click(object sender, EventArgs e)
        {
            Session["OnaylanacakSiparisID"] = null;
            Session["SiparisTamamlaBasildiSiparisID"] = null;
            Response.Redirect("siparisler.aspx", true);
        }

        protected void lbOnaylaKapat_Click(object sender, EventArgs e)
        {
            Session["SiparisTamamlaOnaylaBasildi"] = null;
            Session["OnaylanacakSiparisID"] = null;
            divSevkYerleri.Visible = false;
        }

        protected void lbOnaylamayaDevam_Click(object sender, EventArgs e)
        {
            divSiparis.Visible = false;
        }

        protected void ibKopyala_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                    if (ctrl.ID.StartsWith("SiparisID"))
                        Session["KopyalanacakSiparisID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;

            // siparisteki fiyat tipine hala yetkili mi:
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(Session["KopyalanacakSiparisID"]));
            bool yetkili = false;
            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == siparis.sintFiyatTipiID)
                {
                    yetkili = true;
                    break;
                }
            }
            if (!yetkili)
            {
                divFiyatTipiYetkisiYok.Visible = true;
                return;
            }

            #region Perakande Müşteri
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                int siparisid = 0;

                foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
                    if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                        if (ctrl.ID.StartsWith("SiparisID"))
                            siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);

                Siparisler Oncekisiparis = Siparisler.GetObjectsBySiparisID(siparisid);
                Siparisler Siparis = new Siparisler(((Musteriler)Session["Musteri"]).pkMusteriID,
                        Oncekisiparis.SMREF, Oncekisiparis.sintFiyatTipiID, DateTime.Now,
                        Oncekisiparis.mnToplamTutar, false, Oncekisiparis.TKSREF, DateTime.Now, Oncekisiparis.strAciklama);
                Siparis.DoInsert();

                DataTable dt = new DataTable();
                SiparislerDetay.GetObjectsBySiparisID(dt, siparisid);

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    SiparislerDetay siplerdet = new SiparislerDetay(Siparis.pkSiparisID, Convert.ToInt32(dt.Rows[j]["intUrunID"]),
                        dt.Rows[j]["strUrunAdi"].ToString(),
                        Convert.ToInt32(dt.Rows[j]["intMiktar"]), Convert.ToDecimal(dt.Rows[j]["mnFiyat"]),
                        Guid.Parse(dt.Rows[j]["unKampanyaKart"].ToString()), Convert.ToBoolean(dt.Rows[j]["blKampanyaHediye"]),
                        Guid.Parse(dt.Rows[j]["unKampanyaSatir"].ToString()), dt.Rows[j]["strMiktarTur"].ToString());
                    siplerdet.DoInsert();
                }

                Response.Redirect("siparisler.aspx", true);
                return;
            }
            #endregion

            if (siparis.SMREF == 69348) // ucz siparişi ise sevk yerlerine kopyalansın
            {
                SevkYerleri.GetObjectsBySMREF(cblSiparisKopyala2SevkYerleri.Items, siparis.SMREF);
                cblSiparisKopyala2SevkYerleri.SelectedIndex = 0;
                divSiparisKopyala2.Visible = true;
                return;
            }

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)     // satış temsilcisi veya bölge yöneticisi ise
            {
                ArrayList altlar = new ArrayList();
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
                    altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                    altlar = SatisTemsilcileri.GetSLSREFsFromCariHesaplar();
                //Session["SefSLSREFs"] = altlar;

                if (altlar.Count == 0) // şef değil ise
                {
                    CariHesaplar.GetTekCarilerBySLSREF(cblSiparisKopyalaSubeler.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, false);
                    cblSiparisKopyalaSubeler.Items.RemoveAt(0); // seçinizi kaldırmak için

                    ArrayList anacarigmrefler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                    for (int i = 0; i < anacarigmrefler.Count; i++)
                    {
                        DataTable dt = new DataTable();
                        CariHesaplar.GetSubeler(dt, Convert.ToInt32(anacarigmrefler[i]));

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            ListItem lst = new ListItem();
                            lst.Text = dt.Rows[j][4].ToString();
                            lst.Value = dt.Rows[j][4].ToString().Substring(0, 3) + dt.Rows[j][2].ToString();
                            cblSiparisKopyalaSubeler.Items.Add(lst);
                        }
                    }

                    string sattem = SatisTemsilcileri.GetObjectBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF.ToString());
                    for (int i = 0; i < cblSiparisKopyalaSubeler.Items.Count; i++)
                        cblSiparisKopyalaSubeler.Items[i].Text = sattem + " - " + cblSiparisKopyalaSubeler.Items[i].Text;
                }
                else // şef ise
                {
                    //if (Session["SefSiparisKopyalaListe"] == null)
                    //{
                        CariHesaplar.GetSMREFandSATTEMMUSTERISUBEByGMREFsSLSREFs(cblSiparisKopyalaSubeler.Items, ddlCariHesaplar.Items, altlar);
                    //    Session["SefSiparisKopyalaListe"] = cblSiparisKopyalaSubeler.Items;
                    //}
                    //else
                    //{
                    //    cblSiparisKopyalaSubeler.Items.Clear();

                    //    for (int i = 0; i < ((ListItemCollection)Session["SefSiparisKopyalaListe"]).Count; i++)
                    //    {
                    //        cblSiparisKopyalaSubeler.Items.Add(((ListItemCollection)Session["SefSiparisKopyalaListe"])[i]);
                    //    }
                    //}
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                CariHesaplar.GetSMREFandSATTEMMUSTERISUBEforSiparisKopyala(cblSiparisKopyalaSubeler.Items);
            }
            else                                                                        // müşteri ise
            {
                int gmref = ((Musteriler)Session["Musteri"]).intGMREF;

                if (CariHesaplar.AnaSubeMi(gmref))
                {
                    DataTable dt = new DataTable();
                    CariHesaplar.GetSubeler(dt, gmref);

                    cblSiparisKopyalaSubeler.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dt.Rows[i][4].ToString();
                        lst.Value = dt.Rows[i][2].ToString();
                        cblSiparisKopyalaSubeler.Items.Add(lst);
                    }
                }
                else
                {
                    ListItem lst = new ListItem();
                    lst.Text = CariHesaplar.GetObjectByGMREF(gmref)[1].ToString();
                    lst.Value = gmref.ToString();
                    cblSiparisKopyalaSubeler.Items.Clear();
                    cblSiparisKopyalaSubeler.Items.Add(lst);
                }
            }

            divSiparisKopyala.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisKopyala, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisKopyalaTamamla_Click(object sender, EventArgs e)
        {
            int siparisid = Convert.ToInt32(Session["KopyalanacakSiparisID"]);
            Session["KopyalanacakSiparisID"] = null;

            Siparisler Oncekisiparis = Siparisler.GetObjectsBySiparisID(siparisid);

            for (int i = 0; i < cblSiparisKopyalaSubeler.Items.Count; i++)
            {
                if (cblSiparisKopyalaSubeler.Items[i].Selected)
                {
                    string[] aciklamalar = Oncekisiparis.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
                    string aciklama = string.Empty;
                    if (aciklamalar.Length > 2)
                        aciklama = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + aciklamalar[1] + ";;;"/* + aciklamalar[2]*/;
                    else
                        aciklama = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + aciklamalar[1] + ";;;";



                    int smref = 0;
                    if (cblSiparisKopyalaSubeler.Items[i].Value.Length == 7)
                        smref = Convert.ToInt32(cblSiparisKopyalaSubeler.Items[i].Value);
                    else
                        smref = Convert.ToInt32(cblSiparisKopyalaSubeler.Items[i].Value.Substring(3));



                    if (!(Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(smref), DateTime.Now, "2") > 0 && (Oncekisiparis.sintFiyatTipiID == 3 || Oncekisiparis.sintFiyatTipiID == 4 || Oncekisiparis.sintFiyatTipiID == 7 || Oncekisiparis.sintFiyatTipiID == 8)))
                    {
                        int musteriid = 0;
                        int SLSREF = 0;
                        if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 1) // müşteri değil ise
                        {
                            //SLSREF = SatisTemsilcileri.GetSLSREFBySATTEM
                            //    (cblSiparisKopyalaSubeler.Items[i].Text.Substring(0, cblSiparisKopyalaSubeler.Items[i].Text.IndexOf(" - ")).Trim());
                            //musteriid = Musteriler.GetMusteriIDbySLSREF(SLSREF);

                            SLSREF = CariHesaplar.GetSLSREFBySMREF(smref);
                            //musteriid = Musteriler.GetMusteriIDbySLSREF(SLSREF);
                        }
                        musteriid = ((Musteriler)Session["Musteri"]).pkMusteriID; // musteriid == 0 ? ((Musteriler)Session["Musteri"]).pkMusteriID : musteriid;

                        Siparisler Siparis = new Siparisler(musteriid,
                            smref, Oncekisiparis.sintFiyatTipiID, DateTime.Now,
                            Oncekisiparis.mnToplamTutar, false, Oncekisiparis.TKSREF, DateTime.Now, aciklama);
                        Siparis.DoInsert();

                        DataTable dt = new DataTable();
                        SiparislerDetay.GetObjectsBySiparisID(dt, siparisid);

                        //decimal toplamtutar = 0;
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            //toplamtutar += Convert.ToInt32(dt.Rows[j]["intMiktar"]) * Convert.ToDecimal(dt.Rows[j]["mnFiyat"]);
                            SiparislerDetay siplerdet = new SiparislerDetay(Siparis.pkSiparisID, Convert.ToInt32(dt.Rows[j]["intUrunID"]),
                                dt.Rows[j]["strUrunAdi"].ToString(),
                                Convert.ToInt32(dt.Rows[j]["intMiktar"]), Convert.ToDecimal(dt.Rows[j]["mnFiyat"]),
                                Guid.Parse(dt.Rows[j]["unKampanyaKart"].ToString()), Convert.ToBoolean(dt.Rows[j]["blKampanyaHediye"]),
                                Guid.Parse(dt.Rows[j]["unKampanyaSatir"].ToString()), dt.Rows[j]["strMiktarTur"].ToString());
                            siplerdet.DoInsert();

                            double[] isks = SiparislerDetay.GetObjectISKs(Convert.ToInt64(dt.Rows[j]["pkSiparisDetayID"]));
                            SiparislerDetay.DoInsertISKs(siplerdet.pkSiparisDetayID, isks[10], isks[0], isks[1], isks[2], isks[3], isks[4], isks[5], isks[6], isks[7], isks[8], isks[9]);
                        }

                        //if (Siparis.mnToplamTutar != toplamtutar)
                        //{
                        //    Siparis.mnToplamTutar = toplamtutar;
                        //    Siparis.DoUpdate();
                        //}
                    }
                }
            }

            divSiparisKopyala.Visible = false;
            Response.Redirect("siparisler.aspx", true);
        }

        protected void lbSiparisKopyalaKapat_Click(object sender, EventArgs e)
        {
            divSiparisKopyala.Visible = false;
        }

        protected void lbSiparisKopyala2Tamamla_Click(object sender, EventArgs e)
        {
            int siparisid = Convert.ToInt32(Session["KopyalanacakSiparisID"]);

            Siparisler Oncekisiparis = Siparisler.GetObjectsBySiparisID(siparisid);

            for (int i = 1; i < cblSiparisKopyala2SevkYerleri.Items.Count; i++) // en başta seçim yok var
            {
                if (cblSiparisKopyala2SevkYerleri.Items[i].Selected)
                {
                    Siparisler Siparis = new Siparisler(((Musteriler)Session["Musteri"]).pkMusteriID,
                    Oncekisiparis.SMREF, Oncekisiparis.sintFiyatTipiID, DateTime.Now,
                    Oncekisiparis.mnToplamTutar, false, Oncekisiparis.TKSREF, DateTime.Now, Oncekisiparis.strAciklama);
                    Siparis.DoInsert();

                    DataTable dt = new DataTable();
                    SiparislerDetay.GetObjectsBySiparisID(dt, siparisid);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        SiparislerDetay siplerdet = new SiparislerDetay(Siparis.pkSiparisID, Convert.ToInt32(dt.Rows[j]["intUrunID"]),
                            dt.Rows[j]["strUrunAdi"].ToString(),
                            Convert.ToInt32(dt.Rows[j]["intMiktar"]), Convert.ToDecimal(dt.Rows[j]["mnFiyat"]),
                            Guid.Parse(dt.Rows[j]["unKampanyaKart"].ToString()), Convert.ToBoolean(dt.Rows[j]["blKampanyaHediye"]),
                            Guid.Parse(dt.Rows[j]["unKampanyaSatir"].ToString()), dt.Rows[j]["strMiktarTur"].ToString());
                        siplerdet.DoInsert();
                    }

                    if (!SiparisOnayla(Siparis.pkSiparisID, Convert.ToInt32(cblSiparisKopyala2SevkYerleri.Items[i].Value)))
                        divSiparisOnaylanamadi.Visible = true;
                }
            }

            Response.Redirect("siparisler.aspx", true);
        }

        protected void lbSiparisKopyala2Kapat_Click(object sender, EventArgs e)
        {
            divSiparisKopyala2.Visible = false;
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (siparisid != 0)
            {
                Session["downloadsiparisid"] = siparisid;
                divSiparisKaydet.Visible = true;
            }

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisKaydet, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisKaydetKapat_Click(object sender, EventArgs e)
        {
            divSiparisKaydet.Visible = false;
        }

        protected void ibYazdir_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (siparisid != 0)
            {
                Session["oncekiyazdirsiparisid"] = Session["yazdirsiparisid"];
                Session["yazdirsiparisid"] = siparisid;
            }
        }

        protected void ibEposta_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (siparisid != 0)
            {
                Siparisler sip = Siparisler.GetObjectsBySiparisID(siparisid);
                Musteriler mus = Musteriler.GetMusteriByID(sip.intMusteriID);
                DataTable dt = new DataTable();
                SiparislerDetay.GetObjectsBySiparisID(dt, siparisid, sip.sintFiyatTipiID, true);

                string siparisonaytarihi = "";
                if (sip.blAktarilmis)
                    siparisonaytarihi = sip.dtOnaylamaTarihi.ToShortDateString();

                lblEpostaGonder.Text = "<a href='mailto:?Subject=Sipariş No: " + sip.pkSiparisID.ToString() + "&Body=" +
                    "Siparişi Giren: " + mus.strAd + " " + mus.strSoyad + "%0A" +
                    "Cari Hesap: " + CariHesaplar.GetObjectBySMREF(sip.SMREF)[1].ToString() + "%0D%0A" +
                    "Fiyat Tipi: " + sip.sintFiyatTipiID.ToString() + " - " + FiyatTipleri.GetObjectByID(sip.sintFiyatTipiID) + "%0A" +
                    "Sipariş Oluşturma Tarihi: " + sip.dtOlusmaTarihi.ToShortDateString() + "%0A" +
                    "Sipariş Onay Tarihi: " + siparisonaytarihi + "%0A" +
                    "Vade: " + TaksitPlanlari.GetOdemePlani(sip.TKSREF) + "%0A" + "%0A";

                lblEpostaGonder.Text += "Barkod     Ürün Açıklama     KDV     Miktar     Brüt Fiyat     İskonto 1      İskonto 2     İskonto 3     İskonto 4     Toplam+KDV%0A";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblEpostaGonder.Text += dt.Rows[i]["BARKOD"].ToString() + "   ";
                    lblEpostaGonder.Text += dt.Rows[i]["strUrunAdi"].ToString() + "   ";
                    lblEpostaGonder.Text += dt.Rows[i]["KDV"].ToString() + "   ";
                    lblEpostaGonder.Text += dt.Rows[i]["intMiktar"].ToString() + "   ";
                    lblEpostaGonder.Text += Convert.ToDecimal(dt.Rows[i]["FIYAT"]).ToString("C3") + "   ";
                    lblEpostaGonder.Text += Convert.ToDouble(dt.Rows[i]["ISK1"]).ToString("N1") + "   ";
                    lblEpostaGonder.Text += Convert.ToDouble(dt.Rows[i]["ISK2"]).ToString("N1") + "   ";
                    lblEpostaGonder.Text += Convert.ToDouble(dt.Rows[i]["ISK3"]).ToString("N1") + "   ";
                    lblEpostaGonder.Text += Convert.ToDouble(dt.Rows[i]["ISK4"]).ToString("N1") + "   ";
                    lblEpostaGonder.Text += Convert.ToDecimal(dt.Rows[i]["mnFiyat"]).ToString("C3") + "%0A";
                }
                lblEpostaGonder.Text += "%0A                                                                 Genel Toplam + KDV: " + sip.mnToplamTutar.ToString("C3");

                if (lblEpostaGonder.Text.Length > 2000)
                {
                    lblEpostaGonder.Text = lblEpostaGonder.Text.Substring(0, 1800) + " ...";
                    lblEpostaGonder.Text += "%0A%0A                                                                 Genel Toplam + KDV: " + sip.mnToplamTutar.ToString("C3");
                }

                //HttpCookie cookie = new HttpCookie("SultanlarSiparisEposta", lblEpostaGonder.Text);
                //cookie.Expires = DateTime.Now.AddDays(1);
                //Response.Cookies.Add(cookie);

                lblEpostaGonder.Text += "'>Eposta oluşturuldu, göndermek için tıklayın.</a>";


                divSiparisEposta.Visible = true;
            }
        }

        protected void lbSiparisEpostaKapat_Click(object sender, EventArgs e)
        {
            divSiparisEposta.Visible = false;
        }
        
        protected void lbFiyatTipiKapat_Click(object sender, EventArgs e)
        {
            divFiyatTipi.Visible = false;
        }

        protected void lbRiskBakiyeHataKapat_Click(object sender, EventArgs e)
        {
            divRiskBakiyeHata.Visible = false;
        }

        protected void lbFiyatTipiYetkisiYokKapat_Click(object sender, EventArgs e)
        {
            divFiyatTipiYetkisiYok.Visible = false;
        }

        protected void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise ki öyle olmak zorunda
            {
                divOdemeYap.Visible = true;
                divOdemeYapUyari.Visible = ((Musteriler)Session["Musteri"]).strAd.StartsWith("J.Wax");
                Siparisler.GetSiparisIDToplamTutarOnaylamaTarihiByMusteriID(ddlOdemeYapSiparisler.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);
            }
        }

        protected void lbOdemeYapKapat_Click(object sender, EventArgs e)
        {
            divOdemeYap.Visible = false;
        }

        protected void ddlOdemeYapSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(ddlOdemeYapSiparisler.SelectedValue));
            Session["OdemeSiparisNo"] = siparis.pkSiparisID;
            Session["OdemeTutari"] = siparis.mnToplamTutar.ToString("N3");
            txtOdemeYapTutar.Text = siparis.mnToplamTutar.ToString("N3");
            Session["OdemeGMREF"] = 24479;
            divOdemeYap.Visible = false;
            divOdemeYap2.Visible = true;
        }

        protected void lbOdemeYapTutarDevamEt_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(Session["OdemeTutari"]) < Convert.ToDecimal(txtOdemeYapTutar.Text.Trim()))
            {
                divOdemeYap2Uyari.Visible = true;
                return;
            }

            Session["OdemeTutari"] = Convert.ToDecimal(txtOdemeYapTutar.Text.Trim());
            divOdemeYap2.Visible = false;
            divOdeme.Visible = true;
        }

        protected void btnSiparisVer_Click(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise ki öyle olmak zorunda
            {
                divFiyatTipi.Visible = true;
                GetFiyatTipleri();
            }
        }

        protected void ddlFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise ki öyle olmak zorunda
            {
                Session["SiparisID"] = 0;
                Session["SMREF"] = 0;
                Session["FiyatTipi"] = Convert.ToInt32(ddlFiyatTipleri.SelectedValue);
                Response.Redirect("siparis.aspx", true);
            }
        }

        protected void lbTarihKapat_Click(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                //GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID,
                //    Calendar1.SelectedDate, Calendar2.SelectedDate);
                //GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID,
                //    Calendar1.SelectedDate, Calendar2.SelectedDate, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
                GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                    {
                        GetSiparisCount();
                        GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                    {
                        GetSiparisCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF);
                        GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
                else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                {
                    //GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue),
                    //    Calendar1.SelectedDate, Calendar2.SelectedDate);
                    //GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue),
                    //    Calendar1.SelectedDate, Calendar2.SelectedDate, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    if (ddlCariHesaplar.SelectedIndex > -1)
                    {
                        GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
                else
                {
                    //GetSiparisCountBySMREF((int)Session["SiparisGetirilecekSMREF"],
                    //    Calendar1.SelectedDate, Calendar2.SelectedDate);
                    //GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"],
                    //    Calendar1.SelectedDate, Calendar2.SelectedDate, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    if (Session["SiparisGetirilecekSMREF"] != null)
                    {
                        GetSiparisCountBySMREF((int)Session["SiparisGetirilecekSMREF"]);
                        GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
            }

            divTarih.Visible = false;
        }

        protected void lbTarih_Click(object sender, EventArgs e)
        {
            divTarih.Visible = true;
        }

        protected void ibTarih_Click(object sender, ImageClickEventArgs e)
        {
            divTarih.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblTarihSecim1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            lblTarihSecim2.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void cbTariheGore_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTariheGore.Checked)
            {
                Calendar1.Enabled = true;
                Calendar2.Enabled = true;
            }
            else
            {
                Calendar1.Enabled = false;
                Calendar2.Enabled = false;
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
            }
        }

        protected void rbSiparislerHepsi_Checked(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
                GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                    {
                        GetSiparisCount();
                        GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
                    {
                        GetSiparisCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF);
                        GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
                else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else                                                                // şube seçilmişse
                {
                    if (Session["SiparisGetirilecekSMREF"] != null)
                    {
                        GetSiparisCountBySMREF((int)Session["SiparisGetirilecekSMREF"]);
                        GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
            }



            cbSiparislerSecimTumu.Checked = false;
            if (rbSiparislerHepsi.Checked)
            {
                btnTumunuOnayla.Enabled = false;
                btnTumunuSil.Enabled = false;
            }
            else if (rbSiparislerOnaylilar.Checked)
            {
                btnTumunuOnayla.Enabled = false;
                btnTumunuSil.Enabled = false;
            }
            else if (rbSiparislerOnaysizlar.Checked)
            {
                btnTumunuOnayla.Enabled = false; //
                btnTumunuSil.Enabled = true;
            }
        }

        protected void lbOdemeVazgec_Click(object sender, EventArgs e)
        {
            divOdeme.Visible = false;
            if (Session["OdemeYapildi"] == null)
                divSevkYerleri.Visible = false;
        }

        protected void ibOdemeDetayi_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            Odemeler odeme = Odemeler.GetObjectBySiparisID(siparisid);
            lblOdemeAyrintiSiparisNo.Text = odeme.intSiparisID.ToString();
            lblOdemeAyrintiKrediKart.Text = odeme.strMaskedPan;
            lblOdemeAyrintiTutar.Text = odeme.mnTutar.ToString("C3");
            lblOdemeAyrintiTarih.Text = odeme.dtOdemeZamani.ToString();
            lblOdemeAyrintiAuth.Text = odeme.strAuthCode;
            lblOdemeAyrintiHostRef.Text = odeme.strHostRefNum;
            lblOdemeAyrintiTransID.Text = odeme.strTransId;

            Session["OdemeAyrintiYazdir"] = odeme;
            divOdemeAyrinti.Visible = true;
            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divOdemeAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void ibOdemeAyrintiYazdir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lbOdemeAyrintiKapat_Click(object sender, EventArgs e)
        {
            Session["OdemeAyrintiYazdir"] = null;
            divOdemeAyrinti.Visible = false;
        }

        protected void lbToplamTutarSifirKapat_Click(object sender, EventArgs e)
        {
            divToplamTutarSifir.Visible = false;
        }

        protected void lbSiparisAktarilmisHata_Click(object sender, EventArgs e)
        {
            divSiparisAktarilmisHata.Visible = false;
        }

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty)
            {
                return;
            }
            else if (rbCariHesapUye.Checked)
            {
                ddlTemsilciler.SelectedIndex = 1;
                GetSiparisCount();
                GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                return;
            }

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;
            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();

            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
            lblDipToplam.Text = "0,000 TL";

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

            //dlSiparisler.DataSource = null;
            //dlSiparisler.DataBind();
        }

        protected void dlSiparisler_DataBound(object sender, EventArgs e)
        {
            lblSiparisYok.Visible = dlSiparisler.Items.Count == 0;
        }

        private void SayfaToplami()
        {
            //decimal toplam = 0;

            //foreach (Control ctrl in dlSiparisler.Controls)
            //    foreach (Control ctrl2 in ctrl.Controls)
            //        if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden && ctrl2.ID.StartsWith("mnToplamTutar"))
            //            toplam += Convert.ToDecimal(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);

            //lblSayfaToplami.Text = toplam.ToString("C3");
        }

        protected void lbStokYetersizEvet_Click(object sender, EventArgs e)
        {
            Session["SiparisTamamlaOnaylaBasildi"] = null;
            divStokYetersiz.Visible = false;

            divSevkYerleri.Visible = true;
            tblSevk.Visible = false;
            tblAdresler.Visible = true;
            GetAdresler();

            if (((Siparisler)Session["StokYetersizPerakendeSiparis"]).sintFiyatTipiID != 13 && !Odemeler.GetSiparisOdemeYapildiMi(((Siparisler)Session["StokYetersizPerakendeSiparis"]).pkSiparisID)) // ödeme yapılmış sipariş ise ödeme ekranı açılmayacak, jwax ödemesi internetten olmayacak
            {
                Session["OdemeSiparisNo"] = ((Siparisler)Session["StokYetersizPerakendeSiparis"]).pkSiparisID;
                Session["OdemeTutari"] = ((Siparisler)Session["StokYetersizPerakendeSiparis"]).mnToplamTutar;
                Session["OdemeGMREF"] = 24479;
                divOdeme.Visible = true;
            }

            Session["StokYetersizPerakendeSiparis"] = null;
        }

        protected void lbStokYetersizHayir_Click(object sender, EventArgs e)
        {
            Session["SiparisTamamlaOnaylaBasildi"] = null;
            Session["StokYetersizPerakendeSiparis"] = null;
            divStokYetersiz.Visible = false;
        }

        protected void lbSiparisOnaylanamadiKapat_Click(object sender, EventArgs e)
        {
            divSiparisOnaylanamadi.Visible = false;
            divSiparisOnaylamama.Visible = false;
        }

        protected void cbSiparislerSecimTumu_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in dlSiparisler.Controls)
                foreach (Control ctrl2 in ctrl.Controls)
                    if (ctrl2 is CheckBox)
                        ((CheckBox)ctrl2).Checked = cbSiparislerSecimTumu.Checked;
        }

        protected void btnTumunuOnayla_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in dlSiparisler.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is CheckBox)
                    {
                        if (((CheckBox)ctrl2).Checked)
                        {
                            int siparisid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);

                            if (!SiparisOnayla(siparisid, 0)) // birisi onaylanmadı
                                divSiparisOnaylanamadi.Visible = true;
                        }
                    }
                }
            }

            SiparisListesiniYenile();
            cbSiparislerSecimTumu.Checked = false;
        }

        protected void btnTumunuSil_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in dlSiparisler.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is CheckBox)
                    {
                        if (((CheckBox)ctrl2).Checked)
                        {
                            int siparisid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);
                            Siparisler.DoDeleteWithSiparislerDetays(siparisid);
                        }
                    }
                }
            }

            SiparisListesiniYenile();
            cbSiparislerSecimTumu.Checked = false;
        }

        protected void lbDurumKapat_Click(object sender, EventArgs e)
        {
            divDurum.Visible = false;
        }

        protected void ibDurum_Click(object sender, ImageClickEventArgs e)
        {
            string siparisid = "";

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SiparisID"))
                    {
                        siparisid = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            if (siparisid != "")
            {
                DataTable dt = new DataTable();
                SAPs.GetDurum(dt, Convert.ToInt32(siparisid), 0);
                rptDurum.DataSource = dt;
                rptDurum.DataBind();

                tblDurumBaslik.Visible = false;
                divDurum.Visible = true;
                lbDurumSiparisNo.Text = siparisid;

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divDurum, typeof(string), "scriptSayfayukaricikar", alert, false);
            }
        }

        protected void lbDurumGetir_Click(object sender, EventArgs e)
        {
            int siparisid = txtDurumWebNo.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txtDurumWebNo.Text.Trim());
            int sapsipid = txtDurumSapNo.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txtDurumSapNo.Text.Trim());

            DataTable dt = new DataTable();
            SAPs.GetDurum(dt, siparisid, sapsipid);
            rptDurum.DataSource = dt;
            rptDurum.DataBind();
        }

        protected void btnDurumlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SAPs.GetDurum(dt, 10, 10);
            rptDurum.DataSource = dt;
            rptDurum.DataBind();

            tblDurumBaslik.Visible = true;
            divDurum.Visible = true;
        }

        protected void lbDurumSiparisNo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SAPs.GetDurum(dt, Convert.ToInt32(lbDurumSiparisNo.Text), 0);

            Siparisler sip = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(lbDurumSiparisNo.Text));
            Siparisler sipy = new Siparisler(sip.intMusteriID, sip.SMREF, sip.sintFiyatTipiID, DateTime.Now, 0, false, 0, DateTime.Now, sip.strAciklama);
            sipy.DoInsert();

            int urunsayisi = 0;
            decimal toplamtutar = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["BKY_AD"]) > 0)
                {
                    SiparislerDetay sipdety = new SiparislerDetay(sipy.pkSiparisID,
                        Convert.ToInt32(dt.Rows[i]["MALZ_KOD"]),
                        Urunler.GetProductName(Convert.ToInt32(dt.Rows[i]["MALZ_KOD"])),
                        Convert.ToInt32(dt.Rows[i]["BKY_AD"]),
                        Urunler.GetProductPrice(Convert.ToInt32(dt.Rows[i]["MALZ_KOD"]), sipy.sintFiyatTipiID),
                        Guid.Empty,
                        false,
                        Guid.Empty,
                        "ST");
                    sipdety.DoInsert();
                    toplamtutar += sipdety.mnFiyat * sipdety.intMiktar;
                    urunsayisi++;
                }
            }

            if (urunsayisi == 0)
            {
                sipy.DoDelete();
                string alert = "<script type='text/javascript'>alert('Bakiye kalan ürün bulunamadığından sipariş oluşturulmadı.');</script>";
                ScriptManager.RegisterStartupScript(divDurum, typeof(string), "scriptSayfayukaricikar", alert, false);
            }
            else
            {
                sipy.mnToplamTutar = toplamtutar;
                sipy.DoUpdate();
                Response.Redirect("siparisler.aspx", true);
            }
        }

        protected void ddlSefAltlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int musteriid = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlSefAltlarBayiSatici.SelectedValue));
            if (musteriid > 0)
            {
                Session["SiparisSahibiMusteriID"] = musteriid;
                Session["SiparisGirenMusteriID"] = ((Musteriler)Session["Musteri"]).pkMusteriID;

                Session["IadeSahibiMusteriID"] = musteriid;
                Session["IadeGirenMusteriID"] = ((Musteriler)Session["Musteri"]).pkMusteriID;
            }

            GetCariHesaplar();
        }

        protected void btnExceldenSiparis_Click(object sender, EventArgs e)
        {
            if (fuExcel.HasFile)
            {
                string filename = Server.MapPath("~/musteri/temp/") + "excelsip" + ((Musteriler)Session["Musteri"]).pkMusteriID.ToString() + ".xls";
                fuExcel.SaveAs(filename);
                ExceldenAl(filename);
            }
        }

        protected void lbExcelSiparisKapat_Click(object sender, EventArgs e)
        {
            divExcelSiparisHata.Visible = false;
        }

        private void ExceldenAl(string dosya)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya, false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                if (dosya.EndsWith(".xls"))
                    range = ws.get_Range("A1", "K65535");
                else
                    range = ws.get_Range("A1", "K1000000");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                divExcelSiparisHata.Visible = true;
                return;
            }
            finally
            {
                range = null;
                ws = null;
                if (wb != null)
                    wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                wb = null;
                if (ap != null)
                    ap.Quit();
                ap = null;
            }

            #region musteri yetkisi
            DataTable dt = new DataTable();
            CariHesaplar.GetSMREFsBySLSREF(dt, ((Musteriler)Session["Musteri"]).intSLSREF);
            bool var = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(values[1, 1]) == Convert.ToInt32(dt.Rows[i][0]))
                {
                    var = true;
                    break;
                }
            }
            #endregion

            #region fiyattipi yetkisi
            bool var1 = false;
            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                if (Convert.ToInt16(values[2, 1]) == Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]))
                {
                    var1 = true;
                    break;
                }
            }
            #endregion

            if (!var || !var1)
            {
                divExcelSiparisHata.Visible = true;
                System.IO.File.Delete(dosya);
                return;
            }

            Siparisler sip = new Siparisler(
                ((Musteriler)Session["Musteri"]).pkMusteriID,
                Convert.ToInt32(values[1, 1]),
                Convert.ToInt16(values[2, 1]),
                DateTime.Now,
                0,
                false,
                0,
                DateTime.Now,
                ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + values[3, 1].ToString() + "(Excel'den girildi);;;" + DateTime.Now.ToShortDateString());
            sip.DoInsert();

            decimal toplamtutar = 0;
            int ortvade = 0;
            int ortvade1 = 0;
            for (int i = 4; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null) // 4.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    if (Urunler.GetProductName(Convert.ToInt32(values[i, 1])) != "-hata-")
                    {
                        SiparislerDetay sipdet = new SiparislerDetay(
                            sip.pkSiparisID,
                            Convert.ToInt32(values[i, 1]),
                            Urunler.GetProductName(Convert.ToInt32(values[i, 1])),
                            Convert.ToInt32(values[i, 2]),
                            Urunler.GetProductPrice(Convert.ToInt32(values[i, 1]), sip.sintFiyatTipiID),
                            Guid.Empty,
                            false,
                            Guid.Empty,
                            "ST");
                        sipdet.DoInsert();
                        toplamtutar += sipdet.intMiktar * sipdet.mnFiyat;
                        ortvade += Urunler.GetProductVade(sipdet.intUrunID, sip.sintFiyatTipiID);
                        ortvade1++;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            sip.TKSREF = TaksitPlanlari.GetODMREF(ortvade / ortvade1);
            sip.mnToplamTutar = toplamtutar;
            sip.DoUpdate();

            System.IO.File.Delete(dosya);
            Response.Redirect("siparisler.aspx", true);
        }

        #region Kontroller autopostback false iken getir tuşu
        //protected void btnSiparislerGetir_Click(object sender, EventArgs e)
        //{
        //    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
        //    {
        //        GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
        //        GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //    }
        //    else
        //    {
        //        if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
        //        {
        //            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
        //            {
        //                GetSiparisCount();
        //                GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //            }
        //            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // şef ise
        //            {
        //                GetSiparisCountBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF);
        //                GetSiparislerBySLSREFs(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //            }
        //        }
        //        else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
        //        {
        //            GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
        //            GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //        }
        //        else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
        //        {
        //            GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
        //            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //        }
        //        else                                                                // şube seçilmişse
        //        {
        //            if (Session["SiparisGetirilecekSMREF"] != null)
        //            {
        //                GetSiparisCountBySMREF((int)Session["SiparisGetirilecekSMREF"]);
        //                GetSiparislerBySMREF((int)Session["SiparisGetirilecekSMREF"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}