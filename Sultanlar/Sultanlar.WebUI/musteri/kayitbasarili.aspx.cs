using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.musteri
{
    public partial class kayitbasarili : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["KayitBasarili"] == null)
                Response.Redirect("kayit.html", true);
            else
                Session["KayitBasarili"] = null;
        }
    }
}