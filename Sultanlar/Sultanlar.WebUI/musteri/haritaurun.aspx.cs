using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.musteri
{
    public partial class haritaurun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Klas> UrunGetir(string marka)
        {
            List<Klas> donendeger = new List<Klas>();

            string filitre = marka == string.Empty ? "(HYRS_TANIM = 'ERNET' OR HYRS_TANIM = 'KENTON' OR HYRS_TANIM = 'CAMSİL' OR HYRS_TANIM = 'PİKNİK' OR HYRS_TANIM = 'ARI' OR HYRS_TANIM = 'SALOON' OR HYRS_TANIM = 'BÜNSA' OR HYRS_TANIM = 'ALTIN') AND " : "HYRS_TANIM = '" + marka + "' AND ";
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT * FROM [Web-Malzeme-Full] WHERE " + filitre + "[MAL ACIK] NOT LIKE '%&&%'");
            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Klas(dt.Rows[i]["MAL ACIK"].ToString(), Convert.ToInt32(dt.Rows[i]["ITEMREF"])));

            return donendeger;
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Klas> IlGetir()
        {
            List<Klas> donendeger = new List<Klas>();

            DataTable dt = new DataTable();
            Iller.GetObject(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Klas(dt.Rows[i]["strIl"].ToString(), Convert.ToInt32(dt.Rows[i]["strIlKod"])));

            return donendeger;
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Klas> IlceGetir(string ilkod)
        {
            List<Klas> donendeger = new List<Klas>();

            DataTable dt = new DataTable();
            Ilceler.GetObject(dt, ilkod);
            donendeger.Add(new Klas("Tümü", 0));
            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Klas(dt.Rows[i]["strIlce"].ToString(), Convert.ToInt32(dt.Rows[i]["pkIlceID"])));

            return donendeger;
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Musteri> MusteriGetir(string ilkod, string ilcekod, string urunid)
        {
            List<Musteri> donendeger = new List<Musteri>();

            string ILCEKOD = ilcekod == "Tümü" ? "" : " AND [ILCE] = '" + ilcekod + "'";
            DateTime dat = DateTime.Now.AddMonths(-3);

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT DISTINCT MUS.MUSTERI,MUS.SUBE,MUS.KONUM,MUS.KONUM_ADRES FROM [Web-Satis-Rapor-1] INNER JOIN (SELECT DISTINCT [Web-Musteri].SMREF,MUSTERI,SUBE,KONUM,KONUM_ADRES + (CASE [TEL-1] WHEN '' THEN '' ELSE ' (Tel: ' + [TEL-1] + ')' END) AS KONUM_ADRES,[IL KOD] FROM [Web-Musteri] LEFT OUTER JOIN [Web-Musteri-Acik] ON [Web-Musteri].SMREF = [Web-Musteri-Acik].SMREF AND [Web-Musteri-Acik].TIP = 1 WHERE [MT KOD] != 'A0' AND [MT KOD] != 'B1' AND [MT KOD] != 'Z1') AS MUS ON [Web-Satis-Rapor-1].SMREF = MUS.SMREF" + 
                " WHERE YIL = " + dat.Year.ToString() + " AND AY >= " + dat.Month.ToString() + 
                " AND ITEMREF = " + urunid + " AND [IL KOD] = " + ilkod + ILCEKOD);
            WebGenel.Sorgu(dt, "SELECT DISTINCT MUS.MUSTERI,MUS.SUBE,MUS.KONUM,MUS.KONUM_ADRES FROM [Web-Satis-Rapor-TP] INNER JOIN (SELECT DISTINCT [Web-Musteri-TP].SMREF,MUSTERI,SUBE,KONUM,KONUM_ADRES,[IL KOD] FROM [Web-Musteri-TP] LEFT OUTER JOIN [Web-Musteri-Acik] ON [Web-Musteri-TP].SMREF = [Web-Musteri-Acik].SMREF AND [Web-Musteri-Acik].TIP = 4) AS MUS ON [Web-Satis-Rapor-TP].NOKTAREF = MUS.SMREF " +
                " WHERE NOKTASATYIL = " + dat.Year.ToString() + " AND NOKTASATAY >= " + dat.Month.ToString() +
                " AND URUNKOD = " + urunid + " AND [IL KOD] = " + ilkod);
            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Musteri(dt.Rows[i]["MUSTERI"].ToString(), dt.Rows[i]["SUBE"].ToString(), dt.Rows[i]["KONUM"].ToString(), dt.Rows[i]["KONUM_ADRES"].ToString()));

            return donendeger;
        }
    }

    public class Klas
    {
        public string aciklama { get; set; }
        public int id { get; set; }
        public Klas(string aciklama, int id)
        {
            this.id = id;
            this.aciklama = aciklama;
        }
    }

    public class Musteri
    {
        public string MUSTERI { get; set; }
        public string SUBE { get; set; }
        public string KONUM { get; set; }
        public string KONUM_ADRES { get; set; }
        public Musteri(string MUSTERI, string SUBE, string KONUM, string KONUM_ADRES)
        {
            this.MUSTERI = MUSTERI;
            this.SUBE = SUBE;
            this.KONUM = KONUM;
            this.KONUM_ADRES = KONUM_ADRES;
        }
    }
}