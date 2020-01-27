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
    public class AT_ArabaKimeAit : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkArabaKimeAitID;
        private string _strArabaKimeAit;
        //
        //
        //
        // Constracter lar:
        //
        private AT_ArabaKimeAit(byte pkArabaKimeAitID, string strArabaKimeAit)
        {
            this._pkArabaKimeAitID = pkArabaKimeAitID;
            this._strArabaKimeAit = strArabaKimeAit;
        }
        //
        //
        public AT_ArabaKimeAit(string strArabaKimeAit)
        {
            this._strArabaKimeAit = strArabaKimeAit;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkArabaKimeAitID
        {
            get
            {
                return this._pkArabaKimeAitID;
            }
        }
        //
        //
        public string strArabaKimeAit
        {
            get
            {
                return this._strArabaKimeAit;
            }
            set
            {
                this._strArabaKimeAit = value;
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
            return this._strArabaKimeAit;
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaKimeAitEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strArabaKimeAit", SqlDbType.NVarChar).Value = this._strArabaKimeAit;
                cmd.Parameters.Add("@pkArabaKimeAitID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkArabaKimeAitID = Convert.ToByte(cmd.Parameters["@pkArabaKimeAitID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaKimeAitGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArabaKimeAitID", SqlDbType.TinyInt).Value = this._pkArabaKimeAitID;
                cmd.Parameters.Add("@strArabaKimeAit", SqlDbType.NVarChar).Value = this._strArabaKimeAit;
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaKimeAitSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArabaKimeAitID", SqlDbType.TinyInt).Value = this._pkArabaKimeAitID;
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

                SqlCommand cmd = new SqlCommand("sp_AT_ArabaKimeAitGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_ArabaKimeAit(Convert.ToByte(dr[0]), dr[1].ToString()));
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
