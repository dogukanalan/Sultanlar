using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using System.Data;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class anlasmalifiyatlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            ArrayList fiyattipler = new ArrayList();
            fiyattipler = ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler;
            int indexxx = 0;
            int findex = ddlFiyatTipleri.SelectedIndex;
            ddlFiyatTipleri.Items.Clear();
            for (int i = 0; i < fiyattipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(fiyattipler[i]);
                string fiyattipi = FiyatTipleri.GetObjectByID(fiyattipiid);

                if (fiyattipiid > 500)
                {
                    ddlFiyatTipleri.Items.Add(fiyattipi != "" ? fiyattipi : fiyattipiid.ToString());
                    ddlFiyatTipleri.Items[indexxx].Value = fiyattipiid.ToString();
                    indexxx++;
                }
            }

            ddlFiyatTipleri.SelectedIndex = findex;
            GetObjects(Convert.ToInt32(ddlFiyatTipleri.SelectedValue));
        }

        private void GetObjects(int fiyattipi)
        {
            DataTable dt = new DataTable();
            FiyatTipUrun.GetOlanlar(dt, fiyattipi);
            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();

            DataTable dt1 = new DataTable();
            FiyatTipUrun.GetOlmayanlar(dt1, fiyattipi);
            ASPxGridView2.DataSource = dt1;
            ASPxGridView2.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlFiyatTipleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetObjects(Convert.ToInt32(ddlFiyatTipleri.SelectedValue));
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            FiyatTipUrun.DoDelete(Convert.ToInt32(e.Values[0]), Convert.ToInt32(e.Values[1]));
            GetObjects(Convert.ToInt32(ddlFiyatTipleri.SelectedValue));
        }

        protected void ASPxGridView2_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            FiyatTipUrun ftu = new FiyatTipUrun(Convert.ToInt32(e.Values[0]), Convert.ToInt32(e.Values[1]));
            ftu.DoInsert();
            GetObjects(Convert.ToInt32(ddlFiyatTipleri.SelectedValue));
        }

        protected void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects(Convert.ToInt32(ddlFiyatTipleri.SelectedValue));
        }
    }
}