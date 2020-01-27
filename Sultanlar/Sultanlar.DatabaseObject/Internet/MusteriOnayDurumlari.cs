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
    public class MusteriOnayDurumlari : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkDurumID;
        private string _strDurum;
        //
        //
        //
        // Constracter lar:
        //
        public MusteriOnayDurumlari(byte pkDurumID, string strDurum) // musterionaydurumlarisonrakiler den erisebilmek icin
        {
            this._pkDurumID = pkDurumID;
            this._strDurum = strDurum;
        }
        //
        //
        public MusteriOnayDurumlari(string strDurum)
        {
            this._strDurum = strDurum;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkDurumID
        {
            get
            {
                return this._pkDurumID;
            }
        }
        //
        //
        public string strDurum
        {
            get
            {
                return this._strDurum;
            }
            set
            {
                this._strDurum = value;
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
            return this._strDurum;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strDurum", SqlDbType.NVarChar).Value = this._strDurum;
                cmd.Parameters.Add("@pkDurumID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkDurumID = Convert.ToByte(cmd.Parameters["@pkDurumID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkDurumID", SqlDbType.TinyInt).Value = this._pkDurumID;
                cmd.Parameters.Add("@strDurum", SqlDbType.NVarChar).Value = this._strDurum;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkDurumID", SqlDbType.TinyInt).Value = this._pkDurumID;
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriOnayDurumlari(Convert.ToByte(dr[0]), dr[1].ToString()));
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
        public static string GetObjectByID(byte DurumID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariGetirByID", conn);
                cmd.Parameters.Add("@pkDurumID", SqlDbType.TinyInt).Value = DurumID;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static MusteriOnayDurumlari GetObjectByID(byte DurumID, bool klas)
        {
            MusteriOnayDurumlari donendeger = new MusteriOnayDurumlari("");

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariGetirByID", conn);
                cmd.Parameters.Add("@pkDurumID", SqlDbType.TinyInt).Value = DurumID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        donendeger = new MusteriOnayDurumlari(DurumID, dr[0].ToString());
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
