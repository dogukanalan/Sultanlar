using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDirect" in both code and config file together.
    [ServiceContract]
    public interface IDirect
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Test")]
        string Test();

        [OperationContract, XmlSerializerFormat]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/HesaplaKaydet?bayikod={BayiKod}&yil={Yil}&ay={Ay}&kaydet={Kaydet}&eposta={Email}")]
        XmlDocument HesaplaKaydetIc(int BayiKod, int Yil, int Ay, bool Kaydet, string Email);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/HesaplaKaydet?kaydet={Kaydet}")]
        XmlDocument HesaplaKaydetDis(XmlDocument icerik, bool Kaydet);
    }
}
