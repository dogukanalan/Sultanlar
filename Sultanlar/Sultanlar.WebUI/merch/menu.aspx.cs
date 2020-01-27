using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.merch
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            aMusteri.Visible = ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 2;
        }

        [System.Web.Services.WebMethod()]
        public static void KonumEkle(string slsref, string coord, string yer, string sayfa)
        {
            string SLSREF = slsref;
            string ZAMAN = DateTime.Now.ToString();
            string COORD = coord;
            string YER = yer;
            string SAYFA = sayfa;
            WebGenel.Sorgu("INSERT INTO [Web-SatisTemsilcileri-Log] (SLSREF,ZAMAN,COORD,YER,SAYFA) VALUES (" +
                SLSREF + ",'" + ZAMAN + "','" + COORD + "','" + YER.Replace("'", "").Replace("\"", "").Replace("%", "") + "','" + SAYFA + "')");
        }
    }
}