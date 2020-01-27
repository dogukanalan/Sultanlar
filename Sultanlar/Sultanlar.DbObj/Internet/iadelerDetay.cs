using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class iadelerDetay : DbObj
    {
        public long pkIadeDetayID { get; set; }
        public int intIadeID { get; set; }
        //public iadeler Iade { get { return new iadeler(intIadeID).GetObject(); } }
        public int intUrunID { get; set; }
        public malzemeler Malzeme { get { return new malzemeler(intUrunID).GetObject(); } }
        public string strUrunAdi { get; set; }
        public int intMiktar { get; set; }
        public double mnFiyat { get; set; }

        public iadelerDetay() { }
        public iadelerDetay(long pkIadeDetayID) { this.pkIadeDetayID = pkIadeDetayID; }
        public iadelerDetay(int intIadeID, int intUrunID, string strUrunAdi, int intMiktar, double mnFiyat)
        {
            this.intIadeID = intIadeID;
            this.intUrunID = intUrunID;
            this.strUrunAdi = strUrunAdi;
            this.intMiktar = intMiktar;
            this.mnFiyat = mnFiyat;
        }
        private iadelerDetay(long pkIadeDetayID, int intIadeID, int intUrunID, string strUrunAdi, int intMiktar, double mnFiyat)
        {
            this.pkIadeDetayID = pkIadeDetayID;
            this.intIadeID = intIadeID;
            this.intUrunID = intUrunID;
            this.strUrunAdi = strUrunAdi;
            this.intMiktar = intMiktar;
            this.mnFiyat = mnFiyat;
        }

        public override string ToString() { return pkIadeDetayID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkIadeDetayID", pkIadeDetayID }, { "intIadeID", intIadeID }, { "intUrunID", intUrunID }, { "strUrunAdi", strUrunAdi }, { "intMiktar", intMiktar }, { "mnFiyat", mnFiyat } };
            pkIadeDetayID = ConvertToInt32(Do(QueryType.Insert, "db_sp_iadelerDetayEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkIadeDetayID", pkIadeDetayID }, { "intIadeID", intIadeID }, { "intUrunID", intUrunID }, { "strUrunAdi", strUrunAdi }, { "intMiktar", intMiktar }, { "mnFiyat", mnFiyat } };
            Do(QueryType.Update, "db_sp_iadelerDetayGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_iadelerDetaySil", new Dictionary<string, object>() { { "pkIadeDetayID", pkIadeDetayID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public iadelerDetay GetObject()
        {
            iadelerDetay donendeger = new iadelerDetay();

            Dictionary<int, object> dic = GetObject("db_sp_iadelerDetayGetir", new Dictionary<string, object>() { { "pkIadeDetayID", pkIadeDetayID } }, timeout);
            if (dic != null)
                donendeger = new iadelerDetay(ConvertToInt64(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), ConvertToInt32(dic[4]), ConvertToDouble(dic[5]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadelerDetay> GetObjects(int intIadeID)
        {
            List<iadelerDetay> donendeger = new List<iadelerDetay>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadelerDetaylarGetir", new Dictionary<string, object>() { { "intIadeID", intIadeID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadelerDetay(ConvertToInt64(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), dic[i][3].ToString(), ConvertToInt32(dic[i][4]), ConvertToDouble(dic[i][5])));

            return donendeger;
        }
    }
}
