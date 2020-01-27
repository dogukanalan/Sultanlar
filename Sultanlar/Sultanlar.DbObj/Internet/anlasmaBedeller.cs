using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class anlasmaBedeller : DbObj
    {
        public int pkID { get; set; }
        public int intAnlasmaID { get; set; }
        public int intAnlasmaBedelAdID { get; set; }
        public anlasmaBedelAdlari BedelAdlar { get { return new anlasmaBedelAdlari(intAnlasmaBedelAdID).GetObject(); } }
        public int intTAHAdet { get; set; }
        public double mnTAHBedel { get; set; }
        public double flTAHIsk { get; set; }
        public int intYEGAdet { get; set; }
        public double mnYEGBedel { get; set; }
        public double flYEGIsk { get; set; }
        public string strAciklama1 { get; set; }
        public string strAciklama2 { get; set; }
        public string strAciklama3 { get; set; }
        public string strAciklama4 { get; set; }

        public anlasmaBedeller() { }
        public anlasmaBedeller(int pkID) { this.pkID = pkID; }
        public anlasmaBedeller(int intAnlasmaID, int intAnlasmaBedelAdID, int intTAHAdet, double mnTAHBedel, double flTAHIsk, int intYEGAdet, double mnYEGBedel, double flYEGIsk, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4)
        {
            this.intAnlasmaID = intAnlasmaID;
            this.intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this.intTAHAdet = intTAHAdet;
            this.mnTAHBedel = mnTAHBedel;
            this.flTAHIsk = flTAHIsk;
            this.intYEGAdet = intYEGAdet;
            this.mnYEGBedel = mnYEGBedel;
            this.flYEGIsk = flYEGIsk;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
        }
        private anlasmaBedeller(int pkID, int intAnlasmaID, int intAnlasmaBedelAdID, int intTAHAdet, double mnTAHBedel, double flTAHIsk, int intYEGAdet, double mnYEGBedel, double flYEGIsk, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4)
        {
            this.pkID = pkID;
            this.intAnlasmaID = intAnlasmaID;
            this.intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this.intTAHAdet = intTAHAdet;
            this.mnTAHBedel = mnTAHBedel;
            this.flTAHIsk = flTAHIsk;
            this.intYEGAdet = intYEGAdet;
            this.mnYEGBedel = mnYEGBedel;
            this.flYEGIsk = flYEGIsk;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intAnlasmaID", intAnlasmaID }, { "intAnlasmaBedelAdID", intAnlasmaBedelAdID }, { "intTAHAdet", intTAHAdet }, { "mnTAHBedel", mnTAHBedel }, { "flTAHIsk", flTAHIsk }, { "intYEGAdet", intYEGAdet }, { "mnYEGBedel", mnYEGBedel }, { "flYEGIsk", flYEGIsk }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_anlasmaBedelEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intAnlasmaID", intAnlasmaID }, { "intAnlasmaBedelAdID", intAnlasmaBedelAdID }, { "intTAHAdet", intTAHAdet }, { "mnTAHBedel", mnTAHBedel }, { "flTAHIsk", flTAHIsk }, { "intYEGAdet", intYEGAdet }, { "mnYEGBedel", mnYEGBedel }, { "flYEGIsk", flYEGIsk }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 } };
            Do(QueryType.Update, "db_sp_anlasmaBedelGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_anlasmaBedelSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public anlasmaBedeller GetObject()
        {
            anlasmaBedeller donendeger = new anlasmaBedeller();

            Dictionary<int, object> dic = GetObject("db_sp_anlasmaBedelGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new anlasmaBedeller(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), ConvertToDouble(dic[4]), ConvertToDouble(dic[5]), ConvertToInt32(dic[6]), ConvertToDouble(dic[7]), ConvertToDouble(dic[8]), dic[9].ToString(), dic[10].ToString(), dic[11].ToString(), dic[12].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<anlasmaBedeller> GetObjects(int AnlasmaID)
        {
            List<anlasmaBedeller> donendeger = new List<anlasmaBedeller>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_anlasmaBedellerGetir", new Dictionary<string, object>() { { "intAnlasmaID", AnlasmaID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmaBedeller(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString()));

            return donendeger;
        }
    }
}
