using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class aktiviteler : DbObj
    {
        public int pkID { get; set; }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { return new musteriler(intMusteriID).GetObject(); } }
        public int SMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar().GetObject1((intAktiviteTipiID == 2 || flAktiviteKarZararYuzde == 1) ? 1 : 4, SMREF); } } // flAktiviteKarZararYuzde 1 ise genel anlaşmasız aktivite
        public short sintFiyatTipiID { get; set; }
        public fiyatTipleri FiyatTipi { get { return new fiyatTipleri(sintFiyatTipiID).GetObject(); } }
        public int intAnlasmaID { get; set; }
        public anlasmalar Anlasma { get { return new anlasmalar(intAnlasmaID).GetObject(); } }
        public int intAktiviteTipiID { get; set; }
        public DateTime dtOlusmaTarihi { get; set; }
        public DateTime dtOnaylamaTarihi { get; set; }
        public object blAktarilmis { get; set; }
        public DateTime dtAktiviteBaslangic { get; set; }
        public DateTime dtAktiviteBitis { get; set; }
        public string strAciklama1 { get; set; }
        public string strAciklama2 { get; set; }
        public string strAciklama3 { get; set; }
        public string strAciklama4 { get; set; }
        public double mnTahSabitBedel { get; set; }
        public double mnYegSabitBedel { get; set; }
        public double mnTahHedefCiro { get; set; }
        public double mnYegHedefCiro { get; set; }
        public double mnAktiviteKarZarar { get; set; }
        public double flAktiviteKarZararYuzde { get; set; }
        
        public int DonemYil { 
            get 
            {
                int donendeger = 0;
                try
                {
                    donendeger = Convert.ToInt32(strAciklama4.Substring(0, 4));
                }
                catch (Exception)
                {
                    EventLog.WriteEntry("Sultanlar.Db.Obj", "Aktivite Donem" + pkID.ToString() + " " + strAciklama4);
                }
                return donendeger;
            } 
        }
        public int DonemAy 
        { 
            get
            {
                int donendeger = 0;
                try
                {
                    donendeger = Convert.ToInt32(strAciklama4.Substring(5, strAciklama4.LastIndexOf("/") - 5));
                }
                catch (Exception)
                {
                    EventLog.WriteEntry("Sultanlar.Db.Obj", "Aktivite Donem" + pkID.ToString() + " " + strAciklama4);
                }
                return donendeger;
            } 
        }
        public int DonemGun 
        { 
            get
            {
                int donendeger = 0;
                try
                {
                    donendeger = Convert.ToInt32(strAciklama4.Substring(strAciklama4.LastIndexOf("/") + 1, 2));

                }
                catch (Exception)
                {
                    EventLog.WriteEntry("Sultanlar.Db.Obj", "Aktivite Donem" + pkID.ToString() + " " + strAciklama4);
                }
                return donendeger;
            } 
        }
        public double ToplamTutar { get { double toplam = 0; for (int i = 0; i < detaylar.Count; i++) { toplam += detaylar[i].mnToplam; } return toplam; } }

        private bool detay { get; set; }
        public List<aktivitelerDetay> detaylar { get { if (detay) return new aktivitelerDetay().GetObjects(pkID); else return new List<aktivitelerDetay>(); } }

        public aktiviteler() { detay = false; }
        public aktiviteler(int pkID) { this.pkID = pkID; }
        public aktiviteler(int intMusteriID, int SMREF, short sintFiyatTipiID, int intAnlasmaID, int intAktiviteTipiID, DateTime dtOlusmaTarihi, DateTime dtOnaylamaTarihi, object blAktarilmis, DateTime dtAktiviteBaslangic, DateTime dtAktiviteBitis, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, double mnTahSabitBedel, double mnYegSabitBedel, double mnTahHedefCiro, double mnYegHedefCiro, double mnAktiviteKarZarar, double flAktiviteKarZararYuzde)
        {
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.sintFiyatTipiID = sintFiyatTipiID;
            this.intAnlasmaID = intAnlasmaID;
            this.intAktiviteTipiID = intAktiviteTipiID;
            this.dtOlusmaTarihi = dtOlusmaTarihi;
            this.dtOnaylamaTarihi = dtOnaylamaTarihi;
            this.blAktarilmis = blAktarilmis;
            this.dtAktiviteBaslangic = dtAktiviteBaslangic;
            this.dtAktiviteBitis = dtAktiviteBitis;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.mnTahSabitBedel = mnTahSabitBedel;
            this.mnYegSabitBedel = mnYegSabitBedel;
            this.mnTahHedefCiro = mnTahHedefCiro;
            this.mnYegHedefCiro = mnYegHedefCiro;
            this.mnAktiviteKarZarar = mnAktiviteKarZarar;
            this.flAktiviteKarZararYuzde = flAktiviteKarZararYuzde;
        }
        private aktiviteler(int pkID, int intMusteriID, int SMREF, short sintFiyatTipiID, int intAnlasmaID, int intAktiviteTipiID, DateTime dtOlusmaTarihi, DateTime dtOnaylamaTarihi, object blAktarilmis, DateTime dtAktiviteBaslangic, DateTime dtAktiviteBitis, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, double mnTahSabitBedel, double mnYegSabitBedel, double mnTahHedefCiro, double mnYegHedefCiro, double mnAktiviteKarZarar, double flAktiviteKarZararYuzde, bool detay)
        {
            this.pkID = pkID;
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.sintFiyatTipiID = sintFiyatTipiID;
            this.intAnlasmaID = intAnlasmaID;
            this.intAktiviteTipiID = intAktiviteTipiID;
            this.dtOlusmaTarihi = dtOlusmaTarihi;
            this.dtOnaylamaTarihi = dtOnaylamaTarihi;
            this.blAktarilmis = blAktarilmis;
            this.dtAktiviteBaslangic = dtAktiviteBaslangic;
            this.dtAktiviteBitis = dtAktiviteBitis;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.mnTahSabitBedel = mnTahSabitBedel;
            this.mnYegSabitBedel = mnYegSabitBedel;
            this.mnTahHedefCiro = mnTahHedefCiro;
            this.mnYegHedefCiro = mnYegHedefCiro;
            this.mnAktiviteKarZarar = mnAktiviteKarZarar;
            this.flAktiviteKarZararYuzde = flAktiviteKarZararYuzde;
            this.detay = detay;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "sintFiyatTipiID", sintFiyatTipiID }, { "intAnlasmaID", intAnlasmaID }, { "intAktiviteTipiID", intAktiviteTipiID }, { "dtOlusmaTarihi", dtOlusmaTarihi }, { "dtOnaylamaTarihi", dtOnaylamaTarihi }, { "blAktarilmis", blAktarilmis }, { "dtAktiviteBaslangic", dtAktiviteBaslangic }, { "dtAktiviteBitis", dtAktiviteBitis }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, { "mnTahSabitBedel", mnTahSabitBedel }, { "mnYegSabitBedel", mnYegSabitBedel }, { "mnTahHedefCiro", mnTahHedefCiro }, { "mnYegHedefCiro", mnYegHedefCiro }, { "mnAktiviteKarZarar", mnAktiviteKarZarar }, { "flAktiviteKarZararYuzde", flAktiviteKarZararYuzde } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_aktiviteEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "sintFiyatTipiID", sintFiyatTipiID }, { "intAnlasmaID", intAnlasmaID }, { "intAktiviteTipiID", intAktiviteTipiID }, { "dtOlusmaTarihi", dtOlusmaTarihi }, { "dtOnaylamaTarihi", dtOnaylamaTarihi }, { "blAktarilmis", blAktarilmis }, { "dtAktiviteBaslangic", dtAktiviteBaslangic }, { "dtAktiviteBitis", dtAktiviteBitis }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, { "mnTahSabitBedel", mnTahSabitBedel }, { "mnYegSabitBedel", mnYegSabitBedel }, { "mnTahHedefCiro", mnTahHedefCiro }, { "mnYegHedefCiro", mnYegHedefCiro }, { "mnAktiviteKarZarar", mnAktiviteKarZarar }, { "flAktiviteKarZararYuzde", flAktiviteKarZararYuzde } };
            Do(QueryType.Update, "db_sp_aktiviteGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_aktiviteSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public aktiviteler GetObject()
        {
            aktiviteler donendeger = new aktiviteler();

            Dictionary<int, object> dic = GetObject("db_sp_aktiviteGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new aktiviteler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt16(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]), ConvertToDateTime(dic[6]), ConvertToDateTime(dic[7]), ConvertToBoolean(dic[8]), ConvertToDateTime(dic[9]), ConvertToDateTime(dic[10]), dic[11].ToString(), dic[12].ToString(), dic[13].ToString(), dic[14].ToString(), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), true);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<aktiviteler> GetObjects()
        {
            List<aktiviteler> donendeger = new List<aktiviteler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_aktivitelerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new aktiviteler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToDateTime(dic[i][6]), ConvertToDateTime(dic[i][7]), ConvertToBoolean(dic[i][8]), ConvertToDateTime(dic[i][9]), ConvertToDateTime(dic[i][10]), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), dic[i][14].ToString(), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<aktiviteler> GetObjects(int Yil, object Ay, object Aktarilmis)
        {
            List<aktiviteler> donendeger = new List<aktiviteler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_aktivitelerGetirByAkt", new Dictionary<string, object>() { { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new aktiviteler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToDateTime(dic[i][6]), ConvertToDateTime(dic[i][7]), ConvertToBoolean(dic[i][8]), ConvertToDateTime(dic[i][9]), ConvertToDateTime(dic[i][10]), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), dic[i][14].ToString(), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<aktiviteler> GetObjectsBySLSREF(int SLSREF, int Yil, object Ay, object Aktarilmis)
        {
            List<aktiviteler> donendeger = new List<aktiviteler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_aktivitelerGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new aktiviteler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToDateTime(dic[i][6]), ConvertToDateTime(dic[i][7]), ConvertToBoolean(dic[i][8]), ConvertToDateTime(dic[i][9]), ConvertToDateTime(dic[i][10]), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), dic[i][14].ToString(), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<aktiviteler> GetObjectsByGMREF(int GMREF, int Yil, object Ay, object Aktarilmis)
        {
            List<aktiviteler> donendeger = new List<aktiviteler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_aktivitelerGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new aktiviteler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToDateTime(dic[i][6]), ConvertToDateTime(dic[i][7]), ConvertToBoolean(dic[i][8]), ConvertToDateTime(dic[i][9]), ConvertToDateTime(dic[i][10]), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), dic[i][14].ToString(), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<aktiviteler> GetObjectsBySMREF(int SMREF, int AktiviteTipiID, int Yil, object Ay, object Aktarilmis)
        {
            List<aktiviteler> donendeger = new List<aktiviteler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_aktivitelerGetirBySMREF", new Dictionary<string, object>() { { "AktiviteTipiID", AktiviteTipiID }, { "SMREF", SMREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new aktiviteler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToDateTime(dic[i][6]), ConvertToDateTime(dic[i][7]), ConvertToBoolean(dic[i][8]), ConvertToDateTime(dic[i][9]), ConvertToDateTime(dic[i][10]), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), dic[i][14].ToString(), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), false));

            return donendeger;
        }
    }
}
