using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class BildigiBilgisayarProgramlari : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkBildigiBilgisayarProgramiID;
        private int _intBasvuruID;
        private byte _tintBilgisayarProgramiID;
        //
        //
        //
        // Constracter lar:
        //
        private BildigiBilgisayarProgramlari(int pkBildigiBilgisayarProgramiID, int intBasvuruID, byte tintBilgisayarProgramiID)
        {
            this._pkBildigiBilgisayarProgramiID = pkBildigiBilgisayarProgramiID;
            this._intBasvuruID = intBasvuruID;
            this._tintBilgisayarProgramiID = tintBilgisayarProgramiID;
        }
        //
        //
        public BildigiBilgisayarProgramlari(int intBasvuruID, byte tintBilgisayarProgramiID)
        {
            this._intBasvuruID = intBasvuruID;
            this._tintBilgisayarProgramiID = tintBilgisayarProgramiID;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkBildigiBilgisayarProgramiID
        {
            get
            {
                return this._pkBildigiBilgisayarProgramiID;
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
        public byte tintBilgisayarProgramiID
        {
            get
            {
                return this._tintBilgisayarProgramiID;
            }
            set
            {
                this._tintBilgisayarProgramiID = value;
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
                SqlCommand cmd = new SqlCommand("sp_BildigiBilgisayarProgramiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintBilgisayarProgramiID", SqlDbType.TinyInt).Value = this._tintBilgisayarProgramiID;
                cmd.Parameters.Add("@pkBildigiBilgisayarProgramiID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkBildigiBilgisayarProgramiID = Convert.ToInt32(cmd.Parameters["@pkBildigiBilgisayarProgramiID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_BildigiBilgisayarProgramiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBildigiBilgisayarProgramiID", SqlDbType.Int).Value = this._pkBildigiBilgisayarProgramiID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintBilgisayarProgramiID", SqlDbType.TinyInt).Value = this._tintBilgisayarProgramiID;
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
                SqlCommand cmd = new SqlCommand("sp_BildigiBilgisayarProgramiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBildigiBilgisayarProgramiID", SqlDbType.Int).Value = this._pkBildigiBilgisayarProgramiID;
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

                SqlCommand cmd = new SqlCommand("sp_BildigiBilgisayarProgramiGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new BildigiBilgisayarProgramlari(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToByte(dr[2])));
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
                SqlCommand cmd = new SqlCommand("sp_BildigiBilgisayarProgramiGetir", conn);
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
        //
        //
        public static void GetObject(DataTable dt, int BasvuruID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BildigiBilgisayarProgramiGetirByBasvuruID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = BasvuruID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow dtrow = dt.NewRow();
                        dtrow[0] = dr[0].ToString();
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
