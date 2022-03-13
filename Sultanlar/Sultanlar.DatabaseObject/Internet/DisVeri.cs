using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Internet
{
    public class DisVeri
    {
        public int pkID { get; set; }
        public int SMREF { get; set; }
        public string SUNUCU { get; set; }
        public string VERITABANI { get; set; }
        public string KULLANICI { get; set; }
        public string SIFRE { get; set; }
        public string VERISORGU { get; set; }
        public string STOKSORGU { get; set; }
        public string YILKOLON { get; set; }
        public string AYKOLON { get; set; }
        public string YILKOLON1 { get; set; }
        public string AYKOLON1 { get; set; }
        public string VERIXML { get; set; }
        public string STOKXML { get; set; }

        private static bool IsExist(int SMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Dis-VeriCekme] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

        private static void DoDelete(int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Dis-VeriCekme] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

        public static int DoInsert(int SMREF, string SUNUCU, string VERITABANI, string KULLANICI, string SIFRE, string VERISORGU, string STOKSORGU, string YILKOLON, string AYKOLON, string YILKOLON1, string AYKOLON1, string VERIXML, string STOKXML)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                if (IsExist(SMREF))
                    DoDelete(SMREF);

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Dis-VeriCekme] ([SMREF],[SUNUCU],[VERITABANI],[KULLANICI],[SIFRE],[VERISORGU],[STOKSORGU],YILKOLON,AYKOLON,YILKOLON1,AYKOLON1,VERIXML,STOKXML) VALUES (@SMREF,@SUNUCU,@VERITABANI,@KULLANICI,@SIFRE,@VERISORGU,@STOKSORGU,@YILKOLON,@AYKOLON,@YILKOLON1,@AYKOLON1,@VERIXML,@STOKXML)", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SUNUCU", SqlDbType.NVarChar).Value = SUNUCU;
                cmd.Parameters.Add("@VERITABANI", SqlDbType.NVarChar).Value = VERITABANI;
                cmd.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;
                cmd.Parameters.Add("@SIFRE", SqlDbType.NVarChar).Value = SIFRE;
                cmd.Parameters.Add("@VERISORGU", SqlDbType.NVarChar).Value = VERISORGU;
                cmd.Parameters.Add("@STOKSORGU", SqlDbType.NVarChar).Value = STOKSORGU;
                cmd.Parameters.Add("@YILKOLON", SqlDbType.NVarChar).Value = YILKOLON;
                cmd.Parameters.Add("@AYKOLON", SqlDbType.NVarChar).Value = AYKOLON;
                cmd.Parameters.Add("@YILKOLON1", SqlDbType.NVarChar).Value = YILKOLON1;
                cmd.Parameters.Add("@AYKOLON1", SqlDbType.NVarChar).Value = AYKOLON1;
                cmd.Parameters.Add("@VERIXML", SqlDbType.NVarChar).Value = VERIXML;
                cmd.Parameters.Add("@STOKXML", SqlDbType.NVarChar).Value = STOKXML;
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

        public static DisVeri GetObject(int SMREF)
        {
            DisVeri donendeger = new DisVeri();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[SMREF],[SUNUCU],[VERITABANI],[KULLANICI],[SIFRE],[VERISORGU],[STOKSORGU],YILKOLON,AYKOLON,YILKOLON1,AYKOLON1,VERIXML,STOKXML FROM [Web-Dis-VeriCekme] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = Convert.ToInt32(dr[0]);
                        donendeger.SMREF = Convert.ToInt32(dr[1]);
                        donendeger.SUNUCU = dr[2].ToString();
                        donendeger.VERITABANI = dr[3].ToString();
                        donendeger.KULLANICI = dr[4].ToString();
                        donendeger.SIFRE = dr[5].ToString();
                        donendeger.VERISORGU = dr[6].ToString();
                        donendeger.STOKSORGU = dr[7].ToString();
                        donendeger.YILKOLON = dr[8].ToString();
                        donendeger.AYKOLON = dr[9].ToString();
                        donendeger.YILKOLON1 = dr[10].ToString();
                        donendeger.AYKOLON1 = dr[11].ToString();
                        donendeger.VERIXML = dr[12].ToString();
                        donendeger.STOKXML = dr[13].ToString();
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

        public static void ExecNQ(string sorgu)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
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

        public static object ExecSc(string sorgu)
        {
            object donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar();
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

        public static void ExecNQwp(string CommandText, ArrayList ParameterNames, object[] Parameters)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlCommand cmd = new SqlCommand(CommandText, conn);
                for (int i = 0; i < ParameterNames.Count; i++)
                    cmd.Parameters.AddWithValue(ParameterNames[i].ToString(), Parameters[i]);
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

        public static DataTable ExecDaRe(string sorgu)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
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
    }
}
