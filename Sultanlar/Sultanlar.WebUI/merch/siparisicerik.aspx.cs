using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class siparisicerik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            siparisid.Value = Request.QueryString["siparisid"];
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<SiparislerDetay> SiparislerGetir(int siparisid)
        {
            List<SiparislerDetay> donendeger = new List<SiparislerDetay>();

            SiparislerDetay.GetObjectsBySiparisID(donendeger, siparisid, true);

            return donendeger;
        }
    }
}