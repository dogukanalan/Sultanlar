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
            string donendeger = string.Empty;
            bool aktarildi = Siparis.SiparisOnayla(Convert.ToInt32(context.Request.QueryString["siparisid"]), Convert.ToInt32(context.Request.QueryString["sevkref"]), Convert.ToInt32(context.Request.QueryString["depoid"]), Convert.ToBoolean(context.Request.QueryString["bakiye"]), Musteriler.GetMusteriByID(Convert.ToInt32(context.Request.QueryString["musteriid"])), out donendeger);


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