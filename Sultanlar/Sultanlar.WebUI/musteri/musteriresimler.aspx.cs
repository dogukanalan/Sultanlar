using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.musteri
{
    public partial class musteriresimler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                if (((Musteriler)Session["Musteri"]).intSLSREF == 0) // yönetici ise
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                    ddlTemsilciler.SelectedIndex = 0;
                    WebGenel.Sorgu(dt, "SELECT DISTINCT [Şube] AS Musteri,Kod FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ddlTemsilciler.SelectedValue + " ORDER BY Musteri");
                }
                else
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    WebGenel.Sorgu(dt, "SELECT DISTINCT [Şube] AS Musteri,Kod FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + " ORDER BY Musteri");
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                    ddlMusteriler.Items.Add(new ListItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
                ddlMusteriler.SelectedIndex = 0;

                DataTable dt1 = new DataTable();
                int smref = ddlMusteriler.Items.Count > 0 ? Convert.ToInt32(ddlMusteriler.SelectedValue) : 0;
                RutResim.GetObjects(dt1, smref, 1);
                rp1.DataSource = dt1;
                rp1.DataBind();
                lblYok.Visible = dt1.Rows.Count == 0;
            }
        }

        private void GetMusteriler()
        {
            DataTable dt = new DataTable();
            if (((Musteriler)Session["Musteri"]).intSLSREF == 0) // yönetici ise
                WebGenel.Sorgu(dt, "SELECT DISTINCT" + (txtMusteriAra.Text.Trim() == "" ? " TOP 100" : "") + " [Şube] AS Musteri,Kod FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ddlTemsilciler.SelectedValue + " AND [Şube] LIKE '%" + txtMusteriAra.Text.Trim().Replace("'", "") + "%' ORDER BY Musteri");
            else
                WebGenel.Sorgu(dt, "SELECT DISTINCT" + (txtMusteriAra.Text.Trim() == "" ? " TOP 100" : "") + " [Şube] AS Musteri,Kod FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + " AND [Şube] LIKE '%" + txtMusteriAra.Text.Trim().Replace("'", "") + "%' ORDER BY Musteri");

            ddlMusteriler.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                ddlMusteriler.Items.Add(new ListItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
        }

        private void GetData()
        {
            DataTable dt1 = new DataTable();
            int smref = ddlMusteriler.Items.Count > 0 ? Convert.ToInt32(ddlMusteriler.SelectedValue) : 0;
            RutResim.GetObjects(dt1, smref, 1);
            rp1.DataSource = dt1;
            rp1.DataBind();
            lblYok.Visible = dt1.Rows.Count == 0;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void btnGetir_Changed(object sender, EventArgs e)
        {
            GetData();
        }

        protected void btnAra_Changed(object sender, EventArgs e)
        {
            GetMusteriler();
        }
    }
}