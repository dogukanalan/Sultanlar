using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class isyeriOzelKod2 : DbObj
    {
        public int pkID { get; set; }
        public int intGrup { get; set; }
        public string strOzelKod { get; set; }
        public short sintIsyeriKod { get; set; }
        public short sintAmbarKod { get; set; }

        public isyeriOzelKod2() { }
        public isyeriOzelKod2(int pkID) { this.pkID = pkID; }
        private isyeriOzelKod2(int pkID, int intGrup, string strOzelKod, short sintIsyeriKod, short sintAmbarKod)
        {
            this.pkID = pkID;
            this.intGrup = intGrup;
            this.strOzelKod = strOzelKod;
            this.sintIsyeriKod = sintIsyeriKod;
            this.sintAmbarKod = sintAmbarKod;
        }

        public override string ToString() { return pkID.ToString(); }
        /*/// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intGrup", intGrup }, { "strOzelKod", strOzelKod }, { "sintIsyeriKod", sintIsyeriKod }, { "sintAmbarKod", sintAmbarKod } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intGrup", intGrup }, { "strOzelKod", strOzelKod }, { "sintIsyeriKod", sintIsyeriKod }, { "sintAmbarKod", sintAmbarKod } };
            Do(QueryType.Update, "", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<isyeriOzelKod2> GetObjects()
        {
            List<isyeriOzelKod2> donendeger = new List<isyeriOzelKod2>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_isyeriOzelKod2Getir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new isyeriOzelKod2(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), ConvertToInt16(dic[i][3]), ConvertToInt16(dic[i][4])));

            return donendeger;
        }
    }
}
