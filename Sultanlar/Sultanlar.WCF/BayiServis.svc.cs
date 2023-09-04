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
using System.ServiceModel.Web;
using ExcelLibrary.SpreadSheet;

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
                siparis.saticino = dt.Rows[i]["saticino"].ToString();

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
                siparis.saticino = dt.Rows[i]["saticino"].ToString();

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

        public Stream Fatura2Logo(string apikey, string sipler)
        {
            XmlDocument donendeger = new XmlDocument();

            /*if (apikey != "F7FF8316-3C41-482B-BB06-901D0E4C38A7")
                return donendeger;*/

            string[] sips = sipler.Split('.');

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Entitize;
            settings.Indent = true;
            settings.IndentChars = "";
            //settings.NewLineOnAttributes = true;

            BimatFaturalarDis faturalar = FaturaGetirLogo(sips, apikey, DateTime.Now, DateTime.Now);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(BimatSiparisDis), typeof(BimatSiparisDisDetay), typeof(BimatSiparisDisDispatch), typeof(BimatSiparisDisPayment), typeof(BimatSiparisDisIntel), 
                    typeof(BimatSiparisDisOkcInfo), typeof(BimatSiparisDisCmpInfo) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(BimatFaturalarDis), allXMLAttribueOverrides);

            /*TextWriter TW = new StringWriter();
            XmlWriter XW = XmlWriter.Create(TW, settings);
            MySerializer.Serialize(XW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString().Replace("><", ">\r\n<"));*/

            MemoryStream ms = new MemoryStream();
            TextWriter TW = new StreamWriter(ms, Encoding.GetEncoding("ISO-8859-9"));
            XmlWriter XW = XmlWriter.Create(TW, settings);
            MySerializer.Serialize(XW, faturalar, xsn);

            ms.Position = 0;

            return ms;
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

        #region Dia
        public XmlDocument FaturaDia(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            DiaFaturalarDis faturalar = FaturaGetirDia(new string[0], apikey, bas, bit);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xsn.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xsn.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");

            /*var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(DiaSiparisDis), typeof(DiaSiparisDisDetay), typeof(DiaTaxScheme), typeof(DiaTaxSubtotal) }
                ));*/
            XmlSerializer MySerializer = new XmlSerializer(typeof(DiaFaturalarDis)); //allXMLAttribueOverrides

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        public XmlDocument Fatura2Dia(string apikey, string sipler)
        {
            XmlDocument donendeger = new XmlDocument();

            string[] sips = sipler.Split('.');

            if (sips.Length == 1)
            {

            }

            DiaFaturalarDis faturalar = FaturaGetirDia(sips, apikey, DateTime.Now, DateTime.Now);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xsn.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xsn.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            XmlSerializer MySerializer = new XmlSerializer(typeof(DiaFaturalarDis));

            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }

        private DiaFaturalarDis FaturaGetirDia(string[] SiparisNo, string apikey, DateTime baslangic, DateTime bitis)
        {
            DiaFaturalarDis faturalar = new DiaFaturalarDis();

            DataTable dt = new DataTable();
            if (SiparisNo.Length == 0)
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), new string[0], baslangic, bitis);
            else
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), SiparisNo, baslangic, bitis);

            faturalar.Faturalar = new List<DiaSiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]);

                DiaSiparisDis siparis = new DiaSiparisDis();

                double topfiyat = 0;
                double topiskonto = 0;
                double topkdv = 0;
                double topnet = 0;
                double topnetkdv = 0;

                siparis.UBLVersionID = "2.1";
                siparis.CustomizationID = "TR1.2";
                siparis.ProfileID = "TICARIFATURA";
                siparis.CopyIndicator = "false";
                siparis.InvoiceTypeCode = "SATIS";
                siparis.DocumentCurrencyCode = "TRY";
                siparis.ID = dt.Rows[i]["belgeno"].ToString();
                siparis.UUID = Guid.NewGuid().ToString();
                //siparis.carino2 = dt.Rows[i]["carino2"].ToString();
                siparis.IssueDate = tarih.ToString("yyyy'-'MM'-'dd");
                siparis.IssueTime = tarih.ToShortTimeString();
                siparis.Note = dt.Rows[i]["aciklama"].ToString();
                siparis.BuyerCustomerPartys = new DiaBuyerCustomerParty();
                siparis.BuyerCustomerPartys.Party = new DiaParty();
                siparis.BuyerCustomerPartys.Party.PartyIdentification = new DiaPartyIdentification();
                siparis.BuyerCustomerPartys.Party.PartyIdentification.schemeID = "ID";
                siparis.BuyerCustomerPartys.Party.PartyIdentification.ID = new DiaPartyID();
                siparis.BuyerCustomerPartys.Party.PartyIdentification.ID.ID = dt.Rows[i]["carino2"].ToString();

                DataTable dt1 = DetayVeriGetir(false, false, dt.Rows[i]["sipno"].ToString());
                siparis.LineCountNumeric = dt1.Rows.Count.ToString();
                siparis.InvoiceLines = new List<DiaSiparisDisDetay>();
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

                    DiaSiparisDisDetay detay = new DiaSiparisDisDetay();
                    detay.ID = (j + 1).ToString();
                    detay.Note = new string[2];
                    detay.Note[0] = "Birim1: Adet";
                    detay.Note[1] = "Miktar1: 1.00";
                    detay.InvoicedQuantity = new DiaInvoicedQuantity();
                    detay.InvoicedQuantity.InvoicedQuantity = dt1.Rows[j]["miktartur"].ToString() == "KI" ? (Convert.ToInt32(dt1.Rows[j]["miktar"]) * Convert.ToInt32(dt1.Rows[j]["koli"])).ToString() : dt1.Rows[j]["miktar"].ToString();
                    detay.InvoicedQuantity.unitCode = "NIU";

                    detay.LineExtensionAmount = new DiaLineExtensionAmount();
                    detay.LineExtensionAmount.LineExtensionAmount = toplamnet.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.LineExtensionAmount.currencyID = "TRY";

                    detay.TaxTotal = new DiaTaxTotal();
                    detay.TaxTotal.TaxAmount = new DiaTaxAmount();
                    detay.TaxTotal.TaxAmount.TaxAmount = toplamkdv.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.TaxTotal.TaxAmount.currencyID = "TRY";

                    detay.TaxTotal.TaxSubtotal = new DiaTaxSubtotal();
                    detay.TaxTotal.TaxSubtotal.CalculationSequenceNumeric = "1";
                    detay.TaxTotal.TaxSubtotal.TaxableAmount = detay.LineExtensionAmount.LineExtensionAmount;
                    detay.TaxTotal.TaxSubtotal.TaxAmount = detay.TaxTotal.TaxAmount;
                    detay.TaxTotal.TaxSubtotal.Percent = dt1.Rows[j]["kdv"].ToString();
                    detay.TaxTotal.TaxSubtotal.TaxCategory = new DiaTaxCategory();
                    detay.TaxTotal.TaxSubtotal.TaxCategory.DiaTaxScheme = new DiaTaxScheme();
                    detay.TaxTotal.TaxSubtotal.TaxCategory.DiaTaxScheme.Name = "KDV";
                    detay.TaxTotal.TaxSubtotal.TaxCategory.DiaTaxScheme.TaxTypeCode = "0015";
                    detay.Item = new DiaItem();
                    detay.Item.Description = dt1.Rows[j]["malno"].ToString();
                    detay.Item.Name = dt1.Rows[j]["malzeme"].ToString();
                    detay.Price = new DiaPrice();

                    detay.Price.PriceAmount = new DiaPriceAmount();
                    detay.Price.PriceAmount.PriceAmount = detay.LineExtensionAmount.LineExtensionAmount;
                    detay.Price.PriceAmount.currencyID = "TRY";

                    siparis.InvoiceLines.Add(detay);
                }

                faturalar.Faturalar.Add(siparis);
            }

            return faturalar;
        }
        #endregion

        #region logogo
        public XmlDocument FaturaLogoGo(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            LogoGoFaturalarDis faturalar = FaturaGetirLogoGo(new string[0], apikey, bas, bit);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            //xsn.Add("g", "http://base.google.com/ns/1.0");
            xsn.Add("", "");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(LogoGoSiparisDis), typeof(LogoGoSiparisDisDetay) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(LogoGoFaturalarDis), allXMLAttribueOverrides);

            MemoryStream ms = new MemoryStream();
            TextWriter TW = new StreamWriter(ms, Encoding.Default);
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(Encoding.Default.GetString(ms.ToArray()));

            //XmlDeclaration xmldecl = donendeger.CreateXmlDeclaration("1.0", "utf-8", null);
            //donendeger.InsertBefore(xmldecl, donendeger.FirstChild);

            return donendeger;
        }

        public Stream Fatura2LogoGo(string apikey, string sipler)
        {
            XmlDocument donendeger = new XmlDocument();
            string[] sips = sipler.Split('.');

            LogoGoFaturalarDis faturalar = FaturaGetirLogoGo(sips, apikey, DateTime.Now, DateTime.Now);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            //xsn.Add("g", "http://base.google.com/ns/1.0");
            xsn.Add("", "");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(LogoGoSiparisDis), typeof(LogoGoSiparisDisDetay) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(LogoGoFaturalarDis), allXMLAttribueOverrides);

            /*TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(TW.ToString());*/

            MemoryStream ms = new MemoryStream();
            TextWriter TW = new StreamWriter(ms, Encoding.GetEncoding("ISO-8859-9"));
            MySerializer.Serialize(TW, faturalar, xsn);
            //donendeger.LoadXml(Encoding.Default.GetString(ms.ToArray()));

            ms.Position = 0;

            /*string encodedText = Convert.ToBase64String(ms.ToArray());
            string tekst = Encoding.UTF8.GetString(Convert.FromBase64String(encodedText)).Replace("Ü", "UUUUU").Replace("Ğ", "GGGGG").Replace("Ş", "SSSSS").Replace("İ", "IIIII").Replace("Ö", "OOOOO").Replace("Ç", "CCCCC");

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(tekst);
            writer.Flush();
            stream.Position = 0;*/

            return ms;
        }



        private LogoGoFaturalarDis FaturaGetirLogoGo(string[] SiparisNo, string apikey, DateTime baslangic, DateTime bitis)
        {
            LogoGoFaturalarDis faturalar = new LogoGoFaturalarDis();

            DataTable dt = new DataTable();
            if (SiparisNo.Length == 0)
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), new string[0], baslangic, bitis);
            else
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), SiparisNo, baslangic, bitis);

            faturalar.Faturalar = new List<LogoGoSiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]);
                DateTime tarihSimdi = DateTime.Now;

                LogoGoSiparisDis siparis = new LogoGoSiparisDis();
                siparis.DBOP = "INS";

                double topfiyat = 0;
                double topiskonto = 0;
                double topkdv = 0;
                double topnet = 0;
                double topnetkdv = 0;

                siparis.TYPE = "8";
                siparis.DOC_NUMBER = dt.Rows[i]["belgeno"].ToString();
                siparis.NUMBER = dt.Rows[i]["belgeno"].ToString();
                siparis.NOTES1 = dt.Rows[i]["aciklama"].ToString();
                siparis.ARP_CODE = dt.Rows[i]["carino2"].ToString();
                siparis.SALESMAN_CODE = dt.Rows[i]["saticino"].ToString();
                siparis.DATE = tarih.ToString("dd'.'MM'.'yyyy");
                siparis.DOC_DATE = tarihSimdi.ToString("dd'.'MM'.'yyyy");

                LogoGoSiparisDisDispatch dispatch = new LogoGoSiparisDisDispatch();
                dispatch.DATE = siparis.DATE;
                dispatch.DOC_NUMBER = siparis.DOC_NUMBER;
                dispatch.ARP_CODE = siparis.ARP_CODE;
                dispatch.DOC_DATE = siparis.DOC_DATE;
                dispatch.NOTES1 = siparis.NOTES1;
                dispatch.NUMBER = siparis.NUMBER;
                dispatch.TYPE = siparis.TYPE;

                siparis.DISPATCHES = new List<LogoGoSiparisDisDispatch>();
                siparis.DISPATCHES.Add(dispatch);

                BayiOzelIslemLogoGo(apikey, siparis, dt.Rows[i]);

                DataTable dt1 = DetayVeriGetir(siparis.TYPE == "3", false, dt.Rows[i]["sipno"].ToString());
                siparis.TRANSACTIONS = new List<LogoGoSiparisDisDetay>();
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

                    LogoGoSiparisDisDetay detay = new LogoGoSiparisDisDetay();
                    detay.TYPE = "0";
                    detay.MASTER_CODE = dt1.Rows[j]["mastercode"].ToString();
                    detay.QUANTITY = dt1.Rows[j]["miktartur"].ToString() == "KI" ? (miktar * Convert.ToInt32(dt1.Rows[j]["koli"])).ToString() : miktar.ToString();
                    detay.DISCOUNT_RATE = "";
                    detay.PRICE = fiyat.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.UNIT_CODE = dt1.Rows[j]["birimset"].ToString();
                    detay.VAT_RATE = kdvoran.ToString();
                    detay.DATA_REFERENCE = (j + 1).ToString();

                    BayiOzelIslemLogoGo(apikey, detay);

                    siparis.TRANSACTIONS.Add(detay);

                    for (int k = 0; k < 4; k++)
                    {
                        LogoGoSiparisDisDetay detayi = new LogoGoSiparisDisDetay();
                        detayi.TYPE = "2";
                        detayi.DISCOUNT_RATE = (k == 0 ? isk1.ToString("N4") : k == 1 ? isk2.ToString("N4") : k == 2 ? isk3.ToString("N4") : k == 3 ? isk4.ToString("N4") : "0").Replace(".", "").Replace(",", ".");
                        detayi.PARENTLNREF = detay.DATA_REFERENCE;
                        siparis.TRANSACTIONS.Add(detayi);
                    }
                }

                faturalar.Faturalar.Add(siparis);
            }

            return faturalar;
        }

        private void BayiOzelIslemLogoGo(string apikey, LogoGoSiparisDis siparis, DataRow drow)
        {
            if (apikey == "14EAC406-F114-492E-9E81-7DD6FCA62E8B") //kural tedarik
            {
                siparis.TRADING_GRP = "01";
                siparis.PAYMENT_CODE = "V30";
                siparis.AUXIL_CODE = "SULTANLAR";
                siparis.ARP_CODE = drow["carino3"].ToString();
            }
            else if (apikey == "8DF4A3A1-737E-4D07-AA85-0A99C92A3F16") //akgönül
            {
                siparis.PAYMENT_CODE = "30";
            }
        }

        private void BayiOzelIslemLogoGo(string apikey, LogoGoSiparisDisDetay detay)
        {
            if (apikey == "14EAC406-F114-492E-9E81-7DD6FCA62E8B") //kural tedarik
            {
                detay.PAYMENT_CODE = "V30";
            }
            else if (apikey == "8DF4A3A1-737E-4D07-AA85-0A99C92A3F16") //akgönül
            {
                detay.PAYMENT_CODE = "30";
            }
        }
        #endregion

        #region netsim
        public XmlDocument FaturaNetsim(string apikey, string baslangic, string bitis)
        {
            XmlDocument donendeger = new XmlDocument();

            DateTime bas = Convert.ToDateTime(baslangic);
            DateTime bit = Convert.ToDateTime(bitis);

            LogoGoFaturalarDis faturalar = FaturaGetirNetsim(new string[0], apikey, bas, bit);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(LogoGoSiparisDis), typeof(LogoGoSiparisDisDetay) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(LogoGoFaturalarDis), allXMLAttribueOverrides);

            MemoryStream ms = new MemoryStream();
            TextWriter TW = new StreamWriter(ms, Encoding.Default);
            MySerializer.Serialize(TW, faturalar, xsn);
            donendeger.LoadXml(Encoding.Default.GetString(ms.ToArray()));



            var excel = ListToExcel(faturalar.Faturalar);



            return donendeger;
        }

        public Microsoft.Office.Interop.Excel.Application ListToExcel(List<LogoGoSiparisDis> list)
        {
            //start excel
            Microsoft.Office.Interop.Excel.Application excapp = new Microsoft.Office.Interop.Excel.Application();

            //if you want to make excel visible           
            excapp.Visible = true;

            //create a blank workbook
            var workbook = excapp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

            //or open one - this is no pleasant, but yue're probably interested in the first parameter
            /*string workbookPath = "C:\test.xls";
            var workbook = excapp.Workbooks.Open(workbookPath,
                0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);*/

            //Not done yet. You have to work on a specific sheet - note the cast
            //You may not have any sheets at all. Then you have to add one with NsExcel.Worksheet.Add()
            var sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1]; //indexing starts from 1

            //do something usefull: you select now an individual cell
            /*var range = sheet.get_Range("A1", "A1");
            range.Value2 = "test"; //Value2 is not a typo
            */

            //now the list
            string cellName;
            int counter = 1;
            foreach (var item in list)
            {
                cellName = "A" + counter.ToString();
                var range = sheet.get_Range(cellName, cellName);
                range.Value2 = item.ToString();
                ++counter;
            }

            //you've probably got the point by now, so a detailed explanation about workbook.SaveAs and workbook.Close is not necessary
            //important: if you did not make excel visible terminating your application will terminate excel as well - I tested it
            //but if you did it - to be honest - I don't know how to close the main excel window - maybee somewhere around excapp.Windows or excapp.ActiveWindow
            
            return excapp;
        }

        public Stream Fatura2Netsim(string apikey, string sipler)
        {
            /*XmlDocument donendeger = new XmlDocument();
            string[] sips = sipler.Split('.');

            LogoGoFaturalarDis faturalar = FaturaGetirNetsim(sips, apikey, DateTime.Now, DateTime.Now);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "");

            var allXMLAttribueOverrides = GetXMLAttributeOverrides(XmlAttrInit(
                new List<Type>() { typeof(LogoGoSiparisDis), typeof(LogoGoSiparisDisDetay) }
                ));
            XmlSerializer MySerializer = new XmlSerializer(typeof(LogoGoFaturalarDis), allXMLAttribueOverrides);*/

            MemoryStream ms = new MemoryStream();
            /*TextWriter TW = new StreamWriter(ms, Encoding.GetEncoding("ISO-8859-9"));
            MySerializer.Serialize(TW, faturalar, xsn);

            ms.Position = 0;*/



            string[] sips = sipler.Split('.');
            DataTable dt = BaslikVeriGetir(false, Guid.Parse(apikey), sips, DateTime.Now, DateTime.Now);
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Fatura");
            worksheet.Cells[0, 0] = new Cell("BELGENO"); worksheet.Cells[0, 1] = new Cell("TARIH"); worksheet.Cells[0, 2] = new Cell("CARIKOD"); worksheet.Cells[0, 3] = new Cell("CARI"); 
            worksheet.Cells[0, 4] = new Cell("MALKOD"); worksheet.Cells[0, 5] = new Cell("MALZEME"); worksheet.Cells[0, 6] = new Cell("MIKTAR");
            worksheet.Cells[0, 7] = new Cell("FIYAT"); worksheet.Cells[0, 8] = new Cell("ISK1"); worksheet.Cells[0, 9] = new Cell("ISK2"); worksheet.Cells[0, 10] = new Cell("ISK3"); worksheet.Cells[0, 11] = new Cell("ISK4");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string belgeno = dt.Rows[i]["belgeno"].ToString();
                string tarih = dt.Rows[i]["tarih"].ToString();
                string carino = dt.Rows[i]["carino2"].ToString();
                string cari = dt.Rows[i]["cari"].ToString();
                DataTable dtDetay = DetayVeriGetir(false, false, dt.Rows[i]["sipno"].ToString());
                for (int j = 0; j < dtDetay.Rows.Count; j++)
                {
                    worksheet.Cells[i + j + 1, 0] = new Cell(belgeno);
                    worksheet.Cells[i + j + 1, 1] = new Cell(Convert.ToDateTime(tarih).ToShortDateString(), new CellFormat(CellFormatType.Date, ""));
                    worksheet.Cells[i + j + 1, 2] = new Cell(carino, new CellFormat(CellFormatType.Text, ""));
                    worksheet.Cells[i + j + 1, 3] = new Cell(cari);
                    worksheet.Cells[i + j + 1, 4] = new Cell(dtDetay.Rows[j]["malno"].ToString(), new CellFormat(CellFormatType.Text, ""));
                    worksheet.Cells[i + j + 1, 5] = new Cell(dtDetay.Rows[j]["malzeme"].ToString());
                    worksheet.Cells[i + j + 1, 6] = new Cell(Convert.ToInt32(dtDetay.Rows[j]["miktar"]), new CellFormat(CellFormatType.Number, ""));
                    worksheet.Cells[i + j + 1, 7] = new Cell(Convert.ToDouble(dtDetay.Rows[j]["fiyat"]), new CellFormat(CellFormatType.Number, ""));
                    worksheet.Cells[i + j + 1, 8] = new Cell(Convert.ToDouble(dtDetay.Rows[j]["isk1"]), new CellFormat(CellFormatType.Number, ""));
                    worksheet.Cells[i + j + 1, 9] = new Cell(Convert.ToDouble(dtDetay.Rows[j]["isk2"]), new CellFormat(CellFormatType.Number, ""));
                    worksheet.Cells[i + j + 1, 10] = new Cell(Convert.ToDouble(dtDetay.Rows[j]["isk3"]), new CellFormat(CellFormatType.Number, ""));
                    worksheet.Cells[i + j + 1, 11] = new Cell(Convert.ToDouble(dtDetay.Rows[j]["isk4"]), new CellFormat(CellFormatType.Number, ""));
                }
            }

            //worksheet.Cells[0, 1] = new Cell((short)1); worksheet.Cells[2, 0] = new Cell(9999999); worksheet.Cells[3, 3] = new Cell((decimal)3.45); worksheet.Cells[2, 2] = new Cell("Text string"); 
            //worksheet.Cells[2, 4] = new Cell("Second string"); worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00"); worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY-MM-DD"); 
            //worksheet.Cells.ColumnWidth[0, 1] = 3000; 
            workbook.Worksheets.Add(worksheet);
            workbook.SaveToStream(ms);
            ms.Position = 0;


            /*StreamWriter excelDoc = new StreamWriter(ms);

            StringBuilder ExcelXMLbasi = new StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");

            excelDoc.Write(ExcelXMLbasi.ToString());
            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"220.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");


            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Siparişi Giren:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">asd</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Cari Hesap:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">dsa</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">2</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş Oluşturma Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">01.01.2023</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş Onay Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">01.01.2023</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">acik</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">::: ÜRÜNLER :::</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Barkod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün Açıklama</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">KDV</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Miktar</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt Fiyat</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 1</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 2</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 3</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 4</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam + KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            ms.Seek(0, SeekOrigin.Begin);*/

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", $"attachment; filename=sultanlar-" + sips[0] + ".xls");

            return ms;
        }

        private LogoGoFaturalarDis FaturaGetirNetsim(string[] SiparisNo, string apikey, DateTime baslangic, DateTime bitis)
        {
            LogoGoFaturalarDis faturalar = new LogoGoFaturalarDis();

            DataTable dt = new DataTable();
            if (SiparisNo.Length == 0)
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), new string[0], baslangic, bitis);
            else
                dt = BaslikVeriGetir(false, Guid.Parse(apikey), SiparisNo, baslangic, bitis);

            faturalar.Faturalar = new List<LogoGoSiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]);
                DateTime tarihSimdi = DateTime.Now;

                LogoGoSiparisDis siparis = new LogoGoSiparisDis();
                siparis.DBOP = "INS";

                double topfiyat = 0;
                double topiskonto = 0;
                double topkdv = 0;
                double topnet = 0;
                double topnetkdv = 0;

                siparis.TYPE = "8";
                siparis.DOC_NUMBER = dt.Rows[i]["belgeno"].ToString();
                siparis.NUMBER = dt.Rows[i]["belgeno"].ToString();
                siparis.NOTES1 = dt.Rows[i]["aciklama"].ToString();
                siparis.ARP_CODE = dt.Rows[i]["carino2"].ToString();
                siparis.SALESMAN_CODE = dt.Rows[i]["saticino"].ToString();
                siparis.DATE = tarih.ToString("dd'.'MM'.'yyyy");
                siparis.DOC_DATE = tarihSimdi.ToString("dd'.'MM'.'yyyy");

                BayiOzelIslemLogoGo(apikey, siparis, dt.Rows[i]);

                DataTable dt1 = DetayVeriGetir(siparis.TYPE == "3", false, dt.Rows[i]["sipno"].ToString());
                siparis.TRANSACTIONS = new List<LogoGoSiparisDisDetay>();
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

                    LogoGoSiparisDisDetay detay = new LogoGoSiparisDisDetay();
                    detay.TYPE = "0";
                    detay.MASTER_CODE = dt1.Rows[j]["mastercode"].ToString();
                    detay.QUANTITY = dt1.Rows[j]["miktartur"].ToString() == "KI" ? (miktar * Convert.ToInt32(dt1.Rows[j]["koli"])).ToString() : miktar.ToString();
                    detay.DISCOUNT_RATE = "";
                    detay.PRICE = fiyat.ToString("N4").Replace(".", "").Replace(",", ".");
                    detay.UNIT_CODE = "ADET";
                    detay.VAT_RATE = kdvoran.ToString();
                    detay.DATA_REFERENCE = (j + 1).ToString();

                    BayiOzelIslemLogoGo(apikey, detay);

                    siparis.TRANSACTIONS.Add(detay);

                    for (int k = 0; k < 4; k++)
                    {
                        LogoGoSiparisDisDetay detayi = new LogoGoSiparisDisDetay();
                        detayi.TYPE = "2";
                        detayi.DISCOUNT_RATE = (k == 0 ? isk1.ToString("N4") : k == 1 ? isk2.ToString("N4") : k == 2 ? isk3.ToString("N4") : k == 3 ? isk4.ToString("N4") : "0").Replace(".", "").Replace(",", ".");
                        detayi.PARENTLNREF = detay.DATA_REFERENCE;
                        siparis.TRANSACTIONS.Add(detayi);
                    }
                }

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
CASE WHEN TKSREF = 5 THEN (SELECT CODE FROM DisVeri.dbo.CARI_BIRLESIK_OTOMASYON WHERE LOGICALREF = (SELECT [MUS KOD] FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP))  ELSE (SELECT CODE FROM DisVeri.dbo.CARI_BIRLESIK_OTOMASYON WHERE LOGICALREF = [Web-Musteri-1].[MUS KOD]) END AS carino3,
CASE WHEN TKSREF = 5 THEN (SELECT MUSTERI FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE SUBE END AS cari, " + 
(siparis ? "dtOlusmaTarihi" : "FATTAR") + " AS tarih," +
(siparis ? "'False'" : "IPTAL") + " AS iptal," +
@"28 AS vade
,ISNULL(strKod,'') AS saticino
,dtOlusmaTarihi as siptar
,CASE WHEN TKSREF = 5 THEN 'Şube: ' + SUBE + ' (' + CONVERT(nvarchar(50),[Web-Musteri-1].SMREF) + ') ' ELSE '' END + REPLACE(SUBSTRING(tblINTERNET_Siparisler.strAciklama, CHARINDEX(';;;', tblINTERNET_Siparisler.strAciklama) + 3, 500),SUBSTRING(tblINTERNET_Siparisler.strAciklama, CHARINDEX(';;;', tblINTERNET_Siparisler.strAciklama, CHARINDEX(';;;', tblINTERNET_Siparisler.strAciklama) + 3), 500),'') AS aciklama
FROM tblINTERNET_Siparisler
INNER JOIN (SELECT TIP,GMREF,SMREF,[MUS KOD],SUBE,NETTOP FROM [Web-Musteri-1]) AS [Web-Musteri-1] ON tblINTERNET_Siparisler.SMREF = [Web-Musteri-1].SMREF AND tblINTERNET_Siparisler.TKSREF = [Web-Musteri-1].TIP
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = bintSiparisDetayID
INNER JOIN tblINTERNET_SiparislerQ ON pkSiparisID = tblINTERNET_SiparislerQ.intSiparisID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-1].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
INNER JOIN tblINTERNET_Musteriler ON intMusteriID = pkMusteriID
LEFT OUTER JOIN [Web-Musteri-TP_Personeller] ON pkID = intSLSREF - 1000000000
WHERE tblINTERNET_SiparislerDetaySevk.intMiktar > 0 AND blAktarildi = 'True' AND API = '" + apikey.ToString() + "' AND " + 
where + 

