using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class ucKampanyalar : System.Web.UI.UserControl
    {
        // iki sistemli çalışabilir, açıklama satırına dönüştürülenler harften seçme, harften seçmeli sistemde şu methodlara gerek yok:
        /* GetTedarikciler
         * GetKategoriler
         * GetObjects
         * rblTedarikciler_SelectedIndexChanged
         * rblKategoriler_SelectedIndexChanged
         * lbTedarikciKapat_Click
         * lbKategoriKapat_Click */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TedarikciKamp"] = "NOT NULL";
                Session["KategoriKamp"] = "NOT NULL";
                Session["ArananKamp"] = "";

                //Session["TedarikciHarf"] = "";
                //Session["KategoriHarf"] = "";

                lblSiparisID1.Text = ((SiparisListe)Session["Siparis"])._SiparisID.ToString();
            }

            ucKampanyaAyrinti1.UserControlButtonClicked += new EventHandler(ucKampanyaAyrinti1_UserControlButtonClicked);
        }

        void ucKampanyaAyrinti1_UserControlButtonClicked(object sender, EventArgs e)
        {
            divKampanyaAyrinti.Visible = false;
            SepetBilgisiGuncelle();
        }

        protected void Tedarikci_Click(object sender, EventArgs e)
        {
            lblTedarikciHarf.Text = ((Control)sender).ID.Substring(6, 1);

            GetTedarikciler(((Control)sender).ID.Substring(6, 1), Session["KategoriKamp"].ToString());

            divTedarikci.Visible = true;
            divTedarikciKategoriDis.Visible = true;

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '100' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divTedarikci, typeof(string), "scriptSayfayukaricikar", alert, false);

            //Session["TedarikciHarf"] = ((Control)sender).ID.Substring(6, 1);
            //lblTedarikciSecim.Text = ((Control)sender).ID.Substring(6, 1);
            //GetObjects2();
        }

        protected void Kategori_Click(object sender, EventArgs e)
        {
            lblKategoriHarf.Text = ((Control)sender).ID.Substring(6, 1);

            GetKategoriler(((Control)sender).ID.Substring(6, 1), Session["TedarikciKamp"].ToString());

            divKategori.Visible = true;
            divTedarikciKategoriDis.Visible = true;

            //Session["KategoriHarf"] = ((Control)sender).ID.Substring(6, 1);
            //lblKategoriSecim.Text = ((Control)sender).ID.Substring(6, 1);
            //GetObjects2();
        }

        private void GetTedarikciler(string harf, string kategoriid)
        {
            //Urunler.GetTedarikciler(harf, rblTedarikcilerKamp.Items);
            //Urunler.GetTedarikciler(harf, rblTedarikcilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi);

            //Kampanyalar.GetTedarikciler(harf, rblTedarikcilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
            //Kampanyalar.GetTedarikciler(harf, kategoriid, rblTedarikcilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
            Kampanyalar.GetTedarikciler2(harf, kategoriid, Session["ArananKamp"].ToString(), rblTedarikcilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
        }

        private void GetKategoriler(string harf, string tedarikciid)
        {
            //Urunler.GetKategoriler(harf, rblKategorilerKamp.Items);
            //Urunler.GetKategoriler(harf, rblKategorilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi);

            //Kampanyalar.GetKategoriler(harf, rblKategorilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
            //Kampanyalar.GetKategoriler(harf, tedarikciid, rblKategorilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
            Kampanyalar.GetKategoriler2(harf, tedarikciid, Session["ArananKamp"].ToString(), rblKategorilerKamp.Items, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
        }

        public void GetObjects()
        {
            TedarikciHarfler();
            KategoriHarfler();

            //if (Session["TedarikciKamp"] == "NOT NULL" && Session["KategoriKamp"] == "NOT NULL" && !cbKampanyaYeniUrunler.Checked
            //    && lblAnaUrunArama.Text == "-")
            //{
            //    dlListe.DataBind();
            //    return;
            //}

            string tedarikcioperator = "IS";
            string kategorioperator = "IS";
            if (Session["TedarikciKamp"] != "NOT NULL")
            {
                if (!Session["TedarikciKamp"].ToString().StartsWith("'"))
                    Session["TedarikciKamp"] = "'" + Session["TedarikciKamp"].ToString() + "'";
                tedarikcioperator = "=";
            }
            if (Session["KategoriKamp"] != "NOT NULL")
            {
                if (!Session["KategoriKamp"].ToString().StartsWith("'"))
                    Session["KategoriKamp"] = "'" + Session["KategoriKamp"].ToString() + "'";
                kategorioperator = "=";
            }


            DataTable dt = new DataTable();
            Kampanyalar.GetObjects(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi, Session["ArananKamp"].ToString(), 
                Session["TedarikciKamp"].ToString(), tedarikcioperator, Session["KategoriKamp"].ToString(), kategorioperator, 
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar, cbKampanyaYeniUrunler.Checked);
            dlListe.DataSource = dt;
            dlListe.DataBind();
        }

        //public void GetObjects2()
        //{
        //    if (Session["TedarikciHarf"] == "" && Session["KategoriHarf"] == "")
        //    {
        //        dlListe.DataBind();
        //        return;
        //    }

        //    DataTable dt = new DataTable();
        //    Kampanyalar.GetObjects2(dt, Session["TedarikciHarf"].ToString(), Session["KategoriHarf"].ToString(), 
        //        ((SiparisListe)Session["Siparis"]).FiyatTipi, 
        //        ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
        //    dlListe.DataSource = dt;
        //    dlListe.DataBind();
        //}

        public void GetObjectsByUrunID(int UrunID)
        {
            int FiyatTipi = ((SiparisListe)Session["Siparis"])._FiyatTipi;
            //ArrayList kamkartrefs = Urunler.GetProductKamKartRefs(UrunID, FiyatTipi);
            DataTable dt = new DataTable();
            Kampanyalar.GetObjectsByUrunID(dt, UrunID, FiyatTipi);
            dlListe.DataSource = dt;
            dlListe.DataBind();



            if (dt.Rows.Count == 1)
            {
                Session["KampanyaAyrinti"] = dt.Rows[0]["KAMKARTREF"].ToString();
                divKampanyaAyrinti.Visible = true;
                ucKampanyaAyrinti1.GetObject();

                string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
                ScriptManager.RegisterStartupScript(divKampanyaAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);
            }
        }

        protected void rblTedarikciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secim = rblTedarikcilerKamp.SelectedItem.Text;
            int parantezindex = secim.IndexOf("(");
            if (parantezindex > 0)
                secim = secim.Substring(0, parantezindex - 1);

            lblTedarikciSecim.Text = secim;
            Session["TedarikciKamp"] = rblTedarikcilerKamp.SelectedValue;

            divTedarikci.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblTedarikcilerKamp.Items.Clear();

            cbKampanyaYeniUrunler.Checked = false;

            GetObjects();
        }

        protected void rblKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secim = rblKategorilerKamp.SelectedItem.Text;
            int parantezindex = secim.IndexOf("(");
            if (parantezindex > 0)
                secim = secim.Substring(0, parantezindex - 1);

            lblKategoriSecim.Text = secim;
            Session["KategoriKamp"] = rblKategorilerKamp.SelectedValue;

            divKategori.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblKategorilerKamp.Items.Clear();

            cbKampanyaYeniUrunler.Checked = false;

            GetObjects();
        }

        protected void lbTedarikciKapat_Click(object sender, EventArgs e)
        {
            divTedarikci.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblTedarikcilerKamp.Items.Clear();
        }

        protected void lbKategoriKapat_Click(object sender, EventArgs e)
        {
            divKategori.Visible = false;
            divTedarikciKategoriDis.Visible = false;
            rblKategorilerKamp.Items.Clear();
        }

        protected void btnSipariseAktar_Click(object sender, EventArgs e)
        {
            UrunSecimTarama(true);
            SepetBilgisiGuncelle();
        }

        protected void btnAnaUrunArama_Click(object sender, EventArgs e)
        {
            Session["ArananKamp"] = txtAnaUrunArama.Text.Trim();
            lblAnaUrunArama.Text = txtAnaUrunArama.Text.Trim();
            cbKampanyaYeniUrunler.Checked = false;
            GetObjects();
        }

        protected void btnAnaUrunAramaTemizle_Click(object sender, EventArgs e)
        {
            Session["ArananKamp"] = "";
            lblAnaUrunArama.Text = "-";
            txtAnaUrunArama.Text = string.Empty;
            GetObjects();
        }

        private bool UrunSecimTarama(bool ekle)
        {
            bool miktargirilmis = false;

            for (int i = 0; i < dlListe.Controls.Count; i++) // her bir kampanya
            {
                Guid kamkartref = Guid.Empty;
                int miktar = 0;

                for (int j = 0; j < dlListe.Controls[i].Controls.Count; j++) // kampanya satırındaki kontroller
                {
                    if (dlListe.Controls[i].Controls[j] is System.Web.UI.HtmlControls.HtmlInputControl) // kamkartref
                    {
                        string tekst = ((System.Web.UI.HtmlControls.HtmlInputControl)dlListe.Controls[i].Controls[j]).Value;

                        if (kamkartref == Guid.Empty) // kampanya
                            kamkartref = Guid.Parse(tekst);
                    }
                    else if (dlListe.Controls[i].Controls[j] is TextBox) // miktar
                    {
                        if (((TextBox)dlListe.Controls[i].Controls[j]).Text.Trim() != string.Empty)
                        {
                            miktar = Convert.ToInt32(((TextBox)dlListe.Controls[i].Controls[j]).Text);
                            miktargirilmis = true;
                        }
                        else
                        {
                            miktar = 0;
                        }

                        if (ekle)
                            ((TextBox)dlListe.Controls[i].Controls[j]).Text = string.Empty;
                    }
                }

                if (ekle && miktar != 0)
                {
                    Kampanya kamp = new Kampanya(kamkartref, miktar);
                    kamp.DoInsert((SiparisListe)Session["Siparis"]);
                }
            }

            return miktargirilmis;
        }

        protected void btnTedarikciTemizle_Click(object sender, EventArgs e)
        {
            Session["TedarikciKamp"] = "NOT NULL";
            lblTedarikciSecim.Text = "-";
            GetObjects();

            //Session["TedarikciHarf"] = "";
            //lblTedarikciSecim.Text = "-";
            //GetObjects2();
        }

        protected void btnKategoriTemizle_Click(object sender, EventArgs e)
        {
            Session["KategoriKamp"] = "NOT NULL";
            lblKategoriSecim.Text = "-";
            GetObjects();

            //Session["KategoriHarf"] = "";
            //lblKategoriSecim.Text = "-";
            //GetObjects2();
        }

        protected void btnTedarikciKategoriTemizle_Click(object sender, EventArgs e)
        {
            Session["TedarikciKamp"] = "NOT NULL";
            lblTedarikciSecim.Text = "-";
            Session["KategoriKamp"] = "NOT NULL";
            lblKategoriSecim.Text = "-";
            Session["ArananKamp"] = "";
            lblAnaUrunArama.Text = "-";
            txtAnaUrunArama.Text = string.Empty;
            GetObjects();

            //Session["TedarikciHarf"] = "";
            //lblTedarikciSecim.Text = "-";
            //Session["KategoriHarf"] = "";
            //lblKategoriSecim.Text = "-";
            //GetObjects2();
        }

        public void SepetBilgisiGuncelle()
        {
            decimal toplamtutar = ((SiparisListe)Session["Siparis"]).ToplamTutar;
            lblToplamTutar1.Text = toplamtutar.ToString("C3");
            //if (toplamtutar > 0)
            //    ibSepetBuyut1.ImageUrl = "img/sepet-dolu.png";
            //else
            //    ibSepetBuyut1.ImageUrl = "img/sepet.png";
        }

        protected void ibSepetBuyut1_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void lbKampanyaAyrinti_Click(object sender, EventArgs e)
        {
            string kamkartref = string.Empty;

            foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            {
                if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
                {
                    if (ctrl.ID.StartsWith("KAMKARTREF"))
                    {
                        kamkartref = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
                        break;
                    }
                }
            }

            Session["KampanyaAyrinti"] = kamkartref;
            divKampanyaAyrinti.Visible = true;
            ucKampanyaAyrinti1.GetObject();

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(divKampanyaAyrinti, typeof(string), "scriptSayfayukaricikar", alert, false);
        }

        protected void btnKampanyaAyrintiKapat_Click(object sender, EventArgs e)
        {
            divKampanyaAyrinti.Visible = false;
            SepetBilgisiGuncelle();
        }

        protected void rbResimListeGorunumu_CheckedChanged(object sender, EventArgs e)
        {
            //int width = (rbListeGorunumu.Checked) ? 25 : 100;
            //int height = (rbListeGorunumu.Checked) ? 25 : 250;
            //string acikwidth = (rbListeGorunumu.Checked) ? "300px" : "200px";
            //string reswidth = (rbListeGorunumu.Checked) ? "50px" : "100px";

            //foreach (Control ctrl in dlListe.Controls) // datalist kontrolleri
            //{
            //    foreach (Control ctrl2 in ctrl.Controls) // 
            //    {
            //        if (ctrl2 is System.Web.UI.HtmlControls.HtmlTableCell && ctrl2.ID.StartsWith("tdAcik"))
            //        {
            //            ((System.Web.UI.HtmlControls.HtmlTableCell)ctrl2).Style["width"] = acikwidth;
            //        }
            //        else if (ctrl2 is System.Web.UI.HtmlControls.HtmlTableCell && ctrl2.ID.StartsWith("tdRes"))
            //        {
            //            ((System.Web.UI.HtmlControls.HtmlTableCell)ctrl2).Style["width"] = reswidth;

            //            foreach (Control ctrl3 in ctrl2.Controls)
            //            {
            //                if (ctrl3 is Image)
            //                {
            //                    ((Image)ctrl3).Width = width;
            //                    ((Image)ctrl3).Height = height;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void TedarikciHarfler()
        {
            string kategorioperator = "IS";
            if (Session["KategoriKamp"] != "NOT NULL")
            {
                if (!Session["KategoriKamp"].ToString().StartsWith("'"))
                    Session["KategoriKamp"] = "'" + Session["KategoriKamp"].ToString() + "'";
                kategorioperator = "=";
            }

            DataTable dt = new DataTable();

            Kampanyalar.GetTedarikciHangiHarfler(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi, Session["ArananKamp"].ToString(),
                Session["KategoriKamp"].ToString(), kategorioperator,
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);

            lbKamp2.Font.Bold = false; lbKampA2.Font.Bold = false; lbKampB2.Font.Bold = false; lbKampC2.Font.Bold = false; lbKampD2.Font.Bold = false; lbKampE2.Font.Bold = false; lbKampF2.Font.Bold = false; lbKampG2.Font.Bold = false; lbKampH2.Font.Bold = false; lbKampI2.Font.Bold = false; lbKampJ2.Font.Bold = false; lbKampK2.Font.Bold = false; lbKampL2.Font.Bold = false; lbKampM2.Font.Bold = false; lbKampN2.Font.Bold = false; lbKampO2.Font.Bold = false; lbKampP2.Font.Bold = false; lbKampR2.Font.Bold = false; lbKampS2.Font.Bold = false; lbKampT2.Font.Bold = false; lbKampU2.Font.Bold = false; lbKampV2.Font.Bold = false; lbKampY2.Font.Bold = false; lbKampZ2.Font.Bold = false;
            lbKamp2.Font.Size = 7; lbKampA2.Font.Size = 7; lbKampB2.Font.Size = 7; lbKampC2.Font.Size = 7; lbKampD2.Font.Size = 7; lbKampE2.Font.Size = 7; lbKampF2.Font.Size = 7; lbKampG2.Font.Size = 7; lbKampH2.Font.Size = 7; lbKampI2.Font.Size = 7; lbKampJ2.Font.Size = 7; lbKampK2.Font.Size = 7; lbKampL2.Font.Size = 7; lbKampM2.Font.Size = 7; lbKampN2.Font.Size = 7; lbKampO2.Font.Size = 7; lbKampP2.Font.Size = 7; lbKampR2.Font.Size = 7; lbKampS2.Font.Size = 7; lbKampT2.Font.Size = 7; lbKampU2.Font.Size = 7; lbKampV2.Font.Size = 7; lbKampY2.Font.Size = 7; lbKampZ2.Font.Size = 7;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "2")
                {
                    lbKamp2.Font.Bold = true;
                    lbKamp2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "A")
                {
                    lbKampA2.Font.Bold = true;
                    lbKampA2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "B")
                {
                    lbKampB2.Font.Bold = true;
                    lbKampB2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "C")
                {
                    lbKampC2.Font.Bold = true;
                    lbKampC2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ç")
                {
                    lbKampC2.Font.Bold = true;
                    lbKampC2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "D")
                {
                    lbKampD2.Font.Bold = true;
                    lbKampD2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "E")
                {
                    lbKampE2.Font.Bold = true;
                    lbKampE2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "F")
                {
                    lbKampF2.Font.Bold = true;
                    lbKampF2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "G")
                {
                    lbKampG2.Font.Bold = true;
                    lbKampG2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ğ")
                {
                    lbKampG2.Font.Bold = true;
                    lbKampG2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "H")
                {
                    lbKampH2.Font.Bold = true;
                    lbKampH2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "I")
                {
                    lbKampI2.Font.Bold = true;
                    lbKampI2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "İ")
                {
                    lbKampI2.Font.Bold = true;
                    lbKampI2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "J")
                {
                    lbKampJ2.Font.Bold = true;
                    lbKampJ2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "K")
                {
                    lbKampK2.Font.Bold = true;
                    lbKampK2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "L")
                {
                    lbKampL2.Font.Bold = true;
                    lbKampL2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "M")
                {
                    lbKampM2.Font.Bold = true;
                    lbKampM2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "N")
                {
                    lbKampN2.Font.Bold = true;
                    lbKampN2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "O")
                {
                    lbKampO2.Font.Bold = true;
                    lbKampO2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ö")
                {
                    lbKampO2.Font.Bold = true;
                    lbKampO2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "P")
                {
                    lbKampP2.Font.Bold = true;
                    lbKampP2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "R")
                {
                    lbKampR2.Font.Bold = true;
                    lbKampR2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "S")
                {
                    lbKampS2.Font.Bold = true;
                    lbKampS2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ş")
                {
                    lbKampS2.Font.Bold = true;
                    lbKampS2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "T")
                {
                    lbKampT2.Font.Bold = true;
                    lbKampT2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "U")
                {
                    lbKampU2.Font.Bold = true;
                    lbKampU2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ü")
                {
                    lbKampU2.Font.Bold = true;
                    lbKampU2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "V")
                {
                    lbKampV2.Font.Bold = true;
                    lbKampV2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Y")
                {
                    lbKampY2.Font.Bold = true;
                    lbKampY2.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Z")
                {
                    lbKampZ2.Font.Bold = true;
                    lbKampZ2.Font.Size = 10;
                }
            }
        }

        private void KategoriHarfler()
        {
            string tedarikcioperator = "IS";
            if (Session["TedarikciKamp"] != "NOT NULL")
            {
                if (!Session["TedarikciKamp"].ToString().StartsWith("'"))
                    Session["TedarikciKamp"] = "'" + Session["TedarikciKamp"].ToString() + "'";
                tedarikcioperator = "=";
            }

            DataTable dt = new DataTable();

            Kampanyalar.GetKategoriHangiHarfler(dt, ((SiparisListe)Session["Siparis"]).FiyatTipi, Session["ArananKamp"].ToString(), 
                Session["TedarikciKamp"].ToString(), tedarikcioperator, 
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);

            lbKamp0.Font.Bold = false; lbKampA.Font.Bold = false; lbKampB.Font.Bold = false; lbKampC.Font.Bold = false; lbKampD.Font.Bold = false; lbKampE.Font.Bold = false; lbKampF.Font.Bold = false; lbKampG.Font.Bold = false; lbKampH.Font.Bold = false; lbKampI.Font.Bold = false; lbKampJ.Font.Bold = false; lbKampK.Font.Bold = false; lbKampL.Font.Bold = false; lbKampM.Font.Bold = false; lbKampN.Font.Bold = false; lbKampO.Font.Bold = false; lbKampP.Font.Bold = false; lbKampR.Font.Bold = false; lbKampS.Font.Bold = false; lbKampT.Font.Bold = false; lbKampU.Font.Bold = false; lbKampV.Font.Bold = false; lbKampY.Font.Bold = false; lbKampZ.Font.Bold = false;
            lbKamp0.Font.Size = 7; lbKampA.Font.Size = 7; lbKampB.Font.Size = 7; lbKampC.Font.Size = 7; lbKampD.Font.Size = 7; lbKampE.Font.Size = 7; lbKampF.Font.Size = 7; lbKampG.Font.Size = 7; lbKampH.Font.Size = 7; lbKampI.Font.Size = 7; lbKampJ.Font.Size = 7; lbKampK.Font.Size = 7; lbKampL.Font.Size = 7; lbKampM.Font.Size = 7; lbKampN.Font.Size = 7; lbKampO.Font.Size = 7; lbKampP.Font.Size = 7; lbKampR.Font.Size = 7; lbKampS.Font.Size = 7; lbKampT.Font.Size = 7; lbKampU.Font.Size = 7; lbKampV.Font.Size = 7; lbKampY.Font.Size = 7; lbKampZ.Font.Size = 7;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "0")
                {
                    lbKamp0.Font.Bold = true;
                    lbKamp0.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "A")
                {
                    lbKampA.Font.Bold = true;
                    lbKampA.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "B")
                {
                    lbKampB.Font.Bold = true;
                    lbKampB.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "C")
                {
                    lbKampC.Font.Bold = true;
                    lbKampC.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ç")
                {
                    lbKampC.Font.Bold = true;
                    lbKampC.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "D")
                {
                    lbKampD.Font.Bold = true;
                    lbKampD.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "E")
                {
                    lbKampE.Font.Bold = true;
                    lbKampE.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "F")
                {
                    lbKampF.Font.Bold = true;
                    lbKampF.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "G")
                {
                    lbKampG.Font.Bold = true;
                    lbKampG.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ğ")
                {
                    lbKampG.Font.Bold = true;
                    lbKampG.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "H")
                {
                    lbKampH.Font.Bold = true;
                    lbKampH.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "I")
                {
                    lbKampI.Font.Bold = true;
                    lbKampI.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "İ")
                {
                    lbKampI.Font.Bold = true;
                    lbKampI.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "J")
                {
                    lbKampJ.Font.Bold = true;
                    lbKampJ.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "K")
                {
                    lbKampK.Font.Bold = true;
                    lbKampK.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "L")
                {
                    lbKampL.Font.Bold = true;
                    lbKampL.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "M")
                {
                    lbKampM.Font.Bold = true;
                    lbKampM.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "N")
                {
                    lbKampN.Font.Bold = true;
                    lbKampN.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "O")
                {
                    lbKampO.Font.Bold = true;
                    lbKampO.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ö")
                {
                    lbKampO.Font.Bold = true;
                    lbKampO.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "P")
                {
                    lbKampP.Font.Bold = true;
                    lbKampP.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "R")
                {
                    lbKampR.Font.Bold = true;
                    lbKampR.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "S")
                {
                    lbKampS.Font.Bold = true;
                    lbKampS.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ş")
                {
                    lbKampS.Font.Bold = true;
                    lbKampS.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "T")
                {
                    lbKampT.Font.Bold = true;
                    lbKampT.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "U")
                {
                    lbKampU.Font.Bold = true;
                    lbKampU.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Ü")
                {
                    lbKampU.Font.Bold = true;
                    lbKampU.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "V")
                {
                    lbKampV.Font.Bold = true;
                    lbKampV.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Y")
                {
                    lbKampY.Font.Bold = true;
                    lbKampY.Font.Size = 10;
                }
                else if (dt.Rows[i][0].ToString() == "Z")
                {
                    lbKampZ.Font.Bold = true;
                    lbKampZ.Font.Size = 10;
                }
            }
        }

        protected void ibKampanyaYeniUrunler_Click(object sender, ImageClickEventArgs e)
        {
            cbKampanyaYeniUrunler.Checked = !cbKampanyaYeniUrunler.Checked;
            GetObjects();
        }

        protected void cbKampanyaYeniUrunler_CheckedChanged(object sender, EventArgs e)
        {
            GetObjects();
        }

        protected void dlListe_DataBound(object sender, EventArgs e)
        {
            lblKampanyaYok.Visible = dlListe.Items.Count == 0;
        }
    }
}