using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Model.Xml
{
    [XmlRoot(ElementName = "SultanlarOrdersXml")]
    public class XmlSiparislerDis
    {
        [XmlElement(ElementName = "Siparis", Order = 1)]
        public List<XmlSiparisDis> Siparisler { get; set; }
    }

    [XmlRoot(ElementName = "SultanlarSiparisler")]
    public class SiparislerDis
    {
        [XmlElement(ElementName = "siparis", Order = 1)]
        public List<SiparisDis> Siparisler { get; set; }
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

    public class SiparisDis
    {
        public string sipno { get; set; }
        public string tur { get; set; }
        public string vade { get; set; }
        public string iptal { get; set; }
        public string belgeno { get; set; }
        public string carino { get; set; }
        public string carino2 { get; set; }
        public string cari { get; set; }
        public string tarih { get; set; }
        public string aciklama { get; set; }
        public List<SiparisDisDetay> detaylar { get; set; }
    }

    [XmlType("detay")]
    public class SiparisDisDetay
    {
        public string detayno { get; set; }
        public MalzemeDetay malzeme { get; set; }
        public string miktar { get; set; }
        public string miktartur { get; set; }
        public string isk1 { get; set; }
        public string isk2 { get; set; }
        public string isk3 { get; set; }
        public string isk4 { get; set; }
        public string fiyat { get; set; }
    }

    [XmlType("malzeme")]
    public class MalzemeDetay
    {
        public string malno { get; set; }
        public string malacik { get; set; }
        public string koli { get; set; }
    }
}
