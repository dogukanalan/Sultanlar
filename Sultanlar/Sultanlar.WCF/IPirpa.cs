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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPirpa" in both code and config file together.
    [ServiceContract]
    public interface IPirpa
    {
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Invoices/{baslangic}/{bitis}")]
        XmlDocument GetInvoices(string baslangic, string bitis);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/xml/Orders/{baslangic}/{bitis}")]
        XmlDocument GetOrders(string baslangic, string bitis);
    }
}
