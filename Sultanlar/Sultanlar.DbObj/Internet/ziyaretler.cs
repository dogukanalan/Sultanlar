using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class ziyaretler : DbObj
    {
        public int MTIP { get; set; }
        public int RUT_TUR { get; set; }
        public string RutTuru { get { return RUT_TUR == 1 ? "PLANLI RUT" : "PLANSIZ RUT"; } }
        public string RUT_ID { get; set; }
        public int GMREF { get; set; }
        public cariHesaplar AnaCari { get { return new cariHesaplar().GetObject1(MTIP, GMREF); } }
        public int SMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar().GetObject1(MTIP, SMREF); } }
        public int SLSREF { get; set; }
        public satisTemsilcileri Satici { get { return new satisTemsilcileri(SLSREF).GetObject(); } }
        public string BARKOD { get; set; }
        public DateTime ZIY_BAS_TAR { get; set; }
        public DateTime ZIY_BIT_TAR { get; set; }
        public int ZIY_NDN_ID { get; set; }
        public ziyaretSonlandirmaSebepleri ZiyaretNeden {  get { return new ziyaretSonlandirmaSebepleri(ZIY_NDN_ID).GetObject(); } }
        public string ZIY_KONUM { get; set; }
        public string ZIY_KONUM_ADRES { get; set; }
        public string ZIY_KONUM_CIKIS { get; set; }
        public string ZIY_KONUM_ADRES_CIKIS { get; set; }
        public int FARK_KNM_ZIY { get; set; }
        public byte[] ZIY_KONUM_RESIM { get; set; }
        public string ZIY_NOTLARI { get; set; }
        public int ZIY_SIP { get; set; }
        public int ZIY_AKT { get; set; }
        public int ZIY_IAD { get; set; }
        public int ZIY_TAH { get; set; }
        public string YOL { get; set; }

        public ziyaretler() { }
        public ziyaretler(int MTIP, int SMREF, int SLSREF, DateTime ZIY_BAS_TAR) { this.MTIP = MTIP; this.SMREF = SMREF; this.SLSREF = SLSREF; this.ZIY_BAS_TAR = ZIY_BAS_TAR; }
        public ziyaretler(int MTIP, int RUT_TUR, string RUT_ID, int GMREF, int SMREF, int SLSREF, string BARKOD, DateTime ZIY_BAS_TAR, DateTime ZIY_BIT_TAR, int ZIY_NDN_ID, string ZIY_KONUM, string ZIY_KONUM_ADRES, string ZIY_KONUM_CIKIS, string ZIY_KONUM_ADRES_CIKIS, int FARK_KNM_ZIY, byte[] ZIY_KONUM_RESIM, string ZIY_NOTLARI, int ZIY_SIP, int ZIY_AKT, int ZIY_IAD, int ZIY_TAH, string YOL)
        {
            this.MTIP = MTIP;
            this.RUT_TUR = RUT_TUR;
            this.RUT_ID = RUT_ID;
            this.GMREF = GMREF;
            this.SMREF = SMREF;
            this.SLSREF = SLSREF;
            this.BARKOD = BARKOD;
            this.ZIY_BAS_TAR = ZIY_BAS_TAR;
            this.ZIY_BIT_TAR = ZIY_BIT_TAR;
            this.ZIY_NDN_ID = ZIY_NDN_ID;
            this.ZIY_KONUM = ZIY_KONUM;
            this.ZIY_KONUM_ADRES = ZIY_KONUM_ADRES;
            this.ZIY_KONUM_CIKIS = ZIY_KONUM_CIKIS;
            this.ZIY_KONUM_ADRES_CIKIS = ZIY_KONUM_ADRES_CIKIS;
            this.FARK_KNM_ZIY = FARK_KNM_ZIY;
            this.ZIY_KONUM_RESIM = ZIY_KONUM_RESIM;
            this.ZIY_NOTLARI = ZIY_NOTLARI;
            this.ZIY_SIP = ZIY_SIP;
            this.ZIY_AKT = ZIY_AKT;
            this.ZIY_IAD = ZIY_IAD;
            this.ZIY_TAH = ZIY_TAH;
            this.YOL = YOL;
        }

        public override string ToString() { return RUT_ID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "MTIP", MTIP }, { "RUT_TUR", RUT_TUR }, { "RUT_ID", RUT_ID }, { "GMREF", GMREF }, { "SMREF", SMREF }, { "SLSREF", SLSREF }, { "BARKOD", BARKOD }, { "ZIY_BAS_TAR", ZIY_BAS_TAR }, { "ZIY_BIT_TAR", ZIY_BIT_TAR }, { "ZIY_NDN_ID", ZIY_NDN_ID }, { "ZIY_KONUM", ZIY_KONUM }, { "ZIY_KONUM_ADRES", ZIY_KONUM_ADRES }, { "ZIY_KONUM_CIKIS", ZIY_KONUM_CIKIS }, { "ZIY_KONUM_ADRES_CIKIS", ZIY_KONUM_ADRES_CIKIS }, { "FARK_KNM_ZIY", FARK_KNM_ZIY }, { "ZIY_KONUM_RESIM", ZIY_KONUM_RESIM }, { "ZIY_NOTLARI", ZIY_NOTLARI }, { "ZIY_SIP", ZIY_SIP }, { "ZIY_AKT", ZIY_AKT }, { "ZIY_IAD", ZIY_IAD }, { "ZIY_TAH", ZIY_TAH }, { "YOL", YOL } };
            Do(QueryType.Update, "db_sp_ziyaretEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "MTIP", MTIP }, { "RUT_TUR", RUT_TUR }, { "RUT_ID", RUT_ID }, { "GMREF", GMREF }, { "SMREF", SMREF }, { "SLSREF", SLSREF }, { "BARKOD", BARKOD }, { "ZIY_BAS_TAR", ZIY_BAS_TAR }, { "ZIY_BIT_TAR", ZIY_BIT_TAR }, { "ZIY_NDN_ID", ZIY_NDN_ID }, { "ZIY_KONUM", ZIY_KONUM }, { "ZIY_KONUM_ADRES", ZIY_KONUM_ADRES }, { "ZIY_KONUM_CIKIS", ZIY_KONUM_CIKIS }, { "ZIY_KONUM_ADRES_CIKIS", ZIY_KONUM_ADRES_CIKIS }, { "FARK_KNM_ZIY", FARK_KNM_ZIY }, { "ZIY_KONUM_RESIM", ZIY_KONUM_RESIM }, { "ZIY_NOTLARI", ZIY_NOTLARI }, { "ZIY_SIP", ZIY_SIP }, { "ZIY_AKT", ZIY_AKT }, { "ZIY_IAD", ZIY_IAD }, { "ZIY_TAH", ZIY_TAH }, { "YOL", YOL } };
            Do(QueryType.Update, "db_sp_ziyaretGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_ziyaretSil", new Dictionary<string, object>() { { "MTIP", MTIP }, { "SMREF", SMREF }, { "SLSREF", SLSREF }, { "ZIY_BAS_TAR", ZIY_BAS_TAR } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ziyaretler GetObject()
        {
            ziyaretler donendeger = new ziyaretler();

            Dictionary<int, object> dic = GetObject("db_sp_ziyaretGetir", new Dictionary<string, object>() { { "MTIP", MTIP }, { "SMREF", SMREF }, { "SLSREF", SLSREF }, { "ZIY_BAS_TAR", ZIY_BAS_TAR } }, timeout);
            if (dic != null)
                donendeger = new ziyaretler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]), dic[6].ToString(), ConvertToDateTime(dic[7]), ConvertToDateTime(dic[8]), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), dic[13].ToString(), ConvertToInt32(dic[14]), new byte[] { }, dic[16].ToString(), ConvertToInt32(dic[17]), ConvertToInt32(dic[18]), ConvertToInt32(dic[19]), ConvertToInt32(dic[20]), dic[21].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ziyaretler GetObjectByRutID(string RUT_ID)
        {
            ziyaretler donendeger = new ziyaretler();

            Dictionary<int, object> dic = GetObject("db_sp_ziyaretGetirByRutID", new Dictionary<string, object>() { { "RUT_ID", RUT_ID } }, timeout);
            if (dic != null)
                donendeger = new ziyaretler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]), dic[6].ToString(), ConvertToDateTime(dic[7]), ConvertToDateTime(dic[8]), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), dic[13].ToString(), ConvertToInt32(dic[14]), new byte[] { }, dic[16].ToString(), ConvertToInt32(dic[17]), ConvertToInt32(dic[18]), ConvertToInt32(dic[19]), ConvertToInt32(dic[20]), dic[21].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ziyaretler GetObjectByBarkod(string BARKOD)
        {
            ziyaretler donendeger = new ziyaretler();

            Dictionary<int, object> dic = GetObject("db_sp_ziyaretGetirByBARKOD", new Dictionary<string, object>() { { "BARKOD", BARKOD } }, timeout);
            if (dic != null)
                donendeger = new ziyaretler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]), dic[6].ToString(), ConvertToDateTime(dic[7]), ConvertToDateTime(dic[8]), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), dic[13].ToString(), ConvertToInt32(dic[14]), new byte[] { }, dic[16].ToString(), ConvertToInt32(dic[17]), ConvertToInt32(dic[18]), ConvertToInt32(dic[19]), ConvertToInt32(dic[20]), dic[21].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ziyaretler> GetObjects(int Yil, object Ay)
        {
            List<ziyaretler> donendeger = new List<ziyaretler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_ziyaretlerGetir", new Dictionary<string, object>() { { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new ziyaretler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), dic[i][6].ToString(), ConvertToDateTime(dic[i][7]), ConvertToDateTime(dic[i][8]), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), ConvertToInt32(dic[i][14]), new byte[] { }, dic[i][16].ToString(), ConvertToInt32(dic[i][17]), ConvertToInt32(dic[i][18]), ConvertToInt32(dic[i][19]), ConvertToInt32(dic[i][20]), dic[i][21].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ziyaretler> GetObjectsBySLSREF(int SLSREF, int Yil, object Ay)
        {
            List<ziyaretler> donendeger = new List<ziyaretler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_ziyaretlerGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new ziyaretler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), dic[i][6].ToString(), ConvertToDateTime(dic[i][7]), ConvertToDateTime(dic[i][8]), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), ConvertToInt32(dic[i][14]), new byte[] { }, dic[i][16].ToString(), ConvertToInt32(dic[i][17]), ConvertToInt32(dic[i][18]), ConvertToInt32(dic[i][19]), ConvertToInt32(dic[i][20]), dic[i][21].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ziyaretler> GetObjectsByGMREF(int SLSREF, int GMREF, int Yil, object Ay)
        {
            List<ziyaretler> donendeger = new List<ziyaretler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_ziyaretlerGetirByGMREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "GMREF", GMREF }, { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new ziyaretler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), dic[i][6].ToString(), ConvertToDateTime(dic[i][7]), ConvertToDateTime(dic[i][8]), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), ConvertToInt32(dic[i][14]), new byte[] { }, dic[i][16].ToString(), ConvertToInt32(dic[i][17]), ConvertToInt32(dic[i][18]), ConvertToInt32(dic[i][19]), ConvertToInt32(dic[i][20]), dic[i][21].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ziyaretler> GetObjectsBySMREF(int SLSREF, int MTIP, int SMREF, int Yil, object Ay)
        {
            List<ziyaretler> donendeger = new List<ziyaretler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_ziyaretlerGetirBySMREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "MTIP", MTIP }, { "SMREF", SMREF }, { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new ziyaretler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), dic[i][6].ToString(), ConvertToDateTime(dic[i][7]), ConvertToDateTime(dic[i][8]), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), ConvertToInt32(dic[i][14]), new byte[] { }, dic[i][16].ToString(), ConvertToInt32(dic[i][17]), ConvertToInt32(dic[i][18]), ConvertToInt32(dic[i][19]), ConvertToInt32(dic[i][20]), dic[i][21].ToString()));

            return donendeger;
        }
    }
}
