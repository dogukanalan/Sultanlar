using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class UyeGrubuOzelKodlar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intUyeGrupID;
        private string _strOzelKod;
        //
        //
        //
        // Constracter lar:
        //
        private UyeGrubuOzelKodlar(int pkID, int intUyeGrupID, string strOzelKod)
        {
            this._pkID = pkID;
            this._intUyeGrupID = intUyeGrupID;
            this._strOzelKod = strOzelKod;
        }
        //
        //
        public UyeGrubuOzelKodlar(int intUyeGrupID, string strOzelKod)
        {
            this._intUyeGrupID = intUyeGrupID;
            this._strOzelKod = strOzelKod;
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
        public string strOzelKod
        {
            get
            {
                return this._strOzelKod;
            }
            set
            {
                this._strOzelKod = value;
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
            return OzelKodlar.GetObjectByOzelKod(this._strOzelKod);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuOzelKodEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
                cmd.Parameters.Add("@strOzelKod", SqlDbType.VarChar, 25).Value = this._strOzelKod;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuOzelKodGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
                cmd.Parameters.Add("@strOzelKod", SqlDbType.VarChar, 25).Value = this._strOzelKod;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuOzelKodSil", conn);
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuOzelKodlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new UyeGrubuOzelKodlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString()));
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
        public static void GetObjectOnlyOzelKodlar(IList List, int intUyeGrupID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuOzelKodlarGetir", conn);
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
        //
        //
        public static UyeGrubuOzelKodlar GetObject(int intUyeGrupID, string strOzelKod)
        {
            UyeGrubuOzelKodlar ugok = new UyeGrubuOzelKodlar(0, 0, "0");

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuOzelKodGetirByUyeGrupIDandOzelKod", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
                cmd.Parameters.Add("@strOzelKod", SqlDbType.VarChar, 25).Value = strOzelKod;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        ugok = new UyeGrubuOzelKodlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString());
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

            return ugok;
        }
    }
}
