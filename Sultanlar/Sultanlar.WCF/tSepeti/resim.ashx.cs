using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sultanlar.WCF.tSepeti
{
    /// <summary>
    /// Summary description for resim
    /// </summary>
    public class resim : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.ContentType = "image/png";
            context.Response.Charset = "";

            int resimid = 0;

            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetExpires(DateTime.Now.AddDays(30));
            context.Response.Cache.SetMaxAge(new TimeSpan(30, 0, 0, 0));
            context.Response.AddHeader("Last-Modified", DateTime.Now.ToLongDateString());

            if (context.Request.QueryString["tarif"] != null && context.Request.QueryString["tarif"] != string.Empty)
            {
                resimid = Convert.ToInt32(context.Request.QueryString["tarif"]);
                byte[] resim = Tarifler.GetResim(resimid);
                context.Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                context.Response.BinaryWrite(resim);
            }
            else if (context.Request.QueryString["tarifU"] != null && context.Request.QueryString["tarifU"] != string.Empty)
            {
                resimid = Convert.ToInt32(context.Request.QueryString["tarifU"]);
                byte[] resim = Tarifler.GetResimUrunler(resimid);
                if (resimid == 0)
                    resim = System.IO.File.ReadAllBytes("http://www.sultanlar.com.tr/musteri/img/resimyok_o.png");
                context.Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                context.Response.BinaryWrite(resim);
            }
            else if (context.Request.QueryString["resim"] != null && context.Request.QueryString["resim"] != string.Empty)
            {
                resimid = Convert.ToInt32(context.Request.QueryString["resim"]);
                byte[] resim = Resim.ResimOlustur400400(Resimler.GetObjectByResimID(resimid), true);
                context.Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                context.Response.BinaryWrite(resim);
            }

            context.Response.Flush();
            context.Response.End();
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