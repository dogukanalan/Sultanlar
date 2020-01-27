using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_LojistikFirmalar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private bool _blPasif;
        private string _strLojistikFirma;
        private string _strSorumlu;
        private string _strTelefon;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_LojistikFirmalar()
        {

        }
        //
        //
        private AT2_LojistikFirmalar(int pkID, bool blPasif, string strLojistikFirma, string strSorumlu, string strTelefon)
        {
            this._pkID = pkID;
            this._blPasif = blPasif;
            this._strLojistikFirma = strLojistikFirma;
            this._strSorumlu = strSorumlu;
            this._strTelefon = strTelefon;
        }
        //
        //
        public AT2_LojistikFirmalar(bool blPasif, string strLojistikFirma, string strSorumlu, string strTelefon)
        {
            this._blPasif = blPasif;
            this._strLojistikFirma = strLojistikFirma;
            this._strSorumlu = strSorumlu;
            this._strTelefon = strTelefon;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public string strLojistikFirma { get { return this._strLojistikFirma; } set { this._strLojistikFirma = value; } }
        public string strSorumlu { get { return this._strSorumlu; } set { this._strSorumlu = value; } }
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
            return this._strLojistikFirma;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_LojistikFirmalar] (blPasif,[strLojistikFirma],strSorumlu,strTelefon) VALUES (@blPasif,@strLojistikFirma,@strSorumlu,@strTelefon) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strLojistikFirma", SqlDbType.NVarChar).Value = this._strLojistikFirma;
                cmd.Parameters.Add("@strSorumlu", SqlDbType.NVarChar).Value = this._strSorumlu;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_LojistikFirmalar] SET blPasif = @blPasif, [strLojistikFirma] = @strLojistikFirma,strSorumlu = @strSorumlu, strTelefon = @strTelefon WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strLojistikFirma", SqlDbType.NVarChar).Value = this._strLojistikFirma;
                cmd.Parameters.Add("@strSorumlu", SqlDbType.NVarChar).Value = this._strSorumlu;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_LojistikFirmalar] WHERE pkID = @pkID", conn);
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

                SqlCommand cmd = new SqlCommand("SELECT [pkID],blPasif,[strLojistikFirma],strSorumlu,strTelefon FROM [tblAT2_LojistikFirmalar] WHERE blPasif = @blPasif ORDER BY [strLojistikFirma]", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_LojistikFirmalar(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],blPasif,[strLojistikFirma],strSorumlu,strTelefon FROM [tblAT2_LojistikFirmalar] WHERE blPasif = @blPasif ORDER BY [strLojistikFirma]", conn);
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
        public static AT2_LojistikFirmalar GetObject(int ID)
        {
            AT2_LojistikFirmalar donendeger = new AT2_LojistikFirmalar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],blPasif,[strLojistikFirma],strSorumlu,strTelefon FROM [KurumsalWebSAP].[dbo].[tblAT2_LojistikFirmalar] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AT2_LojistikFirmalar(Convert.ToInt32(dr[0]), Convert.ToBoolean(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
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
