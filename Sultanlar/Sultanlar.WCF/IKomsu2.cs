using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKomsu2" in both code and config file together.
    [ServiceContract]
    public interface IKomsu2
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu001/{Matnr}")]
        komsuC0011.ZwebKomsuS_001[] komsu001(string Matnr);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu002/{Matnr}")]
        komsuC0021.ZwebKomsuS_002[] komsu002(string Matnr);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu003/{Matnr}")]
        komsuC0031.ZwebKomsuS_003[] komsu003(string Matnr);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu004/{Werks}/{Matnr}")]
        komsuC0041.ZwebKomsuS_004[] komsu004get(string Werks, string Matnr);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/post/komsu004/{Matnr}")]
        komsuC0041.ZwebKomsuS_004[] komsu004(komsuC0041.Werks Werks, string Matnr);
    }
}
