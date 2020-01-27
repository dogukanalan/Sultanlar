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

namespace Sultanlar.DatabaseObject
{
    public class PerSSKFirmalar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkPerSSKFirmaID;
        private string _strPerSSKFirmaAdi;
        //
        //
        //
        // Constracter lar:
        //
        private PerSSKFirmalar(byte pkPerSSKFirmaID, string strPerSSKFirmaAdi)
        {
            this._pkPerSSKFirmaID = pkPerSSKFirmaID;
            this._strPerSSKFirmaAdi = strPerSSKFirmaAdi;
        }
        //
        //
        public PerSSKFirmalar(string strPerSSKFirmaAdi)
        {
            this._strPerSSKFirmaAdi = strPerSSKFirmaAdi;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkPerSSKFirmaID
        {
            get
            {
                return this._pkPerSSKFirmaID;
            }
        }
        //
        //
        public string strPerSSKFirmaAdi
        {
            get
            {
                return this._strPerSSKFirmaAdi;
            }
            set
            {
                this._strPerSSKFirmaAdi = value;
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
            return this._strPerSSKFirmaAdi;
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
                SqlCommand cmd = new SqlCommand("sp_PerSSKFirmaEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strPerSSKFirmaAdi", SqlDbType.NVarChar).Value = this._strPerSSKFirmaAdi;
                cmd.Parameters.Add("@pkPerSSKFirmaID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkPerSSKFirmaID = Convert.ToByte(cmd.Parameters["@pkPerSSKFirmaID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_PerSSKFirmaGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkPerSSKFirmaID", SqlDbType.TinyInt).Value = this._pkPerSSKFirmaID;
                cmd.Parameters.Add("@strPerSSKFirmaAdi", SqlDbType.NVarChar).Value = this._strPerSSKFirmaAdi;
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
                SqlCommand cmd = new SqlCommand("sp_PerSSKFirmaSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkPerSSKFirmaID", SqlDbType.TinyInt).Value = this._pkPerSSKFirmaID;
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

                SqlCommand cmd = new SqlCommand("sp_PerSSKFirmaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new PerSSKFirmalar(Convert.ToByte(dr[0]), dr[1].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_PerSSKFirmaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow dtrow = dt.NewRow();
                        dtrow[0] = dr[0].ToString();
                        dtrow[1] = dr[1].ToString();
                        dt.Rows.Add(dtrow);
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
