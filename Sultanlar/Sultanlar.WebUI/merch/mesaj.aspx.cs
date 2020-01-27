using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WebUI.merch
{
    public partial class mesaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            int MesajID = Convert.ToInt32(Request.QueryString["id"]);

            if (Request.QueryString["a"] == "goster")
            {
                GonderilenMesajlar.DoUpdateOkundu(MesajID, DateTime.Now);
                ArrayList al = GonderilenMesajlar.GetObject(MesajID);
                lblKonu.Text = al[0].ToString();
                lblIcerik.Text = al[1].ToString();
                lblZaman.Text = al[2].ToString();
                tableSil.Visible = false;
            }
            else if (Request.QueryString["a"] == "sil")
            {
                GonderilenMesajlar.DoDelete(MesajID, false);
                tableMesaj.Visible = false;
                tableSil.Visible = true;
            }
        }
    }
}