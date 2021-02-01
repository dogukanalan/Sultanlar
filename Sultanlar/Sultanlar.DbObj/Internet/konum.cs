using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class konumListe : DbObj
    {
        public string ap { get; set; }
        public string musteri { get; set; }
        public string kod { get; set; }
        public string sube { get; set; }
        public string tipkod { get; set; }
        public string tip { get; set; }
        public string sehir { get; set; }
        public string ilce { get; set; }
        public string konum { get; set; }
        public string adres { get; set; }
        public string rn { get; set; }

        public konumListe() { }
        public konumListe(string ap, string musteri, string kod, string sube, string tipkod, string tip, string sehir, string ilce, string konum, string adres, string rn)
        {
            this.ap = ap;
            this.musteri = musteri;
            this.kod = kod;
            this.sube = sube;
            this.tipkod = tipkod;
            this.tip = tip;
            this.sehir = sehir;
            this.ilce = ilce;
            this.konum = konum;
            this.adres = adres;
            this.rn = rn;
        }

        public List<konumListe> GetObjects(int SLSREF)
        {
            List<konumListe> donendeger = new List<konumListe>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_konumlarGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new konumListe(dic[i][0].ToString(), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), ""));

            return donendeger;
        }

        public DtAjaxResponse GetObjects(int SLSREF, int Kactane, int Baslangic, Dictionary<string, string> arama)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();

            List<konumListe> donendeger2 = new List<konumListe>();
            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_konumlarGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger2.Add(new konumListe(dic[i][0].ToString(), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), ""));

            donendeger.recordsTotal = donendeger2.Count;

            for (int i = 0; i < arama.Count; i++)
            {
                if (arama.ToArray()[i].Key == "musteri")
                    donendeger2 = donendeger2.ToList().Where(k => k.musteri.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "sube")
                    donendeger2 = donendeger2.ToList().Where(k => k.sube.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "tip")
                    donendeger2 = donendeger2.ToList().Where(k => k.tip.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "sehir")
                    donendeger2 = donendeger2.ToList().Where(k => k.sehir.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "ilce")
                    donendeger2 = donendeger2.ToList().Where(k => k.ilce.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
                else if (arama.ToArray()[i].Key == "adres")
                    donendeger2 = donendeger2.ToList().Where(k => k.adres.IndexOf(arama.ToArray()[i].Value) > -1).ToList();
            }

            donendeger.recordsFiltered = donendeger2.Count;

            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;
            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
                donendeger.json.Add(donendeger2[i]);
            
            return donendeger;
        }

        public konumListe GetObject(int SMREF)
        {
            konumListe donendeger = new konumListe();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_konumGetir", new Dictionary<string, object>() { { "SMREF", SMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger = new konumListe(dic[i][0].ToString(), dic[i][1].ToString(), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), dic[i][9].ToString(), "");

            return donendeger;
        }
    }
}
