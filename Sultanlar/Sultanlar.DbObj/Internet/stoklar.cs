using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class stoklar : DbObj
    {
    }

    public class bayiStokRaporu : DbObj
    {
        public int AY { get; set; }
        public int SMREF { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(SMREF).GetObject(); if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public int MALKOD { get; set; }
        public malzemeler Malzeme { get { malzemeler malz = new malzemeler(MALKOD).GetObject(); if (malzeme) return malz; else { malzemeler mal = new malzemeler(); mal.MALACIK = malz.MALACIK; return mal; } } }
        public double STOKTL { get; set; }
        public double STOKKOLI { get; set; }
        public double YILLIKSATILANKOLI { get; set; }
        public double STOKAY { get; set; }
        public double STOKGUN { get; set; }

        private bool cariAna { get; set; }
        private bool malzeme { get; set; }

        public bayiStokRaporu() { }
        private bayiStokRaporu(int AY, int SMREF, int MALKOD, double STOKTL, double STOKKOLI, double YILLIKSATILANKOLI, double STOKAY, double STOKGUN, bool cariAna, bool malzeme)
        {
            this.AY = AY;
            this.SMREF = SMREF;
            this.MALKOD = MALKOD;
            this.STOKTL = STOKTL;
            this.STOKKOLI = STOKKOLI;
            this.YILLIKSATILANKOLI = YILLIKSATILANKOLI;
            this.STOKAY = STOKAY;
            this.STOKGUN = STOKGUN;
            this.cariAna = cariAna;
            this.malzeme = malzeme;
        }

        public override string ToString() { return STOKKOLI.ToString("N2"); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<bayiStokRaporu> GetObjects(int SLSREF, object SMREF)
        {
            List<bayiStokRaporu> donendeger = new List<bayiStokRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_bayiStokGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "SMREF", SMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new bayiStokRaporu(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDouble(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToDouble(dic[i][7]), false, false));

            return donendeger;
        }
        /// <summary>
        /// bayii_stok_toplam
        /// </summary>
        /// <returns></returns>
        public bayiStokRaporu GetObject(int SMREF, int ITEMREF)
        {
            bayiStokRaporu donendeger = new bayiStokRaporu();

            Dictionary<int, object> dic = GetObject("db_sp_bayiStokSatirGetir", new Dictionary<string, object>() { { "SMREF", SMREF }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                 donendeger = new bayiStokRaporu(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToDouble(dic[3]), ConvertToDouble(dic[4]), ConvertToDouble(dic[5]), ConvertToDouble(dic[6]), ConvertToDouble(dic[7]), false, false);

            return donendeger;
        }
    }
}
