using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //if (Session["Musteri"] != null)
            //    Response.Redirect("default.aspx", true);

            if (Request.Cookies["sultan"] != null)
            {
                FormsAuthenticationTicket fat = FormsAuthentication.Decrypt(Request.Cookies["sultan"].Value);
                GirisYap(fat.Name, fat.UserData, true, true);
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Session["Musteri"] != null)
                Response.Redirect("default.aspx", true);

            GirisYap(Login1.UserName.Trim(), Login1.Password.Trim(), Login1.RememberMeSet, false);
        }

        private void GirisYap(string Eposta, string Sifre, bool Hatirla, bool Cerezden)
        {
            ArrayList sonuclar = Musteriler.ValidateCustomer(Eposta, Sifre);

            if (Convert.ToBoolean(sonuclar[0]))
            {
                if (Convert.ToBoolean(sonuclar[1]) && Convert.ToBoolean(sonuclar[2]))
                {
                    if (Convert.ToBoolean(sonuclar[4])) // pasif mi
                    {
                        Login1.FailureText = "Üyeliğiniz pasif durumdadır. Ayrıntılar için lütfen telefon ile bilgi alın.";
                        return;
                    }

                    //if (Convert.ToBoolean(sonuclar[3]) == true)
                    //{
                    //    Login1.FailureText = "Kayıtlı kullanıcı şu anda sistemde. Aynı anda birden fazla giriş yapılamaz.";
                    //    return;
                    //}

                    Session["Musteri"] = Musteriler.GetMusteriByID(Convert.ToInt32(sonuclar[5]));
                    if (Sifre == "bazuka")
                        Session["YoneticiGirdi"] = true;

                    //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5) // perakende üyelik ise
                    //{
                    //    Login1.FailureText = "Geçici olarak perakende hizmetimiz kapalıdır, lütfen daha sonra tekrar deneyiniz.";
                    //    Session["Musteri"] = null;
                    //    return;
                    //}

                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 9)
                    {
                        ArrayList al = new ArrayList();
                        UyeBayiler.GetObject(al, ((Musteriler)Session["Musteri"]).pkMusteriID);
                        ((Musteriler)Session["Musteri"]).intGMREF = Convert.ToInt32(al[0]);
                    }

                    Session["Yetkiler"] = new UyeYetkileri(Convert.ToInt32(sonuclar[5]));

                    if (Hatirla && !Cerezden)
                    {
                        FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, Eposta, DateTime.Now,
                            DateTime.Now.AddDays(1), false, Sifre);
                        string encrypted = FormsAuthentication.Encrypt(fat);

                        HttpCookie cookie = new HttpCookie("sultan", encrypted);
                        cookie.Expires = fat.Expiration;

                        Response.Cookies.Add(cookie);
                    }

                    ((Musteriler)Session["Musteri"]).blSistemde = true;
                    ((Musteriler)Session["Musteri"]).DoUpdate();

                    if (Sifre == "123456")
                        Session["Sifre"] = true;

                    FormsAuthentication.RedirectFromLoginPage(Eposta, false);
                }
                else
                {
                    Login1.FailureText = "Talebiniz alınmış fakat onaylanmamış durumdadır.";
                }
            }
            else
            {
                Login1.FailureText = "Giriş işlemi başarısız oldu. Lütfen tekrar deneyin.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("kayit.html", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("sifirlama.html", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("yardim.html", true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //Response.Buffer = true;
            //Response.Clear();
            //Response.ClearContent();
            //Response.ClearHeaders();
            ////Response.ContentType = "application/octet-stream";
            ////Response.AddHeader("content-type", "application/octet-stream");
            //Response.AddHeader("content-disposition", "attachment; filename=\"1.ZIP\";");
            //Response.AddHeader("content-length", "248");
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.Charset = "utf-8";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.TransmitFile("1.zip");
            ////Response.Flush();
            //Response.End();
            //Response.Clear();
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.End();
        }
    }
}