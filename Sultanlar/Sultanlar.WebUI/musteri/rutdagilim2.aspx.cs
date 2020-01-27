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
    public partial class rutdagilim2 : System.Web.UI.Page
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
                ASPxGridView1.Columns[0].Width = 30;
                ASPxGridView1.Columns[1].Width = 150;
                ASPxGridView1.Columns[2].Width = 30;
                ASPxGridView1.Columns[3].Width = 50;
                ASPxGridView1.Columns[4].Width = 50;
                ASPxGridView1.Columns[5].Width = 50;
                ASPxGridView1.Columns[6].Width = 50;
                ASPxGridView1.Columns[7].Width = 50;
                ASPxGridView1.Columns[8].Width = 50;
                ASPxGridView1.Columns[9].Width = 50;
                ASPxGridView1.Columns[10].Width = 50;
                ASPxGridView1.Columns[11].Width = 50;
                ASPxGridView1.Columns[12].Width = 50;
                ASPxGridView1.Columns[13].Width = 50;
                ASPxGridView1.Columns[14].Width = 50;
                ASPxGridView1.Columns[15].Width = 50;
                ASPxGridView1.Columns[16].Width = 50;
                ASPxGridView1.Columns[17].Width = 50;
                ASPxGridView1.Columns[18].Width = 50;
                ASPxGridView1.Columns[19].Width = 50;
                ASPxGridView1.Columns[20].Width = 50;
                ASPxGridView1.Columns[21].Width = 50;
                ASPxGridView1.Columns[22].Width = 50;
                ASPxGridView1.Columns[23].Width = 50;
                ASPxGridView1.Columns[24].Width = 50;
                ASPxGridView1.Columns[25].Width = 50;
                ASPxGridView1.Columns[26].Width = 50;
                ASPxGridView1.Columns[27].Width = 50;
                ASPxGridView1.Columns[28].Width = 50;
                ASPxGridView1.Columns[29].Width = 50;
                ASPxGridView1.Columns[30].Width = 50;
                ASPxGridView1.Columns[31].Width = 80;
                ASPxGridView1.Columns[32].Width = 80;
                //foreach (GridViewDataColumn ctrl in ASPxGridView1.Columns)
                //{
                //    (ctrl as GridViewDataColumn).Settings.HeaderFilterMode = HeaderFilterMode.CheckedList;
                //    (ctrl as GridViewDataColumn).PropertiesEdit.DisplayFormatString = "N2";
                //}
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 200;
        }
    }
}