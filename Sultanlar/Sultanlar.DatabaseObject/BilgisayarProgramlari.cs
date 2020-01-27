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
    public class BilgisayarProgramlari : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkBilgisayarProgramiID;
        private string _strBilgisayarProgrami;
        //
        //
        //
        // Constracter lar:
        //
        private BilgisayarProgramlari(byte pkBilgisayarProgramiID, string strBilgisayarProgrami)
        {
            this._pkBilgisayarProgramiID = pkBilgisayarProgramiID;
            this._strBilgisayarProgrami = strBilgisayarProgrami;
        }
        //
        //
        public BilgisayarProgramlari(string strBilgisayarProgrami)
        {
            this._strBilgisayarProgrami = strBilgisayarProgrami;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkBilgisayarProgramiID
        {
            get
            {
                return this._pkBilgisayarProgramiID;
            }
        }
        //
        //
        public string strBilgisayarProgrami
        {
            get
            {
                return this._strBilgisayarProgrami;
            }
            set
            {
                this._strBilgisayarProgrami = value;
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
            return _strBilgisayarProgrami;
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
                SqlCommand cmd = new SqlCommand("sp_BilgisayarProgramiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strBilgisayarProgrami", SqlDbType.NVarChar, 50).Value = this._strBilgisayarProgrami;
                cmd.Parameters.Add("@pkBilgisayarProgramiID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkBilgisayarProgramiID = Convert.ToByte(cmd.Parameters["@pkBilgisayarProgramiID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_BilgisayarProgramiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBilgisayarProgramiID", SqlDbType.TinyInt).Value = this._pkBilgisayarProgramiID;
                cmd.Parameters.Add("@strBilgisayarProgrami", SqlDbType.NVarChar, 50).Value = this._strBilgisayarProgrami;
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
                SqlCommand cmd = new SqlCommand("sp_BilgisayarProgramiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBilgisayarProgramiID", SqlDbType.TinyInt).Value = this._pkBilgisayarProgramiID;
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
            lic.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BilgisayarProgramiGetir", conn);
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
                SqlCommand cmd = new SqlCommand("sp_BilgisayarProgramiGetir", conn);
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
