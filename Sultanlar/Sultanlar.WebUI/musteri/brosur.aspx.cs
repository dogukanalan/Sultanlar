using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.Web.Security;

namespace Sultanlar.WebUI.musteri
{
    public partial class brosur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            ArrayList resimler = new ArrayList();
            Resimler2.GetObjects(resimler, "");
            divIcerik.InnerHtml = "<ul id='g1'>";
            for (int i = 0; i < resimler.Count; i++)
                divIcerik.InnerHtml += "<li><img src='resim.aspx?bro=" + ((Resimler2)resimler[i]).pkID.ToString() + "' /></li>";
            divIcerik.InnerHtml += "</ul>";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }
    }
}