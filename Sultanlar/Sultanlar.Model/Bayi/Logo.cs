using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Model.Bayi
{
    public class LogoGo : Defaults
    {
    }

    public class LogoGoSiparisDis : LogoGo
    {
        public LogoGoSiparisDis()
        {
            LoadDefaults();
        }

        [XmlAttribute(AttributeName = "DBOP")]
        public string DBOP { get; set; }

        [XmlElement(ElementName = "TYPE")]
        public string TYPE { get; set; }

        [XmlElement(ElementName = "NUMBER")]
        public string NUMBER { get; set; }

        [XmlElement(ElementName = "DOC_NUMBER")]
        public string DOC_NUMBER { get; set; }

        [XmlElement(ElementName = "AUXIL_CODE")]
        public string AUXIL_CODE { get; set; }

        [XmlElement(ElementName = "AUTH_CODE")]
        public string AUTH_CODE { get; set; }

        [XmlElement(ElementName = "NOTES1")]
        public string NOTES1 { get; set; }

        [XmlElement(ElementName = "DATE")]
        public string DATE { get; set; }

        [XmlElement(ElementName = "DOC_DATE")]
        public string DOC_DATE { get; set; }

        //[XmlElement(ElementName = "DATE_CREATED")]
        //public string DATE_CREATED { get; set; }

        //[XmlElement(ElementName = "HOUR_CREATED")]
        //public string HOUR_CREATED { get; set; }

        //[XmlElement(ElementName = "MIN_CREATED")]
        //public string MIN_CREATED { get; set; }

        //[XmlElement(ElementName = "SEC_CREATED")]
        //public string SEC_CREATED { get; set; }

        [XmlElement(ElementName = "ARP_CODE")]
        public string ARP_CODE { get; set; }

        [XmlElement(ElementName = "SALESMAN_CODE")]
        public string SALESMAN_CODE { get; set; }

        [XmlElement(ElementName = "TRADING_GRP")]
        public string TRADING_GRP { get; set; }

        [XmlElement(ElementName = "PAYMENT_CODE")]
        public string PAYMENT_CODE { get; set; }

        [XmlElement(ElementName = "EINVOICE")]
        public string EINVOICE { get; set; }

        public List<LogoGoSiparisDisDetay> TRANSACTIONS { get; set; }
        public List<LogoGoSiparisDisDispatch> DISPATCHES { get; set; }
    }

    [XmlType("DISPATCH")]
    public class LogoGoSiparisDisDispatch : Bimat
    {
        [XmlElement(ElementName = "TYPE")]
        public string TYPE { get; set; }

        [XmlElement(ElementName = "NUMBER")]
        public string NUMBER { get; set; }

        [XmlElement(ElementName = "DOC_NUMBER")]
        public string DOC_NUMBER { get; set; }

        [XmlElement(ElementName = "NOTES1")]
        public string NOTES1 { get; set; }

        [XmlElement(ElementName = "DATE")]
        public string DATE { get; set; }

        [XmlElement(ElementName = "DOC_DATE")]
        public string DOC_DATE { get; set; }

        [XmlElement(ElementName = "ARP_CODE")]
        public string ARP_CODE { get; set; }

        [XmlElement(ElementName = "EINVOICE")]
        public string EINVOICE { get; set; }

        [XmlElement(ElementName = "DISP_STATUS")]
        public string DISP_STATUS { get; set; }
    }

    [XmlType("TRANSACTION")]
    public class LogoGoSiparisDisDetay : LogoGo
    {

        [XmlElement(ElementName = "TYPE")]
        public string TYPE { get; set; }

        [XmlElement(ElementName = "MASTER_CODE")]
        public string MASTER_CODE { get; set; }

        [XmlElement(ElementName = "QUANTITY")]
        public string QUANTITY { get; set; }

        [XmlElement(ElementName = "PRICE")]
        public string PRICE { get; set; }

        [XmlElement(ElementName = "UNIT_CODE")]
        public string UNIT_CODE { get; set; }

        [XmlElement(ElementName = "VAT_RATE")]
        public string VAT_RATE { get; set; }

        [XmlElement(ElementName = "PAYMENT_CODE")]
        public string PAYMENT_CODE { get; set; }

        [XmlElement(ElementName = "DATA_REFERENCE")]
        public string DATA_REFERENCE { get; set; }

        [XmlElement(ElementName = "DISCOUNT_RATE")]
        public string DISCOUNT_RATE { get; set; }

        [XmlElement(ElementName = "PARENTLNREF")]
        public string PARENTLNREF { get; set; }
    }

    [XmlRoot(ElementName = "SALES_INVOICES")]
    public class LogoGoFaturalarDis
    {
        [XmlElement(ElementName = "INVOICE", Order = 1)]
        public List<LogoGoSiparisDis> Faturalar { get; set; }
    }
}
