using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WCF
{
    public partial class matruska : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    e.Text = "%" + (((Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[1])) - Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0]))) / Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0]))) * 100).ToString("N2");
                }
            }
        }
    }
}