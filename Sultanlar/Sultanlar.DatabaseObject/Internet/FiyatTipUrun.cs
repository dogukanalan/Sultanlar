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
        public FiyatTipUrun(int TIP, int ITEMREF)
        {
            this._TIP = TIP;
            this._ITEMREF = ITEMREF;
        }
        //
        //
        //
        // Özellikler:
        //
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
                conn.Close();
            }
        }
        //
        //
        public static void DoDelete(int TIP, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-FiyatTip-Urun] WHERE TIP = @TIP AND ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                conn.Open();
                cmd.ExecuteNonQuery();
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP,[Web-FiyatTip-Urun].ITEMREF,[MAL ACIK] AS MALZEME FROM [Web-FiyatTip-Urun] INNER JOIN [Web-Malzeme-Full] ON [Web-FiyatTip-Urun].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = @TIP ORDER BY TIP,ITEMREF", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP,ITEMREF,[MAL ACIK] AS MALZEME FROM [Web-Fiyat] WHERE TIP = @TIP AND ITEMREF NOT IN (SELECT ITEMREF FROM [Web-FiyatTip-Urun] WHERE TIP = [Web-Fiyat].TIP) ORDER BY TIP,ITEMREF", conn);
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
    }
}
