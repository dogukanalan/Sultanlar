using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class TP_PersonelTurleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private string _strTur;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private TP_PersonelTurleri(int pkID, string strTur, string strAciklama)
        {
            this._pkID = pkID;
            this._strTur = strTur;
            this._strAciklama = strAciklama;
        }
        // Constracter lar:
        //
        public TP_PersonelTurleri(string strTur, string strAciklama)
        {
            this._strTur = strTur;
            this._strAciklama = strAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public string strTur { get { return this._strTur; } set { this._strTur = value; } }
        public string strAciklama { get { return this._strAciklama; } set { this._strAciklama = value; } }
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
            return this._strTur;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Musteri-TP_PersonelTurleri] ([strTur],[strAciklama]) VALUES (@strTur,@strAciklama) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@strTur", SqlDbType.NVarChar, 50).Value = this._strTur;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-TP_PersonelTurleri] SET [strTur] = @strTur,[strAciklama] = @strAciklama WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@strTur", SqlDbType.NVarChar, 50).Value = this._strTur;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Musteri-TP_PersonelTurleri] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strTur],[strAciklama] FROM [Web-Musteri-TP_PersonelTurleri]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new TP_PersonelTurleri(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
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
