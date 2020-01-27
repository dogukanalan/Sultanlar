using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class EczaneIlceler : IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private byte _pkEczaneIlceID;
        private string _strEczaneIlceAdi;
        //
        //
        //
        // Constracter lar:
        //
        private EczaneIlceler(byte pkEczaneIlceID, string strEczaneIlceAdi)
        {
            this._pkEczaneIlceID = pkEczaneIlceID;
            this._strEczaneIlceAdi = strEczaneIlceAdi;
        }
        //
        //
        public EczaneIlceler(string strEczaneIlceAdi)
        {
            this._strEczaneIlceAdi = strEczaneIlceAdi;
        }
        //
        //
        //
        // Özellikler:
        //
        public byte pkEczaneIlceID
        {
            get
            {
                return this._pkEczaneIlceID;
            }
        }
        //
        //
        public string strEczaneIlceAdi
        {
            get
            {
                return this._strEczaneIlceAdi;
            }
            set
            {
                this._strEczaneIlceAdi = value;
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
            return this._strEczaneIlceAdi;
        }
        //
        //
        //
        // Metodlar:
        //
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_EczaneIlceGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new EczaneIlceler(Convert.ToByte(dr[0]), dr[1].ToString()));
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
        public static string[,] GetObject()
        {
            string[,] ilceler = new string[39,2];
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EczaneIlceGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int i = 0;
                    while (dr.Read())
                    {
                        ilceler[i, 0] = dr[0].ToString();
                        ilceler[i, 1] = dr[1].ToString();
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
            return ilceler;
        }
    }
}
