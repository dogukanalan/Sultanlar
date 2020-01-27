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
    public class Tedarikciler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private short _pkTedarikciID;
        private string _strTedarikci;
        private string _strTedarikciAciklama;
        private byte[] _binTedarikciResim;
        //
        //
        //
        // Constracter lar:
        //
        private Tedarikciler(short pkTedarikciID, string strTedarikci, string strTedarikciAciklama, byte[] binTedarikciResim)
        {
            this._pkTedarikciID = pkTedarikciID;
            this._strTedarikci = strTedarikci;
            this._strTedarikciAciklama = strTedarikciAciklama;
            this._binTedarikciResim = binTedarikciResim;
        }
        //
        //
        public Tedarikciler(string strTedarikci, string strTedarikciAciklama, byte[] binTedarikciResim)
        {
            this._strTedarikci = strTedarikci;
            this._strTedarikciAciklama = strTedarikciAciklama;
            this._binTedarikciResim = binTedarikciResim;
        }
        //
        //
        //
        // Özellikler:
        //
        public short pkTedarikciID
        {
            get
            {
                return this._pkTedarikciID;
            }
        }
        //
        //
        public string strTedarikci
        {
            get
            {
                return this._strTedarikci;
            }
            set
            {
                this._strTedarikci = value;
            }
        }
        //
        //
        public string strTedarikciAciklama
        {
            get
            {
                return this._strTedarikciAciklama;
            }
            set
            {
                this._strTedarikciAciklama = value;
            }
        }
        //
        //
        public byte[] binTedarikciResim
        {
            get
            {
                return this._binTedarikciResim;
            }
            set
            {
                this._binTedarikciResim = value;
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
        // ToString:
        //
        public override string ToString()
        {
            return this._strTedarikci;
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
                SqlCommand cmd = new SqlCommand("sp_TedarikciEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strTedarikci", SqlDbType.NVarChar, 100).Value = this._strTedarikci;
                cmd.Parameters.Add("@strTedarikciAciklama", SqlDbType.NVarChar).Value = this._strTedarikciAciklama;
                cmd.Parameters.Add("@binTedarikciResim", SqlDbType.VarBinary).Value = this._binTedarikciResim;
                cmd.Parameters.Add("@pkTedarikciID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkTedarikciID = Convert.ToByte(cmd.Parameters["@pkTedarikciID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_TedarikciGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkTedarikciID", SqlDbType.SmallInt).Value = this._pkTedarikciID;
                cmd.Parameters.Add("@strTedarikci", SqlDbType.NVarChar, 100).Value = this._strTedarikci;
                cmd.Parameters.Add("@strTedarikciAciklama", SqlDbType.NVarChar).Value = this._strTedarikciAciklama;
                cmd.Parameters.Add("@binTedarikciResim", SqlDbType.VarBinary).Value = this._binTedarikciResim;
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
                SqlCommand cmd = new SqlCommand("sp_TedarikciSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkTedarikciID", SqlDbType.TinyInt).Value = this._pkTedarikciID;
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

                SqlCommand cmd = new SqlCommand("sp_TedarikciGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Tedarikciler(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), (byte[])dr[3]));
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
        public static void GetObjectByID(string[] Tedarikci, string TedarikciID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_TedarikciGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkTedarikciID", SqlDbType.SmallInt).Value = TedarikciID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Tedarikci[0] = dr[0].ToString();
                        Tedarikci[1] = dr[1].ToString();
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
                SqlCommand cmd = new SqlCommand("sp_TedarikciGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow dtrow = dt.NewRow();
                        dtrow[0] = dr[0];
                        dtrow[1] = dr[1];
                        dtrow[2] = dr[2];
                        dtrow[3] = dr[3];
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
        public static byte[] GetPictureByID(string TedarikciID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_TedarikciResimGetirByID", conn);
                cmd.Parameters.Add("@pkTedarikciID", SqlDbType.SmallInt).Value = TedarikciID;
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
        public static int GetObjectCount() // kullanılmıyor şu anda
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_TedarikciGetirKacSatirVar", conn);
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
        public static object GetObjectOnlyIDs()
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_TedarikciGetirSadeceIDler", conn);
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
    }
}
