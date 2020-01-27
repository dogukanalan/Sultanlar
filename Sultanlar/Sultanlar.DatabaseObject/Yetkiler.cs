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
    public class Yetkiler
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkYetkiID;
        private short _sintFormID;
        private string _strKAdi;
        //
        //
        //
        // Constracter lar:
        //
        private Yetkiler(int pkYetkiID, short sintFormID, string strKAdi)
        {
            this._pkYetkiID = pkYetkiID;
            this._sintFormID = sintFormID;
            this._strKAdi = strKAdi;
        }
        //
        //
        public Yetkiler(short sintFormID, string strKAdi)
        {
            this._sintFormID = sintFormID;
            this._strKAdi = strKAdi;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkYetkiID
        {
            get
            {
                return this._pkYetkiID;
            }
            set
            {
                this._pkYetkiID = value;
            }
        }
        //
        //
        public short sintFormID
        {
            get
            {
                return this._sintFormID;
            }
            set
            {
                this._sintFormID = value;
            }
        }
        //
        //
        public string strKAdi
        {
            get
            {
                return this._strKAdi;
            }
            set
            {
                this._strKAdi = value;
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
            return this._strKAdi;
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
                SqlCommand cmd = new SqlCommand("sp_YetkiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strKAdi", SqlDbType.NVarChar, 100).Value = this._strKAdi;
                cmd.Parameters.Add("@sintFormID", SqlDbType.SmallInt).Value = this._sintFormID;
                cmd.Parameters.Add("@pkYetkiID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkYetkiID = Convert.ToInt16(cmd.Parameters["@pkYetkiID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_YetkiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkYetkiID", SqlDbType.Int).Value = this._pkYetkiID;
                cmd.Parameters.Add("@sintFormID", SqlDbType.SmallInt).Value = this._sintFormID;
                cmd.Parameters.Add("@strKAdi", SqlDbType.NVarChar, 100).Value = this._strKAdi;
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
                SqlCommand cmd = new SqlCommand("sp_YetkiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkYetkiID", SqlDbType.Int).Value = this._pkYetkiID;
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

                SqlCommand cmd = new SqlCommand("sp_YetkiGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Yetkiler(Convert.ToInt32(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString()));
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
        public static void GetObjectByFormID(IList List, short formID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_YetkiGetirByFormID", conn);
                cmd.Parameters.Add("@sintFormID", SqlDbType.SmallInt).Value = formID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Yetkiler(Convert.ToInt32(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_YetkiGetir", conn);
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
                        dtrow[2] = dr[2].ToString();
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
