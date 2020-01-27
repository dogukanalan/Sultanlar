using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class resimler : DbObj
    {
        public int pkResimID { get; set; }
        public byte[] binResim { get; set; }
        public byte[] binResimO { get; set; }
        public byte[] binResimK { get; set; }

        public resimler() { }
        public resimler(int pkResimID) { this.pkResimID = pkResimID; this.pkResimID = pkResimID; }
        private resimler(int pkResimID, byte[] binResim, byte[] binResimK, byte[] binResimO)
        {
            this.pkResimID = pkResimID;
            this.binResim = binResim;
            this.binResimK = binResimK;
            this.binResimO = binResimO;
        }
        
        public override string ToString() { return pkResimID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkResimID", pkResimID }, { "binResim", binResim }, { "binResimO", binResimO }, { "binResimK", binResimK } };
            pkResimID = ConvertToInt32(Do(QueryType.Insert, "db_sp_resimEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkResimID", pkResimID }, { "binResim", binResim }, { "binResimO", binResimO }, { "binResimK", binResimK } };
            Do(QueryType.Update, "db_sp_resimGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_resimSil", new Dictionary<string, object>() { { "pkResimID", pkResimID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public resimler GetObject()
        {
            resimler donendeger = new resimler();

            Dictionary<int, object> dic = GetObject("db_sp_resimGetir", new Dictionary<string, object>() { { "pkResimID", pkResimID } }, timeout);
            if (dic != null)
                donendeger = new resimler(ConvertToInt32(dic[0]), (byte[])dic[1], (byte[])dic[2], (byte[])dic[3]);

            return donendeger;
        }
    }
}
