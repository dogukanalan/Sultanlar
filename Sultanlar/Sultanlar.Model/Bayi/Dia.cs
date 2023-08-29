using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Model.Bayi
{
    public class Dia
    {

    }

    //[XmlType("Invoice")]
    public class DiaSiparisDis : Dia
    {
        [XmlElement(ElementName = "UBLExtensions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public string UBLExtensions { get; set; }

        [XmlElement(ElementName = "UBLVersionID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string UBLVersionID { get; set; }

        [XmlElement(ElementName = "CustomizationID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CustomizationID { get; set; }

        [XmlElement(ElementName = "ProfileID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ProfileID { get; set; }

        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ID { get; set; }

        [XmlElement(ElementName = "CopyIndicator", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CopyIndicator { get; set; }

        [XmlElement(ElementName = "UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string UUID { get; set; }

        [XmlElement(ElementName = "IssueDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueDate { get; set; }

        [XmlElement(ElementName = "IssueTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueTime { get; set; }

        [XmlElement(ElementName = "InvoiceTypeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string InvoiceTypeCode { get; set; }

        [XmlElement(ElementName = "Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Note { get; set; }

        [XmlElement(ElementName = "DocumentCurrencyCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentCurrencyCode { get; set; }

        [XmlElement(ElementName = "LineCountNumeric", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string LineCountNumeric { get; set; }

        [XmlElement(ElementName = "AdditionalDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string AdditionalDocumentReference { get; set; }

        [XmlElement(ElementName = "Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string Signature { get; set; }

        [XmlElement(ElementName = "AccountingSupplierParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string AccountingSupplierParty { get; set; }

        [XmlElement(ElementName = "AccountingCustomerParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string AccountingCustomerParty { get; set; }

        [XmlElement(ElementName = "PaymentMeans", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string PaymentMeans { get; set; }

        [XmlElement(ElementName = "TaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string TaxTotal { get; set; }

        [XmlElement(ElementName = "LegalMonetaryTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public string LegalMonetaryTotal { get; set; }

        [XmlElement(ElementName = "BuyerCustomerParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaBuyerCustomerParty BuyerCustomerPartys { get; set; }

        [XmlElement(ElementName = "InvoiceLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<DiaSiparisDisDetay> InvoiceLines { get; set; }
    }

    public class DiaBuyerCustomerParty : Dia
    {
        [XmlElement(ElementName = "Party", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaParty Party { get; set; }
    }

    public class DiaParty : Dia
    {
        [XmlElement(ElementName = "PartyIdentification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaPartyIdentification PartyIdentification { get; set; }
    }

    public class DiaPartyIdentification : Dia
    {
        [XmlElement(ElementName = "ID")]
        public DiaPartyID ID { get; set; }

        [XmlAttribute(AttributeName = "schemeID")]
        public string schemeID { get; set; }
    }

    public class DiaPartyID : Dia
    {
        [XmlText]
        public string ID { get; set; }
    }

    public class DiaSiparisDisDetay : Dia
    {
        [XmlElement(ElementName = "ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ID { get; set; }

        [XmlElement(ElementName = "Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string[] Note { get; set; }

        [XmlElement(ElementName = "InvoicedQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DiaInvoicedQuantity InvoicedQuantity { get; set; }

        [XmlElement(ElementName = "LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DiaLineExtensionAmount LineExtensionAmount { get; set; }

        [XmlElement(ElementName = "DiaTaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaTaxTotal TaxTotal { get; set; }

        [XmlElement(ElementName = "Item", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaItem Item { get; set; }

        [XmlElement(ElementName = "Price", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaPrice Price { get; set; }
    }

    public class DiaTaxTotal : Dia
    {
        [XmlElement(ElementName = "TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DiaTaxAmount TaxAmount { get; set; }

        [XmlElement(ElementName = "DiaTaxSubtotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaTaxSubtotal TaxSubtotal { get; set; }
    }

    public class DiaTaxSubtotal : Dia
    {
        [XmlElement(ElementName = "TaxableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string TaxableAmount { get; set; }

        [XmlElement(ElementName = "TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DiaTaxAmount TaxAmount { get; set; }

        [XmlElement(ElementName = "CalculationSequenceNumeric", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CalculationSequenceNumeric { get; set; }

        [XmlElement(ElementName = "Percent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Percent { get; set; }

        [XmlElement(ElementName = "DiaTaxCategory", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaTaxCategory TaxCategory { get; set; }
    }

    public class DiaTaxCategory
    {

        [XmlElement(ElementName = "DiaTaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DiaTaxScheme DiaTaxScheme { get; set; }
    }

    public class DiaTaxScheme : Dia
    {
        [XmlElement(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name { get; set; }

        [XmlElement(ElementName = "TaxTypeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string TaxTypeCode { get; set; }
    }

    public class DiaItem : Dia
    {
        [XmlElement(ElementName = "Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name { get; set; }
    }

    public class DiaPrice
    {
        [XmlElement(ElementName = "PriceAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DiaPriceAmount PriceAmount { get; set; }
    }

    [XmlType("InvoicedQuantity")]
    public class DiaInvoicedQuantity
    {
        [XmlText]
        public string InvoicedQuantity { get; set; }

        [XmlAttribute(AttributeName = "unitCode")]
        public string unitCode { get; set; }
    }

    [XmlType("LineExtensionAmount")]
    public class DiaLineExtensionAmount
    {
        [XmlText]
        public string LineExtensionAmount { get; set; }

        [XmlAttribute(AttributeName = "currencyID")]
        public string currencyID { get; set; }
    }

    [XmlType("TaxAmount")]
    public class DiaTaxAmount
    {
        [XmlText]
        public string TaxAmount { get; set; }

        [XmlAttribute(AttributeName = "currencyID")]
        public string currencyID { get; set; }
    }

    [XmlType("PriceAmount")]
    public class DiaPriceAmount
    {
        [XmlText]
        public string PriceAmount { get; set; }

        [XmlAttribute(AttributeName = "currencyID")]
        public string currencyID { get; set; }
    }

    [XmlRoot(ElementName = "Invoices")]
    public class DiaFaturalarDis
    {
        [XmlElement(ElementName = "Invoice", Order = 1)]
        public List<DiaSiparisDis> Faturalar { get; set; }
    }
}
