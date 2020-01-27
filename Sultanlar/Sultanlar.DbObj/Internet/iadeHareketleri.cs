using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class iadeHareketleri : DbObj
    {
        public int pkID { get; set; }
        public int intIadeID { get; set; }
        //public iadeler Iade { get { return new iadeler(intIadeID).GetObject(); } }
        public int intIadeHareketTurID { get; set; }
        public iadeHareketTurleri Tur { get { return new iadeHareketTurleri(intIadeHareketTurID).GetObject(); } }
        public DateTime dtTarih { get; set; }
        public string strIslemYapan { get; set; }
        public string strAciklama { get; set; }

        public iadeHareketleri() { }
        public iadeHareketleri(int pkIadeID) { this.pkID = pkID; }
        public iadeHareketleri(int intIadeID, int intIadeHareketTurID, DateTime dtTarih, string strIslemYapan, string strAciklama)
        {
            this.intIadeID = intIadeID;
            this.intIadeHareketTurID = intIadeHareketTurID;
            this.dtTarih = dtTarih;
            this.strIslemYapan = strIslemYapan;
            this.strAciklama = strAciklama;
        }
        private iadeHareketleri(int pkID, int intIadeID, int intIadeHareketTurID, DateTime dtTarih, string strIslemYapan, string strAciklama)
        {
            this.pkID = pkID;
            this.intIadeID = intIadeID;
            this.intIadeHareketTurID = intIadeHareketTurID;
            this.dtTarih = dtTarih;
            this.strIslemYapan = strIslemYapan;
            this.strAciklama = strAciklama;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intIadeID", intIadeID }, { "intIadeHareketTurID", intIadeHareketTurID }, { "dtTarih", dtTarih }, { "strIslemYapan", strIslemYapan }, { "strAciklama", strAciklama } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_iadeHareketiEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intIadeID", intIadeID }, { "intIadeHareketTurID", intIadeHareketTurID }, { "dtTarih", dtTarih }, { "strIslemYapan", strIslemYapan }, { "strAciklama", strAciklama } };
            Do(QueryType.Update, "db_sp_iadeHareketiGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_iadeHareketiSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public iadeHareketleri GetObject()
        {
            iadeHareketleri donendeger = new iadeHareketleri();

            Dictionary<int, object> dic = GetObject("db_sp_iadeHareketiGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new iadeHareketleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToDateTime(dic[3]), dic[4].ToString(), dic[5].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeHareketleri> GetObjects(int IadeID)
        {
            List<iadeHareketleri> donendeger = new List<iadeHareketleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadeHareketleriGetir", new Dictionary<string, object>() { { "IadeID", IadeID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeHareketleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), dic[i][4].ToString(), dic[i][5].ToString()));

            return donendeger;
        }
    }
}
