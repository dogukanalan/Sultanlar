using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class WebGenel
    {
        public static void DoUpdateHavaDurumu(string HavaDurumu)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HavaDurumuGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strHavaDurumu", SqlDbType.NVarChar, 300).Value = HavaDurumu;
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
        public static void DoUpdateDoviz(string Doviz)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DovizGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strDoviz", SqlDbType.NVarChar, 300).Value = Doviz;
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
        public static string GetObjectHavaDurumu()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HavaDurumuGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static string GetObjectDoviz()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DovizGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static bool Validate(string KAdi, string Sifre)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblWebGenel WHERE bKAdi = @bKAdi AND bSifre = @bSifre", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@bKAdi", SqlDbType.VarBinary, 16).Value = UTF8Encoding.GetEncoding(1254).GetBytes(KAdi);
                cmd.Parameters.Add("@bSifre", SqlDbType.VarBinary, 16).Value = UTF8Encoding.GetEncoding(1254).GetBytes(Sifre);

                try
                {
                    conn.Open();
                    result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;
        }
        public static int DoUpdateSayac()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblWebGenel SET intSiparisSayac = intSiparisSayac + 1 SELECT intSiparisSayac FROM tblWebGenel", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
        public static void DoUpdateDENEME(string Kolon)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblWebGenel SET " + Kolon + " = @dtDENEME", conn);
                cmd.Parameters.Add("@dtDENEME", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.CommandType = CommandType.Text;
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
        public static void DoUpdateStrDENEME(string Deger)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblWebGenel SET strDENEME = strDENEME + ' --- ' + @DENEME", conn);
                cmd.Parameters.Add("@DENEME", SqlDbType.NVarChar).Value = Deger;
                cmd.CommandType = CommandType.Text;
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
        public static string GetHBsifre()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strHBsifre FROM tblWebGenel", conn);
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static string GetN11sifre()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strN11sifre FROM tblWebGenel", conn);
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static string GetGGsifre()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strGGsifre FROM tblWebGenel", conn);
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static string GetSPsifre()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strSPsifre FROM tblWebGenel", conn);
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static void QUANTUMAYAZILMAYANIARTTIR()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblWebGenel SET QUANTUMAYAZILAMAYAN20130525DEN = QUANTUMAYAZILAMAYAN20130525DEN + 1", conn);
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
        public static void Sorgu(DataTable dt, string sorgu)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                if (sorgu.StartsWith("sp_") || sorgu.StartsWith("db_"))
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
        }
        public static void Sorgu(string sorgu)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "webgenel sorgu: " + sorgu);
                }
            }
        }
        public static string SorguSkalar(string sorgu)
        {
            string donendeger = string.Empty;
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "webgenel sorgu: " + sorgu);
                }
            }
            return donendeger;
        }






        public static string WebRisk()
        {
            string donendeger = "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd1 = new SqlCommand("EXEC master.dbo.xp_sqlagent_enum_jobs 1, sa, 0x29CA2518766B574182F2409694F3D06C", conn);
                SqlDataReader dr;

                SqlCommand cmd = new SqlCommand("EXEC msdb.dbo.sp_start_job N'Web-Risk'", conn);
                try
                {
                    bool zatencalisiyor = false;
                    conn.Open();
                    dr = cmd1.ExecuteReader();
                    if (dr.Read()) zatencalisiyor = Convert.ToBoolean(dr[9]);
                    dr.Close();

                    if (!zatencalisiyor)
                    {
                        cmd.ExecuteNonQuery();
                        donendeger = "İşlem başarıyla başlatıldı.\r\n\r\nTahmini tamamlanma süresi: 15 saniye";
                    }
                    else
                    {
                        donendeger = "İşlem şu anda zaten başlatılmış durumda. Tamamlanmadan ikinci kez başlatılamaz.";
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

            return donendeger;
        }
        public static void WebEkstre()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("EXEC msdb.dbo.sp_start_job N'Web-Ekstre'", conn);
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
        public static void WebSatisRapor()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("EXEC msdb.dbo.sp_start_job N'Web-Satis-Rapor'", conn);
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
        public static bool WebSatisRaporCalisiyorMu()
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlDataAdapter da = new SqlDataAdapter("EXEC master.dbo.xp_sqlagent_enum_jobs 1,''", conn);
                DataTable dt = new DataTable();
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

                byte[] data = { 201,79,5,41,152,194,142,72,147,87,97,103,13,93,198,106 }; // web-satis-rapor job id

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (((byte[])dt.Rows[i]["Job ID"])[0] == data[0] && ((byte[])dt.Rows[i]["Job ID"])[1] == data[1] &&
                        ((byte[])dt.Rows[i]["Job ID"])[2] == data[2] && ((byte[])dt.Rows[i]["Job ID"])[3] == data[3] &&
                        ((byte[])dt.Rows[i]["Job ID"])[4] == data[4] && ((byte[])dt.Rows[i]["Job ID"])[5] == data[5])
                    {
                        donendeger = dt.Rows[i]["Running"].ToString() == "1";
                    }
                }
            }

            return donendeger;
        }
        public static DataTable WCFdata(string CommandText, ArrayList ParameterNames, SqlDbType[] Types, ArrayList Parameters, string TableName)
        {
            DataTable dt = new DataTable(TableName);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(CommandText, conn);
                da.SelectCommand.CommandTimeout = 1000;

                if (CommandText.StartsWith("sp_") || CommandText.StartsWith("db_"))
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < Parameters.Count; i++)
                    da.SelectCommand.Parameters.Add(ParameterNames[i].ToString(), (SqlDbType)Types[i]).Value = Parameters[i].ToString();
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

            return dt;
        }
        public static DataTable WCFdata(string CommandText, ArrayList ParameterNames, ArrayList Parameters, string TableName)
        {
            DataTable dt = new DataTable(TableName);

            string where = string.Empty;
            if (!CommandText.StartsWith("sp_") && !CommandText.StartsWith("db_"))
            {
                bool var = false;
                for (int i = 0; i < ParameterNames.Count; i++)
                {
                    if (ParameterNames[i].ToString().Length > 0)
                    {
                        var = true;
                        if (i == 0)
                            where = " WHERE ";
                        where += "[" + ParameterNames[i] + "] = @" + ParameterNames[i] + " AND ";
                    }
                }
                where = var ? where.Substring(0, where.Length - 5) : where;
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(CommandText + where, conn);
                da.SelectCommand.CommandTimeout = 1000;

                if (CommandText.StartsWith("sp_") || CommandText.StartsWith("db_"))
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < Parameters.Count; i++)
                    da.SelectCommand.Parameters.AddWithValue(ParameterNames[i].ToString(), Parameters[i].ToString());
                try
                {
                    conn.Open();
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex, " " + da.SelectCommand.CommandText);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dt;
        }
        public static void ExecNQ(string command)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex, " " + cmd.CommandText);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
