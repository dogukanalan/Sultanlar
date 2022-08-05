using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
    }
}
