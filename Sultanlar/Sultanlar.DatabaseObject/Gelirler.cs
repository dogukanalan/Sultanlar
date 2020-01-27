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
    public class Gelirler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkGelirID;
        private int _intBasvuruID;
        private byte _tintGelirTuruID;
        private string _strGelirTutar;
        private string _strGelirAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private Gelirler(int pkGelirID, int intBasvuruID, byte tintGelirTuruID, string strGelirTutar, string strGelirAciklama)
        {
            this._pkGelirID = pkGelirID;
            this._intBasvuruID = intBasvuruID;
            this._tintGelirTuruID = tintGelirTuruID;
            this._strGelirTutar = strGelirTutar;
            this._strGelirAciklama = strGelirAciklama;
        }
        //
        //
        public Gelirler(int intBasvuruID, byte tintGelirTuruID, string strGelirTutar, string strGelirAciklama)
        {
            this._intBasvuruID = intBasvuruID;
            this._tintGelirTuruID = tintGelirTuruID;
            this._strGelirTutar = strGelirTutar;
            this._strGelirAciklama = strGelirAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkGelirID
        {
            get
            {
                return this._pkGelirID;
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
        public byte tintGelirTuruID
        {
            get
            {
                return this._tintGelirTuruID;
            }
            set
            {
                this._tintGelirTuruID = value;
            }
        }
        //
        //
        public string strGelirTutar
        {
            get
            {
                return this._strGelirTutar;
            }
            set
            {
                this._strGelirTutar = value;
            }
        }
        //
        //
        public string strGelirAciklama
        {
            get
            {
                return this._strGelirAciklama;
            }
            set
            {
                this._strGelirAciklama = value;
            }
        }
        //
        //
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
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GelirEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintGelirTuruID", SqlDbType.TinyInt).Value = this._tintGelirTuruID;
                cmd.Parameters.Add("@strGelirTutar", SqlDbType.NVarChar, 20).Value = this._strGelirTutar;
                cmd.Parameters.Add("@strGelirAciklama", SqlDbType.NVarChar, 300).Value = this._strGelirAciklama;
                cmd.Parameters.Add("@pkGelirID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkGelirID = Convert.ToInt32(cmd.Parameters["@pkGelirID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_GelirGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkGelirID", SqlDbType.Int).Value = this._pkGelirID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintGelirTuruID", SqlDbType.TinyInt).Value = this._tintGelirTuruID;
                cmd.Parameters.Add("@strGelirTutar", SqlDbType.NVarChar, 20).Value = this._strGelirTutar;
                cmd.Parameters.Add("@strGelirAciklama", SqlDbType.NVarChar, 300).Value = this._strGelirAciklama;
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
                SqlCommand cmd = new SqlCommand("sp_GelirSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkGelirID", SqlDbType.Int).Value = this._pkGelirID;
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
        public static void GetObject(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                SqlCommand cmd = new SqlCommand("sp_GelirGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[0].ToString();
                        lic.Add(lst);
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
                SqlCommand cmd = new SqlCommand("sp_GelirGetir", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("sp_GelirGetirByBasvuruID", conn);
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
