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
        public bool yapildi { get; set; }

        public rutlar() { }
        public rutlar(int gmref, int smref, int tip, DateTime tarih, string gun, bool yapildi)
        {
            this.gmref = gmref;
            this.smref = smref;
            this.tip = tip;
            this.tarih = tarih;
            this.gun = gun;
            this.yapildi = yapildi;
        }

        public List<rutlar> GetObjects(int SLSREF)
        {
            List<rutlar> donendeger = new List<rutlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_rutlarGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new rutlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), dic[i][4].ToString(), Convert.ToBoolean(dic[i][5])));

            return donendeger;
        }

        public List<rutlar> GetObjectsBugun(int SLSREF)
        {
            List<rutlar> donendeger = new List<rutlar>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_rutlarGetirBugun", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new rutlar(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToDateTime(dic[i][3]), dic[i][4].ToString(), Convert.ToBoolean(dic[i][5])));

            return donendeger;
        }

        public DtAjaxResponse GetObjects(int SLSREF, int Sira, int Rutlu, int Kactane, int Baslangic, Dictionary<string, string> arama)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();

            List<cariHesaplar> donendeger2 = new List<cariHesaplar>();
            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_rutMusterilerGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger2.Add(new cariHesaplar(ConvertToInt16(dic[i][0]), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), ConvertToInt32(dic[i][9]), dic[i][10].ToString(), dic[i][11].ToString(), dic[i][12].ToString(), ConvertToInt32(dic[i][13]), dic[i][14].ToString(), dic[i][15].ToString(), dic[i][16].ToString(), ConvertToInt32(dic[i][17]), dic[i][18].ToString(), dic[i][19].ToString(), ConvertToInt32(dic[i][20]), dic[i][21].ToString(), dic[i][22].ToString(), dic[i][23].ToString(), dic[i][24].ToString(), dic[i][25].ToString(), dic[i][26].ToString(), dic[i][27].ToString(), dic[i][28].ToString(), dic[i][29].ToString(), dic[i][30].ToString(), dic[i][31].ToString(), dic[i][32].ToString(), ConvertToDouble(dic[i][33])));

            donendeger.recordsTotal = donendeger2.Count;
            for (int i = 0; i < arama.Count; i++)
            {
                if (arama.ToArray()[i].Key == "musteri")
                    donendeger2 = donendeger2.ToList().Where(k => k.MUSTERI.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "sube")
                    donendeger2 = donendeger2.ToList().Where(k => k.SUBE.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "tip")
                    donendeger2 = donendeger2.ToList().Where(k => k.TIP == Convert.ToInt32(arama.ToArray()[i].Value)).ToList();
            }

            //donendeger2 = donendeger2.ToList().Where(k => Convert.ToInt32(k.EKP) == Sira).ToList(); // Sira

            if (Rutlu == 2) // sadece rutlular
            {
                donendeger2 = donendeger2.ToList().Where(k => Convert.ToInt32(k.GRP) > 0).ToList();
            }
            else if (Rutlu == 3) // sadece rutsuzlar
            {
                donendeger2 = donendeger2.ToList().Where(k => k.GRP == "0").ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;
            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
                donendeger.json.Add(donendeger2[i]);

            return donendeger;
        }
    }
}
