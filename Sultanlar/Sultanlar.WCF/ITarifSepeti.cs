using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;

namespace Sultanlar.WCF
{
    [ServiceContract]
    public interface ITarifSepeti
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/UrunlerGetir"), DataContractFormat]
        List<UrunPost> UrunlerGetir(UrunGet get);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/TariflerGetir"), DataContractFormat]
        List<TarifPost> TariflerGetir(TarifGet get);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GirisYap"), DataContractFormat]
        GirisPost GirisYap(GirisGet get);
    }

    #region Classes
    #region Urun
    [DataContract]
    public class UrunGet
    {
        [DataMember]
        public int katid { get; set; }
        [DataMember]
        public string aranan { get; set; }
        [DataMember]
        public int sonid { get; set; }
    }
    [DataContract]
    public class UrunPost
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Ad { get; set; }
        [DataMember]
        public int ResimID { get; set; }

        public UrunPost() { }

        public UrunPost(int ID, string Ad, int ResimID)
        {
            this.ID = ID;
            this.Ad = Ad;
            this.ResimID = ResimID;
        }
    }
    #endregion
    #region Tarif
    [DataContract]
    public class TarifGet
    {
        [DataMember]
        public int katid { get; set; }
        [DataMember]
        public string aranan { get; set; }
        [DataMember]
        public int sonid { get; set; }
        [DataMember]
        public int kactane { get; set; }
        [DataMember]
        public string action { get; set; }
        [DataMember]
        public string uyeid { get; set; }
        [DataMember]
        public string urunid { get; set; }
        [DataMember]
        public string order { get; set; }
    }
    [DataContract]
    public class TarifPost
    {
        [DataMember]
        public int pkID { get; set; }
        [DataMember]
        public int intUyeID { get; set; }
        [DataMember]
        public Uyeler Uye { get; set; }
        [DataMember]
        public bool blOnay { get; set; }
        [DataMember]
        public string strBaslik { get; set; }
        [DataMember]
        public string strMalzemeler { get; set; }
        [DataMember]
        public string strHazirlanis { get; set; }
        [DataMember]
        public byte[] binResim { get; set; }
        [DataMember]
        public byte[] binResimUrunler { get; set; }
        [DataMember]
        public string strUrunlerLink { get; set; }
        [DataMember]
        public DateTime dtTarih { get; set; }
        [DataMember]
        public double OrtPuan { get; set;}
        [DataMember]
        public List<TarifKategori> TarifKategoriler { get; set; }

        public TarifPost(int pkID, int intUyeID, Uyeler Uye, bool blOnay, string strBaslik, string strMalzemeler, string strHazirlanis, byte[] binResim,
            byte[] binResimUrunler, string strUrunlerLink, DateTime dtTarih, double OrtPuan, List<TarifKategori> TarifKategoriler)
        {
            this.pkID = pkID;
            this.intUyeID = intUyeID;
            this.Uye = Uye;
            this.blOnay = blOnay;
            this.strBaslik = strBaslik;
            this.strMalzemeler = strMalzemeler;
            this.strHazirlanis = strHazirlanis;
            this.binResim = binResim;
            this.binResimUrunler = binResimUrunler;
            this.strUrunlerLink = strUrunlerLink;
            this.dtTarih = dtTarih;
            this.OrtPuan = OrtPuan;
            this.TarifKategoriler = TarifKategoriler;
        }
    }
    #endregion
    #region Giris
    [DataContract]
    public class GirisGet
    {
        [DataMember]
        public string eposta { get; set; }
        [DataMember]
        public string sifre { get; set; }
    }
    [DataContract]
    public class GirisPost
    {
        [DataMember]
        public int ID { get; set; }

        public GirisPost() { }

        public GirisPost(int ID)
        {
            this.ID = ID;
        }
    }
    #endregion
    #endregion
}
