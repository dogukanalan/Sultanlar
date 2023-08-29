using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class iadeFiyatAdet : DbObj
    {
        public long ID { get; set; }
        public long bintIadeDetayID { get; set; }
        public iadelerDetay IadeDetay { get { iadelerDetay iadedetay = new iadelerDetay(bintIadeDetayID).GetObject(); return iadedetay; } }
        public iadeler Iade { get { return bintIadeDetayID > 0 ? new iadeler(IadeDetay.intIadeID).GetObject() : new iadeler(); }  }
        public long bintSiparisDetayID { get; set; }
        public siparislerDetay SiparisDetay { get { return new siparislerDetay(bintSiparisDetayID).GetObject(); } }
        public siparisler Siparis { get { return new siparisler(SiparisDetay.intSiparisID).GetObject(); } }
        public int intIadeMiktar { get; set; }

        public iadeFiyatAdet() { }
        public iadeFiyatAdet(long ID) { this.ID = ID; }
        public iadeFiyatAdet(long bintIadeDetayID, long bintSiparisDetayID, int intIadeMiktar)
        {
            this.bintIadeDetayID = bintIadeDetayID;
            this.bintSiparisDetayID = bintSiparisDetayID;
            this.intIadeMiktar = intIadeMiktar;
        }
        private iadeFiyatAdet(long ID, long bintIadeDetayID, long bintSiparisDetayID, int intIadeMiktar)
        {
            this.ID = ID;
            this.bintIadeDetayID = bintIadeDetayID;
            this.bintSiparisDetayID = bintSiparisDetayID;
            this.intIadeMiktar = intIadeMiktar;
        }

        public override string ToString() { return ID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "bintIadeDetayID", bintIadeDetayID }, { "bintSiparisDetayID", bintSiparisDetayID }, { "intIadeMiktar", intIadeMiktar } };
            ID = ConvertToByte(Do(QueryType.Insert, "db_sp_iadeFiyatAdetEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "bintIadeDetayID", bintIadeDetayID }, { "bintSiparisDetayID", bintSiparisDetayID }, { "intIadeMiktar", intIadeMiktar } };
            Do(QueryType.Update, "db_sp_iadeFiyatAdetGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_iadeFiyatAdetSil", new Dictionary<string, object>() { { "ID", ID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public iadeFiyatAdet GetObject()
        {
            iadeFiyatAdet donendeger = new iadeFiyatAdet();

            Dictionary<int, object> dic = GetObject("db_sp_iadeFiyatAdetGetir", new Dictionary<string, object>() { { "ID", ID } }, timeout);
            if (dic != null)
                donendeger = new iadeFiyatAdet(ConvertToInt64(dic[0]), ConvertToInt64(dic[1]), ConvertToInt64(dic[2]), ConvertToInt32(dic[3]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeFiyatAdet> GetObjects(int SMREF, int ITEMREF)
        {
            List<iadeFiyatAdet> donendeger = new List<iadeFiyatAdet>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadeFiyatAdetlerGetir", new Dictionary<string, object>() { { "SMREF", SMREF }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeFiyatAdet(ConvertToInt64(dic[i][0]), ConvertToInt64(dic[i][1]), ConvertToInt64(dic[i][2]), ConvertToInt32(dic[i][3])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeFiyatAdet> GetObjects(long IadeDetayID)
        {
            List<iadeFiyatAdet> donendeger = new List<iadeFiyatAdet>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadeFiyatAdetlerGetirByIadeDetayID", new Dictionary<string, object>() { { "@bintIadeDetayID", IadeDetayID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeFiyatAdet(ConvertToInt64(dic[i][0]), ConvertToInt64(dic[i][1]), ConvertToInt64(dic[i][2]), ConvertToInt32(dic[i][3])));

            return donendeger;
        }
    }
}
