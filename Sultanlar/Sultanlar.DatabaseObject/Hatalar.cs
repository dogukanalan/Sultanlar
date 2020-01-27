using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Sultanlar.DatabaseObject
{
    public class Hatalar : IDisposable
    {
        //
        //
        //
        // Metodlar:
        //
        public static void DoInsert(Exception ex, string yer)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand hatacmd = new SqlCommand("sp_HataEkle", conn);
                hatacmd.CommandType = CommandType.StoredProcedure;
                hatacmd.Parameters.Add("@strHataKodu", SqlDbType.NVarChar).Value = ex.StackTrace != null ? ex.StackTrace : "";
                hatacmd.Parameters.Add("@strHataKaynak", SqlDbType.NVarChar).Value = ex.Source;
                hatacmd.Parameters.Add("@strHataYeri", SqlDbType.NVarChar).Value = yer;
                hatacmd.Parameters.Add("@strHataAciklama", SqlDbType.NVarChar).Value = ex.Message;
                hatacmd.Parameters.Add("@dtHataZamani", SqlDbType.SmallDateTime).Value = DateTime.Now;
                hatacmd.Parameters.Add("@pkHataID", SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                hatacmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void DoInsert(SqlException ex)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand hatacmd = new SqlCommand("sp_HataEkle", conn);
                hatacmd.CommandType = CommandType.StoredProcedure;
                hatacmd.Parameters.Add("@strHataKodu", SqlDbType.NVarChar).Value = ex.ErrorCode.ToString();
                hatacmd.Parameters.Add("@strHataKaynak", SqlDbType.NVarChar).Value = ex.Source;
                hatacmd.Parameters.Add("@strHataYeri", SqlDbType.NVarChar).Value = ex.Procedure;
                hatacmd.Parameters.Add("@strHataAciklama", SqlDbType.NVarChar).Value = ex.Message;
                hatacmd.Parameters.Add("@dtHataZamani", SqlDbType.SmallDateTime).Value = DateTime.Now;
                hatacmd.Parameters.Add("@pkHataID", SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                hatacmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void DoInsert(SmtpException ex, string yer)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand hatacmd = new SqlCommand("sp_HataEkle", conn);
                hatacmd.CommandType = CommandType.StoredProcedure;
                hatacmd.Parameters.Add("@strHataKodu", SqlDbType.NVarChar).Value = ex.StackTrace != null ? ex.StackTrace : "";
                hatacmd.Parameters.Add("@strHataKaynak", SqlDbType.NVarChar).Value = ex.Source;
                hatacmd.Parameters.Add("@strHataYeri", SqlDbType.NVarChar).Value = yer;
                hatacmd.Parameters.Add("@strHataAciklama", SqlDbType.NVarChar).Value = ex.Message;
                hatacmd.Parameters.Add("@dtHataZamani", SqlDbType.SmallDateTime).Value = DateTime.Now;
                hatacmd.Parameters.Add("@pkHataID", SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                hatacmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        //
        // Metodlar:
        //
        public static void DoInsert(string hata, string yer)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand hatacmd = new SqlCommand("sp_HataEkle", conn);
                hatacmd.CommandType = CommandType.StoredProcedure;
                hatacmd.Parameters.Add("@strHataKodu", SqlDbType.NVarChar).Value = "";
                hatacmd.Parameters.Add("@strHataKaynak", SqlDbType.NVarChar).Value = "";
                hatacmd.Parameters.Add("@strHataYeri", SqlDbType.NVarChar).Value = yer;
                hatacmd.Parameters.Add("@strHataAciklama", SqlDbType.NVarChar).Value = hata;
                hatacmd.Parameters.Add("@dtHataZamani", SqlDbType.SmallDateTime).Value = DateTime.Now;
                hatacmd.Parameters.Add("@pkHataID", SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                hatacmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void DoDelete(string HataID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HataSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkHataID", SqlDbType.Int).Value = Convert.ToInt32(HataID);
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
        public static object GetObject()
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_HataGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(donendeger);
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
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
