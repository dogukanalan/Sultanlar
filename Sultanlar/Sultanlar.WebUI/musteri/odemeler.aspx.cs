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
    /// ListItemCollection larda value nun başına text in ilk 3 hanesi GELİYOR
    /// </summary>
    public partial class odemeler : System.Web.UI.Page
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
                Session["OdemelerSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intSiparisSatirSayisi;

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                {
                    GetOdemeCountByMusteriID();
                    GetOdemelerByMusteriID(0, (int)Session["OdemelerSayfaBasiGosterim"]);

                    divOdemeYap.Visible = false;
                    divHesapSecim.Visible = false;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
                {
                    //hlSatistaOnAdim.Visible = true;
                    GetSatisSefYoneticiHesaplar();
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

                    GetOdemeCount();
                    GetOdemeler(0, (int)Session["OdemelerSayfaBasiGosterim"]);
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                {
                    Response.Redirect("yetkiyok.aspx", true);
                }
                else //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
                {
                    divHesapSecim.Visible = false;

                    ddlTemsilciler.Enabled = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 1;
                    int gmref = ((Musteriler)Session["Musteri"]).intGMREF;
                    Session["OdemeGetirilecekSMREF"] = gmref;

                    //ListItem lst = new ListItem();
                    //lst.Text = CariHesaplar.GetObjectByGMREF(gmref)[1].ToString();
                    //lst.Value = gmref.ToString().Substring(3);
                    //ddlCariHesaplar.Items.Add(lst);

                    GetOdemeCountBySMREF(((Musteriler)Session["Musteri"]).intGMREF);
                    GetOdemelerBySMREF(((Musteriler)Session["Musteri"]).intGMREF, 0, (int)Session["OdemelerSayfaBasiGosterim"]);
                }
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "kucukbilgi", alert, false);
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

                CariHesaplar.GetTekCarilerBySLSREF(ddlCariHesaplar.Items, ((Musteriler)Session["Musteri"]).intSLSREF, true, true);

                ArrayList anacarigmrefler = CariHesaplar.GetAnaCarilerGMREFBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF);
                for (int i = 0; i < anacarigmrefler.Count; i++)
                {
                    DataTable dtAna = new DataTable();
                    CariHesaplar.GetObjectByGMREF(dtAna, Convert.ToInt32(anacarigmrefler[i]), true);

                    ListItem lst = new ListItem();
                    lst.Text = dtAna.Rows[0][2].ToString();
                    lst.Value = dtAna.Rows[0][2].ToString().Substring(0, 3) + dtAna.Rows[0][0].ToString();
                    ddlCariHesaplar.Items.Add(lst);
                }

                ddlCariHesaplar.SelectedValue = "1";
                GetOdemeCount();
                GetOdemeler(0, (int)Session["OdemelerSayfaBasiGosterim"]);
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

                    for (int i = 1; i < ((ListItemCollection)Session["SefMusteriListesi"]).Count; i++) // seçiniz varsada tekrar eklemiyor
                        ddlCariHesaplar.Items.Add(((ListItemCollection)Session["SefMusteriListesi"])[i]);
                }

                //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise tümü seçili gelsin, smrefs siz tümü geliyor hızlı
                //{
                //    ddlCariHesaplar.SelectedValue = "1";
                //    GetOdemeCount();
                //    GetOdemeler(0, (int)Session["OdemelerSayfaBasiGosterim"]);
                //}
            }
        }

        private void GetOdemelerBos()
        {
            dlOdemeler.DataSource = null;
            dlOdemeler.DataBind();
        }

        private int GetOdemeCountBySMREF(int SMREF)
        {
            int donendeger = Odemeler.GetOdemeCountBySMREF(SMREF/*, Calendar1.SelectedDate, Calendar2.SelectedDate*/, true);

            if (donendeger > 0)
                lblOdemeKacinci.Text = Session["OdemelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["OdemelerSayfaBasiGosterim"])
                lblOdemeKacinci.Text = donendeger.ToString();

            lblOdemeSayisi.Text = donendeger.ToString();
            return donendeger;
        }

        private void GetOdemelerBySMREF(int SMREF, int Baslangic, int Adet)
        {
            DataTable dt = new DataTable();
            Odemeler.GetObjectsBySMREF(dt, SMREF, Baslangic, Adet, true);
            dlOdemeler.DataSource = dt;
            dlOdemeler.DataBind();
        }

        private int GetOdemeCountByMusteriID()
        {
            int donendeger = Odemeler.GetOdemeCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID/*, Calendar1.SelectedDate, Calendar2.SelectedDate*/, true);

            if (donendeger > 0)
                lblOdemeKacinci.Text = Session["OdemelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["OdemelerSayfaBasiGosterim"])
                lblOdemeKacinci.Text = donendeger.ToString();

            lblOdemeSayisi.Text = donendeger.ToString();
            return donendeger;
        }

        private void GetOdemelerByMusteriID(int Baslangic, int Adet)
        {
            DataTable dt = new DataTable();
            Odemeler.GetObjectsByMusteriID(dt, ((Musteriler)Session["Musteri"]).pkMusteriID, Baslangic, Adet, true, true);
            dlOdemeler.DataSource = dt;
            dlOdemeler.DataBind();
        }

        private int GetOdemeCount()
        {
            int donendeger = 0;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            {
                donendeger = Odemeler.GetOdemeCount();
            }
            else
            {
                ArrayList GMREFs = new ArrayList();
                if (Session["SatTemGMREFs"] == null)
                {
                    for (int i = 2; i < ddlCariHesaplar.Items.Count; i++) // seçiniz ve tümü hariç
                        GMREFs.Add(ddlCariHesaplar.Items[i].Value.Substring(3));

                    Session["SatTemGMREFs"] = GMREFs;
                }
                else
                {
                    GMREFs = (ArrayList)Session["SatTemGMREFs"];
                }

                if (GMREFs.Count > 0)
                    donendeger = Odemeler.GetOdemeCountBySMREFs(GMREFs/*, Calendar1.SelectedDate, Calendar2.SelectedDate*/);
            }

            if (donendeger > 0)
                lblOdemeKacinci.Text = Session["OdemelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["OdemelerSayfaBasiGosterim"])
                lblOdemeKacinci.Text = donendeger.ToString();

            lblOdemeSayisi.Text = donendeger.ToString();
            return donendeger;
        }

        private void GetOdemeler(int Baslangic, int Adet)
        {
            DataTable dt = new DataTable();

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            {
                Odemeler.GetObjects(dt, Baslangic, Adet, true);
            }
            else
            {
                ArrayList GMREFs = new ArrayList();
                if (Session["SatTemGMREFs"] == null)
                {
                    for (int i = 2; i < ddlCariHesaplar.Items.Count; i++) // seçiniz ve tümü hariç
                        GMREFs.Add(ddlCariHesaplar.Items[i].Value.Substring(3));

                    Session["SatTemGMREFs"] = GMREFs;
                }
                else
                {
                    GMREFs = (ArrayList)Session["SatTemGMREFs"];
                }

                if (GMREFs.Count > 0)
                    Odemeler.GetObjectsBySMREFs(dt, GMREFs, Baslangic, Adet, true);
            }

            dlOdemeler.DataSource = dt;
            dlOdemeler.DataBind();
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
            string[] aciklamalar = siparis.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            lblSiparisAciklama.Text = "<strong>Açıklama:</strong> -";
            if (aciklamalar[0] != string.Empty)
                lblSiparisAciklama.Text = lblSiparisAciklama.Text.Substring(0, lblSiparisAciklama.Text.Length - 1) + "<i>" + aciklamalar[0] + "</i>";
            if (aciklamalar[1] != string.Empty)
                lblSiparisAciklama.Text += " - <i>" + aciklamalar[1] + "</i>";
        }

        private void SiparisIncele(SiparisListe siplist)
        {
            divSiparis.Visible = true;

            Repeater1.DataSource = siplist;
            Repeater1.DataBind();
            lblSiparisToplam.Text = siplist.ToplamTutar.ToString("C3");
            //lblOrtalamaVade.Text = GetSiparisOrtVade(siplist).ToString();

            if (TaksitPlanlari.TaksitMi(siplist._TKSREF))
                lblOrtalamaVade.Text = TaksitPlanlari.GetOdemePlani(siplist._TKSREF);
            else
                lblOrtalamaVade.Text = (((Musteriler)Session["Musteri"]).tintUyeTipiID != 1) ? "Ortalama Vade: <strong>" + TaksitPlanlari.GetOdemePlani(siplist._TKSREF).Replace("GÜN VADE", "Gün") + "</strong>" : "";



            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparis, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void lbSiparisIncele_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(((LinkButton)sender).CommandArgument) > 0)
                GetSiparisFromDB(Convert.ToInt32(((LinkButton)sender).CommandArgument));
        }

        protected void lbSiparisKapat_Click(object sender, EventArgs e)
        {
            divSiparis.Visible = false;
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCariHesaplar.Items.Clear();
            ddlCariHesaplar.Items.Add(new ListItem("Seçiniz", "0"));

            if (ddlTemsilciler.SelectedValue == "0")
            {
                
            }
            else if (ddlTemsilciler.SelectedValue == "1")
            {
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
                {
                    ArrayList slsrefs = new ArrayList();
                    for (int i = 2; i < ddlTemsilciler.Items.Count; i++)
                        slsrefs.Add(Convert.ToInt32(ddlTemsilciler.Items[i].Value));

                    CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);
                }
            }
            else
            {
                ArrayList slsrefs = new ArrayList(); slsrefs.Add(ddlTemsilciler.SelectedValue);
                CariHesaplar.GetObjectsBySLSREFs(ddlCariHesaplar.Items, slsrefs);
            }

            dlOdemeler.DataSource = null;
            dlOdemeler.DataBind();
            lblOdemeKacinci.Text = "0"; lblOdemeSayisi.Text = "0";

            lblSiparisYok.Visible = true;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOdemelerBos();
            lblOdemeKacinci.Text = "0"; lblOdemeSayisi.Text = "0";

            if (ddlCariHesaplar.SelectedValue == "1") // tümü 
            {
                GetOdemeCount();
                GetOdemeler(0, (int)Session["OdemelerSayfaBasiGosterim"]);
            }
            else if (ddlCariHesaplar.SelectedValue != "0" && ddlCariHesaplar.SelectedValue != "1")
            {
                GetOdemeCountBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                GetOdemelerBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)),
                    0, (int)Session["OdemelerSayfaBasiGosterim"]);
            }
            else
            {
                Session["OdemeGetirilecekSMREF"] = null;
                GetOdemelerBos();
            }
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            int odemeid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("OdemeID"))
                    {
                        odemeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (odemeid != 0)
            {
                Session["downloadodemeid"] = odemeid;
                divOdemeKaydet.Visible = true;
            }

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divOdemeKaydet, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbOdemeKaydetKapat_Click(object sender, EventArgs e)
        {
            divOdemeKaydet.Visible = false;
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
            lblOdemeAyrintiSiparisNo.Text = odeme.intSiparisID != 0 ? odeme.intSiparisID.ToString() : "-";
            lblOdemeAyrintiKrediKart.Text = odeme.strMaskedPan;
            lblOdemeAyrintiTutar.Text = odeme.mnTutar.ToString("C3");
            lblOdemeAyrintiTarih.Text = odeme.dtOdemeZamani.ToString().Substring(0, 16);
            lblOdemeAyrintiAuth.Text = odeme.strAuthCode;
            lblOdemeAyrintiHostRef.Text = odeme.strHostRefNum;
            lblOdemeAyrintiTransID.Text = odeme.strTransId;

            Session["OdemeAyrintiYazdir"] = odeme;
            divOdemeAyrinti.Visible = true;
            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divOdemeAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbOdemeAyrintiKapat_Click(object sender, EventArgs e)
        {
            divOdemeAyrinti.Visible = false;
        }

        protected void ibOdemeAyrintiYazdir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || 
                ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yönetici ise
            {
                if (ddlCariHesaplar.SelectedIndex > 1)
                    divOdeme1.Visible = true;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                divOdeme1.Visible = true;
            }
        }

        protected void btnOdemeTutarDevam_Click(object sender, EventArgs e)
        {
            Session["OdemeSiparisNo"] = null; // null olmalı ki oid boş gönderilsin
            Session["OdemeTutari"] = Convert.ToDecimal(txtOdemeTutar.Text.Trim());



            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
            {
                Session["OdemeGMREF"] = ((Musteriler)Session["Musteri"]).intGMREF;

                divOdeme.Visible = true;
                divOdeme1.Visible = false;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || 
                      ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yönetici ise
            {
                if (ddlCariHesaplar.SelectedIndex > 1)
                {
                    Session["OdemeGMREF"] = Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3));

                    divOdeme.Visible = true;
                    divOdeme1.Visible = false;
                }
            }
        }

        protected void lbOdemeVazgec1_Click(object sender, EventArgs e)
        {
            divOdeme1.Visible = false;
        }

        protected void lbOdemeVazgec_Click(object sender, EventArgs e)
        {
            divOdeme.Visible = false;
            Response.Redirect("odemeler.aspx", true);
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblOdemeKacinci.Text) - (int)Session["OdemelerSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["OdemelerSayfaBasiGosterim"] < baslangic)
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    {
                        GetOdemelerByMusteriID(baslangic - (int)Session["OdemelerSayfaBasiGosterim"], (int)Session["OdemelerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (ddlCariHesaplar.SelectedValue == "1") // tümü seçilmişse
                            GetOdemeler(baslangic - (int)Session["OdemelerSayfaBasiGosterim"], (int)Session["OdemelerSayfaBasiGosterim"]);
                        else if (ddlCariHesaplar.SelectedValue != "0")
                            GetOdemelerBySMREF((int)Session["OdemeGetirilecekSMREF"], baslangic - (int)Session["OdemelerSayfaBasiGosterim"], (int)Session["OdemelerSayfaBasiGosterim"]);
                    }

                    lblOdemeKacinci.Text = baslangic.ToString();
                }
                else
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    {
                        GetOdemelerByMusteriID(0, (int)Session["OdemelerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (ddlCariHesaplar.SelectedValue == "1") // tümü seçilmişse
                            GetOdemeler(0, (int)Session["OdemelerSayfaBasiGosterim"]);
                        else if (ddlCariHesaplar.SelectedValue != "0")
                            GetOdemelerBySMREF((int)Session["OdemeGetirilecekSMREF"], 0, (int)Session["OdemelerSayfaBasiGosterim"]);
                    }

                    lblOdemeKacinci.Text = Session["OdemelerSayfaBasiGosterim"].ToString();
                }
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblOdemeKacinci.Text) + (int)Session["OdemelerSayfaBasiGosterim"];
            if (Convert.ToInt32(lblOdemeKacinci.Text) < Convert.ToInt32(lblOdemeSayisi.Text))
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                {
                    GetOdemelerByMusteriID(baslangic - (int)Session["OdemelerSayfaBasiGosterim"], (int)Session["OdemelerSayfaBasiGosterim"]);
                }
                else
                {
                    if (ddlCariHesaplar.SelectedValue == "1") // tümü seçilmişse
                        GetOdemeler(baslangic - (int)Session["OdemelerSayfaBasiGosterim"], (int)Session["OdemelerSayfaBasiGosterim"]);
                    else if (ddlCariHesaplar.SelectedValue != "0")
                        GetOdemelerBySMREF((int)Session["OdemeGetirilecekSMREF"], baslangic - (int)Session["OdemelerSayfaBasiGosterim"], (int)Session["OdemelerSayfaBasiGosterim"]);
                }

                if (baslangic > Convert.ToInt32(lblOdemeSayisi.Text))
                    lblOdemeKacinci.Text = lblOdemeSayisi.Text;
                else
                    lblOdemeKacinci.Text = baslangic.ToString();
            }
        }

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty)
                return;

            dlOdemeler.DataSource = null;
            dlOdemeler.DataBind();

            lblOdemeKacinci.Text = "0"; lblOdemeSayisi.Text = "0";

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
        }

        protected void btnCariHesapTemizle_Click(object sender, EventArgs e)
        {
            //txtCariHesapAra.Text = string.Empty;
            //ddlCariHesaplar.Items.Clear();
            //ddlCariHesaplar.SelectedIndex = -1;
            //GetSatisSefYoneticiHesaplar();
            //ddlCariHesaplar.SelectedIndex = 0;

            //dlOdemeler.DataSource = null;
            //dlOdemeler.DataBind();
        }

        protected void dlOdemeler_DataBound(object sender, EventArgs e)
        {
            lblSiparisYok.Visible = dlOdemeler.Items.Count == 0;
        }
    }
}