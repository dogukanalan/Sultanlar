using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class Videolar
    {
        public int pkID { get; set; }
        public int intUyeID { get; set; }
        public Uyeler Uye { get { return Uyeler.GetObject(this.intUyeID); } }
        public int intTarifID { get; set; }
        public DateTime dtTarih { get; set; }
        public string strBaslik { get; set; }
        public string strVideo { get; set; }
        public string strLink { get; set; }

        public override string ToString()
        {
            return this.strBaslik;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_Videolar] ([intUyeID],[intTarifID],[dtTarih],[strBaslik],[strVideo],[strLink]) VALUES (@intUyeID,@intTarifID,@dtTarih,@strBaslik,@strVideo,@strLink) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar, 100).Value = this.strBaslik;
                cmd.Parameters.Add("@strVideo", SqlDbType.NVarChar).Value = this.strVideo;
                cmd.Parameters.Add("@strLink", SqlDbType.NVarChar, 100).Value = this.strLink;
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

        public static List<Videolar> GetObjects(int baslangic, int kactane, string Aranan, string Siralama)
        {
            List<Videolar> donendeger = new List<Videolar>();

            string aranan = Aranan != string.Empty ? "WHERE (strBaslik LIKE '%" + Aranan + "%') " : "";
            string siralama = "ORDER BY dtTarih DESC"; 

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],[dtTarih],[strBaslik],[strVideo],[strLink] FROM tblKENTON_Videolar " + aranan + siralama, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            Videolar video = new Videolar();
                            video.pkID = Convert.ToInt32(dr[0]);
                            video.intUyeID = Convert.ToInt32(dr[1]);
                            video.intTarifID = Convert.ToInt32(dr[2]);
                            video.dtTarih = Convert.ToDateTime(dr[3]);
                            video.strBaslik = dr[4].ToString();
                            video.strVideo = dr[5].ToString();
                            video.strLink = dr[6].ToString();
                            donendeger.Add(video);
                        }
                        index++;
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

        public static Videolar GetObject(int VideoID)
        {
            Videolar donendeger = new Videolar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],[dtTarih],[strBaslik],[strVideo],[strLink] FROM tblKENTON_Videolar WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = VideoID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = Convert.ToInt32(dr[0]);
                        donendeger.intUyeID = Convert.ToInt32(dr[1]);
                        donendeger.intTarifID = Convert.ToInt32(dr[2]);
                        donendeger.dtTarih = Convert.ToDateTime(dr[3]);
                        donendeger.strBaslik = dr[4].ToString();
                        donendeger.strVideo = dr[5].ToString();
                        donendeger.strLink = dr[6].ToString();
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

        public static void GetObjects(IList Liste, int baslangic, int kactane, string Aranan, string Siralama)
        {
            string aranan = Aranan != string.Empty ? "WHERE (strBaslik LIKE '%" + Aranan + "%') " : "";
            string siralama = "ORDER BY dtTarih DESC";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],[dtTarih],[strBaslik],[strVideo],[strLink] FROM tblKENTON_Videolar " + aranan + siralama, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            Videolar video = new Videolar();
                            video.pkID = Convert.ToInt32(dr[0]);
                            video.intUyeID = Convert.ToInt32(dr[1]);
                            video.intTarifID = Convert.ToInt32(dr[2]);
                            video.dtTarih = Convert.ToDateTime(dr[3]);
                            video.strBaslik = dr[4].ToString();
                            video.strVideo = dr[5].ToString();
                            video.strLink = dr[6].ToString();
                            Liste.Add(video);
                        }
                        index++;
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

        public static DateTime GetLastObjectTime()
        {
            DateTime donendeger = new DateTime();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(dtTarih) FROM [tblKENTON_Videolar] WHERE intUyeID = 1 AND DATEADD(dd, 0, DATEDIFF(dd, 0, dtTarih)) < DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))", conn);
                try
                {
                    conn.Open();
                    donendeger = Convert.ToDateTime(cmd.ExecuteScalar());
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
