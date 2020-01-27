using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class uyeGrubuFiyatTipleri : DbObj
    {
        private int pkID { get; set; }
        public int intUyeGrupID { get; set; }
        public short sintFiyatTipiID { get; set; }
        public fiyatTipleri FiyatTipi { get { return new fiyatTipleri(sintFiyatTipiID).GetObject(); } }

        public uyeGrubuFiyatTipleri() { }
        public uyeGrubuFiyatTipleri(int pkID) { this.pkID = pkID; }
        private uyeGrubuFiyatTipleri(int pkID, int intUyeGrupID, short sintFiyatTipiID)
        {
            this.pkID = pkID;
            this.intUyeGrupID = intUyeGrupID;
            this.sintFiyatTipiID = sintFiyatTipiID;
        }
        
        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intUyeGrupID", intUyeGrupID }, { "sintFiyatTipiID", sintFiyatTipiID } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_uyeGrubuFiyatTipiEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intUyeGrupID", intUyeGrupID }, { "sintFiyatTipiID", sintFiyatTipiID } };
            Do(QueryType.Update, "db_sp_uyeGrubuFiyatTipiGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_uyeGrubuFiyatTipiSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uyeGrubuFiyatTipleri GetObject()
        {
            uyeGrubuFiyatTipleri donendeger = new uyeGrubuFiyatTipleri();

            Dictionary<int, object> dic = GetObject("db_sp_uyeGrubuFiyatTipiGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new uyeGrubuFiyatTipleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt16(dic[2]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<uyeGrubuFiyatTipleri> GetObjects()
        {
            List<uyeGrubuFiyatTipleri> donendeger = new List<uyeGrubuFiyatTipleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_uyeGrubuFiyatTipileriGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new uyeGrubuFiyatTipleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt16(dic[i][2])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<uyeGrubuFiyatTipleri> GetObjectsByUyeGrupID(int UyeGrupID)
        {
            List<uyeGrubuFiyatTipleri> donendeger = new List<uyeGrubuFiyatTipleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_uyeGrubuFiyatTipleriGetirByUyeGrupID", new Dictionary<string, object>() { { "intUyeGrupID", UyeGrupID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new uyeGrubuFiyatTipleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt16(dic[i][2])));

            return donendeger;
        }
    }
}
