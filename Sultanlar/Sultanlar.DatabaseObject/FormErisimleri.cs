using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject
{
    public class FormErisimleri : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private string _strTerminal;
        private DateTime _dtGirisTarih;
        private DateTime _dtCikisTarih;
        //
        //
        //
        // Constracter lar:
        //
        private FormErisimleri(long pkID, string strTerminal, DateTime dtGirisTarih, DateTime dtCikisTarih)
        {
            this._pkID = pkID;
            this._strTerminal = strTerminal;
            this._dtGirisTarih = dtGirisTarih;
            this._dtCikisTarih = dtCikisTarih;
        }
        //
        //
        public FormErisimleri(string strTerminal, DateTime dtGirisTarih, DateTime dtCikisTarih)
        {
            this._strTerminal = strTerminal;
            this._dtGirisTarih = dtGirisTarih;
            this._dtCikisTarih = dtCikisTarih;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID
        {
            get
            {
                return this._pkID;
            }
        }
        //
        //
        public string strTerminal
        {
            get
            {
                return this._strTerminal;
            }
            set
            {
                this._strTerminal = value;
            }
        }
        //
        //
        public DateTime dtGirisTarih
        {
            get
            {
                return this._dtGirisTarih;
            }
            set
            {
                this._dtGirisTarih = value;
            }
        }
        //
        //
        public DateTime dtCikisTarihi
        {
            get
            {
                return this._dtCikisTarih;
            }
            set
            {
                this._dtCikisTarih = value;
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
                object CikisTarih = DBNull.Value;

                if (this._dtCikisTarih != DateTime.MinValue)
                    CikisTarih = this._dtCikisTarih;

                SqlCommand cmd = new SqlCommand("sp_FormErisimiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strTerminal", SqlDbType.NVarChar).Value = this._strTerminal;
                cmd.Parameters.Add("@dtGirisTarih", SqlDbType.DateTime).Value = this._dtGirisTarih;
                cmd.Parameters.Add("@dtCikisTarih", SqlDbType.DateTime).Value = CikisTarih;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt64(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_FormErisimiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                cmd.Parameters.Add("@strTerminal", SqlDbType.NVarChar).Value = this._strTerminal;
                cmd.Parameters.Add("@dtGirisTarih", SqlDbType.DateTime).Value = this._dtGirisTarih;
                cmd.Parameters.Add("@dtCikisTarih", SqlDbType.DateTime).Value = this._dtCikisTarih;
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
                SqlCommand cmd = new SqlCommand("sp_FormErisimiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
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
        public static DataTable GetObject()
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_FormErisimleriGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(donendeger);
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
        //
        //
        public static FormErisimleri GetObject(long ID)
        {
            FormErisimleri donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_FormErisimiGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[3].ToString() != string.Empty)
                        {
                            donendeger = new FormErisimleri(Convert.ToInt64(dr[0]), dr[1].ToString(),
                                Convert.ToDateTime(dr[2]), Convert.ToDateTime(dr[3]));
                        }
                        else
                        {
                            donendeger = new FormErisimleri(Convert.ToInt64(dr[0]), dr[1].ToString(),
                                Convert.ToDateTime(dr[2]), DateTime.MinValue);
                        }
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

            return donendeger;
        }
        //
        //
        public static long GetIDByUserLastLogin(string Terminal)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_FormErisimiGetirByUserLastLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strTerminal", SqlDbType.NVarChar).Value = Terminal;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
