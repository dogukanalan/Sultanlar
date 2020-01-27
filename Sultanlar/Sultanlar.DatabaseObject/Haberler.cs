using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Haberler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkHaberID;
        private string _strBaslik;
        private string _strIcerik;
        private DateTime _dtTarih;
        private object _binResim;
        //
        //
        //
        // Constracter lar:
        //
        private Haberler(int pkHaberID, string strBaslik, string strIcerik, DateTime dtTarih, object binResim)
        {
            this._pkHaberID = pkHaberID;
            this._strBaslik = strBaslik;
            this._strIcerik = strIcerik;
            this._dtTarih = dtTarih;
            this._binResim = binResim;
        }
        //
        //
        public Haberler(string strBaslik, string strIcerik, DateTime dtTarih, object binResim)
        {
            this._strBaslik = strBaslik;
            this._strIcerik = strIcerik;
            this._dtTarih = dtTarih;
            this._binResim = binResim;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkHaberID
        {
            get
            {
                return this._pkHaberID;
            }
        }
        //
        //
        public string strBaslik
        {
            get
            {
                return this._strBaslik;
            }
            set
            {
                this._strBaslik = value;
            }
        }
        //
        //
        public string strIcerik
        {
            get
            {
                return this._strIcerik;
            }
            set
            {
                this._strIcerik = value;
            }
        }
        //
        //
        public DateTime dtTarih
        {
            get
            {
                return this._dtTarih;
            }
            set
            {
                this._dtTarih = value;
            }
        }
        //
        //
        public object binResim
        {
            get
            {
                return this._binResim;
            }
            set
            {
                this._binResim = value;
            }
        }
        //
        //
        //
        // ToString:
        //
        public override string ToString()
        {
            return this._strBaslik;
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
            object BinResim = DBNull.Value;
            if (_binResim != null)
            {
                BinResim = _binResim;
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HaberEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar, 50).Value = this._strBaslik;
                cmd.Parameters.Add("@strIcerik", SqlDbType.NVarChar).Value = this._strIcerik;
                cmd.Parameters.Add("@dtTarih", SqlDbType.SmallDateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = BinResim;
                cmd.Parameters.Add("@pkHaberID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkHaberID = Convert.ToInt32(cmd.Parameters["@pkHaberID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_HaberGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkHaberID", SqlDbType.Int).Value = this._pkHaberID;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar, 50).Value = this._strBaslik;
                cmd.Parameters.Add("@strIcerik", SqlDbType.NVarChar).Value = this._strIcerik;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this._binResim;
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
                SqlCommand cmd = new SqlCommand("sp_HaberSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkHaberID", SqlDbType.Int).Value = this._pkHaberID;
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

                SqlCommand cmd = new SqlCommand("sp_HaberGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Haberler(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), DateTime.Parse(dr[3].ToString()), dr[4]));
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
        public static object GetObject()
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_HaberGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(donendeger);
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
        public static object GetObject(int baslangic, int kactane)
        {
            DataTable dt = new DataTable();
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_HaberGetir", conn);
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


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["strBaslik"].ToString().Length > 25)
                    dt.Rows[i]["strBaslik"] = "<span title='" + dt.Rows[i]["strBaslik"].ToString() + "'>" + dt.Rows[i]["strBaslik"].ToString().Substring(0, 25) + "...</span>";
                if (dt.Rows[i]["strIcerik"].ToString().Length > 120)
                    dt.Rows[i]["strIcerik"] = dt.Rows[i]["strIcerik"].ToString().Substring(0, 120) + "...";
            }


            for (int i = 0; i < dt.Columns.Count; i++)
            {
                donendeger.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);
            }


            int satirsayisi = dt.Rows.Count;
            for (int i = baslangic; i < baslangic + kactane; i++)
            {
                if (i < satirsayisi)
                {
                    DataRow drow = donendeger.NewRow();
                    drow.ItemArray = dt.Rows[i].ItemArray;
                    donendeger.Rows.Add(drow);
                }
            }

            return donendeger;
        }
        //
        //
        public static int GetObjectCount()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HaberGetirKacSatirVar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        //
        //
        public static byte[] GetPictureByID(string HaberID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HaberResimGetirByID", conn);
                cmd.Parameters.Add("@pkHaberID", SqlDbType.SmallInt).Value = HaberID;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    donendeger = (byte[])cmd.ExecuteScalar();
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
        public static void GetObjectByID(string[] Haber, string HaberID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_HaberGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkHaberID", SqlDbType.Int).Value = HaberID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Haber[0] = dr[0].ToString();
                        Haber[1] = dr[1].ToString();
                        Haber[2] = dr[2].ToString();
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
