using Sultanlar.DatabaseObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Sultanlar.Model.Xml;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pirpa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Pirpa.svc or Pirpa.svc.cs at the Solution Explorer and start debugging.
    public class Pirpa : IPirpa
    {
        public XmlDocument GetInvoices(string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = DateTime.Parse(baslangic);
            DateTime bit = DateTime.Parse(bitis);

            /*DataSet ds = new DataSet("Satislar");
            DataTable dt = new DataTable("Kalem");
            SqlConnection conn = new SqlConnection(Sultanlar.DatabaseObject.General.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_Pirpa_Satis WHERE FAT_TAR >= @BASLANGIC AND  FAT_TAR <= @BITIS", conn);
            da.SelectCommand.Parameters.AddWithValue("@BASLANGIC", bas);
            da.SelectCommand.Parameters.AddWithValue("@BITIS", bit);
            da.Fill(dt);

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());*/

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Sultanlar.DatabaseObject.General.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT FAT_NO,FAT_NO_MTB,FAT_TAR,PER_KOD,PER_TEM,SUBE FROM vw_Pirpa_Satis WHERE FAT_TAR >= @BASLANGIC AND  FAT_TAR <= @BITIS", conn);
            da.SelectCommand.Parameters.AddWithValue("@BASLANGIC", bas);
            da.SelectCommand.Parameters.AddWithValue("@BITIS", bit);
            da.Fill(dt);


            XmlFaturalarDis faturalar = new XmlFaturalarDis();
            faturalar.Faturalar = new List<XmlFaturaDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlFaturaDis fatura = new XmlFaturaDis();
                DataTable dt1 = WebGenel.WCFdata("SELECT MAL_KOD,MALZEME,ADET_TOP,KOLI_TOP,ISK_TOP,NET_TOP,KDV_TOP,NETKDV_TOP FROM vw_Pirpa_Satis", new ArrayList() { "FAT_NO" }, new ArrayList() { dt.Rows[i]["FAT_NO"].ToString() }, "InvoiceDetail");

                fatura.FAT_NO = dt.Rows[i]["FAT_NO"].ToString();
                fatura.FAT_NO_MTB = dt.Rows[i]["FAT_NO_MTB"].ToString();
                fatura.FAT_TAR = Convert.ToDateTime(dt.Rows[i]["FAT_TAR"]);
                fatura.PER_KOD = dt.Rows[i]["PER_KOD"].ToString();
                fatura.PER_TEM = dt.Rows[i]["PER_TEM"].ToString();

                fatura.Kalemler = new List<XmlFaturaDisDetay>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    XmlFaturaDisDetay detay = new XmlFaturaDisDetay();
                    detay.MAL_KOD = Convert.ToInt32(dt1.Rows[j]["MAL_KOD"]);
                    detay.MALZEME = dt1.Rows[j]["MALZEME"].ToString();
                    detay.ADET_TOP = Convert.ToDouble(dt1.Rows[j]["ADET_TOP"]);
                    detay.KOLI_TOP = Convert.ToDouble(dt1.Rows[j]["KOLI_TOP"]);
                    detay.ISK_TOP = Convert.ToDouble(dt1.Rows[j]["ISK_TOP"]);
                    detay.NET_TOP = Convert.ToDouble(dt1.Rows[j]["NET_TOP"]);
                    detay.KDV_TOP = Convert.ToDouble(dt1.Rows[j]["KDV_TOP"]);
                    detay.NETKDV_TOP = Convert.ToDouble(dt1.Rows[j]["NETKDV_TOP"]);
                    fatura.Kalemler.Add(detay);
                }
                faturalar.Faturalar.Add(fatura);
            }

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(XmlFaturalarDis), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();


            MySerializer.Serialize(TW, faturalar, xsn);



            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        /*public DataTable GetInvoices2(DateTime baslangic, DateTime bitis)
        {
            DataTable donendeger = new DataTable();

            SqlConnection conn = new SqlConnection(Sultanlar.DatabaseObject.General.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_Pirpa_Satis WHERE FAT_TAR >= @BASLANGIC AND  FAT_TAR <= @BITIS", conn);
            da.SelectCommand.Parameters.AddWithValue("@BASLANGIC", baslangic);
            da.SelectCommand.Parameters.AddWithValue("@BITIS", bitis);
            da.Fill(donendeger);

            return donendeger;
        }*/

        public XmlDocument GetOrders(string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = DateTime.Parse(baslangic);
            DateTime bit = DateTime.Parse(bitis);



            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Sultanlar.DatabaseObject.General.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT [pkSiparisID] AS SipNo,sintFiyatTipiID, intSLSREF AS [PlasiyerKodu], strAd + ' ' + strSoyad AS [PlasiyerAdi],strTelefon AS Telefon,BOLGE AS [Bölge],[SMREF] AS MusKod"
+ " ,[dtOlusmaTarihi] AS Tarih,[mnToplamTutar] AS Tutar, strAciklama "
+ "FROM[tblINTERNET_Siparisler] "
+ "INNER JOIN tblINTERNET_Musteriler ON[tblINTERNET_Siparisler].intMusteriID = pkMusteriID "
+ "INNER JOIN tblINTERNET_Musteriler_Ek ON tblINTERNET_Musteriler_Ek.intMusteriID = pkMusteriID "
+ "INNER JOIN [Web-Dis-Siparis] ON [pkSiparisID] = intSiparisID "
+ "WHERE blAktarilmis = 'True' "
+ "AND [dtOlusmaTarihi] >= @BASLANGIC AND [dtOlusmaTarihi] <= @BITIS "
+ "AND (intSLSREF = 830222 OR intSLSREF = 830226 OR intSLSREF = 830227 OR intSLSREF = 830223 OR intSLSREF = 830107 OR intSLSREF = 830228 OR intSLSREF = 830224 OR intSLSREF = 830225 OR intSLSREF = 830229 OR intSLSREF = 830221) "
+ "ORDER BY pkSiparisID DESC", conn);
            da.SelectCommand.Parameters.AddWithValue("@BASLANGIC", bas);
            da.SelectCommand.Parameters.AddWithValue("@BITIS", bit);
            da.Fill(dt);



            XmlSiparislerDis siparisler = new XmlSiparislerDis();
            siparisler.Siparisler = new List<XmlSiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlSiparisDis siparis = new XmlSiparisDis();

                DataTable dt2 = WebGenel.WCFdata("SELECT DISTINCT [IL] AS Sehir,[ILCE] AS Ilce,[GMREF] AS BayiKod,[MUSTERI] AS BayiUnvan,[SMREF] AS Kod,[SUBE] AS Unvan,[MT ACIKLAMA] AS Aciklama,SEHIR AS FaturaTip,[VRG DAIRE] AS VergiDaire,[VRG NO] AS VergiNo,[ADRES] AS Adres,[TEL-1] AS Telefon,[CEP-1] AS Mobil,[FAX-1] AS Fax,[EMAIL-1] AS Eposta FROM [Web-Musteri]", new ArrayList() { "SMREF" }, new ArrayList() { dt.Rows[i]["MusKod"].ToString() }, "Musteri");
                siparis.Musteri = new XmlSiparisMusteri();
                siparis.Musteri.Sehir = dt2.Rows[0]["Sehir"].ToString();
                siparis.Musteri.Ilce = dt2.Rows[0]["Ilce"].ToString();
                siparis.Musteri.BayiKod = dt2.Rows[0]["BayiKod"].ToString();
                siparis.Musteri.BayiUnvan = dt2.Rows[0]["BayiUnvan"].ToString();
                siparis.Musteri.Kod = dt2.Rows[0]["Kod"].ToString();
                siparis.Musteri.Unvan = dt2.Rows[0]["Unvan"].ToString();
                siparis.Musteri.Aciklama = dt2.Rows[0]["Aciklama"].ToString();
                siparis.Musteri.FaturaTip = dt2.Rows[0]["FaturaTip"].ToString();
                siparis.Musteri.VergiDaire = dt2.Rows[0]["VergiDaire"].ToString();
                siparis.Musteri.VergiNo = dt2.Rows[0]["VergiNo"].ToString();
                siparis.Musteri.Adres = dt2.Rows[0]["Adres"].ToString();
                siparis.Musteri.Telefon = dt2.Rows[0]["Telefon"].ToString();
                siparis.Musteri.Mobil = dt2.Rows[0]["Mobil"].ToString();
                siparis.Musteri.Fax = dt2.Rows[0]["Fax"].ToString();
                siparis.Musteri.Eposta = dt2.Rows[0]["Eposta"].ToString();

                siparis.SipNo = dt.Rows[i]["SipNo"].ToString();
                siparis.PlasiyerKodu = dt.Rows[i]["PlasiyerKodu"].ToString();
                siparis.PlasiyerAdi = dt.Rows[i]["PlasiyerAdi"].ToString();
                siparis.Telefon = dt.Rows[i]["Telefon"].ToString();
                siparis.Bolge = dt.Rows[i]["Bölge"].ToString();
                siparis.Tarih = Convert.ToDateTime(dt.Rows[i]["Tarih"]);
                //siparis.Tutar = Convert.ToDouble(dt.Rows[i]["Tutar"]);
                siparis.Aciklama = dt.Rows[i]["strAciklama"].ToString().Split(new string[] { ";;;" }, StringSplitOptions.None)[1];
                siparis.Kalemler = new List<XmlSiparisDisDetay>();

                DataTable dt1 = WebGenel.WCFdata("" +

                    "SELECT UrunKod,Bolum,Barkod,KdvOran,KoliAdet,UrunAd,Adet,ISNULL(BrutFiyat,0) AS BrutFiyat,ISNULL(Isk1,0) AS Isk1,ISNULL(Isk2,0) AS Isk2,ISNULL(Isk3,0) AS Isk3,ISNULL(Isk4,0) AS Isk4" +
",CONVERT(decimal(18,3),ISNULL(dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0),0)) AS NetFiyat" +
",CONVERT(decimal(18,3),ISNULL(dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0) / 100 * KdvOran,0)) AS Kdv" +
",CONVERT(decimal(18,3),ISNULL(dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0) + (dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0) / 100 * KdvOran),0)) AS KdvDahilNet " +
"FROM " +
"(" +
"SELECT intSiparisID,[intUrunID] AS UrunKod,[OZEL ACIK] AS Bolum,BARKOD AS Barkod,KDV AS KdvOran,KOLI AS KoliAdet,[strUrunAdi] AS UrunAd,[intMiktar] AS Adet" +
",(SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID) AS BrutFiyat" +
",(SELECT ISK1 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID) AS Isk1" +
",(SELECT ISK2 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID) AS Isk2" +
",(SELECT ISK3 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID) AS Isk3" +
",(SELECT ISK6 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID) AS Isk4 " +
"FROM [tblINTERNET_SiparislerDetay] " +
"INNER JOIN tblINTERNET_Siparisler ON intSiparisID = pkSiparisID " +
"INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID LEFT OUTER JOIN tblINTERNET_SiparislerDetayISK ON pkSiparisDetayID = bintSiparisDetayID" +
") AS TABLO1" +

                    "", new ArrayList() { "intSiparisID" }, new ArrayList() { siparis.SipNo }, "OrderDetail");

                double toplambrut = 0;
                double toplamiskonto = 0;
                double toplamkdv = 0;
                double toplamnet = 0;
                double toplamnetkdv = 0;
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    XmlSiparisDisDetay detay = new XmlSiparisDisDetay();
                    detay.UrunKod = dt1.Rows[j]["UrunKod"].ToString();
                    detay.Bolum = dt1.Rows[j]["Bolum"].ToString();
                    detay.Barkod = dt1.Rows[j]["Barkod"].ToString();
                    detay.KdvOran = dt1.Rows[j]["KdvOran"].ToString();
                    detay.KoliAdet = dt1.Rows[j]["KoliAdet"].ToString();
                    detay.UrunAd = dt1.Rows[j]["UrunAd"].ToString();
                    detay.Adet = Convert.ToInt32(dt1.Rows[j]["Adet"]);
                    detay.BrutFiyat = Convert.ToDouble(dt1.Rows[j]["BrutFiyat"]);
                    detay.Isk1 = Convert.ToDouble(dt1.Rows[j]["Isk1"]);
                    detay.Isk2 = Convert.ToDouble(dt1.Rows[j]["Isk2"]);
                    detay.Isk3 = Convert.ToDouble(dt1.Rows[j]["Isk3"]);
                    detay.Isk4 = Convert.ToDouble(dt1.Rows[j]["Isk4"]);
                    detay.NetFiyat = Convert.ToDouble(dt1.Rows[j]["NetFiyat"]);
                    detay.Kdv = Convert.ToDouble(dt1.Rows[j]["Kdv"]);
                    detay.KdvDahilNet = Convert.ToDouble(dt1.Rows[j]["KdvDahilNet"]);
                    siparis.Kalemler.Add(detay);

                    toplambrut += detay.BrutFiyat * detay.Adet;
                    toplamiskonto += (detay.BrutFiyat - detay.NetFiyat) * detay.Adet;
                    toplamkdv += (detay.KdvDahilNet - detay.NetFiyat) * detay.Adet;
                    toplamnet += detay.NetFiyat * detay.Adet;
                    toplamnetkdv += detay.KdvDahilNet * detay.Adet;
                }
                siparis.ToplamBrut = Convert.ToDouble(toplambrut.ToString("N3"));
                siparis.ToplamIskonto = Convert.ToDouble(toplamiskonto.ToString("N3"));
                siparis.ToplamKDV = Convert.ToDouble(toplamkdv.ToString("N3"));
                siparis.ToplamNet = Convert.ToDouble(toplamnet.ToString("N3"));
                siparis.ToplamNetKDV = Convert.ToDouble(toplamnetkdv.ToString("N3"));

                siparisler.Siparisler.Add(siparis);
            }


            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(XmlSiparislerDis), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();


            MySerializer.Serialize(TW, siparisler, xsn);



            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }
    }

    public class PirpaServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if (userName != "pirpa" && password != "abdullah")
                throw new SecurityTokenException("Kullanıcı adı-parola yanlış.");
        }
    }
}
