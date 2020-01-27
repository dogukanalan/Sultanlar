using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Kurslar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkKursID;
        private int _intBasvuruID;
        private string _strKursKonu;
        private string _strKursVerenKurulus;
        private string _strKursSure;
        private string _strKursYil;
        //
        //
        //
        // Constracter lar:
        //
        private Kurslar(int pkKursID, int intBasvuruID, string strKursKonu, string strKursVerenKurulus, string strKursSure, string strKursYil)
        {
            this._pkKursID = pkKursID;
            this._intBasvuruID = intBasvuruID;
            this._strKursKonu = strKursKonu;
            this._strKursVerenKurulus = strKursVerenKurulus;
            this._strKursSure = strKursSure;
            this._strKursYil = strKursYil;
        }
        //
        //
        public Kurslar(int intBasvuruID, string strKursKonu, string strKursVerenKurulus, string strKursSure, string strKursYil)
        {
            this._intBasvuruID = intBasvuruID;
            this._strKursKonu = strKursKonu;
            this._strKursVerenKurulus = strKursVerenKurulus;
            this._strKursSure = strKursSure;
            this._strKursYil = strKursYil;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkKursID
        {
            get
            {
                return this._pkKursID;
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
        public string strKursKonu
        {
            get
            {
                return this._strKursKonu;
            }
            set
            {
                this._strKursKonu = value;
            }
        }
        //
        //
        public string strKursVerenKurulus
        {
            get
            {
                return this._strKursVerenKurulus;
            }
            set
            {
                this._strKursVerenKurulus = value;
            }
        }
        //
        //
        public string strKursSure
        {
            get
            {
                return this._strKursSure;
            }
            set
            {
                this._strKursSure = value;
            }
        }
        //
        //
        public string strKursYil
        {
            get
            {
                return this._strKursYil;
            }
            set
            {
                this._strKursYil = value;
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
                SqlCommand cmd = new SqlCommand("sp_KursEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strKursKonu", SqlDbType.NVarChar, 80).Value = this._strKursKonu;
                cmd.Parameters.Add("@strKursVerenKurulus", SqlDbType.NVarChar, 60).Value = this._strKursVerenKurulus;
                cmd.Parameters.Add("@strKursSure", SqlDbType.NVarChar, 20).Value = this._strKursSure;
                cmd.Parameters.Add("@strKursYil", SqlDbType.VarChar, 4).Value = this._strKursYil;
                cmd.Parameters.Add("@pkKursID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkKursID = Convert.ToInt32(cmd.Parameters["@pkKursID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_KursGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkKursID", SqlDbType.Int).Value = this._pkKursID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strKursKonu", SqlDbType.NVarChar, 80).Value = this._strKursKonu;
                cmd.Parameters.Add("@strKursVerenKurulus", SqlDbType.NVarChar, 60).Value = this._strKursVerenKurulus;
                cmd.Parameters.Add("@strKursSure", SqlDbType.NVarChar, 20).Value = this._strKursSure;
                cmd.Parameters.Add("@strKursYil", SqlDbType.VarChar, 4).Value = this._strKursYil;
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
                SqlCommand cmd = new SqlCommand("sp_KursSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkKursID", SqlDbType.Int).Value = this._pkKursID;
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

                SqlCommand cmd = new SqlCommand("sp_KursGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Kurslar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_KursGetir", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("sp_KurslarGetirByBasvuruID", conn);
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
