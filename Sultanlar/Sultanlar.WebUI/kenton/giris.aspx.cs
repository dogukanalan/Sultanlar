using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;

namespace Sultanlar.WebUI.kenton
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Kenton"] != null)
                Response.Redirect("anasayfa.aspx", true);
        }

        [System.Web.Services.WebMethod()]
        public static string[] Giris(string email, string sifre)
        {
            return new string[] { Uyeler.Validate(email, Sifreleme.Encrypt(sifre)).ToString(), Sifreleme.Encrypt(sifre) };
        }
    }
}