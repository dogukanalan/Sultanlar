using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class SiparisGet
    {
        public int slsref { get; set; }
        public int gmref { get; set; }
        public int smref { get; set; }
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

    public class SiparisOnay
    {
        public int SiparisID { get; set; }
        public int Bakiye { get; set; }
        public string MusteriID { get; set; } //uyeid
    }

    public class SiparisKopya
    {
        public int SiparisID { get; set; }
        public List<SiparisKopyaSmref> SMREFs { get; set; }
    }

    public class SiparisKopyaSmref
    {
        public int smref { get; set; }
    }

    public class SiparisKaydet
    {
        public int siparisid { get; set; }
        public string musteri { get; set; }
        public int smref { get; set; }
        public short ftip { get; set; }
        public int mtip { get; set; }
        public string aciklama { get; set; }
        public string teslim { get; set; }
        public List<SiparisKaydetDetay> detaylar { get; set; }
    }

    public class SiparisKaydetDetay
    {
        public int itemref { get; set; }
        public string malacik { get; set; }
        public int miktar { get; set; }
        public string miktartur { get; set; }
        public double isk1 { get; set; }
        public double isk2 { get; set; }
        public double isk3 { get; set; }
        public double isk4 { get; set; }
        public double netkdv { get; set; }
    }

    public class SiparisIsks
    {
        public double fiyat { get; set; }
        public double isk1 { get; set; }
        public double isk2 { get; set; }
        public double isk3 { get; set; }
        public double isk4 { get; set; }
    }
}
