using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class konumoto2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Kaydet(Convert.ToInt32(Request.QueryString["smref"]), Convert.ToInt32(Request.QueryString["tip"]), Request.QueryString["adres"]);
        }

        protected void Kaydet(int SMREF, int TIP, string Adres)
        {
            //Rutlar.SetKonum(SMREF, TIP, Lat + "," + Lng);
            Rutlar.SetKonumAdres(SMREF, TIP, Adres);
        }
    }
}