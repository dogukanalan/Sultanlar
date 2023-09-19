using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class departmanlar : DbObj
    {
        public byte pkDepartmanID { get; set; }
        public string strDepartman { get; set; }
        public string strDepartmanEposta { get; set; }
        public bool blDepartmanWeb { get; set; }

        public departmanlar() { }
        public departmanlar(byte pkDepartmanID) { this.pkDepartmanID = pkDepartmanID; }
        public departmanlar(string strDepartman, string strDepartmanEposta, bool blDepartmanWeb)
        {
            this.strDepartman = strDepartman;
            this.strDepartmanEposta = strDepartmanEposta;
            this.blDepartmanWeb = blDepartmanWeb  ;
        }
        private departmanlar(byte pkDepartmanID, string strDepartman, string strDepartmanEposta, bool blDepartmanWeb)
        {
            this.pkDepartmanID = pkDepartmanID;
            this.strDepartman = strDepartman;
            this.strDepartmanEposta = strDepartmanEposta;
            this.blDepartmanWeb = blDepartmanWeb; 
        }

        public override string ToString() { return strDepartman; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkDepartmanID", pkDepartmanID }, { "strDepartman", strDepartman }, { "strDepartmanEposta", strDepartmanEposta }, { "blDepartmanWeb", blDepartmanWeb } };
            pkDepartmanID = ConvertToByte(Do(QueryType.Insert, "db_sp_departmanEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkDepartmanID", pkDepartmanID }, { "strDepartman", strDepartman }, { "strDepartmanEposta", strDepartmanEposta }, { "blDepartmanWeb", blDepartmanWeb } };
            Do(QueryType.Update, "db_sp_departmanGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_departmanSil", new Dictionary<string, object>() { { "pkDepartmanID", pkDepartmanID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public departmanlar GetObject()
        {
            departmanlar donendeger = new departmanlar();

            Dictionary<int, object> dic = GetObject("db_sp_departmanGetir", new Dictionary<string, object>() { { "pkDepartmanID", pkDepartmanID } }, timeout);
            if (dic != null)
                donendeger = new departmanlar(ConvertToByte(dic[0]), ConvertToString(dic[1]), ConvertToString(dic[2]), Convert.ToBoolean(dic[3]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<departmanlar> GetObjects(bool DepartmanWeb)
        {
            List<departmanlar> donendeger = new List<departmanlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_departmanlarGetir", new Dictionary<string, object>() { { "DepartmanWeb", DepartmanWeb } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new departmanlar(ConvertToByte(dic[i][0]), ConvertToString(dic[i][1]), ConvertToString(dic[i][2]), Convert.ToBoolean(dic[i][3])));

            return donendeger;
        }
    }
}
