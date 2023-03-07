using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sultanlar.Model.Bayi
{
    public class Bimat
    {
        public void LoadDefaults()
        {
            //Iterate through properties
            foreach (var property in GetType().GetProperties())
            {
                //Iterate through attributes of this property
                foreach (Attribute attr in property.GetCustomAttributes(true))
                {
                    //does this property have [DefaultValueAttribute]?
                    if (attr is DefaultValueAttribute)
                    {
                        //So lets try to load default value to the property
                        DefaultValueAttribute dv = (DefaultValueAttribute)attr;
                        try
                        {
                            //Is it an array?
                            if (property.PropertyType.IsArray)
                            {
                                //Use set value for arrays
                                property.SetValue(this, null, (object[])dv.Value);
                            }
                            else
                            {
                                //Use set value for.. not arrays
                                property.SetValue(this, dv.Value, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            //eat it... Or maybe Debug.Writeline(ex);
                        }
                    }
                }
            }
        }
    }

    public class BimatSiparisDis : Bimat
    {
        public BimatSiparisDis()
        {
            LoadDefaults();
        }

        [XmlAttribute(AttributeName = "DBOP")]
        public string DBOP { get; set; }

        [XmlElement(ElementName = "INTERNAL_REFERENCE"), DefaultValue("")]
        public string INTERNAL_REFERENCE { get; set; }

        [XmlElement(ElementName = "TYPE"), DefaultValue("8")]
        public string TYPE { get; set; }

        [XmlElement(ElementName = "NUMBER")]
        public string belgeno { get; set; }

        [XmlElement(ElementName = "DATE")]
        public string tarih { get; set; }

        [XmlElement(ElementName = "TIME")]
        public string TIME { get; set; }

        [XmlElement(ElementName = "ARP_CODE")]
        public string carino2 { get; set; }

        [XmlElement(ElementName = "POST_FLAGS"), DefaultValue("247")]
        public string POST_FLAGS { get; set; }

        [XmlElement(ElementName = "VAT_RATE"), DefaultValue("")]
        public string VAT_RATE { get; set; }

        [XmlElement(ElementName = "ADD_DISCOUNTS"), DefaultValue("")]
        public string ADD_DISCOUNTS { get; set; }

        [XmlElement(ElementName = "TOTAL_DISCOUNTS")]
        public string TOTAL_DISCOUNTS { get; set; }

        [XmlElement(ElementName = "TOTAL_DISCOUNTED")]
        public string TOTAL_DISCOUNTED { get; set; }

        [XmlElement(ElementName = "TOTAL_VAT")]
        public string TOTAL_VAT { get; set; }

        [XmlElement(ElementName = "TOTAL_GROSS")]
        public string TOTAL_GROSS { get; set; }

        [XmlElement(ElementName = "TOTAL_NET")]
        public string TOTAL_NET { get; set; }

        [XmlElement(ElementName = "CURR_INVOICE"), DefaultValue("1")]
        public string CURR_INVOICE { get; set; }

        [XmlElement(ElementName = "RC_XRATE"), DefaultValue("1")]
        public string RC_XRATE { get; set; }

        [XmlElement(ElementName = "RC_NET")]
        public string RC_NET { get; set; }

        [XmlElement(ElementName = "CREATED_BY"), DefaultValue("1")]
        public string CREATED_BY { get; set; }

        [XmlElement(ElementName = "DATE_CREATED")]
        public string DATE_CREATED { get; set; }

        [XmlElement(ElementName = "HOUR_CREATED")]
        public string HOUR_CREATED { get; set; }

        [XmlElement(ElementName = "MIN_CREATED")]
        public string MIN_CREATED { get; set; }

        [XmlElement(ElementName = "SEC_CREATED")]
        public string SEC_CREATED { get; set; }

        [XmlElement(ElementName = "SALESMANCODE")]
        public string SALESMANCODE { get; set; }

        [XmlElement(ElementName = "CURRSEL_TOTALS"), DefaultValue("2")]
        public string CURRSEL_TOTALS { get; set; }

        [XmlElement(ElementName = "DATA_REFERENCE"), DefaultValue("6")]
        public string DATA_REFERENCE { get; set; }

        public List<BimatSiparisDisDispatch> DISPATCHES { get; set; }

        public List<BimatSiparisDisDetay> TRANSACTIONS { get; set; }

        public List<BimatSiparisDisPayment> PAYMENT_LIST { get; set; }

        [XmlElement(ElementName = "ORGLOGOID"), DefaultValue("")]
        public string ORGLOGOID { get; set; }

        [XmlElement(ElementName = "DEFNFLDSLIST"), DefaultValue("")]
        public string DEFNFLDSLIST { get; set; }

        [XmlElement(ElementName = "DEDUCTIONPART1"), DefaultValue("2")]
        public string DEDUCTIONPART1 { get; set; }

        [XmlElement(ElementName = "DEDUCTIONPART2"), DefaultValue("3")]
        public string DEDUCTIONPART2 { get; set; }

        [XmlElement(ElementName = "DATA_LINK_REFERENCE"), DefaultValue("6")]
        public string DATA_LINK_REFERENCE { get; set; }

        public List<BimatSiparisDisIntel> INTEL_LIST { get; set; }

        [XmlElement(ElementName = "AFFECT_RISK"), DefaultValue("0")]
        public string AFFECT_RISK { get; set; }

        [XmlElement(ElementName = "PREACCLINES"), DefaultValue(" ")]
        public string PREACCLINES { get; set; }

        [XmlElement(ElementName = "DOC_DATE")]
        public string DOC_DATE { get; set; }

        [XmlElement(ElementName = "GUID")]
        public string GUID { get; set; }

        [XmlElement(ElementName = "EDURATION_TYPE"), DefaultValue("0")]
        public string EDURATION_TYPE { get; set; }

        [XmlElement(ElementName = "EINVOICE_TURETPRICESTR"), DefaultValue("")]
        public string EINVOICE_TURETPRICESTR { get; set; }

        [XmlElement(ElementName = "TOTAL_NET_STR"), DefaultValue("")]
        public string TOTAL_NET_STR { get; set; }

        [XmlElement(ElementName = "EXIMVAT"), DefaultValue("0")]
        public string EXIMVAT { get; set; }

        [XmlElement(ElementName = "EARCHIVEDETR_INTPAYMENTTYPE"), DefaultValue("0")]
        public string EARCHIVEDETR_INTPAYMENTTYPE { get; set; }

        public List<BimatSiparisDisOkcInfo> OKCINFO_LIST { get; set; }
    }

    [XmlType("TRANSACTION")]
    public class BimatSiparisDisDetay : Bimat
    {
        public BimatSiparisDisDetay()
        {
            LoadDefaults();
        }

        [XmlElement(ElementName = "INTERNAL_REFERENCE"), DefaultValue("")]
        public string INTERNAL_REFERENCE { get; set; }

        [XmlElement(ElementName = "TYPE"), DefaultValue("0")]
        public string TYPE { get; set; }

        [XmlElement(ElementName = "MASTER_CODE")]
        public string malno { get; set; }

        [XmlElement(ElementName = "DETAIL_LEVEL")]
        public string DETAIL_LEVEL { get; set; }

        [XmlElement(ElementName = "QUANTITY")]
        public string miktar { get; set; }

        [XmlElement(ElementName = "PRICE")]
        public string PRICE { get; set; }

        [XmlElement(ElementName = "TOTAL")]
        public string TOTAL { get; set; }

        [XmlElement(ElementName = "CURR_TRANSACTION"), DefaultValue("1")]
        public string CURR_TRANSACTION { get; set; }

        [XmlElement(ElementName = "RC_XRATE"), DefaultValue("1")]
        public string RC_XRATE { get; set; }

        [XmlElement(ElementName = "DISCOUNT_RATE")]
        public string DISCOUNT_RATE { get; set; }

        [XmlElement(ElementName = "BASE_AMOUNT")]
        public string BASE_AMOUNT { get; set; }

        [XmlElement(ElementName = "COST_DISTR")]
        public string COST_DISTR { get; set; }

        [XmlElement(ElementName = "DISCOUNT_DISTR")]
        public string DISCOUNT_DISTR { get; set; }

        [XmlElement(ElementName = "UNIT_CODE")]
        public string UNIT_CODE { get; set; }

        [XmlElement(ElementName = "UNIT_CONV1"), DefaultValue("1")]
        public string UNIT_CONV1 { get; set; }

        [XmlElement(ElementName = "UNIT_CONV2"), DefaultValue("1")]
        public string UNIT_CONV2 { get; set; }

        [XmlElement(ElementName = "VAT_RATE")]
        public string VAT_RATE { get; set; }

        [XmlElement(ElementName = "VAT_AMOUNT")]
        public string VAT_AMOUNT { get; set; }

        [XmlElement(ElementName = "VAT_BASE")]
        public string VAT_BASE { get; set; }

        [XmlElement(ElementName = "BILLED"), DefaultValue("1")]
        public string BILLED { get; set; }

        [XmlElement(ElementName = "TOTAL_NET")]
        public string TOTAL_NET { get; set; }

        [XmlElement(ElementName = "DATA_REFERENCE"), DefaultValue("15")]
        public string DATA_REFERENCE { get; set; }

        [XmlElement(ElementName = "DISPATCH_NUMBER"), DefaultValue("")]
        public string DISPATCH_NUMBER { get; set; }

        [XmlElement(ElementName = "DETAILS"), DefaultValue(" ")]
        public string DETAILS { get; set; }

        [XmlElement(ElementName = "DIST_ORD_REFERENCE"), DefaultValue("")]
        public string DIST_ORD_REFERENCE { get; set; }

        public List<BimatSiparisDisCmpInfo> CAMPAIGN_INFOS { get; set; }

        [XmlElement(ElementName = "MULTI_ADD_TAX"), DefaultValue("1")]
        public string MULTI_ADD_TAX { get; set; }

        [XmlElement(ElementName = "ADDTAXLINELIST"), DefaultValue(" ")]
        public string ADDTAXLINELIST { get; set; }

        [XmlElement(ElementName = "EDT_CURR"), DefaultValue("160")]
        public string EDT_CURR { get; set; }

        [XmlElement(ElementName = "EDT_PRICE")]
        public string EDT_PRICE { get; set; }

        [XmlElement(ElementName = "ORGLOGOID"), DefaultValue(" ")]
        public string ORGLOGOID { get; set; }

        [XmlElement(ElementName = "SALEMANCODE"), DefaultValue("")]
        public string SALEMANCODE { get; set; }

        [XmlElement(ElementName = "DEFNFLDSLIST"), DefaultValue(" ")]
        public string DEFNFLDSLIST { get; set; }

        [XmlElement(ElementName = "MONTH")]
        public string MONTH { get; set; }

        [XmlElement(ElementName = "YEAR")]
        public string YEAR { get; set; }

        [XmlElement(ElementName = "PREACCLINES"), DefaultValue(" ")]
        public string PREACCLINES { get; set; }

        [XmlElement(ElementName = "DEDUCTION_PART1")]
        public string DEDUCTION_PART1 { get; set; }

        [XmlElement(ElementName = "DEDUCTION_PART2")]
        public string DEDUCTION_PART2 { get; set; }

        [XmlElement(ElementName = "GUID")]
        public string GUID { get; set; }

        [XmlElement(ElementName = "MASTER_DEF")]
        public string malacik { get; set; }

        [XmlElement(ElementName = "PARENTLNREF")]
        public string PARENTLNREF { get; set; }

        [XmlElement(ElementName = "FOREIGN_TRADE_TYPE"), DefaultValue("0")]
        public string FOREIGN_TRADE_TYPE { get; set; }

        [XmlElement(ElementName = "DISTRIBUTION_TYPE_WHS"), DefaultValue("0")]
        public string DISTRIBUTION_TYPE_WHS { get; set; }

        [XmlElement(ElementName = "DISTRIBUTION_TYPE_FNO"), DefaultValue("0")]
        public string DISTRIBUTION_TYPE_FNO { get; set; }
    }

    [XmlType("DISPATCH")]
    public class BimatSiparisDisDispatch : Bimat
    {
        public BimatSiparisDisDispatch()
        {
            LoadDefaults();
        }

        [XmlElement(ElementName = "INTERNAL_REFERENCE"), DefaultValue("")]
        public string INTERNAL_REFERENCE { get; set; }

        [XmlElement(ElementName = "TYPE"), DefaultValue("8")]
        public string TYPE { get; set; }

        [XmlElement(ElementName = "NUMBER"), DefaultValue("")]
        public string NUMBER { get; set; }

        [XmlElement(ElementName = "DATE")]
        public string DATE { get; set; }

        [XmlElement(ElementName = "TIME"), DefaultValue("")]
        public string TIME { get; set; }

        [XmlElement(ElementName = "INVOICE_NUMBER")]
        public string INVOICE_NUMBER { get; set; }

        [XmlElement(ElementName = "ARP_CODE")]
        public string ARP_CODE { get; set; }

        [XmlElement(ElementName = "INVOICED"), DefaultValue("1")]
        public string INVOICED { get; set; }

        [XmlElement(ElementName = "ADD_DISCOUNTS"), DefaultValue("")]
        public string ADD_DISCOUNTS { get; set; }

        [XmlElement(ElementName = "TOTAL_DISCOUNTS")]
        public string TOTAL_DISCOUNTS { get; set; }

        [XmlElement(ElementName = "TOTAL_DISCOUNTED")]
        public string TOTAL_DISCOUNTED { get; set; }

        [XmlElement(ElementName = "TOTAL_VAT")]
        public string TOTAL_VAT { get; set; }

        [XmlElement(ElementName = "TOTAL_GROSS")]
        public string TOTAL_GROSS { get; set; }

        [XmlElement(ElementName = "TOTAL_NET")]
        public string TOTAL_NET { get; set; }

        [XmlElement(ElementName = "RC_RATE"), DefaultValue("1")]
        public string RC_RATE { get; set; }

        [XmlElement(ElementName = "RC_NET")]
        public string RC_NET { get; set; }

        [XmlElement(ElementName = "CREATED_BY"), DefaultValue("1")]
        public string CREATED_BY { get; set; }

        [XmlElement(ElementName = "DATE_CREATED")]
        public string DATE_CREATED { get; set; }

        [XmlElement(ElementName = "HOUR_CREATED")]
        public string HOUR_CREATED { get; set; }

        [XmlElement(ElementName = "MIN_CREATED")]
        public string MIN_CREATED { get; set; }

        [XmlElement(ElementName = "SEC_CREATED")]
        public string SEC_CREATED { get; set; }

        [XmlElement(ElementName = "SALESMANCODE")]
        public string SALESMANCODE { get; set; }

        [XmlElement(ElementName = "CURRSEL_TOTALS"), DefaultValue("2")]
        public string CURRSEL_TOTALS { get; set; }

        [XmlElement(ElementName = "DATA_REFERENCE"), DefaultValue("6")]
        public string DATA_REFERENCE { get; set; }

        [XmlElement(ElementName = "ORIG_NUMBER"), DefaultValue("")]
        public string ORIG_NUMBER { get; set; }

        [XmlElement(ElementName = "ORGLOGOID"), DefaultValue("")]
        public string ORGLOGOID { get; set; }

        [XmlElement(ElementName = "CURR_TRANSACTION"), DefaultValue("1")]
        public string CURR_TRANSACTION { get; set; }

        [XmlElement(ElementName = "DEDUCTIONPART1"), DefaultValue("2")]
        public string DEDUCTIONPART1 { get; set; }

        [XmlElement(ElementName = "DEDUCTIONPART2"), DefaultValue("3")]
        public string DEDUCTIONPART2 { get; set; }

        [XmlElement(ElementName = "AFFECT_RISK"), DefaultValue("0")]
        public string AFFECT_RISK { get; set; }

        [XmlElement(ElementName = "DISP_STATUS"), DefaultValue("1")]
        public string DISP_STATUS { get; set; }

        [XmlElement(ElementName = "GUID"), DefaultValue("")]
        public string GUID { get; set; }

        [XmlElement(ElementName = "SHIP_DATE")]
        public string SHIP_DATE { get; set; }

        [XmlElement(ElementName = "SHIP_TIME")]
        public string SHIP_TIME { get; set; }

        [XmlElement(ElementName = "DOC_DATE")]
        public string DOC_DATE { get; set; }

        [XmlElement(ElementName = "DOC_TIME")]
        public string DOC_TIME { get; set; }
    }

    [XmlType("PAYMENT")]
    public class BimatSiparisDisPayment : Bimat
    {
        public BimatSiparisDisPayment()
        {
            LoadDefaults();
        }

        [XmlElement(ElementName = "INTERNAL_REFERENCE"), DefaultValue("")]
        public string INTERNAL_REFERENCE { get; set; }

        [XmlElement(ElementName = "DATE")]
        public string DATE { get; set; }

        [XmlElement(ElementName = "MODULENR"), DefaultValue("4")]
        public string MODULENR { get; set; }

        [XmlElement(ElementName = "TRCODE"), DefaultValue("8")]
        public string TRCODE { get; set; }

        [XmlElement(ElementName = "TOTAL")]
        public string TOTAL { get; set; }

        [XmlElement(ElementName = "PROCDATE")]
        public string PROCDATE { get; set; }

        [XmlElement(ElementName = "REPORTRATE"), DefaultValue("1")]
        public string REPORTRATE { get; set; }

        [XmlElement(ElementName = "DATA_REFERENCE"), DefaultValue("0")]
        public string DATA_REFERENCE { get; set; }

        [XmlElement(ElementName = "DISCOUNT_DUEDATE")]
        public string DISCOUNT_DUEDATE { get; set; }

        [XmlElement(ElementName = "PAY_NO"), DefaultValue("1")]
        public string PAY_NO { get; set; }

        [XmlElement(ElementName = "DISCTRLIST"), DefaultValue(" ")]
        public string DISCTRLIST { get; set; }

        [XmlElement(ElementName = "DISCTRDELLIST"), DefaultValue("0")]
        public string DISCTRDELLIST { get; set; }
    }

    [XmlType("INTEL")]
    public class BimatSiparisDisIntel : Bimat
    {
        public BimatSiparisDisIntel()
        {
            LoadDefaults();
        }

        [XmlElement(ElementName = "LOGICALREF"), DefaultValue("0")]
        public string LOGICALREF { get; set; }
    }

    [XmlType("OKCINFO")]
    public class BimatSiparisDisOkcInfo : Bimat
    {
        public BimatSiparisDisOkcInfo()
        {
            LoadDefaults();
        }

        [XmlElement(ElementName = "INTERNAL_REFERENCE"), DefaultValue("")]
        public string INTERNAL_REFERENCE { get; set; }
    }

    [XmlType("CAMPAIGN_INFO")]
    public class BimatSiparisDisCmpInfo : Bimat
    {
        public BimatSiparisDisCmpInfo()
        {
            LoadDefaults();
        }
    }

    [XmlRoot(ElementName = "SALES_INVOICES")]
    public class BimatFaturalarDis
    {
        [XmlElement(ElementName = "INVOICE", Order = 1)]
        public List<BimatSiparisDis> Faturalar { get; set; }
    }
}
