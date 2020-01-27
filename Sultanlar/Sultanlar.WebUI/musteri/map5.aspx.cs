using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class map5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                txtDate.Text = DateTime.Now.ToShortDateString().Replace(".", "/");
            }

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT MAXZAMAN,MAX(COORD) AS COORD FROM (SELECT CONVERT(VARCHAR(5),max(ZAMAN),108) AS MAXZAMAN,[COORD] FROM [Web-SatisTemsilcileri-Log] WHERE COORD != '0,0' AND SLSREF = " + ddlTemsilciler.SelectedValue + " AND CONVERT(VARCHAR(10), ZAMAN, 103) = '" + txtDate.Text.Replace(".", "/") + "' GROUP BY [COORD]) AS TABLO1 GROUP BY MAXZAMAN ORDER BY MAXZAMAN");
            string input = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
                input += dt.Rows[i]["COORD"].ToString() + "," + dt.Rows[i]["MAXZAMAN"].ToString() + "," + dt.Rows[i]["MAXZAMAN"].ToString().Substring(0, 2) + "|||";
            inputH.Value = input;
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}