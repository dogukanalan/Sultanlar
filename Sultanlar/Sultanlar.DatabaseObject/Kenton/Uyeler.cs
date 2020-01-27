using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class Uyeler : ISultanlar
    {
        public int pkID { get; set; }
        public string strAd { get; set; }
        public string strSoyad { get; set; }
        public string strEposta { get; set; }
        public string strSifre { get; set; }
        public DateTime dtDogum { get; set; }
        public DateTime dtTarih { get; set; }
        public bool blPasif { get; set; }

        private Uyeler(int pkID, string strAd, string strSoyad, string strEposta, string strSifre, DateTime dtDogum, DateTime dtTarih, bool blPasif)
        {
            this.pkID = pkID;
            this.strAd = strAd;
            this.strSoyad = strSoyad;
            this.strEposta = strEposta;
            this.strSifre = strSifre;
            this.dtDogum = dtDogum;
            this.dtTarih = dtTarih;
            this.blPasif = blPasif;
        }

        public Uyeler(string strAd, string strSoyad, string strEposta, string strSifre, DateTime dtDogum, DateTime dtTarih, bool blPasif)
        {
            this.strAd = strAd;
            this.strSoyad = strSoyad;
            this.strEposta = strEposta;
            this.strSifre = strSifre;
            this.dtDogum = dtDogum;
            this.dtTarih = dtTarih;
            this.blPasif = blPasif;
        }

        public Uyeler()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.strAd + " " + this.strSoyad;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_Uyeler] ([strAd],[strSoyad],[strEposta],[strSifre],[dtDogum],[dtTarih],blPasif) VALUES (@strAd,@strSoyad,@strEposta,@strSifre,@dtDogum,@dtTarih,@blPasif) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = this.strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = this.strSoyad;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = this.strEposta;
                cmd.Parameters.Add("@strSifre", SqlDbType.NVarChar).Value = this.strSifre;
                cmd.Parameters.Add("@dtDogum", SqlDbType.DateTime).Value = this.dtDogum;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this.blPasif;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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

        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_Uyeler] SET [strAd] = @strAd,[strSoyad] = @strSoyad,[strEposta] = @strEposta,[strSifre] = @strSifre,[dtDogum] = @dtDogum,[dtTarih] = @dtTarih,blPasif = @blPasif WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = this.strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = this.strSoyad;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = this.strEposta;
                cmd.Parameters.Add("@strSifre", SqlDbType.NVarChar).Value = this.strSifre;
                cmd.Parameters.Add("@dtDogum", SqlDbType.DateTime).Value = this.dtDogum;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this.blPasif;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
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

        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE [tblKENTON_Uyeler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
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

        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[strAd],[strSoyad],[strEposta],[strSifre],[dtDogum],[dtTarih],blPasif FROM [tblKENTON_Uyeler] ORDER BY [strAd],[strSoyad]", conn);
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

        public static void GetObjects(IList List, bool list)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAd],[strSoyad],[strEposta],[strSifre],[dtDogum],[dtTarih],blPasif FROM [tblKENTON_Uyeler] WHERE pkID != 1 ORDER BY [strAd],[strSoyad]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Uyeler(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6]), Convert.ToBoolean(dr[7])));
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

        public static Uyeler GetObject(int ID)
        {
            Uyeler donendeger = new Uyeler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAd],[strSoyad],[strEposta],[strSifre],[dtDogum],[dtTarih],blPasif FROM [tblKENTON_Uyeler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = ID;
                        donendeger.strAd = dr[1].ToString();
                        donendeger.strSoyad = dr[2].ToString();
                        donendeger.strEposta = dr[3].ToString();
                        donendeger.strSifre = dr[4].ToString();
                        donendeger.dtDogum = Convert.ToDateTime(dr[5]);
                        donendeger.dtTarih = Convert.ToDateTime(dr[6]);
                        donendeger.blPasif = Convert.ToBoolean(dr[7]);
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

        public static int Validate(string Eposta, string Sifre)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID FROM [tblKENTON_Uyeler] WHERE strEposta = @strEposta AND strSifre = @strSifre", conn);
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = Eposta;
                cmd.Parameters.Add("@strSifre", SqlDbType.NVarChar).Value = Sifre;
                try
                {
                    conn.Open();
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

        public static bool Exist(string Eposta)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkID) FROM [tblKENTON_Uyeler] WHERE strEposta = @strEposta", conn);
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = Eposta;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
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

        public static string GetPassword(string Eposta)
        {
            string donendeger = "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strSifre FROM [tblKENTON_Uyeler] WHERE strEposta = @strEposta", conn);
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 100).Value = Eposta;
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
