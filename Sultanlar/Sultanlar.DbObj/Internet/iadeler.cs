using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class iadeler : DbObj
    {
        public int pkIadeID { get; set; }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { return new musteriler(intMusteriID).GetObject(); } }
        public int SMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(SMREF).GetObject(); } }
        public DateTime dtOlusmaTarihi { get; set; }
        public double mnToplamTutar { get; set; }
        public double ToplamTutar { get { double toplam = 0; for (int i = 0; i < detaylar.Count; i++) { toplam += detaylar[i].mnFiyat * detaylar[i].intMiktar; } return toplam; } }
        public bool blAktarilmis { get; set; }
        public DateTime dtOnaylamaTarihi { get; set; }
        public string strAciklama { get; set; }
        public string Aciklama1 { get { return strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[0]; } }
        public string Aciklama2 { get { return strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[1]; } }
        public string Aciklama3 { get { return strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None)[2]; } }
        public string strNedenKod { get; set; }
        public string strDepoKod { get; set; }
        public string strDepoUY { get; set; }
        public string strPartiNo { get; set; }

        /// <summary>
        /// 0:kaydedilmiş, 1:fiyatlandırılmamış, 2:fiyatlandırılmış, 3:sevk bekleyen, 4:red, 5:son
        /// </summary>
        public int tur
        {
            get
            {
                if (!blAktarilmis && mnToplamTutar == 0)
                    return 0;
                else if (blAktarilmis && mnToplamTutar == 0)
                    return 1;
                else if (blAktarilmis && mnToplamTutar > 0)
                    return 2;
                else if (!blAktarilmis && mnToplamTutar > 0)
                    return 3;
                else if (!blAktarilmis && mnToplamTutar == -1)
                    return 4;
                else if (!blAktarilmis && mnToplamTutar == -2)
                    return 5;

                return 0;
            }
        }

        private bool detay { get; set; }
        public List<iadelerDetay> detaylar { get { if (detay) return new iadelerDetay().GetObjects(pkIadeID); else return new List<iadelerDetay>(); } }
        public List<iadeHareketleri> hareketler { get { return new iadeHareketleri().GetObjects(pkIadeID); } }

        public iadeler() { detay = false; }
        public iadeler(int pkIadeID) { this.pkIadeID = pkIadeID; }
        public iadeler(int intMusteriID, int SMREF, DateTime dtOlusmaTarihi, double mnToplamTutar, bool blAktarilmis, DateTime dtOnaylamaTarihi, string strAciklama, string strNedenKod, string strDepoKod, string strDepoUY, string strPartiNo)
        {
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.dtOlusmaTarihi = dtOlusmaTarihi;
            this.mnToplamTutar = mnToplamTutar;
            this.blAktarilmis = blAktarilmis;
            this.dtOnaylamaTarihi = dtOnaylamaTarihi;
            this.strAciklama = strAciklama;
            this.strNedenKod = strNedenKod;
            this.strDepoKod = strDepoKod;
            this.strDepoUY = strDepoUY;
            this.strPartiNo = strPartiNo;
        }
        private iadeler(int pkIadeID, int intMusteriID, int SMREF, DateTime dtOlusmaTarihi, double mnToplamTutar, bool blAktarilmis, DateTime dtOnaylamaTarihi, string strAciklama, string strNedenKod, string strDepoKod, string strDepoUY, string strPartiNo, bool detay)
        {
            this.pkIadeID = pkIadeID;
            this.intMusteriID = intMusteriID;
            this.SMREF = SMREF;
            this.dtOlusmaTarihi = dtOlusmaTarihi;
            this.mnToplamTutar = mnToplamTutar;
            this.blAktarilmis = blAktarilmis;
            this.dtOnaylamaTarihi = dtOnaylamaTarihi;
            this.strAciklama = strAciklama;
            this.strNedenKod = strNedenKod;
            this.strDepoKod = strDepoKod;
            this.strDepoUY = strDepoUY;
            this.strPartiNo = strPartiNo;
            this.detay = detay;
        }

        public override string ToString() { return pkIadeID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkIadeID", pkIadeID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "dtOlusmaTarihi", dtOlusmaTarihi }, { "mnToplamTutar", mnToplamTutar }, { "blAktarilmis", blAktarilmis }, { "dtOnaylamaTarihi", dtOnaylamaTarihi }, { "strAciklama", strAciklama }, { "strNedenKod", strNedenKod }, { "strDepoKod", strDepoKod }, { "strDepoUY", strDepoUY }, { "strPartiNo", strPartiNo } };
            pkIadeID = ConvertToInt32(Do(QueryType.Insert, "db_sp_iadeEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkIadeID", pkIadeID }, { "intMusteriID", intMusteriID }, { "SMREF", SMREF }, { "dtOlusmaTarihi", dtOlusmaTarihi }, { "mnToplamTutar", mnToplamTutar }, { "blAktarilmis", blAktarilmis }, { "dtOnaylamaTarihi", dtOnaylamaTarihi }, { "strAciklama", strAciklama }, { "strNedenKod", strNedenKod }, { "strDepoKod", strDepoKod }, { "strDepoUY", strDepoUY }, { "strPartiNo", strPartiNo } };
            Do(QueryType.Update, "db_sp_iadeGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_iadeSil", new Dictionary<string, object>() { { "pkIadeID", pkIadeID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public iadeler GetObject()
        {
            iadeler donendeger = new iadeler();

            Dictionary<int, object> dic = GetObject("db_sp_iadeGetir", new Dictionary<string, object>() { { "pkIadeID", pkIadeID } }, timeout);
            if (dic != null)
                donendeger = new iadeler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToDateTime(dic[3]), ConvertToDouble(dic[4]), Convert.ToBoolean(dic[5]), ConvertToDateTime(dic[6]), dic[7].ToString(), dic[8].ToString(), dic[9].ToString(), dic[10].ToString(), dic[11].ToString(), true);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeler> GetObjects()
        {
            List<iadeler> donendeger = new List<iadeler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadelerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDouble(dic[i][4]), Convert.ToBoolean(dic[i][5]), ConvertToDateTime(dic[i][6]), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeler> GetObjects(object Aktarilmis)
        {
            List<iadeler> donendeger = new List<iadeler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadelerGetir", new Dictionary<string, object>() { { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDouble(dic[i][4]), Convert.ToBoolean(dic[i][5]), ConvertToDateTime(dic[i][6]), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeler> GetObjectsBySLSREF(int SLSREF, int Yil, object Ay, object Aktarilmis)
        {
            List<iadeler> donendeger = new List<iadeler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadelerGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDouble(dic[i][4]), Convert.ToBoolean(dic[i][5]), ConvertToDateTime(dic[i][6]), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeler> GetObjectsByGMREF(int GMREF, int Yil, object Ay, object Aktarilmis)
        {
            List<iadeler> donendeger = new List<iadeler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadelerGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDouble(dic[i][4]), Convert.ToBoolean(dic[i][5]), ConvertToDateTime(dic[i][6]), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iadeler> GetObjectsBySMREF(int SMREF, int Yil, object Ay, object Aktarilmis)
        {
            List<iadeler> donendeger = new List<iadeler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_iadelerGetirBySMREF", new Dictionary<string, object>() { { "SMREF", SMREF }, { "Yil", Yil }, { "Ay", Ay }, { "blAktarilmis", Aktarilmis } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new iadeler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), ConvertToDouble(dic[i][4]), Convert.ToBoolean(dic[i][5]), ConvertToDateTime(dic[i][6]), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DoInsertQ(int SiparisID, string QUANTUMNO)
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "SiparisID", SiparisID }, { "QUANTUMNO", QUANTUMNO } };
            Do(QueryType.Update, "db_sp_iadeQEkle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public void DoInsertQLog(bool Yazildi, int SiparisID, string QuantumNo, string Terminal)
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "Yazildi", Yazildi }, { "SiparisID", SiparisID }, { "QuantumNo", QuantumNo }, { "Tarih", DateTime.Now }, { "MusteriID", 0 }, { "Terminal", Terminal }, { "SiparisTip", "IADE" } };
            Do(QueryType.Update, "db_sp_iadeQLogEkle", param, timeout);
        }
    }
}
