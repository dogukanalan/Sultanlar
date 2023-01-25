using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class SayimEkle
    {
        public int id { get; set; }
        public int uyeid { get; set; }
        public bool ap { get; set; }
        public int turid { get; set; }
        public int anaid { get; set; }
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
        public int itemref { get; set; }
        public int gmref { get; set; }
        public int stok { get; set; }
    }
    public class SayimKaydet
    {
        public int sayimid { get; set; }
        public string musteri { get; set; }
        public int smref { get; set; }
        public int tur { get; set; }
        public string aciklama { get; set; }
        public List<SayimKaydetDetay> detaylar { get; set; }
    }
    public class SayimKaydetDetay
    {
        public int itemref { get; set; }
        public string malacik { get; set; }
        public string miktartur { get; set; }
        public int miktar { get; set; }
    }
}
