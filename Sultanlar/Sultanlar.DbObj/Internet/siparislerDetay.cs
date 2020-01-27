using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class siparislerDetay : DbObj
    {
        public long pkSiparisDetayID { get; set; }
        public int intSiparisID { get; set; }
        //public siparisler Siparis { get { return new siparisler(intSiparisID).GetObject(); } }
        public int intUrunID { get; set; }
        public malzemeler Malzeme { get { return new malzemeler(intUrunID).GetObject(); } }
        public string strUrunAdi { get; set; }
        public int intMiktar { get; set; }
        public double mnFiyat { get; set; }
        public Guid unKampanyaKart { get; set; }
        public bool blKampanyaHediye { get; set; }
        public Guid unKampanyaSatir { get; set; }
        public string strMiktarTur { get; set; }

        public siparislerDetayISKs isks { get { return new siparislerDetayISKs(pkSiparisDetayID).GetObject(); } }

        public siparislerDetay() { }
        public siparislerDetay(long pkSiparisDetayID) { this.pkSiparisDetayID = pkSiparisDetayID; }
        public siparislerDetay(int intSiparisID, int intUrunID, string strUrunAdi, int intMiktar, double mnFiyat, Guid unKampanyaKart, bool blKampanyaHediye, Guid unKampanyaSatir, string strMiktarTur)
        {
            this.intSiparisID = intSiparisID;
            this.intUrunID = intUrunID;
            this.strUrunAdi = strUrunAdi;
            this.intMiktar = intMiktar;
            this.mnFiyat = mnFiyat;
            this.unKampanyaKart = unKampanyaKart;
            this.blKampanyaHediye = blKampanyaHediye;
            this.unKampanyaSatir = unKampanyaSatir;
            this.strMiktarTur = strMiktarTur;
        }
        private siparislerDetay(long pkSiparisDetayID, int intSiparisID, int intUrunID, string strUrunAdi, int intMiktar, double mnFiyat, Guid unKampanyaKart, bool blKampanyaHediye, Guid unKampanyaSatir, string strMiktarTur)
        {
            this.pkSiparisDetayID = pkSiparisDetayID;
            this.intSiparisID = intSiparisID;
            this.intUrunID = intUrunID;
            this.strUrunAdi = strUrunAdi;
            this.intMiktar = intMiktar;
            this.mnFiyat = mnFiyat;
            this.unKampanyaKart = unKampanyaKart;
            this.blKampanyaHediye = blKampanyaHediye;
            this.unKampanyaSatir = unKampanyaSatir;
            this.strMiktarTur = strMiktarTur;
        }

        public override string ToString() { return pkSiparisDetayID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkSiparisDetayID", pkSiparisDetayID }, { "intSiparisID", intSiparisID }, { "intUrunID", intUrunID }, { "strUrunAdi", strUrunAdi }, { "intMiktar", intMiktar }, { "mnFiyat", mnFiyat }, { "unKampanyaKart", unKampanyaKart }, { "blKampanyaHediye", blKampanyaHediye }, { "unKampanyaSatir", unKampanyaSatir }, { "strMiktarTur", strMiktarTur } };
            pkSiparisDetayID = ConvertToInt32(Do(QueryType.Insert, "db_sp_siparislerDetayEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkSiparisDetayID", pkSiparisDetayID }, { "intSiparisID", intSiparisID }, { "intUrunID", intUrunID }, { "strUrunAdi", strUrunAdi }, { "intMiktar", intMiktar }, { "mnFiyat", mnFiyat }, { "unKampanyaKart", unKampanyaKart }, { "blKampanyaHediye", blKampanyaHediye }, { "unKampanyaSatir", unKampanyaSatir }, { "strMiktarTur", strMiktarTur } };
            Do(QueryType.Update, "db_sp_siparislerDetayGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_siparislerDetaySil", new Dictionary<string, object>() { { "pkSiparisDetayID", pkSiparisDetayID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public siparislerDetay GetObject()
        {
            siparislerDetay donendeger = new siparislerDetay();

            Dictionary<int, object> dic = GetObject("db_sp_siparislerDetayGetir", new Dictionary<string, object>() { { "pkSiparisDetayID", pkSiparisDetayID } }, timeout);
            if (dic != null)
                donendeger = new siparislerDetay(ConvertToInt64(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), ConvertToInt32(dic[4]), ConvertToDouble(dic[5]), ConvertToGuid(dic[6].ToString()), Convert.ToBoolean(dic[7]), ConvertToGuid(dic[8].ToString()), dic[9].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparislerDetay> GetObjects(int SiparisID)
        {
            List<siparislerDetay> donendeger = new List<siparislerDetay>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerDetaylarGetir", new Dictionary<string, object>() { { "intSiparisID", SiparisID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparislerDetay(ConvertToInt64(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), dic[i][3].ToString(), ConvertToInt32(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToGuid(dic[i][6].ToString()), Convert.ToBoolean(dic[i][7]), ConvertToGuid(dic[i][8].ToString()), dic[i][9].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DoUpdateISKs(long EskiSiparisDetayID, long YeniSiparisDetayID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "EskiSiparisDetayID", EskiSiparisDetayID }, { "YeniSiparisDetayID", YeniSiparisDetayID } };
            Do(QueryType.Update, "db_sp_siparislerDetayISKGuncelle", param, timeout);
        }
    }

    public class siparislerDetayISKs : DbObj
    {
        public long bintSiparisDetayID { get; set; }
        public double FIYAT { get; set; }
        public double ISK1 { get; set; }
        public double ISK2 { get; set; }
        public double ISK3 { get; set; }
        public double ISK4 { get; set; }
        public double ISK5 { get; set; }
        public double ISK6 { get; set; }
        public double ISK7 { get; set; }
        public double ISK8 { get; set; }
        public double ISK9 { get; set; }
        public double ISK10 { get; set; }
        private siparislerDetayISKs() { }
        public siparislerDetayISKs(long bintSiparisDetayID) { this.bintSiparisDetayID = bintSiparisDetayID; }
        private siparislerDetayISKs(long bintSiparisDetayID, double FIYAT, double ISK1, double ISK2, double ISK3, double ISK4, double ISK5, double ISK6, double ISK7, double ISK8, double ISK9, double ISK10)
        {
            this.bintSiparisDetayID = bintSiparisDetayID;
            this.FIYAT = FIYAT;
            this.ISK1 = ISK1;
            this.ISK2 = ISK2;
            this.ISK3 = ISK3;
            this.ISK4 = ISK4;
            this.ISK5 = ISK5;
            this.ISK6 = ISK6;
            this.ISK7 = ISK7;
            this.ISK8 = ISK8;
            this.ISK9 = ISK9;
            this.ISK10 = ISK10;
        }
        /// <summary>
        /// 
        /// </summary>
        public siparislerDetayISKs GetObject()
        {
            siparislerDetayISKs donendeger = new siparislerDetayISKs();

            Dictionary<int, object> dic = GetObject("db_sp_siparislerDetayISKGetir", new Dictionary<string, object>() { { "bintSiparisDetayID", bintSiparisDetayID } }, timeout);
            if (dic != null)
                donendeger = new siparislerDetayISKs(ConvertToInt64(dic[0]), ConvertToDouble(dic[1]), ConvertToDouble(dic[2]), ConvertToDouble(dic[3]), ConvertToDouble(dic[4]), ConvertToDouble(dic[5]), ConvertToDouble(dic[6]), ConvertToDouble(dic[7]), ConvertToDouble(dic[8]), ConvertToDouble(dic[9]), ConvertToDouble(dic[10]), ConvertToDouble(dic[11]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<siparislerDetayISKs> GetObjects()
        {
            List<siparislerDetayISKs> donendeger = new List<siparislerDetayISKs>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerDetayISKsGetir", timeout);
            for (int i = 0; i < dic.Count; i++)
                donendeger.Add(new siparislerDetayISKs(ConvertToInt64(dic[i][0]), ConvertToDouble(dic[i][1]), ConvertToDouble(dic[i][2]), ConvertToDouble(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11])));

            return donendeger;
        }
    }
}
