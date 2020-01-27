using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IsyeriOzelKod : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private string _strOzelKod;
        private short _sintIsyeriKod;
        private short _sintAmbarKod;
        //
        //
        //
        // Constracter lar:
        //
        private IsyeriOzelKod(int pkID, string strOzelKod, short sintIsyeriKod, short sintAmbarKod)
        {
            this._pkID = pkID;
            this._strOzelKod = strOzelKod;
            this._sintIsyeriKod = sintIsyeriKod;
            this._sintAmbarKod = sintAmbarKod;
        }
        //
        //
        public IsyeriOzelKod(string strOzelKod, short sintIsyeriKod, short sintAmbarKod)
        {
            this._strOzelKod = strOzelKod;
            this._sintIsyeriKod = sintIsyeriKod;
            this._sintAmbarKod = sintAmbarKod;
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
        public short sintIsyeriKod
        {
            get
            {
                return this._sintIsyeriKod;
            }
            set
            {
                this._sintIsyeriKod = value;
            }
        }
        //
        //
        public short sintAmbarKod
        {
            get
            {
                return this._sintAmbarKod;
            }
            set
            {
                this._sintAmbarKod = value;
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
            return this._strOzelKod + " - " + this._sintIsyeriKod.ToString() + " - " + this._sintAmbarKod.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IsyeriOzelKodEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strOzelKod", SqlDbType.VarChar, 25).Value = this._strOzelKod;
                cmd.Parameters.Add("@sintIsyeriKod", SqlDbType.SmallInt).Value = this._sintIsyeriKod;
                cmd.Parameters.Add("@sintAmbarKod", SqlDbType.SmallInt).Value = this._sintAmbarKod;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IsyeriOzelKodGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@strOzelKod", SqlDbType.VarChar, 25).Value = this._strOzelKod;
                cmd.Parameters.Add("@sintIsyeriKod", SqlDbType.SmallInt).Value = this._sintIsyeriKod;
                cmd.Parameters.Add("@sintAmbarKod", SqlDbType.SmallInt).Value = this._sintAmbarKod;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IsyeriOzelKodSil", conn);
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
        public static void GetObject(IList List, string strOzelKod, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_IsyeriOzelKodGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strOzelKod", SqlDbType.VarChar, 25).Value = strOzelKod;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new IsyeriOzelKod(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt16(dr[2]), Convert.ToInt16(dr[3])));
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_IsyeriOzelKodlarGetir", conn);
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
        public static void GetObjects2Gruplar(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT intGrup FROM tblINTERNET_IsyeriOzelKod2", conn);
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
        public static void GetObjects2ByGrup(DataTable dt, int Grup)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkID,intGrup,strOzelKod,sintIsyeriKod,sintAmbarKod FROM tblINTERNET_IsyeriOzelKod2 WHERE intGrup = @intGrup", conn);
                da.SelectCommand.Parameters.Add("@intGrup", SqlDbType.Int).Value = Grup;
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
