using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_Bolgeler
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private bool _blPasif;
        private string _strBolge;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_Bolgeler()
        {

        }
        //
        //
        private AT2_Bolgeler(int pkID, bool blPasif, string strBolge)
        {
            this._pkID = pkID;
            this._blPasif = blPasif;
            this._strBolge = strBolge;
        }
        //
        //
        public AT2_Bolgeler(bool blPasif, string strBolge)
        {
            this._blPasif = blPasif;
            this._strBolge = strBolge;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public string strBolge { get { return this._strBolge; } set { this._strBolge = value; } }
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
            return this._strBolge;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_Bolgeler] (blPasif,[strBolge]) VALUES (@blPasif,@strBolge) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strBolge", SqlDbType.NVarChar).Value = this._strBolge;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_Bolgeler] SET blPasif = @blPasif, [strBolge] = @strBolge WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strBolge", SqlDbType.NVarChar).Value = this._strBolge;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_Bolgeler] WHERE pkID = @pkID", conn);
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

                SqlCommand cmd = new SqlCommand("SELECT [pkID],blPasif,[strBolge] FROM [tblAT2_Bolgeler] WHERE blPasif = @blPasif ORDER BY strBolge", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_Bolgeler(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],blPasif,[strBolge] FROM [tblAT2_Bolgeler] WHERE blPasif = 'False' ORDER BY strBolge", conn);
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
        public static AT2_Bolgeler GetObject(int ID)
        {
            AT2_Bolgeler donendeger = new AT2_Bolgeler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],blPasif,[strBolge] FROM [tblAT2_Bolgeler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger = new AT2_Bolgeler(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString());
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
