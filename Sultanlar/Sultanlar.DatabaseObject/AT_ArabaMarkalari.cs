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
    public class AT_ArabaMarkalari : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private short _pkArabaMarkaID;
        private string _strArabaMarka;
        //
        //
        //
        // Constracter lar:
        //
        private AT_ArabaMarkalari(short pkArabaMarkaID, string strArabaMarka)
        {
            this._pkArabaMarkaID = pkArabaMarkaID;
            this._strArabaMarka = strArabaMarka;
        }
        //
        //
        public AT_ArabaMarkalari(string strArabaMarka)
        {
            this._strArabaMarka = strArabaMarka;
        }
        //
        //
        //
        // Özellikler:
        //
        public short pkArabaMarkaID
        {
            get
            {
                return this._pkArabaMarkaID;
            }
        }
        //
        //
        public string strArabaMarka
        {
            get
            {
                return this._strArabaMarka;
            }
            set
            {
                this._strArabaMarka = value;
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
            return this._strArabaMarka;
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaMarkaEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strArabaMarka", SqlDbType.NVarChar).Value = this._strArabaMarka;
                cmd.Parameters.Add("@pkArabaMarkaID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkArabaMarkaID = Convert.ToInt16(cmd.Parameters["@pkArabaMarkaID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaMarkaGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArabaMarkaID", SqlDbType.TinyInt).Value = this._pkArabaMarkaID;
                cmd.Parameters.Add("@strArabaMarka", SqlDbType.NVarChar).Value = this._strArabaMarka;
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaMarkaSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArabaMarkaID", SqlDbType.TinyInt).Value = this._pkArabaMarkaID;
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

                SqlCommand cmd = new SqlCommand("sp_AT_ArabaMarkaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_ArabaMarkalari(Convert.ToInt16(dr[0]), dr[1].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_ArabaMarkaGetir", conn);
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
