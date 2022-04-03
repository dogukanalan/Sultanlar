using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class IadeGet
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

    public class IadeOnay
    {
        public int IadeID { get; set; }
    }

    public class IadeKopya
    {
        public int IadeID { get; set; }
        public List<IadeKopyaSmref> SMREFs { get; set; }
    }

    public class IadeKopyaSmref
    {
        public int smref { get; set; }
    }

    public class IadeKaydet
    {
        public int iadeid { get; set; }
        public string musteri { get; set; }
        public int smref { get; set; }
        public string aciklama { get; set; }
        public List<IadeKaydetDetay> detaylar { get; set; }
    }

    public class IadeKaydetDetay
    {
        public int itemref { get; set; }
        public string malacik { get; set; }
        public int miktar { get; set; }
        public string miktartur { get; set; }
    }
}
