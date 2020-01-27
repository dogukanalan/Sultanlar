using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class KrediKartlari : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkKrediKartiID;
        private int _intBasvuruID;
        private string _strKrediKarti;
        private string _strKrediKartiLimiti;
        //
        //
        //
        // Constracter lar:
        //
        private KrediKartlari(int pkKrediKartiID, int intBasvuruID, string strKrediKarti, string strKrediKartiLimiti)
        {
            this._pkKrediKartiID = pkKrediKartiID;
            this._intBasvuruID = intBasvuruID;
            this._strKrediKarti = strKrediKarti;
            this._strKrediKartiLimiti = strKrediKartiLimiti;
        }
        //
        //
        public KrediKartlari(int intBasvuruID, string strKrediKarti, string strKrediKartiLimiti)
        {
            this._intBasvuruID = intBasvuruID;
            this._strKrediKarti = strKrediKarti;
            this._strKrediKartiLimiti = strKrediKartiLimiti;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkKrediKartiID
        {
            get
            {
                return this._pkKrediKartiID;
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
        public string strKrediKarti
        {
            get
            {
                return this._strKrediKarti;
            }
            set
            {
                this._strKrediKarti = value;
            }
        }
        //
        //
        public string strKrediKartiLimiti
        {
            get
            {
                return this._strKrediKartiLimiti;
            }
            set
            {
                this._strKrediKartiLimiti = value;
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
                SqlCommand cmd = new SqlCommand("sp_KrediKartiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strKrediKarti", SqlDbType.NVarChar, 30).Value = this._strKrediKarti;
                cmd.Parameters.Add("@strKrediKartiLimiti", SqlDbType.NVarChar, 20).Value = this._strKrediKartiLimiti;
                cmd.Parameters.Add("@pkKrediKartiID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkKrediKartiID = Convert.ToInt32(cmd.Parameters["@pkKrediKartiID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_KrediKartiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkKrediKartiID", SqlDbType.Int).Value = this._pkKrediKartiID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strKrediKarti", SqlDbType.NVarChar, 20).Value = this._strKrediKarti;
                cmd.Parameters.Add("@strKrediKartiLimiti", SqlDbType.NVarChar, 300).Value = this._strKrediKartiLimiti;
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
                SqlCommand cmd = new SqlCommand("sp_KrediKartiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkKrediKartiID", SqlDbType.Int).Value = this._pkKrediKartiID;
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

                SqlCommand cmd = new SqlCommand("sp_KrediKartiGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new KrediKartlari(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_KrediKartiGetir", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("sp_KrediKartiGetirByBasvuruID", conn);
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
