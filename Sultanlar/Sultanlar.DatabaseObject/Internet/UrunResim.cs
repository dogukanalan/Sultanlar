using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class UrunResim : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        int _Sira;
        private int _ITEMREF;
        private int _intResimID;
        private DateTime _dtEklenme;
        private string _strEkleyen;
        //
        //
        //
        // Constracter lar:
        //
        //
        //
        public UrunResim(int Sira, int ITEMREF, int intResimID, DateTime dtEklenme, string strEkleyen)
        {
            this._Sira = Sira;
            this._ITEMREF = ITEMREF;
            this._intResimID = intResimID;
            this._dtEklenme = dtEklenme;
            this._strEkleyen = strEkleyen;
        }
        //
        //
        //
        // Özellikler:
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
        public int intResimID
        {
            get
            {
                return this._intResimID;
            }
            set
            {
                this._intResimID = value;
            }
        }
        //
        //
        public DateTime dtEklenme
        {
            get
            {
                return this._dtEklenme;
            }
            set
            {
                this._dtEklenme = value;
            }
        }
        //
        //
        public string strEkleyen
        {
            get
            {
                return this._strEkleyen;
            }
            set
            {
                this._strEkleyen = value;
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
            return this._Sira.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UrunResimEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this._ITEMREF;
                cmd.Parameters.Add("@intResimID", SqlDbType.Int).Value = this._intResimID;
                cmd.Parameters.Add("@dtEklenme", SqlDbType.DateTime).Value = this._dtEklenme;
                cmd.Parameters.Add("@strEkleyen", SqlDbType.NVarChar).Value = this._strEkleyen;
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
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UrunResimGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this._ITEMREF;
                cmd.Parameters.Add("@intResimID", SqlDbType.Int).Value = this._intResimID;
                cmd.Parameters.Add("@dtEklenme", SqlDbType.DateTime).Value = this._dtEklenme;
                cmd.Parameters.Add("@strEkleyen", SqlDbType.NVarChar).Value = this._strEkleyen;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UrunResimSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this._ITEMREF;
                cmd.Parameters.Add("@intResimID", SqlDbType.Int).Value = this._intResimID;
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
        public static void GetObjects(IList List, int ITEMREF, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UrunResimGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int sira = 0;
                    while (dr.Read())
                    {
                        sira++;
                        List.Add(new UrunResim(sira, Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToDateTime(dr[2]), dr[3].ToString()));
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
        }
        //
        //
        public static void GetObjects(ListItemCollection lic, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UrunResimGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int sira = 0;
                    while (dr.Read())
                    {
                        sira++;
                        ListItem list = new ListItem(sira.ToString(), dr[1].ToString());
                        lic.Add(list);
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
        }
        //
        //
        public static void GetObjects(DataTable dt, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_UrunResimGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        //
        //
        public static void GetIstatistik(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [strEkleyen],(SELECT count(*) FROM tblINTERNET_UrunResim WHERE strEkleyen = [KurumsalWebSAP].[dbo].[tblINTERNET_UrunResim].strEkleyen) AS ResimSayisi FROM [KurumsalWebSAP].[dbo].[tblINTERNET_UrunResim] ORDER BY ResimSayisi DESC", conn);
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
        public static void GetTedarikciResimSayisi(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT [OZEL ACIK], count([OZEL ACIK]) AS ResimSayisi FROM [Web-Malzeme] WHERE ITEMREF IN (SELECT [Web-Malzeme].ITEMREF FROM [Web-Malzeme] INNER JOIN tblINTERNET_UrunResim ON [Web-Malzeme].ITEMREF = tblINTERNET_UrunResim.ITEMREF) GROUP BY [OZEL ACIK] UNION SELECT DISTINCT [OZEL ACIK], '0' AS ResimSayisi FROM [Web-Malzeme] WHERE [OZEL ACIK] NOT IN (SELECT DISTINCT [OZEL ACIK] FROM [Web-Malzeme] WHERE [ITEMREF] IN (SELECT [ITEMREF] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_UrunResim])) ORDER BY [OZEL ACIK]", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[OZEL ACIK]," + 
                    "(SELECT count(DISTINCT [ITEMREF]) FROM [Web-Fiyat] WHERE [OZEL KOD] = [Web-Malzeme].[OZEL KOD]) AS ToplamUrunSayisi," +
                    "count([OZEL ACIK]) AS ResimliUrunSayisi " +
                    "FROM [Web-Malzeme] " +
                    "WHERE ITEMREF IN " +
                    "(SELECT [Web-Malzeme].ITEMREF FROM [Web-Malzeme] INNER JOIN tblINTERNET_UrunResim ON [Web-Malzeme].ITEMREF = tblINTERNET_UrunResim.ITEMREF) " +
                    "GROUP BY [OZEL ACIK],[OZEL KOD] " +
                    "UNION " +
                    "SELECT DISTINCT " +
                    "[OZEL ACIK]," +
                    "(SELECT count(DISTINCT [ITEMREF]) FROM [Web-Fiyat] WHERE [OZEL KOD] = [Web-Malzeme].[OZEL KOD]) AS ToplamUrunSayisi," +
                    "'0' AS ResimliUrunSayisi " +
                    "FROM [Web-Malzeme] " +
                    "WHERE [OZEL ACIK] NOT IN " +
                    "(SELECT DISTINCT [OZEL ACIK] FROM [Web-Malzeme] WHERE [ITEMREF] IN (SELECT [ITEMREF] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_UrunResim])) " +
                    "ORDER BY [OZEL ACIK]"
                , conn);
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

            dt.Columns.Add("ResimsizUrunSayisi", typeof(int));
            dt.Columns.Add("Yuzde", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["ResimsizUrunSayisi"] = Convert.ToInt32(dt.Rows[i]["ToplamUrunSayisi"]) - Convert.ToInt32(dt.Rows[i]["ResimliUrunSayisi"]);
                if (Convert.ToInt32(dt.Rows[i]["ToplamUrunSayisi"]) != 0)
                    dt.Rows[i]["Yuzde"] = (Convert.ToInt32(dt.Rows[i]["ResimliUrunSayisi"]) * 100) / Convert.ToInt32(dt.Rows[i]["ToplamUrunSayisi"]);
                else
                    dt.Rows[i]["Yuzde"] = 0;
            }
        }
        //
        //
        public static int GetResimIDByUrunID(int ITEMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        //
        //
        public static int GetUrunIDByResimID(int ResimID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ITEMREF FROM tblINTERNET_UrunResim WHERE intResimID = @ResimID", conn);
                cmd.Parameters.Add("@ResimID", SqlDbType.Int).Value = ResimID;
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
    }
}
