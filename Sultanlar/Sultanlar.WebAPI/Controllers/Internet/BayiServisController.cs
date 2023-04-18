using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Route("dis/[controller]/[action]")]
    public class BayiServisController : ControllerBase
    {
        [HttpPost("{bayikod}/{satis}/{yilad}/{yil}/{ayad}/{ay}")]
        public string SatisStok(string bayikod, string satis, string yilad, string yil, string ayad, string ay, [FromBody]XmlDocument icerik)
        {
            try
            {
                string xml = icerik.OuterXml;
                DataSet ds = new DataSet();
                ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
                DataTable dt = ds.Tables[0];

                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/Post?bayikod=" + bayikod +
                    "&satis=" + satis +
                    "&yilad=" + (satis == "Satis" ? yilad : "") +
                    "&yil=" + yil.ToString() +
                    "&ayad=" + (satis == "Satis" ? ayad : "") +
                    "&ay=" + ay.ToString());
                wr.Method = "POST";
                wr.ContentType = "text/xml; encoding='utf-8'";
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

        [HttpPost("{bayikod}/{satis}/{yilad}/{basyil}/{bityil}/{ayad}/{basay}/{bitay}")]
        public string SatisStok2(string bayikod, string satis, string yilad, string basyil, string bityil, string ayad, string basay, string bitay, [FromBody] XmlDocument icerik)
        {
            try
            {
                string xml = icerik.OuterXml;
                DataSet ds = new DataSet();
                ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
                DataTable dt = ds.Tables[0];

                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/Post2?bayikod=" + bayikod +
                    "&satis=" + satis +
                    "&yilad=" + (satis == "Satis" ? yilad : "") +
                    "&basyil=" + basyil.ToString() +
                    "&bityil=" + bityil.ToString() +
                    "&ayad=" + (satis == "Satis" ? ayad : "") +
                    "&basay=" + basay.ToString() +
                    "&bitay=" + bitay.ToString());
                wr.Method = "POST";
                wr.ContentType = "text/xml; encoding='utf-8'";
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

        [HttpGet("json/{apikey}/{baslangic}/{bitis}")]
        public IActionResult Siparis(string apikey, string type, string baslangic, string bitis)
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/json/siparis/" + apikey + "/" + baslangic + "/" + bitis));
            ////return Ok(new HttpResponseMessage() { Content = new StringContent(GetData(type, "siparis", apikey, baslangic, bitis), Encoding.UTF8, "application/xml") });
            //return Ok(GetData("json", "siparis", apikey, baslangic, bitis));
        }

        [HttpGet("json/{apikey}/{baslangic}/{bitis}")]
        public IActionResult SiparisLogo(string apikey, string type, string baslangic, string bitis)
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/json/siparis/logo/" + apikey + "/" + baslangic + "/" + bitis));
            ////return Ok(new HttpResponseMessage() { Content = new StringContent(GetData(type, "siparis", apikey, baslangic, bitis), Encoding.UTF8, "application/xml") });
            //return Ok(GetData("json", "siparis", apikey, baslangic, bitis));
        }

        [Produces("application/xml")]
        [HttpGet("xml/{apikey}/{baslangic}/{bitis}")]
        public IActionResult Siparis(string apikey, string baslangic, string bitis)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(new GenelController().WcfGetTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/siparis/" + apikey + "/" + baslangic + "/" + bitis));
            //xdoc.LoadXml(GetData("xml", "siparis", apikey, baslangic, bitis));
            return Ok(xdoc);
        }

        [Produces("application/xml")]
        [HttpGet("xml/{apikey}/{baslangic}/{bitis}")]
        public IActionResult SiparisLogo(string apikey, string baslangic, string bitis)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(new GenelController().WcfGetTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/siparis/logo/" + apikey + "/" + baslangic + "/" + bitis));
            //xdoc.LoadXml(GetData("xml", "siparis", apikey, baslangic, bitis));
            return Ok(xdoc);
        }

        [HttpGet("json/{apikey}/{baslangic}/{bitis}")]
        public IActionResult Fatura(string apikey, string type, string baslangic, string bitis)
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/json/fatura/" + apikey + "/" + baslangic + "/" + bitis));
            //return Ok(GetData("json", "fatura", apikey, baslangic, bitis));
        }

        [HttpGet("json/{apikey}/{baslangic}/{bitis}")]
        public IActionResult FaturaLogo(string apikey, string type, string baslangic, string bitis)
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/json/fatura/logo/" + apikey + "/" + baslangic + "/" + bitis));
            //return Ok(GetData("json", "fatura", apikey, baslangic, bitis));
        }

        [Produces("application/xml")]
        [HttpGet("xml/{apikey}/{baslangic}/{bitis}")]
        public IActionResult Fatura(string apikey, string baslangic, string bitis)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(new GenelController().WcfGetTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/fatura/" + apikey + "/" + baslangic + "/" + bitis));
            //xdoc.LoadXml(GetData("xml", "fatura", apikey, baslangic, bitis));
            return Ok(xdoc);
        }

        [Produces("application/xml")]
        [HttpGet("xml/{apikey}/{baslangic}/{bitis}")]
        public IActionResult FaturaLogo(string apikey, string baslangic, string bitis)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(new GenelController().WcfGetTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/fatura/logo/" + apikey + "/" + baslangic + "/" + bitis));
            //xdoc.LoadXml(GetData("xml", "fatura", apikey, baslangic, bitis));
            return Ok(xdoc);
        }

        [HttpGet("json/{apikey}/{sipno}")]
        public IActionResult Fatura2(string apikey, string type, string sipno)
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/json/fatura2/" + apikey + "/" + sipno));
        }

        [HttpGet("json/{apikey}/{sipno}")]
        public IActionResult Fatura2Logo(string apikey, string type, string sipno)
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/json/fatura2/logo/" + apikey + "/" + sipno));
        }

        [Produces("application/xml")]
        [HttpGet("xml/{apikey}/{sipno}")]
        public IActionResult Fatura2(string apikey, string sipno)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(new GenelController().WcfGetTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/fatura2/" + apikey + "/" + sipno));
            return Ok(xdoc);
        }

        [Produces("application/xml")]
        [HttpGet("xml/{apikey}/{sipno}")]
        public IActionResult Fatura2Logo(string apikey, string sipno)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(new GenelController().WcfGetTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/fatura2/logo/" + apikey + "/" + sipno));
            return Ok(xdoc);
        }

        /*
        [HttpGet("{type}/{apikey}/{baslangic}/{bitis}")]
        public IActionResult Siparis(string apikey, string type, string baslangic, string bitis)
        {
            //return Ok(new HttpResponseMessage() { Content = new StringContent(GetData(type, "siparis", apikey, baslangic, bitis), Encoding.UTF8, "application/xml") });
            return Ok(GetData(type, "siparis", apikey, baslangic, bitis));
        }

        [HttpGet("{type}/{apikey}/{baslangic}/{bitis}")]
        public IActionResult Fatura(string apikey, string type, string baslangic, string bitis) => Ok(GetData(type, "fatura", apikey, baslangic, bitis));
        */

        /*private string GetData(string type, string method, string apikey, string baslangic, string bitis)
        {
            try
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/" + type + "/" + method + "/" + apikey + "/" + baslangic + "/" + bitis + "");
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
        }*/
    }
}
