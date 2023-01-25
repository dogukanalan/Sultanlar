using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class TP_Personeller : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intTur;
        private string _strAd;
        private string _strSoyad;
        private string _strGorev;
        private string _strTelefon;
        private string _strKod;
        private string _strEposta;
        private string _strAciklama;
        private int _intBayi;
        //
        //
        //
        // Constracter lar:
        //
        private TP_Personeller(int pkID, int intTur, string strAd, string strSoyad, string strGorev, string strTelefon, string strKod, string strEposta, string strAciklama, int intBayi)
        {
            this._pkID = pkID;
            this._intTur = intTur;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._strGorev = strGorev;
            this._strTelefon = strTelefon;
            this._strKod = strKod;
            this._strEposta = strEposta;
            this._strAciklama = strAciklama;
            this._intBayi = intBayi;
        }
        //
        //
        public TP_Personeller(int intTur, string strAd, string strSoyad, string strGorev, string strTelefon, string strKod, string strEposta, string strAciklama, int intBayi)
        {
            this._intTur = intTur;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._strGorev = strGorev;
            this._strTelefon = strTelefon;
            this._strKod = strKod;
            this._strEposta = strEposta;
            this._strAciklama = strAciklama;
            this._intBayi = intBayi;
        }
        //
        //
        public TP_Personeller()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intTur { get { return this._intTur; } set { this._intTur = value; } }
        public string strAd { get { return this._strAd; } set { this._strAd = value; } }
        public string strSoyad { get { return this._strSoyad; } set { this._strSoyad = value; } }
        public string strGorev { get { return this._strGorev; } set { this._strGorev = value; } }
        public string strTelefon { get { return this._strTelefon; } set { this._strTelefon = value; } }
        public string strKod { get { return this._strKod; } set { this._strKod = value; } }
        public string strEposta { get { return this._strEposta; } set { this._strEposta = value; } }
        public string strAciklama { get { return this._strAciklama; } set { this._strAciklama = value; } }
        public int intBayi { get { return this._intBayi; } set { this._intBayi = value; } }
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
            return this._strAd + " " + this._strSoyad;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Musteri-TP_Personeller] ([intTur],[strAd],[strSoyad],[strGorev],[strTelefon],strKod,strEposta,[strAciklama],intBayi) VALUES (@intTur,@strAd,@strSoyad,@strGorev,@strTelefon,@strKod,@strEposta,@strAciklama,@intBayi) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intTur", SqlDbType.Int).Value = this._intTur;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = this._strSoyad;
                cmd.Parameters.Add("@strGorev", SqlDbType.NVarChar, 50).Value = this._strGorev;
                cmd.Parameters.Add("@strTelefon", SqlDbType.NVarChar, 50).Value = this._strTelefon;
                cmd.Parameters.Add("@strKod", SqlDbType.NVarChar, 50).Value = this._strKod;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = this._strEposta;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@intBayi", SqlDbType.Int).Value = this._intBayi;
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
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-TP_Personeller] SET [intTur] = @intTur,[strAd] = @strAd,[strSoyad] = @strSoyad,[strGorev] = @strGorev,[strTelefon] = @strTelefon,[strKod] = @strKod,[strEposta] = @strEposta,[strAciklama] = @strAciklama,intBayi = @intBayi WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intTur", SqlDbType.Int).Value = this._intTur;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = this._strSoyad;
                cmd.Parameters.Add("@strGorev", SqlDbType.NVarChar, 50).Value = this._strGorev;
                cmd.Parameters.Add("@strTelefon", SqlDbType.NVarChar, 50).Value = this._strTelefon;
                cmd.Parameters.Add("@strKod", SqlDbType.NVarChar, 50).Value = this._strKod;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = this._strEposta;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@intBayi", SqlDbType.Int).Value = this._intBayi;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Musteri-TP_Personeller] WHERE pkID = @pkID", conn);
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

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTur],[strAd],[strSoyad],[strGorev],[strTelefon],strKod,strEposta,[strAciklama],intBayi FROM [Web-Musteri-TP_Personeller] ORDER BY strAd,strSoyad", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new TP_Personeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9])));
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
        public static TP_Personeller GetObject(int ID)
        {
            TP_Personeller donendeger = new TP_Personeller();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTur],[strAd],[strSoyad],[strGorev],[strTelefon],strKod,strEposta,[strAciklama],intBayi FROM [Web-Musteri-TP_Personeller] WHERE pkID = @ID", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new TP_Personeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9]));
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
        //
        //
        public static TP_Personeller GetObject(string Ad, string Soyad)
        {
            TP_Personeller donendeger = new TP_Personeller();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTur],[strAd],[strSoyad],[strGorev],[strTelefon],strKod,strEposta,[strAciklama],intBayi FROM [Web-Musteri-TP_Personeller] WHERE strAd = @strAd AND strSoyad = @strSoyad", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = Ad;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = Soyad;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new TP_Personeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9]));
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
