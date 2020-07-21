using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Web.Routing;

namespace Sultanlar.WebUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Application["KisiSayisi"] = 0;
            //Application["Bilgiler"] = new ArrayList();

            //RouteTable.Routes.MapHubs();
            //RouteTable.Routes.MapConnection<musteri.ChatConnection>("sulchat", "");
            //RouteTable.Routes.MapConnection("Index", "Default.aspx", null, new ConnectionConfiguration());
            //RouteTable.Routes.MapPageRoute("Default", "Default", "~/default.aspx");

            //var app = (HttpApplication)sender;
            //if (app.Context.Request.Url.LocalPath.EndsWith("/"))
            //{
            //    app.Context.RewritePath(
            //             string.Concat(app.Context.Request.Url.LocalPath, "default.aspx"));
            //}

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["KisiSayisi"] = Convert.ToInt32(Application["KisiSayisi"]) + 1;
            //Session["IPadress"] = Request.UserHostAddress;
            //((ArrayList)Application["Bilgiler"]).Add(Session["IPadress"].ToString());
            //Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //string fullOrigionalpath = Request.Url.ToString();

            //if (fullOrigionalpath.Contains("/index.html"))
            //{
            //    Context.RewritePath("/default.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/kurumsal.html"))
            //{
            //    Context.RewritePath("/kurumsal.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/insankaynaklari.html"))
            //{
            //    Context.RewritePath("/insankaynaklari.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/isbasvuru.html"))
            //{
            //    Context.RewritePath("/isbasvuru.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/isbasvurutam.html"))
            //{
            //    Context.RewritePath("/isbasvurutam.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/iletisim.html"))
            //{
            //    Context.RewritePath("/iletisim.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/musteri/giris.html"))
            //{
            //    Context.RewritePath("/musteri/giris.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/musteri/kayit.html"))
            //{
            //    Context.RewritePath("/musteri/kayit.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/musteri/kayitbasarili.html"))
            //{
            //    Context.RewritePath("/musteri/kayitbasarili.aspx");
            //}
            //else if (fullOrigionalpath.Contains("/musteri/sifirlama.html"))
            //{
            //    Context.RewritePath("/musteri/sifirlama.aspx");
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //if (HttpContext.Current.User != null)
            //{
            //    if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    {
            //        if (HttpContext.Current.User.Identity is FormsIdentity)
            //        {
            //            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
            //            FormsAuthenticationTicket ticket = id.Ticket;
            //            string[] roles = new string[1];
            //            roles[0] = "admin";
            //            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
            //        }
            //    }
            //}
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Server.ClearError();
            //string ErrorMessage = Server.GetLastError().Message;
            //SmtpClient SC = new SmtpClient("mail.sultanlar.com.tr");
            //MailMessage MM = new MailMessage("mistif@sultanlar.com.tr", "mistif@sultanlar.com.tr");
            //MM.Subject = "Hata!";
            //MM.Body = "<b>sultanlar.com.tr</b> Hata Mesajı <br/><br/>" + ErrorMessage;
            //MM.IsBodyHtml = true;
            //SC.Credentials = new NetworkCredential("mistif@sultanlar.com.tr", "mehmeti");
            //SC.Send(MM);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Musteriler.SistemdeDegilYap(((Musteriler)Session["Musteri"]).pkMusteriID);
            //Musteriler.SonSiparisSifir(((Musteriler)Session["Musteri"]).pkMusteriID);

            //if (Request.Cookies["sulSatTemLog"] != null && Request.Cookies["sulSatTemLog1"] != null && Request.Cookies["sulSatTemLogD"] != null && Request.Cookies["sulSatTemLogS"] != null)
            //{
            //    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
            //    {
            //        if (Session["YoneticiGirdi"] == null) // eğer ben değilsem
            //        {
            //            string SLSREF = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
            //            string ZAMAN = DateTime.Parse(Request.Cookies["sulSatTemLogD"].Value).ToString();
            //            string COORD = Request.Cookies["sulSatTemLog1"].Value;
            //            string YER = Request.Cookies["sulSatTemLog"].Value;
            //            string SAYFA = Request.Cookies["sulSatTemLogS"].Value;

            //            WebGenel.Sorgu("INSERT INTO [Web-SatisTemsilcileri-Log] (SLSREF,ZAMAN,COORD,YER,SAYFA) VALUES (" +
            //                SLSREF + ",'" + ZAMAN + "','" + COORD + "','" + YER + "','" + SAYFA + "')");
            //        }
            //    }
            //}
            
            //Application.Lock();
            //Application["KisiSayisi"] = Convert.ToInt32(Application["KisiSayisi"]) - 1;
            //((ArrayList)Application["Bilgiler"]).Remove(Session["IPadress"].ToString());
            //Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}