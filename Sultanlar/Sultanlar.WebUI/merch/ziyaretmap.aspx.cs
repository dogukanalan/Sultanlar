using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class ziyaretmap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                }
                else
                {
                    ddlTemsilciler.Items.Add(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad);
                    ddlTemsilciler.Items[0].Value = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                }

                txtDate.Text = DateTime.Now.ToShortDateString().Replace(".", "/");
            }

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT MAXZAMAN,MAX(COORD) AS COORD FROM (SELECT CONVERT(VARCHAR(5),max(ZAMAN),108) AS MAXZAMAN,[COORD] FROM [Web-SatisTemsilcileri-Log] WHERE COORD != '0,0' AND SLSREF = " + ddlTemsilciler.SelectedValue + " AND CONVERT(VARCHAR(10), ZAMAN, 103) = '" + txtDate.Text.Replace(".", "/") + "' GROUP BY [COORD]) AS TABLO1 GROUP BY MAXZAMAN ORDER BY MAXZAMAN");
            string input = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
                input += dt.Rows[i]["COORD"].ToString() + "," + dt.Rows[i]["MAXZAMAN"].ToString() + "," + dt.Rows[i]["MAXZAMAN"].ToString().Substring(0, 2) + "|||";
            inputH.Value = input;
        }
    }
}