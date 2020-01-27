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
    public partial class rutlar : System.Web.UI.Page
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
                    //btnMap2.Visible = true;
                    btnMap5.Visible = true;
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
                int kolonsayisi = 0;
                foreach (GridViewDataColumn ctrl in ASPxGridView1.Columns)
                {
                    kolonsayisi++;
                    (ctrl as GridViewDataColumn).Settings.HeaderFilterMode = HeaderFilterMode.CheckedList;
                    if (kolonsayisi == 1 || kolonsayisi == 3 || kolonsayisi == 5 || kolonsayisi == 6 || kolonsayisi == 7 || kolonsayisi == 8)
                        (ctrl as GridViewDataColumn).Width = 70;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void btnMap2_Click(object sender, EventArgs e)
        {
            Response.Redirect("map2.aspx", true);
        }

        protected void btnMap5_Click(object sender, EventArgs e)
        {
            Response.Redirect("map5.aspx", true);
        }
    }
}