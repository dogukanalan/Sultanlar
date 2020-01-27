using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.Class;

namespace Sultanlar.WebUI.kenton
{
    public partial class panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["eposta"] != null && Request.QueryString["sifre"] != null)
            {
                int uyeid = Uyeler.Validate(Request.QueryString["eposta"], Request.QueryString["sifre"]);
                if (uyeid > 0)
                    Session["Kenton"] = Uyeler.GetObject(uyeid);
                else
                    Response.Redirect("giris.aspx?hata=hata", true);
            }

            if (Session["Kenton"] == null)
                Response.Redirect("giris.aspx?nereden=panel.aspx", true);

            spanKullanici.InnerHtml = ((Uyeler)Session["Kenton"]).strAd + " " + ((Uyeler)Session["Kenton"]).strSoyad;
        }
    }
}