using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using System.Web.Security;

namespace Sultanlar.WebUI.musteri
{
    public partial class konumal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                WebGenel.Sorgu(dt, "SELECT DISTINCT [A/P],[Tür],[Müşteri],[Şube],[Kod],[Tip],[Şehir],[İlçe],[Adres ],TIP_KOD,ISNULL((SELECT KONUM FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS KONUM FROM [zWeb-Musteri-Adres] WHERE Kod = " +
                    Request.QueryString["smref"] + " AND TIP_KOD = " + Request.QueryString["tip"]);

                if (dt.Rows[0]["Konum"].ToString() != string.Empty)
                {
                    inputLat.Value = dt.Rows[0]["Konum"].ToString().Substring(0, dt.Rows[0]["Konum"].ToString().IndexOf(",")).Trim();
                    inputLng.Value = dt.Rows[0]["Konum"].ToString().Substring(dt.Rows[0]["Konum"].ToString().IndexOf(",") + 1).Trim();
                }
                else
                {
                    inputLat.Value = string.Empty;
                    inputLng.Value = string.Empty;
                }

                //if (Request.QueryString["lat"] != null && Request.QueryString["lng"] != null)
                //{
                //    inputLat.Value = Request.QueryString["lat"];
                //    inputLng.Value = Request.QueryString["lng"];
                //}

                inputSMREF.Value = Request.QueryString["smref"];
                inputTIP.Value = Request.QueryString["tip"];
                inputUnvan.Value = dt.Rows[0]["Şube"].ToString();
                inputAdres.Value = dt.Rows[0]["Şehir"].ToString() + " " + dt.Rows[0]["İlçe"].ToString() + " " + dt.Rows[0]["Adres "].ToString().Replace(".", " . ").Replace("MAH", "MAHALLESİ").Replace("MH", "MAHALLESİ").Replace("SOK", "SOKAK").Replace("SK", "SOKAK").Replace("CD", "CADDESİ").Replace("CAD", "CADDESİ");
                lblMusteri.Text = dt.Rows[0]["Şube"].ToString();
                lblAdres.Text = inputAdres.Value;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void btnAlBakalim_Click(object sender, EventArgs e)
        {
            Rutlar.SetKonum(Convert.ToInt32(inputSMREF.Value), Convert.ToInt32(inputTIP.Value), inputLat.Value + "," + inputLng.Value);
            Rutlar.SetKonumAdres(Convert.ToInt32(inputSMREF.Value), Convert.ToInt32(inputTIP.Value), inputMapAdres2.Value);
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                Response.Redirect("kapat.htm", true);
            else
                Response.Redirect("konumlar.aspx", true);
        }
    }
}