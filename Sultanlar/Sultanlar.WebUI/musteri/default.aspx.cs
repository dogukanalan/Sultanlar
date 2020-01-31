using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
// anlaşmalı noktalarda f3 ve f7 siparişlerini engellemek için divAnlasmaliFiyatHata arat (sipariş kopyalamayı da engelle)
namespace Sultanlar.WebUI.musteri
{
    /// <summary>
    /// ListItemCollection larda value nun başına text in ilk 3 hanesi GELMİYOR
    /// </summary>
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 8) // sd elemanı
                Response.Redirect("defaultsd.aspx", true);

            cbButunUrunler.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID != 1;
            cbHizliSiparis.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID != 1;

            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now;
                Calendar2.SelectedDate = DateTime.Now;
                Calendar3.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar4.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());

                tdEFatura.Visible = ((Musteriler)Session["Musteri"]).intGMREF > 0;
                tdSaticiKampanya.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 ||  !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                td500.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdAdresBankasi.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdKimNe.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdFormlar.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdRutlar.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdKonumlar.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdResimler.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdDestek.Visible = ((Musteriler)Session["Musteri"]).intGMREF == 0 && (((Musteriler)Session["Musteri"]).intSLSREF == 0 || !SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"));
                tdGorseller.Visible = true;
                tdBrosurler.Visible = true;
                tdBrosurler2.Visible = true;
                tdBrosurler3.Visible = true;
                tdBrosurler4.Visible = true;
                tdBrosurler5.Visible = true;
                tdBrosurler6.Visible = true;

                tableAsagi.Visible = !((Musteriler)Session["Musteri"]).blSicakSatis;
                tdFiyatInceleme.Visible = !((Musteriler)Session["Musteri"]).blSicakSatis;

                int sonyarimsiparis = ((Musteriler)Session["Musteri"]).intSonYarimSiparisID;
                if (sonyarimsiparis > 0 && Siparisler.GetObjectsBySiparisID(sonyarimsiparis).pkSiparisID != 0)
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

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    SatisTemsilcileri.GetObjectsFromCariHesaplar(ddlSefAltlar.Items);
                    //SatisTemsilcileri.GetObjects(ddlSefAltlar.Items, true, false); ddlSefAltlar.Items.RemoveAt(0); ddlSefAltlar.SelectedIndex = 0;

                    GetRutlar(Convert.ToInt32(ddlSefAltlar.SelectedValue));

                    divSefAltlar.Visible = true;
                    ibCHduzenle.Visible = true;
                    //spanCHeklemecikarma.Visible = true;
                    //divCHarama.Visible = true;
                    //hlSatistaOnAdim.Visible = true;
                    
                    int musteriid = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));
                    if (musteriid > 0)
                    {
                        Session["SiparisSahibiMusteriID"] = musteriid;
                        Session["SiparisGirenMusteriID"] = ((Musteriler)Session["Musteri"]).pkMusteriID;

                        Session["IadeSahibiMusteriID"] = musteriid;
                        Session["IadeGirenMusteriID"] = ((Musteriler)Session["Musteri"]).pkMusteriID;
                    }
                }

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    Response.Redirect("siparisler.aspx", true);

                if (((Musteriler)Session["Musteri"]).intSLSREF > 0 && ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
                {
                    inputBayiGibi.Value = "0";
                    GetRutlar(((Musteriler)Session["Musteri"]).intSLSREF);

                    //divCHarama.Visible = true;
                    //hlSatistaOnAdim.Visible = true;

                    ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
                    if (altlar.Count > 0) // şef ise
                    {
                        //if (SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"))
                        //{
                            ibCHduzenle.Visible = true;
                            //spanCHeklemecikarma.Visible = true;
                        //}

                        divSefAltlar.Visible = true;
                        SatisTemsilcileriSefler.GetAltlar(ddlSefAltlar.Items, ((Musteriler)Session["Musteri"]).intSLSREF);

                        /*SAP*/
                        if (ddlSefAltlar.Items.Count > 0)
                            ddlSefAltlar.Items.FindByValue(((Musteriler)Session["Musteri"]).intSLSREF.ToString()).Selected = true;
                        else
                            ddlSefAltlar.Items.Add(new ListItem("-", ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    }
                }

                if (((Musteriler)Session["Musteri"]).intSLSREF > 0 && ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                {
                    inputBayiGibi.Value = "1";
                    GetRutlar(((Musteriler)Session["Musteri"]).intSLSREF);
                }

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 9) // bayi elemanı ise
                {
                    divMusteriSiparisIadeButton.Visible = false;
                    inputBayiGibi.Value = "2";
                }

                GetCariHesaplar();
                GetFiyatListeleri();


                if (Session["Ziyaret"] != null)
                {
                    foreach (Control ctrl in dlRutlar.Controls) // datalist in kontrolleri
                        foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                            if (ctrl2 is System.Web.UI.HtmlControls.HtmlTableRow) // tr ise
                                if (((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).Attributes["title"] == ((SatisTemsilcisiZiyaretler)Session["Ziyaret"]).intSMREF.ToString())
                                    foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                                        foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                                            if (ctrl4 is LinkButton)
                                                if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretSonlandir"))
                                                    ((LinkButton)ctrl4).Enabled = true;

                    lbFarkliZiyaretAc.Enabled = false;

                    foreach (Control ctrl in dlRutlar.Controls) // datalist in kontrolleri
                        foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                            foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                                foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                                    if (ctrl4 is LinkButton)
                                        if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretBaslat"))
                                            ((LinkButton)ctrl4).Enabled = false;
                }

                //if (Session["ZiyaretCerezAlinamadi"] != null)
                //{
                //    Session["ZiyaretCerezAlinamadi"] = null;
                //    divZiyaretKonumAlinamadi.Visible = true;
                //}
            }

            if (Session["Ziyaret"] != null)
            {
                lbZiyaretSonlandirUst.Visible = true;
                divZiyaret.Visible = true;

                SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["Ziyaret"];
                int MTIP = Convert.ToInt32(stz.strMekan.Substring(0, 1));
                lblZiyaretSubesi.Text = MTIP == 1 ? CariHesaplar.GetSUBEbySMREF(stz.intSMREF) : MTIP == 4 ? CariHesaplarTP.GetSubelerBySMREF(stz.intSMREF)[1].ToString() : CariHesapZ.GetObject(stz.intSMREF, MTIP, true).SUBE;
                lblZiyaretBaslangic.Text = stz.dtZiyaretBaslangic.ToString();
            }
            else
            {
                lbZiyaretSonlandirUst.Visible = false;
                divZiyaret.Visible = false;
                lblZiyaretSubesi.Text = string.Empty;
                lblZiyaretBaslangic.Text = string.Empty;
            }

            if (((Musteriler)Session["Musteri"]).intSLSREF > 0 && (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 9)) // satış temsilcisi ise
            {
                lbFarkliZiyaretAc.Visible = SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8") ? false : true;
                lbSonZiyaret.Visible = SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8") ? false : true;
            }
            else
            {
                lbFarkliZiyaretAc.Visible = false;
                lbSonZiyaret.Visible = false;
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"click\" });});</script>";
            ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "kucukbilgi", alert, false);

            string alert2 = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGosterSade\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "kucukbilgi2", alert2, false);
        }

        private void GetFiyatListeleri()
        {
            DataTable dt = new DataTable();
            FiyatListeleri.GetObjects(dt, ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler);
            rpFiyatListeleri.DataSource = dt;
            rpFiyatListeleri.DataBind();
        }

        private void GetRutlar(int SLSREF)
        {
            bool bayi = inputBayiGibi.Value == "1" ? true : false;
            tblRutlar.Visible = true;
            DataTable dt = new DataTable();
            Rutlar.GetObjectsBySLSREF(dt, SLSREF, Calendar1.SelectedDate, Calendar2.SelectedDate, bayi);
            dlRutlar.DataSource = dt;
            dlRutlar.DataBind();
            //lblRutYok.Visible = dt.Rows.Count == 0;
        }

        private void GetCariHesaplar()
        {
            DataTable dt = new DataTable();
            int GMREF = ((Musteriler)Session["Musteri"]).intGMREF;
            int SLSREF = ((Musteriler)Session["Musteri"]).intSLSREF;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                divMusteriSiparisIadeButton.Visible = false;
                dlCariHesaplarSube.Visible = false;
                dlSatTemCariler.Visible = true;

                btnAltCari.Visible = true;
                btnGenelAktivite.Visible = true;

                int musteriid = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));


                CariHesaplar.GetObjectsBySLSREF(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), true);

                DataRow dRow = dt.NewRow();
                dRow["GMREF"] = 0;
                dRow["SMREF"] = 0;
                dRow["MUS KOD"] = "--------";
                dRow["MUSTERI"] = "---------------------------";
                dt.Rows.Add(dRow);

                CariHesaplar.GetObjectsBySLSREF(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), false);

                if (dt.Rows[dt.Rows.Count - 1]["MUS KOD"].ToString() == "--------")
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                else if (dt.Rows[0]["MUS KOD"].ToString() == "--------")
                    dt.Rows.RemoveAt(0);

                dlSatTemCariler.DataSource = dt;
                dlSatTemCariler.DataBind();
            }

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 9) // müşteri ise ve bayi elemanı ise
            {
                CariHesaplar.GetObjectByGMREF(dt, GMREF);
                dlCariHesaplar.DataSource = dt;
                dlCariHesaplar.DataBind();

                if (CariHesaplar.AnaSubeMi(GMREF))
                {
                    divMusteriSiparisIadeButton.Visible = false;
                    dlCariHesaplarSube.Visible = true;

                    dt = new DataTable();
                    CariHesaplar.GetSubeler(dt, GMREF);
                    dlCariHesaplarSube.DataSource = dt;
                    dlCariHesaplarSube.DataBind();
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4/* || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2*/) // satış temsilcisi ise (veya yönetici)
            {
                divMusteriSiparisIadeButton.Visible = false;
                dlCariHesaplarSube.Visible = false;
                dlSatTemCariler.Visible = true;

                ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
                //Session["SefSLSREFs"] = altlar;

                if (altlar.Count == 0)  // şef değil ise
                {
                    // ana cariye bağlı olmayan tek cariler
                    CariHesaplar.GetTekCarilerBySLSREF(dt, SLSREF, true);

                    // grup şirketlerinin ana carileri
                    ArrayList anacariler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(SLSREF);

                    if (anacariler.Count != 0 && dt.Rows.Count > 0)
                    {
                        DataRow dRow = dt.NewRow();
                        dRow["GMREF"] = 0;
                        dRow["SMREF"] = 0;
                        dRow["MUS KOD"] = "--------";
                        dRow["MUSTERI"] = "---------------------------";
                        dt.Rows.Add(dRow);
                    }

                    for (int i = 0; i < anacariler.Count; i++)
                    {
                        DataTable dtAna = new DataTable();
                        CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacariler[i]), SLSREF, true);

                        DataRow drow = dt.NewRow();
                        for (int j = 0; j < dtAna.Columns.Count; j++)
                        {
                            drow[j] = dtAna.Rows[0][j];
                        }
                        dt.Rows.Add(drow);
                    }

                    dlSatTemCariler.DataSource = dt;
                    dlSatTemCariler.DataBind();
                }
                else // şef ise
                {
                    if (Session["SefMusteriListesi2"] == null)
                    {
                        //ArrayList anacarigmrefler = new ArrayList();

                        //for (int i = 0; i < altlar.Count; i++)
                        //{
                        //    // ana cariye bağlı olmayan tek cariler
                        //    CariHesaplar.GetTekCarilerBySLSREF(dt, Convert.ToInt32(altlar[i]), true, true, 0);

                        //    // bu alt slsref in grup şirketlerinin ana carileri
                        //    CariHesaplar.GetAnaCarilerGMREFBySLSREF(anacarigmrefler, Convert.ToInt32(altlar[i]));
                        //}

                        //CariHesaplar.GetObjectsBySLSREFs(dt, altlar, true);

                        CariHesaplar.GetObjectsBySLSREF(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), true);

                        DataRow dRow = dt.NewRow();
                        dRow["GMREF"] = 0;
                        dRow["SMREF"] = 0;
                        dRow["MUS KOD"] = "--------";
                        dRow["MUSTERI"] = "---------------------------";
                        dt.Rows.Add(dRow);

                        //for (int i = 0; i < anacarigmrefler.Count; i++)
                        //{
                        //    DataTable dtAna = new DataTable();
                        //    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacarigmrefler[i]), true, true);

                        //    DataRow drow = dt.NewRow();
                        //    for (int j = 0; j < dtAna.Columns.Count; j++)
                        //    {
                        //        drow[j] = dtAna.Rows[0][j];
                        //    }
                        //    dt.Rows.Add(drow);
                        //}

                        //CariHesaplar.GetObjectsBySLSREFs(dt, altlar, false);

                        CariHesaplar.GetObjectsBySLSREF(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), false);

                        if (dt.Rows[dt.Rows.Count - 1]["MUS KOD"].ToString() == "--------")
                            dt.Rows.RemoveAt(dt.Rows.Count - 1);
                        else if (dt.Rows[0]["MUS KOD"].ToString() == "--------")
                            dt.Rows.RemoveAt(0);

                        dlSatTemCariler.DataSource = dt;
                        dlSatTemCariler.DataBind();

                        //Session["SefMusteriListesi2"] = dt;
                    }
                    else
                    {
                        dlSatTemCariler.DataSource = (DataTable)Session["SefMusteriListesi2"];
                        dlSatTemCariler.DataBind();
                    }
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
            {
                inputBayiGibi.Value = "1";
                divMusteriSiparisIadeButton.Visible = false;
                dlCariHesaplarSube.Visible = false;
                dlSatTemCariler.Visible = true;
                tdSaticiKampanya.Visible = false;
                td500.Visible = false;

                CariHesaplar.GetTekCarilerBySLSREF(dt, ((Musteriler)Session["Musteri"]).intSLSREF, true);

                // grup şirketlerinin ana carileri
                ArrayList anacariler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);

                if (anacariler.Count != 0 && dt.Rows.Count > 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["GMREF"] = 0;
                    dRow["SMREF"] = 0;
                    dRow["MUS KOD"] = "--------";
                    dRow["MUSTERI"] = "---------------------------";
                    dt.Rows.Add(dRow);
                }

                for (int i = 0; i < anacariler.Count; i++)
                {
                    DataTable dtAna = new DataTable();
                    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacariler[i]), ((Musteriler)Session["Musteri"]).intSLSREF, true);

                    DataRow drow = dt.NewRow();
                    for (int j = 0; j < dtAna.Columns.Count; j++)
                    {
                        drow[j] = dtAna.Rows[0][j];
                    }
                    dt.Rows.Add(drow);
                }

                dlSatTemCariler.DataSource = dt;
                dlSatTemCariler.DataBind();
            }
        }

        private void GetFiyatTipleri()
        {
            ddlFiyatTipleri.Items.Clear();
            ddlFiyatTipleri.Items.Add("Seçiniz");
            ddlFiyatTipleri.Items[0].Value = "0";

            ArrayList fiyattipler = new ArrayList();
            if (ddlSefAltlar.Items.Count > 0)
                fiyattipler = new UyeYetkileri(Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue))).FiyatTipler;
            else
                fiyattipler = ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler;

            int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Session["SMREF"]));
            int besyuzfiyattipmi = FiyatTipleri.GetFiyatTipByGMREF(GMREF);
            if (besyuzfiyattipmi > 500)
            {
                fiyattipler.Clear();
                fiyattipler.Add((short)besyuzfiyattipmi);
            }

            for (int i = 0; i < fiyattipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(fiyattipler[i]);
                string fiyattipi = FiyatTipleri.GetObjectByID(fiyattipiid);

                ddlFiyatTipleri.Items.Add(fiyattipi != "" ? fiyattipi : fiyattipiid.ToString());
                ddlFiyatTipleri.Items[i + 1].Value = fiyattipiid.ToString();
            }

            if (Session["SMREF"] == null)
            {
                if (Session["LinkButton"] != null)
                {
                    foreach (Control ctrl in ((LinkButton)Session["LinkButton"]).Parent.Controls)
                    {
                        if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                        {
                            if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                            {
                                Session["SMREF"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                                Session["LinkButton"] = null;
                            }
                        }
                    }
                }
            }

            

            if (Convert.ToInt32(Session["SMREF"]) != 0 && ddlFiyatTipleri.Items.Count > 1)
            {
                lblFiyatTipCH.Text = CariHesaplar.GetSUBEbySMREF(Convert.ToInt32(Session["SMREF"]));
                if (lblFiyatTipCH.Text.Trim() == string.Empty)
                    lblFiyatTipCH.Text = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(Session["SMREF"]));
            }



            Session["Yetkiler"] = new UyeYetkileri(((Musteriler)Session["Musteri"]).pkMusteriID); // yetkileri eskiye dönüştürmek lazım



            if (false) // ddlFiyatTipleri.Items.Count == 2 && besyuzfiyattipmi < 500
            {
                if (divMusteriSiparisIadeButton.Visible) // şubesiz cari siparişi veriliyorsa
                {
                    Session["SMREF"] = ((Musteriler)Session["Musteri"]).intGMREF;
                }
                else
                {
                    if (Session["LinkButton"] != null)
                    {
                        foreach (Control ctrl in ((LinkButton)Session["LinkButton"]).Parent.Controls)
                        {
                            if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                            {
                                if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                                {
                                    Session["SMREF"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                                    Session["LinkButton"] = null;
                                }
                            }
                        }
                    }
                }

                Session["RISKBAKIYE"] = CariHesaplar.GetRISKBKYByGMREF(GMREF); // sadece sipariş sayfasında geçişte kullanılacak
                if (ddlFiyatTipleri.Items.Count == 2) // tek fiyat tipinde yetkili ise
                    Session["FiyatTipi"] = Convert.ToInt16(ddlFiyatTipleri.Items[ddlFiyatTipleri.Items.Count - 1].Value); // sadece siparis sayfasinda geciste kullanilacak
                else
                    Session["FiyatTipi"] = Convert.ToInt16(ddlFiyatTipleri.SelectedValue); // sadece siparis sayfasinda geciste kullanilacak

                if (CariHesaplar.GetRISKLMTByGMREF(GMREF) > -1) // risk limiti 10 dan küçük ise sipariş veremeyecek
                {
                    int anlasmaid = Anlasmalar.GetSonAnlasmaID(GMREF, DateTime.Now, "2");
                    if (anlasmaid > 0 && (ddlFiyatTipleri.SelectedItem.Value == "3" || ddlFiyatTipleri.SelectedItem.Value == "4" || ddlFiyatTipleri.SelectedItem.Value == "7" || ddlFiyatTipleri.SelectedItem.Value == "8"))
                    {
                        Session["SMREF"] = null;
                        Session["RISKBAKIYE"] = null;
                        Session["FiyatTipi"] = null;
                        divAnlasmaliFiyatHata.Visible = true;
                        return;
                    }
                    else if (FiyatTipleri.GetFiyatTipByGMREF(GMREF) > 0 && ddlFiyatTipleri.SelectedItem.Value == "2")
                    {
                        Session["SMREF"] = null;
                        Session["RISKBAKIYE"] = null;
                        Session["FiyatTipi"] = null;
                        divAnlasmaliFiyatHata.Visible = true;
                        return;
                    }

                    Session["SiparisID"] = 0;
                    Response.Redirect("siparis.aspx", true);
                }
                else
                {
                    Session["SMREF"] = null;
                    Session["RISKBAKIYE"] = null;
                    Session["FiyatTipi"] = null;
                    divRiskLimitHata.Visible = true;
                }
            }
        }

        private void GetFiyatTipleriAktivite()
        {
            ddlFiyatTipleri.Items.Clear();
            ddlFiyatTipleri.Items.Add("Seçiniz");
            ddlFiyatTipleri.Items[0].Value = "0";

            ddlFiyatTipleri.Items.Add("25");
            ddlFiyatTipleri.Items[1].Value = "25";

            if (Session["SMREFakt"] == null)
            {
                if (Session["LinkButton"] != null)
                {
                    foreach (Control ctrl in ((LinkButton)Session["LinkButton"]).Parent.Controls)
                    {
                        if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                        {
                            if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                            {
                                Session["SMREFakt"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                                Session["LinkButton"] = null;
                            }
                        }
                    }
                }
            }

            if (ddlFiyatTipleri.Items.Count == 2)
            {
                if (ddlFiyatTipleri.Items.Count == 2) // tek fiyat tipinde yetkili ise
                    Session["FiyatTipi"] = Convert.ToInt16(ddlFiyatTipleri.Items[ddlFiyatTipleri.Items.Count - 1].Value); // sadece siparis sayfasinda geciste kullanilacak
                else
                    Session["FiyatTipi"] = Convert.ToInt16(ddlFiyatTipleri.SelectedValue); // sadece siparis sayfasinda geciste kullanilacak

                if (Session["Aktivite"] != null)
                {
                    Session["AktiviteID"] = (bool)Session["Aktivite"] == true ? 0 : 1;
                    Session["Aktivite"] = null;
                    Response.Redirect("aktivite.aspx", true);
                }
                else
                {
                    Session["SMREFakt"] = null;
                    Session["FiyatTipi"] = null;
                    Session["Aktivite"] = null;
                    divFiyatTipi.Visible = false;
                }
            }
        }

        private bool ZiyaretBaslat(int SMREF, string BARKOD, DateTime ZIYGUN, int MTIP, out bool konumyok, out bool mevcutkonumyok)
        {
            bool donendeger = true;
            konumyok = false;
            mevcutkonumyok = false;

            int GMREF = MTIP == 4 ? CariHesaplarTP.GetGMREFBySMREF(SMREF) : MTIP == 2 || MTIP == 3 || MTIP == 5 ? CariHesapZ.GetObject(SMREF, MTIP, true).GMREF : CariHesaplar.GetGMREFBySMREF(SMREF);

            bool bugunyapildi = SatisTemsilcisiZiyaretler.GetObjectsBySLSREFSMREF(((Musteriler)Session["Musteri"]).intSLSREF, SMREF, DateTime.Now);
            BARKOD = bugunyapildi ? ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + DateTime.Now.ToString().Replace(" ", ".") : BARKOD;

            DataTable dt = new DataTable();
            SatisTemsilcisiZiyaretler.GetObjectLast(dt, ((Musteriler)Session["Musteri"]).intSLSREF);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["dtZiyaretBitis"].ToString() == "" && Convert.ToDateTime(dt.Rows[0]["dtZiyaretBaslangic"]).ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                    ScriptManager.RegisterStartupScript(divZiyaretHata, typeof(string), "scriptSayfayukaricikar", alert, false);

                    konumyok = false;
                    return false;
                }
            }

            if (txtCoords1.Text == "0,0")
            {
                mevcutkonumyok = true;
                return false;
            }

            if (Rutlar.GetKonum(SMREF, MTIP) == string.Empty)
            {
                konumyok = true;
                return false;
            }

            string koordinatlar = MTIP.ToString() + ";;;" + txtCoords1.Text + ";;;" + txtCoords.Text;

            SatisTemsilcisiZiyaretler stz = new SatisTemsilcisiZiyaretler(
                ((Musteriler)Session["Musteri"]).intSLSREF,
                BARKOD,
                SMREF,
                ZIYGUN,
                DateTime.Now,
                DateTime.MinValue,
                Guid.Empty,
                koordinatlar,
                "");
            stz.DoInsert();
            Session["Ziyaret"] = stz;

            Rutlar.ZiyaretEkle(
                MTIP,
                ZIYGUN == DateTime.MinValue ? 2 : (bugunyapildi ? 2 : 1),
                BARKOD,
                GMREF,
                SMREF,
                ((Musteriler)Session["Musteri"]).intSLSREF,
                BARKOD,
                DateTime.Now,
                DateTime.Now,
                0,
                txtCoords1.Text,
                txtCoords.Text,
                "",
                "",
                0,
                0,
                0,
                0);

            Response.Cookies.Remove("sulZiyBaslangic");
            HttpCookie co = new HttpCookie("sulZiyBaslangic", Rutlar.GetKonum(SMREF, MTIP));
            co.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Add(co);

            lbFarkliZiyaretAc.Enabled = false;
            lbZiyaretSonlandirUst.Visible = true;

            divZiyaret.Visible = true;
            lblZiyaretSubesi.Text = MTIP == 1 ? CariHesaplar.GetMUSTERIbySMREF(stz.intSMREF) : MTIP == 4 ? CariHesaplarTP.GetSubelerBySMREF(stz.intSMREF)[1].ToString() : CariHesapZ.GetObject(stz.intSMREF, MTIP, true).SUBE;
            lblZiyaretBaslangic.Text = stz.dtZiyaretBaslangic.ToString();

            return donendeger;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void SiparisVer_Click(object sender, EventArgs e)
        {
            if (!divMusteriSiparisIadeButton.Visible)
                Session["LinkButton"] = sender;

            divFiyatTipi.Visible = true; cbHizliSiparis.Checked = false;
            bool bakiyecikmayacak = false;
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 ||
                ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 ||
                ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise veya yönetici ise veya bayi yöneticisi ise
            {
                foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
                {
                    if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                    {
                        if (ctrl.ID.StartsWith("inputBakiyeCikarma"))
                        {
                            tblFiyatTipiPanelindeBakiyeler.Visible = false;
                            bakiyecikmayacak = true;
                        }

                        if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                        {
                            Session["SMREF"] = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);

                            if (!bakiyecikmayacak)
                            {
                                tblFiyatTipiPanelindeBakiyeler.Visible = true;
                                int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value));
                                DataTable dt = new DataTable();
                                CariHesaplar.GetObjectByGMREF(dt, GMREF);
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["RISK LMT"] != DBNull.Value)
                                        lblRiskLimiti.Text = Convert.ToDecimal(dt.Rows[0]["RISK LMT"]).ToString("C3");
                                    if (dt.Rows[0]["VB GUN"] != DBNull.Value)
                                        lblVBVd.Text = Convert.ToDouble(dt.Rows[0]["VB GUN"]) > 0 ? DateTime.Now.AddDays(Convert.ToDouble(dt.Rows[0]["VB GUN"])).ToShortDateString() : "-";
                                    if (dt.Rows[0]["VB TOP"] != DBNull.Value)
                                        lblVBTop.Text = Convert.ToDecimal(dt.Rows[0]["VB TOP"]).ToString("C3");
                                    //if (dt.Rows[0]["VGB GUN"] != DBNull.Value)
                                        lblVGBGun.Text = DateTime.Now.AddDays(CariHesaplar.GetVgbVdByGMREF(GMREF)).ToShortDateString();
                                    //if (dt.Rows[0]["VGB TOP"] != DBNull.Value)
                                        lblVGBToplam.Text = CariHesaplar.GetVgbTopByGMREF(GMREF).ToString("C3");
                                    if (dt.Rows[0]["BAKIYE"] != DBNull.Value)
                                        lblBakiye.Text = Convert.ToDecimal(dt.Rows[0]["BAKIYE"]).ToString("C3");
                                    if (dt.Rows[0]["ACK GUN"] != DBNull.Value)
                                        lblBakiyeVade.Text = DateTime.Now.AddDays(Convert.ToDouble(dt.Rows[0]["ACK GUN"])).ToShortDateString();
                                    if (dt.Rows[0]["C/S TOP"] != DBNull.Value)
                                        lblCekSenetRisk.Text = Convert.ToDecimal(dt.Rows[0]["C/S TOP"]).ToString("C3");
                                    if (dt.Rows[0]["IRS TOP"] != DBNull.Value)
                                        lblIrs.Text = CariHesaplar.GetIrsTopByGMREF(GMREF).ToString("N2");
                                    if (dt.Rows[0]["SIP TOP"] != DBNull.Value)
                                        lblSiparisToplam.Text = CariHesaplar.GetSipTopByGMREF(GMREF).ToString("N2");
                                    if (dt.Rows[0]["SIP TOPLB"] != DBNull.Value)
                                        lblSiparisToplamBakiye.Text = CariHesaplar.GetBakTopByGMREF(GMREF).ToString("N2");
                                    if (dt.Rows[0]["RISK BKY"] != DBNull.Value)
                                        lblRiskBakiyesi.Text = Convert.ToDecimal(dt.Rows[0]["RISK BKY"]).ToString("C3");

                                    //lblRiskBakiyesiBaslik.Visible = ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1;
                                    //lblRiskBakiyesi.Visible = ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1;
                                    Session["RISKBAKIYE"] = Convert.ToDecimal(dt.Rows[0]["RISK BKY"]); // sadece sipariş sayfasında geçişte kullanılacak
                                }
                            }
                            
                            DataTable dtnsts = new DataTable();
                            CariHesaplar.GetNSTsBySMREF(dtnsts, Convert.ToInt32(Session["SMREF"]));
                            dlFiyatTipiNSTs.DataSource = dtnsts;
                            dlFiyatTipiNSTs.DataBind();
                        }
                    }
                }
            }
            else
            {
                tblFiyatTipiPanelindeBakiyeler.Visible = false;

                if (CariHesaplar.AnaSubeMi(((Musteriler)Session["Musteri"]).intGMREF))
                {
                    foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
                    {
                        if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                        {
                            DataTable dtnsts = new DataTable();
                            CariHesaplar.GetNSTsBySMREF(dtnsts, Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value));
                            dlFiyatTipiNSTs.DataSource = dtnsts;
                            dlFiyatTipiNSTs.DataBind();
                        }
                    }
                }
                else
                {
                    DataTable dtnsts = new DataTable();
                    CariHesaplar.GetNSTsBySMREF(dtnsts, ((Musteriler)Session["Musteri"]).intGMREF);
                    dlFiyatTipiNSTs.DataSource = dtnsts;
                    dlFiyatTipiNSTs.DataBind();
                }
            }

            GetFiyatTipleri();

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divFiyatTipi, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void SatTemSiparisVer_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("GMREF"))
                    {
                        int gmref = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        GetSubeler(gmref);
                    }
                }
            }

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSatTemAnaCariSubeleri, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        private void GetSubeler(int gmref)
        {
            btnAltCari.Visible = false;
            btnGenelAktivite.Visible = false;

            DataTable dt = new DataTable();

            ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && altlar.Count == 0) // şef değil ise
            {
                CariHesaplar.GetSubelerBySLSREF(dt, gmref, ((Musteriler)Session["Musteri"]).intSLSREF);
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && altlar.Count > 0) // şef ise
            {
                CariHesaplar.GetSubelerBySLSREF(dt, gmref, Convert.ToInt32(ddlSefAltlar.SelectedValue));
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 || Convert.ToInt32(inputBayiGibi.Value) == 1) // bayi yöneticisi ise veya yönetici bayi yöneticisinin müşterisini seçmişse
            {
                if (CariHesaplar.AnaSubeMi(gmref))
                {
                    inputBayiGibi.Value = "0";
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
                        CariHesaplar.GetSubelerBySLSREF(dt, gmref, ((Musteriler)Session["Musteri"]).intSLSREF);
                    else
                        CariHesaplar.GetSubelerBySLSREF(dt, gmref, Convert.ToInt32(ddlSefAltlar.SelectedValue));
                }
                else
                {
                    inputBayiGibi.Value = "1";
                    btnAltCari.Visible = true;
                    btnGenelAktivite.Visible = true;
                    CariHesaplarTP.GetObjects(dt, gmref);
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                CariHesaplar.GetSubelerBySLSREF(dt, gmref, Convert.ToInt32(ddlSefAltlar.SelectedValue));
            }

            dlSatTemAnaCariSubeleri.DataSource = dt;
            dlSatTemAnaCariSubeleri.DataBind();

            ArrayList al = CariHesaplar.GetObjectByGMREF(gmref, true);
            if (al.Count > 0)
            {
                lblSatTemRiskLimiti.Text = Convert.ToDecimal(al[0]).ToString("C3");
                lblSatTemVBVd.Text = Convert.ToDouble(al[10]) > 0 ? DateTime.Now.AddDays(Convert.ToDouble(al[10])).ToShortDateString() : "-";
                lblSatTemVBTop.Text = Convert.ToDecimal(al[11]).ToString("C3");
                lblSatTemBakiye.Text = Convert.ToDecimal(al[1]).ToString("C3");
                lblSatTemBakiyeVade.Text = DateTime.Now.AddDays(Convert.ToDouble(al[2])).ToShortDateString();
                lblSatTemCekSenetRisk.Text = Convert.ToDecimal(al[3]).ToString("C3");

                lblSatTemIrs.Text = CariHesaplar.GetIrsTopByGMREF(gmref).ToString("N2");
                lblSatTemSiparisToplam.Text = CariHesaplar.GetSipTopByGMREF(gmref).ToString("N2");
                lblSatTemSiparisToplamBakiye.Text = CariHesaplar.GetBakTopByGMREF(gmref).ToString("N2");

                lblSatTemRiskBakiyesi.Text = Convert.ToDecimal(al[7]).ToString("C3");
                lblSatTemVGBGun.Text = DateTime.Now.AddDays(CariHesaplar.GetVgbVdByGMREF(gmref)).ToShortDateString();
                lblSatTemVGBToplam.Text = CariHesaplar.GetVgbTopByGMREF(gmref).ToString("C3");

                //lblSatTemRiskBakiyesiBaslik.Visible = ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1;
                //lblSatTemRiskBakiyesi.Visible = ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1;
                Session["RISKBAKIYE"] = Convert.ToDecimal(al[4]); // sadece sipariş sayfasında geçişte kullanılacak
            }
            else
            {
                Session["RISKBAKIYE"] = 0;
            }
            divSatTemAnaCariSubeleri.Visible = true;
            inputGMREF.Value = gmref.ToString();
        }

        protected void Aktivite_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                        Session["SMREFakt"] = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                }
            }

            //if (Aktiviteler.GetSonOnaylanmamisAktiviteID(Convert.ToInt32(Session["SMREFakt"])) > 0)
            //{
            //    divAktiviteHata.Visible = true;
            //}
            //else
            //{
                divFiyatTipi.Visible = true;
                Session["Aktivite"] = false;
                Session["FiyatTipi"] = "25";
                if (CariHesaplarTP.GetObject(Convert.ToInt32(Session["SMREFakt"]), true).GMREF == 1005405 || CariHesaplarTP.GetObject(Convert.ToInt32(Session["SMREFakt"]), true).GMREF == 1000951) // bayi öztrakya veya meltem ise sultanlar gibi
                {
                    Session["AktiviteID"] = 0; //??????????
                }
                else
                {
                    Session["AktiviteID"] = 0;
                }
                Session["Aktivite"] = null;
                Response.Redirect("aktivite.aspx", true);
            //}

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divFiyatTipi, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void AktiviteSul_Click(object sender, EventArgs e)
        {
            int smref1 = 0;
            int smref = 0;
            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SMREF1") && ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value != string.Empty)
                        smref1 = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    else if (ctrl.ID.StartsWith("SMREF") && ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value != string.Empty)
                        smref = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                }
            }

            Session["SMREFakt"] = smref1 != 0 ? smref1 : smref;

            //if (Session["SMREFakt"] != null && Aktiviteler.GetSonOnaylanmamisAktiviteID(Convert.ToInt32(Session["SMREFakt"])) > 0)
            //{
            //    divAktiviteHata.Visible = true;
            //}
            //else
            //{
                //divFiyatTipi.Visible = true;
                Session["Aktivite"] = false;
                //GetFiyatTipleriAktivite();

                Session["FiyatTipi"] = "7";
                Session["AktiviteID"] = 1;
                Session["Aktivite"] = null;
                Response.Redirect("aktivite.aspx", true);
            //}

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divFiyatTipi, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbAktiviteHata_Click(object sender, EventArgs e)
        {
            divAktiviteHata.Visible = false;
        }

        protected void lbAnlasmaHata_Click(object sender, EventArgs e)
        {
            divAnlasmaHata.Visible = false;
        }

        protected void Anlasma_Click(object sender, EventArgs e)
        {
            AnlasmaTemizle();

            AnlasmaBedelAdlari.GetObjects(cblAnlasmaHizmetBedelleri.Items);

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                        AnlasmaSMREF.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                }
            }

            //if (Anlasmalar.GetSonOnaylanmamisAnlasmaID(Convert.ToInt32(AnlasmaSMREF.Value)) > 0)
            //{
            //    divAnlasmaHata.Visible = true;
            //}
            //else
            //{
                CariHesaplarTP musteri = CariHesaplarTP.GetObject(Convert.ToInt32(AnlasmaSMREF.Value), false);

                txtAnlasmaMusteri.Text = musteri.SUBE;
                txtAnlasmaIl.Text = musteri.IL;
                txtAnlasmaBayi.Text = CariHesaplarTP.GetObject(Convert.ToInt32(AnlasmaSMREF.Value), true).MUSTERI;

                divAnlasma.Visible = true;
            //}

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divFiyatTipi, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        private void AnlasmaTemizle()
        {
            foreach (Control ctrl in divAnlasma.Controls)
            {
                if (ctrl is TextBox && ctrl.ID.StartsWith("txtAnlasma")/* && ctrl.ID.EndsWith("Aciklama")*/)
                {
                    ((TextBox)ctrl).Text = "0";
                }
                else if (ctrl is System.Web.UI.HtmlControls.HtmlInputText && ctrl.ID.StartsWith("datepickerAnlasma"))
                {
                    ((System.Web.UI.HtmlControls.HtmlInputText)ctrl).Value = "";
                }
            }

            foreach (Control ctrl in pnlAnlasmaHizmetBedelleri.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is TextBox && ctrl2.ID.StartsWith("txtAnlasma")/* && ctrl.ID.EndsWith("Aciklama")*/)
                    {
                        ((TextBox)ctrl2).Text = "0";
                    }
                }
            }

            divAnlasmaHizmetBedeli1.Visible = false;
            divAnlasmaHizmetBedeli2.Visible = false;
            divAnlasmaHizmetBedeli3.Visible = false;
            divAnlasmaHizmetBedeli4.Visible = false;
            divAnlasmaHizmetBedeli5.Visible = false;
            divAnlasmaHizmetBedeli6.Visible = false;
            divAnlasmaHizmetBedeli7.Visible = false;
            divAnlasmaHizmetBedeli8.Visible = false;
            divAnlasmaHizmetBedeli9.Visible = false;
            divAnlasmaHizmetBedeli10.Visible = false;
            divAnlasmaHizmetBedeli11.Visible = false;
            divAnlasmaHizmetBedeli12.Visible = false;
            divAnlasmaHizmetBedeli13.Visible = false;
            divAnlasmaHizmetBedeli14.Visible = false;
        }

        protected void AnlasmaSul_Click(object sender, EventArgs e)
        {
            AnlasmaTemizle();

            AnlasmaBedelAdlari.GetObjects(cblAnlasmaHizmetBedelleri.Items);

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("GMREF"))
                        AnlasmaSMREF.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                }
            }

            //if (Anlasmalar.GetSonOnaylanmamisAnlasmaID(Convert.ToInt32(AnlasmaSMREF.Value)) > 0)
            //{
            //    divAnlasmaHata.Visible = true;
            //}
            //else
            //{
                txtAnlasmaMusteri.Text = CariHesaplar.GetMUSTERIbyGMREF(Convert.ToInt32(AnlasmaSMREF.Value));
                txtAnlasmaIl.Text = "İSTANBUL";
                txtAnlasmaBayi.Text = "SULTANLAR PAZARLAMA A.Ş.";

                divAnlasma.Visible = true;
            //}

            AnlasmaSMREF.Value = "-" + AnlasmaSMREF.Value;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divFiyatTipi, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbAnlasmaGir_Click(object sender, EventArgs e)
        {
            try
            {
                int SMREF = AnlasmaSMREF.Value.StartsWith("-") ? Convert.ToInt32(AnlasmaSMREF.Value.Substring(1)) : Convert.ToInt32(AnlasmaSMREF.Value);
                Anlasmalar anlasma = new Anlasmalar(SMREF, ((Musteriler)Session["Musteri"]).pkMusteriID, 
                Convert.ToDateTime(datepickerAnlasmaBaslangic.Value),
                Convert.ToDateTime(datepickerAnlasmaBitis.Value), Convert.ToInt32(txtAnlasmaVadeTAH.Text.Trim()),
                Convert.ToInt32(txtAnlasmaVadeYEG.Text.Trim()), Convert.ToInt32(txtAnlasmaSKUTAH.Text.Trim()),
                Convert.ToInt32(txtAnlasmaSKUYEG.Text.Trim()), Convert.ToDouble(txtAnlasmaTAHIsk.Text.Trim()),
                Convert.ToDouble(txtAnlasmaTAHCiro.Text.Trim()), Convert.ToDouble(txtAnlasmaTAHCiro3.Text.Trim()),
                Convert.ToDouble(txtAnlasmaTAHCiro6.Text.Trim()), Convert.ToDouble(txtAnlasmaTAHCiro12.Text.Trim()),
                Convert.ToDouble(txtAnlasmaTAHCiroIsk.Text.Trim()), Convert.ToDecimal(txtAnlasmaTAHAnlasmaDisiBedeller.Text.Trim()),
                Convert.ToDecimal(txtAnlasmaTAHToplamCiro.Text.Trim()), Convert.ToDouble(txtAnlasmaYEGIsk.Text.Trim()),
                Convert.ToDouble(txtAnlasmaYEGCiro.Text.Trim()), Convert.ToDouble(txtAnlasmaYEGCiro3.Text.Trim()),
                Convert.ToDouble(txtAnlasmaYEGCiro6.Text.Trim()), Convert.ToDouble(txtAnlasmaYEGCiro12.Text.Trim()),
                Convert.ToDouble(txtAnlasmaYEGCiroIsk.Text.Trim()), Convert.ToDecimal(txtAnlasmaYEGAnlasmaDisiBedeller.Text.Trim()),
                Convert.ToDecimal(txtAnlasmaYEGToplamCiro.Text.Trim()), (cbAnlasmaGecici.Checked ? "[Geçici] " : "") + txtAnlasmaAciklama.Text.Trim() + " (Anlaşma onay talep tarihi:" + DateTime.Now.ToShortDateString() + ")",
                AnlasmaSMREF.Value.StartsWith("-") ? "2" : "1", 
                "", txtAnlasmaSubeSayisi.Text.Trim(),
                0);

                ArrayList eklenecekbedeller = new ArrayList();
                for (int i = 0; i < cblAnlasmaHizmetBedelleri.Items.Count; i++) // butun bedellere bak
                {
                    if (cblAnlasmaHizmetBedelleri.Items[i].Selected) // hangi bedeller secili
                    {
                        int tahadet = Convert.ToInt32(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "TAHadet")).Text);
                        int yegadet = Convert.ToInt32(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "YEGadet")).Text);
                        decimal tahbedel = Convert.ToDecimal(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "TAHbedel")).Text);
                        decimal yegbedel = Convert.ToDecimal(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "YEGbedel")).Text);
                        //double tahiskonto = Convert.ToDouble(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "TAHiskonto")).Text);
                        //double yegiskonto = Convert.ToDouble(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "YEGiskonto")).Text);

                        AnlasmaBedeller anlasmabedel = new AnlasmaBedeller(0, Convert.ToInt32(cblAnlasmaHizmetBedelleri.Items[i].Value),
                            tahadet, tahbedel, 0, yegadet, yegbedel, 0, "", "", "", "");
                        eklenecekbedeller.Add(anlasmabedel);
                    }
                }

                //Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", new string[] { "hgunbay@sultanlar.com.tr" },
                //    "Sultanlar Pazarlama A.Ş.",
                //    "Anlaşma onay talebi: " + anlasma.pkID.ToString(),
                //    anlasma.pkID.ToString() + " nolu anlaşma için onay talebi yapılmıştır. Talebi yapan web üyesi: " +
                //    Musteriler.GetMusteriByID(anlasma.intMusteriID).strAd + " " + Musteriler.GetMusteriByID(anlasma.intMusteriID).strSoyad);

                if (!cbAnlasmaGecici.Checked)
                {
                    if (!fuAnlasma.HasFile)
                    {
                        lblAnlasmaHata.Text = "Anlaşma dosyası eklenmeden anlaşma girilemez.";
                        return;
                    }
                }

                anlasma.DoInsert();
                for (int i = 0; i < eklenecekbedeller.Count; i++)
                {
                    AnlasmaBedeller anlasmabedel = (AnlasmaBedeller)eklenecekbedeller[i];
                    anlasmabedel.intAnlasmaID = anlasma.pkID;
                    anlasmabedel.DoInsert();
                }

                if (fuAnlasma.HasFile)
                {
                    System.IO.Stream fs = fuAnlasma.PostedFile.InputStream;
                    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                    byte[] resim = br.ReadBytes(Convert.ToInt32(fs.Length));

                    Class.Eposta.EpostaGonder("Sistem", "demetdogan@tibet.com.tr", "Yeni Anlaşma", "Sisteme yeni bir anlaşma girildi. Anlaşma ile gönderilen dosya ektedir.<br><br>Girilen anlaşma numarası: " + anlasma.pkID.ToString(), resim, fuAnlasma.PostedFile.FileName);
                    //Class.Eposta.EpostaGonder("Sistem", "ndemirbas@tibet.com.tr", "Yeni Anlaşma", "Sisteme yeni bir anlaşma girildi. Anlaşma ile gönderilen dosya ektedir.<br><br>Girilen anlaşma numarası: " + anlasma.pkID.ToString(), resim, fuAnlasma.PostedFile.FileName);
                }

                AnlasmaSMREF.Value = "0";

                divAnlasma.Visible = false;
                divAnlasmaKaydedildi.Visible = true;
            }
            catch (Exception ex)
            {
                string alert1 = "<script type='text/javascript'>alert('Girilen değerlerde hata var, lütfen düzeltip tekrar gönderin.\r\n\r\nHata ayrıntısı: " + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert1, false);
            }

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbAnlasmaHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                int SMREF = AnlasmaSMREF.Value.StartsWith("-") ? Convert.ToInt32(AnlasmaSMREF.Value.Substring(1)) : Convert.ToInt32(AnlasmaSMREF.Value);
                Anlasmalar anlasma = new Anlasmalar(SMREF, ((Musteriler)Session["Musteri"]).pkMusteriID,
                Convert.ToDateTime(datepickerAnlasmaBaslangic.Value),
                Convert.ToDateTime(datepickerAnlasmaBitis.Value), Convert.ToInt32(txtAnlasmaVadeTAH.Text.Trim()),
                Convert.ToInt32(txtAnlasmaVadeYEG.Text.Trim()), Convert.ToInt32(txtAnlasmaSKUTAH.Text.Trim()),
                Convert.ToInt32(txtAnlasmaSKUYEG.Text.Trim()), Convert.ToDouble(txtAnlasmaTAHIsk.Text.Trim()),
                Convert.ToDouble(txtAnlasmaTAHCiro.Text.Trim()), Convert.ToDouble(txtAnlasmaTAHCiro3.Text.Trim()),
                Convert.ToDouble(txtAnlasmaTAHCiro6.Text.Trim()), Convert.ToDouble(txtAnlasmaTAHCiro12.Text.Trim()),
                Convert.ToDouble(txtAnlasmaTAHCiroIsk.Text.Trim()), Convert.ToDecimal(txtAnlasmaTAHAnlasmaDisiBedeller.Text.Trim()),
                Convert.ToDecimal(txtAnlasmaTAHToplamCiro.Text.Trim()), Convert.ToDouble(txtAnlasmaYEGIsk.Text.Trim()),
                Convert.ToDouble(txtAnlasmaYEGCiro.Text.Trim()), Convert.ToDouble(txtAnlasmaYEGCiro3.Text.Trim()),
                Convert.ToDouble(txtAnlasmaYEGCiro6.Text.Trim()), Convert.ToDouble(txtAnlasmaYEGCiro12.Text.Trim()),
                Convert.ToDouble(txtAnlasmaYEGCiroIsk.Text.Trim()), Convert.ToDecimal(txtAnlasmaYEGAnlasmaDisiBedeller.Text.Trim()),
                Convert.ToDecimal(txtAnlasmaYEGToplamCiro.Text.Trim()), txtAnlasmaAciklama.Text.Trim(), "", "", txtAnlasmaSubeSayisi.Text.Trim(),
                0);

                decimal toplamtahbedeller = 0;
                decimal toplamyegbedeller = 0;
                for (int i = 0; i < cblAnlasmaHizmetBedelleri.Items.Count; i++) // butun bedellere bak
                {
                    if (cblAnlasmaHizmetBedelleri.Items[i].Selected) // hangi bedeller secili
                    {
                        int tahadet = Convert.ToInt32(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "TAHadet")).Text);
                        int yegadet = Convert.ToInt32(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "YEGadet")).Text);
                        decimal tahbedel = Convert.ToDecimal(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "TAHbedel")).Text);
                        decimal yegbedel = Convert.ToDecimal(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "YEGbedel")).Text);
                        //double tahiskonto = Convert.ToDouble(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "TAHiskonto")).Text);
                        //double yegiskonto = Convert.ToDouble(((TextBox)pnlAnlasmaHizmetBedelleri.FindControl("txtAnlasmaHizmetBedeli" + cblAnlasmaHizmetBedelleri.Items[i].Value + "YEGiskonto")).Text);

                        toplamtahbedeller += tahadet * tahbedel;
                        toplamyegbedeller += yegadet * yegbedel;
                    }
                }

                txtAnlasmaTAHTumBedeller.Text = (Convert.ToDecimal(txtAnlasmaTAHAnlasmaDisiBedeller.Text) + toplamtahbedeller).ToString("N2");
                txtAnlasmaYEGTumBedeller.Text = (Convert.ToDecimal(txtAnlasmaYEGAnlasmaDisiBedeller.Text) + toplamyegbedeller).ToString("N2");

                txtAnlasmaTAHYilSonuMaliyet.Text = anlasma.mnTAHToplamCiro != 0 ? (100 * (Convert.ToDecimal(txtAnlasmaTAHTumBedeller.Text) / anlasma.mnTAHToplamCiro)).ToString("N1") : 0.ToString("N1");
                txtAnlasmaYEGYilSonuMaliyet.Text = anlasma.mnYEGToplamCiro != 0 ? (100 * (Convert.ToDecimal(txtAnlasmaYEGTumBedeller.Text) / anlasma.mnYEGToplamCiro)).ToString("N1") : 0.ToString("N1");

                txtAnlasmaTAHCiroPrimiDahil.Text = (Convert.ToDouble(txtAnlasmaTAHYilSonuMaliyet.Text) + anlasma.flTAHIsk + anlasma.flTAHCiroIsk
                    + anlasma.flTAHCiro + anlasma.flTAHCiro3 + anlasma.flTAHCiro6 + anlasma.flTAHCiro12).ToString("N1");
                txtAnlasmaYEGCiroPrimiDahil.Text = (Convert.ToDouble(txtAnlasmaYEGYilSonuMaliyet.Text) + anlasma.flYEGIsk + anlasma.flYEGCiroIsk
                    + anlasma.flYEGCiro + anlasma.flYEGCiro3 + anlasma.flYEGCiro6 + anlasma.flYEGCiro12).ToString("N1");

                txtAnlasmaTAHTumBedeller.Text = txtAnlasmaTAHTumBedeller.Text + " TL";
                txtAnlasmaYEGTumBedeller.Text = txtAnlasmaYEGTumBedeller.Text + " TL";
                txtAnlasmaTAHYilSonuMaliyet.Text = "%" + txtAnlasmaTAHYilSonuMaliyet.Text;
                txtAnlasmaYEGYilSonuMaliyet.Text = "%" + txtAnlasmaYEGYilSonuMaliyet.Text;
                txtAnlasmaTAHCiroPrimiDahil.Text = "%" + txtAnlasmaTAHCiroPrimiDahil.Text;
                txtAnlasmaYEGCiroPrimiDahil.Text = "%" + txtAnlasmaYEGCiroPrimiDahil.Text;
            }
            catch (Exception ex)
            {
                string alert1 = "<script type='text/javascript'>alert('Girilen değerlerde hata var, lütfen düzeltip tekrar gönderin.\r\n\r\nHata ayrıntısı: " + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert1, false);
            }
        }

        protected void lbAnlasmaKaydedildiKapat_Click(object sender, EventArgs e)
        {
            divAnlasmaKaydedildi.Visible = false;
        }

        protected void lbAnlasmaKapat_Click(object sender, EventArgs e)
        {
            AnlasmaSMREF.Value = "0";
            divAnlasma.Visible = false;
        }

        protected void ddlSefAltlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRutlar(Convert.ToInt32(ddlSefAltlar.SelectedValue));

            int musteriid = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));
            if (musteriid > 0)
            {
                Session["SiparisSahibiMusteriID"] = musteriid;
                Session["SiparisGirenMusteriID"] = ((Musteriler)Session["Musteri"]).pkMusteriID;

                Session["IadeSahibiMusteriID"] = musteriid;
                Session["IadeGirenMusteriID"] = ((Musteriler)Session["Musteri"]).pkMusteriID;

                inputBayiGibi.Value = ddlSefAltlarBayiSatici.SelectedValue;
            }

            GetCariHesaplar();
        }

        protected void ddlFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (divMusteriSiparisIadeButton.Visible) // şubesiz cari siparişi veriliyorsa
            {
                Session["SMREF"] = ((Musteriler)Session["Musteri"]).intGMREF;
            }
            else
            {
                // bu foreach lüzumsuz çünkü getfiyattiplerinde smref i linkbuttondan alıyoruz (aynı foreach)
                //if (Session["LinkButton"] != null)
                //{
                //    foreach (Control ctrl in ((LinkButton)Session["LinkButton"]).Parent.Controls)
                //    {
                //        if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                //        {
                //            if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                //            {
                //                Session["SMREF"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                //                Session["LinkButton"] = null;
                //            }
                //        }
                //    }
                //}
            }

            int GMREF = CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Session["SMREF"]));
            Session["RISKBAKIYE"] = CariHesaplar.GetRISKBKYByGMREF(GMREF); // sadece sipariş sayfasında geçişte kullanılacak
            if (ddlFiyatTipleri.Items.Count == 2) // tek fiyat tipinde yetkili ise
                Session["FiyatTipi"] = Convert.ToInt16(ddlFiyatTipleri.Items[ddlFiyatTipleri.Items.Count - 1].Value); // sadece siparis sayfasinda geciste kullanilacak
            else
                Session["FiyatTipi"] = Convert.ToInt16(ddlFiyatTipleri.SelectedValue); // sadece siparis sayfasinda geciste kullanilacak

            if (CariHesaplar.GetRISKLMTByGMREF(GMREF) > -1) // risk limiti 10 dan küçük ise sipariş veremeyecek
            {
                int anlasmaid = Anlasmalar.GetSonAnlasmaID(GMREF, DateTime.Now, "2");
                if (anlasmaid > 0 && (ddlFiyatTipleri.SelectedItem.Value == "3" || ddlFiyatTipleri.SelectedItem.Value == "4" || ddlFiyatTipleri.SelectedItem.Value == "7" || ddlFiyatTipleri.SelectedItem.Value == "8"))
                {
                    Session["SMREF"] = null;
                    Session["RISKBAKIYE"] = null;
                    Session["FiyatTipi"] = null;
                    divAnlasmaliFiyatHata.Visible = true;
                    return;
                }
                else if (FiyatTipleri.GetFiyatTipByGMREF(GMREF) > 0 && ddlFiyatTipleri.SelectedItem.Value == "2")
                {
                    Session["SMREF"] = null;
                    Session["RISKBAKIYE"] = null;
                    Session["FiyatTipi"] = null;
                    divAnlasmaliFiyatHata.Visible = true;
                    return;
                }

                if (cbHizliSiparis.Checked)
                {
                    Session["OfflineButunUrunler"] = cbButunUrunler.Checked;
                    Response.Redirect("hizlisiparis.aspx", true);
                }
                else
                {
                    Session["SiparisID"] = 0;
                    Response.Redirect("siparis.aspx", true);
                }
            }
            else
            {
                Session["SMREF"] = null;
                Session["RISKBAKIYE"] = null;
                Session["FiyatTipi"] = null;
                divRiskLimitHata.Visible = true;
            }
        }

        protected void lbFiyatTipiKapat_Click(object sender, EventArgs e)
        {
            Session["Aktivite"] = null;
            Session["SMREF"] = null;
            Session["RISKBAKIYE"] = null;
            divFiyatTipi.Visible = false;
            dlFiyatTipiNSTs.DataBind();
        }

        protected void lbSatTemAnaCariSubeleri_Click(object sender, EventArgs e)
        {
            divSatTemAnaCariSubeleri.Visible = false;
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
                inputBayiGibi.Value = "0";
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
                inputBayiGibi.Value = "1";
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                inputBayiGibi.Value = ddlSefAltlarBayiSatici.SelectedValue;
            //inputGMREF.Value = "0";
        }

        protected void ZiyaretBaslat_Click(object sender, EventArgs e)
        {
            if (Session["Ziyaret"] != null)
                divZiyaretHata.Visible = true;

            int SMREF = 0;
            int MTIP = 0;
            string BARKOD = string.Empty;
            DateTime ZIYGUN = DateTime.MinValue;

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls) // td nin kontrolleri
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                        SMREF = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    else if (ctrl.ID.StartsWith("BARKOD"))
                        BARKOD = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    else if (ctrl.ID.StartsWith("MTIP"))
                        MTIP = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    else if (ctrl.ID.StartsWith("ZIYGUN"))
                        ZIYGUN = Convert.ToDateTime(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                }
                else if (ctrl is LinkButton)
                {
                    if (ctrl.ID.StartsWith("lbSatTemRutZiyaretSonlandir"))
                        ((LinkButton)ctrl).Enabled = true;
                }
            }

            bool konumyok;
            bool mevcutkonumyok;
            if (ZiyaretBaslat(SMREF, BARKOD, ZIYGUN, MTIP, out konumyok, out mevcutkonumyok))
            {
                foreach (Control ctrl in ((LinkButton)sender).Parent.Parent.Parent.Parent.Controls) // datalist in kontrolleri
                    foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                        foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                            foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                                if (ctrl4 is LinkButton)
                                    if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretBaslat"))
                                        ((LinkButton)ctrl4).Enabled = false;
            }
            else
            {
                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert, false);

                if (!konumyok && !mevcutkonumyok)
                {
                    divZiyaretHata.Visible = true;
                }
                else if (mevcutkonumyok)
                {
                    divZiyaretHata3.Visible = true;
                }
                else if (konumyok)
                {
                    lblZiyaretHata2konum.Text = txtCoords.Text;
                    inputZiyaretHata2smref.Value = SMREF.ToString();
                    inputZiyaretHata2tip.Value = MTIP.ToString();
                    inputZiyaretHata2barkod.Value = BARKOD.ToString();
                    inputZiyaretHata2ziygun.Value = ZIYGUN.ToString();
                    divZiyaretHata2.Visible = true;
                }
            }
        }

        protected void ZiyaretSonlandir_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divZiyaretSonlandirmaSebep.Visible = true;

            ((LinkButton)sender).Enabled = false;

            foreach (Control ctrl in ((LinkButton)sender).Parent.Parent.Parent.Parent.Controls) // datalist in kontrolleri
                foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                    foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                        foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                            if (ctrl4 is LinkButton)
                                if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretBaslat"))
                                    ((LinkButton)ctrl4).Enabled = true;

            lbFarkliZiyaretAc.Enabled = true;
        }

        protected void lbZiyaretHataKapat_Click(object sender, EventArgs e)
        {
            divZiyaretHata.Visible = false;
        }

        protected void lbZiyaretHataKapat2_Click(object sender, EventArgs e)
        {
            divZiyaretHata2.Visible = false;
        }

        protected void lbZiyaretHataKapat3_Click(object sender, EventArgs e)
        {
            divZiyaretHata3.Visible = false;
        }

        protected void lbZiyaretIptal_Click(object sender, EventArgs e)
        {
            Response.Cookies.Remove("sulZiyBaslangic");

            SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["Ziyaret"];
            stz.DoDelete();

            Rutlar.ZiyaretSil(stz.strBARKOD);

            lbFarkliZiyaretAc.Enabled = true;
            Session["Ziyaret"] = null;
            divZiyaret.Visible = false;
            lblZiyaretSubesi.Text = string.Empty;
            lblZiyaretBaslangic.Text = string.Empty;

            int SLSREF = 0;
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
            {
                if (SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF).Count > 0) // şef ise
                    SLSREF = Convert.ToInt32(ddlSefAltlar.SelectedValue);
                else // şef değil ise
                    SLSREF = ((Musteriler)Session["Musteri"]).intSLSREF;
            }
            GetRutlar(SLSREF);
        }

        protected void lbZiyaretSonlandirUst_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divZiyaretSonlandirmaSebep.Visible = true;
        }

        protected void lbZiyaretSonlandirmaSebep_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["Ziyaret"];
            stz.dtZiyaretBitis = DateTime.Now;
            stz.unSebep = Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue);
            stz.strAciklama = txtZiyaretSonlandirmaSebepAciklama.Text;
            stz.DoUpdate();

            Rutlar.ZiyaretGuncelle(stz.strBARKOD, stz.dtZiyaretBitis, 
                SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepID(Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue)),
                txtCoords1.Text,
                txtCoords.Text,
                txtCoordsFark.Text,
                "web", stz.strAciklama);

            Response.Cookies.Remove("sulZiyBaslangic");

            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            txtZiyaretSonlandirmaSebepAciklama.Text = string.Empty;
            txtCoords1onceki.Text = "0,0";

            foreach (Control ctrl in dlRutlar.Controls) // datalist in kontrolleri
                foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlTableRow) // tr ise
                        if (((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).Attributes["title"] == ((SatisTemsilcisiZiyaretler)Session["Ziyaret"]).intSMREF.ToString())
                            foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                                foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                                    if (ctrl4 is LinkButton)
                                        if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretSonlandir"))
                                            ((LinkButton)ctrl4).Enabled = false;

            foreach (Control ctrl in dlRutlar.Controls) // datalist in kontrolleri
                foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                    foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                        foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                            if (ctrl4 is LinkButton)
                                if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretBaslat"))
                                    ((LinkButton)ctrl4).Enabled = true;

            lbFarkliZiyaretAc.Enabled = true;
            Session["Ziyaret"] = null;
            divZiyaretSonlandirmaSebep.Visible = false;
            lbZiyaretSonlandirUst.Visible = false;

            divZiyaret.Visible = false;
            lblZiyaretSubesi.Text = string.Empty;
            lblZiyaretBaslangic.Text = string.Empty;

            //Response.Redirect("default.aspx", true);
            int SLSREF = 0;
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
            {
                if (SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF).Count > 0) // şef ise
                    SLSREF = Convert.ToInt32(ddlSefAltlar.SelectedValue);
                else // şef değil ise
                    SLSREF = ((Musteriler)Session["Musteri"]).intSLSREF;
            }
            GetRutlar(SLSREF);
        }

        protected void lbSonZiyaret_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
            if (altlar.Count == 0)  // şef değil ise
                SatisTemsilcisiZiyaretler.GetObjectLast(dt, ((Musteriler)Session["Musteri"]).intSLSREF);
            else
                SatisTemsilcisiZiyaretler.GetObjectLast(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                lbSonZiyaretSonlandir.ToolTip = dt.Rows[0]["pkID"].ToString();

                SatisTemsilcisiZiyaretler stz = SatisTemsilcisiZiyaretler.GetObject(Convert.ToInt32(dt.Rows[0]["pkID"]));
                int MTIP = Convert.ToInt32(stz.strMekan.Substring(0, 1));
                lblSonZiyaretMusteri.Text = MTIP == 1 ? CariHesaplar.GetMUSTERIbySMREF(stz.intSMREF) : MTIP == 4 ? CariHesaplarTP.GetSubelerBySMREF(stz.intSMREF)[1].ToString() : CariHesapZ.GetObject(stz.intSMREF, MTIP, true).SUBE;
                lblSonZiyaretMusteri.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt.Rows[0]["dtZiyaretBaslangic"].ToString();

                if (dt.Rows[0]["dtZiyaretBitis"].ToString() == "")
                    lbSonZiyaretSonlandir.Visible = true;
            }

            divSonZiyaret.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSonZiyaret, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSonZiyaretSonlandir_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = SatisTemsilcisiZiyaretler.GetObject(Convert.ToInt64(((LinkButton)sender).ToolTip));
            Session["Ziyaret"] = stz;
            
            txtCoords1onceki.Text = Rutlar.GetKonum(stz.intSMREF, Convert.ToInt32(stz.strMekan.Split(new string[] { ";;;" }, StringSplitOptions.None)[0]));

            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divSonZiyaret.Visible = false;
            divZiyaretSonlandirmaSebep.Visible = true;
        }

        protected void lbSonZiyaretKapat_Click(object sender, EventArgs e)
        {
            lbSonZiyaretSonlandir.Visible = false;
            divSonZiyaret.Visible = false;
        }

        protected void lbFarkliZiyaretAc_Click(object sender, EventArgs e)
        {
            if (Session["Ziyaret"] != null)
                divZiyaretHata.Visible = true;

            DataTable dt = new DataTable();

            ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && altlar.Count == 0) // şef değil ise
            {
                //CariHesaplar.GetObjectsBySLSREFforFarkliZiyaretBaslat(dt, ((Musteriler)Session["Musteri"]).intSLSREF, txtFarkliZiyaretSube.Text.Replace("'", ""));
                WebGenel.Sorgu(dt, "SELECT DISTINCT TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + " AND [Şube] LIKE '%" + txtFarkliZiyaretSube.Text.Replace("'", "") + "%' ORDER BY [Müşteri],[Şube]");
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && altlar.Count > 0) // şef ise
            {
                //CariHesaplar.GetObjectsBySLSREFforFarkliZiyaretBaslat(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), txtFarkliZiyaretSube.Text.Replace("'", ""));
                WebGenel.Sorgu(dt, "SELECT DISTINCT TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ddlSefAltlar.SelectedValue + " AND [Şube] LIKE '%" + txtFarkliZiyaretSube.Text.Replace("'", "") + "%' ORDER BY [Müşteri],[Şube]");
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
            {
                //CariHesaplarTP.GetObjectsBySLSREFforFarkliZiyaretBaslat(dt, ((Musteriler)Session["Musteri"]).intSLSREF, txtFarkliZiyaretSube.Text.Replace("'", ""));
                WebGenel.Sorgu(dt, "SELECT DISTINCT TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + " AND [Şube] LIKE '%" + txtFarkliZiyaretSube.Text.Replace("'", "") + "%' ORDER BY [Müşteri],[Şube]");
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                //if (inputBayiGibi.Value == "1")
                //    CariHesaplarTP.GetObjectsBySLSREFforFarkliZiyaretBaslat(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), txtFarkliZiyaretSube.Text.Replace("'", ""));
                //else
                //    CariHesaplar.GetObjectsBySLSREFforFarkliZiyaretBaslat(dt, Convert.ToInt32(ddlSefAltlar.SelectedValue), txtFarkliZiyaretSube.Text.Replace("'", ""));

                WebGenel.Sorgu(dt, "SELECT DISTINCT TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ddlSefAltlar.SelectedValue + " AND [Şube] LIKE '%" + txtFarkliZiyaretSube.Text.Replace("'", "") + "%' ORDER BY [Müşteri],[Şube]");
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 9) // bayi elemanı
            {
                ArrayList al = new ArrayList();
                UyeBayiler.GetObject(al, ((Musteriler)Session["Musteri"]).pkMusteriID);
                CariHesaplarTP.GetBayiAltCariler(dt, al);
            }

            rpZiyaretCariler.DataSource = dt;
            rpZiyaretCariler.DataBind();

            divFarkliZiyaret.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbFarkliZiyaretBaslat_Click(object sender, EventArgs e)
        {
            int SMREF = 0;
            int MTIP = 0;

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                    {
                        SMREF = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                    else if (ctrl.ID.StartsWith("MTIP"))
                    {
                        MTIP = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }

            int gmref = (inputBayiGibi.Value == "1" ? CariHesaplarTP.GetGMREFBySMREF(SMREF) : CariHesaplar.GetGMREFBySMREF(SMREF));
            string BARKOD = ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + gmref.ToString() + SMREF.ToString() + "." + DateTime.Now.ToString().Replace(" ", "."); //Rutlar.GetBARKODBySMREF(MTIP, ((Musteriler)Session["Musteri"]).intSLSREF, SMREF)

            bool konumyok;
            bool mevcutkonumyok;
            if (ZiyaretBaslat(SMREF, BARKOD, DateTime.MinValue, MTIP, out konumyok, out mevcutkonumyok))
            {
                foreach (Control ctrl in ((LinkButton)sender).Parent.Parent.Controls) // kendi datalist in kontrolleri // nasıl oldu anlamadım ?
                    foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                        //foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                            //foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                                if (ctrl2 is LinkButton)
                                    if (ctrl2.ID.StartsWith("lbFarkliZiyaretBaslat"))
                                        ((LinkButton)ctrl2).Enabled = false;

                foreach (Control ctrl in dlRutlar.Controls) // datalist in kontrolleri
                    foreach (Control ctrl2 in ctrl.Controls) // item template nin kontrolleri
                        foreach (Control ctrl3 in ctrl2.Controls) // tr nin kontrolleri
                            foreach (Control ctrl4 in ctrl3.Controls) // td nin kontrolleri
                                if (ctrl4 is LinkButton)
                                    if (ctrl4.ID.StartsWith("lbSatTemRutZiyaretBaslat"))
                                        ((LinkButton)ctrl4).Enabled = false;

                divFarkliZiyaret.Visible = false;
            }
            else
            {
                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert, false);

                if (!konumyok && !mevcutkonumyok)
                {
                    divZiyaretHata.Visible = true;
                }
                else if (mevcutkonumyok)
                {
                    divZiyaretHata3.Visible = true;
                }
                else if (konumyok)
                {
                    lblZiyaretHata2konum.Text = txtCoords.Text;
                    inputZiyaretHata2smref.Value = SMREF.ToString();
                    inputZiyaretHata2tip.Value = MTIP.ToString();
                    inputZiyaretHata2barkod.Value = BARKOD.ToString();
                    inputZiyaretHata2ziygun.Value = DateTime.MinValue.ToString();
                    divZiyaretHata2.Visible = true;
                }
            }
        }

        protected void lbFarkliZiyaretKapat_Click(object sender, EventArgs e)
        {
            divFarkliZiyaret.Visible = false;
        }

        protected void lbZiyaretKonumAlinamadi_Click(object sender, EventArgs e)
        {
            divZiyaretKonumAlinamadi.Visible = false;
        }
        
        protected void lbTarihKapat_Click(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                GetRutlar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
            {
                ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
                
                if (altlar.Count > 0) // şef ise
                {
                    GetRutlar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
                }
                else // şef değil ise
                {
                    GetRutlar(((Musteriler)Session["Musteri"]).intSLSREF);
                }
            }

            divTarih.Visible = false;
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
                Calendar1.SelectedDate = DateTime.Now;
                Calendar2.SelectedDate = DateTime.Now;
            }
        }

        protected void ibTarih_Click(object sender, ImageClickEventArgs e)
        {
            divTarih.Visible = true;
        }

        protected void IadeVer_Click(object sender, EventArgs e)
        {
            if (lbIade.Visible) // şubesiz cari iade veriliyorsa
            {
                Session["SMREF"] = ((Musteriler)Session["Musteri"]).intGMREF;
            }
            else
            {
                foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
                {
                    if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                    {
                        if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
                        {
                            Session["SMREF"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                            Session["LinkButton"] = null;
                        }
                    }
                }
            }

            Session["IadeID"] = 0;
            Response.Redirect("iade.aspx", true);
        }

        protected void lbRiskLimitHata_Click(object sender, EventArgs e)
        {
            Session["SMREF"] = null;
            Session["RISKBAKIYE"] = null;
            Session["FiyatTipi"] = null;
            Session["Aktivite"] = null;
            divRiskLimitHata.Visible = false;
            divFiyatTipi.Visible = false;
        }

        protected void lbAnlasmaliFiyatHata_Click(object sender, EventArgs e)
        {
            Session["SMREF"] = null;
            Session["RISKBAKIYE"] = null;
            Session["FiyatTipi"] = null;
            Session["Aktivite"] = null;
            divAnlasmaliFiyatHata.Visible = false;
            divFiyatTipi.Visible = false;
        }

        protected void ibCHduzenle_Click(object sender, ImageClickEventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
            {
                string satkod1 = SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                string satkod = SatisTemsilcileri.GetSATKODBySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));
                if (satkod1.StartsWith("8"))
                {
                    Response.Redirect("sattemcariduzenleme.aspx", true);
                }
                else if (satkod.Substring(10).StartsWith("08"))
                {
                    Session["SatTemCariDuzenlemeYoneticininSectigiSLSREF"] = Convert.ToInt32(ddlSefAltlar.SelectedValue);
                    Response.Redirect("sattemcariduzenleme.aspx", true);
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            {
                string satkod1 = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));
                string satkod = SatisTemsilcileri.GetSATKODBySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));
                if (satkod1.StartsWith("8") || satkod.Substring(10).StartsWith("08"))
                {
                    Session["SatTemCariDuzenlemeYoneticininSectigiSLSREF"] = Convert.ToInt32(ddlSefAltlar.SelectedValue);
                    Response.Redirect("sattemcariduzenleme.aspx", true);
                }
            }
        }

        protected void lbFiyatlar_Click(object sender, EventArgs e)
        {
            ddlFiyatlarFiyatTipleri.Items.Clear();
            ddlFiyatlarFiyatTipleri.Items.Add("Seçiniz");
            ddlFiyatlarFiyatTipleri.Items[0].Value = "0";

            for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]);
                string fiyattipi = FiyatTipleri.GetObjectByID(fiyattipiid);

                ddlFiyatlarFiyatTipleri.Items.Add(fiyattipi);
                ddlFiyatlarFiyatTipleri.Items[i + 1].Value = fiyattipiid.ToString();
            }

            divFiyatlarFiyatTipi.Visible = true;
        }

        protected void lb500_Click(object sender, EventArgs e)
        {
            Response.Redirect("anlasmalifiyatlar.aspx", true);
        }

        protected void lbAdresBankasi_Click(object sender, EventArgs e)
        {
            Response.Redirect("adresbankasi.aspx", true);
        }

        protected void lbKimNe_Click(object sender, EventArgs e)
        {
            Response.Redirect("kimne.aspx", true);
        }

        protected void lbFormlar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formlar/", true);
        }

        protected void lbRutlar_Click(object sender, EventArgs e)
        {
            Response.Redirect("rutlar.aspx", true);
        }

        protected void lbKonumlar_Click(object sender, EventArgs e)
        {
            Response.Redirect("konumlar.aspx", true);
        }

        protected void lbResimler_Click(object sender, EventArgs e)
        {
            Response.Redirect("resimler.aspx", true);
        }

        protected void lbGorseller_Click(object sender, EventArgs e)
        {
            Response.Redirect("gorseller.aspx", true);
        }

        protected void lbBrosurler_Click(object sender, EventArgs e)
        {
            Response.Redirect("brosur.aspx", true);
        }

        protected void lbBrosurler2_Click(object sender, EventArgs e)
        {
            Response.Redirect("katalog/", true);
        }

        protected void lbBrosurler3_Click(object sender, EventArgs e)
        {
            Response.Redirect("teshir/", true);
        }

        protected void lbBrosurler4_Click(object sender, EventArgs e)
        {
            Response.Redirect("sunumlar/", true);
        }

        protected void lbBrosurler5_Click(object sender, EventArgs e)
        {
            Response.Redirect("sosyalmedya/", true);
        }

        protected void lbBrosurler6_Click(object sender, EventArgs e)
        {
            Response.Redirect("odemesistemleri/", true);
        }

        protected void ddlFiyatlarFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["FiyatlarFiyatTipi"] = Convert.ToInt16(ddlFiyatlarFiyatTipleri.SelectedValue);
            Response.Redirect("fiyatlar.aspx", true);
        }

        protected void lbFiyatlarFiyatTipiKapat_Click(object sender, EventArgs e)
        {
            divFiyatlarFiyatTipi.Visible = false;
        }

        protected void btnMusteriAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (divSefAltlar.Visible)
                CariHesaplar.GetObjectsByMusteri(dt, txtMusteriAra.Text, Convert.ToInt32(ddlSefAltlar.SelectedValue));
            else
                CariHesaplar.GetObjectsByMusteri(dt, txtMusteriAra.Text, ((Musteriler)Session["Musteri"]).intSLSREF);
            dlMusteriArama.DataSource = dt;
            dlMusteriArama.DataBind();
            divMusteriArama.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbMusteriAramaKapat_Click(object sender, EventArgs e)
        {
            dlMusteriArama.DataBind();
            divMusteriArama.Visible = false;
        }

        protected void dlFiyatTipiNSTs_DataBound(object sender, EventArgs e)
        {
            lblFiyatTipiNSTsYok.Visible = dlFiyatTipiNSTs.Items.Count == 0;
        }

        protected void ibIadeIlgili_Click(object sender, ImageClickEventArgs e)
        {
            lblIadeIlgiliMusteri.Text = CariHesaplar.GetMUSTERIbySMREFmusterisube(Convert.ToInt32(((ImageButton)sender).CommandArgument));
            txtIadeIlgili.Text = CariHesapEk.GetIadeIlgiliBySMREF(Convert.ToInt32(((ImageButton)sender).CommandArgument));
            inputIadeIlgiliSMREF.Value = ((ImageButton)sender).CommandArgument;
            divIadeIlgili.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divIadeIlgili, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void ibKonum_Click(object sender, ImageClickEventArgs e)
        {
            int tip = Convert.ToInt32(inputBayiGibi.Value) == 1 ? 4 : 1;
            if (char.IsDigit(txtCoords1.Text.Trim()[0]))
            {
                Rutlar.SetKonum(Convert.ToInt32(((ImageButton)sender).CommandArgument), tip, txtCoords1.Text.Trim());
                ((ImageButton)sender).Visible = false;
                string alert = "<script type='text/javascript'>alert('Konum başarıyla alındı.');</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptAlert", alert, false);
            }
            else
            {
                string alert = "<script type='text/javascript'>alert('Konum alınamadı. Aygıtınızdaki konum ayarlarının açık olduğundan emin olun.');</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptAlert", alert, false);
            }
        }

        protected void lbIadeIlgiliKapat_Click(object sender, EventArgs e)
        {
            if (txtIadeIlgili.Text.Trim() != string.Empty)
            {
                if (CariHesapEk.GetIadeIlgiliVarMiBySMREF(Convert.ToInt32(inputIadeIlgiliSMREF.Value)))
                    CariHesapEk.DoUpdateIadeIlgili(txtIadeIlgili.Text.Trim(), Convert.ToInt32(inputIadeIlgiliSMREF.Value));
                else
                    CariHesapEk.DoInsert(Convert.ToInt32(inputIadeIlgiliSMREF.Value), txtIadeIlgili.Text.Trim());
            }
            
            divIadeIlgili.Visible = false;
        }

        protected void lbEFaturaIptal_Click(object sender, EventArgs e)
        {
            Session["EFaturaFaturaNolar"] = null;
            Session["EFaturaAlias"] = null;
            Session["EFaturaProgram"] = null;
            Calendar3.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
            Calendar4.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());

            divEFaturaTarih.Visible = false;
            divEFaturaFaturalar.Visible = false;
            divEFaturaAlias.Visible = false;
        }

        protected void lbEFatura_Click(object sender, EventArgs e)
        {
            lblEFaturaTarihSecim1.Text = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString()).ToShortDateString();
            lblEFaturaTarihSecim2.Text = DateTime.Now.ToShortDateString();

            divEFaturaTarih.Visible = true;
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            lblEFaturaTarihSecim1.Text = Calendar3.SelectedDate.ToShortDateString();
        }

        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            lblEFaturaTarihSecim2.Text = Calendar4.SelectedDate.ToShortDateString();
        }

        protected void lbEFaturaTarihDevam_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //Efatura.GetFATNOFATTARTURACKByGMREF(dt, ((Musteriler)Session["Musteri"]).intGMREF, Calendar3.SelectedDate, Calendar4.SelectedDate);
            //rpEFaturaFaturalar.DataSource = dt;
            //rpEFaturaFaturalar.DataBind();

            Efatura.GetFATNOFATTARTURACKByGMREF(cblEFaturaFaturalar.Items, ((Musteriler)Session["Musteri"]).intGMREF, Calendar3.SelectedDate, Calendar4.SelectedDate);

            lblEFaturaFaturalarSayi.Text = cblEFaturaFaturalar.Items.Count.ToString();

            divEFaturaTarih.Visible = false;
            divEFaturaFaturalar.Visible = true;
        }

        protected void lbEFaturaFaturalarDevam_Click(object sender, EventArgs e)
        {
            ArrayList alFaturaNolar = new ArrayList();
            bool enazbirfaturasecildi = false;
            for (int i = 0; i < cblEFaturaFaturalar.Items.Count; i++)
            {
                if (cblEFaturaFaturalar.Items[i].Selected)
                {
                    alFaturaNolar.Add(cblEFaturaFaturalar.Items[i].Value);
                    enazbirfaturasecildi = true;
                }
            }

            if (enazbirfaturasecildi)
            {
                Session["EFaturaFaturaNolar"] = alFaturaNolar;

                Efatura.GetIDAdByMusteriID(ddlEFaturaAliasSecim.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

                divEFaturaFaturalar.Visible = false;
                divEFaturaAlias.Visible = true;
            }
        }

        protected void ddlEFaturaAliasSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEFaturaAliasSecim.SelectedValue != "0")
            {
                cbEFaturaAliasKaydet.Checked = false;
                cbEFaturaAliasKaydet.Enabled = false;
                txtEFaturaAliasKaydetAd.Enabled = false;
                lbEFaturaAliasSecimSil.Visible = true;
                lbEFaturaAliasSil.Visible = false;
                lbEFaturaAliasVarsayilan.Visible = false;

                foreach (Control ctrl in tblEFaturaAlias.Controls)
                    foreach (Control ctrl2 in ctrl.Controls)
                        foreach (Control ctrl3 in ctrl2.Controls)
                            if (ctrl3 is TextBox)
                                ((TextBox)ctrl3).Enabled = false;

                Efatura ef = Efatura.GetObject(Convert.ToInt32(ddlEFaturaAliasSecim.SelectedValue));
                txtEFaturaAliasKaydetAd.Text = ef.strAd;
                txtEFaturaAliasLT.Text = ef.LT;
                txtEFaturaAliasBOLGE.Text = ef.BOLGE;
                txtEFaturaAliasGRP.Text = ef.GRP;
                txtEFaturaAliasEKP.Text = ef.EKP;
                txtEFaturaAliasABRNO.Text = ef.ABRNO;
                txtEFaturaAliasAMBAR.Text = ef.AMBAR;
                txtEFaturaAliasAY.Text = ef.AY;
                txtEFaturaAliasHAFTA.Text = ef.HAFTA;
                txtEFaturaAliasFATTAR.Text = ef.FATTAR;
                txtEFaturaAliasFATNO.Text = ef.FATNO;
                txtEFaturaAliasFATVD.Text = ef.FATVD;
                txtEFaturaAliasTUR.Text = ef.TUR;
                txtEFaturaAliasTURACK.Text = ef.TURACK;
                txtEFaturaAliasFTUR.Text = ef.FTUR;
                txtEFaturaAliasSLSREF.Text = ef.SLSREF;
                txtEFaturaAliasSATKOD.Text = ef.SATKOD;
                txtEFaturaAliasSATTEM.Text = ef.SATTEM;
                txtEFaturaAliasTEDEKP.Text = ef.TEDEKP;
                txtEFaturaAliasTEDSLSREF.Text = ef.TEDSLSREF;
                txtEFaturaAliasTEDSATTEM.Text = ef.TEDSATTEM;
                txtEFaturaAliasIL.Text = ef.IL;
                txtEFaturaAliasILCE.Text = ef.ILCE;
                txtEFaturaAliasMTACIKLAMA.Text = ef.MTACIKLAMA;
                txtEFaturaAliasGMREF.Text = ef.GMREF;
                txtEFaturaAliasMUSKOD.Text = ef.MUSKOD;
                txtEFaturaAliasMUSTERI.Text = ef.MUSTERI;
                txtEFaturaAliasSMREF.Text = ef.SMREF;
                txtEFaturaAliasSUBKOD.Text = ef.SUBKOD;
                txtEFaturaAliasSUBE.Text = ef.SUBE;
                txtEFaturaAliasSEVKKOD.Text = ef.SEVKKOD;
                txtEFaturaAliasSEVKADRES.Text = ef.SEVKADRES;
                txtEFaturaAliasREYKOD.Text = ef.REYKOD;
                txtEFaturaAliasREYON.Text = ef.REYON;
                txtEFaturaAliasANAGRP.Text = ef.ANAGRP;
                txtEFaturaAliasGRPKOD.Text = ef.GRPKOD;
                txtEFaturaAliasGRUP.Text = ef.GRUP;
                txtEFaturaAliasTEDGRP.Text = ef.TEDGRP;
                txtEFaturaAliasTEDKISAMAL.Text = ef.TEDKISAMAL;
                txtEFaturaAliasBARCODE.Text = ef.BARCODE;
                txtEFaturaAliasITEMREF.Text = ef.ITEMREF;
                txtEFaturaAliasMALKOD.Text = ef.MALKOD;
                txtEFaturaAliasMALZEME.Text = ef.MALZEME;
                txtEFaturaAliasKOLI.Text = ef.KOLI;
                txtEFaturaAliasKDV.Text = ef.KDV;
                txtEFaturaAliasBRM.Text = ef.BRM;
                txtEFaturaAliasADT.Text = ef.ADT;
                txtEFaturaAliasISK1.Text = ef.ISK1;
                txtEFaturaAliasISK2.Text = ef.ISK2;
                txtEFaturaAliasISK3.Text = ef.ISK3;
                txtEFaturaAliasISK4.Text = ef.ISK4;
                txtEFaturaAliasISK5.Text = ef.ISK5;
                txtEFaturaAliasISKALT.Text = ef.ISKALT;
                txtEFaturaAliasBRUTT.Text = ef.BRUTT;
                txtEFaturaAliasISKT.Text = ef.ISKT;
                txtEFaturaAliasNETT.Text = ef.NETT;
                txtEFaturaAliasKDVT.Text = ef.KDVT;
                txtEFaturaAliasNETKDVT.Text = ef.NETKDVT;
            }
            else
            {
                cbEFaturaAliasKaydet.Checked = false;
                cbEFaturaAliasKaydet.Enabled = true;
                txtEFaturaAliasKaydetAd.Enabled = true;
                txtEFaturaAliasKaydetAd.Text = string.Empty;
                lbEFaturaAliasSecimSil.Visible = false;
                lbEFaturaAliasSil.Visible = true;
                lbEFaturaAliasVarsayilan.Visible = true;

                foreach (Control ctrl in tblEFaturaAlias.Controls)
                    foreach (Control ctrl2 in ctrl.Controls)
                        foreach (Control ctrl3 in ctrl2.Controls)
                            if (ctrl3 is TextBox)
                                ((TextBox)ctrl3).Enabled = true;
            }
        }

        protected void lbEFaturaAliasSecimSil_Click(object sender, EventArgs e)
        {
            Efatura ef = Efatura.GetObject(Convert.ToInt32(ddlEFaturaAliasSecim.SelectedValue));
            ef.DoDelete();
            Efatura.GetIDAdByMusteriID(ddlEFaturaAliasSecim.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

            ddlEFaturaAliasSecim.SelectedIndex = 0;
            cbEFaturaAliasKaydet.Checked = false;
            cbEFaturaAliasKaydet.Enabled = true;
            txtEFaturaAliasKaydetAd.Enabled = true;
            txtEFaturaAliasKaydetAd.Text = string.Empty;
            lbEFaturaAliasSecimSil.Visible = false;
            lbEFaturaAliasSil.Visible = true;
            lbEFaturaAliasVarsayilan.Visible = true;

            foreach (Control ctrl in tblEFaturaAlias.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    foreach (Control ctrl3 in ctrl2.Controls)
                    {
                        if (ctrl3 is TextBox)
                        {
                            ((TextBox)ctrl3).Enabled = true;
                            ((TextBox)ctrl3).Text = ((TextBox)ctrl3).ID.Substring(15);
                        }
                    }
                }
            }
        }

        protected void cbEFaturaAliasKaydet_CheckedChanged(object sender, EventArgs e)
        {
            txtEFaturaAliasKaydetAd.Enabled = cbEFaturaAliasKaydet.Checked;
        }

        protected void lbEFaturaAliasSil_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in tblEFaturaAlias.Controls)
                foreach (Control ctrl2 in ctrl.Controls)
                    foreach (Control ctrl3 in ctrl2.Controls)
                        if (ctrl3 is TextBox)
                            ((TextBox)ctrl3).Text = string.Empty;
        }

        protected void lbEFaturaAliasVarsayilan_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in tblEFaturaAlias.Controls)
                foreach (Control ctrl2 in ctrl.Controls)
                    foreach (Control ctrl3 in ctrl2.Controls)
                        if (ctrl3 is TextBox)
                            ((TextBox)ctrl3).Text = ((TextBox)ctrl3).ID.Substring(15);
        }

        protected void lbEFaturaIndir_Click(object sender, EventArgs e)
        {
            if (rbEFaturaAliasIlon.Checked)
            {
                Session["EFaturaAlias"] = null;
                Session["EFaturaProgram"] = "ilon";
            }
            else if (rbEFaturaAliasEczanem.Checked)
            {
                Session["EFaturaAlias"] = null;
                Session["EFaturaProgram"] = "eczanem";
            }
            else if (rbEFaturaAliasTebeos.Checked)
            {
                Session["EFaturaAlias"] = null;
                Session["EFaturaProgram"] = "tebeos";
            }
            else if (rbEFaturaAliasBelirleme.Checked)
            {
                Session["EFaturaProgram"] = null;

                if (cbEFaturaAliasKaydet.Checked && txtEFaturaAliasKaydetAd.Text.Trim() == string.Empty)
                {
                    return;
                }
                else if (cbEFaturaAliasKaydet.Checked)
                {
                    Efatura efat = new Efatura(
                        ((Musteriler)Session["Musteri"]).pkMusteriID,
                        txtEFaturaAliasKaydetAd.Text.Trim(),
                        DateTime.Now,
                        txtEFaturaAliasLT.Text.Trim(),
                        txtEFaturaAliasBOLGE.Text.Trim(),
                        txtEFaturaAliasGRP.Text.Trim(),
                        txtEFaturaAliasEKP.Text.Trim(),
                        txtEFaturaAliasABRNO.Text.Trim(),
                        txtEFaturaAliasAMBAR.Text.Trim(),
                        txtEFaturaAliasAY.Text.Trim(),
                        txtEFaturaAliasHAFTA.Text.Trim(),
                        txtEFaturaAliasFATTAR.Text.Trim(),
                        txtEFaturaAliasFATNO.Text.Trim(),
                        txtEFaturaAliasFATVD.Text.Trim(),
                        txtEFaturaAliasTUR.Text.Trim(),
                        txtEFaturaAliasTURACK.Text.Trim(),
                        txtEFaturaAliasFTUR.Text.Trim(),
                        txtEFaturaAliasSLSREF.Text.Trim(),
                        txtEFaturaAliasSATKOD.Text.Trim(),
                        txtEFaturaAliasSATTEM.Text.Trim(),
                        txtEFaturaAliasTEDEKP.Text.Trim(),
                        txtEFaturaAliasTEDSLSREF.Text.Trim(),
                        txtEFaturaAliasTEDSATTEM.Text.Trim(),
                        txtEFaturaAliasIL.Text.Trim(),
                        txtEFaturaAliasILCE.Text.Trim(),
                        txtEFaturaAliasMTACIKLAMA.Text.Trim(),
                        txtEFaturaAliasGMREF.Text.Trim(),
                        txtEFaturaAliasMUSKOD.Text.Trim(),
                        txtEFaturaAliasMUSTERI.Text.Trim(),
                        txtEFaturaAliasSMREF.Text.Trim(),
                        txtEFaturaAliasSUBKOD.Text.Trim(),
                        txtEFaturaAliasSUBE.Text.Trim(),
                        txtEFaturaAliasSEVKKOD.Text.Trim(),
                        txtEFaturaAliasSEVKADRES.Text.Trim(),
                        txtEFaturaAliasREYKOD.Text.Trim(),
                        txtEFaturaAliasREYON.Text.Trim(),
                        txtEFaturaAliasANAGRP.Text.Trim(),
                        txtEFaturaAliasGRPKOD.Text.Trim(),
                        txtEFaturaAliasGRUP.Text.Trim(),
                        txtEFaturaAliasTEDGRP.Text.Trim(),
                        txtEFaturaAliasTEDKISAMAL.Text.Trim(),
                        txtEFaturaAliasBARCODE.Text.Trim(),
                        txtEFaturaAliasITEMREF.Text.Trim(),
                        txtEFaturaAliasMALKOD.Text.Trim(),
                        txtEFaturaAliasMALZEME.Text.Trim(),
                        txtEFaturaAliasKOLI.Text.Trim(),
                        txtEFaturaAliasKDV.Text.Trim(),
                        txtEFaturaAliasBRM.Text.Trim(),
                        txtEFaturaAliasADT.Text.Trim(),
                        txtEFaturaAliasISK1.Text.Trim(),
                        txtEFaturaAliasISK2.Text.Trim(),
                        txtEFaturaAliasISK3.Text.Trim(),
                        txtEFaturaAliasISK4.Text.Trim(),
                        txtEFaturaAliasISK5.Text.Trim(),
                        txtEFaturaAliasISKALT.Text.Trim(),
                        txtEFaturaAliasBRUTT.Text.Trim(),
                        txtEFaturaAliasISKT.Text.Trim(),
                        txtEFaturaAliasNETT.Text.Trim(),
                        txtEFaturaAliasKDVT.Text.Trim(),
                        txtEFaturaAliasNETKDVT.Text.Trim());
                    efat.DoInsert();
                }

                Session["EFaturaAlias"] = new EFatura(
                txtEFaturaAliasLT.Text.Trim(),
                txtEFaturaAliasBOLGE.Text.Trim(),
                txtEFaturaAliasGRP.Text.Trim(),
                txtEFaturaAliasEKP.Text.Trim(),
                txtEFaturaAliasABRNO.Text.Trim(),
                txtEFaturaAliasAMBAR.Text.Trim(),
                txtEFaturaAliasAY.Text.Trim(),
                txtEFaturaAliasHAFTA.Text.Trim(),
                txtEFaturaAliasFATTAR.Text.Trim(),
                txtEFaturaAliasFATNO.Text.Trim(),
                txtEFaturaAliasFATVD.Text.Trim(),
                txtEFaturaAliasTUR.Text.Trim(),
                txtEFaturaAliasTURACK.Text.Trim(),
                txtEFaturaAliasFTUR.Text.Trim(),
                txtEFaturaAliasSLSREF.Text.Trim(),
                txtEFaturaAliasSATKOD.Text.Trim(),
                txtEFaturaAliasSATTEM.Text.Trim(),
                txtEFaturaAliasTEDEKP.Text.Trim(),
                txtEFaturaAliasTEDSLSREF.Text.Trim(),
                txtEFaturaAliasTEDSATTEM.Text.Trim(),
                txtEFaturaAliasIL.Text.Trim(),
                txtEFaturaAliasILCE.Text.Trim(),
                txtEFaturaAliasMTACIKLAMA.Text.Trim(),
                txtEFaturaAliasGMREF.Text.Trim(),
                txtEFaturaAliasMUSKOD.Text.Trim(),
                txtEFaturaAliasMUSTERI.Text.Trim(),
                txtEFaturaAliasSMREF.Text.Trim(),
                txtEFaturaAliasSUBKOD.Text.Trim(),
                txtEFaturaAliasSUBE.Text.Trim(),
                txtEFaturaAliasSEVKKOD.Text.Trim(),
                txtEFaturaAliasSEVKADRES.Text.Trim(),
                txtEFaturaAliasREYKOD.Text.Trim(),
                txtEFaturaAliasREYON.Text.Trim(),
                txtEFaturaAliasANAGRP.Text.Trim(),
                txtEFaturaAliasGRPKOD.Text.Trim(),
                txtEFaturaAliasGRUP.Text.Trim(),
                txtEFaturaAliasTEDGRP.Text.Trim(),
                txtEFaturaAliasTEDKISAMAL.Text.Trim(),
                txtEFaturaAliasBARCODE.Text.Trim(),
                txtEFaturaAliasITEMREF.Text.Trim(),
                txtEFaturaAliasMALKOD.Text.Trim(),
                txtEFaturaAliasMALZEME.Text.Trim(),
                txtEFaturaAliasKOLI.Text.Trim(),
                txtEFaturaAliasKDV.Text.Trim(),
                txtEFaturaAliasBRM.Text.Trim(),
                txtEFaturaAliasADT.Text.Trim(),
                txtEFaturaAliasISK1.Text.Trim(),
                txtEFaturaAliasISK2.Text.Trim(),
                txtEFaturaAliasISK3.Text.Trim(),
                txtEFaturaAliasISK4.Text.Trim(),
                txtEFaturaAliasISK5.Text.Trim(),
                txtEFaturaAliasISKALT.Text.Trim(),
                txtEFaturaAliasBRUTT.Text.Trim(),
                txtEFaturaAliasISKT.Text.Trim(),
                txtEFaturaAliasNETT.Text.Trim(),
                txtEFaturaAliasKDVT.Text.Trim(),
                txtEFaturaAliasNETKDVT.Text.Trim());
            }



            string alert = "<script type='text/javascript'>window.location.href = 'download.aspx?efatura=true';</script>";
            ScriptManager.RegisterStartupScript(divEFaturaAlias, typeof(string), "scriptSayfaAc", alert, false);

            divEFaturaAlias.Visible = false;
        }

        protected void rbEFaturaAliasBelirleme_CheckedChanged(object sender, EventArgs e)
        {
            divEFaturaAliasBelirleme.Visible = rbEFaturaAliasBelirleme.Checked;
        }

        protected void cblAnlasmaHizmetBedelleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblAnlasmaHizmetBedelleri.Visible = false;

            for (int i = 0; i < cblAnlasmaHizmetBedelleri.Items.Count; i++)
            {
                if (cblAnlasmaHizmetBedelleri.Items[i].Selected)
                {
                    tblAnlasmaHizmetBedelleri.Visible = true;
                }
            }

            foreach (ListItem li in cblAnlasmaHizmetBedelleri.Items)
            {
                foreach (Control ctrl in pnlAnlasmaHizmetBedelleri.Controls)
                {
                    if (ctrl.ID == "divAnlasmaHizmetBedeli" + li.Value)
                    {
                        if (li.Selected)
                        {
                            ctrl.Visible = true;

                            foreach (Control ctrl2 in ctrl.Controls)
                            {
                                if (ctrl2.ID == "lblAnlasmaHizmetBedeli" + li.Value)
                                {
                                    ((Label)ctrl2).Text = li.Text;
                                }
                                //else if (ctrl2.ID == "ddlDil" + li.Value + "Okuma" || ctrl2.ID == "ddlDil" + li.Value + "Yazma" || ctrl2.ID == "ddlDil" + li.Value + "Konusma")
                                //{
                                //    Dereceler.GetObject(((DropDownList)ctrl2).Items);
                                //}
                            }
                        }
                        else
                        {
                            ctrl.Visible = false;
                        }
                    }
                }
            }
        }

        protected void ddlAltCariEkleIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ilceler.GetObject(ddlAltCariEkleIlce.Items, ddlAltCariEkleIl.SelectedValue);
        }

        protected void btnAltCari_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in divAltCariEkle.Controls)
            {
                if (ctrl is TextBox && ctrl.ID.StartsWith("txtAltCariEkle"))
                {
                    ((TextBox)ctrl).Text = "";
                }
            }

            Iller.GetObject(ddlAltCariEkleIl.Items);
            ddlAltCariEkleIlce.Items.Clear();
            divAltCariEkle.Visible = true;

            btnAltCariEkle.Text = "Ekle";
            btnAltCariEkle.CommandArgument = "";
            txtAltCariEkleCari.Enabled = true;
        }

        protected void btnAltCariEkleVazgec_Click(object sender, EventArgs e)
        {
            divAltCariEkle.Visible = false;
        }

        protected void lbAltCariHataKapat_Click(object sender, EventArgs e)
        {
            divAltCariHata.Visible = false;
        }

        protected void btnAltCariEkle_Click(object sender, EventArgs e)
        {
            if (btnAltCariEkle.Text == "Ekle")
            {
                if (CariHesaplarTP.GetNoktaVarMi(txtAltCariEkleCari.Text, Convert.ToInt32(inputGMREF.Value)))
                {
                    divAltCariHata.Visible = true;
                    return;
                }

                CariHesaplarTP altcari = new CariHesaplarTP(0, "", "", "", "", ddlAltCariEkleIl.SelectedItem.Value, ddlAltCariEkleIl.SelectedItem.Text,
                    ddlAltCariEkleIlce.SelectedItem.Value, ddlAltCariEkleIlce.SelectedItem.Text, 0, "", txtAltCariEkleAciklama.Text.Trim(), "",
                    ((Musteriler)Session["Musteri"]).intSLSREF,
                    "", "", "", Convert.ToInt32(inputGMREF.Value), "", txtAltCariEkleCari.Text,
                    CariHesaplarTP.GetLastSMREF() + 1, "", txtAltCariEkleCari.Text, txtAltCariEkleAdres.Text.Trim(), "",
                    rbKonumAl.Checked ? txtCoords1.Text.Trim() : "-Konum Alınmadı",
                    txtAltCariEkleVergiDairesi.Text.Trim(), txtAltCariEkleVergiNo.Text.Trim(), txtAltCariEkleTelefon.Text.Trim(),
                    txtAltCariEkleFax.Text.Trim(), txtAltCariEkleEposta.Text.Trim(), "", txtAltCariEkleCep.Text.Trim(), 0);
                altcari.DoInsert();

                GetSubeler(Convert.ToInt32(inputGMREF.Value));

                divAltCariEkle.Visible = false;
            }
            else if (btnAltCariEkle.Text == "Güncelle")
            {
                CariHesaplarTP altcari = CariHesaplarTP.GetObject(Convert.ToInt32(btnAltCariEkle.CommandArgument), false);
                altcari.ILKOD = ddlAltCariEkleIl.SelectedItem.Value;
                altcari.ILCEKOD = ddlAltCariEkleIlce.SelectedItem.Value;
                altcari.MTACIKLAMA = txtAltCariEkleAciklama.Text.Trim();
                altcari.ADRES = txtAltCariEkleAdres.Text.Trim();
                altcari.SEMT = rbKonumAl.Checked ? txtCoords1.Text : altcari.SEMT;
                altcari.VRGDAIRE = txtAltCariEkleVergiDairesi.Text.Trim();
                altcari.VRGNO = txtAltCariEkleVergiNo.Text.Trim();
                altcari.TEL1 = txtAltCariEkleTelefon.Text.Trim();
                altcari.CEP1 = txtAltCariEkleCep.Text.Trim();
                altcari.FAX1 = txtAltCariEkleFax.Text.Trim();
                altcari.EMAIL1 = txtAltCariEkleEposta.Text.Trim();
                altcari.DoUpdate();

                GetSubeler(Convert.ToInt32(inputGMREF.Value));

                divAltCariEkle.Visible = false;
            }
        }

        protected void CariDuzenle_Click(object sender, EventArgs e)
        {
            divAltCariEkle.Visible = true;

            CariHesaplarTP altcari = CariHesaplarTP.GetObject(Convert.ToInt32(((LinkButton)sender).CommandArgument), false);
            txtAltCariEkleCari.Text = altcari.SUBE;
            txtAltCariEkleCari.Enabled = false;

            Iller.GetObject(ddlAltCariEkleIl.Items);
            for (int i = 0; i < ddlAltCariEkleIl.Items.Count; i++)
                if (ddlAltCariEkleIl.Items[i].Value == altcari.ILKOD)
                    ddlAltCariEkleIl.SelectedIndex = i;

            Ilceler.GetObject(ddlAltCariEkleIlce.Items, ddlAltCariEkleIl.SelectedItem.Value);
            for (int i = 0; i < ddlAltCariEkleIlce.Items.Count; i++)
                if (ddlAltCariEkleIlce.Items[i].Value == altcari.ILCEKOD)
                    ddlAltCariEkleIlce.SelectedIndex = i;

            txtAltCariEkleAciklama.Text = altcari.MTACIKLAMA;
            txtAltCariEkleAdres.Text = altcari.ADRES;
            txtAltCariEkleVergiDairesi.Text = altcari.VRGDAIRE;
            txtAltCariEkleVergiNo.Text = altcari.VRGNO;
            txtAltCariEkleTelefon.Text = altcari.TEL1;
            txtAltCariEkleCep.Text = altcari.CEP1;
            txtAltCariEkleFax.Text = altcari.FAX1;
            txtAltCariEkleEposta.Text = altcari.EMAIL1;

            btnAltCariEkle.Text = "Güncelle";
            btnAltCariEkle.CommandArgument = altcari.SMREF.ToString();

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divAltCariEkle, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void btnGenelAktivite_Click(object sender, EventArgs e)
        {
            Session["SMREFakt"] = Convert.ToInt32(inputGMREF.Value); // gmref ile smref aynı
            Session["flAktiviteKarZararYuzde"] = 1;
            Session["FiyatTipi"] = "25";
            Session["AktiviteID"] = 0;
            Response.Redirect("aktivite.aspx", true);
        }

        protected void cbBakiye_OnCheckedChanged(object sender, EventArgs e)
        {
            int slsref = ((Musteriler)Session["Musteri"]).intSLSREF == 0 ? Convert.ToInt32(ddlSefAltlar.SelectedValue) : ((Musteriler)Session["Musteri"]).intSLSREF;
            WebMusteriEk.SetBakiye(Convert.ToInt32(((CheckBox)sender).ToolTip), slsref, ((CheckBox)sender).Checked, ((Musteriler)Session["Musteri"]).pkMusteriID, DateTime.Now);
        }

        protected string GetKonum(int SMREF, int MusTip)
        {
            return "https://maps.google.com?q=" + Rutlar.GetKonum(SMREF, MusTip);
        }

        protected void KonumSil_Click(object sender, EventArgs e)
        {
            int smref = Convert.ToInt32(((LinkButton)sender).CommandArgument.Substring(0, 7));
            int tip = Convert.ToInt32(((LinkButton)sender).CommandArgument[7].ToString());
            Rutlar.SetKonum(smref, tip, string.Empty);
            ((LinkButton)sender).Visible = false;
            string alert = "<script type='text/javascript'>alert('Konum silindi.');</script>";
            ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptAlert", alert, false);
        }

        protected void lbZiyaretHata2konum_Click(object sender, EventArgs e)
        {
            divZiyaretHata2.Visible = false;

            if (char.IsDigit(txtCoords1.Text.Trim()[0]))
            {
                Rutlar.SetKonum(Convert.ToInt32(Convert.ToInt32(inputZiyaretHata2smref.Value)), Convert.ToInt32(inputZiyaretHata2tip.Value), txtCoords1.Text.Trim());
                string alert = "<script type='text/javascript'>alert('Konum başarıyla alındı ve ziyaret başlatıldı.');</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptAlert", alert, false);

                bool konumyok;
                bool mevcutkonumyok;
                ZiyaretBaslat(Convert.ToInt32(Convert.ToInt32(inputZiyaretHata2smref.Value)), inputZiyaretHata2barkod.Value, Convert.ToDateTime(inputZiyaretHata2ziygun.Value), Convert.ToInt32(inputZiyaretHata2tip.Value), out konumyok, out mevcutkonumyok);
            }
            else
            {
                string alert = "<script type='text/javascript'>alert('Konum alınamadı. Aygıtınızdaki konum ayarlarının açık olduğundan emin olun.');</script>";
                ScriptManager.RegisterStartupScript(divAjaxDefault, typeof(string), "scriptAlert", alert, false);
            }
        }
    }
}