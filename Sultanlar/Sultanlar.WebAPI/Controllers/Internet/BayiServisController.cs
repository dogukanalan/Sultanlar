using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        [HttpGet("json")]
        public IActionResult Deneme()
        {
            return Ok(new GenelController().WcfGetToJSON("http://www.ittihadteknoloji.com.tr/wcf/general.svc/web/json/View/Get?sifre=rapor2020&name=vw_Web-Satis-Rapor-TP-Excele&paramn=B%C3%96LGE;YIL&paramv=EGE%20B%C3%96LGE;2023"));
            //return Ok(GetData("json", "fatura", apikey, baslangic, bitis));
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

        [HttpGet("{apikey}/{muskod}/{malkod}")]
        public IActionResult JsonFiyatIskonto(string apikey, string muskod, string malkod)
        {
            cariHesaplarBayikodlar chb = new cariHesaplarBayikodlar().GetObject(apikey);
            cariHesaplar ch = new cariHesaplar().GetObjectTPByMusKod(chb.GMREF, muskod);

            hareket(apikey, "JsonFiyatIskonto", "muskod:" + muskod, "malkod:" + malkod, "", "", "", HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return Ok(new SiparisProvider().IsksTP(ch.SMREF, 4, Convert.ToInt32(malkod), DateTime.Now));
        }

        [Produces("application/xml")]
        [HttpGet("{apikey}/{muskod}/{malkod}")]
        public IActionResult XmlFiyatIskonto(string apikey, string muskod, string malkod)
        {
            cariHesaplarBayikodlar chb = new cariHesaplarBayikodlar().GetObject(apikey);
            cariHesaplar ch = new cariHesaplar().GetObjectTPByMusKod(chb.GMREF, muskod);
            SiparisIsks isks = new SiparisProvider().IsksTP(ch.SMREF, 4, Convert.ToInt32(malkod), DateTime.Now);

            XmlDocument xdoc = new XmlDocument();
            XDocument doc = new XDocument(new XElement("kosullar",
                                               new XElement("fiyat", isks.fiyat.ToString("N2")),
                                               new XElement("isk1", isks.isk1.ToString("N2")),
                                               new XElement("isk2", isks.isk2.ToString("N2")),
                                               new XElement("isk3", isks.isk3.ToString("N2")),
                                               new XElement("isk4", isks.isk4.ToString("N2"))));


            xdoc.LoadXml(doc.ToString());

            hareket(apikey, "XmlFiyatIskonto", "muskod:" + muskod, "malkod:" + malkod, "", "", "", HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return Ok(xdoc);
        }

        [Produces("application/xml")]
        [HttpGet("{apikey}")]
        public IActionResult xmlDonemStandart(string apikey)
        {
            XmlDocument xdoc = new XmlDocument();
            cariHesaplarBayikodlar chb = new cariHesaplarBayikodlar().GetObject(apikey);
            if (chb.GMREF != 0)
            {
                DataTable dt = aktiviteler.getCustomData("sp_z_TpBayiDonemFiyatIsk", new ArrayList(), new SqlDbType[] { }, new ArrayList(), "Malzeme");
                DataSet ds = new DataSet("Standartlar");
                ds.Tables.Add(dt);

                xdoc.LoadXml(ds.GetXml());
            }

            hareket(apikey, "xmlDonemStandart", "", "", "", "", "", HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return Ok(xdoc);
        }

        [Produces("application/xml")]
        [HttpGet("{apikey}")]
        public IActionResult xmlDonemKampanya(string apikey)
        {
            XmlDocument xdoc = new XmlDocument();
            cariHesaplarBayikodlar chb = new cariHesaplarBayikodlar().GetObject(apikey);
            if (chb.GMREF != 0)
            {
                DataTable dt = aktiviteler.getCustomData("sp_z_TpBayiDonemFiyatIsk2", new ArrayList() { "API" }, new SqlDbType[] { SqlDbType.NVarChar }, new ArrayList() { apikey }, "Musteri");
                DataSet ds = new DataSet("Kampanyalar");
                ds.Tables.Add(dt);

                xdoc.LoadXml(ds.GetXml());
            }

            hareket(apikey, "xmlDonemKampanya", "", "", "", "", "", HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return Ok(xdoc);
        }

        private void hareket(string api, string servis, string param1, string param2, string param3, string param4, string aciklama, string ipadres)
        {
            aktiviteler.ExecNQ("sp_TP_BayiServisLogEkle",
                new ArrayList() { "API", "TARIH", "SERVIS", "PARAMETRE1", "PARAMETRE2", "PARAMETRE3", "PARAMETRE4", "ACIKLAMA", "IPADRES", "ID" },
                new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int },
                new ArrayList() { api, DateTime.Now, servis, param1, param2, param3, param4, aciklama, ipadres, 0 });
        }
    }
}
