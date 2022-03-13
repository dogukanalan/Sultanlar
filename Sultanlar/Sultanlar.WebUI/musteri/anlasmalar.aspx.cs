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
    public partial class anlasmalar : System.Web.UI.Page
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
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + (DateTime.Now.Year - 1).ToString());
                Calendar2.SelectedDate = Convert.ToDateTime("31.12." + (DateTime.Now.Year + 1).ToString());
                lblTarihSecim1.Text = Convert.ToDateTime("01.01." + (DateTime.Now.Year - 1).ToString()).ToShortDateString();
                lblTarihSecim2.Text = Convert.ToDateTime("31.12." + (DateTime.Now.Year + 1).ToString()).ToShortDateString();

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

                Session["AnlasmalarSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intSiparisSatirSayisi;

                GetCariHesaplar();
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

                CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, true);

                ddlCariHesaplarSubeler.Visible = false;
                ddlCariHesaplar.SelectedIndex = 1;
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

                GetAnlasmalarCount();
                GetAnlasmalar(0, (int)Session["AnlasmalarSayfaBasiGosterim"]);
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
                GetAnlasmalarCountBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                GetAnlasmalarBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["AnlasmalarSayfaBasiGosterim"]);
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

        private string BayiSul()
        {
            string donendeger = string.Empty;
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satıcı veya bayi yöneticisi ise
            {
                return ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 ? "2" : "1";
            }
            return Musteriler.GetMusteriByID(Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue))).tintUyeTipiID == 4 ? "2" : "1";
        }

        #region BySMREF
        private int GetAnlasmalarCountBySMREF(int SMREF)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            string bayisul = BayiSul();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && SatisTemsilcileriSefler.GetAltlar(((Musteriler)Session["Musteri"]).intSLSREF).Count > 1)
            //    bayisul = "2";

            int donendeger = Anlasmalar.GetObjectCount(bayisul, SMREF, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblAnlasmaKacinci.Text = Session["AnlasmalarSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AnlasmalarSayfaBasiGosterim"])
                lblAnlasmaKacinci.Text = donendeger.ToString();

            lblAnlasmaSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetAnlasmalarBySMREF(int SMREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            string bayisul = BayiSul();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && SatisTemsilcileriSefler.GetAltlar(((Musteriler)Session["Musteri"]).intSLSREF).Count > 1)
            //    bayisul = "2";

            DataTable dt = new DataTable();
            Anlasmalar.GetObjects(bayisul, dt, SMREF, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        #region ByGMREF
        // parametre ile gelen GMREF fuzuli çünkü smref leri ddlcarihesapsubeler den alıyoruz
        private int GetAnlasmalarCountByGMREF(int GMREF)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            string bayisul = BayiSul();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && SatisTemsilcileriSefler.GetAltlar(((Musteriler)Session["Musteri"]).intSLSREF).Count > 1)
            //    bayisul = "2";

            int donendeger = Anlasmalar.GetObjectCount(bayisul, SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblAnlasmaKacinci.Text = Session["AnlasmalarSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AnlasmalarSayfaBasiGosterim"])
                lblAnlasmaKacinci.Text = donendeger.ToString();

            lblAnlasmaSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetAnlasmalarByGMREF(int GMREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            string bayisul = BayiSul();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && SatisTemsilcileriSefler.GetAltlar(((Musteriler)Session["Musteri"]).intSLSREF).Count > 1)
            //    bayisul = "2";

            DataTable dt = new DataTable();
            Anlasmalar.GetObjects(bayisul, dt, SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        #region BySLSREF
        private int GetAnlasmalarCountBySLSREF(int SLSREF)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            int uyeid = (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) ? ((Musteriler)Session["Musteri"]).pkMusteriID : Musteriler.GetMusteriIDbySLSREF(SLSREF); // eğer satıcı veya bayi yöneticisi ise kendi uyeid'si gelsin
            byte uyetipi = Musteriler.GetMusteriByID(uyeid).tintUyeTipiID;
            if (uyetipi == 6)
                CariHesaplarTP.GetSMREFsBySLSREFcarihesaplardaneslesmeli(SMREFs, SLSREF);
            else if (uyetipi == 4)
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);

            string bayisul = BayiSul();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF).Count > 1) // şef ise
            //    bayisul = "2";

            int donendeger = Anlasmalar.GetObjectCount(bayisul, SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblAnlasmaKacinci.Text = Session["AnlasmalarSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AnlasmalarSayfaBasiGosterim"])
                lblAnlasmaKacinci.Text = donendeger.ToString();

            lblAnlasmaSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetAnlasmalarBySLSREF(int SLSREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList GMREFs = new ArrayList();
            int uyeid = (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) ? ((Musteriler)Session["Musteri"]).pkMusteriID : Musteriler.GetMusteriIDbySLSREF(SLSREF); // eğer satıcı veya bayi yöneticisi ise kendi uyeid'si gelsin
            byte uyetipi = Musteriler.GetMusteriByID(uyeid).tintUyeTipiID;
            if (uyetipi == 6)
                CariHesaplarTP.GetSMREFsBySLSREFcarihesaplardaneslesmeli(GMREFs, SLSREF);
            else if (uyetipi == 4)
                CariHesaplar.GetGMREFsBySLSREF(GMREFs, SLSREF, true);

            string bayisul = BayiSul();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF).Count > 1) // şef ise
            //    bayisul = "2";

            DataTable dt = new DataTable();
            Anlasmalar.GetObjects(bayisul, dt, GMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        #region All
        private int GetAnlasmalarCount()
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            int donendeger = Anlasmalar.GetObjectCount(Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblAnlasmaKacinci.Text = Session["AnlasmalarSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["AnlasmalarSayfaBasiGosterim"])
                lblAnlasmaKacinci.Text = donendeger.ToString();

            lblAnlasmaSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetAnlasmalar(int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            Anlasmalar.GetObjects(dt, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        private void Getir(int Baslangic)
        {
            if ((ddlCariHesaplarSubeler.Visible && ddlCariHesaplarSubeler.SelectedValue == "0") // şubeler seçiniz seçilirse
                || (ddlCariHesaplar.SelectedValue == "0") // cariler seçiniz seçilirse
                || (ddlTemsilciler.SelectedValue == "0")) // satış temsilcileri seçiniz seçilirse
            {
                GetAnlasmalarBos();
                return;
            }

            if (ddlTemsilciler.SelectedValue == "1") // tümü
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    GetAnlasmalarCount();
                    GetAnlasmalar(Baslangic, (int)Session["AnlasmalarSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü
            {
                GetAnlasmalarCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                GetAnlasmalarBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), Baslangic, (int)Session["AnlasmalarSayfaBasiGosterim"]);
            }
            else if (ddlCariHesaplarSubeler.SelectedValue == "TUM1" || !ddlCariHesaplarSubeler.Visible) // şubeler tümü
            {
                GetAnlasmalarCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                GetAnlasmalarByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), Baslangic, (int)Session["AnlasmalarSayfaBasiGosterim"]);
            }
            else // şube
            {
                GetAnlasmalarCountBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)));
                GetAnlasmalarBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), Baslangic, (int)Session["AnlasmalarSayfaBasiGosterim"]);
            }
        }

        private void GetAnlasmalarBos()
        {
            dataList.DataSource = null;
            dataList.DataBind();
            lblAnlasmaKacinci.Text = "0"; lblAnlasmaSayisi.Text = "0";
            lblAnlasmaYok.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void dataList_DataBound(object sender, EventArgs e)
        {
            lblAnlasmaYok.Visible = dataList.Items.Count == 0;
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

                    GetAnlasmalarCount();
                    GetAnlasmalar(0, (int)Session["AnlasmalarSayfaBasiGosterim"]);
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

            Calendar1.SelectedDate = Convert.ToDateTime("01.01." + (DateTime.Now.Year - 1).ToString());
            Calendar2.SelectedDate = DateTime.Now;

            GetAnlasmalarBos();

            lblAnlasmaYok.Visible = true;

            if (ddlTemsilciler.SelectedValue == "0")
                Session["AnlasmaGetirilecekSMREF"] = null;
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
                    CariHesaplar.GetSubeler(ddlCariHesaplarSubeler.Items,
                        Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
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

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty)
                return;

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;

            GetAnlasmalarBos();

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

        protected void ibIncele_Click(object sender, ImageClickEventArgs e)
        {
            int AnlasmaID = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("pkID"))
                    {
                        AnlasmaID = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }

            Anlasmalar anlasma = Anlasmalar.GetObject(AnlasmaID);

            if (anlasma.strAciklama2 == "1")
            {
                CariHesaplarTP musteri = CariHesaplarTP.GetObject(anlasma.SMREF, false);
                txtAnlasmaMusteri.Text = musteri.SUBE;
                txtAnlasmaIl.Text = musteri.IL;
                txtAnlasmaBayi.Text = CariHesaplarTP.GetObject(anlasma.SMREF, true).MUSTERI;
            }
            else
            {
                txtAnlasmaMusteri.Text = CariHesaplar.GetMUSTERIbyGMREF(anlasma.SMREF);
                txtAnlasmaIl.Text = "İSTANBUL";
                txtAnlasmaBayi.Text = "SULTANLAR PAZARLAMA A.Ş.";
            }

            txtAnlasmaSubeSayisi.Text = anlasma.strAciklama4;
            datepickerAnlasmaBaslangic.Value = anlasma.dtBaslangic.ToShortDateString();
            datepickerAnlasmaBitis.Value = anlasma.dtBitis.ToShortDateString();
            txtAnlasmaVadeTAH.Text = anlasma.intVadeTAH.ToString();
            txtAnlasmaVadeYEG.Text = anlasma.intVadeYEG.ToString();
            txtAnlasmaSKUTAH.Text = anlasma.intListSKUTAH.ToString();
            txtAnlasmaSKUYEG.Text = anlasma.intListSKUYEG.ToString();

            txtAnlasmaTAHIsk.Text = anlasma.flTAHIsk.ToString("N1");
            txtAnlasmaTAHCiro.Text = anlasma.flTAHCiro.ToString("N1");
            txtAnlasmaTAHCiro3.Text = anlasma.flTAHCiro3.ToString("N1");
            txtAnlasmaTAHCiro6.Text = anlasma.flTAHCiro6.ToString("N1");
            txtAnlasmaTAHCiro12.Text = anlasma.flTAHCiro12.ToString("N1");
            txtAnlasmaTAHCiroIsk.Text = anlasma.flTAHCiroIsk.ToString("N1");
            txtAnlasmaYEGIsk.Text = anlasma.flYEGIsk.ToString("N1");
            txtAnlasmaYEGCiro.Text = anlasma.flYEGCiro.ToString("N1");
            txtAnlasmaYEGCiro3.Text = anlasma.flYEGCiro3.ToString("N1");
            txtAnlasmaYEGCiro6.Text = anlasma.flYEGCiro6.ToString("N1");
            txtAnlasmaYEGCiro12.Text = anlasma.flYEGCiro12.ToString("N1");
            txtAnlasmaYEGCiroIsk.Text = anlasma.flYEGCiroIsk.ToString("N1");

            txtAnlasmaTAHAnlasmaDisiBedeller.Text = anlasma.mnTAHAnlasmaDisiBedeller.ToString("C2");
            txtAnlasmaYEGAnlasmaDisiBedeller.Text = anlasma.mnYEGAnlasmaDisiBedeller.ToString("C2");
            txtAnlasmaTAHTumBedeller.Text = (anlasma.mnTAHAnlasmaDisiBedeller + anlasma.TAHTumBedellerToplami).ToString("C2");
            txtAnlasmaYEGTumBedeller.Text = (anlasma.mnYEGAnlasmaDisiBedeller + anlasma.YEGTumBedellerToplami).ToString("C2");
            txtAnlasmaTAHToplamCiro.Text = anlasma.mnTAHToplamCiro.ToString("C2");
            txtAnlasmaYEGToplamCiro.Text = anlasma.mnYEGToplamCiro.ToString("C2");
            txtAnlasmaTAHYilSonuMaliyet.Text = anlasma.TAHYilSonuMaliyet.ToString("N1");
            txtAnlasmaYEGYilSonuMaliyet.Text = anlasma.YEGYilSonuMaliyet.ToString("N1");
            txtAnlasmaTAHCiroPrimiDahil.Text = anlasma.TAHCiroPrimiDahilNetMaliyet.ToString("N1");
            txtAnlasmaYEGCiroPrimiDahil.Text = anlasma.YEGCiroPrimiDahilNetMaliyet.ToString("N1");
            txtAnlasmaAciklama.Text = anlasma.strAciklama1;

            ibYazdir.CommandArgument = anlasma.pkID.ToString();

            DataTable dt = new DataTable();
            AnlasmaBedeller.GetObjects(dt, AnlasmaID);
            rptHizmetBedelleri.DataSource = dt;
            rptHizmetBedelleri.DataBind();

            divAnlasma.Visible = true;
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("pkID"))
                    {
                        Session["SilinecekAnlasmaID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            divAnlasmaSil.Visible = true;
        }

        protected void lbSilEvet_Click(object sender, EventArgs e)
        {
            if (Session["SilinecekAnlasmaID"] != null)
            {
                Anlasmalar anlasma = Anlasmalar.GetObject(Convert.ToInt32(Session["SilinecekAnlasmaID"]));
                anlasma.DoDelete();

                DataTable dt = new DataTable();
                AnlasmaBedeller.GetObjects(dt, anlasma.pkID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AnlasmaBedeller anlasmabedel = AnlasmaBedeller.GetObject(Convert.ToInt32(dt.Rows[i]["pkID"]));
                    anlasmabedel.DoDelete();
                }

                Session["SilinecekAnlasmaID"] = null;
                divAnlasmaSil.Visible = false;
                Getir(0);
            }
        }

        protected void lbSilHayir_Click(object sender, EventArgs e)
        {
            Session["SilinecekAnlasmaID"] = null;
            divAnlasmaSil.Visible = false;
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblAnlasmaKacinci.Text) - (int)Session["AnlasmalarSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["AnlasmalarSayfaBasiGosterim"] < baslangic)
                {
                    Getir(baslangic - (int)Session["AnlasmalarSayfaBasiGosterim"]);
                    lblAnlasmaKacinci.Text = baslangic.ToString();
                }
                else
                {
                    Getir(0);
                    lblAnlasmaKacinci.Text = Session["AnlasmalarSayfaBasiGosterim"].ToString();
                }
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblAnlasmaKacinci.Text) + (int)Session["AnlasmalarSayfaBasiGosterim"];
            if (Convert.ToInt32(lblAnlasmaKacinci.Text) < Convert.ToInt32(lblAnlasmaSayisi.Text))
            {
                Getir(baslangic - (int)Session["AnlasmalarSayfaBasiGosterim"]);

                if (baslangic > Convert.ToInt32(lblAnlasmaSayisi.Text))
                    lblAnlasmaKacinci.Text = lblAnlasmaSayisi.Text;
                else
                    lblAnlasmaKacinci.Text = baslangic.ToString();
            }
        }

        protected void rbHepsi_Checked(object sender, EventArgs e)
        {
            Getir(0);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblTarihSecim1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            lblTarihSecim2.Text = Calendar2.SelectedDate.ToShortDateString();
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
            divTarih.Visible = false;
            Getir(0);
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
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + (DateTime.Now.Year - 1).ToString());
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
            }
        }

        protected void lbAnlasmaKapat_Click(object sender, EventArgs e)
        {
            divAnlasma.Visible = false;
        }

        protected void ibYazdir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("yazdiranlasma.aspx?id=" + ibYazdir.CommandArgument, true);
        }
    }
}