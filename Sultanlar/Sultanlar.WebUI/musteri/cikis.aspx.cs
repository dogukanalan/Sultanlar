using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.musteri
{
    public partial class cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Request.Cookies["sultan"] != null)
            {
                HttpCookie cookie = new HttpCookie("sultan");
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
            }

            if (Session["Musteri"] != null)
            {
                ((Musteriler)Session["Musteri"]).intSonYarimSiparisID = 0;
                ((Musteriler)Session["Musteri"]).blSistemde = false;
                ((Musteriler)Session["Musteri"]).DoUpdate();

                SonYeriYaz();

                Response.Cookies.Remove("sdeSLSREF");
                Response.Cookies.Remove("EnSonKonum");

                Session["Musteri"] = null;
                Session["Yetkiler"] = null;
                Session["YoneticiGirdi"] = null;
                //Session.Clear();
                Session.Abandon();

                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        private void SonYeriYaz()
        {
            if (Request.Cookies["sulSatTemLog"] != null && Request.Cookies["sulSatTemLog1"] != null && Request.Cookies["sulSatTemLogD"] != null && Request.Cookies["sulSatTemLogS"] != null)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
                {
                    if (Session["YoneticiGirdi"] == null) // eğer ben değilsem
                    {
                        string SLSREF = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                        string ZAMAN = DateTime.Parse(Request.Cookies["sulSatTemLogD"].Value).ToString();
                        string COORD = Request.Cookies["sulSatTemLog1"].Value;
                        string YER = Request.Cookies["sulSatTemLog"].Value;
                        string SAYFA = Request.Cookies["sulSatTemLogS"].Value;

                        WebGenel.Sorgu("INSERT INTO [Web-SatisTemsilcileri-Log] (SLSREF,ZAMAN,COORD,YER,SAYFA) VALUES (" +
                            SLSREF + ",'" + ZAMAN + "','" + COORD + "','" + YER + "','" + SAYFA + "')");
                    }
                }
            }
        }
    }
}