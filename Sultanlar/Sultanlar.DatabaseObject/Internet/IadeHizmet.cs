using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadeHizmet
    {
        /// <summary>
        /// [IadeHizmet]
        /// </summary>
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            ArrayList ozelkodlar = OzelKodlar.GetObjectsByGrupKod("STG");
            for (int i = 0; i < ozelkodlar.Count; i++)
            {
                if (OZELKOD == ozelkodlar[i].ToString())
                {
                    OZELKOD = "STG";
                    break;
                }
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-IadeHizmet].[STRREF],[Web-IadeHizmet].[GMREF],[Web-IadeHizmet].[SMREF],[Web-IadeHizmet].[FAT TAR],[Web-IadeHizmet].[FAT NO],[Web-IadeHizmet].[HIZ],[Web-IadeHizmet].[TIG ACIK],[Web-IadeHizmet].[TEXT-1],[Web-IadeHizmet].[NET+KDV],IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0) AS TUTIADE,([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) AS TUTFARK FROM [Web-IadeHizmet] LEFT OUTER JOIN [Web-IadeHizmet-Tutar] ON [Web-IadeHizmet].STRREF = [Web-IadeHizmet-Tutar].STRREF WHERE ([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) > 0 AND [Web-IadeHizmet].SMREF = @SMREF AND [Web-IadeHizmet].[OZEL KOD] = @OZELKOD AND [Web-IadeHizmet].[FAT TAR] >= @Date1 AND [Web-IadeHizmet].[FAT TAR] <= @Date2 ORDER BY [Web-IadeHizmet].[FAT TAR] DESC", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
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
        /// <summary>
        /// [IadeHizmet]
        /// </summary>
        public static void GetObjectsByGMREF(DataTable dt, int GMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            ArrayList ozelkodlar = OzelKodlar.GetObjectsByGrupKod("STG");
            for (int i = 0; i < ozelkodlar.Count; i++)
            {
                if (OZELKOD == ozelkodlar[i].ToString())
                {
                    OZELKOD = "STG";
                    break;
                }
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-IadeHizmet].[STRREF],[Web-IadeHizmet].[GMREF],[Web-IadeHizmet].[SMREF],[Web-IadeHizmet].[FAT TAR],[Web-IadeHizmet].[FAT NO],[Web-IadeHizmet].[HIZ],[Web-IadeHizmet].[TIG ACIK],[Web-IadeHizmet].[TEXT-1],[Web-IadeHizmet].[NET+KDV],IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0) AS TUTIADE,([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) AS TUTFARK FROM [Web-IadeHizmet] LEFT OUTER JOIN [Web-IadeHizmet-Tutar] ON [Web-IadeHizmet].STRREF = [Web-IadeHizmet-Tutar].STRREF WHERE ([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) > 0 AND [Web-IadeHizmet].GMREF = @GMREF AND [Web-IadeHizmet].[OZEL KOD] = @OZELKOD AND [Web-IadeHizmet].[FAT TAR] >= @Date1 AND [Web-IadeHizmet].[FAT TAR] <= @Date2 ORDER BY [Web-IadeHizmet].[FAT TAR] DESC", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
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
        /// <summary>
        /// 
        /// </summary>
        public static double GetNETTOPBySMREFOZELKOD(int SMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeHizmet].[NET+KDV]) FROM [Web-IadeHizmet] LEFT OUTER JOIN [Web-IadeHizmet-Tutar] ON [Web-IadeHizmet].STRREF = [Web-IadeHizmet-Tutar].STRREF WHERE ([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) > 0 AND SMREF = @SMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
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
        /// <summary>
        /// 
        /// </summary>
        public static double GetNETTOPByGMREFOZELKOD(int GMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeHizmet].[NET+KDV]) FROM [Web-IadeHizmet] LEFT OUTER JOIN [Web-IadeHizmet-Tutar] ON [Web-IadeHizmet].STRREF = [Web-IadeHizmet-Tutar].STRREF WHERE ([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) > 0 AND GMREF = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
                SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeHizmet].[NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
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
        public static void GetObjectsByGMREFITEMREFforSonradanHizmet(DataTable dt, int GMREF, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-IadeHizmet-Tutar].[STRREF],[Web-IadeHizmet-Tutar].[TUT TOP],[Web-IadeHizmet-Tutar].[bintIadeDetayID] FROM [Web-IadeHizmet-Tutar] INNER JOIN [Web-IadeHizmet] ON [Web-IadeHizmet-Tutar].[STRREF] = [Web-IadeHizmet].[STRREF] WHERE [Web-IadeHizmet].[GMREF] = @GMREF AND [Web-IadeHizmet].[OZEL KOD] = (SELECT DISTINCT [OZEL KOD] FROM [Web-Malzeme] WHERE ITEMREF = @ITEMREF)", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetObjectsByGMREFOZELKODforSonradanHizmet(DataTable dt, int GMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-IadeHizmet].[STRREF],[Web-IadeHizmet].[GMREF],[Web-IadeHizmet].[SMREF],[Web-IadeHizmet].[FAT TAR],[Web-IadeHizmet].[FAT NO],[Web-IadeHizmet].[HIZ],[Web-IadeHizmet].[TIG ACIK],[Web-IadeHizmet].[TEXT-1],[Web-IadeHizmet].[OZEL KOD],[Web-IadeHizmet].[NET+KDV] AS [NET+KDV],IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0) AS [TUTIADE],([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) AS [TUTFARK] FROM [Web-IadeHizmet-Tutar] RIGHT OUTER JOIN [Web-IadeHizmet] ON [Web-IadeHizmet-Tutar].[STRREF] = [Web-IadeHizmet].[STRREF] WHERE [Web-IadeHizmet].[GMREF] = @GMREF AND [Web-IadeHizmet].[OZEL KOD] = @OZELKOD AND [Web-IadeHizmet].[FAT TAR] >= @Date1 AND [Web-IadeHizmet].[FAT TAR] <= @Date2 ORDER BY [Web-IadeHizmet].[FAT TAR] DESC", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetObjectsBySMREFOZELKODforSonradanHizmet(DataTable dt, int SMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-IadeHizmet].[STRREF],[Web-IadeHizmet].[GMREF],[Web-IadeHizmet].[SMREF],[Web-IadeHizmet].[FAT TAR],[Web-IadeHizmet].[FAT NO],[Web-IadeHizmet].[HIZ],[Web-IadeHizmet].[TIG ACIK],[Web-IadeHizmet].[TEXT-1],[Web-IadeHizmet].[OZEL KOD],[Web-IadeHizmet].[NET+KDV] AS [NET+KDV],IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0) AS [TUTIADE],([Web-IadeHizmet].[NET+KDV] - IsNull([Web-IadeHizmet-Tutar].[TUT TOP], 0)) AS [TUTFARK] FROM [Web-IadeHizmet-Tutar] RIGHT OUTER JOIN [Web-IadeHizmet] ON [Web-IadeHizmet-Tutar].[STRREF] = [Web-IadeHizmet].[STRREF] WHERE [Web-IadeHizmet].[SMREF] = @SMREF AND [Web-IadeHizmet].[OZEL KOD] = @OZELKOD AND [Web-IadeHizmet].[FAT TAR] >= @Date1 AND [Web-IadeHizmet].[FAT TAR] <= @Date2 ORDER BY [Web-IadeHizmet].[FAT TAR] DESC", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetSTRREFsByGMREFOZELKOD(DataTable dt, int GMREF, string OZELKOD)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-IadeHizmet].[STRREF] FROM [Web-IadeHizmet] WHERE [Web-IadeHizmet].[GMREF] = @GMREF AND [OZEL KOD] = @OZELKOD", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@OZELKOD", SqlDbType.VarChar, 25).Value = OZELKOD;
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
