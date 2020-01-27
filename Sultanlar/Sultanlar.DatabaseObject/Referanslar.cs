using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Referanslar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkReferansID;
        private int _intBasvuruID;
        private string _strReferansAdi;
        private string _strReferansSirketi;
        private string _strReferansGorevi;
        private string _strReferansTelefonu;
        //
        //
        //
        // Constracter lar:
        //
        private Referanslar(int pkReferansID, int intBasvuruID, string strReferansAdi, string strReferansSirketi, string strReferansGorevi, string strReferansTelefonu)
        {
            this._pkReferansID = pkReferansID;
            this._intBasvuruID = intBasvuruID;
            this._strReferansAdi = strReferansAdi;
            this._strReferansSirketi = strReferansSirketi;
            this._strReferansGorevi = strReferansGorevi;
            this._strReferansTelefonu = strReferansTelefonu;
        }
        //
        //
        public Referanslar(int intBasvuruID, string strReferansAdi, string strReferansSirketi, string strReferansGorevi, string strReferansTelefonu)
        {
            this._intBasvuruID = intBasvuruID;
            this._strReferansAdi = strReferansAdi;
            this._strReferansSirketi = strReferansSirketi;
            this._strReferansGorevi = strReferansGorevi;
            this._strReferansTelefonu = strReferansTelefonu;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkReferansID
        {
            get
            {
                return this._pkReferansID;
            }
        }
        //
        //
        public int intBasvuruID
        {
            get
            {
                return this._intBasvuruID;
            }
            set
            {
                this._intBasvuruID = value;
            }
        }
        //
        //
        public string strReferansAdi
        {
            get
            {
                return this._strReferansAdi;
            }
            set
            {
                this._strReferansAdi = value;
            }
        }
        //
        //
        public string strReferansSirketi
        {
            get
            {
                return this._strReferansSirketi;
            }
            set
            {
                this._strReferansSirketi = value;
            }
        }
        //
        //
        public string strReferansGorevi
        {
            get
            {
                return this._strReferansGorevi;
            }
            set
            {
                this._strReferansGorevi = value;
            }
        }
        //
        //
        public string strReferansTelefonu
        {
            get
            {
                return this._strReferansTelefonu;
            }
            set
            {
                this._strReferansTelefonu = value;
            }
        }
        //
        //
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
                SqlCommand cmd = new SqlCommand("sp_ReferansEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strReferansAdi", SqlDbType.NVarChar, 50).Value = this._strReferansAdi;
                cmd.Parameters.Add("@strReferansSirketi", SqlDbType.NVarChar, 100).Value = this._strReferansSirketi;
                cmd.Parameters.Add("@strReferansGorevi", SqlDbType.NVarChar, 50).Value = this._strReferansGorevi;
                cmd.Parameters.Add("@strReferansTelefonu", SqlDbType.VarChar, 15).Value = this._strReferansTelefonu;
                cmd.Parameters.Add("@pkReferansID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkReferansID = Convert.ToInt32(cmd.Parameters["@pkReferansID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_ReferansGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkReferansID", SqlDbType.Int).Value = this._pkReferansID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strReferansAdi", SqlDbType.NVarChar, 50).Value = this._strReferansAdi;
                cmd.Parameters.Add("@strReferansSirketi", SqlDbType.NVarChar, 100).Value = this._strReferansSirketi;
                cmd.Parameters.Add("@strReferansGorevi", SqlDbType.NVarChar, 50).Value = this._strReferansGorevi;
                cmd.Parameters.Add("@strReferansTelefonu", SqlDbType.VarChar, 15).Value = this._strReferansTelefonu;
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
                SqlCommand cmd = new SqlCommand("sp_ReferansSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkReferansID", SqlDbType.Int).Value = this._pkReferansID;
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
        public static void GetObject(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_ReferansGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Referanslar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_ReferansGetir", conn);
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
                        dtrow[3] = dr[3].ToString();
                        dtrow[4] = dr[4].ToString();
                        dtrow[5] = dr[5].ToString();
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
        //
        //
        public static void GetObject(DataTable dt, int BasvuruID)
        {
            dt.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_ReferansGetirByBasvuruID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = BasvuruID;
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
