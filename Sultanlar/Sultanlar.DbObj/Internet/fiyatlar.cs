using System;
using System.Collections.Generic;
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
        public malzemeler malzeme { get { return new malzemeler(ITEMREF).GetObject(); } }
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
        public fiyatvy fiyatvy { get { return new fiyatvy(ITEMREF); } }

        public fiyatlar() { }
        public fiyatlar(int TIP, int ITEMREF) { this.TIP = TIP; this.ITEMREF = ITEMREF; }
        public fiyatlar(int TIP, int GMREF, string GRUPKOD, string OZELKOD, string HK, string OZELACIK, string REYKOD, string RK, string REYACIK, int ITEMREF, string MALACIK, double FIYAT, double ISK1, double ISK2, double ISK3, double ISK4, double ISK5, double ISK6, double ISK7, double ISK8, double ISK9, double ISK10, double NET, double NETKDV, int VADE, Guid KAMKARTREF, double ODEME_GUN, DateTime ODEME_TARIH)
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
                donendeger = new fiyatlar(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), ConvertToInt32(dic[9]), dic[10].ToString(), ConvertToDouble(dic[11]), ConvertToDouble(dic[12]), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), ConvertToDouble(dic[18]), ConvertToDouble(dic[19]), ConvertToDouble(dic[20]), ConvertToDouble(dic[21]), ConvertToDouble(dic[22]), ConvertToDouble(dic[23]), ConvertToInt32(dic[24]), ConvertToGuid(dic[25].ToString()), ConvertToDouble(dic[26]), ConvertToDateTime(dic[27]));

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
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<fiyatlar> GetObjects(int TIP)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_fiyatlarGetirByTip", new Dictionary<string, object>() { { "TIP", TIP } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new fiyatlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), ConvertToDouble(dic[i][18]), ConvertToDouble(dic[i][19]), ConvertToDouble(dic[i][20]), ConvertToDouble(dic[i][21]), ConvertToDouble(dic[i][22]), ConvertToDouble(dic[i][23]), ConvertToInt32(dic[i][24]), ConvertToGuid(dic[i][25].ToString()), ConvertToDouble(dic[i][26]), ConvertToDateTime(dic[i][27])));

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
