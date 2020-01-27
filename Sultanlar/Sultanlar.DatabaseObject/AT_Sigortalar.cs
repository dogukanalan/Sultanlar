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
    public class AT_Sigortalar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkSigortaID;
        private int _intArabaID;
        private string _dtSigortaBaslangic;
        private string _dtSigortaBitis;
        //
        //
        //
        // Constracter lar:
        //
        private AT_Sigortalar(int pkSigortaID, int intArabaID, string dtSigortaBaslangic, string dtSigortaBitis)
        {
            this._pkSigortaID = pkSigortaID;
            this._intArabaID = intArabaID;
            this._dtSigortaBaslangic = dtSigortaBaslangic;
            this._dtSigortaBitis = dtSigortaBitis;
        }
        //
        //
        public AT_Sigortalar(int intArabaID, string dtSigortaBaslangic, string dtSigortaBitis)
        {
            this._intArabaID = intArabaID;
            this._dtSigortaBaslangic = dtSigortaBaslangic;
            this._dtSigortaBitis = dtSigortaBitis;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkSigortaID
        {
            get
            {
                return this._pkSigortaID;
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
        public string dtSigortaBaslangic
        {
            get
            {
                return this._dtSigortaBaslangic;
            }
            set
            {
                this._dtSigortaBaslangic = value;
            }
        }
        //
        //
        public string dtSigortaBitis
        {
            get
            {
                return this._dtSigortaBitis;
            }
            set
            {
                this._dtSigortaBitis = value;
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
            object SigortaBaslangic = DBNull.Value;
            object SigortaBitis = DBNull.Value;
            if (_dtSigortaBaslangic != string.Empty)
            {
                SigortaBaslangic = DateTime.Parse(_dtSigortaBaslangic);
            }
            if (_dtSigortaBitis != string.Empty)
            {
                SigortaBitis = DateTime.Parse(_dtSigortaBitis);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_SigortaEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = this._intArabaID;
                cmd.Parameters.Add("@dtSigortaBaslangic", SqlDbType.SmallDateTime).Value = SigortaBaslangic;
                cmd.Parameters.Add("@dtSigortaBitis", SqlDbType.SmallDateTime).Value = SigortaBitis;
                cmd.Parameters.Add("@pkSigortaID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkSigortaID = Convert.ToByte(cmd.Parameters["@pkSigortaID"].Value);
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
            object SigortaBaslangic = DBNull.Value;
            object SigortaBitis = DBNull.Value;
            if (_dtSigortaBaslangic != string.Empty)
            {
                SigortaBaslangic = DateTime.Parse(_dtSigortaBaslangic);
            }
            if (_dtSigortaBitis != string.Empty)
            {
                SigortaBitis = DateTime.Parse(_dtSigortaBitis);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_SigortaGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSigortaID", SqlDbType.Int).Value = this._pkSigortaID;
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = this._intArabaID;
                cmd.Parameters.Add("@dtSigortaBaslangic", SqlDbType.SmallDateTime).Value = SigortaBaslangic;
                cmd.Parameters.Add("@dtSigortaBitis", SqlDbType.SmallDateTime).Value = SigortaBitis;
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
                SqlCommand cmd = new SqlCommand("sp_AT_SigortaSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSigortaID", SqlDbType.Int).Value = this._pkSigortaID;
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

                SqlCommand cmd = new SqlCommand("sp_AT_SigortaGetir", conn);
                cmd.Parameters.Add("@intArabaID", SqlDbType.Int).Value = ArabaID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_Sigortalar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_SigortaGetir", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_SigortaKontrol", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_SigortaKontrolBiten", conn);
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
