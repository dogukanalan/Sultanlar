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

namespace Sultanlar.WebUI.musteri
{
    public partial class yonetici : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                Session["SiparislerSayfaBasiGosterim"] = 15;

                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year);
                Calendar2.SelectedDate = DateTime.Now;

                if (((Musteriler)Session["Musteri"]).intSLSREF > 0) // satış temsilcisiyse - lüzumsuz
                {
                    ArrayList altlar = SatisTemsilcileriSefler.GetAltRefler(((Musteriler)Session["Musteri"]).intSLSREF);
                    Session["SefSLSREFs"] = altlar;
                    //rbTumu.Checked = false;
                    //rbCariHesap.Checked = false;
                    //rbMusteri.Checked = true;
                    //ddlMusteriler.Enabled = true;
                    //GetMusteriler((ArrayList)Session["SefSLSREFs"]);
                    GetSiparisCountBySLSREFs(altlar);
                    GetSiparislerBySLSREFs(altlar, 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else // full yetkili yöneticiyse
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
        }

        private void GetCariHesaplar()
        {
            CariHesaplar.GetObjects(ddlCariHesaplar.Items);
        }
        private void GetCariHesaplar(ArrayList SLSREFs)
        {
            CariHesaplar.GetObjects(ddlCariHesaplar.Items, SLSREFs, true);
        }

        private void GetMusteriler()
        {
            Musteriler.GetObjects(ddlMusteriler.Items);
        }
        private void GetMusteriler(ArrayList SLSREFs)
        {
            Musteriler.GetObjects(ddlMusteriler.Items, SLSREFs, true);
        }

        private void GetSiparislerBos()
        {
            dlSiparisler.DataBind();
            lblSiparisSayisi.Text = "0";
            lblSiparisKacinci.Text = "0";
        }

        private void SiparislerOnaylananlarArkaPlan()
        {
            foreach (Control ctrl in dlSiparisler.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlTableRow)
                    {
                        if (((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).Attributes["class"] == "True")
                        {
                            ((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).BgColor = "#D3EAFF";
                            ((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).Style["filter"] = "alpha(opacity=80)";
                            ((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).Style["-moz-opacity"] = ".80";
                            ((System.Web.UI.HtmlControls.HtmlTableRow)ctrl2).Style["opacity"] = ".80";
                        }
                    }
                }
            }
        }

        private int GetSiparisCount()
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            int donendeger = Siparisler.GetSiparisCount(Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli, "");

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

            DataTable dt = new DataTable();
            Siparisler.GetObjects(dt, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli, "");
            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();

            SiparislerOnaylananlarArkaPlan();
        }
        private int GetSiparisCountByMusteriID(int MusteriID)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            int donendeger = Siparisler.GetSiparisCountByMusteriID(MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

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
            Siparisler.GetObjectsByMusteriID(dt, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();

            SiparislerOnaylananlarArkaPlan();
        }
        private int GetSiparisCountByGMREF(int GMREF)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
                SMREFs.Add(dt.Rows[i]["SMREF"].ToString());

            int donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

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

            DataTable dt = new DataTable();
            CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
                SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            DataTable dtSiparisler = new DataTable();
            Siparisler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();

            SiparislerOnaylananlarArkaPlan();
        }
        private int GetSiparisCountBySLSREFs(ArrayList SLSREFs)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            for (int j = 0; j < SLSREFs.Count; j++)
            {
                DataTable dt = new DataTable();
                CariHesaplar.GetSMREFsBySLSREF(dt, Convert.ToInt32(SLSREFs[j]));
                for (int i = 0; i < dt.Rows.Count; i++)
                    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            }

            int donendeger = Siparisler.GetSiparisCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["SiparislerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["SiparislerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySLSREFs(ArrayList SLSREFs, int Baslangic, int Adet)
        {
            object Onayli = DBNull.Value;
            if (rbSiparislerOnaylilar.Checked)
                Onayli = true;
            else if (rbSiparislerOnaysizlar.Checked)
                Onayli = false;

            ArrayList SMREFs = new ArrayList();
            for (int j = 0; j < SLSREFs.Count; j++)
            {
                DataTable dt = new DataTable();
                CariHesaplar.GetSMREFsBySLSREF(dt, Convert.ToInt32(SLSREFs[j]));
                for (int i = 0; i < dt.Rows.Count; i++)
                    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            }

            DataTable dtSiparisler = new DataTable();
            Siparisler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();

            SiparislerOnaylananlarArkaPlan();
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
                int miktar = Convert.ToInt32(dt.Rows[i]["intMiktar"]);
                bool kampanyahediye = Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]);
                decimal oncekifiyat = Convert.ToDecimal(dt.Rows[i]["mnFiyat"]);
                decimal simdikifiyat = 0;

                simdikifiyat = oncekifiyat;

                siplist.Add(urunid, urunadi, miktar, simdikifiyat, kamkartref, kampanyahediye, kamsatirref, "ST", siparisdetayid);
            }

            SiparisIncele(siplist);
        }

        private void SiparisIncele(SiparisListe siplist)
        {
            divSiparis.Visible = true;
            Repeater1.DataSource = siplist;
            Repeater1.DataBind();
            lblSiparisToplam.Text = siplist.ToplamTutar.ToString("C3");

            if (TaksitPlanlari.TaksitMi(siplist._TKSREF))
                lblOrtalamaVade.Text = TaksitPlanlari.GetOdemePlani(siplist._TKSREF);
            else
                lblOrtalamaVade.Text = "Ortalama Vade: <strong>" + TaksitPlanlari.GetOdemePlani(siplist._TKSREF).Replace("GÜN VADE", "Gün") + "</strong>";
        }

        private void SiparisListesiniYenile()
        {
            if (rbMusteri.Checked)
            {
                GetSiparisCountByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue));
                GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), 0,
                        (int)Session["SiparislerSayfaBasiGosterim"]);

                //if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                //    GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), 0,
                //        (int)Session["SiparislerSayfaBasiGosterim"]);
                //else
                //    GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue),
                //        Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"],
                //        (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                if (rbCariHesap.Checked)
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue));
                    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0,
                            (int)Session["SiparislerSayfaBasiGosterim"]);

                    //if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                    //    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0,
                    //        (int)Session["SiparislerSayfaBasiGosterim"]);
                    //else
                    //    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue),
                    //        Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"],
                    //        (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (rbTumu.Checked)
                {
                    if (Session["SefSLSREFs"] != null)
                    {
                        GetSiparisCountBySLSREFs((ArrayList)Session["SefSLSREFs"]);
                        GetSiparislerBySLSREFs((ArrayList)Session["SefSLSREFs"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        GetSiparisCount();
                        GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }

                    //if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"] < 0)
                    //    GetSiparisler(
                    //        0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    //else
                    //    GetSiparisler(
                    //        Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"],
                    //        (int)Session["SiparislerSayfaBasiGosterim"]);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void rbTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTumu.Checked)
            {
                GetSiparislerBos();

                if (Session["SefSLSREFs"] != null)
                {
                    GetSiparisCountBySLSREFs((ArrayList)Session["SefSLSREFs"]);
                    GetSiparislerBySLSREFs((ArrayList)Session["SefSLSREFs"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }

                ddlCariHesaplar.Enabled = false;
                ddlMusteriler.Enabled = false;
                //ddlMusteriler.SelectedIndex = 0;
                //ddlCariHesaplar.SelectedIndex = 0;
                ddlMusteriler.Items.Clear();
                ddlCariHesaplar.Items.Clear();
            }
        }

        protected void rbCariHesap_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCariHesap.Checked)
            {
                GetSiparislerBos();

                if (Session["SefSLSREFs"] != null)
                    GetCariHesaplar((ArrayList)Session["SefSLSREFs"]);
                else
                    GetCariHesaplar();

                ddlCariHesaplar.Enabled = true;
                ddlMusteriler.Enabled = false;
                //ddlMusteriler.SelectedIndex = 0;
                ddlMusteriler.Items.Clear();
            }
        }

        protected void rbMusteri_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMusteri.Checked)
            {
                GetSiparislerBos();

                if (Session["SefSLSREFs"] != null)
                    GetMusteriler((ArrayList)Session["SefSLSREFs"]);
                else
                    GetMusteriler();

                ddlMusteriler.Enabled = true;
                ddlCariHesaplar.Enabled = false;
                //ddlCariHesaplar.SelectedIndex = 0;
                ddlCariHesaplar.Items.Clear();
            }
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCariHesaplar.SelectedIndex > 0)
            {
                GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue));
                GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                GetSiparislerBos();
            }
        }

        protected void ddlMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMusteriler.SelectedIndex > 0)
            {
                GetSiparisCountByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue));
                GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                GetSiparislerBos();
            }
        }

        protected void ibIncele_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Parent.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden)
                    {
                        if (ctrl2.ID.StartsWith("SiparisID"))
                        {
                            siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                            break;
                        }
                    }
                }
            }

            GetSiparisFromDB(siparisid);
        }

        protected void lbSiparisKapat_Click(object sender, EventArgs e)
        {
            divSiparis.Visible = false;
        }

        protected void ibKopyala_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibDegistir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibOnayla_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;
            int musteriid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Parent.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden)
                    {
                        if (ctrl2.ID.StartsWith("SiparisID"))
                        {
                            siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                        }
                        else if (ctrl2.ID.StartsWith("MusteriID"))
                        {
                            musteriid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                        }
                    }
                }
            }

            Session["SilinecekSiparisID"] = siparisid;
            Session["SilinecekSiparisIDMusteriID"] = musteriid;
            divSiparisSil.Visible = true;
        }

        protected void lbSiparisSilEvet_Click(object sender, EventArgs e)
        {
            Siparisler.DoDeleteWithSiparislerDetays((int)Session["SilinecekSiparisID"]);

            Musteriler musteri = Musteriler.GetMusteriByID((int)Session["SilinecekSiparisIDMusteriID"]);
            musteri.intSonYarimSiparisID = 0;
            musteri.DoUpdate();

            if (musteri.pkMusteriID == ((Musteriler)Session["Musteri"]).pkMusteriID) // silinen sipariş bu işlemi yapan yöneticiye ait ise, veritabanındaki sıfırlanan sonyarimsiparis sessionda da sıfırlansın
                ((Musteriler)Session["Musteri"]).intSonYarimSiparisID = 0;

            Session["SilinecekSiparisID"] = null;
            Session["SilinecekSiparisIDMusteriID"] = null;
            divSiparisSil.Visible = false;
            SiparisListesiniYenile();
        }

        protected void lbSiparisSilHayir_Click(object sender, EventArgs e)
        {
            Session["SilinecekSiparisID"] = null;
            divSiparisSil.Visible = false;
        }

        protected void ibYazdir_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Parent.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden)
                    {
                        if (ctrl2.ID.StartsWith("SiparisID"))
                        {
                            siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                            break;
                        }
                    }
                }
            }

            if (siparisid != 0)
            {
                Session["oncekiyazdirsiparisid"] = Session["yazdirsiparisid"];
                Session["yazdirsiparisid"] = siparisid;
            }
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            int siparisid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Parent.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is System.Web.UI.HtmlControls.HtmlInputHidden)
                    {
                        if (ctrl2.ID.StartsWith("SiparisID"))
                        {
                            siparisid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl2).Value);
                            break;
                        }
                    }
                }
            }

            if (siparisid != 0)
            {
                Session["downloadsiparisid"] = siparisid;
                divSiparisKaydet.Visible = true;
            }
        }

        protected void lbSiparisKaydetKapat_Click(object sender, EventArgs e)
        {
            divSiparisKaydet.Visible = false;
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
            if (rbMusteri.Checked)
            {
                GetSiparisCountByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue));
                GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                if (rbCariHesap.Checked) 
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue));
                    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (rbTumu.Checked)
                {
                    if (Session["SefSLSREFs"] != null)
                    {
                        GetSiparisCountBySLSREFs((ArrayList)Session["SefSLSREFs"]);
                        GetSiparislerBySLSREFs((ArrayList)Session["SefSLSREFs"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        GetSiparisCount();
                        GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
            }

            divTarih.Visible = false;
        }

        protected void rbSiparislerHepsi_Checked(object sender, EventArgs e)
        {
            if (rbMusteri.Checked)
            {
                GetSiparisCountByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue));
                GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
            }
            else
            {
                if (rbCariHesap.Checked)
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue));
                    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else if (rbTumu.Checked)
                {
                    if (Session["SefSLSREFs"] != null)
                    {
                        GetSiparisCountBySLSREFs((ArrayList)Session["SefSLSREFs"]);
                        GetSiparislerBySLSREFs((ArrayList)Session["SefSLSREFs"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        GetSiparisCount();
                        GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }
            }
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["SiparislerSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["SiparislerSayfaBasiGosterim"] < baslangic)
                {
                    if (rbMusteri.Checked)
                    {
                        GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (rbCariHesap.Checked)
                            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        else if (rbTumu.Checked)
                            GetSiparisler(baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }

                    lblSiparisKacinci.Text = baslangic.ToString();
                }
                else
                {
                    if (rbMusteri.Checked)
                    {
                        GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (rbCariHesap.Checked)
                        {
                            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                        }
                        else if (rbTumu.Checked)
                        {
                            if (Session["SefSLSREFs"] != null)
                                GetSiparislerBySLSREFs((ArrayList)Session["SefSLSREFs"], 0, (int)Session["SiparislerSayfaBasiGosterim"]);
                            else
                                GetSiparisler(0, (int)Session["SiparislerSayfaBasiGosterim"]);
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
                if (rbMusteri.Checked)
                {
                    GetSiparislerByMusteriID(Convert.ToInt32(ddlMusteriler.SelectedValue), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                }
                else
                {
                    if (rbCariHesap.Checked)
                    {
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue), baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                    else if (rbTumu.Checked)
                    {
                        if (Session["SefSLSREFs"] != null)
                            GetSiparislerBySLSREFs((ArrayList)Session["SefSLSREFs"], baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                        else
                            GetSiparisler(baslangic - (int)Session["SiparislerSayfaBasiGosterim"], (int)Session["SiparislerSayfaBasiGosterim"]);
                    }
                }

                if (baslangic > Convert.ToInt32(lblSiparisSayisi.Text))
                    lblSiparisKacinci.Text = lblSiparisSayisi.Text;
                else
                    lblSiparisKacinci.Text = baslangic.ToString();
            }
        }
    }
}