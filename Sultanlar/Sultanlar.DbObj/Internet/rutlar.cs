using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class rutlar : DbObj
    {
        public int gmref { get; set; }
        public int smref { get; set; }
        public int tip { get; set; }
        public cariHesaplar cari { get { return new cariHesaplar().GetObject1(tip, smref); } }
        public DateTime tarih { get; set; }
        public string gun { get; set; }

        public rutlar() { }
        public rutlar(int gmref, int smref, int tip, DateTime tarih, string gun)
        {
            this.gmref = gmref;
            this.smref = smref;
            this.tip = tip;
            this.tarih = tarih;
            this.gun = gun;
        }

        public List<rutlar> GetObjects(int SLSREF)
        {
            List<rutlar> donendeger = new List<rutlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_rutlarGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new rutlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), dic[i][4].ToString()));

            return donendeger;
        }
    }
}
