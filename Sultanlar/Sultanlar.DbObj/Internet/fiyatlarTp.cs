using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class fiyatlarTp : DbObj
    {
        public int YIL;
        public int AY;
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
        public double KDV; // { get { return ((NETKDV / NET) - 1) * 100; } }
        public double FIYATKDVDAHIL { get { return FIYAT * ((100 + KDV) / 100); } }
        public malzemeler malzeme { get { return new malzemeler(ITEMREF).GetObject(); } }

        public fiyatlarTp() { }
        public fiyatlarTp(int YIL, int AY, int TIP, int ITEMREF) { this.YIL = YIL; this.AY = AY; this.TIP = TIP; this.ITEMREF = ITEMREF; }
        public fiyatlarTp(int YIL, int AY, int TIP, int GMREF, string GRUPKOD, string OZELKOD, string HK, string OZELACIK, string REYKOD, string RK, string REYACIK, int ITEMREF, string MALACIK, double FIYAT, double ISK1, double ISK2, double ISK3, double ISK4, double ISK5, double ISK6, double ISK7, double ISK8, double ISK9, double ISK10, double NET, double NETKDV, int VADE, Guid KAMKARTREF, double ODEME_GUN, DateTime ODEME_TARIH, double KDV)
        {
            this.YIL = YIL;
            this.AY = AY;
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
            this.KDV = KDV;
        }

        public override string ToString() { return MALACIK; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public fiyatlarTp GetObject()
        {
            fiyatlarTp donendeger = new fiyatlarTp();

            Dictionary<int, object> dic = GetObject("db_sp_tpFiyatGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "TIP", TIP }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                donendeger = new fiyatlarTp(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), dic[9].ToString(), dic[10].ToString(), ConvertToInt32(dic[11]), dic[12].ToString(), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), ConvertToDouble(dic[21]), ConvertToDouble(dic[22]), ConvertToDouble(dic[23]), ConvertToDouble(dic[24]), ConvertToDouble(dic[25]), ConvertToInt32(dic[26]), ConvertToGuid(dic[27].ToString()), ConvertToDouble(dic[28]), ConvertToDateTime(dic[29]), ConvertToDouble(dic[30]));

            return donendeger;
        }
        /// <summary>
        /// [Web-Fiyat-TP-3]
        /// </summary>
        /// <returns></returns>
        public fiyatlarTp GetObject(int YIL, int AY, int GUN, int TIP, int ITEMREF)
        {
            fiyatlarTp donendeger = new fiyatlarTp();

            Dictionary<int, object> dic = GetObject("db_sp_tpFiyat3Getir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "GUN", GUN }, { "TIP", TIP }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                donendeger = new fiyatlarTp(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), dic[9].ToString(), dic[10].ToString(), ConvertToInt32(dic[11]), dic[12].ToString(), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), ConvertToDouble(dic[21]), ConvertToDouble(dic[22]), ConvertToDouble(dic[23]), ConvertToDouble(dic[24]), ConvertToDouble(dic[25]), ConvertToInt32(dic[26]), ConvertToGuid(dic[27].ToString()), ConvertToDouble(dic[28]), ConvertToDateTime(dic[29]), ConvertToDouble(dic[30]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlarTp> GetObjects()
        {
            List<fiyatlarTp> donendeger = new List<fiyatlarTp>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_tpFiyatlarGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlarTp(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), ConvertToInt32(dic[i][11]), dic[i][12].ToString(), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), ConvertToDouble(dic[i][25]), ConvertToInt32(dic[i][26]), ConvertToGuid(dic[i][27].ToString()), ConvertToDouble(dic[i][28]), ConvertToDateTime(dic[i][29]), ConvertToDouble(dic[i][30])));

            return donendeger;
        }
        /// <summary>
        /// [Web-Fiyat-TP-3]
        /// </summary>
        /// <returns></returns>
        public List<fiyatlarTp> GetObjects(int YIL, int AY, int GUN, int TIP)
        {
            List<fiyatlarTp> donendeger = new List<fiyatlarTp>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_tpFiyatlarGetirByYilAyGunTip", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "GUN", GUN }, { "TIP", TIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlarTp(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), ConvertToInt32(dic[i][11]), dic[i][12].ToString(), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToDouble(dic[i][24]), ConvertToDouble(dic[i][25]), ConvertToInt32(dic[i][26]), ConvertToGuid(dic[i][27].ToString()), ConvertToDouble(dic[i][28]), ConvertToDateTime(dic[i][29]), ConvertToDouble(dic[i][30])));

            return donendeger;
        }
    }
}
