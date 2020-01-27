using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject;
using System.Drawing;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class map2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).strEposta == "muhsinhut@tibet.com.tr")
                {
                    SatisTemsilcileri.GetObjectsFromCariHesaplar(cblSaticilar.Items);
                }
                else
                {
                    cblSaticilar.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    cblSaticilar.Items[0].Selected = true;
                }
            }

            GetNoktalar();

            if (cbBolgesel.Checked)
                GetBoyamaIlceler();
        }

        private void GetBoyamaIlceler()
        {
            string input = "{ \"type\": \"FeatureCollection\", \"features\": [ ";

            DataTable dt2 = new DataTable();
            WebGenel.Sorgu(dt2, "SELECT DISTINCT SUL_EKIP_BII.IL_KOD,SUL_EKIP_BII.ILC_KOD,ROTA_MAP FROM SUL_EKIP_BII WHERE ROTA_MAP IS NOT NULL AND SUL_EKIP_BII.ILC_KOD != 0 ORDER BY IL_KOD,ILC_KOD");
            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                string coords = string.Empty;
                DataTable dt1 = new DataTable();
                WebGenel.Sorgu(dt1, "SELECT COORD FROM SUL_EKIP_BII_COORD WHERE IL_KOD = " + dt2.Rows[j]["IL_KOD"].ToString() + " AND ILC_KOD = " + dt2.Rows[j]["ILC_KOD"].ToString() + " ORDER BY SIRA");
                for (int i = 0; i < dt1.Rows.Count; i++)
                    coords += "[" + dt1.Rows[i][0].ToString() + "],";
                Color c = Color.FromArgb((j + j) * 10000);
                input += "{ \"type\": \"Feature\", \"properties\": { \"fillColor\": \"#" + (dt2.Rows[j]["ROTA_MAP"].ToString() == string.Empty ? "FFFFFF" : dt2.Rows[j]["ROTA_MAP"].ToString()) + "\" }, \"geometry\": { \"type\": \"Polygon\", \"coordinates\": [[" + coords.Substring(0, coords.Length - 1) + "]] } },";
            }

            GetBoyamaIller(input);
        }

        private void GetBoyamaIller(string input)
        {
            DataTable dt3 = new DataTable();
            WebGenel.Sorgu(dt3, "SELECT DISTINCT IL_KOD,ROTA_MAP_IL FROM SUL_EKIP_BII ORDER BY IL_KOD");
            for (int j = 0; j < dt3.Rows.Count; j++)
            {
                string coords = string.Empty;
                DataTable dt1 = new DataTable();
                WebGenel.Sorgu(dt1, "SELECT COORD FROM SUL_EKIP_BII_COORD WHERE IL_KOD = " + dt3.Rows[j]["IL_KOD"].ToString() + " AND ILC_KOD = 0 ORDER BY SIRA");
                for (int i = 0; i < dt1.Rows.Count; i++)
                    coords += "[" + dt1.Rows[i][0].ToString() + "],";
                Color c = Color.FromArgb((j + j) * 10000);
                input += "{ \"type\": \"Feature\", \"properties\": { \"fillColor\": \"#" + (dt3.Rows[j]["ROTA_MAP_IL"].ToString() == string.Empty ? "FFFFFF" : dt3.Rows[j]["ROTA_MAP_IL"].ToString()) + "\" }, \"geometry\": { \"type\": \"Polygon\", \"coordinates\": [[" + coords.Substring(0, coords.Length - 1) + "]] } },";
            }

            inputB.Value = input.Substring(0, input.Length - 1) + " ] }";
        }

        private void GetNoktalar()
        {
            string where = "WHERE ";
            for (int i = 0; i < cblSaticilar.Items.Count; i++)
                if (cblSaticilar.Items[i].Selected)
                    where += "SLSREF = " + cblSaticilar.Items[i].Value + " OR ";
            where = where != "WHERE " ? where.Substring(0, where.Length - 4) : "WHERE SLSREF = 0";

            string aktifler = cbAktifler.Checked ? " WHERE ACTIVE = 0" : "";

            if (where != "WHERE SLSREF = 0")
            {
                DataTable dt = new DataTable();
                WebGenel.Sorgu(dt, "SELECT DISTINCT MUS.SLSREF,(SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = MUS.SLSREF) AS SATTEM,SUBE AS [Şube],[KONUM] AS [Konum] FROM [Web-Musteri-Acik] INNER JOIN (SELECT DISTINCT TIP,SLSREF,SMREF,SUBE FROM [Web-Musteri-1]" + aktifler + ") AS MUS ON [Web-Musteri-Acik].SMREF = MUS.SMREF AND [Web-Musteri-Acik].TIP = MUS.TIP  INNER JOIN [Web-SatisTemsilcileri] ON SLSMANREF = MUS.SLSREF " + where);
                string input = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string basharfler = dt.Rows[i]["Şube"].ToString()[0].ToString();
                    input += dt.Rows[i]["Konum"].ToString() + "," + dt.Rows[i]["Şube"].ToString() + "," + basharfler + "," + dt.Rows[i]["SLSREF"].ToString() + "," + dt.Rows[i]["SATTEM"].ToString() + "|||";
                }
                inputH.Value = input;
            }
        }
    }
}