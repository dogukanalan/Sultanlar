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
    public class Dereceler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkDereceID;
        private string _strDerece;
        //
        //
        //
        // Constracter lar:
        //
        private Dereceler(byte pkDereceID, string strDerece)
        {
            this._pkDereceID = pkDereceID;
            this._strDerece = strDerece;
        }
        //
        //
        public Dereceler(string strDerece)
        {
            this._strDerece = strDerece;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkDereceID
        {
            get
            {
                return this._pkDereceID;
            }
        }
        //
        //
        public string strDerece
        {
            get
            {
                return this._strDerece;
            }
            set
            {
                this._strDerece = value;
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
        // Metodlar:
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DereceEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strDerece", SqlDbType.NVarChar, 10).Value = this._strDerece;
                cmd.Parameters.Add("@pkDereceID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkDereceID = Convert.ToByte(cmd.Parameters["@pkDereceID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_DereceGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkDereceID", SqlDbType.TinyInt).Value = this._pkDereceID;
                cmd.Parameters.Add("@strDerece", SqlDbType.NVarChar, 10).Value = this._strDerece;
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
                SqlCommand cmd = new SqlCommand("sp_DereceSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkDereceID", SqlDbType.TinyInt).Value = this._pkDereceID;
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
        public static void GetObject(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                SqlCommand cmd = new SqlCommand("sp_DereceGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DereceGetir", conn);
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
