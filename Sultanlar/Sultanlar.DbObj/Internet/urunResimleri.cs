using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class urunResimleri : DbObj
    {
        public int ITEMREF { get; set; }
        public int intResimID { get; set; }
        public DateTime dtEklenme { get; set; }
        public string strEkleyen { get; set; }

        public urunResimleri() { }
        public urunResimleri(int ITEMREF, int intResimID) { this.ITEMREF = ITEMREF; this.intResimID = intResimID; }
        private urunResimleri(int ITEMREF, int intResimID, DateTime dtEklenme, string strEkleyen)
        {
            this.ITEMREF = ITEMREF;
            this.intResimID = intResimID;
            this.dtEklenme = dtEklenme;
            this.strEkleyen = strEkleyen;
        }

        public override string ToString() { return dtEklenme.ToShortDateString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ITEMREF", ITEMREF }, { "intResimID", intResimID }, { "dtEklenme", dtEklenme }, { "strEkleyen", strEkleyen } };
            Do(QueryType.Update, "db_sp_urunResimleriEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ITEMREF", ITEMREF }, { "intResimID", intResimID }, { "dtEklenme", dtEklenme }, { "strEkleyen", strEkleyen } };
            Do(QueryType.Update, "db_sp_urunResimleriGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_urunResimleriSil", new Dictionary<string, object>() { { "ITEMREF", ITEMREF }, { "intResimID", intResimID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public urunResimleri GetObject()
        {
            urunResimleri donendeger = new urunResimleri();

            Dictionary<int, object> dic = GetObject("db_sp_urunResimGetir", new Dictionary<string, object>() { { "ITEMREF", ITEMREF }, { "intResimID", intResimID } }, timeout);
            if (dic != null)
                donendeger = new urunResimleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToDateTime(dic[2]), dic[3].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<urunResimleri> GetObjects()
        {
            List<urunResimleri> donendeger = new List<urunResimleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_urunResimleriGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new urunResimleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToDateTime(dic[i][2]), dic[i][3].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<urunResimleri> GetObjects(int ITEMREF)
        {
            List<urunResimleri> donendeger = new List<urunResimleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_urunResimleriGetirByITEMREF", new Dictionary<string, object>() { { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new urunResimleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToDateTime(dic[i][2]), dic[i][3].ToString()));

            return donendeger;
        }
    }
}
