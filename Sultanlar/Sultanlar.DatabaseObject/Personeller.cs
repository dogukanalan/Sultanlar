using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Personeller : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkPerID;
        private short _sintPerKod;
        private string _strPerAd;
        private byte _tintDepartmanID;
        private byte _tintGorevID;
        private string _strGorevTanimi;
        private string _dtPerGiris;
        private string _dtPerCikis;
        private bool _blPerDurum;
        private bool _blPerCinsiyet;
        private string _dtPerDogumTarihi;
        private string _strPerTCKimlikNo;
        private string _strPerSSKNo;
        private byte _tintKanGrubuID;
        private byte _tintAskerlikDurumuID;
        private byte _tintMedeniDurumID;
        private string _dtPerEvlilikTarihi;
        private byte _tintPerCocukSayisi;
        private string _strPerAdres;
        private byte _tintIlID;
        private short _sintIlceID;
        private string _strPerTelefon;
        private byte _tintOgrenimDurumuID;
        private byte _tintSurucuBelgeSinifiID;
        private byte _tintPerFirmaID;
        private byte _tintPerSSKFirmaID;
        private string _strPerAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private Personeller(int pkPerID, short sintPerKod, string strPerAd, byte tintDepartmanID, byte tintGorevID, string strGorevTanimi, string dtPerGiris, string dtPerCikis,
            bool blPerDurum, bool blPerCinsiyet, string dtPerDogumTarihi, string strPerTCKimlikNo, string strPerSSKNo, byte tintKanGrubuID,
            byte tintAskerlikDurumuID, byte tintMedeniDurumID, string dtPerEvlilikTarihi, byte tintPerCocukSayisi, string strPerAdres, byte tintIlID, short sintIlceID,
            string strPerTelefon, byte tintOgrenimDurumuID, byte tintSurucuBelgeSinifiID, byte tintPerFirmaID, byte tintPerSSKFirmaID, string strPerAciklama)
        {
            this._pkPerID = pkPerID;
            this._sintPerKod = sintPerKod;
            this._strPerAd = strPerAd;
            this._tintDepartmanID = tintDepartmanID;
            this._tintGorevID = tintGorevID;
            this._strGorevTanimi = strGorevTanimi;
            this._dtPerGiris = dtPerGiris;
            this._dtPerCikis = dtPerCikis;
            this._blPerDurum = blPerDurum;
            this._blPerCinsiyet = blPerCinsiyet;
            this._dtPerDogumTarihi = dtPerDogumTarihi;
            this._strPerTCKimlikNo = strPerTCKimlikNo;
            this._strPerSSKNo = strPerSSKNo;
            this._tintKanGrubuID = tintKanGrubuID;
            this._tintAskerlikDurumuID = tintAskerlikDurumuID;
            this._tintMedeniDurumID = tintMedeniDurumID;
            this._dtPerEvlilikTarihi = dtPerEvlilikTarihi;
            this._tintPerCocukSayisi = tintPerCocukSayisi;
            this._strPerAdres = strPerAdres;
            this._tintIlID = tintIlID;
            this._sintIlceID = sintIlceID;
            this._strPerTelefon = strPerTelefon;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._tintSurucuBelgeSinifiID = tintSurucuBelgeSinifiID;
            this._tintPerFirmaID = tintPerFirmaID;
            this._tintPerSSKFirmaID = tintPerSSKFirmaID;
            this._strPerAciklama = strPerAciklama;
        }
        //
        //
        public Personeller(short sintPerKod, string strPerAd, byte tintDepartmanID, byte tintGorevID, string strGorevTanimi, string dtPerGiris, string dtPerCikis,
            bool blPerDurum, bool blPerCinsiyet, string dtPerDogumTarihi, string strPerTCKimlikNo, string strPerSSKNo, byte tintKanGrubuID,
            byte tintAskerlikDurumuID, byte tintMedeniDurumID, string dtPerEvlilikTarihi, byte tintPerCocukSayisi, string strPerAdres, byte tintIlID, short sintIlceID,
            string strPerTelefon, byte tintOgrenimDurumuID, byte tintSurucuBelgeSinifiID, byte tintPerFirmaID, byte tintPerSSKFirmaID, string strPerAciklama)
        {
            this._sintPerKod = sintPerKod;
            this._strPerAd = strPerAd;
            this._tintDepartmanID = tintDepartmanID;
            this._tintGorevID = tintGorevID;
            this._strGorevTanimi = strGorevTanimi;
            this._dtPerGiris = dtPerGiris;
            this._dtPerCikis = dtPerCikis;
            this._blPerDurum = blPerDurum;
            this._blPerCinsiyet = blPerCinsiyet;
            this._dtPerDogumTarihi = dtPerDogumTarihi;
            this._strPerTCKimlikNo = strPerTCKimlikNo;
            this._strPerSSKNo = strPerSSKNo;
            this._tintKanGrubuID = tintKanGrubuID;
            this._tintAskerlikDurumuID = tintAskerlikDurumuID;
            this._tintMedeniDurumID = tintMedeniDurumID;
            this._dtPerEvlilikTarihi = dtPerEvlilikTarihi;
            this._tintPerCocukSayisi = tintPerCocukSayisi;
            this._strPerAdres = strPerAdres;
            this._tintIlID = tintIlID;
            this._sintIlceID = sintIlceID;
            this._strPerTelefon = strPerTelefon;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._tintSurucuBelgeSinifiID = tintSurucuBelgeSinifiID;
            this._tintPerFirmaID = tintPerFirmaID;
            this._tintPerSSKFirmaID = tintPerSSKFirmaID;
            this._strPerAciklama = strPerAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkPerID
        {
            get
            {
                return this._pkPerID;
            }
        }
        public short sintPerKod { get { return this._sintPerKod; } set { this._sintPerKod = value; } }
        public string strPerAd { get { return this._strPerAd; } set { this._strPerAd = value; } }
        public byte tintDepartmanID { get { return this._tintDepartmanID; } set { this._tintDepartmanID = value; } }
        public byte tintGorevID { get { return this._tintGorevID; } set { this._tintGorevID = value; } }
        public string strGorevTanimi { get { return this._strGorevTanimi; } set { this._strGorevTanimi = value; } }
        public string dtPerGiris { get { return this._dtPerGiris; } set { this._dtPerGiris = value; } }
        public string dtPerCikis { get { return this._dtPerCikis; } set { this._dtPerCikis = value; } }
        public bool blPerDurum { get { return this._blPerDurum; } set { this._blPerDurum = value; } }
        public bool blPerCinsiyet { get { return this._blPerCinsiyet; } set { this._blPerCinsiyet = value; } }
        public string dtPerDogumTarihi { get { return this._dtPerDogumTarihi; } set { this._dtPerDogumTarihi = value; } }
        public string strPerTCKimlikNo { get { return this._strPerTCKimlikNo; } set { this._strPerTCKimlikNo = value; } }
        public string strPerSSKNo { get { return this._strPerSSKNo; } set { this._strPerSSKNo = value; } }
        public byte tintKanGrubuID { get { return this._tintKanGrubuID; } set { this._tintKanGrubuID = value; } }
        public byte tintAskerlikDurumuID { get { return this._tintAskerlikDurumuID; } set { this._tintAskerlikDurumuID = value; } }
        public byte tintMedeniDurumID { get { return this._tintMedeniDurumID; } set { this._tintMedeniDurumID = value; } }
        public string dtPerEvlilikTarihi { get { return this._dtPerEvlilikTarihi; } set { this._dtPerEvlilikTarihi = value; } }
        public byte tintPerCocukSayisi { get { return this._tintPerCocukSayisi; } set { this._tintPerCocukSayisi = value; } }
        public string strPerAdres { get { return this._strPerAdres; } set { this._strPerAdres = value; } }
        public byte tintIlID { get { return this._tintIlID; } set { this._tintIlID = value; } }
        public short sintIlceID { get { return this._sintIlceID; } set { this._sintIlceID = value; } }
        public string strPerTelefon { get { return this._strPerTelefon; } set { this._strPerTelefon = value; } }
        public byte tintOgrenimDurumuID { get { return this._tintOgrenimDurumuID; } set { this._tintOgrenimDurumuID = value; } }
        public byte tintSurucuBelgeSinifiID { get { return this._tintSurucuBelgeSinifiID; } set { this._tintSurucuBelgeSinifiID = value; } }
        public byte tintPerFirmaID { get { return this._tintPerFirmaID; } set { this._tintPerFirmaID = value; } }
        public byte tintPerSSKFirmaID { get { return this._tintPerSSKFirmaID; } set { this._tintPerSSKFirmaID = value; } }
        public string strPerAciklama { get { return this._strPerAciklama; } set { this._strPerAciklama = value; } }
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
        // Metodlar:
        //
        public void DoInsert()
        {
            object GirisTarihi = DBNull.Value;
            object CikisTarihi = DBNull.Value;
            object DogumTarihi = DBNull.Value;
            object TCKimlikNo = DBNull.Value;
            object SSKNo = DBNull.Value;
            object EvlilikTarihi = DBNull.Value;
            //object DepartmanID = DBNull.Value;
            //object GorevID = DBNull.Value;
            //object KanGrubuID = DBNull.Value;
            //object AskerlikDurumuID = DBNull.Value;
            //object MedeniDurumID = DBNull.Value;
            //object CocukSayisi = DBNull.Value;
            //object OgrenimDurumuID = DBNull.Value;
            //object SurucuBelgeSinifiID = DBNull.Value;
            //object FirmaID = DBNull.Value;
            //object SSKFirmaID = DBNull.Value;
            object Aciklama = DBNull.Value;

            if (_dtPerGiris != string.Empty)
                GirisTarihi = DateTime.Parse(_dtPerGiris);
            if (_dtPerCikis != string.Empty)
                CikisTarihi = DateTime.Parse(_dtPerCikis);
            if (_dtPerDogumTarihi != string.Empty)
                DogumTarihi = DateTime.Parse(_dtPerDogumTarihi);
            if (_strPerTCKimlikNo != string.Empty)
                TCKimlikNo = _strPerTCKimlikNo;
            if (_strPerSSKNo != string.Empty)
                SSKNo = _strPerSSKNo;
            if (_dtPerEvlilikTarihi != string.Empty)
                EvlilikTarihi = DateTime.Parse(_dtPerEvlilikTarihi);
            //if (_tintDepartmanID != 0)
            //    DepartmanID = _tintDepartmanID;
            //if (_tintGorevID != 0)
            //    GorevID = _tintGorevID;
            //if (_tintKanGrubuID != 0)
            //    KanGrubuID = _tintKanGrubuID;
            //if (_tintAskerlikDurumuID != 0)
            //    AskerlikDurumuID = _tintAskerlikDurumuID;
            //if (_tintMedeniDurumID != 0)
            //    MedeniDurumID = _tintMedeniDurumID;
            //if (_tintPerCocukSayisi != 0)
            //    CocukSayisi = _tintPerCocukSayisi;
            //if (_tintOgrenimDurumuID != 0)
            //    OgrenimDurumuID = _tintOgrenimDurumuID;
            //if (_tintSurucuBelgeSinifiID != 0)
            //    SurucuBelgeSinifiID = _tintSurucuBelgeSinifiID;
            //if (_tintPerFirmaID != 0)
            //    FirmaID = _tintPerFirmaID;
            //if (_tintPerSSKFirmaID != 0)
            //    SSKFirmaID = _tintPerSSKFirmaID;
            if (_strPerAciklama != string.Empty)
                Aciklama = _strPerAciklama;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_PersonelEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sintPerKod", SqlDbType.SmallInt).Value = this._sintPerKod;
                cmd.Parameters.Add("@strPerAd", SqlDbType.NVarChar).Value = this._strPerAd;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@tintGorevID", SqlDbType.TinyInt).Value = this._tintGorevID;
                cmd.Parameters.Add("@strGorevTanimi", SqlDbType.NVarChar).Value = this._strGorevTanimi;
                cmd.Parameters.Add("@dtPerGiris", SqlDbType.SmallDateTime).Value = GirisTarihi;
                cmd.Parameters.Add("@dtPerCikis", SqlDbType.SmallDateTime).Value = CikisTarihi;
                cmd.Parameters.Add("@blPerDurum", SqlDbType.Bit).Value = this._blPerDurum;
                cmd.Parameters.Add("@blPerCinsiyet", SqlDbType.Bit).Value = this._blPerCinsiyet;
                cmd.Parameters.Add("@dtPerDogumTarihi", SqlDbType.SmallDateTime).Value = DogumTarihi;
                cmd.Parameters.Add("@strPerTCKimlikNo", SqlDbType.NVarChar).Value = TCKimlikNo;
                cmd.Parameters.Add("@strPerSSKNo", SqlDbType.NVarChar).Value = SSKNo;
                cmd.Parameters.Add("@tintKanGrubuID", SqlDbType.SmallInt).Value = this._tintKanGrubuID;
                cmd.Parameters.Add("@tintAskerlikDurumuID", SqlDbType.TinyInt).Value = this._tintAskerlikDurumuID;
                cmd.Parameters.Add("@tintMedeniDurumID", SqlDbType.TinyInt).Value = this._tintMedeniDurumID;
                cmd.Parameters.Add("@dtPerEvlilikTarihi", SqlDbType.SmallDateTime).Value = EvlilikTarihi;
                cmd.Parameters.Add("@tintPerCocukSayisi", SqlDbType.TinyInt).Value = this._tintPerCocukSayisi;
                cmd.Parameters.Add("@strPerAdres", SqlDbType.NVarChar).Value = this._strPerAdres;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = 0; // ---------------------------------------------------
                cmd.Parameters.Add("@sintIlceID", SqlDbType.SmallInt).Value = 0; // ---------------------------------------------------
                cmd.Parameters.Add("@strPerTelefon", SqlDbType.NVarChar).Value = this._strPerTelefon;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@tintSurucuBelgeSinifiID", SqlDbType.TinyInt).Value = this._tintSurucuBelgeSinifiID;
                cmd.Parameters.Add("@tintPerFirmaID", SqlDbType.TinyInt).Value = this._tintPerFirmaID;
                cmd.Parameters.Add("@tintPerSSKFirmaID", SqlDbType.TinyInt).Value = this._tintPerSSKFirmaID;
                cmd.Parameters.Add("@strPerAciklama", SqlDbType.NVarChar).Value = Aciklama;
                cmd.Parameters.Add("@pkPerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkPerID = Convert.ToInt32(cmd.Parameters["@pkPerID"].Value);
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
        public void DoUpdate()
        {
            object GirisTarihi = DBNull.Value;
            object CikisTarihi = DBNull.Value;
            object DogumTarihi = DBNull.Value;
            object TCKimlikNo = DBNull.Value;
            object SSKNo = DBNull.Value;
            object EvlilikTarihi = DBNull.Value;
            //object DepartmanID = DBNull.Value;
            //object GorevID = DBNull.Value;
            //object KanGrubuID = DBNull.Value;
            //object AskerlikDurumuID = DBNull.Value;
            //object MedeniDurumID = DBNull.Value;
            //object CocukSayisi = DBNull.Value;
            //object OgrenimDurumuID = DBNull.Value;
            //object SurucuBelgeSinifiID = DBNull.Value;
            //object FirmaID = DBNull.Value;
            //object SSKFirmaID = DBNull.Value;
            object Aciklama = DBNull.Value;

            if (_dtPerGiris != string.Empty)
                GirisTarihi = DateTime.Parse(_dtPerGiris);
            if (_dtPerCikis != string.Empty)
                CikisTarihi = DateTime.Parse(_dtPerCikis);
            if (_dtPerDogumTarihi != string.Empty)
                DogumTarihi = DateTime.Parse(_dtPerDogumTarihi);
            if (_strPerTCKimlikNo != string.Empty)
                TCKimlikNo = _strPerTCKimlikNo;
            if (_strPerSSKNo != string.Empty)
                SSKNo = _strPerSSKNo;
            if (_dtPerEvlilikTarihi != string.Empty)
                EvlilikTarihi = DateTime.Parse(_dtPerEvlilikTarihi);
            //if (_tintDepartmanID != 0)
            //    DepartmanID = _tintDepartmanID;
            //if (_tintGorevID != 0)
            //    GorevID = _tintGorevID;
            //if (_tintKanGrubuID != 0)
            //    KanGrubuID = _tintKanGrubuID;
            //if (_tintAskerlikDurumuID != 0)
            //    AskerlikDurumuID = _tintAskerlikDurumuID;
            //if (_tintMedeniDurumID != 0)
            //    MedeniDurumID = _tintMedeniDurumID;
            //if (_tintPerCocukSayisi != 0)
            //    CocukSayisi = _tintPerCocukSayisi;
            //if (_tintOgrenimDurumuID != 0)
            //    OgrenimDurumuID = _tintOgrenimDurumuID;
            //if (_tintSurucuBelgeSinifiID != 0)
            //    SurucuBelgeSinifiID = _tintSurucuBelgeSinifiID;
            //if (_tintPerFirmaID != 0)
            //    FirmaID = _tintPerFirmaID;
            //if (_tintPerSSKFirmaID != 0)
            //    SSKFirmaID = _tintPerSSKFirmaID;
            if (_strPerAciklama != string.Empty)
                Aciklama = _strPerAciklama;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_PersonelGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkPerID", SqlDbType.Int).Value = this._pkPerID;
                cmd.Parameters.Add("@sintPerKod", SqlDbType.SmallInt).Value = this._sintPerKod;
                cmd.Parameters.Add("@strPerAd", SqlDbType.NVarChar).Value = this._strPerAd;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@tintGorevID", SqlDbType.TinyInt).Value = this._tintGorevID;
                cmd.Parameters.Add("@strGorevTanimi", SqlDbType.NVarChar).Value = this._strGorevTanimi;
                cmd.Parameters.Add("@dtPerGiris", SqlDbType.SmallDateTime).Value = GirisTarihi;
                cmd.Parameters.Add("@dtPerCikis", SqlDbType.SmallDateTime).Value = CikisTarihi;
                cmd.Parameters.Add("@blPerDurum", SqlDbType.Bit).Value = this._blPerDurum;
                cmd.Parameters.Add("@blPerCinsiyet", SqlDbType.Bit).Value = this._blPerCinsiyet;
                cmd.Parameters.Add("@dtPerDogumTarihi", SqlDbType.SmallDateTime).Value = DogumTarihi;
                cmd.Parameters.Add("@strPerTCKimlikNo", SqlDbType.NVarChar).Value = TCKimlikNo;
                cmd.Parameters.Add("@strPerSSKNo", SqlDbType.NVarChar).Value = SSKNo;
                cmd.Parameters.Add("@tintKanGrubuID", SqlDbType.SmallInt).Value = this._tintKanGrubuID;
                cmd.Parameters.Add("@tintAskerlikDurumuID", SqlDbType.TinyInt).Value = this._tintAskerlikDurumuID;
                cmd.Parameters.Add("@tintMedeniDurumID", SqlDbType.TinyInt).Value = this._tintMedeniDurumID;
                cmd.Parameters.Add("@dtPerEvlilikTarihi", SqlDbType.SmallDateTime).Value = EvlilikTarihi;
                cmd.Parameters.Add("@tintPerCocukSayisi", SqlDbType.TinyInt).Value = this._tintPerCocukSayisi;
                cmd.Parameters.Add("@strPerAdres", SqlDbType.NVarChar).Value = this._strPerAdres;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = 0; // ---------------------------------------------------
                cmd.Parameters.Add("@sintIlceID", SqlDbType.SmallInt).Value = 0; // ---------------------------------------------------
                cmd.Parameters.Add("@strPerTelefon", SqlDbType.NVarChar).Value = this._strPerTelefon;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@tintSurucuBelgeSinifiID", SqlDbType.TinyInt).Value = this._tintSurucuBelgeSinifiID;
                cmd.Parameters.Add("@tintPerFirmaID", SqlDbType.TinyInt).Value = this._tintPerFirmaID;
                cmd.Parameters.Add("@tintPerSSKFirmaID", SqlDbType.TinyInt).Value = this._tintPerSSKFirmaID;
                cmd.Parameters.Add("@strPerAciklama", SqlDbType.NVarChar).Value = Aciklama;
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
                SqlCommand cmd = new SqlCommand("sp_PersonelSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkPerID", SqlDbType.Int).Value = this._pkPerID;
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
        public static void GetObject(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_PersonelGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //List.Add(new Personeller(Convert.ToInt32(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString(), Convert.ToByte(dr[3]), Convert.ToByte(dr[4]), 
                            //dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), Convert.ToBoolean(dr[8]), Convert.ToBoolean(dr[9]), dr[10].ToString(), 
                            //dr[11].ToString(), dr[12].ToString(), Convert.ToByte(dr[13]), Convert.ToByte(dr[14]), Convert.ToByte(dr[15]), dr[16].ToString(),
                            //Convert.ToByte(dr[17]), dr[18].ToString(), Convert.ToByte(dr[19]), Convert.ToInt16(dr[20]), dr[21].ToString(), Convert.ToByte(dr[22]),
                            //Convert.ToByte(dr[23]), Convert.ToByte(dr[24]), Convert.ToByte(dr[25]), dr[22].ToString()));
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_PersonelGetirVW", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(dt);
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
        public static void GetObjectByKod(IList List, short Kod)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_PersonelGetirKodaGore", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sintPerKod", SqlDbType.SmallInt).Value = Kod;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        List.Add(new Personeller(Convert.ToInt32(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString(), Convert.ToByte(dr[3]), Convert.ToByte(dr[4]),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), Convert.ToBoolean(dr[8]), Convert.ToBoolean(dr[9]), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), Convert.ToByte(dr[13]), Convert.ToByte(dr[14]), Convert.ToByte(dr[15]), dr[16].ToString(),
                            Convert.ToByte(dr[17]), dr[18].ToString(), Convert.ToByte(dr[19]), Convert.ToInt16(dr[20]), dr[21].ToString(), Convert.ToByte(dr[22]),
                            Convert.ToByte(dr[23]), Convert.ToByte(dr[24]), Convert.ToByte(dr[25]), dr[26].ToString()));
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
    }
}
