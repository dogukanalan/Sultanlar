using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using DevExpress.Web.ASPxGridView;

namespace Sultanlar.WebUI.musteri
{
    public partial class satisraporozet3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                }
                else
                {
                    Response.Redirect("yetkiyok.aspx", true);
                }

                ddlTemsilciler.SelectedIndex = 0;
                ASPxGridView1.DataBind();
                ASPxGridView1.Columns[0].Visible = false;
                foreach (GridViewDataColumn ctrl in ASPxGridView1.Columns)
                {
                    (ctrl as GridViewDataColumn).Settings.HeaderFilterMode = HeaderFilterMode.CheckedList;
                    (ctrl as GridViewDataColumn).PropertiesEdit.DisplayFormatString = "N2";
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }
    }
}