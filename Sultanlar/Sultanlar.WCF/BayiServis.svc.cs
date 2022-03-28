using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BayiServis" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BayiServis.svc or BayiServis.svc.cs at the Solution Explorer and start debugging.
    public class BayiServis : IBayiServis
    {
        public XmlDocument PostXml(XmlDocument icerik, string Bayikod, string Satis, string YilAd, string Yil, string AyAd, string Ay)
        {
            XmlDocument donendeger = new XmlDocument();

            string xml = icerik.OuterXml;
            DataSet ds = new DataSet();
            ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            DataTable dt = ds.Tables[0];

            string tabloadi = "tbl_" + Bayikod + "_" + Satis;

            if (Satis == "Satis") // satış ise son üç ayı silmemiz lazım, tabloyaz ve veriyaz da sadece parametrede gelen ayı siliyor
                DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE " + YilAd + "=" + Yil + " AND " + AyAd + ">=" + (Convert.ToInt32(Ay) - 3).ToString());

            if (DisVeri.TabloYaz(tabloadi, dt, YilAd, Yil, AyAd, Ay))
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>true</basarili></sonuc>");
            else
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>false</basarili></sonuc>");

            return donendeger;
        }
    }
}
