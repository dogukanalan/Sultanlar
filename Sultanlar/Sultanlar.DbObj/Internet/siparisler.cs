using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class siparisler : DbObj
    {
        public int pkSiparisID { get; set; }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { return new musteriler(intMusteriID).GetObject(); } }
        public int SMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(SMREF).GetObject(); } }
        public short sintFiyatTipiID { get; set; }
        public fiyatTipleri FiyatTipi { get { return new fiyatTipleri(sintFiyatTipiID).GetObject(); } }
        public DateTime dtOlusmaTarihi { get; set; }
        public double mnToplamTutar { get; set; }
        public double ToplamTutar { get { double toplam = 0; for (int i = 0; i < detaylar.Count; i++) { toplam += detaylar[i].mnFiyat * detaylar[i].intMiktar; } return toplam; } }
        public bool blAktarilmis { get; set; }
        public int TKSREF { get; set; }
        public DateTime dtOnaylamaTarihi { get; set; }
        public string strAciklama { get; set; }
        public string Aciklama1 { get { return strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0]; } }
        public string Aciklama2 { get { return strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[1]; } }
        public string Aciklama3 { get { return strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[2]; } }

        private bool detay { get; set; }
        public List<siparislerDetay> detaylar { get { if (detay) return new siparislerDetay().GetObjects(pkSiparisID); else return new List<siparislerDetay>(); } }

        public siparisler() { detay = false; }
        public siparisler(int pkSiparisID) { this.pkSiparisID = pkSiparisID; }
        public siparisler(int intMusteriID, int SMREF, short sintFiyatTipiID, DateTime dtOlusmaTarihi, double mnToplamTutar, bool blAktarilmis, int TKSREF, DateTime dtOnaylamaTarihi, string strAciklama)
        {
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.sintFiyatTipiID = sintFiyatTipiID;
            this.dtOlusmaTarihi = dtOlusmaTarihi;
            this.mnToplamTutar = mnToplamTutar;
            this.blAktarilmis = blAktarilmis;
            this.TKSREF = TKSREF;
            this.dtOnaylamaTarihi = dtOnaylamaTarihi;
            this.strAciklama = strAciklama;
        }
        private siparisler(int pkSiparisID, int intMusteriID, int SMREF, short sintFiyatTipiID, DateTime dtOlusmaTarihi, double mnToplamTutar, bool blAktarilmis, int TKSREF, DateTime dtOnaylamaTarihi, string strAciklama, bool detay)
        {
            this.pkSiparisID = pkSiparisID;
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.sintFiyatTipiID = sintFiyatTipiID;
            this.dtOlusmaTarihi = dtOlusmaTarihi;
            this.mnToplamTutar = mnToplamTutar;
            this.blAktarilmis = blAktarilmis;
            this.TKSREF = TKSREF;
            this.dtOnaylamaTarihi = dtOnaylamaTarihi;
            this.strAciklama = strAciklama;
            this.detay = detay;
        }

        public override string ToString() { return pkSiparisID.ToString(); }
        /*/// <summary>
        /// 
        /// </summary>
        private List<siparisler> Minimize(List<siparisler> Source, int Baslangic, int Kactane, Dictionary<string, string> Search, Dictionary<string, string> Order)
        {
            List<siparisler> donendeger = new List<siparisler>();

            for (int i = 0; i < Search.Count; i++)
            {
                if (Search.ToArray()[i].Key == "pkSiparisID")
                    Source = Source.ToList().Where(k => k.pkSiparisID.ToString().IndexOf(Search.ToArray()[i].Value) > -1).ToList();
            }

            for (int i = 0; i < Order.Count; i++)
            {
                if (Order.ToArray()[i].Key == "pkSiparisID")
                {
                    if (Order.ToArray()[i].Value == "asc")
                        Source = Source.ToList().OrderBy(k => k.pkSiparisID).ToList();
                    else
                        Source = Source.ToList().OrderByDescending(k => k.pkSiparisID).ToList();
                }
            }

            int sinir = (Baslangic + Kactane) < Source.Count ? (Baslangic + Kactane) : Source.Count;
            for (int i = Baslangic; i < sinir; i++)
                donendeger.Add(Source[i]);

            return donendeger;
        }*/
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkSiparisID", pkSiparisID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "sintFiyatTipiID", sintFiyatTipiID }, { "dtOlusmaTarihi", dtOlusmaTarihi }, { "mnToplamTutar", mnToplamTutar }, { "blAktarilmis", blAktarilmis }, { "TKSREF", TKSREF }, { "dtOnaylamaTarihi", dtOnaylamaTarihi }, { "strAciklama", strAciklama } };
            pkSiparisID = ConvertToInt32(Do(QueryType.Insert, "db_sp_siparisEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkSiparisID", pkSiparisID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "sintFiyatTipiID", sintFiyatTipiID }, { "dtOlusmaTarihi", dtOlusmaTarihi }, { "mnToplamTutar", mnToplamTutar }, { "blAktarilmis", blAktarilmis }, { "TKSREF", TKSREF }, { "dtOnaylamaTarihi", dtOnaylamaTarihi }, { "strAciklama", strAciklama } };
            Do(QueryType.Update, "db_sp_siparisGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_siparisSil", new Dictionary<string, object>() { { "pkSiparisID", pkSiparisID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public siparisler GetObject()
        {
            siparisler donendeger = new siparisler();

            Dictionary<int, object> dic = GetObject("db_sp_siparisGetir", new Dictionary<string, object>() { { "pkSiparisID", pkSiparisID } }, timeout);
            if (dic != null)
                donendeger = new siparisler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt16(dic[3]), ConvertToDateTime(dic[4]), ConvertToDouble(dic[5]), Convert.ToBoolean(dic[6]), ConvertToInt32(dic[7]), ConvertToDateTime(dic[8]), dic[9].ToString(), true);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisler> GetObjects()
        {
            List<siparisler> donendeger = new List<siparisler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), Convert.ToBoolean(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToDateTime(dic[i][8]), dic[i][9].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisler> GetObjects(object Aktarilmis)
        {
            List<siparisler> donendeger = new List<siparisler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerGetir", new Dictionary<string, object>() { { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), Convert.ToBoolean(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToDateTime(dic[i][8]), dic[i][9].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisler> GetObjectsBySLSREF(int SLSREF, int Yil, object Ay, object Aktarilmis)
        {
            List<siparisler> donendeger = new List<siparisler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), Convert.ToBoolean(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToDateTime(dic[i][8]), dic[i][9].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisler> GetObjectsByGMREF(int GMREF, int Yil, object Ay, object Aktarilmis)
        {
            List<siparisler> donendeger = new List<siparisler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), Convert.ToBoolean(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToDateTime(dic[i][8]), dic[i][9].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisler> GetObjectsBySMREF(int SMREF, int Yil, object Ay, object Aktarilmis)
        {
            List<siparisler> donendeger = new List<siparisler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparislerGetirBySMREF", new Dictionary<string, object>() { { "SMREF", SMREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt16(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), Convert.ToBoolean(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToDateTime(dic[i][8]), dic[i][9].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DoInsertQ(int SiparisID, string QUANTUMNO)
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "SiparisID", SiparisID }, { "QUANTUMNO", QUANTUMNO } };
            Do(QueryType.Update, "db_sp_siparisQEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public int DoInsertQLog(bool Yazildi, int SiparisID, string QuantumNo, int MusteriID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", 0 }, { "Yazildi", Yazildi }, { "SiparisID", SiparisID }, { "QuantumNo", QuantumNo }, { "Tarih", DateTime.Now }, { "MusteriID", MusteriID }, { "Terminal", "" }, { "SiparisTip", "SATIS" } };
            return ConvertToInt32(Do(QueryType.Insert, "db_sp_siparisQLogEkle", param, timeout));
        }
    }
}
