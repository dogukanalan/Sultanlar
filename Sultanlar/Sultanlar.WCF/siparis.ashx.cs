using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WCF
{
    /// <summary>
    /// Summary description for siparis
    /// </summary>
    public class siparis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string donendeger = "hata";
            bool aktarildi = false;

            if (Musteriler.GetMusteriByID(Convert.ToInt32(context.Request.QueryString["musteriid"])).blTaksitPlani) // harici bayi elemanı
            {
                Siparisler sip = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(context.Request.QueryString["siparisid"]));
                sip.dtOnaylamaTarihi = DateTime.Now;
                sip.blAktarilmis = true;
                sip.DoUpdate();
                aktarildi = true;
            }
            else
            {
                aktarildi = Siparis.SiparisOnayla(Convert.ToInt32(context.Request.QueryString["siparisid"]), Convert.ToInt32(context.Request.QueryString["sevkref"]), Convert.ToInt32(context.Request.QueryString["depoid"]), Convert.ToBoolean(context.Request.QueryString["bakiye"]), Musteriler.GetMusteriByID(Convert.ToInt32(context.Request.QueryString["musteriid"])), out donendeger);
            }

            if (aktarildi)
            {
                donendeger = string.Empty;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(donendeger);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}