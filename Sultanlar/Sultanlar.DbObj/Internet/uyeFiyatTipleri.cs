using System;
using System.Collections.Generic;

namespace Sultanlar.DbObj.Internet
{
    public class uyeFiyatTipleri : DbObj
    {
        public int pkID { get; set; }
        public int intMusteriID { get; set; }
        public short sintFiyatTipiID { get; set; }
        public fiyatTipleri FiyatTipi { get { return new fiyatTipleri(sintFiyatTipiID).GetObject(); } }

        public uyeFiyatTipleri() { }
        public uyeFiyatTipleri(int pkID) { this.pkID = pkID; }
        private uyeFiyatTipleri(int pkID, int intMusteriID, short sintFiyatTipiID)
        {
            this.pkID = pkID;
            this.intMusteriID = intMusteriID;
            this.sintFiyatTipiID = sintFiyatTipiID;
        }
        
        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "sintFiyatTipiID", sintFiyatTipiID } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_uyeFiyatTipiEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "sintFiyatTipiID", sintFiyatTipiID } };
            Do(QueryType.Update, "db_sp_uyeFiyatTipiGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_uyeFiyatTipiSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uyeFiyatTipleri GetObject()
        {
            uyeFiyatTipleri donendeger = new uyeFiyatTipleri();

            Dictionary<int, object> dic = GetObject("db_sp_uyeFiyatTipiGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new uyeFiyatTipleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt16(dic[2]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<uyeFiyatTipleri> GetObjects()
        {
            List<uyeFiyatTipleri> donendeger = new List<uyeFiyatTipleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_uyeFiyatTipleriGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new uyeFiyatTipleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt16(dic[i][2])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<uyeFiyatTipleri> GetObjectsByMusteriID(int MusteriID)
        {
            List<uyeFiyatTipleri> donendeger = new List<uyeFiyatTipleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_uyeFiyatTipleriGetirByMusteriID", new Dictionary<string, object>() { { "intMusteriID", MusteriID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new uyeFiyatTipleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt16(dic[i][2])));

            return donendeger;
        }
    }
}
