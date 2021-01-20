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

    public class XmlSiparisDis
    {
        public string SipNo { get; set; }
        public string Uye { get; set; }
        public DateTime Tarih { get; set; }
        //public double Tutar { get; set; }
        public string Aciklama { get; set; }
        [XmlElement("Musteri")]
        public XmlSiparisMusteri Musteri { get; set; }
        public List<XmlSiparisDisDetay> Kalemler { get; set; }
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
}
