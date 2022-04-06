using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class FiyatlarTP
    {
        public static void Update(short FiyatTipi, int Yil, int Ay)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Fiyat-TP]  WHERE TIP=" + FiyatTipi.ToString() + " AND YIL=" + Yil.ToString() + " AND AY=" + Ay.ToString() + " INSERT INTO [Web-Fiyat-TP] ([YIL],[AY],[TIP],GMREF,[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]) SELECT " + Yil.ToString() + "," + Ay.ToString() + ",[TIP],GMREF,[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH] FROM [Web-Fiyat] WHERE TIP = " + FiyatTipi.ToString(), conn);
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

        public static void GetObjects(DataTable dt, short FiyatTipi, int Yil, int Ay)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT *,(SELECT [ES KOD] FROM [Web-Malzeme] WHERE ITEMREF = [Web-Fiyat-TP].ITEMREF) AS ESKOD FROM [Web-Fiyat-TP] WHERE TIP = " + FiyatTipi.ToString() + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString(), conn);
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
        /// [Web-Fiyat-TP-3]
        /// </summary>
        public static void GetObjects(DataTable dt, short FiyatTipi, int Yil, int Ay, int Gun)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_FiyatTPGetir3", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                da.SelectCommand.Parameters.Add("@GUN", SqlDbType.Int).Value = Gun;
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = FiyatTipi;
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

        public static decimal GetFiyat(int UrunID, short FiyatTipi, int Yil, int Ay)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FIYAT FROM [Web-Fiyat-TP] WHERE ITEMREF = " + UrunID.ToString() + " AND TIP = " + FiyatTipi.ToString() + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString(), conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// [Web-Fiyat-TP-3]
        /// </summary>
        public static decimal GetFiyat(int UrunID, short FiyatTipi, int Yil, int Ay, int Gun)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(FIYAT) AS FIYAT FROM [Web-Fiyat-TP-3] WHERE ITEMREF = " + UrunID.ToString() + " AND TIP = " + FiyatTipi.ToString() + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + " AND GUN <= " + Gun.ToString(), conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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

        public static decimal GetNetFiyat(int UrunID, short FiyatTipi, int Yil, int Ay)
        {
            decimal donendeger = 0;

            string fiyattip = FiyatTipi != 7 ? (" AND TIP = " + FiyatTipi.ToString()) : (" AND (TIP = 7 OR TIP > 500)"); // bazı ürünlerin sadece 500 lülerde fiyatı oluyor f7 de olmuyor örneğin hakmar ürünü migros ürünü

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT NET FROM [Web-Fiyat-TP] WHERE ITEMREF = " + UrunID.ToString() + fiyattip + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString(), conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// [Web-Fiyat-TP-3]
        /// </summary>
        public static decimal GetNetFiyat(int UrunID, short FiyatTipi, int Yil, int Ay, int Gun)
        {
            decimal donendeger = 0;

            string fiyattip = FiyatTipi != 7 ? (" AND TIP = " + FiyatTipi.ToString()) : (" AND (TIP = 7 OR TIP > 500)"); // bazı ürünlerin sadece 500 lülerde fiyatı oluyor f7 de olmuyor örneğin hakmar ürünü migros ürünü

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(NET) AS NET FROM [Web-Fiyat-TP-3] WHERE ITEMREF = " + UrunID.ToString() + fiyattip + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + " AND GUN <= " + Gun.ToString(), conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// Eğer iskonto yoksa şu andaki fiyat tablosuna bakıyor
        /// </summary>
        public static double GetIskFiyat(int UrunID, int ISK, short FiyatTipi, int Yil, int Ay)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ISK" + ISK.ToString() + " FROM [Web-Fiyat-TP] WHERE ITEMREF = " + UrunID.ToString() + " AND TIP = " + FiyatTipi.ToString() + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString(), conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        donendeger = Convert.ToDouble(obj);
                    }
                    else
                    {
                        int iskonto = ISK <= 4 ? ISK - 1 : ISK;
                        obj = Urunler.GetProductDiscountsAndPriceFULL(
                                UrunID, FiyatTipi)[iskonto];

                        if (obj != null)
                            donendeger = Convert.ToDouble(obj);
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
        /// <summary>
        /// [Web-Fiyat-TP-3] Eğer iskonto yoksa şu andaki fiyat tablosuna bakıyor
        /// </summary>
        public static double GetIskFiyat(int UrunID, int ISK, short FiyatTipi, int Yil, int Ay, int Gun)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(ISK" + ISK.ToString() + ") AS ISK" + ISK.ToString() + " FROM [Web-Fiyat-TP-3] WHERE ITEMREF = " + UrunID.ToString() + " AND TIP = " + FiyatTipi.ToString() + " AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + " AND GUN <= " + Gun.ToString(), conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        donendeger = Convert.ToDouble(obj);
                    }
                    else
                    {
                        int iskonto = ISK <= 4 ? ISK - 1 : ISK;
                        obj = Urunler.GetProductDiscountsAndPriceFULL(
                                UrunID, FiyatTipi)[iskonto];

                        if (obj != null)
                            donendeger = Convert.ToDouble(obj);
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

        public static decimal DoInsert(int Yil, int Ay, short FiyatTipi, int GMREF, 
            string grupkod, string ozelkod, string hk, string ozelacik, string reykod, string rk, string reyacik, int itemref, string malacik,
            double fiyat, double isk1, double isk2, double isk3, double isk4, double isk5, double isk6, double isk7, double isk8, double isk9, double isk10,
            double net, double netkdv, int vade)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Fiyat-TP] ([YIL],[AY],[TIP],[GMREF],[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]) VALUES (@YIL,@AY,@TIP,@GMREF,@GRUPKOD,@OZELKOD,@HK,@OZELACIK,@REYKOD,@RK,@REYACIK,@ITEMREF,@MALACIK,@FIYAT,@ISK1,@ISK2,@ISK3,@ISK4,@ISK5,@ISK6,@ISK7,@ISK8,@ISK9,@ISK10,@NET,@NETKDV,@VADE,NULL,@ODEME_GUN,NULL)", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = FiyatTipi;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@GRUPKOD", SqlDbType.VarChar).Value = grupkod;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.VarChar).Value = ozelkod;
                cmd.Parameters.Add("@HK", SqlDbType.VarChar).Value = hk;
                cmd.Parameters.Add("@OZELACIK", SqlDbType.VarChar).Value = ozelacik;
                cmd.Parameters.Add("@REYKOD", SqlDbType.VarChar).Value = reykod;
                cmd.Parameters.Add("@RK", SqlDbType.VarChar).Value = rk;
                cmd.Parameters.Add("@REYACIK", SqlDbType.VarChar).Value = reyacik;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = itemref;
                cmd.Parameters.Add("@MALACIK", SqlDbType.VarChar).Value = malacik;
                cmd.Parameters.Add("@FIYAT", SqlDbType.Float).Value = fiyat;
                cmd.Parameters.Add("@ISK1", SqlDbType.Float).Value = isk1;
                cmd.Parameters.Add("@ISK2", SqlDbType.Float).Value = isk2;
                cmd.Parameters.Add("@ISK3", SqlDbType.Float).Value = isk3;
                cmd.Parameters.Add("@ISK4", SqlDbType.Float).Value = isk4;
                cmd.Parameters.Add("@ISK5", SqlDbType.Float).Value = isk5;
                cmd.Parameters.Add("@ISK6", SqlDbType.Float).Value = isk6;
                cmd.Parameters.Add("@ISK7", SqlDbType.Float).Value = isk7;
                cmd.Parameters.Add("@ISK8", SqlDbType.Float).Value = isk8;
                cmd.Parameters.Add("@ISK9", SqlDbType.Float).Value = isk9;
                cmd.Parameters.Add("@ISK10", SqlDbType.Float).Value = isk10;
                cmd.Parameters.Add("@NET", SqlDbType.Float).Value = net;
                cmd.Parameters.Add("@NETKDV", SqlDbType.Float).Value = netkdv;
                cmd.Parameters.Add("@VADE", SqlDbType.Int).Value = vade;
                cmd.Parameters.Add("@ODEME_GUN", SqlDbType.Int).Value = vade;
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

            return donendeger;
        }

        public static int GetVade(int TIP)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("db_sp_VadeGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TIP", TIP);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
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
    }
}
