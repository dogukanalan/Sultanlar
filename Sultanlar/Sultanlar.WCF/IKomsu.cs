using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKomsu" in both code and config file together.
    [ServiceContract]
    public interface IKomsu
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu001/{Matnr}")]
        KomsuC001.ZwebKomsuS_001[] komsu001(string Matnr);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu002/{Matnr}")]
        KomsuC002.ZwebKomsuS_002[] komsu002(string Matnr);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu003/{Matnr}")]
        KomsuC003.ZwebKomsuS_003[] komsu003(string Matnr);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/get/komsu004/{Werks}/{Matnr}")]
        KomsuC004.ZwebKomsuS_004[] komsu004get(string Werks, string Matnr);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "json/post/komsu004/{Matnr}")]
        KomsuC004.ZwebKomsuS_004[] komsu004(KomsuC004.Werks Werks, string Matnr);
    }
}
