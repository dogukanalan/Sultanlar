using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

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
        Class.SiparislerDis SiparisJ(string apikey, string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "xml/Fatura/{apikey}/{baslangic}/{bitis}")]
        XmlDocument Fatura(string apikey, string baslangic, string bitis);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/Fatura/{apikey}/{baslangic}/{bitis}")]
        Class.FaturalarDis FaturaJ(string apikey, string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Post?bayikod={Bayikod}&satis={Satis}&yilad={YilAd}&yil={Yil}&ayad={AyAd}&ay={Ay}")]
        XmlDocument PostXml(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay);
    }
}
