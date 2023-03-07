using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Model.Xml
{
    [XmlRoot(ElementName = "SultanlarInvoicesXml")]
    public class XmlFaturalarDis
    {
        [XmlElement(ElementName = "Fatura", Order = 1)]
        public List<XmlFaturaDis> Faturalar { get; set; }
    }

    [XmlRoot(ElementName = "SultanlarFaturalar")]
    public class FaturalarDis
    {
        [XmlElement(ElementName = "fatura", Order = 1)]
        public List<SiparisDis> Faturalar { get; set; }
    }

    public class XmlFaturaDis
    {
        public string FAT_NO { get; set; }
        public string FAT_NO_MTB { get; set; }
        public DateTime FAT_TAR { get; set; }
        public string PER_KOD { get; set; }
        public string PER_TEM { get; set; }
        public string SUBE { get; set; }
        public List<XmlFaturaDisDetay> Kalemler { get; set; }
    }

    [XmlType("Kalem")]
    public class XmlFaturaDisDetay
    {
        public int MAL_KOD { get; set; }
        public string MALZEME { get; set; }
        public double ADET_TOP { get; set; }
        public double KOLI_TOP { get; set; }
        public double ISK_TOP { get; set; }
        public double NET_TOP { get; set; }
        public double KDV_TOP { get; set; }
        public double NETKDV_TOP { get; set; }
    }
}
