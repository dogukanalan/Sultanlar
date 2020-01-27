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
    public class MusteriOnayDurumHareketleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private byte _tintDurumID;
        private DateTime _dtZaman;
        private string _strKullanici;
        //
        //
        //
        // Constracter lar:
        //
        private MusteriOnayDurumHareketleri(int pkID, int intMusteriID, byte tintDurumID, DateTime dtZaman, string strKullanici)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._tintDurumID = tintDurumID;
            this._dtZaman = dtZaman;
            this._strKullanici = strKullanici;
        }
        //
        //
        public MusteriOnayDurumHareketleri(int intMusteriID, byte tintDurumID, DateTime dtZaman, string strKullanici)
        {
            this._intMusteriID = intMusteriID;
            this._tintDurumID = tintDurumID;
            this._dtZaman = dtZaman;
            this._strKullanici = strKullanici;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public byte tintDurumID { get { return this._tintDurumID; } set { this._tintDurumID = value; } }
        public DateTime dtZaman { get { return this._dtZaman; } set { this._dtZaman = value; } }
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
            return this._dtZaman.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumHareketEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this._dtZaman;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumHareketGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this._dtZaman;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumHareketSil", conn);
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumHareketleriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriOnayDurumHareketleri(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToByte(dr[2]), 
                            Convert.ToDateTime(dr[3]), dr[4].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_MusteriOnayDurumHareketleriGetir", conn);
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
        public static void GetObject(DataTable dt, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_MusteriOnayDurumHareketleriGetirByMusteriID", conn);
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
    }
}
