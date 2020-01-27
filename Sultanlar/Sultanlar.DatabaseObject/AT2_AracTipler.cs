using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_AracTipler
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private bool _blPasif;
        private string _strAracTipi;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_AracTipler()
        {

        }
        //
        //
        private AT2_AracTipler(int pkID, bool blPasif, string strAracTipi)
        {
            this._pkID = pkID;
            this._blPasif = blPasif;
            this._strAracTipi = strAracTipi;
        }
        //
        //
        public AT2_AracTipler(bool blPasif, string strAracTipi)
        {
            this._blPasif = blPasif;
            this._strAracTipi = strAracTipi;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public string strAracTip { get { return this._strAracTipi; } set { this._strAracTipi = value; } }
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
            return this._strAracTipi;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_AracTipler] (blPasif,[strAracTipi]) VALUES (@blPasif,@strAracTipi) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strAracTipi", SqlDbType.NVarChar).Value = this._strAracTipi;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_AracTipler] SET blPasif = @blPasif, [strAracTipi] = @strAracTipi WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strAracTipi", SqlDbType.NVarChar).Value = this._strAracTipi;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_AracTipler] WHERE pkID = @pkID", conn);
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

                SqlCommand cmd = new SqlCommand("SELECT [pkID],blPasif,[strAracTipi] FROM [tblAT2_AracTipler] WHERE blPasif = @blPasif ORDER BY strAracTipi", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_AracTipler(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],blPasif,[strAracTipi] FROM [tblAT2_AracTipler] WHERE blPasif = @blPasif ORDER BY strAracTipi", conn);
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
        public static AT2_AracTipler GetObject(int ID)
        {
            AT2_AracTipler donendeger = new AT2_AracTipler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],blPasif,[strAracTipi] FROM [tblAT2_AracTipler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AT2_AracTipler(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString());
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
