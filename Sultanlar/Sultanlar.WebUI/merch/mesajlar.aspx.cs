using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.merch
{
    public partial class mesajlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                GetDepartmanlar();
                GetMesajlar();
            }
        }

        private void GetDepartmanlar()
        {
            Departmanlar.GetObject(RadioButtonList1.Items);
            RadioButtonList1.Items.Add(new ListItem("Hepsi", "0"));
            if (Request.QueryString["depid"] == null || Request.QueryString["depid"] == "0")
            {
                RadioButtonList1.SelectedValue = "0";
            }
            else
            {
                RadioButtonList1.SelectedValue = Request.QueryString["depid"];
            }
        }

        private void GetMesajlar()
        {
            DataTable dt = new DataTable();
            if (Request.QueryString["depid"] == null || Request.QueryString["depid"] == "0")
                GonderilenMesajlar.GetObjects(dt, ((Musteriler)Session["Musteri"]).pkMusteriID, 50);
            else
                GonderilenMesajlar.GetObjects(dt, ((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(Request.QueryString["depid"]), 50);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "pkMesajID" };
            GridView1.DataBind();
        }

        protected void RadioButtonList1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("mesajlar.aspx?depid=" + RadioButtonList1.SelectedValue, true);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GetMesajlar();
        }
    }
}