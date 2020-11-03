using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sultanlar.WCF
{
    /// <summary>
    /// Summary description for sanalpos
    /// </summary>
    public class sanalpos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string donendeger = string.Empty;


            string xmldata = "<posnetRequest>" +
"<mid>6701633142</mid>" +
"<tid>67124469</tid>" +
"<reverse>" +
"<transaction>sale</transaction>" +
"<hostLogKey>" + context.Request.QueryString["hostlogkey"] + "</hostLogKey>" +
"</reverse>" +
"</posnetRequest>";

            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;


            System.Net.WebRequest webr = System.Net.WebRequest.Create("https://posnet.yapikredi.com.tr/PosnetWebService/XML?xmldata=" + xmldata);

            System.Net.WebResponse wr = webr.GetResponse();
            System.IO.Stream stream = wr.GetResponseStream();
            System.IO.StreamReader strR = new System.IO.StreamReader(stream, System.Text.Encoding.GetEncoding("iso-8859-9"));
            string sayfa = strR.ReadToEnd();
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(sayfa);
            strR.Close();
            wr.Close();


            string approved = xdoc.GetElementsByTagName("approved")[0].InnerText;
            string authCode = string.Empty, hostlogkey = string.Empty, respCode = string.Empty, respText = string.Empty;

            try
            {
                authCode = xdoc.GetElementsByTagName("authCode")[0].InnerText;
                hostlogkey = xdoc.GetElementsByTagName("hostlogkey")[0].InnerText;
            }
            catch (Exception)
            {

            }

            try
            {
                respCode = xdoc.GetElementsByTagName("respCode")[0].InnerText;
                respText = xdoc.GetElementsByTagName("respText")[0].InnerText;
            }
            catch (Exception)
            {

            }

            donendeger = approved + ";;;" + authCode + ";;;" + hostlogkey + ";;;" + respCode + ";;;" + respText;

            context.Response.ContentType = "text/plain";
            context.Response.Write(donendeger);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}