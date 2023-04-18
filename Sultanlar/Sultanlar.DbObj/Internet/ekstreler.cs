using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class ekstreler : DbObj
    {
        public string TUR { get; set; }
        public string FISTUR { get; set; }
        public DateTime FISTAR { get; set; }
        public string FISNO { get; set; }
        public string MATBUNO { get; set; }
        public DateTime FISVADE { get; set; }
        public string FISACIKLAMA { get; set; }
        public double BORC { get; set; }
        public double ALACAK { get; set; }
        public double BAKIYE { get; set; }

        public ekstreler() { }
        public ekstreler(string FISNO) { this.FISNO = FISNO; }
        private ekstreler(string TUR, string FISTUR, DateTime FISTAR, string FISNO, string MATBUNO, DateTime FISVADE, string FISACIKLAMA, double BORC, double ALACAK, double BAKIYE)
        {
            this.TUR = TUR;
            this.FISTUR = FISTUR;
            this.FISTAR = FISTAR;
            this.FISNO = FISNO;
            this.MATBUNO = MATBUNO;
            this.FISVADE = FISVADE;
            this.FISACIKLAMA = FISACIKLAMA;
            this.BORC = BORC;
            this.ALACAK = ALACAK;
            this.BAKIYE = BAKIYE;
        }

        public override string ToString() { return FISACIKLAMA; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ekstreler GetObject()
        {
            ekstreler donendeger = new ekstreler();

            Dictionary<int, object> dic = GetObject("db_sp_ekstreGetir", new Dictionary<string, object>() { { "FISNO", FISNO } }, timeout);
            if (dic != null)
                donendeger = new ekstreler(dic[0].ToString(), dic[1].ToString(), ConvertToDateTime(dic[2]), dic[3].ToString(), dic[4].ToString(), ConvertToDateTime(dic[5]), dic[6].ToString(), ConvertToDouble(dic[7]), ConvertToDouble(dic[8]), ConvertToDouble(dic[9]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ekstreler> GetObjects(int GMREF, int YIL, object AY)
        {
            List<ekstreler> donendeger = new List<ekstreler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_ekstrelerGetir", new Dictionary<string, object>() { { "GMREF", GMREF }, { "YIL", YIL }, { "AY", AY } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new ekstreler(dic[i][0].ToString(), dic[i][1].ToString(), ConvertToDateTime(dic[i][2]), dic[i][3].ToString(), dic[i][4].ToString(), ConvertToDateTime(dic[i][5]), dic[i][6].ToString(), ConvertToDouble(dic[i][7]), ConvertToDouble(dic[i][8]), ConvertToDouble(dic[i][9])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ekstreler GetObjectsDipTop(int GMREF)
        {
            ekstreler donendeger = new ekstreler();

            Dictionary<int, object> dic = GetObject("db_sp_ekstrelerGetirDipTop", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                donendeger = new ekstreler(dic[0].ToString(), dic[1].ToString(), ConvertToDateTime(dic[2]), dic[3].ToString(), dic[4].ToString(), ConvertToDateTime(dic[5]), dic[6].ToString(), ConvertToDouble(dic[7]), ConvertToDouble(dic[8]), ConvertToDouble(dic[9]));

            return donendeger;
        }
    }
}
