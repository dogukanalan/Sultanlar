using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.merch
{
    public partial class rutekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                Getir();
                spanBugunRutPryd.InnerText = WebGenel.SorguSkalar("SELECT [PRYD] FROM [WEB_RUT_0_TAKVIM] WHERE TARIH = '" + DateTime.Now.Day.ToString() + '.' + DateTime.Now.Month.ToString() + '.' + DateTime.Now.Year.ToString() + "'");
            }
        }

        private void Getir()
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            {
                SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);

                if (Request.QueryString["slsref"] != null)
                {
                    string slsref = Request.QueryString["slsref"];
                    string SUBE = Request.QueryString["sube"].Trim().Replace("'", "");
                    string RUTLU = Request.QueryString["rutlu"] == "2" ? " AND (SELECT count(*) FROM [WEB_RUT_4_LISTE] WHERE [TARIH] > getdate() AND SLSREF = " + slsref + " AND SMREF = [zWeb-Musteri-Adres].Kod AND MTIP = [zWeb-Musteri-Adres].TIP_KOD) > 0" : Request.QueryString["rutlu"] == "3" ? " AND (SELECT count(*) FROM [WEB_RUT_4_LISTE] WHERE [TARIH] > getdate() AND SLSREF = " + slsref + " AND SMREF = [zWeb-Musteri-Adres].Kod AND MTIP = [zWeb-Musteri-Adres].TIP_KOD) = 0" : "";

                    string top100 = "";
                    if (SUBE == "")
                        top100 = "TOP 100 ";
                    DataTable dt = new DataTable();
                    WebGenel.Sorgu(dt, "SELECT DISTINCT " + top100 + "TIP_KOD AS MTIP,(SELECT count(*) FROM [WEB_RUT_4_LISTE] WHERE [TARIH] > getdate() AND SLSREF = " + slsref + " AND SMREF = [zWeb-Musteri-Adres].Kod AND MTIP = [zWeb-Musteri-Adres].TIP_KOD) AS RUTVAR,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + slsref + " AND [Şube] LIKE '%" + SUBE + "%'" + RUTLU + " ORDER BY [Müşteri],[Şube]");
                    rpZiyaretCariler.DataSource = dt;
                    rpZiyaretCariler.DataBind();

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
                ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                divTemsilciler.Style["display"] = "none";

                string slsref = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                string SUBE = Request.QueryString["sube"] != null ? Request.QueryString["sube"].Trim().Replace("'", "") : "";
                string RUTLU = Request.QueryString["rutlu"] == "2" ? " AND (SELECT count(*) FROM [WEB_RUT_4_LISTE] WHERE [TARIH] > getdate() AND SLSREF = " + slsref + " AND SMREF = [zWeb-Musteri-Adres].Kod AND MTIP = [zWeb-Musteri-Adres].TIP_KOD) > 0" : Request.QueryString["rutlu"] == "3" ? " AND (SELECT count(*) FROM [WEB_RUT_4_LISTE] WHERE [TARIH] > getdate() AND SLSREF = " + slsref + " AND SMREF = [zWeb-Musteri-Adres].Kod AND MTIP = [zWeb-Musteri-Adres].TIP_KOD) = 0" : "";
                string top100 = "";
                if (SUBE == "")
                    top100 = "TOP 100 ";
                DataTable dt = new DataTable();
                WebGenel.Sorgu(dt, "SELECT DISTINCT " + top100 + "TIP_KOD AS MTIP,(SELECT count(*) FROM [WEB_RUT_4_LISTE] WHERE [TARIH] > getdate() AND SLSREF = " + slsref + " AND SMREF = [zWeb-Musteri-Adres].Kod AND MTIP = [zWeb-Musteri-Adres].TIP_KOD) AS RUTVAR,'' AS [MUS KOD],[Müşteri] AS [MUSTERI],[Kod] AS [SMREF],[Kod] AS [SUB KOD],[Şube] AS [SUBE],ISNULL((SELECT KONUM_ADRES FROM [Web-Musteri-Acik] WHERE TIP = [zWeb-Musteri-Adres].TIP_KOD AND SMREF = [zWeb-Musteri-Adres].Kod),'') AS ADRES ,[Şehir] AS [SEHIR],[İlçe] AS [SEMT],'' AS [TEL-1],'' AS [CEP-1],'' AS [EMAIL-1],'' AS ILGILI FROM [zWeb-Musteri-Adres] WHERE [A/P] = 'AKTİF' AND [Sat.Kod] = " + slsref + " AND [Şube] LIKE '%" + SUBE + "%' " + RUTLU + " ORDER BY [Müşteri],[Şube]");
                rpZiyaretCariler.DataSource = dt;
                rpZiyaretCariler.DataBind();
            }

            if (Request.QueryString["sube"] != null)
                txtFarkliZiyaretSube.Text = Request.QueryString["sube"].Trim().Replace("'", "");

            Rutlar.GetPeriyodlar(rblPeriyodlar.Items, true);
            rblPeriyodlar.Items[0].Selected = true;
            Rutlar.GetGunler(rblGunler.Items, true);
            rblGunler.Items[0].Selected = true;

            islemci.Value = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
        }

        [System.Web.Services.WebMethod()]
        public static string RutEkle(string mtip, string slsref, string gmref, string smref, int kacinci, string periyod, string gun, string baslangic, string bitis, string islemyapan)
        {
            //if (!Rutlar.RutVarMi(Convert.ToInt32(slsref), Convert.ToInt32(gmref), Convert.ToInt32(smref), kacinci))
                Rutlar.Insert(Convert.ToInt32(mtip), Convert.ToInt32(slsref), Convert.ToInt32(gmref), Convert.ToInt32(smref), Convert.ToInt32(kacinci), periyod.Trim(), gun.Trim(), Convert.ToDateTime(baslangic == "" ? DateTime.Now.ToShortDateString() : baslangic), Convert.ToDateTime((bitis == "" ? "01/01/2023" : bitis)), islemyapan, DateTime.Now);
            //else
            //    return "Bu müşteride kayıtlı rut zaten var.";
            return "";
        }

        [System.Web.Services.WebMethod()]
        public static Rut1 RutGetir(string slsref, string gmref, string smref, string kacinci)
        {
            DataTable dt = new DataTable();
            Rutlar.GetRutDetay(dt, Convert.ToInt32(slsref), Convert.ToInt32(gmref), Convert.ToInt32(smref), Convert.ToInt32(kacinci));
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value && dt.Rows[0][0].ToString() != string.Empty)
                return new Rut1(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), Convert.ToDateTime(dt.Rows[0][3]).ToShortDateString(), Convert.ToDateTime(dt.Rows[0][4]).ToShortDateString());
            return new Rut1("", "", "", "", "");
        }
    }

    public class Rut1
    {
        public string ID { get; set; }
        public string Rut { get; set; }
        public string Gun { get; set; }
        public string BasTar { get; set; }
        public string BitTar { get; set; }

        public Rut1(string ID, string Rut, string Gun, string BasTar, string BitTar)
        {
            this.ID = ID;
            this.Rut = Rut;
            this.Gun = Gun;
            this.BasTar = BasTar;
            this.BitTar = BitTar;
        }
    }
}