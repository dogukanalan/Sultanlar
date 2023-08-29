using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Sultanlar.DatabaseObject.SAP
{
    public class Services
    {
        //string username;
        //string password;
        readonly NetworkCredential nc1 = new NetworkCredential("MISTIF", "Ankara1923*+B");

        public Services()
        {
            //this.username = username;
            //this.password = password;
        }

        public string GetClientResponse(string baseurl, string request)
        {
            WebClient wc = new WebClient();
            wc.Credentials = nc1;
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");
            wc.Headers.Add("Host", "192.168.1.5:8000");
            return wc.DownloadString(baseurl + request);

            /*RestClient rest = new RestClient(baseurl);
            rest.Authenticator = new HttpBasicAuthenticator(username, password);
            rest.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");
            rest.AddDefaultHeader("Host", "192.168.1.5:8000");
            //rest.AddDefaultHeader("Connection", "keep-alive");
            rest.AddDefaultHeader("Accept-Encoding", "gzip, deflate");
            RestRequest req = new RestRequest(request, Method.GET);
            //req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");
            req.Timeout = 600000;
            IRestResponse resp = rest.Get(req);
            return resp.Content;*/
        }
    }

    public enum SapType
    {
        Single,
        Multi
    }

    public class SapBase<T>
    {
        public Services serv;
        public string baseurl;
        public string request;
        public SapType type;

        public SapBase()
        {
            baseurl = string.IsNullOrEmpty(baseurl) ? "http://192.168.1.5:8000" : baseurl;
            serv = new Services();
        }

        public object Get()
        {
            if (type == SapType.Single)
            {
                return GetObjects();
            }
            else
            {
                return GetObject();
            }
        }
        public List<T> GetObjects()
        {
            string data = serv.GetClientResponse(baseurl, request);
            List<T> donendeger = JsonConvert.DeserializeObject<List<T>>(data);
            return donendeger;
        }
        public T GetObject()
        {
            string data = serv.GetClientResponse(baseurl, request);
            T donendeger = JsonConvert.DeserializeObject<T>(data);
            return donendeger;
        }
    }

    public class Materials : SapBase<ZwebGetMaterials>
    {
        public Materials(SapType type)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebGetMaterials";
        }

        //public List<t_materials> GetMaterials()
        //{
        //    string data = serv.GetClientResponse("http://192.168.1.5:8000", "/sap/bc/zweb_rest?sap-client=111&method=ZwebGetMaterials");
        //    List<t_materials> donendeger = JsonConvert.DeserializeObject<List<t_materials>>(data);
        //    return donendeger;
        //}
    }
    public class T179T : SapBase<ZwebGetT179t>
    {
        public T179T(SapType type)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebGetT179t";
        }
    }
    public class Customers : SapBase<ZwebGetCustomers>
    {
        public Customers(SapType type)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebGetCustomers";
        }
    }
    public class Prices : SapBase<ZwebGetMaterialPrices>
    {
        public Prices(SapType type)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebGetMaterialPrices";
        }
    }
    public class Personal : SapBase<ZwebGetPersonals>
    {
        public Personal(SapType type)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebGetPersonals";
        }
    }
    public class Vbfa : SapBase<ZwebSelectSalesVbfa>
    {
        public Vbfa(SapType type, string date, string time)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebSelectSalesVbfa&date=" + date + "&time=" + time;
        }
    }
    public class Order : SapBase<ZwebSelectSalesOrder>
    {
        public Order(SapType type, string date, string time)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebSelectSalesOrder&begda=" + date + "&endda=&time=" + time;
        }
    }
    public class Delivery : SapBase<ZwebSelectSalesDelivery>
    {
        public Delivery(SapType type, string date, string time)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebSelectSalesDelivery&begda=" + date + "&endda=&time=" + time;
        }
    }
    public class Transport : SapBase<ZwebSelectSalesTransport>
    {
        public Transport(SapType type, string date, string time)
        {
            this.type = type;
            this.request = "/sap/bc/zweb_rest?sap-client=111&method=ZwebSelectSalesTransport&date=" + date + "&time=" + time;
        }
    }
}
