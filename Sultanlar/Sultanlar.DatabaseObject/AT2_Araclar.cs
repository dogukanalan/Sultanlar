using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_Araclar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intLojistikFirmaID;
        private int _intAracTipiID;
        private int _intSoforMuavinID;
        private int _intMuavinID;
        private bool _blPasif;
        private string _strSorumlu;
        private string _strPlaka;
        private string _strModelYil;
        private string _strTonaj;
        private string _strHacim;
        //
        //
        //
        // Constracter lar:
        //
        private AT2_Araclar()
        {

        }
        //
        //
        private AT2_Araclar(int pkID, int intLojistikFirmaID, int intAracTipiID, int intSoforMuavinID, int intMuavinID, bool blPasif, string strSorumlu, 
            string strPlaka, string strModelYil, string strTonaj, string strHacim)
        {
            this._pkID = pkID;
            this._intLojistikFirmaID = intLojistikFirmaID;
            this._intAracTipiID = intAracTipiID;
            this._intSoforMuavinID = intSoforMuavinID;
            this._intMuavinID = intMuavinID;
            this._blPasif = blPasif;
            this._strSorumlu = strSorumlu;
            this._strPlaka = strPlaka;
            this._strModelYil = strModelYil;
            this._strTonaj = strTonaj;
            this._strHacim = strHacim;
        }
        //
        //
        public AT2_Araclar(int intLojistikFirmaID, int intAracTipiID, int intSoforMuavinID, int intMuavinID, bool blPasif, string strSorumlu, string strPlaka, 
            string strModelYil, string strTonaj, string strHacim)
        {
            this._intLojistikFirmaID = intLojistikFirmaID;
            this._intAracTipiID = intAracTipiID;
            this._intSoforMuavinID = intSoforMuavinID;
            this._intMuavinID = intMuavinID;
            this._blPasif = blPasif;
            this._strSorumlu = strSorumlu;
            this._strPlaka = strPlaka;
            this._strModelYil = strModelYil;
            this._strTonaj = strTonaj;
            this._strHacim = strHacim;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intLojistikFirmaID { get { return this._intLojistikFirmaID; } set { this._intLojistikFirmaID = value; } }
        public int intAracTipiID { get { return this._intAracTipiID; } set { this._intAracTipiID = value; } }
        public int intSoforMuavinID { get { return this._intSoforMuavinID; } set { this._intSoforMuavinID = value; } }
        public int intMuavinID { get { return this._intMuavinID; } set { this._intMuavinID = value; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public string strSorumlu { get { return this._strSorumlu; } set { this._strSorumlu = value; } }
        public string strPlaka { get { return this._strPlaka; } set { this._strPlaka = value; } }
        public string strModelYil { get { return this._strModelYil; } set { this._strModelYil = value; } }
        public string strTonaj { get { return this._strTonaj; } set { this._strTonaj = value; } }
        public string strHacim { get { return this._strHacim; } set { this._strHacim = value; } }
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
            return this._strPlaka;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_Araclar] ([intLojistikFirmaID],[intAracTipiID],intSoforMuavinID,intMuavinID,blPasif,strSorumlu,[strPlaka],strModelYil,[strTonaj],[strHacim]) VALUES (@intLojistikFirmaID,@intAracTipiID,@intSoforMuavinID,@intMuavinID,@blPasif,@strSorumlu,@strPlaka,@strModelYil,@strTonaj,@strHacim) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intLojistikFirmaID", SqlDbType.Int).Value = this._intLojistikFirmaID;
                cmd.Parameters.Add("@intAracTipiID", SqlDbType.Int).Value = this._intAracTipiID;
                cmd.Parameters.Add("@intSoforMuavinID", SqlDbType.Int).Value = this._intSoforMuavinID;
                cmd.Parameters.Add("@intMuavinID", SqlDbType.Int).Value = this._intMuavinID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strSorumlu", SqlDbType.NVarChar).Value = this._strSorumlu;
                cmd.Parameters.Add("@strPlaka", SqlDbType.NVarChar, 25).Value = this._strPlaka;
                cmd.Parameters.Add("@strModelYil", SqlDbType.NVarChar).Value = this._strModelYil;
                cmd.Parameters.Add("@strTonaj", SqlDbType.NVarChar).Value = this._strTonaj;
                cmd.Parameters.Add("@strHacim", SqlDbType.NVarChar).Value = this._strHacim;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_Araclar] SET [intLojistikFirmaID] = @intLojistikFirmaID,[intAracTipiID] = @intAracTipiID,intSoforMuavinID = @intSoforMuavinID,intMuavinID = @intMuavinID,blPasif = @blPasif,strSorumlu = @strSorumlu,[strPlaka] = @strPlaka,strModelYil = @strModelYil,[strTonaj] = @strTonaj,[strHacim] = @strHacim WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intLojistikFirmaID", SqlDbType.Int).Value = this._intLojistikFirmaID;
                cmd.Parameters.Add("@intAracTipiID", SqlDbType.Int).Value = this._intAracTipiID;
                cmd.Parameters.Add("@intSoforMuavinID", SqlDbType.Int).Value = this._intSoforMuavinID;
                cmd.Parameters.Add("@intMuavinID", SqlDbType.Int).Value = this._intMuavinID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@strSorumlu", SqlDbType.NVarChar).Value = this._strSorumlu;
                cmd.Parameters.Add("@strPlaka", SqlDbType.NVarChar, 25).Value = this._strPlaka;
                cmd.Parameters.Add("@strModelYil", SqlDbType.NVarChar).Value = this._strModelYil;
                cmd.Parameters.Add("@strTonaj", SqlDbType.NVarChar).Value = this._strTonaj;
                cmd.Parameters.Add("@strHacim", SqlDbType.NVarChar).Value = this._strHacim;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_Araclar] WHERE pkID = @pkID", conn);
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

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intLojistikFirmaID],[intAracTipiID],intSoforMuavinID,intMuavinID,blPasif,strSorumlu,[strPlaka],strModelYil,[strTonaj],[strHacim] FROM [tblAT2_Araclar] WHERE blPasif = @blPasif ORDER BY strPlaka", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_Araclar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]),
                            Convert.ToBoolean(dr[5]), AT2_LojistikFirmalar.GetObject(Convert.ToInt32(dr[1])).strSorumlu, dr[7].ToString(),
                            dr[8].ToString(), dr[9].ToString(), dr[10].ToString()));
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
        public static void GetObjects(IList List, bool Pasif, int LojistikFirmaID, int AracTipiID, string Plaka, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                string firmaaractip = string.Empty;
                if (LojistikFirmaID > 0)
                    firmaaractip += " AND intLojistikFirmaID = " + LojistikFirmaID.ToString();
                if (AracTipiID > 0)
                    firmaaractip += " AND intAracTipiID = " + AracTipiID.ToString();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intLojistikFirmaID],[intAracTipiID],intSoforMuavinID,intMuavinID,blPasif,strSorumlu,[strPlaka],strModelYil,[strTonaj],[strHacim] FROM [tblAT2_Araclar] WHERE blPasif = @blPasif " + firmaaractip + " AND strPlaka LIKE '%' + @strPlaka + '%' ORDER BY strPlaka", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                cmd.Parameters.Add("@strPlaka", SqlDbType.NVarChar, 25).Value = Plaka;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_Araclar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]),
                            Convert.ToBoolean(dr[5]), AT2_LojistikFirmalar.GetObject(Convert.ToInt32(dr[1])).strSorumlu, dr[7].ToString(), 
                            dr[8].ToString(), dr[9].ToString(), dr[10].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intLojistikFirmaID],[intAracTipiID],intSoforMuavinID,intMuavinID,blPasif,(SELECT strSorumlu FROM tblAT2_LojistikFirmalar WHERE pkID = intLojistikFirmaID),[strPlaka],strModelYil,[strTonaj],[strHacim] FROM [tblAT2_Araclar] WHERE blPasif = @blPasif ORDER BY strPlaka", conn);
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
        public static void GetObjects(DataTable dt, bool Pasif, int LojistikFirmaID, int AracTipiID, string Plaka)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string firmaaractip = string.Empty;
                if (LojistikFirmaID > 0)
                    firmaaractip += " AND intLojistikFirmaID = " + LojistikFirmaID.ToString();
                if (AracTipiID > 0)
                    firmaaractip += " AND intAracTipiID = " + AracTipiID.ToString();

                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intLojistikFirmaID],[intAracTipiID],intSoforMuavinID,intMuavinID,blPasif,strSorumlu,[strPlaka],strModelYil,[strTonaj],[strHacim] FROM [tblAT2_Araclar] WHERE blPasif = @blPasif " + firmaaractip + " AND strPlaka LIKE '%' + @strPlaka + '%' ORDER BY strPlaka", conn);
                da.SelectCommand.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                da.SelectCommand.Parameters.Add("@strPlaka", SqlDbType.NVarChar, 25).Value = Plaka;
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
        public static AT2_Araclar GetObject(int ID)
        {
            AT2_Araclar donendeger = new AT2_Araclar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intLojistikFirmaID],[intAracTipiID],intSoforMuavinID,intMuavinID,blPasif,strSorumlu,[strPlaka],strModelYil,[strTonaj],[strHacim] FROM [tblAT2_Araclar] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger = new AT2_Araclar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]),
                            Convert.ToBoolean(dr[5]), AT2_LojistikFirmalar.GetObject(Convert.ToInt32(dr[1])).strSorumlu, dr[7].ToString(),
                            dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
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
        public static bool IsExist(string Plaka)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblAT2_Araclar WHERE strPlaka = @strPlaka", conn);
                cmd.Parameters.Add("@strPlaka", SqlDbType.NVarChar, 25).Value = Plaka;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
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
