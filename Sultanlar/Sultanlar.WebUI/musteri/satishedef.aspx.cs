using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using Sultanlar.DatabaseObject;
using System.IO;
using DevExpress.Web.ASPxGridView;

namespace Sultanlar.WebUI.musteri
{
    public partial class satishedef : System.Web.UI.Page
    {
        string genelsorgu = "SELECT YEAR(GETDATE()) AS [YIL], " +
"MONTH(GETDATE()) AS[AY], " +
"[PERSONEL] AS SAT_TEM," +
"[PRIM_GR] AS PRIM_GRUBU," +
"sum([HEDEF]) AS HEDEF," +
"sum([KOLI]) AS KOLI_TOPLAM," +
"sum([BEKLEYEN]) AS BEKLEYEN_TOPLAM," +
"sum([KOLI] + [BEKLEYEN]) AS SATIŞ_BEKLEYEN_TOPLAM," +
"CASE sum([HEDEF]) WHEN 0 THEN 0 ELSE sum([KOLI]) / sum([HEDEF]) END AS SATISYUZDE," +
"CASE sum([HEDEF]) WHEN 0 THEN 0 ELSE(sum([KOLI]) + sum([BEKLEYEN])) / sum([HEDEF]) END AS SATISBEKLEYENYUZDE " +
"FROM (" +
"SELECT [SATIS_YIL]" +
",[SATIS_AY]" +
",[BEKLEYEN_YIL]" +
",[BEKLEYEN_AY]" +
",[HEDEF_YIL]" +
",[HEDEF_AY]" +
",[YETKILI]" +
",[SAT_KOD]" +
",[PERSONEL]" +
",[SAT_KOD2]" +
",[SIPARISCI]" +
",[MUS_KOD]" +
",[MUSTERI]" +
",[KATEGORI]" +
",[ALT_KATEGORI]" +
",[PRIM_GR]" +
",[GRUP]" +
",[BOLUM]" +
",[MALZEME]" +
",[NET]" +
",[KOLI]" +
",[BEKLEYEN]" +
",[HEDEF] " +
"FROM [dbo].[zzWeb-Satis] " +
"UNION ALL " +
"SELECT [SATIS_YIL]" +
",[SATIS_AY]" +
",[BEKLEYEN_YIL]" +
",[BEKLEYEN_AY]" +
",[HEDEF_YIL]" +
",[HEDEF_AY]" +
",[YETKILI]" +
",[SAT_KOD]" +
",[PERSONEL]" +
",[SAT_KOD2]" +
",[SIPARISCI]" +
",[MUS_KOD]" +
",[MUSTERI]" +
",[KATEGORI]" +
",[ALT_KATEGORI]" +
",[PRIM_GR]" +
",[GRUP]" +
",[BOLUM]" +
",[MALZEME]" +
",[NET]" +
",[KOLI]" +
",[BEKLEYEN]" +
",[HEDEF] " +
"FROM [dbo].[zzWeb-Bekleyen] " +
"UNION ALL " +
"SELECT [SATIS_YIL]" +
",[SATIS_AY]" +
",[BEKLEYEN_YIL]" +
",[BEKLEYEN_AY]" +
",[HEDEF_YIL]" +
",[HEDEF_AY]" +
",[YETKILI]" +
",[SAT_KOD]" +
",[PERSONEL]" +
",[SAT_KOD2]" +
",[SIPARISCI]" +
",[MUS_KOD]" +
",[MUSTERI]" +
",[KATEGORI]" +
",[ALT_KATEGORI]" +
",[PRIM_GR]" +
",[GRUP]" +
",[BOLUM]" +
",[MALZEME]" +
",[NET]" +
",[KOLI]" +
",[BEKLEYEN]" +
",[HEDEF] " +
"FROM [dbo].[zzWeb-Hedef]" +
") AS TABLO " +
"WHERE ([SATIS_YIL] = YEAR(GETDATE()) OR [SATIS_YIL] = 0)  AND ([BEKLEYEN_YIL] = YEAR(GETDATE()) OR [BEKLEYEN_YIL] = 0) AND ([HEDEF_YIL] = YEAR(GETDATE()) OR [HEDEF_YIL] = 0) " +
"AND ([SATIS_AY] = MONTH(GETDATE()) OR [SATIS_AY] = 0) " +
"AND ([HEDEF_AY] = MONTH(GETDATE()) OR [HEDEF_AY] = 0) " +
"AND ([BEKLEYEN_AY] = 0 OR [BEKLEYEN_AY] = MONTH(GETDATE()) OR [BEKLEYEN_AY] = MONTH(GETDATE()) - 1 OR [BEKLEYEN_AY] = MONTH(GETDATE()) - 2) " +
"GROUP BY [PERSONEL], [PRIM_GR]";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 1) // perakende müşteri veya müşteri ise
                    Response.Redirect("yetkiyok.aspx", true);

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    //SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [SAT TEM] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Personel-Web] WHERE YIL = " + DateTime.Now.Year.ToString();
                    SqlDataSource1.SelectCommand = genelsorgu;
                    SqlDataSource1.SelectParameters.RemoveAt(0);
                    //ddlBayiler.Visible = true;
                    //CariHesaplarTP.GetObjects(ddlBayiler.Items, 0, true, true);
                    //ddlBayiler.Items[0].Text = "Satıcılar";
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                {
                    SqlDataSource1.SelectParameters[0].Name = "SAT_KOD";
                    lblSatKod.Text = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                    //SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [SAT TEM] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Personel-Web] WHERE YIL = " + DateTime.Now.Year.ToString() + " AND [SAT KOD] = " + ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                }
                //else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
                //{
                //    ArrayList bayiler = new ArrayList();
                //    CariHesaplarTP.GetSMREFsBySLSREF(bayiler, ((Musteriler)Session["Musteri"]).intSLSREF, true);
                //    string bayiler1 = string.Empty;
                //    for (int i = 0; i < bayiler.Count; i++)
                //    {
                //        ddlBayiler.Items.Add(new ListItem(CariHesaplar.GetMUSTERIbyGMREF(Convert.ToInt32(bayiler[i])), bayiler[i].ToString()));
                //        bayiler1 += "[MUS KOD] = " + bayiler[i].ToString() + " OR ";
                //        lblBayiKod.Text = bayiler[i].ToString();
                //    }
                //    bayiler1 = "(" + bayiler1.Substring(0, bayiler1.Length - 4) + ") AND ";

                //    SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [MUSTERI] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Bayi] WHERE " + bayiler1 + "YIL = " + DateTime.Now.Year.ToString();
                //    //SqlDataSource1.SelectParameters.RemoveAt(0);
                //    ddlBayiler.Visible = true;
                //    ddlBayiler.SelectedIndex = 0;
                //    //CariHesaplarTP.GetObjects(ddlBayiler.Items, 0, true, true);
                //}

                //ASPxGridView1.AutoFilterByColumn(ASPxGridView1.Columns["AY"], DateTime.Now.Month.ToString());
                foreach (GridViewDataColumn ctrl in ASPxGridView1.Columns)
                {
                    if (ctrl.FieldName != "YIL")
                    {
                        (ctrl as GridViewDataColumn).Settings.HeaderFilterMode = HeaderFilterMode.CheckedList;
                    }
                }
            }
            else
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SqlDataSource1.SelectCommand = genelsorgu;
                    //SqlDataSource1.SelectParameters.RemoveAt(0);
                    //if (lblBayiKod.Text != "0")
                    //{
                    //    SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [MUSTERI] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Bayi] WHERE [MUS KOD] = " + lblBayiKod.Text;
                    //}
                    //else
                    //{
                    //    SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [SAT TEM] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Personel-Web] WHERE YIL = " + DateTime.Now.Year.ToString();
                    //}
                }
            }
        }

        private void DataSourceRefresh()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            {
                SqlDataSource1.SelectCommand = genelsorgu;
                //SqlDataSource1.SelectParameters.RemoveAt(0);
                //if (lblBayiKod.Text != "0")
                //{
                //    SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [MUSTERI] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Bayi] WHERE [MUS KOD] = " + lblBayiKod.Text + " AND YIL = " + DateTime.Now.Year.ToString();
                //}
                //else
                //{
                //    SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [SAT TEM] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Personel-Web] WHERE YIL = " + DateTime.Now.Year.ToString();
                //}
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
            {
                lblSatKod.Text = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                //SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [SAT TEM] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Personel-Web] WHERE YIL = " + DateTime.Now.Year.ToString() + " AND [SAT KOD] = " + ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
            }
            //else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // bayi yöneticisi ise
            //{
            //    SqlDataSource1.SelectCommand = "SELECT [YIL], [AY], [MUSTERI] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Bayi] WHERE [MUS KOD] = " + lblBayiKod.Text + " AND YIL = " + DateTime.Now.Year.ToString();
            //}
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
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
                    e.Text = "%" + (Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[2])) * 100.0 / Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0]))).ToString("N2");
                }
            }
            else if (e.Text == "2")
            {
                if (ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0]).ToString() != "" && ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[3]).ToString() != "" && Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0])) != 0)
                {
                    e.Text = "%" + (Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[3])) * 100.0 / Convert.ToDouble(ASPxGridView1.GetTotalSummaryValue(ASPxGridView1.TotalSummary[0]))).ToString("N2");
                }
            }
        }

        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAutoFilterEventArgs e)
        {
            DataSourceRefresh();
        }

        protected void ASPxGridView1_PageIndexChanged(object sender, EventArgs e)
        {
            DataSourceRefresh();
        }

        protected void ddlBayiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBayiKod.Text = ddlBayiler.SelectedValue;
            DataSourceRefresh();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 0;
        }

        protected void cbSiparisci_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSiparisci.Checked)
            {
                SqlDataSource1.SelectCommand = genelsorgu.Replace("GROUP BY [PERSONEL], [PRIM_GR]", "AND SAT_KOD2 = " + lblSatKod.Text + " GROUP BY [PRIM_GR]")
                    .Replace("[PERSONEL] AS SAT_TEM,", "'" + ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + "' AS SAT_TEM,");
                ASPxGridView1.DataBind();
            }
            else
            {
                Response.Redirect("satishedef.aspx", true);
            }
        }
    }
}