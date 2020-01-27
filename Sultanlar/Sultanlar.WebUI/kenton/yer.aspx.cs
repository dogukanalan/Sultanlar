using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class yer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod()]
        public static void YerEkle(string uyeid, string sayfa, string tarayici, string sayfaid)
        {
            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            Yerler.DoInsert(Convert.ToInt32(uyeid), sayfa, sayfaid, tarayici, ip);
        }
    }
}