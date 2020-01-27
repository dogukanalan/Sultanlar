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
    public class TedarikciResim : ISultanlar, IDisposable
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
        public TedarikciResim(int Sira, int ITEMREF, int intResimID, DateTime dtEklenme, string strEkleyen)
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_TedarikciResimEkle", conn);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_TedarikciResimGuncelle", conn);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_TedarikciResimSil", conn);
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_TedarikciResimGetir", conn);
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
                        List.Add(new TedarikciResim(sira, Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToDateTime(dr[2]), dr[3].ToString()));
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_TedarikciResimGetir", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_TedarikciResimGetir", conn);
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
        public static int GetResimID(int ITEMREF) // son eklenen resim
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_TedarikciResimIDGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = Convert.ToInt32(obj);
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
