using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject
{
    public class Eczaneler : IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkEczaneID;
        private byte _tintEczaneIlceID;
        private string _strEczaneAdi;
        private string _strEczaneAdresi;
        private string _strEczaneTelefonu;
        private string _strEczaneHarita;
        //
        //
        //
        // Constracter lar:
        //
        private Eczaneler(int pkEczaneID, byte tintEczaneIlceID, string strEczaneAdi, string strEczaneAdresi, string strEczaneTelefonu, string strEczaneHarita)
        {
            this._pkEczaneID = pkEczaneID;
            this._tintEczaneIlceID = tintEczaneIlceID;
            this._strEczaneAdi = strEczaneAdi;
            this._strEczaneAdresi = strEczaneAdresi;
            this._strEczaneTelefonu = strEczaneTelefonu;
            this._strEczaneHarita = strEczaneHarita;
        }
        //
        //
        public Eczaneler(byte tintEczaneIlceID, string strEczaneAdi, string strEczaneAdresi, string strEczaneTelefonu, string strEczaneHarita)
        {
            this._tintEczaneIlceID = tintEczaneIlceID;
            this._strEczaneAdi = strEczaneAdi;
            this._strEczaneAdresi = strEczaneAdresi;
            this._strEczaneTelefonu = strEczaneTelefonu;
            this._strEczaneHarita = strEczaneHarita;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkEczaneID
        {
            get
            {
                return this._pkEczaneID;
            }
        }
        //
        //
        public byte tintEczaneIlceID
        {
            get
            {
                return this._tintEczaneIlceID;
            }
            set
            {
                this._tintEczaneIlceID = value;
            }
        }
        //
        //
        public string strEczaneAdi
        {
            get
            {
                return this._strEczaneAdi;
            }
            set
            {
                this._strEczaneAdi = value;
            }
        }
        //
        //
        public string strEczaneAdresi
        {
            get
            {
                return this._strEczaneAdresi;
            }
            set
            {
                this._strEczaneAdresi = value;
            }
        }
        //
        //
        public string strEczaneTelefonu
        {
            get
            {
                return this._strEczaneTelefonu;
            }
            set
            {
                this._strEczaneTelefonu = value;
            }
        }
        //
        //
        public string strEczaneHarita
        {
            get
            {
                return this._strEczaneHarita;
            }
            set
            {
                this._strEczaneHarita = value;
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
        public static void DoInsert(byte ilce, byte gun, string eczaneAdi, string eczaneAdresi, string eczaneTelefonu, string eczaneHarita)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EczaneEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintEczaneIlceID", System.Data.SqlDbType.TinyInt).Value = ilce;
                cmd.Parameters.Add("@tintEczaneGunID", System.Data.SqlDbType.TinyInt).Value = gun;
                cmd.Parameters.Add("@strEczaneAdi", System.Data.SqlDbType.NVarChar, 50).Value = eczaneAdi;
                cmd.Parameters.Add("@strEczaneAdresi", System.Data.SqlDbType.NVarChar, 100).Value = eczaneAdresi;
                cmd.Parameters.Add("@strEczaneTelefonu", System.Data.SqlDbType.NVarChar, 50).Value = eczaneTelefonu;
                cmd.Parameters.Add("@strEczaneHarita", System.Data.SqlDbType.NVarChar, 150).Value = eczaneHarita;
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
        public static void DoDeleteAll()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EczaneSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public static object GetObject(byte EczaneIlceID)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_EczaneGetirByIlceID", conn);
                //da.SelectCommand.Connection = conn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.CommandText = "sp_EczaneGetirByIlceID";
                da.SelectCommand.Parameters.Add("@tintEczaneIlceID", SqlDbType.TinyInt).Value = EczaneIlceID;
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
        public static string[,] GetObject(string EczaneIlceID, string EczanGunID)
        {
            string[,] eczaneler = new string[10,6];
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EczaneGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintEczaneIlceID", SqlDbType.TinyInt).Value = Convert.ToByte(EczaneIlceID);
                cmd.Parameters.Add("@tintEczaneGunID", SqlDbType.TinyInt).Value = Convert.ToByte(EczanGunID != string.Empty ? EczanGunID : "0");
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int i = 0;
                    while (dr.Read())
                    {
                        eczaneler[i, 0] = dr[0].ToString();
                        eczaneler[i, 1] = dr[1].ToString();
                        eczaneler[i, 2] = dr[2].ToString();
                        eczaneler[i, 3] = dr[3].ToString();
                        eczaneler[i, 4] = dr[4].ToString();
                        eczaneler[i, 5] = dr[5].ToString();
                        i++;
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
            return eczaneler;
        }
        //
        //
        public static int GetSonGun()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EczanelerKayitliGunlerinSayisi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                    {
                        donendeger = Convert.ToInt32(obj);
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

            return donendeger;
        }
    }
}
