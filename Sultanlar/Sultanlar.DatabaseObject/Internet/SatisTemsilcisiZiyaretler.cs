using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SatisTemsilcisiZiyaretler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _intSLSREF;
        private string _strBARKOD;
        private int _intSMREF;
        private DateTime _dtZIYGUN;
        private DateTime _dtZiyaretBaslangic;
        private DateTime _dtZiyaretBitis;
        private Guid _unSebep;
        private string _strMekan;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private SatisTemsilcisiZiyaretler(long pkID, int intSLSREF, string strBARKOD, int intSMREF, DateTime dtZIYGUN,
            DateTime dtZiyaretBaslangic, DateTime dtZiyaretBitis, Guid unSebep, string strMekan, string strAciklama)
        {
            this._pkID = pkID;
            this._intSLSREF = intSLSREF;
            this._strBARKOD = strBARKOD;
            this._intSMREF = intSMREF;
            this._dtZIYGUN = dtZIYGUN;
            this._dtZiyaretBaslangic = dtZiyaretBaslangic;
            this._dtZiyaretBitis = dtZiyaretBitis;
            this._unSebep = unSebep;
            this._strMekan = strMekan;
            this._strAciklama = strAciklama;
        }
        //
        //
        public SatisTemsilcisiZiyaretler(int intSLSREF, string strBARKOD, int intSMREF, DateTime dtZIYGUN,
            DateTime dtZiyaretBaslangic, DateTime dtZiyaretBitis, Guid unSebep, string strMekan, string strAciklama)
        {
            this._intSLSREF = intSLSREF;
            this._strBARKOD = strBARKOD;
            this._intSMREF = intSMREF;
            this._dtZIYGUN = dtZIYGUN;
            this._dtZiyaretBaslangic = dtZiyaretBaslangic;
            this._dtZiyaretBitis = dtZiyaretBitis;
            this._unSebep = unSebep;
            this._strMekan = strMekan;
            this._strAciklama = strAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int intSLSREF { get { return this._intSLSREF; } set { this._intSLSREF = value; } }
        public string strBARKOD { get { return this._strBARKOD; } set { this._strBARKOD = value; } }
        public int intSMREF { get { return this._intSMREF; } set { this._intSMREF = value; } }
        public DateTime dtZIYGUN { get { return this._dtZIYGUN; } set { this._dtZIYGUN = value; } }
        public DateTime dtZiyaretBaslangic { get { return this._dtZiyaretBaslangic; } set { this._dtZiyaretBaslangic = value; } }
        public DateTime dtZiyaretBitis { get { return this._dtZiyaretBitis; } set { this._dtZiyaretBitis = value; } }
        public Guid unSebep { get { return this._unSebep; } set { this._unSebep = value; } }
        public string strMekan { get { return this._strMekan; } set { this._strMekan = value; } }
        public string strAciklama { get { return this._strAciklama; } set { this._strAciklama = value; } }
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
            return this._pkID.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object ZIYGUN = DBNull.Value;
            object ZiyaretBitis = DBNull.Value;
            if (this._dtZIYGUN != DateTime.MinValue)
                ZIYGUN = this._dtZIYGUN;
            if (this._dtZiyaretBitis != DateTime.MinValue)
                ZiyaretBitis = this._dtZiyaretBitis;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcisiZiyaretEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = this._intSLSREF;
                cmd.Parameters.Add("@strBARKOD", SqlDbType.NVarChar, 50).Value = this._strBARKOD;
                cmd.Parameters.Add("@intSMREF", SqlDbType.Int).Value = this._intSMREF;
                cmd.Parameters.Add("@dtZIYGUN", SqlDbType.SmallDateTime).Value = ZIYGUN;
                cmd.Parameters.Add("@dtZiyaretBaslangic", SqlDbType.DateTime).Value = this._dtZiyaretBaslangic;
                cmd.Parameters.Add("@dtZiyaretBitis", SqlDbType.DateTime).Value = ZiyaretBitis;
                cmd.Parameters.Add("@unSebep", SqlDbType.UniqueIdentifier).Value = this._unSebep;
                cmd.Parameters.Add("@strMekan", SqlDbType.NVarChar).Value = this._strMekan;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
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
            object ZIYGUN = DBNull.Value;
            object ZiyaretBitis = DBNull.Value;
            if (this._dtZIYGUN != DateTime.MinValue)
                ZIYGUN = this._dtZIYGUN;
            if (this._dtZiyaretBitis != DateTime.MinValue)
                ZiyaretBitis = this._dtZiyaretBitis;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcisiZiyaretGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = this._intSLSREF;
                cmd.Parameters.Add("@strBARKOD", SqlDbType.NVarChar, 50).Value = this._strBARKOD;
                cmd.Parameters.Add("@intSMREF", SqlDbType.Int).Value = this._intSMREF;
                cmd.Parameters.Add("@dtZIYGUN", SqlDbType.SmallDateTime).Value = ZIYGUN;
                cmd.Parameters.Add("@dtZiyaretBaslangic", SqlDbType.DateTime).Value = this._dtZiyaretBaslangic;
                cmd.Parameters.Add("@dtZiyaretBitis", SqlDbType.DateTime).Value = ZiyaretBitis;
                cmd.Parameters.Add("@unSebep", SqlDbType.UniqueIdentifier).Value = this._unSebep;
                cmd.Parameters.Add("@strMekan", SqlDbType.NVarChar).Value = this._strMekan;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcisiZiyaretSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this.pkID;
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
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcisiZiyaretlerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime ZIYGUN = DateTime.MinValue;
                        DateTime ZiyaretBitis = DateTime.MinValue;
                        if (dr[4].ToString() != string.Empty)
                            ZIYGUN = Convert.ToDateTime(dr[4]);
                        if (dr[5].ToString() != string.Empty)
                            ZiyaretBitis = Convert.ToDateTime(dr[5]);

                        List.Add(new SatisTemsilcisiZiyaretler(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(),
                            Convert.ToInt32(dr[3]), ZIYGUN, Convert.ToDateTime(dr[5]), ZiyaretBitis,
                            Guid.Parse(dr[7].ToString()), dr[8].ToString(), dr[9].ToString()));
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
        public static void GetObjects(DataTable dt, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SatisTemsilcisiZiyaretlerGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SatisTemsilcisiZiyaretlerGetirBySLSREF", conn);
                da.SelectCommand.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SatisTemsilcisiZiyaretlerGetirBySMREF", conn);
                da.SelectCommand.Parameters.Add("@intSMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static bool GetObjectsBySLSREFSMREF(int SLSREF, int SMREF, DateTime Zaman)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblINTERNET_SatisTemsilcisiZiyaretler] WHERE intSLSREF = @intSLSREF AND intSMREF = @intSMREF AND CONVERT(varchar(10), dtZiyaretBaslangic, 120) = CONVERT(varchar(10), @dtZiyaretBaslangic, 120)", conn);
                cmd.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@intSMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@dtZiyaretBaslangic", SqlDbType.DateTime).Value = Zaman;
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
        //
        //
        public static SatisTemsilcisiZiyaretler GetObject(long ID)
        {
            SatisTemsilcisiZiyaretler donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SatisTemsilcisiZiyaretGetir", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = ID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new SatisTemsilcisiZiyaretler(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(),
                        Convert.ToInt32(dr[3]),
                        dr[4] != DBNull.Value ? Convert.ToDateTime(dr[4]) : DateTime.MinValue, 
                        Convert.ToDateTime(dr[5]),
                        dr[6] != DBNull.Value ? Convert.ToDateTime(dr[6]) : DateTime.MinValue,
                        Guid.Parse(dr[7].ToString()), dr[8].ToString(), dr[8].ToString());
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
        public static void GetObjectLast(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SatisTemsilcisiZiyaretGetirSonBySLSREF", conn);
                da.SelectCommand.Parameters.Add("@intSLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        /// <summary>
        /// Ziyaret sonlandırma sebepleri
        /// </summary>
        public static void GetZiyaretSonlandırmaSebepleri(ListItemCollection lic, bool Seciniz)
        {
            lic.Clear();
            if (Seciniz)
                lic.Add(new ListItem("Seçiniz", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT LOGICALREF, ACIKLAMA FROM [Web-ZiyaretSonlandirmaSebepleri] ORDER BY ACIKLAMA", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// <summary>
        /// Ziyaret sonlandırma sebep ID
        /// </summary>
        public static int GetZiyaretSonlandırmaSebepID(Guid Ref)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID FROM [Web-ZiyaretSonlandirmaSebepleri] WHERE LOGICALREF = @LOGICALREF", conn);
                cmd.Parameters.Add("@LOGICALREF", SqlDbType.UniqueIdentifier).Value = Ref;
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
