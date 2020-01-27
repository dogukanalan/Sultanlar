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
    public class Gorevler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkGorevID;
        private byte _tintDepartmanID;
        private string _strGorev;
        private bool _blGorevWeb;
        private bool _blGorevListe;
        //
        //
        //
        // Constracter lar:
        //
        private Gorevler(byte pkGorevID, byte tintDepartmanID, string strGorev, bool blGorevWeb, bool blGorevListe)
        {
            this._pkGorevID = pkGorevID;
            this._strGorev = strGorev;
            this._tintDepartmanID = tintDepartmanID;
            this._blGorevWeb = blGorevWeb;
            this._blGorevListe = blGorevListe;
        }
        //
        //
        public Gorevler(byte tintDepartmanID, string strGorev, bool blGorevWeb, bool blGorevListe)
        {
            this._tintDepartmanID = tintDepartmanID;
            this._strGorev = strGorev;
            this._blGorevWeb = blGorevWeb;
            this._blGorevListe = blGorevListe;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkGorevID
        {
            get
            {
                return this._pkGorevID;
            }
        }
        //
        //
        public byte tintDepartmanID
        {
            get
            {
                return this._tintDepartmanID;
            }
            set
            {
                this._tintDepartmanID = value;
            }
        }
        //
        //
        public string strGorev
        {
            get
            {
                return this._strGorev;
            }
            set
            {
                this._strGorev = value;
            }
        }
        //
        //
        public bool blGorevWeb
        {
            get
            {
                return this._blGorevWeb;
            }
            set
            {
                this._blGorevWeb = value;
            }
        }
        //
        //
        public bool blGorevListe
        {
            get
            {
                return this._blGorevListe;
            }
            set
            {
                this._blGorevListe = value;
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
            return this._strGorev;
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
                SqlCommand cmd = new SqlCommand("sp_GorevEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@strGorev", SqlDbType.NVarChar, 50).Value = this._strGorev;
                cmd.Parameters.Add("@blGorevWeb", SqlDbType.Bit).Value = this._blGorevWeb;
                cmd.Parameters.Add("@blGorevListe", SqlDbType.Bit).Value = this._blGorevListe;
                cmd.Parameters.Add("@pkGorevID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkGorevID = Convert.ToByte(cmd.Parameters["@pkGorevID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_GorevGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkGorevID", SqlDbType.TinyInt).Value = this._pkGorevID;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@strGorev", SqlDbType.NVarChar, 50).Value = this._strGorev;
                cmd.Parameters.Add("@blGorevListe", SqlDbType.Bit).Value = this._blGorevListe;
                cmd.Parameters.Add("@blGorevWeb", SqlDbType.Bit).Value = this._blGorevWeb;
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
                SqlCommand cmd = new SqlCommand("sp_GorevSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkGorevID", SqlDbType.TinyInt).Value = this._pkGorevID;
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

                SqlCommand cmd = new SqlCommand("sp_GorevGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString();
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
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_GorevGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Gorevler(Convert.ToByte(dr[0]), Convert.ToByte(dr[1]), dr[2].ToString(), Convert.ToBoolean(dr[3]), Convert.ToBoolean(dr[4])));
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
        public static void GetObjectListeler(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_GorevGetirListeler", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Gorevler(Convert.ToByte(dr[0]), Convert.ToByte(dr[1]), dr[2].ToString(), Convert.ToBoolean(dr[3]), Convert.ToBoolean(dr[4])));
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
        public static void GetObjectHepsi(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_GorevGetirHepsi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Gorevler(Convert.ToByte(dr[0]), Convert.ToByte(dr[1]), dr[2].ToString(), Convert.ToBoolean(dr[3]), Convert.ToBoolean(dr[4])));
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
        public static void GetObjectByDepartmanID(IList List, string DepartmanID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_GorevGetirByDepartmanID", conn);
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = DepartmanID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Gorevler(Convert.ToByte(dr[0]), Convert.ToByte(dr[1]), dr[2].ToString(), Convert.ToBoolean(dr[3]), Convert.ToBoolean(dr[4])));
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
        public static void GetObjectByDepartmanID(DataTable dt, string DepartmanID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GorevGetirByDepartmanID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = DepartmanID;
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
        public static string GetDepartmanEposta(string GorevID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GorevGetirDepartmanEpostaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkGorevID", SqlDbType.TinyInt).Value = GorevID;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GorevGetir", conn);
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
