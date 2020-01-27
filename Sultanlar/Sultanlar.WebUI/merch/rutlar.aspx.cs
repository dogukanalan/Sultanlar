using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class rutlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                if (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);

                    if (Request.QueryString["slsref"] != null)
                    {
                        SqlDataSource1.SelectCommand = "SELECT DISTINCT MUSTERI AS [Müşteri],SUBE AS [Şube]" +
                            ",[TARIH] AS [Tarih],[GUN] AS [Gün] " +
                            "FROM [WEB_RUT_4_LISTE] " +
                            "INNER JOIN [Web-Musteri-1] ON [WEB_RUT_4_LISTE].MTIP = [Web-Musteri-1].TIP AND [WEB_RUT_4_LISTE].SMREF = [Web-Musteri-1].SMREF " +
                            "WHERE [WEB_RUT_4_LISTE].SLSREF = " + Request.QueryString["slsref"] + " AND [TARIH] BETWEEN DATEADD(day,-1,GETDATE()) AND DATEADD(week,4,GETDATE()) " +
                            "ORDER BY [Tarih],[Müşteri],[Şube]";
                        DataBind();

                        for (int i = 0; i < ddlTemsilciler.Items.Count; i++)
                        {
                            if (ddlTemsilciler.Items[i].Value == Request.QueryString["slsref"])
                            {
                                ddlTemsilciler.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strAd + " " + ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strSoyad, ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    ddlTemsilciler.Visible = false;
                }
            }
        }
    }
}