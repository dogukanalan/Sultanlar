using System;
using System.Collections;
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

            DateTime baslangic = DateTime.Now;

            string xml = icerik.OuterXml;
            DataSet ds = new DataSet();
            ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            DataTable dt = ds.Tables[0];

            string tabloadi = "tbl_" + Bayikod + "_" + Satis;

            if (Bayikod == "1071593" || Bayikod == "1052689" || Bayikod == "1018538") // kaan, peker, yılmaz
            {
                if (Satis == "Satis")
                {
                    DateTime bas = Convert.ToDateTime(Yil + "." + (Ay.Length > 1 ? Ay : "0" + Ay) + ".01");
                    DisVeri.ExecNQwp("DELETE FROM " + tabloadi + " WHERE CONVERT(datetime,[CEKIM_TARIH]) >= @TARIH", new ArrayList() { "TARIH" }, new object[] { bas });
                }
                else
                {
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
                }
            }
            else
            {
                if (Satis == "Satis") // satış ise son üç ayı silmemiz lazım, tabloyaz ve veriyaz da sadece parametrede gelen ayı siliyor
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE " + YilAd + "=" + Yil + " AND " + AyAd + ">=" + (Convert.ToInt32(Ay) - 3).ToString());
                else
                    DisVeri.ExecNQ("DELETE FROM " + tabloadi);
            }


            if (DisVeri.TabloYaz(tabloadi, dt, YilAd, Yil, AyAd, Ay, false))
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>true</basarili></sonuc>");
            else
                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>false</basarili></sonuc>");

            SAPs.BayiLogYaz("bayi win servis xml " + Satis, true, Bayikod + " nolu bayi " + Yil + "-" + Ay + " dönemi. Gelen satır: " + dt.Rows.Count.ToString(), baslangic, DateTime.Now);

            return donendeger;
        }
    }
}