(siparis ? @"UNION

SELECT DISTINCT pkIadeID AS sipno,3 AS tur, QUANTUMNO AS belgeno, 
CASE WHEN TKSREF = 5 THEN [Web-Musteri-1].NETTOP ELSE [Web-Musteri-1].SMREF END AS carino, 
CASE WHEN TKSREF = 5 THEN (SELECT [MUS KOD] FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE [Web-Musteri-1].[MUS KOD] END AS carino2, 
CASE WHEN TKSREF = 5 THEN (SELECT MUSTERI FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-1].NETTOP) ELSE SUBE END AS cari, 
dtOlusmaTarihi AS tarih,'False' AS iptal,28 AS vade
,ISNULL(strKod,'') AS saticino
,dtOlusmaTarihi as siptar
,CASE WHEN TKSREF = 5 THEN 'Şube: ' + SUBE + ' (' + CONVERT(nvarchar(50),[Web-Musteri-1].SMREF) + ') ' ELSE '' END + REPLACE(SUBSTRING(tblINTERNET_Iadeler.strAciklama, CHARINDEX(';;;', tblINTERNET_Iadeler.strAciklama) + 3, 500),SUBSTRING(tblINTERNET_Iadeler.strAciklama, CHARINDEX(';;;', tblINTERNET_Iadeler.strAciklama, CHARINDEX(';;;', tblINTERNET_Iadeler.strAciklama) + 3), 500),'') AS aciklama
FROM tblINTERNET_Iadeler
INNER JOIN (SELECT TIP,GMREF,SMREF,[MUS KOD],SUBE,NETTOP FROM [Web-Musteri-1]) AS [Web-Musteri-1] ON tblINTERNET_Iadeler.SMREF = [Web-Musteri-1].SMREF AND tblINTERNET_Iadeler.TKSREF = [Web-Musteri-1].TIP
INNER JOIN tblINTERNET_IadelerDetay ON pkIadeID = intIadeID
INNER JOIN tblINTERNET_IadelerQ ON pkIadeID = tblINTERNET_IadelerQ.intIadeID
INNER JOIN [Web-Musteri-TP-Bayikodlar] ON [Web-Musteri-1].GMREF = [Web-Musteri-TP-Bayikodlar].GMREF
INNER JOIN tblINTERNET_Musteriler ON intMusteriID = pkMusteriID
LEFT OUTER JOIN [Web-Musteri-TP_Personeller] ON pkID = intSLSREF - 1000000000
WHERE TKSREF != 1 AND API = '" + apikey.ToString() + "' AND " +
iadewhere
: "") +

