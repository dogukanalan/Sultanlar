using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class kutuphane : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
                Getir();
        }

        private void Getir()
        {
            DataTable dt = new DataTable();

            Kutuphane.GetObjects(dt, txtFarkliZiyaretSube.Text);
            lblDosyaYok.Visible = dt.Rows.Count == 0;

            rpZiyaretCariler.DataSource = dt;
            rpZiyaretCariler.DataBind();
        }

        protected void btnFarkliZiyaretAra_Click(object sender, EventArgs e)
        {
            Getir();
        }
    }
}