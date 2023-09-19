using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sultanlar.DbObj;

namespace Sultanlar.DbObj.Internet
{
    public class tpPersonelBaglantilari : DbObj
    {
        public int SMREF { get; set; }
        public byte blBayi { get; set; }
        public int personelID { get; set; }
        public string strAciklama { get; set; }
        public tpPersonelBaglantilari() { }
        public tpPersonelBaglantilari(int SMREF, int personelID, int perBayi, byte blBayi) { this.SMREF = SMREF; this.personelID = personelID;this.blBayi = blBayi; }
        public tpPersonelBaglantilari(string strAciklama)
        {
            this.SMREF = SMREF;
            this.blBayi = blBayi;
            this.personelID = personelID;
            this.strAciklama = strAciklama;
        }
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "SMREF", SMREF }, { "blBayi", blBayi }, { "personelID", personelID }, { "strAciklama", strAciklama } };
            SMREF = ConvertToByte(Do(QueryType.Insert, "Web-Musteri-TP_PersonelBaglantilari", param, timeout));
        }
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "SMREF", SMREF }, { "blBayi", blBayi }, { "personelID", personelID }, { "strAciklama", strAciklama } };
            Do(QueryType.Update, "Web-Musteri-TP_PersonelBaglantilari", param, timeout);
        }
        public override void DoDelete()
        {
            Do(QueryType.Delete, "Web-Musteri-TP_PersonelBaglantilari", new Dictionary<string, object>() { { "SMREF", SMREF } }, timeout);
            //personel ID yapmam daha mantıklı olurdu sanırım
        }
    }

    public class tpPersoneller : DbObj
    {
        public int pkID { get; set; }
        public int perTur { get; set; }
        public string strAd { get; set; }
        public string strSoyad { get; set; }
        public string strGorev { get; set; }
        public string strTelefon { get; set; }
        public string strKod { get; set; }
        public string strEposta { get; set; }
        public string strAciklama { get; set; }
        public int perBayi { get; set; }
        public tpPersoneller() { }
        public tpPersoneller(int pkID,int perTur, int perBayi)  { this.pkID = pkID; this.perTur = perTur; this.perBayi = perBayi; }
        public tpPersoneller(string strAd, string strSoyad, string strGorev, string strTelefon, string strKod, string strEposta, string strAciklama)
        {
            this.pkID = pkID;
            this.perTur = perTur;
            this.strAd = strAd;
            this.strSoyad = strSoyad;
            this.strGorev = strGorev;
            this.strTelefon = strTelefon;
            this.strKod = strKod;
            this.strEposta = strEposta;
            this.strAciklama = strAciklama;
            this.perBayi = perBayi;

        }
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "perTur", perTur }, { "strAd", strAd }, { "strSoyad", strSoyad }, { "strGorev", strGorev }, { "strTelefon", strTelefon }, { "strKod", strKod }, { "strEposta", strEposta }, { "strAciklama", strAciklama }, { "perBayi", perBayi } };
            pkID = ConvertToByte(Do(QueryType.Insert, "Web-Musteri-TP_Personeller", param, timeout));
        }
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "perTur", perTur }, { "strAd", strAd }, { "strSoyad", strSoyad }, { "strGorev", strGorev }, { "strTelefon", strTelefon }, { "strKod", strKod }, { "strEposta", strEposta }, { "strAciklama", strAciklama }, { "perBayi", perBayi } };
            pkID = ConvertToByte(Do(QueryType.Update, "Web-Musteri-TP_Personeller", param, timeout));
        }
        public override void DoDelete() 
        {
            Do(QueryType.Delete, "Web-Musteri-TP_Personeller", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
    }
}

    public class tpPersonelTurleri : DbObj
    {
        public int pkID { get; set; }
        public string strTur { get; set; } 
        public string strAciklama { get; set; }
        public tpPersonelTurleri() { }
        public tpPersonelTurleri(byte pkID) { this.pkID = pkID; }
        public tpPersonelTurleri(string strTur, string strAciklama)
        {
            this.pkID = pkID;
            this.strTur = strTur;
            this.strAciklama = strAciklama;
        }

    }


