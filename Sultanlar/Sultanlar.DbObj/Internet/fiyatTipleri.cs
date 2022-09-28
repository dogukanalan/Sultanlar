using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class fiyatTipleri : DbObj
    {
        public int NOSU { get; set; }
        public string ACIKLAMA { get; set; }
        public int GMREF { get; set; }
        public int ANAGMREF { get { return GMREF == 0 ? 0 : GetAnaGmrefNo(); } }

        public fiyatTipleri() { }
        public fiyatTipleri(int NOSU) { this.NOSU = NOSU; }
        private fiyatTipleri(int NOSU, string ACIKLAMA, int GMREF)
        {
            this.NOSU = NOSU;
            this.ACIKLAMA = ACIKLAMA;
            this.GMREF = GMREF;
        }
        
        public override string ToString() { return ACIKLAMA; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "NOSU", NOSU }, { "ACIKLAMA", ACIKLAMA }, { "GMREF", GMREF } };
            Do(QueryType.Update, "db_sp_fiyatTipiEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "NOSU", NOSU }, { "ACIKLAMA", ACIKLAMA }, { "GMREF", GMREF } };
            Do(QueryType.Update, "db_sp_fiyatTipiGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_fiyatTipiSil", new Dictionary<string, object>() { { "NOSU", NOSU } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public fiyatTipleri GetObject()
        {
            fiyatTipleri donendeger = new fiyatTipleri();

            Dictionary<int, object> dic = GetObject("db_sp_fiyatTipiGetir", new Dictionary<string, object>() { { "NOSU", NOSU } }, timeout);
            if (dic != null)
                donendeger = new fiyatTipleri(ConvertToInt32(dic[0]), dic[1].ToString(), ConvertToInt32(dic[2]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public fiyatTipleri GetObjectByGMREF(int GMREF)
        {
            fiyatTipleri donendeger = new fiyatTipleri();

            Dictionary<int, object> dic = GetObject("db_sp_fiyatTipiGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                donendeger = new fiyatTipleri(ConvertToInt32(dic[0]), dic[1].ToString(), ConvertToInt32(dic[2]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatTipleri> GetObjects()
        {
            List<fiyatTipleri> donendeger = new List<fiyatTipleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatTipleriGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatTipleri(ConvertToInt32(dic[i][0]), dic[i][1].ToString(), ConvertToInt32(dic[i][2])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void GetObjects(IList Liste)
        {
            Liste.Clear();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("SELECT NOSU,ACIKLAMA,GMREF FROM [Web-FiyatTipleri] ORDER BY NOSU", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    Liste.Add(new fiyatTipleri(ConvertToInt32(dic[i][0]), dic[i][1].ToString(), ConvertToInt32(dic[i][2])));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetAnaGmrefNo()
        {
            int donendeger = 0;
            object obj = GetObjectSc("SELECT NOSU FROM [Web-FiyatTipleri] WHERE GMREF = (SELECT [ANA_GMREF] FROM [Web-FiyatTipleri] AS TIP WHERE GMREF = @GMREF)", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (obj != null)
                donendeger = Convert.ToInt32(obj);
            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public fiyatTipleri GetObjectVyByGMREF(int GMREF)
        {
            fiyatTipleri donendeger = new fiyatTipleri();

            Dictionary<int, object> dic = GetObject("db_sp_fiyatTipiVyGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                donendeger = new fiyatTipleri(ConvertToInt32(dic[0]), dic[1].ToString(), ConvertToInt32(dic[2]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatTipleri> GetObjects500birlikte()
        {
            List<fiyatTipleri> donendeger = new List<fiyatTipleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatTip500BirlikteGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatTipleri(ConvertToInt32(dic[i][0]), dic[i][1].ToString(), ConvertToInt32(dic[i][2])));

            return donendeger;
        }
    }
}
