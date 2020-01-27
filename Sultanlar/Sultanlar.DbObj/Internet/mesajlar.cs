using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class mesajlar : DbObj
    {
        public bool GonderilenMi { get; set; }
        public int pkMesajID { get; set; }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { return new musteriler(intMusteriID).GetObject(); } }
        public byte tintDepartmanID { get; set; }
        public departmanlar Departman { get { return new departmanlar(tintDepartmanID).GetObject(); } }
        public string strKonu { get; set; }
        public string strIcerik { get; set; }
        public DateTime dtGondermeZamani { get; set; }
        public DateTime dtOkunmaZamani { get; set; }
        public bool blOkundu { get; set; }
        public bool blGonderenSil { get; set; }
        public bool blOkuyanSil { get; set; }

        public mesajlar() { }
        public mesajlar(int pkMesajID, bool GonderilenMi) { this.pkMesajID = pkMesajID; this.GonderilenMi = GonderilenMi; }
        public mesajlar(int intMusteriID, byte tintDepartmanID, string strKonu, string strIcerik, DateTime dtGondermeZamani, DateTime dtOkunmaZamani, bool blOkundu, bool blGonderenSil, bool blOkuyanSil, bool GonderilenMi)
        {
            this.GonderilenMi = GonderilenMi;
            this.intMusteriID = intMusteriID;
            this.tintDepartmanID = tintDepartmanID;
            this.strKonu = strKonu;
            this.strIcerik = strIcerik;
            this.dtGondermeZamani = dtGondermeZamani;
            this.dtOkunmaZamani = dtOkunmaZamani;
            this.blOkundu = blOkundu;
            this.blGonderenSil = blGonderenSil;
            this.blOkuyanSil = blOkuyanSil;
        }
        private mesajlar(int pkMesajID, int intMusteriID, byte tintDepartmanID, string strKonu, string strIcerik, DateTime dtGondermeZamani, DateTime dtOkunmaZamani, bool blOkundu, bool blGonderenSil, bool blOkuyanSil, bool GonderilenMi)
        {
            this.GonderilenMi = GonderilenMi;
            this.pkMesajID = pkMesajID;
            this.intMusteriID = intMusteriID;
            this.tintDepartmanID = tintDepartmanID;
            this.strKonu = strKonu;
            this.strIcerik = strIcerik;
            this.dtGondermeZamani = dtGondermeZamani;
            this.dtOkunmaZamani = dtOkunmaZamani;
            this.blOkundu = blOkundu;
            this.blGonderenSil = blGonderenSil;
            this.blOkuyanSil = blOkuyanSil;
        }

        public override string ToString() { return pkMesajID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkMesajID", pkMesajID }, { "intMusteriID", intMusteriID }, { "tintDepartmanID", tintDepartmanID }, { "strKonu", strKonu }, { "strIcerik", strIcerik }, { "dtGondermeZamani", dtGondermeZamani }, { "dtOkunmaZamani", dtOkunmaZamani }, { "blOkundu", blOkundu }, { "blGonderenSil", blGonderenSil }, { "blOkuyanSil", blOkuyanSil } };
            pkMesajID = ConvertToInt32(Do(QueryType.Insert, GonderilenMi ? "db_sp_gonderilenMesajEkle" : "db_sp_alinanMesajEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkMesajID", pkMesajID }, { "intMusteriID", intMusteriID }, { "tintDepartmanID", tintDepartmanID }, { "strKonu", strKonu }, { "strIcerik", strIcerik }, { "dtGondermeZamani", dtGondermeZamani }, { "dtOkunmaZamani", dtOkunmaZamani }, { "blOkundu", blOkundu }, { "blGonderenSil", blGonderenSil }, { "blOkuyanSil", blOkuyanSil } };
            Do(QueryType.Update, GonderilenMi ? "db_sp_gonderilenMesajGuncelle" : "db_sp_alinanMesajGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, GonderilenMi ? "db_sp_gonderilenMesajSil" : "db_sp_alinanMesajSil", new Dictionary<string, object>() { { "pkMesajID", pkMesajID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public mesajlar GetObject()
        {
            mesajlar donendeger = new mesajlar();

            Dictionary<int, object> dic = GetObject(GonderilenMi ? "db_sp_gonderilenMesajGetir" : "db_sp_alinanMesajGetir", new Dictionary<string, object>() { { "pkMesajID", pkMesajID } }, timeout);
            if (dic != null)
                donendeger = new mesajlar(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToByte(dic[2]), dic[3].ToString(), dic[4].ToString(), ConvertToDateTime(dic[5]), ConvertToDateTime(dic[6]), Convert.ToBoolean(dic[7]), Convert.ToBoolean(dic[8]), Convert.ToBoolean(dic[9]), GonderilenMi);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<mesajlar> GetObjects(int MusteriID)
        {
            List<mesajlar> donendeger = new List<mesajlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects(GonderilenMi ? "db_sp_gonderilenMesajlarGetir" : "db_sp_alinanMesajlarGetir", new Dictionary<string, object>() { { "MusteriID", MusteriID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new mesajlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToByte(dic[i][2]), dic[i][3].ToString(), dic[i][4].ToString(), ConvertToDateTime(dic[i][5]), ConvertToDateTime(dic[i][6]), Convert.ToBoolean(dic[i][7]), Convert.ToBoolean(dic[i][8]), Convert.ToBoolean(dic[i][9]), GonderilenMi));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<mesajlar> GetObjects(object DepartmanID, int MusteriID, bool GonderilenMi)
        {
            List<mesajlar> donendeger = new List<mesajlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects(GonderilenMi ? "db_sp_gonderilenMesajlarGetirByDepartman" : "db_sp_alinanMesajlarGetirByDepartman", new Dictionary<string, object>() { { "DepartmanID", DepartmanID }, { "MusteriID", MusteriID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new mesajlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToByte(dic[i][2]), dic[i][3].ToString(), dic[i][4].ToString(), ConvertToDateTime(dic[i][5]), ConvertToDateTime(dic[i][6]), Convert.ToBoolean(dic[i][7]), Convert.ToBoolean(dic[i][8]), Convert.ToBoolean(dic[i][9]), GonderilenMi));
            
            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetOkunmayanCount(int MusteriID, bool GonderilenMi)
        {
            int donendeger = ConvertToInt32(Do(QueryType.Insert, GonderilenMi ? "db_sp_gonderilenMesajlarOkunmayanSayi" : "", new Dictionary<string, object>() { { "count", 0 }, { "MusteriID", MusteriID } }, timeout));
            return donendeger;
        }
    }
}
