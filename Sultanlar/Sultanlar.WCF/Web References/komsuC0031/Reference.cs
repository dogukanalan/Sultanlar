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

namespace Sultanlar.WCF.komsuC0031 {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ZwebKomsuF003Binding", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ZwebKomsuS_003[]))]
    public partial class ZwebKomsuF003Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ZwebKomsuF003OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ZwebKomsuF003Service() {
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
        public event ZwebKomsuF003CompletedEventHandler ZwebKomsuF003Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sap.com/ZwebKomsuF003", RequestNamespace="urn:sap-com:document:sap:soap:functions:mc-style", ResponseElementName="ZwebKomsuF003Result", ResponseNamespace="urn:sap-com:document:sap:soap:functions:mc-style", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("EtExport", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZwebKomsuS_003[] ZwebKomsuF003([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string IvMatnr) {
            object[] results = this.Invoke("ZwebKomsuF003", new object[] {
                        IvMatnr});
            return ((ZwebKomsuS_003[])(results[0]));
        }
        
        /// <remarks/>
        public void ZwebKomsuF003Async(string IvMatnr) {
            this.ZwebKomsuF003Async(IvMatnr, null);
        }
        
        /// <remarks/>
        public void ZwebKomsuF003Async(string IvMatnr, object userState) {
            if ((this.ZwebKomsuF003OperationCompleted == null)) {
                this.ZwebKomsuF003OperationCompleted = new System.Threading.SendOrPostCallback(this.OnZwebKomsuF003OperationCompleted);
            }
            this.InvokeAsync("ZwebKomsuF003", new object[] {
                        IvMatnr}, this.ZwebKomsuF003OperationCompleted, userState);
        }
        
        private void OnZwebKomsuF003OperationCompleted(object arg) {
            if ((this.ZwebKomsuF003Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ZwebKomsuF003Completed(this, new ZwebKomsuF003CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class ZwebKomsuS_003 {
        
        private string productCodeField;
        
        private string subproductcodeField;
        
        private string attributes1Field;
        
        private string attributes2Field;
        
        private string barcodeField;
        
        private decimal stockField;
        
        private bool stockFieldSpecified;
        
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
        public string Subproductcode {
            get {
                return this.subproductcodeField;
            }
            set {
                this.subproductcodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Attributes1 {
            get {
                return this.attributes1Field;
            }
            set {
                this.attributes1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Attributes2 {
            get {
                return this.attributes2Field;
            }
            set {
                this.attributes2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Barcode {
            get {
                return this.barcodeField;
            }
            set {
                this.barcodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Stock {
            get {
                return this.stockField;
            }
            set {
                this.stockField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StockSpecified {
            get {
                return this.stockFieldSpecified;
            }
            set {
                this.stockFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void ZwebKomsuF003CompletedEventHandler(object sender, ZwebKomsuF003CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZwebKomsuF003CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ZwebKomsuF003CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZwebKomsuS_003[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZwebKomsuS_003[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591