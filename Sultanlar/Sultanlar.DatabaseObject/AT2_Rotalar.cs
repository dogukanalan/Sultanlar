using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_Rotalar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intBolgeID;
        private int _intAracID;
        private bool _blPasif;
        private string _strRota;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_Rotalar()
        {

        }
        //
        //
        private AT2_Rotalar(int pkID, int intBolgeID, int intAracID, bool blPasif, string strRota)
        {
            this._pkID = pkID;
            this._intBolgeID = intBolgeID;
            this._intAracID = intAracID;
            this._blPasif = blPasif;
            this._strRota = strRota;
        }
        //
        //
        public AT2_Rotalar(int intBolgeID, int intAracID, bool blPasif, string strRota)
        {
            this._intBolgeID = intBolgeID;
            this._intAracID = intAracID;
            this._blPasif = blPasif;
            this._strRota = strRota;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intBolgeID { get { return this._intBolgeID; } set { this._intBolgeID = value; } }
        public int intAracID { get { return this._intAracID; } set { this._intAracID = value; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public string strRota { get { return this._strRota; } set { this._strRota = value; } }
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
            return this._strRota;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_Rotalar] ([intBolgeID],[intAracID],[blPasif],[strRota]) VALUES (@intBolgeID,@intAracID,@blPasif,@strRota) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intBolgeID", SqlDbType.Int).Value = this._intBolgeID;
                cmd.Parameters.Add("@intAracID", SqlDbType.Int).Value = this._intAracID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strRota", SqlDbType.NVarChar).Value = this._strRota;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_Rotalar] SET [intBolgeID] = @intBolgeID,[intAracID] = @intAracID,[blPasif] = @blPasif,[strRota] = @strRota WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intBolgeID", SqlDbType.Int).Value = this._intBolgeID;
                cmd.Parameters.Add("@intAracID", SqlDbType.Int).Value = this._intAracID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strRota", SqlDbType.NVarChar).Value = this._strRota;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_Rotalar] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
        public static void GetObjects(IList List, bool Pasif, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intBolgeID],[intAracID],[blPasif],[strRota] FROM [tblAT2_Rotalar] WHERE blPasif = @blPasif ORDER BY strRota", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_Rotalar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            Convert.ToBoolean(dr[3]), dr[4].ToString()));
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
        public static void GetObjects(DataTable dt, bool Pasif)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [tblAT2_Rotalar].[pkID],[intBolgeID],strBolge,[intAracID],[tblAT2_Rotalar].[blPasif],[strRota] FROM [tblAT2_Rotalar] INNER JOIN tblAT2_Bolgeler ON [tblAT2_Rotalar].[intBolgeID] = tblAT2_Bolgeler.pkID WHERE [tblAT2_Rotalar].blPasif = @blPasif ORDER BY strRota", conn);
                da.SelectCommand.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
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
        public static AT2_Rotalar GetObject(int ID)
        {
            AT2_Rotalar donendeger = new AT2_Rotalar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intBolgeID],[intAracID],[blPasif],[strRota] FROM [tblAT2_Rotalar] WHERE [pkID] = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger = new AT2_Rotalar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            Convert.ToBoolean(dr[3]), dr[4].ToString());
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
    }
}
