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
    public class AT_AracFirmalari : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkAracFirmaID;
        private string _strAracFirma;
        //
        //
        //
        // Constracter lar:
        //
        private AT_AracFirmalari(byte pkAracFirmaID, string strAracFirma)
        {
            this._pkAracFirmaID = pkAracFirmaID;
            this._strAracFirma = strAracFirma;
        }
        //
        //
        public AT_AracFirmalari(string strAracFirma)
        {
            this._strAracFirma = strAracFirma;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkAracFirmaID
        {
            get
            {
                return this._pkAracFirmaID;
            }
        }
        //
        //
        public string strAracFirma
        {
            get
            {
                return this._strAracFirma;
            }
            set
            {
                this._strAracFirma = value;
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
            return this._strAracFirma;
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
                SqlCommand cmd = new SqlCommand("sp_AT_AracFirmaEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strAracFirma", SqlDbType.NVarChar, 10).Value = this._strAracFirma;
                cmd.Parameters.Add("@pkAracFirmaID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkAracFirmaID = Convert.ToByte(cmd.Parameters["@pkAracFirmaID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_AT_AracFirmaGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAracFirmaID", SqlDbType.TinyInt).Value = this._pkAracFirmaID;
                cmd.Parameters.Add("@strAracFirma", SqlDbType.NVarChar, 10).Value = this._strAracFirma;
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
                SqlCommand cmd = new SqlCommand("sp_AT_AracFirmaSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAracFirmaID", SqlDbType.TinyInt).Value = this._pkAracFirmaID;
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

                SqlCommand cmd = new SqlCommand("sp_AT_AracFirmaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_AracFirmalari(Convert.ToByte(dr[0]), dr[1].ToString()));
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
