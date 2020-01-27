using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using System.Data;
using System.Drawing;

namespace Sultanlar.WebUI.musteri
{
    public partial class map3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT ROTA_MAP FROM SUL_EKIP_BII WHERE IL_KOD = 34 AND ILC_KOD != 12");
            string input = "{ \"type\": \"FeatureCollection\", \"features\": [ ";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Color c = Color.FromArgb((i + i) * 10000);
                input += "{ \"type\": \"Feature\", \"properties\": { \"fillColor\": \"#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2") + "\" }, \"geometry\": { \"type\": \"Polygon\", \"coordinates\": " + dt.Rows[i]["ROTA_MAP"].ToString() + "} },";
            }
            inputH.Value = input.Substring(0, input.Length - 1) + " ] }";
        }
    }
}