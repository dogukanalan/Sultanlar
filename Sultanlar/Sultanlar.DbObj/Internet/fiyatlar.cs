using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class fiyatlar : DbObj
    {
        public int TIP;
        public int GMREF;
        public string GRUPKOD;
        public string OZELKOD;
        public string HK;
        public string OZELACIK;
        public string REYKOD;
        public string RK;
        public string REYACIK;
        public int ITEMREF;
        public string MALACIK;
        public malzemeler malzeme { get { return new malzemeler().GetObject(ITEMREF, STOKYER); } }
        public double FIYAT;
        public double ISK1;
        public double ISK2;
        public double ISK3;
        public double ISK4;
        public double ISK5;
        public double ISK6;
        public double ISK7;
        public double ISK8;
        public double ISK9;
        public double ISK10;
        public double NET;
        public double NETKDV;
        public int VADE;
        public Guid KAMKARTREF;
        public double ODEME_GUN;
        public DateTime ODEME_TARIH;

        public int STOKYER;
        public int MTIP;
        public int NETFIYATSMREF;
        public fiyatisks NETFIYAT
        {
            get
            {
                return new fiyatisks();
                if (TIP != 2 || NETFIYATSMREF == 0 || MTIP == 0 || STOKYER == 0)
                    return new fiyatisks();

                double fiyat = new fiyatlar(20, ITEMREF).GetObject().FIYAT;
                fiyatisks donendeger = new fiyatisks() { fiyat = fiyat, isk1 = 0, isk2 = 0, isk3 = 0, isk4 = 0 };
                DateTime Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                malzemeler mal = new malzemeler(ITEMREF).GetObject();
                cariHesaplar ch = new cariHesaplar().GetObject1(MTIP, NETFIYATSMREF);

                aktivitelerDetay aktd = MTIP == 1 ? new aktivitelerDetay().GetObjectSon(NETFIYATSMREF, ITEMREF, Tarih) : new aktivitelerDetay().GetObjectSonTP(NETFIYATSMREF, ITEMREF, Tarih);

                if (aktd.pkID > 0) // aktivite
                {
                    donendeger = new fiyatisks() { fiyat = aktd.mnBirimFiyatKDVli / ((100 + mal.KDV) / 100), isk1 = Convert.ToDouble(aktd.strAciklama1), isk2 = Convert.ToDouble(aktd.strAciklama2), isk3 = Convert.ToDouble(aktd.strAciklama3), isk4 = aktd.flEkIsk };
                }
                else
                {
                    anlasmalar anl = new anlasmalar().GetObjectSon(NETFIYATSMREF, MTIP == 1 ? "2" : "1", Tarih);
                    if (anl.pkID > 0) // anlaşma
                    {
                        donendeger = new fiyatisks()
                        {
                            fiyat = fiyat,
                            isk1 = (mal.GRUPKOD == "STG-1" ? anl.flTAHIsk : anl.flYEGIsk),
                            isk2 = (mal.GRUPKOD == "STG-1" ? anl.flTAHCiroIsk : anl.flYEGCiroIsk),
                            isk3 = 0,
                            isk4 = 0
                        };
                    }
                    else
                    {
                        if (MTIP != 1)
                        {
                            aktivitelerDetay aktdG = new aktivitelerDetay().GetObjectSonTP(STOKYER, ITEMREF, Tarih);
                            if (aktdG.pkID > 0) // genel anlaşmasız
                            {
                                donendeger.isk4 = aktdG.flEkIsk;
                            }
                            else // otoaktivite
                            {
                                int tur = ch.MTKOD == "B1" ? 2 : 1;
                                DataTable dtS = getCustomData("SELECT TOP 1 ISK1 FROM [Web-Fiyat-TP-Donem] WHERE TUR = @TUR AND ITEMREF = @ITEMREF AND BASLANGIC <= @FATURA AND BITIS >= @FATURA ORDER BY BASLANGIC DESC",
                                                new ArrayList() { "TUR", "ITEMREF", "FATURA" }, new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.DateTime }, new ArrayList() { tur, ITEMREF, Tarih }, "");

                                donendeger.isk4 = dtS.Rows.Count > 0 ? Convert.ToDouble(dtS.Rows[0][0]) : 0;
                            }
                        }
                    }
                }

                return donendeger;
            }
        }
        public fiyatvy fiyatvy { get { return new fiyatvy(ITEMREF); } }

        public fiyatlar() { }
        public fiyatlar(int TIP, int ITEMREF) { this.TIP = TIP; this.ITEMREF = ITEMREF; }
        public fiyatlar(int TIP, int GMREF, string GRUPKOD, string OZELKOD, string HK, string OZELACIK, string REYKOD, string RK, string REYACIK, int ITEMREF, string MALACIK, double FIYAT, double ISK1, double ISK2, double ISK3, double ISK4, double ISK5, double ISK6, double ISK7, double ISK8, double ISK9, double ISK10, double NET, double NETKDV, int VADE, Guid KAMKARTREF, double ODEME_GUN, DateTime ODEME_TARIH, int STOKYER, int MTIP, int NETFIYATSMREF)
        {
            this.TIP = TIP;
            this.GMREF = GMREF;
            this.GRUPKOD = GRUPKOD;
            this.OZELKOD = OZELKOD;
            this.HK = HK;
            this.OZELACIK = OZELACIK;
            this.REYKOD = REYKOD;
            this.RK = RK;
            this.REYACIK = REYACIK;
            this.ITEMREF = ITEMREF;
            this.MALACIK = MALACIK;
            this.FIYAT = FIYAT;
            this.ISK1 = ISK1;
            this.ISK2 = ISK2;
            this.ISK3 = ISK3;
            this.ISK4 = ISK4;
            this.ISK5 = ISK5;
            this.ISK6 = ISK6;
            this.ISK7 = ISK7;
            this.ISK8 = ISK8;
            this.ISK9 = ISK9;
            this.ISK10 = ISK10;
            this.NET = NET;
            this.NETKDV = NETKDV;
            this.VADE = VADE;
            this.KAMKARTREF = KAMKARTREF;
            this.ODEME_GUN = ODEME_GUN;
            this.ODEME_TARIH = ODEME_TARIH;
            this.STOKYER = MTIP > 1 ? STOKYER : 0;
            this.MTIP = MTIP;
            this.NETFIYATSMREF = NETFIYATSMREF;
        }

        public override string ToString() { return MALACIK; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public fiyatlar GetObject()
        {
            fiyatlar donendeger = new fiyatlar();

            Dictionary<int, object> dic = GetObject("db_sp_fiyatGetir", new Dictionary<string, object>() { { "TIP", TIP }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                donendeger = new fiyatlar(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), ConvertToInt32(dic[9]), dic[10].ToString(), ConvertToDouble(dic[11]), ConvertToDouble(dic[12]), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), ConvertToDouble(dic[21]), ConvertToDouble(dic[22]), ConvertToDouble(dic[23]), ConvertToInt32(dic[24]), ConvertToGuid(dic[25].ToString()), ConvertToDouble(dic[26]), ConvertToDateTime(dic[27]), 0, 0, 0);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjects()
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), 0, 0, 0));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjects(int TIP, int GMREF, int MTIP, int SMREF)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarGetirByTip", new Dictionary<string, object>() { { "TIP", TIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), GMREF, MTIP, SMREF));

            return donendeger;
        }
        /// <summary>
        /// Web-Malzeme-2
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjectsHaric()
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarHaricGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), 0, 0, 0));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjectsByGmrefMtip(int TIP, int GMREF, int MTIP, int SMREF)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarGetirByTipGmrefMtip", new Dictionary<string, object>() { { "TIP", TIP }, { "GMREF", GMREF }, { "MTIP", MTIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), GMREF, MTIP, SMREF));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjectsAll(int TIP, int GMREF, int MTIP, int SMREF)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarGetirAllByTip", new Dictionary<string, object>() { { "TIP", TIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), GMREF, MTIP, SMREF));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetVade(int TIP)
        {
            int donendeger = 0;

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_VadeGetir", new Dictionary<string, object>() { { "TIP", TIP } }, timeout);
            if (dic != null)
                donendeger = ConvertToInt32(dic[0]);

            return donendeger;
        }
        /// <summary>
        /// MTIP olandan sonra kullanmıyoruz
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjectsVY(int GMREF)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarVyGetirByGMREF", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), 0, 0, 0));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjectsVY(int GMREF, int MTIP)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarVyGetirByGMREFMTIP", new Dictionary<string, object>() { { "GMREF", GMREF }, { "MTIP", MTIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), 0, 0, 0));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjectsSmrefad(int SMREF)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarVyGetirBySmrefad", new Dictionary<string, object>() { { "SMREF", SMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27]), 0, 0, 0));

            return donendeger;
        }
    }

    public class fiyatisks
    {
        public double fiyat { get; set; }
        public double isk1 { get; set; }
        public double isk2 { get; set; }
        public double isk3 { get; set; }
        public double isk4 { get; set; }
    }

    public class fiyatvy
    {
        public int ITEMREF { get; set; }
        public bool Isaret { get; set; }
        public bool Varyok { get; set; }
        public bool Depo { get; set; }
        public bool Raf { get; set; }
        public double Raffiyat { get; set; }
        public bool Skt { get; set; }
        public int Siparis { get; set; }
        public fiyatvy(int ITEMREF) { this.ITEMREF = ITEMREF; }
    }
}
