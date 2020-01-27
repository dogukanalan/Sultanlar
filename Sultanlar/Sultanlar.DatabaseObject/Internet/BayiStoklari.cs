using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class BayiStoklari
    {
        public static void DoInsert(int SMREF, int YIL, int AY, int ITEMREF, double STOK, DateTime ZAMAN)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                if (IsExist(SMREF, YIL, AY, ITEMREF))
                    DoDelete(SMREF, YIL, AY, ITEMREF);

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Bayi-Stok] ([SMREF],[YIL],[AY],[ITEMREF],[STOK],[ZAMAN]) VALUES (@SMREF,@YIL,@AY,@ITEMREF,@STOK,@ZAMAN)", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd.Parameters.Add("@STOK", SqlDbType.Float).Value = STOK;
                cmd.Parameters.Add("@ZAMAN", SqlDbType.DateTime).Value = ZAMAN;
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
        public static void DoDelete(int SMREF, int YIL, int AY)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Bayi-Stok] WHERE YIL = @YIL AND AY = @AY AND SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
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
        private static void DoDelete(int SMREF, int YIL, int AY, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Bayi-Stok] WHERE YIL = @YIL AND AY = @AY AND SMREF = @SMREF AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        private static bool IsExist(int SMREF, int YIL, int AY, int ITEMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Bayi-Stok] WHERE YIL = @YIL AND AY = @AY AND SMREF = @SMREF AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public static void GetObjects(DataTable dt, int SMREF, int YIL, int AY)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SMREF],(SELECT BAYIUNVAN FROM [Web-Musteri-TP-Bayikodlar] WHERE GMREF = [Web-Bayi-Stok].SMREF) AS BAYI,[YIL],[AY],[Web-Bayi-Stok].[ITEMREF],[MAL ACIK] AS URUN,[Web-Bayi-Stok].[STOK],[ZAMAN],(SELECT TOP 1 CONVERT(varchar(MAX),[STOK]) + ' (' + CONVERT(varchar(MAX),YIL) + '-' + CONVERT(varchar(MAX),AY) + ')' FROM [Web-Bayi-Stok] AS STOKLART WHERE SMREF = [Web-Bayi-Stok].SMREF AND ITEMREF = [Web-Bayi-Stok].ITEMREF ORDER BY YIL DESC, AY DESC) AS TOPLAMSTOK FROM [Web-Bayi-Stok] INNER JOIN [Web-Malzeme-Full] ON [Web-Bayi-Stok].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE YIL = @YIL AND AY = @AY AND SMREF = @SMREF ORDER BY URUN", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
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
