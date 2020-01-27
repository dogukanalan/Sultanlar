using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.merch
{
    public partial class anket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            Anketler anket = new Anketler();

            if (Request.QueryString["id"] != null)
                anket = Anketler.GetObject(Convert.ToInt32(Request.QueryString["id"]));
            else
                anket = Anketler.GetObject(Anketler.GetObjects()[0].pkID);

            uyeid.Value = ((Musteriler)Session["Musteri"]).pkMusteriID.ToString();
            anketid.Value = anket.pkID.ToString();

            spanSoru.InnerHtml = anket.strSoru;
            spanZaman.InnerHtml = anket.dtZaman.ToShortDateString();
            var list = AnketSecimler.GetObjects(anket.pkID);
            for (int i = 0; i < list.Count; i++)
                rblCevaplar.Items.Add(new ListItem(list[i].strSecim, list[i].pkID.ToString()));

            var list2 = AnketCevaplar.GetObjects(anket.pkID);
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].intMusteriID == ((Musteriler)Session["Musteri"]).pkMusteriID)
                {
                    aGonder.InnerText = "Daha önce seçim yaptınız.";
                    aGonder.HRef = "#";
                    for (int j = 0; j < rblCevaplar.Items.Count; j++)
                        if (list2[i].intSecimID.ToString() == rblCevaplar.Items[j].Value)
                            rblCevaplar.Items[j].Selected = true;
                    rblCevaplar.Enabled = false;
                }
            }
        }

        [System.Web.Services.WebMethod()]
        public static void CevapEkle(int anket, int secim, int uye)
        {
            AnketCevaplar cevap = new AnketCevaplar(anket, secim, uye, DateTime.Now);
            cevap.DoInsert();
        }
    }
}