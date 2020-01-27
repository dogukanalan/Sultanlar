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
    public class MedeniDurumlar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkMedeniDurumID;
        private string _strMedeniDurum;
        //
        //
        //
        // Constracter lar:
        //
        private MedeniDurumlar(byte pkMedeniDurumID, string strMedeniDurum)
        {
            this._pkMedeniDurumID = pkMedeniDurumID;
            this._strMedeniDurum = strMedeniDurum;
        }
        //
        //
        public MedeniDurumlar(string strMedeniDurum)
        {
            this._strMedeniDurum = strMedeniDurum;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkMedeniDurumID
        {
            get
            {
                return this._pkMedeniDurumID;
            }
        }
        //
        //
        public string strMedeniDurum
        {
            get
            {
                return this._strMedeniDurum;
            }
            set
            {
                this._strMedeniDurum = value;
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
            return this._strMedeniDurum;
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
                SqlCommand cmd = new SqlCommand("sp_MedeniDurumEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strMedeniDurum", SqlDbType.NVarChar, 10).Value = this._strMedeniDurum;
                cmd.Parameters.Add("@pkMedeniDurumID", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkMedeniDurumID = Convert.ToByte(cmd.Parameters["@pkMedeniDurumID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_MedeniDurumGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMedeniDurumID", SqlDbType.TinyInt).Value = this._pkMedeniDurumID;
                cmd.Parameters.Add("@strMedeniDurum", SqlDbType.NVarChar, 10).Value = this._strMedeniDurum;
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
                SqlCommand cmd = new SqlCommand("sp_MedeniDurumSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMedeniDurumID", SqlDbType.TinyInt).Value = this._pkMedeniDurumID;
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

                ListItem lst1 = new ListItem();
                lst1.Text = "Seçiniz";
                lst1.Value = "0";
                lic.Add(lst1);

                SqlCommand cmd = new SqlCommand("sp_MedeniDurumGetir", conn);
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

                SqlCommand cmd = new SqlCommand("sp_MedeniDurumGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MedeniDurumlar(Convert.ToByte(dr[0]), dr[1].ToString()));
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
                SqlCommand cmd = new SqlCommand("sp_MedeniDurumGetir", conn);
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
        public static string GetObjectByID(byte MedeniDurumID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_MedeniDurumGetirByID", conn);
                cmd.Parameters.Add("@pkMedeniDurumID", SqlDbType.TinyInt).Value = MedeniDurumID;
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
    }
}
