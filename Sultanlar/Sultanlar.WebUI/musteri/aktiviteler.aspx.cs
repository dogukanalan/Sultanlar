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
    public partial class aktiviteler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 6 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 2 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 4) // bayi yöneticisi veya yönetici değil ise veya satıcı değil ise
                Response.Redirect("yetkiyok.aspx", true);

            if (((Musteriler)Session["Musteri"]).blSicakSatis) // merch ise
                Response.Redirect("yetkiyok.aspx", true);

            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.AddYears(-1).Year.ToString()); ;
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
                lblTarihSecim1.Text = Convert.ToDateTime("01.01." + DateTime.Now.AddYears(-1).Year.ToString()).ToShortDateString();
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

                Session["AktivitelerSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intSiparisSatirSayisi;

                GetCariHesaplar();

                if (Session["AktiviteTamamlaBasildi"] != null)
                {
                    Session["AktiviteGetirilecekSMREF"] = Session["AktiviteTamamlaBasildi"];
                    Session["AktiviteTamamlaBasildi"] = null;
                    Session["OnaylanacakAktiviteID"] = Session["AktiviteTamamlaBasildiAktiviteID"];
                }
                else if (Session["AktiviteTamamlaOnaylaBasildi"] != null)
                {
                    divSevkYerleri.Visible = true;
                    Session["AktiviteTamamlaOnaylaBasildi"] = null;
                }

                inputTopluIslemGosterGizle.Value = "kapali";

                ddlDonemAy.SelectedIndex = DateTime.Now.Month - 1;
            }

            string alert1 = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "kucukbilgi", alert1, false);
        }

        private void GetCariHesaplar()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
            {
                /*SAP*/
                ArrayList st = SatisTemsilcileri.GetObjectBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                if (st.Count > 0)
                    ddlTemsilciler.Items.Add(new ListItem(st[1].ToString(), ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                else
                    ddlTemsilciler.Items.Add(new ListItem("-", ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));

                CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, true); ddlCariHesaplar.SelectedValue = "1";
                
                ddlCariHesaplarSubeler.Visible = false;
                Getir(0);
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satıcı ise
            {
                GetSatisSefYoneticiHesaplar();
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, true);
                ddlTemsilciler.SelectedIndex = 1;

                divCariHesapArama.Visible = true;
                ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));
                ddlCariHesaplar.SelectedIndex = 1;

                GetSiparisCount();
                GetSiparisler(0, (int)Session["AktivitelerSayfaBasiGosterim"]);
            }
        }

        private void GetSatisSefYoneticiHesaplar()
        {
            ArrayList altlar = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
                altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);


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
                GetSiparisCountBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 7);
                GetSiparislerBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 7, 0, (int)Session["AktivitelerSayfaBasiGosterim"]);
            }
            else // şef ise
            {
                SatisTemsilcileri.GetObjectsBySLSREFs(ddlTemsilciler.Items, altlar, false);

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
            }
        }

        #region BySMREF
        private int GetSiparisCountBySMREF(int SMREF, short FiyatTip)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            int donendeger = Aktiviteler.GetAktiviteCountBySMREF(FiyatTip, SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli, Hepsi);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["AktivitelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AktivitelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySMREF(int SMREF, short FiyatTip, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            DataTable dt = new DataTable();
            Aktiviteler.GetObjectsBySMREF(FiyatTip, dt, SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli, Hepsi);

            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();
        }
        #endregion

        #region ByGMREF
        // parametre ile gelen GMREF fuzuli çünkü smref leri ddlcarihesapsubeler den alıyoruz (uyetipini almada kullandım)
        private int GetSiparisCountByGMREF(int GMREF, short FiyatTip)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            //DataTable dt = new DataTable();
            //CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            //int donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs);
            int donendeger = Aktiviteler.GetAktiviteCountBySMREFs(FiyatTip, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli, Hepsi);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["AktivitelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AktivitelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerByGMREF(int GMREF, short FiyatTip, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            //DataTable dt = new DataTable();
            //CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            DataTable dtSiparisler = new DataTable();
            Aktiviteler.GetObjectsBySMREFs(FiyatTip, dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli, Hepsi);

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region BySLSREF
        private int GetSiparisCountBySLSREF(int SLSREF, short FiyatTip)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            ArrayList SMREFs = new ArrayList();
            int uyeid = Musteriler.GetMusteriIDbySLSREF(SLSREF);

            if (FiyatTip == 25)
            {
                CariHesaplarTP.GetSMREFsBySLSREFcarihesaplardaneslesmeli(SMREFs, SLSREF);
                //CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF); // üzerine ekliyor
            }
            else if (FiyatTip == 7)
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);

            int donendeger = Aktiviteler.GetAktiviteCountBySMREFs(FiyatTip, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli, Hepsi);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["AktivitelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AktivitelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySLSREF(int SLSREF, short FiyatTip, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            ArrayList SMREFs = new ArrayList();
            int uyeid = Musteriler.GetMusteriIDbySLSREF(SLSREF);

            if (FiyatTip == 25)
            {
                CariHesaplarTP.GetSMREFsBySLSREFcarihesaplardaneslesmeli(SMREFs, SLSREF);
                //CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF); // üzerine ekliyor
            }
            else if (FiyatTip == 7)
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);

            DataTable dtSiparisler = new DataTable();
            Aktiviteler.GetObjectsBySMREFs(FiyatTip, dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli, Hepsi);

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region All
        private int GetSiparisCount()
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            int donendeger = Aktiviteler.GetAktiviteCount(Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli, Hepsi);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["AktivitelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AktivitelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparisler(int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;
            else if (rbSiparislerHepsi.Checked)
                Hepsi = true;

            DataTable dtSiparisler = new DataTable();
            Aktiviteler.GetObjects(dtSiparisler, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli, Hepsi, "BI04");

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        private bool SiparisOnayla(int aktiviteid)
        {
            Aktiviteler aktivite = Aktiviteler.GetObject(aktiviteid);
            aktivite.dtOnaylamaTarihi = DateTime.Now;
            aktivite.DoUpdate();

            aktivite.DoReddet();

            return true;
        }

        private void GetSiparisFromDB(int AktiviteID)
        {
            Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);

            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);

            AktiviteListe1 aktlist = new AktiviteListe1(aktivite.intMusteriID, aktivite.SMREF, aktivite.sintFiyatTipiID, aktivite.intAktiviteTipiID, false);
            aktlist._AktiviteID = AktiviteID;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long aktivitedetayid = Convert.ToInt64(dt.Rows[i]["pkID"]);
                aktlist.Add(aktivitedetayid);
            }

            SiparisIncele(aktlist);

            lblSiparisAciklama.Text = aktivite.strAciklama1 + " - " + aktivite.strAciklama2 + " - " + aktivite.strAciklama3;
        }

        private void SiparisIncele(AktiviteListe1 aktlist)
        {
            divSiparis.Visible = true;
            lblSiparisSonDurum.Visible = false;
            lbOnaylamayaDevam.Visible = false;
            lblSiparisDetaylari.Visible = true;

            Repeater1.DataSource = aktlist;
            Repeater1.DataBind();
            lblSiparisToplam.Text = aktlist.ToplamTutar.ToString("C3");
        }

        private void Getir(int Baslangic)
        {
            if ((ddlCariHesaplar.SelectedValue == "0") // cariler seçiniz seçilirse
                || (ddlTemsilciler.SelectedValue == "0")) // satış temsilcileri seçiniz seçilirse
            {
                GetSiparislerBos();
                return;
            }

            if (ddlTemsilciler.SelectedValue == "1") // tümü
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    GetSiparisCount();
                    GetSiparisler(Baslangic, (int)Session["AktivitelerSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü
            {
                //short FiyatTipi = 0;

                //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                //{
                //    Musteriler mus = Musteriler.GetMusteriByID(Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue)));
                //    FiyatTipi = mus.tintUyeTipiID == 4 ? (short)7 : (short)25;
                //}
                //else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satıcı veya bayi yöneticisi
                //{
                //    FiyatTipi = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 ? (short)7 : (short)25;
                //}

                //GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), FiyatTipi);
                //GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), FiyatTipi, Baslangic, (int)Session["AktivitelerSayfaBasiGosterim"]);
            }
            else if (ddlCariHesaplarSubeler.SelectedValue == "TUM1" || !ddlCariHesaplarSubeler.Visible) // şubeler tümü
            {
                ListItemCollection lic = new ListItemCollection();
                CariHesaplarTP.GetSubelerByGMREF(lic, Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                short FiyatTipi = lic.Count > 2 ? (short)25 : (short)7;

                GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), FiyatTipi);
                GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), FiyatTipi, Baslangic, (int)Session["AktivitelerSayfaBasiGosterim"]);
            }
            else if (ddlCariHesaplarSubeler.Visible && ddlCariHesaplarSubeler.SelectedValue == "HIC0") // şubeler seçiniz seçilirse
            {
                ListItemCollection lic = new ListItemCollection();
                CariHesaplarTP.GetSubelerByGMREF(lic, Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                short FiyatTipi = lic.Count > 2 ? (short)25 : (short)7;

                GetSiparisCountBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), FiyatTipi);
                GetSiparislerBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), FiyatTipi, Baslangic, (int)Session["AktivitelerSayfaBasiGosterim"]);
            }
            else // şube
            {
                ListItemCollection lic = new ListItemCollection();
                CariHesaplarTP.GetSubelerByGMREF(lic, Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                short FiyatTipi = lic.Count > 2 ? (short)25 : (short)7;

                GetSiparisCountBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), FiyatTipi);
                GetSiparislerBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), FiyatTipi, Baslangic, (int)Session["AktivitelerSayfaBasiGosterim"]);
            }
        }

        private void GetSiparislerBos()
        {
            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();
            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
            lblSiparisYok.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTemsilciler.SelectedValue == "1")
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    ddlCariHesaplar.Items.Clear();
                    ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                    ddlCariHesaplarSubeler.Items.Clear();
                    ddlCariHesaplarSubeler.Visible = false;

                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["AktivitelerSayfaBasiGosterim"]);
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

            Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.AddYears(-1).Year.ToString());
            Calendar2.SelectedDate = DateTime.Now;

            GetSiparislerBos();

            lblSiparisYok.Visible = true;

            if (ddlTemsilciler.SelectedValue == "0")
                Session["AktiviteGetirilecekSMREF"] = null;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCariHesaplar.SelectedValue != "0" && ddlCariHesaplar.SelectedValue != "1")
            {
                ddlCariHesaplarSubeler.Visible = true;
                if (CariHesaplar.GetYTKKODBySMREF(CariHesaplar.GetSMREFByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)))) == "Z1")
                {
                    CariHesaplarTP.GetSubelerByGMREF(ddlCariHesaplarSubeler.Items,
                        Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                }
                else
                {
                    bool AnaSube = CariHesaplar.AnaSubeMi(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                    if (AnaSube)
                    {
                        CariHesaplar.GetSubeler(ddlCariHesaplarSubeler.Items,
                            Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    }
                    else
                    {
                        ddlCariHesaplarSubeler.Items.Clear();
                        ddlCariHesaplarSubeler.Items.Add(new ListItem("Hiçbir alt cari", "HIC0"));
                        ddlCariHesaplarSubeler.Items.Add(new ListItem("Tümü", "TUM1"));
                    }
                }
            }
            else
            {
                ddlCariHesaplarSubeler.Visible = false;
            }

            Getir(0);
        }

        protected void ddlCariHesaplarSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getir(0);
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["AktivitelerSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["AktivitelerSayfaBasiGosterim"] < baslangic)
                {
                    Getir(baslangic - (int)Session["AktivitelerSayfaBasiGosterim"]);
                    lblSiparisKacinci.Text = baslangic.ToString();
                }
                else
                {
                    Getir(0);
                    lblSiparisKacinci.Text = Session["AktivitelerSayfaBasiGosterim"].ToString();
                }
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) + (int)Session["AktivitelerSayfaBasiGosterim"];
            if (Convert.ToInt32(lblSiparisKacinci.Text) < Convert.ToInt32(lblSiparisSayisi.Text))
            {
                Getir(baslangic - (int)Session["AktivitelerSayfaBasiGosterim"]);

                if (baslangic > Convert.ToInt32(lblSiparisSayisi.Text))
                    lblSiparisKacinci.Text = lblSiparisSayisi.Text;
                else
                    lblSiparisKacinci.Text = baslangic.ToString();
            }
        }

        protected void ibIncele_Click(object sender, ImageClickEventArgs e)
        {
            int aktiviteid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("AktiviteID"))
                    {
                        aktiviteid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            GetSiparisFromDB(aktiviteid);

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
                    if (ctrl.ID.StartsWith("AktiviteID"))
                    {
                        Session["AktiviteID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                    else if (ctrl.ID.StartsWith("SMREF"))
                    {
                        Session["SMREFakt"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            if (Session["AktiviteID"] != null && Session["SMREFakt"] != null)
            {
                Aktiviteler aktivite = Aktiviteler.GetObject(Convert.ToInt32(Session["AktiviteID"]));

                bool yetkili = true;
                //for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
                //{
                //    if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == aktivite.sintFiyatTipiID)
                //    {
                //        yetkili = true;
                //        break;
                //    }
                //}

                if (yetkili)
                {
                    Session["AktiviteTipi"] = aktivite.intAktiviteTipiID; // sadece aktivite sayfasinda geciste kullanilacak
                    Session["FiyatTipi"] = aktivite.sintFiyatTipiID; // sadece aktivite sayfasinda geciste kullanilacak
                    Response.Redirect("aktivite.aspx", true);
                }
                else
                {
                    divFiyatTipiYetkisiYok.Visible = true;
                }
            }
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            int aktiviteid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("AktiviteID"))
                    {
                        aktiviteid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        Session["SilinecekAktiviteID"] = aktiviteid;
                        break;
                    }
                }
            }



            //// aktivitedeki fiyat tipine hala yetkili mi:
            //Aktiviteler aktivite = Aktiviteler.GetObject(aktiviteid);
            //bool yetkili = false;
            //for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            //{
            //    if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == aktivite.sintFiyatTipiID)
            //    {
            //        yetkili = true;
            //        break;
            //    }
            //}
            //if (!yetkili)
            //{
            //    divFiyatTipiYetkisiYok.Visible = true;
            //    return;
            //}



            divSiparisSil.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisSil, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisSilEvet_Click(object sender, EventArgs e)
        {
            Aktiviteler.DoDeleteWithAktivitelerDetays((int)Session["SilinecekAktiviteID"]);
            Session["SilinecekAktiviteID"] = null;
            divSiparisSil.Visible = false;
            Getir(0);
        }

        protected void lbSiparisSilHayir_Click(object sender, EventArgs e)
        {
            Session["SilinecekAktiviteID"] = null;
            divSiparisSil.Visible = false;
        }

        protected void ibOnayla_Click(object sender, ImageClickEventArgs e)
        {
            int aktiviteid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("AktiviteID"))
                    {
                        aktiviteid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        Session["OnaylanacakAktiviteID"] = aktiviteid;
                        break;
                    }
                }
            }



            Aktiviteler aktivite = Aktiviteler.GetObject(aktiviteid);

            if (aktivite.blAktarilmis)
            {
                divSiparisAktarilmisHata.Visible = true;
                return;
            }



            //// aktivitedeki fiyat tipine hala yetkili mi:
            //bool yetkili = false;
            //for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            //{
            //    if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == aktivite.sintFiyatTipiID)
            //    {
            //        yetkili = true;
            //        break;
            //    }
            //}
            //if (!yetkili)
            //{
            //    Session["OnaylanacakAktiviteID"] = null;
            //    divFiyatTipiYetkisiYok.Visible = true;
            //    string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            //    ScriptManager.RegisterStartupScript(divFiyatTipiYetkisiYok, typeof(string), "scriptSayfayukaricikar", alert, false);
            //    return;
            //}



            DataTable dtDetaylar = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dtDetaylar, aktivite.pkID);
            if (dtDetaylar.Rows.Count == 0)
            {
                divToplamTutarSifir.Visible = true;
                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divToplamTutarSifir, typeof(string), "scriptSayfayukaricikar", alert, false);
                return;
            }



            //for (int i = 0; i < dtDetaylar.Rows.Count; i++)
            //{
            //    decimal yenifiyat = Urunler.GetProductPrice(Convert.ToInt32(dtDetaylar.Rows[i]["intUrunID"]), aktivite.sintFiyatTipiID);
            //    AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(Convert.ToInt64(dtDetaylar.Rows[i]["pkID"]));
            //    aktlerdet.mnDusulmusBirimFiyatKDVli = yenifiyat;
            //    aktlerdet.DoUpdate();
            //}

            //aktivite.DoUpdate();



            divSevkYerleri.Visible = true;

            //GetSiparisFromDB(aktivite.pkID);
            //lblSiparisDetaylari.Visible = false;
            //lblSiparisSonDurum.Visible = true;
            //lbOnaylamayaDevam.Visible = true;


            //GetSevkYerleri(siparis.SMREF);

            string alert2 = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSevkYerleri, typeof(string), "scriptSayfayukaricikar", alert2, false);
        }

        protected void lbOnaylaBitir_Click(object sender, EventArgs e)
        {
            SiparisOnayla((int)Session["OnaylanacakAktiviteID"]);

            divAktiviteKaydedildi.Visible = true;
            //Aktiviteler aktivite = Aktiviteler.GetObject((int)Session["OnaylanacakAktiviteID"]);
            //Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", new string[] { "hgunbay@sultanlar.com.tr" },
            //    "Sultanlar Pazarlama A.Ş.",
            //    "Aktivite onay talebi: " + Session["OnaylanacakAktiviteID"].ToString(),
            //    Session["OnaylanacakAktiviteID"].ToString() + " nolu aktivite için onay talebi yapılmıştır. Talebi yapan web üyesi: " +
            //    Musteriler.GetMusteriByID(aktivite.intMusteriID).strAd + " " + Musteriler.GetMusteriByID(aktivite.intMusteriID).strSoyad);

            Session["OnaylanacakAktiviteID"] = null;
            divSevkYerleri.Visible = false;
            Getir(0);
        }

        protected void lbOnaylaKapat_Click(object sender, EventArgs e)
        {
            Session["AktiviteTamamlaOnaylaBasildi"] = null;
            Session["OnaylanacakAktiviteID"] = null;
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
                    if (ctrl.ID.StartsWith("AktiviteID"))
                        Session["KopyalanacakAktiviteID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;

            //// aktivitedeki fiyat tipine hala yetkili mi:
            //Aktiviteler aktivite = Aktiviteler.GetObject(Convert.ToInt32(Session["KopyalanacakAktiviteID"]));
            //bool yetkili = false;
            //for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
            //{
            //    if (Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]) == aktivite.sintFiyatTipiID)
            //    {
            //        yetkili = true;
            //        break;
            //    }
            //}
            //if (!yetkili)
            //{
            //    divFiyatTipiYetkisiYok.Visible = true;
            //    return;
            //}

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)     // bayi yöneticisi
            {
                ArrayList gmrefs = new ArrayList();
                CariHesaplar.GetGMREFsBySLSREF(gmrefs, ((Musteriler)Session["Musteri"]).intSLSREF, true);

                CariHesaplarTP.GetSubelerByGMREFs(cblSiparisKopyalaSubeler.Items, gmrefs, false);
                cblSiparisKopyalaSubeler.Items.RemoveAt(0); // seçinizi kaldırmak için
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)
            {
                ArrayList altlar = new ArrayList();
                altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);

                if (altlar.Count == 0) // şef değil ise
                {
                    CariHesaplar.GetTekCarilerBySLSREF(cblSiparisKopyalaSubeler.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, false);
                    cblSiparisKopyalaSubeler.Items.RemoveAt(0); // seçinizi kaldırmak için

                    ArrayList anacarigmrefler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                    for (int i = 0; i < anacarigmrefler.Count; i++)
                    {
                        DataTable dt = new DataTable();
                        CariHesaplar cari = CariHesaplar.GetObject(Convert.ToInt32(anacarigmrefler[i]), true);

                        ListItem lst = new ListItem();
                        lst.Text = cari.MUSTERI;
                        lst.Value = cari.MUSTERI.ToString().Substring(0, 3) + cari.SMREF.ToString();
                        cblSiparisKopyalaSubeler.Items.Add(lst);
                    }

                    string sattem = SatisTemsilcileri.GetObjectBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF.ToString());
                    for (int i = 0; i < cblSiparisKopyalaSubeler.Items.Count; i++)
                        cblSiparisKopyalaSubeler.Items[i].Text = sattem + " - " + cblSiparisKopyalaSubeler.Items[i].Text;
                }
                else // şef ise
                {
                    CariHesaplar.GetSMREFandSATTEMMUSTERISUBEByGMREFsSLSREFs(cblSiparisKopyalaSubeler.Items, ddlCariHesaplar.Items, altlar);
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                if (Musteriler.GetMusteriByID(Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue))).tintUyeTipiID == 6)
                {

                }
                else
                {
                    CariHesaplar.GetTekCarilerBySLSREF(cblSiparisKopyalaSubeler.Items, Convert.ToInt32(ddlTemsilciler.SelectedValue), true, false);
                    cblSiparisKopyalaSubeler.Items.RemoveAt(0); // seçinizi kaldırmak için

                    ArrayList anacarigmrefler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    for (int i = 0; i < anacarigmrefler.Count; i++)
                    {
                        DataTable dt = new DataTable();
                        CariHesaplar cari = CariHesaplar.GetObject(Convert.ToInt32(anacarigmrefler[i]), true);

                        ListItem lst = new ListItem();
                        lst.Text = cari.MUSTERI;
                        lst.Value = cari.MUSTERI.ToString().Substring(0, 3) + cari.SMREF.ToString();
                        cblSiparisKopyalaSubeler.Items.Add(lst);
                    }

                    string sattem = SatisTemsilcileri.GetObjectBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue).ToString());
                    for (int i = 0; i < cblSiparisKopyalaSubeler.Items.Count; i++)
                        cblSiparisKopyalaSubeler.Items[i].Text = sattem + " - " + cblSiparisKopyalaSubeler.Items[i].Text;
                }

                //CariHesaplar.GetSMREFandSATTEMMUSTERISUBE(cblSiparisKopyalaSubeler.Items);
                //CariHesaplarTP.GetSMREFandMUSTERISUBE(cblSiparisKopyalaSubeler.Items);
            }

            divSiparisKopyala.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisKopyala, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisKopyalaTamamla_Click(object sender, EventArgs e)
        {
            int aktiviteid = Convert.ToInt32(Session["KopyalanacakAktiviteID"]);
            Session["KopyalanacakAktiviteID"] = null;

            Aktiviteler Oncekiaktivite = Aktiviteler.GetObject(aktiviteid);

            for (int i = 0; i < cblSiparisKopyalaSubeler.Items.Count; i++)
            {
                if (cblSiparisKopyalaSubeler.Items[i].Selected)
                {
                    int SMREF = 0;
                    if (cblSiparisKopyalaSubeler.Items[i].Value.ToCharArray().Length == 7) // ilk 3 hanede müşteri isminin ilk 3 hanesi varsa
                        SMREF = Convert.ToInt32(cblSiparisKopyalaSubeler.Items[i].Value);
                    else
                        SMREF = Convert.ToInt32(cblSiparisKopyalaSubeler.Items[i].Value.Substring(3));

                    short FiyatTipi = Oncekiaktivite.sintFiyatTipiID != 25 && FiyatTipleri.GetFiyatTipByGMREF(CariHesaplar.GetGMREFBySMREF(SMREF)) != 0 ? FiyatTipleri.GetFiyatTipByGMREF(CariHesaplar.GetGMREFBySMREF(SMREF)) : Oncekiaktivite.sintFiyatTipiID; // kopyalanacak müşterinin fiyat tipi varsa 5.. ise. önceki aktivite 25 ise demekki bayi alt müşteri aktivitesidir önceki aktivite, bu kontrolu koymamın sebebi aynı smref li bayi alt müşterisi sultanlar müşterisi olan 5.. lü fiyat çıkabiliyor

                    int AnlasmaID = FiyatTipi == 25 ?
                        Anlasmalar.GetSonAnlasmaID(SMREF, Convert.ToDateTime("01." + ddlDonemAy.SelectedValue + "." + ddlDonemYil.SelectedValue), "1")
                        : Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(SMREF), Convert.ToDateTime("01." + ddlDonemAy.SelectedValue + "." + ddlDonemYil.SelectedValue), "2");
                    Anlasmalar anlasma = null;
                    if (AnlasmaID != 0) anlasma = Anlasmalar.GetObject(AnlasmaID);
                    decimal TahSabitBedel = AnlasmaID != 0 ? anlasma.TAHTumBedellerToplami : 0;
                    decimal YegSabitBedel = AnlasmaID != 0 ? anlasma.YEGTumBedellerToplami : 0;
                    decimal TahHedefCiro = AnlasmaID != 0 ? anlasma.mnTAHToplamCiro : 0;
                    decimal YegHedefCiro = AnlasmaID != 0 ? anlasma.mnYEGToplamCiro : 0;

                    Aktiviteler Aktivite = new Aktiviteler(((Musteriler)Session["Musteri"]).pkMusteriID,
                        SMREF, FiyatTipi, AnlasmaID, Oncekiaktivite.intAktiviteTipiID, DateTime.Now, 
                        DateTime.Now, false, Oncekiaktivite.dtAktiviteBaslangic, Oncekiaktivite.dtAktiviteBitis, Oncekiaktivite.strAciklama1,
                        Oncekiaktivite.strAciklama2, Oncekiaktivite.strAciklama3, ddlDonemYil.SelectedValue + "/" + ddlDonemAy.SelectedValue, TahSabitBedel,
                        YegSabitBedel, TahHedefCiro, YegHedefCiro, 
                        0, 0);
                    Aktivite.DoInsert();

                    DataTable dt = new DataTable();
                    AktivitelerDetay.GetObjectsByAktiviteID(dt, aktiviteid);

                    decimal AktiviteKarZarar = 0; //???????????
                    double AktiviteKarZararYuzde = (FiyatTipi == 25 && CariHesaplarTP.GetBAYIKODByGMREF(SMREF) != "") ? 1 : 0; // genel anlaşmasız ise 1
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        AktivitelerDetay aktlerdet = new AktivitelerDetay(Aktivite.pkID, Convert.ToInt32(dt.Rows[j]["intUrunID"]),
                            dt.Rows[j]["strUrunAdi"].ToString(),
                            Convert.ToInt32(dt.Rows[j]["intKoliAdet"]), Convert.ToDecimal(dt.Rows[j]["mnBirimFiyatKDVli"]),
                            Convert.ToDecimal(dt.Rows[j]["mnBirimFiyatKDVli"]), Convert.ToDouble(dt.Rows[j]["flMusteriKarYuzde"]),
                            dt.Rows[j]["strSatisHedefi"].ToString(), Convert.ToDecimal(dt.Rows[j]["mnTutar"]),
                            Convert.ToDouble(dt.Rows[j]["flEkIsk"]), Convert.ToDouble(dt.Rows[j]["flCiroPrimDonusYuzde"]),
                            Convert.ToDecimal(dt.Rows[j]["mnBayiMaliyet"]), Convert.ToDecimal(dt.Rows[j]["mnDusulmusBirimFiyatKDVli"]),
                            Convert.ToDouble(dt.Rows[j]["flKarZararYuzde"]), Convert.ToDecimal(dt.Rows[j]["mnToplam"]),
                            dt.Rows[j]["strAciklama1"].ToString(), dt.Rows[j]["strAciklama2"].ToString(), dt.Rows[j]["strAciklama3"].ToString(),
                            "0", "");
                        aktlerdet.DoInsert();

                        int GMREF = CariHesaplarTP.GetObject(SMREF, false).GMREF;

                        double birimfiyat = Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, Aktivite.sintFiyatTipiID, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[4]; // bayi öztrakya veya meltem ise f7 liste fiyatı alınmalı ::: (GMREF == 1005405 || GMREF == 1000951 ? 7 : Aktivite.sintFiyatTipiID)

                        aktlerdet.mnBirimFiyatKDVli = Convert.ToDecimal(birimfiyat * ((Urunler.GetProductKDV(aktlerdet.intUrunID) + 100) / 100));
                        aktlerdet.mnAksiyonFiyati = aktlerdet.mnBirimFiyatKDVli;

                        if (FiyatTipleri.GetFiyatTipByGMREF(CariHesaplar.GetGMREFBySMREF(SMREF)) > 500) // kopyalanacak müşteri 500 lü ise
                        {
                            double isk1 = anlasma == null ? 0 : (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHIsk : anlasma.flYEGIsk); //Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, Aktivite.sintFiyatTipiID, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[0];
                            double isk2 = 0; // Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, Aktivite.sintFiyatTipiID, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[1];
                            double birincidusulmus = 100 - isk1;
                            double ikincidusulmus = birincidusulmus - ((birincidusulmus / 100) * isk2);
                            aktlerdet.strAciklama1 = (100 - ikincidusulmus).ToString("N1");

                            aktlerdet.strAciklama2 = anlasma == null ? "0" : ((Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHCiroIsk : anlasma.flYEGCiroIsk).ToString("N1")); //Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, Aktivite.sintFiyatTipiID, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[2].ToString("N1");
                            aktlerdet.strAciklama3 = Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, Aktivite.sintFiyatTipiID, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[5].ToString("N1");
                        }
                        else if (FiyatTipi == 25) // alt cari veya genel aktivite (öztrakya ve meltem de dahil) ::: GMREF == 1005405 || GMREF == 1000951 ? Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, 7, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[2].ToString("N1") : 
                        {
                            aktlerdet.strAciklama1 = AnlasmaID == 0 ? (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? CariHesaplarTPEk2.GetObject(GMREF, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue)).TAH_ISK.ToString("N1") : CariHesaplarTPEk2.GetObject(GMREF, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue)).YEG_ISK.ToString("N1")) : (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHIsk.ToString("N1") : anlasma.flYEGIsk.ToString("N1"));
                            aktlerdet.strAciklama2 = AnlasmaID == 0 ? "0" : (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHCiroIsk.ToString("N1") : anlasma.flYEGCiroIsk.ToString("N1")); // fiyat değişiminde iskonto değişirse değişmesi lazım
                            aktlerdet.strAciklama3 = Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, 25, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[2].ToString("N1");
                        }
                        else // sultanlar müşterileri
                        {
                            aktlerdet.strAciklama1 = AnlasmaID == 0 ? (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? "5" : "5") : (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHIsk.ToString("N1") : anlasma.flYEGIsk.ToString("N1")); // fiyat değişiminde iskonto değişirse değişmesi lazım
                            aktlerdet.strAciklama2 = AnlasmaID == 0 ? (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? "0" : "0") : (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHCiroIsk.ToString("N1") : anlasma.flYEGCiroIsk.ToString("N1")); // fiyat değişiminde iskonto değişirse değişmesi lazım
                            aktlerdet.strAciklama3 = Urunler.GetProductDiscountsAndPrice(aktlerdet.intUrunID, 7, Convert.ToInt32(ddlDonemYil.SelectedValue), Convert.ToInt32(ddlDonemAy.SelectedValue))[2].ToString("N1");
                        }

                        aktlerdet.flCiroPrimDonusYuzde = AnlasmaID == 0 ? 0 : (Urunler.GetProductGRPKOD(aktlerdet.intUrunID) == "STG-1" ? anlasma.flTAHCiro + anlasma.flTAHCiro3 + anlasma.flTAHCiro6 + anlasma.flTAHCiro12 : anlasma.flYEGCiro + anlasma.flYEGCiro3 + anlasma.flYEGCiro6 + anlasma.flYEGCiro12);

                        double para1 = Convert.ToDouble(aktlerdet.mnBirimFiyatKDVli) - ((Convert.ToDouble(aktlerdet.mnBirimFiyatKDVli) / 100) * Convert.ToDouble(aktlerdet.strAciklama1));
                        double para2 = Convert.ToDouble(para1) - ((Convert.ToDouble(para1) / 100) * Convert.ToDouble(aktlerdet.strAciklama2));
                        double para3 = Convert.ToDouble(para2) - ((Convert.ToDouble(para2) / 100) * Convert.ToDouble(aktlerdet.strAciklama3));
                        double para4 = Convert.ToDouble(para3) - ((Convert.ToDouble(para3) / 100) * aktlerdet.flEkIsk);
                        aktlerdet.mnDusulmusBirimFiyatKDVli = Convert.ToDecimal(para4);

                        aktlerdet.mnTutar = Convert.ToDecimal(Convert.ToDouble(aktlerdet.mnDusulmusBirimFiyatKDVli) - ((Convert.ToDouble(aktlerdet.mnDusulmusBirimFiyatKDVli) / 100) * aktlerdet.flCiroPrimDonusYuzde));

                        aktlerdet.DoUpdate();
                    }

                    Aktivite.mnAktiviteKarZarar = AktiviteKarZarar;
                    Aktivite.flAktiviteKarZararYuzde = AktiviteKarZararYuzde;
                    Aktivite.DoUpdate();
                }
            }

            divSiparisKopyala.Visible = false;
            Response.Redirect("aktiviteler.aspx", true);
        }

        protected void lbSiparisKopyalaKapat_Click(object sender, EventArgs e)
        {
            divSiparisKopyala.Visible = false;
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            int aktiviteid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("AktiviteID"))
                    {
                        aktiviteid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (aktiviteid != 0)
            {
                Session["downloadaktiviteid"] = aktiviteid;
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
            int aktiviteid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("AktiviteID"))
                    {
                        aktiviteid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (aktiviteid != 0)
            {
                Session["oncekiyazdiraktiviteid"] = Session["yazdiraktiviteid"];
                Session["yazdiraktiviteid"] = aktiviteid;
            }
        }

        protected void ibEposta_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void lbSiparisEpostaKapat_Click(object sender, EventArgs e)
        {
            divSiparisEposta.Visible = false;
        }

        protected void lbFiyatTipiYetkisiYokKapat_Click(object sender, EventArgs e)
        {
            divFiyatTipiYetkisiYok.Visible = false;
        }

        protected void lbTarihKapat_Click(object sender, EventArgs e)
        {
            divTarih.Visible = false;
            Getir(0);
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
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.AddYears(-1).Year.ToString());
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
            }
        }

        protected void rbSiparislerHepsi_Checked(object sender, EventArgs e)
        {
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
                btnTumunuOnayla.Enabled = true;
                btnTumunuSil.Enabled = true;
            }
            else if (rbSiparislerRedler.Checked)
            {
                btnTumunuOnayla.Enabled = false;
                btnTumunuSil.Enabled = false;
            }

            Getir(0);
        }

        protected void ibDurum_Click(object sender, ImageClickEventArgs e)
        {

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
                return;

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;

            GetSiparislerBos();

            if (rbCariHesapAraMusteri.Checked)
            {
                ddlTemsilciler.Items.Clear();
                CariHesaplarTP.GetGMREFSATTEMMUSTERIByMusteri(ddlCariHesaplar.Items, txtCariHesapAra.Text.Trim(), false);
            }
            else if (rbCariHesapAraSattem.Checked)
            {
                ddlCariHesaplar.Items.Clear();
                SatisTemsilcileri.GetObjectsBySatisTemsilcisi(ddlTemsilciler.Items, txtCariHesapAra.Text.Trim(), false);
            }
        }

        protected void dlSiparisler_DataBound(object sender, EventArgs e)
        {
            lblSiparisYok.Visible = dlSiparisler.Items.Count == 0;
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
                            int aktid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);
                            SiparisOnayla(aktid);
                        }
                    }
                }
            }

            Getir(0);
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
                            int aktiviteid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);
                            Aktiviteler.DoDeleteWithAktivitelerDetays(aktiviteid);
                        }
                    }
                }
            }

            Getir(0);
            cbSiparislerSecimTumu.Checked = false;
        }

        protected void lbAktiviteKaydedildiKapat_Click(object sender, EventArgs e)
        {
            divAktiviteKaydedildi.Visible = false;
        }
    }

    public class AktiviteListe1 : System.Collections.CollectionBase
    {
        // Alanlar
        public int _AktiviteID;
        public int _MusteriID;
        public int _SMREF;
        public short _FiyatTipi;
        public int _AnlasmaID;
        public int _AktiviteTipiID;
        public DateTime _AktiviteBaslangic;
        public DateTime _AktiviteBitis;
        public string _Aciklama1;
        public string _Aciklama2;
        public string _Aciklama3;
        public string _Aciklama4;
        public decimal _TahSabitBedel;
        public decimal _YegSabitBedel;
        public decimal _TahHedefCiro;
        public decimal _YegHedefCiro;
        public decimal _AktiviteKarZarar;
        public double _AktiviteKarZararYuzde;

        // Constracter
        public AktiviteListe1(int MusteriID, int SMREF, short FiyatTipi, int AktiviteTipi, bool veritabaninayaz)
        {
            this._MusteriID = MusteriID;
            this._SMREF = SMREF;
            this._FiyatTipi = FiyatTipi;
            this._AktiviteTipiID = AktiviteTipi;

            int sonanlasmaid = FiyatTipi == 25 ? Anlasmalar.GetSonAnlasmaID(SMREF, DateTime.Now, "1") : Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(SMREF), DateTime.Now, "2");
            if (sonanlasmaid != 0)
            {
                Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                this._AnlasmaID = anlasma.pkID;
                this._TahSabitBedel = anlasma.TAHTumBedellerToplami + anlasma.mnTAHAnlasmaDisiBedeller;
                this._YegSabitBedel = anlasma.YEGTumBedellerToplami + anlasma.mnYEGAnlasmaDisiBedeller;
                this._TahHedefCiro = anlasma.mnTAHToplamCiro;
                this._YegHedefCiro = anlasma.mnYEGToplamCiro;
            }
        }

        // Özellikler
        public int AktiviteID { get { return this._AktiviteID; } set { value = this._AktiviteID; } }
        public int MusteriID { get { return this._MusteriID; } set { value = this._MusteriID; } }
        public int SMREF { get { return this._SMREF; } set { value = this._SMREF; } }
        public short FiyatTipi { get { return this._FiyatTipi; } set { value = this._FiyatTipi; } }
        public int AnlasmaID { get { return this._AnlasmaID; } set { value = this._AnlasmaID; } }
        public int AktiviteTipiID { get { return this._AktiviteTipiID; } set { value = this._AktiviteTipiID; } }
        public DateTime AktiviteBaslangic { get { return this._AktiviteBaslangic; } set { value = this._AktiviteBaslangic; } }
        public DateTime AktiviteBitis { get { return this._AktiviteBitis; } set { value = this._AktiviteBitis; } }
        public string Aciklama1 { get { return this._Aciklama1; } set { value = this._Aciklama1; } }
        public string Aciklama2 { get { return this._Aciklama2; } set { value = this._Aciklama2; } }
        public string Aciklama3 { get { return this._Aciklama3; } set { value = this._Aciklama3; } }
        public string Aciklama4 { get { return this._Aciklama4; } set { value = this._Aciklama4; } }
        public decimal TahSabitBedel { get { return this._TahSabitBedel; } set { value = this._TahSabitBedel; } }
        public decimal YegSabitBedel { get { return this._YegSabitBedel; } set { value = this._YegSabitBedel; } }
        public decimal TahHedefCiro { get { return this._TahHedefCiro; } set { value = this._TahHedefCiro; } }
        public decimal YegHedefCiro { get { return this._YegHedefCiro; } set { value = this._YegHedefCiro; } }
        public double AktiviteKarZararYuzde { get { return this._AktiviteKarZararYuzde; } set { value = this._AktiviteKarZararYuzde; } }
        public AktiviteDetayi1 this[int index]
        {
            get { return (AktiviteDetayi1)this.List[index]; }
            set { this.List[index] = value; }
        }
        public System.Collections.IList Items
        {
            get { return this.List; }
        }
        public decimal ToplamTutar
        {
            get
            {
                decimal Toplam = 0;

                foreach (AktiviteDetayi1 aktdet in this.List)
                {
                    Toplam += aktdet._SatisHedefi * Convert.ToDecimal(Urunler.GetKoliAdedi(aktdet._UrunID)) * aktdet.DusulmusBirimFiyatKDVli;
                }

                return Toplam;
            }
        }
        /// <summary>
        /// Veritabanından gelen listeye detay satır eklemek için
        /// </summary>
        public void Add(long AktiviteDetayID)
        {
            AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(AktiviteDetayID);
            AktiviteDetayi1 aktdet = new AktiviteDetayi1(aktlerdet.intUrunID, aktlerdet.strUrunAdi, aktlerdet.intKoliAdet, aktlerdet.mnBirimFiyatKDVli,
                aktlerdet.mnAksiyonFiyati, aktlerdet.flMusteriKarYuzde, Convert.ToInt32(aktlerdet.strSatisHedefi), aktlerdet.mnTutar,
                aktlerdet.flEkIsk, aktlerdet.flCiroPrimDonusYuzde, aktlerdet.mnBayiMaliyet, aktlerdet.mnDusulmusBirimFiyatKDVli,
                aktlerdet.flKarZararYuzde, aktlerdet.mnToplam, aktlerdet.strAciklama1, aktlerdet.strAciklama2, aktlerdet.strAciklama3,
                aktlerdet.strAciklama4);
            aktdet._AktiviteDetayID = aktlerdet.pkID;
            this.List.Add(aktdet);
        }
    }

    public class AktiviteDetayi1 : IDisposable
    {
        // Alanlar
        public long _AktiviteDetayID;
        public int _UrunID;
        public string _UrunAdi;
        public int _KoliAdet;
        public decimal _BirimFiyatKDVli;
        public decimal _AksiyonFiyati;
        public double _MusteriKarYuzde;
        public int _SatisHedefi;
        public decimal _Tutar;
        public double _EkIsk;
        public double _CiroPrimDonusYuzde;
        public decimal _BayiMaliyet;
        public decimal _DusulmusBirimFiyatKDVli;
        public double _KarZararYuzde;
        public decimal _Toplam;
        public string _Aciklama1;
        public string _Aciklama2;
        public string _Aciklama3;
        public string _Aciklama4;

        // Constracter lar
        public AktiviteDetayi1(int UrunID, string UrunAdi, int KoliAdet, decimal BirimFiyatKDVli, decimal AksiyonFiyati, double MusteriKarYuzde,
            int SatisHedefi, decimal Tutar, double EkIsk, double CiroPrimDonusYuzde, decimal BayiMaliyet, decimal DusulmusBirimFiyatKDVli,
            double KarZararYuzde, decimal Toplam, string Aciklama1, string Aciklama2, string Aciklama3, string Aciklama4)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._KoliAdet = KoliAdet;
            this._BirimFiyatKDVli = BirimFiyatKDVli;
            this._AksiyonFiyati = AksiyonFiyati;
            this._MusteriKarYuzde = MusteriKarYuzde;
            this._SatisHedefi = SatisHedefi;
            this._Tutar = Tutar;
            this._EkIsk = EkIsk;
            this._CiroPrimDonusYuzde = CiroPrimDonusYuzde;
            this._BayiMaliyet = BayiMaliyet;
            this._DusulmusBirimFiyatKDVli = DusulmusBirimFiyatKDVli;
            this._KarZararYuzde = KarZararYuzde;
            this._Toplam = Toplam;
            this._Aciklama1 = Aciklama1;
            this._Aciklama2 = Aciklama2;
            this._Aciklama3 = Aciklama3;
            this._Aciklama4 = Aciklama4;
        }
        public AktiviteDetayi1(int UrunID, string UrunAdi, int SatisHedefi, decimal AksiyonFiyati, decimal BirimFiyatKDVli)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._SatisHedefi = SatisHedefi;
            this._AksiyonFiyati = AksiyonFiyati;
            this._BirimFiyatKDVli = BirimFiyatKDVli;
        }

        // Özellikler
        public long AktiviteDetayID { get { return this._AktiviteDetayID; } set { value = this._AktiviteDetayID; } }
        public int UrunID { get { return this._UrunID; } set { value = this._UrunID; } }
        public string UrtKod { get { return Urunler.GetProductUrtKod(this._UrunID); } }
        public string UrunAdi { get { return this._UrunAdi; } set { value = this._UrunAdi; } }
        public int KoliAdet { get { return this._KoliAdet; } set { value = this._KoliAdet; } }
        public decimal BirimFiyatKDVli { get { return this._BirimFiyatKDVli; } set { value = this._BirimFiyatKDVli; } }
        public decimal AksiyonFiyati { get { return this._AksiyonFiyati; } set { value = this._AksiyonFiyati; } }
        public double MusteriKarYuzde { get { return this._MusteriKarYuzde; } set { value = this._MusteriKarYuzde; } }
        public int SatisHedefi { get { return this._SatisHedefi; } set { value = this._SatisHedefi; } }
        public decimal Tutar { get { return this._Tutar; } set { value = this._Tutar; } }
        public double FatAltIsk { get { return Convert.ToDouble(this._Aciklama1); } }
        public double FatAltCiro { get { return Convert.ToDouble(this._Aciklama2); } }
        public double PazIsk { get { return Convert.ToDouble(this._Aciklama3); } }
        public double EkIsk { get { return this._EkIsk; } set { value = this._EkIsk; } }
        public double CiroPrimDonusYuzde { get { return this._CiroPrimDonusYuzde; } }
        public decimal BayiMaliyet { get { return this._BayiMaliyet; } set { value = this._BayiMaliyet; } }
        public decimal DusulmusBirimFiyatKDVli { get { return this._DusulmusBirimFiyatKDVli; } }
        public decimal CiroPrimiDusulmusKDVDahil { get { return this._Tutar; } }
        public double KarZararYuzde { get { return this._KarZararYuzde; } set { value = this._KarZararYuzde; } }
        public decimal Toplam { get { return this._Toplam; } set { value = this._Toplam; } }
        public string Aciklama1 { get { return this._Aciklama1; } }
        public string Aciklama2 { get { return this._Aciklama2; } }
        public string Aciklama3 { get { return this._Aciklama3; } }
        public string Aciklama4 { get { return this._Aciklama4; } }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}