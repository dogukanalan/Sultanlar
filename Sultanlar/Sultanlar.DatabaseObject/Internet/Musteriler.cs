using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Musteriler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkMusteriID;
        private byte _tintUyeTipiID;
        private int _intUyeGrupID;
        private string _strAd;
        private string _strSoyad;
        private string _strVergiDairesi;
        private string _strVergiNo;
        private string _strTelefon;
        private string _strEposta;
        private byte[] _binKullaniciAdi;
        private byte[] _binSifre;
        private bool _blSatisOnayi;
        private bool _blBilgiIslemOnayi;
        private DateTime _dtBasvuruTarihi;
        private DateTime _dtSatisOnayTarihi;
        private DateTime _dtBilgiIslemOnayTarihi;
        private bool _blTaksitPlani;
        private int _intGMREF;
        private int _intSLSREF;
        private int _intSonYarimSiparisID;
        private bool _blSistemde;
        private bool _blTalepEposta;
        private bool _blOnayEposta;
        private byte _tintMusteriDurumID;
        private bool _blPasif;
        private bool _blCHvar;
        private string _strUnvan;
        private byte _tintIlID;
        private byte _tintOnerilenFiyatYuzde;
        private bool _blSicakSatis;
        private int _intSiparisUrunSayisi;
        private int _intRaporSatirSayisi;
        private int _intSiparisSatirSayisi;
        //
        //
        //
        // Constracter lar:
        //
        //
        //
        //
        // Constracter lar:
        //
        public Musteriler()
        {

        }
        //
        //
        private Musteriler(int pkMusteriID, byte tintUyeTipiID, int intUyeGrupID, string strAd, string strSoyad, string strVergiDairesi, 
            string strVergiNo, string strTelefon, string strEposta,
            byte[] binKullaniciAdi, byte[] binSifre, bool blSatisOnayi, bool blBilgiIslemOnayi, DateTime dtBasvuruTarihi, DateTime dtSatisOnayTarihi,
            DateTime dtBilgiIslemOnayTarihi, bool blTaksitPlani, int intGMREF, int intSLSREF, int intSonYarimSiparisID,
            bool blSistemde, bool blTalepEposta, bool blOnayEposta, byte tintMusteriDurumID, bool blPasif, bool blCHvar, string strUnvan,
            byte tintIlID, byte tintOnerilenFiyatYuzde, bool blSicakSatis, int intSiparisUrunSayisi, int intRaporSatirSayisi, int intSiparisSatirSayisi)
        {
            this._pkMusteriID = pkMusteriID;
            this._tintUyeTipiID = tintUyeTipiID;
            this._intUyeGrupID = intUyeGrupID;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._strVergiDairesi = strVergiDairesi;
            this._strVergiNo = strVergiNo;
            this._strTelefon = strTelefon;
            this._strEposta = strEposta;
            this._binKullaniciAdi = binKullaniciAdi;
            this._binSifre = binSifre;
            this._blSatisOnayi = blSatisOnayi;
            this._blBilgiIslemOnayi = blBilgiIslemOnayi;
            this._dtBasvuruTarihi = dtBasvuruTarihi;
            this._dtSatisOnayTarihi = dtSatisOnayTarihi;
            this._dtBilgiIslemOnayTarihi = dtBilgiIslemOnayTarihi;
            this._blTaksitPlani = blTaksitPlani;
            this._intGMREF = intGMREF;
            this._intSLSREF = intSLSREF;
            this._intSonYarimSiparisID = intSonYarimSiparisID;
            this._blSistemde = blSistemde;
            this._blTalepEposta = blTalepEposta;
            this._blOnayEposta = blOnayEposta;
            this._tintMusteriDurumID = tintMusteriDurumID;
            this._blPasif = blPasif;
            this._blCHvar = blCHvar;
            this._strUnvan = strUnvan;
            this._tintIlID = tintIlID;
            this._tintOnerilenFiyatYuzde = tintOnerilenFiyatYuzde;
            this._blSicakSatis = blSicakSatis;
            this._intSiparisUrunSayisi = intSiparisUrunSayisi;
            this._intRaporSatirSayisi = intRaporSatirSayisi;
            this._intSiparisSatirSayisi = intSiparisSatirSayisi;
        }
        //
        //
        public Musteriler(byte tintUyeTipiID, int intUyeGrupID, string strAd, string strSoyad, string strVergiDairesi, string strVergiNo, 
            string strTelefon, string strEposta, string binKullaniciAdi, string binSifre, bool blSatisOnayi, bool blBilgiIslemOnayi, 
            DateTime dtBasvuruTarihi, DateTime dtSatisOnayTarihi,
            DateTime dtBilgiIslemOnayTarihi, bool blTaksitPlani, int intGMREF, int intSLSREF, int intSonYarimSiparisID,
            bool blSistemde, bool blTalepEposta, bool blOnayEposta, byte tintMusteriDurumID, bool blPasif, bool blCHvar, string strUnvan,
            byte tintIlID, byte tintOnerilenFiyatYuzde, bool blSicakSatis, int intSiparisUrunSayisi, int intRaporSatirSayisi, int intSiparisSatirSayisi)
        {
            this._tintUyeTipiID = tintUyeTipiID;
            this._intUyeGrupID = intUyeGrupID;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._strVergiDairesi = strVergiDairesi;
            this._strVergiNo = strVergiNo;
            this._strTelefon = strTelefon;
            this._strEposta = strEposta;
            this.binKullaniciAdi = binKullaniciAdi;
            this.binSifre = binSifre;
            this._blSatisOnayi = blSatisOnayi;
            this._blBilgiIslemOnayi = blBilgiIslemOnayi;
            this._dtBasvuruTarihi = dtBasvuruTarihi;
            this._dtSatisOnayTarihi = dtSatisOnayTarihi;
            this._dtBilgiIslemOnayTarihi = dtBilgiIslemOnayTarihi;
            this._blTaksitPlani = blTaksitPlani;
            this._intGMREF = intGMREF;
            this._intSLSREF = intSLSREF;
            this._intSonYarimSiparisID = intSonYarimSiparisID;
            this._blSistemde = blSistemde;
            this._blTalepEposta = blTalepEposta;
            this._blOnayEposta = blOnayEposta;
            this._tintMusteriDurumID = tintMusteriDurumID;
            this._blPasif = blPasif;
            this._blCHvar = blCHvar;
            this._strUnvan = strUnvan;
            this._tintIlID = tintIlID;
            this._tintOnerilenFiyatYuzde = tintOnerilenFiyatYuzde;
            this._blSicakSatis = blSicakSatis;
            this._intSiparisUrunSayisi = intSiparisUrunSayisi;
            this._intRaporSatirSayisi = intRaporSatirSayisi;
            this._intSiparisSatirSayisi = intSiparisSatirSayisi;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkMusteriID { get { return this._pkMusteriID; } }
        public byte tintUyeTipiID { get { return this._tintUyeTipiID; } set { this._tintUyeTipiID = value; } }
        public int intUyeGrupID { get { return this._intUyeGrupID; } set { this._intUyeGrupID = value; } }
        public string strAd { get { return this._strAd; } set { this._strAd = value; } }
        public string strSoyad { get { return this._strSoyad; } set { this._strSoyad = value; } }
        public string strVergiDairesi { get { return this._strVergiDairesi; } set { this._strVergiDairesi = value; } }
        public string strVergiNo { get { return this._strVergiNo; } set { this._strVergiNo = value; } }
        public string strTelefon { get { return this._strTelefon; } set { this._strTelefon = value; } }
        public string strEposta { get { return this._strEposta; } set { this._strEposta = value; } }
        public string binKullaniciAdi { get { return System.Text.UTF8Encoding.GetEncoding(1254).GetString(this._binKullaniciAdi); } set { this._binKullaniciAdi = System.Text.UTF8Encoding.GetEncoding(1254).GetBytes(value); } }
        public string binSifre { get { return System.Text.UTF8Encoding.GetEncoding(1254).GetString(this._binSifre); } set { this._binSifre = System.Text.UTF8Encoding.GetEncoding(1254).GetBytes(value); } }
        public bool blSatisOnayi { get { return this._blSatisOnayi; } set { this._blSatisOnayi = value; } }
        public bool blBilgiIslemOnayi { get { return this._blBilgiIslemOnayi; } set { this._blBilgiIslemOnayi = value; } }
        public DateTime dtBasvuruTarihi { get { return this._dtBasvuruTarihi; } set { this._dtBasvuruTarihi = value; } }
        public DateTime dtSatisOnayTarihi { get { return this._dtSatisOnayTarihi; } set { this._dtSatisOnayTarihi = value; } }
        public DateTime dtBilgiIslemOnayTarihi { get { return this._dtBilgiIslemOnayTarihi; } set { this._dtBilgiIslemOnayTarihi = value; } }
        public bool blTaksitPlani { get { return this._blTaksitPlani; } set { this._blTaksitPlani = value; } }
        public int intGMREF { get { return this._intGMREF; } set { this._intGMREF = value; } }
        public int intSLSREF { get { return this._intSLSREF; } set { this._intSLSREF = value; } }
        public int intSonYarimSiparisID { get { return this._intSonYarimSiparisID; } set { this._intSonYarimSiparisID = value; } }
        public bool blSistemde { get { return this._blSistemde; } set { this._blSistemde = value; } }
        public bool blTalepEposta { get { return this._blTalepEposta; } set { this._blTalepEposta = value; } }
        public bool blOnayEposta { get { return this._blOnayEposta; } set { this._blOnayEposta = value; } }
        public byte tintMusteriDurumID { get { return this._tintMusteriDurumID; } set { this._tintMusteriDurumID = value; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public bool blCHvar { get { return this._blCHvar; } set { this._blCHvar = value; } }
        public string strUnvan { get { return this._strUnvan; } set { this._strUnvan = value; } }
        public byte tintIlID { get { return this._tintIlID; } set { this._tintIlID = value; } }
        public byte tintOnerilenFiyatYuzde { get { return this._tintOnerilenFiyatYuzde; } set { this._tintOnerilenFiyatYuzde = value; } }
        public bool blSicakSatis { get { return this._blSicakSatis; } set { this._blSicakSatis = value; } }
        public int intSiparisUrunSayisi { get { return this._intSiparisUrunSayisi; } set { this._intSiparisUrunSayisi = value; } }
        public int intRaporSatirSayisi { get { return this._intRaporSatirSayisi; } set { this._intRaporSatirSayisi = value; } }
        public int intSiparisSatirSayisi { get { return this._intSiparisSatirSayisi; } set { this._intSiparisSatirSayisi = value; } }
        //
        //
        //
        // Yoketme metodu:
        //
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //
        //
        //
        // ToString:
        //
        public override string ToString()
        {
            return this._strAd + " " + this._strSoyad;
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object SatisOnayTarihi = DBNull.Value;
            object BilgiIslemOnayTarihi = DBNull.Value;
            if (_dtBasvuruTarihi != _dtSatisOnayTarihi)
                SatisOnayTarihi = this._dtSatisOnayTarihi;
            if (_dtBasvuruTarihi != _dtBilgiIslemOnayTarihi)
                BilgiIslemOnayTarihi = this._dtBilgiIslemOnayTarihi;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintUyeTipiID", SqlDbType.TinyInt).Value = this._tintUyeTipiID;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar).Value = this._strSoyad;
                cmd.Parameters.Add("@strVergiDairesi", SqlDbType.NVarChar).Value = this._strVergiDairesi;
                cmd.Parameters.Add("@strVergiNo", SqlDbType.NVarChar).Value = this._strVergiNo;
                cmd.Parameters.Add("@strTelefon", SqlDbType.NVarChar).Value = this._strTelefon;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = this._strEposta;
                cmd.Parameters.Add("@binKullaniciAdi", SqlDbType.VarBinary, 16).Value = this._binKullaniciAdi;
                cmd.Parameters.Add("@binSifre", SqlDbType.VarBinary, 16).Value = this._binSifre;
                cmd.Parameters.Add("@blSatisOnayi", SqlDbType.Bit).Value = this._blSatisOnayi;
                cmd.Parameters.Add("@blBilgiIslemOnayi", SqlDbType.Bit).Value = this._blBilgiIslemOnayi;
                cmd.Parameters.Add("@dtBasvuruTarihi", SqlDbType.SmallDateTime).Value = this._dtBasvuruTarihi;
                cmd.Parameters.Add("@dtSatisOnayTarihi", SqlDbType.SmallDateTime).Value = SatisOnayTarihi;
                cmd.Parameters.Add("@dtBilgiIslemOnayTarihi", SqlDbType.SmallDateTime).Value = BilgiIslemOnayTarihi;
                cmd.Parameters.Add("@blTaksitPlani", SqlDbType.Bit).Value = this._blTaksitPlani;
                cmd.Parameters.Add("@intGMREF", SqlDbType.Int).Value = this._intGMREF;
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = this._intSLSREF;
                cmd.Parameters.Add("@intSonYarimSiparisID", SqlDbType.Int).Value = this._intSonYarimSiparisID;
                cmd.Parameters.Add("@blSistemde", SqlDbType.Bit).Value = this._blSistemde;
                cmd.Parameters.Add("@blTalepEposta", SqlDbType.Bit).Value = this._blTalepEposta;
                cmd.Parameters.Add("@blOnayEposta", SqlDbType.Bit).Value = this._blOnayEposta;
                cmd.Parameters.Add("@tintMusteriDurumID", SqlDbType.TinyInt).Value = this._tintMusteriDurumID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@blCHvar", SqlDbType.Bit).Value = this._blCHvar;
                cmd.Parameters.Add("@strUnvan", SqlDbType.NVarChar).Value = this._strUnvan;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = this._tintIlID;
                cmd.Parameters.Add("@tintOnerilenFiyatYuzde", SqlDbType.TinyInt).Value = this._tintOnerilenFiyatYuzde;
                cmd.Parameters.Add("@blSicakSatis", SqlDbType.Bit).Value = this._blSicakSatis;
                cmd.Parameters.Add("@intSiparisUrunSayisi", SqlDbType.Int).Value = this._intSiparisUrunSayisi;
                cmd.Parameters.Add("@intRaporSatirSayisi", SqlDbType.Int).Value = this._intRaporSatirSayisi;
                cmd.Parameters.Add("@intSiparisSatirSayisi", SqlDbType.Int).Value = this._intSiparisSatirSayisi;
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkMusteriID = Convert.ToInt32(cmd.Parameters["@pkMusteriID"].Value);
                }
                catch (SqlException ex)
                {
                    if (ex.ErrorCode == -2146232060)
                        this.strAd = "kayıtlı";
                    else
                        Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoUpdate()
        {
            object SatisOnayTarihi = DBNull.Value;
            object BilgiIslemOnayTarihi = DBNull.Value;
            if (_dtSatisOnayTarihi != DateTime.MinValue)
                SatisOnayTarihi = this._dtSatisOnayTarihi;
            if (_dtBilgiIslemOnayTarihi != DateTime.MinValue)
                BilgiIslemOnayTarihi = this._dtBilgiIslemOnayTarihi;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = this._pkMusteriID;
                cmd.Parameters.Add("@tintUyeTipiID", SqlDbType.TinyInt).Value = this._tintUyeTipiID;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar).Value = this._strSoyad;
                cmd.Parameters.Add("@strVergiDairesi", SqlDbType.NVarChar).Value = this._strVergiDairesi;
                cmd.Parameters.Add("@strVergiNo", SqlDbType.NVarChar).Value = this._strVergiNo;
                cmd.Parameters.Add("@strTelefon", SqlDbType.NVarChar).Value = this._strTelefon;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = this._strEposta;
                cmd.Parameters.Add("@binKullaniciAdi", SqlDbType.VarBinary, 16).Value = this._binKullaniciAdi;
                cmd.Parameters.Add("@binSifre", SqlDbType.VarBinary, 16).Value = this._binSifre;
                cmd.Parameters.Add("@blSatisOnayi", SqlDbType.Bit).Value = this._blSatisOnayi;
                cmd.Parameters.Add("@blBilgiIslemOnayi", SqlDbType.Bit).Value = this._blBilgiIslemOnayi;
                cmd.Parameters.Add("@dtBasvuruTarihi", SqlDbType.SmallDateTime).Value = this._dtBasvuruTarihi;
                cmd.Parameters.Add("@dtSatisOnayTarihi", SqlDbType.SmallDateTime).Value = SatisOnayTarihi;
                cmd.Parameters.Add("@dtBilgiIslemOnayTarihi", SqlDbType.SmallDateTime).Value = BilgiIslemOnayTarihi;
                cmd.Parameters.Add("@blTaksitPlani", SqlDbType.Bit).Value = this._blTaksitPlani;
                cmd.Parameters.Add("@intGMREF", SqlDbType.Int).Value = this._intGMREF;
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = this._intSLSREF;
                cmd.Parameters.Add("@intSonYarimSiparisID", SqlDbType.Int).Value = this._intSonYarimSiparisID;
                cmd.Parameters.Add("@blSistemde", SqlDbType.Bit).Value = this._blSistemde;
                cmd.Parameters.Add("@blTalepEposta", SqlDbType.Bit).Value = this._blTalepEposta;
                cmd.Parameters.Add("@blOnayEposta", SqlDbType.Bit).Value = this._blOnayEposta;
                cmd.Parameters.Add("@tintMusteriDurumID", SqlDbType.TinyInt).Value = this._tintMusteriDurumID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@blCHvar", SqlDbType.Bit).Value = this._blCHvar;
                cmd.Parameters.Add("@strUnvan", SqlDbType.NVarChar).Value = this._strUnvan;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = this._tintIlID;
                cmd.Parameters.Add("@tintOnerilenFiyatYuzde", SqlDbType.TinyInt).Value = this._tintOnerilenFiyatYuzde;
                cmd.Parameters.Add("@blSicakSatis", SqlDbType.Bit).Value = this._blSicakSatis;
                cmd.Parameters.Add("@intSiparisUrunSayisi", SqlDbType.Int).Value = this._intSiparisUrunSayisi;
                cmd.Parameters.Add("@intRaporSatirSayisi", SqlDbType.Int).Value = this._intRaporSatirSayisi;
                cmd.Parameters.Add("@intSiparisSatirSayisi", SqlDbType.Int).Value = this._intSiparisSatirSayisi;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = this._pkMusteriID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerGetirOrderByDesc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        List.Add(new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), 
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), 
                            dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], (byte[])dr[10], Convert.ToBoolean(dr[11]), 
                            Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]), SatisOnayTarihi, BilgiIslemOnayTarihi, 
                            Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]), Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjectsAktifler(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerGetirAktiflerOrderByDesc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        List.Add(new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(),
                            dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], (byte[])dr[10], Convert.ToBoolean(dr[11]),
                            Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]), SatisOnayTarihi, BilgiIslemOnayTarihi,
                            Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]), Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjectsOnlySattemsAndYoneticis(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID, tintUyeTipiID, intUyeGrupID, strAd, strSoyad, strVergiDairesi, strVergiNo, strTelefon, strEposta, binKullaniciAdi, binSifre, blSatisOnayi, blBilgiIslemOnayi, dtBasvuruTarihi, dtSatisOnayTarihi, dtBilgiIslemOnayTarihi, blTaksitPlani, intGMREF, intSLSREF, intSonYarimSiparisID, blSistemde, blTalepEposta, blOnayEposta, tintMusteriDurumID, blPasif, blCHvar, strUnvan, tintIlID, tintOnerilenFiyatYuzde, blSicakSatis, intSiparisUrunSayisi, intRaporSatirSayisi, intSiparisSatirSayisi FROM tblINTERNET_Musteriler WHERE tintUyeTipiID = 4 OR tintUyeTipiID = 2 ORDER BY strAd", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        List.Add(new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(),
                            dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], (byte[])dr[10], Convert.ToBoolean(dr[11]),
                            Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]), SatisOnayTarihi, BilgiIslemOnayTarihi,
                            Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]), Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjectsOnlySattemsYoneticisBayiYoneticis(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID, tintUyeTipiID, intUyeGrupID, strAd, strSoyad, strVergiDairesi, strVergiNo, strTelefon, strEposta, binKullaniciAdi, binSifre, blSatisOnayi, blBilgiIslemOnayi, dtBasvuruTarihi, dtSatisOnayTarihi, dtBilgiIslemOnayTarihi, blTaksitPlani, intGMREF, intSLSREF, intSonYarimSiparisID, blSistemde, blTalepEposta, blOnayEposta, tintMusteriDurumID, blPasif, blCHvar, strUnvan, tintIlID, tintOnerilenFiyatYuzde, blSicakSatis, intSiparisUrunSayisi, intRaporSatirSayisi, intSiparisSatirSayisi FROM tblINTERNET_Musteriler WHERE tintUyeTipiID = 4 OR tintUyeTipiID = 2 OR tintUyeTipiID = 6 ORDER BY strAd", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        List.Add(new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(),
                            dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], (byte[])dr[10], Convert.ToBoolean(dr[11]),
                            Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]), SatisOnayTarihi, BilgiIslemOnayTarihi,
                            Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]), Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjects(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                ListItem lst1 = new ListItem();
                lst1.Text = "Seçiniz";
                lst1.Value = "0";
                lic.Add(lst1);

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[3].ToString() + " " + dr[4].ToString();
                        lst.Value = dr[0].ToString();
                        lic.Add(lst);
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjects(ListItemCollection lic, ArrayList SLSREFs, bool Web)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                ListItem lst1 = new ListItem();
                lst1.Text = "Seçiniz";
                lst1.Value = "0";
                lic.Add(lst1);

                string slsrefs = string.Empty;
                if (SLSREFs.Count > 0)
                    slsrefs = "WHERE ";
                for (int i = 0; i < SLSREFs.Count; i++)
                {
                    slsrefs += "intSLSREF = " + SLSREFs[i].ToString() + " OR ";
                }
                if (SLSREFs.Count > 0)
                    slsrefs = slsrefs.Substring(0, slsrefs.Length - 3);

                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID, strAd, strSoyad FROM tblINTERNET_Musteriler " + slsrefs + "ORDER BY strAd", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString() + " " + dr[2].ToString();
                        lst.Value = dr[0].ToString();
                        lic.Add(lst);
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjectsSistemde(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerGetirSistemde", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        List.Add(new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(),
                            dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], (byte[])dr[10], Convert.ToBoolean(dr[11]),
                            Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]), SatisOnayTarihi, BilgiIslemOnayTarihi,
                            Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]), Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObjectByUyeGrupID(IList List, int UyeGrupID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerGetirByGrupID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = UyeGrupID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        List.Add(new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), 
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], 
                            (byte[])dr[10], Convert.ToBoolean(dr[11]), Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]),
                            SatisOnayTarihi, BilgiIslemOnayTarihi, Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]),
                            Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static Musteriler GetMusteriByID(int MusteriID)
        {
            /*SAP*/
            Musteriler musteri = new Musteriler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = MusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime SatisOnayTarihi = DateTime.MinValue;                ///////////////////////////////////
                        DateTime BilgiIslemOnayTarihi = DateTime.MinValue;         ///////////////////////////////////
                        if (dr[14] != DBNull.Value)
                        {
                            SatisOnayTarihi = Convert.ToDateTime(dr[14]);
                        }
                        if (dr[15] != DBNull.Value)
                        {
                            BilgiIslemOnayTarihi = Convert.ToDateTime(dr[15]);
                        }

                        musteri = new Musteriler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), 
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), (byte[])dr[9], 
                            (byte[])dr[10], Convert.ToBoolean(dr[11]), Convert.ToBoolean(dr[12]), Convert.ToDateTime(dr[13]),
                            SatisOnayTarihi, BilgiIslemOnayTarihi, Convert.ToBoolean(dr[16]), Convert.ToInt32(dr[17]),
                            Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]),
                            Convert.ToBoolean(dr[20]), Convert.ToBoolean(dr[21]), Convert.ToBoolean(dr[22]), Convert.ToByte(dr[23]),
                            Convert.ToBoolean(dr[24]), Convert.ToBoolean(dr[25]), dr[26].ToString(), Convert.ToByte(dr[27]), Convert.ToByte(dr[28]),
                            Convert.ToBoolean(dr[29]), Convert.ToInt32(dr[30]), Convert.ToInt32(dr[31]), Convert.ToInt32(dr[32]));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return musteri;
        }
        //
        //
        public static int GetUyeGrubuByMusteriID(int MusteriID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT intUyeGrupID FROM tblINTERNET_Musteriler WHERE pkMusteriID = @pkMusteriID", conn);
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        /// <summary>
        /// 0:bool giris kontrolu,
        /// 1:bool satis onayi,
        /// 2:bool bilgiislem onayi,
        /// 3:bool sistemde mi,
        /// 4:bool pasif mi,
        /// 5:int musteriid.
        /// </summary>
        public static ArrayList ValidateCustomer(string Eposta, string Sifre)
        {
            ArrayList sonuc = new ArrayList();
            sonuc.Add(false);
            sonuc.Add(false);
            sonuc.Add(false);
            sonuc.Add(false);
            sonuc.Add(false);
            sonuc.Add(0);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriGirisKontrol", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = Eposta;
                cmd.Parameters.Add("@binSifre", SqlDbType.VarBinary, 16).Value = System.Text.UTF8Encoding.GetEncoding(1254).GetBytes(Sifre);
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        sonuc[0] = Convert.ToBoolean(dr[0]); // giris kontrolu
                        sonuc[1] = Convert.ToBoolean(dr[1]); // satis onayi
                        sonuc[2] = Convert.ToBoolean(dr[2]); // bilgiislem onayi
                        sonuc[3] = Convert.ToBoolean(dr[3]); // sistemde mi
                        sonuc[4] = Convert.ToBoolean(dr[4]); // pasif mi
                        sonuc[5] = Convert.ToInt32(dr[5]); // musteriid
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return sonuc;
        }
        //
        //
        public static bool MusteriVarMi(string Eposta)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriVarMi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = Eposta;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static int KacKisiSistemde()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriSistemdeSayisi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static int GetMusteriIDbyEposta(string Eposta)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID FROM tblINTERNET_Musteriler WHERE strEposta = @strEposta", conn);
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = Eposta;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static int GetMusteriIDbyGMREF(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID FROM tblINTERNET_Musteriler WHERE intGMREF = @intGMREF", conn);
                cmd.Parameters.Add("@intGMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static int GetMusteriIDbySLSREF(int SLSREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID FROM tblINTERNET_Musteriler WHERE intSLSREF = @intSLSREF ORDER BY pkMusteriID DESC", conn);
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static ArrayList GetMusteriIDsBySLSREFs(ArrayList SLSREFs)
        {
            ArrayList donendeger = new ArrayList();

            string slsrefs = string.Empty;
            if (SLSREFs.Count > 0)
            {
                slsrefs = " WHERE";
                for (int i = 0; i < SLSREFs.Count; i++)
                {
                    slsrefs += " intSLSREF = " + SLSREFs[i].ToString() + " OR";
                }
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 3);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkMusteriID FROM tblINTERNET_Musteriler" + slsrefs, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(Convert.ToInt32(dr[0]));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static int GetSLSREFbyMusteriID(int MusteriID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT intSLSREF FROM tblINTERNET_Musteriler WHERE pkMusteriID = @pkMusteriID", conn);
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        /// <summary>
        /// pasif müşteri ise 0 dönüyor
        /// </summary>
        public static int GetGMREFByEpostaSifre(string Eposta, string Sifre)
        {
            int GMREF = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT intGMREF FROM tblINTERNET_Musteriler WHERE strEposta = @strEposta AND binSifre = @binSifre AND blPasif = 'False'", conn);
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = Eposta;
                cmd.Parameters.Add("@binSifre", SqlDbType.VarBinary, 16).Value = System.Text.UTF8Encoding.GetEncoding(1254).GetBytes(Sifre);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        GMREF = Convert.ToInt32(obj);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return GMREF;
        }
        //
        //
        public static void SistemdeDegilYap(int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Musteriler SET blSistemde = 'False' WHERE pkMusteriID = @pkMusteriID", conn);
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void SonSiparisSifir(int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Musteriler SET intSonYarimSiparisID = 0 WHERE pkMusteriID = @pkMusteriID", conn);
                cmd.Parameters.Add("@pkMusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static bool BayiYonHesabiVarMi(int SLSREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkMusteriID) FROM tblINTERNET_Musteriler WHERE tintUyeTipiID = 6 AND intSLSREF = @intSLSREF AND blPasif = 'False'", conn);
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static bool BirdenFazlaHesabiVarMi(int SLSREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkMusteriID) FROM tblINTERNET_Musteriler WHERE intSLSREF = @intSLSREF AND blPasif = 'False'", conn);
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt32(cmd.ExecuteScalar()) > 1 ? true : false;
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
    }
}
