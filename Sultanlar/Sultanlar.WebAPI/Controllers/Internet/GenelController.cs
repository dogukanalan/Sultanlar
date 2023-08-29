using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Produces("application/json")]
    public class GenelController : Controller
    {
        [HttpGet, Yetkili]
        [Route("internet/[controller]/[action]/{cookieRTicket}")]
        public IEnumerable<string> Ticket(string cookieRTicket)
        {
            DateTime yeni = cookieRTicket == "true" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : DateTime.Now.AddMinutes(60);
            string yeniticket = Sifreleme.Encrypt(yeni.ToString());
            string yeniticket2 = Sifreleme.Encrypt("ri8jtDmDQca=", yeni.ToString());

            return new string[] { yeniticket, yeniticket2 };
        }

        [HttpGet, Yetkili]
        [Route("internet/[controller]/[action]")]
        public string Auth() => "";

        [HttpGet, Yetkili]
        [Route("internet/[controller]/[action]/{yer}/{json}")]
        public string HataEkle(string yer, string json)
        {
            byte[] data = System.Convert.FromBase64String(json);
            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);

            Hatalar.DoInsert(base64Decoded, "api " + yer);
            return base64Decoded;
        }

        public string WcfPostTo(string url, string contenttype, [FromBody]XmlDocument icerik)
        {
            try
            {
                string xml = icerik.OuterXml;
                DataSet ds = new DataSet();
                ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
                DataTable dt = ds.Tables[0];

                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                wr.Method = "POST";
                wr.ContentType = contenttype;
                wr.Timeout = 600000;
                wr.ReadWriteTimeout = 600000;
                byte[] bytes = Encoding.UTF8.GetBytes(ds.GetXml());

                Stream requestStream = wr.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        public string WcfGetTo(string url)
        {
            try
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                wr.Method = "GET";
                wr.ContentType = "text/xml; encoding='utf-8'";
                wr.Timeout = 600000;
                wr.ReadWriteTimeout = 600000;

                HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
            }
            catch (Exception ex)
            {
                return "<hata>" + ex.Message + "</hata>";
            }

            return "";
        }

        public string WcfGetToJSON(string url)
        {
            try
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                wr.Method = "GET";
                wr.ContentType = "application/json; encoding='utf-8'";
                wr.Timeout = 600000;
                wr.ReadWriteTimeout = 600000;


                HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
    }
}
