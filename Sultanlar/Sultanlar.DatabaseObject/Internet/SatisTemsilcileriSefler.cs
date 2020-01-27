using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SatisTemsilcileriSefler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _ustSLSREF;
        private int _altSLSREF;
        //
        //
        //
        // Constracter lar:
        //
        private SatisTemsilcileriSefler()
        {

        }
        //
        //
        public SatisTemsilcileriSefler(int ustSLSREF)
        {
            this._ustSLSREF = ustSLSREF;
        }
        //
        //
        public SatisTemsilcileriSefler(int ustSLSREF, int altSLSREF)
        {
            this._ustSLSREF = ustSLSREF;
            this._altSLSREF = altSLSREF;
        }
        //
        //
        //
        // Özellikler:
        //
        public int ustSLSREF
        {
            get
            {
                return this._ustSLSREF;
            }
            set
            {
                this._ustSLSREF = value;
            }
        }
        //
        //
        public int altSLSREF
        {
            get
            {
                return this._altSLSREF;
            }
            set
            {
                this._altSLSREF = value;
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
            return SatisTemsilcileri.GetObjectBySLSREF(this._ustSLSREF)[1].ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = this._ustSLSREF;
                cmd.Parameters.Add("@altSLSREF", SqlDbType.Int).Value = this._altSLSREF;
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
        public void DoUpdate() // gereksiz, ustslsref belirtilerek altslsrefi guncelliyor
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = this._ustSLSREF;
                cmd.Parameters.Add("@altSLSREF", SqlDbType.Int).Value = this._altSLSREF;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = this._ustSLSREF;
                cmd.Parameters.Add("@altSLSREF", SqlDbType.Int).Value = this._altSLSREF;
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
        public static void DoDeleteAltlarla(int UstSLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerSilAltlarla", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = UstSLSREF;
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
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisTemsilcileriSefler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1])));
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
        public static void GetUstler(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerGetirUstler", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisTemsilcileriSefler(Convert.ToInt32(dr[0])));
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
        public static ArrayList GetAltRefler(int ustSLSREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerGetirByUstSLSREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = ustSLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(Convert.ToInt32(dr[0]));
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
        public static ArrayList GetAltlar(int ustSLSREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerGetirByUstSLSREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = ustSLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //donendeger.Add(Convert.ToInt32(dr[0]));
                        donendeger.Add(SatisTemsilcileri.GetObjectBySLSREF(Convert.ToInt32(dr[0]))[1]);
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
        public static void GetAltlar(ListItemCollection lic, int ustSLSREF)
        {
            lic.Clear();

            //lic.Add(new ListItem("Seçiniz", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcileriSeflerGetirByUstSLSREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ustSLSREF", SqlDbType.Int).Value = ustSLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        /*SAP*/
                        ArrayList st = SatisTemsilcileri.GetObjectBySLSREF(Convert.ToInt32(dr[0]));
                        if (st.Count > 0)
                            lic.Add(new ListItem(st[1].ToString(), dr[0].ToString()));
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
    }
}
