using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class sifre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (Uyeler.Exist(email.Value))
            {
                string sifre = Uyeler.GetPassword(email.Value);
                Eposta.EpostaGonder("mail.kenton.com.tr", "app@kenton.com.tr", "[8TAZgK[=fCB", "Tarif Sepeti", email.Value, 25, false, "Şifre Hatırlatma", 
                    "Merhaba değerli üyemiz,<br><br>Mevcut şifreniz: " + Sifreleme.Decrypt(sifre) + "<br>Şifrenizi değiştirmek için 'Üyelik Bilgilerim' ekranını kullanabilirsiniz.<br><br>Teşekkür ederiz.");

                nonhata.InnerHtml = "<a href='giris.aspx'>Şifreniz eposta adresinize gönderilmiştir. Giriş ekranına gitmek için tıklayınız.</a>";
                hata.InnerHtml = "";
            }
            else
            {
                nonhata.InnerHtml = "";
                hata.InnerHtml = "Eposta adresi sistemde bulunamadı. Lütfen doğru yazdığınızdan emin olunuz.";
            }
        }
    }
}