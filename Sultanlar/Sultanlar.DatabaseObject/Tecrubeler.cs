using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Tecrubeler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkTecrubeID;
        private int _intBasvuruID;
        private string _strTecrubeIsyeriAdi;
        private string _strTecrubeGorev;
        private string _dtTecrubeGirisTarihi;
        private string _dtTecrubeCikisTarihi;
        private string _strTecrubeUcret;
        private string _strTecrubeAyrilmaNedeni;
        private bool _blTecrubeCalisiyor;
        //
        //
        //
        // Constracter lar:
        //
        private Tecrubeler(int pkTecrubeID, int intBasvuruID, string strTecrubeIsyeriAdi, string strTecrubeGorev, string dtTecrubeGirisTarihi,
            string dtTecrubeCikisTarihi, string strTecrubeUcret, string strTecrubeAyrilmaNedeni, bool blTecrubeCalisiyor)
        {
            this._pkTecrubeID = pkTecrubeID;
            this._intBasvuruID = intBasvuruID;
            this._strTecrubeIsyeriAdi = strTecrubeIsyeriAdi;
            this._strTecrubeGorev = strTecrubeGorev;
            this._dtTecrubeGirisTarihi = dtTecrubeGirisTarihi;
            this._dtTecrubeCikisTarihi = dtTecrubeCikisTarihi;
            this._strTecrubeUcret = strTecrubeUcret;
            this._strTecrubeAyrilmaNedeni = strTecrubeAyrilmaNedeni;
            this._blTecrubeCalisiyor = blTecrubeCalisiyor;
        }
        //
        //
        public Tecrubeler(int intBasvuruID, string strTecrubeIsyeriAdi, string strTecrubeGorev, string dtTecrubeGirisTarihi, string dtTecrubeCikisTarihi, 
            string strTecrubeUcret, string strTecrubeAyrilmaNedeni, bool blTecrubeCalisiyor)
        {
            this._intBasvuruID = intBasvuruID;
            this._strTecrubeIsyeriAdi = strTecrubeIsyeriAdi;
            this._strTecrubeGorev = strTecrubeGorev;
            this._dtTecrubeGirisTarihi = dtTecrubeGirisTarihi;
            this._dtTecrubeCikisTarihi = dtTecrubeCikisTarihi;
            this._strTecrubeUcret = strTecrubeUcret;
            this._strTecrubeAyrilmaNedeni = strTecrubeAyrilmaNedeni;
            this._blTecrubeCalisiyor = blTecrubeCalisiyor;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkTecrubeID
        {
            get
            {
                return this._pkTecrubeID;
            }
        }
        //
        //
        public int intBasvuruID
        {
            get
            {
                return this._intBasvuruID;
            }
            set
            {
                this._intBasvuruID = value;
            }
        }
        //
        //
        public string strTecrubeIsyeriAdi
        {
            get
            {
                return this._strTecrubeIsyeriAdi;
            }
            set
            {
                this._strTecrubeIsyeriAdi = value;
            }
        }
        //
        //
        public string strTecrubeGorev
        {
            get
            {
                return this._strTecrubeGorev;
            }
            set
            {
                this._strTecrubeGorev = value;
            }
        }
        //
        //
        public string dtTecrubeGirisTarihi
        {
            get
            {
                return this._dtTecrubeGirisTarihi;
            }
            set
            {
                this._dtTecrubeGirisTarihi = value;
            }
        }
        //
        //
        public string dtTecrubeCikisTarihi
        {
            get
            {
                return this._dtTecrubeCikisTarihi;
            }
            set
            {
                this._dtTecrubeCikisTarihi = value;
            }
        }
        //
        //
        public string strTecrubeUcret
        {
            get
            {
                return this._strTecrubeUcret;
            }
            set
            {
                this._strTecrubeUcret = value;
            }
        }
        //
        //
        public string strTecrubeAyrilmaNedeni
        {
            get
            {
                return this._strTecrubeAyrilmaNedeni;
            }
            set
            {
                this._strTecrubeAyrilmaNedeni = value;
            }
        }
        //
        //
        public bool blTecrubeCalisiyor
        {
            get
            {
                return this._blTecrubeCalisiyor;
            }
            set
            {
                this._blTecrubeCalisiyor = value;
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
            object TecrubeGirisTarihi = DBNull.Value;
            object TecrubeCikisTarihi = DBNull.Value;
            if (_dtTecrubeGirisTarihi != string.Empty)
            {
                TecrubeGirisTarihi = DateTime.Parse(_dtTecrubeGirisTarihi);
            }
            if (_dtTecrubeCikisTarihi != string.Empty)
            {
                TecrubeCikisTarihi = DateTime.Parse(_dtTecrubeCikisTarihi);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_TecrubeEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strTecrubeIsyeriAdi", SqlDbType.NVarChar, 100).Value = this._strTecrubeIsyeriAdi;
                cmd.Parameters.Add("@strTecrubeGorev", SqlDbType.NVarChar, 50).Value = this._strTecrubeGorev;
                cmd.Parameters.Add("@dtTecrubeGirisTarihi", SqlDbType.SmallDateTime).Value = TecrubeGirisTarihi;
                cmd.Parameters.Add("@dtTecrubeCikisTarihi", SqlDbType.SmallDateTime).Value = TecrubeCikisTarihi;
                cmd.Parameters.Add("@strTecrubeUcret", SqlDbType.NVarChar, 50).Value = this._strTecrubeUcret;
                cmd.Parameters.Add("@strTecrubeAyrilmaNedeni", SqlDbType.NVarChar, 150).Value = this._strTecrubeAyrilmaNedeni;
                cmd.Parameters.Add("@blTecrubeCalisiyor", SqlDbType.Bit).Value = this._blTecrubeCalisiyor;
                cmd.Parameters.Add("@pkTecrubeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkTecrubeID = Convert.ToInt32(cmd.Parameters["@pkTecrubeID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_TecrubeGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkTecrubeID", SqlDbType.Int).Value = this._pkTecrubeID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strTecrubeIsyeriAdi", SqlDbType.NVarChar, 100).Value = this._strTecrubeIsyeriAdi;
                cmd.Parameters.Add("@strTecrubeGorev", SqlDbType.NVarChar, 50).Value = this._strTecrubeGorev;
                cmd.Parameters.Add("@dtTecrubeGirisTarihi", SqlDbType.SmallDateTime).Value = this._dtTecrubeGirisTarihi;
                cmd.Parameters.Add("@dtTecrubeCikisTarihi", SqlDbType.SmallDateTime).Value = this._dtTecrubeCikisTarihi;
                cmd.Parameters.Add("@strTecrubeUcret", SqlDbType.NVarChar, 50).Value = this._strTecrubeUcret;
                cmd.Parameters.Add("@strTecrubeAyrilmaNedeni", SqlDbType.NVarChar, 150).Value = this._strTecrubeAyrilmaNedeni;
                cmd.Parameters.Add("@blTecrubeCalisiyor", SqlDbType.Bit).Value = this._blTecrubeCalisiyor;
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
                SqlCommand cmd = new SqlCommand("sp_TecrubeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkTecrubeID", SqlDbType.Int).Value = this._pkTecrubeID;
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
        public static void GetObject(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_TecrubeGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Tecrubeler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), Convert.ToBoolean(dr[8])));
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_TecrubeGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow dtrow = dt.NewRow();
                        dtrow[0] = dr[0].ToString();
                        dtrow[1] = dr[1].ToString();
                        dtrow[2] = dr[2].ToString();
                        dtrow[3] = dr[3].ToString();
                        dtrow[4] = dr[4].ToString();
                        dtrow[5] = dr[5].ToString();
                        dtrow[6] = dr[6].ToString();
                        dtrow[7] = dr[7].ToString();
                        dtrow[8] = dr[8].ToString();
                        dt.Rows.Add(dtrow);
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
        public static void GetObject(DataTable dt, int BasvuruID)
        {
            dt.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_TecrubeGetirByBasvuruID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = BasvuruID;
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
