using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class satisTemsilcileriSefler : DbObj
    {
        public int ustSLSREF { get; set; }
        public satisTemsilcileri Ust { get { return new satisTemsilcileri(ustSLSREF).GetObject(); } }
        public int altSLSREF { get; set; }
        public satisTemsilcileri Alt { get { return new satisTemsilcileri(altSLSREF).GetObject(); } }

        public satisTemsilcileriSefler() { }
        public satisTemsilcileriSefler(int ustSLSREF, int altSLSREF)
        {
            this.ustSLSREF = ustSLSREF;
            this.altSLSREF = altSLSREF;
        }

        public override string ToString() { return altSLSREF.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF }, { "altSLSREF", altSLSREF } };
            Do(QueryType.Update, "db_sp_SatisTemsilcileriSeflerEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF }, { "altSLSREF", altSLSREF } };
            Do(QueryType.Update, "db_sp_SatisTemsilcileriSeflerGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_SatisTemsilcileriSeflerSil", new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF }, { "altSLSREF", altSLSREF } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileriSefler> GetObjects()
        {
            List<satisTemsilcileriSefler> donendeger = new List<satisTemsilcileriSefler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_SatisTemsilcileriSeflerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileriSefler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileriSefler> GetObjects(int ustSLSREF)
        {
            List<satisTemsilcileriSefler> donendeger = new List<satisTemsilcileriSefler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_SatisTemsilcileriSeflerGetirByUstSLSREF", new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileriSefler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1])));

            return donendeger;
        }
    }
    public class satisTemsilcileriAgac : DbObj
    {
        public int ustSLSREF { get; set; }
        //public satisTemsilcileri Ust { get { return new satisTemsilcileri(ustSLSREF).GetObject(); } }
        public int altSLSREF { get; set; }
        public satisTemsilcileri Alt { get { return new satisTemsilcileri(altSLSREF).GetObject(); } }
        public List<satisTemsilcileriAgac> Altlar { get { return GetObjects(altSLSREF); } }

        public satisTemsilcileriAgac() { }
        public satisTemsilcileriAgac(int ustSLSREF, int altSLSREF)
        {
            this.ustSLSREF = ustSLSREF;
            this.altSLSREF = altSLSREF;
        }

        public override string ToString() { return altSLSREF.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF }, { "altSLSREF", altSLSREF } };
            Do(QueryType.Update, "db_sp_SatisTemsilcileriSeflerEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF }, { "altSLSREF", altSLSREF } };
            Do(QueryType.Update, "db_sp_SatisTemsilcileriSeflerGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_SatisTemsilcileriSeflerSil", new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF }, { "altSLSREF", altSLSREF } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileriAgac> GetObjects()
        {
            List<satisTemsilcileriAgac> donendeger = new List<satisTemsilcileriAgac>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_SatisTemsilcileriSeflerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileriAgac(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileriAgac> GetEnUstler()
        {
            List<satisTemsilcileriAgac> donendeger = new List<satisTemsilcileriAgac>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_satisTemsilcileriSeflerGetirEnUstler", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileriAgac(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileriAgac> GetObjects(int ustSLSREF)
        {
            List<satisTemsilcileriAgac> donendeger = new List<satisTemsilcileriAgac>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_SatisTemsilcileriSeflerGetirByUstSLSREF2", new Dictionary<string, object>() { { "ustSLSREF", ustSLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileriAgac(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1])));

            return donendeger;
        }
    }
}
