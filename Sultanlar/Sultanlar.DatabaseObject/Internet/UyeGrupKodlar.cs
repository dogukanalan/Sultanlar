using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class UyeGrupKodlar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private string _strGrupKod;
        //
        //
        //
        // Constracter lar:
        //
        private UyeGrupKodlar(int pkID, int intMusteriID, string strGrupKod)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._strGrupKod = strGrupKod;
        }
        //
        //
        public UyeGrupKodlar(int intMusteriID, string strGrupKod)
        {
            this._intMusteriID = intMusteriID;
            this._strGrupKod = strGrupKod;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID
        {
            get
            {
                return this._pkID;
            }
        }
        //
        //
        public int intMusteriID
        {
            get
            {
                return this._intMusteriID;
            }
            set
            {
                this._intMusteriID = value;
            }
        }
        //
        //
        public string strGrupKod
        {
            get
            {
                return this._strGrupKod;
            }
            set
            {
                this._strGrupKod = value;
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
            return GrupKodlar.GetObjectByGrupKod(this._strGrupKod);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupKodEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@strGrupKod", SqlDbType.VarChar, 25).Value = this._strGrupKod;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupKodGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@strGrupKod", SqlDbType.VarChar, 25).Value = this._strGrupKod;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupKodSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
        public static void GetObject(IList List, int intMusteriID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupKodlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = intMusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new UyeGrupKodlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString()));
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
        public static void GetObjectOnlyGrupKodlar(IList List, int intMusteriID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupKodlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = intMusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(dr[2].ToString());
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
