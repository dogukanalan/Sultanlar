using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class rutResimler : DbObj
    {
        public int pkID { get; set; }
        public int SMREF { get; set; }
        public int intTip { get; set; }
        public cariHesaplar Cari { get { cariHesaplar carisube = new cariHesaplar().GetObject1(intTip, SMREF); if (cari) return carisube; else { cariHesaplar cari = new cariHesaplar(); cari.SUBE = carisube.SUBE; cari.MUSTERI = carisube.MUSTERI; return cari; } } }
        public int intMusteriID { get; set; }
        public musteriler Musteri { get { musteriler mus = new musteriler(intMusteriID).GetObject(); if (musteri) return mus; else { musteriler must = new musteriler(); must.strAd = mus.strAd; must.strSoyad = mus.strSoyad; return must; } } }
        public int intTurID { get; set; }
        public rutResimTurler Tur { get { return new rutResimTurler(intTurID).GetObject(); } }
        public string strRutID { get; set; }
        public int intZiyaretID { get; set; }
        public DateTime dtTarih { get; set; }
        public byte[] binResim { get; set; }
        public string strAciklama { get; set; }
        public string strNot { get; set; }

        private bool cari { get; set; }
        private bool musteri { get; set; }

        public rutResimler() { }
        public rutResimler(int pkID) { this.pkID = pkID; }
        public rutResimler(int SMREF, int intTip, int intMusteriID, int intTurID, string strRutID, int intZiyaretID, DateTime dtTarih, byte[] binResim, string strAciklama, string strNot)
        {
            this.SMREF = SMREF;
            this.intTip = intTip;
            this.intMusteriID = intMusteriID;
            this.intTurID = intTurID;
            this.strRutID = strRutID;
            this.intZiyaretID = intZiyaretID;
            this.dtTarih = dtTarih;
            this.binResim = binResim;
            this.strAciklama = strAciklama;
            this.strNot = strNot;
        }
        private rutResimler(int pkID, int SMREF, int intTip, int intMusteriID, int intTurID, string strRutID, int intZiyaretID, DateTime dtTarih, byte[] binResim, string strAciklama, string strNot, bool cari, bool musteri)
        {
            this.pkID = pkID;
            this.SMREF = SMREF;
            this.intTip = intTip;
            this.intMusteriID = intMusteriID;
            this.intTurID = intTurID;
            this.strRutID = strRutID;
            this.intZiyaretID = intZiyaretID;
            this.dtTarih = dtTarih;
            this.binResim = binResim;
            this.strAciklama = strAciklama;
            this.strNot = strNot;
            this.cari = cari;
            this.musteri = musteri;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "SMREF", SMREF }, { "intTip", intTip }, { "intMusteriID", intMusteriID }, { "intTurID", intTurID }, { "strRutID", strRutID }, { "intZiyaretID", intZiyaretID }, { "dtTarih", dtTarih }, { "binResim", binResim }, { "strAciklama", strAciklama }, { "strNot", strNot } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_rutResimEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "SMREF", SMREF }, { "intTip", intTip }, { "intMusteriID", intMusteriID }, { "intTurID", intTurID }, { "strRutID", strRutID }, { "intZiyaretID", intZiyaretID }, { "dtTarih", dtTarih }, { "binResim", binResim }, { "strAciklama", strAciklama }, { "strNot", strNot } };
            Do(QueryType.Update, "db_sp_rutResimGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_rutResimSil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public rutResimler GetObject()
        {
            rutResimler donendeger = new rutResimler();

            Dictionary<int, object> dic = GetObject("db_sp_rutResimGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new rutResimler(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), dic[5].ToString(), ConvertToInt32(dic[6]), ConvertToDateTime(dic[7]), (byte[])dic[8], dic[9].ToString(), dic[10].ToString(), true, true);

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<rutResimler> GetObjects(object SLSREF, object SMREF, object TIP, object TUR, int YIL, object AY)
        {
            List<rutResimler> donendeger = new List<rutResimler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_rutResimlerGetir", new Dictionary<string, object>() { { "SLSREF", SLSREF }, { "SMREF", SMREF }, { "TIP", TIP }, { "TUR", TUR }, { "YIL", YIL }, { "AY", AY } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new rutResimler(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), dic[i][5].ToString(), ConvertToInt32(dic[i][6]), ConvertToDateTime(dic[i][7]), null, dic[i][9].ToString(), dic[i][10].ToString(), false, false));

            return donendeger;
        }
    }

    public class rutResimTurler : StandartClass, IStandartClass
    {
        public rutResimTurler()
        {
            Generate();
        }

        public rutResimTurler(int pkID)
        {
            key = pkID;
            Generate();
        }

        private rutResimTurler(int pkID, string strTur)
        {
            key = pkID;
            value = strTur;
        }

        public void Generate()
        {
            keyFieldName = "pkID";
            valueFieldName = "strTur";
            insertSp = "db_sp_rutResimTurEkle";
            updateSp = "db_sp_rutResimTurGuncelle";
            deleteSp = "db_sp_rutResimTurSil";
            getSp = "db_sp_rutResimTurGetir";
            getsSp = "db_sp_rutResimTurlerGetir";
        }

        public rutResimTurler GetObject()
        {
            GetObj();
            return new rutResimTurler(key, value);
        }

        public List<rutResimTurler> GetObjects()
        {
            List<rutResimTurler> donendeger = new List<rutResimTurler>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new rutResimTurler(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
