using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public partial class adresbankasi : System.Web.UI.Page
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
                ASPxGridView1.Columns[4].Visible = false;
                ASPxGridView1.Columns[ASPxGridView1.Columns.Count - 1].Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //Sultanlar.DatabaseObject.WebGenel.Sorgu(dt, "SELECT * FROM [zWeb-Musteri-Adres] WHERE [Sat.Kod] = " + ddlTemsilciler.SelectedValue + " ORDER BY [Şehir],[İlçe],[Adres ]");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    inputH.Value += dt.Rows[i]["Şehir"].ToString() + " " + dt.Rows[i]["İlçe"].ToString() + " " + dt.Rows[i]["Adres "].ToString() + "|||";
            //}
        }
    }
}