using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class UyeGruplari : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkUyeGrupID;
        private string _strUyeGrup;
        private bool _blTaksitPlani;
        //
        //
        //
        // Constracter lar:
        //
        private UyeGruplari(int pkUyeGrupID, string strUyeGrup, bool blTaksitPlani)
        {
            this._pkUyeGrupID = pkUyeGrupID;
            this._strUyeGrup = strUyeGrup;
            this._blTaksitPlani = blTaksitPlani;
        }
        //
        //
        public UyeGruplari(string strUyeGrup, bool blTaksitPlani)
        {
            this._strUyeGrup = strUyeGrup;
            this._blTaksitPlani = blTaksitPlani;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkUyeGrupID
        {
            get
            {
                return this._pkUyeGrupID;
            }
        }
        //
        //
        public string strUyeGrup
        {
            get
            {
                return this._strUyeGrup;
            }
            set
            {
                this._strUyeGrup = value;
            }
        }
        //
        //
        public bool blTaksitPlani
        {
            get
            {
                return this._blTaksitPlani;
            }
            set
            {
                this._blTaksitPlani = value;
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
            return this._strUyeGrup;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strUyeGrup", SqlDbType.NVarChar).Value = this._strUyeGrup;
                cmd.Parameters.Add("@blTaksitPlani", SqlDbType.Bit).Value = this._blTaksitPlani;
                cmd.Parameters.Add("@pkUyeGrupID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkUyeGrupID = Convert.ToInt32(cmd.Parameters["@pkUyeGrupID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkUyeGrupID", SqlDbType.Int).Value = this._pkUyeGrupID;
                cmd.Parameters.Add("@strUyeGrup", SqlDbType.NVarChar).Value = this._strUyeGrup;
                cmd.Parameters.Add("@blTaksitPlani", SqlDbType.Bit).Value = this._blTaksitPlani;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrupSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkUyeGrupID", SqlDbType.Int).Value = this._pkUyeGrupID;
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGruplariGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new UyeGruplari(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToBoolean(dr[2])));
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
