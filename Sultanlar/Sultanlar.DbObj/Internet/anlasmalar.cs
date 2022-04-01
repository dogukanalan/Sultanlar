using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class anlasmalar : DbObj
    {
        public int pkID { get; set; }
        public int SMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar().GetObject1(strAciklama2 == "2" ? 1 : 4, SMREF); } }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { return new musteriler(intMusteriID).GetObject(); } }
        public DateTime dtBaslangic { get; set; }
        public DateTime dtBitis { get; set; }
        public int intVadeTAH { get; set; }
        public int intVadeYEG { get; set; }
        public int intListSKUTAH { get; set; }
        public int intListSKUYEG { get; set; }
        public double flTAHIsk { get; set; }
        public double flTAHCiro { get; set; }
        public double flTAHCiro3 { get; set; }
        public double flTAHCiro6 { get; set; }
        public double flTAHCiro12 { get; set; }
        public double flTAHCiroIsk { get; set; }
        public double mnTAHAnlasmaDisiBedeller { get; set; }
        public double mnTAHToplamCiro { get; set; }
        public double flYEGIsk { get; set; }
        public double flYEGCiro { get; set; }
        public double flYEGCiro3 { get; set; }
        public double flYEGCiro6 { get; set; }
        public double flYEGCiro12 { get; set; }
        public double flYEGCiroIsk { get; set; }
        public double mnYEGAnlasmaDisiBedeller { get; set; }
        public double mnYEGToplamCiro { get; set; }
        public string strAciklama1 { get; set; }
        public string strAciklama2 { get; set; }
        public string strAciklama3 { get; set; }
        public string strAciklama4 { get; set; }
        public int intOnay { get; set; }

        public int fiyatTip500 { get { return new fiyatTipleri().GetObjectByGMREF(SMREF).NOSU; } }
        public double ahtCiroPrimDonusYuzdeToplam { get { return flTAHCiro + flTAHCiro3 + flTAHCiro6 + flTAHCiro12; } }
        public double yegCiroPrimDonusYuzdeToplam { get { return flYEGCiro + flYEGCiro3 + flYEGCiro6 + flYEGCiro12; } }

        private bool bedel { get; set; }
        public List<anlasmaBedeller> bedeller { get { if (bedel) return new anlasmaBedeller().GetObjects(pkID); else return new List<anlasmaBedeller>(); } }

        public anlasmalar() { bedel = false; }
        public anlasmalar(int pkID) { this.pkID = pkID; }
        public anlasmalar(int SMREF, int intMusteriID, DateTime dtBaslangic, DateTime dtBitis, int intVadeTAH, int intVadeYEG, int intListSKUTAH, int intListSKUYEG, double flTAHIsk, double flTAHCiro, double flTAHCiro3, double flTAHCiro6, double flTAHCiro12, double flTAHCiroIsk, double mnTAHAnlasmaDisiBedeller, double mnTAHToplamCiro, double flYEGIsk, double flYEGCiro, double flYEGCiro3, double flYEGCiro6, double flYEGCiro12, double flYEGCiroIsk, double mnYEGAnlasmaDisiBedeller, double mnYEGToplamCiro, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, int intOnay)
        {
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.dtBaslangic = dtBaslangic;
            this.dtBitis = dtBitis;
            this.intVadeTAH = intVadeTAH;
            this.intVadeYEG = intVadeYEG;
            this.intListSKUTAH = intListSKUTAH;
            this.intListSKUYEG = intListSKUYEG;
            this.flTAHIsk = flTAHIsk;
            this.flTAHCiro = flTAHCiro;
            this.flTAHCiro3 = flTAHCiro3;
            this.flTAHCiro6 = flTAHCiro6;
            this.flTAHCiro12 = flTAHCiro12;
            this.flTAHCiroIsk = flTAHCiroIsk;
            this.mnTAHAnlasmaDisiBedeller = mnTAHAnlasmaDisiBedeller;
            this.mnTAHToplamCiro = mnTAHToplamCiro;
            this.flYEGIsk = flYEGIsk;
            this.flYEGCiro = flYEGCiro;
            this.flYEGCiro3 = flYEGCiro3;
            this.flYEGCiro6 = flYEGCiro6;
            this.flYEGCiro12 = flYEGCiro12;
            this.flYEGCiroIsk = flYEGCiroIsk;
            this.mnYEGAnlasmaDisiBedeller = mnYEGAnlasmaDisiBedeller;
            this.mnYEGToplamCiro = mnYEGToplamCiro;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.intOnay = intOnay;
        }
        private anlasmalar(int pkID, int SMREF, int intMusteriID, DateTime dtBaslangic, DateTime dtBitis, int intVadeTAH, int intVadeYEG, int intListSKUTAH, int intListSKUYEG, double flTAHIsk, double flTAHCiro, double flTAHCiro3, double flTAHCiro6, double flTAHCiro12, double flTAHCiroIsk, double mnTAHAnlasmaDisiBedeller, double mnTAHToplamCiro, double flYEGIsk, double flYEGCiro, double flYEGCiro3, double flYEGCiro6, double flYEGCiro12, double flYEGCiroIsk, double mnYEGAnlasmaDisiBedeller, double mnYEGToplamCiro, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, int intOnay, bool bedel)
        {
            this.pkID = pkID;
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.dtBaslangic = dtBaslangic;
            this.dtBitis = dtBitis;
            this.intVadeTAH = intVadeTAH;
            this.intVadeYEG = intVadeYEG;
            this.intListSKUTAH = intListSKUTAH;
            this.intListSKUYEG = intListSKUYEG;
            this.flTAHIsk = flTAHIsk;
            this.flTAHCiro = flTAHCiro;
            this.flTAHCiro3 = flTAHCiro3;
            this.flTAHCiro6 = flTAHCiro6;
            this.flTAHCiro12 = flTAHCiro12;
            this.flTAHCiroIsk = flTAHCiroIsk;
            this.mnTAHAnlasmaDisiBedeller = mnTAHAnlasmaDisiBedeller;
            this.mnTAHToplamCiro = mnTAHToplamCiro;
            this.flYEGIsk = flYEGIsk;
            this.flYEGCiro = flYEGCiro;
            this.flYEGCiro3 = flYEGCiro3;
            this.flYEGCiro6 = flYEGCiro6;
            this.flYEGCiro12 = flYEGCiro12;
            this.flYEGCiroIsk = flYEGCiroIsk;
            this.mnYEGAnlasmaDisiBedeller = mnYEGAnlasmaDisiBedeller;
            this.mnYEGToplamCiro = mnYEGToplamCiro;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.intOnay = intOnay;
            this.bedel = bedel;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "dtBaslangic", dtBaslangic }, { "dtBitis", dtBitis }, { "intVadeTAH", intVadeTAH }, { "intVadeYEG", intVadeYEG }, { "intListSKUTAH", intListSKUTAH }, { "intListSKUYEG", intListSKUYEG }, { "flTAHIsk", flTAHIsk }, { "flTAHCiro", flTAHCiro }, { "flTAHCiro3", flTAHCiro3 }, { "flTAHCiro6", flTAHCiro6 }, { "flTAHCiro12", flTAHCiro12 }, { "flTAHCiroIsk", flTAHCiroIsk }, { "mnTAHAnlasmaDisiBedeller", mnTAHAnlasmaDisiBedeller }, { "mnTAHToplamCiro", mnTAHToplamCiro }, { "flYEGIsk", flYEGIsk }, { "flYEGCiro", flYEGCiro }, { "flYEGCiro3", flYEGCiro3 }, { "flYEGCiro6", flYEGCiro6 }, { "flYEGCiro12", flYEGCiro12 }, { "flYEGCiroIsk", flYEGCiroIsk }, { "mnYEGAnlasmaDisiBedeller", mnYEGAnlasmaDisiBedeller }, { "mnYEGToplamCiro", mnYEGToplamCiro }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, { "intOnay", intOnay } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_anlasmaEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "dtBaslangic", dtBaslangic }, { "dtBitis", dtBitis }, { "intVadeTAH", intVadeTAH }, { "intVadeYEG", intVadeYEG }, { "intListSKUTAH", intListSKUTAH }, { "intListSKUYEG", intListSKUYEG }, { "flTAHIsk", flTAHIsk }, { "flTAHCiro", flTAHCiro }, { "flTAHCiro3", flTAHCiro3 }, { "flTAHCiro6", flTAHCiro6 }, { "flTAHCiro12", flTAHCiro12 }, { "flTAHCiroIsk", flTAHCiroIsk }, { "mnTAHAnlasmaDisiBedeller", mnTAHAnlasmaDisiBedeller }, { "mnTAHToplamCiro", mnTAHToplamCiro }, { "flYEGIsk", flYEGIsk }, { "flYEGCiro", flYEGCiro }, { "flYEGCiro3", flYEGCiro3 }, { "flYEGCiro6", flYEGCiro6 }, { "flYEGCiro12", flYEGCiro12 }, { "flYEGCiroIsk", flYEGCiroIsk }, { "mnYEGAnlasmaDisiBedeller", mnYEGAnlasmaDisiBedeller }, { "mnYEGToplamCiro", mnYEGToplamCiro }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, { "intOnay", intOnay } };
            Do(QueryType.Update, "db_sp_anlasmaGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_anlasmaSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public anlasmalar GetObject()
        {
            anlasmalar donendeger = new anlasmalar();

            Dictionary<int, object> dic = GetObject("db_sp_anlasmaGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new anlasmalar(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToDateTime(dic[3]), ConvertToDateTime(dic[4]), ConvertToInt32(dic[5]), ConvertToInt32(dic[6]), ConvertToInt32(dic[7]), ConvertToInt32(dic[8]), ConvertToDouble(dic[9]), ConvertToDouble(dic[10]), ConvertToDouble(dic[11]), ConvertToDouble(dic[12]), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), ConvertToDouble(dic[21]), ConvertToDouble(dic[22]), ConvertToDouble(dic[23]), ConvertToDouble(dic[24]), dic[25].ToString(), dic[26].ToString(), dic[27].ToString(), dic[28].ToString(), ConvertToInt32(dic[29]), true);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<anlasmalar> GetObjectsByMusteri(int Yil, int Ay, int SMREF, string Tip)
        {
            List<anlasmalar> donendeger = new List<anlasmalar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_anlasmaGetirByMusteri", new Dictionary<string, object>() { { "Yil", Yil }, { "Ay", Ay }, { "SMREF", SMREF }, { "strAciklama2", Tip } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmalar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), ConvertToInt32(dic[i][29]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<anlasmalar> GetObjects()
        {
            List<anlasmalar> donendeger = new List<anlasmalar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmalar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), ConvertToInt32(dic[i][29]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<anlasmalar> GetObjects(int Yil, object Ay, object Onay)
        {
            List<anlasmalar> donendeger = new List<anlasmalar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_anlasmalarGetir", new Dictionary<string, object>() { { "Yil", Yil }, { "Ay", Ay }, { "intOnay", Onay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmalar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), ConvertToInt32(dic[i][29]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<anlasmalar> GetObjectsBySLSREF(int SLSREF, int Yil, object Ay, object Onay)
        {
            List<anlasmalar> donendeger = new List<anlasmalar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_anlasmalarGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "Yil", Yil }, { "Ay", Ay }, { "intOnay", Onay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmalar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), ConvertToInt32(dic[i][29]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<anlasmalar> GetObjectsByGMREF(int GMREF, int Yil, object Ay, object Onay)
        {
            List<anlasmalar> donendeger = new List<anlasmalar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_anlasmalarGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF }, { "Yil", Yil }, { "Ay", Ay }, { "intOnay", Onay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmalar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), ConvertToInt32(dic[i][29]), false));

            return donendeger;
        }
        /// <summary>
        /// Aciklama2 "1" ise bayi anlaşmaları "2" ise sultanlar anlaşmaları
        /// </summary>
        /// <returns></returns>
        public List<anlasmalar> GetObjectsBySMREF(int SMREF, string Aciklama2, int Yil, object Ay, object Onay)
        {
            List<anlasmalar> donendeger = new List<anlasmalar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_anlasmalarGetirBySMREF", new Dictionary<string, object>() { { "SMREF", SMREF }, { "strAciklama2", Aciklama2 }, { "Yil", Yil }, { "Ay", Ay }, { "intOnay", Onay } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new anlasmalar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), ConvertToInt32(dic[i][29]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public anlasmalar GetObjectSon(int SMREF, string Aciklama2, DateTime Tarih)
        {
            anlasmalar donendeger = new anlasmalar();

            Dictionary<int, object> dic = GetObject("db_sp_anlasmaGetirSon", new Dictionary<string, object>() { { "SMREF", SMREF }, { "strAciklama2", Aciklama2 }, { "Tarih", Tarih } }, timeout);
            if (dic != null)
                donendeger = new anlasmalar(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToDateTime(dic[3]), ConvertToDateTime(dic[4]), ConvertToInt32(dic[5]), ConvertToInt32(dic[6]), ConvertToInt32(dic[7]), ConvertToInt32(dic[8]), ConvertToDouble(dic[9]), ConvertToDouble(dic[10]), ConvertToDouble(dic[11]), ConvertToDouble(dic[12]), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), ConvertToDouble(dic[21]), ConvertToDouble(dic[22]), ConvertToDouble(dic[23]), ConvertToDouble(dic[24]), dic[25].ToString(), dic[26].ToString(), dic[27].ToString(), dic[28].ToString(), ConvertToInt32(dic[29]), true);

            return donendeger;
        }
    }
}
