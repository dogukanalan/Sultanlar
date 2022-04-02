using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class hatalar
    {
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
    }
}
