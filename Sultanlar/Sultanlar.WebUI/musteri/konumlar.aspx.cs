using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using System.Data;
using System.Web.Security;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class konumlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                }
                else
                {
                    Response.Redirect("yetkiyok.aspx", true);
                }

                if (ddlTemsilciler.SelectedValue != "0")
                {
                    DataTable dt = new DataTable();
                    WebGenel.Sorgu(dt, "SELECT DISTINCT [A/P],[Tür],[Müşteri],[Şube],[Kod],[Tip],[Şehir],[İlçe],[Adres ],TIP_KOD,ISNULL((SELECT KONUM FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS KONUM,ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ddlTemsilciler.SelectedValue + " ORDER BY [Müşteri],[Şube]");
                    repe.DataSource = dt;
                    repe.DataBind();
                }
                else
                {
                    repe.Visible = false;
                }
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(form1, typeof(string), "kucukbilgi", alert, false);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlTemsilciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTemsilciler.SelectedValue != "0")
            {
                repe.Visible = true;
                DataTable dt = new DataTable();
                WebGenel.Sorgu(dt, "SELECT DISTINCT [A/P],[Tür],[Müşteri],[Şube],[Kod],[Tip],[Şehir],[İlçe],[Adres ],TIP_KOD,ISNULL((SELECT KONUM FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS KONUM,ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ddlTemsilciler.SelectedValue + " ORDER BY [Müşteri],[Şube]");
                repe.DataSource = dt;
                repe.DataBind();
            }
            else
            {
                repe.Visible = false;
            }
        }

        protected string TurkceKarakter(string Ham)
        {
            return Ham.Replace("İ", "I").Replace("Ğ", "G").Replace("Ü", "U").Replace("Ş", "S").Replace("Ö", "O").Replace("Ç", "C").Replace("&", "-").Replace(" ", "-");
        }

        protected string GetLat(string Ham)
        {
            return Ham.ToString().Substring(0, Ham.ToString().IndexOf(",")).Trim();
        }

        protected string GetLng(string Ham)
        {
            return Ham.Substring(Ham.IndexOf(",") + 1).Trim();
        }
    }
}