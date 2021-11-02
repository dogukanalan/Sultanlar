using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class borcAlacakRaporu : DbObj
    {
        public int GMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(GMREF).GetObject(); } }
        public double BORC { get; set; }
        public double ALACAK { get; set; }
        public double BAKIYE { get; set; }
        public DateTime ORTVADE { get; set; }
        public double VGB { get; set; }
        public int VGBVADE { get; set; }
        public double RISKTOP { get; set; }
        public double RISKLMT { get; set; }

        public borcAlacakRaporu() { }
        private borcAlacakRaporu(int GMREF, double BORC, double ALACAK, double BAKIYE, DateTime ORTVADE, double VGB, int VGBVADE, double RISKTOP, double RISKLMT)
        {
            this.GMREF = GMREF;
            this.BORC = BORC;
            this.ALACAK = ALACAK;
            this.BAKIYE = BAKIYE;
            this.ORTVADE = ORTVADE;
            this.VGB = VGB;
            this.VGBVADE = VGBVADE;
            this.GMREF = GMREF;
            this.RISKTOP = RISKTOP;
            this.RISKLMT = RISKLMT;
        }

        public override string ToString() { return BAKIYE.ToString("N2"); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<borcAlacakRaporu> GetObjects(int SLSREF)
        {
            List<borcAlacakRaporu> donendeger = new List<borcAlacakRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_borcAlacakRaporGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new borcAlacakRaporu(ConvertToInt32(dic[i][0]), ConvertToDouble(dic[i][1]), ConvertToDouble(dic[i][2]), ConvertToDouble(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8])));

            return donendeger;
        }
        public List<borcAlacakRaporu> GetObject(int SMREF)
        {
            List<borcAlacakRaporu> donendeger = new List<borcAlacakRaporu>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_borcAlacakGetir", new Dictionary<string, object>() { { "SMREF", SMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new borcAlacakRaporu(ConvertToInt32(dic[i][0]), ConvertToDouble(dic[i][1]), ConvertToDouble(dic[i][2]), ConvertToDouble(dic[i][3]), ConvertToDateTime(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToInt32(dic[i][6]), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8])));

            return donendeger;
        }
    }
}
