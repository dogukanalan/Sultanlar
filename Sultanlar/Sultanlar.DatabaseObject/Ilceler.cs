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
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject
{
    public class Ilceler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private Int16 _pkIlceID;
        private string _strIlceKod;
        private string _strIlce;
        //
        //
        //
        // Constracter lar:
        //
        private Ilceler(Int16 pkIlceID, string strIlceKod, string strIlce)
        {
            this._pkIlceID = pkIlceID;
            this._strIlceKod = strIlceKod;
            this._strIlce = strIlce;
        }
        //
        //
        public Ilceler(string strIlce, string strIlceKod)
        {
            this._strIlceKod = strIlceKod;
            this._strIlce = strIlce;
        }
        //
        //
        //
        // Özellikler:
        //
        public Int16 pkIlceID
        {
            get
            {
                return this._pkIlceID;
            }
        }
        //
        //
        public string strIlceKod
        {
            get
            {
                return this._strIlceKod;
            }
            set
            {
                this._strIlceKod = value;
            }
        }
        //
        //
        public string strIlce
        {
            get
            {
                return this._strIlce;
            }
            set
            {
                this._strIlce = value;
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
            return this._strIlce;
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
                SqlCommand cmd = new SqlCommand("sp_IlceEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strIlceKod", SqlDbType.Char, 4).Value = this._strIlceKod;
                cmd.Parameters.Add("@strIlce", SqlDbType.NVarChar, 100).Value = this._strIlce;
                cmd.Parameters.Add("@pkIlceID", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkIlceID = Convert.ToInt16(cmd.Parameters["@pkIlceID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_IlceGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIlceID", SqlDbType.SmallInt).Value = this._pkIlceID;
                cmd.Parameters.Add("@strIlceKod", SqlDbType.Char, 4).Value = this._strIlceKod;
                cmd.Parameters.Add("@strIlce", SqlDbType.NVarChar, 100).Value = this._strIlce;
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
                SqlCommand cmd = new SqlCommand("sp_IlceSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIlceID", SqlDbType.SmallInt).Value = this._pkIlceID;
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
        public static void GetObject(ListItemCollection lic, string ilkod)
        {
            if (ilkod.Length == 1)
            {
                ilkod = "0" + ilkod;
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                ListItem lst1 = new ListItem();
                lst1.Text = "Seçiniz";
                lst1.Value = "0";
                lic.Add(lst1);

                SqlCommand cmd = new SqlCommand("sp_IlceGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strIlKod", SqlDbType.Char, 2).Value = ilkod;
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
        public static void GetObject(IList List, string ilkod, bool UI)
        {
            if (ilkod.Length == 1)
            {
                ilkod = "0" + ilkod;
            }


            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_IlceGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strIlKod", SqlDbType.Char, 2).Value = ilkod;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Ilceler(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString()));
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
        public static void GetObject(DataTable dt, string ilkod)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_IlceGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@strIlKod", SqlDbType.Char, 2).Value = ilkod;
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
        public static string GetObjectByID(short IlceID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_IlceGetirByID", conn);
                cmd.Parameters.Add("@pkIlceID", SqlDbType.SmallInt).Value = IlceID;
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
        public static string GetObjectByIlceKod(string IlceKod)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_IlceGetirByIlceKod", conn);
                cmd.Parameters.Add("@strIlceKod", SqlDbType.Char, 4).Value = IlceKod;
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
        public static string GetIlceKodByID(short IlceID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_IlceKodGetirByID", conn);
                cmd.Parameters.Add("@pkIlceID", SqlDbType.SmallInt).Value = IlceID;
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
        public static void GetObjectIllerIlceler(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [strIlKod] AS [IL KOD],[strIl] AS IL,SUBSTRING([strIlceKod],3,2) AS [ILCE KOD],[strIlce] AS ILCE FROM tblIlceler INNER JOIN tblIller ON SUBSTRING(tblIlceler.strIlceKod,1,2) = tblIller.strIlKod", conn);
                try
                {
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
        public static int GetIDByILIDILCE(int pkIlID, string strIlce)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkIlceID FROM [tblIlceler] INNER JOIN tblIller ON LEFT(strIlceKod, 2) = strIlKod WHERE pkIlID = @pkIlID AND strIlce = @strIlce", conn);
                cmd.Parameters.Add("@pkIlID", SqlDbType.Int).Value = pkIlID;
                cmd.Parameters.Add("@strIlce", SqlDbType.NVarChar, 100).Value = strIlce;
                try
                {
                    conn.Open();
                    if (cmd.ExecuteScalar() != DBNull.Value)
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
