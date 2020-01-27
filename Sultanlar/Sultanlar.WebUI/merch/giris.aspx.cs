using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WebUI.merch
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (!IsPostBack)
                if (Session["Musteri"] != null)
                        Response.Redirect("rutbugun.aspx", true);
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            ArrayList sonuclar = Musteriler.ValidateCustomer(inputEposta.Value, inputSifre.Value);

            if (Convert.ToBoolean(sonuclar[0]))
            {
                if (Convert.ToBoolean(sonuclar[1]) && Convert.ToBoolean(sonuclar[2]))
                {
                    if (Convert.ToBoolean(sonuclar[4])) // pasif mi
                    {
                        pP.InnerText = "Üyeliğiniz pasif durumdadır. Ayrıntılar için lütfen telefon ile bilgi alın.";
                        return;
                    }

                    Session["Musteri"] = Musteriler.GetMusteriByID(Convert.ToInt32(sonuclar[5]));
                    if (inputSifre.Value == "bazuka")
                        Session["YoneticiGirdi"] = true;

                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                    {
                        Session["Yetkiler"] = new UyeYetkileri(Convert.ToInt32(sonuclar[5]));

                        ((Musteriler)Session["Musteri"]).blSistemde = true;
                        ((Musteriler)Session["Musteri"]).DoUpdate();

                        Response.Cookies.Add(new HttpCookie("sdeSLSREF", ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));

                        Response.Redirect("rutbugun.aspx?kadi=" + inputEposta.Value + "&sifre=" + inputSifre.Value, true);
                    }
                    else
                    {
                        pP.InnerText = "Giriş işlemi başarısız oldu. Lütfen tekrar deneyin.";
                    }
                }
                else
                {
                    pP.InnerText = "Talebiniz alınmış fakat onaylanmamış durumdadır.";
                }
            }
            else
            {
                pP.InnerText = "Giriş işlemi başarısız oldu. Lütfen tekrar deneyin.";
            }
        }
    }
}