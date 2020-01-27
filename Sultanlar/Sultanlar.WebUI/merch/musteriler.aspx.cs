using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.WebUI.merch
{
    public partial class musteriler : System.Web.UI.Page
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

                sdemi.Value = ((Musteriler)Session["Musteri"]).blSicakSatis ? "1" : "0";
            }
        }

        private void Getir()
        {
            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            //{
            //    if (Request.QueryString["slsref"] != null)
            //    {
            //        string SUBE = Request.QueryString["sube"].Trim().Replace("'", "");
            //        string top100 = "";
            //        if (SUBE == "")
            //            top100 = "TOP 100 ";
            //        DataTable dt = new DataTable();
            //        WebGenel.Sorgu(dt, "SELECT DISTINCT " + top100 + "TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + Request.QueryString["slsref"] + " AND [Şube] LIKE '%" + SUBE + "%' ORDER BY [Müşteri],[Şube]");
            //        rpZiyaretCariler.DataSource = dt;
            //        rpZiyaretCariler.DataBind();

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
            //    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
            //    divTemsilciler.Visible = false;

            //    string SUBE = Request.QueryString["sube"] != null ? Request.QueryString["sube"].Trim().Replace("'", "") : "";
            //    string top100 = "";
            //    if (SUBE == "")
            //        top100 = "TOP 100 ";
            //    DataTable dt = new DataTable();
            //    WebGenel.Sorgu(dt, "SELECT DISTINCT " + top100 + "TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF.ToString() + " AND [Şube] LIKE '%" + SUBE + "%' ORDER BY [Müşteri],[Şube]");
            //    rpZiyaretCariler.DataSource = dt;
            //    rpZiyaretCariler.DataBind();
            //}

            //if (Request.QueryString["sube"] != null)
            //    txtFarkliZiyaretSube.Text = Request.QueryString["sube"].Trim().Replace("'", "");
        }

        protected void lbFarkliZiyaretBaslat_Click(object sender, EventArgs e)
        {
            //Ziy ziyaret = new Ziy();
            //int SMREF = 0;
            //int MTIP = 0;

            //foreach (Control ctrl in ((LinkButton)sender).Parent.Controls)
            //{
            //    if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
            //    {
            //        if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
            //        {
            //            SMREF = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
            //        }
            //        else if (ctrl.ID.StartsWith("MTIP"))
            //        {
            //            MTIP = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
            //        }
            //    }
            //}

            //int gmref = CariHesaplar.GetGMREFBySMREF(SMREF, MTIP);
            //string BARKOD = ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + gmref.ToString() + SMREF.ToString() + "." + DateTime.Now.ToString().Replace(" ", ".");

            //ziyaret.smref = SMREF;
            //ziyaret.barkod = BARKOD;
            //ziyaret.ziygun = DateTime.MinValue;
            //ziyaret.mtip = MTIP;
            //ziyaret.coords = txtCoords.Text;
            //ziyaret.coords1 = txtCoords1.Text;

            //Session["Ziy"] = ziyaret;
            //Response.Redirect("ziyaret.aspx", true);
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Musteri> MusterilerGetir(int sonid, int slsref, string sube)
        {
            List<Musteri> donendeger = new List<Musteri>();

            string SUBE = sube != null ? sube.Trim().Replace("'", "") : "";
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT DISTINCT TIP_KOD AS MTIP,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + slsref.ToString() + " AND [Şube] LIKE '%" + SUBE + "%' ORDER BY [Müşteri],[Şube]");

            int sinir = 0;
            for (int i = sonid; i < dt.Rows.Count; i++)
            {
                if (sinir < 50)
                {
                    Musteri musteri = new Musteri();

                    musteri.MTIP = Convert.ToInt32(dt.Rows[i]["MTIP"]);
                    musteri.MUSKOD = dt.Rows[i]["MUS KOD"].ToString();
                    musteri.MUSTERI = StringParcalama.NoktayiBoslukla(dt.Rows[i]["MUSTERI"].ToString());
                    musteri.SMREF = Convert.ToInt32(dt.Rows[i]["SMREF"]);
                    musteri.SUBKOD = Convert.ToInt32(dt.Rows[i]["SUB KOD"]);
                    musteri.SUBE = StringParcalama.NoktayiBoslukla(dt.Rows[i]["SUBE"].ToString());
                    musteri.ADRES = dt.Rows[i]["ADRES"].ToString();
                    musteri.SEHIR = dt.Rows[i]["SEHIR"].ToString();
                    musteri.SEMT = dt.Rows[i]["SEMT"].ToString();
                    musteri.TEL1 = dt.Rows[i]["TEL-1"].ToString();
                    musteri.CEP1 = dt.Rows[i]["CEP-1"].ToString();
                    musteri.EMAIL1 = dt.Rows[i]["EMAIL-1"].ToString();
                    musteri.ILGILI = dt.Rows[i]["ILGILI"].ToString();

                    donendeger.Add(musteri);
                }
                sinir++;
            }

            return donendeger;
        }
    }

    public class Musteri
    {
        public int MTIP { get; set; }
        public string MUSKOD { get; set; }
        public string MUSTERI { get; set; }
        public int SMREF { get; set; }
        public int SUBKOD { get; set; }
        public string SUBE { get; set; }
        public string ADRES { get; set; }
        public string SEHIR { get; set; }
        public string SEMT { get; set; }
        public string TEL1 { get; set; }
        public string CEP1 { get; set; }
        public string EMAIL1 { get; set; }
        public string ILGILI { get; set; }
    }
}

