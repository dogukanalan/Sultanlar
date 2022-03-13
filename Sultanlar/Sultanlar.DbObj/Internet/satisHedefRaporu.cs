using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class satisHedefRaporu : DbObj
    {
        public int YIL { get; set; }
        public int AY { get; set; }
        public int SLSREF { get; set; }
        public satisTemsilcileri Satici { get { satisTemsilcileri sat = new satisTemsilcileri(SLSREF).GetObject(); if (satici) return sat; else { satisTemsilcileri sa = new satisTemsilcileri(); sa.SATTEM = sat.SATTEM; return sa; } } }
        public int PRIMB { get; set; }
        public primGruplari PRIMGR { get { return new primGruplari(PRIMB).GetObject(); } }
        public double HEDEF { get; set; }
        public double SATIS { get; set; }
        public double BEKLEYEN { get; set; }

        public double SATISBEKLEYEN { get { return SATIS + BEKLEYEN; } }
        public double SATISYUZDE { get { return HEDEF != 0 ? SATIS / HEDEF * 100 : 0; } }
        public double SATISBEKLEYENYUZDE { get { return HEDEF != 0 ? SATISBEKLEYEN / HEDEF * 100 : 0; } }

        private bool satici { get; set; }

        public satisHedefRaporu() { }
        private satisHedefRaporu(int YIL, int AY, int SLSREF, int PRIMB, double HEDEF, double SATIS, double BEKLEYEN, bool satici)
        {
            this.YIL = YIL;
            this.AY = AY;
            this.SLSREF = SLSREF;
            this.PRIMB = PRIMB;
            this.HEDEF = HEDEF;
            this.SATIS = SATIS;
            this.BEKLEYEN = BEKLEYEN;
            this.satici = satici;
        }

        public override string ToString() { return SATISBEKLEYENYUZDE.ToString("N2"); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisHedefRaporu> GetObjects(int YIL, int AY, int SLSREF)
        {
            List<satisHedefRaporu> donendeger = new List<satisHedefRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_satisHedefRaporGetir", new Dictionary<string, object>() { { "YIL", YIL }, { "AY", AY }, { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisHedefRaporu(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisHedefRaporu> GetSatisForDashboard(int YIL, int SLSREF)
        {
            List<satisHedefRaporu> donendeger = new List<satisHedefRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_dashboardYillikSatis", new Dictionary<string, object>() { { "YIL", YIL }, { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisHedefRaporu(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), false));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisHedefRaporu> GetHedefForDashboard(int YIL, int SLSREF)
        {
            List<satisHedefRaporu> donendeger = new List<satisHedefRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_dashboardYillikHedef", new Dictionary<string, object>() { { "YIL", YIL }, { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisHedefRaporu(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToDouble(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), false));

            return donendeger;
        }
    }
}
