using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class hizmetBedelleri : DbObj
    {
        public int pkID { get; set; }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { return new musteriler(intMusteriID).GetObject(); } }
        public int SMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar().GetObject1(4, SMREF); } }
        public int intAnlasmaBedelAdID { get; set; }
        public anlasmaBedelAdlari AnlasmaBedelAd { get { return new anlasmaBedelAdlari(intAnlasmaBedelAdID).GetObject(); } }
        public int intAy { get; set; }
        public int intYil { get; set; }
        public string strFaturaNo { get; set; }
        public DateTime dtFaturaTarih { get; set; }
        public decimal mnTAHBedel { get; set; }
        public decimal mnYEGBedel { get; set; }
        public int intAnlasmaBedelID { get; set; }
        public string strAciklama1 { get; set; }
        public string strAciklama2 { get; set; }
        public string strAciklama3 { get; set; }
        public string strAciklama4 { get; set; }
        public decimal mnMudurButcesi { get; set; }
        public decimal mnElemanButcesi { get; set; }
        public bool blKapamaEtki { get; set; }

        public hizmetBedelleri() { }
        public hizmetBedelleri(int pkID) { this.pkID = pkID; }
        public hizmetBedelleri(int intMusteriID, int SMREF, int intAnlasmaBedelAdID, int intAy, int intYil, string strFaturaNo, DateTime dtFaturaTarih, decimal mnTAHBedel, decimal mnYEGBedel, int intAnlasmaBedelID,
            string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, decimal mnMudurButcesi, decimal mnElemanButcesi, bool blKapamaEtki)
        {
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this.intAy = intAy;
            this.intYil = intYil;
            this.strFaturaNo = strFaturaNo;
            this.dtFaturaTarih = dtFaturaTarih;
            this.mnTAHBedel = mnTAHBedel;
            this.mnYEGBedel = mnYEGBedel;
            this.intAnlasmaBedelID = intAnlasmaBedelID;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.mnMudurButcesi = mnMudurButcesi;
            this.mnElemanButcesi = mnElemanButcesi;
            this.blKapamaEtki = blKapamaEtki;
        }
        private hizmetBedelleri(int pkID, int intMusteriID, int SMREF, int intAnlasmaBedelAdID, int intAy, int intYil, string strFaturaNo, DateTime dtFaturaTarih, decimal mnTAHBedel, decimal mnYEGBedel, int intAnlasmaBedelID,
            string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, decimal mnMudurButcesi, decimal mnElemanButcesi, bool blKapamaEtki)
        {
            this.pkID = pkID;
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this.intAy = intAy;
            this.intYil = intYil;
            this.strFaturaNo = strFaturaNo;
            this.dtFaturaTarih = dtFaturaTarih;
            this.mnTAHBedel = mnTAHBedel;
            this.mnYEGBedel = mnYEGBedel;
            this.intAnlasmaBedelID = intAnlasmaBedelID;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.mnMudurButcesi = mnMudurButcesi;
            this.mnElemanButcesi = mnElemanButcesi;
            this.blKapamaEtki = blKapamaEtki;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "intAnlasmaBedelAdID", intAnlasmaBedelAdID }, 
                { "intAy", intAy }, { "intYil", intYil }, { "strFaturaNo", strFaturaNo }, { "dtFaturaTarih", dtFaturaTarih }, { "mnTAHBedel", mnTAHBedel }, { "mnYEGBedel", mnYEGBedel }, 
                { "intAnlasmaBedelID", intAnlasmaBedelID }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, 
                { "mnMudurButcesi", mnMudurButcesi }, { "mnElemanButcesi", mnElemanButcesi }, { "blKapamaEtki", blKapamaEtki } };
            pkID = ConvertToByte(Do(QueryType.Insert, "db_sp_hizmetBedelleriEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "intAnlasmaBedelAdID", intAnlasmaBedelAdID },
                { "intAy", intAy }, { "intYil", intYil }, { "strFaturaNo", strFaturaNo }, { "dtFaturaTarih", dtFaturaTarih }, { "mnTAHBedel", mnTAHBedel }, { "mnYEGBedel", mnYEGBedel },
                { "intAnlasmaBedelID", intAnlasmaBedelID }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 },
                { "mnMudurButcesi", mnMudurButcesi }, { "mnElemanButcesi", mnElemanButcesi }, { "blKapamaEtki", blKapamaEtki } };
            Do(QueryType.Update, "db_sp_hizmetBedelleriGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_hizmetBedelleriSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public hizmetBedelleri GetObject()
        {
            hizmetBedelleri donendeger = new hizmetBedelleri();

            Dictionary<int, object> dic = GetObject("db_sp_hizmetBedeliGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new hizmetBedelleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]), 
                    ConvertToString(dic[6]), ConvertToDateTime(dic[7]), Convert.ToDecimal(dic[8]), Convert.ToDecimal(dic[9]), ConvertToInt32(dic[10]), ConvertToString(dic[11]), 
                    ConvertToString(dic[12]), ConvertToString(dic[13]), ConvertToString(dic[14]), Convert.ToDecimal(dic[15]), Convert.ToDecimal(dic[16]), Convert.ToBoolean(dic[17]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<hizmetBedelleri> GetObjects()
        {
            List<hizmetBedelleri> donendeger = new List<hizmetBedelleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_hizmetBedelleriGetir", new Dictionary<string, object>() { }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new hizmetBedelleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]),
                    ConvertToString(dic[6]), ConvertToDateTime(dic[7]), Convert.ToDecimal(dic[8]), Convert.ToDecimal(dic[9]), ConvertToInt32(dic[10]), ConvertToString(dic[11]),
                    ConvertToString(dic[12]), ConvertToString(dic[13]), ConvertToString(dic[14]), Convert.ToDecimal(dic[15]), Convert.ToDecimal(dic[16]), Convert.ToBoolean(dic[17])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<hizmetBedelleri> GetObjectsBySLSREF(int SLSREF, int Yil, object Ay)
        {
            List<hizmetBedelleri> donendeger = new List<hizmetBedelleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_hizmetBedelleriGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new hizmetBedelleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]),
                    ConvertToString(dic[i][6]), ConvertToDateTime(dic[i][7]), Convert.ToDecimal(dic[i][8]), Convert.ToDecimal(dic[i][9]), ConvertToInt32(dic[i][10]), ConvertToString(dic[i][11]),
                    ConvertToString(dic[i][12]), ConvertToString(dic[i][13]), ConvertToString(dic[i][14]), Convert.ToDecimal(dic[i][15]), Convert.ToDecimal(dic[i][16]), Convert.ToBoolean(dic[i][17])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<hizmetBedelleri> GetObjectsByGMREF(int GMREF, int Yil, object Ay)
        {
            List<hizmetBedelleri> donendeger = new List<hizmetBedelleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_hizmetBedelleriGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF }, { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new hizmetBedelleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]),
                    ConvertToString(dic[i][6]), ConvertToDateTime(dic[i][7]), Convert.ToDecimal(dic[i][8]), Convert.ToDecimal(dic[i][9]), ConvertToInt32(dic[i][10]), ConvertToString(dic[i][11]),
                    ConvertToString(dic[i][12]), ConvertToString(dic[i][13]), ConvertToString(dic[i][14]), Convert.ToDecimal(dic[i][15]), Convert.ToDecimal(dic[i][16]), Convert.ToBoolean(dic[i][17])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<hizmetBedelleri> GetObjectsBySMREF(int SMREF, int Yil, object Ay)
        {
            List<hizmetBedelleri> donendeger = new List<hizmetBedelleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_hizmetBedelleriGetirBySMREF", new Dictionary<string, object>() { { "SMREF", SMREF }, { "Yil", Yil }, { "Ay", Ay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new hizmetBedelleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]),
                    ConvertToString(dic[i][6]), ConvertToDateTime(dic[i][7]), Convert.ToDecimal(dic[i][8]), Convert.ToDecimal(dic[i][9]), ConvertToInt32(dic[i][10]), ConvertToString(dic[i][11]),
                    ConvertToString(dic[i][12]), ConvertToString(dic[i][13]), ConvertToString(dic[i][14]), Convert.ToDecimal(dic[i][15]), Convert.ToDecimal(dic[i][16]), Convert.ToBoolean(dic[i][17])));

            return donendeger;
        }
    }
}
