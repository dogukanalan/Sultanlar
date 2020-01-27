using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["kac"] == "1")
            {
                string DosyaAdi = Request.QueryString["ad"] + "." + Request.QueryString["tur"];
                byte[] dosya = Kutuphane.GetResim(Convert.ToInt32(Request.QueryString["kutupid"]));
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
                Response.BinaryWrite(dosya);
                Response.Flush();
                Response.End();
            }
            else
            {
                string DosyaAdi = Request.QueryString["ad"] + "." + Request.QueryString["tur"];
                byte[] dosya = Kutuphane2.GetResim(Convert.ToInt32(Request.QueryString["kutupid"]));
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
                Response.BinaryWrite(dosya);
                Response.Flush();
                Response.End();
            }
        }
    }
}