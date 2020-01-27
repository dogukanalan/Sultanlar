using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Data;

namespace Sultanlar.WebUI
{
    public partial class resim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uidO"] != null && Request.QueryString["uidO"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_o.png");
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }
            else if (Request.QueryString["uidO"] != null && Request.QueryString["uidO"] != string.Empty)
            {
                byte[] resim = Resimler.GetObjectOByResimID(Convert.ToInt32(Request.QueryString["uidO"]));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Request.QueryString["uidO"]));
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }



            else if (Request.QueryString["uidK"] != null && Request.QueryString["uidK"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_k.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_k.png");
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }
            else if (Request.QueryString["uidK"] != null && Request.QueryString["uidK"] != string.Empty)
            {
                byte[] resim = Resimler.GetObjectKByResimID(Convert.ToInt32(Request.QueryString["uidK"]));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Request.QueryString["uidK"]));
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }



            else if (Request.QueryString["uid"] != null && Request.QueryString["uid"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_o.png");
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }
            else if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != string.Empty)
            {
                byte[] resim = Resimler.GetObjectByResimID(Convert.ToInt32(Request.QueryString["uid"]));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Request.QueryString["uid"]));
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }



            else if (Request.QueryString["tid"] != null && Request.QueryString["tid"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/bos.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=bos.png");
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }
            else if (Request.QueryString["tid"] != null && Request.QueryString["tid"] != string.Empty)
            {
                byte[] resim = Resimler.GetObjectOByResimID(Convert.ToInt32(Request.QueryString["tid"]));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Request.QueryString["tid"]));
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }



            else if (Request.QueryString["itemref"] != null && Request.QueryString["itemref"] != string.Empty)
            {
                int resimid = UrunResim.GetResimIDByUrunID(Convert.ToInt32(Request.QueryString["itemref"]));
                byte[] resim = Resimler.GetObjectByResimID(resimid);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimid.ToString()));
                try
                {
                    Response.BinaryWrite(resim);
                }
                catch (Exception)
                {
                    resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                    Response.BinaryWrite(resim);
                }
                Response.Flush();
                Response.End();
            }



            else if (Request.QueryString["uid400"] != null && Request.QueryString["uid400"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_b.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_b.png");
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }
            else if (Request.QueryString["uid400"] != null && Request.QueryString["uid400"] != string.Empty)
            {
                byte[] resim = Resim.ResimOlustur400400(Resimler.GetObjectByResimID(Convert.ToInt32(Request.QueryString["uid400"])), true);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Request.QueryString["uid400"]));
                Response.BinaryWrite(resim);
                Response.Flush();
                Response.End();
            }



            else
            {
                Response.Redirect("default.aspx", true);
            }
        }
    }
}