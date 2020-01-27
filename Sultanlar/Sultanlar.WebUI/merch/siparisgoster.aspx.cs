using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class siparisgoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static string SiparisEkle(string musteriid, string smref, string fiyattip, List<siparisdetay> siparisliste)
        {
            Musteriler musteri = Musteriler.GetMusteriByID(Convert.ToInt32(musteriid));
            Siparisler sip = new Siparisler(Convert.ToInt32(musteriid), Convert.ToInt32(smref), Convert.ToInt16(fiyattip), DateTime.Now, 0, false, 0, DateTime.Now, musteri.strAd + " " + musteri.strSoyad + ";;;(mobilden);;;" + DateTime.Now.ToShortDateString());
            sip.DoInsert();

            decimal toplamtutar = 0;
            for (int i = 0; i < siparisliste.Count; i++)
            {
                decimal fiyat = Convert.ToDecimal(siparisliste[i].fiyat);
                toplamtutar += fiyat;
                SiparislerDetay sipdet = new SiparislerDetay(sip.pkSiparisID, Convert.ToInt32(siparisliste[i].itemref),
                    Urunler.GetProductName(Convert.ToInt32(siparisliste[i].itemref)), Convert.ToInt32(siparisliste[i].adet), fiyat, Guid.Empty, false, Guid.Empty, "ST");
                sipdet.DoInsert();
            }

            sip.mnToplamTutar = toplamtutar;
            sip.DoUpdate();

            string Donen = string.Empty;
            Siparis.SiparisOnayla(sip.pkSiparisID, 0, 0, false, musteri, out Donen);
            return Donen;
        }

        public class siparisdetay
        {
            public int itemref { get; set; }
            public string ad { get; set; }
            public int adet { get; set; }
            public string fiyat { get; set; }
        }
    }
}