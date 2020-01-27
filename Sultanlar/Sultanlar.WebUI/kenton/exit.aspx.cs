using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Sultanlar.WebUI.kenton
{
    public partial class exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Session["Kenton"] = null;

            Session.Abandon();
            FormsAuthentication.SignOut();

            Response.Redirect("giris.aspx?from=exit.aspx", true);
        }
    }
}