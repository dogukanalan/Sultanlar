using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using Sultanlar.Model.Xml;
using Sultanlar.Model.Bayi;
using System.IO;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBayiServis" in both code and config file together.
    [ServiceContract]
    public interface IBayiServis
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Test")]
        string Test();

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Siparis/{apikey}/{baslangic}/{bitis}")]
        XmlDocument Siparis(string apikey, string baslangic, string bitis);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Siparis/{apikey}/{baslangic}/{bitis}")]
        SiparislerDis SiparisJ(string apikey, string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Fatura/{apikey}/{baslangic}/{bitis}")]
        XmlDocument Fatura(string apikey, string baslangic, string bitis);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Fatura/{apikey}/{baslangic}/{bitis}")]
        FaturalarDis FaturaJ(string apikey, string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Fatura2/{apikey}/{sipler}")]
        XmlDocument Fatura2(string apikey, string sipler);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Fatura2/{apikey}/{sipler}")]
        FaturalarDis Fatura2J(string apikey, string sipler);

        #region logo
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Siparis/logo/{apikey}/{baslangic}/{bitis}")]
        XmlDocument SiparisLogo(string apikey, string baslangic, string bitis);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Siparis/logo/{apikey}/{baslangic}/{bitis}")]
        SiparislerDis SiparisJLogo(string apikey, string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Fatura/logo/{apikey}/{baslangic}/{bitis}")]
        XmlDocument FaturaLogo(string apikey, string baslangic, string bitis);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Fatura/logo/{apikey}/{baslangic}/{bitis}")]
        BimatFaturalarDis FaturaJLogo(string apikey, string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Fatura2/logo/{apikey}/{sipler}")]
        XmlDocument Fatura2Logo(string apikey, string sipler);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Fatura2/logo/{apikey}/{sipler}")]
        BimatFaturalarDis Fatura2JLogo(string apikey, string sipler);
        #endregion



        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Post?bayikod={Bayikod}&satis={Satis}&yilad={YilAd}&yil={Yil}&ayad={AyAd}&ay={Ay}")]
        XmlDocument PostXml(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Post2?bayikod={Bayikod}&satis={Satis}&yilad={YilAd}&basyil={BasYil}&bityil={BitYil}&ayad={AyAd}&basay={BasAy}&bitay={BitAy}")]
        XmlDocument PostXml2(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string BasYil, string BitYil, string AyAd, string BasAy, string BitAy);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Iade?bayikod={Bayikod}&musteri={Musteri}")]
        string IadeXml(XmlDocument icerik, string Bayikod, string Musteri);
    }
}
