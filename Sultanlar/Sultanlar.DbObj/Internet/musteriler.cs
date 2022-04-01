using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class musteriler : DbObj
    {
        public int pkMusteriID { get; set; }
        public byte tintUyeTipiID { get; set; }
        public uyeTipleri UyeTipi { get { return new uyeTipleri(tintUyeTipiID).GetObject(); } }
        public int intUyeGrupID { get; set; }
        public uyeGruplari UyeGrup { get { return new uyeGruplari(intUyeGrupID).GetObject(); } }
        public string strAd { get; set; }
        public string strSoyad { get; set; }
        public string AdSoyad { get { return strAd + " " + strSoyad; } }
        public string strVergiDairesi { get; set; }
        public string strVergiNo { get; set; }
        public string strTelefon { get; set; }
        public string strEposta { get; set; }
        public string binKullaniciAdi { get; set; }
        public string binSifre { get; set; }
        public bool blSatisOnayi { get; set; }
        public bool blBilgiIslemOnayi { get; set; }
        public DateTime dtBasvuruTarihi { get; set; }
        public DateTime dtSatisOnayTarihi { get; set; }
        public DateTime dtBilgiIslemOnayTarihi { get; set; }
        public bool blTaksitPlani { get; set; }
        public int intGMREF { get; set; }
        public int intSLSREF { get; set; }
        public int intSonYarimSiparisID { get; set; }
        public bool blSistemde { get; set; }
        public bool blTalepEposta { get; set; }
        public bool blOnayEposta { get; set; }
        public byte tintMusteriDurumID { get; set; }
        public bool blPasif { get; set; }
        public bool blCHvar { get; set; }
        public string strUnvan { get; set; }
        public byte tintIlID { get; set; }
        public byte tintOnerilenFiyatYuzde { get; set; }
        public bool blSicakSatis { get; set; }
        public int intSiparisUrunSayisi { get; set; }
        public int intRaporSatirSayisi { get; set; }
        public int intSiparisSatirSayisi { get; set; }
        public bool isSDE { get { return blSicakSatis; } }

        public musteriler() { }
        public musteriler(int pkMusteriID) { this.pkMusteriID = pkMusteriID; }
        private musteriler(int pkMusteriID, byte tintUyeTipiID, int intUyeGrupID, string strAd, string strSoyad, string strVergiDairesi, string strVergiNo, string strTelefon, string strEposta, string binKullaniciAdi, string binSifre, bool blSatisOnayi, bool blBilgiIslemOnayi, DateTime dtBasvuruTarihi, DateTime dtSatisOnayTarihi, DateTime dtBilgiIslemOnayTarihi, bool blTaksitPlani, int intGMREF, int intSLSREF, int intSonYarimSiparisID, bool blSistemde, bool blTalepEposta, bool blOnayEposta, byte tintMusteriDurumID, bool blPasif, bool blCHvar, string strUnvan, byte tintIlID, byte tintOnerilenFiyatYuzde, bool blSicakSatis, int intSiparisUrunSayisi, int intRaporSatirSayisi, int intSiparisSatirSayisi)
        {
            this.pkMusteriID = pkMusteriID;
            this.tintUyeTipiID = tintUyeTipiID;
            this.intUyeGrupID = intUyeGrupID;
            this.strAd = strAd;
            this.strSoyad = strSoyad;
            this.strVergiDairesi = strVergiDairesi;
            this.strVergiNo = strVergiNo;
            this.strTelefon = strTelefon;
            this.strEposta = strEposta;
            this.binKullaniciAdi = binKullaniciAdi;
            this.binSifre = binSifre;
            this.blSatisOnayi = blSatisOnayi;
            this.blBilgiIslemOnayi = blBilgiIslemOnayi;
            this.dtBasvuruTarihi = dtBasvuruTarihi;
            this.dtSatisOnayTarihi = dtSatisOnayTarihi;
            this.dtBilgiIslemOnayTarihi = dtBilgiIslemOnayTarihi;
            this.blTaksitPlani = blTaksitPlani;
            this.intGMREF = intGMREF;
            this.intSLSREF = intSLSREF;
            this.intSonYarimSiparisID = intSonYarimSiparisID;
            this.blSistemde = blSistemde;
            this.blTalepEposta = blTalepEposta;
            this.blOnayEposta = blOnayEposta;
            this.tintMusteriDurumID = tintMusteriDurumID;
            this.blPasif = blPasif;
            this.blCHvar = blCHvar;
            this.strUnvan = strUnvan;
            this.tintIlID = tintIlID;
            this.tintOnerilenFiyatYuzde = tintOnerilenFiyatYuzde;
            this.blSicakSatis = blSicakSatis;
            this.intSiparisUrunSayisi = intSiparisUrunSayisi;
            this.intRaporSatirSayisi = intRaporSatirSayisi;
            this.intSiparisSatirSayisi = intSiparisSatirSayisi;
        }
        
        public override string ToString() { return strAd + " " + strSoyad; }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkMusteriID", pkMusteriID }, { "tintUyeTipiID", tintUyeTipiID }, { "intUyeGrupID", intUyeGrupID }, { "strAd", strAd }, { "strSoyad", strSoyad }, { "strVergiDairesi", strVergiDairesi }, { "strVergiNo", strVergiNo }, { "strTelefon", strTelefon }, { "strEposta", strEposta }, { "binKullaniciAdi", UTF8Encoding.GetEncoding(1254).GetBytes(binKullaniciAdi) }, { "binSifre", UTF8Encoding.GetEncoding(1254).GetBytes(binSifre)  }, { "blSatisOnayi", blSatisOnayi }, { "blBilgiIslemOnayi", blBilgiIslemOnayi }, { "dtBasvuruTarihi", dtBasvuruTarihi }, { "dtSatisOnayTarihi", dtSatisOnayTarihi  }, { "dtBilgiIslemOnayTarihi", dtBilgiIslemOnayTarihi  }, { "blTaksitPlani", blTaksitPlani }, { "intGMREF", intGMREF }, { "intSLSREF", intSLSREF }, { "intSonYarimSiparisID", intSonYarimSiparisID }, { "blSistemde", blSistemde }, { "blTalepEposta", blTalepEposta }, { "blOnayEposta", blOnayEposta }, { "tintMusteriDurumID", tintMusteriDurumID }, { "blPasif", blPasif  }, { "blCHvar", blCHvar }, { "strUnvan", strUnvan }, { "tintIlID", tintIlID }, { "tintOnerilenFiyatYuzde", tintOnerilenFiyatYuzde  }, { "blSicakSatis", blSicakSatis }, { "intSiparisUrunSayisi", intSiparisUrunSayisi  }, { "intRaporSatirSayisi", intRaporSatirSayisi }, { "intSiparisSatirSayisi", intSiparisSatirSayisi } };
            pkMusteriID = ConvertToInt32(Do(QueryType.Insert, "db_sp_musteriEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkMusteriID", pkMusteriID }, { "tintUyeTipiID", tintUyeTipiID }, { "intUyeGrupID", intUyeGrupID }, { "strAd", strAd }, { "strSoyad", strSoyad }, { "strVergiDairesi", strVergiDairesi }, { "strVergiNo", strVergiNo }, { "strTelefon", strTelefon }, { "strEposta", strEposta }, { "binKullaniciAdi", UTF8Encoding.GetEncoding(1254).GetBytes(binKullaniciAdi) }, { "binSifre", UTF8Encoding.GetEncoding(1254).GetBytes(binSifre) }, { "blSatisOnayi", blSatisOnayi }, { "blBilgiIslemOnayi", blBilgiIslemOnayi }, { "dtBasvuruTarihi", dtBasvuruTarihi }, { "dtSatisOnayTarihi", dtSatisOnayTarihi }, { "dtBilgiIslemOnayTarihi", dtBilgiIslemOnayTarihi }, { "blTaksitPlani", blTaksitPlani }, { "intGMREF", intGMREF }, { "intSLSREF", intSLSREF }, { "intSonYarimSiparisID", intSonYarimSiparisID }, { "blSistemde", blSistemde }, { "blTalepEposta", blTalepEposta }, { "blOnayEposta", blOnayEposta }, { "tintMusteriDurumID", tintMusteriDurumID }, { "blPasif", blPasif }, { "blCHvar", blCHvar }, { "strUnvan", strUnvan }, { "tintIlID", tintIlID }, { "tintOnerilenFiyatYuzde", tintOnerilenFiyatYuzde }, { "blSicakSatis", blSicakSatis }, { "intSiparisUrunSayisi", intSiparisUrunSayisi }, { "intRaporSatirSayisi", intRaporSatirSayisi }, { "intSiparisSatirSayisi", intSiparisSatirSayisi } };
            Do(QueryType.Update, "db_sp_musteriGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_musteriSil", new Dictionary<string, object>() { { "pkMusteriID", pkMusteriID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public musteriler GetObject()
        {
            musteriler donendeger = new musteriler();

            Dictionary<int, object> dic = GetObject("db_sp_musteriGetir", new Dictionary<string, object>() { { "pkMusteriID", pkMusteriID } }, timeout);
            if (dic != null)
                donendeger = new musteriler(ConvertToInt32(dic[0]), ConvertToByte(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), UTF8Encoding.GetEncoding(1254).GetString((byte[])dic[9]), UTF8Encoding.GetEncoding(1254).GetString((byte[])dic[10]), Convert.ToBoolean(dic[11]), Convert.ToBoolean(dic[12]), ConvertToDateTime(dic[13]), ConvertToDateTime(dic[14]), ConvertToDateTime(dic[15]), Convert.ToBoolean(dic[16]), ConvertToInt32(dic[17]), ConvertToInt32(dic[18]), ConvertToInt32(dic[19]), Convert.ToBoolean(dic[20]), Convert.ToBoolean(dic[21]), Convert.ToBoolean(dic[22]), ConvertToByte(dic[23]), Convert.ToBoolean(dic[24]), Convert.ToBoolean(dic[25]), dic[26].ToString(), ConvertToByte(dic[27]), ConvertToByte(dic[28]), Convert.ToBoolean(dic[29]), ConvertToInt32(dic[30]), ConvertToInt32(dic[31]), ConvertToInt32(dic[32]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<musteriler> GetObjects()
        {
            List<musteriler> donendeger = new List<musteriler>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_musterilerGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new musteriler(ConvertToInt32(dic[i][0]), ConvertToByte(dic[i][1]), ConvertToInt32(dic[i][2]), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString(), dic[i][7].ToString(), dic[i][8].ToString(), UTF8Encoding.GetEncoding(1254).GetString((byte[])dic[i][9]), UTF8Encoding.GetEncoding(1254).GetString((byte[])dic[i][10]), Convert.ToBoolean(dic[i][11]), Convert.ToBoolean(dic[i][12]), ConvertToDateTime(dic[i][13]), ConvertToDateTime(dic[i][14]), ConvertToDateTime(dic[i][15]), Convert.ToBoolean(dic[i][16]), ConvertToInt32(dic[i][17]), ConvertToInt32(dic[i][18]), ConvertToInt32(dic[i][19]), Convert.ToBoolean(dic[i][20]), Convert.ToBoolean(dic[i][21]), Convert.ToBoolean(dic[i][22]), ConvertToByte(dic[i][23]), Convert.ToBoolean(dic[i][24]), Convert.ToBoolean(dic[i][25]), dic[i][26].ToString(), ConvertToByte(dic[i][27]), ConvertToByte(dic[i][28]), Convert.ToBoolean(dic[i][29]), ConvertToInt32(dic[i][30]), ConvertToInt32(dic[i][31]), ConvertToInt32(dic[i][32])));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public musteriler GetMusteriBySLSREF(int SLSREF)
        {
            musteriler donendeger = new musteriler();

            Dictionary<int, object> dic = GetObject("db_sp_musteriGetirBySLSREF", new Dictionary<string, object>() { { "SLSREF", SLSREF } }, timeout);
            if (dic != null)
                donendeger = new musteriler(ConvertToInt32(dic[0]), ConvertToByte(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), UTF8Encoding.GetEncoding(1254).GetString((byte[])dic[9]), UTF8Encoding.GetEncoding(1254).GetString((byte[])dic[10]), Convert.ToBoolean(dic[11]), Convert.ToBoolean(dic[12]), ConvertToDateTime(dic[13]), ConvertToDateTime(dic[14]), ConvertToDateTime(dic[15]), Convert.ToBoolean(dic[16]), ConvertToInt32(dic[17]), ConvertToInt32(dic[18]), ConvertToInt32(dic[19]), Convert.ToBoolean(dic[20]), Convert.ToBoolean(dic[21]), Convert.ToBoolean(dic[22]), ConvertToByte(dic[23]), Convert.ToBoolean(dic[24]), Convert.ToBoolean(dic[25]), dic[26].ToString(), ConvertToByte(dic[27]), ConvertToByte(dic[28]), Convert.ToBoolean(dic[29]), ConvertToInt32(dic[30]), ConvertToInt32(dic[31]), ConvertToInt32(dic[32]));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Eposta"></param>
        /// <param name="Sifre"></param>
        /// <returns></returns>
        public musteriler ValidateCustomer(string Eposta, string Sifre)
        {
            musteriler donendeger = new musteriler();

            Dictionary<string, object> param = new Dictionary<string, object>() { { "strEposta", Eposta }, { "binSifre", UTF8Encoding.GetEncoding(1254).GetBytes(Sifre) } };
            Dictionary<int, object> dic = GetObject("db_sp_musteriGirisKontrol", param, timeout);
            if (dic != null)
                donendeger = new musteriler(ConvertToInt32(dic[0]), ConvertToByte(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString(), dic[7].ToString(), dic[8].ToString(), null, null, Convert.ToBoolean(dic[11]), Convert.ToBoolean(dic[12]), ConvertToDateTime(dic[13]), ConvertToDateTime(dic[14]), ConvertToDateTime(dic[15]), Convert.ToBoolean(dic[16]), ConvertToInt32(dic[17]), ConvertToInt32(dic[18]), ConvertToInt32(dic[19]), Convert.ToBoolean(dic[20]), Convert.ToBoolean(dic[21]), Convert.ToBoolean(dic[22]), ConvertToByte(dic[23]), Convert.ToBoolean(dic[24]), Convert.ToBoolean(dic[25]), dic[26].ToString(), ConvertToByte(dic[27]), ConvertToByte(dic[28]), Convert.ToBoolean(dic[29]), ConvertToInt32(dic[30]), ConvertToInt32(dic[31]), ConvertToInt32(dic[32]));

            return donendeger;
        }
    }
}
