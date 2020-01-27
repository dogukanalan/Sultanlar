using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SatTemMusteriTalepleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _SMREF;
        private int _SLSREF;
        private bool _blCikar;
        private bool _blSefOnay;
        private int _ESLSREF;
        private long _bintLogID;
        //
        //
        //
        // Constracter lar:
        //
        private SatTemMusteriTalepleri(int SMREF, int SLSREF, bool blCikar, bool blSefOnay, int ESLSREF, long bintLogID)
        {
            this._SMREF = SMREF;
            this._SLSREF = SLSREF;
            this._blCikar = blCikar;
            this._blSefOnay = blSefOnay;
            this._ESLSREF = ESLSREF;
            this._bintLogID = bintLogID;
        }
        //
        //
        public SatTemMusteriTalepleri(int SMREF, int SLSREF, bool blCikar, int ESLSREF, long bintLogID)
        {
            this._SMREF = SMREF;
            this._SLSREF = SLSREF;
            this._blCikar = blCikar;
            this._blSefOnay = false;
            this._ESLSREF = ESLSREF;
            this._bintLogID = bintLogID;
        }
        //
        //
        private SatTemMusteriTalepleri()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int SLSREF { get { return this._SLSREF; } set { this._SLSREF = value; } }
        public bool blCikar { get { return this._blCikar; } set { this._blCikar = value; } }
        public bool blSefOnay { get { return this._blSefOnay; } set { this._blSefOnay = value; } }
        public int ESLSREF { get { return this._ESLSREF; } set { this._ESLSREF = value; } }
        public long bintLogID { get { return this._bintLogID; } set { this._bintLogID = value; } }
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
            return this._SMREF.ToString() + " " + this._SLSREF.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object eslsref = DBNull.Value;
            object logid = DBNull.Value;
            if (this._ESLSREF != 0)
                eslsref = this._ESLSREF;
            if (this._bintLogID != 0)
                logid = this._bintLogID;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-SatTemMusteriTalepleri] (SMREF, SLSREF, blCikar, blSefOnay, ESLSREF, bintLogID) VALUES (@SMREF, @SLSREF, @blCikar, @blSefOnay, @ESLSREF, @bintLogID)", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@blCikar", SqlDbType.Bit).Value = this._blCikar;
                cmd.Parameters.Add("@blSefOnay", SqlDbType.Bit).Value = this._blSefOnay;
                cmd.Parameters.Add("@ESLSREF", SqlDbType.Int).Value = eslsref;
                cmd.Parameters.Add("@bintLogID", SqlDbType.Int).Value = logid;
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
                SqlCommand cmd = new SqlCommand("UPDATE [Web-SatTemMusteriTalepleri] SET blCikar = @blCikar, blSefOnay = @blSefOnay WHERE SMREF = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@blCikar", SqlDbType.Bit).Value = this._blCikar;
                cmd.Parameters.Add("@blSefOnay", SqlDbType.Bit).Value = this._blSefOnay;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-SatTemMusteriTalepleri] WHERE SMREF = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
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
        public static void GetObjects(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SMREF,SLSREF,blCikar,blSefOnay,ESLSREF,bintLogID FROM [Web-SatTemMusteriTalepleri] WHERE SLSREF = @SLSREF", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        public static SatTemMusteriTalepleri GetObject(int SMREF, int SLSREF)
        {
            SatTemMusteriTalepleri stmt = new SatTemMusteriTalepleri();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SMREF,SLSREF,blCikar,blSefOnay,ESLSREF,bintLogID FROM [Web-SatTemMusteriTalepleri] WHERE SLSREF = @SLSREF AND @SMREF = SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        stmt._SMREF = SMREF;
                        stmt._SLSREF = SLSREF;
                        stmt._blCikar = dr[2] != DBNull.Value ? Convert.ToBoolean(dr[2]) : false;
                        stmt._blSefOnay = dr[3] != DBNull.Value ? Convert.ToBoolean(dr[3]) : false;
                        stmt._ESLSREF = dr[4] != DBNull.Value ? Convert.ToInt32(dr[4]) : 0;
                        stmt._bintLogID = dr[5] != DBNull.Value ? Convert.ToInt64(dr[5]) : 0;

                        if (dr[2] == DBNull.Value)
                            stmt._SMREF = 0;
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

            return stmt;
        }
    }
}
