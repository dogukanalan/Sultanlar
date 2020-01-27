using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject
{
    public class AT_Muayeneler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkMuayeneID;
        private int _intArabaID;
        private string _dtMuayeneBaslangic;
        private string _dtMuayeneBitis;
        //
        //
        //
        // Constracter lar:
        //
        private AT_Muayeneler(int pkMuayeneID, int intArabaID, string dtMuayeneBaslangic, string dtMuayeneBitis)
        {
            this._pkMuayeneID = pkMuayeneID;
            this._intArabaID = intArabaID;
            this._dtMuayeneBaslangic = dtMuayeneBaslangic;
            this._dtMuayeneBitis = dtMuayeneBitis;
        }
        //
        //
        public AT_Muayeneler(int intArabaID, string dtMuayeneBaslangic, string dtMuayeneBitis)
        {
            this._intArabaID = intArabaID;
            this._dtMuayeneBaslangic = dtMuayeneBaslangic;
            this._dtMuayeneBitis = dtMuayeneBitis;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkMuayeneID
        {
            get
            {
                return this._pkMuayeneID;
            }
        }
        //
        //
        public int intArabaID
        {
            get
            {
                return this._intArabaID;
            }
            set
            {
                this._intArabaID = value;
            }
        }
        //
        //
        public string dtMuayeneBaslangic
        {
            get
            {
                return this._dtMuayeneBaslangic;
            }
            set
            {
                this._dtMuayeneBaslangic = value;
            }
        }
        //
        //
        public string dtMuayeneBitis
        {
            get
            {
                return this._dtMuayeneBitis;
            }
            set
            {
                this._dtMuayeneBitis = value;
            }
        }
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
        // Metodlar:
        //
        public void DoInsert()
        {
            object MuayeneBaslangic = DBNull.Value;
            object MuayeneBitis = DBNull.Value;
            if (_dtMuayeneBaslangic != string.Empty)
            {
                MuayeneBaslangic = DateTime.Parse(_dtMuayeneBaslangic);
            }
            if (_dtMuayeneBitis != string.Empty)
            {
                MuayeneBitis = DateTime.Parse(_dtMuayeneBitis);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_MuayeneEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = this._intArabaID;
                cmd.Parameters.Add("@dtMuayeneBaslangic", SqlDbType.SmallDateTime).Value = MuayeneBaslangic;
                cmd.Parameters.Add("@dtMuayeneBitis", SqlDbType.SmallDateTime).Value = MuayeneBitis;
                cmd.Parameters.Add("@pkMuayeneID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkMuayeneID = Convert.ToByte(cmd.Parameters["@pkMuayeneID"].Value);
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
            object MuayeneBaslangic = DBNull.Value;
            object MuayeneBitis = DBNull.Value;
            if (_dtMuayeneBaslangic != string.Empty)
            {
                MuayeneBaslangic = DateTime.Parse(_dtMuayeneBaslangic);
            }
            if (_dtMuayeneBitis != string.Empty)
            {
                MuayeneBitis = DateTime.Parse(_dtMuayeneBitis);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_MuayeneGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMuayeneID", SqlDbType.Int).Value = this._pkMuayeneID;
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = this._intArabaID;
                cmd.Parameters.Add("@dtMuayeneBaslangic", SqlDbType.SmallDateTime).Value = MuayeneBaslangic;
                cmd.Parameters.Add("@dtMuayeneBitis", SqlDbType.SmallDateTime).Value = MuayeneBitis;
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
                SqlCommand cmd = new SqlCommand("sp_AT_MuayeneSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMuayeneID", SqlDbType.Int).Value = this._pkMuayeneID;
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
        public static void GetObject(IList List, int ArabaID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_AT_MuayeneGetir", conn);
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = ArabaID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_Muayeneler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString()));
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
        public static void GetObject(DataTable dt, int ArabaID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_MuayeneGetir", conn);
                da.SelectCommand.Parameters.Add("@intArabaID", SqlDbType.Int).Value = ArabaID;
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
        public static void GetObjectToFinish(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_MuayeneKontrol", conn);
                da.SelectCommand.Parameters.Add("@Gelecek", SqlDbType.SmallDateTime).Value = DateTime.Now.AddDays(3);
                da.SelectCommand.Parameters.Add("@Bugun", SqlDbType.SmallDateTime).Value = DateTime.Now;
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
        public static void GetObjectFinished(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_MuayeneKontrolBiten", conn);
                da.SelectCommand.Parameters.Add("@Bugun", SqlDbType.SmallDateTime).Value = DateTime.Now;
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
    }
}
