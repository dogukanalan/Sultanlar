using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class siparisler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            musteriid.Value = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 ? "0" : ((Musteriler)Session["Musteri"]).pkMusteriID.ToString();
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Siparisler> SiparislerGetir(int sonid, int musteriid)
        {
            List<Siparisler> donendeger = new List<Siparisler>();

            List<Siparisler> List = new List<Siparisler>();
            if (musteriid == 0)
                Siparisler.GetObjects(List);
            else
                Siparisler.GetObjectsByMusteriID(List, musteriid, true);

            int sinir = 0;
            for (int i = sonid; i < List.Count; i++)
            {
                if (sinir < 50)
                {
                    List[i].strAciklama = List[i].dtOnaylamaTarihi.ToShortDateString();
                    donendeger.Add(List[i]);
                }
                sinir++;
            }

            return donendeger;
        }
    }
}