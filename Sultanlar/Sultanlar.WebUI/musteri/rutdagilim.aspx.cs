using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using DevExpress.Web.ASPxGridView;
using System.Net;
using System.IO;
using System.Text;

namespace Sultanlar.WebUI.musteri
{
    public partial class rutdagilim : System.Web.UI.Page
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
                //ASPxGridView1.Columns[0].Visible = false;
                //foreach (GridViewDataColumn ctrl in ASPxGridView1.Columns)
                //{
                //    (ctrl as GridViewDataColumn).Settings.HeaderFilterMode = HeaderFilterMode.CheckedList;
                //    (ctrl as GridViewDataColumn).PropertiesEdit.DisplayFormatString = "N2";
                //}
            }


            //using (WebClient client = new WebClient())
            //{
            //    string htmlCode = client.DownloadString("http://localhost:24316/musteri/mesafehesapla.aspx?bir=40.895549,29.192963&iki=40.88801369618312,29.233258385753878");
            //    string deger = htmlCode.Substring(htmlCode.IndexOf("::::::") + 6, htmlCode.IndexOf(";;;;;;"));
            //}
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }
    }
}