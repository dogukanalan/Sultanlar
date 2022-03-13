using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Class
{
    [XmlRoot(ElementName = "SultanlarOrdersXml")]
    public class XmlSiparislerDis
    {
        [XmlElement(ElementName = "Siparis", Order = 1)]
        public List<XmlSiparisDis> Siparisler { get; set; }
    }
    [XmlRoot(ElementName = "SultanlarInvoicesXml")]
    public class XmlFaturalarDis
    {
        [XmlElement(ElementName = "Fatura", Order = 1)]
        public List<XmlFaturaDis> Faturalar { get; set; }
    }

    public class XmlSiparisDis
    {
        public string SipNo { get; set; }
        public string PlasiyerKodu { get; set; }
        public string PlasiyerAdi { get; set; }
        public string Telefon { get; set; }
        public string Bolge { get; set; }
        public DateTime Tarih { get; set; }
        //public double Tutar { get; set; }
        public string Aciklama { get; set; }
        [XmlElement("Musteri")]
        public XmlSiparisMusteri Musteri { get; set; }
        public List<XmlSiparisDisDetay> Kalemler { get; set; }
        public double ToplamBrut { get; set; }
        public double ToplamNet { get; set; }
        public double ToplamIskonto { get; set; }
        public double ToplamKDV { get; set; }
        public double ToplamNetKDV { get; set; }
    }

    public class XmlSiparisMusteri
    {
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string BayiKod { get; set; }
        public string BayiUnvan { get; set; }
        public string Kod { get; set; }
        public string Unvan { get; set; }
        public string Aciklama { get; set; }
        public string FaturaTip { get; set; }
        public string VergiDaire { get; set; }
        public string VergiNo { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mobil { get; set; }
        public string Fax { get; set; }
        public string Eposta { get; set; }
    }

    [XmlType("Kalem")]
    public class XmlSiparisDisDetay
    {
        public string UrunKod { get; set; }
        public string Bolum { get; set; }
        public string Barkod { get; set; }
        public string KdvOran { get; set; }
        public string KoliAdet { get; set; }
        public string UrunAd { get; set; }
        public int Adet { get; set; }
        public double BrutFiyat { get; set; }
        public double Isk1 { get; set; }
        public double Isk2 { get; set; }
        public double Isk3 { get; set; }
        public double Isk4 { get; set; }
        public double NetFiyat { get; set; }
        public double Kdv { get; set; }
        public double KdvDahilNet { get; set; }
    }

    public class XmlFaturaDis
    {
        public string FAT_NO { get; set; }
        public string FAT_NO_MTB { get; set; }
        public DateTime FAT_TAR { get; set; }
        public string PER_KOD { get; set; }
        public string PER_TEM { get; set; }
        public string SUBE { get; set; }
        public List<XmlFaturaDisDetay> Kalemler { get; set; }
    }

    [XmlType("Kalem")]
    public class XmlFaturaDisDetay
    {
        public int MAL_KOD { get; set; }
        public string MALZEME { get; set; }
        public double ADET_TOP { get; set; }
        public double KOLI_TOP { get; set; }
        public double ISK_TOP { get; set; }
        public double NET_TOP { get; set; }
        public double KDV_TOP { get; set; }
        public double NETKDV_TOP { get; set; }
    }
}
