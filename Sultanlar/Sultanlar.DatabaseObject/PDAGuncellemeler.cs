using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class PDAGuncellemeler
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkPDAGuncellemeID;
        private string _strPDAGuncelleme;
        //
        //
        //
        // Constracter lar:
        //
        private PDAGuncellemeler(int pkPDAGuncellemeID, string strPDAGuncelleme)
        {
            this._pkPDAGuncellemeID = pkPDAGuncellemeID;
            this._strPDAGuncelleme = strPDAGuncelleme;
        }
        //
        //
        public PDAGuncellemeler(string strPDAGuncelleme)
        {
            this._strPDAGuncelleme = strPDAGuncelleme;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkPDAGuncellemeID
        {
            get
            {
                return this._pkPDAGuncellemeID;
            }
        }
        //
        //
        public string strPDAGuncelleme
        {
            get
            {
                return this._strPDAGuncelleme;
            }
            set
            {
                this._strPDAGuncelleme = value;
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
            return this._strPDAGuncelleme;
        }
        //
        //
        //
        // Metodlar:
        //
        public static void DoInsert(string veri)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_PDAGuncellemeEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strPDAGuncelleme", SqlDbType.NVarChar, 300).Value = veri;
                cmd.Parameters.Add("@pkPDAGuncellemeID", SqlDbType.Int).Direction = ParameterDirection.Output;
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

                SqlCommand cmd = new SqlCommand("sp_PDAGuncellemeGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new PDAGuncellemeler(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_PDAGuncellemeGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
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

                return donendeger;
            }
        }
        //
        //
        /// <summary>
        /// Ana veritabanındaki toplu güncelleme. Dikkatli kullan!
        /// </summary>
        public static void PDATopluGuncelleme()
        {
            using (SqlConnection conn = new SqlConnection("Server=SERVERDB01; Database=YSP; User Id=sultanlar; Password=pazarlama; Trusted_Connection=False;"))
            {
                SqlCommand cmd = new SqlCommand("sp_PDA_TopluAktarimi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

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
    }
}
