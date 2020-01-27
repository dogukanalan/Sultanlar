using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.musteri
{
    public partial class kartiade1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["KartIadeGecis"] = true;
            //Response.Redirect("kartaiade.aspx?tutar=" + Request.QueryString["tutar"] + "&sipno=" + Request.QueryString["sipno"], true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (TextBox1.Text.Trim() == "morgen")
            //{
            //    Session["KartIadeGecis"] = true;
            //    Response.Redirect("kartaiade.aspx?tutar=" + Request.QueryString["tutar"] + "&sipno=" + Request.QueryString["sipno"], true);
            //}
        }
    }
}