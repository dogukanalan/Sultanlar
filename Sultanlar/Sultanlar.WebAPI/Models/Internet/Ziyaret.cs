using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class Ziyaret
    {
        [JsonPropertyAttribute("mtip")]
        public int MTIP { get; set; }
        [JsonPropertyAttribute("rut_tur")]
        public int RUT_TUR { get; set; }
        [JsonPropertyAttribute("rut_id")]
        public string RUT_ID { get; set; }
        [JsonPropertyAttribute("gmref")]
        public int GMREF { get; set; }
        [JsonPropertyAttribute("smref")]
        public int SMREF { get; set; }
        [JsonPropertyAttribute("slsref")]
        public int SLSREF { get; set; }
        [JsonPropertyAttribute("barkod")]
        public string BARKOD { get; set; }
        [JsonPropertyAttribute("ziy_bas_tar")]
        public string ZIY_BAS_TAR { get; set; }
        [JsonPropertyAttribute("ziy_bit_tar")]
        public string ZIY_BIT_TAR { get; set; }
        [JsonPropertyAttribute("ziy_ndn_id")]
        public int ZIY_NDN_ID { get; set; }
        [JsonPropertyAttribute("ziy_konum")]
        public string ZIY_KONUM { get; set; }
        [JsonPropertyAttribute("ziy_konum_adres")]
        public string ZIY_KONUM_ADRES { get; set; }
        [JsonPropertyAttribute("ziy_konum_cikis")]
        public string ZIY_KONUM_CIKIS { get; set; }
        [JsonPropertyAttribute("ziy_konum_adres_cikis")]
        public string ZIY_KONUM_ADRES_CIKIS { get; set; }
        [JsonPropertyAttribute("ziy_konum_musteri")]
        public string ZIY_KONUM_MUSTERI { get; set; }
        [JsonPropertyAttribute("fark_knm_ziy")]
        public int FARK_KNM_ZIY { get; set; }
        [JsonPropertyAttribute("ziy_konum_resim")]
        public string ZIY_KONUM_RESIM { get; set; }
        [JsonPropertyAttribute("ziy_notlari")]
        public string ZIY_NOTLARI { get; set; }
        [JsonPropertyAttribute("ziy_sip")]
        public int ZIY_SIP { get; set; }
        [JsonPropertyAttribute("ziy_akt")]
        public int ZIY_AKT { get; set; }
        [JsonPropertyAttribute("ziy_iad")]
        public int ZIY_IAD { get; set; }
        [JsonPropertyAttribute("ziy_tah")]
        public int ZIY_TAH { get; set; }
        [JsonPropertyAttribute("yol")]
        public double YOL { get; set; }
    }

    public class ZiyaretGet
    {
        public string Barkod { get; set; }
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

    public class ZiyaretVaryok
    {
        public string barkod { get; set; }
        public string musteri { get; set; }
        public int tip { get; set; }
        public List<ZiyaretVaryokDetay> detays { get; set; }
    }

    public class ZiyaretVaryokDetay
    {
        public int itemref { get; set; }
        public bool isaret { get; set; }
        public bool varyok { get; set; }
        public bool depo { get; set; }
        public bool raf { get; set; }
        public double raffiyat { get; set; }
        public bool skt { get; set; }
        public int siparis { get; set; }
    }
}
