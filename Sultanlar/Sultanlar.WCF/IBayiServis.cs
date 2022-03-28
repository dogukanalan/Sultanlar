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
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Post?bayikod={Bayikod}&satis={Satis}&yilad={YilAd}&yil={Yil}&ayad={AyAd}&ay={Ay}")]
        XmlDocument PostXml(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay);
    }
}
