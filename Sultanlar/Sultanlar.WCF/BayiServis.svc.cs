using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BayiServis" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BayiServis.svc or BayiServis.svc.cs at the Solution Explorer and start debugging.
    public class BayiServis : IBayiServis
    {
        public string Test()
        {
            return "Çalışıyor";
        }

        public XmlDocument Siparis(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            Class.SiparislerDis siparisler = SiparisGetir(Guid.Parse(apikey), bas, bit);

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(Class.SiparislerDis), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, siparisler, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public Class.SiparislerDis SiparisJ(string apikey, string baslangic, string bitis)
        {
            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            Class.SiparislerDis siparisler = SiparisGetir(Guid.Parse(apikey), bas, bit);

            return siparisler;
        }

        public XmlDocument Fatura(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            Class.FaturalarDis faturalar = FaturaGetir(Guid.Parse(apikey), bas, bit);

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(Class.FaturalarDis), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public Class.FaturalarDis FaturaJ(string apikey, string baslangic, string bitis)
        {
            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            Class.FaturalarDis faturalar = FaturaGetir(Guid.Parse(apikey), bas, bit);

            return faturalar;
        }

        private Class.SiparislerDis SiparisGetir(Guid apikey, DateTime baslangic, DateTime bitis)
        {
            Class.SiparislerDis siparisler = new Class.SiparislerDis();

            DataTable dt = BaslikVeriGetir(true, apikey, baslangic, bitis);

            siparisler.Siparisler = new List<Class.SiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Class.SiparisDis siparis = new Class.SiparisDis();

                siparis.sipno = dt.Rows[i]["sipno"].ToString();
                siparis.tur = dt.Rows[i]["tur"].ToString();
                siparis.belgeno = dt.Rows[i]["belgeno"].ToString();
                siparis.carino = dt.Rows[i]["carino"].ToString();
                siparis.carino2 = dt.Rows[i]["carino2"].ToString();
                siparis.cari = dt.Rows[i]["cari"].ToString();
                siparis.tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]).ToShortDateString() + " " + Convert.ToDateTime(dt.Rows[i]["tarih"]).ToShortTimeString();
                siparis.vade = dt.Rows[i]["vade"].ToString();
                siparis.aciklama = dt.Rows[i]["aciklama"].ToString();
                siparis.iptal = dt.Rows[i]["iptal"].ToString();

                DataTable dt1 = DetayVeriGetir(siparis.tur == "3", true, siparis.sipno);
                siparis.detaylar = new List<Class.SiparisDisDetay>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    Class.SiparisDisDetay detay = new Class.SiparisDisDetay();
                    detay.detayno = dt1.Rows[j]["detayno"].ToString();
                    detay.malzeme = new Class.MalzemeDetay();
                    detay.malzeme.malno = dt1.Rows[j]["malno"].ToString();
                    detay.malzeme.malacik = dt1.Rows[j]["malzeme"].ToString();
                    detay.malzeme.koli = dt1.Rows[j]["koli"].ToString();
                    detay.miktar = dt1.Rows[j]["miktar"].ToString();
                    detay.miktartur = dt1.Rows[j]["miktartur"].ToString();
                    detay.isk1 = dt1.Rows[j]["isk1"].ToString();
                    detay.isk2 = dt1.Rows[j]["isk2"].ToString();
                    detay.isk3 = dt1.Rows[j]["isk3"].ToString();
                    detay.isk4 = dt1.Rows[j]["isk4"].ToString();
                    detay.fiyat = dt1.Rows[j]["fiyat"].ToString();
                    siparis.detaylar.Add(detay);
                }

                siparisler.Siparisler.Add(siparis);
            }

            return siparisler;
        }

        private Class.FaturalarDis FaturaGetir(Guid apikey, DateTime baslangic, DateTime bitis)
        {
            Class.FaturalarDis faturalar = new Class.FaturalarDis();

            DataTable dt = BaslikVeriGetir(false, apikey, baslangic, bitis);

            faturalar.Faturalar = new List<Class.SiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Class.SiparisDis siparis = new Class.SiparisDis();

                siparis.sipno = dt.Rows[i]["sipno"].ToString();
                siparis.tur = dt.Rows[i]["tur"].ToString();
                siparis.belgeno = dt.Rows[i]["belgeno"].ToString();
                siparis.carino = dt.Rows[i]["carino"].ToString();
                siparis.carino2 = dt.Rows[i]["carino2"].ToString();
                siparis.cari = dt.Rows[i]["cari"].ToString();
                siparis.tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]).ToShortDateString() + " " + Convert.ToDateTime(dt.Rows[i]["tarih"]).ToShortTimeString();
                siparis.aciklama = dt.Rows[i]["aciklama"].ToString();
                siparis.vade = dt.Rows[i]["vade"].ToString();
                siparis.iptal = dt.Rows[i]["iptal"].ToString();

                DataTable dt1 = DetayVeriGetir(siparis.tur == "3", false, siparis.sipno);
                siparis.detaylar = new List<Class.SiparisDisDetay>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    Class.SiparisDisDetay detay = new Class.SiparisDisDetay();
                    detay.detayno = dt1.Rows[j]["detayno"].ToString();
                    detay.malzeme = new Class.MalzemeDetay();
                    detay.malzeme.malno = dt1.Rows[j]["malno"].ToString();
                    detay.malzeme.malacik = dt1.Rows[j]["malzeme"].ToString();
                    detay.malzeme.koli = dt1.Rows[j]["koli"].ToString();
                    detay.miktar = dt1.Rows[j]["miktar"].ToString();
                    detay.miktartur = dt1.Rows[j]["miktartur"].ToString();
                    detay.isk1 = dt1.Rows[j]["isk1"].ToString();
                    detay.isk2 = dt1.Rows[j]["isk2"].ToString();
                    detay.isk3 = dt1.Rows[j]["isk3"].ToString();
                    detay.isk4 = dt1.Rows[j]["isk4"].ToString();
                    detay.fiyat = dt1.Rows[j]["fiyat"].ToString();
                    siparis.detaylar.Add(detay);
                }

                faturalar.Faturalar.Add(siparis);
            }

            return faturalar;
        }

        private DataTable BaslikVeriGetir(bool siparis, Guid apikey, DateTime baslangic, DateTime bitis)
        {
            DataTable dt = WebGenel.WCFdata(@"SELECT DISTINCT pkSiparisID AS sipno,8 AS tur, QUANTUMNO AS belgeno, 
CASE WHEN TKSREF = 5 THEN [Web-Musteri-1].NETTOP ELSE [Web-Musteri-1].SMREF END AS carino, 
CASE WHEN TKSREF = 5 THEN (SELECT [MUS KOD] FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE [Web-Musteri-1].[MUS KOD] END AS carino2, 
CASE WHEN TKSREF = 5 THEN (SELECT MUSTERI FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE SUBE END AS cari, " + 
(siparis ? "dtOlusmaTarihi" : "FATTAR") + " AS tarih," +
(siparis ? "'False'" : "IPTAL") + " AS iptal," +
@"28 AS vade
,CASE WHEN TKSREF = 5 THEN 'Şube: ' + SUBE + ' (' + CONVERT(nvarchar(50),[Web-Musteri-1].SMREF) + ')' ELSE '' END AS aciklama
FROM tblINTERNET_Siparisler
INNER JOIN (SELECT TIP,GMREF,SMREF,[MUS KOD],SUBE,NETTOP FROM [Web-Musteri-1]) AS [Web-Musteri-1] ON tblINTERNET_Siparisler.SMREF = [Web-Musteri-1].SMREF AND tblINTERNET_Siparisler.TKSREF = [Web-Musteri-1].TIP
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = bintSiparisDetayID
INNER JOIN tblINTERNET_SiparislerQ ON pkSiparisID = tblINTERNET_SiparislerQ.intSiparisID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-1].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
WHERE blAktarildi = 'True' AND API = @API AND dtOlusmaTarihi >= @BASLANGIC AND DATEADD(dd,-1,dtOlusmaTarihi) <= @BITIS " + 

(siparis ? @"UNION

SELECT DISTINCT pkIadeID AS sipno,3 AS tur, QUANTUMNO AS belgeno, 
CASE WHEN TKSREF = 5 THEN [Web-Musteri-1].NETTOP ELSE [Web-Musteri-1].SMREF END AS carino, 
CASE WHEN TKSREF = 5 THEN (SELECT [MUS KOD] FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE [Web-Musteri-1].[MUS KOD] END AS carino2, 
CASE WHEN TKSREF = 5 THEN (SELECT MUSTERI FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE SUBE END AS cari, 
dtOlusmaTarihi AS tarih,'False' AS iptal,28 AS vade
,CASE WHEN TKSREF = 5 THEN 'Şube: ' + SUBE + ' (' + CONVERT(nvarchar(50),[Web-Musteri-1].SMREF) + ')' ELSE '' END AS aciklama
FROM tblINTERNET_Iadeler
INNER JOIN (SELECT TIP,GMREF,SMREF,[MUS KOD],SUBE,NETTOP FROM [Web-Musteri-1]) AS [Web-Musteri-1] ON tblINTERNET_Iadeler.SMREF = [Web-Musteri-1].SMREF AND tblINTERNET_Iadeler.TKSREF = [Web-Musteri-1].TIP
INNER JOIN tblINTERNET_IadelerDetay ON pkIadeID = intIadeID
INNER JOIN tblINTERNET_IadelerQ ON pkIadeID = tblINTERNET_IadelerQ.intIadeID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-1].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
WHERE TKSREF != 1 AND API = @API AND dtOlusmaTarihi >= @BASLANGIC AND DATEADD(dd,-1,dtOlusmaTarihi) <= @BITIS " : "") +

"ORDER BY belgeno DESC", CommandType.Text, new ArrayList() { "API", "BASLANGIC", "BITIS" }, new ArrayList() { apikey, baslangic, bitis }, "SiparisDetay");
            /*SqlConnection conn = new SqlConnection(Sultanlar.DatabaseObject.General.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT DISTINCT pkSiparisID AS sipno, QUANTUMNO AS belgeno, [Web-Musteri-TP].SMREF AS carino, [Web-Musteri-TP].[MUS KOD] AS carino2, MUSTERI AS cari, dtOlusmaTarihi AS tarih
FROM tblINTERNET_Siparisler
INNER JOIN [Web-Musteri-TP] ON tblINTERNET_Siparisler.SMREF = [Web-Musteri-TP].SMREF
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = bintSiparisDetayID
INNER JOIN tblINTERNET_SiparislerQ ON pkSiparisID = tblINTERNET_SiparislerQ.intSiparisID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-TP].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
WHERE API = @API AND dtOlusmaTarihi >= @BASLANGIC AND dtOlusmaTarihi <= @BITIS", conn);
            da.SelectCommand.Parameters.AddWithValue("@API", apikey);
            da.SelectCommand.Parameters.AddWithValue("@BASLANGIC", baslangic);
            da.SelectCommand.Parameters.AddWithValue("@BITIS", bitis);
            da.Fill(dt);*/
            return dt;
        }

        private DataTable DetayVeriGetir(bool IadeMi, bool SiparisMi, string SiparisID)
        {
            string sorgu = "SELECT pkSiparisDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, " + (SiparisMi ? "tblINTERNET_SiparislerDetay.intMiktar" : "tblINTERNET_SiparislerDetaySevk.intMiktar") + @" as miktar, strMiktarTur as miktartur, ISK1 as isk1, ISK2 as isk2, ISK3 as isk3, ISK4 as isk4, mnFiyat AS fiyat
FROM tblINTERNET_Siparisler
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = tblINTERNET_SiparislerDetaySevk.bintSiparisDetayID
LEFT OUTER JOIN tblINTERNET_SiparislerDetayISK ON pkSiparisDetayID = tblINTERNET_SiparislerDetayISK.bintSiparisDetayID";
            string parametername = "pkSiparisID";

            if (IadeMi)
            {
                sorgu = @"SELECT pkIadeDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, tblINTERNET_IadelerDetay.intMiktar as miktar, 'ST' as miktartur, 0 as isk1, 0 as isk2, 0 as isk3, 0 as isk4, mnFiyat AS fiyat
FROM tblINTERNET_Iadeler
INNER JOIN tblINTERNET_IadelerDetay ON pkIadeID = intIadeID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID";
                parametername = "pkIadeID";
            }

            DataTable dt = WebGenel.WCFdata(sorgu, new ArrayList() { parametername }, new ArrayList() { SiparisID }, "SiparisDetay");
            return dt;
        }

        public XmlDocument PostXml(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime baslangic = DateTime.Now;

            string xml = icerik.OuterXml;
            DataSet ds = new DataSet();
            ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            DataTable dt = ds.Tables[0];

            string tabloadi = "tbl_" + Bayikod + "_" + Satis;

            if (Bayikod == "1071593" || Bayikod == "1052689" || Bayikod == "1018538") // kaan, peker, yılmaz
            {
                if (Satis == "Satis")
                {
                    DateTime bas = Convert.ToDateTime(Yil + "." + (Ay.Length > 1 ? Ay : "0" + Ay) + ".01");
                    DisVeri.ExecNQwp("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,[CEKIM_TARIH]) >= @TARIH", new ArrayList() { "TARIH" }, new object[] { bas });
                }
                else
                {
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
                }
            }
            else
            {
                if (Satis == "Satis") // satış ise son üç ayı silmemiz lazım, tabloyaz ve veriyaz da sadece parametrede gelen ayı siliyor
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE " + YilAd + "=" + Yil + " AND " + AyAd + ">=" + (Convert.ToInt32(Ay) - 3).ToString());
                else
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
            }


            if (DisVeri.TabloYaz(tabloadi, dt, YilAd, Yil, AyAd, Ay, false))
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>true</basarili></sonuc>");
            else
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>false</basarili></sonuc>");

            SAPs.BayiLogYaz("bayi win servis xml " + Satis, true, Bayikod + " nolu bayi " + Yil + "-" + Ay + " dönemi. Gelen satır: " + dt.Rows.Count.ToString(), baslangic, DateTime.Now);

            return donendeger;
        }
    }
}
