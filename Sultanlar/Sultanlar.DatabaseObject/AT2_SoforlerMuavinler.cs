using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_SoforlerMuavinler
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intLojistikFirmaID;
        private bool _blPasif;
        private bool _blMuavin;
        private string _strAd;
        private string _strSoyad;
        private string _strTelefon;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_SoforlerMuavinler(int pkID, int intLojistikFirmaID, bool blPasif, bool blMuavin, string strAd, string strSoyad, string strTelefon)
        {
            this._pkID = pkID;
            this._intLojistikFirmaID = intLojistikFirmaID;
            this._blPasif = blPasif;
            this._blMuavin = blMuavin;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._strTelefon = strTelefon;
        }
        //
        //
        public AT2_SoforlerMuavinler(int intLojistikFirmaID, bool blPasif, bool blMuavin, string strAd, string strSoyad, string strTelefon)
        {
            this._intLojistikFirmaID = intLojistikFirmaID;
            this._blPasif = blPasif;
            this._blMuavin = blMuavin;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._strTelefon = strTelefon;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intLojistikFirmaID { get { return this._intLojistikFirmaID; } set { this._intLojistikFirmaID = value; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public bool blMuavin { get { return this._blMuavin; } set { this._blMuavin = value; } }
        public string strAd { get { return this._strAd; } set { this._strAd = value; } }
        public string strSoyad { get { return this._strSoyad; } set { this._strSoyad = value; } }
        public string strTelefon { get { return this._strTelefon; } set { this._strTelefon = value; } }
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
            return this._strAd + " " + this._strSoyad;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_SoforlerMuavinler] (intLojistikFirmaID,blPasif,[blMuavin],[strAd],[strSoyad],[strTelefon]) VALUES (@intLojistikFirmaID,@blPasif,@blMuavin,@strAd,@strSoyad,@strTelefon) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intLojistikFirmaID", SqlDbType.Int).Value = this._intLojistikFirmaID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@blMuavin", SqlDbType.Bit).Value = this._blMuavin;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar).Value = this._strSoyad;
                cmd.Parameters.Add("@strTelefon", SqlDbType.NVarChar).Value = this._strTelefon;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_SoforlerMuavinler] SET intLojistikFirmaID = @intLojistikFirmaID, blPasif = @blPasif,[blMuavin] = @blMuavin,[strAd] = @strAd,[strSoyad] = @strSoyad,[strTelefon] = @strTelefon WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intLojistikFirmaID", SqlDbType.Int).Value = this._intLojistikFirmaID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@blMuavin", SqlDbType.Bit).Value = this._blMuavin;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar).Value = this._strSoyad;
                cmd.Parameters.Add("@strTelefon", SqlDbType.NVarChar).Value = this._strTelefon;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_SoforlerMuavinler] WHERE pkID = @pkID", conn);
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
        public static void GetObjects(IList List, bool blPasif, bool Muavin, string Ad, string Soyad, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],intLojistikFirmaID,blPasif,[blMuavin],[strAd],[strSoyad],[strTelefon] FROM [tblAT2_SoforlerMuavinler] WHERE strAd LIKE '%' + @strAd + '%' AND strSoyad LIKE '%' + @strSoyad + '%' AND blPasif = @blPasif AND blMuavin = @blMuavin ORDER BY strAd,strSoyad", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = blPasif;
                cmd.Parameters.Add("@blMuavin", SqlDbType.Bit).Value = Muavin;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = Ad;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar).Value = Soyad;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_SoforlerMuavinler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), Convert.ToBoolean(dr[3]), dr[4].ToString(), dr[5].ToString(), dr[6].ToString()));
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
        public static void GetObjects(DataTable dt, bool blPasif, bool Muavin)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],intLojistikFirmaID,blPasif,[blMuavin],[strAd],[strSoyad],[strTelefon] FROM [tblAT2_SoforlerMuavinler] WHERE blPasif = @blPasif AND blMuavin = @blMuavin ORDER BY strAd,strSoyad", conn);
                da.SelectCommand.Parameters.Add("@blPasif", SqlDbType.Bit).Value = blPasif;
                da.SelectCommand.Parameters.Add("@blMuavin", SqlDbType.Bit).Value = Muavin;
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
        public static void GetObjectsByFirmaID(IList List, bool blPasif, bool Muavin, int FirmaID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],intLojistikFirmaID,blPasif,[blMuavin],[strAd],[strSoyad],[strTelefon] FROM [tblAT2_SoforlerMuavinler] WHERE intFirmaID = @intFirmaID AND blPasif = @blPasif AND blMuavin = @blMuavin ORDER BY strAd,strSoyad", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = blPasif;
                cmd.Parameters.Add("@blMuavin", SqlDbType.Bit).Value = Muavin;
                cmd.Parameters.Add("@intFirmaID", SqlDbType.Int).Value = FirmaID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_SoforlerMuavinler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), Convert.ToBoolean(dr[3]), dr[4].ToString(), dr[5].ToString(), dr[6].ToString()));
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
