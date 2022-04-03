using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class Ziyaret
    {
        public int MTIP { get; set; }
        public int RUT_TUR { get; set; }
        public string RUT_ID { get; set; }
        public int GMREF { get; set; }
        public int SMREF { get; set; }
        public int SLSREF { get; set; }
        public string BARKOD { get; set; }
        public string ZIY_BAS_TAR { get; set; }
        public string ZIY_BIT_TAR { get; set; }
        public int ZIY_NDN_ID { get; set; }
        public string ZIY_KONUM { get; set; }
        public string ZIY_KONUM_ADRES { get; set; }
        public string ZIY_KONUM_CIKIS { get; set; }
        public string ZIY_KONUM_ADRES_CIKIS { get; set; }
        public string ZIY_KONUM_MUSTERI { get; set; }
        public int FARK_KNM_ZIY { get; set; }
        public string ZIY_KONUM_RESIM { get; set; }
        public string ZIY_NOTLARI { get; set; }
        public int ZIY_SIP { get; set; }
        public int ZIY_AKT { get; set; }
        public int ZIY_IAD { get; set; }
        public int ZIY_TAH { get; set; }
    }

    public class ZiyaretGet
    {
        public int Tip { get; set; }
        public int Smref { get; set; }
        public int Slsref { get; set; }
        public string Zaman { get; set; }
    }

    public class ZiyaretsGet
    {
        public int Tip { get; set; }
        public int Smref { get; set; }
        public int Gmref { get; set; }
        public int Slsref { get; set; }
        public int Yil { get; set; }
        public int Ay { get; set; }


        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }
}
