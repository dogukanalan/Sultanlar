using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class AnlasmaGet
    {
        public int slsref { get; set; }
        public int gmref { get; set; }
        public int smref { get; set; }
        public string tip { get; set; }
        public int yil { get; set; }
        public int ay { get; set; }
        public string onay { get; set; } // 1 onaylı 2 hepsi 0 onaysız


        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }
    public class AnlasmaMusteriGet
    {
        public int yil { get; set; }
        public int ay { get; set; }
        public int smref { get; set; }
        public string tip { get; set; }
    }

    public class AnlasmaKaydet
    {
        public string musteri { get; set; }
        public int smref { get; set; }
        public string aciklama2 { get; set; }
        public int subesay { get; set; }
        public string baslangic { get; set; }
        public string bitis { get; set; }
        public int vadekgt { get; set; }
        public int vadenf { get; set; }
        public int skukgt { get; set; }
        public int skunf { get; set; }
        public double fataltkgt { get; set; }
        public double fataltnf { get; set; }
        public double cirokgt { get; set; }
        public double cironf { get; set; }
        public double ciro3kgt { get; set; }
        public double ciro3nf { get; set; }
        public double ciro6kgt { get; set; }
        public double ciro6nf { get; set; }
        public double ciro12kgt { get; set; }
        public double ciro12nf { get; set; }
        public double cirofataltkgt { get; set; }
        public double cirofataltnf { get; set; }
        public double anldisikgt { get; set; }
        public double anldisinf { get; set; }
        public double topcirokgt { get; set; }
        public double topcironf { get; set; }
        public string aciklama { get; set; }
        public List<AnlasmaBedelKaydet> bedeller { get; set; }
    }

    public class AnlasmaBedelKaydet
    {
        public int id { get; set; }
        public string tur { get; set; }
        public int adet { get; set; }
        public double bedel { get; set; }
    }

    public class AnlasmaKopya
    {
        public int id { get; set; }
        public string musteri { get; set; }
        public string baslangic { get; set; }
        public string bitis { get; set; }
        public string aciklama { get; set; }
        public List<AnlasmaKopyaSmref> SMREFs { get; set; }
    }

    public class AnlasmaKopyaSmref
    {
        public int smref { get; set; }
        public int tip { get; set; }
    }
}
