using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class AktiviteGet
    {
        public int slsref { get; set; }
        public int gmref { get; set; }
        public int smref { get; set; }
        public int tip { get; set; }
        public int yil { get; set; }
        public int ay { get; set; }
        public string onay { get; set; } // 1 onaylı 2 onay talep edilmiş 0 onaysız


        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }

    public class AktiviteKopya
    {
        public int id { get; set; }
        public string musteri { get; set; }
        public string donem { get; set; }
        public string bitis { get; set; }
        public List<AktiviteKopyaSmref> SMREFs { get; set; }
    }

    public class AktiviteKopyaSmref
    {
        public int AnlasmaID { get; set; }
        public int smref { get; set; }
        public int tip { get; set; }
    }

    public class AktiviteKaydet
    {
        public int id { get; set; }
        public int anlasmaid { get; set; }
        public string musteri { get; set; }
        public int smref { get; set; }
        public short fiyattipi { get; set; }
        public int aktivitetipi { get; set; }
        public string baslangic { get; set; }
        public string bitis { get; set; }
        public string aciklama1 { get; set; }
        public string aciklama2 { get; set; }
        public string aciklama3 { get; set; }
        public string donem { get; set; }
        public double tahbedel { get; set; }
        public double yegbedel { get; set; }
        public double tahciro { get; set; }
        public double yegciro { get; set; }
        public List<AktiviteKaydetDetay> detaylar { get; set; }

        public int yil { get { return Convert.ToInt32(donem.Substring(0, 4)); } }
        public int ay { get { return Convert.ToInt32(donem.Substring(5, donem.LastIndexOf("/") - 5)); } }
        public int gun { get { return Convert.ToInt32(donem.Substring(donem.LastIndexOf("/") + 1, 2)); } }
    }

    public class AktiviteKaydetDetay
    {
        public int urun { get; set; }
        public string urunacik { get; set; }
        public string miktar { get; set; }
        public double kdv { get; set; }
        public double birimfiyat { get; set; }
        public double fatalt { get; set; }
        public double fataltciro { get; set; }
        public double ciroprim { get; set; }
        public double pazisk { get; set; }
        public double aksiyon { get; set; }
        public double ekisk { get; set; }
    }
}
