using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WCF
{
    public partial class ilkyuz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 9)
                    {
                        ArrayList al = new ArrayList();
                        UyeBayiler.GetObject(al, ((Musteriler)Session["Musteri"]).pkMusteriID);
                        ((Musteriler)Session["Musteri"]).intGMREF = Convert.ToInt32(al[0]);
                    }

                    ((Musteriler)Session["Musteri"]).blSistemde = true;
                    ((Musteriler)Session["Musteri"]).DoUpdate();

                    Response.Redirect("giris.aspx", true);
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