"ORDER BY belgeno DESC", CommandType.Text, paramnames, paramvalues, "SiparisDetay");
            return dt;
        }

        private DataTable DetayVeriGetir(bool IadeMi, bool SiparisMi, string SiparisID)
        {
            string where = "AND pkSiparisID = " + SiparisID;
            string sorgu = "SELECT pkSiparisDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, " + (SiparisMi ? "tblINTERNET_SiparislerDetay.intMiktar" : "tblINTERNET_SiparislerDetaySevk.intMiktar") + @" as miktar, strMiktarTur as miktartur, ISK1 as isk1, ISK2 as isk2, ISK3 as isk3, ISK4 as isk4, FIYAT AS fiyat,KDV
,(SELECT MASTER_CODE FROM DisVeri.dbo.STOK_BIRLESIK_OTOMASYON WHERE BAYIKOD = (SELECT DISTINCT GMREF FROM [Web-Musteri-1] WHERE SMREF = tblINTERNET_Siparisler.SMREF AND TIP = tblINTERNET_Siparisler.TKSREF) AND [URT_KOD] = intUrunID) AS mastercode
,(SELECT BIRIMSET FROM DisVeri.dbo.STOK_BIRLESIK_OTOMASYON WHERE BAYIKOD = (SELECT DISTINCT GMREF FROM [Web-Musteri-1] WHERE SMREF = tblINTERNET_Siparisler.SMREF AND TIP = tblINTERNET_Siparisler.TKSREF) AND [URT_KOD] = intUrunID) AS birimset
FROM tblINTERNET_Siparisler
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = tblINTERNET_SiparislerDetaySevk.bintSiparisDetayID
LEFT OUTER JOIN tblINTERNET_SiparislerDetayISK ON pkSiparisDetayID = tblINTERNET_SiparislerDetayISK.bintSiparisDetayID WHERE tblINTERNET_SiparislerDetaySevk.intMiktar > 0  AND sintFiyatTipiID = 2" + where +
" UNION ALL SELECT pkSiparisDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, " + (SiparisMi ? "tblINTERNET_SiparislerDetay.intMiktar" : "tblINTERNET_SiparislerDetaySevk.intMiktar") + @" as miktar, strMiktarTur as miktartur, 0 as isk1, 0 as isk2, 0 as isk3, 0 as isk4, (mnFiyat / (100 + KDV) * 100) AS fiyat,KDV
,(SELECT MASTER_CODE FROM DisVeri.dbo.STOK_BIRLESIK_OTOMASYON WHERE BAYIKOD = (SELECT DISTINCT GMREF FROM [Web-Musteri-1] WHERE SMREF = tblINTERNET_Siparisler.SMREF AND TIP = tblINTERNET_Siparisler.TKSREF) AND [URT_KOD] = intUrunID) AS mastercode
,(SELECT BIRIMSET FROM DisVeri.dbo.STOK_BIRLESIK_OTOMASYON WHERE BAYIKOD = (SELECT DISTINCT GMREF FROM [Web-Musteri-1] WHERE SMREF = tblINTERNET_Siparisler.SMREF AND TIP = tblINTERNET_Siparisler.TKSREF) AND [URT_KOD] = intUrunID) AS birimset
FROM tblINTERNET_Siparisler
INNER JOIN tblINTERNET_SiparislerDetay ON pkSiparisID = intSiparisID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID
INNER JOIN tblINTERNET_SiparislerDetaySevk ON pkSiparisDetayID = tblINTERNET_SiparislerDetaySevk.bintSiparisDetayID
LEFT OUTER JOIN tblINTERNET_SiparislerDetayISK ON pkSiparisDetayID = tblINTERNET_SiparislerDetayISK.bintSiparisDetayID WHERE tblINTERNET_SiparislerDetaySevk.intMiktar > 0  AND sintFiyatTipiID != 2" + where;
            //string parametername = "pkSiparisID";

            if (IadeMi)
            {
                sorgu = @"SELECT pkIadeDetayID as detayno, intUrunID as malno, strUrunAdi as malzeme, KOLI as koli, tblINTERNET_IadelerDetay.intMiktar as miktar, 'ST' as miktartur, 0 as isk1, 0 as isk2, 0 as isk3, 0 as isk4, mnFiyat AS fiyat,KDV
,(SELECT TOP 1 MASTER_CODE FROM DisVeri.dbo.STOK_BIRLESIK_OTOMASYON WHERE BAYIKOD = (SELECT DISTINCT GMREF FROM [Web-Musteri-1] WHERE SMREF = tblINTERNET_Iadeler.SMREF AND TIP = tblINTERNET_Iadeler.TKSREF) AND [URT_KOD] = intUrunID) AS mastercode
,(SELECT TOP 1 BIRIMSET FROM DisVeri.dbo.STOK_BIRLESIK_OTOMASYON WHERE BAYIKOD = (SELECT DISTINCT GMREF FROM [Web-Musteri-1] WHERE SMREF = tblINTERNET_Siparisler.SMREF AND TIP = tblINTERNET_Iadeler.TKSREF) AND [URT_KOD] = intUrunID) AS birimset
FROM tblINTERNET_Iadeler
INNER JOIN tblINTERNET_IadelerDetay ON pkIadeID = intIadeID
INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID WHERE pkIadeID = " + SiparisID;
                //parametername = "pkIadeID";
            }

            DataTable dt = WebGenel.WCFdata(sorgu, new ArrayList(), new ArrayList(), "SiparisDetay");
            return dt;
        }

        public string IadeXml(XmlDocument icerik, string Bayikod, string Musteri, string neden)
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
                string docnumber = faturalar[i].SelectSingleNode("DOC_NUMBER") != null ? faturalar[i].SelectSingleNode("DOC_NUMBER").InnerText : faturalar[i].SelectSingleNode("NUMBER").InnerText;
                string docdate = faturalar[i].SelectSingleNode("DATE").InnerText;
                string hour = faturalar[i].SelectSingleNode("HOUR_CREATED") != null ? faturalar[i].SelectSingleNode("HOUR_CREATED").InnerText : "00";
                string minute = faturalar[i].SelectSingleNode("MIN_CREATED") != null ? faturalar[i].SelectSingleNode("MIN_CREATED").InnerText : "00";
                string second = faturalar[i].SelectSingleNode("SEC_CREATED") != null ? faturalar[i].SelectSingleNode("SEC_CREATED").InnerText : "00";
                DateTime date = DateTime.ParseExact(docdate + " " + hour + ":" + minute + ":" + second, "dd.MM.yyyy H:m:s", System.Globalization.CultureInfo.CurrentCulture);
                int SMREF = CariHesaplarTP.GetSMREFByMUSKOD(Convert.ToInt32(Bayikod), muskod);

                int iadeid = IadelerQ.QuantumNoVarMi(Bayikod, docnumber);
                bool redmi = true;
                if(iadeid > 0)
                {
                    Iadeler iadevarmi = Iadeler.GetObjectsByIadeID(iadeid);
                    redmi = iadevarmi.mnToplamTutar == -1 && iadevarmi.blAktarilmis == false;
                }

                if (iadeid > 0 && !redmi)
                {
                    hatali += docnumber + ": fatura numarası zaten kayıtlı.";
                }
                else
                {
                    if (SMREF > 0)
                    {
                        Iadeler iade = new Iadeler(Convert.ToInt32(Musteri), SMREF, date, -2, false, date, "Sistem;;;" + docnumber + ";;;xml");
                        iade.DoInsert();
                        iade.DoUpdate();
                        Iadeler.SetTksref(4, iade.pkIadeID);
                        Iadeler.SetSapDepo(neden, "", "", "", iade.pkIadeID);
                        
                        XmlNodeList transactions = faturalar[i].SelectNodes("TRANSACTIONS/TRANSACTION");
                        string hataliurun = string.Empty;
                        int aktarilanurun = 0;
                        for (int j = 0; j < transactions.Count; j++)
                        {
                            string type = transactions[j].SelectSingleNode("TYPE").InnerText;
                            if (type == "0") // malzeme
                            {
                                string mastercode = transactions[j].SelectSingleNode("MASTER_CODE").InnerText;
                                string itemref = Urunler.GetProductMastercode(Convert.ToInt32(Bayikod), mastercode);

                                if (itemref == "") // ilk bulamadığı üründe buraya girecek
                                {
                                    /*hataliurun += itemref;

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
                                    break;*/
                                }
                                else
                                {
                                    string malzeme = transactions[j].SelectSingleNode("MASTER_DEF").InnerText;
                                    string miktar = transactions[j].SelectSingleNode("QUANTITY").InnerText;
                                    string nettoplamfiyat = transactions[j].SelectSingleNode("TOTAL_NET").InnerText.Replace(".", ",");
                                    decimal netfiyat = Convert.ToDecimal(nettoplamfiyat) / Convert.ToInt32(miktar);
                                    IadelerDetay iadedetay = new IadelerDetay(iade.pkIadeID, Convert.ToInt32(itemref), malzeme, Convert.ToInt32(miktar), netfiyat);
                                    iadedetay.DoInsert();
                                    IadelerDetayFiy fiy = new IadelerDetayFiy(iadedetay.pkIadeDetayID, netfiyat * Convert.ToInt32(miktar), 0, tarih, "Sistem (XML)", DateTime.MinValue, string.Empty);
                                    fiy.DoInsert();
                                    aktarilanurun++;
                                }
                            }
                            else if (type == "2") // iskontolara gerek yok
                            {
                            }
                        }

                        if (hataliurun == string.Empty && aktarilanurun > 0) // bütün ürünler vardıysa eklendiyse
                        {
                            IadelerQ.WriteQuantumNo(iade.pkIadeID, docnumber, docnumber, date);

                            IadeHareketleri.DoInsert(iade.pkIadeID, 27, musteri.strAd + " " + musteri.strSoyad, "xml");
                            IadeHareketleri.DoInsert(iade.pkIadeID, 6, musteri.strAd + " " + musteri.strSoyad, "xml");

                            WebGenel.ExecNQ("db_sp_bayiStokGuncelle1b", CommandType.StoredProcedure, new ArrayList() { "GMREF" }, new ArrayList() { CariHesaplarTP.GetGMREFBySMREF(iade.SMREF) });
                            WebGenel.ExecNQ("db_sp_bayiStokGuncelle2b", CommandType.StoredProcedure, new ArrayList() { "GMREF" }, new ArrayList() { CariHesaplarTP.GetGMREFBySMREF(iade.SMREF) });

                            aktarilan += docnumber + ".";
                        }
                        else // iade içindeki hiç bir ürün bizim değilse
                        {
                            iade.DoDelete();
                        }
                    }
                    else
                    {
                        hatali += docnumber + ": " + muskod + " kodlu müşteri bulunamadı.";
                    }
                }
            }

            donendeger = aktarilan + "." + hatali;

            WebGenel.ExecNQ("sp_INTERNET_IadelerXMLlogEkle", CommandType.StoredProcedure,
                new ArrayList() { "@KULLANICI", "@BAYIKOD", "@XMLICERIK", "@NEDEN", "@AKTARIMLOG", "@HATALOG" },
                new ArrayList() { Convert.ToInt32(Musteri), Convert.ToInt32(Bayikod), gelen.OuterXml, neden, aktarilan.Replace("Aktarılanlar.", ""), hatali.Replace("Aktarılamayanlar.", "") });

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
            if (Bayikod == "1071593" || Bayikod == "1052689" || Bayikod == "1018538") // kaan, peker, yılmaz
            {
                //if (Satis == "Satis")
                //{
                //    DateTime bas = Convert.ToDateTime(BitYil + "." + (BitAy.Length > 1 ? BitAy : "0" + BitAy) + ".01");
                //    DisVeri.ExecNQwp("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,[CEKIM_TARIH]) >= @TARIH", new ArrayList() { "TARIH" }, new object[] { bas });
                //}
                //else
                //{
                //    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
                //}
                YilAd = "YEAR(tarih)";
                AyAd = "MONTH(tarih)";
            }
            else
            {

            }

            if (Satis == "Satis")
            {
                DateTime silmebas = Convert.ToDateTime("01." + BasAy + "." + BasYil);
                DateTime silmebit = Convert.ToDateTime("01." + BitAy + "." + BitYil).AddMonths(1);
                DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,CONVERT(nvarchar(50)," + AyAd + ") + '.01.' + CONVERT(nvarchar(50)," + YilAd + ")) >= '" + silmebas.Month + ".01." + silmebas.Year + "'" + " AND CONVERT(datetime,CONVERT(nvarchar(50)," + AyAd + ") + '.01.' + CONVERT(nvarchar(50)," + YilAd + ")) < '" + silmebit.Month + ".01." + silmebit.Year + "'");
            }
            else
                DisVeri.ExecNQ("DELETE FROM " + tabloadi);

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

    public class EncodingStringWriter : StringWriter
    {
        private readonly Encoding _encoding;

        public EncodingStringWriter(StringBuilder builder, Encoding encoding) : base(builder)
        {
            _encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return _encoding; }
        }
    }
}
