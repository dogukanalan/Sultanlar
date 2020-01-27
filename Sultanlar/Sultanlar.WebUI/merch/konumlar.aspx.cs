using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;

namespace Sultanlar.WebUI.merch
{
    public partial class konumlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                //Getir();

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                    slsref.Value = "0";
                    //if (Request.QueryString["slsref"] != null)
                    //    slsref.Value = Request.QueryString["slsref"];
                }
                else
                {
                    divTemsilciler.Visible = false;
                    slsref.Value = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                }
            }
        }

        private void Getir()
        {
            //if (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            //{
            //    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);

            //    if (Request.QueryString["slsref"] != null)
            //    {
            //        string SUBE = Request.QueryString["sube"].Trim().Replace("'", "");
            //        string top100 = "";
            //        if (SUBE == "")
            //            top100 = "TOP 100 ";
            //        DataTable dt = new DataTable();
            //        WebGenel.Sorgu(dt, "SELECT DISTINCT " + top100 + "[A/P],[Tür],[Müşteri],[Şube],[Kod],[Tip],[Şehir],[İlçe],[Adres ],TIP_KOD,ISNULL((SELECT KONUM FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS KONUM FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + Request.QueryString["slsref"] + " AND [Şube] LIKE '%" + SUBE + "%' ORDER BY [Müşteri],[Şube]");
            //        repe.DataSource = dt;
            //        repe.DataBind();

            //        for (int i = 0; i < ddlTemsilciler.Items.Count; i++)
            //        {
            //            if (ddlTemsilciler.Items[i].Value == Request.QueryString["slsref"])
            //            {
            //                ddlTemsilciler.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    ddlTemsilciler.Items.Add(new ListItem(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strAd + " " + ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strSoyad, ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF.ToString()));
            //    divTemsilciler.Visible = false;

            //    string SUBE = Request.QueryString["sube"] != null ? Request.QueryString["sube"].Trim().Replace("'", "") : "";
            //    string top100 = "";
            //    if (SUBE == "")
            //        top100 = "TOP 100 ";
            //    DataTable dt = new DataTable();
            //    WebGenel.Sorgu(dt, "SELECT DISTINCT " + top100 + "[A/P],[Tür],[Müşteri],[Şube],[Kod],[Tip],[Şehir],[İlçe],[Adres ],TIP_KOD,ISNULL((SELECT KONUM FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS KONUM FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF.ToString() + " AND [Şube] LIKE '%" + SUBE + "%' ORDER BY [Müşteri],[Şube]");
            //    repe.DataSource = dt;
            //    repe.DataBind();
            //}

            //if (Request.QueryString["sube"] != null)
            //    txtFarkliZiyaretSube.Text = Request.QueryString["sube"].Trim().Replace("'", "");
        }

        //protected void btnFarkliZiyaretAra_Click(object sender, EventArgs e)
        //{
        //    Getir();
        //}

        //protected string TurkceKarakter(string Ham)
        //{
        //    return Ham.Replace("İ", "I").Replace("Ğ", "G").Replace("Ü", "U").Replace("Ş", "S").Replace("Ö", "O").Replace("Ç", "C").Replace("&", "-").Replace(" ", "-");
        //}

        //protected string GetLat(string Ham)
        //{
        //    return Ham.ToString().Substring(0, Ham.ToString().IndexOf(",")).Trim();
        //}

        //protected string GetLng(string Ham)
        //{
        //    return Ham.Substring(Ham.IndexOf(",") + 1).Trim();
        //}

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Konum> KonumlarGetir(int sonid, int slsref, string sube)
        {
            List<Konum> donendeger = new List<Konum>();

            string SUBE = sube != null ? sube.Trim().Replace("'", "") : "";
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT DISTINCT [A/P],[Tür],[Müşteri],[Şube],[Kod],[Tip],[Şehir],[İlçe],[Adres ],TIP_KOD,ISNULL((SELECT KONUM FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS KONUM FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + slsref.ToString() + " AND [Şube] LIKE '%" + SUBE + "%' ORDER BY [Müşteri],[Şube]");

            int sinir = 0;
            for (int i = sonid; i < dt.Rows.Count; i++)
            {
                if (sinir < 50)
                {
                    Konum konum = new Konum();

                    konum.AP = dt.Rows[i]["A/P"].ToString();
                    konum.Tur = dt.Rows[i]["Tür"].ToString();
                    konum.Musteri = StringParcalama.NoktayiBoslukla(dt.Rows[i]["Müşteri"].ToString());
                    konum.Sube = StringParcalama.NoktayiBoslukla(dt.Rows[i]["Şube"].ToString());
                    konum.Kod = Convert.ToInt32(dt.Rows[i]["Kod"]);
                    konum.Tip = dt.Rows[i]["Tip"].ToString();
                    konum.Sehir = dt.Rows[i]["Şehir"].ToString();
                    konum.Ilce = dt.Rows[i]["İlçe"].ToString();
                    konum.Adres = dt.Rows[i]["Adres "].ToString();
                    konum.TIP_KOD = Convert.ToInt32(dt.Rows[i]["TIP_KOD"]);
                    konum.KONUM = dt.Rows[i]["KONUM"].ToString();

                    donendeger.Add(konum);
                }
                sinir++;
            }

            return donendeger;
        }
    }

    public class Konum
    {
        public string AP { get; set; }
        public string Tur { get; set; }
        public string Musteri { get; set; }
        public string Sube { get; set; }
        public int Kod { get; set; }
        public string Tip { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Adres { get; set; }
        public int TIP_KOD { get; set; }
        public string KONUM { get; set; }
    }
}