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
    public class IadeFiyat
    {
        /// <summary>
        /// [vw_IadeFiyat]
        /// </summary>
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT YIL,STRREF,TUR,GMREF,SMREF,[GRUP KOD],[OZEL KOD],ITEMREF,[MAL ACIK],[FAT TAR],[FAT NO],KDV,[AD TOP],[BRT FYT],[BRT TOP],[ISK TOP],[BDL TOP],[PRM TOP],[NET TOP],[AD ID],[AD IBD],[AD IBPD] FROM vw_IadeFiyat", conn);
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
        /// [vw_IadeFiyat]
        /// </summary>
        public static void GetObjectsByITEMREF(DataTable dt, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT YIL,STRREF,TUR,GMREF,SMREF,[GRUP KOD],[OZEL KOD],ITEMREF,[MAL ACIK],[FAT TAR],[FAT NO],KDV,[AD TOP],[BRT FYT],[BRT TOP],[ISK TOP],[BDL TOP],[PRM TOP],[NET TOP],[AD ID],[AD IBD],[AD IBPD] FROM vw_IadeFiyat WHERE ITEMREF = @ITEMREF", conn);
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
        /// [vw_IadeFiyat]
        /// </summary>
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT YIL,STRREF,TUR,GMREF,SMREF,[GRUP KOD],[OZEL KOD],ITEMREF,[MAL ACIK],[FAT TAR],[FAT NO],KDV,[AD TOP],[BRT FYT],[BRT TOP],[ISK TOP],[BDL TOP],[PRM TOP],[NET TOP],[AD ID],[AD IBD],[AD IBPD] FROM vw_IadeFiyat WHERE SMREF = @SMREF", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// [vw_IadeFiyat]
        /// </summary>
        public static void GetObjectsBySMREFITEMREF(DataTable dt, int SMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT vw_IadeFiyat.YIL, vw_IadeFiyat.STRREF, vw_IadeFiyat.TUR, vw_IadeFiyat.GMREF, vw_IadeFiyat.SMREF, vw_IadeFiyat.[GRUP KOD], vw_IadeFiyat.[OZEL KOD], vw_IadeFiyat.ITEMREF, vw_IadeFiyat.[MAL ACIK], vw_IadeFiyat.[FAT TAR], vw_IadeFiyat.[FAT NO], vw_IadeFiyat.KDV, vw_IadeFiyat.[AD TOP], CASE WHEN [Web-IadeFiyat-Adet].blAktif = 'True' THEN IsNull([Web-IadeFiyat-Adet].[AD IADE], 0) ELSE 0 END AS ADIADE, CASE WHEN [Web-IadeFiyat-Adet].blAktif = 'True' THEN (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) ELSE vw_IadeFiyat.[AD TOP] END AS ADFARK, vw_IadeFiyat.[BRT FYT], vw_IadeFiyat.[BRT TOP], vw_IadeFiyat.[ISK TOP], vw_IadeFiyat.[BDL TOP], vw_IadeFiyat.[PRM TOP], vw_IadeFiyat.[NET TOP], vw_IadeFiyat.[AD ID], vw_IadeFiyat.[AD IBD], vw_IadeFiyat.[AD IBPD] FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE /*vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0) > 0 AND*/ vw_IadeFiyat.SMREF = @SMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2 ORDER BY vw_IadeFiyat.[FAT TAR] DESC", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// [vw_IadeFiyat]
        /// </summary>
        public static void GetObjectsByGMREFITEMREF(DataTable dt, int GMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT vw_IadeFiyat.YIL, vw_IadeFiyat.STRREF, vw_IadeFiyat.TUR, vw_IadeFiyat.GMREF, vw_IadeFiyat.SMREF, vw_IadeFiyat.[GRUP KOD], vw_IadeFiyat.[OZEL KOD], vw_IadeFiyat.ITEMREF, vw_IadeFiyat.[MAL ACIK], vw_IadeFiyat.[FAT TAR], vw_IadeFiyat.[FAT NO], vw_IadeFiyat.KDV, vw_IadeFiyat.[AD TOP], CASE WHEN [Web-IadeFiyat-Adet].blAktif = 'True' THEN IsNull([Web-IadeFiyat-Adet].[AD IADE], 0) ELSE 0 END AS ADIADE, CASE WHEN [Web-IadeFiyat-Adet].blAktif = 'True' THEN (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) ELSE vw_IadeFiyat.[AD TOP] END AS ADFARK, vw_IadeFiyat.[BRT FYT], vw_IadeFiyat.[BRT TOP], vw_IadeFiyat.[ISK TOP], vw_IadeFiyat.[BDL TOP], vw_IadeFiyat.[PRM TOP], vw_IadeFiyat.[NET TOP], vw_IadeFiyat.[AD ID], vw_IadeFiyat.[AD IBD], vw_IadeFiyat.[AD IBPD] FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE /*vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0) > 0 AND*/ vw_IadeFiyat.GMREF = @GMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2 ORDER BY vw_IadeFiyat.[FAT TAR] DESC", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// [Web-IadeFiyat]
        /// </summary>
        public static double GetNETTOPBySMREFITEMREF(int SMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE SMREF = @SMREF AND ITEMREF = @ITEMREF AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// [Web-IadeFiyat]
        /// </summary>
        public static double GetNETTOPByGMREFITEMREF(int GMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE GMREF = @GMREF AND ITEMREF = @ITEMREF AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
                //SqlCommand cmd = new SqlCommand("SELECT sum(vw_IadeFiyat.[NET TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.GMREF = @GMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// [Web-IadeFiyat]
        /// </summary>
        public static double GetNETTOPBySMREFOZELKOD(int SMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE SMREF = @SMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
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
        /// [Web-IadeFiyat]
        /// </summary>
        public static double GetNETTOPByGMREFOZELKOD(int GMREF, string OZELKOD, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE GMREF = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2", conn);
                //SqlCommand cmd = new SqlCommand("SELECT sum(vw_IadeFiyat.[NET TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.GMREF = @GMREF AND vw_IadeFiyat.[OZEL KOD] = @OZELKOD AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2", conn);
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
        /// [Web-IadeFiyat]
        /// </summary>
        public static double GetOncekiIadeoplamBySMREFITEMREF(int SMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeFiyat-Adet].mnFiyat * [Web-IadeFiyat-Adet].[AD IADE]) FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] ON [Web-IadeFiyat-Adet].[STRREF] = [Web-IadeFiyat].[STRREF] WHERE [Web-IadeFiyat].[SMREF] = @SMREF AND [Web-IadeFiyat].[ITEMREF] = @ITEMREF AND [Web-IadeFiyat].[FAT TAR] >= @Date1 AND [Web-IadeFiyat].[FAT TAR] <= @Date2", conn);
                //SqlCommand cmd = new SqlCommand("SELECT sum(vw_IadeFiyat.[NET TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.GMREF = @GMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// [Web-IadeFiyat]
        /// </summary>
        public static double GetOncekiIadeoplamByGMREFITEMREF(int GMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([Web-IadeFiyat-Adet].mnFiyat * [Web-IadeFiyat-Adet].[AD IADE]) FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] ON [Web-IadeFiyat-Adet].[STRREF] = [Web-IadeFiyat].[STRREF] WHERE [Web-IadeFiyat].[GMREF] = @GMREF AND [Web-IadeFiyat].[ITEMREF] = @ITEMREF AND [Web-IadeFiyat].[FAT TAR] >= @Date1 AND [Web-IadeFiyat].[FAT TAR] <= @Date2", conn);
                //SqlCommand cmd = new SqlCommand("SELECT sum(vw_IadeFiyat.[NET TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.GMREF = @GMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        /// [vw_IadeFiyat] - ?
        /// </summary>
        public static int GetSatisAdetBySMREFITEMREF(int SMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(vw_IadeFiyat.[AD TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.SMREF = @SMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                cmd.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
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
        /// [vw_IadeFiyat] - ?
        /// </summary>
        public static int GetSatisAdetByGMREFITEMREF(int GMREF, int ITEMREF, DateTime date1, DateTime date2)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(vw_IadeFiyat.[AD TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.GMREF = @GMREF AND vw_IadeFiyat.ITEMREF = @ITEMREF AND vw_IadeFiyat.[FAT TAR] >= @Date1 AND vw_IadeFiyat.[FAT TAR] <= @Date2", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                cmd.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
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
        public static void GetSTRREFITEMREFGMREFforSonradanHizmet(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT[Web-IadeFiyat].[STRREF],[Web-IadeFiyat].[ITEMREF],[Web-IadeFiyat].[GMREF] FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] ON [Web-IadeFiyat-Adet].[STRREF] = [Web-IadeFiyat].[STRREF]", conn);
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
        /// UrunToplam,
        /// GenelToplam,
        /// IadeToplam,
        /// ToplamYuzde,
        /// ToplamOran,
        /// HizmetGenel,
        /// HizmetYuzdeli,
        /// Hizmet
        /// </summary>
        public static void GetSonradanHizmetByGMREFITEMREF(DataTable dt, int GMREF, int ITEMREF)
        {
            object obj0 = DBNull.Value;
            object obj1 = DBNull.Value;
            object obj2 = DBNull.Value;
            object obj3 = DBNull.Value;
            object obj4 = DBNull.Value;
            object obj5 = DBNull.Value;
            object obj6 = DBNull.Value;
            object obj7 = DBNull.Value;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SonradanHizmetByGMREFITEMREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        obj0 = dr[0];
                        obj1 = dr[1];
                        obj2 = dr[2];
                        obj3 = dr[3];
                        obj4 = dr[4];
                        obj5 = dr[5];
                        obj6 = dr[6];
                        obj7 = dr[7];
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

            if (obj0 != DBNull.Value && obj1 != DBNull.Value && obj2 != DBNull.Value && obj3 != DBNull.Value && obj4 != DBNull.Value 
                && obj5 != DBNull.Value && obj6 != DBNull.Value && obj7 != DBNull.Value)
            {
                DataRow drow = dt.NewRow();
                drow[0] = Convert.ToDouble(obj0);
                drow[1] = Convert.ToDouble(obj1);
                drow[2] = Convert.ToDouble(obj2);
                drow[3] = Convert.ToDouble(obj3);
                drow[4] = Convert.ToDouble(obj4);
                drow[5] = Convert.ToDouble(obj5);
                drow[6] = Convert.ToDouble(obj6);
                drow[7] = Convert.ToDouble(obj7);
                dt.Rows.Add(drow);
            }
        }
        /// <summary>
        /// -
        /// </summary>
        public static void GetSonradanHizmetByGMREFOZELKOD(DataTable dt, int GMREF, string OZELKOD, string FiyatKolonAd, DateTime date1, DateTime date2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT UrunToplam,GenelToplam,sum(mnFiyat * [AD IADE]) AS IadeToplam,HizmetGenel FROM (SELECT (SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE GMREF = @GMREF AND ITEMREF = IADEFIYAT.[ITEMREF] AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2) AS UrunToplam,(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE [GMREF] = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2) AS GenelToplam,mnFiyat,[AD IADE],(SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2) AS HizmetGenel FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] AS IADEFIYAT ON [Web-IadeFiyat-Adet].[STRREF] = IADEFIYAT.[STRREF] WHERE IADEFIYAT.GMREF = @GMREF AND IADEFIYAT.[OZEL KOD] = @OZELKOD AND IADEFIYAT.[FAT TAR] >= @Date1 AND IADEFIYAT.[FAT TAR] <= @Date2) AS GeciciTablo GROUP BY UrunToplam,GenelToplam,HizmetGenel", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT UrunToplam,GenelToplam,sum(mnFiyat * intMiktar) AS IadeToplam,HizmetGenel FROM (SELECT DISTINCT [Web-IadeFiyat-Adet].STRREF,(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE GMREF = @GMREF AND ITEMREF = IADEFIYAT.[ITEMREF] AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2) AS UrunToplam,(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE [GMREF] = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2) AS GenelToplam,mnFiyat,[Web-IadeFiyat-Adet-IadeDetayIDs].intMiktar,(SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = @GMREF AND [OZEL KOD] = @OZELKOD AND [FAT TAR] >= @Date1 AND [FAT TAR] <= @Date2) AS HizmetGenel FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] AS IADEFIYAT ON [Web-IadeFiyat-Adet].[STRREF] = IADEFIYAT.[STRREF] INNER JOIN [Web-IadeFiyat-Adet-IadeDetayIDs] ON [Web-IadeFiyat-Adet].[STRREF] = [Web-IadeFiyat-Adet-IadeDetayIDs].[STRREF] WHERE IADEFIYAT.GMREF = @GMREF AND IADEFIYAT.[OZEL KOD] = @OZELKOD AND IADEFIYAT.[FAT TAR] >= @Date1 AND IADEFIYAT.[FAT TAR] <= @Date2) AS GeciciTablo GROUP BY UrunToplam,GenelToplam,HizmetGenel", conn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT UrunToplam,GenelToplam,sum(" + FiyatKolonAd + " * [AD IADE]) AS IadeToplam,HizmetGenel FROM (SELECT (SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE GMREF = @GMREF AND ITEMREF = IADEFIYAT.[ITEMREF]) AS UrunToplam,(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE [GMREF] = @GMREF AND [OZEL KOD] = @OZELKOD) AS GenelToplam,IADEFIYAT." + FiyatKolonAd + ",[Web-IadeFiyat-Adet].[AD IADE],(SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = @GMREF AND [OZEL KOD] = @OZELKOD) AS HizmetGenel FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] AS IADEFIYAT ON [Web-IadeFiyat-Adet].[STRREF] = IADEFIYAT.[STRREF] WHERE IADEFIYAT.GMREF = @GMREF AND IADEFIYAT.[OZEL KOD] = @OZELKOD) AS GeciciTablo GROUP BY UrunToplam,GenelToplam,HizmetGenel", conn);
                //SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SonradanHizmetByGMREFOZELKOD", conn);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandTimeout = 400;
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

            //ArrayList silinecekler = new ArrayList();

            //double toplam = 0;

            //dt.Columns.Add("OZEL KOD", typeof(string));
            //dt.Columns.Add("ToplamYuzde", typeof(double));
            //dt.Columns.Add("ToplamOran", typeof(double));
            //dt.Columns.Add("HizmetYuzdeli", typeof(double));
            //dt.Columns.Add("Hizmet", typeof(double));
            //dt.Columns.Add("HizmetOzelKodToplam", typeof(double));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (Convert.ToDouble(dt.Rows[i]["IadeToplam"]) == 0)
            //    {
            //        silinecekler.Add(dt.Rows[i]);
            //    }
            //    else
            //    {
            //        dt.Rows[i]["OZEL KOD"] = Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["ITEMREF"]));
            //        dt.Rows[i]["ToplamYuzde"] = (Convert.ToDouble(dt.Rows[i]["UrunToplam"]) * 100) / Convert.ToDouble(dt.Rows[i]["GenelToplam"]);
            //        dt.Rows[i]["ToplamOran"] = Convert.ToDouble(dt.Rows[i]["UrunToplam"]) / Convert.ToDouble(dt.Rows[i]["IadeToplam"]);
            //        dt.Rows[i]["HizmetYuzdeli"] = (Convert.ToDouble(dt.Rows[i]["HizmetGenel"]) * Convert.ToDouble(dt.Rows[i]["ToplamYuzde"])) / 100;
            //        dt.Rows[i]["Hizmet"] = Convert.ToDouble(dt.Rows[i]["ToplamOran"]) == 0 ? Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) : Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) / Convert.ToDouble(dt.Rows[i]["ToplamOran"]);
            //        toplam += Convert.ToDouble(dt.Rows[i]["Hizmet"]);
            //    }
            //}

            //for (int i = 0; i < dt.Rows.Count; i++)
            //    dt.Rows[i]["HizmetOzelKodToplam"] = toplam;

            //for (int i = 0; i < silinecekler.Count; i++)
            //    dt.Rows.Remove((DataRow)silinecekler[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        public static double GetSonradanHizmetByGMREFOZELKOD(int GMREF, string OZELKOD)
        {
            double donendeger = 0;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SonradanHizmetByGMREFOZELKOD", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

            dt.Columns.Add("ToplamYuzde", typeof(double));
            dt.Columns.Add("ToplamOran", typeof(double));
            dt.Columns.Add("HizmetYuzdeli", typeof(double));
            dt.Columns.Add("Hizmet", typeof(double));
            dt.Columns.Add("HizmetOzelKodToplam", typeof(double));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["ToplamYuzde"] = (Convert.ToDouble(dt.Rows[i]["UrunToplam"]) * 100) / Convert.ToDouble(dt.Rows[i]["GenelToplam"]);
                dt.Rows[i]["ToplamOran"] = Convert.ToDouble(dt.Rows[i]["UrunToplam"]) / Convert.ToDouble(dt.Rows[i]["IadeToplam"]);
                dt.Rows[i]["HizmetYuzdeli"] = (Convert.ToDouble(dt.Rows[i]["HizmetGenel"]) * Convert.ToDouble(dt.Rows[i]["ToplamYuzde"])) / 100;
                dt.Rows[i]["Hizmet"] = Convert.ToDouble(dt.Rows[i]["ToplamOran"]) == 0 ? Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) : Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) / Convert.ToDouble(dt.Rows[i]["ToplamOran"]);
                donendeger += Convert.ToDouble(dt.Rows[i]["Hizmet"]);
            }

            return donendeger;
        }
        /// <summary>
        /// -AD ID
        /// </summary>
        public static void GetSonradanHizmet(DataTable dt, string Musteri, string Sube, string OzelAcik, string FiyatKolonAd)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SonradanHizmet", conn);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter("SELECT IADEFIYAT.[STRREF],IADEFIYAT.[GMREF],(SELECT DISTINCT [MUSTERI] FROM [Web-Musteri] WHERE [GMREF] = IADEFIYAT.[GMREF]) AS MUSTERI,IADEFIYAT.[SMREF],(SELECT DISTINCT [SUBE] FROM [Web-Musteri] WHERE [SMREF] = IADEFIYAT.[SMREF]) AS SUBE,IADEFIYAT.[ITEMREF],(SELECT [MAL ACIK] FROM [Web-Malzeme] WHERE [ITEMREF] = IADEFIYAT.[ITEMREF]) AS MALZEME,IADEFIYAT.[OZEL KOD],(SELECT DISTINCT [OZEL ACIK] FROM [Web-OzelKodlar] WHERE [OZEL KOD] = IADEFIYAT.[OZEL KOD] COLLATE TURKISH_CI_AS) AS [OZEL ACIK],(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE GMREF = IADEFIYAT.[GMREF] AND ITEMREF = IADEFIYAT.[ITEMREF]) AS UrunToplam,(SELECT sum(vw_IadeFiyat.[AD TOP]) FROM vw_IadeFiyat LEFT OUTER JOIN [Web-IadeFiyat-Adet] ON vw_IadeFiyat.STRREF = [Web-IadeFiyat-Adet].STRREF WHERE ([Web-IadeFiyat-Adet].blAktif IS NULL OR (vw_IadeFiyat.[AD TOP] - IsNull([Web-IadeFiyat-Adet].[AD IADE], 0)) > 0) AND vw_IadeFiyat.GMREF = IADEFIYAT.[GMREF] AND vw_IadeFiyat.ITEMREF = IADEFIYAT.[ITEMREF]) AS UrunSatisAdet,(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE [GMREF] = IADEFIYAT.[GMREF] AND [OZEL KOD] = IADEFIYAT.[OZEL KOD]) AS GenelToplam,(SELECT sum([Web-IadeFiyat]." + FiyatKolonAd + " * [Web-IadeFiyat-Adet].[AD IADE]) FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] ON [Web-IadeFiyat-Adet].[STRREF] = [Web-IadeFiyat].[STRREF] WHERE [Web-IadeFiyat].[GMREF] = IADEFIYAT.[GMREF] AND [Web-IadeFiyat].[ITEMREF] = IADEFIYAT.[ITEMREF]) AS IadeToplam,(SELECT sum([Web-IadeFiyat-Adet].[AD IADE]) FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] ON [Web-IadeFiyat-Adet].[STRREF] = [Web-IadeFiyat].[STRREF] WHERE [Web-IadeFiyat].[GMREF] = IADEFIYAT.[GMREF] AND [Web-IadeFiyat].[ITEMREF] = IADEFIYAT.[ITEMREF]) AS IadeAdet,(SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = IADEFIYAT.[GMREF] AND [OZEL KOD] = IADEFIYAT.[OZEL KOD]) AS HizmetGenel FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] AS IADEFIYAT ON [Web-IadeFiyat-Adet].[STRREF] = IADEFIYAT.[STRREF] WHERE [Web-IadeFiyat-Adet].blAktif = 'True' AND (SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = IADEFIYAT.[GMREF] AND [OZEL KOD] = (SELECT DISTINCT [OZEL KOD] FROM [Web-Malzeme] WHERE [ITEMREF] = IADEFIYAT.[ITEMREF])) IS NOT NULL AND [Web-Musteri].MUSTERI LIKE '%" + Musteri + "%' AND [Web-Musteri].SUBE LIKE '%" + Sube + "%' AND [Web-OzelKodlar].[OZEL ACIK] LIKE '%" + OzelAcik + "%' ORDER BY MUSTERI,SUBE,[OZEL ACIK],MALZEME", conn);
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

            ArrayList silinecekler = new ArrayList();
            //ArrayList gmrefozelkod = new ArrayList();
            //ArrayList gmrefozelkodindex = new ArrayList();

            dt.Columns.Add("ToplamYuzde", typeof(double));
            dt.Columns.Add("ToplamOran", typeof(double));
            dt.Columns.Add("HizmetYuzdeli", typeof(double));
            dt.Columns.Add("Hizmet", typeof(double));
            //dt.Columns.Add("HizmetOzelKodToplam", typeof(double));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToDouble(dt.Rows[i]["IadeToplam"]) == 0)
                {
                    silinecekler.Add(dt.Rows[i]);
                }
                else
                {
                    //dt.Rows[i]["ToplamYuzde"] = (Convert.ToDouble(dt.Rows[i]["UrunToplam"]) * 100) / Convert.ToDouble(dt.Rows[i]["GenelToplam"]);
                    //dt.Rows[i]["ToplamOran"] = Convert.ToDouble(dt.Rows[i]["UrunToplam"]) / Convert.ToDouble(dt.Rows[i]["IadeToplam"]);
                    //dt.Rows[i]["HizmetYuzdeli"] = (Convert.ToDouble(dt.Rows[i]["HizmetGenel"]) * Convert.ToDouble(dt.Rows[i]["ToplamYuzde"])) / 100;
                    //dt.Rows[i]["Hizmet"] = Convert.ToDouble(dt.Rows[i]["ToplamOran"]) == 0 ? Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) : Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) / Convert.ToDouble(dt.Rows[i]["ToplamOran"]);
                    ////dt.Rows[i]["HizmetOzelKodToplam"] = GetSonradanHizmetByGMREFOZELKOD(
                    ////    Convert.ToInt32(dt.Rows[i]["GMREF"]), dt.Rows[i]["OZEL KOD"].ToString());

                    //bool var = false;
                    //for (int j = 0; j < gmrefozelkod.Count; j++)
                    //{
                    //    if (gmrefozelkod[j].ToString() == dt.Rows[i]["GMREF"].ToString() + dt.Rows[i]["OZEL KOD"].ToString())
                    //    {
                    //        silinecekler.Add(dt.Rows[i]);
                    //        dt.Rows[(int)gmrefozelkodindex[j]]["Hizmet"] = Convert.ToDouble(dt.Rows[(int)gmrefozelkodindex[j]]["Hizmet"]) + Convert.ToDouble(dt.Rows[i]["Hizmet"]);
                    //        var = true;
                    //        break;
                    //    }
                    //}
                    //if (!var)
                    //{
                    //    gmrefozelkod.Add(dt.Rows[i]["GMREF"].ToString() + dt.Rows[i]["OZEL KOD"].ToString());
                    //    gmrefozelkodindex.Add(i);
                    //    dt.Rows[i]["Hizmet"] = Convert.ToDouble(dt.Rows[i]["Hizmet"]) + Convert.ToDouble(dt.Rows[i]["Hizmet"]);
                    //}
                }
            }

            //dt.Columns.Remove("ITEMREF");
            for (int i = 0; i < silinecekler.Count; i++)
                dt.Rows.Remove((DataRow)silinecekler[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void GetSonradanHizmet2(DataTable dt, string Musteri, string Sube, string OzelAcik, DateTime date1, DateTime date2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT IADEFIYAT.[GMREF],(SELECT DISTINCT MUSTERI FROM [Web-Musteri] WHERE GMREF = IADEFIYAT.GMREF) AS MUSTERI,IADEFIYAT.[OZEL KOD],(SELECT DISTINCT [OZEL ACIK] FROM [Web-OzelKodlar] WHERE [OZEL KOD] = IADEFIYAT.[OZEL KOD] COLLATE TURKISH_CI_AS) AS [OZEL ACIK],(SELECT sum([NET TOP]) FROM [Web-IadeFiyat] WHERE [GMREF] = IADEFIYAT.[GMREF] AND [OZEL KOD] = IADEFIYAT.[OZEL KOD]) AS GenelToplam,(SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = IADEFIYAT.[GMREF] AND [OZEL KOD] = IADEFIYAT.[OZEL KOD]) AS HizmetGenel FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] AS IADEFIYAT ON [Web-IadeFiyat-Adet].[STRREF] = IADEFIYAT.[STRREF] INNER JOIN [Web-IadeFiyat-Adet-IadeDetayIDs] ON [Web-IadeFiyat-Adet].STRREF = [Web-IadeFiyat-Adet-IadeDetayIDs].STRREF WHERE [Web-IadeFiyat-Adet-IadeDetayIDs].blAktif = 'True' AND (SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = IADEFIYAT.[GMREF] AND [OZEL KOD] = (SELECT DISTINCT [OZEL KOD] FROM [Web-Malzeme] WHERE [ITEMREF] = IADEFIYAT.[ITEMREF])) IS NOT NULL AND (SELECT DISTINCT MUSTERI FROM [Web-Musteri] WHERE GMREF = IADEFIYAT.GMREF) LIKE '%" + Musteri + "%' AND (SELECT DISTINCT SUBE FROM [Web-Musteri] WHERE SMREF = IADEFIYAT.SMREF) LIKE '%" + Sube + "%' AND (SELECT DISTINCT [OZEL ACIK] FROM [Web-OzelKodlar] WHERE [OZEL KOD] = IADEFIYAT.[OZEL KOD] COLLATE TURKISH_CI_AS) LIKE '%" + OzelAcik + "%' AND IADEFIYAT.[FAT TAR] >= @Date1 AND IADEFIYAT.[FAT TAR] <= @Date2 ORDER BY MUSTERI,[OZEL ACIK]", conn);
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date1;
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = date2;
                da.SelectCommand.CommandTimeout = 400;
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

            //ArrayList silinecekler = new ArrayList();

            //dt.Columns.Add("ToplamYuzde", typeof(double));
            //dt.Columns.Add("ToplamOran", typeof(double));
            //dt.Columns.Add("HizmetYuzdeli", typeof(double));
            //dt.Columns.Add("Hizmet", typeof(double));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (Convert.ToDouble(dt.Rows[i]["IadeToplam"]) == 0)
            //    {
            //        silinecekler.Add(dt.Rows[i]);
            //    }
            //}

            //for (int i = 0; i < silinecekler.Count; i++)
            //    dt.Rows.Remove((DataRow)silinecekler[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void GetSonradanHizmetKisa(DataTable dt, string Musteri, string Sube, string OzelAcik)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT IADEFIYAT.[GMREF],[Web-Musteri].MUSTERI,IADEFIYAT.[SMREF],[Web-Musteri].SUBE,IADEFIYAT.[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK],(SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = IADEFIYAT.[GMREF] AND [OZEL KOD] = IADEFIYAT.[OZEL KOD]) AS HizmetGenel FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat] AS IADEFIYAT ON [Web-IadeFiyat-Adet].[STRREF] = IADEFIYAT.[STRREF] INNER JOIN [Web-Musteri] ON IADEFIYAT.SMREF = [Web-Musteri].SMREF INNER JOIN [Web-OzelKodlar] ON IADEFIYAT.[OZEL KOD] = [Web-OzelKodlar].[OZEL KOD] COLLATE TURKISH_CI_AS WHERE [Web-IadeFiyat-Adet].blAktif = 'True' AND (SELECT sum([NET+KDV]) FROM [Web-IadeHizmet] WHERE GMREF = IADEFIYAT.[GMREF] AND [OZEL KOD] = (SELECT DISTINCT [OZEL KOD] FROM [Web-Malzeme] WHERE [ITEMREF] = IADEFIYAT.[ITEMREF])) IS NOT NULL  AND [Web-Musteri].MUSTERI LIKE '%" + Musteri + "%' AND [Web-Musteri].SUBE LIKE '%" + Sube + "%' AND [Web-OzelKodlar].[OZEL ACIK] LIKE '%" + OzelAcik + "%' ORDER BY MUSTERI,SUBE,[OZEL ACIK]", conn);
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

            //ArrayList silinecekler = new ArrayList();

            //dt.Columns.Add("ToplamYuzde", typeof(double));
            //dt.Columns.Add("ToplamOran", typeof(double));
            //dt.Columns.Add("HizmetYuzdeli", typeof(double));
            //dt.Columns.Add("Hizmet", typeof(double));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (Convert.ToDouble(dt.Rows[i]["IadeToplam"]) == 0)
            //    {
            //        silinecekler.Add(dt.Rows[i]);
            //    }
            //}

            //for (int i = 0; i < silinecekler.Count; i++)
            //    dt.Rows.Remove((DataRow)silinecekler[i]);
        }
    }
}
