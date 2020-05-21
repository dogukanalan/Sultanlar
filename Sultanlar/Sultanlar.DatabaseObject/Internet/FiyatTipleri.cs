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
    public class FiyatTipleri : IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private short _NOSU;
        private string _ACIKLAMA;
        //
        //
        //
        // Constracter lar:
        //
        private FiyatTipleri(short NOSU, string ACIKLAMA)
        {
            this._NOSU = NOSU;
            this._ACIKLAMA = ACIKLAMA;
        }
        //
        //
        public FiyatTipleri(string ACIKLAMA)
        {
            this._ACIKLAMA = ACIKLAMA;
        }
        //
        //
        //
        // Özellikler:
        //
        public short NOSU
        {
            get
            {
                return this._NOSU;
            }
        }
        //
        //
        public string ACIKLAMA
        {
            get
            {
                return this._ACIKLAMA;
            }
            set
            {
                this._ACIKLAMA = value;
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
            return this._ACIKLAMA;
        }
        //
        //
        //
        // Metodlar:
        //
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT NOSU, ACIKLAMA FROM [Web-FiyatTipleri] ORDER BY NOSU", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new FiyatTipleri(Convert.ToInt16(dr[0]), dr[1].ToString())); //.Substring(0, 3)
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
        public static void GetObjectAciklamali(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT NOSU, ACIKLAMA FROM [Web-FiyatTipleri] ORDER BY NOSU", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new FiyatTipleri(Convert.ToInt16(dr[0]), dr[1].ToString()));
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
        public static void GetObject(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                lic.Clear();

                SqlCommand cmd = new SqlCommand("SELECT NOSU, ACIKLAMA FROM [Web-FiyatTipleri] ORDER BY NOSU", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString(); //.Substring(0, 3)
                        lst.Value = dr[0].ToString();
                        lic.Add(lst);
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
        public static void GetObject(ListItemCollection lic, bool Seciniz, bool Tumu)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                lic.Clear();

                if (Seciniz)
                    lic.Add(new ListItem("Seçiniz", "0"));
                if (Tumu)
                    lic.Add(new ListItem("Tümü", "1"));

                SqlCommand cmd = new SqlCommand("SELECT NOSU FROM [Web-FiyatTipleri] ORDER BY NOSU", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[0].ToString();
                        lst.Value = dr[0].ToString();
                        lic.Add(lst);
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT NOSU, '' FROM [Web-FiyatTipleri]", conn);
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
        public static void GetObjects(DataTable dt, bool ful)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT NOSU, ACIKLAMA, GMREF FROM [Web-FiyatTipleri]", conn);
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
        public static void GetObjectWS(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT NOSU AS 'typeofprice_ref' FROM [Web-FiyatTipleri] ORDER BY NOSU", conn);
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
        public static string GetObjectByID(short NOSU)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT ACIKLAMA FROM [Web-FiyatTipleri] WHERE NOSU = @NOSU", conn);
                cmd.Parameters.Add("@NOSU", SqlDbType.SmallInt).Value = NOSU;
                try
                {
                    conn.Open();
                    /*SAP*/
                    object obj = cmd.ExecuteScalar(); //.Substring(0, 3)
                    if (obj != null)
                        donendeger = obj.ToString();
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
        public static bool GetNETECEVIRByID(short NOSU)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT SIPARISTE_NETE_CEVIR FROM [Web-FiyatTipleri] WHERE NOSU = @NOSU", conn);
                cmd.Parameters.Add("@NOSU", SqlDbType.SmallInt).Value = NOSU;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToBoolean(obj);
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
        public static short GetFiyatTipByGMREF(int GMREF)
        {
            short donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [TIP] FROM KurumsalWebSAP.dbo.[Web-Fiyat] WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt16(obj);
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
