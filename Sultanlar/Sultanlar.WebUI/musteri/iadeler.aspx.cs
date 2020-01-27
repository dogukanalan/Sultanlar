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
    public partial class iadeler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Redirect("default.aspx", true);

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise veya bayi yöneticisi ise
                Response.Redirect("yetkiyok.aspx", true);

            if (((Musteriler)Session["Musteri"]).blSicakSatis) // merch ise
                Response.Redirect("yetkiyok.aspx", true);

            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            

            if (!IsPostBack)
            {
                Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                Calendar2.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
                lblTarihSecim1.Text = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString()).ToShortDateString();
                lblTarihSecim2.Text = DateTime.Now.AddDays(1).ToShortDateString();

                Session["IadelerSayfaBasiGosterim"] = ((Musteriler)Session["Musteri"]).intSiparisSatirSayisi;

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                {
                    divHesapSecim.Visible = false;
                    GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["IadelerSayfaBasiGosterim"]);

                    if (Session["IadeTamamlaOnaylaBasildi"] != null)
                    {
                        divSevkYerleri.Visible = true;
                    }

                    return;
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise
                {
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false; // toplu işlemlerde bir tek bu açılışta enabled true
                }

                GetCariHesaplar();

                if (Session["IadeTamamlaBasildi"] != null)
                {
                    Session["IadeGetirilecekSMREF"] = Session["IadeTamamlaBasildi"];
                    Session["IadeTamamlaBasildi"] = null;
                }
                else if (Session["IadeTamamlaOnaylaBasildi"] != null)
                {
                    divSevkYerleri.Visible = true;

                    //if (((Musteriler)Session["Musteri"]).tintIlID != 34) // istanbul dışı müşteri ise
                    //{
                    //    Session["IadeTamamlaOnaylaBasildi"] = null;
                    //    return;
                    //}

                    Session["IadeTamamlaOnaylaBasildi"] = null;
                }
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(upSiparisler, typeof(string), "kucukbilgi", alert, false);

            inputTopluIslemGosterGizle.Value = "kapali";
        }

        private void GetCariHesaplar()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
            {
                GetSatisSefYoneticiHesaplar();
                //hlSatistaOnAdim.Visible = true;
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
                GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
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
                GetSiparislerBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["IadelerSayfaBasiGosterim"]);
            }
            else                                                                        // müşteri ise
            {
                ddlTemsilciler.Enabled = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 1;
                int gmref = ((Musteriler)Session["Musteri"]).intGMREF;
                Session["IadeGetirilecekSMREF"] = gmref;

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
                    GetSiparislerBySMREF(gmref, 0, (int)Session["IadelerSayfaBasiGosterim"]);
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
                GetSiparislerBySLSREF(((Musteriler)Session["Musteri"]).intSLSREF, 0, (int)Session["IadelerSayfaBasiGosterim"]);
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

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise tümü seçili gelsin, smrefs siz tümü geliyor hızlı
                {
                    ddlCariHesaplar.SelectedValue = "1";
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
            }
        }

        private void GetSiparislerBos()
        {
            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();
        }

        #region BySMREF
        private int GetSiparisCountBySMREF(int SMREF)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            int donendeger = Iadeler.GetIadeCountBySMREF(SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["IadelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["IadelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySMREF(int SMREF, int Baslangic, int Adet)
        {
            Session["IadeGetirilecekSMREF"] = SMREF;

            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            DataTable dt = new DataTable();
            Iadeler.GetObjectsBySMREF(dt, SMREF, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();
        }
        #endregion

        #region ByGMREF
        // parametre ile gelen GMREF fuzuli çünkü smref leri ddlcarihesapsubeler den alıyoruz
        private int GetSiparisCountByGMREF(int GMREF)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            //DataTable dt = new DataTable();
            //CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            int donendeger = Iadeler.GetIadeCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["IadelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["IadelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerByGMREF(int GMREF, int Baslangic, int Adet)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            //DataTable dt = new DataTable();
            //CariHesaplar.GetSubeler(dt, GMREF);
            ArrayList SMREFs = new ArrayList();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    SMREFs.Add(dt.Rows[i]["SMREF"].ToString());
            for (int i = 2; i < ddlCariHesaplarSubeler.Items.Count; i++) // seçiniz tümü hariç
                SMREFs.Add(Convert.ToInt32(ddlCariHesaplarSubeler.Items[i].Value.Substring(3)));

            DataTable dtSiparisler = new DataTable();
            Iadeler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region BySLSREF
        private int GetSiparisCountBySLSREF(int SLSREF)
        {
            int donendeger = 0;

            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            ArrayList SMREFs = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi veya yönetici ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);
            
            if (SMREFs.Count > 0)
                donendeger = Iadeler.GetIadeCountBySMREFs(SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["IadelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["IadelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerBySLSREF(int SLSREF, int Baslangic, int Adet)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            ArrayList SMREFs = new ArrayList();
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi veya yönetici ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                CariHesaplar.GetSMREFsBySLSREF(SMREFs, SLSREF);

            DataTable dtSiparisler = new DataTable();
            if (SMREFs.Count > 0)
                Iadeler.GetObjectsBySMREFs(dtSiparisler, SMREFs, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        #region ByMusteriID
        private int GetSiparisCountByMusteriID(int MusteriID)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            int donendeger = Iadeler.GetIadeCountByMusteriID(MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["IadelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["IadelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparislerByMusteriID(int MusteriID, int Baslangic, int Adet)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            DataTable dt = new DataTable();
            Iadeler.GetObjectsByMusteriID(dt, MusteriID, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            dlSiparisler.DataSource = dt;
            dlSiparisler.DataBind();
        }
        #endregion

        #region All
        private int GetSiparisCount()
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            int donendeger = 0;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise hepsi gelsin, smref lere göre getirmeye gerek yok
            {
                donendeger = Iadeler.GetIadeCount(Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);
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

                if (((ArrayList)Session["SatTemSMREFs"]).Count > 0)
                    donendeger = Iadeler.GetIadeCountBySMREFs((ArrayList)Session["SatTemSMREFs"], Calendar1.SelectedDate, Calendar2.SelectedDate, Onayli);
            }

            if (donendeger > 0)
                lblSiparisKacinci.Text = Session["IadelerSayfaBasiGosterim"].ToString();
            if (donendeger < (int)Session["IadelerSayfaBasiGosterim"])
                lblSiparisKacinci.Text = donendeger.ToString();

            lblSiparisSayisi.Text = donendeger.ToString();
            return donendeger;
        }
        private void GetSiparisler(int Baslangic, int Adet)
        {
            int Onayli = 0;
            if (rbKaydedilmisler.Checked)
                Onayli = 1;
            else if (rbOnayTalepEdilmisler.Checked)
                Onayli = 2;
            else if (rbOnayTaleptenGelenler.Checked)
                Onayli = 3;
            else if (rbOnaylanmislar.Checked)
                Onayli = 4;
            else if (rbReddedilmis.Checked)
                Onayli = 5;
            else if (rbDegisimler.Checked)
                Onayli = 6;

            DataTable dtSiparisler = new DataTable();

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise hepsi gelsin, smref lere göre getirmeye gerek yok
            {
                Iadeler.GetObjects(dtSiparisler, Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
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

                if (((ArrayList)Session["SatTemSMREFs"]).Count > 0)
                    Iadeler.GetObjectsBySMREFs(dtSiparisler, (ArrayList)Session["SatTemSMREFs"], Calendar1.SelectedDate, Calendar2.SelectedDate, Baslangic, Adet, Onayli);
            }

            dlSiparisler.DataSource = dtSiparisler;
            dlSiparisler.DataBind();
        }
        #endregion

        private void SiparisListesiniYenile()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);

                if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"] < 0)
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0,
                        (int)Session["IadelerSayfaBasiGosterim"]);
                else
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID,
                        Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"],
                        (int)Session["IadelerSayfaBasiGosterim"]);
            }
            else
            {
                if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                {
                    GetSiparisCount();

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"] < 0)
                        GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
                    else
                        GetSiparisler(Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"] < 0)
                        GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                    else
                        GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"] < 0)
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0,
                            (int)Session["IadelerSayfaBasiGosterim"]);
                    else
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)),
                            Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"],
                            (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else                                                                // şube seçilmişse
                {
                    GetSiparisCountBySMREF((int)Session["IadeGetirilecekSMREF"]);

                    if (Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"] < 0)
                        GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"], 0,
                            (int)Session["IadelerSayfaBasiGosterim"]);
                    else
                        GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"],
                            Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"],
                            (int)Session["IadelerSayfaBasiGosterim"]);
                }
            }

            cbSiparislerSecimTumu.Checked = false;
        }

        private void SiparisIncele(IadeListe ilist)
        {
            divSiparis.Visible = true;
            lblSiparisSonDurum.Visible = false;
            lbOnaylamayaDevam.Visible = false;
            lblSiparisDetaylari.Visible = true;

            Repeater1.DataSource = ilist;
            Repeater1.DataBind();
            lblSiparisToplam.Text = ilist.ToplamTutar < 0 ? "<i>İptal</i>" : ilist.ToplamTutar.ToString("C3");
        }

        private void GetSiparisFromDB(int IadeID)
        {
            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);

            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID);

            IadeListe ilist = new IadeListe(iade.intMusteriID, iade.SMREF, false);
            ilist._IadeID = IadeID;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long iadedetayid = Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]);
                int urunid = Convert.ToInt32(dt.Rows[i]["intUrunID"]);
                string urunadi = dt.Rows[i]["strUrunAdi"].ToString();
                int miktar = Convert.ToInt32(dt.Rows[i]["intMiktar"]);
                decimal oncekifiyat = Convert.ToDecimal(dt.Rows[i]["mnFiyat"]);
                decimal simdikifiyat = 0;

                simdikifiyat = oncekifiyat;

                ilist.Add(urunid, urunadi, miktar, simdikifiyat, iadedetayid);
            }

            SiparisIncele(ilist);
            string[] aciklamalar = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            lblSiparisAciklama.Text = "<strong>Açıklama:</strong> -";

            if (aciklamalar.Length > 2)
            {
                if (aciklamalar[1] != string.Empty)
                    lblSiparisAciklama.Text = lblSiparisAciklama.Text.Substring(0, lblSiparisAciklama.Text.Length - 1) + "<i>" + aciklamalar[1] + "</i>";
                //if (aciklamalar[2] != string.Empty)
                //    lblSiparisAciklama.Text += " - <i>" + aciklamalar[2] + "</i>";
            }
            else
            {
                if (aciklamalar[1] != string.Empty)
                    lblSiparisAciklama.Text = lblSiparisAciklama.Text.Substring(0, lblSiparisAciklama.Text.Length - 1) + "<i>" + aciklamalar[1] + "</i>";
            }
        }

        private void SiparisOnayla(int iadeid)
        {
            Iadeler iade = Iadeler.GetObjectsByIadeID(iadeid);

            iade.dtOnaylamaTarihi = DateTime.Now;
            iade.blAktarilmis = true;
            iade.strAciklama =
                iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0] + ";;;" +
                /*rblIadeNedenleri.SelectedItem.Text + "-" +*/ iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[1] + ";;;" +
                iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[2];
            if (iade.strAciklama.EndsWith(";;;;;;"))
                iade.strAciklama = iade.strAciklama.Substring(0, iade.strAciklama.LastIndexOf(";;;")) + /*rblIadeNedenleri.SelectedItem.Text + */";;;";
            iade.DoUpdate();

            IadeHareketleri.DoInsert(iade.pkIadeID, 1, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // fiyatlandırılmamışa geldi



            DataTable dtSiparistekiUrunler = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dtSiparistekiUrunler, iadeid);

            DataTable dtIsyeriOzelKod = new DataTable();
            IsyeriOzelKod.GetObjects(dtIsyeriOzelKod);

            for (int i = 0; i < dtIsyeriOzelKod.Rows.Count; i++) // sadece jwax için bölünüyor dolayısıyla 1 kere giriyor buraya
            {
                Iadeler yenisiparis =
                    new Iadeler(iade.intMusteriID, iade.SMREF, iade.dtOlusmaTarihi, 0, true,
                        DateTime.Now, iade.strAciklama);
                ArrayList yenisiparisurunleri = new ArrayList();

                for (int j = 0; j < dtSiparistekiUrunler.Rows.Count; j++)
                {
                    string isyeriozelkod = dtIsyeriOzelKod.Rows[i]["strOzelKod"].ToString();
                    string urunozelkod = Urunler.GetProductOzelKod(Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]), true);
                    if (urunozelkod.StartsWith(isyeriozelkod))
                    {
                        yenisiparisurunleri.Add(
                            new IadelerDetay(
                                0,
                                Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]),
                                dtSiparistekiUrunler.Rows[j]["strUrunAdi"].ToString(),
                                Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intMiktar"]),
                                Convert.ToDecimal(dtSiparistekiUrunler.Rows[j]["mnFiyat"])));

                        IadelerDetay siplerdet = IadelerDetay.GetObjectByIadelerDetayID(
                            Convert.ToInt64(dtSiparistekiUrunler.Rows[j]["pkIadeDetayID"]));
                        siplerdet.DoDelete();
                    }
                }

                if (yenisiparisurunleri.Count > 0)
                {
                    yenisiparis.DoInsert();

                    for (int j = 0; j < yenisiparisurunleri.Count; j++)
                    {
                        IadelerDetay siplerdet = (IadelerDetay)yenisiparisurunleri[j];
                        siplerdet.intIadeID = yenisiparis.pkIadeID;
                        siplerdet.DoInsert();
                    }
                }

                DataTable dtEski = new DataTable();
                IadelerDetay.GetObjectsByIadeID(dtEski, iade.pkIadeID);
                if (dtEski.Rows.Count == 0) // bölünüp eskisinde ürün kalmadıysa
                {
                    iade.DoDelete();
                }
            }
        }

        private bool SiparisOnaylaFiyatlandirilmisi(int iadeid)
        {
            bool donendeger = false;

            Iadeler iade = Iadeler.GetObjectsByIadeID(iadeid);

            if (CariHesaplar.GetGRPBySMREF(Iadeler.GetObjectsByIadeID(iadeid).SMREF) == "06") // eczane iadesi ise
            {
                donendeger = QuantumaYaz(iadeid, 8, 20);

                if (donendeger)
                {
                    iade.blAktarilmis = false;
                    iade.DoUpdate();

                    if (iade.strAciklama.EndsWith("-IADE MERKEZDEN GIRILDI"))
                        IadeHareketleri.DoInsert(iade.pkIadeID, 4, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // iade girilene geldi
                    else
                        IadeHareketleri.DoInsert(iade.pkIadeID, 3, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // sevk bekleyene geldi

                    DataTable dt = new DataTable();
                    IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                        IadeFiyatAdet.DoUpdate(Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]), true);
                }
                else
                {
                    IadelerQ.Delete(iadeid);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);

                if (Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[0]["intUrunID"].ToString()), true) == "211") // ilk ürün jwax ise
                {
                    donendeger = QuantumaYaz(iadeid, 6, 18);

                    if (donendeger)
                    {
                        iade.blAktarilmis = false;
                        iade.DoUpdate();

                        if (iade.strAciklama.EndsWith("-IADE MERKEZDEN GIRILDI"))
                            IadeHareketleri.DoInsert(iade.pkIadeID, 4, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // iade girilene geldi
                        else
                            IadeHareketleri.DoInsert(iade.pkIadeID, 3, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // sevk bekleyene geldi

                        DataTable dt1 = new DataTable();
                        IadelerDetay.GetObjectsByIadeID(dt1, iade.pkIadeID);
                        for (int i = 0; i < dt1.Rows.Count; i++)
                            IadeFiyatAdet.DoUpdate(Convert.ToInt64(dt1.Rows[i]["pkIadeDetayID"]), true);
                    }
                    else
                    {
                        IadelerQ.Delete(iadeid);
                    }
                }
                else
                {
                    donendeger = QuantumaYaz(iadeid, 0, 1);

                    if (donendeger)
                    {
                        iade.blAktarilmis = false;
                        iade.DoUpdate();

                        if (iade.strAciklama.EndsWith("-IADE MERKEZDEN GIRILDI"))
                            IadeHareketleri.DoInsert(iade.pkIadeID, 4, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // iade girilene geldi
                        else
                            IadeHareketleri.DoInsert(iade.pkIadeID, 3, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // sevk bekleyene geldi

                        DataTable dt1 = new DataTable();
                        IadelerDetay.GetObjectsByIadeID(dt1, iade.pkIadeID);
                        for (int i = 0; i < dt1.Rows.Count; i++)
                            IadeFiyatAdet.DoUpdate(Convert.ToInt64(dt1.Rows[i]["pkIadeDetayID"]), true);
                    }
                    else
                    {
                        IadelerQ.Delete(iadeid);
                    }
                }
            }

            return donendeger;
        }

        private bool QuantumaYaz(int IadeID, short IsyeriNo, short AmbarNo)
        {
            return false;

            Iadeler iade = Iadeler.GetObjectsByIadeID(IadeID);
            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID);

            int SLSREF = CariHesaplar.GetSLSREFBySMREF(iade.SMREF);
            Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(iade.intMusteriID);
            if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
                SLSREF = siparisiolusturanmusteri1.intSLSREF;

            SAPsendorder.ZwebSendSalesOrderService clOrder = new SAPsendorder.ZwebSendSalesOrderService();
            clOrder.Credentials = new System.Net.NetworkCredential("MISTIF", "123456");
            SAPsendorder.Zwebs010 header = new SAPsendorder.Zwebs010();

            header.Ctype = "SATIS"; //IADE
            header.Ketdat = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            header.Kunwe = iade.SMREF.ToString();
            header.Pernr = SLSREF.ToString();
            header.Pltyp = "2";
            header.Vbeln = "";
            header.Xblnr = iade.pkIadeID.ToString(); //WebGenel.DoUpdateSayac().ToString()

            SAPsendorder.Zwebs011[] line = new SAPsendorder.Zwebs011[dt.Rows.Count];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = new SAPsendorder.Zwebs011();
                line[i].Xblnr = iade.pkIadeID.ToString();
                line[i].Itmid = i.ToString();
                line[i].Matnr = dt.Rows[i]["intUrunID"].ToString();
                line[i].Meins = Urunler.GetProductBirimRef(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                line[i].MengeSpecified = true;
                line[i].Menge = Convert.ToDecimal(dt.Rows[i]["intMiktar"]);
            }

            string error = string.Empty;
            string donen = string.Empty;
            clOrder.ZwebSendSalesOrder(header, line, out donen);

            bool donendeger = error == string.Empty;



            if (donendeger)
            {
                IadelerQ.WriteQuantumNo(iade.pkIadeID, donen, "0");
                //iade.strAciklama += ";;;" + siparisno;
                //iade.DoUpdate();

                // lojistik:
                //AlinanMesajlar am = new AlinanMesajlar(
                //    ((Musteriler)Session["Musteri"]).pkMusteriID,
                //    1,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am.DoInsert();

                // iade kabul:
                //AlinanMesajlar am1 = new AlinanMesajlar(
                //    ((Musteriler)Session["Musteri"]).pkMusteriID,
                //    58,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am1.DoInsert();

                // iade fiyatlandırma:
                //AlinanMesajlar am2 = new AlinanMesajlar(
                //    ((Musteriler)Session["Musteri"]).pkMusteriID,
                //    59,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am2.DoInsert();

                // satış:
                //AlinanMesajlar am3 = new AlinanMesajlar(
                //    ((Musteriler)Session["Musteri"]).pkMusteriID,
                //    10,
                //    "Onaylanan İade Talebi - SAP Sip.No:" + donen + " Web İade No:" + iade.pkIadeID.ToString(),
                //    donen + " SAP sipariş nolu (Web iade no: " + iade.pkIadeID.ToString() + ") fiyatlandırılmış iade talebi, müşteri (veya satış temsilcisi) tarafından " + DateTime.Now.ToString() + " tarih ve saatinde onaylanmıştır. " + dt.Rows.Count.ToString() + " çeşit satırdan ve " + iade.mnToplamTutar.ToString("C2") + " toplamından oluşan iade siparişinin teslim alınması için lojistik departmanının görevlendirme yapması, iade kabul departmanının gelecek iadenin teslim alınma işlemini yapması önemle rica olunur. Sipariş detayı ilgili tarafından \"Sultanlar\" programı kullanılarak basılmalı ve görevlendirilecek ilgiliye teslim edilmelidir.\n\nNot: Bu mesaj sistem tarafından otomatik gönderilmiştir.".Replace("\n", "<br />"),
                //    DateTime.Now,
                //    DateTime.MinValue,
                //    false,
                //    false,
                //    false);
                //am3.DoInsert();
            }
            else
            {
                Hatalar.DoInsert("İade SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + error, "iadeler.aspx Quantumayaz()");
            }

            QuantumWebServisLog.DoInsert(donendeger, iade.pkIadeID, donen, ((Musteriler)Session["Musteri"]).pkMusteriID, "", "IADE");

            return donendeger;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // müşteri ise diğer siparişler gelmemesi için
            {
                if (CariHesaplar.AnaSubeMi(((Musteriler)Session["Musteri"]).intGMREF))
                {
                    ddlCariHesaplarSubeler.SelectedIndex = 0;

                    Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
                    Calendar2.SelectedDate = DateTime.Now;

                    Session["IadeGetirilecekSMREF"] = null;
                    lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
                    GetSiparislerBos();
                }
                else
                {
                    ddlCariHesaplarSubeler.Visible = false;

                    GetSiparisCountBySMREF(((Musteriler)Session["Musteri"]).intGMREF);
                    GetSiparislerBySMREF(((Musteriler)Session["Musteri"]).intGMREF, 0, (int)Session["IadelerSayfaBasiGosterim"]);
                }

                return;
            }

            if (ddlTemsilciler.SelectedValue == "1")
            {
                GetSiparisCount();
                GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);

                ddlCariHesaplar.Items.Clear();
                ddlCariHesaplar.Items.Add(new ListItem("Tümü", "1"));

                ddlCariHesaplarSubeler.Items.Clear();
                ddlCariHesaplarSubeler.Visible = false;

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

            Calendar1.SelectedDate = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString());
            Calendar2.SelectedDate = DateTime.Now;

            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();
            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";

            lblSiparisYok.Visible = true;

            if (ddlTemsilciler.SelectedValue == "0")
                Session["IadeGetirilecekSMREF"] = null;
        }

        protected void ddlCariHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSiparislerBos();
            ddlCariHesaplarSubeler.Items.Clear();
            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
            lblSiparisYok.Visible = true;

            if (ddlCariHesaplar.SelectedValue == "1") // tümü denmişse
            {
                ddlCariHesaplarSubeler.Visible = false;

                if (ddlTemsilciler.SelectedValue == "1")
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlTemsilciler.SelectedValue != "0")
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["IadelerSayfaBasiGosterim"]);
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

                    GetSiparisCountBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    GetSiparislerBySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)),
                        0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
            }
            else
            {
                ddlCariHesaplarSubeler.Visible = false;
                Session["IadeGetirilecekSMREF"] = null;
            }

            //rbSiparislerHepsi.Checked = true;
            //rbKaydedilmisler.Checked = false;
            //rbOnayTalepEdilmisler.Checked = false;
            //rbOnayTaleptenGelenler.Checked = false;
            //rbOnaylanmislar.Checked = false;
        }

        protected void ddlCariHesaplarSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCariHesaplarSubeler.SelectedValue == "1")
            {
                GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["IadelerSayfaBasiGosterim"]);
            }
            else if (ddlCariHesaplarSubeler.SelectedValue != "0")
            {
                GetSiparisCountBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)));
                GetSiparislerBySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)),
                    0, (int)Session["IadelerSayfaBasiGosterim"]);
            }
            else
            {
                Session["IadeGetirilecekSMREF"] = null;
                lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";
                lblSiparisYok.Visible = true;
                GetSiparislerBos();
            }

            //rbSiparislerHepsi.Checked = true;
            //rbKaydedilmisler.Checked = false;
            //rbOnayTalepEdilmisler.Checked = false;
            //rbOnayTaleptenGelenler.Checked = false;
            //rbOnaylanmislar.Checked = false;
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

        protected void lbTarihKapat_Click(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
                GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["IadelerSayfaBasiGosterim"]);
            }
            else
            {
                if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                {
                    if (ddlCariHesaplar.SelectedIndex > -1)
                    {
                        GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                    }
                }
                else
                {
                    if (Session["IadeGetirilecekSMREF"] != null)
                    {
                        GetSiparisCountBySMREF((int)Session["IadeGetirilecekSMREF"]);
                        GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"], 0, (int)Session["IadelerSayfaBasiGosterim"]);
                    }
                }
            }

            divTarih.Visible = false;
        }

        protected void rbSiparislerHepsi_Checked(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                GetSiparisCountByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID);
                GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["IadelerSayfaBasiGosterim"]);
            }
            else
            {
                if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                {
                    GetSiparisCount();
                    GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                {
                    GetSiparisCountBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue));
                    GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                {
                    GetSiparisCountByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else                                                                // şube seçilmişse
                {
                    if (Session["IadeGetirilecekSMREF"] != null)
                    {
                        GetSiparisCountBySMREF((int)Session["IadeGetirilecekSMREF"]);
                        GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"], 0, (int)Session["IadelerSayfaBasiGosterim"]);
                    }
                }
            }



            cbSiparislerSecimTumu.Checked = false;
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 1) // müşterilere iade yetkisini kaldırdık
            {
                if (rbKaydedilmisler.Checked)
                {
                    btnTumunuOnayla.Enabled = true;
                    btnTumunuSil.Enabled = true;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false;
                }
                else if (rbOnayTalepEdilmisler.Checked)
                {
                    btnTumunuOnayla.Enabled = false;
                    btnTumunuSil.Enabled = false;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false;
                }
                else if (rbOnayTaleptenGelenler.Checked)
                {
                    btnTumunuOnayla.Enabled = false;
                    btnTumunuSil.Enabled = false;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = true;
                }
                else if (rbOnaylanmislar.Checked)
                {
                    btnTumunuOnayla.Enabled = false;
                    btnTumunuSil.Enabled = false;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false;
                }
                else if (rbReddedilmis.Checked)
                {
                    btnTumunuOnayla.Enabled = false;
                    btnTumunuSil.Enabled = false;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false;
                }
                else if (rbDegisimler.Checked)
                {
                    btnTumunuOnayla.Enabled = false;
                    btnTumunuSil.Enabled = false;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false;
                }
                else if (rbSiparislerHepsi.Checked)
                {
                    btnTumunuOnayla.Enabled = false;
                    btnTumunuSil.Enabled = false;
                    btnTumunuFiyatlandirilmisOnayla.Enabled = false;
                }
            }
        }

        protected void ibIncele_Click(object sender, ImageClickEventArgs e)
        {
            int iadeid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            GetSiparisFromDB(iadeid);

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparis, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbOnaylamayaDevam_Click(object sender, EventArgs e)
        {
            divSiparis.Visible = false;
        }

        protected void lbSiparisKapat_Click(object sender, EventArgs e)
        {
            divSiparis.Visible = false;
        }

        protected void ibKopyala_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                    if (ctrl.ID.StartsWith("IadeID"))
                        Session["KopyalanacakIadeID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;

            #region Perakande Müşteri
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
            {
                int iadeid = 0;

                foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
                    if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                        if (ctrl.ID.StartsWith("SiparisID"))
                            iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);

                Iadeler Oncekiiade = Iadeler.GetObjectsByIadeID(iadeid);
                Iadeler Iade = new Iadeler(((Musteriler)Session["Musteri"]).pkMusteriID,
                        Oncekiiade.SMREF, DateTime.Now,
                        Oncekiiade.mnToplamTutar, false, DateTime.Now, Oncekiiade.strAciklama);
                Iade.DoInsert();

                DataTable dt = new DataTable();
                IadelerDetay.GetObjectsByIadeID(dt, iadeid);

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    IadelerDetay ilerdet = new IadelerDetay(Iade.pkIadeID, Convert.ToInt32(dt.Rows[j]["intUrunID"]),
                        dt.Rows[j]["strUrunAdi"].ToString(),
                        Convert.ToInt32(dt.Rows[j]["intMiktar"]), Convert.ToDecimal(dt.Rows[j]["mnFiyat"]));
                    ilerdet.DoInsert();
                }

                Response.Redirect("iadeler.aspx", true);
                return;
            }
            #endregion

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4)     // satış temsilcisi ise
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
                }
                else // şef ise SORUNLU çünkü value nin başına text in ilk 3 hanesi gelmiyor kopyalarken ilk 3 hane çıkarılıyor
                {
                    if (Session["SefSiparisKopyalaListe"] == null)
                    {
                        CariHesaplar.GetSMREFandSATTEMMUSTERISUBEByGMREFsSLSREFs(cblSiparisKopyalaSubeler.Items, ddlCariHesaplar.Items, altlar);
                        Session["SefSiparisKopyalaListe"] = cblSiparisKopyalaSubeler.Items;
                    }
                    else
                    {
                        cblSiparisKopyalaSubeler.Items.Clear();

                        for (int i = 0; i < ((ListItemCollection)Session["SefSiparisKopyalaListe"]).Count; i++)
                        {
                            cblSiparisKopyalaSubeler.Items.Add(((ListItemCollection)Session["SefSiparisKopyalaListe"])[i]);
                        }
                    }
                }
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yönetici ise SORUNLU çünkü value nin başına text in ilk 3 hanesi gelmiyor kopyalarken ilk 3 hane çıkarılıyor
            {
                CariHesaplar.GetSMREFandSATTEMMUSTERISUBE(cblSiparisKopyalaSubeler.Items);
            }
            else                                                                        // müşteri ise
            {
                int gmref = ((Musteriler)Session["Musteri"]).intGMREF;

                if (CariHesaplar.AnaSubeMi(gmref))
                {
                    DataTable dt = new DataTable();
                    CariHesaplar.GetSubeler(dt, gmref);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dt.Rows[i][4].ToString();
                        lst.Value = dt.Rows[i][4].ToString().Substring(0, 3) + dt.Rows[i][2].ToString();
                        cblSiparisKopyalaSubeler.Items.Add(lst);
                    }
                }
                else
                {
                    ListItem lst = new ListItem();
                    lst.Text = CariHesaplar.GetObjectByGMREF(gmref)[1].ToString();
                    lst.Value = gmref.ToString();
                    cblSiparisKopyalaSubeler.Items.Add(lst);
                }
            }

            divSiparisKopyala.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisKopyala, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbSiparisKopyalaTamamla_Click(object sender, EventArgs e)
        {
            int iadeid = Convert.ToInt32(Session["KopyalanacakIadeID"]);
            Session["KopyalanacakIadeID"] = null;

            Iadeler Oncekiiade = Iadeler.GetObjectsByIadeID(iadeid);

            for (int i = 0; i < cblSiparisKopyalaSubeler.Items.Count; i++)
            {
                if (cblSiparisKopyalaSubeler.Items[i].Selected)
                {
                    string[] aciklamalar = Oncekiiade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
                    string aciklama = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + aciklamalar[1] + ";;;" + aciklamalar[2];

                    Iadeler Iade = new Iadeler(((Musteriler)Session["Musteri"]).pkMusteriID,
                        Convert.ToInt32(cblSiparisKopyalaSubeler.Items[i].Value.Substring(3)), DateTime.Now,
                        0, false, DateTime.Now, aciklama);
                    Iade.DoInsert();

                    DataTable dt = new DataTable();
                    IadelerDetay.GetObjectsByIadeID(dt, iadeid);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        IadelerDetay ilerdet = new IadelerDetay(Iade.pkIadeID, Convert.ToInt32(dt.Rows[j]["intUrunID"]),
                            dt.Rows[j]["strUrunAdi"].ToString(), Convert.ToInt32(dt.Rows[j]["intMiktar"]), 0);
                        ilerdet.DoInsert();
                    }
                }
            }

            divSiparisKopyala.Visible = false;
            Response.Redirect("iadeler.aspx", true);
        }

        protected void lbSiparisKopyalaKapat_Click(object sender, EventArgs e)
        {
            divSiparisKopyala.Visible = false;
        }

        protected void ibDegistir_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        Session["IadeID"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                    else if (ctrl.ID.StartsWith("SMREF"))
                    {
                        Session["SMREF"] = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                    }
                }
            }

            if (Session["IadeID"] != null && Session["SMREF"] != null)
            {
                Response.Redirect("iade.aspx", true);
            }
        }

        protected void ibOnayla_Click(object sender, ImageClickEventArgs e)
        {
            int iadeid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        Session["OnaylanacakIadeID"] = iadeid;
                        break;
                    }
                }
            }

            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, iadeid);
            if (dt.Rows.Count == 0)
                return;

            divSevkYerleri.Visible = true;

            GetSiparisFromDB(iadeid);
            lblSiparisDetaylari.Visible = false;
            lblSiparisSonDurum.Visible = true;
            lbOnaylamayaDevam.Visible = true;
        }

        protected void lbOnaylaBitir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, (int)Session["OnaylanacakIadeID"]);

            if (dt.Rows.Count != 0)
            {
                if (rbOnaylaKabule.Checked)
                {
                    Iadeler iade = Iadeler.GetObjectsByIadeID((int)Session["OnaylanacakIadeID"]);
                    iade.strAciklama += ((Musteriler)Session["Musteri"]).pkMusteriID + "-IADE MERKEZDEN GIRILDI";
                    iade.DoUpdate();
                }

                SiparisOnayla((int)Session["OnaylanacakIadeID"]);

                Session["IadeTamamlaOnaylaBasildi"] = null;
                Session["OnaylanacakIadeID"] = null;
                divSevkYerleri.Visible = false;

                Response.Redirect("iadeler.aspx", true);
            }
        }

        protected void lbOnaylaKapat_Click(object sender, EventArgs e)
        {
            Session["IadeTamamlaOnaylaBasildi"] = null;
            Session["OnaylanacakIadeID"] = null;
            divSevkYerleri.Visible = false;
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            int iadeid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        Session["SilinecekIadeID"] = iadeid;
                        break;
                    }
                }
            }

            divSiparisSil.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divSiparisSil, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void ibKaydet_Click(object sender, ImageClickEventArgs e)
        {
            int iadeid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (iadeid != 0)
            {
                Session["downloadiadeid"] = iadeid;
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
            int iadeid = 0;

            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                        break;
                    }
                }
            }

            if (iadeid != 0)
            {
                Session["oncekiyazdiriadeid"] = Session["yazdiriadeid"];
                Session["yazdiriadeid"] = iadeid;
            }
        }

        protected void lbSiparisSilEvet_Click(object sender, EventArgs e)
        {
            Iadeler.DoDeleteWithIadelerDetays((int)Session["SilinecekIadeID"]);

            IadeHareketleri.DoInsert((int)Session["SilinecekIadeID"], 16, ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ""); // iade silindi

            Session["SilinecekIadeID"] = null;
            divSiparisSil.Visible = false;
            SiparisListesiniYenile();
        }

        protected void lbSiparisSilHayir_Click(object sender, EventArgs e)
        {
            Session["SilinecekIadeID"] = null;
            divSiparisSil.Visible = false;
        }

        protected void ibDurum_Click(object sender, ImageClickEventArgs e)
        {
            int iadeid = 0;
            
            foreach (Control ctrl in ((ImageButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("IadeID"))
                    {
                        iadeid = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
                    }
                }
            }

            Session["FiyatlandirilmisOnaylanacakIadeID"] = iadeid;
            divFiyatlandirilmisOnayla.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divFiyatlandirilmisOnayla, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void lbFiyatlandirilmisOnaylaBitir_Click(object sender, EventArgs e)
        {
            int iadeid = Convert.ToInt32(Session["FiyatlandirilmisOnaylanacakIadeID"]);

            if (SiparisOnaylaFiyatlandirilmisi(iadeid))
            {
                Session["FiyatlandirilmisOnaylanacakIadeID"] = null;
                Response.Redirect("iadeler.aspx", true);
            }
            else
            {
                Session["FiyatlandirilmisOnaylanacakIadeID"] = null;
                divFiyatlandirilmisOnayla.Visible = false;
                divSiparisOnaylanamadi.Visible = true;
            }
        }

        protected void lbFiyatlandirilmisOnaylaKapat_Click(object sender, EventArgs e)
        {
            Session["FiyatlandirilmisOnaylanacakIadeID"] = null;
            divFiyatlandirilmisOnayla.Visible = false;
        }

        protected void ibOnceki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) - (int)Session["IadelerSayfaBasiGosterim"];
            if (baslangic > 0)
            {
                if ((int)Session["IadelerSayfaBasiGosterim"] < baslangic)
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    {
                        GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                            GetSiparisler(baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                        else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                            GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                        else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                        else
                            GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"], baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                    }

                    lblSiparisKacinci.Text = baslangic.ToString();
                }
                else
                {
                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                    {
                        GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, 0, (int)Session["IadelerSayfaBasiGosterim"]);
                    }
                    else
                    {
                        if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                            GetSiparisler(0, (int)Session["IadelerSayfaBasiGosterim"]);
                        else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                            GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                        else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                            GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), 0, (int)Session["IadelerSayfaBasiGosterim"]);
                        else
                            GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"], 0, (int)Session["IadelerSayfaBasiGosterim"]);
                    }

                    lblSiparisKacinci.Text = Session["IadelerSayfaBasiGosterim"].ToString();
                }
            }
        }

        protected void ibSonraki_Click(object sender, ImageClickEventArgs e)
        {
            int baslangic = Convert.ToInt32(lblSiparisKacinci.Text) + (int)Session["IadelerSayfaBasiGosterim"];
            if (Convert.ToInt32(lblSiparisKacinci.Text) < Convert.ToInt32(lblSiparisSayisi.Text))
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende müşteri ise
                {
                    GetSiparislerByMusteriID(((Musteriler)Session["Musteri"]).pkMusteriID, baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                }
                else
                {
                    if (ddlTemsilciler.SelectedValue == "1") // tümü seçilmişse
                        GetSiparisler(baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                    else if (ddlCariHesaplar.SelectedValue == "1") // satış temsilcisi tümü seçilmişse
                        GetSiparislerBySLSREF(Convert.ToInt32(ddlTemsilciler.SelectedValue), baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                    else if (ddlCariHesaplarSubeler.SelectedValue == "1") // şubeler tümü seçilmişse
                        GetSiparislerByGMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)), baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                    else
                        GetSiparislerBySMREF((int)Session["IadeGetirilecekSMREF"], baslangic - (int)Session["IadelerSayfaBasiGosterim"], (int)Session["IadelerSayfaBasiGosterim"]);
                }

                if (baslangic > Convert.ToInt32(lblSiparisSayisi.Text))
                    lblSiparisKacinci.Text = lblSiparisSayisi.Text;
                else
                    lblSiparisKacinci.Text = baslangic.ToString();
            }
        }

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty)
                return;

            ddlCariHesaplarSubeler.Items.Clear();
            ddlCariHesaplarSubeler.Visible = false;
            dlSiparisler.DataSource = null;
            dlSiparisler.DataBind();

            lblSiparisKacinci.Text = "0"; lblSiparisSayisi.Text = "0";

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

        protected void lbSiparisOnaylanamadiKapat_Click(object sender, EventArgs e)
        {
            divSiparisOnaylanamadi.Visible = false;
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
                            int iadeid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);
                            DataTable dt = new DataTable();
                            IadelerDetay.GetObjectsByIadeID(dt, iadeid);

                            if (dt.Rows.Count != 0)
                                SiparisOnayla(iadeid);
                        }
                    }
                }
            }

            SiparisListesiniYenile();
            cbSiparislerSecimTumu.Checked = false;
        }

        protected void btnTumunuFiyatlandirilmisOnayla_Click(object sender, EventArgs e)
        {
            bool enazbirisionaylanamadi = false;

            foreach (Control ctrl in dlSiparisler.Controls)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                {
                    if (ctrl2 is CheckBox)
                    {
                        if (((CheckBox)ctrl2).Checked)
                        {
                            int iadeid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);
                            if (!SiparisOnaylaFiyatlandirilmisi(iadeid))
                            {
                                enazbirisionaylanamadi = true;
                            }
                        }
                    }
                }
            }

            SiparisListesiniYenile();
            cbSiparislerSecimTumu.Checked = false;

            if (enazbirisionaylanamadi)
                divSiparisOnaylanamadi.Visible = true;
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
                            int iadeid = Convert.ToInt32(((CheckBox)ctrl2).ToolTip);
                            Iadeler.DoDeleteWithIadelerDetays(iadeid);
                        }
                    }
                }
            }

            SiparisListesiniYenile();
            cbSiparislerSecimTumu.Checked = false;
        }

        protected void btnFaturaTakip_Click(object sender, EventArgs e)
        {
            if (ddlCariHesaplar.SelectedIndex > 1)
            {
                if (CariHesaplar.AnaSubeMi(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3))))
                {
                    if (ddlCariHesaplarSubeler.SelectedIndex > 1)
                    {
                        inputFaturaTakipSMREF.Value = ddlCariHesaplarSubeler.SelectedValue.Substring(3);
                        lblFaturaTakipMusteri.Text = CariHesaplar.GetSUBEbySMREF(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)));
                        FaturaTakipGetir(Convert.ToInt32(ddlCariHesaplarSubeler.SelectedValue.Substring(3)));
                        divFaturaTakip.Visible = true;
                    }
                }
                else
                {
                    inputFaturaTakipSMREF.Value = ddlCariHesaplar.SelectedValue.Substring(3);
                    lblFaturaTakipMusteri.Text = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    FaturaTakipGetir(Convert.ToInt32(ddlCariHesaplar.SelectedValue.Substring(3)));
                    divFaturaTakip.Visible = true;
                }
            }
        }

        private void FaturaTakipGetir(int SMREF)
        {
            DataTable dt = new DataTable();
            IadeFaturaTakip.GetObjects(dt, SMREF);
            rptFaturaTakip.DataSource = dt;
            rptFaturaTakip.DataBind();
        }

        protected void lbFaturaTakipKapat_Click(object sender, EventArgs e)
        {
            divFaturaTakip.Visible = false;
        }

        protected void btnFaturaTakipGir_Click(object sender, EventArgs e)
        {
            IadeFaturaTakip ift = new IadeFaturaTakip(
                ((Musteriler)Session["Musteri"]).pkMusteriID,
                Convert.ToInt32(inputFaturaTakipSMREF.Value),
                txtFaturaTakip.Text.Trim(),
                DateTime.Now,
                txtFaturaTakipAciklama.Text.Trim(),
                false,
                DateTime.Now,
                string.Empty,
                false,
                DateTime.Now,
                string.Empty);
            ift.DoInsert();
            FaturaTakipGetir(Convert.ToInt32(inputFaturaTakipSMREF.Value));
            txtFaturaTakip.Text = string.Empty;
            txtFaturaTakipAciklama.Text = string.Empty;
        }

        protected void lbFaturaTakipSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            IadeFaturaTakip ift = IadeFaturaTakip.GetObject(id);
            if (!ift.blKontrol && !ift.blPazarlama)
            {
                ift.DoDelete();
                FaturaTakipGetir(Convert.ToInt32(inputFaturaTakipSMREF.Value));
            }
            else
            {
                string alert = "<script type='text/javascript'>alert('Fatura işlem gördüğünden artık silinemez.');</script>";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "kucukbilgi", alert, false);
            }
        }
    }
}