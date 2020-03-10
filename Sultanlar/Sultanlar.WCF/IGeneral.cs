using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.ServiceModel.Web;
using System.IO;
using System.Drawing;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGeneral" in both code and config file together.
    [ServiceContract]
    public interface IGeneral
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Test")]
        string Test();
        //
        //
        //
        // XML:
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Android/GetSqliteDb/?eposta={Eposta}&sifre={Sifre}")]
        string androidGetSqliteDb(string Eposta, string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Android/GetSqliteDbFull/?eposta={Eposta}&sifre={Sifre}")]
        string androidGetSqliteDbFull(string Eposta, string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Android/GetClients/?eposta={Eposta}&sifre={Sifre}")]
        XmlDocument androidGetClients(string Eposta, string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Android/GetTypeOfPrices/?eposta={Eposta}&sifre={Sifre}")]
        XmlDocument androidGetTypeOfPrices(string Eposta, string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Android/GetPrices/?eposta={Eposta}&sifre={Sifre}")]
        XmlDocument androidGetPrices(string Eposta, string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Android/GetProducts/?eposta={Eposta}&sifre={Sifre}")]
        XmlDocument androidGetProducts(string Eposta, string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/GetSalesmen/?sifre={Sifre}")]
        XmlDocument GetSalesmen(string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/GetClients/?sifre={Sifre}")]
        XmlDocument GetClients(string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/GetTypeOfPrices/?sifre={Sifre}")]
        XmlDocument GetTypeOfPrices(string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/GetProducts/?sifre={Sifre}")]
        XmlDocument GetProducts(string Sifre);
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/GetPrices/?sifre={Sifre}")]
        XmlDocument GetPrices(string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/hepsiburada/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument hbGetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/n11/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument n11GetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/dela/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument delaGetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/komsu/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument komsuGetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/gg/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument ggGetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/sp/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument sanalpazarGetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/6/GetProducts")]
        XmlDocument GetProducts6();
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/17/GetProducts")]
        XmlDocument GetProducts17();
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/18/GetProducts")]
        XmlDocument GetProducts18();
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/19/GetProducts")]
        XmlDocument GetProducts19();
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/urun/GetProducts")]
        XmlDocument GetProductsUrun();
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/bayi/GetProducts")]
        XmlDocument GetProducts22();
        //
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/json/bayi/GetProducts"), DataContractFormat]
        List<ProductsF22> JSONGetProducts22();
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/brl/GetProducts/?kullanici={KAdi}&sifre={Sifre}")]
        XmlDocument brlGetProducts(string KAdi, string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/eczanem/Efatura/?sifre={Sifre}&vn={VRGNO}&bas={Baslangic}&bit={Bitis}")]
        XmlDocument Efatura(string Sifre, string VRGNO, string Baslangic, string Bitis);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Efatura/eczanem")]
        XmlDocument EfaturaPost(XmlDocument icerik);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/bayisatisrapor?sifre={Sifre}&bayikod={Bayikod}&yil={Yil}&ay={Ay}")]
        XmlDocument GetBayiSatisRapor(string Sifre, string Bayikod, string Yil, string Ay);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/mobilgi/GetProducts?sifre={Sifre}")]
        XmlDocument MobilgiGetProducts(string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/mobilgi/GetCustomers?sifre={Sifre}")]
        XmlDocument MobilgiGetCustomers(string Sifre);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/mobilgi/GetCustomerProduct?sifre={Sifre}&magazakod={Kod}")]
        XmlDocument MobilgiGetCustomerProduct(string Sifre, string Kod);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/EmusiadGetProducts/GetProducts?sifre={Sifre}&grup={Grup}")]
        XmlDocument EmusiadGetProducts(string Sifre, string Grup);
        //
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/View/Get?sifre={Sifre}&name={Name}&paramn={ParamNames}&paramv={ParamValues}")]
        XmlDocument GetView(string Sifre, string Name, string ParamNames, string ParamValues);
        //
        //[OperationContract, XmlSerializerFormat]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/eczanem/Efatura/Post")]
        //XmlDocument EfaturaPost(XmlDocument icerik);
        //
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/SDE/Picture/Post"), DataContractFormat]
        SDEpictures SDEpicturePost(SDEpictures icerik);
        //
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/Deneme/Post"), DataContractFormat]
        List<Salesmen> DenemePost(List<Salesmen> icerik);
        //
        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/xml/SDE/Picture/Post1"), DataContractFormat]
        //void UploadPicMerch(string imageData, string smref, string tip, string tur, string musteri, string ziyaret, string rut, string aciklama);
        //
        //
        //
        // JSON:
        //
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GetSalesmen/?sifre={Sifre}"), DataContractFormat]
        List<Salesmen> JSONGetSalesmen(string Sifre);
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GetClients/?sifre={Sifre}"), DataContractFormat]
        List<Clients> JSONGetClients(string Sifre);
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GetTypeOfPrices/?sifre={Sifre}"), DataContractFormat]
        List<TypeOfPrices> JSONGetTypeOfPrices(string Sifre);
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GetProducts/?sifre={Sifre}"), DataContractFormat]
        List<Products> JSONGetProducts(string Sifre);
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GetPrices/?sifre={Sifre}"), DataContractFormat]
        List<Prices> JSONGetPrices(string Sifre);
        //
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/hepsiburada/GetProducts/?kullanici={KAdi}&sifre={Sifre}"), DataContractFormat]
        List<hbProducts> JSONhbGetProducts(string KAdi, string Sifre);
        //
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/n11/GetProducts/?kullanici={KAdi}&sifre={Sifre}"), DataContractFormat]
        List<n11Products> JSONn11GetProducts(string KAdi, string Sifre);
    }
    //
    //
    //
    //
    //
    //
    //
    // Classes:
    //
    //
    [DataContract]
    public class TypeOfPrices
    {
        [DataMember]
        public int tp_r { get; set; }

        public TypeOfPrices() { }

        public TypeOfPrices(int typeofprice)
        {
            this.tp_r = typeofprice;
        }
    }
    //
    //
    //
    [DataContract]
    public class Salesmen
    {
        [DataMember]
        public int sm_r { get; set; }
        [DataMember]
        public string sm { get; set; }

        public Salesmen() { }

        public Salesmen(int salesman_ref, string salesman)
        {
            this.sm_r = salesman_ref;
            this.sm = salesman;
        }
    }
    //
    //
    //
    [DataContract]
    public class Clients
    {
        [DataMember]
        public int ss_r { get; set; }
        [DataMember]
        public int sm_r { get; set; }
        [DataMember]
        public string ss { get; set; }

        public Clients() { }

        public Clients(int substation_ref, int salesman_ref, string substation)
        {
            this.ss_r = substation_ref;
            this.sm_r = salesman_ref;
            this.ss = substation;
        }
    }
    //
    //
    //
    [DataContract]
    public class Products
    {
        [DataMember]
        public int it_r { get; set; }
        [DataMember]
        public string it { get; set; }
        [DataMember]
        public string br { get; set; }
        [DataMember]
        public string st { get; set; }

        public Products() { }

        public Products(int item_ref, string item, string barcode, string stock)
        {
            this.it_r = item_ref;
            this.it = item;
            this.br = barcode;
            this.st = stock;
        }
    }
    //
    //
    //
    [DataContract]
    public class Prices
    {
        [DataMember]
        public int it_r { get; set; }
        [DataMember]
        public int tp_r { get; set; }
        [DataMember]
        public string pr { get; set; }

        public Prices() { }

        public Prices(int item_ref, int typeofprice_ref, string price)
        {
            this.it_r = item_ref;
            this.tp_r = typeofprice_ref;
            this.pr = price;
        }
    }
    //
    //
    //
    [DataContract]
    public class hbProducts
    {
        [DataMember]
        public string UrunID { get; set; }
        [DataMember]
        public string UrunAdi { get; set; }
        [DataMember]
        public string KDV { get; set; }
        [DataMember]
        public string OzelFiyat { get; set; }
        [DataMember]
        public string ListeFiyat { get; set; }
        [DataMember]
        public string Kur { get; set; }
        [DataMember]
        public string StokAdedi { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public string ImageName1 { get; set; }

        public hbProducts() { }

        public hbProducts(string urunid, string urunadi, string kdv, string ozelfiyat, string listefiyat, string kur, string stokadedi, string barcode, 
            string imagename1)
        {
            this.UrunID = urunid;
            this.UrunAdi = urunadi;
            this.KDV = kdv;
            this.OzelFiyat = ozelfiyat;
            this.ListeFiyat = listefiyat;
            this.Kur = kur;
            this.StokAdedi = stokadedi;
            this.Barcode = barcode;
            this.ImageName1 = imagename1;
        }
    }
    //
    //
    //
    [DataContract]
    public class n11Products
    {
        [DataMember]
        public string UrunID { get; set; }
        [DataMember]
        public string UrunAdi { get; set; }
        [DataMember]
        public string KDV { get; set; }
        [DataMember]
        public string OzelFiyat { get; set; }
        [DataMember]
        public string ListeFiyat { get; set; }
        [DataMember]
        public string Kur { get; set; }
        [DataMember]
        public string StokAdedi { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public string ImageName1 { get; set; }

        public n11Products() { }

        public n11Products(string urunid, string urunadi, string kdv, string ozelfiyat, string listefiyat, string kur, string stokadedi, string barcode, 
            string imagename1)
        {
            this.UrunID = urunid;
            this.UrunAdi = urunadi;
            this.KDV = kdv;
            this.OzelFiyat = ozelfiyat;
            this.ListeFiyat = listefiyat;
            this.Kur = kur;
            this.StokAdedi = stokadedi;
            this.Barcode = barcode;
            this.ImageName1 = imagename1;
        }
    }
    //
    //
    //
    [DataContract]
    public class ProductsF22
    {
        [DataMember]
        public string GRUP { get; set; }
        [DataMember]
        public string KOD { get; set; }
        [DataMember]
        public string MALZEME { get; set; }
        [DataMember]
        public string BARKOD { get; set; }
        [DataMember]
        public string PAKET { get; set; }
        [DataMember]
        public string KOLI { get; set; }
        [DataMember]
        public double KDV { get; set; }
        [DataMember]
        public double FIYAT { get; set; }
        [DataMember]
        public double ISK1 { get; set; }
        [DataMember]
        public double ISK2 { get; set; }
        [DataMember]
        public double ISK3 { get; set; }
        [DataMember]
        public double ISK4 { get; set; }
        [DataMember]
        public double ISK5 { get; set; }
        [DataMember]
        public double ISK6 { get; set; }
        [DataMember]
        public double ISK7 { get; set; }
        [DataMember]
        public double ISK8 { get; set; }
        [DataMember]
        public double ISK9 { get; set; }
        [DataMember]
        public double ISK10 { get; set; }
        [DataMember]
        public double NETKDV { get; set; }
        [DataMember]
        public string VD { get; set; }
        [DataMember]
        public string STOK { get; set; }
        [DataMember]
        public string KG { get; set; }
        [DataMember]
        public string DM3 { get; set; }
        [DataMember]
        public string Resim { get; set; }

        public ProductsF22() { }

        public ProductsF22(string grup, string kod, string malzeme, string barkod, string paket, string koli, double kdv, double fiyat,
            double isk1, double isk2, double isk3, double isk4, double isk5, double isk6, double isk7, double isk8, double isk9, double isk10, double netkdv,
            string vd, string stok, string kg, string dm3, string resim)
        {
            this.GRUP = grup;
            this.KOD = kod;
            this.MALZEME = malzeme;
            this.BARKOD = barkod;
            this.PAKET = paket;
            this.KOLI = koli;
            this.KDV = kdv;
            this.FIYAT = fiyat;
            this.ISK1 = isk1;
            this.ISK2 = isk2;
            this.ISK3 = isk3;
            this.ISK4 = isk4;
            this.ISK5 = isk5;
            this.ISK6 = isk6;
            this.ISK7 = isk7;
            this.ISK8 = isk8;
            this.ISK9 = isk9;
            this.ISK10 = isk10;
            this.NETKDV = netkdv;
            this.VD = vd;
            this.STOK = stok;
            this.KG = kg;
            this.DM3 = dm3;
            this.Resim = resim;
        }
    }
    //
    //
    //
    [DataContract]
    public class SDEpictures
    {
        [DataMember]
        public int smref { get; set; }
        [DataMember]
        public int tip { get; set; }
        [DataMember]
        public int musteri { get; set; }
        [DataMember]
        public int tur { get; set; }
        [DataMember]
        public string rut { get; set; }
        [DataMember]
        public int ziyaret { get; set; }
        [DataMember]
        public string resim { get; set; }
        [DataMember]
        public string aciklama { get; set; }
        [DataMember]
        public string not { get; set; }

        public SDEpictures() { }

        public SDEpictures(int smref, int tip, int musteri, int tur, string rut, int ziyaret, string resim, string aciklama, string not)
        {
            this.smref = smref;
            this.tip = tip;
            this.musteri = musteri;
            this.tur = tur;
            this.rut = rut;
            this.ziyaret = ziyaret;
            this.resim = resim;
            this.aciklama = aciklama;
            this.not = not;
        }
    }
}
