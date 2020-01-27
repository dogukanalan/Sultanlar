using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT_AracGiderleri : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkAracGiderID;
        private int _intArabaID;
        private byte _tintAracFirmaID;
        private string _dtTarih;
        private double _flYakit;
        private string _strFaturaNo;
        private string _strFaturaDetayi;
        private double _flTutar;
        private byte _tintKDV;
        private double _flToplamTutar;
        private byte _tintVade;
        private string _dtOdemeTarihi;
        //
        //
        //
        // Constracter lar:
        //
        private AT_AracGiderleri(int pkAracGiderID, int intArabaID, byte tintAracFirmaID, string dtTarih, double flYakit, string strFaturaNo, string strFaturaDetayi,
            double flTutar, byte tintKDV, double flToplamTutar, byte tintVade, string dtOdemeTarihi)
        {
            this._pkAracGiderID = pkAracGiderID;
            this._intArabaID = intArabaID;
            this._tintAracFirmaID = tintAracFirmaID;
            this._dtTarih = dtTarih;
            this._flYakit = flYakit;
            this._strFaturaNo = strFaturaNo;
            this._strFaturaDetayi = strFaturaDetayi;
            this._flTutar = flTutar;
            this._tintKDV = tintKDV;
            this._flToplamTutar = flToplamTutar;
            this._tintVade = tintVade;
            this._dtOdemeTarihi = dtOdemeTarihi;
        }
        //
        //
        public AT_AracGiderleri(int intArabaID, byte tintAracFirmaID, string dtTarih, double flYakit, string strFaturaNo, string strFaturaDetayi,
            double flTutar, byte tintKDV, double flToplamTutar, byte tintVade, string dtOdemeTarihi)
        {
            this._intArabaID = intArabaID;
            this._tintAracFirmaID = tintAracFirmaID;
            this._dtTarih = dtTarih;
            this._flYakit = flYakit;
            this._strFaturaNo = strFaturaNo;
            this._strFaturaDetayi = strFaturaDetayi;
            this._flTutar = flTutar;
            this._tintKDV = tintKDV;
            this._flToplamTutar = flToplamTutar;
            this._tintVade = tintVade;
            this._dtOdemeTarihi = dtOdemeTarihi;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkAracGiderID
        {
            get
            {
                return this._pkAracGiderID;
            }
        }
        //
        //
        public int intArabaID
        {
            get
            {
                return this._intArabaID;
            }
            set
            {
                this._intArabaID = value;
            }
        }
        //
        //
        public byte tintAracFirmaID
        {
            get
            {
                return this._tintAracFirmaID;
            }
            set
            {
                this._tintAracFirmaID = value;
            }
        }
        //
        //
        public string dtTarih
        {
            get
            {
                return this._dtTarih;
            }
            set
            {
                this._dtTarih = value;
            }
        }
        //
        //
        public double flYakit
        {
            get
            {
                return this._flYakit;
            }
            set
            {
                this._flYakit = value;
            }
        }
        //
        //
        public string strFaturaNo
        {
            get
            {
                return this._strFaturaNo;
            }
            set
            {
                this._strFaturaNo = value;
            }
        }
        //
        //
        public string strFaturaDetayi
        {
            get
            {
                return this._strFaturaDetayi;
            }
            set
            {
                this._strFaturaDetayi = value;
            }
        }
        //
        //
        public double flTutar
        {
            get
            {
                return this._flTutar;
            }
            set
            {
                this._flTutar = value;
            }
        }
        //
        //
        public byte tintKDV
        {
            get
            {
                return this._tintKDV;
            }
            set
            {
                this._tintKDV = value;
            }
        }
        //
        //
        public double flToplamTutar
        {
            get
            {
                return this._flToplamTutar;
            }
            set
            {
                this._flToplamTutar = value;
            }
        }
        //
        //
        public byte tintVade
        {
            get
            {
                return this._tintVade;
            }
            set
            {
                this._tintVade = value;
            }
        }
        //
        //
        public string dtOdemeTarihi
        {
            get
            {
                return this._dtOdemeTarihi;
            }
            set
            {
                this._dtOdemeTarihi = value;
            }
        }
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
            return this._pkAracGiderID.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object Tarih = DBNull.Value;
            object OdemeTarihi = DBNull.Value;
            //object FirmaID = DBNull.Value;
            //object Yakit = DBNull.Value;
            //object Tutar = DBNull.Value;
            //object Toplamtutar = DBNull.Value;
            //object Vade = DBNull.Value;

            if (_dtTarih != string.Empty)
                Tarih = DateTime.Parse(_dtTarih);
            if (_dtOdemeTarihi != string.Empty)
                OdemeTarihi = DateTime.Parse(_dtOdemeTarihi);
            //if (_tintAracFirmaID != 0)
            //    FirmaID = this._tintAracFirmaID;
            //if (_flYakit != 0)
            //    Yakit = this._flYakit;
            //if (_flTutar != 0)
            //    Tutar = this._flTutar;
            //if (_flToplamTutar != 0)
            //    Toplamtutar = this._flToplamTutar;
            //if (_tintVade != 0)
            //    Vade = this._tintVade;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_AracGideriEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = this._intArabaID;
                cmd.Parameters.Add("@tintAracFirmaID", SqlDbType.TinyInt).Value = this._tintAracFirmaID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.SmallDateTime).Value = Tarih;
                cmd.Parameters.Add("@flYakit", SqlDbType.Float).Value = this._flYakit;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar).Value = this._strFaturaNo;
                cmd.Parameters.Add("@strFaturaDetayi", SqlDbType.NVarChar).Value = this._strFaturaDetayi;
                cmd.Parameters.Add("@flTutar", SqlDbType.Float).Value = this._flTutar;
                cmd.Parameters.Add("@tintKDV", SqlDbType.TinyInt).Value = this._tintKDV;
                cmd.Parameters.Add("@flToplamTutar", SqlDbType.Float).Value = this._flToplamTutar;
                cmd.Parameters.Add("@tintVade", SqlDbType.TinyInt).Value = this._tintVade;
                cmd.Parameters.Add("@dtOdemeTarihi", SqlDbType.SmallDateTime).Value = OdemeTarihi;
                cmd.Parameters.Add("@pkAracGiderID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkAracGiderID = Convert.ToByte(cmd.Parameters["@pkAracGiderID"].Value);
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
            object Tarih = DBNull.Value;
            object OdemeTarihi = DBNull.Value;
            if (_dtTarih != string.Empty)
                Tarih = DateTime.Parse(_dtTarih);
            if (_dtOdemeTarihi != string.Empty)
                OdemeTarihi = DateTime.Parse(_dtOdemeTarihi);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_AracGideriGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAracGiderID", SqlDbType.Int).Value = this._pkAracGiderID;
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = this._intArabaID;
                cmd.Parameters.Add("@tintAracFirmaID", SqlDbType.TinyInt).Value = this._tintAracFirmaID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.SmallDateTime).Value = Tarih;
                cmd.Parameters.Add("@flYakit", SqlDbType.Float).Value = this._flYakit;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar).Value = this._strFaturaNo;
                cmd.Parameters.Add("@strFaturaDetayi", SqlDbType.NVarChar).Value = this._strFaturaDetayi;
                cmd.Parameters.Add("@flTutar", SqlDbType.Float).Value = this._flTutar;
                cmd.Parameters.Add("@tintKDV", SqlDbType.TinyInt).Value = this._tintKDV;
                cmd.Parameters.Add("@flToplamTutar", SqlDbType.Float).Value = this._flToplamTutar;
                cmd.Parameters.Add("@tintVade", SqlDbType.TinyInt).Value = this._tintVade;
                cmd.Parameters.Add("@dtOdemeTarihi", SqlDbType.SmallDateTime).Value = OdemeTarihi;
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
                SqlCommand cmd = new SqlCommand("sp_AT_AracGideriSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAracGiderID", SqlDbType.Int).Value = this._pkAracGiderID;
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
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_AT_AracGiderleriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_AracGiderleri(Convert.ToInt32(dr[0]) ,Convert.ToInt32(dr[1]), Convert.ToByte(dr[2]), dr[3].ToString(), Convert.ToDouble(dr[4]), 
                            dr[5].ToString(), dr[6].ToString(), Convert.ToDouble(dr[7]), Convert.ToByte(dr[8]), Convert.ToDouble(dr[9]), Convert.ToByte(dr[10]), 
                            dr[11].ToString()));
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
        public static void GetObjectByID(IList List, int ID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_AT_AracGideriGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAracGiderID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        List.Add(new AT_AracGiderleri(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToByte(dr[2]), dr[3].ToString(), Convert.ToDouble(dr[4]),
                            dr[5].ToString(), dr[6].ToString(), Convert.ToDouble(dr[7]), Convert.ToByte(dr[8]), Convert.ToDouble(dr[9]), Convert.ToByte(dr[10]),
                            dr[11].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_AracGiderleriGetirVW", conn);
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
        public static void GetObjectByArabaID(DataTable dt, int ArabaID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_AracGideriGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intArabaID", SqlDbType.Int).Value = ArabaID;
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
    }
}
