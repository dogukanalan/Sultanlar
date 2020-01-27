using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class ziyaret1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (Session["Ziy"] != null)
                Response.Redirect("ziyaret.aspx", true);

            int SMREF = Convert.ToInt32(Request.QueryString["SMREF"]);
            int MTIP = Convert.ToInt32(Request.QueryString["MTIP"]);
            txtSube.Text = CariHesaplar.GetSUBEbySMREF(SMREF, MTIP);
            if (Rutlar.GetKonum(SMREF, MTIP) == string.Empty)
            {
                divKonumHata.Visible = true;
                aKonum.Visible = true;
                aKonum.HRef= "konumal.aspx?smref=" + Request.QueryString["SMREF"] + "&tip=" + Request.QueryString["MTIP"];
            }
        }

        protected void lbFarkliZiyaretBaslat_Click(object sender, EventArgs e)
        {
            Ziy ziyaret = new Ziy();
            int SMREF = Convert.ToInt32(Request.QueryString["SMREF"]);
            int MTIP = Convert.ToInt32(Request.QueryString["MTIP"]);

            int gmref = CariHesaplar.GetGMREFBySMREF(SMREF, MTIP);

            string BARKOD = Request.QueryString["barkod"] != null ? Request.QueryString["barkod"] : ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + gmref.ToString() + SMREF.ToString() + "." + DateTime.Now.ToString().Replace(" ", ".");
            DateTime ZIYGUN = Request.QueryString["ziygun"] != null ? Convert.ToDateTime(Request.QueryString["ziygun"]) : DateTime.MinValue;

            ziyaret.smref = SMREF;
            ziyaret.barkod = BARKOD;
            ziyaret.ziygun = ZIYGUN;
            ziyaret.mtip = MTIP;
            ziyaret.coords = txtCoords.Text;
            ziyaret.coords1 = txtCoords1.Text;

            Session["Ziy"] = ziyaret;
            Response.Redirect("ziyaret.aspx", true);
        }
    }
}