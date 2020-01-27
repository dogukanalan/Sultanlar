using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_Personeller
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private bool _blPasif;
        private string _strPersonel;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_Personeller()
        {

        }
        //
        //
        private AT2_Personeller(int pkID, bool blPasif, string strPersonel)
        {
            this._pkID = pkID;
            this._blPasif = blPasif;
            this._strPersonel = strPersonel;
        }
        //
        //
        public AT2_Personeller(bool blPasif, string strPersonel)
        {
            this._blPasif = blPasif;
            this._strPersonel = strPersonel;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public string strPersonel { get { return this._strPersonel; } set { this._strPersonel = value; } }
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
            return this._strPersonel;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_Personeller] ([blPasif],[strPersonel]) VALUES (@blPasif,@strPersonel) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strPersonel", SqlDbType.NVarChar).Value = this._strPersonel;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_Personeller] SET [blPasif] = @blPasif,[strPersonel] = @strPersonel WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strPersonel", SqlDbType.NVarChar).Value = this._strPersonel;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_Personeller] WHERE pkID = @pkID", conn);
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

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[blPasif],[strPersonel] FROM [tblAT2_Personeller] WHERE blPasif = @blPasif ORDER BY strPersonel", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_Personeller(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[blPasif],[strPersonel] FROM [tblAT2_Personeller] WHERE blPasif = @blPasif ORDER BY strPersonel", conn);
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
        public static AT2_Personeller GetObject(int ID)
        {
            AT2_Personeller donendeger = new AT2_Personeller();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[blPasif],[strPersonel] FROM [tblAT2_Personeller] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AT2_Personeller(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString());
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
