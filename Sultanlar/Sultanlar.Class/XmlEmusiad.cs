using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Class
{
    [XmlRoot(ElementName = "feed")]
    public class XmlEmusiad
    {
        public string title { get; set; }
        public string updated { get; set; }
        public string lastBuildDate { get; set; }
        [XmlElement(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
        public List<Entry> entry { get; set; }
    }

    public class Entry
    {
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public int id { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string title { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string brand { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string google_product_category { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public int quantity { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string condition { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string price { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string link { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string image_link { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string availability { get; set; }
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public string summary { get; set; } // <![CDATA[ Açıklama ]]>
        [XmlElement(Namespace = "http://base.google.com/ns/1.0")]
        public Emusiad emusiad { get; set; }
    }

    public class Emusiad
    {
        public string site_category { get; set; }
        public string is_service { get; set; }
        public string is_enabled { get; set; }
        public string is_purchasable { get; set; }
        public string is_onsale { get; set; }
        public string special_price { get; set; }
        public string reseller_price { get; set; }
        public string tax_included { get; set; }
        public double tax_rate { get; set; }
        public string short_title { get; set; }
        public string short_description { get; set; } // <![CDATA[ Kısa Açıklama ]]>
        public string seo_description { get; set; }
        public string seo_keywords { get; set; }

    }
}
