using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class UyeGrubuGrupKodlar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intUyeGrupID;
        private string _strGrupKod;
        //
        //
        //
        // Constracter lar:
        //
        private UyeGrubuGrupKodlar(int pkID, int intUyeGrupID, string strGrupKod)
        {
            this._pkID = pkID;
            this._intUyeGrupID = intUyeGrupID;
            this._strGrupKod = strGrupKod;
        }
        //
        //
        public UyeGrubuGrupKodlar(int intUyeGrupID, string strGrupKod)
        {
            this._intUyeGrupID = intUyeGrupID;
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
        public int intUyeGrupID
        {
            get
            {
                return this._intUyeGrupID;
            }
            set
            {
                this._intUyeGrupID = value;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuGrupKodEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuGrupKodGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuGrupKodSil", conn);
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
        public static void GetObject(IList List, int intUyeGrupID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuGrupKodlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new UyeGrubuGrupKodlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString()));
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
        public static void GetObjectOnlyGrupKodlar(IList List, int intUyeGrupID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuGrupKodlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
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
