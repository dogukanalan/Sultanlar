using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadeHizmetTutar
    {
        private string _STRREF; private decimal _TUTTOP; private long _bintIadeDetayID; private int _GMREF; private string _OZELKOD;
        private IadeHizmetTutar(string STRREF, decimal TUTTOP, long bintIadeDetayID, int GMREF, string OZELKOD) { this._STRREF = STRREF; this._TUTTOP = TUTTOP; this._bintIadeDetayID = bintIadeDetayID; this._GMREF = GMREF; this._OZELKOD = OZELKOD; }
        public IadeHizmetTutar() { }
        public string STRREF { get { return this._STRREF; } set { this._STRREF = value; } }
        public decimal TUTTOP { get { return this._TUTTOP; } set { this._TUTTOP = value; } }
        public long bintIadeDetayID { get { return this._bintIadeDetayID; } set { this._bintIadeDetayID = value; } }
        public int GMREF { get { return this._GMREF; } set { this._GMREF = value; } }
        public string OZELKOD { get { return this._OZELKOD; } set { this._OZELKOD = value; } }
        public static IadeHizmetTutar GetObject(long IadeDetayID)
        {
            IadeHizmetTutar donendeger = new IadeHizmetTutar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT STRREF,[TUT TOP],bintIadeDetayID,GMREF,[OZEL KOD] FROM [Web-IadeHizmet-Tutar] WHERE bintIadeDetayID = @IadeDetayID", conn);
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadeHizmetTutar(dr[0].ToString(), Convert.ToDecimal(dr[1]), Convert.ToInt64(dr[2]), Convert.ToInt32(dr[3]), dr[4].ToString());
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
        public static IadeHizmetTutar GetObject(string STRREF)
        {
            IadeHizmetTutar donendeger = new IadeHizmetTutar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT STRREF,[TUT TOP],bintIadeDetayID,GMREF,[OZEL KOD] FROM [Web-IadeHizmet-Tutar] WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadeHizmetTutar(dr[0].ToString(), Convert.ToDecimal(dr[1]), Convert.ToInt64(dr[2]), Convert.ToInt32(dr[3]), dr[4].ToString());
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
        public static IadeHizmetTutar GetObject(int GMREF, string OZELKOD)
        {
            IadeHizmetTutar donendeger = new IadeHizmetTutar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT STRREF,[TUT TOP],bintIadeDetayID,GMREF,[OZEL KOD] FROM [Web-IadeHizmet-Tutar] WHERE GMREF = @GMREF AND [OZEL KOD] = @OZELKOD", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.VarChar).Value = OZELKOD;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadeHizmetTutar(dr[0].ToString(), Convert.ToDecimal(dr[1]), Convert.ToInt64(dr[2]), Convert.ToInt32(dr[3]), dr[4].ToString());
                    }
                    else
                    {
                        donendeger = new IadeHizmetTutar(string.Empty, 0, 0, 0, string.Empty);
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT STRREF,[TUT TOP],bintIadeDetayID,GMREF,[OZEL KOD] FROM [Web-IadeHizmet-Tutar]", conn);
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
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-IadeHizmet-Tutar] SET [TUT TOP] = @TUTTOP WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = this._STRREF;
                cmd.Parameters.Add("@TUTTOP", SqlDbType.Money).Value = this._TUTTOP;
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
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-IadeHizmet-Tutar] WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = this._STRREF;
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



        public static void DoInsert(string STRREF, decimal TUTTOP, long IadeDetayID, int GMREF, string OZELKOD)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-IadeHizmet-Tutar] (STRREF,[TUT TOP],bintIadeDetayID,GMREF,[OZEL KOD]) VALUES (@STRREF,@TUTTOP,@IadeDetayID,@GMREF,@OZELKOD)", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                cmd.Parameters.Add("@TUTTOP", SqlDbType.Money).Value = TUTTOP;
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.VarChar).Value = OZELKOD;
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
        public static void DoUpdate(string STRREF, decimal TUTTOP, long IadeDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-IadeHizmet-Tutar] SET [TUT TOP] = @TUTTOP, bintIadeDetayID = @IadeDetayID WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                cmd.Parameters.Add("@TUTTOP", SqlDbType.Money).Value = TUTTOP;
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
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
        public static void DoDelete(string STRREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-IadeHizmet-Tutar] WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
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
        //public static void DoDelete(long IadeDetayID)
        //{
        //    using (SqlConnection conn = new SqlConnection(General.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("DELETE FROM [Web-IadeHizmet-Tutar] WHERE bintIadeDetayID = @IadeDetayID", conn);
        //        cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        public static double GetTUTTOPByGMREFOZELKOD(int GMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeHizmet-Tutar].[TUT TOP]) FROM [Web-IadeHizmet-Tutar] RIGHT OUTER JOIN [Web-IadeHizmet] ON [Web-IadeHizmet-Tutar].STRREF = [Web-IadeHizmet].STRREF WHERE [Web-IadeHizmet].[GMREF] = @GMREF AND [Web-IadeHizmet].[OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
                cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                cmd.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToDouble(obj);
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
        public static double GetTUTTOPBySMREFOZELKOD(int SMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeHizmet-Tutar].[TUT TOP]) FROM [Web-IadeHizmet-Tutar] RIGHT OUTER JOIN [Web-IadeHizmet] ON [Web-IadeHizmet-Tutar].STRREF = [Web-IadeHizmet].STRREF WHERE [Web-IadeHizmet].[SMREF] = @SMREF AND [Web-IadeHizmet].[OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
                cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                cmd.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToDouble(obj);
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
