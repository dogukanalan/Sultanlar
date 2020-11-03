using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class odeme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbTamamla_Click(object sender, EventArgs e)
        {
            string amount = Convert.ToDecimal(Session["OdemeTutari"]).ToString("N2").Replace(".", "").Replace(",", "");
            string Numara = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strNumara);
            string Guvenlik = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strGuvenlik);
            string Yil = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strYil);
            string Ay = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strAy);

            string orderid = "101010101a" + DateTime.Now.Year.ToString() 
                + (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString())
                + (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString())
                + (DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString())
                + (DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString())
                + (DateTime.Now.Second.ToString().Length == 1 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
            string maskedpan = Numara.Substring(0, 6) + "***" + Numara.Substring(12);

            string xmldata = "<posnetRequest>" +
"<mid>6701633142</mid>" +
"<tid>67124469</tid>" +
"<tranDateRequired>1</tranDateRequired>" +
"<sale>" +
"<amount>" + amount.Replace(".", "") + "</amount>" +
"<ccno>" + Numara + "</ccno>" +
"<currencyCode>TL</currencyCode>" +
"<cvc>" + Guvenlik + "</cvc>" +
"<expDate>" + Yil + Ay + "</expDate>" +
"<orderID>" + orderid + "</orderID>" +
"<installment>00</installment>" +
"</sale>" +
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
            string authCode = string.Empty, hostlogkey = string.Empty, respCode = string.Empty, respText = string.Empty, tranDate = string.Empty;

            try
            {
                authCode = xdoc.GetElementsByTagName("authCode")[0].InnerText;
                hostlogkey = xdoc.GetElementsByTagName("hostlogkey")[0].InnerText;
                tranDate = xdoc.GetElementsByTagName("tranDate")[0].InnerText;
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

            Response.Redirect("odemesayfasi3dpay.aspx?approved=" + approved + "&authCode=" + authCode + "&hostlogkey=" + hostlogkey + 
                "&respCode=" + respCode + "&respText=" + respText + "&tranDate=" + tranDate + "&orderid=" + orderid + "&maskedpan=" + maskedpan, true);
        }
    }
}