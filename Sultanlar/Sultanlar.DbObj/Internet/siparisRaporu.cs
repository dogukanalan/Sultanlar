using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class siparisRaporu : DbObj
    {
        public int SIPNO { get; set; }
        public int WEBSIPNO { get; set; }
        public DateTime TARIH { get; set; }
        public int GMREF { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(GMREF).GetObject(); if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public int SMREF { get; set; }
        public cariHesaplar Sube { get { cariHesaplar carisube = new cariHesaplar(SMREF).GetObject(); if (cariSube) return carisube; else { cariHesaplar cari = new cariHesaplar(); cari.SUBE = carisube.SUBE; return cari; } } }
        public string BOLUM { get; set; }
        public string ACIKLAMA { get; set; }
        public double BRUTT { get; set; }
        public double NETT { get; set; }
        public double ISKT { get; set; }
        public double KOLIT { get; set; }

        private bool cariAna { get; set; }
        private bool cariSube { get; set; }

        public siparisRaporu() { }
        private siparisRaporu(int SIPNO, int WEBSIPNO, DateTime TARIH, int GMREF, int SMREF, string BOLUM, string ACIKLAMA, double BRUTT, double NETT, double ISKT, double KOLIT, bool cariAna, bool cariSube)
        {
            this.SIPNO = SIPNO;
            this.WEBSIPNO = WEBSIPNO;
            this.TARIH = TARIH;
            this.GMREF = GMREF;
            this.SMREF = SMREF;
            this.BOLUM = BOLUM;
            this.ACIKLAMA = ACIKLAMA;
            this.BRUTT = BRUTT;
            this.NETT = NETT;
            this.ISKT = ISKT;
            this.KOLIT = KOLIT;
            this.cariAna = cariAna;
            this.cariSube = cariSube;
        }

        public override string ToString() { return SIPNO.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisRaporu> GetObjects(int YIL, object AY, int SLSREF)
        {
            List<siparisRaporu> donendeger = new List<siparisRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparisRaporGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisRaporu(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToDateTime(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), dic[i][5].ToString(), dic[i][6].ToString(), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), false, false));

            return donendeger;
        }
    }

    public class siparisDetayRaporu : DbObj
    {
        public int SIPNO { get; set; }
        public string WEBSIPNO { get; set; }
        public DateTime TARIH { get; set; }
        public int GMREF { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(GMREF).GetObject(); if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public int SMREF { get; set; }
        public cariHesaplar Sube { 
            get 
            {
                cariHesaplar carisube = new cariHesaplar();
                if (AnaCari.MTKOD == "Z1")
                {
                    carisube = new cariHesaplar().GetObject1(4, SMREF);
                }
                else
                {
                    carisube = new cariHesaplar(SMREF).GetObject();
                }

                if (cariSube) 
                { 
                    return carisube; 
                }
                else 
                { 
                    cariHesaplar cari = new cariHesaplar(); cari.SUBE = carisube.SUBE; return cari; 
                } 
            } 
        }
        public int MALKOD { get; set; }
        public string ACIKLAMA { get; set; }
        public double BRUTT { get; set; }
        public double NETT { get; set; }
        public double ADT { get; set; }
        public double KOLIT { get; set; }
        public int SVKADT { get; set; }
        public int BKYADT { get; set; }
        public int STOK { get; set; }

        public double NET { get { return ADT > 0 ? NETT / ADT : NETT; } }
        private bool cariAna { get; set; }
        private bool cariSube { get; set; }

        public siparisDetayRaporu() { }
        private siparisDetayRaporu(int SIPNO, string WEBSIPNO, DateTime TARIH, int GMREF, int SMREF, int MALKOD, string ACIKLAMA, double BRUTT, double NETT, double ADT, double KOLIT, int SVKADT, int BKYADT, int STOK, bool cariAna, bool cariSube)
        {
            this.SIPNO = SIPNO;
            this.WEBSIPNO = WEBSIPNO;
            this.TARIH = TARIH;
            this.GMREF = GMREF;
            this.SMREF = SMREF;
            this.MALKOD = MALKOD;
            this.ACIKLAMA = ACIKLAMA;
            this.BRUTT = BRUTT;
            this.NETT = NETT;
            this.ADT = ADT;
            this.KOLIT = KOLIT;
            this.SVKADT = SVKADT;
            this.BKYADT = BKYADT;
            this.STOK = STOK;
            this.cariAna = cariAna;
            this.cariSube = cariSube;
        }

        public override string ToString() { return SIPNO.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisDetayRaporu> GetObjects(int YIL, int AY, int SLSREF, object SIPNO)
        {
            List<siparisDetayRaporu> donendeger = new List<siparisDetayRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparisDetayRaporGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF }, { "SIPNO", SIPNO } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisDetayRaporu(ConvertToInt32(dic[i][0]), dic[i][1].ToString(), ConvertToDateTime(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), dic[i][6].ToString(), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToInt32(dic[i][11]), ConvertToInt32(dic[i][12]), ConvertToInt32(dic[i][13]), false, false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisDetayRaporu> GetObjectsTp(int YIL, object AY, int SLSREF, object SIPNO)
        {
            List<siparisDetayRaporu> donendeger = new List<siparisDetayRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparisDetayRaporTpGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF }, { "SIPNO", SIPNO } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisDetayRaporu(ConvertToInt32(dic[i][0]), dic[i][1].ToString(), ConvertToDateTime(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), dic[i][6].ToString(), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToInt32(dic[i][11]), ConvertToInt32(dic[i][12]), ConvertToInt32(dic[i][13]), true, true));

            return donendeger;
        }
    }

    public class siparisDurumRaporu : DbObj
    {
        public DateTime SIPTAR { get; set; }
        public int WEBNO { get; set; }
        public int SIPNO { get; set; }
        public cariHesaplar AnaCari { get { cariHesaplar cariana = new cariHesaplar(Sube.GMREF).GetObject(); if (cariAna) return cariana; else { cariHesaplar cari = new cariHesaplar(); cari.MUSTERI = cariana.MUSTERI; return cari; } } }
        public int MUSKOD { get; set; }
        public cariHesaplar Sube { get { cariHesaplar carisube = new cariHesaplar(MUSKOD).GetObject(); if (cariSube) return carisube; else { cariHesaplar cari = new cariHesaplar(); cari.SUBE = carisube.SUBE; cari.GMREF = carisube.GMREF; return cari; } } }
        public int MALKOD { get; set; }
        public malzemeler Malzeme { get { malzemeler malz = new malzemeler(MALKOD).GetObject(); if (malzeme) return malz; else { malzemeler mal = new malzemeler(); mal.MALACIK = malz.MALACIK; return mal; } } }
        public int SIPAD { get; set; }
        public int TSLAD { get; set; }
        public int IRSAD { get; set; }
        public int BKYAD { get; set; }
        public int IPTAD { get; set; }
        public string RED { get; set; }

        private bool cariAna { get; set; }
        private bool cariSube { get; set; }
        private bool malzeme { get; set; }

        public siparisDurumRaporu() { }
        private siparisDurumRaporu(DateTime SIPTAR, int WEBNO, int SIPNO, int MUSKOD, int MALKOD, int SIPAD, int TSLAD, int IRSAD, int BKYAD, int IPTAD, string RED, bool cariAna, bool cariSube, bool malzeme)
        {
            this.SIPTAR = SIPTAR;
            this.SIPNO = SIPNO;
            this.WEBNO = WEBNO;
            this.MUSKOD = MUSKOD;
            this.MALKOD = MALKOD;
            this.SIPAD = SIPAD;
            this.TSLAD = TSLAD;
            this.IRSAD = IRSAD;
            this.BKYAD = BKYAD;
            this.IPTAD = IPTAD;
            this.RED = RED;
            this.cariAna = cariAna;
            this.cariSube = cariSube;
            this.malzeme = malzeme;
        }

        public override string ToString() { return SIPNO.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<siparisDurumRaporu> GetObjects(int YIL, object AY, int SLSREF, object SIPNO)
        {
            List<siparisDurumRaporu> donendeger = new List<siparisDurumRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_siparisDurumRaporGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF }, { "SIPNO", SIPNO } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new siparisDurumRaporu(ConvertToDateTime(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), false, false, false));

            return donendeger;
        }
    }
}
