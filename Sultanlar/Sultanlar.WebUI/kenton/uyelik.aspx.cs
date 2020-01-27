using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.Class;

namespace Sultanlar.WebUI.kenton
{
    public partial class uyelik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Kenton"] == null)
                Response.Redirect("giris.aspx?nereden=uyelik.aspx", true);

            if (!IsPostBack)
            {
                Uyeler uye = (Uyeler)Session["Kenton"];

                isim.Value = uye.strAd;
                soyisim.Value = uye.strSoyad;
                dogum.Value = uye.dtDogum.ToShortDateString();
                email.Value = uye.strEposta;
                uyeid.Value = Sifreleme.Encrypt(uye.pkID.ToString());
            }
            else
            {
                if (uyeid.Value != "0")
                {
                    Uyeler uye = Uyeler.GetObject(Convert.ToInt32(Sifreleme.Decrypt(uyeid.Value)));
                    Session["Kenton"] = uye;
                }
            }
        }

        [System.Web.Services.WebMethod()]
        public static void UyeGuncelle(string id, string isim, string soyisim, string dogum, string sifre)
        {
            Uyeler uye = Uyeler.GetObject(Convert.ToInt32(Sifreleme.Decrypt(id)));
            uye.strAd = isim;
            uye.strSoyad = soyisim;
            uye.dtDogum = Convert.ToDateTime(dogum);
            uye.strSifre = sifre == "" ? uye.strSifre : Sifreleme.Encrypt(sifre);
            uye.DoUpdate();
        }
    }
}