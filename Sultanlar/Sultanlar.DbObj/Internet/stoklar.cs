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
                    donendeger.Add(new bayiStokRaporu(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDouble(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToDouble(dic[i][7]), false, true));

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

    public class bayiStokTeslim : DbObj
    {
        public string FAT_NO_MTB { get; set; }
        public int GMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(GMREF).GetObject(); } }
        public bool TESLIM { get; set; }
        public DateTime TARIH { get; set; }
        public DateTime SON_TARIH { get; set; }
        public int KULLANICI { get; set; }
        public int SON_KULLANICI { get; set; }
        public string IPT_IRS { get; set; }
        public string IPT_FAT { get; set; }
        //public List<satisRaporu> detay { get { return new satisRaporu().GetObject(FAT_NO_MTB); } }

        public bayiStokTeslim() { }
        public bayiStokTeslim(string FAT_NO_MTB, int GMREF, bool TESLIM, DateTime TARIH, DateTime SON_TARIH, int KULLANICI, int SON_KULLANICI, string IPT_IRS, string IPT_FAT)
        {
            this.FAT_NO_MTB = FAT_NO_MTB;
            this.GMREF = GMREF;
            this.TESLIM = TESLIM;
            this.TARIH = TARIH;
            this.SON_TARIH = SON_TARIH;
            this.KULLANICI = KULLANICI;
            this.SON_KULLANICI = SON_KULLANICI;
            this.IPT_IRS = IPT_IRS;
            this.IPT_FAT = IPT_FAT;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "GMREF", GMREF }, { "FAT_NO_MTB", FAT_NO_MTB }, { "TESLIM", TESLIM }, { "TARIH", TARIH }, { "SON_TARIH", SON_TARIH }, { "KULLANICI", KULLANICI }, { "SON_KULLANICI", SON_KULLANICI } };
            Do(QueryType.Update, "db_sp_bayiStokTeslimEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "GMREF", GMREF }, { "FAT_NO_MTB", FAT_NO_MTB }, { "TESLIM", TESLIM }, { "TARIH", TARIH }, { "SON_TARIH", SON_TARIH }, { "KULLANICI", KULLANICI }, { "SON_KULLANICI", SON_KULLANICI } };
            Do(QueryType.Update, "db_sp_bayiStokTeslimGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<bayiStokTeslim> GetObjects(int GMREF)
        {
            List<bayiStokTeslim> donendeger = new List<bayiStokTeslim>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_bayiStokTeslimlerGetir", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new bayiStokTeslim(dic[i][0].ToString(), ConvertToInt32(dic[i][1]), ConvertToBool(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), dic[i][7].ToString(), dic[i][8].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bayiStokTeslim GetObject(int GMREF, string FAT_NO_MTB)
        {
            bayiStokTeslim donendeger = new bayiStokTeslim();

            Dictionary<int, object> dic = GetObject("db_sp_bayiStokTeslimGetir", new Dictionary<string, object>() { { "GMREF", GMREF }, { "FAT_NO_MTB", FAT_NO_MTB } }, timeout);
            if (dic != null)
                donendeger = new bayiStokTeslim(dic[0].ToString(), ConvertToInt32(dic[1]), ConvertToBool(dic[2]), ConvertToDateTime(dic[3]), ConvertToDateTime(dic[4]), ConvertToInt32(dic[5]), ConvertToInt32(dic[6]), dic[7].ToString(), dic[8].ToString());

            return donendeger;
        }

        public class bayiStokTeslimDetay : DbObj
        {

        }
    }
}
