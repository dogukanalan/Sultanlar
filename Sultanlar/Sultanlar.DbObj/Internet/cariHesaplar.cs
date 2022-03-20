using System;
using System.Collections.Generic;
using System.Linq;

namespace Sultanlar.DbObj.Internet
{
    public class cariHesaplar : DbObj
    {
        public short ACTIVE { get; set; }
        public string BOLGE { get; set; }
        public string GRP { get; set; }
        public string EKP { get; set; }
        public string YTKKOD { get; set; }
        public string ILKOD { get; set; }
        public string IL { get; set; }
        public string ILCEKOD { get; set; }
        public string ILCE { get; set; }
        public int TIP { get; set; }
        public string TIP_ACK { get { return TIP == 1 ? "SAP MUSTERILERI" : TIP == 2 ? "SAP MUS.SUBELERI" : TIP == 3 ? "ZIYARET MUSTERILERI" : TIP == 4 ? "BAYII ALT CARILERI" : TIP == 5 ? "BAYII ALT CARI SUBELERI" : ""; } }
        public string MTKOD { get; set; }
        public string MTACIKLAMA { get; set; }
        public string UNVAN { get; set; }
        public int SLSREF { get; set; }
        public string SATKOD { get; set; }
        public string SATKOD1 { get; set; }
        public string SATTEM { get; set; }
        public int GMREF { get; set; }
        public string MUSKOD { get; set; }
        public string MUSTERI { get; set; }
        public int SMREF { get; set; }
        public string SUBKOD { get; set; }
        public string SUBE { get; set; }
        public string ADRES { get; set; }
        public string SEHIR { get; set; }
        public string SEMT { get; set; }
        public string VRGDAIRE { get; set; }
        public string VRGNO { get; set; }
        public string TEL1 { get; set; }
        public string FAX1 { get; set; }
        public string EMAIL1 { get; set; }
        public string ILGILI { get; set; }
        public string CEP1 { get; set; }
        public double NETTOP { get; set; }

        public bool BayiMi { get { return MTKOD == "Z1"; } }
        public bool AnaCariMi { get { return GMREF == SMREF; } }
        public int fiyatTip500 { get { return new fiyatTipleri().GetObjectByGMREF(GMREF).NOSU; } }
        public konumListe konumA { get { return new konumListe().GetObject(SMREF, TIP); } }

        public cariHesaplar() { }
        public cariHesaplar(int SMREF) { this.SMREF = SMREF; }
        public cariHesaplar(short ACTIVE, string BOLGE, string GRP, string EKP, string YTKKOD, string ILKOD, string IL, string ILCEKOD, string ILCE, int TIP, string MTKOD, string MTACIKLAMA, string UNVAN, int SLSREF, string SATKOD, string SATKOD1, string SATTEM, int GMREF, string MUSKOD, string MUSTERI, int SMREF, string SUBKOD, string SUBE, string ADRES, string SEHIR, string SEMT, string VRGDAIRE, string VRGNO, string TEL1, string FAX1, string EMAIL1, string ILGILI, string CEP1, double NETTOP)
        {
            this.ACTIVE = ACTIVE;
            this.BOLGE = BOLGE;
            this.GRP = GRP;
            this.EKP = EKP;
            this.YTKKOD = YTKKOD;
            this.ILKOD = ILKOD;
            this.IL = IL;
            this.ILCEKOD = ILCEKOD;
            this.ILCE = ILCE;
            this.TIP = TIP;
            this.MTKOD = MTKOD;
            this.MTACIKLAMA = MTACIKLAMA;
            this.UNVAN = UNVAN;
            this.SLSREF = SLSREF;
            this.SATKOD = SATKOD;
            this.SATKOD1 = SATKOD1;
            this.SATTEM = SATTEM;
            this.GMREF = GMREF;
            this.MUSKOD = MUSKOD;
            this.MUSTERI = MUSTERI;
            this.SMREF = SMREF;
            this.SUBKOD = SUBKOD;
            this.SUBE = SUBE;
            this.ADRES = ADRES;
            this.SEHIR = SEHIR;
            this.SEMT = SEMT;
            this.VRGDAIRE = VRGDAIRE;
            this.VRGNO = VRGNO;
            this.TEL1 = TEL1;
            this.FAX1 = FAX1;
            this.EMAIL1 = EMAIL1;
            this.ILGILI = ILGILI;
            this.CEP1 = CEP1;
            this.NETTOP = NETTOP;
        }
        
        public override string ToString() { return SUBE; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public cariHesaplar GetObject()
        {
            cariHesaplar donendeger = new cariHesaplar();

            Dictionary<int, object> dic = GetObject("db_sp_cariHesapGetir", new Dictionary<string, object>() { { "SMREF", SMREF } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplar(ConvertToInt16(dic[0]), dic[1].ToString(), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), ConvertToInt32(dic[13]), dic[14].ToString(), dic[15].ToString(), dic[16].ToString(), ConvertToInt32(dic[17]), dic[18].ToString(), dic[19].ToString(), ConvertToInt32(dic[20]), dic[21].ToString(), dic[22].ToString(), dic[23].ToString(), dic[24].ToString(), dic[25].ToString(), dic[26].ToString(), dic[27].ToString(), dic[28].ToString(), dic[29].ToString(), dic[30].ToString(), dic[31].ToString(), dic[32].ToString(), ConvertToDouble(dic[33]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public cariHesaplar GetObject1(int TIP, int SMREF)
        {
            cariHesaplar donendeger = new cariHesaplar();

            Dictionary<int, object> dic = GetObject("db_sp_cariHesapGetir1", new Dictionary<string, object>() { { "TIP", TIP }, { "SMREF", SMREF } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplar(ConvertToInt16(dic[0]), dic[1].ToString(), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), ConvertToInt32(dic[13]), dic[14].ToString(), dic[15].ToString(), dic[16].ToString(), ConvertToInt32(dic[17]), dic[18].ToString(), dic[19].ToString(), ConvertToInt32(dic[20]), dic[21].ToString(), dic[22].ToString(), dic[23].ToString(), dic[24].ToString(), dic[25].ToString(), dic[26].ToString(), dic[27].ToString(), dic[28].ToString(), dic[29].ToString(), dic[30].ToString(), dic[31].ToString(), dic[32].ToString(), ConvertToDouble(dic[33]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects()
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects(int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects1(int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetir1BySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
        /// <summary>
        /// web-musteri den sadece ana cariler, web-musteri-tp den sadece alt cariler gelecek. web-musteri-z yok
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects11(int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetir11BySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjectsOnlyMain(int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetirAnaCarilerBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            //donendeger.Add(new cariHesaplar(0, "", "", "", "", "", "", "", "", 1, "", "", "", 0, "", "", "", ConvertToInt32(dic[i][0]), "", dic[i][1].ToString(), 0, "", "", "", "", "", "", "", "", "", "", "", "", 0));
            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjectsOnlySub(int GMREF, int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetirSubelerBySLSREFGMREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects1OnlySub(int GMREF, int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetir1SubelerBySLSREFGMREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
        /// <summary>
        /// aktivite kopyalamada kullandık, web-musteri den ana cariler, web-musteri-tp den alt cariler geliyor. web-musteri den musteri bayi ismi gibi geliyor, web-musteri-tp den musteri web-musteri den bayi adını alıyor
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjectsTPOnlySub(int GMREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetirTPSubelerByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            return donendeger;
        }
    }
}
