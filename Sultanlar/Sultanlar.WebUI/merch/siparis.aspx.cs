using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class siparis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            musteriid.Value = ((Musteriler)Session["Musteri"]).pkMusteriID.ToString();

            ddlFiyatTipleri.Items.Clear();
            ddlFiyatTipleri.Items.Add("Seçiniz");
            ddlFiyatTipleri.Items[0].Value = "0";

            ArrayList fiyattipler = new ArrayList();
            fiyattipler = ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler;

            for (int i = 0; i < fiyattipler.Count; i++)
            {
                short fiyattipiid = Convert.ToInt16(fiyattipler[i]);
                string fiyattipi = FiyatTipleri.GetObjectByID(fiyattipiid);

                ddlFiyatTipleri.Items.Add(fiyattipi != "" ? fiyattipi : fiyattipiid.ToString());
                ddlFiyatTipleri.Items[i + 1].Value = fiyattipiid.ToString();
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Urun> UrunlerGetir(int sonid, int fiyattip, string arama)
        {
            List<Urun> donendeger = new List<Urun>();

            string Arama = arama != null ? arama.Trim().Replace("'", "") : "";
            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, 0, 1000, fiyattip.ToString(), Arama);

            int sinir = 0;
            for (int i = sonid; i < dt.Rows.Count; i++)
            {
                if (sinir < 50)
                {
                    Urun urun = new Urun();

                    urun.ID = Convert.ToInt32(dt.Rows[i]["UrunID"]);
                    urun.Ad = dt.Rows[i]["Ad"].ToString();
                    urun.Fiyat = Convert.ToDouble(dt.Rows[i]["Fiyat"]).ToString("N2");
                    urun.Barkod = dt.Rows[i]["Barkod"].ToString();

                    donendeger.Add(urun);
                }
                sinir++;
            }

            return donendeger;
        }
    }

    public class Urun
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Fiyat { get; set; }
        public string Barkod { get; set; }
    }
 }