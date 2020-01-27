using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class videolar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            uyeid.Value = Session["Kenton"] != null ? Sifreleme.Encrypt(((Uyeler)Session["Kenton"]).pkID.ToString()) : Sifreleme.Encrypt("0");
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Videolar> VideolarGetir(int sonid, int kactane, string aranan, string order)
        {
            return Videolar.GetObjects(sonid, kactane, aranan, order);
        }
    }
}