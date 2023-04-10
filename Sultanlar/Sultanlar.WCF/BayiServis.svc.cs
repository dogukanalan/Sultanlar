using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Model.Xml;
using Sultanlar.Model.Bayi;

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

            SiparislerDis siparisler = SiparisGetir(Guid.Parse(apikey), bas, bit);

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(SiparislerDis), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, siparisler, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public SiparislerDis SiparisJ(string apikey, string baslangic, string bitis)
        {
            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            SiparislerDis siparisler = SiparisGetir(Guid.Parse(apikey), bas, bit);

            return siparisler;
        }

        public XmlDocument Fatura(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            /*if (apikey == "F7FF8316-3C41-482B-BB06-901D0E4C38A7")
            {
                BimatFaturalarDis faturalar = FaturaGetirBimat(new string[0], apikey, bas, bit);
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("g", "http://base.google.com/ns/1.0");

                var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                    new List<Type>() { typeof(BimatSiparisDis), typeof(BimatSiparisDisDetay) }
                    ));
                XmlSerializer MySerializer = new XmlSerializer(typeof(BimatFaturalarDis), allXMLAttribueOverrides);

                TextWriter TW = new StringWriter();
                MySerializer.Serialize(TW, faturalar, xsn);
                donendeger.LoadXml(TW.ToString());
            /
            else
            {*/
                FaturalarDis faturalar = FaturaGetir(new string[0], Guid.Parse(apikey), bas, bit);
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("g", "http://base.google.com/ns/1.0");
                XmlSerializer MySerializer = new XmlSerializer(typeof(FaturalarDis), "http://www.w3.org/2005/Atom");

                TextWriter TW = new StringWriter();
                MySerializer.Serialize(TW, faturalar, xsn);
                donendeger.LoadXml(TW.ToString());
            //}


            return donendeger;
        }

        public FaturalarDis FaturaJ(string apikey, string baslangic, string bitis)
        {
            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            FaturalarDis faturalar = FaturaGetir(new string[0], Guid.Parse(apikey), bas, bit);

            return faturalar;
        }

        private SiparislerDis SiparisGetir(Guid apikey, DateTime baslangic, DateTime bitis)
        {
            SiparislerDis siparisler = new SiparislerDis();

            DataTable dt = BaslikVeriGetir(true, apikey, new string[0], baslangic, bitis);

            siparisler.Siparisler = new List<SiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SiparisDis siparis = new SiparisDis();

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
                siparis.detaylar = new List<SiparisDisDetay>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    SiparisDisDetay detay = new SiparisDisDetay();
                    detay.detayno = dt1.Rows[j]["detayno"].ToString();
                    detay.malzeme = new MalzemeDetay();
                    detay.malzeme.malno = dt1.Rows[j]["malno"].ToString();
                    detay.malzeme.malacik = dt1.Rows[j]["malzeme"].ToString();
                    detay.malzeme.koli = dt1.Rows[j]["koli"].ToString();
                    detay.miktar = dt1.Rows[j]["miktartur"].ToString() == "KI" ? (Convert.ToInt32(dt1.Rows[j]["miktar"]) * Convert.ToInt32(dt1.Rows[j]["koli"])).ToString() : dt1.Rows[j]["miktar"].ToString();
                    detay.miktartur = "ST"; //dt1.Rows[j]["miktartur"].ToString();
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

        private FaturalarDis FaturaGetir(string[] SiparisNo, Guid apikey, DateTime baslangic, DateTime bitis)
        {
            FaturalarDis faturalar = new FaturalarDis();

            DataTable dt = new DataTable();
            if (SiparisNo.Length == 0)
                dt = BaslikVeriGetir(false, apikey, new string[0], baslangic, bitis);
            else
                dt = BaslikVeriGetir(false, apikey, SiparisNo, baslangic, bitis);

            faturalar.Faturalar = new List<SiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SiparisDis siparis = new SiparisDis();

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
                siparis.detaylar = new List<SiparisDisDetay>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    SiparisDisDetay detay = new SiparisDisDetay();
                    detay.detayno = dt1.Rows[j]["detayno"].ToString();
                    detay.malzeme = new MalzemeDetay();
                    detay.malzeme.malno = dt1.Rows[j]["malno"].ToString();
                    detay.malzeme.malacik = dt1.Rows[j]["malzeme"].ToString();
                    detay.malzeme.koli = dt1.Rows[j]["koli"].ToString();
                    detay.miktar = dt1.Rows[j]["miktartur"].ToString() == "KI" ? (Convert.ToInt32(dt1.Rows[j]["miktar"]) * Convert.ToInt32(dt1.Rows[j]["koli"])).ToString() : dt1.Rows[j]["miktar"].ToString();
                    detay.miktartur = "ST";  //dt1.Rows[j]["miktartur"].ToString();
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

        public XmlDocument Fatura2(string apikey, string sipler)
        {
            XmlDocument donendeger = new XmlDocument();

            string[] sips = sipler.Split('.');

            FaturalarDis faturalar = FaturaGetir(sips, Guid.Parse(apikey), DateTime.Now, DateTime.Now);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(FaturalarDis), typeof(SiparisDis), typeof(SiparisDisDetay), typeof(MalzemeDetay) } ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(FaturalarDis), allXMLAttribueOverrides);

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public FaturalarDis Fatura2J(string apikey, string sipler)
        {
            string[] sips = sipler.Split('.');

            FaturalarDis faturalar = FaturaGetir(sips, Guid.Parse(apikey), DateTime.Now, DateTime.Now);
            return faturalar;
        }

        #region logo
        public XmlDocument SiparisLogo(string apikey, string baslangic, string bitis)
        {
            return Siparis(apikey, baslangic, bitis);
        }

        public SiparislerDis SiparisJLogo(string apikey, string baslangic, string bitis)
        {
            return SiparisJ(apikey, baslangic, bitis);
        }

        public XmlDocument FaturaLogo(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            BimatFaturalarDis faturalar = FaturaGetirLogo(new string[0], apikey, bas, bit);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(BimatSiparisDis), typeof(BimatSiparisDisDetay) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(BimatFaturalarDis), allXMLAttribueOverrides);

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public BimatFaturalarDis FaturaJLogo(string apikey, string baslangic, string bitis)
        {
            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            BimatFaturalarDis faturalar = FaturaGetirLogo(new string[0], apikey, bas, bit);

            return faturalar;
        }

        public XmlDocument Fatura2Logo(string apikey, string sipler)
        {
            XmlDocument donendeger = new XmlDocument();

            /*if (apikey != "F7FF8316-3C41-482B-BB06-901D0E4C38A7")
                return donendeger;*/

            string[] sips = sipler.Split('.');

            BimatFaturalarDis faturalar = FaturaGetirLogo(sips, apikey, DateTime.Now, DateTime.Now);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(BimatSiparisDis), typeof(BimatSiparisDisDetay), typeof(BimatSiparisDisDispatch), typeof(BimatSiparisDisPayment), typeof(BimatSiparisDisIntel), 
                    typeof(BimatSiparisDisOkcInfo), typeof(BimatSiparisDisCmpInfo) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(BimatFaturalarDis), allXMLAttribueOverrides);

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public BimatFaturalarDis Fatura2JLogo(string apikey, string sipler)
        {
            /*if (apikey != "F7FF8316-3C41-482B-BB06-901D0E4C38A7")
                return donendeger;*/

            string[] sips = sipler.Split('.');

            BimatFaturalarDis faturalar = FaturaGetirLogo(sips, apikey, DateTime.Now, DateTime.Now);
            return faturalar;
        }



        private BimatFaturalarDis FaturaGetirLogo(string[] SiparisNo, string apikey, DateTime baslangic, DateTime bitis)
        {
            BimatFaturalarDis faturalar = new BimatFaturalarDis();

            DataTable dt = new DataTable();
            if (SiparisNo.Length == 0)
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), new string[0], baslangic, bitis);
            else
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), SiparisNo, baslangic, bitis);

            faturalar.Faturalar = new List<BimatSiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]);

                BimatSiparisDis siparis = new BimatSiparisDis();
                siparis.DBOP = "INS";

                double topfiyat = 0;
                double topiskonto = 0;
                double topkdv = 0;
                double topnet = 0;
                double topnetkdv = 0;

                siparis.belgeno = dt.Rows[i]["belgeno"].ToString();
                siparis.carino2 = dt.Rows[i]["carino2"].ToString();
                siparis.tarih = tarih.ToString("dd'.'MM'.'yyyy");
                siparis.TIME = tarih.ToShortTimeString();
                siparis.SHIP_DATE = siparis.tarih;
                siparis.DOC_DATE = siparis.tarih;

                siparis.DATE_CREATED = siparis.DOC_DATE;
                siparis.HOUR_CREATED = tarih.Hour.ToString();
                siparis.MIN_CREATED = tarih.Minute.ToString();
                siparis.SEC_CREATED = tarih.Second.ToString();
                siparis.SALESMANCODE = dt.Rows[i]["saticino"].ToString();
                siparis.INVOICE_NUMBER = siparis.belgeno;

                //siparis.DISPATCHES = new List<BimatSiparisDisDispatch>();
                BimatSiparisDisDispatch dispatch = new BimatSiparisDisDispatch();
                dispatch.DATE = siparis.tarih;
                dispatch.INVOICE_NUMBER = siparis.belgeno;
                dispatch.ARP_CODE = siparis.carino2;
                dispatch.DATE_CREATED = dispatch.DATE;
                dispatch.HOUR_CREATED = tarih.Hour.ToString();
                dispatch.MIN_CREATED = tarih.Minute.ToString();
                dispatch.SEC_CREATED = tarih.Second.ToString();
                dispatch.SALESMANCODE = dt.Rows[i]["saticino"].ToString();
                dispatch.SHIP_DATE = dispatch.DATE;
                dispatch.DOC_DATE = dispatch.DATE;

                siparis.PAYMENT_LIST = new List<BimatSiparisDisPayment>();
                BimatSiparisDisPayment payment = new BimatSiparisDisPayment();
                payment.DATE = siparis.tarih;
                payment.PROCDATE = payment.DATE;
                payment.DISCOUNT_DUEDATE = payment.DATE;
                siparis.PAYMENT_LIST.Add(payment);

                DataTable dt1 = DetayVeriGetir(siparis.TYPE == "3", false, dt.Rows[i]["sipno"].ToString());
                siparis.TRANSACTIONS = new List<BimatSiparisDisDetay>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    double fiyat = Convert.ToDouble(dt1.Rows[j]["fiyat"]);
                    double miktar = Convert.ToDouble(dt1.Rows[j]["miktar"]);
                    double isk1 = Convert.ToDouble(dt1.Rows[j]["isk1"]);
                    double isk2 = Convert.ToDouble(dt1.Rows[j]["isk2"]);
                    double isk3 = Convert.ToDouble(dt1.Rows[j]["isk3"]);
                    double isk4 = Convert.ToDouble(dt1.Rows[j]["isk4"]);
                    double kdvoran = Convert.ToInt32(dt1.Rows[j]["kdv"]);
                    double birimnet = Class.Math.IskontoDus(fiyat, isk1, isk2, isk3, isk4, 0);
                    double birimnetkdv = Class.Math.KdvEkle(birimnet, kdvoran);
                    double birimkdv = birimnet / 100 * kdvoran;

                    double toplam = fiyat * miktar;
                    double toplamnet = birimnet * miktar;
                    double toplamkdv = birimkdv * miktar;
                    double toplamnetkdv = birimnetkdv * miktar;
                    double toplamindirim = toplam - toplamnet;

                    topfiyat += toplam;
                    topiskonto += toplamindirim;
                    topkdv += toplamkdv;
                    topnet += toplamnet;
                    topnetkdv += toplamnetkdv;

                    BimatSiparisDisDetay detay = new BimatSiparisDisDetay();
                    detay.malno = dt1.Rows[j]["malno"].ToString();
                    detay.malacik = dt1.Rows[j]["malzeme"].ToString();
                    detay.miktar = dt1.Rows[j]["miktartur"].ToString() == "KI" ? (Convert.ToInt32(dt1.Rows[j]["miktar"]) * Convert.ToInt32(dt1.Rows[j]["koli"])).ToString() : dt1.Rows[j]["miktar"].ToString();
                    detay.PRICE = fiyat.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.TOTAL = toplam.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.COST_DISTR = toplamindirim.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.DISCOUNT_DISTR = toplamindirim.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.UNIT_CODE = "ST"; //dt1.Rows[j]["miktartur"].ToString();
                    detay.VAT_RATE = dt1.Rows[j]["kdv"].ToString();
                    detay.VAT_AMOUNT = toplamkdv.ToString("N2").Replace(".", "").Replace(",", ".");
                    detay.VAT_BASE = detay.VAT_RATE;
                    detay.TOTAL_NET = toplamnetkdv.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.EDT_PRICE = detay.PRICE;
                    detay.MONTH = tarih.Month.ToString();
                    detay.YEAR = tarih.Year.ToString();
                    detay.GUID = Guid.NewGuid().ToString();

                    detay.CAMPAIGN_INFOS = new List<BimatSiparisDisCmpInfo>();
                    BimatSiparisDisCmpInfo cmp = new BimatSiparisDisCmpInfo();
                    detay.CAMPAIGN_INFOS.Add(cmp);

                    siparis.TRANSACTIONS.Add(detay);

                    for (int k = 0; k < 4; k++)
                    {
                        BimatSiparisDisDetay detayi = new BimatSiparisDisDetay();
                        detayi.TYPE = "2";
                        detayi.malno = "";
                        detayi.DETAIL_LEVEL = "1";
                        detayi.miktar = "0";
                        detayi.TOTAL = toplamindirim.ToString("N4").Replace(".", "").Replace(",", ".");
                        detayi.DISCOUNT_RATE = (k == 0 ? isk1.ToString("N4") : k == 1 ? isk2.ToString("N4") : k == 2 ? isk3.ToString("N4") : k == 3 ? isk4.ToString("N4") : "0").Replace(".", "").Replace(",", ".");
                        detayi.BASE_AMOUNT = "0";
                        detayi.UNIT_CONV1 = "0";
                        detayi.UNIT_CONV2 = "0";
                        detayi.DATA_REFERENCE = "22";
                        detayi.DIST_ORD_REFERENCE = "0";
                        detayi.MULTI_ADD_TAX = "0";
                        detayi.MONTH = tarih.Month.ToString();
                        detayi.YEAR = tarih.Year.ToString();
                        detayi.DEDUCTION_PART1 = "2";
                        detayi.DEDUCTION_PART2 = "3";
                        detayi.GUID = detay.GUID;
                        detayi.PARENTLNREF = "27";
                        siparis.TRANSACTIONS.Add(detayi);
                    }
                }

                dispatch.TOTAL_DISCOUNTS = topiskonto.ToString("N4").Replace(".", "").Replace(",", ".");
                dispatch.TOTAL_DISCOUNTED = topiskonto.ToString("N4").Replace(".", "").Replace(",", ".");
                dispatch.TOTAL_VAT = topkdv.ToString("N2").Replace(".", "").Replace(",", ".");
                dispatch.TOTAL_GROSS = topfiyat.ToString("N4").Replace(".", "").Replace(",", ".");
                dispatch.TOTAL_NET = topnetkdv.ToString("N4").Replace(".", "").Replace(",", ".");
                dispatch.RC_NET = topnetkdv.ToString("N4").Replace(".", "").Replace(",", ".");
                dispatch.GUID = Guid.NewGuid().ToString();
                //siparis.DISPATCHES.Add(dispatch);

                payment.TOTAL = dispatch.TOTAL_NET;

                siparis.TOTAL_DISCOUNTS = topiskonto.ToString("N4").Replace(".", "").Replace(",", ".");
                siparis.TOTAL_DISCOUNTED = topiskonto.ToString("N4").Replace(".", "").Replace(",", ".");
                siparis.TOTAL_VAT = topkdv.ToString("N2").Replace(".", "").Replace(",", ".");
                siparis.TOTAL_GROSS = topfiyat.ToString("N4").Replace(".", "").Replace(",", ".");
                siparis.TOTAL_NET = topnetkdv.ToString("N4").Replace(".", "").Replace(",", ".");
                siparis.RC_NET = topnetkdv.ToString("N4").Replace(".", "").Replace(",", ".");

                siparis.GUID = dispatch.GUID;

                siparis.INTEL_LIST = new List<BimatSiparisDisIntel>();
                BimatSiparisDisIntel intel = new BimatSiparisDisIntel();
                siparis.INTEL_LIST.Add(intel);

                siparis.OKCINFO_LIST = new List<BimatSiparisDisOkcInfo>();
                BimatSiparisDisOkcInfo okcinfo = new BimatSiparisDisOkcInfo();
                siparis.OKCINFO_LIST.Add(okcinfo);

                faturalar.Faturalar.Add(siparis);
            }

            return faturalar;
        }
        #endregion

        private DataTable BaslikVeriGetir(bool siparis, Guid apikey, string[] SiparisNo, DateTime baslangic, DateTime bitis)
        {
            ArrayList paramnames = new ArrayList() { "API", "BASLANGIC", "BITIS" };
            ArrayList paramvalues = new ArrayList() { apikey, baslangic, bitis };

            string where = "API = @API AND dtOlusmaTarihi >= @BASLANGIC AND DATEADD(dd,-1,dtOlusmaTarihi) <= @BITIS ";
            string iadewhere = "API = @API AND dtOlusmaTarihi >= @BASLANGIC AND DATEADD(dd,-1,dtOlusmaTarihi) <= @BITIS ";
            if (SiparisNo.Length > 0)
            {
                paramnames = new ArrayList();
                paramvalues = new ArrayList();
                where = "(";
                iadewhere = "(";
                for (int i = 0; i < SiparisNo.Length; i++)
                {
                    where += "pkSiparisID = " + SiparisNo[i].ToString() + " OR ";
                    iadewhere += "pkIadeID = " + SiparisNo[i].ToString() + " OR ";
                }
                where = where.Substring(0, where.Length - 4) + ")";
                iadewhere = iadewhere.Substring(0, iadewhere.Length - 4) + ")";
            }

            DataTable dt = WebGenel.WCFdata(@"SELECT DISTINCT pkSiparisID AS sipno,8 AS tur, QUANTUMNO AS belgeno, 
CASE WHEN TKSREF = 5 THEN [Web-Musteri-1].NETTOP ELSE [Web-Musteri-1].SMREF END AS carino, 
CASE WHEN TKSREF = 5 THEN (SELECT [MUS KOD] FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE [Web-Musteri-1].[MUS KOD] END AS carino2, 
CASE WHEN TKSREF = 5 THEN (SELECT MUSTERI FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE SUBE END AS cari, " + 
(siparis ? "dtOlusmaTarihi" : "FATTAR") + " AS tarih," +
(siparis ? "'False'" : "IPTAL") + " AS iptal," +
@"28 AS vade
,CASE WHEN TKSREF = 5 THEN 'Şube: ' + SUBE + ' (' + CONVERT(nvarchar(50),[Web-Musteri-1].SMREF) + ')' ELSE '' END AS aciklama
,intMusteriID AS saticino
,dtOlusmaTarihi as siptar
FROM tblINTERNET_Siparisler
INNER JOIN (SELECT TIP,GMREF,SMREF,[MUS KOD],SUBE,NETTOP FROM [Web-Musteri-1]) AS [Web-Musteri-1] ON tblINTERNET_Siparisler.SMREF = [Web-Musteri-1].SMREF AND tblINTERNET_Siparisler.TKSREF = [Web-Musteri-1].TIP
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = bintSiparisDetayID
INNER JOIN tblINTERNET_SiparislerQ ON pkSiparisID = tblINTERNET_SiparislerQ.intSiparisID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-1].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
WHERE tblINTERNET_SiparislerDetaySevk.intMiktar > 0 AND blAktarildi = 'True' AND API = '" + apikey.ToString() + "' AND " + 
where + 

(siparis ? @"UNION

SELECT DISTINCT pkIadeID AS sipno,3 AS tur, QUANTUMNO AS belgeno, 
CASE WHEN TKSREF = 5 THEN [Web-Musteri-1].NETTOP ELSE [Web-Musteri-1].SMREF END AS carino, 
CASE WHEN TKSREF = 5 THEN (SELECT [MUS KOD] FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE [Web-Musteri-1].[MUS KOD] END AS carino2, 
CASE WHEN TKSREF = 5 THEN (SELECT MUSTERI FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE SUBE END AS cari, 
dtOlusmaTarihi AS tarih,'False' AS iptal,28 AS vade
,CASE WHEN TKSREF = 5 THEN 'Şube: ' + SUBE + ' (' + CONVERT(nvarchar(50),[Web-Musteri-1].SMREF) + ')' ELSE '' END AS aciklama
,intMusteriID AS saticino
,dtOlusmaTarihi as siptar
FROM tblINTERNET_Iadeler
INNER JOIN (SELECT TIP,GMREF,SMREF,[MUS KOD],SUBE,NETTOP FROM [Web-Musteri-1]) AS [Web-Musteri-1] ON tblINTERNET_Iadeler.SMREF = [Web-Musteri-1].SMREF AND tblINTERNET_Iadeler.TKSREF = [Web-Musteri-1].TIP
INNER JOIN tblINTERNET_IadelerDetay ON pkIadeID = intIadeID
INNER JOIN tblINTERNET_IadelerQ ON pkIadeID = tblINTERNET_IadelerQ.intIadeID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-1].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
WHERE TKSREF != 1 AND API = '" + apikey.ToString() + "' AND " +
iadewhere
: "") +

"ORDER BY belgeno DESC", CommandType.Text, paramnames, paramvalues, "SiparisDetay");
            return dt;
        }

        private DataTable DetayVeriGetir(bool IadeMi, bool SiparisMi, string SiparisID)
        {
            string where = "AND pkSiparisID = " + SiparisID;
            string sorgu = "SELECT pkSiparisDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, " + (SiparisMi ? "tblINTERNET_SiparislerDetay.intMiktar" : "tblINTERNET_SiparislerDetaySevk.intMiktar") + @" as miktar, strMiktarTur as miktartur, ISK1 as isk1, ISK2 as isk2, ISK3 as isk3, ISK4 as isk4, mnFiyat AS fiyat,KDV
FROM tblINTERNET_Siparisler
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = tblINTERNET_SiparislerDetaySevk.bintSiparisDetayID
LEFT OUTER JOIN tblINTERNET_SiparislerDetayISK ON pkSiparisDetayID = tblINTERNET_SiparislerDetayISK.bintSiparisDetayID WHERE tblINTERNET_SiparislerDetaySevk.intMiktar > 0 " + where;
            //string parametername = "pkSiparisID";

            if (IadeMi)
            {
                sorgu = @"SELECT pkIadeDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, tblINTERNET_IadelerDetay.intMiktar as miktar, 'ST' as miktartur, 0 as isk1, 0 as isk2, 0 as isk3, 0 as isk4, mnFiyat AS fiyat,KDV
FROM tblINTERNET_Iadeler
INNER JOIN tblINTERNET_IadelerDetay ON pkIadeID = intIadeID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID WHERE pkIadeID = " + SiparisID;
                //parametername = "pkIadeID";
            }

            DataTable dt = WebGenel.WCFdata(sorgu, new ArrayList(), new ArrayList(), "SiparisDetay");
            return dt;
        }

        public string IadeXml(XmlDocument icerik, string Bayikod, string Musteri)
        {
            string donendeger = string.Empty;
            string aktarilan = "Aktarılanlar.";
            string hatali = "Aktarılamayanlar.";

            XmlDocument gelen = new XmlDocument();
            DateTime tarih = DateTime.Now;
            Musteriler musteri = Musteriler.GetMusteriByID(Convert.ToInt32(Musteri));

            gelen.Load(new MemoryStream(Convert.FromBase64String(icerik.InnerText)));
            XmlNodeList faturalar = gelen.SelectNodes("SALES_INVOICES/INVOICE");
            for (int i = 0; i < faturalar.Count; i++)
            {
                string muskod = faturalar[i].SelectSingleNode("ARP_CODE").InnerText;
                string docnumber = faturalar[i].SelectSingleNode("DOC_NUMBER").InnerText;
                string docdate = faturalar[i].SelectSingleNode("DATE").InnerText;
                string hour = faturalar[i].SelectSingleNode("HOUR_CREATED").InnerText;
                string minute = faturalar[i].SelectSingleNode("MIN_CREATED").InnerText;
                string second = faturalar[i].SelectSingleNode("SEC_CREATED").InnerText;
                DateTime date = DateTime.ParseExact(docdate + " " + hour + ":" + minute + ":" + second, "dd.MM.yyyy H:m:s", System.Globalization.CultureInfo.CurrentCulture);
                int SMREF = CariHesaplarTP.GetSMREFByMUSKOD(Convert.ToInt32(Bayikod), muskod);

                if (IadelerQ.QuantumNoVarMi(docnumber))
                {
                    hatali += docnumber + ": fatura numarası zaten kayıtlı.";
                }
                else
                {
                    if (SMREF > 0)
                    {
                        Iadeler iade = new Iadeler(Convert.ToInt32(Musteri), SMREF, date, -2, false, tarih, "Sistem;;;" + docnumber + ";;;bimat xml");
                        iade.DoInsert();
                        iade.DoUpdate();
                        Iadeler.SetTksref(4, iade.pkIadeID);
                        Iadeler.SetSapDepo("", "", "", "", iade.pkIadeID);

                        XmlNodeList transactions = faturalar[i].SelectNodes("TRANSACTIONS/TRANSACTION");
                        string hataliurun = string.Empty;
                        for (int j = 0; j < transactions.Count; j++)
                        {
                            string type = transactions[j].SelectSingleNode("TYPE").InnerText;
                            if (type == "0") // malzeme
                            {
                                string itemref = transactions[j].SelectSingleNode("MASTER_CODE").InnerText;

                                if (Urunler.GetProductUrunID(itemref) == 0) // ilk bulamadığı üründe buraya girecek
                                {
                                    hataliurun += itemref;

                                    DataTable dt = new DataTable();
                                    IadelerDetay.GetObjectsByIadeID(dt, iade.pkIadeID);
                                    for (int k = 0; k < dt.Rows.Count; k++)
                                    {
                                        IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(dt.Rows[k]["pkIadeDetayID"]));
                                        IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(id.pkIadeDetayID);
                                        idf.DoDelete();
                                        id.DoDelete();
                                    }

                                    iade.DoDelete();
                                    hatali += docnumber + ": " + itemref + " kodlu malzeme bulunamadı.";
                                    break;
                                }
                                else
                                {
                                    string malzeme = transactions[j].SelectSingleNode("MASTER_DEF").InnerText;
                                    string miktar = transactions[j].SelectSingleNode("QUANTITY").InnerText;
                                    string nettoplamfiyat = transactions[j].SelectSingleNode("TOTAL_NET").InnerText.Replace(".", ",");
                                    decimal netfiyat = Convert.ToDecimal(nettoplamfiyat) / Convert.ToInt32(miktar);
                                    IadelerDetay iadedetay = new IadelerDetay(iade.pkIadeID, Convert.ToInt32(itemref), malzeme, Convert.ToInt32(miktar), netfiyat);
                                    iadedetay.DoInsert();
                                    IadelerDetayFiy fiy = new IadelerDetayFiy(iadedetay.pkIadeDetayID, netfiyat * Convert.ToInt32(miktar), 0, tarih, "Bimat", DateTime.MinValue, string.Empty);
                                    fiy.DoInsert();
                                }
                            }
                            else if (type == "2") // iskontolara gerek yok
                            {
                            }
                        }

                        if (hataliurun == string.Empty) // bütün ürünler vardıysa eklendiyse
                        {
                            IadelerQ.WriteQuantumNo(iade.pkIadeID, docnumber, docnumber);
                            IadeHareketleri.DoInsert(iade.pkIadeID, 6, musteri.strAd + " " + musteri.strSoyad, "xml");

                            aktarilan += docnumber + ".";
                        }
                    }
                    else
                    {
                        hatali += docnumber + ": " + muskod + " kodlu müşteri bulunamadı.";
                    }
                }
            }

            donendeger = aktarilan + "." + hatali;
            return donendeger;
        }





        public XmlDocument PostXml(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime baslangic = DateTime.Now;

            string xml = icerik.OuterXml;
            DataSet ds = new DataSet();
            ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            DataTable dt = ds.Tables[0];

            donendeger = BayiVeriYaz(dt, Bayikod, Satis, YilAd, Yil, AyAd, Ay);

            SAPs.BayiLogYaz("bayi win servis xml " + Satis, true, Bayikod + " nolu bayi " + Yil + "-" + Ay + " dönemi. Gelen satır: " + dt.Rows.Count.ToString(), baslangic, DateTime.Now);

            return donendeger;
        }

        public XmlDocument PostXml2(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string BasYil, string BitYil, string AyAd, string BasAy, string BitAy)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime baslangic = DateTime.Now;

            string xml = icerik.OuterXml;
            DataSet ds = new DataSet();
            ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            DataTable dt = ds.Tables[0];

            donendeger = BayiVeriYaz(dt, Bayikod, Satis, YilAd, BasYil, BitYil, AyAd, BasAy, BitAy);

            SAPs.BayiLogYaz("bayi win servis xml " + Satis, true, Bayikod + " nolu bayi " + BasYil + "-" + BasAy + " : " + BitYil + "-" + BitAy + " arası. Gelen satır: " + dt.Rows.Count.ToString(), baslangic, DateTime.Now);

            return donendeger;
        }

        private XmlDocument BayiVeriYaz(DataTable dt, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay)
        {
            XmlDocument donendeger = new XmlDocument();

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
                {
                    DateTime silmebas = Convert.ToDateTime("01." + Ay + "." + Yil).AddMonths(-3);
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,CONVERT(nvarchar(50)," + AyAd + ") + '.01.' + CONVERT(nvarchar(50)," + YilAd + ")) >= '" + silmebas.Month + ".01." + silmebas.Year + "'");
                }
                else
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
            }


            if (DisVeri.TabloYaz(tabloadi, dt, YilAd, Yil, AyAd, Ay, false))
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>true</basarili></sonuc>");
            else
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>false</basarili></sonuc>");

            return donendeger;
        }

        private XmlDocument BayiVeriYaz(DataTable dt, string Bayikod, string Satis, string YilAd, string BasYil, string BitYil, string AyAd, string BasAy, string BitAy)
        {
            XmlDocument donendeger = new XmlDocument();

            string tabloadi = "tbl_" + Bayikod + "_" + Satis;
            if (Bayikod == "1071593" || Bayikod == "1052689" || Bayikod == "1018538") // kaan, peker, yılmaz // buraya girmeyecek
            {
                if (Satis == "Satis")
                {
                    DateTime bas = Convert.ToDateTime(BitYil + "." + (BitAy.Length > 1 ? BitAy : "0" + BitAy) + ".01");
                    DisVeri.ExecNQwp("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,[CEKIM_TARIH]) >= @TARIH", new ArrayList() { "TARIH" }, new object[] { bas });
                }
                else
                {
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
                }
            }
            else
            {
                if (Satis == "Satis")
                {
                    DateTime silmebas = Convert.ToDateTime("01." + BasAy + "." + BasYil);
                    DateTime silmebit = Convert.ToDateTime("01." + BitAy + "." + BitYil).AddMonths(1);
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,CONVERT(nvarchar(50)," + AyAd + ") + '.01.' + CONVERT(nvarchar(50)," + YilAd + ")) >= '" + silmebas.Month + ".01." + silmebas.Year + "'" + " AND CONVERT(datetime,CONVERT(nvarchar(50)," + AyAd + ") + '.01.' + CONVERT(nvarchar(50)," + YilAd + ")) < '" + silmebit.Month + ".01." + silmebit.Year + "'");
                }
                else
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
            }


            if (DisVeri.TabloYaz(tabloadi, dt, YilAd, BitYil, AyAd, BitAy, false))
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>true</basarili><satirsayisi>" + dt.Rows.Count.ToString() + "</satirsayisi></sonuc>");
            else
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>false</basarili><satirsayisi>0</satirsayisi></sonuc>");

            return donendeger;
        }





        private List<XmlSer> XmlAttrInit(List<Type> tip)
        {
            List<XmlSer> returnValue = new List<XmlSer>();

            for (int i = 0; i < tip.Count; i++)
            {
                foreach (PropertyInfo PropInfo in tip[i].GetProperties())
                {
                    if (PropInfo.GetCustomAttributes(false).Length > 1)
                    {
                        returnValue.Add(new XmlSer() { name = PropInfo.Name, tip = tip[i] });
                    }
                }
            }

            return returnValue;
        }

        private XmlAttributeOverrides GetXMLAttributeOverrides(List<XmlSer> propertiesToInlcudeInOrder)
        {
            var allXMLAttribueOverrides = new XmlAttributeOverrides();

            for (int i = 0; i < propertiesToInlcudeInOrder.Count; i++)
            {
                var attrs = new XmlAttributes();
                attrs.XmlElements.Add(new XmlElementAttribute(propertiesToInlcudeInOrder[i].name));
                allXMLAttribueOverrides.Add(propertiesToInlcudeInOrder[i].tip, propertiesToInlcudeInOrder[i].name, attrs);
            }

            return allXMLAttribueOverrides;
        }
    }

    public class XmlSer
    {
        public Type tip { get; set; }
        public string name { get; set; }
    }
}
