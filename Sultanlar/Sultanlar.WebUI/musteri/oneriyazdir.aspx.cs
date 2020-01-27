using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class oneriyazdir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Siparis"] == null || Session["OneriSiparisiGMREFdir"] == null)
                Response.Redirect("default.aspx", true);

            lblSatTem.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
            lblTarih.Text = DateTime.Now.ToString();

            if ((bool)Session["OneriSiparisiGMREFdir"] == true)
            {
                lblMusteri.Text = CariHesaplar.GetMUSTERIbyGMREF(CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF));
                lblSube.Text = CariHesaplar.GetSUBEbySMREF(((SiparisListe)Session["Siparis"])._SMREF);

                DataTable dt = new DataTable();
                SatisRapor.GetProductsByGMREF(dt, 0, 30000, CariHesaplar.GetGMREFBySMREF(((SiparisListe)Session["Siparis"])._SMREF), ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                lblMusteri.Text = CariHesaplar.GetMUSTERIbyGMREF(((SiparisListe)Session["Siparis"])._SMREF);

                DataTable dt = new DataTable();
                SatisRapor.GetProductsBySMREF(dt, 0, 30000, ((SiparisListe)Session["Siparis"])._SMREF, ((SiparisListe)Session["Siparis"])._FiyatTipi, ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
    }
}