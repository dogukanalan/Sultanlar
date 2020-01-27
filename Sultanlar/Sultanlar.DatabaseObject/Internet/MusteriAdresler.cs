using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class MusteriAdresler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        int _pkAdresID;
        private int _intMusteriID;
        private string _strBaslik;
        private string _strAdres;
        private byte _tintIlID;
        private short _sintIlceID;
        //
        //
        //
        // Constracter lar:
        //
        //
        //
        private MusteriAdresler(int pkAdresID, int intMusteriID, string strBaslik, string strAdres, byte tintIlID, short sintIlceID)
        {
            this._pkAdresID = pkAdresID;
            this._intMusteriID = intMusteriID;
            this._strBaslik = strBaslik;
            this._strAdres = strAdres;
            this._tintIlID = tintIlID;
            this._sintIlceID = sintIlceID;
        }
        //
        //
        public MusteriAdresler(int intMusteriID, string strBaslik, string strAdres, byte tintIlID, short sintIlceID)
        {
            this._intMusteriID = intMusteriID;
            this._strBaslik = strBaslik;
            this._strAdres = strAdres;
            this._tintIlID = tintIlID;
            this._sintIlceID = sintIlceID;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkAdresID
        {
            get
            {
                return this._pkAdresID;
            }
        }
        //
        //
        public int intMusteriID
        {
            get
            {
                return this._intMusteriID;
            }
            set
            {
                this._intMusteriID = value;
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
        public string strAdres
        {
            get
            {
                return this._strAdres;
            }
            set
            {
                this._strAdres = value;
            }
        }
        //
        //
        public byte tintIlID
        {
            get
            {
                return this._tintIlID;
            }
            set
            {
                this._tintIlID = value;
            }
        }
        //
        //
        public short sintIlceID
        {
            get
            {
                return this._sintIlceID;
            }
            set
            {
                this._sintIlceID = value;
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
            return this._strBaslik;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdresEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar).Value = this._strBaslik;
                cmd.Parameters.Add("@strAdres", SqlDbType.NVarChar, 80).Value = this._strAdres;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = this._tintIlID;
                cmd.Parameters.Add("@sintIlceID", SqlDbType.SmallInt).Value = this._sintIlceID;
                cmd.Parameters.Add("@pkAdresID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkAdresID = Convert.ToInt32(cmd.Parameters["@pkAdresID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdresGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAdresID", SqlDbType.Int).Value = this._pkAdresID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar).Value = this._strBaslik;
                cmd.Parameters.Add("@strAdres", SqlDbType.NVarChar, 80).Value = this._strAdres;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = this._tintIlID;
                cmd.Parameters.Add("@sintIlceID", SqlDbType.SmallInt).Value = this._sintIlceID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdresSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAdresID", SqlDbType.Int).Value = this._pkAdresID;
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
        public static void GetObjects(IList List, int MusteriID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdreslerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new MusteriAdresler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(),
                            Convert.ToByte(dr[4]), Convert.ToInt16(dr[5])));
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
        public static void GetObjects(ListItemCollection lic, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                ListItem lst1 = new ListItem("Yeni Adres Ekle", "0");
                lic.Add(lst1);

                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdreslerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
        public static string GetAdres(int AdresID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdresGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAdresID", SqlDbType.Int).Value = AdresID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        donendeger = dr[3].ToString();
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
        public static MusteriAdresler GetObject(int AdresID)
        {
            MusteriAdresler donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusteriAdresGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkAdresID", SqlDbType.Int).Value = AdresID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        donendeger = new MusteriAdresler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(),
                            Convert.ToByte(dr[4]), Convert.ToInt16(dr[5]));
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
        public static void GetObjects(DataTable dt, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_MusteriAdreslerGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
