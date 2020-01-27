using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Kenton;

namespace Sultanlar.WebUI.kenton
{
    public partial class tarifekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Kenton"] != null)
                uyeid.Value = ((Uyeler)Session["Kenton"]).pkID.ToString();
            else
                Response.Redirect("giris.aspx?nereden=tarifekle.aspx", true);
        }

        [System.Web.Services.WebMethod()]
        public static string TarifEkle(string imageData, string uyeid, string baslik, string malzemeler, string hazirlanis)
        {
            byte[] resim = Convert.FromBase64String(imageData);
            Tarifler tar = new Tarifler(Convert.ToInt32(uyeid), false, baslik, malzemeler.Replace("\n", "<br>"), hazirlanis.Replace("\n", "<br>"), resim, null, "", DateTime.Now);
            tar.DoInsert();

            Class.Eposta.EpostaGonder("mail.kenton.com.tr", "app@kenton.com.tr", "[8TAZgK[=fCB", "Tarif Sepeti", "ssahinduran@tibet.com.tr", 25, false, "Yeni bir tarif eklendi",
                    "Tarif sepeti uygulamasına yeni bir tarif eklendi. Ayrıntılar:<br><br>Ekleyen: " + tar.Uye.strAd + " " + tar.Uye.strSoyad + "<br>Tarif Başlığı: " + tar.strBaslik + "<br>Malzemeler:<br>" + tar.strMalzemeler + "<br>Hazırlanış:<br>" + tar.strHazirlanis);

            return tar.pkID.ToString();
        }
    }
}