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
    public class MusteriOnayDurumlariSonrakiler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _tintDurumID;
        private byte _tintSonrakiDurumID;
        //
        //
        //
        // Constracter lar:
        //
        private MusteriOnayDurumlariSonrakiler(byte tintDurumID, byte tintSonrakiDurumID)
        {
            this._tintDurumID = tintDurumID;
            this._tintSonrakiDurumID = tintSonrakiDurumID;
        }
        //
        //
        public MusteriOnayDurumlariSonrakiler(byte tintSonrakiDurumID)
        {
            this._tintSonrakiDurumID = tintSonrakiDurumID;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte tintDurumID
        {
            get
            {
                return this._tintDurumID;
            }
            set
            {
                this._tintDurumID = value;
            }
        }
        //
        //
        public byte tintSonrakiDurumID
        {
            get
            {
                return this._tintSonrakiDurumID;
            }
            set
            {
                this._tintSonrakiDurumID = value;
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
            return this._tintSonrakiDurumID.ToString() + " - " + this._tintSonrakiDurumID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariSonrakilerEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@tintSonrakiDurumID", SqlDbType.TinyInt).Value = this._tintSonrakiDurumID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariSonrakilerGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@tintSonrakiDurumID", SqlDbType.TinyInt).Value = this._tintSonrakiDurumID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariSonrakilerSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = this._tintDurumID;
                cmd.Parameters.Add("@tintSonrakiDurumID", SqlDbType.TinyInt).Value = this._tintSonrakiDurumID;
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariSonrakilerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriOnayDurumlariSonrakiler(Convert.ToByte(dr[0]), Convert.ToByte(dr[1])));
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
        public static void GetObjectByID(IList List, byte DurumID)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriOnayDurumlariSonrakilerGetirByID", conn);
                cmd.Parameters.Add("@tintDurumID", SqlDbType.TinyInt).Value = DurumID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        MusteriOnayDurumlari mod = MusteriOnayDurumlari.GetObjectByID(Convert.ToByte(dr[0]), true);
                        List.Add(new MusteriOnayDurumlari(mod.pkDurumID, mod.strDurum));
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
