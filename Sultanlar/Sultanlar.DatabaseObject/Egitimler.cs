using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Egitimler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkEgitimID;
        private int _intBasvuruID;
        private byte _tintOgrenimDurumuID;
        private string _strEgitimOkulAdi;
        private string _strEgitimBolum;
        private string _strEgitimBitirmeYili;
        //
        //
        //
        // Constracter lar:
        //
        private Egitimler(int pkEgitimID, int intBasvuruID, byte tintOgrenimDurumuID, string strEgitimOkulAdi, string strEgitimBolum, string strEgitimBitirmeYili)
        {
            this._pkEgitimID = pkEgitimID;
            this._intBasvuruID = intBasvuruID;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._strEgitimOkulAdi = strEgitimOkulAdi;
            this._strEgitimBolum = strEgitimBolum;
            this._strEgitimBitirmeYili = strEgitimBitirmeYili;
        }
        //
        //
        public Egitimler(int intBasvuruID, byte tintOgrenimDurumuID, string strEgitimOkulAdi, string strEgitimBolum, string strEgitimBitirmeYili)
        {
            this._intBasvuruID = intBasvuruID;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._strEgitimOkulAdi = strEgitimOkulAdi;
            this._strEgitimBolum = strEgitimBolum;
            this._strEgitimBitirmeYili = strEgitimBitirmeYili;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkEgitimID
        {
            get
            {
                return this._pkEgitimID;
            }
        }
        //
        //
        public int intBasvuruID
        {
            get
            {
                return this._intBasvuruID;
            }
            set
            {
                this._intBasvuruID = value;
            }
        }
        //
        //
        public byte tintOgrenimDurumuID
        {
            get
            {
                return this._tintOgrenimDurumuID;
            }
            set
            {
                this._tintOgrenimDurumuID = value;
            }
        }
        //
        //
        public string strEgitimOkulAdi
        {
            get
            {
                return this._strEgitimOkulAdi;
            }
            set
            {
                this._strEgitimOkulAdi = value;
            }
        }
        //
        //
        public string strEgitimBolum
        {
            get
            {
                return this._strEgitimBolum;
            }
            set
            {
                this._strEgitimBolum = value;
            }
        }
        //
        //
        public string strEgitimBitirmeYili
        {
            get
            {
                return this._strEgitimBitirmeYili;
            }
            set
            {
                this._strEgitimBitirmeYili = value;
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
        // Metodlar:
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EgitimEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@strEgitimOkulAdi", SqlDbType.NVarChar, 70).Value = this._strEgitimOkulAdi;
                cmd.Parameters.Add("@strEgitimBolum", SqlDbType.NVarChar, 60).Value = this._strEgitimBolum;
                cmd.Parameters.Add("@strEgitimBitirmeYili", SqlDbType.VarChar, 4).Value = this._strEgitimBitirmeYili;
                cmd.Parameters.Add("@pkEgitimID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkEgitimID = Convert.ToInt32(cmd.Parameters["@pkEgitimID"].Value);
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
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EgitimGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkEgitimID", SqlDbType.Int).Value = this._pkEgitimID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@strEgitimOkulAdi", SqlDbType.NVarChar, 70).Value = this._strEgitimOkulAdi;
                cmd.Parameters.Add("@strEgitimBolum", SqlDbType.NVarChar, 60).Value = this._strEgitimBolum;
                cmd.Parameters.Add("@strEgitimBitirmeYili", SqlDbType.VarChar, 4).Value = this._strEgitimBitirmeYili;
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
                SqlCommand cmd = new SqlCommand("sp_EgitimSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkEgitimID", SqlDbType.Int).Value = this._pkEgitimID;
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

                SqlCommand cmd = new SqlCommand("sp_EgitimGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Egitimler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToByte(dr[2]), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_EgitimGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow dtrow = dt.NewRow();
                        dtrow[0] = dr[0].ToString();
                        dtrow[1] = dr[1].ToString();
                        dtrow[2] = dr[2].ToString();
                        dtrow[3] = dr[3].ToString();
                        dtrow[4] = dr[4].ToString();
                        dtrow[5] = dr[5].ToString();
                        dt.Rows.Add(dtrow);
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
        public static void GetObject(DataTable dt, int BasvuruID)
        {
            dt.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_EgitimGetirByBasvuruID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = BasvuruID;
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
