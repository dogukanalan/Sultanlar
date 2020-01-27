using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using Sultanlar.DatabaseObject;
using DevExpress.Web.ASPxGridView;

namespace Sultanlar.WebUI.musteri
{
    public partial class borcalacakrapor : System.Web.UI.Page
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
                
                hlSatisHedef.Visible = true;
                imgSatisHedef.Visible = true;
                hlStok.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2;
                imgStok.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2;

                ddlTemsilciler.SelectedIndex = 0;
                ASPxGridView1.DataBind();
                ASPxGridView1.Columns[0].Visible = false;
                foreach (GridViewDataColumn ctrl in ASPxGridView1.Columns)
                {
                    if ((ctrl as GridViewDataColumn).FieldName != "ORT_VD")
                    {
                        (ctrl as GridViewDataColumn).Settings.HeaderFilterMode = HeaderFilterMode.CheckedList;
                        (ctrl as GridViewDataColumn).PropertiesEdit.DisplayFormatString = "N2";
                    }
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
            DevExpress.Web.ASPxGridView.Export.ASPxGridViewExporter exportGrid = new DevExpress.Web.ASPxGridView.Export.ASPxGridViewExporter();
            exportGrid.GridViewID = "ASPxGridView1";
            exportGrid.ID = "exp1";
            this.Controls.Add(exportGrid);
            if (ASPxGridView1.Selection.Count == 0)
            {
                exportGrid.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;
            }
            exportGrid.WriteXlsxToResponse();
        }
    }
}