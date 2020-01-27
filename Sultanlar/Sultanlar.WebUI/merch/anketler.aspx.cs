using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class anketler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            uyeid.Value = ((Musteriler)Session["Musteri"]).pkMusteriID.ToString();
        }

        [System.Web.Services.WebMethod()]
        public static List<Anket> AnketlerGetir(int uye)
        {
            var donendeger = new List<Anket>();

            var anketler = Anketler.GetObjects();
            for (int i = 0; i < anketler.Count; i++)
                donendeger.Add(new Anket(anketler[i].pkID, anketler[i].strSoru, anketler[i].dtZaman.ToShortDateString()));

            return donendeger;
        }
    }
    
    public class Anket
    {
        public int ID { get; set; }
        public string Soru { get; set; }
        public string Zaman { get; set; }
        public List<AnketSecimler> secimler
        {
            get
            {
                return AnketSecimler.GetObjects(this.ID);
            }
        }
        public List<AnketCevaplar> cevaplar
        {
            get
            {
                return AnketCevaplar.GetObjects(this.ID);
            }
        }

        public Anket(int ID, string Soru, string Zaman)
        {
            this.ID = ID;
            this.Soru = Soru;
            this.Zaman = Zaman;
        }
    }

    //public class Secim
    //{
    //    public int ID { get; set; }
    //    public int Anket { get; set; }
    //    public string Secim1 { get; set; }
    //    public Secim() { }
    //    public Secim(int ID, int Anket, string Secim1)
    //    {
    //        this.ID = ID;
    //        this.Anket = Anket;
    //        this.Secim1 = Secim1;
    //    }
    //}

    //public class Cevap
    //{
    //    public int ID { get; set; }
    //    public int Anket { get; set; }
    //    public int Secim { get; set; }
    //    public int Uye { get; set; }
    //    public Cevap() { }
    //    public Cevap(int ID, int Anket, int Secim, int Uye)
    //    {
    //        this.ID = ID;
    //        this.Anket = Anket;
    //        this.Secim = Secim;
    //        this.Uye = Uye;
    //    }
    //}
}