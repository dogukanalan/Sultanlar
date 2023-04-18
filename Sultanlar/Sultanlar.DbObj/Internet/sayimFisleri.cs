using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class sayimFis : DbObj
    {
        public int ID { get; set; }
        public int UYE_ID { get; set; }
        public musteriler Musteri { get { return new musteriler(UYE_ID).GetObject(); } }
        public bool AP { get; set; }
        public bool ONAYLI { get; set; }
        public int TUR_ID { get; set; }
        public sayimFisTurleri Tur { get { return new sayimFisTurleri(TUR_ID).GetObject(); } }
        public int ANA_ID { get; set; }
        //public sayimFisleri Ana { get { return ANA_ID != ID ? new sayimFisleri(ANA_ID).GetObject() : this; } }
        public string ACIKLAMA { get; set; }
        public DateTime TARIH { get; set; }
        public int GMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(GMREF).GetObject(); } }
        public List<sayimFisleri> detaylar { get { return new sayimFisleri().GetObjectsByID(ID); } }
        public sayimFis() { }
        public sayimFis(int ID) { this.ID = ID; }
        public sayimFis(bool AP, int UYE_ID, int TUR_ID, int ANA_ID, int GMREF, DateTime TARIH, bool ONAYLI, string ACIKLAMA)
        {
            this.UYE_ID = UYE_ID;
            this.AP = AP;
            this.ONAYLI = ONAYLI;
            this.TUR_ID = TUR_ID;
            this.ANA_ID = ANA_ID;
            this.ACIKLAMA = ACIKLAMA;
            this.TARIH = TARIH;
            this.GMREF = GMREF;
        }
        private sayimFis(int ID, bool AP, int UYE_ID, int TUR_ID, int ANA_ID, int GMREF, DateTime TARIH, bool ONAYLI, string ACIKLAMA)
        {
            this.ID = ID;
            this.UYE_ID = UYE_ID;
            this.AP = AP;
            this.ONAYLI = ONAYLI;
            this.TUR_ID = TUR_ID;
            this.ANA_ID = ANA_ID;
            this.ACIKLAMA = ACIKLAMA;
            this.TARIH = TARIH;
            this.GMREF = GMREF;
        }

        public override string ToString() { return ACIKLAMA; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "UYE_ID", UYE_ID }, { "AP", AP }, { "ONAYLI", ONAYLI }, { "TUR_ID", TUR_ID }, { "ANA_ID", ANA_ID }, { "ACIKLAMA", ACIKLAMA }, { "TARIH", TARIH }, { "GMREF", GMREF } };
            ID = ConvertToInt32(Do(QueryType.Insert, "db_sp_stokFisBaslikEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "UYE_ID", UYE_ID }, { "AP", AP }, { "ONAYLI", ONAYLI }, { "TUR_ID", TUR_ID }, { "ANA_ID", ANA_ID }, { "ACIKLAMA", ACIKLAMA }, { "TARIH", TARIH }, { "GMREF", GMREF } };
            Do(QueryType.Update, "db_sp_stokFisBaslikGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_stokFisBaslikSil", new Dictionary<string, object>() { { "ID", ID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sayimFis GetObject()
        {
            sayimFis donendeger = new sayimFis();

            Dictionary<int, object> dic = GetObject("db_sp_stokFisBaslikGetir", new Dictionary<string, object>() { { "ID", ID } }, timeout);
            if (dic != null)
                donendeger = new sayimFis(ConvertToInt32(dic[0]), Convert.ToBoolean(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), ConvertToInt32(dic[5]), ConvertToDateTime(dic[6]), Convert.ToBoolean(dic[7]), dic[8].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<sayimFis> GetObjects(int GMREF)
        {
            List<sayimFis> donendeger = new List<sayimFis>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_stokFislerBaslikGetir", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new sayimFis(ConvertToInt32(dic[i][0]), Convert.ToBoolean(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), ConvertToInt32(dic[i][5]), ConvertToDateTime(dic[i][6]), Convert.ToBoolean(dic[i][7]), dic[i][8].ToString()));

            return donendeger;
        }
    }
    public class sayimFisleri : DbObj
    { 
        public int ID { get; set; } 
        public int UYE_ID { get { return sf.UYE_ID; } } 
        public musteriler Musteri { get { return new musteriler(UYE_ID).GetObject(); } }
        public bool AP { get { return sf.AP; } } 
        public int TUR_ID { get { return sf.TUR_ID; } } 
        public sayimFisTurleri Tur { get { return sf.Tur; } }
        public int ANA_ID { get { return sf.ANA_ID; } }
        public string ACIKLAMA { get { return sf.ACIKLAMA; } } 
        public DateTime TARIH { get { return sf.TARIH; } } 
        public int ITEMREF { get; set; } 
        public malzemeler Malzeme { get { return new malzemeler(ITEMREF).GetObject(); } }
        public int GMREF { get { return sf.GMREF; } }
        public cariHesaplar Cari { get { return new cariHesaplar(GMREF).GetObject(); } }
        public int STOK { get; set; }
        public int BASLIK_ID { get; set; }
        public bool ONAYLI { get { return sf.ONAYLI; } }
        private sayimFis sf;
        public sayimFisleri() { }
        public sayimFisleri(int ID) { this.ID = ID; }
        public sayimFisleri(int ITEMREF, int STOK, int BASLIK_ID)
        {
            this.ITEMREF = ITEMREF;
            this.STOK = STOK;
            this.BASLIK_ID = BASLIK_ID;
        }
        private sayimFisleri(int ID, int ITEMREF, int STOK, int BASLIK_ID)
        {
            sf = new sayimFis(BASLIK_ID).GetObject();
            this.ID = ID;
            this.ITEMREF = ITEMREF;
            this.STOK = STOK;
            this.BASLIK_ID = BASLIK_ID;
        }

        public override string ToString() { return ACIKLAMA; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "ITEMREF", ITEMREF }, { "STOK", STOK }, { "BASLIK_ID", BASLIK_ID } };
            ID = ConvertToInt32(Do(QueryType.Insert, "db_sp_stokFisEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "ITEMREF", ITEMREF }, { "STOK", STOK }, { "BASLIK_ID", BASLIK_ID } };
            Do(QueryType.Update, "db_sp_stokFisGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_stokFisSil", new Dictionary<string, object>() { { "ID", ID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sayimFisleri GetObject()
        {
            sayimFisleri donendeger = new sayimFisleri();

            Dictionary<int, object> dic = GetObject("db_sp_stokFisGetir", new Dictionary<string, object>() { { "ID", ID } }, timeout);
            if (dic != null)
                donendeger = new sayimFisleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), ConvertToInt32(dic[3]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<sayimFisleri> GetObjects(int GMREF)
        {
            List<sayimFisleri> donendeger = new List<sayimFisleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_stokFislerGetir", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new sayimFisleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<sayimFisleri> GetObjectsByID(int BASLIK_ID)
        {
            List<sayimFisleri> donendeger = new List<sayimFisleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_stokFislerGetirByBaslikId", new Dictionary<string, object>() { { "BASLIK_ID", BASLIK_ID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new sayimFisleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), ConvertToInt32(dic[i][3])));

            return donendeger;
        }
    }

    public class sayimFisTurleri : DbObj
    {
        public int ID { get; set; }
        public string ACIKLAMA { get; set; }
        public int ANA_TUR_ID { get; set; }
        //public sayimFisTurleri Ana { get { return ANA_TUR_ID != ID ? new sayimFisTurleri(ANA_TUR_ID).GetObject() : new sayimFisTurleri(); } }
        public bool YON { get; set; }
        public sayimFisTurleri() { }
        public sayimFisTurleri(int ID) { this.ID = ID; }
        private sayimFisTurleri(int ID, string ACIKLAMA, int ANA_TUR_ID, bool YON)
        {
            this.ID = ID;
            this.ACIKLAMA = ACIKLAMA;
            this.ANA_TUR_ID = ANA_TUR_ID;
            this.YON = YON;
        }

        public override string ToString() { return ACIKLAMA; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "ACIKLAMA", ACIKLAMA }, { "ANA_TUR_ID", ANA_TUR_ID }, { "YON", YON } };
            ID = ConvertToInt32(Do(QueryType.Insert, "db_sp_stokFisTuruEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ID", ID }, { "ACIKLAMA", ACIKLAMA }, { "ANA_TUR_ID", ANA_TUR_ID }, { "YON", YON } };
            Do(QueryType.Update, "db_sp_stokFisTuruGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_stokFisTuruSil", new Dictionary<string, object>() { { "ID", ID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sayimFisTurleri GetObject()
        {
            sayimFisTurleri donendeger = new sayimFisTurleri();

            Dictionary<int, object> dic = GetObject("db_sp_stokFisTuruGetir", new Dictionary<string, object>() { { "ID", ID } }, timeout);
            if (dic != null)
                donendeger = new sayimFisTurleri(ConvertToInt32(dic[0]), dic[1].ToString(), ConvertToInt32(dic[2]), Convert.ToBoolean(dic[3]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<sayimFisTurleri> GetObjects()
        {
            List<sayimFisTurleri> donendeger = new List<sayimFisTurleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_stokFisTurleriGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new sayimFisTurleri(ConvertToInt32(dic[i][0]), dic[i][1].ToString(), ConvertToInt32(dic[i][2]), Convert.ToBoolean(dic[i][3])));

            return donendeger;
        }
    }

    public class sayimRapor : DbObj
    {
        public int GMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(GMREF).GetObject(); } }
        public int ITEMREF { get; set; }
        public malzemeler Malzeme { get { return new malzemeler(ITEMREF).GetObject(); } }
        public int STOK { get; set; }
        public sayimRapor() { }
        private sayimRapor(int GMREF, int ITEMREF, int STOK)
        {
            this.GMREF = GMREF;
            this.ITEMREF = ITEMREF;
            this.STOK = STOK;
        }

        public override string ToString() { return Malzeme.MALACIK; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sayimRapor GetObject(int GMREF, int ITEMREF)
        {
            sayimRapor donendeger = new sayimRapor();

            Dictionary<int, object> dic = GetObject("db_sp_SayimRaporSatir", new Dictionary<string, object>() { { "GMREF", GMREF }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                donendeger = new sayimRapor(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<sayimRapor> GetObjects(int GMREF)
        {
            List<sayimRapor> donendeger = new List<sayimRapor>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_SayimRapor", new Dictionary<string, object>() { { "GMREF", GMREF } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new sayimRapor(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2])));

            return donendeger;
        }
    }
    public class sayimEksikFazlaFisleri : DbObj
    {
        public int ID { get; set; }
        public int UYE_ID { get; set; }
        public musteriler Musteri { get { return new musteriler(UYE_ID).GetObject(); } }
        public bool AP { get; set; }
        public int TUR_ID { get; set; }
        public sayimFisTurleri Tur { get; set; }
        public int ANA_ID { get; set; }
        public string ACIKLAMA { get; set; }
        public DateTime TARIH { get; set; }
        public int ITEMREF { get; set; }
        public malzemeler Malzeme { get { return new malzemeler(ITEMREF).GetObject(); } }
        public int GMREF { get; set; }
        public cariHesaplar Cari { get { return new cariHesaplar(GMREF).GetObject(); } }
        public int STOK { get; set; }
        public int SAYIM { get; set; }
        public int SESF { get; set; }
        public bool ONAYLI { get; set; }
        public sayimEksikFazlaFisleri() { }
        private sayimEksikFazlaFisleri(int ID, int UYE_ID, bool AP, int TUR_ID, int ANA_ID, string ACIKLAMA, DateTime TARIH, int ITEMREF, int GMREF, int STOK, int SAYIM, int SESF, bool ONAYLI)
        {
            this.ID = ID;
            this.UYE_ID = UYE_ID;
            this.AP = AP;
            this.TUR_ID = TUR_ID;
            this.ANA_ID = ANA_ID;
            this.ACIKLAMA = ACIKLAMA;
            this.TARIH = TARIH;
            this.ITEMREF = ITEMREF;
            this.GMREF = GMREF;
            this.STOK = STOK;
            this.SAYIM = SAYIM;
            this.SESF = SESF;
            this.ONAYLI = ONAYLI;
        }

        public override string ToString() { return ACIKLAMA; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sayimEksikFazlaFisleri GetObject(bool Fazla, int ID, int ITEMREF)
        {
            sayimEksikFazlaFisleri donendeger = new sayimEksikFazlaFisleri();

            Dictionary<int, object> dic = GetObject(Fazla ? "db_sp_SayimFazla" : "db_sp_SayimEksik", new Dictionary<string, object>() { { "ID", ID }, { "ITEMREF", ITEMREF } }, timeout);
            if (dic != null)
                donendeger = new sayimEksikFazlaFisleri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), Convert.ToBoolean(dic[2]), ConvertToInt32(dic[3]), ConvertToInt32(dic[4]), dic[5].ToString(), ConvertToDateTime(dic[6]), ConvertToInt32(dic[7]), ConvertToInt32(dic[8]), ConvertToInt32(dic[9]), ConvertToInt32(dic[10]), ConvertToInt32(dic[11]), Convert.ToBoolean(dic[12]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<sayimEksikFazlaFisleri> GetObjects(bool Fazla, int ID)
        {
            List<sayimEksikFazlaFisleri> donendeger = new List<sayimEksikFazlaFisleri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects(Fazla ? "db_sp_SayimFazla" : "db_sp_SayimEksik", new Dictionary<string, object>() { { "ID", ID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new sayimEksikFazlaFisleri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), Convert.ToBoolean(dic[i][2]), ConvertToInt32(dic[i][3]), ConvertToInt32(dic[i][4]), dic[i][5].ToString(), ConvertToDateTime(dic[i][6]), ConvertToInt32(dic[i][7]), ConvertToInt32(dic[i][8]), ConvertToInt32(dic[i][9]), ConvertToInt32(dic[i][10]), ConvertToInt32(dic[i][11]), Convert.ToBoolean(dic[i][12])));

            return donendeger;
        }
    }
}
