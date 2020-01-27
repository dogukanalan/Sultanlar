using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class malzemeler : DbObj
    {
        public int AP { get; set; }
        public int ITEMREF { get; set; }
        public string MALKOD { get; set; }
        public string MALACIK { get; set; }
        public string URTKOD { get; set; }
        public string ESKOD { get; set; }
        public string BIRIMREF { get; set; }
        public string BIRIM { get; set; }
        public string GRUPKOD { get; set; }
        public string GRUPACIK { get; set; }
        public string OZELKOD { get; set; }
        public string HK { get; set; }
        public string OZELACIK { get; set; }
        public string REYKOD { get; set; }
        public string RK { get; set; }
        public string REYACIK { get; set; }
        public double KDV { get; set; }
        public double KOLI { get; set; }
        public string BARKOD { get; set; }
        public double STOK { get; set; }
        public int KYTM { get; set; }
        public int KANAL { get; set; }
        public int PRIMT { get; set; }
        public int PRIMB { get; set; }
        public string HYRS { get; set; }
        public string HYRS_TANIM { get; set; }
        public int DONUSUM { get; set; }
        public int MHDHB { get; set; }
        public int MHDRZ { get; set; }

        public malzemeler() { }
        public malzemeler(int ITEMREF) { this.ITEMREF = ITEMREF; }
        public malzemeler(int AP, int ITEMREF, string MALKOD, string MALACIK, string URTKOD, string ESKOD, string BIRIMREF, string BIRIM, string GRUPKOD, string GRUPACIK, string OZELKOD, string HK, string OZELACIK, string REYKOD, string RK, string REYACIK, double KDV, double KOLI, string BARKOD, double STOK, int KYTM, int KANAL, int PRIMT, int PRIMB, string HYRS, string HYRS_TANIM, int DONUSUM, int MHDHB, int MHDRZ)
        {
            this.AP = AP;
            this.ITEMREF = ITEMREF;
            this.MALKOD = MALKOD;
            this.MALACIK = MALACIK;
            this.URTKOD = URTKOD;
            this.ESKOD = ESKOD;
            this.BIRIMREF = BIRIMREF;
            this.BIRIM = BIRIM;
            this.GRUPKOD = GRUPKOD;
            this.GRUPACIK = GRUPACIK;
            this.OZELKOD = OZELKOD;
            this.HK = HK;
            this.OZELACIK = OZELACIK;
            this.REYKOD = REYKOD;
            this.RK = RK;
            this.REYACIK = REYACIK;
            this.KDV = KDV;
            this.KOLI = KOLI;
            this.BARKOD = BARKOD;
            this.STOK = STOK;
            this.KYTM = KYTM;
            this.KANAL = KANAL;
            this.PRIMT = PRIMT;
            this.PRIMB = PRIMB;
            this.HYRS = HYRS;
            this.HYRS_TANIM = HYRS_TANIM;
            this.DONUSUM = DONUSUM;
            this.MHDHB = MHDHB;
            this.MHDRZ = MHDRZ;
        }

        public override string ToString() { return MALACIK; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public malzemeler GetObject()
        {
            malzemeler donendeger = new malzemeler();

            Dictionary<int, object> dic = GetObject("db_sp_malzemeGetir", new Dictionary<string, object>() { { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                donendeger = new malzemeler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), dic[9].ToString(), dic[10].ToString(), dic[11].ToString(), dic[12].ToString(), dic[13].ToString(), dic[14].ToString(), dic[15].ToString(), ConvertToDouble(dic[16]), ConvertToDouble(dic[17]), dic[18].ToString(), ConvertToDouble(dic[19]), ConvertToInt32(dic[20]), ConvertToInt32(dic[21]), ConvertToInt32(dic[22]), ConvertToInt32(dic[23]), dic[24].ToString(), dic[25].ToString(), ConvertToInt32(dic[26]), ConvertToInt32(dic[27]), ConvertToInt32(dic[28]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<malzemeler> GetObjects()
        {
            List<malzemeler> donendeger = new List<malzemeler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_malzemelerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new malzemeler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), dic[i][13].ToString(), dic[i][14].ToString(), dic[i][15].ToString(), ConvertToDouble(dic[i][16]), ConvertToDouble(dic[i][17]), dic[i][18].ToString(), ConvertToDouble(dic[i][19]), ConvertToInt32(dic[i][20]), ConvertToInt32(dic[i][21]), ConvertToInt32(dic[i][22]), ConvertToInt32(dic[i][23]), dic[i][24].ToString(), dic[i][25].ToString(), ConvertToInt32(dic[i][26]), ConvertToInt32(dic[i][27]), ConvertToInt32(dic[i][28])));

            return donendeger;
        }
    }
}
