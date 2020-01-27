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
    public partial class hizmetbedelleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 6 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 2) // bayi yöneticisi veya yönetici değil ise
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

                Session["HizmetBedelleriSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intSiparisSatirSayisi;

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
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
            {
                SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, true);
                ddlTemsilciler.SelectedIndex = 1;

                divCariHesapArama.Visible = true;
                ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));
                ddlCariHesaplar.SelectedIndex = 1;

                GetHizmetBedelleriCount();
                GetHizmetBedelleri(0, (int)Session["HizmetBedelleriSayfaBasiGosterim"]);
            }
        }

        #region BySMREF
        private int GetHizmetBedelleriCountBySMREF(int SMREF)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            int donendeger = AnlasmaHizmetBedelleri.GetObjectCount(SMREF, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblHizmetBedeliKacinci.Text = Session["HizmetBedelleriSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["HizmetBedelleriSayfaBasiGosterim"])
                lblHizmetBedeliKacinci.Text = donendeger.ToString();

            lblHizmetBedeliSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetHizmetBedelleriBySMREF(int SMREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            AnlasmaHizmetBedelleri.GetObjects(dt, SMREF, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        #region ByGMREF
        // parametre ile gelen GMREF fuzuli çünkü smref leri ddlcarihesapsubeler den alıyoruz
        private int GetHizmetBedelleriCountByGMREF(int GMREF)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            int donendeger = AnlasmaHizmetBedelleri.GetObjectCount(SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblHizmetBedeliKacinci.Text = Session["HizmetBedelleriSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["HizmetBedelleriSayfaBasiGosterim"])
                lblHizmetBedeliKacinci.Text = donendeger.ToString();

            lblHizmetBedeliSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetHizmetBedelleriByGMREF(int GMREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            DataTable dt = new DataTable();
            AnlasmaHizmetBedelleri.GetObjects(dt, SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        #region BySLSREF
        private int GetHizmetBedelleriCountBySLSREF(int SLSREF)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            CariHesaplarTP.GetSMREFsBySLSREF(SMREFs, SLSREF);

            int donendeger = AnlasmaHizmetBedelleri.GetObjectCount(SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblHizmetBedeliKacinci.Text = Session["HizmetBedelleriSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["HizmetBedelleriSayfaBasiGosterim"])
                lblHizmetBedeliKacinci.Text = donendeger.ToString();

            lblHizmetBedeliSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetHizmetBedelleriBySLSREF(int SLSREF, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            CariHesaplarTP.GetSMREFsBySLSREF(SMREFs, SLSREF);

            DataTable dt = new DataTable();
            AnlasmaHizmetBedelleri.GetObjects(dt, SMREFs, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        #region All
        private int GetHizmetBedelleriCount()
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            int donendeger = AnlasmaHizmetBedelleri.GetObjectCount(Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate);

            if (donendeger > 0)
                lblHizmetBedeliKacinci.Text = Session["HizmetBedelleriSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["HizmetBedelleriSayfaBasiGosterim"])
                lblHizmetBedeliKacinci.Text = donendeger.ToString();

            lblHizmetBedeliSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetHizmetBedelleri(int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            AnlasmaHizmetBedelleri.GetObjects(dt, Onayli, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet);

            dataList.DataSource = dt;
            dataList.DataBind();
        }
        #endregion

        private void Getir(int Baslangic)
        {
            if ((ddlCariHesaplarSubeler.Visible && ddlCariHesaplarSubeler.SelectedValue == "HIC0") // şubeler seçiniz seçilirse
                || (ddlCariHesaplar.SelectedValue == "0") // cariler seçiniz seçilirse
                || (ddlTemsilciler.SelectedValue == "0")) // satış temsilcileri seçiniz seçilirse
            {
                GetHizmetBedelleriBos();
                return;
            }

            if (ddlTemsilciler.SelectedValue == "1") // tümü
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise
                {
                    GetHizmetBedelleriCount();
                    GetHizmetBedelleri(Baslangic, (int)Session["HizmetBedelleriSayfaBasiGosterim"]);
                }
            }
            else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü
            {
                //GetHizmetBedelleriCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                //GetHizmetBedelleriBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), Baslangic, (int)Session["HizmetBedelleriSayfaBasiGosterim"]);
            }
            else if (ddlCariHesaplarSubeler.SelectedValue == "TUM1" || !ddlCariHesaplarSubeler.Visible) // şubeler tümü
            {
                GetHizmetBedelleriCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                GetHizmetBedelleriByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), Baslangic, (int)Session["HizmetBedelleriSayfaBasiGosterim"]);
            }
            else // şube
            {
                GetHizmetBedelleriCountBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)));
                GetHizmetBedelleriBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)), Baslangic, (int)Session["HizmetBedelleriSayfaBasiGosterim"]);
            }
        }

        private void GetHizmetBedelleriBos()
        {
            dataList.DataSource = null;
            dataList.DataBind();
            lblHizmetBedeliKacinci.Text = "0"; lblHizmetBedeliSayisi.Text = "0";
            lblHizmetYok.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void dataList_DataBound(object sender, EventArgs e)
        {
            lblHizmetYok.Visible = dataList.Items.Count == 0;
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
                }

                return;
            }

            ddlCariHesaplar.Items.Clear();
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));
            if (ddlTemsilciler.SelectedValue != "0")
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;

            CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, Convert.ToInt32(ddlTemsilciler.SelectedValue), true, true);

            GetHizmetBedelleriBos();

            lblHizmetYok.Visible = true;

            if (ddlTemsilciler.SelectedValue == "0")
                Session["HizmetBedeliGetirilecekSMREF"] = null;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCariHesaplar.SelectedValue != "0" && ddlCariHesaplar.SelectedValue != "1")
            {
                ddlCariHesaplarSubeler.Visible = true;
                CariHesaplarTP.GetSubelerByGMREF(ddlCariHesaplarSubeler.Items,
                    Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
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

            GetHizmetBedelleriBos();

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

        protected void ibDegistir_Click(object sender, ImageClickEventArgs e)
        {
            AnlasmaBedelAdlari.GetObjects(ddlAnlasmaBedelAdlari.Items, 0, 0);

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("pkID"))
                    {
                        hizmetID.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            AnlasmaHizmetBedelleri hizmet = AnlasmaHizmetBedelleri.GetObject(Convert.ToInt32(hizmetID.Value));
            for (int i = 0; i < ddlAnlasmaBedelAdlari.Items.Count; i++)
                if (ddlAnlasmaBedelAdlari.Items[i].Value == hizmet.intAnlasmaBedelAdID.ToString())
                    ddlAnlasmaBedelAdlari.SelectedIndex = i;
            txtAy.Text = hizmet.intAy.ToString();
            txtYil.Text = hizmet.intYil.ToString();
            txtFatNo.Text = hizmet.strFaturaNo;
            datepicker1.Value = hizmet.dtFaturaTarih.ToShortDateString();
            txtTAHBedel.Text = hizmet.mnTAHBedel.ToString("N2");
            txtYEGBedel.Text = hizmet.mnYEGBedel.ToString("N2");
            txtAciklama.Text = hizmet.strAciklama1;
            txtMudurButcesi.Text = Convert.ToInt32(hizmet.mnMudurButce).ToString();
            txtElemanButcesi.Text = Convert.ToInt32(hizmet.mnElemanButce).ToString();
            cbKapamaEtki.Checked = hizmet.blKapamaEtki;



            ddlAnlasmaBedelAdlari.Enabled = true;
            txtAy.Enabled = true;
            txtYil.Enabled = true;
            txtFatNo.Enabled = true;
            datepicker1.Disabled = false;
            txtTAHBedel.Enabled = true;
            txtYEGBedel.Enabled = true;
            txtAciklama.Enabled = true;
            txtMudurButcesi.Enabled = true;
            txtElemanButcesi.Enabled = true;
            cbKapamaEtki.Enabled = true;
            lbHizmetBedeliGirKaydet.Enabled = true;
            divHizmetBedeliGir.Visible = true;
        }

        protected void ibIncele_Click(object sender, ImageClickEventArgs e)
        {
            AnlasmaBedelAdlari.GetObjects(ddlAnlasmaBedelAdlari.Items, 0, 0);

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("pkID"))
                    {
                        hizmetID.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            AnlasmaHizmetBedelleri hizmet = AnlasmaHizmetBedelleri.GetObject(Convert.ToInt32(hizmetID.Value));
            for (int i = 0; i < ddlAnlasmaBedelAdlari.Items.Count; i++)
                if (ddlAnlasmaBedelAdlari.Items[i].Value == hizmet.intAnlasmaBedelAdID.ToString())
                    ddlAnlasmaBedelAdlari.SelectedIndex = i;
            txtAy.Text = hizmet.intAy.ToString();
            txtYil.Text = hizmet.intYil.ToString();
            txtFatNo.Text = hizmet.strFaturaNo;
            datepicker1.Value = hizmet.dtFaturaTarih.ToShortDateString();
            txtTAHBedel.Text = hizmet.mnTAHBedel.ToString("N2");
            txtYEGBedel.Text = hizmet.mnYEGBedel.ToString("N2");
            txtAciklama.Text = hizmet.strAciklama1;
            txtMudurButcesi.Text = Convert.ToInt32(hizmet.mnMudurButce).ToString();
            txtElemanButcesi.Text = Convert.ToInt32(hizmet.mnElemanButce).ToString();
            cbKapamaEtki.Checked = hizmet.blKapamaEtki;



            ddlAnlasmaBedelAdlari.Enabled = false;
            txtAy.Enabled = false;
            txtYil.Enabled = false;
            txtFatNo.Enabled = false;
            datepicker1.Disabled = true;
            txtTAHBedel.Enabled = false;
            txtYEGBedel.Enabled = false;
            txtAciklama.Enabled = false;
            txtMudurButcesi.Enabled = false;
            txtElemanButcesi.Enabled = false;
            cbKapamaEtki.Enabled = false;
            lbHizmetBedeliGirKaydet.Enabled = false;
            divHizmetBedeliGir.Visible = true;
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("pkID"))
                    {
                        Session["SilinecekAnlasmaHizmetBedelID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            divHizmetSil.Visible = true;
        }

        protected void lbSilEvet_Click(object sender, EventArgs e)
        {
            if (Session["SilinecekAnlasmaHizmetBedelID"] != null)
            {
                AnlasmaHizmetBedelleri hizmet = AnlasmaHizmetBedelleri.GetObject(Convert.ToInt32(Session["SilinecekAnlasmaHizmetBedelID"]));
                hizmet.DoDelete();
                Session["SilinecekAnlasmaHizmetBedelID"] = null;
                divHizmetSil.Visible = false;
                Getir(0);
            }
        }

        protected void lbSilHayir_Click(object sender, EventArgs e)
        {
            Session["SilinecekAnlasmaHizmetBedelID"] = null;
            divHizmetSil.Visible = false;
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            int hizmetid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("pkID"))
                    {
                        hizmetid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }

            if (hizmetid != 0)
            {
                Session["downloadhizmetid"] = hizmetid;
                divSiparisKaydet.Visible = true;
            }

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisKaydet, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisKaydetKapat_Click(object sender, EventArgs e)
        {
            divSiparisKaydet.Visible = false;
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblHizmetBedeliKacinci.Text) - (int)Session["HizmetBedelleriSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["HizmetBedelleriSayfaBasiGosterim"] < baslangic)
                {
                    Getir(baslangic - (int)Session["HizmetBedelleriSayfaBasiGosterim"]);
                    lblHizmetBedeliKacinci.Text = baslangic.ToString();
                }
                else
                {
                    Getir(0);
                    lblHizmetBedeliKacinci.Text = Session["HizmetBedelleriSayfaBasiGosterim"].ToString();
                }
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblHizmetBedeliKacinci.Text) + (int)Session["HizmetBedelleriSayfaBasiGosterim"];
            if (Convert.ToInt32(lblHizmetBedeliKacinci.Text) < Convert.ToInt32(lblHizmetBedeliSayisi.Text))
            {
                Getir(baslangic - (int)Session["HizmetBedelleriSayfaBasiGosterim"]);

                if (baslangic > Convert.ToInt32(lblHizmetBedeliSayisi.Text))
                    lblHizmetBedeliKacinci.Text = lblHizmetBedeliSayisi.Text;
                else
                    lblHizmetBedeliKacinci.Text = baslangic.ToString();
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
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.AddYears(-1).Year.ToString());
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
            }
        }

        protected void btnHizmetBedeliGir_Click(object sender, EventArgs e)
        {
            if (ddlCariHesaplarSubeler.Visible && ddlCariHesaplarSubeler.SelectedIndex > 1)
            {
                AnlasmaBedelAdlari.GetObjects(ddlAnlasmaBedelAdlari.Items, 0, 0);
                hizmetID.Value = "0";



                ddlAnlasmaBedelAdlari.Enabled = true;
                txtAy.Enabled = true;
                txtYil.Enabled = true;
                txtFatNo.Enabled = true;
                datepicker1.Disabled = false;
                txtTAHBedel.Enabled = true;
                txtYEGBedel.Enabled = true;
                txtAciklama.Enabled = true;
                txtMudurButcesi.Enabled = true;
                txtElemanButcesi.Enabled = true;
                cbKapamaEtki.Enabled = true;
                lbHizmetBedeliGirKaydet.Enabled = true;

                ddlAnlasmaBedelAdlari.SelectedIndex = 0;
                txtAy.Text = "01";
                txtYil.Text = DateTime.Now.Year.ToString();
                txtFatNo.Text = string.Empty;
                datepicker1.Value = string.Empty;
                txtTAHBedel.Text = "0";
                txtYEGBedel.Text = "0";
                txtAciklama.Text = string.Empty;
                txtMudurButcesi.Text = DateTime.Now.Year.ToString();
                txtElemanButcesi.Text = "1";
                cbKapamaEtki.Checked = true;

                divHizmetBedeliGir.Visible = true;
            }
        }

        protected void lbHizmetBedeliGirKaydet_Click(object sender, EventArgs e)
        {
            if (txtAy.Text.Trim() != "01" && txtAy.Text.Trim() != "02" && txtAy.Text.Trim() != "03" && txtAy.Text.Trim() != "04" && txtAy.Text.Trim() != "05" && txtAy.Text.Trim() != "06" && txtAy.Text.Trim() != "07" && txtAy.Text.Trim() != "08" && txtAy.Text.Trim() != "09" && txtAy.Text.Trim() != "10" && txtAy.Text.Trim() != "11" && txtAy.Text.Trim() != "12")
            {
                string alert1 = "<script type='text/javascript'>alert('Girilen ay değerinde hata var. Format şu şekilde olmalıdır: örneğin Ocak ayı: \"01\"');</script>";
                ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "scriptSayfayukaricikar", alert1, false);
                return;
            }

            try
            {
                if (hizmetID.Value != "0")
                {
                    AnlasmaHizmetBedelleri hizmet = AnlasmaHizmetBedelleri.GetObject(Convert.ToInt32(hizmetID.Value));

                    hizmet.intMusteriID = ((Musteriler)Session["Musteri"]).pkMusteriID;
                    hizmet.intAnlasmaBedelAdID = Convert.ToInt32(ddlAnlasmaBedelAdlari.SelectedValue);
                    hizmet.intAy = Convert.ToInt32(txtAy.Text.Trim());
                    hizmet.intYil = Convert.ToInt32(txtYil.Text.Trim());
                    hizmet.strFaturaNo = txtFatNo.Text.Trim();
                    hizmet.dtFaturaTarih = Convert.ToDateTime(datepicker1.Value);
                    hizmet.mnTAHBedel = Convert.ToDecimal(txtTAHBedel.Text.Trim());
                    hizmet.mnYEGBedel = Convert.ToDecimal(txtYEGBedel.Text.Trim());
                    hizmet.strAciklama1 = txtAciklama.Text.Trim();
                    hizmet.mnMudurButce = Convert.ToInt32(txtMudurButcesi.Text.Trim());
                    hizmet.mnElemanButce = Convert.ToInt32(txtElemanButcesi.Text.Trim());
                    hizmet.blKapamaEtki = cbKapamaEtki.Checked;

                    hizmet.DoUpdate();
                }
                else
                {
                    AnlasmaHizmetBedelleri ahb = new AnlasmaHizmetBedelleri(
                        Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)),
                        ((Musteriler)Session["Musteri"]).pkMusteriID,
                        Convert.ToInt32(ddlAnlasmaBedelAdlari.SelectedValue),
                        Convert.ToInt32(txtAy.Text.Trim()), Convert.ToInt32(txtYil.Text.Trim()), txtFatNo.Text.Trim(),
                        Convert.ToDateTime(datepicker1.Value), Convert.ToDecimal(txtTAHBedel.Text.Trim()),
                        Convert.ToDecimal(txtYEGBedel.Text.Trim()), 0, txtAciklama.Text.Trim(), "", "", "",
                        Convert.ToInt32(txtMudurButcesi.Text.Trim()), Convert.ToInt32(txtElemanButcesi.Text.Trim()), cbKapamaEtki.Checked);
                    ahb.DoInsert();
                }

                hizmetID.Value = "0";
                divHizmetBedeliGir.Visible = false;
                Getir(0);
            }
            catch (Exception ex)
            {
                string alert1 = "<script type='text/javascript'>alert('Girilen değerlerde hata var, lütfen düzeltip tekrar gönderin.\r\n\r\nHata ayrıntısı: " + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "scriptSayfayukaricikar", alert1, false);
            }
        }

        protected void lbHizmetBedeliGirKapat_Click(object sender, EventArgs e)
        {
            hizmetID.Value = "0";
            divHizmetBedeliGir.Visible = false;
        }

        protected void ibTumunuKaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlCariHesaplarSubeler.SelectedIndex > 1) // alt cari
            {
                Session["downloadhizmetlersmref"] = Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3));
                Session["downloadhizmetleronayli"] = rbOnaylilar.Checked ? 1 : rbOnaysizlar.Checked ? 0 : -1;
                Session["downloadhizmetlertarihbaslangic"] = Calendar1.SelectedDate;
                Session["downloadhizmetlertarihbitis"] = Calendar2.SelectedDate;
                //Response.Redirect("download.aspx", true);

                ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "redirect", "<script type='text/javascript'>window.location.href='download.aspx';</script>", false);
            }
            else if (ddlCariHesaplarSubeler.SelectedIndex == 1) // tüm alt cariler
            {
                Session["downloadhizmetlergmref"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));
                Session["downloadhizmetleronayli"] = rbOnaylilar.Checked ? 1 : rbOnaysizlar.Checked ? 0 : -1;
                Session["downloadhizmetlertarihbaslangic"] = Calendar1.SelectedDate;
                Session["downloadhizmetlertarihbitis"] = Calendar2.SelectedDate;
                //Response.Redirect("download.aspx", true);

                ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "redirect", "<script type='text/javascript'>window.location.href='download.aspx';</script>", false);
            }
        }
    }
}