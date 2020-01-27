using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace Sultanlar.DatabaseObject
{
    public class Cocuklar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkCocukID;
        private int _intBasvuruID;
        private string _strCocukAd;
        private bool _blCocukErkek;
        private string _dtCocukDogumTarihi;
        private string _strCocukOkul;
        //
        //
        //
        // Constracter lar:
        //
        private Cocuklar(int pkCocukID, int intBasvuruID, string strCocukAd, bool blCocukErkek, string dtCocukDogumTarihi, string strCocukOkul)
        {
            this._pkCocukID = pkCocukID;
            this._intBasvuruID = intBasvuruID;
            this._strCocukAd = strCocukAd;
            this._blCocukErkek = blCocukErkek;
            this._dtCocukDogumTarihi = dtCocukDogumTarihi;
            this._strCocukOkul = strCocukOkul;
        }
        //
        //
        public Cocuklar(int intBasvuruID, string strCocukAd, bool blCocukErkek, string dtCocukDogumTarihi, string strCocukOkul)
        {
            this._intBasvuruID = intBasvuruID;
            this._strCocukAd = strCocukAd;
            this._blCocukErkek = blCocukErkek;
            this._dtCocukDogumTarihi = dtCocukDogumTarihi;
            this._strCocukOkul = strCocukOkul;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkCocukID
        {
            get
            {
                return this._pkCocukID;
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
        public string strCocukAd
        {
            get
            {
                return this._strCocukAd;
            }
            set
            {
                this._strCocukAd = value;
            }
        }
        //
        //
        public bool blCocukErkek
        {
            get
            {
                return this._blCocukErkek;
            }
            set
            {
                this._blCocukErkek = value;
            }
        }
        //
        //
        public string dtCocukDogumTarihi
        {
            get
            {
                return this._dtCocukDogumTarihi;
            }
            set
            {
                this._dtCocukDogumTarihi = value;
            }
        }
        //
        //
        public string strCocukOkul
        {
            get
            {
                return this._strCocukOkul;
            }
            set
            {
                this._strCocukOkul = value;
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
        //
        //
        public override string ToString()
        {
            return this._strCocukAd;
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object CocukDogumTarihi = DBNull.Value;
            if (_dtCocukDogumTarihi != string.Empty)
            {
                CocukDogumTarihi = DateTime.Parse(_dtCocukDogumTarihi);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CocukEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strCocukAd", SqlDbType.NVarChar, 30).Value = this._strCocukAd;
                cmd.Parameters.Add("@blCocukErkek", SqlDbType.Bit).Value = this._blCocukErkek;
                cmd.Parameters.Add("@dtCocukDogumTarihi", SqlDbType.SmallDateTime).Value = CocukDogumTarihi;
                cmd.Parameters.Add("@strCocukOkul", SqlDbType.NVarChar, 70).Value = this._strCocukOkul;
                cmd.Parameters.Add("@pkCocukID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkCocukID = Convert.ToInt32(cmd.Parameters["@pkCocukID"].Value);
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
            object CocukDogumTarihi = DBNull.Value;
            if (_dtCocukDogumTarihi != string.Empty)
            {
                CocukDogumTarihi = DateTime.Parse(_dtCocukDogumTarihi);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CocukGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkCocukID", SqlDbType.Int).Value = this._pkCocukID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@strCocukAd", SqlDbType.NVarChar, 30).Value = this._strCocukAd;
                cmd.Parameters.Add("@blCocukErkek", SqlDbType.Bit).Value = this._blCocukErkek;
                cmd.Parameters.Add("@dtCocukDogumTarihi", SqlDbType.SmallDateTime).Value = CocukDogumTarihi;
                cmd.Parameters.Add("@strCocukOkul", SqlDbType.NVarChar, 70).Value = this._strCocukOkul;
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
                SqlCommand cmd = new SqlCommand("sp_CocukSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkCocukID", SqlDbType.Int).Value = this._pkCocukID;
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
        public static void GetObject(IList List, int BasvuruID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_CocukGetirByBasvuruID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = BasvuruID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Cocuklar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), Convert.ToBoolean(dr[3]), dr[4].ToString(),
                            dr[5].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_CocukGetir", conn);
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
    }
}
