using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.DatabaseObject
{
    public class SatTemMusteriTalepleriLog : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _SMREF;
        private int _SLSREF;
        private int _intMusteriID;
        private bool _blCikar;
        private DateTime _dtZaman;
        private int _ESLSREF;
        private string _strTerminal;
        //
        //
        //
        // Constracter lar:
        //
        private SatTemMusteriTalepleriLog(long pkID, int SMREF, int SLSREF, int intMusteriID, bool blCikar, DateTime dtZaman, 
            int ESLSREF, string strTerminal)
        {
            this._pkID = pkID;
            this._SMREF = SMREF;
            this._SLSREF = SLSREF;
            this._intMusteriID = intMusteriID;
            this._blCikar = blCikar;
            this._dtZaman = dtZaman;
            this._ESLSREF = ESLSREF;
            this._strTerminal = strTerminal;
        }
        //
        //
        public SatTemMusteriTalepleriLog(int SMREF, int SLSREF, int intMusteriID, bool blCikar, DateTime dtZaman,
            int ESLSREF, string strTerminal)
        {
            this._SMREF = SMREF;
            this._SLSREF = SLSREF;
            this._intMusteriID = intMusteriID;
            this._blCikar = blCikar;
            this._dtZaman = dtZaman;
            this._ESLSREF = ESLSREF;
            this._strTerminal = strTerminal;
        }
        //
        //
        public SatTemMusteriTalepleriLog()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int SLSREF { get { return this._SLSREF; } set { this._SLSREF = value; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public bool blCikar { get { return this._blCikar; } set { this._blCikar = value; } }
        public DateTime dtZaman { get { return this._dtZaman; } set { this._dtZaman = value; } }
        public int ESLSREF { get { return this._ESLSREF; } set { this._ESLSREF = value; } }
        public string strTerminal { get { return this._strTerminal; } set { this._strTerminal = value; } }
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
            return SatisTemsilcileri.GetObjectBySLSREF(this._SLSREF) + " " + this._dtZaman.ToShortDateString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object MusteriID = DBNull.Value;
            object eslsref = DBNull.Value;
            object Terminal = DBNull.Value;
            if (this._intMusteriID != 0)
                MusteriID = this._intMusteriID;
            if (this._ESLSREF != 0)
                eslsref = this._ESLSREF;
            if (this._strTerminal != "")
                Terminal = this._strTerminal;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-SatTemMusteriTalepleriLog] (SMREF, SLSREF, intMusteriID, blCikar, dtZaman, ESLSREF, strTerminal) VALUES (@SMREF, @SLSREF, @intMusteriID, @blCikar, @dtZaman, @ESLSREF, @strTerminal) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                cmd.Parameters.Add("@blCikar", SqlDbType.Bit).Value = this._blCikar;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this._dtZaman;
                cmd.Parameters.Add("@ESLSREF", SqlDbType.Int).Value = eslsref;
                cmd.Parameters.Add("@strTerminal", SqlDbType.NVarChar).Value = Terminal;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("UPDATE [Web-SatTemMusteriTalepleriLog] SET intMusteriID = @intMusteriID, dtZaman = @dtZaman, blCikar = @blCikar WHERE SMREF = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@blCikar", SqlDbType.Bit).Value = this._blCikar;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this._dtZaman;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-SatTemMusteriTalepleriLog] WHERE pkID = @pkID", conn);
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkID,SMREF,SLSREF,intMusteriID,blCikar,dtZaman,ESLSREF,strTerminal FROM [Web-SatTemMusteriTalepleriLog] ORDER BY pkID DESC", conn);
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
        public static SatTemMusteriTalepleriLog GetObject(int SMREF, int SLSREF)
        {
            SatTemMusteriTalepleriLog stmtl = new SatTemMusteriTalepleriLog();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,SMREF,SLSREF,intMusteriID,blCikar,dtZaman,ESLSREF,strTerminal FROM [Web-SatTemMusteriTalepleriLog] WHERE SLSREF = @SLSREF AND @SMREF = SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        stmtl._pkID = Convert.ToInt64(dr[0]);
                        stmtl._SMREF = SMREF;
                        stmtl._SLSREF = SLSREF;
                        stmtl._intMusteriID = Convert.ToInt32(dr[3]);
                        stmtl._blCikar = dr[4] != DBNull.Value ? Convert.ToBoolean(dr[4]) : false;
                        stmtl._dtZaman = Convert.ToDateTime(dr[5]);
                        stmtl._ESLSREF = dr[6] != DBNull.Value ? Convert.ToInt32(dr[6]) : 0;
                        stmtl._strTerminal = dr[7] != DBNull.Value ? dr[5].ToString() : "";

                        if (dr[1] == DBNull.Value)
                            stmtl._SMREF = 0;
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

            return stmtl;
        }
    }
}
