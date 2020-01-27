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
    public class MusteriOnayDurumYetkileri
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private byte _tintDurumID;
        private string _strKullanici;
        //
        //
        //
        // Constracter lar:
        //
        private MusteriOnayDurumYetkileri(int pkID, byte tintDurumID, string strKullanici)
        {
            this._pkID = pkID;
            this._tintDurumID = tintDurumID;
            this._strKullanici = strKullanici;
        }
        //
        //
        public MusteriOnayDurumYetkileri(byte tintDurumID, string strKullanici)
        {
            this._tintDurumID = tintDurumID;
            this._strKullanici = strKullanici;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public byte tintDurumID { get { return this._tintDurumID; } set { this._tintDurumID = value; } }
        public string strKullanici { get { return this._strKullanici; } set { this._strKullanici = value; } }
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
            return this._strKullanici.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumYetkiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@strKullanici", SqlDbType.NVarChar).Value = this._strKullanici;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumYetkiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@strKullanici", SqlDbType.NVarChar).Value = this._strKullanici;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumYetkiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumYetkileriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriOnayDurumYetkileri(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), dr[2].ToString()));
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_MusteriOnayDurumYetkileriGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static void GetObjectByDurumID(IList List, byte DurumID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumYetkileriGetirByDurumID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = DurumID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriOnayDurumYetkileri(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), dr[2].ToString()));
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
