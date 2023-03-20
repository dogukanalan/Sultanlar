﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Sultanlar.WCF.komsuC0021 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ZwebKomsuF002Binding", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ZwebKomsuS_002[]))]
    public partial class ZwebKomsuF002Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ZwebKomsuF002OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ZwebKomsuF002Service() {
            this.Url = global::Sultanlar.WCF.Properties.Settings.Default.Sultanlar_WCF_komsuC0011_ZwebKomsuF001Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ZwebKomsuF002CompletedEventHandler ZwebKomsuF002Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sap.com/ZwebKomsuF002", RequestNamespace="urn:sap-com:document:sap:soap:functions:mc-style", ResponseElementName="ZwebKomsuF002Result", ResponseNamespace="urn:sap-com:document:sap:soap:functions:mc-style", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("EtExport", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZwebKomsuS_002[] ZwebKomsuF002([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string IvMatnr) {
            object[] results = this.Invoke("ZwebKomsuF002", new object[] {
                        IvMatnr});
            return ((ZwebKomsuS_002[])(results[0]));
        }
        
        /// <remarks/>
        public void ZwebKomsuF002Async(string IvMatnr) {
            this.ZwebKomsuF002Async(IvMatnr, null);
        }
        
        /// <remarks/>
        public void ZwebKomsuF002Async(string IvMatnr, object userState) {
            if ((this.ZwebKomsuF002OperationCompleted == null)) {
                this.ZwebKomsuF002OperationCompleted = new System.Threading.SendOrPostCallback(this.OnZwebKomsuF002OperationCompleted);
            }
            this.InvokeAsync("ZwebKomsuF002", new object[] {
                        IvMatnr}, this.ZwebKomsuF002OperationCompleted, userState);
        }
        
        private void OnZwebKomsuF002OperationCompleted(object arg) {
            if ((this.ZwebKomsuF002Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ZwebKomsuF002Completed(this, new ZwebKomsuF002CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZwebKomsuS_002 {
        
        private string productCodeField;
        
        private string productNameField;
        
        private string brandField;
        
        private string categoryField;
        
        private string productDetailField;
        
        private string taxRateField;
        
        private string stockUnitField;
        
        private string priceUnitField;
        
        private string associationCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ProductCode {
            get {
                return this.productCodeField;
            }
            set {
                this.productCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ProductName {
            get {
                return this.productNameField;
            }
            set {
                this.productNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Brand {
            get {
                return this.brandField;
            }
            set {
                this.brandField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ProductDetail {
            get {
                return this.productDetailField;
            }
            set {
                this.productDetailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TaxRate {
            get {
                return this.taxRateField;
            }
            set {
                this.taxRateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string StockUnit {
            get {
                return this.stockUnitField;
            }
            set {
                this.stockUnitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PriceUnit {
            get {
                return this.priceUnitField;
            }
            set {
                this.priceUnitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AssociationCode {
            get {
                return this.associationCodeField;
            }
            set {
                this.associationCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void ZwebKomsuF002CompletedEventHandler(object sender, ZwebKomsuF002CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZwebKomsuF002CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ZwebKomsuF002CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZwebKomsuS_002[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZwebKomsuS_002[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591