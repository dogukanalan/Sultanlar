using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class ziyaretvaryok : DbObj
    {
        public int pkID { get; set; }
        public string BARKOD { get; set; }
        public ziyaretler Ziyaret { get { return new ziyaretler().GetObjectByBarkod(BARKOD); } }
        public int FIYAT_TIP { get; set; }
        public DateTime TARIH { get; set; }
        public List<ziyaretvaryokdetay> detays { get { return new ziyaretvaryokdetay().GetObjects(pkID);  } }

        public ziyaretvaryok() { }
        private ziyaretvaryok(int pkID, string BARKOD, int FIYAT_TIP, DateTime TARIH) { this.pkID = pkID; this.BARKOD = BARKOD; this.FIYAT_TIP = FIYAT_TIP; this.TARIH = TARIH; }

        public override string ToString() { return BARKOD; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "BARKOD", BARKOD }, { "FIYAT_TIP", FIYAT_TIP }, { "TARIH", TARIH } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_ziyaretVaryokEkle", param, timeout));
        }
        /// <summary>
        /// detaylarla
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_ziyaretVaryokSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public ziyaretvaryok GetObject(string BARKOD)
        {
            ziyaretvaryok donendeger = new ziyaretvaryok();
            donendeger.BARKOD = "";

            Dictionary<int, object> dic = GetObject("db_sp_ziyaretVaryokGetir", new Dictionary<string, object>() { { "BARKOD", BARKOD } }, timeout);
            if (dic != null)
                donendeger = new ziyaretvaryok(ConvertToInt32(dic[0]), dic[1].ToString(), ConvertToInt32(dic[2]), ConvertToDateTime(dic[3]));

            return donendeger;
        }
    }
    public class ziyaretvaryokdetay : DbObj
    {
        public int pkID { get; set; }
        public int VARYOK_ID { get; set; }
        public int ITEMREF { get; set; }
        public malzemeler Malzeme { get { return new malzemeler(ITEMREF).GetObject(); } }
        public object VARYOK { get; set; }
        public bool DEPO { get; set; }
        public bool RAF { get; set; }
        public double RAF_FIYAT { get; set; }
        public bool SKT { get; set; }
        public int SIPARIS { get; set; }
        public bool ISARET { get { return VARYOK is null ? false : true; /*Convert.ToBoolean(GetObjectSc("SELECT CASE WHEN VARYOK IS NULL THEN 'False' ELSE 'True' END FROM WEB_RUT_6_VARYOK_DETAY WHERE pkID = @pkID", new Dictionary<string, object>() { { "pkID", pkID } }, timeout));*/ } }

        public ziyaretvaryokdetay() { }
        public ziyaretvaryokdetay(int pkID, int VARYOK_ID, int ITEMREF, object VARYOK, bool DEPO, bool RAF, double RAF_FIYAT, bool SKT, int SIPARIS) 
        { 
            this.pkID = pkID; this.VARYOK_ID = VARYOK_ID; this.ITEMREF = ITEMREF; this.VARYOK = VARYOK; this.DEPO = DEPO; this.RAF = RAF; this.RAF_FIYAT = RAF_FIYAT; this.SKT = SKT; this.SIPARIS = SIPARIS;
        }

        public override string ToString() { return Malzeme.MALACIK; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "VARYOK_ID", VARYOK_ID }, { "ITEMREF", ITEMREF }, { "VARYOK", VARYOK }, { "DEPO", DEPO }, { "RAF", RAF }, { "RAF_FIYAT", RAF_FIYAT }, { "SKT", SKT }, { "SIPARIS", SIPARIS } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_ziyaretVaryokDetayEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public void DoInsertNull()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "VARYOK_ID", VARYOK_ID }, { "ITEMREF", ITEMREF }, { "VARYOK", DBNull.Value }, { "DEPO", DBNull.Value }, { "RAF", DBNull.Value }, { "RAF_FIYAT", DBNull.Value }, { "SKT", DBNull.Value }, { "SIPARIS", DBNull.Value } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_ziyaretVaryokDetayEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public List<ziyaretvaryokdetay> GetObjects(int VarYokID)
        {
            List<ziyaretvaryokdetay> donendeger = new List<ziyaretvaryokdetay>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_ziyaretVaryokDetaylarGetir", new Dictionary<string, object>() { { "VarYokID", VarYokID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new ziyaretvaryokdetay(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), dic[i][3] == DBNull.Value ? null : dic[i][3], ConvertToBool(dic[i][4]), ConvertToBool(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToBool(dic[i][7]), ConvertToInt32(dic[i][8])));

            return donendeger;
        }
    }
}
