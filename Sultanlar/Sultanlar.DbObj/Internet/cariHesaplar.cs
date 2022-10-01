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

        public bool Subelerden { get; set; }
        public bool BayiMi { get { return MTKOD == "Z1"; } }
        public bool AnaCariMi { get { return GMREF == SMREF; } }
        public string AnaCari { get { if (Subelerden) return ""; return AnaCariMi ? MUSTERI : new cariHesaplar().GetObject1(1, GMREF).MUSTERI; } }
        public int fiyatTip500 { get { if (Subelerden) return 0; fiyatTipleri tip = TIP == 1 ? new fiyatTipleri().GetObjectByGMREF(GMREF) : TIP == 4 ? new fiyatTipleri().GetObjectByGMREF(SMREF) : TIP == 5 ? new fiyatTipleri().GetObjectByGMREF(Convert.ToInt32(NETTOP)) : new fiyatTipleri(); fiyatTip500ack = tip.ACIKLAMA; return tip.NOSU; } } //fiyatTipleri tip = TIP == 1 ? new fiyatTipleri().GetObjectByGMREF(GMREF) : TIP == 4 || TIP == 5 ? new fiyatTipleri().GetObjectVyByGMREF(SMREF) : new fiyatTipleri();
        public string fiyatTip500ack { get; set; }
        public int fiyatTip500smref { get { if (Subelerden) return 0; fiyatTipleri tip = new fiyatTipleri().GetObjectByGMREF(SMREF); fiyatTip500smrefack = tip.ACIKLAMA; return tip.NOSU; } } //GetObjectVyByGMREF
        public string fiyatTip500smrefack { get; set; }
        public konumListe konumA { get { return new konumListe().GetObject(SMREF, TIP); } }
        public cariHesaplarAcik acik { get { if (Subelerden) return new cariHesaplarAcik(); return new cariHesaplarAcik(SMREF, TIP).GetObject(); } }


        public cariHesaplar() { Subelerden = false; }
        public cariHesaplar(int SMREF) { this.SMREF = SMREF; }
        public cariHesaplar(short ACTIVE, string BOLGE, string GRP, string EKP, string YTKKOD, string ILKOD, string IL, string ILCEKOD, string ILCE, int TIP, string MTKOD, string MTACIKLAMA, string UNVAN, int SLSREF, string SATKOD, string SATKOD1, string SATTEM, int GMREF, string MUSKOD, string MUSTERI, int SMREF, string SUBKOD, string SUBE, string ADRES, string SEHIR, string SEMT, string VRGDAIRE, string VRGNO, string TEL1, string FAX1, string EMAIL1, string ILGILI, string CEP1, double NETTOP, bool Subelerden)
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

            this.Subelerden = Subelerden;
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
                donendeger = new cariHesaplar(ConvertToInt16(dic[0]), dic[1].ToString(), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), ConvertToInt32(dic[13]), dic[14].ToString(), dic[15].ToString(), dic[16].ToString(), ConvertToInt32(dic[17]), dic[18].ToString(), dic[19].ToString(), ConvertToInt32(dic[20]), dic[21].ToString(), dic[22].ToString(), dic[23].ToString(), dic[24].ToString(), dic[25].ToString(), dic[26].ToString(), dic[27].ToString(), dic[28].ToString(), dic[29].ToString(), dic[30].ToString(), dic[31].ToString(), dic[32].ToString(), ConvertToDouble(dic[33]), false);

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
                donendeger = new cariHesaplar(ConvertToInt16(dic[0]), dic[1].ToString(), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), ConvertToInt32(dic[9]), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), ConvertToInt32(dic[13]), dic[14].ToString(), dic[15].ToString(), dic[16].ToString(), ConvertToInt32(dic[17]), dic[18].ToString(), dic[19].ToString(), ConvertToInt32(dic[20]), dic[21].ToString(), dic[22].ToString(), dic[23].ToString(), dic[24].ToString(), dic[25].ToString(), dic[26].ToString(), dic[27].ToString(), dic[28].ToString(), dic[29].ToString(), dic[30].ToString(), dic[31].ToString(), dic[32].ToString(), ConvertToDouble(dic[33]), false);

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), false));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), false));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), false));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), false));

            return donendeger;
        }
        /// <summary>
        /// web-musteri, web-musteri-z, web-musteri-tp
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects12(int SLSREF)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetir12BySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), false));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), false));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), true));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), true));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cariHesaplar> GetObjects1OnlySub(int GMREF, int SLSREF, bool Subelerden)
        {
            List<cariHesaplar> donendeger = new List<cariHesaplar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_cariHesaplarGetir1SubelerBySLSREFGMREF", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), Subelerden));

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
                    donendeger.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33]), true));

            return donendeger;
        }
    }

    public class cariHesaplarAcik : DbObj
    {
        public int SMREF { get; set; }
        public int TIP { get; set; }
        public DateTime TARIH { get; set; }
        public bool PASIF { get; set; }
        public int KAYNAKKOD { get; set; }
        public cariHesaplarAcikKaynak KAYNAKACK { get { return new cariHesaplarAcikKaynak().GetObject(KAYNAKKOD); } }
        public string KONUM { get; set; }
        public string KONUMADRES { get; set; }
        public byte[] KONUMRESIM { get; set; }
        public string TABELAUNVANI { get; set; }
        public int TURKOD { get; set; }
        public int KASASAYISI { get; set; }
        public string YUZOLCUMU { get; set; }
        public List<cariHesaplarAcikGunler> GUNLER { get{ return new cariHesaplarAcikGunler().GetObjects(SMREF, TIP); } }
        public List<cariHesaplarAcikYetkili> YETKILILER { get { return new cariHesaplarAcikYetkili().GetObjects(SMREF, TIP); } }
        public cariHesaplarAcik() { }
        public cariHesaplarAcik(int SMREF, int TIP)
        {
            this.SMREF = SMREF;
            this.TIP = TIP;
        }
        public cariHesaplarAcik GetObject()
        {
            cariHesaplarAcik donendeger = new cariHesaplarAcik();

            Dictionary<int, object> dic = GetObject("SELECT [SMREF],[TIP],[TARIH],[PASIF],[KAYNAK_KOD],[KONUM],[KONUM_ADRES],[KONUM_RESIM],[TABELA_UNVANI],[TUR_KOD],[KASA_SAYISI],[YUZOLCUMU] FROM [Web-Musteri-Acik] WHERE SMREF = @SMREF AND TIP = @TIP", new Dictionary<string, object>() { { "TIP", TIP }, { "SMREF", SMREF } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplarAcik() { SMREF = ConvertToInt32(dic[0]), TIP = ConvertToInt32(dic[1]), TARIH = ConvertToDateTime(dic[2]), PASIF = Convert.ToBoolean(dic[3]), KAYNAKKOD = ConvertToInt32(dic[4]), KONUM = dic[5].ToString(), KONUMADRES = dic[6].ToString(), KONUMRESIM = ConvertToByteArray(dic[7]), TABELAUNVANI = dic[8].ToString(), TURKOD = ConvertToInt32(dic[9]), KASASAYISI = ConvertToInt32(dic[10]), YUZOLCUMU = dic[11].ToString() };

            return donendeger;
        }
    }
    public class cariHesaplarAcikGunler : DbObj
    {
        public int KOD { get; set; }
        public int GUNKOD { get; set; }
        public cariHesaplarAcikGunTur GUNACK { get { return new cariHesaplarAcikGunTur().GetObject(GUNKOD); } }
        public int SMREF { get; set; }
        public int MTIP { get; set; }
        public DateTime BASLANGIC { get; set; }
        public DateTime BITIS { get; set; }
        public string ACIKLAMA { get; set; }
        public int HAFTANIN_GUNU { get; set; }
        public string haftaningunu { get { return HAFTANIN_GUNU == 1 ? "Pazartesi" : HAFTANIN_GUNU == 2 ? "Salı" : HAFTANIN_GUNU == 3 ? "Çarşamba" : HAFTANIN_GUNU == 4 ? "Perşembe" : HAFTANIN_GUNU == 5 ? "Cuma" : HAFTANIN_GUNU == 6 ? "Cumartesi" : HAFTANIN_GUNU == 7 ? "Pazar" : ""; } }
        public cariHesaplarAcikGunler() { }
        public cariHesaplarAcikGunler(int KOD)
        {
            this.KOD = KOD;
        }
        public cariHesaplarAcikGunler GetObject()
        {
            cariHesaplarAcikGunler donendeger = new cariHesaplarAcikGunler();

            Dictionary<int, object> dic = GetObject("SELECT [KOD],[GUN_KOD],[SMREF],[MTIP],[BASLANGIC],[BITIS],[ACIKLAMA] FROM [Web-Musteri-Acik-Gunler] WHERE KOD = @KOD", new Dictionary<string, object>() { { "KOD", KOD } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplarAcikGunler() { KOD = ConvertToInt32(dic[0]), GUNKOD = ConvertToInt32(dic[1]), SMREF = ConvertToInt32(dic[2]), MTIP = ConvertToInt32(dic[3]), BASLANGIC = ConvertToDateTime(dic[4]), BITIS = ConvertToDateTime(dic[5]), ACIKLAMA = dic[6].ToString() };

            return donendeger;
        }
        public List<cariHesaplarAcikGunler> GetObjects(int SMREF, int MTIP)
        {
            List<cariHesaplarAcikGunler> donendeger = new List<cariHesaplarAcikGunler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("SELECT [KOD],[GUN_KOD],[SMREF],[MTIP],[BASLANGIC],[BITIS],[ACIKLAMA] FROM [Web-Musteri-Acik-Gunler] WHERE SMREF = @SMREF AND MTIP = @MTIP", new Dictionary<string, object>() { { "SMREF", SMREF }, { "MTIP", MTIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplarAcikGunler { KOD = ConvertToInt32(dic[i][0]), GUNKOD = ConvertToInt32(dic[i][1]), SMREF = ConvertToInt32(dic[i][2]), MTIP = ConvertToInt32(dic[i][3]), BASLANGIC = ConvertToDateTime(dic[i][4]), BITIS = ConvertToDateTime(dic[i][5]), ACIKLAMA = dic[i][6].ToString() });

            return donendeger;
        }
    }
    public class cariHesaplarAcikYetkili : DbObj
    {
        public int KOD { get; set; }
        public int SMREF { get; set; }
        public int TIP { get; set; }
        public DateTime TARIH { get; set; }
        public bool PASIF { get; set; }
        public int TUR { get; set; }
        public cariHesaplarAcikYetkiliTur TURACK { get { return new cariHesaplarAcikYetkiliTur().GetObject(TUR); } }
        public string ISIM { get; set; }
        public string SOYISIM { get; set; }
        public string TELEFON { get; set; }
        public string CEP { get; set; }
        public string EPOSTA { get; set; }
        public string UNVAN { get; set; }
        public string ACIKLAMA { get; set; }
        public cariHesaplarAcikYetkili() { }
        public cariHesaplarAcikYetkili(int KOD)
        {
            this.KOD = KOD;
        }
        public cariHesaplarAcikYetkili GetObject()
        {
            cariHesaplarAcikYetkili donendeger = new cariHesaplarAcikYetkili();

            Dictionary<int, object> dic = GetObject("SELECT [KOD],[SMREF],[TIP],[TARIH],[PASIF],[TUR],[ISIM],[SOYISIM],[TELEFON],[CEP],[EPOSTA],[UNVAN],[ACIKLAMA] FROM [Web-Musteri-Acik-Yetkili] WHERE KOD = @KOD", new Dictionary<string, object>() { { "KOD", KOD } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplarAcikYetkili() { KOD = ConvertToInt32(dic[0]), SMREF = ConvertToInt32(dic[1]), TIP = ConvertToInt32(dic[2]), TARIH = ConvertToDateTime(dic[3]), PASIF = Convert.ToBoolean(dic[4]), TUR = ConvertToInt32(dic[5]), ISIM = dic[6].ToString(), SOYISIM = dic[7].ToString(), TELEFON = dic[8].ToString(), CEP = dic[9].ToString(), EPOSTA = dic[10].ToString(), UNVAN = dic[11].ToString(), ACIKLAMA = dic[12].ToString() };

            return donendeger;
        }
        public List<cariHesaplarAcikYetkili> GetObjects(int SMREF, int TIP)
        {
            List<cariHesaplarAcikYetkili> donendeger = new List<cariHesaplarAcikYetkili>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("SELECT [KOD],[SMREF],[TIP],[TARIH],[PASIF],[TUR],[ISIM],[SOYISIM],[TELEFON],[CEP],[EPOSTA],[UNVAN],[ACIKLAMA] FROM [Web-Musteri-Acik-Yetkili] WHERE SMREF = @SMREF AND TIP = @TIP", new Dictionary<string, object>() { { "SMREF", SMREF }, { "TIP", TIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new cariHesaplarAcikYetkili { KOD = ConvertToInt32(dic[i][0]), SMREF = ConvertToInt32(dic[i][1]), TIP = ConvertToInt32(dic[i][2]), TARIH = ConvertToDateTime(dic[i][3]), PASIF = Convert.ToBoolean(dic[i][4]), TUR = ConvertToInt32(dic[i][5]), ISIM = dic[i][6].ToString(), SOYISIM = dic[i][7].ToString(), TELEFON = dic[i][8].ToString(), CEP = dic[i][9].ToString(), EPOSTA = dic[i][10].ToString(), UNVAN = dic[i][11].ToString(), ACIKLAMA = dic[i][12].ToString() });

            return donendeger;
        }
    }
    public class cariHesaplarAcikGunTur : DbObj
    {
        public int KOD { get; set; }
        public string ACIKLAMA { get; set; }
        public cariHesaplarAcikGunTur GetObject(int KOD)
        {
            cariHesaplarAcikGunTur donendeger = new cariHesaplarAcikGunTur();

            Dictionary<int, object> dic = GetObject("SELECT [KOD],[ACIKLAMA] FROM [Web-Musteri-Acik-Gun-Tur] WHERE KOD = @KOD", new Dictionary<string, object>() { { "KOD", KOD } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplarAcikGunTur() { KOD = ConvertToInt32(dic[0]), ACIKLAMA = dic[1].ToString() };

            return donendeger;
        }
    }
    public class cariHesaplarAcikYetkiliTur : DbObj
    {
        public int KOD { get; set; }
        public string ACIKLAMA { get; set; }
        public cariHesaplarAcikYetkiliTur GetObject(int KOD)
        {
            cariHesaplarAcikYetkiliTur donendeger = new cariHesaplarAcikYetkiliTur();

            Dictionary<int, object> dic = GetObject("SELECT [KOD],[ACIKLAMA] FROM [Web-Musteri-Acik-Yetkili-Tur] WHERE KOD = @KOD", new Dictionary<string, object>() { { "KOD", KOD } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplarAcikYetkiliTur() { KOD = ConvertToInt32(dic[0]), ACIKLAMA = dic[1].ToString() };

            return donendeger;
        }
    }
    public class cariHesaplarAcikKaynak : DbObj
    {
        public int KOD { get; set; }
        public string ACIKLAMA { get; set; }
        public cariHesaplarAcikKaynak GetObject(int KOD)
        {
            cariHesaplarAcikKaynak donendeger = new cariHesaplarAcikKaynak();

            Dictionary<int, object> dic = GetObject("SELECT [KOD],[ACIKLAMA] FROM [Web-Musteri-Acik-Kaynak] WHERE KOD = @KOD", new Dictionary<string, object>() { { "KOD", KOD } }, timeout);
            if (dic != null)
                donendeger = new cariHesaplarAcikKaynak() { KOD = ConvertToInt32(dic[0]), ACIKLAMA = dic[1].ToString() };

            return donendeger;
        }
    }
}
