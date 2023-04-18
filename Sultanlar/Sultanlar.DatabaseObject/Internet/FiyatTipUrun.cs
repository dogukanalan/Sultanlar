using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class FiyatTipUrun : IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _TIP;
        private int _ITEMREF;
        //
        //
        //
        // Constracter lar:
        //
        /*public FiyatTipUrun(int TIP, int ITEMREF)
        {
            this._TIP = TIP;
            this._ITEMREF = ITEMREF;
        }*/
        public FiyatTipUrun(int TIP, int ITEMREF, string KULLANICI)
        {
            this._TIP = TIP;
            this._ITEMREF = ITEMREF;
            this.KULLANICI = KULLANICI;
        }
        //
        //
        //
        // Özellikler:
        //
        private string KULLANICI {get;set;}
        public int TIP
        {
            get
            {
                return this._TIP;
            }
            set
            {
                this._TIP = value;
            }
        }
        //
        //
        public int ITEMREF
        {
            get
            {
                return this._ITEMREF;
            }
            set
            {
                this._ITEMREF = value;
            }
        }
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
            return this._ITEMREF.ToString() + "-" + Urunler.GetProductName(this._ITEMREF, true);
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
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-FiyatTip-Urun] WHERE TIP = @TIP AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = this._TIP;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this._ITEMREF;
                conn.Open();
                bool varmi = Convert.ToBoolean(cmd.ExecuteScalar());
                if (!varmi)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO [Web-FiyatTip-Urun] (TIP,ITEMREF) VALUES (@TIP,@ITEMREF)", conn);
                    cmd2.Parameters.Add("@TIP", SqlDbType.Int).Value = this._TIP;
                    cmd2.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this._ITEMREF;
                    cmd2.ExecuteNonQuery();
                }
                SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-FiyatTip-Urun-Log] (TIP,ITEMREF,KULLANICI,EKLE,TARIH) VALUES (@TIP,@ITEMREF,@KULLANICI,@EKLE,@TARIH)", conn);
                cmd3.Parameters.Add("@TIP", SqlDbType.Int).Value = this._TIP;
                cmd3.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this._ITEMREF;
                cmd3.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = this.KULLANICI;
                cmd3.Parameters.Add("@EKLE", SqlDbType.Bit).Value = true;
                cmd3.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = DateTime.Now;
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void DoDelete(int TIP, int ITEMREF, string KULLANICI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-FiyatTip-Urun] WHERE TIP = @TIP AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                conn.Open();
                cmd.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-FiyatTip-Urun-Log] (TIP,ITEMREF,KULLANICI,EKLE,TARIH) VALUES (@TIP,@ITEMREF,@KULLANICI,@EKLE,@TARIH)", conn);
                cmd3.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd3.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd3.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;
                cmd3.Parameters.Add("@EKLE", SqlDbType.Bit).Value = false;
                cmd3.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = DateTime.Now;
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP,[Web-FiyatTip-Urun].ITEMREF,[MAL ACIK] AS MALZEME FROM [Web-FiyatTip-Urun] INNER JOIN [Web-Malzeme-Full] ON [Web-FiyatTip-Urun].ITEMREF = [Web-Malzeme-Full].ITEMREF ORDER BY TIP,ITEMREF", conn);
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
        public static void GetObjects(DataTable dt, int TIP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP,[Web-FiyatTip-Urun].ITEMREF,[MAL ACIK] FROM [Web-FiyatTip-Urun] INNER JOIN [Web-Malzeme-Full] ON [Web-FiyatTip-Urun].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = @TIP ORDER BY TIP,ITEMREF", conn);
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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
        public static void GetOlanlar(DataTable dt, int TIP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP,[Web-FiyatTip-Urun].ITEMREF,[MAL ACIK] AS MALZEME,AP FROM [Web-FiyatTip-Urun] INNER JOIN [Web-Malzeme-Full] ON [Web-FiyatTip-Urun].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = @TIP ORDER BY TIP,ITEMREF", conn);
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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
        public static void GetOlmayanlar(DataTable dt, int TIP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-Fiyat].TIP,[Web-Fiyat].ITEMREF,[Web-Fiyat].[MAL ACIK] AS MALZEME,AP FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF FULL OUTER JOIN [Web-FiyatTip-Urun] ON [Web-Fiyat].TIP = [Web-FiyatTip-Urun].TIP AND [Web-Fiyat].ITEMREF = [Web-FiyatTip-Urun].ITEMREF WHERE [Web-Fiyat].TIP = @TIP AND [Web-FiyatTip-Urun].ITEMREF IS NULL ORDER BY [Web-Fiyat].TIP,[Web-Fiyat].ITEMREF", conn);
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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
        public static void GetOlanlar5000(DataTable dt, int TIP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP,[Web-Fiyat_VY].ITEMREF,[MAL ACIK] AS MALZEME,AP FROM [Web-Fiyat_VY] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat_VY].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = @TIP ORDER BY [Web-Fiyat_VY].ITEMREF", conn);
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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
        public static void GetOlmayanlar5000(DataTable dt, int TIP, int TIP500)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT @TIP,[Web-Malzeme-Full].ITEMREF,[Web-Malzeme-Full].[MAL ACIK] AS MALZEME,AP FROM [Web-Malzeme-Full] INNER JOIN [Web-Fiyat] ON [Web-Malzeme-Full].ITEMREF = [Web-Fiyat].ITEMREF AND [Web-Fiyat].TIP = 20 WHERE [Web-Malzeme-Full].ITEMREF > 1200000 AND [Web-Malzeme-Full].ITEMREF < 1600000 AND [Web-Malzeme-Full].ITEMREF NOT IN (SELECT ITEMREF FROM [Web-Fiyat_VY] WHERE TIP = @TIP) ORDER BY ITEMREF", conn); //SELECT @TIP,ITEMREF,[MAL ACIK] AS MALZEME,AP FROM [Web-Malzeme-Full] WHERE ITEMREF NOT IN (SELECT ITEMREF FROM [Web-Fiyat_VY] WHERE TIP = @TIP) ORDER BY ITEMREF
                if (TIP500 > 0 && TIP500 != TIP)
                    da.SelectCommand.CommandText = "SELECT @TIP,[Web-Fiyat].ITEMREF,[Web-Fiyat].[MAL ACIK] AS MALZEME,AP FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = " + TIP500.ToString() + " AND [Web-Fiyat].ITEMREF NOT IN (SELECT ITEMREF FROM [Web-Fiyat_VY] AS FIY WHERE TIP = @TIP) ORDER BY [Web-Fiyat].ITEMREF";
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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
        public static void DoInsert5000(int TIP, int ITEMREF, int TIP500, string KULLANICI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Fiyat_VY] WHERE TIP = @TIP AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                conn.Open();
                bool varmi = Convert.ToBoolean(cmd.ExecuteScalar());
                if (!varmi)
                {
                    bool besyuzdevarmi = true;
                    if (TIP500 != 0)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT count(*) FROM [Web-Fiyat] WHERE TIP = @TIP AND ITEMREF = @ITEMREF", conn);
                        cmd4.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP500;
                        cmd4.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                        besyuzdevarmi = Convert.ToBoolean(cmd4.ExecuteScalar());
                    }

                    if (besyuzdevarmi)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO [Web-Fiyat_VY] (TIP,MTIP,BY_REF,ANA_GMREF,GMREF,ITEMREF) VALUES (@TIP,(SELECT MTIP FROM [Web-FiyatTipleri] WHERE NOSU = @TIP),(SELECT BY_REF FROM [Web-FiyatTipleri] WHERE NOSU = @TIP),(SELECT ANA_GMREF FROM [Web-FiyatTipleri] WHERE NOSU = @TIP),(SELECT GMREF FROM [Web-FiyatTipleri] WHERE NOSU = @TIP),@ITEMREF)", conn);
                        cmd2.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                        cmd2.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                        cmd2.ExecuteNonQuery();
                    }

                    SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-FiyatTip-Urun-Log] (TIP,ITEMREF,KULLANICI,EKLE,TARIH) VALUES (@TIP,@ITEMREF,@KULLANICI,@EKLE,@TARIH)", conn);
                    cmd3.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                    cmd3.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                    cmd3.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;
                    cmd3.Parameters.Add("@EKLE", SqlDbType.Bit).Value = true;
                    cmd3.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd3.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        //
        //
        public static void DoDelete5000(int TIP, int ITEMREF, string KULLANICI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Fiyat_VY] WHERE TIP = @TIP AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                conn.Open();
                cmd.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-FiyatTip-Urun-Log] (TIP,ITEMREF,KULLANICI,EKLE,TARIH) VALUES (@TIP,@ITEMREF,@KULLANICI,@EKLE,@TARIH)", conn);
                cmd3.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd3.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd3.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;
                cmd3.Parameters.Add("@EKLE", SqlDbType.Bit).Value = false;
                cmd3.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = DateTime.Now;
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
