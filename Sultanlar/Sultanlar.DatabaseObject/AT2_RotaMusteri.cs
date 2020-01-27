using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject
{
    public class AT2_RotaMusteri
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _SMREF;
        private int _intRotaID;
        private int _intSira;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_RotaMusteri()
        {

        }
        //
        //
        private AT2_RotaMusteri(long pkID, int SMREF, int intRotaID, int intSira)
        {
            this._pkID = pkID;
            this._SMREF = SMREF;
            this._intRotaID = intRotaID;
            this._intSira = intSira;
        }
        //
        //
        public AT2_RotaMusteri(int SMREF, int intRotaID, int intSira)
        {
            this._SMREF = SMREF;
            this._intRotaID = intRotaID;
            this._intSira = intSira;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int intRotaID { get { return this._intRotaID; } set { this._intRotaID = value; } }
        public int intSira { get { return this._intSira; } set { this._intSira = value; } }
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
            return AT2_Rotalar.GetObject(this._intRotaID).strRota + "-" + this._intSira.ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_RotaMusteri] ([SMREF],[intRotaID],[intSira]) VALUES (@SMREF,@intRotaID,@intSira) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intRotaID", SqlDbType.Int).Value = this._intRotaID;
                cmd.Parameters.Add("@intSira", SqlDbType.Int).Value = this._intSira;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt64(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_RotaMusteri] SET [SMREF] = @SMREF,[intRotaID] = @intRotaID,[intSira] = @intSira WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intRotaID", SqlDbType.Int).Value = this._intRotaID;
                cmd.Parameters.Add("@intSira", SqlDbType.Int).Value = this._intSira;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_RotaMusteri] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
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
        public static void GetObjects(DataTable dt, int RotaID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[SMREF],(SELECT TOP 1 SUBE FROM [Web-Musteri] WHERE SMREF = [tblAT2_RotaMusteri].SMREF) AS SUBE,[intRotaID],[intSira] FROM [tblAT2_RotaMusteri] WHERE intRotaID = @intRotaID ORDER BY intSira", conn);
                da.SelectCommand.Parameters.Add("@intRotaID", SqlDbType.Int).Value = RotaID;
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
        public static AT2_RotaMusteri GetObject(long ID)
        {
            AT2_RotaMusteri donendeger = new AT2_RotaMusteri();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[SMREF],[intRotaID],[intSira] FROM [tblAT2_RotaMusteri] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AT2_RotaMusteri(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            Convert.ToInt32(dr[3]));
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
        //
        //
        public static AT2_RotaMusteri GetObject(int RotaID, int Sira)
        {
            AT2_RotaMusteri donendeger = new AT2_RotaMusteri();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[SMREF],[intRotaID],[intSira] FROM [tblAT2_RotaMusteri] WHERE intRotaID = @intRotaID AND intSira = @intSira", conn);
                cmd.Parameters.Add("@intRotaID", SqlDbType.Int).Value = RotaID;
                cmd.Parameters.Add("@intSira", SqlDbType.Int).Value = Sira;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AT2_RotaMusteri(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[3]));
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
        //
        //
        public static bool IsExist(/*int RotaID, */int SMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblAT2_RotaMusteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                //cmd.Parameters.Add("@intRotaID", SqlDbType.Int).Value = RotaID;
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
        //
        //
        public static bool IsExistSira(long ID, int Sira)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblAT2_RotaMusteri] WHERE pkID = @pkID AND intSira = @intSira", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = ID;
                cmd.Parameters.Add("@intSira", SqlDbType.Int).Value = Sira;
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
        //
        //
        public static int MaxSira(int RotaID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(intSira) FROM [tblAT2_RotaMusteri] WHERE intRotaID = @intRotaID", conn);
                cmd.Parameters.Add("@intRotaID", SqlDbType.Int).Value = RotaID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt32(obj);
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetObjectsWithCustomers(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT CONVERT(bit,'False') AS SECIM,CASE WHEN count(DISTINCT tblAT2_Rotalar.pkID) > 0 THEN CONVERT(bit,'True') ELSE CONVERT(bit,'False') END AS RotaSayisi,CASE WHEN [Web-Musteri].ACTIVE = 1 THEN CONVERT(bit,'True') ELSE CONVERT(bit,'False') END AS ACTIVE,[Web-Musteri].MUSTERI,[Web-Musteri].[SMREF],[Web-Musteri].SUBE,UPPER([Web-Musteri].IL) AS IL,[Web-Musteri].ILCE,[Web-Musteri].ADRES,[tblAT2_RotaMusteri].[intRotaID],tblAT2_Rotalar.strRota FROM [Web-Musteri] LEFT OUTER JOIN [tblAT2_RotaMusteri] ON [Web-Musteri].SMREF = [tblAT2_RotaMusteri].SMREF LEFT OUTER JOIN tblAT2_Rotalar ON [tblAT2_RotaMusteri].[intRotaID] = tblAT2_Rotalar.pkID GROUP BY [Web-Musteri].ACTIVE,[Web-Musteri].MUSTERI,[Web-Musteri].[SMREF],[Web-Musteri].SUBE,[Web-Musteri].IL,[Web-Musteri].ILCE,[Web-Musteri].ADRES,[tblAT2_RotaMusteri].[intRotaID],tblAT2_Rotalar.strRota ORDER BY MUSTERI,SUBE", conn);
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
