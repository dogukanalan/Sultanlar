using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.Class;

namespace Sultanlar.WebUI.kenton
{
    public partial class tarifler : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            uyeid.Value = Session["Kenton"] != null ? Sifreleme.Encrypt(((Uyeler)Session["Kenton"]).pkID.ToString()) : Sifreleme.Encrypt("0");

            if (Request.QueryString["a"] != null)
            {
                if (Request.QueryString["a"] == "benim")
                {
                    if (Session["Kenton"] == null)
                        Response.Redirect("giris.aspx?nereden=tarifler.aspx", true);

                    divTarifEkle.Visible = true;
                    actionA.Value = "benim";
                }
                else if (Request.QueryString["a"] == "fav")
                {
                    if (Session["Kenton"] == null)
                        Response.Redirect("giris.aspx?nereden=tarifler.aspx", true);

                    actionA.Value = "fav";
                }
                else if (Request.QueryString["a"] == "urun")
                {
                    actionA.Value = "urun";
                }
                else if (Request.QueryString["a"] == "kullanicilar")
                {
                    actionA.Value = "kul";
                }
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Tarifler> TariflerGetir(int sonid, int kactane, string action, string uyeid, string urunid, string aranan, int katid, string order)
        {
            List<Tarifler> donendeger = new List<Tarifler>();
            if (action == "")
                donendeger = Tarifler.GetObjects(sonid, kactane, aranan, katid, order);
            else if (action == "benim")
                donendeger = Tarifler.GetObjectsOwn(sonid, kactane, Convert.ToInt32(Sifreleme.Decrypt(uyeid)), aranan, order);
            else if (action == "fav")
                donendeger = Tarifler.GetObjectsFav(sonid, kactane, Convert.ToInt32(Sifreleme.Decrypt(uyeid)), aranan, order);
            else if (action == "urun")
                donendeger = Tarifler.GetObjectsByUrunID(sonid, kactane, Convert.ToInt32(urunid), aranan, order); // uye id aslinda urun id
            else if (action == "kul")
                donendeger = Tarifler.GetObjectsKul(sonid, kactane, aranan, katid, order);
            return donendeger;
        }
    }
}