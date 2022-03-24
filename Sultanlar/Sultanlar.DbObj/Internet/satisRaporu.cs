using Sultanlar.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class satisRaporu : DbObj
    {
        public string TUR { get; set; }
        public string TURACK { get; set; }
        public DateTime SIPTAR { get; set; }
        public DateTime FATTAR { get; set; }
        public string SIPNO { get; set; }
        public string FATNO { get; set; }
        public string FATNOMTB { get; set; }
        public int SLSREF { get; set; }
        public satisTemsilcileri Satici { get { return new satisTemsilcileri(SLSREF).GetObject(); } }
        public int GMREF { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(GMREF).GetObject();  if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public int SMREF { get; set; }
        public cariHesaplar Sube { get { cariHesaplar carisube = new cariHesaplar(SMREF).GetObject(); if (cariSube) return carisube; else { cariHesaplar cari = new cariHesaplar(); cari.SUBE = carisube.SUBE; return cari; } } }
        public int ITEMREF { get; set; }
        public malzemeler Malzeme { get { malzemeler mal = new malzemeler(ITEMREF).GetObject(); if (malzeme) return mal; else { malzemeler rmal = new malzemeler(); rmal.MALACIK = mal.MALACIK; return rmal; } } }
        public string FTUR { get; set; }
        public string FTIP_ACK { get; set; }
        public double ADETT { get; set; }
        public double KOLIT { get; set; }
        public double BRUTT { get; set; }
        public double NETT { get; set; }
        public double ISKT { get; set; }
        public double NETKDVT { get; set; }

        public int YIL { get { return FATTAR.Year; } }
        public int AY { get { return FATTAR.Month; } }
        public double BRUTBIRIM { get { return ADETT != 0 ? BRUTT / ADETT : BRUTT; } }
        private double NETBIRIM { get { return ADETT != 0 ? NETT / ADETT : NETT; } }

        private bool cariAna { get; set; }
        private bool cariSube { get; set; }
        private bool malzeme { get; set; }

        public satisRaporu() { }
        private satisRaporu(string TUR, string TURACK, DateTime SIPTAR, DateTime FATTAR, string SIPNO, string FATNO, string FATNOMTB, int SLSREF, int GMREF, int SMREF, int ITEMREF, string FTUR, string FTIP_ACK, double ADETT, double KOLIT, double BRUTT, double NETT, double ISKT, double NETKDVT, bool cariAna, bool cariSube, bool malzeme)
        {
            this.TUR = TUR;
            this.TURACK = TURACK;
            this.SIPTAR = SIPTAR;
            this.FATTAR = FATTAR;
            this.SIPNO = SIPNO;
            this.FATNO = FATNO;
            this.FATNOMTB = FATNOMTB;
            this.SLSREF = SLSREF;
            this.GMREF = GMREF;
            this.SMREF = SMREF;
            this.ITEMREF = ITEMREF;
            this.FTUR = FTUR;
            this.FTIP_ACK = FTIP_ACK;
            this.ADETT = ADETT;
            this.KOLIT = KOLIT;
            this.BRUTT = BRUTT;
            this.NETT = NETT;
            this.ISKT = ISKT;
            this.NETKDVT = NETKDVT;
            this.cariAna = cariAna;
            this.cariSube = cariSube;
            this.malzeme = malzeme;
        }

        public override string ToString() { return FATNO; }
        /// <summary>
        /// YIL ve AY zorunlu, diğerleri DBNull.Value olabilir
        /// </summary>
        /// <returns></returns>
        public List<satisRaporu> GetObjects(int YIL, object AY, int SLSREF, object GMREF, object SMREF, object ITEMREF)
        {
            List<satisRaporu> donendeger = new List<satisRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_satisRaporGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF }, { "GMREF", GMREF }, { "SMREF", SMREF }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisRaporu(dic[i][0].ToString(), dic[i][1].ToString(), ConvertToDateTime(dic[i][2]), ConvertToDateTime(dic[i][3]), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToInt32(dic[i][9]), ConvertToInt32(dic[i][10]), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), true, true, true));

            return donendeger;
        }
    }

    public class satisRaporuOzet : DbObj
    {
        public int YIL { get; set; }
        public int AY { get; set; }
        public int SLSREF { get; set; }
        public satisTemsilcileri Satici { get { return new satisTemsilcileri(SLSREF).GetObject(); } }
        public int GMREF { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(GMREF).GetObject(); if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public string KAT { get; set; }
        public double ADETT { get; set; }
        public double KOLIT { get; set; }
        public double NETT { get; set; }

        private bool cariAna { get; set; }

        public satisRaporuOzet() { }
        private satisRaporuOzet(int YIL, int AY, int SLSREF, int GMREF, string KAT, double ADETT, double KOLIT, double NETT, bool cariAna)
        {
            this.YIL = YIL;
            this.AY = AY;
            this.SLSREF = SLSREF;
            this.GMREF = GMREF;
            this.KAT = KAT;
            this.ADETT = ADETT;
            this.KOLIT = KOLIT;
            this.NETT = NETT;
            this.cariAna = cariAna;
        }

        public override string ToString() { return KOLIT.ToString("N0"); }
        /// <summary>
        /// GMREF boş şimdilik
        /// </summary>
        /// <returns></returns>
        public List<satisRaporuOzet> GetObjects(int YIL, object AY, object SLSREF, string TUR, object GMREF)
        {
            List<satisRaporuOzet> donendeger = new List<satisRaporuOzet>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_satisRaporOzetGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF }, { "TUR", TUR }, { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisRaporuOzet(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), dic[i][4].ToString(), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToDouble(dic[i][7]), false));

            return donendeger;
        }
    }

    public class satisRaporuKars : DbObj
    {
        public int YIL { get; set; }
        public int AY { get; set; }
        public int SLSREF { get; set; }
        public satisTemsilcileri Satici { get { return new satisTemsilcileri(SLSREF).GetObject(); } }
        public int GMREF { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(GMREF).GetObject(); if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public string KAT { get; set; }
        public double YILADETT { get; set; }
        public double YILKOLIT { get; set; }
        public double YILNETT { get; set; }
        public double OYILADETT { get; set; }
        public double OYILKOLIT { get; set; }
        public double OYILNETT { get; set; }

        private bool cariAna { get; set; }

        public satisRaporuKars() { }
        private satisRaporuKars(int YIL, int AY, int SLSREF, int GMREF, string KAT, double YILADETT, double YILKOLIT, double YILNETT, double OYILADETT, double OYILKOLIT, double OYILNETT, bool cariAna)
        {
            this.YIL = YIL;
            this.AY = AY;
            this.SLSREF = SLSREF;
            this.GMREF = GMREF;
            this.KAT = KAT;
            this.YILADETT = YILADETT;
            this.YILKOLIT = YILKOLIT;
            this.YILNETT = YILNETT;
            this.OYILADETT = OYILADETT;
            this.OYILKOLIT = OYILKOLIT;
            this.OYILNETT = OYILNETT;
            this.cariAna = cariAna;
        }

        public override string ToString() { return YILKOLIT.ToString("N0"); }
        /// <summary>
        /// GMREF boş şimdilik
        /// </summary>
        /// <returns></returns>
        public List<satisRaporuKars> GetObjects(int YIL, object AY, object SLSREF, string TUR, object GMREF)
        {
            List<satisRaporuKars> donendeger = new List<satisRaporuKars>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_satisRaporKarsGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF }, { "TUR", TUR }, { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisRaporuKars(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), dic[i][4].ToString(), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), false));

            return donendeger;
        }
    }

    public class satisDashboard : DbObj
    {
        public List<BolumYillik> GetBolumYillik(int YIL, int SLSREF)
        {
            List<BolumYillik> donendeger = new List<BolumYillik>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_dashboardYillikBolum", new Dictionary<string, object>() { { "YIL", YIL }, { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new BolumYillik(dic[i][0].ToString(), ConvertToInt32(dic[i][1]), Convert.ToInt32(dic[i][2])));

            return donendeger;
        }
        public List<BayiSatisHedef> GetBayiSatisHedef(int YIL, int AY)
        {
            List<BayiSatisHedef> donendeger = new List<BayiSatisHedef>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_dashboardBayiSatisHedef", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new BayiSatisHedef(dic[i][0].ToString(), Convert.ToInt32(dic[i][1]), Convert.ToInt32(dic[i][2])));

            return donendeger;
        }
        public List<SatisHedefVgb> GetSatisHedefVgb(int YIL, int AY)
        {
            List<SatisHedefVgb> donendeger = new List<SatisHedefVgb>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_dashboardSatisHedefVgb", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new SatisHedefVgb(dic[i][0].ToString(), Convert.ToInt32(dic[i][1]), Convert.ToInt32(dic[i][2]), Convert.ToInt32(dic[i][3]), Convert.ToDouble(dic[i][4]), Convert.ToDouble(dic[i][5])));

            return donendeger;
        }
        public List<SatisHedefBolge> GetSatisHedefBolge(int YIL, int AY)
        {
            List<SatisHedefBolge> donendeger = new List<SatisHedefBolge>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_dashboardSatisHedefVgb2", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new SatisHedefBolge(dic[i][0].ToString(), Convert.ToInt32(dic[i][1]), Convert.ToInt32(dic[i][2]), Convert.ToInt32(dic[i][3])));

            return donendeger;
        }
    }
}
