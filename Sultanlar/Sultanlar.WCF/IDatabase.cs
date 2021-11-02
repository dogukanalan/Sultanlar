using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;

namespace Sultanlar.WCF
{
    [ServiceContract]
    public interface IDatabase
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Test")]
        string Test();

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/get/saticilar"), DataContractFormat]
        List<SatisTemsilcileri> SaticilarGet();
    }
}
