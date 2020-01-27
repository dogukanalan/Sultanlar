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
    public class Departmanlar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkDepartmanID;
        private string _strDepartman;
        private string _strDepartmanEposta;
        private bool _blDepartmanWeb;
        //
        //
        //
        // Constracter lar:
        //
        private Departmanlar(byte pkDepartmanID, string strDepartman, string strDepartmanEposta, bool blDepartmanWeb)
        {
            this._pkDepartmanID = pkDepartmanID;
            this._strDepartman = strDepartman;
            this._strDepartmanEposta = strDepartmanEposta;
            this._blDepartmanWeb = blDepartmanWeb;
        }
        //
        //
        public Departmanlar(string strDepartman, string strDepartmanEposta, bool blDepartmanWeb)
        {
            this._strDepartman = strDepartman;
            this._strDepartmanEposta = strDepartmanEposta;
            this._blDepartmanWeb = blDepartmanWeb;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkDepartmanID
        {
            get
            {
                return this._pkDepartmanID;
            }
        }
        //
        //
        public string strDepartman
        {
            get
            {
                return this._strDepartman;
            }
            set
            {
                this._strDepartman = value;
            }
        }
        //
        //
        public string strDepartmanEposta
        {
            get
            {
                return this._strDepartmanEposta;
            }
            set
            {
                this._strDepartmanEposta = value;
            }
        }
        //
        //
        public bool blDepartmanWeb
        {
            get
            {
                return this._blDepartmanWeb;
            }
            set
            {
                this._blDepartmanWeb = value;
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
            return this._strDepartman;
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
                SqlCommand cmd = new SqlCommand("sp_DepartmanEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strDepartman", SqlDbType.NVarChar, 100).Value = this._strDepartman;
                cmd.Parameters.Add("@strDepartmanEposta", SqlDbType.NVarChar, 100).Value = this._strDepartmanEposta;
                cmd.Parameters.Add("@blDepartmanWeb", SqlDbType.Bit).Value = this._blDepartmanWeb;
                cmd.Parameters.Add("@pkDepartmanID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkDepartmanID = Convert.ToByte(cmd.Parameters["@pkDepartmanID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_DepartmanGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkDepartmanID", SqlDbType.TinyInt).Value = this._pkDepartmanID;
                cmd.Parameters.Add("@strDepartman", SqlDbType.NVarChar, 100).Value = this._strDepartman;
                cmd.Parameters.Add("@strDepartmanEposta", SqlDbType.NVarChar, 100).Value = this._strDepartmanEposta;
                cmd.Parameters.Add("@blDepartmanWeb", SqlDbType.Bit).Value = this._blDepartmanWeb;
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
                SqlCommand cmd = new SqlCommand("sp_DepartmanSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkDepartmanID", SqlDbType.TinyInt).Value = this._pkDepartmanID;
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

                SqlCommand cmd = new SqlCommand("sp_DepartmanGetirWeb", conn);
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
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_DepartmanGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Departmanlar(Convert.ToByte(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToBoolean(dr[3])));
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
                List.Add(new Departmanlar(0, "Boş", "", false));

                SqlCommand cmd = new SqlCommand("sp_DepartmanGetirHepsi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Departmanlar(Convert.ToByte(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToBoolean(dr[3])));
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
        public static string GetEmailByID(string DepartmanID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DepartmanEpostaGetirByID", conn);
                cmd.Parameters.Add("@pkDepartmanID", SqlDbType.TinyInt).Value = DepartmanID;
                cmd.CommandType = CommandType.StoredProcedure;
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
        public static string GetObjectByID(byte DepartmanID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strDepartman FROM tblDepartmanlar WHERE pkDepartmanID = @DepartmanID", conn);
                cmd.Parameters.Add("@DepartmanID", SqlDbType.TinyInt).Value = DepartmanID;
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
    }
}
