using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SAPs
    {
        public static void GetDurum(DataTable dt, int SiparisID, int SapSipID)
        {
            string where = " WHERE";

            if (SiparisID != 0)
                where += " (WEB_NO = " + SiparisID.ToString() + ") AND";
            if (SapSipID != 0)
                where += " (SIP_NO = " + SiparisID.ToString() + ") AND";

            if (where == " WHERE") where = string.Empty; else where = where.Substring(0, where.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SNR],[YIL],[AY],[MUST_KOD],[SIP_TAR],[SIP_NO],[SIP_STR],[WEB_NO],[MALZ_KOD],[RED_KOD],[RED_NEDENI],[SIP_AD],[TSL_AD],[IRS_AD],[BKY_AD] FROM [SAP_SIPARIS_STR_DRM] " + where, conn);
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

        public static void LogYaz(string servis, bool basarili, string log, DateTime baslangic, DateTime bitis)
        {
            using(SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmdLog = new SqlCommand("INSERT INTO [SAP_SERVIS_LOG] ([dtZaman],[strServis],blBasarili,[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strServis,@blBasarili,@strLog,@dtBaslangic,@dtBitis)", conn);
                cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
                cmdLog.Parameters.AddWithValue("@strServis", servis);
                cmdLog.Parameters.AddWithValue("@blBasarili", basarili);
                cmdLog.Parameters.AddWithValue("@strLog", log);
                cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
                cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
                conn.Open();
                cmdLog.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void BayiLogYaz(string servis, bool basarili, string log, DateTime baslangic, DateTime bitis)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmdLog = new SqlCommand("INSERT INTO [BAYI_SERVIS_LOG] ([dtZaman],[strServis],blBasarili,[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strServis,@blBasarili,@strLog,@dtBaslangic,@dtBitis)", conn);
                cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
                cmdLog.Parameters.AddWithValue("@strServis", servis);
                cmdLog.Parameters.AddWithValue("@blBasarili", basarili);
                cmdLog.Parameters.AddWithValue("@strLog", log);
                cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
                cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
                conn.Open();
                cmdLog.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void HataYaz(string tablo, string key1, string key2, string key3, string key4, string key5, string log, DateTime baslangic, DateTime bitis)
        {
            using(SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmdLog = new SqlCommand("INSERT INTO [SAP_HATA_LOG] ([dtZaman],[strTablo],[strKey1],[strKey2],[strKey3],[strKey4],[strKey5],[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strTablo,@strKey1,@strKey2,@strKey3,@strKey4,@strKey5,@strLog,@dtBaslangic,@dtBitis)", conn);
                cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
                cmdLog.Parameters.AddWithValue("@strTablo", tablo);
                cmdLog.Parameters.AddWithValue("@strKey1", key1);
                cmdLog.Parameters.AddWithValue("@strKey2", key2);
                cmdLog.Parameters.AddWithValue("@strKey3", key3);
                cmdLog.Parameters.AddWithValue("@strKey4", key4);
                cmdLog.Parameters.AddWithValue("@strKey5", key5);
                cmdLog.Parameters.AddWithValue("@strLog", log);
                cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
                cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
                cmdLog.ExecuteNonQuery();
            }
        }
    }
}
