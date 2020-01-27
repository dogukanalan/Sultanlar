using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject.Kenton;

namespace Sultanlar.WebUI.kenton
{
    public partial class resim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int resimid = 0;

            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetExpires(DateTime.Now.AddDays(30));
            Response.Cache.SetMaxAge(new TimeSpan(30, 0, 0, 0));
            Response.AddHeader("Last-Modified", DateTime.Now.ToLongDateString());

            if (Request.QueryString["tarif"] != null && Request.QueryString["tarif"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["tarif"]);
                byte[] resim = Tarifler.GetResim(resimid);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["tarifU"] != null && Request.QueryString["tarifU"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["tarifU"]);
                byte[] resim = Tarifler.GetResimUrunler(resimid);
                if (resimid == 0)
                    resim = System.IO.File.ReadAllBytes(Server.MapPath("../musteri/img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["resim"] != null && Request.QueryString["resim"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["resim"]);
                byte[] resim = Resim.ResimOlustur400400(Resimler.GetObjectByResimID(resimid), true);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                Response.BinaryWrite(resim);
            }

            Response.Flush();
            Response.End();
        }
    }
}