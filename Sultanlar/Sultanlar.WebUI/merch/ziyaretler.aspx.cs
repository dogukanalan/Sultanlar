using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class ziyaretler : System.Web.UI.Page
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

                    if (Request.QueryString["slsref"] != null && Request.QueryString["slsref"] != "0")
                    {
                        SqlDataSource1.SelectCommand = "SELECT RUT_ID_E,[RUT_ TIP],[SB_ACK] AS SUBE,[TARIH]" +
                            ",convert(char(5), [ZIY_BAS_TAR], 108) AS ZIY_BAS,convert(char(5), [ZIY_BIT_TAR], 108) AS ZIY_BIT" +
                            ",FARK_KNM_ZIY AS FARK,RUT_KONUM,ZIY_KONUM " +
                            "FROM [Web_Rut_9_Ziyaretler] " +
                            "WHERE SAT_KOD = " + Request.QueryString["slsref"] + " ORDER BY [ZIY_BAS_TAR] DESC";
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
                    else
                    {
                        SqlDataSource1.SelectCommand = "SELECT RUT_ID_E,[RUT_ TIP],[SB_ACK] AS SUBE,[TARIH]" +
                            ",convert(char(5), [ZIY_BAS_TAR], 108) AS ZIY_BAS,convert(char(5), [ZIY_BIT_TAR], 108) AS ZIY_BIT" +
                            ",FARK_KNM_ZIY AS FARK,RUT_KONUM,ZIY_KONUM " +
                            "FROM [Web_Rut_9_Ziyaretler] " +
                            "ORDER BY [ZIY_BAS_TAR] DESC";
                        DataBind();
                        ddlTemsilciler.SelectedIndex = 0;
                    }
                }
                else
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    ddlTemsilciler.Visible = false;
                }
            }
        }
    }
}