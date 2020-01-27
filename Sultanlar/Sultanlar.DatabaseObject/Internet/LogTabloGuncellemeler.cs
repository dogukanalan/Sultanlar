using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class LogTabloGuncellemeler
    {
        public static object GetObject()
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1000 pkID,dtBaslangic,dtBitis,strYer,strLog FROM tblINTERNET_LogTabloGuncellemeler ORDER BY pkID DESC", conn);
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

                return donendeger;
            }
        }
    }
}
