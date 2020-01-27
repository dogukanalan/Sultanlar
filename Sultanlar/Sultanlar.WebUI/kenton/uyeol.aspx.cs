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
    public partial class uyeol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Kenton"] != null)
                Response.Redirect("anasayfa.aspx", true);
        }

        [System.Web.Services.WebMethod()]
        public static string UyeOl(string isim, string soyisim, string email, string sifre, string dogum)
        {
            DateTime DOGUM = DateTime.Now;

            try
            {
                DOGUM = Convert.ToDateTime(dogum);
            }
            catch (Exception ex)
            {
                //return "dogumhata";
            }

            if (Uyeler.Exist(email))
                return "epostahata";

            Uyeler uye = new Uyeler(isim, soyisim, email, Sifreleme.Encrypt(sifre), DOGUM, DateTime.Now, false);
            uye.DoInsert();

            return Sifreleme.Encrypt(sifre);
        }
    }
}