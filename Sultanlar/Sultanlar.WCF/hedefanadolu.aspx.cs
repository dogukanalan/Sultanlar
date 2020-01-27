using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WCF
{
    public partial class hedefanadolu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["bolge"] == "anadolu")
                SqlDataSource1.SelectCommand = "SELECT MUSTERI,sum(HEDEF) AS HEDEF,sum(SATIŞ + BEKLEYEN) AS SATIS,CASE WHEN (sum(HEDEF)) > 0 THEN (sum(SATIŞ + BEKLEYEN)) / sum(HEDEF) ELSE 0 END AS ORAN FROM dbo.YeniSatisHedef2018_Anadolu() WHERE (AY = 0 OR AY = MONTH(getdate())) AND (BEKL_AY = 0 OR BEKL_AY = MONTH(getdate()) OR BEKL_AY = MONTH(getdate()) - 1 OR BEKL_AY = MONTH(getdate()) - 2) GROUP BY MUSTERI";
            else if (Request.QueryString["bolge"] == "avrupa")
                SqlDataSource1.SelectCommand = "SELECT MUSTERI,sum(HEDEF) AS HEDEF,sum(SATIŞ + BEKLEYEN) AS SATIS,CASE WHEN (sum(HEDEF)) > 0 THEN (sum(SATIŞ + BEKLEYEN)) / sum(HEDEF) ELSE 0 END AS ORAN FROM dbo.YeniSatisHedef2018_Avrupa() WHERE (AY = 0 OR AY = MONTH(getdate())) AND (BEKL_AY = 0 OR BEKL_AY = MONTH(getdate()) OR BEKL_AY = MONTH(getdate()) - 1 OR BEKL_AY = MONTH(getdate()) - 2) GROUP BY MUSTERI HAVING sum(HEDEF) > 0";
            else if (Request.QueryString["bolge"] == "bati")
                SqlDataSource1.SelectCommand = "SELECT MUSTERI,sum(HEDEF) AS HEDEF,sum(SATIŞ + BEKLEYEN) AS SATIS,CASE WHEN (sum(HEDEF)) > 0 THEN (sum(SATIŞ + BEKLEYEN)) / sum(HEDEF) ELSE 0 END AS ORAN FROM dbo.YeniSatisHedef2018_Bati() WHERE (AY = 0 OR AY = MONTH(getdate())) AND (BEKL_AY = 0 OR BEKL_AY = MONTH(getdate()) OR BEKL_AY = MONTH(getdate()) - 1 OR BEKL_AY = MONTH(getdate()) - 2) GROUP BY [MUSTERI] HAVING sum(HEDEF) > 0";
            else if (Request.QueryString["bolge"] == "dogu")
                SqlDataSource1.SelectCommand = "SELECT MUSTERI,sum(HEDEF) AS HEDEF,sum(SATIŞ + BEKLEYEN) AS SATIS,CASE WHEN (sum(HEDEF)) > 0 THEN (sum(SATIŞ + BEKLEYEN)) / sum(HEDEF) ELSE 0 END AS ORAN FROM dbo.YeniSatisHedef2018_Dogu() WHERE (AY = 0 OR AY = MONTH(getdate())) AND (BEKL_AY = 0 OR BEKL_AY = MONTH(getdate()) OR BEKL_AY = MONTH(getdate()) - 1 OR BEKL_AY = MONTH(getdate()) - 2) GROUP BY MUSTERI HAVING sum(HEDEF) > 0";
            else if (Request.QueryString["bolge"] == "guneydogu")
                SqlDataSource1.SelectCommand = "SELECT MUSTERI,sum(HEDEF) AS HEDEF,sum(SATIŞ + BEKLEYEN) AS SATIS,CASE WHEN (sum(HEDEF)) > 0 THEN (sum(SATIŞ + BEKLEYEN)) / sum(HEDEF) ELSE 0 END AS ORAN FROM dbo.YeniSatisHedef2018_Guneydogu() WHERE (AY = 0 OR AY = MONTH(getdate())) AND (BEKL_AY = 0 OR BEKL_AY = MONTH(getdate()) OR BEKL_AY = MONTH(getdate()) - 1 OR BEKL_AY = MONTH(getdate()) - 2) GROUP BY MUSTERI HAVING sum(HEDEF) > 0";
            else if (Request.QueryString["bolge"] == "ulusal")
                SqlDataSource1.SelectCommand = "SELECT MUSTERI,sum(HEDEF) AS HEDEF,sum(SATIŞ + BEKLEYEN) AS SATIS,CASE WHEN (sum(HEDEF)) > 0 THEN (sum(SATIŞ + BEKLEYEN)) / sum(HEDEF) ELSE 0 END AS ORAN FROM dbo.YeniSatisHedef2018_Ulusal() WHERE (AY = 0 OR AY = MONTH(getdate())) AND (BEKL_AY = 0 OR BEKL_AY = MONTH(getdate()) OR BEKL_AY = MONTH(getdate()) - 1 OR BEKL_AY = MONTH(getdate()) - 2) GROUP BY MUSTERI";

            DataBind();
        }

        protected void ASPxGridView1_SummaryDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewSummaryDisplayTextEventArgs e)
        {
            if (e.Text.StartsWith("Sum"))
            {
                e.Text = e.Text.Replace("Sum=", "");
            }
            else if (e.Text == "1")
            {
                if (ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0]).ToString() != "" && ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[2]).ToString() != "" && Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0])) != 0)
                {
                    e.Text = "%" + (Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[1])) / Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0])) * 100).ToString("N2");
                }
            }
        }
    }
}